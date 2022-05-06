using System;
using System.Collections.Generic;

namespace food_Manager.Models.Data
{
    public partial class Food
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Petid { get; set; }
        public string FoodName { get; set; } = null!;
        public int FirstGram { get; set; }
        public int EndGram { get; set; }
        public int RemainGram { get; set; }
        public int SpecifyRemainGram { get; set; }
        public TimeSpan FeedTime { get; set; }
        public TimeSpan AlertTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
