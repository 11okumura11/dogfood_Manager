using System;
using System.Collections.Generic;

namespace food_manager.Models.Data
{
    public partial class History
    {
        public int Id { get; set; }
        public int Petid { get; set; }
        public int Foodid { get; set; }
        public int ChangeFood { get; set; }
        public string Memo { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
