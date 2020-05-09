using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Spells")]
public class SpellManager : MonoBehaviour
{
    [XmlArray("Spells")]
    [XmlArrayItem("Spell")]
    public List<Spell> spells = new List<Spell>();

    public Text spellName;
    public Text spellLevel;
    public Text spellDescription;

    Text[] spellDetails;

    void Start()
    {
        spellDetails = new Text[] { spellName, spellLevel, spellDescription };
        Load("Resources/Spells");
    }

    public static SpellManager Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(SpellManager));

        StringReader reader = new StringReader(_xml.text);

        SpellManager spells = serializer.Deserialize(reader) as SpellManager;

        reader.Dispose();

        return spells;
    }
}
