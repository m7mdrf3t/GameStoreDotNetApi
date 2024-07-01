using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record UpdateGameDTO(
    int Id , 
    [Required][StringLength(40)]
    string Name , 
    int GenreId, 
    [Range(1,100)]
    decimal Price , 
    DateOnly ReleaseDate
);