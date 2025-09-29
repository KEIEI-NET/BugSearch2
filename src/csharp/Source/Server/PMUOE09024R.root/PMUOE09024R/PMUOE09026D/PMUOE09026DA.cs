//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ������}�X�^�f�[�^�p�����[�^
//                  :   PMUOE09026D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06�@
// Note             :   ���e�[�u���ɂ͂Ȃ��ǉ����ڂ�����̂ŁA�����������͋C�����Ă�������
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOESupplierWork
    /// <summary>
    ///                      UOE�����惏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE�����惏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2009/05/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/22  ����</br>
    /// <br>                 :   �����ڒǉ��i�L�[�ύX�j</br>
    /// <br>                 :   �@���_�R�[�h</br>
    /// <br>                 :   �@�d����R�[�h</br>
    /// <br>Update Note      :   2008/9/9  ����</br>
    /// <br>                 :   ���^�ύX</br>
    /// <br>                 :   �@���_�֌W�̍��ڂ�nvarchar��nchar�ɕύX</br>
    /// <br>Update Note      :   2008/11/10  ����</br>
    /// <br>                 :   �����ڕύX�i�^�ύX�ɔ���DD�����ύX�j</br>
    /// <br>                 :   �@�[�i�敪</br>
    /// <br>                 :   �@��</br>
    /// <br>                 :   �@UOE�[�i�敪</br>
    /// <br>Update Note      :   2009/5/27  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���O�C���^�C���A�E�g</br>
    /// <br>                 :   UOE����URL</br>
    /// <br>                 :   UOE�݌Ɋm�FURL</br>
    /// <br>                 :   UOE�����I��URL</br>
    /// <br>                 :   UOE���O�C��URL</br>
    /// <br>                 :   �⍇���E�������</br>
    /// <br>                 :   e-Parts���[�UID</br>
    /// <br>                 :   e-Parts�p�X���[�h</br>
    /// <br>Update Note      :   2012/09/10  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   BL�Ǘ����[�U�[�R�[�h</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOESupplierWork : IFileHeader
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
        private string _sectionCode = "";

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d���f�[�^�v�㎞�̎d����R�[�h</remarks>
        private Int32 _supplierCd;

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

        /// <summary>UOE�h�c�ԍ�</summary>
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

        /// <summary>�i�Ԉ󎚋敪</summary>
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

        /// <summary>���O�C���^�C���A�E�g</summary>
        /// <remarks>�b</remarks>
        private Int32 _loginTimeoutVal;

        /// <summary>UOE����URL</summary>
        private string _uOEOrderUrl = "";

        /// <summary>UOE�݌Ɋm�FURL</summary>
        private string _uOEStockCheckUrl = "";

        /// <summary>UOE�����I��URL</summary>
        private string _uOEForcedTermUrl = "";

        /// <summary>UOE���O�C��URL</summary>
        private string _uOELoginUrl = "";

        /// <summary>�⍇���E�������</summary>
        /// <remarks>0:�������� 1:�݌Ɋm�F</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>e-Parts���[�UID</summary>
        private string _ePartsUserId = "";

        /// <summary>e-Parts�p�X���[�h</summary>
        private string _ePartsPassWord = "";

        /// <summary>UOE�o�ɋ��_����</summary>
        private string _uOEShipSectNm = "";

        /// <summary>UOE���㋒�_����</summary>
        private string _uOESalSectNm = "";

        /// <summary>UOE�w�苒�_����</summary>
        private string _uOEReservSectNm = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>�����\���[�J�[���̂P</summary>
        private string _enableOdrMakerName1 = "";

        /// <summary>�����\���[�J�[���̂Q</summary>
        private string _enableOdrMakerName2 = "";

        /// <summary>�����\���[�J�[���̂R</summary>
        private string _enableOdrMakerName3 = "";

        /// <summary>�����\���[�J�[���̂S</summary>
        private string _enableOdrMakerName4 = "";

        /// <summary>�����\���[�J�[���̂T</summary>
        private string _enableOdrMakerName5 = "";

        /// <summary>�����\���[�J�[���̂U</summary>
        private string _enableOdrMakerName6 = "";

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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^�v�㎞�̎d����R�[�h</value>
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
        /// <summary>UOE�h�c�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�h�c�ԍ��v���p�e�B</br>
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
        /// <summary>�i�Ԉ󎚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԉ󎚋敪�v���p�e�B</br>
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

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>���O�C���^�C���A�E�g�v���p�e�B</summary>
        /// <value>�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���^�C���A�E�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEOrderUrl
        {
            get { return _uOEOrderUrl; }
            set { _uOEOrderUrl = value; }
        }

        /// public propaty name  :  UOEStockCheckUrl
        /// <summary>UOE�݌Ɋm�FURL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌Ɋm�FURL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEStockCheckUrl
        {
            get { return _uOEStockCheckUrl; }
            set { _uOEStockCheckUrl = value; }
        }

        /// public propaty name  :  UOEForcedTermUrl
        /// <summary>UOE�����I��URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����I��URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEForcedTermUrl
        {
            get { return _uOEForcedTermUrl; }
            set { _uOEForcedTermUrl = value; }
        }

        /// public propaty name  :  UOELoginUrl
        /// <summary>UOE���O�C��URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���O�C��URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOELoginUrl
        {
            get { return _uOELoginUrl; }
            set { _uOELoginUrl = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// <value>0:�������� 1:�݌Ɋm�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EPartsPassWord
        {
            get { return _ePartsPassWord; }
            set { _ePartsPassWord = value; }
        }

        /// public propaty name  :  UOEShipSectNm
        /// <summary>UOE�o�ɋ��_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�o�ɋ��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEShipSectNm
        {
            get { return _uOEShipSectNm; }
            set { _uOEShipSectNm = value; }
        }

        /// public propaty name  :  UOESalSectNm
        /// <summary>UOE���㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESalSectNm
        {
            get { return _uOESalSectNm; }
            set { _uOESalSectNm = value; }
        }

        /// public propaty name  :  UOEReservSectNm
        /// <summary>UOE�w�苒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEReservSectNm
        {
            get { return _uOEReservSectNm; }
            set { _uOEReservSectNm = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  EnableOdrMakerName1
        /// <summary>�����\���[�J�[���̂P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[���̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnableOdrMakerName1
        {
            get { return _enableOdrMakerName1; }
            set { _enableOdrMakerName1 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName2
        /// <summary>�����\���[�J�[���̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[���̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnableOdrMakerName2
        {
            get { return _enableOdrMakerName2; }
            set { _enableOdrMakerName2 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName3
        /// <summary>�����\���[�J�[���̂R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[���̂R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnableOdrMakerName3
        {
            get { return _enableOdrMakerName3; }
            set { _enableOdrMakerName3 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName4
        /// <summary>�����\���[�J�[���̂S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[���̂S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnableOdrMakerName4
        {
            get { return _enableOdrMakerName4; }
            set { _enableOdrMakerName4 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName5
        /// <summary>�����\���[�J�[���̂T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[���̂T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnableOdrMakerName5
        {
            get { return _enableOdrMakerName5; }
            set { _enableOdrMakerName5 = value; }
        }

        /// public propaty name  :  EnableOdrMakerName6
        /// <summary>�����\���[�J�[���̂U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���[�J�[���̂U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnableOdrMakerName6
        {
            get { return _enableOdrMakerName6; }
            set { _enableOdrMakerName6 = value; }
        }

        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  BLMngUserCode
        /// <summary>BL�Ǘ����[�U�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�Ǘ����[�U�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLMngUserCode
        {
            get { return _bLMngUserCode; }
            set { _bLMngUserCode = value; }
        }
        // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// UOE�����惏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UOESupplierWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplierWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESupplierWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>UOESupplierWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   UOESupplierWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class UOESupplierWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplierWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOESupplierWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOESupplierWork || graph is ArrayList || graph is UOESupplierWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UOESupplierWork).FullName));

            if (graph != null && graph is UOESupplierWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOESupplierWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOESupplierWork[])graph).Length;
            }
            else if (graph is UOESupplierWork)
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
            //UOE������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE�����於��
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d�b�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //TelNo
            //UOE�[���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOETerminalCd
            //UOE�z�X�g�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEHostCode
            //UOE�ڑ��p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEConnectPassword
            //UOE�ڑ����[�UID
            serInfo.MemberInfo.Add(typeof(string)); //UOEConnectUserId
            //UOE�h�c�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //UOEIDNum
            //�ʐM�A�Z���u��ID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId
            //�ڑ��o�[�W�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ConnectVersionDiv
            //UOE�o�ɋ��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEShipSectCd
            //UOE���㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOESalSectCd
            //UOE�w�苒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEReservSectCd
            //��M��
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveCondition
            //��֕i�ԋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstPartsNoDiv
            //�i�Ԉ󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNoPrtCd
            //�艿�g�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceUseDiv
            //�d���f�[�^��M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipDtRecvDiv
            //�`�F�b�N�R�[�h�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CheckCodeDiv
            //�Ɩ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessCode
            //UOE�w�苒�_
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSection
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //UOE�[�i�敪
            serInfo.MemberInfo.Add(typeof(string)); //UOEDeliGoodsDiv
            //BO�敪
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //UOE�������[�g
            serInfo.MemberInfo.Add(typeof(string)); //UOEOrderRate
            //�����\���[�J�[�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd1
            //�����\���[�J�[�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd2
            //�����\���[�J�[�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd3
            //�����\���[�J�[�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd4
            //�����\���[�J�[�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd5
            //�����\���[�J�[�R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //EnableOdrMakerCd6
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            //�����i�ԃn�C�t���敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd1
            //�����i�ԃn�C�t���敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd2
            //�����i�ԃn�C�t���敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd3
            //�����i�ԃn�C�t���敪�S
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd4
            //�����i�ԃn�C�t���敪�T
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd5
            //�����i�ԃn�C�t���敪�U
            serInfo.MemberInfo.Add(typeof(Int32)); //OdrPrtsNoHyphenCd6
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            //�@��ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //instrumentNo
            //UOE�e�X�g���[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOETestMode
            //UOE�A�C�e���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEItemCd
            //�z���_�S�����_
            serInfo.MemberInfo.Add(typeof(string)); //HondaSectionCode
            //�񓚕ۑ��t�H���_
            serInfo.MemberInfo.Add(typeof(string)); //AnswerSaveFolder
            //�}�c�_�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MazdaSectionCode
            //�ً}�敪
            serInfo.MemberInfo.Add(typeof(string)); //EmergencyDiv
            //������z�敪�i�_�C�n�c�j
            serInfo.MemberInfo.Add(typeof(Int32)); //DaihatsuOrdreDiv
            //���O�C���^�C���A�E�g
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //UOE����URL
            serInfo.MemberInfo.Add(typeof(string)); //UOEOrderUrl
            //UOE�݌Ɋm�FURL
            serInfo.MemberInfo.Add(typeof(string)); //UOEStockCheckUrl
            //UOE�����I��URL
            serInfo.MemberInfo.Add(typeof(string)); //UOEForcedTermUrl
            //UOE���O�C��URL
            serInfo.MemberInfo.Add(typeof(string)); //UOELoginUrl
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //e-Parts���[�UID
            serInfo.MemberInfo.Add(typeof(string)); //EPartsUserId
            //e-Parts�p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //EPartsPassWord
            //UOE�o�ɋ��_����
            serInfo.MemberInfo.Add(typeof(string)); //UOEShipSectNm
            //UOE���㋒�_����
            serInfo.MemberInfo.Add(typeof(string)); //UOESalSectNm
            //UOE�w�苒�_����
            serInfo.MemberInfo.Add(typeof(string)); //UOEReservSectNm
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //�����\���[�J�[���̂P
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName1
            //�����\���[�J�[���̂Q
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName2
            //�����\���[�J�[���̂R
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName3
            //�����\���[�J�[���̂S
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName4
            //�����\���[�J�[���̂T
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName5
            //�����\���[�J�[���̂U
            serInfo.MemberInfo.Add(typeof(string)); //EnableOdrMakerName6
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            //BL�Ǘ����[�U�[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BLMngUserCode
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is UOESupplierWork)
            {
                UOESupplierWork temp = (UOESupplierWork)graph;

                SetUOESupplierWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOESupplierWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOESupplierWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOESupplierWork temp in lst)
                {
                    SetUOESupplierWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOESupplierWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 68;// DEL 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
        // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
        //private const int currentMemberCount = 74;// ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
        private const int currentMemberCount = 75;
        // 2012/09/10 UPD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<
        /// <summary>
        ///  UOESupplierWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplierWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetUOESupplierWork(System.IO.BinaryWriter writer, UOESupplierWork temp)
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
            //UOE������R�[�h
            writer.Write(temp.UOESupplierCd);
            //UOE�����於��
            writer.Write(temp.UOESupplierName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d�b�ԍ�
            writer.Write(temp.TelNo);
            //UOE�[���R�[�h
            writer.Write(temp.UOETerminalCd);
            //UOE�z�X�g�R�[�h
            writer.Write(temp.UOEHostCode);
            //UOE�ڑ��p�X���[�h
            writer.Write(temp.UOEConnectPassword);
            //UOE�ڑ����[�UID
            writer.Write(temp.UOEConnectUserId);
            //UOE�h�c�ԍ�
            writer.Write(temp.UOEIDNum);
            //�ʐM�A�Z���u��ID
            writer.Write(temp.CommAssemblyId);
            //�ڑ��o�[�W�����敪
            writer.Write(temp.ConnectVersionDiv);
            //UOE�o�ɋ��_�R�[�h
            writer.Write(temp.UOEShipSectCd);
            //UOE���㋒�_�R�[�h
            writer.Write(temp.UOESalSectCd);
            //UOE�w�苒�_�R�[�h
            writer.Write(temp.UOEReservSectCd);
            //��M��
            writer.Write(temp.ReceiveCondition);
            //��֕i�ԋ敪
            writer.Write(temp.SubstPartsNoDiv);
            //�i�Ԉ󎚋敪
            writer.Write(temp.PartsNoPrtCd);
            //�艿�g�p�敪
            writer.Write(temp.ListPriceUseDiv);
            //�d���f�[�^��M�敪
            writer.Write(temp.StockSlipDtRecvDiv);
            //�`�F�b�N�R�[�h�敪
            writer.Write(temp.CheckCodeDiv);
            //�Ɩ��敪
            writer.Write(temp.BusinessCode);
            //UOE�w�苒�_
            writer.Write(temp.UOEResvdSection);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //UOE�[�i�敪
            writer.Write(temp.UOEDeliGoodsDiv);
            //BO�敪
            writer.Write(temp.BoCode);
            //UOE�������[�g
            writer.Write(temp.UOEOrderRate);
            //�����\���[�J�[�R�[�h�P
            writer.Write(temp.EnableOdrMakerCd1);
            //�����\���[�J�[�R�[�h�Q
            writer.Write(temp.EnableOdrMakerCd2);
            //�����\���[�J�[�R�[�h�R
            writer.Write(temp.EnableOdrMakerCd3);
            //�����\���[�J�[�R�[�h�S
            writer.Write(temp.EnableOdrMakerCd4);
            //�����\���[�J�[�R�[�h�T
            writer.Write(temp.EnableOdrMakerCd5);
            //�����\���[�J�[�R�[�h�U
            writer.Write(temp.EnableOdrMakerCd6);
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            //�����i�ԃn�C�t���敪�P
            writer.Write(temp.OdrPrtsNoHyphenCd1);
            //�����i�ԃn�C�t���敪�Q
            writer.Write(temp.OdrPrtsNoHyphenCd2);
            //�����i�ԃn�C�t���敪�R
            writer.Write(temp.OdrPrtsNoHyphenCd3);
            //�����i�ԃn�C�t���敪�S
            writer.Write(temp.OdrPrtsNoHyphenCd4);
            //�����i�ԃn�C�t���敪�T
            writer.Write(temp.OdrPrtsNoHyphenCd5);
            //�����i�ԃn�C�t���敪�U
            writer.Write(temp.OdrPrtsNoHyphenCd6);
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            //�@��ԍ�
            writer.Write(temp.instrumentNo);
            //UOE�e�X�g���[�h
            writer.Write(temp.UOETestMode);
            //UOE�A�C�e���R�[�h
            writer.Write(temp.UOEItemCd);
            //�z���_�S�����_
            writer.Write(temp.HondaSectionCode);
            //�񓚕ۑ��t�H���_
            writer.Write(temp.AnswerSaveFolder);
            //�}�c�_�����_�R�[�h
            writer.Write(temp.MazdaSectionCode);
            //�ً}�敪
            writer.Write(temp.EmergencyDiv);
            //������z�敪�i�_�C�n�c�j
            writer.Write(temp.DaihatsuOrdreDiv);
            //���O�C���^�C���A�E�g
            writer.Write(temp.LoginTimeoutVal);
            //UOE����URL
            writer.Write(temp.UOEOrderUrl);
            //UOE�݌Ɋm�FURL
            writer.Write(temp.UOEStockCheckUrl);
            //UOE�����I��URL
            writer.Write(temp.UOEForcedTermUrl);
            //UOE���O�C��URL
            writer.Write(temp.UOELoginUrl);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //e-Parts���[�UID
            writer.Write(temp.EPartsUserId);
            //e-Parts�p�X���[�h
            writer.Write(temp.EPartsPassWord);
            //UOE�o�ɋ��_����
            writer.Write(temp.UOEShipSectNm);
            //UOE���㋒�_����
            writer.Write(temp.UOESalSectNm);
            //UOE�w�苒�_����
            writer.Write(temp.UOEReservSectNm);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //�����\���[�J�[���̂P
            writer.Write(temp.EnableOdrMakerName1);
            //�����\���[�J�[���̂Q
            writer.Write(temp.EnableOdrMakerName2);
            //�����\���[�J�[���̂R
            writer.Write(temp.EnableOdrMakerName3);
            //�����\���[�J�[���̂S
            writer.Write(temp.EnableOdrMakerName4);
            //�����\���[�J�[���̂T
            writer.Write(temp.EnableOdrMakerName5);
            //�����\���[�J�[���̂U
            writer.Write(temp.EnableOdrMakerName6);
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            //BL�Ǘ����[�U�[�R�[�h
            writer.Write(temp.BLMngUserCode);
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

        }

        /// <summary>
        ///  UOESupplierWork�C���X�^���X�擾
        /// </summary>
        /// <returns>UOESupplierWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplierWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private UOESupplierWork GetUOESupplierWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            UOESupplierWork temp = new UOESupplierWork();

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
            //UOE������R�[�h
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE�����於��
            temp.UOESupplierName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d�b�ԍ�
            temp.TelNo = reader.ReadString();
            //UOE�[���R�[�h
            temp.UOETerminalCd = reader.ReadString();
            //UOE�z�X�g�R�[�h
            temp.UOEHostCode = reader.ReadString();
            //UOE�ڑ��p�X���[�h
            temp.UOEConnectPassword = reader.ReadString();
            //UOE�ڑ����[�UID
            temp.UOEConnectUserId = reader.ReadString();
            //UOE�h�c�ԍ�
            temp.UOEIDNum = reader.ReadString();
            //�ʐM�A�Z���u��ID
            temp.CommAssemblyId = reader.ReadString();
            //�ڑ��o�[�W�����敪
            temp.ConnectVersionDiv = reader.ReadInt32();
            //UOE�o�ɋ��_�R�[�h
            temp.UOEShipSectCd = reader.ReadString();
            //UOE���㋒�_�R�[�h
            temp.UOESalSectCd = reader.ReadString();
            //UOE�w�苒�_�R�[�h
            temp.UOEReservSectCd = reader.ReadString();
            //��M��
            temp.ReceiveCondition = reader.ReadInt32();
            //��֕i�ԋ敪
            temp.SubstPartsNoDiv = reader.ReadInt32();
            //�i�Ԉ󎚋敪
            temp.PartsNoPrtCd = reader.ReadInt32();
            //�艿�g�p�敪
            temp.ListPriceUseDiv = reader.ReadInt32();
            //�d���f�[�^��M�敪
            temp.StockSlipDtRecvDiv = reader.ReadInt32();
            //�`�F�b�N�R�[�h�敪
            temp.CheckCodeDiv = reader.ReadInt32();
            //�Ɩ��敪
            temp.BusinessCode = reader.ReadInt32();
            //UOE�w�苒�_
            temp.UOEResvdSection = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //UOE�[�i�敪
            temp.UOEDeliGoodsDiv = reader.ReadString();
            //BO�敪
            temp.BoCode = reader.ReadString();
            //UOE�������[�g
            temp.UOEOrderRate = reader.ReadString();
            //�����\���[�J�[�R�[�h�P
            temp.EnableOdrMakerCd1 = reader.ReadInt32();
            //�����\���[�J�[�R�[�h�Q
            temp.EnableOdrMakerCd2 = reader.ReadInt32();
            //�����\���[�J�[�R�[�h�R
            temp.EnableOdrMakerCd3 = reader.ReadInt32();
            //�����\���[�J�[�R�[�h�S
            temp.EnableOdrMakerCd4 = reader.ReadInt32();
            //�����\���[�J�[�R�[�h�T
            temp.EnableOdrMakerCd5 = reader.ReadInt32();
            //�����\���[�J�[�R�[�h�U
            temp.EnableOdrMakerCd6 = reader.ReadInt32();
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            //�����i�ԃn�C�t���敪�P
            temp.OdrPrtsNoHyphenCd1 = reader.ReadInt32();
            //�����i�ԃn�C�t���敪�Q
            temp.OdrPrtsNoHyphenCd2 = reader.ReadInt32();
            //�����i�ԃn�C�t���敪�R
            temp.OdrPrtsNoHyphenCd3 = reader.ReadInt32();
            //�����i�ԃn�C�t���敪�S
            temp.OdrPrtsNoHyphenCd4 = reader.ReadInt32();
            //�����i�ԃn�C�t���敪�T
            temp.OdrPrtsNoHyphenCd5 = reader.ReadInt32();
            //�����i�ԃn�C�t���敪�U
            temp.OdrPrtsNoHyphenCd6 = reader.ReadInt32();
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            //�@��ԍ�
            temp.instrumentNo = reader.ReadString();
            //UOE�e�X�g���[�h
            temp.UOETestMode = reader.ReadString();
            //UOE�A�C�e���R�[�h
            temp.UOEItemCd = reader.ReadString();
            //�z���_�S�����_
            temp.HondaSectionCode = reader.ReadString();
            //�񓚕ۑ��t�H���_
            temp.AnswerSaveFolder = reader.ReadString();
            //�}�c�_�����_�R�[�h
            temp.MazdaSectionCode = reader.ReadString();
            //�ً}�敪
            temp.EmergencyDiv = reader.ReadString();
            //������z�敪�i�_�C�n�c�j
            temp.DaihatsuOrdreDiv = reader.ReadInt32();
            //���O�C���^�C���A�E�g
            temp.LoginTimeoutVal = reader.ReadInt32();
            //UOE����URL
            temp.UOEOrderUrl = reader.ReadString();
            //UOE�݌Ɋm�FURL
            temp.UOEStockCheckUrl = reader.ReadString();
            //UOE�����I��URL
            temp.UOEForcedTermUrl = reader.ReadString();
            //UOE���O�C��URL
            temp.UOELoginUrl = reader.ReadString();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //e-Parts���[�UID
            temp.EPartsUserId = reader.ReadString();
            //e-Parts�p�X���[�h
            temp.EPartsPassWord = reader.ReadString();
            //UOE�o�ɋ��_����
            temp.UOEShipSectNm = reader.ReadString();
            //UOE���㋒�_����
            temp.UOESalSectNm = reader.ReadString();
            //UOE�w�苒�_����
            temp.UOEReservSectNm = reader.ReadString();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //�����\���[�J�[���̂P
            temp.EnableOdrMakerName1 = reader.ReadString();
            //�����\���[�J�[���̂Q
            temp.EnableOdrMakerName2 = reader.ReadString();
            //�����\���[�J�[���̂R
            temp.EnableOdrMakerName3 = reader.ReadString();
            //�����\���[�J�[���̂S
            temp.EnableOdrMakerName4 = reader.ReadString();
            //�����\���[�J�[���̂T
            temp.EnableOdrMakerName5 = reader.ReadString();
            //�����\���[�J�[���̂U
            temp.EnableOdrMakerName6 = reader.ReadString();
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            //BL�Ǘ����[�U�[�R�[�h
            temp.BLMngUserCode = reader.ReadString();
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<


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
        /// <returns>UOESupplierWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESupplierWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOESupplierWork temp = GetUOESupplierWork(reader, serInfo);
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
                    retValue = (UOESupplierWork[])lst.ToArray(typeof(UOESupplierWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
