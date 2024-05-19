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
        await Clients.Caller.SendAsync("Korisnik konektovan.");
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Chat App");
        await base.OnDisconnectedAsync(exception);
    }




}
