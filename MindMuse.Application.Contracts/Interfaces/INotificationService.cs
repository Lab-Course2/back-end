using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Application.Contracts.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface INotificationService
    {
        Task<object> CreateNotification(NotificationRequest request);
        Task<object> GetAllNotifications();
        Task<bool> CheckIfExist(NotificationRequest notificationRequest);
        Task<IEnumerable<object>> GetSpecificNotifications(string id);
        Task<OperationResult> DeleteNotification(IEnumerable<string> ids);
        Task<OperationResult> UpdateNotification(string id, NotificationRequest notificationRequest);
        Task<string> GetSpecificNotification(NotificationRequest notificationRequest);
    }
}