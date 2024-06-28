using API_Jewelley_Management.Models;
using FluentValidation;

namespace API_Jewelley_Management.Validation
{
    public class CategoryValidator : BaseValidator<CategoryModel>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("{PropertyName} is Required");

            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("{PropertyName} is Required");
        }
    }
}
