using System.Threading.Tasks;

namespace Cashback.Commom.Publisher
{
    public interface IPublisher
    {
        Task SendQuery<T>(T query) where T : Query;
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
