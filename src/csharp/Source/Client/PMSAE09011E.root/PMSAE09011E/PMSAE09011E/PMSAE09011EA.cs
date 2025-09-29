//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �I�[�g�o�b�N�X�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/07/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SAndESetting
    /// <summary>
    ///                      �I�[�g�o�b�N�X�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I�[�g�o�b�N�X�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/6/25</br>
    /// <br>Genarated Date   :   2009/07/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/7/17  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���i���[�J�[�R�[�h�P�T</br>
    /// <br>                 :   ���L�[�ύX</br>
    /// <br>                 :   3,10��3,9,10</br>
    /// </remarks>
    public class SAndESetting
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

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���O�C���S���҂̏������_�R�[�h���Z�b�g</remarks>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���O�C���S���҂̏������_���̂��Z�b�g</remarks>
        private string _sectionName = "";


        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        /// <remarks>���O�C���S���҂̏������Ӑ於�̂��Z�b�g</remarks>
        private string _customerName = "";


        /// <summary>�[�i��X�܃R�[�h</summary>
        private string _addresseeShopCd = "";

        /// <summary>�Z�d�Ǘ��R�[�h</summary>
        private string _sAndEMngCode = "";

        /// <summary>�o��敪</summary>
        private Int32 _expenseDivCd;

        /// <summary>�����敪</summary>
        private Int32 _directSendingCd;

        /// <summary>�󒍋敪</summary>
        private Int32 _acptAnOrderDiv;

        /// <summary>�[�i�҃R�[�h</summary>
        private string _delivererCd = "";

        /// <summary>�[�i�Җ�</summary>
        private string _delivererNm = "";

        /// <summary>�[�i�ҏZ��</summary>
        private string _delivererAddress = "";

        /// <summary>�[�i�҂s�d�k</summary>
        private string _delivererPhoneNum = "";

        /// <summary>���i����</summary>
        private string _tradCompName = "";

        /// <summary>���i�����_��</summary>
        private string _tradCompSectName = "";

        /// <summary>���i���R�[�h�i�����j</summary>
        private string _pureTradCompCd = "";

        /// <summary>���i���d�ؗ��i�����j</summary>
        private Double _pureTradCompRate;

        /// <summary>���i���R�[�h�i�D�ǁj</summary>
        private string _priTradCompCd = "";

        /// <summary>���i���d�ؗ��i�D�ǁj</summary>
        private Double _priTradCompRate;

        /// <summary>AB���i�R�[�h</summary>
        private string _aBGoodsCode = "";

        /// <summary>�R�����g�w��敪</summary>
        /// <remarks>"�V�s�ڃR�����g�w��敪"</remarks>
        private Int32 _commentReservedDiv;

        /// <summary>���i���[�J�[�R�[�h�P</summary>
        private Int32 _goodsMakerCd1;

        /// <summary>���i���[�J�[�R�[�h�Q</summary>
        private Int32 _goodsMakerCd2;

        /// <summary>���i���[�J�[�R�[�h�R</summary>
        private Int32 _goodsMakerCd3;

        /// <summary>���i���[�J�[�R�[�h�S</summary>
        private Int32 _goodsMakerCd4;

        /// <summary>���i���[�J�[�R�[�h�T</summary>
        private Int32 _goodsMakerCd5;

        /// <summary>���i���[�J�[�R�[�h�U</summary>
        private Int32 _goodsMakerCd6;

        /// <summary>���i���[�J�[�R�[�h�V</summary>
        private Int32 _goodsMakerCd7;

        /// <summary>���i���[�J�[�R�[�h�W</summary>
        private Int32 _goodsMakerCd8;

        /// <summary>���i���[�J�[�R�[�h�X</summary>
        private Int32 _goodsMakerCd9;

        /// <summary>���i���[�J�[�R�[�h�P�O</summary>
        private Int32 _goodsMakerCd10;

        /// <summary>���i���[�J�[�R�[�h�P�P</summary>
        private Int32 _goodsMakerCd11;

        /// <summary>���i���[�J�[�R�[�h�P�Q</summary>
        private Int32 _goodsMakerCd12;

        /// <summary>���i���[�J�[�R�[�h�P�R</summary>
        private Int32 _goodsMakerCd13;

        /// <summary>���i���[�J�[�R�[�h�P�S</summary>
        private Int32 _goodsMakerCd14;

        /// <summary>���i���[�J�[�R�[�h�P�T</summary>
        private Int32 _goodsMakerCd15;

        /// <summary>���i�n�d�l�敪</summary>
        private Int32 _partsOEMDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���O�C���S���҂̏������_�R�[�h���Z�b�g</value>
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

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// <value>���O�C���S���҂̏������_���̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }


        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// <value>���O�C���S���҂̏������Ӑ於�̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  AddresseeShopCd
        /// <summary>�[�i��X�܃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�܃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeShopCd
        {
            get { return _addresseeShopCd; }
            set { _addresseeShopCd = value; }
        }

        /// public propaty name  :  SAndEMngCode
        /// <summary>�Z�d�Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�d�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SAndEMngCode
        {
            get { return _sAndEMngCode; }
            set { _sAndEMngCode = value; }
        }

        /// public propaty name  :  ExpenseDivCd
        /// <summary>�o��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExpenseDivCd
        {
            get { return _expenseDivCd; }
            set { _expenseDivCd = value; }
        }

        /// public propaty name  :  DirectSendingCd
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DirectSendingCd
        {
            get { return _directSendingCd; }
            set { _directSendingCd = value; }
        }

        /// public propaty name  :  AcptAnOrderDiv
        /// <summary>�󒍋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOrderDiv
        {
            get { return _acptAnOrderDiv; }
            set { _acptAnOrderDiv = value; }
        }

        /// public propaty name  :  DelivererCd
        /// <summary>�[�i�҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DelivererCd
        {
            get { return _delivererCd; }
            set { _delivererCd = value; }
        }

        /// public propaty name  :  DelivererNm
        /// <summary>�[�i�Җ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DelivererNm
        {
            get { return _delivererNm; }
            set { _delivererNm = value; }
        }

        /// public propaty name  :  DelivererAddress
        /// <summary>�[�i�ҏZ���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�ҏZ���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DelivererAddress
        {
            get { return _delivererAddress; }
            set { _delivererAddress = value; }
        }

        /// public propaty name  :  DelivererPhoneNum
        /// <summary>�[�i�҂s�d�k�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�҂s�d�k�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DelivererPhoneNum
        {
            get { return _delivererPhoneNum; }
            set { _delivererPhoneNum = value; }
        }

        /// public propaty name  :  TradCompName
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TradCompName
        {
            get { return _tradCompName; }
            set { _tradCompName = value; }
        }

        /// public propaty name  :  TradCompSectName
        /// <summary>���i�����_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TradCompSectName
        {
            get { return _tradCompSectName; }
            set { _tradCompSectName = value; }
        }

        /// public propaty name  :  PureTradCompCd
        /// <summary>���i���R�[�h�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PureTradCompCd
        {
            get { return _pureTradCompCd; }
            set { _pureTradCompCd = value; }
        }

        /// public propaty name  :  PureTradCompRate
        /// <summary>���i���d�ؗ��i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���d�ؗ��i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PureTradCompRate
        {
            get { return _pureTradCompRate; }
            set { _pureTradCompRate = value; }
        }

        /// public propaty name  :  PriTradCompCd
        /// <summary>���i���R�[�h�i�D�ǁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���R�[�h�i�D�ǁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriTradCompCd
        {
            get { return _priTradCompCd; }
            set { _priTradCompCd = value; }
        }

        /// public propaty name  :  PriTradCompRate
        /// <summary>���i���d�ؗ��i�D�ǁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���d�ؗ��i�D�ǁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriTradCompRate
        {
            get { return _priTradCompRate; }
            set { _priTradCompRate = value; }
        }

        /// public propaty name  :  ABGoodsCode
        /// <summary>AB���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ABGoodsCode
        {
            get { return _aBGoodsCode; }
            set { _aBGoodsCode = value; }
        }

        /// public propaty name  :  CommentReservedDiv
        /// <summary>�R�����g�w��敪�v���p�e�B</summary>
        /// <value>"�V�s�ڃR�����g�w��敪"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommentReservedDiv
        {
            get { return _commentReservedDiv; }
            set { _commentReservedDiv = value; }
        }

        /// public propaty name  :  GoodsMakerCd1
        /// <summary>���i���[�J�[�R�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd1
        {
            get { return _goodsMakerCd1; }
            set { _goodsMakerCd1 = value; }
        }

        /// public propaty name  :  GoodsMakerCd2
        /// <summary>���i���[�J�[�R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd2
        {
            get { return _goodsMakerCd2; }
            set { _goodsMakerCd2 = value; }
        }

        /// public propaty name  :  GoodsMakerCd3
        /// <summary>���i���[�J�[�R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd3
        {
            get { return _goodsMakerCd3; }
            set { _goodsMakerCd3 = value; }
        }

        /// public propaty name  :  GoodsMakerCd4
        /// <summary>���i���[�J�[�R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd4
        {
            get { return _goodsMakerCd4; }
            set { _goodsMakerCd4 = value; }
        }

        /// public propaty name  :  GoodsMakerCd5
        /// <summary>���i���[�J�[�R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd5
        {
            get { return _goodsMakerCd5; }
            set { _goodsMakerCd5 = value; }
        }

        /// public propaty name  :  GoodsMakerCd6
        /// <summary>���i���[�J�[�R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd6
        {
            get { return _goodsMakerCd6; }
            set { _goodsMakerCd6 = value; }
        }

        /// public propaty name  :  GoodsMakerCd7
        /// <summary>���i���[�J�[�R�[�h�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd7
        {
            get { return _goodsMakerCd7; }
            set { _goodsMakerCd7 = value; }
        }

        /// public propaty name  :  GoodsMakerCd8
        /// <summary>���i���[�J�[�R�[�h�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd8
        {
            get { return _goodsMakerCd8; }
            set { _goodsMakerCd8 = value; }
        }

        /// public propaty name  :  GoodsMakerCd9
        /// <summary>���i���[�J�[�R�[�h�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd9
        {
            get { return _goodsMakerCd9; }
            set { _goodsMakerCd9 = value; }
        }

        /// public propaty name  :  GoodsMakerCd10
        /// <summary>���i���[�J�[�R�[�h�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd10
        {
            get { return _goodsMakerCd10; }
            set { _goodsMakerCd10 = value; }
        }

        /// public propaty name  :  GoodsMakerCd11
        /// <summary>���i���[�J�[�R�[�h�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd11
        {
            get { return _goodsMakerCd11; }
            set { _goodsMakerCd11 = value; }
        }

        /// public propaty name  :  GoodsMakerCd12
        /// <summary>���i���[�J�[�R�[�h�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd12
        {
            get { return _goodsMakerCd12; }
            set { _goodsMakerCd12 = value; }
        }

        /// public propaty name  :  GoodsMakerCd13
        /// <summary>���i���[�J�[�R�[�h�P�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd13
        {
            get { return _goodsMakerCd13; }
            set { _goodsMakerCd13 = value; }
        }

        /// public propaty name  :  GoodsMakerCd14
        /// <summary>���i���[�J�[�R�[�h�P�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd14
        {
            get { return _goodsMakerCd14; }
            set { _goodsMakerCd14 = value; }
        }

        /// public propaty name  :  GoodsMakerCd15
        /// <summary>���i���[�J�[�R�[�h�P�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�P�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd15
        {
            get { return _goodsMakerCd15; }
            set { _goodsMakerCd15 = value; }
        }

        /// public propaty name  :  PartsOEMDiv
        /// <summary>���i�n�d�l�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�n�d�l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsOEMDiv
        {
            get { return _partsOEMDiv; }
            set { _partsOEMDiv = value; }
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


        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SAndESetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SAndESetting()
        {
        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(���O�C���S���҂̏������_�R�[�h���Z�b�g)</param>
        /// <param name="sectionName">���_����(���O�C���S���҂̏������_���̂��Z�b�g)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="addresseeShopCd">�[�i��X�܃R�[�h</param>
        /// <param name="sAndEMngCode">�Z�d�Ǘ��R�[�h</param>
        /// <param name="expenseDivCd">�o��敪</param>
        /// <param name="directSendingCd">�����敪</param>
        /// <param name="acptAnOrderDiv">�󒍋敪</param>
        /// <param name="delivererCd">�[�i�҃R�[�h</param>
        /// <param name="delivererNm">�[�i�Җ�</param>
        /// <param name="delivererAddress">�[�i�ҏZ��</param>
        /// <param name="delivererPhoneNum">�[�i�҂s�d�k</param>
        /// <param name="tradCompName">���i����</param>
        /// <param name="tradCompSectName">���i�����_��</param>
        /// <param name="pureTradCompCd">���i���R�[�h�i�����j</param>
        /// <param name="pureTradCompRate">���i���d�ؗ��i�����j</param>
        /// <param name="priTradCompCd">���i���R�[�h�i�D�ǁj</param>
        /// <param name="priTradCompRate">���i���d�ؗ��i�D�ǁj</param>
        /// <param name="aBGoodsCode">AB���i�R�[�h</param>
        /// <param name="commentReservedDiv">�R�����g�w��敪("�V�s�ڃR�����g�w��敪")</param>
        /// <param name="goodsMakerCd1">���i���[�J�[�R�[�h�P</param>
        /// <param name="goodsMakerCd2">���i���[�J�[�R�[�h�Q</param>
        /// <param name="goodsMakerCd3">���i���[�J�[�R�[�h�R</param>
        /// <param name="goodsMakerCd4">���i���[�J�[�R�[�h�S</param>
        /// <param name="goodsMakerCd5">���i���[�J�[�R�[�h�T</param>
        /// <param name="goodsMakerCd6">���i���[�J�[�R�[�h�U</param>
        /// <param name="goodsMakerCd7">���i���[�J�[�R�[�h�V</param>
        /// <param name="goodsMakerCd8">���i���[�J�[�R�[�h�W</param>
        /// <param name="goodsMakerCd9">���i���[�J�[�R�[�h�X</param>
        /// <param name="goodsMakerCd10">���i���[�J�[�R�[�h�P�O</param>
        /// <param name="goodsMakerCd11">���i���[�J�[�R�[�h�P�P</param>
        /// <param name="goodsMakerCd12">���i���[�J�[�R�[�h�P�Q</param>
        /// <param name="goodsMakerCd13">���i���[�J�[�R�[�h�P�R</param>
        /// <param name="goodsMakerCd14">���i���[�J�[�R�[�h�P�S</param>
        /// <param name="goodsMakerCd15">���i���[�J�[�R�[�h�P�T</param>
        /// <param name="partsOEMDiv">���i�n�d�l�敪</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>SAndESetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SAndESetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionName, Int32 customerCode, string customerName, string addresseeShopCd, string sAndEMngCode, Int32 expenseDivCd, Int32 directSendingCd, Int32 acptAnOrderDiv, string delivererCd, string delivererNm, string delivererAddress, string delivererPhoneNum, string tradCompName, string tradCompSectName, string pureTradCompCd, Double pureTradCompRate, string priTradCompCd, Double priTradCompRate, string aBGoodsCode, Int32 commentReservedDiv, Int32 goodsMakerCd1, Int32 goodsMakerCd2, Int32 goodsMakerCd3, Int32 goodsMakerCd4, Int32 goodsMakerCd5, Int32 goodsMakerCd6, Int32 goodsMakerCd7, Int32 goodsMakerCd8, Int32 goodsMakerCd9, Int32 goodsMakerCd10, Int32 goodsMakerCd11, Int32 goodsMakerCd12, Int32 goodsMakerCd13, Int32 goodsMakerCd14, Int32 goodsMakerCd15, Int32 partsOEMDiv, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._addresseeShopCd = addresseeShopCd;
            this._sAndEMngCode = sAndEMngCode;
            this._expenseDivCd = expenseDivCd;
            this._directSendingCd = directSendingCd;
            this._acptAnOrderDiv = acptAnOrderDiv;
            this._delivererCd = delivererCd;
            this._delivererNm = delivererNm;
            this._delivererAddress = delivererAddress;
            this._delivererPhoneNum = delivererPhoneNum;
            this._tradCompName = tradCompName;
            this._tradCompSectName = tradCompSectName;
            this._pureTradCompCd = pureTradCompCd;
            this._pureTradCompRate = pureTradCompRate;
            this._priTradCompCd = priTradCompCd;
            this._priTradCompRate = priTradCompRate;
            this._aBGoodsCode = aBGoodsCode;
            this._commentReservedDiv = commentReservedDiv;
            this._goodsMakerCd1 = goodsMakerCd1;
            this._goodsMakerCd2 = goodsMakerCd2;
            this._goodsMakerCd3 = goodsMakerCd3;
            this._goodsMakerCd4 = goodsMakerCd4;
            this._goodsMakerCd5 = goodsMakerCd5;
            this._goodsMakerCd6 = goodsMakerCd6;
            this._goodsMakerCd7 = goodsMakerCd7;
            this._goodsMakerCd8 = goodsMakerCd8;
            this._goodsMakerCd9 = goodsMakerCd9;
            this._goodsMakerCd10 = goodsMakerCd10;
            this._goodsMakerCd11 = goodsMakerCd11;
            this._goodsMakerCd12 = goodsMakerCd12;
            this._goodsMakerCd13 = goodsMakerCd13;
            this._goodsMakerCd14 = goodsMakerCd14;
            this._goodsMakerCd15 = goodsMakerCd15;
            this._partsOEMDiv = partsOEMDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^��������
        /// </summary>
        /// <returns>SAndESetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SAndESetting�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SAndESetting Clone()
        {
            return new SAndESetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionName, this._customerCode, this._customerName, this._addresseeShopCd, this._sAndEMngCode, this._expenseDivCd, this._directSendingCd, this._acptAnOrderDiv, this._delivererCd, this._delivererNm, this._delivererAddress, this._delivererPhoneNum, this._tradCompName, this._tradCompSectName, this._pureTradCompCd, this._pureTradCompRate, this._priTradCompCd, this._priTradCompRate, this._aBGoodsCode, this._commentReservedDiv, this._goodsMakerCd1, this._goodsMakerCd2, this._goodsMakerCd3, this._goodsMakerCd4, this._goodsMakerCd5, this._goodsMakerCd6, this._goodsMakerCd7, this._goodsMakerCd8, this._goodsMakerCd9, this._goodsMakerCd10, this._goodsMakerCd11, this._goodsMakerCd12, this._goodsMakerCd13, this._goodsMakerCd14, this._goodsMakerCd15, this._partsOEMDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SAndESetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SAndESetting target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.AddresseeShopCd == target.AddresseeShopCd)
                 && (this.SAndEMngCode == target.SAndEMngCode)
                 && (this.ExpenseDivCd == target.ExpenseDivCd)
                 && (this.DirectSendingCd == target.DirectSendingCd)
                 && (this.AcptAnOrderDiv == target.AcptAnOrderDiv)
                 && (this.DelivererCd == target.DelivererCd)
                 && (this.DelivererNm == target.DelivererNm)
                 && (this.DelivererAddress == target.DelivererAddress)
                 && (this.DelivererPhoneNum == target.DelivererPhoneNum)
                 && (this.TradCompName == target.TradCompName)
                 && (this.TradCompSectName == target.TradCompSectName)
                 && (this.PureTradCompCd == target.PureTradCompCd)
                 && (this.PureTradCompRate == target.PureTradCompRate)
                 && (this.PriTradCompCd == target.PriTradCompCd)
                 && (this.PriTradCompRate == target.PriTradCompRate)
                 && (this.ABGoodsCode == target.ABGoodsCode)
                 && (this.CommentReservedDiv == target.CommentReservedDiv)
                 && (this.GoodsMakerCd1 == target.GoodsMakerCd1)
                 && (this.GoodsMakerCd2 == target.GoodsMakerCd2)
                 && (this.GoodsMakerCd3 == target.GoodsMakerCd3)
                 && (this.GoodsMakerCd4 == target.GoodsMakerCd4)
                 && (this.GoodsMakerCd5 == target.GoodsMakerCd5)
                 && (this.GoodsMakerCd6 == target.GoodsMakerCd6)
                 && (this.GoodsMakerCd7 == target.GoodsMakerCd7)
                 && (this.GoodsMakerCd8 == target.GoodsMakerCd8)
                 && (this.GoodsMakerCd9 == target.GoodsMakerCd9)
                 && (this.GoodsMakerCd10 == target.GoodsMakerCd10)
                 && (this.GoodsMakerCd11 == target.GoodsMakerCd11)
                 && (this.GoodsMakerCd12 == target.GoodsMakerCd12)
                 && (this.GoodsMakerCd13 == target.GoodsMakerCd13)
                 && (this.GoodsMakerCd14 == target.GoodsMakerCd14)
                 && (this.GoodsMakerCd15 == target.GoodsMakerCd15)
                 && (this.PartsOEMDiv == target.PartsOEMDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="sAndESetting1">
        ///                    ��r����SAndESetting�N���X�̃C���X�^���X
        /// </param>
        /// <param name="sAndESetting2">��r����SAndESetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SAndESetting sAndESetting1, SAndESetting sAndESetting2)
        {
            return ((sAndESetting1.CreateDateTime == sAndESetting2.CreateDateTime)
                 && (sAndESetting1.UpdateDateTime == sAndESetting2.UpdateDateTime)
                 && (sAndESetting1.EnterpriseCode == sAndESetting2.EnterpriseCode)
                 && (sAndESetting1.FileHeaderGuid == sAndESetting2.FileHeaderGuid)
                 && (sAndESetting1.UpdEmployeeCode == sAndESetting2.UpdEmployeeCode)
                 && (sAndESetting1.UpdAssemblyId1 == sAndESetting2.UpdAssemblyId1)
                 && (sAndESetting1.UpdAssemblyId2 == sAndESetting2.UpdAssemblyId2)
                 && (sAndESetting1.LogicalDeleteCode == sAndESetting2.LogicalDeleteCode)
                 && (sAndESetting1.SectionCode == sAndESetting2.SectionCode)
                 && (sAndESetting1.SectionName == sAndESetting2.SectionName)
                 && (sAndESetting1.CustomerCode == sAndESetting2.CustomerCode)
                 && (sAndESetting1.CustomerName == sAndESetting2.CustomerName)
                 && (sAndESetting1.AddresseeShopCd == sAndESetting2.AddresseeShopCd)
                 && (sAndESetting1.SAndEMngCode == sAndESetting2.SAndEMngCode)
                 && (sAndESetting1.ExpenseDivCd == sAndESetting2.ExpenseDivCd)
                 && (sAndESetting1.DirectSendingCd == sAndESetting2.DirectSendingCd)
                 && (sAndESetting1.AcptAnOrderDiv == sAndESetting2.AcptAnOrderDiv)
                 && (sAndESetting1.DelivererCd == sAndESetting2.DelivererCd)
                 && (sAndESetting1.DelivererNm == sAndESetting2.DelivererNm)
                 && (sAndESetting1.DelivererAddress == sAndESetting2.DelivererAddress)
                 && (sAndESetting1.DelivererPhoneNum == sAndESetting2.DelivererPhoneNum)
                 && (sAndESetting1.TradCompName == sAndESetting2.TradCompName)
                 && (sAndESetting1.TradCompSectName == sAndESetting2.TradCompSectName)
                 && (sAndESetting1.PureTradCompCd == sAndESetting2.PureTradCompCd)
                 && (sAndESetting1.PureTradCompRate == sAndESetting2.PureTradCompRate)
                 && (sAndESetting1.PriTradCompCd == sAndESetting2.PriTradCompCd)
                 && (sAndESetting1.PriTradCompRate == sAndESetting2.PriTradCompRate)
                 && (sAndESetting1.ABGoodsCode == sAndESetting2.ABGoodsCode)
                 && (sAndESetting1.CommentReservedDiv == sAndESetting2.CommentReservedDiv)
                 && (sAndESetting1.GoodsMakerCd1 == sAndESetting2.GoodsMakerCd1)
                 && (sAndESetting1.GoodsMakerCd2 == sAndESetting2.GoodsMakerCd2)
                 && (sAndESetting1.GoodsMakerCd3 == sAndESetting2.GoodsMakerCd3)
                 && (sAndESetting1.GoodsMakerCd4 == sAndESetting2.GoodsMakerCd4)
                 && (sAndESetting1.GoodsMakerCd5 == sAndESetting2.GoodsMakerCd5)
                 && (sAndESetting1.GoodsMakerCd6 == sAndESetting2.GoodsMakerCd6)
                 && (sAndESetting1.GoodsMakerCd7 == sAndESetting2.GoodsMakerCd7)
                 && (sAndESetting1.GoodsMakerCd8 == sAndESetting2.GoodsMakerCd8)
                 && (sAndESetting1.GoodsMakerCd9 == sAndESetting2.GoodsMakerCd9)
                 && (sAndESetting1.GoodsMakerCd10 == sAndESetting2.GoodsMakerCd10)
                 && (sAndESetting1.GoodsMakerCd11 == sAndESetting2.GoodsMakerCd11)
                 && (sAndESetting1.GoodsMakerCd12 == sAndESetting2.GoodsMakerCd12)
                 && (sAndESetting1.GoodsMakerCd13 == sAndESetting2.GoodsMakerCd13)
                 && (sAndESetting1.GoodsMakerCd14 == sAndESetting2.GoodsMakerCd14)
                 && (sAndESetting1.GoodsMakerCd15 == sAndESetting2.GoodsMakerCd15)
                 && (sAndESetting1.PartsOEMDiv == sAndESetting2.PartsOEMDiv)
                 && (sAndESetting1.EnterpriseName == sAndESetting2.EnterpriseName)
                 && (sAndESetting1.UpdEmployeeName == sAndESetting2.UpdEmployeeName));
        }
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SAndESetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESetting�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SAndESetting target)
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
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.AddresseeShopCd != target.AddresseeShopCd) resList.Add("AddresseeShopCd");
            if (this.SAndEMngCode != target.SAndEMngCode) resList.Add("SAndEMngCode");
            if (this.ExpenseDivCd != target.ExpenseDivCd) resList.Add("ExpenseDivCd");
            if (this.DirectSendingCd != target.DirectSendingCd) resList.Add("DirectSendingCd");
            if (this.AcptAnOrderDiv != target.AcptAnOrderDiv) resList.Add("AcptAnOrderDiv");
            if (this.DelivererCd != target.DelivererCd) resList.Add("DelivererCd");
            if (this.DelivererNm != target.DelivererNm) resList.Add("DelivererNm");
            if (this.DelivererAddress != target.DelivererAddress) resList.Add("DelivererAddress");
            if (this.DelivererPhoneNum != target.DelivererPhoneNum) resList.Add("DelivererPhoneNum");
            if (this.TradCompName != target.TradCompName) resList.Add("TradCompName");
            if (this.TradCompSectName != target.TradCompSectName) resList.Add("TradCompSectName");
            if (this.PureTradCompCd != target.PureTradCompCd) resList.Add("PureTradCompCd");
            if (this.PureTradCompRate != target.PureTradCompRate) resList.Add("PureTradCompRate");
            if (this.PriTradCompCd != target.PriTradCompCd) resList.Add("PriTradCompCd");
            if (this.PriTradCompRate != target.PriTradCompRate) resList.Add("PriTradCompRate");
            if (this.ABGoodsCode != target.ABGoodsCode) resList.Add("ABGoodsCode");
            if (this.CommentReservedDiv != target.CommentReservedDiv) resList.Add("CommentReservedDiv");
            if (this.GoodsMakerCd1 != target.GoodsMakerCd1) resList.Add("GoodsMakerCd1");
            if (this.GoodsMakerCd2 != target.GoodsMakerCd2) resList.Add("GoodsMakerCd2");
            if (this.GoodsMakerCd3 != target.GoodsMakerCd3) resList.Add("GoodsMakerCd3");
            if (this.GoodsMakerCd4 != target.GoodsMakerCd4) resList.Add("GoodsMakerCd4");
            if (this.GoodsMakerCd5 != target.GoodsMakerCd5) resList.Add("GoodsMakerCd5");
            if (this.GoodsMakerCd6 != target.GoodsMakerCd6) resList.Add("GoodsMakerCd6");
            if (this.GoodsMakerCd7 != target.GoodsMakerCd7) resList.Add("GoodsMakerCd7");
            if (this.GoodsMakerCd8 != target.GoodsMakerCd8) resList.Add("GoodsMakerCd8");
            if (this.GoodsMakerCd9 != target.GoodsMakerCd9) resList.Add("GoodsMakerCd9");
            if (this.GoodsMakerCd10 != target.GoodsMakerCd10) resList.Add("GoodsMakerCd10");
            if (this.GoodsMakerCd11 != target.GoodsMakerCd11) resList.Add("GoodsMakerCd11");
            if (this.GoodsMakerCd12 != target.GoodsMakerCd12) resList.Add("GoodsMakerCd12");
            if (this.GoodsMakerCd13 != target.GoodsMakerCd13) resList.Add("GoodsMakerCd13");
            if (this.GoodsMakerCd14 != target.GoodsMakerCd14) resList.Add("GoodsMakerCd14");
            if (this.GoodsMakerCd15 != target.GoodsMakerCd15) resList.Add("GoodsMakerCd15");
            if (this.PartsOEMDiv != target.PartsOEMDiv) resList.Add("PartsOEMDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="sAndESetting1">��r����SAndESetting�N���X�̃C���X�^���X</param>
        /// <param name="sAndESetting2">��r����SAndESetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESetting�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SAndESetting sAndESetting1, SAndESetting sAndESetting2)
        {
            ArrayList resList = new ArrayList();
            if (sAndESetting1.CreateDateTime != sAndESetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (sAndESetting1.UpdateDateTime != sAndESetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sAndESetting1.EnterpriseCode != sAndESetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sAndESetting1.FileHeaderGuid != sAndESetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sAndESetting1.UpdEmployeeCode != sAndESetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sAndESetting1.UpdAssemblyId1 != sAndESetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sAndESetting1.UpdAssemblyId2 != sAndESetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sAndESetting1.LogicalDeleteCode != sAndESetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sAndESetting1.SectionCode != sAndESetting2.SectionCode) resList.Add("SectionCode");
            if (sAndESetting1.SectionName != sAndESetting2.SectionName) resList.Add("SectionName");
            if (sAndESetting1.CustomerCode != sAndESetting2.CustomerCode) resList.Add("CustomerCode");
            if (sAndESetting1.CustomerName != sAndESetting2.CustomerName) resList.Add("CustomerName");
            if (sAndESetting1.AddresseeShopCd != sAndESetting2.AddresseeShopCd) resList.Add("AddresseeShopCd");
            if (sAndESetting1.SAndEMngCode != sAndESetting2.SAndEMngCode) resList.Add("SAndEMngCode");
            if (sAndESetting1.ExpenseDivCd != sAndESetting2.ExpenseDivCd) resList.Add("ExpenseDivCd");
            if (sAndESetting1.DirectSendingCd != sAndESetting2.DirectSendingCd) resList.Add("DirectSendingCd");
            if (sAndESetting1.AcptAnOrderDiv != sAndESetting2.AcptAnOrderDiv) resList.Add("AcptAnOrderDiv");
            if (sAndESetting1.DelivererCd != sAndESetting2.DelivererCd) resList.Add("DelivererCd");
            if (sAndESetting1.DelivererNm != sAndESetting2.DelivererNm) resList.Add("DelivererNm");
            if (sAndESetting1.DelivererAddress != sAndESetting2.DelivererAddress) resList.Add("DelivererAddress");
            if (sAndESetting1.DelivererPhoneNum != sAndESetting2.DelivererPhoneNum) resList.Add("DelivererPhoneNum");
            if (sAndESetting1.TradCompName != sAndESetting2.TradCompName) resList.Add("TradCompName");
            if (sAndESetting1.TradCompSectName != sAndESetting2.TradCompSectName) resList.Add("TradCompSectName");
            if (sAndESetting1.PureTradCompCd != sAndESetting2.PureTradCompCd) resList.Add("PureTradCompCd");
            if (sAndESetting1.PureTradCompRate != sAndESetting2.PureTradCompRate) resList.Add("PureTradCompRate");
            if (sAndESetting1.PriTradCompCd != sAndESetting2.PriTradCompCd) resList.Add("PriTradCompCd");
            if (sAndESetting1.PriTradCompRate != sAndESetting2.PriTradCompRate) resList.Add("PriTradCompRate");
            if (sAndESetting1.ABGoodsCode != sAndESetting2.ABGoodsCode) resList.Add("ABGoodsCode");
            if (sAndESetting1.CommentReservedDiv != sAndESetting2.CommentReservedDiv) resList.Add("CommentReservedDiv");
            if (sAndESetting1.GoodsMakerCd1 != sAndESetting2.GoodsMakerCd1) resList.Add("GoodsMakerCd1");
            if (sAndESetting1.GoodsMakerCd2 != sAndESetting2.GoodsMakerCd2) resList.Add("GoodsMakerCd2");
            if (sAndESetting1.GoodsMakerCd3 != sAndESetting2.GoodsMakerCd3) resList.Add("GoodsMakerCd3");
            if (sAndESetting1.GoodsMakerCd4 != sAndESetting2.GoodsMakerCd4) resList.Add("GoodsMakerCd4");
            if (sAndESetting1.GoodsMakerCd5 != sAndESetting2.GoodsMakerCd5) resList.Add("GoodsMakerCd5");
            if (sAndESetting1.GoodsMakerCd6 != sAndESetting2.GoodsMakerCd6) resList.Add("GoodsMakerCd6");
            if (sAndESetting1.GoodsMakerCd7 != sAndESetting2.GoodsMakerCd7) resList.Add("GoodsMakerCd7");
            if (sAndESetting1.GoodsMakerCd8 != sAndESetting2.GoodsMakerCd8) resList.Add("GoodsMakerCd8");
            if (sAndESetting1.GoodsMakerCd9 != sAndESetting2.GoodsMakerCd9) resList.Add("GoodsMakerCd9");
            if (sAndESetting1.GoodsMakerCd10 != sAndESetting2.GoodsMakerCd10) resList.Add("GoodsMakerCd10");
            if (sAndESetting1.GoodsMakerCd11 != sAndESetting2.GoodsMakerCd11) resList.Add("GoodsMakerCd11");
            if (sAndESetting1.GoodsMakerCd12 != sAndESetting2.GoodsMakerCd12) resList.Add("GoodsMakerCd12");
            if (sAndESetting1.GoodsMakerCd13 != sAndESetting2.GoodsMakerCd13) resList.Add("GoodsMakerCd13");
            if (sAndESetting1.GoodsMakerCd14 != sAndESetting2.GoodsMakerCd14) resList.Add("GoodsMakerCd14");
            if (sAndESetting1.GoodsMakerCd15 != sAndESetting2.GoodsMakerCd15) resList.Add("GoodsMakerCd15");
            if (sAndESetting1.PartsOEMDiv != sAndESetting2.PartsOEMDiv) resList.Add("PartsOEMDiv");
            if (sAndESetting1.EnterpriseName != sAndESetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (sAndESetting1.UpdEmployeeName != sAndESetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
