using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MoviesApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _c;

        public RemoveCategoryCommandHandler(MovieContext c)
        {
            _c = c;
        }

        public async void Handle(RemoveCategoryCommand command)
        {
            var category = await _c.Categories.FindAsync(command.CategoryId);
            _c.Categories.Remove(category);
            await _c.SaveChangesAsync();
        }
    }
}
