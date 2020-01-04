using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardProj.DB.Models
{
    class Card
    {
        [Key]
        public int CardId { get; private set; }
        public string ShopName { get; set; }
        public double Percent { get; set; }
    }
}