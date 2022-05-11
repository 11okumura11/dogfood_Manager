using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace food_manager.Models.Data
{
    public partial class LoginUser
    {
        [Required(ErrorMessage = "ユーザー名を入力して下さい。")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "パスワードを入力して下さい。")]
        public string Password { get; set; } = null!;

    }
    public partial class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ユーザー名を入力して下さい。")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "メールアドレスを入力して下さい。")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "パスワードを入力して下さい。")]
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
