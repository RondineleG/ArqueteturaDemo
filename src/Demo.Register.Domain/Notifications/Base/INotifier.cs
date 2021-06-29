using System.Collections.Generic;

namespace Demo.Register.Domain.Notifications
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotification();

        void Handle(Notification notificacao);
    }
}
