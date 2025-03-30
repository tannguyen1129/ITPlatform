using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace BusinessObjects
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();

            // CHỖ NÀY bạn đặt đúng chuỗi kết nối SQL Server
            optionsBuilder.UseNpgsql("Host=dpg-cvkit7odl3ps738k02v0-a.singapore-postgres.render.com;Port=5432;Database=itplatform_db_d2wu;Username=itplatform_db_d2wu_user;Password=hqsAKQ1gfaxgYDtWSi9BbBeKV3WRKgMl;SSL Mode=Require;Trust Server Certificate=true");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
