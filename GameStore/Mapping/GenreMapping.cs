using GameStore.DTOs;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GenreMapping
{
        public static GenreDTO toDto(this Genre genre){
        Console.WriteLine(" i just return a value");
        return new GenreDTO(
            genre.id,
            genre.name
        );
        
    }
}
