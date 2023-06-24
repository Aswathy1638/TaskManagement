using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Task> AssignedTask { get; set; }
        public object AssignedTasks { get; internal set; }
    }
}
