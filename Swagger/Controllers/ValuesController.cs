using Swagger.Models;
using System.Web.Http;

namespace Swagger.Controllers
{
    [RoutePrefix("SchemaFilter")]
    public class ValuesController : ApiController
    {
        [Route("Regular")]
        public SchemaFilterGetResponse GetSchemaFilter()
        {
            return null;
        }

        [Route("Inherited")]
        public InheritedGetResponse GetInheritedSchemaFilter()
        {
            return null;
        }
    }
}
