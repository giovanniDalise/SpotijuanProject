
using Oracle.ManagedDataAccess.Client;
using Spotijuan.Dao.Dto;
using Spotijuan.Dao.Exceptions;
using System.Data;

namespace Spotijuan.Dao.Dao
{
    public class DaoUtenti : DaoAbstract<Utente>
    {
       
        protected override Utente ResultsetToEntity(OracleDataReader reader)
        {
            Utente utente;
            List<Canzone> preferiti = new List<Canzone>();
            try
            {
                utente = new Utente(
                    Convert.ToInt32(reader.GetString("idUtente")),
                    reader.GetString("nome"),
                    reader.GetString("cognome"),
                    reader.GetString("email"),
                    reader.GetString("username"),
                    reader.GetString("psw"),
                    reader.GetDateTime("data_nascita").ToLocalTime(),
                    preferiti);
            }
            catch (OracleException e)
            {
                throw new DaoException("Errore in fase da Result a Entity.", e);
            }
            return utente;
        }
        protected override List<Utente> TransformData(OracleDataReader reader)
        {
            List<Utente> result = new List<Utente>();
            Utente utente = null;
            Canzone canzone = null;
            int indiceUtente = -1;

            //La sequenza reader.GetInt32(reader.GetOrdinal("idUtente")) è utilizzata per ottenere il valore della colonna "idUtente" dal lettore dei dati (DataReader) e convertirlo in un intero.
            //In altre parole, la sequenza completa si traduce nel seguente flusso:
            //  GetOrdinal("idUtente"): Ottieni l'indice numerico della colonna "idUtente".
            //  GetInt32(indice): Ottieni il valore della colonna "idUtente" come tipo Int32.

            try
            {
                while (reader.Read())
                {
                    if (reader["idUtente"] != DBNull.Value && reader.GetInt32("idUtente") != indiceUtente)
                    {
                        indiceUtente = reader.GetInt32("idUtente");
                        utente = ResultsetToEntity(reader);
                        result.Add(utente);
                    }

                    if (reader["idCanzone"] != DBNull.Value && reader.GetInt32("idCanzone") != 0)
                    {
                        canzone = new Canzone(
                            reader.GetInt32("idCanzone"),
                            new Artista(0, reader.GetString("artistaNome"), new List<string>()),
                            reader.GetString("titolo"),
                            reader.GetString("link"),
                            reader.GetInt32("annoUscita"),
                            new List<String>(),
                            TimeSpan.FromMilliseconds(reader.GetTimeSpan(reader.GetOrdinal("durata")).TotalMilliseconds)
                        );
                        // Non sto prendendo anche i generi ( new List<String>())in questo caso perchè non mi servono tutti questi dati nello specifico per gli utenti poi i generi li recupererò da altrove quando ne avò bisogno.
                        // Una get all di tutti gli utenti potrebbe farla ad esempio in un caso do utilizzo con attore un moderatore, ma in questo caso del genere della sua canzone preferita il moderatore non se ne fa nulla.
                        //Bisogna sempre pensare sia per risparmio di tempo che complessità di codice a quanto necessario analizzando le casistiche di utilizzo prendersi dati specifici.

                        utente.Preferiti.Add(canzone);
                    }
                }
            }
            catch (Exception ex)
            {
               throw new DaoException("Errore in fase di trasformazione dei dati in DaoUtenti", ex);
            }

            return result;
        }

        protected override string GetSelect()
        {
            return "MAS_SPOTIJUAN.SELECT_USERS";
        }
        /*
        protected override string GetIdName()
        {
            return "idUtente";
        }
        protected override string GetInsert(Utente utente)
        {
            return $"INSERT INTO utente (nome, cognome, email, username, psw, data_nascita) VALUES ('{utente.Nome}', '{utente.Cognome}', '{utente.Email}', '{utente.Username}', '{utente.Psw}', TO_DATE('{utente.DataNascita:yyyy-MM-dd}', 'YYYY-MM-DD'))";
        }
       
        protected override string GetDelete(int id)
        {
            return $"delete from utente where idUtente = {id}";
        }
      
       protected override string GetFindById()
       {
           return "MAS_SPOTIJUAN.SELECT_USERS";
       }
      
        protected override string GetFindByText()
        {
            return "MAS_SPOTIJUAN.SELECT_USERS";
        }
 
        protected override string GetUpdate(Utente utente, int id)
        {
            DateTime utcDataNascita = utente.DataNascita.ToUniversalTime();
            string formattedDate = utcDataNascita.ToString("dd/MM/yyyy HH:mm:ss");

            string query = $"update utente set nome = '{utente.Nome}', cognome = '{utente.Cognome}', email = '{utente.Email}', username = '{utente.Username}', psw = '{utente.Psw}', data_nascita = TO_DATE('{formattedDate}', 'DD/MM/YYYY HH24:MI:SS') where idUtente = {id}";

            return query;
        }
           
        protected override string GetFindByObject(Utente utente)
        {
            string query = @"
            SELECT utente.*, canzone.*, artista.nome as artistaNome
            FROM utente
            LEFT JOIN preferiti ON utente.idUtente = preferiti.utente
            LEFT JOIN canzone ON preferiti.canzone = canzone.idCanzone
            LEFT JOIN artista_canzone ON canzone.idCanzone = artista_canzone.idCanzone
            LEFT JOIN artista ON artista_canzone.idArtista = artista.idArtista
            WHERE 1 = 1";

            if (utente != null)
            {
                if (!string.IsNullOrEmpty(utente.Nome))
                    query += $" AND utente.nome = '{utente.Nome}'";

                if (!string.IsNullOrEmpty(utente.Cognome))
                    query += $" OR utente.cognome = '{utente.Cognome}'";

                if (!string.IsNullOrEmpty(utente.Email))
                    query += $" OR utente.email = '{utente.Email}'";

                if (!string.IsNullOrEmpty(utente.Username))
                    query += $" OR utente.username = '{utente.Username}'";

                if (!string.IsNullOrEmpty(utente.Psw))
                    query += $" OR utente.psw = '{utente.Psw}'";

                if (utente.DataNascita != DateTime.MinValue)
                {
                    // Assicurati di formattare la data nel modo corretto, ad esempio: 'yyyy-MM-dd'
                    string formattedDate = utente.DataNascita.ToString("yyyy-MM-dd");

                    // Aggiungi la condizione solo se la data è diversa da DateTime.MinValue
                    query += $" OR TRUNC(utente.data_nascita) = TO_DATE('{formattedDate}', 'YYYY-MM-DD')";
                }
            }

            return query;
        }
        */

    }
}
