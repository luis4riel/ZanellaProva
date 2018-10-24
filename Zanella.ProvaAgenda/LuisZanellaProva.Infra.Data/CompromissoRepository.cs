using LuisZanellaProva.Dominio.Funcionalidades.Compromissos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisZanellaProva.Infra.Data
{
    public class CompromissoRepository : ICompromissoRepository
    {
        #region Querys
        public const string SqlInsereCompromisso =
            @"INSERT INTO TBCompromisso 
                (Assunto, Local, DataInicial, DataFinal, isDiaTodo) 
              VALUES 
                ({0}Assunto, {0}Local, {0}DataInicial, {0}DataFinal, {0}isDiaTodo)";

        public const string SqlSelecionaTodosCompromissos =
            @"SELECT
                Id,
                Assunto,
                Local,
                DataInicial,
                DataFinal,
                isDiaTodo
            FROM
                TBCompromisso";

        public const string SqlEditaCompromisso =
             @"UPDATE TBCompromisso
                SET
                    Assunto = {0}Assunto,
                    Local = {0}Local,
                    DataInicial = {0}DataInicial,
                    DataFinal = {0}DataFinal,
                    isDiaTodo = {0}isDiaTodo
                WHERE Id = {0}Id";

        public const string SqlExcluiCompromisso =
                @"DELETE FROM TBCompromisso
                WHERE Id = {0}Id";
        #endregion

        public Compromisso Adicionar(Compromisso novaEntidade)
        {
            novaEntidade.Id = Db.Insert(SqlInsereCompromisso, GetParametros(novaEntidade));

            return novaEntidade;
        }

        public void Deletar(int id)
        {
            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(SqlExcluiCompromisso, parms);
        }

        public Compromisso Editar(Compromisso entidadeEditada)
        {
            Db.Update(SqlEditaCompromisso, GetParametros(entidadeEditada));

            return entidadeEditada;
        }

        public Compromisso SelecionaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Compromisso> SelecionaTudo()
        {
            return Db.GetAll(SqlSelecionaTodosCompromissos, Converter);
        }

        private Dictionary<string, object> GetParametros(Compromisso compromisso)
        {
            return new Dictionary<string, object>
            {
                { "Id", compromisso.Id },
                { "Assunto", compromisso.Assunto},
                { "Local", compromisso.Local },
                { "DataInicial", compromisso.DataInicial },
                { "DataFinal", compromisso.DataFinal },
                { "isDiaTodo", compromisso.DiaTodo }
            };
        }

        private static Func<IDataReader, Compromisso> Converter = reader =>
          new Compromisso
          {
              Id = Convert.ToInt32(reader["Id"]),
              Assunto = Convert.ToString(reader["Assunto"]),
              Local = Convert.ToString(reader["Local"]),
              DataInicial = Convert.ToDateTime(reader["DataInicial"]),
              DataFinal = Convert.ToDateTime(reader["DataFinal"]),
              DiaTodo = Convert.ToBoolean(reader["isDiaTodo"])
          };
    }
}
