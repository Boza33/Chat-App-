using Chat_App.Dtos;
using Chat_App.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chat_App.Hubs;
public class ChatHub : Hub
{
    private readonly ChatServices _chatService;
    public ChatHub(ChatServices chatService)
    {
        _chatService = chatService;
    }

    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "Chat App");
        await Clients.Caller.SendAsync("UserConnected");
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Chat App");
        var user = _chatService.GetUserByConnectionId(Context.ConnectionId);
        _chatService.RemoveUserFromList(user);
        await DisplayOnlineUsers();

        await base.OnDisconnectedAsync(exception);
    }

    public async Task AddUserConnectionId(string name)
    {
        _chatService.AddUserConnectionId(name, Context.ConnectionId);
        await DisplayOnlineUsers();
    }

    public async Task ReceiveMessage(MessageDto message)
    {
        await Clients.Group("Chat App").SendAsync("NewMessage", message);
    }

    private async Task DisplayOnlineUsers()
    {
        var onlineUsers = _chatService.GetOnlineUsers();
        await Clients.Groups("Chat App").SendAsync("OnlineUsers", onlineUsers);
    }
}
 