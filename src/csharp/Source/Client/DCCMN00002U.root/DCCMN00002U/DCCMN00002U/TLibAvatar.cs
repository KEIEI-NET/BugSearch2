using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// TLib代行クラス
    /// </summary>
    /// <remarks>SFCMN00001UのInternalクラス TLib と等価な文字チェック処理を提供します。</remarks>
    public class TLibAvatar
    {
        # region [許可文字パターン]
        /// <summary>
        /// 許可文字パターン
        /// </summary>
        public struct EnableChars
        {
            /// <summary>スペース許可</summary>
            private bool _space;
            /// <summary>記号許可</summary>
            private bool _sign;
            /// <summary>英字許可</summary>
            private bool _alpha;
            /// <summary>カナ許可</summary>
            private bool _kana;
            /// <summary>数値許可</summary>
            private bool _num;
            /// <summary>数値記号許可</summary>
            private bool _numSign;
            /// <summary>全角文字許可</summary>
            private bool _word;
            /// <summary>
            /// スペース許可
            /// </summary>
            public bool Space
            {
                get { return _space; }
                set { _space = value; }
            }
            /// <summary>
            /// 記号許可
            /// </summary>
            public bool Sign
            {
                get { return _sign; }
                set { _sign = value; }
            }
            /// <summary>
            /// 英字許可
            /// </summary>
            public bool Alpha
            {
                get { return _alpha; }
                set { _alpha = value; }
            }
            /// <summary>
            /// カナ許可
            /// </summary>
            public bool Kana
            {
                get { return _kana; }
                set { _kana = value; }
            }
            /// <summary>
            /// 数値許可
            /// </summary>
            public bool Num
            {
                get { return _num; }
                set { _num = value; }
            }
            /// <summary>
            /// 数値記号許可
            /// </summary>
            public bool NumSign
            {
                get { return _numSign; }
                set { _numSign = value; }
            }
            /// <summary>
            /// 全角文字許可
            /// </summary>
            public bool Word
            {
                get { return _word; }
                set { _word = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="space">スペース許可</param>
            /// <param name="sign">記号許可</param>
            /// <param name="alpha">英字許可</param>
            /// <param name="kana">カナ許可</param>
            /// <param name="num">数値許可</param>
            /// <param name="numSign">数値記号許可</param>
            /// <param name="word">全角文字許可</param>
            public EnableChars( bool space, bool sign, bool alpha, bool kana, bool num, bool numSign, bool word )
            {
                _space = space;
                _sign = sign;
                _alpha = alpha;
                _kana = kana;
                _num = num;
                _numSign = numSign;
                _word = word;
            }
        }
        # endregion

        # region [public static methods]
        /// <summary>
        /// 許可文字チェック処理
        /// </summary>
        /// <param name="key">文字</param>
        /// <param name="enableChars">許可文字パターン</param>
        /// <returns>true: 合致する / false: 合致しない</returns>
        public static bool CheckCharactor( char key, EnableChars enableChars )
        {
            // 空白除外
            if ( !enableChars.Space && (key == ' ') )
            {
                return false;
            }
            // 記号除外
            if ( !enableChars.Sign && TLibAvatar.IsSign( key ) )
            {
                return false;
            }
            // 英字除外
            if ( !enableChars.Alpha && TLibAvatar.IsAlpha( key ) )
            {
                return false;
            }
            // 半角カナ除外
            if ( !enableChars.Kana && TLibAvatar.IsKana( key ) )
            {
                return false;
            }
            // 数字除外
            if ( !enableChars.Num && TLibAvatar.IsNum( key ) )
            {
                return false;
            }
            // 数値記号除外
            if ( !enableChars.NumSign && TLibAvatar.IsNumSign( key ) )
            {
                return false;
            }
            // 全角文字除外
            if ( !enableChars.Word && TLibAvatar.IsWord( key ) )
            {
                return false;
            }
            // シングルクォーテーションは常に除外
            if ( key == '\'' )
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// アルファベット判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsAlpha( char key )
        {
            char[] arChk = new char[] 
            { 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 
                'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
                'w', 'x', 'y', 'z'
            };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// 制御文字判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsCtrl( char key )
        {
            return char.IsControl( key );
        }
        /// <summary>
        /// 半角ｶﾅ判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsKana( char key )
        {
            char[] arChk = new char[] 
            { 
                '｡', '｢', '｣', '､', '･', 'ｦ', 'ｧ', 'ｨ', 'ｩ', 'ｪ', 'ｫ', 'ｬ', 'ｭ', 'ｮ', 'ｯ', 'ｰ', 
                'ｱ', 'ｲ', 'ｳ', 'ｴ', 'ｵ', 'ｶ', 'ｷ', 'ｸ', 'ｹ', 'ｺ', 'ｻ', 'ｼ', 'ｽ', 'ｾ', 'ｿ', 'ﾀ', 
                'ﾁ', 'ﾂ', 'ﾃ', 'ﾄ', 'ﾅ', 'ﾆ', 'ﾇ', 'ﾈ', 'ﾉ', 'ﾊ', 'ﾋ', 'ﾌ', 'ﾍ', 'ﾎ', 'ﾏ', 'ﾐ', 
                'ﾑ', 'ﾒ', 'ﾓ', 'ﾔ', 'ﾕ', 'ﾖ', 'ﾗ', 'ﾘ', 'ﾙ', 'ﾚ', 'ﾛ', 'ﾜ', 'ﾝ', 'ﾞ', 'ﾟ'
            };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// 数値判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsNum( char key )
        {
            char[] arChk = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// 数値記号判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsNumSign( char key )
        {
            char[] arChk = new char[] { '-', '/', '*', '+', '=', '.', ',' };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// 記号判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsSign( char key )
        {
            char[] arChk = new char[] 
            { 
                '!', '"', '#', '$', '%', '&', '\'', '(', ')', ':', ';', '<', '>', '?', '@', '[', 
                '\\', ']', '^', '{', '|', '}', '~', '_'
            };
            return IsCharCheck( key, arChk );
        }
        /// <summary>
        /// 全角文字判定
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsWord( char key )
        {
            return ((((!IsSign( key ) && (key != ' ')) && (!IsKana( key ) && !IsAlpha( key ))) && (!IsNumSign( key ) && !IsNum( key ))) && !IsCtrl( key ));
        }
        # endregion

        # region [private static methods]
        /// <summary>
        /// 文字チェック処理実装
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arChk"></param>
        /// <returns></returns>
        private static bool IsCharCheck( char key, char[] arChk )
        {
            if ( arChk != null )
            {
                for ( int i = 0; i < arChk.Length; i++ )
                {
                    if ( arChk[i] == key )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        # endregion
    }
}
