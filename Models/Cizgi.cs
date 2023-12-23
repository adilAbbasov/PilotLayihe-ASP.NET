using NetTopologySuite.Geometries;

namespace BinaPilotLayihe.Models
{
	public class Cizgi
	{
		public int OgcFid { get; set; }

		public int? Index { get; set; }
	
		public int? Passed { get; set; }
		
		public int? Analysed { get; set; }

		public string? Geotype { get; set; }

		public ICollection<Buffer>? Buffers { get; set; }

		public Geometry? Wkb_geometry { get; set; }
	}
}
