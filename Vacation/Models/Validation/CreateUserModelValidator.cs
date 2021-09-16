using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Vacation.Entities;

namespace Vacation.Models.Validation
{
    public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserModelValidator(VacationDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(4);
            RuleFor(x => x.ConfirmPassword).Equal(c => c.Password);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                if (dbContext.Users.Any(b => b.Email == value))
                {
                    context.AddFailure("User with that e-mail is already registered");
                }
            });
        }
    }
}
