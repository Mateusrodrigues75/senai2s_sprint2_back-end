using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        void CadastrarJogo(JogoDomain NovoJogo);

        List<JogoDomain> ListarJogos();

        void Deletar(int id);
    }
}
