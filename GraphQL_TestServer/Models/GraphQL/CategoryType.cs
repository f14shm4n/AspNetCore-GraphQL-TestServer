using GraphQL.Types;
using GraphQL_TestServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models.GraphQL
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(DataService data)
        {
            Field(x => x.Id).Description("The category id.");
            Field(x => x.Name).Description("The category name.");
            Field<ListGraphType<PostType>>("posts",
                resolve: ctx => data.GetPostsByCategoryId(ctx.Source.Id),
                description: "The category posts.");
        }
    }
}
