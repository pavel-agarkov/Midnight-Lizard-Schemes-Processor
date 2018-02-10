﻿using MidnightLizard.Schemes.Domain.Common.Messaging;
using MidnightLizard.Schemes.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidnightLizard.Schemes.Domain.Common.Interfaces
{
    /// <summary>
    /// Dispatches domain events to the events queue
    /// </summary>
    /// <typeparam name="TAggregateId">Type of Aggregate ID to wich this event is related</typeparam>
    public interface IDomainEventsDispatcher<TAggregateId>
        where TAggregateId : DomainEntityId
    {
        Task<DomainResult> DispatchEvent(TransportMessage<DomainEvent<TAggregateId>, TAggregateId> transportEvent);
    }
}
