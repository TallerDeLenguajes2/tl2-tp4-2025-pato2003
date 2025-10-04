namespace iAccesoADatos
{
    using cadeteria;
    using cadete;
    using pedidos;
    using informe;
    public interface IAccesoADatos
    {
        public Cadeteria getCadeteria();
        public List<Cadete> getCadetes();
        public List<Pedidos> getPedidos();
        public InformeCadeteria getInforme();
        public Pedidos agregarPedido(Pedidos pedido);
        public void guardarPedidos(List<Pedidos> listaPedidos);

    }
}