// See https://aka.ms/new-console-template for more information
using won5lab18reztema.Models;
namespace won5lab18reztema.Models
{
    public class Producator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public List<Autovehicul> Autovehicule { get; set; }
    }
}