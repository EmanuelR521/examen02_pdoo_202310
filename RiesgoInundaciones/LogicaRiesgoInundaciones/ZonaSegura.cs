
namespace LogicaRiesgoInundaciones
{
    public class ZonaSegura : Zona
    {
        //CONSTRUCTOR DE LAS ZONAS SEGURAS
        public ZonaSegura(string topografia, string tipo, int nivelMar, int area, int totalHabitantes, int distanciaRios)
        {
            this.topografia = topografia;
            this.tipo = tipo;
            this.nivelMar = nivelMar;
            this.area = area;
            this.totalHabitantes = totalHabitantes;
            this.distanciaRios = distanciaRios;
            riesgo = false;
            densidadPoblacional = totalHabitantes / area;
            inundacion = string.Empty;
        }


        //ACCESORES DEL BOOL RIESGO Y EL STRING TOPOGRAFIA
        public override bool getRiesgo()
        {
            return riesgo;
        }
        public override string? getTopografia()
        {
            return topografia;
        }

        //PAGO DE DEUDAS DE LOS METODOS ABSTRACTOS, COMO NO SON UTLIZADOS, SOLO SE PONE A LANZAR EL ERROR 

        public override string getInundacion()
        {
            throw new NotImplementedException();
        }

        public override string getTipo()
        {
            throw new NotImplementedException();
        }

        public override void setInundacion(string? NuevaInundacion)
        {
            throw new NotImplementedException();
        }
        private string devuelveRiesgo()
        {
            if (riesgo)
                return "si";
            else
                return "no";
        }
        //METODO UTILIZADO PARA LA IMPRESION DE LA ZONA
        public override string ToString()
        {
            string texto;
            texto = $"Zona {topografia} | Riesgo : {devuelveRiesgo()} | Tipo : {tipo} | Area : {area} km2 |" +
                $" Densidad Poblacional : {densidadPoblacional} p/km2\n ";

            return texto;
        }
    }

}
