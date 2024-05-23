using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic
{
    public class GetListProgrammingLanguageTechnologyByDynamicQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; } // bunu gönderdiğimiz zaman dinamik sorgu yazmak istediğimizi söylemiş olyruz
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageTechnologyByDynamicQueryHandler :IRequestHandler<GetListProgrammingLanguageTechnologyByDynamicQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _repository;

            public GetListProgrammingLanguageTechnologyByDynamicQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> plTechnologies = await _repository.GetListAsync(include:
                                                                                    p => p.Include(c => c.ProgrammingLanguage),
                                                                                    index: request.PageRequest.Page,
                                                                                    size: request.PageRequest.PageSize);

                ProgrammingLanguageTechnologyListModel mappedModels = _mapper.Map<ProgrammingLanguageTechnologyListModel>(plTechnologies);
                return mappedModels;
            }
        }
    }
}
