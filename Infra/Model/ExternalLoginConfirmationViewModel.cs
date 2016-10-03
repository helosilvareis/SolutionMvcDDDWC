using System.ComponentModel.DataAnnotations;

namespace WcWebUi.Infra.Model
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}