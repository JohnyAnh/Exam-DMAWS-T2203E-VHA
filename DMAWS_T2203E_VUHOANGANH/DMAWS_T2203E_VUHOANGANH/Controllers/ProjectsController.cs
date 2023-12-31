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
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Projects/Search/{searchString}
        [HttpGet("Search/{searchString}")]
        public ActionResult<IEnumerable<Project>> SearchProjects(string searchString)
        {
            var projects = _context.Projects.Where(p => p.ProjectName.Contains(searchString)).ToList();
            return projects;
        }

        // GET: api/Projects/Details/{id}
        [HttpGet("Details/{id}")]
        public ActionResult<Project> GetProjectDetails(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            project.ProjectEmployees = _context.ProjectEmployees.Where(pe => pe.ProjectId == id).ToList();
            return project;
        }

        // GET: api/Projects
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return _context.Projects.ToList();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST: api/Projects
        [HttpPost]
        public IActionResult PostProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public IActionResult PutProject(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
