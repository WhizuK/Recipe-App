using Livro_de_Receita.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livro_de_Receita.repository.Interfaces
{
    public interface IUser
    {
        User Create(User user);
        User Update(User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        void Delete(int id);
        User Login(string username, string password);
    }
}
