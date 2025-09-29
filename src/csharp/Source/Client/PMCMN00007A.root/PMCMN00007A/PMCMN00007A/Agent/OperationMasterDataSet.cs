//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定データ
// プログラム概要   : 操作権限一覧表示のUI用データセットを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// オペレーションマスタDBのデータセット
    /// </summary>
    partial class OperationMasterDataSet
    {
        /// <summary>
        /// オペレーションマスタテーブルのカラムインデックス列挙体
        /// </summary>
        /// <remarks>
        /// ①カラム名を変更した場合、列挙値名も変更すること（カラム名と列挙値名を同じにする）。<br/>
        /// ②カラム順を変更した場合、列挙値の定義位置も変更すること（定義位置がインデックスを表す）。
        /// </remarks>
        public enum ClmIdx : int
        {
            /// <summary>提供日付</summary>
            OfferDate,
            /// <summary>カテゴリコード</summary>
            CategoryCode,
            /// <summary>カテゴリ名称</summary>
            CategoryName,
            /// <summary>カテゴリ表示順位</summary>
            CategoryDspOdr,
            /// <summary>プログラムＩＤ</summary>
            PgId,
            /// <summary>プログラム名称</summary>
            PgName,
            /// <summary>プログラム表示順位</summary>
            PgDspOdr,
            /// <summary>オペレーションコード</summary>
            OperationCode,
            /// <summary>オペレーション名称</summary>
            OperationName,
            /// <summary>オペレーション表示順位</summary>
            OperationDspOdr
        }
    }
}
