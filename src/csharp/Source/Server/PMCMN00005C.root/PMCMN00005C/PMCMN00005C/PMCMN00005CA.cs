using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Broadleaf.Library.Diagnostics
{
    /// <summary>
    /// デバッグをアシストするクラスです。
    /// </summary>
    static public class NSDebug
    {
        /// <summary>
        /// 現在実行中のメソッド名を取得します。
        /// </summary>
        /// <param name="stackframe">実行中のメソッド情報を持つ<b>StackFrame</b></param>
        /// <returns>実行中のメソッド名(クラス名.メソッド名(パラメータ))</returns>
        static public string GetExecutingMethodName(System.Diagnostics.StackFrame stackframe)
        {
            System.Reflection.MethodBase methodbase = stackframe.GetMethod();

            string className = methodbase.ReflectedType.Name;
            string methodName = methodbase.Name;
            string parameter = "";

            foreach (System.Reflection.ParameterInfo paramInfo in methodbase.GetParameters())
            {
                if (paramInfo != null)
                {
                    if (parameter.Length != 0)
                    {
                        parameter += ", ";
                    }

                    // パラメータの型名称取得
                    string paramTypeName = paramInfo.ParameterType.Name;

                    // 参照渡しチェック
                    if (paramInfo.ParameterType.IsByRef)
                    {
                        // 参照型パラメータの場合、ParameterType.Nameには "Int32&" と言う感じで
                        // "&"が後ろに付いてくるので、付いてこない型名称を取得
                        paramTypeName = paramInfo.ParameterType.GetElementType().Name;
                        parameter += (paramInfo.IsOut) ? "out " : "ref ";
                    }

                    // ジェネリック型チェック
                    if (paramInfo.ParameterType.IsGenericType)
                    {
                        // ジェネリック型の< >内に記述されている型名称を取得
                        paramTypeName = paramInfo.ParameterType.GetGenericArguments()[0].Name;
                        parameter += "List<" + paramTypeName + ">";
                    }
                    else
                    {
                        parameter += paramTypeName;
                    }

                    parameter += " " + paramInfo.Name;
                }
            }

            return string.Format("{0}.{1}({2})", className, methodName, parameter);
        }

        /// <summary>
        /// SqlCommand 内に設定されているSQLコマンドやパラメータの内容を取得します。
        /// </summary>
        /// <param name="command">SqlCommand オブジェクト</param>
        /// <returns>SQLコマンドやパラメータの内容</returns>
        static public string GetSqlCommand(SqlCommand command)
        {
            string CommandText = string.Empty;

            CommandText += "------ 変数 ------" + Environment.NewLine;

            foreach (SqlParameter param in command.Parameters)
            {
                string sqlDbType = param.SqlDbType.ToString();

                if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar ||
                    param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                {
                    sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                }

                string value = param.Value.ToString();

                if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar ||
                    param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                {
                    value = string.Format("'{0}'", param.Value);
                }

                CommandText += string.Format("DECLARE {0} {1}\r\n", param.ParameterName, sqlDbType);
                CommandText += string.Format("SET {0} = {1}\r\n", param.ParameterName, value);
                CommandText += Environment.NewLine;
            }

            CommandText += "------ SQL ------" + Environment.NewLine;
            CommandText += command.CommandText;

            return CommandText;
        }
    }
}
