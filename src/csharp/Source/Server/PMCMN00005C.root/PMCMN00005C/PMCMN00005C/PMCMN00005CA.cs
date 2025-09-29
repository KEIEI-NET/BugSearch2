using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Broadleaf.Library.Diagnostics
{
    /// <summary>
    /// �f�o�b�O���A�V�X�g����N���X�ł��B
    /// </summary>
    static public class NSDebug
    {
        /// <summary>
        /// ���ݎ��s���̃��\�b�h�����擾���܂��B
        /// </summary>
        /// <param name="stackframe">���s���̃��\�b�h��������<b>StackFrame</b></param>
        /// <returns>���s���̃��\�b�h��(�N���X��.���\�b�h��(�p�����[�^))</returns>
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

                    // �p�����[�^�̌^���̎擾
                    string paramTypeName = paramInfo.ParameterType.Name;

                    // �Q�Ɠn���`�F�b�N
                    if (paramInfo.ParameterType.IsByRef)
                    {
                        // �Q�ƌ^�p�����[�^�̏ꍇ�AParameterType.Name�ɂ� "Int32&" �ƌ���������
                        // "&"�����ɕt���Ă���̂ŁA�t���Ă��Ȃ��^���̂��擾
                        paramTypeName = paramInfo.ParameterType.GetElementType().Name;
                        parameter += (paramInfo.IsOut) ? "out " : "ref ";
                    }

                    // �W�F�l���b�N�^�`�F�b�N
                    if (paramInfo.ParameterType.IsGenericType)
                    {
                        // �W�F�l���b�N�^��< >���ɋL�q����Ă���^���̂��擾
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
        /// SqlCommand ���ɐݒ肳��Ă���SQL�R�}���h��p�����[�^�̓��e���擾���܂��B
        /// </summary>
        /// <param name="command">SqlCommand �I�u�W�F�N�g</param>
        /// <returns>SQL�R�}���h��p�����[�^�̓��e</returns>
        static public string GetSqlCommand(SqlCommand command)
        {
            string CommandText = string.Empty;

            CommandText += "------ �ϐ� ------" + Environment.NewLine;

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
