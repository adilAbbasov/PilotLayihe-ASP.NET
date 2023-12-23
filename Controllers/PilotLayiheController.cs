using BinaPilotLayihe.Data;
using BinaPilotLayihe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Features;
using NetTopologySuite.IO;
using System.Reflection;

namespace BinaPilotLayihe.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PilotLayiheController(TestContext dbContext) : ControllerBase
	{
		private readonly TestContext _dbContext = dbContext;

		[HttpPost("api/v1/import-pois")]
		public async Task<IActionResult> ImportPois(IFormFile formFile)
		{
			try
			{
				if (formFile == null || formFile.Length == 0)
					return BadRequest("File is null or empty");

				// Read data from GeoJson file and create a FeatureCollection
				var featureCollection = CreateGeoJsonFeatureCollection(formFile);
				var poiler = new List<Poi>();

				// Iterate through features and add to the dbcontext
				foreach (var feature in featureCollection)
				{
					var poi = new Poi
					{
						Wkb_geometry = feature.Geometry,
					};

					poiler.Add(poi);
				}

				await _dbContext.Poiler.AddRangeAsync(poiler);
				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-buildings")]
		public async Task<IActionResult> ImportBuildings(IFormFile formFile1, IFormFile formFile2)
		{
			try
			{
				if (formFile1 == null || formFile1.Length == 0 || formFile2 == null || formFile2.Length == 0)
					return BadRequest("File is null or empty");

				var featureCollection1 = CreateGeoJsonFeatureCollection(formFile1);
				var featureCollection2 = CreateGeoJsonFeatureCollection(formFile2);

				var binalar1 = CreateBuildings(featureCollection1, "blue");
				await _dbContext.Binalar.AddRangeAsync(binalar1);
				await _dbContext.SaveChangesAsync();

				var binalar2 = CreateBuildings(featureCollection2, "red");
				await _dbContext.Binalar.AddRangeAsync(binalar2);
				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-roads")]
		public async Task<IActionResult> ImportRoads(IFormFile formFile)
		{
			try
			{
				if (formFile == null || formFile.Length == 0)
					return BadRequest("File is null or empty");

				var featureCollection = CreateGeoJsonFeatureCollection(formFile);
				var yollar = CreateRoads(featureCollection);

				await _dbContext.Yollar.AddRangeAsync(yollar);
				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("api/v1/export-buildings")]
		public async Task<IActionResult> ExportBuildings()
		{
			try
			{
				var binalar = await _dbContext.Binalar.ToListAsync();
				var featureCollection = new FeatureCollection();

				// Iterate through buildings, create feature for each building and add to the featureCollection
				foreach (var bina in binalar)
				{
					var geometry = bina.Geometry;
					var attributes = new AttributesTable { { "Id", bina.Id } };
					var feature = new Feature(geometry, attributes);

					featureCollection.Add(feature);
				}

				// Write to GeoJSON using NetTopologySuite
				var writer = new GeoJsonWriter();
				var geoJson = writer.Write(featureCollection);

				return Content(geoJson, "application/json");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("api/v1/get-available-buildings")]
		public async Task<IActionResult> GetAvailableBuildings()
		{
			var availableBuildings = await _dbContext.Binalar.OrderBy(b => b.Id).Select(b => b.Id).ToListAsync();
			return Ok(availableBuildings);
		}

		[HttpGet("api/v1/export-building/{id}")]
		public async Task<IActionResult> ExportBuilding(int id)
		{
			try
			{
				var bina = await _dbContext.Binalar.FindAsync(id);

				if (bina == null)
					return NotFound($"Building with ID {id} not found.");

				// Create feature for building 
				var geometry = bina.Geometry;
				var attributes = new AttributesTable { { "Id", bina.Id } };
				var feature = new Feature(geometry, attributes);

				// Write to GeoJSON using NetTopologySuite
				var writer = new GeoJsonWriter();
				var geoJson = writer.Write(feature);

				return Content(geoJson, "application/json");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("api/v1/update-building/{id}")]
		public async Task<IActionResult> UpdateBuilding(int id, IFormFile formFile)
		{
			try
			{
				if (formFile == null || formFile.Length == 0)
					return BadRequest("File is null or empty");

				var feature = CreateGeoJsonFeature(formFile);
				var bina = await _dbContext.Binalar.FindAsync(id);

				if (bina == null)
					return NotFound($"Building with ID {id} not found.");

				bina = GetEntityWithProperties(bina, feature.Attributes);
				bina.Geometry = feature.Geometry;

				_dbContext.Entry(bina).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();

				return Ok($"Building with ID {id} updated successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("api/v1/delete-building/{id}")]
		public async Task<IActionResult> DeleteBuilding(int id)
		{
			try
			{
				var bina = await _dbContext.Binalar.FindAsync(id);

				if (bina == null)
					return NotFound($"Building with ID {id} not found.");

				_dbContext.Binalar.Remove(bina);
				await _dbContext.SaveChangesAsync();

				return Ok($"Building with ID {id} deleted successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-building")]
		public async Task<IActionResult> ImportBuilding(IFormFile formFile)
		{
			try
			{
				if (formFile == null || formFile.Length == 0)
					return BadRequest("File is null or empty");

				var feature = CreateGeoJsonFeature(formFile);

				var bina = new Bina();
				bina = GetEntityWithProperties(bina, feature.Attributes);
				bina.Geometry = feature.Geometry;

				await _dbContext.Binalar.AddAsync(bina);
				await _dbContext.SaveChangesAsync();

				return Ok($"Building added successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-lines")]
		public async Task<IActionResult> ImportLines(IFormFile formFile)
		{
			try
			{
				if (formFile == null || formFile.Length == 0)
					return BadRequest("File is null or empty");

				var featureCollection = CreateGeoJsonFeatureCollection(formFile);
				var cizgiler = new List<Cizgi>();

				foreach (var feature in featureCollection.Cast<Feature>())
				{
					var cizgi = new Cizgi();
					cizgi = GetEntityWithProperties(cizgi, feature.Attributes);
					cizgi.Wkb_geometry = feature.Geometry;

					cizgiler.Add(cizgi);
				}

				await _dbContext.Cizgiler.AddRangeAsync(cizgiler);
				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-points")]
		public async Task<IActionResult> ImportPoints(IFormFile formFile)
		{
			try
			{
				if (formFile == null || formFile.Length == 0)
					return BadRequest("File is null or empty");

				var featureCollection = CreateGeoJsonFeatureCollection(formFile);
				var noktalar = new List<Nokta>();

				foreach (var feature in featureCollection.Cast<Feature>())
				{
					var nokta = new Nokta();
					nokta = GetEntityWithProperties(nokta, feature.Attributes);
					nokta.Wkb_geometry = feature.Geometry;

					noktalar.Add(nokta);
				}

				await _dbContext.Noktalar.AddRangeAsync(noktalar);
				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/insert-buffers")]
		public IActionResult InsertBuffers()
		{
			try
			{
				var sql = "INSERT INTO buffers (Cizgi_Id, Buffer_Type, State, Geometry) SELECT ogc_fid, 'start' AS Buffer_Type, false AS State, ST_SetSRID(ST_Buffer(ST_StartPoint(wkb_geometry)::geography, 25), 4326)::geometry AS Geometry FROM cizgiler; INSERT INTO buffers (Cizgi_Id, Buffer_Type, State, Geometry) SELECT ogc_fid, 'center' AS Buffer_Type, false AS State, ST_SetSRID(ST_Buffer(ST_LineInterpolatePoint(wkb_geometry, 0.5)::geography, 25), 4326)::geometry AS Geometry FROM cizgiler; INSERT INTO buffers (Cizgi_Id, Buffer_Type, State, Geometry) SELECT ogc_fid, 'end' AS Buffer_Type, false AS State, ST_SetSRID(ST_Buffer(ST_EndPoint(wkb_geometry)::geography, 25), 4326)::geometry AS Geometry FROM cizgiler;";

				_dbContext.Database.ExecuteSqlRaw(sql);

				return Ok("Buffers inserted successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("api/v1/update-buffer-states")]
		public IActionResult UpdateBufferStates()
		{
			try
			{
				var sql = "UPDATE buffers SET state = EXISTS (SELECT 1 FROM noktalar n WHERE ST_Within(n.wkb_geometry, Geometry) AND Buffer_Type IN ('start', 'center', 'end'));";

				_dbContext.Database.ExecuteSqlRaw(sql);

				return Ok("Buffer states updated successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpPut("api/v1/update-cizgiler")]
		public IActionResult UpdateCizgiler()
		{
			try
			{
				var sql1 = "UPDATE cizgiler c SET analysed = CASE WHEN (SELECT COUNT(*) FROM buffers WHERE cizgi_id = c.ogc_fid AND buffer_type IN ('start', 'center', 'end') AND state = true) = 3 THEN 1 WHEN (SELECT COUNT(*) FROM buffers WHERE cizgi_id = c.ogc_fid AND buffer_type IN ('start', 'end') AND state = true) = 2 THEN 3 WHEN (SELECT COUNT(*) FROM buffers WHERE cizgi_id = c.ogc_fid AND buffer_type IN ('start', 'center') AND state = true) = 2 OR (SELECT COUNT(*) FROM buffers WHERE cizgi_id = c.ogc_fid AND buffer_type IN ('center', 'end') AND state = true) = 2 THEN 2 ELSE 0 END, color = CASE WHEN analysed = '1' THEN 'green' WHEN analysed = '2' THEN 'yellow' WHEN analysed = '3' THEN 'red' ELSE color END;";
				
				var sql2 = "UPDATE cizgiler c SET color = CASE WHEN analysed = '1' THEN 'green' WHEN analysed = '2' THEN 'yellow' WHEN analysed = '3' THEN 'red' ELSE color END;";

				_dbContext.Database.ExecuteSqlRaw(sql1);
				_dbContext.Database.ExecuteSqlRaw(sql2);

				return Ok("Cizgiler updated successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private static string ReadFileContent(IFormFile formFile)
		{
			using var formFileReader = new StreamReader(formFile.OpenReadStream());
			var fileContent = formFileReader.ReadToEnd();

			return fileContent;
		}

		private static Feature CreateGeoJsonFeature(IFormFile formFile)
		{
			var fileContent = ReadFileContent(formFile);
			var geoJsonReader = new GeoJsonReader();
			var feature = geoJsonReader.Read<Feature>(fileContent);

			return feature;
		}

		private static FeatureCollection CreateGeoJsonFeatureCollection(IFormFile formFile)
		{
			var fileContent = ReadFileContent(formFile);
			var geoJsonReader = new GeoJsonReader();
			var featureCollection = geoJsonReader.Read<FeatureCollection>(fileContent);

			return featureCollection;
		}

		private List<Bina> CreateBuildings(FeatureCollection features, string color)
		{
			var binalar = new List<Bina>();

			foreach (var feature in features)
			{
				var sql = "SELECT * FROM binalar WHERE ST_Equals(geometry, ST_GeomFromText({0}, 4326))";
				var geometryText = feature.Geometry.AsText();
				var exists = _dbContext.Binalar.FromSqlRaw(sql, geometryText).Any();

				if (!exists)
				{
					var bina = new Bina
					{
						Geometry = feature.Geometry,
						Color = color
					};

					binalar.Add(bina);
				}
			}

			return binalar;
		}

		private List<Yol> CreateRoads(FeatureCollection features)
		{
			var yollar = new List<Yol>();

			foreach (var feature in features)
			{
				if (yollar.Any(y => y.Wkb_geometry.Crosses(feature.Geometry)))
					continue;

				var sql = "SELECT * FROM yollar WHERE ST_Crosses(wkb_geometry, ST_GeomFromText({0}, 4326))";
				var geometryText = feature.Geometry.AsText();
				var exists = _dbContext.Yollar.FromSqlRaw(sql, geometryText).Any();

				if (!exists)
				{
					var yol = new Yol
					{
						Wkb_geometry = feature.Geometry,
					};

					yollar.Add(yol);
				}
			}

			return yollar;
		}

		private static Dictionary<string, object> GetAttributeDictionary(IAttributesTable attributesTable)
		{
			var attributeDictionary = new Dictionary<string, object>();

			foreach (var attribute in attributesTable.GetNames())
			{
				string attributeName;

				if (attribute == "id")
					continue;
				else if (attribute.Contains(':'))
					attributeName = attribute.Replace(":", "");
				else
					attributeName = attribute;

				var attributeValue = attributesTable[attribute];

				attributeDictionary[attributeName] = attributeValue;
			}

			return attributeDictionary;
		}

		private static T GetEntityWithProperties<T>(T entity, IAttributesTable attributes) where T : new()
		{
			var attributeDictionary = GetAttributeDictionary(attributes);

			foreach (var attribute in attributeDictionary)
			{
				var propertyName = attribute.Key;
				var propertyValue = attribute.Value?.ToString();

				var propertyInfo = entity.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

				if (propertyInfo != null)
				{
					if (propertyInfo.PropertyType == typeof(int?))
					{
						if (int.TryParse(propertyValue, out int convertedValue))
							propertyInfo.SetValue(entity, convertedValue);
					}
					else if (propertyInfo.PropertyType == typeof(string))
					{
						var convertedValue = Convert.ChangeType(propertyValue, propertyInfo.PropertyType);
						propertyInfo.SetValue(entity, convertedValue);
					}
				}
			}

			return entity;
		}
	}
}
