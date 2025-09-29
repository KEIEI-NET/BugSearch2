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

		/// <summary>.NS配信案内設定画面設定クラス</summary>
		private MulticastInfoEditorSetting _setting = null;

		#endregion

		#region << Public Properties >>

		/// <summary>
		/// .NS配信案内設定画面設定クラス
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
		/// 画面をクリアします。
		/// </summary>
		private void ScreenClear()
		{
			this.AnothersheetPath_textBox.Clear();
		}

		/// <summary>
		/// .NS配信案内設定画面設定クラス画面展開処理
		/// </summary>
		/// <param name="multicastInfoEditorSetting">.NS配信案内設定画面設定クラス</param>
		private void SetMulticastInfoEditorSettingToScreen( MulticastInfoEditorSetting multicastInfoEditorSetting )
		{
			this.AnothersheetPath_textBox.Text = multicastInfoEditorSetting.AnothersheetFileDirPath;
		}

		/// <summary>
		/// .NS配信案内設定画面設定クラス画面取得処理
		/// </summary>
		/// <param name="multicastInfoEditorSetting">.NS配信案内設定画面設定クラス</param>
		private void SetMulticastInfoEditorSettingFromScreen( ref MulticastInfoEditorSetting multicastInfoEditorSetting )
		{
			if( multicastInfoEditorSetting == null ) {
				multicastInfoEditorSetting = new MulticastInfoEditorSetting();
			}
			multicastInfoEditorSetting.AnothersheetFileDirPath = this.AnothersheetPath_textBox.Text;
		}

		/// <summary>
		/// 画面の入力チェックを行います。
		/// </summary>
		/// <param name="control">対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>正しく入力されている場合は <c>true</c> を返します。そうでない場合は、<c>false</c> を返します。</returns>
		private bool ScreenInputCheck( ref Control control, ref string message )
		{
			bool result = true;

			if( this.AnothersheetPath_textBox.Text.Trim() == String.Empty ) {
				message = "別紙ファイル配置フォルダを入力してください。";
				control = this.AnothersheetPath_textBox;
				result  = false;
			}
			else if( ! Directory.Exists( this.AnothersheetPath_textBox.Text ) ) {
				message = "入力されている別紙ファイル配置フォルダは存在しません。";
				control = this.AnothersheetPath_textBox;
				result = false;
			}

			return result;
		}

		#endregion

		#region << Control Events >>

		/// <summary>
		/// Form.Load イベント (MulticastInfoSettingForm)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void MulticastInfoSettingForm_Load( object sender, EventArgs e )
		{
		}

		/// <summary>
		/// Form.Shown イベント (MulticastInfoSettingForm)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void MulticastInfoSettingForm_Shown( object sender, EventArgs e )
		{
			// 画面をクリア
			this.ScreenClear();
			if( this._setting != null ) {
				this.SetMulticastInfoEditorSettingToScreen( this._setting );
			}

			this.AnothersheetPath_textBox.Focus();
			this.ActiveControl = this.AnothersheetPath_textBox;
		}

		/// <summary>
		/// Control.Click イベント (OK_button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void OK_button_Click( object sender, EventArgs e )
		{
			Control control = null;
			string  message = "";;
			if( ! this.ScreenInputCheck( ref control, ref message ) ) {
				MessageBox.Show( this, message, "入力チェック", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1 );

				if( control != null ) {
					control.Focus();
					this.ActiveControl = control;
				}

				return;
			}

			// 画面データ取得
			MulticastInfoEditorSetting setting = this._setting.Clone();
			this.SetMulticastInfoEditorSettingFromScreen( ref setting );
			this._setting = setting;

			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Control.Click イベント (Cancel_button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void Cancel_button_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Control.Click イベント (DirRef_button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
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