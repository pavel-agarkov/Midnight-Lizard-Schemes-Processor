﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MidnightLizard.Schemes.Domain.Common;
using MidnightLizard.Schemes.Domain.PublicSchemeAggregate;
using MidnightLizard.Schemes.Domain.PublicSchemeAggregate.Infrastructure;
using MidnightLizard.Schemes.Infrastructure.Queue;
using MidnightLizard.Schemes.Infrastructure.Snapshot;
using MidnightLizard.Schemes.Processor.Configuration;
using Newtonsoft.Json;

namespace MidnightLizard.Schemes.Processor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<AggregatesCacheConfig>(Configuration);

            services.AddSingleton<ElasticSearchConfig>(x =>
            {
                var esConfig = new ElasticSearchConfig();
                Configuration.Bind(esConfig);
                return esConfig;
            });
            services.AddSingleton<KafkaConfig>(x =>
            {
                return new KafkaConfig
                {
                    KAFKA_EVENTS_CONSUMER_CONFIG = JsonConvert
                        .DeserializeObject<Dictionary<string, object>>(
                            Configuration.GetValue<string>(nameof(KafkaConfig.KAFKA_EVENTS_CONSUMER_CONFIG))),

                    KAFKA_REQUESTS_CONSUMER_CONFIG = JsonConvert
                        .DeserializeObject<Dictionary<string, object>>(
                            Configuration.GetValue<string>(nameof(KafkaConfig.KAFKA_REQUESTS_CONSUMER_CONFIG))),

                    SCHEMES_EVENTS_TOPIC = Configuration.GetValue<string>(
                        nameof(KafkaConfig.SCHEMES_EVENTS_TOPIC)),

                    SCHEMES_REQUESTS_TOPIC = Configuration.GetValue<string>(
                        nameof(KafkaConfig.SCHEMES_REQUESTS_TOPIC))
                };
            });
            services.AddTransient<IAggregateSnapshot<PublicScheme, PublicSchemeId>, SchemesSnapshot>();

            services.AddMemoryCache();
            services.AddMvc();

            // Autofac - last part!
            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
