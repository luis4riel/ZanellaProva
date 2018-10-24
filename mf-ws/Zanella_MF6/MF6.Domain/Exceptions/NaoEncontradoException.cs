namespace MF6.Domain.Exceptions
{
    public class NaoEncontradoException : BusinessException
    {
        public NaoEncontradoException() : base(ErrorCodes.NotFound, "Registro Não Encontrado") { }
    }
}
