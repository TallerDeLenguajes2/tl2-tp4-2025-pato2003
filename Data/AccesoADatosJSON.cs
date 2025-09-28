namespace accesoADatosJSON
{
    using cadeteria;
    using cadete;
    using System.Text.Json;
    using iAccesoADatos;
    using pedidos;
    using informe;
    public class AccesoADatosJSON : IAccesoADatos
    {
        private string archivoCadeteria;
        private string archivoCadete;
        private string archivoPedido;
        private string archivoInforme;
        private string ruta;

        public AccesoADatosJSON(string archivoCadeteria, string archivoCadete, string archivoPedido, string archivoInforme)
        {
            ruta = "./Data/";
            this.archivoCadete = archivoCadete;
            this.archivoCadeteria = archivoCadeteria;
            this.archivoPedido = archivoPedido;
            this.archivoInforme = archivoInforme;
        }

        public Cadeteria getCadeteria()
        {
            using (FileStream fs = new FileStream(ruta + archivoCadeteria, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);
                    fs.Close();
                    return cadeteria;
                }
            }

        }


        public List<Cadete> getCadetes()
        {
            using (FileStream fs = new FileStream(ruta + archivoCadete, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(contenido);
                    fs.Close();
                    return listaCadetes;
                }
            }
        }
        public List<Pedidos> getPedidos()
        {
            using (FileStream fs = new FileStream(ruta + archivoPedido, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    List<Pedidos> listaPedidos = JsonSerializer.Deserialize<List<Pedidos>>(contenido);
                    fs.Close();
                    return listaPedidos;
                }
            }
        }
        public InformeCadeteria getInforme()
        {
            using (FileStream fs = new FileStream(ruta + archivoInforme, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    List<InformeIndividual> listaInformes = JsonSerializer.Deserialize<List<InformeIndividual>>(contenido);
                    fs.Close();
                    InformeCadeteria informe = new InformeCadeteria(listaInformes);
                    return informe;
                }
            }
        }

        public void agregarPedido(Pedidos pedido)
        {
            
        }

    }
}