using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Application.Interfaces.Service;

namespace UserProfileService.Application.Features.Candidate.Commands
{
    public class CandidateUpdateCommandHandler : IRequestHandler<CandidateUpdateCommand , Guid>
    {

        private readonly ICandidateRepository _cnadidateRepository;
      
        private readonly ICloudinaryService _cloudinaryService;
        public CandidateUpdateCommandHandler(ICandidateRepository candidateRepository , ICloudinaryService cloudinaryService)
        {  
            _cloudinaryService = cloudinaryService;
            _cnadidateRepository = candidateRepository;
           
        }

        public async Task<Guid> Handle(CandidateUpdateCommand request , CancellationToken cancellationToken)
        {

            var dto =  request.dto;
            var candidate =  await _cnadidateRepository.GetByIdAsync(request.id) ?? throw new ApplicationException("Area Not found"); ;

            var photo = await _cloudinaryService.UploadImageAsync(dto.photo);
            var cv = await _cloudinaryService.UploadDocumentAsync(dto.cv);
            candidate.CvUrl = cv;
            candidate.PhotoUrl = photo;
            candidate.HighestEducation = dto.highestEducation;
            candidate.UpdatedOn = DateTime.UtcNow; 
            await _cnadidateRepository.UpdateAsync();
            return candidate.Id;
   
        }



    }
}
