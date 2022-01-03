using System.Collections.Generic;

namespace Proton.Register.Domain.Core.Notifications
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotification();

        void Handle(Notification notificacao);
    }
}
