//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定データ
// プログラム概要   : 操作権限設定データのユーティリティを定義します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Util
{
    using TextBoxType   = Infragistics.Win.UltraWinEditors.TextEditorControlBase;
    using OptionSetType = Infragistics.Win.UltraWinEditors.UltraOptionSet;

    #region <操作権限設定データ/>

    /// <summary>
    /// 操作権限設定データユーティリティ
    /// </summary>
    public static class EntityUtil
    {
        #region <カテゴリ/>

        /// <summary>
        /// カテゴリコード列挙体
        /// </summary>
        public enum CategoryCode : int
        {
            /// <summary>部品</summary>
            Part = 0,
            /// <summary>エントリ</summary>
            Entry = 1,
            /// <summary>更新</summary>
            Update = 2,
            /// <summary>照会</summary>
            Reference = 3,
            /// <summary>帳票</summary>
            Report = 4,
            /// <summary>マスメン</summary>
            MasterMaintenance = 50,
            /// <summary>全体設定</summary>
            AllSetting = 60,
            /// <summary>その他</summary>
            Others = 90
        }

        /// <summary>
        /// カテゴリーコードの配列を生成します。
        /// </summary>
        /// <returns>カテゴリーコードの配列</returns>
        public static int[] CreateCategoryCodeArray()
        {
           return new int[] {
                (int)CategoryCode.Part,
                (int)CategoryCode.Entry,
                (int)CategoryCode.Update,
                (int)CategoryCode.Reference,
                (int)CategoryCode.Report,
                (int)CategoryCode.MasterMaintenance,
                (int)CategoryCode.Others
            };
        }

        #endregion  // <カテゴリ/>

        #region <プログラムID/>

        /// <summary>全プログラムを表すID</summary>
        public const string ALL_PG_ID = "";

        #endregion  // <プログラムID/>

        #region <オペレーションコード/>

        /// <summary>全操作を表すオペレーションコード</summary>
        public const int ALL_OPERATION_CODE = -1;

        #endregion  // <オペレーションコード/>
    }

    #endregion  // <操作権限設定データ/>

    #region <拠点/>

    /// <summary>
    /// 拠点ユーティリティ
    /// </summary>
    public static class SectionUtil
    {
        #region <メッセージ/>

        /// <summary>メッセージ：拠点コードが存在しません。</summary>
        public const string MSG_SECTION_CODE_IS_NOT_FOUND = "拠点コードが存在しません。";       // LITERAL:

        /// <summary>メッセージ：全社設定は削除できません。</summary>
        public const string MSG_ALL_SECTION_CANNOT_BE_DELETED = "全社共通は削除できません。";   // LITERAL:

        #endregion  // <メッセージ/>

        /// <summary>桁数</summary>
        public const int DIGIT = 2;

        #region <全社共通/>

        /// <summary>全社共通を示す拠点コード値</summary>
        public const int ALL_SECTION_CODE_NUMBER = 0;

        /// <summary>全社共通を示す拠点コード</summary>
        public const string ALL_SECTION_CODE = "00";

        /// <summary>全社共通の名称</summary>
        public const string ALL_SECTION_NAME = "全社共通";

        /// <summary>
        /// 全社か判定します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns><c>true</c> :全社である。<br/><c>false</c>:全社ではない。</returns>
        public static bool IsAllSection(string sectionCode)
        {
            int sectionCodeNumber = -1;
            bool isNumber = int.TryParse(sectionCode.Trim(), out sectionCodeNumber);
            if (isNumber)
            {
                return sectionCodeNumber.Equals(ALL_SECTION_CODE_NUMBER);
            }
            else
            {
                return false;
            }
        }

        #endregion  // <全社共通/>

        /// <summary>
        /// 指定した拠点コードが存在するか判定します。
        /// </summary>
        /// <remarks>
        /// 全社共通コードは存在すると判定します。
        /// </remarks>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns><c>true</c> :存在する。<br/><c>false</c>:存在しない。</returns>
        public static bool ExistsCode(string sectionCode)
        {
            return ExistsCode(sectionCode, false);
        }

        /// <summary>
        /// 指定した拠点コードが存在するか判定します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="enabledAllSection">全社共通を有効にするフラグ(<c>true</c> :有効<br/><c>false</c>:無効)</param>
        /// <returns><c>true</c> :存在する。<br/><c>false</c>:存在しない。</returns>
        private static bool ExistsCode(
            string sectionCode,
            bool enabledAllSection
        )
        {
            // 全社共通が無効の場合、全社共通コードは存在すると判定
            if (!enabledAllSection)
            {
                if (IsAllSection(sectionCode)) return true;
            }

            SecInfoAcs secInfoAcs = new SecInfoAcs();   // 拠点コードのガイド

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    // TODO:効率のよい検索方法
                    if (secInfoSet.SectionCode.Trim().Equals(sectionCode.Trim().PadLeft(DIGIT, '0')))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }

    #endregion  // <拠点/>

    #region <範囲関連/>

    /// <summary>
    /// 範囲ユーティリティ
    /// </summary>
    /// <remarks>
    /// <br>Note       : 各コードの範囲と桁の情報を提供します。</br>
    /// <br>Programmer : 30434 工藤 恵優</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public static class RangeUtil
    {
        /// <summary>対象月フォーマット</summary>
        public const string YEAR_MONTH_FORMAT = "yyyy/MM";
        /// <summary>対象日フォーマット</summary>
        public const string DATE_FORMAT = "yyyy/MM/dd";

        /// <summary>最初から</summary>
        public const string FROM_BEGIN = "最初から";
        /// <summary>最後まで</summary>
        public const string TO_END = "最後まで";

        /// <summary>
        /// 最初からか判定します。
        /// </summary>
        /// <param name="startCode">開始コード</param>
        /// <param name="minNumber">最小値</param>
        /// <returns><c>true</c> :最初から<br/><c>false</c>:最初からではない</returns>
        private static bool IsFromBegin(
            string startCode,
            int minNumber
        )
        {
            if (string.IsNullOrEmpty(startCode)) return true;

            int startNumber = -1;
            if (int.TryParse(startCode, out startNumber))
            {
                return startNumber < minNumber;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 最後までか判定します。
        /// </summary>
        /// <param name="endCode">終了コード</param>
        /// <param name="maxNumber">最大値</param>
        /// <returns><c>true</c> :最後まで<br/><c>false</c>:最後までではない</returns>
        private static bool IsToEnd(
            string endCode,
            int maxNumber
        )
        {
            if (string.IsNullOrEmpty(endCode)) return true;

            int endNumber = -1;
            if (int.TryParse(endCode, out endNumber))
            {
                return endNumber > maxNumber;
            }
            else
            {
                return false;
            }
        }

        #region <従業員コード/>

        /// <summary>
        /// 担当者：従業員コード
        /// </summary>
        public static class EmployeeCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "担当者";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion

        #region <倉庫コード/>

        /// <summary>
        /// 倉庫：倉庫コード
        /// </summary>
        public static class WarehouseCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "倉庫";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <倉庫コード/>

        #region <仕入先コード/>

        /// <summary>
        /// 仕入先：仕入先コード
        /// </summary>
        public static class SupplierCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "仕入先";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 999999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "000000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion

        #region <商品メーカーコード/>

        /// <summary>
        /// メーカー：商品メーカーコード
        /// </summary>
        public static class GoodsMakerCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "メーカー";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion  // <商品メーカーコード/>

        #region <商品大分類コード/>

        /// <summary>
        /// 商品大分類：商品大分類コード
        /// </summary>
        public static class GoodsLGroupCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "商品大分類";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <商品大分類コード/>

        #region <商品中分類コード/>

        /// <summary>
        /// 商品中分類：商品中分類コード
        /// </summary>
        public static class GoodsMGroupCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "商品中分類";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <商品中分類コード/>

        #region <ＢＬグループコード/>

        /// <summary>
        /// グループコード：BLグループコード
        /// </summary>
        public static class BLGroupCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "グループコード";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 99999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "00000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <ＢＬグループコード/>

        #region <自社分類コード/>

        /// <summary>
        /// 商品区分：自社分類コード
        /// </summary>
        public static class EnterpriseGanreCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "商品区分";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion  // <自社分類コード/>

        #region <ＢＬコード/>

        /// <summary>
        /// BLコード：BLコード
        /// </summary>
        public static class BLGoodsCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "ＢＬコード";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 99999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "00000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion  // <ＢＬコード：ＢＬコード/>

        #region <販売エリアコード/>

        /// <summary>
        /// 地区：販売エリアコード
        /// </summary>
        public static class SalesAreaCode
        {
            /// <summary>ラベル</summary>
            public const string LABEL = "地区";
            /// <summary>最小値</summary>
            public const int MIN = 1;
            /// <summary>最大値</summary>
            public const int MAX = 9999;
            /// <summary>数値フォーマット</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// 全範囲か判定します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <param name="endCode">終了コード</param>
            /// <returns><c>true</c> :全範囲である<br/><c>false</c>:全範囲ではない</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// 開始文字列を取得します。
            /// </summary>
            /// <param name="startCode">開始コード</param>
            /// <returns>開始文字列</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// 終了文字列を取得します。
            /// </summary>
            /// <param name="endCode">終了コード</param>
            /// <returns>終了文字列</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <販売エリアコード/>
    }

    #endregion  // <範囲/>

    #region <ガイド制御/>

    /// <summary>
    /// ガイドのUIを制御するクラス
    /// </summary>
    /// <typeparam name="TValueUI">値のUIの型（通常はTNedit）</typeparam>
    /// <typeparam name="TOperationUI">操作のUIの型（通常はUltraButton）</typeparam>
    /// <typeparam name="TNextFocusUI">操作後にフォーカスするUIの型（通常はTCommboEditor）</typeparam>
    public class GuideUIController<TValueUI, TOperationUI, TNextFocusUI>
        where TValueUI      : TextBoxType
        where TOperationUI  : Control
        where TNextFocusUI  : Control
    {
        #region <範囲指定のUIフラグ/>

        /// <summary>範囲指定のUIフラグ</summary>
        private bool _isRangeUI;
        /// <summary>
        /// 範囲指定のUIフラグのアクセサ
        /// </summary>
        /// <value><c>true</c> :範囲指定のUIである。<br/><c>false</c>:範囲指定のUIではない。</value>
        protected bool IsRangeUI
        {
            get { return _isRangeUI; }
            set { _isRangeUI = value; }
        }

        #endregion  // <範囲指定のUIフラグ/>

        #region <値/>

        /// <summary>値のUI</summary>
        private readonly TValueUI _valueUI;
        /// <summary>
        /// 値のUIを取得します。
        /// </summary>
        /// <value>値のUI</value>
        protected TValueUI ValueUI
        {
            get { return _valueUI; }
        }

        /// <summary>以前の値</summary>
        private string _previousValue;
        /// <summary>
        /// 以前の値のアクセサ
        /// </summary>
        /// <value>以前の値</value>
        protected string PreviousValue
        {
            get { return _previousValue; }
            set { _previousValue = value; }
        }

        /// <summary>
        /// 以前の値を取得します。
        /// </summary>
        /// <returns>以前の値</returns>
        public string GetPreviousText()
        {
            return PreviousValue;
        }

        #endregion  // <値/>

        #region <操作/>

        /// <summary>操作のUI</summary>
        private readonly TOperationUI _operationUI;
        /// <summary>
        /// 操作のUIを取得します。
        /// </summary>
        /// <value>操作のUI</value>
        protected TOperationUI OperationUI
        {
            get { return _operationUI; }
        }

        // TODO:次善処置↓（削除する方向で…）
        /// <summary>操作UIのフォーカス可能フラグ</summary>
        private bool _canFocusOperationUI = true;
        /// <summary>
        /// 操作UIのフォーカス可能フラグのアクセサ
        /// </summary>
        /// <value><c>true</c> :可能。<br/><c>false</c>:不可能</value>
        protected bool CanFocusOperationUI
        {
            get { return _canFocusOperationUI; }
            set { _canFocusOperationUI = value; }
        }

        #endregion  // <操作/>

        #region <操作後のフォーカス/>

        /// <summary>操作後にフォーカスするUI</summary>
        private readonly TNextFocusUI _nextFocusUI;
        /// <summary>
        /// 操作後にフォーカスするUI
        /// </summary>
        /// <value>操作後にフォーカスするUI</value>
        protected TNextFocusUI NextFocusUI
        {
            get { return _nextFocusUI; }
        }

        #endregion  // <操作後のフォーカス/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="valueUI">値のUI</param>
        /// <param name="operationUI">操作のUI</param>
        /// <param name="nextFocusUI">操作後にフォーカスするUI</param>
        public GuideUIController(
            TValueUI valueUI,
            TOperationUI operationUI,
            TNextFocusUI nextFocusUI
        )
        {
            _valueUI    = valueUI;
            _operationUI= operationUI;
            _nextFocusUI= nextFocusUI;
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="valueUI">値のUI</param>
        /// <param name="operationUI">操作のUI</param>
        /// <param name="nextFocusUI">操作後にフォーカスするUI</param>
        /// <param name="isRangeUI">範囲指定のUIであるかのフラグ</param>
        public GuideUIController(
            TValueUI valueUI,
            TOperationUI operationUI,
            TNextFocusUI nextFocusUI,
            bool isRangeUI
        )
        {
            _valueUI    = valueUI;
            _operationUI= operationUI;
            _nextFocusUI= nextFocusUI;
            _isRangeUI  = isRangeUI;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 制御を開始します。
        /// </summary>
        public void StartControl()
        {
            // 値があれば、操作にフォーカスしない
            ValueUI.ValueChanged += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    // TODO:▼次善処置
                    if (!ValueUI.Text.Equals(PreviousValue))
                    {
                        PreviousValue = ValueUI.Text;
                        CanFocusOperationUI = false;
                    }
                    else
                    {
                        CanFocusOperationUI = true;
                    }
                    // ▲次善処置

                    // 範囲指定の場合、タブ移動はしない
                    if (IsRangeUI)
                    {
                        if (OperationUI.TabStop) OperationUI.TabStop = false;
                        return;
                    }

                    if (string.IsNullOrEmpty(ValueUI.Text.Trim()))
                    {
                        OperationUI.TabStop = true;
                    }
                    else
                    {
                        OperationUI.TabStop = false;
                    }
                }
            );

            // 操作後に次のコントロールへフォーカス
            OperationUI.Click += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    // TODO:▼次善処置
                    OperationUI.Focus();
                    
                    if (!CanFocusOperationUI)
                    {
                        NextFocusUI.Focus();
                        CanFocusOperationUI = true;
                    }
                    // ▲次善処置

                    // Controlを継承しているコントロールがイベントソースになるはず…
                    try
                    {
                        if (((Control)sender).Tag == null) return;

                        bool canFocus = (bool)((Control)sender).Tag;
                        if (canFocus)
                        {
                            OperationUI.Focus();
                            ((Control)sender).Tag = false;
                        }
                        else
                        {
                            NextFocusUI.Focus();
                        }
                    }
                    catch (InvalidCastException) { }
                }
            );
        }
    }

    #region <Special Version/>

    /// <summary>
    /// 一般的なガイドのUIを制御するクラス
    /// </summary>
    public sealed class GeneralGuideUIController : GuideUIController<TextBoxType, Control, Control>
    {
        /// <summary>コントロールにフォーカスするフラグ</summary>
        public const bool CAN_FOCUS = true;

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="valueTextBox">値のテキストボックス</param>
        /// <param name="guideButton">ガイドボタン</param>
        /// <param name="nextFocusControl">次にフォーカスするコントロール</param>
        public GeneralGuideUIController(
            TextBoxType valueTextBox,
            Control guideButton,
            Control nextFocusControl
        ) : base(valueTextBox, guideButton, nextFocusControl)
        { }
    }

    /// <summary>
    /// 一般的な範囲指定ガイドのUIを制御するクラス
    /// </summary>
    public sealed class GeneralRangeGuideUIController : GuideUIController<TextBoxType, Control, Control>
    {
        /// <summary>コントロールにフォーカスするフラグ</summary>
        public const bool CAN_FOCUS = true;

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="valueTextBox">値のテキストボックス</param>
        /// <param name="guideButton">ガイドボタン</param>
        /// <param name="nextFocusControl">次にフォーカスするコントロール</param>
        public GeneralRangeGuideUIController(
            TextBoxType valueTextBox,
            Control guideButton,
            Control nextFocusControl
        ) : base(valueTextBox, guideButton, nextFocusControl, true)
        { }
    }

    #endregion  // <Special Version/>

    #endregion  // <ガイド制御/>

    #region <スペースキー制御/>

    /// <summary>
    /// コントロールのKeyPressイベントのヘルパクラス
    /// </summary>
    /// <typeparam name="TControl">コントロールの型</typeparam>
    /// <remarks>
    /// <br>Note       : 不具合対応[5710]にて追加</br>
    /// <br>Programmer : 30434 工藤 恵優</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public abstract class ControlKeyPressEventHelper<TControl> where TControl : Control
    {
        #region <コントロールのリスト/>

        /// <summary>コントロールのリスト</summary>
        private readonly IList<TControl> _controlList;
        /// <summary>
        /// コントロールのリストを取得します。
        /// </summary>
        /// <value>コントロールのリスト</value>
        public IList<TControl> ControlList
        {
            get { return _controlList; }
        }

        #endregion  // <コントロールのリスト/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected ControlKeyPressEventHelper()
        {
            _controlList = new List<TControl>();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// スペースキーの制御を開始します。
        /// </summary>
        public void StartSpaceKeyControl()
        {
            foreach (TControl control in ControlList)
            {
                control.KeyPress += new KeyPressEventHandler(this.Control_KeyPress);
            }
        }

        #region <イベントハンドラ/>

        /// <summary>
        /// スペースキーの制御を行うイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void Control_KeyPress(
            object sender,
            KeyPressEventArgs e
        )
        {
            if (e.KeyChar.Equals(' '))
            {
                ControlSpaceKey(sender, e);
            }
        }

        /// <summary>
        /// スペースキーの制御を行うイベントハンドラの実装
        /// </summary>
        /// <remarks>
        /// スペースキー押下時に呼び出されます。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected abstract void ControlSpaceKey(
            object sender,
            KeyPressEventArgs e
        );

        #endregion  // <イベントハンドラ/>
    }

    #region <UltraOptionSet/>

    /// <summary>
    /// UltraOptionSetコントロールのKeyPressイベントのヘルパクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 不具合対応[5710]にて追加</br>
    /// <br>Programmer : 30434 工藤 恵優</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public sealed class OptionSetKeyPressEventHelper : ControlKeyPressEventHelper<OptionSetType>
    {
        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OptionSetKeyPressEventHelper() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// スペースキーの制御を行うイベントハンドラの実装
        /// </summary>
        /// <remarks>
        /// スペースキー押下時に呼び出されます。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        [Obsolete("汎用的にするには要改造")]    // TODO:汎用的にするには要改造
        protected override void ControlSpaceKey(
            object sender,
            KeyPressEventArgs e
        )
        {
            #region <Guard Phrase/>

            if (ControlList.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            foreach (OptionSetType optionSet in ControlList)
            {
                // 選択項目が1つだけ
                if (optionSet.Items.Count.Equals(1))
                {
                    optionSet.Value = 0;
                    optionSet.CheckedIndex = 0;
                    optionSet.FocusedIndex = 0;
                    continue;
                }

                // 選択項目が2つ以上（通常）
                if (optionSet.CheckedIndex.Equals(optionSet.FocusedIndex))
                {
                    int nextOptionIndex = optionSet.CheckedIndex + 1;
                    if (nextOptionIndex >= optionSet.Items.Count)
                    {
                        nextOptionIndex = 0;
                    }
                    optionSet.Value = nextOptionIndex;
                    optionSet.CheckedIndex = nextOptionIndex;
                    optionSet.FocusedIndex = nextOptionIndex;
                }
                break; // TODO:先頭だけ
            }
        }
    }

    #endregion  // <UltraOptionSet/>

    #region <ラジオボタン/>

    /// <summary>
    /// ラジオボタンのKeyPressイベントのヘルパクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 不具合対応[5710]にて追加</br>
    /// <br>Programmer : 30434 工藤 恵優</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public sealed class RadioKeyPressEventHelper : ControlKeyPressEventHelper<RadioButton>
    {
        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public RadioKeyPressEventHelper() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 現在のコントロールリストのインデックスを取得します。
        /// </summary>
        /// <value>現在のコントロールリストのインデックス</value>
        private int CurrentIndex
        {
            get
            {
                for (int i = 0; i < ControlList.Count; i++)
                {
                    if (ControlList[i].Checked) return i;
                }
                return 0;
            }
        }

        /// <summary>
        /// スペースキーの制御を行うイベントハンドラの実装
        /// </summary>
        /// <remarks>
        /// スペースキー押下時に呼び出されます。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected override void ControlSpaceKey(
            object sender,
            KeyPressEventArgs e
        )
        {
            #region <Guard Phrase/>

            if (ControlList.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            if (ControlList[CurrentIndex].Checked)
            {
                int nextIndex = CurrentIndex + 1;
                if (nextIndex >= ControlList.Count) nextIndex = 0;

                ControlList[nextIndex].Focus();
                ControlList[nextIndex].Checked = true;
            }
        }
    }

    #endregion  // <ラジオボタン/>

    #endregion  // <スペースキー制御/>
}
