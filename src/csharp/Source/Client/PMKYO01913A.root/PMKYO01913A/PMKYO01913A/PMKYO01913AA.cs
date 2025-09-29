//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受信エラーチェック処理
// プログラム概要   : ユーザデータに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 作 成 日  2011/07/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  2011/09/05  作成担当 : 孫東響
// 修 正 日              修正内容 : #24361 拠点管理自動受信常駐PG
//                                  アクセスクラスの論理削除について
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受信エラーチェックアクセスクラス
    /// </summary>
    public class OprtnHisLogAcs
    {
        #region private
        IOprtnHisLogDB iOprtnHisLogDB;
        string _dataMsg = "締月次受信エラー";
        ArrayList workList = new ArrayList();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OprtnHisLogAcs()
        {

        }
        #endregion

        #region ロジック処理
        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します
        /// </summary>
        /// <param name="list">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報を検索します</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.08.04</br>
        public void SearchLog(out ArrayList list)
        {
            list = new ArrayList();
            object obj = new object();
            if(iOprtnHisLogDB == null)
            {
                iOprtnHisLogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            }
            //検索条件クラス構築
            OprtnHisLogSrchWork oprtnHisLogSrchWork = new OprtnHisLogSrchWork();
            oprtnHisLogSrchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            oprtnHisLogSrchWork.LogDataObjAssemblyID = "PMKYO01100U";
            oprtnHisLogSrchWork.St_LogDataCreateDateTime = new DateTime(1800,1,1);
            oprtnHisLogSrchWork.Ed_LogDataCreateDateTime = DateTime.Now;
            oprtnHisLogSrchWork.LogDataKindCd = (int)LogDataKind.ErrorLog;
            oprtnHisLogSrchWork.LogDataOperationCd = 12;

            //検索を行う
            int status = iOprtnHisLogDB.Search(ref obj, oprtnHisLogSrchWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

            workList = (ArrayList)obj;

            //検索結果処理
            for (int i = 0; i < workList.Count; i++)
            {
                try
                {
                    OprtnHisLogWork oprtnHisLogWork = (OprtnHisLogWork)workList[i];
                    PMKYO01901EA errInfo = new PMKYO01901EA();
                    if (oprtnHisLogWork.LogDataMassage.Contains(_dataMsg))
                    {
                        string[] data = oprtnHisLogWork.LogDataMassage.Split('　');
                        errInfo.NoFlg = data[1];
                        errInfo.No = data[2];
                        errInfo.Date = data[3];
                        errInfo.SectionCode = data[4];
                        errInfo.SectionNm = data[5];
                        errInfo.CustomerCode = data[6];
                        errInfo.CustomerNm = data[7];
                        errInfo.Error = data[8];
                        list.Add(errInfo);
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 操作履歴ログデータ情報を論理削除します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を論理削除します</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.08.04</br>
        public void LogicalDelete()
        {
            if (iOprtnHisLogDB == null)
            {
                iOprtnHisLogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            }
            //DEL #24361 拠点管理自動受信常駐PGアクセスクラスの論理削除について----->>>>>
            //for (int i = 0; i < workList.Count; i++)
            //{
            //    object oprtnHisLogWork = (object)workList[i];
            //    iOprtnHisLogDB.LogicalDelete(ref oprtnHisLogWork);
            //}
            //DEL #24361 拠点管理自動受信常駐PGアクセスクラスの論理削除について-----<<<<<
            //ADD #24361 拠点管理自動受信常駐PGアクセスクラスの論理削除について----->>>>>            
            object oprtnHisLogWork = (object)workList;
            iOprtnHisLogDB.LogicalDelete(ref oprtnHisLogWork); 
            //ADD #24361 拠点管理自動受信常駐PGアクセスクラスの論理削除について-----<<<<<
        }
        #endregion
    }
}
