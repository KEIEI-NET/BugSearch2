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
    ///                      ���R���[UOE�`�[�⑫�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[UOE�`�[�⑫�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   22018 ��ؐ��b</br>
    /// <br>Date             :   2008/11/19</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePUOESlipParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�t�n�d�`�[�P�ʃf�[�^���X�g</summary>
        private List<FrePUOESlipParaUnitWork> _uoeSlipParaUnitList;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �t�n�d�`�[�P�ʃf�[�^���X�g
        /// </summary>
        public List<FrePUOESlipParaUnitWork> UOESlipParaUnitList
        {
            get { return _uoeSlipParaUnitList; }
            set { _uoeSlipParaUnitList = value; }
        }
       
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FrePUOESlipParaWork()
        {
        }

        # region [�t�n�d�`�[�P�ʃf�[�^]
        /// <summary>
        /// �t�n�d�`�[�P�ʃf�[�^
        /// </summary>
        [Serializable]
        [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
        public class FrePUOESlipParaUnitWork
        {
            /// <summary>�`�[</summary>
            private FrePSalesSlipWork _slipWork;
            /// <summary>���׃��X�g</summary>
            private List<FrePSalesDetailWork> _detailWorkList;
            ///// <summary>�⑫���</summary>
            //private object _extraData;

            /// <summary>
            /// �`�[���X�g
            /// </summary>
            public FrePSalesSlipWork SlipWork
            {
                get { return _slipWork; }
                set { _slipWork = value; }
            }
            /// <summary>
            /// ���׃��X�g
            /// </summary>
            public List<FrePSalesDetailWork> DetailWorkList
            {
                get { return _detailWorkList; }
                set { _detailWorkList = value; }
            }
            ///// <summary>
            ///// �⑫���
            ///// </summary>
            //public object ExtraData
            //{
            //    get { return _extraData; }
            //    set { _extraData = value; }
            //}

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public FrePUOESlipParaUnitWork()
            {
            }
        }
        # endregion
    }
}
