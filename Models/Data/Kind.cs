using System;
using System.Collections.Generic;

namespace food_manager.Models.Data
{
    public partial class Kind
    {
        public int Id { get; set; }
        public string KindsData { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
