using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class UserService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public UserService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<List<UserGrid>> GetUserGridData()
        {
            var users = await GetAllUser();
            return _mapper.Map<List<User>, List<UserGrid>>(users);
        }

        public UserGrid GetUserGrid(User user)
        {
            return _mapper.Map<User, UserGrid>(user);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> AddUser(UserModify userModify)
        {
            var user = _mapper.Map<UserModify, User>(userModify);

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUser(Guid userId, UserModify userModify)
        {
            var user = await GetUserById(userId);

            if (user != null)
            {
                _mapper.Map(userModify, user);
                _context.User.Update(user);

                await _context.SaveChangesAsync();
            }

            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}