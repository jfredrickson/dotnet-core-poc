using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSandbox.Models
{
    public class Widget
    {
        public Widget() { }

        public int Id { get; set; }
        [MaxLength(45)]
        public string Name { get; set; }
    }
}
