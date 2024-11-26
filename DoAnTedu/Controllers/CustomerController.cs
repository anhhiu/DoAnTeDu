using DoAnTedu.Common;
using DoAnTedu.Dtos.Custermers;
using DoAnTedu.Interfaces;
using DoAnTedu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAnTedu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController( ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var response = new ResponseService<dynamic>();

            response = await _service.GetAllCustomer();

            return StatusCode(response.Statuscode, response);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = new ResponseService<dynamic>();

            response = await _service.GetCustomerById(id);

            return StatusCode(response.Statuscode, response);

        }

        [HttpGet("Seach")]
        public async Task<IActionResult> GetCustomerCartCodeorName([FromQuery] string key)
        {
            var response = new ResponseService<dynamic>();

            response = await _service.SearchCustomerCardCodeorCartNameAsync(key);

            return StatusCode(response.Statuscode, response);

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer model)
        {
            var response = new ResponseService<dynamic>();

            response = await _service.CreateCustomer(model);

            return StatusCode(response.Statuscode, response);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomer model, int id)
        {
            var response = new ResponseService<dynamic>();

            response = await _service.UpdateCustomerById(model, id);

            return StatusCode(response.Statuscode, response);
        }

        [HttpPut("updateCustomerMapper/{id:int}")]
        public async Task<IActionResult> UpdateCustomerMapper(UpdateCustomerMapper model, int id)
        {
            var response = new ResponseService<dynamic>();

            response = await _service.UpdateCustomerMapperAsync(model, id);

            return StatusCode(response.Statuscode, response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = new ResponseService<dynamic>();
            response = await _service.DeleteCustomerById(id);
            return StatusCode(response.Statuscode, response);
        }

        [HttpGet("page")]

        public async Task<IActionResult> GetCustomerPage(int pageNumber, int pageSize)
        {
            
            var (response, skip, take, total) = await _service.GetAllCustomer(pageNumber, pageSize);

            var result = new
            {
                Data = response,
                Skip = skip,
                Take = take,
                Total = total
            };
            return StatusCode(response.Statuscode, result);
        }



    }
}
