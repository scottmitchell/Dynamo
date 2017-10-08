using System.Xml;
using Dynamo.Engine;
using ProtoCore.Namespace;

namespace Dynamo.Graph.Nodes.NodeLoaders
{
    /// <summary>
    ///     Xml Loader for CodeBlock nodes.
    /// </summary>
    internal class CodeBlockNodeLoader : INodeLoader<CodeBlockNodeModel>, INodeFactory<CodeBlockNodeModel>
    {
        private readonly LibraryServices libraryServices;

        public CodeBlockNodeLoader(LibraryServices manager)
        {
            libraryServices = manager;
        }

        public CodeBlockNodeModel CreateNodeFromFile(XmlElement elNode, SaveContext context, ElementResolver resolver)
        {
            var node = CreateNode();
            node.ElementResolver = resolver;
            node.Deserialize(elNode, context);
            return node;
        }

        public CodeBlockNodeModel CreateNodeFromFile(Newtonsoft.Json.Linq.JObject jNode, SaveContext context, ElementResolver resolver)
        {
            var guid = Dynamo.Utilities.GuidUtility.tryParseOrCreateGuid(jNode["Id"].Value<string>());
            var code = jNode["Code"].ToString();
            return new CodeBlockNodeModel(code, guid, 0.0, 0.0, libraryServices, resolver);
        }

        public CodeBlockNodeModel CreateNode()
        {
            return new CodeBlockNodeModel(libraryServices);
        }
    }
}