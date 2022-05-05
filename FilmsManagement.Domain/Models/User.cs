using System;

namespace FilmsManagement.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string Mail { get; set; }
    }
}
