using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class GameDetailsDTO(
    int Id , 
    string Name , 
    int GenreID , 
    decimal Price , 
    DateOnly ReleaseDate
);
