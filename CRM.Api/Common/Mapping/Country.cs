using CRM.Api.Controllers.Contracts;

using CRM.Domain.Leads;
using CRM.Leads.Commands.CreateCountry;
using CRM.Leads.Commands.CreateLead;

namespace CRM.Api.Controllers.Common.Mapping;

public static class Country
{


    public static CreateCountryCommand MapToCountriesCommand(this CreateCountryCommand request)
    {
        return new CreateCountryCommand(name: request.name, countryCode: request.countryCode, languageCode: request.languageCode);

    }


    public static CreateCountryResponse MapToResponse(this Countries countries)
    {
        return new CreateCountryResponse(id: countries.Id, name: countries.Translations.FirstOrDefault().Name, code: countries.CountryCode);

    }


}