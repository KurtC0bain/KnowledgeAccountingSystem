using System.ComponentModel.DataAnnotations;


namespace SystemDAL.Attributes
{
    public class CustomValidation
    {
        public sealed class CheckCapitalized : ValidationAttribute
        {
            protected override ValidationResult IsValid(object str, ValidationContext validationContext)
            {
                if (char.IsUpper(str.ToString()[0]))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("VALIDATION");
                }
            }

        }

    }
}
