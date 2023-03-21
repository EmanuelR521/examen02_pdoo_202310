
namespace LogicaRiesgoInundaciones
{
    public abstract class Zona
    {
        //ATRIBUTOS DE EL OBJETO ZONA, DECIDI SEPARAR EL TIPO POR TOPOGRAFIA Y TIPO PARA UNA MEJOR MANIPULACION
        protected string? topografia;
        protected string? tipo;
        protected int nivelMar;
        protected int area;
        protected int totalHabitantes;
        protected int distanciaRios;
        protected bool riesgo;
        protected double densidadPoblacional;
        protected string? inundacion;

        //METODOS ABSTRACTOS 
        public abstract bool getRiesgo();

        public abstract string? getTipo();

        public abstract void setInundacion(string? NuevaInundacion);

        public abstract string? getTopografia();

        public abstract string? getInundacion();
    }
}
