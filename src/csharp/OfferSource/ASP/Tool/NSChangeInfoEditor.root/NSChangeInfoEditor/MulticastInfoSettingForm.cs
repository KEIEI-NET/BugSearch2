using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	public partial class MulticastInfoSettingForm : Form
	{
		#region << Constructor >>

		/// <summary>
		/// 
		/// </summary>
		public MulticastInfoSettingForm()
		{
			InitializeComponent();
		}

		#endregion

		#region << Private Members >>

		/// <summary>.NS�z�M�ē��ݒ��ʐݒ�N���X</summary>
		private MulticastInfoEditorSetting _setting = null;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// .NS�z�M�ē��ݒ��ʐݒ�N���X
		/// </summary>
		public MulticastInfoEditorSetting Setting
		{
			get {
				return this._setting;
			}
			set {
				this._setting = value;
			}
		}

		#endregion

		#region << Private Methods >>

		/// <summary>
		/// ��ʂ��N���A���܂��B
		/// </summary>
		private void ScreenClear()
		{
			this.AnothersheetPath_textBox.Clear();
		}

		/// <summary>
		/// .NS�z�M�ē��ݒ��ʐݒ�N���X��ʓW�J����
		/// </summary>
		/// <param name="multicastInfoEditorSetting">.NS�z�M�ē��ݒ��ʐݒ�N���X</param>
		private void SetMulticastInfoEditorSettingToScreen( MulticastInfoEditorSetting multicastInfoEditorSetting )
		{
			this.AnothersheetPath_textBox.Text = multicastInfoEditorSetting.AnothersheetFileDirPath;
		}

		/// <summary>
		/// .NS�z�M�ē��ݒ��ʐݒ�N���X��ʎ擾����
		/// </summary>
		/// <param name="multicastInfoEditorSetting">.NS�z�M�ē��ݒ��ʐݒ�N���X</param>
		private void SetMulticastInfoEditorSettingFromScreen( ref MulticastInfoEditorSetting multicastInfoEditorSetting )
		{
			if( multicastInfoEditorSetting == null ) {
				multicastInfoEditorSetting = new MulticastInfoEditorSetting();
			}
			multicastInfoEditorSetting.AnothersheetFileDirPath = this.AnothersheetPath_textBox.Text;
		}

		/// <summary>
		/// ��ʂ̓��̓`�F�b�N���s���܂��B
		/// </summary>
		/// <param name="control">�ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>���������͂���Ă���ꍇ�� <c>true</c> ��Ԃ��܂��B�����łȂ��ꍇ�́A<c>false</c> ��Ԃ��܂��B</returns>
		private bool ScreenInputCheck( ref Control control, ref string message )
		{
			bool result = true;

			if( this.AnothersheetPath_textBox.Text.Trim() == String.Empty ) {
				message = "�ʎ��t�@�C���z�u�t�H���_����͂��Ă��������B";
				control = this.AnothersheetPath_textBox;
				result  = false;
			}
			else if( ! Directory.Exists( this.AnothersheetPath_textBox.Text ) ) {
				message = "���͂���Ă���ʎ��t�@�C���z�u�t�H���_�͑��݂��܂���B";
				control = this.AnothersheetPath_textBox;
				result = false;
			}

			return result;
		}

		#endregion

		#region << Control Events >>

		/// <summary>
		/// Form.Load �C�x���g (MulticastInfoSettingForm)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void MulticastInfoSettingForm_Load( object sender, EventArgs e )
		{
		}

		/// <summary>
		/// Form.Shown �C�x���g (MulticastInfoSettingForm)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void MulticastInfoSettingForm_Shown( object sender, EventArgs e )
		{
			// ��ʂ��N���A
			this.ScreenClear();
			if( this._setting != null ) {
				this.SetMulticastInfoEditorSettingToScreen( this._setting );
			}

			this.AnothersheetPath_textBox.Focus();
			this.ActiveControl = this.AnothersheetPath_textBox;
		}

		/// <summary>
		/// Control.Click �C�x���g (OK_button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void OK_button_Click( object sender, EventArgs e )
		{
			Control control = null;
			string  message = "";;
			if( ! this.ScreenInputCheck( ref control, ref message ) ) {
				MessageBox.Show( this, message, "���̓`�F�b�N", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );

				if( control != null ) {
					control.Focus();
					this.ActiveControl = control;
				}

				return;
			}

			// ��ʃf�[�^�擾
			MulticastInfoEditorSetting setting = this._setting.Clone();
			this.SetMulticastInfoEditorSettingFromScreen( ref setting );
			this._setting = setting;

			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Control.Click �C�x���g (Cancel_button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void Cancel_button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Control.Click �C�x���g (DirRef_button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void DirRef_button_Click( object sender, EventArgs e )
		{
			this.DirRef_folderBrowserDialog.SelectedPath = this.AnothersheetPath_textBox.Text;

			if( this.DirRef_folderBrowserDialog.ShowDialog( this ) == DialogResult.OK ) {
				this.AnothersheetPath_textBox.Text = this.DirRef_folderBrowserDialog.SelectedPath;
			}
		}

		#endregion
	}
}