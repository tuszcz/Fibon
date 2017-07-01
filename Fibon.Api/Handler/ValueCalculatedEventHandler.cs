﻿using System;
using System.Threading.Tasks;
using Fibon.Api.Repository;
using Fibon.Messages.Events;

namespace Fibon.Api.Handler
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {
        private readonly IRepository _repository;

        public ValueCalculatedEventHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task HandlerAsync(ValueCalculatedEvent @event)
        {
            _repository.Add(@event.Number, @event.Value);
            return Task.CompletedTask;
        }
    }
}