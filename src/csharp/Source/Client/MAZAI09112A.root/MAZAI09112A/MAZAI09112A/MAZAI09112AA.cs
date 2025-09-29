using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫管理全体設定設定テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note            : 在庫管理全体設定設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer      : 30005 木建　翼</br>
    /// <br>Date            : 2007.03.01</br>
    /// <br>Update Note     : 2007.03.27 22022 段上　知子</br>
    /// <br>                             1.フォーカス移動の障害対応</br>
    /// <br>                             2.プルダウン項目色設定</br>
    /// <br>                             3.ボタンアイコン設定</br>
    /// <br>                             4.端数処理区分追加</br>
    /// ---------------------------------------------------------------------------------
    /// <br>Update Note     : 2007.08.20 20081 疋田　勇人</br>
    /// <br>                             1.DC.NS用に変更する</br>
    /// <br>UpdateNote      : 2008/06/04 30415 柴田 倫幸</br>
    /// <br>        	      ・データ項目の追加/削除による修正</br>   
    /// <br>UpdateNote      : 2008/07/03 30415 柴田 倫幸</br>
    /// <br>        	      ・端数処理区分追加による修正</br>       
    /// <br>UpdateNote      : 2008.12.01 21024 佐々木 健</br>
    /// <br>        	      ・Searchメソッドの追加</br>
    /// <br>Update Note     : 2009/12/02 朱俊成</br>
    /// <br>                  PM.NS-4</br>
    /// <br>                  棚卸運用区分の追加</br>
    /// <br>Update Note     : 2011/08/29 周雨</br>
    /// <br>                  連番 1016 「現在庫表示区分」を追加　</br>
    /// <br>Update Note     : 2012/06/08 lanl</br>
    /// <br>                : #Redmine30282 「棚卸データ削除区分」を画面に追加　</br>
    /// <br>Update Note     : 2012/07/02 三戸　伸悟</br>
    /// <br>                 「移動時在庫自動登録区分」を画面に追加　</br>
    /// <br>Update Note     : 2014/10/27 wangf </br>
    /// <br>                : Redmine#43854画面に列「移動伝票出力先区分」追加</br>

    /// </remarks>
    public class StockMngTtlStAcs
    {
        #region Private Members

        /// <summary>リモートオブジェクト</summary>
        private IStockMngTtlStDB _iStockMngTtlStDB = null;

        #endregion

        #region Constructor

        /// <summary>
		/// 在庫管理全体設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫管理全体設定アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30005 木建　翼</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
        public StockMngTtlStAcs()
		{
			try {
				// リモートオブジェクト取得
				this._iStockMngTtlStDB = MediationStockMngTtlStDB.GetStockMngTtlStDB();
				}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iStockMngTtlStDB = null;
			}
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iStockMngTtlStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
		/// 在庫管理全体設定設定読込処理
		/// </summary>
		/// <param name="readList">読込結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note            : 在庫管理全体設定設定の読み込み処理を行ないます。</br>
	    /// <br>Programmer      : 30005 木建　翼</br>
        /// <br>Date            : 2007.03.01</br>
    	/// </remarks>
        public int Read(out StockMngTtlSt stockMngTtlSt, string enterpriseCode, int stockMngTtlStCd)
        {
            int status = -1;
            
            try
            {
                stockMngTtlSt = null;
                StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
                stockMngTtlStWork.EnterpriseCode = enterpriseCode;
                //stockMngTtlStWork.StockMngTtlStCd = stockMngTtlStCd;  // DEL 2008/06/04

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);

                // 在庫管理全体設定読み込み
                status = this._iStockMngTtlStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                    // クラス内メンバコピー
                    stockMngTtlSt = CopyToStockMngTtlStFromStockMngTtlStWork(stockMngTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                stockMngTtlSt = null;
                //オフライン時はnullをセット
                this._iStockMngTtlStDB = null;

                return -1;
            }
 
        }

        // --- DEL 2008/06/04 -------------------------------->>>>>
        /// <summary>
		/// 在庫管理全体設定登録・更新処理
		/// </summary>
        /// <param name="writeList">在庫管理全体設定リスト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 在庫管理全体設定の登録・更新を行います。実際は更新しか行なわれない。</br>
		/// <br>Programmer : 30005 木建　翼</br>
		/// <br>Date       : 2007.03.01</br>
		/// </remarks>
        //public int Write(ref ArrayList writeList)
        //{
        //    int status = 0;

        //    try
        //    {
        //        ArrayList paraList = new ArrayList();
        //        foreach (object writeObj in writeList)
        //        {
        //            if (writeObj is StockMngTtlSt)
        //            {
        //                // 在庫管理全体設定クラスから在庫管理全体設定ワーククラスにコピー
        //                paraList.Add(CopyToStockMngTtlStWorkFromStockMngTtlSt((StockMngTtlSt)writeObj));
        //            }
        //        }

        //        object paraobj = paraList;
                
        //        // リモートへ書き込み
        //        status = this._iStockMngTtlStDB.Write(ref paraobj);

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // 在庫管理全体設定
        //            if (paraobj is StockMngTtlStWork)
        //            {
        //                // 在庫管理全体設定ワーククラスから在庫管理全体設定クラスにコピー
        //                writeList.Add(CopyToStockMngTtlStFromStockMngTtlStWork((StockMngTtlStWork)paraobj));
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // オフライン時はnullをセット
        //        writeList = null;
        //        //this._iStockMngTtlSt = null;

        //        // 通信エラーは-1を返す。
        //        status = -1;
        //    }

        //    return status;

        //}
        // --- DEL 2008/06/04 --------------------------------<<<<< 

        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// <summary>
        /// 在庫管理全体設定登録・更新処理
        /// </summary>
        /// <param name="writeList">在庫管理全体設定リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の登録・更新を行います</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Write(ref StockMngTtlSt stockMngTtlSt)
        {
            int status = 0;

            try
            {
                // 在庫管理全体設定クラスを在庫管理全体設定ワーククラスへメンバコピー
                StockMngTtlStWork stockMngTtlStWork = CopyToStockMngTtlStWorkFromStockMngTtlSt(stockMngTtlSt);

                // 保存
                Object paraObj = (object)stockMngTtlStWork;
                status = this._iStockMngTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 在庫管理全体設定ワーククラスから在庫管理全体設定クラスへメンバコピー
                    ArrayList wklist = (ArrayList)paraObj;
                    stockMngTtlStWork = wklist[0] as StockMngTtlStWork;
                    stockMngTtlSt = CopyToStockMngTtlStFromStockMngTtlStWork(stockMngTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockMngTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 在庫管理全体設定論理削除処理
        /// </summary>
        /// <param name="estimateDefSet">在庫管理全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int LogicalDelete(ref StockMngTtlSt stockMngTtlSt)
        {
            int status = 0;

            try
            {
                // 在庫管理全体設定クラスを在庫管理全体設定ワーククラスへメンバコピー
                StockMngTtlStWork stockMngTtlStWork = CopyToStockMngTtlStWorkFromStockMngTtlSt(stockMngTtlSt);

                // 在庫管理全体設定を論理削除
                Object paraObj = (object)stockMngTtlStWork;
                status = this._iStockMngTtlStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 在庫管理全体設定ワーククラスを在庫管理全体設定クラスにメンバコピー
                    stockMngTtlStWork = paraObj as StockMngTtlStWork;
                    stockMngTtlSt = CopyToStockMngTtlStFromStockMngTtlStWork(stockMngTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockMngTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 在庫管理全体設定論理削除復活処理
        /// </summary>
        /// <param name="estimateDefSet">在庫管理全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Revival(ref StockMngTtlSt stockMngTtlSt)
        {
            int status = 0;

            try
            {
                // 在庫管理全体設定クラスを在庫管理全体設定ワーククラスへメンバコピー
                StockMngTtlStWork stockMngTtlStWork = CopyToStockMngTtlStWorkFromStockMngTtlSt(stockMngTtlSt);

                // 復活
                Object paraObj = (object)stockMngTtlStWork;
                status = this._iStockMngTtlStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 在庫管理全体設定ワーククラスを在庫管理全体設定クラスにメンバコピー
                    stockMngTtlStWork = paraObj as StockMngTtlStWork;
                    stockMngTtlSt = CopyToStockMngTtlStFromStockMngTtlStWork(stockMngTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iStockMngTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 在庫管理全体設定物理削除処理
        /// </summary>
        /// <param name="estimateDefSet">在庫管理全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の物理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Delete(StockMngTtlSt stockMngTtlSt)
        {
            int status = 0;

            try
            {
                // 在庫管理全体設定クラスを在庫管理全体設定ワーククラスへメンバコピー
                StockMngTtlStWork stockMngTtlStWork = CopyToStockMngTtlStWorkFromStockMngTtlSt(stockMngTtlSt);
                // XML変換し、文字列をバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);

                // 在庫管理全体設定物理削除
                status = this._iStockMngTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iStockMngTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 在庫管理全体設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        // 2008.12.01 Add >>>
        /// <summary>
        /// 在庫管理全体設定検索処理
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の検索処理を行います。論理削除データは抽出されません。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2008.12.01 Add <<<
        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバコピー処理（在庫管理全体設定ワーククラス→在庫管理全体設定クラス）
        /// </summary>
        /// <param name="slipIniSetWork">在庫管理全体設定ワーククラス</param>
        /// <returns>在庫管理全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定設定ワーククラスから在庫管理全体設定クラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282 №1002 「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private StockMngTtlSt CopyToStockMngTtlStFromStockMngTtlStWork(StockMngTtlStWork stockMngTtlStWork)
        {
            StockMngTtlSt stockMngTtlSt = new StockMngTtlSt();

            // 作成日時
            stockMngTtlSt.CreateDateTime = stockMngTtlStWork.CreateDateTime;
            // 更新日時
            stockMngTtlSt.UpdateDateTime = stockMngTtlStWork.UpdateDateTime;
            // 企業コード
            stockMngTtlSt.EnterpriseCode = stockMngTtlStWork.EnterpriseCode;
            // GUID
            stockMngTtlSt.FileHeaderGuid = stockMngTtlStWork.FileHeaderGuid;
            // 更新従業員コード
            stockMngTtlSt.UpdEmployeeCode = stockMngTtlStWork.UpdEmployeeCode;
            // 更新アセンブリID1
            stockMngTtlSt.UpdAssemblyId1 = stockMngTtlStWork.UpdAssemblyId1;
            // 更新アセンブリID2
            stockMngTtlSt.UpdAssemblyId2 = stockMngTtlStWork.UpdAssemblyId2;
            // 論理削除区分
            stockMngTtlSt.LogicalDeleteCode = stockMngTtlStWork.LogicalDeleteCode;
            // 拠点コード
            stockMngTtlSt.SectionCode = stockMngTtlStWork.SectionCode;  // ADD 2008/06/04
            /* --- DEL 2008/06/04 -------------------------------->>>>>
            // 在庫管理全体設定管理コード
            stockMngTtlSt.StockMngTtlStCd = stockMngTtlStWork.StockMngTtlStCd;
            // 受託在庫拠点間移動区分
            stockMngTtlSt.TrustStSectMoveCd = stockMngTtlStWork.TrustStSectMoveCd;
            // 受託在庫倉庫移動区分
            stockMngTtlSt.TrustStWhouMoveCd = stockMngTtlStWork.TrustStWhouMoveCd;
            // 受託在庫委託許可区分
            stockMngTtlSt.TrEntrustPermCd = stockMngTtlStWork.TrEntrustPermCd;
               --- DEL 2008/06/04 --------------------------------<<<<< */
            // 在庫移動確定区分
            stockMngTtlSt.StockMoveFixCode = stockMngTtlStWork.StockMoveFixCode;
            // 在庫管理有無区分初期表示値
            //stockMngTtlSt.StockMngExistCdDisp = stockMngTtlStWork.StockMngExistCdDisp;  // DEL 2008/06/04
            // 製番管理区分初期表示値
            //stockMngTtlSt.PrdNumMngDivDisp = stockMngTtlStWork.PrdNumMngDivDisp;        // 2007.08.20 del
            // 最適在庫条件区分(使用しないため常に0)
            //stockMngTtlSt.BeatStockCondCd = stockMngTtlStWork.BeatStockCondCd;          // DEL 2008/06/04
            // 在庫評価方法
            stockMngTtlSt.StockPointWay = stockMngTtlStWork.StockPointWay;
            // 2007.03.27 DANJO ADD START
            // 端数処理区分
            stockMngTtlSt.FractionProcCd = stockMngTtlStWork.FractionProcCd;              // ADD 2008/07/03
            // 2007.03.27 DANJO ADD END

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            stockMngTtlSt.InventoryMngDiv = stockMngTtlStWork.InventoryMngDiv;
            // --- ADD 2009/12/02 ----------<<<<<

            // 2007.08.20 add start--------------------------------------->>
            // 在庫切れ出荷区分
            stockMngTtlSt.StockTolerncShipmDiv = stockMngTtlStWork.StockTolerncShipmDiv;
            // 棚卸印刷順初期設定区分
            stockMngTtlSt.InvntryPrtOdrIniDiv = stockMngTtlStWork.InvntryPrtOdrIniDiv;
            // 最高在庫数超え発注区分
            stockMngTtlSt.MaxStkCntOverOderDiv = stockMngTtlStWork.MaxStkCntOverOderDiv;
            // 2007.08.20 add end ----------------------------------------<<

            // --- ADD 2008/06/04 -------------------------------->>>>>
            stockMngTtlSt.ShelfNoDuplDiv = stockMngTtlStWork.ShelfNoDuplDiv;
            stockMngTtlSt.LotUseDivCd = stockMngTtlStWork.LotUseDivCd;
            stockMngTtlSt.SectDspDivCd = stockMngTtlStWork.SectDspDivCd;
            // --- ADD 2008/06/04 --------------------------------<<<<<
            stockMngTtlSt.PreStckCntDspDiv = stockMngTtlStWork.PreStckCntDspDiv;  // ADD 2011/08/29
            stockMngTtlSt.InvntryDtDelDiv = stockMngTtlStWork.InvntryDtDelDiv;  // ADD lanl 2012/06/08 Redmine#30282
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            stockMngTtlSt.MoveStockAutoInsDiv = stockMngTtlStWork.MoveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            stockMngTtlSt.MoveSlipOutPutDiv = stockMngTtlStWork.MoveSlipOutPutDiv;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            return stockMngTtlSt;
        }

        /// <summary>
        /// クラスメンバコピー処理（在庫管理全体設定クラス→在庫管理全体設定クラスワーク）
        /// </summary>
        /// <param name="slipIniSet">在庫管理全体設定クラス</param>
        /// <returns>在庫管理全体設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定クラスから在庫管理全体設定ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             Redmine#30282 №1002 「棚卸データ削除区分」を画面に追加</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private StockMngTtlStWork CopyToStockMngTtlStWorkFromStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
        {
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();

            // 作成日時
            stockMngTtlStWork.CreateDateTime = stockMngTtlSt.CreateDateTime;
            // 更新日時
            stockMngTtlStWork.UpdateDateTime = stockMngTtlSt.UpdateDateTime;
            // 企業コード
            stockMngTtlStWork.EnterpriseCode = stockMngTtlSt.EnterpriseCode;
            // GUID
            stockMngTtlStWork.FileHeaderGuid = stockMngTtlSt.FileHeaderGuid;
            // 更新従業員コード
            stockMngTtlStWork.UpdEmployeeCode = stockMngTtlSt.UpdEmployeeCode;
            // 更新アセンブリID1
            stockMngTtlStWork.UpdAssemblyId1 = stockMngTtlSt.UpdAssemblyId1;
            // 更新アセンブリID2
            stockMngTtlStWork.UpdAssemblyId2 = stockMngTtlSt.UpdAssemblyId2;
            // 論理削除区分
            stockMngTtlStWork.LogicalDeleteCode = stockMngTtlSt.LogicalDeleteCode;
            // 企業コード
            stockMngTtlStWork.EnterpriseCode = stockMngTtlSt.EnterpriseCode;
            // 拠点コード
            stockMngTtlStWork.SectionCode = stockMngTtlSt.SectionCode;  // ADD 2008/06/04
            /* --- DEL 2008/06/04 -------------------------------->>>>>
            // 在庫管理全体設定管理コード
            stockMngTtlStWork.StockMngTtlStCd = stockMngTtlSt.StockMngTtlStCd;
            // 受託在庫拠点間移動区分
            stockMngTtlStWork.TrustStSectMoveCd = stockMngTtlSt.TrustStSectMoveCd;
            // 受託在庫倉庫移動区分
            stockMngTtlStWork.TrustStWhouMoveCd = stockMngTtlSt.TrustStWhouMoveCd;
            // 受託在庫委託許可区分
            stockMngTtlStWork.TrEntrustPermCd = stockMngTtlSt.TrEntrustPermCd;
               --- DEL 2008/06/04 --------------------------------<<<<< */
            // 在庫移動確定区分
            stockMngTtlStWork.StockMoveFixCode = stockMngTtlSt.StockMoveFixCode;
            // 在庫管理有無区分初期表示値
            //stockMngTtlStWork.StockMngExistCdDisp = stockMngTtlSt.StockMngExistCdDisp;  // DEL 2008/06/04
            // 製番管理区分初期表示値
            //stockMngTtlStWork.PrdNumMngDivDisp = stockMngTtlSt.PrdNumMngDivDisp;        // 2007.08.20 del
            // 最適在庫条件区分(使用しないため常に0)
            //stockMngTtlStWork.BeatStockCondCd = stockMngTtlSt.BeatStockCondCd;          // DEL 2008/06/04
            // 在庫評価方法
            stockMngTtlStWork.StockPointWay = stockMngTtlSt.StockPointWay;
            // 2007.03.27 DANJO ADD START
            // 端数処理区分
            stockMngTtlStWork.FractionProcCd = stockMngTtlSt.FractionProcCd;              // ADD 2008/07/03      
            // 2007.03.27 DANJO ADD END

            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            stockMngTtlStWork.InventoryMngDiv = stockMngTtlSt.InventoryMngDiv;
            // --- ADD 2009/12/02 ----------<<<<<

            // 2007.08.20 add start--------------------------------------->>
            // 在庫切れ出荷区分
            stockMngTtlStWork.StockTolerncShipmDiv = stockMngTtlSt.StockTolerncShipmDiv;
            // 棚卸印刷順初期設定区分
            stockMngTtlStWork.InvntryPrtOdrIniDiv = stockMngTtlSt.InvntryPrtOdrIniDiv;
            // 最高在庫数超え発注区分
            stockMngTtlStWork.MaxStkCntOverOderDiv = stockMngTtlSt.MaxStkCntOverOderDiv;
            // 2007.08.20 add end ----------------------------------------<<

            // --- ADD 2008/06/04 -------------------------------->>>>>
            stockMngTtlStWork.ShelfNoDuplDiv = stockMngTtlSt.ShelfNoDuplDiv;
            stockMngTtlStWork.LotUseDivCd = stockMngTtlSt.LotUseDivCd;
            stockMngTtlStWork.SectDspDivCd = stockMngTtlSt.SectDspDivCd;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
            stockMngTtlStWork.PreStckCntDspDiv = stockMngTtlSt.PreStckCntDspDiv;  // ADD 2011/08/29
            stockMngTtlStWork.InvntryDtDelDiv = stockMngTtlSt.InvntryDtDelDiv; // ADD lanl 2012/06/08 Redmine#30282
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            stockMngTtlStWork.MoveStockAutoInsDiv = stockMngTtlSt.MoveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            stockMngTtlStWork.MoveSlipOutPutDiv = stockMngTtlSt.MoveSlipOutPutDiv;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            return stockMngTtlStWork;
        }

        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// <summary>
        /// 在庫管理全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定の検索処理を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = stockMngTtlStWork;
            object retobj = null;

            //MessageBox.Show("dbg1"); //DBG

            // 在庫管理全体設定全件検索
            status = this._iStockMngTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (StockMngTtlStWork wkStockMngTtlStWork in wkList)
                    {
                        retList.Add(CopyToStockMngTtlStFromStockMngTtlStWork(wkStockMngTtlStWork));
                    }
                }
            }

            return status;
        }
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        // --- ADD 2011/08/29 -------------------------------->>>>>
        /// <summary>
        /// 在庫管理全体設定設定読込処理(全社共通のみ)
        /// </summary>
        /// <param name="stockMngTtlSt">読込結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note            : 在庫管理全体設定設定の読み込み処理を行ないます。</br>
        /// <br>Programmer      : 周雨</br>
        /// <br>Date            : 2011/08/29</br>
        /// </remarks>
        public int Read(out StockMngTtlSt stockMngTtlSt, string enterpriseCode)
        {
            int status = -1;

            try
            {
                stockMngTtlSt = null;
                StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
                stockMngTtlStWork.EnterpriseCode = enterpriseCode;
                stockMngTtlStWork.SectionCode = "00";

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);

                // 在庫管理全体設定読み込み
                status = this._iStockMngTtlStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                    // クラス内メンバコピー
                    stockMngTtlSt = CopyToStockMngTtlStFromStockMngTtlStWork(stockMngTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                stockMngTtlSt = null;
                //オフライン時はnullをセット
                this._iStockMngTtlStDB = null;

                return -1;
            }

        }
        // --- ADD 2011/08/29 --------------------------------<<<<<
        #endregion


    }
}
