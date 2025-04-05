using System.Net.WebSockets;
using System.Text;

namespace ITPlatformUMT.WebSockets
{
    public static class WebSocketHandler
    {
        public static async Task Handle(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None);
                    break;
                }

                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                Console.WriteLine($"[WebSocket] Received: {message}");

                // Echo lại message (nếu cần gửi lại)
                await webSocket.SendAsync(
                    new ArraySegment<byte>(Encoding.UTF8.GetBytes($"Bạn gửi: {message}")),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );
            }
        }
    }
}
