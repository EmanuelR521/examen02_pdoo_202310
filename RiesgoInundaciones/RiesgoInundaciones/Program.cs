using LogicaRiesgoInundaciones;

namespace RiesgoInundaciones
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                             ------------- REPORTE DE GESTION DE RIESGOS-------------\n");

            //CONTROLAMOS EL INGRESO DE INPUTS INCORRECTOS, QUE NO SEAN NUMEROS NATURALES
            int cantidadZonas = 0;
            bool inputAdecuado = false;
            do
            {
                try
                {
                    Console.Write("Ingrese la cantidad de zonas a censar: ");
                    cantidadZonas = int.Parse(Console.ReadLine()!);

                    if (cantidadZonas > 0)
                        inputAdecuado = true;
                    else
                        Console.WriteLine("Ingrese un numero natual, por favor");
                }
                catch (FormatException)
                {
                    Console.WriteLine("El valor que ingresaste no es un formato permitido, intente de nuevo");
                }
            }
            while (!inputAdecuado);

            Console.WriteLine("\nCensando zonas...\n");

            //CREAMOS EL OBJETO DAGRAN CON ARGUMENTO DE CANTIDAD DE ZONAS

            Dagran censado = new Dagran(cantidadZonas);

            //IMPRIME LAS ZONAS CON EL METODO SOBREESCRITO ToString()
            for(int i = 0; i < censado.getZonas().Length; i++)
            Console.WriteLine(censado.getZonas()[i].ToString());

            //IMPRIME LOS DOS METODOS REQUERIDOS POR EL EJERCICIO
            Console.WriteLine(censado.ObtienePorcentajeZonasPorTipo());
            Console.WriteLine(censado.ObtienePorcentajeRiesgosPorTipo());
        }
    }
}
