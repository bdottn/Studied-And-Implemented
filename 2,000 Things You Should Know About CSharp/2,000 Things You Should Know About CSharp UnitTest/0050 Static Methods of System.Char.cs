using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    // Reference：http://csharp.2000things.com/2010/08/06/50-static-methods-of-system-char/

    [TestClass]
    public class Static_Methods_of_System_Char
    {
        /*
         * The System.Char class has a large number of static methods that serve as utility methods for getting information about individual characters.
         * 
         * System.Char 有大量用於獲取單個字符訊息的靜態方法
         */
        [TestMethod]
        public void Static_Methods_of_System_Char_Implement()
        {
            // 將指定的數字 Unicode 字元轉換成雙精確度浮點數。
            char c = '2';
            double d = char.GetNumericValue(c);

            // 將指定的 Unicode 字元分類至由其中一個 System.Globalization.UnicodeCategory 值所識別的群組。
            UnicodeCategory cat = char.GetUnicodeCategory('a');     // LowercaseLetter
            cat = char.GetUnicodeCategory('+');     // MathSymbol
            cat = char.GetUnicodeCategory('6');     // DecimalDigitNumber

            // Check for control characters
            // 指示指定的 Unicode 字元是否分類為控制字元。
            bool isCtrl = char.IsControl('a');      // false
            isCtrl = char.IsControl('\t');          // true

            // Check for digits
            // 指示指定的 Unicode 字元是否分類為十進位數字。
            bool isDigit = char.IsDigit('a');       // false
            isDigit = char.IsDigit('3');            // true

            // Check for letters
            // 表示指定的 Unicode 字元是否分類為 Unicode 字母。
            bool isLetter = char.IsLetter('%');     // false
            isLetter = char.IsLetter('P');          // true
            isLetter = char.IsLetter('ǽ');          // true

            // 表示指定的 Unicode 字元是否分類為字母或十進位數字。
            bool lord = char.IsLetterOrDigit('j');  // true

            // Check for lower/upper case
            // 指示指定的 Unicode 字元是否分類為小寫字母。
            bool low = char.IsLower('j');           // true
            low = char.IsLower('Y');                // false
            // 指示指定的 Unicode 字元是否分類為大寫字母。
            bool upper = char.IsUpper('Ǻ');         // true

            // Check for numbers
            // 指示指定的 Unicode 字元是否分類為數字。
            bool isnum = char.IsNumber('4');        // true
            isnum = char.IsNumber('௧');             // true
            isnum = char.IsNumber('X');             // false

            // Other
            // 指示指定的 Unicode 字元是否分類為標點符號。
            bool ispunc = char.IsPunctuation('?');  // true
            // 指示指定的 Unicode 字元是否分類為分隔符號字元。
            bool issep = char.IsSeparator(' ');     // true
            // 指示指定的 Unicode 字元是否分類為符號字元。
            bool issymbol = char.IsSymbol('$');     // true

            // Unicode
            // 指出指定的字元是否有 Surrogate 字碼單位。
            bool issur = char.IsSurrogate('\xd840');         // true
            // 指出指定的 System.Char 物件是否為低 Surrogate。
            bool islow = char.IsLowSurrogate('\xd840');    // false
            // 指出指定的 System.Char 物件是否為高 Surrogate。
            bool ishigh = char.IsHighSurrogate('\xd840');  // true

            // Conversion
            // 將 Unicode 字元值轉換成它的對等大寫。
            char upp = char.ToUpper('a');       // A
            // 將 Unicode 字元值轉換成它的對等小寫。
            char lower = char.ToLower('a');     // a
            lower = char.ToLower('Y');          // y
        }
    }
}