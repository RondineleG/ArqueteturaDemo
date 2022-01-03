using FluentValidation;
using FluentValidation.Results;

namespace Browl.Domain.Notifications
{
    public abstract class BaseNotification
    {
        private readonly INotifier _notifier;

        public BaseNotification(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
