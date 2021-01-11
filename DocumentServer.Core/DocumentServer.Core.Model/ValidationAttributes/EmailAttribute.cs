using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DocumentServer.Core.Model.ValidationAttributes
{
    /// <summary>
    /// 验证邮箱的格式是否正确
    /// </summary>
    public class EmailAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            if (!string.IsNullOrEmpty(value + ""))
            {
                ///邮箱
                Regex reg = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
                if (!reg.IsMatch(value + ""))
                {
                    validationResult = new ValidationResult(ErrorMessage);
                }
            }
            return validationResult;
        }
    }
}
