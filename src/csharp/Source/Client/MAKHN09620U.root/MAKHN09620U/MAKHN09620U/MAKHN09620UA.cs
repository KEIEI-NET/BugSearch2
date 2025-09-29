//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : セットマスタ
// プログラム概要   : セットマスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008.08.01  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009/02/06  修正内容 : 各種速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009/02/09  修正内容 : 検索条件追加設定(速度アップの為)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/03/16  修正内容 : 障害対応12345
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 削除商品の商品情報を非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/06/08  修正内容 : 障害・改良対応7月リリース分
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2010/12/03   修正内容 :１．明細行を全て削除後に、ヘッダ部の削除ボタンを押下するとエラーが発生する不具合の修正
//                                  ２．複数行の明細があるセット品の明細の一部を行削除し、ヘッダ部の削除ボタンを実行した場合の削除処理の不正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/08/04  修正内容 : 起動速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/10/10  修正内容 : Redmine#32620 №1559、セットマスタでエラーが発生する件の調査
//                                : 検索結果の子商品情報データリストの中に品名が長すぎデータがあると、エラーが発生することの対応
//                                : GoodsSetGoodsDataSet.xsd改修のみ、本体ソース改修無し
//----------------------------------------------------------------------------//
// 管理番号  11175121-00 作成担当 : gaocheng
// 修 正 日  2015/05/08  修正内容 : ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正
//                                : ツールバーでショートカットキーの修正
//----------------------------------------------------------------------------//
// 管理番号  11175121-00 作成担当 : gaocheng
// 修 正 日  2015/07/02  修正内容 : ウィンドウ位置とサイズの記憶功能の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Data;
using System.Collections;
using System.Drawing;
using Broadleaf.Application.Resources; // ADD gaocheng　2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品セットフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Note       : 商品セットの設定を行います。</br>
    /// <br>Programmer : 30005 木建　翼</br>
    /// <br>Date       : 2007.05.07</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 親商品情報を編集しないでフォーカス移動をすると、検索が実行されないよう </br>
    /// <br>           : に変更。                                                               </br>
    /// <br>Programmer : 30005 木建　翼                                                         </br>
    /// <br>Date       : 2007.06.05                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : DC.NS用に変更する(変更点が多すぎるため変更コメントは残しません)        </br>
    /// <br>Programmer : 20081 疋田　勇人                                                       </br>
    /// <br>Date       : 2007.09.26                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : PM.NS対応                                                              </br>
    /// <br>Programmer : 30413 犬飼                                                             </br>
    /// <br>Date       : 2008.08.01                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.02.06 20056 對馬 大輔</br>
    /// <br>           : 　各種速度アップ対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.02.09 20056 對馬 大輔</br>
    /// <br>           : 　検索条件追加設定(速度アップの為)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009/03/16 30452 上野 俊治</br>
    /// <br>           : 　障害対応12345</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2010/06/08 譚洪</br>
    /// <br>           : 障害・改良対応7月リリース分</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2010/08/04 22018 鈴木 正臣</br>
    /// <br>           : 起動速度アップ対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2012/10/10 wangf</br>
    /// <br>           : 10801804-00、Redmine#32620 №1559、セットマスタでエラーが発生する件の調査</br>
    /// <br>           : 検索結果の子商品情報データリストの中に品名が長すぎデータがあると、エラーが発生することの対応</br>
    /// <br>           : GoodsSetGoodsDataSet.xsd改修のみ、本体ソース改修無し</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/05/08 gaocheng</br>
    /// <br>           : ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正</br>
    /// <br>           : ツールバーでショートカットキーの修正</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>UpdateNote : 2015/07/02 gaocheng</br>
    /// <br>           : ウィンドウ位置とサイズの記憶功能の対応</br>
    /// <br>------------------------------------------------------------------------------------</br>  
    /// </remarks>
    #region DEL 2010/06/08
    // ------ DEL 2010/06/08 ---------->>>>>
    //    public partial class MAKHN09620UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
//    {
//        #region ◆Constractor

//        /// <summary>
//        /// 商品セットフォームクラスコンストラクタ
//        /// </summary>
//        /// <remarks>
//        /// <br>Note       : 商品セットフォームクラスの新しいインスタンスを初期化します。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.07</br>
//        /// </remarks>
//        public MAKHN09620UA()
//        {
//            InitializeComponent();

//            // 2008.08.04 30413 犬飼 プロパティ追加 >>>>>>START
//            if (LoginInfoAcquisition.Employee != null)
//            {
//                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
//            }
//            // 2008.08.04 30413 犬飼 プロパティ追加 <<<<<<END

//            // 商品セットマスタアクセスクラスインスタンス化
//            _goodsSetAcs = new GoodsSetAcs();
//            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//            //// ユーザーコントロールクラスインスタンス化
//            //_userControl = new MAKHN09620UB();
//            // ユーザーコントロールクラスインスタンス化
//            _userControl = new MAKHN09620UB(_goodsSetAcs);
//            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//            // プロパティ初期値設定
//            this._canPrint = false;
//            this._canNew = true;
//            this._canDelete = true;
//            // 2008.08.20 30413 犬飼 プロパティ追加 >>>>>>START
//            //this._canLogicalDeleteDataExtraction = true;
//            this._canLogicalDeleteDataExtraction = false;
//            // 2008.08.20 30413 犬飼 プロパティ追加 <<<<<<END
//            this._canClose = true;		// デフォルト:true固定
//            this._defaultAutoFillToColumn = false;
//            this._canSpecificationSearch = false;

//            // 企業コードを取得する
//            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

//            // 変数初期化
//            this._dataIndex = -1;
//            this._changeFlg = false;
//            this._indexBuf = -2;

//            // Eventの設定
//            this._userControl.GridKeyDownTopRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownTopRow);
//            this._userControl.GridKeyDownButtomRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownButtomRow);

//        }

//        #endregion

//        #region ◆Public Members

//        /// <summary>クローズ可能・不可能プロパティ</summary>
//        /// <value>クローズできるかの判定</value>
//        /// <remarks></remarks>
//        public bool _canClose;

//        /// <summary>デリート可能・不可能プロパティ</summary>
//        /// <value>デリートできるかの判定</value>
//        /// <remarks></remarks>
//        public bool _canDelete;

//        /// <summary>論理削除可能・不可能プロパティ</summary>
//        /// <value>論理削除できるかの判定</value>
//        /// <remarks></remarks>
//        public bool _canLogicalDeleteDataExtraction;

//        /// <summary>登録可能・不可能プロパティ</summary>
//        /// <value>登録できるかの判定</value>
//        /// <remarks></remarks>
//        public bool _canNew;

//        /// <summary>印刷可能・不可能プロパティ</summary>
//        /// <value>印刷できるかの判定</value>
//        /// <remarks></remarks>
//        public bool _canPrint;

//        /// <summary>件数指定抽出可能・不可能プロパティ</summary>
//        /// <value>件数指定抽出できるかの判定</value>
//        /// <remarks></remarks>
//        public bool _canSpecificationSearch;

//        /// <summary>データインデックスプロパティ</summary>
//        /// <value>選択データのインデックス</value>
//        /// <remarks></remarks>
//        public int _dataIndex;

//        /// <summary>自動サイズ調整</summary>
//        /// <value>自動サイズ調整できるかの判定</value>
//        /// <remarks></remarks>
//        public bool _defaultAutoFillToColumn;

//        #endregion

//        # region ◆Private Members

//        // 商品セットアクセスクラス
//        private GoodsSetAcs _goodsSetAcs;
//        // ユーザコントロールクラス
//        private MAKHN09620UB _userControl;
//        // 企業コード
//        private string _enterpriseCode;

//        // 2008.08.04 30413 犬飼 プロパティ追加 >>>>>>START
//        // ログイン従業員
//        private Employee _loginEmployee = null;
//        // 2008.08.04 30413 犬飼 プロパティ追加 <<<<<<END

//        private static GoodsSet _goodsSetClone;

//        private int _indexBuf;
//        private bool _changeFlg;

//        private ImageList _imageList24;
//        private ImageList _imageList16;

//        // 編集モード
//        private const string INSERT_MODE = "新規モード";
//        private const string REFER_MODE = "参照モード";
//        private const string UPDATE_MODE = "更新モード";
//        private const string DELETE_MODE = "削除モード";

//        private const string PG_ID = "MAKHN09620U";
//        private const string PG_NM = "セットマスタ";

//        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//        // 編集前データ保持
//        private int _prevParentMakerCode;
//        private string _prevParentGoodsCode;
//        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05 T-Kidate END

//        # endregion

//        # region ◆Events
//        /// <summary>
//        /// 画面非表示イベント
//        /// </summary>
//        /// <remarks>
//        /// 画面が非表示状態になった際に発生します。
//        /// </remarks>
//        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

//        # endregion

//        # region ◆Main
//        /// <summary>
//        /// アプリケーションのメイン エントリ ポイントです。
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            System.Windows.Forms.Application.Run(new MAKHN09620UA());
//        }
//        # endregion

//        # region ◆Properties

//        /// <summary>画面終了設定プロパティ</summary>
//        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
//        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
//        public bool CanClose
//        {
//            get { return _canClose; }
//            set { _canClose = value; }
//        }

//        /// <summary>削除可能設定プロパティ</summary>
//        /// <value>削除が可能かどうかの設定を取得します。</value>
//        public bool CanDelete
//        {
//            get { return _canDelete; }
//            set { _canDelete = value; }
//        }

//        /// <summary>
//        /// 論理削除データの抽出が可能かどうかの設定を取得します。
//        /// </summary>
//        public bool CanLogicalDeleteDataExtraction
//        {
//            get { return _canLogicalDeleteDataExtraction; }
//        }

//        /// <summary>新規登録可能設定プロパティ</summary>
//        /// <value>新規登録が可能かどうかの設定を取得します。</value>
//        public bool CanNew
//        {
//            get { return _canNew; }
//        }

//        /// <summary>
//        /// 印刷可能かどうかの設定を取得します。
//        /// </summary>
//        public bool CanPrint
//        {
//            get { return _canPrint; }
//        }

//        /// <summary>件数指定抽出可能設定プロパティ</summary>
//        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
//        public bool CanSpecificationSearch
//        {
//            get { return _canSpecificationSearch; }
//        }

//        /// <summary>
//        /// データセットの選択データインデックスを取得または設定します。
//        /// </summary>
//        public int DataIndex
//        {
//            get { return _dataIndex; }
//            set { _dataIndex = value; }
//        }

//        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
//        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
//        public bool DefaultAutoFillToColumn
//        {
//            get { return _defaultAutoFillToColumn; }
//            set { _defaultAutoFillToColumn = value; }
//        }

//        # endregion

//        # region ◆Public Methods

//        /// <summary>
//        /// バインドデータセット取得処理
//        /// </summary>
//        /// <param name="bindDataSet">グリッドリッド用データセット</param>
//        /// <param name="tableName">テーブル名称</param>
//        /// <remarks>
//        /// Note       : グリッドにバインドさせるデータセットを取得します。<br />
//        /// Programmer : 30005 木建　翼<br />
//        /// Date       : 2007.05.07<br />
//        /// </remarks>
//        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
//        {
//            bindDataSet = this._goodsSetAcs.GoodsSetDataSet;
//            tableName = GoodsSetAcs.GOODSSET_TABLE;
//        }

//        /// <summary>
//        ///	データ検索処理 
//        /// </summary>
//        /// <param name="totalCount">全該当件数</param>
//        /// <param name="readCount">抽出対象件数</param>
//        /// <returns>ステータス</returns>
//        /// <remarks>
//        /// Note			:	先頭から指定件数分のデータを検索し、
//        ///						抽出結果を展開し全該当件数,読込件数を返します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        public int Search(ref int totalCount, int readCount)
//        {
//            int status = 0;

//            if (readCount == 0)
//            {
//                status = this._goodsSetAcs.SearchAll(this._enterpriseCode, ref totalCount);
//            }

//            switch (status)
//            {
//                // 全件取得メソッドの結果が"正常終了"のとき
//                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//                    {
//                        break;
//                    }
//                case (int)ConstantManagement.DB_Status.ctDB_EOF:
//                    {
//                        status = 0;
//                        break;
//                    }

//                default:
//                    {
//                        TMsgDisp.Show(
//                            this, 									// 親ウィンドウフォーム
//                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
//                            PG_ID, 			        				// アセンブリＩＤまたはクラスＩＤ
//                            PG_NM,            						// プログラム名称
//                            "Search", 								// 処理名称
//                            TMsgDisp.OPE_GET, 						// オペレーション
//                            "読み込みに失敗しました。",    			// 表示するメッセージ
//                            status, 								// ステータス値
//                            this._goodsSetAcs,      				// エラーが発生したオブジェクト
//                            MessageBoxButtons.OK, 					// 表示するボタン
//                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
//                        break;
//                    }
//            }

//            return status;
//        }

//        /// <summary>
//        ///	ネクストデータ検索処理(未実装)
//        /// </summary>
//        /// <param name="readCount">抽出対象件数</param>
//        /// <returns>ステータス</returns>
//        /// <remarks>
//        /// Note			:	指定した件数分のネクストデータを検索します。<br />
//        /// Programmer		:	木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        public int SearchNext(int readCount)
//        {
//            //未実装
//            return 9;
//        }

//        /// <summary>
//        ///	データ削除処理(論理削除)
//        /// </summary>
//        /// <returns>ステータス</returns>
//        /// <remarks>
//        /// Note			:	選択中のデータを削除します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        public int Delete()
//        {
//            // 2008.08.20 30413 犬飼 論理削除から物理削除に変更 >>>>>>START
//            //#region < 論理削除データ準備処理 >
//            //int status = 0;
//            //GoodsSet goodsSet; 
//            //List<GoodsSet> delDataList = new List<GoodsSet>();

//            //// 親メーカーコードと親品番でフィルタをかけ、関連するセット商品情報を取得する
//            //int parentGoodsMakerCd = (int)this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSMAKERCD_TITLE];
//            //string parentGoodsNo = (string)this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSNO_TITLE];

//            //this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.RowFilter = GoodsSetAcs.PARENTGOODSMAKERCD_TITLE + " = '" + parentGoodsMakerCd + "' AND " +
//            //                                                                                                         GoodsSetAcs.PARENTGOODSNO_TITLE + " = '" + parentGoodsNo + "'"; 

//            //int cnt = this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.Count;

//            //for (int i = 0;i < cnt; i++)
//            //{
//            //    goodsSet = new GoodsSet();
//            //    this.GetGridData(ref goodsSet);

//            //    goodsSet.SubGoodsMakerCd = (int)this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView[i][GoodsSetAcs.SUBGOODSMAKERCD_TITLE];
//            //    goodsSet.SubGoodsNo = (string)this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView[i][GoodsSetAcs.SUBGOODSNO_TITLE];

//            //    delDataList.Add(goodsSet);
//            //}
//            //#endregion

//            //#region < 論理削除処理 >
//            //status = this._goodsSetAcs.LogicalDelete(delDataList);
//            //#endregion

//            //#region < 論理削除後処理 >
//            //switch (status)
//            //{
//            //    #region -- 正常終了 --
//            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//            //        {
//            //            break;
//            //        }
//            //    #endregion

//            //    #region -- 論理削除失敗 --
//            //    default:
//            //        {
//            //            // 論理削除失敗
//            //            TMsgDisp.Show(
//            //                this, 									// 親ウィンドウフォーム
//            //                emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
//            //                PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
//            //                PG_NM,						            // プログラム名称
//            //                "Delete", 								// 処理名称
//            //                TMsgDisp.OPE_HIDE, 						// オペレーション
//            //                "削除に失敗しました。", 				// 表示するメッセージ
//            //                status, 								// ステータス値
//            //                this._goodsSetAcs, 					    // エラーが発生したオブジェクト
//            //                MessageBoxButtons.OK, 					// 表示するボタン
//            //                MessageBoxDefaultButton.Button1);		// 初期表示ボタン

//            //            CloseForm(DialogResult.Cancel);
//            //            return status;
//            //        }
//            //    #endregion
//            //}
//            //#endregion
//            #region < 物理削除データ準備処理 >
//            int status = 0;
//            GoodsSet goodsSet;
//            List<GoodsSet> delDataList = new List<GoodsSet>();

//            // 親メーカーコードと親品番でフィルタをかけ、関連するセット商品情報を取得する
//            int parentGoodsMakerCd = (int)this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSMAKERCD_TITLE];
//            string parentGoodsNo = (string)this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSNO_TITLE];

//            this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.RowFilter = GoodsSetAcs.PARENTGOODSMAKERCD_TITLE + " = '" + parentGoodsMakerCd + "' AND " +
//                                                                                                                     GoodsSetAcs.PARENTGOODSNO_TITLE + " = '" + parentGoodsNo + "'";

//            int cnt = this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.Count;

//            for (int i = 0; i < cnt; i++)
//            {
//                goodsSet = new GoodsSet();
//                this.GetGridData(ref goodsSet);

//                goodsSet.SubGoodsMakerCd = (int)this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView[i][GoodsSetAcs.SUBGOODSMAKERCD_TITLE];
//                goodsSet.SubGoodsNo = (string)this._goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView[i][GoodsSetAcs.SUBGOODSNO_TITLE];

//                delDataList.Add(goodsSet);
//            }
//            #endregion

//            #region < 物理削除処理 >
//            status = this._goodsSetAcs.Delete(delDataList);
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
//                        return status;
//                    }
//                #endregion

//                #region -- 物理削除失敗 --
//                default:
//                    {
//                        // 物理削除失敗
//                        TMsgDisp.Show(
//                            this, 									// 親ウィンドウフォーム
//                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
//                            PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
//                            PG_NM,						            // プログラム名称
//                            "Delete", 								// 処理名称
//                            TMsgDisp.OPE_HIDE, 						// オペレーション
//                            "完全削除に失敗しました。", 			// 表示するメッセージ
//                            status, 								// ステータス値
//                            this._goodsSetAcs, 					    // エラーが発生したオブジェクト
//                            MessageBoxButtons.OK, 					// 表示するボタン
//                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

//                        CloseForm(DialogResult.Cancel);
//                        return status;
//                    }
//                #endregion
//            }
//            #endregion
//            // 2008.08.20 30413 犬飼 論理削除から物理削除に変更 <<<<<<END

//            return status;
//        }

//        /// <summary>
//        ///	印刷処理
//        /// </summary>
//        /// <returns>ステータス</returns>
//        /// <remarks>
//        /// Note			:	印刷処理を実行します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        public int Print()
//        {
//            return 0;
//        }

//        /// <summary>
//        ///	グリッド列外観情報取得処理
//        /// </summary>
//        /// <returns>グリッド列外観情報格納Hashtable</returns>
//        /// <remarks>
//        /// Note			:	各列の外見を設定するクラスを格納したHashtableを
//        ///						取得します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        public Hashtable GetAppearanceTable()
//        {
//            Hashtable appearanceTable = new Hashtable();

//            // 2008.08.04 30413 犬飼 グリッド列設定変更 >>>>>>START
//            #region ■グリッド列設定 <<<<<< 変更前
//            //******************
//            // *①削除日
//            // *②論理削除区分
//            // *③親商品メーカーコード
//            // *④親商品メーカー名称
//            // *⑤親商品コード
//            // *⑥親商品名称
//            // *⑦表示順位
//            // *⑧メーカーコード
//            // *⑨メーカー名称
//            // *⑩商品コード
//            // *⑪商品名称
//            // *⑫数量
//            // *⑬特記事項
//            // *⑭カタログ図番
//            // ******************/

//            //appearanceTable.Add(GoodsSetAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
//            //appearanceTable.Add(GoodsSetAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.PARENTGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.PARENTGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.PARENTGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.PARENTGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.DISPLAYORDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.SUBGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.SUBGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.SUBGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.SUBGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.CNTFL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.SETSPECIALNOTE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.CATALOGSHAPENO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.CHILDPLURALGOODS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            #endregion

//            #region ■グリッド列設定
//            /******************
//             *①削除日
//             *　論理削除区分
//             *②複数
//             *③親品番
//             *④親品名
//             *　親商品メーカーコード
//             *⑤親商品メーカー名称
//             *⑥品番
//             *⑦品名
//             *　メーカーコード
//             *⑧メーカー名称
//             *⑨ＱＴＹ(数量)
//             *　表示順位
//             *⑩セット規格・特記事項
//             *⑪カタログ図番
//             *　提供区分
//             *⑫提供区分名称
//             ******************/

//            //appearanceTable.Add(GoodsSetAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
//            //appearanceTable.Add(GoodsSetAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.CHILDPLURALGOODS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.PARENTGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.PARENTGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.PARENTGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.PARENTGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.SUBGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.SUBGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.SUBGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.SUBGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.CNTFL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.DISPLAYORDER_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.SETSPECIALNOTE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            appearanceTable.Add(GoodsSetAcs.CATALOGSHAPENO_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
//            //appearanceTable.Add(GoodsSetAcs.DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//            #endregion
//            // 2008.08.04 30413 犬飼 グリッド列設定変更 <<<<<<END

//            return appearanceTable;
//        }

//        #endregion

//        #region ◆Private Methods

//        /// <summary>
//        ///	画面初期設定処理
//        /// </summary>
//        /// <remarks>
//        /// Note			:	画面の初期設定を行います。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        private void ScreenInitialSetting()
//        {
//            // アイコン設定
//            this._imageList24 = IconResourceManagement.ImageList24;
//            this._imageList16 = IconResourceManagement.ImageList16;

//            // ガイドボタンのアイコン設定
//            this.ParentMakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
//            // 2008.08.06 30413 犬飼 商品ガイドボタンの削除 >>>>>>START
//            //this.ParentGoodsGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
//            // 2008.08.06 30413 犬飼 商品ガイドボタンの削除 <<<<<<END

//            // 処理ボタンのアイコン設定
//            this.Ok_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.SAVE];         // 保存ボタン
//            this.Cancel_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.CLOSE];    // 閉じるボタン
//            this.Revive_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.REVIVAL];  // 復活ボタン
//            this.Delete_Button.Appearance.Image = this._imageList24.Images[(int)Size24_Index.DELETE];   // 完全削除ボタン
//        }

//        /// <summary>
//        ///	画面クリア処理
//        /// </summary>
//        /// <remarks>
//        /// Note			:	画面をクリアします。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        ///</remarks>
//        private void ScreenClear()
//        {
//            this.ParentMakerCode_tNedit.Clear();
//            this.ParentMakerName_tEdit.Clear();
//            this.ParentGoodsCode_tEdit.Clear();
//            this.ParentGoodsName_tEdit.Clear();

//            // 編集前情報をクリア
//            this._prevParentMakerCode = 0;
//            this._prevParentGoodsCode = "";
//        }

//        /// <summary>
//        /// フォームクローズ処理
//        /// </summary>
//        /// <param name="dialogResult">ダイアログ結果</param>
//        /// <remarks>
//        /// Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。<br />
//        /// Programmer : 30005 木建　翼<br />
//        /// Date       : 2007.05.07<br />
//        /// </remarks>
//        private void CloseForm(DialogResult dialogResult)
//        {
//            // 画面非表示イベント
//            if (UnDisplaying != null)
//            {
//                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
//                UnDisplaying(this, me);
//            }

//            this.DialogResult = dialogResult;

//            this._indexBuf = -2;

//            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
//            // フォームを非表示化する。
//            if (this._canClose == true)
//            {
//                this.Close();
//            }
//            else
//            {
//                this.Hide();
//            }
//        }

//        /// <summary>
//        ///	画面再構築処理
//        /// </summary>
//        /// <remarks>
//        /// Note			:	モードに基づいて入力画面を再構築します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        private void ScreenReconstruction()
//        {
//            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//            //GoodsSetAcs goodsSetAcs = new GoodsSetAcs();
//            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//            #region < 商品セットGrid選択チェック >
//            if (this.DataIndex < 0)
//            {
//                #region -- Grid未選択 --

//                // セット商品情報表示データテーブルをクリア
//                this._userControl.ClearGoodsSetDataTable();
//                // グリッド初期設定処理の呼び出し
//                this._userControl.SetGoodsSetGrid();

//                //新規登録画面
//                ScreenAccordingToMode(0);

//                #endregion
//            }

//            else
//            {
//                #region -- Grid選択済 --

//                // 2008.08.20 30413 犬飼 論理削除の関連処理を削除 >>>>>>START
//                //// 画面表示切替のため論理削除区分を取得
//                //int logicalDeleteCode = (int)_goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.LOGICALDELETE_TITLE];
//                // 2008.08.20 30413 犬飼 論理削除の関連処理を削除 <<<<<<END

//                // 品番でテーブルにフィルタをかけるために保持する
//                int parentGoodsMakerCd = (int)_goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSMAKERCD_TITLE];
//                string parentGoodsNo = (string)_goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSNO_TITLE];

//                #region < グリッド初期化 >
//                // セット商品情報表示データテーブルをクリア
//                this._userControl.ClearGoodsSetDataTable();
//                // グリッド初期設定処理の呼び出し
//                this._userControl.SetGoodsSetGrid();
//                #endregion

//#if false
//                #region < データ画面展開処理 >
//                // 親商品情報に関連したセット商品情報のデータビュー
//                _goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.RowFilter = GoodsSetAcs.PARENTGOODSMAKERCD_TITLE + " = '" + parentGoodsMakerCd + "' AND " +
//                                                                                                                    GoodsSetAcs.PARENTGOODSNO_TITLE + " = '" + parentGoodsNo + "'"; 

//                // 2008.08.04 30413 犬飼 データビューをソート >>>>>>START
//                // 提供区分＋品番＋メーカーコード
//                _goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.Sort = GoodsSetAcs.DIVISION_TITLE + " asc, " +
//                                                                                                               GoodsSetAcs.SUBGOODSNO_TITLE + " asc, " + GoodsSetAcs.SUBGOODSMAKERCD_TITLE + " asc";
//                // 2008.08.04 30413 犬飼 データビューをソート <<<<<<END
                
//                int rowCount = _goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView.Count;
 
//                for (int i = 0; i < rowCount; i++)
//                {
//                #region -- 親商品情報を展開 --
//                    // 2008.08.07 30413 犬飼 プライマリーキーの変更 >>>>>>START
//                    //object[] objPrimaryKey = new object[] { parentGoodsMakerCd, parentGoodsNo };
//                    object[] objPrimaryKey = new object[] { parentGoodsNo, parentGoodsMakerCd};
//                    // 2008.08.07 30413 犬飼 プライマリーキーの変更 <<<<<<END
//                    DataRow goodsSetDataRow = _goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].Rows.Find(objPrimaryKey);

//                    DisplayScreen(goodsSetDataRow);
//                    #endregion

//                #region -- セット商品情報を展開 --
//                    DataRow childDataRow = _goodsSetAcs.ChildGoodsInfoDataSet.Tables[GoodsSetAcs.CHILDGOODSINFO_TABLE].DefaultView[i].Row;
//                    DisplayScreen(i, ref childDataRow);
//                    #endregion
//                }
//                #endregion

//#else
//                #region < データ画面展開処理 >

//                List<GoodsUnitData> parentGoodsUnitDataList;
//                List<GoodsUnitData> childGoodsUnitDataList;
//                // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//                //this.GetGoodSetData(parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);
//                this.GetGoodSetData(1, parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);
//                // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//                // 2009.03.26 30413 犬飼 商品マスタに無い場合は、セットマスタから取得するため不要 >>>>>>START
//                //// 2009.02.13 30413 犬飼 例外エラーを修正 >>>>>>START
//                //// 親商品が存在しない
//                //if (parentGoodsUnitDataList.Count == 0)
//                //{
//                //    TMsgDisp.Show(
//                //        this, 								// 親ウィンドウフォーム
//                //        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
//                //        PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
//                //        "親商品が存在しません。",           // 表示するメッセージ
//                //        0, 									// ステータス値
//                //        MessageBoxButtons.OK);				// 表示するボタン

//                //    CloseForm(DialogResult.Cancel);
//                //    return;
//                //}
//                //// 2009.02.13 30413 犬飼 例外エラーを修正 <<<<<<END
//                // 2009.03.26 30413 犬飼 商品マスタに無い場合は、セットマスタから取得するため不要 <<<<<<END

//                #region -- 親商品情報を展開 --
//                this.DisplayScreen(parentGoodsUnitDataList[0]);
//                #endregion

//                #region -- セット商品情報を展開 --
//                childGoodsUnitDataList.Sort(CompareGoodsUnitData);
//                for (int i = 0; i < childGoodsUnitDataList.Count; i++)
//                {
//                    DisplayScreen(i, childGoodsUnitDataList[i]);
//                }
//                #endregion

//                // 2008.10.30 30413 犬飼 セット商品との同一チェック用に設定 >>>>>>START
//                this._userControl.SetParentData(this.ParentGoodsCode_tEdit.Text, this.ParentMakerCode_tNedit.GetInt());
//                // 2008.10.30 30413 犬飼 セット商品との同一チェック用に設定 <<<<<<END

//                #endregion
//#endif

//                #region < 画面表示設定処理 >
//                // 2008.08.20 30413 犬飼 論理削除の関連処理を削除 >>>>>>START
//                //if (logicalDeleteCode == 0)
//                //{
//                //    // 更新画面
//                //    ScreenAccordingToMode(1);
//                //}
//                //else
//                //{
//                //    // フォーカスをボタンにセット
//                //    this.Delete_Button.Focus();

//                //    // 削除画面
//                //    ScreenAccordingToMode(2);
//                //}
//                // 更新画面のみ
//                ScreenAccordingToMode(1);
//                // 2008.08.20 30413 犬飼 論理削除の関連処理を削除 <<<<<<END
//                #endregion

//                this._indexBuf = this._dataIndex;

//                #endregion
//            }
//            #endregion

//            #region < 変更チェック用クローン作成 >
//            // 画面変更されたかチェックをするためクローン作成
//            _goodsSetClone = new GoodsSet();
//            this.DispToGoodsSet(ref _goodsSetClone);
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

//        /// <summary>
//        ///	モード別画面構築処理
//        /// </summary>
//        /// <remarks>
//        /// Note			:	モード別に画面を構築します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        private void ScreenAccordingToMode(int mode)
//        {
//            Control focusControl = new Control();

//            switch (mode)
//            {
//                case 0:

//                    #region ■新規登録

//                    this.Mode_Label.Text = INSERT_MODE;

//                    this.Ok_Button.Visible = true;
//                    this.Cancel_Button.Visible = true;
//                    this.Delete_Button.Visible = false;
//                    this.Revive_Button.Visible = false;

//                    ScreenInputPermissionControl(true);
//                    // 2008.08.22 30413 犬飼 初期フォーカスを品番に変更 >>>>>>START
//                    //focusControl = this.ParentMakerCode_tNedit;
//                    focusControl = this.ParentGoodsCode_tEdit;
//                    // 2008.08.22 30413 犬飼 初期フォーカスを品番に変更 <<<<<<END

//                    break;
//                    #endregion

//                case 1:

//                    #region ■更   新
//                    this.Mode_Label.Text = UPDATE_MODE;

//                    this.Ok_Button.Visible = true;
//                    this.Cancel_Button.Visible = true;
//                    this.Delete_Button.Visible = false;
//                    this.Revive_Button.Visible = false;

//                    ScreenInputPermissionControl(true);
//                    this.ParentGoodsCode_tEdit.Enabled = false;
//                    this.ParentMakerCode_tNedit.Enabled = false;
//                    // 2008.08.06 30413 犬飼 商品ガイドボタンの削除 >>>>>>START
//                    //this.ParentGoodsGuide_Button.Enabled = false;
//                    // 2008.08.06 30413 犬飼 商品ガイドボタンの削除 <<<<<<END
//                    this.ParentMakerGuide_Button.Enabled = false;

//                    focusControl = this.Ok_Button;

//                    break;
//                    #endregion

//                case 2:

//                    #region ■削   除
//                    this.Mode_Label.Text = DELETE_MODE;

//                    this.Ok_Button.Visible = false;
//                    this.Cancel_Button.Visible = true;
//                    this.Delete_Button.Visible = true;
//                    this.Revive_Button.Visible = true;

//                    ScreenInputPermissionControl(false);

//                    break;
//                    #endregion

//            }
//            this._indexBuf = this._dataIndex;

//            focusControl.Focus();
//        }

//        /// <summary>
//        ///	画面入力許可制御処理
//        /// </summary>
//        /// <param name="enabled">入力許可設定値</param>
//        /// <remarks>
//        /// Note			:	画面の入力許可を制御します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        private void ScreenInputPermissionControl(bool enabled)
//        {
//            // モードによって入力許可を制御
//            this.ParentMakerCode_tNedit.Enabled = enabled;
//            this.ParentGoodsCode_tEdit.Enabled = enabled;
//            this.ParentMakerGuide_Button.Enabled = enabled;  // 親商品メーカーガイドボタン
//            // 2008.08.06 30413 犬飼 商品ガイドボタンの削除 >>>>>>START
//            //this.ParentGoodsGuide_Button.Enabled = enabled;  // 親商品ガイドボタン
//            // 2008.08.06 30413 犬飼 商品ガイドボタンの削除 <<<<<<END

//            // グリッド上ボタン許可制御
//            this._userControl.GridButtonPermissionControl(enabled);
//            // グリッド編集許可制御
//            this._userControl.GridInputPermissionControl(enabled);
//        }

//        /// <summary>
//        ///	画面展開処理
//        /// </summary>
//        /// <remarks>
//        /// Note			:	フォームにデータテーブルのデータを展開します。<br />
//        /// Programmer		:	木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        private void DisplayScreen(DataRow dataRow)
//        {
//            #region ●親商品メーカー
//            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSMAKERCD_TITLE))
//            {
//                this.ParentMakerCode_tNedit.SetInt((int)(dataRow[GoodsSetAcs.PARENTGOODSMAKERCD_TITLE]));
//            }
//            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSMAKERNM_TITLE))
//            {
//                this.ParentMakerName_tEdit.DataText = (string)(dataRow[GoodsSetAcs.PARENTGOODSMAKERNM_TITLE]);
//            }
//            #endregion

//            #region ●親品番
//            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSNO_TITLE))
//            {
//                this.ParentGoodsCode_tEdit.DataText = (string)(dataRow[GoodsSetAcs.PARENTGOODSNO_TITLE]);
//            }
//            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSNAME_TITLE))
//            {
//                this.ParentGoodsName_tEdit.DataText = (string)(dataRow[GoodsSetAcs.PARENTGOODSNAME_TITLE]);
//            }
//            #endregion
//        }

//        /// <summary>
//        ///	画面展開処理(オーバーロード)
//        /// </summary>
//        /// <remarks>
//        /// Note			:	フォームにデータテーブルのデータを展開します。<br />
//        /// Programmer		:	木建　翼<br />
//        /// Date			:	2007.05.07<br />
//        /// </remarks>
//        private void DisplayScreen(int rowNo, ref DataRow dataRow)
//        {
//            #region ●グリッドデータ展開

//            // グリッドに表示するNoなので行数に１を加える
//            int No = rowNo + 1;
//            this._userControl.SetGoodsSetDataTable(No, dataRow);

//            #endregion
//        }

//        /// <summary>
//        /// 検索処理
//        /// </summary>
//        /// <returns>結果[true: 正常, false: 異常]</returns>
//        /// <remarks>
//        /// <br>Note       : 商品セット情報の検索処理を行ないます。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.07</br>
//        /// </remarks>
//        private int SearchProc(ref int totalCount, int readCount)
//        {
//            int status = -1;

//            #region < 全件検索 >
//            if (readCount == 0)
//            {
//                status = this._goodsSetAcs.SearchAll(this._enterpriseCode, ref totalCount);
//            }
//            #endregion

//            #region < 検索後処理 >
//            switch (status)
//            {
//                #region -- 正常終了 --
//                // 全件取得メソッドの結果が"正常終了"のとき
//                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//                    {
//                        break;
//                    }
//                #endregion

//                #region -- データ無し --
//                case (int)ConstantManagement.DB_Status.ctDB_EOF:
//                    {
//                        break;
//                    }
//                #endregion

//                #region -- 検索失敗 --
//                default:
//                    {
//                        TMsgDisp.Show(
//                            this, 									// 親ウィンドウフォーム
//                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
//                            PG_ID, 		    				    	// アセンブリＩＤまたはクラスＩＤ
//                            PG_NM,        						    // プログラム名称
//                            "SearchProc", 							// 処理名称
//                            TMsgDisp.OPE_GET, 						// オペレーション
//                            "読み込みに失敗しました。",    			// 表示するメッセージ
//                            status, 								// ステータス値
//                            this._goodsSetAcs,             			// エラーが発生したオブジェクト
//                            MessageBoxButtons.OK, 					// 表示するボタン
//                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
//                        break;
//                    }
//                #endregion
//            }
//            #endregion

//            return status;

//        }

//        /// <summary>
//        /// 登録・更新処理
//        /// </summary>
//        /// <returns>結果[true: 正常, false: 異常]</returns>
//        /// <remarks>
//        /// <br>Note       : 商品セット情報の登録・更新処理を行ないます。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.07</br>
//        /// </remarks>
//        private int SaveProc()
//        {
//            int status = -1;

//            #region < 入力チェック >
//            Control control = null;
//            string message = null;
//            if (this.ScreenDataCheck(ref control, ref message) == false)
//            {
//                #region -- エラーメッセージ --
//                TMsgDisp.Show(
//                    this,                               // 親ウィンドウフォーム
//                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
//                    PG_ID,                              // アセンブリＩＤまたはクラスＩＤ
//                    message,                            // 表示するメッセージ
//                    0,                                  // ステータス値
//                    MessageBoxButtons.OK);              // 表示するボタン
//                #endregion

//                #region -- フォーカス移動 --
//                if (control != null)
//                {
//                    control.Focus();
//                    if (control is TEdit)
//                    {
//                        ((TEdit)control).SelectAll();
//                    }
//                    else if (control is TNedit)
//                    {
//                        ((TNedit)control).SelectAll();
//                    }
//                }
//                #endregion

//                return status;
//            }
//            #endregion

//            #region < 登録データ準備処理 >
//            // 画面情報をEクラスに格納
//            int errorRowNo;
//            string errorColNm;
//            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
//            List<GoodsSet> writeDataList = new List<GoodsSet>();

//            // 有効なデータ行リストを取得
//            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

//            // エラー行番号が"0"のときのみ正常
//            if (errorRowNo == 0)
//            {
//                // 書き込みを行なうデータクラスのリストを作成する
//                for (int i = 0; i < effectDataList.Count; i++)
//                {
//                    GoodsSet goodsSet = new GoodsSet();
//                    this.DispToGoodsSet(effectDataList[i], ref goodsSet);
//                    writeDataList.Add(goodsSet);
//                }
//            }
//            #endregion

//            // 2008.08.20 30413 犬飼 物理削除処理の追加 >>>>>>START
//            #region < 物理削除データ準備処理 >
//            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
//            List<GoodsSet> delDataList = new List<GoodsSet>();

//            // 削除対象データの取得
//            this._userControl.GetDeleteData(out deleteDataList);

//            // 削除を行なうデータクラスのリストを作成する
//            for (int i = 0; i < deleteDataList.Count; i++)
//            {
//                GoodsSet goodsSet = new GoodsSet();
//                // 完全削除
//                this.DispToGoodsSet(deleteDataList[i], ref goodsSet);
//                delDataList.Add(goodsSet);
//            }
//            #endregion

//            #region < 物理削除処理 >
//            // 削除対象があれば該当レコードを削除
//            if (deleteDataList.Count != 0)
//            {
//                status = this._goodsSetAcs.DeleteUnique(delDataList);
//            }
//            else
//            {
//                status = 0;
//            }
//            #endregion
//            // 2008.08.20 30413 犬飼 物理削除処理の追加 <<<<<<END

//            // 2008.08.20 30413 犬飼 登録処理は物理削除処理後に実行 >>>>>>START
//            //#region < 登録処理 >
//            //// 商品セット設定書き込み処理
//            ////status = this._goodsSetAcs.Write(ref goodsSet);
//            //status = this._goodsSetAcs.Write(writeDataList);
//            //#endregion

//            #region < 登録処理 >
//            if (status == 0)
//            {
//                // 2008.08.21 30413 犬飼 登録処理で商品連結データディクショナリーを追加 >>>>>>START
//                // 商品セット設定書き込み処理
//                //status = this._goodsSetAcs.Write(writeDataList);
//                Dictionary<string, GoodsUnitData> goodsUnitDataDic;
//                _userControl.GetLC_GoodsUnitData(out goodsUnitDataDic);
//                status = this._goodsSetAcs.Write(writeDataList, goodsUnitDataDic);
//                // 2008.08.21 30413 犬飼 登録処理で商品連結データディクショナリーを追加 <<<<<<END
//            }
//            #endregion
//            // 2008.08.20 30413 犬飼 登録処理は物理削除処理後に実行 <<<<<<END

//            #region < 登録後処理 >
//            switch (status)
//            {
//                #region -- 通常終了 --
//                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//                    status = 0;
//                    break;

//                // 重複エラー
//                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
//                    // コード重複
//                    TMsgDisp.Show(
//                        this, 									// 親ウィンドウフォーム
//                        emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
//                        PG_ID, 					        		// アセンブリＩＤまたはクラスＩＤ
//                        "このコードは既に使用されています。",  	// 表示するメッセージ
//                        0, 										// ステータス値
//                        MessageBoxButtons.OK);					// 表示するボタン
//                    if (this.ParentMakerCode_tNedit.Enabled == true)
//                    {
//                        this.ParentMakerCode_tNedit.Focus();
//                        this.ParentMakerCode_tNedit.SelectAll();
//                    }
//                    break;
//                #endregion

//                #region -- 排他制御 --
//                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
//                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
//                    ExclusiveTransaction(status, true);
//                    break;
//                #endregion

//                #region -- 登録失敗 --
//                default:
//                    TMsgDisp.Show(
//                        this,                                 // 親ウィンドウフォーム
//                        emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
//                        PG_ID,                                // アセンブリＩＤまたはクラスＩＤ
//                        PG_NM,                                // プログラム名称
//                        "SaveProc",                           // 処理名称
//                        TMsgDisp.OPE_UPDATE,                  // オペレーション
//                        "登録に失敗しました。",               // 表示するメッセージ
//                        status,                               // ステータス値
//                        this._goodsSetAcs,                    // エラーが発生したオブジェクト
//                        MessageBoxButtons.OK,                 // 表示するボタン
//                        MessageBoxDefaultButton.Button1);     // 初期表示ボタン
//                    this.CloseForm(DialogResult.Cancel);
//                    break;
//                #endregion
//            }
//            #endregion

//            return status;
//        }

//        /// <summary>
//        /// 排他処理
//        /// </summary>
//        /// <param name="status">STATUS</param>
//        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
//        /// <remarks>
//        /// Note       : 排他処理を行います<br />
//        /// Programmer : 30005 木建　翼<br />
//        /// Date       : 2007.05.07<br />
//        /// </remarks>
//        private void ExclusiveTransaction(int status, bool hide)
//        {
//            switch (status)
//            {
//                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
//                    {
//                        // 他端末更新
//                        TMsgDisp.Show(
//                            this, 								// 親ウィンドウフォーム
//                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
//                            PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
//                            "既に他端末より更新されています。", // 表示するメッセージ
//                            0, 									// ステータス値
//                            MessageBoxButtons.OK);				// 表示するボタン
//                        if (hide == true)
//                        {
//                            CloseForm(DialogResult.Cancel);
//                        }
//                        break;
//                    }
//                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
//                    {
//                        // 他端末削除
//                        TMsgDisp.Show(
//                            this, 								// 親ウィンドウフォーム
//                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
//                            PG_ID, 						        // アセンブリＩＤまたはクラスＩＤ
//                            "既に他端末より削除されています。", // 表示するメッセージ
//                            0, 									// ステータス値
//                            MessageBoxButtons.OK);				// 表示するボタン
//                        if (hide == true)
//                        {
//                            CloseForm(DialogResult.Cancel);
//                        }
//                        break;
//                    }
//            }
//        }

//        /// <summary>
//        /// 画面情報格納処理
//        /// </summary>
//        /// <param name="goodsSet">商品セットデータクラス</param>
//        /// <remarks>
//        /// Note       : 画面情報のデータクラス格納処理を行います<br />
//        /// Programmer : 30005 木建　翼<br />
//        /// Date       : 2007.05.07<br />
//        /// </remarks>
//        private void DispToGoodsSet(ref GoodsSet goodsSet)
//        {
//            goodsSet.ParentGoodsMakerCd = this.ParentMakerCode_tNedit.GetInt();         // 親商品メーカーコード
//            goodsSet.ParentGoodsNo = this.ParentGoodsCode_tEdit.DataText;          // 親品番
//        }

//        /// <summary>
//        /// 画面情報格納処理(オーバーロード)
//        /// </summary>
//        /// <param name="row">セット商品情報入力データテーブル行</param>
//        /// <param name="goodsSet">商品セットデータクラス</param>
//        /// <remarks>
//        /// Note       : 画面情報のデータクラス格納処理を行います<br />
//        /// Programmer : 30005 木建　翼<br />
//        /// Date       : 2007.05.07<br />
//        /// </remarks>
//        private void DispToGoodsSet(GoodsSetGoodsDataSet.GoodsSetDetailRow row, ref GoodsSet goodsSet)
//        {
//            // 2008.08.20 30413 犬飼 企業コードの追加 >>>>>>START
//            goodsSet.EnterpriseCode = this._enterpriseCode;                            // 企業コード
//            // 2008.08.20 30413 犬飼 企業コードの追加 <<<<<<END

//            goodsSet.ParentGoodsMakerCd = this.ParentMakerCode_tNedit.GetInt();       // 親商品メーカーコード
//            goodsSet.ParentGoodsNo = this.ParentGoodsCode_tEdit.DataText;        // 親品番
//            goodsSet.ParentGoodsName = this.ParentGoodsName_tEdit.DataText;        // 親品名
//            // セット商品情報のクローンを作成する処理を追加
//            //goodsSet.SubGoodsMakerCd     = row.MakerCode;                              // メーカーコード
//            goodsSet.SubGoodsMakerCd = int.Parse(row.MakerCode);                              // メーカーコード
//            goodsSet.SubGoodsNo = row.GoodsCode;                              // 品番
//            goodsSet.SubGoodsName = row.GoodsName;                              // 品名
//            //goodsSet.CntFl               = row.CntFl;                                  // 数量
//            goodsSet.CntFl = double.Parse(row.CntFl);                                  // 数量
//            goodsSet.DisplayOrder = row.Disply;                                 // 表示順位
//            goodsSet.SetSpecialNote = row.SetNote;                                // セット規格・特記事項
//            // 2008.08.04 30413 犬飼 カタログ図番の削除 >>>>>>START
//            //goodsSet.CatalogShapeNo = row.CatalogShape;                           // カタログ図番
//            // 2008.08.04 30413 犬飼 カタログ図番の削除 <<<<<<END
//        }

//        /// <summary>
//        /// 画面入力情報不正チェック処理
//        /// </summary>
//        /// <param name="control">不正対象コントロール</param>
//        /// <param name="message">メッセージ</param>
//        /// <returns>チェック結果[true: OK, false: NG]</returns>
//        /// <remarks>
//        /// <br>Note       : 画面の入力情報の不正チェックを行います。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.07</br>
//        /// </remarks>
//        private bool ScreenDataCheck(ref Control control, ref string message)
//        {
//            bool result = true;

//            #region ●親商品情報入力チェック

//            // 2008.10.09 30413 犬飼 名称を入力チェックから外す >>>>>>START
//            #region < メーカーコードの入力チェック >
//            //if (this.ParentMakerCode_tNedit.GetInt() == 0 || this.ParentMakerName_tEdit.Text.TrimEnd() == "")
//            //if (this.ParentMakerCode_tNedit.GetInt() == 0)    // DEL 2009/04/09
//            if ((this.ParentMakerCode_tNedit.Enabled) && (this.ParentMakerCode_tNedit.Text.TrimEnd() == ""))  // ADD 2009/04/09
//            {
//                message = this.ParentMakerCode_Label.Text + "を入力してください。";
//                control = this.ParentMakerCode_tNedit;
//                result = false;
//                return result;
//            }
//            #endregion

//            #region < 品番の入力チェック >
//            //if (this.ParentGoodsCode_tEdit.Text.TrimEnd() == "" || this.ParentGoodsName_tEdit.Text.TrimEnd() == "")
//            if (this.ParentGoodsCode_tEdit.Text.TrimEnd() == "")
//            {
//                message = this.ParentGoodsCode_Label.Text + "を入力してください。";
//                control = this.ParentGoodsCode_tEdit;
//                result = false;
//                return result;
//            }
//            #endregion
//            // 2008.10.09 30413 犬飼 名称を入力チェックから外す <<<<<<END

//            // 2009.03.26 30413 犬飼 親商品の商品マスタ削除チェック >>>>>>START
//            #region < 品名のチェック >
//            if (this.ParentGoodsName_tEdit.Text.TrimEnd() == "")
//            {
//                message = "親商品が商品マスタから削除されています。";
//                control = this.ParentGoodsCode_tEdit;
//                result = false;
//                return result;
//            }
//            #endregion
//            // 2009.03.26 30413 犬飼 親商品の商品マスタ削除チェック <<<<<<END

//            #endregion

//            #region ●セット商品情報入力チェック

//            result = _userControl.GridDataCheck(ref control, ref message);

//            #endregion

//            return result;
//        }

//        /// <summary>
//        /// 選択されたGridデータ取得処理(オーバーロード)
//        /// </summary>
//        /// <param name="goodsSet">商品セットデータクラス</param>
//        /// <remarks>
//        /// <br>Note       : 選択されたGridのデータ取得を行います。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.08</br>
//        /// </remarks>
//        private void GetGridData(ref GoodsSet goodsSet)
//        {
//            // 親商品メーカーコード
//            goodsSet.ParentGoodsMakerCd = (int)(this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSMAKERCD_TITLE]);
//            // 親品番
//            goodsSet.ParentGoodsNo = (string)(this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSNO_TITLE]);
//        }

//        /// <summary>
//        /// 選択されたGridデータ取得処理(オーバーロード)
//        /// </summary>
//        /// <param name="row">セット商品情報入力データテーブル行</param>
//        /// <param name="goodsSet">商品セットデータクラス</param>
//        /// <remarks>
//        /// <br>Note       : 選択されたGridのデータ取得を行います。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.08</br>
//        /// </remarks>
//        private void GetGridData(GoodsSetGoodsDataSet.GoodsSetDetailRow row, ref GoodsSet goodsSet)
//        {
//            #region < 親商品情報 >
//            // 親商品メーカーコード
//            goodsSet.ParentGoodsMakerCd = (int)(this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSMAKERCD_TITLE]);
//            // 親品番
//            goodsSet.ParentGoodsNo = (string)(this._goodsSetAcs.GoodsSetDataSet.Tables[GoodsSetAcs.GOODSSET_TABLE].DefaultView[this._dataIndex][GoodsSetAcs.PARENTGOODSNO_TITLE]);
//            #endregion

//            #region < セット商品情報 >
//            // ■セット商品情報グリッドからデータを取得する
//            // メーカーコード
//            //goodsSet.SubGoodsMakerCd = row.MakerCode;
//            goodsSet.SubGoodsMakerCd = int.Parse(row.MakerCode);
//            // 品番
//            goodsSet.SubGoodsNo = row.GoodsCode;
//            #endregion
//        }

//        /// <summary>
//        /// 画面変更確認処理
//        /// </summary>
//        /// <returns>チェック結果[true: 変更有, false: 変更無]</returns>
//        /// <remarks>
//        /// <br>Note       : キャンセルボタン押下時、画面に変更があったかのチェックを行います。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.08</br>
//        /// </remarks>
//        private bool CheckScreenChange()
//        {
//            bool result = false;

//            GoodsSet goodsSetBefore = new GoodsSet();
//            GoodsSet goodsSetAfter = new GoodsSet();

//            // 画面から取得するデータを編集後のデータとする
//            this.DispToGoodsSet(ref goodsSetAfter);

//            #region < 親商品情報比較処理 >
//            // 画面表示時(クローン)と比較をして違いがあるかチェックする
//            ArrayList DisagreementList = _goodsSetClone.Compare(goodsSetAfter);
//            if (DisagreementList.Count > 0)
//            {
//                // 編集有り
//                result = true;
//                return result;
//            }
//            #endregion

//            #region < セット商品情報比較処理 >
//            result = this._userControl.CheckGridChange();
//            #endregion

//            return result;
//        }

//        /// <summary>
//        /// 詳細グリッド最上位行キーダウンイベント
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータクラス</param>
//        private void GoodsSetDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
//        {
//            this.ParentGoodsCode_tEdit.Focus();
//            this.ParentGoodsCode_tEdit.SelectAll();
//        }

//        /// <summary>
//        /// 詳細グリッド最下層行キーダウンイベント
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータクラス</param>
//        private void GoodsSetDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
//        {
//            this.Ok_Button.Focus();
//        }

//        #endregion

//        #region ◆ControlEvent

//        /// <summary>
//        /// Form.Load イベント (MAKHN09620UA)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// <br>Note       : フォームが表示されるときに発生します。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 2007.05.08</br>
//        /// </remarks>
//        private void MAKHN09620UA_Load(object sender, EventArgs e)
//        {
//            // 画面を構築
//            this.ScreenInitialSetting();

//            this.panel_Detail.Controls.Add(_userControl);

//            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//            // 画面ロード時に表示された親商品情報を編集前データとして保持
//            this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
//            this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
//            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05 T-Kidate END
//        }

//        /// <summary>
//        ///	Form.Closing イベント(MAKHN09620UA)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
//        /// <remarks>
//        /// Note			:	フォームを閉じる前に、ユーザーがフォームを閉じ
//        ///						ようとしたときに発生します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	007.05.08<br />
//        /// </remarks>
//        private void MAKHN09620UA_FormClosing(object sender, FormClosingEventArgs e)
//        {
//            this._indexBuf = -2;

//            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
//            // フォームを非表示化する。
//            //（フォームの「×」をクリックされた場合の対応です。）
//            if (CanClose == false)
//            {
//                e.Cancel = true;
//                this.Hide();
//                return;
//            }
//        }

//        /// <summary>
//        /// Form.VisibleChanged イベント (MAKHN09620UA)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// <br>Note       : フォームが表示状態が変わったときに発生します。</br>
//        /// <br>Programmer : 30005 木建　翼</br>
//        /// <br>Date       : 007.05.08</br>
//        /// </remarks>
//        private void MAKHN09620UA_VisibleChanged(object sender, EventArgs e)
//        {
//            if (this.Visible == false)
//            {
//                this.Owner.Activate();
//                return;
//            }

//            // ターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
//            if (this._indexBuf == this._dataIndex)
//            {
//                return;
//            }

//            Initial_timer.Enabled = true;
//            ScreenClear();
//        }

//        /// <summary>
//        /// Control.Click イベント(Delete_Button)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// <br>Note        : 物理削除ボタンがクリックされたときに発生します。</br>
//        /// <br>Programmer  : 30005 木建　翼</br>
//        /// <br>Date        : 2007.05.08</br>
//        /// </remarks>
//        private void Delete_Button_Click(object sender, EventArgs e)
//        {
//            #region < 完全削除確認 >
//            DialogResult result = TMsgDisp.Show(
//                this, 								// 親ウィンドウフォーム
//                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
//                PG_ID,       						// アセンブリＩＤまたはクラスＩＤ
//                "データを削除します。" + "\r\n" +
//                "よろしいですか？", 				// 表示するメッセージ
//                0, 									// ステータス値
//                MessageBoxButtons.OKCancel, 		// 表示するボタン
//                MessageBoxDefaultButton.Button2);	// 初期表示ボタン
//            #endregion

//            if (result == DialogResult.OK)
//            {
//                #region < 物理削除データ準備処理 >
//                // 画面情報をEクラスに格納
//                int errorRowNo;
//                string errorColNm;
//                GoodsSet goodsSet;
//                List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
//                List<GoodsSet> delDataList = new List<GoodsSet>();

//                // 有効なデータ行リストを取得
//                this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

//                // エラー行番号が"0"のときのみ正常
//                if (errorRowNo == 0)
//                {
//                    // 書き込みを行なうデータクラスのリストを作成する
//                    for (int i = 0; i < effectDataList.Count; i++)
//                    {
//                        goodsSet = new GoodsSet();
//                        this.DispToGoodsSet(effectDataList[i], ref goodsSet);
//                        delDataList.Add(goodsSet);
//                    }
//                }

//                #endregion

//                #region < 物理削除処理 >
//                int status = this._goodsSetAcs.Delete(delDataList);
//                #endregion

//                #region < 物理削除後処理 >
//                switch (status)
//                {
//                    #region -- 正常終了 --
//                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//                        {
//                            break;
//                        }
//                    #endregion

//                    #region -- 排他制御 --
//                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
//                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
//                        {
//                            ExclusiveTransaction(status, true);
//                            return;
//                        }
//                    #endregion

//                    #region -- 物理削除失敗 --
//                    default:
//                        {
//                            // 物理削除
//                            TMsgDisp.Show(
//                                this, 									// 親ウィンドウフォーム
//                                emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
//                                PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
//                                PG_NM,					    	        // プログラム名称
//                                "Delete_Button_Click", 					// 処理名称
//                                TMsgDisp.OPE_DELETE, 					// オペレーション
//                                "削除に失敗しました。", 		    	// 表示するメッセージ
//                                status, 								// ステータス値
//                                this._goodsSetAcs, 	    				// エラーが発生したオブジェクト
//                                MessageBoxButtons.OK, 					// 表示するボタン
//                                MessageBoxDefaultButton.Button1);		// 初期表示ボタン

//                            CloseForm(DialogResult.Cancel);
//                            return;
//                        }
//                    #endregion
//                }
//                #endregion

//            }
//            else
//            {
//                this.Delete_Button.Focus();
//                return;
//            }

//            if (UnDisplaying != null)
//            {
//                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
//                UnDisplaying(this, me);
//            }

//            this.DialogResult = DialogResult.OK;

//            this._indexBuf = -2;

//            if (CanClose == true)
//            {
//                this.Close();
//            }
//            else
//            {
//                this.Hide();
//            }
//        }

//        /// <summary>
//        /// Control.Click イベント(Revive_Button)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// Note　　　  : 復活ボタンコントロールがクリックされたときに発生します。<br />
//        /// Programmer  : 30005 木建  翼<br />
//        /// Date        : 2007.05.08<br />
//        /// </remarks>
//        private void Revival_Button_Click(object sender, EventArgs e)
//        {
//            #region < 復活データ準備処理 >
//            int errorRowNo;                                                 // エラー行番号
//            string errorColNm;
//            GoodsSet goodsSet;                                              // データクラス
//            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;    // 有効データ行リスト
//            List<GoodsSet> revDataList = new List<GoodsSet>();              // 復活対象データクラスリスト

//            // 有効なデータ行リストを取得
//            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

//            // エラー行番号が"0"のときのみ正常
//            if (errorRowNo == 0)
//            {
//                // 書き込みを行なうデータクラスのリストを作成する
//                for (int i = 0; i < effectDataList.Count; i++)
//                {
//                    goodsSet = new GoodsSet();
//                    this.DispToGoodsSet(effectDataList[i], ref goodsSet);
//                    revDataList.Add(goodsSet);
//                }
//            }
//            #endregion

//            #region < 復活処理 >
//            int status = this._goodsSetAcs.Revival(revDataList);
//            #endregion

//            #region < 復活後処理 >
//            switch (status)
//            {
//                #region -- 通常終了 --
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

//                #region -- 復活失敗 --
//                default:
//                    {
//                        // 復活失敗
//                        TMsgDisp.Show(
//                            this, 									// 親ウィンドウフォーム
//                            emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
//                            PG_ID, 							        // アセンブリＩＤまたはクラスＩＤ
//                            PG_NM,						            // プログラム名称
//                            "Revive_Button_Click", 					// 処理名称
//                            TMsgDisp.OPE_UPDATE, 					// オペレーション
//                            "復活に失敗しました。", 			    // 表示するメッセージ
//                            status, 								// ステータス値
//                            this._goodsSetAcs, 	    				// エラーが発生したオブジェクト
//                            MessageBoxButtons.OK, 					// 表示するボタン
//                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

//                        CloseForm(DialogResult.Cancel);
//                        return;
//                    }
//                #endregion
//            }
//            #endregion

//            if (UnDisplaying != null)
//            {
//                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
//                UnDisplaying(this, me);
//            }

//            this.DialogResult = DialogResult.OK;

//            this._indexBuf = -2;

//            if (CanClose == true)
//            {
//                this.Close();
//            }
//            else
//            {
//                this.Hide();
//            }
//        }

//        /// <summary>
//        ///　Control.Click イベント(Ok_Button)
//        /// </summary>
//        /// <remarks>
//        /// Note            :   保存ボタンコントロールがクリックされたときに発生します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.08<br />
//        ///</remarks>
//        private void Ok_Button_Click(object sender, EventArgs e)
//        {
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

//                // フォーカスを商品セットコードにして全選択にする
//                this.ParentMakerCode_tNedit.Focus();
//                this.ParentMakerCode_tNedit.SelectAll();

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

//        /// <summary>
//        ///	Control.Click イベント(Cancel_Button)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// Note			:	閉じるボタンコントロールがクリックされたときに
//        ///						発生します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.05.08<br />
//        /// </remarks>
//        private void Cancel_Button_Click(object sender, EventArgs e)
//        {
//            // 削除モード以外の場合は保存確認処理を行う。
//            if ((this.Mode_Label.Text != DELETE_MODE) &&
//                (this.Mode_Label.Text != REFER_MODE))
//            {
//                // 変更チェック処理
//                this._changeFlg = CheckScreenChange();

//                if (this._changeFlg)
//                {
//                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する

//                    #region < 保存確認 >
//                    DialogResult res = TMsgDisp.Show(
//                        this, 								// 親ウィンドウフォーム
//                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
//                        PG_ID,       	    				// アセンブリＩＤまたはクラスＩＤ
//                        null, 		        				// 表示するメッセージ
//                        0, 									// ステータス値
//                        MessageBoxButtons.YesNoCancel);	    // 表示するボタン
//                    #endregion

//                    #region < 保存確認後処理 >
//                    switch (res)
//                    {
//                        #region -- はい --
//                        case DialogResult.Yes:
//                            {
//                                if (SaveProc() != 0)
//                                {
//                                    return;
//                                }

//                                this.DialogResult = DialogResult.OK;
//                                break;
//                            }
//                        #endregion

//                        #region -- いいえ --
//                        case DialogResult.No:
//                            {
//                                this.DialogResult = DialogResult.Cancel;
//                                break;
//                            }
//                        #endregion

//                        #region -- キャンセル --
//                        default:
//                            {
//                                this.Cancel_Button.Focus();
//                                return;
//                            }
//                        #endregion
//                    }
//                    #endregion
//                }
//            }

//            this.ParentMakerCode_tNedit.Text = "";
//            this.ParentGoodsCode_tEdit.Text = "";

//            // 画面非表示イベント
//            if (UnDisplaying != null)
//            {
//                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
//                UnDisplaying(this, me);
//            }

//            this.DialogResult = DialogResult.Cancel;

//            this._indexBuf = -2;

//            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
//            // フォームを非表示化する。
//            if (CanClose == true)
//            {
//                this.Close();
//            }
//            else
//            {
//                this.Hide();
//            }
//        }

//        /// <summary>
//        /// Timer.Tick イベント イベント(Initial_Timer)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// Note　　　  : 指定された間隔の時間が経過したときに発生します。
//        ///					  この処理は、システムが提供するスレッド プール
//        ///					  スレッドで実行されます。<br />
//        /// Programmer  : 30005 木建　翼<br />
//        /// Date        : 2007.05.08<br />
//        /// </remarks>
//        private void Initial_timer_Tick(object sender, EventArgs e)
//        {
//            Initial_timer.Enabled = false;
//            ScreenReconstruction();
//        }

//        /// <summary>
//        ///	Control.ChangeFocus イベント
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// Note			:	フォーカス移動時に発生します。<br />
//        /// Programmer		:	30005 木建　翼<br />
//        /// Date			:	2007.03.06<br />
//        /// </remarks>
//        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
//        {
//            if (e.PrevCtrl == null || e.NextCtrl == null) return;

//            switch (e.PrevCtrl.Name)
//            {
//                #region ●グリッド内フォーカス移動
//                case "uGrid_Details":
//                    {
//                        // 2008.10.15 30413 犬飼 タブも同じ動作とする >>>>>>START
//                        //switch (e.Key)
//                        //{
//                        //    case Keys.Return:
//                        //    case Keys.Tab:
//                        //        {
//                        //            if (this._userControl.uGrid_Details.ActiveCell != null)
//                        //            {
//                        //                if (this._userControl.ReturnKeyDown())
//                        //                {
//                        //                    e.NextCtrl = null;
//                        //                }
//                        //                else
//                        //                {
//                        //                    e.NextCtrl = this.Ok_Button;
//                        //                }
//                        //            }

//                        //            break;
//                        //        }
//                        //}
//                        //break;
//                        if (!e.ShiftKey)
//                        {
//                            switch (e.Key)
//                            {
//                                case Keys.Return:
//                                case Keys.Tab:
//                                    {
//                                        if (this._userControl.uGrid_Details.ActiveCell != null)
//                                        {
//                                            if (this._userControl.ReturnKeyDown())
//                                            {
//                                                e.NextCtrl = null;
//                                            }
//                                            else
//                                            {
//                                                e.NextCtrl = this.Ok_Button;
//                                            }
//                                        }

//                                        break;
//                                    }
//                            }
//                            //break;
//                        }
//                        else
//                        {
//                            switch (e.Key)
//                            {
//                                case Keys.Tab:
//                                    {
//                                        if ((this._userControl.uGrid_Details.ActiveCell.Column.Index == 1) && (this._userControl.uGrid_Details.ActiveCell.Row.Index == 0))
//                                        {
//                                            if (this.ParentMakerCode_tNedit.Enabled)
//                                            {
//                                                if (this.ParentMakerCode_tNedit.Text != "")
//                                                {
//                                                    // メーカーにフォーカス遷移
//                                                    e.NextCtrl = this.ParentMakerCode_tNedit;
//                                                }
//                                                else
//                                                {
//                                                    // メーカーガイドにフォーカス遷移
//                                                    e.NextCtrl = ParentMakerGuide_Button;
//                                                }
//                                            }
//                                            else
//                                            {
//                                                // メーカーが無効の時は閉じるボタンに遷移
//                                                e.NextCtrl = this.Cancel_Button;
//                                            }
//                                        }
//                                        else
//                                        {
//                                            if (this._userControl.ReturnKeyDown2())
//                                            {
//                                                e.NextCtrl = null;
//                                            }
//                                        }
//                                    }
//                                    break;
//                            }
//                        }
//                        break;
//                        // 2008.10.15 30413 犬飼 タブも同じ動作とする <<<<<<END
//                    }
//                #endregion

//                #region ●メーカー情報検索
//                case "ParentMakerCode_tNedit":
//                    {
//                        #region < 編集チェック >
//                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//                        // 変数保持
//                        int parentMakerCode = this.ParentMakerCode_tNedit.GetInt();

//                        if (this._prevParentMakerCode == parentMakerCode)
//                        {
//                            // 編集前と同じなら処理を行なわない
//                            if (parentMakerCode != 0)
//                            {
//                                // カーソル制御
//                                e.NextCtrl = this._userControl;
//                            }
//                            return;
//                        }
//                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05. T-Kidate END
//                        #endregion

//                        #region < ゼロ入力チェック >
//                        if (this.ParentMakerCode_tNedit.GetInt() != 0)
//                        {
//                            // 2008.10.09 30413 犬飼 動作高速化対応 >>>>>>START
//                            // メーカーデータクラス
//                            MakerUMnt makerUMnt;
//                            // 商品データクラスインスタンス化
//                            //GoodsAcs goodsAcs = new GoodsAcs();
//                            //string msg;
//                            //goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

//                            #region < メーカー情報取得処理 >
//                            //goodsAcs.GetMaker(this._enterpriseCode, this.ParentMakerCode_tNedit.GetInt(), out makerUMnt);
//                            //this._goodsAcs.GetMaker(this._enterpriseCode, this.ParentMakerCode_tNedit.GetInt(), out makerUMnt);
//                            this._goodsSetAcs.GetMaker(this._enterpriseCode, this.ParentMakerCode_tNedit.GetInt(), out makerUMnt);
//                            #endregion
//                            // 2008.10.09 30413 犬飼 動作高速化対応 <<<<<<END

//                            #region < 画面表示処理 >

//                            if (makerUMnt != null)
//                            {
//                                #region -- 取得データ展開 --
//                                // メーカー情報画面表示
//                                this.ParentMakerName_tEdit.DataText = makerUMnt.MakerName;

//                                // 商品情報はクリア
//                                this.ParentGoodsCode_tEdit.Clear();
//                                this.ParentGoodsName_tEdit.Clear();

//                                // カーソル制御
//                                e.NextCtrl = this._userControl;

//                                #endregion
//                            }
//                            else
//                            {
//                                #region -- 取得失敗 --
//                                TMsgDisp.Show(
//                                    this,
//                                    emErrorLevel.ERR_LEVEL_INFO,
//                                    this.Name,
//                                    "該当するデータが存在しません。",
//                                    -1,
//                                    MessageBoxButtons.OK);

//                                this.ParentMakerCode_tNedit.Clear();
//                                this.ParentMakerName_tEdit.Clear();

//                                // カーソル制御
//                                e.NextCtrl = e.PrevCtrl;
//                                #endregion
//                            }
//                            #endregion
//                        }
//                        else
//                        {
//                            this.ParentMakerCode_tNedit.Clear();
//                            this.ParentMakerName_tEdit.Clear();
//                        }
//                        #endregion

//                        #region < 編集前データ保持 >
//                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//                        // 編集された親商品情報を編集前データとして保持
//                        this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
//                        this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
//                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05. T-Kidate END
//                        #endregion

//                        // 2008.10.15 30413 犬飼 セット商品との同一チェック用に設定 >>>>>>START
//                        this._userControl.SetParentData(this.ParentGoodsCode_tEdit.Text, this.ParentMakerCode_tNedit.GetInt());
//                        // 2008.10.15 30413 犬飼 セット商品との同一チェック用に設定 <<<<<<END

//                        break;
//                    }

//                #endregion

//                #region ●商品情報検索
//                case "ParentGoodsCode_tEdit":
//                    {
//                        #region < 編集チェック >
//                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//                        // 変数保持
//                        string parentGoodsCode = this.ParentGoodsCode_tEdit.DataText;

//                        if (this._prevParentGoodsCode == parentGoodsCode)
//                        {
//                            // 編集前と同じなら処理を行なわない
//                            return;
//                        }
//                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05. T-Kidate END
//                        #endregion

//                        #region < 空入力チェック >
//                        if (this.ParentGoodsCode_tEdit.DataText != "")
//                        {
//                            string searchCode;
//                            // 検索の種類を取得
//                            int searchType = this._userControl.GetSearchType(this.ParentGoodsCode_tEdit.DataText, out searchCode);

//                            //List<GoodsUnitData> goodsUnitDataList;
//                            //string message;

//                            // 2008.08.04 30413 犬飼 商品検索処理の変更 >>>>>>START
//                            #region < 商品検索処理 > <<<<<<変更前
//                            //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
//                            //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
//                            #endregion

//                            #region < 商品検索処理 >
//                            //string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
//                            //GoodsCndtn goodsCndtn = new GoodsCndtn();
//                            //GoodsAcs goodsAcs = new GoodsAcs();

//                            //// 商品検索条件設定
//                            //goodsCndtn.EnterpriseCode = this._enterpriseCode;
//                            //goodsCndtn.SectionCode = sectionCd;
//                            //goodsCndtn.GoodsMakerCd = this.ParentMakerCode_tNedit.GetInt();
//                            //goodsCndtn.MakerName = this.ParentMakerName_tEdit.DataText;
//                            //goodsCndtn.GoodsNo = this.ParentGoodsCode_tEdit.DataText;
//                            //goodsCndtn.GoodsNoSrchTyp = searchType;

//                            //int status = goodsAcs.SearchInitial(this._enterpriseCode, sectionCd, out message);
//                            //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out goodsUnitDataList, out message);
//                            #endregion
//                            // 2008.08.04 30413 犬飼 商品検索処理の変更 <<<<<<END

//                            List<GoodsUnitData> parentGoodsUnitDataList;
//                            List<GoodsUnitData> childGoodsUnitDataList;
//                            string parentGoodsNo = this.ParentGoodsCode_tEdit.DataText;
//                            //int parentGoodsMakerCd = this.ParentMakerCode_tNedit.GetInt(); // DEL 2009/03/16
//                            int parentGoodsMakerCd = 0; // ADD 2009/03/16

//                            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//                            //int status = this.GetGoodSetData(parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);
//                            int status = this.GetGoodSetData(0, parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);
//                            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//                            #region < 画面表示処理 >
//                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
//                            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (parentGoodsUnitDataList != null) && (parentGoodsUnitDataList.Count > 0))
//                            {
//                                //#region -- 取得データ展開 --
//                                //// 商品マスタデータクラス
//                                //GoodsUnitData goodsUnitData = new GoodsUnitData();
//                                //goodsUnitData = goodsUnitDataList[0];

//                                //// 商品情報画面表示
//                                //this.ParentMakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
//                                //this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
//                                //this.ParentGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
//                                //this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;
//                                //#endregion

//                                #region -- 親商品情報を展開 --
//                                this.DisplayScreen(parentGoodsUnitDataList[0]);
//                                #endregion

//                                #region -- セット商品情報を展開 --
//                                childGoodsUnitDataList.Sort(CompareGoodsUnitData);
//                                for (int i = 0; i < childGoodsUnitDataList.Count; i++)
//                                {
//                                    DisplayScreen(i, childGoodsUnitDataList[i]);
//                                }
//                                #endregion

//                                // UI画面のモード変更チェック
//                                if (this._goodsSetAcs.CheckModeChange(parentGoodsUnitDataList[0]))
//                                {
//                                    // セットマスタに登録済みの親品番、親メーカーコード
//                                    this.Mode_Label.Text = UPDATE_MODE;
//                                    this.ParentGoodsCode_tEdit.Enabled = false;
//                                    this.ParentMakerCode_tNedit.Enabled = false;
//                                    this.ParentMakerGuide_Button.Enabled = false;
//                                }
//                            }
//                            // 2008.10.30 30413 犬飼 同一品番選択画面でのキャンセル処理を追加 >>>>>>START
//                            else if (status == -1)
//                            {
//                                // 同一品番選択画面でキャンセル
//                                // 商品情報クリア
//                                this.ParentGoodsCode_tEdit.Clear();
//                                this.ParentGoodsName_tEdit.Clear();

//                                // カーソル制御
//                                e.NextCtrl = e.PrevCtrl;
//                            }
//                            // 2008.10.30 30413 犬飼 同一品番選択画面でのキャンセル処理を追加 <<<<<<END
//                            else
//                            {
//                                #region -- 取得失敗 --
//                                TMsgDisp.Show(
//                                    this,
//                                    emErrorLevel.ERR_LEVEL_INFO,
//                                    this.Name,
//                                    // 2008.08.04 30413 犬飼 商品コード → 品番に変更 >>>>>>START
//                                    //"商品コード [" + searchCode + "] に該当するデータが存在しません。",
//                                    "品番 [" + searchCode + "] に該当するデータが存在しません。",
//                                    // 2008.08.04 30413 犬飼 商品コード → 品番に変更 <<<<<<END
//                                    -1,
//                                    MessageBoxButtons.OK);

//                                // 商品情報クリア
//                                this.ParentGoodsCode_tEdit.Clear();
//                                this.ParentGoodsName_tEdit.Clear();

//                                // カーソル制御
//                                e.NextCtrl = e.PrevCtrl;
//                                #endregion
//                            }
//                            #endregion

//                        }
//                        else
//                        {
//                            // 品番を元に戻す
//                            this.ParentGoodsCode_tEdit.DataText = "";
//                            // 品名のクリア
//                            this.ParentGoodsName_tEdit.DataText = "";
//                        }
//                        #endregion

//                        #region < 編集前データ保持 >
//                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//                        // 親商品情報が編集されたので編集前データとして保持
//                        this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
//                        this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
//                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05 T-Kidate END 
//                        #endregion

//                        // 2008.10.15 30413 犬飼 セット商品との同一チェック用に設定 >>>>>>START
//                        this._userControl.SetParentData(this.ParentGoodsCode_tEdit.Text, this.ParentMakerCode_tNedit.GetInt());
//                        // 2008.10.15 30413 犬飼 セット商品との同一チェック用に設定 <<<<<<END

//                        break;
//                    }
//                #endregion
//            }
//        }

//        /// <summary>
//        /// Control.Click イベント(ParentMakerGuide_Button)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// <br>Note        : 親商品メーカーガイドボタンがクリックされたときに発生します。</br>
//        /// <br>Programmer  : 30005 木建　翼</br>
//        /// <br>Date        : 2007.05.09</br>
//        /// </remarks>
//        private void ParentMakerGuide_Button_Click(object sender, EventArgs e)
//        {
//            // 2008.10.09 30413 犬飼 動作高速化対応 >>>>>>START
//            //GoodsAcs goodsAcs = new GoodsAcs();
//            //string msg;
//            //goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

//            MakerUMnt makerUMnt = new MakerUMnt();

//            //int status = goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out makerUMnt);
//            int status = this._goodsSetAcs.ExecuteMakerGuid(this._enterpriseCode, out makerUMnt);
//            // 2008.10.09 30413 犬飼 動作高速化対応 <<<<<<END

//            if (status != 0) return;

//            // 取得データ表示
//            this.ParentMakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
//            this.ParentMakerName_tEdit.DataText = makerUMnt.MakerName;

//            // 商品データとの整合性を取るため親商品情報のクリア
//            this.ParentGoodsCode_tEdit.Clear();
//            this.ParentGoodsName_tEdit.Clear();

//            #region < 編集前データ保持 >
//            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//            // 編集された親商品情報を編集前データとして保持
//            this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
//            this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
//            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05. T-Kidate END

//            // 次のコントロールへフォーカスを移動
//            this.SelectNextControl((Control)sender, true, true, true, true);
//            #endregion
//        }

//        // 2008.08.06 30413 犬飼 商品ガイドボタンイベントの削除 >>>>>>START
//        #region 商品ガイドボタンイベントの削除
//        ///// <summary>
//        ///// Control.Click イベント(ParentGoodsGuide_Button)
//        ///// </summary>
//        ///// <param name="sender">対象オブジェクト</param>
//        ///// <param name="e">イベントパラメータ</param>
//        ///// <remarks>
//        ///// <br>Note        : 親商品商品ガイドボタンがクリックされたときに発生します。</br>
//        ///// <br>Programmer  : 30005 木建　翼</br>
//        ///// <br>Date        : 2007.05.09</br>
//        ///// </remarks>
//        //private void ParentGoodsGuide_Button_Click(object sender, EventArgs e)
//        //{
//        //    MAKHN04110UA goodsGuide = new MAKHN04110UA();
//        //    GoodsUnitData goodsUnitData = new GoodsUnitData();
//        //    GoodsCndtn goodsCndtn = new GoodsCndtn();

//        //    // 検索条件の設定
//        //    goodsCndtn.EnterpriseCode = _enterpriseCode;
//        //    goodsCndtn.GoodsMakerCd = this.ParentMakerCode_tNedit.GetInt();

//        //    // 商品検索ガイドの起動
//        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate START
//        //    //goodsGuide.ShowGuide(this, false, goodsCndtn, out goodsUnitData);
//        //    goodsGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
//        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate END

//        //    // 何も選択されていなかったら
//        //    if (goodsUnitData == null)
//        //    {
//        //        return;
//        //    }

//        //    // 親商品情報画面表示
//        //    this.ParentMakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
//        //    this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
//        //    this.ParentGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
//        //    this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;

//        //    #region < 編集前データ保持 >
//        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
//        //    // 編集された親商品情報を編集前データとして保持
//        //    this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
//        //    this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
//        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05. T-Kidate END
//        //    #endregion
//        //}
//        #endregion
//        // 2008.08.06 30413 犬飼 商品ガイドボタンイベントの削除 <<<<<<END

//        #endregion

//        // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//        #region 削除
//        ///// <summary>
//        /////	商品セット情報取得
//        ///// </summary>
//        ///// <param name="parentGoodsNo">親品番</param>
//        ///// <param name="parentGoodsMakerCd">親メーカーコード</param>
//        ///// <param name="parentGoodsUnitDataList">親商品情報データリスト</param>
//        ///// <param name="childGoodsUnitDataList">セット商品情報データリスト</param>
//        ///// <remarks>
//        ///// Note			:	親商品とセット商品の情報を取得します。<br />
//        ///// Programmer		:	30413 犬飼<br />
//        ///// Date			:	2008.08.07<br />
//        ///// </remarks>
//        //private int GetGoodSetData(string parentGoodsNo, int parentGoodsMakerCd, out List<GoodsUnitData> parentGoodsUnitDataList, out List<GoodsUnitData> childGoodsUnitDataList)
//        //{
//        //    int status = -1;
//        //    string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
//        //    GoodsCndtn goodsCndtn = new GoodsCndtn();
//        //    PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
//        //    //List<GoodsUnitData> goodsUnitDataList;
//        //    string message;
//        //    parentGoodsUnitDataList = new List<GoodsUnitData>();
//        //    childGoodsUnitDataList = new List<GoodsUnitData>();

//        //    goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
//        //    goodsCndtn.SectionCode = sectionCd;
//        //    goodsCndtn.MakerName = "";
//        //    goodsCndtn.GoodsNoSrchTyp = 0;
//        //    goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
//        //    goodsCndtn.GoodsNo = parentGoodsNo;
//        //    goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

//        //    // 品番検索(結合検索なし)
//        //    status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out parentGoodsUnitDataList, out message);
//        //    if (status == 0)
//        //    {
//        //        GoodsUnitData wkGoodsUnitData = parentGoodsUnitDataList[0];
//        //        goodsCndtn.GoodsMakerCd = wkGoodsUnitData.GoodsMakerCd;
//        //        goodsCndtn.GoodsNo = wkGoodsUnitData.GoodsNo;

//        //        // 品番検索(結合検索有り完全一致)
//        //        status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
//        //        if (status != 0)
//        //        {
//        //            return status;
//        //        }
//        //    }
//        //    else
//        //    {
//        //        // 品番検索キャンセルor失敗
//        //        return status;
//        //    }
//        //    //status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList);
//        //    //status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
//        //    //if (status != 0)
//        //    //{
//        //    //    // 品番検索(結合検索なし)で再検索
//        //    //    status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out parentGoodsUnitDataList, out message);
//        //    //    // 処理終了
//        //    //    return status;
//        //    //}

//        //    // 商品情報取得時のメーカー、品番設定
//        //    int makerCode = parentGoodsUnitDataList[0].GoodsMakerCd;
//        //    string goodsNo = parentGoodsUnitDataList[0].GoodsNo;

//        //    //// 親商品情報の取得
//        //    //status = this._goodsSetAcs.SearchGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, GoodsAcs.GoodsKind.Parent, out parentGoodsUnitDataList);
//        //    //if (status != 0)
//        //    //{
//        //    //    // 処理終了
//        //    //    return status;
//        //    //}

//        //    // セット商品情報の取得
//        //    status = this._goodsSetAcs.SearchGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, GoodsAcs.GoodsKind.ChildSet, out childGoodsUnitDataList);

//        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない >>>>>>START
//        //    //// 品番検索結果をローカルキャッシュに追加
//        //    //this._goodsSetAcs.CacheUpdateGoodsSet(parentGoodsUnitDataList[0], childGoodsUnitDataList);
//        //    // 2008.11.07 30413 犬飼 商品情報のキャッシュを行わない <<<<<<END

//        //    return status;
//        //}
//        #endregion

//        /// <summary>
//        /// 商品セット情報取得
//        /// </summary>
//        /// <param name="iMode">0:品番入力時 1:一覧選択時</param>
//        /// <param name="parentGoodsNo">親品番</param>
//        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
//        /// <param name="parentGoodsUnitDataList">親商品情報データリスト</param>
//        /// <param name="childGoodsUnitDataList">子商品情報データリスト</param>
//        /// <returns></returns>
//        private int GetGoodSetData(int iMode, string parentGoodsNo, int parentGoodsMakerCd, out List<GoodsUnitData> parentGoodsUnitDataList, out List<GoodsUnitData> childGoodsUnitDataList)
//        {
//            int status = -1;
//            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
//            GoodsCndtn goodsCndtn = new GoodsCndtn();
//            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
//            string message;
//            parentGoodsUnitDataList = new List<GoodsUnitData>();
//            childGoodsUnitDataList = new List<GoodsUnitData>();

//            goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
//            goodsCndtn.SectionCode = sectionCd;
//            goodsCndtn.MakerName = "";
//            goodsCndtn.GoodsNoSrchTyp = 0;
//            goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
//            goodsCndtn.GoodsNo = parentGoodsNo;
//            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
//            // 2009.02.09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//            goodsCndtn.IsSettingSupplier = 1;
//            goodsCndtn.PriceApplyDate = DateTime.Today;
//            goodsCndtn.TotalAmountDispWayCd = 0; // 0:総額表示しない
//            goodsCndtn.ConsTaxLayMethod = 1; // 1:明細転嫁
//            goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:共通設定
//            // 2009.02.09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//            if (iMode == 0)
//            {
//                // 品番検索(結合検索なし)
//                status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out parentGoodsUnitDataList, out message);
//                if (status == 0)
//                {
//                    GoodsUnitData wkGoodsUnitData = parentGoodsUnitDataList[0];
//                    goodsCndtn.GoodsMakerCd = wkGoodsUnitData.GoodsMakerCd;
//                    goodsCndtn.GoodsNo = wkGoodsUnitData.GoodsNo;

//                    // 品番検索(結合検索有り完全一致)
//                    status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
//                    if (status != 0) return status;
//                }
//                else
//                {
//                    // 品番検索キャンセルor失敗
//                    return status;
//                }
//            }
//            else
//            {
//                goodsCndtn.GoodsMakerCd = parentGoodsMakerCd;
//                goodsCndtn.GoodsNo = parentGoodsNo;

//                // 品番検索(結合検索有り完全一致)
//                status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
//                // 2009.03.26 30413 犬飼 親商品の商品マスタ削除チェック >>>>>>START
//                //if (status != 0) return status;
//                if (status != 0)
//                {
//                    // 該当品番無し
//                    parentGoodsUnitDataList = new List<GoodsUnitData>();
//                    GoodsUnitData addGoodsUnitData = new GoodsUnitData();
//                    addGoodsUnitData.GoodsMakerCd = parentGoodsMakerCd;
//                    addGoodsUnitData.GoodsNo = parentGoodsNo;
//                    parentGoodsUnitDataList.Add(addGoodsUnitData);
//                }
//                // 2009.03.26 30413 犬飼 親商品の商品マスタ削除チェック <<<<<<END
//            }

//            // 商品情報取得時のメーカー、品番設定
//            int makerCode = parentGoodsUnitDataList[0].GoodsMakerCd;
//            string goodsNo = parentGoodsUnitDataList[0].GoodsNo;

//            // セット商品情報の取得
//            status = this._goodsSetAcs.SearchGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, GoodsAcs.GoodsKind.ChildSet, out childGoodsUnitDataList);

//            return status;
//        }
//        // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//        /// <summary>
//        ///	画面展開処理
//        /// </summary>
//        /// <param name="goodsUnitData">親商品セット情報データクラス</param>
//        /// <remarks>
//        /// Note			:	フォームに親商品情報を展開します。<br />
//        /// Programmer		:	30413 犬飼<br />
//        /// Date			:	2008.08.07<br />
//        /// </remarks>
//        private void DisplayScreen(GoodsUnitData goodsUnitData)
//        {
//            if (goodsUnitData != null)
//            {
//                #region ●親品番
//                this.ParentGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
//                this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;
//                #endregion

//                #region ●親商品メーカー
//                // DEL 2009/04/09 ------>>>
//                //this.ParentMakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
//                //this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
//                // DEL 2009/04/09 ------<<<

//                // ADD 2009/04/09 ------>>>
//                if (goodsUnitData.GoodsName == string.Empty)
//                {
//                    this.ParentMakerCode_tNedit.DataText = string.Empty;
//                    this.ParentMakerName_tEdit.DataText = string.Empty;
//                }
//                else
//                {
//                    this.ParentMakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
//                    this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
//                }
//                // ADD 2009/04/09 ------<<<
//                #endregion
//            }
//        }

//        /// <summary>
//        ///	画面展開処理(オーバーロード)
//        /// </summary>
//        /// <param name="rowNo">行番号</param>
//        /// <param name="goodsUnitData">セット商品情報データクラス</param>
//        /// <remarks>
//        /// Note			:	フォームにセット商品情報を展開します。<br />
//        /// Programmer		:	30413 犬飼<br />
//        /// Date			:	2008.08.07<br />
//        /// </remarks>
//        private void DisplayScreen(int rowNo, GoodsUnitData goodsUnitData)
//        {
//            #region ●グリッドデータ展開

//            // グリッドに表示するNoなので行数に１を加える
//            int No = rowNo + 1;
//            this._userControl.SetGoodsSetDataTable(No, goodsUnitData);

//            #endregion
//        }

//        /// <summary>
//        ///	ソート用の商品連結データ比較処理
//        /// </summary>
//        /// <param name="goodsA">商品連結データ(比較元)</param>
//        /// <param name="goodsB">商品連結データ(比較先)</param>
//        /// <remarks>
//        /// Note			:	商品連結データの比較を行います。<br />
//        /// Programmer		:	30413 犬飼<br />
//        /// Date			:	2008.08.21<br />
//        /// </remarks>
//        private static int CompareGoodsUnitData(GoodsUnitData goodsA, GoodsUnitData goodsB)
//        {
//            if (goodsA == null)
//            {
//                if (goodsB == null)
//                {
//                    return 0;
//                }
//                else
//                {
//                    return -1;
//                }
//            }
//            else
//            {
//                if (goodsB == null)
//                {
//                    return 1;
//                }
//                else
//                {
//                    if (goodsA.OfferKubun == 0 && goodsB.OfferKubun == 0)
//                    {
//                        return goodsA.SetDispOrder.CompareTo(goodsB.SetDispOrder);
//                    }
//                    else
//                    {
//                        if (goodsA.OfferKubun != 0 && goodsB.OfferKubun == 0)
//                        {
//                            return 0;
//                        }
//                        else
//                        {
//                            if (goodsA.OfferKubun != 0 && goodsB.OfferKubun != 0)
//                            {
//                                return goodsA.SetDispOrder.CompareTo(goodsB.SetDispOrder);
//                            }
//                            else
//                            {
//                                return -1;
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }
    // ------ DEL 2010/06/08 ----------<<<<<
    #endregion

    #region ADD 2010/06/08
    // ---- ADD 2010/06/08 --------->>>>>
    public partial class MAKHN09620UA : System.Windows.Forms.Form
    {
        #region ■ Private Const
        private const string ct_Tool_CloseButton = "ButtonTool_Close";						// 終了
        private const string ct_Tool_NewButton = "ButtonTool_New";							// 新規
        private const string ct_Tool_SaveButton = "ButtonTool_Save";							// 保存
        private const string ct_Tool_DeleteButton = "ButtonTool_Delete";						// 削除
        private const string ct_Tool_LoginEmployee = "LabelTool_LoginTitle";				// ログイン担当者タイトル
        private const string ct_Tool_LoginEmployeeName = "LabelTool_LoginName";		     // ログイン担当者名称
        private const string ctAssemblyName = "MAKHN09620UA"; // セットマスタアセンブリID // ADD gaocheng　2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応
        #endregion ■ Private Const

        #region ◆Constractor

        /// <summary>
        /// 商品セットフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品セットフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>    
        /// </remarks>
        public MAKHN09620UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
            
            // 商品セットマスタアクセスクラスインスタンス化
            _goodsSetAcs = new GoodsSetAcs();

            // ユーザーコントロールクラスインスタンス化
            _userControl = new MAKHN09620UB(_goodsSetAcs);

            this._userControl.InitialLoadFlag = true;  // ADD gaocheng　2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応

            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // --- DEL m.suzuki 2010/08/04 ---------->>>>>
            //// 商品データを検索する。
            //this.SearchProc(ref intOne, intTwo);
            // --- DEL m.suzuki 2010/08/04 ----------<<<<<

            // Eventの設定
            this._userControl.GridKeyDownTopRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownTopRow);
            this._userControl.GridKeyDownButtomRow += new EventHandler(this.GoodsSetDetailInput_GridKeyDownButtomRow);

        }

        #endregion

        # region ◆Private Members

        // 商品セットアクセスクラス
        private GoodsSetAcs _goodsSetAcs;
        // ユーザコントロールクラス
        private MAKHN09620UB _userControl;
        // 企業コード
        private string _enterpriseCode;

        // ログイン従業員
        private Employee _loginEmployee = null;
        
        private static GoodsSet _goodsSetClone;

        private int intOne;
        private int intTwo = 0;

        private bool _changeFlg;

        private ImageList _imageList24;
        private ImageList _imageList16;

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";

        private const string PG_ID = "MAKHN09620U";
        private const string PG_NM = "セットマスタ";

        // 編集前データ保持
        private int _prevParentMakerCode;
        private string _prevParentGoodsCode;

        //初期化フラグ
        private bool _initialLoadFlag = false;

        # endregion

        # region ◆Public Methods

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this._goodsSetAcs.GoodsSetDataSet;
            tableName = GoodsSetAcs.GOODSSET_TABLE;
        }

        /// <summary>
        ///	データ検索処理 
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note	   : 先頭から指定件数分のデータを検索し、
        ///					 抽出結果を展開し全該当件数,読込件数を返します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;

            if (readCount == 0)
            {
                status = this._goodsSetAcs.SearchAll(this._enterpriseCode, ref totalCount);
            }

            switch (status)
            {
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
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
                            this._goodsSetAcs,      				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        ///	グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note	   : 各列の外見を設定するクラスを格納したHashtableを
        ///					 取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            #region ■グリッド列設定
            /******************
             *①削除日
             *　論理削除区分
             *②複数
             *③親品番
             *④親品名
             *　親商品メーカーコード
             *⑤親商品メーカー名称
             *⑥品番
             *⑦品名
             *　メーカーコード
             *⑧メーカー名称
             *⑨ＱＴＹ(数量)
             *　表示順位
             *⑩セット規格・特記事項
             *⑪カタログ図番
             *　提供区分
             *⑫提供区分名称
             ******************/

            appearanceTable.Add(GoodsSetAcs.CHILDPLURALGOODS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.PARENTGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.PARENTGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.PARENTGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.PARENTGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.SUBGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.SUBGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.SUBGOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.SUBGOODSMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.CNTFL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.DISPLAYORDER_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.SETSPECIALNOTE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(GoodsSetAcs.CATALOGSHAPENO_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            #endregion
            
            return appearanceTable;
        }

        #endregion

        #region ◆Private Methods

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面の初期設定を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // アイコン設定
            this._imageList24 = IconResourceManagement.ImageList24;
            this._imageList16 = IconResourceManagement.ImageList16;

            // ガイドボタンのアイコン設定
            this.ParentMakerGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];

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
        /// <br>Note	   : 画面をクリアします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        ///</remarks>
        private void ScreenClear()
        {
            this.ParentMakerCode_tNedit.Clear();
            this.ParentMakerName_tEdit.Clear();
            this.ParentGoodsCode_tEdit.Clear();
            this.ParentGoodsName_tEdit.Clear();

            // 編集前情報をクリア
            this._prevParentMakerCode = 0;
            this._prevParentGoodsCode = "";
        }

        /// <summary>
        ///	画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : モードに基づいて入力画面を再構築します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenReconstruction()
        {

            // セット商品情報表示データテーブルをクリア
            this._userControl.ClearGoodsSetDataTable();
            // グリッド初期設定処理の呼び出し
            this._userControl.SetGoodsSetGrid();

            //新規登録画面
            ScreenAccordingToMode(0);

            #region < 変更チェック用クローン作成 >
            // 画面変更されたかチェックをするためクローン作成
            _goodsSetClone = new GoodsSet(); 
            this.DispToGoodsSet(ref _goodsSetClone);
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

        /// <summary>
        ///	モード別画面構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : モード別に画面を構築します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenAccordingToMode(int mode)
        {
            Control focusControl = new Control();

            switch (mode)
            {
                case 0:

                    #region ■新規登録

                    this.Mode_Label.Text = INSERT_MODE;

                    this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = false;

                    ScreenInputPermissionControl(true);

                    focusControl = this.ParentGoodsCode_tEdit;
                    
                    break;
                    #endregion
            }

            focusControl.Focus();
        }

        /// <summary>
        ///	画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note	   : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {
            // モードによって入力許可を制御
            this.ParentMakerCode_tNedit.Enabled     = enabled;
            this.ParentGoodsCode_tEdit.Enabled      = enabled;
            this.ParentMakerGuide_Button.Enabled    = enabled;  // 親商品メーカーガイドボタン
            // グリッド上ボタン許可制御
            this._userControl.GridButtonPermissionControl(enabled);
            // グリッド編集許可制御
            this._userControl.GridInputPermissionControl(enabled);
        }

        /// <summary>
        ///	画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : フォームにデータテーブルのデータを展開します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DisplayScreen(DataRow dataRow)
        {
            #region ●親商品メーカー
            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSMAKERCD_TITLE))
            {
                this.ParentMakerCode_tNedit.SetInt((int)(dataRow[GoodsSetAcs.PARENTGOODSMAKERCD_TITLE]));
            }
            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSMAKERNM_TITLE))
            {
                this.ParentMakerName_tEdit.DataText = (string)(dataRow[GoodsSetAcs.PARENTGOODSMAKERNM_TITLE]);
            }
            #endregion

            #region ●親品番
            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSNO_TITLE))
            {
                this.ParentGoodsCode_tEdit.DataText = (string)(dataRow[GoodsSetAcs.PARENTGOODSNO_TITLE]);
            }
            if (!dataRow.IsNull(GoodsSetAcs.PARENTGOODSNAME_TITLE))
            {
                this.ParentGoodsName_tEdit.DataText = (string)(dataRow[GoodsSetAcs.PARENTGOODSNAME_TITLE]);
            }
            #endregion
        }

        /// <summary>
        ///	画面展開処理(オーバーロード)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : フォームにデータテーブルのデータを展開します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DisplayScreen(int rowNo, ref DataRow dataRow)
        {
            #region ●グリッドデータ展開

            // グリッドに表示するNoなので行数に１を加える
            int No = rowNo + 1;     
            this._userControl.SetGoodsSetDataTable(No, dataRow);

            #endregion
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <returns>結果[true: 正常, false: 異常]</returns>
        /// <remarks>
        /// <br>Note       : 商品セット情報の検索処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SearchProc(ref int totalCount, int readCount)
        {
            int status = -1;

            #region < 全件検索 >
            if (readCount == 0)
            {
                status = this._goodsSetAcs.SearchAll(this._enterpriseCode, ref totalCount);
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
                            this._goodsSetAcs,             			// エラーが発生したオブジェクト
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
        /// <br>Note       : 商品セット情報の登録・更新処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SaveProc()
        {
            int status = -1;

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
            List<GoodsSet> writeDataList = new List<GoodsSet>();
            
            // 有効なデータ行リストを取得
            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

            // エラー行番号が"0"のときのみ正常
            if (errorRowNo == 0)
            {
                // 書き込みを行なうデータクラスのリストを作成する
                for (int i = 0; i < effectDataList.Count; i++)
                {
                    GoodsSet goodsSet = new GoodsSet();
                    this.DispToGoodsSet(effectDataList[i], ref goodsSet);
                    writeDataList.Add(goodsSet);
                }
            }
            #endregion

            #region < 物理削除データ準備処理 >
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
            List<GoodsSet> delDataList = new List<GoodsSet>();

            // 削除対象データの取得
            this._userControl.GetDeleteData(out deleteDataList);

            // 削除を行なうデータクラスのリストを作成する
            for (int i = 0; i < deleteDataList.Count; i++)
            {
                GoodsSet goodsSet = new GoodsSet();
                // 完全削除
                this.DispToGoodsSet(deleteDataList[i], ref goodsSet);
                delDataList.Add(goodsSet);
            }
            #endregion

            #region < 物理削除処理 >
            // 削除対象があれば該当レコードを削除
            if (deleteDataList.Count != 0)
            {
                status = this._goodsSetAcs.DeleteUnique(delDataList);
            }
            else
            {
                status = 0;
            }
            #endregion

            #region < 登録処理 >
            if (status == 0)
            {

                // 商品セット設定書き込み処理
                Dictionary<string, GoodsUnitData> goodsUnitDataDic;
                _userControl.GetLC_GoodsUnitData(out goodsUnitDataDic);
                status = this._goodsSetAcs.Write(writeDataList, goodsUnitDataDic);
            }
            #endregion
            
            #region < 登録後処理 >
            switch (status)
            {
                #region -- 通常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
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
                    if (this.ParentMakerCode_tNedit.Enabled == true)
                    {
                        this.ParentMakerCode_tNedit.Focus();
                        this.ParentMakerCode_tNedit.SelectAll();
                    }
                    break;
                #endregion

                #region -- 排他制御 --
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status);
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
                        this._goodsSetAcs,                    // エラーが発生したオブジェクト
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
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
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
        /// <param name="goodsSet">商品セットデータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面情報のデータクラス格納処理を行います</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DispToGoodsSet(ref GoodsSet goodsSet)
        {
            goodsSet.ParentGoodsMakerCd     = this.ParentMakerCode_tNedit.GetInt();         // 親商品メーカーコード
            goodsSet.ParentGoodsNo          = this.ParentGoodsCode_tEdit.DataText;          // 親品番
        }

        /// <summary>
        /// 画面情報格納処理(オーバーロード)
        /// </summary>
        /// <param name="row">セット商品情報入力データテーブル行</param>
        /// <param name="goodsSet">商品セットデータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面情報のデータクラス格納処理を行います</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DispToGoodsSet(GoodsSetGoodsDataSet.GoodsSetDetailRow row, ref GoodsSet goodsSet)
        {

            goodsSet.EnterpriseCode = this._enterpriseCode;                            // 企業コード

            goodsSet.ParentGoodsMakerCd  = this.ParentMakerCode_tNedit.GetInt();       // 親商品メーカーコード
            goodsSet.ParentGoodsNo       = this.ParentGoodsCode_tEdit.DataText;        // 親品番
            goodsSet.ParentGoodsName     = this.ParentGoodsName_tEdit.DataText;        // 親品名
            // セット商品情報のクローンを作成する処理を追加
            goodsSet.SubGoodsMakerCd = int.Parse(row.MakerCode);                              // メーカーコード
            goodsSet.SubGoodsNo = row.GoodsCode;                              // 品番
            goodsSet.SubGoodsName        = row.GoodsName;                              // 品名
            goodsSet.CntFl = double.Parse(row.CntFl);                                  // 数量
            goodsSet.DisplayOrder = row.Disply;                                 // 表示順位
            goodsSet.SetSpecialNote      = row.SetNote;                                // セット規格・特記事項
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果[true: OK, false: NG]</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            #region ●親商品情報入力チェック
            #region < メーカーコードの入力チェック >
            if ((this.ParentMakerCode_tNedit.Enabled) && (this.ParentMakerCode_tNedit.Text.TrimEnd() == ""))
            {
                message = this.ParentMakerCode_Label.Text + "を入力してください。";
                control = this.ParentMakerCode_tNedit;
                result = false;
                return result;
            }
            #endregion

            #region < 品番の入力チェック >
            if (this.ParentGoodsCode_tEdit.Text.TrimEnd() == "")
            {
                message = this.ParentGoodsCode_Label.Text + "を入力してください。";
                control = this.ParentGoodsCode_tEdit;
                result = false;
                return result;
            }
            #endregion

            #region < 品名のチェック >
            if (this.ParentGoodsName_tEdit.Text.TrimEnd() == "")
            {
                message = "親商品が商品マスタから削除されています。";
                control = this.ParentGoodsCode_tEdit;
                result = false;
                return result;
            }
            #endregion
            
            #endregion

            #region ●セット商品情報入力チェック

            result = _userControl.GridDataCheck(ref control, ref message);
            
            #endregion

            return result;
        }

        /// <summary>
        /// 画面変更確認処理
        /// </summary>
        /// <returns>チェック結果[true: 変更有, false: 変更無]</returns>
        /// <remarks>
        /// <br>Note       : キャンセルボタン押下時、画面に変更があったかのチェックを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private bool CheckScreenChange()
        {
            bool result = false;

            GoodsSet goodsSetBefore = new GoodsSet();
            GoodsSet goodsSetAfter = new GoodsSet();

            // 画面から取得するデータを編集後のデータとする
            this.DispToGoodsSet(ref goodsSetAfter);

            #region < 親商品情報比較処理 >
            // 画面表示時(クローン)と比較をして違いがあるかチェックする
            ArrayList DisagreementList = _goodsSetClone.Compare(goodsSetAfter);
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
        private void GoodsSetDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
        {
            this.ParentGoodsCode_tEdit.Focus();
            this.ParentGoodsCode_tEdit.SelectAll();
        }

        /// <summary>
        /// 詳細グリッド最下層行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void GoodsSetDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
        {
        }

        #endregion

        #region ◆ControlEvent

        /// <summary>
        /// Form.Load イベント (MAKHN09620UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks>
         private void MAKHN09620UA_Load(object sender, EventArgs e)
        {
             // 画面を構築
             this.ScreenInitialSetting();

             this.panel_Detail.Controls.Add(_userControl);

             // 設定読み込み
             this._userControl.Deserialize(); // ADD ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応

             Initial_timer.Enabled = true;

             // 画面ロード時に表示された親商品情報を編集前データとして保持
             this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
             this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// <br>Update Note: 2015/07/02 gaocheng</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks>
        private void Initial_timer_Tick(object sender, EventArgs e)
        {
            Initial_timer.Enabled = false;
            ScreenReconstruction();
            //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正 ---->>>>>
            // 画面初期化のみ明細グリッドセット
            if (this._userControl.InitialLoadFlag)
            {
                // 明細グリッドセット
                this._userControl.LoadGridColumnsSetting(this._userControl.uGrid_Details, this._userControl.UserSetting.DetailColumnsList); 
            }
            this._userControl.InitialLoadFlag = false;
            //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正 ----<<<<<
        }

        /// <summary>
        ///	Control.ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	フォーカス移動時に発生します。</br>
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
                                            if (this._userControl.ReturnKeyDown())
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else
                                            {
                                            }
                                        }

                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if ((this._userControl.uGrid_Details.ActiveCell.Column.Index == 1) && (this._userControl.uGrid_Details.ActiveCell.Row.Index == 0))
                                        {
                                            if (this.ParentMakerCode_tNedit.Enabled)
                                            {
                                                if (this.ParentMakerCode_tNedit.Text != "")
                                                {
                                                    // メーカーにフォーカス遷移
                                                    e.NextCtrl = this.ParentMakerCode_tNedit;
                                                }
                                                else
                                                {
                                                    // メーカーガイドにフォーカス遷移
                                                    e.NextCtrl = ParentMakerGuide_Button;
                                                }
                                            }
                                            else
                                            {
                                            }
                                        }
                                        else
                                        {
                                            if (this._userControl.ReturnKeyDown2())
                                            {
                                                e.NextCtrl = null;
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
            case "ParentMakerCode_tNedit":
                {
                    #region < 編集チェック >
                    // 変数保持
                    int parentMakerCode = this.ParentMakerCode_tNedit.GetInt();
                    
                    if (this._prevParentMakerCode == parentMakerCode)
                    {
                        // 編集前と同じなら処理を行なわない
                        if (parentMakerCode != 0)
                        {
                            // カーソル制御
                            e.NextCtrl = this._userControl;
                        }
                        return;
                    }
                    #endregion

                    #region < ゼロ入力チェック >
                    if (this.ParentMakerCode_tNedit.GetInt() != 0)
                    {
                        // メーカーデータクラス
                        MakerUMnt makerUMnt;
                        // 商品データクラスインスタンス化

                        #region < メーカー情報取得処理 >
                        this._goodsSetAcs.GetMaker(this._enterpriseCode, this.ParentMakerCode_tNedit.GetInt(), out makerUMnt);
                        #endregion
        
                        #region < 画面表示処理 >

                        if (makerUMnt != null)
                        {
                            #region -- 取得データ展開 --
                            // メーカー情報画面表示
                            this.ParentMakerName_tEdit.DataText = makerUMnt.MakerName;

                            // 商品情報はクリア
                            this.ParentGoodsCode_tEdit.Clear();
                            this.ParentGoodsName_tEdit.Clear();

                            // カーソル制御
                            e.NextCtrl = this._userControl;
                            
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

                            this.ParentMakerCode_tNedit.Clear();
                            this.ParentMakerName_tEdit.Clear();

                            // カーソル制御
                            e.NextCtrl = e.PrevCtrl;
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        this.ParentMakerCode_tNedit.Clear();
                        this.ParentMakerName_tEdit.Clear();
                    }
                    #endregion

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
                    this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
                    #endregion

                    this._userControl.SetParentData(this.ParentGoodsCode_tEdit.Text, this.ParentMakerCode_tNedit.GetInt());

                    break;
                }
                
                #endregion

                #region ●商品情報検索
                case "ParentGoodsCode_tEdit":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string parentGoodsCode = this.ParentGoodsCode_tEdit.DataText;

                        if (this._prevParentGoodsCode == parentGoodsCode)
                        {
                            // 編集前と同じなら処理を行なわない
                            return;
                        }
                        #endregion

                        #region < 空入力チェック >
                        if (this.ParentGoodsCode_tEdit.DataText != "")
                        {
                            string searchCode;
                            // 検索の種類を取得
                            int searchType = this._userControl.GetSearchType(this.ParentGoodsCode_tEdit.DataText, out searchCode);

                            List<GoodsUnitData> parentGoodsUnitDataList;
                            List<GoodsUnitData> childGoodsUnitDataList;
                            string parentGoodsNo = this.ParentGoodsCode_tEdit.DataText;
                            int parentGoodsMakerCd = 0; // ADD 2009/03/16

                            int status = this.GetGoodSetData(0, parentGoodsNo, parentGoodsMakerCd, out parentGoodsUnitDataList, out childGoodsUnitDataList);

                            
                            #region < 画面表示処理 >
                            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (parentGoodsUnitDataList != null) && (parentGoodsUnitDataList.Count > 0))
                            {

                                #region -- 親商品情報を展開 --
                                this.DisplayScreen(parentGoodsUnitDataList[0]);
                                #endregion

                                #region -- セット商品情報を展開 --
                                childGoodsUnitDataList.Sort(CompareGoodsUnitData);
                                for (int i = 0; i < childGoodsUnitDataList.Count; i++)
                                {
                                    DisplayScreen(i, childGoodsUnitDataList[i]);
                                }
                                #endregion

                                // UI画面のモード変更チェック
                                if (this._goodsSetAcs.CheckModeChange(parentGoodsUnitDataList[0]))
                                {
                                    // セットマスタに登録済みの親品番、親メーカーコード
                                    this.Mode_Label.Text = UPDATE_MODE;
                                    this.tToolsManager_MainMenu.Tools[ct_Tool_DeleteButton].SharedProps.Enabled = true;
                                    this.ParentGoodsCode_tEdit.Enabled = false;
                                    this.ParentMakerCode_tNedit.Enabled = false;
                                    this.ParentMakerGuide_Button.Enabled = false;
                                }
                            }
                            else if (status == -1)
                            {
                                // 同一品番選択画面でキャンセル
                                // 商品情報クリア
                                this.ParentGoodsCode_tEdit.Clear();
                                this.ParentGoodsName_tEdit.Clear();

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
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
                                this.ParentGoodsCode_tEdit.Clear();
                                this.ParentGoodsName_tEdit.Clear();

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            #endregion

                        }    
                        else
                        {
                            // 品番を元に戻す
                            this.ParentGoodsCode_tEdit.DataText = "";
                            // 品名のクリア
                            this.ParentGoodsName_tEdit.DataText = "";
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 親商品情報が編集されたので編集前データとして保持
                        this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
                        this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;
                        #endregion

                        this._userControl.SetParentData(this.ParentGoodsCode_tEdit.Text, this.ParentMakerCode_tNedit.GetInt());

                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// Control.Click イベント(ParentMakerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 親商品メーカーガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void ParentMakerGuide_Button_Click(object sender, EventArgs e)
        {
            
            MakerUMnt makerUMnt = new MakerUMnt();

            int status = this._goodsSetAcs.ExecuteMakerGuid(this._enterpriseCode, out makerUMnt);
            
            if (status != 0) return;

            // 取得データ表示
            this.ParentMakerCode_tNedit.SetInt(makerUMnt.GoodsMakerCd);
            this.ParentMakerName_tEdit.DataText = makerUMnt.MakerName;

            // 商品データとの整合性を取るため親商品情報のクリア
            this.ParentGoodsCode_tEdit.Clear();
            this.ParentGoodsName_tEdit.Clear();
            
            #region < 編集前データ保持 >
            // 編集された親商品情報を編集前データとして保持
            this._prevParentMakerCode = this.ParentMakerCode_tNedit.GetInt();
            this._prevParentGoodsCode = this.ParentGoodsCode_tEdit.DataText;

            // 次のコントロールへフォーカスを移動
            this.SelectNextControl((Control)sender, true, true, true, true);
            #endregion
        }
        
        #endregion

        /// <summary>
        /// 商品セット情報取得
        /// </summary>
        /// <param name="iMode">0:品番入力時 1:一覧選択時</param>
        /// <param name="parentGoodsNo">親品番</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsUnitDataList">親商品情報データリスト</param>
        /// <param name="childGoodsUnitDataList">子商品情報データリスト</param>
        /// <returns></returns>
        private int GetGoodSetData(int iMode, string parentGoodsNo, int parentGoodsMakerCd, out List<GoodsUnitData> parentGoodsUnitDataList, out List<GoodsUnitData> childGoodsUnitDataList)
        {
            int status = -1;
            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
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
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            goodsCndtn.IsSettingSupplier = 1;
            goodsCndtn.PriceApplyDate = DateTime.Today;
            goodsCndtn.TotalAmountDispWayCd = 0; // 0:総額表示しない
            goodsCndtn.ConsTaxLayMethod = 1; // 1:明細転嫁
            goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:共通設定
            if (iMode == 0)
            {
                // 品番検索(結合検索なし)
                status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out parentGoodsUnitDataList, out message);
                if (status == 0)
                {
                    GoodsUnitData wkGoodsUnitData = parentGoodsUnitDataList[0];
                    goodsCndtn.GoodsMakerCd = wkGoodsUnitData.GoodsMakerCd;
                    goodsCndtn.GoodsNo = wkGoodsUnitData.GoodsNo;

                    // 品番検索(結合検索有り完全一致)
                    status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);
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
                status = this._goodsSetAcs.SearchGoodSetData(goodsCndtn, out partsInfoDataSet, out parentGoodsUnitDataList);

                if (status != 0)
                {
                    // 該当品番無し
                    parentGoodsUnitDataList = new List<GoodsUnitData>();
                    GoodsUnitData addGoodsUnitData = new GoodsUnitData();
                    addGoodsUnitData.GoodsMakerCd = parentGoodsMakerCd;
                    addGoodsUnitData.GoodsNo = parentGoodsNo;
                    parentGoodsUnitDataList.Add(addGoodsUnitData);
                }
            }

            // 商品情報取得時のメーカー、品番設定
            int makerCode = parentGoodsUnitDataList[0].GoodsMakerCd;
            string goodsNo = parentGoodsUnitDataList[0].GoodsNo;

            // --- ADD m.suzuki 2010/08/04 ---------->>>>>
            // ユーザー登録分のセットマスタ抽出・キャッシュ
            GoodsSet readCndtn = new GoodsSet();
            readCndtn.EnterpriseCode = _enterpriseCode;
            readCndtn.ParentGoodsMakerCd = makerCode;
            readCndtn.ParentGoodsNo = goodsNo;
            _goodsSetAcs.Read( readCndtn );
            // --- ADD m.suzuki 2010/08/04 ----------<<<<<

            // セット商品情報の取得
            status = this._goodsSetAcs.SearchGoodsUnitData(partsInfoDataSet, makerCode, goodsNo, GoodsAcs.GoodsKind.ChildSet, out childGoodsUnitDataList);

            return status;
        }

        /// <summary>
        ///	画面展開処理
        /// </summary>
        /// <param name="goodsUnitData">親商品セット情報データクラス</param>
        /// <remarks>
        /// <br>Note			:	フォームに親商品情報を展開します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DisplayScreen(GoodsUnitData goodsUnitData)
        {
            if (goodsUnitData != null)
            {
                #region ●親品番
                this.ParentGoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
                this.ParentGoodsName_tEdit.DataText = goodsUnitData.GoodsName;
                #endregion

                #region ●親商品メーカー
                if (goodsUnitData.GoodsName == string.Empty)
                {
                    this.ParentMakerCode_tNedit.DataText = string.Empty;
                    this.ParentMakerName_tEdit.DataText = string.Empty;
                }
                else
                {
                    this.ParentMakerCode_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
                    this.ParentMakerName_tEdit.DataText = goodsUnitData.MakerName;
                }
                #endregion
            }
        }

        /// <summary>
        ///	画面展開処理(オーバーロード)
        /// </summary>
        /// <param name="rowNo">行番号</param>
        /// <param name="goodsUnitData">セット商品情報データクラス</param>
        /// <remarks>
        /// <br>Note			:	フォームにセット商品情報を展開します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private void DisplayScreen(int rowNo, GoodsUnitData goodsUnitData)
        {
            #region ●グリッドデータ展開

            // グリッドに表示するNoなので行数に１を加える
            int No = rowNo + 1;
            this._userControl.SetGoodsSetDataTable(No, goodsUnitData);

            #endregion
        }

        /// <summary>
        ///	ソート用の商品連結データ比較処理
        /// </summary>
        /// <param name="goodsA">商品連結データ(比較元)</param>
        /// <param name="goodsB">商品連結データ(比較先)</param>
        /// <remarks>
        /// <br>Note			:	商品連結データの比較を行います。</br>
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
                        return goodsA.SetDispOrder.CompareTo(goodsB.SetDispOrder);
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
                                return goodsA.SetDispOrder.CompareTo(goodsB.SetDispOrder);
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
        /// <br>Date        : 2010/06/08</br>
        /// <br>UpdateNote  : 2010/12/03  鄧潘ハン</br>
        /// <br>修正内容    : １．明細行を全て削除後に、ヘッダ部の削除ボタンを押下するとエラーが発生する不具合の修正</br>
        /// <br>              ２．複数行の明細があるセット品の明細の一部を行削除し、ヘッダ部の削除ボタンを実行した場合の削除処理の不正</br>
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
                        if (SaveProc() != 0)
                        {
                            return;
                        }

                        ScreenClear();

                        // フォーカスを商品セットコードにして全選択にする
                        this.ParentMakerCode_tNedit.Focus();
                        this.ParentMakerCode_tNedit.SelectAll();

                        // 画面の再構築を行なうため
                        this.Initial_timer.Enabled = true;

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
                            GoodsSet goodsSet;
                            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList;
                            List<GoodsSet> delDataList = new List<GoodsSet>();

                            // 有効なデータ行リストを取得
                            this._userControl.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);

                            // エラー行番号が"0"のときのみ正常
                            if (errorRowNo == 0)
                            {
                                // 書き込みを行なうデータクラスのリストを作成する
                                for (int i = 0; i < effectDataList.Count; i++)
                                {
                                    goodsSet = new GoodsSet();
                                    this.DispToGoodsSet(effectDataList[i], ref goodsSet);
                                    delDataList.Add(goodsSet);
                                }
                            }
                            // ---ADD 2010/12/03 ---------------------------------------->>>>>
                            // 削除対象データの取得
                            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
                            this._userControl.GetDeleteData(out deleteDataList);

                            // 削除を行なうデータクラスのリストを作成する
                            for (int i = 0; i < deleteDataList.Count; i++)
                            {
                                goodsSet = new GoodsSet();
                                // 完全削除
                                this.DispToGoodsSet(deleteDataList[i], ref goodsSet);
                                delDataList.Add(goodsSet);
                            }
                            // ---ADD 2010/12/03 ----------------------------------------<<<<<
                            #endregion

                            #region < 物理削除処理 >
                            int status = this._goodsSetAcs.Delete(delDataList);
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
                                        ExclusiveTransaction(status);
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
                                            this._goodsSetAcs, 	    				// エラーが発生したオブジェクト
                                            MessageBoxButtons.OK, 					// 表示するボタン
                                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                                        return;
                                    }
                                #endregion
                            }
                            #endregion

                            #region 初期戻る
                            ScreenClear();

                            // セット商品情報表示データテーブルをクリア
                            this._userControl.ClearGoodsSetDataTable();
                            // グリッド初期設定処理の呼び出し
                            this._userControl.SetGoodsSetGrid();

                            //新規登録画面
                            ScreenAccordingToMode(0);
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

                                // セット商品情報表示データテーブルをクリア
                                this._userControl.ClearGoodsSetDataTable();
                                // グリッド初期設定処理の呼び出し
                                this._userControl.SetGoodsSetGrid();

                                //新規登録画面
                                ScreenAccordingToMode(0);
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                ScreenClear();

                                // セット商品情報表示データテーブルをクリア
                                this._userControl.ClearGoodsSetDataTable();
                                // グリッド初期設定処理の呼び出し
                                this._userControl.SetGoodsSetGrid();

                                //新規登録画面
                                ScreenAccordingToMode(0);
                            }
                        }
                        else
                        {
                            ScreenClear();

                            // セット商品情報表示データテーブルをクリア
                            this._userControl.ClearGoodsSetDataTable();
                            // グリッド初期設定処理の呼び出し
                            this._userControl.SetGoodsSetGrid();

                            //新規登録画面
                            ScreenAccordingToMode(0);
                        }

                        break;
                    }
            }
        }

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
        # region [フォームクローズ前処理]
        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームクロージングイベントを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>  
        /// </remarks>
        private void MAKHN09620UA_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// フォームクローズ前処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : FormClosingイベントだと×ボタン時に抜けてしまうので、Parentでウィンドウメッセージを扱う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>  
        /// </remarks> 
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
        /// <remarks>
        /// <br>Note       : ユーザー設定保存処理</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>    
        /// </remarks>  
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
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

        //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正 ---->>>>>
        /// <summary>
        /// セットマスタフォームサーズの移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォームサイズ変更イベントを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/05/08</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正</br>    
        /// </remarks>   
        private void MAKHN09620UA_SizeChanged(object sender, EventArgs e)
        {
            this.ultraLabel3.Width = this.ultraLabel2.Width;
            this.ultraLabel3.Height = this.ultraLabel4.Height;
            this.Mode_Label.Location = new Point(this.ultraLabel2.Location.X + this.ultraLabel2.Width - this.Mode_Label.Width, this.Mode_Label.Location.Y);
            this.panel_Detail.Location = new Point(this.ultraLabel3.Location.X + 29, this.ultraLabel3.Location.Y + 12);
            this.panel_Detail.Width = this.ultraLabel3.Location.X + this.ultraLabel3.Width - this.panel_Detail.Location.X - 13;
            this.panel_Detail.Height = this.ultraLabel3.Location.Y + this.ultraLabel3.Height - this.panel_Detail.Location.Y - 13;
            this._userControl.SettingGridWidth(this.panel_Detail.Width, this.panel_Detail.Height);
            this.SizeChanged -= new EventHandler(MAKHN09620UA_SizeChanged);
            this.Height = this.Height + 1;
            this.Height = this.Height - 1;
            this.SizeChanged += new System.EventHandler(this.MAKHN09620UA_SizeChanged);
        }

        /// <summary>
        /// メインパネルの位置移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : メインパネルの位置変更イベントを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/05/08</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正</br>    
        /// </remarks>    
        private void MAKHN09620UA_Fill_Panel_LocationChanged(object sender, EventArgs e)
        {
            this.ultraLabel3.Width = this.ultraLabel2.Width;
            this.ultraLabel3.Height = this.ultraLabel4.Height;
            this.Mode_Label.Location = new Point(this.ultraLabel2.Location.X + this.ultraLabel2.Width - this.Mode_Label.Width, this.Mode_Label.Location.Y);
            this.panel_Detail.Location = new Point(this.ultraLabel3.Location.X + 29, this.ultraLabel3.Location.Y + 12);
            this.panel_Detail.Width = this.ultraLabel3.Location.X + this.ultraLabel3.Width - this.panel_Detail.Location.X - 13;
            this.panel_Detail.Height = this.ultraLabel3.Location.Y + this.ultraLabel3.Height - this.panel_Detail.Location.Y - 13;
            this._userControl.SettingGridWidth(this.panel_Detail.Width, this.panel_Detail.Height);
        }

        /// <summary>
        /// メインパネルのサイズ移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : メインパネルサイズ変更イベントを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/05/08</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正</br>    
        /// </remarks>     
        private void MAKHN09620UA_Fill_Panel_SizeChanged(object sender, EventArgs e)
        {
            this.ultraLabel3.Width = this.ultraLabel2.Width;
            this.ultraLabel3.Height = this.ultraLabel4.Height;
            this.Mode_Label.Location = new Point(this.ultraLabel2.Location.X + this.ultraLabel2.Width - this.Mode_Label.Width, this.Mode_Label.Location.Y);
            this.panel_Detail.Location = new Point(this.ultraLabel3.Location.X + 29, this.ultraLabel3.Location.Y + 12);
            this.panel_Detail.Width = this.ultraLabel3.Location.X + this.ultraLabel3.Width - this.panel_Detail.Location.X - 13;
            this.panel_Detail.Height = this.ultraLabel3.Location.Y + this.ultraLabel3.Height - this.panel_Detail.Location.Y - 13;
            this._userControl.SettingGridWidth(this.panel_Detail.Width, this.panel_Detail.Height);
        }
        //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正 ----<<<<<
    }
    // ---- ADD 2010/06/08 ---------<<<<<
    #endregion ADD 2010/06/08
}