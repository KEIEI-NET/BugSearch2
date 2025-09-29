//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ（エクスポート）
// プログラム概要   : 得意先マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/02/01  修正内容 : MANTIS[14951]対応：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当：李亜博
// 修 正 日  2012/06/12  修正内容：大陽案件、Redmine#30393 
//                                 得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当：李亜博
// 修 正 日  2012/07/09  修正内容：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.46の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/24  修正内容 ：大陽案件、Redmine#30387
//                                  動作検証
//----------------------------------------------------------------------------//
// 管理番号  11900025-00 作成担当 ：3H 仰亮亮
// 修 正 日  2023/06/28  修正内容 ：得意先略称エクスポートの不具合対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2012/06/12 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
    /// <br>Update Note: 2012/07/09 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.46の対応</br>
    /// <br>Update Note: 2012/07/24 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  動作検証</br>
    /// <br>Update Note: 2023/06/28 3H 仰亮亮</br>
    /// <br>管理番号   : 11900025-00 得意先略称エクスポートの不具合対応</br>
    /// </remarks>
    public class CustomerExportAcs
    {
        #region ■ Private Member

        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;

        private const string PRINTSET_TABLE = "CustomerExp";
        #endregion

        # region ■Constracter
        /// <summary>
        /// 得意先マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public CustomerExportAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
        }
        # endregion

        #region ■ 得意先マスタ情報検索
        /// <summary>
        /// 得意先マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2012/07/24 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  動作検証</br>
        /// </remarks>
        public int Search(CustomerExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            CreateDataTable(ref dataTable);

            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();

            customerCustomerChangeParamWork.EnterpriseCode = condition.EnterpriseCode;
            customerCustomerChangeParamWork.StCustomerCode = condition.CustomerCdSt;
            customerCustomerChangeParamWork.EdCustomerCode = condition.CustomerCdEd;
            customerCustomerChangeParamWork.StMngSectionCode = condition.SectionCdSt;
            customerCustomerChangeParamWork.EdMngSectionCode = condition.SectionCdEd;
            customerCustomerChangeParamWork.SearchDiv = 1;// ADD  2012/06/12  李亜博 Redmine#30393

            object al = null;

            status = _iCustomerCustomerChangeDB.Search(ref al, customerCustomerChangeParamWork, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList retReatList = (ArrayList)al;
                // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                CustomerInputAcs cust = new CustomerInputAcs();
                int ConsTaxLay = cust.GetConsTaxLayMethod(customerCustomerChangeParamWork.EnterpriseCode, 0);
                int index = 0;
                Dictionary<int, CustomerCustomerChangeResultWork> dict = new Dictionary<int, CustomerCustomerChangeResultWork>();
                int i = 0;
                // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                foreach (CustomerCustomerChangeResultWork customerCustomerChangeResultWork in retReatList)
                {
                   //ConverToDataSetCustomerInf(customerCustomerChangeResultWork, ref dataTable);// DEL  2012/06/12  李亜博 Redmine#30393
                    // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                    if (!dict.ContainsKey(customerCustomerChangeResultWork.CustomerCode))
                        {
                            dict.Add(customerCustomerChangeResultWork.CustomerCode, customerCustomerChangeResultWork);
                            int total = 0;
                            for (int j = i + 1; j < retReatList.Count; j++)
                            {
                                CustomerCustomerChangeResultWork custcust = retReatList[j] as CustomerCustomerChangeResultWork;
                                if (customerCustomerChangeResultWork.CustomerCode == custcust.CustomerCode)
                                {
                                    total += 1;
                                    break;
                                }

                            }
                            if (total == 0) { customerCustomerChangeResultWork.CustRateGrpCode = -1; }
                        }
                        i++;
                        // ------ ADD START 2012/07/24 Redmine#30393 李亜博 for 動作検証-------->>>>
                        if (customerCustomerChangeResultWork.CustLogicalDeleteCode != 0) { customerCustomerChangeResultWork.CustRateGrpCode = -1; }
                        // ------ ADD END 2012/07/24 Redmine#30393 李亜博 for 動作検証--------<<<<
                        ConverToDataSetCustomerInf(customerCustomerChangeResultWork, ref dataTable, ConsTaxLay, index);
                        ++index; 
                    // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region ■ Private Methods
        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));           //  得意先コード
            dataTable.Columns.Add("CustomerSubCodeRF", typeof(string));	      //  得意先サブコード
            dataTable.Columns.Add("NameRF", typeof(string));	              //  名称
            dataTable.Columns.Add("Name2RF", typeof(string));	              //  名称2
            dataTable.Columns.Add("CustomerSnmRF", typeof(string));	          //  得意先略称
            dataTable.Columns.Add("KanaRF", typeof(string));	              //  カナ
            dataTable.Columns.Add("HonorificTitleRF", typeof(string));	      //  敬称
            dataTable.Columns.Add("OutputNameCodeRF", typeof(string));	      //  諸口コード
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));	      //  管理拠点コード
            dataTable.Columns.Add("CustomerAgentCdRF", typeof(string));	      //  顧客担当従業員コード

            dataTable.Columns.Add("OldCustomerAgentCdRF", typeof(string));	  //  旧顧客担当従業員コード
            dataTable.Columns.Add("CustAgentChgDateRF", typeof(string));       //  顧客担当変更日
            dataTable.Columns.Add("TransStopDateRF", typeof(string));	      //  取引中止日	
            dataTable.Columns.Add("CarMngDivCdRF", typeof(string));	          //  車輌管理区分
            dataTable.Columns.Add("CorporateDivCodeRF", typeof(string));       //  個人・法人区分
            dataTable.Columns.Add("AcceptWholeSaleRF", typeof(string));	      //  業販先区分
            dataTable.Columns.Add("CustomerAttributeDivRF", typeof(string));	  //  得意先属性区分
            dataTable.Columns.Add("CustWarehouseCdRF", typeof(string));	      //  得意先優先倉庫コード
            dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));       //  業種コード
            dataTable.Columns.Add("JobTypeCodeRF", typeof(string));	          //  職種コード

            dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	      //  販売エリアコード
            dataTable.Columns.Add("CustAnalysCode1RF", typeof(string));        //  得意先分析コード1
            dataTable.Columns.Add("CustAnalysCode2RF", typeof(string));	      //  得意先分析コード2
            dataTable.Columns.Add("CustAnalysCode3RF", typeof(string));	      //  得意先分析コード3
            dataTable.Columns.Add("CustAnalysCode4RF", typeof(string));	      //  得意先分析コード4
            dataTable.Columns.Add("CustAnalysCode5RF", typeof(string));	      //  得意先分析コード5
            dataTable.Columns.Add("CustAnalysCode6RF", typeof(string));	      //  得意先分析コード6
            dataTable.Columns.Add("ClaimSectionCodeRF", typeof(string));	  //  請求拠点コード
            dataTable.Columns.Add("ClaimCodeRF", typeof(string));              //  請求先コード
            dataTable.Columns.Add("TotalDayRF", typeof(string));	              //  締日

            dataTable.Columns.Add("CollectMoneyCodeRF", typeof(string));	      //  集金月区分コード
            dataTable.Columns.Add("CollectMoneyDayRF", typeof(string));	      //  集金日
            dataTable.Columns.Add("CollectCondRF", typeof(string));	          //  回収条件
            dataTable.Columns.Add("CollectSightRF", typeof(string));	          //  回収サイト
            dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));        //  次回勘定開始日
            dataTable.Columns.Add("BillCollecterCdRF", typeof(string));	      //  集金担当従業員コード
            dataTable.Columns.Add("CustCTaXLayRefCdRF", typeof(string));	      //  得意先消費税転嫁方式参照区分
            dataTable.Columns.Add("ConsTaxLayMethodRF", typeof(string));	      //  消費税転嫁方式
            dataTable.Columns.Add("SalesUnPrcFrcProcCdRF", typeof(string));	  //  売上単価端数処理コード
            dataTable.Columns.Add("SalesMoneyFrcProcCdRF", typeof(string));	  //  売上金額端数処理コード

            dataTable.Columns.Add("SalesCnsTaxFrcProcCdRF", typeof(string));   //  売上消費税端数処理コード
            dataTable.Columns.Add("CreditMngCodeRF", typeof(string));	      //  与信管理区分 
            dataTable.Columns.Add("DepoDelCodeRF", typeof(string));	          //  入金消込区分
            dataTable.Columns.Add("AccRecDivCdRF", typeof(string));	          //  売掛区分
            dataTable.Columns.Add("PostNoRF", typeof(string));	              //  郵便番号
            dataTable.Columns.Add("Address1RF", typeof(string));	          //  住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("Address3RF", typeof(string));	          //  住所3（番地）
            dataTable.Columns.Add("Address4RF", typeof(string));	          //  住所4（アパート名称）
            dataTable.Columns.Add("CustomerAgentRF", typeof(string));         //  得意先担当者

            dataTable.Columns.Add("HomeTelNoRF", typeof(string));             //  電話番号（自宅）
            dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	          //  電話番号（勤務先）
            dataTable.Columns.Add("PortableTelNoRF", typeof(string));	      //  電話番号（携帯）
            dataTable.Columns.Add("OthersTelNoRF", typeof(string));	          //  電話番号（その他）
            dataTable.Columns.Add("HomeFaxNoRF", typeof(string));	          //  FAX番号（自宅）
            dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	          //  FAX番号（勤務先）

            dataTable.Columns.Add("SearchTelNoRF", typeof(string));	          //  電話番号（検索用下4桁）
            dataTable.Columns.Add("MainContactCodeRF", typeof(string));	      //  主連絡先区分
            dataTable.Columns.Add("Note1RF", typeof(string));	              //  備考１
            dataTable.Columns.Add("Note2RF", typeof(string));	              //  備考２
            dataTable.Columns.Add("Note3RF", typeof(string));	              //  備考３

            dataTable.Columns.Add("Note4RF", typeof(string));	              //  備考４
            dataTable.Columns.Add("Note5RF", typeof(string));	              //  備考５ 
            dataTable.Columns.Add("Note6RF", typeof(string));	              //  備考６
            dataTable.Columns.Add("Note7RF", typeof(string));	              //  備考７
            dataTable.Columns.Add("Note8RF", typeof(string));	              //  備考８
            dataTable.Columns.Add("Note9RF", typeof(string));	              //  備考９
            dataTable.Columns.Add("Note10RF", typeof(string));	              // 備考１０
            dataTable.Columns.Add("MainSendMailAddrCdRF", typeof(string));	  //  主送信先メールアドレス区分
            dataTable.Columns.Add("MailAddress1RF", typeof(string));	      //  メールアドレス1	
            dataTable.Columns.Add("MailSendCode1RF", typeof(string));	      //  メール送信区分コード1

            dataTable.Columns.Add("MailAddrKindCode1RF", typeof(string));	  //  メールアドレス種別コード1
            dataTable.Columns.Add("MailAddress2RF", typeof(string));	      // メールアドレス２ 
            dataTable.Columns.Add("MailSendCode2RF", typeof(string));	      //  メール送信区分コード２
            dataTable.Columns.Add("MailAddrKindCode2RF", typeof(string));	  //  メールアドレス種別コード２
            dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	      //  銀行口座１
            dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	      //  銀行口座２
            dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	      //  銀行口座３
            // DEL 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            //  TODO:使用しない…請求書出力区分コード
            //dataTable.Columns.Add("BillOutputCodeRF", typeof(string));	      //  請求書出力区分コード
            // DEL 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<
            dataTable.Columns.Add("ReceiptOutputCodeRF", typeof(string));	  // 領収書出力区分コード
            dataTable.Columns.Add("DmOutCodeRF", typeof(string));	          //  DM出力区分

            dataTable.Columns.Add("SalesSlipPrtDivRF", typeof(string));	      //  売上伝票発行区分
            dataTable.Columns.Add("AcpOdrrSlipPrtDivRF", typeof(string));	  //  受注伝票発行区分
            dataTable.Columns.Add("ShipmSlipPrtDivRF", typeof(string));	      //  出荷伝票発行区分
            dataTable.Columns.Add("EstimatePrtDivRF", typeof(string));	      //  見積書発行区分	
            dataTable.Columns.Add("UOESlipPrtDivRF", typeof(string));	      // UOE伝票発行区分	
            dataTable.Columns.Add("QrcodePrtCdRF", typeof(string));	          //  QRコード印刷
            dataTable.Columns.Add("CustSlipNoMngCdRF", typeof(string));	      //  相手伝票番号管理区分
            dataTable.Columns.Add("CustomerSlipNoDivRF", typeof(string));	  //  得意先伝票番号区分

            // ADD 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            dataTable.Columns.Add("TotalBillOutputDivRF", typeof(string));      // 合計請求書出力区分
            dataTable.Columns.Add("DetailBillOutputCodeRF", typeof(string));    // 明細請求書出力区分
            dataTable.Columns.Add("SlipTtlBillOutputDivRF", typeof(string));    // 伝票合計請求書出力区分
            // ADD 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
            //dataTable.Columns.Add("CustRateGrpFine", typeof(string));          //得意先掛率グループ(優良)// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            dataTable.Columns.Add("CustRateGrpFineAll", typeof(string));          //得意先掛率グループ(優良ALL)// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            dataTable.Columns.Add("CustRateGrpPureAll", typeof(string));       //得意先掛率グループ(純正ALL)
            dataTable.Columns.Add("CustRateGrpPure1", typeof(string));         //得意先掛率グループ純正１
            dataTable.Columns.Add("CustRateGrpPure2", typeof(string));         //得意先掛率グループ純正2
            dataTable.Columns.Add("CustRateGrpPure3", typeof(string));         //得意先掛率グループ純正3
            dataTable.Columns.Add("CustRateGrpPure4", typeof(string));         //得意先掛率グループ純正4
            dataTable.Columns.Add("CustRateGrpPure5", typeof(string));         //得意先掛率グループ純正5
            dataTable.Columns.Add("CustRateGrpPure6", typeof(string));         //得意先掛率グループ純正6
            dataTable.Columns.Add("CustRateGrpPure7", typeof(string));         //得意先掛率グループ純正7
            dataTable.Columns.Add("CustRateGrpPure8", typeof(string));         //得意先掛率グループ純正8
            dataTable.Columns.Add("CustRateGrpPure9", typeof(string));         //得意先掛率グループ純正9
            dataTable.Columns.Add("CustRateGrpPure10", typeof(string));        //得意先掛率グループ純正１0
            dataTable.Columns.Add("CustRateGrpPure11", typeof(string));        //得意先掛率グループ純正１1
            dataTable.Columns.Add("CustRateGrpPure12", typeof(string));        //得意先掛率グループ純正１2
            dataTable.Columns.Add("CustRateGrpPure13", typeof(string));        //得意先掛率グループ純正１3
            dataTable.Columns.Add("CustRateGrpPure14", typeof(string));        //得意先掛率グループ純正１4
            dataTable.Columns.Add("CustRateGrpPure15", typeof(string));        //得意先掛率グループ純正１5
            dataTable.Columns.Add("CustRateGrpPure16", typeof(string));        //得意先掛率グループ純正１6
            dataTable.Columns.Add("CustRateGrpPure17", typeof(string));        //得意先掛率グループ純正１7
            dataTable.Columns.Add("CustRateGrpPure18", typeof(string));        //得意先掛率グループ純正１8
            dataTable.Columns.Add("CustRateGrpPure19", typeof(string));        //得意先掛率グループ純正１9
            dataTable.Columns.Add("CustRateGrpPure20", typeof(string));        //得意先掛率グループ純正20
            dataTable.Columns.Add("CustRateGrpPure21", typeof(string));        //得意先掛率グループ純正21
            dataTable.Columns.Add("CustRateGrpPure22", typeof(string));        //得意先掛率グループ純正22
            dataTable.Columns.Add("CustRateGrpPure23", typeof(string));        //得意先掛率グループ純正23
            dataTable.Columns.Add("CustRateGrpPure24", typeof(string));        //得意先掛率グループ純正24
            dataTable.Columns.Add("CustRateGrpPure25", typeof(string));        //得意先掛率グループ純正25
            //--------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataSet
        /// </summary>
        /// <param name="customerWork">検索結果</param>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="ConsTaxLay">消費税転嫁方式</param>
        /// <param name="para_index">DataTable 行の標的</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2023/06/28 3H 仰亮亮</br>
        /// <br>管理番号   : 11900025-00　得意先略称エクスポートの不具合対応</br>
        /// </remarks>
        //private void ConverToDataSetCustomerInf(CustomerCustomerChangeResultWork customerWork, ref DataTable dataTable)// DEL  2012/06/12  李亜博 Redmine#30393 
        private void ConverToDataSetCustomerInf(CustomerCustomerChangeResultWork customerWork, ref DataTable dataTable, int ConsTaxLay, int para_index)// ADD  2012/06/12  李亜博 Redmine#30393 
        {
            // --------------- DEL START 2012/06/12 Redmine#30393 李亜博-------->>>>
            //DataRow dataRow = dataTable.NewRow();

            //dataRow["CustomerCodeRF"] = AppendZero(customerWork.CustomerCode.ToString(), 8);
            //dataRow["CustomerSubCodeRF"] = customerWork.CustomerSubCode.Trim();
            //dataRow["NameRF"] = GetSubString(customerWork.Name, 30);
            //dataRow["Name2RF"] = GetSubString(customerWork.Name2, 30);
            //dataRow["CustomerSnmRF"] = GetSubString(customerWork.CustomerSnm, 15);
            //dataRow["KanaRF"] = GetSubString(customerWork.Kana, 30);
            //dataRow["HonorificTitleRF"] = GetSubString(customerWork.HonorificTitle, 4);
            //dataRow["OutputNameCodeRF"] = AppendZero(customerWork.OutputNameCode.ToString(), 2);

            //dataRow["MngSectionCodeRF"] = AppendStrZero(customerWork.MngSectionCode, 2);
            //dataRow["CustomerAgentCdRF"] = AppendStrZero(customerWork.CustomerAgentCd, 4);
            //dataRow["OldCustomerAgentCdRF"] = AppendStrZero(customerWork.OldCustomerAgentCd, 4);
            //if (customerWork.CustAgentChgDate == DateTime.MinValue)
            //{
            //    dataRow["CustAgentChgDateRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["CustAgentChgDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.CustAgentChgDate).ToString();
            //}
            //if (customerWork.TransStopDate == DateTime.MinValue)
            //{
            //    dataRow["TransStopDateRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["TransStopDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.TransStopDate).ToString();
            //}

            //dataRow["CarMngDivCdRF"] = customerWork.CarMngDivCd.ToString();
            //dataRow["CorporateDivCodeRF"] = customerWork.CorporateDivCode.ToString();
            //dataRow["AcceptWholeSaleRF"] = customerWork.AcceptWholeSale.ToString();
            //dataRow["CustomerAttributeDivRF"] = customerWork.CustomerAttributeDiv.ToString();
            //dataRow["CustWarehouseCdRF"] = AppendStrZero(customerWork.CustWarehouseCd, 4);
            //dataRow["BusinessTypeCodeRF"] = AppendZero(customerWork.BusinessTypeCode.ToString(), 4);
            //dataRow["JobTypeCodeRF"] = AppendZero(customerWork.JobTypeCode.ToString(), 4);
            //dataRow["SalesAreaCodeRF"] = AppendZero(customerWork.SalesAreaCode.ToString(), 4);
            //dataRow["CustAnalysCode1RF"] = customerWork.CustAnalysCode1.ToString();
            //dataRow["CustAnalysCode2RF"] = customerWork.CustAnalysCode2.ToString();
            //dataRow["CustAnalysCode3RF"] = customerWork.CustAnalysCode3.ToString();
            //dataRow["CustAnalysCode4RF"] = customerWork.CustAnalysCode4.ToString();
            //dataRow["CustAnalysCode5RF"] = customerWork.CustAnalysCode5.ToString();
            //dataRow["CustAnalysCode6RF"] = customerWork.CustAnalysCode6.ToString();

            //dataRow["ClaimSectionCodeRF"] = AppendStrZero(customerWork.ClaimSectionCode, 2);
            //dataRow["ClaimCodeRF"] = AppendZero(customerWork.ClaimCode.ToString(), 8);
            //if (customerWork.TotalDay == 0)
            //{
            //    dataRow["TotalDayRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["TotalDayRF"] = customerWork.TotalDay.ToString();
            //}

            //dataRow["CollectMoneyCodeRF"] = customerWork.CollectMoneyCode.ToString();
            //if (customerWork.CollectMoneyDay == 0)
            //{
            //    dataRow["CollectMoneyDayRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["CollectMoneyDayRF"] = customerWork.CollectMoneyDay.ToString();
            //}
            //dataRow["CollectCondRF"] = GetSubString(customerWork.CollectCond.ToString(), 2);
            //dataRow["CollectSightRF"] = GetSubString(customerWork.CollectSight.ToString(), 3);
            //if (customerWork.NTimeCalcStDate == 0)
            //{
            //    dataRow["NTimeCalcStDateRF"] = DBNull.Value;
            //}
            //else
            //{
            //    dataRow["NTimeCalcStDateRF"] = customerWork.NTimeCalcStDate.ToString();
            //}
            //dataRow["BillCollecterCdRF"] = AppendStrZero(customerWork.BillCollecterCd, 4);

            //dataRow["CustCTaXLayRefCdRF"] = customerWork.CustCTaXLayRefCd.ToString();
            //dataRow["ConsTaxLayMethodRF"] = customerWork.ConsTaxLayMethod.ToString();
            //dataRow["SalesUnPrcFrcProcCdRF"] = customerWork.SalesUnPrcFrcProcCd.ToString();
            //dataRow["SalesMoneyFrcProcCdRF"] = customerWork.SalesMoneyFrcProcCd.ToString();
            //dataRow["SalesCnsTaxFrcProcCdRF"] = customerWork.SalesCnsTaxFrcProcCd.ToString();
            //dataRow["CreditMngCodeRF"] = customerWork.CreditMngCode.ToString();
            //dataRow["DepoDelCodeRF"] = customerWork.DepoDelCode.ToString();
            //dataRow["AccRecDivCdRF"] = customerWork.AccRecDivCd.ToString();

            //dataRow["PostNoRF"] = GetSubString(customerWork.PostNo, 10);
            //dataRow["Address1RF"] = GetSubString(customerWork.Address1, 30);
            //dataRow["Address3RF"] = GetSubString(customerWork.Address3, 22);
            //dataRow["Address4RF"] = GetSubString(customerWork.Address4, 30);
            //dataRow["CustomerAgentRF"] = GetSubString(customerWork.CustomerAgent, 20);

            //dataRow["HomeTelNoRF"] = GetSubString(customerWork.HomeTelNo, 16);
            //dataRow["OfficeTelNoRF"] = GetSubString(customerWork.OfficeTelNo, 16);
            //dataRow["PortableTelNoRF"] = GetSubString(customerWork.PortableTelNo, 16);
            //dataRow["OthersTelNoRF"] = GetSubString(customerWork.OthersTelNo, 16);
            //dataRow["HomeFaxNoRF"] = GetSubString(customerWork.HomeFaxNo, 16);
            //dataRow["OfficeFaxNoRF"] = GetSubString(customerWork.OfficeFaxNo, 16);
            //dataRow["SearchTelNoRF"] = GetSubString(customerWork.SearchTelNo, 4);
            //dataRow["MainContactCodeRF"] = customerWork.MainContactCode;

            //dataRow["Note1RF"] = GetSubString(customerWork.Note1, 20);
            //dataRow["Note2RF"] = GetSubString(customerWork.Note2, 20);
            //dataRow["Note3RF"] = GetSubString(customerWork.Note3, 20);
            //dataRow["Note4RF"] = GetSubString(customerWork.Note4, 20);
            //dataRow["Note5RF"] = GetSubString(customerWork.Note5, 20);
            //dataRow["Note6RF"] = GetSubString(customerWork.Note6, 20);
            //dataRow["Note7RF"] = GetSubString(customerWork.Note7, 20);
            //dataRow["Note8RF"] = GetSubString(customerWork.Note8, 20);
            //dataRow["Note9RF"] = GetSubString(customerWork.Note9, 20);
            //dataRow["Note10RF"] = GetSubString(customerWork.Note10, 20);
            //dataRow["MainSendMailAddrCdRF"] = GetSubString(customerWork.MainSendMailAddrCd.ToString(), 64);
            //dataRow["MailAddress1RF"] = GetSubString(customerWork.MailAddress1, 64);
            //dataRow["MailSendCode1RF"] = customerWork.MailSendCode1.ToString();
            //dataRow["MailAddrKindCode1RF"] = customerWork.MailAddrKindCode1.ToString();
            //dataRow["MailAddress2RF"] = GetSubString(customerWork.MailAddress2, 64);
            //dataRow["MailSendCode2RF"] = customerWork.MailSendCode2.ToString();
            //dataRow["MailAddrKindCode2RF"] = customerWork.MailAddrKindCode2.ToString();


            //dataRow["AccountNoInfo1RF"] = GetSubString(customerWork.AccountNoInfo1, 60);
            //dataRow["AccountNoInfo2RF"] = GetSubString(customerWork.AccountNoInfo2, 60);
            //dataRow["AccountNoInfo3RF"] = GetSubString(customerWork.AccountNoInfo3, 60);
            //// DEL 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            //// TODO:使用しない…請求書出力区分コード
            ////dataRow["BillOutputCodeRF"] = customerWork.BillOutputCode.ToString();
            //// DEL 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<
            //dataRow["ReceiptOutputCodeRF"] = customerWork.ReceiptOutputCode.ToString();
            //dataRow["DmOutCodeRF"] = customerWork.DmOutCode.ToString();
            //dataRow["SalesSlipPrtDivRF"] = customerWork.SalesSlipPrtDiv.ToString();
            //dataRow["AcpOdrrSlipPrtDivRF"] = customerWork.AcpOdrrSlipPrtDiv.ToString();
            //dataRow["ShipmSlipPrtDivRF"] = customerWork.ShipmSlipPrtDiv.ToString();
            //dataRow["EstimatePrtDivRF"] = customerWork.EstimatePrtDiv.ToString();
            //dataRow["UOESlipPrtDivRF"] = customerWork.UOESlipPrtDiv.ToString();
            //dataRow["QrcodePrtCdRF"] = customerWork.QrcodePrtCd.ToString();
            //dataRow["CustSlipNoMngCdRF"] = customerWork.CustSlipNoMngCd.ToString();
            //dataRow["CustomerSlipNoDivRF"] = customerWork.CustomerSlipNoDiv.ToString();

            //// ADD 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            //dataRow["TotalBillOutputDivRF"]     = customerWork.TotalBillOutputDiv.ToString();   // 合計請求書出力区分
            //dataRow["DetailBillOutputCodeRF"]   = customerWork.DetailBillOutputCode.ToString(); // 明細請求書出力区分
            //dataRow["SlipTtlBillOutputDivRF"]   = customerWork.SlipTtlBillOutputDiv.ToString(); // 伝票合計請求書出力区分
            //// ADD 2010/02/01 MANTIS対応[14951]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            //dataTable.Rows.Add(dataRow);
            // --------------- DEL END 2012/06/12 Redmine#30393 李亜博--------<<<<
            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
            int index = -1;
            if (para_index != 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["CustomerCodeRF"].ToString().Equals(customerWork.CustomerCode.ToString("00000000")))
                    {
                        index = i;
                        break;
                    }
                }
            }
            if (index == -1)
            {
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);
                index = dataTable.Rows.Count - 1;

            }
            dataTable.Rows[index]["CustomerCodeRF"] = AppendZero(customerWork.CustomerCode.ToString(), 8);
            dataTable.Rows[index]["CustomerSubCodeRF"] = customerWork.CustomerSubCode.Trim();
            dataTable.Rows[index]["NameRF"] = GetSubString(customerWork.Name, 30);
            dataTable.Rows[index]["Name2RF"] = GetSubString(customerWork.Name2, 30);
            //dataTable.Rows[index]["CustomerSnmRF"] = GetSubString(customerWork.CustomerSnm, 15); // DEL 2023/06/28 3H 仰亮亮
            dataTable.Rows[index]["CustomerSnmRF"] = GetSubString(customerWork.CustomerSnm, 20); // ADD 2023/06/28 3H 仰亮亮
            dataTable.Rows[index]["KanaRF"] = GetSubString(customerWork.Kana, 30);
            dataTable.Rows[index]["HonorificTitleRF"] = GetSubString(customerWork.HonorificTitle, 4);
            dataTable.Rows[index]["OutputNameCodeRF"] = AppendZero(customerWork.OutputNameCode.ToString(), 1);
            dataTable.Rows[index]["MngSectionCodeRF"] = AppendStrZero(customerWork.MngSectionCode, 2);
            dataTable.Rows[index]["CustomerAgentCdRF"] = AppendStrZero(customerWork.CustomerAgentCd, 4);
            dataTable.Rows[index]["OldCustomerAgentCdRF"] = AppendStrZero(customerWork.OldCustomerAgentCd, 4);
            if (customerWork.CustAgentChgDate == DateTime.MinValue)
            {
                dataTable.Rows[index]["CustAgentChgDateRF"] = DBNull.Value;
            }
            else
            {

                dataTable.Rows[index]["CustAgentChgDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.CustAgentChgDate).ToString();
            }
            if (customerWork.TransStopDate == DateTime.MinValue)
            {

                dataTable.Rows[index]["TransStopDateRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["TransStopDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", customerWork.TransStopDate).ToString();
            }

            dataTable.Rows[index]["CarMngDivCdRF"] = customerWork.CarMngDivCd.ToString();
            dataTable.Rows[index]["CorporateDivCodeRF"] = customerWork.CorporateDivCode.ToString();
            dataTable.Rows[index]["AcceptWholeSaleRF"] = customerWork.AcceptWholeSale.ToString();
            dataTable.Rows[index]["CustomerAttributeDivRF"] = customerWork.CustomerAttributeDiv.ToString();
            dataTable.Rows[index]["CustWarehouseCdRF"] = AppendStrZero(customerWork.CustWarehouseCd, 4);
            dataTable.Rows[index]["BusinessTypeCodeRF"] = AppendZero(customerWork.BusinessTypeCode.ToString(), 4);
            dataTable.Rows[index]["JobTypeCodeRF"] = AppendZero(customerWork.JobTypeCode.ToString(), 4);
            dataTable.Rows[index]["SalesAreaCodeRF"] = AppendZero(customerWork.SalesAreaCode.ToString(), 4);
            dataTable.Rows[index]["CustAnalysCode1RF"] = customerWork.CustAnalysCode1.ToString();
            dataTable.Rows[index]["CustAnalysCode2RF"] = customerWork.CustAnalysCode2.ToString();
            dataTable.Rows[index]["CustAnalysCode3RF"] = customerWork.CustAnalysCode3.ToString();
            dataTable.Rows[index]["CustAnalysCode4RF"] = customerWork.CustAnalysCode4.ToString();
            dataTable.Rows[index]["CustAnalysCode5RF"] = customerWork.CustAnalysCode5.ToString();
            dataTable.Rows[index]["CustAnalysCode6RF"] = customerWork.CustAnalysCode6.ToString();

            dataTable.Rows[index]["ClaimSectionCodeRF"] = AppendStrZero(customerWork.ClaimSectionCode, 2);
            dataTable.Rows[index]["ClaimCodeRF"] = AppendZero(customerWork.ClaimCode.ToString(), 8);
            if (customerWork.TotalDay == 0)
            {
                dataTable.Rows[index]["TotalDayRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["TotalDayRF"] = customerWork.TotalDay.ToString();
            }

            dataTable.Rows[index]["CollectMoneyCodeRF"] = customerWork.CollectMoneyCode.ToString();
            if (customerWork.CollectMoneyDay == 0)
            {
                dataTable.Rows[index]["CollectMoneyDayRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["CollectMoneyDayRF"] = customerWork.CollectMoneyDay.ToString();
            }
            dataTable.Rows[index]["CollectCondRF"] = GetSubString(customerWork.CollectCond.ToString(), 2);
            dataTable.Rows[index]["CollectSightRF"] = GetSubString(customerWork.CollectSight.ToString(), 3);
            if (customerWork.NTimeCalcStDate == 0)
            {
                dataTable.Rows[index]["NTimeCalcStDateRF"] = DBNull.Value;
            }
            else
            {
                dataTable.Rows[index]["NTimeCalcStDateRF"] = customerWork.NTimeCalcStDate.ToString();
            }
            dataTable.Rows[index]["BillCollecterCdRF"] = AppendStrZero(customerWork.BillCollecterCd, 4);

            dataTable.Rows[index]["CustCTaXLayRefCdRF"] = customerWork.CustCTaXLayRefCd.ToString();
            if (customerWork.CustCTaXLayRefCd == 0)
            {
                dataTable.Rows[index]["ConsTaxLayMethodRF"] = ConsTaxLay.ToString();
            }
            else
            {
                dataTable.Rows[index]["ConsTaxLayMethodRF"] = customerWork.ConsTaxLayMethod.ToString();
            }
            dataTable.Rows[index]["SalesUnPrcFrcProcCdRF"] = customerWork.SalesUnPrcFrcProcCd.ToString();
            dataTable.Rows[index]["SalesMoneyFrcProcCdRF"] = customerWork.SalesMoneyFrcProcCd.ToString();
            dataTable.Rows[index]["SalesCnsTaxFrcProcCdRF"] = customerWork.SalesCnsTaxFrcProcCd.ToString();
            dataTable.Rows[index]["CreditMngCodeRF"] = customerWork.CreditMngCode.ToString();
            dataTable.Rows[index]["DepoDelCodeRF"] = customerWork.DepoDelCode.ToString();
            dataTable.Rows[index]["AccRecDivCdRF"] = customerWork.AccRecDivCd.ToString();

            dataTable.Rows[index]["PostNoRF"] = GetSubString(customerWork.PostNo, 10);
            dataTable.Rows[index]["Address1RF"] = GetSubString(customerWork.Address1, 30);
            dataTable.Rows[index]["Address3RF"] = GetSubString(customerWork.Address3, 22);
            dataTable.Rows[index]["Address4RF"] = GetSubString(customerWork.Address4, 30);
            dataTable.Rows[index]["CustomerAgentRF"] = GetSubString(customerWork.CustomerAgent, 20);

            dataTable.Rows[index]["HomeTelNoRF"] = GetSubString(customerWork.HomeTelNo, 16);
            dataTable.Rows[index]["OfficeTelNoRF"] = GetSubString(customerWork.OfficeTelNo, 16);
            dataTable.Rows[index]["PortableTelNoRF"] = GetSubString(customerWork.PortableTelNo, 16);
            dataTable.Rows[index]["OthersTelNoRF"] = GetSubString(customerWork.OthersTelNo, 16);
            dataTable.Rows[index]["HomeFaxNoRF"] = GetSubString(customerWork.HomeFaxNo, 16);
            dataTable.Rows[index]["OfficeFaxNoRF"] = GetSubString(customerWork.OfficeFaxNo, 16);
            dataTable.Rows[index]["SearchTelNoRF"] = GetSubString(customerWork.SearchTelNo, 4);
            dataTable.Rows[index]["MainContactCodeRF"] = customerWork.MainContactCode;

            dataTable.Rows[index]["Note1RF"] = GetSubString(customerWork.Note1, 20);
            dataTable.Rows[index]["Note2RF"] = GetSubString(customerWork.Note2, 20);
            dataTable.Rows[index]["Note3RF"] = GetSubString(customerWork.Note3, 20);
            dataTable.Rows[index]["Note4RF"] = GetSubString(customerWork.Note4, 20);
            dataTable.Rows[index]["Note5RF"] = GetSubString(customerWork.Note5, 20);
            dataTable.Rows[index]["Note6RF"] = GetSubString(customerWork.Note6, 20);
            dataTable.Rows[index]["Note7RF"] = GetSubString(customerWork.Note7, 20);
            dataTable.Rows[index]["Note8RF"] = GetSubString(customerWork.Note8, 20);
            dataTable.Rows[index]["Note9RF"] = GetSubString(customerWork.Note9, 20);
            dataTable.Rows[index]["Note10RF"] = GetSubString(customerWork.Note10, 20);
            dataTable.Rows[index]["MainSendMailAddrCdRF"] = GetSubString(customerWork.MainSendMailAddrCd.ToString(), 64);
            dataTable.Rows[index]["MailAddress1RF"] = GetSubString(customerWork.MailAddress1, 64);
            dataTable.Rows[index]["MailSendCode1RF"] = customerWork.MailSendCode1.ToString();
            dataTable.Rows[index]["MailAddrKindCode1RF"] = customerWork.MailAddrKindCode1.ToString();
            dataTable.Rows[index]["MailAddress2RF"] = GetSubString(customerWork.MailAddress2, 64);
            dataTable.Rows[index]["MailSendCode2RF"] = customerWork.MailSendCode2.ToString();
            dataTable.Rows[index]["MailAddrKindCode2RF"] = customerWork.MailAddrKindCode2.ToString();


            dataTable.Rows[index]["AccountNoInfo1RF"] = GetSubString(customerWork.AccountNoInfo1, 60);
            dataTable.Rows[index]["AccountNoInfo2RF"] = GetSubString(customerWork.AccountNoInfo2, 60);
            dataTable.Rows[index]["AccountNoInfo3RF"] = GetSubString(customerWork.AccountNoInfo3, 60);
            dataTable.Rows[index]["ReceiptOutputCodeRF"] = customerWork.ReceiptOutputCode.ToString();
            dataTable.Rows[index]["DmOutCodeRF"] = customerWork.DmOutCode.ToString();
            dataTable.Rows[index]["SalesSlipPrtDivRF"] = customerWork.SalesSlipPrtDiv.ToString();
            dataTable.Rows[index]["AcpOdrrSlipPrtDivRF"] = customerWork.AcpOdrrSlipPrtDiv.ToString();
            dataTable.Rows[index]["ShipmSlipPrtDivRF"] = customerWork.ShipmSlipPrtDiv.ToString();
            dataTable.Rows[index]["EstimatePrtDivRF"] = customerWork.EstimatePrtDiv.ToString();
            dataTable.Rows[index]["UOESlipPrtDivRF"] = customerWork.UOESlipPrtDiv.ToString();
            dataTable.Rows[index]["QrcodePrtCdRF"] = customerWork.QrcodePrtCd.ToString();
            dataTable.Rows[index]["CustSlipNoMngCdRF"] = customerWork.CustSlipNoMngCd.ToString();
            dataTable.Rows[index]["CustomerSlipNoDivRF"] = customerWork.CustomerSlipNoDiv.ToString();

            dataTable.Rows[index]["TotalBillOutputDivRF"] = customerWork.TotalBillOutputDiv.ToString();   // 合計請求書出力区分
            dataTable.Rows[index]["DetailBillOutputCodeRF"] = customerWork.DetailBillOutputCode.ToString(); // 明細請求書出力区分
            dataTable.Rows[index]["SlipTtlBillOutputDivRF"] = customerWork.SlipTtlBillOutputDiv.ToString(); // 伝票合計請求書出力区分

            if (customerWork.CustRateGrpCode != -1 && !string.IsNullOrEmpty(customerWork.CustRateGrpCode.ToString().Trim()))
            {
                if (customerWork.RateGPureCode == 1)
                {
                    //dataTable.Rows[index]["CustRateGrpFine"] = customerWork.CustRateGrpCode.ToString("0000");// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                    dataTable.Rows[index]["CustRateGrpFineAll"] = customerWork.CustRateGrpCode.ToString("0000");// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                }
                else
                {

                    switch (customerWork.GoodsMakerCd)
                    {
                        case 0:
                            dataTable.Rows[index]["CustRateGrpPureAll"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 1:
                            dataTable.Rows[index]["CustRateGrpPure1"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 2:
                            dataTable.Rows[index]["CustRateGrpPure2"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 3:
                            dataTable.Rows[index]["CustRateGrpPure3"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 4:
                            dataTable.Rows[index]["CustRateGrpPure4"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 5:
                            dataTable.Rows[index]["CustRateGrpPure5"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 6:
                            dataTable.Rows[index]["CustRateGrpPure6"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 7:
                            dataTable.Rows[index]["CustRateGrpPure7"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 8:
                            dataTable.Rows[index]["CustRateGrpPure8"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 9:
                            dataTable.Rows[index]["CustRateGrpPure9"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 10:
                            dataTable.Rows[index]["CustRateGrpPure10"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 11:
                            dataTable.Rows[index]["CustRateGrpPure11"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 12:
                            dataTable.Rows[index]["CustRateGrpPure12"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 13:
                            dataTable.Rows[index]["CustRateGrpPure13"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 14:
                            dataTable.Rows[index]["CustRateGrpPure14"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 15:
                            dataTable.Rows[index]["CustRateGrpPure15"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 16:
                            dataTable.Rows[index]["CustRateGrpPure16"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 17:
                            dataTable.Rows[index]["CustRateGrpPure17"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 18:
                            dataTable.Rows[index]["CustRateGrpPure18"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 19:
                            dataTable.Rows[index]["CustRateGrpPure19"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 20:
                            dataTable.Rows[index]["CustRateGrpPure20"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 21:
                            dataTable.Rows[index]["CustRateGrpPure21"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 22:
                            dataTable.Rows[index]["CustRateGrpPure22"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 23:
                            dataTable.Rows[index]["CustRateGrpPure23"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 24:
                            dataTable.Rows[index]["CustRateGrpPure24"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                        case 25:
                            dataTable.Rows[index]["CustRateGrpPure25"] = customerWork.CustRateGrpCode.ToString("0000");
                            break;
                    }
                }
            }
            else 
            {
                if (customerWork.RateGPureCode == 1)
                {
                    //dataTable.Rows[index]["CustRateGrpFine"] = customerWork.CustRateGrpCode.ToString();// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                    dataTable.Rows[index]["CustRateGrpFineAll"] = customerWork.CustRateGrpCode.ToString();// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                }
                else
                {
                    switch (customerWork.GoodsMakerCd)
                    {
                        case 0:
                            dataTable.Rows[index]["CustRateGrpPureAll"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 1:
                            dataTable.Rows[index]["CustRateGrpPure1"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 2:
                            dataTable.Rows[index]["CustRateGrpPure2"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 3:
                            dataTable.Rows[index]["CustRateGrpPure3"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 4:
                            dataTable.Rows[index]["CustRateGrpPure4"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 5:
                            dataTable.Rows[index]["CustRateGrpPure5"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 6:
                            dataTable.Rows[index]["CustRateGrpPure6"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 7:
                            dataTable.Rows[index]["CustRateGrpPure7"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 8:
                            dataTable.Rows[index]["CustRateGrpPure8"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 9:
                            dataTable.Rows[index]["CustRateGrpPure9"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 10:
                            dataTable.Rows[index]["CustRateGrpPure10"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 11:
                            dataTable.Rows[index]["CustRateGrpPure11"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 12:
                            dataTable.Rows[index]["CustRateGrpPure12"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 13:
                            dataTable.Rows[index]["CustRateGrpPure13"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 14:
                            dataTable.Rows[index]["CustRateGrpPure14"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 15:
                            dataTable.Rows[index]["CustRateGrpPure15"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 16:
                            dataTable.Rows[index]["CustRateGrpPure16"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 17:
                            dataTable.Rows[index]["CustRateGrpPure17"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 18:
                            dataTable.Rows[index]["CustRateGrpPure18"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 19:
                            dataTable.Rows[index]["CustRateGrpPure19"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 20:
                            dataTable.Rows[index]["CustRateGrpPure20"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 21:
                            dataTable.Rows[index]["CustRateGrpPure21"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 22:
                            dataTable.Rows[index]["CustRateGrpPure22"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 23:
                            dataTable.Rows[index]["CustRateGrpPure23"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 24:
                            dataTable.Rows[index]["CustRateGrpPure24"] = customerWork.CustRateGrpCode.ToString();
                            break;
                        case 25:
                            dataTable.Rows[index]["CustRateGrpPure25"] = customerWork.CustRateGrpCode.ToString();
                            break;
                    }
                }
            }
            // ------ DEL START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.46の対応-------->>>>
            //if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpFine"].ToString()))
            //{
            //    dataTable.Rows[index]["CustRateGrpFine"] = "-1";
            //}
            // ------ DEL END 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.46の対応--------<<<<
            // ------ ADD START 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.46の対応-------->>>>
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpFineAll"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpFineAll"] = "-1";
            }
            // ------ ADD END 2012/07/09 Redmine#30393 李亜博 for 障害一覧の指摘NO.46の対応--------<<<<
            
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPureAll"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPureAll"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure1"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure1"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure2"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure2"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure3"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure3"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure4"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure4"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure5"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure5"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure6"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure6"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure7"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure7"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure8"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure8"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure9"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure9"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure10"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure10"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure11"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure11"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure12"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure12"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure13"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure13"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure14"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure14"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure15"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure15"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure16"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure16"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure17"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure17"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure18"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure18"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure19"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure19"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure20"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure20"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure21"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure21"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure22"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure22"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure23"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure23"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure24"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure24"] = "-1";
            }
            if (String.IsNullOrEmpty(dataTable.Rows[index]["CustRateGrpPure25"].ToString()))
            {
                dataTable.Rows[index]["CustRateGrpPure25"] = "-1";
            }
            // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            bfString = bfString.Trim();
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }
        #endregion
    }
}
