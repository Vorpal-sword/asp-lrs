using System;
using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime date = (DateTime)value;
        return date > DateTime.Now;
    }
}

public class NotOnWeekendAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime date = (DateTime)value;
        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
    }
}
public class NotOnSpecificDayAttribute : ValidationAttribute
{
    private readonly DayOfWeek _dayOfWeek;

    public NotOnSpecificDayAttribute(DayOfWeek dayOfWeek)
    {
        _dayOfWeek = dayOfWeek;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var consultationDate = (DateTime)value;
        var productProperty = validationContext.ObjectType.GetProperty("Product");
        if (productProperty == null)
        {
            return new ValidationResult("Помилка валідації.");
        }

        var productValue = (string)productProperty.GetValue(validationContext.ObjectInstance);
        if (productValue == "Основи" && consultationDate.DayOfWeek == _dayOfWeek)
        {
            return new ValidationResult($"Консультація щодо продукту 'Основи' не може проводитися у {_dayOfWeek}.");
        }

        return ValidationResult.Success;
    }
}
