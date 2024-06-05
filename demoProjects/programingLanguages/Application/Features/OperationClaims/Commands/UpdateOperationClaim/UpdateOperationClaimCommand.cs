using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public  class UpdateOperationClaimCommand :IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler: IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _rule;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository repository, IMapper mapper, OperationClaimBusinessRules rule)
            {
                _repository = repository;
                _mapper = mapper;
                _rule = rule;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _repository.GetAsync(b=>b.Id== request.Id);
                if (operationClaim == null) return default;
                operationClaim.Name = request.Name;

                OperationClaim updatedOperationClaim = await _repository.UpdateAsync(operationClaim);
                UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
                return updatedOperationClaimDto;
            }
        }
    }
}
