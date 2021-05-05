using senai.spmedicalgroup.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Método que cadastra uma novo Medico
        /// </summary>
        /// <param name="NovoMedico">id do Médico que será Cadastrado</param>
        public void Cadastrar(Medico NovoMedico);

        /// <summary>
        /// Lista todos os Medicos do SPMedical Group 
        /// </summary>
        /// <returns>Lista com os Medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um Medico pelo id 
        /// </summary>
        /// <param name="id">id do Medico que será buscado</param>
        /// <returns>Medico Buscado</returns>
        Medico BuscarPorId(int id);

        /// <summary>
        /// Atualiza um Medico pelo Id
        /// </summary>
        /// <param name="id">Id do Medico que será atualizado</param>
        /// <param name="MedicoAtt">Objeto MedicoAtt com as informações atualizadas</param>
        void Atualizar(int id, Medico MedicoAtt);

        /// <summary>
        /// Deleta um cadastro de um Medico existente
        /// </summary>
        /// <param name="id">Id do Medico que será deletado</param>
        void Deletar(int id);
    }
}
