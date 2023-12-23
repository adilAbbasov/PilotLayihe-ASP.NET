using NetTopologySuite.Geometries;

namespace BinaPilotLayihe.Models
{
	public class Buffer
	{
		public int Id { get; set; }

		public Cizgi Cizgi { get; set; }

		public int Cizgi_Id { get; set; }

		public string Buffer_Type { get; set; }

		public bool State { get; set; }

		public Geometry Geometry { get; set; }
	}
}
