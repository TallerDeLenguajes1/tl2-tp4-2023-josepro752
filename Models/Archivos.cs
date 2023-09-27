using tl2_tp4_2023_josepro752;
using Microsoft.VisualBasic.FileIO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EspacioArchivos;
public abstract class AccesoADatos{
    public abstract bool Existe(string nombre);
    public abstract Cadeteria LeerCadeteria();
    public abstract List<Cadete> LeerCadetes();
    public void GuardarResumen(Cadeteria Cdtria){
        try{
            // Abre el archivo para escritura (si no existe, lo crea; si existe, sobrescribe el contenido)
            using (StreamWriter arch = new StreamWriter("Resumen.txt")){
                arch.WriteLine(Cdtria.Nombre +"RESUMEN");
                arch.WriteLine("Fecha: "+DateTime.Now.ToString("dddd d 'de' MMMM 'de' yyyy"));
                arch.WriteLine("PE: pedidos entregados, PSE: pedidos sin entregar, PC: pedidos cancelados, PT: pedidos totales.");
    
                foreach (var c in Cdtria.Cadetes){
                    var id = c.Id;
                    var nombre = c.Nombre;
                    var pE = c.CantidadPedidos(Cdtria.Pedidos,1);
                    var pSE = c.CantidadPedidos(Cdtria.Pedidos,2);
                    var pC = c.CantidadPedidos(Cdtria.Pedidos,3);
                    var TP = c.CantidadPedidos(Cdtria.Pedidos,0);
                    var pago = Cdtria.JornalACobrar(id);
                    arch.WriteLine(id+"| "+nombre+", PE"+pE+" PSE:"+pSE+" PC:"+pC+" PT:"+TP+", JORNAL: "+pago);
                }
                var numeroPed = Cdtria.Pedidos.Count(); 
                arch.WriteLine("Total de pedidos: "+numeroPed+"  Total a pagar: "+Cdtria.TotalaPagar());
            }
            // Console.WriteLine("Arreglo de cadenas escrito en el archivo correctamente.");
        }
        catch (IOException e){
            // Console.WriteLine($"Ocurrió un error al escribir en el archivo: {e.Message}");
        }
    }
    public void EscribirResumen(){
        if(Existe("Resumen")){
            using(StreamReader read = new StreamReader("Resumen.txt")){
                while(!read.EndOfStream){
                    Console.WriteLine(read.ReadLine());
                }
            }

        }
    }
}
public class AccesoJSON : AccesoADatos{
    public override bool Existe(string nombre){
        return File.Exists(nombre+".json")||File.Exists(nombre+".txt");
    }
    public override Cadeteria LeerCadeteria(){
        Cadeteria cadet = null;
        if (Existe("Cadeteria.json")){
            string json = File.ReadAllText("Cadeteria.json");
            cadet = JsonSerializer.Deserialize<Cadeteria>(json);
        } else {
            Console.WriteLine("No existe el json");
        }
        return cadet;
    }
    public override List<Cadete> LeerCadetes(){
        if (Existe("Cadetes.json")){
            string json = File.ReadAllText("Cadetes.json");
            return JsonSerializer.Deserialize<List<Cadete>>(json);
        } else {
            Console.WriteLine("No existe el json");
        }
        return null;
    }
    public void GuardarJSON(string nombre, Cadeteria cadeterria) {
        var json = JsonSerializer.Serialize(cadeterria);
        File.WriteAllText(nombre+".json",json);
    }
    public void GuardarJSON(string nombre, List<Cadete> cadeterria) {
        var json = JsonSerializer.Serialize(cadeterria);
        File.WriteAllText(nombre+".json",json);
    }

}
public class AccesoCSV : AccesoADatos{
    public override bool Existe(string nombre){
        return File.Exists(nombre+".csv")||File.Exists(nombre+".txt");
    }
    public override Cadeteria LeerCadeteria(){
        using(TextFieldParser ruta = new TextFieldParser("Cadeteria.csv")){
            ruta.TextFieldType = FieldType.Delimited;
            ruta.SetDelimiters(",",";");
            while(!ruta.EndOfData){
                string[] colum = ruta.ReadFields();
                if(colum.Count()==2){
                    var nom = colum[0];
                    int tel; 
                    int.TryParse(colum[1],out tel);
                    var Cdria = new Cadeteria(nom,tel);
                    return Cdria;
                }else{
                    System.Console.WriteLine("no tiene el formato adecuado");
                }
            }
        }
        return null;
    }
    public override List<Cadete> LeerCadetes(){
        using(TextFieldParser ruta = new TextFieldParser("Cadetes.csv")){
            ruta.TextFieldType = FieldType.Delimited;
            var Cadts = new List<Cadete>();
            ruta.SetDelimiters(",",";");
            while(!ruta.EndOfData){
                string[] filas = ruta.ReadFields();
                if(filas.Count()==4){
                    int id, tel; 
                    var nom = filas[1];
                    var dire = filas[2];
                    int.TryParse(filas[0],out id);
                    int.TryParse(filas[3],out tel);
                    var cad = new Cadete(id,nom,dire,tel);
                    Cadts.Add(cad);
                }else{
                    System.Console.WriteLine("no tiene el formato adecuado");
                }
            }
            return Cadts;
        }
    }
}
