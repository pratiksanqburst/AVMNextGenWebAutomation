using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading.Tasks;
using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class LocationRequestBody:APIHelper
    {
        
        #region Properties
        static ResourceManager rm2 = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}", Assembly.GetExecutingAssembly());
        public static string userName = rm2.GetString("Username");
        public static string password = rm2.GetString("Password");
        public static string adminUser = rm2.GetString("AdminUser");
        public static string adminPassword = rm2.GetString("AdminPassword");
        public static string adminDev = rm2.GetString("AdminDev");
        public static string adminDevPassword = rm2.GetString("AdminDevPassword");
        static ResourceManager rm3 = new ResourceManager($"AVMNextGenWebAutomation.APITestData{environment}", Assembly.GetExecutingAssembly());
        public static string searchKey = rm3.GetString("Searchkey");
        #endregion
        public  LoginBody LoginrequestBody= new LoginBody ()
        {
            userName = adminUser,
            password =""
        };
        public LocationGroupsResponseBody LocationGroupsRequestBody = new LocationGroupsResponseBody()
        {
            groupId = -1,
            locationCount = 0,
            groupName = "random",
            description = "Automation description"
        };
        public LocationGroupsResponseBody LocationgroupsRequestBody = new LocationGroupsResponseBody()
        {
        groupId = 3,
        locationCount = 0,
        groupName = "random",
         description = "Automation description edited"
        };
        public LocationTypesBody LocationTypesRequestBody = new LocationTypesBody()
        {
             id = 0,
             name = "typename",
             description = "Automation description",
            code = "Automation code",
            toleranceMetres = 200,
            replaceAddressWithLocationName = true,
            duringVehicleOperatingHours = true,
             priority = 0,
            deleted = 0,
            icon = "PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPg0KICAgICAgICA8cGF0aCBkPSJNMCAwaDIwdjIwSDB6Ii8+DQogICAgICAgIDxwYXRoIGQ9Im0xMCAxNy40MTcgNC4xMjUtNC4xMjVhNS44MzMgNS44MzMgMCAxIDAtOC4yNSAwTDEwIDE3LjQxN3ptMCAyLjM1Nkw0LjY5NyAxNC40N2E3LjUgNy41IDAgMSAxIDEwLjYwNiAwTDEwIDE5Ljc3M3ptMC04Ljk0QTEuNjY3IDEuNjY3IDAgMSAwIDEwIDcuNWExLjY2NyAxLjY2NyAwIDAgMCAwIDMuMzMzem0wIDEuNjY3YTMuMzMzIDMuMzMzIDAgMSAxIDAtNi42NjcgMy4zMzMgMy4zMzMgMCAwIDEgMCA2LjY2N3oiIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyIvPg0KICAgIDwvZz4NCjwvc3ZnPg0K",
           colorHex = "29B6F6",
            optionLogOnly = false,
            optionNotifyEntryExit = true,
            optionNotifyOnEntry = false,
            optionNotifyOnExit = false,
            iconUrl = "https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg",
        };
        public LocationTypesBody LocationTypesrequestBody = new LocationTypesBody()
        {
          id = 2,
          name = "typeName",
          description = "Automation description edited",
          code = "Automation code edited",
           toleranceMetres = 100,
          replaceAddressWithLocationName = false,
           duringVehicleOperatingHours = false,
           priority = 0,
           deleted = 0,
           icon = "PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgICA8ZyBmaWxsPSJub25lIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiPg0KICAgICAgICA8cGF0aCBkPSJNMCAwaDIwdjIwSDB6Ii8+DQogICAgICAgIDxwYXRoIGQ9Im0xMCAxNy40MTcgNC4xMjUtNC4xMjVhNS44MzMgNS44MzMgMCAxIDAtOC4yNSAwTDEwIDE3LjQxN3ptMCAyLjM1Nkw0LjY5NyAxNC40N2E3LjUgNy41IDAgMSAxIDEwLjYwNiAwTDEwIDE5Ljc3M3ptMC04Ljk0QTEuNjY3IDEuNjY3IDAgMSAwIDEwIDcuNWExLjY2NyAxLjY2NyAwIDAgMCAwIDMuMzMzem0wIDEuNjY3YTMuMzMzIDMuMzMzIDAgMSAxIDAtNi42NjcgMy4zMzMgMy4zMzMgMCAwIDEgMCA2LjY2N3oiIGZpbGw9IiNGRkYiIGZpbGwtcnVsZT0ibm9uemVybyIvPg0KICAgIDwvZz4NCjwvc3ZnPg0K",
           colorHex = "29B6F6",
           optionLogOnly = true,
           optionNotifyEntryExit = false,
           optionNotifyOnEntry = false,
           optionNotifyOnExit = false,
           iconUrl = "https://avmnextgenstorage.blob.core.windows.net/location-types/location-type-icon-one.svg"
        };
        public AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location.CreateLocationRequestBody createLocationRequestBody = new APIModal.Location.CreateLocationRequestBody() //doubt
        {
            featureData = new AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location.Featuredata(),
            featureData.
           // APIModal.Location.Geometry featureData.geometry = new AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location.Geometry(),
            groupId = ,
            groupName = "",
            locationId = 0,
            locationDescription = "Test Automation desc",
            locationName ="locName",
            locationRadiusMeters = 100000,
            locationTypeCode = "",
            locationTypeName = "",
            locationTypeId = 3,
            featureShape = 2,
            featureData.geometry.type = "Point",
            featureData.geometry.coordinates = new double[2] { 127.133789, -23.624395 },
            featureData.type = "Feature"
        };
        public VehicleSearchBody VehicleSearchRequestBody = new VehicleSearchBody()
        {
        pageNumber = 1,
        pageSize = 10,
        searchText = searchKey
        };
        public VehicleSearchBody VehicleSearchrequestBody = new VehicleSearchBody()
        {
            pageNumber = 1,
            pageSize = 10,
            searchText = searchKey
        };
        public LocationsSearchRequestBody LocationsSearchrequestBody = new LocationsSearchRequestBody()
        {
        pageNumber = 1,
        pageSize = 10,
        searchText = searchKey,
        groupId = 5
        };
        public AddLocaTionsToGroupRequestBody AddLocaTionsToGrouprequestBody = new AddLocaTionsToGroupRequestBody()
        { 
            groupId = 5,
            locationIds = []
 
        };
        public CreateLocationRequestBody CreatelocationrequestBody = new CreateLocationRequestBody()
        {
            featureData = new Featuredata(),
        featureData.geometry = new Geometry(),
        featureData.properties = new Properties(),
        groupId = groupId,
        groupName = "",
        locationId = locId,
        locationDescription = "Test Automation desc edited",
        locationName = locName + "Edit",
        locationRadiusMeters = 120000,
        locationTypeCode = "",
        locationTypeName = "",
        locationTypeId = locTypeId,
        featureShape = 2,
        featureData.properties.locationRadius = 120000,
        featureData.geometry.type = "Point",
        featureData.geometry.coordinates = new double[2] { 127.133789, -23.624395 },
        featureData.bbox = new double[4] { 127.133789, -23.624395, 127.133789, -23.624395 },
        featureData.type = "Feature",

        };
        public DeleteLocationRequestBody DeletelocationRequestBody = new DeleteLocationRequestBody()
         {
        locationIds = new[] { locId1, locId2 }
         };
};

   





  

