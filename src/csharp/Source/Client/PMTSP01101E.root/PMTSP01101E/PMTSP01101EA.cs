using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;


namespace Broadleaf.Application.UIData
{


    /// public class name:   TspServiceDataManager
    /// <summary>
    ///                      TSPサービスデータマネージャー
    /// </summary>
    /// <remarks>
    /// <br>note             :   TSPサービスで使用する各種データとデータ操作を提供する</br>
    /// <br>Programmer       :   32470 小原</br>
    /// <br>Date             :   2020/12/01</br>
	/// <br>				 :	 1.TSPインラインの自動受信モード時に指示書番号を指定して受信できるように変更</br>
	/// </remarks>
    /// 
    [XmlInclude(typeof(TspServiceDataManager))]
    public class TspServiceDataManager
    {

        // アクセスチケット
        /// <summary>
        /// アクセスチケット
        /// </summary>
        public string AccessTicket = "";

        // 検索条件

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string EnterpriseCode = "";

		/// <summary>指示書番号</summary>
		public string InstSlipNoStr = "";
 
        /// public propaty name  :  Status
        /// <summary>処理ステータス</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEBサービス問い合わせの処理ステータス</br>
        /// <br>Programer        :   小原</br>
        /// </remarks>
        public int Status;

        // 処理ステータスメッセージ

        // 
        /// public propaty name  :  TspServiceDataList
        /// <summary>TSPサービスデータリスト</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSPサービスデータのリスト</br>
        /// <br>Programer        :   小原</br>
        /// </remarks>
        public TspServiceData[] TspServiceDataList;


        /// public propaty name  :  ResultTspRequestList
        /// <summary>実行結果 TSP問合せデータ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送受信データ更新、削除時等に TspServiceDataList 内の各オブジェクトに対する結果セットを返します</br>
        /// </remarks>
        public TspRequest[] ResultTspRequestList;


        /// public propaty name  :  Message
        /// <summary>処理メッセージ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理メッセージ</br>
        /// <br>Programer        :   小原</br>
        /// </remarks>
        public string Message;


        #region コンストラクタ


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TspServiceDataManager()
        {
    
    
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tspServiceData">TSPサービスデータ</param>
        public TspServiceDataManager(TspServiceData tspServiceData)
        {

            this.Status = 0;
            this.TspServiceDataList = new TspServiceData[1];
            this.TspServiceDataList[0] = tspServiceData;

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tspServiceDataList">TSPサービスデータリスト</param>
        public TspServiceDataManager(TspServiceData[] tspServiceDataList)
        {
            this.Status = 0;
            this.TspServiceDataList = tspServiceDataList;

        }


        #endregion コンストラクタ

        /// <summary>
        /// TSP通信番号リスト取得
        /// </summary>
        /// <remarks>
        /// 現在保持しているTSPサービスデータリストからTSP通信番号のみを抽出してリスト化します
        /// </remarks>
        /// <returns>TSP通信番号リスト</returns>
        public int[] GetTspCommNoList()
        { 
            ArrayList al = new ArrayList();

            foreach (TspServiceData dtl in this.TspServiceDataList)
            {
                al.Add(dtl.TspSdRvData.TspCommNo);
            }

            return (int[])al.ToArray(typeof(int));
        }


        /// <summary>
        /// TSP問合せデータ リスト取得
        /// </summary>
        /// <remarks>
        /// 現在保持しているTSPサービスデータリストからTSP問合せデータの項目のみを抽出してリスト化します
        /// </remarks>
        /// <returns>TSP通信番号リスト</returns>
        public TspRequest[] GetTspRequestList()
        {
            
            ArrayList al = new ArrayList();
            TspRequest tspReq = null;

            foreach (TspServiceData dtl in this.TspServiceDataList)
            {
                tspReq = new TspRequest();
                tspReq.EnterpriseCode = dtl.TspSdRvData.EnterpriseCode;
                if(tspReq.EnterpriseCode.Trim().Equals(""))
                {
                    tspReq.EnterpriseCode = EnterpriseCode;
                }

                tspReq.PmEnterpriseCode = dtl.TspSdRvData.PmEnterpriseCode;
                tspReq.TspCommNo = dtl.TspSdRvData.TspCommNo;
                tspReq.CommConditionDivCd = dtl.TspSdRvData.CommConditionDivCd;

                al.Add(tspReq);
            }

            return (TspRequest[])al.ToArray(typeof(TspRequest));
        }


    }

     
    /// public class name:   TspServiceData
    /// <summary>
    ///                      TSPサービスデータ
    /// </summary>
    /// <remarks>
    /// <br>note             :   TSPサービスで使用する各種データとデータ操作を提供する</br>
    /// <br>Programmer       :   32470 小原</br>
    /// <br>Date             :   2020/12/01</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    /// 
    [XmlInclude(typeof(TspServiceData))]
    public class TspServiceData
    {

        // TSP送受信データクラス
        /// public propaty name  :  TspSdRvData
        /// <summary>TSP送受信データクラス</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP送受信データクラス</br>
        /// </remarks>
        public TspSdRvDt TspSdRvData;

        
        /// public propaty name  :  TspSdRvData
        /// <summary>TSP送受信明細データクラス</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP送受信明細データクラス</br>
        /// </remarks>
        public TspSdRvDtl[] TspSdRvDtlDataList;


        /// <summary>
        /// 処理ステータス(このデータに対して登録、更新、削除等を行った際の処理結果ステータスが入っています)
        /// </summary>
        public int ResultStatus = 0;

         
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TspServiceData()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tspSdRvData">TSP送受信データ</param>
        /// <param name="tspSdRvDtlList">TSP送受信明細データ</param>
        public TspServiceData(TspSdRvDt tspSdRvData, TspSdRvDtl[] tspSdRvDtlList)
        {
            this.TspSdRvData = tspSdRvData;
            this.TspSdRvDtlDataList = tspSdRvDtlList;
            this.ResultStatus = 0;
        }

        #endregion コンストラクタ

    }



}
