using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCmpnySt
    /// <summary>
    ///                      BLP���Аݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   BLP���Аݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccCmpnySt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>PCC���Ж���</summary>
        /// <remarks>PM�̓��Ӑ於��</remarks>
        private string _pccCompanyName = "";

        /// <summary>PCC�q�ɃR�[�h</summary>
        private string _pccWarehouseCd = "";

        /// <summary>PCC�q�ɖ���</summary>
        private string _pccWarehouseNm = "";

        /// <summary>PCC�D��q�ɃR�[�h1</summary>
        private string _pccPriWarehouseCd1 = "";

        /// <summary>PCC�D��q�ɃR�[�h2</summary>
        private string _pccPriWarehouseCd2 = "";

        /// <summary>PCC�D��q�ɃR�[�h3</summary>
        private string _pccPriWarehouseCd3 = "";

        /// <summary>�i�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _goodsNoDspDiv;

        /// <summary>�i�ԕ\���敪����</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _goodsNoDspDivName = "";

        /// <summary>�W�����i�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _listPrcDspDiv;

        /// <summary>�W�����i�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _listPrcDspDivName = "";

        /// <summary>�d�؉��i�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _costDspDiv;

        /// <summary>�d�؉��i�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _costDspDivName = "";

        /// <summary>�I�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _shelfDspDiv;

        /// <summary>�I�ԕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _shelfDspDivName = "";

        /// <summary>�݌ɕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _stockDspDiv;

        /// <summary>�݌ɕ\���敪����</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _stockDspDivName = "";

        /// <summary>�R�����g�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _commentDspDiv;

        /// <summary>�R�����g�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _commentDspDivName = "";

        /// <summary>�o�א��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _spmtCntDspDiv;

        /// <summary>�o�א��\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _spmtCntDspDivName = "";

        /// <summary>�󒍐��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _acptCntDspDiv;

        /// <summary>�󒍐��\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _acptCntDspDivName = "";

        /// <summary>���i�I��i�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelGdNoDspDiv;

        /// <summary>���i�I��i�ԕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelGdNoDspDivName = "";

        /// <summary>���i�I��W�����i�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelLsPrDspDiv;

        /// <summary>���i�I��W�����i�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelLsPrDspDivName = "";

        /// <summary>���i�I��I�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelSelfDspDiv;

        /// <summary>���i�I��I�ԕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelSelfDspDivName = "";

        /// <summary>���i�I���݌ɕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelStckDspDiv;

        /// <summary>���i�I���݌ɕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelStckDspDivName = "";

        /// <summary>�݌ɏ󋵃}�[�N1</summary>
        /// <remarks>(���p�S�p����)�݌ɂ���</remarks>
        private string _stckStMark1 = "";

        /// <summary>�݌ɏ󋵃}�[�N2</summary>
        /// <remarks>(���p�S�p����)�݌ɂȂ�</remarks>
        private string _stckStMark2 = "";

        /// <summary>�݌ɏ󋵃}�[�N3</summary>
        /// <remarks>(���p�S�p����)�݌ɕs��</remarks>
        private string _stckStMark3 = "";

        /// <summary>PCC�����於��1</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplName1 = "";

        /// <summary>PCC�����於��2</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplName2 = "";

        /// <summary>PCC������J�i����</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplKana = "";

        /// <summary>PCC�����旪��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplSnm = "";

        /// <summary>PCC������X�֔ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplPostNo = "";

        /// <summary>PCC������Z��1</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplAddr1 = "";

        /// <summary>PCC������Z��2</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplAddr2 = "";

        /// <summary>PCC������Z��3</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplAddr3 = "";

        /// <summary>PCC������d�b�ԍ�1</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplTelNo1 = "";

        /// <summary>PCC������d�b�ԍ�2</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplTelNo2 = "";

        /// <summary>PCC������FAX�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplFaxNo = "";

        /// <summary>�`�[���s�敪�iPCC�j</summary>
        /// <remarks>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</remarks>
        private Int32 _pccSlipPrtDiv;

        /// <summary>�`�[���s���́iPCC�j</summary>
        /// <remarks>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</remarks>
        private string _pccSlipPrtDivName = "";

        /// <summary>�`�[�Ĕ��s�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _pccSlipRePrtDiv;

        /// <summary>�`�[�Ĕ��s����</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private string _pccSlipRePrtDivName = "";

        /// <summary>���i�I��D�Ǖ\���敪</summary>
        /// <remarks>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</remarks>
        private Int32 _prtSelPrmDspDiv;

        /// <summary>���i�I��D�Ǖ\������</summary>
        /// <remarks>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</remarks>
        private string _prtSelPrmDspDivName = "";

        /// <summary>�݌ɏ󋵕\���敪</summary>
        /// <remarks>0:�}�[�N 1:���݌ɐ�</remarks>
        private Int32 _stckStDspDiv;

        /// <summary>�݌ɏ󋵕\������</summary>
        /// <remarks>0:�}�[�N 1:���݌ɐ�</remarks>
        private string _stckStDspDivName = "";

        /// <summary>�݌ɃR�����g1</summary>
        private string _stckStComment1 = "";

        /// <summary>�݌ɃR�����g2</summary>
        private string _stckStComment2 = "";

        /// <summary>�݌ɃR�����g3</summary>
        private string _stckStComment3 = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h�v���p�e�B</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  PccCompanyName
        /// <summary>PCC���Ж��̃v���p�e�B</summary>
        /// <value>PM�̓��Ӑ於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���Ж��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccCompanyName
        {
            get { return _pccCompanyName; }
            set { _pccCompanyName = value; }
        }

        /// public propaty name  :  PccWarehouseCd
        /// <summary>PCC�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccWarehouseCd
        {
            get { return _pccWarehouseCd; }
            set { _pccWarehouseCd = value; }
        }

        /// public propaty name  :  PccWarehouseNm
        /// <summary>PCC�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccWarehouseNm
        {
            get { return _pccWarehouseNm; }
            set { _pccWarehouseNm = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd1
        /// <summary>PCC�D��q�ɃR�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd1
        {
            get { return _pccPriWarehouseCd1; }
            set { _pccPriWarehouseCd1 = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd2
        /// <summary>PCC�D��q�ɃR�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd2
        {
            get { return _pccPriWarehouseCd2; }
            set { _pccPriWarehouseCd2 = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd3
        /// <summary>PCC�D��q�ɃR�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd3
        {
            get { return _pccPriWarehouseCd3; }
            set { _pccPriWarehouseCd3 = value; }
        }

        /// public propaty name  :  GoodsNoDspDiv
        /// <summary>�i�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoDspDiv
        {
            get { return _goodsNoDspDiv; }
            set { _goodsNoDspDiv = value; }
        }

        /// public propaty name  :  GoodsNoDspDivName
        /// <summary>�i�ԕ\���敪���̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoDspDivName
        {
            get { return _goodsNoDspDivName; }
            set { _goodsNoDspDivName = value; }
        }

        /// public propaty name  :  ListPrcDspDiv
        /// <summary>�W�����i�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPrcDspDiv
        {
            get { return _listPrcDspDiv; }
            set { _listPrcDspDiv = value; }
        }

        /// public propaty name  :  ListPrcDspDivName
        /// <summary>�W�����i�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrcDspDivName
        {
            get { return _listPrcDspDivName; }
            set { _listPrcDspDivName = value; }
        }

        /// public propaty name  :  CostDspDiv
        /// <summary>�d�؉��i�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CostDspDiv
        {
            get { return _costDspDiv; }
            set { _costDspDiv = value; }
        }

        /// public propaty name  :  CostDspDivName
        /// <summary>�d�؉��i�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CostDspDivName
        {
            get { return _costDspDivName; }
            set { _costDspDivName = value; }
        }

        /// public propaty name  :  ShelfDspDiv
        /// <summary>�I�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShelfDspDiv
        {
            get { return _shelfDspDiv; }
            set { _shelfDspDiv = value; }
        }

        /// public propaty name  :  ShelfDspDivName
        /// <summary>�I�ԕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfDspDivName
        {
            get { return _shelfDspDivName; }
            set { _shelfDspDivName = value; }
        }

        /// public propaty name  :  StockDspDiv
        /// <summary>�݌ɕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDspDiv
        {
            get { return _stockDspDiv; }
            set { _stockDspDiv = value; }
        }

        /// public propaty name  :  StockDspDivName
        /// <summary>�݌ɕ\���敪���̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDspDivName
        {
            get { return _stockDspDivName; }
            set { _stockDspDivName = value; }
        }

        /// public propaty name  :  CommentDspDiv
        /// <summary>�R�����g�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommentDspDiv
        {
            get { return _commentDspDiv; }
            set { _commentDspDiv = value; }
        }

        /// public propaty name  :  CommentDspDivName
        /// <summary>�R�����g�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommentDspDivName
        {
            get { return _commentDspDivName; }
            set { _commentDspDivName = value; }
        }

        /// public propaty name  :  SpmtCntDspDiv
        /// <summary>�o�א��\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SpmtCntDspDiv
        {
            get { return _spmtCntDspDiv; }
            set { _spmtCntDspDiv = value; }
        }

        /// public propaty name  :  SpmtCntDspDivName
        /// <summary>�o�א��\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpmtCntDspDivName
        {
            get { return _spmtCntDspDivName; }
            set { _spmtCntDspDivName = value; }
        }

        /// public propaty name  :  AcptCntDspDiv
        /// <summary>�󒍐��\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptCntDspDiv
        {
            get { return _acptCntDspDiv; }
            set { _acptCntDspDiv = value; }
        }

        /// public propaty name  :  AcptCntDspDivName
        /// <summary>�󒍐��\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcptCntDspDivName
        {
            get { return _acptCntDspDivName; }
            set { _acptCntDspDivName = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDiv
        /// <summary>���i�I��i�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDiv
        {
            get { return _prtSelGdNoDspDiv; }
            set { _prtSelGdNoDspDiv = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDivName
        /// <summary>���i�I��i�ԕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelGdNoDspDivName
        {
            get { return _prtSelGdNoDspDivName; }
            set { _prtSelGdNoDspDivName = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDiv
        /// <summary>���i�I��W�����i�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDiv
        {
            get { return _prtSelLsPrDspDiv; }
            set { _prtSelLsPrDspDiv = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDivName
        /// <summary>���i�I��W�����i�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelLsPrDspDivName
        {
            get { return _prtSelLsPrDspDivName; }
            set { _prtSelLsPrDspDivName = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDiv
        /// <summary>���i�I��I�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDiv
        {
            get { return _prtSelSelfDspDiv; }
            set { _prtSelSelfDspDiv = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDivName
        /// <summary>���i�I��I�ԕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelSelfDspDivName
        {
            get { return _prtSelSelfDspDivName; }
            set { _prtSelSelfDspDivName = value; }
        }

        /// public propaty name  :  PrtSelStckDspDiv
        /// <summary>���i�I���݌ɕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelStckDspDiv
        {
            get { return _prtSelStckDspDiv; }
            set { _prtSelStckDspDiv = value; }
        }

        /// public propaty name  :  PrtSelStckDspDivName
        /// <summary>���i�I���݌ɕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelStckDspDivName
        {
            get { return _prtSelStckDspDivName; }
            set { _prtSelStckDspDivName = value; }
        }

        /// public propaty name  :  StckStMark1
        /// <summary>�݌ɏ󋵃}�[�N1�v���p�e�B</summary>
        /// <value>(���p�S�p����)�݌ɂ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃}�[�N1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStMark1
        {
            get { return _stckStMark1; }
            set { _stckStMark1 = value; }
        }

        /// public propaty name  :  StckStMark2
        /// <summary>�݌ɏ󋵃}�[�N2�v���p�e�B</summary>
        /// <value>(���p�S�p����)�݌ɂȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃}�[�N2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStMark2
        {
            get { return _stckStMark2; }
            set { _stckStMark2 = value; }
        }

        /// public propaty name  :  StckStMark3
        /// <summary>�݌ɏ󋵃}�[�N3�v���p�e�B</summary>
        /// <value>(���p�S�p����)�݌ɕs��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃}�[�N3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStMark3
        {
            get { return _stckStMark3; }
            set { _stckStMark3 = value; }
        }

        /// public propaty name  :  PccSuplName1
        /// <summary>PCC�����於��1�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�����於��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplName1
        {
            get { return _pccSuplName1; }
            set { _pccSuplName1 = value; }
        }

        /// public propaty name  :  PccSuplName2
        /// <summary>PCC�����於��2�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplName2
        {
            get { return _pccSuplName2; }
            set { _pccSuplName2 = value; }
        }

        /// public propaty name  :  PccSuplKana
        /// <summary>PCC������J�i���̃v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplKana
        {
            get { return _pccSuplKana; }
            set { _pccSuplKana = value; }
        }

        /// public propaty name  :  PccSuplSnm
        /// <summary>PCC�����旪�̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplSnm
        {
            get { return _pccSuplSnm; }
            set { _pccSuplSnm = value; }
        }

        /// public propaty name  :  PccSuplPostNo
        /// <summary>PCC������X�֔ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplPostNo
        {
            get { return _pccSuplPostNo; }
            set { _pccSuplPostNo = value; }
        }

        /// public propaty name  :  PccSuplAddr1
        /// <summary>PCC������Z��1�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������Z��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplAddr1
        {
            get { return _pccSuplAddr1; }
            set { _pccSuplAddr1 = value; }
        }

        /// public propaty name  :  PccSuplAddr2
        /// <summary>PCC������Z��2�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������Z��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplAddr2
        {
            get { return _pccSuplAddr2; }
            set { _pccSuplAddr2 = value; }
        }

        /// public propaty name  :  PccSuplAddr3
        /// <summary>PCC������Z��3�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������Z��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplAddr3
        {
            get { return _pccSuplAddr3; }
            set { _pccSuplAddr3 = value; }
        }

        /// public propaty name  :  PccSuplTelNo1
        /// <summary>PCC������d�b�ԍ�1�v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplTelNo1
        {
            get { return _pccSuplTelNo1; }
            set { _pccSuplTelNo1 = value; }
        }

        /// public propaty name  :  PccSuplTelNo2
        /// <summary>PCC������d�b�ԍ�2�v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplTelNo2
        {
            get { return _pccSuplTelNo2; }
            set { _pccSuplTelNo2 = value; }
        }

        /// public propaty name  :  PccSuplFaxNo
        /// <summary>PCC������FAX�ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplFaxNo
        {
            get { return _pccSuplFaxNo; }
            set { _pccSuplFaxNo = value; }
        }

        /// public propaty name  :  PccSlipPrtDiv
        /// <summary>�`�[���s�敪�iPCC�j�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�敪�iPCC�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccSlipPrtDiv
        {
            get { return _pccSlipPrtDiv; }
            set { _pccSlipPrtDiv = value; }
        }

        /// public propaty name  :  PccSlipPrtDivName
        /// <summary>�`�[���s���́iPCC�j�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s���́iPCC�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSlipPrtDivName
        {
            get { return _pccSlipPrtDivName; }
            set { _pccSlipPrtDivName = value; }
        }

        /// public propaty name  :  PccSlipRePrtDiv
        /// <summary>�`�[�Ĕ��s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Ĕ��s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccSlipRePrtDiv
        {
            get { return _pccSlipRePrtDiv; }
            set { _pccSlipRePrtDiv = value; }
        }

        /// public propaty name  :  PccSlipRePrtDivName
        /// <summary>�`�[�Ĕ��s���̃v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Ĕ��s���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSlipRePrtDivName
        {
            get { return _pccSlipRePrtDivName; }
            set { _pccSlipRePrtDivName = value; }
        }

        /// public propaty name  :  PrtSelPrmDspDiv
        /// <summary>���i�I��D�Ǖ\���敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��D�Ǖ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelPrmDspDiv
        {
            get { return _prtSelPrmDspDiv; }
            set { _prtSelPrmDspDiv = value; }
        }

        /// public propaty name  :  PrtSelPrmDspDivName
        /// <summary>���i�I��D�Ǖ\�����̃v���p�e�B</summary>
        /// <value>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��D�Ǖ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelPrmDspDivName
        {
            get { return _prtSelPrmDspDivName; }
            set { _prtSelPrmDspDivName = value; }
        }

        /// public propaty name  :  StckStDspDiv
        /// <summary>�݌ɏ󋵕\���敪�v���p�e�B</summary>
        /// <value>0:�}�[�N 1:���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵕\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckStDspDiv
        {
            get { return _stckStDspDiv; }
            set { _stckStDspDiv = value; }
        }

        /// public propaty name  :  StckStDspDivName
        /// <summary>�݌ɏ󋵕\�����̃v���p�e�B</summary>
        /// <value>0:�}�[�N 1:���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵕\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStDspDivName
        {
            get { return _stckStDspDivName; }
            set { _stckStDspDivName = value; }
        }


        /// public propaty name  :  StckStComment1
        /// <summary>�݌ɃR�����g1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɃR�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment1
        {
            get { return _stckStComment1; }
            set { _stckStComment1 = value; }
        }

        /// public propaty name  :  StckStComment2
        /// <summary>�݌ɃR�����g2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɃR�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment2
        {
            get { return _stckStComment2; }
            set { _stckStComment2 = value; }
        }

        /// public propaty name  :  StckStComment3
        /// <summary>�݌ɃR�����g3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɃR�����g3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment3
        {
            get { return _stckStComment3; }
            set { _stckStComment3 = value; }
        }


        /// <summary>
        /// BLP���Аݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccCmpnySt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnySt()
        {
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="pccCompanyName">PCC���Ж���(PM�̓��Ӑ於��)</param>
        /// <param name="pccWarehouseCd">PCC�q�ɃR�[�h</param>
        /// <param name="pccWarehouseNm">PCC�q�ɖ���</param>
        /// <param name="pccPriWarehouseCd1">PCC�D��q�ɃR�[�h1</param>
        /// <param name="pccPriWarehouseCd2">PCC�D��q�ɃR�[�h2</param>
        /// <param name="pccPriWarehouseCd3">PCC�D��q�ɃR�[�h3</param>
        /// <param name="goodsNoDspDiv">�i�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="goodsNoDspDivName">�i�ԕ\���敪����(0:���� 1:���Ȃ�)</param>
        /// <param name="listPrcDspDiv">�W�����i�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="listPrcDspDivName">�W�����i�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="costDspDiv">�d�؉��i�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="costDspDivName">�d�؉��i�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="shelfDspDiv">�I�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="shelfDspDivName">�I�ԕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="stockDspDiv">�݌ɕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="stockDspDivName">�݌ɕ\���敪����(0:���� 1:���Ȃ�)</param>
        /// <param name="commentDspDiv">�R�����g�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="commentDspDivName">�R�����g�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="spmtCntDspDiv">�o�א��\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="spmtCntDspDivName">�o�א��\������(0:���� 1:���Ȃ�)</param>
        /// <param name="acptCntDspDiv">�󒍐��\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="acptCntDspDivName">�󒍐��\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelGdNoDspDiv">���i�I��i�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelGdNoDspDivName">���i�I��i�ԕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelLsPrDspDiv">���i�I��W�����i�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelLsPrDspDivName">���i�I��W�����i�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelSelfDspDiv">���i�I��I�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelSelfDspDivName">���i�I��I�ԕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelStckDspDiv">���i�I���݌ɕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelStckDspDivName">���i�I���݌ɕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="stckStMark1">�݌ɏ󋵃}�[�N1((���p�S�p����)�݌ɂ���)</param>
        /// <param name="stckStMark2">�݌ɏ󋵃}�[�N2((���p�S�p����)�݌ɂȂ�)</param>
        /// <param name="stckStMark3">�݌ɏ󋵃}�[�N3((���p�S�p����)�݌ɕs��)</param>
        /// <param name="pccSuplName1">PCC�����於��1((���p�S�p����))</param>
        /// <param name="pccSuplName2">PCC�����於��2((���p�S�p����))</param>
        /// <param name="pccSuplKana">PCC������J�i����((���p�̂�))</param>
        /// <param name="pccSuplSnm">PCC�����旪��((���p�S�p����))</param>
        /// <param name="pccSuplPostNo">PCC������X�֔ԍ�((���p�̂�))</param>
        /// <param name="pccSuplAddr1">PCC������Z��1((���p�S�p����))</param>
        /// <param name="pccSuplAddr2">PCC������Z��2((���p�S�p����))</param>
        /// <param name="pccSuplAddr3">PCC������Z��3((���p�S�p����))</param>
        /// <param name="pccSuplTelNo1">PCC������d�b�ԍ�1((���p�̂�))</param>
        /// <param name="pccSuplTelNo2">PCC������d�b�ԍ�2((���p�̂�))</param>
        /// <param name="pccSuplFaxNo">PCC������FAX�ԍ�((���p�̂�))</param>
        /// <param name="pccSlipPrtDiv">�`�[���s�敪�iPCC�j(0:���Ȃ� 1:�� 2:�Ӱ� 3:����)</param>
        /// <param name="pccSlipPrtDivName">�`�[���s���́iPCC�j(0:���Ȃ� 1:�� 2:�Ӱ� 3:����)</param>
        /// <param name="pccSlipRePrtDiv">�`�[�Ĕ��s�敪(0:���Ȃ� 1:����)</param>
        /// <param name="pccSlipRePrtDivName">�`�[�Ĕ��s����(0:���Ȃ� 1:����)</param>
        /// <param name="prtSelPrmDspDiv">���i�I��D�Ǖ\���敪(0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�)</param>
        /// <param name="prtSelPrmDspDivName">���i�I��D�Ǖ\������(0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�)</param>
        /// <param name="stckStDspDiv">�݌ɏ󋵕\���敪(0:�}�[�N 1:���݌ɐ�)</param>
        /// <param name="stckStDspDivName">�݌ɏ󋵕\������(0:�}�[�N 1:���݌ɐ�)</param>
        /// <param name="stckStComment1">�݌ɃR�����g1</param>
        /// <param name="stckStComment2">�݌ɃR�����g2</param>
        /// <param name="stckStComment3">�݌ɃR�����g3</param>
        /// <returns>PccCmpnySt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._pccCompanyName = pccCompanyName;
            this._pccWarehouseCd = pccWarehouseCd;
            this._pccWarehouseNm = pccWarehouseNm;
            this._pccPriWarehouseCd1 = pccPriWarehouseCd1;
            this._pccPriWarehouseCd2 = pccPriWarehouseCd2;
            this._pccPriWarehouseCd3 = pccPriWarehouseCd3;
            this._goodsNoDspDiv = goodsNoDspDiv;
            this._goodsNoDspDivName = goodsNoDspDivName;
            this._listPrcDspDiv = listPrcDspDiv;
            this._listPrcDspDivName = listPrcDspDivName;
            this._costDspDiv = costDspDiv;
            this._costDspDivName = costDspDivName;
            this._shelfDspDiv = shelfDspDiv;
            this._shelfDspDivName = shelfDspDivName;
            this._stockDspDiv = stockDspDiv;
            this._stockDspDivName = stockDspDivName;
            this._commentDspDiv = commentDspDiv;
            this._commentDspDivName = commentDspDivName;
            this._spmtCntDspDiv = spmtCntDspDiv;
            this._spmtCntDspDivName = spmtCntDspDivName;
            this._acptCntDspDiv = acptCntDspDiv;
            this._acptCntDspDivName = acptCntDspDivName;
            this._prtSelGdNoDspDiv = prtSelGdNoDspDiv;
            this._prtSelGdNoDspDivName = prtSelGdNoDspDivName;
            this._prtSelLsPrDspDiv = prtSelLsPrDspDiv;
            this._prtSelLsPrDspDivName = prtSelLsPrDspDivName;
            this._prtSelSelfDspDiv = prtSelSelfDspDiv;
            this._prtSelSelfDspDivName = prtSelSelfDspDivName;
            this._prtSelStckDspDiv = prtSelStckDspDiv;
            this._prtSelStckDspDivName = prtSelStckDspDivName;
            this._stckStMark1 = stckStMark1;
            this._stckStMark2 = stckStMark2;
            this._stckStMark3 = stckStMark3;
            this._pccSuplName1 = pccSuplName1;
            this._pccSuplName2 = pccSuplName2;
            this._pccSuplKana = pccSuplKana;
            this._pccSuplSnm = pccSuplSnm;
            this._pccSuplPostNo = pccSuplPostNo;
            this._pccSuplAddr1 = pccSuplAddr1;
            this._pccSuplAddr2 = pccSuplAddr2;
            this._pccSuplAddr3 = pccSuplAddr3;
            this._pccSuplTelNo1 = pccSuplTelNo1;
            this._pccSuplTelNo2 = pccSuplTelNo2;
            this._pccSuplFaxNo = pccSuplFaxNo;
            this._pccSlipPrtDiv = pccSlipPrtDiv;
            this._pccSlipPrtDivName = pccSlipPrtDivName;
            this._pccSlipRePrtDiv = pccSlipRePrtDiv;
            this._pccSlipRePrtDivName = pccSlipRePrtDivName;
            this._prtSelPrmDspDiv = prtSelPrmDspDiv;
            this._prtSelPrmDspDivName = prtSelPrmDspDivName;
            this._stckStDspDiv = stckStDspDiv;
            this._stckStDspDivName = stckStDspDivName;
            this._stckStComment1 = stckStComment1;
            this._stckStComment2 = stckStComment2;
            this._stckStComment3 = stckStComment3;
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^��������
        /// </summary>
        /// <returns>PccCmpnySt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccCmpnySt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnySt Clone()
        {
            return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3);//@@@@20230303
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccCmpnySt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccCompanyName == target.PccCompanyName)
                 && (this.PccWarehouseCd == target.PccWarehouseCd)
                 && (this.PccWarehouseNm == target.PccWarehouseNm)
                 && (this.PccPriWarehouseCd1 == target.PccPriWarehouseCd1)
                 && (this.PccPriWarehouseCd2 == target.PccPriWarehouseCd2)
                 && (this.PccPriWarehouseCd3 == target.PccPriWarehouseCd3)
                 && (this.GoodsNoDspDiv == target.GoodsNoDspDiv)
                 && (this.GoodsNoDspDivName == target.GoodsNoDspDivName)
                 && (this.ListPrcDspDiv == target.ListPrcDspDiv)
                 && (this.ListPrcDspDivName == target.ListPrcDspDivName)
                 && (this.CostDspDiv == target.CostDspDiv)
                 && (this.CostDspDivName == target.CostDspDivName)
                 && (this.ShelfDspDiv == target.ShelfDspDiv)
                 && (this.ShelfDspDivName == target.ShelfDspDivName)
                 && (this.StockDspDiv == target.StockDspDiv)
                 && (this.StockDspDivName == target.StockDspDivName)
                 && (this.CommentDspDiv == target.CommentDspDiv)
                 && (this.CommentDspDivName == target.CommentDspDivName)
                 && (this.SpmtCntDspDiv == target.SpmtCntDspDiv)
                 && (this.SpmtCntDspDivName == target.SpmtCntDspDivName)
                 && (this.AcptCntDspDiv == target.AcptCntDspDiv)
                 && (this.AcptCntDspDivName == target.AcptCntDspDivName)
                 && (this.PrtSelGdNoDspDiv == target.PrtSelGdNoDspDiv)
                 && (this.PrtSelGdNoDspDivName == target.PrtSelGdNoDspDivName)
                 && (this.PrtSelLsPrDspDiv == target.PrtSelLsPrDspDiv)
                 && (this.PrtSelLsPrDspDivName == target.PrtSelLsPrDspDivName)
                 && (this.PrtSelSelfDspDiv == target.PrtSelSelfDspDiv)
                 && (this.PrtSelSelfDspDivName == target.PrtSelSelfDspDivName)
                 && (this.PrtSelStckDspDiv == target.PrtSelStckDspDiv)
                 && (this.PrtSelStckDspDivName == target.PrtSelStckDspDivName)
                 && (this.StckStMark1 == target.StckStMark1)
                 && (this.StckStMark2 == target.StckStMark2)
                 && (this.StckStMark3 == target.StckStMark3)
                 && (this.PccSuplName1 == target.PccSuplName1)
                 && (this.PccSuplName2 == target.PccSuplName2)
                 && (this.PccSuplKana == target.PccSuplKana)
                 && (this.PccSuplSnm == target.PccSuplSnm)
                 && (this.PccSuplPostNo == target.PccSuplPostNo)
                 && (this.PccSuplAddr1 == target.PccSuplAddr1)
                 && (this.PccSuplAddr2 == target.PccSuplAddr2)
                 && (this.PccSuplAddr3 == target.PccSuplAddr3)
                 && (this.PccSuplTelNo1 == target.PccSuplTelNo1)
                 && (this.PccSuplTelNo2 == target.PccSuplTelNo2)
                 && (this.PccSuplFaxNo == target.PccSuplFaxNo)
                 && (this.PccSlipPrtDiv == target.PccSlipPrtDiv)
                 && (this.PccSlipPrtDivName == target.PccSlipPrtDivName)
                 && (this.PccSlipRePrtDiv == target.PccSlipRePrtDiv)
                 && (this.PccSlipRePrtDivName == target.PccSlipRePrtDivName)
                 && (this.PrtSelPrmDspDiv == target.PrtSelPrmDspDiv)
                 && (this.PrtSelPrmDspDivName == target.PrtSelPrmDspDivName)
                 && (this.StckStDspDiv == target.StckStDspDiv)
                 && (this.StckStDspDivName == target.StckStDspDivName)
                 && (this.StckStComment1 == target.StckStComment1)
                 && (this.StckStComment2 == target.StckStComment2)
                 && (this.StckStComment3 == target.StckStComment3));
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCmpnySt1">
        ///                    ��r����PccCmpnySt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccCmpnySt2">��r����PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccCmpnySt pccCmpnySt1, PccCmpnySt pccCmpnySt2)
        {
            return ((pccCmpnySt1.CreateDateTime == pccCmpnySt2.CreateDateTime)
                 && (pccCmpnySt1.UpdateDateTime == pccCmpnySt2.UpdateDateTime)
                 && (pccCmpnySt1.LogicalDeleteCode == pccCmpnySt2.LogicalDeleteCode)
                 && (pccCmpnySt1.InqOriginalEpCd.Trim() == pccCmpnySt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccCmpnySt1.InqOriginalSecCd == pccCmpnySt2.InqOriginalSecCd)
                 && (pccCmpnySt1.InqOtherEpCd == pccCmpnySt2.InqOtherEpCd)
                 && (pccCmpnySt1.InqOtherSecCd == pccCmpnySt2.InqOtherSecCd)
                 && (pccCmpnySt1.PccCompanyCode == pccCmpnySt2.PccCompanyCode)
                 && (pccCmpnySt1.PccCompanyName == pccCmpnySt2.PccCompanyName)
                 && (pccCmpnySt1.PccWarehouseCd == pccCmpnySt2.PccWarehouseCd)
                 && (pccCmpnySt1.PccWarehouseNm == pccCmpnySt2.PccWarehouseNm)
                 && (pccCmpnySt1.PccPriWarehouseCd1 == pccCmpnySt2.PccPriWarehouseCd1)
                 && (pccCmpnySt1.PccPriWarehouseCd2 == pccCmpnySt2.PccPriWarehouseCd2)
                 && (pccCmpnySt1.PccPriWarehouseCd3 == pccCmpnySt2.PccPriWarehouseCd3)
                 && (pccCmpnySt1.GoodsNoDspDiv == pccCmpnySt2.GoodsNoDspDiv)
                 && (pccCmpnySt1.GoodsNoDspDivName == pccCmpnySt2.GoodsNoDspDivName)
                 && (pccCmpnySt1.ListPrcDspDiv == pccCmpnySt2.ListPrcDspDiv)
                 && (pccCmpnySt1.ListPrcDspDivName == pccCmpnySt2.ListPrcDspDivName)
                 && (pccCmpnySt1.CostDspDiv == pccCmpnySt2.CostDspDiv)
                 && (pccCmpnySt1.CostDspDivName == pccCmpnySt2.CostDspDivName)
                 && (pccCmpnySt1.ShelfDspDiv == pccCmpnySt2.ShelfDspDiv)
                 && (pccCmpnySt1.ShelfDspDivName == pccCmpnySt2.ShelfDspDivName)
                 && (pccCmpnySt1.StockDspDiv == pccCmpnySt2.StockDspDiv)
                 && (pccCmpnySt1.StockDspDivName == pccCmpnySt2.StockDspDivName)
                 && (pccCmpnySt1.CommentDspDiv == pccCmpnySt2.CommentDspDiv)
                 && (pccCmpnySt1.CommentDspDivName == pccCmpnySt2.CommentDspDivName)
                 && (pccCmpnySt1.SpmtCntDspDiv == pccCmpnySt2.SpmtCntDspDiv)
                 && (pccCmpnySt1.SpmtCntDspDivName == pccCmpnySt2.SpmtCntDspDivName)
                 && (pccCmpnySt1.AcptCntDspDiv == pccCmpnySt2.AcptCntDspDiv)
                 && (pccCmpnySt1.AcptCntDspDivName == pccCmpnySt2.AcptCntDspDivName)
                 && (pccCmpnySt1.PrtSelGdNoDspDiv == pccCmpnySt2.PrtSelGdNoDspDiv)
                 && (pccCmpnySt1.PrtSelGdNoDspDivName == pccCmpnySt2.PrtSelGdNoDspDivName)
                 && (pccCmpnySt1.PrtSelLsPrDspDiv == pccCmpnySt2.PrtSelLsPrDspDiv)
                 && (pccCmpnySt1.PrtSelLsPrDspDivName == pccCmpnySt2.PrtSelLsPrDspDivName)
                 && (pccCmpnySt1.PrtSelSelfDspDiv == pccCmpnySt2.PrtSelSelfDspDiv)
                 && (pccCmpnySt1.PrtSelSelfDspDivName == pccCmpnySt2.PrtSelSelfDspDivName)
                 && (pccCmpnySt1.PrtSelStckDspDiv == pccCmpnySt2.PrtSelStckDspDiv)
                 && (pccCmpnySt1.PrtSelStckDspDivName == pccCmpnySt2.PrtSelStckDspDivName)
                 && (pccCmpnySt1.StckStMark1 == pccCmpnySt2.StckStMark1)
                 && (pccCmpnySt1.StckStMark2 == pccCmpnySt2.StckStMark2)
                 && (pccCmpnySt1.StckStMark3 == pccCmpnySt2.StckStMark3)
                 && (pccCmpnySt1.PccSuplName1 == pccCmpnySt2.PccSuplName1)
                 && (pccCmpnySt1.PccSuplName2 == pccCmpnySt2.PccSuplName2)
                 && (pccCmpnySt1.PccSuplKana == pccCmpnySt2.PccSuplKana)
                 && (pccCmpnySt1.PccSuplSnm == pccCmpnySt2.PccSuplSnm)
                 && (pccCmpnySt1.PccSuplPostNo == pccCmpnySt2.PccSuplPostNo)
                 && (pccCmpnySt1.PccSuplAddr1 == pccCmpnySt2.PccSuplAddr1)
                 && (pccCmpnySt1.PccSuplAddr2 == pccCmpnySt2.PccSuplAddr2)
                 && (pccCmpnySt1.PccSuplAddr3 == pccCmpnySt2.PccSuplAddr3)
                 && (pccCmpnySt1.PccSuplTelNo1 == pccCmpnySt2.PccSuplTelNo1)
                 && (pccCmpnySt1.PccSuplTelNo2 == pccCmpnySt2.PccSuplTelNo2)
                 && (pccCmpnySt1.PccSuplFaxNo == pccCmpnySt2.PccSuplFaxNo)
                 && (pccCmpnySt1.PccSlipPrtDiv == pccCmpnySt2.PccSlipPrtDiv)
                 && (pccCmpnySt1.PccSlipPrtDivName == pccCmpnySt2.PccSlipPrtDivName)
                 && (pccCmpnySt1.PccSlipRePrtDiv == pccCmpnySt2.PccSlipRePrtDiv)
                 && (pccCmpnySt1.PccSlipRePrtDivName == pccCmpnySt2.PccSlipRePrtDivName)
                 && (pccCmpnySt1.PrtSelPrmDspDiv == pccCmpnySt2.PrtSelPrmDspDiv)
                 && (pccCmpnySt1.PrtSelPrmDspDivName == pccCmpnySt2.PrtSelPrmDspDivName)
                 && (pccCmpnySt1.StckStDspDiv == pccCmpnySt2.StckStDspDiv)
                 && (pccCmpnySt1.StckStDspDivName == pccCmpnySt2.StckStDspDivName)
                 && (pccCmpnySt1.StckStComment1 == pccCmpnySt2.StckStComment1)
                 && (pccCmpnySt1.StckStComment2 == pccCmpnySt2.StckStComment2)
                 && (pccCmpnySt1.StckStComment3 == pccCmpnySt2.StckStComment3));
        }
        /// <summary>
        /// BLP���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccCmpnySt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccCompanyName != target.PccCompanyName) resList.Add("PccCompanyName");
            if (this.PccWarehouseCd != target.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (this.PccWarehouseNm != target.PccWarehouseNm) resList.Add("PccWarehouseNm");
            if (this.PccPriWarehouseCd1 != target.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (this.PccPriWarehouseCd2 != target.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (this.PccPriWarehouseCd3 != target.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (this.GoodsNoDspDiv != target.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (this.GoodsNoDspDivName != target.GoodsNoDspDivName) resList.Add("GoodsNoDspDivName");
            if (this.ListPrcDspDiv != target.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (this.ListPrcDspDivName != target.ListPrcDspDivName) resList.Add("ListPrcDspDivName");
            if (this.CostDspDiv != target.CostDspDiv) resList.Add("CostDspDiv");
            if (this.CostDspDivName != target.CostDspDivName) resList.Add("CostDspDivName");
            if (this.ShelfDspDiv != target.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (this.ShelfDspDivName != target.ShelfDspDivName) resList.Add("ShelfDspDivName");
            if (this.StockDspDiv != target.StockDspDiv) resList.Add("StockDspDiv");
            if (this.StockDspDivName != target.StockDspDivName) resList.Add("StockDspDivName");
            if (this.CommentDspDiv != target.CommentDspDiv) resList.Add("CommentDspDiv");
            if (this.CommentDspDivName != target.CommentDspDivName) resList.Add("CommentDspDivName");
            if (this.SpmtCntDspDiv != target.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (this.SpmtCntDspDivName != target.SpmtCntDspDivName) resList.Add("SpmtCntDspDivName");
            if (this.AcptCntDspDiv != target.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (this.AcptCntDspDivName != target.AcptCntDspDivName) resList.Add("AcptCntDspDivName");
            if (this.PrtSelGdNoDspDiv != target.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (this.PrtSelGdNoDspDivName != target.PrtSelGdNoDspDivName) resList.Add("PrtSelGdNoDspDivName");
            if (this.PrtSelLsPrDspDiv != target.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (this.PrtSelLsPrDspDivName != target.PrtSelLsPrDspDivName) resList.Add("PrtSelLsPrDspDivName");
            if (this.PrtSelSelfDspDiv != target.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (this.PrtSelSelfDspDivName != target.PrtSelSelfDspDivName) resList.Add("PrtSelSelfDspDivName");
            if (this.PrtSelStckDspDiv != target.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (this.PrtSelStckDspDivName != target.PrtSelStckDspDivName) resList.Add("PrtSelStckDspDivName");
            if (this.StckStMark1 != target.StckStMark1) resList.Add("StckStMark1");
            if (this.StckStMark2 != target.StckStMark2) resList.Add("StckStMark2");
            if (this.StckStMark3 != target.StckStMark3) resList.Add("StckStMark3");
            if (this.PccSuplName1 != target.PccSuplName1) resList.Add("PccSuplName1");
            if (this.PccSuplName2 != target.PccSuplName2) resList.Add("PccSuplName2");
            if (this.PccSuplKana != target.PccSuplKana) resList.Add("PccSuplKana");
            if (this.PccSuplSnm != target.PccSuplSnm) resList.Add("PccSuplSnm");
            if (this.PccSuplPostNo != target.PccSuplPostNo) resList.Add("PccSuplPostNo");
            if (this.PccSuplAddr1 != target.PccSuplAddr1) resList.Add("PccSuplAddr1");
            if (this.PccSuplAddr2 != target.PccSuplAddr2) resList.Add("PccSuplAddr2");
            if (this.PccSuplAddr3 != target.PccSuplAddr3) resList.Add("PccSuplAddr3");
            if (this.PccSuplTelNo1 != target.PccSuplTelNo1) resList.Add("PccSuplTelNo1");
            if (this.PccSuplTelNo2 != target.PccSuplTelNo2) resList.Add("PccSuplTelNo2");
            if (this.PccSuplFaxNo != target.PccSuplFaxNo) resList.Add("PccSuplFaxNo");
            if (this.PccSlipPrtDiv != target.PccSlipPrtDiv) resList.Add("PccSlipPrtDiv");
            if (this.PccSlipPrtDivName != target.PccSlipPrtDivName) resList.Add("PccSlipPrtDivName");
            if (this.PccSlipRePrtDiv != target.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (this.PccSlipRePrtDivName != target.PccSlipRePrtDivName) resList.Add("PccSlipRePrtDivName");
            if (this.PrtSelPrmDspDiv != target.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (this.PrtSelPrmDspDivName != target.PrtSelPrmDspDivName) resList.Add("PrtSelPrmDspDivName");
            if (this.StckStDspDiv != target.StckStDspDiv) resList.Add("StckStDspDiv");
            if (this.StckStDspDivName != target.StckStDspDivName) resList.Add("StckStDspDivName");
            if (this.StckStComment1 != target.StckStComment1) resList.Add("StckStComment1");
            if (this.StckStComment2 != target.StckStComment2) resList.Add("StckStComment2");
            if (this.StckStComment3 != target.StckStComment3) resList.Add("StckStComment3");

            return resList;
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCmpnySt1">��r����PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <param name="pccCmpnySt2">��r����PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccCmpnySt pccCmpnySt1, PccCmpnySt pccCmpnySt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCmpnySt1.CreateDateTime != pccCmpnySt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCmpnySt1.UpdateDateTime != pccCmpnySt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCmpnySt1.LogicalDeleteCode != pccCmpnySt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCmpnySt1.InqOriginalEpCd.Trim() != pccCmpnySt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccCmpnySt1.InqOriginalSecCd != pccCmpnySt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccCmpnySt1.InqOtherEpCd != pccCmpnySt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCmpnySt1.InqOtherSecCd != pccCmpnySt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCmpnySt1.PccCompanyCode != pccCmpnySt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccCmpnySt1.PccCompanyName != pccCmpnySt2.PccCompanyName) resList.Add("PccCompanyName");
            if (pccCmpnySt1.PccWarehouseCd != pccCmpnySt2.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (pccCmpnySt1.PccWarehouseNm != pccCmpnySt2.PccWarehouseNm) resList.Add("PccWarehouseNm");
            if (pccCmpnySt1.PccPriWarehouseCd1 != pccCmpnySt2.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (pccCmpnySt1.PccPriWarehouseCd2 != pccCmpnySt2.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (pccCmpnySt1.PccPriWarehouseCd3 != pccCmpnySt2.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (pccCmpnySt1.GoodsNoDspDiv != pccCmpnySt2.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (pccCmpnySt1.GoodsNoDspDivName != pccCmpnySt2.GoodsNoDspDivName) resList.Add("GoodsNoDspDivName");
            if (pccCmpnySt1.ListPrcDspDiv != pccCmpnySt2.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (pccCmpnySt1.ListPrcDspDivName != pccCmpnySt2.ListPrcDspDivName) resList.Add("ListPrcDspDivName");
            if (pccCmpnySt1.CostDspDiv != pccCmpnySt2.CostDspDiv) resList.Add("CostDspDiv");
            if (pccCmpnySt1.CostDspDivName != pccCmpnySt2.CostDspDivName) resList.Add("CostDspDivName");
            if (pccCmpnySt1.ShelfDspDiv != pccCmpnySt2.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (pccCmpnySt1.ShelfDspDivName != pccCmpnySt2.ShelfDspDivName) resList.Add("ShelfDspDivName");
            if (pccCmpnySt1.StockDspDiv != pccCmpnySt2.StockDspDiv) resList.Add("StockDspDiv");
            if (pccCmpnySt1.StockDspDivName != pccCmpnySt2.StockDspDivName) resList.Add("StockDspDivName");
            if (pccCmpnySt1.CommentDspDiv != pccCmpnySt2.CommentDspDiv) resList.Add("CommentDspDiv");
            if (pccCmpnySt1.CommentDspDivName != pccCmpnySt2.CommentDspDivName) resList.Add("CommentDspDivName");
            if (pccCmpnySt1.SpmtCntDspDiv != pccCmpnySt2.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (pccCmpnySt1.SpmtCntDspDivName != pccCmpnySt2.SpmtCntDspDivName) resList.Add("SpmtCntDspDivName");
            if (pccCmpnySt1.AcptCntDspDiv != pccCmpnySt2.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (pccCmpnySt1.AcptCntDspDivName != pccCmpnySt2.AcptCntDspDivName) resList.Add("AcptCntDspDivName");
            if (pccCmpnySt1.PrtSelGdNoDspDiv != pccCmpnySt2.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (pccCmpnySt1.PrtSelGdNoDspDivName != pccCmpnySt2.PrtSelGdNoDspDivName) resList.Add("PrtSelGdNoDspDivName");
            if (pccCmpnySt1.PrtSelLsPrDspDiv != pccCmpnySt2.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (pccCmpnySt1.PrtSelLsPrDspDivName != pccCmpnySt2.PrtSelLsPrDspDivName) resList.Add("PrtSelLsPrDspDivName");
            if (pccCmpnySt1.PrtSelSelfDspDiv != pccCmpnySt2.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (pccCmpnySt1.PrtSelSelfDspDivName != pccCmpnySt2.PrtSelSelfDspDivName) resList.Add("PrtSelSelfDspDivName");
            if (pccCmpnySt1.PrtSelStckDspDiv != pccCmpnySt2.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (pccCmpnySt1.PrtSelStckDspDivName != pccCmpnySt2.PrtSelStckDspDivName) resList.Add("PrtSelStckDspDivName");
            if (pccCmpnySt1.StckStMark1 != pccCmpnySt2.StckStMark1) resList.Add("StckStMark1");
            if (pccCmpnySt1.StckStMark2 != pccCmpnySt2.StckStMark2) resList.Add("StckStMark2");
            if (pccCmpnySt1.StckStMark3 != pccCmpnySt2.StckStMark3) resList.Add("StckStMark3");
            if (pccCmpnySt1.PccSuplName1 != pccCmpnySt2.PccSuplName1) resList.Add("PccSuplName1");
            if (pccCmpnySt1.PccSuplName2 != pccCmpnySt2.PccSuplName2) resList.Add("PccSuplName2");
            if (pccCmpnySt1.PccSuplKana != pccCmpnySt2.PccSuplKana) resList.Add("PccSuplKana");
            if (pccCmpnySt1.PccSuplSnm != pccCmpnySt2.PccSuplSnm) resList.Add("PccSuplSnm");
            if (pccCmpnySt1.PccSuplPostNo != pccCmpnySt2.PccSuplPostNo) resList.Add("PccSuplPostNo");
            if (pccCmpnySt1.PccSuplAddr1 != pccCmpnySt2.PccSuplAddr1) resList.Add("PccSuplAddr1");
            if (pccCmpnySt1.PccSuplAddr2 != pccCmpnySt2.PccSuplAddr2) resList.Add("PccSuplAddr2");
            if (pccCmpnySt1.PccSuplAddr3 != pccCmpnySt2.PccSuplAddr3) resList.Add("PccSuplAddr3");
            if (pccCmpnySt1.PccSuplTelNo1 != pccCmpnySt2.PccSuplTelNo1) resList.Add("PccSuplTelNo1");
            if (pccCmpnySt1.PccSuplTelNo2 != pccCmpnySt2.PccSuplTelNo2) resList.Add("PccSuplTelNo2");
            if (pccCmpnySt1.PccSuplFaxNo != pccCmpnySt2.PccSuplFaxNo) resList.Add("PccSuplFaxNo");
            if (pccCmpnySt1.PccSlipPrtDiv != pccCmpnySt2.PccSlipPrtDiv) resList.Add("PccSlipPrtDiv");
            if (pccCmpnySt1.PccSlipPrtDivName != pccCmpnySt2.PccSlipPrtDivName) resList.Add("PccSlipPrtDivName");
            if (pccCmpnySt1.PccSlipRePrtDiv != pccCmpnySt2.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (pccCmpnySt1.PccSlipRePrtDivName != pccCmpnySt2.PccSlipRePrtDivName) resList.Add("PccSlipRePrtDivName");
            if (pccCmpnySt1.PrtSelPrmDspDiv != pccCmpnySt2.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (pccCmpnySt1.PrtSelPrmDspDivName != pccCmpnySt2.PrtSelPrmDspDivName) resList.Add("PrtSelPrmDspDivName");
            if (pccCmpnySt1.StckStDspDiv != pccCmpnySt2.StckStDspDiv) resList.Add("StckStDspDiv");
            if (pccCmpnySt1.StckStDspDivName != pccCmpnySt2.StckStDspDivName) resList.Add("StckStDspDivName");
            if (pccCmpnySt1.StckStComment1 != pccCmpnySt2.StckStComment1) resList.Add("StckStComment1");
            if (pccCmpnySt1.StckStComment2 != pccCmpnySt2.StckStComment2) resList.Add("StckStComment2");
            if (pccCmpnySt1.StckStComment3 != pccCmpnySt2.StckStComment3) resList.Add("StckStComment3");

            return resList;
        }
    }
}
