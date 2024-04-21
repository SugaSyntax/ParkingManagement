
using FluentValidation;
using ParkingManagement.Core.Entities;

namespace ParkingManagement.Core.Validators
{
    public class DateRangeValidator : AbstractValidator<DateRange>
    {
        public DateRangeValidator()
        {
            RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Start date is required")
            .NotNull().WithMessage("Start date is required");

            RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("Start date is required")
            .NotNull().WithMessage("Start date is required")
            .GreaterThan(p => p.StartDate).WithMessage("End date must be greater than start date.");

            RuleFor(x => x)
            .Custom((range, context) =>
            {
                if (range.StartDate.HasValue && range.EndDate.HasValue)
                {
                    var duration = range.EndDate.Value - range.StartDate.Value;
                    if (duration.TotalDays > 3) // Customize your duration constraint here
                    {
                        context.AddFailure("Booking cannot be made for more than 3 days.");
                    }
                }
            });
        }
    }
}