using System.Text.Json.Serialization;

namespace informe
{
    public class InformeIndividual
    {
        [JsonPropertyName("cantPedidos")]
        public int CantPedidos { get; set; }
        [JsonPropertyName("montoGanado")]
        public double MontoGanado{ get; set; }
        [JsonPropertyName("nombreCadete")]
        public string? NombreCadete{ get; set; }

        public InformeIndividual(int cantPedidos, double montoGanado, string? nombreCadete)
        {
            CantPedidos = cantPedidos;
            MontoGanado = montoGanado;
            NombreCadete = nombreCadete;
        }

    }

    public class InformeCadeteria
    {
        private int totalEnvios;
        private double totalMonto;
        private double promedioEnvios;
        private List<InformeIndividual> listaInformes;
        public List<InformeIndividual> ListaInformes { get => listaInformes; set => listaInformes = value; }
        public int TotalEnvios { get => totalEnvios;}
        public double TotalMonto { get => totalMonto;}
        public double PromedioEnvios { get => promedioEnvios;}

        public InformeCadeteria(List<InformeIndividual> listaInformes)
        {
            if (listaInformes!=null && listaInformes.Count() > 0)
            {
                totalEnvios = listaInformes.Sum(i => i.CantPedidos);
                totalMonto = listaInformes.Sum(i => i.MontoGanado);
                promedioEnvios = (double)totalEnvios / listaInformes.Count;
                this.listaInformes = listaInformes;
            }
            else
            {
                totalEnvios = 0;
                totalMonto = 0;
                promedioEnvios = 0;
                this.listaInformes = new List<InformeIndividual>();
            }}
    }
}