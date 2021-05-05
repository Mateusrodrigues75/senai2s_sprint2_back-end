using senai.spmedicalgroup.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Método que cadastra uma nova Clinica
        /// </summary>
        /// <param name="NovaClinica">id da clinica que será cadastrada</param>
        public void Cadastrar(Clinica NovaClinica);

        /// <summary>
        /// Lista todas as clinicas do SPMedical Group 
        /// </summary>
        /// <returns>Lista com as clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma Clinica pelo id 
        /// </summary>
        /// <param name="id">id da clinica que será buscada</param>
        /// <returns>Clinica Buscada</returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma clinica pelo Id
        /// </summary>
        /// <param name="id">Id da clinica que será atualizada</param>
        /// <param name="ClinicaAtt">Objeto ClinicaAtt com as informações atualizadas</param>
        void Atualizar(int id, Clinica ClinicaAtt);

        /// <summary>
        /// Deleta o cadastro de uma clinica existente
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        void Deletar(int id);

    }
}
