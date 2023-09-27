namespace EspacioCadeteria;

using System.Text.Json;
using tl2_tp4_2023_josepro752;

public static class AccesoADatosCadetes {
    public static List<Cadete> Obtener () {
        var path = "Cadetes.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
            return cadetes;
        }
        return null;
    }
}