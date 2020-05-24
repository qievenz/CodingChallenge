namespace Figura.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Figuras")]
    public partial class Figura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(300)]
        public string Area { get; set; }

        [StringLength(300)]
        public string Perimetro { get; set; }

        [StringLength(300)]
        public string Volumen { get; set; }
    }
}
