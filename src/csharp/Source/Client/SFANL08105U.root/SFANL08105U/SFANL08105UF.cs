using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Collections.Generic;

using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �V�K�쐬�_�C�A���O���
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�̐V�K�쐬�ɕK�v�ȏ�����͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UF : Form
	{
		#region PrivateMember
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        // ���[ID
        private string _prtFormId;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		// �o�͖���
		private string _displayName;
		// �p�����
		private PaperKind _paperKind;
		// �I���󎚍��ڃO���[�v
		private PrtItemGrpWork _selectedPrtItemGrp;
		// �󎚍��ڃO���[�vLIST
		private List<PrtItemGrpWork> _prtItemGrpList;
		// �p������ (Portrait:�c,Landscape:��)
		private PageOrientation _landscape = PageOrientation.Landscape;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08105UF()
		{
			InitializeComponent();

			this.ubDecide.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			this.ubCancel.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];

			_selectedPrtItemGrp = null;
		}
		#endregion

		#region Property
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        /// <summary>���[ID</summary>
        public string PrtFormId
        {
            get { return _prtFormId; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		/// <summary>�o�͖���</summary>
		public string DisplayName
		{
			get { return _displayName; }
		}

		/// <summary>�p�����</summary>
		public PaperKind PaperKind
		{
			get { return _paperKind; }
		}

		/// <summary>�I���󎚍��ڃO���[�v</summary>
		public PrtItemGrpWork SelectedPrtItemGrp
		{
			get { return _selectedPrtItemGrp; }
		}

		/// <summary>�p������ (Portrait:�c,Landscape:��)</summary>
		public PageOrientation Landscape
		{
			get { return _landscape; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// �V�K�쐬�_�C�A���O�\������
		/// </summary>
		/// <param name="prtItemGrpList">�󎚍��ڃO���[�vLIST</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�̐V�K�쐬�ɕK�v�ȏ�����͂����ʂ�\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public DialogResult ShowNewReportInfoDialog(List<PrtItemGrpWork> prtItemGrpList)
		{
			this.DialogResult = DialogResult.Cancel;

			_prtItemGrpList = prtItemGrpList;

			return this.ShowDialog();
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// ���̓`�F�b�N
		/// </summary>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="control">�R���g���[��</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʂ̓��̓`�F�b�N���s�Ȃ��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private bool InputCheck(out string message, out Control control)
		{
			message = string.Empty;
			control = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // ���[ID
            if ( this.tedPrtFormId.Text.Equals( string.Empty ) )
            {
                message = this.ulPrtFormId.Text + "�����͂���Ă��܂���B";
                control = this.tedPrtFormId;
                return false;
            }
            if ( this.tedPrtFormId.Text.IndexOf( '\\' ) != -1 || this.tedPrtFormId.Text.IndexOf( '/' ) != -1 )
            {
                message = this.ulPrtFormId.Text + "�ɉ��L�����͎g�p�o���܂���B" + Environment.NewLine + Environment.NewLine + "\\ /";
                control = this.tedPrtFormId;
                return false;
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

			// ���[����
			if (this.tedDisplayName.Text.Equals(string.Empty))
			{
				message = this.ulDisplayName.Text + "�����͂���Ă��܂���B";
				control = this.tedDisplayName;
				return false;
			}
			if (this.tedDisplayName.Text.IndexOf('\\') != -1 || this.tedDisplayName.Text.IndexOf('/') != -1)
			{
				message = this.ulDisplayName.Text + "�ɉ��L�����͎g�p�o���܂���B" + Environment.NewLine + Environment.NewLine + "\\ /";
				control = this.tedDisplayName;
				return false;
			}

			// �󎚍��ڃO���[�v
			if (this.cmbFreePrtPprItemGrpNm.Value == null)
			{
				message = this.ulFreePrtPprItemGrpNm.Text + "���I������Ă��܂���B";
				control = this.cmbFreePrtPprItemGrpNm;
				return false;
			}

			return true;
		}

		/// <summary>
		/// ���ڃO���[�v�X�V����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���ڃO���[�v�R���{�{�b�N�X�̍X�V���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void UpdateFreePrtPprItemGrp()
		{
			// ���[�p���敪(1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���)
			int printPaperUseDivcd = (int)this.cmbPrintPaperUseDivcd.Value;

			// ���ڃO���[�v
			this.cmbFreePrtPprItemGrpNm.Items.Clear();
			foreach (PrtItemGrpWork prtItemGrp in _prtItemGrpList)
			{
				if (printPaperUseDivcd == prtItemGrp.PrintPaperUseDivcd)
					this.cmbFreePrtPprItemGrpNm.Items.Add(prtItemGrp.FreePrtPprItemGrpCd, prtItemGrp.FreePrtPprItemGrpNm);
			}

			if (this.cmbFreePrtPprItemGrpNm.Items.Count > 0)
				this.cmbFreePrtPprItemGrpNm.SelectedIndex = 0;

			// �`�[,DM�͂����̎��͗p���������c�ɂ���
			if (printPaperUseDivcd == 2 || printPaperUseDivcd == 4)
				this.uosOrientation.Value = PageOrientation.Portrait;
			else
				this.uosOrientation.Value = PageOrientation.Landscape;
		}
		#endregion

		#region Event
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UF_Load(object sender, EventArgs e)
		{
			// ������ �����ݒ� ������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // ���[ID
            this.tedPrtFormId.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			// ���[����
			this.tedDisplayName.Clear();
			// �p�����
			this.cmbPaperName.Items.Clear();
			this.cmbPaperName.Items.Add(PaperKind.A3, 				"�`�R");
			this.cmbPaperName.Items.Add(PaperKind.A4, 				"�`�S");
			this.cmbPaperName.Items.Add(PaperKind.A5, 				"�`�T");
			this.cmbPaperName.Items.Add(PaperKind.B4, 				"�a�S");
			this.cmbPaperName.Items.Add(PaperKind.B5, 				"�a�T");
			this.cmbPaperName.Items.Add(PaperKind.JapanesePostcard,	"�͂���");
			//this.cmbPaperName.Items.Add(PaperKind.Custom,			"�J�X�^��");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            this.cmbPaperName.Items.Add( PaperKind.Custom, "�J�X�^��" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
			this.cmbPaperName.Value = PaperKind.A4;
			// ���[�p���敪
			this.cmbPrintPaperUseDivcd.Items.Clear();
			this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.Report,		"���[");
			this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.Slip,			"�`�[");
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            //this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.DMReport,		"�c�l�ꗗ�\");
            //this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.DMPostCard,	"�c�l�͂���");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            this.cmbPrintPaperUseDivcd.Items.Add( (int)SFANL08105UA.PrintPaperUseDivcdKind.DmdBill, "������" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
			this.cmbPrintPaperUseDivcd.SelectedIndex = 0;
			UpdateFreePrtPprItemGrp();
			// �p������
			this.uosOrientation.Items.Clear();
			this.uosOrientation.Items.Add(PageOrientation.Landscape,	"��");
			this.uosOrientation.Items.Add(PageOrientation.Portrait,		"�c");
			this.uosOrientation.CheckedIndex = 0;
		}

		/// <summary>
		/// �V�K�쐬�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �V�K�쐬�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubDecide_Click(object sender, EventArgs e)
		{
			string message;
			Control control;

			if (InputCheck(out message, out control))
			{
				_selectedPrtItemGrp = _prtItemGrpList.Find(
					delegate(PrtItemGrpWork prtItemGrp)
					{
						if (prtItemGrp.FreePrtPprItemGrpCd.Equals(this.cmbFreePrtPprItemGrpNm.Value))
							return true;
						else
							return false;
					}
				);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                _prtFormId = this.tedPrtFormId.Text;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				_displayName	= this.tedDisplayName.Text;
				_paperKind		= (PaperKind)this.cmbPaperName.Value;
				_landscape		= (PageOrientation)this.uosOrientation.Value;

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					SFANL08105UH.ctASSEMBLY_ID,			// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��
				control.Focus();
			}
		}

		/// <summary>
		/// �L�����Z���{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �L�����Z���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// SelectionChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbPrintPaperUseDivcd_SelectionChanged(object sender, EventArgs e)
		{
			UpdateFreePrtPprItemGrp();
		}

		/// <summary>
		/// �t�H�[���L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[����ŃL�[�������ꂽ���ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UF_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				ubCancel_Click(sender, e);
		}
		#endregion
	}
}