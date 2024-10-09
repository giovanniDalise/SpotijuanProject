using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotijuan.Dao.Dao;
using Spotijuan.Dao.Dto;

namespace Spotijuan.Test
{
   
    [TestClass]
    public class TestUtente : TestAbstract<Utente>
    {
        [TestMethod]
        protected override IDao<Utente> GetDao() { return new DaoUtenti(); }
    /* 
        [TestMethod]
        protected override Utente GetElementCreate()
        {
            return new Utente(0, "Gennaro", "Esposito", "gennaroesposito@gmail.com", "genny88", "lamiapasswordsicura", DateTime.Parse("1988-10-10 02:00:00"), new List<Canzone>());
        }
      
        [TestMethod]
        protected override int GetIdDelete()
        {
            IDao<Utente> dao = GetDao();
            Utente nuovoUtente = new Utente(0, "Gennaro", "Esposito", "gennaroesposito@gmail.com", "genny88", "lamiapasswordsicura", DateTime.Parse("1988-10-10 02:00:00"), new List<Canzone>());
            int id = dao.Create(nuovoUtente);
            return id;
        }
       
        [TestMethod]
        protected override Utente GetElementFindById()
        {
            return new Utente(0, "Gustavo", "Ghiotti", "gustavoghiotti@gmail.com", "gustavoon", "gostarda88", DateTime.Parse("2023-03-03 01:00:00"), new List<Canzone>());
        }
        [TestMethod]
        protected override int GetIdFind()
        {
            return 1;
        }
       
        [TestMethod]
        protected override List<Utente> GetListFindByText() {
            List<Utente> lista = new List<Utente>();
            lista.Add(new Utente(0, "Gustavo", "Ghiotti", "gustavoghiotti@gmail.com", "gustavoon", "gostarda88", DateTime.Parse("2023-03-03 01:00:00"), new List<Canzone>()));
            lista.Add(new Utente(0, "Mario", "IlBiottiondo", "mariosibell@gmail.com", "marione", "mariopsw", DateTime.Parse("2022-09-09 02:00:00"), new List<Canzone>()));
            return lista;
        }
        [TestMethod]
        protected override string GetText()
        {
            return "iott";
        }
        

        [TestMethod]
        protected override Utente GetElementUpdate()
        {
            return new Utente(4, "Mimma", "Daniela", "sorammimm@gmail.com", "mimma88", "lamimmpassvuord", DateTime.Parse("1981-11-10 06:00:00"), new List<Canzone>());
        }

        [TestMethod]
        protected override int GetIdUpdate()
        {
            return 4;
        }
     
        [TestMethod]
        protected override List<Utente> GetListFindByObject()
        {
            List<Utente> lista = new List<Utente>();
            lista.Add(new Utente(0, "Gustavo", "Ghiotti", "gustavoghiotti@gmail.com", "gustavoon", "gostarda88", DateTime.Parse("2023-03-03 01:00:00"), new List<Canzone>()));
            lista.Add(new Utente(0, "Mario", "IlBiottiondo", "mariosibell@gmail.com", "marione", "mariopsw", DateTime.Parse("2022-09-09 02:00:00"), new List<Canzone>()));
            lista.Add(new Utente(0, "Gennaro", "Singapore", "singasongosang@gmail.com", "ocines", "cino88", DateTime.Parse("2000-02-02 01:00:00"), new List<Canzone>()));
            return lista;
        }
        [TestMethod]
        protected override Utente GetElementFindByObject() //ricorda che questo utente deve avere caratteristiche con gli altri utente per ricavare la lista dal dao con cui fare il confronto con quelli attesi sopra
        {
            return new Utente(0, "Gustavo", "IlBiottiondo", "gustavoghiotti@gmail.com", "ocines", "gostarda88", DateTime.Parse("2023-03-03 02:00:00"), new List<Canzone>());
        }
    */
    }

}