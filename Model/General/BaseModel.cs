using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General
{
    public class BaseModel
    {
        [ScaffoldColumn(false)]
        public DateTime CreteDate { get; set; } = DateTime.Now;
        [ScaffoldColumn(false)]
        public DateTime ModifieldDate { get; set; } = DateTime.Now;
    }
}
