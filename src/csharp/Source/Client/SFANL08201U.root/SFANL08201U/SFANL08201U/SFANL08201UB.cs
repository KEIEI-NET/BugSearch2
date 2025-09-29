using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 登録用ダイアログクラス
    /// </summary>
	public partial class MaintenanceDlg: GridFormBase
	{
        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region delegate
        /// <summary>
        /// 自由帳票グループ追加保存デリゲート
        /// </summary>
        /// <param name="freePprGrp">自由帳票グループ</param>
        /// <returns>ステータス</returns>
        public delegate bool SaveNewGroupDelegate(FreePprGrp freePprGrp);

        /// <summary>
        /// 自由帳票グループ振替追加保存デリゲート
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループ振替</param>
        /// <returns>ステータス</returns>
        public delegate bool SaveNewFrePprDelegate(FrePprGrTr frePprGrTr);
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
		public MaintenanceDlg()
		{
			InitializeComponent();
            // データセット作成
            DataSetColumnConstruction();
            // 画面初期設定
            InitialScreenSetting();
        }
        #endregion

        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //
        #region public member
        /// <summary>SaveNewGroup</summary>
        public SaveNewGroupDelegate SaveNewGroup;      // グループの保存ボタンが押下されたときのデリゲート
        /// <summary>SaveNewFrePpr</summary>
        public SaveNewFrePprDelegate SaveNewFrePpr;    // 明細の保存ボタンが押下されたときのデリゲート
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region private member
        private int _dialogMode = 0;           // 0:自由帳票グループ　1：自由帳票グループ振替
        private FreePprGrpAcs _freePprGrpAcs = new FreePprGrpAcs();
        private int _groupCode = 0;            // プロパティ用
        private DateTime _updateTime = DateTime.MinValue;          // 更新日付保持用
        private DateTime _createTime = DateTime.MinValue;          // 作成日付保持用
        private Guid _guid = Guid.Empty;                           // FileHeaderGUID保持用
        private DataTable _frePprSelectDT;                         // 帳票選択に使用するGrid用
        private bool _canClose = false;                           // 画面クローズを許可の設定
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region private constant
        //const string PGID = "MaintenanceDlg";
        const string INS_MODE = "新規モード";
        const string UPD_MODE = "更新モード";
        const int CT_GROUPMODE = 0;
        const int CT_TRANCEMODE = 1;
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region Prorerties
        /// <summary>
        /// グループコード
        /// </summary>
        public int GroupCode
        {
            get { return _groupCode; }
            set
            {
                _groupCode = value;
                this.GroupCd_tNedit.SetInt(value); 
            }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可の設定を取得または設定します</value>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }
        #endregion

        // ===================================================================================== //
        // パブリック関数
        // ===================================================================================== //
        #region private methods
 
        #region 画面再構築処理
        /// <summary>
        /// 画面表示(自由帳票グループモード)新規
        /// </summary>
        public void ShowGroupDlg()
        {
            //画面クリア
            ScreenClear();
            //新規モード
            Mode_Label1.Text = INS_MODE;
            GroupCd_tNedit.Enabled = true;
            GroupCd_tNedit.Text = string.Empty;

            //ダイアログモードを(グループモードに)変更
            _dialogMode = CT_GROUPMODE;
            groupAdd_panel.Visible = true;
            TranceAdd_Panel.Visible = false;
        
            // パネルを表示する
            groupAdd_panel.Location = new Point(0, 0);
            groupAdd_panel.Visible = true;

            // ウィンドウサイズをグループパネルにあわせる
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = groupAdd_panel.Size.Width;
            int afterClientHeight = groupAdd_panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // ウィンドウサイズの変更にあわせて座標を補正する
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);

            this.Text = "自由帳票グループ設定";
            this.TopLevel = true;
            this.Show();
        }

        /// <summary>
        /// 画面表示(自由帳票グループ振替モード)新規
        /// </summary>
        public void ShowTranceDlg()
        {
            //全グループならキャンセル
            if (GroupCode == 0)
            {
                TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                "MaintenanceDlg", 						    // アセンブリＩＤまたはクラスＩＤ
                "全グループには追加できません",     // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);   // 表示するボタン
                return;
            }

            //画面クリア
            ScreenClear();
            //新規モード
            Mode_Label2.Text = INS_MODE;
            ultraLabel2.Visible = true;

            //ダイアログモードを(振替モードに)変更
            _dialogMode = CT_TRANCEMODE;
            groupAdd_panel.Visible = false;
            TranceAdd_Panel.Visible = true;

            // パネルを表示する
            TranceAdd_Panel.Location = new Point(0, 0);
            TranceAdd_Panel.Visible = true;

            // ウィンドウサイズをグループパネルにあわせる
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = TranceAdd_Panel.Size.Width;
            int afterClientHeight = TranceAdd_Panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // ウィンドウサイズの変更にあわせて座標を補正する
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);


            //-- コンボボックス設定 -----------------------------
            ArrayList freePprGrpAL = new ArrayList();
            
            //グループ情報取得
            _freePprGrpAcs.SearchStaticMemoryFreePprGrp(out freePprGrpAL, LoginInfoAcquisition.EnterpriseCode);
            foreach (FreePprGrp freePprGrp in freePprGrpAL)
            {
                //全グループはのぞく
                if (freePprGrp.FreePrtPprGroupCd == 0)
                    continue;
                //コンボボックスに追加                
                //選択されていたグループを標準で選択する
                if (freePprGrp.FreePrtPprGroupCd == GroupCode)
                {
                    Group_tComboEditor.Items.Add(freePprGrp.FreePrtPprGroupCd, freePprGrp.FreePrtPprGroupNm);
                    Group_tComboEditor.SelectedIndex = 0;
                }
            }

            // 帳票選択グリッドをフィルタリング 
            _frePprSelectDT.DefaultView.RowFilter = string.Empty;
            FrePprSelect_Grid.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.FireInitializeRow);

            this.Text = "自由帳票設定";
            this.Show();
        }

        /// <summary>
        /// 画面表示(自由帳票グループモード)更新
        /// </summary>
        public void ShowGroupDlg(int frePprGrpCd, string frePprGrpNm, DateTime updateTime, DateTime createTime,Guid guid)
        {
            //画面クリア
            ScreenClear();
            //更新モード
            Mode_Label1.Text = UPD_MODE;
            GroupCd_tNedit.Enabled = false;

            //ダイアログモードを(グループモードに)変更
            _dialogMode = CT_GROUPMODE;
            groupAdd_panel.Visible = true;
            TranceAdd_Panel.Visible = false;

            // パネルを表示する
            groupAdd_panel.Location = new Point(0, 0);
            groupAdd_panel.Visible = true;

            // ウィンドウサイズをグループパネルにあわせる
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = groupAdd_panel.Size.Width;
            int afterClientHeight = groupAdd_panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // ウィンドウサイズの変更にあわせて座標を補正する
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);

            this.Text = "自由帳票グループ設定";
            GroupCd_tNedit.SetValue(frePprGrpCd);
            GroupNm_tEdit.Text = frePprGrpNm;
            _updateTime = updateTime;
            _createTime = createTime;
            _guid = guid;
            this.Show();
        }

        /// <summary>
        /// 画面表示(自由帳票グループ振替モード)更新
        /// </summary>
        public void ShowTranceDlg(int frePprGrpCd, int frePprGrTrCd, int oderNo, string outputFormFileName, int userPrtPprIdDerivNo, DateTime updateTime, DateTime createTime,Guid guid)
        {
            //画面クリア
            ScreenClear();
            //更新モード
            Mode_Label2.Text = UPD_MODE;
            ultraLabel2.Visible = false;

            //ダイアログモードを(振替モードに)変更
            _dialogMode = CT_TRANCEMODE;
            groupAdd_panel.Visible = false;
            TranceAdd_Panel.Visible = true;

            // パネルを表示する
            TranceAdd_Panel.Location = new Point(0, 0);
            TranceAdd_Panel.Visible = true;

            // ウィンドウサイズをグループパネルにあわせる
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = TranceAdd_Panel.Size.Width;
            int afterClientHeight = TranceAdd_Panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // ウィンドウサイズの変更にあわせて座標を補正する
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);

            //-- コンボボックス設定 -----------------------------
            ArrayList freePprGrpAL = new ArrayList();

            //グループ情報取得
            _freePprGrpAcs.SearchStaticMemoryFreePprGrp(out freePprGrpAL, LoginInfoAcquisition.EnterpriseCode);
            foreach (FreePprGrp freePprGrp in freePprGrpAL)
            {

                //選択されていたグループを標準で選択する
                if (freePprGrp.FreePrtPprGroupCd == frePprGrpCd)
                {
                    Group_tComboEditor.Items.Add(freePprGrp.FreePrtPprGroupCd, freePprGrp.FreePrtPprGroupNm);
                    Group_tComboEditor.SelectedIndex = 0;
                }
            }

            //更新情報を出力
            FrrPptDispOrderCd_tNedit.SetValue(oderNo);
            FrrPptDispOrderCd_tNedit.Tag = frePprGrTrCd;
            FrePrtPSet wk = new FrePrtPSet();
            wk.OutputFormFileName = outputFormFileName;
            wk.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;

            // 帳票選択グリッドをフィルタリング 
            _frePprSelectDT.DefaultView.RowFilter = CT_FREE_PPR_OFrmFilNm + " = '" + outputFormFileName + "' AND " + CT_FREE_PPR_DerivNo + "=" + userPrtPprIdDerivNo.ToString();
            
            _updateTime = updateTime;
            _createTime = createTime;
            _guid = guid;
            
            this.Text = "自由帳票設定";
            this.Show();
        }
        #endregion

        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private methods 

        #region 画面初期設定
        /// <summary>
        /// 画面初期設定
        /// </summary>
        private void InitialScreenSetting()
        {
            //アイコンの設定
            ImageList imageList24 = IconResourceManagement.ImageList24;
            // 保存ボタン
            this.GrOk_Button.ImageList = imageList24;
            this.GrOk_Button.Appearance.Image = Size24_Index.SAVE;
            this.TrOk_Button.ImageList = imageList24;
            this.TrOk_Button.Appearance.Image = Size24_Index.SAVE;

            // 保存ボタン
            this.GrCancel_Button.ImageList = imageList24;
            this.GrCancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.TrCancel_Button.ImageList = imageList24;
            this.TrCancel_Button.Appearance.Image = Size24_Index.CLOSE;

            //タスクバーに表示しない
            this.ShowInTaskbar = false;

            //グリッドの設定
            FrePprSelect_Grid.DataSource = _frePprSelectDT;
            _frePprSelectDT.DefaultView.Sort = CT_FREE_PPR_DerivNo;
            setGridAppearance(FrePprSelect_Grid);        // 配色設定
            setGridBehavior(FrePprSelect_Grid);          // 動作設定
            SetGridColAppearance();                      // 表示設定
        }
        #endregion

        #region DataSet構築処理
        private void DataSetColumnConstruction()
        {
            //-- 自由帳票グループ -------------------------------------
            _frePprSelectDT = new DataTable(CT_FREE_PPR_SLCT);
            //// GUID
            //_frePprSelectDT.Columns.Add(CT_FREE_PPR_GUID, typeof(Guid));
            //// 更新日付
            //_frePprSelectDT.Columns.Add(CT_FREE_PPR_UPDT, typeof(DateTime));
            //// 作成日付
            //_frePprSelectDT.Columns.Add(CT_FREE_PPR_CRDT, typeof(DateTime));    
            //出力名称
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_PrtNm, typeof(string));
            //コメント
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_USRComment, typeof(string));
            //出力ファイル名
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_OFrmFilNm, typeof(string));
            //ユーザー帳票ID枝番号 
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_DerivNo, typeof(Int32));
        }
        #endregion

        #region 帳票選択グリッドデータ作成処理
        private void SetSelectPprInfo()
        {
            //印字位置設定のキャッシュを取得
            List<FrePrtPSet> frePprPSetLs = null;
            int sts = SFANL08201UA.GetFrePrtPSetLsCash(ref frePprPSetLs);
            int index = 0;

            //データクリア
            _frePprSelectDT.Rows.Clear();

            //値をセットする
            if (sts != 0) return;
            foreach (FrePrtPSet frePprPSet in frePprPSetLs)
            {
                DataRow dataRow = _frePprSelectDT.NewRow();
                dataRow[CT_FREE_PPR_OFrmFilNm]  = frePprPSet.OutputFormFileName;
                dataRow[CT_FREE_PPR_DerivNo]    = frePprPSet.UserPrtPprIdDerivNo;
                dataRow[CT_FREE_PPR_PrtNm]      = frePprPSet.DisplayName;
                dataRow[CT_FREE_PPR_USRComment] = frePprPSet.PrtPprUserDerivNoCmt;
                _frePprSelectDT.Rows.Add(dataRow);
                index++;
            }
            if (FrePprSelect_Grid.Rows.FilteredInRowCount > 0)
            {
                FrePprSelect_Grid.Rows[0].Activate();
            }
        }
        #endregion

        #region グリッド列概観設定
        private void SetGridColAppearance()
        {
            // 表示設定
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_OFrmFilNm].Hidden = true;
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_DerivNo].Hidden = true;
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_PrtNm].Hidden = false;
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_USRComment].Hidden = false;
        }
        #endregion

        #region 画面クリア処理
        private void ScreenClear()
        {
            if(_frePprSelectDT.Rows.Count == 0)
                SetSelectPprInfo();                          // グリッドにデータ設定
            GroupCd_tNedit.SetInt(0);
            GroupNm_tEdit.Text = "";
            FrrPptDispOrderCd_tNedit.SetInt(0);
            FrrPptDispOrderCd_tNedit.Tag = null;
            Group_tComboEditor.Items.Clear();
            _updateTime = DateTime.MinValue;
            _createTime = DateTime.MinValue;
            _guid = Guid.Empty;
            if (FrePprSelect_Grid.Rows.FilteredInRowCount > 0)
                FrePprSelect_Grid.Rows[0].Activate();
        }
        #endregion

        #region 入力チェック処理
        /// <summary>
        /// 画面入力チェック
        /// </summary>
        /// <param name="control">チェックNG時のフォーカス移動先</param>
        /// <param name="message">チェックNG時のメッセージ</param>
        /// <returns>ture:OK false:不正入力あり</returns>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            if (_dialogMode == CT_TRANCEMODE)
            {
                // 表示順位コード
                if (this.FrrPptDispOrderCd_tNedit.GetInt() <= 0)
                {
                    control = this.FrrPptDispOrderCd_tNedit;
                    message = this.FrrPptDispOrderCd_Title.Text + "を入力してください";
                    return false;
                }
                // 振替名称
                if ((this.FrePprSelect_Grid.ActiveRow == null) || (this.FrePprSelect_Grid.ActiveRow.Index < 0))
                {
                    control = this.FrePprSelect_Grid;
                    message = this.FrePpr_Title.Text + "を入力してください";
                    return false;
                }
            }
            else if (_dialogMode == CT_GROUPMODE)
            {
                // グループコード
                if (this.GroupCd_tNedit.GetInt() <= 0)
                {
                    control = this.GroupCd_tNedit;
                    message = this.GroupCd_Title.Text + "を入力してください";
                    return false;
                }
                // グループ名称

                if (this.GroupNm_tEdit.Text.TrimEnd(new char[]{' ','　'}) == "")
                {
                    control = this.GroupNm_tEdit;
                    message = this.GroupNm_Title.Text + "を入力してください";
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 自由帳票グループ登録処理
        private bool RegistGroupData()
        {
            // 入力チェック
            string message = "";
            Control control = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, message, 0, MessageBoxButtons.OK);
                control.Focus();
                if (control is TEdit) ((TEdit)control).SelectAll();
                return false;
            }

            FreePprGrp frePprGr = new FreePprGrp();
            DispToFreePprGrp(ref frePprGr);

            // このデリゲートを実行するとAクラスを使って登録結果がOKならUI更新
            return SaveNewGroup(frePprGr);     //保存ボタン押下デリゲート呼出し
        }
        #endregion

        #region 自由帳票振替情報登録処理
        private bool RegistTranceData()
        {
            // 入力チェック
            string message = "";
            Control control = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, message, 0, MessageBoxButtons.OK);
                control.Focus();
                if (control is TEdit) ((TEdit)control).SelectAll();
                return false;
            }

            FrePprGrTr frePprGrTr = null;
            DispToFreePprGrTr(ref frePprGrTr);

            //ここでAクラスを使って登録結果がOKならUI更新
            return SaveNewFrePpr(frePprGrTr);      // 保存ボタン押下デリゲート処理呼出し
        }
        #endregion

        #region 画面　→　自由帳票グループ
        /// <summary>
        /// 画面入力情報自由帳票グループクラス格納
        /// </summary>
        /// <param name="frePprGrp">自由帳票グループクラス</param>
        private void DispToFreePprGrp(ref FreePprGrp frePprGrp)
        {
            if (frePprGrp == null)
            {
                // 新規の場合
                frePprGrp = new FreePprGrp();
            }

            frePprGrp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            frePprGrp.FreePrtPprGroupCd = GroupCd_tNedit.GetInt();
            frePprGrp.FreePrtPprGroupNm = GroupNm_tEdit.Text;
            if (_updateTime != DateTime.MinValue)
                frePprGrp.UpdateDateTime = _updateTime;
            if (_createTime != DateTime.MinValue)
                frePprGrp.CreateDateTime = _createTime;
            if (_guid != Guid.Empty)
                frePprGrp.FileHeaderGuid = _guid;
        }
        #endregion

        #region 画面　→　自由帳票グループ振替
        /// <summary>
        /// 画面入力情報自由帳票グループ振替クラス格納
        /// </summary>
        /// <param name="frePprGrTr">自由帳票グループクラス</param>
        private void DispToFreePprGrTr(ref FrePprGrTr frePprGrTr)
        {
            if (frePprGrTr == null)
            {
                // 新規の場合
                frePprGrTr = new FrePprGrTr();
            }
            frePprGrTr.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            frePprGrTr.FreePrtPprGroupCd = (Int32)Group_tComboEditor.SelectedItem.DataValue;
            frePprGrTr.DisplayOrder = FrrPptDispOrderCd_tNedit.GetInt();
            
            frePprGrTr.DisplayName = (string)_frePprSelectDT.Rows[FrePprSelect_Grid.ActiveRow.Index][CT_FREE_PPR_PrtNm];
            frePprGrTr.OutputFormFileName = (string)_frePprSelectDT.Rows[FrePprSelect_Grid.ActiveRow.Index][CT_FREE_PPR_OFrmFilNm];
            frePprGrTr.UserPrtPprIdDerivNo = (int)_frePprSelectDT.Rows[FrePprSelect_Grid.ActiveRow.Index][CT_FREE_PPR_DerivNo];

            frePprGrTr.DisplayName = (string)FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_PrtNm].Value;
            frePprGrTr.OutputFormFileName = (string)FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_OFrmFilNm].Value;
            frePprGrTr.UserPrtPprIdDerivNo = (int)FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_DerivNo].Value;


            if (FrrPptDispOrderCd_tNedit.Tag != null)
                frePprGrTr.TransferCode = (int)(FrrPptDispOrderCd_tNedit.Tag);
            if (_updateTime != DateTime.MinValue)
                frePprGrTr.UpdateDateTime = _updateTime;
            if (_createTime != DateTime.MinValue)
                frePprGrTr.CreateDateTime = _createTime;
            if (_guid != Guid.Empty)
                frePprGrTr.FileHeaderGuid = _guid;
        }
        #endregion

        #region 画面終了処理
        /// <summary>
        /// コントロールの描画を止めて画面を隠します(ちらつき防止)
        /// </summary>
        private void SuspendLayoutHide()
        {
            this.SuspendLayout();
            this.Visible = false;
            this.ResumeLayout();
        }
        #endregion

        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region Control Event

        /// <summary>
        /// Rowが初期化されたときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            string outputFormFileNm = Convert.ToString(e.Row.Cells[CT_FREE_PPR_OFrmFilNm].Text);
            int userDerivNo = Convert.ToInt32(e.Row.Cells[CT_FREE_PPR_DerivNo].Value);
            
            //印字位置設定のキャッシュを取得
            FrePprGrTr frePprGrTr = SFANL08201UA.GetFrePprGrTrCash(_groupCode, outputFormFileNm, userDerivNo);
            
            // 既に存在しているか
            if ((frePprGrTr == null) || (Mode_Label2.Text == UPD_MODE))
            {
                e.Row.CellAppearance.ForeColor = Color.Black;
            }
            else
            {
                e.Row.CellAppearance.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// グリッドが描画されるとき発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_Paint(object sender, PaintEventArgs e)
        {
            // アクティブロウを取得
            if (FrePprSelect_Grid.ActiveRow == null) return;

            string outputFormFileNm = Convert.ToString(FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_OFrmFilNm].Text);
            int userDerivNo = Convert.ToInt32(FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_DerivNo].Value);

            //印字位置設定のキャッシュを取得
            FrePprGrTr frePprGrTr = SFANL08201UA.GetFrePprGrTrCash(_groupCode, outputFormFileNm, userDerivNo);
            
            // 既に存在しているか
            if ((frePprGrTr == null) || (Mode_Label2.Text == UPD_MODE))
            {
                FrePprSelect_Grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            }
            else
            {
                FrePprSelect_Grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
            }   
        }

        /// <summary>
        /// ロウがアクティブになったときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_AfterRowActivate_1(object sender, EventArgs e)
        {
            FrePprSelect_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            SuspendLayoutHide();
        }

        /// <summary>
        /// 自由帳票グループ保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrOk_Button_Click(object sender, EventArgs e)
        {
            // グループ登録処理
            if (RegistGroupData())
            {
                SuspendLayoutHide();
            }
        }

        /// <summary>
        /// 自由帳票グループ振替保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrOk_Button_Click(object sender, EventArgs e)
        {
            // 振替情報登録処理
            if (RegistTranceData())
            {
                SuspendLayoutHide();
            }
        }

        /// <summary>
        /// グリッドがアクティブになったときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_AfterRowActivate(object sender, EventArgs e)
        {
            FrePprSelect_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// グリッド上でキーが押下されたときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if ((this.FrePprSelect_Grid.ActiveRow != null) && (this.FrePprSelect_Grid.ActiveRow.Index == 0))
                        {
                            FrrPptDispOrderCd_tNedit.Focus();
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((this.FrePprSelect_Grid.ActiveRow != null) && (this.FrePprSelect_Grid.ActiveRow.Index == (this.FrePprSelect_Grid.Rows.Count-1)))
                        {
                            TrOk_Button.Focus();
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        SuspendLayoutHide();
                        break;
                    }
            }
        }

        /// <summary>
        /// 表示状態が変化したときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceDlg_VisibleChanged(object sender, EventArgs e)
        {
            //擬似的にモーダルにする
            if (this.Visible)
            {
                this.Owner.Enabled = false;
            }
            else
            {
                this.Owner.Enabled = true;
            }
        }

        /// <summary>
        /// フォームが閉じられるときに発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            // フォームの「×」をクリックされた場合の対応です
            if (this.CanClose == false)
            {
                e.Cancel = true;
                this.SuspendLayoutHide();
                return;
            }
        }

        /// <summary>
        /// フォーム上でキーが押下されたタイミングで発生します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceDlg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }
        #endregion


    }
}