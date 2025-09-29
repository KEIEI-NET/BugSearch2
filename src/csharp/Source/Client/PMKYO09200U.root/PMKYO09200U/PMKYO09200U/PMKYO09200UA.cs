//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�Ώېݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ����M�Ώېݒ�̕ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/25  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/25  �C�����e : Redmine #23998 �݌Ɉړ��f�[�^�̎�M�敪�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/09/20  �C�����e : Redmine #25368 �u����M�Ώېݒ�v�̍X�V���ڂ̐���ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : ���O
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ����M�Ώېݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ����M�Ώېݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
	/// <br>Programmer	: ���M</br>
	/// <br>Date		: 2009.04.22</br>
	/// <br>Update Note : ���� 2011.07.25</br>
	/// <br>            : SCM�Ή��]���_�Ǘ��i10704767-00�j</br>
    /// <br>Update Note : 2020/09/25 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11600006-00</br>
    /// <br>            : PMKOBETSU-3877�̑Ή�</br>
	/// <br></br>
	/// </remarks>
	public partial class PMKYO09200UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{

		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ����M�Ώېݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: ����M�Ώېݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public PMKYO09200UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = false;
			this._canNew = false;
			this._canDelete = false;
			this._canClose = true;
			this._defaultAutoFillToColumn = false;
			this._canSpecificationSearch = false;
			this._canLogicalDeleteDataExtraction = false;

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._dataIndex = -1;
			this._sendSetAcs = new SendSetAcs();
			this._totalCount = 0;
			this._sendSetTable = new Hashtable();
			_secMngSndRcvDtlList = new List<SecMngSndRcvDtl>();
			_secMngSndRcvList = new List<SecMngSndRcv>();
			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			_newSndRcvList = new List<SecMngSndRcv>();
			_newSndRcvDtlList = new List<SecMngSndRcvDtl>();
			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;
		}

		#endregion

		#region -- Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		/*----------------------------------------------------------------------------------*/
		private SendSetAcs _sendSetAcs;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _sendSetTable;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// �ۑ���r�pClone
		private SecMngSndRcv _sendSetClone;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

		// View�pGrid�ɕ\��������e�[�u����
		private const string VIEW_TABLE = "VIEW_TABLE";

		// Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
		private const string VIEW_NAME_TITLE = "�f�[�^�E�}�X�^����";
		private const string VIEW_SEND_TITLE = "���M�敪";
		private const string VIEW_RECEIVED_TITLE = "��M�敪";
		private const string VIEW_SORTS_TITLE = "�\������";
		private const string VIEW_FILEID_TITLE = "�t�@�C���h�c";
		private const string VIEW_FILENM_TITLE = "�t�@�C������";
		private const string VIEW_USERGUIDEDIVCD_TITLE = "���[�U�[�K�C�h�敪";
		private const string VIEW_GUID_KEY_TITLE = "Guid";
        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
        private const string VIEW_ACPTANODSEND_TITLE = "�󒍃f�[�^���M�敪";
        private const string VIEW_ACPTANODRECEIVED_TITLE = "�󒍃f�[�^��M�敪";
        private const string VIEW_SHIPMENTSEND_TITLE = "�ݏo�f�[�^���M�敪";
        private const string VIEW_SHIPMENTRECEIVED_TITLE = "�ݏo�f�[�^��M�敪";
        private const string VIEW_ESTIMATESEND_TITLE = "���σf�[�^���M�敪";
        private const string VIEW_ESTIMATERECEIVED_TITLE = "���σf�[�^��M�敪";
        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

		//�q��ʗpGrid���KEY���
		private const string COLUMN_FILEID = "FileId";
		private const string COLUMN_FILENM = "FileNm";
		private const string COLUMN_ITEMID = "ItemId";
		private const string COLUMN_ITEMNAME = "ItemName";
		private const string COLUMN_UPDATECD = "UpdateCd";
		//����M�Ώۏڍ׃}�X�^
		List<SecMngSndRcvDtl> _secMngSndRcvDtlList;
		//����M�Ώۃ}�X�^
		List<SecMngSndRcv> _secMngSndRcvList;

		// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
		/// <summary>
		/// _callForm
		/// </summary>
		public bool _callForm = false;
		/// <summary>
		/// _callPara
		/// </summary>
		public int _callPara = 0;
		private List<SecMngSndRcvDtl> _newSndRcvDtlList;
		private List<SecMngSndRcv> _newSndRcvList;
		// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

		#endregion

		#region -- Properties --
		/*----------------------------------------------------------------------------------*/
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{
				this._canClose = value;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get
			{
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
				return this._defaultAutoFillToColumn;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}
		# endregion

		#region -- Public Methods --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
		///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			// �I�t���C����ԃ`�F�b�N
			if (!CheckOnline())
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOP,
					this.Text,
					this.Text + "��ʌ��������Ɏ��s���܂����B",
					(int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return -1;
			}

			int status = 0;

			List<SecMngSndRcv> sentSets = null;
			List<SecMngSndRcvDtl> sentDtlSets = null;
			List<SecMngSndRcv> _sentSets = new List<SecMngSndRcv>();

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
			this._sendSetTable.Clear();

			status = this._sendSetAcs.SearchAll(out sentSets, out sentDtlSets, this._enterpriseCode);
			this._totalCount = sentSets.Count;

			switch (status)
			{
				case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
					{
						int index = 0;

						_sentSets = GetDisplayList(sentSets);

						foreach (SecMngSndRcv sentSet in _sentSets)
						{
							SendSetToDataSet(sentSet.Clone(), index);
							++index;
						}

						_secMngSndRcvList = sentSets;
						_secMngSndRcvDtlList = sentDtlSets;

						break;
					}
				case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
					{
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

						break;
					}
				default:
					{
						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
							"PMKYO09200U",							// �A�Z���u��ID
							"����M�Ώېݒ�",              �@�@     // �v���O��������
							"Search",                               // ��������
							TMsgDisp.OPE_GET,                       // �I�y���[�V����
							"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
							status,									// �X�e�[�^�X�l
							this._sendSetAcs,					    // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,					// �\������{�^��
							MessageBoxDefaultButton.Button1);		// �����\���{�^��

						break;
					}
			}

			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B(������)</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public int Delete()
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note        : ������������s���܂��B(������)</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();
			appearanceTable.Add(VIEW_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SEND_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_RECEIVED_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SORTS_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_FILEID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_FILENM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_USERGUIDEDIVCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            appearanceTable.Add(VIEW_ACPTANODSEND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ACPTANODRECEIVED_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_SHIPMENTSEND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_SHIPMENTRECEIVED_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ESTIMATESEND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ESTIMATERECEIVED_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			if (_callForm && (_callPara != 0))
			{
				List<SecMngSndRcvDtl> allSndRcvDtlList = new List<SecMngSndRcvDtl>();
				List<SecMngSndRcv> allSndRcvList = new List<SecMngSndRcv>();
				int status = _sendSetAcs.SearchAll(out allSndRcvList, out allSndRcvDtlList, this._enterpriseCode);

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					if (allSndRcvList != null && allSndRcvList.Count > 0)
					{
						//����M�Ώ�
						foreach (SecMngSndRcv myresult in allSndRcvList)
						{
							if (myresult.DisplayOrder == _callPara)
							{
								_newSndRcvList.Add(myresult);
							}
						}
					}
					if (allSndRcvDtlList != null && allSndRcvDtlList.Count > 0)
					{
						//����M�Ώۏڍ�
						foreach (SecMngSndRcv sndRcv in _newSndRcvList)
						{
							foreach (SecMngSndRcvDtl result in allSndRcvDtlList)
							{
								if (result.FileId.Equals(sndRcv.FileId))
								{
									_newSndRcvDtlList.Add(result);
								}
							}
						}
					}
					if (_newSndRcvList != null && _newSndRcvList.Count > 0)
					{
						// �t�@�C������
						this.FileName_tEdit.Text = _newSndRcvList[0].MasterName;

						//���M�敪
						this.SendCode_uOption.Value = (object)_newSndRcvList[0].SecMngSendDiv;

						//��M�敪
						ReceivedCode_tComEditorInit(_newSndRcvList[0].DisplayOrder);

						this.ReceivedCode_tComEditor.Value = (object)_newSndRcvList[0].SecMngRecvDiv;

                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                        //�󒍃f�[�^���M�敪
                        this.AcptAnOdrSend_tComEditor.Value = (object)_newSndRcvList[0].AcptAnOdrSendDiv;
                        //�󒍃f�[�^��M�敪
                        this.AcptAnOdrReceived_tComEditor.Value = (object) _newSndRcvList[0].AcptAnOdrRecvDiv;
                        //�ݏo�f�[�^���M�敪
                        this.ShipmentSend_tComEditor.Value = (object)_newSndRcvList[0].ShipmentSendDiv;
                        //�ݏo�f�[�^��M�敪
                        this.ShipmentReceived_tComEditor.Value = (object)_newSndRcvList[0].ShipmentRecvDiv;
                        //���σf�[�^���M�敪
                        this.EstimateSend_tComEditor.Value = (object)_newSndRcvList[0].EstimateSendDiv;
                        //���σf�[�^��M�敪
                        this.EstimateReceived_tComEditor.Value = (object)_newSndRcvList[0].EstimateRecvDiv;
                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
					}

					this.uGrid_Details.BeginUpdate();

					// �O���b�h������
					CreateGrid();

					_newSndRcvDtlList.Sort(delegate(SecMngSndRcvDtl x, SecMngSndRcvDtl y) { return x.DisplayOrder - y.DisplayOrder; });

					// �V�K�s�쐬
					CreateNewRow(ref this.uGrid_Details, _newSndRcvDtlList);

					SetGridNoEdit();

					this.uGrid_Details.EndUpdate();

					if (this.uGrid_Details.Rows.Count == 0)
					{
						this.uGrid_Details.ActiveRow = null;
					}
					else
					{
						this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[0];
					}
				}

			}
			else
			{
				// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
				if (this.DataIndex < 0)
				{
					SecMngSndRcv sendSet = new SecMngSndRcv();
					//�N���[���쐬
					this._sendSetClone = sendSet.Clone();

					this._indexBuf = this._dataIndex;

					// ��ʏ����r�p�N���[���ɃR�s�[���܂�
					ScreenToSendSet(ref this._sendSetClone);

				}
				else
				{
					// �ێ����Ă���f�[�^�Z�b�g���C���O���擾
					Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
					SecMngSndRcv sendSet = (SecMngSndRcv)this._sendSetTable[guid];

					// �f�[�^���͉�ʓW�J����
					SendSetToScreen(sendSet);

					// �t�H�[�J�X�ݒ�
					int focusindex = sendSet.SecMngSendDiv;
					if (focusindex == 0)
					{
						this.SendCode_uOption.FocusedIndex = 0;
					}
					else
					{
						this.SendCode_uOption.FocusedIndex = 1;
					}


					// �N���[���쐬
					this._sendSetClone = sendSet.Clone();

					// ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
					ScreenToSendSet(ref this._sendSetClone);

					this._indexBuf = this._dataIndex;
				}
			}
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            // �t�@�C������
            if (!this.FileName_tEdit.Text.Equals("����f�[�^"))
            {
                this.panel1.Visible = false;
                this.uGrid_Details.Location = new Point(46, 130);
                this.uGrid_Details.Size = new Size(457, 334);
                // �󒍃f�[�^���M�敪
                this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                // �ݏo�f�[�^���M�敪
                this.ShipmentSend_tComEditor.SelectedIndex = 0;
                // ���σf�[�^���M�敪
                this.EstimateSend_tComEditor.SelectedIndex = 0;
                // �󒍃f�[�^��M�敪
                this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                // �ݏo�f�[�^��M�敪
                this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                // ���σf�[�^��M�敪
                this.EstimateReceived_tComEditor.SelectedIndex = 0;
            }
            else
            {
                this.panel1.Visible = true;
                this.uGrid_Details.Location = new Point(46, 315);
                this.uGrid_Details.Size = new Size(457, 149);
                // ���M�敪
                if (Convert.ToInt32(this.SendCode_uOption.Value.ToString()) == 0)
                {
                    // �󒍃f�[�^���M�敪
                    this.AcptAnOdrSend_tComEditor.Enabled = false;
                    // �ݏo�f�[�^���M�敪
                    this.ShipmentSend_tComEditor.Enabled = false;
                    // ���σf�[�^���M�敪
                    this.EstimateSend_tComEditor.Enabled = false;
                    // �󒍃f�[�^���M�敪
                    this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                    // �ݏo�f�[�^���M�敪
                    this.ShipmentSend_tComEditor.SelectedIndex = 0;
                    // ���σf�[�^���M�敪
                    this.EstimateSend_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // �󒍃f�[�^���M�敪
                    this.AcptAnOdrSend_tComEditor.Enabled = true;
                    // �ݏo�f�[�^���M�敪
                    this.ShipmentSend_tComEditor.Enabled = true;
                    // ���σf�[�^���M�敪
                    this.EstimateSend_tComEditor.Enabled = true;
                }

                // ��M�敪
                if (this.ReceivedCode_tComEditor.SelectedIndex == 0)
                {
                    // �󒍃f�[�^��M�敪
                    this.AcptAnOdrReceived_tComEditor.Enabled = false;
                    // �ݏo�f�[�^��M�敪
                    this.ShipmentReceived_tComEditor.Enabled = false;
                    // ���σf�[�^��M�敪
                    this.EstimateReceived_tComEditor.Enabled = false;
                    // �󒍃f�[�^��M�敪
                    this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                    // �ݏo�f�[�^��M�敪
                    this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                    // ���σf�[�^��M�敪
                    this.EstimateReceived_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // �󒍃f�[�^��M�敪
                    this.AcptAnOdrReceived_tComEditor.Enabled = true;
                    // �ݏo�f�[�^��M�敪
                    this.ShipmentReceived_tComEditor.Enabled = true;
                    // ���σf�[�^��M�敪
                    this.EstimateReceived_tComEditor.Enabled = true;
                }
            }
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ�񑗎�M�Ώېݒ�N���X�i�[����
		/// </summary>
		/// <param name="sendSet">����M�Ώېݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂瑗��M�Ώېݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		private void ScreenToSendSet(ref SecMngSndRcv sendSet)
		{
			if (sendSet == null)
			{
				// �V�K�̏ꍇ
				sendSet = new SecMngSndRcv();
			}

			//��ƃR�[�h
			sendSet.EnterpriseCode = this._enterpriseCode;
			// ���M�敪
			sendSet.SecMngSendDiv = Convert.ToInt32(this.SendCode_uOption.Value.ToString());
			//��M�敪
			sendSet.SecMngRecvDiv = Convert.ToInt32(this.ReceivedCode_tComEditor.Value.ToString());
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^���M�敪
            sendSet.AcptAnOdrSendDiv = Convert.ToInt32(this.AcptAnOdrSend_tComEditor.Value.ToString());
            //�󒍃f�[�^��M�敪
            sendSet.AcptAnOdrRecvDiv = Convert.ToInt32(this.AcptAnOdrReceived_tComEditor.Value.ToString());
            //�ݏo�f�[�^���M�敪
            sendSet.ShipmentSendDiv = Convert.ToInt32(this.ShipmentSend_tComEditor.Value.ToString());
            //�ݏo�f�[�^��M�敪
            sendSet.ShipmentRecvDiv = Convert.ToInt32(this.ShipmentReceived_tComEditor.Value.ToString());
            //���σf�[�^���M�敪
            sendSet.EstimateSendDiv = Convert.ToInt32(this.EstimateSend_tComEditor.Value.ToString());
            //���σf�[�^��M�敪
            sendSet.EstimateRecvDiv = Convert.ToInt32(this.EstimateReceived_tComEditor.Value.ToString());
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ۑ���񑗎�M�Ώېݒ�N���X�i�[����
		/// </summary>
		/// <param name="secMngSndRcv">����M�Ώېݒ�I�u�W�F�N�g</param>
		/// <param name="secMngSndRcvDtlList"></param>
		/// <param name="secMngSndRcvList"></param>
		/// <remarks>
		/// <br>Note       : �ۑ���񂩂瑗��M�Ώېݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date	   : 2009.04.22</br>
		/// </remarks>
		private void SaveToSetList(SecMngSndRcv secMngSndRcv, ref List<SecMngSndRcv> secMngSndRcvList, ref List<SecMngSndRcvDtl> secMngSndRcvDtlList)
		{
			//����M�Ώۃ}�X�^
			secMngSndRcvList = _secMngSndRcvList.FindAll(delegate(SecMngSndRcv target)
			{
				if (secMngSndRcv.DisplayOrder == target.DisplayOrder)
				{
					return (true);
				}
				else
				{
					return (false);
				}
			});

			foreach (SecMngSndRcv _secMngSndRcv in secMngSndRcvList)
			{
				_secMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
				_secMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
			}

			//����M�Ώۏڍ׃}�X�^
			foreach (SecMngSndRcv _secMngSndRcv in secMngSndRcvList)
			{
				List<SecMngSndRcvDtl> resultDtlList = _secMngSndRcvDtlList.FindAll(delegate(SecMngSndRcvDtl target)
				{
					if (_secMngSndRcv.FileId.Equals(target.FileId))
					{
						return (true);
					}
					else
					{
						return (false);
					}
				});

				foreach (SecMngSndRcvDtl result in resultDtlList)
				{
					secMngSndRcvDtlList.Add(result);
				}
			}

			for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
			{
				string fileId = this.uGrid_Details.Rows[index].Cells[COLUMN_FILEID].Value.ToString().Trim();
				string itemId = this.uGrid_Details.Rows[index].Cells[COLUMN_ITEMID].Value.ToString().Trim();

				foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
				{
					if (fileId.Equals(secMngSndRcvDtl.FileId) && itemId.Equals(secMngSndRcvDtl.ItemId))
					{
						secMngSndRcvDtl.DataUpdateDiv = (int)this.uGrid_Details.Rows[index].Cells[COLUMN_UPDATECD].Value;
					}
				}
			}

		}


		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable allDefSetTable = new DataTable(VIEW_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			allDefSetTable.Columns.Add(VIEW_NAME_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_SEND_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_RECEIVED_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_SORTS_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_FILEID_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_FILENM_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_USERGUIDEDIVCD_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            allDefSetTable.Columns.Add(VIEW_ACPTANODSEND_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ACPTANODRECEIVED_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SHIPMENTSEND_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_SHIPMENTRECEIVED_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ESTIMATESEND_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ESTIMATERECEIVED_TITLE, typeof(string));
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
			this.Bind_DataSet.Tables.Add(allDefSetTable);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note        : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void ScreenClear()
		{
			// �O���b�h������
			CreateGrid();
			SetGridLayout();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note        : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		private void ReceivedCode_tComEditorInit(int displayOrder)
		{
			this.ReceivedCode_tComEditor.Items.Clear();

			if ((0 <= displayOrder) && (99 >= displayOrder))
			{
				// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				// ����n�A�d���n�A�݌Ɏd���n
				if ((1 == displayOrder) || (3 == displayOrder) || (21 == displayOrder) || (2 == displayOrder)
					|| (10 == displayOrder) || (11 == displayOrder) || (17 == displayOrder) || (18 == displayOrder)
					|| (19 == displayOrder)) //�݌Ɉړ��f�[�^ // ADD 2011.08.25
				{
					// �Ȃ�
					Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
					listItem0.DataValue = "0";
					listItem0.DisplayText = "�Ȃ�";

					// ����i�݌ɍX�V�Ȃ��j
					Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
					listItem1.DataValue = "1";
					listItem1.DisplayText = "����i�݌ɍX�V�Ȃ��j";

					// ����i�݌ɍX�V����j
					Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
					listItem2.DataValue = "2";
					listItem2.DisplayText = "����i�݌ɍX�V����j";

					this.ReceivedCode_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });
				}
				else
				{
                // ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

					// �Ȃ�
					Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
					listItem0.DataValue = "0";
					listItem0.DisplayText = "�Ȃ�";

					// ����
					Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
					listItem1.DataValue = "1";
					listItem1.DisplayText = "����";

					this.ReceivedCode_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1 });
				}
			}
			else if (100 <= displayOrder)
			{
				// �Ȃ�
				Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
				listItem2.DataValue = "0";
				listItem2.DisplayText = "�Ȃ�";

				// ����i�ǉ��̂݁j
				Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
				listItem3.DataValue = "1";
				listItem3.DisplayText = "����i�ǉ��̂݁j";

				// ����i�ǉ��E�X�V�j
				Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
				listItem4.DataValue = "2";
				listItem4.DisplayText = "����i�ǉ��E�X�V�j";

				// ����
				Infragistics.Win.ValueListItem listItem5 = new Infragistics.Win.ValueListItem();
				listItem5.DataValue = "3";
				listItem5.DisplayText = "����i�X�V�̂݁j";

				this.ReceivedCode_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem2, listItem3, listItem4, listItem5 });

			}
			else
			{
				//�Ȃ�
			}

		}

		/// <summary>
		/// �O���b�h�쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h���쐬���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void CreateGrid()
		{
			DataTable dataTable = new DataTable();

			// �t�@�C���h�c
			dataTable.Columns.Add(COLUMN_FILEID, typeof(string));
			// �t�@�C������
			dataTable.Columns.Add(COLUMN_FILENM, typeof(string));
			// ���ڂh�c
			dataTable.Columns.Add(COLUMN_ITEMID, typeof(string));
			//���ږ��� 
			dataTable.Columns.Add(COLUMN_ITEMNAME, typeof(string));
			//�X�V�敪
			dataTable.Columns.Add(COLUMN_UPDATECD, typeof(int));

			this.uGrid_Details.DataSource = dataTable;

			this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();
		}

		/// <summary>
		/// �V�K�s�쐬����
		/// </summary>
		/// <param name="uGrid">�O���b�h</param>
		/// <param name="secMngSndRcvDtlList"></param>
		/// <remarks>
		/// <br>Note       : �O���b�h�ɍs��ǉ����܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void CreateNewRow(ref UltraGrid uGrid, List<SecMngSndRcvDtl> secMngSndRcvDtlList)
		{

			foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
			{
				// �s�ǉ�
				uGrid.DisplayLayout.Bands[0].AddNew();

				//���ڂh�c
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMID].Value = secMngSndRcvDtl.ItemId;

				//���ږ���
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_ITEMNAME].Value = secMngSndRcvDtl.ItemName;

				//�t�@�C���h�c
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_FILEID].Value = secMngSndRcvDtl.FileId;

				//�}�X�^����
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_FILENM].Value = secMngSndRcvDtl.FileNm;

				//�X�V�敪
				uGrid.Rows[uGrid.Rows.Count - 1].Cells[COLUMN_UPDATECD].Value = secMngSndRcvDtl.DataUpdateDiv;

			}
		}

		/// <summary>
		/// �O���b�h���̐���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       :�O���b�h���̐���ݒ肵�܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void SetGridNoEdit()
		{
			int index = (int)this.ReceivedCode_tComEditor.SelectedIndex;

			if (this.uGrid_Details.Rows.Count == 0)
			{
				return;
			}

			//�u��M�Ȃ��v�y�сu��M����i�ǉ��̂݁j�v�̏ꍇ
			if (index == 0 || index == 1)
			{
				foreach (UltraGridRow row in this.uGrid_Details.Rows)
				{
					row.Cells[COLUMN_UPDATECD].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

					// ADD 2011/09/20 for #25368 ---------- >>>>>
					if (index == 1
						&& row.Cells[COLUMN_FILEID].Text.Equals("StockRF")
						&& row.Cells[COLUMN_ITEMID].Text.Equals("SupplierStockRF"))
					{
						row.Cells[COLUMN_UPDATECD].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
					}
					// ADD 2011/09/20 for #25368 ---------- <<<<<
				}
			}
			else
			{
				foreach (UltraGridRow row in this.uGrid_Details.Rows)
				{
					row.Cells[COLUMN_UPDATECD].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				}
			}
		}

		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h���C�A�E�g��ݒ肵�܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private void SetGridLayout()
		{
			ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;


			//--------------------------------------
			// ���͕s��
			//--------------------------------------
			columns[COLUMN_FILEID].CellActivation = Activation.NoEdit;
			columns[COLUMN_FILENM].CellActivation = Activation.NoEdit;
			columns[COLUMN_ITEMID].CellActivation = Activation.NoEdit;
			columns[COLUMN_ITEMNAME].CellActivation = Activation.NoEdit;

			//--------------------------------------
			// ��Œ�
			//--------------------------------------
			//columns[COLUMN_FILENM].Header.Fixed = true;
			//columns[COLUMN_ITEMNAME].Header.Fixed = true;
			//columns[COLUMN_UPDATECD].Header.Fixed = true;

			//--------------------------------------
			// �L���v�V����
			//--------------------------------------
			columns[COLUMN_FILEID].Header.Caption = "�t�@�C���h�c";
			columns[COLUMN_FILENM].Header.Caption = "�t�@�C������";
			columns[COLUMN_ITEMID].Header.Caption = "���ڂh�c";
			columns[COLUMN_ITEMNAME].Header.Caption = "���ږ���";
			columns[COLUMN_UPDATECD].Header.Caption = "�X�V�敪";

			//--------------------------------------
			// ��
			//--------------------------------------
			columns[COLUMN_FILEID].Width = 50;
			columns[COLUMN_FILENM].Width = 174;
			columns[COLUMN_ITEMID].Width = 50;
			columns[COLUMN_ITEMNAME].Width = 160;
			columns[COLUMN_UPDATECD].Width = 92;

			//--------------------------------------
			// ��\��
			//--------------------------------------
			columns[COLUMN_FILEID].Hidden = true;
			columns[COLUMN_ITEMID].Hidden = true;

			//--------------------------------------
			// �e�L�X�g�ʒu(VAlign)
			//--------------------------------------
			for (int index = 0; index < columns.Count; index++)
			{
				columns[index].CellAppearance.TextVAlign = VAlign.Middle;
			}

			//--------------------------------------
			// �R���{�{�b�N�X�ݒ�
			//--------------------------------------
			ValueList valueList = new ValueList();
			valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

			valueList.ValueListItems.Clear();
			valueList.ValueListItems.Add(0, "����");
			valueList.ValueListItems.Add(1, "���Ȃ�");
			columns[COLUMN_UPDATECD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			columns[COLUMN_UPDATECD].ValueList = valueList.Clone();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ����M�Ώۏڍאݒ�N���X��ʓW�J����
		/// </summary>
		/// <param name="sendSet">����M�Ώۏڍאݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ����M�Ώۏڍאݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		private void SendSetToScreen(SecMngSndRcv sendSet)
		{
			if (sendSet != null)
			{
				// �t�@�C������
				this.FileName_tEdit.Text = sendSet.MasterName;

				//���M�敪
				this.SendCode_uOption.Value = (object)sendSet.SecMngSendDiv;

				//��M�敪
				ReceivedCode_tComEditorInit(sendSet.DisplayOrder);

				this.ReceivedCode_tComEditor.Value = (object)sendSet.SecMngRecvDiv;

                // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                //�󒍃f�[�^���M�敪
                this.AcptAnOdrSend_tComEditor.Value = (object)sendSet.AcptAnOdrSendDiv;
                //�󒍃f�[�^��M�敪
                this.AcptAnOdrReceived_tComEditor.Value = (object)sendSet.AcptAnOdrRecvDiv;
                //�ݏo�f�[�^���M�敪
                this.ShipmentSend_tComEditor.Value = (object)sendSet.ShipmentSendDiv;
                //�ݏo�f�[�^��M�敪
                this.ShipmentReceived_tComEditor.Value = (object)sendSet.ShipmentRecvDiv;
                //���σf�[�^���M�敪
                this.EstimateSend_tComEditor.Value = (object)sendSet.EstimateSendDiv;
                //���σf�[�^��M�敪
                this.EstimateReceived_tComEditor.Value = (object)sendSet.EstimateRecvDiv;
                // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

				//����M�Ώ�
				List<SecMngSndRcv> resultList = _secMngSndRcvList.FindAll(delegate(SecMngSndRcv target)
				{
					if (sendSet.DisplayOrder == target.DisplayOrder)
					{
						return (true);
					}
					else
					{
						return (false);
					}
				});

				List<SecMngSndRcvDtl> resultDtlDisPlayList = new List<SecMngSndRcvDtl>();
				//����M�Ώۏڍ�
				foreach (SecMngSndRcv secMngSndRcv in resultList)
				{
					List<SecMngSndRcvDtl> resultDtlList = _secMngSndRcvDtlList.FindAll(delegate(SecMngSndRcvDtl target)
					{
						if (secMngSndRcv.FileId.Equals(target.FileId))
						{
							return (true);
						}
						else
						{
							return (false);
						}
					});

					foreach (SecMngSndRcvDtl result in resultDtlList)
					{
						resultDtlDisPlayList.Add(result);
					}
				}

				this.uGrid_Details.BeginUpdate();

				// �O���b�h������
				CreateGrid();

				resultDtlDisPlayList.Sort(delegate(SecMngSndRcvDtl x, SecMngSndRcvDtl y) { return x.DisplayOrder - y.DisplayOrder; });

				// �V�K�s�쐬
				CreateNewRow(ref this.uGrid_Details, resultDtlDisPlayList);

				SetGridNoEdit();

				this.uGrid_Details.EndUpdate();

				if (this.uGrid_Details.Rows.Count == 0)
				{
					this.uGrid_Details.ActiveRow = null;
				}
				else
				{
					this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[0];
				}

			}

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///�@�ۑ�����(SaveSendSet())
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		private bool SaveSendSet()
		{
			bool result = false;
			Control control = null;
			int status;

			SecMngSndRcv secMngSndRcv = null;
			List<SecMngSndRcv> secMngSndRcvList = new List<SecMngSndRcv>();
			List<SecMngSndRcvDtl> secMngSndRcvDtlList = new List<SecMngSndRcvDtl>();

			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			if (_callForm && _callPara != 0 && _newSndRcvList.Count > 0)
			{
				for (int cnt = 0; cnt < _newSndRcvList.Count; cnt++)
				{
					//��ƃR�[�h
					_newSndRcvList[cnt].EnterpriseCode = this._enterpriseCode;
					// ���M�敪
					_newSndRcvList[cnt].SecMngSendDiv = Convert.ToInt32(this.SendCode_uOption.Value.ToString());
					//��M�敪
					_newSndRcvList[cnt].SecMngRecvDiv = Convert.ToInt32(this.ReceivedCode_tComEditor.Value.ToString());
                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                    //�󒍃f�[�^���M�敪
                    _newSndRcvList[cnt].AcptAnOdrSendDiv = Convert.ToInt32(this.AcptAnOdrSend_tComEditor.Value.ToString());
                    //�󒍃f�[�^��M�敪
                    _newSndRcvList[cnt].AcptAnOdrRecvDiv = Convert.ToInt32(this.AcptAnOdrReceived_tComEditor.Value.ToString());
                    //�ݏo�f�[�^���M�敪
                    _newSndRcvList[cnt].ShipmentSendDiv = Convert.ToInt32(this.ShipmentSend_tComEditor.Value.ToString());
                    //�ݏo�f�[�^��M�敪
                    _newSndRcvList[cnt].ShipmentRecvDiv = Convert.ToInt32(this.ShipmentReceived_tComEditor.Value.ToString());
                    //���σf�[�^���M�敪
                    _newSndRcvList[cnt].EstimateSendDiv = Convert.ToInt32(this.EstimateSend_tComEditor.Value.ToString());
                    //���σf�[�^��M�敪
                    _newSndRcvList[cnt].EstimateRecvDiv = Convert.ToInt32(this.EstimateReceived_tComEditor.Value.ToString());
                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
				}

				for (int cnt = 0; cnt < this.uGrid_Details.Rows.Count; cnt++)
				{
					_newSndRcvDtlList[cnt].DataUpdateDiv = (int)this.uGrid_Details.Rows[cnt].Cells[COLUMN_UPDATECD].Value;
				}

				status = this._sendSetAcs.Write(ref _newSndRcvList, ref _newSndRcvDtlList);
			}
			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
			else
			{
				if (this.DataIndex >= 0)
				{
					Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
					secMngSndRcv = ((SecMngSndRcv)this._sendSetTable[guid]).Clone();
				}

				ScreenToSendSet(ref secMngSndRcv);

				//SaveToSetList(secMngSndRcv, ref secMngSndRcvList, ref secMngSndRcvDtlList);// DEL 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

				// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				if (secMngSndRcv != null)
				{
					int displayOd = secMngSndRcv.DisplayOrder;
					if ((1 == displayOd) || (3 == displayOd) || (21 == displayOd) || (2 == displayOd)
					|| (10 == displayOd) || (11 == displayOd) || (17 == displayOd) || (18 == displayOd))
					{
						string msg = string.Empty;

						if ((1 == displayOd) || (3 == displayOd) || (21 == displayOd) || (2 == displayOd))
						{
							// ����n
							msg = "�f�[�^���������m�ۂ���ׂɁA����f�[�^�A���㖾�׃f�[�^�A�󒍃}�X�^�A���q���f�[�^���ꏏ�ɍX�V���Ă�낵���ł��傤���H";
							foreach (SecMngSndRcv tmpSecMngSndRcv in _secMngSndRcvList)
							{
								int tmpDisplayOrder = tmpSecMngSndRcv.DisplayOrder;
								if ((1 == tmpDisplayOrder) || (3 == tmpDisplayOrder) || (21 == tmpDisplayOrder) || (2 == tmpDisplayOrder))
								{
									tmpSecMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
									tmpSecMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
                                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                                    if (1 == tmpDisplayOrder)
                                    {
                                        if (tmpDisplayOrder == displayOd)
                                        {
                                            //�󒍃f�[�^���M�敪
                                            tmpSecMngSndRcv.AcptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                                            //�󒍃f�[�^��M�敪
                                            tmpSecMngSndRcv.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
                                            //�ݏo�f�[�^���M�敪
                                            tmpSecMngSndRcv.ShipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                                            //�ݏo�f�[�^��M�敪
                                            tmpSecMngSndRcv.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
                                            //���σf�[�^���M�敪
                                            tmpSecMngSndRcv.EstimateSendDiv = secMngSndRcv.EstimateSendDiv;
                                            //���σf�[�^��M�敪
                                            tmpSecMngSndRcv.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
                                        }
                                        else
                                        {
                                            // ���M�敪
                                            if (secMngSndRcv.SecMngSendDiv == 0)
                                            {
                                                //�󒍃f�[�^���M�敪
                                                tmpSecMngSndRcv.AcptAnOdrSendDiv = 0;
                                                //�ݏo�f�[�^���M�敪
                                                tmpSecMngSndRcv.ShipmentSendDiv = 0;
                                                //���σf�[�^���M�敪
                                                tmpSecMngSndRcv.EstimateSendDiv = 0;
                                            }
                                            // ��M�敪
                                            if (secMngSndRcv.SecMngRecvDiv == 0)
                                            {
                                                //�󒍃f�[�^��M�敪
                                                tmpSecMngSndRcv.AcptAnOdrRecvDiv = 0;
                                                //�ݏo�f�[�^��M�敪
                                                tmpSecMngSndRcv.ShipmentRecvDiv = 0;
                                                //���σf�[�^��M�敪
                                                tmpSecMngSndRcv.EstimateRecvDiv = 0;
                                            }

                                        }
                                    }
                                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
									secMngSndRcvList.Add(tmpSecMngSndRcv);
								}
								
							}
						}
						else if ((10 == displayOd) || (11 == displayOd))
						{
							// �d���n
							msg = "�f�[�^���������m�ۂ���ׂɁA�d���f�[�^�A�d�����׃f�[�^�͈ꏏ�ɍX�V���Ă�낵���ł��傤���H";
							foreach (SecMngSndRcv tmpSecMngSndRcv in _secMngSndRcvList)
							{
								int tmpDisplayOrder = tmpSecMngSndRcv.DisplayOrder;
								if ((10 == tmpDisplayOrder) || (11 == tmpDisplayOrder))
								{
									tmpSecMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
									tmpSecMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
									secMngSndRcvList.Add(tmpSecMngSndRcv);
								}
								
							}
						}
						else
						{
							// �݌Ɏd���n
							msg = "�f�[�^���������m�ۂ���ׂɁA�݌Ɏd���f�[�^�A�݌Ɏd�����׃f�[�^�͈ꏏ�ɍX�V���Ă�낵���ł��傤���H";
							foreach (SecMngSndRcv tmpSecMngSndRcv in _secMngSndRcvList)
							{
								int tmpDisplayOrder = tmpSecMngSndRcv.DisplayOrder;
								if ((17 == tmpDisplayOrder) || (18 == tmpDisplayOrder))
								{
									tmpSecMngSndRcv.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
									tmpSecMngSndRcv.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
									secMngSndRcvList.Add(tmpSecMngSndRcv);
								}
								
							}
						}
						DialogResult res = TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
									 emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
									  this.Name,						    // �A�Z���u���h�c�܂��̓N���X�h�c
									 msg, 	// �\�����郁�b�Z�[�W
									 0, 									// �X�e�[�^�X�l
									 MessageBoxButtons.YesNo);				// �\������{�^��

						if (res == DialogResult.Yes)
						{

						}
						else
						{
							return false;
						}
					}
					else
					{
						SaveToSetList(secMngSndRcv, ref secMngSndRcvList, ref secMngSndRcvDtlList);
					}

				}
				
				// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

				status = this._sendSetAcs.Write(ref secMngSndRcvList, ref secMngSndRcvDtlList);
			}
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �o�^�����_�C�A���O�\��
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);

						// �Č���
						int totalCount = 0;
						Search(ref totalCount, 0);

						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
						RepeatTransaction(status, ref control);
						control.Focus();
						return false;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						this.DialogResult = DialogResult.Cancel;
						this._indexBuf = -2;

						if (CanClose == true)
						{
							this.Close();
						}
						else
						{
							this.Hide();
						}
						return false;
					}

				default:
					{
						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
							"PMKYO09200U",							// �A�Z���u��ID
							"����M�Ώېݒ�ݒ�",  �@�@             // �v���O��������
							"SaveSendSet",                          // ��������
							TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
							"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
							status,									// �X�e�[�^�X�l
							this._sendSetAcs,				    	// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,			  		// �\������{�^��
							MessageBoxDefaultButton.Button1);		// �����\���{�^��

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						this.DialogResult = DialogResult.Cancel;
						this._indexBuf = -2;

						if (CanClose == true)
						{
							this.Close();
						}
						else
						{
							this.Hide();
						}
						return false;
					}
			}
			// UPD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//SendSetToDataSet(secMngSndRcv, this.DataIndex);
			if (!_callForm)
			{
				SendSetToDataSet(secMngSndRcv, this.DataIndex);
			}
			// UPD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

			result = true;
			return result;

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ����M�Ώېݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="sendSet">����M�Ώېݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ��ƃR�[�h�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date	   : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877�̑Ή�</br>
		/// </remarks>
		private void SendSetToDataSet(SecMngSndRcv sendSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

			// ����
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NAME_TITLE] = sendSet.MasterName;
			//���M�敪
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SEND_TITLE] = GetSendName(sendSet.SecMngSendDiv);
			//��M�敪
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_RECEIVED_TITLE] = GetReceivedName(sendSet.SecMngRecvDiv, sendSet.DisplayOrder);
			//�\������
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SORTS_TITLE] = sendSet.DisplayOrder;
			//�t�@�C���h�c
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEID_TITLE] = sendSet.FileId;
			//�t�@�C������
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILENM_TITLE] = sendSet.FileNm;
			//���[�U�[�K�C�h�敪
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_USERGUIDEDIVCD_TITLE] = sendSet.UserGuideDivCd;

			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sendSet.FileHeaderGuid;

            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^���M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANODSEND_TITLE] = GetSendName(sendSet.AcptAnOdrSendDiv);
            //�󒍃f�[�^��M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACPTANODRECEIVED_TITLE] = GetSendName(sendSet.AcptAnOdrRecvDiv);
            //�ݏo�f�[�^���M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SHIPMENTSEND_TITLE] = GetSendName(sendSet.ShipmentSendDiv);
            //�ݏo�f�[�^��M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SHIPMENTRECEIVED_TITLE] = GetSendName(sendSet.ShipmentRecvDiv);
            //���σf�[�^���M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATESEND_TITLE] = GetSendName(sendSet.EstimateSendDiv);
            //���σf�[�^��M�敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATERECEIVED_TITLE] = GetSendName(sendSet.EstimateRecvDiv);
            // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<

			if (this._sendSetTable.ContainsKey(sendSet.FileHeaderGuid) == true)
			{
				this._sendSetTable.Remove(sendSet.FileHeaderGuid);
			}
			this._sendSetTable.Add(sendSet.FileHeaderGuid, sendSet);
		}

		/// <summary>
		/// ����f�[�^�̃��b�Z�[�W
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : ���ɋ��_�Ǘ��ݒ�}�X�^�ɓ���f�[�^����ꍇ�A���b�Z�[�W������B</br>
		/// <br>Programmer  : ���M</br>
		/// <br>Date        : 2009/03/30</br>
		/// </remarks>
		private void RepeatTransaction(int status, ref Control control)
		{
			TMsgDisp.Show(
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
				"PMKYO09200U",						// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^�����ɑ��݂��Ă��܂��B", 	// �\�����郁�b�Z�[�W
				0, 									// �X�e�[�^�X�l
				MessageBoxButtons.OK);				// �\������{�^��
			SendCode_uOption.Focus();

			control = SendCode_uOption;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date	   : 2009.04.22</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
				|| status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
			{
				TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
					"PMKYO09200U",							// �A�Z���u��ID
					"���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
					status,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
			}
		}

		#endregion

		# region -- Control Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.Load �C�x���g(PMKYO09200U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Form1_Load(object sender, EventArgs e)
		{
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.Closing �C�x���g(PMKYO09200U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.VisibleChanged �C�x���g(PMKYO09200U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
		///					  ���Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Form1_VisibleChanged(object sender, EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// ���C���t���[���A�N�e�B�u��
                //this.Owner.Activate();//DEL 2011/07/25
                //-----ADD 2011/07/25----->>>>>
                if (!this._callForm)
                {
                    this.Owner.Activate();
                }
                //-----ADD 2011/07/25-----<<<<<
				return;
			}
			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			ScreenClear();

			Timer.Enabled = true;

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	ReceivedCode_.VisibleChanged �C�x���g(PMKYO09200U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
		///					  ���Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void ReceivedCode_tComEditor_SelectionChanged(object sender, EventArgs e)
		{
			SetGridNoEdit();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, EventArgs e)
		{
			// �I�t���C����ԃ`�F�b�N
			if (!CheckOnline())
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOP,
					this.Text,
					this.Text + "��ʕۑ������Ɏ��s���܂����B",
					(int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return;
			}

			if (!SaveSendSet())
			{
				return;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			if (_callForm && (_callPara != 0))
			{
				this.Close();
			}
			// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<
			else
			{
				// ��ʂ̃f�[�^���擾����
				SecMngSndRcv comparesecMngSndRcv = new SecMngSndRcv();
				comparesecMngSndRcv = this._sendSetClone.Clone();
				ScreenToSendSet(ref comparesecMngSndRcv);

				// ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
				if (!(this._sendSetClone.Equals(comparesecMngSndRcv)) || !CompareOriginalScreen())
				{
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
					DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
						"PMKYO09200U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
						null, 					                              // �\�����郁�b�Z�[�W
						0, 					                                  // �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

					switch (res)
					{
						case DialogResult.Yes:
							{
								if (!SaveSendSet())
								{
									return;
								}
								return;
							}

						case DialogResult.No:
							{
								// ��ʔ�\���C�x���g
								if (UnDisplaying != null)
								{
									MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
									UnDisplaying(this, me);
								}

								break;
							}

						default:
							{
								this.Cancel_Button.Focus();
								return;
							}
					}
				}

				this.DialogResult = DialogResult.Cancel;
				this._indexBuf = -2;

				// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
				// �t�H�[�����\��������B
				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Timer.Tick �C�x���g(timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer	: ���M</br>
		/// <br>Date		: 2009.04.22</br>
		/// </remarks>
		private void Timer_Tick(object sender, EventArgs e)
		{
			Timer.Enabled = false;

			ScreenReconstruction();
		}

		/// <summary>
		/// ChangeFocus �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null)
			{
				return;
			}

			switch (e.PrevCtrl.Name)
			{
				// �O���b�h
				case "uGrid_Details":
					{
						#region �O���b�h

						if (e.ShiftKey == false)
						{
							if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
							{
								int rowIndex;
								int colIndex;

								if (this.uGrid_Details.ActiveCell != null)
								{
									rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
									colIndex = this.uGrid_Details.ActiveCell.Column.Index;
								}
								else if (this.uGrid_Details.ActiveRow != null)
								{
									e.NextCtrl = null;
									this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
									return;
								}
								else
								{
									if (this.uGrid_Details.Rows.Count == 0)
									{
										e.NextCtrl = this.Ok_Button;
										return;
									}
									else
									{
										e.NextCtrl = null;
										this.uGrid_Details.Rows[0].Cells[4].Activate();
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
										return;
									}
								}

								e.NextCtrl = null;

								if (colIndex < 4)
								{
									// �Ƀt�H�[�J�X
									this.uGrid_Details.Rows[rowIndex].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
									return;
								}
								else if (colIndex == 4)
								{
									if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)
									{
										// �t�H�[�J�X�ړ��Ȃ�
										//this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
										e.NextCtrl = this.Ok_Button;
										this.uGrid_Details.ActiveCell = null;
										return;
									}
									else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1)
									{
										e.NextCtrl = null;
										this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
										return;
									}
									else
									{
										this.uGrid_Details.Rows[rowIndex + 1].Cells[4].Activate();
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
										return;
									}
								}
								else
								{
									this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
								}
							}
						}
						else
						{
							if (e.Key == Keys.Tab)
							{
								int rowIndex;
								int colIndex;

								if (this.uGrid_Details.ActiveCell != null)
								{
									rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
									colIndex = this.uGrid_Details.ActiveCell.Column.Index;
								}
								else if (this.uGrid_Details.ActiveRow != null)
								{
									rowIndex = this.uGrid_Details.ActiveRow.Index;
									colIndex = 5;
								}
								else
								{
									if (this.uGrid_Details.Rows.Count == 0)
									{
										e.NextCtrl = this.Ok_Button;
										return;
									}
									else
									{
										e.NextCtrl = this.Ok_Button;
										return;
									}
								}

								e.NextCtrl = null;

								if (colIndex <= 4)
								{
									if (rowIndex == 0)
									{
                                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                                        // �t�@�C������
                                        if (this.FileName_tEdit.Text.Equals("����f�[�^"))
                                        {
                                            if (this.EstimateReceived_tComEditor.Enabled == true)
                                            {
                                                e.NextCtrl = this.EstimateReceived_tComEditor;
                                            }
                                            else if (this.EstimateSend_tComEditor.Enabled == true)
                                            {
                                                e.NextCtrl = this.EstimateSend_tComEditor;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ReceivedCode_tComEditor;
                                            }
                                        }
                                        else
                                        {
                                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                                            e.NextCtrl = this.ReceivedCode_tComEditor;
                                        }// ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή�
									}
									else
									{
										this.uGrid_Details.Rows[rowIndex - 1].Cells[4].Activate();
										this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
									}
								}
								else
								{
									this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
								}
							}
						}
						break;

						#endregion
					}
			}

			if (e.NextCtrl == null)
			{
				return;
			}

			switch (e.NextCtrl.Name)
			{
				// �O���b�h
				case "uGrid_Details":
					{
						#region �O���b�h

						if (e.ShiftKey == false)
						{
							if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
							{
								if (this.uGrid_Details.Rows.Count == 0)
								{
									e.NextCtrl = this.Ok_Button;
								}
								else
								{
									e.NextCtrl = null;

									int selectIndex = this.ReceivedCode_tComEditor.SelectedIndex;

									if (selectIndex == 0 || selectIndex == 1)
									{
										e.NextCtrl = this.Ok_Button;
									}
									else
									{
										this.uGrid_Details.Rows[0].Cells[4].Activate();
									}

									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
							else if (e.Key == Keys.Up)
							{
								if (this.uGrid_Details.Rows.Count == 0)
								{
									e.NextCtrl = this.Ok_Button;
								}
								else
								{
									e.NextCtrl = null;
									this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
						}
						else
						{
							if (e.Key == Keys.Tab)
							{
                                if (this.uGrid_Details.Rows.Count == 0 || ReceivedCode_tComEditor.SelectedIndex == 0 ||
                                    ReceivedCode_tComEditor.SelectedIndex == 1)
								{
                                    // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
                                    // �t�@�C������
                                    if (this.FileName_tEdit.Text.Equals("����f�[�^"))
                                    {
                                        if (this.EstimateReceived_tComEditor.Enabled == true)
                                        {
                                            e.NextCtrl = this.EstimateReceived_tComEditor;
                                        }
                                        else if (this.EstimateSend_tComEditor.Enabled == true)
                                        {
                                            e.NextCtrl = this.EstimateSend_tComEditor;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.ReceivedCode_tComEditor;
                                        }
                                    }
                                    else
                                    {
                                        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
                                        e.NextCtrl = this.ReceivedCode_tComEditor;
                                    }// ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή�
									
								}
								else
								{
									e.NextCtrl = null;
									this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[4].Activate();
									this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
								}
							}
						}
						break;

						#endregion
					}
			}
		}

		/// <summary>
		/// ���M���̎擾����
		/// </summary>
		/// <param name="sendCode">���M�R�[�h</param>
		/// <returns>���M����</returns>
		/// <remarks>
		/// <br>Note       : ���M���̂��擾���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private string GetSendName(int sendCode)
		{
			string sendName = string.Empty;
			if (sendCode == 0)
			{
				sendName = "�Ȃ�";
			}
			else if (sendCode == 1)
			{
				sendName = "����";
			}
			else
			{
				sendName = "";
			}
			return sendName;
		}

		/// <summary>
		/// ��M���̎擾����
		/// </summary>
		/// <param name="receivedCode">��M�R�[�h</param>
		/// <param name="displayOrder"></param>
		/// <returns>��M����</returns>
		/// <remarks>
		/// <br>Note       : ��M���̂��擾���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private string GetReceivedName(int receivedCode, int displayOrder)
		{
			string receivedName = string.Empty;
			if ((1 <= displayOrder) && (displayOrder <= 99))
			{
				// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
				// ����n�A�d���n�A�݌Ɏd���n
				if ((1 == displayOrder) || (3 == displayOrder) || (21 == displayOrder) || (2 == displayOrder)
					|| (10 == displayOrder) || (11 == displayOrder) || (17 == displayOrder) || (18 == displayOrder)
					|| (19 == displayOrder)) //�݌Ɉړ��f�[�^ // ADD 2011.08.25)
				{
					if (receivedCode == 0)
					{
						receivedName = "�Ȃ�";
					}
					else if (receivedCode == 1)
					{
						receivedName = "����i�݌ɍX�V�Ȃ��j";
					}
					else if (receivedCode == 2)
					{
						receivedName = "����i�݌ɍX�V����j";
					}
					else
					{
						receivedName = string.Empty;
					}
				}
				else
				{
				// ADD 2011/07/25 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

					if (receivedCode == 0)
					{
						receivedName = "�Ȃ�";
					}
					else if (receivedCode == 1)
					{
						receivedName = "����";
					}
					else
					{
						receivedName = string.Empty;
					}
				}

			}
			else if (100 <= displayOrder)
			{
				if (receivedCode == 0)
				{
					receivedName = "�Ȃ�";
				}
				else if (receivedCode == 1)
				{
					receivedName = "����i�ǉ��̂݁j";
				}
				else if (receivedCode == 2)
				{
					receivedName = "����i�ǉ��E�X�V�j";
				}
				else if (receivedCode == 3)
				{
					receivedName = "����i�X�V�̂݁j";
				}
				else
				{
					receivedName = string.Empty;
				}
			}
			else
			{
				receivedName = string.Empty;
			}

			return receivedName;
		}

		/// <summary>
		/// �O���b�h�\�����X�g�擾����
		/// </summary>
		/// <param name="secMngSndRcvList">����M�Ώۃ}�X�^�������ʃ��X�g</param>
		/// <remarks>
		/// <br>Note        : �O���b�h�ɕ\�����郊�X�g���擾���܂��B</br>
		/// <br>Programmer  : ���M</br>
		/// <br>Date        : 2009.04.22</br>
		/// </remarks>
		private List<SecMngSndRcv> GetDisplayList(List<SecMngSndRcv> secMngSndRcvList)
		{
			// �d�����Ă���f�[�^������ꍇ�́A���ꏇ�ʂ̃f�[�^���擾
			Dictionary<int, SecMngSndRcv> parentDic = new Dictionary<int, SecMngSndRcv>();

			foreach (SecMngSndRcv secMngSndRcv in secMngSndRcvList)
			{
				int key = secMngSndRcv.DisplayOrder;
				if (!parentDic.ContainsKey(key))
				{
					parentDic.Add(key, secMngSndRcv.Clone());
				}
			}

			List<SecMngSndRcv> _secMngSndRcvList = new List<SecMngSndRcv>();

			foreach (SecMngSndRcv result in parentDic.Values)
			{
				_secMngSndRcvList.Add(result.Clone());
			}

			return _secMngSndRcvList;
		}

		/// <summary>
		/// ��ʏ���r����
		/// </summary>
		/// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
		/// <remarks>
		/// <br>Note       : ��ʏ��̔�r���s���܂��B</br>
		/// <br>Programmer : ���M</br>
		/// <br>Date       : 2009.04.22</br>
		/// </remarks>
		private bool CompareOriginalScreen()
		{
			bool sameFlg = true;
			SecMngSndRcv secMngSndRcv = new SecMngSndRcv();

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
				secMngSndRcv = ((SecMngSndRcv)this._sendSetTable[guid]).Clone();
			}

			//����M�Ώۃ}�X�^
			List<SecMngSndRcv> secMngSndRcvList = _secMngSndRcvList.FindAll(delegate(SecMngSndRcv target)
			{
				if (secMngSndRcv.DisplayOrder == target.DisplayOrder)
				{
					return (true);
				}
				else
				{
					return (false);
				}
			});

			//����M�Ώۏڍ׃}�X�^
			List<SecMngSndRcvDtl> secMngSndRcvDtlList = new List<SecMngSndRcvDtl>();

			foreach (SecMngSndRcv _secMngSndRcv in secMngSndRcvList)
			{
				List<SecMngSndRcvDtl> resultDtlList = _secMngSndRcvDtlList.FindAll(delegate(SecMngSndRcvDtl target)
				{
					if (_secMngSndRcv.FileId.Equals(target.FileId))
					{
						return (true);
					}
					else
					{
						return (false);
					}
				});

				foreach (SecMngSndRcvDtl result in resultDtlList)
				{
					secMngSndRcvDtlList.Add(result);
				}
			}

			for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
			{
				string fileId = this.uGrid_Details.Rows[index].Cells[COLUMN_FILEID].Value.ToString().Trim();
				string itemId = this.uGrid_Details.Rows[index].Cells[COLUMN_ITEMID].Value.ToString().Trim();

				foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
				{
					if (fileId.Equals(secMngSndRcvDtl.FileId) && itemId.Equals(secMngSndRcvDtl.ItemId))
					{
						int dataUpdate = (int)this.uGrid_Details.Rows[index].Cells[COLUMN_UPDATECD].Value;
						if (dataUpdate != secMngSndRcvDtl.DataUpdateDiv)
						{
							sameFlg = false;
							break;
						}
					}
				}
			}

			return sameFlg;
		}

		#endregion

		#region �� �I�t���C����ԃ`�F�b�N����
		/// <summary>				
		/// ���O�I�����I�����C����ԃ`�F�b�N����				
		/// </summary>				
		/// <returns>�`�F�b�N��������</returns>				
		public static bool CheckOnline()
		{
			if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
			{
				return false;
			}
			else
			{
				// ���[�J���G���A�ڑ���Ԃɂ��I�����C������				
				if (CheckRemoteOn() == false)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>				
		/// �����[�g�ڑ��\����				
		/// </summary>				
		/// <returns>���茋��</returns>				
		private static bool CheckRemoteOn()
		{
			bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

			if (isLocalAreaConnected == false)
			{
				// �C���^�[�l�b�g�ڑ��s�\���				
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion

        #region
        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------>>>>>
        /// <summary>
        /// ���M�敪 �l�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���M�敪�̃`�F�b�N��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void SendCode_uOption_ValueChanged(object sender, EventArgs e)
        {
            // �t�@�C������
            if (this.FileName_tEdit.Text.Equals("����f�[�^"))
            {
                // ���M�敪
                if (Convert.ToInt32(this.SendCode_uOption.Value.ToString()) == 0)
                {
                    // �󒍃f�[�^���M�敪
                    this.AcptAnOdrSend_tComEditor.Enabled = false;
                    // �ݏo�f�[�^���M�敪
                    this.ShipmentSend_tComEditor.Enabled = false;
                    // ���σf�[�^���M�敪
                    this.EstimateSend_tComEditor.Enabled = false;
                    // �󒍃f�[�^���M�敪
                    this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                    // �ݏo�f�[�^���M�敪
                    this.ShipmentSend_tComEditor.SelectedIndex = 0;
                    // ���σf�[�^���M�敪
                    this.EstimateSend_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // �󒍃f�[�^���M�敪
                    this.AcptAnOdrSend_tComEditor.Enabled = true;
                    // �ݏo�f�[�^���M�敪
                    this.ShipmentSend_tComEditor.Enabled = true;
                    // ���σf�[�^���M�敪
                    this.EstimateSend_tComEditor.Enabled = true;
                }
            }
            else
            {
                // �󒍃f�[�^���M�敪
                this.AcptAnOdrSend_tComEditor.SelectedIndex = 0;
                // �ݏo�f�[�^���M�敪
                this.ShipmentSend_tComEditor.SelectedIndex = 0;
                // ���σf�[�^���M�敪
                this.EstimateSend_tComEditor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// ��M�敪 �l�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��M�敪�̃`�F�b�N��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void ReceivedCode_tComEditor_ValueChanged(object sender, EventArgs e)
        {
             // �t�@�C������
            if (this.FileName_tEdit.Text.Equals("����f�[�^"))
            {
                // ��M�敪
                if (Convert.ToInt32(this.ReceivedCode_tComEditor.Value.ToString()) == 0)
                {
                    // �󒍃f�[�^��M�敪
                    this.AcptAnOdrReceived_tComEditor.Enabled = false;
                    // �ݏo�f�[�^��M�敪
                    this.ShipmentReceived_tComEditor.Enabled = false;
                    // ���σf�[�^��M�敪
                    this.EstimateReceived_tComEditor.Enabled = false;
                    // �󒍃f�[�^��M�敪
                    this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                    // �ݏo�f�[�^��M�敪
                    this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                    // ���σf�[�^��M�敪
                    this.EstimateReceived_tComEditor.SelectedIndex = 0;
                }
                else
                {
                    // �󒍃f�[�^��M�敪
                    this.AcptAnOdrReceived_tComEditor.Enabled = true;
                    // �ݏo�f�[�^��M�敪
                    this.ShipmentReceived_tComEditor.Enabled = true;
                    // ���σf�[�^��M�敪
                    this.EstimateReceived_tComEditor.Enabled = true;
                }
            }
            else
            {
                // �󒍃f�[�^��M�敪
                this.AcptAnOdrReceived_tComEditor.SelectedIndex = 0;
                // �ݏo�f�[�^��M�敪
                this.ShipmentReceived_tComEditor.SelectedIndex = 0;
                // ���σf�[�^��M�敪
                this.EstimateReceived_tComEditor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// �󒍃f�[�^���M�敪�l�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �󒍃f�[�^���M�敪��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void AcptAnOdrSend_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // �󒍃f�[�^���M�敪
            if (this.AcptAnOdrSend_tComEditor.SelectedIndex == 1)
            {
                SendMessage();
                this.AcptAnOdrSend_tComEditor.Focus();
            }
        }

        /// <summary>
        /// �f�[�^���M�敪�ύX�̃��b�Z�[�W
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^���M�敪��ύX�������ɒ񎦃��b�Z�[�W��\������B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void SendMessage()
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                "PMKYO09200U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�����M�̃f�[�^������ꍇ�Ƀf�[�^�̕s��������������\��������܂��B", 	// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
        }

        /// <summary>
        /// �ݏo�f�[�^���M�敪�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ݏo�f�[�^���M�敪��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void ShipmentSend_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // �ݏo�f�[�^���M�敪
            if (this.ShipmentSend_tComEditor.SelectedIndex == 1)
            {
                SendMessage();
                this.ShipmentSend_tComEditor.Focus();
            }
        }

        /// <summary>
        /// �ݏo�f�[�^���M�敪�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ݏo�f�[�^���M�敪��ύX�������ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/09/25</br>
        /// </remarks>
        private void EstimateSend_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this._indexBuf == -2)
            {
                return;
            }
            // ���σf�[�^���M�敪
            if (this.EstimateSend_tComEditor.SelectedIndex == 1)
            {
                SendMessage();
                this.EstimateSend_tComEditor.Focus();
            }
        }
        // ADD ���O 2020/09/25 PMKOBETSU-3877�̑Ή� ------<<<<<
        #endregion
	}
}