using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 通番コード (番号タイプ管理マスタの番号コードに対応)
    /// </summary>
    public enum SerialNumberCode
    {
        /// <summary>0:未設定</summary>
        Empty = 0,
        /// <summary>3:入金伝票番号</summary>
        DepositSlipNo = 3,
        /// <summary>4:領収書番号</summary>
        ReceiptNo = 4,
        /// <summary>5:受注番号</summary>
        AcceptAnOrderNo = 5,
        /// <summary>7:受注管理番号</summary>
        AcptAnOdrMngNo = 7,
        /// <summary>52:支払伝票番号</summary>
        PaymentSlipNo = 52,
        /// <summary>500:仕入伝票番号</summary>
        SupplierSlipNo = 500,
        /// <summary>510:入荷伝票番号</summary>
        ArrGdsSlipNo = 510,
        /// <summary>520:発注伝票番号</summary>
        SalesOrderSlipNo = 520,
        /// <summary>530:見積伝票番号</summary>
        EstimateSlipNo = 530,
        /// <summary>540:受注伝票番号</summary>
        AcptAnOdrSlipNo = 540,
        /// <summary>1000:見積番号</summary>
        EstimateNo = 1000,
        /// <summary>1200:売上伝票番号</summary>
        SalesSlipNum = 1200,
        /// <summary>1300:出荷伝票番号</summary>
        ShipmentSlipNo = 1300,
        //// 1700:移動出荷伝票番号
        //MoveShipmentSlipNo = 1700,  //DEL 2008/07/07 M.Kubota
        /// <summary>1700:在庫移動伝票番号</summary>
        StockMoveSlipNo = 1700,       //ADD 2008/07/07 M.Kubota
        /// <summary>1720:在庫調整伝票番号</summary>
        StockAdjustSlipNo = 1720,
        //// <summary>1730:移動入荷伝票番号</summary>
        //MoveArrGdsSlipNo = 1730,  //DEL 2008/07/07 M.Kubota
        /// <summary>3000:共通通番</summary>
        CommonNo = 3000,
        /// <summary>3010:売上明細通番(売上,受注,出荷,見積)</summary>
        SailsDtlNo = 3010,
        /// <summary>3020:仕入明細通番(仕入,発注,入荷)</summary>
        StockDtlNo = 3020,
        /// <summary>3030:入金明細通番</summary>
        DepositDtlNo = 3030,
        /// <summary>3040:支払明細通番</summary>
        PaymentDtlNo = 3040,
        //// <summary>3100:請求精算伝票番号</summary>
        //Dmd = 3100,
        /// <summary>3200:車輌管理番号(SEQ)</summary>
        CarMngNo = 3200,
        /// <summary>3300:UOE発注番号</summary>
        UOESalesOrderNo = 3300,
        /// <summary>3310:UOEオンライン番号</summary>
        UOEOnlineNo = 3310,
        /// <summary>3500:送受信履歴ログ送信番号</summary>
        SndRcvHisConsNo = 3500
    }

    /// <summary>
    /// 採番管理を行うクラスです。
    /// </summary>
    /// <remarks>
    /// <br>Note       : 番号管理設定マスタの値を元に各種連番を取得するクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.05.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class NumberingManager : RemoteDB
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public NumberingManager()
        {
        }

        /// <summary>
        /// リトライ回数を取得します。
        /// </summary>
        private int RetryCount
        {
            get { return 50; }
        }

        /// <summary>
        /// リトライ時のインターバルをミリ秒で取得します。
        /// </summary>
        private int RetryInterval
        {
           get { return 500; }
        }

        /// <summary>
        /// 通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="serialnumcd">通番コードを指定します。</param>
        /// <param name="serialnumber">番号コードに基いて採番された通番を返します。</param>
        /// <returns>STATUS</returns>
        public int GetSerialNumber(string enterprisecode, string sectioncode, SerialNumberCode serialnumcd, out Int64 serialnumber)
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            serialnumber = 0;

            // 番号採番部品の準備
            NumberNumbering numMng = new NumberNumbering();

            int noCode = (int)serialnumcd;
            string[] strParam = new string[0];
            string no = "";
            int noItemPatternCd = 0;
            string retMsg = "";

            int retrycount = this.RetryCount;
            do
            {
                // 戻り値の初期化
                no = "";
                noItemPatternCd = 0;
                retMsg = "";

                // 通番を採番
                status = numMng.Numbering(enterprisecode, sectioncode, noCode, strParam, out no, out noItemPatternCd, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
                {
                    retrycount -= 1;
                    base.WriteErrorLog(string.Format("GetSerialNumber: Retry = {0} Time = {1} NoCode = {2} RetMsg = {3}", (this.RetryCount - retrycount), DateTime.Now.TimeOfDay.ToString(), noCode, retMsg));
                    System.Threading.Thread.Sleep(this.RetryInterval);
                }
                else
                {
                    retrycount = 0;
                }
            }
            while (retrycount > 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                serialnumber = Convert.ToInt64(no);
            }
            else
            {
                base.WriteErrorLog("NumberingManager.GetSerialNumberにてエラー Msg = " + retMsg, status);
            }

            return status;
        }
    }
}
