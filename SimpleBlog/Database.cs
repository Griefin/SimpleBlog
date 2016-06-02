using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;
using System.Web;

namespace SimpleBlog
{
  public static class Database
  {
    public static ISession Session
    {
      get
      {
        // if casting fail, it will throw exception
        // e.g. when someone referencing it and the session has not been initialized or not the correct type of object
        return (ISession)HttpContext.Current.Items[SessionKey]; 
      }
    }

    private const string SessionKey = "SimpleBlog.Database.SessionKey"; // unique key
    private static NHibernate.ISessionFactory _sessionFactory;

    public static void Configure()
    {
      var config = new Configuration();

      // configure connection string
      config.Configure(); // refer to web.config for the setting

      // add mapping
      var mapper = new ModelMapper();
      mapper.AddMapping<UserMap>();
      config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

      // create session factory
      _sessionFactory = config.BuildSessionFactory();
    }

    public static void OpenSession()
    {
      HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
    }

    public static void CloseSession()
    {
      // if casting fail, it will NOT throw exception
      // e.g. the session were never open in a request even if the close session is invoke
      //      example: you want to make sure that requesting for a file or image from the server is not resulting of opening database connection
      var session = HttpContext.Current.Items[SessionKey] as ISession; 


      if (session != null)
        session.Close();
      HttpContext.Current.Items.Remove(SessionKey);
    }
  }
}