using System;
using System.Collections.Generic;

namespace respositorUnitSw.View
{
    public class VM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Zam { get; set; }
    }
    public class VMM
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string OrderName { get; set; }
        public string PersonName { get; set; }

    }
}
