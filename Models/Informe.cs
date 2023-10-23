namespace EspacioCadeteria;

public class Informe {
    public static List<InformeCadete> GetInforme(Cadeteria cadeteria) {
        var cadetes = cadeteria.GetCadetes();
        var InformeCadetes = new List<InformeCadete>();
        foreach (Cadete C in cadetes) {
            InformeCadetes.Add(new InformeCadete(C.Nombre,C.Id,cadeteria.JornalAPagarPorCadete(C.Id),cadeteria.ContarPedidos(C.Id)));
        }
        return InformeCadetes;
    }
}
public class InformeCadete {
    private string nombreCad;
    private int idCad;
    private float jornal;
    private int pedidosEntregados;
    public InformeCadete(string nombreCad, int idCad, float jornal, int pedidosEntregados)
    {
        this.nombreCad = nombreCad;
        this.idCad = idCad;
        this.jornal = jornal;
        this.pedidosEntregados = pedidosEntregados;
    }
}