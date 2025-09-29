//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTABセッション管理データ削除処理　アクセスクラス
// プログラム概要   : PMTABセッション管理データテーブルに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11300141-00 作成担当 : 譚洪
// 作 成 日  2017/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTABセッション管理データ削除処理　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTABセッション管理データテーブルの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/04/06</br>
    /// </remarks>
    public class PmTabSessionMngAcs
    {
        private IPmTabSessionMngDB _pmTabSessionMngDB;
        private static PmTabSessionMngAcs _pmTabSessionMngAcs;

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private PmTabSessionMngAcs()
        {
            this._pmTabSessionMngDB = MediationPmTabSessionMngDB.GetDeletePmTabSessionDateDB();
        }

        /// <summary>
        /// PMTABセッション管理データ削除処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>PMTABセッション管理データ削除処理アクセスクラス インスタンス</returns>
        public static PmTabSessionMngAcs GetInstance()
        {
            if (_pmTabSessionMngAcs == null)
            {
                _pmTabSessionMngAcs = new PmTabSessionMngAcs();
            }

            return _pmTabSessionMngAcs;
        }
        # endregion ■ Constructor ■

        # region ■ PMTABセッション管理データの削除処理 ■
        /// <summary>
        /// PMTABセッション管理データ削除処理
        /// </summary>
        /// <param name="pmTabSessionMngWork">PMTABセッション管理データパラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データ削除処理する。</br>
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2017/04/06</br> 
        /// </remarks>
        public int DeleteData(PmTabSessionMngWork pmTabSessionMngWork, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            object pmTabSessionMngObj = new object();

            if (pmTabSessionMngWork != null)
            {
                pmTabSessionMngObj = (object)pmTabSessionMngWork;
            }
            
            status = this._pmTabSessionMngDB.DeleteSessionMng(ref pmTabSessionMngObj, out retMessage);

            return status;
        }

        # endregion ■ PMTABセッション管理データの削除処理 ■
    }
}
