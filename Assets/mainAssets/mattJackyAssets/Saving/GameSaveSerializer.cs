using System.IO;
using System.Xml.Serialization;

/**
 * Created by Matthew Lillie
 * 
 * This is a static class which will be used for saving and loading a game state
 * 
 */
public static class GameSaveSerializer
{
    // Serializes the generic value of T and returns the serialized string
    public static string Serialize<T>(this T value)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, value);
        return writer.ToString();
    }

    // Deserializes the given value and returns the generic value of T that the value represented
    public static T Deserialize<T>(this string value)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(value);
        return (T) xml.Deserialize(reader);

    }
}
