using System.ComponentModel.DataAnnotations;

namespace GameStore.Entities;

public record class Genre
{
    public int id {get; set;}

    public required string name {get; set;}
}
