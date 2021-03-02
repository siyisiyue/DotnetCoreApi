using Microsoft.EntityFrameworkCore;
namespace DotnetCoreApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
           : base(options)
        {
        }


        public DbSet<TodoItems> TodoItems { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<GanttTask> GanttTask { get; set; }
        public DbSet<GanttLine> GanttLine { get; set; }

        public DbSet<TableHead> TableHead { get; set; }
        public DbSet<ShuiNiHunLingTu> ShuiNiHunLingTu { get; set; }
        public DbSet<GangJingAnZhuang> GangJingAnZhuang { get; set; }
        public DbSet<PostionTemp> PostionTemp { get; set; }
        public DbSet<Relation> Relation { get; set; }

    }
}
