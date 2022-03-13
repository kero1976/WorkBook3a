using NUnit.Framework;
using System.IO;
using WorkBook3.Domain.Helpers;

namespace WorkBook3Test.Tests
{
    public abstract class TestBase
    {
        public string BaseDir { get; }

        /// <summary>
        /// テストデータが置かれているフォルダを指定する.
        /// </summary>
        /// <param name="dir">テストデータが置かれている「テストデータ」以下のディレクトリ</param>
        public TestBase(string dir)
        {
            BaseDir = dir;
        }
        private string GetTestDir()
        {
            return FilePathHelper.GetFullPath(Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                @"..\..\..\",
                "テストデータ",
                BaseDir).ToString());
        }

        public string GetTestFile(string filePath)
        {
            return Path.Combine(GetTestDir(), filePath);
        }
    }
}
