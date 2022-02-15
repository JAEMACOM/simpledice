using App.Metrics;
using App.Metrics.Counter;

namespace ASPDice
{
    public class MetricsDefinitions
    {
        public static CounterOptions RolledDiceCounter => new CounterOptions
        {
            Name    = "Dices rolled",
            Context = "DiceApi",
            MeasurementUnit = Unit.Calls
        };

    }
}
