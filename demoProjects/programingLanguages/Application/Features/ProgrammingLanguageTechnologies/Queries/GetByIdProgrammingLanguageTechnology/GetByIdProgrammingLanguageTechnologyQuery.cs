using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgrammingLanguageTechnologyQueryHandler:IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _technologyRepository;

            public GetByIdProgrammingLanguageTechnologyQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            // private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public async Task<ProgrammingLanguageTechnologyGetByIdDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
               // ProgrammingLanguageTechnology programmingLanguageT = await _technologyRepository.GetAsync(b => b.Id == request.Id);

                ProgrammingLanguageTechnology? programmingLanguageTechnology = await _technologyRepository.GetAsync(x => x.Id == request.Id,
                                                                                 a => a.Include(p => p.ProgrammingLanguage));

               

                //await _programmingLanguageBusinessRules.ProgramingLanguageShouldExitsWhenRequested(request.Id);

                ProgrammingLanguageTechnologyGetByIdDto programmingLanguageTDto = _mapper.Map<ProgrammingLanguageTechnologyGetByIdDto>(programmingLanguageTechnology);
                return programmingLanguageTDto;
            }
           
        }
    }
}
