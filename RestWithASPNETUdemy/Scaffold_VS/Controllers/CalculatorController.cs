using Microsoft.AspNetCore.Mvc;

namespace Scaffold_VS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("Seja bem vindo");
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {   
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            
            return BadRequest("Invalid Input");
        }

        private decimal ConverToDecimal(string strNumber)
        {
            decimal decimalvalue;

            if (decimal.TryParse(strNumber, out decimalvalue))
            {
                return decimalvalue;
            }

            return 0;
        }

        bool isNumeric(string strNumber)
        {
            //throw new NotImplementedException();
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;

        }

    }
}
