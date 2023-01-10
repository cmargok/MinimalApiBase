using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Base.Domain.Entities
{
    [Table("WeatherForecast", Schema = "Weather")]
    public class WeatherForecast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
