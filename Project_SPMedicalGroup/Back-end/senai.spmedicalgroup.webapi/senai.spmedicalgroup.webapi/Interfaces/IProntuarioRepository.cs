using senai.spmedicalgroup.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Interfaces
{
    interface IProntuarioRepository
    {
        /// <summary>
        /// Método que cadastra uma novo Prontuario
        /// </summary>
        /// <param name="NovoProntuario">id do prontuario que será cadastrado </param>
        public void Cadastrar(Prontuario NovoProntuario);

        /// <summary>
        /// Lista todos os Prontuario do SPMedical Group 
        /// </summary>
        /// <returns>Lista com os Prontuarios</returns>
        List<Prontuario> Listar();

        /// <summary>
        /// Busca um Prontuario pelo id 
        /// </summary>
        /// <param name="id">id do Prontuario que será buscado</param>
        /// <returns>Prontuario Buscado</returns>
        Prontuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um Prontuario pelo Id
        /// </summary>
        /// <param name="id">Id do Prontuario que será atualizado</param>
        /// <param name="ProntuarioAtt">Objeto ProntuarioAtt com as informações atualizadas</param>
        void Atualizar(int id, Prontuario ProntuarioAtt);

        /// <summary>
        /// Deleta um Prontuario existente
        /// </summary>
        /// <param name="id">Id do Prontuario que será deletado</param>
        void Deletar(int id);
    }
}
