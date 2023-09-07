using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.DashCam
{
    public class DashCamResponseBody
    {
        public class DashCamStorageResponseBody
        {
            public string data { get; set; }
            public object storage { get; set; }
            
        }
        public class getDashCamResponseBody
        {
            public string recordings { get; set; }
            public string alarmHistory { get; set; }

        }
        public class getDashCamVehdetailsResponseBody
        {
            public string videoLost { get; set; }
            public string motionDection { get; set; }
            public string videoMask { get; set; }
            public string input { get; set; }
            public string overSpeed { get; set; }
            public string lowSpeed { get; set; }
            public string urgency { get; set; }

            public int id { get; set; }
            public string name { get; set; }

            public string monthlyDataLimit { get; set; }
            public double dailyDataLimit { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public double dataUsedByMonth { get; set; }
            public double dataUsedByday { get; set; }

            public string cost { get; set; }

            public string x { get; set; }
            public string y { get; set; }
            public string z { get; set; }
            public string tilt { get; set; }
            public string hit { get; set; }

            public string deviceID { get; set; }
            public string nodeID { get; set; }
            public string dtu { get; set; }
            public Location location { get; set; }
            public Gsensor gsensor { get; set; }
            public Module module { get; set; }
            public Fuel fuel { get; set; }
            public Mobile mobile { get; set; }
            public Wifi wifi { get; set; }
            public List<Storage> storage { get; set; }
            public Alarm alarm { get; set; }
            public Temp temp { get; set; }
            public Mileage mileage { get; set; }

            public string mode { get; set; }
            public string dtu { get; set; }
            public string direct { get; set; }
            public string satellites { get; set; }
            public string speed { get; set; }
            public string altitude { get; set; }
            public string precision { get; set; }
            public string longitude { get; set; }
            public string latitude { get; set; }

            public string todayDay { get; set; }
            public string total { get; set; }

            public string type { get; set; }
            public string strength { get; set; }

            public string mobile { get; set; }
            public string location { get; set; }
            public string wifi { get; set; }
            public string gsensor { get; set; }
            public string record { get; set; }

            public string guid { get; set; }
            public string deviceno { get; set; }
            public string devicename { get; set; }
            public string devicetype { get; set; }
            public List<Channel> channels { get; set; }
            public string sim { get; set; }
            public string streamserverid { get; set; }
            public string storageserverid { get; set; }
            public string gatewayserverid { get; set; }
            public string fleetid { get; set; }
            public string driverid { get; set; }
            public string engineno { get; set; }
            public string chassisno { get; set; }
            public string plateno { get; set; }
            public string identiyno { get; set; }
            public string vehicletype { get; set; }
            public int isshared { get; set; }
            public string sharedobj { get; set; }
            public object voiceFilePath { get; set; }
            public string deviceModel { get; set; }
            public string appVersion { get; set; }
            public string nodeGuid { get; set; }
            public string nodeName { get; set; }
            public string wifidlserverid { get; set; }
            public string fileserverid { get; set; }
            public StorageAndDataStatusDto storageAndDataStatusDto { get; set; }
            public LastStatusJson lastStatusJson { get; set; }
            public bool ignitionOn { get; set; }
            public string location { get; set; }

            public int deviceIndex { get; set; }
            public double totalStorage { get; set; }
            public double freeStorage { get; set; }
            public int oldRecordingsCount { get; set; }
            public int newRecordingsCount { get; set; }
            public string index { get; set; }
            public string status { get; set; }
            public string total { get; set; }
            public string free { get; set; }

            public Data data { get; set; }
            public List<Storage> storage { get; set; }

            public string insideTemp { get; set; }
            public string outsideTemp { get; set; }
            public string engineerTemp { get; set; }
            public string deviceTemp { get; set; }
            public string insideHumidity { get; set; }
            public string outsidHumidity { get; set; }
            public string strength { get; set; }
            public string ip { get; set; }
            public string mask { get; set; }
            public string gateway { get; set; }
            public string ssid { get; set; }
        

    }
        public class getDashCamSetAlertResponseBody
        {
            public string date { get; set; }

        }
        public class getDashCamAlarmListResponseBody
        {
            public int alarmCode { get; set; }
            public string alarmName { get; set; }

        }
    }
}
