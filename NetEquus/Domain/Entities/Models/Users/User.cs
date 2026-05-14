using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Domain.Entities.Models.Users
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

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
        [AllowNull]
        public string? Email { get; set; }
        [AllowNull]
        public string? Password_Hash { get; set; }

        public virtual HorseArtist HorseArtist { get; set; }

        public bool IsAdmin { get; set; } = true;
        [AllowNull]
        public string? RefreshToken { get; set; }
        [AllowNull]
        public DateTime? RefreshTokenExpiryTime { get; set; }
        [AllowNull]
        public DateTime? LastLogin {  get; set; }

        public bool IsNpc { get; set; }

        public bool CanLogin { get; set; } = true;

        public int FailedLoginCount { get; set; }

        public DateTime? LockedUntil { get; set; }


        public User(string username, string? userEmail, string? passwordHash, bool isAdmin)
        {
            UserId = Guid.NewGuid();
            Username = username;
            Email = userEmail;
            Password_Hash = passwordHash;
            IsAdmin = isAdmin;
        }

        public User()
        { }
    }
}
