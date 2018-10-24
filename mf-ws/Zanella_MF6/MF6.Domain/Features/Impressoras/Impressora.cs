namespace MF6.Domain.Features.Impressoras
{
    public class Impressora
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Ip { get; set; }
        public bool EmUso { get; set; }
        public int NivelTonerColorido { get; set; }
        public int NivelTonerPreto { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Marca))
                throw new CampoEmBrancoException();
            if (string.IsNullOrEmpty(Ip))
                throw new CampoEmBrancoException();
            if (NivelTonerPreto < 0 || NivelTonerPreto > 100)
                throw new NivelInvalidoException();
            if (NivelTonerColorido < 0 || NivelTonerColorido > 100)
                throw new NivelInvalidoException();
        }
    }
}
