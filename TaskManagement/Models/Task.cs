using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Models;

namespace TaskManagement.Models
{
    public class Task
    {

        public ICollection<Task> AssignedTasks { get; set; } = new List<Task>();
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Notification> Notifications { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser{ get; set; }
        
    }
}