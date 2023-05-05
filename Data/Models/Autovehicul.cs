// See https://aka.ms/new-console-template for more information

namespace won5lab18reztema.Models
{
    public class Autovehicul
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int? ProducatorId { get; set; }
        public Producator Producator { get; set; }
        public List<Cheie> Chei { get; set; } = new List<Cheie>();
        public CarteTehnica CarteTehnica { get; set; }        
    }
}