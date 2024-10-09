using Oracle.ManagedDataAccess.Client;
using Spotijuan.Dao.Dto;
using Spotijuan.Dao.Exceptions;
using System.Data;

namespace Spotijuan.Dao.Dao
{
    public class DaoArtisti : DaoAbstract<Artista>
    {
        protected override Artista ResultsetToEntity(OracleDataReader reader)
        {
            Artista artista;
            List<string> generi = new List<string>();
            try
            {
                artista = new Artista(
                    Convert.ToInt32(reader["idArtista"]),
                    reader.GetString("nomeArtista"),
                    generi);
            }
            catch (OracleException e)
            {
                throw new DaoException("Errore in fase da Result a Entity.", e);
            }
            return artista;
        }
        protected override List<Artista> TransformData(OracleDataReader reader)
        {
            List<Artista> result = new List<Artista>();
            Artista artista = null;
            string genere = "";
            int indiceArtista = -1;
            try
            {
                while (reader.Read())
                {
                    if (reader["idArtista"] != DBNull.Value && reader.GetInt32("idArtista") != indiceArtista)
                    {
                        indiceArtista = reader.GetInt32("idArtista");
                        artista = ResultsetToEntity(reader);
                        result.Add(artista);
                    }

                    if (reader["idGenere"] != DBNull.Value && reader.GetInt32(reader.GetOrdinal("idGenere")) != 0)
                    {
                        genere = reader.GetString("nomegenere");


                        artista.Generi.Add(genere);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DaoException("Errore in fase di trasformazione dei dati in DaoArtisti", ex);
            }

            return result;
        }
        protected override string GetSelect()
        {
            return "MAS_SPOTIJUAN.SELECT_ARTISTS";
        }
        /*
        protected override string GetIdName()
        {
            return "idArtista";
        }
        protected override string GetInsert(Artista artista)
        {
            return $"INSERT INTO artista (nome) VALUES ('{artista.Nome}')";
        }
        protected override string GetDelete(int id)
        {
            return $"delete from artista where idArtista = {id}";
        }
        protected override string GetFindById()
        {
            return "MAS_SPOTIJUAN.SELECT_ARTISTS";
        }
        protected override string GetFindByText()
        {
            return "MAS_SPOTIJUAN.SELECT_ARTISTS";
        }
        protected override string GetUpdate(Artista artista, int id)
        {
            return $"update artista set nome = '{artista.Nome}'where idArtista = {id}";
        }
        protected override string GetFindByObject(Artista artista)
        {
            string query = @"
           SELECT a.idArtista, a.nome AS nomeArtista, g.idGenere, g.genere AS nomeGenere
           FROM artista a
           LEFT JOIN artista_canzone ac ON a.idArtista = ac.idArtista
           LEFT JOIN canzoni_generi cg ON cg.idcanzone = ac.idcanzone
           LEFT JOIN genere g ON g.idGenere = cg.idGenere
           WHERE 1 = 1";

            if (artista != null)
            {
                if (!string.IsNullOrEmpty(artista.Nome))
                    query += $" AND a.nome = '{artista.Nome}'";
            }
            return query;
        }
        */
    }
}
