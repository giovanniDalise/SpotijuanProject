using Spotijuan.Dao.Dao;
using Spotijuan.Dao.Dto;

// Non li ho continuati a fare dato che ho i test per provare il funzionamento

namespace Spotijuan.Dao
{
    public class BootStrap
    {
        private static DaoArtisti daoArtisti = new DaoArtisti();
        public static void Main(string[] args)
        {
            int scelta = 0;

            do
            {
                Console.WriteLine("Scegli il tipo di operazione:");
                Console.WriteLine("1.Lista degli artisti");
                Console.WriteLine("2.Inserisci un nuovo utente");
                Console.WriteLine("3.Cancella un utente");
                Console.WriteLine("4.Modifica un utente");
                Console.WriteLine("5.Trova utente per id");
                Console.WriteLine("6.Trova utente tramite username");
                Console.WriteLine("7.Trova utente tramite dati registrazione");
                Console.WriteLine("0.Esci");

                scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 1:
                        VisualizzaArtisti();
                        break;
                    case 2:
                //        InserisciUtente();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova!");
                        break;
                }
            } while (scelta != 0);
        }

        public static void VisualizzaArtisti()
        {
            List<Artista> listaArtisti = daoArtisti.Read();
            foreach (Artista artista in listaArtisti)
            {
                Console.WriteLine(artista.ToString());
            }
        }
        /*
        public static void InserisciUtente()
        {
            daoUtenti.Create(new Utente(2, "mario", "rossi", "fsdm@gmail.com", "culio", "fsdcul88", DateTime.Parse("1989-11-11"), new List<Canzone>()));
        }
        */
    }
}