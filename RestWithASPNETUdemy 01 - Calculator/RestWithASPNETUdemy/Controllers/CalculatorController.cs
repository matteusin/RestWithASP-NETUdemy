using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        // GET api/values
        [HttpGet("{FirstNumber}/{SecondNumber}")]
        public IActionResult Sum(string FirstNumber, string SecondNumber)
        {
            if (IsNumeric(FirstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(FirstNumber) + ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input values :(");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalvalue;
            if (decimal.TryParse(number, out decimalvalue))
            {
                return decimalvalue;
            }
            return 0;
        }

        private bool IsNumeric(string number)
        {
            double vNumber;
            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out vNumber);
            return isNumber;
        }
    }
}
