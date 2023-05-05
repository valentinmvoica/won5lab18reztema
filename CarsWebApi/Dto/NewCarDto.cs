namespace CarsWebApi.Dto
{
    /// <summary>
    /// Data describing a new car
    /// </summary>
    public class NewCarDto
    {
        /// <summary>
        /// Name of the car
        /// </summary>
        public string Nume { get; set; }
        /// <summary>
        /// producer id
        /// </summary>
        public int IdProducator { get; set; }
    }
}
