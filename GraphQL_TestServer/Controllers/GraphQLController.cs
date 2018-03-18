using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL_TestServer.Models.GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_TestServer.Controllers
{
    [Produces("application/json")]
    [Route("api/graph")]
    public class GraphQLController : Controller
    {
        private RootGraphQuery _graphQuery;

        public GraphQLController(RootGraphQuery graphQuery)
        {
            this._graphQuery = graphQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQueryParam param, [FromServices] IServiceProvider services)
        {
            var schema = new Schema { Query = _graphQuery, ResolveType = t => (GraphType)services.GetService(t) };

            var result = await new DocumentExecuter().ExecuteAsync(opt =>
            {
                opt.Schema = schema;
                opt.Query = param.Query;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}