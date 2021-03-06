﻿using MidnightLizard.Commons.Domain.Interfaces;
using MidnightLizard.Commons.Domain.Messaging;
using MidnightLizard.Commons.Domain.Results;
using MidnightLizard.Schemes.Domain.PublicSchemeAggregate;
using MidnightLizard.Schemes.Domain.PublicSchemeAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MidnightLizard.Schemes.Processor.Application.DomainEventHandlers.SchemeEventHandlers
{
    public class ColorSchemeValidationFailedEventHandler
        : FailedDomainEventHandler<ColorSchemeValidationFailedEvent, PublicSchemeId>
    {
    }

    public class SchemeAccessDeniedEventHandler
        : FailedDomainEventHandler<SchemeAccessDeniedEvent, PublicSchemeId>
    {
    }

    public class PublisherIdValidationFailedEventHandler
        : FailedDomainEventHandler<PublisherIdValidationFailedEvent, PublicSchemeId>
    {
    }
}
