namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(ElementName = "dataroot", Namespace = "", IsNullable = false)]
    public partial class character_skill_nodes
    {
        public string edit_uuid { get; set; }

        [System.Xml.Serialization.XmlElement("character_skill_nodes")]
        public character_skill_node[] nodes { get; set; }

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
    public partial class character_skill_node
    {

        public string campaign_key { get; set; }

        public string character_skill_key { get; set; }

        public string character_skill_node_set_key { get; set; }

        public string faction_key { get; set; }

        public byte indent { get; set; }

        public string key { get; set; }

        public byte points_on_creation { get; set; }

        public byte required_num_parents { get; set; }

        public string subculture { get; set; }

        public byte tier { get; set; }

        public byte visible_in_ui { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string record_uuid { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public ulong record_timestamp { get; set; }

        [System.Xml.Serialization.XmlAttribute()]
        public string record_key { get; set; }
    }
}
