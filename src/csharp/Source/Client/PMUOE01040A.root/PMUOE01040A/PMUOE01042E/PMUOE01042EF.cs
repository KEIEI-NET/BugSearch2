//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報定義クラス
// プログラム概要   : ＵＯＥ回答情報確定用 仕入ヘッダ・明細情報を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ＵＯＥ回答情報確定用＜仕入ヘッダ・明細情報＞
    /// </summary>
    public class StockSlipGrp
    {
        public StockSlipWork stockSlipWork = null;
        public List<StockDetailWork> stockDetailWorkList = null;

        public StockSlipGrp()
        {
            Clear();
        }

        public void Clear()
        {
            stockSlipWork = new StockSlipWork();

            if (stockDetailWorkList == null)
            {
                stockDetailWorkList = new List<StockDetailWork>();
            }
            else
            {
                stockDetailWorkList.Clear();
            }
        }
    }

}
