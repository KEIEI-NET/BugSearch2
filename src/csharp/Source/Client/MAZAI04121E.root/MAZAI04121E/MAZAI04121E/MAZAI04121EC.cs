using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveHeader
    /// <summary>
    ///                      �݌Ɉړ��w�b�_�f�[�^
    /// </summary>
    /// <remarks>
    /// note             :   �݌Ɉړ��w�b�_�f�[�^�t�@�C��<br />
    /// Programmer       :   �ɓ� �L<br />
    /// Date             :   <br />
    /// Genarated Date   :   2007/01/23<br />
    /// Update Note      :   <br />
    /// </remarks>
    public class StockMoveHeader
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

        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h</summary>
        private string _StockMvEmpCode = "";

        /// <summary>�݌Ɉړ����͏]�ƈ�����</summary>
        private string _StockMvEmpName = "";

        /// <summary>�o�ח\���</summary>
        private DateTime _ShipmentScdlDay;

        /// <summary>�o�ח\���</summary>
        private DateTime _ShipmentFixDay;

        /// <summary>�ړ������_�R�[�h</summary>
        private string _BfSectionCode;

        /// <summary>�ړ������_����</summary>
        private string _BfSectionGuideName;

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _BfEnterWarehCode;

        /// <summary>�ړ����q�ɖ���</summary>
        private string _BfEnterWarehName;

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _AfSectionCode;

        /// <summary>�ړ��拒�_����</summary>
        private string _AfSectionGuideName;

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _AfEnterWarehCode = "";

        /// <summary>�ړ���q�ɖ���</summary>
        private string _AfEnterWarehName = "";

        /// <summary>�ړ��`�[�ԍ�</summary>
        private int _StockMoveSlipNo;

        /// <summary>�ړ��`�[���s�敪</summary>
        private bool _MoveSlipPrintDiv;

        /// <summary>�o�גS���]�ƈ��R�[�h</summary>
        private string _ShipAgentCd = "";

        /// <summary>�o�גS���]�ƈ�����</summary>
        private string _ShipAgentNm = "";

        /// <summary>����S���]�ƈ��R�[�h</summary>
        private string _ReceiveAgentCd = "";

        /// <summary>����S���]�ƈ�����</summary>
        private string _ReceiveAgentNm = "";

        /// <summary>���ד�</summary>
        private DateTime _ArrivalGoodsDay;

        /// <summary>�`�[�E�v</summary>
        private string _OutLine = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬�����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �쐬���� �a��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �쐬���� �a��(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �쐬���� ����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �쐬���� ����(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V�����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V���� �a��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V���� �a��(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V���� ����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V���� ����(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   ��ƃR�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   GUID�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V�]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V�A�Z���u��ID1�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �X�V�A�Z���u��ID2�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
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
        /// note             :   �_���폜�敪�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  _StockMvEmpCode
        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _StockMvEmpCode; }
            set { _StockMvEmpCode = value; }
        }

        /// public propaty name  :  _StockMvEmpName
        /// <summary>�݌Ɉړ����͏]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ����͏]�ƈ����̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string StockMvEmpName
        {
            get { return _StockMvEmpName; }
            set { _StockMvEmpName = value; }
        }

        /// public propaty name  :  _ShipmentScdlDay
        /// <summary>�o�ח\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�ח\����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public DateTime ShipmentScdlDay
        {
            get { return _ShipmentScdlDay; }
            set { _ShipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentScdlDayJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� �a��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentScdlDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� �a��(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentScdlDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� ����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentScdlDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� ����(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentScdlDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ShipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  _ShipmentScdlDay
        /// <summary>�o�ח\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�ח\����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public DateTime ShipmentFixDay
        {
            get { return _ShipmentFixDay; }
            set { _ShipmentFixDay = value; }
        }

        /// public propaty name  :  ShipmentFixDayJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� �a��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentFixDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� �a��(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentFixDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� ����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentFixDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� ����(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipmentFixDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ShipmentFixDay); }
            set { }
        }

        /// public propaty name  :  _BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ������_�R�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string BfSectionCode
        {
            get { return _BfSectionCode; }
            set { _BfSectionCode = value; }
        }

        /// public propaty name  :  _BfSectionGuideName
        /// <summary>�ړ������_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ������_���̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string BfSectionGuideName
        {
            get { return _BfSectionGuideName; }
            set { _BfSectionGuideName = value; }
        }

        /// public propaty name  :  _BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ����q�ɃR�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _BfEnterWarehCode; }
            set { _BfEnterWarehCode = value; }
        }

        /// public propaty name  :  _BfEnterWarehName
        /// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ����q�ɖ��̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _BfEnterWarehName; }
            set { _BfEnterWarehName = value; }
        }

        /// public propaty name  :  _AfSectionCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��拒�_�R�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string AfSectionCode
        {
            get { return _AfSectionCode; }
            set { _AfSectionCode = value; }
        }

        /// public propaty name  :  _AfSectionGuideName
        /// <summary>�ړ��拒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��拒�_���̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string AfSectionGuideName
        {
            get { return _AfSectionGuideName; }
            set { _AfSectionGuideName = value; }
        }

        /// public propaty name  :  _AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ���q�ɃR�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _AfEnterWarehCode; }
            set { _AfEnterWarehCode = value; }
        }

        /// public propaty name  :  _AfEnterWarehName
        /// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ���q�ɖ��̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _AfEnterWarehName; }
            set { _AfEnterWarehName = value; }
        }

        /// public propaty name  :  _StockMoveSlipNo
        /// <summary>�ړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��`�[�ԍ��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public int StockMoveSlipNo
        {
            get { return _StockMoveSlipNo; }
            set { _StockMoveSlipNo = value; }
        }

        /// public propaty name  :  _MoveSlipPrintDiv
        /// <summary>�ړ��`�[���s�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��`�[���s�敪�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public bool MoveSlipPrintDiv
        {
            get { return _MoveSlipPrintDiv; }
            set { _MoveSlipPrintDiv = value; }
        }

        /// public propaty name  :  _ShipAgentCd
        /// <summary>�o�גS���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�גS���]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _ShipAgentCd; }
            set { _ShipAgentCd = value; }
        }

        /// public propaty name  :  _ShipAgentNm
        /// <summary>�o�גS���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �o�גS���]�ƈ����̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ShipAgentNm
        {
            get { return _ShipAgentNm; }
            set { _ShipAgentNm = value; }
        }

        /// public propaty name  :  _ReceiveAgentCd
        /// <summary>����S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ����S���]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _ReceiveAgentCd; }
            set { _ReceiveAgentCd = value; }
        }

        /// public propaty name  :  _ReceiveAgentNm
        /// <summary>����S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ����S���]�ƈ����̃v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ReceiveAgentNm
        {
            get { return _ReceiveAgentNm; }
            set { _ReceiveAgentNm = value; }
        }

        /// public propaty name  :  _ArrivalGoodsDay
        /// <summary>���ד��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���ד��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _ArrivalGoodsDay; }
            set { _ArrivalGoodsDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDayJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// ------de----------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� �a��v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ArrivalGoodsDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� �a��(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ArrivalGoodsDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� ����v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ArrivalGoodsDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬���� ����(��)�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string ArrivalGoodsDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _ArrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  OutLine
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �`�[�E�v�v���p�e�B<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public string OutLine
        {
            get { return _OutLine; }
            set { _OutLine = value; }
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockMoveHeader�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveHeader�N���X�̐V�����C���X�^���X�𐶐����܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public StockMoveHeader()
        {
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <returns>StockMoveHeader�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveHeader�N���X�̐V�����C���X�^���X�𐶐����܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public StockMoveHeader(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string StockMvEmpCode, string StockMvEmpName, DateTime ShipmentScdlDay, DateTime ShipmentFixDay, string BfSectionCode, string BfSectionGuideName, string BfEnterWarehCode, string BfEnterWarehName, string AfSectionCode, string AfSectionGuideName, string AfEnterWarehCode, string AfEnterWarehName, int StockMoveSlipNo, bool MoveSlipPrintDiv, string ShipAgentCd, string ShipAgentNm, string ReceiveAgentCd, string ReceiveAgentNm, DateTime ArrivalGoodsDay, string OutLine)
        {
            this._createDateTime = createDateTime;
            this._updateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._StockMvEmpCode = StockMvEmpCode;
            this._StockMvEmpName = StockMvEmpName;
            this._ShipmentScdlDay = ShipmentScdlDay;
            this._ShipmentFixDay = ShipmentFixDay;
            this._BfSectionCode = BfSectionCode;
            this._BfSectionGuideName = BfSectionGuideName;
            this._BfEnterWarehCode = BfEnterWarehCode;
            this._BfEnterWarehName = BfEnterWarehName;
            this._AfSectionCode = AfSectionCode;
            this._AfSectionGuideName = AfSectionGuideName;
            this._AfEnterWarehCode = AfEnterWarehCode;
            this._AfEnterWarehName = AfEnterWarehName;
            this._StockMoveSlipNo = StockMoveSlipNo;
            this._MoveSlipPrintDiv = MoveSlipPrintDiv;
            this._ShipAgentCd = ShipAgentCd;
            this._ShipAgentNm = ShipAgentNm;
            this._ReceiveAgentCd = ReceiveAgentCd;
            this._ReceiveAgentNm = ReceiveAgentNm;
            this._ArrivalGoodsDay = ArrivalGoodsDay;
            this._OutLine = OutLine;
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^��������
        /// </summary>
        /// <returns>StockMoveHeader�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockMoveHeader�N���X�̃C���X�^���X��Ԃ��܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public StockMoveHeader Clone()
        {
            return new StockMoveHeader(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._StockMvEmpCode, this._StockMvEmpName, this._ShipmentScdlDay, this.ShipmentFixDay, this.BfSectionCode, this.BfSectionGuideName, this.BfEnterWarehCode, this.BfEnterWarehName, this._AfSectionCode, this._AfSectionGuideName, this._AfEnterWarehCode, this._AfEnterWarehName, this.StockMoveSlipNo, this._MoveSlipPrintDiv, this._ShipAgentCd, this._ShipAgentNm, this._ReceiveAgentCd, this._ReceiveAgentNm, this._ArrivalGoodsDay, this._OutLine);
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockMoveHeader�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveHeader�N���X�̓��e����v���邩��r���܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public bool Equals(StockMoveHeader target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.StockMvEmpCode == target.StockMvEmpCode)
                 && (this.StockMvEmpName == target.StockMvEmpName)
                 && (this.ShipmentScdlDay == target.ShipmentScdlDay)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionGuideName == target.BfSectionGuideName)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.BfEnterWarehName == target.BfEnterWarehName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionGuideName == target.AfSectionGuideName)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.AfEnterWarehName == target.AfEnterWarehName)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.MoveSlipPrintDiv == target.MoveSlipPrintDiv)
                 && (this.ShipAgentCd == target.ShipAgentCd)
                 && (this.ShipAgentNm == target.ShipAgentNm)
                 && (this.ReceiveAgentCd == target.ReceiveAgentCd)
                 && (this.ReceiveAgentNm == target.ReceiveAgentNm)
                 && (this.ArrivalGoodsDay == target.ArrivalGoodsDay)
                 && (this.OutLine == target.OutLine));
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="stockMoveHeader1">
        ///                    ��r����StockMoveHeader�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockMoveHeader2">��r����StockMoveHeader�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveHeader�N���X�̓��e����v���邩��r���܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public static bool Equals(StockMoveHeader stockMoveHeader1, StockMoveHeader stockMoveHeader2)
        {
            return ((stockMoveHeader1.CreateDateTime == stockMoveHeader2.CreateDateTime)
                 && (stockMoveHeader1.UpdateDateTime == stockMoveHeader2.UpdateDateTime)
                 && (stockMoveHeader1.EnterpriseCode == stockMoveHeader2.EnterpriseCode)
                 && (stockMoveHeader1.FileHeaderGuid == stockMoveHeader2.FileHeaderGuid)
                 && (stockMoveHeader1.UpdEmployeeCode == stockMoveHeader2.UpdEmployeeCode)
                 && (stockMoveHeader1.UpdAssemblyId1 == stockMoveHeader2.UpdAssemblyId1)
                 && (stockMoveHeader1.UpdAssemblyId2 == stockMoveHeader2.UpdAssemblyId2)
                 && (stockMoveHeader1.LogicalDeleteCode == stockMoveHeader2.LogicalDeleteCode)
                 && (stockMoveHeader1.StockMvEmpCode == stockMoveHeader2.StockMvEmpCode)
                 && (stockMoveHeader1.StockMvEmpName == stockMoveHeader2.StockMvEmpName)
                 && (stockMoveHeader1.ShipmentScdlDay == stockMoveHeader2.ShipmentScdlDay)
                 && (stockMoveHeader1.BfSectionCode == stockMoveHeader2.BfSectionCode)
                 && (stockMoveHeader1.BfSectionGuideName == stockMoveHeader2.BfSectionGuideName)
                 && (stockMoveHeader1.BfEnterWarehCode == stockMoveHeader2.BfEnterWarehCode)
                 && (stockMoveHeader1.BfEnterWarehName == stockMoveHeader2.BfEnterWarehName)
                 && (stockMoveHeader1.AfSectionCode == stockMoveHeader2.AfSectionCode)
                 && (stockMoveHeader1.AfSectionGuideName == stockMoveHeader2.AfSectionGuideName)
                 && (stockMoveHeader1.AfEnterWarehCode == stockMoveHeader2.AfEnterWarehCode)
                 && (stockMoveHeader1.AfEnterWarehName == stockMoveHeader2.AfEnterWarehName)
                 && (stockMoveHeader1.StockMoveSlipNo == stockMoveHeader2.StockMoveSlipNo)
                 && (stockMoveHeader1.MoveSlipPrintDiv == stockMoveHeader2.MoveSlipPrintDiv)
                 && (stockMoveHeader1.ShipAgentCd == stockMoveHeader2.ShipAgentCd)
                 && (stockMoveHeader1.ShipAgentNm == stockMoveHeader2.ShipAgentNm)
                 && (stockMoveHeader1.ReceiveAgentCd == stockMoveHeader2.ReceiveAgentCd)
                 && (stockMoveHeader1.ReceiveAgentNm == stockMoveHeader2.ReceiveAgentNm)
                 && (stockMoveHeader1.ArrivalGoodsDay == stockMoveHeader2.ArrivalGoodsDay)
                 && (stockMoveHeader1.OutLine == stockMoveHeader2.OutLine));
        }
        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockMoveHeader�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveHeader�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public ArrayList Compare(StockMoveHeader target)
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
            if (this.StockMvEmpCode != target.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (this.StockMvEmpName != target.StockMvEmpName) resList.Add("StockMvEmpName");
            if (this.ShipmentScdlDay != target.ShipmentScdlDay) resList.Add("ShipmentScdlDay");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionGuideName != target.BfSectionGuideName) resList.Add("BfSectionGuideName");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.BfEnterWarehName != target.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionGuideName != target.AfSectionGuideName) resList.Add("AfSectionGuideName");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.AfEnterWarehName != target.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.MoveSlipPrintDiv != target.MoveSlipPrintDiv) resList.Add("MoveSlipPrintDiv");
            if (this.ShipAgentCd != target.ShipAgentCd) resList.Add("ShipAgentCd");
            if (this.ShipAgentNm != target.ShipAgentNm) resList.Add("ShipAgentNm");
            if (this.ReceiveAgentCd != target.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (this.ReceiveAgentNm != target.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (this.ArrivalGoodsDay != target.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (this.OutLine != target.OutLine) resList.Add("OutLine");

            return resList;
        }

        /// <summary>
        /// �݌Ɉړ��w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="stockMoveHeader1">��r����StockMoveHeader�N���X�̃C���X�^���X</param>
        /// <param name="stockMoveHeader2">��r����StockMoveHeader�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveHeader�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�<br />
        /// Programer        :   �ɓ� �L<br />
        /// </remarks>
        public static ArrayList Compare(StockMoveHeader stockMoveHeader1, StockMoveHeader stockMoveHeader2)
        {
            ArrayList resList = new ArrayList();
            if (stockMoveHeader1.CreateDateTime != stockMoveHeader2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockMoveHeader1.UpdateDateTime != stockMoveHeader2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockMoveHeader1.EnterpriseCode != stockMoveHeader2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMoveHeader1.FileHeaderGuid != stockMoveHeader2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockMoveHeader1.UpdEmployeeCode != stockMoveHeader2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockMoveHeader1.UpdAssemblyId1 != stockMoveHeader2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockMoveHeader1.UpdAssemblyId2 != stockMoveHeader2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockMoveHeader1.LogicalDeleteCode != stockMoveHeader2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockMoveHeader1.StockMvEmpCode != stockMoveHeader2.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (stockMoveHeader1.StockMvEmpName != stockMoveHeader2.StockMvEmpName) resList.Add("StockMvEmpName");
            if (stockMoveHeader1.ShipmentScdlDay != stockMoveHeader2.ShipmentScdlDay) resList.Add("ShipmentScdlDay");
            if (stockMoveHeader1.BfSectionCode != stockMoveHeader2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMoveHeader1.BfSectionGuideName != stockMoveHeader2.BfSectionGuideName) resList.Add("BfSectionGuideName");
            if (stockMoveHeader1.BfEnterWarehCode != stockMoveHeader2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMoveHeader1.BfEnterWarehName != stockMoveHeader2.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (stockMoveHeader1.AfSectionCode != stockMoveHeader2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMoveHeader1.AfSectionGuideName != stockMoveHeader2.AfSectionGuideName) resList.Add("AfSectionGuideName");
            if (stockMoveHeader1.AfEnterWarehCode != stockMoveHeader2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMoveHeader1.AfEnterWarehName != stockMoveHeader2.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (stockMoveHeader1.StockMoveSlipNo != stockMoveHeader2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMoveHeader1.MoveSlipPrintDiv != stockMoveHeader2.MoveSlipPrintDiv) resList.Add("MoveSlipPrintDiv");
            if (stockMoveHeader1.ShipAgentCd != stockMoveHeader2.ShipAgentCd) resList.Add("ShipAgentCd");
            if (stockMoveHeader1.ShipAgentNm != stockMoveHeader2.ShipAgentNm) resList.Add("ShipAgentNm");
            if (stockMoveHeader1.ReceiveAgentCd != stockMoveHeader2.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (stockMoveHeader1.ReceiveAgentNm != stockMoveHeader2.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (stockMoveHeader1.ArrivalGoodsDay != stockMoveHeader2.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (stockMoveHeader1.OutLine != stockMoveHeader2.OutLine) resList.Add("OutLine");

            return resList;
        }
    }
}