using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// �f�[�^���̓V�X�e���萔
    /// </summary>
    /// <remarks>
    /// �󒍃}�X�^�̃f�[�^���̓V�X�e���ɓo�^�����l�������܂��B
    /// </remarks>
    public enum DataInputSystem
    {
        /// <summary>0:����</summary>
        DC = 0,
        /// <summary>1:����</summary>
        SF = 1,
        /// <summary>2:��</summary>
        BK = 2,
        /// <summary>3:�Ԕ�</summary>
        CS = 3,
        /// <summary>10:�o�l</summary>
        PM = 10,
        /// <summary>11:�d��</summary>
        DN = 11,
        /// <summary>12:�Ɏq</summary>
        GL = 12,
        /// <summary>13:�q�b</summary>
        RC = 13
    }

    /// <summary>
    /// �`�[�f�[�^�敪�萔
    /// </summary>
    /// <remarks>
    /// �󒍃}�X�^�̎󒍃X�e�[�^�X��A�g���f�[�^�敪�ɓo�^�����l�������܂��B
    /// </remarks>
    public enum SlipDataDivide
    {
        /// <summary> 1:����</summary>
        Estimate = 1,
        /// <summary> 2:����</summary>
        SalesOrder = 2,
        /// <summary> 3:��</summary>
        AcceptAnOrder = 3,
        /// <summary> 4:����</summary>
        ArrivalGoods = 4, 
        /// <summary> 5:�o��</summary>
        Shipment = 5,
        /// <summary> 6:�d��</summary>
        Stock = 6,
        /// <summary> 7:����</summary>
        Sales = 7,
        /// <summary> 8:����</summary>
        Deposit = 8,
        /// <summary> 9:�x��</summary>
        Payment = 9,
        /*
        /// <summary>10:���וԕi</summary>
        ArrivalReturnedGoods = 10,
        /// <summary>11:�o�וԕi</summary>
        ShipmentReturnedGoods = 11,
        /// <summary>12:�d���ԕi</summary>
        StockReturnedGoods = 12,
        /// <summary>13:����ԕi</summary>
        SalesReturnedGoods = 13
        */
        // --- ADD 2013/02/13 ---------->>>>>
        // �d���ԕi�\��p�敪��ǉ�
        StockRetPlan = 14,
        // --- ADD 2013/02/13 ----------<<<<<
    }

    /// public class name:   AcceptOdrExtractWork
    /// <summary>
    ///                      �󒍒��o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �󒍒��o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AcceptOdrExtractWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�󒍔ԍ�</summary>
        private Int32 _acceptAnOrderNo;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>���ꂼ��̓`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>0:����,1:����,2:���,3:�Ԕ� 10:PM,11:�d��,12:�Ɏq,13:RC </remarks>
        private Int32 _dataInputSystem;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>���גʔ�</summary>
        private Int64 _slipDtlNum;

        /// <summary>���גʔԎ}��</summary>
        /// <remarks>0 �̏ꍇ�A�������גʔԂ������R�[�h�̒��ōł��傫�����גʔԎ}�Ԃ������R�[�h�𒊏o����B</remarks>
        private Int32 _slipDtlNumDerivNo;

        /// <summary>�A�g���f�[�^�敪</summary>
        /// <remarks>1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��</remarks>
        private Int32 _srcLinkDataCode;

        /// <summary>�A�g�����גʔ�</summary>
        private Int64 _srcSlipDtlNum;


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>���ꂼ��̓`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>0:����,1:����,2:���,3:�Ԕ� 10:PM,11:�d��,12:�Ɏq,13:RC </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>���ʒʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʒʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  SlipDtlNum
        /// <summary>���גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SlipDtlNum
        {
            get { return _slipDtlNum; }
            set { _slipDtlNum = value; }
        }

        /// public propaty name  :  SlipDtlNumDerivNo
        /// <summary>���גʔԎ}�ԃv���p�e�B</summary>
        /// <value>0 �̏ꍇ�A�������גʔԂ������R�[�h�̒��ōł��傫�����גʔԎ}�Ԃ������R�[�h�𒊏o����B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���גʔԎ}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipDtlNumDerivNo
        {
            get { return _slipDtlNumDerivNo; }
            set { _slipDtlNumDerivNo = value; }
        }

        /// public propaty name  :  SrcLinkDataCode
        /// <summary>�A�g���f�[�^�敪�v���p�e�B</summary>
        /// <value>1:���� 2:���� 3:�� 4:���� 5:�o�� 6:�d�� 7:���� 8:�ԕi 9:���� 10:�x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g���f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SrcLinkDataCode
        {
            get { return _srcLinkDataCode; }
            set { _srcLinkDataCode = value; }
        }

        /// public propaty name  :  SrcSlipDtlNum
        /// <summary>�A�g�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SrcSlipDtlNum
        {
            get { return _srcSlipDtlNum; }
            set { _srcSlipDtlNum = value; }
        }

        /// <summary>
        /// �󒍒��o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>AcceptOdrExtractWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AcceptOdrExtractWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AcceptOdrExtractWork()
        {
        }
    }
}
