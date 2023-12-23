using NetTopologySuite.Geometries;

namespace BinaPilotLayihe.Models
{
	public class Nokta
	{
		public int OgcFid { get; set; }

		public int? Index { get; set; }

		public string? Geotype { get; set; }

		public Geometry? Wkb_geometry { get; set; }
	}
}
