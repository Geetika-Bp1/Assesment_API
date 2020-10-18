using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_API.Data
{
    public class Department
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string MarkAlias { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int DepartmentLead { get; set; }
        public int ParentDepartment { get; set; }
    }
}
