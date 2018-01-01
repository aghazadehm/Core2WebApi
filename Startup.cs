using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using Core2WebApi.Common;
using Core2WebApi.Common.Security;
using Core2WebApi.Common.Web;
using Core2WebApi.Controllers.V1.Derivatives.Future;
using Core2WebApi.Data.Entities;
using Core2WebApi.Data.QueryProcessors;
using Core2WebApi.Data.SqlServer.QueryProcessors;
using Core2WebApi.LinkServices;
using Core2WebApi.Services.BrokersService;
using Core2WebApi.Services.Derivatives.Future;
using Core2WebApi.Services.InquiryProcessing;
using Core2WebApi.Services.InquiryProcessing.Derivatives.Future;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Core2WebApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddAutoMapper ();

            services.AddSwaggerGen (options => {
                options.SwaggerDoc ("v1", new Info {
                    Title = "IME API",
                        Version = "v1",
                        Description = "فراهم کردن داده های بورس کالای برای فعالین بازار سرمایه",
                        TermsOfService = "None",
                        Contact = new Contact {
                            Name = "ime.co.ir/api", Email = "aghazadeh@ime.co.ir", Url = "https://ime.co.ir.api/v1"
                        }
                });
                var filePath = Path.Combine (PlatformServices.Default.Application.ApplicationBasePath, "SWCapi.xml");
                options.IncludeXmlComments (filePath);

            });

            services.AddApiVersioning (Options => {
                Options.ReportApiVersions = true;
                Options.DefaultApiVersion = new ApiVersion (1, 0);
            });

            AddBindings (services);
            services.AddMvc ();
        }

        private void AddBindings (IServiceCollection services) {
            services.AddIdentity<IHttpContextAccessor, HttpContextAccessor> ();
            services.AddSingleton<IApplicationInfo, ApplicationInfoAdapter> ();
            services.AddSingleton<IUserSession, UserSession> (); //(userSession);
            services.AddSingleton<IWebUserSession, UserSession> (); //(userSession);
            services.AddSingleton<ICommonLinkService, CommonLinkService> ();
            services.AddSingleton<IPagedDataRequestFactory, PagedDataRequestFactory> ();

            AddDbContexts (services);
            AddBrokerBindings (services);
            AddFutureContractBinding (services);

        }

        private void AddFutureContractBinding (IServiceCollection services) {
            services.AddSingleton<IFutureContractLinkService, FutureContractLinkService> ();

            services.AddScoped<IAllFutureContractInquiryProcessor, AllFutureContractInquiryProcessor> ();
            services.AddSingleton<IAllFutureContractQueryProcessor, AllFutureContractQueryProcessor> ();

            services.AddScoped<IFutureContractsDependencyBlock, FutureContractsDependencyBlock> ();

            // services.AddSingleton<IBrokerByIdInquiryProcessor, BrokerByIdInquiryProcessor> ();
            // services.AddSingleton<IBrokerByIdQueryProcessor, BrokerByIdQueryProcessor> ();
        }

        private void AddDbContexts (IServiceCollection services) {
            services.AddDbContext<InformingDBContext> ();
            services.AddDbContext<FutureSnapshotContext> ();
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
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger ();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc (r => {
                r.MapRoute ("default", "{controller}/{action}");
            });
        }
    }
}