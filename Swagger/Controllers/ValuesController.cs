using Swashbuckle.Swagger;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Swagger.Controllers
{
    [RoutePrefix("Values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("Working")]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(WorkingGetResponse))]
        public IHttpActionResult Working()
        {
            return Ok(new WorkingGetResponse { Strings = new List<string> { "value1", "value2" } });
        }

        [HttpGet]
        [Route("NotWorking")]
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(NotWorkingGetResponse))]
        public IHttpActionResult NotWorking()
        {
            return Ok(new NotWorkingGetResponse { Strings = new List<string> { "value1", "value2" } });
        }
    }

    internal class NotWorkingGetResponse : BaseGetResponse
    {
        public IEnumerable<string> Strings { get; set; } = new List<string>();
    }

    [SwaggerSchemaFilter(typeof(SingleJsonArraySchemaFilter))]
    internal class WorkingGetResponse : BaseGetResponse
    {
        public IEnumerable<string> Strings { get; set; } = new List<string>();
    }

    [SwaggerSchemaFilter(typeof(SingleJsonArraySchemaFilter))]
    internal abstract class BaseGetResponse
    {
    }

    internal class SingleJsonArraySchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            schema.@default = new { working = true };
        }
    }
}
