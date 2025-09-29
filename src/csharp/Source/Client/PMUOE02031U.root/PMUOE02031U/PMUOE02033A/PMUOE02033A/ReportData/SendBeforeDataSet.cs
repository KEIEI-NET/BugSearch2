//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リスト テーブルアクセスクラス
// プログラム概要   : 送信前リスト テーブルアクセスクラスを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/09/11  修正内容 : MAHNB02015A：入金確認表を参考に新規作成
//----------------------------------------------------------------------------//

namespace Broadleaf.Application.Controller.ReportData
{
    /// <summary>
    /// 送信前リストの帳票印字用データセット
    /// </summary>
    partial class SendBeforeDataSet
    {
        partial class SendBeforeDataTable
        {
        }
        /// <summary>
        /// カラム列挙体
        /// </summary>
        public enum ClmIdx : int
        {
            /// <summary>拠点コード</summary>
            SectionCode,
            /// <summary>拠点ガイド名称</summary>
            SectionGuideSnm,
            /// <summary>発注先コード</summary>
            UOESupplierCd,
            /// <summary>発注先名称</summary>
            UOESupplierName,
            /// <summary>注文番号</summary>
            OnlineNo,
            /// <summary>得意先</summary>
            CustomerCode,
            /// <summary>依頼者</summary>
            EmployeeCode,
            /// <summary>品番</summary>
            GoodsNo,
            /// <summary>品名</summary>
            GoodsName,
            /// <summary>メーカー</summary>
            GoodsMakerCd,
            /// <summary>数量</summary>
            AcceptAnOrderCnt,
            /// <summary>B/O</summary>
            BoCode,
            /// <summary>リマーク1</summary>
            UoeRemark1,
            /// <summary>リマーク2</summary>
            UoeRemark2,
            /// <summary>納</summary>
            UOEDeliGoodsDiv,
            /// <summary>H納</summary>
            FollowDeliGoodsDiv,
            /// <summary>拠点</summary>
            UOEResvdSection,

            /// <summary>印刷順</summary>
            PrintOrder
        }
    }
}
