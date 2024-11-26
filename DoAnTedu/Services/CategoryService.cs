using DoAnTedu.Common;
using DoAnTedu.Data;
using DoAnTedu.Dtos.Categories;
using DoAnTedu.Interfaces;
using DoAnTedu.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DoAnTedu.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbcontext _context;

        public CategoryService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ResponseService<dynamic>> CreateCategoryAsync(CreateCategory model)
        {
            var response = new ResponseService<dynamic>();

            if (model == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.BadRequest;
                response.Message = "input error";
                return response;
            }

            var category = new Category
            {
                Name = model.Name,
                CreatedAt = DateTime.Now,
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            response.Data = category;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "create category sucess";
            return response;
        }

        public async Task<ResponseService<dynamic>> UpdateCategoryAsync(CreateCategory model, int id)
        {
            var response = new ResponseService<dynamic>();

            if (model == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.BadRequest;
                response.Message = "input error";
                return response;
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }
            category.Name = model.Name;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            response.Data = category;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "update category sucess";
            return response;
        }

        public async Task<ResponseService<dynamic>> DeleteCategoryAsync(int id)
        {
            var response = new ResponseService<dynamic>();
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }

            response.Data = category;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "delete category sucess";
            return response;
        }

        public async Task<ResponseService<dynamic>> GetCategoryByIdAsync(int id)
        {
            var response = new ResponseService<dynamic>();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }

            response.Data = category;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "get category by id sucess";
            return response;
        }

        public async Task<ResponseService<dynamic>> GetAllCategoryAsync()
        {
            var response = new ResponseService<dynamic>();

            var category = await _context.Categories.ToListAsync();
            if (category.Count == 0)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.BadRequest;
                response.Message = "khong co gi";
                return response;
            }

            response.Data = category;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "get category sucess";
            return response;
        }

    }
}
