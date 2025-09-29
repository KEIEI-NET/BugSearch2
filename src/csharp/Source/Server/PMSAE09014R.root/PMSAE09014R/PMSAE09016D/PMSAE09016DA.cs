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
// �� �� ��  2009/08/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SAndESettingWork
    /// <summary>
    ///                      �I�[�g�o�b�N�X�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I�[�g�o�b�N�X�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/6/25</br>
    /// <br>Genarated Date   :   2009/08/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/7/17  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���i���[�J�[�R�[�h�P�T</br>
    /// <br>                 :   ���L�[�ύX</br>
    /// <br>                 :   3,10��3,9,10</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SAndESettingWork : IFileHeader
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

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

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

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerName = "";


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

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
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

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }


        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SAndESettingWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESettingWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SAndESettingWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SAndESettingWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SAndESettingWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SAndESettingWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESettingWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SAndESettingWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SAndESettingWork || graph is ArrayList || graph is SAndESettingWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SAndESettingWork).FullName));

            if (graph != null && graph is SAndESettingWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SAndESettingWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SAndESettingWork[])graph).Length;
            }
            else if (graph is SAndESettingWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�[�i��X�܃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddresseeShopCd
            //�Z�d�Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SAndEMngCode
            //�o��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpenseDivCd
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DirectSendingCd
            //�󒍋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOrderDiv
            //�[�i�҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DelivererCd
            //�[�i�Җ�
            serInfo.MemberInfo.Add(typeof(string)); //DelivererNm
            //�[�i�ҏZ��
            serInfo.MemberInfo.Add(typeof(string)); //DelivererAddress
            //�[�i�҂s�d�k
            serInfo.MemberInfo.Add(typeof(string)); //DelivererPhoneNum
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //TradCompName
            //���i�����_��
            serInfo.MemberInfo.Add(typeof(string)); //TradCompSectName
            //���i���R�[�h�i�����j
            serInfo.MemberInfo.Add(typeof(string)); //PureTradCompCd
            //���i���d�ؗ��i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //PureTradCompRate
            //���i���R�[�h�i�D�ǁj
            serInfo.MemberInfo.Add(typeof(string)); //PriTradCompCd
            //���i���d�ؗ��i�D�ǁj
            serInfo.MemberInfo.Add(typeof(Double)); //PriTradCompRate
            //AB���i�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ABGoodsCode
            //�R�����g�w��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CommentReservedDiv
            //���i���[�J�[�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd1
            //���i���[�J�[�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd2
            //���i���[�J�[�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd3
            //���i���[�J�[�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd4
            //���i���[�J�[�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd5
            //���i���[�J�[�R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd6
            //���i���[�J�[�R�[�h�V
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd7
            //���i���[�J�[�R�[�h�W
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd8
            //���i���[�J�[�R�[�h�X
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd9
            //���i���[�J�[�R�[�h�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd10
            //���i���[�J�[�R�[�h�P�P
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd11
            //���i���[�J�[�R�[�h�P�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd12
            //���i���[�J�[�R�[�h�P�R
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd13
            //���i���[�J�[�R�[�h�P�S
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd14
            //���i���[�J�[�R�[�h�P�T
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd15
            //���i�n�d�l�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsOEMDiv
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName


            serInfo.Serialize(writer, serInfo);
            if (graph is SAndESettingWork)
            {
                SAndESettingWork temp = (SAndESettingWork)graph;

                SetSAndESettingWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SAndESettingWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SAndESettingWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SAndESettingWork temp in lst)
                {
                    SetSAndESettingWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SAndESettingWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 45;

        /// <summary>
        ///  SAndESettingWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESettingWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSAndESettingWork(System.IO.BinaryWriter writer, SAndESettingWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�[�i��X�܃R�[�h
            writer.Write(temp.AddresseeShopCd);
            //�Z�d�Ǘ��R�[�h
            writer.Write(temp.SAndEMngCode);
            //�o��敪
            writer.Write(temp.ExpenseDivCd);
            //�����敪
            writer.Write(temp.DirectSendingCd);
            //�󒍋敪
            writer.Write(temp.AcptAnOrderDiv);
            //�[�i�҃R�[�h
            writer.Write(temp.DelivererCd);
            //�[�i�Җ�
            writer.Write(temp.DelivererNm);
            //�[�i�ҏZ��
            writer.Write(temp.DelivererAddress);
            //�[�i�҂s�d�k
            writer.Write(temp.DelivererPhoneNum);
            //���i����
            writer.Write(temp.TradCompName);
            //���i�����_��
            writer.Write(temp.TradCompSectName);
            //���i���R�[�h�i�����j
            writer.Write(temp.PureTradCompCd);
            //���i���d�ؗ��i�����j
            writer.Write(temp.PureTradCompRate);
            //���i���R�[�h�i�D�ǁj
            writer.Write(temp.PriTradCompCd);
            //���i���d�ؗ��i�D�ǁj
            writer.Write(temp.PriTradCompRate);
            //AB���i�R�[�h
            writer.Write(temp.ABGoodsCode);
            //�R�����g�w��敪
            writer.Write(temp.CommentReservedDiv);
            //���i���[�J�[�R�[�h�P
            writer.Write(temp.GoodsMakerCd1);
            //���i���[�J�[�R�[�h�Q
            writer.Write(temp.GoodsMakerCd2);
            //���i���[�J�[�R�[�h�R
            writer.Write(temp.GoodsMakerCd3);
            //���i���[�J�[�R�[�h�S
            writer.Write(temp.GoodsMakerCd4);
            //���i���[�J�[�R�[�h�T
            writer.Write(temp.GoodsMakerCd5);
            //���i���[�J�[�R�[�h�U
            writer.Write(temp.GoodsMakerCd6);
            //���i���[�J�[�R�[�h�V
            writer.Write(temp.GoodsMakerCd7);
            //���i���[�J�[�R�[�h�W
            writer.Write(temp.GoodsMakerCd8);
            //���i���[�J�[�R�[�h�X
            writer.Write(temp.GoodsMakerCd9);
            //���i���[�J�[�R�[�h�P�O
            writer.Write(temp.GoodsMakerCd10);
            //���i���[�J�[�R�[�h�P�P
            writer.Write(temp.GoodsMakerCd11);
            //���i���[�J�[�R�[�h�P�Q
            writer.Write(temp.GoodsMakerCd12);
            //���i���[�J�[�R�[�h�P�R
            writer.Write(temp.GoodsMakerCd13);
            //���i���[�J�[�R�[�h�P�S
            writer.Write(temp.GoodsMakerCd14);
            //���i���[�J�[�R�[�h�P�T
            writer.Write(temp.GoodsMakerCd15);
            //���i�n�d�l�敪
            writer.Write(temp.PartsOEMDiv);
            //���_����
            writer.Write(temp.SectionName);
            //���Ӑ旪��
            writer.Write(temp.CustomerName);

        }

        /// <summary>
        ///  SAndESettingWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SAndESettingWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESettingWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SAndESettingWork GetSAndESettingWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SAndESettingWork temp = new SAndESettingWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�[�i��X�܃R�[�h
            temp.AddresseeShopCd = reader.ReadString();
            //�Z�d�Ǘ��R�[�h
            temp.SAndEMngCode = reader.ReadString();
            //�o��敪
            temp.ExpenseDivCd = reader.ReadInt32();
            //�����敪
            temp.DirectSendingCd = reader.ReadInt32();
            //�󒍋敪
            temp.AcptAnOrderDiv = reader.ReadInt32();
            //�[�i�҃R�[�h
            temp.DelivererCd = reader.ReadString();
            //�[�i�Җ�
            temp.DelivererNm = reader.ReadString();
            //�[�i�ҏZ��
            temp.DelivererAddress = reader.ReadString();
            //�[�i�҂s�d�k
            temp.DelivererPhoneNum = reader.ReadString();
            //���i����
            temp.TradCompName = reader.ReadString();
            //���i�����_��
            temp.TradCompSectName = reader.ReadString();
            //���i���R�[�h�i�����j
            temp.PureTradCompCd = reader.ReadString();
            //���i���d�ؗ��i�����j
            temp.PureTradCompRate = reader.ReadDouble();
            //���i���R�[�h�i�D�ǁj
            temp.PriTradCompCd = reader.ReadString();
            //���i���d�ؗ��i�D�ǁj
            temp.PriTradCompRate = reader.ReadDouble();
            //AB���i�R�[�h
            temp.ABGoodsCode = reader.ReadString();
            //�R�����g�w��敪
            temp.CommentReservedDiv = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P
            temp.GoodsMakerCd1 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�Q
            temp.GoodsMakerCd2 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�R
            temp.GoodsMakerCd3 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�S
            temp.GoodsMakerCd4 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�T
            temp.GoodsMakerCd5 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�U
            temp.GoodsMakerCd6 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�V
            temp.GoodsMakerCd7 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�W
            temp.GoodsMakerCd8 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�X
            temp.GoodsMakerCd9 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�O
            temp.GoodsMakerCd10 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�P
            temp.GoodsMakerCd11 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�Q
            temp.GoodsMakerCd12 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�R
            temp.GoodsMakerCd13 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�S
            temp.GoodsMakerCd14 = reader.ReadInt32();
            //���i���[�J�[�R�[�h�P�T
            temp.GoodsMakerCd15 = reader.ReadInt32();
            //���i�n�d�l�敪
            temp.PartsOEMDiv = reader.ReadInt32();
            //���_����
            temp.SectionName = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerName = reader.ReadString();


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
        /// <returns>SAndESettingWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESettingWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SAndESettingWork temp = GetSAndESettingWork(reader, serInfo);
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
                    retValue = (SAndESettingWork[])lst.ToArray(typeof(SAndESettingWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


