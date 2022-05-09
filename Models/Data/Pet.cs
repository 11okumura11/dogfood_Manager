using System;
using System.Collections.Generic;

namespace food_manager.Models.Data
{
    public partial class Pet
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Kindsid { get; set; }
        public string PetsName { get; set; } = null!;
        public DateTime? PetsAge { get; set; }
        public double PetsWeight { get; set; }
        public bool PetsGender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
