using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MoviesApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _c;

        public UpdateMovieCommandHandler(MovieContext c)
        {
            _c = c;
        }

        public async void Handle(UpdateMovieCommand command)
        {
            var value = await _c.Movies.FindAsync(command.MovieId);
            value.Rating = command.Rating;
            value.Status = command.Status;
            value.Duration = command.Duration;
            value.CoverImageUrl = command.CoverImageUrl;
            value.CreatedYear = command.CreatedYear;
            value.Description = command.Description;
            value.ReleaseDate = command.ReleaseDate;
            value.Title = command.Title;
            await _c.SaveChangesAsync();
        }
    }
}
