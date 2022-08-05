using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFood_WebApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string username { get; set; }

    }
}
