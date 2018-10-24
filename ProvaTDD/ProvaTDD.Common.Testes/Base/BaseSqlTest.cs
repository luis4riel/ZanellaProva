using ProvaTDD.Infra.Features;

namespace ProvaTDD.Common.Testes.Base
{
    public static class BaseSqlTest
    {
        #region aluno
        private const string INSERT_ALUNO = "Insert into TBAluno(Nome, Idade) values ('Luis', 22)";
        private const string DELETE_ALUNO = "DELETE FROM TBAluno DBCC CHECKIDENT('TBAluno', RESEED, 0)";
        #endregion

        #region avaliacao
        private const string INSERT_AVALIACAO = "Insert into TBAvaliacao (Assunto, Data) values ('PROVA', 2018-06-19)";
        private const string DELETE_AVALIACAO = "DELETE FROM TBAvaliacao DBCC CHECKIDENT('TBAvaliacao', RESEED, 0)";
        #endregion

        #region resultado
        private const string INSERT_RESULTADO = "Insert into TBResultado (Nota, IdAluno) values (1.0, 1)";
        private const string DELETE_RESULTADO = "DELETE FROM TBResultado DBCC CHECKIDENT('TBResultado', RESEED, 0)";
        #endregion

        public static void SeedDatabase()
        {

            Db.Update(DELETE_RESULTADO);
            Db.Update(DELETE_ALUNO);
            Db.Update(DELETE_AVALIACAO);

            Db.Update(INSERT_ALUNO);
            Db.Update(INSERT_AVALIACAO);
            Db.Update(INSERT_RESULTADO);
        }
    }
}
