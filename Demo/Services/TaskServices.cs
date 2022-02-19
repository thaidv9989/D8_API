using Demo.Models;

namespace Demo.Services
{
    public class TaskServices : ITaskServices
    {
        private static readonly List<TasksModel> _tasks = new List<TasksModel>();
        public TasksModel Add(TasksModel tasksModel)
        {
            _tasks.Add(tasksModel);
            return tasksModel;
        }

        public List<TasksModel> Add(List<TasksModel> tasks)
        {
            _tasks.AddRange(tasks); 
            return tasks;   
        }

        public void Delete(Guid id)
        {
            var rs = _tasks.FirstOrDefault(t => t.Id == id);
            if (rs != null)
            {
                _tasks.Remove(rs);
            }

        }

        public void Delete(List<Guid> ids)
        {
            _tasks.RemoveAll(x => ids.Contains(x.Id));
        }

        public List<TasksModel> GetAll()
        {
            return _tasks;  
        }

        public TasksModel? GetOne(Guid id)
        {
            return _tasks.FirstOrDefault(x => x.Id == id);  
        }

        public TasksModel? Update(TasksModel tasksModel)
        {
            var rs = _tasks.FirstOrDefault(x => x.Id == tasksModel.Id);
            if (rs == null) return null;
            rs.Title = tasksModel.Title;
            rs.IsCompleted = tasksModel.IsCompleted;

            return rs;

        }
    }
}
