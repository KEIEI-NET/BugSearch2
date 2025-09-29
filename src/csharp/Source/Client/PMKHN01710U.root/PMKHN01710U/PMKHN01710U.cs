//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提案商品画面起動プログラム
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 3H 趙遠
// 作 成 日 : 2016/06/06   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Library.Forms
{
    /// <summary>
    /// 提案商品画面起動プログラムクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 提案商品画面起動プログラムのクラスです。</br>
    /// <br>Programmer  : 3H 趙遠</br>
    /// <br>Date        : 2016/06/06</br>
    /// <br></br>
    class PMKHN01710U : ApplicationContext
    {
        /// <summary>
        /// 提案商品画面起動プログラム
        /// </summary>
        /// <param name="main">提案商品起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : 提案商品画面起動プログラム</br>
        /// <br>Programmer : 3H 趙遠</br>
        /// <br>Date       : 2016/06/06</br>
        /// </remarks>
        public PMKHN01710U(Propose_Para_Main main)
        {
            SFMIT10201U obj = new SFMIT10201U();
            obj.FormClosed += new FormClosedEventHandler(OnFormClosed);
            obj.Show(main);
        }
        
        private void OnFormClosed(object sender, EventArgs e)
        {
            // スレッドのメッセージループ終了の呼出
            ExitThread();
        }
    }
}
