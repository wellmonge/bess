
using Domain.Repos.Interface;
using System.Data;

namespace Domain.Repos
{    
    public class UserRepository : Repository, IUserRepository
    {

        private IDbTransaction _transaction;

        public UserRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        
    }
}