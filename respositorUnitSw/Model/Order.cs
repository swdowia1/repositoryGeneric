using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace respositorUnitSw.Model
{
    [Table("Order")]
    public class Order : EntityCore
    {
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}