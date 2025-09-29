//****************************************************************************//
// システム         : ＰＭ.ＮＳ
// プログラム名称   : PMデータ同期処理起動画面
// プログラム概要   : アクセスクラスの同期処理をコールする
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 林超凡
// 作 成 日  2014/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Common;
using System.Collections;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 受信処理自起動
    /// </summary>
    public partial class PMSCM04120UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region [ Private Member ]
        private SynchExecuteAcs _synchExecuteAcs;
        
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 受信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMSCM04120UA()
        {
            // 初期化処理
            InitializeComponent();
            this._synchExecuteAcs = new SynchExecuteAcs();
        }
        #endregion

        #region [ PMデータ同期処理起動画面 ]
        internal void RegularStart()
        {
            try
            {
                _synchExecuteAcs.RegularStart();
            }
            catch
            {
            }
        }

        internal void TranslateExecute()
        {
            try
            {
                _synchExecuteAcs.TranslateExecute();
            }
            catch
            {
            }
        }
        #endregion
    }
}