using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 自由帳票印刷系自動生成定数管理
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票印刷系自動生成で使用するconstを定義します</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CD
    {
        #region public const
        // -- 作成条件文字列 ---------------------------------------------
        /// <summary>各条件文字列の間隔</summary>
        public const string CT_ITEM_INTERVAL = "　　　　";

        // -- データソース＆データメンバー -------------------------------
        /// <summary>自由帳票印刷用データセット名</summary>
        public const string CT_FREPPRPRINTDS = "FREPPRPRINTDS";
        /// <summary>メイン印刷データ用データテーブル名</summary>
        public const string CT_FREPPRPRINT_MAIN_DT = "FREPPRPRINT_MAIN_DT";
        /// <summary>抽出条件用データテーブル名</summary>
        public const string CT_FREPPRPRINT_EXTR_DT = "FREPPRPRINT_EXTR_DT";
        /// <summary>帳票フッター文用データテーブル名</summary>
        public const string CT_FREPPRPRINT_PFTR_DT = "FREPPRPRINT_PFTR_DT";
        /// <summary>ソート順位用データテーブル名</summary>
        public const string CT_FREPPRPRINT_SRTO_DT = "FREPPRPRINT_SRTO_DT";

        // -- フィールド名 -----------------------------------------------
        // 帳票フッター文用データテーブル分
        /// <summary>帳票フッター文1</summary>
        public const string CT_PRINTFOOTER1 = "PRTOUTSETRF.PRINTFOOTER1RF";
        /// <summary>帳票フッター文2</summary>
        public const string CT_PRINTFOOTER2 = "PRTOUTSETRF.PRINTFOOTER2RF";

        // 抽出条件文字列分
        /// <summary>抽出条件文字列</summary>
        public const string CT_EXTRACTCONDS = "FREPPRPRINT_EXTRACT_CONDS";
        
        // ソート順位
        /// <summary>ソート順位</summary>
        public const string CT_SORTODER = "FREPPRPRINT_SORTODER";

        /// <summary>ソート順位1</summary>
        public const string CT_SORTODER1 = "FREPPRPRINT_SORTODER1";
        /// <summary>ソート順位2</summary>
        public const string CT_SORTODER2 = "FREPPRPRINT_SORTODER2";
        /// <summary>ソート順位3</summary>
        public const string CT_SORTODER3 = "FREPPRPRINT_SORTODER3";
        /// <summary>ソート順位4</summary>
        public const string CT_SORTODER4 = "FREPPRPRINT_SORTODER4";
        /// <summary>ソート順位5</summary>
        public const string CT_SORTODER5 = "FREPPRPRINT_SORTODER5";

////////////////////////////////////////////// 2008.02.07 TERASAKA ADD STA //
		// -- 伝票用コントロール名 -----------------------------------------------
		/// <summary>保険情報GroupHeader</summary>
		public const string CT_INSURINFO_GROUPHEADERNAME = "InsurHeader";
		/// <summary>保険情報GroupFooter</summary>
		public const string CT_INSURINFO_GROUPFOOTERNAME = "InsurFooter";
// 2008.02.07 TERASAKA ADD END //////////////////////////////////////////////
        #endregion
    }
}
