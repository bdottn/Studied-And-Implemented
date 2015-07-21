namespace ConsoleApplicationClassLibrary
{
    public class ConstantClass
    {
        public static readonly int BeginNumber = 0;

        public const int EndNumber = 10;

        // 變更設定值，建置類別庫後產生 dll，抽換 ConsoleApplication 的 dll 檔案
        // public static readonly int BeginNumber = 9;

        // public const int EndNumber = 20;
    }
}