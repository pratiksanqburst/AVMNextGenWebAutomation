using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Roles
{
    public class RolesTreeBody
    {
        public class EditRoleNameRequestBody
        {
            public string userName { get; set; }
            public string roleName { get; set; }
            public string roleDescription { get; set; }
        }

        public class EditRoleRightsRequestBody
        {
            public string userName { get; set; }
            public bool defaultRole { get; set; }
            public int[] reportList { get; set; }
            public int[] accessRights { get; set; }
        }



        public class RolesCreationRequestBody
        {
            public string userName { get; set; }
            public string roleName { get; set; }
            public string roleDescription { get; set; }
            public bool defaultRole { get; set; }
            public int[] reportList { get; set; }
            public int[] accessRights { get; set; }
        }
        public class VehicleTreeBody
        {
            public string UserName { get; set; }
            public bool forManagement { get; set; }
        }

    }
}
