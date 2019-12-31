using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace respositorUnitSw.Model
{
    [Table("Person")]
    public class Person : EntityCore
    {
        public int Age { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
