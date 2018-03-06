public class SingleCase {
    #region �������̰߳�ȫ
    private static volatile SingleCase _instance;
    private static object _lock = new object();
    public static SingleCase singleCase {
        get {
            if (_instance == null) {
                lock (_lock) {
                    if (_instance == null)
                        _instance = new SingleCase();
                }
            }
            return _instance;
        }
    }

    private SingleCase() { }
    #endregion
}