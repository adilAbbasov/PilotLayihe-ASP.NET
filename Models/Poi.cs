using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace BinaPilotLayihe.Models;

public partial class Poi : Entity
{
	public int OgcFid { get; set; }

	public string? AddrCity { get; set; }

	public string? AddrHousenumber { get; set; }

	public string? AddrPostcode { get; set; }

	public string? AddrStreet { get; set; }

	public string? AltName { get; set; }

	public string? Amenity { get; set; }

	public string? Atm { get; set; }

	public string? Backrest { get; set; }

	public string? Brand { get; set; }

	public string? BrandWikidata { get; set; }

	public string? BrandWikipedia { get; set; }

	public string? ContactEmail { get; set; }

	public string? ContactFacebook { get; set; }

	public string? ContactInstagram { get; set; }

	public string? ContactPhone { get; set; }

	public string? ContactWebsite { get; set; }

	public string? Cuisine { get; set; }

	public string? Delivery { get; set; }

	public string? DietHalal { get; set; }

	public string? DietMeat { get; set; }

	public string? DietVegan { get; set; }

	public string? DietVegetarian { get; set; }

	public string? DriveThrough { get; set; }

	public string? Facebook { get; set; }

	public string? Image { get; set; }

	public string? InternetAccess { get; set; }

	public string? InternetAccessFee { get; set; }

	public string? Name { get; set; }

	public string? NameAr { get; set; }

	public string? NameAz { get; set; }

	public string? NameEn { get; set; }

	public string? NameFa { get; set; }

	public string? NameRu { get; set; }

	public string? NameTr { get; set; }

	public string? OfficialName { get; set; }

	public string? OpeningHours { get; set; }

	public string? OpeningHoursCovid19 { get; set; }

	public string? Operator { get; set; }

	public string? OutdoorSeating { get; set; }

	public string? Phone { get; set; }

	public string? RefVatin { get; set; }

	public string? SourceRefUrl { get; set; }

	public string? Takeaway { get; set; }

	public string? Website { get; set; }

	public string? Wikidata { get; set; }

	public string? Wikipedia { get; set; }

	public string? Geotype { get; set; }

	public int? Index { get; set; }

	public Geometry? Wkb_geometry { get; set; }
}
