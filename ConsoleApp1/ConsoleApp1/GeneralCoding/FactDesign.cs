using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IAirConditioner
    {
        void Operate();
    }
    public class Cooling : IAirConditioner
    {
        private readonly double _temperature;

        public Cooling(double temperature)
        {
            _temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Cooling the room to the required temperature of {_temperature} degrees");
        }
    }
    public class Warming : IAirConditioner
    {
        private readonly double _temperature;

        public Warming(double temperature)
        {
            _temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Warming the room to the required temperature of {_temperature} degrees.");
        }
    }
    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }
    public class CoolingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new Cooling(temperature);
    }
    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new Warming(temperature);
    }
    public enum Actions
    {
        Cooling,
        Warming
    }

    public static class AirConditioner
    {
        private static readonly Dictionary<Actions, AirConditionerFactory> _factories;

        static AirConditioner()
        {
            _factories = new Dictionary<Actions, AirConditionerFactory>
        {
            { Actions.Cooling, new CoolingFactory() },
            { Actions.Warming, new WarmingFactory() }
        };

            //foreach (Actions action in Enum.GetValues(typeof(Actions)))
            //{
            //    var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
            //    _factories.Add(action, factory);
            //}
        }

        public static IAirConditioner ExecuteCreation(Actions action, double temperature) => _factories[action].Create(temperature);
    }
    class FactDesign
    {
        static void Main(string[] args)
        {
            var factory = AirConditioner.ExecuteCreation(Actions.Cooling, 22.5);
            factory.Operate();
        }
    }
}
