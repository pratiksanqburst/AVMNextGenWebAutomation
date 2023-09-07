using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Contacts
{
    public class ContactTreebody
    {
        public class ContactGroupRequestBody
        {
            public string shortName { get; set; }
            public string fullName { get; set; }
            public string comments { get; set; }
            public bool deleted { get; set; }
        }
        public class EditContactGroupRequestBody
        {
            public int contactGroupId { get; set; }
            public string shortName { get; set; }
            public string fullName { get; set; }
            public string comments { get; set; }
            public bool deleted { get; set; }
        }
    }
}
