namespace EspacioCadeteria;
using System.Text.Json;
public class AccesoADatosPedidos {
    public List<Pedido> Obtener() {
        if (File.Exists("Pedidos.json")) {
            var json = File.ReadAllText("Pedidos.json");
            var pedidos = JsonSerializer.Deserialize<List<Pedido>>(json);
            return pedidos;
        }
        return null;
    }
    public void Guardar(List<Pedido> pedidos) {
        var json = JsonSerializer.Serialize(pedidos);
        File.WriteAllText("Pedidos.json",json);
    }
}
