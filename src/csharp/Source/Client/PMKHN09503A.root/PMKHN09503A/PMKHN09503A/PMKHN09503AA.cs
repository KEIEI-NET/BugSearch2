//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品不可設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 返品不可設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品不可設定のフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.20</br>
    /// </remarks>
    public class GoodsNotReturnAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private GoodsNotReturnAcs()
        {
            // 変数初期化
            this._dataSet = new GoodsNotReturnDataSet();
            this._goodsNotReturnDetailDataTable = this._dataSet.GoodsNotReturnDetail;
            this.goodsNotReturnProcDB = GoodsNotReturnSetDB.GetGoodsNotReturnProcDB();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties

        /// <summary>
        /// 返品不可設定明細データテーブルプロパティ
        /// </summary>
        public GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable GoodsNotReturnDetailDataTable
        {
            get { return _goodsNotReturnDetailDataTable; }
        }

        /// <summary>
        /// 返品不可設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>返品不可設定アクセスクラス インスタンス</returns>
        public static GoodsNotReturnAcs GetInstance()
        {
            if (_goodsNotReturnAcs == null)
            {
                _goodsNotReturnAcs = new GoodsNotReturnAcs();
            }

            return _goodsNotReturnAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static GoodsNotReturnAcs _goodsNotReturnAcs;
        private GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable _goodsNotReturnDetailDataTable;
        private GoodsNotReturnDataSet _dataSet;
        IGoodsNotReturnProcDB goodsNotReturnProcDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods

        /// <summary>
        /// 返品不可設定データ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="goodsNotReturnList">売上伝票データリスト</param>
        /// <param name="retMessage">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メッセージにより、返品不可設定データ検索処理を行います。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        public int ReadDBData(string enterpriseCode, string salesSlipNum, out ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = this.goodsNotReturnProcDB.ReadDBData(enterpriseCode, salesSlipNum, out goodsNotReturnList, out retMessage);

            return status;
        }

        /// <summary>
        /// 返品不可設定データ更新処理
        /// </summary>
        /// <param name="goodsNotReturnList">売上伝票データリスト</param>
        /// <param name="retMessage">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メッセージにより、返品不可設定データ更新処理を行います。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        public int UpdateReturnUpper(ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = this.goodsNotReturnProcDB.UpdateReturnUpper(ref goodsNotReturnList, out retMessage);

            return status;
        }

        /// <summary>
        /// 返品不可設定データ画面出力
        /// </summary>
        /// <param name="goodsNotReturnList">売上伝票データリスト</param>
        /// <remarks>
        /// <br>Note       : メッセージにより、返品不可設定データ出力処理を行います。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        public ArrayList goodsNotReturnCache(ArrayList goodsNotReturnList)
        {
            int rowNo = 0;
            ArrayList goodsNotReturnListTmp = new ArrayList();
            foreach (GoodsNotReturnWork work in goodsNotReturnList)
            {

                GoodsNotReturnDataSet.GoodsNotReturnDetailRow row = _goodsNotReturnDetailDataTable.NewGoodsNotReturnDetailRow();

                // NO.
                rowNo = rowNo + 1;
                row.RowNo = rowNo;
                // 商品番号
                row.ProductNo = work.GoodsNo;
                // 商品名称
                row.GoodsName = work.GoodsName;
                // メーカー名称
                row.Manufacturer = work.MakerName;
                // 出荷数
                double shipmentCnt = work.ShipmentCnt;
                row.ShipmentNo = shipmentCnt;
                // 返品済数
                double acptAnOdrRemainCnt = work.AcptAnOdrRemainCnt;
                double returnNo = shipmentCnt - acptAnOdrRemainCnt;
                row.ReturnNo = returnNo;
                // 返品上限数
                row.LimitReturnNo = work.RetUpperCnt;
                // 受注ステータス
                row.AcptAnOdrStatus = work.AcptAnOdrStatus;
                // 売上明細通番
                row.SalesSlipDtlNum = work.SalesSlipDtlNum;
                // 更新日時
                row.UpdateTime = work.UpdateDateTime;
                // 取得した売上明細情報．売上伝票区分（明細）が「2：値引」の場合、明細部分に表示しない；
                if (work.SalesSlipCdDtl != 2 && work.ShipmentCnt >= 0 && work.DtlLogicalDeleteCode == 0)
                {
                    _goodsNotReturnDetailDataTable.Rows.Add(row);
                    goodsNotReturnListTmp.Add(work);
                }
                else
                {
                    rowNo = rowNo - 1;
                }

                if (rowNo == 99)
                {
                    break;
                }
            }
            return goodsNotReturnListTmp;
        }

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行います。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.01</br> 
        /// </remarks>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行います。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.01</br> 
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
