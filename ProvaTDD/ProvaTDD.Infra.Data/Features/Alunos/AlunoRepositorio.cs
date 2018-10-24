using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Infra.Features;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProvaTDD.Infra.Data.Features.Alunos
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        #region querys
        private const string _inserir = @"INSERT INTO TBAluno(Nome, Idade) VALUES (@Nome, @Idade)";
        private const string _pegarPorId = @"SELECT * FROM TBAluno WHERE Id = @Id";
        private const string _pegarTodos = @"SELECT * FROM TBAluno";
        private const string _deletar = @"DELETE FROM TBAluno WHERE Id = @Id";
        private const string _atualizar = @"UPDATE TBAluno SET  Nome = @Nome, Idade = @Idade";
        #endregion

        public Aluno Atualizar(Aluno entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Aluno entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Aluno PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Aluno> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Aluno Salvar(Aluno entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Aluno> Make = reader =>
           new Aluno
           {
               Id = Convert.ToInt64(reader["Id"]),
               Nome = Convert.ToString(reader["Nome"]),
               Idade = Convert.ToInt32(reader["Idade"])
           };

        private object[] Take(Aluno aluno)
        {
            return new object[]
            {
                "@Id", aluno.Id,
                "@Nome", aluno.Nome,
                "@Idade", aluno.Idade
            };
        }
    }
}
