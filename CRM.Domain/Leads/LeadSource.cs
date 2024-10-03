using CRM.Domain.Common;
using ErrorOr;

namespace CRM.Domain.Leads;

//plz dont use Guid is not sufficiant for database
public class LeadSource : TranslatableEntity<int, TranslatedLeadSource, LeadSource>
{


}



public class TranslatedLeadSource : TranslatedEntity<int, LeadSource, TranslatedLeadSource>
{


    public string name { get; set; }
    public TranslatedLeadSource(string name)
    {
        this.name = name;

    }

}


