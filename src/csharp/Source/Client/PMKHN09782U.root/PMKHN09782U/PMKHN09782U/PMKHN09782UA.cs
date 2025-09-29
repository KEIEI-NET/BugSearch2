//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー品番パターンマスタUIクラス
// プログラム概要   : メーカー品番パターンマスタ UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メーカー品番パターンマスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカー品番パターンマスタを行います。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
    public partial class PMKHN09782UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region -- Private Members --

        // プロパティ用
        private bool _canNew;
        private bool _canClose;
        private bool _canPrint;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private int LogicalDeleteMode;		      // モード
        private string EnterpriseCd;           // 企業コード

        private HandyMakerGoodsPtrnAcs MakerGoodsPtrnAcs;	    // メーカー品番パターンマスタアクセスクラス
        private Hashtable makerGoodsPtrnTable;	        // メーカー品番パターンマスタテーブル
        private HandyMakerGoodsPtrnWork MakerGoodsPtrnClone;	    // 比較用メーカー品番パターンマスタクローンクラス
        private MakerAcs makerAccess; // 商品データクラス
        private const string CtProgramID = "PMKHN09782U";    // プログラムID

        private const string CtViewTable = "VIEW_TABLE";     // テーブル名

        // 編集モード
        private const string CtInsertMode = "新規モード";
        private const string CtUpdateMode = "更新モード";
        private const string CtDeleteMode = "削除モード";

        private const string CtPtrnNoDisp = "適用しない";
        private const string CtPtrnDisp = "適用する";

        // FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        private const string CtDeleteDate = "削除日";
        private const string CtPtrnNoTitle = "パターンNo.";
        private const string CtMakeCodeTitle = "メーカーCD";
        private const string CtMakeNmTitle = "メーカー";
        private const string CtPtrnDivCdTitle = "パターン適用";
        private const string CtBarCodeLengthTitle = "バーコード桁数";
        private const string CtControlStrTitle = "制御文字列";
        private const string CtGuidTitle = "GUID";

        // Message関連定義
        private const string CtNoInput = "を入力して下さい。";
        private const string CtCheckMessage = "メーカーコードが登録されていません。";
        private const string CtErrReadMsg = "読み込みに失敗しました。";
        private const string CtErrReadForCheckMsg = "メーカー品番パターンマスタ検索に失敗しました。";
        private const string CtErrDprMsg = "このコードは既に使用されています。";
        private const string CtErrMakerAndBarCodeMsg = "同一メーカーコード・バーコード桁数・制御文字列のデータが既に登録されています。";
        private const string CtErrDelMsg = "削除に失敗しました。";
        private const string CtErrUpdtMsg = "登録に失敗しました。";
        private const string CtErrRvvMsg = "復活に失敗しました。";
        private const string CtErr800Msg = "既に他端末より更新されています。";
        private const string CtErr801Msg = "既に他端末より削除されています。";
        private const string CtDelMsg = "データを削除します。" + "\r\n" + "よろしいですか？";
        private const string CtInputCheck = "入力されたパターン№のメーカー品番パターンマスタ情報は既に登録されています。" + "\r\n" + "編集を行いますか？";
        private const string CtDelMessage = "入力されたパターン№のメーカー品番パターンマスタ情報は既に削除されています。";
        private const string CtRenewalMessage = "最新情報を取得しました。";
        private const string CtInputErr = "は入力不正です。";
        private const string CtControlStrErr = "制御文字列は、0,1,9のいずれかで登録して下さい。";
        /// <summary>前回入力メーカーコード</summary>
        private string PrevGoodsMakerCode = string.Empty;
        /// <summary>前回入力メーカー名</summary>
        private string PrevGoodsMakerName = string.Empty;
        /// <summary>メーカーディクショナリー</summary>
        private Dictionary<int, string> GoodsMakerDic = null;

        // _GridIndexバッファ（メインフレーム最小化対応）
        private int IndexBuf;
        
        #endregion

        #region -- Constructor --
        /// <summary>
        /// メーカー品番パターンマスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public PMKHN09782UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 企業コード取得
            this.EnterpriseCd = LoginInfoAcquisition.EnterpriseCode;

            // メーカー品番パターンマスタアクセスクラスインスタンス化
            this.MakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            // 商品データクラスインスタンス化
            makerAccess = new MakerAcs();

            //比較用クローン
            this.MakerGoodsPtrnClone = null;
      
            // プロパティの初期設定
            this._canPrint = false;
            this._canClose = false;
            this._canDelete = true;		                     // 削除機能
            this._canLogicalDeleteDataExtraction = true;	 // 論理削除データ表示機能
            this._canNew = true;		                     // 新規作成機能
            this._canSpecificationSearch = false;	         // 件数指定検索機能
            this._defaultAutoFillToColumn = false;	         // 列サイズ自動調整機能

            this._dataIndex = -1;
            this.LogicalDeleteMode = 0;
            this.makerGoodsPtrnTable   = new Hashtable();

            // _GridIndexバッファ（メインフレーム最小化対応）
            this.IndexBuf = -2;
            // メーカー情報のキャッシュ処理
            GetGoodsMakerInfo();
        }
        #endregion

        #region -- Main --
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09782UA());
        }        
        #endregion

        #region -- Events --
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Properties --
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>新規作成可能設定プロパティ</summary>
        /// <value>新規作成が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }        
        #endregion

        #region -- Public Methods --

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Print()
        {
            // 印刷アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = CtViewTable;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchMakerGoodsPtrn(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(CtDeleteDate, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // パターンNo.
            appearanceTable.Add(CtPtrnNoTitle, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "00000#", Color.Black));
            // メーカーCD
            appearanceTable.Add(CtMakeCodeTitle, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "000#", Color.Black));
            // メーカー
            appearanceTable.Add(CtMakeNmTitle, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // パターン適用
            appearanceTable.Add(CtPtrnDivCdTitle, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // バーコード桁数
            appearanceTable.Add(CtBarCodeLengthTitle, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // 制御文字列
            appearanceTable.Add(CtControlStrTitle, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // GUID
            appearanceTable.Add(CtGuidTitle, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion

        #region -- Private Methods --

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this.IndexBuf = -2;

            // 比較用クローンクリア
            this.MakerGoodsPtrnClone = null;

            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            CtErr800Msg,                        // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            CtErr801Msg,                        // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable makerGoodsPtrnTable = new DataTable(CtViewTable);
            makerGoodsPtrnTable.Columns.Add(CtDeleteDate, typeof(string));

            makerGoodsPtrnTable.Columns.Add(CtPtrnNoTitle, typeof(string));      // パターンNo.
            makerGoodsPtrnTable.Columns.Add(CtMakeCodeTitle, typeof(string));      // メーカーCD
            makerGoodsPtrnTable.Columns.Add(CtMakeNmTitle, typeof(string));     // メーカー
            makerGoodsPtrnTable.Columns.Add(CtPtrnDivCdTitle, typeof(string));     // パターン適用
            makerGoodsPtrnTable.Columns.Add(CtBarCodeLengthTitle, typeof(int));          // バーコード桁数
            makerGoodsPtrnTable.Columns.Add(CtControlStrTitle, typeof(string));        // 制御文字列

            makerGoodsPtrnTable.Columns.Add(CtGuidTitle, typeof(Guid));

            this.Bind_DataSet.Tables.Add(makerGoodsPtrnTable);
        }

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ボタン配置
            int cancelButtonX = this.Cancel_Button.Location.X;
            int okButtonLocationX = this.Ok_Button.Location.X;
            int delbuttonLocationX = this.Revive_Button.Location.X;
            int buttonLocationY = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(cancelButtonX, buttonLocationY);
            this.Ok_Button.Location = new System.Drawing.Point(okButtonLocationX, buttonLocationY);
            this.Revive_Button.Location = new System.Drawing.Point(okButtonLocationX, buttonLocationY);
            this.Delete_Button.Location = new System.Drawing.Point(delbuttonLocationX, buttonLocationY);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._dataIndex < 0)
            {
                // 新規モード
                this.LogicalDeleteMode = -1;

                HandyMakerGoodsPtrnWork newMakerGoodsPtrn = new HandyMakerGoodsPtrnWork();
                
                // メーカー品番パターンマスタオブジェクトを画面に展開
                MakerGoodsPtrnToScreen(newMakerGoodsPtrn);

                // クローン作成
                this.MakerGoodsPtrnClone = newMakerGoodsPtrn.Clone();
                ScreenToMakerGoodsPtrn(ref this.MakerGoodsPtrnClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex][CtGuidTitle];
                HandyMakerGoodsPtrnWork makerGoodsPtrnWork = (HandyMakerGoodsPtrnWork)this.makerGoodsPtrnTable[guid];

                // メーカー品番パターンマスタオブジェクトを画面に展開
                MakerGoodsPtrnToScreen(makerGoodsPtrnWork);

                if (makerGoodsPtrnWork.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.LogicalDeleteMode = 0;

                    // クローン作成
                    this.MakerGoodsPtrnClone = makerGoodsPtrnWork.Clone();
                    ScreenToMakerGoodsPtrn(ref this.MakerGoodsPtrnClone);
                }
                else
                {
                    // 削除モード
                    this.LogicalDeleteMode = 1;
                }
            }
            // _GridIndexバッファ保持（メインフレーム最小化対応）
            this.IndexBuf = this._dataIndex;

            ScreenInputPermissionControl();
        }

        /// <summary>
        /// メーカー品番パターンマスタオブジェクト画面展開処理
        /// </summary>
        /// <param name="makerGoodsPtrn">取得したデータ</param>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタオブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void MakerGoodsPtrnToScreen(HandyMakerGoodsPtrnWork makerGoodsPtrn)
        {
            // メーカー品番パターンNo.
            if (makerGoodsPtrn.MakerGoodsPtrnNo == 0)
            {
                tEdit_DelivererCd.DataText = string.Empty;
            }
            else
            {
                tEdit_DelivererCd.DataText = makerGoodsPtrn.MakerGoodsPtrnNo.ToString().PadLeft(6, '0');
            }
            // メーカー
            tNedit_GoodsMakerCd.SetInt(makerGoodsPtrn.GoodsMakerCd);
            // メーカー名
            uLabel_MakerName.Text = makerGoodsPtrn.MakerName.Trim();
            // パターン適用
            PtrnDivCd_tComboEditor.SelectedIndex = makerGoodsPtrn.MakerGoodsPtrnDivCd;
            // バーコード桁数
            tNedit_BarCodeLength.SetInt(makerGoodsPtrn.BarCodeLength);
            // 制御文字列
            tEdit_ControlStr.Text = makerGoodsPtrn.ControlStr.Trim();
        }

        /// <summary>
        /// 画面情報をメーカー品番パターンマスタクラス格納処理
        /// </summary>
        /// <param name="makerGoodsPtrn">保存するデータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面情報からメーカー品番パターンマスタクラスにデータを格納します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenToMakerGoodsPtrn(ref HandyMakerGoodsPtrnWork makerGoodsPtrn)
        {
            if (makerGoodsPtrn == null)
            {
                // 新規の時
                makerGoodsPtrn = new HandyMakerGoodsPtrnWork();
            }
            // 企業コード
            makerGoodsPtrn.EnterpriseCode = this.EnterpriseCd;
            // 拠点コード
            makerGoodsPtrn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            // メーカー品番パターンNo.
            if (this.tEdit_DelivererCd.DataText != string.Empty)
            {
                makerGoodsPtrn.MakerGoodsPtrnNo = Convert.ToInt32(this.tEdit_DelivererCd.DataText);
            }
            else
            {
                makerGoodsPtrn.MakerGoodsPtrnNo = 0;
            }
            // メーカー
            makerGoodsPtrn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // メーカー
            makerGoodsPtrn.MakerName = this.uLabel_MakerName.Text.TrimEnd();
            // パターン適用
            makerGoodsPtrn.MakerGoodsPtrnDivCd = this.PtrnDivCd_tComboEditor.SelectedIndex;
            // バーコード桁数
            makerGoodsPtrn.BarCodeLength = this.tNedit_BarCodeLength.GetInt();
            // 制御文字列
            makerGoodsPtrn.ControlStr = this.tEdit_ControlStr.DataText.TrimEnd();
            this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.PtrnDivCd_tComboEditor.SelectedIndex = 0;        // パターン適用
            this.tEdit_DelivererCd.Clear();                       // パターンNo.
            this.tNedit_GoodsMakerCd.Clear();                     // メーカーCD
            this.uLabel_MakerName.Text = "";                      // メーカー
            this.tEdit_ControlStr.Clear();                        // バーコード桁数
            this.tNedit_BarCodeLength.Clear();                    // 制御文字列
        }

        /// <summary>
        /// メーカー品番パターンマスタ保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタの保存を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            // 入力チェック
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }
            HandyMakerGoodsPtrnWork makerGoodsPtrnWork = new HandyMakerGoodsPtrnWork();
            // 更新モード
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex][CtGuidTitle];
                makerGoodsPtrnWork = ((HandyMakerGoodsPtrnWork)this.makerGoodsPtrnTable[guid]).Clone();
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (makerGoodsPtrnWork.GoodsMakerCd != this.tNedit_GoodsMakerCd.GetInt() || makerGoodsPtrnWork.BarCodeLength != this.tNedit_BarCodeLength.GetInt() || !this.tEdit_ControlStr.DataText.Trim().Equals(makerGoodsPtrnWork.ControlStr))
            {
                // メーカーコード+バーコード桁数+制御文字列ユニークチェック
                ArrayList retList = null;
                status = this.MakerGoodsPtrnAcs.ReadByMakerAndBarCodeLength(out retList, this.EnterpriseCd, this.tNedit_GoodsMakerCd.GetInt(), this.tNedit_BarCodeLength.GetInt(), this.tEdit_ControlStr.DataText.TrimEnd(), 0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // メーカーコード+バーコード桁数が既に登録済
                            TMsgDisp.Show(
                                this,                               // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                CtProgramID,                        // アセンブリＩＤまたはクラスＩＤ
                                CtErrMakerAndBarCodeMsg,            // 表示するメッセージ
                                0,                                  // ステータス値
                                MessageBoxButtons.OK);              // 表示するボタン
                            this.tNedit_GoodsMakerCd.Focus();
                            this.tNedit_GoodsMakerCd.SelectAll();
                            return result;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            break;
                        }
                    default:
                        {
                            // 登録失敗
                            TMsgDisp.Show(
                                this,                               // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                                CtProgramID,                        // アセンブリＩＤまたはクラスＩＤ
                                this.Text,                          // プログラム名称
                                "SaveProc",                         // 処理名称
                                TMsgDisp.OPE_UPDATE,                // オペレーション
                                CtErrReadForCheckMsg,               // 表示するメッセージ
                                status,                             // ステータス値
                                this.MakerGoodsPtrnAcs,             // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,               // 表示するボタン
                                MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                            CloseForm(DialogResult.Cancel);
                            return result;
                        }
                }
            }

            // 登録データを画面から取得
            ScreenToMakerGoodsPtrn(ref makerGoodsPtrnWork);

            status = this.MakerGoodsPtrnAcs.Write(ref makerGoodsPtrnWork);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        MakerGoodsPtrnToDataSet(makerGoodsPtrnWork.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            CtProgramID, 							// アセンブリＩＤまたはクラスＩＤ
                            CtErrDprMsg, 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        tEdit_DelivererCd.Focus();
                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 		                    // プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            CtErrUpdtMsg, 			// 表示するメッセージ
                            status, 							// ステータス値
                            this.MakerGoodsPtrnAcs,			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // Copyチェック
            WordCopyCheck();
            // パターンNo.
            if (this.tEdit_DelivererCd.DataText == "")
            {
                message = this.PtrnNo_Label.Text + CtNoInput;
                control = this.tEdit_DelivererCd;
                return false;
            }

            // メーカーCD
            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                message = "メーカーコード" + CtNoInput;
                control = this.tNedit_GoodsMakerCd;
                return false;
            }

            // バーコード桁数
            if (this.tNedit_BarCodeLength.GetInt() == 0)
            {
                message = this.BarCodeLength_uLabel.Text + CtNoInput;
                control = this.tNedit_BarCodeLength;
                return false;
            }

            // 制御文字列
            if (this.tEdit_ControlStr.DataText == "")
            {
                message = this.ControlStr_Label.Text + CtNoInput;
                control = this.tEdit_ControlStr;
                return false;
            }

            // 9以降に数字がある場合
            string controlStr = this.tEdit_ControlStr.DataText.Trim();
            if (controlStr.Contains("9") && !"9".Equals(controlStr.Substring(controlStr.Length - 1, 1)))
            {
                message = this.ControlStr_Label.Text + CtInputErr;
                control = this.tEdit_ControlStr;
                return false;
            }

            bool strFlag = false;
            char[] str = this.tEdit_ControlStr.DataText.ToCharArray();
            foreach (char targetChar in str)
            {
                if ((targetChar == '9') || ('1' == targetChar))
                {
                    strFlag = true;
                }
                else
                {
                    // 0,1,9以外の値を入力した場合
                    if (targetChar != '0')
                    {
                        message = CtControlStrErr;
                        control = this.tEdit_ControlStr;
                        return false;
                    }
                }
            }
            // 1又は9が含まれない場合
            if (!strFlag)
            {
                message = this.ControlStr_Label.Text + CtInputErr;
                control = this.tEdit_ControlStr;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Copyチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : Copy文字時に発生します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void WordCopyCheck()
        {
            Regex r = new Regex(@"^[0-9]+$");
            // パターン№
            if (!String.IsNullOrEmpty(this.tEdit_DelivererCd.DataText.Trim()) && !r.IsMatch(this.tEdit_DelivererCd.DataText))
            {
                this.tEdit_DelivererCd.Text = String.Empty;
            }
            // メーカー
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd.DataText.Trim()) && !r.IsMatch(this.tNedit_GoodsMakerCd.DataText))
            {
                this.tNedit_GoodsMakerCd.Text = String.Empty;
            }
            // バーコード桁数
            if (!String.IsNullOrEmpty(this.tNedit_BarCodeLength.DataText.Trim()) && !r.IsMatch(this.tNedit_BarCodeLength.DataText))
            {
                this.tNedit_BarCodeLength.Text = String.Empty;
            }
            // 制御文字列
            if (!String.IsNullOrEmpty(this.tEdit_ControlStr.DataText.Trim()) && !r.IsMatch(this.tEdit_ControlStr.DataText))
            {
                this.tEdit_ControlStr.Text = String.Empty;
            }
        }


        /// <summary>
        /// メーカー品番パターンマスタオブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタオブジェクトの論理削除復活を行います</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[CtViewTable].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex][CtGuidTitle];
            HandyMakerGoodsPtrnWork makerGoodsPtrnWork = ((HandyMakerGoodsPtrnWork)this.makerGoodsPtrnTable[guid]).Clone();

            // メーカー品番パターンマスタが存在していない
            if (makerGoodsPtrnWork == null)
            {
                return -1;
            }

            status = this.MakerGoodsPtrnAcs.Revival(ref makerGoodsPtrnWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        MakerGoodsPtrnToDataSet(makerGoodsPtrnWork.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 		                    // プログラム名称
                            "Revival", 							// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            CtErrRvvMsg, 			// 表示するメッセージ
                            status, 							// ステータス値
                            this.MakerGoodsPtrnAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// メーカー品番パターンマスタオブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタブジェクトの完全削除を行います</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[CtViewTable].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex][CtGuidTitle];
            HandyMakerGoodsPtrnWork makerGoodsPtrn = (HandyMakerGoodsPtrnWork)this.makerGoodsPtrnTable[guid];

            // メーカー品番パターンマスタが存在していない
            if (makerGoodsPtrn == null)
            {
                return -1;
            }

            status = this.MakerGoodsPtrnAcs.Delete(makerGoodsPtrn);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this.makerGoodsPtrnTable.Remove((Guid)this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex][CtGuidTitle]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex].Delete();
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "DeleteProc", 					// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            CtErrDelMsg, 			// 表示するメッセージ
                            status, 							// ステータス値
                            this.MakerGoodsPtrnAcs,			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenInputPermissionControl()
        {
            switch (this.LogicalDeleteMode)
            {
                case -1:
                    {
                        // 新規モード
                        this.Mode_Label.Text = CtInsertMode;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Renewal_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true, false);

                        // 初期フォーカスをセット
                        this.tEdit_DelivererCd.Focus();

                        break;
                    }
                case 1:
                    {
                        // 削除モード
                        this.Mode_Label.Text = CtDeleteMode;

                        // ボタンの表示
                        this.Ok_Button.Visible = false;
                        this.Renewal_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(false, false);

                        // 初期フォーカスをセット
                        this.Delete_Button.Focus();

                        break;
                    }
                default:
                    {
                        // 更新モード
                        this.Mode_Label.Text = CtUpdateMode;

                        // ボタンの表示
                        this.Ok_Button.Visible = true;
                        this.Renewal_Button.Visible = true;
                        this.Cancel_Button.Visible = true;  // 更新できる項目が無いので、[閉じる]ボタンのみ表示
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // コントロールの表示設定
                        ScreenInputPermissionControl(true, true);

                        // 初期フォーカスをセット
                        this.tNedit_GoodsMakerCd.Focus();

                        break;
                    }
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <param name="update">更新フラグ</param>        
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled, bool update)
        {
            this.tEdit_DelivererCd.Enabled = enabled;      // パターンNo.
            this.tNedit_GoodsMakerCd.Enabled = enabled;           // メーカーCD
            this.uButton_GoodsMakerGuide.Enabled = enabled;                 // メーカーボタン 
            this.PtrnDivCd_tComboEditor.Enabled = enabled;             // パターン適用
            this.tNedit_BarCodeLength.Enabled = enabled;          // バーコード桁数
            this.tEdit_ControlStr.Enabled = enabled;              // 制御文字列
            
            // 更新時処理？
            if (update == true)
            {
                this.tEdit_DelivererCd.Enabled = false;      // パターンNo.
            }

            // ちらつき防止の為
            this.Enabled = true;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int SearchMakerGoodsPtrn(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList retList = null;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this.MakerGoodsPtrnAcs.Search(out retList, this.EnterpriseCd);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (HandyMakerGoodsPtrnWork makerGoodsPtrnWork in retList)
                        {
                            if (this.makerGoodsPtrnTable.ContainsKey(makerGoodsPtrnWork.FileHeaderGuid) == false)
                            {
                                MakerGoodsPtrnToDataSet(makerGoodsPtrnWork.Clone(), index);
                                index++;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 			                // プログラム名称
                            "SearchMakerGoodsPtrn", 			    // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            CtErrReadMsg, 		// 表示するメッセージ
                            status, 							// ステータス値
                            this.MakerGoodsPtrnAcs, 		    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            if (retList == null)
            {
                retList = new ArrayList();
            }
            totalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// メーカー品番パターンマスタオブジェクト展開処理
        /// </summary>
        /// <param name="makerGoodsPtrnWork">メーカー品番パターンマスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタクラスをDataSetに格納します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void MakerGoodsPtrnToDataSet(HandyMakerGoodsPtrnWork makerGoodsPtrnWork, int index)
        {
            if ((index < 0) || (index >= this.Bind_DataSet.Tables[CtViewTable].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[CtViewTable].NewRow();
                this.Bind_DataSet.Tables[CtViewTable].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[CtViewTable].Rows.Count - 1;
            }

            // 削除日
            if (makerGoodsPtrnWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtDeleteDate] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtDeleteDate] = makerGoodsPtrnWork.UpdateDateTime;
            }

            // パターンNo.
            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtPtrnNoTitle] = makerGoodsPtrnWork.MakerGoodsPtrnNo.ToString().PadLeft(6,'0');
            // メーカーCD
            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtMakeCodeTitle] = makerGoodsPtrnWork.GoodsMakerCd.ToString().PadLeft(4, '0');

            // メーカー
            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtMakeNmTitle] = makerGoodsPtrnWork.MakerName;

            // パターン適用
            string makerGoodsPtrn = string.Empty;
            if (makerGoodsPtrnWork.MakerGoodsPtrnDivCd == 0)
            {
                // 適用しない
                makerGoodsPtrn = CtPtrnDisp;
            }
            else
            {
                // 適用する
                makerGoodsPtrn = CtPtrnNoDisp;
            }

            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtPtrnDivCdTitle] = makerGoodsPtrn;

            // バーコード桁数
            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtBarCodeLengthTitle] = makerGoodsPtrnWork.BarCodeLength;
            // 制御文字列
            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtControlStrTitle] = makerGoodsPtrnWork.ControlStr.TrimEnd();

            // GUID
            this.Bind_DataSet.Tables[CtViewTable].Rows[index][CtGuidTitle] = makerGoodsPtrnWork.FileHeaderGuid;

            if (this.makerGoodsPtrnTable.ContainsKey(makerGoodsPtrnWork.FileHeaderGuid) == true)
            {
                this.makerGoodsPtrnTable.Remove(makerGoodsPtrnWork.FileHeaderGuid);
            }
            this.makerGoodsPtrnTable.Add(makerGoodsPtrnWork.FileHeaderGuid, makerGoodsPtrnWork);

        }

        /// <summary>
        /// メーカー品番パターンマスタオブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタオブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[CtViewTable].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[CtViewTable].Rows[this._dataIndex][CtGuidTitle];
            HandyMakerGoodsPtrnWork makerGoodsPtrnWork = ((HandyMakerGoodsPtrnWork)this.makerGoodsPtrnTable[guid]).Clone();

            // メーカー品番パターンマスタが存在していない
            if (makerGoodsPtrnWork == null)
            {
                return -1;
            }

            status = this.MakerGoodsPtrnAcs.LogicalDelete(ref makerGoodsPtrnWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        MakerGoodsPtrnToDataSet(makerGoodsPtrnWork.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            CtErrDelMsg, 			// 表示するメッセージ
                            status, 							// ステータス値
                            this.MakerGoodsPtrnAcs,			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }
            return status;
        }

        #endregion

        #region -- Control Event --

        /// <summary>
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面構築
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            if (!SaveProc())
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == CtInsertMode)
            {
                ScreenClear();

                // 新規モード
                this.LogicalDeleteMode = -1;

                HandyMakerGoodsPtrnWork newMakerGoodsPtrnWork = new HandyMakerGoodsPtrnWork();

                // メーカー品番パターンマスタオブジェクトを画面に展開
                MakerGoodsPtrnToScreen(newMakerGoodsPtrnWork);

                // クローン作成
                this.MakerGoodsPtrnClone = newMakerGoodsPtrnWork.Clone();
                ScreenToMakerGoodsPtrn(ref this.MakerGoodsPtrnClone);

                // _GridIndexバッファ保持
                this.IndexBuf = this._dataIndex;

                ScreenInputPermissionControl();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndexバッファ初期化（メインフレーム最小化対応）
                this.IndexBuf = -2;

                if (this._canClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != CtDeleteMode)
            {
                // 現在の画面情報を取得する
                HandyMakerGoodsPtrnWork compareMakerGoodsPtrn = new HandyMakerGoodsPtrnWork();
                compareMakerGoodsPtrn = this.MakerGoodsPtrnClone.Clone();
                ScreenToMakerGoodsPtrn(ref compareMakerGoodsPtrn);

                // 最初に取得した画面情報と比較
                if (!(this.MakerGoodsPtrnClone.Equals(compareMakerGoodsPtrn)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                        null, 								// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.YesNoCancel);	    // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                this.Cancel_Button.Focus();
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this.IndexBuf = -2;

            if (this._canClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// tRetKeyControl イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Returnキーが押されたときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_DelivererCd":
                    if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = tEdit_DelivererCd;
                        }
                    }
                    break;
                case "tNedit_GoodsMakerCd":
                    {
                        int goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                        if (goodsMakerCd != 0)
                        {
                            if (int.Parse(PrevGoodsMakerCode.Trim()) != goodsMakerCd)
                            {
                                string goodsMakerName = this.GetGoodsMakerName(goodsMakerCd);

                                #region < 画面表示処理 >

                                if (!string.IsNullOrEmpty(goodsMakerName))
                                {
                                    #region -- 取得データ展開 --
                                    // メーカー情報画面表示
                                    this.tNedit_GoodsMakerCd.SetInt(goodsMakerCd);
                                    this.uLabel_MakerName.Text = goodsMakerName;
                                    if (!e.ShiftKey)
                                    {
                                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                        {
                                            e.NextCtrl = PtrnDivCd_tComboEditor;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        CtProgramID,
                                        CtCheckMessage,
                                        -1,
                                        MessageBoxButtons.OK);

                                    if (!string.IsNullOrEmpty(this.PrevGoodsMakerCode))
                                    {
                                        this.tNedit_GoodsMakerCd.SetInt(int.Parse(this.PrevGoodsMakerCode));
                                    }
                                    else
                                    {
                                        this.tNedit_GoodsMakerCd.Clear();
                                    }

                                    this.tNedit_GoodsMakerCd.SelectAll();
                                    // カーソル制御
                                    e.NextCtrl = e.PrevCtrl;
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                if (!e.ShiftKey)
                                {
                                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.PtrnDivCd_tComboEditor;
                                    }
                                }
                            }
                            
                        }
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            this.uLabel_MakerName.Text = string.Empty;
                        }
                        this.PrevGoodsMakerName = this.uLabel_MakerName.Text.Trim();

                        break;
                    }
                case "Renewal_Button":
                    if (e.Key == Keys.Left)
                    {
                        e.NextCtrl = null;
                    }
                    break;
            }
            // Copyチェック
            WordCopyCheck();
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モード変更ときに発生します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            // パターンNo.
            string makerGoodsPtrnNo = tEdit_DelivererCd.DataText.Trim().PadLeft(6,'0');

            for (int i = 0; i < this.Bind_DataSet.Tables[CtViewTable].Rows.Count; i++)
            {
                // データセットと比較
                string dsMakerGoodsPtrnNo = (string)this.Bind_DataSet.Tables[CtViewTable].Rows[i][CtPtrnNoTitle];
                if (makerGoodsPtrnNo == dsMakerGoodsPtrnNo)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[CtViewTable].Rows[i][CtDeleteDate] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CtProgramID,						    // アセンブリＩＤまたはクラスＩＤ
                          CtDelMessage, 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // パターンNo.のクリア
                        tEdit_DelivererCd.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        CtProgramID,                            // アセンブリＩＤまたはクラスＩＤ
                        CtInputCheck,   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // パターンNo.のクリア
                                tEdit_DelivererCd.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 復活ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this.IndexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 完全削除ボタンクリック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                CtProgramID, 						// アセンブリＩＤまたはクラスＩＤ
                CtDelMsg, 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel, 		// 表示するボタン
                MessageBoxDefaultButton.Button2);	// 初期表示ボタン

            if (result == DialogResult.OK)
            {
                if (DeleteProc() != 0)
                {
                    return;
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this.IndexBuf = -2;

            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Form.Load イベント()
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームがロードされた時に発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09782UA_Load(object sender, EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Cancel_Button.ImageList = imageList24;   
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;         // 保存ボタン
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;    // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	 // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	 // 完全削除ボタン

            this.uButton_GoodsMakerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期化
            ScreenInitialSetting();

        }

        /// <summary>
        /// Form.Closing イベント(PMKHN09782UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09782UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this.MakerGoodsPtrnClone = null;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this.IndexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
            if (this._canClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント(PMKHN09782UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09782UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // _GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this.IndexBuf == this._dataIndex)
            {
                return;
            }

            // ちらつき防止の為
            this.Enabled = false;

            this.Initial_Timer.Enabled = true;

            // 画面クリア
            ScreenClear();
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 最新情報ボタンクリックときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // メーカー
            GetGoodsMakerInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          CtProgramID,						    // アセンブリＩＤまたはクラスＩＤ
                          CtRenewalMessage, 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// メーカー情報のキャッシュ処理。
        /// </summary>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        /// <remarks>
        /// <br>Note       : メーカー情報をキャッシュします。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int GetGoodsMakerInfo()
        {
            ArrayList makerList = new ArrayList();
            int Status = this.makerAccess.SearchAll(out makerList, this.EnterpriseCd);

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.GoodsMakerDic = new Dictionary<int, string>();
                foreach (MakerUMnt makerUMntWork in makerList)
                {
                    if (makerUMntWork.LogicalDeleteCode == 0 && !this.GoodsMakerDic.ContainsKey(makerUMntWork.GoodsMakerCd))
                    {
                        this.GoodsMakerDic.Add(makerUMntWork.GoodsMakerCd, makerUMntWork.MakerName.Trim());
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// メーカー名の取得処理。
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private string GetGoodsMakerName(int goodsMakerCode)
        {
            string goodsMakerName = string.Empty;
            if (goodsMakerCode == 0) return goodsMakerName;

            if (this.GoodsMakerDic.ContainsKey(goodsMakerCode))
            {
                goodsMakerName = this.GoodsMakerDic[goodsMakerCode];
            }
            return goodsMakerName;
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;
            int status = makerAccess.ExecuteGuid(this.EnterpriseCd, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                uLabel_MakerName.Text = makerUMnt.MakerName.Trim();

                // 編集された親商品情報を編集前データとして保持
                this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                this.PrevGoodsMakerName = this.uLabel_MakerName.Text.Trim();

                // 次フォーカス
                PtrnDivCd_tComboEditor.Focus();
            }
        }
        #endregion
    }
}