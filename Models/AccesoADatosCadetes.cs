namespace EspacioCadeteria;
using System.Text.Json;
public class AccesoADatosCadetes {
    public List<Cadete> Obtener() {
        if (File.Exists("Cadetes.json")) {
            var json = File.ReadAllText("Cadetes.json");
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>(json); //Devuelve una lista de cadetes
            return cadetes;
        }
        return null;
    } 
    public void Guardar(List<Cadete> cadetes) {
        var json = JsonSerializer.Serialize(cadetes);
        File.WriteAllText("Cadetes.json",json);
    }
}
