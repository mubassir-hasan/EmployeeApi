using AutoMapper;
using Data;
using EmployeeMgt.Application.Common.VMs;
using EmployeeMgt.Application.Emloyees.VMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Application.Emloyees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeDbContext dbContext, ILogger<EmployeeService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmployeeVM> Insert(EmployeeVM model)
        {
            var entiy = new Employee { FirstName = model.FirstName, LastName = model.LastName, MiddleName = model.MiddleName };
            await _dbContext.AddAsync(entiy);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeVM>(entiy); 
        }

        

        public async Task<IEnumerable<EmployeeVM>> GetAll(EmployeeListSearchQuery query)
        {
            var list = new List<EmployeeVM>();
            var currentPage = query.CurrentPage >= 0 ? query.CurrentPage : 1;
            var dbList =await _dbContext.Employee
                .OrderByDescending(x=>x.Id)
                .Skip((currentPage - 1) * query.PageSize)
                .Take(query.PageSize)
                .AsNoTracking()
                .ToListAsync();
            foreach (var item in dbList)
            {
                list.Add(_mapper.Map<EmployeeVM>(item));
            }
            return list;
        }

        public async Task<EmployeeVM> GetById(long id)
        {
            var entity = await _dbContext.Employee.FindAsync(id);
            return _mapper.Map<EmployeeVM>(entity);
        }

        public async Task<EmployeeVM> Update(EmployeeVM model)
        {
            var entity = await _dbContext.Employee.FindAsync(model.Id);
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName; ;
            entity.MiddleName = model.MiddleName;
            await _dbContext.SaveChangesAsync();
            return model;
        }
        public async Task<ResultModel> Delete(long id)
        {
            var entity = await _dbContext.Employee.FindAsync(id);
            _dbContext.Employee.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return new ResultModel(true, "Employee Deleted");
        }
    }
}
