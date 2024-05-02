using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public  class GetListProgrammingLanguageQuery :IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgramingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _pLPepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageHandler(IProgrammingLanguageRepository pLPepository, IMapper mapper)
            {
                _pLPepository = pLPepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> pl = await _pLPepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                ProgramingLanguageListModel mappedProgramingLanguageListModel = _mapper.Map<ProgramingLanguageListModel>(pl);
                return mappedProgramingLanguageListModel;
            }
        }
    }
}
