//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入庫更新
// プログラム概要   : 在庫入庫更新で使用するデータの編集を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2008/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/14  修正内容 : 在庫調整明細取得時のバグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/16  修正内容 : 不具合対応[10145]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/19  修正内容 : 不具合対応[10178]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/04  修正内容 : MANTIS外不具合対応　代替品時、更新仕入明細データの発注数は変更しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/17  修正内容 : 不具合対応[10140][10177][10529]
//                                  ・HeaderNoAndGuidJoin(計上データの明細とヘッダーを紐付ける)、StockSlipAndDetailJoin(仕入と仕入明細を紐付ける)の各DataSet追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/25  修正内容 : 在庫調整データの作成方法変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/27  修正内容 : 不具合対応[13289]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 修 正 日  2010/11/01  修正内容 : MANTIS[0016444]対応
//                                 ①在庫調整明細データの受払元伝票区分、受払元取引区分のセット修正
//                                 ②在庫調整データの仕入金額小計を再集計するように修正
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 劉亜駿 							
// 修 正 日  2012/02/08  修正内容 : 2012/03/28配信分、Redmine#28282　 							
//                                  在庫入庫更新のエラーを修正する							
//----------------------------------------------------------------------------// 							
// 管理番号  10801804-00 作成担当 : 鄧潘ハン
// 修 正 日  2012/08/30  修正内容 : 2012/09/12配信分、redmine #31885:吉田商会　在庫入庫更新処理の対応
//----------------------------------------------------------------------------//	
// 管理番号  10801804-00 作成担当 : 鄧潘ハン
// 修 正 日  2012/09/28  修正内容 : 2012/09/12配信分、redmine #31885:吉田商会　仕入先マスタの次回勘定が未設定の場合は仕入計上日＝仕入日となるように修正の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱 猛
// 修 正 日  2012/10/02  修正内容 : 2012/09/12配信分、redmine #31885:吉田商会　仕入日計算に支払月区分を使用しないように修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 朱 猛
// 修 正 日  2012/10/10  修正内容 : 2012/09/17配信分、Redmine#32625 消費税計算不正の対応。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenw
// 作 成 日  2013/03/07  修正内容 : 2013/04/03配信分
//                                  Redmine#34989の対応 日産UOEWEBの改良(ＯＰＥＮ価格対応)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李占川
// 修 正 日  2013/05/16  修正内容 : 2013/06/18配信分、Redmine#35459 #42の対応
//----------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE入庫更新 データ確定専用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE入庫更新データの確定処理を行います。</br>
    /// <br>Programmer	: 照田 貴志</br>
    /// <br>Date		: 2008/09/04</br>
    /// <br>UpdateNote  : 2009/01/14 照田 貴志　在庫調整明細取得時のバグ修正 </br>
    /// <br>            : 2009/01/16 照田 貴志　不具合対応[10145]</br>
    /// <br>            : 2009/01/19 照田 貴志　不具合対応[10178]</br>
    /// <br>            : 2009/02/04 照田 貴志　MANTIS外不具合対応　代替品時、更新仕入明細データの発注数は変更しない</br>
    /// <br>            : 2009/02/17 照田 貴志　不具合対応[10140][10177][10529]</br>
    /// <br>              ・HeaderNoAndGuidJoin(計上データの明細とヘッダーを紐付ける)、StockSlipAndDetailJoin(仕入と仕入明細を紐付ける)の各DataSet追加</br>
    /// <br>            : 2009/02/25 照田 貴志　在庫調整データの作成方法変更</br>
    /// <br>            : 2009/05/27 照田 貴志　不具合対応[13289]</br>
    /// <br>UpdateNote  : 2012/08/30 鄧潘ハン</br>
    /// <br>管理番号    : 10801804-00 20120912配信分</br>
    /// <br>              redmine #31885:吉田商会　在庫入庫更新処理の対応</br>
    /// <br>UpdateNote  : 2012/09/28 鄧潘ハン</br>
    /// <br>管理番号    : 10801804-00 20120912配信分</br>
    /// <br>              redmine #31885:吉田商会　仕入先マスタの次回勘定が未設定の場合は仕入計上日＝仕入日となるように修正の対応</br>
    /// <br>UpdateNote  : 2012/10/02 朱 猛</br>
    /// <br>管理番号    : 10801804-00 20120912配信分</br>
    /// <br>              redmine #31885:吉田商会　仕入日計算に支払月区分を使用しないように修正</br>
    /// <br>UpdateNote  : 2012/10/10 朱 猛</br>
    /// <br>管理番号    : 10801804-00 20120917配信分</br>
    /// <br>              Redmine#32625 消費税計算不正の対応。</br>
    /// <br>UpdateNote  : 2013/05/16 李占川</br>
    /// <br>管理番号    : 10801804-00 2013/06/18配信分</br>
    /// <br>              Redmine#35459 #42の対応</br>
    /// </remarks>
    class PMUOE01203AB
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ▼定数
        // 入庫更新区分
        private const int ENTERUPDDIV_NOTENTER = 0;         // 未入庫
        private const int ENTERUPDDIV_ENTER = 1;            // 入庫
        private const bool UOESUBSTMARK_NOEXISTS = false;   // 代替品なし
        private const bool UOESUBSTMARK_EXISTS = true;      // 代替品あり
        private const string OPENFLAG = "OPEN価格"; // ADD chenw 2013/03/07 Redmine#34989
        #endregion

        #region ▼変数
        // アクセスクラス
        UOEOrderDtlAcs _uoeOrderDtlAcs = null;              // UOE発注データアクセスクラス
        GoodsAcs _goodsAcs = null;                          // 商品マスタアクセスクラス
        // データセット関連
        private GridMainDataSet.GridMainTableDataTable _gridMainDataTable = null;   // グリッドメイン(更新情報)テーブル
        // HashTable
        private Hashtable _uoeOrderDtlWorkHTable = null;    // UOE発注データ(key：仕入明細通番)
        private Hashtable _stockSlipWorkHTable = null;      // 仕入データ(key：仕入伝票番号)
        private Hashtable _stockDetailWorkHTable = null;    // 仕入明細データ(key：仕入明細通番)
        private Hashtable _supplierHTable = null;           // 仕入先データ(key：仕入先コード)
        // その他
        private List<string> _uoeOrderDtlWorkUpdateList = null; // 更新対象UOE発注データ(HashTableのキー情報)
        private string _enterpriseCode = string.Empty;          // 企業コード
        private bool _stockingPaymentOption = false;            // 買掛オプション
        private int _stockBlnktPrtNoDiv;                        // UOE自社マスタ.在庫一括品番区分   //ADD 2009/01/16 不具合対応[10145]

        private bool _meiJiDiv = false;                         // 明治産業区分　ADD 李占川 2013/05/16 Redmine#35459

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        /// <summary> 商品マスタアクセスクラス </summary>
        public GoodsAcs GoodsAcs { set { this._goodsAcs = value; } }
        /// <summary> 買掛オプション </summary>
        public bool StockingPaymentOption { set { this._stockingPaymentOption = value; } }
        /// <summary> UOE自社マスタ.在庫一括品番区分 </summary>                                     //ADD 2009/01/16 不具合対応[10145]
        public int StockBlnktPrtNoDiv { set { this._stockBlnktPrtNoDiv = value; } }                 //ADD 2009/01/16 不具合対応[10145]
        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
        /// <summary> 明治産業区分 </summary>   
        public bool MeiJiDiv { set { this._meiJiDiv = value; } }
        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constracter
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="uoeOrderDtlWorkHTable">UOE発注データHashTable</param>
        /// <param name="gridMainDataTable">グリッドメイン(更新情報)テーブル</param>
        /// <param name="stockSlipWorkHTable">仕入データHashTable</param>
        /// <param name="stockDetailWorkHTable">仕入明細データHashTable</param>
        /// <param name="supplierHtable">仕入先データHashTable</param>
        /// <param name="goodsAcs">商品マスタアクセスクラス</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01203AB(string enterpriseCode
                            ,Hashtable uoeOrderDtlWorkHTable
                            ,GridMainDataSet.GridMainTableDataTable gridMainDataTable
                            ,Hashtable stockSlipWorkHTable
                            ,Hashtable stockDetailWorkHTable
                            ,Hashtable supplierHtable)
        {
            this._enterpriseCode = enterpriseCode;                  // 企業コード
            this._uoeOrderDtlWorkHTable = uoeOrderDtlWorkHTable;    // UOE発注データ
            this._gridMainDataTable = gridMainDataTable;            // グリッドメイン(更新情報)テーブル
            this._stockSlipWorkHTable = stockSlipWorkHTable;        // 仕入データHashTable
            this._stockDetailWorkHTable = stockDetailWorkHTable;    // 仕入明細データHashTable
            this._supplierHTable = supplierHtable;                  // 仕入先データHashTable

            // インスタンス生成
            this._uoeOrderDtlAcs = new UOEOrderDtlAcs();            // UOE発注データアクセスクラス
        }
        #endregion

        // ===================================================================================== //
        // パブリック
        // ===================================================================================== //
        #region ▼CreateUOEStcUpdDataList(更新用オブジェクト作成メイン)
        /// <summary>
        /// 更新用オブジェクト作成メイン
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>更新用オブジェクト(CustomSerializeArrayList型)</returns>
        /// <remarks>
        /// <br>Note       : 更新用の各データ(UOE発注、仕入、仕入明細、在庫調整)を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public object CreateUOEStcUpdDataList(out string msg)
        {
            msg = string.Empty;

            // 更新対象データチェック
            DataRow[] dataRows = this.GetGridMainDataRows();
            if (dataRows.Length == 0)
            {
                msg = "該当データがありません。";
                return null;
            }

            CustomSerializeArrayList uoeStcUpdDataList = new CustomSerializeArrayList();

            // 売上・仕入制御データ作成
            this.CreateIOWriteCtrlOptWork(ref uoeStcUpdDataList);
            if (uoeStcUpdDataList == null)
            {
                msg = "全体初期値設定マスタを設定して下さい。";
                return null;
            }

            // 発注・計上データ作成(仕入、在庫調整共に作成する)
            this.CreateOrderDtlArrayList(ref uoeStcUpdDataList);                //ADD 2009/02/25

            // USBオプション-買掛オプション判定
            if (this._stockingPaymentOption == true)
            {
                // 何もしない CommentADD 2009/02/25
                /* ---DEL 2009/02/25 ------------------------------------------>>>>>
                //// 計上データ作成
                //this.CreateStockSlipArrayList(ref uoeStcUpdDataList);         //DEL 2009/02/17 不具合対応[10140][10177][10529]

                // 発注・計上データ作成
                this.CreateOrderDtlArrayList(ref uoeStcUpdDataList);            //ADD 2009/02/17 不具合対応[10140][10177][10529]
                   ---DEL 2009/02/25 ------------------------------------------<<<<< */
            }
            else
            {
                // 在庫調整データ作成
                this.CreateStockAdjustArrayList(ref uoeStcUpdDataList);
            }

            // UOE発注データ(入庫更新フラグ更新済)作成
            uoeStcUpdDataList.Add(this.CreateUOEOrderDtlWorkList());

            return uoeStcUpdDataList;
        }
        #endregion

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        #region ▼GetRemainCntMngDiv(残数管理区分取得)　DEL 2009/05/27 不具合対応[13289]
        ///// <summary>
        ///// 残数管理区分取得
        ///// </summary>
        ///// <returns>-1：失敗、その他：残数管理区分の値</returns>
        ///// <remarks>
        ///// <br>Note       : 全体初期値設定マスタより残数管理区分を取得します。</br>
        ///// <br>Programmer : 照田 貴志</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private int GetRemainCntMngDiv()
        //{
        //    AllDefSetWork allDefSetWork = new AllDefSetWork();
        //    allDefSetWork.EnterpriseCode = this._enterpriseCode;
        //    object paraobj = allDefSetWork;

        //    // リモートオブジェクト取得
        //    IAllDefSetDB iAllDefSetDB = (IAllDefSetDB)MediationAllDefSetDB.GetAllDefSetDB();

        //    // 読み込み
        //    object retobj = null;
        //    int status = iAllDefSetDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        return -1;
        //    }
        //    ArrayList allDefSetWorkList = retobj as ArrayList;
        //    if (allDefSetWorkList == null)
        //    {
        //        return -1;
        //    }

        //    // 自拠点のデータ取得
        //    for (int index = 0; index <= allDefSetWorkList.Count - 1; index++)
        //    {
        //        allDefSetWork = (AllDefSetWork)allDefSetWorkList[index];
        //        if (allDefSetWork.SectionCode.TrimEnd() == LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd())
        //        {
        //            return allDefSetWork.RemainCntMngDiv;
        //        }
        //    }

        //    return -1;
        //}
        #endregion

        #region ▼GetGoodsUnitDataList(商品在庫マスタ情報取得)
        /// <summary>
        /// 商品在庫マスタ情報取得
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>null：取得失敗、その他：取得した商品在庫リスト</returns>
        /// <remarks>
        /// <br>Note       : メーカー、品番で商品在庫マスタを検索します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private List<GoodsUnitData> GetGoodsUnitDataList(int goodsMakerCd, string goodsNo)
        {
            string msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            // 抽出条件
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = goodsMakerCd;
            goodsCndtn.GoodsNo = goodsNo;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return goodsUnitDataList;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region ▼GetGridMainDataRows( UOE入庫更新メイン(グリッド内容反映済)データ取得 )
        /// <summary>
        /// UOE入庫更新メイン(グリッド内容反映済)データ取得
        /// </summary>
        /// <returns>区分が「1：入庫」「3：明細修正」「9：消し込み」のいずれかとなっている明細</returns>
        /// <remarks>
        /// <br>Note       : グリッドメインデータから更新対象のデータを抽出し、返します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private DataRow[] GetGridMainDataRows()
        {
            // 「1：入庫」「3：明細修正」「9：消し込み」が対象
            string filter = string.Format("(({0}='{1}') OR ({0}='{2}') OR ({0}='{3}'))"
                                        , this._gridMainDataTable.DivCdColumn.ColumnName
                                        , PMUOE01202EA.DIVCD_ENTER
                                        , PMUOE01202EA.DIVCD_UPDATE
                                        , PMUOE01202EA.DIVCD_DELETE);
            string sort = string.Format("{0}, {1}"
                                        , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName
                                        , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName);

            return this._gridMainDataTable.Select(filter, sort);
        }
        #endregion

        // ---ADD 2009/02/25 ---------------------------------------------------------------------------->>>>>
        #region ▼GetGridMainDataRowsStockAdjust( UOE入庫更新メイン(グリッド内容反映済)在庫調整用データ取得 )
        /// <summary>
        /// UOE入庫更新メイン(グリッド内容反映済)データ取得
        /// </summary>
        /// <returns>区分が「1：入庫」「3：明細修正」のいずれかとなっている明細</returns>
        /// <remarks>
        /// <br>Note       : グリッドメインデータから更新対象のデータを抽出し、返します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private DataRow[] GetGridMainDataRowsStockAdjust()
        {
            // 「1：入庫」「3：明細修正」が対象
            string filter = string.Format("(({0}='{1}') OR ({0}='{2}'))"
                                        , this._gridMainDataTable.DivCdColumn.ColumnName
                                        , PMUOE01202EA.DIVCD_ENTER
                                        , PMUOE01202EA.DIVCD_UPDATE);
            string sort = string.Format("{0}, {1}, {2}"
                                        , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName
                                        , this._gridMainDataTable.WarehouseCodeColumn.ColumnName
                                        , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName);

            return this._gridMainDataTable.Select(filter, sort);
        }
        #endregion
        // ---ADD 2009/02/25 ----------------------------------------------------------------------------<<<<<

        // 売上・仕入制御データ作成関連
        #region ▼CreateIOWriteCtrlOptWork(売上・仕入制御データ作成)
        /// <summary>
        /// 売上・仕入制御データ作成
        /// </summary>
        /// <param name="uoeStcUpdDataList">売上・仕入制御データ(CustomSerializeArrayList型)</param>
        /// <remarks>
        /// <br>Note       : 売上・仕入制御データの作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateIOWriteCtrlOptWork(ref CustomSerializeArrayList uoeStcUpdDataList)
        {

            IOWriteCtrlOptWork ioWriteCtrlOptWork = new IOWriteCtrlOptWork();
            ioWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;        // 制御起点

            ioWriteCtrlOptWork.EstimateAddUpRemDiv = 0;                         // 見積データ計上残区分
            ioWriteCtrlOptWork.AcpOdrrAddUpRemDiv = 0;                          // 受注データ計上残区分
            ioWriteCtrlOptWork.ShipmAddUpRemDiv = 0;                            // 出荷データ計上残区分
            ioWriteCtrlOptWork.RetGoodsStockEtyDiv = 0;                         // 返品時在庫登録区分
            ioWriteCtrlOptWork.SupplierSlipDelDiv = 0;                         // 仕入伝票削除区分
            ioWriteCtrlOptWork.EnterpriseCode = this._enterpriseCode;           // 企業コード
            ioWriteCtrlOptWork.CarMngDivCd = 0;                                // 車両管理区分
            // ---DEL 2009/05/27 不具合対応[13289] -------------------------------------------->>>>>
            //ioWriteCtrlOptWork.RemainCntMngDiv = this.GetRemainCntMngDiv();     // 残数管理区分

            //if (ioWriteCtrlOptWork.RemainCntMngDiv == -1)
            //{
            //    // 残数管理区分取得失敗
            //    uoeStcUpdDataList = null;
            //    return;
            //}
            // ---DEL 2009/05/27 不具合対応[13289] --------------------------------------------<<<<<
            ioWriteCtrlOptWork.RemainCntMngDiv = 0;     //ADD 2009/05/27 不具合対応[13289]　※0固定とする

            uoeStcUpdDataList.Add(ioWriteCtrlOptWork);
        }
        #endregion

        // 計上データ作成関連
        #region ▼CreateStockSlipArrayList(計上データ群作成)　2009/02/17 DEL 不具合対応[10140][10177][10529]
        ///// <summary>
        ///// 計上データ群作成
        ///// </summary>
        ///// <param name="uoeStcUpdDataList">更新用データ</param>
        ///// <remarks>
        ///// <br>Note       : グリッドメイン(更新情報)データ、仕入データ、仕入明細データ、UOE発注データを元に計上データを作成します。</br>
        ///// <br>             また、UOE発注データの入庫区分を更新します。</br>
        ///// <br>Programmer : 照田 貴志</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private void CreateStockSlipArrayList(ref CustomSerializeArrayList uoeStcUpdDataList)
        //{
        //    StockSlipListInfo stockSlipListInfo = new StockSlipListInfo();      // 計上データ貯め込み用クラス
        //    List<StockDetailWork> stockDetailWork = null;                       // 計上明細リスト
        //    GridMainDataSet.GridMainTableRow mainRow = null;                    // グリッド入力データ(現在値)
        //    GridMainDataSet.GridMainTableRow mainRowBf = null;                  // グリッド入力データ(前回値)

        //    // 更新対象データ取得
        //    //DataRow[] dataRows = this.GetGridMainDataRows();                  //DEL 2009/02/17 不具合対応[10140][10177][10529]
        //    // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ---------------------------------------->>>>>
        //    // 計上は「1：入庫」「3：明細修正」が対象
        //    string filter = string.Format("(({0}='{1}') OR ({0}='{2}'))"
        //                                , this._gridMainDataTable.DivCdColumn.ColumnName
        //                                , PMUOE01202EA.DIVCD_ENTER
        //                                , PMUOE01202EA.DIVCD_UPDATE);
        //    string sort = string.Format("{0}, {1}"
        //                                , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName
        //                                , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName);

        //    DataRow[] dataRows = this._gridMainDataTable.Select(filter, sort);
        //    // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ----------------------------------------<<<<<
        //    for (int index = 0; index <= dataRows.Length - 1; index++)
        //    {
        //        mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

        //        // ヘッダーが異なる場合に計上データ作成
        //        if ((mainRowBf != null) && (mainRowBf.HeaderGridRowNo != mainRow.HeaderGridRowNo))
        //        {
        //            // 計上データ貯め込み
        //            stockDetailWork = stockSlipListInfo.StockDetailWorkList;
        //            //stockSlipListInfo.StockSlipWork = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_NOEXISTS, stockDetailWork);    //DEL 2009/02/17 不具合対応[10140][10177][10529]
        //            stockSlipListInfo.StockSlipWork = this.GetStockSlipWorkUpdate(mainRowBf, stockDetailWork);                          //ADD 2009/02/17 不具合対応[10140][10177][10529]

        //            // 貯め込んだ計上データ、計上明細、明細付加データをまとめてuoeStcUpdDataListに追加
        //            uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipList);

        //            /* ---DEL 2009/02/17 不具合対応[10140][10177][10529] ---------------------------------------->>>>>
        //            // 代替品がある場合
        //            if (stockSlipListInfo.StockDetailWorkBfListDataIsExists)
        //            {
        //                // 代替品用発注データ貯め込み
        //                stockSlipListInfo.StockSlipWorkBf = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_EXISTS);


        //                // 貯め込んだ代替品用発注、発注明細データをまとめてuoeStcUpdDataListに追加
        //                uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
        //            }
        //               ---DEL 2009/02/17 不具合対応[10140][10177][10529] ----------------------------------------<<<<< */
        //            stockSlipListInfo.ClearItem();
        //        }

        //        // 計上明細、明細付加データ貯め込み
        //        stockSlipListInfo.DtlRelationGuid = Guid.NewGuid();     //GUID採番
        //        //stockSlipListInfo.StockDetailWork = this.CreateStockDetailWork(mainRow, UOESUBSTMARK_NOEXISTS);           //DEL 2009/02/17 不具合対応[10140][10177][10529]
        //        stockSlipListInfo.StockDetailWork = this.GetStockDetailWorkUpdate(mainRow);                                 //ADD 2009/02/17 不具合対応[10140][10177][10529]
        //        stockSlipListInfo.SlipDetailAddInfoWork = this.CreateSlipDetailAddInfoWork(mainRow);

        //        /* ---DEL 2009/01/16 不具合対応[10145] ------------------------------------------------------------->>>>>
        //        if (string.IsNullOrEmpty(mainRow.SubstPartsNo.TrimEnd()) == false)
        //        {
        //            // 代替品用発注明細データを貯め込み
        //            stockSlipListInfo.StockDetailWorkBf = this.CreateStockDetailWork(mainRow, UOESUBSTMARK_EXISTS);
        //        }
        //           ---DEL 2009/01/16 不具合対応[10145] ------------------------------------------------------------->>>>> */
        //        /* ---DEL 2009/02/17 不具合対応[10140][10177][10529] ----------------------------------------------->>>>>
        //        // ---ADD 2009/01/16 不具合対応[10145] ------------------------------------------------------------->>>>>
        //        // 代替品採用で代替品がある場合
        //        if (this._stockBlnktPrtNoDiv == 0)
        //        {
        //            if (string.IsNullOrEmpty(mainRow.SubstPartsNo.TrimEnd()) == false)
        //            {
        //                // 代替品用発注明細データを貯め込み
        //                stockSlipListInfo.StockDetailWorkBf = this.CreateStockDetailWork(mainRow, UOESUBSTMARK_EXISTS);
        //            }
        //        }
        //        // ---ADD 2009/01/16 不具合対応[10145] -------------------------------------------------------------<<<<<
        //           ---DEL 2009/02/17 不具合対応[10140][10177][10529] -----------------------------------------------<<<<< */

        //        // UOE発注データ更新
        //        this.UpdateUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc, mainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid);

        //        // 1つ前の情報を保持
        //        mainRowBf = mainRow;
        //    }

        //    // 以下、最後のデータを処理

        //    // 計上データ貯め込み
        //    stockDetailWork = stockSlipListInfo.StockDetailWorkList;
        //    //stockSlipListInfo.StockSlipWork = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_NOEXISTS, stockDetailWork);    //DEL 2009/02/17 不具合対応[10140][10177][10529]
        //    stockSlipListInfo.StockSlipWork = this.GetStockSlipWorkUpdate(mainRowBf, stockDetailWork);                          //ADD 2009/02/17 不具合対応[10140][10177][10529]

        //    // 貯め込んだ計上データ、計上明細、明細付加データをまとめてuoeStcUpdDataListに追加
        //    uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipList);

        //    /* ---DEL 2009/02/17 不具合対応[10140][10177][10529] ------------------------------------------------>>>>>
        //    // 代替品がある場合
        //    if (stockSlipListInfo.StockDetailWorkBfListDataIsExists)
        //    {
        //        // 代替品用発注データ貯め込み
        //        stockSlipListInfo.StockSlipWorkBf = this.CreateStockSlipWork(mainRowBf, UOESUBSTMARK_EXISTS);


        //        // 貯め込んだ代替品用発注、発注明細データをまとめてuoeStcUpdDataListに追加
        //        uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
        //    }
        //       ---DEL 2009/02/17 不具合対応[10140][10177][10529] ------------------------------------------------<<<<< */
        //}
        #endregion

        #region ▼CreateStockSlipWork(仕入データ作成)　2009/02/17 DEL 不具合対応[10140][10177][10529]
        ///// <summary>
        ///// 更新用仕入データ作成
        ///// </summary>
        ///// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        ///// <param name="uoeSubstFlg">True：代替品用データ、False：発注計上仕入データ</param>
        ///// <returns>更新用仕入データ</returns>
        ///// <remarks>
        ///// <br>Note       : ①発注計上仕入データの場合、仕入データ、グリッドメイン(更新情報)データを元に更新用仕入データを作成します。</br>
        ///// <br>             ②代替品用データの場合、仕入明細データの内容をそのまま返します。</br>
        ///// <br>Programmer : 照田 貴志</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private StockSlipWork CreateStockSlipWork(GridMainDataSet.GridMainTableRow mainRow, bool uoeSubstFlg)
        //{
        //    // ※代替品用の場合、こちらからCALLされる
        //    return this.CreateStockSlipWork(mainRow, uoeSubstFlg, null);
        //}
        //private StockSlipWork CreateStockSlipWork(GridMainDataSet.GridMainTableRow mainRow, bool uoeSubstFlg, List<StockDetailWork> stockDetailWorkList)
        //{
        //    //StockSlipWork stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[mainRow.SupplierSlipNo.ToString()];
        //    StockSlipWork stockSlipWork = ((StockSlipWork)this._stockSlipWorkHTable[mainRow.SupplierSlipNo.ToString()]).Clone();        //※値渡し
        //    if (uoeSubstFlg == UOESUBSTMARK_EXISTS)
        //    {
        //        // 代替品用の場合、そのまま返す
        //        return stockSlipWork;
        //    }

        //    // 仕入消費税端数処理コード
        //    int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockSlipWork.SupplierCd]).StockCnsTaxFrcProcCd;

        //    stockSlipWork.CreateDateTime = DateTime.MinValue;                           // 作成日時                     [初期化]
        //    stockSlipWork.UpdateDateTime = DateTime.MinValue;                           // 更新日時                     [初期化]
        //    stockSlipWork.EnterpriseCode = this._enterpriseCode;                        // 企業コード
        //    stockSlipWork.FileHeaderGuid = Guid.Empty;                                  // GUID                         [初期化]
        //    stockSlipWork.UpdEmployeeCode = string.Empty;                               // 更新従業員コード             [初期化]
        //    stockSlipWork.UpdAssemblyId1 = string.Empty;                                // 更新アセンブリID1            [初期化]
        //    stockSlipWork.UpdAssemblyId2 = string.Empty;                                // 更新アセンブリID2            [初期化]
        //    stockSlipWork.LogicalDeleteCode = 0;                                        // 論理削除区分                 [初期化]
        //    stockSlipWork.SupplierFormal = 0;                                           // 仕入形式                     [0：仕入]
        //    stockSlipWork.SupplierSlipNo = 0;                                           // 仕入伝票番号                 [初期化]
        //    stockSlipWork.InputDay = DateTime.Today;                                    // 入力日
        //    stockSlipWork.ArrivalGoodsDay = DateTime.Today;                             // 入荷日
        //    stockSlipWork.StockDate = DateTime.Today;                                   // 仕入日
        //    stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;                    // 仕入計上日付                 [仕入日と同値]
        //    stockSlipWork.PartySaleSlipNum = mainRow.InputSlipNo;                       // 相手先伝票番号               [画面の入力値(伝票番号)]
        //    stockSlipWork.DetailRowCount = stockDetailWorkList.Count;                   // 明細数                       [貯め込んだ明細数]

        //    // 仕入データの情報算出(左から仕入、仕入明細リスト、仕入端数処理区分、仕入消費税端数処理コード)
        //    StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockSlipWork.StockFractionProcCd,stockCnsTaxFrcProcCd);
        //    /*
        //    stockSlipWork.StockTotalPrice;          // 仕入金額合計
        //    stockSlipWork.StockSubttlPrice;         // 仕入金額小計
        //    stockSlipWork.StockTtlPricTaxInc;       // 仕入金額計(税込み)
        //    stockSlipWork.StockTtlPricTaxExc;       // 仕入金額計(税抜き)
        //    stockSlipWork.StockNetPrice;            // 仕入正価金額
        //    stockSlipWork.StockPriceConsTax;        // 仕入金額消費税額
        //    stockSlipWork.TtlItdedStcOutTax;        // 仕入外税対象額合計
        //    stockSlipWork.TtlItdedStcInTax;         // 仕入内税対象額合計
        //    stockSlipWork.TtlItdedStcTaxFree;       // 仕入非課税対象額合計
        //    stockSlipWork.StockOutTax;              // 仕入金額消費税額(外税)
        //    stockSlipWork.StckPrcConsTaxInclu;      // 仕入金額消費税額(内税)
        //    stockSlipWork.StckDisTtlTaxExc;         // 仕入値引金額計(税抜き)
        //    stockSlipWork.ItdedStockDisOutTax;      // 仕入値引外税対象額合計
        //    stockSlipWork.ItdedStockDisInTax;       // 仕入値引内税対象額合計
        //    stockSlipWork.ItdedStockDisTaxFre;      // 仕入値引非課税対象額合計
        //    stockSlipWork.StockDisOutTax;           // 仕入値引消費税額(外税)
        //    stockSlipWork.StckDisTtlTaxInclu;       // 仕入値引消費税額(内税)
        //    */

        //    return stockSlipWork;
        //}
        #endregion
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------->>>>>
        #region ▼GetStockSlipWorkNoUpdate(更新前仕入データ取得)
        /// <summary>
        /// 更新前仕入データ取得
        /// </summary>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <returns>更新前仕入データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入伝票番号を元にHashTableから更新前の仕入データを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private StockSlipWork GetStockSlipWorkNoUpdate(int supplierSlipNo)
        {
            if (this._stockSlipWorkHTable.ContainsKey(supplierSlipNo.ToString()) == false)
            {
                return null;
            }

            return ((StockSlipWork)this._stockSlipWorkHTable[supplierSlipNo.ToString()]).Clone();
        }
        #endregion

        #region ▼GetStockSlipWorkUpdate(更新後仕入データ取得)
        /// <summary>
        /// 更新後仕入データ取得
        /// </summary>
        /// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        /// <param name="stockDetailWorkList">更新後仕入明細データ</param>
        /// <returns>更新後仕入データ</returns>
        /// <remarks>
        /// <br>Note       : 更新前仕入データをベースに各項目を更新して返します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2012/08/30 鄧潘ハン</br>
        /// <br>管理番号   : 10801804-00 20120912配信分</br>
        /// <br>             redmine #31885:吉田商会　在庫入庫更新処理の対応</br>
        /// <br> 　　　　　　　　　　　　　 仕入日と仕入計上日の対応</br>
        /// <br>UpdateNote  : 2012/09/28 鄧潘ハン</br>
        /// <br>管理番号    : 10801804-00 20120912配信分</br>
        /// <br>              redmine #31885:吉田商会　仕入先マスタの次回勘定が未設定の場合は仕入計上日＝仕入日となるように修正の対応</br>
        /// <br>UpdateNote  : 2012/10/02 朱 猛</br>
        /// <br>管理番号    : 10801804-00 20120912配信分</br>
        /// <br>              redmine #31885:吉田商会　仕入日計算に支払月区分を使用しないように修正</br>
        /// <br>UpdateNote  : 2012/10/10 朱 猛</br>
        /// <br>管理番号    : 10801804-00 20120917配信分</br>
        /// <br>              Redmine#32625 消費税計算不正の対応。</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        private StockSlipWork GetStockSlipWorkUpdate(GridMainDataSet.GridMainTableRow mainRow, List<StockDetailWork> stockDetailWorkList)
        {
            // 仕入データ取得
            StockSlipWork stockSlipWork = this.GetStockSlipWorkNoUpdate(mainRow.SupplierSlipNo);
            if (stockSlipWork == null)
            {
                return null;
            }

            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
            int totalDay = 0;
            int nTimeCalcStDate = 0;
            DateTime targetDate = DateTime.MinValue;
            DateTime nextTimeAddUpDate = DateTime.MinValue;
            // 支払先情報取得
            Supplier supplier = (Supplier)this._supplierHTable[mainRow.SupplierCd];
            //UOE発注データ(key：仕入明細通番)
            UOEOrderDtlWork uoeOrderDtlWork = null;

            foreach (string key in this._uoeOrderDtlWorkHTable.Keys)
            {
                string uoeOrderDtlKey = this.GetOrderDtlKey(mainRow.StockSlipDtlNumSrc.ToString(), mainRow.SlipNo);  // ADD 李占川 2013/05/16 Redmine#35459

                //if (mainRow.StockSlipDtlNumSrc.ToString().Trim() == key) //  DEL 李占川 2013/05/16 Redmine#35459
                if (uoeOrderDtlKey == key)  // ADD 李占川 2013/05/16 Redmine#35459
                {
                    uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
                }
            }
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<

            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockSlipWork.SupplierCd]).StockCnsTaxFrcProcCd;

            stockSlipWork.CreateDateTime = DateTime.MinValue;                           // 作成日時                     [初期化]
            stockSlipWork.UpdateDateTime = DateTime.MinValue;                           // 更新日時                     [初期化]
            stockSlipWork.EnterpriseCode = this._enterpriseCode;                        // 企業コード
            stockSlipWork.FileHeaderGuid = Guid.Empty;                                  // GUID                         [初期化]
            stockSlipWork.UpdEmployeeCode = string.Empty;                               // 更新従業員コード             [初期化]
            stockSlipWork.UpdAssemblyId1 = string.Empty;                                // 更新アセンブリID1            [初期化]
            stockSlipWork.UpdAssemblyId2 = string.Empty;                                // 更新アセンブリID2            [初期化]
            stockSlipWork.LogicalDeleteCode = 0;                                        // 論理削除区分                 [初期化]
            stockSlipWork.SupplierFormal = 0;                                           // 仕入形式                     [0：仕入]
            stockSlipWork.SupplierSlipNo = 0;                                           // 仕入伝票番号                 [初期化]
            stockSlipWork.InputDay = DateTime.Today;                                    // 入力日
            stockSlipWork.ArrivalGoodsDay = DateTime.Today;                             // 入荷日
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
            if (uoeOrderDtlWork != null)
            {
                stockSlipWork.StockDate = uoeOrderDtlWork.ReceiveDate;                  // 仕入日<---UOE発注データの受信日
            }
            // ----- ADD 2012/09/28 鄧潘ハン  redmine#31885----->>>>>
            stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;// 仕入計上日付
            // 仕入日
            targetDate = stockSlipWork.StockDate;
            // 締日
            totalDay = supplier.PaymentTotalDay;
            //来月勘定開始日
            nTimeCalcStDate = supplier.NTimeCalcStDate;
            // ----- ADD 2012/09/28 鄧潘ハン  redmine#31885-----<<<<<
            // ----- DEL 2012/10/02 朱 猛  redmine#31885----->>>>>
            ////支払月区分コード0:当月 1:翌月 2:翌々月 3:翌々々月
            //if (supplier != null && supplier.PaymentMonthCode != 0)
            //{
            //    //stockSlipWork.StockAddUpADate = this.GetNextTotalDate(supplier.PaymentMonthCode - 1, stockSlipWork.StockDate, supplier.PaymentTotalDay).AddDays(1);// 仕入計上日付 //DEL 2012/09/28 鄧潘ハン  redmine#31885
            //    // ----- ADD 2012/09/28 鄧潘ハン  redmine#31885----->>>>>
            //    if (!((totalDay == 0) || (nTimeCalcStDate == 0) || (targetDate == DateTime.MinValue)))
            //    {
            //        stockSlipWork.StockAddUpADate = this.GetNextTotalDate(supplier.PaymentMonthCode - 1, stockSlipWork.StockDate, supplier.PaymentTotalDay).AddDays(1);// 仕入計上日付 
            //    }
            //    // ----- ADD 2012/09/28 鄧潘ハン  redmine#31885-----<<<<<
            //}
            // ----- DEL 2012/10/02 朱 猛  redmine#31885-----<<<<<
            //else // ----- DEL 2012/10/02 朱 猛  redmine#31885
            //{ // ----- DEL 2012/10/02 朱 猛  redmine#31885
                // ----- DEL 2012/09/28 鄧潘ハン  redmine#31885----->>>>>
                //stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;// 仕入計上日付 
                //targetDate = stockSlipWork.StockDate;
                //totalDay = supplier.PaymentTotalDay;
                //nTimeCalcStDate = supplier.NTimeCalcStDate;
                // ----- DEL 2012/09/28 鄧潘ハン  redmine#31885-----<<<<<
                nextTimeAddUpDate = this.GetNextTotalDate(0, stockSlipWork.StockDate, supplier.PaymentTotalDay).AddDays(1);// 仕入計上日付 
                // 締日、来月勘定開始日が設定されていない場合はそのまま終了
                if (!((totalDay == 0) || (nTimeCalcStDate == 0) || (targetDate == DateTime.MinValue)))
                {
                    // 来月勘定開始日 ≦ 締日
                    if (nTimeCalcStDate <= totalDay)
                    {
                        // 対象日の日付が来月勘定開始日～締日の場合に来月勘定
                        if ((nTimeCalcStDate <= targetDate.Day) && (targetDate.Day <= totalDay))
                        {
                            stockSlipWork.StockAddUpADate = nextTimeAddUpDate;
                        }
                    }
                    // 来月勘定開始日 ＞ 締日
                    else
                    {
                        // 対象日の日付が1日～締日、来月勘定開始日～末日の場合に来月勘定
                        if ((1 <= targetDate.Day) && (targetDate.Day <= totalDay) ||
                            (nTimeCalcStDate <= targetDate.Day))
                        {
                            stockSlipWork.StockAddUpADate = nextTimeAddUpDate;
                        }
                    }
                }
            //} // ----- DEL 2012/10/02 朱 猛  redmine#31885
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
            // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
            //stockSlipWork.StockDate = DateTime.Today;                                 // 仕入日 
            //stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;                  // 仕入計上日付                 [仕入日と同値] 
            // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
            stockSlipWork.PartySaleSlipNum = mainRow.InputSlipNo;                       // 相手先伝票番号               [画面の入力値(伝票番号)]
            stockSlipWork.DetailRowCount = stockDetailWorkList.Count;                   // 明細数                       [貯め込んだ明細数]

            // ----- ADD 2012/10/10 朱 猛 Redmine#32625 ----->>>>>
            //仕入端数処理区分と端数処理単位の取得
            //1:切捨て,2:四捨五入,3:切上げ　（消費税）
            StockProcMoney stockProcMoney = this._uoeOrderDtlAcs.GetStockProcMoney(
                                                        1,
                                                        stockCnsTaxFrcProcCd,
                                                        999999999);

            stockSlipWork.StockFractionProcCd = stockProcMoney.FractionProcCd;
            // ----- ADD 2012/10/10 朱 猛 Redmine#32625 -----<<<<<

            // 仕入データの情報算出(左から仕入、仕入明細リスト、仕入端数処理区分、仕入消費税端数処理コード)
            //StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockSlipWork.StockFractionProcCd, stockCnsTaxFrcProcCd); // DEL 2012/10/10 朱 猛 Redmine#32625
            StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockProcMoney.FractionProcUnit, stockProcMoney.FractionProcCd); // ADD 2012/10/10 朱 猛 Redmine#32625
            //---TotalPriceSettingでは以下の項目が更新される(他にもあるかも？)---
            //stockSlipWork.StockTotalPrice;          // 仕入金額合計
            //stockSlipWork.StockSubttlPrice;         // 仕入金額小計
            //stockSlipWork.StockTtlPricTaxInc;       // 仕入金額計(税込み)
            //stockSlipWork.StockTtlPricTaxExc;       // 仕入金額計(税抜き)
            //stockSlipWork.StockNetPrice;            // 仕入正価金額
            //stockSlipWork.StockPriceConsTax;        // 仕入金額消費税額
            //stockSlipWork.TtlItdedStcOutTax;        // 仕入外税対象額合計
            //stockSlipWork.TtlItdedStcInTax;         // 仕入内税対象額合計
            //stockSlipWork.TtlItdedStcTaxFree;       // 仕入非課税対象額合計
            //stockSlipWork.StockOutTax;              // 仕入金額消費税額(外税)
            //stockSlipWork.StckPrcConsTaxInclu;      // 仕入金額消費税額(内税)
            //stockSlipWork.StckDisTtlTaxExc;         // 仕入値引金額計(税抜き)
            //stockSlipWork.ItdedStockDisOutTax;      // 仕入値引外税対象額合計
            //stockSlipWork.ItdedStockDisInTax;       // 仕入値引内税対象額合計
            //stockSlipWork.ItdedStockDisTaxFre;      // 仕入値引非課税対象額合計
            //stockSlipWork.StockDisOutTax;           // 仕入値引消費税額(外税)
            //stockSlipWork.StckDisTtlTaxInclu;       // 仕入値引消費税額(内税)

            return stockSlipWork;
        }

        // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
        /// <summary>
        /// 対象年月日、締日から、実際に締対象となる日付を算出します。
        /// </summary>
        /// <param name="targetDate">対象年月日</param>
        /// <param name="totalDay">設定上の締日</param>
        /// <returns>対象月の実際の締日</returns>
        /// <remarks>
        /// <br>Note       : 対象年月日、締日から、実際に締対象となる日付を算出します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>管理番号   : 10801804-00 20120912配信分</br>
        /// <br>             redmine #31885:吉田商会　在庫入庫更新処理の対応</br>
        /// <br> 　　　　　　　　　　　　　 仕入日と仕入計上日の対応</br>
        /// </remarks>
        private int GetRealTotalDay(DateTime targetDate, int totalDay)
        {
            int retValue = totalDay;
            // 対象月の末日取得
            int lastDayofMonth = DateTime.DaysInMonth(targetDate.Year, targetDate.Month);

            if (lastDayofMonth < totalDay) retValue = lastDayofMonth;

            return retValue;
        }

        /// <summary>
        /// 指定日付の次回以降の締日を算出します。
        /// </summary>
        /// <param name="loopCnt">0:当月,1:翌月,2:翌々月...</param>
        /// <param name="targetdate">対象日</param>
        /// <param name="totalDay">締日</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 指定日付の次回以降の締日を算出します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>管理番号   : 10801804-00 20120912配信分</br>
        /// <br>             redmine #31885:吉田商会　在庫入庫更新処理の対応</br>
        /// <br> 　　　　　　　　　　　　　 仕入日と仕入計上日の対応</br>
        /// </remarks>
        private DateTime GetNextTotalDate(int loopCnt, DateTime targetdate, int totalDay)
        {

            DateTime retDate = targetdate;

            // 対象月の実際の締日を取得
            int totalDayR = this.GetRealTotalDay(retDate, totalDay);

            // 対象日が実際の締日より大きい場合は1ヵ月加算
            if (targetdate.Day > totalDayR)
            {
                retDate = retDate.AddMonths(1);

                totalDayR = this.GetRealTotalDay(retDate, totalDay);
            }
            retDate = new DateTime(retDate.Year, retDate.Month, totalDayR);

            return (loopCnt == 0) ? retDate : GetNextTotalDate(loopCnt - 1, retDate.AddDays(1), totalDay);
        }
        // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
        #endregion
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ---------------------------------------<<<<<

        #region ▼CreateStockDetailWork(更新用仕入明細データ作成)　2009/02/17 DEL 不具合対応[10140][10177][10529]
        ///// <summary>
        ///// 更新用仕入明細データ作成
        ///// </summary>
        ///// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        ///// <param name="uoeSubstFlg">True：代替品用データ、False：発注計上仕入データ</param>
        ///// <returns>更新用仕入明細データ</returns>
        ///// <remarks>
        ///// <br>Note       : ①発注計上仕入データの場合、仕入明細データ、UOE発注データ、グリッドメイン(更新情報)データを元に更新用仕入明細データを作成します。</br>
        ///// <br>             ②代替品用データの場合、仕入明細データの内容をそのまま返します。</br>
        ///// <br>             ※以下の2点は間違えやすいので注意</br>
        ///// <br>               uoeSubstFlg                 →発注計上仕入データor代替品用データの判定</br>
        ///// <br>               uoeOrderDtlWork.UOESubstMark→発注計上仕入データ内での代替品判定</br>
        ///// <br>Programmer : 照田 貴志</br>
        ///// <br>Date       : 2008/09/04</br>
        ///// </remarks>
        //private StockDetailWork CreateStockDetailWork(GridMainDataSet.GridMainTableRow mainRow,bool uoeSubstFlg)
        //{
        //    //StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // 仕入明細データ
        //    StockDetailWork stockDetailWork = ((StockDetailWork)this._stockDetailWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()]).Clone();  // 仕入明細データ ※値渡し
        //    if (uoeSubstFlg == UOESUBSTMARK_EXISTS)
        //    {
        //        // 代替品用の場合、そのまま返す
        //        return stockDetailWork;
        //    }

        //    UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // UOE発注データ
        //    if (this._supplierHTable.ContainsKey(stockDetailWork.SupplierCd) == false)
        //    {
        //        // 仕入先が無い
        //        return null;
        //    }
        //    // 仕入消費税端数処理コード
        //    int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockCnsTaxFrcProcCd;
        //    // 仕入金額端数処理コード
        //    int stockMoneyFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockMoneyFrcProcCd;

        //    stockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;         // 仕入形式(元)                 [計上元の仕入形式]
        //    stockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;       // 仕入明細通番(元)             [計上元の明細通番]

        //    stockDetailWork.CreateDateTime = DateTime.MinValue;                         // 作成日時                     [初期化]
        //    stockDetailWork.UpdateDateTime = DateTime.MinValue;                         // 更新日時                     [初期化]
        //    stockDetailWork.EnterpriseCode = this._enterpriseCode;                      // 企業コード
        //    stockDetailWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [初期化]
        //    stockDetailWork.UpdEmployeeCode = string.Empty;                             // 更新従業員コード             [初期化]
        //    stockDetailWork.UpdAssemblyId1 = string.Empty;                              // 更新アセンブリID1            [初期化]
        //    stockDetailWork.UpdAssemblyId2 = string.Empty;                              // 更新アセンブリID2            [初期化]
        //    stockDetailWork.LogicalDeleteCode = 0;                                      // 論理削除区分                 [初期化]
        //    stockDetailWork.AcceptAnOrderNo = 0;                                        // 受注番号                     [初期化]
        //    stockDetailWork.SupplierFormal = 0;                                         // 仕入形式                     [0：仕入]
        //    stockDetailWork.SupplierSlipNo = 0;                                         // 仕入伝票番号                 [初期化]
        //    stockDetailWork.CommonSeqNo = 0;                                            // 共通通番                     [初期化]
        //    stockDetailWork.StockSlipDtlNum = 0;                                        // 仕入明細通番                 [初期化]
        //    //stockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;         // 仕入形式(元)                 [計上元の仕入形式]
        //    //stockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;       // 仕入明細通番(元)             [計上元の明細通番]
        //    stockDetailWork.ListPriceTaxExcFl = uoeOrderDtlWork.AnswerListPrice;        // 定価(税抜，浮動)             [UOE発注データの回答定価]
        //    stockDetailWork.RateSectStckUnPrc = string.Empty;                           // 掛率設定拠点(仕入単価)       [未設定]
        //    stockDetailWork.RateDivStckUnPrc = string.Empty;                            // 掛率設定区分(仕入単価)       [未設定]
        //    stockDetailWork.UnPrcCalcCdStckUnPrc = 0;                                   // 単価算出区分(仕入単価)       [未設定]
        //    stockDetailWork.PriceCdStckUnPrc = 0;                                       // 価格区分(仕入単価)           [未設定]
        //    stockDetailWork.StdUnPrcStckUnPrc = 0;                                      // 基準単価(仕入単価)           [未設定]
        //    stockDetailWork.FracProcUnitStcUnPrc = 0;                                   // 端数処理単位(仕入単価)       [未設定]
        //    stockDetailWork.FracProcStckUnPrc = 0;                                      // 端数処理(仕入単価)           [未設定]
        //    stockDetailWork.StockUnitPriceFl = mainRow.InputAnswerSalesUnitCost;        // 仕入単価(税抜，浮動)         [画面の入力値(原単価)]
        //    stockDetailWork.RateBLGoodsCode = 0;                                        // BL商品コード(掛率)		    [未設定]
        //    stockDetailWork.RateBLGoodsName = string.Empty;                             // BL商品コード名称(掛率)		[未設定]
        //    stockDetailWork.RateGoodsRateGrpCd = 0;                                     // 商品掛率グループコード(掛率)	[未設定]
        //    stockDetailWork.RateGoodsRateGrpNm = string.Empty;                          // 商品掛率グループ名称(掛率)	[未設定]
        //    stockDetailWork.RateBLGroupCode = 0;                                        // BLグループコード(掛率)		[未設定]
        //    stockDetailWork.RateBLGroupName = string.Empty;                             // BLグループ名称(掛率)		    [未設定]
        //    stockDetailWork.StockCount = mainRow.InputEnterCnt;                         // 仕入数		                [画面の入力値(入庫)]
        //    //stockDetailWork.OrderCnt = 0;                                               // 発注数量		                [未設定]        //DEL 2009/02/04
        //    // ---ADD 2009/02/04 代替品以外の時のみ発注数量を[未設定]とする --------------------------------------------------->>>>>
        //    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == true)
        //    {
        //        stockDetailWork.OrderCnt = 0;                                           // 発注数量		                [未設定]
        //    }
        //    // ---ADD 2009/02/04 ----------------------------------------------------------------------------------------------<<<<<
        //    stockDetailWork.OrderAdjustCnt = 0;                                         // 発注調整数		            [未設定]
        //    stockDetailWork.OrderRemainCnt = 0;                                         // 発注残数		                [未設定]
        //    stockDetailWork.StockCountDifference = 0;                                   // 仕入差分数                   [未設定]

        //    // 定価(税込，浮動)
        //    stockDetailWork.ListPriceTaxIncFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.ListPriceTaxExcFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

        //    // 仕入単価(税込，浮動)
        //    stockDetailWork.StockUnitTaxPriceFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.StockUnitPriceFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

        //    // 仕入単価変更区分
        //    if (stockDetailWork.StockUnitPriceFl == stockDetailWork.BfStockUnitPriceFl)
        //    {
        //        stockDetailWork.StockUnitChngDiv = 0;       // 変更なし
        //    }
        //    else
        //    {
        //        stockDetailWork.StockUnitChngDiv = 1;       // 変更あり
        //    }

        //    // 仕入金額(税抜き、税込み)
        //    long stockPriceTaxInc = 0;
        //    long stockPriceTaxExc = 0;
        //    long stockPriceConsTax = 0;

        //    bool bStatus = this._uoeOrderDtlAcs.CalculationStockPrice(
        //        stockDetailWork.StockCount,
        //        stockDetailWork.StockUnitPriceFl,
        //        stockDetailWork.TaxationCode,
        //        stockMoneyFrcProcCd,
        //        stockCnsTaxFrcProcCd,
        //        out stockPriceTaxInc,
        //        out stockPriceTaxExc,
        //        out stockPriceConsTax);

        //    if (bStatus == true)
        //    {
        //        stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;    //仕入金額（税抜き）
        //        stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;    //仕入金額（税込み）
        //    }
        //    else
        //    {
        //        stockDetailWork.StockPriceTaxExc = 0;                   //仕入金額（税抜き）
        //        stockDetailWork.StockPriceTaxInc = 0;                   //仕入金額（税込み）
        //    }

        //    // 仕入金額消費税額(仕入金額税込み-仕入金額税抜き)
        //    stockDetailWork.StockPriceConsTax = stockDetailWork.StockPriceTaxInc - stockDetailWork.StockPriceTaxExc;

        //    // --- ADD 2009/01/16 不具合対応[10145] --------------------------------------------------------->>>>>
        //    // 発注品採用時、代替品を採用しない
        //    if (this._stockBlnktPrtNoDiv != 0)
        //    {
        //        return stockDetailWork;
        //    }
        //    // --- ADD 2009/01/16 不具合対応[10145] ---------------------------------------------------------<<<<<

        //    // 代替品ありの場合、再設定
        //    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
        //    {
        //        // 商品マスタ読み込み
        //        List<GoodsUnitData> goodsUnitDataList = this.GetGoodsUnitDataList(stockDetailWork.GoodsMakerCd, uoeOrderDtlWork.SubstPartsNo);
        //        if (goodsUnitDataList != null)              //ADD 2009/01/19 不具合対応[10178]
        //        {                                           //ADD 2009/01/19 不具合対応[10178]
        //            GoodsUnitData goodsUnitData = goodsUnitDataList[0];

        //            stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                  // 商品メーカーコード
        //            stockDetailWork.MakerName = goodsUnitData.MakerName;                        // メーカー名称
        //            stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;                // メーカーカナ名称
        //            stockDetailWork.CmpltMakerKanaName = string.Empty;                          // メーカーカナ名称（一式）
        //            stockDetailWork.GoodsNo = goodsUnitData.GoodsNo;                            // 商品番号
        //            stockDetailWork.GoodsName = goodsUnitData.GoodsName;                        // 商品名称
        //            stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;                // 商品名称カナ
        //            stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // 商品大分類コード
        //            stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // 商品大分類名称
        //            stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // 商品中分類コード
        //            stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // 商品中分類名称
        //            stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                    // BLグループコード
        //            stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                    // BLグループコード名称
        //            stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL商品コード
        //            stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL商品コード名称（全角）
        //            stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // 自社分類コード
        //            stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // 自社分類名称
        //        }                                           //ADD 2009/01/19 不具合対応[10178]
        //    }

        //    return stockDetailWork;
        //}
        #endregion
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------->>>>>
        #region ▼GetStockDetailWorkNoUpdate(更新後仕入明細データ取得)
        /// <summary>
        /// 更新前仕入明細データ取得
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">仕入明細通番</param>
        /// <returns>更新前仕入明細データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入明細通番を元にHashTableから更新前の仕入明細データを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private StockDetailWork GetStockDetailWorkNoUpdate(long stockSlipDtlNumSrc)
        {
            if (this._stockDetailWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
            {
                return null;
            }

            return ((StockDetailWork)this._stockDetailWorkHTable[stockSlipDtlNumSrc.ToString()]).Clone();
        }
        #endregion

        #region ▼GetStockDetailWorkUpdate(計上データ用情報作成)
        /// <summary>
        /// 計上データ用情報作成
        /// </summary>
        /// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        /// <returns>更新後仕入明細データ</returns>
        /// <remarks>
        /// <br>Note       : 更新前仕入明細データをベースに各項目を更新して返します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        private StockDetailWork GetStockDetailWorkUpdate(GridMainDataSet.GridMainTableRow mainRow)
        {
            // 仕入明細データ取得
            StockDetailWork stockDetailWork = this.GetStockDetailWorkNoUpdate(mainRow.StockSlipDtlNumSrc);
            if (stockDetailWork == null)
            {
                return null;
            }

            // UOE発注データ取得
            //UOEOrderDtlWork uoeOrderDtlWork = this.GetUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc);  //  DEL 李占川 2013/05/16 Redmine#35459
            UOEOrderDtlWork uoeOrderDtlWork = this.GetUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc, mainRow.SlipNo);  //  ADD 李占川 2013/05/16 Redmine#35459

            if (this._supplierHTable.ContainsKey(stockDetailWork.SupplierCd) == false)
            {
                // 仕入先が無い
                return null;
            }
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockCnsTaxFrcProcCd;
            // 仕入金額端数処理コード
            int stockMoneyFrcProcCd = ((Supplier)this._supplierHTable[stockDetailWork.SupplierCd]).StockMoneyFrcProcCd;

            stockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;         // 仕入形式(元)                 [計上元の仕入形式]
            stockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;       // 仕入明細通番(元)             [計上元の明細通番]

            stockDetailWork.CreateDateTime = DateTime.MinValue;                         // 作成日時                     [初期化]
            stockDetailWork.UpdateDateTime = DateTime.MinValue;                         // 更新日時                     [初期化]
            stockDetailWork.EnterpriseCode = this._enterpriseCode;                      // 企業コード
            stockDetailWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [初期化]
            stockDetailWork.UpdEmployeeCode = string.Empty;                             // 更新従業員コード             [初期化]
            stockDetailWork.UpdAssemblyId1 = string.Empty;                              // 更新アセンブリID1            [初期化]
            stockDetailWork.UpdAssemblyId2 = string.Empty;                              // 更新アセンブリID2            [初期化]
            stockDetailWork.LogicalDeleteCode = 0;                                      // 論理削除区分                 [初期化]
            stockDetailWork.AcceptAnOrderNo = 0;                                        // 受注番号                     [初期化]
            stockDetailWork.SupplierFormal = 0;                                         // 仕入形式                     [0：仕入]
            stockDetailWork.SupplierSlipNo = 0;                                         // 仕入伝票番号                 [初期化]
            stockDetailWork.CommonSeqNo = 0;                                            // 共通通番                     [初期化]
            stockDetailWork.StockSlipDtlNum = 0;                                        // 仕入明細通番                 [初期化]
            stockDetailWork.ListPriceTaxExcFl = uoeOrderDtlWork.AnswerListPrice;        // 定価(税抜，浮動)             [UOE発注データの回答定価]
            stockDetailWork.RateSectStckUnPrc = string.Empty;                           // 掛率設定拠点(仕入単価)       [未設定]
            stockDetailWork.RateDivStckUnPrc = string.Empty;                            // 掛率設定区分(仕入単価)       [未設定]
            stockDetailWork.UnPrcCalcCdStckUnPrc = 0;                                   // 単価算出区分(仕入単価)       [未設定]
            stockDetailWork.PriceCdStckUnPrc = 0;                                       // 価格区分(仕入単価)           [未設定]
            stockDetailWork.StdUnPrcStckUnPrc = 0;                                      // 基準単価(仕入単価)           [未設定]
            stockDetailWork.FracProcUnitStcUnPrc = 0;                                   // 端数処理単位(仕入単価)       [未設定]
            stockDetailWork.FracProcStckUnPrc = 0;                                      // 端数処理(仕入単価)           [未設定]
            stockDetailWork.StockUnitPriceFl = mainRow.InputAnswerSalesUnitCost;        // 仕入単価(税抜，浮動)         [画面の入力値(原単価)]
            stockDetailWork.RateBLGoodsCode = 0;                                        // BL商品コード(掛率)		    [未設定]
            stockDetailWork.RateBLGoodsName = string.Empty;                             // BL商品コード名称(掛率)		[未設定]
            stockDetailWork.RateGoodsRateGrpCd = 0;                                     // 商品掛率グループコード(掛率)	[未設定]
            stockDetailWork.RateGoodsRateGrpNm = string.Empty;                          // 商品掛率グループ名称(掛率)	[未設定]
            stockDetailWork.RateBLGroupCode = 0;                                        // BLグループコード(掛率)		[未設定]
            stockDetailWork.RateBLGroupName = string.Empty;                             // BLグループ名称(掛率)		    [未設定]
            stockDetailWork.StockCount = mainRow.InputEnterCnt;                         // 仕入数		                [画面の入力値(入庫)]
            /* 発注数量はそのままの値 2009/02/17 DEL 不具合対応[10140][10177][10529] ------------------------------------------------->>>>>
            //stockDetailWork.OrderCnt = 0;                                               // 発注数量		                [未設定]        //DEL 2009/02/04
            //// ---ADD 2009/02/04 代替品以外の時のみ発注数量を[未設定]とする --------------------------------------------------->>>>>
            //if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == true)
            //{
            //    stockDetailWork.OrderCnt = 0;                                           // 発注数量		                [未設定]
            //}
            //// ---ADD 2009/02/04 ----------------------------------------------------------------------------------------------<<<<<
               発注数量はそのままの値 2009/02/17 DEL 不具合対応[10140][10177][10529] -------------------------------------------------<<<<< */

            stockDetailWork.OrderAdjustCnt = 0;                                         // 発注調整数		            [未設定]
            stockDetailWork.OrderRemainCnt = 0;                                         // 発注残数		                [未設定]
            stockDetailWork.StockCountDifference = 0;                                   // 仕入差分数                   [未設定]

            // 定価(税込，浮動)
            stockDetailWork.ListPriceTaxIncFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.ListPriceTaxExcFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

            // 仕入単価(税込，浮動)
            stockDetailWork.StockUnitTaxPriceFl = this._uoeOrderDtlAcs.GetStockPriceTaxInc(stockDetailWork.StockUnitPriceFl, stockDetailWork.TaxationCode, stockCnsTaxFrcProcCd);

            // 仕入単価変更区分
            if (stockDetailWork.StockUnitPriceFl == stockDetailWork.BfStockUnitPriceFl)
            {
                stockDetailWork.StockUnitChngDiv = 0;       // 変更なし
            }
            else
            {
                stockDetailWork.StockUnitChngDiv = 1;       // 変更あり
            }

            // 仕入金額(税抜き、税込み)
            long stockPriceTaxInc = 0;
            long stockPriceTaxExc = 0;
            long stockPriceConsTax = 0;

            bool bStatus = this._uoeOrderDtlAcs.CalculationStockPrice(
                stockDetailWork.StockCount,
                stockDetailWork.StockUnitPriceFl,
                stockDetailWork.TaxationCode,
                stockMoneyFrcProcCd,
                stockCnsTaxFrcProcCd,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax);

            if (bStatus == true)
            {
                stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;    //仕入金額（税抜き）
                stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;    //仕入金額（税込み）
            }
            else
            {
                stockDetailWork.StockPriceTaxExc = 0;                   //仕入金額（税抜き）
                stockDetailWork.StockPriceTaxInc = 0;                   //仕入金額（税込み）
            }

            // 仕入金額消費税額(仕入金額税込み-仕入金額税抜き)
            stockDetailWork.StockPriceConsTax = stockDetailWork.StockPriceTaxInc - stockDetailWork.StockPriceTaxExc;

            // --- ADD 2009/01/16 不具合対応[10145] --------------------------------------------------------->>>>>
            // 発注品採用時、代替品を採用しない
            if (this._stockBlnktPrtNoDiv != 0)
            {
                return stockDetailWork;
            }
            // --- ADD 2009/01/16 不具合対応[10145] ---------------------------------------------------------<<<<<

            // 代替品ありの場合、再設定
            if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
            {
                // 商品マスタ読み込み
                List<GoodsUnitData> goodsUnitDataList = this.GetGoodsUnitDataList(stockDetailWork.GoodsMakerCd, uoeOrderDtlWork.SubstPartsNo);
                if (goodsUnitDataList != null)              //ADD 2009/01/19 不具合対応[10178]
                {                                           //ADD 2009/01/19 不具合対応[10178]
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                  // 商品メーカーコード
                    stockDetailWork.MakerName = goodsUnitData.MakerName;                        // メーカー名称
                    stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;                // メーカーカナ名称
                    stockDetailWork.CmpltMakerKanaName = string.Empty;                          // メーカーカナ名称（一式）
                    stockDetailWork.GoodsNo = goodsUnitData.GoodsNo;                            // 商品番号
                    stockDetailWork.GoodsName = goodsUnitData.GoodsName;                        // 商品名称
                    stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;                // 商品名称カナ
                    stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // 商品大分類コード
                    stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // 商品大分類名称
                    stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // 商品中分類コード
                    stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // 商品中分類名称
                    stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                    // BLグループコード
                    stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                    // BLグループコード名称
                    stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL商品コード
                    stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL商品コード名称（全角）
                    stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // 自社分類コード
                    stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // 自社分類名称
                }                                           //ADD 2009/01/19 不具合対応[10178]
            }

            return stockDetailWork;
        }
        #endregion
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ---------------------------------------<<<<<

        #region ▼CreateSlipDetailAddInfoWork(更新用仕入明細付加データ作成)
        /// <summary>
        /// 更新用仕入明細付加データ作成
        /// </summary>
        /// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        /// <param name="splitFlg">分納有無(True：あり、False：なし)</param>
        /// <returns>更新用仕入明細付加データ</returns>
        /// <remarks>
        /// <br>Note       : グリッドメイン(更新情報)データを元に更新用仕入明細付加データを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        //private SlipDetailAddInfoWork CreateSlipDetailAddInfoWork(GridMainDataSet.GridMainTableRow mainRow)           //DEL 2009/02/17 不具合対応[10140][10177][10529]
        private SlipDetailAddInfoWork CreateSlipDetailAddInfoWork(GridMainDataSet.GridMainTableRow mainRow,bool splitFlg)
        {
            SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

            slipDetailAddInfoWork.GoodsEntryDiv = 0;                                    // 商品登録区分                 [0：なし]
            slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;                   // 商品提供日付
            slipDetailAddInfoWork.PriceUpdateDiv = 0;                                   // 価格更新区分                 [0：なし]
            slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;                   // 価格開始日付
            slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;                   // 価格提供日付
            slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;                         // 車両関連付けGUID

            //計上残区分
            /* ---DEL 2009/02/17 不具合対応[10140][10177][10529] ------------------------------->>>>>
            if (mainRow.DivCd == PMUOE01202EA.DIVCD_DELETE)
            {
                // 消し込み
                slipDetailAddInfoWork.AddUpRemDiv = 2;      // 2：残さない
            }
            else
            {
                // その他
                slipDetailAddInfoWork.AddUpRemDiv = 1;      // 1：残す
            }
               ---DEL 2009/02/17 不具合対応[10140][10177][10529] -------------------------------<<<<< */
            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ------------------------------->>>>>
            if (splitFlg)
            {
                // 分納あり時
                slipDetailAddInfoWork.AddUpRemDiv = 1;                                                      // 1：残す
                slipDetailAddInfoWork.OrderRemainAdjustCnt = mainRow.EnterCnt - mainRow.InputEnterCnt;      // 差分(修正時の発注残調整用)
            }
            else
            {
                // 分納なし時
                slipDetailAddInfoWork.AddUpRemDiv = 2;                                                      // 2：残さない
                slipDetailAddInfoWork.OrderRemainAdjustCnt = 0;                                             // 差分(修正時の発注残調整用)
            }
            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] -------------------------------<<<<<

            return slipDetailAddInfoWork;
        }
        #endregion

        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------->>>>>
        #region CreateGridMainWorkTable(更新済データを含むグリッドメインデータ作成)
        /// <summary>
        /// 更新済データを含むグリッドメインデータ作成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 更新済データを含むグリッドメインデータを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br></br>
        /// <br>Update Note: 2012/02/08 劉亜駿</br>
        /// <br>#Redmine28282 在庫入庫更新のエラーを修正する</br>
        /// </remarks>
        private GridMainDataSet.GridMainWorkTableDataTable CreateGridMainWorkTable()
        {
            GridMainDataSet.GridMainWorkTableDataTable gridMainTable = new GridMainDataSet.GridMainWorkTableDataTable();
            GridMainDataSet.GridMainWorkTableRow gridMainRow = null;
            UOEOrderDtlWork uoeOrderDtlWork = null;

            foreach (string key in this._uoeOrderDtlWorkHTable.Keys)
            {
                uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];

                // 拠点
                //if (uoeOrderDtlWork.UOESectOutGoodsCnt > 0) //DEL BY 劉亜駿 on 2012/02/08 for Redmine#28282
                if (uoeOrderDtlWork.UOESectOutGoodsCnt != 0) // ADD BY　劉亜駿 on 2012/02/08 for Redmine#28282
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //共通
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_SECTION;                              // 列区分
                    gridMainRow.SlipNo = uoeOrderDtlWork.UOESectionSlipNo;                  // 伝票番号
                    gridMainRow.UOESectOutGoodsCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;    // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = 0;                                          // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;              // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.UOESectOutGoodsCnt;         // 入庫数(入力用)

                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // BO1
                if (uoeOrderDtlWork.BOShipmentCnt1 > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //共通
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_BO1;                                  // 列区分
                    gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo1;                         // 伝票番号
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt1;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt1;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt1;             // 入庫数(入力用)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // BO2
                if (uoeOrderDtlWork.BOShipmentCnt2 > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //共通
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_BO2;                                  // 列区分
                    gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo2;                         // 伝票番号
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt2;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt2;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt2;             // 入庫数(入力用)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // BO3
                if (uoeOrderDtlWork.BOShipmentCnt3 > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //共通
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_BO3;                                  // 列区分
                    gridMainRow.SlipNo = uoeOrderDtlWork.BOSlipNo3;                         // 伝票番号
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.BOShipmentCnt3;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.BOShipmentCnt3;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.BOShipmentCnt3;             // 入庫数(入力用)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // MF
                if (uoeOrderDtlWork.MakerFollowCnt > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //共通
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_MAKER;                                // 列区分
                    gridMainRow.SlipNo = "";                                                // 伝票番号(スペース)
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.MakerFollowCnt;             // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.MakerFollowCnt;                  // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.MakerFollowCnt;             // 入庫数(入力用)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
                // EO
                if (uoeOrderDtlWork.EOAlwcCount > 0)
                {
                    gridMainRow = this.CreateGridMainWorkDataRow(gridMainTable, uoeOrderDtlWork);       //共通
                    gridMainRow.ColumnDiv = PMUOE01203AA.COLUMNDIV_EO;                                   // 列区分
                    gridMainRow.SlipNo = "";                                                // 伝票番号(スペース)
                    gridMainRow.UOESectOutGoodsCnt = 0;                                     // UOE拠点出庫数
                    gridMainRow.BOShipmentCnt = uoeOrderDtlWork.EOAlwcCount;                // BO出庫数
                    gridMainRow.EnterCnt = uoeOrderDtlWork.EOAlwcCount;                     // 入庫数
                    gridMainRow.InputEnterCnt = uoeOrderDtlWork.EOAlwcCount;                // 入庫数(入力用)
                    gridMainTable.AddGridMainWorkTableRow(gridMainRow);
                }
            }

            return gridMainTable;
        }
        #endregion

        #region CreateGridMainWorkDataRow(更新済データを含むグリッドメインデータの行作成)
        /// <summary>
        /// 更新済データを含むグリッドメインデータの行作成
        /// </summary>
        /// <param name="gridMainWorkTable">グリッドメイン（更新済データを含む）</param>
        /// <param name="uoeOrderDtlWork">UOE発注データ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 更新済データを含むグリッドメインデータの行を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private GridMainDataSet.GridMainWorkTableRow CreateGridMainWorkDataRow(GridMainDataSet.GridMainWorkTableDataTable gridMainWorkTable
                                                                         , UOEOrderDtlWork uoeOrderDtlWork)
        {
            GridMainDataSet.GridMainWorkTableRow gridMainRow = gridMainWorkTable.NewGridMainWorkTableRow();

            gridMainRow.DivCd = PMUOE01202EA.DIVCD_NOCHANGE;                            // 区分(" "：未処理、"1"：入荷、"2"：未入荷、"3"：修正、"9"：消込み)
            gridMainRow.GoodsMakerCd = uoeOrderDtlWork.GoodsMakerCd;                 // メーカーコード
            gridMainRow.GoodsNo = uoeOrderDtlWork.GoodsNo;                           // 品番
            gridMainRow.GoodsName = uoeOrderDtlWork.GoodsName;                       // 品名
            gridMainRow.UOESalesOrderNo = uoeOrderDtlWork.UOESalesOrderNo;           // UOE発注番号
            gridMainRow.UOESalesOrderRowNo = uoeOrderDtlWork.UOESalesOrderRowNo;     // UOE発注行番号
            gridMainRow.OnlineNo = uoeOrderDtlWork.OnlineNo;                         // オンライン番号
            gridMainRow.OnlineRowNo = uoeOrderDtlWork.OnlineRowNo;                   // オンライン行番号
            gridMainRow.WarehouseCode = uoeOrderDtlWork.WarehouseCode;               // 倉庫コード
            gridMainRow.WarehouseShelfNo = uoeOrderDtlWork.WarehouseShelfNo;         // 棚番
            gridMainRow.SalesUnitCost = uoeOrderDtlWork.SalesUnitCost;               // 原価単価
            gridMainRow.AnswerSalesUnitCost = uoeOrderDtlWork.AnswerSalesUnitCost;   // 回答原価単価
            gridMainRow.AnswerPartsNo = uoeOrderDtlWork.AnswerPartsNo;               // 回答品番
            gridMainRow.UOERemark1 = uoeOrderDtlWork.UoeRemark1;                     // リマーク1
            gridMainRow.UOERemark2 = uoeOrderDtlWork.UoeRemark2;                     // リマーク2
            gridMainRow.SupplierCd = uoeOrderDtlWork.SupplierCd;                     // 仕入先コード
            gridMainRow.SubstPartsNo = uoeOrderDtlWork.SubstPartsNo;                 // 代替品番
            gridMainRow.SupplierSlipNo = uoeOrderDtlWork.SupplierSlipNo;             // 仕入伝票番号
            gridMainRow.StockSlipDtlNumSrc = uoeOrderDtlWork.StockSlipDtlNum;        // 仕入明細通番
            gridMainRow.HeaderGridRowNo = 0;                                            // UOE入庫更新ヘッダーグリッド用行番号
            gridMainRow.DetailGridRowNo = 0;                                            // UOE入庫更新明細グリッド用行番号
            gridMainRow.InputAnswerSalesUnitCost = uoeOrderDtlWork.AnswerSalesUnitCost;   // 回答原価単価
            gridMainRow.AnswerMakerCd = uoeOrderDtlWork.AnswerMakerCd;               // 回答メーカーコード
            gridMainRow.UOESupplierCd = uoeOrderDtlWork.UOESupplierCd;               // UOE発注先コード          //ADD 2009/01/19 不具合対応[10063]

            return gridMainRow;
        }
        #endregion

        // 発注・計上データ作成関連
        #region ▼CreateOrderDtlArrayList(発注・計上データ群作成)
        /// <summary>
        /// 発注・計上データ群作成
        /// </summary>
        /// <param name="uoeStcUpdDataList"></param>
        /// <remarks>
        /// <br>Note       : グリッドメイン(更新情報)データ、仕入データ、仕入明細データ、UOE発注データを元に発注データ</br>
        /// <br>             及び計上データを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2012/08/30 鄧潘ハン</br>
        /// <br>管理番号   : 10801804-00 20120912配信分</br>
        /// <br>             redmine #31885:吉田商会　在庫入庫更新処理の対応</br>
        /// <br>             同一のオンライン番号であっても異なる仕入伝票に生成されてしまうの障害の対応</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        private void CreateOrderDtlArrayList(ref CustomSerializeArrayList uoeStcUpdDataList)
        {
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
            int nextSupplierSlipNo = 0;
            int nowSupplierSlipNo = 0;
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
            string columnDiv = string.Empty;
            int gridMainWorkRowCount = 0;
            int supplierSlipNo = 0;
            long stockSlipDtlNum = 0;
            int deleteCount = 0;                                            // 明細分納削除数
            double deleteStockCount = 0;
            double orderCount = 0;
            bool substPartsNoIsExists = false;                              // 代替有無
            bool stockSlipIsUpdate = false;         //True：更新あり、False：更新なし
            int substPartsNoCount = 0;
            GridMainDataSet.GridMainTableRow gridMainRow = null;            // 画面情報
            GridMainDataSet.GridMainTableRow gridMainRowBackUp = null;      // 画面情報バックアップ
            GridMainDataSet.GridMainTableRow gridMainRowWork = null;
            Hashtable updateSlipNoHTable = new Hashtable();                       // 更新対象の伝票番号
            StockSlipListInfo stockSlipListInfo = new StockSlipListInfo();  // 発注・計上データ貯め込み用クラス
            StockSlipListInfo stockSlipListInfoWork = new StockSlipListInfo();      //計上データ再編成用貯め込みクラス
            StockSlipWork stockSlipWork = null;                             // 仕入データ
            StockDetailWork stockDetailWork = null;                         // 仕入明細データ
            SlipDetailAddInfoWork slipDetailAddInfoWork = null;             // 仕入明細調整データ
            IOWriteMASIRDeleteWork deleteWork = null;                       // 発注伝票削除情報
            List<StockDetailWork> stockDetailWorkList = null;               // 計上明細リスト
            List<StockDetailWork> stockDetailWorkBfList = null;             // 発注明細リスト
            List<IOWriteMASIRDeleteWork> deleteWorkList = new List<IOWriteMASIRDeleteWork>();       //発注伝票削除リスト

            HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableDataTable headerNoAndGuidJoinTable = null;      //計上明細とヘッダー紐付けテーブル
            HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableRow headerNoAndGuidJoinRow = null;
            HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableRow headerNoAndGuidJoinRowBf = null;
            int headerGridRowNo = 0;

            // UOE発注を分納単位にしたもの
            GridMainDataSet.GridMainWorkTableDataTable gridMainWorkTable = this.CreateGridMainWorkTable();
            GridMainDataSet.GridMainWorkTableRow gridMainWorkRow = null;

            // 仕入と仕入明細の紐付け情報取得
            StockSlipAndDetailJoin.JoinTableDataTable slipJoinTable = this.CreateSlipJoinTable();

            // 画面に表示されていて、更新対象の伝票番号を取得
            #region 画面に表示されていて、更新対象の伝票番号を取得
            DataRow[] dataRows = this.GetGridMainDataRows();
            for (int i = 0; i<= dataRows.Length - 1; i++)
            {
                supplierSlipNo = int.Parse(dataRows[i][this._gridMainDataTable.SupplierSlipNoColumn.ColumnName].ToString());

                if (updateSlipNoHTable.ContainsKey(supplierSlipNo) == true)
                {
                    continue;
                }

                updateSlipNoHTable.Add(supplierSlipNo, supplierSlipNo);
            }
            #endregion

            // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
            //更新対象の伝票番号単位に処理を行う
            //foreach (int key in updateSlipNoHTable.Keys)
            //{
            // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
                substPartsNoCount = 0;      //代替件数
                stockSlipIsUpdate = false;

                // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
                // 1伝票に紐付く仕入明細取得
                //supplierSlipNo = (int)updateSlipNoHTable[key];
                // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<

                // 1伝票内の計上ヘッダー・明細紐付け情報// DEL 2012/08/30 鄧潘ハン  redmine#31885
                //伝票内の計上ヘッダー・明細紐付け情報// ADD 2012/08/30 鄧潘ハン  redmine#31885
                headerNoAndGuidJoinTable = new HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableDataTable();
                //string slipJoinFilter = string.Format("({0}={1})", slipJoinTable.SupplierSlipNoColumn.ColumnName, supplierSlipNo);// DEL 2012/08/30 鄧潘ハン  redmine#31885
                // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
                string slipJoinFilter = string.Empty;
                foreach (int key in updateSlipNoHTable.Keys)
                {
                    supplierSlipNo = (int)updateSlipNoHTable[key];
                    if (string.IsNullOrEmpty(slipJoinFilter))
                    {
                        slipJoinFilter = string.Format("({0}={1})", _gridMainDataTable.SupplierSlipNoColumn.ColumnName, supplierSlipNo);
                    }
                    else
                    {
                        slipJoinFilter = slipJoinFilter + " OR " + string.Format("({0}={1})", _gridMainDataTable.SupplierSlipNoColumn.ColumnName, supplierSlipNo);
                    }
                }
                DataRow[] slipJoinRows = slipJoinTable.Select(slipJoinFilter, _gridMainDataTable.SupplierSlipNoColumn.ColumnName + " ASC");
                // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
                //DataRow[] slipJoinRows = slipJoinTable.Select(slipJoinFilter);//DEL 2012/08/30 鄧潘ハン  redmine#31885
                for (int j = 0; j <= slipJoinRows.Length - 1; j++)
                {
                    //↓↓↓↓↓仕入明細1件に対する処理↓↓↓↓↓

                    //明細通番取得
                    stockSlipDtlNum = (long)slipJoinRows[j][slipJoinTable.StockSlipDtlNumSrcColumn.ColumnName];

                    //代替有無取得
                    substPartsNoIsExists = this.CheckSubstPartsNoIsExists(stockSlipDtlNum);
                    if (substPartsNoIsExists)
                    {
                        stockSlipIsUpdate = true;
                        substPartsNoCount++;
                    }

                    // 仕入明細に紐付く画面の明細を取得(分納がある為、2件以上となる事もある)
                    string gridMainWorkFilter = string.Format("({0}={1})", this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, stockSlipDtlNum);
                    DataRow[] gridMainWorkRows = gridMainWorkTable.Select(gridMainWorkFilter);
                    gridMainWorkRowCount = gridMainWorkRows.Length;
                    // 件数無し
                    if (gridMainWorkRowCount == 0)
                    {
                        #region 1仕入0明細
                        gridMainRow = null;

                        //計上明細データなし

                        //明細追加情報なし

                        //発注明細データ更新なし(代替品であっても表示されていないものは更新しない)
                        stockSlipListInfo.StockDetailWorkBf = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);

                        //UOE発注データ更新なし
                        #endregion
                    }
                    // 1仕入1明細
                    //else if (gridMainRowCount == 1)
                    else if (gridMainWorkRowCount == 1)
                    {
                        #region 1仕入1明細
                        //gridMainRowCount = 1;
                        gridMainWorkRow = (GridMainDataSet.GridMainWorkTableRow)gridMainWorkRows[0];

                        // ------------DEL 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                        //分納を含む全てのデータの中から画面に表示されているものだけ抽出
                        //string gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                        //                            this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                        //                            this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                        // ------------DEL 李占川 2013/05/16 FOR Redmine#35459---------<<<<

                        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                        string gridMainFilter = string.Empty;
                        if (!this._meiJiDiv || string.Empty.Equals(gridMainWorkRow.SlipNo))
                        {
                            gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                                                        this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                                        this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                        }
                        else
                        {
                            gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}' AND {4}='{5}')",
                                                        this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                                        this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv,
                                                        this._gridMainDataTable.SlipNoColumn, gridMainWorkRow.SlipNo);
                        }

                        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<
                        DataRow[] gridMainRows = this._gridMainDataTable.Select(gridMainFilter);
                        gridMainRow = (GridMainDataSet.GridMainTableRow)gridMainRows[0];

                        if (gridMainRow.DivCd == PMUOE01202EA.DIVCD_DELETE)
                        {
                            //計上明細データなし

                            //明細追加情報なし

                            //発注明細データなし

                            //UOE発注データ更新
                            //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists);                      // DEL 李占川 2013/05/16 Redmine#35459
                            this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists, gridMainRow.SlipNo);    // ADD 李占川 2013/05/16 Redmine#35459

                            stockSlipIsUpdate = true;       // 更新あり
                        }
                        else if ((gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOCHANGE) ||
                                 (gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOTENTER))
                        {
                            //計上明細データなし

                            //明細追加情報なし

                            //発注明細データ
                            stockSlipListInfo.StockDetailWorkBf = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);

                            //UOE発注データ更新なし
                        }
                        else
                        {
                            //GUID採番
                            stockSlipListInfo.DtlRelationGuid = Guid.NewGuid();

                            //計上明細データ
                            stockSlipListInfo.StockDetailWork = this.GetStockDetailWorkUpdate(gridMainRow);

                            // 計上ヘッダー・明細紐付け情報
                            headerNoAndGuidJoinTable.AddHeaderNoAndGuidJoinTableRow(gridMainRow.HeaderGridRowNo
                                                                                    ,gridMainRow.DetailGridRowNo
                                                                                    ,stockSlipListInfo.DtlRelationGuid);

                            //明細追加情報
                            slipDetailAddInfoWork = this.CreateSlipDetailAddInfoWork(gridMainRow,false);
                            stockSlipListInfo.SlipDetailAddInfoWork = slipDetailAddInfoWork;

                            //発注明細データ
                            stockDetailWork = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);

                            if (substPartsNoIsExists)
                            {
                                //代替品時、更新あり
                                this.SetSubstPartsInfo(ref stockDetailWork);
                            }
                            else
                            {
                                // 更新なし
                            }
                            stockSlipListInfo.StockDetailWorkBf = stockDetailWork;

                            //UOE発注データ更新
                            //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists);                   // DEL 李占川 2013/05/16 Redmine#35459
                            this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists, gridMainRow.SlipNo); // ADD 李占川 2013/05/16 Redmine#35459
                        }

                        // 発注ヘッダー取得用に保持しておく
                        if (gridMainRow != null)
                        {
                            gridMainRowBackUp = gridMainRow;
                        }
                        #endregion
                    }
                    // 1仕入2明細以上
                    else
                    {
                        #region 1仕入2明細以上
                        deleteCount = 0;            //削除明細数
                        deleteStockCount = 0;       //削除仕入数
                        for (int k = 0; k <= gridMainWorkRowCount - 1; k++)
                        {
                            gridMainWorkRow = (GridMainDataSet.GridMainWorkTableRow)gridMainWorkRows[k];

                            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                            //分納を含む全てのデータの中から今回更新対象のものを抽出
                            //string gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                            //                                this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                            //                                this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459---------<<<<
                            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                            string gridMainFilter = string.Empty;
                            if (!this._meiJiDiv || string.Empty.Equals(gridMainWorkRow.SlipNo))
                            {
                                gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}')",
                                                                this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                                                this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv);
                            }
                            else
                            {
                                gridMainFilter = string.Format("({0}={1}) AND ({2}='{3}' AND {4}='{5}')",
                                        this._gridMainDataTable.StockSlipDtlNumSrcColumn.ColumnName, gridMainWorkRow.StockSlipDtlNumSrc,
                                        this._gridMainDataTable.ColumnDivColumn.ColumnName, gridMainWorkRow.ColumnDiv,
                                        this._gridMainDataTable.SlipNoColumn, gridMainWorkRow.SlipNo);
                            }

                            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<
                            DataRow[] gridMainRows = this._gridMainDataTable.Select(gridMainFilter);
                            if (gridMainRows.Length == 0)
                            {
                                continue;
                            }

                            gridMainRow = (GridMainDataSet.GridMainTableRow)gridMainRows[0];


                            if (gridMainRow.DivCd == PMUOE01202EA.DIVCD_DELETE)
                            {
                                //計上明細データなし

                                //明細追加情報なし

                                deleteStockCount = deleteStockCount + gridMainRow.EnterCnt;     //削除仕入数を加算

                                deleteCount++;                                                  //削除数カウントアップ

                                //UOE発注データ更新
                                //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists);                   // DEL 李占川 2013/05/16 Redmine#35459
                                this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty, substPartsNoIsExists, gridMainRow.SlipNo); // ADD 李占川 2013/05/16 Redmine#35459
                            }
                            else if ((gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOCHANGE) ||
                                     (gridMainRow.DivCd == PMUOE01202EA.DIVCD_NOTENTER))
                            {
                                //計上明細データなし

                                //明細追加情報なし

                                //削除仕入数の加算なし

                                //削除数カウントアップなし

                                //UOE発注データ更新なし
                            }
                            else
                            {
                                //GUID採番
                                stockSlipListInfo.DtlRelationGuid = Guid.NewGuid();

                                //計上明細データ
                                stockSlipListInfo.StockDetailWork = this.GetStockDetailWorkUpdate(gridMainRow);

                                // 計上ヘッダー・明細紐付け情報
                                headerNoAndGuidJoinTable.AddHeaderNoAndGuidJoinTableRow(gridMainRow.HeaderGridRowNo
                                                                                        ,gridMainRow.DetailGridRowNo
                                                                                        ,stockSlipListInfo.DtlRelationGuid);

                                //明細追加情報
                                stockSlipListInfo.SlipDetailAddInfoWork = this.CreateSlipDetailAddInfoWork(gridMainRow,true);

                                //UOE発注データ更新
                                //this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists);                   // DEL 李占川 2013/05/16 Redmine#35459
                                this.UpdateUOEOrderDtlWork(stockSlipDtlNum, gridMainRow.ColumnDiv, ENTERUPDDIV_ENTER, stockSlipListInfo.DtlRelationGuid, substPartsNoIsExists, gridMainRow.SlipNo); // ADD 李占川 2013/05/16 Redmine#35459
                            }

                            // 発注ヘッダー取得用に保持しておく
                            if (gridMainRow != null)
                            {
                                // InputSlipNoが無い(画面に表示されていない)ものは対象としない
                                try
                                {
                                    if (gridMainRow.InputSlipNo != null)
                                    {
                                        gridMainRowBackUp = gridMainRow;
                                    }
                                }
                                catch (StrongTypingException)
                                {
                                }
                            }
                        }

                        //発注明細データ
                        #region 発注明細データ作成
                        if (deleteCount == 0)
                        {
                            //取消なし

                            stockDetailWork = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);
                            if (substPartsNoIsExists)
                            {
                                // 代替用項目更新
                                this.SetSubstPartsInfo(ref stockDetailWork);
                            }
                            else
                            {
                                // 更新なし
                            }
                            stockSlipListInfo.StockDetailWorkBf = stockDetailWork;
                        }
                        else if (gridMainWorkRowCount.Equals(deleteCount))
                        {
                            //全て取消

                            //発注明細データなし
                        }
                        else
                        {
                            //一部取消：発注の数量からあらかじめ削除数分引いておく

                            //発注明細データ更新あり
                            stockDetailWork = this.GetStockDetailWorkNoUpdate(stockSlipDtlNum);
                            orderCount = stockDetailWork.OrderCnt;

                            stockDetailWork.StockCount = orderCount - deleteStockCount;         //仕入数
                            stockDetailWork.OrderCnt = orderCount - deleteStockCount;           //発注数
                            stockDetailWork.OrderRemainCnt = orderCount - deleteStockCount;     //発注残数

                            if (substPartsNoIsExists)
                            {
                                // 代替用項目更新
                                this.SetSubstPartsInfo(ref stockDetailWork);
                            }
                            else
                            {
                                // 更新なし
                            }
                            // 取消した結果残数が無くなる場合は明細削除とみなす
                            if (stockDetailWork.OrderRemainCnt > 0)
                            {
                                stockSlipListInfo.StockDetailWorkBf = stockDetailWork;
                            }
                            stockSlipIsUpdate = true;
                        }
                        #endregion
                        #endregion
                    }
                    // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
                    //今回データの仕入伝票番号の取得
                    nowSupplierSlipNo = (int)slipJoinRows[j][slipJoinTable.SupplierSlipNoColumn.ColumnName];
                    //最後のデータの以外の場合、次のデータ仕入伝票番号の取得
                    if (slipJoinRows.Length - 1 != j)
                    {
                        nextSupplierSlipNo = (int)slipJoinRows[j + 1][slipJoinTable.SupplierSlipNoColumn.ColumnName];
                    }
                    //今回データの仕入伝票番号と次のデータの仕入伝票番号は違いの場合、或いは、最後のデータの場合。
                    if (nowSupplierSlipNo != nextSupplierSlipNo || slipJoinRows.Length - 1 == j)
                    {
                        // 発注データ作成
                        #region 発注データ作成
                        // 発注明細データ取得
                        stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                        if (stockDetailWorkBfList.Count == 0)
                        {
                            stockSlipWork = this.GetStockSlipWorkNoUpdate(nowSupplierSlipNo);

                            // 全明細削除
                            deleteWork = new IOWriteMASIRDeleteWork();
                            deleteWork.DebitNoteDiv = stockSlipWork.DebitNoteDiv;

                            deleteWork.EnterpriseCode = this._enterpriseCode;
                            deleteWork.SupplierFormal = stockSlipWork.SupplierFormal;
                            deleteWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
                            deleteWork.UpdateDateTime = stockSlipWork.UpdateDateTime;

                            deleteWorkList.Add(deleteWork);
                        }
                        else if (stockSlipIsUpdate == false)
                        {
                            // 発注明細の更新なし(代替、削除が無い)　→　発注データは必要なし
                        }
                        else
                        {
                            //発注明細データ取得
                            stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                            //発注データ
                            stockSlipListInfo.StockSlipWorkBf = this.SetOrderInfo(gridMainRowBackUp, stockDetailWorkBfList);

                            //発注データ群をまとめてuoeStcUpdDataListに追加
                            uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
                        }
                        #endregion
                        substPartsNoCount = 0;      //代替件数
                        stockSlipIsUpdate = false;
                        // 貯め込んだ1伝票分の情報を削除
                        stockSlipListInfo.ClearBfItem();
                    }
                    // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
                }

                // 計上データ作成
                #region 計上データ作成
                // 計上明細データ取得
                stockDetailWorkList = stockSlipListInfo.StockDetailWorkList;

                if (stockDetailWorkList.Count == 0)
                {
                    // 画面に値なし　→　計上データなし
                }
                else
                {
                    #region 計上ヘッダー・明細紐付けテーブルを元にして明細をヘッダー毎にまとめる。まとめた後uoeStcUpdDataListに追加
                    stockSlipListInfoWork = new StockSlipListInfo();

                    headerGridRowNo = -1;
                    string headerNoAndJoinSort = string.Format("{0},{1}",headerNoAndGuidJoinTable.HeaderGridRowNoColumn.ColumnName
                                                                        ,headerNoAndGuidJoinTable.DetailGridRowNoColumn.ColumnName);
                    DataRow[] headerNoAndGuidJoinRows = headerNoAndGuidJoinTable.Select(string.Empty, headerNoAndJoinSort);
                    for (int idx = 0; idx <= headerNoAndGuidJoinRows.Length - 1; idx++)
                    {
                        headerNoAndGuidJoinRow = (HeaderNoAndGuidJoin.HeaderNoAndGuidJoinTableRow)headerNoAndGuidJoinRows[idx];
                        if ((idx > 0) && (headerGridRowNo != headerNoAndGuidJoinRow.HeaderGridRowNo))
                        {
                            //グリッドメインの情報取得
                            string filter = string.Format("({0}={1}) AND ({2}={3})"
                                                        , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.HeaderGridRowNo
                                                        , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.DetailGridRowNo);

                            DataRow[] gridMainRowsWork = this._gridMainDataTable.Select(filter);
                            gridMainRowWork = (GridMainDataSet.GridMainTableRow)gridMainRowsWork[0];     

                            // ヘッダー情報取得
                            stockSlipListInfoWork.StockSlipWork = this.GetStockSlipWorkUpdate(gridMainRowWork, stockSlipListInfoWork.StockDetailWorkList).Clone();

                            // 計上データ群をまとめてuoeStcUpdDataListに追加
                            uoeStcUpdDataList.Add(stockSlipListInfoWork.StockSlipList);

                            stockSlipListInfoWork.ClearItem();
                        }

                        //GUID
                        stockSlipListInfoWork.DtlRelationGuid = headerNoAndGuidJoinRow.Guid;

                        // 明細
                        stockSlipListInfoWork.StockDetailWork = stockSlipListInfo.GetStockDetailWork(headerNoAndGuidJoinRow.Guid).Clone();
                        // 明細付加情報
                        stockSlipListInfoWork.SlipDetailAddInfoWork = stockSlipListInfo.GetSlipDetailAddInfoWork(headerNoAndGuidJoinRow.Guid);

                        headerGridRowNo = headerNoAndGuidJoinRow.HeaderGridRowNo;
                        headerNoAndGuidJoinRowBf = headerNoAndGuidJoinRow;
                    }


                    //グリッドメインの情報取得
                    string filter2 = string.Format("({0}={1}) AND ({2}={3})"
                                                , this._gridMainDataTable.HeaderGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.HeaderGridRowNo
                                                , this._gridMainDataTable.DetailGridRowNoColumn.ColumnName, headerNoAndGuidJoinRowBf.DetailGridRowNo);

                    DataRow[] gridMainRowsWork2 = this._gridMainDataTable.Select(filter2);
                    gridMainRowWork = (GridMainDataSet.GridMainTableRow)gridMainRowsWork2[0];

                    // ヘッダー情報取得
                    stockSlipListInfoWork.StockSlipWork = this.GetStockSlipWorkUpdate(gridMainRowWork, stockSlipListInfoWork.StockDetailWorkList).Clone();

                    // 計上データ群をまとめてuoeStcUpdDataListに追加
                    CustomSerializeArrayList csList = stockSlipListInfoWork.StockSlipList;
                    uoeStcUpdDataList.Add(csList);


                    // 計上データ
                    //stockSlipListInfo.StockSlipWork = this.GetStockSlipWorkUpdate(gridMainRowBackUp, stockDetailWorkList);

                    // 計上データ群をまとめてuoeStcUpdDataListに追加
                    //uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipList);
                    #endregion
                }
                #endregion

                // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
                // 発注データ作成
                #region 発注データ作成
                //// 発注明細データ取得
                //stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                //if (stockDetailWorkBfList.Count == 0)
                //{
                //    stockSlipWork = this.GetStockSlipWorkNoUpdate(supplierSlipNo);

                //    // 全明細削除
                //    deleteWork = new IOWriteMASIRDeleteWork();
                //    deleteWork.DebitNoteDiv = stockSlipWork.DebitNoteDiv;

                //    deleteWork.EnterpriseCode = this._enterpriseCode;
                //    deleteWork.SupplierFormal = stockSlipWork.SupplierFormal;
                //    deleteWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
                //    deleteWork.UpdateDateTime = stockSlipWork.UpdateDateTime;

                //    deleteWorkList.Add(deleteWork);
                //}
                //else if (stockSlipIsUpdate == false)
                //{
                //    // 発注明細の更新なし(代替、削除が無い)　→　発注データは必要なし
                //}
                //else
                //{
                //    //発注明細データ取得
                //    stockDetailWorkBfList = stockSlipListInfo.StockDetailWorkBfList;

                //    //発注データ
                //    stockSlipListInfo.StockSlipWorkBf = this.SetOrderInfo(gridMainRowBackUp, stockDetailWorkBfList);

                //    //発注データ群をまとめてuoeStcUpdDataListに追加
                //    uoeStcUpdDataList.Add(stockSlipListInfo.StockSlipBfList);
                //}
                #endregion
                // ----- DEL 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
                // 貯め込んだ1伝票分の情報を削除
                stockSlipListInfo.ClearItem();
            //}//DEL 2012/08/30 鄧潘ハン  redmine#31885

            // 伝票削除用データ作成
            #region 伝票削除用データ作成
            for (int i = 0; i <= deleteWorkList.Count - 1; i++)
            {
                uoeStcUpdDataList.Add(deleteWorkList[i]);
            }
            #endregion
        }
        #endregion

        #region ▼CheckSubstPartsNoIsExists(代替品採用チェック)
        /// <summary>
        /// 代替品採用チェック
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">明細通番</param>
        /// <returns>True:代替品採用、False:代替品採用しない</returns>
        /// <remarks>
        /// <br>Note       : 代替品を採用するかどうかの判定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>        /// </remarks>
        private bool CheckSubstPartsNoIsExists(long stockSlipDtlNumSrc)
        {
            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
            //{
            //    return false;
            //}

            ////代替品採用で代替品がある場合
            //if (this._stockBlnktPrtNoDiv == 0)
            //{
            //    UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()];
            //    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
            //    {
            //        return true;
            //    }
            //}
            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459---------<<<<

            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            if (!this._meiJiDiv)
            {
                if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
                {
                    return false;
                }

                //代替品採用で代替品がある場合
                if (this._stockBlnktPrtNoDiv == 0)
                {
                    UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()];
                    if (string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
                    {
                        return true;
                    }
                }
            }
            else 
            {
                //代替品採用で代替品がある場合
                if (this._stockBlnktPrtNoDiv == 0)
                {
                    UOEOrderDtlWork uoeOrderDtlWork = GetUOEOrderDtlWorkFromTable(this._uoeOrderDtlWorkHTable, stockSlipDtlNumSrc);

                    if (null != uoeOrderDtlWork && string.IsNullOrEmpty(uoeOrderDtlWork.SubstPartsNo.TrimEnd()) == false)
                    {
                        return true;
                    }
                }
            }
            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<

            return false;
        }
        #endregion

        #region SetOrderInfo(発注情報取得)
        /// <summary>
        /// 発注情報取得
        /// </summary>
        /// <param name="mainRow">更新データ</param>
        /// <param name="stockDetailWorkList">仕入(計上・発注)明細データリスト</param>
        /// <returns>発注データ</returns>
        /// <remarks>
        /// <br>Note       : 発注情報をセットします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote  : 2012/10/10 朱 猛</br>
        /// <br>管理番号    : 10801804-00 20120917配信分</br>
        /// <br>              Redmine#32625 消費税計算不正の対応。</br>
        /// </remarks>
        private StockSlipWork SetOrderInfo(GridMainDataSet.GridMainTableRow mainRow, List<StockDetailWork> stockDetailWorkList)
        {
            // 仕入データ取得
            StockSlipWork stockSlipWork = this.GetStockSlipWorkNoUpdate(mainRow.SupplierSlipNo);
            if (stockSlipWork == null)
            {
                return null;
            }

            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = ((Supplier)this._supplierHTable[stockSlipWork.SupplierCd]).StockCnsTaxFrcProcCd;

            stockSlipWork.DetailRowCount = stockDetailWorkList.Count;                   // 明細数                       [貯め込んだ明細数]

            // ----- ADD 2012/10/10 朱 猛 Redmine#32625 ----->>>>>
            //仕入端数処理区分と端数処理単位の取得
            //1:切捨て,2:四捨五入,3:切上げ　（消費税）
            StockProcMoney stockProcMoney = this._uoeOrderDtlAcs.GetStockProcMoney(
                                                        1,
                                                        stockCnsTaxFrcProcCd,
                                                        999999999);

            stockSlipWork.StockFractionProcCd = stockProcMoney.FractionProcCd;
            // ----- ADD 2012/10/10 朱 猛 Redmine#32625 -----<<<<<

            // 仕入データの情報算出(左から仕入、仕入明細リスト、仕入端数処理区分、仕入消費税端数処理コード)
            //StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockSlipWork.StockFractionProcCd, stockCnsTaxFrcProcCd); // DEL 2012/10/10 朱 猛 Redmine#32625
            StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, stockDetailWorkList, stockProcMoney.FractionProcUnit, stockProcMoney.FractionProcCd); // ADD 2012/10/10 朱 猛 Redmine#32625
            //---TotalPriceSettingでは以下の項目が更新される(他にもあるかも？)---
            //stockSlipWork.StockTotalPrice;          // 仕入金額合計
            //stockSlipWork.StockSubttlPrice;         // 仕入金額小計
            //stockSlipWork.StockTtlPricTaxInc;       // 仕入金額計(税込み)
            //stockSlipWork.StockTtlPricTaxExc;       // 仕入金額計(税抜き)
            //stockSlipWork.StockNetPrice;            // 仕入正価金額
            //stockSlipWork.StockPriceConsTax;        // 仕入金額消費税額
            //stockSlipWork.TtlItdedStcOutTax;        // 仕入外税対象額合計
            //stockSlipWork.TtlItdedStcInTax;         // 仕入内税対象額合計
            //stockSlipWork.TtlItdedStcTaxFree;       // 仕入非課税対象額合計
            //stockSlipWork.StockOutTax;              // 仕入金額消費税額(外税)
            //stockSlipWork.StckPrcConsTaxInclu;      // 仕入金額消費税額(内税)
            //stockSlipWork.StckDisTtlTaxExc;         // 仕入値引金額計(税抜き)
            //stockSlipWork.ItdedStockDisOutTax;      // 仕入値引外税対象額合計
            //stockSlipWork.ItdedStockDisInTax;       // 仕入値引内税対象額合計
            //stockSlipWork.ItdedStockDisTaxFre;      // 仕入値引非課税対象額合計
            //stockSlipWork.StockDisOutTax;           // 仕入値引消費税額(外税)
            //stockSlipWork.StckDisTtlTaxInclu;       // 仕入値引消費税額(内税)

            return stockSlipWork;
        }
        #endregion

        #region ▼SetSubstPartsInfo(発注データ用代替品情報セット)
        /// <summary>
        /// 発注データ用代替品情報セット
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE発注データ</param>
        /// <param name="stockDetailWork">仕入(計上・発注)明細データ</param>
        /// <remarks>
        /// <br>Note       : 代替品情報をセットします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        private void SetSubstPartsInfo(ref StockDetailWork stockDetailWork)
        {
            long stockSlipDtlNum = stockDetailWork.StockSlipDtlNum;

            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNum.ToString()) == false)
            //{
            //    return;
            //}
            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459---------<<<<

            /*
            // ヘッダー初期化
            stockDetailWork.CreateDateTime = DateTime.MinValue;                         // 作成日時                     [初期化]
            stockDetailWork.UpdateDateTime = DateTime.MinValue;                         // 更新日時                     [初期化]
            stockDetailWork.EnterpriseCode = this._enterpriseCode;                      // 企業コード
            stockDetailWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [初期化]
            stockDetailWork.UpdEmployeeCode = string.Empty;                             // 更新従業員コード             [初期化]
            stockDetailWork.UpdAssemblyId1 = string.Empty;                              // 更新アセンブリID1            [初期化]
            stockDetailWork.UpdAssemblyId2 = string.Empty;                              // 更新アセンブリID2            [初期化]
            stockDetailWork.LogicalDeleteCode = 0;                                      // 論理削除区分                 [初期化]
            stockDetailWork.AcceptAnOrderNo = 0;                                        // 受注番号                     [初期化]
            //stockDetailWork.StockSlipDtlNum = 0;                                        // 仕入明細通番
            stockDetailWork.SupplierFormalSrc = 0;                                      // 仕入形式(元)
            stockDetailWork.StockSlipDtlNumSrc = 0;                                     // 仕入明細通番(元)
            */
            //stockDetailWork.AcceptAnOrderNo = 0;                                        // 受注番号                     [初期化]
            //stockDetailWork.StockSlipDtlNum = 0;                                        // 仕入明細通番

            // UOE発注データ取得
            //UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNum.ToString()];  // DEL 李占川 2013/05/16 Redmine#35459

            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            UOEOrderDtlWork uoeOrderDtlWork = null;
            if (!this._meiJiDiv)
            {
                if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNum.ToString()) == false)
                {
                    return;
                }

                // UOE発注データ取得
                uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNum.ToString()];
            }
            else
            {
                // UOE発注データ取得
                uoeOrderDtlWork = GetUOEOrderDtlWorkFromTable(this._uoeOrderDtlWorkHTable, stockSlipDtlNum);

                if (null == uoeOrderDtlWork) return;
            }
            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<

            // 商品マスタ読み込み
            List<GoodsUnitData> goodsUnitDataList = this.GetGoodsUnitDataList(stockDetailWork.GoodsMakerCd, uoeOrderDtlWork.SubstPartsNo);
            if (goodsUnitDataList != null) 
            {
                GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                  // 商品メーカーコード
                stockDetailWork.MakerName = goodsUnitData.MakerName;                        // メーカー名称
                stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;                // メーカーカナ名称
                stockDetailWork.CmpltMakerKanaName = string.Empty;                          // メーカーカナ名称（一式）
                stockDetailWork.GoodsNo = goodsUnitData.GoodsNo;                            // 商品番号
                stockDetailWork.GoodsName = goodsUnitData.GoodsName;                        // 商品名称
                stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;                // 商品名称カナ
                stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // 商品大分類コード
                stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // 商品大分類名称
                stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // 商品中分類コード
                stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // 商品中分類名称
                stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                    // BLグループコード
                stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                    // BLグループコード名称
                stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL商品コード
                stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL商品コード名称（全角）
                stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // 自社分類コード
                stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // 自社分類名称
            }
        }
        #endregion

        #region ▼CreateSlipJoinTable(仕入・仕入明細データ紐付けテーブル作成)
        /// <summary>
        /// 仕入・仕入明細データ紐付けテーブル作成
        /// </summary>
        /// <returns>仕入・仕入明細紐付け結果</returns>
        /// <remarks>
        /// <br>Note       : 仕入データと仕入明細を紐付ける為のテーブルを作成します。(HashTableでは抽出が難しいのでDataTableで抽出を行う為)</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private StockSlipAndDetailJoin.JoinTableDataTable CreateSlipJoinTable()
        {
            StockSlipAndDetailJoin.JoinTableDataTable dataTable = new StockSlipAndDetailJoin.JoinTableDataTable();

            foreach (string key in this._stockDetailWorkHTable.Keys)
            {
                StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailWorkHTable[key];

                StockSlipAndDetailJoin.JoinTableRow dataRow = dataTable.NewJoinTableRow();
                dataRow[dataTable.SupplierSlipNoColumn.ColumnName] = stockDetailWork.SupplierSlipNo;
                dataRow[dataTable.StockSlipDtlNumSrcColumn.ColumnName] = stockDetailWork.StockSlipDtlNum;

                dataTable.AddJoinTableRow(dataRow);
            }

            return dataTable;
        }
        #endregion

        #region ▼GetStockSlipWorkNoUpdateList(更新前仕入明細リスト取得)
        /// <summary>
        /// 更新前仕入明細リスト取得
        /// </summary>
        /// <returns>更新前仕入明細リスト</returns>
        /// <remarks>
        /// <br>Note       : HashTableから更新前の仕入明細を全て取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// </remarks>
        private List<StockDetailWork> GetStockDetailWorkNoUpdateList()
        {
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
            for (int i = 0; i <= this._stockDetailWorkHTable.Count - 1; i++)
            {
                stockDetailWorkList.Add(((StockDetailWork)this._stockDetailWorkHTable[i]).Clone());
            }

            return stockDetailWorkList;
        }
        #endregion
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ---------------------------------------<<<<<

        // 在庫調整データ作成関連
        #region ▼CreateStockAdjustArrayList(在庫調整データ群作成)
        /// <summary>
        /// 在庫調整データ群作成
        /// </summary>
        /// <param name="uoeStcUpdDataList">更新用データ</param>
        /// <remarks>
        /// <br>Note       : グリッドメイン(更新情報)データ、仕入データ、仕入明細データ、UOE発注データを元に更新データを作成します。</br>
        /// <br>             また、UOE発注データの入庫区分を更新します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void CreateStockAdjustArrayList(ref CustomSerializeArrayList uoeStcUpdDataList)
        {
            StockAdjustListInfo stockAdjustListInfo = new StockAdjustListInfo();    // 在庫調整データ貯め込み用クラス
            GridMainDataSet.GridMainTableRow mainRow = null;                        // グリッド入力データ(現在値)
            GridMainDataSet.GridMainTableRow mainRowBf = null;                      // グリッド入力データ(前回値)
            CustomSerializeArrayList customSArrayList = new CustomSerializeArrayList();     //ADD 2009/02/25
            int dtlCount = 0;                                                               //ADD 2009/02/25

            // 更新対象データ取得
            //DataRow[] dataRows = this.GetGridMainDataRows();              //DEL 2009/02/25
            // ---ADD 2009/02/25 ------------------------------------------------->>>>>
            DataRow[] dataRows = this.GetGridMainDataRowsStockAdjust();
            if (dataRows.Length == 0)
            {
                return;
            }
            // ---ADD 2009/02/25 -------------------------------------------------<<<<<

            long stockSubttlPrice = 0;   // 2010/11/01 Add

            for (int index = 0; index <= dataRows.Length - 1; index++)
            {
                mainRow = (GridMainDataSet.GridMainTableRow)dataRows[index];

                // ---ADD 2009/02/25 --------------------------------------------->>>>>
                // 倉庫なしは処理しない
                if (string.IsNullOrEmpty(mainRow.WarehouseCode.TrimEnd()))
                {
                    mainRowBf = mainRow;
                    continue;
                }
                // ---ADD 2009/02/25 ---------------------------------------------<<<<<

                // ヘッダーが異なる場合に在庫調整データ作成
                //if ((mainRowBf != null) && (mainRowBf.HeaderGridRowNo != mainRow.HeaderGridRowNo))                                    //DEL 2009/02/25
                if ((mainRowBf != null) &&
                    ((mainRowBf.HeaderGridRowNo != mainRow.HeaderGridRowNo) || (mainRowBf.WarehouseCode != mainRow.WarehouseCode)))     //ADD 2009/02/25
                {
                    if (stockAdjustListInfo.StockAdjustDtlCount > 0)                            //ADD 2009/02/25
                    {                                                                           //ADD 2009/02/25
                        // 在庫調整データ貯め込み
                        // 2010/11/01 >>>
                        //stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf);
                        stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf, stockSubttlPrice);
                        // 2010/11/01 <<<

                        // 貯め込んだ在庫調整、在庫調整明細データをまとめてuoeStcUpdDataListに追加
                        //uoeStcUpdDataList.Add(stockAdjustListInfo.StockAdjustList);           //DEL 2009/02/25
                        customSArrayList.Add(stockAdjustListInfo.StockAdjustList);              //ADD 2009/02/25
                    }                                                                           //ADD 2009/02/25
                    stockAdjustListInfo.ClearItem();
                    stockSubttlPrice = 0;   // 2010/11/01 Add
                }

                // 在庫調整明細データ貯め込み
                // 2010/11/01 >>>
                //stockAdjustListInfo.StockAdjustDtlWork = this.CreateStockAdjustDtlWork(mainRow);
                StockAdjustDtlWork stockAdjustDtlWork = this.CreateStockAdjustDtlWork(mainRow);
                stockSubttlPrice += stockAdjustDtlWork.StockPriceTaxExc;

                stockAdjustListInfo.StockAdjustDtlWork = stockAdjustDtlWork;
                // 2010/11/01 <<<
                dtlCount++;

                // UOE発注データ更新
                //this.UpdateUOEOrderDtlWork(mainRow.StockSlipDtlNumSrc, mainRow.ColumnDiv, ENTERUPDDIV_ENTER, Guid.Empty);         //DEL 2009/02/25

                mainRowBf = mainRow;
            }

            // 以下、最後のデータを処理

            // 在庫調整データ貯め込み
            // 2010/11/01 >>>
            //stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf);
            stockAdjustListInfo.StockAdjustWork = this.CreateStockAdjustWork(mainRowBf, stockSubttlPrice);
            // 2010/11/01 <<<

            // 貯め込んだ在庫調整、在庫調整明細データをまとめてuoeStcUpdDataListに追加
            if (stockAdjustListInfo.StockAdjustDtlCount > 0)                            //ADD 2009/02/25
            {                                                                           //ADD 2009/02/25
                //uoeStcUpdDataList.Add(stockAdjustListInfo.StockAdjustList);           //DEL 2009/02/25
                customSArrayList.Add(stockAdjustListInfo.StockAdjustList);              //ADD 2009/02/25
            }                                                                           //ADD 2009/02/25

            if (dtlCount > 0)
            {
                CustomSerializeArrayList customList = customSArrayList;
                uoeStcUpdDataList.Add(customList);                                      //ADD 2009/02/25
            }
        }
        #endregion

        #region ▼CreateStockAdjustWork(更新用在庫調整データ作成)
        /// <summary>
        /// 更新用在庫調整データ作成
        /// </summary>
        /// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        /// <param name="stockSubttlPrice">仕入金額小計</param>
        /// <returns>更新用在庫調整データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入データ、グリッドメイン(更新情報)データを元に更新用在庫調整データを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        // 2010/11/01 >>>
        //private StockAdjustWork CreateStockAdjustWork(GridMainDataSet.GridMainTableRow mainRow)
        private StockAdjustWork CreateStockAdjustWork(GridMainDataSet.GridMainTableRow mainRow, long stockSubttlPrice)
        // 2010/11/01 <<<
        {
            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            StockSlipWork stockSlipWork = (StockSlipWork)this._stockSlipWorkHTable[mainRow.SupplierSlipNo.ToString()];

            stockAdjustWork.CreateDateTime = DateTime.MinValue;                         // 作成日時                     [初期化]
            stockAdjustWork.UpdateDateTime = DateTime.MinValue;                         // 更新日時                     [初期化]
            stockAdjustWork.EnterpriseCode = this._enterpriseCode;                      // 企業コード
            stockAdjustWork.FileHeaderGuid = Guid.Empty;                                // GUID                         [初期化]
            stockAdjustWork.UpdEmployeeCode = string.Empty;                             // 更新従業員コード             [初期化]
            stockAdjustWork.UpdAssemblyId1 = string.Empty;                              // 更新アセンブリID1            [初期化]
            stockAdjustWork.UpdAssemblyId2 = string.Empty;                              // 更新アセンブリID2            [初期化]
            stockAdjustWork.LogicalDeleteCode = 0;                                      // 論理削除区分                 [初期化]
            stockAdjustWork.SectionCode = stockSlipWork.SectionCode;	                // 拠点コード                   [計上元の拠点コード]
            stockAdjustWork.StockAdjustSlipNo = 0;                                      // 在庫調整伝票番号             [初期化]
            stockAdjustWork.AcPaySlipCd = 13;                                           // 受払元伝票区分               [13：在庫仕入]
            stockAdjustWork.AcPayTransCd = 30;                                          // 受払元取引区分               [30：在庫数調整]
            stockAdjustWork.AdjustDate = DateTime.Today;                                // 調整日付
            stockAdjustWork.InputDay = DateTime.Today;	                                // 入力日付
            stockAdjustWork.StockSectionCd = stockSlipWork.StockSectionCd;	            // 仕入拠点コード               [計上元の仕入拠点コード]
            stockAdjustWork.StockInputCode = stockSlipWork.StockInputCode;	            // 仕入入力者コード             [計上元の仕入入力者コード]
            stockAdjustWork.StockInputName = stockSlipWork.StockInputName;	            // 仕入入力者名称               [計上元の仕入入力者名称]
            stockAdjustWork.StockAgentCode = stockSlipWork.StockAgentCode;	            // 仕入担当者コード             [計上元の仕入担当者コード]
            stockAdjustWork.StockAgentName = stockSlipWork.StockAgentName;	            // 仕入担当者名称               [計上元の仕入担当者名称]
            // 2010/11/01 >>>
            //stockAdjustWork.StockSubttlPrice = stockSlipWork.StockSubttlPrice;	        // 仕入金額小計                 [計上元の仕入金額小計]
            stockAdjustWork.StockSubttlPrice = stockSubttlPrice;                        // 仕入金額小計                 [計上元の仕入金額小計]
            // 2010/11/01 <<<
            stockAdjustWork.SlipNote = string.Empty;                                    // 伝票備考                     [初期化]

            return stockAdjustWork;
        }
        #endregion

        #region ▼CreateStockAdjustDtlWork(更新用在庫調整明細データ作成)
        /// <summary>
        /// 更新用在庫調整明細データ作成
        /// </summary>
        /// <param name="mainRow">グリッドメイン(更新情報)データ</param>
        /// <returns>更新用在庫調整明細データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入明細データ、UOE発注データ、グリッドメイン(更新情報)データを元に更新用在庫調整明細データを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        private StockAdjustDtlWork CreateStockAdjustDtlWork(GridMainDataSet.GridMainTableRow mainRow)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            StockDetailWork stockDetailWork = (StockDetailWork)this._stockDetailWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // 仕入明細データ
            //UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[mainRow.StockSlipDtlNumSrc.ToString()];  // UOE発注データ  // DEL 李占川 2013/05/16 Redmine#35459
            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            string uoeOrderDtlKey = this.GetOrderDtlKey(mainRow.StockSlipDtlNumSrc.ToString(), mainRow.SlipNo);
            UOEOrderDtlWork uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey];  // UOE発注データ
            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<<

            stockAdjustDtlWork.CreateDateTime = DateTime.MinValue;                      // 作成日時                     [初期化]
            stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;                      // 更新日時                     [初期化]
            stockAdjustDtlWork.EnterpriseCode = this._enterpriseCode;                   // 企業コード
            stockAdjustDtlWork.FileHeaderGuid = Guid.Empty;                             // GUID                         [初期化]
            stockAdjustDtlWork.UpdEmployeeCode = string.Empty;                          // 更新従業員コード             [初期化]
            stockAdjustDtlWork.UpdAssemblyId1 = string.Empty;                           // 更新アセンブリID1            [初期化]
            stockAdjustDtlWork.UpdAssemblyId2 = string.Empty;                           // 更新アセンブリID2            [初期化]
            stockAdjustDtlWork.LogicalDeleteCode = 0;                                   // 論理削除区分                 [初期化]
            stockAdjustDtlWork.SectionCode = stockDetailWork.SectionCode;	            // 拠点コード                   [計上元の拠点コード]
            stockAdjustDtlWork.StockAdjustSlipNo = 0;	                                // 在庫調整伝票番号             [初期化]
            //stockAdjustDtlWork.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc;	// 仕入形式(元)                 [計上元の仕入形式]          //DEL 2009/01/14
            //stockAdjustDtlWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc;	// 仕入明細通番(元)             [計上元の仕入明細通番]  //DEL 2009/01/14
            stockAdjustDtlWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;	    // 仕入形式(元)                 [計上元の仕入形式]          //ADD 2009/01/14
            stockAdjustDtlWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;	// 仕入明細通番(元)             [計上元の仕入明細通番]      //ADD 2009/01/14
            // 2010/11/01 >>>
            //stockAdjustDtlWork.AcPaySlipCd = stockDetailWork.StockSlipCdDtl;	        // 受払元伝票区分               [計上元の仕入伝票区分]
            //stockAdjustDtlWork.AcPayTransCd = 10;	                                    // 受払元取引区分               [10：通常伝票]
            stockAdjustDtlWork.AcPaySlipCd = 13;                                        // 受払元伝票区分               [13:在庫仕入]
            stockAdjustDtlWork.AcPayTransCd = 30;	                                    // 受払元取引区分               [30:在庫数調整]
            // 2010/11/01 <<<
            stockAdjustDtlWork.AdjustDate = DateTime.Today;	                            // 調整日付
            stockAdjustDtlWork.InputDay = DateTime.Today;	                            // 入力日付
            stockAdjustDtlWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;	            // 商品メーカーコード           [計上元の商品メーカーコード]
            stockAdjustDtlWork.MakerName = stockDetailWork.MakerName;	                // メーカー名称                 [計上元のメーカー名称]
            stockAdjustDtlWork.GoodsNo = stockDetailWork.GoodsNo;	                    // 商品番号                     [計上元の商品番号]
            stockAdjustDtlWork.GoodsName = stockDetailWork.GoodsName;	                // 商品名称                     [計上元の商品名称]
            stockAdjustDtlWork.StockUnitPriceFl = mainRow.InputAnswerSalesUnitCost;	    // 仕入単価(税抜,浮動)          [画面の入力値(原単価)]
            stockAdjustDtlWork.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;	// 変更前仕入単価(浮動)         [計上元の変更前仕入単価(浮動)]
            stockAdjustDtlWork.AdjustCount = mainRow.InputEnterCnt;	                    // 調整数                       [画面の入力値(入庫)]
            stockAdjustDtlWork.DtlNote = string.Empty;	                                // 明細備考                     [初期化]
            stockAdjustDtlWork.WarehouseCode = stockDetailWork.WarehouseCode;	        // 倉庫コード                   [計上元の倉庫コード]
            stockAdjustDtlWork.WarehouseName = stockDetailWork.WarehouseName;	        // 倉庫名称                     [計上元の倉庫名称]
            stockAdjustDtlWork.BLGoodsCode = stockDetailWork.BLGoodsCode;	            // BL商品コード                 [計上元のBL商品コード]
            stockAdjustDtlWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;	    // BL商品コード名称(全角)       [計上元のBL商品コード名称(全角)]
            stockAdjustDtlWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;	    // 倉庫棚番                     [計上元の倉庫棚番]
            stockAdjustDtlWork.ListPriceFl = uoeOrderDtlWork.AnswerListPrice;	        // 定価(浮動)                   [UOE発注データの回答定価]
            //stockAdjustDtlWork.OpenPriceDiv = 0;	                                    // オープン価格区分             [0：通常] //DEL chenw 2013/03/07 Redmine#34989
            // ------ ADD chenw 2013/03/07 Redmine#34989 ------------>>>>>
            if (OPENFLAG.Equals(uoeOrderDtlWork.LineErrorMassage.Trim()))
            {
                stockAdjustDtlWork.OpenPriceDiv = 1;
            }
            else
            {
                stockAdjustDtlWork.OpenPriceDiv = 0;
            }
            // ------ ADD chenw 2013/03/07 Redmine#34989 ------------<<<<<
            // 	仕入金額(税抜き)
            stockAdjustDtlWork.StockPriceTaxExc = (long)Math.Round(stockAdjustDtlWork.StockUnitPriceFl * stockAdjustDtlWork.AdjustCount,0);
            
            return stockAdjustDtlWork;
        }
        #endregion

        // UOE発注データ作成関連
        #region ▼CreateUOEOrderDtlWorkList(更新用UOE発注データ作成)
        /// <summary>
        /// 更新用UOE発注データ作成
        /// </summary>
        /// <returns>更新用UOE発注データ</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データのうち更新フラグが立っているものを抽出します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
//        private ArrayList CreateUOEOrderDtlWorkList()
        private CustomSerializeArrayList CreateUOEOrderDtlWorkList()
        {
            UOEOrderDtlWork uoeOrderDtlWork = null;

            ArrayList arrayList = new ArrayList();
            CustomSerializeArrayList customArrayList = new CustomSerializeArrayList();
//            foreach(string key in this._uoeOrderDtlWorkHTable.Keys)
            for (int idx = 0; idx <= this._uoeOrderDtlWorkUpdateList.Count - 1; idx++)
            {
                //uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];

                // 更新のかかっているもののみ登録
                //if ((uoeOrderDtlWork.EnterUpdDivSec == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivBO1 == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivBO2 == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivBO3 == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivMaker == ENTERUPDDIV_ENTER) ||
                //    (uoeOrderDtlWork.EnterUpdDivEO == ENTERUPDDIV_ENTER))
                //{
                //    arrayList.Add(this._uoeOrderDtlWorkHTable[key]);
                //}
                uoeOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[this._uoeOrderDtlWorkUpdateList[idx]];

                arrayList.Add(uoeOrderDtlWork);
            }

            customArrayList.Add(arrayList);
//            return arrayList;
            return customArrayList;
        }
        #endregion

        #region ▼UpdateUOEOrderDtlWork(UOE発注データ更新)
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ----------------------------------------------------->>>>>
        /// <summary>
        /// UOE発注データ更新
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">仕入明細通番</param>
        /// <param name="columnDiv">列区分(拠点、BO1、BO2、BO3、メーカー、EO)</param>
        /// <param name="value">更新値(0：未入庫、1：入庫済)</param>
        /// <param name="guid">GUID</param>
        /// <param name="substPartsNoIsExists">代替有無(True：あり、Falseなし)</param>
        /// <remarks>
        /// <br>Note       : UOE発注データの入庫更新区分を更新します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        //private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid, bool substPartsNoIsExists)  //  DEL 李占川 2013/05/16 Redmine#35459
        private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid, bool substPartsNoIsExists, string slipNo)   //  ADD 李占川 2013/05/16 Redmine#35459
        {
            //this.UpdateUOEOrderDtlWork(stockSlipDtlNumSrc, columnDiv, value, guid);        //  DEL 李占川 2013/05/16 Redmine#35459
            this.UpdateUOEOrderDtlWork(stockSlipDtlNumSrc, columnDiv, value, guid, slipNo);  //  ADD 李占川 2013/05/16 Redmine#35459
            if (substPartsNoIsExists)
            {
                //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).DtlRelationGuid = Guid.Empty;  // DEL 李占川 2013/05/16 Redmine#35459
                // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
                string uoeOrderDtlKey = this.GetOrderDtlKey(stockSlipDtlNumSrc.ToString(), slipNo);
                ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).DtlRelationGuid = Guid.Empty;
                // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            }
        }
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] -----------------------------------------------------<<<<<

        /// <summary>
        /// UOE発注データ更新
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">仕入明細通番</param>
        /// <param name="columnDiv">列区分(拠点、BO1、BO2、BO3、メーカー、EO)</param>
        /// <param name="value">更新値(0：未入庫、1：入庫済)</param>
        /// <param name="guid">GUID</param>
        /// <remarks>
        /// <br>Note       : UOE発注データの入庫更新区分を更新します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        //private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid)                // DEL 李占川 2013/05/16 Redmine#35459
        private void UpdateUOEOrderDtlWork(long stockSlipDtlNumSrc, string columnDiv, int value, Guid guid, string slipNo)   // ADD 李占川 2013/05/16 Redmine#35459
        {
            string uoeOrderDtlKey = this.GetOrderDtlKey(stockSlipDtlNumSrc.ToString(), slipNo); // ADD 李占川 2013/05/16 Redmine#35459

            // HashTableに無い場合は処理しない
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)  // DEL 李占川 2013/05/16 Redmine#35459
            if (this._uoeOrderDtlWorkHTable.ContainsKey(uoeOrderDtlKey) == false)                   // ADD 李占川 2013/05/16 Redmine#35459
            {
                return;
            }

            // GUID
            if (guid != Guid.Empty)
            {
                //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).DtlRelationGuid = guid; // DEL 李占川 2013/05/16 Redmine#35459
                ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).DtlRelationGuid = guid;                  // ADD 李占川 2013/05/16 Redmine#35459
            }

            switch (columnDiv)
            {
                case PMUOE01203AA.COLUMNDIV_SECTION:
                    {
                        // 入庫更新区分(拠点)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivSec = value; // DEL 李占川 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivSec = value;                  // ADD 李占川 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_BO1:
                    {
                        // 入庫更新区分(BO1)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivBO1 = value; // DEL 李占川 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivBO1 = value;                  // ADD 李占川 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_BO2:
                    {
                        // 入庫更新区分(BO2)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivBO2 = value; // DEL 李占川 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivBO2 = value;                  // ADD 李占川 2013/05/16 Redmine#35459
                        break;      
                    }
                case PMUOE01203AA.COLUMNDIV_BO3:
                    {
                        // 入庫更新区分(BO3)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivBO3 = value; // DEL 李占川 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivBO3 = value;                  // ADD 李占川 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_MAKER:
                    {
                        // 入庫更新区分(メーカー)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivMaker = value;   // DEL 李占川 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivMaker = value;                    // ADD 李占川 2013/05/16 Redmine#35459
                        break;
                    }
                case PMUOE01203AA.COLUMNDIV_EO:
                    {
                        // 入庫更新区分(EO)
                        //((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()]).EnterUpdDivEO = value;      // DEL 李占川 2013/05/16 Redmine#35459
                        ((UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[uoeOrderDtlKey]).EnterUpdDivEO = value;                       // ADD 李占川 2013/05/16 Redmine#35459
                        break;
                    }
                default:
                    return;
            }

            if (this._uoeOrderDtlWorkUpdateList == null)
            {
                this._uoeOrderDtlWorkUpdateList = new List<string>();
            }

            //if (this._uoeOrderDtlWorkUpdateList.Contains(stockSlipDtlNumSrc.ToString()) == false)     // DEL 李占川 2013/05/16 Redmine#35459
            if (this._uoeOrderDtlWorkUpdateList.Contains(uoeOrderDtlKey) == false)                      // ADD 李占川 2013/05/16 Redmine#35459
            {
                //this._uoeOrderDtlWorkUpdateList.Add(stockSlipDtlNumSrc.ToString() + slipNo);          // DEL 李占川 2013/05/16 Redmine#35459
                this._uoeOrderDtlWorkUpdateList.Add(uoeOrderDtlKey);                                    // ADD 李占川 2013/05/16 Redmine#35459
            }


        }
        #endregion

        // HashTableデータ取得
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------->>>>>
        #region ▼GetUOEOrderDtlWork(UOE発注データ取得)
        /// <summary>
        /// UOE発注データ取得
        /// </summary>
        /// <param name="stockSlipDtlNumSrc">仕入明細通番</param>
        /// <returns>UOE発注データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入明細通番を元にHashTableからUOE発注データを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/02/17</br>
        /// <br>UpdateNote : 2013/05/16 李占川</br>
        /// <br>管理番号   : 10801804-00 2013/06/18配信分</br>
        /// <br>              Redmine#35459 #42の対応</br>
        /// </remarks>
        //private UOEOrderDtlWork GetUOEOrderDtlWork(long stockSlipDtlNumSrc)  // DEL 李占川 2013/05/16 Redmine#35459
        private UOEOrderDtlWork GetUOEOrderDtlWork(long stockSlipDtlNumSrc, string slipNo)  // ADD 李占川 2013/05/16 Redmine#35459
        {
            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            //if (this._uoeOrderDtlWorkHTable.ContainsKey(stockSlipDtlNumSrc.ToString()) == false)
            //{
            //    return null;
            //}

            //return (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[stockSlipDtlNumSrc.ToString()];
            // ------------DEL 李占川 2013/05/16 FOR Redmine#35459---------<<<<

            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
            string key = this.GetOrderDtlKey(stockSlipDtlNumSrc.ToString(), slipNo);
            if (this._uoeOrderDtlWorkHTable.ContainsKey(key) == false)
            {
                return null;
            }

            return (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
            // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<
        }
        #endregion
        // ---ADD 2009/02/17 不具合対応[10140][10177][10529] ---------------------------------------<<<<<

        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459--------->>>>
        /// <summary>
        /// キーの判断
        /// </summary>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <param name="slipNo">伝票番号</param>
        /// <returns>キー</returns>
        /// <remarks>
        /// <br>Note       : キーを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/16</br>
        /// </remarks>
        private string GetOrderDtlKey(string stockSlipDtlNum, string slipNo)
        {
            // 明治産業時
            if (_meiJiDiv)
            {
                int slipNoInt = 0;
                Int32.TryParse(slipNo, out slipNoInt);
                return stockSlipDtlNum + slipNoInt.ToString().PadLeft(6, '0');
            }
            else
            {
                return stockSlipDtlNum;
            }
        }

        /// <summary>
        /// UOE発注データ取得
        /// </summary>
        /// <param name="uoeOrderDtlWorkHTable">HashTable</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <returns>UOE発注データ</returns>
        /// <remarks>
        /// <br>Note       : 仕入明細通番を元にHashTableからUOE発注データを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/05/16</br>
        /// </remarks>
        private UOEOrderDtlWork GetUOEOrderDtlWorkFromTable(Hashtable uoeOrderDtlWorkHTable, long stockSlipDtlNum)
        {
            UOEOrderDtlWork uOEOrderDtlWork = null;

            foreach (string key in _uoeOrderDtlWorkHTable.Keys)
            {
                // 元明細通番を使用
                string newStockSlipDtlNum = string.Empty;
                
                if (_meiJiDiv)
                {
                    // 明治産業時
                    newStockSlipDtlNum = key.Substring(0, key.Length - 6);
                }
                else
                {
                    newStockSlipDtlNum = key;
                }
                 
                if (newStockSlipDtlNum.Equals(stockSlipDtlNum.ToString()))
                {
                    uOEOrderDtlWork = (UOEOrderDtlWork)this._uoeOrderDtlWorkHTable[key];
                    break;
                }
            }

            return uOEOrderDtlWork;
        }
        // ------------ADD 李占川 2013/05/16 FOR Redmine#35459---------<<<<

        // ===================================================================================== //
        // クラス
        // ===================================================================================== //
        #region ◎仕入データ情報貯め込み用クラス
        /// <summary>
        /// 仕入データ情報貯め込み用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ①更新後仕入データの「仕入金額合計」「仕入金額」「明細行数」はこのクラス内で求める</br>
        /// <br>             ②更新後仕入明細データの「仕入行番号」はこのクラス内で求める</br>
        /// <br>             ③更新後仕入明細、仕入明細付加データの「明細関連付けGUID」は引き渡された値をこのクラス内でセットする</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private class StockSlipListInfo
        {
            #region ▼変数
            // 代替品用情報
            private CustomSerializeArrayList _stockSlipBfList = null;   // 代替品更新データ群
            private StockSlipWork _stockSlipWorkBf = null;              //  L更新前仕入(代替品番更新用)     ←プロパティで渡される
            private ArrayList _stockDetailWorkBfList = null;            //  L更新前仕入明細リスト(代替品番更新用)
            // StockDetailWork型                                        //    L更新前仕入明細　←プロパティで渡され、リストに格納

            // 発注計上仕入用情報
            private CustomSerializeArrayList _stockSlipList = null;     // 発注計上仕入群(仕入伝票番号単位)
            private StockSlipWork _stockSlipWork = null;                //  L仕入                           ←プロパティで渡される
            private ArrayList _stockDetailWorkList = null;              //  L仕入明細リスト
            // StockDetailWork型                                        //    L仕入明細　　　　←プロパティで渡され、リストに格納
            private ArrayList _slipDetailAddInfoWorkList = null;        //  L明細付加情報リスト
            // SlipDetailAddInfoWork型                                  //    L明細付加情報　　←プロパティで渡され、リストに格納

            // その他変数
            private long _stockTotalPrice = 0;                          // 明細の仕入金額(税抜き)の合計
            private long _stockSubttlPrice = 0;                         // 明細の仕入金額(税込み)の合計
            private Guid _dtlRelationGuid = Guid.Empty;                 // 明細関連付けGUID

            private Hashtable _slipDetailAddInfoHTable = new Hashtable();       //ADD 2009/02/17 不具合対応[10140][10177][10529]
            private Hashtable _stockDetailWorkHTable = new Hashtable();         //ADD 2009/02/17 不具合対応[10140][10177][10529]
            #endregion

            #region ▼コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public StockSlipListInfo()
            {
                this.InitializeItem();          // 発注計上用仕入情報初期化
                this.InitializeBfItem();        // 代替品用仕入情報初期化
            }
            #endregion

            // プロパティ
            #region ▼プロパティ(Get)
            /// <summary> 発注計上仕入群 </summary>
            public CustomSerializeArrayList StockSlipList { get { return this.GetStockSlipList(); } }
            /// <summary> 代替品更新データ群 </summary>
            public CustomSerializeArrayList StockSlipBfList { get { return this.GetStockSlipBfList(); } }
            /* ---DEL 2009/02/17 不具合対応[10140][10177][10529] -------------------------------------------------------------->>>>>
            /// <summary> 代替品更新データ群存在フラグ(True：代替品あり、False：代替品なし) </summary>
            public bool StockDetailWorkBfListDataIsExists { get { return this._stockDetailWorkBfList.Count != 0 ? true : false; } }
               ---DEL 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------------------------------<<<<< */
            /// <summary> 仕入明細リスト </summary>
            public List<StockDetailWork> StockDetailWorkList { get { return this.GetStockDetailWorkList(); } }
            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] -------------------------------------------------------------->>>>>
            public List<StockDetailWork> StockDetailWorkBfList { get { return this.GetStockDetailWorkBfList(); } }
            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------------------------------<<<<<
            #endregion

            #region ▼プロパティ(Set)
            /// <summary> 仕入データ </summary>
            public StockSlipWork StockSlipWork { set { this._stockSlipWork = value; } }
            /// <summary> 仕入明細データ </summary>
            public StockDetailWork StockDetailWork { set { this.AddStockDetailWorkList(value); } }
            /// <summary> 仕入明細付加情報 </summary>
            public SlipDetailAddInfoWork SlipDetailAddInfoWork { set { this.AddSlipDetailAddInfoWorkList(value); } }
            /// <summary> 更新前仕入データ </summary>
            public StockSlipWork StockSlipWorkBf { set { this._stockSlipWorkBf = value; } }
            /// <summary> 更新前仕入明細データ </summary>
            public StockDetailWork StockDetailWorkBf { set { this._stockDetailWorkBfList.Add(value); } }
            #endregion

            #region ▼プロパティ(Get、Set)
            /// <summary> 明細関連付けGUID </summary>
            public Guid DtlRelationGuid
            {
                get { return this._dtlRelationGuid; }
                set { this._dtlRelationGuid = value; }
            }
            #endregion

            // パブリックメソッド
            #region ▼ClearItem(取得アイテムの初期化)
            /// <summary>
            /// 取得アイテムの初期化
            /// </summary>
            /// <remarks>
            /// <br>Note       : これまでに貯め込んだアイテムを初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public void ClearItem()
            {
                // 発注計上用仕入情報初期化
                this.InitializeItem();

                /* ---DEL 2009/02/17 不具合対応[10140][10177][10529] --------------->>>>>
                // 代替品用仕入情報初期化
                if (this.StockDetailWorkBfListDataIsExists)
                {
                    this.InitializeBfItem();
                }
                   ---DEL 2009/02/17 不具合対応[10140][10177][10529] ---------------<<<<< */
                this.InitializeBfItem();        //ADD 2009/02/17
            }
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885----->>>>>
            /// <summary>
            /// 取得アイテムの初期化
            /// </summary>
            /// <remarks>
            /// <br>Note       : これまでに貯め込んだアイテムを初期化します。</br>
            /// <br>Programmer : 鄧潘ハン</br>
            /// <br>Date       : 2009/02/17</br>
            /// <br>管理番号   : 10801804-00 20120912配信分</br>
            /// <br>             redmine #31885:吉田商会　在庫入庫更新処理の対応</br>
            /// <br>             同一のオンライン番号であっても異なる仕入伝票に生成されてしまうの障害の対応</br>
            /// </remarks>
            public void ClearBfItem()
            {
                this.InitializeBfItem();      
            }
            // ----- ADD 2012/08/30 鄧潘ハン  redmine#31885-----<<<<<
            #endregion


            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] -------------------------------------------------------------->>>>>
            public SlipDetailAddInfoWork GetSlipDetailAddInfoWork(Guid guid)
            {
                if (guid == Guid.Empty)
                {
                    return null;
                }

                return (SlipDetailAddInfoWork)this._slipDetailAddInfoHTable[guid];
            }
            public StockDetailWork GetStockDetailWork(Guid guid)
            {
                if (guid == Guid.Empty)
                {
                    return null;
                }

                return (StockDetailWork)this._stockDetailWorkHTable[guid];
            }
            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------------------------------<<<<<

            // プライベートメソッド
            #region ▼InitializeItem(発注計上用仕入情報初期化)
            /// <summary>
            /// 発注計上用仕入情報初期化
            /// </summary>
            /// <remarks>
            /// <br>Note       : 発注計上用仕入情報を初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void InitializeItem()
            {
                // 初期化
                this._stockSlipList = new CustomSerializeArrayList();       // 発注計上仕入群(仕入伝票番号単位)
                this._stockSlipWork = new StockSlipWork();                  //  L仕入
                this._stockDetailWorkList = new ArrayList();                //  L仕入明細リスト
                                                                            //    L仕入明細
                this._slipDetailAddInfoWorkList = new ArrayList();          //  L明細付加情報リスト
                                                                            //    L明細付加情報
                this._stockTotalPrice = 0;
                this._stockSubttlPrice = 0;

                this._stockDetailWorkHTable = new Hashtable();      //ADD 2009/02/17 不具合対応[10140][10177][10529]
                this._slipDetailAddInfoHTable = new Hashtable();    //ADD 2009/02/17 不具合対応[10140][10177][10529]
            }
            #endregion

            #region ▼InitializeBfItem(代替品用仕入情報初期化)
            /// <summary>
            /// 代替品用仕入情報初期化
            /// </summary>
            /// <remarks>
            /// <br>Note       : 代替品用仕入情報を初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void InitializeBfItem()
            {
                // 初期化
                this._stockSlipBfList = new CustomSerializeArrayList();     // 代替品更新データ群
                this._stockSlipWorkBf = new StockSlipWork();                //  L更新前仕入(代替品番更新用)
                this._stockDetailWorkBfList = new ArrayList();              //  L更新前仕入明細リスト(代替品番更新用)
                                                                            //    L更新前仕入明細
            }
            #endregion

            #region ▼GetStockSlipList(発注計上仕入群取得)
            /// <summary>
            /// 発注計上仕入群取得
            /// </summary>
            /// <returns>発注計上仕入群(貯め込んだデータを収集したもの)</returns>
            /// <remarks>
            /// <br>Note       : 貯め込んだ仕入、仕入明細リスト、明細付加情報リストを元に発注計上仕入群を作成して返します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private CustomSerializeArrayList GetStockSlipList()
            {
                this._stockSlipList.Add(this._stockSlipWork);
                this._stockSlipList.Add(this._stockDetailWorkList);
                this._stockSlipList.Add(this._slipDetailAddInfoWorkList);

                return this._stockSlipList;
            }
            #endregion

            #region ▼GetStockSlipBfList(代替品更新データ群取得)
            /// <summary>
            /// 代替品更新データ群取得
            /// </summary>
            /// <returns>代替品更新データ群(貯め込んだデータを収集したもの)</returns>
            /// <remarks>
            /// <br>Note       : 貯め込んだ更新前仕入、更新前仕入明細リストを元に代替品更新データ群を作成して返します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private CustomSerializeArrayList GetStockSlipBfList()
            {
                this._stockSlipBfList.Add(this._stockSlipWorkBf);
                this._stockSlipBfList.Add(this._stockDetailWorkBfList);

                return this._stockSlipBfList;
            }
            #endregion

            #region ▼GetStockDetailWorkList(仕入明細リスト取得)
            /// <summary>
            /// 仕入明細リスト取得
            /// </summary>
            /// <returns>型変換された仕入明細リスト</returns>
            /// <remarks>
            /// <br>Note       : 貯め込んだArrayList型の仕入明細をListくStockDetailWork>型に変換して戻します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private List<StockDetailWork> GetStockDetailWorkList()
            {
                // 型変換：ArrayList→List<StockDetailWork>
                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                for (int idx = 0; idx <= this._stockDetailWorkList.Count - 1; idx++)
                {
                    stockDetailWorkList.Add((StockDetailWork)this._stockDetailWorkList[idx]);
                }

                return stockDetailWorkList;
            }
            #endregion

            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] -------------------------------------------------------------->>>>>
            #region ▼GetStockDetailWorkBfList(仕入明細リスト取得)
            /// <summary>
            /// 仕入明細リスト取得
            /// </summary>
            /// <returns>型変換された仕入明細リスト</returns>
            /// <remarks>
            /// <br>Note       : 貯め込んだArrayList型の仕入明細をListくStockDetailWork>型に変換して戻します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private List<StockDetailWork> GetStockDetailWorkBfList()
            {
                // 型変換：ArrayList→List<StockDetailWork>
                List<StockDetailWork> stockDetailWorkBfList = new List<StockDetailWork>();
                for (int idx = 0; idx <= this._stockDetailWorkBfList.Count - 1; idx++)
                {
                    stockDetailWorkBfList.Add((StockDetailWork)this._stockDetailWorkBfList[idx]);
                }

                return stockDetailWorkBfList;
            }
            #endregion
            // ---ADD 2009/02/17 不具合対応[10140][10177][10529] --------------------------------------------------------------<<<<<

            #region ▼AddStockDetailWorkList(仕入明細追加)
            /// <summary>
            /// 仕入明細追加
            /// </summary>
            /// <param name="stockDetailWork">仕入明細</param>
            /// <remarks>
            /// <br>Note       : 仕入明細にGUID、行番号を付加して仕入明細リストへの追加を行います。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void AddStockDetailWorkList(StockDetailWork stockDetailWork)
            {
                this._stockTotalPrice = this._stockTotalPrice + stockDetailWork.StockPriceTaxExc;
                this._stockSubttlPrice = this._stockSubttlPrice + stockDetailWork.StockPriceTaxInc;

                // 行番号を採番(伝票単位に1から開始)
                stockDetailWork.StockRowNo = this._stockDetailWorkList.Count + 1;

                // 明細関連付けGUID
                stockDetailWork.DtlRelationGuid = this._dtlRelationGuid;

                this._stockDetailWorkList.Add(stockDetailWork);
                this._stockDetailWorkHTable.Add(stockDetailWork.DtlRelationGuid, stockDetailWork);
            }
            #endregion

            #region ▼AddSlipDetailAddInfoWorkList(明細付加情報追加)
            /// <summary>
            /// 明細付加情報追加
            /// </summary>
            /// <param name="slipDetailAddInfoWork">明細付加情報</param>
            /// <remarks>
            /// <br>Note       : 明細付加情報にGUID、番号を付加して明細付加情報リストへの追加を行います。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void AddSlipDetailAddInfoWorkList(SlipDetailAddInfoWork slipDetailAddInfoWork)
            {
                // 明細関連付けGUID
                slipDetailAddInfoWork.DtlRelationGuid = this._dtlRelationGuid;

                // 番号を採番(●●単位に1から開始)
                slipDetailAddInfoWork.SlipDtlRegOrder = this._slipDetailAddInfoWorkList.Count + 1;

                this._slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                this._slipDetailAddInfoHTable.Add(slipDetailAddInfoWork.DtlRelationGuid, slipDetailAddInfoWork);        //ADD 2009/02/17 不具合対応[10140][10177][10529]
            }
            #endregion
        }
        #endregion

        #region ◎在庫調整データ情報貯め込み用クラス
        /// <summary>
        /// 在庫調整データ情報貯め込み用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ①在庫調整明細データの「行番号」はこのクラス内で求める</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private class StockAdjustListInfo
        {
            #region ▼変数
            // 在庫調整用情報
            CustomSerializeArrayList _stockAdjustList = null;   // 在庫調整データ群
            ArrayList _stockAdjustWorkList = null;              //  L在庫調整リスト
            // StockAdjustWork型                                //    L在庫調整　　　←プロパティで渡され、リストに格納
            ArrayList _stockAdjustDtlWorkList = null;           //  L在庫調整明細リスト
            // StockAdjustDtlWork型                             //    L在庫調整明細　←プロパティで渡され、リストに格納
            #endregion

            #region ▼コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public StockAdjustListInfo()
            {
                this.InitializeItem();          // 在庫調整用情報初期化
            }
            #endregion

            // プロパティ
            #region ▼プロパティ(Get)
            /// <summary> 在庫調整データ群 </summary>
            public CustomSerializeArrayList StockAdjustList { get {return this.GetStockAdjustList(); } }
            /// <summary> 明細件数 </summary>
            public int StockAdjustDtlCount { get { return this._stockAdjustDtlWorkList.Count; } }
            #endregion

            #region ▼プロパティ(Set)
            /// <summary> 在庫調整データ </summary>
            public StockAdjustWork StockAdjustWork { set { this._stockAdjustWorkList.Add(value); } }
            /// <summary> 在庫調整明細データ </summary>
            public StockAdjustDtlWork StockAdjustDtlWork { set { this.AddStockAdjustDtlWork(value); } }
            #endregion

            // パブリックメソッド
            #region ▼ClearItem(取得アイテムの初期化)
            /// <summary>
            /// 取得アイテムの初期化
            /// </summary>
            /// <remarks>
            /// <br>Note       : これまでに貯め込んだアイテムを初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            public void ClearItem()
            {
                // 在庫調整用情報初期化
                this.InitializeItem();
            }
            #endregion

            // プライベートメソッド
            #region ▼InitializeItem(在庫調整用情報初期化)
            /// <summary>
            /// 在庫調整用情報初期化
            /// </summary>
            /// <remarks>
            /// <br>Note       : 在庫調整用情報を初期化します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void InitializeItem()
            {
                // 初期化
                this._stockAdjustList = new CustomSerializeArrayList();     // 在庫調整データ群
                this._stockAdjustWorkList = new ArrayList();                //  L在庫調整リスト
                                                                            //    L在庫調整
                this._stockAdjustDtlWorkList = new ArrayList();             //  L在庫調整明細リスト
                                                                            //    L在庫調整明細
            }
            #endregion

            #region ▼GetStockAdjustList(在庫調整データ群取得)
            /// <summary>
            /// 在庫調整データ群取得
            /// </summary>
            /// <returns>在庫調整データ群(貯め込んだデータを収集したもの)</returns>
            /// <remarks>
            /// <br>Note       : 貯め込んだ在庫調整リスト、在庫調整明細リストを元に在庫調整データ群を作成して返します。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private CustomSerializeArrayList GetStockAdjustList()
            {
                this._stockAdjustList.Add(this._stockAdjustWorkList);
                this._stockAdjustList.Add(this._stockAdjustDtlWorkList);

                return this._stockAdjustList;
            }
            #endregion

            #region ▼AddStockAdjustDtlWork(在庫調整明細追加)
            /// <summary>
            /// 在庫調整明細追加
            /// </summary>
            /// <param name="stockAdjustDtlWork">在庫調整明細</param>
            /// <remarks>
            /// <br>Note       : 在庫調整明細に行番号を付加して在庫調整明細リストへの追加を行います。</br>
            /// <br>Programmer : 照田 貴志</br>
            /// <br>Date       : 2008/09/04</br>
            /// </remarks>
            private void AddStockAdjustDtlWork(StockAdjustDtlWork stockAdjustDtlWork)
            {
                // 行番号を採番(伝票単位に1から開始)
                stockAdjustDtlWork.StockAdjustRowNo = this._stockAdjustDtlWorkList.Count + 1;

                this._stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
            }
            #endregion
        }
        #endregion
    }
}