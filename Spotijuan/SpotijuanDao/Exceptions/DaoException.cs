namespace Spotijuan.Dao.Exceptions
{
    public class DaoException : Exception
    {
        public DaoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
