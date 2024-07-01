using GameStore.DTOs;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO game){
        return new Game(){
            Name = game.Name,
            genreID = game.GenreID,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

        public static Game ToEntity(this UpdateGameDTO game , int id){
        return new Game(){
            id = id,
            Name = game.Name,
            genreID = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

        public static Genre ToEntity(this GenreDTO game){
        return new Genre(){
            id = game.id,
            name = game.name
        };
        }

    public static GameSummaryDTO toGameSummaryDTO(this Game game)
    {
        return new (
            game.id , 
            game.Name,
            game.Genre!.name,
            game.Price,
            game.ReleaseDate
        );
    }
    public static GameDetailsDTO toGameDetailsDTO(this Game game)
    {
        return new (
            game.id , 
            game.Name,
            game.genreID,
            game.Price,
            game.ReleaseDate
        );
    }

}
