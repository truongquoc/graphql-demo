using GraphQL;
using GraphQL.Types;
using GraphQl_solution.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{
    [Route("graphQL")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GraphQLController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables;
            var schema = new Schema
            {
                //Query = new AuthorQuery(_db)
            };
            if (query == null) { throw new ArgumentNullException(paramName: nameof(query)); }
            //var inputs = query.Variables;
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                //_.Inputs = inputs;
            });

            if(result.Errors.Count > 0)
            {
                return BadRequest();
            }
            
            return Ok(result);
        }
    }
}
