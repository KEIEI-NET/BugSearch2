//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【13030】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/10     修正内容：Mantis【9494】得意先マスタのWrite()で更新するように修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/01/29     修正内容：Mantis【14950】請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15033】伝票印刷区分×5を追加
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先一括修正アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 得意先一括修正アクセスクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2008/11/20</br>
    /// </remarks>
    public class CustomerCustomerChangeAcs
    {
        #region ■ Private Members

        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;

        private ICustomerInfoDB _iCustomerInfoDB;   // ADD 2009/04/10

        #endregion ■ Private Members


        # region ■ Constractor
        /// <summary>
        /// 得意先一括修正アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先一括修正のアクセスクラスのコンストラクタです。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
            this._iCustomerInfoDB = (ICustomerInfoDB)MediationCustomerInfoDB.GetCustomerInfoDB();
        }
        # endregion ■ Constractor


        #region ■ Public Methods
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="customerCustomerChangeList">得意先一括修正リスト</param>
        /// <remarks>
        /// <br>Note       : 更新処理を行います。<br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public int Write(ref ArrayList customerCustomerChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList workList = new ArrayList();

                foreach (CustomerCustomerChangeResult para in customerCustomerChangeList)
                {
                    // クラスメンバコピー処理
                    //workList.Add(CopyToCustomerCustomerChangeResultWorkFromCustomerCustomerChangeResult(para));   // DEL 2009/04/10
                    workList.Add(CopyToCustomerWorkFromCustomerCustomerChangeResult(para));                         // ADD 2009/04/10
                }

                object paraObj = workList;
                ArrayList duplicationItemList;

                // 更新
                //status = this._iCustomerCustomerChangeDB.Write(ref paraObj);                  // DEL 2009/04/10
                status = this._iCustomerInfoDB.Write(ref paraObj, out duplicationItemList);     // ADD 2009/04/10
                if (status == 0)
                {
                    customerCustomerChangeList = new ArrayList();
                    workList = paraObj as ArrayList;

                    //foreach (CustomerCustomerChangeResultWork retWork in workList)    // DEL 2009/04/10
                    foreach (CustomerWork retWork in workList)                          // ADD 2009/04/10
                    {
                        // クラスメンバコピー処理
                        //customerCustomerChangeList.Add(CopyToCustomerCustomerChangeResultFromCustomerCustomerChangeResultWork(retWork));      // DEL 2009/04/10
                        customerCustomerChangeList.Add(CopyToCustomerCustomerChangeResultFromCustomerWork(retWork));                            // ADD 2009/04/10
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="customerCustomerChangeList">得意先一括修正リスト</param>
        /// <param name="para">得意先一括修正リスト検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。<br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public int Search(out List<CustomerCustomerChangeResult> customerCustomerChangeList, CustomerCustomerChangeParam para, ConstantManagement.LogicalMode logicalMode)
        {
            customerCustomerChangeList = new List<CustomerCustomerChangeResult>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // クラスメンバコピー処理
                CustomerCustomerChangeParamWork paraWork = CopyToCustomerCustomerChangeParamWorkFromCustomerCustomerChangeParam(para);

                object paraObj = paraWork;
                ArrayList retList = new ArrayList();
                object retObj = retList;

                // 検索
                status = this._iCustomerCustomerChangeDB.Search(ref retObj, paraObj, 0, logicalMode);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    
                    foreach (CustomerCustomerChangeResultWork retWork in retList)
                    {
                        // クラスメンバコピー処理
                        customerCustomerChangeList.Add(CopyToCustomerCustomerChangeResultFromCustomerCustomerChangeResultWork(retWork));
                    }

                    // 得意先コード順にソート
                    customerCustomerChangeList.Sort(delegate(CustomerCustomerChangeResult x, CustomerCustomerChangeResult y)
                    {
                        if (x.CustomerCode > y.CustomerCode)
                        {
                            return 1;
                        }
                        else if (x.CustomerCode < y.CustomerCode)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                        
                    });
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        #endregion ■Public Methods


        #region ■ Private Methods
        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="para">得意先一括修正抽出条件クラス</param>
        /// <returns>得意先一括修正抽出条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeParamWork CopyToCustomerCustomerChangeParamWorkFromCustomerCustomerChangeParam(CustomerCustomerChangeParam para)
        {
            CustomerCustomerChangeParamWork paraWork = new CustomerCustomerChangeParamWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;          // 企業コード
            paraWork.StMngSectionCode = para.StMngSectionCode;      // 開始管理拠点コード
            paraWork.EdMngSectionCode = para.EdMngSectionCode;      // 終了管理拠点コード
            paraWork.StCustomerCode = para.StCustomerCode;          // 開始得意先
            paraWork.EdCustomerCode = para.EdCustomerCode;          // 終了得意先
            paraWork.StKana = para.StKana;                          // 開始カナ
            paraWork.EdKana = para.EdKana;                          // 終了カナ
            paraWork.StCustomerAgentCd = para.StCustomerAgentCd;    // 開始顧客担当従業員コード
            paraWork.EdCustomerAgentCd = para.EdCustomerAgentCd;    // 終了顧客担当従業員コード
            paraWork.StSalesAreaCode = para.StSalesAreaCode;        // 開始販売エリアコード
            paraWork.EdSalesAreaCode = para.EdSalesAreaCode;        // 終了販売エリアコード
            paraWork.StBusinessTypeCode = para.StBusinessTypeCode;  // 開始業種コード
            paraWork.EdBusinessTypeCode = para.EdBusinessTypeCode;  // 終了業種コード
            paraWork.SearchDiv = para.SearchDiv;                    // 検索区分

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">得意先一括修正抽出条件ワーククラス</param>
        /// <returns>得意先一括修正抽出条件クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeResult CopyToCustomerCustomerChangeResultFromCustomerCustomerChangeResultWork(CustomerCustomerChangeResultWork retWork)
        {
            CustomerCustomerChangeResult ret = new CustomerCustomerChangeResult();

            ret.CreateDateTime = retWork.CreateDateTime;                // 作成日時
            ret.UpdateDateTime = retWork.UpdateDateTime;                // 更新日時
            ret.EnterpriseCode = retWork.EnterpriseCode;                // 企業コード
            ret.FileHeaderGuid = retWork.FileHeaderGuid;                // GUID
            ret.UpdEmployeeCode = retWork.UpdEmployeeCode;              // 更新従業員コード
            ret.UpdAssemblyId1 = retWork.UpdAssemblyId1;                // 更新アセンブリID1
            ret.UpdAssemblyId2 = retWork.UpdAssemblyId2;                // 更新アセンブリID2
            ret.LogicalDeleteCode = retWork.LogicalDeleteCode;          // 論理削除区分
            ret.CustomerCode = retWork.CustomerCode;                    // 得意先コード
            ret.CustomerSubCode = retWork.CustomerSubCode;              // 得意先サブコード
            ret.Name = retWork.Name;                                    // 名称
            ret.Name2 = retWork.Name2;                                  // 名称2
            ret.HonorificTitle = retWork.HonorificTitle;                // 敬称
            ret.Kana = retWork.Kana;                                    // カナ
            ret.CustomerSnm = retWork.CustomerSnm;                      // 得意先略称
            ret.OutputNameCode = retWork.OutputNameCode;                // 諸口コード
            ret.OutputName = retWork.OutputName;                        // 諸口名称
            ret.CorporateDivCode = retWork.CorporateDivCode;            // 個人・法人区分
            ret.CustomerAttributeDiv = retWork.CustomerAttributeDiv;    // 得意先属性区分
            ret.JobTypeCode = retWork.JobTypeCode;                      // 職種コード
            ret.JobTypeName = retWork.JobTypeName;                      // 職種名称
            ret.BusinessTypeCode = retWork.BusinessTypeCode;            // 業種コード
            ret.BusinessTypeName = retWork.BusinessTypeName;            // 業種名称
            ret.SalesAreaCode = retWork.SalesAreaCode;                  // 販売エリアコード
            ret.SalesAreaName = retWork.SalesAreaName;                  // 販売エリア名称
            ret.PostNo = retWork.PostNo;                                // 郵便番号
            ret.Address1 = retWork.Address1;                            // 住所1（都道府県市区郡・町村・字）
            ret.Address3 = retWork.Address3;                            // 住所3（番地）
            ret.Address4 = retWork.Address4;                            // 住所4（アパート名称）
            ret.HomeTelNo = retWork.HomeTelNo;                          // 電話番号（自宅）
            ret.OfficeTelNo = retWork.OfficeTelNo;                      // 電話番号（勤務先）
            ret.PortableTelNo = retWork.PortableTelNo;                  // 電話番号（携帯）
            ret.HomeFaxNo = retWork.HomeFaxNo;                          // FAX番号（自宅）
            ret.OfficeFaxNo = retWork.OfficeFaxNo;                      // FAX番号（勤務先）
            ret.OthersTelNo = retWork.OthersTelNo;                      // 電話番号（その他）
            ret.MainContactCode = retWork.MainContactCode;              // 主連絡先区分
            ret.SearchTelNo = retWork.SearchTelNo.Trim();               // 電話番号（検索用下4桁）
            ret.MngSectionCode = retWork.MngSectionCode.Trim();         // 管理拠点コード
            ret.MngSectionName = retWork.MngSectionName;                // 管理拠点名称
            ret.InpSectionCode = retWork.InpSectionCode.Trim();         // 入力拠点コード
            ret.CustAnalysCode1 = retWork.CustAnalysCode1;              // 得意先分析コード1
            ret.CustAnalysCode2 = retWork.CustAnalysCode2;              // 得意先分析コード2
            ret.CustAnalysCode3 = retWork.CustAnalysCode3;              // 得意先分析コード3
            ret.CustAnalysCode4 = retWork.CustAnalysCode4;              // 得意先分析コード4
            ret.CustAnalysCode5 = retWork.CustAnalysCode5;              // 得意先分析コード5
            ret.CustAnalysCode6 = retWork.CustAnalysCode6;              // 得意先分析コード6
            ret.BillOutputCode = retWork.BillOutputCode;                // 請求書出力区分コード
            ret.BillOutputName = retWork.BillOutputName;                // 請求書出力区分名称
            ret.TotalDay = retWork.TotalDay;                            // 締日
            ret.CollectMoneyCode = retWork.CollectMoneyCode;            // 集金月区分コード
            ret.CollectMoneyName = retWork.CollectMoneyName;            // 集金月区分名称
            ret.CollectMoneyDay = retWork.CollectMoneyDay;              // 集金日
            ret.CollectCond = retWork.CollectCond;                      // 回収条件
            ret.CollectSight = retWork.CollectSight;                    // 回収サイト
            ret.ClaimCode = retWork.ClaimCode;                          // 請求先コード
            ret.ClaimName = retWork.ClaimName;                          // 請求先名称
            ret.ClaimName2 = retWork.ClaimName2;                        // 請求先名称2
            ret.ClaimSnm = retWork.ClaimSnm;                            // 請求先略所
            ret.TransStopDate = retWork.TransStopDate;                  // 取引中止日
            ret.DmOutCode = retWork.DmOutCode;                          // DM出力区分
            ret.DmOutName = retWork.DmOutName;                          // DM出力区分名称
            ret.MainSendMailAddrCd = retWork.MainSendMailAddrCd;        // 主送信先メールアドレス区分
            ret.MailAddrKindCode1 = retWork.MailAddrKindCode1;          // メールアドレス種別コード1
            ret.MailAddrKindName1 = retWork.MailAddrKindName1;          // メールアドレス種別名称1
            ret.MailAddress1 = retWork.MailAddress1;                    // メールアドレス1
            ret.MailSendCode1 = retWork.MailSendCode1;                  // メール送信区分コード1
            ret.MailSendName1 = retWork.MailSendName1;                  // メール送信区分名称1
            ret.MailAddrKindCode2 = retWork.MailAddrKindCode2;          // メールアドレス種別コード2
            ret.MailAddrKindName2 = retWork.MailAddrKindName2;          // メールアドレス種別名称2
            ret.MailAddress2 = retWork.MailAddress2;                    // メールアドレス2
            ret.MailSendCode2 = retWork.MailSendCode2;                  // メール送信区分コード2
            ret.MailSendName2 = retWork.MailSendName2;                  // メール送信区分名称2
            ret.CustomerAgentCd = retWork.CustomerAgentCd.Trim();       // 顧客担当従業員コード
            ret.CustomerAgentNm = retWork.CustomerAgentNm;              // 顧客担当従業員名称
            ret.BillCollecterCd = retWork.BillCollecterCd.Trim();       // 集金担当従業員コード
            ret.OldCustomerAgentCd = retWork.OldCustomerAgentCd.Trim(); // 旧顧客担当従業員コード
            ret.OldCustomerAgentNm = retWork.OldCustomerAgentNm;        // 旧顧客担当従業員名称
            ret.CustAgentChgDate = retWork.CustAgentChgDate;            // 顧客担当変更日
            ret.AcceptWholeSale = retWork.AcceptWholeSale;              // 業販先区分
            ret.CreditMngCode = retWork.CreditMngCode;                  // 与信管理区分
            ret.DepoDelCode = retWork.DepoDelCode;                      // 入金消込区分
            ret.AccRecDivCd = retWork.AccRecDivCd;                      // 売掛区分
            ret.CustSlipNoMngCd = retWork.CustSlipNoMngCd;              // 相手伝票番号管理区分
            ret.PureCode = retWork.PureCode;                            // 純正区分
            ret.CustCTaXLayRefCd = retWork.CustCTaXLayRefCd;            // 得意先消費税転嫁方式参照区分
            ret.ConsTaxLayMethod = retWork.ConsTaxLayMethod;            // 消費税転嫁方式
            ret.TotalAmountDispWayCd = retWork.TotalAmountDispWayCd;    // 総額表示方法区分
            ret.TotalAmntDspWayRef = retWork.TotalAmntDspWayRef;        // 総額表示方法参照区分
            ret.AccountNoInfo1 = retWork.AccountNoInfo1;                // 銀行口座1
            ret.AccountNoInfo2 = retWork.AccountNoInfo2;                // 銀行口座2
            ret.AccountNoInfo3 = retWork.AccountNoInfo3;                // 銀行口座3
            ret.SalesUnPrcFrcProcCd = retWork.SalesUnPrcFrcProcCd;      // 売上単価端数処理コード
            ret.SalesMoneyFrcProcCd = retWork.SalesMoneyFrcProcCd;      // 売上金額端数処理コード
            ret.SalesCnsTaxFrcProcCd = retWork.SalesCnsTaxFrcProcCd;    // 売上消費税端数処理コード
            ret.CustomerSlipNoDiv = retWork.CustomerSlipNoDiv;          // 得意先伝票番号区分
            ret.NTimeCalcStDate = retWork.NTimeCalcStDate;              // 次回勘定開始日
            ret.CustomerAgent = retWork.CustomerAgent;                  // 得意先担当者
            ret.ClaimSectionCode = retWork.ClaimSectionCode.Trim();     // 請求拠点コード
            ret.ClaimSectionName = retWork.ClaimSectionName;            // 請求拠点名称
            ret.CarMngDivCd = retWork.CarMngDivCd;                      // 車輌管理区分
            ret.BillPartsNoPrtCd = retWork.BillPartsNoPrtCd;            // 品番印字区分(請求書)
            ret.DeliPartsNoPrtCd = retWork.DeliPartsNoPrtCd;            // 品番印字区分(納品書）
            ret.DefSalesSlipCd = retWork.DefSalesSlipCd;                // 伝票区分初期値
            ret.LavorRateRank = retWork.LavorRateRank;                  // 工賃レバレートランク
            ret.SlipTtlPrn = retWork.SlipTtlPrn;                        // 伝票タイトルパターン
            ret.DepoBankCode = retWork.DepoBankCode;                    // 入金銀行コード
            ret.DepoBankName = retWork.DepoBankName;                    // 入金銀行名称
            ret.CustWarehouseCd = retWork.CustWarehouseCd.Trim();       // 得意先優先倉庫コード
            ret.CustWarehouseName = retWork.CustWarehouseName;          // 得意先優先倉庫名称
            ret.QrcodePrtCd = retWork.QrcodePrtCd;                      // QRコード印刷
            ret.DeliHonorificTtl = retWork.DeliHonorificTtl;            // 納品書敬称
            ret.BillHonorificTtl = retWork.BillHonorificTtl;            // 請求書敬称
            ret.EstmHonorificTtl = retWork.EstmHonorificTtl;            // 見積書敬称
            ret.RectHonorificTtl = retWork.RectHonorificTtl;            // 領収書敬称
            ret.DeliHonorTtlPrtDiv = retWork.DeliHonorTtlPrtDiv;        // 納品書敬称印字区分
            ret.BillHonorTtlPrtDiv = retWork.BillHonorTtlPrtDiv;        // 請求書敬称印字区分
            ret.EstmHonorTtlPrtDiv = retWork.EstmHonorTtlPrtDiv;        // 見積書敬称印字区分
            ret.RectHonorTtlPrtDiv = retWork.RectHonorTtlPrtDiv;        // 領収書敬称印字区分
            ret.Note1 = retWork.Note1;                                  // 備考1
            ret.Note2 = retWork.Note2;                                  // 備考2
            ret.Note3 = retWork.Note3;                                  // 備考3
            ret.Note4 = retWork.Note4;                                  // 備考4
            ret.Note5 = retWork.Note5;                                  // 備考5
            ret.Note6 = retWork.Note6;                                  // 備考6
            ret.Note7 = retWork.Note7;                                  // 備考7
            ret.Note8 = retWork.Note8;                                  // 備考8
            ret.Note9 = retWork.Note9;                                  // 備考9
            ret.Note10 = retWork.Note10;                                // 備考10
            ret.CreditMoney = retWork.CreditMoney;                      // 与信額[変動情報]
            ret.WarningCreditMoney = retWork.WarningCreditMoney;        // 警告与信額[変動情報]
            ret.PrsntAccRecBalance = retWork.PrsntAccRecBalance;        // 現在売掛残高[変動情報]
            ret.RateGPureCode = retWork.RateGPureCode;                  // 純正区分[掛率]
            ret.GoodsMakerCd = retWork.GoodsMakerCd;                    // 商品メーカーコード[掛率]
            ret.CustRateGrpCode = retWork.CustRateGrpCode;              // 得意先掛率グループコード[掛率]
            //ret.EnterpriseName = retWork.EnterpriseName;
            //ret.UpdEmployeeName = retWork.UpdEmployeeName;
            //ret.InpSectionName = retWork.InpSectionName;
            //ret.BillOutPutCodeNm = retWork.BillOutPutCodeNm;
            //ret.BillCollecterNm = retWork.BillCollecterNm;

            // ADD 2009/04/07 ------>>>
            ret.ReceiptOutputCode = retWork.ReceiptOutputCode;          // 領収書出力区分コード
            // ADD 2009/04/07 ------<<<

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            ret.SalesSlipPrtDiv = retWork.SalesSlipPrtDiv;      // 納品書出力（売上伝票発行区分）
            ret.AcpOdrrSlipPrtDiv = retWork.AcpOdrrSlipPrtDiv;  // 受注伝票出力（受注伝票発行区分）
            ret.ShipmSlipPrtDiv = retWork.ShipmSlipPrtDiv;      // 貸出伝票出力（出荷伝票発行区分）
            ret.EstimatePrtDiv = retWork.EstimatePrtDiv;        // 見積伝票出力（見積伝票発行区分）
            ret.UOESlipPrtDiv = retWork.UOESlipPrtDiv;          // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            ret.TotalBillOutputDiv = retWork.TotalBillOutputDiv;    // 合計請求書出力区分
            ret.DetailBillOutputCode = retWork.DetailBillOutputCode;// 明細請求書出力区分
            ret.SlipTtlBillOutputDiv = retWork.SlipTtlBillOutputDiv;// 伝票合計請求書出力区分
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            return ret;
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="retWork">得意先一括修正抽出条件ワーククラス</param>
        /// <returns>得意先一括修正抽出条件クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private CustomerCustomerChangeResultWork CopyToCustomerCustomerChangeResultWorkFromCustomerCustomerChangeResult(CustomerCustomerChangeResult ret)
        {
            CustomerCustomerChangeResultWork retWork = new CustomerCustomerChangeResultWork();

            retWork.CreateDateTime = ret.CreateDateTime;                // 作成日時
            retWork.UpdateDateTime = ret.UpdateDateTime;                // 更新日時
            retWork.EnterpriseCode = ret.EnterpriseCode;                // 企業コード
            retWork.FileHeaderGuid = ret.FileHeaderGuid;                // GUID
            retWork.UpdEmployeeCode = ret.UpdEmployeeCode;              // 更新従業員コード
            retWork.UpdAssemblyId1 = ret.UpdAssemblyId1;                // 更新アセンブリID1
            retWork.UpdAssemblyId2 = ret.UpdAssemblyId2;                // 更新アセンブリID2
            retWork.LogicalDeleteCode = ret.LogicalDeleteCode;          // 論理削除区分
            retWork.CustomerCode = ret.CustomerCode;                    // 得意先コード
            retWork.CustomerSubCode = ret.CustomerSubCode;              // 得意先サブコード
            retWork.Name = ret.Name;                                    // 名称
            retWork.Name2 = ret.Name2;                                  // 名称2
            retWork.HonorificTitle = ret.HonorificTitle;                // 敬称
            retWork.Kana = ret.Kana;                                    // カナ
            retWork.CustomerSnm = ret.CustomerSnm;                      // 得意先略称
            retWork.OutputNameCode = ret.OutputNameCode;                // 諸口コード
            retWork.OutputName = ret.OutputName;                        // 諸口名称
            retWork.CorporateDivCode = ret.CorporateDivCode;            // 個人・法人区分
            retWork.CustomerAttributeDiv = ret.CustomerAttributeDiv;    // 得意先属性区分
            retWork.JobTypeCode = ret.JobTypeCode;                      // 職種コード
            retWork.JobTypeName = ret.JobTypeName;                      // 職種名称
            retWork.BusinessTypeCode = ret.BusinessTypeCode;            // 業種コード
            retWork.BusinessTypeName = ret.BusinessTypeName;            // 業種名称
            retWork.SalesAreaCode = ret.SalesAreaCode;                  // 販売エリアコード
            retWork.SalesAreaName = ret.SalesAreaName;                  // 販売エリア名称
            retWork.PostNo = ret.PostNo;                                // 郵便番号
            retWork.Address1 = ret.Address1;                            // 住所1（都道府県市区郡・町村・字）
            retWork.Address3 = ret.Address3;                            // 住所3（番地）
            retWork.Address4 = ret.Address4;                            // 住所4（アパート名称）
            retWork.HomeTelNo = ret.HomeTelNo;                          // 電話番号（自宅）
            retWork.OfficeTelNo = ret.OfficeTelNo;                      // 電話番号（勤務先）
            retWork.PortableTelNo = ret.PortableTelNo;                  // 電話番号（携帯）
            retWork.HomeFaxNo = ret.HomeFaxNo;                          // FAX番号（自宅）
            retWork.OfficeFaxNo = ret.OfficeFaxNo;                      // FAX番号（勤務先）
            retWork.OthersTelNo = ret.OthersTelNo;                      // 電話番号（その他）
            retWork.MainContactCode = ret.MainContactCode;              // 主連絡先区分
            retWork.SearchTelNo = ret.SearchTelNo;                      // 電話番号（検索用下4桁）
            retWork.MngSectionCode = ret.MngSectionCode;                // 管理拠点コード
            retWork.MngSectionName = ret.MngSectionName;                // 管理拠点名称
            retWork.InpSectionCode = ret.InpSectionCode;                // 入力拠点コード
            retWork.CustAnalysCode1 = ret.CustAnalysCode1;              // 得意先分析コード1
            retWork.CustAnalysCode2 = ret.CustAnalysCode2;              // 得意先分析コード2
            retWork.CustAnalysCode3 = ret.CustAnalysCode3;              // 得意先分析コード3
            retWork.CustAnalysCode4 = ret.CustAnalysCode4;              // 得意先分析コード4
            retWork.CustAnalysCode5 = ret.CustAnalysCode5;              // 得意先分析コード5
            retWork.CustAnalysCode6 = ret.CustAnalysCode6;              // 得意先分析コード6
            retWork.BillOutputCode = ret.BillOutputCode;                // 請求書出力区分コード
            retWork.BillOutputName = ret.BillOutputName;                // 請求書出力区分名称
            retWork.TotalDay = ret.TotalDay;                            // 締日
            retWork.CollectMoneyCode = ret.CollectMoneyCode;            // 集金月区分コード
            retWork.CollectMoneyName = ret.CollectMoneyName;            // 集金月区分名称
            retWork.CollectMoneyDay = ret.CollectMoneyDay;              // 集金日
            retWork.CollectCond = ret.CollectCond;                      // 回収条件
            retWork.CollectSight = ret.CollectSight;                    // 回収サイト
            retWork.ClaimCode = ret.ClaimCode;                          // 請求先コード
            retWork.ClaimName = ret.ClaimName;                          // 請求先名称
            retWork.ClaimName2 = ret.ClaimName2;                        // 請求先名称2
            retWork.ClaimSnm = ret.ClaimSnm;                            // 請求先略所
            retWork.TransStopDate = ret.TransStopDate;                  // 取引中止日
            retWork.DmOutCode = ret.DmOutCode;                          // DM出力区分
            retWork.DmOutName = ret.DmOutName;                          // DM出力区分名称
            retWork.MainSendMailAddrCd = ret.MainSendMailAddrCd;        // 主送信先メールアドレス区分
            retWork.MailAddrKindCode1 = ret.MailAddrKindCode1;          // メールアドレス種別コード1
            retWork.MailAddrKindName1 = ret.MailAddrKindName1;          // メールアドレス種別名称1
            retWork.MailAddress1 = ret.MailAddress1;                    // メールアドレス1
            retWork.MailSendCode1 = ret.MailSendCode1;                  // メール送信区分コード1
            retWork.MailSendName1 = ret.MailSendName1;                  // メール送信区分名称1
            retWork.MailAddrKindCode2 = ret.MailAddrKindCode2;          // メールアドレス種別コード2
            retWork.MailAddrKindName2 = ret.MailAddrKindName2;          // メールアドレス種別名称2
            retWork.MailAddress2 = ret.MailAddress2;                    // メールアドレス2
            retWork.MailSendCode2 = ret.MailSendCode2;                  // メール送信区分コード2
            retWork.MailSendName2 = ret.MailSendName2;                  // メール送信区分名称2
            retWork.CustomerAgentCd = ret.CustomerAgentCd;              // 顧客担当従業員コード
            retWork.CustomerAgentNm = ret.CustomerAgentNm;              // 顧客担当従業員名称
            retWork.BillCollecterCd = ret.BillCollecterCd;              // 集金担当従業員コード
            retWork.OldCustomerAgentCd = ret.OldCustomerAgentCd;        // 旧顧客担当従業員コード
            retWork.OldCustomerAgentNm = ret.OldCustomerAgentNm;        // 旧顧客担当従業員名称
            retWork.CustAgentChgDate = ret.CustAgentChgDate;            // 顧客担当変更日
            retWork.AcceptWholeSale = ret.AcceptWholeSale;              // 業販先区分
            retWork.CreditMngCode = ret.CreditMngCode;                  // 与信管理区分
            retWork.DepoDelCode = ret.DepoDelCode;                      // 入金消込区分
            retWork.AccRecDivCd = ret.AccRecDivCd;                      // 売掛区分
            retWork.CustSlipNoMngCd = ret.CustSlipNoMngCd;              // 相手伝票番号管理区分
            retWork.PureCode = ret.PureCode;                            // 純正区分
            retWork.CustCTaXLayRefCd = ret.CustCTaXLayRefCd;            // 得意先消費税転嫁方式参照区分
            retWork.ConsTaxLayMethod = ret.ConsTaxLayMethod;            // 消費税転嫁方式
            retWork.TotalAmountDispWayCd = ret.TotalAmountDispWayCd;    // 総額表示方法区分
            retWork.TotalAmntDspWayRef = ret.TotalAmntDspWayRef;        // 総額表示方法参照区分
            retWork.AccountNoInfo1 = ret.AccountNoInfo1;                // 銀行口座1
            retWork.AccountNoInfo2 = ret.AccountNoInfo2;                // 銀行口座2
            retWork.AccountNoInfo3 = ret.AccountNoInfo3;                // 銀行口座3
            retWork.SalesUnPrcFrcProcCd = ret.SalesUnPrcFrcProcCd;      // 売上単価端数処理コード
            retWork.SalesMoneyFrcProcCd = ret.SalesMoneyFrcProcCd;      // 売上金額端数処理コード
            retWork.SalesCnsTaxFrcProcCd = ret.SalesCnsTaxFrcProcCd;    // 売上消費税端数処理コード
            retWork.CustomerSlipNoDiv = ret.CustomerSlipNoDiv;          // 得意先伝票番号区分
            retWork.NTimeCalcStDate = ret.NTimeCalcStDate;              // 次回勘定開始日
            retWork.CustomerAgent = ret.CustomerAgent;                  // 得意先担当者
            retWork.ClaimSectionCode = ret.ClaimSectionCode;            // 請求拠点コード
            retWork.ClaimSectionName = ret.ClaimSectionName;            // 請求拠点名称
            retWork.CarMngDivCd = ret.CarMngDivCd;                      // 車輌管理区分
            retWork.BillPartsNoPrtCd = ret.BillPartsNoPrtCd;            // 品番印字区分(請求書)
            retWork.DeliPartsNoPrtCd = ret.DeliPartsNoPrtCd;            // 品番印字区分(納品書）
            retWork.DefSalesSlipCd = ret.DefSalesSlipCd;                // 伝票区分初期値
            retWork.LavorRateRank = ret.LavorRateRank;                  // 工賃レバレートランク
            retWork.SlipTtlPrn = ret.SlipTtlPrn;                        // 伝票タイトルパターン
            retWork.DepoBankCode = ret.DepoBankCode;                    // 入金銀行コード
            retWork.DepoBankName = ret.DepoBankName;                    // 入金銀行名称
            retWork.CustWarehouseCd = ret.CustWarehouseCd;              // 得意先優先倉庫コード
            retWork.CustWarehouseName = ret.CustWarehouseName;          // 得意先優先倉庫名称
            retWork.QrcodePrtCd = ret.QrcodePrtCd;                      // QRコード印刷
            retWork.DeliHonorificTtl = ret.DeliHonorificTtl;            // 納品書敬称
            retWork.BillHonorificTtl = ret.BillHonorificTtl;            // 請求書敬称
            retWork.EstmHonorificTtl = ret.EstmHonorificTtl;            // 見積書敬称
            retWork.RectHonorificTtl = ret.RectHonorificTtl;            // 領収書敬称
            retWork.DeliHonorTtlPrtDiv = ret.DeliHonorTtlPrtDiv;        // 納品書敬称印字区分
            retWork.BillHonorTtlPrtDiv = ret.BillHonorTtlPrtDiv;        // 請求書敬称印字区分
            retWork.EstmHonorTtlPrtDiv = ret.EstmHonorTtlPrtDiv;        // 見積書敬称印字区分
            retWork.RectHonorTtlPrtDiv = ret.RectHonorTtlPrtDiv;        // 領収書敬称印字区分
            retWork.Note1 = ret.Note1;                                  // 備考1
            retWork.Note2 = ret.Note2;                                  // 備考2
            retWork.Note3 = ret.Note3;                                  // 備考3
            retWork.Note4 = ret.Note4;                                  // 備考4
            retWork.Note5 = ret.Note5;                                  // 備考5
            retWork.Note6 = ret.Note6;                                  // 備考6
            retWork.Note7 = ret.Note7;                                  // 備考7
            retWork.Note8 = ret.Note8;                                  // 備考8
            retWork.Note9 = ret.Note9;                                  // 備考9
            retWork.Note10 = ret.Note10;                                // 備考10
            retWork.CreditMoney = ret.CreditMoney;                      // 与信額[変動情報]
            retWork.WarningCreditMoney = ret.WarningCreditMoney;        // 警告与信額[変動情報]
            retWork.PrsntAccRecBalance = ret.PrsntAccRecBalance;        // 現在売掛残高[変動情報]
            retWork.RateGPureCode = ret.RateGPureCode;                  // 純正区分[掛率]
            retWork.GoodsMakerCd = ret.GoodsMakerCd;                    // 商品メーカーコード[掛率]
            retWork.CustRateGrpCode = ret.CustRateGrpCode;              // 得意先掛率グループコード[掛率]
            //retWork.EnterpriseName = ret.EnterpriseName;
            //retWork.UpdEmployeeName = ret.UpdEmployeeName;
            //retWork.InpSectionName = ret.InpSectionName;
            //retWork.BillOutPutCodeNm = ret.BillOutPutCodeNm;
            //retWork.BillCollecterNm = ret.BillCollecterNm;

            // ADD 2009/04/07 ------>>>
            retWork.ReceiptOutputCode = ret.ReceiptOutputCode;          // 領収書出力区分コード
            // ADD 2009/04/07 ------<<<

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            retWork.SalesSlipPrtDiv = ret.SalesSlipPrtDiv;      // 納品書出力（売上伝票発行区分）
            retWork.AcpOdrrSlipPrtDiv = ret.AcpOdrrSlipPrtDiv;  // 受注伝票出力（受注伝票発行区分）
            retWork.ShipmSlipPrtDiv = ret.ShipmSlipPrtDiv;      // 貸出伝票出力（出荷伝票発行区分）
            retWork.EstimatePrtDiv = ret.EstimatePrtDiv;        // 見積伝票出力（見積伝票発行区分）
            retWork.UOESlipPrtDiv = ret.UOESlipPrtDiv;          // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            retWork.TotalBillOutputDiv = ret.TotalBillOutputDiv;    // 合計請求書出力区分
            retWork.DetailBillOutputCode = ret.DetailBillOutputCode;// 明細請求書出力区分
            retWork.SlipTtlBillOutputDiv = ret.SlipTtlBillOutputDiv;// 伝票合計請求書出力区分
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            return retWork;
        }

        // ADD 2009/04/10 ------>>>
        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="retWork">得意先マスタワーククラス</param>
        /// <returns>得意先一括修正抽出条件クラス</returns>
        /// <remarks>
        /// </remarks>
        private CustomerCustomerChangeResult CopyToCustomerCustomerChangeResultFromCustomerWork(CustomerWork retWork)
        {
            CustomerCustomerChangeResult ret = new CustomerCustomerChangeResult();

            ret.CreateDateTime = retWork.CreateDateTime;                // 作成日時
            ret.UpdateDateTime = retWork.UpdateDateTime;                // 更新日時
            ret.EnterpriseCode = retWork.EnterpriseCode;                // 企業コード
            ret.FileHeaderGuid = retWork.FileHeaderGuid;                // GUID
            ret.UpdEmployeeCode = retWork.UpdEmployeeCode;              // 更新従業員コード
            ret.UpdAssemblyId1 = retWork.UpdAssemblyId1;                // 更新アセンブリID1
            ret.UpdAssemblyId2 = retWork.UpdAssemblyId2;                // 更新アセンブリID2
            ret.LogicalDeleteCode = retWork.LogicalDeleteCode;          // 論理削除区分
            ret.CustomerCode = retWork.CustomerCode;                    // 得意先コード
            ret.CustomerSubCode = retWork.CustomerSubCode;              // 得意先サブコード
            ret.Name = retWork.Name;                                    // 名称
            ret.Name2 = retWork.Name2;                                  // 名称2
            ret.HonorificTitle = retWork.HonorificTitle;                // 敬称
            ret.Kana = retWork.Kana;                                    // カナ
            ret.CustomerSnm = retWork.CustomerSnm;                      // 得意先略称
            ret.OutputNameCode = retWork.OutputNameCode;                // 諸口コード
            ret.OutputName = retWork.OutputName;                        // 諸口名称
            ret.CorporateDivCode = retWork.CorporateDivCode;            // 個人・法人区分
            ret.CustomerAttributeDiv = retWork.CustomerAttributeDiv;    // 得意先属性区分
            ret.JobTypeCode = retWork.JobTypeCode;                      // 職種コード
            ret.JobTypeName = retWork.JobTypeName;                      // 職種名称
            ret.BusinessTypeCode = retWork.BusinessTypeCode;            // 業種コード
            ret.BusinessTypeName = retWork.BusinessTypeName;            // 業種名称
            ret.SalesAreaCode = retWork.SalesAreaCode;                  // 販売エリアコード
            ret.SalesAreaName = retWork.SalesAreaName;                  // 販売エリア名称
            ret.PostNo = retWork.PostNo;                                // 郵便番号
            ret.Address1 = retWork.Address1;                            // 住所1（都道府県市区郡・町村・字）
            ret.Address3 = retWork.Address3;                            // 住所3（番地）
            ret.Address4 = retWork.Address4;                            // 住所4（アパート名称）
            ret.HomeTelNo = retWork.HomeTelNo;                          // 電話番号（自宅）
            ret.OfficeTelNo = retWork.OfficeTelNo;                      // 電話番号（勤務先）
            ret.PortableTelNo = retWork.PortableTelNo;                  // 電話番号（携帯）
            ret.HomeFaxNo = retWork.HomeFaxNo;                          // FAX番号（自宅）
            ret.OfficeFaxNo = retWork.OfficeFaxNo;                      // FAX番号（勤務先）
            ret.OthersTelNo = retWork.OthersTelNo;                      // 電話番号（その他）
            ret.MainContactCode = retWork.MainContactCode;              // 主連絡先区分
            ret.SearchTelNo = retWork.SearchTelNo.Trim();               // 電話番号（検索用下4桁）
            ret.MngSectionCode = retWork.MngSectionCode.Trim();         // 管理拠点コード
            ret.MngSectionName = retWork.MngSectionName;                // 管理拠点名称
            ret.InpSectionCode = retWork.InpSectionCode.Trim();         // 入力拠点コード
            ret.CustAnalysCode1 = retWork.CustAnalysCode1;              // 得意先分析コード1
            ret.CustAnalysCode2 = retWork.CustAnalysCode2;              // 得意先分析コード2
            ret.CustAnalysCode3 = retWork.CustAnalysCode3;              // 得意先分析コード3
            ret.CustAnalysCode4 = retWork.CustAnalysCode4;              // 得意先分析コード4
            ret.CustAnalysCode5 = retWork.CustAnalysCode5;              // 得意先分析コード5
            ret.CustAnalysCode6 = retWork.CustAnalysCode6;              // 得意先分析コード6
            ret.BillOutputCode = retWork.BillOutputCode;                // 請求書出力区分コード
            ret.BillOutputName = retWork.BillOutputName;                // 請求書出力区分名称
            ret.TotalDay = retWork.TotalDay;                            // 締日
            ret.CollectMoneyCode = retWork.CollectMoneyCode;            // 集金月区分コード
            ret.CollectMoneyName = retWork.CollectMoneyName;            // 集金月区分名称
            ret.CollectMoneyDay = retWork.CollectMoneyDay;              // 集金日
            ret.CollectCond = retWork.CollectCond;                      // 回収条件
            ret.CollectSight = retWork.CollectSight;                    // 回収サイト
            ret.ClaimCode = retWork.ClaimCode;                          // 請求先コード
            ret.ClaimName = retWork.ClaimName;                          // 請求先名称
            ret.ClaimName2 = retWork.ClaimName2;                        // 請求先名称2
            ret.ClaimSnm = retWork.ClaimSnm;                            // 請求先略所
            ret.TransStopDate = retWork.TransStopDate;                  // 取引中止日
            ret.DmOutCode = retWork.DmOutCode;                          // DM出力区分
            ret.DmOutName = retWork.DmOutName;                          // DM出力区分名称
            ret.MainSendMailAddrCd = retWork.MainSendMailAddrCd;        // 主送信先メールアドレス区分
            ret.MailAddrKindCode1 = retWork.MailAddrKindCode1;          // メールアドレス種別コード1
            ret.MailAddrKindName1 = retWork.MailAddrKindName1;          // メールアドレス種別名称1
            ret.MailAddress1 = retWork.MailAddress1;                    // メールアドレス1
            ret.MailSendCode1 = retWork.MailSendCode1;                  // メール送信区分コード1
            ret.MailSendName1 = retWork.MailSendName1;                  // メール送信区分名称1
            ret.MailAddrKindCode2 = retWork.MailAddrKindCode2;          // メールアドレス種別コード2
            ret.MailAddrKindName2 = retWork.MailAddrKindName2;          // メールアドレス種別名称2
            ret.MailAddress2 = retWork.MailAddress2;                    // メールアドレス2
            ret.MailSendCode2 = retWork.MailSendCode2;                  // メール送信区分コード2
            ret.MailSendName2 = retWork.MailSendName2;                  // メール送信区分名称2
            ret.CustomerAgentCd = retWork.CustomerAgentCd.Trim();       // 顧客担当従業員コード
            ret.CustomerAgentNm = retWork.CustomerAgentNm;              // 顧客担当従業員名称
            ret.BillCollecterCd = retWork.BillCollecterCd.Trim();       // 集金担当従業員コード
            ret.OldCustomerAgentCd = retWork.OldCustomerAgentCd.Trim(); // 旧顧客担当従業員コード
            ret.OldCustomerAgentNm = retWork.OldCustomerAgentNm;        // 旧顧客担当従業員名称
            ret.CustAgentChgDate = retWork.CustAgentChgDate;            // 顧客担当変更日
            ret.AcceptWholeSale = retWork.AcceptWholeSale;              // 業販先区分
            ret.CreditMngCode = retWork.CreditMngCode;                  // 与信管理区分
            ret.DepoDelCode = retWork.DepoDelCode;                      // 入金消込区分
            ret.AccRecDivCd = retWork.AccRecDivCd;                      // 売掛区分
            ret.CustSlipNoMngCd = retWork.CustSlipNoMngCd;              // 相手伝票番号管理区分
            ret.PureCode = retWork.PureCode;                            // 純正区分
            ret.CustCTaXLayRefCd = retWork.CustCTaXLayRefCd;            // 得意先消費税転嫁方式参照区分
            ret.ConsTaxLayMethod = retWork.ConsTaxLayMethod;            // 消費税転嫁方式
            ret.TotalAmountDispWayCd = retWork.TotalAmountDispWayCd;    // 総額表示方法区分
            ret.TotalAmntDspWayRef = retWork.TotalAmntDspWayRef;        // 総額表示方法参照区分
            ret.AccountNoInfo1 = retWork.AccountNoInfo1;                // 銀行口座1
            ret.AccountNoInfo2 = retWork.AccountNoInfo2;                // 銀行口座2
            ret.AccountNoInfo3 = retWork.AccountNoInfo3;                // 銀行口座3
            ret.SalesUnPrcFrcProcCd = retWork.SalesUnPrcFrcProcCd;      // 売上単価端数処理コード
            ret.SalesMoneyFrcProcCd = retWork.SalesMoneyFrcProcCd;      // 売上金額端数処理コード
            ret.SalesCnsTaxFrcProcCd = retWork.SalesCnsTaxFrcProcCd;    // 売上消費税端数処理コード
            ret.CustomerSlipNoDiv = retWork.CustomerSlipNoDiv;          // 得意先伝票番号区分
            ret.NTimeCalcStDate = retWork.NTimeCalcStDate;              // 次回勘定開始日
            ret.CustomerAgent = retWork.CustomerAgent;                  // 得意先担当者
            ret.ClaimSectionCode = retWork.ClaimSectionCode.Trim();     // 請求拠点コード
            ret.ClaimSectionName = retWork.ClaimSectionName;            // 請求拠点名称
            ret.CarMngDivCd = retWork.CarMngDivCd;                      // 車輌管理区分
            ret.BillPartsNoPrtCd = retWork.BillPartsNoPrtCd;            // 品番印字区分(請求書)
            ret.DeliPartsNoPrtCd = retWork.DeliPartsNoPrtCd;            // 品番印字区分(納品書）
            ret.DefSalesSlipCd = retWork.DefSalesSlipCd;                // 伝票区分初期値
            ret.LavorRateRank = retWork.LavorRateRank;                  // 工賃レバレートランク
            ret.SlipTtlPrn = retWork.SlipTtlPrn;                        // 伝票タイトルパターン
            ret.DepoBankCode = retWork.DepoBankCode;                    // 入金銀行コード
            ret.DepoBankName = retWork.DepoBankName;                    // 入金銀行名称
            ret.CustWarehouseCd = retWork.CustWarehouseCd.Trim();       // 得意先優先倉庫コード
            ret.CustWarehouseName = retWork.CustWarehouseName;          // 得意先優先倉庫名称
            ret.QrcodePrtCd = retWork.QrcodePrtCd;                      // QRコード印刷
            ret.DeliHonorificTtl = retWork.DeliHonorificTtl;            // 納品書敬称
            ret.BillHonorificTtl = retWork.BillHonorificTtl;            // 請求書敬称
            ret.EstmHonorificTtl = retWork.EstmHonorificTtl;            // 見積書敬称
            ret.RectHonorificTtl = retWork.RectHonorificTtl;            // 領収書敬称
            ret.DeliHonorTtlPrtDiv = retWork.DeliHonorTtlPrtDiv;        // 納品書敬称印字区分
            ret.BillHonorTtlPrtDiv = retWork.BillHonorTtlPrtDiv;        // 請求書敬称印字区分
            ret.EstmHonorTtlPrtDiv = retWork.EstmHonorTtlPrtDiv;        // 見積書敬称印字区分
            ret.RectHonorTtlPrtDiv = retWork.RectHonorTtlPrtDiv;        // 領収書敬称印字区分
            ret.Note1 = retWork.Note1;                                  // 備考1
            ret.Note2 = retWork.Note2;                                  // 備考2
            ret.Note3 = retWork.Note3;                                  // 備考3
            ret.Note4 = retWork.Note4;                                  // 備考4
            ret.Note5 = retWork.Note5;                                  // 備考5
            ret.Note6 = retWork.Note6;                                  // 備考6
            ret.Note7 = retWork.Note7;                                  // 備考7
            ret.Note8 = retWork.Note8;                                  // 備考8
            ret.Note9 = retWork.Note9;                                  // 備考9
            ret.Note10 = retWork.Note10;                                // 備考10
            ret.CreditMoney = retWork.CreditMoney;                      // 与信額[変動情報]
            ret.WarningCreditMoney = retWork.WarningCreditMoney;        // 警告与信額[変動情報]
            ret.PrsntAccRecBalance = retWork.PrsntAccRecBalance;        // 現在売掛残高[変動情報]
            ret.ReceiptOutputCode = retWork.ReceiptOutputCode;          // 領収書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            ret.SalesSlipPrtDiv = retWork.SalesSlipPrtDiv;      // 納品書出力（売上伝票発行区分）
            ret.AcpOdrrSlipPrtDiv = retWork.AcpOdrrSlipPrtDiv;  // 受注伝票出力（受注伝票発行区分）
            ret.ShipmSlipPrtDiv = retWork.ShipmSlipPrtDiv;      // 貸出伝票出力（出荷伝票発行区分）
            ret.EstimatePrtDiv = retWork.EstimatePrtDiv;        // 見積伝票出力（見積伝票発行区分）
            ret.UOESlipPrtDiv = retWork.UOESlipPrtDiv;          // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            ret.TotalBillOutputDiv = retWork.TotalBillOutputDiv;    // 合計請求書出力区分
            ret.DetailBillOutputCode = retWork.DetailBillOutputCode;// 明細請求書出力区分
            ret.SlipTtlBillOutputDiv = retWork.SlipTtlBillOutputDiv;// 伝票合計請求書出力区分
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            return ret;
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="retWork">得意先一括修正抽出条件クラス</param>
        /// <returns>得意先マスタワーククラス</returns>
        /// <remarks>
        /// </remarks>
        private CustomerWork CopyToCustomerWorkFromCustomerCustomerChangeResult(CustomerCustomerChangeResult ret)
        {
            CustomerWork retWork = new CustomerWork();

            retWork.CreateDateTime = ret.CreateDateTime;                // 作成日時
            retWork.UpdateDateTime = ret.UpdateDateTime;                // 更新日時
            retWork.EnterpriseCode = ret.EnterpriseCode;                // 企業コード
            retWork.FileHeaderGuid = ret.FileHeaderGuid;                // GUID
            retWork.UpdEmployeeCode = ret.UpdEmployeeCode;              // 更新従業員コード
            retWork.UpdAssemblyId1 = ret.UpdAssemblyId1;                // 更新アセンブリID1
            retWork.UpdAssemblyId2 = ret.UpdAssemblyId2;                // 更新アセンブリID2
            retWork.LogicalDeleteCode = ret.LogicalDeleteCode;          // 論理削除区分
            retWork.CustomerCode = ret.CustomerCode;                    // 得意先コード
            retWork.CustomerSubCode = ret.CustomerSubCode;              // 得意先サブコード
            retWork.Name = ret.Name;                                    // 名称
            retWork.Name2 = ret.Name2;                                  // 名称2
            retWork.HonorificTitle = ret.HonorificTitle;                // 敬称
            retWork.Kana = ret.Kana;                                    // カナ
            retWork.CustomerSnm = ret.CustomerSnm;                      // 得意先略称
            retWork.OutputNameCode = ret.OutputNameCode;                // 諸口コード
            retWork.OutputName = ret.OutputName;                        // 諸口名称
            retWork.CorporateDivCode = ret.CorporateDivCode;            // 個人・法人区分
            retWork.CustomerAttributeDiv = ret.CustomerAttributeDiv;    // 得意先属性区分
            retWork.JobTypeCode = ret.JobTypeCode;                      // 職種コード
            retWork.JobTypeName = ret.JobTypeName;                      // 職種名称
            retWork.BusinessTypeCode = ret.BusinessTypeCode;            // 業種コード
            retWork.BusinessTypeName = ret.BusinessTypeName;            // 業種名称
            retWork.SalesAreaCode = ret.SalesAreaCode;                  // 販売エリアコード
            retWork.SalesAreaName = ret.SalesAreaName;                  // 販売エリア名称
            retWork.PostNo = ret.PostNo;                                // 郵便番号
            retWork.Address1 = ret.Address1;                            // 住所1（都道府県市区郡・町村・字）
            retWork.Address3 = ret.Address3;                            // 住所3（番地）
            retWork.Address4 = ret.Address4;                            // 住所4（アパート名称）
            retWork.HomeTelNo = ret.HomeTelNo;                          // 電話番号（自宅）
            retWork.OfficeTelNo = ret.OfficeTelNo;                      // 電話番号（勤務先）
            retWork.PortableTelNo = ret.PortableTelNo;                  // 電話番号（携帯）
            retWork.HomeFaxNo = ret.HomeFaxNo;                          // FAX番号（自宅）
            retWork.OfficeFaxNo = ret.OfficeFaxNo;                      // FAX番号（勤務先）
            retWork.OthersTelNo = ret.OthersTelNo;                      // 電話番号（その他）
            retWork.MainContactCode = ret.MainContactCode;              // 主連絡先区分
            retWork.SearchTelNo = ret.SearchTelNo;                      // 電話番号（検索用下4桁）
            retWork.MngSectionCode = ret.MngSectionCode;                // 管理拠点コード
            retWork.MngSectionName = ret.MngSectionName;                // 管理拠点名称
            retWork.InpSectionCode = ret.InpSectionCode;                // 入力拠点コード
            retWork.CustAnalysCode1 = ret.CustAnalysCode1;              // 得意先分析コード1
            retWork.CustAnalysCode2 = ret.CustAnalysCode2;              // 得意先分析コード2
            retWork.CustAnalysCode3 = ret.CustAnalysCode3;              // 得意先分析コード3
            retWork.CustAnalysCode4 = ret.CustAnalysCode4;              // 得意先分析コード4
            retWork.CustAnalysCode5 = ret.CustAnalysCode5;              // 得意先分析コード5
            retWork.CustAnalysCode6 = ret.CustAnalysCode6;              // 得意先分析コード6
            retWork.BillOutputCode = ret.BillOutputCode;                // 請求書出力区分コード
            retWork.BillOutputName = ret.BillOutputName;                // 請求書出力区分名称
            retWork.TotalDay = ret.TotalDay;                            // 締日
            retWork.CollectMoneyCode = ret.CollectMoneyCode;            // 集金月区分コード
            retWork.CollectMoneyName = ret.CollectMoneyName;            // 集金月区分名称
            retWork.CollectMoneyDay = ret.CollectMoneyDay;              // 集金日
            retWork.CollectCond = ret.CollectCond;                      // 回収条件
            retWork.CollectSight = ret.CollectSight;                    // 回収サイト
            retWork.ClaimCode = ret.ClaimCode;                          // 請求先コード
            retWork.ClaimName = ret.ClaimName;                          // 請求先名称
            retWork.ClaimName2 = ret.ClaimName2;                        // 請求先名称2
            retWork.ClaimSnm = ret.ClaimSnm;                            // 請求先略所
            retWork.TransStopDate = ret.TransStopDate;                  // 取引中止日
            retWork.DmOutCode = ret.DmOutCode;                          // DM出力区分
            retWork.DmOutName = ret.DmOutName;                          // DM出力区分名称
            retWork.MainSendMailAddrCd = ret.MainSendMailAddrCd;        // 主送信先メールアドレス区分
            retWork.MailAddrKindCode1 = ret.MailAddrKindCode1;          // メールアドレス種別コード1
            retWork.MailAddrKindName1 = ret.MailAddrKindName1;          // メールアドレス種別名称1
            retWork.MailAddress1 = ret.MailAddress1;                    // メールアドレス1
            retWork.MailSendCode1 = ret.MailSendCode1;                  // メール送信区分コード1
            retWork.MailSendName1 = ret.MailSendName1;                  // メール送信区分名称1
            retWork.MailAddrKindCode2 = ret.MailAddrKindCode2;          // メールアドレス種別コード2
            retWork.MailAddrKindName2 = ret.MailAddrKindName2;          // メールアドレス種別名称2
            retWork.MailAddress2 = ret.MailAddress2;                    // メールアドレス2
            retWork.MailSendCode2 = ret.MailSendCode2;                  // メール送信区分コード2
            retWork.MailSendName2 = ret.MailSendName2;                  // メール送信区分名称2
            retWork.CustomerAgentCd = ret.CustomerAgentCd;              // 顧客担当従業員コード
            retWork.CustomerAgentNm = ret.CustomerAgentNm;              // 顧客担当従業員名称
            retWork.BillCollecterCd = ret.BillCollecterCd;              // 集金担当従業員コード
            retWork.OldCustomerAgentCd = ret.OldCustomerAgentCd;        // 旧顧客担当従業員コード
            retWork.OldCustomerAgentNm = ret.OldCustomerAgentNm;        // 旧顧客担当従業員名称
            retWork.CustAgentChgDate = ret.CustAgentChgDate;            // 顧客担当変更日
            retWork.AcceptWholeSale = ret.AcceptWholeSale;              // 業販先区分
            retWork.CreditMngCode = ret.CreditMngCode;                  // 与信管理区分
            retWork.DepoDelCode = ret.DepoDelCode;                      // 入金消込区分
            retWork.AccRecDivCd = ret.AccRecDivCd;                      // 売掛区分
            retWork.CustSlipNoMngCd = ret.CustSlipNoMngCd;              // 相手伝票番号管理区分
            retWork.PureCode = ret.PureCode;                            // 純正区分
            retWork.CustCTaXLayRefCd = ret.CustCTaXLayRefCd;            // 得意先消費税転嫁方式参照区分
            retWork.ConsTaxLayMethod = ret.ConsTaxLayMethod;            // 消費税転嫁方式
            retWork.TotalAmountDispWayCd = ret.TotalAmountDispWayCd;    // 総額表示方法区分
            retWork.TotalAmntDspWayRef = ret.TotalAmntDspWayRef;        // 総額表示方法参照区分
            retWork.AccountNoInfo1 = ret.AccountNoInfo1;                // 銀行口座1
            retWork.AccountNoInfo2 = ret.AccountNoInfo2;                // 銀行口座2
            retWork.AccountNoInfo3 = ret.AccountNoInfo3;                // 銀行口座3
            retWork.SalesUnPrcFrcProcCd = ret.SalesUnPrcFrcProcCd;      // 売上単価端数処理コード
            retWork.SalesMoneyFrcProcCd = ret.SalesMoneyFrcProcCd;      // 売上金額端数処理コード
            retWork.SalesCnsTaxFrcProcCd = ret.SalesCnsTaxFrcProcCd;    // 売上消費税端数処理コード
            retWork.CustomerSlipNoDiv = ret.CustomerSlipNoDiv;          // 得意先伝票番号区分
            retWork.NTimeCalcStDate = ret.NTimeCalcStDate;              // 次回勘定開始日
            retWork.CustomerAgent = ret.CustomerAgent;                  // 得意先担当者
            retWork.ClaimSectionCode = ret.ClaimSectionCode;            // 請求拠点コード
            retWork.ClaimSectionName = ret.ClaimSectionName;            // 請求拠点名称
            retWork.CarMngDivCd = ret.CarMngDivCd;                      // 車輌管理区分
            retWork.BillPartsNoPrtCd = ret.BillPartsNoPrtCd;            // 品番印字区分(請求書)
            retWork.DeliPartsNoPrtCd = ret.DeliPartsNoPrtCd;            // 品番印字区分(納品書）
            retWork.DefSalesSlipCd = ret.DefSalesSlipCd;                // 伝票区分初期値
            retWork.LavorRateRank = ret.LavorRateRank;                  // 工賃レバレートランク
            retWork.SlipTtlPrn = ret.SlipTtlPrn;                        // 伝票タイトルパターン
            retWork.DepoBankCode = ret.DepoBankCode;                    // 入金銀行コード
            retWork.DepoBankName = ret.DepoBankName;                    // 入金銀行名称
            retWork.CustWarehouseCd = ret.CustWarehouseCd;              // 得意先優先倉庫コード
            retWork.CustWarehouseName = ret.CustWarehouseName;          // 得意先優先倉庫名称
            retWork.QrcodePrtCd = ret.QrcodePrtCd;                      // QRコード印刷
            retWork.DeliHonorificTtl = ret.DeliHonorificTtl;            // 納品書敬称
            retWork.BillHonorificTtl = ret.BillHonorificTtl;            // 請求書敬称
            retWork.EstmHonorificTtl = ret.EstmHonorificTtl;            // 見積書敬称
            retWork.RectHonorificTtl = ret.RectHonorificTtl;            // 領収書敬称
            retWork.DeliHonorTtlPrtDiv = ret.DeliHonorTtlPrtDiv;        // 納品書敬称印字区分
            retWork.BillHonorTtlPrtDiv = ret.BillHonorTtlPrtDiv;        // 請求書敬称印字区分
            retWork.EstmHonorTtlPrtDiv = ret.EstmHonorTtlPrtDiv;        // 見積書敬称印字区分
            retWork.RectHonorTtlPrtDiv = ret.RectHonorTtlPrtDiv;        // 領収書敬称印字区分
            retWork.Note1 = ret.Note1;                                  // 備考1
            retWork.Note2 = ret.Note2;                                  // 備考2
            retWork.Note3 = ret.Note3;                                  // 備考3
            retWork.Note4 = ret.Note4;                                  // 備考4
            retWork.Note5 = ret.Note5;                                  // 備考5
            retWork.Note6 = ret.Note6;                                  // 備考6
            retWork.Note7 = ret.Note7;                                  // 備考7
            retWork.Note8 = ret.Note8;                                  // 備考8
            retWork.Note9 = ret.Note9;                                  // 備考9
            retWork.Note10 = ret.Note10;                                // 備考10
            retWork.CreditMoney = ret.CreditMoney;                      // 与信額[変動情報]
            retWork.WarningCreditMoney = ret.WarningCreditMoney;        // 警告与信額[変動情報]
            retWork.PrsntAccRecBalance = ret.PrsntAccRecBalance;        // 現在売掛残高[変動情報]
            retWork.ReceiptOutputCode = ret.ReceiptOutputCode;          // 領収書出力区分コード
            retWork.WriteDiv = 1;                                       // 更新区分

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            retWork.SalesSlipPrtDiv = ret.SalesSlipPrtDiv;      // 納品書出力（売上伝票発行区分）
            retWork.AcpOdrrSlipPrtDiv = ret.AcpOdrrSlipPrtDiv;  // 受注伝票出力（受注伝票発行区分）
            retWork.ShipmSlipPrtDiv = ret.ShipmSlipPrtDiv;      // 貸出伝票出力（出荷伝票発行区分）
            retWork.EstimatePrtDiv = ret.EstimatePrtDiv;        // 見積伝票出力（見積伝票発行区分）
            retWork.UOESlipPrtDiv = ret.UOESlipPrtDiv;          // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            retWork.TotalBillOutputDiv = ret.TotalBillOutputDiv;    // 合計請求書出力区分
            retWork.DetailBillOutputCode = ret.DetailBillOutputCode;// 明細請求書出力区分
            retWork.SlipTtlBillOutputDiv = ret.SlipTtlBillOutputDiv;// 伝票合計請求書出力区分
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            return retWork;
        }
        // ADD 2009/04/10 ------<<<

        #endregion ■ Private Methods
    }
}
