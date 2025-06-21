using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly RecipePlatformDbContext _dbContext;
        public CategoryService(RecipePlatformDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<AddCategoryDropDownModel>> GetCategoriesDropDownAsync()
        {
            IEnumerable<AddCategoryDropDownModel> addCategoryDropDowns = await this._dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new AddCategoryDropDownModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                 .ToArrayAsync();

            return addCategoryDropDowns;
        }
    

    }
}