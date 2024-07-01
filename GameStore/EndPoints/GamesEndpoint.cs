using GameStore.Data;
using GameStore.DTOs;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GamesEndpoint
{
    const string GetGAmeEndPoint = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
{

    var group = app.MapGroup("games")
            .WithParameterValidation();

    // Get /games
    group.MapGet("/",async (GameStoreContext dbcontext) => 
        await dbcontext.Games 
                .Include(Game => Game.Genre)
                .Select(game => game.toGameSummaryDTO())
                .AsNoTracking().ToListAsync());
    
    // Get /games/id
    group.MapGet("/{id}",async (int id , GameStoreContext dbcontext) => 
    {
        Game? game = await dbcontext.Games.FindAsync(id);
        return game is null ? Results.NotFound() : Results.Ok(game.toGameDetailsDTO());
    })
    .WithName(GetGAmeEndPoint);
    
    // Post /games
    group.MapPost("/",async (CreateGameDTO NewGame , GameStoreContext dbcontext) => {

        Game game = NewGame.ToEntity();
        // if i need to add more data to game GameTDO not included in it's mapper
        // game.Genre = dbcontext.Genres.Find(game.genreID);

        dbcontext.Games.Add(game);
        await dbcontext.SaveChangesAsync();

        return Results.CreatedAtRoute(GetGAmeEndPoint,new {id = game.id} ,game.toGameDetailsDTO());
    });

    //Put games/id
    group.MapPut("/{id}",async (int id ,UpdateGameDTO UpdateGames , GameStoreContext dbcontext) => {

        var ExsistingGame = await dbcontext.Games.FindAsync(id);
        
        if(ExsistingGame is null ){
            return Results.NotFound();
        }

        dbcontext.Entry(ExsistingGame)
                 .CurrentValues
                 .SetValues(UpdateGames.ToEntity(id));
        
        await dbcontext.SaveChangesAsync();

         return Results.NoContent();
    });


    group.MapDelete("/{id}",async (int id , GameStoreContext dbcontext) => {
       
       await dbcontext.Games
            .Where(game => game.id == id)
            .ExecuteDeleteAsync();

        return Results.NoContent;
    });

    return group;

}

}
