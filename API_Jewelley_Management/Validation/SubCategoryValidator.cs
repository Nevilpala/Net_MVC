using API_Jewelley_Management.Models;
using FluentValidation;

namespace API_Jewelley_Management.Validation
{
    public class SubCategoryValidator : BaseValidator<SubCategoryModel>
    {
        public SubCategoryValidator()
        {
            RuleFor(x => x.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is Required");


            RuleFor(x => x.CategoryID)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Select Category Name")
                .NotNull().WithMessage("Select Category Name");
                

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)

                .NotEmpty().WithMessage("{PropertyName} is Required");

        }
    }
}
