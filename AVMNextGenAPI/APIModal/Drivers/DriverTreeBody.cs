using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers
{
    public class DriverTreeBody
    {
        public class VehicleTreeBody
        {
            public string UserName { get; set; }
            public bool forManagement { get; set; }
        }
        public class VehicleStatusBody
        {
            public string userName { get; set; }
            public int unitId { get; set; }
            public int driverIdCurrent { get; set; }
        }
        public class DriverGroupsResponsebody
        {
            public int groupId { get; set; }
            public string groupName { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int driverCount { get; set; }

        }
        public class CreateDriverBody
        {
            public string? firstName { get; set; }
            public string? lastName { get; set; }
            public string? phone1 { get; set; }
            public string? email1 { get; set; }
            public string? address1 { get; set; }
            public string? address2 { get; set; }
            public string? nationality { get; set; }
            public string? dateJoined { get; set; }
            public string? gender { get; set; }
            public string? groupName { get; set; }
            public string? bloodType { get; set; }
            public string? licenceNumber { get; set; }
            public string? driverUniqueId { get; set; }
            public int? groupId { get; set; }
            public string? emergencyContactName { get; set; }
            public string? emergencyContactRelationship { get; set; }
            public string? emergencyContactPhone1 { get; set; }
            public string? licenseExpiryDate { get; set; }
            public string? licenseState { get; set; }
            public int? unitId { get; set; }
            public int? rfTagId { get; set; }
        }
        public class EditDriverBody
        {
            public int driverId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phone1 { get; set; }
            public string email1 { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string nationality { get; set; }
            public string dateJoined { get; set; }
            public string gender { get; set; }
            public string groupName { get; set; }
            public string bloodType { get; set; }
            public string licenceNumber { get; set; }
            public string driverUniqueId { get; set; }
            public int groupId { get; set; }
            public string emergencyContactName { get; set; }
            public string emergencyContactRelationship { get; set; }
            public string emergencyContactPhone1 { get; set; }
            public string licenseExpiryDate { get; set; }
            public string licenseState { get; set; }
            public int unitId { get; set; }
            public int rfTagId { get; set; }
        }
        public class AssignDriverRequestBody
        {
            public int unitId { get; set; }
            public int driverId { get; set; }
        }
        public class AssignDriversToGrpRequestBody
        {
            public int[] driverIds { get; set; }
            public int groupId { get; set; }
        }
        public class DeleteDriversRequestBody
        {
            public int[] driverIds { get; set; }
        }
        public class EditVehicleGroupBody
        {
            public string groupName { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int? groupId { get; set; }

        }
    }
}
