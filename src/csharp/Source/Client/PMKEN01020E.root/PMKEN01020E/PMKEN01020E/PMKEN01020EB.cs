using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>検索タイプ</summary>
    public enum SearchType
    {
        /// <summary>完全一致検索</summary>
        WholeWord = 0,
        /// <summary>前方一致検索</summary>
        PrefixSearch = 1,
        /// <summary>後方一致検索</summary>
        SuffixSearch = 2,
        /// <summary>曖昧検索</summary>
        FreeSearch = 3,
        /// <summary>ハイフン無し完全一致</summary>
        WholeWordWithNoHyphen = 4,
    }

    /// <summary>検索条件</summary>
    public enum SearchFlag
    {
        // BL検索用フラグ
        /// <summary>未使用フラグ[純正BLコード検索優先と同等]</summary>
        NoPrimeBlSearchFlag = 0,
        /// <summary>未使用フラグ[純正BLコード検索優先と同等]</summary>
        NoPrimeBlSearch = 0,
        /// <summary>純正BLコード検索優先</summary>
        BlSearch = 0,
        /// <summary>優良BLコード検索優先</summary>
        PrimeBlSearch = 1,

        // 品番検索用フラグ
        /// <summary>商品情報のみ[提供／優良] [商品マスメン用]</summary>
        GoodsInfoOnly = 2,
        /// <summary>商品情報及びセット情報[提供／優良]</summary>
        GoodsAndSetInfo = 3,
        /// <summary>品番結合検索[提供／優良]</summary>
        PartsNoJoinSearch = 4,
        /// <summary>品番結合検索[代替含]</summary>
        PartsNoJoinSearchSubst = 5,
    }

    /// <summary>次回表示UI指定フラグ</summary>
    public enum SelectUIKind
    {
        /// <summary>指定なし</summary>
        None = 0,
        /// <summary>代替選択UI指定</summary>
        Subst = 1,
        /// <summary>結合選択UI指定</summary>
        Join = 2,
        /// <summary>セット選択UI指定</summary>
        Set = 3,
        /// <summary>同一品番選択UI指定[内部処理用]</summary>
        SamePartsNo = 4,
        /// <summary>部品選択UI指定[内部処理用]</summary>
        PartsSelection = 5,
        /// <summary>優良部品選択UI指定[内部処理用]</summary>
        PrimeSearchParts = 6
    }

    /// <summary>商品区分</summary>
    public enum GoodsKind
    {
        /// <summary>指定なしの部品</summary>
        NotDesignated = 0,
        /// <summary>結合・セット・代替の元になる部品(デフォルト)</summary>
        Parent = 1,
        /// <summary>結合先の部品</summary>
        Join = 2,
        /// <summary>セット子部品</summary>
        Set = 4,
        /// <summary>代替先の部品</summary>
        Subst = 8,
        /// <summary>複数代替先（互換）部品</summary>
        SubstPlrl = 16
    }

    // ===================================================================================== //
    // 構造体
    // ===================================================================================== //
    #region Struct
    /// <summary>
    /// 優良設定マスタキー構造体
    /// </summary>
    public struct PrmSettingKey
    {
        string _sectionCode;
        int _goodsMGroup;
        int _tbsPartsCode;
        int _partsMakerCd;

        /// <summary>
        /// 優良設定マスタキー構造体
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="tbsPartsCode"></param>
        /// <param name="partsMakerCd"></param>
        public PrmSettingKey(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd)
        {
            this._sectionCode = sectionCode;
            this._goodsMGroup = goodsMGroup;
            this._tbsPartsCode = tbsPartsCode;
            this._partsMakerCd = partsMakerCd;
        }
    }

    /// <summary>
    /// 品番複数検索用条件クラス
    /// </summary>
    public class SrchCond
    {
        /// <summary>メーカーコード</summary>
        public int makerCd;
        /// <summary>品番</summary>
        public string partsNo = string.Empty;
    }
    # endregion
}
