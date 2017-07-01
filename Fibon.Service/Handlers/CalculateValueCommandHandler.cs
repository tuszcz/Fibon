using System.Threading.Tasks;
using Fibon.Messages.Commands;
using Fibon.Messages.Events;
using RawRabbit;

namespace Fibon.Service.Handlers
{
    public class CalculateValueCommandHandler : ICommandHandler<CalculateValueCommand>
    {
        private readonly IBusClient _busClient;

        public CalculateValueCommandHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CalculateValueCommand command)
        {
            int result = Fib(command.Number);

            await _busClient.PublishAsync(new ValueCalculatedEvent(command.Number, result));
        }

        private static int Fib(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return Fib(n - 2) + Fib(n - 1);
            }
        }

    }
}