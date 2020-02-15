using IAC.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAC.BL
{
    public class ReportGenerator
    {
        private AircraftRepository _aircraftRepository;
        private AircraftModelRepository _aircraftModelRepository;
        private CompanyRepository _companyRepository;
        private CountryRepository _countryRepository;
        public ReportGenerator(AircraftRepository aircraftRepository,
            AircraftModelRepository aircraftModelRepository,
            CompanyRepository companyRepository,
            CountryRepository countryRepository)
        {
            _aircraftRepository = aircraftRepository;
            _aircraftModelRepository = aircraftModelRepository;
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
        }

        public List<ReportItem> GenerateReportAircraftInEurope()
        {
            List<Aircraft> lektuvai = _aircraftRepository.Retrieve();
            List<ReportItem> ataskaita = new List<ReportItem>();
            
            foreach (var vienasLektuvas in lektuvai)
            {
                Company lektuvoKompanija = _companyRepository.Retrieve(vienasLektuvas.CompanyId);
                Country lektuvoSalis = _countryRepository.Retrieve(lektuvoKompanija.CountryId);
                AircraftModel lektuvoModelis = _aircraftModelRepository.Retrieve(vienasLektuvas.ModelId);
                if (lektuvoSalis.Continent == "Europe")
                {
                    ReportItem eilute = new ReportItem();
                    eilute.AircraftTailNumber = vienasLektuvas.TailNumber;
                    eilute.ModelNumber = lektuvoModelis.Number;
                    eilute.ModelDescription = lektuvoModelis.Description;
                    eilute.OwnerCompanyName = lektuvoKompanija.Name;
                    eilute.CompanyCountryCode = lektuvoSalis.Code;
                    eilute.CompanyCountryName = lektuvoSalis.Name;
                    eilute.BelongsToEU = lektuvoSalis.BelongsToEU;
                    ataskaita.Add(eilute);
                }
            }
            return ataskaita;
        }

    }
}
