namespace MediaCenter.Common.Models
{
  public class Movie
  {
    /*
    SELECT
    CASE
      WHEN ty.name IN ('bigint') THEN 'public long' + IIF(c.is_nullable = 1, '?', '') + ' '  + c.name + ' {  get; set; }'
      WHEN ty.name IN ('varchar') THEN 'public string' + IIF(c.is_nullable = 1, '?', '') + ' '  + c.name + ' {  get; set; }'
      WHEN ty.name IN ('decimal') THEN 'public decimal' + IIF(c.is_nullable = 1, '?', '') + ' '  + c.name + ' {  get; set; }'
      WHEN ty.name IN ('datetime') THEN 'public DateTime' + IIF(c.is_nullable = 1, '?', '') + ' '  + c.name + ' {  get; set; }'
      ELSE NULL
    END,
    c.name,
    ty.name
  FROM
    sys.tables t
    INNER JOIN sys.columns c
    ON t.object_id = c.object_id
    INNER JOIN sys.types ty
    ON c.user_type_id = ty.user_type_id
  WHERE
    t.name = 'Movie'
  ORDER BY
    c.column_id
    */

    public long id { get; set; }
    public string unique_movie_title { get; set; }
    public string title { get; set; }
    public long year { get; set; }
    public string? imdb_link { get; set; }
    public decimal rating { get; set; }
    public long votes { get; set; }
    public string? summary { get; set; }
    public DateTime last_update_date { get; set; }
    public long own_this_movie { get; set; }
    public long? mpaa_rating_id { get; set; }

    public List<MovieCast> Cast { get; set; } = new List<MovieCast>();
  }
}