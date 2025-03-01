using EFLayer.Class;
using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRoles
{
    public class KategorisValidationRoles : AbstractValidator<Kategories> 
    {
        public KategorisValidationRoles()
        {
            RuleFor(x => x.kategoryName).MinimumLength(5).WithMessage("5 KARAKTERDEN AZ OLAMAZ");
        }
    }
}
