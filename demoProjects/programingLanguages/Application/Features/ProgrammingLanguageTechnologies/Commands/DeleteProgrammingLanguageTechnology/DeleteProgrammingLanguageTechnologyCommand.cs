using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public  class DeleteProgrammingLanguageTechnologyCommand :IRequest<DeletedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageTechnologyCommandHandler:IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _repository;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
              ProgrammingLanguageTechnology result = await _repository.GetAsync(c=>c.Id == request.Id);
                //if (result == null)
                //{

                //}

                await _repository.DeleteAsync(result);
                DeletedProgrammingLanguageTechnologyDto deletedDto = _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(result);
                return deletedDto;
            }
          


        }
    }
}
