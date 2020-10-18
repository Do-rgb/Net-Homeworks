using System.Xml.Serialization;

namespace CUITask2.Entities
{
    [XmlRoot(ElementName = "POST_ERRORS")]
    public class PostErrors
    {
        [XmlElement(ElementName = "All")] public long All { get; set; }

        [XmlElement(ElementName = "Critical")] public long Critical { get; set; }
    }
}