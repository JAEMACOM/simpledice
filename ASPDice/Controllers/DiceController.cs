using Microsoft.AspNetCore.Mvc;
using App.Metrics;

namespace ASPDice.Controllers
{
    [ApiController]  //Damit es im Developmentmodus über Swagger läuft
    [Route("[controller]")] //Damit es im Developmentmodus über Swagger läuft

    public class DiceController : DiceBaseController // Der Name des exportierten Services ist der Name der Klasse - "Controller" = "Dice"
    {
        private readonly IMetrics _metrics;

        public DiceController(IMetrics metrics)
        {
            _metrics = metrics;
        }

        [HttpGet(Name = "GetDice")] //Beim Http GET Request wird GetDice aufgerufen
        public int GetDice()
        {
            // Nur Einfachkeit als Test Projekt. Besser mit Static Rnd Variable und locks für Thread-Sicherheit
            // Problem: new Random() wird jedes mal eine neue Initialisierung des Random-Seeds über die System-Zeit
            // Da die Auflösung der System-Zeit nicht unendlich klein ist, kann z.B eine schnelle Schleife,
            // immer die gleiche Zahl bekommen!
            var aDiceRolled = new Random().Next(1, 7);
            lock (ListLock)
            {
                DiceList.Add(aDiceRolled);
            }
            _metrics.Measure.Counter.Increment(MetricsDefinitions.RolledDiceCounter);
            return aDiceRolled;
        }


    }

 }
