using API_Jewelley_Management.Models;
using FluentValidation;

namespace API_Jewelley_Management.Validation
{
    public class BaseValidator<T>: AbstractValidator<T>
    { 
        private bool BeAValidInteger(string value)
        {
            return int.TryParse(value, out _);
        }

    }
}
