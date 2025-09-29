//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先マスタ
// プログラム概要   ：得意先の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/04/23     修正内容：Partsman用に修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/02/03     修正内容：障害ID:9391対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【12493】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/03     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30531 大矢 睦美
// 修正日    2009/01/04     修正内容：MANTIS【14873】請求書タイプ毎出力区分追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤 恵優
// 修正日    2010/06/26     修正内容：SCM：簡単問合せアカウントグループIDを追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/07/06     修正内容：QRコード携帯メール対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：caowj
// 修正日    2010/08/10     修正内容：障害改良対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2011/06/09     修正内容：名称変更対応[SCM→PCC]
// ---------------------------------------------------------------------//
// 管理番号  10970681-00    作成担当：陳健
// 修正日    K2014/02/06    修正内容：前橋京和商会個別 得意先マスタ改良対応
// ------------------------------------------------------------------------//
// 管理番号  11770021-00    作成担当：梶谷貴士
// 修正日    2021/05/10     修正内容：得意先情報ガイド表示PKG対応
// ------------------------------------------------------------------------//
using System;
using System.Collections;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerInfo
	/// <summary>
	///                      得意先マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/18</br>
	/// <br>Genarated Date   :   2008/04/23  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustomerInfo
	{
        // --- DEL 2010/08/10 ------------------------------------>>>>>
        //# region public static readonly string（手動追加）
        ///// <summary>様</summary>
        //public static readonly string CST_HonorificTitle_0 = "様";
        ///// <summary>殿</summary>
        //public static readonly string CST_HonorificTitle_1 = "殿";
        ///// <summary>御中</summary>
        //public static readonly string CST_HonorificTitle_2 = "御中";

        ///// <summary>得意先名称１,２を使用する</summary>
        //public static readonly string CST_OutputName_0 = "得意先名称１・２";
        ///// <summary>得意先名称１を使用する</summary>
        //public static readonly string CST_OutputName_1 = "得意先名称１";
        ///// <summary>得意先名称２を使用する</summary>
        //public static readonly string CST_OutputName_2 = "得意先名称２";
        ///// <summary>諸口名称を使用する</summary>
        //public static readonly string CST_OutputName_3 = "諸口名称";

        ///// <summary>当月</summary>
        //public static readonly string CST_CollectMoneyName_0 = "当月";
        ///// <summary>翌月</summary>
        //public static readonly string CST_CollectMoneyName_1 = "翌月";
        ///// <summary>翌々月</summary>
        //public static readonly string CST_CollectMoneyName_2 = "翌々月";
        ///// <summary>翌々々月</summary>
        //public static readonly string CST_CollectMoneyName_3 = "翌々々月";

        ///// <summary>個人</summary>
        //public static readonly string CST_CorporateDivName_0 = "個人";
        ///// <summary>法人</summary>
        //public static readonly string CST_CorporateDivName_1 = "法人";
        ///// <summary>大口法人</summary>
        //public static readonly string CST_CorporateDivName_2 = "大口法人";
        ///// <summary>業者</summary>
        //public static readonly string CST_CorporateDivName_3 = "業者";
        ///// <summary>社員</summary>
        //public static readonly string CST_CorporateDivName_4 = "社員";

        ///// <summary>する</summary>
        //public static readonly string CST_BillOutputName_0 = "する";
        ///// <summary>しない</summary>
        //public static readonly string CST_BillOutputName_1 = "しない";

        ///// <summary>する</summary>
        //public static readonly string CST_DmOutName_0 = "する";
        ///// <summary>しない</summary>
        //public static readonly string CST_DmOutName_1 = "しない";

        ///// <summary>送信しない</summary>
        //public static readonly string CST_MailSendName_0 = "送信しない";
        ///// <summary>送信する</summary>
        //public static readonly string CST_MailSendName_1 = "送信する";

        ///// <summary>自宅</summary>
        //public static readonly string CST_MailAddrKindName_0 = "自宅";
        ///// <summary>会社</summary>
        //public static readonly string CST_MailAddrKindName_1 = "会社";
        ///// <summary>携帯端末</summary>
        //public static readonly string CST_MailAddrKindName_2 = "携帯端末";
        ///// <summary>本人以外</summary>
        //public static readonly string CST_MailAddrKindName_3 = "本人以外";
        ///// <summary>その他</summary>
        //public static readonly string CST_MailAddrKindName_99 = "その他";

        ///// <summary>伝票単位</summary>
        //public static readonly string CST_ConsTaxLayMethod_0 = "伝票転嫁";
        ///// <summary>明細単位</summary>
        //public static readonly string CST_ConsTaxLayMethod_1 = "明細転嫁";
        ///// <summary>請求親</summary>
        //public static readonly string CST_ConsTaxLayMethod_2 = "請求親";
        ///// <summary>請求子</summary>
        //public static readonly string CST_ConsTaxLayMethod_3 = "請求子";
        ///// <summary>非課税</summary>
        //public static readonly string CST_ConsTaxLayMethod_9 = "非課税";

        ///// <summary>総額表示しない（税抜き）</summary>
        //public static readonly string CST_TotalAmountDispWayCd_0 = "しない(税抜)";
        ///// <summary>総額表示する（税込み）</summary>
        //public static readonly string CST_TotalAmountDispWayCd_1 = "する(税込)";

        ///// <summary>全体設定を参照する</summary>
        //public static readonly string CST_TotalAmntDspWayRef_0 = "全体設定参照";
        ///// <summary>得意先設定を参照する</summary>
        //public static readonly string CST_TotalAmntDspWayRef_1 = "得意先参照";

        ///// <summary>0:税率設定マスタを参照</summary>
        //public static readonly string CST_CustCTaXLayRefCd_0 = "税率設定参照";
        ///// <summary>1:得意先マスタを参照</summary>
        //public static readonly string CST_CustCTaXLayRefCd_1 = "得意先参照";

        ///// <summary>正式取引先</summary>
        //public static readonly string CST_CustomerAttributeDiv_0 = "正式取引先";
        ///// <summary>社内取引先</summary>
        //public static readonly string CST_CustomerAttributeDiv_8 = "社内取引先";
        ///// <summary>諸口口座</summary>
        //public static readonly string CST_CustomerAttributeDiv_9 = "諸口口座";

        ///// <summary>得意先</summary>
        //public static readonly string CST_CustomerDivCd_0 = "得意先";
        ///// <summary>納入先</summary>
        //public static readonly string CST_CustomerDivCd_1 = "納入先";

        ///// <summary>現金</summary>
        //public static readonly string CST_CollectCond_10 = "現金";
        ///// <summary>振込</summary>
        //public static readonly string CST_CollectCond_20 = "振込";
        ///// <summary>小切手</summary>
        //public static readonly string CST_CollectCond_30 = "小切手";
        ///// <summary>手形</summary>
        //public static readonly string CST_CollectCond_40 = "手形";
        ///// <summary>手数料「</summary>
        //public static readonly string CST_CollectCond_50 = "手数料";
        ///// <summary>相殺</summary>
        //public static readonly string CST_CollectCond_60 = "相殺";
        ///// <summary>値引</summary>
        //public static readonly string CST_CollectCond_70 = "値引";
        ///// <summary>その他</summary>
        //public static readonly string CST_CollectCond_80 = "その他";

        ///// <summary>しない</summary>
        //public static readonly string CST_CreditMngCode_0 = "しない";
        ///// <summary>する</summary>
        //public static readonly string CST_CreditMngCode_1 = "する";

        ///// <summary>しない</summary>
        //public static readonly string CST_DepoDelCode_0 = "しない";
        ///// <summary>する</summary>
        //public static readonly string CST_DepoDelCode_1 = "する";

        ///// <summary>売掛なし</summary>
        //public static readonly string CST_AccRecDivCd_0 = "売掛なし";
        ///// <summary>売掛</summary>
        //public static readonly string CST_AccRecDivCd_1 = "売掛";

        ///// <summary>西暦</summary>
        //public static readonly string CST_EraNameCode_0 = "西暦";
        ///// <summary>和暦</summary>
        //public static readonly string CST_EraNameCode_1 = "和暦";

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
        /////// <summary>しない</summary>
        ////public static readonly string CST_CustSlipNoMngCd_0 = "しない";
        /////// <summary>する</summary>
        ////public static readonly string CST_CustSlipNoMngCd_1 = "する";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
        ///// <summary>全体設定参照</summary>
        //public static readonly string CST_CustSlipNoMngCd_0 = "全体設定参照";
        ///// <summary>しない</summary>
        //public static readonly string CST_CustSlipNoMngCd_1 = "しない";
        ///// <summary>する</summary>
        //public static readonly string CST_CustSlipNoMngCd_2 = "する";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
        /////// <summary>純正</summary>
        ////public static readonly string CST_PureCode_0 = "純正";
        /////// <summary>その他</summary>
        ////public static readonly string CST_PureCode_1 = "その他";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 DEL
        /////// <summary>使用しない</summary>
        ////public static readonly string CST_CustomerSlipNoDiv_0 = "使用しない";
        /////// <summary>使用する</summary>
        ////public static readonly string CST_CustomerSlipNoDiv_1 = "使用する";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
        ///// <summary>使用しない</summary>
        //public static readonly string CST_CustomerSlipNoDiv_0 = "使用しない";
        ///// <summary>連番</summary>
        //public static readonly string CST_CustomerSlipNoDiv_1 = "連番";
        ///// <summary>締毎</summary>
        //public static readonly string CST_CustomerSlipNoDiv_2 = "締毎";
        ///// <summary>期末</summary>
        //public static readonly string CST_CustomerSlipNoDiv_3 = "期末";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/04/28 ADD
        ///// <summary>しない</summary>
        //public static readonly string CST_CarMngDivCd_0 = "しない";
        ///// <summary>登録(確認)</summary>
        //public static readonly string CST_CarMngDivCd_1 = "登録(確認)";
        ///// <summary>登録(自動)</summary>
        //public static readonly string CST_CarMngDivCd_2 = "登録(自動)";
        ///// <summary>登録無</summary>
        //public static readonly string CST_CarMngDivCd_3 = "登録無";

        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 DEL
        /////// <summary>しない</summary>
        ////public static readonly string CST_QrcodePrtCd_0 = "しない";
        /////// <summary>する</summary>
        ////public static readonly string CST_QrcodePrtCd_1 = "する";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
        ///// <summary>標準</summary>
        //public static readonly string CST_QrcodePrtCd_0 = "標準";
        ///// <summary>印字しない</summary>
        //public static readonly string CST_QrcodePrtCd_1 = "印字しない";
        ///// <summary>印字する</summary>
        //public static readonly string CST_QrcodePrtCd_2 = "印字する";
        ///// <summary>返品含む</summary>
        //public static readonly string CST_QrcodePrtCd_3 = "返品含む";
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/04/28 ADD
        //// 2010/07/06 Add >>>
        ///// <summary>印字する（携帯メール）</summary>
        //public static readonly string CST_QrcodePrtCd_4 = "印字する（携帯メール）";
        ///// <summary>返品含む（携帯メール）</summary>
        //public static readonly string CST_QrcodePrtCd_5 = "返品含む（携帯メール）";
        //// 2010/07/06 Add <<<

        //// --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
        ///// <summary>標準</summary>
        //public static readonly string CST_PrtDiv_0 = "標準";
        ///// <summary>未使用</summary>
        //public static readonly string CST_PrtDiv_1 = "未使用";
        ///// <summary>使用</summary>
        //public static readonly string CST_PrtDiv_2 = "使用";
        //// --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

        //// ADD 2009/04/07 ------>>>
        ///// <summary>する</summary>
        //public static readonly string CST_ReceiptOutputCode_0 = "する";
        ///// <summary>しない</summary>
        //public static readonly string CST_ReceiptOutputCode_1 = "しない";
        //// ADD 2009/04/07 ------<<<

        //// ADD 2009/06/03 ------>>>
        ///// <summary>なし</summary>
        //public static readonly string CST_OnlineKindDiv_0 = "なし";
        ///// <summary>SCM</summary>
        //public static readonly string CST_OnlineKindDiv_10 = "SCM";
        ///// <summary>TSP.NS</summary>
        //public static readonly string CST_OnlineKindDiv_20 = "TSP.NS";
        ///// <summary>TSP.NSインライン</summary>
        //public static readonly string CST_OnlineKindDiv_30 = "TSP.NSインライン";
        ///// <summary>TSPメール</summary>
        //public static readonly string CST_OnlineKindDiv_40 = "TSPメール";
        //// ADD 2009/06/03 ------<<<
        //// --- ADD  大矢睦美  2010/01/04 ---------->>>>>
        ///// <summary>標準</summary>
        //public static readonly string CST_TotalBillOutputDiv_0 = "標準";
        ///// <summary>使用</summary>
        //public static readonly string CST_TotalBillOutputDiv_1 = "使用";
        ///// <summary>未使用</summary>
        //public static readonly string CST_TotalBillOutputDiv_2 = "未使用";

        ///// <summary>標準</summary>
        //public static readonly string CST_DetailBillOutputCode_0 = "標準";
        ///// <summary>使用</summary>
        //public static readonly string CST_DetailBillOutputCode_1 = "使用";
        ///// <summary>未使用</summary>
        //public static readonly string CST_DetailBillOutputCode_2 = "未使用";

        ///// <summary>標準</summary>
        //public static readonly string CST_SlipTtlBillOutputDiv_0 = "標準";
        ///// <summary>使用</summary>
        //public static readonly string CST_SlipTtlBillOutputDiv_1 = "使用";
        ///// <summary>未使用</summary>
        //public static readonly string CST_SlipTtlBillOutputDiv_2 = "未使用";
        //// --- ADD  大矢睦美  2010/01/04 ----------<<<<<

        //# endregion
        // --- DEL 2010/08/10 ------------------------------------<<<<<

        // --- ADD 2010/08/10 ------------------------------------>>>>>
        # region public static readonly string（手動追加）
        /// <summary>様</summary>
        public static readonly string CST_HonorificTitle_0 = "様";
        /// <summary>殿</summary>
        public static readonly string CST_HonorificTitle_1 = "殿";
        /// <summary>御中</summary>
        public static readonly string CST_HonorificTitle_2 = "御中";
        /// <summary>得意先名称１,２を使用する</summary>
        public static readonly string CST_OutputName_0 = "0:得意先名称１・２";
        /// <summary>得意先名称１を使用する</summary>
        public static readonly string CST_OutputName_1 = "1:得意先名称１";
        /// <summary>得意先名称２を使用する</summary>
        public static readonly string CST_OutputName_2 = "2:得意先名称２";
        /// <summary>諸口名称を使用する</summary>
        public static readonly string CST_OutputName_3 = "3:諸口名称";
        /// <summary>当月</summary>
        public static readonly string CST_CollectMoneyName_0 = "0:当月";
        /// <summary>翌月</summary>
        public static readonly string CST_CollectMoneyName_1 = "1:翌月";
        /// <summary>翌々月</summary>
        public static readonly string CST_CollectMoneyName_2 = "2:翌々月";
        /// <summary>翌々々月</summary>
        public static readonly string CST_CollectMoneyName_3 = "3:翌々々月";
        /// <summary>個人</summary>
        public static readonly string CST_CorporateDivName_0 = "0:個人";
        /// <summary>法人</summary>
        public static readonly string CST_CorporateDivName_1 = "1:法人";
        /// <summary>大口法人</summary>
        public static readonly string CST_CorporateDivName_2 = "2:大口法人";
        /// <summary>業者</summary>
        public static readonly string CST_CorporateDivName_3 = "3:業者";
        /// <summary>社員</summary>
        public static readonly string CST_CorporateDivName_4 = "4:社員";
        /// <summary>する</summary>
        public static readonly string CST_BillOutputName_0 = "0:する";
        /// <summary>しない</summary>
        public static readonly string CST_BillOutputName_1 = "1:しない";
        /// <summary>する</summary>
        public static readonly string CST_DmOutName_0 = "する";
        /// <summary>しない</summary>
        public static readonly string CST_DmOutName_1 = "しない";
        /// <summary>送信しない</summary>
        public static readonly string CST_MailSendName_0 = "0:送信しない";
        /// <summary>送信する</summary>
        public static readonly string CST_MailSendName_1 = "1:送信する";
        /// <summary>自宅</summary>
        public static readonly string CST_MailAddrKindName_0 = "0:自宅";
        /// <summary>会社</summary>
        public static readonly string CST_MailAddrKindName_1 = "1:会社";
        /// <summary>携帯端末</summary>
        public static readonly string CST_MailAddrKindName_2 = "2:携帯端末";
        /// <summary>本人以外</summary>
        public static readonly string CST_MailAddrKindName_3 = "3:本人以外";
        /// <summary>その他</summary>
        public static readonly string CST_MailAddrKindName_99 = "4:その他";
        /// <summary>伝票単位</summary>
        public static readonly string CST_ConsTaxLayMethod_0 = "0:伝票転嫁";
        /// <summary>明細単位</summary>
        public static readonly string CST_ConsTaxLayMethod_1 = "1:明細転嫁";
        /// <summary>請求親</summary>
        public static readonly string CST_ConsTaxLayMethod_2 = "2:請求親";
        /// <summary>請求子</summary>
        public static readonly string CST_ConsTaxLayMethod_3 = "3:請求子";
        /// <summary>非課税</summary>
        public static readonly string CST_ConsTaxLayMethod_9 = "9:非課税";
        /// <summary>総額表示しない（税抜き）</summary>
        public static readonly string CST_TotalAmountDispWayCd_0 = "しない(税抜)";
        /// <summary>総額表示する（税込み）</summary>
        public static readonly string CST_TotalAmountDispWayCd_1 = "する(税込)";
        /// <summary>全体設定を参照する</summary>
        public static readonly string CST_TotalAmntDspWayRef_0 = "全体設定参照";
        /// <summary>得意先設定を参照する</summary>
        public static readonly string CST_TotalAmntDspWayRef_1 = "得意先参照";
        /// <summary>0:税率設定マスタを参照</summary>
        public static readonly string CST_CustCTaXLayRefCd_0 = "0:税率設定参照";
        /// <summary>1:得意先マスタを参照</summary>
        public static readonly string CST_CustCTaXLayRefCd_1 = "1:得意先参照";
        /// <summary>正式取引先</summary>
        public static readonly string CST_CustomerAttributeDiv_0 = "0:正式取引先";
        /// <summary>社内取引先</summary>
        public static readonly string CST_CustomerAttributeDiv_8 = "1:社内取引先";
        /// <summary>諸口口座</summary>
        public static readonly string CST_CustomerAttributeDiv_9 = "2:諸口口座";
        /// <summary>得意先</summary>
        public static readonly string CST_CustomerDivCd_0 = "0:得意先";
        /// <summary>納入先</summary>
        public static readonly string CST_CustomerDivCd_1 = "1:納入先";
        /// <summary>現金</summary>
        public static readonly string CST_CollectCond_10 = "現金";
        /// <summary>振込</summary>
        public static readonly string CST_CollectCond_20 = "振込";
        /// <summary>小切手</summary>
        public static readonly string CST_CollectCond_30 = "小切手";
        /// <summary>手形</summary>
        public static readonly string CST_CollectCond_40 = "手形";
        /// <summary>手数料「</summary>
        public static readonly string CST_CollectCond_50 = "手数料";
        /// <summary>相殺</summary>
        public static readonly string CST_CollectCond_60 = "相殺";
        /// <summary>値引</summary>
        public static readonly string CST_CollectCond_70 = "値引";
        /// <summary>その他</summary>
        public static readonly string CST_CollectCond_80 = "その他";
        /// <summary>しない</summary>
        public static readonly string CST_CreditMngCode_0 = "0:しない";
        /// <summary>する</summary>
        public static readonly string CST_CreditMngCode_1 = "1:する";
        /// <summary>しない</summary>
        public static readonly string CST_DepoDelCode_0 = "0:しない";
        /// <summary>する</summary>
        public static readonly string CST_DepoDelCode_1 = "1:する";
        /// <summary>売掛なし</summary>
        public static readonly string CST_AccRecDivCd_0 = "0:売掛なし";
        /// <summary>売掛</summary>
        public static readonly string CST_AccRecDivCd_1 = "1:売掛";
        /// <summary>西暦</summary>
        public static readonly string CST_EraNameCode_0 = "西暦";
        /// <summary>和暦</summary>
        public static readonly string CST_EraNameCode_1 = "和暦";
        /// <summary>全体設定参照</summary>
        public static readonly string CST_CustSlipNoMngCd_0 = "0:全体設定参照";
        /// <summary>しない</summary>
        public static readonly string CST_CustSlipNoMngCd_1 = "1:しない";
        /// <summary>する</summary>
        public static readonly string CST_CustSlipNoMngCd_2 = "2:する";
        /// <summary>使用しない</summary>
        public static readonly string CST_CustomerSlipNoDiv_0 = "0:使用しない";
        /// <summary>連番</summary>
        public static readonly string CST_CustomerSlipNoDiv_1 = "1:連番";
        /// <summary>締毎</summary>
        public static readonly string CST_CustomerSlipNoDiv_2 = "2:締毎";
        /// <summary>期末</summary>
        public static readonly string CST_CustomerSlipNoDiv_3 = "3:期末";
        /// <summary>しない</summary>
        public static readonly string CST_CarMngDivCd_0 = "0:しない";
        /// <summary>登録(確認)</summary>
        public static readonly string CST_CarMngDivCd_1 = "1:登録(確認)";
        /// <summary>登録(自動)</summary>
        public static readonly string CST_CarMngDivCd_2 = "2:登録(自動)";
        /// <summary>登録無</summary>
        public static readonly string CST_CarMngDivCd_3 = "3:登録無";
        /// <summary>標準</summary>
        public static readonly string CST_QrcodePrtCd_0 = "0:標準";
        /// <summary>印字しない</summary>
        public static readonly string CST_QrcodePrtCd_1 = "1:印字しない";
        /// <summary>印字する</summary>
        public static readonly string CST_QrcodePrtCd_2 = "2:印字する";
        /// <summary>返品含む</summary>
        public static readonly string CST_QrcodePrtCd_3 = "3:返品含む";
        /// <summary>印字する（携帯メール）</summary>
        public static readonly string CST_QrcodePrtCd_4 = "4:印字する（携帯メール）";
        /// <summary>返品含む（携帯メール）</summary>
        public static readonly string CST_QrcodePrtCd_5 = "5:返品含む（携帯メール）";
        /// <summary>標準</summary>
        public static readonly string CST_PrtDiv_0 = "0:標準";
        /// <summary>未使用</summary>
        public static readonly string CST_PrtDiv_1 = "1:未使用";
        /// <summary>使用</summary>
        public static readonly string CST_PrtDiv_2 = "2:使用";
        /// <summary>する</summary>
        public static readonly string CST_ReceiptOutputCode_0 = "0:する";
        /// <summary>しない</summary>
        public static readonly string CST_ReceiptOutputCode_1 = "1:しない";
        /// <summary>なし</summary>
        public static readonly string CST_OnlineKindDiv_0 = "0:なし";
        /// <summary>SCM</summary>
        //public static readonly string CST_OnlineKindDiv_10 = "1:SCM"; // 2011/06/09
        public static readonly string CST_OnlineKindDiv_10 = "1:PCC"; // 2011/06/09
        /// <summary>TSP.NS</summary>
        public static readonly string CST_OnlineKindDiv_20 = "20:TSP.NS";
        /// <summary>TSP.NSインライン</summary>
        public static readonly string CST_OnlineKindDiv_30 = "30:TSP.NSインライン";
        /// <summary>TSPメール</summary>
        public static readonly string CST_OnlineKindDiv_40 = "40:TSPメール";
        /// <summary>標準</summary>
        public static readonly string CST_TotalBillOutputDiv_0 = "0:標準";
        /// <summary>使用</summary>
        public static readonly string CST_TotalBillOutputDiv_1 = "1:使用";
        /// <summary>未使用</summary>
        public static readonly string CST_TotalBillOutputDiv_2 = "2:未使用";
        /// <summary>標準</summary>
        public static readonly string CST_DetailBillOutputCode_0 = "0:標準";
        /// <summary>使用</summary>
        public static readonly string CST_DetailBillOutputCode_1 = "1:使用";
        /// <summary>未使用</summary>
        public static readonly string CST_DetailBillOutputCode_2 = "2:未使用";
        /// <summary>標準</summary>
        public static readonly string CST_SlipTtlBillOutputDiv_0 = "0:標準";
        /// <summary>使用</summary>
        public static readonly string CST_SlipTtlBillOutputDiv_1 = "1:使用";
        /// <summary>未使用</summary>
        public static readonly string CST_SlipTtlBillOutputDiv_2 = "2:未使用";

        # endregion
        // --- ADD 2010/08/10 ------------------------------------<<<<<

        # region [private フィールド（★自動生成）得意先マスタ メンバ]
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = string.Empty;

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = string.Empty;

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = string.Empty;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>得意先コード</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private Int32 _customerCode;

        /// <summary>得意先サブコード</summary>
        private string _customerSubCode = string.Empty;

        /// <summary>名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _name = string.Empty;

        /// <summary>名称2</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _name2 = string.Empty;

        /// <summary>敬称</summary>
        private string _honorificTitle = string.Empty;

        /// <summary>カナ</summary>
        private string _kana = string.Empty;

        /// <summary>得意先略称</summary>
        private string _customerSnm = string.Empty;

        /// <summary>諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _outputNameCode;

        /// <summary>諸口名称</summary>
        private string _outputName = string.Empty;

        /// <summary>個人・法人区分</summary>
        /// <remarks>0:個人,1:法人,2:大口法人,3:業者,4:社員</remarks>
        private Int32 _corporateDivCode;

        /// <summary>得意先属性区分</summary>
        /// <remarks>0:正式取引先,8:社内取引先,9:諸口口座</remarks>
        private Int32 _customerAttributeDiv;

        /// <summary>職種コード</summary>
        private Int32 _jobTypeCode;

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _postNo = string.Empty;

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address1 = string.Empty;

        /// <summary>住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address3 = string.Empty;

        /// <summary>住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address4 = string.Empty;

        /// <summary>電話番号（自宅）</summary>
        /// <remarks>ハイフンを含めた16桁の番号</remarks>
        private string _homeTelNo = string.Empty;

        /// <summary>電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _officeTelNo = string.Empty;

        /// <summary>電話番号（携帯）</summary>
        private string _portableTelNo = string.Empty;

        /// <summary>FAX番号（自宅）</summary>
        private string _homeFaxNo = string.Empty;

        /// <summary>FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _officeFaxNo = string.Empty;

        /// <summary>電話番号（その他）</summary>
        private string _othersTelNo = string.Empty;

        /// <summary>主連絡先区分</summary>
        /// <remarks>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</remarks>
        private Int32 _mainContactCode;

        /// <summary>電話番号（検索用下4桁）</summary>
        private string _searchTelNo = string.Empty;

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = string.Empty;

        /// <summary>入力拠点コード</summary>
        private string _inpSectionCode = string.Empty;

        /// <summary>得意先分析コード1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード6</summary>
        private Int32 _custAnalysCode6;

        /// <summary>請求書出力区分コード</summary>
        /// <remarks>0:請求書発行する,1:しない</remarks>
        private Int32 _billOutputCode;

        /// <summary>請求書出力区分名称</summary>
        private string _billOutputName = string.Empty;

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>集金月区分コード</summary>
        /// <remarks>0:当月,1:翌月,2:翌々月</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _collectMoneyName = string.Empty;

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>回収条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _collectCond;

        /// <summary>回収サイト</summary>
        /// <remarks>手形サイト　180等</remarks>
        private Int32 _collectSight;

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先。納入先の場合の使用可能項目</remarks>
        private Int32 _claimCode;

        /// <summary>取引中止日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _transStopDate;

        /// <summary>DM出力区分</summary>
        /// <remarks>0:出力する,1:出力しない</remarks>
        private Int32 _dmOutCode;

        /// <summary>DM出力区分名称</summary>
        /// <remarks>全角で管理</remarks>
        private string _dmOutName = string.Empty;

        /// <summary>主送信先メールアドレス区分</summary>
        /// <remarks>0:メールアドレス1,1:メールアドレス2</remarks>
        private Int32 _mainSendMailAddrCd;

        /// <summary>メールアドレス種別コード1</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>メールアドレス種別名称1</summary>
        private string _mailAddrKindName1 = string.Empty;

        /// <summary>メールアドレス1</summary>
        private string _mailAddress1 = string.Empty;

        /// <summary>メール送信区分コード1</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode1;

        /// <summary>メール送信区分名称1</summary>
        private string _mailSendName1 = string.Empty;

        /// <summary>メールアドレス種別コード2</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>メールアドレス種別名称2</summary>
        private string _mailAddrKindName2 = string.Empty;

        /// <summary>メールアドレス2</summary>
        private string _mailAddress2 = string.Empty;

        /// <summary>メール送信区分コード2</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode2;

        /// <summary>メール送信区分名称2</summary>
        private string _mailSendName2 = string.Empty;

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = string.Empty;

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = string.Empty;

        /// <summary>旧顧客担当従業員コード</summary>
        private string _oldCustomerAgentCd = string.Empty;

        /// <summary>顧客担当変更日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _custAgentChgDate;

        /// <summary>業販先区分</summary>
        /// <remarks>0:業販先以外,1:業販先,2:納入先</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>与信管理区分</summary>
        private Int32 _creditMngCode;

        /// <summary>入金消込区分</summary>
        /// <remarks>PM(0:しない,1:する) G/D( 0:しない,1:する(請求別),2:する(納品別)）</remarks>
        private Int32 _depoDelCode;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>相手伝票番号管理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _custSlipNoMngCd;

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:その他（PMは優良）　</remarks>
        private Int32 _pureCode;

        /// <summary>得意先消費税転嫁方式参照区分</summary>
        /// <remarks>0:税率設定マスタを参照　1:得意先マスタを参照</remarks>
        private Int32 _custCTaXLayRefCd;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>総額表示方法参照区分</summary>
        /// <remarks>0:全体設定参照 1:得意先参照</remarks>
        private Int32 _totalAmntDspWayRef;

        /// <summary>銀行口座1</summary>
        private string _accountNoInfo1 = string.Empty;

        /// <summary>銀行口座2</summary>
        private string _accountNoInfo2 = string.Empty;

        /// <summary>銀行口座3</summary>
        private string _accountNoInfo3 = string.Empty;

        /// <summary>売上単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>売上金額端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesMoneyFrcProcCd;

        /// <summary>売上消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>得意先伝票番号区分</summary>
        /// <remarks>0:使用しない　1:使用する</remarks>
        private Int32 _customerSlipNoDiv;

        /// <summary>次回勘定開始日</summary>
        /// <remarks>01～31まで（省略可能）</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>得意先担当者</summary>
        /// <remarks>得意先（仕入先）の問い合わせ先社員名</remarks>
        private string _customerAgent = string.Empty;

        /// <summary>請求拠点コード</summary>
        /// <remarks>請求を行う拠点</remarks>
        private string _claimSectionCode = string.Empty;

        /// <summary>車輌管理区分</summary>
        /// <remarks>0:しない、1:登録(確認)、2:登録(自動) 3:登録無</remarks>
        private Int32 _carMngDivCd;

        /// <summary>品番印字区分(請求書)</summary>
        /// <remarks>0:商品マスタ、1:有、2:無</remarks>
        private Int32 _billPartsNoPrtCd;

        /// <summary>品番印字区分(納品書）</summary>
        /// <remarks>0:商品マスタ、1:有、2:無</remarks>
        private Int32 _deliPartsNoPrtCd;

        /// <summary>伝票区分初期値</summary>
        private Int32 _defSalesSlipCd;

        /// <summary>工賃レバレートランク</summary>
        private Int32 _lavorRateRank;

        /// <summary>伝票タイトルパターン</summary>
        /// <remarks>0000:未設定、0100:基本タイトル、0200・・</remarks>
        private Int32 _slipTtlPrn;

        /// <summary>入金銀行コード</summary>
        private Int32 _depoBankCode;

        /// <summary>得意先優先倉庫コード</summary>
        private String _custWarehouseCd;

        /// <summary>QRコード印刷</summary>
        private Int32 _qrcodePrtCd;

        /// <summary>納品書敬称</summary>
        /// <remarks>納品書用の敬称</remarks>
        private string _deliHonorificTtl = string.Empty;

        /// <summary>請求書敬称</summary>
        /// <remarks>請求書用の敬称</remarks>
        private string _billHonorificTtl = string.Empty;

        /// <summary>見積書敬称</summary>
        /// <remarks>見積書用の敬称</remarks>
        private string _estmHonorificTtl = string.Empty;

        /// <summary>領収書敬称</summary>
        /// <remarks>領収書用の敬称</remarks>
        private string _rectHonorificTtl = string.Empty;

        /// <summary>納品書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _deliHonorTtlPrtDiv;

        /// <summary>請求書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _billHonorTtlPrtDiv;

        /// <summary>見積書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _estmHonorTtlPrtDiv;

        /// <summary>領収書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _rectHonorTtlPrtDiv;

        /// <summary>備考1</summary>
        private string _note1 = string.Empty;

        /// <summary>備考2</summary>
        private string _note2 = string.Empty;

        /// <summary>備考3</summary>
        private string _note3 = string.Empty;

        /// <summary>備考4</summary>
        private string _note4 = string.Empty;

        /// <summary>備考5</summary>
        private string _note5 = string.Empty;

        /// <summary>備考6</summary>
        private string _note6 = string.Empty;

        /// <summary>備考7</summary>
        private string _note7 = string.Empty;

        /// <summary>備考8</summary>
        private string _note8 = string.Empty;

        /// <summary>備考9</summary>
        private string _note9 = string.Empty;

        /// <summary>備考10</summary>
        private string _note10 = string.Empty;

        /// <summary>企業名称</summary>
        private string _enterpriseName = string.Empty;

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = string.Empty;

        /// <summary>職種名称</summary>
        private string _jobTypeName = string.Empty;

        /// <summary>業種名称</summary>
        private string _businessTypeName = string.Empty;

        /// <summary>入力拠点名称</summary>
        private string _inpSectionName = string.Empty;

        /// <summary>請求書出力区分名称</summary>
        /// <remarks>請求書発行する,しない</remarks>
        private string _billOutPutCodeNm = string.Empty;

        /// <summary>集金担当従業員名称</summary>
        private string _billCollecterNm = string.Empty;

        // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
        /// <summary>納品書出力区分</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>受注伝票出力区分</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>貸出伝票出力区分</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private Int32 _shipmSlipPrtDiv;

        /// <summary>見積伝票出力区分</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private Int32 _estimatePrtDiv;

        /// <summary>UOE伝票出力区分</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private Int32 _uoeSlipPrtDiv;
        // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

        // ADD 2009/04/07 ------>>>
        /// <summary>領収書出力区分コード</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _receiptOutputCode;
        // ADD 2009/04/07 ------<<<

        // ADD 2009/06/03 ------>>>
        /// <summary>得意先企業コード</summary>
        private string _customerEpCode = string.Empty;

        /// <summary>得意先拠点コード</summary>
        private string _customerSecCode = string.Empty;

        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
        /// <summary>簡単問合せアカウントグループID</summary>
        private string _simplInqAcntAcntGrId = string.Empty;
        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<

        /// <summary>オンライン種別区分</summary>
        /// <remarks>0:なし 10:SCM 20:TSP.NS 30:TSP.NSインライン 40:TSP</remarks>
        private Int32 _onlineKindDiv;
        // ADD 2009/06/03 ------<<<
        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
        /// <summary>合計請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>明細請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>伝票合計請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _slipTtlBillOutputDiv;
        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
        
        # endregion

        # region [private フィールド（手動追加）ＵＩ用メンバ]
        /// <summary>個人・法人区分名称</summary>
        private string _prslOrCorpDivNm = string.Empty;

        /// <summary>主連絡先区分名称</summary>
        /// <remarks>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</remarks>
        private string _mainContactName = string.Empty;

        /// <summary>自宅TEL表示名称</summary>
        private string _homeTelNoDspName = string.Empty;

        /// <summary>勤務先TEL表示名称</summary>
        private string _officeTelNoDspName = string.Empty;

        /// <summary>携帯TEL表示名称</summary>
        private string _mobileTelNoDspName = string.Empty;

        /// <summary>その他TEL表示名称</summary>
        private string _otherTelNoDspName = string.Empty;

        /// <summary>自宅FAX表示名称</summary>
        private string _homeFaxNoDspName = string.Empty;

        /// <summary>勤務先FAX表示名称</summary>
        private string _officeFaxNoDspName = string.Empty;
        # endregion

        # region [private フィールド（手動追加）コードに対する名称]
        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = string.Empty;

        /// <summary>請求先名称</summary>
        private string _claimName = string.Empty;

        /// <summary>請求先名称２</summary>
        private string _claimName2 = string.Empty;

        /// <summary>請求先略称</summary>
        private string _claimSnm = string.Empty;

        /// <summary>顧客担当従業員名称</summary>
        private string _customerAgentNm = string.Empty;

        /// <summary>旧顧客担当従業員名称</summary>
        private string _oldCustomerAgentNm = string.Empty;

        /// <summary>請求拠点名称</summary>
        private string _claimSectionName = string.Empty;

        /// <summary>入金銀行名称</summary>
        private string _depoBankName = string.Empty;

        /// <summary>得意先優先倉庫名称</summary>
        private string _custWarehouseName = string.Empty;

        /// <summary>管理拠点名称</summary>
        private string _mngSectionName = string.Empty;
        // ADD 陳健 K2014/02/06 ------------------------------>>>>>>
        /// <summary>メモ</summary>
        private string _noteInfo = string.Empty;
        // ADD 陳健 K2014/02/06 ------------------------------<<<<<<
        // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
        /// <summary>得意先情報ガイド表示</summary>
        /// <remarks>0:表示あり 1:表示なし</remarks>
        private Int32 _DisplayDivCode;
        // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
        # endregion

        // パブリックプロパティ群
        // ※「得意先マスタ メンバー」のプロパティのうち、CollectMoneyCode, BillOutputCode, DmOutCodeについては
        //   コードset時に対応するNameにも値を入れるように変更しています。
        //   （Nameの取り得る値が本クラスにて定義されているので、Codeの値が決定するとNameも一意に決まる為）

		# region [プロパティ（★自動生成）得意先マスタ メンバ]
        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSubCode
        /// <summary>得意先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>名称2プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  OutputNameCode
        /// <summary>諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>諸口名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CorporateDivCode
        /// <summary>個人・法人区分プロパティ</summary>
        /// <value>0:個人,1:法人,2:大口法人,3:業者,4:社員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   個人・法人区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CorporateDivCode
        {
            get { return _corporateDivCode; }
            set { _corporateDivCode = value; }
        }

        /// public propaty name  :  CustomerAttributeDiv
        /// <summary>得意先属性区分プロパティ</summary>
        /// <value>0:正式取引先,8:社内取引先,9:諸口口座</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先属性区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerAttributeDiv
        {
            get { return _customerAttributeDiv; }
            set { _customerAttributeDiv = value; }
        }

        /// public propaty name  :  JobTypeCode
        /// <summary>職種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   職種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JobTypeCode
        {
            get { return _jobTypeCode; }
            set { _jobTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>電話番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  OthersTelNo
        /// <summary>電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OthersTelNo
        {
            get { return _othersTelNo; }
            set { _othersTelNo = value; }
        }

        /// public propaty name  :  MainContactCode
        /// <summary>主連絡先区分プロパティ</summary>
        /// <value>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主連絡先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainContactCode
        {
            get { return _mainContactCode; }
            set { _mainContactCode = value; }
        }

        /// public propaty name  :  SearchTelNo
        /// <summary>電話番号（検索用下4桁）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（検索用下4桁）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>入力拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  BillOutputCode
        /// <summary>請求書出力区分コードプロパティ</summary>
        /// <value>0:請求書発行する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillOutputCode
        {
            get { return _billOutputCode; }
            set { _billOutputCode = value; }
        }

        /// public propaty name  :  BillOutputName
        /// <summary>請求書出力区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillOutputName
        {
            get { return _billOutputName; }
            set { _billOutputName = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>集金月区分コードプロパティ</summary>
        /// <value>0:当月,1:翌月,2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>回収条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  CollectSight
        /// <summary>回収サイトプロパティ</summary>
        /// <value>手形サイト　180等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収サイトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectSight
        {
            get { return _collectSight; }
            set { _collectSight = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先得意先。納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  TransStopDate
        /// <summary>取引中止日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TransStopDate
        {
            get { return _transStopDate; }
            set { _transStopDate = value; }
        }

        /// public propaty name  :  DmOutCode
        /// <summary>DM出力区分プロパティ</summary>
        /// <value>0:出力する,1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmOutCode
        {
            get { return _dmOutCode; }
            set { _dmOutCode = value; }
        }

        /// public propaty name  :  DmOutName
        /// <summary>DM出力区分名称プロパティ</summary>
        /// <value>全角で管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM出力区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DmOutName
        {
            get { return _dmOutName; }
            set { _dmOutName = value; }
        }

        /// public propaty name  :  MainSendMailAddrCd
        /// <summary>主送信先メールアドレス区分プロパティ</summary>
        /// <value>0:メールアドレス1,1:メールアドレス2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主送信先メールアドレス区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainSendMailAddrCd
        {
            get { return _mainSendMailAddrCd; }
            set { _mainSendMailAddrCd = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>メールアドレス種別コード1プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>メールアドレス種別名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>メールアドレス1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>メール送信区分コード1プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailSendName1
        /// <summary>メール送信区分名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailSendName1
        {
            get { return _mailSendName1; }
            set { _mailSendName1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>メールアドレス種別コード2プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>メールアドレス種別名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>メールアドレス2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>メール送信区分コード2プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }

        /// public propaty name  :  MailSendName2
        /// <summary>メール送信区分名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailSendName2
        {
            get { return _mailSendName2; }
            set { _mailSendName2 = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentCd
        /// <summary>旧顧客担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldCustomerAgentCd
        {
            get { return _oldCustomerAgentCd; }
            set { _oldCustomerAgentCd = value; }
        }

        /// public propaty name  :  CustAgentChgDate
        /// <summary>顧客担当変更日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CustAgentChgDate
        {
            get { return _custAgentChgDate; }
            set { _custAgentChgDate = value; }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>業販先区分プロパティ</summary>
        /// <value>0:業販先以外,1:業販先,2:納入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業販先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  CreditMngCode
        /// <summary>与信管理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  DepoDelCode
        /// <summary>入金消込区分プロパティ</summary>
        /// <value>PM(0:しない,1:する) G/D( 0:しない,1:する(請求別),2:する(納品別)）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金消込区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepoDelCode
        {
            get { return _depoDelCode; }
            set { _depoDelCode = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  CustSlipNoMngCd
        /// <summary>相手伝票番号管理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手伝票番号管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipNoMngCd
        {
            get { return _custSlipNoMngCd; }
            set { _custSlipNoMngCd = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:その他（PMは優良）　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  CustCTaXLayRefCd
        /// <summary>得意先消費税転嫁方式参照区分プロパティ</summary>
        /// <value>0:税率設定マスタを参照　1:得意先マスタを参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先消費税転嫁方式参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustCTaXLayRefCd
        {
            get { return _custCTaXLayRefCd; }
            set { _custCTaXLayRefCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TotalAmntDspWayRef
        /// <summary>総額表示方法参照区分プロパティ</summary>
        /// <value>0:全体設定参照 1:得意先参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmntDspWayRef
        {
            get { return _totalAmntDspWayRef; }
            set { _totalAmntDspWayRef = value; }
        }

        /// public propaty name  :  AccountNoInfo1
        /// <summary>銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo1
        {
            get { return _accountNoInfo1; }
            set { _accountNoInfo1 = value; }
        }

        /// public propaty name  :  AccountNoInfo2
        /// <summary>銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo2
        {
            get { return _accountNoInfo2; }
            set { _accountNoInfo2 = value; }
        }

        /// public propaty name  :  AccountNoInfo3
        /// <summary>銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo3
        {
            get { return _accountNoInfo3; }
            set { _accountNoInfo3 = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>売上単価端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesMoneyFrcProcCd
        /// <summary>売上金額端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesMoneyFrcProcCd
        {
            get { return _salesMoneyFrcProcCd; }
            set { _salesMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>売上消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>得意先伝票番号区分プロパティ</summary>
        /// <value>0:使用しない　1:使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先伝票番号区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>次回勘定開始日プロパティ</summary>
        /// <value>01～31まで（省略可能）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   次回勘定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  CustomerAgent
        /// <summary>得意先担当者プロパティ</summary>
        /// <value>得意先（仕入先）の問い合わせ先社員名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgent
        {
            get { return _customerAgent; }
            set { _customerAgent = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>請求拠点コードプロパティ</summary>
        /// <value>請求を行う拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  CarMngDivCd
        /// <summary>車輌管理区分プロパティ</summary>
        /// <value>0:しない、1:登録(確認)、2:登録(自動) 3:登録無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }

        /// public propaty name  :  BillPartsNoPrtCd
        /// <summary>品番印字区分(請求書)プロパティ</summary>
        /// <value>0:商品マスタ、1:有、2:無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分(請求書)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillPartsNoPrtCd
        {
            get { return _billPartsNoPrtCd; }
            set { _billPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DeliPartsNoPrtCd
        /// <summary>品番印字区分(納品書）プロパティ</summary>
        /// <value>0:商品マスタ、1:有、2:無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分(納品書）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliPartsNoPrtCd
        {
            get { return _deliPartsNoPrtCd; }
            set { _deliPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DefSalesSlipCd
        /// <summary>伝票区分初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefSalesSlipCd
        {
            get { return _defSalesSlipCd; }
            set { _defSalesSlipCd = value; }
        }

        /// public propaty name  :  LavorRateRank
        /// <summary>工賃レバレートランクプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   工賃レバレートランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LavorRateRank
        {
            get { return _lavorRateRank; }
            set { _lavorRateRank = value; }
        }

        /// public propaty name  :  SlipTtlPrn
        /// <summary>伝票タイトルパターンプロパティ</summary>
        /// <value>0000:未設定、0100:基本タイトル、0200・・</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票タイトルパターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipTtlPrn
        {
            get { return _slipTtlPrn; }
            set { _slipTtlPrn = value; }
        }

        /// public propaty name  :  DepoBankCode
        /// <summary>入金銀行コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金銀行コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepoBankCode
        {
            get { return _depoBankCode; }
            set { _depoBankCode = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>得意先優先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先優先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  QrcodePrtCd
        /// <summary>QRコード印刷プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QRコード印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 QrcodePrtCd
        {
            get { return _qrcodePrtCd; }
            set { _qrcodePrtCd = value; }
        }

        /// public propaty name  :  DeliHonorificTtl
        /// <summary>納品書敬称プロパティ</summary>
        /// <value>納品書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliHonorificTtl
        {
            get { return _deliHonorificTtl; }
            set { _deliHonorificTtl = value; }
        }

        /// public propaty name  :  BillHonorificTtl
        /// <summary>請求書敬称プロパティ</summary>
        /// <value>請求書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillHonorificTtl
        {
            get { return _billHonorificTtl; }
            set { _billHonorificTtl = value; }
        }

        /// public propaty name  :  EstmHonorificTtl
        /// <summary>見積書敬称プロパティ</summary>
        /// <value>見積書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstmHonorificTtl
        {
            get { return _estmHonorificTtl; }
            set { _estmHonorificTtl = value; }
        }

        /// public propaty name  :  RectHonorificTtl
        /// <summary>領収書敬称プロパティ</summary>
        /// <value>領収書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RectHonorificTtl
        {
            get { return _rectHonorificTtl; }
            set { _rectHonorificTtl = value; }
        }

        /// public propaty name  :  DeliHonorTtlPrtDiv
        /// <summary>納品書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliHonorTtlPrtDiv
        {
            get { return _deliHonorTtlPrtDiv; }
            set { _deliHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  BillHonorTtlPrtDiv
        /// <summary>請求書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillHonorTtlPrtDiv
        {
            get { return _billHonorTtlPrtDiv; }
            set { _billHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  EstmHonorTtlPrtDiv
        /// <summary>見積書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstmHonorTtlPrtDiv
        {
            get { return _estmHonorTtlPrtDiv; }
            set { _estmHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  RectHonorTtlPrtDiv
        /// <summary>領収書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RectHonorTtlPrtDiv
        {
            get { return _rectHonorTtlPrtDiv; }
            set { _rectHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  Note1
        /// <summary>備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note1
        {
            get { return _note1; }
            set { _note1 = value; }
        }

        /// public propaty name  :  Note2
        /// <summary>備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note2
        {
            get { return _note2; }
            set { _note2 = value; }
        }

        /// public propaty name  :  Note3
        /// <summary>備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note3
        {
            get { return _note3; }
            set { _note3 = value; }
        }

        /// public propaty name  :  Note4
        /// <summary>備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note4
        {
            get { return _note4; }
            set { _note4 = value; }
        }

        /// public propaty name  :  Note5
        /// <summary>備考5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note5
        {
            get { return _note5; }
            set { _note5 = value; }
        }

        /// public propaty name  :  Note6
        /// <summary>備考6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note6
        {
            get { return _note6; }
            set { _note6 = value; }
        }

        /// public propaty name  :  Note7
        /// <summary>備考7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note7
        {
            get { return _note7; }
            set { _note7 = value; }
        }

        /// public propaty name  :  Note8
        /// <summary>備考8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note8
        {
            get { return _note8; }
            set { _note8 = value; }
        }

        /// public propaty name  :  Note9
        /// <summary>備考9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note9
        {
            get { return _note9; }
            set { _note9 = value; }
        }

        /// public propaty name  :  Note10
        /// <summary>備考10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note10
        {
            get { return _note10; }
            set { _note10 = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  JobTypeName
        /// <summary>職種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   職種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  InpSectionName
        /// <summary>入力拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  BillOutPutCodeNm
        /// <summary>請求書出力区分名称プロパティ</summary>
        /// <value>請求書発行する,しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillOutPutCodeNm
        {
            get { return _billOutPutCodeNm; }
            set { _billOutPutCodeNm = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>集金担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>納品書出力区分プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>受注伝票出力区分プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  ShipmSlipPrtDiv
        /// <summary>貸出伝票出力区分プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmSlipPrtDiv
        {
            get { return _shipmSlipPrtDiv; }
            set { _shipmSlipPrtDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>見積伝票出力区分プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE伝票出力区分プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uoeSlipPrtDiv; }
            set { _uoeSlipPrtDiv = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>領収書出力区分コードプロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書出力区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceiptOutputCode
        {
            get { return _receiptOutputCode; }
            set { _receiptOutputCode = value; }
        }

        // ADD 2009/06/03 ------>>>
        /// public propaty name  :  CustomerEpCode
        /// <summary>得意先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>得意先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }

        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
        /// public propaty name  :  SimplInqAcntAcntGrId
        /// <summary>簡単問合せアカウントグループIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せアカウントグループIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SimplInqAcntAcntGrId
        {
            get { return _simplInqAcntAcntGrId; }
            set { _simplInqAcntAcntGrId = value; }
        }
        // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<

        /// public propaty name  :  OnlineKindDiv
        /// <summary>オンライン種別区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン種別区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
        // ADD 2009/06/03 ------<<<
        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>合計請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>明細請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>伝票合計請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }
        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<


        # endregion

        # region [プロパティ（手動追加）ＵＩ用メンバ]
        /// public propaty name  :  PrslOrCorpDivNm
        /// <summary>個人・法人区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   個人・法人区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrslOrCorpDivNm
        {
            get { return _prslOrCorpDivNm; }
            set { _prslOrCorpDivNm = value; }
        }

        /// public propaty name  :  PrslOrCorpDivNm
        /// <summary>主連絡先区分名称プロパティ</summary>
        /// <value>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主連絡先区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MainContactName
        {
            get { return _mainContactName; }
            set { _mainContactName = value; }
        }

        /// public propaty name  :  HomeTelNoDspName
        /// <summary>自宅TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自宅TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNoDspName
        {
            get { return _homeTelNoDspName; }
            set { _homeTelNoDspName = value; }
        }

        /// public propaty name  :  OfficeTelNoDspName
        /// <summary>勤務先TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   勤務先TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNoDspName
        {
            get { return _officeTelNoDspName; }
            set { _officeTelNoDspName = value; }
        }

        /// public propaty name  :  MobileTelNoDspName
        /// <summary>携帯TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   携帯TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MobileTelNoDspName
        {
            get { return _mobileTelNoDspName; }
            set { _mobileTelNoDspName = value; }
        }

        /// public propaty name  :  OtherTelNoDspName
        /// <summary>その他TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   その他TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OtherTelNoDspName
        {
            get { return _otherTelNoDspName; }
            set { _otherTelNoDspName = value; }
        }

        /// public propaty name  :  HomeFaxNoDspName
        /// <summary>自宅FAX表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自宅FAX表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNoDspName
        {
            get { return _homeFaxNoDspName; }
            set { _homeFaxNoDspName = value; }
        }

        /// public propaty name  :  OfficeFaxNoDspName
        /// <summary>勤務先FAX表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   勤務先FAX表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNoDspName
        {
            get { return _officeFaxNoDspName; }
            set { _officeFaxNoDspName = value; }
        }
        # endregion

        # region [プロパティ（手動追加）コードに対する名称]
        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>請求先名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  OldCustomerAgentNm
        /// <summary>旧顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldCustomerAgentNm
        {
            get { return _oldCustomerAgentNm; }
            set { _oldCustomerAgentNm = value; }
        }

        /// public propaty name  :  ClaimSectionName
        /// <summary>請求拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionName
        {
            get { return _claimSectionName; }
            set { _claimSectionName = value; }
        }

        /// public propaty name  :  DepoBankName
        /// <summary>入金銀行名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金銀行名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepoBankName
        {
            get { return _depoBankName; }
            set { _depoBankName = value; }
        }

        /// public propaty name  :  CustWarehouseName
        /// <summary>得意先優先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先優先倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustWarehouseName
        {
            get { return _custWarehouseName; }
            set { _custWarehouseName = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>管理拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }
        # endregion

        #region [プロパティ（手動追加）外部公開用 メンバ]
        /// <summary>
        /// 得意先　判定プロパティ
        /// </summary>
        public bool IsCustomer
        {
            get {
                return (this.AcceptWholeSale == 1);
            }
        }
        /// <summary>
        /// 納入先　判定プロパティ
        /// </summary>
        public bool IsReceiver
        {
            get {
                return (this.AcceptWholeSale == 2);
            }
        }

        // ADD 陳健 K2014/02/06 ------------------------------>>>>>>
        /// <summary>
        /// メモ
        /// </summary>
        public string NoteInfo
        {
            get
            {
                return this._noteInfo;
            }
            set
            {
                this._noteInfo = value;
            }
        }
        // ADD 陳健 K2014/02/06 ------------------------------<<<<<<
        // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
        /// <summary>
        /// 得意先情報ガイド表示
        /// </summary>
        public Int32 DisplayDivCode
        {
            get { return _DisplayDivCode; }
            set { _DisplayDivCode = value; }
        }
        // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
        #endregion

        # region [コンストラクタ（手動追加）]
		/// <summary>
		/// 得意先マスタコンストラクタ
		/// </summary>
		/// <returns>Customerクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   Customerクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CustomerInfo()
		{
			// 企業コードを初期設定
			this._enterpriseCode =  LoginInfoAcquisition.EnterpriseCode;

			// デフォルト値設定
			this.OutputNameCode = 0;
			this.CollectMoneyCode = 0;
			this.BillOutputCode = 0;
			this.DmOutCode = 0;
			//this.SexCode = 0;
			this.CorporateDivCode = 0;
			this.MainContactCode = 0;
			this.MailSendCode1 = 0;
			this.MailSendCode2 = 0;
			//this.MailSendCode3 = 0;
			//this.MailSendCode4 = 0;
			//this.MailSendCode5 = 0;
			//this.MailSendCode6 = 0;
			this.MailAddrKindCode1 = 0;
			this.MailAddrKindCode2 = 0;
			//this.MailAddrKindCode3 = 0;
			//this.MailAddrKindCode4 = 0;
			//this.MailAddrKindCode5 = 0;
			//this.MailAddrKindCode6 = 0;

            this.CollectCond = 10;
        }
        # endregion

        # region [コンストラクタ（★自動生成　＋　一部手動追加）]
        /// <summary>
        /// 得意先マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="customerCode">得意先コード(納入先の場合の使用可能項目)</param>
        /// <param name="customerSubCode">得意先サブコード</param>
        /// <param name="name">名称(納入先の場合の使用可能項目)</param>
        /// <param name="name2">名称2(納入先の場合の使用可能項目)</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="kana">カナ</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="outputNameCode">諸口コード(0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称)</param>
        /// <param name="outputName">諸口名称</param>
        /// <param name="corporateDivCode">個人・法人区分(0:個人,1:法人,2:大口法人,3:業者,4:社員)</param>
        /// <param name="customerAttributeDiv">得意先属性区分(0:正式取引先,8:社内取引先,9:諸口口座)</param>
        /// <param name="jobTypeCode">職種コード</param>
        /// <param name="businessTypeCode">業種コード</param>
        /// <param name="salesAreaCode">販売エリアコード</param>
        /// <param name="postNo">郵便番号(納入先の場合の使用可能項目)</param>
        /// <param name="address1">住所1（都道府県市区郡・町村・字）(納入先の場合の使用可能項目)</param>
        /// <param name="address3">住所3（番地）(納入先の場合の使用可能項目)</param>
        /// <param name="address4">住所4（アパート名称）(納入先の場合の使用可能項目)</param>
        /// <param name="homeTelNo">電話番号（自宅）(ハイフンを含めた16桁の番号)</param>
        /// <param name="officeTelNo">電話番号（勤務先）(納入先の場合の使用可能項目)</param>
        /// <param name="portableTelNo">電話番号（携帯）</param>
        /// <param name="homeFaxNo">FAX番号（自宅）</param>
        /// <param name="officeFaxNo">FAX番号（勤務先）(納入先の場合の使用可能項目)</param>
        /// <param name="othersTelNo">電話番号（その他）</param>
        /// <param name="mainContactCode">主連絡先区分(0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･)</param>
        /// <param name="searchTelNo">電話番号（検索用下4桁）</param>
        /// <param name="mngSectionCode">管理拠点コード</param>
        /// <param name="inpSectionCode">入力拠点コード</param>
        /// <param name="custAnalysCode1">得意先分析コード1</param>
        /// <param name="custAnalysCode2">得意先分析コード2</param>
        /// <param name="custAnalysCode3">得意先分析コード3</param>
        /// <param name="custAnalysCode4">得意先分析コード4</param>
        /// <param name="custAnalysCode5">得意先分析コード5</param>
        /// <param name="custAnalysCode6">得意先分析コード6</param>
        /// <param name="billOutputCode">請求書出力区分コード(0:請求書発行する,1:しない)</param>
        /// <param name="billOutputName">請求書出力区分名称</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="collectMoneyCode">集金月区分コード(0:当月,1:翌月,2:翌々月)</param>
        /// <param name="collectMoneyName">集金月区分名称(当月,翌月,翌々月)</param>
        /// <param name="collectMoneyDay">集金日(DD)</param>
        /// <param name="collectCond">回収条件(10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他)</param>
        /// <param name="collectSight">回収サイト(手形サイト　180等)</param>
        /// <param name="claimCode">請求先コード(請求先得意先。納入先の場合の使用可能項目)</param>
        /// <param name="transStopDate">取引中止日(YYYYMMDD)</param>
        /// <param name="dmOutCode">DM出力区分(0:出力する,1:出力しない)</param>
        /// <param name="dmOutName">DM出力区分名称(全角で管理)</param>
        /// <param name="mainSendMailAddrCd">主送信先メールアドレス区分(0:メールアドレス1,1:メールアドレス2)</param>
        /// <param name="mailAddrKindCode1">メールアドレス種別コード1(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName1">メールアドレス種別名称1</param>
        /// <param name="mailAddress1">メールアドレス1</param>
        /// <param name="mailSendCode1">メール送信区分コード1(0:非送信,1:送信)</param>
        /// <param name="mailSendName1">メール送信区分名称1</param>
        /// <param name="mailAddrKindCode2">メールアドレス種別コード2(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName2">メールアドレス種別名称2</param>
        /// <param name="mailAddress2">メールアドレス2</param>
        /// <param name="mailSendCode2">メール送信区分コード2(0:非送信,1:送信)</param>
        /// <param name="mailSendName2">メール送信区分名称2</param>
        /// <param name="customerAgentCd">顧客担当従業員コード(文字型)</param>
        /// <param name="billCollecterCd">集金担当従業員コード</param>
        /// <param name="oldCustomerAgentCd">旧顧客担当従業員コード</param>
        /// <param name="custAgentChgDate">顧客担当変更日(YYYYMMDD)</param>
        /// <param name="acceptWholeSale">業販先区分(0:業販先以外,1:業販先,2:納入先)</param>
        /// <param name="creditMngCode">与信管理区分</param>
        /// <param name="depoDelCode">入金消込区分(PM(0:しない,1:する) G/D( 0:しない,1:する(請求別),2:する(納品別)）)</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="custSlipNoMngCd">相手伝票番号管理区分(0:しない　1:する)</param>
        /// <param name="pureCode">純正区分(0:純正、1:その他（PMは優良）　)</param>
        /// <param name="custCTaXLayRefCd">得意先消費税転嫁方式参照区分(0:税率設定マスタを参照　1:得意先マスタを参照)</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親3:請求子　9:非課税)</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="totalAmntDspWayRef">総額表示方法参照区分(0:全体設定参照 1:得意先参照)</param>
        /// <param name="accountNoInfo1">銀行口座1</param>
        /// <param name="accountNoInfo2">銀行口座2</param>
        /// <param name="accountNoInfo3">銀行口座3</param>
        /// <param name="salesUnPrcFrcProcCd">売上単価端数処理コード(0の場合は 標準設定とする。)</param>
        /// <param name="salesMoneyFrcProcCd">売上金額端数処理コード(0の場合は 標準設定とする。)</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード(0の場合は 標準設定とする。)</param>
        /// <param name="customerSlipNoDiv">得意先伝票番号区分(0:使用しない　1:使用する)</param>
        /// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
        /// <param name="customerAgent">得意先担当者(得意先（仕入先）の問い合わせ先社員名)</param>
        /// <param name="claimSectionCode">請求拠点コード(請求を行う拠点)</param>
        /// <param name="carMngDivCd">車輌管理区分(0:しない、1:登録(確認)、2:登録(自動) 3:登録無)</param>
        /// <param name="billPartsNoPrtCd">品番印字区分(請求書)(0:商品マスタ、1:有、2:無)</param>
        /// <param name="deliPartsNoPrtCd">品番印字区分(納品書）(0:商品マスタ、1:有、2:無)</param>
        /// <param name="defSalesSlipCd">伝票区分初期値</param>
        /// <param name="lavorRateRank">工賃レバレートランク</param>
        /// <param name="slipTtlPrn">伝票タイトルパターン(0000:未設定、0100:基本タイトル、0200・・)</param>
        /// <param name="depoBankCode">入金銀行コード</param>
        /// <param name="custWarehouseCd">得意先優先倉庫コード</param>
        /// <param name="qrcodePrtCd">QRコード印刷</param>
        /// <param name="deliHonorificTtl">納品書敬称(納品書用の敬称)</param>
        /// <param name="billHonorificTtl">請求書敬称(請求書用の敬称)</param>
        /// <param name="estmHonorificTtl">見積書敬称(見積書用の敬称)</param>
        /// <param name="rectHonorificTtl">領収書敬称(領収書用の敬称)</param>
        /// <param name="deliHonorTtlPrtDiv">納品書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="billHonorTtlPrtDiv">請求書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="estmHonorTtlPrtDiv">見積書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="rectHonorTtlPrtDiv">領収書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="note1">備考1</param>
        /// <param name="note2">備考2</param>
        /// <param name="note3">備考3</param>
        /// <param name="note4">備考4</param>
        /// <param name="note5">備考5</param>
        /// <param name="note6">備考6</param>
        /// <param name="note7">備考7</param>
        /// <param name="note8">備考8</param>
        /// <param name="note9">備考9</param>
        /// <param name="note10">備考10</param>
        /// <param name="salesAreaName">販売エリア名称</param>
        /// <param name="claimName">請求先名称</param>
        /// <param name="claimName2">請求先名称２</param>
        /// <param name="claimSnm">請求先略称</param>
        /// <param name="customerAgentNm">顧客担当従業員名称</param>
        /// <param name="oldCustomerAgentNm">旧顧客担当従業員名称</param>
        /// <param name="claimSectionName">請求拠点名称</param>
        /// <param name="depoBankName">入金銀行名称</param>
        /// <param name="custWarehouseName">得意先優先倉庫名称</param>
        /// <param name="mngSectionName">管理拠点名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="jobTypeName">職種名称</param>
        /// <param name="businessTypeName">業種名称</param>
        /// <param name="inpSectionName">入力拠点名称</param>
        /// <param name="billOutPutCodeNm">請求書出力区分名称(請求書発行する,しない)</param>
        /// <param name="billCollecterNm">集金担当従業員名称</param>
        /// <param name="homeTelNoDspName">自宅ＴＥＬ番号表示名称</param>
        /// <param name="officeTelNoDspName">勤務先ＴＥＬ番号表示名称</param>
        /// <param name="mobileTelNoDspName">携帯ＴＥＬ番号表示名称</param>
        /// <param name="otherTelNoDspName">その他ＴＥＬ番号表示名称</param>
        /// <param name="homeFaxNoDspName">自宅ＦＡＸ番号表示名称</param>
        /// <param name="officeFaxNoDspName">勤務先ＦＡＸ番号表示名称</param>
        /// <param name="salesSlipPrtDiv">納品書出力区分</param>
        /// <param name="acpOdrrSlipPrtDiv">受注伝票出力区分</param>
        /// <param name="shipmSlipPrtDiv">貸出伝票出力区分</param>
        /// <param name="estimatePrtDiv">見積伝票出力区分</param>
        /// <param name="uoeSlipPrtDiv">UOE伝票出力区分</param>
        /// <param name="receiptOutputCode">領収書出力区分コード</param>
        /// <param name="customerEpCode">得意先企業コード</param>
        /// <param name="customerSecCode">得意先拠点コード</param>
        /// <param name="onlineKindDiv">オンライン種別区分</param>
        /// <param name="totalBillOutputDiv">合計請求書出力区分</param>
        /// <param name="detailBillOutputCode">明細請求書出力区分</param>
        /// <param name="slipTtlBillOutputDiv">伝票合計請求書出力区分</param>
        /// <param name="simplInqAcntAcntGrId">簡単問合せアカウントグループID</param>
        /// <param name="noteInfo">メモ</param>
        /// <param name="DisplayDivCode">得意先情報ガイド表示</param>
        /// <returns>CustomerInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public CustomerInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, Int32 businessTypeCode, Int32 salesAreaCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string billCollecterCd, string oldCustomerAgentCd, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, String custWarehouseCd, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, string salesAreaName, string claimName, string claimName2, string claimSnm, string customerAgentNm, string oldCustomerAgentNm, string claimSectionName, string depoBankName, string custWarehouseName, string mngSectionName, string enterpriseName, string updEmployeeName, string jobTypeName, string businessTypeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 shipmSlipPrtDiv, Int32 estimatePrtDiv, Int32 uoeSlipPrtDiv, Int32 receiptOutputCode)       
        // --- UPD  大矢睦美  2010/01/04 ---------->>>>> 
        //public CustomerInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, Int32 businessTypeCode, Int32 salesAreaCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string billCollecterCd, string oldCustomerAgentCd, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, String custWarehouseCd, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, string salesAreaName, string claimName, string claimName2, string claimSnm, string customerAgentNm, string oldCustomerAgentNm, string claimSectionName, string depoBankName, string custWarehouseName, string mngSectionName, string enterpriseName, string updEmployeeName, string jobTypeName, string businessTypeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 shipmSlipPrtDiv, Int32 estimatePrtDiv, Int32 uoeSlipPrtDiv, Int32 receiptOutputCode, string customerEpCode, string customerSecCode, Int32 onlineKindDiv)
        public CustomerInfo(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, Int32 businessTypeCode, Int32 salesAreaCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string billCollecterCd, string oldCustomerAgentCd, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, String custWarehouseCd, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, string salesAreaName, string claimName, string claimName2, string claimSnm, string customerAgentNm, string oldCustomerAgentNm, string claimSectionName, string depoBankName, string custWarehouseName, string mngSectionName, string enterpriseName, string updEmployeeName, string jobTypeName, string businessTypeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 shipmSlipPrtDiv, Int32 estimatePrtDiv, Int32 uoeSlipPrtDiv, Int32 receiptOutputCode, string customerEpCode, string customerSecCode, Int32 onlineKindDiv, Int32 totalBillOutputDiv, Int32 detailBillOutputCode, Int32 slipTtlBillOutputDiv
        , string simplInqAcntAcntGrId, string noteInfo   // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加
        , Int32 DisplayDivCode   // ADD 2021/05/10 得意先情報ガイド表示
        )
        // --- UPD  大矢睦美  2010/01/04 ---------->>>>>
        // (手動追加)↓
        ///// <param name="homeTelNoDspName">自宅ＴＥＬ番号表示名称</param>
        ///// <param name="officeTelNoDspName">勤務先ＴＥＬ番号表示名称</param>
        ///// <param name="mobileTelNoDspName">携帯ＴＥＬ番号表示名称</param>
        ///// <param name="otherTelNoDspName">その他ＴＥＬ番号表示名称</param>
        ///// <param name="homeFaxNoDspName">自宅ＦＡＸ番号表示名称</param>
        ///// <param name="officeFaxNoDspName">勤務先ＦＡＸ番号表示名称</param>
        /////
        // (手動追加)→　, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, CusCarNote cusCarNoteObj )
        // UPD 陳健 K2014/02/06 ----------------------------->>>>>
        // (手動追加)↓
        //// <param name="noteInfo">メモ</param>
        // (手動追加)→　, string noteInfo
        {
            # region [（★自動生成）]
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._name = name;
            this._name2 = name2;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._customerSnm = customerSnm;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._corporateDivCode = corporateDivCode;
            this._customerAttributeDiv = customerAttributeDiv;
            this._jobTypeCode = jobTypeCode;
            this._businessTypeCode = businessTypeCode;
            this._salesAreaCode = salesAreaCode;
            this._postNo = postNo;
            this._address1 = address1;
            this._address3 = address3;
            this._address4 = address4;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._othersTelNo = othersTelNo;
            this._mainContactCode = mainContactCode;
            this._searchTelNo = searchTelNo;
            this._mngSectionCode = mngSectionCode;
            this._inpSectionCode = inpSectionCode;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._billOutputCode = billOutputCode;
            this._billOutputName = billOutputName;
            this._totalDay = totalDay;
            this._collectMoneyCode = collectMoneyCode;
            this._collectMoneyName = collectMoneyName;
            this._collectMoneyDay = collectMoneyDay;
            this._collectCond = collectCond;
            this._collectSight = collectSight;
            this._claimCode = claimCode;
            this._transStopDate = transStopDate;
            this._dmOutCode = dmOutCode;
            this._dmOutName = dmOutName;
            this._mainSendMailAddrCd = mainSendMailAddrCd;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailAddress1 = mailAddress1;
            this._mailSendCode1 = mailSendCode1;
            this._mailSendName1 = mailSendName1;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddrKindName2 = mailAddrKindName2;
            this._mailAddress2 = mailAddress2;
            this._mailSendCode2 = mailSendCode2;
            this._mailSendName2 = mailSendName2;
            this._customerAgentCd = customerAgentCd;
            this._billCollecterCd = billCollecterCd;
            this._oldCustomerAgentCd = oldCustomerAgentCd;
            this._custAgentChgDate = custAgentChgDate;
            this._acceptWholeSale = acceptWholeSale;
            this._creditMngCode = creditMngCode;
            this._depoDelCode = depoDelCode;
            this._accRecDivCd = accRecDivCd;
            this._custSlipNoMngCd = custSlipNoMngCd;
            this._pureCode = pureCode;
            this._custCTaXLayRefCd = custCTaXLayRefCd;
            this._consTaxLayMethod = consTaxLayMethod;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._totalAmntDspWayRef = totalAmntDspWayRef;
            this._accountNoInfo1 = accountNoInfo1;
            this._accountNoInfo2 = accountNoInfo2;
            this._accountNoInfo3 = accountNoInfo3;
            this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
            this._salesMoneyFrcProcCd = salesMoneyFrcProcCd;
            this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
            this._customerSlipNoDiv = customerSlipNoDiv;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._customerAgent = customerAgent;
            this._claimSectionCode = claimSectionCode;
            this._carMngDivCd = carMngDivCd;
            this._billPartsNoPrtCd = billPartsNoPrtCd;
            this._deliPartsNoPrtCd = deliPartsNoPrtCd;
            this._defSalesSlipCd = defSalesSlipCd;
            this._lavorRateRank = lavorRateRank;
            this._slipTtlPrn = slipTtlPrn;
            this._depoBankCode = depoBankCode;
            this._custWarehouseCd = custWarehouseCd;
            this._qrcodePrtCd = qrcodePrtCd;
            this._deliHonorificTtl = deliHonorificTtl;
            this._billHonorificTtl = billHonorificTtl;
            this._estmHonorificTtl = estmHonorificTtl;
            this._rectHonorificTtl = rectHonorificTtl;
            this._deliHonorTtlPrtDiv = deliHonorTtlPrtDiv;
            this._billHonorTtlPrtDiv = billHonorTtlPrtDiv;
            this._estmHonorTtlPrtDiv = estmHonorTtlPrtDiv;
            this._rectHonorTtlPrtDiv = rectHonorTtlPrtDiv;
            this._note1 = note1;
            this._note2 = note2;
            this._note3 = note3;
            this._note4 = note4;
            this._note5 = note5;
            this._note6 = note6;
            this._note7 = note7;
            this._note8 = note8;
            this._note9 = note9;
            this._note10 = note10;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._jobTypeName = jobTypeName;
            this._businessTypeName = businessTypeName;
            this._inpSectionName = inpSectionName;
            this._billOutPutCodeNm = billOutPutCodeNm;
            this._billCollecterNm = billCollecterNm;
            this._salesSlipPrtDiv = salesSlipPrtDiv;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._shipmSlipPrtDiv = shipmSlipPrtDiv;
            this._estimatePrtDiv = estimatePrtDiv;
            this._uoeSlipPrtDiv = uoeSlipPrtDiv;
            this._receiptOutputCode = receiptOutputCode;
            // ADD 2009/06/03 ------>>>
            this._customerEpCode = customerEpCode;
            this._customerSecCode = customerSecCode;
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            this._simplInqAcntAcntGrId = simplInqAcntAcntGrId;
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            this._onlineKindDiv = onlineKindDiv;
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            this._totalBillOutputDiv = totalBillOutputDiv;
            this._detailBillOutputCode = detailBillOutputCode;
            this._slipTtlBillOutputDiv = slipTtlBillOutputDiv;
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            // ADD 陳健 K2014/02/06 --------------------->>>>>
            this._noteInfo = noteInfo;
            // ADD 陳健 K2014/02/06 ---------------------<<<<<
            // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
            this._DisplayDivCode = DisplayDivCode;
            // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
            # endregion

            # region [（手動追加）]
            // 名称
            this._salesAreaName = salesAreaName;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerAgentNm = customerAgentNm;
            this._oldCustomerAgentNm = oldCustomerAgentNm;
            this._claimSectionName = claimSectionName;
            this._depoBankName = depoBankName;
            this._custWarehouseName = custWarehouseName;
            this._mngSectionName = mngSectionName;

            // ＴＥＬ・ＦＡＸ表示名称（ＵＩ表示用の項目）
            this._homeTelNoDspName = homeTelNoDspName;
            this._officeTelNoDspName = officeTelNoDspName;
            this._mobileTelNoDspName = mobileTelNoDspName;
            this._otherTelNoDspName = otherTelNoDspName;
            this._homeFaxNoDspName = homeFaxNoDspName;
            this._officeFaxNoDspName = officeFaxNoDspName;
            # endregion
        }

        /// <summary>
        /// 得意先マスタ複製処理
        /// </summary>
        /// <returns>Customerクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustomerクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerInfo Clone()
        {
            // (手動追加)　→　, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName);
            //return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode);
            // --- UPD  大矢睦美  2010/01/04 ---------->>>>>
            //return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode, this._customerEpCode, this._customerSecCode, this._onlineKindDiv);
            //return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode, this._customerEpCode, this._customerSecCode, this._onlineKindDiv, this.TotalBillOutputDiv,this._detailBillOutputCode,this._slipTtlBillOutputDiv
            //, this._simplInqAcntAcntGrId    // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加    
            //);
            // --- UPD  大矢睦美  2010/01/04 ----------<<<<<
            return new CustomerInfo(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._businessTypeCode, this._salesAreaCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._billCollecterCd, this._oldCustomerAgentCd, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._custWarehouseCd, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._salesAreaName, this._claimName, this._claimName2, this._claimSnm, this._customerAgentNm, this._oldCustomerAgentNm, this._claimSectionName, this._depoBankName, this._custWarehouseName, this._mngSectionName, this._enterpriseName, this._updEmployeeName, this._jobTypeName, this._businessTypeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._homeTelNoDspName, this._officeTelNoDspName, this._mobileTelNoDspName, this._otherTelNoDspName, this._homeFaxNoDspName, this._officeFaxNoDspName, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv, this._receiptOutputCode, this._customerEpCode, this._customerSecCode, this._onlineKindDiv, this.TotalBillOutputDiv, this._detailBillOutputCode, this._slipTtlBillOutputDiv
            , this._simplInqAcntAcntGrId, this._noteInfo // ADD 陳健 K2014/02/06  
            , this._DisplayDivCode   // ADD 2021/05/10 得意先情報ガイド表示
            );
        }
        # endregion

        # region [publicメソッド（★自動生成）]
        /// <summary>
        /// 得意先マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomerInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( CustomerInfo target )
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSubCode == target.CustomerSubCode)
                 && (this.Name == target.Name)
                 && (this.Name2 == target.Name2)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.OutputName == target.OutputName)
                 && (this.CorporateDivCode == target.CorporateDivCode)
                 && (this.CustomerAttributeDiv == target.CustomerAttributeDiv)
                 && (this.JobTypeCode == target.JobTypeCode)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.PostNo == target.PostNo)
                 && (this.Address1 == target.Address1)
                 && (this.Address3 == target.Address3)
                 && (this.Address4 == target.Address4)
                 && (this.HomeTelNo == target.HomeTelNo)
                 && (this.OfficeTelNo == target.OfficeTelNo)
                 && (this.PortableTelNo == target.PortableTelNo)
                 && (this.HomeFaxNo == target.HomeFaxNo)
                 && (this.OfficeFaxNo == target.OfficeFaxNo)
                 && (this.OthersTelNo == target.OthersTelNo)
                 && (this.MainContactCode == target.MainContactCode)
                 && (this.SearchTelNo == target.SearchTelNo)
                 && (this.MngSectionCode == target.MngSectionCode)
                 && (this.InpSectionCode == target.InpSectionCode)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.BillOutputCode == target.BillOutputCode)
                 && (this.BillOutputName == target.BillOutputName)
                 && (this.TotalDay == target.TotalDay)
                 && (this.CollectMoneyCode == target.CollectMoneyCode)
                 && (this.CollectMoneyName == target.CollectMoneyName)
                 && (this.CollectMoneyDay == target.CollectMoneyDay)
                 && (this.CollectCond == target.CollectCond)
                 && (this.CollectSight == target.CollectSight)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.TransStopDate == target.TransStopDate)
                 && (this.DmOutCode == target.DmOutCode)
                 && (this.DmOutName == target.DmOutName)
                 && (this.MainSendMailAddrCd == target.MainSendMailAddrCd)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailAddress1 == target.MailAddress1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailSendName1 == target.MailSendName1)
                 && (this.MailAddrKindCode2 == target.MailAddrKindCode2)
                 && (this.MailAddrKindName2 == target.MailAddrKindName2)
                 && (this.MailAddress2 == target.MailAddress2)
                 && (this.MailSendCode2 == target.MailSendCode2)
                 && (this.MailSendName2 == target.MailSendName2)
                 && (this.CustomerAgentCd == target.CustomerAgentCd)
                 && (this.BillCollecterCd == target.BillCollecterCd)
                 && (this.OldCustomerAgentCd == target.OldCustomerAgentCd)
                 && (this.CustAgentChgDate == target.CustAgentChgDate)
                 && (this.AcceptWholeSale == target.AcceptWholeSale)
                 && (this.CreditMngCode == target.CreditMngCode)
                 && (this.DepoDelCode == target.DepoDelCode)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.CustSlipNoMngCd == target.CustSlipNoMngCd)
                 && (this.PureCode == target.PureCode)
                 && (this.CustCTaXLayRefCd == target.CustCTaXLayRefCd)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TotalAmntDspWayRef == target.TotalAmntDspWayRef)
                 && (this.AccountNoInfo1 == target.AccountNoInfo1)
                 && (this.AccountNoInfo2 == target.AccountNoInfo2)
                 && (this.AccountNoInfo3 == target.AccountNoInfo3)
                 && (this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd)
                 && (this.SalesMoneyFrcProcCd == target.SalesMoneyFrcProcCd)
                 && (this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd)
                 && (this.CustomerSlipNoDiv == target.CustomerSlipNoDiv)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.CustomerAgent == target.CustomerAgent)
                 && (this.ClaimSectionCode == target.ClaimSectionCode)
                 && (this.CarMngDivCd == target.CarMngDivCd)
                 && (this.BillPartsNoPrtCd == target.BillPartsNoPrtCd)
                 && (this.DeliPartsNoPrtCd == target.DeliPartsNoPrtCd)
                 && (this.DefSalesSlipCd == target.DefSalesSlipCd)
                 && (this.LavorRateRank == target.LavorRateRank)
                 && (this.SlipTtlPrn == target.SlipTtlPrn)
                 && (this.DepoBankCode == target.DepoBankCode)
                 && (this.CustWarehouseCd == target.CustWarehouseCd)
                 && (this.QrcodePrtCd == target.QrcodePrtCd)
                 && (this.DeliHonorificTtl == target.DeliHonorificTtl)
                 && (this.BillHonorificTtl == target.BillHonorificTtl)
                 && (this.EstmHonorificTtl == target.EstmHonorificTtl)
                 && (this.RectHonorificTtl == target.RectHonorificTtl)
                 && (this.DeliHonorTtlPrtDiv == target.DeliHonorTtlPrtDiv)
                 && (this.BillHonorTtlPrtDiv == target.BillHonorTtlPrtDiv)
                 && (this.EstmHonorTtlPrtDiv == target.EstmHonorTtlPrtDiv)
                 && (this.RectHonorTtlPrtDiv == target.RectHonorTtlPrtDiv)
                 && (this.Note1 == target.Note1)
                 && (this.Note2 == target.Note2)
                 && (this.Note3 == target.Note3)
                 && (this.Note4 == target.Note4)
                 && (this.Note5 == target.Note5)
                 && (this.Note6 == target.Note6)
                 && (this.Note7 == target.Note7)
                 && (this.Note8 == target.Note8)
                 && (this.Note9 == target.Note9)
                 && (this.Note10 == target.Note10)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerAgentNm == target.CustomerAgentNm)
                 && (this.OldCustomerAgentNm == target.OldCustomerAgentNm)
                 && (this.ClaimSectionName == target.ClaimSectionName)
                 && (this.DepoBankName == target.DepoBankName)
                 && (this.CustWarehouseName == target.CustWarehouseName)
                 && (this.MngSectionName == target.MngSectionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.JobTypeName == target.JobTypeName)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.InpSectionName == target.InpSectionName)
                 && (this.BillOutPutCodeNm == target.BillOutPutCodeNm)
                 && (this.BillCollecterNm == target.BillCollecterNm)
                 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.ShipmSlipPrtDiv == target.ShipmSlipPrtDiv)
                 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
                 && (this.UOESlipPrtDiv == target.UOESlipPrtDiv)
                 && (this.ReceiptOutputCode == target.ReceiptOutputCode)
                 // ADD 2009/06/03 ------>>>
                 && (this.CustomerEpCode == target.CustomerEpCode)
                 && (this.CustomerSecCode == target.CustomerSecCode)
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                && (this.SimplInqAcntAcntGrId == target.SimplInqAcntAcntGrId)
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
                 && (this.OnlineKindDiv == target.OnlineKindDiv)
                 // ADD 2009/06/03 ------<<<
                 // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                 && (this.TotalBillOutputDiv == target.TotalBillOutputDiv)
                 && (this.DetailBillOutputCode == target.DetailBillOutputCode)
                 && (this.SlipTtlBillOutputDiv == target.SlipTtlBillOutputDiv)
                 // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                 // ADD 陳健 K2014/02/06--------------------------->>>>>
                 && (this.NoteInfo == target.NoteInfo)
                 // ADD 陳健 K2014/02/06---------------------------<<<<<
                 // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
                 && (this.DisplayDivCode == target.DisplayDivCode)
                 // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
                 );
        }

        /// <summary>
        /// 得意先マスタ比較処理
        /// </summary>
        /// <param name="customerInfo1">
        ///                    比較するCustomerInfoクラスのインスタンス
        /// </param>
        /// <param name="customerInfo2">比較するCustomerInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( CustomerInfo customerInfo1, CustomerInfo customerInfo2 )
        {
            return ((customerInfo1.CreateDateTime == customerInfo2.CreateDateTime)
                 && (customerInfo1.UpdateDateTime == customerInfo2.UpdateDateTime)
                 && (customerInfo1.EnterpriseCode == customerInfo2.EnterpriseCode)
                 && (customerInfo1.FileHeaderGuid == customerInfo2.FileHeaderGuid)
                 && (customerInfo1.UpdEmployeeCode == customerInfo2.UpdEmployeeCode)
                 && (customerInfo1.UpdAssemblyId1 == customerInfo2.UpdAssemblyId1)
                 && (customerInfo1.UpdAssemblyId2 == customerInfo2.UpdAssemblyId2)
                 && (customerInfo1.LogicalDeleteCode == customerInfo2.LogicalDeleteCode)
                 && (customerInfo1.CustomerCode == customerInfo2.CustomerCode)
                 && (customerInfo1.CustomerSubCode == customerInfo2.CustomerSubCode)
                 && (customerInfo1.Name == customerInfo2.Name)
                 && (customerInfo1.Name2 == customerInfo2.Name2)
                 && (customerInfo1.HonorificTitle == customerInfo2.HonorificTitle)
                 && (customerInfo1.Kana == customerInfo2.Kana)
                 && (customerInfo1.CustomerSnm == customerInfo2.CustomerSnm)
                 && (customerInfo1.OutputNameCode == customerInfo2.OutputNameCode)
                 && (customerInfo1.OutputName == customerInfo2.OutputName)
                 && (customerInfo1.CorporateDivCode == customerInfo2.CorporateDivCode)
                 && (customerInfo1.CustomerAttributeDiv == customerInfo2.CustomerAttributeDiv)
                 && (customerInfo1.JobTypeCode == customerInfo2.JobTypeCode)
                 && (customerInfo1.BusinessTypeCode == customerInfo2.BusinessTypeCode)
                 && (customerInfo1.SalesAreaCode == customerInfo2.SalesAreaCode)
                 && (customerInfo1.PostNo == customerInfo2.PostNo)
                 && (customerInfo1.Address1 == customerInfo2.Address1)
                 && (customerInfo1.Address3 == customerInfo2.Address3)
                 && (customerInfo1.Address4 == customerInfo2.Address4)
                 && (customerInfo1.HomeTelNo == customerInfo2.HomeTelNo)
                 && (customerInfo1.OfficeTelNo == customerInfo2.OfficeTelNo)
                 && (customerInfo1.PortableTelNo == customerInfo2.PortableTelNo)
                 && (customerInfo1.HomeFaxNo == customerInfo2.HomeFaxNo)
                 && (customerInfo1.OfficeFaxNo == customerInfo2.OfficeFaxNo)
                 && (customerInfo1.OthersTelNo == customerInfo2.OthersTelNo)
                 && (customerInfo1.MainContactCode == customerInfo2.MainContactCode)
                 && (customerInfo1.SearchTelNo == customerInfo2.SearchTelNo)
                 && (customerInfo1.MngSectionCode == customerInfo2.MngSectionCode)
                 && (customerInfo1.InpSectionCode == customerInfo2.InpSectionCode)
                 && (customerInfo1.CustAnalysCode1 == customerInfo2.CustAnalysCode1)
                 && (customerInfo1.CustAnalysCode2 == customerInfo2.CustAnalysCode2)
                 && (customerInfo1.CustAnalysCode3 == customerInfo2.CustAnalysCode3)
                 && (customerInfo1.CustAnalysCode4 == customerInfo2.CustAnalysCode4)
                 && (customerInfo1.CustAnalysCode5 == customerInfo2.CustAnalysCode5)
                 && (customerInfo1.CustAnalysCode6 == customerInfo2.CustAnalysCode6)
                 && (customerInfo1.BillOutputCode == customerInfo2.BillOutputCode)
                 && (customerInfo1.BillOutputName == customerInfo2.BillOutputName)
                 && (customerInfo1.TotalDay == customerInfo2.TotalDay)
                 && (customerInfo1.CollectMoneyCode == customerInfo2.CollectMoneyCode)
                 && (customerInfo1.CollectMoneyName == customerInfo2.CollectMoneyName)
                 && (customerInfo1.CollectMoneyDay == customerInfo2.CollectMoneyDay)
                 && (customerInfo1.CollectCond == customerInfo2.CollectCond)
                 && (customerInfo1.CollectSight == customerInfo2.CollectSight)
                 && (customerInfo1.ClaimCode == customerInfo2.ClaimCode)
                 && (customerInfo1.TransStopDate == customerInfo2.TransStopDate)
                 && (customerInfo1.DmOutCode == customerInfo2.DmOutCode)
                 && (customerInfo1.DmOutName == customerInfo2.DmOutName)
                 && (customerInfo1.MainSendMailAddrCd == customerInfo2.MainSendMailAddrCd)
                 && (customerInfo1.MailAddrKindCode1 == customerInfo2.MailAddrKindCode1)
                 && (customerInfo1.MailAddrKindName1 == customerInfo2.MailAddrKindName1)
                 && (customerInfo1.MailAddress1 == customerInfo2.MailAddress1)
                 && (customerInfo1.MailSendCode1 == customerInfo2.MailSendCode1)
                 && (customerInfo1.MailSendName1 == customerInfo2.MailSendName1)
                 && (customerInfo1.MailAddrKindCode2 == customerInfo2.MailAddrKindCode2)
                 && (customerInfo1.MailAddrKindName2 == customerInfo2.MailAddrKindName2)
                 && (customerInfo1.MailAddress2 == customerInfo2.MailAddress2)
                 && (customerInfo1.MailSendCode2 == customerInfo2.MailSendCode2)
                 && (customerInfo1.MailSendName2 == customerInfo2.MailSendName2)
                 && (customerInfo1.CustomerAgentCd == customerInfo2.CustomerAgentCd)
                 && (customerInfo1.BillCollecterCd == customerInfo2.BillCollecterCd)
                 && (customerInfo1.OldCustomerAgentCd == customerInfo2.OldCustomerAgentCd)
                 && (customerInfo1.CustAgentChgDate == customerInfo2.CustAgentChgDate)
                 && (customerInfo1.AcceptWholeSale == customerInfo2.AcceptWholeSale)
                 && (customerInfo1.CreditMngCode == customerInfo2.CreditMngCode)
                 && (customerInfo1.DepoDelCode == customerInfo2.DepoDelCode)
                 && (customerInfo1.AccRecDivCd == customerInfo2.AccRecDivCd)
                 && (customerInfo1.CustSlipNoMngCd == customerInfo2.CustSlipNoMngCd)
                 && (customerInfo1.PureCode == customerInfo2.PureCode)
                 && (customerInfo1.CustCTaXLayRefCd == customerInfo2.CustCTaXLayRefCd)
                 && (customerInfo1.ConsTaxLayMethod == customerInfo2.ConsTaxLayMethod)
                 && (customerInfo1.TotalAmountDispWayCd == customerInfo2.TotalAmountDispWayCd)
                 && (customerInfo1.TotalAmntDspWayRef == customerInfo2.TotalAmntDspWayRef)
                 && (customerInfo1.AccountNoInfo1 == customerInfo2.AccountNoInfo1)
                 && (customerInfo1.AccountNoInfo2 == customerInfo2.AccountNoInfo2)
                 && (customerInfo1.AccountNoInfo3 == customerInfo2.AccountNoInfo3)
                 && (customerInfo1.SalesUnPrcFrcProcCd == customerInfo2.SalesUnPrcFrcProcCd)
                 && (customerInfo1.SalesMoneyFrcProcCd == customerInfo2.SalesMoneyFrcProcCd)
                 && (customerInfo1.SalesCnsTaxFrcProcCd == customerInfo2.SalesCnsTaxFrcProcCd)
                 && (customerInfo1.CustomerSlipNoDiv == customerInfo2.CustomerSlipNoDiv)
                 && (customerInfo1.NTimeCalcStDate == customerInfo2.NTimeCalcStDate)
                 && (customerInfo1.CustomerAgent == customerInfo2.CustomerAgent)
                 && (customerInfo1.ClaimSectionCode == customerInfo2.ClaimSectionCode)
                 && (customerInfo1.CarMngDivCd == customerInfo2.CarMngDivCd)
                 && (customerInfo1.BillPartsNoPrtCd == customerInfo2.BillPartsNoPrtCd)
                 && (customerInfo1.DeliPartsNoPrtCd == customerInfo2.DeliPartsNoPrtCd)
                 && (customerInfo1.DefSalesSlipCd == customerInfo2.DefSalesSlipCd)
                 && (customerInfo1.LavorRateRank == customerInfo2.LavorRateRank)
                 && (customerInfo1.SlipTtlPrn == customerInfo2.SlipTtlPrn)
                 && (customerInfo1.DepoBankCode == customerInfo2.DepoBankCode)
                 && (customerInfo1.CustWarehouseCd == customerInfo2.CustWarehouseCd)
                 && (customerInfo1.QrcodePrtCd == customerInfo2.QrcodePrtCd)
                 && (customerInfo1.DeliHonorificTtl == customerInfo2.DeliHonorificTtl)
                 && (customerInfo1.BillHonorificTtl == customerInfo2.BillHonorificTtl)
                 && (customerInfo1.EstmHonorificTtl == customerInfo2.EstmHonorificTtl)
                 && (customerInfo1.RectHonorificTtl == customerInfo2.RectHonorificTtl)
                 && (customerInfo1.DeliHonorTtlPrtDiv == customerInfo2.DeliHonorTtlPrtDiv)
                 && (customerInfo1.BillHonorTtlPrtDiv == customerInfo2.BillHonorTtlPrtDiv)
                 && (customerInfo1.EstmHonorTtlPrtDiv == customerInfo2.EstmHonorTtlPrtDiv)
                 && (customerInfo1.RectHonorTtlPrtDiv == customerInfo2.RectHonorTtlPrtDiv)
                 && (customerInfo1.Note1 == customerInfo2.Note1)
                 && (customerInfo1.Note2 == customerInfo2.Note2)
                 && (customerInfo1.Note3 == customerInfo2.Note3)
                 && (customerInfo1.Note4 == customerInfo2.Note4)
                 && (customerInfo1.Note5 == customerInfo2.Note5)
                 && (customerInfo1.Note6 == customerInfo2.Note6)
                 && (customerInfo1.Note7 == customerInfo2.Note7)
                 && (customerInfo1.Note8 == customerInfo2.Note8)
                 && (customerInfo1.Note9 == customerInfo2.Note9)
                 && (customerInfo1.Note10 == customerInfo2.Note10)
                 && (customerInfo1.SalesAreaName == customerInfo2.SalesAreaName)
                 && (customerInfo1.ClaimName == customerInfo2.ClaimName)
                 && (customerInfo1.ClaimName2 == customerInfo2.ClaimName2)
                 && (customerInfo1.ClaimSnm == customerInfo2.ClaimSnm)
                 && (customerInfo1.CustomerAgentNm == customerInfo2.CustomerAgentNm)
                 && (customerInfo1.OldCustomerAgentNm == customerInfo2.OldCustomerAgentNm)
                 && (customerInfo1.ClaimSectionName == customerInfo2.ClaimSectionName)
                 && (customerInfo1.DepoBankName == customerInfo2.DepoBankName)
                 && (customerInfo1.CustWarehouseName == customerInfo2.CustWarehouseName)
                 && (customerInfo1.MngSectionName == customerInfo2.MngSectionName)
                 && (customerInfo1.EnterpriseName == customerInfo2.EnterpriseName)
                 && (customerInfo1.UpdEmployeeName == customerInfo2.UpdEmployeeName)
                 && (customerInfo1.JobTypeName == customerInfo2.JobTypeName)
                 && (customerInfo1.BusinessTypeName == customerInfo2.BusinessTypeName)
                 && (customerInfo1.InpSectionName == customerInfo2.InpSectionName)
                 && (customerInfo1.BillOutPutCodeNm == customerInfo2.BillOutPutCodeNm)
                 && (customerInfo1.BillCollecterNm == customerInfo2.BillCollecterNm)
                 && (customerInfo1.SalesSlipPrtDiv == customerInfo2.SalesSlipPrtDiv)
                 && (customerInfo1.AcpOdrrSlipPrtDiv == customerInfo2.AcpOdrrSlipPrtDiv)
                 && (customerInfo1.ShipmSlipPrtDiv == customerInfo2.ShipmSlipPrtDiv)
                 && (customerInfo1.EstimatePrtDiv == customerInfo2.EstimatePrtDiv)
                 && (customerInfo1.UOESlipPrtDiv == customerInfo2.UOESlipPrtDiv)
                 && (customerInfo1.ReceiptOutputCode == customerInfo2.ReceiptOutputCode)
                 // ADD 2009/06/03 ------>>>
                 && (customerInfo1.CustomerEpCode == customerInfo2.CustomerEpCode)
                 && (customerInfo1.CustomerSecCode == customerInfo2.CustomerSecCode)
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
                 && (customerInfo1.SimplInqAcntAcntGrId == customerInfo2.SimplInqAcntAcntGrId)
                // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
                 && (customerInfo1.OnlineKindDiv == customerInfo2.OnlineKindDiv)
                 // ADD 2009/06/03 ------<<<
                 // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                 && (customerInfo1.TotalBillOutputDiv == customerInfo2.TotalBillOutputDiv)
                 && (customerInfo1.DetailBillOutputCode == customerInfo2.DetailBillOutputCode)
                 && (customerInfo1.SlipTtlBillOutputDiv == customerInfo2.SlipTtlBillOutputDiv)
                 // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                 // ADD 陳健 K2014/02/06--------------------------->>>>>
                 && (customerInfo1.NoteInfo == customerInfo2.NoteInfo)
                 // ADD 陳健 K2014/02/06---------------------------<<<<<
                 // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
                 && (customerInfo1.DisplayDivCode == customerInfo2.DisplayDivCode)
                 // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
                 );
        }
        /// <summary>
        /// 得意先マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomerInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( CustomerInfo target )
        {
            ArrayList resList = new ArrayList();
            if ( this.CreateDateTime != target.CreateDateTime ) resList.Add( "CreateDateTime" );
            if ( this.UpdateDateTime != target.UpdateDateTime ) resList.Add( "UpdateDateTime" );
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.FileHeaderGuid != target.FileHeaderGuid ) resList.Add( "FileHeaderGuid" );
            if ( this.UpdEmployeeCode != target.UpdEmployeeCode ) resList.Add( "UpdEmployeeCode" );
            if ( this.UpdAssemblyId1 != target.UpdAssemblyId1 ) resList.Add( "UpdAssemblyId1" );
            if ( this.UpdAssemblyId2 != target.UpdAssemblyId2 ) resList.Add( "UpdAssemblyId2" );
            if ( this.LogicalDeleteCode != target.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( this.CustomerCode != target.CustomerCode ) resList.Add( "CustomerCode" );
            if ( this.CustomerSubCode != target.CustomerSubCode ) resList.Add( "CustomerSubCode" );
            if ( this.Name != target.Name ) resList.Add( "Name" );
            if ( this.Name2 != target.Name2 ) resList.Add( "Name2" );
            if ( this.HonorificTitle != target.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( this.Kana != target.Kana ) resList.Add( "Kana" );
            if ( this.CustomerSnm != target.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( this.OutputNameCode != target.OutputNameCode ) resList.Add( "OutputNameCode" );
            if ( this.OutputName != target.OutputName ) resList.Add( "OutputName" );
            if ( this.CorporateDivCode != target.CorporateDivCode ) resList.Add( "CorporateDivCode" );
            if ( this.CustomerAttributeDiv != target.CustomerAttributeDiv ) resList.Add( "CustomerAttributeDiv" );
            if ( this.JobTypeCode != target.JobTypeCode ) resList.Add( "JobTypeCode" );
            if ( this.BusinessTypeCode != target.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( this.SalesAreaCode != target.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( this.PostNo != target.PostNo ) resList.Add( "PostNo" );
            if ( this.Address1 != target.Address1 ) resList.Add( "Address1" );
            if ( this.Address3 != target.Address3 ) resList.Add( "Address3" );
            if ( this.Address4 != target.Address4 ) resList.Add( "Address4" );
            if ( this.HomeTelNo != target.HomeTelNo ) resList.Add( "HomeTelNo" );
            if ( this.OfficeTelNo != target.OfficeTelNo ) resList.Add( "OfficeTelNo" );
            if ( this.PortableTelNo != target.PortableTelNo ) resList.Add( "PortableTelNo" );
            if ( this.HomeFaxNo != target.HomeFaxNo ) resList.Add( "HomeFaxNo" );
            if ( this.OfficeFaxNo != target.OfficeFaxNo ) resList.Add( "OfficeFaxNo" );
            if ( this.OthersTelNo != target.OthersTelNo ) resList.Add( "OthersTelNo" );
            if ( this.MainContactCode != target.MainContactCode ) resList.Add( "MainContactCode" );
            if ( this.SearchTelNo != target.SearchTelNo ) resList.Add( "SearchTelNo" );
            if ( this.MngSectionCode != target.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( this.InpSectionCode != target.InpSectionCode ) resList.Add( "InpSectionCode" );
            if ( this.CustAnalysCode1 != target.CustAnalysCode1 ) resList.Add( "CustAnalysCode1" );
            if ( this.CustAnalysCode2 != target.CustAnalysCode2 ) resList.Add( "CustAnalysCode2" );
            if ( this.CustAnalysCode3 != target.CustAnalysCode3 ) resList.Add( "CustAnalysCode3" );
            if ( this.CustAnalysCode4 != target.CustAnalysCode4 ) resList.Add( "CustAnalysCode4" );
            if ( this.CustAnalysCode5 != target.CustAnalysCode5 ) resList.Add( "CustAnalysCode5" );
            if ( this.CustAnalysCode6 != target.CustAnalysCode6 ) resList.Add( "CustAnalysCode6" );
            if ( this.BillOutputCode != target.BillOutputCode ) resList.Add( "BillOutputCode" );
            if ( this.BillOutputName != target.BillOutputName ) resList.Add( "BillOutputName" );
            if ( this.TotalDay != target.TotalDay ) resList.Add( "TotalDay" );
            if ( this.CollectMoneyCode != target.CollectMoneyCode ) resList.Add( "CollectMoneyCode" );
            if ( this.CollectMoneyName != target.CollectMoneyName ) resList.Add( "CollectMoneyName" );
            if ( this.CollectMoneyDay != target.CollectMoneyDay ) resList.Add( "CollectMoneyDay" );
            if ( this.CollectCond != target.CollectCond ) resList.Add( "CollectCond" );
            if ( this.CollectSight != target.CollectSight ) resList.Add( "CollectSight" );
            if ( this.ClaimCode != target.ClaimCode ) resList.Add( "ClaimCode" );
            if ( this.TransStopDate != target.TransStopDate ) resList.Add( "TransStopDate" );
            if ( this.DmOutCode != target.DmOutCode ) resList.Add( "DmOutCode" );
            if ( this.DmOutName != target.DmOutName ) resList.Add( "DmOutName" );
            if ( this.MainSendMailAddrCd != target.MainSendMailAddrCd ) resList.Add( "MainSendMailAddrCd" );
            if ( this.MailAddrKindCode1 != target.MailAddrKindCode1 ) resList.Add( "MailAddrKindCode1" );
            if ( this.MailAddrKindName1 != target.MailAddrKindName1 ) resList.Add( "MailAddrKindName1" );
            if ( this.MailAddress1 != target.MailAddress1 ) resList.Add( "MailAddress1" );
            if ( this.MailSendCode1 != target.MailSendCode1 ) resList.Add( "MailSendCode1" );
            if ( this.MailSendName1 != target.MailSendName1 ) resList.Add( "MailSendName1" );
            if ( this.MailAddrKindCode2 != target.MailAddrKindCode2 ) resList.Add( "MailAddrKindCode2" );
            if ( this.MailAddrKindName2 != target.MailAddrKindName2 ) resList.Add( "MailAddrKindName2" );
            if ( this.MailAddress2 != target.MailAddress2 ) resList.Add( "MailAddress2" );
            if ( this.MailSendCode2 != target.MailSendCode2 ) resList.Add( "MailSendCode2" );
            if ( this.MailSendName2 != target.MailSendName2 ) resList.Add( "MailSendName2" );
            if ( this.CustomerAgentCd != target.CustomerAgentCd ) resList.Add( "CustomerAgentCd" );
            if ( this.BillCollecterCd != target.BillCollecterCd ) resList.Add( "BillCollecterCd" );
            if ( this.OldCustomerAgentCd != target.OldCustomerAgentCd ) resList.Add( "OldCustomerAgentCd" );
            if ( this.CustAgentChgDate != target.CustAgentChgDate ) resList.Add( "CustAgentChgDate" );
            if ( this.AcceptWholeSale != target.AcceptWholeSale ) resList.Add( "AcceptWholeSale" );
            if ( this.CreditMngCode != target.CreditMngCode ) resList.Add( "CreditMngCode" );
            if ( this.DepoDelCode != target.DepoDelCode ) resList.Add( "DepoDelCode" );
            if ( this.AccRecDivCd != target.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( this.CustSlipNoMngCd != target.CustSlipNoMngCd ) resList.Add( "CustSlipNoMngCd" );
            if ( this.PureCode != target.PureCode ) resList.Add( "PureCode" );
            if ( this.CustCTaXLayRefCd != target.CustCTaXLayRefCd ) resList.Add( "CustCTaXLayRefCd" );
            if ( this.ConsTaxLayMethod != target.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( this.TotalAmountDispWayCd != target.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( this.TotalAmntDspWayRef != target.TotalAmntDspWayRef ) resList.Add( "TotalAmntDspWayRef" );
            if ( this.AccountNoInfo1 != target.AccountNoInfo1 ) resList.Add( "AccountNoInfo1" );
            if ( this.AccountNoInfo2 != target.AccountNoInfo2 ) resList.Add( "AccountNoInfo2" );
            if ( this.AccountNoInfo3 != target.AccountNoInfo3 ) resList.Add( "AccountNoInfo3" );
            if ( this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd ) resList.Add( "SalesUnPrcFrcProcCd" );
            if ( this.SalesMoneyFrcProcCd != target.SalesMoneyFrcProcCd ) resList.Add( "SalesMoneyFrcProcCd" );
            if ( this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd ) resList.Add( "SalesCnsTaxFrcProcCd" );
            if ( this.CustomerSlipNoDiv != target.CustomerSlipNoDiv ) resList.Add( "CustomerSlipNoDiv" );
            if ( this.NTimeCalcStDate != target.NTimeCalcStDate ) resList.Add( "NTimeCalcStDate" );
            if ( this.CustomerAgent != target.CustomerAgent ) resList.Add( "CustomerAgent" );
            if ( this.ClaimSectionCode != target.ClaimSectionCode ) resList.Add( "ClaimSectionCode" );
            if ( this.CarMngDivCd != target.CarMngDivCd ) resList.Add( "CarMngDivCd" );
            if ( this.BillPartsNoPrtCd != target.BillPartsNoPrtCd ) resList.Add( "BillPartsNoPrtCd" );
            if ( this.DeliPartsNoPrtCd != target.DeliPartsNoPrtCd ) resList.Add( "DeliPartsNoPrtCd" );
            if ( this.DefSalesSlipCd != target.DefSalesSlipCd ) resList.Add( "DefSalesSlipCd" );
            if ( this.LavorRateRank != target.LavorRateRank ) resList.Add( "LavorRateRank" );
            if ( this.SlipTtlPrn != target.SlipTtlPrn ) resList.Add( "SlipTtlPrn" );
            if ( this.DepoBankCode != target.DepoBankCode ) resList.Add( "DepoBankCode" );
            if ( this.CustWarehouseCd != target.CustWarehouseCd ) resList.Add( "CustWarehouseCd" );
            if ( this.QrcodePrtCd != target.QrcodePrtCd ) resList.Add( "QrcodePrtCd" );
            if ( this.DeliHonorificTtl != target.DeliHonorificTtl ) resList.Add( "DeliHonorificTtl" );
            if ( this.BillHonorificTtl != target.BillHonorificTtl ) resList.Add( "BillHonorificTtl" );
            if ( this.EstmHonorificTtl != target.EstmHonorificTtl ) resList.Add( "EstmHonorificTtl" );
            if ( this.RectHonorificTtl != target.RectHonorificTtl ) resList.Add( "RectHonorificTtl" );
            if ( this.DeliHonorTtlPrtDiv != target.DeliHonorTtlPrtDiv ) resList.Add( "DeliHonorTtlPrtDiv" );
            if ( this.BillHonorTtlPrtDiv != target.BillHonorTtlPrtDiv ) resList.Add( "BillHonorTtlPrtDiv" );
            if ( this.EstmHonorTtlPrtDiv != target.EstmHonorTtlPrtDiv ) resList.Add( "EstmHonorTtlPrtDiv" );
            if ( this.RectHonorTtlPrtDiv != target.RectHonorTtlPrtDiv ) resList.Add( "RectHonorTtlPrtDiv" );
            if ( this.Note1 != target.Note1 ) resList.Add( "Note1" );
            if ( this.Note2 != target.Note2 ) resList.Add( "Note2" );
            if ( this.Note3 != target.Note3 ) resList.Add( "Note3" );
            if ( this.Note4 != target.Note4 ) resList.Add( "Note4" );
            if ( this.Note5 != target.Note5 ) resList.Add( "Note5" );
            if ( this.Note6 != target.Note6 ) resList.Add( "Note6" );
            if ( this.Note7 != target.Note7 ) resList.Add( "Note7" );
            if ( this.Note8 != target.Note8 ) resList.Add( "Note8" );
            if ( this.Note9 != target.Note9 ) resList.Add( "Note9" );
            if ( this.Note10 != target.Note10 ) resList.Add( "Note10" );
            if ( this.SalesAreaName != target.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( this.ClaimName != target.ClaimName ) resList.Add( "ClaimName" );
            if ( this.ClaimName2 != target.ClaimName2 ) resList.Add( "ClaimName2" );
            if ( this.ClaimSnm != target.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( this.CustomerAgentNm != target.CustomerAgentNm ) resList.Add( "CustomerAgentNm" );
            if ( this.OldCustomerAgentNm != target.OldCustomerAgentNm ) resList.Add( "OldCustomerAgentNm" );
            if ( this.ClaimSectionName != target.ClaimSectionName ) resList.Add( "ClaimSectionName" );
            if ( this.DepoBankName != target.DepoBankName ) resList.Add( "DepoBankName" );
            if ( this.CustWarehouseName != target.CustWarehouseName ) resList.Add( "CustWarehouseName" );
            if ( this.MngSectionName != target.MngSectionName ) resList.Add( "MngSectionName" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( this.UpdEmployeeName != target.UpdEmployeeName ) resList.Add( "UpdEmployeeName" );
            if ( this.JobTypeName != target.JobTypeName ) resList.Add( "JobTypeName" );
            if ( this.BusinessTypeName != target.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( this.InpSectionName != target.InpSectionName ) resList.Add( "InpSectionName" );
            if ( this.BillOutPutCodeNm != target.BillOutPutCodeNm ) resList.Add( "BillOutPutCodeNm" );
            if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
            if (this.SalesSlipPrtDiv != target.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.ShipmSlipPrtDiv != target.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (this.EstimatePrtDiv != target.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (this.UOESlipPrtDiv != target.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (this.ReceiptOutputCode != target.ReceiptOutputCode) resList.Add("ReceiptOutputCode");
            // ADD 2009/06/03 ------>>>
            if (this.CustomerEpCode != target.CustomerEpCode) resList.Add("CustomerEpCode");
            if (this.CustomerSecCode != target.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            if (this.SimplInqAcntAcntGrId != target.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            if (this.OnlineKindDiv != target.OnlineKindDiv) resList.Add("OnlineKindDiv");
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            if (this.TotalBillOutputDiv != target.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (this.DetailBillOutputCode != target.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (this.SlipTtlBillOutputDiv != target.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            // ADD 陳健 K2014/02/06--------------------------->>>>>
            if (this.NoteInfo != target.NoteInfo) resList.Add("NoteInfo");
            // ADD 陳健 K2014/02/06---------------------------<<<<<
            // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
            if (this.DisplayDivCode != target.DisplayDivCode) resList.Add("DisplayDivCode");
            // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
                 
            return resList;
        }

        /// <summary>
        /// 得意先マスタ比較処理
        /// </summary>
        /// <param name="customerInfo1">比較するCustomerInfoクラスのインスタンス</param>
        /// <param name="customerInfo2">比較するCustomerInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( CustomerInfo customerInfo1, CustomerInfo customerInfo2 )
        {
            ArrayList resList = new ArrayList();
            if ( customerInfo1.CreateDateTime != customerInfo2.CreateDateTime ) resList.Add( "CreateDateTime" );
            if ( customerInfo1.UpdateDateTime != customerInfo2.UpdateDateTime ) resList.Add( "UpdateDateTime" );
            if ( customerInfo1.EnterpriseCode != customerInfo2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( customerInfo1.FileHeaderGuid != customerInfo2.FileHeaderGuid ) resList.Add( "FileHeaderGuid" );
            if ( customerInfo1.UpdEmployeeCode != customerInfo2.UpdEmployeeCode ) resList.Add( "UpdEmployeeCode" );
            if ( customerInfo1.UpdAssemblyId1 != customerInfo2.UpdAssemblyId1 ) resList.Add( "UpdAssemblyId1" );
            if ( customerInfo1.UpdAssemblyId2 != customerInfo2.UpdAssemblyId2 ) resList.Add( "UpdAssemblyId2" );
            if ( customerInfo1.LogicalDeleteCode != customerInfo2.LogicalDeleteCode ) resList.Add( "LogicalDeleteCode" );
            if ( customerInfo1.CustomerCode != customerInfo2.CustomerCode ) resList.Add( "CustomerCode" );
            if ( customerInfo1.CustomerSubCode != customerInfo2.CustomerSubCode ) resList.Add( "CustomerSubCode" );
            if ( customerInfo1.Name != customerInfo2.Name ) resList.Add( "Name" );
            if ( customerInfo1.Name2 != customerInfo2.Name2 ) resList.Add( "Name2" );
            if ( customerInfo1.HonorificTitle != customerInfo2.HonorificTitle ) resList.Add( "HonorificTitle" );
            if ( customerInfo1.Kana != customerInfo2.Kana ) resList.Add( "Kana" );
            if ( customerInfo1.CustomerSnm != customerInfo2.CustomerSnm ) resList.Add( "CustomerSnm" );
            if ( customerInfo1.OutputNameCode != customerInfo2.OutputNameCode ) resList.Add( "OutputNameCode" );
            if ( customerInfo1.OutputName != customerInfo2.OutputName ) resList.Add( "OutputName" );
            if ( customerInfo1.CorporateDivCode != customerInfo2.CorporateDivCode ) resList.Add( "CorporateDivCode" );
            if ( customerInfo1.CustomerAttributeDiv != customerInfo2.CustomerAttributeDiv ) resList.Add( "CustomerAttributeDiv" );
            if ( customerInfo1.JobTypeCode != customerInfo2.JobTypeCode ) resList.Add( "JobTypeCode" );
            if ( customerInfo1.BusinessTypeCode != customerInfo2.BusinessTypeCode ) resList.Add( "BusinessTypeCode" );
            if ( customerInfo1.SalesAreaCode != customerInfo2.SalesAreaCode ) resList.Add( "SalesAreaCode" );
            if ( customerInfo1.PostNo != customerInfo2.PostNo ) resList.Add( "PostNo" );
            if ( customerInfo1.Address1 != customerInfo2.Address1 ) resList.Add( "Address1" );
            if ( customerInfo1.Address3 != customerInfo2.Address3 ) resList.Add( "Address3" );
            if ( customerInfo1.Address4 != customerInfo2.Address4 ) resList.Add( "Address4" );
            if ( customerInfo1.HomeTelNo != customerInfo2.HomeTelNo ) resList.Add( "HomeTelNo" );
            if ( customerInfo1.OfficeTelNo != customerInfo2.OfficeTelNo ) resList.Add( "OfficeTelNo" );
            if ( customerInfo1.PortableTelNo != customerInfo2.PortableTelNo ) resList.Add( "PortableTelNo" );
            if ( customerInfo1.HomeFaxNo != customerInfo2.HomeFaxNo ) resList.Add( "HomeFaxNo" );
            if ( customerInfo1.OfficeFaxNo != customerInfo2.OfficeFaxNo ) resList.Add( "OfficeFaxNo" );
            if ( customerInfo1.OthersTelNo != customerInfo2.OthersTelNo ) resList.Add( "OthersTelNo" );
            if ( customerInfo1.MainContactCode != customerInfo2.MainContactCode ) resList.Add( "MainContactCode" );
            if ( customerInfo1.SearchTelNo != customerInfo2.SearchTelNo ) resList.Add( "SearchTelNo" );
            if ( customerInfo1.MngSectionCode != customerInfo2.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( customerInfo1.InpSectionCode != customerInfo2.InpSectionCode ) resList.Add( "InpSectionCode" );
            if ( customerInfo1.CustAnalysCode1 != customerInfo2.CustAnalysCode1 ) resList.Add( "CustAnalysCode1" );
            if ( customerInfo1.CustAnalysCode2 != customerInfo2.CustAnalysCode2 ) resList.Add( "CustAnalysCode2" );
            if ( customerInfo1.CustAnalysCode3 != customerInfo2.CustAnalysCode3 ) resList.Add( "CustAnalysCode3" );
            if ( customerInfo1.CustAnalysCode4 != customerInfo2.CustAnalysCode4 ) resList.Add( "CustAnalysCode4" );
            if ( customerInfo1.CustAnalysCode5 != customerInfo2.CustAnalysCode5 ) resList.Add( "CustAnalysCode5" );
            if ( customerInfo1.CustAnalysCode6 != customerInfo2.CustAnalysCode6 ) resList.Add( "CustAnalysCode6" );
            if ( customerInfo1.BillOutputCode != customerInfo2.BillOutputCode ) resList.Add( "BillOutputCode" );
            if ( customerInfo1.BillOutputName != customerInfo2.BillOutputName ) resList.Add( "BillOutputName" );
            if ( customerInfo1.TotalDay != customerInfo2.TotalDay ) resList.Add( "TotalDay" );
            if ( customerInfo1.CollectMoneyCode != customerInfo2.CollectMoneyCode ) resList.Add( "CollectMoneyCode" );
            if ( customerInfo1.CollectMoneyName != customerInfo2.CollectMoneyName ) resList.Add( "CollectMoneyName" );
            if ( customerInfo1.CollectMoneyDay != customerInfo2.CollectMoneyDay ) resList.Add( "CollectMoneyDay" );
            if ( customerInfo1.CollectCond != customerInfo2.CollectCond ) resList.Add( "CollectCond" );
            if ( customerInfo1.CollectSight != customerInfo2.CollectSight ) resList.Add( "CollectSight" );
            if ( customerInfo1.ClaimCode != customerInfo2.ClaimCode ) resList.Add( "ClaimCode" );
            if ( customerInfo1.TransStopDate != customerInfo2.TransStopDate ) resList.Add( "TransStopDate" );
            if ( customerInfo1.DmOutCode != customerInfo2.DmOutCode ) resList.Add( "DmOutCode" );
            if ( customerInfo1.DmOutName != customerInfo2.DmOutName ) resList.Add( "DmOutName" );
            if ( customerInfo1.MainSendMailAddrCd != customerInfo2.MainSendMailAddrCd ) resList.Add( "MainSendMailAddrCd" );
            if ( customerInfo1.MailAddrKindCode1 != customerInfo2.MailAddrKindCode1 ) resList.Add( "MailAddrKindCode1" );
            if ( customerInfo1.MailAddrKindName1 != customerInfo2.MailAddrKindName1 ) resList.Add( "MailAddrKindName1" );
            if ( customerInfo1.MailAddress1 != customerInfo2.MailAddress1 ) resList.Add( "MailAddress1" );
            if ( customerInfo1.MailSendCode1 != customerInfo2.MailSendCode1 ) resList.Add( "MailSendCode1" );
            if ( customerInfo1.MailSendName1 != customerInfo2.MailSendName1 ) resList.Add( "MailSendName1" );
            if ( customerInfo1.MailAddrKindCode2 != customerInfo2.MailAddrKindCode2 ) resList.Add( "MailAddrKindCode2" );
            if ( customerInfo1.MailAddrKindName2 != customerInfo2.MailAddrKindName2 ) resList.Add( "MailAddrKindName2" );
            if ( customerInfo1.MailAddress2 != customerInfo2.MailAddress2 ) resList.Add( "MailAddress2" );
            if ( customerInfo1.MailSendCode2 != customerInfo2.MailSendCode2 ) resList.Add( "MailSendCode2" );
            if ( customerInfo1.MailSendName2 != customerInfo2.MailSendName2 ) resList.Add( "MailSendName2" );
            if ( customerInfo1.CustomerAgentCd != customerInfo2.CustomerAgentCd ) resList.Add( "CustomerAgentCd" );
            if ( customerInfo1.BillCollecterCd != customerInfo2.BillCollecterCd ) resList.Add( "BillCollecterCd" );
            if ( customerInfo1.OldCustomerAgentCd != customerInfo2.OldCustomerAgentCd ) resList.Add( "OldCustomerAgentCd" );
            if ( customerInfo1.CustAgentChgDate != customerInfo2.CustAgentChgDate ) resList.Add( "CustAgentChgDate" );
            if ( customerInfo1.AcceptWholeSale != customerInfo2.AcceptWholeSale ) resList.Add( "AcceptWholeSale" );
            if ( customerInfo1.CreditMngCode != customerInfo2.CreditMngCode ) resList.Add( "CreditMngCode" );
            if ( customerInfo1.DepoDelCode != customerInfo2.DepoDelCode ) resList.Add( "DepoDelCode" );
            if ( customerInfo1.AccRecDivCd != customerInfo2.AccRecDivCd ) resList.Add( "AccRecDivCd" );
            if ( customerInfo1.CustSlipNoMngCd != customerInfo2.CustSlipNoMngCd ) resList.Add( "CustSlipNoMngCd" );
            if ( customerInfo1.PureCode != customerInfo2.PureCode ) resList.Add( "PureCode" );
            if ( customerInfo1.CustCTaXLayRefCd != customerInfo2.CustCTaXLayRefCd ) resList.Add( "CustCTaXLayRefCd" );
            if ( customerInfo1.ConsTaxLayMethod != customerInfo2.ConsTaxLayMethod ) resList.Add( "ConsTaxLayMethod" );
            if ( customerInfo1.TotalAmountDispWayCd != customerInfo2.TotalAmountDispWayCd ) resList.Add( "TotalAmountDispWayCd" );
            if ( customerInfo1.TotalAmntDspWayRef != customerInfo2.TotalAmntDspWayRef ) resList.Add( "TotalAmntDspWayRef" );
            if ( customerInfo1.AccountNoInfo1 != customerInfo2.AccountNoInfo1 ) resList.Add( "AccountNoInfo1" );
            if ( customerInfo1.AccountNoInfo2 != customerInfo2.AccountNoInfo2 ) resList.Add( "AccountNoInfo2" );
            if ( customerInfo1.AccountNoInfo3 != customerInfo2.AccountNoInfo3 ) resList.Add( "AccountNoInfo3" );
            if ( customerInfo1.SalesUnPrcFrcProcCd != customerInfo2.SalesUnPrcFrcProcCd ) resList.Add( "SalesUnPrcFrcProcCd" );
            if ( customerInfo1.SalesMoneyFrcProcCd != customerInfo2.SalesMoneyFrcProcCd ) resList.Add( "SalesMoneyFrcProcCd" );
            if ( customerInfo1.SalesCnsTaxFrcProcCd != customerInfo2.SalesCnsTaxFrcProcCd ) resList.Add( "SalesCnsTaxFrcProcCd" );
            if ( customerInfo1.CustomerSlipNoDiv != customerInfo2.CustomerSlipNoDiv ) resList.Add( "CustomerSlipNoDiv" );
            if ( customerInfo1.NTimeCalcStDate != customerInfo2.NTimeCalcStDate ) resList.Add( "NTimeCalcStDate" );
            if ( customerInfo1.CustomerAgent != customerInfo2.CustomerAgent ) resList.Add( "CustomerAgent" );
            if ( customerInfo1.ClaimSectionCode != customerInfo2.ClaimSectionCode ) resList.Add( "ClaimSectionCode" );
            if ( customerInfo1.CarMngDivCd != customerInfo2.CarMngDivCd ) resList.Add( "CarMngDivCd" );
            if ( customerInfo1.BillPartsNoPrtCd != customerInfo2.BillPartsNoPrtCd ) resList.Add( "BillPartsNoPrtCd" );
            if ( customerInfo1.DeliPartsNoPrtCd != customerInfo2.DeliPartsNoPrtCd ) resList.Add( "DeliPartsNoPrtCd" );
            if ( customerInfo1.DefSalesSlipCd != customerInfo2.DefSalesSlipCd ) resList.Add( "DefSalesSlipCd" );
            if ( customerInfo1.LavorRateRank != customerInfo2.LavorRateRank ) resList.Add( "LavorRateRank" );
            if ( customerInfo1.SlipTtlPrn != customerInfo2.SlipTtlPrn ) resList.Add( "SlipTtlPrn" );
            if ( customerInfo1.DepoBankCode != customerInfo2.DepoBankCode ) resList.Add( "DepoBankCode" );
            if ( customerInfo1.CustWarehouseCd != customerInfo2.CustWarehouseCd ) resList.Add( "CustWarehouseCd" );
            if ( customerInfo1.QrcodePrtCd != customerInfo2.QrcodePrtCd ) resList.Add( "QrcodePrtCd" );
            if ( customerInfo1.DeliHonorificTtl != customerInfo2.DeliHonorificTtl ) resList.Add( "DeliHonorificTtl" );
            if ( customerInfo1.BillHonorificTtl != customerInfo2.BillHonorificTtl ) resList.Add( "BillHonorificTtl" );
            if ( customerInfo1.EstmHonorificTtl != customerInfo2.EstmHonorificTtl ) resList.Add( "EstmHonorificTtl" );
            if ( customerInfo1.RectHonorificTtl != customerInfo2.RectHonorificTtl ) resList.Add( "RectHonorificTtl" );
            if ( customerInfo1.DeliHonorTtlPrtDiv != customerInfo2.DeliHonorTtlPrtDiv ) resList.Add( "DeliHonorTtlPrtDiv" );
            if ( customerInfo1.BillHonorTtlPrtDiv != customerInfo2.BillHonorTtlPrtDiv ) resList.Add( "BillHonorTtlPrtDiv" );
            if ( customerInfo1.EstmHonorTtlPrtDiv != customerInfo2.EstmHonorTtlPrtDiv ) resList.Add( "EstmHonorTtlPrtDiv" );
            if ( customerInfo1.RectHonorTtlPrtDiv != customerInfo2.RectHonorTtlPrtDiv ) resList.Add( "RectHonorTtlPrtDiv" );
            if ( customerInfo1.Note1 != customerInfo2.Note1 ) resList.Add( "Note1" );
            if ( customerInfo1.Note2 != customerInfo2.Note2 ) resList.Add( "Note2" );
            if ( customerInfo1.Note3 != customerInfo2.Note3 ) resList.Add( "Note3" );
            if ( customerInfo1.Note4 != customerInfo2.Note4 ) resList.Add( "Note4" );
            if ( customerInfo1.Note5 != customerInfo2.Note5 ) resList.Add( "Note5" );
            if ( customerInfo1.Note6 != customerInfo2.Note6 ) resList.Add( "Note6" );
            if ( customerInfo1.Note7 != customerInfo2.Note7 ) resList.Add( "Note7" );
            if ( customerInfo1.Note8 != customerInfo2.Note8 ) resList.Add( "Note8" );
            if ( customerInfo1.Note9 != customerInfo2.Note9 ) resList.Add( "Note9" );
            if ( customerInfo1.Note10 != customerInfo2.Note10 ) resList.Add( "Note10" );
            if ( customerInfo1.SalesAreaName != customerInfo2.SalesAreaName ) resList.Add( "SalesAreaName" );
            if ( customerInfo1.ClaimName != customerInfo2.ClaimName ) resList.Add( "ClaimName" );
            if ( customerInfo1.ClaimName2 != customerInfo2.ClaimName2 ) resList.Add( "ClaimName2" );
            if ( customerInfo1.ClaimSnm != customerInfo2.ClaimSnm ) resList.Add( "ClaimSnm" );
            if ( customerInfo1.CustomerAgentNm != customerInfo2.CustomerAgentNm ) resList.Add( "CustomerAgentNm" );
            if ( customerInfo1.OldCustomerAgentNm != customerInfo2.OldCustomerAgentNm ) resList.Add( "OldCustomerAgentNm" );
            if ( customerInfo1.ClaimSectionName != customerInfo2.ClaimSectionName ) resList.Add( "ClaimSectionName" );
            if ( customerInfo1.DepoBankName != customerInfo2.DepoBankName ) resList.Add( "DepoBankName" );
            if ( customerInfo1.CustWarehouseName != customerInfo2.CustWarehouseName ) resList.Add( "CustWarehouseName" );
            if ( customerInfo1.MngSectionName != customerInfo2.MngSectionName ) resList.Add( "MngSectionName" );
            if ( customerInfo1.EnterpriseName != customerInfo2.EnterpriseName ) resList.Add( "EnterpriseName" );
            if ( customerInfo1.UpdEmployeeName != customerInfo2.UpdEmployeeName ) resList.Add( "UpdEmployeeName" );
            if ( customerInfo1.JobTypeName != customerInfo2.JobTypeName ) resList.Add( "JobTypeName" );
            if ( customerInfo1.BusinessTypeName != customerInfo2.BusinessTypeName ) resList.Add( "BusinessTypeName" );
            if ( customerInfo1.InpSectionName != customerInfo2.InpSectionName ) resList.Add( "InpSectionName" );
            if ( customerInfo1.BillOutPutCodeNm != customerInfo2.BillOutPutCodeNm ) resList.Add( "BillOutPutCodeNm" );
            if (customerInfo1.BillCollecterNm != customerInfo2.BillCollecterNm) resList.Add("BillCollecterNm");
            if (customerInfo1.SalesSlipPrtDiv != customerInfo2.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (customerInfo1.AcpOdrrSlipPrtDiv != customerInfo2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (customerInfo1.ShipmSlipPrtDiv != customerInfo2.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (customerInfo1.EstimatePrtDiv != customerInfo2.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (customerInfo1.UOESlipPrtDiv != customerInfo2.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (customerInfo1.ReceiptOutputCode != customerInfo2.ReceiptOutputCode) resList.Add("ReceiptOutputCode");
            // ADD 2009/06/03 ------>>>
            if (customerInfo1.CustomerEpCode != customerInfo2.CustomerEpCode) resList.Add("CustomerEpCode");
            if (customerInfo1.CustomerSecCode != customerInfo2.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            if (customerInfo1.SimplInqAcntAcntGrId != customerInfo2.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            if (customerInfo1.OnlineKindDiv != customerInfo2.OnlineKindDiv) resList.Add("OnlineKindDiv");
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            if (customerInfo1.TotalBillOutputDiv != customerInfo2.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (customerInfo1.DetailBillOutputCode != customerInfo2.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (customerInfo1.SlipTtlBillOutputDiv != customerInfo2.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            // ADD 陳健 K2014/02/06--------------------------->>>>>
            if (customerInfo1.NoteInfo != customerInfo2.NoteInfo) resList.Add("NoteInfo");
            // ADD 陳健 K2014/02/06---------------------------<<<<<
            // ADD 梶谷 貴士 2021/05/10 ------------------------------>>>>>>
            if (customerInfo1.DisplayDivCode != customerInfo2.DisplayDivCode) resList.Add("DisplayDivCode");
            // ADD 梶谷 貴士 2021/05/10 ------------------------------<<<<<<
            return resList;
        }
        # endregion

        # region [publicメソッド（手動追加）]
        /// <summary>
        /// 諸口名称取得処理
        /// </summary>
        /// <param name="outputNameCode">諸口コード</param>
        /// <returns>諸口名称</returns>
        public static string GetOutputName( int outputNameCode )
        {
            switch ( outputNameCode )
            {
                case 0:
                    {
                        return CST_OutputName_0;
                    }
                case 1:
                    {
                        return CST_OutputName_1;
                    }
                case 2:
                    {
                        return CST_OutputName_2;
                    }
                case 3:
                    {
                        return CST_OutputName_3;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 集金月区分名称取得処理
        /// </summary>
        /// <param name="collectMoneyCode">集金月区分コード</param>
        /// <returns>集金月区分名称</returns>
        public static string GetCollectMoneyName( int collectMoneyCode )
        {
            switch ( collectMoneyCode )
            {
                case 0:
                    {
                        return CST_CollectMoneyName_0;
                    }
                case 1:
                    {
                        return CST_CollectMoneyName_1;
                    }
                case 2:
                    {
                        return CST_CollectMoneyName_2;
                    }
                case 3:
                    {
                        return CST_CollectMoneyName_3;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 個人・法人区分名称取得処理
        /// </summary>
        /// <param name="corporateDivCode">個人・法人区分</param>
        /// <returns>個人・法人区分名称</returns>
        public static string GetPrslOrCorpDivNm( int corporateDivCode )
        {
            switch ( corporateDivCode )
            {
                case 0:
                    {
                        return CST_CorporateDivName_0;
                    }
                case 1:
                    {
                        return CST_CorporateDivName_1;
                    }
                case 2:
                    {
                        return CST_CorporateDivName_2;
                    }
                case 3:
                    {
                        return CST_CorporateDivName_3;
                    }
                case 4:
                    {
                        return CST_CorporateDivName_4;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 請求書出力区分名称取得処理
        /// </summary>
        /// <param name="billOutputCode">請求書出力区分コード</param>
        /// <returns>請求書出力区分名称</returns>
        public static string GetBillOutputName( int billOutputCode )
        {
            switch ( billOutputCode )
            {
                case 0:
                    {
                        return CST_BillOutputName_0;
                    }
                case 1:
                    {
                        return CST_BillOutputName_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// DM出力区分名称取得処理
        /// </summary>
        /// <param name="dmOutCode">DM出力区分</param>
        /// <returns>DM出力区分名称</returns>
        public static string GetDmOutName( int dmOutCode )
        {
            switch ( dmOutCode )
            {
                case 0:
                    {
                        return CST_DmOutName_0;
                    }
                case 1:
                    {
                        return CST_DmOutName_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// 消費税転嫁方式名称取得処理
        /// </summary>
        /// <param name="consTaxLayMethod">消費税転嫁方式区分</param>
        /// <returns>消費税転嫁方式名称</returns>
        public static string GetConsTaxLayMethodName( int consTaxLayMethod )
        {
            switch ( consTaxLayMethod )
            {
                case 0:
                    {
                        return CST_ConsTaxLayMethod_0;
                    }
                case 1:
                    {
                        return CST_ConsTaxLayMethod_1;
                    }
                case 2:
                    {
                        return CST_ConsTaxLayMethod_2;
                    }
                case 3:
                    {
                        return CST_ConsTaxLayMethod_3;
                    }
                case 9:
                    {
                        return CST_ConsTaxLayMethod_9;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 総額表示方法区分名称取得処理
        /// </summary>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <returns>総額表示方法区分名称</returns>
        public static string GetTotalAmountDispWayCdName( int totalAmountDispWayCd )
        {
            switch ( totalAmountDispWayCd )
            {
                case 0:
                    {
                        return CST_TotalAmountDispWayCd_0;
                    }
                case 1:
                    {
                        return CST_TotalAmountDispWayCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 総額表示方法参照区分名称取得処理
        /// </summary>
        /// <param name="totalAmntDspWayRef">総額表示方法参照区分</param>
        /// <returns>総額表示方法参照区分名称</returns>
        public static string GetTotalAmntDspWayRefName( int totalAmntDspWayRef )
        {
            switch ( totalAmntDspWayRef )
            {
                case 0:
                    {
                        return CST_TotalAmntDspWayRef_0;
                    }
                case 1:
                    {
                        return CST_TotalAmntDspWayRef_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// 得意先消費税転嫁方式参照区分 名称取得処理
        /// </summary>
        /// <param name="CustCTaXLayRefCd">得意先消費税転嫁方式参照区分</param>
        /// <returns>得意先消費税転嫁方式参照区分 名称</returns>
        public static string GetCustCTaXLayRefCdName( int CustCTaXLayRefCd )
        {
            switch ( CustCTaXLayRefCd )
            {
                case 0:
                    {
                        return CST_CustCTaXLayRefCd_0;
                    }
                case 1:
                    {
                        return CST_CustCTaXLayRefCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// 主連絡先区分名称取得処理
        /// </summary>
        /// <param name="mainContactCode">主連絡先区分</param>
        /// <returns>主連絡先区分名称</returns>
        public string GetMainContactName( int mainContactCode )
        {
            return GetMainContactName( mainContactCode, 0 );
        }

        /// <summary>
        /// 主連絡先区分名称取得処理
        /// </summary>
        /// <param name="mainContactCode">主連絡先区分</param>
        /// <param name="mode">0:通常 1:略称</param>
        /// <returns>主連絡先区分名称</returns>
        public string GetMainContactName( int mainContactCode, int mode )
        {
            switch ( mainContactCode )
            {
                case 0:
                    {
                        return this.HomeTelNoDspName;
                    }
                case 1:
                    {
                        return this.OfficeTelNoDspName;
                    }
                case 2:
                    {
                        return this.MobileTelNoDspName;
                    }
                case 3:
                    {
                        return this.HomeFaxNoDspName;
                    }
                case 4:
                    {
                        return this.OfficeFaxNoDspName;
                    }
                case 5:
                    {
                        return this.OtherTelNoDspName;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// メール送信区分名称取得処理
        /// </summary>
        /// <param name="mailSendCode">メール送信区分コード</param>
        /// <returns>メール送信区分名称</returns>
        public static string GetMailSendName( int mailSendCode )
        {
            switch ( mailSendCode )
            {
                case 0:
                    {
                        return CST_MailSendName_0;
                    }
                case 1:
                    {
                        return CST_MailSendName_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// メールアドレス種別名称取得処理
        /// </summary>
        /// <param name="mailAddrKindCode">メールアドレス種別コード</param>
        /// <returns>メールアドレス種別名称</returns>
        public static string GetMailAddrKindName( int mailAddrKindCode )
        {
            switch ( mailAddrKindCode )
            {
                case 0:
                    {
                        return CST_MailAddrKindName_0;
                    }
                case 1:
                    {
                        return CST_MailAddrKindName_1;
                    }
                case 2:
                    {
                        return CST_MailAddrKindName_2;
                    }
                case 3:
                    {
                        return CST_MailAddrKindName_3;
                    }
                case 99:
                    {
                        return CST_MailAddrKindName_99;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>得意先属性区分名称取得処理</summary>
        /// <param name="CustomerAttributeDiv">得意先属性区分値</param>
        /// <returns>名称</returns>
        public static string GetCustomerAttributeDivName( int CustomerAttributeDiv )
        {
            switch ( CustomerAttributeDiv )
            {
                case 0:
                    {
                        return CST_CustomerAttributeDiv_0;
                    }
                case 8:
                    {
                        return CST_CustomerAttributeDiv_8;
                    }
                case 9:
                    {
                        return CST_CustomerAttributeDiv_9;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>得意先種別区分名称取得処理</summary>
        /// <param name="CustomerDivCd">得意先種別区分</param>
        /// <returns>名称</returns>
        public static string GetCustomerDivCdName( int CustomerDivCd )
        {
            switch ( CustomerDivCd )
            {
                case 0:
                    {
                        return CST_CustomerDivCd_0;
                    }
                case 1:
                    {
                        return CST_CustomerDivCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>回収条件名称取得処理</summary>
        /// <param name="CollectCond">回収条件値</param>
        /// <returns>名称</returns>
        public static string GetCollectCondName( int CollectCond )
        {
            switch ( CollectCond )
            {
                case 10:
                    {
                        return CST_CollectCond_10;
                    }
                case 20:
                    {
                        return CST_CollectCond_20;
                    }
                case 30:
                    {
                        return CST_CollectCond_30;
                    }
                case 40:
                    {
                        return CST_CollectCond_40;
                    }
                case 50:
                    {
                        return CST_CollectCond_50;
                    }
                case 60:
                    {
                        return CST_CollectCond_60;
                    }
                case 70:
                    {
                        return CST_CollectCond_70;
                    }
                case 80:
                    {
                        return CST_CollectCond_80;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>与信管理区分名称取得処理</summary>
        /// <param name="CreditMngCode">与信管理区分値</param>
        /// <returns>名称</returns>
        public static string GetCreditMngCodeName( int CreditMngCode )
        {
            switch ( CreditMngCode )
            {
                case 0:
                    {
                        return CST_CreditMngCode_0;
                    }
                case 1:
                    {
                        return CST_CreditMngCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>入金消込区分名称取得処理</summary>
        /// <param name="DepoDelCode">入金消込区分値</param>
        /// <returns>名称</returns>
        public static string GetDepoDelCodeName( int DepoDelCode )
        {
            switch ( DepoDelCode )
            {
                case 0:
                    {
                        return CST_DepoDelCode_0;
                    }
                case 1:
                    {
                        return CST_DepoDelCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>売掛区分名称取得処理</summary>
        /// <param name="AccRecDivCd">売掛区分値</param>
        /// <returns>名称</returns>
        public static string GetAccRecDivCdName( int AccRecDivCd )
        {
            switch ( AccRecDivCd )
            {
                case 0:
                    {
                        return CST_AccRecDivCd_0;
                    }
                case 1:
                    {
                        return CST_AccRecDivCd_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>元号区分名称取得処理</summary>
        /// <param name="EraNameCode">元号区分値</param>
        /// <returns>名称</returns>
        public static string GetEraNameCodeName( int EraNameCode )
        {
            switch ( EraNameCode )
            {
                case 0:
                    {
                        return CST_EraNameCode_0;
                    }
                case 1:
                    {
                        return CST_EraNameCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>相手伝票番号管理区分名称取得処理</summary>
        /// <param name="CustSlipNoMngCd">相手伝票番号管理区分値</param>
        /// <returns>名称</returns>
        public static string GetCustSlipNoMngCdName( int CustSlipNoMngCd )
        {
            switch ( CustSlipNoMngCd )
            {
                case 0:
                    {
                        return CST_CustSlipNoMngCd_0;
                    }
                case 1:
                    {
                        return CST_CustSlipNoMngCd_1;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
                case 2:
                    {
                        return CST_CustSlipNoMngCd_2;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
        ///// <summary>純正区分名称取得処理</summary>
        ///// <param name="PureCode">純正区分値</param>
        ///// <returns>名称</returns>
        //public static string GetPureCodeName( int PureCode )
        //{
        //    switch ( PureCode )
        //    {
        //        case 0:
        //            {
        //                return CST_PureCode_0;
        //            }
        //        case 1:
        //            {
        //                return CST_PureCode_1;
        //            }
        //        default:
        //            {
        //                return string.Empty;
        //            }
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
        /// <summary>得意先伝票番号区分名称取得処理</summary>
        /// <param name="CusotomerSlipNoDiv">得意先伝票番号区分</param>
        /// <returns>名称</returns>
        public static string GetCustomerSlipNoDivName( int CusotomerSlipNoDiv )
        {
            switch ( CusotomerSlipNoDiv )
            {
                case 0:
                    {
                        return CST_CustomerSlipNoDiv_0;
                    }
                case 1:
                    {
                        return CST_CustomerSlipNoDiv_1;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/12 ADD
                case 2:
                    {
                        return CST_CustomerSlipNoDiv_2;
                    }
                case 3:
                    {
                        return CST_CustomerSlipNoDiv_3;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/12 ADD
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// 領収書出力区分名称取得処理
        /// </summary>
        /// <param name="receiptOutputCode">領収書出力区分コード</param>
        /// <returns>領収書出力区分名称</returns>
        public static string GetReceiptOutputName(int receiptOutputCode)
        {
            switch (receiptOutputCode)
            {
                case 0:
                    {
                        return CST_ReceiptOutputCode_0;
                    }
                case 1:
                    {
                        return CST_ReceiptOutputCode_1;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// オンライン種別区分名称取得処理
        /// </summary>
        /// <param name="onlineKindDiv">オンライン種別区分</param>
        /// <returns>オンライン種別区分名称</returns>
        public static string GetOnlineKindDivName(int onlineKindDiv)
        {
            switch (onlineKindDiv)
            {
                case 0:
                    {
                        return CST_OnlineKindDiv_0;
                    }
                case 10:
                    {
                        return CST_OnlineKindDiv_10;
                    }
                case 20:
                    {
                        return CST_OnlineKindDiv_20;
                    }
                case 30:
                    {
                        return CST_OnlineKindDiv_30;
                    }
                case 40:
                    {
                        return CST_OnlineKindDiv_40;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
        /// <summary>
        /// 合計請求書出力区分名称取得処理
        /// </summary>
        /// <param name="totalBillOutputDiv">合計請求書出力区分</param>
        /// <returns>合計請求書出力区分名称</returns>
        public static string GetTotalBillOutputDiv(int totalBillOutputDiv)
        {
            switch (totalBillOutputDiv)
            {
                case 0:
                    {
                        return CST_TotalBillOutputDiv_0;
                    }
                case 1:
                    {
                        return CST_TotalBillOutputDiv_1;
                    }
                case 2:
                    {
                        return CST_TotalBillOutputDiv_2;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// 明細請求書出力区分取得処理
        /// </summary>
        /// <param name="detailBillOutputCode">明細請求書出力区分</param>
        /// <returns>明細請求書出力区分名称</returns>  
        public static string GetDetailBillOutputCode(int detailBillOutputCode)
        {
            switch (detailBillOutputCode)
            {
                case 0:
                    {
                        return CST_DetailBillOutputCode_0;
                    }
                case 1:
                    {
                        return CST_DetailBillOutputCode_1;
                    }
                case 2:
                    {
                        return CST_DetailBillOutputCode_2;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        /// <summary>
        /// 伝票合計請求書出力区分名称取得処理
        /// </summary>
        /// <param name="slipTtlBillOutputDiv">伝票合計請求書出力区分</param>
        /// <returns>伝票合計請求書出力区分名称</returns>
        public static string GetSlipTtlBillOutputDiv(int slipTtlBillOutputDiv)
        {
            switch (slipTtlBillOutputDiv)
            {
                case 0:
                    {
                        return CST_SlipTtlBillOutputDiv_0;
                    }
                case 1:
                    {
                        return CST_SlipTtlBillOutputDiv_1;
                    }
                case 2:
                    {
                        return CST_SlipTtlBillOutputDiv_2;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
        # endregion
    }
}
