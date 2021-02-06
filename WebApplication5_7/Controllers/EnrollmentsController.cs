using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5_7.Controllers
{

    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _dbService;

        public EnrollmentsController(IStudentDbService service)
        {
            _dbService = service;
        }

        [Route("api/enrollments")]
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            _dbService.EnrollStudent(request);
            var response = new EnrollStudentResponse();
            return Created(new Uri("http://localhost:56982/"), response);
        }


        [Route("api/enrollments/promotions")]
        [HttpPost]
        public IActionResult PromoteStudents(Study study)
        {
            var response = _dbService.PromoteStudents(study.Semester, study.Studies);
            if (response != null)
            {
                return Created("Student was promoted", response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
