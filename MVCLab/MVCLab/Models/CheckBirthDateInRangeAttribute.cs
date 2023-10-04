using System.ComponentModel.DataAnnotations;

namespace MVCLab.Models
{
    public class CheckBirthDateInRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Chưa nhập ngày sinh");
            }
            var tuoi = DateTime.Now.Year - ((DateTime)value).Year;
            if(tuoi < 18)
            {
                return new ValidationResult("Chưa đủ 18 tuổi");
            }
            if (tuoi > 60)
            {
                return new ValidationResult("Hết tuổi đi học");
            }
            return ValidationResult.Success;
        }
    }
}