//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル在庫情報取得(通常)アクセスクラス
// プログラム概要   : ハンディターミナル在庫情報取得(通常)アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル在庫情報取得(通常)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫情報取得(通常)アクセスクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/15</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyStockInfoAcs
    {
        #region [定数]
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // ﾛｸﾞｲﾝIDが見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND04100A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>企業コード</summary>
        private const string EnterpriseCode = "企業コード:";
        /// <summary>従業員コード</summary>
        private const string EmployeeCode = "従業員コード:";
        /// <summary>コンピュータ名</summary>
        private const string MachineName = "コンピュータ名:";
        /// <summary>処理区分</summary>
        private const string OpDiv = "処理区分:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>相手先商品コード(JAN等)</summary>
        private const string CustomerGoodsCode = "商品バーコード:";
        /// <summary>倉庫棚番</summary>
        private const string WarehouseShelfNo = "棚番:";
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgNull = "検索条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgParam = "入力パラメータエラーが発生しました。";
        #endregion

        // ===================================================================================== //
        // Static 変数
        // ===================================================================================== //
        #region Static Members
        /// <summary>ログ用ロック</summary>
        static object LogLockObj = null;
        #endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public HandyStockInfoAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ハンディターミナル在庫情報取得(通常)取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナルログイン情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public int SearchHandyStockInfo(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // 検索条件
            HandyStockCondWork handyStockCondWork = condObj as HandyStockCondWork;

            // パラメータがnullの場合、
            if (handyStockCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(handyStockCondWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // パラメータチェック
                switch (handyStockCondWork.OpDiv)
                {

                    // 入力パラメータ.取得区分が、0:"初回読込"の時
                    case 0:

                        // 入力パラメータ「企業コード、従業員コード、コンピュータ名、倉庫コード、相手先商品コード(JAN等)」は空がある場合、エラーを戻ります。
                        if (string.IsNullOrEmpty(handyStockCondWork.EnterpriseCode.Trim())
                            || string.IsNullOrEmpty(handyStockCondWork.EmployeeCode.Trim())
                            || string.IsNullOrEmpty(handyStockCondWork.MachineName.Trim()) 
                            || string.IsNullOrEmpty(handyStockCondWork.WarehouseCode.Trim())
                            || string.IsNullOrEmpty(handyStockCondWork.CustomerGoodsCode.Trim()))
                        {
                            // エラーメッセージに引数の名前と値をログ出力します。
                            this.WriteLog(handyStockCondWork, ErrorMsgParam);
                            return status;
                        }
                        break;

                    // 入力パラメータ.処理区分が、1:"次"の時
                    case 1:
                    // 入力パラメータ.処理区分が、2:"前"の時
                    case 2:

                        // 入力パラメータ「企業コード、従業員コード、コンピュータ名、倉庫コード、メーカーコード、商品番号」は空がある場合、エラーを戻ります。
                        if (string.IsNullOrEmpty(handyStockCondWork.EnterpriseCode.Trim())
                            || string.IsNullOrEmpty(handyStockCondWork.EmployeeCode.Trim())
                            || string.IsNullOrEmpty(handyStockCondWork.MachineName.Trim()) 
                            || string.IsNullOrEmpty(handyStockCondWork.WarehouseCode.Trim())
                            || string.IsNullOrEmpty(handyStockCondWork.GoodsNo.Trim()) 
                            || handyStockCondWork.GoodsMakerCd == 0)
                        {
                            // エラーメッセージに引数の名前と値をログ出力します。
                            this.WriteLog(handyStockCondWork, ErrorMsgParam);
                            return status;
                        }
                        break;

                    // 入力パラメータ.処理区分が、「0、1、2」以外の時、エラーを戻ります。
                    default:
                        // エラーメッセージに引数の名前と値をログ出力します。
                        this.WriteLog(handyStockCondWork, ErrorMsgParam);
                        return status;
                }
            }

            try
            {
                #region 在庫情報取得(通常)を取得する
                // リモート取得
                IHandyStockDB iHandyStockDB = (IHandyStockDB)MediationHandyStockDB.GetHandyStockDB();

                // ハンディターミナルログイン情報取得リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyStockCondWork);
                byte[] retByte = null;

                status = iHandyStockDB.Search(condByte, out retByte);

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 返却パラメータセット
                    retObj = XmlByteSerializer.Deserialize(retByte, typeof(HandyStockWork));
                    status = StatusNomal;
                }
                // 在庫情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // 読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    status = StatusError;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(handyStockCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                //　処理なし。
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="handyStockCondWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(HandyStockCondWork handyStockCondWork, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + PathLog;

            lock (LogLockObj)
            {
                // フォルダが存在しない場合、
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                if (handyStockCondWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyStockCondWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyStockCondWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyStockCondWork.MachineName);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyStockCondWork.OpDiv);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + handyStockCondWork.WarehouseCode);
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + handyStockCondWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + handyStockCondWork.GoodsNo);
                    // 相手先商品コード(JAN等)
                    writer.WriteLine(CustomerGoodsCode + handyStockCondWork.CustomerGoodsCode);
                    // 倉庫棚番
                    writer.WriteLine(WarehouseShelfNo + handyStockCondWork.WarehouseShelfNo);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}
