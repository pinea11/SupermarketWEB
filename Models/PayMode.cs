namespace SupermarketWEB.Models
{
    public class PayMode
    {
        public int Id { get; set; } // Llave primaria
        public string Name { get; set; } // Nombre del modo de pago
        public string? Description { get; set; } // Descripción del modo de pago
    }
}
