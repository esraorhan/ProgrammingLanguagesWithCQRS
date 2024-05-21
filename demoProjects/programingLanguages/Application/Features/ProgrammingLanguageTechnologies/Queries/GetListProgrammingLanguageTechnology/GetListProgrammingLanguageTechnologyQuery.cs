using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQuery :IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _languageTechnologyRepository;

            public GetListProgrammingLanguageTechnologyQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository languageTechnologyRepository)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
               IPaginate<ProgrammingLanguageTechnology> plTechnologies = await _languageTechnologyRepository.GetListAsync(include:
                                                                                    p=>p.Include(c=>c.ProgrammingLanguage),
                                                                                    index: request.PageRequest.Page,
                                                                                    size: request.PageRequest.PageSize);
                ProgrammingLanguageTechnologyListModel mappedModels =_mapper.Map<ProgrammingLanguageTechnologyListModel>(plTechnologies);
                return mappedModels;
            }
        }
    }
}
