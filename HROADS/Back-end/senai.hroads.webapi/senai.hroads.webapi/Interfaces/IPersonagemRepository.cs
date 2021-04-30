using senai.hroads.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webapi.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do personagem que será buscado</param>
        /// <returns>Um personagem buscado</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPerso">Objeto novoPerso que será cadastrado</param>
        void Cadastrar(Personagem novoPerso);

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será atualizado</param>
        /// <param name="persoAtualizado">Objeto persoAtualizado com as novas informações</param>
        void Atualizar(int id, Personagem persoAtualizado);

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será deletado</param>
        void Deletar(int id);
    }
}
