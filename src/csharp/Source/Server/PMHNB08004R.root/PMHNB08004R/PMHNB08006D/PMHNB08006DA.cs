using System;
using System.Collections;

//using Broadleaf.Library.Data; // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      ���R���[����`�[�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[����`�[�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   22018 ��ؐ��b</br>
    /// <br>Date             :   2008/5/30</br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePSalesSlipParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[�L�[���X�g</summary>
        private List<FrePSalesSlipParaKey> _frePSalesSlipParaKeyList;
        
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �`�[�L�[���X�g
        /// </summary>
        public List<FrePSalesSlipParaKey> FrePSalesSlipParaKeyList
        {
            get { return _frePSalesSlipParaKeyList; }
            set { _frePSalesSlipParaKeyList = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FrePSalesSlipParaWork()
        {
        }

        # region [�`�[�L�[�\����]
        /// <summary>
        /// ���R���[�i����`�[�j�L�[�\����
        /// </summary>
        [Serializable]
        public struct FrePSalesSlipParaKey
        {
            private int _acptAnOdrStatus;
            private string _salesSlipNum;

            /// <summary>
            /// �󒍃X�e�[�^�X
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// ����`�[�ԍ�
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus"></param>
            /// <param name="salesSlipNum"></param>
            public FrePSalesSlipParaKey(int acptAnOdrStatus, string salesSlipNum)
            {
                _acptAnOdrStatus = acptAnOdrStatus;
                _salesSlipNum = salesSlipNum;
            }
        }
        # endregion
    }

}
