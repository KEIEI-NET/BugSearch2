using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using Broadleaf.Application.Partsman.WebService.TSPService;
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Data;


namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// .NS TSPサービスクライアントプロキシ
    /// </summary>
    /// <remarks>
    /// <br>Note       : WEBサービスクライアントプロキシのラッパーです</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/12/01</br>
    /// </remarks>
    public class NSTspService : TspService
    {

        // WEBサービスクライアントプロキシのURLを指定するために本クラスを定義しています
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serviceURL"></param>
        public NSTspService(string serviceURL)
        {
            // URL指定
            this.Url = serviceURL;
        }
        #endregion

    }

    /// <summary>
    /// TSPサービスクライアント(PM側)
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP WEBサービスへ接続するクライアントプロキシ</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/12/01</br>
    /// </remarks>
    public class TSPServiceClientForPM
    {
        #region 定数
        private const string XML_FILE_NAME = "PMTSP01102A_UserSetting.xml";
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TSPServiceClientForPM()
        {

            //
            // ここで接続する URLを取得して _ServiceURL へセットします       
            // 後日、何らかのローカル設定ファイルを検索して、そのファイルからURLを取得できる場合は
            // 取得したURLで接続できるようにする(設定ファイルが無い場合はデフォルト設定で接続)
            //
            _DefaultPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME);
            try
            {
                if (UserSettingController.ExistUserSetting(_DefaultPath))
                {
                    DataSet UiDataSet = new DataSet();
                    UiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, _DefaultPath));
                    _ServiceURL = UiDataSet.Tables["UserSettingInfo"].Rows[0][0].ToString();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("サービス接続ファイルが定義されていますが読み込めません\n"+e.Message+"\n"+e.StackTrace);

                // 誤送信防止
                _ServiceURL = string.Empty;
            }

        }

        #endregion


        #region private メンバ

        private string _DefaultPath = "TspDefault";

        /// <summary>
        /// WEBサービスURL
        /// </summary>
//		private string _ServiceURL = "http://www40.superfrontman.net/TSPROOT/TspService.asmx"; // テストサーバ
        private string _ServiceURL = "https://tsp.nsblcloud.jp/TSPROOT/TspService.asmx";
        #endregion


        //
        //  以下の public メソッドで TspServicePM.CS 内に定義されたプロキシクラスの
        // 各種メンバ･メソッドにアクセスします。 
        //

        #region public メソッド

        /// <summary>
        /// TSPサービス PM側データ送信
        /// </summary>
        /// <param name="tspServiceDataManager">送信対象 TSP送受信データ管理クラス</param>
        /// <returns>送信結果 0:成功, -1:送信エラー, -99:DB接続エラー</returns>
        public int SendPMTspData(Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager)
        {


            TspServiceDataManagerWork tsDM = ConvertToTspServiceDataManager(tspServiceDataManager);

            // 以下の2行処理を別スレッドで実行します(コード量はかなり増加します.....)
            // Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);
            // int st = tspService.SendPMTspData(tsDM);
            
            // 処理スレッド実行(接続タイムアウトを計るためにスレッド処理を行っています)
            #region スレッド実行          
            int st = 0;
            AutoResetEvent ev = new AutoResetEvent(false);
			TSPServiceThreadInfo ti = new TSPServiceThreadInfo();

			// スレッドを生成
			ti.Handle = ThreadPool.RegisterWaitForSingleObject(
				ev,
				new WaitOrTimerCallback(SendPMTspDataThread),
				ti,
				120000, // 2分間のタイムアウト待ち
				false
				);

            // スレッドへ各種パラメータを渡す
            ti.parmObj1        = tsDM;   // 送信対象 TSP受信データ
			ti.Complete        = false;
			ti.TimeOut         = false;

            // スレッド実行
			ev.Set();
			while(true) 
			{
				Thread.Sleep(1000);
                // 処理が成功するかタイムアウトが発生するまでループ
				if((ti.TimeOut) || (ti.Complete))
				{
					ev.Reset();
					break;
				}
            }

            #endregion 

            #region スレッドからの戻り値の判定
            if (ti.Complete)
			{
                //---- スレッド処理の正常終了(WEBサーバの処理の成功はパラメータのステータスで判断)

                // データの転記処理
                tsDM = (TspServiceDataManagerWork)ti.parmObj1;
                Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager2;
                tspServiceDataManager2 = ConvertToUITspServiceDataManager(tsDM);

                tspServiceDataManager.ResultTspRequestList = tspServiceDataManager2.ResultTspRequestList;
                tspServiceDataManager.TspServiceDataList = tspServiceDataManager2.TspServiceDataList;

                st = tsDM.Status;
            }
			else if(ti.TimeOut)
            {
                //---- 処理タイムアウト
                tsDM = new TspServiceDataManagerWork();
                tsDM.Status = TSPServiceMessageHelperForPM.STATUS_SERVICE_TIMEOUT;
                st = tsDM.Status;
                tspServiceDataManager.Status = st;
                tspServiceDataManager.Message = TSPServiceMessageHelperForPM.GetMessage(st);
            }
			else
			{
                //---- その他エラー
                tsDM = new TspServiceDataManagerWork();
                tsDM.Status = TSPServiceMessageHelperForPM.STATUS_SYSTEM_ERROR;
                st = tsDM.Status;
                tspServiceDataManager.Status = st;
                tspServiceDataManager.Message = TSPServiceMessageHelperForPM.GetMessage(st);
            }
            #endregion

            return st;
        }


        /// <summary>
        /// TSPサービス PM側データ受信(2006.10.27現在 使用されていません)
        /// </summary>
        /// <param name="tspServiceDataManager">受信対象 TSP送受信データ管理クラス</param>
        /// <returns>受信結果(TSP送受信データ管理クラス)</returns>
        public Broadleaf.Application.UIData.TspServiceDataManager ReceivePMTspData(Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager)
        {

            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            TspServiceDataManagerWork rTsDM = null;
            Broadleaf.Application.UIData.TspServiceDataManager rUITsDM = null;
            TspServiceDataManagerWork tsDM = ConvertToTspServiceDataManager(tspServiceDataManager);


            rTsDM = tspService.RecivePMTspData(tsDM);

            if (rTsDM != null)
            {
                rUITsDM = ConvertToUITspServiceDataManager(rTsDM);
            }

            if (rUITsDM == null)
            {
                rUITsDM = new Broadleaf.Application.UIData.TspServiceDataManager();
                rUITsDM.Status = -1;
            }


            // 処理ステータスに対するメッセージを作成する
            rUITsDM.Message = MakeStatusMessage(rUITsDM);
            return rUITsDM;

        }

        /// <summary>
        /// TSPサービス PM側送受信データ ステータス変更(通信状態区分)
        /// </summary>
        /// <param name="statusMode">変更ステータス(通信状態区分)</param>
        /// <param name="tspRequestList">変更対象TSP送受信データを指定するTSP問合せクラス</param>
        /// <returns>処理結果 0:成功, -1:エラー</returns>
        public int ChangeStatusPMTspData(Int32 statusMode, Broadleaf.Application.UIData.TspRequest[] tspRequestList)
        {
            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            int st = tspService.ChangeStatusPMTspData(statusMode, ConvertToTspRequestWork(tspRequestList));

            return st;

        }


        /// <summary>
        /// TSPサービス PM側 TSP送受信データ照会
        /// </summary>
        /// <param name="tspRequestList">照会するTSP送受信データを指定するTSP問合せクラス(照会結果もここにセットされます)</param>
        /// <returns>照会結果 0:成功, -1:照会エラー, 4:照会データ無し </returns>
        public int InquiryPMTspData(ref Broadleaf.Application.UIData.TspRequest[] tspRequestList)
        {
            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            TspRequestWork[] parm = ConvertToTspRequestWork(tspRequestList);

            int st = tspService.InquiryPMTspDataEx(ref parm);


            tspRequestList = ConvertToTspRequest(parm);
            return st;
        }


        /// <summary>
        /// TSPサービス PM側 TSP送受信データ削除
        /// </summary>
        /// <param name="tspRequestList">削除対象TSP送受信データを指定するTSP問合せクラス</param>
        /// <returns>処理結果 0:成功 -1:削除エラー</returns>
        public int DeletePMTspData(Broadleaf.Application.UIData.TspRequest[] tspRequestList)
        {
            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            TspRequestWork[] tspRequestWorkList = ConvertToTspRequestWork(tspRequestList);

            int st = tspService.DeletePMTspData(ref tspRequestWorkList);

            tspRequestList = ConvertToTspRequest(tspRequestWorkList);

            return st;
        }

        #endregion


        #region privateメソッド
        /// <summary>
        /// TSPサービス PM側データ送信スレッド処理
        /// </summary>
        /// <param name="state"></param>
        /// <param name="timedOut"></param>
        private void SendPMTspDataThread(object state, bool timedOut)
        {

            TSPServiceThreadInfo ti = (TSPServiceThreadInfo)state;
            TspServiceDataManagerWork tsDM = (TspServiceDataManagerWork)ti.parmObj1;

            if (!timedOut)
            {

                # region TSPサービス PM側データ送信
                int st = -1;
                ti.Status = -1;

                Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);
                st = tspService.SendPMTspData(tsDM);

                # endregion リサイクルパーツ検索

                // 検索処理が終了したらフラグセット
                ti.Status = st;
                ti.Complete = true;
                ti.parmObj1 = tsDM;

                if (ti.Complete)
                {
                    if (ti.Handle != null)
                    {
                        ti.Handle.Unregister(null);
                    }
                }

            }
            else
            {

                ti.Status = TSPServiceMessageHelperForPM.STATUS_SERVICE_TIMEOUT;   // タイムアウト
                ti.Complete = false;
                ti.TimeOut = true;
                ti.parmObj1 = tsDM;

                if (ti.Handle != null)
                {
                    ti.Handle.Unregister(null);
                }

            }


        }

        #endregion privateメソッド

        //
        // 各種データコンバータ について 
        //
        // 今回のTSP WEBサービス処理では、WEBサービスとクライアント間でやり取りされるパラメータ(クラス)
        // とは別に各種UI側で使用されるクラスを定義して使用しています(プロパティ等の構造はほぼ一緒です)。
        //
        // このためWEBサービスで使用しているパラメータに変更がある場合は、
        //
        //  (1)WEBサービスのパラメータの変更、
        //  (2)UI側クラスの変更, 
        //  (3)WEBサービスクライアントプロキシの再生成, 
        //  (4) WEBサービスのパラメータ <---> UI側クラス のデータコンバータ修正
        //
        //  以上の修正が必要となります。
        //  本来であれば、UI側も(3)で自動生成されたパラメータクラスを使用することで、
        // (2),(4)を省くことも可能ですが、今回は、1つのWEBサービスに対して、異なるバージョンの
        // WEBサービスクライアントが存在することを前提に作成していますので、このような
        // 冗長な処理が必要となってきます。
        //
        //  具体的には、WEBサービスとクライアントのバージョンの差(パラメータの相違)を
        // 本クラスと以下のデータコンバータで吸収することで、WEBサービスは常に最新のもののみが
        // 提供され、クライアントはWEBサービスのバージョンを意識する必要がなくなります。 
        // 
        // 当社の文化的にはWEBサービスの変更と共にクライアントも全バージョン一斉に修正
        // するような事が多いのですが、MS社のアーキテクトが採用している手法が上記
        // のものに近かったのでこの手法を採用しています 
        //

        #region 各種データコンバータ

        /// <summary>
        /// TspServiceDataManagerWork --> TspServiceDataManager コンバート
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private TspServiceDataManagerWork ConvertToTspServiceDataManager(Broadleaf.Application.UIData.TspServiceDataManager source)
        {

            TspSdRvDtWork tspDt;
            TspSdRvDtlWork tspDtl;
            TspServiceDataWork tsd;
            TspServiceDataManagerWork tsDM;
            TspServiceDataWork[] tsdList;

            tspDt = new TspSdRvDtWork();
            tspDtl = new TspSdRvDtlWork();

            TspSdRvDtlWork[] tspDtlLst = new TspSdRvDtlWork[1];
            tspDtlLst[0] = tspDtl;

            tsd = new TspServiceDataWork();
            tsd.TspSdRvData = tspDt;
            tsd.TspSdRvDtlDataList = tspDtlLst;
            tsdList = new TspServiceDataWork[1];
            tsdList[0] = tsd;

            tsDM = new TspServiceDataManagerWork();
            tsDM.TspServiceDataList = tsdList;

            if (source != null)
            {
                tsDM.EnterpriseCode = source.EnterpriseCode;
                tsDM.Message = source.Message;
                tsDM.TspServiceDataList = ConvertToTspServiceData(source.TspServiceDataList);
            }

            return tsDM;
        }

        /// <summary>
        /// TspServiceDataManager -->  TspServiceDataManagerWorkコンバート
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Broadleaf.Application.UIData.TspServiceDataManager ConvertToUITspServiceDataManager(TspServiceDataManagerWork source)
        {

            Broadleaf.Application.UIData.TspSdRvDt tspDt;
            Broadleaf.Application.UIData.TspSdRvDtl tspDtl;
            Broadleaf.Application.UIData.TspServiceData tsd;
            Broadleaf.Application.UIData.TspServiceDataManager tsDM = null;
            Broadleaf.Application.UIData.TspServiceData[] tsdList;

            tspDt = new Broadleaf.Application.UIData.TspSdRvDt();
            tspDtl = new Broadleaf.Application.UIData.TspSdRvDtl();

            Broadleaf.Application.UIData.TspSdRvDtl[] tspDtlLst = new Broadleaf.Application.UIData.TspSdRvDtl[1];
            tspDtlLst[0] = tspDtl;

            tsd = new Broadleaf.Application.UIData.TspServiceData();
            tsd.TspSdRvData = tspDt;
            tsd.TspSdRvDtlDataList = tspDtlLst;
            tsdList = new Broadleaf.Application.UIData.TspServiceData[1];
            tsdList[0] = tsd;

            tsDM = new Broadleaf.Application.UIData.TspServiceDataManager();
            tsDM.TspServiceDataList = tsdList;


            if (source != null)
            {
                tsDM.Status = source.Status;
                tsDM.EnterpriseCode = source.EnterpriseCode;
                tsDM.Message = source.Message;

                tsDM.TspServiceDataList = ConvertToUITspServiceData(source.TspServiceDataList);

                // 処理ステータスの転記
                ArrayList al = new ArrayList();
                Broadleaf.Application.UIData.TspRequest tspRequest = null;

                if (tsDM.TspServiceDataList != null)
                {

                    foreach (Broadleaf.Application.UIData.TspServiceData tspServiceData in tsDM.TspServiceDataList)
                    {
                        if (tspServiceData.TspSdRvData != null)
                        {

                            tspRequest = new Broadleaf.Application.UIData.TspRequest();
                            tspRequest.TspCommCount = tspServiceData.TspSdRvData.TspCommCount;
                            tspRequest.EnterpriseCode = tspServiceData.TspSdRvData.EnterpriseCode;
                            tspRequest.PmEnterpriseCode = tspServiceData.TspSdRvData.PmEnterpriseCode;
                            tspRequest.TspCommNo = tspServiceData.TspSdRvData.TspCommNo;
                            tspRequest.CommConditionDivCd = tspServiceData.TspSdRvData.CommConditionDivCd;
                            al.Add(tspRequest);
                        }

                    }
                }

                tsDM.ResultTspRequestList = (Broadleaf.Application.UIData.TspRequest[])al.ToArray(typeof(Broadleaf.Application.UIData.TspRequest));

            
            }
            else
            {
                ArrayList al = new ArrayList();
                tsDM.ResultTspRequestList = (Broadleaf.Application.UIData.TspRequest[])al.ToArray(typeof(Broadleaf.Application.UIData.TspRequest));
            }


            return tsDM;

        }


        /// <summary>
        /// TspServiceDataWork --> TspServiceData コンバート
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Broadleaf.Application.UIData.TspServiceData ConvertToUITspServiceData(TspServiceDataWork source)
        {

            Broadleaf.Application.UIData.TspSdRvDt tspHead;
            Broadleaf.Application.UIData.TspSdRvDtl tspDtl;
            Broadleaf.Application.UIData.TspServiceData tspSData;

            tspHead = new Broadleaf.Application.UIData.TspSdRvDt();
            TspSdRvDtWork sourceHead = source.TspSdRvData;

            tspHead.CreateDateTime = sourceHead.CreateDateTime; // 作成日時
            tspHead.UpdateDateTime = sourceHead.UpdateDateTime; // 更新日時
            tspHead.EnterpriseCode = sourceHead.EnterpriseCode; // 企業コード
            tspHead.FileHeaderGuid = sourceHead.FileHeaderGuid; // GUID
            tspHead.UpdEmployeeCode = sourceHead.UpdEmployeeCode; // 更新従業員コード
            tspHead.UpdAssemblyId1 = sourceHead.UpdAssemblyId1; // 更新アセンブリID1
            tspHead.UpdAssemblyId2 = sourceHead.UpdAssemblyId2; // 更新アセンブリID2
            tspHead.LogicalDeleteCode = sourceHead.LogicalDeleteCode; // 論理削除区分
            tspHead.PmEnterpriseCode = sourceHead.PmEnterpriseCode; // PM企業コード
            tspHead.TspCommNo = sourceHead.TspCommNo; // TSP通信番号
            tspHead.TspCommCount = sourceHead.TspCommCount; // TSP通信回数
            tspHead.OrderContentsDivCd = sourceHead.OrderContentsDivCd; // 発注内容区分
            tspHead.InstSlipNoStr = sourceHead.InstSlipNoStr; // 指示書番号（文字列）
            tspHead.AcceptAnOrderNo = sourceHead.AcceptAnOrderNo; // 受注番号
            tspHead.DataInputSystem = sourceHead.DataInputSystem; // データ入力システム
            tspHead.SlipNo = sourceHead.SlipNo; // 伝票番号
            tspHead.SlipKind = sourceHead.SlipKind; // 伝票種別
            tspHead.CommConditionDivCd = sourceHead.CommConditionDivCd; // 通信状態区分
            tspHead.NumberPlate1Code = sourceHead.NumberPlate1Code; // 陸運事務所番号
            tspHead.NumberPlate1Name = sourceHead.NumberPlate1Name; // 陸運事務局名称
            tspHead.NumberPlate2 = sourceHead.NumberPlate2; // 車両登録番号（種別）
            tspHead.NumberPlate3 = sourceHead.NumberPlate3; // 車両登録番号（カナ）
            tspHead.NumberPlate4 = sourceHead.NumberPlate4; // 車両登録番号（プレート番号）
            tspHead.ModelDesignationNo = sourceHead.ModelDesignationNo; // 型式指定番号
            tspHead.CategoryNo = sourceHead.CategoryNo; // 類別番号
            tspHead.MakerCode = sourceHead.MakerCode; // メーカーコード
            tspHead.ModelCode = sourceHead.ModelCode; // 車種コード
            tspHead.ModelSubCode = sourceHead.ModelSubCode; // 車種サブコード
            tspHead.ModelName = sourceHead.ModelName; // 車種名
            tspHead.CarInspectCertModel = sourceHead.CarInspectCertModel; // 車検証型式
            tspHead.FullModel = sourceHead.FullModel; // 型式（フル型）
            tspHead.FrameNo = sourceHead.FrameNo; // 車台番号
            tspHead.FrameModel = sourceHead.FrameModel; // 車台型式
            tspHead.ChassisNo = sourceHead.ChassisNo; // シャシーNo
            tspHead.CarProperNo = sourceHead.CarProperNo; // 車両固有番号
            tspHead.ProduceTypeOfYearNum = sourceHead.ProduceTypeOfYearNum; // 生産年式（NUMタイプ）
            tspHead.SalesOrderDate = sourceHead.SalesOrderDate; // 発注日
            tspHead.SalesOrderEmployeeCd = sourceHead.SalesOrderEmployeeCd; // 発注者従業員コード
            tspHead.SalesOrderEmployeeNm = sourceHead.SalesOrderEmployeeNm; // 発注者従業員名称
            tspHead.SalesOrderComment = sourceHead.SalesOrderComment; // 発注時コメント
            tspHead.OrderSideSystemVerCd = sourceHead.OrderSideSystemVerCd; // 発注側システムバージョン区分
            tspHead.TspAnswerDataMngNo = sourceHead.TspAnswerDataMngNo; // TSP回答データ管理番号
            tspHead.TspSlipType = sourceHead.TspSlipType; // TSP伝票タイプ
            tspHead.AcceptAnOrderDate = sourceHead.AcceptAnOrderDate; // 受注日
            tspHead.PmSlipNo = sourceHead.PmSlipNo; // PM伝票番号
            tspHead.AcceptAnOrderNm = sourceHead.AcceptAnOrderNm; // 受注者名
            tspHead.TspTotalSlipPrice = sourceHead.TspTotalSlipPrice; // TSP伝票合計金額
            tspHead.PmComment = sourceHead.PmComment; // PMコメント
            tspHead.PmVersion = sourceHead.PmVersion; // PMバージョン
            tspHead.PmSendDate = sourceHead.PmSendDate; // PM送信日
            tspHead.PmSlipKind = sourceHead.PmSlipKind; // PM伝票種別
            tspHead.PmOriginalSlipNo = sourceHead.PmOriginalSlipNo; // PM元黒伝票番号

            ArrayList al = new ArrayList();

            foreach (TspSdRvDtlWork sourcedtl in source.TspSdRvDtlDataList)
            {

                tspDtl = new Broadleaf.Application.UIData.TspSdRvDtl();

                tspDtl.CreateDateTime = sourcedtl.CreateDateTime; // 作成日時
                tspDtl.UpdateDateTime = sourcedtl.UpdateDateTime; // 更新日時
                tspDtl.EnterpriseCode = sourcedtl.EnterpriseCode; // 企業コード
                tspDtl.FileHeaderGuid = sourcedtl.FileHeaderGuid; // GUID
                tspDtl.UpdEmployeeCode = sourcedtl.UpdEmployeeCode; // 更新従業員コード
                tspDtl.UpdAssemblyId1 = sourcedtl.UpdAssemblyId1; // 更新アセンブリID1
                tspDtl.UpdAssemblyId2 = sourcedtl.UpdAssemblyId2; // 更新アセンブリID2
                tspDtl.LogicalDeleteCode = sourcedtl.LogicalDeleteCode; // 論理削除区分
                tspDtl.PmEnterpriseCode = sourcedtl.PmEnterpriseCode; // PM企業コード
                tspDtl.TspCommNo = sourcedtl.TspCommNo; // TSP通信番号
                tspDtl.TspCommCount = sourcedtl.TspCommCount; // TSP通信回数
                tspDtl.TspCommRowNo = sourcedtl.TspCommRowNo; // TSP通信行番号
                tspDtl.DeliveredGoodsDiv = sourcedtl.DeliveredGoodsDiv; // 納品区分
                tspDtl.HandleDivCode = sourcedtl.HandleDivCode; // 取扱区分
                tspDtl.PartsShape = sourcedtl.PartsShape; // 部品形態
                tspDtl.DelivrdGdsConfCd = sourcedtl.DelivrdGdsConfCd; // 納品確認区分
                tspDtl.DeliGdsCmpltDueDate = sourcedtl.DeliGdsCmpltDueDate; // 納品完了予定日
                tspDtl.TbsPartsCode = sourcedtl.TbsPartsCode; // 翼部品コード
                tspDtl.PmPartsNameKana = sourcedtl.PmPartsNameKana; // PM部品名（カナ）
                tspDtl.SalesOrderCount = sourcedtl.SalesOrderCount; // 発注数
                tspDtl.DeliveredGoodsCount = sourcedtl.DeliveredGoodsCount; // 納品数
                tspDtl.PartsNoWithHyphen = sourcedtl.PartsNoWithHyphen; // ハイフン付品番
                tspDtl.PmPartsMakerCode = sourcedtl.PmPartsMakerCode; // PM部品メーカーコード
                tspDtl.PurePartsMakerCode = sourcedtl.PurePartsMakerCode; // 純正部品メーカーコード
                tspDtl.PurePrtsNoWithHyphen = sourcedtl.PurePrtsNoWithHyphen; // 純正ハイフン付品番
                tspDtl.ListPrice = sourcedtl.ListPrice; // 定価
                tspDtl.UnitPrice = sourcedtl.UnitPrice; // 単価
                tspDtl.PmDtlTakeinDivCd = sourcedtl.PmDtlTakeinDivCd; // PM明細取込区分


                al.Add(tspDtl);
            }

            Broadleaf.Application.UIData.TspSdRvDtl[] dtlList = (Broadleaf.Application.UIData.TspSdRvDtl[])al.ToArray(typeof(Broadleaf.Application.UIData.TspSdRvDtl));
            tspSData = new Broadleaf.Application.UIData.TspServiceData(tspHead.Clone(), dtlList);
            tspSData.ResultStatus = source.ResultStatus;

            return tspSData;

        }



        /// <summary>
        /// TspServiceData --> TspServiceDataWork コンバート
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private TspServiceDataWork ConvertToTspServiceData(Broadleaf.Application.UIData.TspServiceData source)
        {

            TspSdRvDtWork tspHead;
            TspSdRvDtlWork tspDtl;
            TspServiceDataWork tspSData;

            tspHead = new TspSdRvDtWork();
            Broadleaf.Application.UIData.TspSdRvDt sourceHead = source.TspSdRvData;

            tspHead.CreateDateTime = sourceHead.CreateDateTime; // 作成日時
            tspHead.UpdateDateTime = sourceHead.UpdateDateTime; // 更新日時
            tspHead.EnterpriseCode = sourceHead.EnterpriseCode; // 企業コード
            tspHead.FileHeaderGuid = sourceHead.FileHeaderGuid; // GUID
            tspHead.UpdEmployeeCode = sourceHead.UpdEmployeeCode; // 更新従業員コード
            tspHead.UpdAssemblyId1 = sourceHead.UpdAssemblyId1; // 更新アセンブリID1
            tspHead.UpdAssemblyId2 = sourceHead.UpdAssemblyId2; // 更新アセンブリID2
            tspHead.LogicalDeleteCode = sourceHead.LogicalDeleteCode; // 論理削除区分
            tspHead.PmEnterpriseCode = sourceHead.PmEnterpriseCode; // PM企業コード
            tspHead.TspCommNo = sourceHead.TspCommNo; // TSP通信番号
            tspHead.TspCommCount = sourceHead.TspCommCount; // TSP通信回数
            tspHead.OrderContentsDivCd = sourceHead.OrderContentsDivCd; // 発注内容区分
            tspHead.InstSlipNoStr = sourceHead.InstSlipNoStr; // 指示書番号（文字列）
            tspHead.AcceptAnOrderNo = sourceHead.AcceptAnOrderNo; // 受注番号
            tspHead.DataInputSystem = sourceHead.DataInputSystem; // データ入力システム
            tspHead.SlipNo = sourceHead.SlipNo; // 伝票番号
            tspHead.SlipKind = sourceHead.SlipKind; // 伝票種別
            tspHead.CommConditionDivCd = sourceHead.CommConditionDivCd; // 通信状態区分
            tspHead.NumberPlate1Code = sourceHead.NumberPlate1Code; // 陸運事務所番号
            tspHead.NumberPlate1Name = sourceHead.NumberPlate1Name; // 陸運事務局名称
            tspHead.NumberPlate2 = sourceHead.NumberPlate2; // 車両登録番号（種別）
            tspHead.NumberPlate3 = sourceHead.NumberPlate3; // 車両登録番号（カナ）
            tspHead.NumberPlate4 = sourceHead.NumberPlate4; // 車両登録番号（プレート番号）
            tspHead.ModelDesignationNo = sourceHead.ModelDesignationNo; // 型式指定番号
            tspHead.CategoryNo = sourceHead.CategoryNo; // 類別番号
            tspHead.MakerCode = sourceHead.MakerCode; // メーカーコード
            tspHead.ModelCode = sourceHead.ModelCode; // 車種コード
            tspHead.ModelSubCode = sourceHead.ModelSubCode; // 車種サブコード
            tspHead.ModelName = sourceHead.ModelName; // 車種名
            tspHead.CarInspectCertModel = sourceHead.CarInspectCertModel; // 車検証型式
            tspHead.FullModel = sourceHead.FullModel; // 型式（フル型）
            tspHead.FrameNo = sourceHead.FrameNo; // 車台番号
            tspHead.FrameModel = sourceHead.FrameModel; // 車台型式
            tspHead.ChassisNo = sourceHead.ChassisNo; // シャシーNo
            tspHead.CarProperNo = sourceHead.CarProperNo; // 車両固有番号
            tspHead.ProduceTypeOfYearNum = sourceHead.ProduceTypeOfYearNum; // 生産年式（NUMタイプ）
            tspHead.SalesOrderDate = sourceHead.SalesOrderDate; // 発注日
            tspHead.SalesOrderEmployeeCd = sourceHead.SalesOrderEmployeeCd; // 発注者従業員コード
            tspHead.SalesOrderEmployeeNm = sourceHead.SalesOrderEmployeeNm; // 発注者従業員名称
            tspHead.SalesOrderComment = sourceHead.SalesOrderComment; // 発注時コメント
            tspHead.OrderSideSystemVerCd = sourceHead.OrderSideSystemVerCd; // 発注側システムバージョン区分
            tspHead.TspAnswerDataMngNo = sourceHead.TspAnswerDataMngNo; // TSP回答データ管理番号
            tspHead.TspSlipType = sourceHead.TspSlipType; // TSP伝票タイプ
            tspHead.AcceptAnOrderDate = sourceHead.AcceptAnOrderDate; // 受注日
            tspHead.PmSlipNo = sourceHead.PmSlipNo; // PM伝票番号
            tspHead.AcceptAnOrderNm = sourceHead.AcceptAnOrderNm; // 受注者名
            tspHead.TspTotalSlipPrice = sourceHead.TspTotalSlipPrice; // TSP伝票合計金額
            tspHead.PmComment = sourceHead.PmComment; // PMコメント
            tspHead.PmVersion = sourceHead.PmVersion; // PMバージョン
            tspHead.PmSendDate = sourceHead.PmSendDate; // PM送信日
            tspHead.PmSlipKind = sourceHead.PmSlipKind; // PM伝票種別
            tspHead.PmOriginalSlipNo = sourceHead.PmOriginalSlipNo; // PM元黒伝票番号


            ArrayList al = new ArrayList();

            foreach (Broadleaf.Application.UIData.TspSdRvDtl sourcedtl in source.TspSdRvDtlDataList)
            {

                tspDtl = new TspSdRvDtlWork();

                tspDtl.CreateDateTime = sourcedtl.CreateDateTime; // 作成日時
                tspDtl.UpdateDateTime = sourcedtl.UpdateDateTime; // 更新日時
                tspDtl.EnterpriseCode = sourcedtl.EnterpriseCode; // 企業コード
                tspDtl.FileHeaderGuid = sourcedtl.FileHeaderGuid; // GUID
                tspDtl.UpdEmployeeCode = sourcedtl.UpdEmployeeCode; // 更新従業員コード
                tspDtl.UpdAssemblyId1 = sourcedtl.UpdAssemblyId1; // 更新アセンブリID1
                tspDtl.UpdAssemblyId2 = sourcedtl.UpdAssemblyId2; // 更新アセンブリID2
                tspDtl.LogicalDeleteCode = sourcedtl.LogicalDeleteCode; // 論理削除区分
                tspDtl.PmEnterpriseCode = sourcedtl.PmEnterpriseCode; // PM企業コード
                tspDtl.TspCommNo = sourcedtl.TspCommNo; // TSP通信番号
                tspDtl.TspCommCount = sourcedtl.TspCommCount; // TSP通信回数
                tspDtl.TspCommRowNo = sourcedtl.TspCommRowNo; // TSP通信行番号
                tspDtl.DeliveredGoodsDiv = sourcedtl.DeliveredGoodsDiv; // 納品区分
                tspDtl.HandleDivCode = sourcedtl.HandleDivCode; // 取扱区分
                tspDtl.PartsShape = sourcedtl.PartsShape; // 部品形態
                tspDtl.DelivrdGdsConfCd = sourcedtl.DelivrdGdsConfCd; // 納品確認区分
                tspDtl.DeliGdsCmpltDueDate = sourcedtl.DeliGdsCmpltDueDate; // 納品完了予定日
                tspDtl.TbsPartsCode = sourcedtl.TbsPartsCode; // 翼部品コード
                tspDtl.PmPartsNameKana = sourcedtl.PmPartsNameKana; // PM部品名（カナ）
                tspDtl.SalesOrderCount = sourcedtl.SalesOrderCount; // 発注数
                tspDtl.DeliveredGoodsCount = sourcedtl.DeliveredGoodsCount; // 納品数
                tspDtl.PartsNoWithHyphen = sourcedtl.PartsNoWithHyphen; // ハイフン付品番
                tspDtl.PmPartsMakerCode = sourcedtl.PmPartsMakerCode; // PM部品メーカーコード
                tspDtl.PurePartsMakerCode = sourcedtl.PurePartsMakerCode; // 純正部品メーカーコード
                tspDtl.PurePrtsNoWithHyphen = sourcedtl.PurePrtsNoWithHyphen; // 純正ハイフン付品番
                tspDtl.ListPrice = sourcedtl.ListPrice; // 定価
                tspDtl.UnitPrice = sourcedtl.UnitPrice; // 単価
                tspDtl.PmDtlTakeinDivCd = sourcedtl.PmDtlTakeinDivCd; // PM明細取込区分


                al.Add(tspDtl);
            }

            TspSdRvDtlWork[] dtlList = (TspSdRvDtlWork[])al.ToArray(typeof(TspSdRvDtlWork));
            tspSData = new TspServiceDataWork(); //TspServiceDataWork(tspHead, dtlList);
            tspSData.TspSdRvData = tspHead;
            tspSData.TspSdRvDtlDataList = dtlList;
            tspSData.ResultStatus = source.ResultStatus;

            return tspSData;

        }



        /// <summary>
        /// TspServiceDataWork[] -->  TspServiceData[] コンバート
        /// </summary>
        /// <param name="source">TSPサービスデータマネージャWorkリスト</param>
        /// <returns>TSPサービスデータマネージャ リスト</returns>
        private Broadleaf.Application.UIData.TspServiceData[] ConvertToUITspServiceData(TspServiceDataWork[] source)
        {

            Broadleaf.Application.UIData.TspServiceData tspSData;
            ArrayList al = new ArrayList();
            foreach (TspServiceDataWork sourceData in source)
            {
                tspSData = ConvertToUITspServiceData(sourceData);
                al.Add(tspSData);
            }

            Broadleaf.Application.UIData.TspServiceData[] tspSDataList = (Broadleaf.Application.UIData.TspServiceData[])al.ToArray(typeof(Broadleaf.Application.UIData.TspServiceData));


            return tspSDataList;

        }


        /// <summary>
        /// TspServiceData[] -->  TspServiceDataWork[] コンバート
        /// </summary>
        /// <param name="source">TSPサービスデータマネージャ リスト</param>
        /// <returns>TSPサービスデータマネージャWorkリスト</returns>
        private TspServiceDataWork[] ConvertToTspServiceData(Broadleaf.Application.UIData.TspServiceData[] source)
        {

            TspServiceDataWork tspSData;
            ArrayList al = new ArrayList();
            foreach (Broadleaf.Application.UIData.TspServiceData sourceData in source)
            {
                tspSData = ConvertToTspServiceData(sourceData);
                al.Add(tspSData);
            }

            TspServiceDataWork[] tspSDataList = (TspServiceDataWork[])al.ToArray(typeof(TspServiceDataWork));


            return tspSDataList;

        }


        /// <summary>
        /// TSP問合せデータWork[] --> TSP問合せデータ[] コンバート
        /// </summary>
        /// <param name="source">TSP問合せデータWork リスト</param>
        /// <returns>TSP問合せデータ リスト</returns>
        private Broadleaf.Application.UIData.TspRequest[] ConvertToTspRequest(TspRequestWork[] source)
        {

            Broadleaf.Application.UIData.TspRequest tspSData;
            Broadleaf.Application.UIData.TspRequest[] tspSDataList = null;
            ArrayList al = new ArrayList();

            if (source != null)
            {
                foreach (TspRequestWork sourceData in source)
                {
                    tspSData = ConvertToTspRequest(sourceData);
                    al.Add(tspSData);
                }

                tspSDataList = (Broadleaf.Application.UIData.TspRequest[])al.ToArray(typeof(Broadleaf.Application.UIData.TspRequest));
            }

            return tspSDataList;

        }


        /// <summary>
        /// TSP問合せデータ --> TSP問合せデータWork コンバート
        /// </summary>
        /// <param name="tspRequest">TSP問合せデータWork </param>
        /// <returns>TSP問合せデータ </returns>
        private Broadleaf.Application.UIData.TspRequest ConvertToTspRequest(TspRequestWork tspRequest)
        {

            Broadleaf.Application.UIData.TspRequest resObj = new Broadleaf.Application.UIData.TspRequest();

            if (tspRequest != null)
            {
                resObj.CommConditionDivCd = tspRequest.CommConditionDivCd;
                resObj.EnterpriseCode = tspRequest.EnterpriseCode;
                resObj.PmEnterpriseCode = tspRequest.PmEnterpriseCode;
                resObj.TspCommNo = tspRequest.TspCommNo;
                resObj.TspCommCount = tspRequest.TspCommCount;
            }

            return resObj;
        }



        /// <summary>
        /// TSP問合せデータ[] --> TSP問合せデータWork[] コンバート
        /// </summary>
        /// <param name="source">TSP問合せデータ リスト</param>
        /// <returns>TSP問合せデータWork リスト</returns>
        private TspRequestWork[] ConvertToTspRequestWork(Broadleaf.Application.UIData.TspRequest[] source)
        {

            TspRequestWork tspSData;
            ArrayList al = new ArrayList();
            foreach (Broadleaf.Application.UIData.TspRequest sourceData in source)
            {
                tspSData = ConvertToTspRequestWork(sourceData);
                al.Add(tspSData);
            }

            TspRequestWork[] tspSDataList = (TspRequestWork[])al.ToArray(typeof(TspRequestWork));


            return tspSDataList;

        }


        /// <summary>
        /// TSP問合せデータ --> TSP問合せデータWork コンバート
        /// </summary>
        /// <param name="tspRequest">TSP問合せデータ</param>
        /// <returns>TSP問合せデータWork</returns>
        private TspRequestWork ConvertToTspRequestWork(Broadleaf.Application.UIData.TspRequest tspRequest)
        {

            TspRequestWork resObj = new TspRequestWork();

            if (tspRequest != null)
            {
                resObj.CommConditionDivCd = tspRequest.CommConditionDivCd;
                resObj.EnterpriseCode = tspRequest.EnterpriseCode;
                resObj.PmEnterpriseCode = tspRequest.PmEnterpriseCode;
                resObj.TspCommNo = tspRequest.TspCommNo;
                resObj.TspCommCount = tspRequest.TspCommCount;
            }

            return resObj;
        }



        /// <summary>
        /// ステータスメッセージ生成(このメソッドは旧処理の為に作成されたものです)
        /// エラーメッセージを取得する際は、TSPServiceMessageHelperForPM クラスの
        /// 各種定義、メソッドを使用してください
        /// </summary>
        /// <param name="tspServiceDataManager"></param>
        /// <returns>ステータスメッセージ</returns>
        private string MakeStatusMessage(Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager)
        {
            string messsageStr = "";

            int status = tspServiceDataManager.Status;
            switch (status)
            {
                case 0:
                    messsageStr = "TSP送受信処理は正常に行われました";
                    break;
                case 4:
                    messsageStr = "処理に該当するデータがありません";
                    break;
                case 9:
                    messsageStr = "TSP送受信データの一部は処理できませんでした";
                    break;
                case -9:
                    messsageStr = "TSP送受信データは取得できませんでした - 検索条件が不正です";
                    break;
                case -15:
                    messsageStr = "TSPサービスへ接続できません - ログイン情報が有効ではありません";
                    break;
                case -99:
                    messsageStr = "TSPサービスDBへ接続できません";
                    break;
                case -1:
                    messsageStr = "TSPサービス接続時に予期しないエラーが発生しました";
                    break;
                case 103:
                    messsageStr = "TSPサービスから接続テストデータが送受信されました" + "\n" + tspServiceDataManager.Message;
                    break;

                default:
                    break;
            }


            return messsageStr;
        }



        #endregion 各種データコンバータ


        #region innerクラス
        /// <summary>
        /// スレッド処理用状態遷移パラメータクラス
        /// </summary>
        private class TSPServiceThreadInfo
        {
            // 各種スレッドの状態と、処理パラメータを定義
            //
            // 汎用パラメータのような object型を 巨大なデータに対して使用すると
            // パフォーマンスが落ちるので、その場合は型定義したプロパティを別途
            // 準備して使用してください(今回はあまり大きなデータは扱わないのでこのまま使用)

            /// <summary>
            /// 
            /// </summary>
            public RegisteredWaitHandle Handle = null;
            /// <summary>
            /// 
            /// </summary>
            public bool TimeOut = false;
            /// <summary>
            /// 
            /// </summary>
            public bool Complete = false;
            /// <summary>
            /// 
            /// </summary>
            public object parmObj1 = null;   // 汎用パラメータ
            /// <summary>
            /// 
            /// </summary>
            public object parmObj2 = null;   // 汎用パラメータ
            /// <summary>
            /// 
            /// </summary>
            public object parmObj3 = null;   // 汎用パラメータ
            /// <summary>
            /// 
            /// </summary>
            public int Status = 0;

        }

        #endregion
    }



    /// <summary>
    /// TSPサービス メッセージヘルパー(PM)
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSPサービスの各種ステータスとメッセージを提供します</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/12/01</br>
    /// </remarks>
    public static class TSPServiceMessageHelperForPM
    {
        static TSPServiceMessageHelperForPM()
        { 
            // 静的クラスなのでインスタンス化は許可しません
        }

        /// <summary>
        /// ステータス 0:処理成功
        /// </summary>
        static public int STATUS_SUCCESS = ctSTATUS_SUCCESS;        // 処理成功

        /// <summary>
        /// ステータス 4:処理に該当するデータが無い
        /// </summary>
        static public int STATUS_DATA_NOT_FOUND = ctSTATUS_DATA_NOT_FOUND;        // データが見つからない

        /// <summary>
        /// ステータス 9:一部のデータに処理エラーが発生している
        /// </summary>
        static public int STATUS_DATA_ERROR_SUBSET = ctSTATUS_DATA_ERROR_SUBSET;        // データ一部エラー

        /// <summary>
        /// ステータス -9:検索条件が不正
        /// </summary>
        static public int STATUS_SEARCH_PARAM_UNENABLE = ctSTATUS_SEARCH_PARAM_UNENABLE;       // 検索条件が不正

        /// <summary>
        /// ステータス -99:DB接続エラー
        /// </summary>
        static public int STATUS_DB_ERROR = ctSTATUS_DB_ERROR;      // DB接続エラー

        /// <summary>
        /// ステータス -1:システムエラー(予期しないエラー)
        /// </summary>
        static public int STATUS_SYSTEM_ERROR = ctSTATUS_SYSTEM_ERROR;       // システムエラー

        /// <summary>
        /// ステータス -1:WEBサービス接続タイムアウト(予期しないエラー)
        /// </summary>
        static public int STATUS_SERVICE_TIMEOUT = ctSTATUS_SERVICE_TIMEOUT;       // タイムアウト

        /// <summary>
        /// ステータス 0:処理成功
        /// </summary>
        private const int ctSTATUS_SUCCESS = 0;        // 処理成功

        /// <summary>
        /// ステータス 4:処理に該当するデータが無い
        /// </summary>
        private const int ctSTATUS_DATA_NOT_FOUND = 4;        // データが見つからない

        /// <summary>
        /// ステータス 9:一部のデータに処理エラーが発生している
        /// </summary>
        private const int ctSTATUS_DATA_ERROR_SUBSET = 9;        // データ一部エラー

        /// <summary>
        /// ステータス -9:検索条件が不正
        /// </summary>
        private const int ctSTATUS_SEARCH_PARAM_UNENABLE = -9;       // 検索条件が不正

        /// <summary>
        /// ステータス -99:DB接続エラー
        /// </summary>
        private const int ctSTATUS_DB_ERROR = -99;      // DB接続エラー

        /// <summary>
        /// ステータス -1:システムエラー(予期しないエラー)
        /// </summary>
        private const int ctSTATUS_SYSTEM_ERROR = -1;       // システムエラー

        /// <summary>
        /// ステータス -104:WEBサービス接続タイムアウト(予期しないエラー)
        /// </summary>
        private const int ctSTATUS_SERVICE_TIMEOUT = -104;       // タイムアウト


        /// <summary>
        /// ステータスメッセージ取得
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <returns>メッセージ文字列</returns>
        static public string GetMessage(int status)
        {
            string messsageStr = "";

            switch (status)
            {
                case TSPServiceMessageHelperForPM.ctSTATUS_SUCCESS:
                    messsageStr = "TSP送受信処理は正常に行われました";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_DATA_NOT_FOUND:
                    messsageStr = "処理に該当するデータがありません";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_DATA_ERROR_SUBSET:
                    messsageStr = "TSP送受信データの一部は処理できませんでした";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_SEARCH_PARAM_UNENABLE:
                    messsageStr = "TSP送受信データは取得できませんでした - 検索条件が不正です";
                    break;
                case -15:
                    messsageStr = "TSPサービスへ接続できません - ログイン情報が有効ではありません";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_DB_ERROR:
                    messsageStr = "TSPサービスDBへ接続できません";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_SYSTEM_ERROR:
                    messsageStr = "TSPサービス接続時に予期しないエラーが発生しました";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_SERVICE_TIMEOUT:
                    messsageStr = "TSPサービスへ接続できませんでした(接続タイムアウト)";
                    break;
                case 103:
                    messsageStr = "TSPサービスから接続テストデータが送受信されました";
                    break;

                default:
                    if (status > 0)
                    {
                        messsageStr = "TSPサービスで予期しないエラーが発生しました";
                    }
                    break;
            }

            return messsageStr;
        
        }
    
    }

    public static class TspXMLDecryptTableResource
    {
        /// <summary>
        /// 初期化ベクタ
        /// </summary>
        public static readonly byte[] InitVector = Encoding.Default.GetBytes("BRLFTSPN");
        /// <summary>
        /// 月毎ラウンドキーテーブル
        /// </summary>
        public static readonly byte[] Key = Encoding.Default.GetBytes("yｻﾙ5nuvｱSqs2vｻsQ");
    }

}
