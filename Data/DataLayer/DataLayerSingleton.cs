using Microsoft.EntityFrameworkCore;
using won5lab18reztema.Data.Exceptions;
using won5lab18reztema.Models;

namespace won5lab18reztema.Data.DataLayer
{
    public partial class DataLayerSingleton
    {
        #region Singleton
        private DataLayerSingleton()
        {

        }

        private static DataLayerSingleton _instance;

        
        public static DataLayerSingleton Instance { get
            {
                if (_instance == null)
                {
                    _instance = new DataLayerSingleton();
                }
                return _instance;
            }  
        }
        #endregion
        public Autovehicul ChangeCarName(int id, string newName)
        {
            using var ctx = new CarsDbContext();
            var auto = ctx.Autovehicule.FirstOrDefault(a => a.Id == id);

            if (auto == null)
            {
                throw new InvalidIdException($"Id producator invalid {id}");
            }

            auto.Nume = newName;
            ctx.SaveChanges();

            return auto;
        }
        public List<Autovehicul> GetAllAutovehicule()
        {
            using var ctx = new CarsDbContext();
            return ctx.Autovehicule.Include(a=>a.CarteTehnica).ToList();

        }
        public Autovehicul GetAutovehicul(int id)
        {
            using var ctx = new CarsDbContext();

            return ctx.Autovehicule.FirstOrDefault(a => a.Id == id);
        }
        public Autovehicul AdaugaAutovehicul(string nume, int producatorId)
        {
            using var ctx = new CarsDbContext();

            if (!ctx.Producatori.Any(p => p.Id == producatorId))
            {
                throw new InvalidIdException($"Id producator invalid {producatorId}");
            }

            var autovehicul = new Autovehicul
            {
                Nume = nume,
                ProducatorId = producatorId
            };

            ctx.Add(autovehicul);
            ctx.SaveChanges();

            return autovehicul;
        }

        public Producator AdaugaProducator(string nume, string adresa)
        {
            using var ctx = new CarsDbContext();

            var producator = new Producator
            {
                Nume = nume,
                Adresa = adresa
            };

            ctx.Add(producator);
            ctx.SaveChanges();

            return producator;
        }

        public Cheie AdaugaCheieLaAutovehicul(Guid codAcces, int autovehiculId)
        {
            using var ctx = new CarsDbContext();

            if (!ctx.Autovehicule.Any(a => a.Id == autovehiculId))
            {
                throw new InvalidIdException($"Id autovehicul invalid {autovehiculId}");
            }

            var cheie = new Cheie
            {
                CodAcces = codAcces,
                AutovehiculId = autovehiculId
            };

            ctx.Add(cheie);
            ctx.SaveChanges();

            return cheie;
        }
        public Cheie AdaugaCheieLaAutovehicul2(Guid codAcces, int autovehiculId)
        {
            using var ctx = new CarsDbContext();

            var autovehicul = ctx.Autovehicule.FirstOrDefault(a => a.Id == autovehiculId);
            if (autovehicul == null)
            {
                throw new InvalidIdException($"Id autovehicul invalid {autovehiculId}");
            }
            var cheie = new Cheie { CodAcces = codAcces };

            autovehicul.Chei.Add(cheie);

            ctx.SaveChanges();

            return cheie;
        }
        public void StergeAutovehicul(int id)
        {
            using var ctx = new CarsDbContext();

            var autovehicul = ctx.Autovehicule.Include(a=>a.Chei).FirstOrDefault(a => a.Id == id);
            if (autovehicul == null)
            {
                throw new InvalidIdException($"Id autovehicul invalid {id}");
            }

            autovehicul.Chei.ForEach(c =>
            {
                c.AutovehiculId = null;
            });

            ctx.Remove(autovehicul);
            ctx.SaveChanges();
        }
        public void StergeProducator(int id)
        {
            using var ctx = new CarsDbContext();

            var producator = ctx.Producatori.Include(p=>p.Autovehicule).FirstOrDefault(p => p.Id == id);
            if (producator == null)
            {
                throw new InvalidIdException($"Id producator invalid {id}");
            }

            producator.Autovehicule.ForEach(a => a.ProducatorId = null);

            ctx.Remove(producator);

            ctx.SaveChanges();

        }
    }
}
