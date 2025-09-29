//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リストデータクラス
// プログラム概要   : 送信前リストデータクラスを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/11  修正内容 : MAHNB02013E：入金確認表を参考に新規作成
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 送信前リスト抽出条件クラス
    /// </summary>
    /// <remarks>
    /// PMOUE02032Eに配置するが、循環参照になってしまうため、PMUOE02033Aに移植
    /// </remarks>
    public sealed class SendBeforeOrderCondition : SendBeforOrderCndtnWork
    {
        #region <帳票ヘッダーのタイトル/>

        /// <summary>システム区分のタイトル</summary>
        public const string SYSTEM_DIV_CD_TITLE = "システム区分";
        /// <summary>印刷順のタイトル</summary>
        public const string PRINT_ORDER_TITLE = "印刷順";
        /// <summary>オンライン番号のタイトル</summary>
        public const string ONLINE_NO_TITLE = "注文番号";
        /// <summary>UOE発注先コードのタイトル</summary>
        public const string UOE_SUPPLIER_CD_TITLE = "発注先";

        /// <summary>作成日のフォーマット</summary>
        public const string PRINT_DATE_FORMAT = "yyyy/MM/dd";
        /// <summary>作成時間のフォーマット</summary>
        public const string PRINT_TIME_FORMAT = "HH:mm";

        #endregion  // <帳票ヘッダーのタイトル/>

        #region <システム区分/>

        /// <summary>
        /// システム区分の列挙体
        /// </summary>
        public enum SystemDivCode : int
        {
            /// <summary>手入力</summary>
            Manual = 0,
            /// <summary>伝発</summary>
            DenPatsu = 1,
            /// <summary>検索</summary>
            Searching = 2,
            /// <summary>一括</summary>
            Lump = 3,
            /// <summary>補充</summary>
            Supplement = 4
        }

        /// <summary>
        /// システム区分の名称を取得します。
        /// </summary>
        /// <value>システム区分の名称</value>
        public string SystemDivName
        {
            get
            {
                switch (SystemDivCd)
                {
                    case (int)SystemDivCode.Manual:
                        return "手入力";    // LITERAL:
                    case (int)SystemDivCode.DenPatsu:
                        return "伝発";      // LITERAL:
                    case (int)SystemDivCode.Searching:
                        return "検索";      // LITERAL:
                    case (int)SystemDivCode.Lump:
                        return "一括";      // LITERAL:
                    case (int)SystemDivCode.Supplement:
                        return "補充";      // LITERAL:
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion  // <システム区分/>

        #region <印刷順/>

        /// <summary>
        /// 印刷順の列挙体
        /// </summary>
        public enum PrintOrderType : int
        {
            /// <summary>注文番号別</summary>
            ByOnlineNo = 0,
            /// <summary>発注先別</summary>
            ByUOESupplierCode = 1
        }

        /// <summary>印刷順</summary>
        private PrintOrderType _printOrder;
        /// <summary>
        /// 印刷順のアクセサ
        /// </summary>
        /// <value>印刷順</value>
        public PrintOrderType PrintOrder
        {
            get { return _printOrder; }
            set { _printOrder = value; }
        }

        /// <summary>
        /// 印刷順の名称を取得します。
        /// </summary>
        /// <value>印刷順の名称</value>
        public string PrintOrderName
        {
            get
            {
                switch (PrintOrder)
                {
                    case PrintOrderType.ByOnlineNo:
                        return "注文番号別";
                    case PrintOrderType.ByUOESupplierCode:
                        return "発注先別";
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion  // <印刷順/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SendBeforeOrderCondition() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 送信前リスト抽出条件（リモート用）を生成します。
        /// </summary>
        /// <returns>送信前リスト抽出条件（リモート用）</returns>
        public SendBeforOrderCndtnWork CreateSendBeforOrderCndtnWork()
        {
            SendBeforOrderCndtnWork copy = new SendBeforOrderCndtnWork();

            copy.EnterpriseCode = EnterpriseCode;
            copy.SystemDivCd = SystemDivCd;
            copy.St_OnlineNo = St_OnlineNo;
            copy.Ed_OnlineNo = Ed_OnlineNo;

            copy.SectionCodes = new string[SectionCodes.Length];
            Array.Copy(SectionCodes, copy.SectionCodes, SectionCodes.Length);
            
            copy.St_UOESupplierCd = St_UOESupplierCd;
            copy.Ed_UOESupplierCd = Ed_UOESupplierCd;

            return copy;
        }
    }
}
