using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Linq;

namespace Acme.SimpleTaskApp.Persons
{
    public class LookupAppService : SimpleTaskAppAppServiceBase, ILookupAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;

        public LookupAppService(IRepository<Person, Guid> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<ComboboxItemDto>> GetPerpleComboboxItems()
        {
            var persons = await _personRepository.GetAllListAsync();

            return new List<ComboboxItemDto>
            (
                persons.Select(o=> new ComboboxItemDto(o.Id.ToString("D"),o.Name)).ToList()
            );

        }
    }
}
