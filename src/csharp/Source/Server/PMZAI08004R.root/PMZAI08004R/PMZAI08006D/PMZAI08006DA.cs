using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePStockMoveSlipWork
    /// <summary>
    ///                      ���R���[�݌Ɉړ��`�[�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�݌Ɉړ��`�[�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   22018 ��ؐ��b</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePStockMoveSlipParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[�L�[���X�g</summary>
        private List<FrePStockMoveSlipParaKey> _frePStockMoveSlipParaKeyList;

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
        public List<FrePStockMoveSlipParaKey> FrePStockMoveSlipParaKeyList
        {
            get { return _frePStockMoveSlipParaKeyList; }
            set { _frePStockMoveSlipParaKeyList = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FrePStockMoveSlipParaWork()
        {
        }

        # region [�`�[�L�[�\����]
        /// <summary>
        /// ���R���[�i�݌Ɉړ��`�[�j�L�[�\����
        /// </summary>
        [Serializable]
        public struct FrePStockMoveSlipParaKey
        {
            /// <summary>�݌Ɉړ��`��</summary>
            private Int32 _stockMoveFormal;
            /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
            private Int32 _stockMoveSlipNo;
            /// <summary>
            /// �݌Ɉړ��`��
            /// </summary>
            /// <remarks>1:�݌Ɉړ��A2�F�q�Ɉړ�</remarks>
            public Int32 StockMoveFormal
            {
                get { return _stockMoveFormal; }
                set { _stockMoveFormal = value; }
            }
            /// <summary>
            /// �݌Ɉړ��`�[�ԍ�
            /// </summary>
            public Int32 StockMoveSlipNo
            {
                get { return _stockMoveSlipNo; }
                set { _stockMoveSlipNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="stockMoveFormal">�݌Ɉړ��`��(1:�݌Ɉړ��A2�F�q�Ɉړ�)</param>
            /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
            public FrePStockMoveSlipParaKey( Int32 stockMoveFormal, Int32 stockMoveSlipNo )
            {
                _stockMoveFormal = stockMoveFormal;
                _stockMoveSlipNo = stockMoveSlipNo;
            }
        }
        # endregion
    }

}
