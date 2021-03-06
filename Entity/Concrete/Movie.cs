using System.ComponentModel;
using System.Numerics;
using Entity.Abstract;

namespace Entity;

public class Movie:IEntity
{
    public long id { get; set; }
    public string? overview { get; set; }
    public DateTime? release_date { get; set; }
    public string? genres { get; set; }
    public decimal? vote_average { get; set; }
    public string? budget { get; set; }
    public string adult { get; set; }
    public string? imdb_id { get; set; }
    public string? belongs_to_collection { get; set; }
    public string? homepage { get; set; }
    public string? original_language { get; set; }
    public string? original_title { get; set; }
    public string? poster_path { get; set; }
    public string? production_companies { get; set; }
    public string? production_countries { get; set; }
    public string? popularity { get; set; }
    public int? revenue { get; set; }
    public decimal? runtime { get; set; }
    public string? spoken_languages { get; set; }
    public string? status { get; set; }
    public string? tagline { get; set; }
    public string? title { get; set; }
    public string? video { get; set; }
    [DefaultValue(0)]
    public int? Views_Count { get; set; }
    public int? vote_count { get; set; }
    
}   