using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    public class MAZAI02111EA : IExtrProc
    {
        #region コンストラクター
        /// <summary>
        /// 棚卸関連一覧表抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 棚卸関連一覧表抽出クラスの初期化を行い新しいインスタンスを生成します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2007.09.14 980035 金沢 貞義</br>
        /// <br>             ・DC.NS対応</br>
        /// -----------------------------------------------------------------------------------
        /// <br>UpdateNote : PM.NS対応</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date	   : 2008.10.08</br>
        /// <br>Update Note: 2009/12/10 張凱</br>
        /// <br>			 不具合対応(PM.NS保守依頼③対応)</br>
        /// <br>Update Note: 2011/11/28 陳建明</br>
        /// <br>			 障害報告 #8073 棚卸調査表/棚番の印刷順について</br>
        /// </remarks>
        public MAZAI02111EA(object printInfo)
        {     
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as InventSearchCndtnUI;
            this._inventoryListCmnAcs = new InventoryListCmnAcs();
        }

        #endregion

        #region private member

        private SFCMN06002C _printInfo = null;                      // 共通印刷情報クラス
        private InventoryListCmnAcs _inventoryListCmnAcs = null;    // 棚卸関連一覧表アクセスクラス
        private InventSearchCndtnUI _extraInfo = null;              // 抽出条件クラス

        #endregion

        #region コンスト
        private const string PGID = "MAZAI02111E";
        #endregion

        #region IExtrProc メンバ

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int ExtrPrintData()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            
			try
			{
                form.Show();			// ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }

        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        #endregion

        #region private methods
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2009/12/10 張凱</br>
        /// <br>             ソートの修正</br>
        /// </remarks>
        private int ExtraProc()
        {
            int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //データ取得
                status = this._inventoryListCmnAcs.Search(this._extraInfo, out message);      	               

                if (status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // フィルター文字列
                    string strFilter	= "";
                    // ソート文字列を取得
                    // ----------UPD 2009/12/10 ---------<<<<<
                    //string strSort		= this.MakeSortingOrderString();
                    string strSort = string.Empty;
                    //棚卸調査表以外、重複棚番ありのみ以外場合
                    if (this._extraInfo.SelectedPaperKind == 0)
                    {
                        if (_extraInfo.OutputAppointDiv != 3)
                        {
                            strSort = this.MakeSortingOrderString();
                        }
                    }
                    else
                    {
                        strSort = this.MakeSortingOrderString();
                    }
                    // ----------UPD 2009/12/10 ---------<<<<<
                    // 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
                    DataView dv = new DataView(this._inventoryListCmnAcs._printDataSet.Tables[MAZAI02114EA.InventoryListDataTable],strFilter,strSort,DataViewRowState.CurrentRows);
                    if( dv.Count > 0 ) 
                    {
                    // データをセット
                        this._printInfo.rdData = dv;
                    }
                    //// 該当データ無し
                    else 
                    {
                        status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
                    }                 
                    
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PGID, message, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            result = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                }
            }
            return result;
        }

        /// <summary>
		/// ソート文字列作成処理
		/// </summary>
		/// <returns>ソート文字列</returns>
		/// <remarks>
		/// <br>Note       : ソート文字列を作成します。</br>
		/// <br>Programmer : 23001 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2011/11/28 陳建明</br>
        /// <br>             ソートの修正</br>
		/// </remarks>
		private string MakeSortingOrderString()
		{
			string sortStr = "";

            //選択されたソート条件により処理を分ける倉庫
            switch(this._extraInfo.SortDiv)
            {
                // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
                #region // 2007.09.14 修正
                ////倉庫→商品
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_Goods:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_SectionCode,0 );
                //    //倉庫
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseCode,0 );
                //    //メーカー
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_MakerCode,0 );
                //    //商品
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_GoodsCode,0 );
                //    //在庫区分
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_UiSotckDiv,0 );
                //    //仕入単価
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_StockUnitPrice,0 );
                //    //仕入先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CustomerCode,0 );
                //    //委託先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_ShipCustomerCode,0 );
                //    //事業者コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CarrierEpCode,0 );
                //   
                //    break;
                //}
                ////倉庫→得意先(仕入先)→商品
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Goods:
                //{   
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_SectionCode,0 );
                //    //倉庫
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseCode,0 );
                //    //仕入先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CustomerCode,0 );
                //    //メーカー
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_MakerCode,0 );
                //    //商品
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_GoodsCode,0 );
                //    //在庫区分
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_UiSotckDiv,0 );
                //    //仕入単価
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_StockUnitPrice,0 );                   
                //    //委託先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_ShipCustomerCode,0 );
                //    //事業者コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CarrierEpCode,0 );
                //    break;
                //}
                ////通番
                //case (int)InventSearchCndtnUI.SortOrder.SequenceNumber:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_InventorySeqNo,0);
                //    break;
                //}
                ////倉庫→出荷先得意先(委託先)→商品
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_ShipCustomer_Goods:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_SectionCode,0 );
                //    //倉庫
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseCode,0 );
                //    //委託先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_ShipCustomerCode,0 );
                //    //メーカー
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_MakerCode,0 );
                //    //商品
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_GoodsCode,0 );
                //    //在庫区分
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_UiSotckDiv,0 );
                //    //仕入単価
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_StockUnitPrice,0 );
                //    //仕入先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CustomerCode,0 );                   
                //    //事業者コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CarrierEpCode,0 );
                //    break;
                //}
                ////倉庫→事業者→商品
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_CarrierEp_Goods:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_SectionCode,0 );
                //    //倉庫
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseCode,0 );
                //    //事業者コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CarrierEpCode,0 );
                //    //メーカー
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_MakerCode,0 );
                //    //商品
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_GoodsCode,0 );
                //    //在庫区分
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_UiSotckDiv,0 );
                //    //仕入単価
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_StockUnitPrice,0 );
                //    //仕入先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CustomerCode,0 );                                       
                //    //委託先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_ShipCustomerCode,0 );
                //    break;
                //}        
                #endregion
                
                // 2008.10.08 30413 犬飼 ソート文字列編集を変更 >>>>>>START
                ////倉庫→棚番
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_SectionCode, 0);
                //    //倉庫
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                //    //棚番
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);
                //    break;
                //}

                ////倉庫→得意先(仕入先)
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SectionCode, 0);
                //    //倉庫
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                //    //仕入先コード
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_CustomerCode, 0);
                //    break;
                //}

                ////倉庫→ＢＬコード
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SectionCode, 0);
                //    //倉庫
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                //    //ＢＬコード
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                //    break;
                //}

                ////倉庫→メーカー
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_Maker:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SectionCode, 0);
                //    //倉庫
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                //    //メーカー
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_MakerCode, 0);
                //    break;
                //}

                ////倉庫→得意先(仕入先)→棚番
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo:
                //{   
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_SectionCode, 0);
                //    //倉庫
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                //    //仕入先コード
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_CustomerCode, 0);
                //    //棚番
                //    this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                //    break;
                //}

                ////倉庫→得意先(仕入先)→メーカー
                //case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker:
                //{
                //    //一応拠点も入れておく
                //    //拠点
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SectionCode, 0);
                //    //倉庫
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                //    //仕入先コード
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_CustomerCode, 0);
                //    //メーカー
                //    this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_MakerCode, 0);
                //    break;
                //}
                // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<

                case 0:             // 棚番順
                    {
                        //倉庫
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);//del 2011/11/28 陳建明 Redmine #8073
                        //棚番
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);//del 2011/11/28 陳建明 Redmine #8073
                        //品番
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo,0);//del 2011/11/28 陳建明 Redmine #8073
                        //メーカー
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);//del 2011/11/28 陳建明 Redmine #8073
                        break;
                    }
                case 1:             // 仕入先順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 2:             // ＢＬコード順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //ＢＬコード
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 3:             // グループコード順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //グループコード
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGroupCode, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 4:             // メーカー順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
                case 5:             // 仕入先・棚番順
                    {
                        //倉庫
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);//del 2011/11/28 陳建明 Redmine #8073
                        //仕入先
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);//del 2011/11/28 陳建明 Redmine #8073
                        //棚番
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);//del 2011/11/28 陳建明 Redmine #8073
                        //品番
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);//del 2011/11/28 陳建明 Redmine #8073
                        //メーカー
                        //this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);//del 2011/11/28 陳建明 Redmine #8073
                        break;
                    }
                case 6:             // 仕入先・メーカー順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
                // 2008.10.08 30413 犬飼 ソート文字列編集を変更 <<<<<<END
            }

            // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
            ////製番毎にソート(通番時は関係ないが)
            //this.MakeSortQuery( ref sortStr, MAZAI02114EA.ctCol_ProductNumber,0 );
            // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
                
			return sortStr;
		}

		/// <summary>
		/// ソート用文字列作成処理
		/// </summary>
		/// <param name="colName">列名称</param>
		/// <param name="ascDescDiv">昇順・降順区分[0:昇順, 1:降順]</param>
		/// <param name="strQuery">ソート用文字列</param>
		/// <remarks>
		/// <br>Note       : ソート用の文字列の作成を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MakeSortQuery( ref string strQuery, string colName, int ascDescDiv )
		{
            if( strQuery == null ) {
                strQuery = "";
            }

            if( strQuery == "" ) {
                strQuery += String.Format( "{0} {1}", colName, ( ascDescDiv == 0 ? "ASC" : "DESC" ) );
            }
            else {
                strQuery += String.Format( ", {0} {1}", colName, ( ascDescDiv == 0 ? "ASC" : "DESC" ) );
            }
		}


        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, PGID, iMsg, iSt, iButton, iDefButton);
        }


        #endregion
    }
}
