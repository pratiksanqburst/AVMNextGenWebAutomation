using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location
{

    public class LocationTreeResponseBody

    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string locationDescription { get; set; }
        public int locationTypeId { get; set; }
        public string locationTypeName { get; set; }
        public string locationTypeCode { get; set; }
        public string locationTypeIconUrl { get; set; }
        public string colorHex { get; set; }
        public bool? isChecked { get; set; }
    }


    public class LocationGroupsResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public int? locationCount { get; set; }
    }



    public class LocationTypesResponseBody
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public string icon { get; set; }
        public string colorHex { get; set; }
        public bool optionLogOnly { get; set; }
        public bool optionNotifyEntryExit { get; set; }
        public bool optionNotifyOnEntry { get; set; }
        public bool optionNotifyOnExit { get; set; }
        public int total { get; set; }
        public string iconUrl { get; set; }
    }

    public class CreateLocationTypeResponseBody
    {
        public bool success { get; set; }
        public string error { get; set; }
        public string feedback { get; set; }
        public string _ref { get; set; }
        public int id { get; set; }
    }

    public class LocationSearchKeyResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string locationDescription { get; set; }
        public int locationTypeId { get; set; }
        public Featuredata featureData { get; set; }
        public int featureShape { get; set; }
        public int locationRadiusMeters { get; set; }
        public string locationTypeName { get; set; }
        public string locationTypeColorHex { get; set; }
        public string? locationTypeCode { get; set; }
        public string? locationTypeIconUrl { get; set; }
        public int total { get; set; }
    }


    public class LocationsGroupedResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public Location[] locations { get; set; }
    }

    public class Location
    {
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string locationDescription { get; set; }
        public int locationTypeId { get; set; }
        public string locationTypeName { get; set; }
        public object featureData { get; set; }
        public int featureShape { get; set; }
    }


    public class LocationsWithGroupIdResponseBody
    {
        public Locationslist[] locationsList { get; set; }
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public int locationCount { get; set; }
    }

    public class Locationslist
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string locationDescription { get; set; }
        public int locationTypeId { get; set; }
        public string locationTypeName { get; set; }
        public string locationTypeCode { get; set; }
        public string locationTypeIconUrl { get; set; }
        public string colorHex { get; set; }
        public bool? isChecked { get; set; }
    }


}
