using System.Runtime.InteropServices;

namespace APIAmbiental.Models
{
    public class CondicoesAmbientaisModel
    {
        public int id { get; set; }
        public string? qualidadeAr{ get; set; }
        public string? umidade { get; set; }
        public string? temperatura { get; set; }
        public string? contatoEmergencia { get; set; }
        public string? desastreNatural { get; set; }
    }
}
