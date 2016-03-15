using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization.Json;

namespace NexChar
{
    public class JSONModelBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var serializer = new JsonSerializer<T>();
            var inputStream = controllerContext.RequestContext.HttpContext.Request.InputStream;
            inputStream.Position = 0;
            return serializer.Deserialize(inputStream);
        }
    }
}

public interface ISerializer<T>
{
    T Deserialize(Stream inputStream);
    void Serialize(Stream outputStream, T objectGraph);
}

public class JsonSerializer<T> : ISerializer<T>
{
    private readonly DataContractJsonSerializer _serializer;

    public JsonSerializer()
    {
        _serializer = new DataContractJsonSerializer(typeof (T));
    }

    public T Deserialize(Stream inputStream)
    {
        return (T) _serializer.ReadObject(inputStream);
    }

    public void Serialize(Stream outputStream, T objectGraph)
    {
        _serializer.WriteObject(outputStream, objectGraph);
    }
}