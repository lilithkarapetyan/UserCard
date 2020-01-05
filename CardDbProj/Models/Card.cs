using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDbProj.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; private set; }
        public string ShopName { get; set; }
        public double Percent { get; set; }
    }
}
