//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/07/20  修正内容 : テキスト出力
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/10/09  修正内容 : 障害ID:15880対応
//----------------------------------------------------------------------------//
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
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010/07/20</br>
	/// </remarks>
	public partial class PMHNB04161UD : Form
	{
		#region Constructor
		/// <summary>
		/// ユーザー設定画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : ユーザー設定画面クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		public PMHNB04161UD()
		{
			InitializeComponent();

			this._imageList16									= IconResourceManagement.ImageList16;

            this._analysisTextSettingAcs                        = new AnalysisTextSettingAcs();

            this._analysisTextSettingAcs.ReferDivValue = this.ReferDiv; // ADD 2010/10/09
            this.tEdit_SalesEmployeeFileName.Text = this._analysisTextSettingAcs.SalesEmployeeFileNameValue;
		}
        // ---ADD 2010/10/09 --------------------->>>
        public PMHNB04161UD(int referDiv)
        {
            InitializeComponent();

            this.ReferDiv = referDiv;
            this._imageList16 = IconResourceManagement.ImageList16;

            this._analysisTextSettingAcs = new AnalysisTextSettingAcs(this.ReferDiv);

            this._analysisTextSettingAcs.ReferDivValue = this.ReferDiv;
            this.tEdit_SalesEmployeeFileName.Text = this._analysisTextSettingAcs.SalesEmployeeFileNameValue;
            this.tEdit_SalesSellerFileName.Text = this._analysisTextSettingAcs.SalesSellerFileNameValue;
            this.tEdit_SalesPublisherFileName.Text = this._analysisTextSettingAcs.SalesPublisherFileNameValue;
        }
        // ---ADD 2010/10/09 ---------------------<<<
		#endregion

        /// <summary>テキスト出力設定アクセスクラス</summary>
        public AnalysisTextSettingAcs AnalysisTextSettingAcs
        {
            get { return this._analysisTextSettingAcs; }
            set { this._analysisTextSettingAcs = value; }
        }

		#region Private Members
		private ImageList _imageList16 = null;
        private AnalysisTextSettingAcs _analysisTextSettingAcs = null;
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>参照区分</summary>
        private int _referDiv = 0;
        // ---ADD 2010/10/09 ---------------------<<<
		#endregion

        // ---ADD 2010/10/09 --------------------->>>
        #region プロパティ
        /// <summary>
        /// 参照区分
        /// </summary>
        public int ReferDiv
        {
            get { return this._referDiv; }
            set { this._referDiv = value; }
        }
        #endregion
        // ---ADD 2010/10/09 ---------------------<<<

        #region Control Events
        /// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
        private void PMHNB04161UD_Load(object sender, EventArgs e)
		{
			this.Ok_ultraButton.ImageList								= this._imageList16;
			this.Cancel_ultraButton.ImageList							= this._imageList16;

            this.ultraButton_SalesEmployeeFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesEmployeeFileSelect.Appearance.Image = Size16_Index.STAR1;

            this.tEdit_SalesEmployeeFileName.Text = this._analysisTextSettingAcs.SalesEmployeeFileNameValue;
            // ---ADD 2010/10/09 --------------------->>>
            this.ultraButton_SalesSellerFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesSellerFileSelect.Appearance.Image = Size16_Index.STAR1;
            this.ultraButton_SalesPublisherFileSelect.ImageList = this._imageList16;
            this.ultraButton_SalesPublisherFileSelect.Appearance.Image = Size16_Index.STAR1;

            this.tEdit_SalesSellerFileName.Text = this._analysisTextSettingAcs.SalesSellerFileNameValue;
            this.tEdit_SalesPublisherFileName.Text = this._analysisTextSettingAcs.SalesPublisherFileNameValue;
            // ---ADD 2010/10/09 ---------------------<<<
		}

        private void ultraButton_FileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {
               
                case "ultraButton_SalesEmployeeFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesEmployeeFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesEmployeeFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesEmployeeFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }
            
        }

        // ---ADD 2010/10/09 --------------------->>>
        private void ultraButton_SellerFileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {

                case "ultraButton_SalesSellerFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesSellerFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesSellerFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesSellerFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }

        }

        private void ultraButton_PublisherFileSelect_Click(object sender, EventArgs e)
        {
            string controlName = ((Control)sender).Name;

            switch (controlName)
            {

                case "ultraButton_SalesPublisherFileSelect":
                    {
                        if (!string.IsNullOrEmpty(this.tEdit_SalesPublisherFileName.Text))
                        {
                            this.openFileDialog.FileName = this.tEdit_SalesPublisherFileName.Text.Trim();
                        }
                        this.openFileDialog.Multiselect = false;
                        this.openFileDialog.CheckFileExists = false;
                        // ファイル選択
                        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.tEdit_SalesPublisherFileName.Text = this.openFileDialog.FileName.ToUpper();
                        }
                        break;
                    }
            }

        }
        // ---ADD 2010/10/09 ---------------------<<<

		/// <summary>
		/// UltraButton.Click イベント（Ok_ultraButton）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note       : コントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
		/// </remarks>
		private void Ok_ultraButton_Click(object sender, EventArgs e)
		{
            // ---UPD 2010/10/09 --------------------->>>
            //this._analysisTextSettingAcs.SalesEmployeeFileNameValue = this.tEdit_SalesEmployeeFileName.Text;
            // ファイル名（担当者）
            this._analysisTextSettingAcs.SalesEmployeeFileNameValue = this.tEdit_SalesEmployeeFileName.Text;

            // ファイル名（受注者）
            this._analysisTextSettingAcs.SalesSellerFileNameValue = this.tEdit_SalesSellerFileName.Text;

            // ファイル名（発行者）
            this._analysisTextSettingAcs.SalesPublisherFileNameValue = this.tEdit_SalesPublisherFileName.Text;
            // ---UPD 2010/10/09 ---------------------<<<
            this._analysisTextSettingAcs.Serialize();

            this.Close();
            
		}
		#endregion

        /// <summary>
        /// フォーカス移動イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーカス移動イベント処理</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SalesEmployeeFileName":
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
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text))
                                        {
                                            // 次項目
                                            //e.NextCtrl = Ok_ultraButton; // DEL 2010/10/09
                                            e.NextCtrl = tEdit_SalesSellerFileName; // DEL 2010/10/09
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
                // ---ADD 2010/10/09 --------------------->>>
                case "tEdit_SalesSellerFileName":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text))
                                        {
                                            // ファイル名（担当者）ガイド
                                            e.NextCtrl = ultraButton_SalesEmployeeFileSelect;
                                        }
                                        else
                                        {
                                            // ファイル名（担当者）
                                            e.NextCtrl = tEdit_SalesEmployeeFileName;
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
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesSellerFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = tEdit_SalesPublisherFileName;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_SalesSellerFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "tEdit_SalesPublisherFileName":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (string.IsNullOrEmpty(tEdit_SalesSellerFileName.Text))
                                        {
                                            // ファイル名（受注者）ガイド
                                            e.NextCtrl = ultraButton_SalesSellerFileSelect;
                                        }
                                        else
                                        {
                                            // ファイル名（受注者）
                                            e.NextCtrl = tEdit_SalesSellerFileName;
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
                                case Keys.Return:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_SalesPublisherFileName.Text))
                                        {
                                            // 次項目
                                            e.NextCtrl = Ok_ultraButton;
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            e.NextCtrl = ultraButton_SalesPublisherFileSelect;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                // ---ADD 2010/10/09 ---------------------<<<
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
                                        //if (string.IsNullOrEmpty(tEdit_SalesEmployeeFileName.Text)) // DEL 2010/10/09
                                        if (string.IsNullOrEmpty(tEdit_SalesPublisherFileName.Text)) // ADD 2010/10/09
                                        {
                                            // 次項目
                                            //e.NextCtrl = ultraButton_SalesEmployeeFileSelect; // DEL 2010/10/09
                                            e.NextCtrl = ultraButton_SalesPublisherFileSelect; // ADD 2010/10/09
                                        }
                                        else
                                        {
                                            // ガイドボタン
                                            //e.NextCtrl = tEdit_SalesEmployeeFileName; // DEL 2010/10/09
                                            e.NextCtrl = tEdit_SalesPublisherFileName; // ADD 2010/10/09
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

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : キャンセルボタン</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        private void Cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
	}

    
    /// <summary>
    /// テキスト出力設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : シリアル化する分析テキスト出力設定クラスです。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010/07/20</br>
    /// </remarks>
    [Serializable]
    public class AnalysisTextSetting
    {
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>参照区分</summary>
        private int _referDivValue = 0;
        // ---ADD 2010/10/09 ---------------------<<<

        // ---ADD 2010/10/09 --------------------->>>
        #region プロパティ
        /// <summary>
        /// 参照区分
        /// </summary>
        public int ReferDivValue
        {
            get { return this._referDivValue; }
            set { this._referDivValue = value; }
        }
        #endregion
        // ---ADD 2010/10/09 ---------------------<<<

        #region Constructor
        /// <summary>
        /// テキスト出力設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSetting()
        {
            this._salesEmployeeFileNameValue = string.Empty;
            this._salesSellerFileNameValue = string.Empty; // ADD 2010/10/09
            this._salesPublisherFileNameValue = string.Empty; // ADD 2010/10/09
        }

        /// <summary>
        /// テキスト出力設定クラスコンストラクタ
        /// </summary>
        /// <param name="salesEmployeeFileNameValue">出力ファイル名（担当者）初期値</param>
        /// <remarks>
        /// <br>Note       : テキスト出力設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSetting(string salesEmployeeFileNameValue)
        {
            // ---UPD 2010/10/09 --------------------->>>
            //this._salesEmployeeFileNameValue = salesEmployeeFileNameValue;
            // 参照区分は受注者の場合
            if (this._referDivValue == 2)
            {
                this._salesSellerFileNameValue = salesEmployeeFileNameValue;
            }
            // 参照区分は発行者の場合
            else if (this._referDivValue == 3)
            {
                this._salesPublisherFileNameValue = salesEmployeeFileNameValue;
            }
            // そのほかの場合
            else
            {
                this._salesEmployeeFileNameValue = salesEmployeeFileNameValue;
            }
            // ---UPD 2010/10/09 ---------------------<<<
        }
        #endregion

        #region Private Member
        /// <summary>出力ファイル名（担当者）初期値</summary>
        private string _salesEmployeeFileNameValue;

        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>出力ファイル名（受注者）初期値</summary>
        private string _salesSellerFileNameValue;

        /// <summary>出力ファイル名（発行者）初期値</summary>
        private string _salesPublisherFileNameValue;
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion

        #region Propaty

        /// <summary>出力ファイル名（担当者）初期値プロパティ</summary>
        public string SalesEmployeeFileNameValue
        {
            get { return this._salesEmployeeFileNameValue; }
            set { this._salesEmployeeFileNameValue = value; }
        }
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>出力ファイル名（受注者）初期値プロパティ</summary>
        public string SalesSellerFileNameValue
        {
            get { return this._salesSellerFileNameValue; }
            set { this._salesSellerFileNameValue = value; }
        }

        /// <summary>出力ファイル名（発行者）初期値プロパティ</summary>
        public string SalesPublisherFileNameValue
        {
            get { return this._salesPublisherFileNameValue; }
            set { this._salesPublisherFileNameValue = value; }
        }
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion
    }

    /// <summary>
    /// テキスト出力設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力設定クラスのアクセス制御を行います。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010/07/20</br>
    /// </remarks>
    public class AnalysisTextSettingAcs
    {
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>参照区分</summary>
        private int _referDivValue = 0;
        // ---ADD 2010/10/09 ---------------------<<<

        // ---ADD 2010/10/09 --------------------->>>
        #region プロパティ
        /// <summary>
        /// 参照区分
        /// </summary>
        public int ReferDivValue
        {
            get { return this._referDivValue; }
            set { this._referDivValue = value; }
        }

        /// <summary>テキスト出力設定クラス</summary>
        public AnalysisTextSetting AnalysisTextSetting
        {
            get { return _analysisTextSetting; }
            set { _analysisTextSetting = value; }
        }
        #endregion
        // ---ADD 2010/10/09 ---------------------<<<

        #region Constructor
        /// <summary>
        /// テキスト出力設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public AnalysisTextSettingAcs()
        {
            if (_analysisTextSetting == null)
            {
                _analysisTextSetting = new AnalysisTextSetting();
            }
            _analysisTextSetting.ReferDivValue = this.ReferDivValue; // ADD 2010/10/09
            this.Deserialize();
        }
        // ---ADD 2010/10/09 --------------------->>>
        public AnalysisTextSettingAcs(int referDivValue)
        {
            this.ReferDivValue = referDivValue;
            if (_analysisTextSetting == null)
            {
                _analysisTextSetting = new AnalysisTextSetting();
            }
            _analysisTextSetting.ReferDivValue = this.ReferDivValue;
            this.Deserialize();
        }
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion

        #region Private Member
        /// <summary>テキスト出力設定クラス</summary>
        private static AnalysisTextSetting _analysisTextSetting;
        /// <summary>テキスト出力設定保存ファイル名称</summary>
        private const string XML_FILE_NAME = "PMHNB04160U_Construction.XML";
        #endregion

        #region Events
        /// <summary>テキスト出力設定変更後イベント</summary>
        public static event EventHandler AnalysisTextSettingChanged;
        #endregion

        #region Properties
        /// <summary>出力ファイル名（担当者）初期値プロパティ</summary>
        public string SalesEmployeeFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue; // ADD 2010/10/09

                return _analysisTextSetting.SalesEmployeeFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue; // ADD 2010/10/09

                _analysisTextSetting.SalesEmployeeFileNameValue = value;
            }
        }
        // ---ADD 2010/10/09 --------------------->>>
        /// <summary>出力ファイル名（受注者）初期値プロパティ</summary>
        public string SalesSellerFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;

                return _analysisTextSetting.SalesSellerFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;

                _analysisTextSetting.SalesSellerFileNameValue = value;
            }
        }

        /// <summary>出力ファイル名（発行者）初期値プロパティ</summary>
        public string SalesPublisherFileNameValue
        {
            get
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;

                return _analysisTextSetting.SalesPublisherFileNameValue;
            }
            set
            {
                if (_analysisTextSetting == null)
                {
                    _analysisTextSetting = new AnalysisTextSetting();
                }
                _analysisTextSetting.ReferDivValue = this.ReferDivValue;
                _analysisTextSetting.SalesPublisherFileNameValue = value;
            }
        }
        // ---ADD 2010/10/09 ---------------------<<<
        #endregion

        #region Public Methods
        /// <summary>
        /// テキスト出力設定クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力設定クラスのシリアライズを行います。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_analysisTextSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

            // 担当者別実績照会画面用ユーザー設定変更後イベント
            if (AnalysisTextSettingChanged != null)
            {
                AnalysisTextSettingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// テキスト出力設定クラスデシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010/07/20</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    _analysisTextSetting = UserSettingController.DeserializeUserSetting<AnalysisTextSetting>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                catch (InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
            }
        }
        #endregion
    }
    
}