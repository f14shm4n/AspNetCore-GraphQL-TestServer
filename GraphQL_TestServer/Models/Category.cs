using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Post> Posts { get; set; }

        public override string ToString() => $"Id = {Id}, Name = {Name}";
    }
}
