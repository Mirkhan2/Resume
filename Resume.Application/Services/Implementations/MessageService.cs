using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Security;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Message;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class MessageService : IMessageService
    {
        #region Constructor
        private readonly AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<bool> CreateMessage(CreateMessageViewModel message)
        {
            Message newMessage = new Message()
            {

                Email = message.Email.SanitizeText(),
                Name = message.Name.SanitizeText(),
                Text = message.Text.SanitizeText()
            };

            await _context.AddAsync(newMessage);
            await _context.SaveChangesAsync();

            return true;
        }

     

        //public async Task<List<CreateMessageViewModel>> GetAllMessages()
        //{
        //    List<MessageViewModel> messages = await _context.Messages
        //       .Select(m => new MessageViewModel()
        //       {
        //           Id = m.Id,
        //           Email = m.Email,
        //           Name = m.Name,
        //           Text = m.Text
        //       })
        //       .ToListAsync();

        //    return messages;

        //}
        public async Task<bool> DeleteMessage(long id)
        {
            Message message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);

            if (message == null) return false;

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return true;
        }

       public async Task<List<MessageViewModel>> GetAllMessages()
        {
            List<MessageViewModel> messages = await _context.Messages
                .Select(m => new MessageViewModel()
                {
                    Id = m.Id,
                    Email = m.Email,
                    Name = m.Name,
                    Text = m.Text
                })
                .ToListAsync();
            return messages;
        }
    }
}
