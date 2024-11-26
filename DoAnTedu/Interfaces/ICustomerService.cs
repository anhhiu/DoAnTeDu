using DoAnTedu.Common;
using DoAnTedu.Dtos.Custermers;
using DoAnTedu.Models;

namespace DoAnTedu.Interfaces
{
    public interface ICustomerService
    {
        Task<ResponseService<dynamic>> CreateCustomer(Customer model);
        Task<ResponseService<dynamic>> GetAllCustomer();
        Task<ResponseService<dynamic>> GetCustomerById(int id);
        Task<ResponseService<dynamic>> DeleteCustomerById(int id);
        Task<ResponseService<dynamic>> UpdateCustomerById(UpdateCustomer model, int id);
        Task<(ResponseService<dynamic>, int skip, int take, int total)> GetAllCustomer(int pageNumber, int pageSize);

        Task<ResponseService<dynamic>> UpdateCustomerMapperAsync(UpdateCustomerMapper model, int id);

        Task<ResponseService<dynamic>> SearchCustomerCardCodeorCartNameAsync(string key);


    }
}
