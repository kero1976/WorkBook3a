namespace WorkBook3.Domain.Helpers
{
    public static class PaddingHelper
    {
        /// <summary>
        /// データを固定長に整形する(中間値は0で埋める).
        /// </summary>
        /// 例) Noが2で固定文字が1,`、サイズが6の場合は、100002
        /// <param name="fix">先頭に付与する固定文字</param>
        /// <param name="no">値</param>
        /// <param name="size">文字列の長さ</param>
        /// <returns>固定長文字</returns>
        public static string GetData(string fix, int no, int size)
        {
            // noを文字型に変換
            string strNo = no.ToString();

            string result = fix + strNo.PadLeft(size - fix.Length, '0');
            if (result.Length == size)
            {
                return result;
            }
            if (strNo.Length == size)
            {
                return strNo;
            }
            return strNo.Substring(strNo.Length - size);
        }
    }
}
