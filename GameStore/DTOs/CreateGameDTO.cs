using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record CreateGameDTO
(
    [Required][StringLength(40)]string Name , 
    int GenreID , 
    [Range(1,100)]decimal Price , 
    DateOnly ReleaseDate
);