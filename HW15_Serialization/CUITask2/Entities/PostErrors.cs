using System.Xml.Serialization;

namespace CUITask2.Entities
{
    [XmlRoot(ElementName="POST_ERRORS")]
    public class PostErrors {
        [XmlElement(ElementName="All")]
        public int All { get; set; }
        [XmlElement(ElementName="Critical")]
        public int Critical { get; set; }
    }
}