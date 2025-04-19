using System.ComponentModel.DataAnnotations;

namespace Business.Attributes;

public class DateAfterAttribute : ValidationAttribute
{
    private readonly string _otherPropertyName;
    public DateAfterAttribute(string otherPropertyName)
    {
        _otherPropertyName = otherPropertyName;
        ErrorMessage = "{0} måste vara senare än " + otherPropertyName + ".";
    }

    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        var otherProperty = context.ObjectType.GetProperty(_otherPropertyName);
        if (otherProperty == null)
            return new ValidationResult($"Okänd egenskap {_otherPropertyName}");

        var otherDate = (DateTime)otherProperty.GetValue(context.ObjectInstance)!;
        var thisDate = (DateTime?)value;

        if (thisDate == null || thisDate > otherDate)
            return ValidationResult.Success!;

        return new ValidationResult(FormatErrorMessage(context.DisplayName));
    }
}
