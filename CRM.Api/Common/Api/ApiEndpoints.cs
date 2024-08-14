

namespace CRM.Api.Common.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "v1/api";

    public static class Leads
    {
        private const string Base = $"{ApiBase}/Leads";


        
        public const string Create = Base;
        public const string Get = $"{Base}/";

         
    }

  public static class Services
    {
        private const string Base = $"{ApiBase}/Services";


        
        public const string Create = Base;
        public const string Get = $"{Base}/";

         
    }


  public static class Applications
    {
        private const string Base = $"{ApiBase}/Application";


        
        public const string Create = Base;
        public const string Get = $"{Base}/";

         
    }

}
