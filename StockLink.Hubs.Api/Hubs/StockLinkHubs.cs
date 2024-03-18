using Microsoft.AspNetCore.SignalR;

namespace StockLink.Hubs.Api.Hubs
{
    public class StockLinkHubs : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}