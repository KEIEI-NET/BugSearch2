using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// StockMonthYearReportResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockMonthYearReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接StockMonthYearReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationStockMonthYearReportResultDB
    {
        /// <summary>
        /// StockMonthYearReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.21</br>
        /// </remarks>
        public MediationStockMonthYearReportResultDB()
        {
        }
        /// <summary>
        /// IStockMonthYearReportResultDBインターフェース取得
        /// </summary>
        /// <returns>IStockMonthYearReportResultDBオブジェクト</returns>
        public static IStockMonthYearReportResultDB GetStockMonthYearReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:8008";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IStockMonthYearReportResultDB)Activator.GetObject(typeof(IStockMonthYearReportResultDB), string.Format("{0}/MyAppStockMonthYearReportResult", wkStr));
        }
    }
}
