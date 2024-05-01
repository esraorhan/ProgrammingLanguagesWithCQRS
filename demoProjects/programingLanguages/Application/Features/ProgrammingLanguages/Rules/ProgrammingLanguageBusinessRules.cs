using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public  class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _repository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository repository)
        {
            _repository = repository;
        }

        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _repository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }
    }
}
