using System.Xml;
using System.Xml.Serialization;

public class Item
{
    [XmlAttribute("name")]
    public string name;

    [XmlElement("Cost")]
    public string cost;

    [XmlElement("Weight")]
    public float weight;

    [XmlElement("Description")]
    public string description;
}
