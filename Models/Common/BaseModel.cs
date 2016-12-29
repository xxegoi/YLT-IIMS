using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Common
{
    public abstract partial class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        
        public int? Order { get; set; }
    }
}
