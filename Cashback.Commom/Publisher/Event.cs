using MediatR;

namespace Cashback.Commom.Publisher
{
    public abstract class Event : Message, INotification
    {

    }
}
