using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Model
{
    public class PaymentMethodModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser { get; set; }

    }
}
