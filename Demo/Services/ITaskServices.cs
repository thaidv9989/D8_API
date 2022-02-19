using Demo.Models;

namespace Demo.Services
{
    public interface ITaskServices
    {
        public List<TasksModel> GetAll();
        public TasksModel? GetOne(Guid id);

        public TasksModel Add(TasksModel tasksModel);    

        public TasksModel? Update(TasksModel tasksModel);

        void Delete(Guid id);

        List<TasksModel> Add(List<TasksModel> tasks);

        void Delete(List<Guid> ids);   
    }
}
