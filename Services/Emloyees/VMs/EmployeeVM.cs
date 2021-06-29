using AutoMapper;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Application.Emloyees.VMs
{
    public class EmployeeVM
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
    }

    public class EmployeeVMProfile : Profile
    {
        public EmployeeVMProfile()
        {
            CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}
