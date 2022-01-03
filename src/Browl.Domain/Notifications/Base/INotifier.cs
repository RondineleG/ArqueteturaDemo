using System.Collections.Generic;

namespace Browl.Domain.Notifications
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotification();

        void Handle(Notification notificacao);
    }
}
