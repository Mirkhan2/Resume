﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Services.Interfaces
{
    public interface IMessageService
    {
        Task<bool> CreateMessage(CreateMessageViewModel message);
        Task<List<CreateMessageViewModel>> GetAllMessages();
        Task<bool> DeleteMessage(long id);

    }
}
