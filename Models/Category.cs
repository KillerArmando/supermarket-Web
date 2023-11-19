namespace SupermarkerWEB.Models
{
    public class Category
    {
        public int Id { get; set; } // Sera la llave Primaria
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } // Propiedad de Navegacion
    }
}
