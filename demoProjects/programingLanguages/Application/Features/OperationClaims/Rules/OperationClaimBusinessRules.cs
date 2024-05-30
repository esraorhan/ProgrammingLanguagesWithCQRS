using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public  class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task NameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(c=>c.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation Claim name exists.");
        }

        public async Task BrandShouldExistWhenRequested(int id)
        {
            OperationClaim claim = await _operationClaimRepository.GetAsync(b => b.Id == id);
            if (claim == null) throw new BusinessException("Requested claimname doesn't  exist.");
        }
    }
}
