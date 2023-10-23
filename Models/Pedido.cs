namespace EspacioCadeteria;

public enum Estado {
    EnPreparacion,
    Entregado,
    Cancelado
}
public class Pedido {
    private int id;
    private string nombre;
    private string observacion;
    private Estado estado;
    private Cliente cliente;
    private int idCad;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public int IdCad { get => idCad; set => idCad = value; }

    public Pedido () { //Constructor vacio que te pide el JSON para deserializar, es necesario cuando necesitas agregar otros constructores. Por ejemplo: tomarPedido()
        //Constructor vacío
    }

    public Pedido(int id, string nombre, string observacion, Estado estado, Cliente cliente) {
        this.id = id;
        this.nombre = nombre;
        this.observacion = observacion;
        this.estado = estado;
        this.cliente = cliente;
        this.idCad = 0;
    }
}