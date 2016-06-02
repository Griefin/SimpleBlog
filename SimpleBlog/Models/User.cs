using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
  public class User
  {
    public virtual int Id { get; set; }
    public virtual string Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }
  }

  public class UserMap : ClassMapping<User>
  {
    public UserMap()
    {
      this.Table("users");

      this.Id(
        x => x.Id, 
        x => x.Generator(Generators.Identity)
      );

      this.Property(
        x => x.Username,
        x => x.NotNullable(true)
      );

      this.Property(
        x => x.Email,
        x => x.NotNullable(true)
      );

      this.Property(
        x => x.PasswordHash,
        x => {
          x.Column("password_hash");
          x.NotNullable(true);
        }
      );
    }
  }
}