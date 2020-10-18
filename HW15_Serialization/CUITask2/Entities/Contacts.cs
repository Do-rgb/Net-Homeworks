﻿using System.Xml.Serialization;

namespace CUITask2.Entities
{
    [XmlRoot(ElementName = "CONTACTS")]
    public class Contacts
    {
        [XmlElement(ElementName = "SmsPhoneNumber")]
        public long SmsPhoneNumber { get; set; }

        [XmlElement(ElementName = "PhoneNeedActualize")]
        public bool PhoneNeedActualize { get; set; }
    }
}