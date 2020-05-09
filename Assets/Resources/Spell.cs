using System.Xml;
using System.Xml.Serialization;

public class Spell
{
    [XmlAttribute("name")]
    public string name;

    [XmlElement("Level")]
    public string level;

    [XmlElement("Description")]
    public string description;
}
