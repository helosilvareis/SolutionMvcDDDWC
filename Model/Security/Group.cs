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
    [Table("WC_Group")]
    public class Group : BaseModel
    {
        [Key]
        [Display(Name = "LBL_CODE", ResourceType = typeof(Resource))]
        public int GroupId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "MSG_FIELD_NULL")]
        [StringLength(70)]
        [Index(IsUnique = true)]
        [Display(Name = "LBL_NAME", ResourceType = typeof(Resource))]
        public string Name { get; set; }
        [Display(Name = "LBL_ACTIVE", ResourceType = typeof(Resource))]
        public bool Active { get; set; } = true;
        [StringLength(250)]
        [Display(Name = "LBL_OBSERVATION", ResourceType = typeof(Resource))]
        public string Observation { get; set; }
        public IList<User> Users { get; set; }
    }
}
