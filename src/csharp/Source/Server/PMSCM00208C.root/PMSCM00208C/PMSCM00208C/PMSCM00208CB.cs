using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �ȒP�⍇���ڑ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ȒP�⍇���ڑ����̃f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// </remarks>
    [Serializable]
    public class SimplInqCnectInfo
    {
        #region �� Constructor
        /// <summary>
        /// 
        /// </summary>
        public SimplInqCnectInfo()
        {

        }
        #endregion

        #region �� Private Member
        private int _cashRegisterNo;
        private int _customerCode;
        #endregion

        #region �� Property

        /// <summary>���W�ԍ��i�[���ԍ��j</summary>
        public int CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// <summary>���Ӑ�R�[�h</summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        #endregion
    }
}
