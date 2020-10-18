using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment_API.Data;
using Microsoft.Extensions.Logging;

namespace Assesment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly Assesment_APIContext _context;

        private readonly ILogger<DepartmentsController> _logger;
        public DepartmentsController(Assesment_APIContext context,ILogger<DepartmentsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartment()
        {
            try
            {
                return await _context.Department.ToListAsync();

                //List<Department> departments = new List<Department>()
                //{
                //new Department{ DepartmentID =1, DepartmentName = "It", MarkAlias="", AddedBy = "Admin1", AddedTime = DateTime.Now.AddDays(-7), ModifiedBy = "Admin1", ModifiedTime = DateTime.Now, DepartmentLead = 1,ParentDepartment = 0},
                //new Department{ DepartmentID =2, DepartmentName = "Marketing", MarkAlias="", AddedBy = "Admin2", AddedTime = DateTime.Now.AddDays(-7), ModifiedBy = "Admin1", ModifiedTime = DateTime.Now, DepartmentLead = 1,ParentDepartment = 0},
                //new Department{ DepartmentID =3, DepartmentName = "Digital", MarkAlias="", AddedBy = "Admin3", AddedTime = DateTime.Now.AddDays(-7), ModifiedBy = "Admin1", ModifiedTime = DateTime.Now, DepartmentLead = 1,ParentDepartment = 0},
                //new Department{ DepartmentID =4, DepartmentName = "Cleaning", MarkAlias="", AddedBy = "Admin4", AddedTime = DateTime.Now.AddDays(-7), ModifiedBy = "Admin1", ModifiedTime = DateTime.Now, DepartmentLead = 1,ParentDepartment = 0},
                //new Department{ DepartmentID =5, DepartmentName = "It-support", MarkAlias="", AddedBy = "Admin5", AddedTime = DateTime.Now.AddDays(-7), ModifiedBy = "Admin1", ModifiedTime = DateTime.Now, DepartmentLead = 1,ParentDepartment = 1},
                //new Department{ DepartmentID =6, DepartmentName = "It2", MarkAlias="", AddedBy = "Admin1", AddedTime = DateTime.Now.AddDays(-7), ModifiedBy = "Admin1", ModifiedTime = DateTime.Now, DepartmentLead = 1,ParentDepartment = 0}
                //};
                //return departments;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        ////GET : api/ParentDepartment
        [HttpGet]
        [Route("ParentDepartment")]
        public IList<ParentDepartment> GetParentDepartment()
        {
            var res = _context.Department.Select(p => new ParentDepartment() { Id = p.Id, DepartmentName = p.DepartmentName });
            return res.ToList();
        }
        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _context.Department.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();

            return department;
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.Id == id);
        }
    }
}
