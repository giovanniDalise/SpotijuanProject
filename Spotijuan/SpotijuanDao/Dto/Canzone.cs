using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotijuan.Dao.Dto
{
    public class Canzone
    {
        private int id;
        private Artista artista;
        private string titolo;
        private string link;
        private int annoUscita;
        private List <string> generi;
        private TimeSpan durata;

        public Canzone(int id, Artista artista, string titolo, string link, int annoUscita, List<string> generi, TimeSpan durata)
        {
            this.Id = id;
            this.Artista = artista;
            this.Titolo = titolo;
            this.Link = link;
            this.AnnoUscita = annoUscita;
            this.Generi = generi;
            this.Durata = durata;
        }

        public int Id { get => id; set => id = value; }
        public Artista Artista { get => artista; set => artista = value; }
        public string Titolo { get => titolo; set => titolo = value; }
        public string Link { get => link; set => link = value; }
        public int AnnoUscita { get => annoUscita; set => annoUscita = value; }
        public List<string> Generi { get => generi; set => generi = value; }
        public TimeSpan Durata { get => durata; set => durata = value; }

        public override bool Equals(object? obj)
        {
            return obj is Canzone canzone &&
                   EqualityComparer<Artista>.Default.Equals(artista, canzone.artista) &&
                   titolo == canzone.titolo &&
                   link == canzone.link &&
                   annoUscita == canzone.annoUscita &&
                   EqualityComparer<List<string>>.Default.Equals(generi, canzone.generi) &&
                   durata.Equals(canzone.durata);
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Artista)}={Artista}, {nameof(Titolo)}={Titolo}, {nameof(Link)}={Link}, {nameof(AnnoUscita)}={AnnoUscita.ToString()}, {nameof(Generi)}={Generi}, {nameof(Durata)}={Durata.ToString()}}}";
        }
    }
}
