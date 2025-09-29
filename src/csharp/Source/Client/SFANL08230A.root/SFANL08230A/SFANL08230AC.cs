using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由帳票印字位置DL定数定義クラス
    /// </summary>
    public class SFANL08230AC
    {
        #region Public Const
        // テーブル名称
        /// <summary>印字位置（ユーザー）テーブル</summary>
        public const string TABLE_USER = "TABEL_USER";
        /// <summary>印字位置（提供）テーブル</summary>
        public const string TABLE_OFFER = "TABLE_OFFER";

        // カラム名称
        /// <summary>上書き選択フラグ</summary>
        public const string COL_USER_SELECT_UPDATE = "SELECT_UPDATE_USER";
        /// <summary>既存フラグ</summary>
        public const string COL_USER_EXISTFLG = "EXISTFLG_USER";
        /// <summary>更新フラグ</summary>
        public const string COL_USER_UPDATEFLG = "UPDATEFLG_USER";
        /// <summary>状態</summary>
        public const string COL_USER_STATUS = "STATUS_USER";
        /// <summary>キー</summary>
        public const string COL_USER_KEY = "KEY_USER";
        /// <summary>出力ファイル名</summary>
        public const string COL_USER_OUTPUTFORMFILENAME = "OUTPUTFORMFILENAME_USER";
        /// <summary>出力名称</summary>
        public const string COL_USER_DISPLAYNAME = "DISPLAYNAME_USER";
        /// <summary>ユーザー帳票ID枝番号</summary>
        public const string COL_USER_USERPRTPPRIDDERIVNO = "USERPRTPPRIDDERIVNO_USER";
        /// <summary>帳票ユーザー枝番コメント</summary>
        public const string COL_USER_PRTPPRUSERDERIVNOCMT = "PRTPPRUSERDERIVNOCMT_USER";
        /// <summary>印字項目グループコード</summary>
        public const string COL_USER_FREEPRTPPRITEMGRPCD = "FREEPRTPPRITEMGRPCD_USER";
        /// <summary>サーバー更新日時</summary>
        public const string COL_USER_UPDATETIME = "UPDATETIME_USER";
        /// <summary>システム区分</summary>
        public const string COL_USER_SYSTEMDIVCD = "SYSTEMDIVCD_USER";
        /// <summary>システム区分名称</summary>
        public const string COL_USER_SYSTEMDIVNAME = "SYSTEMDIVNAME_USER";
        /// <summary>オプションコード</summary>
        public const string COL_USER_OPTIONCODE = "OPTIONCODE_USER";
        /// <summary>オプション名称</summary>
        public const string COL_USER_OPTIONNAME = "OPTIONNAME_USER";
        /// <summary>帳票使用区分コード</summary>
        public const string COL_USER_PRINTPAPERUSEDIVCD = "PRINTPAPERUSEDIVCD_USER";
        /// <summary>帳票使用区分名称</summary>
        public const string COL_USER_PRINTPAPERUSEDIVCDNM = "PRINTPAPERUSEDIVCDNM_USER";

        ///// <summary>No.（グリッド表示用）</summary>
        /// <summary>選択フラグ</summary>
        public const string COL_OFFER_SELECT = "SELECT_OFFER";
        /// <summary>キー</summary>
        public const string COL_OFFER_KEY = "KEY_OFFER";
        /// <summary>出力ファイル名</summary>
        public const string COL_OFFER_OUTPUTFORMFILENAME = "OUTPUTFORMFILENAME_OFFER";
        /// <summary>出力名称</summary>
        public const string COL_OFFER_DISPLAYNAME = "DISPLAYNAME_OFFER";
        /// <summary>ユーザー帳票ID枝番号</summary>
        public const string COL_OFFER_USERPRTPPRIDDERIVNO = "USERPRTPPRIDDERIVNO_OFFER";
        /// <summary>帳票ユーザー枝番コメント</summary>
        public const string COL_OFFER_PRTPPRUSERDERIVNOCMT = "PRTPPRUSERDERIVNOCMT_OFFER";
        /// <summary>印字項目グループ</summary>
        public const string COL_OFFER_FREEPRTPPRITEMGRPCD = "FREEPRTPPRITEMGRPCD_OFFER";
        /// <summary>サーバー更新日時(表示用)</summary>
        public const string COL_OFFER_UPDATETIMESTR = "UPDATETIMESTR_OFFER";
        /// <summary>サーバー更新日時</summary>
        public const string COL_OFFER_UPDATETIME = "UPDATETIME_OFFER";
        /// <summary>システム区分</summary>
        public const string COL_OFFER_SYSTEMDIVCD = "SYSTEMDIVCD_OFFER";
        /// <summary>システム区分名称</summary>
        public const string COL_OFFER_SYSTEMDIVNAME = "SYSTEMDIVNAME_OFFER";
        /// <summary>オプションコード</summary>
        public const string COL_OFFER_OPTIONCODE = "OPTIONCODE_OFFER";
        /// <summary>オプション名称</summary>
        public const string COL_OFFER_OPTIONNAME = "OPTIONNAME_OFFER";
        /// <summary>未ダウンロード</summary>
        public const string COL_OFFER_NO_DOWNLOAD = "NO_DOWNLOAD_OFFER";
        /// <summary>新バージョン</summary>
        public const string COL_OFFER_NEW_VERSION = "NEW_VERSION_OFFER";
        /// <summary>帳票使用区分コード</summary>
        public const string COL_OFFER_PRINTPAPERUSEDIVCD = "PRINTPAPERUSEDIVCD_OFFER";
        /// <summary>帳票使用区分名称</summary>
        public const string COL_OFFER_PRINTPAPERUSEDIVCDNM = "PRINTPAPERUSEDIVCDNM_OFFER";
        /// <summary>取込画像コード</summary>
        public const string COL_OFFER_TAKEINIMAGEGROUPCD = "TAKEINIMAGEGROUPCD_OFFER";


        /// <summary>更新フラグ(なし)</summary>
        public const int UPDATEFLG_NONE = 0;
        /// <summary>更新フラグ(上書き更新)</summary>
        public const int UPDATEFLG_UPDATE = 1;
        # endregion
    }
}
