using Microsoft.AspNetCore.Mvc;
using Motus_API.Models;
using Motus_DataAccessLayer;

namespace Motus_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotusController : ControllerBase
    {
        
        private readonly ILogger<MotusController> _logger;
        private IMotusRepository _repository;

        public MotusController(
            ILogger<MotusController> logger,
            IMotusRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType<SuccessResultModel<string>>(200)]
        [ProducesResponseType<ErrorResultModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get()
        {
            try
            {
                string result = _repository.GetRandomWord();
                return Ok(new SuccessResultModel<string>() { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResultModel() { ErrorMessage = ex.Message });
            }
        }
        [HttpGet("{size}")]
        [ProducesResponseType<SuccessResultModel<string>>(200)]
        [ProducesResponseType<ErrorResultModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get(int size)
        {
            try
            {
                string result = _repository.GetRandomWord(size);
                return Ok(new SuccessResultModel<string>() { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResultModel() { ErrorMessage = ex.Message });
            }
        }
        [HttpGet("check/{word}")]
        [ProducesResponseType<SuccessResultModel<bool>>(200)]
        [ProducesResponseType<ErrorResultModel>(400)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get(string word)
        {
            try
            {
                bool result = _repository.IsValid(word);
                return Ok(new SuccessResultModel<bool>() { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResultModel() { ErrorMessage = ex.Message });
            }
        }
    }
}
