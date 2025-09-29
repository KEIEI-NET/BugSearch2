//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 操作履歴ログデータの書き込み
// プログラム概要   : 操作履歴ログデータ追加処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/05/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;


using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.IO;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 操作履歴ログデータの書き込みDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 操作履歴ログデータの書き込みDBの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class OperationLogSvrDB
    {

        #region ■ Const Memebers ■
        // 更新従業員コード
        private const string UPDEMPLOYEE_ID = "9999";
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 操作履歴ログデータモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 操作履歴ログデータの書き込みする。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.5.15</br>
        /// </remarks>
        public OperationLogSvrDB()
        {
        }
        #endregion

        # region ■ 操作履歴ログデータの書き込み関連 ■
        /// <summary>
        /// 操作履歴ログデータの書き込み。
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <param name="logDataCreateDateTime">時刻</param>
        /// <param name="logDataKind">ログ種別</param>
        /// <param name="programId">プログラムID</param>
        /// <param name="programName">プログラム名</param>
        /// <param name="methodName">メソッド名</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="status">ステータス</param>
        /// <param name="message">メッセージ</param>
        /// <param name="data">データ</param>
        /// <br>Note       : 操作履歴ログデータを書き込みする。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.5.15</br>
        public void WriteOperationLogSvr(object sender, DateTime logDataCreateDateTime, LogDataKind logDataKind,
                            string programId, string programName, string methodName, Int32 operationCode,
                            Int32 status, string message, string data)
        {

            // 企業コード
            string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 登録ヘッダ情報
            OprtnHisLogWork oprtnHisLogInsertWork = new OprtnHisLogWork();
            object objInsert = (object)this;
            IFileHeader insertIf = (IFileHeader)oprtnHisLogInsertWork;
            FileHeader fileInsert = new FileHeader(objInsert);
            fileInsert.SetInsertHeader(ref insertIf, objInsert);

            ArrayList oprtnHisLogWorkList = new ArrayList();
            OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
            // 作成日時
            oprtnHisLogWork.CreateDateTime = oprtnHisLogInsertWork.CreateDateTime;
            // 更新日時
            oprtnHisLogWork.UpdateDateTime = oprtnHisLogInsertWork.UpdateDateTime;
            // 企業コード
            oprtnHisLogWork.EnterpriseCode = _enterpriseCode;
            // GUID
            oprtnHisLogWork.FileHeaderGuid = oprtnHisLogInsertWork.FileHeaderGuid;
            // 更新従業員コード
            oprtnHisLogWork.UpdEmployeeCode = UPDEMPLOYEE_ID;
            // 更新アセンブリID1
            oprtnHisLogWork.UpdAssemblyId1 = oprtnHisLogInsertWork.UpdAssemblyId1;
            // 更新アセンブリID2
            oprtnHisLogWork.UpdAssemblyId2 = oprtnHisLogInsertWork.UpdAssemblyId2;
            // 論理削除区分
            oprtnHisLogWork.LogicalDeleteCode = oprtnHisLogInsertWork.LogicalDeleteCode;
            // ログデータ作成日時
            oprtnHisLogWork.LogDataCreateDateTime = logDataCreateDateTime;
            // ログデータGUID
            Guid guid = Guid.NewGuid();
            oprtnHisLogWork.LogDataGuid = guid;
            // ログデータ種別区分コード
            oprtnHisLogWork.LogDataKindCd = (int)logDataKind;
            // ログデータ対象起動プログラム名称
            oprtnHisLogWork.LogDataObjBootProgramNm = programName;
            // ログデータ対象アセンブリID
            oprtnHisLogWork.LogDataObjAssemblyID = programId;
            // ログデータ対象アセンブリ名称
            oprtnHisLogWork.LogDataObjAssemblyNm = programName;
            // ログデータ対象クラスID
            string[] senderInfo = this.GetSenderInfo(sender);
            oprtnHisLogWork.LogDataObjClassID = senderInfo[1];
            // ログデータ対象処理名
            oprtnHisLogWork.LogDataObjProcNm = methodName;
            // ログデータオペレーションコード
            oprtnHisLogWork.LogDataOperationCd = operationCode;
            // ログデータシステムバージョン
            oprtnHisLogWork.LogDataSystemVersion = senderInfo[2];
            // ログオペレーションステータス
            oprtnHisLogWork.LogOperationStatus = status;
            // ログデータメッセージ
            if (message.Length > 500)
            {
                oprtnHisLogWork.LogDataMassage = message.Substring(0, 500);
            }
            else
            {
                oprtnHisLogWork.LogDataMassage = message;
            }
            // ログオペレーションデータ
            if (data.Length > 80)
            {
                oprtnHisLogWork.LogOperationData = data.Substring(0, 80);
            }
            else
            {
                oprtnHisLogWork.LogOperationData = data;
            }
            oprtnHisLogWorkList.Add(oprtnHisLogWork);

            IOprtnHisLogDB iOprtnHisLogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();

            object objPara = (object)oprtnHisLogWorkList;

            // 操作履歴ログデータの書き込み。
            int dbStatus = iOprtnHisLogDB.Write(ref objPara);

        }

        /// <summary>
        /// オペレーションマスタの登録内容と整合性が取れている。
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : オペレーションマスタの登録内容と整合性が取れている。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.5.15</br>
        private string[] GetSenderInfo(object sender)
        {
            string[] strArray = new string[] { string.Empty, string.Empty, string.Empty };
            if (sender != null)
            {
                Type type = sender.GetType();
                AssemblyName name = type.Assembly.GetName();
                if (name != null)
                {
                    strArray[0] = name.Name;
                    strArray[2] = name.Version.ToString();
                }
                if (type != null)
                {
                    strArray[1] = type.Name;
                }
            }
            return strArray;
        }
        #endregion

    }
}
