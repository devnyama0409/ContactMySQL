using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactMySQL.Startup))]
namespace ContactMySQL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
