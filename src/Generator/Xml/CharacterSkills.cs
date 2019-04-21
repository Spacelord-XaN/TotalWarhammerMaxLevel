namespace Xan.TotalWarhammerMaxLevel.Generator.Xml
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(ElementName = "dataroot", Namespace = "", IsNullable = false)]
    public partial class character_skills
    {

        /// <remarks/>
        public string edit_uuid { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character_skills")]
        public character_skill[] skills { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string export_time { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public ushort revision { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string export_branch { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string export_user { get; set; }
    }

    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class character_skill
    {

        /// <remarks/>
        public byte background_weighting { get; set; }

        /// <remarks/>
        public string image_path { get; set; }

        /// <remarks/>
        public byte influence_cost { get; set; }

        /// <remarks/>
        public byte is_background_skill { get; set; }

        /// <remarks/>
        public byte is_female_only_background_skill { get; set; }

        /// <remarks/>
        public byte is_male_only_background_skill { get; set; }

        /// <remarks/>
        public string key { get; set; }

        /// <remarks/>
        public localised_description localised_description { get; set; }

        /// <remarks/>
        public localised_name localised_name { get; set; }

        /// <remarks/>
        public object pre_battle_speech_parameter { get; set; }

        /// <remarks/>
        public byte unlocked_at_rank { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string record_uuid { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public ulong record_timestamp { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string record_key { get; set; }
    }

    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class localised_description
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string state { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string last_approved_text { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string last_edit_user { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }

    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class localised_name
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string state { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string last_approved_text { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string last_edit_user { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value { get; set; }
    }
}