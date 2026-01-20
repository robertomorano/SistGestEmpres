
using ChatTest.Entities;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
