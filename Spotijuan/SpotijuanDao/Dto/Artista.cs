using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotijuan.Dao.Dto
{
    public class Artista
    {
        private int id;
        private string nome;
        private List<string> generi;

        public Artista(int id, string nome, List<string> generi)
        {
            this.Id = id;
            this.Nome = nome;
            this.Generi = generi;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public List<string> Generi { get => generi; set => generi = value; }

        public override bool Equals(object? obj)
        {
            return obj is Artista artista &&
                   nome == artista.nome;
        }

        public override string ToString()
        {
            StringBuilder generiStr = new StringBuilder("[");
            foreach (string genere in Generi)
            {
                generiStr.Append(genere.ToString());
                generiStr.Append(", ");
            }
            generiStr.Append("]");
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Nome)}={Nome},{nameof(Generi)}={generiStr}}}";
        }
    }
}
