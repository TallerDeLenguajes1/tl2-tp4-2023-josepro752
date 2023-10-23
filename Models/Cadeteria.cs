namespace EspacioCadeteria;
using System.Linq;
public class Cadeteria {
    private string nombre;
    private long telefono;
    private static Cadeteria instance;
    public AccesoADatosCadeteria accesoADatosCadeteria;
    private AccesoADatosCadetes accesoADatosCadetes;
    private AccesoADatosPedidos accesoADatosPedidos;
    public string Nombre { get => nombre; set => nombre = value; }
    public long Telefono { get => telefono; set => telefono = value; }
    public Cadeteria () {
        //Constructor vacio
    }
    public static Cadeteria GetInstance() {
        //Patron singeltone
        if (instance == null) {
            instance = new AccesoADatosCadeteria().Obtener();
            instance.accesoADatosCadeteria = new AccesoADatosCadeteria();
            instance.accesoADatosCadetes = new AccesoADatosCadetes();
            instance.accesoADatosPedidos = new AccesoADatosPedidos();
            instance.accesoADatosPedidos.Guardar(new List<Pedido>());
        }
        return instance;
    }
    public List<Cadete> GetCadetes() {
        return accesoADatosCadetes.Obtener();
    }
    public List<Pedido> GetPedidos() {
        return accesoADatosPedidos.Obtener();
    }
    public Pedido AddPedido(string nombre, string observacion, EstadoPedido estado, Cliente cliente) {
        var listaPed = accesoADatosPedidos.Obtener();
        var pedido = new Pedido(listaPed.Count(),nombre,observacion,estado,cliente);
        listaPed.Add(pedido);
        accesoADatosPedidos.Guardar(listaPed);
        return pedido;
    }
    public Pedido CambiarEstadoPedido(int idPed, EstadoPedido estado) {
        var listaPed = GetPedidos();
        Pedido ped = null;
        foreach(var pedido in listaPed) {
            if (pedido.Id == idPed) {
                pedido.Estado = estado;
                ped = pedido;
            }
        }
        accesoADatosPedidos.Guardar(listaPed);
        return ped;
    }
    public Pedido AsignarPedido(int idPed, int idCad) {
        Pedido ped = null;
        var cadete = GetCadetes().FirstOrDefault(cadete => cadete.Id == idCad);
        if (cadete != null) {
            var listaPed = GetPedidos();
            foreach(var pedido in listaPed) {
                if (pedido.Id == idPed) {
                    pedido.IdCad = idCad;
                    ped = pedido;
                }
            }
        }
        return ped;
    }
    public Pedido ReAsignarPedido(int idPed, int idCad) {
        return AsignarPedido(idPed,idCad);
    }
    public float JornalAPagarPorCadete (int idCad) {
        float monto = 0;
        var cadete = accesoADatosCadetes.Obtener().FirstOrDefault(cadete => idCad == cadete.Id);
        if (cadete != null) {
            monto = 500 * accesoADatosPedidos.Obtener().Count(pedido => pedido.IdCad == idCad);
        }
        return monto;
    }
    public int ContarPedidos(int idCad) {
        var listaPed = accesoADatosPedidos.Obtener();
        return listaPed.Count(pedido => pedido.IdCad == idCad && pedido.Estado == EstadoPedido.Entregado);
    }
    public List<InformeCadete> GetInforme(Cadeteria cadeteria) {
        return Informe.GetInforme(cadeteria);
    }
}