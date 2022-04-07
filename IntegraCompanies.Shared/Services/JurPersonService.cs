using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class JurPersonService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public JurPersonService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<JurPerson>> GetAllJurPerson()
        {
            return await _context.JurPerson
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<JurPersonGrid>> GetJurPersonGridData()
        {
            var jurPersons = await GetAllJurPerson();
            return _mapper.Map<List<JurPerson>, List<JurPersonGrid>>(jurPersons);
        }

        public async Task<List<JurPersonCombo>> GetJurPersonComboData()
        {
            var jurPersons = await GetAllJurPerson();
            return _mapper.Map<List<JurPerson>, List<JurPersonCombo>>(jurPersons);
        }

        public JurPersonGrid GetJurPersonGrid(JurPerson jurPerson)
        {
            return _mapper.Map<JurPerson, JurPersonGrid>(jurPerson);
        }

        public async Task<JurPerson> GetJurPersonById(Guid id)
        {
            return await _context.JurPerson.FindAsync(id);
        }

        public async Task<JurPerson> GetSameJurPerson(string name)
        {
            return await _context.JurPerson.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<JurPerson> AddJurPerson(JurPersonModify jurPersonModify)
        {
            var jurPerson = _mapper.Map<JurPersonModify, JurPerson>(jurPersonModify);

            await _context.JurPerson.AddAsync(jurPerson);
            await _context.SaveChangesAsync();

            return jurPerson;
        }

        public async Task<JurPerson> UpdateJurPerson(Guid jurPersonId, JurPersonModify jurPersonModify)
        {
            var jurPerson = await GetJurPersonById(jurPersonId);

            if (jurPerson != null)
            {
                _mapper.Map(jurPersonModify, jurPerson);
                _context.JurPerson.Update(jurPerson);

                await _context.SaveChangesAsync();
            }

            return jurPerson;
        }

        public async Task DeleteJurPerson(JurPerson jurPerson)
        {
            _context.JurPerson.Remove(jurPerson);
            await _context.SaveChangesAsync();
        }
    }
}