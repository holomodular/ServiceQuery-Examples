using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Database;
using Asp.Versioning;

namespace WebApp.Controllers.api.v1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json", "application/problem+json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostgreSqlController : ExampleController
    {
        private readonly PostgreSqlDatabaseContext _context;

        public PostgreSqlController(
            PostgreSqlDatabaseContext exampleDatabaseContext,
            IMapper mapper) : base(mapper)
        {
            _context = exampleDatabaseContext;
        }

        protected override IQueryable<ExampleClass> GetQueryable()
        {
            return _context.ExampleClasses.AsQueryable();
        }
    }
}