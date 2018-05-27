using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Entities
{
    public class Order
    {
        public string Ordno { get; set; }
        public Folder Folderno { get; set; }
    }
}
