using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Dominio.Features.Resultados;
using ProvaTDD.Infra.Features;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProvaTDD.Infra.Data.Features.Resultados
{
    public class ResultadoRepositorio : IResultadoRepositorio
    {
        #region querys
        private const string _inserir = @"INSERT INTO TBResultado (Nota, IdAluno) VALUES (@Nota, @IdAluno)";
        private const string _pegarPorId = @"SELECT * FROM TBResultado WHERE Id = @Id";
        private const string _pegarTodos = @"SELECT * FROM TBResultado";
        private const string _deletar = @"DELETE FROM TBResultado WHERE Id = @Id";
        private const string _atualizar = @"UPDATE TBResultado SET  Nota = @Nota";
        #endregion

        public Resultado Atualizar(Resultado entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Resultado entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Resultado PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Resultado> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Resultado Salvar(Resultado entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Resultado> Make = reader =>
          new Resultado
          {
              Id = Convert.ToInt64(reader["Id"]),
              Nota = Convert.ToDouble(reader["Nota"]),
              Aluno = new Aluno
              {
                  Id = Convert.ToInt32(reader["IdAluno"])
              }
          };

        private object[] Take(Resultado resultado)
        {
            return new object[]
            {
                "@Id", resultado.Id,
                "@Nota", resultado.Nota,
                "@IdAluno", resultado.Aluno.Id
            };
        }
    }
}
