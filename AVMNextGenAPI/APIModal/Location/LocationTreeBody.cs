using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenAPI.APIModal.Location
{
    public class LoginBody
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class CreateLocationRequestBody
    {
        public int groupId { get; set; }
        public string? groupName { get; set; }
        public int locationId { get; set; }
        public string locationName { get; set; }
        public string locationDescription { get; set; }
        public int locationTypeId { get; set; }
        public string locationTypeCode { get; set; }
        public string locationTypeName { get; set; }
        public Featuredata? featureData { get; set; }
        public int featureShape { get; set; }
        public int locationRadiusMeters { get; set; }
        public int? total { get; set; }
    }

    public class LocationsSearchRequestBody
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string searchText { get; set; }
        public int groupId { get; set; }
    }

    public class Featuredata
    {
        public double[]? bbox { get; set; }
        public Crs? crs { get; set; }
        public string? id { get; set; }
        public Geometry? geometry { get; set; }
        public Properties? properties { get; set; }
        public string? type { get; set; }

    }


    public class Geometry
    {
        public double[]? coordinates { get; set; }
        public string? type { get; set; }
    }

    public class Properties
    {
        public int locationRadius { get; set; }
        public string? additionalProp1 { get; set; }
        public string? additionalProp2 { get; set; }
        public string? additionalProp3 { get; set; }
    }
}
