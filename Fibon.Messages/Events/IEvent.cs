using System.Threading.Tasks;

namespace Fibon.Messages.Events
{
    public interface IEvent
    {

    }

    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandlerAsync(T @event);
    }

    public class ValueCalculatedEvent
    {
        public int Number { get; set; }
        public int Value { get; set; }

        protected ValueCalculatedEvent()
        {

        }
        public ValueCalculatedEvent(int number, int value)
        {
            Number = number;
            Value = value;
        }
    }
}