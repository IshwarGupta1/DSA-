namespace Singleton
{
    public class HashInstance
    {
        private static HashInstance _hashInstance;
        private HashInstance() { 
        }
        public static HashInstance getInstance()
        {
            if( _hashInstance == null )
                _hashInstance = new HashInstance();
            return _hashInstance;
        }
    }
}
