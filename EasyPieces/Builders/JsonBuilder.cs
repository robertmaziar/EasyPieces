using Newtonsoft.Json.Linq;

namespace EasyPieces.Builders
{
    public class JsonBuilder
    {
        private readonly JObject _jsonObject;

        public JsonBuilder()
        {
            _jsonObject = new JObject();
        }

        public JsonBuilder AddProperty(string propertyName, object value)
        {
            _jsonObject[propertyName] = JToken.FromObject(value);
            return this;
        }

        public JsonBuilder AddArray(string arrayName, params object[] values)
        {
            _jsonObject[arrayName] = new JArray(values);
            return this;
        }

        public JsonBuilder AddObject(string objectName, Action<JsonBuilder> buildAction)
        {
            var nestedBuilder = new JsonBuilder();
            buildAction(nestedBuilder);
            _jsonObject[objectName] = nestedBuilder.Build();
            return this;
        }

        public JObject Build()
        {
            return _jsonObject;
        }
    }
}
