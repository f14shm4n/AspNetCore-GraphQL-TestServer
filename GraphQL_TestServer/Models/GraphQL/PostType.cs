using GraphQL.Types;
using GraphQL_TestServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models.GraphQL
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType(DataService data)
        {
            Field(x => x.Id).Description("The post id.");
            Field(x => x.Name).Description("The post name.");
            Field(x => x.Link).Description("The post permalink.");
            Field(x => x.Created).Description("The post created date.");
            Field(x => x.Modified).Description("The post modification date.");

            Field(x => x.CategoryId).Description("The category id.");
            Field(x => x.UserId).Description("The user id.");

            Field<UserType>("user", resolve: ctx => data.GetUser(ctx.Source.UserId));
            Field<CategoryType>("category", resolve: ctx => data.GetCategory(ctx.Source.CategoryId));
        }
    }
}
