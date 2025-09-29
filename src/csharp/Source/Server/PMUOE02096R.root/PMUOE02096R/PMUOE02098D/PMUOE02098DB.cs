using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOEAnswerLedgerResultWork
    /// <summary>
    ///                      UOE�񓚕\��(�����^�C�v)���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE�񓚕\��(�����^�C�v)���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOEAnswerLedgerResultWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

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

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE�����ԍ�</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>UOE�����s�ԍ�</summary>
        private Int32 _uOESalesOrderRowNo;

        /// <summary>���M�[���ԍ�</summary>
        /// <remarks>���M�������s�[���ԍ�</remarks>
        private Int32 _sendTerminalNo;

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>�ʐM�A�Z���u��ID</summary>
        private string _commAssemblyId = "";

        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>�I�����C���s�ԍ�</summary>
        private Int32 _onlineRowNo;

        /// <summary>������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>�f�[�^�X�V����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _dataUpdateDateTime;

        /// <summary>UOE���</summary>
        /// <remarks>0:UOE 1:�����d����M</remarks>
        private Int32 _uOEKind;

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�[���ԍ�</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>BO�敪</summary>
        private string _boCode = "";

        /// <summary>�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>�t�H���[�[�i�敪</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>�t�H���[�[�i�敪����</summary>
        private string _followDeliGoodsDivNm = "";

        /// <summary>UOE�w�苒�_</summary>
        private string _uOEResvdSection = "";

        /// <summary>UOE�w�苒�_����</summary>
        private string _uOEResvdSectionNm = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        /// <remarks>�˗��Җ���</remarks>
        private string _employeeName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�󒍐���</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>�艿�i�����j</summary>
        /// <remarks>�K�p�i�艿�j</remarks>
        private Double _listPrice;

        /// <summary>�����P��</summary>
        /// <remarks>�d�؂艿�i</remarks>
        private Double _salesUnitCost;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>��M���t</summary>
        private DateTime _receiveDate;

        /// <summary>��M����</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _receiveTime;

        /// <summary>�񓚃��[�J�[�R�[�h</summary>
        private Int32 _answerMakerCd;

        /// <summary>�񓚕i��</summary>
        private string _answerPartsNo = "";

        /// <summary>�񓚕i��</summary>
        private string _answerPartsName = "";

        /// <summary>��֕i��</summary>
        private string _substPartsNo = "";

        /// <summary>UOE���_�o�ɐ�</summary>
        private Int32 _uOESectOutGoodsCnt;

        /// <summary>BO�o�ɐ�1</summary>
        /// <remarks>�T�u�{���t�H���[��</remarks>
        private Int32 _bOShipmentCnt1;

        /// <summary>BO�o�ɐ�2</summary>
        /// <remarks>�{���t�H���[��</remarks>
        private Int32 _bOShipmentCnt2;

        /// <summary>BO�o�ɐ�3</summary>
        /// <remarks>���[�g�t�H���[��</remarks>
        private Int32 _bOShipmentCnt3;

        /// <summary>���[�J�[�t�H���[��</summary>
        private Int32 _makerFollowCnt;

        /// <summary>���o�ɐ�</summary>
        private Int32 _nonShipmentCnt;

        /// <summary>UOE���_�݌ɐ�</summary>
        private Int32 _uOESectStockCnt;

        /// <summary>BO�݌ɐ�1</summary>
        /// <remarks>�T�u�{���݌�</remarks>
        private Int32 _bOStockCount1;

        /// <summary>BO�݌ɐ�2</summary>
        /// <remarks>�{���݌�</remarks>
        private Int32 _bOStockCount2;

        /// <summary>BO�݌ɐ�3</summary>
        /// <remarks>���[�g�݌�</remarks>
        private Int32 _bOStockCount3;

        /// <summary>UOE���_�`�[�ԍ�</summary>
        private string _uOESectionSlipNo = "";

        /// <summary>BO�`�[�ԍ��P</summary>
        /// <remarks>�T�u�{���t�H���[�`�[��</remarks>
        private string _bOSlipNo1 = "";

        /// <summary>BO�`�[�ԍ��Q</summary>
        /// <remarks>�{���t�H���[�`�[��</remarks>
        private string _bOSlipNo2 = "";

        /// <summary>BO�`�[�ԍ��R</summary>
        /// <remarks>���[�g�t�H���[�`�[��</remarks>
        private string _bOSlipNo3 = "";

        /// <summary>EO������</summary>
        private Int32 _eOAlwcCount;

        /// <summary>BO�Ǘ��ԍ�</summary>
        private string _bOManagementNo = "";

        /// <summary>�񓚒艿</summary>
        private Double _answerListPrice;

        /// <summary>�񓚌����P��</summary>
        private Double _answerSalesUnitCost;

        /// <summary>UOE��փ}�[�N</summary>
        private string _uOESubstMark = "";

        /// <summary>UOE�݌Ƀ}�[�N</summary>
        private string _uOEStockMark = "";

        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";

        /// <summary>UOE�o�׋��_�R�[�h�P�i�}�c�_�j</summary>
        private string _mazdaUOEShipSectCd1 = "";

        /// <summary>UOE�o�׋��_�R�[�h�Q�i�}�c�_�j</summary>
        private string _mazdaUOEShipSectCd2 = "";

        /// <summary>UOE�o�׋��_�R�[�h�R�i�}�c�_�j</summary>
        private string _mazdaUOEShipSectCd3 = "";

        /// <summary>UOE���_�R�[�h�P�i�}�c�_�j</summary>
        private string _mazdaUOESectCd1 = "";

        /// <summary>UOE���_�R�[�h�Q�i�}�c�_�j</summary>
        private string _mazdaUOESectCd2 = "";

        /// <summary>UOE���_�R�[�h�R�i�}�c�_�j</summary>
        private string _mazdaUOESectCd3 = "";

        /// <summary>UOE���_�R�[�h�S�i�}�c�_�j</summary>
        private string _mazdaUOESectCd4 = "";

        /// <summary>UOE���_�R�[�h�T�i�}�c�_�j</summary>
        private string _mazdaUOESectCd5 = "";

        /// <summary>UOE���_�R�[�h�U�i�}�c�_�j</summary>
        private string _mazdaUOESectCd6 = "";

        /// <summary>UOE���_�R�[�h�V�i�}�c�_�j</summary>
        private string _mazdaUOESectCd7 = "";

        /// <summary>UOE�݌ɐ��P�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt1;

        /// <summary>UOE�݌ɐ��Q�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt2;

        /// <summary>UOE�݌ɐ��R�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt3;

        /// <summary>UOE�݌ɐ��S�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt4;

        /// <summary>UOE�݌ɐ��T�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt5;

        /// <summary>UOE�݌ɐ��U�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt6;

        /// <summary>UOE�݌ɐ��V�i�}�c�_�j</summary>
        private Int32 _mazdaUOEStockCnt7;

        /// <summary>UOE���R�[�h</summary>
        private string _uOEDistributionCd = "";

        /// <summary>UOE���R�[�h</summary>
        private string _uOEOtherCd = "";

        /// <summary>UOE�g�l�R�[�h</summary>
        private string _uOEHMCd = "";

        /// <summary>�a�n��</summary>
        private Int32 _bOCount;

        /// <summary>UOE�}�[�N�R�[�h</summary>
        private string _uOEMarkCode = "";

        /// <summary>�o�׌�</summary>
        private string _sourceShipment = "";

        /// <summary>�A�C�e���R�[�h</summary>
        private string _itemCode = "";

        /// <summary>UOE�`�F�b�N�R�[�h</summary>
        private string _uOECheckCode = "";

        /// <summary>�w�b�h�G���[���b�Z�[�W</summary>
        private string _headErrorMassage = "";

        /// <summary>���C���G���[���b�Z�[�W</summary>
        private string _lineErrorMassage = "";


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

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

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UOESalesOrderRowNo
        /// <summary>UOE�����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderRowNo
        {
            get { return _uOESalesOrderRowNo; }
            set { _uOESalesOrderRowNo = value; }
        }

        /// public propaty name  :  SendTerminalNo
        /// <summary>���M�[���ԍ��v���p�e�B</summary>
        /// <value>���M�������s�[���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendTerminalNo
        {
            get { return _sendTerminalNo; }
            set { _sendTerminalNo = value; }
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

        /// public propaty name  :  OnlineNo
        /// <summary>�I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>�I�����C���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
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

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>�f�[�^�X�V�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }

        /// public propaty name  :  UOEKind
        /// <summary>UOE��ʃv���p�e�B</summary>
        /// <value>0:UOE 1:�����d����M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOEKind
        {
            get { return _uOEKind; }
            set { _uOEKind = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�[���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
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

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>�t�H���[�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>�t�H���[�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
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

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>UOE�w�苒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
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

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// <value>�˗��Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// <value>�K�p�i�艿�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�d�؂艿�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  ReceiveDate
        /// <summary>��M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }

        /// public propaty name  :  ReceiveTime
        /// <summary>��M�����v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
        }

        /// public propaty name  :  AnswerMakerCd
        /// <summary>�񓚃��[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚃��[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerMakerCd
        {
            get { return _answerMakerCd; }
            set { _answerMakerCd = value; }
        }

        /// public propaty name  :  AnswerPartsNo
        /// <summary>�񓚕i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerPartsNo
        {
            get { return _answerPartsNo; }
            set { _answerPartsNo = value; }
        }

        /// public propaty name  :  AnswerPartsName
        /// <summary>�񓚕i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerPartsName
        {
            get { return _answerPartsName; }
            set { _answerPartsName = value; }
        }

        /// public propaty name  :  SubstPartsNo
        /// <summary>��֕i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֕i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubstPartsNo
        {
            get { return _substPartsNo; }
            set { _substPartsNo = value; }
        }

        /// public propaty name  :  UOESectOutGoodsCnt
        /// <summary>UOE���_�o�ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�o�ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectOutGoodsCnt
        {
            get { return _uOESectOutGoodsCnt; }
            set { _uOESectOutGoodsCnt = value; }
        }

        /// public propaty name  :  BOShipmentCnt1
        /// <summary>BO�o�ɐ�1�v���p�e�B</summary>
        /// <value>�T�u�{���t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt1
        {
            get { return _bOShipmentCnt1; }
            set { _bOShipmentCnt1 = value; }
        }

        /// public propaty name  :  BOShipmentCnt2
        /// <summary>BO�o�ɐ�2�v���p�e�B</summary>
        /// <value>�{���t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt2
        {
            get { return _bOShipmentCnt2; }
            set { _bOShipmentCnt2 = value; }
        }

        /// public propaty name  :  BOShipmentCnt3
        /// <summary>BO�o�ɐ�3�v���p�e�B</summary>
        /// <value>���[�g�t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt3
        {
            get { return _bOShipmentCnt3; }
            set { _bOShipmentCnt3 = value; }
        }

        /// public propaty name  :  MakerFollowCnt
        /// <summary>���[�J�[�t�H���[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�t�H���[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerFollowCnt
        {
            get { return _makerFollowCnt; }
            set { _makerFollowCnt = value; }
        }

        /// public propaty name  :  NonShipmentCnt
        /// <summary>���o�ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NonShipmentCnt
        {
            get { return _nonShipmentCnt; }
            set { _nonShipmentCnt = value; }
        }

        /// public propaty name  :  UOESectStockCnt
        /// <summary>UOE���_�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectStockCnt
        {
            get { return _uOESectStockCnt; }
            set { _uOESectStockCnt = value; }
        }

        /// public propaty name  :  BOStockCount1
        /// <summary>BO�݌ɐ�1�v���p�e�B</summary>
        /// <value>�T�u�{���݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�݌ɐ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOStockCount1
        {
            get { return _bOStockCount1; }
            set { _bOStockCount1 = value; }
        }

        /// public propaty name  :  BOStockCount2
        /// <summary>BO�݌ɐ�2�v���p�e�B</summary>
        /// <value>�{���݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�݌ɐ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOStockCount2
        {
            get { return _bOStockCount2; }
            set { _bOStockCount2 = value; }
        }

        /// public propaty name  :  BOStockCount3
        /// <summary>BO�݌ɐ�3�v���p�e�B</summary>
        /// <value>���[�g�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�݌ɐ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOStockCount3
        {
            get { return _bOStockCount3; }
            set { _bOStockCount3 = value; }
        }

        /// public propaty name  :  UOESectionSlipNo
        /// <summary>UOE���_�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionSlipNo
        {
            get { return _uOESectionSlipNo; }
            set { _uOESectionSlipNo = value; }
        }

        /// public propaty name  :  BOSlipNo1
        /// <summary>BO�`�[�ԍ��P�v���p�e�B</summary>
        /// <value>�T�u�{���t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo1
        {
            get { return _bOSlipNo1; }
            set { _bOSlipNo1 = value; }
        }

        /// public propaty name  :  BOSlipNo2
        /// <summary>BO�`�[�ԍ��Q�v���p�e�B</summary>
        /// <value>�{���t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo2
        {
            get { return _bOSlipNo2; }
            set { _bOSlipNo2 = value; }
        }

        /// public propaty name  :  BOSlipNo3
        /// <summary>BO�`�[�ԍ��R�v���p�e�B</summary>
        /// <value>���[�g�t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo3
        {
            get { return _bOSlipNo3; }
            set { _bOSlipNo3 = value; }
        }

        /// public propaty name  :  EOAlwcCount
        /// <summary>EO�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   EO�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EOAlwcCount
        {
            get { return _eOAlwcCount; }
            set { _eOAlwcCount = value; }
        }

        /// public propaty name  :  BOManagementNo
        /// <summary>BO�Ǘ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOManagementNo
        {
            get { return _bOManagementNo; }
            set { _bOManagementNo = value; }
        }

        /// public propaty name  :  AnswerListPrice
        /// <summary>�񓚒艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerListPrice
        {
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>�񓚌����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚌����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerSalesUnitCost
        {
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }

        /// public propaty name  :  UOESubstMark
        /// <summary>UOE��փ}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE��փ}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESubstMark
        {
            get { return _uOESubstMark; }
            set { _uOESubstMark = value; }
        }

        /// public propaty name  :  UOEStockMark
        /// <summary>UOE�݌Ƀ}�[�N�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌Ƀ}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEStockMark
        {
            get { return _uOEStockMark; }
            set { _uOEStockMark = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  MazdaUOEShipSectCd1
        /// <summary>UOE�o�׋��_�R�[�h�P�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�o�׋��_�R�[�h�P�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOEShipSectCd1
        {
            get { return _mazdaUOEShipSectCd1; }
            set { _mazdaUOEShipSectCd1 = value; }
        }

        /// public propaty name  :  MazdaUOEShipSectCd2
        /// <summary>UOE�o�׋��_�R�[�h�Q�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�o�׋��_�R�[�h�Q�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOEShipSectCd2
        {
            get { return _mazdaUOEShipSectCd2; }
            set { _mazdaUOEShipSectCd2 = value; }
        }

        /// public propaty name  :  MazdaUOEShipSectCd3
        /// <summary>UOE�o�׋��_�R�[�h�R�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�o�׋��_�R�[�h�R�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOEShipSectCd3
        {
            get { return _mazdaUOEShipSectCd3; }
            set { _mazdaUOEShipSectCd3 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd1
        /// <summary>UOE���_�R�[�h�P�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�P�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd1
        {
            get { return _mazdaUOESectCd1; }
            set { _mazdaUOESectCd1 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd2
        /// <summary>UOE���_�R�[�h�Q�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�Q�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd2
        {
            get { return _mazdaUOESectCd2; }
            set { _mazdaUOESectCd2 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd3
        /// <summary>UOE���_�R�[�h�R�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�R�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd3
        {
            get { return _mazdaUOESectCd3; }
            set { _mazdaUOESectCd3 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd4
        /// <summary>UOE���_�R�[�h�S�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�S�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd4
        {
            get { return _mazdaUOESectCd4; }
            set { _mazdaUOESectCd4 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd5
        /// <summary>UOE���_�R�[�h�T�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�T�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd5
        {
            get { return _mazdaUOESectCd5; }
            set { _mazdaUOESectCd5 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd6
        /// <summary>UOE���_�R�[�h�U�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�U�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd6
        {
            get { return _mazdaUOESectCd6; }
            set { _mazdaUOESectCd6 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd7
        /// <summary>UOE���_�R�[�h�V�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�V�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MazdaUOESectCd7
        {
            get { return _mazdaUOESectCd7; }
            set { _mazdaUOESectCd7 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt1
        /// <summary>UOE�݌ɐ��P�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��P�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt1
        {
            get { return _mazdaUOEStockCnt1; }
            set { _mazdaUOEStockCnt1 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt2
        /// <summary>UOE�݌ɐ��Q�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��Q�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt2
        {
            get { return _mazdaUOEStockCnt2; }
            set { _mazdaUOEStockCnt2 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt3
        /// <summary>UOE�݌ɐ��R�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��R�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt3
        {
            get { return _mazdaUOEStockCnt3; }
            set { _mazdaUOEStockCnt3 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt4
        /// <summary>UOE�݌ɐ��S�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��S�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt4
        {
            get { return _mazdaUOEStockCnt4; }
            set { _mazdaUOEStockCnt4 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt5
        /// <summary>UOE�݌ɐ��T�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��T�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt5
        {
            get { return _mazdaUOEStockCnt5; }
            set { _mazdaUOEStockCnt5 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt6
        /// <summary>UOE�݌ɐ��U�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��U�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt6
        {
            get { return _mazdaUOEStockCnt6; }
            set { _mazdaUOEStockCnt6 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt7
        /// <summary>UOE�݌ɐ��V�i�}�c�_�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�݌ɐ��V�i�}�c�_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt7
        {
            get { return _mazdaUOEStockCnt7; }
            set { _mazdaUOEStockCnt7 = value; }
        }

        /// public propaty name  :  UOEDistributionCd
        /// <summary>UOE���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDistributionCd
        {
            get { return _uOEDistributionCd; }
            set { _uOEDistributionCd = value; }
        }

        /// public propaty name  :  UOEOtherCd
        /// <summary>UOE���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEOtherCd
        {
            get { return _uOEOtherCd; }
            set { _uOEOtherCd = value; }
        }

        /// public propaty name  :  UOEHMCd
        /// <summary>UOE�g�l�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�g�l�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEHMCd
        {
            get { return _uOEHMCd; }
            set { _uOEHMCd = value; }
        }

        /// public propaty name  :  BOCount
        /// <summary>�a�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOCount
        {
            get { return _bOCount; }
            set { _bOCount = value; }
        }

        /// public propaty name  :  UOEMarkCode
        /// <summary>UOE�}�[�N�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�}�[�N�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEMarkCode
        {
            get { return _uOEMarkCode; }
            set { _uOEMarkCode = value; }
        }

        /// public propaty name  :  SourceShipment
        /// <summary>�o�׌��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SourceShipment
        {
            get { return _sourceShipment; }
            set { _sourceShipment = value; }
        }

        /// public propaty name  :  ItemCode
        /// <summary>�A�C�e���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�C�e���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        /// public propaty name  :  UOECheckCode
        /// <summary>UOE�`�F�b�N�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�`�F�b�N�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOECheckCode
        {
            get { return _uOECheckCode; }
            set { _uOECheckCode = value; }
        }

        /// public propaty name  :  HeadErrorMassage
        /// <summary>�w�b�h�G���[���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�b�h�G���[���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HeadErrorMassage
        {
            get { return _headErrorMassage; }
            set { _headErrorMassage = value; }
        }

        /// public propaty name  :  LineErrorMassage
        /// <summary>���C���G���[���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���C���G���[���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LineErrorMassage
        {
            get { return _lineErrorMassage; }
            set { _lineErrorMassage = value; }
        }


        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UOEAnswerLedgerResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>UOEAnswerLedgerResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class UOEAnswerLedgerResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOEAnswerLedgerResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOEAnswerLedgerResultWork || graph is ArrayList || graph is UOEAnswerLedgerResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UOEAnswerLedgerResultWork).FullName));

            if (graph != null && graph is UOEAnswerLedgerResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOEAnswerLedgerResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOEAnswerLedgerResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOEAnswerLedgerResultWork[])graph).Length;
            }
            else if (graph is UOEAnswerLedgerResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
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
            //�V�X�e���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd
            //UOE�����ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //UOE�����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderRowNo
            //���M�[���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SendTerminalNo
            //UOE������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE�����於��
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //�ʐM�A�Z���u��ID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId
            //�I�����C���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //�I�����C���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineRowNo
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�f�[�^�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime
            //UOE���
            serInfo.MemberInfo.Add(typeof(Int32)); //UOEKind
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //���W�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //BO�敪
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(string)); //UOEDeliGoodsDiv
            //�[�i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //DeliveredGoodsDivNm
            //�t�H���[�[�i�敪
            serInfo.MemberInfo.Add(typeof(string)); //FollowDeliGoodsDiv
            //�t�H���[�[�i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //FollowDeliGoodsDivNm
            //UOE�w�苒�_
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSection
            //UOE�w�苒�_����
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSectionNm
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //��M���t
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveDate
            //��M����
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveTime
            //�񓚃��[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerMakerCd
            //�񓚕i��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerPartsNo
            //�񓚕i��
            serInfo.MemberInfo.Add(typeof(string)); //AnswerPartsName
            //��֕i��
            serInfo.MemberInfo.Add(typeof(string)); //SubstPartsNo
            //UOE���_�o�ɐ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectOutGoodsCnt
            //BO�o�ɐ�1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt1
            //BO�o�ɐ�2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt2
            //BO�o�ɐ�3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt3
            //���[�J�[�t�H���[��
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowCnt
            //���o�ɐ�
            serInfo.MemberInfo.Add(typeof(Int32)); //NonShipmentCnt
            //UOE���_�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectStockCnt
            //BO�݌ɐ�1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOStockCount1
            //BO�݌ɐ�2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOStockCount2
            //BO�݌ɐ�3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOStockCount3
            //UOE���_�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //BO�`�[�ԍ��P
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO�`�[�ԍ��Q
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO�`�[�ԍ��R
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //EO������
            serInfo.MemberInfo.Add(typeof(Int32)); //EOAlwcCount
            //BO�Ǘ��ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //BOManagementNo
            //�񓚒艿
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerListPrice
            //�񓚌����P��
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerSalesUnitCost
            //UOE��փ}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //UOESubstMark
            //UOE�݌Ƀ}�[�N
            serInfo.MemberInfo.Add(typeof(string)); //UOEStockMark
            //�w�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //UOE�o�׋��_�R�[�h�P�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOEShipSectCd1
            //UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOEShipSectCd2
            //UOE�o�׋��_�R�[�h�R�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOEShipSectCd3
            //UOE���_�R�[�h�P�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd1
            //UOE���_�R�[�h�Q�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd2
            //UOE���_�R�[�h�R�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd3
            //UOE���_�R�[�h�S�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd4
            //UOE���_�R�[�h�T�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd5
            //UOE���_�R�[�h�U�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd6
            //UOE���_�R�[�h�V�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd7
            //UOE�݌ɐ��P�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt1
            //UOE�݌ɐ��Q�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt2
            //UOE�݌ɐ��R�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt3
            //UOE�݌ɐ��S�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt4
            //UOE�݌ɐ��T�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt5
            //UOE�݌ɐ��U�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt6
            //UOE�݌ɐ��V�i�}�c�_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt7
            //UOE���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEDistributionCd
            //UOE���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEOtherCd
            //UOE�g�l�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEHMCd
            //�a�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //BOCount
            //UOE�}�[�N�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOEMarkCode
            //�o�׌�
            serInfo.MemberInfo.Add(typeof(string)); //SourceShipment
            //�A�C�e���R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ItemCode
            //UOE�`�F�b�N�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UOECheckCode
            //�w�b�h�G���[���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //HeadErrorMassage
            //���C���G���[���b�Z�[�W
            serInfo.MemberInfo.Add(typeof(string)); //LineErrorMassage


            serInfo.Serialize(writer, serInfo);
            if (graph is UOEAnswerLedgerResultWork)
            {
                UOEAnswerLedgerResultWork temp = (UOEAnswerLedgerResultWork)graph;

                SetUOEAnswerLedgerResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOEAnswerLedgerResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOEAnswerLedgerResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOEAnswerLedgerResultWork temp in lst)
                {
                    SetUOEAnswerLedgerResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOEAnswerLedgerResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 105;

        /// <summary>
        ///  UOEAnswerLedgerResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetUOEAnswerLedgerResultWork(System.IO.BinaryWriter writer, UOEAnswerLedgerResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
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
            //�V�X�e���敪
            writer.Write(temp.SystemDivCd);
            //UOE�����ԍ�
            writer.Write(temp.UOESalesOrderNo);
            //UOE�����s�ԍ�
            writer.Write(temp.UOESalesOrderRowNo);
            //���M�[���ԍ�
            writer.Write(temp.SendTerminalNo);
            //UOE������R�[�h
            writer.Write(temp.UOESupplierCd);
            //UOE�����於��
            writer.Write(temp.UOESupplierName);
            //�ʐM�A�Z���u��ID
            writer.Write(temp.CommAssemblyId);
            //�I�����C���ԍ�
            writer.Write(temp.OnlineNo);
            //�I�����C���s�ԍ�
            writer.Write(temp.OnlineRowNo);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //�f�[�^�X�V����
            writer.Write((Int64)temp.DataUpdateDateTime.Ticks);
            //UOE���
            writer.Write(temp.UOEKind);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //���W�ԍ�
            writer.Write(temp.CashRegisterNo);
            //BO�敪
            writer.Write(temp.BoCode);
            //�[�i�敪
            writer.Write(temp.UOEDeliGoodsDiv);
            //�[�i�敪����
            writer.Write(temp.DeliveredGoodsDivNm);
            //�t�H���[�[�i�敪
            writer.Write(temp.FollowDeliGoodsDiv);
            //�t�H���[�[�i�敪����
            writer.Write(temp.FollowDeliGoodsDivNm);
            //UOE�w�苒�_
            writer.Write(temp.UOEResvdSection);
            //UOE�w�苒�_����
            writer.Write(temp.UOEResvdSectionNm);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�]�ƈ�����
            writer.Write(temp.EmployeeName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�n�C�t�������i�ԍ�
            writer.Write(temp.GoodsNoNoneHyphen);
            //���i����
            writer.Write(temp.GoodsName);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //�艿�i�����j
            writer.Write(temp.ListPrice);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //��M���t
            writer.Write((Int64)temp.ReceiveDate.Ticks);
            //��M����
            writer.Write(temp.ReceiveTime);
            //�񓚃��[�J�[�R�[�h
            writer.Write(temp.AnswerMakerCd);
            //�񓚕i��
            writer.Write(temp.AnswerPartsNo);
            //�񓚕i��
            writer.Write(temp.AnswerPartsName);
            //��֕i��
            writer.Write(temp.SubstPartsNo);
            //UOE���_�o�ɐ�
            writer.Write(temp.UOESectOutGoodsCnt);
            //BO�o�ɐ�1
            writer.Write(temp.BOShipmentCnt1);
            //BO�o�ɐ�2
            writer.Write(temp.BOShipmentCnt2);
            //BO�o�ɐ�3
            writer.Write(temp.BOShipmentCnt3);
            //���[�J�[�t�H���[��
            writer.Write(temp.MakerFollowCnt);
            //���o�ɐ�
            writer.Write(temp.NonShipmentCnt);
            //UOE���_�݌ɐ�
            writer.Write(temp.UOESectStockCnt);
            //BO�݌ɐ�1
            writer.Write(temp.BOStockCount1);
            //BO�݌ɐ�2
            writer.Write(temp.BOStockCount2);
            //BO�݌ɐ�3
            writer.Write(temp.BOStockCount3);
            //UOE���_�`�[�ԍ�
            writer.Write(temp.UOESectionSlipNo);
            //BO�`�[�ԍ��P
            writer.Write(temp.BOSlipNo1);
            //BO�`�[�ԍ��Q
            writer.Write(temp.BOSlipNo2);
            //BO�`�[�ԍ��R
            writer.Write(temp.BOSlipNo3);
            //EO������
            writer.Write(temp.EOAlwcCount);
            //BO�Ǘ��ԍ�
            writer.Write(temp.BOManagementNo);
            //�񓚒艿
            writer.Write(temp.AnswerListPrice);
            //�񓚌����P��
            writer.Write(temp.AnswerSalesUnitCost);
            //UOE��փ}�[�N
            writer.Write(temp.UOESubstMark);
            //UOE�݌Ƀ}�[�N
            writer.Write(temp.UOEStockMark);
            //�w�ʃR�[�h
            writer.Write(temp.PartsLayerCd);
            //UOE�o�׋��_�R�[�h�P�i�}�c�_�j
            writer.Write(temp.MazdaUOEShipSectCd1);
            //UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
            writer.Write(temp.MazdaUOEShipSectCd2);
            //UOE�o�׋��_�R�[�h�R�i�}�c�_�j
            writer.Write(temp.MazdaUOEShipSectCd3);
            //UOE���_�R�[�h�P�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd1);
            //UOE���_�R�[�h�Q�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd2);
            //UOE���_�R�[�h�R�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd3);
            //UOE���_�R�[�h�S�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd4);
            //UOE���_�R�[�h�T�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd5);
            //UOE���_�R�[�h�U�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd6);
            //UOE���_�R�[�h�V�i�}�c�_�j
            writer.Write(temp.MazdaUOESectCd7);
            //UOE�݌ɐ��P�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt1);
            //UOE�݌ɐ��Q�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt2);
            //UOE�݌ɐ��R�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt3);
            //UOE�݌ɐ��S�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt4);
            //UOE�݌ɐ��T�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt5);
            //UOE�݌ɐ��U�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt6);
            //UOE�݌ɐ��V�i�}�c�_�j
            writer.Write(temp.MazdaUOEStockCnt7);
            //UOE���R�[�h
            writer.Write(temp.UOEDistributionCd);
            //UOE���R�[�h
            writer.Write(temp.UOEOtherCd);
            //UOE�g�l�R�[�h
            writer.Write(temp.UOEHMCd);
            //�a�n��
            writer.Write(temp.BOCount);
            //UOE�}�[�N�R�[�h
            writer.Write(temp.UOEMarkCode);
            //�o�׌�
            writer.Write(temp.SourceShipment);
            //�A�C�e���R�[�h
            writer.Write(temp.ItemCode);
            //UOE�`�F�b�N�R�[�h
            writer.Write(temp.UOECheckCode);
            //�w�b�h�G���[���b�Z�[�W
            writer.Write(temp.HeadErrorMassage);
            //���C���G���[���b�Z�[�W
            writer.Write(temp.LineErrorMassage);

        }

        /// <summary>
        ///  UOEAnswerLedgerResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>UOEAnswerLedgerResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private UOEAnswerLedgerResultWork GetUOEAnswerLedgerResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            UOEAnswerLedgerResultWork temp = new UOEAnswerLedgerResultWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
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
            //�V�X�e���敪
            temp.SystemDivCd = reader.ReadInt32();
            //UOE�����ԍ�
            temp.UOESalesOrderNo = reader.ReadInt32();
            //UOE�����s�ԍ�
            temp.UOESalesOrderRowNo = reader.ReadInt32();
            //���M�[���ԍ�
            temp.SendTerminalNo = reader.ReadInt32();
            //UOE������R�[�h
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE�����於��
            temp.UOESupplierName = reader.ReadString();
            //�ʐM�A�Z���u��ID
            temp.CommAssemblyId = reader.ReadString();
            //�I�����C���ԍ�
            temp.OnlineNo = reader.ReadInt32();
            //�I�����C���s�ԍ�
            temp.OnlineRowNo = reader.ReadInt32();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�f�[�^�X�V����
            temp.DataUpdateDateTime = new DateTime(reader.ReadInt64());
            //UOE���
            temp.UOEKind = reader.ReadInt32();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //���W�ԍ�
            temp.CashRegisterNo = reader.ReadInt32();
            //BO�敪
            temp.BoCode = reader.ReadString();
            //�[�i�敪
            temp.UOEDeliGoodsDiv = reader.ReadString();
            //�[�i�敪����
            temp.DeliveredGoodsDivNm = reader.ReadString();
            //�t�H���[�[�i�敪
            temp.FollowDeliGoodsDiv = reader.ReadString();
            //�t�H���[�[�i�敪����
            temp.FollowDeliGoodsDivNm = reader.ReadString();
            //UOE�w�苒�_
            temp.UOEResvdSection = reader.ReadString();
            //UOE�w�苒�_����
            temp.UOEResvdSectionNm = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�]�ƈ�����
            temp.EmployeeName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�n�C�t�������i�ԍ�
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //�艿�i�����j
            temp.ListPrice = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //��M���t
            temp.ReceiveDate = new DateTime(reader.ReadInt64());
            //��M����
            temp.ReceiveTime = reader.ReadInt32();
            //�񓚃��[�J�[�R�[�h
            temp.AnswerMakerCd = reader.ReadInt32();
            //�񓚕i��
            temp.AnswerPartsNo = reader.ReadString();
            //�񓚕i��
            temp.AnswerPartsName = reader.ReadString();
            //��֕i��
            temp.SubstPartsNo = reader.ReadString();
            //UOE���_�o�ɐ�
            temp.UOESectOutGoodsCnt = reader.ReadInt32();
            //BO�o�ɐ�1
            temp.BOShipmentCnt1 = reader.ReadInt32();
            //BO�o�ɐ�2
            temp.BOShipmentCnt2 = reader.ReadInt32();
            //BO�o�ɐ�3
            temp.BOShipmentCnt3 = reader.ReadInt32();
            //���[�J�[�t�H���[��
            temp.MakerFollowCnt = reader.ReadInt32();
            //���o�ɐ�
            temp.NonShipmentCnt = reader.ReadInt32();
            //UOE���_�݌ɐ�
            temp.UOESectStockCnt = reader.ReadInt32();
            //BO�݌ɐ�1
            temp.BOStockCount1 = reader.ReadInt32();
            //BO�݌ɐ�2
            temp.BOStockCount2 = reader.ReadInt32();
            //BO�݌ɐ�3
            temp.BOStockCount3 = reader.ReadInt32();
            //UOE���_�`�[�ԍ�
            temp.UOESectionSlipNo = reader.ReadString();
            //BO�`�[�ԍ��P
            temp.BOSlipNo1 = reader.ReadString();
            //BO�`�[�ԍ��Q
            temp.BOSlipNo2 = reader.ReadString();
            //BO�`�[�ԍ��R
            temp.BOSlipNo3 = reader.ReadString();
            //EO������
            temp.EOAlwcCount = reader.ReadInt32();
            //BO�Ǘ��ԍ�
            temp.BOManagementNo = reader.ReadString();
            //�񓚒艿
            temp.AnswerListPrice = reader.ReadDouble();
            //�񓚌����P��
            temp.AnswerSalesUnitCost = reader.ReadDouble();
            //UOE��փ}�[�N
            temp.UOESubstMark = reader.ReadString();
            //UOE�݌Ƀ}�[�N
            temp.UOEStockMark = reader.ReadString();
            //�w�ʃR�[�h
            temp.PartsLayerCd = reader.ReadString();
            //UOE�o�׋��_�R�[�h�P�i�}�c�_�j
            temp.MazdaUOEShipSectCd1 = reader.ReadString();
            //UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
            temp.MazdaUOEShipSectCd2 = reader.ReadString();
            //UOE�o�׋��_�R�[�h�R�i�}�c�_�j
            temp.MazdaUOEShipSectCd3 = reader.ReadString();
            //UOE���_�R�[�h�P�i�}�c�_�j
            temp.MazdaUOESectCd1 = reader.ReadString();
            //UOE���_�R�[�h�Q�i�}�c�_�j
            temp.MazdaUOESectCd2 = reader.ReadString();
            //UOE���_�R�[�h�R�i�}�c�_�j
            temp.MazdaUOESectCd3 = reader.ReadString();
            //UOE���_�R�[�h�S�i�}�c�_�j
            temp.MazdaUOESectCd4 = reader.ReadString();
            //UOE���_�R�[�h�T�i�}�c�_�j
            temp.MazdaUOESectCd5 = reader.ReadString();
            //UOE���_�R�[�h�U�i�}�c�_�j
            temp.MazdaUOESectCd6 = reader.ReadString();
            //UOE���_�R�[�h�V�i�}�c�_�j
            temp.MazdaUOESectCd7 = reader.ReadString();
            //UOE�݌ɐ��P�i�}�c�_�j
            temp.MazdaUOEStockCnt1 = reader.ReadInt32();
            //UOE�݌ɐ��Q�i�}�c�_�j
            temp.MazdaUOEStockCnt2 = reader.ReadInt32();
            //UOE�݌ɐ��R�i�}�c�_�j
            temp.MazdaUOEStockCnt3 = reader.ReadInt32();
            //UOE�݌ɐ��S�i�}�c�_�j
            temp.MazdaUOEStockCnt4 = reader.ReadInt32();
            //UOE�݌ɐ��T�i�}�c�_�j
            temp.MazdaUOEStockCnt5 = reader.ReadInt32();
            //UOE�݌ɐ��U�i�}�c�_�j
            temp.MazdaUOEStockCnt6 = reader.ReadInt32();
            //UOE�݌ɐ��V�i�}�c�_�j
            temp.MazdaUOEStockCnt7 = reader.ReadInt32();
            //UOE���R�[�h
            temp.UOEDistributionCd = reader.ReadString();
            //UOE���R�[�h
            temp.UOEOtherCd = reader.ReadString();
            //UOE�g�l�R�[�h
            temp.UOEHMCd = reader.ReadString();
            //�a�n��
            temp.BOCount = reader.ReadInt32();
            //UOE�}�[�N�R�[�h
            temp.UOEMarkCode = reader.ReadString();
            //�o�׌�
            temp.SourceShipment = reader.ReadString();
            //�A�C�e���R�[�h
            temp.ItemCode = reader.ReadString();
            //UOE�`�F�b�N�R�[�h
            temp.UOECheckCode = reader.ReadString();
            //�w�b�h�G���[���b�Z�[�W
            temp.HeadErrorMassage = reader.ReadString();
            //���C���G���[���b�Z�[�W
            temp.LineErrorMassage = reader.ReadString();


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
        /// <returns>UOEAnswerLedgerResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOEAnswerLedgerResultWork temp = GetUOEAnswerLedgerResultWork(reader, serInfo);
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
                    retValue = (UOEAnswerLedgerResultWork[])lst.ToArray(typeof(UOEAnswerLedgerResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
