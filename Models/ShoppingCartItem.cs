using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CinemaTickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie Movie { get; set; }
        public int Amount { get; set; }

        //tb sa vedem cum facem sa se elibereze cosul de cumparaturi dupa ce s-a facut comanda
        public string ShoppingCartId { get; set; }
    }
}