//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 結合マスタ
// プログラム概要   : 結合マスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 作 成 日  2008/07/28  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/02/12  修正内容 : 速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 削除商品の商品情報を非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/07/16  修正内容 : Mantis【13573】【13574】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/10/30  修正内容 : Mantis【14536】
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/01/05  修正内容 : Mantis【14864】
//                                : マスタ保存直後新規で保存した親品番を入力しても子品番が表示されない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/06/08  修正内容 : 障害・改良対応7月リリース分
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/08/03  修正内容 : 起動速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 修 正 日  2013/10/08  修正内容 : 仕掛一覧 №2094対応
//                                : 原単価の取得に掛率マスタの設定を含める
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉超
// 作 成 日  2013/12/04  修正内容 : 明細の項目位置を保持するように対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉超 FOR Redmine#41737
// 作 成 日  2013/12/25  修正内容 : 項目位置変更後、保存（新規、修正共に）
//                                  操作をすると元に戻る。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gezh
// 作 成 日  2014/01/21  修正内容 : Redmine#41447既存障害の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources; // ADD 劉超　2013/12/04 FOR Redmine#41447

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 結合フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : PM.NS用に変更する(変更点が多すぎるため変更コメントは残しません)        </br>
    /// <br>Programmer : 30415 柴田 倫幸                                                        </br>
    /// <br>Date       : 2008/07/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 速度アップ対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009/02.12</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2010/06/08 譚洪</br>
    /// <br>           : 障害・改良対応7月リリース分</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2010/08/03 鈴木 正臣</br>
    /// <br>           : 起動速度アップ対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2013/12/04 劉超</br>
    /// <br>           : 明細の項目位置を保持するように対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2013/12/25 劉超</br>
    /// <br>           : 項目位置変更後、保存（新規、修正共に）操作をすると元に戻るに対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2014/01/21 gezh</br>
    /// <br>           : Redmine#41447既存障害の修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    #region DEL 2010/06/08
    // ---- DEL 2010/06/08 ------>>>>>
    //public partial class PMKEN09074UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    //{
    //    #region ◆Constractor

    //    /// <summary>
    //    /// 結合フォームクラスコンストラクタ
    //    /// </summary>
    //    /// <remarks>
    //    /// </remarks>
    //    public PMKEN09074UA()
    //    {
    //        InitializeComponent();

    //        // 結合マスタアクセスクラスインスタンス化
    //        _joinPartsUAcs = new JoinPartsUAcs();
    //        // ユーザーコントロールクラスインスタンス化
    //        _userControl = new PMKEN09074UB(_joinPartsUAcs);  // ADD 2008/10/17 不具合対応[6559]

    //        // プロパティ初期値設定
    //        this._canPrint = false;
    //        this._canNew = true;
    //        this._canDelete = true;
    //        this._canLogicalDeleteDataExtraction = false;
    //        this._canClose = true;		                   // デフォルト:true固定
    //        this._defaultAutoFillToColumn = false;
    //        this._canSpecificationSearch = false;

    //        // 企業コードを取得する
    //        this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

    //        // 変数初期化
    //        this._dataIndex = -1;
    //        this._changeFlg = false;
    //        this._indexBuf = -2;

    //        // Eventの設定
    //        this._userControl.GridKeyDownTopRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownTopRow);
    //        this._userControl.GridKeyDownButtomRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownButtomRow);
    //    }

    //    #endregion

    //    #region ◆Public Members

    //    /// <summary>クローズ可能・不可能プロパティ</summary>
    //    /// <value>クローズできるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _canClose;

    //    /// <summary>デリート可能・不可能プロパティ</summary>
    //    /// <value>デリートできるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _canDelete;

    //    /// <summary>論理削除可能・不可能プロパティ</summary>
    //    /// <value>論理削除できるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _canLogicalDeleteDataExtraction;

    //    /// <summary>登録可能・不可能プロパティ</summary>
    //    /// <value>登録できるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _canNew;

    //    /// <summary>印刷可能・不可能プロパティ</summary>
    //    /// <value>印刷できるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _canPrint;

    //    /// <summary>件数指定抽出可能・不可能プロパティ</summary>
    //    /// <value>件数指定抽出できるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _canSpecificationSearch;

    //    /// <summary>データインデックスプロパティ</summary>
    //    /// <value>選択データのインデックス</value>
    //    /// <remarks></remarks>
    //    public int _dataIndex;

    //    /// <summary>自動サイズ調整</summary>
    //    /// <value>自動サイズ調整できるかの判定</value>
    //    /// <remarks></remarks>
    //    public bool _defaultAutoFillToColumn;

    //    #endregion

    //    # region ◆Private Members

    //    /// <summary>結合マスタ（ユーザー登録）アクセス</summary>
    //    private readonly JoinPartsUAcs _joinPartsUAcs;  // ADD 2008/10/17 不具合対応[6559] readonly
    //    /// <summary>結合先情報のユーザーコントロール</summary>
    //    private readonly PMKEN09074UB _userControl;     // ADD 2008/10/17 不具合対応[6559] readonly
    //    /// <summary>企業コード</summary>
    //    private readonly string _enterpriseCode;        // ADD 2008/10/17 不具合対応[6559] readonly

    //    private static JoinPartsU _joinPartsUClone;

    //    private int _indexBuf;
    //    private bool _changeFlg;

    //    private ImageList _imageList24;
    //    private ImageList _imageList16;

    //    // 編集モード
    //    private const string INSERT_MODE = "新規モード";
    //    private const string REFER_MODE  = "参照モード";
    //    private const string UPDATE_MODE = "更新モード";
    //    private const string DELETE_MODE = "削除モード";

    //    private const string PG_ID = "PMKEN09074U";
    //    private const string PG_NM = "結合マスタ";

    //    // 編集前データ保持
    //    private int _prevParentMakerCode;
    //    private string _prevParentGoodsCode;

    //    # endregion

    //    # region ◆Events
    //    /// <summary>
    //    /// 画面非表示イベント
    //    /// </summary>
    //    /// <remarks>
    //    /// 画面が非表示状態になった際に発生します。
    //    /// </remarks>
    //    public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

    //    # endregion

    //    # region ◆Main
    //    /// <summary>
    //    /// アプリケーションのメイン エントリ ポイントです。
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        System.Windows.Forms.Application.Run(new PMKEN09074UA());
    //    }
    //    # endregion

    //    # region ◆Properties

    //    /// <summary>画面終了設定プロパティ</summary>
    //    /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
    //    /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
    //    public bool CanClose
    //    {
    //        get { return _canClose; }
    //        set { _canClose = value; }
    //    }

    //    /// <summary>削除可能設定プロパティ</summary>
    //    /// <value>削除が可能かどうかの設定を取得します。</value>
    //    public bool CanDelete
    //    {
    //        get { return _canDelete; }
    //        set { _canDelete = value; }
    //    }

    //    /// <summary>
    //    /// 論理削除データの抽出が可能かどうかの設定を取得します。
    //    /// </summary>
    //    public bool CanLogicalDeleteDataExtraction
    //    {
    //        get { return _canLogicalDeleteDataExtraction; }
    //    }

    //    /// <summary>新規登録可能設定プロパティ</summary>
    //    /// <value>新規登録が可能かどうかの設定を取得します。</value>
    //    public bool CanNew
    //    {
    //        get { return _canNew; }
    //    }

    //    /// <summary>
    //    /// 印刷可能かどうかの設定を取得します。
    //    /// </summary>
    //    public bool CanPrint
    //    {
    //        get { return _canPrint; }
    //    }

    //    /// <summary>件数指定抽出可能設定プロパティ</summary>
    //    /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
    //    public bool CanSpecificationSearch
    //    {
    //        get { return _canSpecificationSearch; }
    //    }

    //    /// <summary>
    //    /// データセットの選択データインデックスを取得または設定します。
    //    /// </summary>
    //    public int DataIndex
    //    {
    //        get { return _dataIndex; }
    //        set { _dataIndex = value; }
    //    }

    //    /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
    //    /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
    //    public bool DefaultAutoFillToColumn
    //    {
    //        get { return _defaultAutoFillToColumn; }
    //        set { _defaultAutoFillToColumn = value; }
    //    }

    //    // ADD 2008/10/17 不具合対応[6559]---------->>>>>
        
    //    /// <summary>
    //    /// ログインユーザーを取得します。
    //    /// </summary>
    //    /// <value>ログインユーザー</value>
    //    private Employee LoginWorker
    //    {
    //        get { return _joinPartsUAcs.LoginWorker; }
    //    }

    //    /// <summary>
    //    /// 自拠点コードを取得します。
    //    /// </summary>
    //    /// <value>自拠点コード</value>
    //    private string OwnSectionCode
    //    {
    //        get { return _joinPartsUAcs.OwnSectionCode; }
    //    }
    //    // ADD 2008/10/17 不具合対応[6559]----------<<<<<

    //    # endregion

    //    # region ◆Public Methods

    //    /// <summary>
    //    /// バインドデータセット取得処理
    //    /// </summary>
    //    /// <param name="bindDataSet">グリッドリッド用データセット</param>
    //    /// <param name="tableName">テーブル名称</param>
    //    /// <remarks>
    //    /// </remarks>
    //    public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
    //    {
    //        bindDataSet = this._joinPartsUAcs.JoinPartsUDataSet;
    //        tableName = JoinPartsUAcs.JOINPARTSU_TABLE;
    //    }

    //    /// <summary>
    //    ///	データ検索処理 
    //    /// </summary>
    //    /// <param name="totalCount">全該当件数</param>
    //    /// <param name="readCount">抽出対象件数</param>
    //    /// <returns>ステータス</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    public int Search(ref int totalCount, int readCount)
    //    {
    //        int status = 0;

    //        if (readCount == 0)
    //        {
    //            status = this._joinPartsUAcs.SearchAll(this._enterpriseCode, ref totalCount);
    //        }

    //        switch (status)
    //        {
    //            // 全件取得メソッドの結果が"正常終了"のとき
    //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
    //                {
    //                    break;
    //                }
    //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
    //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
    //                {
    //                    status = 0;
    //                    break;
    //                }
    //            default:
    //                {
    //                    TMsgDisp.Show(
    //                        this, 									// 親ウィンドウフォーム
    //                        emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
    //                        PG_ID, 			        				// アセンブリＩＤまたはクラスＩＤ
    //                        PG_NM,            						// プログラム名称
    //                        "Search", 								// 処理名称
    //                        TMsgDisp.OPE_GET, 						// オペレーション
    //                        "読み込みに失敗しました。",    			// 表示するメッセージ
    //                        status, 								// ステータス値
    //                        this._joinPartsUAcs,      				// エラーが発生したオブジェクト
    //                        MessageBoxButtons.OK, 					// 表示するボタン
    //                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン
    //                    break;
    //                }
    //        }

    //        return status;
    //    }

    //    /// <summary>
    //    ///	ネクストデータ検索処理(未実装)
    //    /// </summary>
    //    /// <param name="readCount">抽出対象件数</param>
    //    /// <returns>ステータス</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    public int SearchNext(int readCount)
    //    {
    //        //未実装
    //        return 9;
    //    }

    //    /// <summary>
    //    ///	データ削除処理(論理削除)
    //    /// </summary>
    //    /// <returns>ステータス</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    public int Delete()
    //    {
    //        #region < 物理削除データ準備処理 >

    //        int status = 0;
    //        JoinPartsU joinPartsU;
    //        List<JoinPartsU> delDataList = new List<JoinPartsU>();

    //        // 結合元メーカーコードと結合元品番でフィルタをかけ、結合先商品情報を取得する
    //        int parentGoodsMakerCd = (int)this._joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.PARENTGOODSMAKERCD_TITLE];
    //        string parentGoodsNo = (string)this._joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.PARENTGOODSNO_TITLE];

    //        this._joinPartsUAcs.ChildGoodsInfoDataSet.Tables[JoinPartsUAcs.CHILDGOODSINFO_TABLE].DefaultView.RowFilter = JoinPartsUAcs.PARENTGOODSMAKERCD_TITLE + " = '" + parentGoodsMakerCd + "' AND " +
    //                                                                                                                 JoinPartsUAcs.PARENTGOODSNO_TITLE + " = '" + parentGoodsNo + "'";

    //        int cnt = this._joinPartsUAcs.ChildGoodsInfoDataSet.Tables[JoinPartsUAcs.CHILDGOODSINFO_TABLE].DefaultView.Count;

    //        for (int i = 0; i < cnt; i++)
    //        {
    //            joinPartsU = new JoinPartsU();
    //            this.GetGridData(ref joinPartsU);

    //            joinPartsU.JoinDestMakerCd = (int)this._joinPartsUAcs.ChildGoodsInfoDataSet.Tables[JoinPartsUAcs.CHILDGOODSINFO_TABLE].DefaultView[i][JoinPartsUAcs.SUBGOODSMAKERCD_TITLE];
    //            joinPartsU.JoinDestPartsNo = (string)this._joinPartsUAcs.ChildGoodsInfoDataSet.Tables[JoinPartsUAcs.CHILDGOODSINFO_TABLE].DefaultView[i][JoinPartsUAcs.SUBGOODSNO_TITLE];

    //            delDataList.Add(joinPartsU);
    //        }
    //        #endregion

    //        #region < 物理削除処理 >

    //        status = this._joinPartsUAcs.Delete(delDataList);
    //        #endregion

    //        #region < 物理削除後処理 >

    //        switch (status)
    //        {
    //            #region -- 正常終了 --
    //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
    //                {
    //                    break;
    //                }
    //            #endregion

    //            #region -- 排他制御 --
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
    //                {
    //                    ExclusiveTransaction(status, true);
    //                    return status;
    //                }
    //            #endregion

    //            #region -- 物理削除失敗 --
    //            default:
    //                {
    //                    // 物理削除失敗
    //                    TMsgDisp.Show(
    //                        this, 									// 親ウィンドウフォーム
    //                        emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
    //                        PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
    //                        PG_NM,						            // プログラム名称
    //                        "Delete", 								// 処理名称
    //                        TMsgDisp.OPE_HIDE, 						// オペレーション
    //                        "完全削除に失敗しました。", 			// 表示するメッセージ
    //                        status, 								// ステータス値
    //                        this._joinPartsUAcs, 					    // エラーが発生したオブジェクト
    //                        MessageBoxButtons.OK, 					// 表示するボタン
    //                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン

    //                    CloseForm(DialogResult.Cancel);
    //                    return status;
    //                }
    //            #endregion
    //        }
    //        #endregion
            
    //        return status;
    //    }

    //    /// <summary>
    //    ///	印刷処理
    //    /// </summary>
    //    /// <returns>ステータス</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    public int Print()
    //    {
    //        return 0;
    //    }

    //    /// <summary>
    //    ///	グリッド列外観情報取得処理
    //    /// </summary>
    //    /// <returns>グリッド列外観情報格納Hashtable</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    public Hashtable GetAppearanceTable()
    //    {
    //        Hashtable appearanceTable = new Hashtable();

    //        // グリッド列設定
    //        // 削除日
    //        appearanceTable.Add(JoinPartsUAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
    //        // 論理削除区分
    //        appearanceTable.Add(JoinPartsUAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
    //        // 複数
    //        appearanceTable.Add(JoinPartsUAcs.CHILDPLURALGOODS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 結合元品番
    //        appearanceTable.Add(JoinPartsUAcs.PARENTGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 結合元商品名称
    //        appearanceTable.Add(JoinPartsUAcs.PARENTGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 結合元メーカーコード
    //        appearanceTable.Add(JoinPartsUAcs.PARENTGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
    //        // 結合元メーカー名称
    //        appearanceTable.Add(JoinPartsUAcs.PARENTGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 結合先品番
    //        appearanceTable.Add(JoinPartsUAcs.SUBGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 結合先商品名称
    //        appearanceTable.Add(JoinPartsUAcs.SUBGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 結合先メーカーコード
    //        appearanceTable.Add(JoinPartsUAcs.SUBGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
    //        // 結合先メーカー名称
    //        appearanceTable.Add(JoinPartsUAcs.SUBGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // QTY
    //        appearanceTable.Add(JoinPartsUAcs.QTY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
    //        // 結合規格・特記事項
    //        appearanceTable.Add(JoinPartsUAcs.SETSPECIALNOTE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 提供日付
    //        //appearanceTable.Add(JoinPartsUAcs.OFFERDATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
    //        // 表示順位
    //        appearanceTable.Add(JoinPartsUAcs.DISPLAYORDER_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
    //        // GUID
    //        appearanceTable.Add(JoinPartsUAcs.FILEHEADERGUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

    //        return appearanceTable;
    //    }

    //    #endregion

    //    #region ◆Private Methods

    //    /// <summary>
    //    ///	画面初期設定処理
    //    /// </summary>
    //    /// <remarks>
    //    /// </remarks>
    //    private void ScreenInitialSetting()
    //    {
    //        // アイコン設定
    //        this._imageList24 = IconResourceManagement.ImageList24;
    //        this._imageList16 = IconResourceManagement.ImageList16;

    //        // 処理ボタンのアイコン設定
    //        this.Ok_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.SAVE];         // 保存ボタン
    //        this.Cancel_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.CLOSE];    // 閉じるボタン
    //        this.Revive_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.REVIVAL];  // 復活ボタン
    //        this.Delete_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.DELETE];   // 完全削除ボタン
    //    }

    //    /// <summary>
    //    ///	画面クリア処理
    //    /// </summary>
    //    /// <remarks>
    //    ///</remarks>
    //    private void ScreenClear()
    //    {
    //        this.tNedit_GoodsMakerCd.Clear();
    //        this.ParentMakerName_tEdit.Clear();
    //        this.tEdit_GoodsNo.Clear();
    //        this.ParentGoodsName_tEdit.Clear();

    //        this._userControl.ClearGoodsSetDataTable(); // ADD 2008/10/24 不具合対応[7009]
    //    }

    //    /// <summary>
    //    /// フォームクローズ処理
    //    /// </summary>
    //    /// <param name="dialogResult">ダイアログ結果</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void CloseForm(DialogResult dialogResult)
    //    {
    //        // 画面非表示イベント
    //        if (UnDisplaying != null)
    //        {
    //            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
    //            UnDisplaying(this, me);
    //        }

    //        this.DialogResult = dialogResult;

    //        this._indexBuf = -2;

    //        // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
    //        // フォームを非表示化する。
    //        if (this._canClose == true)
    //        {
    //            this.Close();
    //        }
    //        else
    //        {
    //            this.Hide();
    //        }
    //    }

    //    // ADD 2008/11/06 不具合対応[7095] 既に登録済みの場合、更新モード ---------->>>>>
    //    /// <summary>
    //    /// 全データ格納データセット（DataView）より、該当するレコードのインデックスを取得します。
    //    /// </summary>
    //    /// <param name="joinSourceGoodsNo">結合元品番</param>
    //    /// <param name="joinSourceMakerCode">結合元メーカーコード</param>
    //    /// <returns>該当するインデックス</returns>
    //    private int FindIndexOfDataView(
    //        string joinSourceGoodsNo,
    //        int joinSourceMakerCode
    //    )
    //    {
    //        const int GOODS_NO_CLM_IDX = 3; // 結合元品番のカラムインデックス
    //        const int MAKER_CD_CLM_IDX = 5; // 結合元メーカーコードのカラムインデックス

    //        DataView dataView = _joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView;
            
    //        for (int index = 0; index < dataView.Count; index++)
    //        {
    //            string goodsNo = dataView[index][GOODS_NO_CLM_IDX].ToString();
    //            string makerCd = dataView[index][MAKER_CD_CLM_IDX].ToString();
    //            System.Diagnostics.Debug.WriteLine("ビューの元品番：" + goodsNo + " ビューの元メーカー：" + makerCd);

    //            if (goodsNo.Equals(joinSourceGoodsNo) && makerCd.Equals(joinSourceMakerCode.ToString()))
    //            {
    //                return index;
    //            }
    //        }
    //        return -1;
    //    }
    //    // ADD 2008/11/06 不具合対応[7095] 既に登録済みの場合、更新モード ----------<<<<<

    //    /// <summary>
    //    ///	画面再構築処理
    //    /// </summary>
    //    /// <remarks>
    //    /// </remarks>
    //    private void ScreenReconstruction()
    //    {
    //        try
    //        {
    //            this.Cursor = Cursors.WaitCursor;

    //            #region < 結合Grid選択チェック >
    //            if (this.DataIndex < 0)
    //            {
    //                #region -- Grid未選択 --    // MEMO:[新規]

    //                // 結合先商品情報表示データテーブルをクリア
    //                this._userControl.ClearGoodsSetDataTable();

    //                // 削除ボタンの使用不可
    //                this._userControl.DeleteBtnFlag = true;

    //                // グリッド初期設定処理の呼び出し
    //                this._userControl.SetJoinPartsUGrid();

    //                // グリッドの表示を先頭に戻す
    //                this._userControl.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
    //                this._userControl.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

    //                //新規登録画面
    //                ScreenAccordingToMode(0);

    //                #endregion
    //            }
    //            else
    //            {
    //                #region -- Grid選択済 --    // MEMO:[修正]

    //                // 結合先商品情報表示データテーブルをクリア
    //                this._userControl.ClearGoodsSetDataTable();

    //                // 削除ボタンの使用不可
    //                // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>
    //                //this._userControl.DeleteBtnFlag = false;
    //                this._userControl.DeleteBtnFlag = true;
    //                // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<

    //                // グリッド初期設定処理の呼び出し
    //                this._userControl.SetJoinPartsUGrid();

    //                // グリッドの表示を先頭に戻す
    //                this._userControl.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
    //                this._userControl.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

    //                System.Windows.Forms.Application.DoEvents();

    //                // 画面表示切替のため論理削除区分を取得
    //                int logicalDeleteCode = (int)_joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.LOGICALDELETE_TITLE];
    //                // 商品コードでテーブルにフィルタをかけるために保持する
    //                int parentGoodsMakerCd = (int)_joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.PARENTGOODSMAKERCD_TITLE];
    //                string parentGoodsNo = (string)_joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.PARENTGOODSNO_TITLE];

    //                #region < データ画面展開処理 >

    //                List<GoodsUnitData> parentGoodsUnitDataList;
    //                List<GoodsUnitData> childGoodsUnitDataList;
    //                this.GetGoodSetData(1, parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);

    //                // 2009.03.26 30413 犬飼 商品マスタに無い場合は、結合マスタから取得するため不要 >>>>>>START
    //                //// 結合元商品が存在しない
    //                //if (parentGoodsUnitDataList.Count == 0)
    //                //{
    //                //    TMsgDisp.Show(
    //                //        this, 								// 親ウィンドウフォーム
    //                //        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
    //                //        PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
    //                //        "結合元商品が存在しません。",       // 表示するメッセージ
    //                //        0, 									// ステータス値
    //                //        MessageBoxButtons.OK);				// 表示するボタン

    //                //    CloseForm(DialogResult.Cancel);
    //                //    return;
    //                //}
    //                // 2009.03.26 30413 犬飼 商品マスタに無い場合は、結合マスタから取得するため不要 <<<<<<END
                
    //                #region -- 親商品情報を展開 --
    //                this.DisplayScreen(parentGoodsUnitDataList[0]);
    //                #endregion

    //                #region -- 結合商品情報を展開 --
    //                childGoodsUnitDataList.Sort(CompareGoodsUnitData);
    //                for (int i = 0; i < childGoodsUnitDataList.Count; i++)
    //                {
    //                    DisplayScreen(i, childGoodsUnitDataList[i]);
    //                }
    //                #endregion

    //                #endregion

    //                #region < 画面表示設定処理 >
    //                if (logicalDeleteCode == 0)
    //                {
    //                    // 更新画面
    //                    ScreenAccordingToMode(1);
    //                }
    //                else
    //                {
    //                    // フォーカスをボタンにセット
    //                    this.Delete_Button.Focus();

    //                    // 削除画面
    //                    ScreenAccordingToMode(2);
    //                }
    //                #endregion

    //                this._indexBuf = this._dataIndex;

    //                #endregion
    //            }
    //            #endregion

    //            #region < 変更チェック用クローン作成 >
    //            // 画面変更されたかチェックをするためクローン作成
    //            _joinPartsUClone = new JoinPartsU();
    //            this.DispToJoinPartsU(ref _joinPartsUClone);
    //            #endregion

    //            #region < フォーカス設定・全選択 >
    //            Control focusControl = null;
    //            if (focusControl != null)
    //            {
    //                focusControl.Focus();
    //                if (focusControl is TEdit) ((TEdit)focusControl).SelectAll();
    //                if (focusControl is TNedit) ((TNedit)focusControl).SelectAll();
    //            }
    //            #endregion
    //        }
    //        finally
    //        {
    //            this.Cursor = Cursors.Default;
    //        }
    //    }

    //    /// <summary>
    //    ///	モード別画面構築処理
    //    /// </summary>
    //    /// <remarks>
    //    /// </remarks>
    //    private void ScreenAccordingToMode(int mode)
    //    {
    //        switch (mode)
    //        {
    //            case 0:

    //                #region ■新規登録

    //                this.Mode_Label.Text = INSERT_MODE;

    //                this.Ok_Button.Visible = true;
    //                this.Cancel_Button.Visible = true;
    //                this.Delete_Button.Visible = false;
    //                this.Revive_Button.Visible = false;

    //                ScreenInputPermissionControl(true);
    //                this.tEdit_GoodsNo.Focus();

    //                break;
    //                #endregion

    //            case 1:

    //                #region ■更   新
    //                this.Mode_Label.Text = UPDATE_MODE;

    //                this.Ok_Button.Visible = true;
    //                this.Cancel_Button.Visible = true;
    //                this.Delete_Button.Visible = false;
    //                this.Revive_Button.Visible = false;

    //                ScreenInputPermissionControl(true);
    //                this.tEdit_GoodsNo.Enabled = false;
    //                this.tNedit_GoodsMakerCd.Enabled = false;
                    
    //                this._userControl.uGrid_Details.ActiveCell = this._userControl.uGrid_Details.Rows[0].Cells[1];
    //                this._userControl.uGrid_Details.Focus();
    //                this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

    //                break;
    //                #endregion

    //            case 2:

    //                #region ■削   除
    //                this.Mode_Label.Text = DELETE_MODE;

    //                this.Ok_Button.Visible = false;
    //                this.Cancel_Button.Visible = true;
    //                this.Delete_Button.Visible = true;
    //                this.Revive_Button.Visible = true;

    //                ScreenInputPermissionControl(false);
                    
    //                break;
    //                #endregion

    //        }

    //        this._indexBuf = this._dataIndex;
    //    }

    //    /// <summary>
    //    ///	画面入力許可制御処理
    //    /// </summary>
    //    /// <param name="enabled">入力許可設定値</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void ScreenInputPermissionControl(bool enabled)
    //    {
    //        // モードによって入力許可を制御
    //        this.tEdit_GoodsNo.Enabled      = enabled;
            
    //        // グリッド上ボタン許可制御
    //        // -- DEL 2009/08/04 ---------------------------------->>>
    //        //this._userControl.GridButtonPermissionControl(enabled);
    //        // -- DEL 2009/08/04 ----------------------------------<<<
    //        // グリッド編集許可制御
    //        this._userControl.GridInputPermissionControl(enabled);
    //    }

    //    /// <summary>
    //    /// 結合情報取得
    //    /// </summary>
    //    /// <param name="iMode">0:品番入力時 1:一覧選択時</param>
    //    /// <param name="parentGoodsNo">親品番</param>
    //    /// <param name="parentGoodsMakerCd">親メーカーコード</param>
    //    /// <param name="parentGoodsUnitDataList">親商品情報データリスト</param>
    //    /// <param name="childGoodsUnitDataList">子商品情報データリスト</param>
    //    /// <returns></returns>
    //    private int GetGoodSetData(int iMode, string parentGoodsNo, int parentGoodsMakerCd, out List<GoodsUnitData> parentGoodsUnitDataList, out List<GoodsUnitData> childGoodsUnitDataList)
    //    {
    //        int status = -1;
    //        string sectionCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
    //        GoodsCndtn goodsCndtn = new GoodsCndtn();
    //        PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
    //        string message;
    //        parentGoodsUnitDataList = new List<GoodsUnitData>();
    //        childGoodsUnitDataList = new List<GoodsUnitData>();

    //        goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
    //        goodsCndtn.SectionCode = sectionCd;
    //        goodsCndtn.MakerName = "";
    //        goodsCndtn.GoodsNoSrchTyp = 0;
    //        goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
    //        goodsCndtn.GoodsNo = parentGoodsNo;
    //        goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
    //        goodsCndtn.IsSettingSupplier = 1;
    //        goodsCndtn.PriceApplyDate = DateTime.Today;
    //        goodsCndtn.TotalAmountDispWayCd = 0; // 0:総額表示しない
    //        goodsCndtn.ConsTaxLayMethod = 1; // 1:明細転嫁
    //        goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:共通設定
            
    //        if (iMode == 0)
    //        {
    //            // 品番検索(結合検索なし)
    //            status = this._joinPartsUAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out parentGoodsUnitDataList, out message);
    //            if (status == 0)
    //            {
    //                GoodsUnitData wkGoodsUnitData = parentGoodsUnitDataList[0];
    //                goodsCndtn.GoodsMakerCd = wkGoodsUnitData.GoodsMakerCd;
    //                goodsCndtn.GoodsNo = wkGoodsUnitData.GoodsNo;

    //                // 品番検索(結合検索有り完全一致)
    //                status = this._joinPartsUAcs.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
    //                if (status != 0) return status;
    //            }
    //            else
    //            {
    //                // 品番検索キャンセルor失敗
    //                return status;
    //            }
    //        }
    //        else
    //        {
    //            goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
    //            goodsCndtn.GoodsNo = parentGoodsNo;

    //            // 品番検索(結合検索有り完全一致)
    //            status = this._joinPartsUAcs.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
    //            // 2009.03.26 30413 犬飼 結合元商品の商品マスタ削除チェック >>>>>>START
    //            //if (status != 0) return status;
    //            if (status != 0)
    //            {
    //                // 該当品番無し
    //                parentGoodsUnitDataList = new List<GoodsUnitData>();
    //                GoodsUnitData addGoodsUnitData = new GoodsUnitData();
    //                addGoodsUnitData.GoodsMakerCd = parentGoodsMakerCd;
    //                addGoodsUnitData.GoodsNo = parentGoodsNo;
    //                parentGoodsUnitDataList.Add(addGoodsUnitData);
    //            }
    //            // 2009.03.26 30413 犬飼 結合元商品の商品マスタ削除チェック <<<<<<END
    //        }

    //        // 商品情報取得時のメーカー、品番設定
    //        int makerCode = parentGoodsUnitDataList[0].GoodsMakerCd;
    //        string goodsNo = parentGoodsUnitDataList[0].GoodsNo;

    //        // 結合先商品情報の取得
    //        status = this._joinPartsUAcs.SearchGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, GoodsAcs.GoodsKind.ChildJoin, out childGoodsUnitDataList);

    //        return status;
    //    }

    //    /// <summary>
    //    ///	画面展開処理
    //    /// </summary>
    //    /// <param name="goodsUnitData">結合元情報データクラス</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void DisplayScreen(GoodsUnitData goodsUnitData)
    //    {
    //        if (goodsUnitData != null)
    //        {
    //            #region ●親品番
    //            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
    //            this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;
    //            #endregion

    //            #region ●親商品メーカー
    //            // DEL 2009/04/09 ------>>>
    //            //this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
    //            //this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
    //            // DEL 2009/04/09 ------<<<
                
    //            // ADD 2009/04/09 ------>>>
    //            if (goodsUnitData.GoodsName == string.Empty)
    //            {
    //                this.tNedit_GoodsMakerCd.DataText = string.Empty;
    //                this.ParentMakerName_tEdit.DataText = string.Empty;
    //            }
    //            else
    //            {
    //                this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
    //                this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
    //            }
    //            // ADD 2009/04/09 ------<<<
    //            #endregion
    //        }
    //    }

    //    /// <summary>
    //    ///	画面展開処理(オーバーロード)
    //    /// </summary>
    //    /// <param name="rowNo">行番号</param>
    //    /// <param name="goodsUnitData">結合先商品情報データクラス</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void DisplayScreen(int rowNo, GoodsUnitData goodsUnitData)
    //    {
    //        #region ●グリッドデータ展開

    //        // グリッドに表示するNoなので行数に１を加える
    //        int No = rowNo + 1;
    //        this._userControl.SetJoinPartsUDataTable(No, goodsUnitData);

    //        #endregion
    //    }

    //    /// <summary>
    //    /// 検索処理
    //    /// </summary>
    //    /// <returns>結果[true: 正常, false: 異常]</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    private int SearchProc(ref int totalCount, int readCount)
    //    {
    //        int status = -1;

    //        #region < 全件検索 >
    //        if (readCount == 0)
    //        {
    //            status = this._joinPartsUAcs.SearchAll(this._enterpriseCode, ref totalCount);
    //        }
    //        #endregion

    //        #region < 検索後処理 >
    //        switch (status)
    //        {
    //            #region -- 正常終了 --
    //            // 全件取得メソッドの結果が"正常終了"のとき
    //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
    //                {
    //                    break;
    //                }
    //            #endregion

    //            #region -- データ無し --
    //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
    //                {
    //                    break;
    //                }
    //            #endregion

    //            #region -- 検索失敗 --
    //            default:
    //                {
    //                    TMsgDisp.Show(
    //                        this, 									// 親ウィンドウフォーム
    //                        emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
    //                        PG_ID, 		    				    	// アセンブリＩＤまたはクラスＩＤ
    //                        PG_NM,        						    // プログラム名称
    //                        "SearchProc", 							// 処理名称
    //                        TMsgDisp.OPE_GET, 						// オペレーション
    //                        "読み込みに失敗しました。",    			// 表示するメッセージ
    //                        status, 								// ステータス値
    //                        this._joinPartsUAcs,             			// エラーが発生したオブジェクト
    //                        MessageBoxButtons.OK, 					// 表示するボタン
    //                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン
    //                    break;
    //                }
    //            #endregion
    //        }
    //        #endregion

    //        return status;

    //    }

    //    /// <summary>
    //    /// 登録・更新処理
    //    /// </summary>
    //    /// <returns>結果[true: 正常, false: 異常]</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    private int SaveProc()
    //    {
    //        int status = -1;

    //        #region < 入力チェック >
    //        Control control = null;
    //        string message = null;
    //        if (this.ScreenDataCheck(ref control, ref message) == false)
    //        {
    //            #region -- エラーメッセージ --
    //            TMsgDisp.Show(
    //                this,                               // 親ウィンドウフォーム
    //                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
    //                PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
    //                message,                            // 表示するメッセージ
    //                0,                                  // ステータス値
    //                MessageBoxButtons.OK);              // 表示するボタン
    //            #endregion

    //            #region -- フォーカス移動 --
    //            if (control != null)
    //            {
    //                control.Focus();

    //                if (control is TEdit)
    //                {
    //                    ((TEdit)control).SelectAll();
    //                }
    //                else if (control is TNedit)
    //                {
    //                    ((TNedit)control).SelectAll();
    //                }
    //            }
    //            #endregion

    //            return status;
    //        }
    //        #endregion

    //        #region < 登録データ準備処理 >
    //        // 画面情報をEクラスに格納
    //        int errorRowNo;
    //        string errorColNm;
    //        List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
    //        List<JoinPartsU> writeDataList = new List<JoinPartsU>();
            
    //        // 有効なデータ行リストを取得
    //        this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

    //        // エラー行番号が"0"のときのみ正常
    //        if (errorRowNo == 0)
    //        {
    //            // 書き込みを行なうデータクラスのリストを作成する
    //            for (int i = 0; i < effectDataList.Count; i++)
    //            {
    //                JoinPartsU goodsSet = new JoinPartsU();
    //                this.DispToJoinPartsU(effectDataList[i], ref goodsSet);
    //                writeDataList.Add(goodsSet);
    //            }
    //        }
    //        #endregion

    //        #region < 物理削除データ準備処理 >
    //        List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
    //        List<JoinPartsU> delDataList = new List<JoinPartsU>();

    //        // 削除対象データの取得
    //        this._userControl.GetDeleteData(out deleteDataList);

    //        // 削除を行なうデータクラスのリストを作成する
    //        for (int i = 0; i < deleteDataList.Count; i++)
    //        {
    //            JoinPartsU goodsSet = new JoinPartsU();
    //            // 完全削除
    //            this.DispToJoinPartsU(deleteDataList[i], ref goodsSet);
    //            delDataList.Add(goodsSet);
    //        }
    //        #endregion

    //        #region < 物理削除処理 >
    //        // 削除対象があれば該当レコードを削除
    //        if (deleteDataList.Count != 0)
    //        {
    //            status = this._joinPartsUAcs.DeleteUnique(delDataList);
    //        }
    //        else
    //        {
    //            status = 0;
    //        }
    //        #endregion
            
    //        Dictionary<string, GoodsUnitData> goodsUnitDataDic;
    //        _userControl.GetLC_GoodsUnitData(out goodsUnitDataDic);

    //        // 結合設定書き込み処理
    //        status = this._joinPartsUAcs.Write(writeDataList, goodsUnitDataDic);

    //        #region < 登録後処理 >
    //        switch (status)
    //        {
    //            #region -- 通常終了 --
    //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
    //                status = 0;
    //                break;

    //            // 重複エラー
    //            case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
    //                // コード重複
    //                TMsgDisp.Show(
    //                    this, 									// 親ウィンドウフォーム
    //                    emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
    //                    PG_ID, 					        		// アセンブリＩＤまたはクラスＩＤ
    //                    "このコードは既に使用されています。",  	// 表示するメッセージ
    //                    0, 										// ステータス値
    //                    MessageBoxButtons.OK);					// 表示するボタン
    //                if (this.tNedit_GoodsMakerCd.Enabled == true)
    //                {
    //                    this.tNedit_GoodsMakerCd.Focus();
    //                    this.tNedit_GoodsMakerCd.SelectAll();
    //                }
    //                break;
    //            #endregion

    //            #region -- 排他制御 --
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
    //                ExclusiveTransaction(status, true);
    //                break;
    //            #endregion

    //            #region -- 登録失敗 --
    //            default:
    //                TMsgDisp.Show(
    //                    this,                                 // 親ウィンドウフォーム
    //                    emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
    //                    PG_ID,                                // アセンブリＩＤまたはクラスＩＤ
    //                    PG_NM,                                // プログラム名称
    //                    "SaveProc",                           // 処理名称
    //                    TMsgDisp.OPE_UPDATE,                  // オペレーション
    //                    "登録に失敗しました。",               // 表示するメッセージ
    //                    status,                               // ステータス値
    //                    this._joinPartsUAcs,                    // エラーが発生したオブジェクト
    //                    MessageBoxButtons.OK,                 // 表示するボタン
    //                    MessageBoxDefaultButton.Button1);     // 初期表示ボタン
    //                this.CloseForm(DialogResult.Cancel);
    //                break;
    //            #endregion
    //        }
    //        #endregion

    //        return status;
    //    }

    //    /// <summary>
    //    /// 排他処理
    //    /// </summary>
    //    /// <param name="status">STATUS</param>
    //    /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void ExclusiveTransaction(int status, bool hide)
    //    {
    //        switch (status)
    //        {
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
    //                {
    //                    // 他端末更新
    //                    TMsgDisp.Show(
    //                        this, 								// 親ウィンドウフォーム
    //                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
    //                        PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
    //                        "既に他端末より更新されています。", // 表示するメッセージ
    //                        0, 									// ステータス値
    //                        MessageBoxButtons.OK);				// 表示するボタン
    //                    if (hide == true)
    //                    {
    //                        CloseForm(DialogResult.Cancel);
    //                    }
    //                    break;
    //                }
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
    //                {
    //                    // 他端末削除
    //                    TMsgDisp.Show(
    //                        this, 								// 親ウィンドウフォーム
    //                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
    //                        PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
    //                        "既に他端末より削除されています。", // 表示するメッセージ
    //                        0, 									// ステータス値
    //                        MessageBoxButtons.OK);				// 表示するボタン
    //                    if (hide == true)
    //                    {
    //                        CloseForm(DialogResult.Cancel);
    //                    }
    //                    break;
    //                }
    //        }
    //    }

    //    /// <summary>
    //    /// 画面情報格納処理
    //    /// </summary>
    //    /// <param name="joinPartsU">結合データクラス</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void DispToJoinPartsU(ref JoinPartsU joinPartsU)
    //    {
    //        joinPartsU.JoinSourceMakerCode = this.tNedit_GoodsMakerCd.GetInt();         // 結合元商品メーカーコード
    //        joinPartsU.JoinSourPartsNoWithH = this.tEdit_GoodsNo.DataText;              // 結合元商品コード
    //    }

    //    /// <summary>
    //    /// 画面情報格納処理(オーバーロード)
    //    /// </summary>
    //    /// <param name="row">セット商品情報入力データテーブル行</param>
    //    /// <param name="joinPartsU">結合データクラス</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void DispToJoinPartsU(GoodsSetGoodsDataSet.GoodsSetDetailRow row, ref JoinPartsU joinPartsU)
    //    {
    //        joinPartsU.JoinDispOrder = row.Disply;                                              // 結合表示順位
    //        joinPartsU.JoinSourceMakerCode = this.tNedit_GoodsMakerCd.GetInt();                 // 結合元メーカーコード
    //        joinPartsU.JoinSourPartsNoWithH = this.tEdit_GoodsNo.DataText;                      // 結合元品番(－付き品番)
    //        joinPartsU.JoinSourPartsNoNoneH = joinPartsU.JoinSourPartsNoWithH.Replace("-", ""); // 結合元品番(－無し品番)
    //        joinPartsU.JoinDestMakerCd = int.Parse(row.MakerCode);                              // 結合先メーカーコード
    //        joinPartsU.JoinDestPartsNo = row.GoodsCode;                                         // 結合先品番
    //        joinPartsU.JoinQty = double.Parse(row.Qty.ToString());                              // TODO:QTY DataRow→JoinPartsU
    //        joinPartsU.JoinSpecialNote = row.SetNote;                                           // 結合規格・特記事項
    //    }

    //    /// <summary>
    //    /// 画面入力情報不正チェック処理
    //    /// </summary>
    //    /// <param name="control">不正対象コントロール</param>
    //    /// <param name="message">メッセージ</param>
    //    /// <returns>チェック結果[true: OK, false: NG]</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    private bool ScreenDataCheck(ref Control control, ref string message)
    //    {
    //        bool result = true;

    //        #region ●結合元商品情報入力チェック

    //        #region < 商品コードの入力チェック >
    //        if (this.tEdit_GoodsNo.Text.TrimEnd() == "")
    //        {
    //            message = this.ParentGoodsCode_Label.Text + "を入力してください。";
    //            control = this.tEdit_GoodsNo;
    //            result = false;
    //            return result;
    //        }
    //        #endregion

    //        #region < メーカーコードの入力チェック >
    //        //if (this.tNedit_GoodsMakerCd.GetInt() == 0)   // DEL 2009/04/09
    //        if ((this.tNedit_GoodsMakerCd.Enabled) && (this.tNedit_GoodsMakerCd.GetInt() == 0))     // ADD 2009/04/09
    //        {
    //            message = this.ParentMakerCode_Label.Text + "を入力してください。";
    //            control = this.tNedit_GoodsMakerCd;
    //            result = false;
    //            return result;
    //        }
    //        #endregion

    //        // 2009.03.26 30413 犬飼 結合元商品の商品マスタ削除チェック >>>>>>START
    //        #region < 品名のチェック >
    //        if (this.ParentGoodsName_tEdit.Text.TrimEnd() == "")
    //        {
    //            message = "結合元商品が商品マスタから削除されています。";
    //            control = this.tEdit_GoodsNo;
    //            result = false;
    //            return result;
    //        }
    //        #endregion
    //        // 2009.03.26 30413 犬飼 結合元商品の商品マスタ削除チェック <<<<<<END

    //        #endregion

    //        #region ●結合先商品情報入力チェック

    //        result = _userControl.GridDataCheck(ref control, ref message);
            
    //        #endregion

    //        return result;
    //    }

    //    /// <summary>
    //    /// 選択されたGridデータ取得処理(オーバーロード)
    //    /// </summary>
    //    /// <param name="joinPartsU">結合データクラス</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void GetGridData(ref JoinPartsU joinPartsU)
    //    {
    //        // 結合元メーカーコード
    //        joinPartsU.JoinSourceMakerCode = (int)(this._joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.PARENTGOODSMAKERCD_TITLE]);
    //        // 結合元品番
    //        joinPartsU.JoinSourPartsNoWithH = this._joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView[this._dataIndex][JoinPartsUAcs.PARENTGOODSNO_TITLE].ToString();
    //        // 企業コード
    //        joinPartsU.EnterpriseCode = this._enterpriseCode;
    //    }
        
    //    /// <summary>
    //    /// 画面変更確認処理
    //    /// </summary>
    //    /// <returns>チェック結果[true: 変更有, false: 変更無]</returns>
    //    /// <remarks>
    //    /// </remarks>
    //    private bool CheckScreenChange()
    //    {
    //        bool result = false;

    //        JoinPartsU joinPartsUBefore = new JoinPartsU();
    //        JoinPartsU joinPartsUAfter = new JoinPartsU();

    //        // 画面から取得するデータを編集後のデータとする
    //        this.DispToJoinPartsU(ref joinPartsUAfter);

    //        #region < 親商品情報比較処理 >
    //        // 画面表示時(クローン)と比較をして違いがあるかチェックする
    //        ArrayList DisagreementList = _joinPartsUClone.Compare(joinPartsUAfter);
            
    //        if (DisagreementList.Count > 0)
    //        {
    //            // 編集有り
    //            result = true;
    //            return result;
    //        }
    //        #endregion

    //        #region < セット商品情報比較処理 >
    //        result = this._userControl.CheckGridChange();
    //        #endregion

    //        return result;
    //    }

    //    /// <summary>
    //    /// 詳細グリッド最上位行キーダウンイベント
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータクラス</param>
    //    private void GoodsSetDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
    //    {
    //        this.tEdit_GoodsNo.Focus();
    //        this.tEdit_GoodsNo.SelectAll();
    //    }

    //    /// <summary>
    //    /// 詳細グリッド最下層行キーダウンイベント
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータクラス</param>
    //    private void GoodsSetDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
    //    {
    //        this.Ok_Button.Focus();
    //    }

    //    #endregion

    //    #region ◆ControlEvent

    //    /// <summary>
    //    /// Form.Load イベント (PMKEN09074UA)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //     private void PMKEN09074UA_Load(object sender, EventArgs e)
    //    {
    //         // 画面を構築
    //         this.ScreenInitialSetting();

    //         this.panel_Detail.Controls.Add(_userControl);

    //         // 画面ロード時に表示された親商品情報を編集前データとして保持
    //         this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
    //         this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
    //    }

    //    /// <summary>
    //    ///	Form.Closing イベント(PMKEN09074UA)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void PMKEN09074UA_FormClosing(object sender, FormClosingEventArgs e)
    //    {
    //        // ADD 2008/10/22 不具合対応[6563]---------->>>>>
    //        // [×]ボタン用の処理
    //        if ((sender == this) && e.CloseReason.Equals(CloseReason.UserClosing))
    //        {
    //            try
    //            {
    //                // 直接[×]ボタンをクリックしたのなら、フォームは見えているはず
    //                if (this.Visible) Cancel_Button_Click(sender, e);   // [閉じる]ボタンと同じ処理を行う
    //            }
    //            catch (NullReferenceException ex)   // フレーム側の[閉じる]ボタン用のハンドラ
    //            {
    //                System.Diagnostics.Debug.WriteLine(ex.ToString());
    //                // 何もしない（∵フレーム側の[閉じる]ボタンでも[×]ボタンと同じ条件のイベントが発生する）
    //            }
    //        }
    //        // ADD 2008/10/22 不具合対応[6563]----------<<<<<

    //        this._indexBuf = -2;

    //        // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
    //        // フォームを非表示化する。
    //        //（フォームの「×」をクリックされた場合の対応です。）
    //        if (CanClose == false)
    //        {
    //            e.Cancel = true;
    //            this.Hide();
    //            return;
    //        }
    //    }

    //    /// <summary>
    //    /// Form.VisibleChanged イベント (PMKEN09074UA)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void PMKEN09074UA_VisibleChanged(object sender, EventArgs e)
    //    {
    //        if (this.Visible == false)
    //        {
    //            this.Owner.Activate();
    //            return;
    //        }

    //        // ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
    //        if (this._indexBuf == this._dataIndex)
    //        {
    //            return;
    //        }

    //        Initial_timer.Enabled = true;

    //        ScreenClear();
    //    }

    //    /// <summary>
    //    /// Control.Click イベント(Delete_Button)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void Delete_Button_Click(object sender, EventArgs e)
    //    {
    //        #region < 完全削除確認 >
    //        DialogResult result = TMsgDisp.Show(
    //            this, 								// 親ウィンドウフォーム
    //            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
    //            PG_ID,       						// アセンブリＩＤまたはクラスＩＤ
    //            "データを削除します。" + "\r\n" +
    //            "よろしいですか？", 				// 表示するメッセージ
    //            0, 									// ステータス値
    //            MessageBoxButtons.OKCancel, 		// 表示するボタン
    //            MessageBoxDefaultButton.Button2);	// 初期表示ボタン
    //        #endregion

    //        if (result == DialogResult.OK)
    //        {
    //            #region < 物理削除データ準備処理 >
    //            // 画面情報をEクラスに格納
    //            int errorRowNo;
    //            string errorColNm;
    //            JoinPartsU goodsSet;
    //            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
    //            List<JoinPartsU> delDataList = new List<JoinPartsU>();

    //            // 有効なデータ行リストを取得
    //            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

    //            // エラー行番号が"0"のときのみ正常
    //            if (errorRowNo == 0)
    //            {
    //                // 書き込みを行なうデータクラスのリストを作成する
    //                for (int i = 0; i < effectDataList.Count; i++)
    //                {
    //                    goodsSet = new JoinPartsU();
    //                    this.DispToJoinPartsU(effectDataList[i], ref goodsSet);
    //                    delDataList.Add(goodsSet);
    //                }
    //            }
    //            #endregion

    //            #region < 物理削除処理 >
    //            int status = this._joinPartsUAcs.Delete(delDataList);
    //            #endregion

    //            #region < 物理削除後処理 >
    //            switch (status)
    //            {
    //                #region -- 正常終了 --
    //                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
    //                    {
    //                        break;
    //                    }
    //                #endregion

    //                #region -- 排他制御 --
    //                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
    //                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
    //                    {
    //                        ExclusiveTransaction(status, true);
    //                        return;
    //                    }
    //                #endregion

    //                #region -- 物理削除失敗 --
    //                default:
    //                    {
    //                        // 物理削除
    //                        TMsgDisp.Show(
    //                            this, 									// 親ウィンドウフォーム
    //                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
    //                            PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
    //                            PG_NM,					    	        // プログラム名称
    //                            "Delete_Button_Click", 					// 処理名称
    //                            TMsgDisp.OPE_DELETE, 					// オペレーション
    //                            "削除に失敗しました。", 		    	// 表示するメッセージ
    //                            status, 								// ステータス値
    //                            this._joinPartsUAcs, 	    			// エラーが発生したオブジェクト
    //                            MessageBoxButtons.OK, 					// 表示するボタン
    //                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

    //                        CloseForm(DialogResult.Cancel);
    //                        return;
    //                    }
    //                #endregion
    //            }
    //            #endregion

    //        }
    //        else
    //        {
    //            this.Delete_Button.Focus();
    //            return;
    //        }

    //        if (UnDisplaying != null)
    //        {
    //            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
    //            UnDisplaying(this, me);
    //        }

    //        this.DialogResult = DialogResult.OK;

    //        this._indexBuf = -2;

    //        if (CanClose == true)
    //        {
    //            this.Close();
    //        }
    //        else
    //        {
    //            this.Hide();
    //        }
    //    }

    //    /// <summary>
    //    /// Control.Click イベント(Revive_Button)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void Revival_Button_Click(object sender, EventArgs e)
    //    {
    //        #region < 復活データ準備処理 >
    //        int errorRowNo;                                                     // エラー行番号
    //        string errorColNm;
    //        JoinPartsU goodsSet;                                                // データクラス
    //        List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;        // 有効データ行リスト
    //        List<JoinPartsU> revDataList = new List<JoinPartsU>();              // 復活対象データクラスリスト

    //        // 有効なデータ行リストを取得
    //        this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

    //        // エラー行番号が"0"のときのみ正常
    //        if (errorRowNo == 0)
    //        {
    //            // 書き込みを行なうデータクラスのリストを作成する
    //            for (int i = 0; i < effectDataList.Count; i++)
    //            {
    //                goodsSet = new JoinPartsU();
    //                this.DispToJoinPartsU(effectDataList[i], ref goodsSet);
    //                revDataList.Add(goodsSet);
    //            }
    //        }
    //        #endregion

    //        #region < 復活処理 >
    //        int status = this._joinPartsUAcs.Revival(revDataList);
    //        #endregion

    //        #region < 復活後処理 >
    //        switch (status)
    //        {
    //            #region -- 通常終了 --
    //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
    //                {
    //                    break;
    //                }
    //            #endregion

    //            #region -- 排他制御 --
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
    //            case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
    //                {
    //                    ExclusiveTransaction(status, true);
    //                    return;
    //                }
    //            #endregion

    //            #region -- 復活失敗 --
    //            default:
    //                {
    //                    // 復活失敗
    //                    TMsgDisp.Show(
    //                        this, 									// 親ウィンドウフォーム
    //                        emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
    //                        PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
    //                        PG_NM,						            // プログラム名称
    //                        "Revive_Button_Click", 					// 処理名称
    //                        TMsgDisp.OPE_UPDATE, 					// オペレーション
    //                        "復活に失敗しました。", 			    // 表示するメッセージ
    //                        status, 								// ステータス値
    //                        this._joinPartsUAcs, 	    			// エラーが発生したオブジェクト
    //                        MessageBoxButtons.OK, 					// 表示するボタン
    //                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン

    //                    CloseForm(DialogResult.Cancel);
    //                    return;
    //                }
    //            #endregion
    //        }
    //        #endregion

    //        if (UnDisplaying != null)
    //        {
    //            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
    //            UnDisplaying(this, me);
    //        }

    //        this.DialogResult = DialogResult.OK;

    //        this._indexBuf = -2;

    //        if (CanClose == true)
    //        {
    //            this.Close();
    //        }
    //        else
    //        {
    //            this.Hide();
    //        }
    //    }

    //    /// <summary>
    //    ///　Control.Click イベント(Ok_Button)
    //    /// </summary>
    //    /// <remarks>
    //    ///</remarks>
    //    private void Ok_Button_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            this.Cursor = Cursors.WaitCursor;

    //            if (SaveProc() != 0)
    //            {
    //                return;
    //            }

    //            // 画面非表示イベント
    //            if (UnDisplaying != null)
    //            {
    //                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
    //                UnDisplaying(this, me);
    //            }

    //            #region ●新規登録
    //            // 登録モードの場合は画面を終了せずに連続入力を可能とする
    //            if (this.Mode_Label.Text == INSERT_MODE)
    //            {
    //                // データインデックスを初期化する
    //                this.DataIndex = -1;

    //                ScreenClear();

    //                // フォーカスを結合コードにして全選択にする
    //                this.tEdit_GoodsNo.Focus();
    //                this.tEdit_GoodsNo.SelectAll();

    //                // 画面の再構築を行なうため
    //                this.Initial_timer.Enabled = true;
    //            }
    //            #endregion

    //            #region ●更新
    //            else
    //            {
    //                this.DialogResult = DialogResult.OK;

    //                this._indexBuf = -2;

    //                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
    //                // フォームを非表示化する。
    //                if (CanClose == true)
    //                {
    //                    this.Close();
    //                }
    //                else
    //                {
    //                    this.Hide();
    //                }
    //            }
    //            #endregion
    //        }
    //        finally
    //        {
    //            this.Cursor = Cursors.Default;
    //        }

    //        // 2010/01/05 Add >>>
    //        this._prevParentMakerCode = 0;
    //        this._prevParentGoodsCode = "";
    //        // 2010/01/05 Add <<<
    //    }

    //    /// <summary>
    //    ///	Control.Click イベント(Cancel_Button)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void Cancel_Button_Click(object sender, EventArgs e)
    //    {
    //        // 削除モード以外の場合は保存確認処理を行う。
    //        if ((this.Mode_Label.Text != DELETE_MODE) &&
    //            (this.Mode_Label.Text != REFER_MODE))
    //        {
    //            // 変更チェック処理
    //            this._changeFlg = CheckScreenChange();

    //            if (this._changeFlg)
    //            {
    //                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
              
    //                #region < 保存確認 >
    //                DialogResult res = TMsgDisp.Show(
    //                    this, 								// 親ウィンドウフォーム
    //                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
    //                    PG_ID,       	    				// アセンブリＩＤまたはクラスＩＤ
    //                    null, 		        				// 表示するメッセージ
    //                    0, 									// ステータス値
    //                    MessageBoxButtons.YesNoCancel);	    // 表示するボタン
    //                #endregion

    //                #region < 保存確認後処理 >
    //                switch (res)
    //                {
    //                    #region -- はい --
    //                    case DialogResult.Yes:
    //                        {
    //                            if (SaveProc() != 0)
    //                            {
    //                                return;
    //                            }

    //                            this.DialogResult = DialogResult.OK;
    //                            break;
    //                        }
    //                    #endregion

    //                    #region -- いいえ --
    //                    case DialogResult.No:
    //                        {
    //                            this.DialogResult = DialogResult.Cancel;
    //                            break;
    //                        }
    //                    #endregion

    //                    #region -- キャンセル --
    //                    default:
    //                        {
    //                            this.Cancel_Button.Focus();
    //                            return;
    //                        }
    //                    #endregion
    //                }
    //                #endregion
    //            }
    //        }

    //        // 画面非表示イベント
    //        if (UnDisplaying != null)
    //        {
    //            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
    //            UnDisplaying(this, me);
    //        }

    //        this.DialogResult = DialogResult.Cancel;

    //        this._indexBuf = -2;

    //        // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
    //        // フォームを非表示化する。
    //        if (CanClose == true)
    //        {
    //            this.Close();
    //        }
    //        else
    //        {
    //            this.Hide();
    //        }

    //        this._prevParentMakerCode = 0;
    //        this._prevParentGoodsCode = "";
    //    }

    //    /// <summary>
    //    /// Timer.Tick イベント イベント(Initial_Timer)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void Initial_timer_Tick(object sender, EventArgs e)
    //    {
    //        Initial_timer.Enabled = false;
    //        ScreenReconstruction();
    //    }

    //    /// <summary>
    //    ///	Control.ChangeFocus イベント
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
    //    {
    //        if (e.PrevCtrl == null || e.NextCtrl == null) return;

    //        switch (e.PrevCtrl.Name)
    //        {
    //            #region ●グリッド内フォーカス移動
    //            case "uGrid_Details":
    //                {
    //                    if (!e.ShiftKey)
    //                    {
    //                        switch (e.Key)
    //                        {
    //                            case Keys.Return:
    //                            case Keys.Tab:
    //                                {
    //                                    if (this._userControl.uGrid_Details.ActiveCell != null)
    //                                    {
    //                                        // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移 ---------->>>>>
    //                                        // TODO:「QTY」への強制フォーカス遷移
    //                                        CellCoodinate previousCellCoodinate;
    //                                        if (this._userControl.ReturnKeyDown(out previousCellCoodinate))
    //                                        {
    //                                            if (
    //                                                this._userControl.uGrid_Details.ActiveCell.Column.Index.Equals(1)   // 移動後のセルが1:「表示順位」
    //                                                    &&                                                              // ※グリッド側の制御により、次のTabStop可能セル（前の「品名」セル→次の「表示順位」セル）に遷移している
    //                                                previousCellCoodinate.Column.Equals(2)                              // 移動前のセルが2:「品名」
    //                                            )
    //                                            {
    //                                                int rowIndex = this._userControl.uGrid_Details.ActiveCell.Row.Index;
    //                                                if (rowIndex > 0)
    //                                                {
    //                                                    int previousRowIndex = rowIndex - 1;
    //                                                    if (this._userControl.uGrid_Details.Rows[previousRowIndex].Cells["Qty"].TabStop.Equals(Infragistics.Win.DefaultableBoolean.True))
    //                                                    {
    //                                                        this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
    //                                                        this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
    //                                                    }
    //                                                }
    //                                            }
    //                                            // ADD 2008/11/25 不具合対応[6564] 結合先を新規追加時は「QTY」へ強制フォーカス遷移 ----------<<<<<

    //                                            e.NextCtrl = null;
    //                                        }
    //                                        else
    //                                        {
    //                                            e.NextCtrl = this.Ok_Button;
    //                                        }
    //                                    }

    //                                    break;
    //                                }
    //                            default:
    //                                break;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        switch (e.Key)
    //                        {
    //                            case Keys.Tab:
    //                                {
    //                                    if ((this._userControl.uGrid_Details.ActiveCell.Column.Index.Equals(1)) && (this._userControl.uGrid_Details.ActiveCell.Row.Index.Equals(0)))
    //                                    {
    //                                        // ADD 2008/11/17 不具合対応[6558] Shift+Tabによるフォーカス遷移 ---------->>>>>
    //                                        e.NextCtrl = this.tEdit_GoodsNo;
    //                                        if (!this.tEdit_GoodsNo.Enabled)
    //                                        // ADD 2008/11/17 不具合対応[6558] Shift+Tabによるフォーカス遷移 ----------<<<<<
    //                                        {
    //                                            // 閉じるボタンに遷移
    //                                            e.NextCtrl = this.Cancel_Button;
    //                                        }
    //                                    }
    //                                    else
    //                                    {   // MEMO:[Shift]+[Tab]
    //                                        if (this._userControl.ReturnKeyDown2())
    //                                        {
    //                                            e.NextCtrl = null;
    //                                        }
    //                                        else
    //                                        {
    //                                            // ADD 2008/11/17 不具合対応[6558] Shift+Tabによるフォーカス遷移 ---------->>>>>
    //                                            // 表示順 0 の行へ遷移しようとした場合
    //                                            e.NextCtrl = this.tEdit_GoodsNo;
    //                                            if (!this.tEdit_GoodsNo.Enabled)
    //                                            {
    //                                                // 閉じるボタンに遷移
    //                                                e.NextCtrl = this.Cancel_Button;
    //                                            }
    //                                            // ADD 2008/11/17 不具合対応[6558] Shift+Tabによるフォーカス遷移 ----------<<<<<
    //                                        }
    //                                    }
    //                                }
    //                                break;
    //                        }
    //                    }
    //                    break;
    //                }
    //            #endregion

    //            #region ●メーカー情報検索
    //        case "tNedit_GoodsMakerCd":
    //            {
    //                #region < 編集チェック >
    //                // 変数保持
    //                int parentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                    
    //                if (this._prevParentMakerCode == parentMakerCode)
    //                {
    //                    // 編集前と同じなら処理を行なわない
    //                    return;
    //                }
    //                #endregion

    //                #region < ゼロ入力チェック >
    //                if (this.tNedit_GoodsMakerCd.GetInt() != 0)
    //                {
    //                    // メーカーデータクラス
    //                    MakerUMnt makerUMnt;
                        
    //                    // メーカー情報取得
    //                    this._joinPartsUAcs.GetMaker(this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt(), out makerUMnt);

    //                    #region < 画面表示処理 >

    //                    if (makerUMnt != null)
    //                    {
    //                        #region -- 取得データ展開 --
    //                        // メーカー情報画面表示
    //                        this.ParentMakerName_tEdit.DataText = makerUMnt.MakerName;
    //                        #endregion
    //                    }
    //                    else
    //                    {
    //                        #region -- 取得失敗 --
    //                        TMsgDisp.Show(
    //                            this,
    //                            emErrorLevel.ERR_LEVEL_INFO,
    //                            this.Name,
    //                            "該当するデータが存在しません。",
    //                            -1,
    //                            MessageBoxButtons.OK);

    //                        this.tNedit_GoodsMakerCd.Clear();
    //                        this.ParentMakerName_tEdit.Clear();
    //                        #endregion
    //                    }
    //                    #endregion
    //                }
    //                else
    //                {
    //                    this.tNedit_GoodsMakerCd.Clear();
    //                    this.ParentMakerName_tEdit.Clear();
    //                }
    //                #endregion

    //                #region < 編集前データ保持 >
    //                // 編集された親商品情報を編集前データとして保持
    //                this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
    //                this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
    //                #endregion

    //                break;
    //            }
                
    //            #endregion

    //            #region ●商品情報検索
    //            case "tEdit_GoodsNo":
    //                {
    //                    #region < 編集チェック >
    //                    // 変数保持
    //                    string parentGoodsCode = this.tEdit_GoodsNo.DataText;

    //                    if (this._prevParentGoodsCode == parentGoodsCode)
    //                    {
    //                        // 編集前と同じなら処理を行なわない
    //                        return;
    //                    }
    //                    #endregion

    //                    #region < 空入力チェック >
    //                    if (this.tEdit_GoodsNo.DataText != "")
    //                    {
    //                        string searchCode;
    //                        // 検索の種類を取得
    //                        int searchType = this._userControl.GetSearchType(this.tEdit_GoodsNo.DataText, out searchCode);

    //                        List<GoodsUnitData> parentGoodsUnitDataList;
    //                        List<GoodsUnitData> childGoodsUnitDataList;
    //                        string parentGoodsNo = this.tEdit_GoodsNo.DataText;
    //                        int parentGoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

    //                        int status = this.GetGoodSetData(0, parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);

    //                        #region < 画面表示処理 >
    //                        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (parentGoodsUnitDataList != null) && (parentGoodsUnitDataList.Count > 0))
    //                        {
    //                            #region -- 結合元商品情報を展開 --
    //                            this.DisplayScreen(parentGoodsUnitDataList[0]);
    //                            #endregion

    //                            #region -- 結合先商品情報を展開 --
    //                            childGoodsUnitDataList.Sort(CompareGoodsUnitData);
    //                            for (int i = 0; i < childGoodsUnitDataList.Count; i++)
    //                            {
    //                                DisplayScreen(i, childGoodsUnitDataList[i]);
    //                            }
    //                            #endregion

    //                            // UI画面のモード変更チェック
    //                            if (this._joinPartsUAcs.CheckModeChange(parentGoodsUnitDataList[0]))
    //                            {
    //                                // 結合マスタに登録済みの商品
    //                                this.Mode_Label.Text = UPDATE_MODE;
    //                                this.tEdit_GoodsNo.Enabled = false;
    //                                this.tNedit_GoodsMakerCd.Enabled = false;
    //                                //this.ParentMakerGuide_Button.Enabled = false;

    //                                // 削除ボタンの使用不可
    //                                // -- DEL 2009/10/30 ------------->>>
    //                                //this._userControl.DeleteBtnFlag = false;
    //                                //this._userControl.uButton_RowDeleteEnabled(false);
    //                                // -- DEL 2009/10/30 -------------<<<
    //                            }

    //                            // -- ADD 2009/10/30 ------------------------>>>
    //                            if ((childGoodsUnitDataList.Count > 0) && (childGoodsUnitDataList[0] as GoodsUnitData).JoinDispOrder >= 100)
    //                            {
    //                                this._userControl.DeleteBtnFlag = false;
    //                                this._userControl.uButton_RowDeleteEnabled(false);
    //                            }
    //                            else
    //                            {
    //                                this._userControl.DeleteBtnFlag = true;
    //                                this._userControl.uButton_RowDeleteEnabled(true);
    //                            }
    //                            // -- ADD 2009/10/30 ------------------------<<<
    //                        }
    //                        else if (status == -1)
    //                        {
    //                            this.tEdit_GoodsNo.Clear();
    //                            this.ParentGoodsName_tEdit.Clear();

    //                            // カーソル制御
    //                            e.NextCtrl = e.PrevCtrl;
    //                            break;
    //                        }
    //                        else
    //                        {
    //                            #region -- 取得失敗 --
    //                            TMsgDisp.Show(
    //                                this,
    //                                emErrorLevel.ERR_LEVEL_INFO,
    //                                this.Name,
    //                                "品番 [" + searchCode + "] に該当するデータが存在しません。",
    //                                -1,
    //                                MessageBoxButtons.OK);

    //                            // 商品情報クリア
    //                            this.tEdit_GoodsNo.Clear();
    //                            this.ParentGoodsName_tEdit.Clear();

    //                            // カーソル制御
    //                            e.NextCtrl = e.PrevCtrl;
    //                            #endregion
    //                        }
    //                        #endregion
    //                    }    
    //                    else
    //                    {
    //                        // 商品コードを元に戻す
    //                        this.tEdit_GoodsNo.DataText = "";
    //                        // 商品名称のクリア
    //                        this.ParentGoodsName_tEdit.DataText = "";

    //                        // ADD 2008/11/06 不具合対応[7513] 品番クリア時にメーカーもクリア ---------->>>>>
    //                        this.tNedit_GoodsMakerCd.Clear();
    //                        this.ParentMakerName_tEdit.Clear();
    //                        // ADD 2008/11/06 不具合対応[7513] 品番クリア時にメーカーもクリア ----------<<<<<
    //                    }
    //                    #endregion

    //                    #region < 編集前データ保持 >
    //                    // 親商品情報が編集されたので編集前データとして保持
    //                    this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
    //                    this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
    //                    #endregion

    //                    // ADD 2008/11/25 不具合対応[6564]↓ 結合先を新規追加時は「QTY」へ強制フォーカス遷移
    //                    this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

    //                    break;
    //                }
    //            #endregion
    //        }
    //    }

    //    /// <summary>
    //    /// Control.Click イベント(ParentGoodsGuide_Button)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void ParentGoodsGuide_Button_Click(object sender, EventArgs e)
    //    {
    //        MAKHN04110UA goodsGuide = new MAKHN04110UA();
    //        GoodsUnitData goodsUnitData = new GoodsUnitData();
    //        GoodsCndtn goodsCndtn = new GoodsCndtn();

    //        // 検索条件の設定
    //        goodsCndtn.EnterpriseCode = _enterpriseCode;
    //        goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

    //        // 商品検索ガイドの起動
    //        goodsGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
            
    //        // 何も選択されていなかったら
    //        if (goodsUnitData == null)
    //        {
    //            return;
    //        }

    //        // 結合元商品情報画面表示
    //        this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
    //        this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
    //        this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
    //        this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;

    //        #region < 編集前データ保持 >
    //        // 編集された結合元商品情報を編集前データとして保持
    //        this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
    //        this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
    //        #endregion
    //    }

    //    /// <summary>
    //    /// ValueChanged イベント(tNedit_GoodsMakerCd)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void tNedit_GoodsMakerCd_ValueChanged(object sender, EventArgs e)
    //    {
    //        this._userControl.JoinSourceMakerCode = tNedit_GoodsMakerCd.GetInt();
    //    }

    //    /// <summary>
    //    /// ValueChanged イベント(tEdit_GoodsNo)
    //    /// </summary>
    //    /// <param name="sender">対象オブジェクト</param>
    //    /// <param name="e">イベントパラメータ</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private void tEdit_GoodsNo_ValueChanged(object sender, EventArgs e)
    //    {
    //        this._userControl.JoinSourPartsNoWithH = tEdit_GoodsNo.DataText;
    //    }
    //    #endregion

    //    /// <summary>
    //    ///	ソート用の商品連結データ比較処理
    //    /// </summary>
    //    /// <param name="goodsA">商品連結データ(比較元)</param>
    //    /// <param name="goodsB">商品連結データ(比較先)</param>
    //    /// <remarks>
    //    /// </remarks>
    //    private static int CompareGoodsUnitData(GoodsUnitData goodsA, GoodsUnitData goodsB)
    //    {
    //        if (goodsA == null)
    //        {
    //            if (goodsB == null)
    //            {
    //                return 0;
    //            }
    //            else
    //            {
    //                return -1;
    //            }
    //        }
    //        else
    //        {
    //            if (goodsB == null)
    //            {
    //                return 1;
    //            }
    //            else
    //            {
    //                if (goodsA.OfferKubun == 0 && goodsB.OfferKubun == 0)
    //                {
    //                    return goodsA.JoinDispOrder.CompareTo(goodsB.JoinDispOrder);
    //                }
    //                else
    //                {
    //                    if (goodsA.OfferKubun != 0 && goodsB.OfferKubun == 0)
    //                    {
    //                        return 0;
    //                    }
    //                    else
    //                    {
    //                        if (goodsA.OfferKubun != 0 && goodsB.OfferKubun != 0)
    //                        {
    //                            return goodsA.JoinDispOrder.CompareTo(goodsB.JoinDispOrder);
    //                        }
    //                        else
    //                        {
    //                            return -1;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    // ---- DEL 2010/06/08 ------<<<<<
    #endregion

    #region ADD 2010/06/08
    // ---- ADD 2010/06/08 ---------->>>>>
    public partial class PMKEN09074UA : System.Windows.Forms.Form
    {
        #region ■ Private Const
        private const string ct_Tool_CloseButton = "ButtonTool_Close";						// 終了
        private const string ct_Tool_NewButton = "ButtonTool_New";							// 新規
        private const string ct_Tool_SaveButton = "ButtonTool_Save";							// 保存
        private const string ct_Tool_DeleteButton = "ButtonTool_Delete";						// 削除
        private const string ct_Tool_LoginEmployee = "LabelTool_LoginTitle";				// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName = "LabelTool_LoginName";		     // ログイン担当者名称
        private const string ctAssemblyName = "PMKEN09074UA";	// 結合マスタアセンブリID　// ADD 劉超　2013/12/04 FOR Redmine#41447
        #endregion ■ Private Const

        #region ◆Constractor

        /// <summary>
        /// 結合フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public PMKEN09074UA()
        {
            InitializeComponent();

            // 結合マスタアクセスクラスインスタンス化
            _joinPartsUAcs = new JoinPartsUAcs();
            // ユーザーコントロールクラスインスタンス化
            _userControl = new PMKEN09074UB(_joinPartsUAcs);

            this._userControl.InitialLoadFlag = true;     // ADD 劉超　2013/12/04 FOR Redmine#41447

            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // --- DEL m.suzuki 2010/08/03 ---------->>>>>
            //this.Search(ref _intOne, _intTwo);
            // --- DEL m.suzuki 2010/08/03 ----------<<<<<

            // 変数初期化
            this._changeFlg = false;

            // Eventの設定
            this._userControl.GridKeyDownTopRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownTopRow);
            this._userControl.GridKeyDownButtomRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownButtomRow);
        }

        #endregion

        # region ◆Private Members

        /// <summary>結合マスタ（ユーザー登録）アクセス</summary>
        private readonly JoinPartsUAcs _joinPartsUAcs; 
        /// <summary>結合先情報のユーザーコントロール</summary>
        private readonly PMKEN09074UB _userControl; 
        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;   

        private static JoinPartsU _joinPartsUClone;

        private bool _changeFlg;


        private int _intOne;
        private int _intTwo = 0;

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";

        private const string PG_ID = "PMKEN09074U";
        private const string PG_NM = "結合マスタ";

        // 編集前データ保持
        private int _prevParentMakerCode;
        private string _prevParentGoodsCode;

        # endregion

        # region ◆Properties
        /// <summary>
        /// ログインユーザーを取得します。
        /// </summary>
        /// <value>ログインユーザー</value>
        private Employee LoginWorker
        {
            get { return _joinPartsUAcs.LoginWorker; }
        }

        /// <summary>
        /// 自拠点コードを取得します。
        /// </summary>
        /// <value>自拠点コード</value>
        private string OwnSectionCode
        {
            get { return _joinPartsUAcs.OwnSectionCode; }
        }

        # endregion

        # region ◆Public Methods

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : バインドデータセットを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this._joinPartsUAcs.JoinPartsUDataSet;
            tableName = JoinPartsUAcs.JOINPARTSU_TABLE;
        }

        /// <summary>
        ///	データ検索処理 
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : データを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;

            if (readCount == 0)
            {
                status = this._joinPartsUAcs.SearchAll(this._enterpriseCode, ref totalCount);
            }

            switch (status)
            {
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        status = 0;
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
                            PG_ID, 			        				// アセンブリＩＤまたはクラスＩＤ
                            PG_NM,            						// プログラム名称
                            "Search", 								// 処理名称
                            TMsgDisp.OPE_GET, 						// オペレーション
                            "読み込みに失敗しました。",    			// 表示するメッセージ
                            status, 								// ステータス値
                            this._joinPartsUAcs,      				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        break;
                    }
            }

            return status;
        }
        #endregion

        #region ◆Private Methods

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面初期設定を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {

            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[ct_Tool_CloseButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 新規
            this.tToolsManager_MainMenu.Tools[ct_Tool_NewButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // 保存
            this.tToolsManager_MainMenu.Tools[ct_Tool_SaveButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 削除
            this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployee].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[ct_Tool_LoginEmployeeName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
        }

        /// <summary>
        ///	画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面クリアを処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_GoodsMakerCd.Clear();
            this.ParentMakerName_tEdit.Clear();
            this.tEdit_GoodsNo.Clear();
            this.ParentGoodsName_tEdit.Clear();

            this._userControl.ClearGoodsSetDataTable();
        }

        /// <summary>
        /// 全データ格納データセット（DataView）より、該当するレコードのインデックスを取得します。
        /// </summary>
        /// <param name="joinSourceGoodsNo">結合元品番</param>
        /// <param name="joinSourceMakerCode">結合元メーカーコード</param>
        /// <returns>該当するインデックス</returns>
        /// <remarks>
        /// <br>Note       : 全データを格納します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int FindIndexOfDataView(
            string joinSourceGoodsNo,
            int joinSourceMakerCode
        )
        {
            const int GOODS_NO_CLM_IDX = 3; // 結合元品番のカラムインデックス
            const int MAKER_CD_CLM_IDX = 5; // 結合元メーカーコードのカラムインデックス

            DataView dataView = _joinPartsUAcs.JoinPartsUDataSet.Tables[JoinPartsUAcs.JOINPARTSU_TABLE].DefaultView;

            for (int index = 0; index < dataView.Count; index++)
            {
                string goodsNo = dataView[index][GOODS_NO_CLM_IDX].ToString();
                string makerCd = dataView[index][MAKER_CD_CLM_IDX].ToString();
                System.Diagnostics.Debug.WriteLine("ビューの元品番：" + goodsNo + " ビューの元メーカー：" + makerCd);

                if (goodsNo.Equals(joinSourceGoodsNo) && makerCd.Equals(joinSourceMakerCode.ToString()))
                {
                    return index;
                }
            }
            return -1;
        }

        /// <summary>
        ///	画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 結合先商品情報表示データテーブルをクリア
                this._userControl.ClearGoodsSetDataTable();

                // 削除ボタンの使用不可
                this._userControl.DeleteBtnFlag = true;

                // グリッド初期設定処理の呼び出し
                this._userControl.SetJoinPartsUGrid();

                // グリッドの表示を先頭に戻す
                this._userControl.uGrid_Details.DisplayLayout.RowScrollRegions.Clear();
                this._userControl.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

                //新規登録画面
                ScreenAccordingToMode(0);

                #region < 変更チェック用クローン作成 >
                // 画面変更されたかチェックをするためクローン作成
                _joinPartsUClone = new JoinPartsU();
                this.DispToJoinPartsU(ref _joinPartsUClone);
                #endregion

                #region < フォーカス設定・全選択 >
                Control focusControl = null;
                if (focusControl != null)
                {
                    focusControl.Focus();
                    if (focusControl is TEdit) ((TEdit)focusControl).SelectAll();
                    if (focusControl is TNedit) ((TNedit)focusControl).SelectAll();
                }
                #endregion
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///	モード別画面構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モード別画面を構築します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenAccordingToMode(int mode)
        {
            switch (mode)
            {
                case 0:

                    #region ■新規登録

                    this.Mode_Label.Text = INSERT_MODE;

                    this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = false;

                    ScreenInputPermissionControl(true);
                    this.tEdit_GoodsNo.Focus();

                    break;
                    #endregion
            }
        }

        /// <summary>
        ///	画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面入力許可を制御処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {
            // モードによって入力許可を制御
            this.tEdit_GoodsNo.Enabled = enabled;

            // グリッド編集許可制御
            this._userControl.GridInputPermissionControl(enabled);
        }

        /// <summary>
        /// 結合情報取得
        /// </summary>
        /// <param name="iMode">0:品番入力時 1:一覧選択時</param>
        /// <param name="parentGoodsNo">親品番</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsUnitDataList">親商品情報データリスト</param>
        /// <param name="childGoodsUnitDataList">子商品情報データリスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 結合情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int GetGoodSetData(int iMode, string parentGoodsNo, int parentGoodsMakerCd, out List<GoodsUnitData> parentGoodsUnitDataList, out List<GoodsUnitData> childGoodsUnitDataList)
        {
            int status = -1;
            string sectionCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
            string message;
            parentGoodsUnitDataList = new List<GoodsUnitData>();
            childGoodsUnitDataList = new List<GoodsUnitData>();

            goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            goodsCndtn.SectionCode = sectionCd;
            goodsCndtn.MakerName = "";
            goodsCndtn.GoodsNoSrchTyp = 0;
            goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
            goodsCndtn.GoodsNo = parentGoodsNo;
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
            goodsCndtn.IsSettingSupplier = 1;
            goodsCndtn.PriceApplyDate = DateTime.Today;
            goodsCndtn.TotalAmountDispWayCd = 0; // 0:総額表示しない
            goodsCndtn.ConsTaxLayMethod = 1; // 1:明細転嫁
            goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:共通設定

            if (iMode == 0)
            {
                // 品番検索(結合検索なし)
                status = this._joinPartsUAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out parentGoodsUnitDataList, out message);
                if (status == 0)
                {
                    GoodsUnitData wkGoodsUnitData = parentGoodsUnitDataList[0];
                    goodsCndtn.GoodsMakerCd = wkGoodsUnitData.GoodsMakerCd;
                    goodsCndtn.GoodsNo = wkGoodsUnitData.GoodsNo;

                    // 品番検索(結合検索有り完全一致)
                    status = this._joinPartsUAcs.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
                    if (status != 0) return status;
                }
                else
                {
                    // 品番検索キャンセルor失敗
                    return status;
                }
            }
            else
            {
                goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
                goodsCndtn.GoodsNo = parentGoodsNo;

                // 品番検索(結合検索有り完全一致)
                status = this._joinPartsUAcs.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
                // 2009.03.26 30413 犬飼 結合元商品の商品マスタ削除チェック >>>>>>START
                //if (status != 0) return status;
                if (status != 0)
                {
                    // 該当品番無し
                    parentGoodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData addGoodsUnitData = new GoodsUnitData();
                    addGoodsUnitData.GoodsMakerCd = parentGoodsMakerCd;
                    addGoodsUnitData.GoodsNo = parentGoodsNo;
                    parentGoodsUnitDataList.Add(addGoodsUnitData);
                }
                // 2009.03.26 30413 犬飼 結合元商品の商品マスタ削除チェック <<<<<<END
            }

            // 商品情報取得時のメーカー、品番設定
            int makerCode = parentGoodsUnitDataList[0].GoodsMakerCd;
            string goodsNo = parentGoodsUnitDataList[0].GoodsNo;

            // --- ADD m.suzuki 2010/08/03 ---------->>>>>
            // ユーザー登録分の結合マスタ抽出・キャッシュ
            JoinPartsU readCndtn = new JoinPartsU();
            readCndtn.EnterpriseCode = _enterpriseCode;
            readCndtn.JoinSourceMakerCode = makerCode;
            readCndtn.JoinSourPartsNoWithH = goodsNo;
            _joinPartsUAcs.Read( readCndtn );
            // --- ADD m.suzuki 2010/08/03 ----------<<<<<

            // 結合先商品情報の取得
            status = this._joinPartsUAcs.SearchGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, GoodsAcs.GoodsKind.ChildJoin, out childGoodsUnitDataList);

            return status;
        }

        /// <summary>
        ///	画面展開処理
        /// </summary>
        /// <param name="goodsUnitData">結合元情報データクラス</param>
        /// <remarks>
        /// <br>Note       : 画面を展開処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DisplayScreen(GoodsUnitData goodsUnitData)
        {
            if (goodsUnitData != null)
            {
                #region ●親品番
                this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;
                #endregion

                #region ●親商品メーカー
                if (goodsUnitData.GoodsName == string.Empty)
                {
                    this.tNedit_GoodsMakerCd.DataText = string.Empty;
                    this.ParentMakerName_tEdit.DataText = string.Empty;
                }
                else
                {
                    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                    this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
                }
                #endregion
            }
        }

        /// <summary>
        ///	画面展開処理(オーバーロード)
        /// </summary>
        /// <param name="rowNo">行番号</param>
        /// <param name="goodsUnitData">結合先商品情報データクラス</param>
        /// <param name="unitPriceCalcRet">単価算出結果</param>
        /// <remarks>
        /// <br>Note       : 画面を展開処理(オーバーロード)します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        //private void DisplayScreen(int rowNo, GoodsUnitData goodsUnitData)
        private void DisplayScreen(int rowNo, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet)
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<
        {
            #region ●グリッドデータ展開

            // グリッドに表示するNoなので行数に１を加える
            int No = rowNo + 1;
            // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
            this._userControl.SetJoinPartsUDataTable(No, goodsUnitData, unitPriceCalcRet);
            // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<

            #endregion
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <returns>結果[true: 正常, false: 異常]</returns>
        /// <remarks>
        /// <br>Note       : 画面を検索処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
        {
            int status = -1;

            #region < 全件検索 >
            if (readCount == 0)
            {
                status = this._joinPartsUAcs.SearchAll(this._enterpriseCode, ref totalCount);
            }
            #endregion

            #region < 検索後処理 >
            switch (status)
            {
                #region -- 正常終了 --
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
                            PG_ID, 		    				    	// アセンブリＩＤまたはクラスＩＤ
                            PG_NM,        						    // プログラム名称
                            "SearchProc", 							// 処理名称
                            TMsgDisp.OPE_GET, 						// オペレーション
                            "読み込みに失敗しました。",    			// 表示するメッセージ
                            status, 								// ステータス値
                            this._joinPartsUAcs,             			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        break;
                    }
                #endregion
            }
            #endregion

            return status;

        }

        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <returns>結果[true: 正常, false: 異常]</returns>
        /// <remarks>
        /// <br>Note       : 画面を登録・更新処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SaveProc()
        {
            int status = -1;

            bool delOnly = false;// 2010/07/14 Add

            #region < 入力チェック >
            Control control = null;
            string message = null;
            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                #region -- エラーメッセージ --
                TMsgDisp.Show(
                    this,                               // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
                    message,                            // 表示するメッセージ
                    0,                                  // ステータス値
                    MessageBoxButtons.OK);              // 表示するボタン
                #endregion

                #region -- フォーカス移動 --
                if (control != null)
                {
                    control.Focus();

                    if (control is TEdit)
                    {
                        ((TEdit)control).SelectAll();
                    }
                    else if (control is TNedit)
                    {
                        ((TNedit)control).SelectAll();
                    }
                }
                #endregion

                return status;
            }
            #endregion

            #region < 登録データ準備処理 >
            // 画面情報をEクラスに格納
            int errorRowNo;
            string errorColNm;
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
            List<JoinPartsU> writeDataList = new List<JoinPartsU>();

            // 有効なデータ行リストを取得
            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

            // エラー行番号が"0"のときのみ正常
            if (errorRowNo == 0)
            {
                // 書き込みを行なうデータクラスのリストを作成する
                for (int i = 0; i < effectDataList.Count; i++)
                {
                    JoinPartsU goodsSet = new JoinPartsU();
                    this.DispToJoinPartsU(effectDataList[i], ref goodsSet);
                    writeDataList.Add(goodsSet);
                }
            }
            if (effectDataList.Count == 0) delOnly = true;  // 2010/07/14 Add
            #endregion

            #region < 物理削除データ準備処理 >
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
            List<JoinPartsU> delDataList = new List<JoinPartsU>();

            // 削除対象データの取得
            this._userControl.GetDeleteData(out deleteDataList);

            // 削除を行なうデータクラスのリストを作成する
            for (int i = 0; i < deleteDataList.Count; i++)
            {
                JoinPartsU goodsSet = new JoinPartsU();
                // 完全削除
                this.DispToJoinPartsU(deleteDataList[i], ref goodsSet);
                delDataList.Add(goodsSet);
            }
            #endregion

            #region < 物理削除処理 >
            // 削除対象があれば該当レコードを削除
            if (deleteDataList.Count != 0)
            {
                status = this._joinPartsUAcs.DeleteUnique(delDataList);
            }
            else
            {
                status = 0;
            }
            #endregion

            // 2010/07/14 Add >>>
            if (!delOnly)
            {
                // 2010/07/14 Add <<<

                Dictionary<string, GoodsUnitData> goodsUnitDataDic;
                _userControl.GetLC_GoodsUnitData(out goodsUnitDataDic);

                // 結合設定書き込み処理
                status = this._joinPartsUAcs.Write(writeDataList, goodsUnitDataDic);

            }   // 2010/07/14 Add

            #region < 登録後処理 >
            switch (status)
            {
                #region -- 通常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    this.SaveSettings(); // ADD 劉超　2013/12/25 FOR Redmine#41737
                    status = 0;
                    break;

                // 重複エラー
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // コード重複
                    TMsgDisp.Show(
                        this, 									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                        PG_ID, 					        		// アセンブリＩＤまたはクラスＩＤ
                        "このコードは既に使用されています。",  	// 表示するメッセージ
                        0, 										// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    if (this.tNedit_GoodsMakerCd.Enabled == true)
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        this.tNedit_GoodsMakerCd.SelectAll();
                    }
                    break;
                #endregion

                #region -- 排他制御 --
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status, true);
                    break;
                #endregion

                #region -- 登録失敗 --
                default:
                    TMsgDisp.Show(
                        this,                                 // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                        PG_ID,                                // アセンブリＩＤまたはクラスＩＤ
                        PG_NM,                                // プログラム名称
                        "SaveProc",                           // 処理名称
                        TMsgDisp.OPE_UPDATE,                  // オペレーション
                        "登録に失敗しました。",               // 表示するメッセージ
                        status,                               // ステータス値
                        this._joinPartsUAcs,                    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,                 // 表示するボタン
                        MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                    break;
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 画面を排他処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
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
                            PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 画面情報格納処理
        /// </summary>
        /// <param name="joinPartsU">結合データクラス</param>
        /// <remarks>
        /// <br>Note       : 画面を格納処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DispToJoinPartsU(ref JoinPartsU joinPartsU)
        {
            joinPartsU.JoinSourceMakerCode = this.tNedit_GoodsMakerCd.GetInt();         // 結合元商品メーカーコード
            joinPartsU.JoinSourPartsNoWithH = this.tEdit_GoodsNo.DataText;              // 結合元商品コード
        }

        /// <summary>
        /// 画面情報格納処理(オーバーロード)
        /// </summary>
        /// <param name="row">セット商品情報入力データテーブル行</param>
        /// <param name="joinPartsU">結合データクラス</param>
        /// <remarks>
        /// <br>Note       : 画面情報を格納処理(オーバーロード)します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DispToJoinPartsU(GoodsSetGoodsDataSet.GoodsSetDetailRow row, ref JoinPartsU joinPartsU)
        {
            joinPartsU.JoinDispOrder = row.Disply;                                              // 結合表示順位
            joinPartsU.JoinSourceMakerCode = this.tNedit_GoodsMakerCd.GetInt();                 // 結合元メーカーコード
            joinPartsU.JoinSourPartsNoWithH = this.tEdit_GoodsNo.DataText;                      // 結合元品番(－付き品番)
            joinPartsU.JoinSourPartsNoNoneH = joinPartsU.JoinSourPartsNoWithH.Replace("-", ""); // 結合元品番(－無し品番)
            joinPartsU.JoinDestMakerCd = int.Parse(row.MakerCode);                              // 結合先メーカーコード
            joinPartsU.JoinDestPartsNo = row.GoodsCode;                                         // 結合先品番
            joinPartsU.JoinQty = double.Parse(row.Qty.ToString());                              // TODO:QTY DataRow→JoinPartsU
            joinPartsU.JoinSpecialNote = row.SetNote;                                           // 結合規格・特記事項
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果[true: OK, false: NG]</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報を不正チェック処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            #region ●結合元商品情報入力チェック

            #region < 商品コードの入力チェック >
            if (this.tEdit_GoodsNo.Text.TrimEnd() == "")
            {
                message = this.ParentGoodsCode_Label.Text + "を入力してください。";
                control = this.tEdit_GoodsNo;
                result = false;
                return result;
            }
            #endregion

            #region < メーカーコードの入力チェック >
            if ((this.tNedit_GoodsMakerCd.Enabled) && (this.tNedit_GoodsMakerCd.GetInt() == 0)) 
            {
                message = this.ParentMakerCode_Label.Text + "を入力してください。";
                control = this.tNedit_GoodsMakerCd;
                result = false;
                return result;
            }
            #endregion

            #region < 品名のチェック >
            if (this.ParentGoodsName_tEdit.Text.TrimEnd() == "")
            {
                message = "結合元商品が商品マスタから削除されています。";
                control = this.tEdit_GoodsNo;
                result = false;
                return result;
            }
            #endregion

            #endregion

            #region ●結合先商品情報入力チェック

            result = _userControl.GridDataCheck(ref control, ref message);

            #endregion

            return result;
        }

        /// <summary>
        /// 画面変更確認処理
        /// </summary>
        /// <returns>チェック結果[true: 変更有, false: 変更無]</returns>
        /// <remarks>
        /// <br>Note       : 画面を変更確認処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private bool CheckScreenChange()
        {
            bool result = false;

            JoinPartsU joinPartsUBefore = new JoinPartsU();
            JoinPartsU joinPartsUAfter = new JoinPartsU();

            // 画面から取得するデータを編集後のデータとする
            this.DispToJoinPartsU(ref joinPartsUAfter);

            #region < 親商品情報比較処理 >
            // 画面表示時(クローン)と比較をして違いがあるかチェックする
            ArrayList DisagreementList = _joinPartsUClone.Compare(joinPartsUAfter);

            if (DisagreementList.Count > 0)
            {
                // 編集有り
                result = true;
                return result;
            }
            #endregion

            #region < セット商品情報比較処理 >
            result = this._userControl.CheckGridChange();
            #endregion

            return result;
        }

        /// <summary>
        /// 詳細グリッド最上位行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最上位行キーダウンイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void GoodsSetDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
        {
            this.tEdit_GoodsNo.Focus();
            this.tEdit_GoodsNo.SelectAll();
        }

        /// <summary>
        /// 詳細グリッド最下層行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 詳細グリッド最下層行キーダウンイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void GoodsSetDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///	ソート用の商品連結データ比較処理
        /// </summary>
        /// <param name="goodsA">商品連結データ(比較元)</param>
        /// <param name="goodsB">商品連結データ(比較先)</param>
        /// <remarks>
        /// <br>Note       : ソート用の商品連結データ比較処理。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private static int CompareGoodsUnitData(GoodsUnitData goodsA, GoodsUnitData goodsB)
        {
            if (goodsA == null)
            {
                if (goodsB == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (goodsB == null)
                {
                    return 1;
                }
                else
                {
                    if (goodsA.OfferKubun == 0 && goodsB.OfferKubun == 0)
                    {
                        return goodsA.JoinDispOrder.CompareTo(goodsB.JoinDispOrder);
                    }
                    else
                    {
                        if (goodsA.OfferKubun != 0 && goodsB.OfferKubun == 0)
                        {
                            return 0;
                        }
                        else
                        {
                            if (goodsA.OfferKubun != 0 && goodsB.OfferKubun != 0)
                            {
                                return goodsA.JoinDispOrder.CompareTo(goodsB.JoinDispOrder);
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベントを行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
            if (this._userControl.uGrid_Details.ActiveCell != null)
            {
                this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this._changeFlg = CheckScreenChange();

                        if (_changeFlg)
                        {
                            #region < データ変更確認 >
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                "登録してもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxDefaultButton.Button1);
                            #endregion

                            if (dialogResult == DialogResult.Yes)
                            {
                                if (SaveProc() != 0)
                                {
                                    return;
                                }

                                // 終了処理
                                this.Close();
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                // 終了処理
                                this.Close();
                            }
                        }
                        else
                        {
                            // 終了処理
                            this.Close();
                        }

                        break;
                    }
                case "ButtonTool_Save":
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            if (SaveProc() != 0)
                            {
                                return;
                            }

                            ScreenClear();

                            // グリッド初期設定処理の呼び出し
                            this._userControl.SetJoinPartsUGrid();

                            // フォーカスを結合コードにして全選択にする
                            this.tEdit_GoodsNo.Focus();
                            this.tEdit_GoodsNo.SelectAll();

                            // 画面の再構築を行なうため
                            this.Initial_timer.Enabled = true;

                            this._prevParentMakerCode = 0;
                            this._prevParentGoodsCode = "";
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        break;
                    }
                case "ButtonTool_Delete":
                    {
                        #region < 完全削除確認 >
                        DialogResult result = TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_QUESTION, // エラーレベル
                            PG_ID,       						// アセンブリＩＤまたはクラスＩＤ
                            "データを削除します。" + "\r\n" +
                            "よろしいですか？", 				// 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OKCancel, 		// 表示するボタン
                            MessageBoxDefaultButton.Button2);	// 初期表示ボタン
                        #endregion

                        if (result == DialogResult.OK)
                        {
                            #region < 物理削除データ準備処理 >
                            // 画面情報をEクラスに格納
                            int errorRowNo;
                            string errorColNm;
                            JoinPartsU goodsSet;
                            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
                            List<JoinPartsU> delDataList = new List<JoinPartsU>();

                            // 有効なデータ行リストを取得
                            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

                            // エラー行番号が"0"のときのみ正常
                            if (errorRowNo == 0)
                            {
                                // 書き込みを行なうデータクラスのリストを作成する
                                for (int i = 0; i < effectDataList.Count; i++)
                                {
                                    goodsSet = new JoinPartsU();
                                    this.DispToJoinPartsU(effectDataList[i], ref goodsSet);
                                    delDataList.Add(goodsSet);
                                }
                            }
                            // 2010/07/14 Add >>>
                            // 削除対象データの取得
                            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
                            this._userControl.GetDeleteData(out deleteDataList);

                            // 削除を行なうデータクラスのリストを作成する
                            for (int i = 0; i < deleteDataList.Count; i++)
                            {
                                goodsSet = new JoinPartsU();
                                // 完全削除
                                this.DispToJoinPartsU(deleteDataList[i], ref goodsSet);
                                delDataList.Add(goodsSet);
                            }
                            // 2010/07/14 Add <<<
                            #endregion

                            #region < 物理削除処理 >
                            int status = this._joinPartsUAcs.Delete(delDataList);
                            #endregion

                            #region < 物理削除後処理 >
                            switch (status)
                            {
                                #region -- 正常終了 --
                                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                    {
                                        break;
                                    }
                                #endregion

                                #region -- 排他制御 --
                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                    {
                                        ExclusiveTransaction(status, true);
                                        return;
                                    }
                                #endregion

                                #region -- 物理削除失敗 --
                                default:
                                    {
                                        // 物理削除
                                        TMsgDisp.Show(
                                            this, 									// 親ウィンドウフォーム
                                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
                                            PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
                                            PG_NM,					    	        // プログラム名称
                                            "Delete_Button_Click", 					// 処理名称
                                            TMsgDisp.OPE_DELETE, 					// オペレーション
                                            "削除に失敗しました。", 		    	// 表示するメッセージ
                                            status, 								// ステータス値
                                            this._joinPartsUAcs, 	    			// エラーが発生したオブジェクト
                                            MessageBoxButtons.OK, 					// 表示するボタン
                                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                                        return;
                                    }
                                #endregion
                            }
                            #endregion

                            #region 初期戻る
                            ScreenClear();

                            // グリッド初期設定処理の呼び出し
                            this._userControl.SetJoinPartsUGrid();

                            //新規登録画面
                            ScreenAccordingToMode(0);

                            this._prevParentMakerCode = 0;
                            this._prevParentGoodsCode = "";

                            #endregion

                        }
                        else
                        {
                            return;
                        }

                        break;
                    }
                case "ButtonTool_New":
                    {
                        this._changeFlg = CheckScreenChange();

                        if (_changeFlg)
                        {
                            #region < データ変更確認 >
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                                "登録してもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxDefaultButton.Button1);
                            #endregion

                            if (dialogResult == DialogResult.Yes)
                            {
                                if (SaveProc() != 0)
                                {
                                    return;
                                }

                                ScreenClear();

                                // グリッド初期設定処理の呼び出し
                                this._userControl.SetJoinPartsUGrid();

                                //新規登録画面
                                ScreenAccordingToMode(0);

                                this._prevParentMakerCode = 0;
                                this._prevParentGoodsCode = "";
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                ScreenClear();

                                // グリッド初期設定処理の呼び出し
                                this._userControl.SetJoinPartsUGrid();

                                //新規登録画面
                                ScreenAccordingToMode(0);

                                this._prevParentMakerCode = 0;
                                this._prevParentGoodsCode = "";
                            }
                        }
                        else
                        {
                            ScreenClear();

                            // グリッド初期設定処理の呼び出し
                            this._userControl.SetJoinPartsUGrid();

                            //新規登録画面
                            ScreenAccordingToMode(0);

                            this._prevParentMakerCode = 0;
                            this._prevParentGoodsCode = "";
                        }

                        break;
                    }
            }
        }

        #endregion

        #region ◆ControlEvent

        /// <summary>
        /// Form.Load イベント (PMKEN09074UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Form.Load イベント (PMKEN09074UA)。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void PMKEN09074UA_Load(object sender, EventArgs e)
        {
            // 画面を構築
            this.ScreenInitialSetting();

            this.panel_Detail.Controls.Add(_userControl);

            // 設定読み込み
            this._userControl.Deserialize(); // ADD 劉超　2013/12/04 FOR Redmine#41447

            // 画面ロード時に表示された親商品情報を編集前データとして保持
            this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;

            Initial_timer.Enabled = true;
        }

        // ADD START 劉超　2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームクロージングイベントを行う。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        private void PMKEN09074UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (NullReferenceException)
            {
            }

            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;

            //今回設定情報の保存(プログラム終了時に実装)
            ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.tToolsManager_MainMenu);
        }

        # region [フォームクローズ前処理]
        /// <summary>
        /// フォームクローズ前処理
        /// </summary>
        /// <remarks>FormClosingイベントだと×ボタン時に抜けてしまうので、Parentでウィンドウメッセージを扱う</remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // フォームを閉じる時(×ボタンも含む)
            //-----------------------------------------
            // ユーザー設定保存(→XML書き込み)
            SaveSettings();
        }
        /// <summary>
        /// ユーザー設定保存処理
        /// </summary>
        private void SaveSettings()
        {
            // グリッドのカラム情報を保存する
            List<ColumnInfo> detailColumnsList;
            this._userControl.SaveGridColumnsSetting(this._userControl.uGrid_Details, out detailColumnsList);
            this._userControl.UserSetting.DetailColumnsList = detailColumnsList;

            // 設定保存
            this._userControl.Serialize();
        }
        # endregion
        // ADD END 劉超　2013/12/04 FOR Redmine#41447 ------<<<<<<

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Timer.Tick イベント イベント(Initial_Timer)。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void Initial_timer_Tick(object sender, EventArgs e)
        {
            Initial_timer.Enabled = false;
            ScreenReconstruction();

            // 明細グリッドセット
            this._userControl.LoadGridColumnsSetting(ref this._userControl.uGrid_Details, this._userControl.UserSetting.DetailColumnsList); // ADD 劉超　2013/12/04 FOR Redmine#41447
        }

        /// <summary>
        ///	Control.ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Control.ChangeFocus イベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                #region ●グリッド内フォーカス移動
                case "uGrid_Details":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this._userControl.uGrid_Details.ActiveCell != null)
                                        {
                                            // TODO:「QTY」への強制フォーカス遷移
                                            CellCoodinate previousCellCoodinate;
                                            if (this._userControl.ReturnKeyDown(out previousCellCoodinate))
                                            {
                                                if (
                                                    this._userControl.uGrid_Details.ActiveCell.Column.Index.Equals(1)   // 移動後のセルが1:「表示順位」
                                                        &&                                                              // ※グリッド側の制御により、次のTabStop可能セル（前の「品名」セル→次の「表示順位」セル）に遷移している
                                                    previousCellCoodinate.Column.Equals(2)                              // 移動前のセルが2:「品名」
                                                )
                                                {
                                                    int rowIndex = this._userControl.uGrid_Details.ActiveCell.Row.Index;
                                                    if (rowIndex > 0)
                                                    {
                                                        int previousRowIndex = rowIndex - 1;
                                                        if (this._userControl.uGrid_Details.Rows[previousRowIndex].Cells["Qty"].TabStop.Equals(Infragistics.Win.DefaultableBoolean.True))
                                                        {
                                                            this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                            this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                        }
                                                    }
                                                }

                                                e.NextCtrl = null;
                                            }
                                            else
                                            {
                                            }
                                        }

                                        break;
                                    }
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
                                        if ((this._userControl.uGrid_Details.ActiveCell.Column.Index.Equals(1)) && (this._userControl.uGrid_Details.ActiveCell.Row.Index.Equals(0)))
                                        {
                                            e.NextCtrl = this.tEdit_GoodsNo;
                                            if (!this.tEdit_GoodsNo.Enabled)
                                            {
                                            }
                                        }
                                        else
                                        {   // MEMO:[Shift]+[Tab]
                                            if (this._userControl.ReturnKeyDown2())
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else
                                            {
                                                // 表示順 0 の行へ遷移しようとした場合
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                                if (!this.tEdit_GoodsNo.Enabled)
                                                {
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region ●メーカー情報検索
                case "tNedit_GoodsMakerCd":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        int parentMakerCode = this.tNedit_GoodsMakerCd.GetInt();

                        if (this._prevParentMakerCode == parentMakerCode)
                        {
                            // 編集前と同じなら処理を行なわない
                            return;
                        }
                        #endregion

                        #region < ゼロ入力チェック >
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            // メーカーデータクラス
                            MakerUMnt makerUMnt;

                            // メーカー情報取得
                            this._joinPartsUAcs.GetMaker(this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt(), out makerUMnt);

                            #region < 画面表示処理 >

                            if (makerUMnt != null)
                            {
                                #region -- 取得データ展開 --
                                // メーカー情報画面表示
                                this.ParentMakerName_tEdit.DataText = makerUMnt.MakerName;
                                #endregion
                            }
                            else
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_GoodsMakerCd.Clear();
                                this.ParentMakerName_tEdit.Clear();
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.ParentMakerName_tEdit.Clear();
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                        this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
                        #endregion

                        break;
                    }

                #endregion

                #region ●商品情報検索
                case "tEdit_GoodsNo":
                    {
                        // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------>>>>>
                        if (e.NextCtrl.Name == "uButton_StoreChange")
                        {
                            //[結合先]ボタン許可制御処理
                            _userControl.GridButtonPermissionControl(true);
                        }
                        // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------<<<<<

                        #region < 編集チェック >
                        // 変数保持
                        string parentGoodsCode = this.tEdit_GoodsNo.DataText;

                        if (this._prevParentGoodsCode == parentGoodsCode)
                        {
                            // 編集前と同じなら処理を行なわない
                            return;
                        }
                        #endregion

                        #region < 空入力チェック >
                        if (this.tEdit_GoodsNo.DataText != "")
                        {
                            string searchCode;
                            // 検索の種類を取得
                            int searchType = this._userControl.GetSearchType(this.tEdit_GoodsNo.DataText, out searchCode);

                            List<GoodsUnitData> parentGoodsUnitDataList;
                            List<GoodsUnitData> childGoodsUnitDataList;
                            string parentGoodsNo = this.tEdit_GoodsNo.DataText;
                            int parentGoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

                            int status = this.GetGoodSetData(0, parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);
                            // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
                            List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                            unitPriceCalcRetList = this._userControl.CalclationUnitPrice(childGoodsUnitDataList); // 原単価取得
                            // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<

                            #region < 画面表示処理 >
                            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (parentGoodsUnitDataList != null) && (parentGoodsUnitDataList.Count > 0))
                            {
                                #region -- 結合元商品情報を展開 --
                                this.DisplayScreen(parentGoodsUnitDataList[0]);
                                #endregion

                                #region -- 結合先商品情報を展開 --
                                childGoodsUnitDataList.Sort(CompareGoodsUnitData);
                                for (int i = 0; i < childGoodsUnitDataList.Count; i++)
                                {
                                    // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
                                    //DisplayScreen(i, childGoodsUnitDataList[i]);
                                    UnitPriceCalcRet UnitPriceCalcRet = this._userControl.SearchUnitPriceCalcRet(2, unitPriceCalcRetList, childGoodsUnitDataList[i]);
                                    DisplayScreen(i, childGoodsUnitDataList[i], UnitPriceCalcRet);
                                    // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<
                                }
                                #endregion

                                // UI画面のモード変更チェック
                                if (this._joinPartsUAcs.CheckModeChange(parentGoodsUnitDataList[0]))
                                {
                                    // 結合マスタに登録済みの商品
                                    this.Mode_Label.Text = UPDATE_MODE;
                                    this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = true;
                                    this.tEdit_GoodsNo.Enabled = false;
                                    this.tNedit_GoodsMakerCd.Enabled = false;
                                    //this.ParentMakerGuide_Button.Enabled = false;

                                    // 削除ボタンの使用不可
                                    // -- DEL 2009/10/30 ------------->>>
                                    //this._userControl.DeleteBtnFlag = false;
                                    //this._userControl.uButton_RowDeleteEnabled(false);
                                    // -- DEL 2009/10/30 -------------<<<
                                }

                                // -- ADD 2009/10/30 ------------------------>>>
                                if ((childGoodsUnitDataList.Count > 0) && (childGoodsUnitDataList[0] as GoodsUnitData).JoinDispOrder >= 100)
                                {
                                    this._userControl.DeleteBtnFlag = false;
                                    this._userControl.uButton_RowDeleteEnabled(false);
                                }
                                else
                                {
                                    this._userControl.DeleteBtnFlag = true;
                                    this._userControl.uButton_RowDeleteEnabled(true);
                                }
                                // -- ADD 2009/10/30 ------------------------<<<
                            }
                            else if (status == -1)
                            {
                                this.tEdit_GoodsNo.Clear();
                                this.ParentGoodsName_tEdit.Clear();

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                break;
                            }
                            else
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "品番 [" + searchCode + "] に該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // 商品情報クリア
                                this.tEdit_GoodsNo.Clear();
                                this.ParentGoodsName_tEdit.Clear();

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            // 商品コードを元に戻す
                            this.tEdit_GoodsNo.DataText = "";
                            // 商品名称のクリア
                            this.ParentGoodsName_tEdit.DataText = "";

                            // ADD 2008/11/06 不具合対応[7513] 品番クリア時にメーカーもクリア ---------->>>>>
                            this.tNedit_GoodsMakerCd.Clear();
                            this.ParentMakerName_tEdit.Clear();
                            // ADD 2008/11/06 不具合対応[7513] 品番クリア時にメーカーもクリア ----------<<<<<
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 親商品情報が編集されたので編集前データとして保持
                        this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                        this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
                        #endregion

                        // ADD 2008/11/25 不具合対応[6564]↓ 結合先を新規追加時は「QTY」へ強制フォーカス遷移
                        this._userControl.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                        break;
                    }
                #endregion
            }
            // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------>>>>>
            if (e.NextCtrl != null)
            {
                switch(e.NextCtrl.Name)
                {
                    case "tEdit_GoodsNo":
                        {
                            _userControl.GridButtonPermissionControl(false);
                            break;
                        }
                    case "uButton_StoreChange":
                        {
                            _userControl.GridButtonPermissionControl(true);
                            break;
                        }
                
                }
            }
            // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------<<<<<
        }

        /// <summary>
        /// Control.Click イベント(ParentGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Control.Click イベント(ParentGoodsGuide_Button) イベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ParentGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsGuide = new MAKHN04110UA();
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            // 検索条件の設定
            goodsCndtn.EnterpriseCode = _enterpriseCode;
            goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // 商品検索ガイドの起動
            goodsGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);

            // 何も選択されていなかったら
            if (goodsUnitData == null)
            {
                return;
            }

            // 結合元商品情報画面表示
            this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
            this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
            this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
            this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;

            #region < 編集前データ保持 >
            // 編集された結合元商品情報を編集前データとして保持
            this._prevParentMakerCode = this.tNedit_GoodsMakerCd.GetInt();
            this._prevParentGoodsCode = this.tEdit_GoodsNo.DataText;
            #endregion
        }

        /// <summary>
        /// ValueChanged イベント(tNedit_GoodsMakerCd)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ValueChanged イベント(tNedit_GoodsMakerCd)イベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void tNedit_GoodsMakerCd_ValueChanged(object sender, EventArgs e)
        {
            this._userControl.JoinSourceMakerCode = tNedit_GoodsMakerCd.GetInt();
        }

        /// <summary>
        /// ValueChanged イベント(tEdit_GoodsNo)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ValueChanged イベント(tEdit_GoodsNo)イベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void tEdit_GoodsNo_ValueChanged(object sender, EventArgs e)
        {
            this._userControl.JoinSourPartsNoWithH = tEdit_GoodsNo.DataText;
        }

        // ------------ ADD 譚洪 2013/12/04 --------------- >>>>
        /// <summary>
        /// SizeChanged イベント()
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : SizeChanged イベント()イベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        private void PMKEN09074UA_SizeChanged(object sender, EventArgs e)
        {
            this.panel_Detail.Width = this.Width - this.Width / 19;
            this.ultraLabel2.Width = this.Width - this.Width / 50 - 1;
            this.ultraLabel3.Width = this.Width - this.Width / 50;
            this.Mode_Label.Location = new Point(this.ultraLabel2.Location.X + this.ultraLabel2.Width - this.Mode_Label.Width, this.Mode_Label.Location.Y);

            this.panel_Detail.Height = this.Height - this.panel_Detail.Location.Y - this.ultraStatusBar1.Height - 73;
            this.ultraLabel3.Height = this.Height - this.panel_Detail.Location.Y - this.ultraStatusBar1.Height - 55;
            this.ultraLabel4.Height = this.Height - this.panel_Detail.Location.Y - this.ultraStatusBar1.Height - 55;

            this._userControl.SettingGridWidth(this.panel_Detail.Width, this.panel_Detail.Height);
        }
        // ------------ ADD 譚洪 2013/12/04 --------------- <<<<
        #endregion
    }
    // ---- ADD 2010/06/08 ----------<<<<<
    #endregion
}