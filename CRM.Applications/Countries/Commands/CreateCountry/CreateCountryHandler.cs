using CRM.Applications.Common.Interface;
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateCountry;

public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, ErrorOr<Countries>>
{


    private readonly ICountriesRepository _ICountriesRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCountryHandler(ICountriesRepository ICountriesRepository, IUnitOfWork unitOfWork)
    {
        _ICountriesRepository = ICountriesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Countries>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        Countries countries = await _ICountriesRepository.getAsync(request.countryCode, cancellationToken);

        countries = countries == null ? new Countries() : countries;
        countries.build(new TranslatedCountries(request.name, request.languageCode), request.countryCode);
          Console.Write("countries.Id"+countries.Id);
        if (countries.Id < 1)
             await _ICountriesRepository.AddAsync(countries,cancellationToken);
        await _unitOfWork.CommitChangesAsync();
        return countries;
    }

}





