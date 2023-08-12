using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var validationEntity = new ValidationContext<object>(entity);
            var result = validator.Validate(validationEntity);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
