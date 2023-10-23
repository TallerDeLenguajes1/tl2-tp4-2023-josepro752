namespace EspacioCadeteria;

public class Cliente {
    private string nombre;
    private string direccion;
    private long telefono;
    private string DatosRef;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public long Telefono { get => telefono; set => telefono = value; }
    public string DatosRef1 { get => DatosRef; set => DatosRef = value; }
    public Cliente () { //Constructor vacio que te pide el JSON para deserializar, es necesario cuando necesitas agregar otros constructores. Por ejemplo: tomarPedido()
        //Constructor vacío
    }
}