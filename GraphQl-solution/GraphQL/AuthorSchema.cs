using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{
    public class AuthorSchema : Schema,ISchema
    {
        public AuthorSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
        }
    }
}
