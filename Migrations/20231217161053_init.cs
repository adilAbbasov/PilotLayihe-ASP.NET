using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BinaPilotLayihe.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "bina",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    addrcity = table.Column<string>(name: "addr:city", type: "character varying", nullable: true),
                    addrcountry = table.Column<string>(name: "addr:country", type: "character varying", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "character varying", nullable: true),
                    addrpostcode = table.Column<string>(name: "addr:postcode", type: "character varying", nullable: true),
                    addrstreet = table.Column<string>(name: "addr:street", type: "character varying", nullable: true),
                    amenity = table.Column<string>(type: "character varying", nullable: true),
                    bathopen_air = table.Column<string>(name: "bath:open_air", type: "character varying", nullable: true),
                    bathsand_bath = table.Column<string>(name: "bath:sand_bath", type: "character varying", nullable: true),
                    brand = table.Column<string>(type: "character varying", nullable: true),
                    building = table.Column<string>(type: "character varying", nullable: true),
                    buildinglevels = table.Column<string>(name: "building:levels", type: "character varying", nullable: true),
                    charge = table.Column<string>(type: "character varying", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    fee = table.Column<string>(type: "character varying", nullable: true),
                    internet_access = table.Column<string>(type: "character varying", nullable: true),
                    internet_accessfee = table.Column<string>(name: "internet_access:fee", type: "character varying", nullable: true),
                    leisure = table.Column<string>(type: "character varying", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    namear = table.Column<string>(name: "name:ar", type: "character varying", nullable: true),
                    nameaz = table.Column<string>(name: "name:az", type: "character varying", nullable: true),
                    nameen = table.Column<string>(name: "name:en", type: "character varying", nullable: true),
                    nameru = table.Column<string>(name: "name:ru", type: "character varying", nullable: true),
                    opening_hours = table.Column<string>(type: "character varying", nullable: true),
                    opening_hourscovid19 = table.Column<string>(name: "opening_hours:covid19", type: "character varying", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "character varying", nullable: true),
                    paymentcash = table.Column<string>(name: "payment:cash", type: "character varying", nullable: true),
                    paymentmastercard = table.Column<string>(name: "payment:mastercard", type: "character varying", nullable: true),
                    paymentvisa = table.Column<string>(name: "payment:visa", type: "character varying", nullable: true),
                    phone = table.Column<string>(type: "character varying", nullable: true),
                    phone_1 = table.Column<string>(type: "character varying", nullable: true),
                    shop = table.Column<string>(type: "character varying", nullable: true),
                    source = table.Column<string>(type: "character varying", nullable: true),
                    tourism = table.Column<string>(type: "character varying", nullable: true),
                    geotype = table.Column<string>(type: "character varying", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: true),
                    color = table.Column<string>(type: "character varying", nullable: true),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bina_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "poi",
                columns: table => new
                {
                    ogc_fid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    addrcity = table.Column<string>(name: "addr:city", type: "character varying", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "character varying", nullable: true),
                    addrpostcode = table.Column<string>(name: "addr:postcode", type: "character varying", nullable: true),
                    addrstreet = table.Column<string>(name: "addr:street", type: "character varying", nullable: true),
                    alt_name = table.Column<string>(type: "character varying", nullable: true),
                    amenity = table.Column<string>(type: "character varying", nullable: true),
                    atm = table.Column<string>(type: "character varying", nullable: true),
                    backrest = table.Column<string>(type: "character varying", nullable: true),
                    brand = table.Column<string>(type: "character varying", nullable: true),
                    brandwikidata = table.Column<string>(name: "brand:wikidata", type: "character varying", nullable: true),
                    brandwikipedia = table.Column<string>(name: "brand:wikipedia", type: "character varying", nullable: true),
                    contactemail = table.Column<string>(name: "contact:email", type: "character varying", nullable: true),
                    contactfacebook = table.Column<string>(name: "contact:facebook", type: "character varying", nullable: true),
                    contactinstagram = table.Column<string>(name: "contact:instagram", type: "character varying", nullable: true),
                    contactphone = table.Column<string>(name: "contact:phone", type: "character varying", nullable: true),
                    contactwebsite = table.Column<string>(name: "contact:website", type: "character varying", nullable: true),
                    cuisine = table.Column<string>(type: "character varying", nullable: true),
                    delivery = table.Column<string>(type: "character varying", nullable: true),
                    diethalal = table.Column<string>(name: "diet:halal", type: "character varying", nullable: true),
                    dietmeat = table.Column<string>(name: "diet:meat", type: "character varying", nullable: true),
                    dietvegan = table.Column<string>(name: "diet:vegan", type: "character varying", nullable: true),
                    dietvegetarian = table.Column<string>(name: "diet:vegetarian", type: "character varying", nullable: true),
                    drive_through = table.Column<string>(type: "character varying", nullable: true),
                    facebook = table.Column<string>(type: "character varying", nullable: true),
                    image = table.Column<string>(type: "character varying", nullable: true),
                    internet_access = table.Column<string>(type: "character varying", nullable: true),
                    internet_accessfee = table.Column<string>(name: "internet_access:fee", type: "character varying", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    namear = table.Column<string>(name: "name:ar", type: "character varying", nullable: true),
                    nameaz = table.Column<string>(name: "name:az", type: "character varying", nullable: true),
                    nameen = table.Column<string>(name: "name:en", type: "character varying", nullable: true),
                    namefa = table.Column<string>(name: "name:fa", type: "character varying", nullable: true),
                    nameru = table.Column<string>(name: "name:ru", type: "character varying", nullable: true),
                    nametr = table.Column<string>(name: "name:tr", type: "character varying", nullable: true),
                    official_name = table.Column<string>(type: "character varying", nullable: true),
                    opening_hours = table.Column<string>(type: "character varying", nullable: true),
                    opening_hourscovid19 = table.Column<string>(name: "opening_hours:covid19", type: "character varying", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "character varying", nullable: true),
                    outdoor_seating = table.Column<string>(type: "character varying", nullable: true),
                    phone = table.Column<string>(type: "character varying", nullable: true),
                    refvatin = table.Column<string>(name: "ref:vatin", type: "character varying", nullable: true),
                    source_refurl = table.Column<string>(name: "source_ref:url", type: "character varying", nullable: true),
                    takeaway = table.Column<string>(type: "character varying", nullable: true),
                    website = table.Column<string>(type: "character varying", nullable: true),
                    wikidata = table.Column<string>(type: "character varying", nullable: true),
                    wikipedia = table.Column<string>(type: "character varying", nullable: true),
                    geotype = table.Column<string>(type: "character varying", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: true),
                    wkb_geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    id = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("poi_pkey", x => x.ogc_fid);
                });

            migrationBuilder.CreateTable(
                name: "yol",
                columns: table => new
                {
                    ogc_fid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    access = table.Column<string>(type: "character varying", nullable: true),
                    alt_name = table.Column<string>(type: "character varying", nullable: true),
                    bicycle = table.Column<string>(type: "character varying", nullable: true),
                    bridge = table.Column<string>(type: "character varying", nullable: true),
                    covered = table.Column<string>(type: "character varying", nullable: true),
                    crossing = table.Column<string>(type: "character varying", nullable: true),
                    foot = table.Column<string>(type: "character varying", nullable: true),
                    footway = table.Column<string>(type: "character varying", nullable: true),
                    highway = table.Column<string>(type: "character varying", nullable: true),
                    horse = table.Column<string>(type: "character varying", nullable: true),
                    int_name = table.Column<string>(type: "character varying", nullable: true),
                    int_ref = table.Column<string>(type: "character varying", nullable: true),
                    junction = table.Column<string>(type: "character varying", nullable: true),
                    lane_markings = table.Column<string>(type: "character varying", nullable: true),
                    lanes = table.Column<string>(type: "character varying", nullable: true),
                    layer = table.Column<string>(type: "character varying", nullable: true),
                    lit = table.Column<string>(type: "character varying", nullable: true),
                    maxspeed = table.Column<string>(type: "character varying", nullable: true),
                    maxwidth = table.Column<string>(type: "character varying", nullable: true),
                    motor_vehicle = table.Column<string>(type: "character varying", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    nameaz = table.Column<string>(name: "name:az", type: "character varying", nullable: true),
                    nameaz_cyr = table.Column<string>(name: "name:az_cyr", type: "character varying", nullable: true),
                    nameen = table.Column<string>(name: "name:en", type: "character varying", nullable: true),
                    nameru = table.Column<string>(name: "name:ru", type: "character varying", nullable: true),
                    old_name = table.Column<string>(type: "character varying", nullable: true),
                    old_nameru = table.Column<string>(name: "old_name:ru", type: "character varying", nullable: true),
                    oneway = table.Column<string>(type: "character varying", nullable: true),
                    service = table.Column<string>(type: "character varying", nullable: true),
                    sourcegeometry = table.Column<string>(name: "source:geometry", type: "character varying", nullable: true),
                    surface = table.Column<string>(type: "character varying", nullable: true),
                    tunnel = table.Column<string>(type: "character varying", nullable: true),
                    geotype = table.Column<string>(type: "character varying", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: true),
                    wkb_geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    id = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("yollar_pkey", x => x.ogc_fid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bina");

            migrationBuilder.DropTable(
                name: "poi");

            migrationBuilder.DropTable(
                name: "yol");
        }
    }
}
