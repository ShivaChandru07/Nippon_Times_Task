//using Microsoft.Extensions.DependencyInjection;
//using TaskReturn.DataBase;

//namespace TaskReturn.BusinessRepo
//{
//    public class TaskService : BackgroundService
//    {
//        private readonly IServiceScopeFactory mServiceScope;
//        public TaskService(IServiceScopeFactory serviceScope)
//        {
//            mServiceScope = serviceScope;
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                //using (var sc = mServiceScope.CreateScope())
//                //{
//                //    var Data = sc.ServiceProvider.GetRequiredService<TaskDBContext>();
//                //    foreach (var task in Data.Task.Where(x => x.Status == 0 && x.CreatedDate < x.CreatedDate.AddSeconds(180)).ToList())
//                //    {
//                //        task.ID = task.ID;
//                //        task.Name = task.Name;
//                //        task.CreatedDate = task.CreatedDate;
//                //        task.Status = 2;
//                //        task.ModifiedDate = DateTime.UtcNow;
//                //        task.TimeTaken = "NA";
//                //        Data.Task.Update(task);
//                //    }
//                //    await Task.Delay(TimeSpan.FromSeconds(180));
//                //    Data.SaveChanges();
//                //}
//            }
//        }
//    }
//}
