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
    public class DifficultyService : IDifficultyService
    {
        private readonly IDifficulty _repository;
        public DifficultyService(IDifficulty _repository)
        {
            this._repository = _repository;
        }

        public Difficulty Create(Difficulty difficulty)
        {
            return _repository.Create(difficulty);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Difficulty Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Difficulty> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Difficulty Update(Difficulty difficulty)
        {
            return _repository.Update(difficulty);
        }
    }
}
