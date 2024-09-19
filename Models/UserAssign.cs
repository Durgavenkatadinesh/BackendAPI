namespace BackendAPI.Models
{
    public class UserAssign
    {
        public ICollection<Invoice> AssignedInvoices { get; set; }
    }
}
