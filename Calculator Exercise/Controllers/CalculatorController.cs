using Domain.DTOs;
using Domain.Interfaces;
using Domain.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Calculator_Exercise.Controllers
{
    public class CalculatorController : BaseController
    {
        private readonly ICalculationService _calculator;
        public CalculatorController(ICalculationService _calculator)
        {
            this._calculator = _calculator;
        }

        [ProducesResponseType(typeof(IEnumerable<CalculatorDto>), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Sum(EquationQuery query)
        {
            return Ok(await _calculator.Sum(query));
        }

        [ProducesResponseType(typeof(IEnumerable<CalculatorDto>), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Subtract(EquationQuery query)
        {
            return Ok(await _calculator.Subtract(query));
        }

        [ProducesResponseType(typeof(IEnumerable<CalculatorDto>), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Divide(EquationQuery query)
        {
            query.isDivision = true;
            return Ok(await _calculator.Divide(query));
        }

        [ProducesResponseType(typeof(IEnumerable<CalculatorDto>), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Multiply(EquationQuery query)
        {
            return Ok(await _calculator.Multiply(query));
        }
    }
}
