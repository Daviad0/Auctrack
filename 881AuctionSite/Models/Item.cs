using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAuctrack.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Current { get; set; }
        public string Winner { get; set; }
        public string Donator { get; set; }
        public TimeSpan TimeFrame { get; set; }

        public virtual ICollection<ItemGroup> ItemGroups { get; set; }
    }
}