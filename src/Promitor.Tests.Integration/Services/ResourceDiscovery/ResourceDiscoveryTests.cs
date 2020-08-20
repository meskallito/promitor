using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bogus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Promitor.Agents.ResourceDiscovery.Graph.Model;
using Promitor.Tests.Integration.Clients;
using Xunit;
using Xunit.Abstractions;

namespace Promitor.Tests.Integration.Services.ResourceDiscovery
{
    public class ResourceDiscoveryTests : ResourceDiscoveryIntegrationTest
    {
        private readonly Faker _bogusGenerator = new Faker();

        public ResourceDiscoveryTests(ITestOutputHelper testOutput)
          : base(testOutput)
        {
        }

        [Fact]
        public async Task ResourceDiscovery_GetForUnexistingResourceDiscoveryGroup_ReturnsNotFound()
        {
            // Arrange
            string resourceDiscoveryGroupName = _bogusGenerator.Lorem.Word();
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ResourceDiscovery_GetAllPerResourceTypeWithoutFilters_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "logic-apps-unfiltered";
            const int expectedResourceCount = 13;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnOneResourceGroup_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "one-resource-group-scenario";
            const int expectedResourceCount = 3;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnTwoResourceGroups_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "two-resource-group-scenario";
            const int expectedResourceCount = 4;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnOneSubscription_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "one-subscriptions-scenario";
            const int expectedResourceCount = 2;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnTwoSubscriptions_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "two-subscriptions-scenario";
            const int expectedResourceCount = 13;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnAppTag_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "one-tag-scenario";
            const int expectedResourceCount = 3;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnAppAndRegionTag_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "two-tag-scenario";
            const int expectedResourceCount = 3;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnOneRegion_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "one-region-scenario";
            const int expectedResourceCount = 1;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_GetWithFilterOnTwoRegions_ReturnsExpectedAmount()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "two-region-scenario";
            const int expectedResourceCount = 12;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            Assert.Equal(expectedResourceCount, resources.Count);
        }

        [Fact]
        public async Task ResourceDiscovery_MultipleCallsForSameDiscoveryGroup_ReturnsSameResults()
        {
            // Arrange
            const string resourceDiscoveryGroupName = "two-region-scenario";
            const int expectedResourceCount = 12;
            var resourceDiscoveryClient = new ResourceDiscoveryClient(Configuration, Logger);

            // Act
            var response1 = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);
            var response2 = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);
            var response3 = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);
            var response4 = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);
            var response5 = await resourceDiscoveryClient.GetDiscoveredResourcesAsync(resourceDiscoveryGroupName);

            // Assert
            var discoveredResources1 = await GetDiscoveredResourcesAsync(response1);
            var discoveredResources2 = await GetDiscoveredResourcesAsync(response2);
            var discoveredResources3 = await GetDiscoveredResourcesAsync(response3);
            var discoveredResources4 = await GetDiscoveredResourcesAsync(response4);
            var discoveredResources5 = await GetDiscoveredResourcesAsync(response5);
            Logger.LogInformation("Asserting first results");
            Assert.Equal(expectedResourceCount, discoveredResources1.Count);
            Logger.LogInformation("Asserting second results");
            Assert.Equal(expectedResourceCount, discoveredResources2.Count);
            Logger.LogInformation("Asserting third results");
            Assert.Equal(expectedResourceCount, discoveredResources3.Count);
            Logger.LogInformation("Asserting fourth results");
            Assert.Equal(expectedResourceCount, discoveredResources4.Count);
            Logger.LogInformation("Asserting fifth results");
            Assert.Equal(expectedResourceCount, discoveredResources5.Count);
        }

        private static async Task<List<Resource>> GetDiscoveredResourcesAsync(HttpResponseMessage response)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var rawResponseBody = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(rawResponseBody);
            var resources = JsonConvert.DeserializeObject<List<Resource>>(rawResponseBody);
            Assert.NotNull(resources);
            return resources;
        }
    }
}
