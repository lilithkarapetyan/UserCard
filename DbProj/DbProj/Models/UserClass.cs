using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbProj.Models
{
    public class UserCard
    {
        [Key, Column(Order = 1)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
        public Card Card { get; set; }
    }
}
