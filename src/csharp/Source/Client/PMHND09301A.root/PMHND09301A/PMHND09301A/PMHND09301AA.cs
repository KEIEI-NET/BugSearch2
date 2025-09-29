//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 商品バーコード関連付けマスタ登録アクセスクラス
// プログラム概要   : 商品バーコード関連付けマスタ登録アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/12  修正内容 : 新規作成
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
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品バーコード関連付けマスタ登録アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けマスタ登録アクセスクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyGoodsBarCodeAcs
    {
        #region [定数]
        // 登録処理が正常に終了したステータス
        private const int StatusNomal = 0;
        // 登録処理がタイムアウトステータス
        private const int StatusTimeout = 5;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>他でデータが変更済みの場合、（ST_ARSET）のステータス</summary>
        private const int StatusArset = -2;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND09301A_";
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
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>商品バーコード</summary>
        private const string GoodsBarCode = "商品バーコード:";
        /// <summary>商品バーコード種別</summary>
        private const string GoodsBarCodeKind = "商品バーコード種別:";
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
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public HandyGoodsBarCodeAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// 商品バーコード関連付けマスタ登録処理
        /// </summary>
        /// <param name="insertObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタを登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int InsertHandyGoodsBarCode(object insertObj)
        {
            int status = StatusError;

            // 登録データ
            GoodsBarCodeRevnWork goodsBarCodeRevnWork = insertObj as GoodsBarCodeRevnWork;

            // パラメータがnullの場合、
            if (goodsBarCodeRevnWork == null)
            {
                // ログ出力します。
                this.WriteLog(goodsBarCodeRevnWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目チェック
                if (string.IsNullOrEmpty(goodsBarCodeRevnWork.EnterpriseCode)
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.MachineName.Trim()) 
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.GoodsNo.Trim()) 
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.GoodsBarCode.Trim())
                    || goodsBarCodeRevnWork.GoodsMakerCd <= 0)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(goodsBarCodeRevnWork, ErrorMsgParam);
                    return status;
                }

                // 桁数チェック
                if (goodsBarCodeRevnWork.GoodsMakerCd > 999999 || goodsBarCodeRevnWork.GoodsNo.Length > 40
                    || goodsBarCodeRevnWork.GoodsBarCode.Length > 128 || goodsBarCodeRevnWork.GoodsBarCodeKind > 99
                    || goodsBarCodeRevnWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(goodsBarCodeRevnWork, ErrorMsgParam);
                    return status;
                }
            }

            // 登録データの補正
            // チェックデジット区分は固定値(0:なし)
            goodsBarCodeRevnWork.CheckdigitCode = 0;
            // 提供データ区分は固定値(0:ユーザデータ)
            goodsBarCodeRevnWork.OfferDataDiv = 0;

            try
            {
                #region 商品バーコード関連付けマスタ情報を登録する
                // リモート取得
                IHandyGoodsBarCodeDB iHandyGoodsBarCodeDB = (IHandyGoodsBarCodeDB)MediationHandyGoodsBarCodeDB.GetHandyGoodsBarCodeDB();

                // 商品バーコード関連付けマスタリモート呼び出し
                byte[] insertByte = XmlByteSerializer.Serialize(goodsBarCodeRevnWork);

                status = iHandyGoodsBarCodeDB.InsertForHandy(insertByte);

                // 登録処理が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 登録処理がタイムアウトの場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // 他でデータが変更済みの場合
                else if (status == StatusArset)
                {
                    status = StatusArset;
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
                this.WriteLog(goodsBarCodeRevnWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 何もしない
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="goodsBarCodeRevnWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(GoodsBarCodeRevnWork goodsBarCodeRevnWork, string errMsg)
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
                if (goodsBarCodeRevnWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + goodsBarCodeRevnWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + goodsBarCodeRevnWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + goodsBarCodeRevnWork.MachineName);
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + goodsBarCodeRevnWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + goodsBarCodeRevnWork.GoodsNo);
                    // 商品バーコード
                    writer.WriteLine(GoodsBarCode + goodsBarCodeRevnWork.GoodsBarCode);
                    // 商品バーコード種別
                    writer.WriteLine(GoodsBarCodeKind + goodsBarCodeRevnWork.GoodsBarCodeKind);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}
