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
    /// バージョン情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : バージョン情報クラスの定義と実装</br>
    /// <br>Programmer : 森山　浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00803AD
    {

        #region << private変数 >>

        /// <summary>
        /// ファイル名
        /// </summary>
        public string fileName;

        /// <summary>
        /// 更新日付
        /// </summary>
        public DateTime changeDateTime;

        #endregion

        /// public propaty name  :  FileName
        /// <summary>ファイル名</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// public propaty name  :  ChangeDateTime
        /// <summary>更新日付</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日付</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ChangeDateTime
        {
            get { return changeDateTime; }
            set { changeDateTime = value; }
        }

    }
}
