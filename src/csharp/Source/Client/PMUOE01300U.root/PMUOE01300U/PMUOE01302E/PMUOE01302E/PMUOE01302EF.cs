//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    // 優良メーカー用の電文編集クラス
    using PrimeTelegramEditorType = UoeSndEdit1001Acs.TelegramEditOpenClose1001;

    /// <summary>
    /// 仕入受信用送信電文生成クラス
    /// </summary>
    public sealed class SendingStockReceptionTelegramEssence
    {
        #region <業務区分/>

        /// <summary>業務区分</summary>
        private const int BUSINESS_CODE = 1;    // 1:発注/2:見積り/3:在庫確認
        /// <summary>
        /// 業務区分を取得します。（仕入受信処理では発注(=1)固定）
        /// </summary>
        public int BusinessCode { get { return BUSINESS_CODE; } }

        /// <summary>
        /// 業務名称を取得します。（仕入受信処理では発注(=1)固定）
        /// </summary>
        /// <value>業務名称</value>
        public string BusinessName { get { return "発注"; } }   // LITERAL:

        #endregion  // <業務区分/>

        #region <通信アセンブリID/>

        /// <summary>通信アセンブリID</summary>
        private readonly string _commAssemblyId;
        /// <summary>
        /// 通信アセンブリIDを取得します。
        /// </summary>
        public string CommAssemblyId { get { return _commAssemblyId; } }

        #endregion  // <通信アセンブリID/>

        #region <UOE発注先コード/>

        /// <summary>UOE発注先コード</summary>
        private readonly int _uoeSupplierCd;
        /// <summary>
        /// UOE発注先コードを取得します。
        /// </summary>
        /// <value>UOE発注先コード</value>
        public int UOESupplierCd { get { return _uoeSupplierCd; } }

        #endregion  // <UOE発注先コード/>

        #region <UOEホストコード/>

        /// <summary>UOEホストコード</summary>
        private readonly string _uoeHostCode;
        /// <summary>
        /// UOEホストコードを取得します。
        /// </summary>
        public string UOEHostCode { get { return _uoeHostCode; } }

        #endregion  // <UOEホストコード/>

        #region <UOE接続パスワード/>

        /// <summary>UOE接続パスワード</summary>
        private readonly string _uoeConnectPassword;
        /// <summary>
        /// UOE接続パスワードを取得します。
        /// </summary>
        /// <value>UOE接続パスワード</value>
        public string UOEConnectPassword { get { return _uoeConnectPassword; } }

        #endregion  // <UOE接続パスワード/>

        #region <閉局電文の無効フラグ/>

        /// <summary>閉局電文の無効フラグ</summary>
        private readonly bool _disabledClosingTelegram;
        /// <summary>
        /// 閉局電文の無効フラグを取得します。
        /// </summary>
        /// <value>
        /// <c>true</c> :閉局電文は生成されません。<br/>
        /// <c>false</c>:閉局電文は生成されます。
        /// </value>
        private bool DisabledClosingTelegram { get { return _disabledClosingTelegram; } }

        #endregion  // <閉局電文の無効フラグ/>

        #region <UOE発注先インスタンス/>

        /// <summary>UOE発注先のヘルパ</summary>
        private readonly UOESupplierHelper _uoeSupplierHelper;
        /// <summary>
        /// UOE発注先のヘルパを取得します。
        /// </summary>
        /// <value>UOE発注先のヘルパ</value>
        private UOESupplierHelper UOESupplierHelper { get { return _uoeSupplierHelper; } }

        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        public UOESupplier UOESupplier
        {
            get { return UOESupplierHelper.RealUOESupplier; }
        }

        #endregion  // <UOE発注先インスタンス/>

        /// <summary>送信電文のデフォルトサイズ（69[Byte]）</summary>
        private const int SEND_TELEGRAM_DEFAULT_LENGTH = 69;        // TODO:開局/閉局電文のサイズ（固定）
        /// <summary>仕入要求電文のサイズ（256[Byte]）</summary>
        private const int SEND_TELEGRAM_STOCK_REQUEST_LENGTH = 256; // TODO:仕入要求電文のサイズ（固定）

        #region <UOE送信編集結果（ヘッダー）/>

        /// <summary>UOE送信編集結果（ヘッダー）</summary>
        private UoeSndHed _uoeSendHeader;
        /// <summary>
        /// UOE送信編集結果（ヘッダー）を取得します。
        /// </summary>
        /// <remarks>
        /// 送信処理の送受信処理メソッドの再利用で使用します。
        /// </remarks>
        /// <value>UOE送信編集結果（ヘッダー）</value>
        public UoeSndHed UOESendHeader
        {
            get
            {
                if (_uoeSendHeader == null)
                {
                    _uoeSendHeader = CreateUoeSndHed();
                }
                return _uoeSendHeader;
            }
        }

        #endregion  // UOE送信編集結果（ヘッダー）

        #region <UOE送信制御条件/>

        /// <summary>UOE送信制御条件</summary>
        private UoeSndRcvCtlPara _uoeSendReceiveControlParameter;
        /// <summary>
        /// UOE送信制御条件を取得します。
        /// </summary>
        /// <remarks>
        /// 送信処理の受信編集処理メソッドの再利用で使用します。
        /// </remarks>
        /// <value>UOE送信制御条件</value>
        public UoeSndRcvCtlPara UOESendReceiveControlParameter
        {
            get
            {
                if (_uoeSendReceiveControlParameter == null)
                {
                    const int MANUAL_SYSTEM_DIV_CODE = 0;   // UOE発注データ.システム区分（0:手入力/1:伝発/2:検索/3:一括/4:補充）
                    const int NORMAL_PROCESS = 0;           // 処理区分（0:通常／1:復旧）

                    _uoeSendReceiveControlParameter = new UoeSndRcvCtlPara(
                        UOESupplierHelper.EnterpriseProfile.Code,
                        BusinessCode,
                        MANUAL_SYSTEM_DIV_CODE,
                        NORMAL_PROCESS,
                        UOESupplierHelper.EnterpriseProfile.Name,
                        BusinessName
                    );
                }
                return _uoeSendReceiveControlParameter;
            }
        }

        #endregion  // <UOE送信制御条件/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <param name="uoeHostCode">UOEホストコード</param>
        /// <param name="uoeConnectPassword">UOE接続パスワード</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        public SendingStockReceptionTelegramEssence(
            string commAssemblyId,
            int uoeSupplierCd,
            string uoeHostCode,
            string uoeConnectPassword,
            UOESupplierHelper uoeSupplier
        ) : this(commAssemblyId, uoeSupplierCd, uoeHostCode, uoeConnectPassword, uoeSupplier, false)
        { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <param name="uoeHostCode">UOEホストコード</param>
        /// <param name="uoeConnectPassword">UOE接続パスワード</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="disabledClosingTelegram">閉局電文の無効フラグ</param>
        public SendingStockReceptionTelegramEssence(
            string commAssemblyId,
            int uoeSupplierCd,
            string uoeHostCode,
            string uoeConnectPassword,
            UOESupplierHelper uoeSupplier,
            bool disabledClosingTelegram
        )
        {
            _commAssemblyId         = commAssemblyId;
            _uoeSupplierCd          = uoeSupplierCd;
            _uoeHostCode            = uoeHostCode;
            _uoeConnectPassword     = uoeConnectPassword;
            _uoeSupplierHelper      = uoeSupplier;
            _disabledClosingTelegram= disabledClosingTelegram;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// UOE送信編集結果（ヘッダー）を生成します。
        /// </summary>
        /// <returns>UOE送信編集結果（ヘッダー）</returns>
        private UoeSndHed CreateUoeSndHed()
        {
            UoeSndHed uoeSndHed = new UoeSndHed();

            uoeSndHed.BusinessCode  = BusinessCode;     // 業務区分
            uoeSndHed.CommAssemblyId= CommAssemblyId;   // 通信アセンブリID
            uoeSndHed.UOESupplierCd = UOESupplierCd;    // UOE発注先コード

            // UOE送信編集（明細）クラス
            uoeSndHed.UoeSndDtlList = new List<UoeSndDtl>();
            {
                // 1.開局電文
                uoeSndHed.UoeSndDtlList.Add(CreateOpenUoeSndDtl());

                // 2.仕入要求電文
                uoeSndHed.UoeSndDtlList.Add(CreateStockRequestUoeSndDtl());

                // 3.閉局電文
                if (!DisabledClosingTelegram)
                {
                    uoeSndHed.UoeSndDtlList.Add(CreateCloseUoeSndDtl());
                }
            }

            return uoeSndHed;
        }

        #region <UOE送信編集結果（明細）の生成/>

        #region <開局電文/閉局電文/>

        /// <summary>
        /// 開局電文（閉局電文）のUOE送信編集結果（明細）を生成します。
        /// </summary>
        /// <param name="openMode">
        /// 開局：<c>EnumUoeConst.OpenMode.ct_OPEN</c><br/>
        /// 閉局：<c>EnumUoeConst.OpenMode.ct_CLOSE</c>
        /// </param>
        /// <returns>開局電文（閉局電文）のUOE送信編集結果（明細）</returns>
        private UoeSndDtl CreateCreateOpenOrCloseUoeSndDtl(EnumUoeConst.OpenMode openMode)
        {
            // 優良メーカー用の電文編集者を設定
            PrimeTelegramEditorType primeTelegramEditor = new PrimeTelegramEditorType();
            primeTelegramEditor.uOESupplier = UOESupplier;

            // UOE送信編集結果を編集
            UoeSndDtl uoeSndDtl = new UoeSndDtl();
            {
                // 発注回答番号…開局/閉局の場合、0
                uoeSndDtl.UOESalesOrderNo = 0;

                // 発注回答行番号…開局/閉局の場合、サイズ0
                uoeSndDtl.UOESalesOrderRowNo = new List<int>();

                // 送信電文(JIS)…開局/閉局の場合、発注区分は手入力(=1)
                uoeSndDtl.SndTelegram = primeTelegramEditor.Telegram(
                    (int)EnumUoeConst.ctSystemDivCd.ct_Input,
                    (int)openMode
                );

                // 送信電文のサイズ
                uoeSndDtl.SndTelegramLen = SEND_TELEGRAM_DEFAULT_LENGTH;
            }
            return uoeSndDtl;
        }

        #endregion  // <開局電文/閉局電文/>

        /// <summary>
        /// 開局電文のUOE送信編集結果（明細）を生成します。
        /// </summary>
        /// <returns>開局電文のUOE送信編集結果（明細）</returns>
        private UoeSndDtl CreateOpenUoeSndDtl()
        {
            return CreateCreateOpenOrCloseUoeSndDtl(EnumUoeConst.OpenMode.ct_OPEN);
        }

        /// <summary>
        /// 仕入要求電文のUOE送信編集結果（明細）を生成します。
        /// </summary>
        /// <returns>仕入要求電文のUOE送信編集結果（明細）</returns>
        private UoeSndDtl CreateStockRequestUoeSndDtl()
        {
            // 優良メーカー用の電文編集者を設定
            PrimeTelegramEditorType primeTelegramEditor = new PrimeTelegramEditorType();
            primeTelegramEditor.uOESupplier = UOESupplier;

            // UOE送信編集結果を編集
            UoeSndDtl uoeSndDtl = new UoeSndDtl();
            {
                // 発注回答番号
                uoeSndDtl.UOESalesOrderNo = 1;

                // 発注回答行番号
                uoeSndDtl.UOESalesOrderRowNo = new List<int>();
                uoeSndDtl.UOESalesOrderRowNo.Add(1);

                // 送信電文(JIS)
                uoeSndDtl.SndTelegram = primeTelegramEditor.Telegram(UOESupplierHelper.ReceivingUOESupplierType);

                // 送信電文のサイズ
                uoeSndDtl.SndTelegramLen = SEND_TELEGRAM_STOCK_REQUEST_LENGTH;
            }
            return uoeSndDtl;
        }

        /// <summary>
        /// 閉局電文のUOE送信編集結果（明細）を生成します。
        /// </summary>
        /// <returns>閉局電文のUOE送信編集結果（明細）</returns>
        private UoeSndDtl CreateCloseUoeSndDtl()
        {
            UoeSndDtl uoeSndDtl = CreateCreateOpenOrCloseUoeSndDtl(EnumUoeConst.OpenMode.ct_CLOSE);
            {
                // TODO:閉局電文の微調整（∵送信処理の場合と値が違う？）
                const int RESULT_INDEX_UPPER= 34;
                const int RESULT_INDEX_LOWER= 35;
                const int ORDER_DIV_INDEX   = 36;
                const byte JIS_CODE_OF_0 = 48;
                const byte JIS_CODE_OF_1 = 49;

                // 結果："  "→"00"
                uoeSndDtl.SndTelegram[RESULT_INDEX_UPPER] = JIS_CODE_OF_0;
                uoeSndDtl.SndTelegram[RESULT_INDEX_LOWER] = JIS_CODE_OF_0;

                // 発注区分：" "→"1"
                uoeSndDtl.SndTelegram[ORDER_DIV_INDEX] = JIS_CODE_OF_1;
            }
            return uoeSndDtl;
        }

        #endregion  // <UOE送信編集結果（明細）の生成/>

        #region <デバッグ用/>

        /// <summary>
        /// UOE送信編集結果（ヘッダー）を文字列に変換します。
        /// </summary>
        /// <param name="uoeSndHed">UOE送信編集結果（ヘッダー）</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>文字列</returns>
        public static string ConvertString(
            UoeSndHed uoeSndHed,
            UOESupplierHelper uoeSupplier
        )
        {
            StringBuilder str = new StringBuilder();

            str.Append("業務区分：").Append(uoeSndHed.BusinessCode).Append(Environment.NewLine);
            str.Append("通信アセンブリID：").Append(uoeSndHed.CommAssemblyId).Append(Environment.NewLine);
            str.Append("UOE発注コード：").Append(uoeSndHed.UOESupplierCd).Append(Environment.NewLine);
            str.Append("UOE送信編集(明細)：").Append(uoeSndHed.UoeSndDtlList.Count).Append(" 件" + Environment.NewLine);
            for (int i = 0; i < uoeSndHed.UoeSndDtlList.Count; i++)
            {
                str.Append("電文[").Append(i).Append("]" + Environment.NewLine);

                UoeSndDtl uoeSndDtl = uoeSndHed.UoeSndDtlList[i];
                {
                    str.Append("発注回答番号：").Append(uoeSndDtl.UOESalesOrderNo).Append(Environment.NewLine);
                    str.Append("発注回答行番号：").Append(uoeSndDtl.UOESalesOrderRowNo).Append(Environment.NewLine);

                    //for (int j = 0; j < uoeSndDtl.SndTelegram.Length; j++)
                    //{
                    //    str.Append("送信電文(JIS)[").Append(j).Append("] = ").Append(uoeSndDtl.SndTelegram[j]).Append(";").Append(Environment.NewLine);
                    //}

                    str.Append("[送信電文(JIS)]").Append(Environment.NewLine);
                    SendingText sendingText = new SendingText(uoeSndDtl.SndTelegram);
                    str.Append(sendingText.ToString());
                }

                str.Append(Environment.NewLine);
            }

            if (uoeSupplier == null) return str.ToString();

            // [追加情報]：UOE発注先
            str.Append("[追加情報]：UOE発注先").Append(Environment.NewLine);
            str.Append("電話番号：").Append(uoeSupplier.RealUOESupplier.TelNo).Append(Environment.NewLine);

            return str.ToString();
        }

        /// <summary>
        /// UOE送信編集結果（ヘッダー）を文字列に変換します。
        /// </summary>
        /// <param name="uoeRecHed">UOE送信編集結果（ヘッダー）</param>
        /// <returns>文字列</returns>
        public static string ConvertString(UoeRecHed uoeRecHed)
        {
            StringBuilder str = new StringBuilder();

            str.Append("業務区分：").Append(uoeRecHed.BusinessCode).Append(Environment.NewLine);
            str.Append("通信アセンブリID").Append(uoeRecHed.CommAssemblyId).Append(Environment.NewLine);
            str.Append("UOE発注先コード：").Append(uoeRecHed.UOESupplierCd).Append(Environment.NewLine);
            str.Append("UOE受信結果(明細)：").Append(uoeRecHed.UoeRecDtlList.Count).Append(" 件" + Environment.NewLine);
            for (int i = 0; i < uoeRecHed.UoeRecDtlList.Count; i++)
            {
                str.Append("電文[").Append(i).Append("]" + Environment.NewLine);

                UoeRecDtl uoeRecDtl = uoeRecHed.UoeRecDtlList[i];
                {
                    str.Append("発注回答番号：").Append(uoeRecDtl.UOESalesOrderNo).Append(Environment.NewLine);
                    str.Append("発注回答行番号：").Append(uoeRecDtl.UOESalesOrderRowNo).Append(Environment.NewLine);

                    for (int j = 0; j < uoeRecDtl.RecTelegram.Length; j++)
                    {
                        str.Append("受信電文(JIS)[").Append(j).Append("] = ").Append(uoeRecDtl.RecTelegram[j]).Append(";").Append(Environment.NewLine);
                    }
                    if (uoeRecDtl.RecTelegram.Length <= 0) str.Append("受信電文(JIS)：なし").Append(Environment.NewLine);

                    str.Append("データ送信区分：").Append(uoeRecDtl.DataSendCode).Append(Environment.NewLine);
                    str.Append("データ復旧区分：").Append(uoeRecDtl.DataRecoverDiv).Append(Environment.NewLine);
                }

                str.Append(Environment.NewLine);
            }

            // HACK:一時、消し
            //int index = 0;
            //ReceivedTextAgreegate agreegate = new ReceivedTextAgreegate(uoeRecHed);
            //IIterator<ReceivedText> iter = agreegate.CreateIterator();
            //while (iter.HasNext())
            //{
            //    index++;
            //    ReceivedText text = iter.GetNext();

            //    str.Append("受信テキスト[").Append(index).Append("]").Append(Environment.NewLine);
            //    str.Append(text.ToString()).Append(Environment.NewLine);
            //}

            return str.ToString();
        }

        #endregion  // <デバッグ用/>
    }
}
