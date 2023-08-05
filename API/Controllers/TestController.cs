using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly List<Employee> _employees = new()
        {
            new Employee(){Id = 1001, Name = "Ali"},
            new Employee(){Id = 1002, Name = "Veli"},
            new Employee(){Id = 1003, Name = "Ayşe"},
        };

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("primitive")]
        public int GetNumber()
        {
            return 10;
        }

        [HttpGet("detail")]
        public Employee Get()
        {
            return _employees.First();
        }

        [HttpGet("all")]
        public List<Employee> GetAllA()
        {
            return _employees;
        }

        [HttpGet("all-iactionresult")]
        //[ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public IActionResult GetAllB()
        {
            if (!_employees.Any())
                return NotFound();

            return Ok(_employees);
        }

        [HttpGet("all-actionresult")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetAllC()
        {
            if (!_employees.Any())
                return NotFound();

            return Ok(_employees);
        }

        [HttpGet("all-iactionresultasync")]
        //[ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllD()
        {
            if (!_employees.Any())
                return NotFound();

            return await Task.FromResult(Ok(_employees));
        }

        [HttpGet("all-actionresultasync")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Employee>>> GetAllE()
        {
            if (!_employees.Any())
                return NotFound();

            return await Task.FromResult(Ok(_employees));
        }
    }
}