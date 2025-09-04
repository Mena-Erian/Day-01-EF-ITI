using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public partial class Employee
    {
        //public override string ToString() =>
        //    $"ID:{BusinessEntityID}, NationalID:{NationalIDNumber}, Login:{LoginID}, Title:{JobTitle}, OrgLevel:{OrganizationLevel?.ToString() ?? "N/A"}, Birth:{BirthDate:yyyy-MM-dd}, Marital:{MaritalStatus}, Gender:{Gender}, Hire:{HireDate:yyyy-MM-dd}, Salaried:{SalariedFlag}, Vacation:{VacationHours}, Sick:{SickLeaveHours}, Status:{(CurrentFlag ? "Active" : "Inactive")}, GUID:{rowguid}, Modified:{ModifiedDate:yyyy-MM-dd HH:mm:ss}";

    }
}
