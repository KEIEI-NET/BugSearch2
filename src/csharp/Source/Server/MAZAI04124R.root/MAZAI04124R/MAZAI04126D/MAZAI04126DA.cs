using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

//�ړ����z�FStockMovePrice(Int64)�A���i�����o�^�敪��ǉ�����

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMoveWork
    /// <summary>
    ///                      �݌Ɉړ��f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɉړ��f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/07/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/23  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   ���i���̃J�i</br>
    /// <br>Update Note      :   2012/07/05 �O�� �L��</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �ړ����݌Ɏ����o�^�敪</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMoveWork : IFileHeader
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

        /// <summary>�݌Ɉړ��`��</summary>
        /// <remarks>1:�݌Ɉړ��A2�F�q�Ɉړ�</remarks>
        private Int32 _stockMoveFormal;

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>�݌Ɉړ��s�ԍ�</summary>
        private Int32 _stockMoveRowNo;

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>�ړ������_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>�ړ������_�K�C�h����</summary>
        private string _bfSectionGuideSnm = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>�ړ����q�ɖ���</summary>
        private string _bfEnterWarehName = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>�ړ��拒�_�K�C�h����</summary>
        private string _afSectionGuideSnm = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _afEnterWarehCode = "";

        /// <summary>�ړ���q�ɖ���</summary>
        private string _afEnterWarehName = "";

        /// <summary>�o�ח\���</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentScdlDay;

        /// <summary>�o�׊m���</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentFixDay;

        /// <summary>���ד�</summary>
        /// <remarks>�݌Ɉړ������i���ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>�ړ����</summary>
        /// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
        private Int32 _moveStatus;

        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h</summary>
        /// <remarks>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _stockMvEmpCode = "";

        /// <summary>�݌Ɉړ����͏]�ƈ�����</summary>
        private string _stockMvEmpName = "";

        /// <summary>�o�גS���]�ƈ��R�[�h</summary>
        /// <remarks>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _shipAgentCd = "";

        /// <summary>�o�גS���]�ƈ�����</summary>
        private string _shipAgentNm = "";

        /// <summary>����S���]�ƈ��R�[�h</summary>
        /// <remarks>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</remarks>
        private string _receiveAgentCd = "";

        /// <summary>����S���]�ƈ�����</summary>
        private string _receiveAgentNm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:���ЁA1:���</remarks>
        private Int32 _stockDiv;

        /// <summary>�d���P���i�Ŕ�,�����j</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�ړ���</summary>
        private Double _moveCount;

        /// <summary>�ړ����I��</summary>
        private string _bfShelfNo = "";

        /// <summary>�ړ���I��</summary>
        private string _afShelfNo = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>�艿�i�����j</summary>
        private Double _listPriceFl;

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</remarks>
        private string _outline = "";

        /// <summary>�q�ɔ��l1</summary>
        /// <remarks>�݌Ɉړ����̈ړ��`�[�ɏo�͂�����l���Z�b�g</remarks>
        private string _warehouseNote1 = "";

        /// <summary>�`�[���s�ϋ敪</summary>
        /// <remarks>0:�����s 1:���s��</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>�ړ����z</summary>
        private Int64 _stockMovePrice;

        /// <summary>���i�����o�^�敪</summary>
        private Int32 _autoGoodsInsDiv;

        /// <summary>�݌Ɉړ��m��敪</summary>
        /// <remarks>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </remarks>
        private Int32 _stockMoveFixCode;

        /// <summary>�݌Ɏ󕥃f�[�^�쐬�敪</summary>
        /// <remarks>0�F�쐬�K�v�A1�F�쐬�Ȃ� </remarks>
        private Int32 _createHistDiv;

        // --- ADD �O�� 2012/07/05 ---------->>>>>
        /// <summary>�ړ����݌Ɏ����o�^�敪</summary>
        /// <remarks>0�F����A1�F���Ȃ� </remarks>
        private Int32 _moveStockAutoInsDiv;
        // --- ADD �O�� 2012/07/05 ----------<<<<<
        
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

        /// public propaty name  :  StockMoveFormal
        /// <summary>�݌Ɉړ��`���v���p�e�B</summary>
        /// <value>1:�݌Ɉړ��A2�F�q�Ɉړ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveFormal
        {
            get { return _stockMoveFormal; }
            set { _stockMoveFormal = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveRowNo
        /// <summary>�݌Ɉړ��s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveRowNo
        {
            get { return _stockMoveRowNo; }
            set { _stockMoveRowNo = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>�X�V���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �f�[�^�̓o�^�X�V���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideSnm
        /// <summary>�ړ������_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionGuideSnm
        {
            get { return _bfSectionGuideSnm; }
            set { _bfSectionGuideSnm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideSnm
        /// <summary>�ړ��拒�_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionGuideSnm
        {
            get { return _afSectionGuideSnm; }
            set { _afSectionGuideSnm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  ShipmentScdlDay
        /// <summary>�o�ח\����v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentScdlDay
        {
            get { return _shipmentScdlDay; }
            set { _shipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentFixDay
        /// <summary>�o�׊m����v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׊m����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentFixDay
        {
            get { return _shipmentFixDay; }
            set { _shipmentFixDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// <value>�݌Ɉړ������i���ב��j���s�������ɃZ�b�g</value>
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

        /// public propaty name  :  MoveStatus
        /// <summary>�ړ���ԃv���p�e�B</summary>
        /// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  StockMvEmpCode
        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _stockMvEmpCode; }
            set { _stockMvEmpCode = value; }
        }

        /// public propaty name  :  StockMvEmpName
        /// <summary>�݌Ɉړ����͏]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ����͏]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockMvEmpName
        {
            get { return _stockMvEmpName; }
            set { _stockMvEmpName = value; }
        }

        /// public propaty name  :  ShipAgentCd
        /// <summary>�o�גS���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�גS���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _shipAgentCd; }
            set { _shipAgentCd = value; }
        }

        /// public propaty name  :  ShipAgentNm
        /// <summary>�o�גS���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�גS���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipAgentNm
        {
            get { return _shipAgentNm; }
            set { _shipAgentNm = value; }
        }

        /// public propaty name  :  ReceiveAgentCd
        /// <summary>����S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _receiveAgentCd; }
            set { _receiveAgentCd = value; }
        }

        /// public propaty name  :  ReceiveAgentNm
        /// <summary>����S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveAgentNm
        {
            get { return _receiveAgentNm; }
            set { _receiveAgentNm = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:���ЁA1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ�,�����j�v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ�,�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  MoveCount
        /// <summary>�ړ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MoveCount
        {
            get { return _moveCount; }
            set { _moveCount = value; }
        }

        /// public propaty name  :  BfShelfNo
        /// <summary>�ړ����I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfShelfNo
        {
            get { return _bfShelfNo; }
            set { _bfShelfNo = value; }
        }

        /// public propaty name  :  AfShelfNo
        /// <summary>�ړ���I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfShelfNo
        {
            get { return _afShelfNo; }
            set { _afShelfNo = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  ListPriceFl
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// <value>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  WarehouseNote1
        /// <summary>�q�ɔ��l1�v���p�e�B</summary>
        /// <value>�݌Ɉړ����̈ړ��`�[�ɏo�͂�����l���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɔ��l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseNote1
        {
            get { return _warehouseNote1; }
            set { _warehouseNote1 = value; }
        }

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>�`�[���s�ϋ敪�v���p�e�B</summary>
        /// <value>0:�����s 1:���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  StockMovePrice
        /// <summary>�ړ����z</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMovePrice
        {
            get { return _stockMovePrice; }
            set { _stockMovePrice = value; }
        }

        /// public propaty name  :  AutoGoodsInsDiv
        /// <summary>���i�����o�^�敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoGoodsInsDiv
        {
            get { return _autoGoodsInsDiv; }
            set { _autoGoodsInsDiv = value; }
        }

        /// public propaty name  :  StockMoveFixCode
        /// <summary>�݌Ɉړ��m��敪�v���p�e�B</summary>
        /// <value>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��m��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

        /// public propaty name  :  CreateHistDiv
        /// <summary>�݌Ɏ󕥃f�[�^�쐬�敪�v���p�e�B</summary>
        /// <value>0�F�쐬�K�v�A1�F�쐬�Ȃ� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ󕥃f�[�^�쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreateHistDiv
        {
            get { return _createHistDiv; }
            set { _createHistDiv = value; }
        }

        // --- ADD �O�� 2012/07/05 ---------->>>>>
        /// public propaty name  :  MoveStockAutoInsDiv
        /// <summary>�ړ����݌Ɏ����o�^�敪�v���p�e�B</summary>
        /// <value>0�F����A1�F���Ȃ� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����݌Ɏ����o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveStockAutoInsDiv
        {
            get { return _moveStockAutoInsDiv; }
            set { _moveStockAutoInsDiv = value; }
        }
        // --- ADD �O�� 2012/07/05 ----------<<<<<

        /// <summary>
        /// �݌Ɉړ��f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMoveWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMoveWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMoveWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMoveWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockMoveWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMoveWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMoveWork || graph is ArrayList || graph is StockMoveWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockMoveWork).FullName));

            if (graph != null && graph is StockMoveWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMoveWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMoveWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMoveWork[])graph).Length;
            }
            else if (graph is StockMoveWork)
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
            //�݌Ɉړ��`��
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFormal
            //�݌Ɉړ��`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //�݌Ɉړ��s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveRowNo
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //�ړ������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //�ړ������_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionGuideSnm
            //�ړ����q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //�ړ����q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //�ړ��拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //�ړ��拒�_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionGuideSnm
            //�ړ���q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //�ړ���q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //�o�ח\���
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlDay
            //�o�׊m���
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixDay
            //���ד�
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //���͓�
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�ړ����
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStatus
            //�݌Ɉړ����͏]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockMvEmpCode
            //�݌Ɉړ����͏]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //StockMvEmpName
            //�o�גS���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ShipAgentCd
            //�o�גS���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //ShipAgentNm
            //����S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ReceiveAgentCd
            //����S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //ReceiveAgentNm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //�݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //�d���P���i�Ŕ�,�����j
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //�ړ���
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCount
            //�ړ����I��
            serInfo.MemberInfo.Add(typeof(string)); //BfShelfNo
            //�ړ���I��
            serInfo.MemberInfo.Add(typeof(string)); //AfShelfNo
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //�`�[�E�v
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //�q�ɔ��l1
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNote1
            //�`�[���s�ϋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintFinishCd
            //�ړ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePrice
            //���i�����o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoGoodsInsDiv
            //�݌Ɉړ��m��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFixCode
            //�݌Ɏ󕥃f�[�^�쐬
            serInfo.MemberInfo.Add(typeof(Int32)); //CreateHistDiv

            // --- ADD �O�� 2012/07/05 ---------->>>>>
            // �ړ����݌Ɏ����o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStockAutoInsDiv
            // --- ADD �O�� 2012/07/05 ----------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMoveWork)
            {
                StockMoveWork temp = (StockMoveWork)graph;

                SetStockMoveWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMoveWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMoveWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMoveWork temp in lst)
                {
                    SetStockMoveWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMoveWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD �O�� 2012/07/05 ---------->>>>>
        //private const int currentMemberCount = 54;
        private const int currentMemberCount = 55;
        // --- UPD �O�� 2012/07/05 ----------<<<<<

        /// <summary>
        ///  StockMoveWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockMoveWork(System.IO.BinaryWriter writer, StockMoveWork temp)
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
            //�݌Ɉړ��`��
            writer.Write(temp.StockMoveFormal);
            //�݌Ɉړ��`�[�ԍ�
            writer.Write(temp.StockMoveSlipNo);
            //�݌Ɉړ��s�ԍ�
            writer.Write(temp.StockMoveRowNo);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //�ړ������_�R�[�h
            writer.Write(temp.BfSectionCode);
            //�ړ������_�K�C�h����
            writer.Write(temp.BfSectionGuideSnm);
            //�ړ����q�ɃR�[�h
            writer.Write(temp.BfEnterWarehCode);
            //�ړ����q�ɖ���
            writer.Write(temp.BfEnterWarehName);
            //�ړ��拒�_�R�[�h
            writer.Write(temp.AfSectionCode);
            //�ړ��拒�_�K�C�h����
            writer.Write(temp.AfSectionGuideSnm);
            //�ړ���q�ɃR�[�h
            writer.Write(temp.AfEnterWarehCode);
            //�ړ���q�ɖ���
            writer.Write(temp.AfEnterWarehName);
            //�o�ח\���
            writer.Write((Int64)temp.ShipmentScdlDay.Ticks);
            //�o�׊m���
            writer.Write((Int64)temp.ShipmentFixDay.Ticks);
            //���ד�
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //���͓�
            writer.Write((Int64)temp.InputDay.Ticks);
            //�ړ����
            writer.Write(temp.MoveStatus);
            //�݌Ɉړ����͏]�ƈ��R�[�h
            writer.Write(temp.StockMvEmpCode);
            //�݌Ɉړ����͏]�ƈ�����
            writer.Write(temp.StockMvEmpName);
            //�o�גS���]�ƈ��R�[�h
            writer.Write(temp.ShipAgentCd);
            //�o�גS���]�ƈ�����
            writer.Write(temp.ShipAgentNm);
            //����S���]�ƈ��R�[�h
            writer.Write(temp.ReceiveAgentCd);
            //����S���]�ƈ�����
            writer.Write(temp.ReceiveAgentNm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�d���P���i�Ŕ�,�����j
            writer.Write(temp.StockUnitPriceFl);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //�ړ���
            writer.Write(temp.MoveCount);
            //�ړ����I��
            writer.Write(temp.BfShelfNo);
            //�ړ���I��
            writer.Write(temp.AfShelfNo);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //�艿�i�����j
            writer.Write(temp.ListPriceFl);
            //�`�[�E�v
            writer.Write(temp.Outline);
            //�q�ɔ��l1
            writer.Write(temp.WarehouseNote1);
            //�`�[���s�ϋ敪
            writer.Write(temp.SlipPrintFinishCd);
            //�ړ����z
            writer.Write(temp.StockMovePrice);
            //���i�����o�^�敪
            writer.Write(temp.AutoGoodsInsDiv);
            //�݌Ɉړ��m��敪
            writer.Write(temp.StockMoveFixCode);
            //�݌Ɏ󕥃f�[�^�쐬�敪
            writer.Write(temp.CreateHistDiv);

            // --- ADD �O�� 2012/07/05 ---------->>>>>
            //�ړ����݌Ɏ����o�^�敪
            writer.Write(temp.MoveStockAutoInsDiv);
            // --- ADD �O�� 2012/07/05 ----------<<<<<
        }

        /// <summary>
        ///  StockMoveWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMoveWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockMoveWork GetStockMoveWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockMoveWork temp = new StockMoveWork();

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
            //�݌Ɉړ��`��
            temp.StockMoveFormal = reader.ReadInt32();
            //�݌Ɉړ��`�[�ԍ�
            temp.StockMoveSlipNo = reader.ReadInt32();
            //�݌Ɉړ��s�ԍ�
            temp.StockMoveRowNo = reader.ReadInt32();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //�ړ������_�R�[�h
            temp.BfSectionCode = reader.ReadString();
            //�ړ������_�K�C�h����
            temp.BfSectionGuideSnm = reader.ReadString();
            //�ړ����q�ɃR�[�h
            temp.BfEnterWarehCode = reader.ReadString();
            //�ړ����q�ɖ���
            temp.BfEnterWarehName = reader.ReadString();
            //�ړ��拒�_�R�[�h
            temp.AfSectionCode = reader.ReadString();
            //�ړ��拒�_�K�C�h����
            temp.AfSectionGuideSnm = reader.ReadString();
            //�ړ���q�ɃR�[�h
            temp.AfEnterWarehCode = reader.ReadString();
            //�ړ���q�ɖ���
            temp.AfEnterWarehName = reader.ReadString();
            //�o�ח\���
            temp.ShipmentScdlDay = new DateTime(reader.ReadInt64());
            //�o�׊m���
            temp.ShipmentFixDay = new DateTime(reader.ReadInt64());
            //���ד�
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //���͓�
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�ړ����
            temp.MoveStatus = reader.ReadInt32();
            //�݌Ɉړ����͏]�ƈ��R�[�h
            temp.StockMvEmpCode = reader.ReadString();
            //�݌Ɉړ����͏]�ƈ�����
            temp.StockMvEmpName = reader.ReadString();
            //�o�גS���]�ƈ��R�[�h
            temp.ShipAgentCd = reader.ReadString();
            //�o�גS���]�ƈ�����
            temp.ShipAgentNm = reader.ReadString();
            //����S���]�ƈ��R�[�h
            temp.ReceiveAgentCd = reader.ReadString();
            //����S���]�ƈ�����
            temp.ReceiveAgentNm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //�݌ɋ敪
            temp.StockDiv = reader.ReadInt32();
            //�d���P���i�Ŕ�,�����j
            temp.StockUnitPriceFl = reader.ReadDouble();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //�ړ���
            temp.MoveCount = reader.ReadDouble();
            //�ړ����I��
            temp.BfShelfNo = reader.ReadString();
            //�ړ���I��
            temp.AfShelfNo = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //�艿�i�����j
            temp.ListPriceFl = reader.ReadDouble();
            //�`�[�E�v
            temp.Outline = reader.ReadString();
            //�q�ɔ��l1
            temp.WarehouseNote1 = reader.ReadString();
            //�`�[���s�ϋ敪
            temp.SlipPrintFinishCd = reader.ReadInt32();
            //�ړ����z
            temp.StockMovePrice = reader.ReadInt64();
            //���i�����o�^�敪
            temp.AutoGoodsInsDiv = reader.ReadInt32();
            //�݌Ɉړ��m��敪
            temp.StockMoveFixCode = reader.ReadInt32();
            //�݌Ɏ󕥃f�[�^�쐬�敪
            temp.CreateHistDiv = reader.ReadInt32();

            // --- ADD �O�� 2012/07/05 ---------->>>>>
            //�ړ����݌Ɏ����o�^�敪
            temp.MoveStockAutoInsDiv = reader.ReadInt32();
            // --- ADD �O�� 2012/07/05 ----------<<<<<


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
        /// <returns>StockMoveWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMoveWork temp = GetStockMoveWork(reader, serInfo);
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
                    retValue = (StockMoveWork[])lst.ToArray(typeof(StockMoveWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
