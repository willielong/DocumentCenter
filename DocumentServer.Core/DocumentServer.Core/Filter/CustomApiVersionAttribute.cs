using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace DocumentServer.Core.Filter
{
    public class CustomApiVersionAttribute : ApiVersionsBaseAttribute
    {
        public CustomApiVersionAttribute(ApiVersion version) : base(version)
        {
        }

        public CustomApiVersionAttribute(params ApiVersion[] versions) : base(versions)
        {
        }

        public CustomApiVersionAttribute(string versions) : base(versions)
        {
        }

        public CustomApiVersionAttribute(params string[] versions) : base(versions)
        {
        }
    }
}
