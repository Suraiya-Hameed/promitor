using GuardNet;
using Newtonsoft.Json.Linq;
using Promitor.Core.Contracts;
using Promitor.Core.Contracts.ResourceTypes;

namespace Promitor.Agents.ResourceDiscovery.Graph.ResourceTypes
{
    public class CognitiveServicesAccountDiscoveryQuery : ResourceDiscoveryQuery
    {
        public override string[] ResourceTypes => new[] { "microsoft.cognitiveservices/accounts" };
        public override string[] ProjectedFieldNames => new[] { "subscriptionId", "resourceGroup", "name" };

        public override AzureResourceDefinition ParseResults(JToken resultRowEntry)
        {
            Guard.NotNull(resultRowEntry, nameof(resultRowEntry));

            var cognitiveServicesAccountName = resultRowEntry[2]?.ToString();

            var resource = new CognitiveServicesAccountResourceDefinition(resultRowEntry[0]?.ToString(), resultRowEntry[1]?.ToString(), cognitiveServicesAccountName);
            return resource;
        }
    }
}
