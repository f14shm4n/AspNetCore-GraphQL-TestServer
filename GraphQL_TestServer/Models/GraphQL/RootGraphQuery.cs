using GraphQL.Types;
using GraphQL_TestServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models.GraphQL
{
    public class RootGraphQuery : ObjectGraphType
    {
        public RootGraphQuery(DataService data)
        {
            Field<UserType>("user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return data.GetUser(id);
                });
            Field<ListGraphType<UserType>>("users", resolve: ctx => data.Users);

            Field<CategoryType>("category",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: ctx =>
                {
                    int? id = ctx.GetArgument<int?>("id", 0);
                    string name = ctx.GetArgument<string>("name");

                    if (id.HasValue) return data.GetCategory(id.Value);
                    if (name != null) return data.GetCategory(name);
                    return null;
                });
            Field<ListGraphType<CategoryType>>("categories", resolve: ctx => data.Categories);

            Field<PostType>("post",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx => data.GetPost(ctx.GetArgument<int>("id")));
            Field<ListGraphType<PostType>>("posts",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "count" }),
                resolve: ctx => data.GetPosts(ctx.GetArgument<int>("count")));
        }
    }
}
