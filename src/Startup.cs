using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core2WebApi.Common;
using Core2WebApi.Common.Security;
using Core2WebApi.Common.Web;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.Data.SqlServer.QueryProcessors;
using Core2WebApi.LinkServices;
using Core2WebApi.Services.BrokersService;
using Core2WebApi.Services.InquiryProcessing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Core2WebApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddAutoMapper ();
            services.AddMvc ();
            services.AddApiVersioning (Options => {
                Options.ReportApiVersions = true;
                Options.DefaultApiVersion = new ApiVersion (1, 0);
            });

            AddBindings (services);
        }

        private void AddBindings (IServiceCollection services) {
            services.AddIdentity<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddSingleton<IApplicationInfo, ApplicationInfoAdapter> ();
            services.AddSingleton<IUserSession, UserSession> (); //(userSession);
            services.AddSingleton<IWebUserSession, UserSession> (); //(userSession);
            services.AddSingleton<ICommonLinkService, CommonLinkService> ();
            services.AddSingleton<IPagedDataRequestFactory, PagedDataRequestFactory> ();

            AddDbContexts(services);
            AddBrokerBindings (services);

        }

        private void AddDbContexts(IServiceCollection services)
        {
            services.AddDbContext<InformingDBContext>();
        }

        private void AddBrokerBindings (IServiceCollection services) {
            services.AddScoped<IBrokersService, BrokersService> ();
            services.AddScoped<IBrokerServiceDependencyBlock, BrokerServiceDependencyBlock> ();
            services.AddSingleton<IBrokerLinkService, BrokerLinkService> ();

            services.AddScoped<IAllBrokersInquiryProcessor, AllBrokersInquiryProcessor> ();
            services.AddSingleton<IAllBrokersQueryProcessor, AllBrokersQueryProcessor> ();

            services.AddSingleton<IBrokerByIdInquiryProcessor, BrokerByIdInquiryProcessor> ();
            services.AddSingleton<IBrokerByIdQueryProcessor, BrokerByIdQueryProcessor> ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationInfo applicationInfo) {
            loggerFactory.AddFile ("logs/" + applicationInfo.ApplicationName + "-{Date}.txt");

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler (options => {
                    options.Run (async context => {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var ex = context.Features.Get<IExceptionHandlerFeature> ();
                        if (ex != null) {
                            var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                            await context.Response.WriteAsync (err).ConfigureAwait (false);
                        }
                    });
                });
            }
            app.UseMvc ();
        }
    }
}