using CRM.Domain.Common;
using ErrorOr;

namespace CRM.Domain.Leads;

//plz dont use Guid is not sufficiant for database
public class Countries : TranslatableEntity<int, TranslatedCountries, Countries>
{

    public string CountryCode { get; set; }

    public void build(TranslatedCountries translatedCountries, string CountryCode)
    {
        this.CountryCode = CountryCode;

        Translations.Add(translatedCountries);
    }
}



public class TranslatedCountries : TranslatedEntity<int, Countries, TranslatedCountries>
{

    public string Name { get; set; }


    public TranslatedCountries(string name,string languageCode )
    {
        this.Name = name;
        this.LanguageCode=languageCode;

    }

}


