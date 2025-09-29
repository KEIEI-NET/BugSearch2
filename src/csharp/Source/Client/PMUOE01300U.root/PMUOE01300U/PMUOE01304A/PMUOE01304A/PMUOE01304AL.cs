//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/14  修正内容 : 受信電文で、数値項目にスペースが入ってきた場合の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/08/06  修正内容 : TEL発注分の場合はUOE発注番号と行番号を強制的に0にする。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangmj
// 作 成 日  2012/12/10  修正内容 : 1月16日配信分、redmine#32926PMデータと連携が取れないの対応。
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 鄧潘ハン
// 作 成 日  2013/10/09  修正内容 : Redmine 40628のNo36点、原単価の対応
//----------------------------------------------------------------------------//
// 管理番号  12100013-00 作成担当 : 陳艶丹
// 作 成 日  2025/01/10  修正内容 : PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;       // 2009/10/14 Add

namespace Broadleaf.Application.Controller
{
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using UOEGuideNameDB= SingletonPolicy<UOEGuideNameDBAgent>;
    using MakerMasterDB = SingletonPolicy<MakerMasterDBAgent>;
    using System.Threading;
    using Broadleaf.Application.Resources;
    using Broadleaf.Application.Common;

    /// <summary>
    /// UOE発注データの構築者クラス
    /// </summary>
    public abstract class UOEOrderDataBuilder : OrderInformationBuilder
    {
        #region <進捗情報/>

        /// <summary>処理中のメッセージ</summary>
        protected const string NOW_RUNNING = "UOE発注データを作成中";   // LITERAL:

        /// <summary>進捗情報</summary>
        private readonly UpdateProgressEventArgs _progressInfo = new UpdateProgressEventArgs(NOW_RUNNING, 0, 0);
        /// <summary>
        /// 進捗情報を取得します。
        /// </summary>
        protected UpdateProgressEventArgs ProgressInfo { get { return _progressInfo; } }

        #endregion  // <進捗情報/>

        #region <オンライン行番号の採番/>

        /// <summary>オンライン行番号のカウンタ</summary>
        protected int _onlineRowNoCount;

        #endregion  // <オンライン行番号の採番/>

        #region <現在のUOE発注データの明細レコード/>

        /// <summary>現在のUOE発注データの明細レコード</summary>
        private UOEOrderDtlWork _currentUOEOrderDetailRecord;
        /// <summary>
        /// 現在のUOE発注データの明細レコードのアクセサ
        /// </summary>
        /// <value>現在のUOE発注データの明細レコード</value>
        protected UOEOrderDtlWork CurrentUOEOrderDetailRecord
        {
            get { return _currentUOEOrderDetailRecord; }
            set { _currentUOEOrderDetailRecord = value; }
        }

        #endregion  // <現在のUOE発注データの明細レコード/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="receivedTelegramAgreegate">受信電文の集合体</param>
        /// <param name="observer">簡易オブザーバー</param>
        protected UOEOrderDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// UOE発注データに受信電文の内容をマージします。
        /// </summary>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2025/01/10</br>
        /// </remarks>
        public override void Merge()
        {
            ProgressInfo.IsRunning = true;
            ProgressInfo.Max = ReceivedTelegramAgreegate.Size;

            IIterator<ReceivedText> receivedTelegramIterator = ReceivedTelegramAgreegate.CreateIterator();
            while (receivedTelegramIterator.HasNext())
            {
                Observer.Update(ProgressInfo);

                bool isNewRecord = false;

                // マージするUOE発注データの明細レコードを設定
                ReceivedText receivedTelegram = receivedTelegramIterator.GetNext();
                if (receivedTelegram.IsTelephoneOrder())
                {
                    // TEL発注分（電文問合せ番号 == 0）…普通に新規登録
                    CurrentUOEOrderDetailRecord = new UOEOrderDtlWork();
                    isNewRecord = true;
                }
                else
                {
                    // UOE発注分（電文問合せ番号 != 0）…既存のレコードを元に新規登録
                    CurrentUOEOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
                    if (CurrentUOEOrderDetailRecord == null)
                    {
                        receivedTelegram.IsTelephoneOrderForced = true;
                        CurrentUOEOrderDetailRecord = new UOEOrderDtlWork();
                        isNewRecord = true;
                    }
                }

                // --- ADD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応 ----->>>>>
                MergeDtlRelationGiid(receivedTelegram);         // 120.明細関連付けGUID
                if (StockDB.Instance.Policy.FindStockDetailWork(receivedTelegram) == null)
                    receivedTelegram.IsTelephoneOrderForced = true;
                // --- ADD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応 -----<<<<<

                // 受信電文の内容をマージ
                MergeEnterpriseCode(receivedTelegram);          // 003.企業コード
                MergeSystemDivCd(receivedTelegram);             // 009.システム区分
                // add 2012/08/06 >>>
                if (receivedTelegram.IsTelephoneOrderForced)
                {
                    CurrentUOEOrderDetailRecord.UOESalesOrderNo = 0;
                    CurrentUOEOrderDetailRecord.UOESalesOrderRowNo = 0;
                }
                else
                {
                    // add 2012/08/06 <<<
                    MergeUOESalesOrderNo(receivedTelegram);         // 010.UOE発注番号
                    MergeUOESalesOrderRowNo(receivedTelegram);      // 011.UOE発注行番号
                }   // add 2012/08/06
                MergeSendTerminalNo(receivedTelegram);          // 012.送信端末番号
                MergeUOESupplierCd(receivedTelegram);           // 013.UOE発注先コード
                MergeUOESupplierName(receivedTelegram);         // 014.UOE発注先名称
                MergeCommAssemblyId(receivedTelegram);          // 015.通信アセンブリID
                MergeOnlineNo(receivedTelegram);                // 016.オンライン番号
                MergeOnlineRowNo(receivedTelegram);             // 017.オンライン行番号
                MergeInputDay(receivedTelegram);                // 019.入力日
                MergeDataUpdateDateTime(receivedTelegram);      // 020.データ更新日時
                MergeUOEKind(receivedTelegram);                 // 021.UOE種別
                MergeSectionCode(receivedTelegram);             // 025.拠点コード
                MergeSubSectionCode(receivedTelegram);          // 026.部門コード
                MergeCashRegisterNo(receivedTelegram);          // 029.端末番号
                MergeSupplierFormal(receivedTelegram);          // 031.仕入形式
                MergeBoCode(receivedTelegram);                  // 034.BO区分
                MergeUOEDeliGoodsDiv(receivedTelegram);         // 035.納品区分
                MergeDeliveredGoodsDivNm(receivedTelegram);     // 036.納品区分名称
                MergeEmployeeCode(receivedTelegram);            // 041.従業員コード
                MergeEmployeeName(receivedTelegram);            // 042.従業員名称
                MergeGoodsMakerCd(receivedTelegram);            // 043.商品メーカーコード
                MergeMakerName(receivedTelegram);               // 044.メーカー名称
                MergeGoodsNo(receivedTelegram);                 // 045.商品番号
                MergeGoodsNoNoneHyphen(receivedTelegram);       // 046.ハイフン無商品番号
                MergeGoodsName(receivedTelegram);               // 047.商品名称
                {
                    MergeWarehouseCode(receivedTelegram);       // 048.倉庫コード
                    MergeWarehouseName(receivedTelegram);       // 049.倉庫名称
                    MergeWarehouseShelfNo(receivedTelegram);    // 050.倉庫棚番
                }
                MergeAcceptAnOrderCnt(receivedTelegram);        // 051.受注数量
                MergeSupplierCd(receivedTelegram);              // 054.仕入先コード
                MergeSupplierSnm(receivedTelegram);             // 055.仕入先略称
                MergeUoeRemark1(receivedTelegram);              // 056.UOEリマーク1
                MergeReceiveDate(receivedTelegram);             // 058.受信日付
                MergeReceiveTime(receivedTelegram);             // 059.受信時刻
                MergeAnswerMakerCd(receivedTelegram);           // 060.回答メーカーコード
                MergeAnswerPartsNo(receivedTelegram);           // 061.回答品番
                MergeAnswerPartsName(receivedTelegram);         // 062.回答品名
                MergeSubstPartsNo(receivedTelegram);            // 063.代替品番
                {
                    MergeUOESectOutGoodsCnt(receivedTelegram);  // 064.UOE拠点出庫数
                }
                MergeBOShipmentCnt1(receivedTelegram);          // 065.BO出庫数1
                MergeUOESectionSlipNo(receivedTelegram);        // 074.UOE拠点伝票番号
                MergeBOSlipNo1(receivedTelegram);               // 075.BO伝票番号1
                MergeAnswerListPrice(receivedTelegram);         // 080.回答定価
                {
                    MergeAnswerSalesUnitCost(receivedTelegram); // 081.回答原価単価
                    MergeUOEMarkCode(receivedTelegram);         // 106.UOEマークコード
                }
                MergeUOECheckCode(receivedTelegram);            // 109.チェックコード
                MergeLineErrorMessage(receivedTelegram);        // 111.ラインエラー
                MergeDataSendCode(receivedTelegram);            // 112.データ送信区分
                MergeDataRecoverDiv(receivedTelegram);          // 113.データ復旧区分
                MergeEnterUpdDivSec(receivedTelegram);          // 114.入庫更新区分（拠点）
                MergeEnterUpdDivBO1(receivedTelegram);          // 115.入庫更新区分（BO1）
                MergeEnterUpdDivBO2(receivedTelegram);          // 116.入庫更新区分（BO2）
                MergeEnterUpdDivBO3(receivedTelegram);          // 117.入庫更新区分（BO3）
                MergeEnterUpdDivMaker(receivedTelegram);        // 118.入庫更新区分（メーカー）
                MergeEnterUpdDivEO(receivedTelegram);           // 119.入庫更新区分（EO）

                //MergeDtlRelationGiid(receivedTelegram);         // 120.明細関連付けGUID // DEL 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応

                // DBへ挿入用にレコードを追加
                if (isNewRecord)
                {
                    StockDB.Instance.Policy.AddUOEOrderDtlWork(CurrentUOEOrderDetailRecord, receivedTelegram);
                }
                // 既存のレコードを元に新規登録する場合、
                // 検索されたインスタンスの値を変更しているため、新たに追加する必要なし

                ProgressInfo.Count++;
            }   // while (receivedTelegramIterator.HasNext())

            ProgressInfo.IsRunning = false;
        }

        #endregion  // <Override/>

        #region <003.企業コード/>

        /// <summary>
        /// 企業コードをマージします。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterpriseCode(ReceivedText receivedTelegram)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentUOEOrderDetailRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion  // <003.企業コード/>

        #region <009.システム区分/>

        /// <summary>
        /// システム区分をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合にはセットし、
        /// <c>0</c>以外の場合には元データのシステム区分をセット
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSystemDivCd(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                CurrentUOEOrderDetailRecord.SystemDivCd = ReceivedText.SALES_ORDER_NO_BY_TELEPHONE;
            }
        }

        #endregion  // <9.システム区分/>

        #region <010.UOE発注番号/>

        /// <summary>
        /// UOE発注番号をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOESalesOrderNo(ReceivedText receivedTelegram)
        {
            int uoeSalesOrderNo = int.Parse(receivedTelegram.UOESalesOrderNo);
            CurrentUOEOrderDetailRecord.UOESalesOrderNo = uoeSalesOrderNo;
        }

        #endregion  // <10.UOE発注番号/>

        #region <011.UOE発注行番号/>

        /// <summary>
        /// UOE発注行番号をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の回答電文対応行
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOESalesOrderRowNo(ReceivedText receivedTelegram)
        {
            int uoeSalesOrderRowNo = int.Parse(receivedTelegram.UOESalesOrderRowNo);

            if (receivedTelegram.IsTelephoneOrder() || uoeSalesOrderRowNo.Equals(0))
            {
                uoeSalesOrderRowNo = GetRowNoOfTelOrder(receivedTelegram.UOESectionSlipNo);
            }

            CurrentUOEOrderDetailRecord.UOESalesOrderRowNo = uoeSalesOrderRowNo;
        }

        #endregion  // <011.UOE発注行番号/>

        #region <012.送信端末番号/>

        /// <summary>
        /// 送信端末番号をマージします。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSendTerminalNo(ReceivedText receivedTelegram)
        {
            int sendTerminalNo = LoginWorkerAcs.Instance.Policy.CashRegisterNo;
            CurrentUOEOrderDetailRecord.SendTerminalNo = sendTerminalNo;
        }

        #endregion  // <012.送信端末番号/>

        #region <013.UOE発注先コード/>

        /// <summary>
        /// UOE発注先コードをマージします。
        /// </summary>
        /// <remarks>
        /// UIで入力した発注先コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOESupplierCd(ReceivedText receivedTelegram)
        {
            int uoeSupplierCd = UoeSupplier.RealUOESupplier.UOESupplierCd;
            CurrentUOEOrderDetailRecord.UOESupplierCd = uoeSupplierCd;
        }

        #endregion  // <013.UOE発注先コード/>

        #region <014.UOE発注先名称/>

        /// <summary>
        /// UOE発注先名称をマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注先コードに対する名称
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOESupplierName(ReceivedText receivedTelegram)
        {
            string uoeSupplierName = UoeSupplier.RealUOESupplier.UOESupplierName.Trim();
            CurrentUOEOrderDetailRecord.UOESupplierName = uoeSupplierName;
        }

        #endregion  // <014.UOE発注先名称/>

        #region <015.通信アセンブリID/>

        /// <summary>
        /// 通信アセンブリIDをマージします。
        /// </summary>
        /// <remarks>
        /// UOE発注マスタの通信アセンブリID
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeCommAssemblyId(ReceivedText receivedTelegram)
        {
            string commAssemblyId = UoeSupplier.RealUOESupplier.CommAssemblyId.Trim();
            CurrentUOEOrderDetailRecord.CommAssemblyId = commAssemblyId;
        }

        #endregion  // <015.通信アセンブリID/>

        #region <016.オンライン番号/>

        /// <summary>
        /// オンライン番号をマージします。
        /// </summary>
        /// <remarks>
        /// リモート側で採番するため、<c>0</c>を設定…リモート側で自動的にinsertする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOnlineNo(ReceivedText receivedTelegram)
        {
            const int ONLINE_NO = 0;
            CurrentUOEOrderDetailRecord.OnlineNo = ONLINE_NO;
        }

        #endregion  // <016.オンライン番号/>

        #region <017.オンライン行番号/>

        /// <summary>
        /// オンライン行番号をマージします。
        /// </summary>
        /// <remarks>
        /// オンライン番号に対する連番　※受信した順番になる
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeOnlineRowNo(ReceivedText receivedTelegram)
        {
            int onlineRowNo = ++_onlineRowNoCount;
            CurrentUOEOrderDetailRecord.OnlineRowNo = onlineRowNo;
        }

        #endregion  // <017.オンライン行番号/>

        #region <019.入力日/>

        /// <summary>
        /// 入力日をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeInputDay(ReceivedText receivedTelegram)
        {
            DateTime inputDay = DateTime.Now;
            CurrentUOEOrderDetailRecord.InputDay = inputDay;
        }

        #endregion  // <019.入力日/>

        #region <020.データ更新日時/>

        /// <summary>
        /// データ更新日時をマージします。
        /// </summary>
        /// <remarks>
        /// システム日付・時刻（時刻表示として使用）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeDataUpdateDateTime(ReceivedText receivedTelegram)
        {
            DateTime dataUpdateDateTime = DateTime.Now;
            CurrentUOEOrderDetailRecord.DataUpdateDateTime = dataUpdateDateTime;
        }

        #endregion  // <020.データ更新日時/>

        #region <021.UOE種別/>

        /// <summary>
        /// UOE種別をマージします。
        /// </summary>
        /// <remarks>
        /// 1:卸商仕入受信
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOEKind(ReceivedText receivedTelegram)
        {
            const int UOE_KIND = 1; // 0:UOE／1:卸商仕入受信
            CurrentUOEOrderDetailRecord.UOEKind = UOE_KIND;
        }

        #endregion  // <021.UOE種別/>

        #region <025.拠点コード/>

        /// <summary>
        /// 拠点コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者の拠点コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSectionCode(ReceivedText receivedTelegram)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentUOEOrderDetailRecord.SectionCode = sectionCode;
        }

        #endregion  // <025.拠点コード/>

        #region <026.部門コード/>

        /// <summary>
        /// 部門コードをマージします。
        /// </summary>
        /// <remarks>
        /// ログイン担当者の部門コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSubSectionCode(ReceivedText receivedTelegram)
        {
            int subSectionCode = LoginWorkerAcs.Instance.Policy.Detail.BelongSubSectionCode;
            CurrentUOEOrderDetailRecord.SubSectionCode = subSectionCode;
        }

        #endregion  // <026.部門コード/>

        #region <029.端末番号/>

        /// <summary>
        /// 端末番号をマージします。
        /// </summary>
        /// <remarks>
        /// 端末番号
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeCashRegisterNo(ReceivedText receivedTelegram)
        {
            int cashRegisterNo = LoginWorkerAcs.Instance.Policy.CashRegisterNo;
            CurrentUOEOrderDetailRecord.CashRegisterNo = cashRegisterNo;
        }

        #endregion  // <029.端末番号/>

        #region <031.仕入形式/>

        /// <summary>
        /// 仕入形式をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、2:発注
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSupplierFormal(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                const int ORDER = 2;    // 2:発注
                CurrentUOEOrderDetailRecord.SupplierFormal = ORDER;
            }
        }

        #endregion  // <031.仕入形式/>

        #region <034.BO区分/>

        /// <summary>
        /// BO区分をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文のBO区分
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBoCode(ReceivedText receivedTelegram)
        {
            string boCode = receivedTelegram.BOCode;
            CurrentUOEOrderDetailRecord.BoCode = boCode;
        }

        #endregion  // <034.BO区分/>

        #region <035.納品区分/>

        /// <summary>
        /// 納品区分をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の納品区分
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOEDeliGoodsDiv(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string uoeDeliGoodsDiv = receivedTelegram.DeliveryGoodsDiv;
                CurrentUOEOrderDetailRecord.UOEDeliGoodsDiv = uoeDeliGoodsDiv;
            }
        }

        #endregion  // <035.納品区分/>

        #region <036.納品区分名称/>

        /// <summary>
        /// 納品区分名称をマージします。
        /// </summary>
        /// <remarks>
        /// UOEガイド名称マスタから取得
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeDeliveredGoodsDivNm(ReceivedText receivedTelegram)
        {
            UOEGuideName uoeGuideName = UOEGuideNameDB.Instance.Policy.Find(
                UoeSupplier.RealUOESupplier.UOESupplierCd,  // UOE発注先コード
                CurrentUOEOrderDetailRecord.UOEDeliGoodsDiv // UOE発注データの納品区分
            );
            if (uoeGuideName != null)
            {
                string deliveredGoodsDivNm = uoeGuideName.UOEGuideNm;
                CurrentUOEOrderDetailRecord.DeliveredGoodsDivNm = deliveredGoodsDivNm;
            }
        }

        #endregion  // <036.納品区分名称/>

        #region <041.従業員コード/>

        /// <summary>
        /// 従業員コードをマージします。
        /// </summary>
        /// <remarks>
        /// 元データ
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEmployeeCode(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string employeeCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
                CurrentUOEOrderDetailRecord.EmployeeCode = employeeCode;
            }
        }

        #endregion  // <041.従業員コード/>

        #region <042.従業員名称/>

        /// <summary>
        /// 従業員コードをマージします。
        /// </summary>
        /// <remarks>
        /// 元データ
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEmployeeName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string employeeName = LoginWorkerAcs.Instance.Policy.Profile.Name;
                CurrentUOEOrderDetailRecord.EmployeeName = employeeName;
            }
        }

        #endregion  // <042.従業員名称/>

        #region <043.商品メーカーコード/>

        /// <summary>
        /// 商品メーカーコードをマージします。
        /// </summary>
        /// <remarks>
        /// 元データ
        /// 受信電文の電文問合せ番号番号が0の場合には、受信電文のメーカーコード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsMakerCd(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                // 2009/10/14 >>>
                //int goodsMakerCd = int.Parse(receivedTelegram.AnswerMakerCode);
                int goodsMakerCd = TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0);
                // 2009/10/14 <<<
                CurrentUOEOrderDetailRecord.GoodsMakerCd = goodsMakerCd;
            }
        }

        #endregion  // <042.商品メーカーコード/>

        #region <044.メーカー名称/>

        /// <summary>
        /// メーカー名称をマージします。
        /// </summary>
        /// <remarks>
        /// 元データ
        /// 受信電文の電文問合せ番号番号が0の場合には、メーカーコードに対するメーカー名称（メーカーマスタより）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeMakerName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                MakerSet makerSet = MakerMasterDB.Instance.Policy.Find(CurrentUOEOrderDetailRecord.GoodsMakerCd);
                if (makerSet != null)
                {
                    string makerName = makerSet.MakerName;
                    CurrentUOEOrderDetailRecord.MakerName = makerName;
                }
            }
        }

        #endregion  // <044.メーカー名称/>

        #region <045.商品番号/>

        /// <summary>
        /// 商品番号をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、受信電文の受注部品番号
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsNo(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string goodsNo = receivedTelegram.AcceptPartsNo;
                CurrentUOEOrderDetailRecord.GoodsNo = goodsNo;
            }
        }

        #endregion  // <045.商品番号/>

        #region <046.ハイフン無商品番号/>

        /// <summary>
        /// ハイフン無商品番号をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、受信電文の受注部品番号からハイフン削除
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsNoNoneHyphen(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string goodsNoNoneHyphen = receivedTelegram.AcceptPartsNo.Replace("-", string.Empty);
                CurrentUOEOrderDetailRecord.GoodsNoNoneHyphen = goodsNoNoneHyphen;
            }
        }

        #endregion  // <046.ハイフン無商品番号/>

        #region <047.商品名称/>

        /// <summary>
        /// 商品名称をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、受信電文の品名
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeGoodsName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                string goodsName = receivedTelegram.AnswerPartsName;
                CurrentUOEOrderDetailRecord.GoodsName = goodsName;
            }
        }

        #endregion  // <047.商品名称/>

        #region <048.倉庫コード/>

        /// <summary>
        /// 倉庫コードをマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、
        /// 拠点設定マスタの倉庫コード（3つ）と
        /// 受信電文の出荷部品番号、メーカーコードで
        /// 在庫マスタの存在チェックを行い存在する倉庫コードをセットする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeWarehouseCode(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                Stock foundStock = FindStockBy3WarehouseCodes(receivedTelegram);
                if (foundStock != null)
                {
                    CurrentUOEOrderDetailRecord.WarehouseCode = foundStock.WarehouseCode;
                }
            }
        }

        #endregion  // <048.倉庫コード/>

        #region <049.倉庫名称/>

        /// <summary>
        /// 倉庫名称をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、
        /// 拠点設定マスタの倉庫コード（3つ）と
        /// 受信電文の出荷部品番号、メーカーコードで
        /// 在庫マスタの存在チェックを行い存在する倉庫名称をセットする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeWarehouseName(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                Stock foundStock = FindStockBy3WarehouseCodes(receivedTelegram);
                if (foundStock != null)
                {
                    CurrentUOEOrderDetailRecord.WarehouseName = foundStock.WarehouseName;
                }
            }
        }

        #endregion  // <049.倉庫名称/>

        #region <050.倉庫棚番/>

        /// <summary>
        /// 倉庫棚番をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の電文問合せ番号が<c>0</c>の場合には、
        /// 拠点設定マスタの倉庫コード（3つ）と
        /// 受信電文の出荷部品番号、メーカーコードで
        /// 在庫マスタの存在チェックを行い存在する倉庫棚番をセットする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeWarehouseShelfNo(ReceivedText receivedTelegram)
        {
            if (receivedTelegram.IsTelephoneOrder())
            {
                Stock foundStock = FindStockBy3WarehouseCodes(receivedTelegram);
                if (foundStock != null)
                {
                    CurrentUOEOrderDetailRecord.WarehouseShelfNo = foundStock.WarehouseShelfNo;
                }
            }
        }

        #endregion  // <050.倉庫棚番/>

        #region <051.受注数量/>

        /// <summary>
        /// 受注数量をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の受注数量
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeAcceptAnOrderCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double acceptAnOrderCnt = double.Parse(receivedTelegram.AcceptAnOrderCount);
            double acceptAnOrderCnt = TStrConv.StrToDoubleDef(receivedTelegram.AcceptAnOrderCount.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AcceptAnOrderCnt = acceptAnOrderCnt;
        }

        #endregion  // <051.受注数量/>

        #region <054.仕入先コード/>

        /// <summary>
        /// 仕入先コードをマージします。
        /// </summary>
        /// <remarks>
        /// 発注先マスタの仕入先コード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSupplierCd(ReceivedText receivedTelegram)
        {
            int supplierCd = UoeSupplier.RealUOESupplier.UOESupplierCd;
            CurrentUOEOrderDetailRecord.SupplierCd = supplierCd;
        }

        #endregion  // <054.仕入先コード/>

        #region <055.仕入先略称/>

        /// <summary>
        /// 仕入先略称をマージします。
        /// </summary>
        /// <remarks>
        /// 発注先マスタの仕入先コードに対する名称
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSupplierSnm(ReceivedText receivedTelegram)
        {
            string supplierSnm = UoeSupplier.RealUOESupplier.UOESupplierName;
            CurrentUOEOrderDetailRecord.SupplierSnm = supplierSnm;
        }

        #endregion  // <055.仕入先略称/>

        #region <056.UOEリマーク1/>

        /// <summary>
        /// UOEリマーク1をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文のリマーク（トリムしてセット）　※リモートで*Dの判断を行う為トリムする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUoeRemark1(ReceivedText receivedTelegram)
        {
            string uoeRemark1 = receivedTelegram.UOERemark;
            CurrentUOEOrderDetailRecord.UoeRemark1 = uoeRemark1;
        }

        #endregion  // <056.UOEリマーク1/>

        #region <058.受信日付/>

        /// <summary>
        /// 受信日付をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の分類コード（MMDD）を加工
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeReceiveDate(ReceivedText receivedTelegram)
        {
            ReceivedDate receivedDate = new ReceivedDate(receivedTelegram.ClassifiedCode.Trim());
            DateTime receiveDate = receivedDate.ToDateTime();
            CurrentUOEOrderDetailRecord.ReceiveDate = receiveDate;
        }

        #endregion  // <058.受信日付/>

        #region <059.受信時刻/>

        /// <summary>
        /// 受信時刻をマージします。
        /// </summary>
        /// <remarks>
        /// システム時刻
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeReceiveTime(ReceivedText receivedTelegram)
        {
            DateTime systemTime = DateTime.Now;
            int hour= systemTime.Hour;
            int min = systemTime.Minute;
            int sec = systemTime.Second;
            string strSystemTime = hour.ToString("0000") + min.ToString("00") + sec.ToString("00");

            int receiveTime = int.Parse(strSystemTime);
            CurrentUOEOrderDetailRecord.ReceiveTime = receiveTime;
        }

        #endregion  // <059.受信時刻/>

        #region <060.回答メーカーコード/>

        /// <summary>
        /// 回答メーカーコードをマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文のメーカーコード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeAnswerMakerCd(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int answerMakerCd = int.Parse(receivedTelegram.AnswerMakerCode);
            int answerMakerCd = TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AnswerMakerCd = answerMakerCd;
        }

        #endregion  // <060.回答メーカーコード/>

        #region <061.回答品番/>

        /// <summary>
        /// 回答品番をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の出荷部品番号
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeAnswerPartsNo(ReceivedText receivedTelegram)
        {
            string answerPartsNo = receivedTelegram.AnswerPartsNo;
            CurrentUOEOrderDetailRecord.AnswerPartsNo = answerPartsNo;
        }

        #endregion  // <061.回答品番/>

        #region <062.回答品名/>

        /// <summary>
        /// 回答品名をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の品名
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeAnswerPartsName(ReceivedText receivedTelegram)
        {
            string answerPartsName = receivedTelegram.AnswerPartsName;
            CurrentUOEOrderDetailRecord.AnswerPartsName = TrimEndCode(answerPartsName);
        }

        #endregion  // <062.回答品名/>

        #region <063.代替品番/>

        /// <summary>
        /// 代替品番をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の受注部品番号と出荷部品番号が同一でない場合に出荷部品番号をセット
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeSubstPartsNo(ReceivedText receivedTelegram)
        {
            if (!receivedTelegram.AcceptPartsNo.Equals(receivedTelegram.AnswerPartsNo))
            {
                string substPartsNo = receivedTelegram.AnswerPartsNo;
                CurrentUOEOrderDetailRecord.SubstPartsNo = substPartsNo;
            }
        }

        #endregion  // <063.代替品番/>

        #region <064.UOE拠点出庫数/>

        /// <summary>
        /// UOE拠点出庫数をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の出荷数　※受信電文の予備コードが0及びスペース以外の場合にはマイナスとする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeUOESectOutGoodsCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int uoeSectOutGoodsCnt = int.Parse(receivedTelegram.UOESectOutGoodsCount);
            int uoeSectOutGoodsCnt = TStrConv.StrToIntDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<

            string reserveCode = receivedTelegram.UOEMarkCode.Trim();
            if (reserveCode.Equals("0") || string.IsNullOrEmpty(reserveCode))
            {
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = uoeSectOutGoodsCnt;
            }
            else
            {
                if (uoeSectOutGoodsCnt > 0) uoeSectOutGoodsCnt *= (-1);
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = uoeSectOutGoodsCnt;
            }
        }

        #endregion  // <064.UOE拠点出庫数/>

        #region <065.BO出庫数1/>

        /// <summary>
        /// BO出庫数1をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文のB/O数　※受信電文の予備コードが0及びスペース以外の場合にはマイナスとする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBOShipmentCnt1(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int boShipmentCnt1 = int.Parse(receivedTelegram.BOShipmentCount);
            int boShipmentCnt1 = TStrConv.StrToIntDef(receivedTelegram.BOShipmentCount.Trim(), 0);
            // 2009/10/14 <<<

            string reserveCode = receivedTelegram.UOEMarkCode.Trim();
            if (reserveCode.Equals("0") || string.IsNullOrEmpty(reserveCode))
            {
                CurrentUOEOrderDetailRecord.BOShipmentCnt1 = boShipmentCnt1;
            }
            else
            {
                if (boShipmentCnt1 > 0) boShipmentCnt1 *= (-1);
                CurrentUOEOrderDetailRecord.BOShipmentCnt1 = boShipmentCnt1;
            }
        }

        #endregion  // <065.BO出庫数1/>

        #region <074.UOE拠点伝票番号/>

        /// <summary>
        /// UOE拠点伝票番号をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の出荷伝票番号
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOESectionSlipNo(ReceivedText receivedTelegram)
        {
            string uoeSectionSlipNo = receivedTelegram.UOESectionSlipNo;
            CurrentUOEOrderDetailRecord.UOESectionSlipNo = uoeSectionSlipNo;
        }

        #endregion  // <074.UOE拠点伝票番号/>

        #region <075.BO伝票番号1/>

        /// <summary>
        /// BO伝票番号1をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文のB/O出荷伝票
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeBOSlipNo1(ReceivedText receivedTelegram)
        {
            string boSlipNo1 = receivedTelegram.BOSlipNo;
            CurrentUOEOrderDetailRecord.BOSlipNo1 = boSlipNo1;
        }

        #endregion  // <075.BO伝票番号1/>

        #region <080.回答定価/>

        /// <summary>
        /// 回答定価をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の定価
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeAnswerListPrice(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double answerListPrice = double.Parse(receivedTelegram.AnswerListPrice);
            double answerListPrice = TStrConv.StrToDoubleDef(receivedTelegram.AnswerListPrice.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AnswerListPrice = answerListPrice;
        }

        #endregion  // <080.回答定価/>

        #region <081.回答原価単価/>

        /// <summary>
        /// 回答原価単価をマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の仕切単価
        /// ※明治産業は小数点1位までとなり10倍値がセットされてくる為、小数点付きでセット　明治以外はそのまま
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeAnswerSalesUnitCost(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //double answerSalesUnitCost = double.Parse(receivedTelegram.AnswerSalesUnitCost);
            double answerSalesUnitCost = TStrConv.StrToDoubleDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
            // 2009/10/14 <<<
            CurrentUOEOrderDetailRecord.AnswerSalesUnitCost = answerSalesUnitCost;
        }

        #endregion  // <081.回答原価単価/>

        #region <106.UOEマークコード/>

        /// <summary>
        /// UOEマークコードをマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の予備コード（明治以外は<c>0</c>をセット）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected virtual void MergeUOEMarkCode(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.UOEMarkCode = "0";
        }

        #endregion  // <106.UOEマークコード/>

        #region <109.チェックコード/>

        /// <summary>
        /// チェックコードをマージします。
        /// </summary>
        /// <remarks>
        /// チェックコード
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeUOECheckCode(ReceivedText receivedTelegram)
        {
            string uoeCheckCode = receivedTelegram.UOECheckCode;
            CurrentUOEOrderDetailRecord.UOECheckCode = uoeCheckCode;
        }
         
        #endregion  // <109.チェックコード/>

        #region <111.ラインエラー/>

        /// <summary>
        /// ラインエラーをマージします。
        /// </summary>
        /// <remarks>
        /// ラインエラー
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeLineErrorMessage(ReceivedText receivedTelegram)
        {
            string lineErrorMessage = receivedTelegram.LineErrorMessage;
            CurrentUOEOrderDetailRecord.LineErrorMassage = lineErrorMessage;
        }

        #endregion  // <111.ラインエラー/>

        /// <summary>データ送信/復旧区分の正常終了定数</summary>
        protected const int NORMAL_DATA_STATE = 9;

        #region <112.データ送信区分/>

        /// <summary>
        /// データ送信区分をマージします。
        /// </summary>
        /// <remarks>
        /// 9:正常終了
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeDataSendCode(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.DataSendCode = NORMAL_DATA_STATE;
        }

        #endregion  // <112.データ送信区分/>

        #region <113.データ復旧区分/>

        /// <summary>
        /// データ復旧区分をマージします。
        /// </summary>
        /// <remarks>
        /// 9:正常終了
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeDataRecoverDiv(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.DataRecoverDiv = NORMAL_DATA_STATE;
        }

        #endregion  // <113.データ復旧区分/>

        /// <summary>
        /// 入庫更新区分列挙体
        /// </summary>
        protected enum EnterUpdateDiv : int
        {
            /// <summary>未入庫</summary>
            NotEnterd = 0,
            /// <summary>入庫済</summary>
            Enterd = 1
        }

        #region <114.入庫更新区分（拠点）/>

        /// <summary>
        /// 入庫更新区分（拠点）をマージします。
        /// </summary>
        /// <remarks>
        /// 卸商入庫更新区分が自動…1:入庫済<br/>
        /// 卸商入庫更新区分が手動…0:未入庫
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterUpdDivSec(ReceivedText receivedTelegram)
        {
            int enterUpdDivSec = (int)EnterUpdateDiv.NotEnterd;
            if (LoginWorkerAcs.Instance.Policy.UOESetting.DistEnterDiv.Equals((int)LoginWorker.OroshishoDistEnterDiv.Auto))
            {
                enterUpdDivSec = (int)EnterUpdateDiv.Enterd;
            }
            CurrentUOEOrderDetailRecord.EnterUpdDivSec = enterUpdDivSec;
        }

        #endregion  // <114.入庫更新区分（拠点）/>

        #region <115.入庫更新区分（BO1）/>

        /// <summary>
        /// 入庫更新区分（BO1）をマージします。
        /// </summary>
        /// <remarks>
        /// 1:入庫済
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterUpdDivBO1(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivBO1 = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <115.入庫更新区分（BO1）/>

        #region <116.入庫更新区分（BO2）/>

        /// <summary>
        /// 入庫更新区分（BO2）をマージします。
        /// </summary>
        /// <remarks>
        /// 1:入庫済
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterUpdDivBO2(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivBO2 = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <116.入庫更新区分（BO2）/>

        #region <117.入庫更新区分（BO3）/>

        /// <summary>
        /// 入庫更新区分（BO3）をマージします。
        /// </summary>
        /// <remarks>
        /// 1:入庫済
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterUpdDivBO3(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivBO3 = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <117.入庫更新区分（BO3）/>

        #region <118.入庫更新区分（メーカー）/>

        /// <summary>
        /// 入庫更新区分（メーカー）をマージします。
        /// </summary>
        /// <remarks>
        /// 1:入庫済
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterUpdDivMaker(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivMaker = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <118.入庫更新区分（メーカー）/>

        #region <119.入庫更新区分（EO）/>

        /// <summary>
        /// 入庫更新区分（EO）をマージします。
        /// </summary>
        /// <remarks>
        /// 1:入庫済
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeEnterUpdDivEO(ReceivedText receivedTelegram)
        {
            CurrentUOEOrderDetailRecord.EnterUpdDivEO = (int)EnterUpdateDiv.Enterd;
        }

        #endregion  // <119.入庫更新区分（EO）/>

        #region <120.明細関連付けGUID/>

        /// <summary>
        /// 明細関連付けGUIDをマージします。
        /// </summary>
        /// <remarks>
        /// 対応する仕入明細データ（発注情報）のレコードと同じ値<br/>
        /// 受信電文にもGUIDが設定され、
        /// 　受信電文 - UOE発注データ - 仕入明細データ　
        /// の関連付けが行われます。
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected void MergeDtlRelationGiid(ReceivedText receivedTelegram)
        {
            if (CurrentUOEOrderDetailRecord.DtlRelationGuid.Equals(Guid.Empty))
            {
                CurrentUOEOrderDetailRecord.DtlRelationGuid = Guid.NewGuid();
            }
            receivedTelegram.DtlRelationGuid = CurrentUOEOrderDetailRecord.DtlRelationGuid;
        }

        #endregion  // <120.明細関連付けGUID/>
    }

    #region <SPK/>

    /// <summary>
    /// SPK用UOE発注データの構築者クラス
    /// </summary>
    public sealed class SPKOrderDataBuilder : UOEOrderDataBuilder
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="receivedTelegramAgreegate">受信電文の集合体</param>
        /// <param name="observer">簡易オブザーバー</param>
        public SPKOrderDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>
    }

    #endregion  // <SPK/>

    #region <明治産業/>

    /// <summary>
    /// 明治産業用UOE発注データの構築者クラス
    /// </summary>
    public sealed class MeijiOrderDataBuilder : UOEOrderDataBuilder
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="receivedTelegramAgreegate">受信電文の集合体</param>
        /// <param name="observer">簡易オブザーバー</param>
        public MeijiOrderDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        /// <summary>"*D"：受信電文のリマーク</summary>
        private const string ASTERISK_D_REMARK = "*D";

        // ---- ADD  2013/10/09 鄧潘ハン Redmine40628---- >>>>>
        //Thread中、メッセージ関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD  2013/10/09 鄧潘ハン Redmine40628---- <<<<<

        /// <summary>
        /// 倉庫・棚番を設定できるか判定します。
        /// </summary>
        /// <remarks>
        /// 接続先が明治産業で発注先マスタ上のVerが"1:新"の場合でリマークに"*D"が設定されている場合は未設定とする
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>
        /// <c>true</c> :設定できる<br/>
        /// <c>false</c>:設定できない
        /// </returns>
        private bool CanSetWarehouse(ReceivedText receivedTelegram)
        {
            //return !(UoeSupplier.IsNewVersion() && receivedTelegram.UOERemark.Trim().Equals(ASTERISK_D_REMARK));// DEL 2012/12/10 yangmj FOR redmine#32926PMデータと連携が取れない
            //----- ADD 2012/12/10 yangmj FOR redmine#32926PMデータと連携が取れない----->>>>>
            //送信のみの場合、リマークの先頭二位「*D」の場合、設定できない
            if (UoeSupplier.RealUOESupplier.ReceiveCondition.Equals((int)UOESupplierUtil.ReceiveConditionDiv.SendOnly))
            {
                if (!(string.IsNullOrEmpty(receivedTelegram.UOERemark) || receivedTelegram.UOERemark.Length < 2))
                {
                    return !(UoeSupplier.IsNewVersion() && receivedTelegram.UOERemark.Substring(0, 2).Trim().Equals(ASTERISK_D_REMARK));
                }
                //送信のみの場合、リマークの先頭二位「*D」以外の場合、設定できる
                return true;
            }
            else
            {
                //送受信可能の場合、リマークに"*D"が設定されている場合は未設定とする
                return !(UoeSupplier.IsNewVersion() && receivedTelegram.UOERemark.Trim().Equals(ASTERISK_D_REMARK));
            }
            //----- ADD 2012/12/10 yangmj FOR redmine#32926PMデータと連携が取れない-----<<<<<
        }

        #region <Override/>

        /// <summary>
        /// 倉庫コードをマージします。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        protected override void MergeWarehouseCode(ReceivedText receivedTelegram)
        {
            if (CanSetWarehouse(receivedTelegram))
            {
                base.MergeWarehouseCode(receivedTelegram);
            }
            else
            {
                CurrentUOEOrderDetailRecord.WarehouseCode = string.Empty;
            }
        }

        /// <summary>
        /// 倉庫名称をマージします。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        protected override void MergeWarehouseName(ReceivedText receivedTelegram)
        {
            if (CanSetWarehouse(receivedTelegram))
            {
                base.MergeWarehouseName(receivedTelegram);
            }
            else
            {
                CurrentUOEOrderDetailRecord.WarehouseName = string.Empty;
            }
        }

        /// <summary>
        /// 倉庫棚番をマージします。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        protected override void MergeWarehouseShelfNo(ReceivedText receivedTelegram)
        {
            if (CanSetWarehouse(receivedTelegram))
            {
                base.MergeWarehouseShelfNo(receivedTelegram);
            }
            else
            {
                CurrentUOEOrderDetailRecord.WarehouseShelfNo = string.Empty;
            }
        }

        /// <summary>
        /// UOE拠点出庫数をマージします。
        /// </summary>
        /// <remarks>
        /// 接続先が明治産業の場合で、予備コードが<c>1</c>の場合にはUOE拠点出庫数に<c>-1</c>を掛ける
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected override void MergeUOESectOutGoodsCnt(ReceivedText receivedTelegram)
        {
            // 2009/10/14 >>>
            //int uoeSectOutGoodsCnt = int.Parse(receivedTelegram.UOESectOutGoodsCount);
            int uoeSectOutGoodsCnt = TStrConv.StrToIntDef(receivedTelegram.UOESectOutGoodsCount.Trim(), 0);
            // 2009/10/14 <<<

            if (receivedTelegram.UOEMarkCode.Trim().Equals("1"))
            {
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = (-1) * uoeSectOutGoodsCnt;
            }
            else
            {
                CurrentUOEOrderDetailRecord.UOESectOutGoodsCnt = uoeSectOutGoodsCnt;
            }
        }

        /// <summary>
        /// 回答原価単価をマージします。
        /// </summary>
        /// <remarks>
        /// 明治産業は小数点第1位までとなり10倍値がセットされてくる為、小数点付きでセット
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected override void MergeAnswerSalesUnitCost(ReceivedText receivedTelegram)
        {
            // ---- ADD  2013/10/09 鄧潘ハン Redmine40628---- >>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);

            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD  2013/10/09 鄧潘ハン Redmine40628---- <<<<<
            // 2009/10/14 >>>
            //int nAnswerSalesUnitCost    = int.Parse(receivedTelegram.AnswerSalesUnitCost);
            int nAnswerSalesUnitCost = TStrConv.StrToIntDef(receivedTelegram.AnswerSalesUnitCost.Trim(), 0);
            // 2009/10/14 <<<

            // ---- ADD  2013/10/09 鄧潘ハン Redmine40628---- >>>>>
            double answerSalesUnitCost = 0.0;
            //フタバUSB専用
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);

                //卸商受信処理(手動)である場合
                if (!(Thread.GetData(msgShowSolt) != null
                    && ((Int32)Thread.GetData(msgShowSolt) == 1
                    || (Int32)Thread.GetData(msgShowSolt) == 2
                    || (Int32)Thread.GetData(msgShowSolt) == 3
                    || (Int32)Thread.GetData(msgShowSolt) == 4)))
                {
                    answerSalesUnitCost = ((double)nAnswerSalesUnitCost) / 10.0;
                }
                else
                {
                    answerSalesUnitCost = (double)nAnswerSalesUnitCost;
                }

            }
            else
            {
                answerSalesUnitCost = ((double)nAnswerSalesUnitCost) / 10.0;
            }
            // ---- ADD  2013/10/09 鄧潘ハン Redmine40628---- <<<<<

            //double answerSalesUnitCost = ( (double)nAnswerSalesUnitCost ) / 10.0;//DEL  2013/10/09 鄧潘ハン Redmine40628

            CurrentUOEOrderDetailRecord.AnswerSalesUnitCost = answerSalesUnitCost;
        }

        /// <summary>
        /// UOEマークコードをマージします。
        /// </summary>
        /// <remarks>
        /// 受信電文の予備コード（明治以外は<c>0</c>をセット）
        /// </remarks>
        /// <param name="receivedTelegram">受信電文</param>
        protected override void MergeUOEMarkCode(ReceivedText receivedTelegram)
        {
            string uoeMarkCode = receivedTelegram.UOEMarkCode;
            CurrentUOEOrderDetailRecord.UOEMarkCode = uoeMarkCode;
        }

        #endregion  // <Override/>
    }

    #endregion  // <明治産業/>
}
