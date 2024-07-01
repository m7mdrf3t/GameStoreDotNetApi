using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class GameSummaryDTO(
    int Id , 
    string Name , 
    string GenreID , 
    decimal Price , 
    DateOnly ReleaseDate
);
