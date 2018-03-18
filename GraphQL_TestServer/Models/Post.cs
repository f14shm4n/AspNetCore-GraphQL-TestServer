using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public override string ToString() => $"Id = {Id}, Name = {Name}, CategoryId = {CategoryId}";
    }
}
