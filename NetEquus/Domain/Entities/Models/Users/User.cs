using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Domain.Entities.Models.Users
{
    public class User
    {
        [Key]
        public Guid User_Id { get; set; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                NormalizedUsername = value?.ToLower();
            }
        }

        public string NormalizedUsername { get; set; }

        public string User_Email { get; set; }

        public string Password_Hash { get; set; }

        public bool IsAdmin { get; set; } = true;
        [AllowNull]
        public string? RefreshToken { get; set; }
        [AllowNull]
        public DateTime? RefreshTokenExpiryTime { get; set; }
        [AllowNull]
        public DateTime? LastLogin {  get; set; }


        public User(string username, string user_Email, string password_Hash, bool isAdmin)
        {
            User_Id = Guid.NewGuid();
            Username = username;
            User_Email = user_Email;
            Password_Hash = password_Hash;
            IsAdmin = isAdmin;
        }

        public User()
        { }
    }
}
