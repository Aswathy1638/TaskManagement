using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Data;

namespace TaskManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        public class NotificationController
        {
            private readonly ApplicationDbContext _context;

            public NotificationController(ApplicationDbContext context)
            {
                _context = context;
            }

            public void AddNotification(Notification notification)
            {
                _context.Notifications.Add(notification);
                _context.SaveChanges();
            }
        }

    }
}
