using FluentValidation;
using System.Text.Json.Serialization;

namespace Domain.Queries
{
    public class EquationQuery
    {
        public double? Num1 { get; set; }
        public double? Num2 { get; set; }
        [JsonIgnore]
        public bool isDivision { get; set; }
    }

    public class EquationQueryValidator : AbstractValidator<EquationQuery>
    {
        public EquationQueryValidator()
        {
            RuleFor(x => x.Num1).NotNull().WithMessage("Parameter Num1 cannot be null!");
            RuleFor(x => x.Num2).NotNull().WithMessage("Parameter Num2 cannot be null!");
            RuleFor(x => x.Num2).Must(OnNotEmpty).WithMessage("Cannot divide by zero!");
        }
        private bool OnNotEmpty(EquationQuery input, double? num2)
        {
            return !(input.isDivision && num2.Value == 0);
        }
    }
}
