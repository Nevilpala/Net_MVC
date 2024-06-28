using API_Jewelley_Management.Models;
using FluentValidation;

namespace API_Jewelley_Management.Validation
{
    public class ProductValidator : BaseValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .Cascade(CascadeMode.StopOnFirstFailure) 
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("{PropertyName} is not be Empty");

            RuleFor(x => x.CategoryID)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Select Category Name")
                .NotNull().WithMessage("Select Category Name")
                .GreaterThan(0).WithMessage("{PropertyName} is must greater than 0");


            RuleFor(x => x.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(x => x.SellPrice)
                .Cascade(CascadeMode.StopOnFirstFailure) 
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("Select Category Name") 
                .GreaterThan(0).WithMessage("{PropertyName} is must greater than 0");

            RuleFor(x => x.Price)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("Select Category Name")
                .GreaterThan(0).WithMessage("{PropertyName} is must greater than 0");

            RuleFor(x => x.Discount)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("Select Category Name")
                .InclusiveBetween(0,100).WithMessage("{PropertyName} is between 0 to 100");

            RuleFor(x => x.Quantity)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .NotNull().WithMessage("Select Category Name")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is must greater than 0");


        }
    }
}
