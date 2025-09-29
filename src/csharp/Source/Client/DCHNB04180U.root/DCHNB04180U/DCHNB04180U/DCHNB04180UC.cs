using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
//using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ユーザー設定画面クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ユーザー設定情報を入力します。</br>
    /// <br>Programmer : 30462 行澤　仁美</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br>Update Note: 2010/07/20 徐後継</br>
    /// <br>            ・テキスト出力対応</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            ・テキスト出力対応13482</br>
	/// </remarks>
	public partial class DCHNB04180UC : Form
	{
		#region Constructor
		/// <summary>
		/// ユーザー設定画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : ユーザー設定画面クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 徐後継</br>
        /// <br>            ・テキスト出力対応</br>
		/// </remarks>
		public DCHNB04180UC()
		{
			InitializeComponent();

			this._imageList16									= IconResourceManagement.ImageList16;

			this._analysisChartSettingAcs						= new AnalysisChartSettingAcs();

			// 詳細表示初期値
			this.DetailDisplayInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.DetailDisplayInitialValue;
			// ポイントラベル表示初期値
			this.PointLabelInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.PointLabelInitialValue;
			// ポイントラベルフォントサイズ初期値
			this.PointLabelSize_tComboEditor.Value				= this._analysisChartSettingAcs.PointLabelSizeInitialValue;
			// ラベル角度初期値
			this.LabelVerticalInitialValue_ultraOptionSet.Value	= this._analysisChartSettingAcs.LabelVerticalInitialValue;
			// ラベル最大桁数初期値
			if (this._analysisChartSettingAcs.LabelMaxLengthInitialValue != -1)
			{
				this.LabelMaxLengthInitialValue_tNedit.SetInt(this._analysisChartSettingAcs.LabelMaxLengthInitialValue);
			}
			else
			{
				this.LabelMaxLengthInitialValue_tNedit.Clear();
			}
			// ラベルフォントサイズ初期値
			this.LabelSize_tComboEditor.Value					= this._analysisChartSettingAcs.LabelSizeInitialValue;
			// ３Ｄ／２Ｄ表示初期値
			this.View3D2DInitialValue_ultraOptionSet.Value		= this._analysisChartSettingAcs.View3D2DInitialValue;

            // --- ADD 2010/07/20 -------------------------------->>>>>
            this.tEdit_SectionFileName.Text = this._analysisChartSettingAcs.SectionFileNameValue;
            this.tEdit_CustomerFileName.Text = this._analysisChartSettingAcs.CustomerFileNameValue;
            this.tEdit_SalesEmployeeFileName.Text = this._analysisChartSettingAcs.SalesEmployeeFileNameValue;
            this.tEdit_FrontEmployeeFileName.Text = this._analysisChartSettingAcs.FrontEmployeeFileNameValue;
            this.tEdit_SalesInputFileName.Text = this._analysisChartSettingAcs.SalesInputFileNameValue;
            this.tEdit_SalesAreaFileName.Text = this._analysisChartSettingAcs.SalesAreaFileNameValue;
            this.tEdit_BusinessTypeFileName.Text = this._analysisChartSettingAcs.BusinessTypeFileNameValue;
            // --- ADD 2010/07/20 --------------------------------<<<<<
		}
		#endregion

        // --- ADD 2010/07/20 -------------------------------->>>>>
        public AnalysisChartSettingAcs AnalysisChartSettingAcs
        {
            get { return this._analysisChartSettingAcs; }
            set { this._analysisChartSettingAcs = value; }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

		#region Private Members
		private ImageList _imageList16 = null;
		private AnalysisChartSettingAcs _analysisChartSettingAcs = null;
		#endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 徐後継</br>
        /// <br>            ・テキスト出力対応</br>
		/// </remarks>
		private void SFANL06500UE_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;
			this.Ok_ultraButton.Appearance.Image						= Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image					= Size16_Index.BEFORE;

            // --- ADD 2010/07/20 -------------------------------->>>>>
            this.ultraButton_SectionFileSelect.ImageList = this._imageList16;
            this.ultraButton_CustomerFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesEmployeeFileSelect.ImageList = this._imageList16;
            this.ultraButton_FrontEmployeeFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesInputFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesAreaFileSelect.ImageList = this._imageList16;
            this.ultraButton_BusinessTypeFileSelect.ImageList = this._imageList16;
            this.ultraButton_SectionFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_CustomerFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesEmployeeFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_FrontEmployeeFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesInputFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesAreaFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_BusinessTypeFileSelect.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2010/07/20 --------------------------------<<<<<

			// 詳細表示初期値
			this.DetailDisplayInitialValue_ultraOptionSet.Value			= this._analysisChartSettingAcs.DetailDisplayInitialValue;
			this.DetailDisplayInitialValue_ultraOptionSet.FocusedIndex	= this.DetailDisplayInitialValue_ultraOptionSet.CheckedIndex;
			// ポイントラベル表示初期値
			this.PointLabelInitialValue_ultraOptionSet.Value			= this._analysisChartSettingAcs.PointLabelInitialValue;
			this.PointLabelInitialValue_ultraOptionSet.FocusedIndex		= this.PointLabelInitialValue_ultraOptionSet.CheckedIndex;
			// ポイントラベルフォントサイズ初期値
			this.PointLabelSize_tComboEditor.Value						= this._analysisChartSettingAcs.PointLabelSizeInitialValue;
			// ラベル角度初期値
			this.LabelVerticalInitialValue_ultraOptionSet.Value			= this._analysisChartSettingAcs.LabelVerticalInitialValue;
			this.LabelVerticalInitialValue_ultraOptionSet.FocusedIndex	= this.LabelVerticalInitialValue_ultraOptionSet.CheckedIndex;
			// ラベル最大桁数初期値
			if (this._analysisChartSettingAcs.LabelMaxLengthInitialValue != -1)
			{
				this.LabelMaxLengthInitialValue_tNedit.SetInt(this._analysisChartSettingAcs.LabelMaxLengthInitialValue);
			}
			else
			{
				this.LabelMaxLengthInitialValue_tNedit.Clear();
			}
			// ラベルフォントサイズ初期値
			this.LabelSize_tComboEditor.Value							= this._analysisChartSettingAcs.LabelSizeInitialValue;
			// ３Ｄ／２Ｄ表示初期値
			this.View3D2DInitialValue_ultraOptionSet.Value				= this._analysisChartSettingAcs.View3D2DInitialValue;
			this.View3D2DInitialValue_ultraOptionSet.FocusedIndex		= this.View3D2DInitialValue_ultraOptionSet.CheckedIndex;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this.tEdit_SectionFileName.Text = this._analysisChartSettingAcs.SectionFileNameValue;
            this.tEdit_CustomerFileName.Text = this._analysisChartSettingAcs.CustomerFileNameValue;
            this.tEdit_SalesEmployeeFileName.Text = this._analysisChartSettingAcs.SalesEmployeeFileNameValue;
            this.tEdit_FrontEmployeeFileName.Text = this._analysisChartSettingAcs.FrontEmployeeFileNameValue;
            this.tEdit_SalesInputFileName.Text = this._analysisChartSettingAcs.SalesInputFileNameValue;
            this.tEdit_SalesAreaFileName.Text = this._analysisChartSettingAcs.SalesAreaFileNameValue;
            this.tEdit_BusinessTypeFileName.Text = this._analysisChartSettingAcs.BusinessTypeFileNameValue;
            // --- ADD 2010/07/20 --------------------------------<<<<<
            
		}

        /// <summary>
        /// ファイル名ガイドボタンClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ファイル名ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void ultraButton_FileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
                case "ultraButton_SectionFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SectionFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SectionFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SectionFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_CustomerFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_CustomerFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_CustomerFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_CustomerFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_SalesEmployeeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesEmployeeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesEmployeeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesEmployeeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_FrontEmployeeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_FrontEmployeeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_FrontEmployeeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_FrontEmployeeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_SalesInputFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesInputFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesInputFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesInputFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_SalesAreaFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesAreaFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesAreaFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesAreaFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
                case "ultraButton_BusinessTypeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_BusinessTypeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_BusinessTypeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_BusinessTypeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }
            
        }

		/// <summary>
		/// UltraButton.Click イベント（Ok_ultraButton）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : コントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 徐後継</br>
        /// <br>            ・テキスト出力対応</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
			// 詳細表示初期値
			this._analysisChartSettingAcs.DetailDisplayInitialValue			= (bool)this.DetailDisplayInitialValue_ultraOptionSet.Value;
			// ポイントラベル表示初期値
			this._analysisChartSettingAcs.PointLabelInitialValue			= (bool)this.PointLabelInitialValue_ultraOptionSet.Value;
			// ポイントラベルフォントサイズ初期値
			this._analysisChartSettingAcs.PointLabelSizeInitialValue		= (int)this.PointLabelSize_tComboEditor.SelectedItem.DataValue;
			// ラベル角度初期値
			this._analysisChartSettingAcs.LabelVerticalInitialValue			= (bool)this.LabelVerticalInitialValue_ultraOptionSet.Value;
			// ラベル最大桁数初期値
			if (this.LabelMaxLengthInitialValue_tNedit.DataText == string.Empty)
			{
				this._analysisChartSettingAcs.LabelMaxLengthInitialValue	= -1;
			}
			else
			{
				this._analysisChartSettingAcs.LabelMaxLengthInitialValue	= this.LabelMaxLengthInitialValue_tNedit.GetInt();
			}
			// ラベルフォントサイズ初期値
			this._analysisChartSettingAcs.LabelSizeInitialValue				= (int)this.LabelSize_tComboEditor.SelectedItem.DataValue;
			// ３Ｄ／２Ｄ表示初期値
			this._analysisChartSettingAcs.View3D2DInitialValue				= (bool)this.View3D2DInitialValue_ultraOptionSet.Value;

            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._analysisChartSettingAcs.SectionFileNameValue = this.tEdit_SectionFileName.Text;
            this._analysisChartSettingAcs.CustomerFileNameValue = this.tEdit_CustomerFileName.Text;
            this._analysisChartSettingAcs.SalesEmployeeFileNameValue = this.tEdit_SalesEmployeeFileName.Text;
            this._analysisChartSettingAcs.FrontEmployeeFileNameValue = this.tEdit_FrontEmployeeFileName.Text;
            this._analysisChartSettingAcs.SalesInputFileNameValue = this.tEdit_SalesInputFileName.Text;
            this._analysisChartSettingAcs.SalesAreaFileNameValue = this.tEdit_SalesAreaFileName.Text;
            this._analysisChartSettingAcs.BusinessTypeFileNameValue = this.tEdit_BusinessTypeFileName.Text;
            // --- ADD 2010/07/20 --------------------------------<<<<<

			this._analysisChartSettingAcs.Serialize();
		}
		#endregion

        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理します。</br>
        /// <br>Programmer : 徐後継</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "View3D2DInitialValue_ultraOptionSet":
                    {
                        # region [次フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (UserSetup_ultraTabControl.Tabs["TextSetting"].Visible == true)  // ADD 2010/08/23
                                        {
                                            // タブ切り替え
                                            UserSetup_ultraTabControl.ActiveTab = UserSetup_ultraTabControl.Tabs["TextSetting"];
                                            UserSetup_ultraTabControl.SelectedTab = UserSetup_ultraTabControl.ActiveTab;
                                            // 次項目
                                            e.NextCtrl = tEdit_SectionFileName;
                                        }
                                        else
                                        {
                                            // 次項目
                                            e.NextCtrl = Ok_ultraButton; // ADD 2010/08/23
                                        }
                                       
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                case "tEdit_SectionFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SectionFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_CustomerFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_SectionFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (UserSetup_ultraTabControl.Tabs["ChartSetting"].Visible == true)
                                        {
                                            // タブ切り替え
                                            UserSetup_ultraTabControl.ActiveTab = UserSetup_ultraTabControl.Tabs["ChartSetting"];
                                            UserSetup_ultraTabControl.SelectedTab = UserSetup_ultraTabControl.ActiveTab;
                                            // 次項目
                                            e.NextCtrl = View3D2DInitialValue_ultraOptionSet;
                                        }
                                        else
                                        {
                                            // 次項目
                                            e.NextCtrl = e.PrevCtrl;
                                        }

                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_CustomerFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_CustomerFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_SalesEmployeeFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_CustomerFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesEmployeeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_FrontEmployeeFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_SalesEmployeeFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_FrontEmployeeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_FrontEmployeeFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_SalesInputFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_FrontEmployeeFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesInputFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesInputFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_SalesAreaFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_SalesInputFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesAreaFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesAreaFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_BusinessTypeFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_SalesAreaFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_BusinessTypeFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_BusinessTypeFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_BusinessTypeFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "Ok_ultraButton":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        // ボタン押下
                                        Ok_ultraButton_Click(this, new EventArgs());
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "Cancel_ultraButton":
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // ボタン押下
                                    Cancel_ultraButton_Click(this, new EventArgs());
                                }
                                break;
                            case Keys.Tab:
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// UltraButton.Click イベント（Cancel_ultraButton）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがクリックされたときに発生します。</br>
        /// <br>Programmer	: 徐後継</br>
        /// <br>Date		: 2010/07/20</br>
        /// </remarks>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<

        // --- ADD 2010/08/23 -------------------------------->>>>>
        /// <summary>
        /// テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/23</br>
        /// </remarks>
        public void uTabControlSet(bool display)
        {
            //テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。
            UserSetup_ultraTabControl.Tabs["TextSetting"].Visible = display;
        }
        // --- ADD 2010/08/23 --------------------------------<<<<<
	}

	/// <summary>
	/// 分析チャート表示設定クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : シリアル化する分析チャート表示設定クラスです。</br>
    /// <br>Programmer : 30462 行澤　仁美</br>
    /// <br>Date       : 2008.12.01</br>
    /// <br>Update Note: 2010/07/20 徐後継</br>
    /// <br>            ・テキスト出力対応</br>
	/// </remarks>
	[Serializable]
	public class AnalysisChartSetting
	{
		#region Constructor
		/// <summary>
		/// 分析チャート表示設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
		/// </remarks>
		public AnalysisChartSetting()
		{
			this._detailDisplayInitialValue		= DEFAULT_DETAILDISPLAYINITIAL_VALUE;
			this._pointLabelInitialValue		= DEFAULT_POINTLABELINITIAL_VALUE;
			this._pointLabelSizeInitialValue	= DEFAULT_POINTLABELSIZEINITIAL_VALUE;
			this._labelVerticalInitialValue		= DEFAULT_LABELVERTICALINITIAL_VALUE;
			this._labelMaxLengthInitialValue	= DEFAULT_LABELMAXLENGTHINITIAL_VALUE;
			this._labelSizeInitialValue			= DEFAULT_LABELSIZEINITIAL_VALUE;
			this._view3D2DInitialValue			= DEFAULT_VIEW3D2DINITIAL_VALUE;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._sectionFileNameValue = string.Empty;
            this._customerFileNameValue = string.Empty;
            this._salesEmployeeFileNameValue = string.Empty;
            this._frontEmployeeFileNameValue = string.Empty;
            this._salesInputFileNameValue = string.Empty;
            this._salesAreaFileNameValue = string.Empty;
            this._businessTypeFileNameValue = string.Empty;
            // --- ADD 2010/07/20 --------------------------------<<<<<
		}

		/// <summary>
		/// 分析チャート表示設定クラスコンストラクタ
		/// </summary>
		/// <param name="detailDisplayInitialValue">詳細表示初期値</param>
		/// <param name="pointLabelInitialValue">ポイントラベル表示初期値</param>
		/// <param name="pointLabelSizeInitialValue">ポイントラベルフォントサイズ初期値</param>
		/// <param name="labelVerticalInitialValue">ラベル角度初期値</param>
		/// <param name="labelMaxLengthInitialValue">ラベル最大桁数初期値</param>
		/// <param name="labelSizeInitialValue">ラベルフォントサイズ初期値</param>
		/// <param name="view3D2DInitialValue">３Ｄ／２Ｄ表示初期値</param>
        /// <param name="sectionFileNameValue">出力ファイル名（拠点）初期値</param>
        /// <param name="customerFileNameValue">出力ファイル名（得意先）初期値</param>
        /// <param name="salesEmployeeFileNameValue">出力ファイル名（担当者）初期値</param>
        /// <param name="frontEmployeeFileNameValue">出力ファイル名（受注者）初期値</param>
        /// <param name="salesInputFileNameValue">出力ファイル名（発行者）初期値</param>
        /// <param name="salesAreaFileNameValue">出力ファイル名（地区）初期値</param>
        /// <param name="businessTypeFileNameValue">出力ファイル名（業種）初期値</param>
		/// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 徐後継</br>
        /// <br>            ・テキスト出力対応</br>
		/// </remarks>
        //public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue)
        public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue, string sectionFileNameValue, string customerFileNameValue, string salesEmployeeFileNameValue, string frontEmployeeFileNameValue, string salesInputFileNameValue, string salesAreaFileNameValue, string businessTypeFileNameValue)
		{
			this._detailDisplayInitialValue		= detailDisplayInitialValue;
			this._pointLabelInitialValue		= pointLabelInitialValue;
			this._pointLabelSizeInitialValue	= pointLabelSizeInitialValue;
			this._labelVerticalInitialValue		= labelVerticalInitialValue;
			this._labelMaxLengthInitialValue	= labelMaxLengthInitialValue;
			this._labelSizeInitialValue			= labelSizeInitialValue;
			this._view3D2DInitialValue			= view3D2DInitialValue;
            // --- ADD 2010/07/20 -------------------------------->>>>>
            this._sectionFileNameValue = sectionFileNameValue;
            this._customerFileNameValue = customerFileNameValue;
            this._salesEmployeeFileNameValue = salesEmployeeFileNameValue;
            this._frontEmployeeFileNameValue = frontEmployeeFileNameValue;
            this._salesInputFileNameValue = salesInputFileNameValue;
            this._salesAreaFileNameValue = salesAreaFileNameValue;
            this._businessTypeFileNameValue = businessTypeFileNameValue;
            // --- ADD 2010/07/20 --------------------------------<<<<<
        }
        #endregion
        // --- ADD 2010/07/20 -------------------------------->>>>>
        #region Private Member
        /// <summary>出力ファイル名（拠点）初期値</summary>
        private string _sectionFileNameValue;
        /// <summary>出力ファイル名（得意先）初期値</summary>
        private string _customerFileNameValue;
        /// <summary>出力ファイル名（担当者）初期値</summary>
        private string _salesEmployeeFileNameValue;
        /// <summary>出力ファイル名（受注者）初期値</summary>
        private string _frontEmployeeFileNameValue;
        /// <summary>出力ファイル名（発行者）初期値</summary>
        private string _salesInputFileNameValue;
        /// <summary>出力ファイル名（地区）初期値</summary>
        private string _salesAreaFileNameValue;
        /// <summary>出力ファイル名（業種）初期値</summary>
        private string _businessTypeFileNameValue;
        #endregion
        // --- ADD 2010/07/20 --------------------------------<<<<<
		#region Private Member
		/// <summary>詳細表示初期値</summary>
		private bool _detailDisplayInitialValue;
		/// <summary>ポイントラベル表示初期値</summary>
		private bool _pointLabelInitialValue;
		/// <summary>ポイントラベルフォントサイズ初期値</summary>
		private int _pointLabelSizeInitialValue;
		/// <summary>ラベル角度初期値</summary>
		private bool _labelVerticalInitialValue;
		/// <summary>ラベル最大桁数初期値</summary>
		private int _labelMaxLengthInitialValue;
		/// <summary>ラベルフォントサイズ初期値</summary>
		private int _labelSizeInitialValue;
		/// <summary>３Ｄ／２Ｄ表示初期値</summary>
		private bool _view3D2DInitialValue;

		/// <summary>詳細表示初期値</summary>
		private const bool DEFAULT_DETAILDISPLAYINITIAL_VALUE	= false;
		/// <summary>ポイントラベル表示初期値</summary>
		private const bool DEFAULT_POINTLABELINITIAL_VALUE		= true;
		/// <summary>ポイントラベルフォントサイズ初期値</summary>
		private const int DEFAULT_POINTLABELSIZEINITIAL_VALUE	= 9;
		/// <summary>ラベル角度初期値</summary>
		private const bool DEFAULT_LABELVERTICALINITIAL_VALUE	= false;
		/// <summary>ラベル最大桁数初期値</summary>
		private const int DEFAULT_LABELMAXLENGTHINITIAL_VALUE	= -1;
		/// <summary>ラベルフォントサイズ初期値</summary>
		private const int DEFAULT_LABELSIZEINITIAL_VALUE		= 9;
		/// <summary>３Ｄ／２Ｄ表示初期値</summary>
		private const bool DEFAULT_VIEW3D2DINITIAL_VALUE		= true;
		#endregion

		#region Propaty
		/// <summary>詳細表示初期値プロパティ</summary>
		public bool DetailDisplayInitialValue
		{
			get { return this._detailDisplayInitialValue; }
			set { this._detailDisplayInitialValue = value; }
		}

		/// <summary>ポイントラベル表示初期値プロパティ</summary>
		public bool PointLabelInitialValue
		{
			get { return this._pointLabelInitialValue; }
			set { this._pointLabelInitialValue = value; }
		}

		/// <summary>ポイントラベルフォントサイズ初期値プロパティ</summary>
		public int PointLabelSizeInitialValue
		{
			get { return this._pointLabelSizeInitialValue; }
			set { this._pointLabelSizeInitialValue = value; }
		}

		/// <summary>ラベル角度初期値プロパティ</summary>
		public bool LabelVerticalInitialValue
		{
			get { return this._labelVerticalInitialValue; }
			set { this._labelVerticalInitialValue = value; }
		}

		/// <summary>ラベル最大桁数初期値プロパティ</summary>
		public int LabelMaxLengthInitialValue
		{
			get { return this._labelMaxLengthInitialValue; }
			set { this._labelMaxLengthInitialValue = value; }
		}

		/// <summary>ラベルフォントサイズ初期値プロパティ</summary>
		public int LabelSizeInitialValue
		{
			get { return this._labelSizeInitialValue; }
			set { this._labelSizeInitialValue = value; }
		}

		/// <summary>３Ｄ／２Ｄ表示初期値プロパティ</summary>
		public bool View3D2DInitialValue
		{
			get { return this._view3D2DInitialValue; }
			set { this._view3D2DInitialValue = value; }
		}
        // --- ADD 2010/07/20 -------------------------------->>>>>
        /// <summary>出力ファイル名（拠点）初期値プロパティ</summary>
        public string SectionFileNameValue
        {
            get { return this._sectionFileNameValue; }
            set { this._sectionFileNameValue = value; }
        }

        /// <summary>出力ファイル名（得意先）初期値プロパティ</summary>
        public string CustomerFileNameValue
        {
            get { return this._customerFileNameValue; }
            set { this._customerFileNameValue = value; }
        }

        /// <summary>出力ファイル名（担当者）初期値プロパティ</summary>
        public string SalesEmployeeFileNameValue
        {
            get { return this._salesEmployeeFileNameValue; }
            set { this._salesEmployeeFileNameValue = value; }
        }

        /// <summary>出力ファイル名（受注者）初期値プロパティ</summary>
        public string FrontEmployeeFileNameValue
        {
            get { return this._frontEmployeeFileNameValue; }
            set { this._frontEmployeeFileNameValue = value; }
        }

        /// <summary>出力ファイル名（発行者）初期値プロパティ</summary>
        public string SalesInputFileNameValue
        {
            get { return this._salesInputFileNameValue; }
            set { this._salesInputFileNameValue = value; }
        }

        /// <summary>出力ファイル名（地区）初期値プロパティ</summary>
        public string SalesAreaFileNameValue
        {
            get { return this._salesAreaFileNameValue; }
            set { this._salesAreaFileNameValue = value; }
        }

        /// <summary>出力ファイル名（業種）初期値プロパティ</summary>
        public string BusinessTypeFileNameValue
        {
            get { return this._businessTypeFileNameValue; }
            set { this._businessTypeFileNameValue = value; }
        }
        #endregion
        // --- ADD 2010/07/20 --------------------------------<<<<<
	}

	/// <summary>
	/// 分析チャート表示設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 分析チャート表示設定クラスのアクセス制御を行います。</br>
    /// <br>Programmer : 30462 行澤　仁美</br>
    /// <br>Date       : 2008.12.01</br>
	/// </remarks>
	public class AnalysisChartSettingAcs
	{
		#region Constructor
		/// <summary>
		/// 分析チャート表示設定アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 分析チャート表示設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
		/// </remarks>
		public AnalysisChartSettingAcs()
		{
			// 起動モード取得
			//if (DCHNB04180UA._parameter.Length != 0)
			//{
            //    this._startMode = TStrConv.StrToIntDef(DCHNB04180UA._parameter[0], 0);
			//}

			if (_analysisChartSetting == null)
			{
				_analysisChartSetting = new AnalysisChartSetting();
			}
			this.Deserialize();
		}
		#endregion

		#region Private Member
		/// <summary>起動モード</summary>
		private int _startMode = 0;
		/// <summary>分析チャート表示設定クラス</summary>
		private static AnalysisChartSetting _analysisChartSetting;

		/// <summary>分析チャート表示設定保存ファイル名称</summary>
		private const string XML_FILE_NAME = "SFANL06500U_ChartSetting?.XML";
		#endregion

		#region Events
		/// <summary>分析チャート表示設定変更後イベント</summary>
		public static event EventHandler AnalysisChartSettingChanged;
		#endregion

		#region Properties
		/// <summary>詳細表示初期値プロパティ</summary>
		public bool DetailDisplayInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.DetailDisplayInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.DetailDisplayInitialValue = value;
			}
		}

		/// <summary>ポイントラベル表示初期値プロパティ</summary>
		public bool PointLabelInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.PointLabelInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.PointLabelInitialValue = value;
			}
		}

		/// <summary>ポイントラベルフォントサイズ初期値プロパティ</summary>
		public int PointLabelSizeInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.PointLabelSizeInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.PointLabelSizeInitialValue = value;
			}
		}

		/// <summary>ラベル角度初期値プロパティ</summary>
		public bool LabelVerticalInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelVerticalInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelVerticalInitialValue = value;
			}
		}

		/// <summary>ラベル最大桁数初期値プロパティ</summary>
		public int LabelMaxLengthInitialValue
		{
			get
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				return _analysisChartSetting.LabelMaxLengthInitialValue;
			}
			set
			{
				if (_analysisChartSetting == null)
				{
					_analysisChartSetting = new AnalysisChartSetting();
				}
				_analysisChartSetting.LabelMaxLengthInitialValue = value;
			}
		}

        /// <summary>ラベルフォントサイズ初期値プロパティ</summary>
        public int LabelSizeInitialValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.LabelSizeInitialValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.LabelSizeInitialValue = value;
            }
        }

        /// <summary>３Ｄ／２Ｄ表示初期値プロパティ</summary>
        public bool View3D2DInitialValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.View3D2DInitialValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.View3D2DInitialValue = value;
            }
        }
        // --- ADD 2010/07/20 --------------------------------<<<<<
        #region Properties
        /// <summary>出力ファイル名（拠点）初期値プロパティ</summary>
        public string SectionFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SectionFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SectionFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（得意先）初期値プロパティ</summary>
        public string CustomerFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.CustomerFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.CustomerFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（担当者）初期値プロパティ</summary>
        public string SalesEmployeeFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SalesEmployeeFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SalesEmployeeFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（受注者）初期値プロパティ</summary>
        public string FrontEmployeeFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.FrontEmployeeFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.FrontEmployeeFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（発行者）初期値プロパティ</summary>
        public string SalesInputFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SalesInputFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SalesInputFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（地区）初期値プロパティ</summary>
        public string SalesAreaFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.SalesAreaFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.SalesAreaFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（業種）初期値プロパティ</summary>
        public string BusinessTypeFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.BusinessTypeFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.BusinessTypeFileNameValue = value;
            }
        }
        #endregion
        // --- ADD 2010/07/20 --------------------------------<<<<<
		#endregion

		#region Public Methods
		/// <summary>
		/// 分析チャート表示設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 徐後継</br>
        /// <br>            ・テキスト出力対応</br>
		/// </remarks>
		public void Serialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());
            
            //UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));//  DEL 2010/07/20
            UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));// ADD 2010/07/20

			// 受注検索検索画面用ユーザー設定変更後イベント
			if (AnalysisChartSettingChanged != null)
			{
				AnalysisChartSettingChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// 分析チャート表示設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 30462 行澤　仁美</br>
        /// <br>Date       : 2008.12.01</br>
        /// <br>Update Note: 2010/07/20 徐後継</br>
        /// <br>            ・テキスト出力対応</br>
		/// </remarks>
		public void Deserialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))//  DEL 2010/07/20
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))// ADD 2010/07/20
			{
				try
				{
                    //_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));//  DEL 2010/07/20
                    _analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));// ADD 2010/07/20

				}
				catch (InvalidOperationException)
				{
                    //UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));//  DEL 2010/07/20
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));// ADD 2010/07/20
				}
			}
		}
		#endregion
	}
}