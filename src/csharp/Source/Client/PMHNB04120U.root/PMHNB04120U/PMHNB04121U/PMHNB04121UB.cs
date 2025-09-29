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
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	public partial class PMHNB04121UB : Form
	{
		#region Constructor
		/// <summary>
		/// ユーザー設定画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : ユーザー設定画面クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public PMHNB04121UB()
		{
			InitializeComponent();

			this._imageList16 = IconResourceManagement.ImageList16;

            this._analysisChartSettingAcs = new AnalysisChartSettingAcs(); 

		}
		#endregion

        public AnalysisChartSettingAcs AnalysisChartSettingAcs
        {
            get { return this._analysisChartSettingAcs; }
            set { this._analysisChartSettingAcs = value; }
        }

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
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
        private void PMHNB04121UB_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;
			this.Ok_ultraButton.Appearance.Image						= Size16_Index.DECISION;
			this.Cancel_ultraButton.Appearance.Image					= Size16_Index.BEFORE;

            this.ultraButton_FileSelect.ImageList = this._imageList16;
            this.ultraButton_FileSelect.Appearance.Image = Size16_Index.STAR1;

            this.tEdit_FileName.Text = this._analysisChartSettingAcs.CustomInqFileNameValue;

		}

        /// <summary>
        /// FileSelect イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void ultraButton_FileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
                case "ultraButton_FileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_FileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_FileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        this.openFileDialog.Filter = string.Format("{0} | {1}", "ファイル(*.*)", "*.*");
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_FileName.Text = this.openFileDialog.FileName.ToUpper();
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
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
            this._analysisChartSettingAcs.CustomInqFileNameValue = this.tEdit_FileName.Text;
            this._analysisChartSettingAcs.Serialize();
            this.DialogResult = DialogResult.OK;
            // 終了
            this.Close();
		}
		#endregion

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_FileName":
                    {
                        # region [次フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_FileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_FileSelect;
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
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        # endregion
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
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キャンセルボタンイベント処理します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
	}

	/// <summary>
	/// 設定クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : シリアル化する分析設定クラスです。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	[Serializable]
	public class AnalysisChartSetting
	{
		#region Constructor
		/// <summary>
		/// 設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public AnalysisChartSetting()
		{
            this._customInqFileNameValue = string.Empty;
		}

		/// <summary>
		/// 設定クラスコンストラクタ
		/// </summary>
        /// <param name="customInqFileNameValue">出力ファイル名初期値</param>
		/// <remarks>
        /// <br>Note       : 設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
        public AnalysisChartSetting(string customInqFileNameValue)
		{
            this._customInqFileNameValue = customInqFileNameValue;
		}
		#endregion

        #region Private Member
        /// <summary>出力ファイル名初期値</summary>
        private string _customInqFileNameValue;
        #endregion

        #region Propaty
        /// <summary>出力ファイル名初期値プロパティ</summary>
        public string CustomInqFileNameValue
        {
            get { return this._customInqFileNameValue; }
            set { this._customInqFileNameValue = value; }
        }
        #endregion
	}

	/// <summary>
	/// 表示設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 表示設定クラスのアクセス制御を行います。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	public class AnalysisChartSettingAcs
	{
		#region Constructor
		/// <summary>
		/// 表示設定アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public AnalysisChartSettingAcs()
		{
			if (_analysisChartSetting == null)
			{
				_analysisChartSetting = new AnalysisChartSetting();
			}
			this.Deserialize();
		}
		#endregion

		#region Private Member
		/// <summary>設定クラス</summary>
		private static AnalysisChartSetting _analysisChartSetting;

		/// <summary>設定保存ファイル名称</summary>
		private const string XML_FILE_NAME = "PMHNB04120U_Construction.XML";
		#endregion

		#region Events
		/// <summary>設定変更後イベント</summary>
		public static event EventHandler AnalysisChartSettingChanged;
		#endregion

        #region Properties
        /// <summary>出力ファイル名初期値プロパティ</summary>
        public string CustomInqFileNameValue
        {
            get
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                return _analysisChartSetting.CustomInqFileNameValue;
            }
            set
            {
                if (_analysisChartSetting == null)
                {
                    _analysisChartSetting = new AnalysisChartSetting();
                }
                _analysisChartSetting.CustomInqFileNameValue = value;
            }
        }
        #endregion

		#region Public Methods
		/// <summary>
		/// 表示設定クラスシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 表示設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public void Serialize()
		{
            string fileName = XML_FILE_NAME;

            UserSettingController.SerializeUserSetting(_analysisChartSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));

			// 検索画面用ユーザー設定変更後イベント
			if (AnalysisChartSettingChanged != null)
			{
				AnalysisChartSettingChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// 表示設定クラスデシリアライズ処理
		/// </summary>
		/// <remarks>
        /// <br>Note       : 表示設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public void Deserialize()
		{
            string fileName = XML_FILE_NAME;

			if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName))))
			{
				try
				{
					_analysisChartSetting = UserSettingController.DeserializeUserSetting<AnalysisChartSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
                }
				catch (InvalidOperationException)
				{
					UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)));
				}
			}
		}
		#endregion
	}
}