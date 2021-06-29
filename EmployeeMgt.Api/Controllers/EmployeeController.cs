using EmployeeMgt.Application.Common.VMs;
using EmployeeMgt.Application.Emloyees;
using EmployeeMgt.Application.Emloyees.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeVM>> GetAll(EmployeeListSearchQuery query)
        {
            return await _empService.GetAll(query);
            
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeVM> Get(long id)
        {
            return await _empService.GetById(id);

        }

        [HttpPost]
        public async Task<EmployeeVM> Insert(EmployeeVM employee)
        {
            return await _empService.Insert(employee); 
            
        }

        [HttpPut]
        public async Task<EmployeeVM> Update(EmployeeVM employee)
        {
            return await _empService.Update(employee);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResultModel> Delete(long id)
        {
            return await _empService.Delete(id);

        }
    }
}
