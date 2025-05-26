using InterviewReady.Messaging.Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Infrastructure.Consumers
{
    public class CandidateCreatedConsumer : IConsumer<ICandidateCreatedEvent>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ILogger<CandidateCreatedConsumer> _logger;

        public CandidateCreatedConsumer(ICandidateRepository candidateRepository, ILogger<CandidateCreatedConsumer> logger)
        {
            _candidateRepository = candidateRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ICandidateCreatedEvent> context)
        {
            var message = context.Message;

            _logger.LogInformation("Received CandidateCreatedEvent: {@Message}", message);

            var candidate = new Candidate
            {
                Id = message.Id,
                FullName = message.FullName,
            };

            await _candidateRepository.AddAsync(candidate);

            _logger.LogInformation("Candidate with ID {Id} created successfully.", message.Id);
        }
    }

}
