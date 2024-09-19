using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Invoice
    {
        [Key]
        [Required]
        public int InvoiceId { get; set; }
        public string PMC { get; set; }
        public string SiteName { get; set; }
        public string VendorName { get; set; }
        public decimal PriorBalance { get; set; }
    }
}
