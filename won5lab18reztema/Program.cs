// See https://aka.ms/new-console-template for more information
using won5lab18reztema.Data.DataLayer;
using won5lab18reztema.Models;

//DataLayerSingleton.Instance.Seed();
//Autovehicul jetta = DataLayerSingleton.Instance.AdaugaAutovehicul("Jetta", 1);
//var dacia = DataLayerSingleton.Instance.AdaugaProducator("Dacia", "Mioveni");

DataLayerSingleton.Instance.AdaugaCheieLaAutovehicul(Guid.NewGuid(), 1);
DataLayerSingleton.Instance.StergeAutovehicul(1);

Console.WriteLine("Hello");