namespace Entity.DTOs;

public class MovieDto
{
    public string tagline { get; set; }
    public string Overview { get; set; }
    public DateTime? RelaseDate { get; set; }
    public decimal? vote_avarage { get; set; }
    public string Budget { get; set; }
    public string adult { get; set; }
    public string homepage { get; set; }
    public string original_title { get; set; }
    public int? revenue { get; set; }
    public string status { get; set; }
    public int Views_Count { get; set; }
}