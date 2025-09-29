//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : DataTime�֘A�̋��ʏ������������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// DateTime���[�e�B���e�B
    /// </summary>
    public static class DateTimeUtil
    {
        /// <summary>�f�t�H���g�̓��t�t�H�[�}�b�g</summary>
        public const string DEFAULT_DATE_TIME_FORMAT = "yyyy/MM/dd";

        /// <summary>�f�t�H���g�̊J�n����</summary>
        public const string DEFAULT_FROM_TIME = "00:00:00";

        /// <summary>�f�t�H���g�̏I������</summary>
        public const string DEFAULT_TO_TIME = "23:59:59";

        /// <summary>
        /// DateTime�^�̓��t�ɕϊ����܂��B
        /// </summary>
        /// <param name="yyyyMMdd">int�^�̓��t</param>
        /// <returns>DateTime�^�̓��t</returns>
        public static DateTime ToDateTime(int yyyyMMdd)
        {
            const string DATE_TIME_FORMAT = "yyyyMMdd";
            return Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(DATE_TIME_FORMAT, yyyyMMdd);
        }

        /// <summary>
        /// long�^�̓����ɕϊ����܂��B
        /// </summary>
        /// <param name="dateTime">DateTime�^�̓���</param>
        /// <returns>long�^�̓���</returns>
        public static long ToLong(DateTime dateTime)
        {
            return (long)Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate(dateTime);
        }

        /// <summary>
        /// �����ɕs�������邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �J�n���t�ƏI�����t�̊��Ԃ�3�����𒴂���ꍇ�A�G���[�Ƃ݂Ȃ��܂��B
        /// </remarks>
        /// <param name="from">�J�n����</param>
        /// <param name="to">�I������</param>
        /// <returns>true :����<br/>false:�Ȃ�</returns>
        public static bool HasError(
            DateTime from,
            DateTime to
        )
        {
            if (from > to) return true;

            DateTime fromDate   = new DateTime(from.Year, from.Month, from.Day);
            DateTime maxDate    = fromDate.AddMonths(3);

            DateTime toDate = new DateTime(to.Year, to.Month, to.Day);
            if (toDate > maxDate) return true;

            return false;
        }

        /// <summary>
        /// �~���̔�r�҃N���X
        /// </summary>
        public class ReverseComparer : IComparer<DateTime>
        {
            #region IComparer<DateTime> �����o

            /// <summary>
            /// ��r���܂��B
            /// </summary>
            /// <param name="x">����</param>
            /// <param name="y">�E��</param>
            /// <returns>
            /// <c>x < y</c> :<c>1</c><br/>
            /// <c>x > y</c> :<c>-1</c><br/>
            /// <c>x == y</c>:<c>0</c>
            /// </returns>
            public int Compare(DateTime x, DateTime y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }

            #endregion

            #region <Constructor/>

            /// <summary>
            /// �f�t�H���g�R���X�g���N�^
            /// </summary>
            public ReverseComparer() { }

            #endregion  // <Constructor/>
        }
    }

    /// <summary>
    /// �A�Z���u�����[�e�B���e�B
    /// </summary>
    public static class AssemblyUtil
    {
        /// <summary>
        /// ���̂��擾���܂��B
        /// </summary>
        /// <param name="assembly">�A�Z���u��</param>
        /// <returns>����</returns>
        public static string GetName(Assembly assembly)
        {
            string[] fullNames = assembly.FullName.Split(',');
            return fullNames[0];
        }
    }
}
