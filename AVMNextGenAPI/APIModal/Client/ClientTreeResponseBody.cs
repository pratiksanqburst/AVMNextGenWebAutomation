using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Client
{


    public class CreateClientRequestBody
    {
        public Client client { get; set; }
        public int[]? unitIds { get; set; }
        public int[]? vehicleGroupIds { get; set; }
        public int[]? driverIds { get; set; }
        public int[]? driverGroupIds { get; set; }
    }

    public class Client
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string clientPassword { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string position { get; set; }
        public string notes { get; set; }
        public int clientRole { get; set; }
        public string clientFullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string preferredName { get; set; }
    }


    public class ClientTreeResponseBody
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string clientPassword { get; set; }
        public string clientPasswordBefore { get; set; }
        public bool deleted { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string position { get; set; }
        public string notes { get; set; }
        public int clientRole { get; set; }
        public int isAccountLocked { get; set; }
        public string clientFullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string preferredName { get; set; }
        public int driverId { get; set; }
    }

    public class ClientByUsernameResponseBody
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
        public bool deleted { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string position { get; set; }
        public string notes { get; set; }
        public int clientRole { get; set; }
        public string clientRoleName { get; set; }
        public int isAccountLocked { get; set; }
        public string clientFullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string preferredName { get; set; }
        public int driverId { get; set; }
    }


    public class ClientGroupedResponseBody
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
        public bool deleted { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string position { get; set; }
        public string notes { get; set; }
        public int clientRole { get; set; }
        public string clientRoleName { get; set; }
        public int isAccountLocked { get; set; }
        public string clientFullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string preferredName { get; set; }
        public bool suppressAlarms { get; set; }
        public bool suppressAlerts { get; set; }
        public Driversgrouped[] driversGrouped { get; set; }
        public Driversungrouped[] driversUnGrouped { get; set; }
        public Vehiclesgrouped[] vehiclesGrouped { get; set; }
        public Vehiclesungrouped[] vehiclesUnGrouped { get; set; }
    }

    public class Driversgrouped
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int driverCount { get; set; }
        public int driverTotalCount { get; set; }
        public Driver1[] drivers { get; set; }
    }

    public class Driver1
    {
        public int driverId { get; set; }
        public string shortName { get; set; }
    }

    public class Driversungrouped
    {
        public int driverId { get; set; }
        public string shortName { get; set; }
    }

    public class Vehiclesgrouped
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int unitCount { get; set; }
        public int unitTotalCount { get; set; }
        public Unit[] units { get; set; }
    }

    public class Unit
    {
        public int unitId { get; set; }
        public string unitName { get; set; }
    }

    public class Vehiclesungrouped
    {
        public int unitId { get; set; }
        public string unitName { get; set; }
    }

}
