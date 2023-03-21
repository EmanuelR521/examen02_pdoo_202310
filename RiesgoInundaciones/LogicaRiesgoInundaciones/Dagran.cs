
namespace LogicaRiesgoInundaciones
{
    public class Dagran
    {
        //ATRIBUTOS
        private int cantidadZonas;
        private Zona[] lasZonas;
        private string[] lasInundaciones = new string[] {"urbana", "fluvial", "costera" };

        //CONSTRUCTOR DEL OBJETO 
        public Dagran(int cantidadZonas)
        {
            this.cantidadZonas = cantidadZonas;
            lasZonas = new Zona[cantidadZonas];
            inicializaZonas();
            asignaTipoInundacion();
        }

        //METODO QUE DEVULVE LA CANTIDAD DE ZONAS EN RIESGO
        private int getCantidadRiesgo()
        {
            int cantZonas = 0;
            foreach(Zona pedazo in lasZonas)
            {
                if (pedazo.getRiesgo())
                {
                    cantZonas++;
                }
            }
            return cantZonas;
        }

        //ACCESOR QUE DEVUELVE EL ARREGLO lasZonas
        public Zona[] getZonas()
        {
            return lasZonas;
        }

        //METODO QUE ASIGNA VALORES ALEATORIOS A LOS ATRIBUTOS DE CADA ZONA EN EL ARREGLO lasZonas
        private void inicializaZonas()
        {
            
            Random rnd = new Random();
            string[] tipos = { "urbana", "rural" };
            string[] topografias = { "costera", "montanosa" };
            string tipo, topografia;
            int nivelMar, area, totalHabitantes, distanciaRios;

            for (int i = 0; i < lasZonas.Length; i++)
            {
                topografia = topografias[rnd.Next(topografias.Length)];
                tipo = tipos[rnd.Next(tipos.Length)];
                nivelMar = rnd.Next(0, 3001);
                area = rnd.Next(1, 50);
                totalHabitantes = rnd.Next(1000, 1000000);
                distanciaRios = rnd.Next(0, 2000);
                double densidadPoblacional = totalHabitantes / area;

                if ((topografia == "costera" && nivelMar <= 10) ||
                    (tipo == "urbana" && densidadPoblacional > 100) || 
                    (topografia == "montanosa" && distanciaRios < 50))
                    lasZonas[i] = new ZonaEnRiesgo(topografia, tipo, nivelMar, area, totalHabitantes, distanciaRios);
                else
                {
                    lasZonas[i] = new ZonaSegura(topografia, tipo, nivelMar, area, totalHabitantes, distanciaRios);
                }

            }
            
        }

        //METODO QUE ASIGNA EL TIPO DE INUNDACION EN CASO DE TENERLA AL LAS ZONAS EN EL ARREGLO lasZonas
        private void asignaTipoInundacion()
        {
            Random rnd = new Random();
            for(int i = 0; i < lasZonas.Length; i++)
            {
                if (lasZonas[i].getRiesgo())
                {
                    if(lasZonas[i].getTopografia() == "costera")
                    {
                        if (lasZonas[i].getTipo() == "rural") {

                            switch (rnd.Next(0, 2))
                            {
                                case 0:
                                    lasZonas[i].setInundacion("fluvial");
                                    break;
                                case 1:
                                    lasZonas[i].setInundacion("costera");
                                    break;
                            }
                        }
                        else
                        {
                            lasZonas[i].setInundacion(lasInundaciones[rnd.Next(0,3)]);
                        }
                    }

                    if (lasZonas[i].getTopografia() == "montanosa")
                    {
                        switch (rnd.Next(0, 1))
                        {
                            case 0:
                                lasZonas[i].setInundacion("fluvial");
                                break;
                            case 1:
                                lasZonas[i].setInundacion("costera");
                                break;
                        }
                    }
                }
            }
            
        }   

        //METODO QUE MEDIANTE ACCESOR OBTIENE LA TOPOGRAFIA Y TIPO DE ZONA Y MEDIANTE CONTADOR LOS TOTALIZA
        public string ObtienePorcentajeZonasPorTipo()
        {
            int costeraUrbana = 0, costeraRural = 0, montanosaUrbana = 0, montanosaRural = 0;
            string texto;

            for (int i = 0; i < lasZonas.Length; i++)
            {
                if (lasZonas[i].getRiesgo())
                {
                    if (lasZonas[i].getTopografia() == "costera" && lasZonas[i].getTipo() == "urbana")
                        costeraUrbana++;
                    if (lasZonas[i].getTopografia() == "costera" && lasZonas[i].getTipo() == "rural")
                        costeraRural++;
                    if (lasZonas[i].getTopografia() == "montanosa" && lasZonas[i].getTipo() == "urbana")
                        montanosaUrbana++;
                    if (lasZonas[i].getTopografia() == "montanosa" && lasZonas[i].getTipo() == "rural")
                        montanosaRural++;
                }
            }

            texto = $"--PORCENTAJE DE ZONAS POR TIPO--\n costera urbana: {costeraUrbana*100/getCantidadRiesgo()}%\n " +
                $"costera rural: {costeraRural*100/getCantidadRiesgo()}%\n montanosa urbana: {montanosaUrbana*100/getCantidadRiesgo()}%\n " +
                $"montanosa rural: {montanosaRural*100/getCantidadRiesgo()}%\n";

            return texto;
        }

        
        //METODO QUE OBTIENE LOS TIPOS DE INUNDACION MEDIANTE UN ACCESOR Y CON UN CONTADOR SE OBTIENE LA CANTIDAD
        public string ObtienePorcentajeRiesgosPorTipo()
        {
            int fluvial = 0, costera = 0, urbana = 0;
            string texto;

            for (int i = 0; i < lasZonas.Length; i++)
            {
                if (lasZonas[i].getRiesgo())
                {
                    if (lasZonas[i].getInundacion() == "fluvial") 
                        fluvial++;
                    if (lasZonas[i].getInundacion() == "costera")
                        costera++;
                    if (lasZonas[i].getInundacion() == "urbana")
                        urbana++;
                }
            }

            texto = $"--PORCENTAJE DE RIESGO POR TIPO--\n Riesgo de inundacion Fluvial: {fluvial * 100 / getCantidadRiesgo()}%\n " +
                $"Riesgo de inundacion Costera :{costera * 100 / getCantidadRiesgo()}%\n " +
                $"Riesgo de inundacion Urbana: {urbana * 100 / getCantidadRiesgo()}%\n";

            return texto;
        }


    }
}