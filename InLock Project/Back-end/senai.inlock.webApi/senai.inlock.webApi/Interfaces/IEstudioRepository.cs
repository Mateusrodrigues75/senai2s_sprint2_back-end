using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        void CadastrarEstudio(EstudioDomain NovoEstudio);

        List<EstudioDomain> ListarEstudios();

        void DeletarEstudio(int id);
    }
}
