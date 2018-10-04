﻿using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Vivid.GraphQL;
using Vivid.GraphQL.Types;
using Vivid.Web.GraphQL;

namespace Vivid.Web.Helpers
{
    public static class GraphQLExtensions
    {
        public static IServiceCollection AddGraphQL(this IServiceCollection services)
        {
            services.AddTransient<IQueryResolver, QueryResolver>();

            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<UserType>();
            services.AddSingleton<UserInputType>();
            services.AddSingleton<TaskListType>();
            services.AddSingleton<TaskListInputType>();
            services.AddSingleton<TaskItemType>();
            services.AddSingleton<TaskItemInputType>();

            services.AddSingleton<ZevereQuery>();
            services.AddSingleton<ZevereMutation>();
            services.AddSingleton<ISchema, ZevereSchema>(_ => new ZevereSchema(
                new FuncDependencyResolver(_.GetRequiredService)
            ));

            services.AddGraphQl(schema =>
            {
                schema.SetQueryType<ZevereQuery>();
                schema.SetMutationType<ZevereMutation>();
            });

            return services;
        }
    }
}