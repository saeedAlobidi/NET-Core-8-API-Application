using CRM.Domain.Common;
using ErrorOr;

namespace CRM.Domain.Leads;

//plz dont use Guid is not sufficiant for database
public class LeadStatus : TranslatableEntity<int, TranslatedLeadStatus, LeadStatus>
{


}



public class TranslatedLeadStatus : TranslatedEntity<int, LeadStatus, TranslatedLeadStatus>
{


public string name { get; set; }

    public TranslatedLeadStatus(string name)
    {
        this.name = name;
    }
}


