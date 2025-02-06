//using App.Domain.Core.Data.Repository;
//using App.Domain.Core.Entities;
//using App.Domain.Core.Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Domain.Services.User
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;
//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }
//        public async Task<Core.Entities.Duty> GetByDutyId(int id, CancellationToken cancellationToken)
//        {
//            return await _userRepository.GetByDutyId(id, cancellationToken);
//        }

//        public async Task<List<Core.Entities.Duty>> GetListDuty(CancellationToken cancellationToken)
//        {
//           return await _userRepository.GetListDuty(cancellationToken);
//        }

//        public async Task<List<Role>> GetRoles(CancellationToken cancellationToken)
//        {
//            return await _userRepository.GetRoles(cancellationToken);
//        }

//        public async Task<Core.Entities.User> Login(string username, string password, CancellationToken cancellationToken)
//        {
//            return await _userRepository.Login(username, password, cancellationToken);  
//        }
//    }
//}
