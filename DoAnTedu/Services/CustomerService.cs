using AutoMapper;
using DoAnTedu.Common;
using DoAnTedu.Data;
using DoAnTedu.Dtos.Custermers;
using DoAnTedu.Interfaces;
using DoAnTedu.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DoAnTedu.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbcontext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // ma cartcode tu dong
        public async Task<string> GenerateCodeAsync()
        {
            // Lấy mã cuối cùng từ database
            var lastCustomer = await _context.Customers
                .OrderByDescending(p => p.ID)
                .FirstOrDefaultAsync();

            string lastCode = lastCustomer?.CardCode ?? "KH00001";

            if (string.IsNullOrEmpty(lastCode) || lastCode.Length < 7 || !lastCode.StartsWith("KH"))
            {
                lastCode = "KH00001"; // Gán giá trị mặc định nếu không hợp lệ
            }
            // Tách số ra khỏi mã
            string numberPart = lastCode.Substring(2);


            if (!int.TryParse(numberPart, out int currentNumber))
            {
                throw new FormatException("Phần số của mã khách hàng không hợp lệ.");
            }

            int newNumber = int.Parse(numberPart) + 1;
            // ghep ma moi
            return $"KH{newNumber:D5}";
        }

        public async Task<ResponseService<dynamic>> CreateCustomer(Customer model)
        {
            var response = new ResponseService<dynamic>();

            if (model == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.BadRequest;
                response.Message = "input error";
                return response;
            }
            // add
            try
            {
                model.CardCode = await GenerateCodeAsync();

                var existingCustomer = await _context.Customers.AnyAsync(p => p.CardCode == model.CardCode);

                if (existingCustomer)
                {
                    response.Data = new { };
                    response.Statuscode = (int)HttpStatusCode.BadRequest;
                    response.Message = "ma card code da ton tai";
                    return response;
                }

                await _context.Customers.AddAsync(model);
                await _context.SaveChangesAsync();


                response.Data = model;
                response.Statuscode = (int)HttpStatusCode.Created;
                response.Message = "them thanh cong";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Error: " + ex.Message;
                return response;
            }
            return response;

        }

        public async Task<ResponseService<dynamic>> GetAllCustomer()
        {
            var response = new ResponseService<dynamic>();

            var customer = await _context.Customers.AsNoTracking()
                                                   .Include(p => p.CrD1s)
                                                   .Include(p => p.CrD2s)
                                                   .Include(p => p.CrD3s)
                                                   .Include(p => p.CrD4s)
                                                   .Include(p => p.CrD5s)
                                                   .ToListAsync();

            if (customer.Count == 0)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }

            response.Data = customer;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "ok";
            return response;

        }

        public async Task<ResponseService<dynamic>> GetCustomerById(int id)
        {
            var response = new ResponseService<dynamic>();

            var customer = await _context.Customers.AsNoTracking()
                                                   .Include(p => p.CrD1s)
                                                   .Include(p => p.CrD2s)
                                                   .Include(p => p.CrD3s)
                                                   .Include(p => p.CrD4s)
                                                   .Include(p => p.CrD5s)
                                                   .FirstOrDefaultAsync(p => p.ID == id);

            if (customer == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }

            response.Data = customer;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "ok";
            return response;

        }

        public async Task<ResponseService<dynamic>> DeleteCustomerById(int id)
        {
            var response = new ResponseService<dynamic>();

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "da xoa khach hang co id:" + id;
            return response;

        }

        public async Task<ResponseService<dynamic>> UpdateCustomerById(UpdateCustomer model, int id)
        {
            var response = new ResponseService<dynamic>();


            if (model == null || id <= 0)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.BadRequest;
                response.Message = "input error";
                return response;
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "not found";
                return response;
            }

            //// Ví dụ: Không cho phép chỉnh sửa khách hàng nếu trạng thái đã là "Deactivated"
            //if (customer.Status == "Deactivated")
            //{
            //    response.Data = null;
            //    response.Statuscode = (int)HttpStatusCode.Conflict; // HTTP 409 Conflict
            //    response.Message = "Không thể cập nhật khách hàng đã bị vô hiệu hóa.";
            //    return response;
            //}

            _mapper.Map(model, customer);

            try
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                response.Data = customer;
                response.Statuscode = (int)HttpStatusCode.OK;
                response.Message = "cap nhat thanh cong";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.InternalServerError;
                response.Message = "loi khi luu du lieu:" + ex.Message;
            }

            return response;

        }

        public async Task<(ResponseService<dynamic>, int skip, int take, int total)> GetAllCustomer(int pageNumber, int pageSize)
        {
            var response = new ResponseService<dynamic>();
            int skip = 0, take = 0, total = 0;

            // Query cơ sở dữ liệu, bao gồm các quan hệ cần thiết
            var query = _context.Customers.AsNoTracking()
                                          .Include(p => p.CrD1s)
                                          .Include(p => p.CrD2s)
                                          .Include(p => p.CrD3s)
                                          .Include(p => p.CrD4s)
                                          .Include(p => p.CrD5s)
                                          .AsQueryable();


            if (pageNumber > 0 && pageSize > 0)
            {
                query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            var customer = await query.ToListAsync();
            skip = pageNumber;
            take = pageSize;
            total = customer.Count();

            if (customer.Count == 0)
            {
                response.Data = new { };
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "No customers found.";
                return (response, skip, take, total);
            }
            response.Data = customer;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "OK";

            // Trả về toàn bộ dữ liệu, skip và take = 0
            return (response, skip, take, total);

        }

        public async Task<ResponseService<dynamic>> UpdateCustomerMapperAsync(UpdateCustomerMapper model, int id)
        {
            var response = new ResponseService<dynamic>();

            if (model == null)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.BadRequest;
                response.Message = "dau vao khong hop le";
                return response;
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "khong tim thay";
                return response;
            }

            try
            {
                _mapper.Map(model, customer);
                model.Status = "Update";
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                response.Data = customer;
                response.Statuscode = (int)HttpStatusCode.OK;
                response.Message = "cap nhat thanh cong";

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.InternalServerError;
                response.Message = "error" + ex.Message;
            }

            return response;

        }

        public async Task<ResponseService<dynamic>> SearchCustomerCardCodeorCartNameAsync(string key)
        {
            var response = new ResponseService<dynamic>();

            var customer = await _context.Customers.AsNoTracking().Include(p => p.CrD1s)
                                                   .Include(p=> p.CrD2s)
                                                   .Include(p => p.CrD3s)
                                                   .Include(p => p.CrD4s)
                                                   .Include(p => p.CrD5s)
                                                   .Where(p => p.CardCode!.ToLower().Contains(key.ToLower())
                                                   || p.CardName!.ToLower().Contains(key.ToLower()))
                                                   .ToListAsync();

            if (customer == null)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.NotFound;
                response.Message = "khong tim thay";
                return response;
            }

            try
            {
                response.Data = customer;
                response.Statuscode = (int)HttpStatusCode.OK;
                response.Message = "tim thay key:" +key.ToLower();

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Statuscode = (int)HttpStatusCode.InternalServerError;
                response.Message = "error" + ex.Message;
            }

            return response;

        }
    }
}
