using senai.spmedicalgroup.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Método que cadastra uma nova Especialidade
        /// </summary>
      /// <param name="NovaEspecialidade">id da especialidade que será cadastrada</param>
        public void Cadastrar(Especialidade NovaEspecialidade);

        /// <summary>
        /// Lista todas as Especialidades do SPMedical Group 
        /// </summary>
        /// <returns>Lista com as Especialidades</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Busca uma especialidade pelo id 
        /// </summary>
        /// <param name="id">id da especialidade que será buscada</param>
        /// <returns>Especialidade Buscada</returns>
        Especialidade BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma Especialidade pelo Id
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizada</param>
        /// <param name="EspecialidadeAtt">Objeto EspecialidadeAtt com as informações atualizadas</param>
        void Atualizar(int id, Especialidade EspecialidadeAtt);

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        void Deletar(int id);
    }
}
