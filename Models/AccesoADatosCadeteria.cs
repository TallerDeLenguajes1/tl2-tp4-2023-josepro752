namespace EspacioCadeteria;

using System.Text.Json;
using tl2_tp4_2023_josepro752;

public static class AccesoADatosCadeteria {
    public static Cadeteria Obtener () {
        if (File.Exists("Cadeteria.json")) {
            var cadeteria = JsonSerializer.Deserialize<Cadeteria>("Cadeteria.json");
            return cadeteria;
        }
        return null;
    }
}