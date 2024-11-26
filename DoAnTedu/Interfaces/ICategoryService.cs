using DoAnTedu.Common;
using DoAnTedu.Dtos.Categories;

namespace DoAnTedu.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseService<dynamic>> CreateCategoryAsync(CreateCategory model);
        Task<ResponseService<dynamic>> UpdateCategoryAsync(CreateCategory model, int id);
        Task<ResponseService<dynamic>> DeleteCategoryAsync(int id);
        Task<ResponseService<dynamic>> GetCategoryByIdAsync(int id);
        Task<ResponseService<dynamic>> GetAllCategoryAsync();
    }
}
