//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/02/09  修正内容 : ・読み込み処理の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
// 2011/02/09 Add >>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
// 2011/02/09 Add <<<

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// SCM I/O Writerの代理人クラス
    /// </summary>
    public static class SCMIOWriterAgent
    {
        /// <summary>IOWriterのwritemode 0:Insert(更新日時R設定) 1:通常モード(更新日時UI設定。Updateあり)</summary>
        private const int WRITE_MODE = 1;

        /// <summary>
        /// 書込みます。
        /// </summary>
        /// <param name="writingList">書込むSCM受注系データ</param>
        /// <returns>結果ステータス</returns>
        public static KeyValuePair<int, object> Write(CustomSerializeArrayList writingList)
        {
            #region <Guard Phrase>

            if (ListUtil.IsNullOrEmpty(writingList))
            {
                return new KeyValuePair<int, object>((int)ResultUtil.ResultCode.Normal, writingList);
            }

            #endregion // <Guard Phrase>

            // 1パラ目
            object retScmCsObj = writingList;

            IIOWriteScmDB scmIOWriter = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            {
                int status = scmIOWriter.ScmWrite(ref retScmCsObj, WRITE_MODE);
                {
                }
                return new KeyValuePair<int, object>(status, retScmCsObj);
            }
        }

        // 2011/02/09 Add >>>

        // ----- UPD 2011/08/10 ----- >>>>>
        //public static int Read(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList)
        //{
        //    return ReadProc(scmReadWork,out scmHeaderWork,out scmCarWork,out scmDetailWorkList,out scmAnswerWorkList);
        //}

        /// <summary>
        /// SCM情報を取得します。
        /// </summary>
        /// <param name="scmReadWork">SCMReadデータ</param>
        /// <param name="scmHeaderWork">SCM受注データ</param>
        /// <param name="scmCarWork">SCM受注データ(車両情報)データ</param>
        /// <param name="scmDetailWorkList">SCM受注明細データ(問合せ・発注)のリスト</param>
        /// <param name="scmAnswerWorkList">SCM受注明細データ(回答)のリスト</param>
        /// <param name="scmAcOdSetDtWorkList">SCMセット部品データのリスト</param>
        /// <returns></returns>
        public static int Read(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList, out List<SCMAcOdSetDtWork> scmAcOdSetDtWorkList)
        {
            return ReadProc(scmReadWork, out scmHeaderWork, out scmCarWork, out scmDetailWorkList, out scmAnswerWorkList, out scmAcOdSetDtWorkList);
        }
        // ----- UPD 2011/08/10 ----- <<<<<

        /// <summary>
        /// SCM情報を取得します。
        /// </summary>
        /// <param name="scmReadWork">SCMReadデータ</param>
        /// <param name="scmHeaderWork">SCM受注データ</param>
        /// <param name="scmCarWork">SCM受注データ(車両情報)データ</param>
        /// <param name="scmDetailWorkList">SCM受注明細データ(問合せ・発注)のリスト</param>
        /// <param name="scmAnswerWorkList">SCM受注明細データ(回答)のリスト</param>
        /// <param name="scmAcOdSetDtWorkList">SCMセット部品データのリスト</param>
        /// <returns></returns>
        // ----- UPD 2011/08/10 ----- >>>>>
        //private static int ReadProc(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList)
        private static int ReadProc(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList, out List<SCMAcOdSetDtWork> scmAcOdSetDtWorkList)
        // ----- UPD 2011/08/10 ----- <<<<<
        {
            scmHeaderWork = null;
            scmCarWork = null;
            scmDetailWorkList = null;
            scmAnswerWorkList = null;
            scmAcOdSetDtWorkList = null; // ADD 2011/08/10
            object retSCMScObj = new CustomSerializeArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            IIOWriteScmDB scmIOWriter = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            {

                status = scmIOWriter.ScmRead(ref retSCMScObj, (object)scmReadWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ----- UPD 2011/08/10 ----- >>>>>
                    //IOWriterUtil.ExpandSCMReadRet(retSCMScObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork);
                    IOWriterUtil.ExpandSCMReadRet(retSCMScObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmAcOdSetDtWorkList, out scmCarWork);
                    // ----- UPD 2011/08/10 ----- <<<<<
                }
            }
            return status;
        }
        // 2011/02/09 Add <<<
    }
}
