

namespace CRM.Api.Common.Api;

public static class ApiEndpoints
{
  private const string ApiBase = "v1/api";

 public static class Users
  {
    private const string Base = $"{ApiBase}/Users";



    public const string Create = Base;
    public const string CreateRole = $"{Base}/Roles";
    public const string Get = $"{Base}/";
    public const string GetById = $"{Base}/{{id}}";
    public const string Login = $"{Base}/Login";
    public const string AssignRole = $"{Base}/AssignRole";
     

  }

  public static class Countries
  {
    private const string Base = $"{ApiBase}/Countries";
    public const string Create = Base;
    public const string Get = $"{Base}/";
    public const string GetById = $"{Base}/{{id}}";

  }

  public static class Leads
  {
    private const string Base = $"{ApiBase}/Leads";



    public const string Create = Base;
    public const string Get = $"{Base}/";
    public const string GetById = $"{Base}/{{id}}";

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
