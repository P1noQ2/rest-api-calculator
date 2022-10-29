using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Queries;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services
{
    public class Calculator : ICalculationService
    {
        private IValidator<EquationQuery> _validator;
        public Calculator(IValidator<EquationQuery> _validator)
        {
            this._validator = _validator;
        }
        private CalculatorDto calculatorDto = new();
        public async Task<CalculatorDto> Divide(EquationQuery query)
        {
            ValidationResult result = await _validator.ValidateAsync(query);
            if (result.IsValid)
                return new CalculatorDto { Value = query.Num1 / query.Num2, Message = "Succeeded" };
            else
                return new CalculatorDto { Message = String.Join('\n', result.Errors) };
        }

        public async Task<CalculatorDto> Multiply(EquationQuery query)
        {
            ValidationResult result = await _validator.ValidateAsync(query);
            if (result.IsValid)
                return new CalculatorDto { Value = query.Num1 * query.Num2, Message = "Succeeded" };
            else
                return new CalculatorDto { Message = String.Join('\n', result.Errors) };
        }

        public async Task<CalculatorDto> Subtract(EquationQuery query)
        {
            ValidationResult result = await _validator.ValidateAsync(query);
            if (result.IsValid)
                return new CalculatorDto { Value = query.Num1 - query.Num2, Message = "Succeeded" };
            else
                return new CalculatorDto { Message = String.Join('\n', result.Errors) };
        }

        public async Task<CalculatorDto> Sum(EquationQuery query)
        {
            ValidationResult result = await _validator.ValidateAsync(query);
            if (result.IsValid)
                return new CalculatorDto { Value = query.Num1 + query.Num2, Message = "Succeeded" };
            else
                return new CalculatorDto { Message = String.Join('\n', result.Errors) };
        }
    }
}
