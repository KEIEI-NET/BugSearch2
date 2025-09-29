using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// ����f�[�^�p���ʊ֐�
    /// </summary>
    public static class SalesTool
    {
        /// <summary>
        /// �����𐔒l(Int64)�ɕϊ����܂��A�ϊ��Ɏ��s�����ꍇ�̓f�t�H���g�l��Ԃ��܂��B
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