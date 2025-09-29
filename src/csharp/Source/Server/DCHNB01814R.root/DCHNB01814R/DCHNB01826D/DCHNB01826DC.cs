using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// 売上データ用共通関数
    /// </summary>
    public static class SalesTool
    {
        /// <summary>
        /// 文字を数値(Int64)に変換します、変換に失敗した場合はデフォルト値を返します。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static Int64 StrToIntDef(string s, Int64 defaultvalue)
        {
            Int64 result = defaultvalue;
            
            try
            {
                result = Int64.Parse(s);
            }
            catch
            {

            }

            return result;
        }
    }
}