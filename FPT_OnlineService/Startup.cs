﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FPT_OnlineService.Startup))]
namespace FPT_OnlineService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}