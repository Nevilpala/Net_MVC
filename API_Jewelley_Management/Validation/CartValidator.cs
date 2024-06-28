using API_Jewelley_Management.Areas.Website.Models;
using FluentValidation;

namespace API_Jewelley_Management.Validation
{
    public class CartValidator : BaseValidator<CartModel>
    {
        public CartValidator()
        {
            RuleFor(x => x.ProductID)
                .Cascade(CascadeMode.StopOnFirstFailure) 
                .NotEqual(0).WithMessage("{PropertyName} is Required"); 

            RuleFor(x => x.UserID)
                .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEqual(0).WithMessage("{PropertyName} is Required");

            RuleFor(x => x.Quantity)
                .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEqual(0).WithMessage("{PropertyName} is Required")
               .LessThanOrEqualTo(10).WithMessage("{PropertyName} must be Less Than or Equal 10");
 
        }
 
    }
}
