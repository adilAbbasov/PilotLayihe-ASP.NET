using NetTopologySuite.Geometries;

namespace BinaPilotLayihe.Models;

public partial class Yol : Entity
{
	public int OgcFid { get; set; }

	public string? Access { get; set; }

	public string? AltName { get; set; }

	public string? Bicycle { get; set; }

	public string? Bridge { get; set; }

	public string? Covered { get; set; }

	public string? Crossing { get; set; }

	public string? Foot { get; set; }

	public string? Footway { get; set; }

	public string? Highway { get; set; }

	public string? Horse { get; set; }

	public string? IntName { get; set; }

	public string? IntRef { get; set; }

	public string? Junction { get; set; }

	public string? LaneMarkings { get; set; }

	public string? Lanes { get; set; }

	public string? Layer { get; set; }

	public string? Lit { get; set; }

	public string? Maxspeed { get; set; }

	public string? Maxwidth { get; set; }

	public string? MotorVehicle { get; set; }

	public string? Name { get; set; }

	public string? NameAz { get; set; }

	public string? NameAzCyr { get; set; }

	public string? NameEn { get; set; }

	public string? NameRu { get; set; }

	public string? OldName { get; set; }

	public string? OldNameRu { get; set; }

	public string? Oneway { get; set; }

	public string? Service { get; set; }

	public string? SourceGeometry { get; set; }

	public string? Surface { get; set; }

	public string? Tunnel { get; set; }

	public string? Geotype { get; set; }

	public int? Index { get; set; }

	public Geometry? Wkb_geometry { get; set; }
}
