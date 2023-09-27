namespace EspacioCadeteria;

using System.Text.Json;
using tl2_tp4_2023_josepro752;

public static class AccesoADatosPedidos {
    public static List<Pedido> Obtener() {
        var path = "Pedidos.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            var pedidos = JsonSerializer.Deserialize<List<Pedido>>(json);
            return pedidos;
        }
        return null;
    }
    public static void Guardar(List<Pedido> Pedidos) {
        var json = JsonSerializer.Serialize(Pedidos);
        File.WriteAllText("Pedidos.json",json);
    }
}