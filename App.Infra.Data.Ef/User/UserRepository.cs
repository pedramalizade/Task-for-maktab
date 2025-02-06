//using App.Domain.Core.Data.Repository;
//using App.Domain.Core.Entities;
//using App.Infra.Data.SqlServer.Ef.ApplicationDbContext;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Infra.Data.Ef.User
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly AppDbContext _appDbContext;
//        public UserRepository(AppDbContext appDbContext)
//        {
//            _appDbContext = appDbContext;
//        }
//        public async Task<Duty> GetByDutyId(int id, CancellationToken cancellationToken)
//        {
//            return await _appDbContext.Duties.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<List<Duty>> GetListDuty(CancellationToken cancellationToken)
//        {
//            return await _appDbContext.Duties.AsNoTracking().OrderBy(x => x.IsCompleted)
//                .Select(x => new Duty()
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    Description = x.Description,
//                    IsCompleted = x.IsCompleted,
//                    UserId = x.UserId
//                }).ToListAsync();
//        }

//        public async Task<Domain.Core.Entities.User> Login(string username, string password, CancellationToken cancellationToken)
//        {
//            return await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username && x.PasswordHash == password);
//        }
//    }
//}
