using Microsoft.AspNetCore.SignalR;
using ChatTest.Entities;


namespace SignalRChat.Hubs
{
    public class chatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
