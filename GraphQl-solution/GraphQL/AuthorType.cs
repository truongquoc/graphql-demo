﻿using GraphQL.Types;
using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{
    public class AuthorType : ObjectGraphType<Author>
    {
       public AuthorType()
        {
            Name = "Author";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Author");
            Field(x => x.Name).Description("The name of the author");
            Field(x => x.Books, type: typeof(ListGraphType<BookType>)).Description("Author's books");
        }
    }
}
