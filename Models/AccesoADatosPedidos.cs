namespace EspacioCadeteria;

using System.Text.Json;
using tl2_tp4_2023_josepro752;

public class AccesoADatosPedidos {
    public List<Pedido> Obtener() {
        if (File.Exists("Pedidos.json")) {
            var pedidos = JsonSerializer.Deserialize<List<Pedido>>("Pedidos.json");
            return pedidos;
        }
        return null;
    }
    public void Guardar(List<Pedido> Pedidos) {
        var json = JsonSerializer.Serialize(Pedidos);
        File.WriteAllText("Pedidos.json",json);
    }
}