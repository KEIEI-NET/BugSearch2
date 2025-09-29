using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcRetGdsSlipTtlDataWork
    /// <summary>
    ///                      �d���ԕi�`�[(�ӕ�)�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���ԕi�`�[(�ӕ�)�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/02/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcRetGdsSlipTtlDataWork
    {
        /// <summary>�d����h��</summary>
        private string _suppHonorificTitle = "";

        /// <summary>�d����X�֔ԍ�</summary>
        private string _supplierPostNo = "";

        /// <summary>�d����Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _supplierAddr1 = "";

        /// <summary>�d����Z��3�i�Ԓn�j</summary>
        private string _supplierAddr3 = "";

        /// <summary>�d����Z��4�i�A�p�[�g���́j</summary>
        private string _supplierAddr4 = "";

        /// <summary>�d����d�b�ԍ�</summary>
        private string _supplierTelNo = "";

        /// <summary>�d����FAX�ԍ�</summary>
        private string _supplierTelNo2 = "";

        /// <summary>���Џ�񖼏�1</summary>
        private string _coInfName1 = "";

        /// <summary>���Џ�񖼏�2</summary>
        private string _coInfName2 = "";

        /// <summary>���Џ��X�֔ԍ�</summary>
        private string _coInfPostNo = "";

        /// <summary>���Џ��Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _coInfAddress1 = "";

        /// <summary>���Џ��Z��2�i���ځj</summary>
        private Int32 _coInfAddress2;

        /// <summary>���Џ��Z��3�i�Ԓn�j</summary>
        private string _coInfAddress3 = "";

        /// <summary>���Џ��Z��4�i�A�p�[�g���́j</summary>
        private string _coInfAddress4 = "";

        /// <summary>���Џ��d�b�ԍ�1</summary>
        private string _coInfTelNo1 = "";

        /// <summary>���Џ��d�b�ԍ�2</summary>
        private string _coInfTelNo2 = "";

        /// <summary>���Џ��d�b�ԍ�3</summary>
        private string _coInfTelNo3 = "";

        /// <summary>���Џ��d�b�ԍ��^�C�g��1</summary>
        private string _coInfTelTitle1 = "";

        /// <summary>���Џ��d�b�ԍ��^�C�g��2</summary>
        private string _coInfTelTitle2 = "";

        /// <summary>���Џ��d�b�ԍ��^�C�g��3</summary>
        private string _coInfTelTitle3 = "";

        /// <summary>���Ж��̖���1</summary>
        private string _coNmName1 = "";

        /// <summary>���Ж��̖���2</summary>
        private string _coNmName2 = "";

        /// <summary>���Ж��̗X�֔ԍ�</summary>
        private string _coNmPostNo = "";

        /// <summary>���Ж��̏Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _coNmAddress1 = "";

        /// <summary>���Ж��̏Z��2�i���ځj</summary>
        private Int32 _coNmAddress2;

        /// <summary>���Ж��̏Z��3�i�Ԓn�j</summary>
        private string _coNmAddress3 = "";

        /// <summary>���Ж��̏Z��4�i�A�p�[�g���́j</summary>
        private string _coNmAddress4 = "";

        /// <summary>���Ж��̓d�b�ԍ�1</summary>
        private string _coNmTelNo1 = "";

        /// <summary>���Ж��̓d�b�ԍ�2</summary>
        private string _coNmTelNo2 = "";

        /// <summary>���Ж��̓d�b�ԍ�3</summary>
        private string _coNmTelNo3 = "";

        /// <summary>���Ж��̓d�b�ԍ��^�C�g��1</summary>
        private string _coNmTelTitle1 = "";

        /// <summary>���Ж��̓d�b�ԍ��^�C�g��2</summary>
        private string _coNmTelTitle2 = "";

        /// <summary>���Ж��̓d�b�ԍ��^�C�g��3</summary>
        private string _coNmTelTitle3 = "";

        /// <summary>�d���`��</summary>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於��</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於��2</summary>
        private string _supplierNm2 = "";

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accPayDivCd;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>���ד�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>�d����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>�d���v����t</summary>
        /// <remarks>�d���v���</remarks>
        private DateTime _stockAddUpADate;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>20:�ԕi</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>�d�����͎҃R�[�h</summary>
        private string _stockInputCode = "";

        /// <summary>�d�����͎Җ���</summary>
        private string _stockInputName = "";

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>�ԕi���R</summary>
        private string _retGoodsReason = "";

        /// <summary>�d���`�[���l1</summary>
        private string _supplierSlipNote1 = "";

        /// <summary>�d���`�[���l2</summary>
        private string _supplierSlipNote2 = "";

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>�d�����z���v</summary>
        /// <remarks>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</remarks>
        private Int64 _stockTotalPrice;

        /// <summary>�d�����z���v</summary>
        /// <remarks>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</remarks>
        private Int64 _stockSubttlPrice;

        /// <summary>�d�����z�v�i�ō��݁j</summary>
        /// <remarks>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</remarks>
        private Int64 _stockTtlPricTaxInc;

        /// <summary>�d�����z�v�i�Ŕ����j</summary>
        /// <remarks>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</remarks>
        private Int64 _stockTtlPricTaxExc;

        /// <summary>�d����ېőΏۊz���v</summary>
        /// <remarks>��ېőΏۋ��z�̏W�v</remarks>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>���ł̏ꍇ:�ō���/105*5,�O�ł̏ꍇ:�Ŕ���*5/100</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>�d�����z����Ŋz�i���Łj</summary>
        /// <remarks>���d�����z����Ŋz �Ɋ܂܂�Ă�����ŕ��̋��z�A�O�ŕ���(�d�����z����Ŋz�|�d�����z����Ŋz(����))�ɂĎZ�o�\</remarks>
        private Int64 _stckPrcConsTaxInclu;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d���l�����z�v�i�Ŕ����j</summary>
        private Int64 _stckDisTtlTaxExc;

        /// <summary>�d���l�����z�v�i���Łj</summary>
        private Int64 _stckDisTtlTaxInclu;


        /// public propaty name  :  SuppHonorificTitle
        /// <summary>�d����h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>�d����X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr
        /// <summary>�d����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>�d����Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>�d����Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  SupplierTelNo
        /// <summary>�d����d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>�d����FAX�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  CoInfName1
        /// <summary>���Џ�񖼏�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ�񖼏�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfName1
        {
            get { return _coInfName1; }
            set { _coInfName1 = value; }
        }

        /// public propaty name  :  CoInfName2
        /// <summary>���Џ�񖼏�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ�񖼏�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfName2
        {
            get { return _coInfName2; }
            set { _coInfName2 = value; }
        }

        /// public propaty name  :  CoInfPostNo
        /// <summary>���Џ��X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfPostNo
        {
            get { return _coInfPostNo; }
            set { _coInfPostNo = value; }
        }

        /// public propaty name  :  CoInfAddress1
        /// <summary>���Џ��Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfAddress1
        {
            get { return _coInfAddress1; }
            set { _coInfAddress1 = value; }
        }

        /// public propaty name  :  CoInfAddress2
        /// <summary>���Џ��Z��2�i���ځj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��Z��2�i���ځj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CoInfAddress2
        {
            get { return _coInfAddress2; }
            set { _coInfAddress2 = value; }
        }

        /// public propaty name  :  CoInfAddress3
        /// <summary>���Џ��Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfAddress3
        {
            get { return _coInfAddress3; }
            set { _coInfAddress3 = value; }
        }

        /// public propaty name  :  CoInfAddress4
        /// <summary>���Џ��Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfAddress4
        {
            get { return _coInfAddress4; }
            set { _coInfAddress4 = value; }
        }

        /// public propaty name  :  CoInfTelNo1
        /// <summary>���Џ��d�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfTelNo1
        {
            get { return _coInfTelNo1; }
            set { _coInfTelNo1 = value; }
        }

        /// public propaty name  :  CoInfTelNo2
        /// <summary>���Џ��d�b�ԍ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfTelNo2
        {
            get { return _coInfTelNo2; }
            set { _coInfTelNo2 = value; }
        }

        /// public propaty name  :  CoInfTelNo3
        /// <summary>���Џ��d�b�ԍ�3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��d�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfTelNo3
        {
            get { return _coInfTelNo3; }
            set { _coInfTelNo3 = value; }
        }

        /// public propaty name  :  CoInfTelTitle1
        /// <summary>���Џ��d�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��d�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfTelTitle1
        {
            get { return _coInfTelTitle1; }
            set { _coInfTelTitle1 = value; }
        }

        /// public propaty name  :  CoInfTelTitle2
        /// <summary>���Џ��d�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��d�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfTelTitle2
        {
            get { return _coInfTelTitle2; }
            set { _coInfTelTitle2 = value; }
        }

        /// public propaty name  :  CoInfTelTitle3
        /// <summary>���Џ��d�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Џ��d�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoInfTelTitle3
        {
            get { return _coInfTelTitle3; }
            set { _coInfTelTitle3 = value; }
        }

        /// public propaty name  :  CoNmName1
        /// <summary>���Ж��̖���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̖���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmName1
        {
            get { return _coNmName1; }
            set { _coNmName1 = value; }
        }

        /// public propaty name  :  CoNmName2
        /// <summary>���Ж��̖���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̖���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmName2
        {
            get { return _coNmName2; }
            set { _coNmName2 = value; }
        }

        /// public propaty name  :  CoNmPostNo
        /// <summary>���Ж��̗X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̗X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmPostNo
        {
            get { return _coNmPostNo; }
            set { _coNmPostNo = value; }
        }

        /// public propaty name  :  CoNmAddress1
        /// <summary>���Ж��̏Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̏Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmAddress1
        {
            get { return _coNmAddress1; }
            set { _coNmAddress1 = value; }
        }

        /// public propaty name  :  CoNmAddress2
        /// <summary>���Ж��̏Z��2�i���ځj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̏Z��2�i���ځj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CoNmAddress2
        {
            get { return _coNmAddress2; }
            set { _coNmAddress2 = value; }
        }

        /// public propaty name  :  CoNmAddress3
        /// <summary>���Ж��̏Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̏Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmAddress3
        {
            get { return _coNmAddress3; }
            set { _coNmAddress3 = value; }
        }

        /// public propaty name  :  CoNmAddress4
        /// <summary>���Ж��̏Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̏Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmAddress4
        {
            get { return _coNmAddress4; }
            set { _coNmAddress4 = value; }
        }

        /// public propaty name  :  CoNmTelNo1
        /// <summary>���Ж��̓d�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̓d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmTelNo1
        {
            get { return _coNmTelNo1; }
            set { _coNmTelNo1 = value; }
        }

        /// public propaty name  :  CoNmTelNo2
        /// <summary>���Ж��̓d�b�ԍ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̓d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmTelNo2
        {
            get { return _coNmTelNo2; }
            set { _coNmTelNo2 = value; }
        }

        /// public propaty name  :  CoNmTelNo3
        /// <summary>���Ж��̓d�b�ԍ�3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̓d�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmTelNo3
        {
            get { return _coNmTelNo3; }
            set { _coNmTelNo3 = value; }
        }

        /// public propaty name  :  CoNmTelTitle1
        /// <summary>���Ж��̓d�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̓d�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmTelTitle1
        {
            get { return _coNmTelTitle1; }
            set { _coNmTelTitle1 = value; }
        }

        /// public propaty name  :  CoNmTelTitle2
        /// <summary>���Ж��̓d�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̓d�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmTelTitle2
        {
            get { return _coNmTelTitle2; }
            set { _coNmTelTitle2 = value; }
        }

        /// public propaty name  :  CoNmTelTitle3
        /// <summary>���Ж��̓d�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̓d�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CoNmTelTitle3
        {
            get { return _coNmTelTitle3; }
            set { _coNmTelTitle3 = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����,10:���p����Œ���(����),11:���E,12:���E(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
        }

        /// public propaty name  :  AccPayDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccPayDivCd
        {
            get { return _accPayDivCd; }
            set { _accPayDivCd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ד��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockAddUpADate
        /// <summary>�d���v����t�v���p�e�B</summary>
        /// <value>�d���v���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockAddUpADate
        {
            get { return _stockAddUpADate; }
            set { _stockAddUpADate = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>20:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  StockInputCode
        /// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputCode
        {
            get { return _stockInputCode; }
            set { _stockInputCode = value; }
        }

        /// public propaty name  :  StockInputName
        /// <summary>�d�����͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  RetGoodsReasonDiv
        /// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetGoodsReasonDiv
        {
            get { return _retGoodsReasonDiv; }
            set { _retGoodsReasonDiv = value; }
        }

        /// public propaty name  :  RetGoodsReason
        /// <summary>�ԕi���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RetGoodsReason
        {
            get { return _retGoodsReason; }
            set { _retGoodsReason = value; }
        }

        /// public propaty name  :  SupplierSlipNote1
        /// <summary>�d���`�[���l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote1
        {
            get { return _supplierSlipNote1; }
            set { _supplierSlipNote1 = value; }
        }

        /// public propaty name  :  SupplierSlipNote2
        /// <summary>�d���`�[���l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[���l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSlipNote2
        {
            get { return _supplierSlipNote2; }
            set { _supplierSlipNote2 = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  StockTotalPrice
        /// <summary>�d�����z���v�v���p�e�B</summary>
        /// <value>�d�����z���v���d�����z�v�i�ō��݁j�{��ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPrice
        {
            get { return _stockTotalPrice; }
            set { _stockTotalPrice = value; }
        }

        /// public propaty name  :  StockSubttlPrice
        /// <summary>�d�����z���v�v���p�e�B</summary>
        /// <value>�d�����z���v���d�����z�v�i�Ŕ����j�{��ېőΏۊz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSubttlPrice
        {
            get { return _stockSubttlPrice; }
            set { _stockSubttlPrice = value; }
        }

        /// public propaty name  :  StockTtlPricTaxInc
        /// <summary>�d�����z�v�i�ō��݁j�v���p�e�B</summary>
        /// <value>�O�Ŏ��F�Ŕ����{����ŁA���Ŏ��F���ŉ��i�i�ō��j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxInc
        {
            get { return _stockTtlPricTaxInc; }
            set { _stockTtlPricTaxInc = value; }
        }

        /// public propaty name  :  StockTtlPricTaxExc
        /// <summary>�d�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>�O�Ŏ��F�Ŕ����i�̏W�v�A���Ŏ��F���ŉ��i�i�ō��j�̏W�v�|�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtlPricTaxExc
        {
            get { return _stockTtlPricTaxExc; }
            set { _stockTtlPricTaxExc = value; }
        }

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>�d����ېőΏۊz���v�v���p�e�B</summary>
        /// <value>��ېőΏۋ��z�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcTaxFree
        {
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>���ł̏ꍇ:�ō���/105*5,�O�ł̏ꍇ:�Ŕ���*5/100</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  StckPrcConsTaxInclu
        /// <summary>�d�����z����Ŋz�i���Łj�v���p�e�B</summary>
        /// <value>���d�����z����Ŋz �Ɋ܂܂�Ă�����ŕ��̋��z�A�O�ŕ���(�d�����z����Ŋz�|�d�����z����Ŋz(����))�ɂĎZ�o�\</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckPrcConsTaxInclu
        {
            get { return _stckPrcConsTaxInclu; }
            set { _stckPrcConsTaxInclu = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�x���e 3:�x���q 9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  StckDisTtlTaxExc
        /// <summary>�d���l�����z�v�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l�����z�v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxExc
        {
            get { return _stckDisTtlTaxExc; }
            set { _stckDisTtlTaxExc = value; }
        }

        /// public propaty name  :  StckDisTtlTaxInclu
        /// <summary>�d���l�����z�v�i���Łj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l�����z�v�i���Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckDisTtlTaxInclu
        {
            get { return _stckDisTtlTaxInclu; }
            set { _stckDisTtlTaxInclu = value; }
        }


        /// <summary>
        /// �d���ԕi�`�[(�ӕ�)�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StcRetGdsSlipTtlDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StcRetGdsSlipTtlDataWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StcRetGdsSlipTtlDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StcRetGdsSlipTtlDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StcRetGdsSlipTtlDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StcRetGdsSlipTtlDataWork || graph is ArrayList || graph is StcRetGdsSlipTtlDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StcRetGdsSlipTtlDataWork).FullName));

            if (graph != null && graph is StcRetGdsSlipTtlDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StcRetGdsSlipTtlDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StcRetGdsSlipTtlDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StcRetGdsSlipTtlDataWork[])graph).Length;
            }
            else if (graph is StcRetGdsSlipTtlDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�d����h��
            serInfo.MemberInfo.Add(typeof(string)); //SuppHonorificTitle
            //�d����X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SupplierPostNo
            //�d����Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr
            //�d����Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr3
            //�d����Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr4
            //�d����d�b�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo
            //�d����FAX�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo2
            //���Џ�񖼏�1
            serInfo.MemberInfo.Add(typeof(string)); //CoInfName1
            //���Џ�񖼏�2
            serInfo.MemberInfo.Add(typeof(string)); //CoInfName2
            //���Џ��X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //CoInfPostNo
            //���Џ��Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //CoInfAddress1
            //���Џ��Z��2�i���ځj
            serInfo.MemberInfo.Add(typeof(Int32)); //CoInfAddress2
            //���Џ��Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //CoInfAddress3
            //���Џ��Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //CoInfAddress4
            //���Џ��d�b�ԍ�1
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelNo1
            //���Џ��d�b�ԍ�2
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelNo2
            //���Џ��d�b�ԍ�3
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelNo3
            //���Џ��d�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelTitle1
            //���Џ��d�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelTitle2
            //���Џ��d�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //CoInfTelTitle3
            //���Ж��̖���1
            serInfo.MemberInfo.Add(typeof(string)); //CoNmName1
            //���Ж��̖���2
            serInfo.MemberInfo.Add(typeof(string)); //CoNmName2
            //���Ж��̗X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //CoNmPostNo
            //���Ж��̏Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //CoNmAddress1
            //���Ж��̏Z��2�i���ځj
            serInfo.MemberInfo.Add(typeof(Int32)); //CoNmAddress2
            //���Ж��̏Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //CoNmAddress3
            //���Ж��̏Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //CoNmAddress4
            //���Ж��̓d�b�ԍ�1
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelNo1
            //���Ж��̓d�b�ԍ�2
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelNo2
            //���Ж��̓d�b�ԍ�3
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelNo3
            //���Ж��̓d�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelTitle1
            //���Ж��̓d�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelTitle2
            //���Ж��̓d�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //CoNmTelTitle3
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於��2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�d�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockGoodsCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccPayDivCd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //�d����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //�d���v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAddUpADate
            //�d���`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipCd
            //�d�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            //�d�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�ԕi���R�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsReasonDiv
            //�ԕi���R
            serInfo.MemberInfo.Add(typeof(string)); //RetGoodsReason
            //�d���`�[���l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote1
            //�d���`�[���l2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSlipNote2
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPrice
            //�d�����z���v
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSubttlPrice
            //�d�����z�v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxInc
            //�d�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtlPricTaxExc
            //�d����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedStcTaxFree
            //�d�����z����Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceConsTax
            //�d�����z����Ŋz�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StckPrcConsTaxInclu
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d���l�����z�v�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxExc
            //�d���l�����z�v�i���Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //StckDisTtlTaxInclu


            serInfo.Serialize(writer, serInfo);
            if (graph is StcRetGdsSlipTtlDataWork)
            {
                StcRetGdsSlipTtlDataWork temp = (StcRetGdsSlipTtlDataWork)graph;

                SetStcRetGdsSlipTtlDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StcRetGdsSlipTtlDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StcRetGdsSlipTtlDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StcRetGdsSlipTtlDataWork temp in lst)
                {
                    SetStcRetGdsSlipTtlDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StcRetGdsSlipTtlDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 68;

        /// <summary>
        ///  StcRetGdsSlipTtlDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStcRetGdsSlipTtlDataWork(System.IO.BinaryWriter writer, StcRetGdsSlipTtlDataWork temp)
        {
            //�d����h��
            writer.Write(temp.SuppHonorificTitle);
            //�d����X�֔ԍ�
            writer.Write(temp.SupplierPostNo);
            //�d����Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.SupplierAddr);
            //�d����Z��3�i�Ԓn�j
            writer.Write(temp.SupplierAddr3);
            //�d����Z��4�i�A�p�[�g���́j
            writer.Write(temp.SupplierAddr4);
            //�d����d�b�ԍ�
            writer.Write(temp.SupplierTelNo);
            //�d����FAX�ԍ�
            writer.Write(temp.SupplierTelNo2);
            //���Џ�񖼏�1
            writer.Write(temp.CoInfName1);
            //���Џ�񖼏�2
            writer.Write(temp.CoInfName2);
            //���Џ��X�֔ԍ�
            writer.Write(temp.CoInfPostNo);
            //���Џ��Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.CoInfAddress1);
            //���Џ��Z��2�i���ځj
            writer.Write(temp.CoInfAddress2);
            //���Џ��Z��3�i�Ԓn�j
            writer.Write(temp.CoInfAddress3);
            //���Џ��Z��4�i�A�p�[�g���́j
            writer.Write(temp.CoInfAddress4);
            //���Џ��d�b�ԍ�1
            writer.Write(temp.CoInfTelNo1);
            //���Џ��d�b�ԍ�2
            writer.Write(temp.CoInfTelNo2);
            //���Џ��d�b�ԍ�3
            writer.Write(temp.CoInfTelNo3);
            //���Џ��d�b�ԍ��^�C�g��1
            writer.Write(temp.CoInfTelTitle1);
            //���Џ��d�b�ԍ��^�C�g��2
            writer.Write(temp.CoInfTelTitle2);
            //���Џ��d�b�ԍ��^�C�g��3
            writer.Write(temp.CoInfTelTitle3);
            //���Ж��̖���1
            writer.Write(temp.CoNmName1);
            //���Ж��̖���2
            writer.Write(temp.CoNmName2);
            //���Ж��̗X�֔ԍ�
            writer.Write(temp.CoNmPostNo);
            //���Ж��̏Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.CoNmAddress1);
            //���Ж��̏Z��2�i���ځj
            writer.Write(temp.CoNmAddress2);
            //���Ж��̏Z��3�i�Ԓn�j
            writer.Write(temp.CoNmAddress3);
            //���Ж��̏Z��4�i�A�p�[�g���́j
            writer.Write(temp.CoNmAddress4);
            //���Ж��̓d�b�ԍ�1
            writer.Write(temp.CoNmTelNo1);
            //���Ж��̓d�b�ԍ�2
            writer.Write(temp.CoNmTelNo2);
            //���Ж��̓d�b�ԍ�3
            writer.Write(temp.CoNmTelNo3);
            //���Ж��̓d�b�ԍ��^�C�g��1
            writer.Write(temp.CoNmTelTitle1);
            //���Ж��̓d�b�ԍ��^�C�g��2
            writer.Write(temp.CoNmTelTitle2);
            //���Ж��̓d�b�ԍ��^�C�g��3
            writer.Write(temp.CoNmTelTitle3);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於��
            writer.Write(temp.SupplierNm1);
            //�d���於��2
            writer.Write(temp.SupplierNm2);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�d�����i�敪
            writer.Write(temp.StockGoodsCd);
            //���|�敪
            writer.Write(temp.AccPayDivCd);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //���ד�
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //�d����
            writer.Write((Int64)temp.StockDate.Ticks);
            //�d���v����t
            writer.Write((Int64)temp.StockAddUpADate.Ticks);
            //�d���`�[�敪
            writer.Write(temp.SupplierSlipCd);
            //�d�����͎҃R�[�h
            writer.Write(temp.StockInputCode);
            //�d�����͎Җ���
            writer.Write(temp.StockInputName);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�ԕi���R�R�[�h
            writer.Write(temp.RetGoodsReasonDiv);
            //�ԕi���R
            writer.Write(temp.RetGoodsReason);
            //�d���`�[���l1
            writer.Write(temp.SupplierSlipNote1);
            //�d���`�[���l2
            writer.Write(temp.SupplierSlipNote2);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //�d�����z���v
            writer.Write(temp.StockTotalPrice);
            //�d�����z���v
            writer.Write(temp.StockSubttlPrice);
            //�d�����z�v�i�ō��݁j
            writer.Write(temp.StockTtlPricTaxInc);
            //�d�����z�v�i�Ŕ����j
            writer.Write(temp.StockTtlPricTaxExc);
            //�d����ېőΏۊz���v
            writer.Write(temp.TtlItdedStcTaxFree);
            //�d�����z����Ŋz
            writer.Write(temp.StockPriceConsTax);
            //�d�����z����Ŋz�i���Łj
            writer.Write(temp.StckPrcConsTaxInclu);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d���l�����z�v�i�Ŕ����j
            writer.Write(temp.StckDisTtlTaxExc);
            //�d���l�����z�v�i���Łj
            writer.Write(temp.StckDisTtlTaxInclu);

        }

        /// <summary>
        ///  StcRetGdsSlipTtlDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StcRetGdsSlipTtlDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StcRetGdsSlipTtlDataWork GetStcRetGdsSlipTtlDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StcRetGdsSlipTtlDataWork temp = new StcRetGdsSlipTtlDataWork();

            //�d����h��
            temp.SuppHonorificTitle = reader.ReadString();
            //�d����X�֔ԍ�
            temp.SupplierPostNo = reader.ReadString();
            //�d����Z��1�i�s���{���s��S�E�����E���j
            temp.SupplierAddr = reader.ReadString();
            //�d����Z��3�i�Ԓn�j
            temp.SupplierAddr3 = reader.ReadString();
            //�d����Z��4�i�A�p�[�g���́j
            temp.SupplierAddr4 = reader.ReadString();
            //�d����d�b�ԍ�
            temp.SupplierTelNo = reader.ReadString();
            //�d����FAX�ԍ�
            temp.SupplierTelNo2 = reader.ReadString();
            //���Џ�񖼏�1
            temp.CoInfName1 = reader.ReadString();
            //���Џ�񖼏�2
            temp.CoInfName2 = reader.ReadString();
            //���Џ��X�֔ԍ�
            temp.CoInfPostNo = reader.ReadString();
            //���Џ��Z��1�i�s���{���s��S�E�����E���j
            temp.CoInfAddress1 = reader.ReadString();
            //���Џ��Z��2�i���ځj
            temp.CoInfAddress2 = reader.ReadInt32();
            //���Џ��Z��3�i�Ԓn�j
            temp.CoInfAddress3 = reader.ReadString();
            //���Џ��Z��4�i�A�p�[�g���́j
            temp.CoInfAddress4 = reader.ReadString();
            //���Џ��d�b�ԍ�1
            temp.CoInfTelNo1 = reader.ReadString();
            //���Џ��d�b�ԍ�2
            temp.CoInfTelNo2 = reader.ReadString();
            //���Џ��d�b�ԍ�3
            temp.CoInfTelNo3 = reader.ReadString();
            //���Џ��d�b�ԍ��^�C�g��1
            temp.CoInfTelTitle1 = reader.ReadString();
            //���Џ��d�b�ԍ��^�C�g��2
            temp.CoInfTelTitle2 = reader.ReadString();
            //���Џ��d�b�ԍ��^�C�g��3
            temp.CoInfTelTitle3 = reader.ReadString();
            //���Ж��̖���1
            temp.CoNmName1 = reader.ReadString();
            //���Ж��̖���2
            temp.CoNmName2 = reader.ReadString();
            //���Ж��̗X�֔ԍ�
            temp.CoNmPostNo = reader.ReadString();
            //���Ж��̏Z��1�i�s���{���s��S�E�����E���j
            temp.CoNmAddress1 = reader.ReadString();
            //���Ж��̏Z��2�i���ځj
            temp.CoNmAddress2 = reader.ReadInt32();
            //���Ж��̏Z��3�i�Ԓn�j
            temp.CoNmAddress3 = reader.ReadString();
            //���Ж��̏Z��4�i�A�p�[�g���́j
            temp.CoNmAddress4 = reader.ReadString();
            //���Ж��̓d�b�ԍ�1
            temp.CoNmTelNo1 = reader.ReadString();
            //���Ж��̓d�b�ԍ�2
            temp.CoNmTelNo2 = reader.ReadString();
            //���Ж��̓d�b�ԍ�3
            temp.CoNmTelNo3 = reader.ReadString();
            //���Ж��̓d�b�ԍ��^�C�g��1
            temp.CoNmTelTitle1 = reader.ReadString();
            //���Ж��̓d�b�ԍ��^�C�g��2
            temp.CoNmTelTitle2 = reader.ReadString();
            //���Ж��̓d�b�ԍ��^�C�g��3
            temp.CoNmTelTitle3 = reader.ReadString();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於��
            temp.SupplierNm1 = reader.ReadString();
            //�d���於��2
            temp.SupplierNm2 = reader.ReadString();
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�d�����i�敪
            temp.StockGoodsCd = reader.ReadInt32();
            //���|�敪
            temp.AccPayDivCd = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //���ד�
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //�d����
            temp.StockDate = new DateTime(reader.ReadInt64());
            //�d���v����t
            temp.StockAddUpADate = new DateTime(reader.ReadInt64());
            //�d���`�[�敪
            temp.SupplierSlipCd = reader.ReadInt32();
            //�d�����͎҃R�[�h
            temp.StockInputCode = reader.ReadString();
            //�d�����͎Җ���
            temp.StockInputName = reader.ReadString();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�ԕi���R�R�[�h
            temp.RetGoodsReasonDiv = reader.ReadInt32();
            //�ԕi���R
            temp.RetGoodsReason = reader.ReadString();
            //�d���`�[���l1
            temp.SupplierSlipNote1 = reader.ReadString();
            //�d���`�[���l2
            temp.SupplierSlipNote2 = reader.ReadString();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�d�����z���v
            temp.StockTotalPrice = reader.ReadInt64();
            //�d�����z���v
            temp.StockSubttlPrice = reader.ReadInt64();
            //�d�����z�v�i�ō��݁j
            temp.StockTtlPricTaxInc = reader.ReadInt64();
            //�d�����z�v�i�Ŕ����j
            temp.StockTtlPricTaxExc = reader.ReadInt64();
            //�d����ېőΏۊz���v
            temp.TtlItdedStcTaxFree = reader.ReadInt64();
            //�d�����z����Ŋz
            temp.StockPriceConsTax = reader.ReadInt64();
            //�d�����z����Ŋz�i���Łj
            temp.StckPrcConsTaxInclu = reader.ReadInt64();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d���l�����z�v�i�Ŕ����j
            temp.StckDisTtlTaxExc = reader.ReadInt64();
            //�d���l�����z�v�i���Łj
            temp.StckDisTtlTaxInclu = reader.ReadInt64();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>StcRetGdsSlipTtlDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StcRetGdsSlipTtlDataWork temp = GetStcRetGdsSlipTtlDataWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (StcRetGdsSlipTtlDataWork[])lst.ToArray(typeof(StcRetGdsSlipTtlDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
