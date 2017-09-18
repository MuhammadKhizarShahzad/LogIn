using System;
using System.Collections.Generic;

namespace LogIn.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public string Role { get; set; }
        public string DiplayName { get; set; }
    }
}
