namespace GameStore.Entities;

public record class Game
{
    public int id { get; set;}
    public required string Name{get; set;}

    public int genreID {set; get;}

    public Genre? Genre { get; set; }

    public decimal Price { get; set; }
    public DateOnly ReleaseDate {get; set;}

}
