namespace LuisZanellaProva.Dominio
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        public abstract void Valida();
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
