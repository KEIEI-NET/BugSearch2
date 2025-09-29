using System;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;  //ADD 2008/08/25 M.Kubota 
using System.Diagnostics;             //ADD 2008/08/25 M.Kubota


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// IOWrite仕入処理金額更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : IOWriteにて仕入処理の金額系の更新処理をまとめて行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.01.16</br>
    /// <br></br>
    /// <br>Update Note: 仕入データ・仕入明細データファイルレイアウト変更</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.03.26</br>
    /// </remarks>
    [Serializable]
    //public class IOWriteSIRMoneyUpdateDB : RemoteDB, IFunctionCallTargetWrite           //DEL 2008/08/25 M.Kubota
    public class IOWriteSIRMoneyUpdateDB : RemoteWithAppLockDB, IFunctionCallTargetWrite  //ADD 2008/08/25 M.Kubota
    {
        private PaymentSlpDB _paymentSlpDB = null;

        /// <summary>
        /// 支払伝票リモート プロパティ
        /// </summary>
        private PaymentSlpDB paymentSlpDB
        {
            get
            {
                if (this._paymentSlpDB == null)
                {
                    this._paymentSlpDB = new PaymentSlpDB();
                }

                return this._paymentSlpDB;
            }
        }

        private PaymentReadDB _paymentReadDB = null;

        /// <summary>
        /// 支払伝票検索リモート プロパティ
        /// </summary>
        private PaymentReadDB paymentReadDB
        {
            get
            {
                if (this._paymentReadDB == null)
                {
                    this._paymentReadDB = new PaymentReadDB();
                }

                return this._paymentReadDB;
            }
        }

        /// <summary>
        /// IOWrite金額更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特に無し</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.16</br>
        /// </remarks>
        public IOWriteSIRMoneyUpdateDB()
        {
        }

        # region [Read]

        /// <summary>
        /// 支払データの読み込みを行います。
        /// </summary>
        /// <param name="origin">呼び出し元プログラムID</param>
        /// <param name="readResultList">検索パラメータ(仕入データ)兼検索結果リスト</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払データの読み込みを行ないます</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.01.24</br>
        public int ReadFromStockSlip(string origin, ref CustomSerializeArrayList readResultList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                // コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    //base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                // 仕入データ読み込み結果チェック
                StockSlipWork stockSlipWork = (ListUtils.Find(readResultList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork);

                if (stockSlipWork == null)
                {
                    //base.WriteErrorLog(null, "プログラムエラー。仕入データパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 仕入データパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                // 支払データ検索条件の設定
                SearchParaPaymentRead searchParaPaymentRead = new SearchParaPaymentRead();

                searchParaPaymentRead.PaymentCallMonthsStart = DateTime.MinValue;
                searchParaPaymentRead.PaymentCallMonthsEnd = DateTime.MaxValue;
                
                searchParaPaymentRead.EnterpriseCode = stockSlipWork.EnterpriseCode;     // 企業コード
                searchParaPaymentRead.PaymentSlipNo = stockSlipWork.AutoPaySlipNum;      // 支払伝票番号
                //searchParaPaymentRead.AutoPayment = stockSlipWork.AutoPayment;           // 自動支払区分
                searchParaPaymentRead.AutoPayment = -1;
                //searchParaPaymentRead.SupplierSlipNo = stockSlipWork.SupplierSlipNo;     // 仕入伝票番号

                // 支払データ読み込み
                object paymentResult;

                status = this.paymentReadDB.Search(out paymentResult, searchParaPaymentRead, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    //レスポンスデータ生成
                    ArrayList readPaymentList = paymentResult as ArrayList;

                    if (ListUtils.IsNotEmpty(readPaymentList))
                    {
                        # region --- DEL 2008/08/25 M.Kubota --->>>
                        //PaymentSlpWork readPaymentWork = readPaymentList[0] as PaymentSlpWork;

                        //if (readPaymentWork != null)
                        //{
                        //    readResultList.Add(readPaymentWork);
                        //}
                        # endregion --- DEL 2008/08/25 M.Kubota ---<<<

                        //--- ADD 2008/08/25 M.Kubota --->>>
                        PaymentDataWork readPaymentDataWork = readPaymentList[0] as PaymentDataWork;

                        if (readPaymentDataWork != null)
                        {
                            readResultList.Add(readPaymentDataWork);
                        }
                        //--- ADD 2008/08/25 M.Kubota ---<<<
                    }
                }

                //データ無しは"正常"とする
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteSIRMoneyUpdateDB.ReadFromStockSlip:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }

            return status;
        }

        # endregion

        #region[Write]　仕入伝票更新時の金額マスタ更新処理

        /// <summary>
        /// 仕入データから支払データを作成します。
        /// </summary>
        /// <param name="stockslipparam">仕入データ</param>
        /// <param name="paymentsliplist">支払データリスト</param>
        //private void CreatePaymentSlipParameter(StockSlipWork stockslipparam, ref PaymentSlpWork paymentData)
        private void CreatePaymentSlipParameter(StockSlipWork stockslipparam, ref PaymentDataWork  paymentData)
        {
            if (stockslipparam != null && paymentData != null)
            {
                //●仕入伝票データから設定される項目
                paymentData.EnterpriseCode = stockslipparam.EnterpriseCode;            // 企業コード
                paymentData.DebitNoteDiv =
                                (int)ConstantManagement_Mobile.ct_DebitNoteDiv.Black;  // 赤伝区分 ← 仕入から作成する支払は常に黒とする
                paymentData.SupplierFormal = stockslipparam.SupplierFormal;            // 仕入形式
                paymentData.SupplierSlipNo = stockslipparam.SupplierSlipNo;            // 仕入伝票番号
                paymentData.SupplierCd = stockslipparam.SupplierCd;                    // 仕入先コード
                paymentData.SupplierNm1 = stockslipparam.SupplierNm1;                  // 仕入先名1
                paymentData.SupplierNm2 = stockslipparam.SupplierNm2;                  // 仕入先名2
                paymentData.SupplierSnm = stockslipparam.SupplierSnm;                  // 仕入先略称
                paymentData.PayeeCode = stockslipparam.PayeeCode;                      // 支払先コード
                paymentData.PayeeSnm = stockslipparam.PayeeSnm;                        // 支払先略称
                paymentData.PaymentInpSectionCd = stockslipparam.StockSectionCd;       // 支払入力拠点コード ← 仕入拠点コード
                paymentData.AddUpSecCode = stockslipparam.StockAddUpSectionCd;         // 計上拠点コード ← 仕入計上拠点コード
                paymentData.UpdateSecCd = stockslipparam.SectionCode;                  // 更新拠点コード ← 拠点コード
                paymentData.SubSectionCode = stockslipparam.SubSectionCode;            // 部門コード
                paymentData.InputDay = stockslipparam.InputDay;                        // 支払日 ← 入力日  // ADD 2009/03/25
                paymentData.PaymentDate = stockslipparam.InputDay;                     // 支払日 ← 入力日
                paymentData.AddUpADate = stockslipparam.StockAddUpADate;               // 計上日付 ← 仕入計上日付
                paymentData.PaymentTotal = stockslipparam.StockTotalPrice;             // 支払計 ← 仕入金額合計
                paymentData.Payment = stockslipparam.StockTotalPrice;                  // 支払金額 ← 仕入金額合計
                paymentData.AutoPayment = stockslipparam.AutoPayment;                  // 自動支払区分
                paymentData.PaymentAgentCode = stockslipparam.StockAgentCode;          // 支払担当者コード ← 仕入担当者コード
                paymentData.PaymentAgentName = stockslipparam.StockAgentName;          // 支払担当者名称 ← 仕入担当者名称
                paymentData.PaymentInputAgentCd = stockslipparam.StockInputCode;       // 支払入力者コード ← 仕入入力者コード
                paymentData.PaymentInputAgentNm = stockslipparam.StockInputName;       // 支払入力者名称 ← 仕入入力者名称
                paymentData.Outline = stockslipparam.SupplierSlipNo.ToString();        // 伝票摘要 ← 仕入伝票番号
                paymentData.Payment1 = stockslipparam.StockTotalPrice;                 // 支払金額１ ← 仕入金額合計
            }
        }
        
        /// <summary>
        /// 仕入処理の金額更新の準備処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">更新対象オブジェクト</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置(未使用)</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入処理の金額更新の準備処理を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.16</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.WriteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }
                
                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.WriteInitial:プログラムエラー。更新対象パラメータリストが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入伝票オブジェクトの取得
                StockSlipWork stockSlipParam = ListUtils.Find(list, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                if (stockSlipParam == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.WriteInitial:プログラムエラー。更新対象仕入オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象仕入オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●支払伝票オブジェクトの取得
                //PaymentSlpWork paymentData = ListUtils.Find(list, typeof(PaymentSlpWork), ListUtils.FIND_TYPE.Class) as PaymentSlpWork;   //DEL 2008/08/25 M.Kubota
                PaymentDataWork paymentData = ListUtils.Find(list, typeof(PaymentDataWork), ListUtils.FindType.Class) as PaymentDataWork;  //ADD 2008/08/25 M.Kubota

                if (paymentData == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.WriteInitial:プログラムエラー。更新対象支払オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象支払オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●支払伝票オブジェクトの作成
                this.CreatePaymentSlipParameter(stockSlipParam, ref paymentData);

                PaymentSlpWork paymentSlp = null;
                PaymentDtlWork[] paymentDtlArray = null;
                PaymentDataUtil.Division(paymentData, out paymentSlp, out paymentDtlArray);

                //●支払伝票番号の採番
                this.paymentSlpDB.WriteInitial(ref paymentSlp, ref paymentDtlArray, ref sqlConnection, ref sqlTransaction);

                PaymentDataUtil.UnionRef(ref paymentData, paymentSlp, paymentDtlArray);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMoneyUpdateDB.WriteInitial:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }

        /// <summary>
        /// 仕入処理の金額更新の処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">更新対象オブジェクト</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入処理の金額更新の処理を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.16</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref Broadleaf.Library.Data.SqlClient.SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.Write:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.Write:プログラムエラー。更新対象パラメータリストが未指定です");
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象パラメータリストが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入伝票オブジェクトの取得
                StockSlipWork stockSlipParam = ListUtils.Find(list, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                if (stockSlipParam == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.WriteInitial:プログラムエラー。更新対象仕入オブジェクトパラメータが未指定です");
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象仕入オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●支払伝票オブジェクトの取得
                # region --- DEL 2008/08/25 M.Kubota --->>>
                //PaymentSlpWork paymentData = ListUtils.Find(list, typeof(PaymentSlpWork), ListUtils.FIND_TYPE.Class) as PaymentSlpWork;
                //if (paymentData == null)
                //{
                //    base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.Write:プログラムエラー。更新対象支払伝票オブジェクトパラメータが未指定です");
                //    return status;
                //}
                # endregion
                
                PaymentDataWork paymentData = ListUtils.Find(list, typeof(PaymentDataWork), ListUtils.FindType.Class) as PaymentDataWork;

                PaymentSlpWork paymentSlp = null;
                PaymentDtlWork[] paymentDtlArray = null;

                if (paymentData == null)
                {
                    errmsg += ": 更新対象支払伝票オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                
                PaymentDataUtil.Division(paymentData, out paymentSlp, out paymentDtlArray);

                //●支払伝票マスタ更新処理
                status = this.paymentSlpDB.WriteProc(ref paymentSlp, ref paymentDtlArray, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "支払伝票データの更新処理でエラーが発生しました。 " + retMsg;
                }
                
                PaymentDataUtil.UnionRef(ref paymentData, paymentSlp, paymentDtlArray);
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteSIRMoneyUpdateDB.Write:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }

            return status;
        }
        #endregion

        # region [RedWrite]  仕入赤伝票作成時の支払伝票データ作成処理

        public int RedWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            // 支払伝票も赤伝は存在せず、通常の黒伝として登録するが、金額などをマイナスにして相殺するようなデータとしている
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWriteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●赤伝更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(redList))
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWriteInitial:プログラムエラー。赤伝更新対象パラメータリストが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入赤伝オブジェクトの取得
                StockSlipWork stockSlipParam = ListUtils.Find(redList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                if (stockSlipParam == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWriteInitial:プログラムエラー。更新対象仕入赤伝オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象仕入赤伝オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●支払伝票オブジェクトの取得
                # region --- DEL 2008/08/25 M.Kubota --->>>
                //PaymentSlpWork paymentData = ListUtils.Find( redList, typeof( PaymentSlpWork ), ListUtils.FIND_TYPE.Class ) as PaymentSlpWork;

                //if (paymentData == null)
                //{
                //    base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWriteInitial:プログラムエラー。更新対象支払オブジェクトパラメータが未指定です");
                //    return status;
                //}
                # endregion --- DEL 2008/08/25 M.Kubota ---<<<

                //--- ADD 2008/08/25 M.Kubota --->>>
                PaymentDataWork paymentData = ListUtils.Find(redList, typeof(PaymentDataWork), ListUtils.FindType.Class) as PaymentDataWork;  //ADD 2008/08/25 M.Kubota

                if (paymentData == null)
                {
                    errmsg += ": 更新対象支払オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                //--- ADD 2008/08/25 M.Kubota ---<<<

                //●支払伝票オブジェクトの作成
                //this.CreatePaymentSlipParameter(stockSlipParam, ref paymentData);  //DEL 2008/08/25 M.Kubota
                this.CreatePaymentSlipParameter(stockSlipParam, ref paymentData);    //ADD 2008/08/25 M.Kubota

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBDepositDB.RedWriteInitial:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }
            finally
            {
                //TODO: WARNING の扱い
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    retMsg = "更新された支払伝票データはありません。" + retMsg;
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
        }

        public int RedWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWrite:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●赤伝更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(redList))
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWrite:プログラムエラー。赤伝更新対象パラメータリストが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 赤伝更新対象パラメータリストが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入赤伝オブジェクトの取得
                StockSlipWork stockSlipParam = ListUtils.Find(redList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                if (stockSlipParam == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWrite:プログラムエラー。更新対象仕入赤伝オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象仕入赤伝オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●支払伝票オブジェクトの取得
                # region --- DEL 2008/08/25 M.Kubota --->>>
                //PaymentSlpWork paymentData = ListUtils.Find( redList, typeof( PaymentSlpWork ), ListUtils.FIND_TYPE.Class ) as PaymentSlpWork;

                //if (paymentData == null)
                //{
                //    base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.RedWrite:プログラムエラー。更新対象支払伝票オブジェクトパラメータが未指定です");
                //    return status;
                //}
                # endregion --- DEL 2008/08/25 M.Kubota ---<<<
                
                //--- ADD 2008/08/25 M.Kubota --->>>
                int objPos = -1;
                PaymentDataWork paymentData = ListUtils.Find(redList, typeof(PaymentDataWork), ListUtils.FindType.Class, out objPos) as PaymentDataWork;
                PaymentSlpWork paymentSlip = null;
                PaymentDtlWork[] paymentDtlArray = null;

                if (paymentData == null)
                {
                    errmsg += "更新対象支払伝票オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                PaymentDataUtil.Division(paymentData, out paymentSlip, out paymentDtlArray);
                //--- ADD 2008/08/25 M.Kubota ---<<<

                //●支払伝票マスタ更新処理
                //status = this.paymentSlpDB.WritePaymentSlpWork(ref paymentData, ref sqlConnection, ref sqlTransaction);       //DEL 2008/08/25 M.Kubota
                status = this.paymentSlpDB.Write(ref paymentSlip, ref paymentDtlArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/08/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "支払伝票データの更新処理でエラーが発生しました。 " + retMsg;
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki DEL 2008.02.27
                    //// 赤伝更新結果リストに追加する
                    //retRedList.Add(paymentData);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki DEL 2008.02.27
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    PaymentDataUtil.Union(out paymentData, paymentSlip, paymentDtlArray);
                    redList[objPos] = paymentData;
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                }
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMAHNBDepositDB.RedWrite:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }

            return status;
        }


        # endregion

        #region [Delete]　仕入伝票削除時の金額マスタ更新処理
        /// <summary>
        /// 仕入処理の金額削除の処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">更新対象オブジェクト</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入処理の金額削除の処理を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.16</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref Broadleaf.Library.Data.SqlClient.SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.DeleteInitial:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.DeleteInitial:プログラムエラー。削除対象パラメータリストが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 削除対象パラメータリストが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●仕入伝票削除オブジェクトの取得
                StockSlipDeleteWork stockSlpDelParam = ListUtils.Find(list, typeof(StockSlipDeleteWork), ListUtils.FindType.Class) as StockSlipDeleteWork;
                StockSlipWork stockSlipParam = null;

                if (stockSlpDelParam == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.DeleteInitial:プログラムエラー。削除対象仕入オブジェクトパラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 削除対象仕入オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }
                else
                {
                    // 仕入伝票削除オブジェクトから仕入伝票オブジェクトを生成する(後述の支払伝票オブジェクトを作成する際に必要な為)
                    stockSlipParam = new StockSlipWork();
                    stockSlipParam.EnterpriseCode = stockSlpDelParam.EnterpriseCode;  // 企業コード
                    stockSlipParam.SupplierFormal = stockSlpDelParam.SupplierFormal;  // 仕入形式
                    stockSlipParam.SupplierSlipNo = stockSlpDelParam.SupplierSlipNo;  // 仕入伝票番号
                    stockSlipParam.DebitNoteDiv = stockSlpDelParam.DebitNoteDiv;      // 赤伝区分
                    stockSlipParam.UpdateDateTime = stockSlpDelParam.UpdateDateTime;  // 更新日付
                }

                //●支払伝票オブジェクトの取得
                # region --- DEL 2008/08/25 M.Kubota --->>>
                //PaymentSlpWork paymentData = ListUtils.Find(list, typeof(PaymentSlpWork), ListUtils.FIND_TYPE.Class) as PaymentSlpWork;

                //if (paymentData == null)
                //{
                //    base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.DeleteInitial:プログラムエラー。更新対象支払伝票オブジェクトパラメータが未指定です");
                //    return status;
                //}
                # endregion --- DEL 2008/08/25 M.Kubota ---<<<

                //--- ADD 2008/08/25 M.Kubota --->>>
                PaymentDataWork paymentData = ListUtils.Find(list, typeof(PaymentDataWork), ListUtils.FindType.Class) as PaymentDataWork;  //ADD 2008/08/25 M.Kubota

                if (paymentData == null)
                {
                    errmsg += ": 更新対象支払伝票オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                //--- ADD 2008/08/25 M.Kubota ---<<<

                //●支払伝票オブジェクトの作成
                //this.CreatePaymentSlipParameter(stockSlipParam, ref paymentData);  //DEL 2008/08/25 M.Kubota
                this.CreatePaymentSlipParameter(stockSlipParam, ref paymentData);    //ADD 2008/08/25 M.Kubota

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteMoneyUpdateDB.DeleteInitial:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }

        /// <summary>
        /// 仕入処理の金額削除の処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="list">更新対象オブジェクト</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入処理の金額削除の処理を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.16</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref Broadleaf.Library.Data.SqlClient.SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            retMsg = "";
            retItemInfo = "";

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/08/25 M.Kubota

            try
            {
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.Delete:プログラムエラー。データベース接続情報パラメータが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": データベース接続情報パラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●更新対象パラメータリストチェック
                if (ListUtils.IsEmpty(list))
                {
                    //base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.Delete:プログラムエラー。更新対象パラメータリストが未指定です");  //DEL 2008/08/25 M.Kubota
                    //--- ADD 2008/08/25 M.Kubota --->>>
                    errmsg += ": 更新対象パラメータリストが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    //--- ADD 2008/08/25 M.Kubota ---<<<
                    return status;
                }

                //●支払伝票オブジェクトの取得
                # region --- DEL 2008/08/25 M.Kubota --->>>
                //PaymentSlpWork paymentData = ListUtils.Find(list, typeof(PaymentSlpWork), ListUtils.FIND_TYPE.Class) as PaymentSlpWork;

                //if (paymentData == null)
                //{
                //    base.WriteErrorLog(null, "IOWriteSIRMoneyUpdateDB.Delete:プログラムエラー。更新対象支払伝票オブジェクトパラメータが未指定です");
                //    return status;
                //}
                # endregion --- DEL 2008/08/25 M.Kubota ---<<<

                //--- ADD 2008/08/25 M.Kubota --->>>
                PaymentDataWork paymentData = ListUtils.Find(list, typeof(PaymentDataWork), ListUtils.FindType.Class) as PaymentDataWork;

                if (paymentData == null)
                {
                    errmsg += ": 更新対象支払伝票オブジェクトパラメータが未指定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                //--- ADD 2008/08/25 M.Kubota ---<<<

                //●削除処理(論理)
                //status = this.paymentSlpDB.LogicalDelete(paymentData.EnterpriseCode, paymentData.PaymentSlipNo, ref sqlConnection, ref sqlTransaction);  //DEL 2008/08/25 M.Kubota
                status = this.paymentSlpDB.LogicalDelete(paymentData.EnterpriseCode, paymentData.PaymentSlipNo, ref sqlConnection, ref sqlTransaction);  //ADD 2008/08/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    retMsg = "支払伝票データの削除処理でエラーが発生しました。 " + retMsg;
                }
            }
            catch (Exception ex)
            {
                //base.WriteErrorLog(ex, "IOWriteSIRMoneyUpdateDB.Delete:" + ex.Message);  //DEL 2008/08/25 M.Kubota
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);  //ADD 2008/08/25 M.Kubota
            }

            return status;
        }

        #endregion

        # region --- DEL 2008/08/25 M.Kubota --->>>
# if false
        /// <summary>
        /// List ユーティリティクラス
        /// </summary>
        private class ListUtils
        {
            /// <summary>検索パターン Find() で利用</summary>
            public enum FIND_TYPE
            {
                /// <summary>クラス</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }

            /// <summary>
            /// CustomArrayList から指定した型のオブジェクトを取得する
            /// </summary>
            /// <param name="paramArray">検査対象パラメータList</param>
            /// <param name="type">検索対象タイプ</param>
            /// <param name="pattern">検索パターン</param>
            /// <param name="position">パラメータ位置</param>
            /// <returns>オブジェクト</returns>
            public static object Find(CustomSerializeArrayList paramArray, Type type, FIND_TYPE pattern, out int position)
            {
                object result = null;
                position = -1;

                if (IsEmpty(paramArray)) return result;

                //パラメータを取得
                if (pattern == FIND_TYPE.Class)
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] != null && paramArray[i].GetType() == type)
                        {
                            result = paramArray[i];
                            position = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] is ArrayList)
                        {
                            ArrayList al = paramArray[i] as ArrayList;
                            if (al != null && al.Count > 0)
                            {
                                if (al[0] != null && al[0].GetType() == type)
                                {
                                    result = paramArray[i];
                                    position = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                return result;
            }

            /// <summary>
            /// CustomArrayList から指定した型のオブジェクトを取得する
            /// </summary>
            /// <param name="paramArray">検査対象パラメータList</param>
            /// <param name="type">検索対象タイプ</param>
            /// <param name="pattern">検索パターン</param>
            /// <returns>オブジェクト</returns>
            public static object Find(CustomSerializeArrayList paramArray, Type type, FIND_TYPE pattern)
            {
                int position;
                return Find(paramArray, type, pattern, out position);
            }

            /// <summary>
            /// ArrayListが空かどうかを判断する
            /// </summary>
            /// <param name="al">検査対象ArrayList</param>
            /// <returns>true:空 false:空でない</returns>
            public static bool IsEmpty(ArrayList al)
            {
                if (al == null || al.Count <= 0) return true;
                return false;
            }

            /// <summary>
            /// ArrayListが空かどうかを判断する
            /// </summary>
            /// <param name="al">検査対象ArrayList</param>
            /// <returns>true:空でない false:空</returns>
            public static bool IsNotEmpty(ArrayList al)
            {
                return !IsEmpty(al);
            }
        }
# endif
        # endregion --- DEL 2008/08/25 M.Kubota ---<<<
    }
}
