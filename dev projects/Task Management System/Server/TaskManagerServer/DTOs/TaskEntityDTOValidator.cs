using FluentValidation;
using TaskManagerServer.DTOs;
using TaskManagerServer.Entities;

namespace TaskManagerServer.Validators
{
    public class TaskEntityDTOValidator : AbstractValidator<TaskEntityDTO>
    {
        public TaskEntityDTOValidator()
        {
            RuleFor(x => x.TaskId).NotNull();

            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(x => x.DueDate)
                .Must(date => date > DateTime.Now)
                .WithMessage("DueDate must be in the future.");

            RuleFor(x => x.TaskStatus)
                .IsInEnum()
                .WithMessage("Invalid status value.");
        }
    }
}
