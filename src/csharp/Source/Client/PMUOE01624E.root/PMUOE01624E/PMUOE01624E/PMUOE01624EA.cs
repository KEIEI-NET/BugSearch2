//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Y�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �����
// �� �� ��  2010/03/08  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �C �� ��  2011/03/01  �C�����e : ���YUOE������B�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEOrderDtlInfo
    /// <summary>
    ///                      �񓚃f�[�^�捞�����e�[�u���X�L�[�}��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񓚃f�[�^�捞�����e�[�u���X�L�[�}��`�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �����</br>
    /// <br>Date             :   2010/03/08</br>
    /// <br>UpdateNote       : 2011/03/01 liyp</br>
    /// <br>                  ���YUOE������B�Ή� </br>
    /// <br> </br>
    /// </remarks>
    public class UOEOrderDtlInfo
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

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>�󒍓`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>20:��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>���㖾�גʔ�</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�[���ԍ�</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>BO�敪</summary>
        private string _boCode = "";

        /// <summary>UOE�[�i�敪</summary>
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

        /// <summary>�f�[�^���M�敪</summary>
        /// <remarks>0:������,1:������,2:���M�G���[,3:��M�G���[,5:�񓚖��ߍ���,9:����I��</remarks>
        private Int32 _dataSendCode;

        /// <summary>�f�[�^�����敪</summary>
        /// <remarks>0:������,1:�G���[,9:����I��</remarks>
        private Int32 _dataRecoverDiv;

        /// <summary>���ɍX�V�敪�i���_�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivSec;

        /// <summary>���ɍX�V�敪�iBO1�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivBO1;

        /// <summary>���ɍX�V�敪�iBO2�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivBO2;

        /// <summary>���ɍX�V�敪�iBO3�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivBO3;

        /// <summary>���ɍX�V�敪�iҰ���j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivMaker;

        /// <summary>���ɍX�V�敪�iEO�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivEO;

        // --------ADD 2011/03/01 ----------->>>>>
        ///<summary>�A�g�ԍ�</summary>
        private string _renkeNo = "";
        // --------ADD 2011/03/01 -----------<<<<<

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

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>�󒍓`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>20:��</value>
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

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>���㖾�גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
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

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
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

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
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

        /// public propaty name  :  DataSendCode
        /// <summary>�f�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:������,1:������,2:���M�G���[,3:��M�G���[,5:�񓚖��ߍ���,9:����I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  DataRecoverDiv
        /// <summary>�f�[�^�����敪�v���p�e�B</summary>
        /// <value>0:������,1:�G���[,9:����I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataRecoverDiv
        {
            get { return _dataRecoverDiv; }
            set { _dataRecoverDiv = value; }
        }

        /// public propaty name  :  EnterUpdDivSec
        /// <summary>���ɍX�V�敪�i���_�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�i���_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivSec
        {
            get { return _enterUpdDivSec; }
            set { _enterUpdDivSec = value; }
        }

        /// public propaty name  :  EnterUpdDivBO1
        /// <summary>���ɍX�V�敪�iBO1�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iBO1�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivBO1
        {
            get { return _enterUpdDivBO1; }
            set { _enterUpdDivBO1 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO2
        /// <summary>���ɍX�V�敪�iBO2�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iBO2�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivBO2
        {
            get { return _enterUpdDivBO2; }
            set { _enterUpdDivBO2 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO3
        /// <summary>���ɍX�V�敪�iBO3�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iBO3�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivBO3
        {
            get { return _enterUpdDivBO3; }
            set { _enterUpdDivBO3 = value; }
        }

        /// public propaty name  :  EnterUpdDivMaker
        /// <summary>���ɍX�V�敪�iҰ���j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iҰ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivMaker
        {
            get { return _enterUpdDivMaker; }
            set { _enterUpdDivMaker = value; }
        }

        /// public propaty name  :  EnterUpdDivEO
        /// <summary>���ɍX�V�敪�iEO�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iEO�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivEO
        {
            get { return _enterUpdDivEO; }
            set { _enterUpdDivEO = value; }
        }

        // ------ADD 2011/03/01 ---------------------->>>>>
        // <summary>�A�g�ԍ�</summary>
        public string RenkeNo
        {
            get { return _renkeNo; }
            set { _renkeNo = value; }
        }
        // ------ADD 2011/03/01 ----------------------<<<<<

        /// <summary>
        /// UOE�����f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UOEOrderDtlNissanInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEOrderDtlNissanInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEOrderDtlInfo()
        {
        }
    }
}
