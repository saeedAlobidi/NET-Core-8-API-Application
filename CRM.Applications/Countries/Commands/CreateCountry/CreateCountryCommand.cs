
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateCountry;

public record CreateCountryCommand(string name,string countryCode,string languageCode):IRequest<ErrorOr<Countries>>;

//public record CreateCountryCommand(List<CountryCommand> CountryCommands):IRequest<ErrorOr<Countries>>;
