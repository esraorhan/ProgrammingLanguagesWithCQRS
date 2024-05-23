using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public  class UpdateProgrammingLanguageTechnologyCommand :IRequest<UpdatedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _businessRules;

            public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology programmingLanguageTechnology = await  _repository.GetAsync(b => b.Id == request.Id);
                if (programmingLanguageTechnology == null)
                    return default;

                programmingLanguageTechnology.Name = request.Name;
                programmingLanguageTechnology.Description = request.Description;
                //  programmingLanguageTechnology.ProgrammingLanguageId = request.ProgrammingLanguageId;

                ProgrammingLanguageTechnology updatedlanguageTechnology = await _repository.UpdateAsync(programmingLanguageTechnology);
                UpdatedProgrammingLanguageTechnologyDto updatedLanguageTechnologyDto = _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedlanguageTechnology);

                return updatedLanguageTechnologyDto;

            }
        }
    }
}
