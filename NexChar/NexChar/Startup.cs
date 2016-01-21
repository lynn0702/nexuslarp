using Microsoft.Owin;
using NexChar;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NexChar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
