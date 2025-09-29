//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会
// プログラム概要   : SCM問合せログテーブルに対して検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/19  修正内容 : Redmine#17394
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/24  修正内容 : Redmine#17505
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <remarks>
    /// <br>Note       : 他社部品検索履歴照会のアクセスクラスです。</br>
    /// <br>Programmer : 朱 猛</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    public class ScmInqLogAcs
    {
        #region ■ Private Members ■
        // SCM問合せログデータセット
        private ScmInqLogInquiryDataSet _scmInqLogDataSet;
        // SCM問合せログデータテーブル
        private ScmInqLogInquiryDataSet.ScmInqLogInquiryDataTable _scmInqLogDataTable;
        private IScmInqLogInquiryDB _iScmInqLogDB;
        private static ScmInqLogAcs _scmInqLogAcs;
        #endregion ■ Private Members ■

        #region ■ Properties ■

        /// <summary>
        /// SCM問合せログデータテーブルプロパティ
        /// </summary>
        public ScmInqLogInquiryDataSet.ScmInqLogInquiryDataTable ScmInqLogDataTable
        {
            get { return _scmInqLogDataTable; }
        }
        #endregion ■ Properties ■

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private ScmInqLogAcs()
        {
            // 変数初期化
            this._scmInqLogDataSet = new ScmInqLogInquiryDataSet();
            this._scmInqLogDataTable = this._scmInqLogDataSet.ScmInqLogInquiry;
            this._iScmInqLogDB = MediationScmInqLogInquiryDB.GetIScmInqLogInquiryDB();
        }
        # endregion ■ Constructor ■

        /// <summary>
        /// 拠点管理設定情報を取得して、送信処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="readMode">読込モード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : SCM問合せログ取得処理を行う。</br>      
        /// <br>Programmer : 朱 猛</br>                                  
        /// <br>Date       : 2010/11/11</br> 
        /// </remarks>
        //public int search(ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode) // DEL 2010/11/19
        public int search(ref object scmInqLogInquirySearchPara, int readMode) // ADD 2010/11/19
        {
            ArrayList outScmInqLogList = new ArrayList();
            object outObj = outScmInqLogList as object;

            //int status = this._iScmInqLogDB.Search(out outObj, scmInqLogInquirySearchPara, readMode); // DEL 2010/11/19
            int status = this._iScmInqLogDB.Search(out outObj, ref scmInqLogInquirySearchPara, readMode); // ADD 2010/11/19
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                outScmInqLogList = (ArrayList)outObj;
                int i = 1;
                this._scmInqLogDataTable.Clear();
                // ---UPD 2010/11/24 ------------------------------->>>
                //foreach (ScmInqLogInquiryWork scmInqLog in outScmInqLogList)
                //{
                //    ScmInqLogInquiryDataSet.ScmInqLogInquiryRow scmInqLogRow = this._scmInqLogDataTable.NewScmInqLogInquiryRow();
                //    scmInqLogRow.CnectOriginalEpNm = scmInqLog.CnectOriginalEpNm;
                //    //scmInqLogRow.CreateDateTime = scmInqLog.CreateDateTime; // DEL 2010/11/19
                //    scmInqLogRow.CreateDate = scmInqLog.CreateDateTime.Date; // ADD 2010/11/19
                //    scmInqLogRow.CreateTime = scmInqLog.CreateDateTime.TimeOfDay.ToString().Substring(0, 8); // ADD 2010/11/19
                //    scmInqLogRow.RowNo = i++;
                //    scmInqLogRow.ScmInqContents = scmInqLog.ScmInqContents;
                //    switch (scmInqLog.InqDataInputSystem)
                //    {
                //        case 1:
                //            scmInqLogRow.UseSystem = "SF.NS";
                //            break;
                //        case 2:
                //            scmInqLogRow.UseSystem = "BK/BF.NS";
                //            break;
                //        case 3:
                //            scmInqLogRow.UseSystem = "RC.NS";
                //            break;
                //        case 4:
                //            scmInqLogRow.UseSystem = "SF7";
                //            break;
                //        case 5:
                //            scmInqLogRow.UseSystem = "BKパーフェクト";
                //            break;
                //        case 6:
                //            scmInqLogRow.UseSystem = "RC7";
                //            break;
                //        default:
                //            break;
                //    }
                //    this._scmInqLogDataTable.Rows.Add(scmInqLogRow);
                //}
                this._scmInqLogDataTable.BeginLoadData();
                try
                {
                    foreach (ScmInqLogInquiryWork scmInqLog in outScmInqLogList)
                    {
                        ScmInqLogInquiryDataSet.ScmInqLogInquiryRow scmInqLogRow = this._scmInqLogDataTable.NewScmInqLogInquiryRow();
                        scmInqLogRow.CnectOriginalEpNm = scmInqLog.CnectOriginalEpNm;
                        scmInqLogRow.CreateDate = scmInqLog.CreateDateTime.Date;
                        scmInqLogRow.CreateTime = scmInqLog.CreateDateTime.TimeOfDay.ToString().Substring(0, 8); // ADD 2010/11/19
                        scmInqLogRow.RowNo = i++;
                        scmInqLogRow.ScmInqContents = scmInqLog.ScmInqContents;
                        switch (scmInqLog.InqDataInputSystem)
                        {
                            case 1:
                                scmInqLogRow.UseSystem = "SF.NS";
                                break;
                            case 2:
                                scmInqLogRow.UseSystem = "BK/BF.NS";
                                break;
                            case 3:
                                scmInqLogRow.UseSystem = "RC.NS";
                                break;
                            case 4:
                                scmInqLogRow.UseSystem = "SF7";
                                break;
                            case 5:
                                scmInqLogRow.UseSystem = "BKパーフェクト";
                                break;
                            case 6:
                                scmInqLogRow.UseSystem = "RC7";
                                break;
                            default:
                                break;
                        }
                        this._scmInqLogDataTable.Rows.Add(scmInqLogRow);
                    }
                }
                finally
                {
                    this._scmInqLogDataTable.EndLoadData();
                }
                // ---UPD 2010/11/24 -------------------------------<<<
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._scmInqLogDataTable.Clear();
                return status;
            }
            else
            {
                return status;
            }
        }

        # region ■ SCM問合せログアクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// SCM問合せログアクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM問合せログ取得処理を行う。</br>      
        /// <br>Programmer : 朱 猛</br>                                  
        /// <br>Date       : 2010/11/11</br> 
        /// </remarks>
        public static ScmInqLogAcs GetInstance()
        {
            if (_scmInqLogAcs == null)
            {
                _scmInqLogAcs = new ScmInqLogAcs();
            }

            return _scmInqLogAcs;
        }
        # endregion ■ SCM問合せログアクセスクラス インスタンス取得処理 ■
    }
}
