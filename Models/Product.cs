using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarkerWEB.Models
{
    public class Product
    {
        //[Key] -> Anotacion si la propiedad no se llama id, ejemplo ProductId
        public int Id { get; set; } //Sera la llave Primaria
        public string Name { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? CategoryId { get; set; } //Sera la llave primaria
        public Category? Category { get; set; } // Propiedad de Navegación
    }
}
