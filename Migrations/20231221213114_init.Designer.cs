﻿// <auto-generated />
using System;
using BinaPilotLayihe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BinaPilotLayihe.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20231221213114_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BinaPilotLayihe.Models.Bina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddrCity")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:city");

                    b.Property<string>("AddrCountry")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:country");

                    b.Property<string>("AddrHousenumber")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:housenumber");

                    b.Property<string>("AddrPostcode")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:postcode");

                    b.Property<string>("AddrStreet")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:street");

                    b.Property<string>("Amenity")
                        .HasColumnType("character varying")
                        .HasColumnName("amenity");

                    b.Property<string>("BathOpenAir")
                        .HasColumnType("character varying")
                        .HasColumnName("bath:open_air");

                    b.Property<string>("BathSandBath")
                        .HasColumnType("character varying")
                        .HasColumnName("bath:sand_bath");

                    b.Property<string>("Brand")
                        .HasColumnType("character varying")
                        .HasColumnName("brand");

                    b.Property<string>("Building")
                        .HasColumnType("character varying")
                        .HasColumnName("building");

                    b.Property<string>("BuildingLevels")
                        .HasColumnType("character varying")
                        .HasColumnName("building:levels");

                    b.Property<string>("Charge")
                        .HasColumnType("character varying")
                        .HasColumnName("charge");

                    b.Property<string>("Color")
                        .HasColumnType("character varying")
                        .HasColumnName("color");

                    b.Property<string>("Description")
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<string>("Fee")
                        .HasColumnType("character varying")
                        .HasColumnName("fee");

                    b.Property<Geometry>("Geometry")
                        .HasColumnType("geometry")
                        .HasColumnName("geometry");

                    b.Property<string>("Geotype")
                        .HasColumnType("character varying")
                        .HasColumnName("geotype");

                    b.Property<int?>("Index")
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<string>("InternetAccess")
                        .HasColumnType("character varying")
                        .HasColumnName("internet_access");

                    b.Property<string>("InternetAccessFee")
                        .HasColumnType("character varying")
                        .HasColumnName("internet_access:fee");

                    b.Property<string>("Leisure")
                        .HasColumnType("character varying")
                        .HasColumnName("leisure");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("NameAr")
                        .HasColumnType("character varying")
                        .HasColumnName("name:ar");

                    b.Property<string>("NameAz")
                        .HasColumnType("character varying")
                        .HasColumnName("name:az");

                    b.Property<string>("NameEn")
                        .HasColumnType("character varying")
                        .HasColumnName("name:en");

                    b.Property<string>("NameRu")
                        .HasColumnType("character varying")
                        .HasColumnName("name:ru");

                    b.Property<string>("OpeningHours")
                        .HasColumnType("character varying")
                        .HasColumnName("opening_hours");

                    b.Property<string>("OpeningHoursCovid19")
                        .HasColumnType("character varying")
                        .HasColumnName("opening_hours:covid19");

                    b.Property<string>("Operator")
                        .HasColumnType("character varying")
                        .HasColumnName("operator");

                    b.Property<string>("PaymentCash")
                        .HasColumnType("character varying")
                        .HasColumnName("payment:cash");

                    b.Property<string>("PaymentMastercard")
                        .HasColumnType("character varying")
                        .HasColumnName("payment:mastercard");

                    b.Property<string>("PaymentVisa")
                        .HasColumnType("character varying")
                        .HasColumnName("payment:visa");

                    b.Property<string>("Phone")
                        .HasColumnType("character varying")
                        .HasColumnName("phone");

                    b.Property<string>("Phone1")
                        .HasColumnType("character varying")
                        .HasColumnName("phone_1");

                    b.Property<string>("Shop")
                        .HasColumnType("character varying")
                        .HasColumnName("shop");

                    b.Property<string>("Source")
                        .HasColumnType("character varying")
                        .HasColumnName("source");

                    b.Property<string>("Tourism")
                        .HasColumnType("character varying")
                        .HasColumnName("tourism");

                    b.HasKey("Id")
                        .HasName("bina_pkey");

                    b.ToTable("binalar", (string)null);
                });

            modelBuilder.Entity("BinaPilotLayihe.Models.Cizgi", b =>
                {
                    b.Property<int>("OgcFid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ogc_fid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgcFid"));

                    b.Property<string>("Analysed")
                        .HasColumnType("character varying")
                        .HasColumnName("analysed");

                    b.Property<string>("Geotype")
                        .HasColumnType("character varying")
                        .HasColumnName("geotype");

                    b.Property<int?>("Index")
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<string>("Passed")
                        .HasColumnType("character varying")
                        .HasColumnName("passed");

                    b.Property<Geometry>("Wkb_geometry")
                        .HasColumnType("geometry")
                        .HasColumnName("wkb_geometry");

                    b.HasKey("OgcFid")
                        .HasName("cizgi_pkey");

                    b.ToTable("cizgiler", (string)null);
                });

            modelBuilder.Entity("BinaPilotLayihe.Models.Nokta", b =>
                {
                    b.Property<int>("OgcFid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ogc_fid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgcFid"));

                    b.Property<string>("Geotype")
                        .HasColumnType("character varying")
                        .HasColumnName("geotype");

                    b.Property<int?>("Index")
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<Geometry>("Wkb_geometry")
                        .HasColumnType("geometry")
                        .HasColumnName("wkb_geometry");

                    b.HasKey("OgcFid")
                        .HasName("nokta_pkey");

                    b.ToTable("noktalar", (string)null);
                });

            modelBuilder.Entity("BinaPilotLayihe.Models.Poi", b =>
                {
                    b.Property<int>("OgcFid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ogc_fid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgcFid"));

                    b.Property<string>("AddrCity")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:city");

                    b.Property<string>("AddrHousenumber")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:housenumber");

                    b.Property<string>("AddrPostcode")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:postcode");

                    b.Property<string>("AddrStreet")
                        .HasColumnType("character varying")
                        .HasColumnName("addr:street");

                    b.Property<string>("AltName")
                        .HasColumnType("character varying")
                        .HasColumnName("alt_name");

                    b.Property<string>("Amenity")
                        .HasColumnType("character varying")
                        .HasColumnName("amenity");

                    b.Property<string>("Atm")
                        .HasColumnType("character varying")
                        .HasColumnName("atm");

                    b.Property<string>("Backrest")
                        .HasColumnType("character varying")
                        .HasColumnName("backrest");

                    b.Property<string>("Brand")
                        .HasColumnType("character varying")
                        .HasColumnName("brand");

                    b.Property<string>("BrandWikidata")
                        .HasColumnType("character varying")
                        .HasColumnName("brand:wikidata");

                    b.Property<string>("BrandWikipedia")
                        .HasColumnType("character varying")
                        .HasColumnName("brand:wikipedia");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("character varying")
                        .HasColumnName("contact:email");

                    b.Property<string>("ContactFacebook")
                        .HasColumnType("character varying")
                        .HasColumnName("contact:facebook");

                    b.Property<string>("ContactInstagram")
                        .HasColumnType("character varying")
                        .HasColumnName("contact:instagram");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("character varying")
                        .HasColumnName("contact:phone");

                    b.Property<string>("ContactWebsite")
                        .HasColumnType("character varying")
                        .HasColumnName("contact:website");

                    b.Property<string>("Cuisine")
                        .HasColumnType("character varying")
                        .HasColumnName("cuisine");

                    b.Property<string>("Delivery")
                        .HasColumnType("character varying")
                        .HasColumnName("delivery");

                    b.Property<string>("DietHalal")
                        .HasColumnType("character varying")
                        .HasColumnName("diet:halal");

                    b.Property<string>("DietMeat")
                        .HasColumnType("character varying")
                        .HasColumnName("diet:meat");

                    b.Property<string>("DietVegan")
                        .HasColumnType("character varying")
                        .HasColumnName("diet:vegan");

                    b.Property<string>("DietVegetarian")
                        .HasColumnType("character varying")
                        .HasColumnName("diet:vegetarian");

                    b.Property<string>("DriveThrough")
                        .HasColumnType("character varying")
                        .HasColumnName("drive_through");

                    b.Property<string>("Facebook")
                        .HasColumnType("character varying")
                        .HasColumnName("facebook");

                    b.Property<string>("Geotype")
                        .HasColumnType("character varying")
                        .HasColumnName("geotype");

                    b.Property<string>("Image")
                        .HasColumnType("character varying")
                        .HasColumnName("image");

                    b.Property<int?>("Index")
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<string>("InternetAccess")
                        .HasColumnType("character varying")
                        .HasColumnName("internet_access");

                    b.Property<string>("InternetAccessFee")
                        .HasColumnType("character varying")
                        .HasColumnName("internet_access:fee");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("NameAr")
                        .HasColumnType("character varying")
                        .HasColumnName("name:ar");

                    b.Property<string>("NameAz")
                        .HasColumnType("character varying")
                        .HasColumnName("name:az");

                    b.Property<string>("NameEn")
                        .HasColumnType("character varying")
                        .HasColumnName("name:en");

                    b.Property<string>("NameFa")
                        .HasColumnType("character varying")
                        .HasColumnName("name:fa");

                    b.Property<string>("NameRu")
                        .HasColumnType("character varying")
                        .HasColumnName("name:ru");

                    b.Property<string>("NameTr")
                        .HasColumnType("character varying")
                        .HasColumnName("name:tr");

                    b.Property<string>("OfficialName")
                        .HasColumnType("character varying")
                        .HasColumnName("official_name");

                    b.Property<string>("OpeningHours")
                        .HasColumnType("character varying")
                        .HasColumnName("opening_hours");

                    b.Property<string>("OpeningHoursCovid19")
                        .HasColumnType("character varying")
                        .HasColumnName("opening_hours:covid19");

                    b.Property<string>("Operator")
                        .HasColumnType("character varying")
                        .HasColumnName("operator");

                    b.Property<string>("OutdoorSeating")
                        .HasColumnType("character varying")
                        .HasColumnName("outdoor_seating");

                    b.Property<string>("Phone")
                        .HasColumnType("character varying")
                        .HasColumnName("phone");

                    b.Property<string>("RefVatin")
                        .HasColumnType("character varying")
                        .HasColumnName("ref:vatin");

                    b.Property<string>("SourceRefUrl")
                        .HasColumnType("character varying")
                        .HasColumnName("source_ref:url");

                    b.Property<string>("Takeaway")
                        .HasColumnType("character varying")
                        .HasColumnName("takeaway");

                    b.Property<string>("Website")
                        .HasColumnType("character varying")
                        .HasColumnName("website");

                    b.Property<string>("Wikidata")
                        .HasColumnType("character varying")
                        .HasColumnName("wikidata");

                    b.Property<string>("Wikipedia")
                        .HasColumnType("character varying")
                        .HasColumnName("wikipedia");

                    b.Property<Geometry>("Wkb_geometry")
                        .HasColumnType("geometry")
                        .HasColumnName("wkb_geometry");

                    b.HasKey("OgcFid")
                        .HasName("poi_pkey");

                    b.ToTable("poiler", (string)null);
                });

            modelBuilder.Entity("BinaPilotLayihe.Models.Yol", b =>
                {
                    b.Property<int>("OgcFid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ogc_fid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgcFid"));

                    b.Property<string>("Access")
                        .HasColumnType("character varying")
                        .HasColumnName("access");

                    b.Property<string>("AltName")
                        .HasColumnType("character varying")
                        .HasColumnName("alt_name");

                    b.Property<string>("Bicycle")
                        .HasColumnType("character varying")
                        .HasColumnName("bicycle");

                    b.Property<string>("Bridge")
                        .HasColumnType("character varying")
                        .HasColumnName("bridge");

                    b.Property<string>("Covered")
                        .HasColumnType("character varying")
                        .HasColumnName("covered");

                    b.Property<string>("Crossing")
                        .HasColumnType("character varying")
                        .HasColumnName("crossing");

                    b.Property<string>("Foot")
                        .HasColumnType("character varying")
                        .HasColumnName("foot");

                    b.Property<string>("Footway")
                        .HasColumnType("character varying")
                        .HasColumnName("footway");

                    b.Property<string>("Geotype")
                        .HasColumnType("character varying")
                        .HasColumnName("geotype");

                    b.Property<string>("Highway")
                        .HasColumnType("character varying")
                        .HasColumnName("highway");

                    b.Property<string>("Horse")
                        .HasColumnType("character varying")
                        .HasColumnName("horse");

                    b.Property<int?>("Index")
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<string>("IntName")
                        .HasColumnType("character varying")
                        .HasColumnName("int_name");

                    b.Property<string>("IntRef")
                        .HasColumnType("character varying")
                        .HasColumnName("int_ref");

                    b.Property<string>("Junction")
                        .HasColumnType("character varying")
                        .HasColumnName("junction");

                    b.Property<string>("LaneMarkings")
                        .HasColumnType("character varying")
                        .HasColumnName("lane_markings");

                    b.Property<string>("Lanes")
                        .HasColumnType("character varying")
                        .HasColumnName("lanes");

                    b.Property<string>("Layer")
                        .HasColumnType("character varying")
                        .HasColumnName("layer");

                    b.Property<string>("Lit")
                        .HasColumnType("character varying")
                        .HasColumnName("lit");

                    b.Property<string>("Maxspeed")
                        .HasColumnType("character varying")
                        .HasColumnName("maxspeed");

                    b.Property<string>("Maxwidth")
                        .HasColumnType("character varying")
                        .HasColumnName("maxwidth");

                    b.Property<string>("MotorVehicle")
                        .HasColumnType("character varying")
                        .HasColumnName("motor_vehicle");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("NameAz")
                        .HasColumnType("character varying")
                        .HasColumnName("name:az");

                    b.Property<string>("NameAzCyr")
                        .HasColumnType("character varying")
                        .HasColumnName("name:az_cyr");

                    b.Property<string>("NameEn")
                        .HasColumnType("character varying")
                        .HasColumnName("name:en");

                    b.Property<string>("NameRu")
                        .HasColumnType("character varying")
                        .HasColumnName("name:ru");

                    b.Property<string>("OldName")
                        .HasColumnType("character varying")
                        .HasColumnName("old_name");

                    b.Property<string>("OldNameRu")
                        .HasColumnType("character varying")
                        .HasColumnName("old_name:ru");

                    b.Property<string>("Oneway")
                        .HasColumnType("character varying")
                        .HasColumnName("oneway");

                    b.Property<string>("Service")
                        .HasColumnType("character varying")
                        .HasColumnName("service");

                    b.Property<string>("SourceGeometry")
                        .HasColumnType("character varying")
                        .HasColumnName("source:geometry");

                    b.Property<string>("Surface")
                        .HasColumnType("character varying")
                        .HasColumnName("surface");

                    b.Property<string>("Tunnel")
                        .HasColumnType("character varying")
                        .HasColumnName("tunnel");

                    b.Property<Geometry>("Wkb_geometry")
                        .HasColumnType("geometry")
                        .HasColumnName("wkb_geometry");

                    b.HasKey("OgcFid")
                        .HasName("yol_pkey");

                    b.ToTable("yollar", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
