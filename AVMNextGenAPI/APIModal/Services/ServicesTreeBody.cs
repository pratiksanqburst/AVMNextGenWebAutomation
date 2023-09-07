using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Services
{
    public class ServicesTreeBody
    {
        public class GetServiceByIdRequest
        {
            public string userName { get; set; }
            public int serviceId { get; set; }
        }


        public class GetServicesByUserNameRequest
        {
            public string userName { get; set; }
            public int unitId { get; set; }
            public int pageNumber { get; set; }
            public int pageSize { get; set; }
        }

        public class CreateServiceRequestBody
        {
            public int unitId { get; set; }
            public int serviceType { get; set; }
            public string serviceDate { get; set; }
            public int cost { get; set; }
            public int odometer { get; set; }
            public string notes { get; set; }
            public int engineHours { get; set; }
            public string userName { get; set; }
        }
 

    }
}
