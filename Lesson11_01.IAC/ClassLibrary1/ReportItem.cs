using System;
using System.Collections.Generic;
using System.Text;

namespace IAC
{
    public class ReportItem
    {
        public string AircraftTailNumber { get; set; }
        public string ModelNumber { get; set; }
        public string ModelDescription { get; set; }
        public string OwnerCompanyName { get; set; }
        public string CompanyCountryCode { get; set; }
        public string CompanyCountryName { get; set; }
        public bool? BelongsToEU { get; set; }

        public ReportItem(string aircraftTailNumber, string modelNumber, string modelDescription, string ownerCompanyName, string companyCountryCode, string companyCountryName, bool? belongsToEU)
        {
            AircraftTailNumber = aircraftTailNumber;
            ModelNumber = modelNumber;
            ModelDescription = modelDescription;
            OwnerCompanyName = ownerCompanyName;
            CompanyCountryCode = companyCountryCode;
            CompanyCountryName = companyCountryName;
            BelongsToEU = belongsToEU;
        }
    }

}
