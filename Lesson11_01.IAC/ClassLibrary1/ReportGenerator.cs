using System;
using System.Collections.Generic;
using System.Text;
using IAC.BL.Repositories;
using System.Threading.Tasks;


namespace IAC
{
	public class ReportGenerator
	{
		private AircraftRepository aircraftRepository;
		private CompanyRepository companyRepository;
		private CountryRepository countryRepository;
		private AircraftModelRepository aircraftModelRepository;

		public ReportGenerator(AircraftRepository aircraftRepository, CompanyRepository companyRepository, CountryRepository countryRepository, AircraftModelRepository aircraftModelRepository)
		{
			this.aircraftRepository = aircraftRepository;
			this.companyRepository = companyRepository;
			this.countryRepository = countryRepository;
			this.aircraftModelRepository = aircraftModelRepository;
		}

		List<ReportItem> reportItem = new List<ReportItem>();
		public List<ReportItem> GenerateReportAircraftInEurope()
		{
			List<Aircraft> aircrafts = aircraftRepository.Retrieve();
			foreach (var item in aircrafts)
			{
				Company company = companyRepository.Retrieve(item.CompanyId);
				Country country = countryRepository.Retrieve(company.CountryId);
				string continent = country.Continent;
				if (continent == "Europe")
				{
					reportItem.Add(new ReportItem(item.TailNumber, aircraftModelRepository.Retrieve(item.ModelId).Number, aircraftModelRepository.Retrieve(item.ModelId).Description, company.Name, country.Code, country.Name, country.BelongsToEU));
				}
			}
			return reportItem;
		}
	}
}
