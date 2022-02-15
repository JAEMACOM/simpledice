using Microsoft.AspNetCore.Mvc;

namespace ASPDice.Controllers
{
    public class DiceBaseController : ControllerBase
    {
        protected static List<int> DiceList = new List<int>();
        protected static readonly object ListLock = new object();
    }
}
