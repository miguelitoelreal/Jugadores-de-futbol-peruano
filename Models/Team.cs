namespace JugadoresFutbolPeruano.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        public Team()
        {
            Name = string.Empty;
            Assignments = new List<Assignment>();
        }
    }
}
