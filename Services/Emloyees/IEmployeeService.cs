using EmployeeMgt.Application.Common.VMs;
using EmployeeMgt.Application.Emloyees.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Application.Emloyees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeVM>> GetAll(EmployeeListSearchQuery query);
        Task<EmployeeVM> GetById(long id);
        Task<EmployeeVM> Insert(EmployeeVM model);
        Task<EmployeeVM> Update(EmployeeVM model);
        Task<ResultModel> Delete(long id);
    }
}
