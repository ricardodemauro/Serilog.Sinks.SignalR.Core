using Carter;
using System.Net;

namespace SerilogSignalR.Server.CarterModules
{
    public class HomeModule : CarterModule
    {
        public HomeModule()
        {
            Get("/", async (req, res) =>
            {
                res.StatusCode = (int)HttpStatusCode.OK;
                res.ContentType = "text/html";
                await res.SendFileAsync("wwwroot/index.html");
            });
        }
    }
}
