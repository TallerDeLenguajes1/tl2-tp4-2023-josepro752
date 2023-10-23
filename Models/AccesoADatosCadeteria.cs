namespace EspacioCadeteria;
using System.Text.Json;
public class AccesoADatosCadeteria {
    public Cadeteria Obtener() {
        if (File.Exists("Cadeteria.json")) {
            var json = File.ReadAllText("Cadeteria.json");
            var cadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
            return cadeteria;
        }
        return null;
    }
    public void Guardar(Cadeteria cadeteria) {
        var json = JsonSerializer.Serialize(cadeteria);
        File.WriteAllText("Cadeteria.json",json);
    }
}
