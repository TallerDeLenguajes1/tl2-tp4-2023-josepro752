namespace EspacioCadeteria;

using System.Text.Json;
using tl2_tp4_2023_josepro752;

public static class AccesoADatosCadeteria {
    public static Cadeteria Obtener () {
        var path = "Cadeteria.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            var cadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
            return cadeteria;
        }
        return null;
    }
}