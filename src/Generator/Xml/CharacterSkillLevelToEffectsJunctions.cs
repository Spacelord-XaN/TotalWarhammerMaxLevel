namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(ElementName = "dataroot", Namespace = "", IsNullable = false)]
    public partial class character_skill_level_to_effects_junctions
    {
        public string edit_uuid { get; set; }

        [System.Xml.Serialization.XmlElement("character_skill_level_to_effects_junctions")]
        public character_skill_level_to_effects_junction[] junctions { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string export_time { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public ushort revision { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string export_branch { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string export_user { get; set; }
    }

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class character_skill_level_to_effects_junction
    {
        public string character_skill_key { get; set; }

        public string effect_key { get; set; }

        public string effect_scope { get; set; }

        public byte is_factionwide { get; set; }

        public byte level { get; set; }

        public short value { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string record_uuid { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public ulong record_timestamp { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string record_key { get; set; }
    }
}
