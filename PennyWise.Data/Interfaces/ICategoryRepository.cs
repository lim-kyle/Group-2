using PennyWise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PennyWise.Data.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        IQueryable<Category> GetCategories();
        Category? GetCategory(int categoryId); 
        void UpdateCategory(Category category);
    }
}
