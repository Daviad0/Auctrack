using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAuctrack.Models
{
    public class Bidder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int BidderNum { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }


    }
}