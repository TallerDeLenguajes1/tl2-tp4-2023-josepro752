namespace EspacioCadeteria;

using System.Text.Json;
using tl2_tp4_2023_josepro752;

public static class AccesoADatosCadetes {
    public static List<Cadete> Obtener () {
        if (File.Exists("Cadetes.json")) {
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>("Cadetes.json");
            return cadetes;
        }
        return null;
    }
}