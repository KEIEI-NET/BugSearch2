using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d��DX�ʒm�|�b�v�A�b�v�t�H�[��
	/// </summary>
	/// <remarks>
	/// <br>Note        : �d��DX�ʒm�|�b�v�A�b�v�t�H�[���ł��B</br>
	/// <br>Programmer  : 32281 �����@�Ȍ�</br>
	/// <br>Date        : 2023.12.20</br>
	/// </remarks>
	public partial class SFMIT01297UA : Form
	{
		#region Const Member
		/// <summary> �t�H�[���̕s�����x(�ő�l) </summary>
		private const double CT_OPACITY_MAX = 0.99;
		/// <summary> �t�H�[���̕s�����x(�ŏ��l) </summary>
		private const double CT_OPACITY_MIN = 0.0;
		/// <summary> �t�H�[���̕s�����x(�����l) </summary>
		private const double CT_OPACITY_DECREASE = 0.05;
		#endregion

		#region Private Member
		/// <summary> �d��DX�ʒm�ݒ�A�N�Z�X�N���X </summary>
		private EBookLinkSettingsNtcSetAcs _eBookLinkSettingsNtcSetAcs;
		/// <summary> �d��DX�ʒm�ݒ��� </summary>
		private EBookLinkSettingsNtcSet _settingInfo;
		/// <summary> �}�E�X�̃N���b�N�ʒu </summary>
		private Point _mousePoint;
		/// <summary> ��ʋN���t���O </summary>
		private bool _formShown = false;
		/// <summary>�A�C�R���p�C���[�W���X�g</summary>
		private ImageList _imageList16;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFMIT01297UA()
		{
			InitializeComponent();

			// ��ʂ͉E���ɔz�u�i�f�t�H���g�j
			int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
			int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;

			this.Left = screenWidth - this.Width;
			this.Top = screenheigth - this.Height;

			this._imageList16 = IconResourceManagement.ImageList16;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �ݒ���擾����
		/// </summary>
		private int GetSettingInfo()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			if (this._eBookLinkSettingsNtcSetAcs == null)
				this._eBookLinkSettingsNtcSetAcs = new EBookLinkSettingsNtcSetAcs();

			// �d��DX�ʒm����Ǎ�
			status = this._eBookLinkSettingsNtcSetAcs.ReadSettingInfo(out this._settingInfo);
			return status;
		}

		/// <summary>
		/// �ݒ�t�@�C���̃`�F�b�N
		/// </summary>
		/// <returns>true:�`�F�b�NOK, false:�`�F�b�NNG</returns>
		private bool CheckSettingsFile()
		{
			//--------------------------------------------------
			// �|�b�v�A�b�v�\���敪���u�\�����Ȃ��v�ꍇ
			//--------------------------------------------------
			if (this._settingInfo.PopupDspDiv == EBookLinkSettingsNtcHelper.CT_POPUPDSPDIV_NONDSP)
			{
				// �㑱�������Ȃ�
				return false;
			}

			// �J�n�����`�F�b�N
			DateTime notificationDateSt = TDateTime.LongDateToDateTime(EBookLinkSettingsNtcHelper.CT_FORMAT_DATE, this._settingInfo.NotificationDateSt);
			DateTime today = DateTime.Today;
			if (today.CompareTo(notificationDateSt) < 0)
			{
				// �㑱�������Ȃ�
				return false;
			}

			// ���O�p�I�v�V�������`�F�b�N
			foreach (ExclusionsOption exop in this._settingInfo.ExclusionsOptions)
			{
				PurchaseStatus purchaseStatus = PurchaseStatus.Uncontract;
				switch (exop.Authority)
				{
					case "USB":
						purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(exop.Code);
						break;
					case "Enterprise":
						purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(exop.Code);
						break;
				}
				if (purchaseStatus > PurchaseStatus.Uncontract)
				{
					// �㑱�������Ȃ�
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// �d��DX�ʒm����
		/// </summary>
		private void NoticeEBookLinkSettings()
		{
			//--------------------------------------------------
			// �ݒ�t�@�C���̃`�F�b�N
			//--------------------------------------------------
			if (!CheckSettingsFile())
			{
				// �d��DX�ʒm���I��
				this.Close();
				return;
			}
			this.timerBeforeShow.Enabled = true;
		}

		/// <summary>
		/// �|�b�v�A�b�v��ʔ�\������
		/// </summary>
		private void HidePopup()
		{
			// �|�b�v�A�b�v��ʔ�\���^�C�}���N��
			this.timerOpacity.Enabled = true;
		}

		#endregion

		#region Control Event
		/// <summary>
		/// FormShown�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void SFMIT01297UA_Shown(object sender, EventArgs e)
		{
			// ��ʂ��\���ɂ���
			this.Visible = false;

			// �A�C�R���ݒ�
			this.notifyIcon.Icon = Properties.Resources.SFICON01;

			this._formShown = true;

			// �ݒ�����擾
			int status = GetSettingInfo();

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.Label_Title.Text = this._settingInfo.PopupTitle;
				this.Label_Contents.Text = this._settingInfo.PopupMsg.Replace("\\n", "\r\n");
				// �d��DX�ʒm����
				this.NoticeEBookLinkSettings();
			}
		}

		/// <summary>
		/// �y�C���g�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void Panel_Main_Paint(object sender, PaintEventArgs e)
		{
			if (this._formShown)
			{
				Color colorTop = Color.FromArgb(222, 247, 255);
				Color colorBottom = Color.FromArgb(162, 235, 255);

				// �������ɑ΂��ẴO���f�[�V����
				LinearGradientBrush p = new LinearGradientBrush(ClientRectangle, colorTop, colorBottom, LinearGradientMode.Vertical);
				e.Graphics.FillRectangle(p, ClientRectangle);
			}
		}

		/// <summary>
		/// �w�b�_�p�l��MouseDown�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void Header_MouseDown(object sender, MouseEventArgs e)
		{
			// ��ʂ��\���ɂ��Ă���
			if (this.timerOpacity.Enabled == true)
			{
				return;
			}

			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				//�ʒu���L������
				this._mousePoint = new Point(e.X, e.Y);
			}
		}

		/// <summary>
		/// �w�b�_�p�l��MouseMove�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void Header_MouseMove(object sender, MouseEventArgs e)
		{
			// ��ʂ��\���ɂ��Ă���
			if (this.timerOpacity.Enabled == true)
			{
				return;
			}

			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				int pointX = this.Location.X + e.X - this._mousePoint.X;
				int pointY = this.Location.Y + e.Y - this._mousePoint.Y;
				this.Location = new Point(pointX, pointY);
			}
		}

		/// <summary>
		/// �u�~�v�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void Label_Close_Click(object sender, EventArgs e)
		{
			this.Label_Close.Enabled = false;
			// �|�b�v�A�b�v��ʂ��\���ɂ���
			HidePopup();

			this._settingInfo.PopupDspDiv = this.Notification_CheckBox.Checked ? (short)0 : (short)1;
			this._eBookLinkSettingsNtcSetAcs.WriteSettingInfo(ref this._settingInfo);
		}

		/// <summary>
		/// timerBeforeShow_Tick�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void timerBeforeShow_Tick(object sender, EventArgs e)
		{
			this.timerBeforeShow.Enabled = false;

			// �d��DX�ʒm��ʂ�\������
			this.Visible = true;
			this.Opacity = CT_OPACITY_MAX;
			this.TopMost = true;
		}

		/// <summary>
		/// timerOpacity_Tick�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void timerOpacity_Tick(object sender, EventArgs e)
		{
			// �|�b�v�A�b�v��������蓧�߂��A��\���ɂ���
			try
			{
				this.Opacity -= CT_OPACITY_DECREASE;
			}
			catch (Exception)
			{
				this.Opacity = CT_OPACITY_MIN;
			}
			finally
			{
				if (this.Opacity <= CT_OPACITY_MIN)
				{
					this.TopMost = false;
					this.Visible = false;
					this.timerOpacity.Enabled = false;
					this.Close();
				}
			}
		}

		/// <summary>
		/// �v�����[�V�����T�C�gURL�����N���N���b�N
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void lblLink_Click(object sender, EventArgs e)
		{
			string url = this._settingInfo.PromotionUrl;
			if (!String.IsNullOrEmpty(LoginInfoAcquisition.EnterpriseCode) && !String.IsNullOrEmpty(this._settingInfo.PromotionParam))
				url += this._settingInfo.PromotionParam + LoginInfoAcquisition.EnterpriseCode;

			// �u���E�U���N�����ݒ肳�ꂽURL�փ����N
			System.Diagnostics.Process.Start(url);
		}

		/// <summary>
		/// �O�����MURL�����N���N���b�N
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		private void lblLink2_Click(object sender, EventArgs e)
		{
			// �u���E�U���N�����ݒ肳�ꂽURL�փ����N
			System.Diagnostics.Process.Start(this._settingInfo.ExternalTransmissionUrl);
		}
		#endregion
	}
}