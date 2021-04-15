using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgCompresser.Classess
{
    public static class ExtenstionMethd
    {
        private static readonly string _r_n = "\r\n";

        /// <summary>
        /// 居中填充
        /// </summary>
        /// <param name="str"></param>
        /// <param name="totalWidth">填充后的总长度，强迫症患者请使用偶数</param>
        /// <param name="paddingChar">填充字符（默认为空格）</param>
        /// <returns></returns>
        public static string PadCenter(this string str, int totalWidth, char paddingChar = ' ')
        {
            return str.Length > totalWidth ? str :
                str.PadLeft( (totalWidth - str.Length)/2 + str.Length, paddingChar).PadRight(totalWidth, paddingChar);
        }

        /// <summary>
        /// 回车换行
        /// </summary>
        /// <param name="str"></param>
        /// <param name="line">行数（默认一行）</param>
        /// <returns></returns>
        public static string EnterLine(this string str, int line = 1)
        {
            for (int i = 0; i < line; i++)
                str += _r_n;
            return str;
        }
    }
}
