using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Trips
{
    public class TripsResponseBody
    {



        public int assignedTripCount { get; set; }
        public int unAssignedTripCount { get; set; }
        public Trip[] trips { get; set; }

    }
    public class Trip
    {
        public float km { get; set; }
        public string startLocation { get; set; }
        public string stopLocation { get; set; }
        public int unitId { get; set; }
        public object driverName { get; set; }
        public int tripId { get; set; }
        public int driverId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isBusiness { get; set; }
        public string reason { get; set; }
    }


    public class SingleTripResponseBody
    {
        public int tripId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public bool isBusiness { get; set; }
        public double km { get; set; }
        public string startLocation { get; set; }
        public string stopLocation { get; set; }
        public string reason { get; set; }
        public int unitId { get; set; }
        public string unitName { get; set; }
        public string vehicleId { get; set; }
        public Point[] points { get; set; }
    }

    public class Point
    {
        public int recordId { get; set; }
        public string locationTime { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }


}
