using Model.General;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Security
{
    [Table("WC_User")]
    public class User : BaseModel
    {
        [Key]
        [Display(Name = "LBL_CODE", ResourceType = typeof(Resource))]
        public int UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MSG_FIELD_NULL")]
        [StringLength(70)]
        [Display(Name = "LBL_NAME", ResourceType = typeof(Resource))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MSG_FIELD_NULL")]
        [StringLength(70)]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MSG_INVALID_EMAIL")]
        [Display(Name = "LBL_EMAIL", ResourceType = typeof(Resource))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MSG_FIELD_NULL")]
        [StringLength(8)]
        [Index(IsUnique = true)]
        [Display(Name = "LBL_LOGIN", ResourceType = typeof(Resource))]
        public string Login { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MSG_FIELD_NULL")]
        [StringLength(1024)]
        [Display(Name = "LBL_PASSWORD", ResourceType = typeof(Resource))]
        public string Password { get; set; }
        [Display(Name = "LBL_GROUP", ResourceType = typeof(Resource))]
        public Role Groups { get; set; } = Role.User;
        [StringLength(250)]
        [Display(Name = "LBL_OBSERVATION", ResourceType = typeof(Resource))]
        public string Observation { get; set; }
        [Display(Name = "LBL_ACTIVE", ResourceType = typeof(Resource))]
        public bool Active { get; set; } = true;

        [NotMapped]
        public string DisplayName { get; set; }
    }

    public enum Role
    {
        [Display(Name = "LBL_ADMINISTRATOR", ResourceType = typeof(Resource))]
        Administrator = 1,
        [Display(Name = "LBL_USERWITHPRIVILEGES", ResourceType = typeof(Resource))]
        UserWithPrivileges = 2,
        [Display(Name = "LBL_USER", ResourceType = typeof(Resource))]
        User = 3
    }
}
