//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品データ削除処理　アクセスクラス
// プログラム概要   : 検品データテーブルに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/05/22  修正内容 : 新規作成
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
    /// 検品データ削除処理　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品データテーブルの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/05/22</br>
    /// </remarks>
    public class InspectDataAcs
    {
        // 検品データDBリモートオブジェクト
        private IInspectDataDB _inspectDataDB;
        // 検品データ削除処理アクセスクラス
        private static InspectDataAcs _inspectDataAcs;

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private InspectDataAcs()
        {
            this._inspectDataDB = MediationInspectDataDB.GetDeleteInspectDataDB();
        }

        /// <summary>
        /// 検品データ削除処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>検品データ削除処理アクセスクラス インスタンス</returns>
        public static InspectDataAcs GetInstance()
        {
            if (_inspectDataAcs == null)
            {
                _inspectDataAcs = new InspectDataAcs();
            }

            return _inspectDataAcs;
        }
        # endregion ■ Constructor ■

        # region ■ 検品データの削除処理 ■
        /// <summary>
        /// 検品データ削除処理
        /// </summary>
        /// <param name="inspectDataWork">検品データパラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 検品データ削除処理する。</br>
        /// <br>Programmer : 3H 張小磊</br>                                  
        /// <br>Date       : 2017/05/22</br> 
        /// </remarks>
        public int DeleteData(InspectDataWork inspectDataWork, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            object inspectDataObj = new object();

            if (inspectDataWork != null)
            {
                inspectDataObj = (object)inspectDataWork;
            }

            // 検品データ削除処理
            status = this._inspectDataDB.DeleteInspectData(ref inspectDataObj, out retMessage);

            return status;
        }

        # endregion ■ 検品データの削除処理 ■
    }
}
