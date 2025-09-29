using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[���������ݒ�UI
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[����������ʏ��p�}�X�����ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.22</br>
	/// <br></br>
	/// <br>UpdateNote	: 2008.03.19 22024 ����_�u</br>
	/// <br>			: �P�D���[�̒��o�����ɓ��t�n���ڂ��܂܂�Ȃ���Ԃł̊m���s�Ƃ���B</br>
	/// <br>			: 2008.04.04 22024 ����_�u</br>
	/// <br>			: �P�D�i�Ǉ�2008P058-5-005010-01 �u�~�v�������ɓ��̓`�F�b�N��������Ȃ��s��C��</br>
	/// <br>			: 2008.04.07 22024 ����_�u</br>
	/// <br>			: �P�D�i�Ǉ�2008P058-2-001005-02 2008.04.04�Ή��ǉ���</br>
	/// <br>			: �@�@�\�����ʓ���ҏW��Ԃɂē��̓`�F�b�N��������Ȃ��s��C��</br>
	/// </remarks>
	public partial class SFANL08130UA : Form
	{
		#region PrivateMember
		// ���o��������LIST
		private List<FrePExCndD>	_frePExCndDList;
		// �L�����o����LIST
		private List<FrePprECnd>	_frePprECndList;
		// ���o�����ݒ�LIST�����l
		private List<FrePprECnd>	_buf_frePprECndList;
		// �󎚍��ڐݒ�LIST
		private List<PrtItemSetWork> _prtItemSetList;
		// �o�C���h�f�[�^�e�[�u��
		private DataTable			_dt;
		// �ύX�`�F�b�N�p�o�b�t�@
		private string				_bufText;
		private int					_bufCode;
////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
		private bool				_cancelCloseCheck;
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
		#endregion

		#region Const
		// �A�Z���u��ID
		private const string ctASSEMBLY_ID = "SFANL08130U";
		// �c�[���{�^���p
		private const string ctButtonTool_Decide = "Decide_ButtonTool";
		private const string ctButtonTool_Return = "Return_ButtonTool";
		private const string ctButtonTool_Cancel = "Cancel_ButtonTool";
		// �X�L�[�}�p
		private const string TBL_FREPPRECND_SETTING		= "FrePprECndSetting";
		private const string COL_USEDFLG				= "UsedFlg";				// �g�p�t���O
		private const string COL_DISPLAYORDER			= "DisplayOrder";			// �\������
		private const string COL_EXTRACONDITIONTITLE	= "ExtraConditionTitle";	// ���o�����^�C�g��
		private const string COL_FREPRTPPREXTRACONDCD	= "FrePrtPprExtraCondCd";	// ���R���[���o�����}��
		private const string COL_FREPPRECND				= "FrePprECnd";				// ���R���[���o�����}�X�^
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08130UA()
		{
			InitializeComponent();

			_frePprECndList		= new List<FrePprECnd>();
			_buf_frePprECndList = new List<FrePprECnd>();

			InitializeSetting();
		}
		#endregion

		#region Property
		/// <summary>�g�p���钊�o�����}�X�^</summary>
		public List<FrePprECnd> UseFrePprECndList
		{
			get { return _frePprECndList; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���R���[���������ݒ��ʕ\������
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�LIST</param>
		/// <param name="frePExCndDList">���R���[���o��������LIST</param>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <returns>�_�C�A���O���U���g</returns>
		/// <remarks>
		/// <br>Note		: ���R���[����������ʂ��N�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		public DialogResult ShowFrePprECndSetting(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList, List<PrtItemSetWork> prtItemSetList)
		{
			_frePExCndDList	= frePExCndDList;
			foreach (FrePprECnd frePprECnd in frePprECndList)
				_buf_frePprECndList.Add(frePprECnd.Clone());
			_prtItemSetList	= prtItemSetList;

			InitializeData();

			return this.ShowDialog();
		}

////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="frePprECndList">���R���[���o�����ݒ�LIST</param>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="errIndex">�s���ƂȂ鍀�ڂ�ListIndex</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2008.03.19</br>
		/// </remarks>
		public bool InputCheck(List<FrePprECnd> frePprECndList, out string message, out int errIndex)
		{
			message = string.Empty;
			errIndex = 0;

			// ���o�����ɓ��t�n���܂܂�Ă��邩�̃`�F�b�N
			bool existExtrTypeDate = false;
			foreach (FrePprECnd frePprECnd in frePprECndList)
			{
				if (frePprECnd.UsedFlg == 1 && frePprECnd.ExtraConditionDivCd == 4)
				{
					existExtrTypeDate = true;
					break;
				}
			}
			if (!existExtrTypeDate)
			{
				message		= "���t�n������1�͕K�v�ł��B";
				errIndex	= -1;
				return false;
			}

			// �e���o�����ɂ��Ẵ`�F�b�N
			if (!SFANL08132CA.InputCheck(frePprECndList, false, out message, out errIndex))
				return false;

			return true;
		}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂ���ъe��ϐ��̏����������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void InitializeSetting()
		{
			this.tToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// �m��{�^��
			ButtonTool decideButton = (ButtonTool)this.tToolbarsManager.Tools[ctButtonTool_Decide];
			if (decideButton != null) decideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			// �߂�{�^��
			ButtonTool returnButton = (ButtonTool)this.tToolbarsManager.Tools[ctButtonTool_Return];
			if (returnButton != null) returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			// ����{�^��
			ButtonTool cancelButton = (ButtonTool)this.tToolbarsManager.Tools[ctButtonTool_Cancel];
			if (cancelButton != null) cancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;

			DataSet ds = new DataSet();
			_dt = new DataTable(TBL_FREPPRECND_SETTING);
			_dt.Columns.Add(COL_USEDFLG,				typeof(int));			// �g�p�t���O
			_dt.Columns.Add(COL_DISPLAYORDER,			typeof(int));			// �\������
			_dt.Columns.Add(COL_EXTRACONDITIONTITLE,	typeof(string));		// ���o�����^�C�g��
			_dt.Columns.Add(COL_FREPRTPPREXTRACONDCD,	typeof(int));			// ���R���[���o�����}��
			_dt.Columns.Add(COL_FREPPRECND,				typeof(FrePprECnd));	// ���R���[���o�����}�X�^
			ds.Tables.Add(_dt);
			this.gridExtrList.DataSource = ds;
			this.gridExtrList.DataMember = TBL_FREPPRECND_SETTING;
		}

		/// <summary>
		/// �f�[�^����������
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂɕ\������f�[�^��������Ԃɂ��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void InitializeData()
		{
			_dt.Rows.Clear();

			// �f�[�^�̐ݒ�
			foreach (FrePprECnd frePprECnd in _buf_frePprECndList)
				SetFrePprECndToDataTable(frePprECnd.Clone(), -1);
		}

		/// <summary>
		/// �f�[�^�e�[�u�����X�V����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="index">�C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note		: DataTable�Ɏ��R���[���o�����ݒ�}�X�^���Z�b�g���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SetFrePprECndToDataTable(FrePprECnd frePprECnd, int index)
		{
			DataRow dr;
			if (index < 0)
			{
				dr = _dt.NewRow();
				_dt.Rows.Add(dr);
			}
			else
			{
				dr = _dt.Rows[index];
			}

			dr[COL_USEDFLG]					= frePprECnd.UsedFlg;				// �g�p�t���O
			dr[COL_DISPLAYORDER]			= frePprECnd.DisplayOrder;			// �\������
			dr[COL_EXTRACONDITIONTITLE]		= frePprECnd.ExtraConditionTitle;	// ���o�����^�C�g��
			dr[COL_FREPRTPPREXTRACONDCD]	= frePprECnd.FrePrtPprExtraCondCd;	// ���R���[���o�����}��
			dr[COL_FREPPRECND]				= frePprECnd;						// ���R���[���o�����}�X�^
		}

		/// <summary>
		/// ��ʐ�������
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <remarks>
		/// <br>Note		: ���R���[���o�����ݒ�}�X�^�̏������ɉ�ʍ\����ύX���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UpdateSetttingUI(FrePprECnd frePprECnd)
		{
			// ������ ���o�����^�C�v�̐ݒ� ������
			this.cmdExtraConditionTypeCd.Items.Clear();
			this.cmdExtraConditionTypeCd.ReadOnly = false;
			switch (frePprECnd.ExtraConditionDivCd)
			{
				case 1:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "���S��v");
					this.cmdExtraConditionTypeCd.Items.Add(1, "�͈�");
					break;
				}
				case 2:
				case 3:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "���S��v");
					this.cmdExtraConditionTypeCd.Items.Add(1, "�͈�");
					this.cmdExtraConditionTypeCd.Items.Add(2, "�����܂�����");
					break;
				}
				case 4:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "���S��v");
					this.cmdExtraConditionTypeCd.Items.Add(1, "�͈�");
					this.cmdExtraConditionTypeCd.Items.Add(3, "���ԁi�J�n����j");
					this.cmdExtraConditionTypeCd.Items.Add(4, "���ԁi�I������j");
					break;
				}
				case 5:
				case 6:
				{
					this.cmdExtraConditionTypeCd.Items.Add(0, "�@");
					this.cmdExtraConditionTypeCd.ReadOnly = true;
					break;
				}
			}

			if (frePprECnd.UsedFlg == 1)
			{
				this.pnlExtrProperty.Enabled = true;
				this.pnlDefaultSetting.Enabled = true;
			}
			else
			{
				this.pnlExtrProperty.Enabled = false;
				this.pnlDefaultSetting.Enabled = false;
			}

			// �f�[�^�̃Z�b�g
			this.tedExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
			this.cmdExtraConditionTypeCd.Value	= frePprECnd.ExtraConditionTypeCd;
			this.ndtDisplayOder.SetInt(frePprECnd.DisplayOrder);

			UpdateDefaultSettingUI(frePprECnd);
		}

		/// <summary>
		/// �����l�ݒ�UI�X�V����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <remarks>
		/// <br>Note		: ���R���[���o�����ݒ�}�X�^�̏������ɏ����l�ݒ�p��ʂ��쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UpdateDefaultSettingUI(FrePprECnd frePprECnd)
		{
			while (this.pnlDefSettingUI.Controls.Count > 0)
				this.pnlDefSettingUI.Controls[0].Dispose();

			Control defSettingCtrl = SFANL08132CA.GetExtrSettingControl(frePprECnd, _frePExCndDList);
			if (defSettingCtrl != null)
			{
				this.pnlDefSettingUI.Controls.Add(defSettingCtrl);
				defSettingCtrl.Dock = DockStyle.Top;
			}
		}

		/// <summary>
		/// �����l�ݒ�擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <remarks>
		/// <br>Note		: �����l�ݒ�p��ʂ�蒊�o���������l���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void GetDefaultSettingData(FrePprECnd frePprECnd)
		{
			if (frePprECnd != null && frePprECnd.UsedFlg == 1)
			{
				string controlName = SFANL08132CA.GetControlName(frePprECnd);
				if (this.pnlDefSettingUI.Controls.ContainsKey(controlName))
				{
					IFreePrintUserControl iFreePrintUserControl = this.pnlDefSettingUI.Controls[controlName] as IFreePrintUserControl;
					iFreePrintUserControl.GetFrePprECndInfo(ref frePprECnd);
				}
			}
		}

		/// <summary>
		/// �ύX�`�F�b�N����
		/// </summary>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ̏�񂪕ύX����Ă��邩�`�F�b�N���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private bool ChangeCheck()
		{
			List<FrePprECnd> frePprECndList = GetFrePprECndList();
			foreach (FrePprECnd compareFrePprECnd in frePprECndList)
			{
				if (!_buf_frePprECndList.Exists(
					delegate(FrePprECnd frePprECnd)
					{
////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//						if (frePprECnd.EqualsWithoutExtrDate(compareFrePprECnd))
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
						if (frePprECnd.EqualsWithoutSystemDate(compareFrePprECnd))
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
							return true;
						else
							return false;
					}
				))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// ���R���[���o����LIST�擾����
		/// </summary>
		/// <returns>���R���[���o����LIST</returns>
		private List<FrePprECnd> GetFrePprECndList()
		{
			List<FrePprECnd> frePprECndList = new List<FrePprECnd>();

			foreach (DataRow dr in _dt.Rows)
				frePprECndList.Add((FrePprECnd)dr[COL_FREPPRECND]);

			return frePprECndList;
		}

		/// <summary>
		/// �\�����ʍX�V����
		/// </summary>
		/// <param name="usedFlg">�X�V��̎g�p�t���O</param>
		/// <param name="index">�Ώۃf�[�^�̃C���f�b�N�X</param>
		/// <param name="nextOder">�X�V��̕\������</param>
		/// <remarks>
		/// <br>Note		: �\�����ʂ̍X�V�������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UpdateDisplayOder(int usedFlg, int index, int nextOder)
		{
			DataRow dr = _dt.Rows[index];
			FrePprECnd frePprECnd = (FrePprECnd)dr[COL_FREPPRECND];

			int offerOrUserStCd = (int)dr[COL_USEDFLG];
			DataRow[] drArray;
			if (usedFlg == 1)
			{
				// ���݂̍ő�\�����ʂ��擾
				string filter = COL_USEDFLG + "=1";
				drArray = _dt.Select(filter, COL_DISPLAYORDER + " DESC");
				if (drArray.Length != 0)
				{
					int maxDispOder = (int)drArray[0][COL_DISPLAYORDER];
					if (nextOder == 0)
						nextOder = maxDispOder + 1;
					else if (nextOder > maxDispOder)
						nextOder = maxDispOder;
				}
				else
				{
					if (nextOder == 0)
						nextOder = 1;
				}

				if (nextOder > frePprECnd.DisplayOrder)
				{
					filter = COL_USEDFLG + "=1 AND " + COL_DISPLAYORDER + ">" + frePprECnd.DisplayOrder + " AND " + COL_DISPLAYORDER + "<=" + nextOder;
					drArray = _dt.Select(filter, COL_DISPLAYORDER + " ASC");
					if (drArray.Length != 0)
					{
						foreach (DataRow moveRow in drArray)
						{
							FrePprECnd wkFrePprECnd = (FrePprECnd)moveRow[COL_FREPPRECND];
							wkFrePprECnd.DisplayOrder--;
							SetFrePprECndToDataTable(wkFrePprECnd, _dt.Rows.IndexOf(moveRow));
						}
					}
				}
				else
				{
					filter = COL_USEDFLG + "=1 AND " + COL_DISPLAYORDER + "<" + frePprECnd.DisplayOrder + " AND " + COL_DISPLAYORDER + ">=" + nextOder;
					drArray = _dt.Select(filter, COL_DISPLAYORDER + " ASC");
					if (drArray.Length != 0)
					{
						foreach (DataRow moveRow in drArray)
						{
							FrePprECnd wkFrePprECnd = (FrePprECnd)moveRow[COL_FREPPRECND];
							wkFrePprECnd.DisplayOrder++;
							SetFrePprECndToDataTable(wkFrePprECnd, _dt.Rows.IndexOf(moveRow));
						}
					}
				}

				frePprECnd.DisplayOrder = nextOder;
				SetFrePprECndToDataTable(frePprECnd, index);

				this.pnlExtrProperty.Enabled = true;
				this.pnlDefaultSetting.Enabled = true;
			}
			else
			{
				// �K�{���o�������ڂ̏ꍇ�͈ȉ��̏������s��Ȃ�
				if (frePprECnd.NecessaryExtraCondCd == 1) return;

				int dispOder	= frePprECnd.DisplayOrder;
				string filter	= COL_USEDFLG + "=1 AND " + COL_DISPLAYORDER + " > " + frePprECnd.DisplayOrder;
				drArray = _dt.Select(filter, COL_DISPLAYORDER + " ASC");
				foreach (DataRow moveRow in drArray)
				{
					FrePprECnd wkFrePprECnd = (FrePprECnd)moveRow[COL_FREPPRECND];
					wkFrePprECnd.DisplayOrder = dispOder++;
					SetFrePprECndToDataTable(wkFrePprECnd, _dt.Rows.IndexOf(moveRow));
				}

				frePprECnd.DisplayOrder = 999;	// �g�p���Ȃ��f�[�^��999�Œ�
				SetFrePprECndToDataTable(frePprECnd, index);

				this.pnlExtrProperty.Enabled = false;
				this.pnlDefaultSetting.Enabled = false;
			}

			// �\�����ʂ̏����Ń\�[�g
			this.gridExtrList.DisplayLayout.Bands[0].Columns[COL_DISPLAYORDER].SortIndicator
				= SortIndicator.Ascending;
			if (this.gridExtrList.ActiveRow != null)
				this.gridExtrList.ActiveRowScrollRegion.ScrollRowIntoView(this.gridExtrList.ActiveRow);
			
			this.ndtDisplayOder.SetInt(frePprECnd.DisplayOrder);
		}

		/// <summary>
		/// ���g�p�f�[�^����������
		/// </summary>
		/// <param name="frePprECndList">���o�����ݒ�LIST</param>
		/// <remarks>
		/// <br>Note		: ���g�p�ƂȂ��Ă��钊�o�����̏��������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void UnusedDataInitialize(List<FrePprECnd> frePprECndList)
		{
			foreach (FrePprECnd frePprECnd in frePprECndList)
			{
				if (frePprECnd.UsedFlg == 0)
				{
					if (_prtItemSetList != null && _prtItemSetList.Count > 0)
					{
						PrtItemSetWork prtItemSet = _prtItemSetList.Find(
							delegate(PrtItemSetWork prtItemSetWork)
							{
								if (prtItemSetWork.FreePrtPaperItemCd == frePprECnd.FrePrtPprExtraCondCd)
									return true;
								else
									return false;
							}
						);
						if (prtItemSet != null) frePprECnd.ExtraConditionTitle = prtItemSet.FreePrtPaperItemNm;
					}
					frePprECnd.StExtraNumCode		= 0;
					frePprECnd.EdExtraNumCode		= 0;
					frePprECnd.StExtraCharCode		= string.Empty;
					frePprECnd.EdExtraCharCode		= string.Empty;
					frePprECnd.StExtraDateBaseCd	= 2;
					frePprECnd.StExtraDateSignCd	= 0;
					frePprECnd.StExtraDateNum		= 0;
					frePprECnd.StExtraDateUnitCd	= 0;
					frePprECnd.StartExtraDate		= 0;
					frePprECnd.EdExtraDateBaseCd	= 2;
					frePprECnd.EdExtraDateSignCd	= 0;
					frePprECnd.EdExtraDateNum		= 0;
					frePprECnd.EdExtraDateUnitCd	= 0;
					frePprECnd.EndExtraDate			= 0;
					frePprECnd.CheckItemCode1		= -1;
					frePprECnd.CheckItemCode2		= -1;
					frePprECnd.CheckItemCode3		= -1;
					frePprECnd.CheckItemCode4		= -1;
					frePprECnd.CheckItemCode5		= -1;
					frePprECnd.CheckItemCode6		= -1;
					frePprECnd.CheckItemCode7		= -1;
					frePprECnd.CheckItemCode8		= -1;
					frePprECnd.CheckItemCode9		= -1;
					frePprECnd.CheckItemCode10		= -1;
				}
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void tToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			this.gridExtrList.Focus();
			gridExtrList_BeforeRowDeactivate(this.gridExtrList, new CancelEventArgs());

			switch (e.Tool.Key)
			{
				case ctButtonTool_Decide:	// �m��{�^��
				{
					List<FrePprECnd> frePprECndList = GetFrePprECndList();

					string	message;
					int		errIndex;
////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//					if (SFANL08132CA.InputCheck(frePprECndList, false, out message, out errIndex))
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
					// ��ʑS�̂ł̓��̓`�F�b�N���e�����̏����l�Ɋւ�����̓`�F�b�N
					if (InputCheck(frePprECndList, out message, out errIndex))
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
					{
						// ���g�p�f�[�^����������
						UnusedDataInitialize(frePprECndList);

						_frePprECndList		= frePprECndList;
						this.DialogResult	= DialogResult.OK;
////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
						_cancelCloseCheck	= true;
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
						this.Close();
					}
					else
					{
						DialogResult dlgRet = TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
							ctASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
							message,							// �\�����郁�b�Z�[�W 
							0,									// �X�e�[�^�X�l
							MessageBoxButtons.OK);				// �\������{�^��
////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//						foreach (UltraGridRow row in this.gridExtrList.Rows)
//						{
//							if ((int)row.Cells[COL_FREPRTPPREXTRACONDCD].Value == frePprECndList[errIndex].FrePrtPprExtraCondCd)
//							{
//								row.Activate();
//								break;
//							}
//						}
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
						if (errIndex >= 0 && errIndex < frePprECndList.Count)
						{
							foreach (UltraGridRow row in this.gridExtrList.Rows)
							{
								if ((int)row.Cells[COL_FREPRTPPREXTRACONDCD].Value == frePprECndList[errIndex].FrePrtPprExtraCondCd)
								{
									row.Activate();
									break;
								}
							}
						}
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
					}
					break;
				}
				case ctButtonTool_Return:	// �߂�{�^��
				{
////////////////////////////////////////////// 2008.04.04 TERASAKA DEL STA //
//					if (!ChangeCheck())
//					{
//						DialogResult dlgRet = TMsgDisp.Show(
//							emErrorLevel.ERR_LEVEL_CONFIRM,		// �G���[���x��
//							ctASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
//							string.Empty,						// �\�����郁�b�Z�[�W 
//							0,									// �X�e�[�^�X�l
//							MessageBoxButtons.YesNo);			// �\������{�^��
//						if (dlgRet == DialogResult.Yes)
//						{
//							this.DialogResult = DialogResult.Cancel;
//							this.Close();
//						}
//					}
//					else
//					{
//						this.DialogResult = DialogResult.Cancel;
//						this.Close();
//					}
// 2008.04.04 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
					this.Close();
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
					break;
				}
				case ctButtonTool_Cancel:	// ����{�^��
				{
					if (!ChangeCheck())
					{
						string message = "���ݕҏW���̃f�[�^�����݂��܂��B\r\n\r\n������Ԃɖ߂��܂����H";
						DialogResult dlgRet = TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_QUESTION,	// �G���[���x��
							ctASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
							message.ToString(),					// �\�����郁�b�Z�[�W 
							0,									// �X�e�[�^�X�l
							MessageBoxButtons.YesNo);			// �\������{�^��
						if (dlgRet == DialogResult.Yes)
						{
							InitializeData();
							this.gridExtrList.Rows[0].Activate();
							this.gridExtrList.Focus();
						}
					}
					break;
				}
			}
		}

		/// <summary>
		/// �O���b�h�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			// �g�p�t���O
			e.Layout.Bands[0].Columns[COL_USEDFLG].Header.Caption = "�g�p�敪";
			e.Layout.Bands[0].Columns[COL_USEDFLG].Style
				= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			// �\������
			e.Layout.Bands[0].Columns[COL_DISPLAYORDER].Header.Caption	= "�\������";
			e.Layout.Bands[0].Columns[COL_DISPLAYORDER].CellAppearance.TextHAlign = HAlign.Right;
			// ���o�����^�C�g��
			e.Layout.Bands[0].Columns[COL_EXTRACONDITIONTITLE].Header.Caption = "���o�����^�C�g��";
			// ���R���[���o�����}�X�^
			e.Layout.Bands[0].Columns[COL_FREPPRECND].Hidden = true;
			// ���R���[���o�����}��
			e.Layout.Bands[0].Columns[COL_FREPRTPPREXTRACONDCD].Hidden = true;

			// �\�����ʂ̏����Ń\�[�g
			e.Layout.Bands[0].Columns[COL_DISPLAYORDER].SortIndicator
				= SortIndicator.Ascending;
		}

		/// <summary>
		/// �O���b�h�s�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �s�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_InitializeRow(object sender, InitializeRowEventArgs e)
		{
			FrePprECnd frePprECnd = (FrePprECnd)e.Row.Cells[COL_FREPPRECND].Value;
			if (frePprECnd.NecessaryExtraCondCd == 1)
				e.Row.Appearance.ForeColor = Color.Red;
			else
				e.Row.Appearance.ForeColor = Color.Black;
		}

		/// <summary>
		/// �O���b�h�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃN���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_MouseClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElement�𗘗p���č��W�ʒu�̃R���g���[�����擾
			UIElement element = this.gridExtrList.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// �N���b�N�����ʒu��GridRow�̏ꍇ�̂ݏ������s��
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null && ultraGridCell.Column.Key.Equals(COL_USEDFLG))
			{
				if ((int)ultraGridCell.Value == 0)
					UpdateDisplayOder(1, ultraGridCell.Row.ListIndex, 0);
				else
					UpdateDisplayOder(0, ultraGridCell.Row.ListIndex, 999);
			}
		}

		/// <summary>
		/// �O���b�hAfterRowActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��̍s���A�N�e�B�u���������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridExtrList.DisplayLayout.Override.SelectedRowAppearance.ForeColor
				= this.gridExtrList.ActiveRow.Appearance.ForeColor;

			this.gridExtrList.ActiveRow.Selected = true;

			// ��ʂ̍č쐬
			FrePprECnd frePprECnd = (FrePprECnd)this.gridExtrList.ActiveRow.Cells[COL_FREPPRECND].Value;
			UpdateSetttingUI(frePprECnd);
		}

		/// <summary>
		/// �O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃL�[���������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Right:
				{
					if (this.pnlExtrProperty.Enabled)
						this.ndtDisplayOder.Focus();
					e.Handled = true;
					break;
				}
				case Keys.Space:
				{
					if (this.gridExtrList.ActiveRow != null)
					{
						if ((int)this.gridExtrList.ActiveRow.Cells[COL_USEDFLG].Value == 0)
							UpdateDisplayOder(1, this.gridExtrList.ActiveRow.ListIndex, 0);
						else
							UpdateDisplayOder(0, this.gridExtrList.ActiveRow.ListIndex, 999);
					}
					break;
				}
			}
		}

		/// <summary>
		/// AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����ҏW���[�h���I��������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SettingControl_AfterExitEditMode(object sender, EventArgs e)
		{
			bool isDataChanged = false;
			
			if (sender is TEdit)
				isDataChanged = !_bufText.Equals(((TEdit)sender).Text);
			if (sender is TNedit)
				isDataChanged = !_bufCode.Equals(((TNedit)sender).GetInt());
			if (sender is TComboEditor)
			{
				isDataChanged = !_bufCode.Equals((int)((TComboEditor)sender).Value);
				_bufCode = (int)((TComboEditor)sender).Value;
			}

			if (isDataChanged)
			{
				FrePprECnd frePprECnd = (FrePprECnd)this.gridExtrList.ActiveRow.Cells[COL_FREPPRECND].Value;
				GetDefaultSettingData(frePprECnd);

				if (sender == this.ndtDisplayOder)
				{
					SetFrePprECndToDataTable(frePprECnd, this.gridExtrList.ActiveRow.ListIndex);
					UpdateDisplayOder(1, this.gridExtrList.ActiveRow.ListIndex, this.ndtDisplayOder.GetInt());
				}
				else if (sender == this.tedExtraConditionTitle)
				{
					frePprECnd.ExtraConditionTitle	= this.tedExtraConditionTitle.Text;
					SetFrePprECndToDataTable(frePprECnd, this.gridExtrList.ActiveRow.ListIndex);
					UpdateDefaultSettingUI(frePprECnd);
				}
				else if (sender == this.cmdExtraConditionTypeCd)
				{
					frePprECnd.ExtraConditionTypeCd	= (int)this.cmdExtraConditionTypeCd.Value;
					SetFrePprECndToDataTable(frePprECnd, this.gridExtrList.ActiveRow.ListIndex);
					UpdateDefaultSettingUI(frePprECnd);
				}
			}
		}

		/// <summary>
		/// Enter�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SettingControl_Enter(object sender, EventArgs e)
		{
			if (sender is TEdit)
				_bufText = ((TEdit)sender).Text;
			if (sender is TNedit)
				_bufCode = ((TNedit)sender).GetInt();
			if (sender is TComboEditor)
				_bufCode = (int)((TComboEditor)sender).Value;
		}

		/// <summary>
		/// �t�H�[���L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[����ŃL�[�������ꂽ���ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SFANL08130UA_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				ToolClickEventArgs ev = new ToolClickEventArgs(this.tToolbarsManager.Tools[ctButtonTool_Return], new ListToolItem());
				tToolbarsManager_ToolClick(sender, ev);
			}
		}

		/// <summary>
		/// BeforeRowDeactivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �s����A�N�e�B�u�ɂȂ�O�ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void gridExtrList_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			int listIndex = this.gridExtrList.ActiveRow.ListIndex;

			FrePprECnd frePprECnd = _dt.Rows[listIndex][COL_FREPPRECND] as FrePprECnd;
			GetDefaultSettingData(frePprECnd);

			SetFrePprECndToDataTable(frePprECnd, listIndex);
		}

		/// <summary>
		/// Shown�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����ŏ��ɕ\�����ꂽ���ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.22</br>
		/// </remarks>
		private void SFANL08130UA_Shown(object sender, EventArgs e)
		{
			if (this.gridExtrList.Rows.Count > 0)
				this.gridExtrList.Rows[0].Activate();
		}

////////////////////////////////////////////// 2008.04.04 TERASAKA ADD STA //
		/// <summary>
		/// FormClosing�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����ŏ��ɕ\�����ꂽ���ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.04.04</br>
		/// </remarks>
		private void SFANL08130UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !_cancelCloseCheck)
			{
////////////////////////////////////////////// 2008.04.07 TERASAKA ADD STA //
				this.gridExtrList.Focus();
// 2008.04.07 TERASAKA ADD END //////////////////////////////////////////////
				gridExtrList_BeforeRowDeactivate(this.gridExtrList, new CancelEventArgs());

				if (!ChangeCheck())
				{
					DialogResult dlgRet = TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_CONFIRM,		// �G���[���x��
						ctASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						string.Empty,						// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.YesNo);			// �\������{�^��
					if (dlgRet == DialogResult.No)
					{
						e.Cancel = true;
					}
				}
			}
		}
// 2008.04.04 TERASAKA ADD END //////////////////////////////////////////////
		#endregion
	}
}