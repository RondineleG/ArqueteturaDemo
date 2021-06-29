using System.Collections.Generic;
using System.Linq;

namespace Proton.Register.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notification;

        public Notifier()
        {
            _notification = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            _notification.Add(notificacao);
        }

        public List<Notification> GetNotification()
        {
            return _notification;
        }

        public bool HasNotification()
        {
            return _notification.Any();
        }
    }
}
