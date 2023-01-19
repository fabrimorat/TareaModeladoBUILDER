using System;

namespace EjemploBUILDER
{
    class Program
    {
        static void Main(string[] args)
        {
            var cocina = new Cocina();

            // un cliente pide una Pizza cuatro quesos familiar
            cocina.RecepcionarProximaPizza(new CuatroQuesosBuilder("Familiar"));
            cocina.CocinarPizzaPasoAPaso();
            var pizzaCuatroQuesos = cocina.PizzaPreparada;
            Console.WriteLine(pizzaCuatroQuesos.Masa);


            // otro cliente pide una Hawaiana
            cocina.RecepcionarProximaPizza(new HawaianaBuilder("Mediana"));
            cocina.CocinarPizzaPasoAPaso();
            var pizzaHawaiana = cocina.PizzaPreparada;
            Console.WriteLine(pizzaHawaiana.Relleno);

        }

        // Producto final
        public class Pizza
        {
            public string Masa { get; set; }
            public string Salsa { get; set; }
            public string Relleno { get; set; }
            public string Tamaño { get; set; }
            public bool EstaDoblada { get; set; }

            public Pizza()
            {

            }

            public Pizza(string tamaño, string masa, string salsa, string relleno, bool doblar) : this()
            {
                Tamaño = tamaño;
                Masa = masa;
                Salsa = salsa;
                Relleno = relleno;
                EstaDoblada = doblar;
            }
        }

        // Builder
        public abstract class PizzaBuilder
        {
            // Protected para que las clases que implementen puedan acceder
            protected Pizza _pizza;
            public string Tamaño { get; set; }

            public Pizza ObtenerPizza() { return _pizza; }



            // Un paso para cada una de las propiedades
            public virtual void PasoPrepararMasa()
            {

            }

            public virtual void PasoAñadirSalsa()
            {

            }

            public virtual void PasoPrepararRelleno()
            {

            }

            public virtual void PasoDoblarPoizza()
            {

            }

        }

        // BuilderConcreto
        public class HawaianaBuilder : PizzaBuilder
        {
            public HawaianaBuilder(string tamaño)
            {
                _pizza = new Pizza
                {
                    Tamaño = tamaño
                };
            }
            public override void PasoPrepararMasa()
            {
                _pizza.Masa = "Suave";
            }

            public override void PasoAñadirSalsa()
            {
                _pizza.Salsa = "Dulce";
            }

            public override void PasoPrepararRelleno()
            {
                _pizza.Relleno = "piña+tomate+jamón";
            }
        }

        // Otro BuilderConcreto
        public class CuatroQuesosBuilder : PizzaBuilder
        {
            public CuatroQuesosBuilder(string tamaño)
            {
                _pizza = new Pizza
                {
                    Tamaño = tamaño
                };
            }
            public override void PasoPrepararMasa()
            {
                _pizza.Masa = "Cocido";
            }

            public override void PasoAñadirSalsa()
            {
                _pizza.Salsa = "Roquefort";
            }

            public override void PasoPrepararRelleno()
            {
                _pizza.Relleno = "mozzarela+gorgonzola+parmesano+ricotta";
            }
        }

        // Director
        public class Cocina
        {
            private PizzaBuilder _pizzaBuilder;

            public void RecepcionarProximaPizza(PizzaBuilder pizzaBuilder)
            {
                _pizzaBuilder = pizzaBuilder;
            }

            public void CocinarPizzaPasoAPaso()
            {
                _pizzaBuilder.PasoPrepararMasa();
                _pizzaBuilder.PasoAñadirSalsa();
                _pizzaBuilder.PasoPrepararRelleno();
            }

            public Pizza PizzaPreparada
            {
                get { return _pizzaBuilder.ObtenerPizza(); }

            }
        }
    }

}