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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ユーザー設定画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザー設定情報を入力します。</br>
	/// <br>Programmer : 22014 熊谷　友孝</br>
    /// <br>Date       : 2006.10.10</br>
    /// <br>UpdateNote : 2010/07/20 王　増喜 テキスト出力対応</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            ・テキスト出力対応13482</br>
	/// </remarks>
    public partial class PMZAI04101UC : Form
	{
		#region Constructor
		/// <summary>
		/// ユーザー設定画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ユーザー設定画面クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
		/// </remarks>
		public PMZAI04101UC()
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
            this.View3D2DInitialValue_ultraOptionSet.Value = this._analysisChartSettingAcs.View3D2DInitialValue;

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            this._analysisTextSettingAcs = new AnalysisTextSettingAcs();
            // 出力ファイル名表示初期値
            this.tEdit_SettingFileName.Value = this._analysisTextSettingAcs.StockFileNameValue;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
		}
		#endregion

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        public AnalysisTextSettingAcs AnalysisTextSettingAcs
        {
            get { return this._analysisTextSettingAcs; }
            set { this._analysisTextSettingAcs = value; }
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		#region Private Members
		private ImageList _imageList16 = null;
        private AnalysisChartSettingAcs _analysisChartSettingAcs = null;
        private AnalysisTextSettingAcs _analysisTextSettingAcs = null;// ADD 2010/07/20 テキスト出力対応 --------------------
		#endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
		/// </remarks>
		private void SFANL06500UE_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;
			this.Ok_ultraButton.Appearance.Image						= Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image					= Size16_Index.BEFORE;

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

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            // 出力ファイル名表示初期値
            this.tEdit_SettingFileName.Text                             = this._analysisTextSettingAcs.StockFileNameValue;

            this._imageList16 = IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
		}

		/// <summary>
		/// UltraButton.Click イベント（Ok_ultraButton）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
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
            this._analysisChartSettingAcs.Serialize();

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            // 出力ファイル名表示初期値
            this._analysisTextSettingAcs.StockFileNameValue = (string)this.tEdit_SettingFileName.Value;
            this._analysisTextSettingAcs.Serialize();
            this.Close();
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
		}

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// UltraButton.Click イベント（Ok_ultraButton）
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tEdit_SettingFileName.Text))
            {
                this.openFileDialog.FileName = this.tEdit_SettingFileName.Text.Trim();
            }
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;

            // ファイル選択
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_SettingFileName.Text = openFileDialog.FileName.ToUpper();
            }
        }

        /// <summary>
        /// テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御
        /// </summary>
        /// <param name="display">display</param>
        /// <remarks>
        /// <br>Note       : テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// <remarks>
        public void uTabControlSet(bool display)
        {
            //テキスト出力オプションの有効、無効で設定のテキスト出力タブの表示制御を行う。
            UserSetup_ultraTabControl.Tabs["TextOutput"].Visible = display;
        }

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォーカス移動時に発生します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "DetailDisplayInitialValue_ultraOptionSet":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;

                case "View3D2DInitialValue_ultraOptionSet":
                    {
                        if (!e.ShiftKey)
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
                                        if (UserSetup_ultraTabControl.Tabs["TextOutput"].Visible)
                                        {
                                            // タブ切り替え
                                            this.UserSetup_ultraTabControl.ActiveTab = this.UserSetup_ultraTabControl.Tabs["TextOutput"];
                                            this.UserSetup_ultraTabControl.SelectedTab = this.UserSetup_ultraTabControl.ActiveTab;
                                            // 次項目
                                            e.NextCtrl = this.tEdit_SettingFileName;
                                        }
                                        else
                                        {
                                            // 次項目
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                       
                                    }
                                    break;
                                default:
                                    {
                                        e.NextCtrl = this.tEdit_SettingFileName;
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                case "tEdit_SettingFileName":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = Ok_ultraButton;
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
                                        if (UserSetup_ultraTabControl.Tabs["ChartSetting"].Visible)
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
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SettingFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = tEdit_SettingFileName;
                                        }
                                    }
                                    break;
                                default:
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
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
		#endregion
	}

	/// <summary>
	/// 分析チャート表示設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : シリアル化する分析チャート表示設定クラスです。</br>
	/// <br>Programmer : 22014 熊谷　友孝</br>
	/// <br>Date       : 2006.10.10</br>
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
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
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
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
		/// </remarks>
        public AnalysisChartSetting(bool detailDisplayInitialValue, bool pointLabelInitialValue, int pointLabelSizeInitialValue, bool labelVerticalInitialValue, int labelMaxLengthInitialValue, int labelSizeInitialValue, bool view3D2DInitialValue)
		{
			this._detailDisplayInitialValue		= detailDisplayInitialValue;
			this._pointLabelInitialValue		= pointLabelInitialValue;
			this._pointLabelSizeInitialValue	= pointLabelSizeInitialValue;
			this._labelVerticalInitialValue		= labelVerticalInitialValue;
			this._labelMaxLengthInitialValue	= labelMaxLengthInitialValue;
			this._labelSizeInitialValue			= labelSizeInitialValue;
            this._view3D2DInitialValue = view3D2DInitialValue;
		}
		#endregion

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
        private const bool DEFAULT_VIEW3D2DINITIAL_VALUE = true;
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
		#endregion
	}

	/// <summary>
	/// 分析チャート表示設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 分析チャート表示設定クラスのアクセス制御を行います。</br>
	/// <br>Programmer : 22014 熊谷　友孝</br>
	/// <br>Date       : 2006.10.10</br>
	/// </remarks>
	public class AnalysisChartSettingAcs
	{
		#region Constructor
		/// <summary>
		/// 分析チャート表示設定アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
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
		#endregion

		#region Public Methods
		/// <summary>
		/// 分析チャート表示設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 分析チャート表示設定クラスのシリアライズを行います。</br>
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
		/// </remarks>
		public void Serialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            //UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)); // DEL 2010/07/20
            UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))); // ADD 2010/07/20
            
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
		/// <br>Programmer : 22014 熊谷　友孝</br>
		/// <br>Date       : 2006.10.10</br>
		/// </remarks>
		public void Deserialize()
		{
			string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            //if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))) // DEL 2010/07/20
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))) // ADD 2010/07/20
            {
				try
				{
                    //_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)); // DEL 2010/07/20
                    _analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))); // ADD 2010/07/20
                }
				catch (InvalidOperationException)
				{
                    //UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)); // DEL 2010/07/20
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))); // ADD 2010/07/20
                }
			}
		}
		#endregion
	}

    // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
    /// <summary>
    /// 分析チャート表示設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : シリアル化する分析チャート表示設定クラスです。</br>
    /// <br>Programmer : 王増喜</br>
    /// <br>Date       : 2010/07/20</br>
    /// </remarks>
    [Serializable]
    public class AnalysisTextSetting
    {
        #region Constructor
        /// <summary>
        /// 分析チャート表示設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSetting()
        {
            this._stockFileNameValue = DEFAULT_STOCKFILENAME_VALUE;
        }

        /// <summary>
        /// 分析チャート表示設定クラスコンストラクタ
        /// </summary>
        /// <param name="stockFileNameValue">出力ファイル名</param>
        /// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSetting(string stockFileNameValue)
        {
            this._stockFileNameValue = stockFileNameValue;
        }
        #endregion

        #region Private Member
        /// <summary>出力ファイル名表示初期値</summary>
        private string _stockFileNameValue;
        /// <summary>出力ファイル名表示初期値</summary>
        private const string DEFAULT_STOCKFILENAME_VALUE = "";
        #endregion

        #region Propaty
        /// <summary>出力ファイル名表示初期値</summary>
        public string StockFileNameValue
        {
            get { return this._stockFileNameValue; }
            set { this._stockFileNameValue = value; }
        }
        #endregion
    }

    /// <summary>
    /// 分析チャート表示設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 分析チャート表示設定クラスのアクセス制御を行います。</br>
    /// <br>Programmer : 王増喜</br>
    /// <br>Date       : 2010/07/20</br>
    /// </remarks>
    public class AnalysisTextSettingAcs
    {
        #region Constructor
        /// <summary>
        /// 分析チャート表示設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 分析チャート表示設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSettingAcs()
        {
            if (_analysisTextSetting == null)
            {
                _analysisTextSetting = new AnalysisTextSetting();
            }
            this.Deserialize();
        }
        #endregion

        #region Private Member
        /// <summary>起動モード</summary>
        private int _startMode = 2;
        /// <summary>分析チャート表示設定クラス</summary>
        private static AnalysisTextSetting _analysisTextSetting;

        /// <summary>分析チャート表示設定保存ファイル名称</summary>
        private const string XML_FILE_NAME = "SFANL06500U_ChartSetting?.XML";
        #endregion

        #region Events
        /// <summary>分析チャート表示設定変更後イベント</summary>
        public static event EventHandler AnalysisTextSettingChanged;
        #endregion

        #region Properties
        /// <summary>出力ファイル名表示初期値プロパティ</summary>
        public string StockFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                return _analysisTextSetting.StockFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.StockFileNameValue = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 分析チャート表示設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void Serialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            UserSettingController.SerializeUserSetting(_analysisTextSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));

            // 受注検索検索画面用ユーザー設定変更後イベント
            if (AnalysisTextSettingChanged != null)
            {
                AnalysisTextSettingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 分析チャート表示設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 分析チャート表示設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 王増喜</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void Deserialize()
        {
            string fileName = XML_FILE_NAME.Replace("?", this._startMode.ToString());

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))
            {
                try
                {
                    _analysisTextSetting = UserSettingController.DeserializeUserSetting<AnalysisTextSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                }
            }
        }
        #endregion
    }
    // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
}