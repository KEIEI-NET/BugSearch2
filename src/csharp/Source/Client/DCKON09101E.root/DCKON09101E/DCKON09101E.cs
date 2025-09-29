using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockProcMoney
    /// <summary>
    ///						 �d�����z�����敪�ݒ�}�X�^
    /// </summary>
    /// <remarks>
	/// <br>note             :   �d�����z�����敪�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �������� / 30167 ��� �O�M</br>
    /// <br>Date             :   2007.08.20</br>
    /// <br>Genarated Date   :   2006.08.20  (CSharp File Generated Date)</br>
    /// </remarks>
    public class StockProcMoney
    {
        /*----------------------------------------------------------------------------------*/
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

		/// <summary>�[�������Ώۋ��z�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Int32 _fracProcMoneyDiv;

		/// <summary>�[�������R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Int32 _fractionProcCode;

		/// <summary>������z</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Double _upperLimitPrice;

		/// <summary>�[�������P��</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Double _fractionProcUnit;

		/// <summary>�[�������敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Int32 _fractionProcCd;

		/// <summary>�[�������敪��</summary>
		/// <remarks>���ʃt�@�C���w�b�_(�K�C�h�p)</remarks>
		private string _fractionProcCdNm;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /*----------------------------------------------------------------------------------*/
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

		/// public propaty name  :  FracProcMoneyDiv
		/// <summary>�[�������Ώۋ��z�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������Ώۋ��z�敪�v���p�e�B</br>
		/// <br>Programer        :   30167 ��� �O�M</br>
		/// </remarks>
		public Int32 FracProcMoneyDiv
		{
			get { return _fracProcMoneyDiv; }
			set { _fracProcMoneyDiv = value; }
		}

		/// public propaty name  :  FractionProcCode
		/// <summary>�[�������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   30167 ��� �O�M</br>
		/// </remarks>
		public Int32 FractionProcCode
		{
			get { return _fractionProcCode; }
			set { _fractionProcCode = value; }
		}

		/// public propaty name  :  UpperLimitPrice
		/// <summary>������z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z�v���p�e�B</br>
		/// <br>Programer        :   30167 ��� �O�M</br>
		/// </remarks>
		public Double UpperLimitPrice
		{
			get { return _upperLimitPrice; }
			set { _upperLimitPrice = value; }
		}

		/// public propaty name  :  FractionProcUnit
		/// <summary>�[�������P�ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������P�ʃv���p�e�B</br>
		/// <br>Programer        :   30167 ��� �O�M</br>
		/// </remarks>
		public Double FractionProcUnit
		{
			get { return _fractionProcUnit; }
			set { _fractionProcUnit = value; }
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>�[�������敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������敪�v���p�e�B</br>
		/// <br>Programer        :   30167 ��� �O�M</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get { return _fractionProcCd; }
			set { _fractionProcCd = value; }
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>�[�������敪���v���p�e�B(�K�C�h�p)</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������敪���v���p�e�B(�K�C�h�p)</br>
		/// <br>Programer        :   30167 ��� �O�M</br>
		/// </remarks>
		public string FractionProcCdNm
		{
			get { return _fractionProcCdNm; }
			set { _fractionProcCdNm = value; }
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockProcMoney�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcMoney�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockProcMoney()
        {
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="upperLimitPrice">������z</param>
		/// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		/// <param name="fractionProcCdNm">�[�������敪��(�K�C�h�p)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>StockProcMoney�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcMoney�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   �������� / 30167 ��� �O�M</br>
        /// </remarks>
        public StockProcMoney(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice, Double fractionProcUnit, Int32 fractionProcCd, string fractionProcCdNm, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
			this._fracProcMoneyDiv = fracProcMoneyDiv;
			this._fractionProcCode = fractionProcCode;
			this._upperLimitPrice = upperLimitPrice;
			this._fractionProcUnit = fractionProcUnit;
			this._fractionProcCd = fractionProcCd;
			this._fractionProcCdNm = fractionProcCdNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^��������
        /// </summary>
        /// <returns>StockProcMoney�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockProcMoney�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   �������� / 30167 ��� �O�M</br>
        /// </remarks>
        public StockProcMoney Clone()
        {
            return new StockProcMoney(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._fracProcMoneyDiv, this._fractionProcCode, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._fractionProcCdNm, this._enterpriseName, this._updEmployeeName);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockProcMoney�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcMoney�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   �������� / 30167 ��� �O�M</br>
        /// </remarks>
        public bool Equals(StockProcMoney target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.FracProcMoneyDiv == target.FracProcMoneyDiv)
				 && (this.FractionProcCode == target.FractionProcCode)
				 && (this.UpperLimitPrice == target.UpperLimitPrice)
				 && (this.FractionProcUnit == target.FractionProcUnit)
				 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="StockProcMoney1">
        ///                    ��r����StockProcMoney�N���X�̃C���X�^���X
        /// </param>
        /// <param name="StockProcMoney2">��r����StockProcMoney�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcMoney�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   �������� / 30167 ��� �O�M</br>
        /// </remarks>
        public static bool Equals(StockProcMoney StockProcMoney1, StockProcMoney StockProcMoney2)
        {
            return ((StockProcMoney1.CreateDateTime == StockProcMoney2.CreateDateTime)
                 && (StockProcMoney1.UpdateDateTime == StockProcMoney2.UpdateDateTime)
                 && (StockProcMoney1.EnterpriseCode == StockProcMoney2.EnterpriseCode)
                 && (StockProcMoney1.FileHeaderGuid == StockProcMoney2.FileHeaderGuid)
                 && (StockProcMoney1.UpdEmployeeCode == StockProcMoney2.UpdEmployeeCode)
                 && (StockProcMoney1.UpdAssemblyId1 == StockProcMoney2.UpdAssemblyId1)
                 && (StockProcMoney1.UpdAssemblyId2 == StockProcMoney2.UpdAssemblyId2)
				 && (StockProcMoney1.FracProcMoneyDiv == StockProcMoney2.FracProcMoneyDiv)
				 && (StockProcMoney1.FractionProcCode == StockProcMoney2.FractionProcCode)
				 && (StockProcMoney1.UpperLimitPrice == StockProcMoney2.UpperLimitPrice)
				 && (StockProcMoney1.FractionProcUnit == StockProcMoney2.FractionProcUnit)
				 && (StockProcMoney1.FractionProcCd == StockProcMoney2.FractionProcCd)
                 && (StockProcMoney1.LogicalDeleteCode == StockProcMoney2.LogicalDeleteCode)
                 && (StockProcMoney1.EnterpriseName == StockProcMoney2.EnterpriseName)
                 && (StockProcMoney1.UpdEmployeeName == StockProcMoney2.UpdEmployeeName));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockProcMoney�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcMoney�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   �������� / 30167 ���O�M</br>
        /// </remarks>
        public ArrayList Compare(StockProcMoney target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (this.FracProcMoneyDiv != target.FracProcMoneyDiv) resList.Add("FracProcMoneyDiv");
			if (this.FractionProcCode != target.FractionProcCode) resList.Add("FractionProcCode");
			if (this.UpperLimitPrice != target.UpperLimitPrice) resList.Add("UpperLimitPrice");
			if (this.FractionProcUnit != target.FractionProcUnit) resList.Add("FractionProcUnit");
			if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="StockProcMoney1">��r����StockProcMoney�N���X�̃C���X�^���X</param>
        /// <param name="StockProcMoney2">��r����StockProcMoney�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcMoney�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   �������� / 30167 ���O�M</br>
        /// </remarks>
        public static ArrayList Compare(StockProcMoney StockProcMoney1, StockProcMoney StockProcMoney2)
        {
            ArrayList resList = new ArrayList();
            if (StockProcMoney1.CreateDateTime != StockProcMoney2.CreateDateTime) resList.Add("CreateDateTime");
            if (StockProcMoney1.UpdateDateTime != StockProcMoney2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (StockProcMoney1.EnterpriseCode != StockProcMoney2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (StockProcMoney1.FileHeaderGuid != StockProcMoney2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (StockProcMoney1.UpdEmployeeCode != StockProcMoney2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (StockProcMoney1.UpdAssemblyId1 != StockProcMoney2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (StockProcMoney1.UpdAssemblyId2 != StockProcMoney2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (StockProcMoney1.FracProcMoneyDiv != StockProcMoney2.FracProcMoneyDiv) resList.Add("FracProcMoneyDiv");
			if (StockProcMoney1.FractionProcCode != StockProcMoney2.FractionProcCode) resList.Add("FractionProcCode");
			if (StockProcMoney1.UpperLimitPrice != StockProcMoney2.UpperLimitPrice) resList.Add("UpperLimitPrice");
			if (StockProcMoney1.FractionProcUnit != StockProcMoney2.FractionProcUnit) resList.Add("FractionProcUnit");
			if (StockProcMoney1.FractionProcCd != StockProcMoney2.FractionProcCd) resList.Add("FractionProcCd");
            if (StockProcMoney1.LogicalDeleteCode != StockProcMoney2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (StockProcMoney1.EnterpriseName != StockProcMoney2.EnterpriseName) resList.Add("EnterpriseName");
            if (StockProcMoney1.UpdEmployeeName != StockProcMoney2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

		/// <summary>
		/// �[�������Ώۋ��z�敪�R�[�h���X�g�擾����
		/// </summary>
		/// <returns>�[�������Ώۋ��z�敪�R�[�h���X�g</returns>
		/// <remarks>
		/// <br>Note		: �[�������Ώۋ��z�敪�ɂĎg�p����R�[�h�̃��X�g���擾���܂��B</br>
		/// <br>			: �C���f�b�N�X��GetFracProcMoneyNmList()�ɂĎ擾�o���閼�̂ƈ�v���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFracProcMoneyDivCdList()
		{
			ArrayList retList = new ArrayList();
			retList.Add(0);
			retList.Add(1);
			retList.Add(2);
			return retList;
		}

		/// <summary>
		/// �[�������Ώۋ��z�敪���̃��X�g�擾����
		/// </summary>
		/// <returns>�[�������Ώۋ��z�敪���̃��X�g</returns>
		/// <remarks>
		/// <br>Note		: �[�������Ώۋ��z�敪�ɂĎg�p���閼�̂̃��X�g���擾���܂��B</br>
		/// <br>			: �C���f�b�N�X��GetFracProcMoneyCdList()�ɂĎ擾�o����R�[�h�ƈ�v���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFracProcMoneyDivNmList()
		{
			ArrayList retList = new ArrayList();
			retList.Add("�d�����z");
			retList.Add("�����");
			retList.Add("�d���P��");
			return retList;
		}

		/// <summary>
		/// �[�������Ώۋ��z�敪���̎擾����
		/// </summary>
		/// <returns>�[�������Ώۋ��z�敪����</returns>
		/// <remarks>
		/// <br>Note		: �[�������Ώۋ��z�敪�ɂĎg�p���閼�̂��擾���܂��B</br>
		/// <br>			: �C���f�b�N�X��GetFracProcMoneyCdList()�ɂĎ擾�o����R�[�h�ƈ�v���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.22</br>
		/// </remarks>
		public static string GetFracProcMoneyDivNm(Int32 getFracProcMoneyDivCd)
		{
			string retFracProcMoneyDivNm = "";
			ArrayList wkListCd = GetFracProcMoneyDivCdList();
			ArrayList wkListNm = GetFracProcMoneyDivNmList();

			for (int ix = 0; ix != wkListCd.Count; ix++)
			{
				if (getFracProcMoneyDivCd == (Int32)wkListCd[ix])
				{
					retFracProcMoneyDivNm = wkListNm[ix].ToString();
					break;
				}
			}
			return retFracProcMoneyDivNm;
		}

		/// <summary>
		/// �[�������敪�R�[�h���X�g�擾����
		/// </summary>
		/// <returns>�[�������敪�R�[�h���X�g</returns>
		/// <remarks>
		/// <br>Note		: �[�������敪�ɂĎg�p����R�[�h�̃��X�g���擾���܂��B</br>
		/// <br>			: �C���f�b�N�X��GetFractionProcCdNmList()�ɂĎ擾�o���閼�̂ƈ�v���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFractionProcCdCdList()
		{
			ArrayList retList = new ArrayList();
			retList.Add(1);
			retList.Add(2);
			retList.Add(3);
			return retList;
		}

		/// <summary>
		/// �[�������敪���̃��X�g�擾����
		/// </summary>
		/// <returns>�[�������敪���̃��X�g</returns>
		/// <remarks>
		/// <br>Note		: �[�������敪�ɂĎg�p���閼�̂̃��X�g���擾���܂��B</br>
		/// <br>			: �C���f�b�N�X��GetFractionProcCdCdList()�ɂĎ擾�o����R�[�h�ƈ�v���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFractionProcCdNmList()
		{
			ArrayList retList = new ArrayList();
			retList.Add("�؎̂�");
			retList.Add("�l�̌ܓ�");
			retList.Add("�؏グ");
			return retList;
		}

		/// <summary>
		/// �[�������敪���̎擾����
		/// </summary>
		/// <returns>�[�������敪���̖���</returns>
		/// <remarks>
		/// <br>Note		: �[�������敪�ɂĎg�p���閼�̂��擾���܂��B</br>
		/// <br>			: �C���f�b�N�X��GetFractionProcCdCdList()�ɂĎ擾�o����R�[�h�ƈ�v���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.22</br>
		/// </remarks>
		public static string GetFractionProcCdNm(Int32 getFractionProcCd)
		{
			string retFractionProcCd = "";
			ArrayList wkListCd = GetFractionProcCdCdList();
			ArrayList wkListNm = GetFractionProcCdNmList();

			for (int ix = 0; ix != wkListCd.Count; ix++)
			{
				if (getFractionProcCd == (Int32)wkListCd[ix])
				{
					retFractionProcCd = wkListNm[ix].ToString();
					break;
				}
			}
			return retFractionProcCd;
		}
    
        /// <summary>
        /// �[�������敪�R�[�h�擾����
        /// </summary>
        /// <returns>�[�������敪�R�[�h</returns>
        /// <remarks>
        /// <br>Note		: �[�������敪�ɂĎg�p����R�[�h���擾���܂��B</br>
        /// <br>			: �C���f�b�N�X��GetFractionProcCdCdList()�ɂĎ擾�o����R�[�h�ƈ�v���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.08.22</br>
        /// </remarks>
        public static int GetFractionProcCd(string getFractionProcCdNm)
        {
            int retFractionProcCd = 0;
            ArrayList wkListCd = GetFractionProcCdCdList();
            ArrayList wkListNm = GetFractionProcCdNmList();

            for (int ix = 0; ix != wkListNm.Count; ix++)
            {
                if (string.Equals(wkListNm[ix].ToString(), getFractionProcCdNm) == true)
                {
                    retFractionProcCd = int.Parse(wkListCd[ix].ToString());
                    break;
                }
            }
            return retFractionProcCd;
        }
    }
}
