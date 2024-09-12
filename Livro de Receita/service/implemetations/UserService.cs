using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Livro_de_Receita.service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.service.implemetations
{
    public class UserService : IUserService
    {
        private readonly IUser _repository;
        public UserService(IUser _repository)
        {
            this._repository = _repository;
        }
        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public User Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

        public User Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<User> RetrieveAll()
        {
            return _repository .RetrieveAll();
        }

        public User Update(User user)
        {
            return _repository.Update(user); 
        }
    }
}
