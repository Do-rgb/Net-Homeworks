using System.Xml.Serialization;

namespace CUITask2.Entities
{
    [XmlRoot(ElementName="PORTAL_USER_INFO")]
    public class PortalUserInfo {
        [XmlElement(ElementName="AGENT_INFO")]
        public AgentInfo AgentInfo { get; set; }
        [XmlElement(ElementName="CONTACTS")]
        public Contacts Contacts { get; set; }
        [XmlElement(ElementName="POST_ERRORS")]
        public PostErrors PostErrors { get; set; }
        [XmlElement(ElementName="IsEmployee")]
        public bool IsEmployee { get; set; }
        [XmlElement(ElementName="Company")]
        public string Company { get; set; }
        [XmlElement(ElementName="FilialISN")]
        public int FilialIsn { get; set; }
    }
}