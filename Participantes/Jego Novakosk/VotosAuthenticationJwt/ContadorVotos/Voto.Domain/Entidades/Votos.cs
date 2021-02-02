


namespace Voto.Domain.Entidades

{
    public class Votos
    {
        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdFilme { get; private set; }

        public Votos(int id, int idUsuario, int idFilme)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdFilme = idFilme;
        }
    }
}
