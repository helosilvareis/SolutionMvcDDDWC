using System.ComponentModel.DataAnnotations;

namespace WcWebUi.Infra.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}