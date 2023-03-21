
namespace LogicaRiesgoInundaciones
{
    public class ZonaEnRiesgo : Zona
    {
        //CONTRUCTOR DE LAS ZONAS EN RIESGO
        public ZonaEnRiesgo(string topografia, string tipo, int nivelMar, int area, int totalHabitantes, int distanciaRios)
        {
            this.topografia = topografia;
            this.tipo = tipo;
            this.nivelMar = nivelMar;
            this.area = area;
            this.totalHabitantes = totalHabitantes;
            this.distanciaRios = distanciaRios;
            riesgo = true;
            densidadPoblacional = totalHabitantes / area;
            inundacion = string.Empty;
        }

        //ACCESOR PARA EL BOOLEANO RIESGO, STRING TOPOGRAFIA, STRING TIPO, STRING INUNDACION, SE PAGA LA DEUDA DE LA CLASE ZONA
        public override bool getRiesgo()
        {
            return riesgo;
        }
        public override string? getTopografia()
        {
            return topografia;
        }
        public override string? getTipo()
        {
            return tipo;
        }
        public override void setInundacion(string? inundacion)
        {
            this.inundacion = inundacion;
        }
        public override string? getInundacion()
        {
            return inundacion;
        }

        private string devuelveRiesgo()
        {
            if (riesgo)
                return "si";
            else
                return "no";
        }

        //METODO REQUERIDO PARA IMPRIMIR LA ZONA
        public override string ToString()
        {
            string texto;
            texto = $"Zona {topografia} | Riesgo : {devuelveRiesgo()} | Tipo : {tipo} | Area : {area} km2 |" +
                $" Densidad Poblacional : {densidadPoblacional} p/km2 | Tipo de inundacion: {inundacion}\n";

            return texto;
        }
    }
}
