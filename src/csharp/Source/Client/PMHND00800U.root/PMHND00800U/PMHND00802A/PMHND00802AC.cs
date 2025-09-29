//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : HTプログラム導入処理
// プログラム概要   : HTプログラム導入処理ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 森山　浩
// 作 成 日  2017/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HTプログラム導入処理定数クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : HTプログラム導入処理定数クラスの定義と実装</br>
    /// <br>Programmer : 森山　浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00802AC
    {

        /// <summary>
        /// パラメータチェックエラー
        /// </summary>
        public static int ParamCheckError = -1;

        /// <summary>
        /// 通常メニューモード
        /// </summary>
        public static int NormalMenuMode = 0;

        /// <summary>
        /// サポートメニューモード
        /// </summary>
        public static int SupportMenuMode = 1;

        /// <summary>
        /// バージョンチェックモード
        /// </summary>
        public static int VersionCheckMode = 2;
    }
}
