using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockTtlSt
    /// <summary>
    ///                      �d���݌ɑS�̐ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���݌ɑS�̐ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/7/24</br>
    /// <br>Genarated Date   :   2008/02/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/2/13  ����</br>
    /// <br>                 :   �����x������R�[�h�C�����x�����햼��</br>
    /// <br>                 :   �����x������敪�̒ǉ�</br>
    /// <br>Update Note      :   2008.02.18 30167 ���@�O�M</br>
    /// <br>					 �����x���֘A���ڒǉ�</br>
    /// <br>Update Note      :   2008/2/25  ����</br>
    /// <br>                 :   ���o�א��敪�Q�̒ǉ�</br>
    /// <br>Update Note      :   </br>
    /// <br>                 :   ���ύX����ۂ̒��ӎ�������</br>
    /// <br>                 :   ���̃N���X�����ڒǉ��ȂǂŕύX����ꍇ�A���������c�[�����g�����̂܂ܒu����������</br>
    /// <br>                 :   �A�N�Z�X�N���X���ʂŃ��r���h�ł��܂���B�����x�����탊�X�g�Ȃǂ̃t�@�C���d�l���ɂ͂Ȃ����ڂ��ǉ�����Ă��܂��B</br>
    /// <br>                 :   (���̃N���X�ɏ�L���ڂ⃁�\�b�h��ǉ����Ă���̂���������(static�H)�A�{���Ȃ�A�N�Z�X�N���X�ɒǉ����Ȃ��Ǝ��������ł���Ӗ����Ȃ����A�{���̈Ӗ��ł̎d���݌ɑS�̐ݒ�}�X�^�̃N���X�ɂȂ�Ȃ�)</br>  
    /// <br>UpdateNote       :   2008/06/05 30415 �ēc �ύK</br>
    /// <br>        	         �E�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��</br>    
    /// <br>UpdateNote       :   2008/07/22 30415 �ēc �ύK</br>
    /// <br>        	         �E���ڂ̍폜�ɂ��C��</br>
    /// <br>UpdateNote       :   2008/09/12 30452 ��� �r��</br>
    /// <br>        	         �E�݌Ɍ����敪��ǉ�</br>   
    /// </remarks>
    public class StockTtlSt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�I�[���O�͑S��</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// <summary>�d���݌ɑS�̐ݒ�Ǘ��R�[�h</summary>
        /// <remarks>��ɂO�ݒ�</remarks>
        private Int32 _stockAllStMngCd;

        /// <summary>�ŗ��L����1</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validDtConsTaxRate1;

        /// <summary>����ŗ�1</summary>
        private Double _consTaxRate1;

        /// <summary>�ŗ��L����2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validDtConsTaxRate2;

        /// <summary>����ŗ�2</summary>
        private Double _consTaxRate2;

        /// <summary>�ŗ��L����3</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validDtConsTaxRate3;

        /// <summary>����ŗ�3</summary>
        private Double _consTaxRate3;

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// <summary>�d���l������</summary>
        private string _stockDiscountName = "";

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// <summary>���i�P��0�敪</summary>
        /// <remarks>0:�񋟃f�[�^���Q�Ƃ��Ȃ�,1:�񋟃f�[�^���Q�Ƃ���@���P</remarks>
        private Int32 _partsUnitPrcZeroCd;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// <summary>�ԕi�`�[���s�敪</summary>
        /// <remarks>0:���Ȃ��@1:����B</remarks>
        private Int32 _rgdsSlipPrtDiv;

        /// <summary>�ԕi���P������敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _rgdsUnPrcPrtDiv;

        /// <summary>�ԕi���[���~����敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _rgdsZeroPrtDiv;

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// <summary>���o�א��敪</summary>
        ///// <remarks>0:�`�F�b�N�����@1:�x��  2:�x���{�ē���(�d�����㓯�����͂̍ۂ̓��א����o�א��̃`�F�b�N�j</remarks>
        //private Int32 _ioGoodsCntDiv;

        ///// <summary>���o�א��敪�Q</summary>
        ///// <remarks>0:�`�F�b�N�����@1:�x��  2:�x���{�ē���(�d�����㓯�����͂̍ۂ̓��א����o�א��̃`�F�b�N�j</remarks>
        //private Int32 _ioGoodsCntDiv2;

        ///// <summary>�d���`�������l</summary>
        ///// <remarks>0:�d���@1:���ׁ@(�d�����㓯�����͂̏����l�ݒ�j</remarks>
        //private Int32 _supplierFormalIni;

        ///// <summary>���㖾�׊m�F</summary>
        ///// <remarks>0:�C�Ӂ@1:�K�{�@�i�d�����㓯�����͂̔��㖾�׊m�F�j</remarks>
        //private Int32 _salesSlipDtlConf;
        // --- DEL 2008/07/22 --------------------------------<<<<< 

        /// <summary>�艿���͋敪</summary>
        /// <remarks>0:�\�@1:�s��  (�d�����ׂ̒艿���́j</remarks>
        private Int32 _listPriceInpDiv;

        /// <summary>�P�����͋敪</summary>
        /// <remarks>0:�\�@1:�s��  (�d�����ׂ̎d���P�����́j</remarks>
        private Int32 _unitPriceInpDiv;

        /// <summary>���ה��l�\���敪</summary>
        /// <remarks>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
        private Int32 _dtlNoteDispDiv;

        /// <summary>�����x������R�[�h</summary>
        /// <remarks>�G���g���ł̎����x���̋���</remarks>
        private Int32 _autoPayMoneyKindCode;

        /// <summary>�����x�����햼��</summary>
        /// <remarks>�G���g���ł̎����x���̋���</remarks>
        private string _autoPayMoneyKindName = "";

        /// <summary>�����x������敪</summary>
        /// <remarks>�G���g���ł̎����x���̋���</remarks>
        private Int32 _autoPayMoneyKindDiv;

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// <summary>�����x���敪</summary>
        /// <remarks>0:�ʏ�x��,1:�����x���i�x���`�[���͂��甭���j</remarks>
        private Int32 _autoPayment;

        /// <summary>�艿�����X�V�敪</summary>
        /// <remarks>0:��X�V�@1:�������X�V�@2:�m�F�X�V</remarks>
        private Int32 _priceCostUpdtDiv;

        /// <summary>���i�����o�^</summary>
        /// <remarks>0:�Ȃ��@1:����</remarks>
        private Int32 _autoEntryGoodsDivCd;

        /// <summary>�艿�`�F�b�N�敪</summary>
        /// <remarks>0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j</remarks>
        private Int32 _priceCheckDivCd;

        /// <summary>�d���P���`�F�b�N�敪</summary>
        /// <remarks>0:�����@1:�ē��́@2:�x��MSG�@�i�P���������̏ꍇ�j</remarks>
        private Int32 _stockUnitChgDivCd;

        /// <summary>���_�\���敪</summary>
        /// <remarks>0:�W���@1:����Ͻ��@2:�\������</remarks>
        private Int32 _sectDspDivCd;

        /// <summary>�`�[���t�N���A�敪</summary>
        /// <remarks>0:�V�X�e�����t 1:���͓��t</remarks>
        private Int32 _slipDateClrDivCd;

        /// <summary>�x���`�[���t�N���A�敪</summary>
        /// <remarks>0:�V�X�e�����t�ɖ߂� 1:���͓��t�̂܂�</remarks>
        private Int32 _paySlipDateClrDiv;

        /// <summary>�x���`�[���t�͈͋敪</summary>
        /// <remarks>0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s��</remarks>
        private Int32 _paySlipDateAmbit;
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�d�������œ]�ŕ�������</summary>
        /// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
        private string _suppCTaxLayMethodNm = "";

        // --- ADD 2008/09/12 -------------------------------->>>>>
        /// <summary>�݌Ɍ����敪</summary>
        /// <remarks>0:�D��q�� 1:�w��q��</remarks>
        private Int32 _stockSearchDiv;
        // --- ADD 2008/09/12 --------------------------------<<<<<

        // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
        /// <summary>���i���ĕ\���敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _goodsNmReDispDivCd;
        // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
        

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�I�[���O�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  StockAllStMngCd
        /// <summary>�d���݌ɑS�̐ݒ�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��ɂO�ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���݌ɑS�̐ݒ�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAllStMngCd
        {
            get { return _stockAllStMngCd; }
            set { _stockAllStMngCd = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate1
        /// <summary>�ŗ��L����1�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidDtConsTaxRate1
        {
            get { return _validDtConsTaxRate1; }
            set { _validDtConsTaxRate1 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate1JpFormal
        /// <summary>�ŗ��L����1 �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����1 �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate1JpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate1JpInFormal
        /// <summary>�ŗ��L����1 �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����1 �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate1JpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate1AdFormal
        /// <summary>�ŗ��L����1 ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����1 ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate1AdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate1AdInFormal
        /// <summary>�ŗ��L����1 ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����1 ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate1AdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validDtConsTaxRate1); }
            set { }
        }

        /// public propaty name  :  ConsTaxRate1
        /// <summary>����ŗ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ŗ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate1
        {
            get { return _consTaxRate1; }
            set { _consTaxRate1 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate2
        /// <summary>�ŗ��L����2�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidDtConsTaxRate2
        {
            get { return _validDtConsTaxRate2; }
            set { _validDtConsTaxRate2 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate2JpFormal
        /// <summary>�ŗ��L����2 �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����2 �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate2JpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate2JpInFormal
        /// <summary>�ŗ��L����2 �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����2 �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate2JpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate2AdFormal
        /// <summary>�ŗ��L����2 ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����2 ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate2AdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate2AdInFormal
        /// <summary>�ŗ��L����2 ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����2 ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate2AdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validDtConsTaxRate2); }
            set { }
        }

        /// public propaty name  :  ConsTaxRate2
        /// <summary>����ŗ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ŗ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate2
        {
            get { return _consTaxRate2; }
            set { _consTaxRate2 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate3
        /// <summary>�ŗ��L����3�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidDtConsTaxRate3
        {
            get { return _validDtConsTaxRate3; }
            set { _validDtConsTaxRate3 = value; }
        }

        /// public propaty name  :  ValidDtConsTaxRate3JpFormal
        /// <summary>�ŗ��L����3 �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����3 �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate3JpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate3JpInFormal
        /// <summary>�ŗ��L����3 �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����3 �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate3JpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate3AdFormal
        /// <summary>�ŗ��L����3 ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����3 ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate3AdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ValidDtConsTaxRate3AdInFormal
        /// <summary>�ŗ��L����3 ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��L����3 ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidDtConsTaxRate3AdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validDtConsTaxRate3); }
            set { }
        }

        /// public propaty name  :  ConsTaxRate3
        /// <summary>����ŗ�3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ŗ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate3
        {
            get { return _consTaxRate3; }
            set { _consTaxRate3 = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }
           --- DEL 2008/06/05 --------------------------------<<<<< */

        /// public propaty name  :  StockDiscountName
        /// <summary>�d���l�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���l�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDiscountName
        {
            get { return _stockDiscountName; }
            set { _stockDiscountName = value; }
        }

        /* --- DEL 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  PartsUnitPrcZeroCd
        /// <summary>���i�P��0�敪�v���p�e�B</summary>
        /// <value>0:�񋟃f�[�^���Q�Ƃ��Ȃ�,1:�񋟃f�[�^���Q�Ƃ���@���P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�P��0�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsUnitPrcZeroCd
        {
            get { return _partsUnitPrcZeroCd; }
            set { _partsUnitPrcZeroCd = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</value>
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
            --- DEL 2008/06/05 --------------------------------<<<<< */

        /// public propaty name  :  RgdsSlipPrtDiv
        /// <summary>�ԕi�`�[���s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�`�[���s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RgdsSlipPrtDiv
        {
            get { return _rgdsSlipPrtDiv; }
            set { _rgdsSlipPrtDiv = value; }
        }

        /// public propaty name  :  RgdsUnPrcPrtDiv
        /// <summary>�ԕi���P������敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���P������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RgdsUnPrcPrtDiv
        {
            get { return _rgdsUnPrcPrtDiv; }
            set { _rgdsUnPrcPrtDiv = value; }
        }

        /// public propaty name  :  RgdsZeroPrtDiv
        /// <summary>�ԕi���[���~����敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���[���~����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RgdsZeroPrtDiv
        {
            get { return _rgdsZeroPrtDiv; }
            set { _rgdsZeroPrtDiv = value; }
        }

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// public propaty name  :  IoGoodsCntDiv
        ///// <summary>���o�א��敪�v���p�e�B</summary>
        ///// <value>0:�`�F�b�N�����@1:�x��  2:�x���{�ē���(�d�����㓯�����͂̍ۂ̓��א����o�א��̃`�F�b�N�j</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���o�א��敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 IoGoodsCntDiv
        //{
        //    get { return _ioGoodsCntDiv; }
        //    set { _ioGoodsCntDiv = value; }
        //}

        ///// public propaty name  :  IoGoodsCntDiv2
        ///// <summary>���o�א��敪�Q�v���p�e�B</summary>
        ///// <value>0:�`�F�b�N�����@1:�x��  2:�x���{�ē���(�d�����㓯�����͂̍ۂ̓��א����o�א��̃`�F�b�N�j</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���o�א��敪�Q�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 IoGoodsCntDiv2
        //{
        //    get { return _ioGoodsCntDiv2; }
        //    set { _ioGoodsCntDiv2 = value; }
        //}

        ///// public propaty name  :  SupplierFormalIni
        ///// <summary>�d���`�������l�v���p�e�B</summary>
        ///// <value>0:�d���@1:���ׁ@(�d�����㓯�����͂̏����l�ݒ�j</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �d���`�������l�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 SupplierFormalIni
        //{
        //    get { return _supplierFormalIni; }
        //    set { _supplierFormalIni = value; }
        //}

        ///// public propaty name  :  SalesSlipDtlConf
        ///// <summary>���㖾�׊m�F�v���p�e�B</summary>
        ///// <value>0:�C�Ӂ@1:�K�{�@�i�d�����㓯�����͂̔��㖾�׊m�F�j</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���㖾�׊m�F�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 SalesSlipDtlConf
        //{
        //    get { return _salesSlipDtlConf; }
        //    set { _salesSlipDtlConf = value; }
        //}
        // --- DEL 2008/07/22 --------------------------------<<<<< 

        /// public propaty name  :  ListPriceInpDiv
        /// <summary>�艿���͋敪�v���p�e�B</summary>
        /// <value>0:�\�@1:�s��  (�d�����ׂ̒艿���́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿���͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPriceInpDiv
        {
            get { return _listPriceInpDiv; }
            set { _listPriceInpDiv = value; }
        }

        /// public propaty name  :  UnitPriceInpDiv
        /// <summary>�P�����͋敪�v���p�e�B</summary>
        /// <value>0:�\�@1:�s��  (�d�����ׂ̎d���P�����́j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P�����͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnitPriceInpDiv
        {
            get { return _unitPriceInpDiv; }
            set { _unitPriceInpDiv = value; }
        }

        /// public propaty name  :  DtlNoteDispDiv
        /// <summary>���ה��l�\���敪�v���p�e�B</summary>
        /// <value>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ה��l�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlNoteDispDiv
        {
            get { return _dtlNoteDispDiv; }
            set { _dtlNoteDispDiv = value; }
        }

        /// public propaty name  :  AutoPayMoneyKindCode
        /// <summary>�����x������R�[�h�v���p�e�B</summary>
        /// <value>�G���g���ł̎����x���̋���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayMoneyKindCode
        {
            get { return _autoPayMoneyKindCode; }
            set { _autoPayMoneyKindCode = value; }
        }

        /// public propaty name  :  AutoPayMoneyKindName
        /// <summary>�����x�����햼�̃v���p�e�B</summary>
        /// <value>�G���g���ł̎����x���̋���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x�����햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AutoPayMoneyKindName
        {
            get { return _autoPayMoneyKindName; }
            set { _autoPayMoneyKindName = value; }
        }

        /// public propaty name  :  AutoPayMoneyKindDiv
        /// <summary>�����x������敪�v���p�e�B</summary>
        /// <value>�G���g���ł̎����x���̋���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayMoneyKindDiv
        {
            get { return _autoPayMoneyKindDiv; }
            set { _autoPayMoneyKindDiv = value; }
        }

        // --- ADD 2008/06/05 -------------------------------->>>>>
        /// public propaty name  :  AutoPayment
        /// <summary>�����x���敪�v���p�e�B</summary>
        /// <value>0:�ʏ�x��,1:�����x���i�x���`�[���͂��甭���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  PriceCostUpdtDiv
        /// <summary>�艿�����X�V�敪�v���p�e�B</summary>
        /// <value>0:��X�V�@1:�������X�V�@2:�m�F�X�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�����X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 PriceCostUpdtDiv
        {
            get { return _priceCostUpdtDiv; }
            set { _priceCostUpdtDiv = value; }
        }

        /// public propaty name  :  AutoEntryGoodsDivCd
        /// <summary>���i�����o�^�v���p�e�B</summary>
        /// <value>0:�Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����o�^�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 AutoEntryGoodsDivCd
        {
            get { return _autoEntryGoodsDivCd; }
            set { _autoEntryGoodsDivCd = value; }
        }

        /// public propaty name  :  PriceCheckDivCd
        /// <summary>�艿�`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 PriceCheckDivCd
        {
            get { return _priceCheckDivCd; }
            set { _priceCheckDivCd = value; }
        }

        /// public propaty name  :  StockUnitChgDivCd
        /// <summary>�d���P���`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:�����@1:�ē��́@2:�x��MSG�@�i�P���������̏ꍇ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 StockUnitChgDivCd
        {
            get { return _stockUnitChgDivCd; }
            set { _stockUnitChgDivCd = value; }
        }

        /// public propaty name  :  SectDspDivCd
        /// <summary>���_�\���敪�v���p�e�B</summary>
        /// <value>0:�W���@1:����Ͻ��@2:�\������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�\���敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SectDspDivCd
        {
            get { return _sectDspDivCd; }
            set { _sectDspDivCd = value; }
        }

        /// public propaty name  :  SlipDateClrDivCd
        /// <summary>�`�[���t�N���A�敪�v���p�e�B</summary>
        /// <value>0:�V�X�e�����t 1:���͓��t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���t�N���A�敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 SlipDateClrDivCd
        {
            get { return _slipDateClrDivCd; }
            set { _slipDateClrDivCd = value; }
        }

        /// public propaty name  :  PaySlipDateClrDiv
        /// <summary>�x���`�[���t�N���A�敪�v���p�e�B</summary>
        /// <value>0:�V�X�e�����t�ɖ߂� 1:���͓��t�̂܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[���t�N���A�敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 PaySlipDateClrDiv
        {
            get { return _paySlipDateClrDiv; }
            set { _paySlipDateClrDiv = value; }
        }

        /// public propaty name  :  PaySlipDateAmbit
        /// <summary>�x���`�[���t�͈͋敪�v���p�e�B</summary>
        /// <value>0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[���t�͈͋敪�v���p�e�B</br>
        /// <br>Programer        :   30415 �ēc �ύK</br>
        /// </remarks>
        public Int32 PaySlipDateAmbit
        {
            get { return _paySlipDateAmbit; }
            set { _paySlipDateAmbit = value; }
        }
        // --- ADD 2008/06/05 --------------------------------<<<<< 

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>�d�������œ]�ŕ������̃v���p�e�B</summary>
        /// <value>�`�[�P�ʁA���גP�ʁA�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
        }

        // --- ADD 2008/09/12 -------------------------------->>>>>
        /// public propaty name  :  StockSearchDiv
        /// <summary>�݌Ɍ����敪�v���p�e�B</summary>
        /// <value>0:�D��q�� 1:�w��q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɍ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSearchDiv
        {
            get { return _stockSearchDiv; }
            set { _stockSearchDiv = value; }
        }
        // --- ADD 2008/09/12 --------------------------------<<<<<

        // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
        /// public propaty name  :  StockSearchDiv
        /// <summary>���i���ĕ\���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���ĕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNmReDispDivCd
        {
            get { return _goodsNmReDispDivCd; }
            set { _goodsNmReDispDivCd = value; }
        }
        // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
        
        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockTtlSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTtlSt()
        {
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h�i�I�[���O�͑S�Ёj</param>  // ADD 2008/06/05
        /// <param name="stockDiscountName">�d���l������</param>
        /// <param name="rgdsSlipPrtDiv">�ԕi�`�[���s�敪(0:���Ȃ��@1:����B)</param>
        /// <param name="rgdsUnPrcPrtDiv">�ԕi���P������敪(0:����@1:���Ȃ�)</param>
        /// <param name="rgdsZeroPrtDiv">�ԕi���[���~����敪(0:����@1:���Ȃ�)</param>
        /// <param name="listPriceInpDiv">�艿���͋敪(0:�\�@1:�s��  (�d�����ׂ̒艿���́j)</param>
        /// <param name="unitPriceInpDiv">�P�����͋敪(0:�\�@1:�s��  (�d�����ׂ̎d���P�����́j)</param>
        /// <param name="dtlNoteDispDiv">���ה��l�\���敪(0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) )</param>
        /// <param name="autoPayMoneyKindCode">�����x������R�[�h(�G���g���ł̎����x���̋���)</param>
        /// <param name="autoPayMoneyKindName">�����x�����햼��(�G���g���ł̎����x���̋���)</param>
        /// <param name="autoPayMoneyKindDiv">�����x������敪(�G���g���ł̎����x���̋���)</param>
        /// <param name="autoPayment">�����x���敪�i0:�ʏ�x��,1:�����x���i�x���`�[���͂��甭���j�j</param>
        /// <param name="priceCostUpdtDiv">�艿�����X�V�敪�i0:��X�V�@1:�������X�V�@2:�m�F�X�V�j</param>
        /// <param name="autoEntryGoodsDivCd">���i�����o�^�i0:�Ȃ��@1:����j</param>
        /// <param name="priceCheckDivCd">�艿�`�F�b�N�敪�i0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j�j</param>
        /// <param name="stockUnitChgDivCd">�d���P���`�F�b�N�敪�i0:�����@1:�ē��́@2:�x��MSG�@�i�P���������̏ꍇ�j�j</param>
        /// <param name="sectDspDivCd">���_�\���敪�i0:�W���@1:����Ͻ��@2:�\�������j</param>
        /// <param name="slipDateClrDivCd">�`�[���t�N���A�敪�i0:�V�X�e�����t 1:���͓��t�j</param>
        /// <param name="paySlipDateClrDiv">�x���`�[���t�N���A�敪�i0:�V�X�e�����t�ɖ߂� 1:���͓��t�̂܂܁j</param>
        /// <param name="paySlipDateAmbit">�x���`�[���t�͈͋敪�i0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s�j</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
        /// <param name="stockSearchDiv">�݌Ɍ����敪</param>
        /// <param name="goodsNmReDispDivCd">���i���ĕ\���敪</param>
        /// <returns>StockTtlSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public StockTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockAllStMngCd, DateTime validDtConsTaxRate1, Double consTaxRate1, DateTime validDtConsTaxRate2, Double consTaxRate2, DateTime validDtConsTaxRate3, Double consTaxRate3, Int32 totalAmountDispWayCd, string stockDiscountName, Int32 partsUnitPrcZeroCd, Int32 suppCTaxLayCd, Int32 rgdsSlipPrtDiv, Int32 rgdsUnPrcPrtDiv, Int32 rgdsZeroPrtDiv, Int32 ioGoodsCntDiv, Int32 ioGoodsCntDiv2, Int32 supplierFormalIni, Int32 salesSlipDtlConf, Int32 listPriceInpDiv, Int32 unitPriceInpDiv, Int32 dtlNoteDispDiv, Int32 autoPayMoneyKindCode, string autoPayMoneyKindName, Int32 autoPayMoneyKindDiv, string enterpriseName, string updEmployeeName, string suppCTaxLayMethodNm)  // DEL 2008/06/05
        //public StockTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string stockDiscountName, Int32 rgdsSlipPrtDiv, Int32 rgdsUnPrcPrtDiv, Int32 rgdsZeroPrtDiv, Int32 listPriceInpDiv, Int32 unitPriceInpDiv, Int32 dtlNoteDispDiv, Int32 autoPayMoneyKindCode, string autoPayMoneyKindName, Int32 autoPayMoneyKindDiv, string enterpriseName, string updEmployeeName, string suppCTaxLayMethodNm, Int32 autoPayment, Int32 priceCostUpdtDiv, Int32 autoEntryGoodsDivCd, Int32 priceCheckDivCd, Int32 stockUnitChgDivCd, Int32 sectDspDivCd, Int32 slipDateClrDivCd, Int32 paySlipDateClrDiv, Int32 paySlipDateAmbit, Int32 stockSearchDiv)  // ADD 2008/06/05
        public StockTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string stockDiscountName, Int32 rgdsSlipPrtDiv, Int32 rgdsUnPrcPrtDiv, Int32 rgdsZeroPrtDiv, Int32 listPriceInpDiv, Int32 unitPriceInpDiv, Int32 dtlNoteDispDiv, Int32 autoPayMoneyKindCode, string autoPayMoneyKindName, Int32 autoPayMoneyKindDiv, string enterpriseName, string updEmployeeName, string suppCTaxLayMethodNm, Int32 autoPayment, Int32 priceCostUpdtDiv, Int32 autoEntryGoodsDivCd, Int32 priceCheckDivCd, Int32 stockUnitChgDivCd, Int32 sectDspDivCd, Int32 slipDateClrDivCd, Int32 paySlipDateClrDiv, Int32 paySlipDateAmbit, Int32 stockSearchDiv, Int32 goodsNmReDispDivCd)  // ADD 2009.04.02
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;  // ADD 2008/06/05
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            this._stockAllStMngCd = stockAllStMngCd;
            this.ValidDtConsTaxRate1 = validDtConsTaxRate1;
            this._consTaxRate1 = consTaxRate1;
            this.ValidDtConsTaxRate2 = validDtConsTaxRate2;
            this._consTaxRate2 = consTaxRate2;
            this.ValidDtConsTaxRate3 = validDtConsTaxRate3;
            this._consTaxRate3 = consTaxRate3;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
               --- DEL 2008/06/05 --------------------------------<<<<< */
            this._stockDiscountName = stockDiscountName;
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            this._partsUnitPrcZeroCd = partsUnitPrcZeroCd;
            this._suppCTaxLayCd = suppCTaxLayCd;
               --- DEL 2008/06/05 --------------------------------<<<<< */
            this._rgdsSlipPrtDiv = rgdsSlipPrtDiv;
            this._rgdsUnPrcPrtDiv = rgdsUnPrcPrtDiv;
            this._rgdsZeroPrtDiv = rgdsZeroPrtDiv;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //this._ioGoodsCntDiv = ioGoodsCntDiv;
            //this._ioGoodsCntDiv2 = ioGoodsCntDiv2;
            //this._supplierFormalIni = supplierFormalIni;
            //this._salesSlipDtlConf = salesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            this._listPriceInpDiv = listPriceInpDiv;
            this._unitPriceInpDiv = unitPriceInpDiv;
            this._dtlNoteDispDiv = dtlNoteDispDiv;
            this._autoPayMoneyKindCode = autoPayMoneyKindCode;
            this._autoPayMoneyKindName = autoPayMoneyKindName;
            this._autoPayMoneyKindDiv = autoPayMoneyKindDiv;
            // --- ADD 2008/06/05 -------------------------------->>>>>
            this._autoPayment = autoPayment;
            this._priceCostUpdtDiv = priceCostUpdtDiv;
            this._autoEntryGoodsDivCd = autoEntryGoodsDivCd;
            this._priceCheckDivCd = priceCheckDivCd;
            this._stockUnitChgDivCd = stockUnitChgDivCd;
            this._sectDspDivCd = sectDspDivCd;
            this._slipDateClrDivCd = slipDateClrDivCd;
            this._paySlipDateClrDiv = paySlipDateClrDiv;
            this._paySlipDateAmbit = paySlipDateAmbit;
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
            // --- ADD 2008/09/12 -------------------------------->>>>>
            this._stockSearchDiv = stockSearchDiv;
            // --- ADD 2008/09/12 --------------------------------<<<<<
            // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
            this._goodsNmReDispDivCd = goodsNmReDispDivCd;
            // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^��������
        /// </summary>
        /// <returns>StockTtlSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockTtlSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTtlSt Clone()
        {
            //return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockAllStMngCd, this._validDtConsTaxRate1, this._consTaxRate1, this._validDtConsTaxRate2, this._consTaxRate2, this._validDtConsTaxRate3, this._consTaxRate3, this._totalAmountDispWayCd, this._stockDiscountName, this._partsUnitPrcZeroCd, this._suppCTaxLayCd, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._ioGoodsCntDiv, this._ioGoodsCntDiv2, this._supplierFormalIni, this._salesSlipDtlConf, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm);  // DEL 2008/06/05
            // --- DEL 2008/09/12 -------------------------------->>>>>
            //return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockDiscountName, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm, this._autoPayment, this._priceCostUpdtDiv, this._autoEntryGoodsDivCd, this._priceCheckDivCd, this._stockUnitChgDivCd, this._sectDspDivCd, this._slipDateClrDivCd, this._paySlipDateClrDiv, this._paySlipDateAmbit);  // ADD 2008/06/05
            // --- DEL 2008/09/12 --------------------------------<<<<<
            // --- ADD 2008/09/12 -------------------------------->>>>>
            //return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockDiscountName, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm, this._autoPayment, this._priceCostUpdtDiv, this._autoEntryGoodsDivCd, this._priceCheckDivCd, this._stockUnitChgDivCd, this._sectDspDivCd, this._slipDateClrDivCd, this._paySlipDateClrDiv, this._paySlipDateAmbit, this._stockSearchDiv);
            // --- ADD 2008/09/12 --------------------------------<<<<<
            return new StockTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockDiscountName, this._rgdsSlipPrtDiv, this._rgdsUnPrcPrtDiv, this._rgdsZeroPrtDiv, this._listPriceInpDiv, this._unitPriceInpDiv, this._dtlNoteDispDiv, this._autoPayMoneyKindCode, this._autoPayMoneyKindName, this._autoPayMoneyKindDiv, this._enterpriseName, this._updEmployeeName, this._suppCTaxLayMethodNm, this._autoPayment, this._priceCostUpdtDiv, this._autoEntryGoodsDivCd, this._priceCheckDivCd, this._stockUnitChgDivCd, this._sectDspDivCd, this._slipDateClrDivCd, this._paySlipDateClrDiv, this._paySlipDateAmbit, this._stockSearchDiv, this._goodsNmReDispDivCd);   // ADD 2009.04.02
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockTtlSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockTtlSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)  // ADD 2008/06/05
                 /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (this.StockAllStMngCd == target.StockAllStMngCd)
                && (this.ValidDtConsTaxRate1 == target.ValidDtConsTaxRate1)
                && (this.ConsTaxRate1 == target.ConsTaxRate1)
                && (this.ValidDtConsTaxRate2 == target.ValidDtConsTaxRate2)
                && (this.ConsTaxRate2 == target.ConsTaxRate2)
                && (this.ValidDtConsTaxRate3 == target.ValidDtConsTaxRate3)
                && (this.ConsTaxRate3 == target.ConsTaxRate3)
                && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                    --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (this.StockDiscountName == target.StockDiscountName)
                /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (this.PartsUnitPrcZeroCd == target.PartsUnitPrcZeroCd)
                && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                   --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (this.RgdsSlipPrtDiv == target.RgdsSlipPrtDiv)
                 && (this.RgdsUnPrcPrtDiv == target.RgdsUnPrcPrtDiv)
                 && (this.RgdsZeroPrtDiv == target.RgdsZeroPrtDiv)

                 // --- DEL 2008/07/22 -------------------------------->>>>>
                 //&& (this.IoGoodsCntDiv == target.IoGoodsCntDiv)
                 //&& (this.IoGoodsCntDiv2 == target.IoGoodsCntDiv2)
                 //&& (this.SupplierFormalIni == target.SupplierFormalIni)
                 //&& (this.SalesSlipDtlConf == target.SalesSlipDtlConf)
                // --- DEL 2008/07/22 --------------------------------<<<<< 

                 && (this.ListPriceInpDiv == target.ListPriceInpDiv)
                 && (this.UnitPriceInpDiv == target.UnitPriceInpDiv)
                 && (this.DtlNoteDispDiv == target.DtlNoteDispDiv)
                 && (this.AutoPayMoneyKindCode == target.AutoPayMoneyKindCode)
                 && (this.AutoPayMoneyKindName == target.AutoPayMoneyKindName)
                 && (this.AutoPayMoneyKindDiv == target.AutoPayMoneyKindDiv)
                 // --- ADD 2008/06/05 -------------------------------->>>>>
                 && (this.AutoPayment == target.AutoPayment)      
                 && (this.PriceCostUpdtDiv == target.PriceCostUpdtDiv)
                 && (this.AutoEntryGoodsDivCd == target.AutoEntryGoodsDivCd)
                 && (this.PriceCheckDivCd == target.PriceCheckDivCd)
                 && (this.StockUnitChgDivCd == target.StockUnitChgDivCd)
                 && (this.SectDspDivCd == target.SectDspDivCd)
                 && (this.SlipDateClrDivCd == target.SlipDateClrDivCd)
                 && (this.PaySlipDateClrDiv == target.PaySlipDateClrDiv)
                 && (this.PaySlipDateAmbit == target.PaySlipDateAmbit)
                 // --- ADD 2008/06/05 --------------------------------<<<<< 
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
                // --- ADD 2008/09/12 -------------------------------->>>>>
                 //&& (this.StockSearchDiv == target.StockSearchDiv));
                 // --- ADD 2008/09/12 --------------------------------<<<<<
                 // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
                 && (this.StockSearchDiv == target.StockSearchDiv)
                 && (this.GoodsNmReDispDivCd == target.GoodsNmReDispDivCd));
                 // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END

        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^��r����
        /// </summary>
        /// <param name="stockTtlSt1">
        ///                    ��r����StockTtlSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockTtlSt2">��r����StockTtlSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockTtlSt stockTtlSt1, StockTtlSt stockTtlSt2)
        {
            return ((stockTtlSt1.CreateDateTime == stockTtlSt2.CreateDateTime)
                 && (stockTtlSt1.UpdateDateTime == stockTtlSt2.UpdateDateTime)
                 && (stockTtlSt1.EnterpriseCode == stockTtlSt2.EnterpriseCode)
                 && (stockTtlSt1.FileHeaderGuid == stockTtlSt2.FileHeaderGuid)
                 && (stockTtlSt1.UpdEmployeeCode == stockTtlSt2.UpdEmployeeCode)
                 && (stockTtlSt1.UpdAssemblyId1 == stockTtlSt2.UpdAssemblyId1)
                 && (stockTtlSt1.UpdAssemblyId2 == stockTtlSt2.UpdAssemblyId2)
                 && (stockTtlSt1.LogicalDeleteCode == stockTtlSt2.LogicalDeleteCode)
                 && (stockTtlSt1.SectionCode == stockTtlSt2.SectionCode)  // ADD 2008/06/05
                /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (stockTtlSt1.StockAllStMngCd == stockTtlSt2.StockAllStMngCd)
                && (stockTtlSt1.ValidDtConsTaxRate1 == stockTtlSt2.ValidDtConsTaxRate1)
                && (stockTtlSt1.ConsTaxRate1 == stockTtlSt2.ConsTaxRate1)
                && (stockTtlSt1.ValidDtConsTaxRate2 == stockTtlSt2.ValidDtConsTaxRate2)
                && (stockTtlSt1.ConsTaxRate2 == stockTtlSt2.ConsTaxRate2)
                && (stockTtlSt1.ValidDtConsTaxRate3 == stockTtlSt2.ValidDtConsTaxRate3)
                && (stockTtlSt1.ConsTaxRate3 == stockTtlSt2.ConsTaxRate3)
                && (stockTtlSt1.TotalAmountDispWayCd == stockTtlSt2.TotalAmountDispWayCd)
                   --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (stockTtlSt1.StockDiscountName == stockTtlSt2.StockDiscountName)
                /* --- DEL 2008/06/05 -------------------------------->>>>>
                && (stockTtlSt1.PartsUnitPrcZeroCd == stockTtlSt2.PartsUnitPrcZeroCd)
                && (stockTtlSt1.SuppCTaxLayCd == stockTtlSt2.SuppCTaxLayCd)
                   --- DEL 2008/06/05 --------------------------------<<<<< */
                 && (stockTtlSt1.RgdsSlipPrtDiv == stockTtlSt2.RgdsSlipPrtDiv)
                 && (stockTtlSt1.RgdsUnPrcPrtDiv == stockTtlSt2.RgdsUnPrcPrtDiv)
                 && (stockTtlSt1.RgdsZeroPrtDiv == stockTtlSt2.RgdsZeroPrtDiv)

                 // --- DEL 2008/07/22 -------------------------------->>>>>
                 //&& (stockTtlSt1.IoGoodsCntDiv == stockTtlSt2.IoGoodsCntDiv)
                 //&& (stockTtlSt1.IoGoodsCntDiv2 == stockTtlSt2.IoGoodsCntDiv2)
                 //&& (stockTtlSt1.SupplierFormalIni == stockTtlSt2.SupplierFormalIni)
                 //&& (stockTtlSt1.SalesSlipDtlConf == stockTtlSt2.SalesSlipDtlConf)
                // --- DEL 2008/07/22 --------------------------------<<<<< 

                 && (stockTtlSt1.ListPriceInpDiv == stockTtlSt2.ListPriceInpDiv)
                 && (stockTtlSt1.UnitPriceInpDiv == stockTtlSt2.UnitPriceInpDiv)
                 && (stockTtlSt1.DtlNoteDispDiv == stockTtlSt2.DtlNoteDispDiv)
                 && (stockTtlSt1.AutoPayMoneyKindCode == stockTtlSt2.AutoPayMoneyKindCode)
                 && (stockTtlSt1.AutoPayMoneyKindName == stockTtlSt2.AutoPayMoneyKindName)
                 && (stockTtlSt1.AutoPayMoneyKindDiv == stockTtlSt2.AutoPayMoneyKindDiv)
                 // --- ADD 2008/06/05 -------------------------------->>>>>
                 && (stockTtlSt1.AutoPayment == stockTtlSt2.AutoPayment)
                 && (stockTtlSt1.PriceCostUpdtDiv == stockTtlSt2.PriceCostUpdtDiv)
                 && (stockTtlSt1.AutoEntryGoodsDivCd == stockTtlSt2.AutoEntryGoodsDivCd)
                 && (stockTtlSt1.PriceCheckDivCd == stockTtlSt2.PriceCheckDivCd)
                 && (stockTtlSt1.StockUnitChgDivCd == stockTtlSt2.StockUnitChgDivCd)
                 && (stockTtlSt1.SectDspDivCd == stockTtlSt2.SectDspDivCd)
                 && (stockTtlSt1.SlipDateClrDivCd == stockTtlSt2.SlipDateClrDivCd)
                 && (stockTtlSt1.PaySlipDateClrDiv == stockTtlSt2.PaySlipDateClrDiv)
                 && (stockTtlSt1.PaySlipDateAmbit == stockTtlSt2.PaySlipDateAmbit)
                 // --- ADD 2008/06/05 --------------------------------<<<<< 
                 && (stockTtlSt1.EnterpriseName == stockTtlSt2.EnterpriseName)
                 && (stockTtlSt1.UpdEmployeeName == stockTtlSt2.UpdEmployeeName)
                 && (stockTtlSt1.SuppCTaxLayMethodNm == stockTtlSt2.SuppCTaxLayMethodNm)
                 // --- ADD 2008/09/12 -------------------------------->>>>>
                 //&& (stockTtlSt1.StockSearchDiv == stockTtlSt2.StockSearchDiv));
                 // --- ADD 2008/09/12 --------------------------------<<<<<
                 // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
                 && (stockTtlSt1.StockSearchDiv == stockTtlSt2.StockSearchDiv)
                 && (stockTtlSt1.GoodsNmReDispDivCd == stockTtlSt2.GoodsNmReDispDivCd));
                 // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
        }
        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockTtlSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockTtlSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (this.StockAllStMngCd != target.StockAllStMngCd) resList.Add("StockAllStMngCd");
            if (this.ValidDtConsTaxRate1 != target.ValidDtConsTaxRate1) resList.Add("ValidDtConsTaxRate1");
            if (this.ConsTaxRate1 != target.ConsTaxRate1) resList.Add("ConsTaxRate1");
            if (this.ValidDtConsTaxRate2 != target.ValidDtConsTaxRate2) resList.Add("ValidDtConsTaxRate2");
            if (this.ConsTaxRate2 != target.ConsTaxRate2) resList.Add("ConsTaxRate2");
            if (this.ValidDtConsTaxRate3 != target.ValidDtConsTaxRate3) resList.Add("ValidDtConsTaxRate3");
            if (this.ConsTaxRate3 != target.ConsTaxRate3) resList.Add("ConsTaxRate3");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (this.StockDiscountName != target.StockDiscountName) resList.Add("StockDiscountName");
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (this.PartsUnitPrcZeroCd != target.PartsUnitPrcZeroCd) resList.Add("PartsUnitPrcZeroCd");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (this.RgdsSlipPrtDiv != target.RgdsSlipPrtDiv) resList.Add("RgdsSlipPrtDiv");
            if (this.RgdsUnPrcPrtDiv != target.RgdsUnPrcPrtDiv) resList.Add("RgdsUnPrcPrtDiv");
            if (this.RgdsZeroPrtDiv != target.RgdsZeroPrtDiv) resList.Add("RgdsZeroPrtDiv");

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //if (this.IoGoodsCntDiv != target.IoGoodsCntDiv) resList.Add("IoGoodsCntDiv");
            //if (this.IoGoodsCntDiv2 != target.IoGoodsCntDiv2) resList.Add("IoGoodsCntDiv2");
            //if (this.SupplierFormalIni != target.SupplierFormalIni) resList.Add("SupplierFormalIni");
            //if (this.SalesSlipDtlConf != target.SalesSlipDtlConf) resList.Add("SalesSlipDtlConf");
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            if (this.ListPriceInpDiv != target.ListPriceInpDiv) resList.Add("ListPriceInpDiv");
            if (this.UnitPriceInpDiv != target.UnitPriceInpDiv) resList.Add("UnitPriceInpDiv");
            if (this.DtlNoteDispDiv != target.DtlNoteDispDiv) resList.Add("DtlNoteDispDiv");
            if (this.AutoPayMoneyKindCode != target.AutoPayMoneyKindCode) resList.Add("AutoPayMoneyKindCode");
            if (this.AutoPayMoneyKindName != target.AutoPayMoneyKindName) resList.Add("AutoPayMoneyKindName");
            if (this.AutoPayMoneyKindDiv != target.AutoPayMoneyKindDiv) resList.Add("AutoPayMoneyKindDiv");
            // --- ADD 2008/06/05 -------------------------------->>>>>
            if (this.AutoPayment != target.AutoPayment) resList.Add("AutoPayment");
            if (this.PriceCostUpdtDiv != target.PriceCostUpdtDiv) resList.Add("PriceCostUpdtDiv");
            if (this.AutoEntryGoodsDivCd != target.AutoEntryGoodsDivCd) resList.Add("AutoEntryGoodsDivCd");
            if (this.PriceCheckDivCd != target.PriceCheckDivCd) resList.Add("PriceCheckDivCd");
            if (this.StockUnitChgDivCd != target.StockUnitChgDivCd) resList.Add("StockUnitChgDivCd");
            if (this.SectDspDivCd != target.SectDspDivCd) resList.Add("SectDspDivCd");
            if (this.SlipDateClrDivCd != target.SlipDateClrDivCd) resList.Add("SlipDateClrDivCd");
            if (this.PaySlipDateClrDiv != target.PaySlipDateClrDiv) resList.Add("PaySlipDateClrDiv");
            if (this.PaySlipDateAmbit != target.PaySlipDateAmbit) resList.Add("PaySlipDateAmbit");
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            // --- ADD 2008/09/12 -------------------------------->>>>>
            if (this.StockSearchDiv != target.StockSearchDiv) resList.Add("StockSearchDiv");
            // --- ADD 2008/09/12 --------------------------------<<<<<
            // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
            if (this.GoodsNmReDispDivCd != target.GoodsNmReDispDivCd) resList.Add("GoodsNmReDispDivCd");
            // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
            return resList;
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�}�X�^��r����
        /// </summary>
        /// <param name="stockTtlSt1">��r����StockTtlSt�N���X�̃C���X�^���X</param>
        /// <param name="stockTtlSt2">��r����StockTtlSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockTtlSt stockTtlSt1, StockTtlSt stockTtlSt2)
        {
            ArrayList resList = new ArrayList();
            if (stockTtlSt1.CreateDateTime != stockTtlSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockTtlSt1.UpdateDateTime != stockTtlSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockTtlSt1.EnterpriseCode != stockTtlSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockTtlSt1.FileHeaderGuid != stockTtlSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockTtlSt1.UpdEmployeeCode != stockTtlSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockTtlSt1.UpdAssemblyId1 != stockTtlSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockTtlSt1.UpdAssemblyId2 != stockTtlSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockTtlSt1.LogicalDeleteCode != stockTtlSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockTtlSt1.SectionCode != stockTtlSt2.SectionCode) resList.Add("SectionCode");  // ADD 2008/06/05
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (stockTtlSt1.StockAllStMngCd != stockTtlSt2.StockAllStMngCd) resList.Add("StockAllStMngCd");
            if (stockTtlSt1.ValidDtConsTaxRate1 != stockTtlSt2.ValidDtConsTaxRate1) resList.Add("ValidDtConsTaxRate1");
            if (stockTtlSt1.ConsTaxRate1 != stockTtlSt2.ConsTaxRate1) resList.Add("ConsTaxRate1");
            if (stockTtlSt1.ValidDtConsTaxRate2 != stockTtlSt2.ValidDtConsTaxRate2) resList.Add("ValidDtConsTaxRate2");
            if (stockTtlSt1.ConsTaxRate2 != stockTtlSt2.ConsTaxRate2) resList.Add("ConsTaxRate2");
            if (stockTtlSt1.ValidDtConsTaxRate3 != stockTtlSt2.ValidDtConsTaxRate3) resList.Add("ValidDtConsTaxRate3");
            if (stockTtlSt1.ConsTaxRate3 != stockTtlSt2.ConsTaxRate3) resList.Add("ConsTaxRate3");
            if (stockTtlSt1.TotalAmountDispWayCd != stockTtlSt2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (stockTtlSt1.StockDiscountName != stockTtlSt2.StockDiscountName) resList.Add("StockDiscountName");
            /* --- DEL 2008/06/05 -------------------------------->>>>>
            if (stockTtlSt1.PartsUnitPrcZeroCd != stockTtlSt2.PartsUnitPrcZeroCd) resList.Add("PartsUnitPrcZeroCd");
            if (stockTtlSt1.SuppCTaxLayCd != stockTtlSt2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
               --- DEL 2008/06/05 --------------------------------<<<<< */
            if (stockTtlSt1.RgdsSlipPrtDiv != stockTtlSt2.RgdsSlipPrtDiv) resList.Add("RgdsSlipPrtDiv");
            if (stockTtlSt1.RgdsUnPrcPrtDiv != stockTtlSt2.RgdsUnPrcPrtDiv) resList.Add("RgdsUnPrcPrtDiv");
            if (stockTtlSt1.RgdsZeroPrtDiv != stockTtlSt2.RgdsZeroPrtDiv) resList.Add("RgdsZeroPrtDiv");

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //if (stockTtlSt1.IoGoodsCntDiv != stockTtlSt2.IoGoodsCntDiv) resList.Add("IoGoodsCntDiv");
            //if (stockTtlSt1.IoGoodsCntDiv2 != stockTtlSt2.IoGoodsCntDiv2) resList.Add("IoGoodsCntDiv2");
            //if (stockTtlSt1.SupplierFormalIni != stockTtlSt2.SupplierFormalIni) resList.Add("SupplierFormalIni");
            //if (stockTtlSt1.SalesSlipDtlConf != stockTtlSt2.SalesSlipDtlConf) resList.Add("SalesSlipDtlConf");
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            if (stockTtlSt1.ListPriceInpDiv != stockTtlSt2.ListPriceInpDiv) resList.Add("ListPriceInpDiv");
            if (stockTtlSt1.UnitPriceInpDiv != stockTtlSt2.UnitPriceInpDiv) resList.Add("UnitPriceInpDiv");
            if (stockTtlSt1.DtlNoteDispDiv != stockTtlSt2.DtlNoteDispDiv) resList.Add("DtlNoteDispDiv");
            if (stockTtlSt1.AutoPayMoneyKindCode != stockTtlSt2.AutoPayMoneyKindCode) resList.Add("AutoPayMoneyKindCode");
            if (stockTtlSt1.AutoPayMoneyKindName != stockTtlSt2.AutoPayMoneyKindName) resList.Add("AutoPayMoneyKindName");
            if (stockTtlSt1.AutoPayMoneyKindDiv != stockTtlSt2.AutoPayMoneyKindDiv) resList.Add("AutoPayMoneyKindDiv");
            // --- ADD 2008/06/05 -------------------------------->>>>>
            if (stockTtlSt1.AutoPayment != stockTtlSt2.AutoPayment) resList.Add("AutoPayment");
            if (stockTtlSt1.PriceCostUpdtDiv != stockTtlSt2.PriceCostUpdtDiv) resList.Add("PriceCostUpdtDiv");
            if (stockTtlSt1.AutoEntryGoodsDivCd != stockTtlSt2.AutoEntryGoodsDivCd) resList.Add("AutoEntryGoodsDivCd");
            if (stockTtlSt1.PriceCheckDivCd != stockTtlSt2.PriceCheckDivCd) resList.Add("PriceCheckDivCd");
            if (stockTtlSt1.StockUnitChgDivCd != stockTtlSt2.StockUnitChgDivCd) resList.Add("StockUnitChgDivCd");
            if (stockTtlSt1.SectDspDivCd != stockTtlSt2.SectDspDivCd) resList.Add("SectDspDivCd");
            if (stockTtlSt1.SlipDateClrDivCd != stockTtlSt2.SlipDateClrDivCd) resList.Add("SlipDateClrDivCd");
            if (stockTtlSt1.PaySlipDateClrDiv != stockTtlSt2.PaySlipDateClrDiv) resList.Add("PaySlipDateClrDiv");
            if (stockTtlSt1.PaySlipDateAmbit != stockTtlSt2.PaySlipDateAmbit) resList.Add("PaySlipDateAmbit");
            // --- ADD 2008/06/05 --------------------------------<<<<< 
            if (stockTtlSt1.EnterpriseName != stockTtlSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockTtlSt1.UpdEmployeeName != stockTtlSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockTtlSt1.SuppCTaxLayMethodNm != stockTtlSt2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            // --- ADD 2008/09/12 -------------------------------->>>>>
            if (stockTtlSt1.StockSearchDiv != stockTtlSt2.StockSearchDiv) resList.Add("StockSearchDiv");
            // --- ADD 2008/09/12 --------------------------------<<<<<
            // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
            if (stockTtlSt1.GoodsNmReDispDivCd != stockTtlSt2.GoodsNmReDispDivCd) resList.Add("GoodsNmReDispDivCd");
            // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
            
            return resList;
        }
        //----- ueno add ---------- start 2008.02.18
        /// <summary>�����x�����탊�X�g</summary>
        public static SortedList _autoPayMoneyKindCodeList;

        /// <summary>���z��ʋ敪���X�g</summary>
        public static SortedList _mnyKindDivList;

        /// <summary>
        /// �R���{�{�b�N�X���̎擾����
        /// </summary>
        /// <param name="code">�R���{�{�b�N�X�R�[�h</param>
        /// <param name="sList">�\�[�g���X�g</param>
        /// <returns>�R���{�{�b�N�X����</returns>
        /// <remarks>
        /// <br>Note       : �R���{�{�b�N�X�R�[�h����R���{�{�b�N�X���̂��擾���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.02.18</br>
        /// </remarks>
        public static string GetComboBoxNm(int code, SortedList sList)
        {
            string retStr = "";

            if (sList.ContainsKey((object)code))
            {
                retStr = sList[code].ToString();
            }
            return retStr;
        }
        //----- ueno add ---------- end 2008.02.18
    }
}
