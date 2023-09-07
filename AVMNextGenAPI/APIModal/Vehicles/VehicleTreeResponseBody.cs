using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI
{
    public class VehicleTreeResponseBody
    {

        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public int groupId { get; set; }
        public int unitId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public string unitName { get; set; }
        public string driverName { get; set; }
        public int fleetId { get; set; }
        public string vehicleRego { get; set; }
        public string vehicleId { get; set; }
        public float speed { get; set; }
        public string address { get; set; }
        public DateTime utcTime { get; set; }
        public string headStr { get; set; }

    }
    public class VehicleGroupedResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public Vehicle[] vehicles { get; set; }
    }

    public class GetOdoValueResponseBody
    {
        public float odoKm { get; set; }
        public float engineHours { get; set; }
    }

    public class Vehicle
    {
        public int unitId { get; set; }
        public string unitName { get; set; }
        public int fleetId { get; set; }
        public string vehicleRego { get; set; }
        public string vehicleId { get; set; }
        public int vehicleStatusFlag { get; set; }
        public string driverName { get; set; }
        public DateTime utcTime { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string address { get; set; }
        public float heading { get; set; }
        public string headStr { get; set; }
        public float speed { get; set; }
        public bool ign { get; set; }


    }

    public class ManageVehiclesResponseBody
    {
        public int? unitId { get; set; }
        public int? trackerId { get; set; }
        public string? department { get; set; }
        public int? departmentId { get; set; }
        public int? classTypeId { get; set; }
        public int? thresholdTemplateId { get; set; }
        public string? vehicleId { get; set; }
        public string? vehicleName { get; set; }
        public string? make { get; set; }
        public string? manufacturer { get; set; }
        public string? model { get; set; }
        public string? type { get; set; }
        public int? year { get; set; }
        public string? registration { get; set; }
        public string? licensesRequired { get; set; }
        public string? chassisVin { get; set; }
        public string? engineNumber { get; set; }
        public string? vehicleCategory { get; set; }
        public string? group { get; set; }
        public int? groupId { get; set; }
        public int? operatingHours { get; set; }
        public string? operatingHoursName { get; set; }
        public string? timeZone { get; set; }
        public int? driverId { get; set; }
        public string? driverName { get; set; }
        public string? serialNumber { get; set; }
        public bool? isCalibratingOdo { get; set; }
        public int? odometerReading { get; set; }
        public int? engHoursReading { get; set; }
        public string? odometerReadingDateUtc { get; set; }
        public bool? isCalibratingEngHours { get; set; }
        public int? engHoursReadingSeconds { get; set; }
        public string? engHoursReadingDateUtc { get; set; }
    }

    public class VehicleStatusByUserName
    {
        public int unitId { get; set; }
        public string unitName { get; set; }
        public int fleetId { get; set; }
        public DateTime utcTime { get; set; }
        public string tzInfo { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public float speed { get; set; }
        public float heading { get; set; }
        public string headStr { get; set; }
        public string address { get; set; }
        public int driverId { get; set; }
        public string driverName { get; set; }
        public string driverStatus { get; set; }
        public string vehId { get; set; }
        public string rego { get; set; }
        public string contactPhone { get; set; }
        public float odoKm { get; set; }
        public float engineHours { get; set; }
        public string status { get; set; }
        public string gpsState { get; set; }
        public float lastStopLat { get; set; }
        public float lastStopLon { get; set; }
        public string lastStopAddress { get; set; }
        public float lastStopDuration { get; set; }
        public DateTime lastStopTime { get; set; }
        public string terminalState { get; set; }
        public string run { get; set; }
        public bool ign { get; set; }
        public DateTime? alarmTimeUtc { get; set; }
        public string? lights { get; set; }
        public string? power { get; set; }
        public string? backupPower { get; set; }
        public int? vehicleStatusFlag { get; set; }

    }

    public class VehicleGroupResponseBody
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupColor { get; set; }
        public int unitCount { get; set; }
    }
    public class GetVehicleByIdResponse
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public string groupColor { get; set; }
    }


    public class VehicleContactResponseBody
    {
        public int contactGroupId { get; set; }
        public string shortName { get; set; }
        public string fullName { get; set; }
        public string comments { get; set; }
    }

    public class VehicleContactUnitIdResponseBody
    {
        public int contactGroupId { get; set; }
        public string contactGroupShortName { get; set; }
        public string warning { get; set; }
    }

    public class FindNowResponseBody
    {
        public bool success { get; set; }
        public string error { get; set; }
        public string feedback { get; set; }
        public string _ref { get; set; }
    }

    public class HistoryResponseBody
    {
        public Data data { get; set; }
        public Alertsinfo[] alertsInfo { get; set; }
    }

    public class Data
    {
        public int[] boundingBoxes { get; set; }
        public Crs crs { get; set; }
        public string type { get; set; }
        public Feature[] features { get; set; }
    }

    public class Crs
    {
        public int type { get; set; }
    }

    public class Feature
    {
        public int[] boundingBoxes { get; set; }
        public Crs crs { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }


    public class Alertsinfo
    {
        public Tripdates tripDates { get; set; }
        public string entityName { get; set; }
        public string alertDescription { get; set; }
        public DateTime alertTime { get; set; }
        public string alertLocation { get; set; }
        public int lat { get; set; }
        public int _long { get; set; }
        public int driverId { get; set; }
        public bool alert { get; set; }
        public int speed { get; set; }
        public string uniqueString { get; set; }
        public int dir { get; set; }
        public bool ign { get; set; }
        public string entityDisplayType { get; set; }
    }

    public class Tripdates
    {
        public DateTime tripStartTime { get; set; }
        public DateTime tripEndTime { get; set; }
    }

    public class VehicleAlertsResponseBody
    {
        public int contact { get; set; }
        public Alert[] alerts { get; set; }
    }

    public class Alert
    {
        public int id { get; set; }
        public int order { get; set; }
        public string name { get; set; }
        public string helpText { get; set; }
        public Alertsincluded[] alertsIncluded { get; set; }
        public bool isChecked { get; set; }
    }

    public class Alertsincluded
    {
        public string alertName { get; set; }
        public Subalert[] subAlerts { get; set; }
    }

    public class Subalert
    {
        public int subAlertId { get; set; }
        public string subAlertName { get; set; }
    }


}
