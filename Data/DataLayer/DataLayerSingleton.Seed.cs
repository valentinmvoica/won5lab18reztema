using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using won5lab18reztema.Models;

namespace won5lab18reztema.Data.DataLayer
{
    public partial class DataLayerSingleton
	{
		public void Seed()
		{
			using var carsDbContext = new CarsDbContext();

			var vw = new Producator { Nume = "VW", Adresa = "Volfenstein" };
			var polo = new Autovehicul
			{
				Nume = "Polo",
				Producator = vw,
				CarteTehnica = new CarteTehnica
				{
					AnFabricatie = 1989,
					CapacitateCilindrica = 1395,
					SeriaSasiu = Guid.NewGuid().ToString()
				}
			};

			var faiton = new Autovehicul
			{
				Nume = "Phaeton",
				Producator = vw,
				CarteTehnica = new CarteTehnica
				{
					AnFabricatie = 2010,
					CapacitateCilindrica = 3496,
					SeriaSasiu = Guid.NewGuid().ToString()
				}
			};

			var fox = new Autovehicul
			{
				Nume = "Fox",
				Producator = vw,
				CarteTehnica = new CarteTehnica
				{
					AnFabricatie = 2000,
					CapacitateCilindrica = 1346,
					SeriaSasiu = Guid.NewGuid().ToString()
				}
			};

			carsDbContext.Add(fox);
			carsDbContext.Add(faiton);
			carsDbContext.Add(polo);

			carsDbContext.SaveChanges();
		}
	}
}
