using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mytable",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    overview = table.Column<string>(type: "text", nullable: true),
                    release_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    genres = table.Column<string>(type: "text", nullable: true),
                    vote_average = table.Column<decimal>(type: "numeric", nullable: true),
                    budget = table.Column<string>(type: "text", nullable: true),
                    adult = table.Column<string>(type: "text", nullable: false),
                    imdb_id = table.Column<string>(type: "text", nullable: true),
                    belongs_to_collection = table.Column<string>(type: "text", nullable: true),
                    homepage = table.Column<string>(type: "text", nullable: true),
                    original_language = table.Column<string>(type: "text", nullable: true),
                    original_title = table.Column<string>(type: "text", nullable: true),
                    poster_path = table.Column<string>(type: "text", nullable: true),
                    production_companies = table.Column<string>(type: "text", nullable: true),
                    production_countries = table.Column<string>(type: "text", nullable: true),
                    popularity = table.Column<string>(type: "text", nullable: true),
                    revenue = table.Column<int>(type: "integer", nullable: true),
                    runtime = table.Column<decimal>(type: "numeric", nullable: true),
                    spoken_languages = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    tagline = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    video = table.Column<string>(type: "text", nullable: true),
                    Views_Count = table.Column<int>(type: "integer", nullable: true),
                    vote_count = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mytable", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mytable");
        }
    }
}
