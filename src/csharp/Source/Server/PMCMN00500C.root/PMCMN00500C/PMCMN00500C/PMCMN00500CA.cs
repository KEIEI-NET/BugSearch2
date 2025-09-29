//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Partsman Product定数定義クラス
// プログラム概要   : Partsman Product 共通定数管理クラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11601223-00  作成担当 : 佐々木亘
// 作 成 日  2021/10/12   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Net;

namespace Broadleaf.Application.Resources
{
    /// <summary>
    /// Partsman Product定数定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: Partsman Product 共通定数管理クラスです。</br>
    /// <br>Programmer	: 佐々木亘</br>
    /// <br>Date		: 2021/10/12</br>
    /// </remarks>
    public class ConstantManagement_PM_PRO
    {
        #region ■ public Members

        /// <summary> セキュリティプロトコル</summary>
        public enum ScrtyPrtclType : int
        {
              SSL30 = (int)SecurityProtocolType.Ssl3
            , TLS10 = (int)SecurityProtocolType.Tls
            , TLS11 = (int)(SecurityProtocolType)0x00000300
            , TLS12 = (int)(SecurityProtocolType)0x00000C00
        }
        #endregion ■ public Members

        # region ■ Constructor
        /// <summary>
        /// Partsman Product定数定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : Partsman Product定数定義クラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2021/10/12</br>
        /// </remarks>
        public ConstantManagement_PM_PRO()
        {
        }
        #endregion ■ Constructor

        #region ■ Public Methods

        #region 定数定義

        /// <summary> セキュリティプロトコル</summary>
        public static SecurityProtocolType ScrtyPrtcl
        {
            get
            {
                return (SecurityProtocolType)(
                      ScrtyPrtclType.SSL30
                    | ScrtyPrtclType.TLS10
                    | ScrtyPrtclType.TLS11
                    | ScrtyPrtclType.TLS12
                    );
            }
        }
        #endregion // 定数定義

        #endregion // ■ Public Methods

    }
}
