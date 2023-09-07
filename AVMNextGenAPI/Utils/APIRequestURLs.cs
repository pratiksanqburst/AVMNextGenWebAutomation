using AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Roles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.Utils
{
    public class APIRequestURLs
    {
        #region Vehicles
        public string getVehicleByUsername = "api/vehicles/GetVehiclesByUsername";

        public string getVehicles = "api/Vehicles/GetVehicles";

        public string getVehiclesGrouped = "api/Vehicles/GetVehiclesGrouped";

        public string getVehicleStatusByUserName = "api/Vehicles/GetVehicleStatusByUserName";

        public string getVehicleunitid = "api/vehicles/{unitId}";

        public string vehiclegroups = "api/Vehicles/Groups";

        public string vehiclegroupsgroupId = "api/Vehicles/Groups/{groupId}";

        public string vehicles = "api/vehicles";

        public string getOperatingHours = "api/Vehicles/GetOperatingHours";

        public string getOdometerAndEngineHours = "api/Vehicles/GetOdometerAndEngineHours";

        public string Addvehiclestogroup = "api/vehicles/addvehiclestogroup";

        public string contactGroups = "api/Vehicles/ContactGroups";

        public string findNowVehicles = "api/Vehicles/FindNowVehicle";

        public string vehicleHistoryDetails = "api/vehicles/VehicleHistoryDetails";

        public string VehicleAlertUnitid = "api/Vehicles/Alerts/{unitId}";

        public string contactGroupunitid = "api/Vehicles/ContactGroups/{unitId}";

        #endregion

        #region Alarms

        public string getAlarmsByUsername = "api/alarms/GetAlarmsByUsername";

        public string clearAlarm = "api/alarms/ClearAlarm";
        
        #endregion

        #region Location

        public string getLocationsByUsername = "api/locations/GetLocationsByUsername";

        public string LocationGroups = "api/Locations/Groups";

        public string Locationgroups = "api/locations/groups";

        public string locationGroupId = "api/Locations/Groups/{groupID}";

        public string locationTypes = "api/Locations/LocationTypes";

        public string locationTypes1 = "api/Locations/LocationTypes/1/10";

        public string locationTypeId = "api/Locations/LocationTypes/{typeId}";

        public string locationType = "api/locations/LocationType";

        public string locationTypesIcon = "api/Locations/LocationTypes/Icons";

        public string createLocation = "api/Locations/CreateLocation";

        public string getLocations = "api/Locations/GetLocations";

        public string getLocationsGrouped = "api/Locations/GetLocationsGrouped";

        public string getLocationInGroupWithFeatures = "api/Locations/GetLocationsInGroupWithFeatures";

        public string getLocationGroupIdGroup = "api/Locations/GetLocationsByGroupId?groupId={groupId}";

        public string getLocationgroupId1 = "api/Locations/{groupId}/1/10";

        public string Addlocationgroup = "api/locations/addlocationtogroup";

        public string updateLocation = "api/Locations/UpdateLocation";

        public string locationId = "api/Locations/{locId}";

        public string deleteLocation = "api/Locations/DeleteLocations";

        public string locationTypeslocTypeId = "api/Locations/LocationTypes/{locTypeId}";

        #endregion

        #region Client

        public string newClient = "api/Clients/NewClient";

        public string getClientsByUserName = "api/Clients/GetClientsByUserName";

        public string getClientVehiclesAndDriversGrouped = "api/Clients/GetClientVehiclesAndDriversGrouped";

        public string updateClient = "api/Clients/UpdateClient";

        public string updateSignalRAlertNotification = "api/Clients/UpdateSignalRAlertNotification";

        public string updateSignalRAlarmNotification = "api/Clients/UpdateSignalRAlarmNotification";

        public string updateAccountLockout = "api/Clients/UpdateAccountLockout";

        public string clientsID = "api/Clients/{clientId}";

        public string updatePassword = "api/Clients/UpdatePassword";

        public string initialScript = "api/Clients/InitialScript";

        #endregion

        #region Alert

        public string getAlertsByUsername = "api/alerts/GetAlertsByUsername";

        public string alertid = "api/Alerts/{alertID}";

        public string alertDelete = "api/alerts/delete";

        #endregion

        #region Contacts

        public string contactgroups = "api/ContactGroups";

        public string ContactGroupUsages = "/api/ContactGroups/ContactGroupUsages/{groupId}";

        public string contactGroupID = "api/ContactGroups/{groupID}";

        #endregion

        #region OperationalHours

        public string createOperatingHours = "api/operationalHours/CreateOperatingHours";

        public string OperationalHours = "api/operationalHours";

        public string updateOperatingHour = "api/operationalHours/UpdateOperatingHour";

        public string OperatingHoursid = "api/OperationalHours/{id}";

        #endregion


        #region Trips

        public string getTrips = "api/trips/GetTrips";

        public string tripsapi = "api/trips";

        public string updateMultipleTrips = "api/trips/UpdateMultipleTrips";

        #endregion

        #region Roles

        public string roles = "api/Roles";

        public string updateRole = "api/roles/UpdateRoleName/{roleID}";

        public string updateRolerights = "api/roles/UpdateRoleRights/{roleID}";

        public string roleId = "/api/roles/{roleId}";

        public string getUserAccessrights = "api/Roles/GetUserAccessRights";


        #endregion

        #region UserSettings

        public string settingName = "api/Users? settingName = { settingsName }";

        public string userS = "api/Users";


        #endregion

        #region Services

        public string getServiceById = "api/Services/GetServiceById";

        public string getLastService = "api/Services/GetLastService/{vehicleId}";

        public string getServices = "api/Services/GetServices";

        public string Services = "api/services";

        public string ServiceId = "api/services/{serviceId}";

        public string serviceTypes = "api/Services/ServiceTypes";

        public string ServiceReading = "api/Services/ServiceReading/{serviceId}";



        #endregion


        #region MapSettings

        public string MapSettings = "api/mapsettings";


        #endregion


        #region ZoomPresets

        public string ZoomPreset = "api/zoompresets";

        public string ZoomPresetS = "api/ZoomPresets";


        #endregion


        #region Drivers

        public string getDriversByUsername = "api/drivers/GetDriversByUsername";

        public string getvehiclestatusbyusername = "api/Vehicles/GetVehicleStatusByUserName";

        public string driverGroups = "api/drivers/Groups";

        public string getDriverGroups = "api/Drivers/GetDriverGroups";

        public string createdriver = "api/drivers/CreateDriver";

        public string getDrivers = "api/Drivers/GetDrivers";

        public string getDriversGrouped = "api/Drivers/GetDriversGrouped";

        public string getDriversByGroupID = "api/drivers/GetDriversByGroupId/{groupId}/1/20";

        public string assignVehicleToDriver = "api/drivers/AssignVehicleToDriver";

        public string updatedriver = "api/drivers/UpdateDriver";
       
        public string DriversdriverId = "api/Drivers/{driverId}";

        public string assignDriverstogroup = "api/drivers/AssignDriversToGroup";

        public string deleteDrivers = "api/drivers/DeleteDrivers";

        public string DriversGroupsgroupID = "api/drivers/Groups/{groupId}";

        public string getDrivergroupBygroupID = "api/Drivers/GetDriverGroupByGroupId/{groupId}";

        public string DriversgroupsGroupID = "api/drivers/Groups/{groupID}";


        #endregion

        #region DashCam

        public string dashStatus = "api/Dashcam/Status";

        public string DashcamStoragestatus = "api/Dashcam/StorageStatus/:unitId";

        public string createvideoplayback = "api/Dashcam/CreateVideoPlaybackRequest";

        public string getdashcamRercordings = "api/Dashcam/GetDashcamRecordings";

        public string Dashcamvehicledetails = "api/Dashcam/VehicleDetails/:unitId";

        public string dashcamSetdataUsageAlert = "api/Dashcam/SetDataUsageAlert";

        public string dashcamAlarmlist = "api/Dashcam/AlarmList";

        #endregion

        #region HereMap

        public string HeremapSearchLocations = "api/HereMap/SearchLocations";

        public string HereMapgetlocationinfo = "api/HereMap/GetLocationInfo";

        public string HereMapDrawroute = "api/HereMap/DrawRoute";



        #endregion

        #region FleetManager/preference

        public string Preferencesave = "api/FleetManager/preference";

        public string prefrenceget = "api/FleetManager/preference";




        #endregion


        #region ServiceSchedule

        public string saveServiceschedule = "api/ServiceSchedule/SaveServiceSchedule";

        public string saveServicescheduleList = "api/ServiceSchedule/SaveServiceScheduleList";

        public string updateServiceSchedule = "api/ServiceSchedule/UpdateServiceSchedule";

        public string updateServiceScheduleList = "api/ServiceSchedule/UpdateServiceScheduleList";

        public string getServiceScheduleByUnitId = "api/ServiceSchedule/GetServiceScheduleByUnitId?unitId=52";


        #endregion



        #region Version

        public string versionAPI = "api/Version";

        public string appVersion = "api/Version/AppVersion";




        #endregion



    }

}