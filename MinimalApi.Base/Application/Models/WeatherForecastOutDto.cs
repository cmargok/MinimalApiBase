using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Base.Application.Models
{
    public class WeatherForecastOutDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        [Required]
        public int TemperatureF { get; set; }

        [Required]
        public string Summary { get; set; }

    }
}
