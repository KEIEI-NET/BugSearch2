//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : UOE������ݒ�
// �v���O�����T�v   : UOE������}�X�^�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2008/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/25  �C�����e : UOE������}�X�^���ڒǉ��̈�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��
// �C �� ��  2012/09/10  �C�����e : BL�Ǘ����[�U�[�R�[�h�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESupplier
    /// <summary>
    ///                      UOE������}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE������}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/06/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/06/25 �Ɠc �M�u�@UOE������}�X�^���ڒǉ��̈�</br>
    /// </remarks>
    public class UOESupplier
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

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�d�b�ԍ�</summary>
        private string _telNo = "";

        /// <summary>UOE�[���R�[�h</summary>
        private string _uOETerminalCd = "";

        /// <summary>UOE�z�X�g�R�[�h</summary>
        private string _uOEHostCode = "";

        /// <summary>UOE�ڑ��p�X���[�h</summary>
        private string _uOEConnectPassword = "";

        /// <summary>UOE�ڑ����[�UID</summary>
        private string _uOEConnectUserId = "";

        /// <summary>UOEID�ԍ�</summary>
        private string _uOEIDNum = "";

        /// <summary>�ʐM�A�Z���u��ID</summary>
        private string _commAssemblyId = "";

        /// <summary>�ڑ��o�[�W�����敪</summary>
        private Int32 _connectVersionDiv;

        /// <summary>UOE�o�ɋ��_�R�[�h</summary>
        private string _uOEShipSectCd = "";

        /// <summary>UOE���㋒�_�R�[�h</summary>
        private string _uOESalSectCd = "";

        /// <summary>UOE�w�苒�_�R�[�h</summary>
        private string _uOEReservSectCd = "";

        /// <summary>��M��</summary>
        /// <remarks>��M�L���敪</remarks>
        private Int32 _receiveCondition;

        /// <summary>��֕i�ԋ敪</summary>
        private Int32 _substPartsNoDiv;

        /// <summary>�i�Ԉ���敪</summary>
        private Int32 _partsNoPrtCd;

        /// <summary>�艿�g�p�敪</summary>
        private Int32 _listPriceUseDiv;

        /// <summary>�d���f�[�^��M�敪</summary>
        private Int32 _stockSlipDtRecvDiv;

        /// <summary>�`�F�b�N�R�[�h�敪</summary>
        private Int32 _checkCodeDiv;

        /// <summary>�Ɩ��敪</summary>
        private Int32 _businessCode;

        /// <summary>UOE�w�苒�_</summary>
        private string _uOEResvdSection = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        ///// <summary>�[�i�敪</summary>
        //private Int32 _deliveredGoodsDiv;

        /// <summary>UOE�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>BO�敪</summary>
        private string _boCode = "";

        /// <summary>UOE�������[�g</summary>
        private string _uOEOrderRate = "";

        /// <summary>�����\���[�J�[�R�[�h�P</summary>
        private Int32 _enableOdrMakerCd1;

        /// <summary>�����\���[�J�[�R�[�h�Q</summary>
        private Int32 _enableOdrMakerCd2;

        /// <summary>�����\���[�J�[�R�[�h�R</summary>
        private Int32 _enableOdrMakerCd3;

        /// <summary>�����\���[�J�[�R�[�h�S</summary>
        private Int32 _enableOdrMakerCd4;

        /// <summary>�����\���[�J�[�R�[�h�T</summary>
        private Int32 _enableOdrMakerCd5;

        /// <summary>�����\���[�J�[�R�[�h�U</summary>
        private Int32 _enableOdrMakerCd6;

        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
        /// <summary>�����i�ԃn�C�t���敪�P</summary>
        private Int32 _odrPrtsNoHyphenCd1;

        /// <summary>�����i�ԃn�C�t���敪�Q</summary>
        private Int32 _odrPrtsNoHyphenCd2;

        /// <summary>�����i�ԃn�C�t���敪�R</summary>
        private Int32 _odrPrtsNoHyphenCd3;

        /// <summary>�����i�ԃn�C�t���敪�S</summary>
        private Int32 _odrPrtsNoHyphenCd4;

        /// <summary>�����i�ԃn�C�t���敪�T</summary>
        private Int32 _odrPrtsNoHyphenCd5;

        /// <summary>�����i�ԃn�C�t���敪�U</summary>
        private Int32 _odrPrtsNoHyphenCd6;
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<

        /// <summary>�@��ԍ�</summary>
        private string _instrumentNo = "";

        /// <summary>UOE�e�X�g���[�h</summary>
        private string _uOETestMode = "";

        /// <summary>UOE�A�C�e���R�[�h</summary>
        private string _uOEItemCd = "";

        /// <summary>�z���_�S�����_</summary>
        private string _hondaSectionCode = "";

        /// <summary>�񓚕ۑ��t�H���_</summary>
        private string _answerSaveFolder = "";

        /// <summary>�}�c�_�����_�R�[�h</summary>
        private string _mazdaSectionCode = "";

        /// <summary>�ً}�敪</summary>
        private string _emergencyDiv = "";

        /// <summary>������z�敪�i�_�C�n�c�j</summary>
        private Int32 _daihatsuOrdreDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�Ɩ��敪����</summary>
        private string _businessName = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        // ---ADD 2009/06/01 ------------------------------------->>>>>
        /// <summary>���O�C���^�C���A�E�g</summary>
        private Int32 _loginTimeoutVal;
        /// <summary>UOE����URL</summary>
        private string _uoeOrderUrl = "";
        /// <summary>UOE�݌Ɋm�FURL</summary>
        private string _uoeStockCheckUrl = "";
        /// <summary>UOE�����I��URL</summary>
        private string _uoeForcedTermUrl = "";
        /// <summary>UOE���O�C��URL</summary>
        private string _uoeLoginUrl = "";
        /// <summary>�⍇���E�������</summary>
        private Int32 _inqOrdDivCd;
        /// <summary>e-Parts���[�UID</summary>
        private string _ePartsUserId = "";
        /// <summary>e-Parts�p�X���[�h</summary>
        private string _ePartsPassWord = "";
        // ---ADD 2009/06/01 -------------------------------------<<<<<
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        /// <summary>BL�Ǘ����[�U�[�R�[�h</summary>
        private string _bLMngUserCode = "";
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<


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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  TelNo
        /// <summary>�d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TelNo
        {
            get { return _telNo; }
            set { _telNo = value; }
        }

        /// public propaty name  :  UOETerminalCd
        /// <summary>UOE�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOETerminalCd
        {
            get { return _uOETerminalCd; }
            set { _uOETerminalCd = value; }
        }

        /// public propaty name  :  UOEHostCode
        /// <summary>UOE�z�X�g�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�z�X�g�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEHostCode
        {
            get { return _uOEHostCode; }
            set { _uOEHostCode = value; }
        }

        /// public propaty name  :  UOEConnectPassword
        /// <summary>UOE�ڑ��p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�ڑ��p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEConnectPassword
        {
            get { return _uOEConnectPassword; }
            set { _uOEConnectPassword = value; }
        }

        /// public propaty name  :  UOEConnectUserId
        /// <summary>UOE�ڑ����[�UID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�ڑ����[�UID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEConnectUserId
        {
            get { return _uOEConnectUserId; }
            set { _uOEConnectUserId = value; }
        }

        /// public propaty name  :  UOEIDNum
        /// <summary>UOEID�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEID�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEIDNum
        {
            get { return _uOEIDNum; }
            set { _uOEIDNum = value; }
        }

        /// public propaty name  :  CommAssemblyId
        /// <summary>�ʐM�A�Z���u��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM�A�Z���u��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }

        /// public propaty name  :  ConnectVersionDiv
        /// <summary>�ڑ��o�[�W�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��o�[�W�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConnectVersionDiv
        {
            get { return _connectVersionDiv; }
            set { _connectVersionDiv = value; }
        }

        /// public propaty name  :  UOEShipSectCd
        /// <summary>UOE�o�ɋ��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�o�ɋ��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEShipSectCd
        {
            get { return _uOEShipSectCd; }
            set { _uOEShipSectCd = value; }
        }

        /// public propaty name  :  UOESalSectCd
        /// <summary>UOE���㋒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESalSectCd
        {
            get { return _uOESalSectCd; }
            set { _uOESalSectCd = value; }
        }

        /// public propaty name  :  UOEReservSectCd
        /// <summary>UOE�w�苒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEReservSectCd
        {
            get { return _uOEReservSectCd; }
            set { _uOEReservSectCd = value; }
        }

        /// public propaty name  :  ReceiveCondition
        /// <summary>��M�󋵃v���p�e�B</summary>
        /// <value>��M�L���敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�󋵃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiveCondition
        {
            get { return _receiveCondition; }
            set { _receiveCondition = value; }
        }

        /// public propaty name  :  SubstPartsNoDiv
        /// <summary>��֕i�ԋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֕i�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubstPartsNoDiv
        {
            get { return _substPartsNoDiv; }
            set { _substPartsNoDiv = value; }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>�i�Ԉ���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  ListPriceUseDiv
        /// <summary>�艿�g�p�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPriceUseDiv
        {
            get { return _listPriceUseDiv; }
            set { _listPriceUseDiv = value; }
        }

        /// public propaty name  :  StockSlipDtRecvDiv
        /// <summary>�d���f�[�^��M�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���f�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipDtRecvDiv
        {
            get { return _stockSlipDtRecvDiv; }
            set { _stockSlipDtRecvDiv = value; }
        }

        /// public propaty name  :  CheckCodeDiv
        /// <summary>�`�F�b�N�R�[�h�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�R�[�h�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckCodeDiv
        {
            get { return _checkCodeDiv; }
            set { _checkCodeDiv = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>�Ɩ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�˗��҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        ///// public propaty name  :  DeliveredGoodsDiv
        ///// <summary>�[�i�敪�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �[�i�敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 DeliveredGoodsDiv
        //{
        //    get { return _deliveredGoodsDiv; }
        //    set { _deliveredGoodsDiv = value; }
        //}

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  UOEOrderRate
        /// <summary>UOE�������[�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�������[�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEOrderRate
        {
            get { return _uOEOrderRate; }
            set { _uOEOrderRate = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd1
        /// <summary>�����\���[�J�[�R�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd1
        {
            get { return _enableOdrMakerCd1; }
            set { _enableOdrMakerCd1 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd2
        /// <summary>�����\���[�J�[�R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd2
        {
            get { return _enableOdrMakerCd2; }
            set { _enableOdrMakerCd2 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd3
        /// <summary>�����\���[�J�[�R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd3
        {
            get { return _enableOdrMakerCd3; }
            set { _enableOdrMakerCd3 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd4
        /// <summary>�����\���[�J�[�R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd4
        {
            get { return _enableOdrMakerCd4; }
            set { _enableOdrMakerCd4 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd5
        /// <summary>�����\���[�J�[�R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd5
        {
            get { return _enableOdrMakerCd5; }
            set { _enableOdrMakerCd5 = value; }
        }

        /// public propaty name  :  EnableOdrMakerCd6
        /// <summary>�����\���[�J�[�R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnableOdrMakerCd6
        {
            get { return _enableOdrMakerCd6; }
            set { _enableOdrMakerCd6 = value; }
        }
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
        /// public propaty name  :  OdrPrtsNoHyphenCd1
        /// <summary>�����i�ԃn�C�t���敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃn�C�t���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd1
        {
            get { return _odrPrtsNoHyphenCd1; }
            set { _odrPrtsNoHyphenCd1 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd2
        /// <summary>�����i�ԃn�C�t���敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃn�C�t���敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd2
        {
            get { return _odrPrtsNoHyphenCd2; }
            set { _odrPrtsNoHyphenCd2 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd3
        /// <summary>�����i�ԃn�C�t���敪�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃn�C�t���敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd3
        {
            get { return _odrPrtsNoHyphenCd3; }
            set { _odrPrtsNoHyphenCd3 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd4
        /// <summary>�����i�ԃn�C�t���敪�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃn�C�t���敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd4
        {
            get { return _odrPrtsNoHyphenCd4; }
            set { _odrPrtsNoHyphenCd4 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd5
        /// <summary>�����i�ԃn�C�t���敪�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃn�C�t���敪�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd5
        {
            get { return _odrPrtsNoHyphenCd5; }
            set { _odrPrtsNoHyphenCd5 = value; }
        }

        /// public propaty name  :  OdrPrtsNoHyphenCd6
        /// <summary>�����i�ԃn�C�t���敪�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃn�C�t���敪�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OdrPrtsNoHyphenCd6
        {
            get { return _odrPrtsNoHyphenCd6; }
            set { _odrPrtsNoHyphenCd6 = value; }
        }
        //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
        /// public propaty name  :  instrumentNo
        /// <summary>�@��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �@��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string instrumentNo
        {
            get { return _instrumentNo; }
            set { _instrumentNo = value; }
        }

        /// public propaty name  :  UOETestMode
        /// <summary>UOE�e�X�g���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�e�X�g���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOETestMode
        {
            get { return _uOETestMode; }
            set { _uOETestMode = value; }
        }

        /// public propaty name  :  UOEItemCd
        /// <summary>UOE�A�C�e���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�A�C�e���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEItemCd
        {
            get { return _uOEItemCd; }
            set { _uOEItemCd = value; }
        }

        /// public propaty name  :  HondaSectionCode
        /// <summary>�z���_�S�����_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �z���_�S�����_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HondaSectionCode
        {
            get { return _hondaSectionCode; }
            set { _hondaSectionCode = value; }
        }

        /// public propaty name  :  AnswerSaveFolder
        /// <summary>�񓚕ۑ��t�H���_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕ۑ��t�H���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerSaveFolder
        {
            get { return _answerSaveFolder; }
            set { _answerSaveFolder = value; }
        }

        /// public propaty name  :  MazdaSectionCode
        /// <summary>�}�c�_�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�c�_�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaSectionCode
        {
            get { return _mazdaSectionCode; }
            set { _mazdaSectionCode = value; }
        }

        /// public propaty name  :  EmergencyDiv
        /// <summary>�ً}�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ً}�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmergencyDiv
        {
            get { return _emergencyDiv; }
            set { _emergencyDiv = value; }
        }

        /// public propaty name  :  DaihatsuOrdreDiv
        /// <summary>������z�敪�i�_�C�n�c�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�敪�i�_�C�n�c�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DaihatsuOrdreDiv
        {
            get { return _daihatsuOrdreDiv; }
            set { _daihatsuOrdreDiv = value; }
        }

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

        /// public propaty name  :  BusinessName
        /// <summary>�Ɩ��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
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

        // ---ADD 2009/06/01 -------------------------------------------------->>>>>
        /// public propaty name  :  LoginTimeoutVal
        /// <summary>���O�C���^�C���A�E�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���^�C���A�E�g�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public Int32 LoginTimeoutVal
        {
            get { return _loginTimeoutVal; }
            set { _loginTimeoutVal = value; }
        }

        /// public propaty name  :  UOEOrderUrl
        /// <summary>UOE����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE����URL�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public string UOEOrderUrl
        {
            get { return _uoeOrderUrl; }
            set { _uoeOrderUrl = value; }
        }

        /// public propaty name  :  UOEStockCheckUrl
        /// <summary>UOE�݌Ɋm�FURL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌Ɋm�FURL�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public string UOEStockCheckUrl
        {
            get { return _uoeStockCheckUrl; }
            set { _uoeStockCheckUrl = value; }
        }

        /// public propaty name  :  UOEForcedTermUrl
        /// <summary>UOE�����I��URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����I��URL�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public string UOEForcedTermUrl
        {
            get { return _uoeForcedTermUrl; }
            set { _uoeForcedTermUrl = value; }
        }

        /// public propaty name  :  UOELoginUrl
        /// <summary>UOE���O�C��URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���O�C��URL�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public string UOELoginUrl
        {
            get { return _uoeLoginUrl; }
            set { _uoeLoginUrl = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  EPartsUserId
        /// <summary>e-Parts���[�UID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   e-Parts���[�UID�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public string EPartsUserId
        {
            get { return _ePartsUserId; }
            set { _ePartsUserId = value; }
        }

        /// public propaty name  :  EPartsPassWord
        /// <summary>e-Parts�p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   e-Parts�p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   �Ɠc �M�u</br>
        /// </remarks>
        public string EPartsPassWord
        {
            get { return _ePartsPassWord; }
            set { _ePartsPassWord = value; }
        }
        // ---ADD 2009/06/01 --------------------------------------------------<<<<<
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  BLMngUserCode
        /// <summary>BL�Ǘ����[�U�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�Ǘ����[�U�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ���� ��</br>
        /// </remarks>
        public string BLMngUserCode
        {
            get { return _bLMngUserCode; }
            set { _bLMngUserCode = value; }
        }
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// UOE������}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>UOESupplier�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplier�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESupplier()
        {
        }

        /// <summary>
        /// UOE������}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESupplierName">UOE�����於��</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="telNo">�d�b�ԍ�</param>
        /// <param name="uOETerminalCd">UOE�[���R�[�h</param>
        /// <param name="uOEHostCode">UOE�z�X�g�R�[�h</param>
        /// <param name="uOEConnectPassword">UOE�ڑ��p�X���[�h</param>
        /// <param name="uOEConnectUserId">UOE�ڑ����[�UID</param>
        /// <param name="uOEIDNum">UOEID�ԍ�</param>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <param name="connectVersionDiv">�ڑ��o�[�W�����敪</param>
        /// <param name="uOEShipSectCd">UOE�o�ɋ��_�R�[�h</param>
        /// <param name="uOESalSectCd">UOE���㋒�_�R�[�h</param>
        /// <param name="uOEReservSectCd">UOE�w�苒�_�R�[�h</param>
        /// <param name="receiveCondition">��M��(��M�L���敪)</param>
        /// <param name="substPartsNoDiv">��֕i�ԋ敪</param>
        /// <param name="partsNoPrtCd">�i�Ԉ���敪</param>
        /// <param name="listPriceUseDiv">�艿�g�p�敪</param>
        /// <param name="stockSlipDtRecvDiv">�d���f�[�^��M�敪</param>
        /// <param name="checkCodeDiv">�`�F�b�N�R�[�h�敪</param>
        /// <param name="businessCode">�Ɩ��敪</param>
        /// <param name="uOEResvdSection">UOE�w�苒�_</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h(�˗��҃R�[�h)</param>
        ///// <param name="deliveredGoodsDiv">�[�i�敪</param>
        /// <param name="uOEDeliGoodsDiv">UOE�[�i�敪</param>
        /// <param name="boCode">BO�敪</param>
        /// <param name="uOEOrderRate">UOE�������[�g</param>
        /// <param name="enableOdrMakerCd1">�����\���[�J�[�R�[�h�P</param>
        /// <param name="enableOdrMakerCd2">�����\���[�J�[�R�[�h�Q</param>
        /// <param name="enableOdrMakerCd3">�����\���[�J�[�R�[�h�R</param>
        /// <param name="enableOdrMakerCd4">�����\���[�J�[�R�[�h�S</param>
        /// <param name="enableOdrMakerCd5">�����\���[�J�[�R�[�h�T</param>
        /// <param name="enableOdrMakerCd6">�����\���[�J�[�R�[�h�U</param>
        /// <param name="odrPrtsNoHyphenCd1">�����i�ԃn�C�t���敪�P</param>
        /// <param name="odrPrtsNoHyphenCd1">�����i�ԃn�C�t���敪�Q</param>
        /// <param name="odrPrtsNoHyphenCd1">�����i�ԃn�C�t���敪�R</param>
        /// <param name="odrPrtsNoHyphenCd1">�����i�ԃn�C�t���敪�S</param>
        /// <param name="odrPrtsNoHyphenCd1">�����i�ԃn�C�t���敪�T</param>
        /// <param name="odrPrtsNoHyphenCd1">�����i�ԃn�C�t���敪�U</param>
        /// <param name="instrumentNo">�@��ԍ�</param>
        /// <param name="uOETestMode">UOE�e�X�g���[�h</param>
        /// <param name="uOEItemCd">UOE�A�C�e���R�[�h</param>
        /// <param name="hondaSectionCode">�z���_�S�����_</param>
        /// <param name="answerSaveFolder">�񓚕ۑ��t�H���_</param>
        /// <param name="mazdaSectionCode">�}�c�_�����_�R�[�h</param>
        /// <param name="emergencyDiv">�ً}�敪</param>
        /// <param name="daihatsuOrdreDiv">������z�敪�i�_�C�n�c�j</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="businessName">�Ɩ��敪����</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="loginTimeoutVal">���O�C���^�C���A�E�g</param>
        /// <param name="uoeOrderUrl">UOE����URL</param>
        /// <param name="uoeStockCheckUrl">UOE�݌Ɋm�FURL</param>
        /// <param name="uoeForcedTermUrl">UOE�����I��URL</param>
        /// <param name="uoeLoginUrl">UOE���O�C��URL</param>
        /// <param name="inqOrdDivCd">�⍇���E�������</param>
        /// <param name="ePartsUserId">e-Parts���[�UID</param>
        /// <param name="ePartsPassWord">e-Parts�p�X���[�h</param>
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        /// <param name="bLMngUserCode">BL�Ǘ����[�U�[�R�[�h</param>
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        /// <returns>UOESupplier�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplier�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd)      //DEL 2009/06/01
        //public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd, Int32 loginTimeoutVal, string uoeOrderUrl, string uoeStockCheckUrl, string uoeForcedTermUrl, string uoeLoginUrl, Int32 inqOrdDivCd, string ePartsUserId, string ePartsPassWord)        //ADD 2009/06/01 // DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
        // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        //public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, Int32 odrPrtsNoHyphenCd1, Int32 odrPrtsNoHyphenCd2, Int32 odrPrtsNoHyphenCd3, Int32 odrPrtsNoHyphenCd4, Int32 odrPrtsNoHyphenCd5, Int32 odrPrtsNoHyphenCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd, Int32 loginTimeoutVal, string uoeOrderUrl, string uoeStockCheckUrl, string uoeForcedTermUrl, string uoeLoginUrl, Int32 inqOrdDivCd, string ePartsUserId, string ePartsPassWord)// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
        public UOESupplier(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 uOESupplierCd, string uOESupplierName, Int32 goodsMakerCd, string telNo, string uOETerminalCd, string uOEHostCode, string uOEConnectPassword, string uOEConnectUserId, string uOEIDNum, string commAssemblyId, Int32 connectVersionDiv, string uOEShipSectCd, string uOESalSectCd, string uOEReservSectCd, Int32 receiveCondition, Int32 substPartsNoDiv, Int32 partsNoPrtCd, Int32 listPriceUseDiv, Int32 stockSlipDtRecvDiv, Int32 checkCodeDiv, Int32 businessCode, string uOEResvdSection, string employeeCode, string uOEDeliGoodsDiv, string boCode, string uOEOrderRate, Int32 enableOdrMakerCd1, Int32 enableOdrMakerCd2, Int32 enableOdrMakerCd3, Int32 enableOdrMakerCd4, Int32 enableOdrMakerCd5, Int32 enableOdrMakerCd6, Int32 odrPrtsNoHyphenCd1, Int32 odrPrtsNoHyphenCd2, Int32 odrPrtsNoHyphenCd3, Int32 odrPrtsNoHyphenCd4, Int32 odrPrtsNoHyphenCd5, Int32 odrPrtsNoHyphenCd6, string instrumentNo, string uOETestMode, string uOEItemCd, string hondaSectionCode, string answerSaveFolder, string mazdaSectionCode, string emergencyDiv, Int32 daihatsuOrdreDiv, string enterpriseName, string updEmployeeName, string businessName, string sectionCode, Int32 supplierCd, Int32 loginTimeoutVal, string uoeOrderUrl, string uoeStockCheckUrl, string uoeForcedTermUrl, string uoeLoginUrl, Int32 inqOrdDivCd, string ePartsUserId, string ePartsPassWord, string bLMngUserCode)
        // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._goodsMakerCd = goodsMakerCd;
            this._telNo = telNo;
            this._uOETerminalCd = uOETerminalCd;
            this._uOEHostCode = uOEHostCode;
            this._uOEConnectPassword = uOEConnectPassword;
            this._uOEConnectUserId = uOEConnectUserId;
            this._uOEIDNum = uOEIDNum;
            this._commAssemblyId = commAssemblyId;
            this._connectVersionDiv = connectVersionDiv;
            this._uOEShipSectCd = uOEShipSectCd;
            this._uOESalSectCd = uOESalSectCd;
            this._uOEReservSectCd = uOEReservSectCd;
            this._receiveCondition = receiveCondition;
            this._substPartsNoDiv = substPartsNoDiv;
            this._partsNoPrtCd = partsNoPrtCd;
            this._listPriceUseDiv = listPriceUseDiv;
            this._stockSlipDtRecvDiv = stockSlipDtRecvDiv;
            this._checkCodeDiv = checkCodeDiv;
            this._businessCode = businessCode;
            this._uOEResvdSection = uOEResvdSection;
            this._employeeCode = employeeCode;
            //this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._boCode = boCode;
            this._uOEOrderRate = uOEOrderRate;
            this._enableOdrMakerCd1 = enableOdrMakerCd1;
            this._enableOdrMakerCd2 = enableOdrMakerCd2;
            this._enableOdrMakerCd3 = enableOdrMakerCd3;
            this._enableOdrMakerCd4 = enableOdrMakerCd4;
            this._enableOdrMakerCd5 = enableOdrMakerCd5;
            this._enableOdrMakerCd6 = enableOdrMakerCd6;
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            this._odrPrtsNoHyphenCd1 = odrPrtsNoHyphenCd1;
            this._odrPrtsNoHyphenCd2 = odrPrtsNoHyphenCd2;
            this._odrPrtsNoHyphenCd3 = odrPrtsNoHyphenCd3;
            this._odrPrtsNoHyphenCd4 = odrPrtsNoHyphenCd4;
            this._odrPrtsNoHyphenCd5 = odrPrtsNoHyphenCd5;
            this._odrPrtsNoHyphenCd6 = odrPrtsNoHyphenCd6;
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            this._instrumentNo = instrumentNo;
            this._uOETestMode = uOETestMode;
            this._uOEItemCd = uOEItemCd;
            this._hondaSectionCode = hondaSectionCode;
            this._answerSaveFolder = answerSaveFolder;
            this._mazdaSectionCode = mazdaSectionCode;
            this._emergencyDiv = emergencyDiv;
            this._daihatsuOrdreDiv = daihatsuOrdreDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._businessName = businessName;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            // ---ADD 2009/06/01 --------------------->>>>>
            this._loginTimeoutVal = loginTimeoutVal;
            this._uoeOrderUrl = uoeOrderUrl;
            this._uoeStockCheckUrl = uoeStockCheckUrl;
            this._uoeForcedTermUrl = uoeForcedTermUrl;
            this._uoeLoginUrl = uoeLoginUrl;
            this._inqOrdDivCd = inqOrdDivCd;
            this._ePartsUserId = ePartsUserId;
            this._ePartsPassWord = ePartsPassWord;
            // ---ADD 2009/06/01 ---------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            this._bLMngUserCode = bLMngUserCode;
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// UOE������}�X�^��������
        /// </summary>
        /// <returns>UOESupplier�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UOESupplier�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESupplier Clone()
        {
            //return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd);     //DEL 2009/06/01
            //return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd,this._loginTimeoutVal,this._uoeOrderUrl,this.UOEStockCheckUrl,this.UOEForcedTermUrl,this.UOELoginUrl,this.InqOrdDivCd,this.EPartsUserId,this.EPartsPassWord);       //ADD 2009/06/01// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
            // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            //return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._odrPrtsNoHyphenCd1, this._odrPrtsNoHyphenCd2, this._odrPrtsNoHyphenCd3, this._odrPrtsNoHyphenCd4, this._odrPrtsNoHyphenCd5, this._odrPrtsNoHyphenCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd, this._loginTimeoutVal, this._uoeOrderUrl, this.UOEStockCheckUrl, this.UOEForcedTermUrl, this.UOELoginUrl, this.InqOrdDivCd, this.EPartsUserId, this.EPartsPassWord);// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
            return new UOESupplier(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._uOESupplierCd, this._uOESupplierName, this._goodsMakerCd, this._telNo, this._uOETerminalCd, this._uOEHostCode, this._uOEConnectPassword, this._uOEConnectUserId, this._uOEIDNum, this._commAssemblyId, this._connectVersionDiv, this._uOEShipSectCd, this._uOESalSectCd, this._uOEReservSectCd, this._receiveCondition, this._substPartsNoDiv, this._partsNoPrtCd, this._listPriceUseDiv, this._stockSlipDtRecvDiv, this._checkCodeDiv, this._businessCode, this._uOEResvdSection, this._employeeCode, this._uOEDeliGoodsDiv, this._boCode, this._uOEOrderRate, this._enableOdrMakerCd1, this._enableOdrMakerCd2, this._enableOdrMakerCd3, this._enableOdrMakerCd4, this._enableOdrMakerCd5, this._enableOdrMakerCd6, this._odrPrtsNoHyphenCd1, this._odrPrtsNoHyphenCd2, this._odrPrtsNoHyphenCd3, this._odrPrtsNoHyphenCd4, this._odrPrtsNoHyphenCd5, this._odrPrtsNoHyphenCd6, this._instrumentNo, this._uOETestMode, this._uOEItemCd, this._hondaSectionCode, this._answerSaveFolder, this._mazdaSectionCode, this._emergencyDiv, this._daihatsuOrdreDiv, this._enterpriseName, this._updEmployeeName, this._businessName, this._sectionCode, this._supplierCd, this._loginTimeoutVal, this._uoeOrderUrl, this.UOEStockCheckUrl, this.UOEForcedTermUrl, this.UOELoginUrl, this.InqOrdDivCd, this.EPartsUserId, this.EPartsPassWord, this.BLMngUserCode);
            // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// UOE������}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOESupplier�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplier�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UOESupplier target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.TelNo == target.TelNo)
                 && (this.UOETerminalCd == target.UOETerminalCd)
                 && (this.UOEHostCode == target.UOEHostCode)
                 && (this.UOEConnectPassword == target.UOEConnectPassword)
                 && (this.UOEConnectUserId == target.UOEConnectUserId)
                 && (this.UOEIDNum == target.UOEIDNum)
                 && (this.CommAssemblyId == target.CommAssemblyId)
                 && (this.ConnectVersionDiv == target.ConnectVersionDiv)
                 && (this.UOEShipSectCd == target.UOEShipSectCd)
                 && (this.UOESalSectCd == target.UOESalSectCd)
                 && (this.UOEReservSectCd == target.UOEReservSectCd)
                 && (this.ReceiveCondition == target.ReceiveCondition)
                 && (this.SubstPartsNoDiv == target.SubstPartsNoDiv)
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                 && (this.ListPriceUseDiv == target.ListPriceUseDiv)
                 && (this.StockSlipDtRecvDiv == target.StockSlipDtRecvDiv)
                 && (this.CheckCodeDiv == target.CheckCodeDiv)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.EmployeeCode == target.EmployeeCode)
                 //&& (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.BoCode == target.BoCode)
                 && (this.UOEOrderRate == target.UOEOrderRate)
                 && (this.EnableOdrMakerCd1 == target.EnableOdrMakerCd1)
                 && (this.EnableOdrMakerCd2 == target.EnableOdrMakerCd2)
                 && (this.EnableOdrMakerCd3 == target.EnableOdrMakerCd3)
                 && (this.EnableOdrMakerCd4 == target.EnableOdrMakerCd4)
                 && (this.EnableOdrMakerCd5 == target.EnableOdrMakerCd5)
                 && (this.EnableOdrMakerCd6 == target.EnableOdrMakerCd6)
                 //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                 && (this.OdrPrtsNoHyphenCd1 == target.OdrPrtsNoHyphenCd1)
                 && (this.OdrPrtsNoHyphenCd2 == target.OdrPrtsNoHyphenCd2)
                 && (this.OdrPrtsNoHyphenCd3 == target.OdrPrtsNoHyphenCd3)
                 && (this.OdrPrtsNoHyphenCd4 == target.OdrPrtsNoHyphenCd4)
                 && (this.OdrPrtsNoHyphenCd5 == target.OdrPrtsNoHyphenCd5)
                 && (this.OdrPrtsNoHyphenCd6 == target.OdrPrtsNoHyphenCd6)
                 //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                 && (this.instrumentNo == target.instrumentNo)
                 && (this.UOETestMode == target.UOETestMode)
                 && (this.UOEItemCd == target.UOEItemCd)
                 && (this.HondaSectionCode == target.HondaSectionCode)
                 && (this.AnswerSaveFolder == target.AnswerSaveFolder)
                 && (this.MazdaSectionCode == target.MazdaSectionCode)
                 && (this.EmergencyDiv == target.EmergencyDiv)
                 && (this.DaihatsuOrdreDiv == target.DaihatsuOrdreDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BusinessName == target.BusinessName)
                 && (this.SectionCode == target.SectionCode)
                 //&& (this.SupplierCd == target.SupplierCd));  //DEL 2009/06/01
                // ---ADD 2009/06/01 ---------------------------------->>>>>
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.LoginTimeoutVal == target.LoginTimeoutVal)
                 && (this.UOEOrderUrl == target.UOEOrderUrl)
                 && (this.UOEStockCheckUrl == target.UOEStockCheckUrl)
                 && (this.UOEForcedTermUrl == target.UOEForcedTermUrl)
                 && (this.UOELoginUrl == target.UOELoginUrl)
                 && (this.InqOrdDivCd == target.InqOrdDivCd)
                 && (this.EPartsUserId == target.EPartsUserId)
                // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                 //&& (this.EPartsPassWord == target.EPartsPassWord));
                 && (this.EPartsPassWord == target.EPartsPassWord)
                // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                // ---ADD 2009/06/01 ----------------------------------<<<<<
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                 && (this.BLMngUserCode == target.BLMngUserCode));
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        }


        /// <summary>
        /// UOE������}�X�^��r����
        /// </summary>
        /// <param name="uOESupplier1">
        ///                    ��r����UOESupplier�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uOESupplier2">��r����UOESupplier�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplier�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UOESupplier uOESupplier1, UOESupplier uOESupplier2)
        {
            return ((uOESupplier1.CreateDateTime == uOESupplier2.CreateDateTime)
                 && (uOESupplier1.UpdateDateTime == uOESupplier2.UpdateDateTime)
                 && (uOESupplier1.EnterpriseCode == uOESupplier2.EnterpriseCode)
                 && (uOESupplier1.FileHeaderGuid == uOESupplier2.FileHeaderGuid)
                 && (uOESupplier1.UpdEmployeeCode == uOESupplier2.UpdEmployeeCode)
                 && (uOESupplier1.UpdAssemblyId1 == uOESupplier2.UpdAssemblyId1)
                 && (uOESupplier1.UpdAssemblyId2 == uOESupplier2.UpdAssemblyId2)
                 && (uOESupplier1.LogicalDeleteCode == uOESupplier2.LogicalDeleteCode)
                 && (uOESupplier1.UOESupplierCd == uOESupplier2.UOESupplierCd)
                 && (uOESupplier1.UOESupplierName == uOESupplier2.UOESupplierName)
                 && (uOESupplier1.GoodsMakerCd == uOESupplier2.GoodsMakerCd)
                 && (uOESupplier1.TelNo == uOESupplier2.TelNo)
                 && (uOESupplier1.UOETerminalCd == uOESupplier2.UOETerminalCd)
                 && (uOESupplier1.UOEHostCode == uOESupplier2.UOEHostCode)
                 && (uOESupplier1.UOEConnectPassword == uOESupplier2.UOEConnectPassword)
                 && (uOESupplier1.UOEConnectUserId == uOESupplier2.UOEConnectUserId)
                 && (uOESupplier1.UOEIDNum == uOESupplier2.UOEIDNum)
                 && (uOESupplier1.CommAssemblyId == uOESupplier2.CommAssemblyId)
                 && (uOESupplier1.ConnectVersionDiv == uOESupplier2.ConnectVersionDiv)
                 && (uOESupplier1.UOEShipSectCd == uOESupplier2.UOEShipSectCd)
                 && (uOESupplier1.UOESalSectCd == uOESupplier2.UOESalSectCd)
                 && (uOESupplier1.UOEReservSectCd == uOESupplier2.UOEReservSectCd)
                 && (uOESupplier1.ReceiveCondition == uOESupplier2.ReceiveCondition)
                 && (uOESupplier1.SubstPartsNoDiv == uOESupplier2.SubstPartsNoDiv)
                 && (uOESupplier1.PartsNoPrtCd == uOESupplier2.PartsNoPrtCd)
                 && (uOESupplier1.ListPriceUseDiv == uOESupplier2.ListPriceUseDiv)
                 && (uOESupplier1.StockSlipDtRecvDiv == uOESupplier2.StockSlipDtRecvDiv)
                 && (uOESupplier1.CheckCodeDiv == uOESupplier2.CheckCodeDiv)
                 && (uOESupplier1.BusinessCode == uOESupplier2.BusinessCode)
                 && (uOESupplier1.UOEResvdSection == uOESupplier2.UOEResvdSection)
                 && (uOESupplier1.EmployeeCode == uOESupplier2.EmployeeCode)
                 //&& (uOESupplier1.DeliveredGoodsDiv == uOESupplier2.DeliveredGoodsDiv)
                 && (uOESupplier1.UOEDeliGoodsDiv == uOESupplier2.UOEDeliGoodsDiv)
                 && (uOESupplier1.BoCode == uOESupplier2.BoCode)
                 && (uOESupplier1.UOEOrderRate == uOESupplier2.UOEOrderRate)
                 && (uOESupplier1.EnableOdrMakerCd1 == uOESupplier2.EnableOdrMakerCd1)
                 && (uOESupplier1.EnableOdrMakerCd2 == uOESupplier2.EnableOdrMakerCd2)
                 && (uOESupplier1.EnableOdrMakerCd3 == uOESupplier2.EnableOdrMakerCd3)
                 && (uOESupplier1.EnableOdrMakerCd4 == uOESupplier2.EnableOdrMakerCd4)
                 && (uOESupplier1.EnableOdrMakerCd5 == uOESupplier2.EnableOdrMakerCd5)
                 && (uOESupplier1.EnableOdrMakerCd6 == uOESupplier2.EnableOdrMakerCd6)
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
                 && (uOESupplier1.OdrPrtsNoHyphenCd1 == uOESupplier2.OdrPrtsNoHyphenCd1)
                 && (uOESupplier1.OdrPrtsNoHyphenCd2 == uOESupplier2.OdrPrtsNoHyphenCd2)
                 && (uOESupplier1.OdrPrtsNoHyphenCd3 == uOESupplier2.OdrPrtsNoHyphenCd3)
                 && (uOESupplier1.OdrPrtsNoHyphenCd4 == uOESupplier2.OdrPrtsNoHyphenCd4)
                 && (uOESupplier1.OdrPrtsNoHyphenCd5 == uOESupplier2.OdrPrtsNoHyphenCd5)
                 && (uOESupplier1.OdrPrtsNoHyphenCd6 == uOESupplier2.OdrPrtsNoHyphenCd6)
                //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
                 && (uOESupplier1.instrumentNo == uOESupplier2.instrumentNo)
                 && (uOESupplier1.UOETestMode == uOESupplier2.UOETestMode)
                 && (uOESupplier1.UOEItemCd == uOESupplier2.UOEItemCd)
                 && (uOESupplier1.HondaSectionCode == uOESupplier2.HondaSectionCode)
                 && (uOESupplier1.AnswerSaveFolder == uOESupplier2.AnswerSaveFolder)
                 && (uOESupplier1.MazdaSectionCode == uOESupplier2.MazdaSectionCode)
                 && (uOESupplier1.EmergencyDiv == uOESupplier2.EmergencyDiv)
                 && (uOESupplier1.DaihatsuOrdreDiv == uOESupplier2.DaihatsuOrdreDiv)
                 && (uOESupplier1.EnterpriseName == uOESupplier2.EnterpriseName)
                 && (uOESupplier1.UpdEmployeeName == uOESupplier2.UpdEmployeeName)
                 && (uOESupplier1.BusinessName == uOESupplier2.BusinessName)
                 && (uOESupplier1.SectionCode == uOESupplier2.SectionCode)
                 //&& (uOESupplier1.SupplierCd == uOESupplier2.SupplierCd));        //DEL 2009/06/01
                 // ---ADD 2009/06/01 ---------------------------------->>>>>
                 && (uOESupplier1.SupplierCd == uOESupplier2.SupplierCd)
                 && (uOESupplier1.LoginTimeoutVal == uOESupplier2.LoginTimeoutVal)
                 && (uOESupplier1.UOEOrderUrl == uOESupplier2.UOEOrderUrl)
                 && (uOESupplier1.UOEStockCheckUrl == uOESupplier2.UOEStockCheckUrl)
                 && (uOESupplier1.UOEForcedTermUrl == uOESupplier2.UOEForcedTermUrl)
                 && (uOESupplier1.UOELoginUrl == uOESupplier2.UOELoginUrl)
                 && (uOESupplier1.InqOrdDivCd == uOESupplier2.InqOrdDivCd)
                 && (uOESupplier1.EPartsUserId == uOESupplier2.EPartsUserId)
                // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                // && (uOESupplier1.EPartsPassWord == uOESupplier2.EPartsPassWord));
                 && (uOESupplier1.EPartsPassWord == uOESupplier2.EPartsPassWord)
                // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
                // ---ADD 2009/06/01 ----------------------------------<<<<<
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                 && (uOESupplier1.BLMngUserCode == uOESupplier2.BLMngUserCode));
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

        }
        /// <summary>
        /// UOE������}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOESupplier�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplier�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UOESupplier target)
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
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.TelNo != target.TelNo) resList.Add("TelNo");
            if (this.UOETerminalCd != target.UOETerminalCd) resList.Add("UOETerminalCd");
            if (this.UOEHostCode != target.UOEHostCode) resList.Add("UOEHostCode");
            if (this.UOEConnectPassword != target.UOEConnectPassword) resList.Add("UOEConnectPassword");
            if (this.UOEConnectUserId != target.UOEConnectUserId) resList.Add("UOEConnectUserId");
            if (this.UOEIDNum != target.UOEIDNum) resList.Add("UOEIDNum");
            if (this.CommAssemblyId != target.CommAssemblyId) resList.Add("CommAssemblyId");
            if (this.ConnectVersionDiv != target.ConnectVersionDiv) resList.Add("ConnectVersionDiv");
            if (this.UOEShipSectCd != target.UOEShipSectCd) resList.Add("UOEShipSectCd");
            if (this.UOESalSectCd != target.UOESalSectCd) resList.Add("UOESalSectCd");
            if (this.UOEReservSectCd != target.UOEReservSectCd) resList.Add("UOEReservSectCd");
            if (this.ReceiveCondition != target.ReceiveCondition) resList.Add("ReceiveCondition");
            if (this.SubstPartsNoDiv != target.SubstPartsNoDiv) resList.Add("SubstPartsNoDiv");
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (this.ListPriceUseDiv != target.ListPriceUseDiv) resList.Add("ListPriceUseDiv");
            if (this.StockSlipDtRecvDiv != target.StockSlipDtRecvDiv) resList.Add("StockSlipDtRecvDiv");
            if (this.CheckCodeDiv != target.CheckCodeDiv) resList.Add("CheckCodeDiv");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            //if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.BoCode != target.BoCode) resList.Add("BoCode");
            if (this.UOEOrderRate != target.UOEOrderRate) resList.Add("UOEOrderRate");
            if (this.EnableOdrMakerCd1 != target.EnableOdrMakerCd1) resList.Add("EnableOdrMakerCd1");
            if (this.EnableOdrMakerCd2 != target.EnableOdrMakerCd2) resList.Add("EnableOdrMakerCd2");
            if (this.EnableOdrMakerCd3 != target.EnableOdrMakerCd3) resList.Add("EnableOdrMakerCd3");
            if (this.EnableOdrMakerCd4 != target.EnableOdrMakerCd4) resList.Add("EnableOdrMakerCd4");
            if (this.EnableOdrMakerCd5 != target.EnableOdrMakerCd5) resList.Add("EnableOdrMakerCd5");
            if (this.EnableOdrMakerCd6 != target.EnableOdrMakerCd6) resList.Add("EnableOdrMakerCd6");
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            if (this.OdrPrtsNoHyphenCd1 != target.OdrPrtsNoHyphenCd1) resList.Add("OdrPrtsNoHyphenCd1");
            if (this.OdrPrtsNoHyphenCd2 != target.OdrPrtsNoHyphenCd2) resList.Add("OdrPrtsNoHyphenCd2");
            if (this.OdrPrtsNoHyphenCd3 != target.OdrPrtsNoHyphenCd3) resList.Add("OdrPrtsNoHyphenCd3");
            if (this.OdrPrtsNoHyphenCd4 != target.OdrPrtsNoHyphenCd4) resList.Add("OdrPrtsNoHyphenCd4");
            if (this.OdrPrtsNoHyphenCd5 != target.OdrPrtsNoHyphenCd5) resList.Add("OdrPrtsNoHyphenCd5");
            if (this.OdrPrtsNoHyphenCd6 != target.OdrPrtsNoHyphenCd6) resList.Add("OdrPrtsNoHyphenCd6");
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            if (this.instrumentNo != target.instrumentNo) resList.Add("instrumentNo");
            if (this.UOETestMode != target.UOETestMode) resList.Add("UOETestMode");
            if (this.UOEItemCd != target.UOEItemCd) resList.Add("UOEItemCd");
            if (this.HondaSectionCode != target.HondaSectionCode) resList.Add("HondaSectionCode");
            if (this.AnswerSaveFolder != target.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (this.MazdaSectionCode != target.MazdaSectionCode) resList.Add("MazdaSectionCode");
            if (this.EmergencyDiv != target.EmergencyDiv) resList.Add("EmergencyDiv");
            if (this.DaihatsuOrdreDiv != target.DaihatsuOrdreDiv) resList.Add("DaihatsuOrdreDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            // ---ADD 2009/06/01 ---------------------------------->>>>>
            if (this.LoginTimeoutVal != target.LoginTimeoutVal) resList.Add("LoginTimeoutVal");
            if (this.UOEOrderUrl != target.UOEOrderUrl) resList.Add("UOEOrderUrl");
            if (this.UOEStockCheckUrl != target.UOEStockCheckUrl) resList.Add("UOEStockCheckUrl");
            if (this.UOEForcedTermUrl != target.UOEForcedTermUrl) resList.Add("UOEForcedTermUrl");
            if (this.UOELoginUrl != target.UOELoginUrl) resList.Add("UOELoginUrl");
            if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
            if (this.EPartsUserId != target.EPartsUserId) resList.Add("EPartsUserId");
            if (this.EPartsPassWord != target.EPartsPassWord) resList.Add("EPartsPassWord");
            // ---ADD 2009/06/01 ----------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            if (this.BLMngUserCode != target.BLMngUserCode) resList.Add("BLMngUserCode");
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// UOE������}�X�^��r����
        /// </summary>
        /// <param name="uOESupplier1">��r����UOESupplier�N���X�̃C���X�^���X</param>
        /// <param name="uOESupplier2">��r����UOESupplier�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplier�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UOESupplier uOESupplier1, UOESupplier uOESupplier2)
        {
            ArrayList resList = new ArrayList();
            if (uOESupplier1.CreateDateTime != uOESupplier2.CreateDateTime) resList.Add("CreateDateTime");
            if (uOESupplier1.UpdateDateTime != uOESupplier2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (uOESupplier1.EnterpriseCode != uOESupplier2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOESupplier1.FileHeaderGuid != uOESupplier2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (uOESupplier1.UpdEmployeeCode != uOESupplier2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (uOESupplier1.UpdAssemblyId1 != uOESupplier2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (uOESupplier1.UpdAssemblyId2 != uOESupplier2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (uOESupplier1.LogicalDeleteCode != uOESupplier2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (uOESupplier1.UOESupplierCd != uOESupplier2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOESupplier1.UOESupplierName != uOESupplier2.UOESupplierName) resList.Add("UOESupplierName");
            if (uOESupplier1.GoodsMakerCd != uOESupplier2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (uOESupplier1.TelNo != uOESupplier2.TelNo) resList.Add("TelNo");
            if (uOESupplier1.UOETerminalCd != uOESupplier2.UOETerminalCd) resList.Add("UOETerminalCd");
            if (uOESupplier1.UOEHostCode != uOESupplier2.UOEHostCode) resList.Add("UOEHostCode");
            if (uOESupplier1.UOEConnectPassword != uOESupplier2.UOEConnectPassword) resList.Add("UOEConnectPassword");
            if (uOESupplier1.UOEConnectUserId != uOESupplier2.UOEConnectUserId) resList.Add("UOEConnectUserId");
            if (uOESupplier1.UOEIDNum != uOESupplier2.UOEIDNum) resList.Add("UOEIDNum");
            if (uOESupplier1.CommAssemblyId != uOESupplier2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (uOESupplier1.ConnectVersionDiv != uOESupplier2.ConnectVersionDiv) resList.Add("ConnectVersionDiv");
            if (uOESupplier1.UOEShipSectCd != uOESupplier2.UOEShipSectCd) resList.Add("UOEShipSectCd");
            if (uOESupplier1.UOESalSectCd != uOESupplier2.UOESalSectCd) resList.Add("UOESalSectCd");
            if (uOESupplier1.UOEReservSectCd != uOESupplier2.UOEReservSectCd) resList.Add("UOEReservSectCd");
            if (uOESupplier1.ReceiveCondition != uOESupplier2.ReceiveCondition) resList.Add("ReceiveCondition");
            if (uOESupplier1.SubstPartsNoDiv != uOESupplier2.SubstPartsNoDiv) resList.Add("SubstPartsNoDiv");
            if (uOESupplier1.PartsNoPrtCd != uOESupplier2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");
            if (uOESupplier1.ListPriceUseDiv != uOESupplier2.ListPriceUseDiv) resList.Add("ListPriceUseDiv");
            if (uOESupplier1.StockSlipDtRecvDiv != uOESupplier2.StockSlipDtRecvDiv) resList.Add("StockSlipDtRecvDiv");
            if (uOESupplier1.CheckCodeDiv != uOESupplier2.CheckCodeDiv) resList.Add("CheckCodeDiv");
            if (uOESupplier1.BusinessCode != uOESupplier2.BusinessCode) resList.Add("BusinessCode");
            if (uOESupplier1.UOEResvdSection != uOESupplier2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (uOESupplier1.EmployeeCode != uOESupplier2.EmployeeCode) resList.Add("EmployeeCode");
            //if (uOESupplier1.DeliveredGoodsDiv != uOESupplier2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (uOESupplier1.UOEDeliGoodsDiv != uOESupplier2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (uOESupplier1.BoCode != uOESupplier2.BoCode) resList.Add("BoCode");
            if (uOESupplier1.UOEOrderRate != uOESupplier2.UOEOrderRate) resList.Add("UOEOrderRate");
            if (uOESupplier1.EnableOdrMakerCd1 != uOESupplier2.EnableOdrMakerCd1) resList.Add("EnableOdrMakerCd1");
            if (uOESupplier1.EnableOdrMakerCd2 != uOESupplier2.EnableOdrMakerCd2) resList.Add("EnableOdrMakerCd2");
            if (uOESupplier1.EnableOdrMakerCd3 != uOESupplier2.EnableOdrMakerCd3) resList.Add("EnableOdrMakerCd3");
            if (uOESupplier1.EnableOdrMakerCd4 != uOESupplier2.EnableOdrMakerCd4) resList.Add("EnableOdrMakerCd4");
            if (uOESupplier1.EnableOdrMakerCd5 != uOESupplier2.EnableOdrMakerCd5) resList.Add("EnableOdrMakerCd5");
            if (uOESupplier1.EnableOdrMakerCd6 != uOESupplier2.EnableOdrMakerCd6) resList.Add("EnableOdrMakerCd6");
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            if (uOESupplier1.OdrPrtsNoHyphenCd1 != uOESupplier2.OdrPrtsNoHyphenCd1) resList.Add("OdrPrtsNoHyphenCd1");
            if (uOESupplier1.OdrPrtsNoHyphenCd2 != uOESupplier2.OdrPrtsNoHyphenCd2) resList.Add("OdrPrtsNoHyphenCd2");
            if (uOESupplier1.OdrPrtsNoHyphenCd3 != uOESupplier2.OdrPrtsNoHyphenCd3) resList.Add("OdrPrtsNoHyphenCd3");
            if (uOESupplier1.OdrPrtsNoHyphenCd4 != uOESupplier2.OdrPrtsNoHyphenCd4) resList.Add("OdrPrtsNoHyphenCd4");
            if (uOESupplier1.OdrPrtsNoHyphenCd5 != uOESupplier2.OdrPrtsNoHyphenCd5) resList.Add("OdrPrtsNoHyphenCd5");
            if (uOESupplier1.OdrPrtsNoHyphenCd6 != uOESupplier2.OdrPrtsNoHyphenCd6) resList.Add("OdrPrtsNoHyphenCd6");
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            if (uOESupplier1.instrumentNo != uOESupplier2.instrumentNo) resList.Add("instrumentNo");
            if (uOESupplier1.UOETestMode != uOESupplier2.UOETestMode) resList.Add("UOETestMode");
            if (uOESupplier1.UOEItemCd != uOESupplier2.UOEItemCd) resList.Add("UOEItemCd");
            if (uOESupplier1.HondaSectionCode != uOESupplier2.HondaSectionCode) resList.Add("HondaSectionCode");
            if (uOESupplier1.AnswerSaveFolder != uOESupplier2.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (uOESupplier1.MazdaSectionCode != uOESupplier2.MazdaSectionCode) resList.Add("MazdaSectionCode");
            if (uOESupplier1.EmergencyDiv != uOESupplier2.EmergencyDiv) resList.Add("EmergencyDiv");
            if (uOESupplier1.DaihatsuOrdreDiv != uOESupplier2.DaihatsuOrdreDiv) resList.Add("DaihatsuOrdreDiv");
            if (uOESupplier1.EnterpriseName != uOESupplier2.EnterpriseName) resList.Add("EnterpriseName");
            if (uOESupplier1.UpdEmployeeName != uOESupplier2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (uOESupplier1.BusinessName != uOESupplier2.BusinessName) resList.Add("BusinessName");
            if (uOESupplier1.SectionCode != uOESupplier2.SectionCode) resList.Add("SectionCode");
            if (uOESupplier1.SupplierCd != uOESupplier2.SupplierCd) resList.Add("SupplierCd");
            // ---ADD 2009/06/01 ---------------------------------->>>>>
            if (uOESupplier1.LoginTimeoutVal != uOESupplier2.LoginTimeoutVal) resList.Add("LoginTimeoutVal");
            if (uOESupplier1.UOEOrderUrl != uOESupplier2.UOEOrderUrl) resList.Add("UOEOrderUrl");
            if (uOESupplier1.UOEStockCheckUrl != uOESupplier2.UOEStockCheckUrl) resList.Add("UOEStockCheckUrl");
            if (uOESupplier1.UOEForcedTermUrl != uOESupplier2.UOEForcedTermUrl) resList.Add("UOEForcedTermUrl");
            if (uOESupplier1.UOELoginUrl != uOESupplier2.UOELoginUrl) resList.Add("UOELoginUrl");
            if (uOESupplier1.InqOrdDivCd != uOESupplier2.InqOrdDivCd) resList.Add("InqOrdDivCd");
            if (uOESupplier1.EPartsUserId != uOESupplier2.EPartsUserId) resList.Add("EPartsUserId");
            if (uOESupplier1.EPartsPassWord != uOESupplier2.EPartsPassWord) resList.Add("EPartsPassWord");
            // ---ADD 2009/06/01 ----------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            if (uOESupplier1.BLMngUserCode != uOESupplier2.BLMngUserCode) resList.Add("BLMngUserCode");
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
