using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotijuan.Dao.Dao;
using Spotijuan.Dao.Exceptions;
using System.Configuration;

namespace Spotijuan.Test
{
    [TestClass]
    public abstract class TestAbstract<T>
    {
        IDao<T> dao;
        [TestInitialize]
        public void Initialize()
        {
            // Sostituisci la stringa di connessione con la tua effettiva stringa di connessione
            string connectionString = ConfigurationManager.ConnectionStrings["SPOTIJUAN"].ConnectionString;

            dao = GetDao();

        }
        [TestMethod]
        public void TestRead()
        {          
            try
            {
                dao.Read();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Errore nel metodo read. Generata eccezione: {ex.Message}");
            }

        }
        /*
         [TestMethod]
         public void TestCreate()
         {
             T element = GetElementCreate();

             Assert.IsTrue(dao.Create(element) > 0, "Errore nel metodo create. Generata Exception");

             var result = dao.Read();
             Console.WriteLine("Risultati da dao.Read():");
             CollectionAssert.Contains(result, element, "Errore nel metodo create. Dati non corretti");
         }

         [TestMethod]
         public void TestDelete()
         {
             int id = GetIdDelete();

             try
             {
                 dao.Delete(id);
                 Assert.IsNull(dao.FindById(id), "Il record non è stato cancellato correttamente.");
             }
             catch (Exception ex)
             {
                 Assert.Fail($"Errore nel metodo delete: {ex.Message}");
             }
         }

         [TestMethod]
         public void TestFindById()
         {
             try
             {
                 T expected = GetElementFindById();
                 int id = GetIdFind();

                 // Chiamata al metodo senza assert specifico per "non generare eccezioni"
                 T actual = dao.FindById(id);

                 // Assert per verificare i dati
                 Assert.AreEqual(expected, actual, "Errore nel metodo FindById. Dati non corretti");
             }
             catch (Exception ex)
             {
                 Assert.Fail($"Il metodo FindById ha generato non prevista: {ex.Message}");
             }
         }

         [TestMethod]
         public void TestFindByText()
         {
             List<T> expected = GetListFindByText();
             string text = GetText();

             try
             {
                 List<T> actual = dao.FindByText(text);

                 // Verifica se la chiamata al metodo FindByText ha generato un'eccezione
                 Assert.IsNotNull(actual, "Errore nel metodo FindByText. Generata Exception");

                 // Verifica se i risultati attesi contengono tutti gli elementi effettivi
                 foreach (T t in expected)
                 {
                     Assert.IsTrue(actual.Contains(t), "Errore nel metodo FindByText. Dati non corretti");
                 }

                 // Verifica se gli elementi effettivi contengono tutti quelli attesi
                 foreach (T t in actual)
                 {
                     Assert.IsTrue(expected.Contains(t), "Errore nel metodo FindByText. Dati non corretti");
                 }
             }
             catch (Exception ex)
             {
                 Assert.Fail($"Errore nel metodo FindByText: {ex.Message}");
             }

         }
         [TestMethod]
         public void TestUpdate()
         {
             T element = GetElementUpdate();
             int id = GetIdUpdate();

             try
             {
                 // Chiamata al metodo senza assert specifico per "non generare eccezioni"
                 dao.Update(element, id);

                 // Assert per verificare i dati
                 T actual = dao.FindById(id);
                 Assert.AreEqual(element, actual, "Errore nel metodo update. Dati non corretti");
             }
             catch (Exception ex)
             {
                 Assert.Fail($"Il metodo Update ha generato un'eccezione non prevista: {ex.Message}");
             }
         }

         [TestMethod]
         public void TestFindByObject()
         {
             T element = GetElementFindByObject();
             List<T> expected = GetListFindByObject();

             // Verifica che il metodo findByObject non generi un'eccezione
             try
             {
                 dao.FindByObject(element);
             }
             catch (Exception)
             {
                 Assert.Fail("Errore nel metodo findByObject. Generata Exception");
             }

             List<T> actual = dao.FindByObject(element);

             // Verifica che ogni elemento atteso sia presente nella lista reale
             foreach (T t in expected)
             {
                 Assert.IsTrue(actual.Contains(t), "Errore nel metodo findByObject. Dati non corretti");
             }

             // Verifica che ogni elemento reale sia presente nella lista attesa
             foreach (T t in actual)
             {
                 Assert.IsTrue(expected.Contains(t), "Errore nel metodo findByObject. Dati non corretti");
             }
         }
        */
         protected abstract IDao<T> GetDao(); 
        /*
         protected abstract List<T> GetListFindByObject();
         protected abstract T GetElementFindByObject();

         protected abstract int GetIdUpdate();
         protected abstract T GetElementUpdate();

         protected abstract T GetElementCreate();
         protected abstract int GetIdDelete();

         protected abstract T GetElementFindById();
         protected abstract int GetIdFind();

         protected abstract string GetText();
         protected abstract List<T> GetListFindByText();
      */
    }
}