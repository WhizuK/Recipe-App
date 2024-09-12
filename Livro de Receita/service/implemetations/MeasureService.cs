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
    public class MeasureService : IMeasuresService
    {
        private readonly IMeasure _repository;
        public MeasureService(IMeasure _repository)
        {
            this._repository = _repository;
        }
        public Measures Create(Measures measures)
        {
            return _repository.Create(measures);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Measures Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Measures> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Measures Update(Measures measures)
        {
            return _repository.Update(measures);
        }
    }
}
