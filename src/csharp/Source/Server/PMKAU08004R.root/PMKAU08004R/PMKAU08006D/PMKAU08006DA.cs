using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      ���R���[�������f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�������f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   22018 ��ؐ��b</br>
    /// <br>Date             :   2008/6/12</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.15  22018 ��� ���b</br>
    /// <br>           : ������(����)�ɑΉ�����ׁA�ύX�B</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePBillParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[������(50:���v������,60:���א�����,70:�`�[���v������,80:�̎���)</summary>
        private int _slipPrtKind;
        /// <summary>�����L�[���X�g</summary>
        private List<FrePBillParaKey> _frePBillParaKeyList;
        // --- ADD m.suzuki 2010/02/15 ---------->>>>>
        /// <summary>���Ӑ摍���g�p�t���O</summary>
        private bool _useSumCust;
        // --- ADD m.suzuki 2010/02/15 ----------<<<<<

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �`�[������ (50:���v������,60:���א�����,70:�`�[���v������,80:�̎���)
        /// </summary>
        public int SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }
        /// <summary>
        /// �������L�[���X�g
        /// </summary>
        public List<FrePBillParaKey> FrePBillParaKeyList
        {
            get 
            {
                if ( _frePBillParaKeyList == null )
                {
                    _frePBillParaKeyList = new List<FrePBillParaKey>();
                }
                return _frePBillParaKeyList; 
            }
            set { _frePBillParaKeyList = value; }
        }
        // --- ADD m.suzuki 2010/02/15 ---------->>>>>
        /// <summary>
        /// ���Ӑ摍���g�p�t���O
        /// </summary>
        public bool UseSumCust
        {
            get { return _useSumCust; }
            set { _useSumCust = value; }
        }
        // --- ADD m.suzuki 2010/02/15 ----------<<<<<

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FrePBillParaWork()
        {
        }

        # region [�������L�[�\����]
        /// <summary>
        /// �������L�[�\����
        /// </summary>
        [Serializable]
        public struct FrePBillParaKey
        {
            /// <summary>�v�㋒�_�R�[�h</summary>
            private string _addUpSecCode;
            /// <summary>������R�[�h</summary>
            private int _claimCode;
            /// <summary>���ы��_�R�[�h</summary>
            private string _resultsSectCd;
            /// <summary>���Ӑ�R�[�h</summary>
            private int _customerCode;
            /// <summary>�v��N����</summary>
            private DateTime _addUpDate;
            /// <summary>
            /// �v�㋒�_�R�[�h
            /// </summary>
            /// <remarks>99</remarks>
            public string AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }
            /// <summary>
            /// ������R�[�h
            /// </summary>
            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            /// <summary>
            /// ���ы��_�R�[�h
            /// </summary>
            public string ResultsSectCd
            {
                get { return _resultsSectCd; }
                set { _resultsSectCd = value; }
            }
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// �v��N����
            /// </summary>
            /// <remarks>yyyymmdd</remarks>
            public DateTime AddUpDate
            {
                get { return _addUpDate; }
                set { _addUpDate = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
            /// <param name="claimCode">������R�[�h</param>
            /// <param name="resultsSectCd">���ы��_�R�[�h</param>
            /// <param name="customerCode">���Ӑ�R�[�h</param>
            /// <param name="addUpDate">�v��N����</param>
            public FrePBillParaKey( string addUpSecCode, int claimCode, string resultsSectCd, int customerCode, DateTime addUpDate )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
                _resultsSectCd = resultsSectCd;
                _customerCode = customerCode;
                _addUpDate = addUpDate;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
            /// <param name="claimCode">������R�[�h</param>
            /// <param name="resultsSectCd">���ы��_�R�[�h</param>
            /// <param name="customerCode">���Ӑ�R�[�h</param>
            /// <param name="addUpDate">�v��N����</param>
            public FrePBillParaKey( string addUpSecCode, int claimCode, string resultsSectCd, int customerCode, int addUpDate )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
                _resultsSectCd = resultsSectCd;
                _customerCode = customerCode;
                _addUpDate = GetDateTime( addUpDate );
            }
            /// <summary>
            /// �v��N����LongDate�擾
            /// </summary>
            /// <returns></returns>
            public int GetAddUpDateLongDate()
            {
                return (_addUpDate.Year * 10000 + _addUpDate.Month * 100 + _addUpDate.Day);
            }
            /// <summary>
            /// �v��N����LongDate�Z�b�g
            /// </summary>
            /// <param name="longDate"></param>
            public void SetAddUpDateLongDate( int longDate )
            {
                _addUpDate = GetDateTime( longDate );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public string CreateKey()
            {
                return string.Format( "{0}-{1:D8}-{2}-{3:D8}-{4:yyyyMMdd}", _addUpSecCode, _claimCode, _resultsSectCd, _customerCode, _addUpDate );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            /// <summary>
            /// ���t�ϊ�����
            /// </summary>
            /// <param name="longDate"></param>
            /// <returns></returns>
            private static DateTime GetDateTime( int longDate )
            {
                try
                {
                    return new DateTime( longDate / 10000, (longDate / 100) % 100, longDate % 100 );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }
        # endregion
    }

}
