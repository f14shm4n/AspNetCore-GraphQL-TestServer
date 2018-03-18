using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_TestServer.Models.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id).Description("The user id.");
            Field(x => x.Name).Description("The user name.");
            Field(x => x.Email).Description("The user email.");
            Field(x => x.Joined).Description("The user registration date.");
        }
    }
}
