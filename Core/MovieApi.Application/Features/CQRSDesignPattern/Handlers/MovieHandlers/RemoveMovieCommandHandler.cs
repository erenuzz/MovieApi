using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MoviesApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _c;

        public RemoveMovieCommandHandler(MovieContext c)
        {
            _c = c;
        }

        public async void Handle(RemoveMovieCommand command)
        {
            var movie = await _c.Movies.FindAsync(command.MovieId);
            _c.Movies.Remove(movie);
            await _c.SaveChangesAsync();
        }
    }
}
