using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace BinaPilotLayihe.Models;

public partial class Bina
{
	public int Id { get; set; }

	public string? AddrCity { get; set; }

	public string? AddrCountry { get; set; }

	public string? AddrHousenumber { get; set; }

	public string? AddrPostcode { get; set; }

	public string? AddrStreet { get; set; }

	public string? Amenity { get; set; }

	public string? BathOpenAir { get; set; }

	public string? BathSandBath { get; set; }

	public string? Brand { get; set; }

	public string? Building { get; set; }

	public string? BuildingLevels { get; set; }

	public string? Charge { get; set; }

	public string? Description { get; set; }

	public string? Fee { get; set; }

	public string? InternetAccess { get; set; }

	public string? InternetAccessFee { get; set; }

	public string? Leisure { get; set; }

	public string? Name { get; set; }

	public string? NameAr { get; set; }

	public string? NameAz { get; set; }

	public string? NameEn { get; set; }

	public string? NameRu { get; set; }

	public string? OpeningHours { get; set; }

	public string? OpeningHoursCovid19 { get; set; }

	public string? Operator { get; set; }

	public string? PaymentCash { get; set; }

	public string? PaymentMastercard { get; set; }

	public string? PaymentVisa { get; set; }

	public string? Phone { get; set; }

	public string? Phone1 { get; set; }

	public string? Shop { get; set; }

	public string? Source { get; set; }

	public string? Tourism { get; set; }

	public string? Geotype { get; set; }

	public int? Index { get; set; }

	public string? Color { get; set; }

	public Geometry? Geometry { get; set; }
}
