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
    public class MAZAI02071EA : IExtrProc
    {
        #region コンストラクタ
        /// <summary>
        /// 在庫一覧表抽出クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫一覧表抽出クラスの初期化を行い新しいインスタンスを生成します。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// <br>Update Note: 2007.10.05 980035 金沢 貞義</br>
        /// <br>			 ・DC.NS対応</br>
        /// <br>           : 2008/10/08        照田 貴志</br>
        /// <br>			 ・バグ修正、仕様変更対応</br>
        /// <br>           : 2009/03/13        照田 貴志　不具合対応[12371]</br>
        /// <br>           : 2009/03/26        照田 貴志　不具合対応[12832]</br>
        /// <br>           : 2009/04/03        照田 貴志　不具合対応[12372][13000]</br>
        /// </remarks>
        public MAZAI02071EA(object printInfo)
        {     
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as StockListCndtn;
            this._stockListAcs = new StockListAcs();
        }

        #endregion

        #region private member

        private SFCMN06002C _printInfo = null;                      // 共通印刷情報クラス
        private StockListAcs _stockListAcs = null;                  // 在庫一覧表アクセスクラス
        private StockListCndtn _extraInfo = null;                   // 抽出条件クラス

        #endregion

        #region コンスト
        private const string PGID = "MAZAI02071E";
        #endregion

        #region IExtrProc メンバ

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 23010 中村 仁</br>
        /// <br>Date       : 2007.03.22</br>
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
                form.Show();			    // ダイアログ表示
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
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private int ExtraProc()
        {
            int result = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //データ取得
                status = this._stockListAcs.Search(this._extraInfo, out message);      	

                if (status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // フィルター文字列
                    //string strFilter	= "";                                       //DEL 2009/04/03 不具合対応[12372]
                    string strFilter = this.MakeFilterString(this._extraInfo);      //ADD 2009/04/03 不具合対応[12372]
                    // ソート文字列を取得
                    string strSort		= this.MakeSortingOrderString();
                    // 抽出結果テーブルから指定されたフィルタ・ソート条件でデータビューを作成
                    DataView dv = new DataView(this._stockListAcs._printDataSet.Tables[MAZAI02074EA.StockListDataTable],strFilter,strSort,DataViewRowState.CurrentRows);

                    if( dv.Count > 0 ) 
                    {
                    // データをセット
                        this._printInfo.rdData = dv;
                    }
                    // 該当データ無し
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

        // ---ADD 2009/04/03 不具合対応[12372] ---------------------------------------------->>>>>
        /// <summary>
        /// 抽出文字列作成処理
        /// </summary>
        /// <param name="stockListCndtn">検索時の条件</param>
        /// <returns>抽出文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件の仕入先を元に抽出文字列を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/04/03</br>
        /// </remarks>
        private string MakeFilterString(StockListCndtn stockListCndtn)
        {
            string strQuery = "";

            if ((stockListCndtn.St_StockSupplierCode != 0) && (stockListCndtn.Ed_StockSupplierCode != 0))
            {
                strQuery = String.Format("{0} <= {1} AND {2} <= {3}",
                stockListCndtn.St_StockSupplierCode.ToString(),
                MAZAI02074EA.ctCol_StockSupplierCode,
                MAZAI02074EA.ctCol_StockSupplierCode,
                stockListCndtn.Ed_StockSupplierCode.ToString());
            }

            if ((stockListCndtn.St_StockSupplierCode != 0) && (stockListCndtn.Ed_StockSupplierCode == 0))
            {
                strQuery = String.Format("{0} <= {1}",
                stockListCndtn.St_StockSupplierCode.ToString(),
                MAZAI02074EA.ctCol_StockSupplierCode);
            }

            if ((stockListCndtn.St_StockSupplierCode == 0) && (stockListCndtn.Ed_StockSupplierCode != 0))
            {
                strQuery = String.Format("{0} <= {1}",
                MAZAI02074EA.ctCol_StockSupplierCode,
                stockListCndtn.Ed_StockSupplierCode.ToString());
            }

            return strQuery;
        }
        // ---ADD 2009/04/03 不具合対応[12372] ----------------------------------------------<<<<<

        /// <summary>
		/// ソート文字列作成処理
		/// </summary>
		/// <returns>ソート文字列</returns>
		/// <remarks>
		/// <br>Note       : ソート文字列を作成します。</br>
		/// <br>Programmer : 23001 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private string MakeSortingOrderString()
		{
			string sortStr = "";

            // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
            //// 拠点オプションありかつ拠点選択の時
            //if( ( this._extraInfo.IsOptSection ) && ( this._extraInfo.DepositStockSecCodeList.Length > 1 ) ) 
            //{
            //    // ソート条件に拠点を追加
            //    this.MakeSortQuery( ref sortStr, MAZAI02074EA.ctCol_SectionCode, 0 );
            //}
            // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<

            //選択されたソート条件により処理を分ける倉庫
            switch(this._extraInfo.ChangePageDiv)
            {
                //--- DEL 2008/08/01 ---------->>>>>
                ////最終仕入日順
                //case (int)StockListCndtn.PageChangeDiv.Sort_StockDate:
                //{
                //    this.MakeSortQuery( ref sortStr, MAZAI02074EA.ctCol_LastStockDate_sort,0 );
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                //商品大分類中分類順
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //case (int)StockListCndtn.PageChangeDiv.Sort_LargeMediumGoodsGanreCode:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_LargeGoodsGanreCode, 0);
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_MediumGoodsGanreCode, 0);
                //    break;
                //}
                //--- DEL 2008/08/01 ---------->>>>>
                //case (int)StockListCndtn.PageChangeDiv.Sort_LargeGoodsGanreCode:
                //{   
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_LargeGoodsGanreCode, 0);
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_MediumGoodsGanreCode, 0);
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_DetailGoodsGanreCode, 0);
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                ////キャリア順
                //case (int)StockListCndtn.PageChangeDiv.Sort_CarrierCode:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_CarrierCode,0);
                //    break;
                //}
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/08/01 ---------->>>>>
                //メーカー順
                //case (int)StockListCndtn.PageChangeDiv.Sort_MakerCode:
                //{
                //    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //    //this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_MakerCode, 0);
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_GoodsMakerCd, 0);
                //    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                ////機種順
                //case (int)StockListCndtn.PageChangeDiv.Sort_CellPhoneModeleCode:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_CellphoneModelCode,0);
                //    break;
                //}
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/08/01 ---------->>>>>
                ////出荷可能数順
                //case (int)StockListCndtn.PageChangeDiv.Sort_ShipmentPosCnt:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_ShipmentPosCnt,0);
                //    break;
                //}

                //// 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                ////倉庫順
                //case (int)StockListCndtn.PageChangeDiv.Sort_WarehouseCode:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_WarehouseCode, 0);
                //    break;
                //}
                ////自社分類順
                //case (int)StockListCndtn.PageChangeDiv.Sort_EnterpriseGanreCode:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_EnterpriseGanreCode, 0);
                //    break;
                //}
                ////ＢＬコード順
                //case (int)StockListCndtn.PageChangeDiv.Sort_BLGoodsCode:
                //{
                //    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<

                //--- ADD 2008/08/01 ---------->>>>>
                // 仕入先順
                case (int)StockListCndtn.PageChangeDiv.Sort_SupplierCode:
                {
                    /* ---DEL 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------>>>>>
                    //this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);               //DEL 2008/10/08 ソート順変更の為
                    // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------>>>>>
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseCode, 0);          // 倉庫
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_CustomerCode, 0);           // 仕入先
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);                 // BLコード
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_GoodsMakerCd, 0);           // メーカー
                    // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------<<<<<
                       ---DEL 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------<<<<< */
                    // ---ADD 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------>>>>>
                    //this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_SectionCode, 0);            // 拠点         //ADD 2009/03/26 不具合対応[12832] → DEL 2009/04/03 不具合対応[13000]
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseCode, 0);          // 倉庫
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_CustomerCode, 0);           // 仕入先
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_GoodsMakerCd, 0);           // メーカー
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);                 // BLコード
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_GoodsNo, 0);                     // 品番
                    // ---ADD 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------<<<<<
                    break;
                }
                // 棚番順
                case (int)StockListCndtn.PageChangeDiv.Sort_WarehouseCode:
                {
                    /* ---DEL 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------>>>>>
                    //this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);               //DEL 2008/10/08 ソート順変更の為
                    // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------>>>>>
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseCode, 0);          // 倉庫
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseShelfNo, 0);       // 棚番
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);                 // BLコード
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_GoodsMakerCd, 0);           // メーカー
                    // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------<<<<<
                       ---DEL 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------<<<<< */
                    // ---ADD 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------>>>>>
                    //this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_SectionCode, 0);            // 拠点         //ADD 2009/03/26 不具合対応[12832] → DEL 2009/04/03 不具合対応[13000]
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseCode, 0);          // 倉庫
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseShelfNoBreak, 0);  // 棚番ブレイク
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_WarehouseShelfNo, 0);       // 棚番
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_BLGoodsCode, 0);                 // BLコード
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_GoodsNo, 0);                     // 品番
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_CustomerCode, 0);           // 仕入先
                    this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_Sort_GoodsMakerCd, 0);           // メーカー
                    // ---ADD 2009/03/13 不具合対応[12371] ------------------------------------------------------------------------------<<<<<
                    break;
                }
                //--- ADD 2008/08/01 ----------<<<<<
            }

            /* ---DEL 2009/03/13 不具合対応[12371] --------------------------->>>>>
            //商品番号順にソート
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            //this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_GoodsCode, 0);
            this.MakeSortQuery(ref sortStr, MAZAI02074EA.ctCol_GoodsNo, 0);
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
               ---DEL 2009/03/13 不具合対応[12371] ---------------------------<<<<< */

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
		/// <br>Date       : 2007.03.22</br>
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
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, PGID, iMsg, iSt, iButton, iDefButton);
        }


        #endregion
    }
}
