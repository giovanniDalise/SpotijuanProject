using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotijuan.Dao.Dto
{
    public class Utente
    {
        private int id;
        private string nome;
        private string cognome;
        private string email;
        private string username;
        private string psw;
        private DateTime dataNascita; 
        private List<Canzone> preferiti;

        public Utente(int id, string nome, string cognome, string email, string username, string psw, DateTime dataNascita, List<Canzone> preferiti)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cognome = cognome;
            this.Email = email;
            this.Username = username;
            this.Psw = psw;
            this.DataNascita = dataNascita;
            this.Preferiti = preferiti;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Psw { get => psw; set => psw = value; }
        public DateTime DataNascita { get => dataNascita; set => dataNascita = value; }
        public List<Canzone> Preferiti { get => preferiti; set => preferiti = value; }

        public override bool Equals(object? obj)
        {
            return obj is Utente utente &&
                   nome == utente.nome &&
                   cognome == utente.cognome &&
                   email == utente.email &&
                   username == utente.username &&
                   psw == utente.psw &&
                   dataNascita == utente.dataNascita;
        }

        public override string ToString()
        {
            //ho dovuto aggiungere questa parte al toString utente se no non riusciva a leggermi la lista dei 
            //preferiti
            StringBuilder preferitiStr = new StringBuilder("[");
            foreach (Canzone canzone in Preferiti)
            {
                preferitiStr.Append(canzone.ToString());
                preferitiStr.Append(", ");
            }
            preferitiStr.Append("]");

            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Nome)}={Nome}, {nameof(Cognome)}={Cognome}, {nameof(Email)}={Email}, {nameof(Username)}={Username}, {nameof(Psw)}={Psw}, {nameof(DataNascita)}={DataNascita.ToString()}, {nameof(Preferiti)}={preferitiStr}}}";
        }
    }

}
