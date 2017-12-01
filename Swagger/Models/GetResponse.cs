using Swagger.Net;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;

namespace Swagger.Models
{
    [SwaggerSchemaFilter(typeof(AddDefault))]
    public class SchemaFilterGetResponse
    {
        public IEnumerable<string> Strings { get; set; } = new List<string>();
    }

    public class InheritedGetResponse : Base
    {
        public IEnumerable<string> Strings { get; set; } = new List<string>();
    }

    [SwaggerSchemaFilter(typeof(AddDefault))]
    public abstract class Base { }

    public class AddDefault : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry sr, Type t)
        {
            schema.example = schema.@default = new { working = true };
        }
    }
}