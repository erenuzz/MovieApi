using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoviesApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _c;

        public UpdateCategoryCommandHandler(MovieContext c)
        {
            _c = c;
        }

        public async void Handle(UpdateCategoryCommand command)
        {
            var value = await _c.Categories.FindAsync(command.CategoryId);
            value.CategoryName = command.CategoryName;
            await _c.SaveChangesAsync();
        }
    }
}
