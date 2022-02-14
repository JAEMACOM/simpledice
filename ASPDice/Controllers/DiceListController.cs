using Microsoft.AspNetCore.Mvc;

namespace ASPDice.Controllers
{
    [ApiController]  //Damit es im Developmentmodus über Swagger läuft
    [Route("[controller]")] //Damit es im Developmentmodus über Swagger läuft

    public class DiceListController : DiceBaseController
    {
        [HttpGet(Name = "GetList")]   //Name des exportierten Services
        public List<int> GetList()
        {
            lock (ListLock)
            {
                return DiceList;
            }
        }
    }
}
