using PermissionManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManagement.Domain.UnitTests.Employees
{
    internal class EmployeeMock
    {
        public static readonly string Name = "Luis";
        public static readonly string LastName = "Chara";
        public static readonly Email Email = Email.Create("prueba@gmail.com").Value;
    }
}
