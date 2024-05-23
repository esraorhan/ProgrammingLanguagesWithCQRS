using Application.Features.ProgrammingLanguages.Rules;
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

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public  class CreateProgrammingLanguageTechnologyCommand : IRequest<CreatedProgrammingLanguageTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _businessRules;

            public CreateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
                //_businessRules = businessRules;
            }

            //mapper ne yapıo ?
            //Dto id ve name var Brand ise id name ve sonradan gelen x gibi bir alan olabişlir ama 
            //sonrasında o x alanını döndürmek istenmeyebilir.



            public async Task<CreatedProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
               await _businessRules.ProgrammingLanguageTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguageTechnology mappedResult = _mapper.Map<ProgrammingLanguageTechnology>(request);
                ProgrammingLanguageTechnology createdResult =await _repository.AddAsync(mappedResult);
                CreatedProgrammingLanguageTechnologyDto CreatedDto = _mapper.Map<CreatedProgrammingLanguageTechnologyDto>(createdResult);

                return CreatedDto;
            }
        }
    }
}
