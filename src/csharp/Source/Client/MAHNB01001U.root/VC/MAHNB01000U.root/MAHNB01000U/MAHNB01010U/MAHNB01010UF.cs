using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 列表示状態クラスコレクションクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列表示状態クラスのコレクションクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// </remarks>
    internal class ColDisplayStatusList
    {

        #region Constructor
        /// <summary>
        /// 列表示状態クラスコレクションクラスコンストラクタ
        /// </summary>
        /// <param name="colDisplayStatusList">ColDisplayStatusクラスリストのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスコレクションクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public ColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable)
        {
            // 各種インスタンス化
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusKeyList = new List<string>();
            this._salesDetailDataTable = salesDetailDataTable;

            // 初期列表示状態リスト生成
            List<ColDisplayStatusExp> initStatusList = new List<ColDisplayStatusExp>();

            int visiblePosition = 0;

            // 上下１段
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName, visiblePosition++, true, 44, 2, 0, 0, 44, 4, "", "",false,false,false));                                                    // №

            // 上段
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, 73, 2, 44, 0, 73, 2, "GoodsNo", "GoodsName", true, false, false));                                                         // BLコード
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, 430, 2, 117, 0, 430, 2, "GoodsNo", "AcceptAnOrderCntDisplay", true, false, false));                                          // 品名
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, visiblePosition++, true, 90, 2, 547, 0, 90, 2, "ShipmentCntDisplay", "ShipmentCntDisplay", true, false, true));                         // 受注数
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesCodeColumn.ColumnName, visiblePosition++, true, 140, 2, 637, 0, 140, 2, "ListPriceDisplay", "ListPriceDisplay", true, true, true));                                          // 販売区分         // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.CostRateColumn.ColumnName, visiblePosition++, true, 70, 2, 777, 0, 70, 2, "SalesRate", "SalesUnitCost", true, true, true));                                                       // 仕入率           // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, visiblePosition++, true, 140, 2, 847, 0, 140, 2, "SalesUnPrcDisplay", "SalesRate", true, true, true));                                            // 原単価           // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DummyColumn.ColumnName, visiblePosition++, true, 130, 2, 987, 0, 130, 2, "SalesMoneyDisplay", "WarehouseCode", true, false, false));                                              // ダミー           // 切替項目(基本) 基本幅合計480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DtlNoteColumn.ColumnName, visiblePosition++, true, 405, 2, 1117, 0, 400, 2, "PartySlipNumDtl", "PartySlipNumDtl", true, true, true));                                             // 備考             // 切替項目(切替) 補正+5
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, visiblePosition++, true, 84, 2, 1517, 0, 80, 2, "DeliGdsCmpltDueDate", "PartySlipNumDtl", true, true, true));                                   // 一式             // 切替項目(切替) 補正+4 切替合計480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, visiblePosition++, true, 132, 2, 1597, 0, 130, 2, "PartySalesSlipNum", "StockDate", true, true, true));                                      // 仕入先           // 切替項目(仕入) 補正+2
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.StockDateColumn.ColumnName, visiblePosition++, true, 166, 2, 1727, 0, 165, 2, "PartySalesSlipNum", "PartySalesSlipNum", true, true, true));                                       // 仕入日           // 切替項目(仕入) 補正+1 仕入合計294
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.BoCodeColumn.ColumnName, visiblePosition++, true, 40, 2, 1892, 0, 40, 2, "SupplierSnmForOrder", "SupplierCdForOrder", true, true, true));                                         // BO               // 切替項目(発注) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, visiblePosition++, true, 120, 2, 1932, 0, 120, 2, "SupplierSnmForOrder", "AcceptAnOrderCntForOrder", true, true, true));                     // 発注先           // 切替項目(発注) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, visiblePosition++, true, 60, 2, 2052, 0, 60, 2, "SupplierSnmForOrder", "SupplierSnmForOrder", true, true, true));                      // 発注数           // 切替項目(発注) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, visiblePosition++, true, 130, 2, 2112, 0, 130, 2, "UOEResvdSectionNm", "FollowDeliGoodsDivNm", true, true, true));                          // 納品区分         // 切替項目(発注) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, visiblePosition++, true, 130, 2, 2242, 0, 130, 2, "UOEResvdSectionNm", "UOEResvdSectionNm", true, true, true));                            // H納品区分        // 切替項目(発注) 発注合計480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, true, 65, 2, 2372, 0, 65, 2, "SupplierStockDisplay", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));      // 倉庫
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, true, 100, 2, 2437, 0, 100, 2, "SupplierStockDisplay", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true)); // 棚番
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SlipMemoExistColumn.ColumnName, visiblePosition++, true, 30, 2, 2537, 0, 30, 2, "SupplierSlipExist", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));         // メモイメージ
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, visiblePosition++, true, 301, 2, 1597, 0, 295, 2, "GoodsMngNo", "GoodsMngNo", true, true, true));                                                  // RC区分           // 切替項目(SCM) 補正 // 2010/02/26

            // 下段
            //initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, 273, 2, 44, 2, 273, 2, "BLGoodsCode", "GoodsKindCode", true, false, false));                                                   // 品番
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, 273, 2, 44, 2, 273, 2, "BLGoodsCode", "BLGoodsCode", true, false, false));                                                   // 品番
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName, visiblePosition++, true, 50, 2, 317, 2, 50, 2, "GoodsName", "GoodsMakerCd", true, true, true));                                                   // 商品属性(純正優良)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, true, 80, 2, 367, 2, 80, 2, "GoodsName", "BLGoodsCode", true, true, true));                                                     // メーカー
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, true, 100, 2, 447, 2, 100, 2, "GoodsName", "SalesCode", true, true, true));                                                       // 仕入先
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, visiblePosition++, true, 90, 2, 547, 2, 90, 2, "AcceptAnOrderCntDisplay", "SupplierCd", true, false, true));                                 // 出荷数
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, 110, 2, 637, 2, 110, 2, "SalesCode", "CostRate", true, true, true));                                                  // 標準価格         // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, 30, 2, 747, 2, 30, 2, "SalesCode", "CostRate", true, true, true));                                                 // オープンイメージ // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesRateColumn.ColumnName, visiblePosition++, true, 70, 2, 777, 2, 70, 2, "CostRate", "SalesUnPrcDisplay", true, true, true));                                                   // 売価率           // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, visiblePosition++, true, 140, 2, 847, 2, 140, 2, "SalesUnitCost", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));        // 売単価           // 切替項目(基本)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, visiblePosition++, true, 130, 2, 987, 2, 130, 2, "Dummy", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));                // 売上金額         // 切替項目(基本) 基本幅合計480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, visiblePosition++, true, 285, 2, 1117, 2, 280, 2, "DtlNote", "DeliGdsCmpltDueDate", true, true, true));                                         // 得意先注番       // 切替項目(切替) 補正+5
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, visiblePosition++, true, 204, 2, 1397, 2, 200, 2, "DtlNote", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));           // 納品完了予定日   // 切替項目(切替) 補正+4 切替幅合計480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, visiblePosition++, true, 298, 2, 1597, 2, 295, 2, "SupplierCdForStock", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));  // 仕入伝票番号     // 切替項目(仕入) 補正+3 仕入幅合計294
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, visiblePosition++, true, 220, 2, 1892, 2, 220, 2, "BoCode", "DeliveredGoodsDivNm", true, true, true));                                      // 発注先名称       // 切替項目(発注)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, visiblePosition++, true, 260, 2, 2112, 2, 260, 2, "DeliveredGoodsDivNm", "WarehouseCode", true, true, true));                                 // 指定拠点         // 切替項目(発注) 発注幅合計480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, visiblePosition++, true, 165, 2, 2372, 2, 165, 2, "WarehouseCode", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));    // 現在庫数
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName, visiblePosition++, true, 30, 2, 2537, 2, 30, 2, "SlipMemoExist", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));         // 仕入情報イメージ
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, visiblePosition++, true, 301, 2, 1597, 2, 295, 2, "RecycleDivNm", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));               // PS管理番号       // 切替項目(SCM) 補正 // 2010/02/26

            // 初期列表示状態リスト格納処理
            foreach (ColDisplayStatusExp initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // 列表示状態クラスリストが無効の場合は、初期列表示状態リストを設定
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    ColDisplayStatusExp colDisplayStatus = null;

                    try
                    {
                        colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
                    }
                    catch (KeyNotFoundException)
                    {
                        //
                    }

                    if (colDisplayStatus != null)
                    {
                        this._colDisplayStatusList.Add(colDisplayStatus);
                    }
                }

                // 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            else
            {
                // 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

                // 初期列表示状態リストと列表示状態クラス格納Dictionaryの値を比較し、不足分を補充する
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    if (!this.ContainsKey(colKey))
                    {
                        // 存在しなければ追加
                        ColDisplayStatusExp colDisplayStatus = null;

                        try
                        {
                            colDisplayStatus = this._colDisplayStatusInitDictionary[colKey]; // 初期列表示状態クラス格納Dicより取得
                        }
                        catch (KeyNotFoundException)
                        {
                            //
                        }

                        if (colDisplayStatus != null)
                        {
                            colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colDisplayStatus);
                        }
                    }
                    else
                    {
                        // 存在していれば初期列表示状態リストの内容で更新
                        ColDisplayStatusExp colDisplayStatusInit = null;
                        ColDisplayStatusExp colDisplayStatus = null;
                        try
                        {
                            colDisplayStatus = this._colDisplayStatusDictionary[colKey]; // 列表示状態クラス格納Dicより取得
                            colDisplayStatusInit = this._colDisplayStatusInitDictionary[colKey]; // 初期列表示状態クラス格納Dicより取得
                        }
                        catch (KeyNotFoundException)
                        {
                            //
                        }

                        if (colDisplayStatus != null)
                        {
                            colDisplayStatus.OriginX = colDisplayStatusInit.OriginX;
                            colDisplayStatus.OriginY = colDisplayStatusInit.OriginY;
                            colDisplayStatus.SpanX = colDisplayStatusInit.SpanX;
                            colDisplayStatus.SpanY = colDisplayStatusInit.SpanY;
                            colDisplayStatus.Width = colDisplayStatusInit.Width;
                        }

                    }
                }
            }

            // 表示位置によるソート処理
            this.Sort();
        }
        #endregion

        #region Private Members
        /// <summary>列表示状態クラスリスト</summary>
        private List<ColDisplayStatusExp> _colDisplayStatusList = null;

        /// <summary>列表示状態クラス格納Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusDictionary = null;

        /// <summary>初期列表示状態クラス格納Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusInitDictionary = null;

        /// <summary>列表示状態キーリスト</summary>
        private List<string> _colDisplayStatusKeyList = null;

        /// <summary>売上明細データテーブル</summary>
        SalesInputDataSet.SalesDetailDataTable _salesDetailDataTable;
        #endregion

        #region Public Methods
        /// <summary>
        /// 列表示状態キー格納判断処理
        /// </summary>
        /// <param name="key">対象列表示状態キー</param>
        /// <returns>列表示状態の有無(true:有,false:無)</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

        /// <summary>
        /// 並べ替え処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを表示位置より並べ替えます。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト取得処理
        /// </summary>
        /// <returns>ColDisplayStatusクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを取得します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public List<ColDisplayStatusExp> GetColDisplayStatusList()
        {
            // 表示位置によるソート処理
            this.Sort();

            return this._colDisplayStatusList;
        }

        /// <summary>
        /// 初期列表示状態クラス格納Dictionary取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 初期列表示状態クラス格納Dictionaryを取得します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public Dictionary<string, ColDisplayStatusExp> GetColDisplayInitDictionary()
        {
            return this._colDisplayStatusInitDictionary;
        }

        /// <summary>
        /// 列表示状態クラスリスト設定処理
        /// </summary>
        /// <param name="colDisplayStatusList">設定するColDisplayStatusクラスリストのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを設定します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="displayStatusList">シリアライズ対象ColDisplayStatusクラスリストのインスタンス</param>
        /// <param name="fileName">シリアライズ先ファイル名称</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストをシリアライズします。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatusExp> colDisplayStatusList, string fileName)
        {
            ColDisplayStatusExp[] colDisplayStatusArray = new ColDisplayStatusExp[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ元ファイル名称</param>
        /// <returns>デシリアライズされたColDisplayStatusクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : デシリアライズした列表示状態クラスリストを返します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public static List<ColDisplayStatusExp> Deserialize(string fileName)
        {
            List<ColDisplayStatusExp> retList = new List<ColDisplayStatusExp>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatusExp[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatusExp[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatusExp colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 列表示状態クラス追加処理
        /// </summary>
        /// <param name="colDisplayStatus">追加するColDisplayStatusクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryに追加します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private void Add(ColDisplayStatusExp colDisplayStatus)
        {
            // 既に同一キーが存在する場合は処理しない
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key))
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラス削除処理
        /// </summary>
        /// <param name="colDisplayStatus">削除するColDisplayStatusクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private void Remove(ColDisplayStatusExp colDisplayStatus)
        {
            // 同一キーが存在しない場合は処理しない
            if (!(this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key)))
            {
                return;
            }

            ColDisplayStatusExp status = null;

            try
            {
                status = this._colDisplayStatusDictionary[colDisplayStatus.Key];
            }
            catch (KeyNotFoundException)
            {
                //
            }

            if (status == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(status);
            this._colDisplayStatusDictionary.Remove(colDisplayStatus.Key);

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト⇒Dictionary格納処理
        /// </summary>
        /// <param name="colDisplayStatusList">格納するColDisplayStatusクラスのリストのインスタンス</param>
        /// <returns>列表示状態クラス格納Dictionaryのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private Dictionary<string, ColDisplayStatusExp> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            Dictionary<string, ColDisplayStatusExp> retDictionary = new Dictionary<string, ColDisplayStatusExp>();

            foreach (ColDisplayStatusExp status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }
        #endregion
    }
}