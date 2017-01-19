using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ContactMySQL.Models
{
    // ApplicationUser クラスにプロパティを追加することでユーザーのプロファイル データを追加できます。詳細については、http://go.microsoft.com/fwlink/?LinkID=317594 を参照してください。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // authenticationType が CookieAuthenticationOptions.AuthenticationType で定義されているものと一致している必要があります
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // ここにカスタム ユーザー クレームを追加します
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ContactMySQL.Models.Bunrui> Bunruis { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.Busho> Bushos { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.Chiiki> Chiikis { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.Hojin> Hojins { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.Jyuyodo> Jyuyodoes { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.SystemMaster> SystemMasters { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.Tantosha> Tantoshas { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.ToiawaseRireki> ToiawaseRirekis { get; set; }

        public System.Data.Entity.DbSet<ContactMySQL.Models.ShafukuUser> ShafukuUsers { get; set; }
    }
}