//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : トヨタ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 李占川
// 作 成 日  2010/01/04  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 李占川
// 修 正 日  2010/01/19  修正内容 : 仕入明細データも抽出する処理を追加
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 李占川
// 修 正 日  2010/01/22  修正内容 : redmine#2554 進捗更新用メッセージ画面の追加
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 朱 猛
// 修 正 日  2011/01/30  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/12  修正内容 : Redmine:26485
//                                  Redmine仕様連絡 の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/29  修正内容 : Redmine:7733
//                                  Redmine仕様連絡 の対応(再修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/12/15  修正内容 : Redmine#27386トヨタUOEWebタクティー品番の発注対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI 今野
// 作 成 日  2012/09/20  修正内容 : 品番チェック処理の修正
//----------------------------------------------------------------------------//
// 管理番号  11370054-00 作成担当 : 30757 佐々木貴英
// 作 成 日  2017/07/12  修正内容 : トヨタ新WEBUOEロボット対応
//                                  ②発注バックアップデータの末尾にゴミが含まれる
//                                    既存障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using System.IO;
using System.Data;
using System.Globalization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// トヨタ回答データ取込処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : トヨタ回答データ取込処理のアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/01/04</br>
    /// <br>UpdateNote : 2010/01/19 李占川</br>
    /// <br>             redmine#2510 仕入明細データも抽出する処理を追加</br>
    /// <br>UpdateNote : 2010/01/22 李占川</br>
    /// <br>             redmine#2554 進捗更新用メッセージ画面の追加</br>
    /// <br>Update Note : 2011/01/30 朱 猛</br>
    /// <br>              UOE自動化改良</br>
    /// <br>Update Note : 2017/07/12 30757 佐々木貴英</br>
    /// <br>管理番号    : 11370054-00 トヨタ新WEBUOEロボット対応</br>
    /// <br>              ②発注バックアップデータの末尾にゴミが含まれる既存障害対応</br>
    /// </remarks>
    public class UOEOrderDtlToyotaAcs
    {
        # region プライベート変数
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private UOESupplierAcs _uOESupplierAcs;
        private UOEOrderDtlAcs _uOEOrderDtlAcs;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;

        private DN_H dn_h = new DN_H();
        private int _systemDivCd = 0;
        private List<UOEOrderDtlWork> _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
        private List<StockDetailWork> _stockDetailWorkList = new List<StockDetailWork>();
        # endregion

        # region プライベート定数
        /*----------------------------------------------------------------------------------*/
        // datatable名称用
        /// <summary>
        /// datatable名称
        /// </summary>
        public static string TABLE_ID = "DETAIL_TABLE";
        /// <summary>
        /// No.
        /// </summary>
        public static string NO = "No";
        /// <summary>
        /// 品番
        /// </summary>
        public static string GOODSNO = "GoodsNo";
        /// <summary>
        /// ﾒｰｶｰ(タイトル)	
        /// </summary>
        public static string GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>
        /// 品名(タイトル)	
        /// </summary>
        public static string GOODSNAME = "GoodsName";
        /// <summary>
        /// 数量(タイトル)	
        /// </summary>
        public static string COUNT = "Count";
        /// <summary>
        /// 回答品番(タイトル)	
        /// </summary>
        public static string ANSWERPARTSNO = "AnswerPartsNo";
        /// <summary>
        /// 定価(タイトル)	
        /// </summary>
        public static string LISTPRICE = "ListPrice";
        /// <summary>
        /// 単価(タイトル)	
        /// </summary>
        public static string SALESUNITCOST = "SalesUnitCost";
        /// <summary>
        /// コメント(タイトル)	
        /// </summary>
        public static string COMMENT = "Comment";
        /// <summary>
        /// 拠点伝票番号(タイトル)	
        /// </summary>
        public static string UOESECTIONSLIPNO = "UOESectionSlipNo";
        /// <summary>
        /// 出荷数(タイトル)	
        /// </summary>
        public static string UOESECTOUTGOODSCNT = "UOESectOutGoodsCnt";
        /// <summary>
        /// BO伝票番号1(タイトル)
        /// </summary>
        public static string BOSLIPNO1 = "BOSlipNo1";
        /// <summary>
        /// 出荷数(タイトル)		
        /// </summary>
        public static string BOSHIPMENTCNT1 = "BOShipmentCnt1";
        /// <summary>
        /// BO伝票番号2(タイトル)	
        /// </summary>
        public static string BOSLIPNO2 = "BOSlipNo2";
        /// <summary>
        /// 出荷数(タイトル)		
        /// </summary>
        public static string BOSHIPMENTCNT2 = "BOShipmentCnt2";
        /// <summary>
        /// BO伝票番号3(タイトル)	
        /// </summary>
        public static string BOSLIPNO3 = "BOSlipNo3";
        /// <summary>
        /// 出荷数(タイトル)		
        /// </summary>
        public static string BOSHIPMENTCNT3 = "BOShipmentCnt3";
        /// <summary>
        /// ﾒｰｶｰﾌｫﾛｰ数(タイトル)	
        /// </summary>
        public static string MAKERFOLLOWCNT = "MakerFollowCnt";
        //------ADD BY 凌小青 on 2011/11/12 for Redmine#26485------>>>>>>>
        /// <summary>
        /// オンライン番号(タイトル)	
        /// </summary>
        public static string ONLINENO = "OnlineNo";
        //------ADD BY 凌小青 on 2011/11/12 for Redmine#26485------<<<<<<<

        //ヘッドエラーメッセージ
        private const string MSG_TRA = "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ";	// 0x11  0xf1  0xf1  0xf1
        private const string MSG_UCD = "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ";	// 0x12  0xf7  0xf7
        private const string MSG_PAS = "ﾊﾟｽﾜｰﾄﾞｴﾗｰ";	// 0x14
        private const string MSG_RUS = "ﾙｽﾊﾞﾝｴﾗｰ";	// 0x88
        private const string MSG_ELS = "ｿﾉﾀｴﾗｰ";	// 0x99
        private const string MSG_HEN = "ﾍﾝｼﾝﾃﾞｰﾀﾅｼ";	//       0xf2
        private const string MSG_NOU = "ﾉｳﾋﾝｺｰﾄﾞﾅｼ";	//       0xf3
        private const string MSG_DAT = "ﾃﾞｰﾀﾅｼ";	//       0xf4  0xf4  0xf4
        private const string MSG_STK = "ｼﾃｲｷｮﾃﾝｴﾗｰ";	//       0xf5
        private const string MSG_KUF = "ｶｼｭｳｳﾘｱｹﾞﾌｶ";	//       0xc3
        private const string MSG_HTA = "ﾊｯﾁｭｳﾀﾝﾄｳｼｬｴﾗｰ";	//       0xc4
        private const string MSG_FNC = "ﾌｫﾛｰﾉｰﾋﾝｺｰﾄﾞﾅｼ";	//       0xc5
        private const string MSG_KOC = "ｶｼｭｳｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ";	//       0xc6

        private const string COMMASSEMBLY_ID = "0103";
        private const string AUTOCOMMASSEMBLY_ID = "0104"; // ADD 2010/01/30

        private const Int32 ctBufLen = 3;		//明細バッファサイズ
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2010/01/22 李占川</br>
        /// <br>             redmine#2554 進捗更新用メッセージ画面の追加</br>
        /// </remarks>
        public UOEOrderDtlToyotaAcs()
        {
            this._uOESupplierAcs = new UOESupplierAcs();
            this._uOEOrderDtlAcs = new UOEOrderDtlAcs();
            this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();

            // --- ADD 2010/01/22 ---------->>>>>
            // DB更新が完了したら進捗表示用フォームを閉じます。
            this._uoeSndRcvCtlAcs.UpdateProgress += new UoeSndRcvCtlAcs.OnUpdateProgress(this.CloseProgressForm);
            // --- ADD 2010/01/22 ----------<<<<<

            // データセット列情報構築処理
            this.DataTableColumnConstruction();
        }
        # endregion

        # region -- 検索処理 --
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="toyotaAnswerDatePara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <param name="results">オンライン番号results</param> //ADD BY 凌小青 on 2011/11/12 for Redmine#26485 
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : RCV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2010/01/19 李占川</br>
        /// <br>             redmine#2510 仕入明細データも抽出する処理を追加</br>
        /// </remarks>
        //public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage)//DEL BY 凌小青 on 2011/11/12 for Redmine#26485 
        public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage, ref List<string> results)//ADD BY 凌小青 on 2011/11/12 for Redmine#26485 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            this._dataTable.Clear();

            List<UOEOrderDtlInfo> rcvDataDtlList;
            // RCV情報取得処理
            string fileName = toyotaAnswerDatePara.AnswerSaveFolder + "\\HATTU.RCV";
            //status = this.GetRCVData(out rcvDataDtlList, fileName, ref errMessage);//DEL BY 凌小青 on 2011/11/12 for Redmine#26485
            //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>
            //トヨタbakファイル
            string toyotaFlod = toyotaAnswerDatePara.AnswerSaveFolder;
            string month = DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month.ToString()) : (DateTime.Now.Month.ToString());
            string hour = DateTime.Now.Hour < 10 ? ("0" + DateTime.Now.Hour.ToString()) : (DateTime.Now.Hour.ToString());
            string day = DateTime.Now.Day < 10 ? ("0" + DateTime.Now.Day.ToString()) : (DateTime.Now.Day.ToString());
            string minuet = DateTime.Now.Minute < 10 ? ("0" + DateTime.Now.Minute.ToString()) : (DateTime.Now.Minute.ToString());
            string second = DateTime.Now.Second < 10 ? ("0" + DateTime.Now.Second.ToString()) : (DateTime.Now.Second.ToString());
            string bakFileName = "HATTU_" + DateTime.Now.Year
                                           + month
                                           + day
                                           + hour
                                           + minuet
                                           + second
                                           + ".RCV";
            if (!File.Exists(toyotaFlod + "\\" + bakFileName))
            {
                CopyFile(fileName, toyotaFlod + "\\" + bakFileName);
            }
            status = this.GetRCVData(out rcvDataDtlList, toyotaFlod + "\\" + bakFileName, ref errMessage);
            //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<<<<

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // RCVのデータがない場合
            if (rcvDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 発注回答データのリマーク2
            //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>>>>
            List<String> uoeRemarks = new List<String>();
            for (int i = 0; i < rcvDataDtlList.Count; i++)
            {
                uoeRemarks.Add(rcvDataDtlList[i].UoeRemark2);
            }
            //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<<<<
            string uoeRemark2 = rcvDataDtlList[0].UoeRemark2;
            // システム区分
            this._systemDivCd = Int32.Parse(uoeRemark2.Substring(1, 1));

            // UOE発注データを検索,検索条件の設定
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();
            para.EnterpriseCode = toyotaAnswerDatePara.EnterpriseCode; //企業コード					
            para.CashRegisterNo = 0; //レジ番号					
            para.SystemDivCd = this._systemDivCd; //システム区分	
            para.St_InputDay = DateTime.MinValue; //開始入力日					
            para.Ed_InputDay = DateTime.MaxValue; //終了入力日					
            para.CustomerCode = 0; //得意先コード					
            para.UOESupplierCd = toyotaAnswerDatePara.UOESupplierCd; //UOE発注先コード					
            para.St_OnlineNo = int.MinValue; //開始呼出番号					
            para.Ed_OnlineNo = int.MaxValue; //終了呼出番号					
            para.DataSendCodes = new int[] { 1 }; //データ送信フラグ					

            // UOE発注データを検索
            List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>(); // UOE発注データ
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>(); // 仕入明細データ

            status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

            if (status != 0)
            {
                if (uOEOrderDtlWorkList == null || uOEOrderDtlWorkList.Count == 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // トヨタ発注処理で作成されたデータの絞込み
            //List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemark2);//DEL BY 凌小青 on 2011/11/12 for Redmine#26485
            List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemarks);//ADD BY 凌小青 on 2011/11/12 for Redmine#26485

            // 絞り込まれた発注データと対になる仕入明細データを抽出
            List<StockDetailWork> retStockDetailWorkList = this.FilterStockDetailList(retuOEOrderDtlWorkList, stockDetailWorkList); // ADD 2010/01/19

            if (retuOEOrderDtlWorkList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 対象UOE発注データを回答発注データのソート順でソート
            retuOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());
            //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>
            string message = "";
            results = OnlineMergerList(retuOEOrderDtlWorkList, rcvDataDtlList, ref message);
            if (results.Count > 0)
            {
                errMessage = message;
                status = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
            }
            else
            {
                this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);
            }
            //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<
            //this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);//DEL BY 凌小青 on 2011/11/12 for Redmine#26485

            // データセット行増加処理
            this.DataTableAddRow(retuOEOrderDtlWorkList);

            // 確定処理使用
            this._uOEOrderDtlWorkList = retuOEOrderDtlWorkList;

            // --- ADD 2010/01/19 ---------->>>>>
            //this._stockDetailWorkList = stockDetailWorkList;
            this._stockDetailWorkList = retStockDetailWorkList;
            // --- ADD 2010/01/19 ----------<<<<<

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="toyotaAnswerDatePara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <param name="rem2">リマーク２</param>
        /// <param name="results">オンライン番号results</param> //ADD BY 凌小青 on 2011/11/29 for Redmine#7733 
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : RCV情報を取得処理する。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2011/01/30</br>
        /// </remarks>
        //public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage, string rem2) //DEL BY 凌小青 on 2011/11/29 for Redmine#7733
        public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage, List<string> rem2, ref List<string> results)//ADD BY 凌小青 on 2011/11/29 for Redmine#7733
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            this._dataTable.Clear();

            List<UOEOrderDtlInfo> rcvDataDtlList;
            // RCV情報取得処理
            string fileName = toyotaAnswerDatePara.AnswerSaveFolder + "\\HATTU.RCV";
            //status = this.GetRCVData(out rcvDataDtlList, fileName, ref errMessage);//ADD BY 凌小青 on 2011/11/29 for Redmine#7733
            //--------ADD BY 凌小青 on 2011/11/29 for Redmine#7733 ---------->>>>>>>>>>>>>
            //トヨタbakファイル
            string toyotaFlod = toyotaAnswerDatePara.AnswerSaveFolder;
            string month = DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month.ToString()) : (DateTime.Now.Month.ToString());
            string hour = DateTime.Now.Hour < 10 ? ("0" + DateTime.Now.Hour.ToString()) : (DateTime.Now.Hour.ToString());
            string day = DateTime.Now.Day < 10 ? ("0" + DateTime.Now.Day.ToString()) : (DateTime.Now.Day.ToString());
            string minuet = DateTime.Now.Minute < 10 ? ("0" + DateTime.Now.Minute.ToString()) : (DateTime.Now.Minute.ToString());
            string second = DateTime.Now.Second < 10 ? ("0" + DateTime.Now.Second.ToString()) : (DateTime.Now.Second.ToString());
            string bakFileName = "HATTU_" + DateTime.Now.Year
                                           + month
                                           + day
                                           + hour
                                           + minuet
                                           + second
                                           + ".RCV";
            if (!File.Exists(toyotaFlod + "\\" + bakFileName))
            {
                CopyFile(fileName, toyotaFlod + "\\" + bakFileName);
            }
            status = this.GetRCVData(out rcvDataDtlList, toyotaFlod + "\\" + bakFileName, ref errMessage);
            //--------ADD BY 凌小青 on 2011/11/29 for Redmine#7733 ----------<<<<<<<<<<<<<<<<

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // RCVのデータがない場合
            if (rcvDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 発注回答データのリマーク2
            //string uoeRemark2 = rem2;//DEL BY 凌小青 on 2011/11/29 for Redmine#7733
            string uoeRemark2 = rem2[0];//DEL BY 凌小青 on 2011/11/29 for Redmine#7733
            // システム区分
            this._systemDivCd = Int32.Parse(uoeRemark2.Substring(1, 1));

            // UOE発注データを検索,検索条件の設定
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();
            para.EnterpriseCode = toyotaAnswerDatePara.EnterpriseCode; //企業コード					
            para.CashRegisterNo = 0; //レジ番号					
            para.SystemDivCd = this._systemDivCd; //システム区分	
            para.St_InputDay = DateTime.MinValue; //開始入力日					
            para.Ed_InputDay = DateTime.MaxValue; //終了入力日					
            para.CustomerCode = 0; //得意先コード					
            para.UOESupplierCd = toyotaAnswerDatePara.UOESupplierCd; //UOE発注先コード					
            para.St_OnlineNo = int.MinValue; //開始呼出番号					
            para.Ed_OnlineNo = int.MaxValue; //終了呼出番号					
            para.DataSendCodes = new int[] { 1 }; //データ送信フラグ					

            // UOE発注データを検索
            List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>(); // UOE発注データ
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>(); // 仕入明細データ

            status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

            if (status != 0)
            {
                if (uOEOrderDtlWorkList == null || uOEOrderDtlWorkList.Count == 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // トヨタ発注処理で作成されたデータの絞込み
            //List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemark2);//DEL BY 凌小青 on 2011/11/29 for Redmine#7733
            List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, rem2);// ADD BY 凌小青 on 2011/11/29 for Redmine#7733

            // 絞り込まれた発注データと対になる仕入明細データを抽出
            List<StockDetailWork> retStockDetailWorkList = this.FilterStockDetailList(retuOEOrderDtlWorkList, stockDetailWorkList); // ADD 2010/01/19

            if (retuOEOrderDtlWorkList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 対象UOE発注データを回答発注データのソート順でソート
            retuOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());
            //--------ADD BY 凌小青 on 2011/11/29 for Redmine#7733 ---------->>>>>>>>>>>>>
            string message = "";
            results = OnlineMergerList(retuOEOrderDtlWorkList, rcvDataDtlList, ref message);
            if (results.Count > 0)
            {
                errMessage = message;
                status = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
            }
            else
            {
            this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);
            }
            //--------ADD BY 凌小青 on 2011/11/29 for Redmine#7733 ----------<<<<<<<<<<<<<
            //this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);//DEL BY 凌小青 on 2011/11/29 for Redmine#7733

            // データセット行増加処理
            this.DataTableAddRow(retuOEOrderDtlWorkList);

            // 確定処理使用
            this._uOEOrderDtlWorkList = retuOEOrderDtlWorkList;

            this._stockDetailWorkList = retStockDetailWorkList;

            return status;
        }

        //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>
        //---UPD 2017/07/12 30757 佐々木貴英 トヨタ新WEBUOEロボット対応 ----->>>>>
        ///// <summary>
        ///// bakファイル
        ///// </summary>
        ///// <param name="srcPath"></param>
        ///// <param name="dirPath"></param> 
        ///// <br>Note       : bakファイル。</br>
        ///// <br>Programmer : 凌小青</br>
        ///// <br>Date       : 2011/11/12</br>
        ///// </remarks>
        //private void CopyFile(string srcPath, string dirPath)
        //{
        //    FileStream srcFile = new FileStream(srcPath, FileMode.Open);
        //    FileStream dirFile = new FileStream(dirPath, FileMode.Create);
        //    BufferedStream bs = null;
        //    BufferedStream bs2 = null;
        //    try
        //    {
        //        byte[] data = new byte[1024];
        //        bs = new BufferedStream(srcFile);
        //        bs2 = new BufferedStream(dirFile);
        //        while (bs.Read(data, 0, data.Length) > 0)
        //        {
        //            bs2.Write(data, 0, data.Length);
        //            bs2.Flush();
        //        }
        //    }
        //    catch (IOException)
        //    {
        //        return;
        //    }
        //    finally
        //    {
        //        bs.Close();
        //        bs2.Close();
        //        srcFile.Close();
        //        dirFile.Close();
        //    }
        //}
        /// <summary>
        /// コピー元ファイルをコピー先ファイルにコピーする
        /// </summary>
        /// <param name="srcPath">コピー元ファイル名（フルパス）</param>
        /// <param name="dirPath">コピー先ファイル名（フルパス）</param> 
        /// <remarks>
        /// <br>Note       : bakファイル。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011/11/12</br>
        /// <br>Update Note: 2017/07/12 30757 佐々木貴英</br>
        /// <br>管理番号   : 11370054-00 トヨタ新WEBUOEロボット対応</br>
        /// <br>             ②発注バックアップデータの末尾にゴミが含まれる既存障害対応</br>
        /// </remarks>
        private void CopyFile( string srcPath, string dirPath )
        {
            File.Copy( srcPath, dirPath );
        }
        //---UPD 2017/07/12 30757 佐々木貴英 トヨタ新WEBUOEロボット対応 -----<<<<<

        /// <summary>
        /// 回答データと発注データの整合性チェック
        /// </summary>
        /// <param name="workList"></param>
        /// <param name="dateList"></param>
        /// <param name="message"></param> 
        /// <returns>List</returns>
        /// <br>Note       : 回答データと発注データの整合性チェック。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011/11/12</br>
        private List<string> OnlineMergerList(List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList, ref string message)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < workList.Count; i++)
            {
                if (i < dateList.Count)
                {
                    //UOE代替マークなし					
                    // --- DEL K2012/09/20 ---------------------------->>>>>
                    //if ("".Equals(dateList[i].UOESubstMark.Trim()) || null == dateList[i].UOESubstMark)
                    // --- DEL K2012/09/20 ----------------------------<<<<<
                    // --- ADD K2012/09/20 ---------------------------->>>>>
                    if ("".Equals(dateList[i].UOESubstMark.Trim()) || null == dateList[i].UOESubstMark || "0".Equals(dateList[i].UOESubstMark.Trim()))
                    // --- ADD K2012/09/20 ----------------------------<<<<<
                    {
                        //if (dateList[i].AnswerPartsNo.Trim() != workList[i].GoodsNo) //DEL BY 凌小青 on 2011/11/29 for Redmine#7733
                        //if (dateList[i].AnswerPartsNo.Trim() != workList[i].GoodsNoNoneHyphen)//ADD BY 凌小青 on 2011/11/29 for Redmine#7733 // DEL 2011/12/15 yangmj for Redmine#
                        if (dateList[i].AnswerPartsNo.Trim().Replace("-", "") != workList[i].GoodsNoNoneHyphen) // ADD 2011/12/15 yangmj for Redmine#
                        {
                            message = "下記のオンライン番号の明細内容が異なりますので" + "\r\n" + "取込処理を中断いたします。 \r\n ";
                            if (results.Contains(workList[i].OnlineNo.ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                results.Add(workList[i].OnlineNo.ToString());
                            }
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// トヨタ発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">RCV情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : トヨタ発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011/11/12</br>
        /// </remarks>
        private List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, List<String> remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            foreach (UOEOrderDtlWork work in list)
            {
                for (int i = 0; i < remark2.Count; i++)
                {
                    if (work.CommAssemblyId == COMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2[i]
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                        break;
                    }
                    //--------ADD BY 凌小青 on 2011/11/29-------------->>>>>>>>>>
                    else if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                         && work.UoeRemark2 == remark2[i]
                         && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                        break;
                    }
                   //--------ADD BY 凌小青 on 2011/11/29--------------<<<<<<<<<<<<
                }
            }

            return retList;
        }
        //--------ADD BY 凌小青 on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<<<<


        /// <summary>
        /// RCV情報取得処理
        /// </summary>
        /// <param name="rcvDataDtlList">RCV情報</param>
        /// <param name="filePathName">ファイル名前</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : RCV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private int GetRCVData(out List<UOEOrderDtlInfo> rcvDataDtlList, string filePathName, ref string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // RCV情報
            rcvDataDtlList = new List<UOEOrderDtlInfo>();

            FileStream fileStream = null;
            try
            {
                // 使用中判断
                try
                {
                    fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                }
                catch(IOException)
                {
                    errMessage = "発注回答ファイルが使用中です。";
                    // 異常場合
                    return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                }

                int recordLength = 511;
                int num = (int)fileStream.Length / recordLength;

                for (int i = 0; i < num; i++)
                {
                    this.dn_h.Clear(0x00);

                    byte[] line = new byte[recordLength];
                    fileStream.Read(line, 0, line.Length);
                    this.FromByteArray(line);
                    this.ConverDNHToUOEOrderDtlInfo(ref rcvDataDtlList);
                }
            }
            catch
            {
                // 異常場合
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return status;
        }
        # endregion

        # region -- 確定処理 --
        // --- ADD 2010/01/22 ---------->>>>>
        #region 進捗表示

        /// <summary>進捗表示用フォーム</summary>
        SFCMN00299CA _progressForm;
        /// <summary>進捗表示用フォームを取得または設定します。</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _progressForm; }
            set { _progressForm = value; }
        }

        /// <summary>
        /// 進捗表示用フォームを閉じるイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void CloseProgressForm(object sender, UoeSndRcvCtlAcs.UpdateProgressEventArgs e)
        {
            if (ProgressForm == null) return;

            // DB更新が完了したら進捗表示用フォームを閉じます。
            if (e.ProgressState.Equals(UoeSndRcvCtlAcs.SendAndReceiveProgress.DoneUpdateDB))
            {
                ProgressForm.Close();
            }
        }

        #endregion // 進捗表示
        // --- ADD 2010/01/22 ----------<<<<<

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="toyotaAnswerDatePara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : 確定処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2010/01/19 李占川</br>
        /// <br>             redmine#2510 仕入明細データも抽出する処理を追加</br>
        /// </remarks>
        public int DoConfirm(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = string.Empty;

            // --- ADD 2010/01/19 ---------->>>>>
            if (_uOEOrderDtlWorkList.Count == 0 || _stockDetailWorkList.Count == 0)
            {
                errMessage = "取込処理に失敗しました。";
                return (-1);
            }
            // --- ADD 2010/01/19 ----------<<<<<

            // 条件クラス
            UoeSndRcvCtlPara uoeSndRcvCtlPara = new UoeSndRcvCtlPara();
            uoeSndRcvCtlPara.BusinessCode = 1; // 1:発注 2:見積 3:在庫確認 4:取消処理
            uoeSndRcvCtlPara.EnterpriseCode = toyotaAnswerDatePara.EnterpriseCode;
            uoeSndRcvCtlPara.SystemDivCd = this._systemDivCd;
            uoeSndRcvCtlPara.ProcessDiv = 1;            //0：通常、1：復旧

            status = this._uoeSndRcvCtlAcs.UoeSndRcvCtl(uoeSndRcvCtlPara, this._uOEOrderDtlWorkList, this._stockDetailWorkList, out errMessage);

            return status;
        }
        # endregion 確定処理

        # region -- キャッシュ処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 発注先の算出
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE発注先マスタInfo</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">ログイン拠点</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 発注先の算出処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            outUOESupplierlilst = new ArrayList();

            // 検索結果
            ArrayList uOESupplierList = new ArrayList();

            // ＵＯＥ発注先マスタを読み込み
            status = this._uOESupplierAcs.SearchAll(out uOESupplierList, enterpriseCode, sectionCode);

            // 正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = 0;

                foreach (UOESupplier uOESupplier in uOESupplierList)
                {
                    if (uOESupplier.LogicalDeleteCode == 0 && uOESupplier.CommAssemblyId == COMMASSEMBLY_ID)
                    {
                        outUOESupplierlilst.Add(uOESupplier);
                    }
                }
            }

            return status;
        }
        # endregion

        # region -- DataTableの処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 処理結果
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>処理結果をを取得</remarks>
        public DataTable DetailDataTable
        {
            get { return this._dataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._dataTable.Clear();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void DataTableColumnConstruction()
        {
            DataTable table = new DataTable(TABLE_ID);

            // Addを行う順番が、列の表示順位となります。
            table.Columns.Add(NO, typeof(string));   // No.
            table.Columns.Add(GOODSNO, typeof(string)); // 品番
            table.Columns.Add(GOODSMAKERCD, typeof(Int32)); // ﾒｰｶｰ(タイトル)				
            table.Columns.Add(GOODSNAME, typeof(string)); // 品名(タイトル)	
            table.Columns.Add(COUNT, typeof(Double)); // 数量(タイトル)		
            table.Columns.Add(ANSWERPARTSNO, typeof(string)); // 回答品番(タイトル)		
            table.Columns.Add(LISTPRICE, typeof(Double)); // 定価(タイトル)				
            table.Columns.Add(SALESUNITCOST, typeof(Double)); // 単価(タイトル)				
            table.Columns.Add(COMMENT, typeof(string)); // コメント(タイトル)				
            table.Columns.Add(UOESECTIONSLIPNO, typeof(string)); // 拠点伝票番号(タイトル)				
            table.Columns.Add(UOESECTOUTGOODSCNT, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(BOSLIPNO1, typeof(string)); // BO伝票番号1(タイトル)				
            table.Columns.Add(BOSHIPMENTCNT1, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(BOSLIPNO2, typeof(string)); // BO伝票番号2(タイトル)				
            table.Columns.Add(BOSHIPMENTCNT2, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(BOSLIPNO3, typeof(string)); // BO伝票番号3(タイトル)				
            table.Columns.Add(BOSHIPMENTCNT3, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(MAKERFOLLOWCNT, typeof(Int32)); // ﾒｰｶｰﾌｫﾛｰ数(タイトル)	
            table.Columns.Add(ONLINENO, typeof(Int32)); // オンライン番号(タイトル)	  //ADD BY 凌小青 on 2011/11/12 for Redmine#26485


            table.Columns[NO].Caption = "No.";
            table.Columns[GOODSNO].Caption = "品番"; // 品番
            table.Columns[GOODSMAKERCD].Caption = "ﾒｰｶｰ"; // 品番(タイトル)				
            table.Columns[GOODSNAME].Caption = "品名"; // 品名(タイトル)				
            table.Columns[COUNT].Caption = "数量"; // 数量(タイトル)				
            table.Columns[ANSWERPARTSNO].Caption = "回答品番"; // 回答品番(タイトル)				
            table.Columns[LISTPRICE].Caption = "定価"; // 定価(タイトル)				
            table.Columns[SALESUNITCOST].Caption = "単価"; // 単価(タイトル)				
            table.Columns[COMMENT].Caption = "コメント"; // コメント(タイトル)				
            table.Columns[UOESECTIONSLIPNO].Caption = "拠点"; // 拠点伝票番号(タイトル)				
            table.Columns[UOESECTOUTGOODSCNT].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO1].Caption = "ＳＦ"; // BO伝票番号1(タイトル)				
            table.Columns[BOSHIPMENTCNT1].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO2].Caption = "ＨＦ"; // BO伝票番号2(タイトル)				
            table.Columns[BOSHIPMENTCNT2].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO3].Caption = "ＲＦ"; // BO伝票番号3(タイトル)				
            table.Columns[BOSHIPMENTCNT3].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[MAKERFOLLOWCNT].Caption = "ＭＦ"; // ﾒｰｶｰﾌｫﾛｰ数(タイトル)	
            table.Columns[ONLINENO].ColumnMapping = MappingType.Hidden; //ADD BY 凌小青 on 2011/11/12 for Redmine#26485
            this._dataTable = table;
        }

        /// <summary>
        /// データセット行増加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット行増加処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void DataTableAddRow(List<UOEOrderDtlWork> workList)
        {
            int rowIndex = 1;
            foreach (UOEOrderDtlWork work in workList)
            {
                DataRow row = this._dataTable.NewRow();

                row[NO] = rowIndex.ToString();
                //品番		
                row[GOODSNO] = work.GoodsNo;
                //ﾒｰｶｰ	
                row[GOODSMAKERCD] = work.GoodsMakerCd;
                //品名	
                row[GOODSNAME] = work.GoodsName;
                //数量
                row[COUNT] = work.AcceptAnOrderCnt;
                //回答品番	
                row[ANSWERPARTSNO] = work.AnswerPartsNo;
                //定価	
                row[LISTPRICE] = work.AnswerListPrice;
                //単価	
                row[SALESUNITCOST] = work.AnswerSalesUnitCost;
                //コメント
                if (work.HeadErrorMassage == string.Empty)
                {
                    row[COMMENT] = work.LineErrorMassage;
                }
                else
                {
                    row[COMMENT] = work.HeadErrorMassage;
                }
                //拠点								
                row[UOESECTIONSLIPNO] = work.UOESectionSlipNo;
                //出荷数
                row[UOESECTOUTGOODSCNT] = work.UOESectOutGoodsCnt;
                //ＳＦ								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //出荷数								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //ＨＦ								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //出荷数								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //ＲＦ								
                row[BOSLIPNO3] = work.BOSlipNo3;
                //出荷数								
                row[BOSHIPMENTCNT3] = work.BOShipmentCnt3;
                //ＭＦ								
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;
                //オンライン番号
                row[ONLINENO] = work.OnlineNo; //ADD BY 凌小青 on 2011/11/12 for Redmine#26485

                this._dataTable.Rows.Add(row);
                rowIndex++;
            }
        }
        # endregion

        # region -- その他処理 --
        /// <summary>
        /// トヨタ発注回答ファイルのﾚｺｰﾄﾞの処理
        /// </summary>
        /// <param name="rcvDataDtlList">ﾚｺｰﾄﾞリスト</param>
        /// <remarks>
        /// <br>Note       : トヨタ発注回答ファイルのﾚｺｰﾄﾞを処理</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void ConverDNHToUOEOrderDtlInfo(ref List<UOEOrderDtlInfo> rcvDataDtlList)
        {
            for (int i = 0; i < ctBufLen; i++)
            {
                UOEOrderDtlInfo uOEOrderDtlInfo = new UOEOrderDtlInfo();

                // リマーク2
                uOEOrderDtlInfo.UoeRemark2 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.rem2);
                // 回答品番
                uOEOrderDtlInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);

                if (uOEOrderDtlInfo.AnswerPartsNo.Trim() == string.Empty)
                {
                    continue;
                }
                // 回答品名
                uOEOrderDtlInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hn);

                //代替なし
                if (!((dn_h.ln_h[i].daita[0] == 0x00)
                || (dn_h.ln_h[i].daita[0] == 0x20)
                || (dn_h.ln_h[i].daita[0] == 0x30)))
                {
                    // 代替品番
                    uOEOrderDtlInfo.SubstPartsNo = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);
                }

                // 拠点出庫数						
                uOEOrderDtlInfo.UOESectOutGoodsCnt = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].su);
                // BO出庫数1							
                uOEOrderDtlInfo.BOShipmentCnt1 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbfsu);
                // BO出庫数2	
                uOEOrderDtlInfo.BOShipmentCnt2 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hofsu);
                // BO出庫数3							
                uOEOrderDtlInfo.BOShipmentCnt3 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgfsu);
                // メーカーフォロー数	
                uOEOrderDtlInfo.MakerFollowCnt = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mkfsu);
                // 未出庫数	
                uOEOrderDtlInfo.NonShipmentCnt = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].nonsu);
                // BO在庫数1							
                uOEOrderDtlInfo.BOStockCount1 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbzsu);
                // BO在庫数2	
                uOEOrderDtlInfo.BOStockCount2 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hozsu);
                // BO在庫数3							
                uOEOrderDtlInfo.BOStockCount3 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgzai);
                // UOE拠点伝票番号	
                uOEOrderDtlInfo.UOESectionSlipNo = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kyden);
                // BO伝票№1							
                uOEOrderDtlInfo.BOSlipNo1 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].sbden);
                // BO伝票№2	
                uOEOrderDtlInfo.BOSlipNo2 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hofde);
                // BO伝票№3							
                uOEOrderDtlInfo.BOSlipNo3 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].rgfde);
                // 回答定価			
                uOEOrderDtlInfo.AnswerListPrice = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].l_p);
                // 回答原価単価							
                uOEOrderDtlInfo.AnswerSalesUnitCost = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].d_n);
                // UOE代替マーク							
                uOEOrderDtlInfo.UOESubstMark = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].daita);

                //ヘッドエラーなし
                if (!(dn_h.ln_h[i].lerrC[0] == 0x00
                    || dn_h.ln_h[i].lerrC[0] == 0x20))
                {
                    string errMessage = GetHeadErrorMassage(dn_h.ln_h[i].lerrC[0]);
                    //ヘッドエラーメッセージ
                    uOEOrderDtlInfo.HeadErrorMassage = errMessage;
                }

                // ラインエラーメッセージ							
                uOEOrderDtlInfo.LineErrorMassage = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].lerrM);

                rcvDataDtlList.Add(uOEOrderDtlInfo);
            }
        }

        /// <summary>
        /// 発注回答データをUOE発注データに反映の処理
        /// </summary>
        /// <param name="workList">UOE発注データ</param>
        /// <param name="dateList">発注回答データ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注回答データをUOE発注データに反映ﾞを処理</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2011/01/30 朱 猛</br>
        /// <br>             UOE自動化改良</br>
        /// </remarks>
        private int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                for (int i = 0; i < workList.Count; i++)
                {
                    if (i < dateList.Count)
                    {
                        // 受信日付	
                        workList[i].ReceiveDate = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd"), "yyyyMMdd", CultureInfo.InvariantCulture);
                        //受信時刻
                        workList[i].ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss"));
                        //回答品番
                        workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                        //回答品名
                        workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                        //代替品番
                        workList[i].SubstPartsNo = dateList[i].SubstPartsNo;
                        //拠点出庫数							
                        workList[i].UOESectOutGoodsCnt = dateList[i].UOESectOutGoodsCnt;
                        //BO出庫数1	
                        workList[i].BOShipmentCnt1 = dateList[i].BOShipmentCnt1;
                        //BO出庫数2							
                        workList[i].BOShipmentCnt2 = dateList[i].BOShipmentCnt2;
                        //BO出庫数3							
                        workList[i].BOShipmentCnt3 = dateList[i].BOShipmentCnt3;
                        //メーカーフォロー数							
                        workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
                        //未出庫数	
                        workList[i].NonShipmentCnt = dateList[i].NonShipmentCnt;
                        //BO在庫数1							
                        workList[i].BOStockCount1 = dateList[i].BOStockCount1;
                        //BO在庫数2							
                        workList[i].BOStockCount2 = dateList[i].BOStockCount2;
                        //BO在庫数3							
                        workList[i].BOStockCount3 = dateList[i].BOStockCount3;
                        //UOE拠点伝票番号							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO伝票№1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO伝票№2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;
                        //BO伝票№3							
                        workList[i].BOSlipNo3 = dateList[i].BOSlipNo3;
                        //回答定価				
                        workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        //回答原価単価							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
                        //UOE代替マーク							
                        workList[i].UOESubstMark = dateList[i].UOESubstMark;
                        //ヘッドエラーメッセージ	
                        workList[i].HeadErrorMassage = dateList[i].HeadErrorMassage;
                        //ラインエラーメッセージ					
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // データ送信区分
                        workList[i].DataSendCode = 5;
                        workList[i].UoeRemark2 = dateList[i].UoeRemark2; // ADD 2011/01/30 朱 猛 // UOEリマーク２
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// トヨタ発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">RCV情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : トヨタ発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2011/01/30 朱 猛</br>
        /// <br>             UOE自動化改良</br>
        /// </remarks>
        private List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)       
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            foreach (UOEOrderDtlWork work in list)
            {
                if (work.CommAssemblyId == COMMASSEMBLY_ID
                    && work.UoeRemark2 == remark2
                    && work.DataRecoverDiv == 0)
                {
                    retList.Add(work);
                }
                // ---ADD 2011/01/30 朱 猛 ---------------------------------------->>>>>
                else if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                && work.UoeRemark2 == remark2
                && work.DataRecoverDiv == 0)
                {
                    retList.Add(work);
                }
                // ---ADD 2011/01/30 朱 猛 ----------------------------------------<<<<<                
            }

            return retList;
        }

        // --- ADD 2010/01/19 ---------->>>>>
        /// <summary>
        /// 絞り込まれた発注データと対になる仕入明細データの抽出処理
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">絞り込まれた発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データリスト</param>
        /// <returns>結果仕入明細データリスト</returns>
        /// <remarks>
        /// <br>Note       : 絞り込まれた発注データと対になる仕入明細データを抽出</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/19</br>
        /// </remarks>
        private List<StockDetailWork> FilterStockDetailList(List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList)
        {
            List<StockDetailWork> retList = new List<StockDetailWork>();

            foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                // 仕入形式
                int supplierFormal = uOEOrderDtlWork.SupplierFormal;
                // 仕入明細通番
                long stockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    if (stockDetailWork.EnterpriseCode == uOEOrderDtlWork.EnterpriseCode
                        && stockDetailWork.SupplierFormal == supplierFormal
                        && stockDetailWork.StockSlipDtlNum == stockSlipDtlNum)
                    {
                        retList.Add(stockDetailWork);
                    }
                }
            }

            return retList;
        }
        // --- ADD 2010/01/19 ----------<<<<<
        # endregion

        # region リスト順の作成処理
        /// <summary>
        /// 対象UOE発注データ比較クラス(オンライン番号(昇順)、インライン行番号(昇順)、UOE発注番号(昇順)、UOE発注行番号(昇順))
        /// </summary>
        /// <remarks>
        /// <br>Note       : 対象UOE発注データ比較クラス。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : Comparer<UOEOrderDtlWork>
        {
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // オンライン番号 
                int result = x.OnlineNo.CompareTo(y.OnlineNo);
                if (result != 0) return result;

                // オンライン行番号
                result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
                if (result != 0) return result;

                // UOE発注番号
                result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
                if (result != 0) return result;

                // UOE発注行番号
                result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
                return result;
            }
        }
        # endregion

        # region ヘッドエラーメッセージの取得
        /// <summary>
        /// ｴﾗｰﾒｯｾｰｼﾞの設定処理
        /// </summary>
        /// <param name="cd">ｺｰﾄﾞ</param>
        /// <returns>ｴﾗｰﾒｯｾｰｼﾞ</returns>
        /// <remarks>
        /// <br>Note       : ｴﾗｰﾒｯｾｰｼﾞの設定処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private string GetHeadErrorMassage(byte cd)
        {
            string str = "";

            switch (cd)
            {
                case 0x11:						//-- "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ" --
                case 0xF1:						//-- "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ" --
                    str = MSG_TRA;
                    break;
                case 0x12:						//-- "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" --
                case 0xF7:						//-- "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" --
                    str = MSG_UCD;
                    break;
                case 0x14:						//-- "ﾊﾟｽﾜｰﾄﾞｴﾗｰ" --
                    str = MSG_PAS;
                    break;
                case 0x88:						//-- "ﾙｽﾊﾞﾝｴﾗｰ" --
                    str = MSG_RUS;
                    break;
                case 0xF2:						//-- "ﾍﾝｼﾝﾃﾞｰﾀﾅｼ" --
                    str = MSG_HEN;
                    break;
                case 0xF3:						//-- "ﾉｳﾋﾝｺｰﾄﾞﾅｼ" --
                    str = MSG_NOU;
                    break;
                case 0xF4:						//-- "ﾃﾞｰﾀﾅｼ" --
                    str = MSG_DAT;
                    break;
                case 0xF5:						//-- "ｼﾃｲｷｮﾃﾝｴﾗｰ" --
                    str = MSG_STK;
                    break;
                case 0xC3:						//-- "ｶｼｭｳｳﾘｱｹﾞﾌｶ" --
                    str = MSG_KUF;
                    break;
                case 0xC4:						//-- "ﾊｯﾁｭｳﾀﾝﾄｳｼｬｴﾗｰ" --
                    str = MSG_HTA;
                    break;
                case 0xC5:						//-- "ﾌｫﾛｰﾉｰﾋﾝｺｰﾄﾞﾅｼ" --
                    str = MSG_FNC;
                    break;
                case 0xC6:						//-- "ｶｼｭｳｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" --
                    str = MSG_KOC;
                    break;
                case 0x99:						//-- "ｿﾉﾀｴﾗｰ" --
                default:
                    str = MSG_ELS;
                    break;
            }
            return (str);
        }
        # endregion

        # region トヨタ発注回答ファイルクラス
        /// <summary>
        /// トヨタ発注回答ファイル＜ライン＞
        /// </summary>
        private class LN_H
        {
            public byte[] mkkbn = new byte[1];	// ﾗｲﾝ      ﾒｰｶｰ区分
            public byte[] hb = new byte[14];	//          品番              
            public byte[] hn = new byte[30];	//	        品名              
            public byte[] l_p = new byte[7];	//          L_P               
            public byte[] d_n = new byte[7];	//          D_N               
            public byte[] jsu = new byte[5];	//          受注数            
            public byte[] su = new byte[5];		//          出庫数            
            public byte[] sbfsu = new byte[5];	//          ｻﾌﾞ本部ﾌｫﾛｰ数     
            public byte[] hofsu = new byte[5];	//          本部ﾌｫﾛｰ数        
            public byte[] rgfsu = new byte[5];	//          ﾙｰﾄ外ﾌｫﾛｰ数       
            public byte[] mkfsu = new byte[5];	//          ﾒｰｶｰﾌｫﾛｰ数        
            public byte[] nonsu = new byte[5];	//          未出庫数          
            public byte[] sbzsu = new byte[5];	//          ｻﾌﾞ本部在庫       
            public byte[] hozsu = new byte[5];	//          本部在庫          
            public byte[] rgzai = new byte[5];	//          ﾙｰﾄ外在庫数       
            public byte[] kyden = new byte[6];	//          主管拠点伝番      
            public byte[] sbden = new byte[6];	//          ｻﾌﾞ本部伝番       
            public byte[] hofde = new byte[6];	//          本部ﾌｫﾛｰ伝番      
            public byte[] rgfde = new byte[6];	//          ﾙｰﾄ外ﾌｫﾛｰ伝番     
            public byte[] daita = new byte[1];	//          代替有無          
            public byte[] hbkbn = new byte[1];	//          品番区分          
            public byte[] syocd = new byte[1];	//          商品CD            
            public byte[] hincd = new byte[4];	//          品目CD            
            public byte[] nkicd = new byte[1];	//          納期CD            
            public byte[] hozcd = new byte[1];	//          本部在庫CD        
            public byte[] lerrC = new byte[1];	//          ﾗｲﾝｴﾗｰC           
            public byte[] lerrM = new byte[6];	//          ﾗｲﾝｴﾗｰM           

            public LN_H()
            {
                Clear(0x00);
            }
            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref mkkbn, cd, mkkbn.Length);	// ﾗｲﾝ      ﾒｰｶｰ区分 
                UoeCommonFnc.MemSet(ref hb, cd, hb.Length);		    //          品番              
                UoeCommonFnc.MemSet(ref hn, cd, hn.Length);		    //          品名              
                UoeCommonFnc.MemSet(ref l_p, cd, l_p.Length);		//          L_P               
                UoeCommonFnc.MemSet(ref d_n, cd, d_n.Length);		//          D_N               
                UoeCommonFnc.MemSet(ref jsu, cd, jsu.Length);		//          受注数            
                UoeCommonFnc.MemSet(ref su, cd, su.Length);		    //          出庫数            
                UoeCommonFnc.MemSet(ref sbfsu, cd, sbfsu.Length);	//          ｻﾌﾞ本部ﾌｫﾛｰ数     
                UoeCommonFnc.MemSet(ref hofsu, cd, hofsu.Length);	//          本部ﾌｫﾛｰ数        
                UoeCommonFnc.MemSet(ref rgfsu, cd, rgfsu.Length);	//          ﾙｰﾄ外ﾌｫﾛｰ数       
                UoeCommonFnc.MemSet(ref mkfsu, cd, mkfsu.Length);	//          ﾒｰｶｰﾌｫﾛｰ数        
                UoeCommonFnc.MemSet(ref nonsu, cd, nonsu.Length);	//          未出庫数          
                UoeCommonFnc.MemSet(ref sbzsu, cd, sbzsu.Length);	//          ｻﾌﾞ本部在庫       
                UoeCommonFnc.MemSet(ref hozsu, cd, hozsu.Length);	//          本部在庫          
                UoeCommonFnc.MemSet(ref rgzai, cd, rgzai.Length);	//          ﾙｰﾄ外在庫数       
                UoeCommonFnc.MemSet(ref kyden, cd, kyden.Length);	//          主管拠点伝番      
                UoeCommonFnc.MemSet(ref sbden, cd, sbden.Length);	//          ｻﾌﾞ本部伝番       
                UoeCommonFnc.MemSet(ref hofde, cd, hofde.Length);	//          本部ﾌｫﾛｰ伝番      
                UoeCommonFnc.MemSet(ref rgfde, cd, rgfde.Length);	//          ﾙｰﾄ外ﾌｫﾛｰ伝番     
                UoeCommonFnc.MemSet(ref daita, cd, daita.Length);	//          代替有無          
                UoeCommonFnc.MemSet(ref hbkbn, cd, hbkbn.Length);	//          品番区分          
                UoeCommonFnc.MemSet(ref syocd, cd, syocd.Length);	//          商品CD            
                UoeCommonFnc.MemSet(ref hincd, cd, hincd.Length);	//          品目CD            
                UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          納期CD            
                UoeCommonFnc.MemSet(ref hozcd, cd, hozcd.Length);	//          本部在庫CD        
                UoeCommonFnc.MemSet(ref lerrC, cd, lerrC.Length);	//          ﾗｲﾝｴﾗｰC           
                UoeCommonFnc.MemSet(ref lerrM, cd, lerrM.Length);	//          ﾗｲﾝｴﾗｰM           
            }
        }

        /// <summary>
        /// トヨタ発注回答ファイル＜本体＞
        /// </summary>
        private class DN_H
        {
            public byte[] acd = new byte[7];		//           相手先ｺｰﾄﾞ       
            public byte[] tcd = new byte[7];		//           当方ｺｰﾄﾞ         
            public byte[] dttm = new byte[6];		//           日付･時刻        
            public byte[] pass = new byte[6];		//           ﾊﾟｽﾜｰﾄﾞ          
            public byte[] kflg = new byte[1];		//           継続ﾌﾗｸﾞ 
            public byte[] nrkdttm = new byte[4];	//           入力日付時間
            public byte[] sysdt = new byte[6];	    //           ｼｽﾃﾑ日付
            public byte[] sbs = new byte[2];	    //           ｽﾍﾟｰｽ
            public byte[] nhkb = new byte[1];		//           納品区分         
            public byte[] fnkb = new byte[1];		//           ﾌｫﾛｰ納品区分     
            public byte[] rem1 = new byte[8];		//           ﾘﾏｰｸ1            
            public byte[] rem2 = new byte[10];	    //           ﾘﾏｰｸ2            
            public byte[] kyo = new byte[2];		//           指定拠点         
            public byte[] tan = new byte[2];		//           担当者ｺｰﾄﾞ  
            public byte[] skbn = new byte[1];		//           処理区分  
            public LN_H[] ln_h = new LN_H[ctBufLen];// ﾗｲﾝ       149ﾊﾞｲﾄ       

            /// <summary>	
            /// コンストラクター
            /// </summary>
            public DN_H()
            {
                Clear(0x00);
            }

            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref acd, cd, acd.Length);		    //           相手先ｺｰﾄﾞ       
                UoeCommonFnc.MemSet(ref tcd, cd, tcd.Length);		    //           当方ｺｰﾄﾞ         
                UoeCommonFnc.MemSet(ref dttm, cd, dttm.Length);		    //           日付･時刻        
                UoeCommonFnc.MemSet(ref pass, cd, pass.Length);		    //           ﾊﾟｽﾜｰﾄﾞ          
                UoeCommonFnc.MemSet(ref kflg, cd, kflg.Length);		    //           継続ﾌﾗｸﾞ  
                UoeCommonFnc.MemSet(ref nrkdttm, cd, nrkdttm.Length);	//           入力日付時間
                UoeCommonFnc.MemSet(ref sysdt, cd, sysdt.Length);	    //           ｼｽﾃﾑ日付
                UoeCommonFnc.MemSet(ref sbs, cd, sbs.Length);	        //           ｽﾍﾟｰｽ
                UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);		    //           納品区分         
                UoeCommonFnc.MemSet(ref fnkb, cd, fnkb.Length);		    //           ﾌｫﾛｰ納品区分     
                UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);		    //           ﾘﾏｰｸ1            
                UoeCommonFnc.MemSet(ref rem2, cd, rem2.Length);		    //           ﾘﾏｰｸ2            
                UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);		    //           指定拠点         
                UoeCommonFnc.MemSet(ref tan, cd, tan.Length);		    //           担当者ｺｰﾄﾞ       
                UoeCommonFnc.MemSet(ref skbn, cd, skbn.Length);		    //           処理区分  

                //明細部
                for (int i = 0; i < ctBufLen; i++)
                {
                    if (ln_h[i] == null)
                    {
                        ln_h[i] = new LN_H();
                    }
                    else
                    {
                        ln_h[i].Clear(0x00);
                    }
                }         
            }
        }
        # endregion

        # region バイト型配列に変換
        /// <summary>
        /// バイト型配列に変換
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : バイト型配列に変換を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void FromByteArray(byte[] line)
        {
            //_detailMax = 0;
            MemoryStream ms = new MemoryStream();
            ms.Write(line, 0, line.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ms.Read(dn_h.acd, 0, dn_h.acd.Length);      //           相手先ｺｰﾄﾞ       
            ms.Read(dn_h.tcd, 0, dn_h.tcd.Length);      //           当方ｺｰﾄﾞ         
            ms.Read(dn_h.dttm, 0, dn_h.dttm.Length);    //           日付･時刻        
            ms.Read(dn_h.pass, 0, dn_h.pass.Length);    //           ﾊﾟｽﾜｰﾄﾞ          
            ms.Read(dn_h.kflg, 0, dn_h.kflg.Length);    //           継続ﾌﾗｸﾞ  
            ms.Read(dn_h.nrkdttm, 0, dn_h.nrkdttm.Length);//         入力日付時間  
            ms.Read(dn_h.sysdt, 0, dn_h.sysdt.Length);  //           ｼｽﾃﾑ日付  
            ms.Read(dn_h.sbs, 0, dn_h.sbs.Length);      //           ｽﾍﾟｰｽ  
            ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);    //           納品区分         
            ms.Read(dn_h.fnkb, 0, dn_h.fnkb.Length);    //           ﾌｫﾛｰ納品区分     
            ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);    //           ﾘﾏｰｸ1            
            ms.Read(dn_h.rem2, 0, dn_h.rem2.Length);    //           ﾘﾏｰｸ2            
            ms.Read(dn_h.kyo, 0, dn_h.kyo.Length);      //           指定拠点         
            ms.Read(dn_h.tan, 0, dn_h.tan.Length);      //           担当者ｺｰﾄﾞ       
            ms.Read(dn_h.skbn, 0, dn_h.skbn.Length);    //           処理区分      

            //明細部
            for (int i = 0; i < ctBufLen; i++)
            {
                ms.Read(dn_h.ln_h[i].mkkbn, 0, dn_h.ln_h[i].mkkbn.Length);	// ﾗｲﾝ      ﾒｰｶｰ区分 
                ms.Read(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);        // ﾗｲﾝ      品番              
                ms.Read(dn_h.ln_h[i].hn, 0, dn_h.ln_h[i].hn.Length);        //          品名              
                ms.Read(dn_h.ln_h[i].l_p, 0, dn_h.ln_h[i].l_p.Length);      //          L_P               
                ms.Read(dn_h.ln_h[i].d_n, 0, dn_h.ln_h[i].d_n.Length);      //          D_N               
                ms.Read(dn_h.ln_h[i].jsu, 0, dn_h.ln_h[i].jsu.Length);      //          受注数            
                ms.Read(dn_h.ln_h[i].su, 0, dn_h.ln_h[i].su.Length);        //          出庫数            
                ms.Read(dn_h.ln_h[i].sbfsu, 0, dn_h.ln_h[i].sbfsu.Length);  //          ｻﾌﾞ本部ﾌｫﾛｰ数     
                ms.Read(dn_h.ln_h[i].hofsu, 0, dn_h.ln_h[i].hofsu.Length);  //          本部ﾌｫﾛｰ数        
                ms.Read(dn_h.ln_h[i].rgfsu, 0, dn_h.ln_h[i].rgfsu.Length);  //          ﾙｰﾄ外ﾌｫﾛｰ数       
                ms.Read(dn_h.ln_h[i].mkfsu, 0, dn_h.ln_h[i].mkfsu.Length);  //          ﾒｰｶｰﾌｫﾛｰ数        
                ms.Read(dn_h.ln_h[i].nonsu, 0, dn_h.ln_h[i].nonsu.Length);  //          未出庫数          
                ms.Read(dn_h.ln_h[i].sbzsu, 0, dn_h.ln_h[i].sbzsu.Length);  //          ｻﾌﾞ本部在庫       
                ms.Read(dn_h.ln_h[i].hozsu, 0, dn_h.ln_h[i].hozsu.Length);  //          本部在庫          
                ms.Read(dn_h.ln_h[i].rgzai, 0, dn_h.ln_h[i].rgzai.Length);  //          ﾙｰﾄ外在庫数       
                ms.Read(dn_h.ln_h[i].kyden, 0, dn_h.ln_h[i].kyden.Length);  //          主管拠点伝番      
                ms.Read(dn_h.ln_h[i].sbden, 0, dn_h.ln_h[i].sbden.Length);  //          ｻﾌﾞ本部伝番       
                ms.Read(dn_h.ln_h[i].hofde, 0, dn_h.ln_h[i].hofde.Length);  //          本部ﾌｫﾛｰ伝番      
                ms.Read(dn_h.ln_h[i].rgfde, 0, dn_h.ln_h[i].rgfde.Length);  //          ﾙｰﾄ外ﾌｫﾛｰ伝番     
                ms.Read(dn_h.ln_h[i].daita, 0, dn_h.ln_h[i].daita.Length);  //          代替有無          
                ms.Read(dn_h.ln_h[i].hbkbn, 0, dn_h.ln_h[i].hbkbn.Length);  //          品番区分          
                ms.Read(dn_h.ln_h[i].syocd, 0, dn_h.ln_h[i].syocd.Length);  //          商品CD            
                ms.Read(dn_h.ln_h[i].hincd, 0, dn_h.ln_h[i].hincd.Length);  //          品目CD            
                ms.Read(dn_h.ln_h[i].nkicd, 0, dn_h.ln_h[i].nkicd.Length);  //          納期CD            
                ms.Read(dn_h.ln_h[i].hozcd, 0, dn_h.ln_h[i].hozcd.Length);  //          本部在庫CD        
                ms.Read(dn_h.ln_h[i].lerrC, 0, dn_h.ln_h[i].lerrC.Length);  //          ﾗｲﾝｴﾗｰC           
                ms.Read(dn_h.ln_h[i].lerrM, 0, dn_h.ln_h[i].lerrM.Length);  //          ﾗｲﾝｴﾗｰM   
            }    

            ms.Close();
        }
        # endregion
    }
}
