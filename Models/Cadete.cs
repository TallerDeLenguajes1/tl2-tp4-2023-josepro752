namespace EspacioCadeteria;

public class Cadete {
    private int id;
    private string nombre;
    private string direccion;
    private long telefono;
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public long Telefono { get => telefono; set => telefono = value; }

    public Cadete () { //Constructor vacio que te pide el JSON para deserializar, es necesario cuando necesitas agregar otros constructores. Por ejemplo: tomarPedido()
        //Constructor vacío
    }
    public Cadete(int id, string nombre, string direccion, long telefono) {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}