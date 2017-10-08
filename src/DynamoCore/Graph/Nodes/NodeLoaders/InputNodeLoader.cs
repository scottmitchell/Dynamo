using System.Xml;
using Dynamo.Graph.Nodes.CustomNodes;

namespace Dynamo.Graph.Nodes.NodeLoaders
{
    internal class InputNodeLoader : INodeLoader<Symbol>, INodeFactory<Symbol>
    {
        public InputNodeLoader()
        {
        }

        public Symbol CreateNodeFromFile(XmlElement elNode, SaveContext context, ProtoCore.Namespace.ElementResolver resolver)
        {
            var node = CreateNode();
            node.ElementResolver = resolver;
            node.Deserialize(elNode, context);
            return node;
        }

        public Symbol CreateNodeFromFile(Newtonsoft.Json.Linq.JObject jNode, SaveContext context, ProtoCore.Namespace.ElementResolver resolver)
        {
            throw new System.NotImplementedException();
        }

        public Symbol CreateNode()
        {
            return new Symbol(); 
        }
    }
}
