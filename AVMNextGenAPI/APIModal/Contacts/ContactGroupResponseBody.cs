using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Contacts
{
    public class ContactGroupResponseBody
    {
        public int contactGroupId { get; set; }
        public bool successful { get; set; }
    }

    public class ContactGroupDetailsResponseBody
    {
        public int contactGroupId { get; set; }
        public string shortName { get; set; }
        public string fullName { get; set; }
        public string comments { get; set; }
        public int contactDetailCount { get; set; }
    }


}
