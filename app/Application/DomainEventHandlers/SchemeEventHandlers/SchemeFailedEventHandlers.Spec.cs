﻿using FluentAssertions;
using FluentValidation.Results;
using MediatR;
using MidnightLizard.Schemes.Domain.Common.Interfaces;
using MidnightLizard.Schemes.Domain.Common.Results;
using MidnightLizard.Schemes.Domain.PublicSchemeAggregate;
using MidnightLizard.Schemes.Domain.PublicSchemeAggregate.Events;
using MidnightLizard.Schemes.Testing;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;

using ITransEvent = MidnightLizard.Schemes.Domain.Common.Messaging.ITransportMessage<MidnightLizard.Schemes.Domain.Common.Messaging.BaseMessage>;
using TransEvent = MidnightLizard.Schemes.Domain.Common.Messaging.TransportMessage<MidnightLizard.Schemes.Domain.PublicSchemeAggregate.Events.ColorSchemeValidationFailedEvent, MidnightLizard.Schemes.Domain.PublicSchemeAggregate.PublicSchemeId>;

namespace MidnightLizard.Schemes.Processor.Application.DomainEventHandlers.SchemeEventHandlers
{
    public class ColorSchemeValidationFailedEventHandlerSpec : ColorSchemeValidationFailedEventHandler
    {
        private static int handle_CallCount;
        private IMediator mediator;
        private readonly ITransEvent testTransEvent = new TransEvent(new ColorSchemeValidationFailedEvent(null, new ValidationResult()), Guid.NewGuid(), DateTime.UtcNow);

        public ColorSchemeValidationFailedEventHandlerSpec()
        {
            this.mediator = StartupStub.Resolve<IMediator>();
        }

        public override async Task<DomainResult> Handle(TransEvent request, CancellationToken cancellationToken)
        {
            ColorSchemeValidationFailedEventHandlerSpec.handle_CallCount++;
            return DomainResult.Ok;
        }

        [It(nameof(MediatR))]
        public async Task Should_handle_Event()
        {
            ColorSchemeValidationFailedEventHandlerSpec.handle_CallCount = 0;

            var result = await this.mediator.Send(this.testTransEvent);

            ColorSchemeValidationFailedEventHandlerSpec.handle_CallCount.Should().Be(1);
        }
    }
}