using GameStore.Data;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GenreEndpoint
{
    public static RouteGroupBuilder MapGenreEndpoint(this WebApplication app){
        var group = app.MapGroup("genres");

        group.MapGet("/",async (GameStoreContext dbcontext) => {
            await dbcontext.Genres
                    .Select(genre => genre.toDto())
                    .AsNoTracking()
                    .ToListAsync();
        });
        
        return group;
    } 
}
