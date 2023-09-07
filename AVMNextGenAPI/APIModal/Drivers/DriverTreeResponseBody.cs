using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Drivers
{
    public class DriverTreeResponseBody
    {
        public string tzInfo { get; set; }
        public object vehicleName { get; set; }
        public int unitId { get; set; }
        public int driverId { get; set; }
        public string driverShortName { get; set; }
        public string driverContactPhone { get; set; }
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public string address { get; set; }
        public DateTime? utcTime { get; set; }
        public bool? isChecked { get; set; }
    }


    public class DriverGroupsResponsebody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public int driverCount { get; set; }

    }
    public class CreateDriverResponsebody
    {
        public int id { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public string feedback { get; set; }
        public string _ref { get; set; }

    }

    public class DriverGroupedResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public Driver[] drivers { get; set; }
    }

    public class Driver
    {
        public int driverId { get; set; }
        public string driverShortName { get; set; }
        public string driverContactPhone { get; set; }
        public string address { get; set; }
        public DateTime utcTime { get; set; }
        public string tzInfo { get; set; }
    }

    public class DriverByGroupIdResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public int driverCount { get; set; }
        public Driverlist[] driverList { get; set; }
    }

    public class Driverlist
    {
        public int driverId { get; set; }
        public string driverShortName { get; set; }
        public string driverContactPhone { get; set; }
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public string address { get; set; }
        public DateTime utcTime { get; set; }
        public string tzInfo { get; set; }
        public string vehicleName { get; set; }
        public int unitId { get; set; }
        public bool? isChecked { get; set; }
    }

    public class GetDriverByIdResponseBody
    {
        public int driverId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone1 { get; set; }
        public string email1 { get; set; }
        public string address1 { get; set; }
        public string? address2 { get; set; }
        public string nationality { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? dateJoined { get; set; }
        public string gender { get; set; }
        public string bloodType { get; set; }
        public string licenceNumber { get; set; }
        public string driverUniqueId { get; set; }
        public int groupId { get; set; }
        public string emergencyContactName { get; set; }
        public string emergencyContactRelationship { get; set; }
        public string emergencyContactPhone1 { get; set; }
        public DateTime? licenseExpiryDate { get; set; }
        public string licenseState { get; set; }
        public int? unitId { get; set; }
        public int rfTagId { get; set; }
        public string? unitName { get; set; }
        public string groupName { get; set; }
    }

}
