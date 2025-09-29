using System;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// 支払データ操作クラス
    /// </summary>
    public static class PaymentDataUtil
    {
        /// <summary>
        /// 支払伝票データと支払明細データを合体して支払データを作成します。
        /// </summary>
        /// <param name="paymentDataWork">作成した支払データ</param>
        /// <param name="paymentSlpWork">支払伝票データ</param>
        /// <param name="paymentDtlWorkArray">支払明細データの配列</param>
        public static void UnionRef(ref PaymentDataWork paymentDataWork, PaymentSlpWork paymentSlpWork, PaymentDtlWork[] paymentDtlWorkArray)
        {
            if (paymentDataWork != null)
            {
                # region [PaymentDataWork ← PaymentSlpWork]
                if (paymentSlpWork != null)
                {
                    paymentDataWork.CreateDateTime = paymentSlpWork.CreateDateTime;            // 作成日時
                    paymentDataWork.UpdateDateTime = paymentSlpWork.UpdateDateTime;            // 更新日時
                    paymentDataWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;            // 企業コード
                    paymentDataWork.FileHeaderGuid = paymentSlpWork.FileHeaderGuid;            // GUID
                    paymentDataWork.UpdEmployeeCode = paymentSlpWork.UpdEmployeeCode;          // 更新従業員コード
                    paymentDataWork.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;            // 更新アセンブリID1
                    paymentDataWork.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;            // 更新アセンブリID2
                    paymentDataWork.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode;      // 論理削除区分
                    paymentDataWork.DebitNoteDiv = paymentSlpWork.DebitNoteDiv;                // 赤伝区分
                    paymentDataWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;              // 支払伝票番号
                    paymentDataWork.SupplierFormal = paymentSlpWork.SupplierFormal;            // 仕入形式
                    paymentDataWork.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;            // 仕入伝票番号
                    paymentDataWork.SupplierCd = paymentSlpWork.SupplierCd;                    // 仕入先コード
                    paymentDataWork.SupplierNm1 = paymentSlpWork.SupplierNm1;                  // 仕入先名1
                    paymentDataWork.SupplierNm2 = paymentSlpWork.SupplierNm2;                  // 仕入先名2
                    paymentDataWork.SupplierSnm = paymentSlpWork.SupplierSnm;                  // 仕入先略称
                    paymentDataWork.PayeeCode = paymentSlpWork.PayeeCode;                      // 支払先コード
                    paymentDataWork.PayeeName = paymentSlpWork.PayeeName;                      // 支払先名称
                    paymentDataWork.PayeeName2 = paymentSlpWork.PayeeName2;                    // 支払先名称2
                    paymentDataWork.PayeeSnm = paymentSlpWork.PayeeSnm;                        // 支払先略称
                    paymentDataWork.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;  // 支払入力拠点コード
                    paymentDataWork.AddUpSecCode = paymentSlpWork.AddUpSecCode;                // 計上拠点コード
                    paymentDataWork.UpdateSecCd = paymentSlpWork.UpdateSecCd;                  // 更新拠点コード
                    paymentDataWork.SubSectionCode = paymentSlpWork.SubSectionCode;            // 部門コード
                    paymentDataWork.InputDay = paymentSlpWork.InputDay;                        // 入力日付  //ADD 2009/03/25
                    paymentDataWork.PaymentDate = paymentSlpWork.PaymentDate;                  // 支払日付
                    paymentDataWork.AddUpADate = paymentSlpWork.AddUpADate;                    // 計上日付
                    paymentDataWork.PaymentTotal = paymentSlpWork.PaymentTotal;                // 支払計
                    paymentDataWork.Payment = paymentSlpWork.Payment;                          // 支払金額
                    paymentDataWork.FeePayment = paymentSlpWork.FeePayment;                    // 手数料支払額
                    paymentDataWork.DiscountPayment = paymentSlpWork.DiscountPayment;          // 値引支払額
                    paymentDataWork.AutoPayment = paymentSlpWork.AutoPayment;                  // 自動支払区分
                    paymentDataWork.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;        // 手形振出日
                    paymentDataWork.DraftKind = paymentSlpWork.DraftKind;                      // 手形種類
                    paymentDataWork.DraftKindName = paymentSlpWork.DraftKindName;              // 手形種類名称
                    paymentDataWork.DraftDivide = paymentSlpWork.DraftDivide;                  // 手形区分
                    paymentDataWork.DraftDivideName = paymentSlpWork.DraftDivideName;          // 手形区分名称
                    paymentDataWork.DraftNo = paymentSlpWork.DraftNo;                          // 手形番号
                    paymentDataWork.DebitNoteLinkPayNo = paymentSlpWork.DebitNoteLinkPayNo;    // 赤黒支払連結番号
                    paymentDataWork.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;        // 支払担当者コード
                    paymentDataWork.PaymentAgentName = paymentSlpWork.PaymentAgentName;        // 支払担当者名称
                    paymentDataWork.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;  // 支払入力者コード
                    paymentDataWork.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;  // 支払入力者名称
                    paymentDataWork.Outline = paymentSlpWork.Outline;                          // 伝票摘要
                    paymentDataWork.BankCode = paymentSlpWork.BankCode;                        // 銀行コード
                    paymentDataWork.BankName = paymentSlpWork.BankName;                        // 銀行名称
                }
                # endregion

                # region [PaymentDataWork ← PaymentDtlWork]
                if (paymentDtlWorkArray != null)
                {
                    for (int idx = 0; idx < paymentDtlWorkArray.Length; idx++)
                    {
                        PaymentDtlWork paymentDtlWork = paymentDtlWorkArray[idx];

                        switch (paymentDtlWork.PaymentRowNo)
                        {
                            case 1:
                                {
                                    paymentDataWork.PaymentRowNo1 = paymentDtlWork.PaymentRowNo;     // 支払行番号１
                                    paymentDataWork.MoneyKindCode1 = paymentDtlWork.MoneyKindCode;   // 金種コード１
                                    paymentDataWork.MoneyKindName1 = paymentDtlWork.MoneyKindName;   // 金種名称１
                                    paymentDataWork.MoneyKindDiv1 = paymentDtlWork.MoneyKindDiv;     // 金種区分１
                                    paymentDataWork.Payment1 = paymentDtlWork.Payment;               // 支払金額１
                                    paymentDataWork.ValidityTerm1 = paymentDtlWork.ValidityTerm;     // 有効期限１
                                    break;
                                }
                            case 2:
                                {
                                    paymentDataWork.PaymentRowNo2 = paymentDtlWork.PaymentRowNo;     // 支払行番号２
                                    paymentDataWork.MoneyKindCode2 = paymentDtlWork.MoneyKindCode;   // 金種コード２
                                    paymentDataWork.MoneyKindName2 = paymentDtlWork.MoneyKindName;   // 金種名称２
                                    paymentDataWork.MoneyKindDiv2 = paymentDtlWork.MoneyKindDiv;     // 金種区分２
                                    paymentDataWork.Payment2 = paymentDtlWork.Payment;               // 支払金額２
                                    paymentDataWork.ValidityTerm2 = paymentDtlWork.ValidityTerm;     // 有効期限２
                                    break;
                                }
                            case 3:
                                {
                                    paymentDataWork.PaymentRowNo3 = paymentDtlWork.PaymentRowNo;     // 支払行番号３
                                    paymentDataWork.MoneyKindCode3 = paymentDtlWork.MoneyKindCode;   // 金種コード３
                                    paymentDataWork.MoneyKindName3 = paymentDtlWork.MoneyKindName;   // 金種名称３
                                    paymentDataWork.MoneyKindDiv3 = paymentDtlWork.MoneyKindDiv;     // 金種区分３
                                    paymentDataWork.Payment3 = paymentDtlWork.Payment;               // 支払金額３
                                    paymentDataWork.ValidityTerm3 = paymentDtlWork.ValidityTerm;     // 有効期限３
                                    break;
                                }
                            case 4:
                                {
                                    paymentDataWork.PaymentRowNo4 = paymentDtlWork.PaymentRowNo;     // 支払行番号４
                                    paymentDataWork.MoneyKindCode4 = paymentDtlWork.MoneyKindCode;   // 金種コード４
                                    paymentDataWork.MoneyKindName4 = paymentDtlWork.MoneyKindName;   // 金種名称４
                                    paymentDataWork.MoneyKindDiv4 = paymentDtlWork.MoneyKindDiv;     // 金種区分４
                                    paymentDataWork.Payment4 = paymentDtlWork.Payment;               // 支払金額４
                                    paymentDataWork.ValidityTerm4 = paymentDtlWork.ValidityTerm;     // 有効期限４
                                    break;
                                }
                            case 5:
                                {
                                    paymentDataWork.PaymentRowNo5 = paymentDtlWork.PaymentRowNo;     // 支払行番号５
                                    paymentDataWork.MoneyKindCode5 = paymentDtlWork.MoneyKindCode;   // 金種コード５
                                    paymentDataWork.MoneyKindName5 = paymentDtlWork.MoneyKindName;   // 金種名称５
                                    paymentDataWork.MoneyKindDiv5 = paymentDtlWork.MoneyKindDiv;     // 金種区分５
                                    paymentDataWork.Payment5 = paymentDtlWork.Payment;               // 支払金額５
                                    paymentDataWork.ValidityTerm5 = paymentDtlWork.ValidityTerm;     // 有効期限５
                                    break;
                                }
                            case 6:
                                {
                                    paymentDataWork.PaymentRowNo6 = paymentDtlWork.PaymentRowNo;     // 支払行番号６
                                    paymentDataWork.MoneyKindCode6 = paymentDtlWork.MoneyKindCode;   // 金種コード６
                                    paymentDataWork.MoneyKindName6 = paymentDtlWork.MoneyKindName;   // 金種名称６
                                    paymentDataWork.MoneyKindDiv6 = paymentDtlWork.MoneyKindDiv;     // 金種区分６
                                    paymentDataWork.Payment6 = paymentDtlWork.Payment;               // 支払金額６
                                    paymentDataWork.ValidityTerm6 = paymentDtlWork.ValidityTerm;     // 有効期限６
                                    break;
                                }
                            case 7:
                                {
                                    paymentDataWork.PaymentRowNo7 = paymentDtlWork.PaymentRowNo;     // 支払行番号７
                                    paymentDataWork.MoneyKindCode7 = paymentDtlWork.MoneyKindCode;   // 金種コード７
                                    paymentDataWork.MoneyKindName7 = paymentDtlWork.MoneyKindName;   // 金種名称７
                                    paymentDataWork.MoneyKindDiv7 = paymentDtlWork.MoneyKindDiv;     // 金種区分７
                                    paymentDataWork.Payment7 = paymentDtlWork.Payment;               // 支払金額７
                                    paymentDataWork.ValidityTerm7 = paymentDtlWork.ValidityTerm;     // 有効期限７
                                    break;
                                }
                            case 8:
                                {
                                    paymentDataWork.PaymentRowNo8 = paymentDtlWork.PaymentRowNo;     // 支払行番号８
                                    paymentDataWork.MoneyKindCode8 = paymentDtlWork.MoneyKindCode;   // 金種コード８
                                    paymentDataWork.MoneyKindName8 = paymentDtlWork.MoneyKindName;   // 金種名称８
                                    paymentDataWork.MoneyKindDiv8 = paymentDtlWork.MoneyKindDiv;     // 金種区分８
                                    paymentDataWork.Payment8 = paymentDtlWork.Payment;               // 支払金額８
                                    paymentDataWork.ValidityTerm8 = paymentDtlWork.ValidityTerm;     // 有効期限８
                                    break;
                                }
                            case 9:
                                {
                                    paymentDataWork.PaymentRowNo9 = paymentDtlWork.PaymentRowNo;     // 支払行番号９
                                    paymentDataWork.MoneyKindCode9 = paymentDtlWork.MoneyKindCode;   // 金種コード９
                                    paymentDataWork.MoneyKindName9 = paymentDtlWork.MoneyKindName;   // 金種名称９
                                    paymentDataWork.MoneyKindDiv9 = paymentDtlWork.MoneyKindDiv;     // 金種区分９
                                    paymentDataWork.Payment9 = paymentDtlWork.Payment;               // 支払金額９
                                    paymentDataWork.ValidityTerm9 = paymentDtlWork.ValidityTerm;     // 有効期限９
                                    break;
                                }
                            case 10:
                                {
                                    paymentDataWork.PaymentRowNo10 = paymentDtlWork.PaymentRowNo;    // 支払行番号１０
                                    paymentDataWork.MoneyKindCode10 = paymentDtlWork.MoneyKindCode;  // 金種コード１０
                                    paymentDataWork.MoneyKindName10 = paymentDtlWork.MoneyKindName;  // 金種名称１０
                                    paymentDataWork.MoneyKindDiv10 = paymentDtlWork.MoneyKindDiv;    // 金種区分１０
                                    paymentDataWork.Payment10 = paymentDtlWork.Payment;              // 支払金額１０
                                    paymentDataWork.ValidityTerm10 = paymentDtlWork.ValidityTerm;    // 有効期限１０
                                    break;
                                }
                        }
                    }
                }
                # endregion
            }
        }
        
        /// <summary>
        /// 支払伝票データと支払明細データを合体して支払データを作成します。
        /// </summary>
        /// <param name="paymentDataWork">作成した支払データ</param>
        /// <param name="paymentSlpWork">支払伝票データ</param>
        /// <param name="paymentDtlWorkArray">支払明細データの配列</param>
        public static void Union(out PaymentDataWork paymentDataWork, PaymentSlpWork paymentSlpWork, PaymentDtlWork[] paymentDtlWorkArray)
        {
            paymentDataWork = new PaymentDataWork();
            PaymentDataUtil.UnionRef(ref paymentDataWork, paymentSlpWork, paymentDtlWorkArray);
        }

        /// <summary>
        /// 支払データを支払伝票データと支払明細データに分割します。
        /// </summary>
        /// <param name="paymentDataWork">支払データ</param>
        /// <param name="paymentSlpWork">分割された支払伝票データ</param>
        /// <param name="paymentDtlWorkArray">分割された支払明細データの配列</param>
        public static void DivisionRef(PaymentDataWork paymentDataWork, ref PaymentSlpWork paymentSlpWork, ref PaymentDtlWork[] paymentDtlWorkArray)
        {
            if (paymentDataWork != null && paymentSlpWork != null && paymentDtlWorkArray != null)
            {
                # region [PaymentSlpWork ← PaymentDataWork]
                paymentSlpWork.CreateDateTime = paymentDataWork.CreateDateTime;            // 作成日時
                paymentSlpWork.UpdateDateTime = paymentDataWork.UpdateDateTime;            // 更新日時
                paymentSlpWork.EnterpriseCode = paymentDataWork.EnterpriseCode;            // 企業コード
                paymentSlpWork.FileHeaderGuid = paymentDataWork.FileHeaderGuid;            // GUID
                paymentSlpWork.UpdEmployeeCode = paymentDataWork.UpdEmployeeCode;          // 更新従業員コード
                paymentSlpWork.UpdAssemblyId1 = paymentDataWork.UpdAssemblyId1;            // 更新アセンブリID1
                paymentSlpWork.UpdAssemblyId2 = paymentDataWork.UpdAssemblyId2;            // 更新アセンブリID2
                paymentSlpWork.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;      // 論理削除区分
                paymentSlpWork.DebitNoteDiv = paymentDataWork.DebitNoteDiv;                // 赤伝区分
                paymentSlpWork.PaymentSlipNo = paymentDataWork.PaymentSlipNo;              // 支払伝票番号
                paymentSlpWork.SupplierFormal = paymentDataWork.SupplierFormal;            // 仕入形式
                paymentSlpWork.SupplierSlipNo = paymentDataWork.SupplierSlipNo;            // 仕入伝票番号
                paymentSlpWork.SupplierCd = paymentDataWork.SupplierCd;                    // 仕入先コード
                paymentSlpWork.SupplierNm1 = paymentDataWork.SupplierNm1;                  // 仕入先名1
                paymentSlpWork.SupplierNm2 = paymentDataWork.SupplierNm2;                  // 仕入先名2
                paymentSlpWork.SupplierSnm = paymentDataWork.SupplierSnm;                  // 仕入先略称
                paymentSlpWork.PayeeCode = paymentDataWork.PayeeCode;                      // 支払先コード
                paymentSlpWork.PayeeName = paymentDataWork.PayeeName;                      // 支払先名称
                paymentSlpWork.PayeeName2 = paymentDataWork.PayeeName2;                    // 支払先名称2
                paymentSlpWork.PayeeSnm = paymentDataWork.PayeeSnm;                        // 支払先略称
                paymentSlpWork.PaymentInpSectionCd = paymentDataWork.PaymentInpSectionCd;  // 支払入力拠点コード
                paymentSlpWork.AddUpSecCode = paymentDataWork.AddUpSecCode;                // 計上拠点コード
                paymentSlpWork.UpdateSecCd = paymentDataWork.UpdateSecCd;                  // 更新拠点コード
                paymentSlpWork.SubSectionCode = paymentDataWork.SubSectionCode;            // 部門コード
                paymentSlpWork.InputDay = paymentDataWork.InputDay;                        // 入力日付  // ADD 2009/03/25
                paymentSlpWork.PaymentDate = paymentDataWork.PaymentDate;                  // 支払日付
                paymentSlpWork.PrePaymentDate = paymentDataWork.PrePaymentDate;            // 前回支払日付 // ADD 2011/12/15
                paymentSlpWork.AddUpADate = paymentDataWork.AddUpADate;                    // 計上日付
                paymentSlpWork.PaymentTotal = paymentDataWork.PaymentTotal;                // 支払計
                paymentSlpWork.Payment = paymentDataWork.Payment;                          // 支払金額
                paymentSlpWork.FeePayment = paymentDataWork.FeePayment;                    // 手数料支払額
                paymentSlpWork.DiscountPayment = paymentDataWork.DiscountPayment;          // 値引支払額
                paymentSlpWork.AutoPayment = paymentDataWork.AutoPayment;                  // 自動支払区分
                paymentSlpWork.DraftDrawingDate = paymentDataWork.DraftDrawingDate;        // 手形振出日
                paymentSlpWork.DraftKind = paymentDataWork.DraftKind;                      // 手形種類
                paymentSlpWork.DraftKindName = paymentDataWork.DraftKindName;              // 手形種類名称
                paymentSlpWork.DraftDivide = paymentDataWork.DraftDivide;                  // 手形区分
                paymentSlpWork.DraftDivideName = paymentDataWork.DraftDivideName;          // 手形区分名称
                paymentSlpWork.DraftNo = paymentDataWork.DraftNo;                          // 手形番号
                paymentSlpWork.DebitNoteLinkPayNo = paymentDataWork.DebitNoteLinkPayNo;    // 赤黒支払連結番号
                paymentSlpWork.PaymentAgentCode = paymentDataWork.PaymentAgentCode;        // 支払担当者コード
                paymentSlpWork.PaymentAgentName = paymentDataWork.PaymentAgentName;        // 支払担当者名称
                paymentSlpWork.PaymentInputAgentCd = paymentDataWork.PaymentInputAgentCd;  // 支払入力者コード
                paymentSlpWork.PaymentInputAgentNm = paymentDataWork.PaymentInputAgentNm;  // 支払入力者名称
                paymentSlpWork.Outline = paymentDataWork.Outline;                          // 伝票摘要
                paymentSlpWork.BankCode = paymentDataWork.BankCode;                        // 銀行コード
                paymentSlpWork.BankName = paymentDataWork.BankName;                        // 銀行名称
                # endregion

                # region [PaymentDtlWork[] ← PaymentDataWork]

                ArrayList paymentDtlWorkList = new ArrayList();

                if (paymentDataWork.PaymentRowNo1 > 0)
                {
                    PaymentDtlWork paymentDtlWork1 = new PaymentDtlWork();
                    paymentDtlWork1.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork1.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork1.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork1.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork1.PaymentRowNo = paymentDataWork.PaymentRowNo1;
                    paymentDtlWork1.MoneyKindCode = paymentDataWork.MoneyKindCode1;
                    paymentDtlWork1.MoneyKindName = paymentDataWork.MoneyKindName1;
                    paymentDtlWork1.MoneyKindDiv = paymentDataWork.MoneyKindDiv1;
                    paymentDtlWork1.Payment = paymentDataWork.Payment1;
                    paymentDtlWork1.ValidityTerm = paymentDataWork.ValidityTerm1;
                    paymentDtlWorkList.Add(paymentDtlWork1);
                }
                if (paymentDataWork.PaymentRowNo2 > 0)
                {
                    PaymentDtlWork paymentDtlWork2 = new PaymentDtlWork();
                    paymentDtlWork2.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork2.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork2.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork2.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork2.PaymentRowNo = paymentDataWork.PaymentRowNo2;
                    paymentDtlWork2.MoneyKindCode = paymentDataWork.MoneyKindCode2;
                    paymentDtlWork2.MoneyKindName = paymentDataWork.MoneyKindName2;
                    paymentDtlWork2.MoneyKindDiv = paymentDataWork.MoneyKindDiv2;
                    paymentDtlWork2.Payment = paymentDataWork.Payment2;
                    paymentDtlWork2.ValidityTerm = paymentDataWork.ValidityTerm2;
                    paymentDtlWorkList.Add(paymentDtlWork2);
                }
                if (paymentDataWork.PaymentRowNo3 > 0)
                {
                    PaymentDtlWork paymentDtlWork3 = new PaymentDtlWork();
                    paymentDtlWork3.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork3.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork3.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork3.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork3.PaymentRowNo = paymentDataWork.PaymentRowNo3;
                    paymentDtlWork3.MoneyKindCode = paymentDataWork.MoneyKindCode3;
                    paymentDtlWork3.MoneyKindName = paymentDataWork.MoneyKindName3;
                    paymentDtlWork3.MoneyKindDiv = paymentDataWork.MoneyKindDiv3;
                    paymentDtlWork3.Payment = paymentDataWork.Payment3;
                    paymentDtlWork3.ValidityTerm = paymentDataWork.ValidityTerm3;
                    paymentDtlWorkList.Add(paymentDtlWork3);
                }
                if (paymentDataWork.PaymentRowNo4 > 0)
                {
                    PaymentDtlWork paymentDtlWork4 = new PaymentDtlWork();
                    paymentDtlWork4.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork4.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork4.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork4.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork4.PaymentRowNo = paymentDataWork.PaymentRowNo4;
                    paymentDtlWork4.MoneyKindCode = paymentDataWork.MoneyKindCode4;
                    paymentDtlWork4.MoneyKindName = paymentDataWork.MoneyKindName4;
                    paymentDtlWork4.MoneyKindDiv = paymentDataWork.MoneyKindDiv4;
                    paymentDtlWork4.Payment = paymentDataWork.Payment4;
                    paymentDtlWork4.ValidityTerm = paymentDataWork.ValidityTerm4;
                    paymentDtlWorkList.Add(paymentDtlWork4);
                }
                if (paymentDataWork.PaymentRowNo5 > 0)
                {
                    PaymentDtlWork paymentDtlWork5 = new PaymentDtlWork();
                    paymentDtlWork5.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork5.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork5.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork5.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork5.PaymentRowNo = paymentDataWork.PaymentRowNo5;
                    paymentDtlWork5.MoneyKindCode = paymentDataWork.MoneyKindCode5;
                    paymentDtlWork5.MoneyKindName = paymentDataWork.MoneyKindName5;
                    paymentDtlWork5.MoneyKindDiv = paymentDataWork.MoneyKindDiv5;
                    paymentDtlWork5.Payment = paymentDataWork.Payment5;
                    paymentDtlWork5.ValidityTerm = paymentDataWork.ValidityTerm5;
                    paymentDtlWorkList.Add(paymentDtlWork5);
                }
                if (paymentDataWork.PaymentRowNo6 > 0)
                {
                    PaymentDtlWork paymentDtlWork6 = new PaymentDtlWork();
                    paymentDtlWork6.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork6.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork6.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork6.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork6.PaymentRowNo = paymentDataWork.PaymentRowNo6;
                    paymentDtlWork6.MoneyKindCode = paymentDataWork.MoneyKindCode6;
                    paymentDtlWork6.MoneyKindName = paymentDataWork.MoneyKindName6;
                    paymentDtlWork6.MoneyKindDiv = paymentDataWork.MoneyKindDiv6;
                    paymentDtlWork6.Payment = paymentDataWork.Payment6;
                    paymentDtlWork6.ValidityTerm = paymentDataWork.ValidityTerm6;
                    paymentDtlWorkList.Add(paymentDtlWork6);
                }
                if (paymentDataWork.PaymentRowNo7 > 0)
                {
                    PaymentDtlWork paymentDtlWork7 = new PaymentDtlWork();
                    paymentDtlWork7.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork7.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork7.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork7.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork7.PaymentRowNo = paymentDataWork.PaymentRowNo7;
                    paymentDtlWork7.MoneyKindCode = paymentDataWork.MoneyKindCode7;
                    paymentDtlWork7.MoneyKindName = paymentDataWork.MoneyKindName7;
                    paymentDtlWork7.MoneyKindDiv = paymentDataWork.MoneyKindDiv7;
                    paymentDtlWork7.Payment = paymentDataWork.Payment7;
                    paymentDtlWork7.ValidityTerm = paymentDataWork.ValidityTerm7;
                    paymentDtlWorkList.Add(paymentDtlWork7);
                }
                if (paymentDataWork.PaymentRowNo8 > 0)
                {
                    PaymentDtlWork paymentDtlWork8 = new PaymentDtlWork();
                    paymentDtlWork8.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork8.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork8.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork8.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork8.PaymentRowNo = paymentDataWork.PaymentRowNo8;
                    paymentDtlWork8.MoneyKindCode = paymentDataWork.MoneyKindCode8;
                    paymentDtlWork8.MoneyKindName = paymentDataWork.MoneyKindName8;
                    paymentDtlWork8.MoneyKindDiv = paymentDataWork.MoneyKindDiv8;
                    paymentDtlWork8.Payment = paymentDataWork.Payment8;
                    paymentDtlWork8.ValidityTerm = paymentDataWork.ValidityTerm8;
                    paymentDtlWorkList.Add(paymentDtlWork8);
                }
                if (paymentDataWork.PaymentRowNo9 > 0)
                {
                    PaymentDtlWork paymentDtlWork9 = new PaymentDtlWork();
                    paymentDtlWork9.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork9.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork9.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork9.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork9.PaymentRowNo = paymentDataWork.PaymentRowNo9;
                    paymentDtlWork9.MoneyKindCode = paymentDataWork.MoneyKindCode9;
                    paymentDtlWork9.MoneyKindName = paymentDataWork.MoneyKindName9;
                    paymentDtlWork9.MoneyKindDiv = paymentDataWork.MoneyKindDiv9;
                    paymentDtlWork9.Payment = paymentDataWork.Payment9;
                    paymentDtlWork9.ValidityTerm = paymentDataWork.ValidityTerm9;
                    paymentDtlWorkList.Add(paymentDtlWork9);
                }
                if (paymentDataWork.PaymentRowNo10 > 0)
                {
                    PaymentDtlWork paymentDtlWork10 = new PaymentDtlWork();
                    paymentDtlWork10.EnterpriseCode = paymentDataWork.EnterpriseCode;
                    paymentDtlWork10.LogicalDeleteCode = paymentDataWork.LogicalDeleteCode;
                    paymentDtlWork10.SupplierFormal = paymentDataWork.SupplierFormal;
                    paymentDtlWork10.PaymentSlipNo = paymentDataWork.PaymentSlipNo;
                    paymentDtlWork10.PaymentRowNo = paymentDataWork.PaymentRowNo10;
                    paymentDtlWork10.MoneyKindCode = paymentDataWork.MoneyKindCode10;
                    paymentDtlWork10.MoneyKindName = paymentDataWork.MoneyKindName10;
                    paymentDtlWork10.MoneyKindDiv = paymentDataWork.MoneyKindDiv10;
                    paymentDtlWork10.Payment = paymentDataWork.Payment10;
                    paymentDtlWork10.ValidityTerm = paymentDataWork.ValidityTerm10;
                    paymentDtlWorkList.Add(paymentDtlWork10);
                }

                if (paymentDtlWorkList != null && paymentDtlWorkList.Count > 0)
                {
                    paymentDtlWorkArray = (PaymentDtlWork[])paymentDtlWorkList.ToArray(typeof(PaymentDtlWork));
                }
                # endregion
            }
        }

        /// <summary>
        /// 支払データを支払伝票データと支払明細データに分割します。
        /// </summary>
        /// <param name="paymentDataWork">支払データ</param>
        /// <param name="paymentSlpWork">分割された支払伝票データ</param>
        /// <param name="paymentDtlWorkArray">分割された支払明細データの配列</param>
        public static void Division(PaymentDataWork paymentDataWork, out PaymentSlpWork paymentSlpWork, out PaymentDtlWork[] paymentDtlWorkArray)
        {
            paymentSlpWork = new PaymentSlpWork();
            paymentDtlWorkArray = new PaymentDtlWork[0];
            PaymentDataUtil.DivisionRef(paymentDataWork, ref paymentSlpWork, ref paymentDtlWorkArray);
        }

    }
}
