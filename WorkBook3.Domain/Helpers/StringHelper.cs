using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBook3.Domain.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// 改行ありのデータをListに変換する。空行は除去する
        /// </summary>
        /// <param name="data">改行ありの文字列</param>
        /// <returns>改行で区切ったリスト</returns>
        public static List<string> GetList(string data)
        {
            var datas = data.Split('\n');
            var list = new List<string>(datas);
            list.RemoveAll(s => s == string.Empty);
            return list;
        }
    }
}
