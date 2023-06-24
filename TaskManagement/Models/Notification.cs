using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
   
           public class Notification
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public int UserId { get; set; }
            public User User { get; set; }
        }

        public enum TaskStatus
        {
            Todo,
            InProgress,
            Done
        }

        public enum TaskPriority
        {
            High,
            Medium,
            Low
        }


    }
