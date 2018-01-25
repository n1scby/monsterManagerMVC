using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Monster
    {
       
        public int Id { get; set; }
 
        public string Name { get; set; }

        [Display(Name="Number of Eyes")]
        public int NumberOfEyes { get; set; }

        public string Color { get; set; }

        [Display(Name="Number of Arms")]
        public int NumberOfArms { get; set; }
    }
}
