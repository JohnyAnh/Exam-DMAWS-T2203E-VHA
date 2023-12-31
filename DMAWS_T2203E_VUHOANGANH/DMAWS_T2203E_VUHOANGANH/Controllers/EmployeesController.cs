﻿using System.Collections.Generic;
using System.Linq;
using DMAWS_T2203E_VUHOANGANH.Data;
using DMAWS_T2203E_VUHOANGANH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2203E_VUHOANGANH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        // GET: api/Employees/Search/{searchString}/{dobFromDate}/{dobToDate}
        [HttpGet("Search/{searchString}/{dobFromDate}/{dobToDate}")]
        public ActionResult<IEnumerable<Employee>> SearchEmployees(string searchString, DateTime dobFromDate, DateTime dobToDate)
        {
            var employees = _context.Employees.Where(e =>
                e.EmployeeName.Contains(searchString) &&
                e.EmployeeDOB >= dobFromDate &&
                e.EmployeeDOB <= dobToDate).ToList();

            return employees;
        }

        // GET: api/Employees/Details/{id}
        [HttpGet("Details/{id}")]
        public ActionResult<Employee> GetEmployeeDetails(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.ProjectEmployees = _context.ProjectEmployees.Where(pe => pe.EmployeeId == id).ToList();
            return employee;
        }


        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
