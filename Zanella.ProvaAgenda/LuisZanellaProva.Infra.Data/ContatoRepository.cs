using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace LuisZanellaProva.Infra.Data
{
    public class ContatoRepository : IContatoRepository
    {

        #region Querys
        public const string SqlInsereContato = 
            @"INSERT INTO TBContato 
                (Nome, Email, Departamento, Endereco, Telefone) 
              VALUES 
                ({0}Nome,{0}Email,{0}Departamento, {0}Endereco, {0}Telefone)";

        public const string SqlSelecionaTodosContatos =
            @"SELECT
                Id,
                Nome,
                Email,
                Departamento,
                Endereco,
                Telefone
            FROM
                TBContato";

        public const string SqlEditaContato =
             @"UPDATE TBContato
                SET
                    Nome = {0}Nome,
                    Email = {0}Email,
                    Departamento = {0}Departamento,
                    Endereco = {0}Endereco,
                    Telefone = {0}Telefone
                WHERE Id = {0}Id";

        public const string SqlExcluiContato =
                @"DELETE FROM TBContato
                WHERE Id = {0}Id";
        #endregion

        public Contato Adicionar(Contato novaEntidade)
        {
            novaEntidade.Id = Db.Insert(SqlInsereContato, GetParametros(novaEntidade));

            return novaEntidade;
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlExcluiContato, parms);
        }

        public Contato Editar(Contato entidadeEditada)
        {
            Db.Update(SqlEditaContato, GetParametros(entidadeEditada));

            return entidadeEditada;
        }

        public Contato SelecionaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contato> SelecionaTudo()
        {
            return Db.GetAll(SqlSelecionaTodosContatos, Converter);
        }

        private Dictionary<string, object> GetParametros(Contato contato)
        {
            return new Dictionary<string, object>
            {
                { "Id", contato.Id },
                { "Nome", contato.Nome },
                { "Email", contato.Email },
                { "Departamento", contato.Departamento },
                { "Endereco", contato.Endereco },
                { "Telefone", contato.Telefone }
            };
        }

        private static Func<IDataReader, Contato> Converter = reader =>
          new Contato
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"]),
              Email = Convert.ToString(reader["Email"]),
              Departamento = Convert.ToString(reader["Departamento"]),
              Endereco = Convert.ToString(reader["Endereco"]),
              Telefone = Convert.ToString(reader["Telefone"])
          };
    }
}
