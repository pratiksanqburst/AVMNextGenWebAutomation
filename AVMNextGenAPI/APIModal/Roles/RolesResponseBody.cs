using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Roles
{
    public class RolesResponseBody
    {
        public int roleId { get; set; }
    }

    public class RolesListResponseBody
    {
        public string roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public bool defaultRole { get; set; }
        public int[]? reportList { get; set; }
        public int[] accessRights { get; set; }
        public User[]? users { get; set; }
    }

    public class User
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
    }

}
