using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentServer.Core.Model.ValidationAttributes
{
    /// <summary>
    /// 验证手机格式是否正确
    /// </summary>
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            if (!string.IsNullOrEmpty(value + ""))
            {
                Regex reg = new Regex(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$");
                if (!reg.IsMatch(value + ""))
                {
                    validationResult = new ValidationResult(ErrorMessage);
                }
            }
            return validationResult;
        }
    }
}
