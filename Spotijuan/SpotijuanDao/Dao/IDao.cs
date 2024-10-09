namespace Spotijuan.Dao.Dao
{
    public interface IDao <T>
    {
              List<T> Read();
        //       int Create(T element);
        //       void Delete(int id);
        //       T FindById(int id);
        //       List<T> FindByText(string text);
        //       void Update(T element, int id);
        //       List<T> FindByObject(T element);
    }
}
