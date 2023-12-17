using BinaPilotLayihe.Data;
using BinaPilotLayihe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace BinaPilotLayihe.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PilotLayiheController : ControllerBase
	{
		private readonly TestContext _dbContext;

		public PilotLayiheController(TestContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpPost("api/v1/import-points")]
		public async Task<IActionResult> ImportPoints()
		{
			try
			{
				// File path for GeoJSON data
				var filePath = "C:/Users/acer/Dropbox/Мой ПК (Adil)/Desktop/data/poi.geojson";
				var geoJson = System.IO.File.ReadAllText(filePath);

				// Read GeoJSON using NetTopologySuite
				var reader = new GeoJsonReader();
				var featureCollection = reader.Read<FeatureCollection>(geoJson);

				// Iterate through features and add to the dbcontext
				foreach (var feature in featureCollection)
				{
					var poi = new Poi
					{
						Wkb_geometry = feature.Geometry,
					};

					await _dbContext.Poiler.AddAsync(poi);
				}

				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-buildings")]
		public async Task<IActionResult> ImportBuildings()
		{
			try
			{
				var file1Path = "C:/Users/acer/Dropbox/Мой ПК (Adil)/Desktop/data/bina1.geojson";
				var file2Path = "C:/Users/acer/Dropbox/Мой ПК (Adil)/Desktop/data/bina2.geojson";

				var geoJson1 = System.IO.File.ReadAllText(file1Path);
				var geoJson2 = System.IO.File.ReadAllText(file2Path);

				var reader = new GeoJsonReader();

				var featureCollection1 = reader.Read<FeatureCollection>(geoJson1);
				var featureCollection2 = reader.Read<FeatureCollection>(geoJson2);

				foreach (var feature in featureCollection1)
				{
					var geometry = feature.Geometry;

					if (!IsGeometryExisting(geometry))
					{
						var bina = new Bina
						{
							Geometry = geometry,
							Color = "red"
						};

						await _dbContext.Binalar.AddAsync(bina);
					}
				}

				foreach (var feature in featureCollection2)
				{
					var geometry = feature.Geometry;

					if (!IsGeometryExisting(geometry))
					{
						var bina = new Bina
						{
							Geometry = geometry,
							Color = "blue"
						};

						await _dbContext.Binalar.AddAsync(bina);
					}
				}

				await _dbContext.SaveChangesAsync();

				return Ok("GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-roads")]
		public async Task<IActionResult> ImportRoads()
		{
			try
			{
				var filePath = "C:/Users/acer/Dropbox/Мой ПК (Adil)/Desktop/data/yollar.geojson";
				var geoJson = System.IO.File.ReadAllText(filePath);

				var reader = new GeoJsonReader();
				var featureCollection = reader.Read<FeatureCollection>(geoJson);

				foreach (var feature in featureCollection)
				{
					var geometry = feature.Geometry;

					if (!AreGeometriesCrossing(geometry))
					{
						var yol = new Yol
						{
							Wkb_geometry = geometry,
						};

						await _dbContext.Yollar.AddAsync(yol);
					}
				}

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
				var buildings = await _dbContext.Binalar.ToListAsync();
				var featureCollection = new FeatureCollection();

				// Iterate through buildings, create feature for each building and add to the featureCollection
				foreach (var building in buildings)
				{
					var geometry = building.Geometry;
					var attributes = new AttributesTable { { "Id", building.Id } };
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

		[HttpGet("api/v1/export-building/{id}")]
		public async Task<IActionResult> ExportBuilding(int id)
		{
			try
			{
				var building = await _dbContext.Binalar.FindAsync(id);

				if (building == null)
				{
					return NotFound($"Building with ID {id} not found.");
				}

				// Create feature for building 
				var geometry = building.Geometry;
				var attributes = new AttributesTable { { "Id", building.Id } };
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
		public async Task<IActionResult> UpdateBuilding(int id)
		{
			try
			{
				var filePath = "C:/Users/acer/Dropbox/Мой ПК (Adil)/Desktop/data/bina-update.geojson";
				var geoJson = System.IO.File.ReadAllText(filePath);

				var reader = new GeoJsonReader();
				var feature = reader.Read<Feature>(geoJson);

				var building = await _dbContext.Binalar.FindAsync(id);

				if (building == null)
				{
					return NotFound($"Building with ID {id} not found.");
				}

				// Update building based on feature attributes and geometry
				// The attribute keys do not match with the property names of building model, so i mapped attributes manually
				// If you are interested, check the extensions.txt file to see mapping attributes through iteration
				building.AddrCity = feature.Attributes["addr:city"] as string;
				building.AddrCountry = feature.Attributes["addr:country"] as string;
				building.AddrHousenumber = feature.Attributes["addr:housenumber"] as string;
				building.AddrPostcode = feature.Attributes["addr:postcode"] as string;
				building.AddrStreet = feature.Attributes["addr:street"] as string;
				building.Building = feature.Attributes["building"] as string;
				building.BuildingLevels = feature.Attributes["building:levels"] as string;
				building.Name = feature.Attributes["name"] as string;
				building.NameAz = feature.Attributes["name:az"] as string;
				building.NameEn = feature.Attributes["name:en"] as string;
				building.NameRu = feature.Attributes["name:ru"] as string;
				building.Geotype = feature.Attributes["geotype"] as string;
				building.Index = int.Parse(feature.Attributes["index"].ToString());
				building.Geometry = feature.Geometry;

				_dbContext.Entry(building).State = EntityState.Modified;
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
				var building = await _dbContext.Binalar.FindAsync(id);

				if (building == null)
				{
					return NotFound($"Building with ID {id} not found.");
				}

				_dbContext.Binalar.Remove(building);
				await _dbContext.SaveChangesAsync();

				return Ok($"Building with ID {id} deleted successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("api/v1/import-building")]
		public async Task<IActionResult> ImportBuilding()
		{
			try
			{
				var filePath = "C:/Users/acer/Dropbox/Мой ПК (Adil)/Desktop/data/bina-add.geojson";
				var geoJson = System.IO.File.ReadAllText(filePath);

				var reader = new GeoJsonReader();
				var feature = reader.Read<Feature>(geoJson);

				// Create object based on feature attributes and geometry
				var bina = new Bina
				{
					Index = int.Parse(feature.Attributes["index"].ToString()),
					Geotype = feature.Attributes["geotype"] as string,
					Geometry = feature.Geometry
				};

				await _dbContext.Binalar.AddAsync(bina);
				await _dbContext.SaveChangesAsync();

				return Ok($"GeoJSON data imported successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private bool IsGeometryExisting(Geometry? newGeometry)
		{
			return _dbContext.ChangeTracker.Entries<Bina>().Any(bina => bina.Entity.Geometry.EqualsExact(newGeometry));
		}

		private bool AreGeometriesCrossing(Geometry? newGeometry)
		{
			return _dbContext.ChangeTracker.Entries<Yol>().Any(yol => yol.Entity.Wkb_geometry.Crosses(newGeometry));
		}
	}
}
