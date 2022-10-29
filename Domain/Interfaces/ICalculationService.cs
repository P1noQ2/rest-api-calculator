using Domain.DTOs;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICalculationService
    {
        public Task<CalculatorDto> Sum(EquationQuery query);
        public Task<CalculatorDto> Subtract(EquationQuery query);
        public Task<CalculatorDto> Multiply(EquationQuery query);
        public Task<CalculatorDto> Divide(EquationQuery query);
    }
}
