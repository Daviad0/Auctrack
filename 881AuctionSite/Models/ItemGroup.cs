using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAuctrack.Models
{
    public class ItemGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainDonator { get; set; }
        public string ForAllOfThose { get; set; }

        public virtual Item Items { get; set; }
    }
}