using System;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// List ユーティリティクラス
    /// </summary>
    public class ListUtils
    {
        /// <summary>検索パターン Find() で使用</summary>
        public enum FindType
        {
            /// <summary>クラス</summary>
            Class,
            /// <summary>Array</summary>
            Array
        }

        /// <summary>
        /// CustomArrayList から指定した型のオブジェクトを取得する
        /// </summary>
        /// <param name="paramArray">検査対象パラメータList</param>
        /// <param name="type">検索対象タイプ</param>
        /// <param name="pattern">検索パターン</param>
        /// <param name="position">パラメータ位置</param>
        /// <returns>オブジェクト</returns>
        public static object Find(ArrayList paramArray, Type type, FindType pattern, out int position)
        {
            object result = null;

            position = -1;

            if (IsNotEmpty(paramArray))
            {
                //パラメータを取得
                if (pattern == FindType.Class)
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] != null && paramArray[i].GetType() == type)
                        {
                            result = paramArray[i];
                            position = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] is ArrayList)
                        {
                            ArrayList al = paramArray[i] as ArrayList;
                            if (al != null && al.Count > 0)
                            {
                                if (al[0] != null && al[0].GetType() == type)
                                {
                                    result = paramArray[i];
                                    position = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// CustomArrayList から指定した型のオブジェクトを取得する
        /// </summary>
        /// <param name="paramArray">検査対象パラメータList</param>
        /// <param name="type">検索対象タイプ</param>
        /// <param name="pattern">検索パターン</param>
        /// <returns>オブジェクト</returns>
        public static object Find(ArrayList paramArray, Type type, FindType pattern)
        {
            int position;
            return Find(paramArray, type, pattern, out position);
        }

        /// <summary>
        /// ArrayListが空かどうかを判断する
        /// </summary>
        /// <param name="al">検査対象ArrayList</param>
        /// <returns>true:空 false:空でない</returns>
        public static bool IsEmpty(ArrayList al)
        {
            if (al == null || al.Count <= 0) return true;
            return false;
        }

        /// <summary>
        /// ArrayListが空かどうかを判断する
        /// </summary>
        /// <param name="al">検査対象ArrayList</param>
        /// <returns>true:空でない false:空</returns>
        public static bool IsNotEmpty(ArrayList al)
        {
            return !IsEmpty(al);
        }
    }
}
