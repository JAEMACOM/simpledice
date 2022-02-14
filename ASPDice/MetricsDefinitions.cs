using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Histogram;

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

        public static HistogramOptions RolledDiceList => new HistogramOptions
        {
            Name    = "Dices List",
            Context = "DiceApi",
            MeasurementUnit = Unit.Results
        };
    }
}
