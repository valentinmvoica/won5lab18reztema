using CarsWebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using won5lab18reztema.Data.DataLayer;
using won5lab18reztema.Models;

namespace CarsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasiniController : ControllerBase
    {
        [HttpGet("{id}")]
        public Autovehicul GetById(int id) =>
           DataLayerSingleton.Instance.GetAutovehicul(id);
        /// <summary>
        /// Toate automobilele
        /// </summary>
        /// <param name="maxCapacitateCilindrica">optional; capacitate cilindrica maxima</param>
        /// <returns></returns>
        [HttpGet()]
        public List<Autovehicul> GetAll([FromQuery]int? maxCapacitateCilindrica)
        {            
            if (maxCapacitateCilindrica == null)
            {
                return DataLayerSingleton.Instance.GetAllAutovehicule();
            }

            return DataLayerSingleton.Instance.GetAllAutovehicule()
                .Where(a=>a.CarteTehnica!=null&&a.CarteTehnica.CapacitateCilindrica<= maxCapacitateCilindrica)
                .ToList();
        }

        [HttpPost("")]
        public Autovehicul AddAutovehicul([FromBody] NewCarDto dateAutovehicul) {
            return DataLayerSingleton.Instance.AdaugaAutovehicul(dateAutovehicul.Nume, dateAutovehicul.IdProducator);
        }
        [HttpPut("{id}")]
        public Autovehicul updateAutovehicul(int id, [FromBody] string newName)
        {
            return DataLayerSingleton.Instance.ChangeCarName(id, newName);
        }

        /// <summary>
        /// This is meant for car deletion
        /// </summary>
        /// <param name="id">id of the car to be deleted</param>
        /// <param name="deleteKeys">if true the keys will be deleted as well/</param>
        [HttpDelete("{id}")]
        public void DeleteAutovehicul(int id, [FromQuery] bool deleteKeys )
        {
            DataLayerSingleton.Instance.StergeAutovehicul(id);
        }
    }
}
