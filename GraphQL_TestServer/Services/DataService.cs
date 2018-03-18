using f14;
using GraphQL_TestServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Services
{
    public class DataService
    {
        public DataService()
        {
            Users = GenFu.GenFu.ListOf<User>(3);
            Categories = GenFu.GenFu.ListOf<Category>(3);
            Posts = new List<Post>();

            foreach (var c in Categories)
            {
                var postsCount = RandomHelper.Next(1, 5);
                for (int i = 0; i < postsCount; i++)
                {
                    var post = GenFu.GenFu.New<Post>();
                    post.CategoryId = c.Id;
                    post.Category = null;
                    post.UserId = Users[RandomHelper.Next(0, Users.Count)].Id;
                    post.User = null;

                    Posts.Add(post);
                }
            }
        }

        public List<User> Users { get; }
        public List<Category> Categories { get; }
        public List<Post> Posts { get; }

        public User GetUser(int id) => Users.FirstOrDefault(x => x.Id == id);

        public Category GetCategory(int id) => Categories.FirstOrDefault(x => x.Id == id);
        public Category GetCategory(string name) => Categories.FirstOrDefault(x => x.Name == name);

        public Post GetPost(int id) => Posts.FirstOrDefault(x => x.Id == id);
        public IEnumerable<Post> GetPosts(int count) => Posts.Take(count);
        public IEnumerable<Post> GetPostsByCategoryId(int categoryId) => Posts.Where(x => x.CategoryId == categoryId);
    }
}
