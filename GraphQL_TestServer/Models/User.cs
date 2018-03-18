using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }

        public override string ToString() => $"Id = {Id}, Name = {Name}, Email = {Email}, Joined = {Joined}";
    }
}
