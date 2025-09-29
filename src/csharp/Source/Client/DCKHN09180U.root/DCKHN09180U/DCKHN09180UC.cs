using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{

	/// <summary>
	/// �|���}�X�^�ꊇ�o�^ �u�����͉�ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �|���}�X�^�ꊇ�o�^ �u�����͉�ʃN���X</br>
	/// <br>Programmer	: 30167 ���@�O�M</br>
	/// <br>Date		: 2008.01.10</br>
	/// </remarks>
	public partial class DCKHN09180UC : Form
	{
		#region Constructor
		/// <summary>
		/// �|���}�X�^�ꊇ�o�^ �u�����͉�ʃN���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �|���}�X�^�ꊇ�o�^ �u�����͉�ʃN���X�̃C���X�^���X���쐬</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date		: 2008.01.10</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public DCKHN09180UC(ref UltraGrid uGrid)
		{
			InitializeComponent();

			this._rateBlanketAcs = new RateBlanketAcs();
			
			// �O���b�h�f�[�^�擾
			this.DCKHN09180UB_uGrid = uGrid;
			
			//--------------------
			// �R���{�{�b�N�X�ݒ�
			//--------------------
			// �R���{�{�b�N�X�p�f�[�^�e�[�u��
			this._dataTableReplaceTarget = new DataTable();
			this._dataTablePriceDiv = new DataTable();
			this._dataTableUnPrcCalcDiv = new DataTable();
			this._dataTableUnPrcFracProcDiv = new DataTable();
			this._dataTableBargainCd = new DataTable();

			DataTblColumnConstComboList(ref this._dataTableReplaceTarget);
			DataTblColumnConstComboList(ref this._dataTablePriceDiv);
			DataTblColumnConstComboList(ref this._dataTableUnPrcCalcDiv);
			DataTblColumnConstComboList(ref this._dataTableUnPrcFracProcDiv);
			DataTblColumnConstComboList(ref this._dataTableBargainCd);
		}
		#endregion
		
		#region Private Member

		private int _target_tComboEditorValue = -1;
		private RateBlanketAcs _rateBlanketAcs = null;
		private UltraGrid DCKHN09180UB_uGrid = null;
		
		//------------------
		// �R���{�{�b�N�X�p
		//------------------
		private DataTable _dataTableReplaceTarget = null;		// �u���ΏۃR���{�{�b�N�X�p
		private DataTable _dataTablePriceDiv = null;			// ���i�敪�R���{�{�b�N�X�p
		private DataTable _dataTableUnPrcCalcDiv = null;		// �P���Z�o�敪�R���{�{�b�N�X�p
		private DataTable _dataTableUnPrcFracProcDiv = null;	// �[�������敪�R���{�{�b�N�X�p
		private DataTable _dataTableBargainCd = null;			// �����敪�R���{�{�b�N�X�p

		#endregion Private Member

		#region Private Const Member

		// �R���{�{�b�N�X�p
		private const string COMBO_CODE = "COMBO_CODE";
		private const string COMBO_NAME = "COMBO_NAME";
		
		// ���ڌ���
		private const int PRICEFL_NUM = 16;
		private const int RATEVAL_NUM = 6;
		private const int UNPRCFRACPROCUNIT_NUM = 12;
		
		#endregion Private Const Member

		/// <summary>
		/// ����������
		/// </summary>
		/// <remarks>
		/// <br>Note       : UI�̏������������s���B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			//------------------------------------
			// �R���{�{�b�N�X�p�f�[�^�e�[�u���ݒ�
			//------------------------------------
			SetComboData(ref RateBlanket._replaceItemSList, ref this._dataTableReplaceTarget);
			SetComboData(ref RateBlanket._priceDivSList, ref this._dataTablePriceDiv);
			SetComboData(ref Rate._unPrcCalcDivTable, ref this._dataTableUnPrcCalcDiv);
			SetComboData(ref Rate._unPrcFracProcDivTable, ref this._dataTableUnPrcFracProcDiv);
			SetComboData(ref RateBlanket._bargainCdSList, ref this._dataTableBargainCd);

			//-----------------------------------
			// �R���{�{�b�N�X�ݒ�i�Œ蕔���̂݁j
			//-----------------------------------
			BindCombo(ref this.Target_tComboEditor, ref this._dataTableReplaceTarget);

			TargetVisibleChange(0);
		}

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				case "Target_tComboEditor":
					{
						if (this.Target_tComboEditor != null)
						{
							TargetVisibleChange((Int32)this.Target_tComboEditor.Value);
						}
						break;
					}
			}
		}

		/// <summary>
		/// �R���{�{�b�N�X�p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DataTblColumnConstComboList(ref DataTable wkTable)
		{
			wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// �R�[�h
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// ����

			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

		/// <summary>
		/// �R���{�{�b�N�X�f�[�^�ݒ�
		/// </summary>
		/// <remarks>
		/// <param name="sList">�\�[�g���X�g</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SetComboData(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = (Int32)de.Key;
					dr[COMBO_NAME] = de.Value.ToString();

					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// �R���{�{�b�N�X�o�C���h
		/// </summary>
		/// <remarks>
		/// <param name="tCombo">TComboEditor</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�Ƀo�C���h���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
		{
			tCombo.DisplayMember = COMBO_NAME;
			tCombo.DataSource = dataTable.DefaultView;
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void ScreenClear()
		{
			//------------------
			// �ݒ�f�[�^�N���A
			//------------------
			// �R���{�{�b�N�X������
			this.Target_tComboEditor.Value = RateBlanket._replaceItemSList.GetKey(0);		// �u���R���{�{�b�N�X
			this._target_tComboEditorValue = -1;

			this.TargetData_tComboEditor.Clear();
			this.TargetData_tDateEdit.Clear();
			this.TargetData_tNedit.Clear();
			
			this.ReplaceData_tComboEditor.Clear();
			this.ReplaceData_tDateEdit.Clear();
			this.ReplaceData_tNedit.Clear();
		}

		/// <summary>
		/// �u���Ώە\���ύX
		/// </summary>
		/// <param name="target">�u���ΏۃR�[�h</param>
		/// <remarks>
		/// <br>Note�@     : �u���Ώۂ̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void TargetVisibleChange(int target)
		{
			if (this._target_tComboEditorValue == target) return;

			// �S�Ĕ�\���ɂ���
			this.TargetData_tComboEditor.Hide();
			this.TargetData_tDateEdit.Hide();
			this.TargetData_tNedit.Hide();
			
			this.ReplaceData_tComboEditor.Hide();
			this.ReplaceData_tDateEdit.Hide();
			this.ReplaceData_tNedit.Hide();
			
			// �S�ăN���A����
			this.TargetData_tComboEditor.Clear();
			this.TargetData_tDateEdit.Clear();
			this.TargetData_tNedit.Clear();
			
			this.ReplaceData_tComboEditor.Clear();
			this.ReplaceData_tDateEdit.Clear();
			this.ReplaceData_tNedit.Clear();
			
			switch(target)
			{
				case 0:	// �|���J�n��
					{
						this.TargetData_tDateEdit.Show();
						this.ReplaceData_tDateEdit.Show();
						break;
					}
				case 1:	// ���i
				case 4:	// �|��
				case 5:	// �[�������P��
					{
						switch(target)
						{
							case 1:
								{
									this.TargetData_tNedit.MaxLength = PRICEFL_NUM;
									this.TargetData_tNedit.ExtEdit.Column = PRICEFL_NUM;

									this.ReplaceData_tNedit.MaxLength = PRICEFL_NUM;
									this.ReplaceData_tNedit.ExtEdit.Column = PRICEFL_NUM;
									break;
								}
							case 4:
								{
									this.TargetData_tNedit.MaxLength = RATEVAL_NUM;
									this.TargetData_tNedit.ExtEdit.Column = RATEVAL_NUM;

									this.ReplaceData_tNedit.MaxLength = RATEVAL_NUM;
									this.ReplaceData_tNedit.ExtEdit.Column = RATEVAL_NUM;
									break;
								}
							default:
								{
									this.TargetData_tNedit.MaxLength = UNPRCFRACPROCUNIT_NUM;
									this.TargetData_tNedit.ExtEdit.Column = UNPRCFRACPROCUNIT_NUM;

									this.ReplaceData_tNedit.MaxLength = UNPRCFRACPROCUNIT_NUM;
									this.ReplaceData_tNedit.ExtEdit.Column = UNPRCFRACPROCUNIT_NUM;
									break;
								}
						}
						this.TargetData_tNedit.Show();
						this.ReplaceData_tNedit.Show();
						break;
					}
				case 2:	// ���i�敪
				case 3:	// �P���Z�o�敪
				case 6:	// �[�������敪
				case 7:	// �����敪
					{
						this.TargetData_tComboEditor.BeginUpdate();
						this.ReplaceData_tComboEditor.BeginUpdate();
						
						// ��x�N���A����
						this.TargetData_tComboEditor.Items.Clear();
						this.ReplaceData_tComboEditor.Items.Clear();
						
						// �o�C���h�N���A
						this.TargetData_tComboEditor.DataSource = "";
						this.ReplaceData_tComboEditor.DataSource = "";
						
						// �ēx�ݒ肷��
						switch(target)
						{
							case 2:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTablePriceDiv);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTablePriceDiv);
									break;
								}
							case 3:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTableUnPrcCalcDiv);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTableUnPrcCalcDiv);
									break;
								}
							case 6:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTableUnPrcFracProcDiv);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTableUnPrcFracProcDiv);
									break;
								}
							default:
								{
									BindCombo(ref this.TargetData_tComboEditor, ref this._dataTableBargainCd);
									BindCombo(ref this.ReplaceData_tComboEditor, ref this._dataTableBargainCd);
									break;
								}
						}

						// �擪�f�[�^��\������
						if (this.TargetData_tComboEditor.Items.Count > 0)
						{
							this.TargetData_tComboEditor.Value = this.TargetData_tComboEditor.Items[0].DataValue;
						}
						if (this.ReplaceData_tComboEditor.Items.Count > 0)
						{
							this.ReplaceData_tComboEditor.Value = this.ReplaceData_tComboEditor.Items[0].DataValue;
						}
						this.TargetData_tComboEditor.EndUpdate();
						this.ReplaceData_tComboEditor.EndUpdate();

						this.TargetData_tComboEditor.Show();
						this.ReplaceData_tComboEditor.Show();
						break;
					}
			}
			
			// �I�������ԍ���ێ�
			this._target_tComboEditorValue = target;
		}

		/// <summary>
		/// �u������
		/// </summary>
		/// <remarks>
		/// <br>Note�@     : �u���������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void TargetReplace(int target, out int cnt)
		{
			cnt = 0;	// �u����
			
			// �u���Ώۃf�[�^����
			foreach(UltraGridRow uRow in DCKHN09180UB_uGrid.Rows)
			{	
				switch(target)
				{
					//-----------
					// TDateEdit
					//-----------
					case 0:	// �|���J�n��
						{
							if ((DateTime)uRow.Cells[RateBlanketResult.RATESTARTDATE].Value == this.TargetData_tDateEdit.GetDateTime())
							{
								uRow.Cells[RateBlanketResult.RATESTARTDATE].Value = this.ReplaceData_tDateEdit.GetDateTime();
								cnt++;
							}
							break;
						}
					//--------
					// TNedit
					//--------
					case 1:	// ���i
						{
							if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == this.TargetData_tNedit.GetValue())
							{
								// �|���y�ђ[�������P�ʂ����ݒ莞�̂ݐݒ�
								if ((RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == 0)
									&& (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == 0))
								{
									uRow.Cells[RateBlanketResult.PRICEFL].Value = this.ReplaceData_tNedit.GetValue();
									cnt++;
								}
							}
							break;
						}
					case 4:	// �|��
						{
							if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == this.TargetData_tNedit.GetValue())
							{
								// ���i���ݒ莞�̂ݐݒ�
								if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == 0)
								{
									uRow.Cells[RateBlanketResult.RATEVAL].Value = this.ReplaceData_tNedit.GetValue();
									cnt++;
								}
							}
							break;
						}
					case 5:	// �[�������P��
						{
							if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == this.TargetData_tNedit.GetValue())
							{
								// ���i���ݒ莞�̂ݐݒ�
								if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == 0)
								{
									uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value = this.ReplaceData_tNedit.GetValue();
									cnt++;
								}
							}
							break;
						}
					//--------------
					// tComboEditor
					//--------------
					case 2:	// ���i�敪
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.PRICEDIV].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								uRow.Cells[RateBlanketResult.PRICEDIV].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
							}
							break;
						}
					case 3:	// �P���Z�o�敪
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								// ���[�N�փR�s�[
								int wkValue = RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value);
								
								uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
								
								// �R���{�{�b�N�X���L�����m�F����i�e�L�X�g�������̏ꍇ�A���͂����f�[�^��\������j
								if (uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Text == RateBlanketAcs.NullChgStr(this.ReplaceData_tComboEditor.Value))
								{
									// �����Ȃ̂Ō��ɖ߂�
									uRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value = wkValue;
									cnt--;
								}
							}
							break;
						}
					case 6:	// �[�������敪
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.UNPRCFRACPROCDIV].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								uRow.Cells[RateBlanketResult.UNPRCFRACPROCDIV].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
							}
							break;
						}
					case 7:	// �����敪
						{
							if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.BARGAINCD].Value) == RateBlanketAcs.NullChgInt(this.TargetData_tComboEditor.Value))
							{
								uRow.Cells[RateBlanketResult.BARGAINCD].Value = RateBlanketAcs.NullChgInt(this.ReplaceData_tComboEditor.Value);
								cnt++;
							}
							break;
						}
				}
			}
		}

		/// <summary>
		/// Target_tComboEditor_SelectionChangeCommitted �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �u���Ώۂ��ω������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void Target_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.Target_tComboEditor != null)
			{
				TargetVisibleChange((Int32)this.Target_tComboEditor.Value);
			}
		}

		/// <summary>
		/// �u���{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Replace_uButton_Click(object sender, EventArgs e)
		{
			int cnt = 0;
			
			// ���b�Z�[�W�Ŏ���̊m�F
			string strMsg = "�S�Ēu�����܂��B��낵���ł����H";

			// Ok�Ȃ珉�񒊏o���A�ۑ����̃f�[�^�ɖ߂�
			DialogResult dlgRes = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_INFO,        //�G���[���x��
				"DCKHN09180UC",                     //UNIT�@ID
				this.Text,                          //�v���O��������
				"�u��",		                        //�v���Z�XID
				"",                                 //�I�y���[�V����
				strMsg,                             //���b�Z�[�W
				0,									//�X�e�[�^�X
				null,								//�I�u�W�F�N�g
				MessageBoxButtons.YesNo,            //�_�C�A���O�{�^���w��
				MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
				);
			
			if(dlgRes == DialogResult.Yes)
			{
				if (this.Target_tComboEditor != null)
				{
					TargetReplace((int)this.Target_tComboEditor.Value, out cnt);

					// �u���������b�Z�[�W
					TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
						"DCKHN09180UC",							// �A�Z���u��ID
						cnt + "���u�����܂����B",				// �\�����郁�b�Z�[�W
						0,										// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
				}
			}
		}

		/// <summary>
		/// ����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void Cancel_uButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void DCKHN09180UC_Load(object sender, EventArgs e)
		{
			// �A�C�R����\������
			ImageList imageList16 = IconResourceManagement.ImageList16;
			ImageList imageList24 = IconResourceManagement.ImageList24;

			// ����{�^���A�C�R��
			this.Replace_uButton.ImageList = imageList24;
			this.Replace_uButton.Appearance.Image = Size24_Index.SAVE;
			
			this.Cancel_uButton.ImageList = imageList24;
			this.Cancel_uButton.Appearance.Image = Size24_Index.CLOSE;
			
			// ��ʏ���������
			ScreenInitialSetting();

			// ��ʃN���A
			ScreenClear();
			
			this.timer_InitialSetFocus.Enabled = true;
		}

		/// <summary>
		/// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;
			this.Target_tComboEditor.Focus();
		}
	}
}