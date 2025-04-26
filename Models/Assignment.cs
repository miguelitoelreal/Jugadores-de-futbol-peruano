namespace JugadoresFutbolPeruano.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
