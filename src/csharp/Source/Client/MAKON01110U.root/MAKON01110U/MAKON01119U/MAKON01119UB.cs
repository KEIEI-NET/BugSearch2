using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d�����͗p���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����͂̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.17 21024 ���X�� �� MANTIS[0013502] �ۑ���̉�ʏ������̏����l���u����v�ɕύX</br>
    /// <br>2009.07.10 21024 ���X�� �� MANTIS[0013757] �d�����ύX���A���ד`�[���ύX����敪��ǉ�</br>
    /// <br>2009.11.13 30434 �H�� �b�D MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�</br>
    /// <br>2010.01.06 30434 �H�� �b�D MANTIS[0014857] �S���҂�ۑ�����ێ�����ݒ��ǉ�</br>
    /// <br>Update Note: 2014/09/01 �q����</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : redmine�@#43374 �d���`�[����(�ۑ��ネ�S�\������)�̒ǉ��Ή�</br>
    /// <br>UpdateNote : 2017/08/11 杍^  </br>
    /// <br>�Ǘ��ԍ�   : 11370074-00</br>
    /// <br>             �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�</br> 
    /// </remarks>
	[Serializable]
	public class StockSlipInputConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region ��Private Members
		private int _focusPositionValue = DEFAULT_FocusPosition_VALUE;
		private int _dataInputCountValue = DEFAULT_DataInputCount_VALUE;
		private int _stockGoodsCdValue = DEFAULT_StockGoodsCd_VALUE;
		private int _accPayDivCdValue = DEFAULT_AccPayDivCd_VALUE;
		private int _fontSizeValue = DEFAULT_FontSize_VALUE;
		private int _clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
		private int _saveInfoStore = DEFAULT_SaveInfoStore_VALUE;

        private int _saveAgentStore = DEFAULT_SaveAgentStore_VALUE; // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ�

		private int _functionMode = DEFAULT_FunctionMode_VALUE;
		private int _supplierFormalAfterSave = DEFAULT_SupplierFormalAfterSave_VALUE;
        private int _stockGoodsCdAfterSave = DEFAULT_StockGoodsCdAfterSave_VALUE;   // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�
		private int _dateClearAfterSave = DEFAULT_DateClearAfterSave_VALUE;
		private int _supplierFormalValue = DEFAULT_SupplierFormal_VALUE;
        private int _focusPositionAfterSaveValue = DEFAULT_FocusPositionAfterSave_VALUE;
        private int _useStockAgent = DEFAULT_UseStockAgent_VALUE;
        private int _reflectArrivalGoodsDay;    // 2009.07.10 Add

		private HeaderFocusConstructionList _headerFocusConstructionList;

		private const int DEFAULT_FocusPosition_VALUE = 1;
		private const int DEFAULT_DataInputCount_VALUE = 21;
		private const int DEFAULT_SupplierFormal_VALUE = 0;
		private const int DEFAULT_StockGoodsCd_VALUE = 0;
		private const int DEFAULT_AccPayDivCd_VALUE = 1;
		private const int DEFAULT_FontSize_VALUE = 11;
        // 2009.06.17 >>>
		//private const int DEFAULT_ClearAfterSave_VALUE = 0;
        private const int DEFAULT_ClearAfterSave_VALUE = 1;
        // 2009.06.17 <<<
        private const int DEFAULT_SaveInfoStore_VALUE = 0;
        private const int DEFAULT_SaveAgentStore_VALUE = 0; // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ�
		private const int DEFAULT_FunctionMode_VALUE = 0;
		private const int DEFAULT_DateClearAfterSave_VALUE = 1;
		private const int DEFAULT_SupplierFormalAfterSave_VALUE = 0;
        private const int DEFAULT_StockGoodsCdAfterSave_VALUE = 0;  // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�
        private const int DEFAULT_FocusPositionAfterSave_VALUE = 1;
        private const int DEFAULT_UseStockAgent_VALUE = 0;
        // 2009.07.10 Add >>>
        private const int DEFAULT_ReflectArrivalGoodsDay = 0;
        // 2009.07.10 Add <<<
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructors
		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public StockSlipInputConstruction()
		{
			this._focusPositionValue = DEFAULT_FocusPosition_VALUE;
			this._dataInputCountValue = DEFAULT_DataInputCount_VALUE;
			this._stockGoodsCdValue = DEFAULT_StockGoodsCd_VALUE;
			this._accPayDivCdValue = DEFAULT_AccPayDivCd_VALUE;
			this._fontSizeValue = DEFAULT_FontSize_VALUE;
			this._clearAfterSave = DEFAULT_ClearAfterSave_VALUE;
			this._saveInfoStore = DEFAULT_SaveInfoStore_VALUE;
			this._functionMode = DEFAULT_FunctionMode_VALUE;
			this._supplierFormalAfterSave = DEFAULT_SupplierFormalAfterSave_VALUE;
            this._stockGoodsCdAfterSave = DEFAULT_StockGoodsCd_VALUE;   // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�
			this._dateClearAfterSave = DEFAULT_DateClearAfterSave_VALUE;
			this._supplierFormalValue = DEFAULT_SupplierFormal_VALUE;
            this._focusPositionAfterSaveValue = DEFAULT_FocusPositionAfterSave_VALUE;
            this._useStockAgent = DEFAULT_UseStockAgent_VALUE;
            this._reflectArrivalGoodsDay = DEFAULT_ReflectArrivalGoodsDay;  // 2009.07.10 Add

			this._headerFocusConstructionList = new HeaderFocusConstructionList();

		}

		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X
		/// </summary>
		/// <param name="focusPositionValue">�����t�H�[�J�X�ʒu</param>
		/// <param name="dataInputCountValue">�f�[�^���͍s��</param>
		/// <param name="supplierFormalValue">�`�[���</param>
		/// <param name="stockGoodsCdValue">���i�敪</param>
		/// <param name="accPayDivCdValue">���|�敪</param>
		/// <param name="fontSizeValue">�t�H���g�T�C�Y</param>
		/// <param name="clearAfterSave">�ۑ��㏉��������</param>
		/// <param name="saveInfoStore">�ۑ����̕ێ�</param>
		/// <param name="functionMode">�t�@���N�V�������[�h</param>
		/// <param name="headerFocusConstructionList">�w�b�_�t�H�[�J�X�ݒ胊�X�g</param>
		/// <param name="supplierFormalAfterSave">�ۑ���̎d���`��</param>
		/// <param name="dateClearAfterSave">�ۑ���̓��t������</param>
        /// <param name="focusPositionAfterSave">�ۑ���̃t�H�[�J�X�ʒu</param>
        /// <param name="useStockAgent">�d����S���҂̎g�p</param>
        /// <param name="reflectArrivalGoodsDay">�d�����ύX���̓��ד��ւ̔��f</param>
        /// <param name="stockGoodsCdAfterSave">�ۑ���̓��͋敪</param>
		/// <remarks>
		/// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
        /// <br>2009.11.13 30434 �H�� �b�D MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�</br>
		/// </remarks>
        // 2009.07.10 >>>
        //public StockSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int supplierFormalValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int functionMode, HeaderFocusConstructionList headerFocusConstructionList, int supplierFormalAfterSave, int dateClearAfterSave, int focusPositionAfterSave, int useStockAgent)
        public StockSlipInputConstruction(int focusPositionValue, int dataInputCountValue, int supplierFormalValue, int stockGoodsCdValue, int accPayDivCdValue, int fontSizeValue, int clearAfterSave, int saveInfoStore, int functionMode, HeaderFocusConstructionList headerFocusConstructionList, int supplierFormalAfterSave, int dateClearAfterSave, int focusPositionAfterSave, int useStockAgent, int reflectArrivalGoodsDay, int stockGoodsCdAfterSave)
        // 2009.07.10 <<<
        {
			this._focusPositionValue = focusPositionValue;
			this._dataInputCountValue = dataInputCountValue;
			this._supplierFormalValue = supplierFormalValue;
			this._stockGoodsCdValue = stockGoodsCdValue;
			this._accPayDivCdValue = accPayDivCdValue;
			this._fontSizeValue = fontSizeValue;
			this._clearAfterSave = clearAfterSave;
			this._saveInfoStore = saveInfoStore;
			this._functionMode = functionMode;
			this._headerFocusConstructionList = HeaderFocusConstructionList;
			this._supplierFormalAfterSave = supplierFormalAfterSave;
			this._dateClearAfterSave = dateClearAfterSave;
            this._focusPositionAfterSaveValue = focusPositionAfterSave;
            this._useStockAgent = useStockAgent;
            this._reflectArrivalGoodsDay = reflectArrivalGoodsDay;  // 2009.07.10 Add
            this._stockGoodsCdAfterSave = stockGoodsCdAfterSave;    // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�
		}

        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ---------->>>>>
        // public�N���X��public�R���X�g���N�^�ł��邽�߁A��I/F���c��
        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X
        /// </summary>
        /// <param name="focusPositionValue">�����t�H�[�J�X�ʒu</param>
        /// <param name="dataInputCountValue">�f�[�^���͍s��</param>
        /// <param name="supplierFormalValue">�`�[���</param>
        /// <param name="stockGoodsCdValue">���i�敪</param>
        /// <param name="accPayDivCdValue">���|�敪</param>
        /// <param name="fontSizeValue">�t�H���g�T�C�Y</param>
        /// <param name="clearAfterSave">�ۑ��㏉��������</param>
        /// <param name="saveInfoStore">�ۑ����̕ێ�</param>
        /// <param name="functionMode">�t�@���N�V�������[�h</param>
        /// <param name="headerFocusConstructionList">�w�b�_�t�H�[�J�X�ݒ胊�X�g</param>
        /// <param name="supplierFormalAfterSave">�ۑ���̎d���`��</param>
        /// <param name="dateClearAfterSave">�ۑ���̓��t������</param>
        /// <param name="focusPositionAfterSave">�ۑ���̃t�H�[�J�X�ʒu</param>
        /// <param name="useStockAgent">�d����S���҂̎g�p</param>
        /// <param name="reflectArrivalGoodsDay">�d�����ύX���̓��ד��ւ̔��f</param>
        public StockSlipInputConstruction(
            int focusPositionValue,
            int dataInputCountValue,
            int supplierFormalValue,
            int stockGoodsCdValue,
            int accPayDivCdValue,
            int fontSizeValue,
            int clearAfterSave,
            int saveInfoStore,
            int functionMode,
            HeaderFocusConstructionList headerFocusConstructionList,
            int supplierFormalAfterSave,
            int dateClearAfterSave,
            int focusPositionAfterSave,
            int useStockAgent,
            int reflectArrivalGoodsDay
        ) : this(
            focusPositionValue,
            dataInputCountValue,
            supplierFormalValue,
            stockGoodsCdValue,
            accPayDivCdValue,
            fontSizeValue,
            clearAfterSave,
            saveInfoStore,
            functionMode,
            headerFocusConstructionList,
            supplierFormalAfterSave,
            dateClearAfterSave,
            focusPositionAfterSave,
            useStockAgent,
            reflectArrivalGoodsDay,
            DEFAULT_StockGoodsCd_VALUE
        ) { }
        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ----------<<<<<

		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region ��Properties
		/// <summary>�����t�H�[�J�X�ʒu</summary>
		public int FocusPositionValue
		{
			get { return this._focusPositionValue; }
			set { this._focusPositionValue = value; }
		}

		/// <summary>�f�[�^���͍s��</summary>
		public int DataInputCountValue
		{
			get { return this._dataInputCountValue; }
			set { this._dataInputCountValue = value; }
		}

		/// <summary>�d���`��</summary>
		public int SupplierFormalValue
		{
			get { return this._supplierFormalValue; }
			set { this._supplierFormalValue = value; }
		}

		/// <summary>���i�敪</summary>
		public int StockGoodsCdValue
		{
			get { return this._stockGoodsCdValue; }
			set { this._stockGoodsCdValue = value; }
		}

		/// <summary>���|�敪</summary>
		public int AccPayDivCdValue
		{
			get { return this._accPayDivCdValue; }
			set { this._accPayDivCdValue = value; }
		}

		/// <summary>�t�H���g�T�C�Y</summary>
		public int FontSizeValue
		{
			get { return this._fontSizeValue; }
			set { this._fontSizeValue = value; }
		}

		/// <summary>�ۑ��㏉��������</summary>
		public int ClearAfterSave
		{
			get { return this._clearAfterSave; }
			set { this._clearAfterSave = value; }
		}

		/// <summary>�ۑ����̋L��</summary>
		public int SaveInfoStoreValue
		{
			get { return this._saveInfoStore; }
			set { this._saveInfoStore = value; }
		}

        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ---------->>>>>
        /// <summary>�ۑ��S���҂̋L��</summary>
        public int SaveAgentStoreValue
        {
            get { return this._saveAgentStore; }
            set { this._saveAgentStore = value; }
        }
        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ----------<<<<<

		/// <summary>�t�@���N�V�������[�h</summary>
		public int FunctionMode
		{
			get { return this._functionMode; }
			set { this._functionMode = value; }
		}

		/// <summary>�ۑ���̎d���`��</summary>
		public int SupplierFormalAfterSave
		{
			get { return this._supplierFormalAfterSave; }
			set { this._supplierFormalAfterSave = value; }
		}

        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ---------->>>>>
        /// <summary>�ۑ���̓��͋敪</summary>
        public int StockGoodsCdAfterSave
        {
            get { return this._stockGoodsCdAfterSave; }
            set { this._stockGoodsCdAfterSave = value; }
        }
        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ----------<<<<<

		/// <summary>�ۑ���̓��t������</summary>
		public int DateClearAfterSave
		{
			get { return this._dateClearAfterSave; }
			set { this._dateClearAfterSave = value; }
		}

        /// <summary>�ۑ���̃t�H�[�J�X�ʒu</summary>
        public int FocusPositionAfterSave
        {
            get { return this._focusPositionAfterSaveValue; }
            set { this._focusPositionAfterSaveValue = value; }
        }
        
        /// <summary>�d����S���҂̎g�p</summary>
        public int UseStockAgent
        {
            get { return this._useStockAgent; }
            set { this._useStockAgent = value; }
        }

		/// <summary>�w�b�_�t�H�[�J�X�ݒ胊�X�g</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionList
		{
			get { return this._headerFocusConstructionList; }
			set { this._headerFocusConstructionList = value; }
		}

        // 2009.07.10 Add >>>
        /// <summary>���ד��֔��f</summary>
        public int ReflectArrivalGoodsDay
        {
            get { return _reflectArrivalGoodsDay; }
            set { _reflectArrivalGoodsDay = value; }
        }
        // 2009.07.10 Add <<<

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region ��Public Methods
		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X��������
		/// </summary>
		/// <returns>�d�����͗p���[�U�[�ݒ�N���X</returns>
		public StockSlipInputConstruction Clone()
		{
            return new StockSlipInputConstruction(
                this._focusPositionValue,
                this._dataInputCountValue,
                this._supplierFormalValue,
                this._stockGoodsCdValue,
                this._accPayDivCdValue,
                this._fontSizeValue,
                this._clearAfterSave,
                this._saveInfoStore,
                this._functionMode,
                this._headerFocusConstructionList,
                this._supplierFormalAfterSave,
                this._dateClearAfterSave,
                this._focusPositionAfterSaveValue,
                // 2009.07.10 >>>
                //this._useStockAgent);
                this._useStockAgent,
                this._reflectArrivalGoodsDay,
                this._stockGoodsCdAfterSave // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�
                );
                // 2009.07.10 <<<
        }
		# endregion
	}

	/// <summary>
	/// �d�����͗p�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����͂̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.10 21024 ���X�� �� MANTIS[0013757] �d�����ύX���A���ד`�[���ύX����敪��ǉ�</br>
    /// <br>2009.11.13 30434 �H�� �b�D MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ�</br>
    /// <br>2010.01.06 30434 �H�� �b�D MANTIS[0014857] �S���҂�ۑ�����ێ�����ݒ��ǉ�</br>
    /// <br>UpdateNote  : 2017/08/11 杍^  </br>
    /// <br>�Ǘ��ԍ�    : 11370074-00</br>
    /// <br>              �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�</br> 
    /// </remarks>
	public class StockSlipInputConstructionAcs
	{
		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region ��Public Const
		/// <summary>�����t�H�[�J�X�ʒu�i���_�j</summary>
		public const int ForcusPosition_SectionCode = 0;
        /// <summary>�����t�H�[�J�X�ʒu�i�S���ҁj</summary>
        public const int ForcusPosition_StockAgentCode = 1;
        /// <summary>�����t�H�[�J�X�ʒu�i�d����j</summary>
		public const int ForcusPosition_SupplierCode = 2;
        /// <summary>�����t�H�[�J�X�ʒu�i�d��SEQ�ԍ��j</summary>
        public const int ForcusPosition_SupplierSlipNo = 3;
        /// <summary>�����t�H�[�J�X�ʒu�i�`�[��ʁj</summary>
		public const int ForcusPosition_SupplierFormal = 4;
        /// <summary>�����t�H�[�J�X�ʒu�i�`�[�ԍ��j</summary>
        public const int ForcusPosition_PartySaleSlipNum = 5;

		/// <summary>�ۑ��㏉���������i���Ȃ��j</summary>
		public const int ClearAfterSave_OFF = 0;
		/// <summary>�ۑ��㏉���������i����j</summary>
		public const int ClearAfterSave_ON = 1;

		/// <summary>�ۑ���̓`�[��ʁi���ɖ߂��j</summary>
		public const int SupplierFormalAfterSave_Init = 0;
		/// <summary>�ۑ���̓`�[��ʁi���͒l�̂܂܁j</summary>
		public const int SupplierFormalAfterSave_Keep = 1;

        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ---------->>>>>
        /// <summary>�ۑ���̓��͋敪�i���ɖ߂��j</summary>
        public const int StockGoodsCdAfterSave_Init = 0;
        /// <summary>�ۑ���̓��͋敪�i���͒l�̂܂܁j</summary>
        public const int StockGoodsCdAfterSave_Keep = 1;
        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ----------<<<<<

		/// <summary>�ۑ���̓��t�������i�d���݌ɑS�̐ݒ�Q�Ɓj</summary>
		public const int DateClearAfterSave_Default = 0;
		/// <summary>�ۑ���̓��t�������i�V�X�e�����t�ɖ߂��j</summary>
		public const int DateClearAfterSave_ON = 1;
		/// <summary>�ۑ���̓��t�������i���͓��t�̂܂܁j</summary>
		public const int DateClearAfterSave_OFF = 2;

        /// <summary>�ۑ���̃t�H�[�J�X�ʒu�i�����l�ɖ߂��j</summary>
        public const int FocusPositionAfterSave_Detault = 0;
        /// <summary>�ۑ���̃t�H�[�J�X�ʒu�i�`�[�ԍ��j</summary>
        public const int FocusPositionAfterSave_PartySaleSlipNum = 1;

        /// <summary>�d����S���҂̎g�p�i���Ȃ��j</summary>
        public const int UseStockAgent_OFF = 0;
        /// <summary>�d����S���҂̎g�p�i����j</summary>
        public const int UseStockAgent_ON = 1;

		/// <summary>�ۑ������̋L���i���Ȃ��j</summary>
		public const int SaveInfoStore_OFF = 0;
		/// <summary>�ۑ������̋L���i����j</summary>
		public const int SaveInfoStore_ON = 1;

        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ---------->>>>>
        /// <summary>�O��ۑ����̒S���҂̋L���i���Ȃ��j</summary>
        public const int SaveAgentStore_OFF = 0;
        /// <summary>�O��ۑ����̒S���҂̋L���i����j</summary>
        public const int SaveAgentStore_ON = 1;
        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ----------<<<<<

        // 2009.07.10 >>>
        /// <summary>�d�����ύX���ɓ��ד��֔��f�i�������j</summary>
        public const int ReflectArrivalGoodsDay_ON = 0;
        /// <summary>�d�����ύX���ɓ��ד��֔��f�i�v��������j</summary>
        public const int ReflectArrivalGoodsDay_ExcludeAppropriate = 1;
        /// <summary>�d�����ύX���ɓ��ד��֔��f�i���Ȃ��j</summary>
        public const int ReflectArrivalGoodsDay_OFF = 2;
        // 2009.07.10 <<<

		# endregion

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���萔�i�n���f�B�^�[�~�i���p�j
        /// <summary>�n���f�B�^�[�~�i���R���X�g���N�^�̃��[�h</summary>
        private const string ConstructorsModeHandy = "Handy";
        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

        // ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region ��Private Members

		private StockSlipInputConstruction _stockSlipInputConstruction;
		private static StockSlipInputConstructionAcs _stockSlipInputConstructionAcs;
		private const string XML_FILE_NAME = "MAKON01112A_Construction.XML";
		private Dictionary<string, Control> _headerItemsDictionary;

		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructors
		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private StockSlipInputConstructionAcs()
		{
			_stockSlipInputConstruction = new StockSlipInputConstruction();
			_headerItemsDictionary = new Dictionary<string, Control>();
			this.Deserialize();
		}

		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns>�d�����͗p���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
		public static StockSlipInputConstructionAcs GetInstance()
		{
			if (_stockSlipInputConstructionAcs == null)
			{
				_stockSlipInputConstructionAcs = new StockSlipInputConstructionAcs();
			}

			return _stockSlipInputConstructionAcs;
		}
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region ��Delegate
		/// <summary>���񃊃X�g�擾�擾�C�x���g</summary>
		public delegate List<ColDisplayInfo> GetColDisplayInfoEventHandler();
		/// <summary>���񃊃X�g�Z�b�g�C�x���g</summary>
		public delegate void SetColDisplayInfoEventHandler( List<ColDisplayInfo> colDisplayInfoList );
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region�� Event
		/// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
		public event EventHandler DataChanged;
		/// <summary>�񏉊����擾�C�x���g</summary>
		public event GetColDisplayInfoEventHandler GetColDisplayInfoInitList;
		/// <summary>��ŐV���擾�C�x���g</summary>
		public event GetColDisplayInfoEventHandler GetColDisplayInfoList;
		/// <summary>��ŐV���ݒ�C�x���g</summary>
		public event SetColDisplayInfoEventHandler SetColDisplayInfoList;

		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region ��Properties
		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X
		/// </summary>
		public StockSlipInputConstruction StockInputConstruction
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.Clone();
			}
		}

		/// <summary>�����t�H�[�J�X�ʒu</summary>
		public int FocusPositionValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.FocusPositionValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.FocusPositionValue = value;
			}
		}

		/// <summary>�f�[�^���͍s��</summary>
		public int DataInputCountValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.DataInputCountValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.DataInputCountValue = value;
			}
		}

		/// <summary>�`�[���</summary>
		public int SupplierFormalValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.SupplierFormalValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.SupplierFormalValue = value;
			}
		}

		/// <summary>���i�敪</summary>
		public int StockGoodsCdValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.StockGoodsCdValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.StockGoodsCdValue = value;
			}
		}

		/// <summary>���|�敪</summary>
		public int AccPayDivCdValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.AccPayDivCdValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.AccPayDivCdValue = value;
			}
		}

		/// <summary>�t�H���g�T�C�Y</summary>
		public int FontSizeValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.FontSizeValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.FontSizeValue = value;
			}
		}

		/// <summary>�ۑ��㏉��������</summary>
		public int ClearAfterSaveValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.ClearAfterSave;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.ClearAfterSave = value;
			}
		}

		/// <summary>�ۑ������L��</summary>
		public int SaveInfoStoreValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.SaveInfoStoreValue;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.SaveInfoStoreValue = value;
			}
		}

        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ---------->>>>>
        /// <summary>�ۑ����S���ҋL��</summary>
        public int SaveAgentStoreValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.SaveAgentStoreValue;
            }
            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.SaveAgentStoreValue = value;
            }
        }
        // ADD 2010/01/06 MANTIS�Ή�[14857]�F�S���҂�ۑ�����ێ�����ݒ��ǉ� ----------<<<<<

		/// <summary>�t�@���N�V�������[�h</summary>
		public int FunctionModeValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.FunctionMode;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.FunctionMode = value;
			}
		}

		/// <summary>�ۑ���̎d���`��</summary>
		public int SupplierFormalAfterSaveValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.SupplierFormalAfterSave;

			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.SupplierFormalAfterSave = value;
			}
		}

        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ---------->>>>>
        /// <summary>�ۑ���̓��͋敪</summary>
        public int StockGoodsCdAfterSaveValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.StockGoodsCdAfterSave;

            }
            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.StockGoodsCdAfterSave = value;
            }
        }
        // ADD 2009/11/13 MANTIS[0013983] ���͋敪�̕ێ��@�\��ǉ� ----------<<<<<

		/// <summary>�ۑ���̓��t������</summary>
		public int DateClearAfterSaveValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				return _stockSlipInputConstruction.DateClearAfterSave;

			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.DateClearAfterSave = value;
			}
		}

        /// <summary>�ۑ���̃t�H�[�J�X�ʒu</summary>
        public int FocusPositionAfterSaveValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.FocusPositionAfterSave;
            }
            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.FocusPositionAfterSave = value;
            }
        }

        /// <summary>�d����S���҂̎g�p</summary>
        public int UseStockAgentValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.UseStockAgent;
            }

            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.UseStockAgent = value;
            }
        }

        // 2009.07.10 Add >>>
        /// <summary>�d�����ύX���ɓ��ד��֔��f</summary>
        public int ReflectArrivalGoodsDayValue
        {
            get
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                return _stockSlipInputConstruction.ReflectArrivalGoodsDay;
            }

            set
            {
                if (_stockSlipInputConstruction == null)
                {
                    _stockSlipInputConstruction = new StockSlipInputConstruction();
                }
                _stockSlipInputConstruction.ReflectArrivalGoodsDay = value;
            }
        }
        // 2009.07.10 Add <<<

		/// <summary>�w�b�_�t�H�[�J�X�ݒ胊�X�g</summary>
		public HeaderFocusConstructionList HeaderFocusConstructionListValue
		{
			get
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}

                if (_stockSlipInputConstruction.HeaderFocusConstructionList.headerFocusConstruction.Count == 0)
                {
                    _stockSlipInputConstruction.HeaderFocusConstructionList.headerFocusConstruction = this.MakeHeaderFocusConstructionListFromHeaderItemsDictionary(this._headerItemsDictionary);
                }

				return _stockSlipInputConstruction.HeaderFocusConstructionList;
			}
			set
			{
				if (_stockSlipInputConstruction == null)
				{
					_stockSlipInputConstruction = new StockSlipInputConstruction();
				}
				_stockSlipInputConstruction.HeaderFocusConstructionList = value;
			}
		}

		/// <summary>���ח��񏉊���񃊃X�g</summary>
		public List<ColDisplayInfo> ColDisplayInfoInitList
		{
			get 
			{
				if (this.GetColDisplayInfoInitList != null)
				{
					return GetColDisplayInfoInitList();
				}
				else
				{
					return null; 
				}
				
			}
		}

		/// <summary>���ח��񃊃X�g</summary>
		public List<ColDisplayInfo> ColDisplayInfoList
		{
			get 
			{
				if (this.GetColDisplayInfoList != null)
				{
					return this.GetColDisplayInfoList();
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (this.SetColDisplayInfoList != null)
				{
					this.SetColDisplayInfoList(value);
				}
			}
		}

		/// <summary>�w�b�_����Dictionary</summary>
		public Dictionary<string, Control> HeaderItemsDictionary
		{
			get { return this._headerItemsDictionary; }
			set { this._headerItemsDictionary = value; }
		}

		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region ��Public Methods

		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.05.21</br>
		/// </remarks>
		public void Serialize()
		{
			UserSettingController.SerializeUserSetting(_stockSlipInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

			if (DataChanged != null)
			{
				// �f�[�^�ύX�㔭���C�x���g���s
				DataChanged(this, new EventArgs());
			}
		}

		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.07.19</br>
		/// </remarks>
		public void Deserialize()
		{
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
                try
                {
                    _stockSlipInputConstruction = UserSettingController.DeserializeUserSetting<StockSlipInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
            }
		}

		/// <summary>
		/// �d�����͗p���[�U�[�ݒ�N���X�ݒ�t�@�C�����݃`�F�b�N
		/// </summary>
		/// <returns>True:���[�U�[�ݒ�t�@�C������</returns>
		public bool IsUserSettingExists()
		{
			bool ret = false;
			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
			{
				ret = true;
			}
			return ret;
		}
		# endregion

        //
        #region ��Internal & Private Methods

        /// <summary>
        /// HeaderFocusConstruction���X�g����
        /// </summary>
        /// <param name="headerItemsDictionary">�w�b�_�[�A�C�e���f�B�N�V���i��</param>
        /// <returns>HeaderFocusConstruction���X�g</returns>
        internal List<HeaderFocusConstruction> MakeHeaderFocusConstructionListFromHeaderItemsDictionary( Dictionary<string, Control> headerItemsDictionary )
        {
            List<HeaderFocusConstruction> retHeaderFocusConstructionList = new List<HeaderFocusConstruction>();

            if (headerItemsDictionary != null)
            {
                int index = 0;
                SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
                foreach (string key in headerItemsDictionary.Keys)
                {
                    Control control = headerItemsDictionary[key];
                    sortedDictionary.Add(index, key);
                    index++;
                }

                foreach (int keyIndex in sortedDictionary.Keys)
                {
                    string key = sortedDictionary[keyIndex];
                    HeaderFocusConstruction headerFocusConstruction = new HeaderFocusConstruction();
                    Control control = headerItemsDictionary[key];
                    headerFocusConstruction.Key = control.Name;
                    headerFocusConstruction.Caption = key;
                    headerFocusConstruction.EnterStop = true;
                    retHeaderFocusConstructionList.Add(headerFocusConstruction);
                }
            }
            return retHeaderFocusConstructionList;
        }
        #endregion

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        #region ���n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�
        // ===================================================================================== //
        // �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        // ===================================================================================== //
        # region ��Constracter
        /// <summary>
        /// �R���X�g���N�^�i�n���f�B�^�[�~�i���p�j
        /// </summary>
        /// <param name="mode">���͋@�\���[�h</param>
        /// <remarks>
        /// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B�i�n���f�B�^�[�~�i���p�j</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public StockSlipInputConstructionAcs(string mode)
        {
            // ���͋@�\���[�h�̓n���f�B�^�[�~�i���ꍇ
            if (ConstructorsModeHandy.Equals(mode))
            {
                _stockSlipInputConstruction = new StockSlipInputConstruction();
                _headerItemsDictionary = new Dictionary<string, Control>();
                this.Deserialize();
            }
        }
        #endregion

        #endregion
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
    }

    // --- ADD  �q�����@For redmine #43374 �d���`�[����(�ۑ��ネ�S�\������) ------>>>>>
    /// <summary>
    /// �d�����͗p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͂̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : �q����</br>
    /// <br>Date       : 2014/09/01</br>
    /// </remarks>
    public class StockSlipInputConstructionLog
    {
        // �v���C�x�[�g�ϐ�
        # region ��Private Members
        private int _logoDisp = DEFAULT_LogoDisp_VALUE;
        private int _logoDispTime = DEFAULT_LogoDispTime_VALUE;
        private const int DEFAULT_LogoDisp_VALUE = 0;  //�ۑ���̃��S�\��
        private const int DEFAULT_LogoDispTime_VALUE = 2;�@�@//�ۑ���̃��S�\������(�f�t�H���g�l)
        # endregion

        // �R���X�g���N�^
        # region ��Constructors
        /// <summary>
        /// �V�����C���X�^���X�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �q����</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public StockSlipInputConstructionLog()
        {
            this._logoDisp = DEFAULT_LogoDisp_VALUE;
            this._logoDispTime = DEFAULT_LogoDispTime_VALUE;
        }

        /// <summary>
        /// �V�����C���X�^���X�̏����������Q
        /// </summary>      
        /// <remarks>
        /// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �q����</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public StockSlipInputConstructionLog(int logoDisp, int logoDispTime)
        {
            this._logoDisp = logoDisp;
            this._logoDispTime = logoDispTime;
        }
        
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>�ۑ���̃��S�\��</summary>
        public int LogoDisp
        {
            get { return _logoDisp; }
            set { _logoDisp = value; }
        }
        /// <summary>�ۑ���̃��S�\������</summary>
        public int LogoDispTime
        {
            get { return _logoDispTime; }
            set { _logoDispTime = value; }
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ��Public Methods
        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X��������
        /// </summary>
        /// <returns>�d�����͗p���[�U�[�ݒ�N���X</returns>
        public StockSlipInputConstructionLog Clone()
        {
            return new StockSlipInputConstructionLog(
                this._logoDisp,
                this._logoDispTime              
                );
        }
        # endregion
    }
    /// <summary>
    /// �d�����͗p�ݒ�A�N�Z�X�N���X
    /// </summary>
    public class StockSlipInputConstructionAcsLog
    {
        public const int LogoDisp_ON = 0;
        public const int LogoDisp_OFF = 1;

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private StockSlipInputConstructionLog _stockSlipInputConstructionLog;
        private static StockSlipInputConstructionAcsLog _stockSlipInputConstructionAcsLog;
        private const string XML_FILE_NAME_LOGO = "SFMIT01210_Settings.xml";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private StockSlipInputConstructionAcsLog()
        {
            _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
            this.Deserialize();
        }
        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : �q����</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void Deserialize()
        {            
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO)))
            {
                try
                {
                    _stockSlipInputConstructionLog = UserSettingController.DeserializeUserSetting<StockSlipInputConstructionLog>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO));
                }
            }
        }

        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�����͗p���[�U�[�ݒ�A�N�Z�X�N���X �C���X�^���X�擾�������܂��B</br>
        /// <br>Programmer : �q����</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public static StockSlipInputConstructionAcsLog GetInstance()
        {
            if (_stockSlipInputConstructionAcsLog == null)
            {
                _stockSlipInputConstructionAcsLog = new StockSlipInputConstructionAcsLog();
            }

            return _stockSlipInputConstructionAcsLog;
        }
        # endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        # region�� Event
        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X
        /// </summary>
        public StockSlipInputConstructionLog StockInputConstructionLog
        {
            get
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                return _stockSlipInputConstructionLog.Clone();
            }
        }

        /// <summary>�ۑ���̃��S�\��</summary>
        public int LogoDispValue
        {
            get
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                return _stockSlipInputConstructionLog.LogoDisp;
            }

            set
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                _stockSlipInputConstructionLog.LogoDisp = value;
            }
        }
        /// <summary>�ۑ���̃��S�\������</summary>
        public int LogoDispTimeValue
        {
            get
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                return _stockSlipInputConstructionLog.LogoDispTime;
            }

            set
            {
                if (_stockSlipInputConstructionLog == null)
                {
                    _stockSlipInputConstructionLog = new StockSlipInputConstructionLog();
                }
                _stockSlipInputConstructionLog.LogoDispTime = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        /// <summary>
        /// �d�����͗p���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�����͗p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : �q����</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_stockSlipInputConstructionLog, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME_LOGO));

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }
    }
    // --- ADD  �q�����@For redmine #43374 �d���`�[����(�ۑ��ネ�S�\������) ------<<<<<
    
    
}
