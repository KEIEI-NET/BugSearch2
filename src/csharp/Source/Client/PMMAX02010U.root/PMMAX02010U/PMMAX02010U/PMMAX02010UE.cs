//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の障害一覧No.1の　M-045とM-046のメッセージ対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/15   修正内容 : Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : Redmine#48629の障害一覧No.237　チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/02/19   修正内容 : LDNS発生した障害　メッセージ不正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メッセージ一覧
    /// </summary>
    public class PMMAX02010UE
    {
        #region メッセージ
        /// <summary></summary>
        public const string M_001 = "得意先コード[{0}]は存在しないか、削除されています。";
        /// <summary></summary>
        public const string M_007 = "チェックリスト保存先は存在しないか、書込み権限がありません。";
        /// <summary></summary>
        public const string M_010 = "部品MAX得意先を入力してください。\r\n出品自動登録の際に登録する売価率、売単価の算出するために必要です。";
        /// <summary></summary>
        public const string M_012 = "出品一括更新処理を開始します。";
        /// <summary></summary>
        public const string M_013 = "画面入力値を検査します。";
        /// <summary></summary>
        public const string M_014 = "在庫マスタを抽出します。";
        /// <summary></summary>
        public const string M_015 = "画面入力値に不備がありましたので、処理を終了しました。";
        /// <summary></summary>
        public const string M_016 = "中止ボタンが押されたため、処理を中止します。";
        /// <summary></summary>
        public const string M_017 = "システムエラーが発生しました。\r\n[ステータス={0},メッセージ={1}]";
        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ---->>>>>
        ///// <summary></summary>
        //public const string M_018 = "売価率が下限値[{0}%]以下となっています。";
        ///// <summary></summary>
        //public const string M_019 = "販売単価が下限値[{0}円]以下となっています。";
        ///// <summary></summary>
        //public const string M_020 = "販売単価が1円以下の出品は行えません。";
        /// <summary></summary>
        public const string M_018 = "売価率が下限値[{0}%]未満となっています。";
        /// <summary></summary>
        public const string M_019 = "販売単価が下限値[{0}円]未満となっています。";
        /// <summary></summary>
        public const string M_020 = "販売単価が1円未満の出品は行えません。";
        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.2の　販売単価と売価率の「未満」仕様変更対応 ----<<<<<
        /// <summary></summary>
        public const string M_021 = "一次ファイルを出力します。[{0}件]";
        /// <summary></summary>
        public const string M_023 = "一次ファイル保存中にエラーが発生しました。\r\n[ステータス={0},メッセージ={1}]";
        /// <summary></summary>
        public const string M_024 = "出品更新する情報は見つかりませんでした。";
        /// <summary></summary>
        public const string M_025 = "部品MAXにログインできません。認証情報に誤まりがあります。\r\n再度入力しなおしてください。";
        /// <summary></summary>
        public const string M_026 = "部品MAXに出品更新情報を登録します。";
        /// <summary></summary>
        public const string M_027 = "部品MAXに接続できませんでした。\r\nインターネットに接続されている事を確認してください。";
        /// <summary></summary>
        // UPD BY 宋剛 2016/02/19 FOR LDNS発生した障害　メッセージ不正 ---->>>>>
        // public const string M_028 = "部品MAXに接続できませんでした。[ステータス={0},メッセージ={1}]";
        public const string M_028 = "部品MAXに接続できませんでした。\r\n[ステータス={0},メッセージ={1}]";
        // UPD BY 宋剛 2016/02/19 FOR LDNS発生した障害　メッセージ不正 ----<<<<<
        /// <summary></summary>
        public const string M_029 = "出品更新情報の登録中に部品MAXでエラーが発生しました。\r\n[部品MAX管理画面]-[出品更新画面]を表示し、出品更新情報が登録されているかご確認お願いします。\r\n登録されていない場合は、再度[出品更新]ボタンを押し、処理をしなおしてください。";
        /// <summary></summary>
        public const string M_030 = "部品MAXへの登録が完了しました。";
        /// <summary></summary>
        public const string M_031 = "入力値を保存しています。";
        /// <summary></summary>
        public const string M_032 = "入力値の保存が完了しました。";
        /// <summary></summary>
        public const string M_033 = "出品更新処理中に予期せぬエラーが発生しました。\r\n[ステータス={0},メッセージ={1}]";
        /// <summary></summary>
        public const string M_034 = "倉庫に、部品MAXの倉庫を1つ以上選択してください。";
        /// <summary></summary>
        public const string M_035 = "BLコード[{0}]は存在しないか、削除されています。";
        /// <summary></summary>
        public const string M_036 = "メーカーコード[{0}]は存在しないか、削除されています。";
        /// <summary></summary>
        public const string M_037 = "商品掛率グループコード[{0}]は存在しないか、削除されています。";
        /// <summary></summary>
        public const string M_038 = "仕入先コード[{0}]は存在しないか、削除されています。";
        /// <summary></summary>
        public const string M_039 = "価格算出日を入力してください。";
        /// <summary></summary>
        public const string M_040 = "警告対象とする売価率の下限値を入力してください。";
        /// <summary></summary>
        public const string M_041 = "警告対象とする販売単価の下限値を入力してください。";
        /// <summary></summary>
        public const string M_042 = "エラー再取込を開始します。";
        /// <summary></summary>
        public const string M_043 = "商品中分類コード[{0}]は存在しないか、削除されています。";
        /// <summary></summary>
        public const string M_044 = "売価率に小数点以下を含める事はできません。部品MAXに登録する際に切り捨てられます。";

        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.1の　M-045とM-046のメッセージ対応 ---->>>>>
        ///// <summary></summary>
        //public const string M_045 = "出荷数に小数点以下を含める事はできません。部品MAXに登録する際に切り捨てられます。";
        ///// <summary></summary>
        //public const string M_046 = "出荷数に小数点以下を含める事はできません。部品MAXに登録する際に切り捨てられます。出荷数が1未満の場合は、登録されません。この明細は無視されます。";
        /// <summary></summary>
        public const string M_045 = "現在庫数に小数点以下を含める事はできません。部品MAXに登録する際に切り捨てられます。";
        /// <summary></summary>
        public const string M_046 = "現在庫数が1未満の場合は、登録されません。この明細は無視されます。";
        // UPD BY 宋剛 2016/02/15 FOR Redmine#48629の障害一覧No.1の　M-045とM-046のメッセージ対応 ----<<<<<
        /// <summary></summary>
        public const string M_047 = "在庫マスタの抽出結果が、10万件を超えています。\r\n抽出条件を絞り込んでください。";
        /// <summary></summary>
        public const string M_050 = "不正な文字が含まれています。名称の修正を行って下さい。"; // ADD BY 宋剛 2016/02/19 FOR チェック処理に名称にカンマとダブルクウォーテーションが含まれていないか判定処理追加
        #endregion
    }
}
