namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(ElementName = "dataroot", Namespace = "", IsNullable = false)]
    public partial class character_skill_node_sets
    {
        public string edit_uuid { get; set; }

        [System.Xml.Serialization.XmlElement("character_skill_node_sets")]
        public character_skill_node_set[] node_sets { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string export_time { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public byte revision { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string export_branch { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string export_user { get; set; }
    }

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class character_skill_node_set
    {
        public string agent_key { get; set; }

        public string agent_subtype_key { get; set; }

        public object campaign_key { get; set; }

        public enc_title enc_title { get; set; }

        public object faction_key { get; set; }

        public byte for_army { get; set; }

        public byte for_navy { get; set; }

        public string key { get; set; }

        public string subculture { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string record_uuid { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public ulong record_timestamp { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string record_key { get; set; }
    }

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class enc_title
    {
        [System.Xml.Serialization.XmlAttribute()]
        public string state { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string last_approved_text { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string last_edit_user { get; set; }

        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }
}


