﻿using BlazorBlogApp.Shared.Models.Base;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;

namespace BlazorBlogApp.Server.Services.Foundation
{
    // Cosmos 정보를 위한 Options을 저장하는 객체
    public class CosmosDbServiceOptions
    {
        public string? Account { get; set; }
        public string? Key { get; set; }
        public string? DatabaseName { get; set; }
        public string? ContainerName { get; set; }
    }

    // Cosmos를 실질적으로 연결하는 Service
    public class CosmosDbService
    {
        private readonly CosmosClient client;
        private readonly string databaseName;
        private readonly string ContainerName; // 왜 소문자 대문자 사용 경우가 다른지

        public CosmosDbService(IOptions<CosmosDbServiceOptions> options)
        {
            client = new CosmosClient(options.Value.Account, options.Value.Key);
            databaseName = options.Value.DatabaseName;
            ContainerName = options.Value.ContainerName;
        }

        public Container GetContainer()
        {
            var container = client.GetContainer(databaseName, ContainerName);
            return container;
        }
    }

    // Cosmos에 실질적으로 data를 저장하는 확장 메서드
    public static class CosmosDbServiceExtensions
    {
        public static async Task<T> GetModel<T>(this Container container, string id) where T : CosmosModelBase
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            try
            {
                var response = await container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public static async Task AddModel<T>(this Container container, T model) where T : CosmosModelBase
        {
            await container.CreateItemAsync(model, new PartitionKey(model.Id));
        }

        public static async Task EditModel<T>(this Container container, T model) where T : CosmosModelBase
        {
            await container.UpsertItemAsync(model, new PartitionKey(model.Id));
        }

        public static async Task RemoveModel<T>(this Container container, string id) where T : CosmosModelBase
        {
            await container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        public static IQueryable<T> OfCosmosItemType<T>(this IQueryable<T> query) where T : CosmosModelBase
        {
            var typeName = query.ElementType.Name;
            return query.Where(x => x.ClassType == typeName);
        }


        public static IQueryable<T> GetModelLinqQueryable<T>(this Container container) where T : CosmosModelBase
        {
            return container.GetItemLinqQueryable<T>()
                .OfCosmosItemType()
                .AsQueryable();
        }

        public static async Task<List<T>> GetListFromFeedIteratorAsync<T>(this IQueryable<T> query) where T : CosmosModelBase
        {
            var result = new List<T>();
            using (var iterator = query.ToFeedIterator())
            {
                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync())
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
