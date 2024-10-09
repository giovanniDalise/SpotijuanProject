using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotijuan.Dao.Dao;
using Spotijuan.Dao.Dto;

namespace Spotijuan.Test
{
    [TestClass]
    public class TestArtista : TestAbstract<Artista>
    {
        [TestMethod]
        protected override IDao<Artista> GetDao() { return new DaoArtisti(); }
        /*
        [TestMethod]
        protected override Artista GetElementCreate()
        {
            return new Artista(0, "Sting", new List<string>());
        }
        [TestMethod]
        protected override int GetIdDelete()
        {
            IDao<Artista> dao = GetDao();
            Artista nuovoArtista = new Artista(0, "Elliott Smith", new List<string>());
            int id = dao.Create(nuovoArtista);
            return id;
        }
        [TestMethod]
        protected override Artista GetElementFindById()
        {
            return new Artista(0,"Talk Talk",new List<string> {"Post Rock"});
        }
        [TestMethod]
        protected override int GetIdFind()
        {
            return 1;
        }
        [TestMethod]
        protected override List<Artista> GetListFindByText()
        {
            List<Artista> lista = new List<Artista>();
            lista.Add(new Artista(0, "Burzum", new List<string>()));
            lista.Add(new Artista(0, "Gurzum", new List<string>()));
            return lista;
        }
        [TestMethod]
        protected override string GetText()
        {
            return "urzu";
        }
        [TestMethod]
        protected override Artista GetElementUpdate()
        {
            return new Artista(6,"Elliott Smith", new List<string>());
        }
        [TestMethod]
        protected override int GetIdUpdate()
        {
            return 4;
        }
        [TestMethod]
        protected override List<Artista> GetListFindByObject()
        {
            List<Artista> lista = new List<Artista>();
            lista.Add(new Artista(0, "Burzum", new List<string>()));
            return lista;
        }
        [TestMethod]
        protected override Artista GetElementFindByObject()
        {
            return new Artista(0, "Burzum", new List<string>());
        }
        */
    }  
}
