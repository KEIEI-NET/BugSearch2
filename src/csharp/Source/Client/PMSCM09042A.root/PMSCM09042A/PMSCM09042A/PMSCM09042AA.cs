//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM新着通知設定マスタ
// プログラム概要   : SCM新着通知設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/09/03  修正内容 : チケット[14236]対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM新着通知設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM新着通知設定テーブルのアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
    public class SCMNewArrNtfyStAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private ISCMNewArrNtfyStDB _iSCMNewArrNtfyStDB = null;

        #endregion

        #region -- コンストラクタ --
        /// <summary>
        /// SCM新着通知設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : SCM新着通知設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public SCMNewArrNtfyStAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iSCMNewArrNtfyStDB = (ISCMNewArrNtfyStDB)MediationSCMNewArrNtfyStDB.GetSCMNewArrNtfyStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSCMNewArrNtfyStDB = null;
            }
		}
        #endregion

        #region -- オンラインモード取得処理 --
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSCMNewArrNtfyStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion

        #region -- 読み込み処理 --
        /// <summary>
		/// 読み込み処理
		/// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
		/// <param name="enterpriseCode">企業コード</param> 
		/// <param name="sectionCode">拠点コード</param>  
		/// <param name="customerCode">得意先コード</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out SCMNewArrNtfySt scmNewArrNtfySt, string enterpriseCode, string sectionCode, int customerCode)
        {
            return ReadProc(out scmNewArrNtfySt, enterpriseCode, sectionCode, customerCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>  
		/// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMNewArrNtfySt scmNewArrNtfySt, string enterpriseCode, string sectionCode, int customerCode)
		{
            int status = 0;

            scmNewArrNtfySt = null;

			try
			{
                SCMNewArrNtfyStWork scmNewArrNtfyStWork = new SCMNewArrNtfyStWork();
                scmNewArrNtfyStWork.EnterpriseCode = enterpriseCode;
                scmNewArrNtfyStWork.SectionCode = sectionCode;
                scmNewArrNtfyStWork.CustomerCode = customerCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmNewArrNtfyStWork);

                status = this._iSCMNewArrNtfyStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    scmNewArrNtfyStWork = (SCMNewArrNtfyStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMNewArrNtfyStWork));
                    // ワーク→UIデータクラス
                    scmNewArrNtfySt = CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(scmNewArrNtfyStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				scmNewArrNtfySt = null;
				// オフライン時はnullをセット
                this._iSCMNewArrNtfyStDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
        #endregion

        #region -- 登録･更新処理 --
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の登録・更新を行います</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref SCMNewArrNtfySt scmNewArrNtfySt)
        {
            int status = 0;

			// UIデータクラス→ワーク
            SCMNewArrNtfyStWork scmNewArrNtfyStWork = CopyToSCMNewArrNtfyStWorkFromSCMNewArrNtfySt(scmNewArrNtfySt);

            object obj = scmNewArrNtfyStWork;
			
			try
			{
				// 書き込み処理
                status = this._iSCMNewArrNtfyStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        scmNewArrNtfyStWork = (SCMNewArrNtfyStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        scmNewArrNtfySt = CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(scmNewArrNtfyStWork);
                    }
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
                this._iSCMNewArrNtfyStDB = null;
				// 通信エラーは-1を戻す
				status = -1;
			}
			return status;
        }
        #endregion

        #region -- 削除処理 --
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref SCMNewArrNtfySt scmNewArrNtfySt)
        {
            int status = 0;

            // UIデータクラス→ワーク
            SCMNewArrNtfyStWork scmNewArrNtfyStWork = CopyToSCMNewArrNtfyStWorkFromSCMNewArrNtfySt(scmNewArrNtfySt);

            object obj = scmNewArrNtfyStWork;

            try
            {
                // 論理削除
                status = this._iSCMNewArrNtfyStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmNewArrNtfyStWork = (SCMNewArrNtfyStWork)obj;
                    // ワーク→UIデータクラス
                    scmNewArrNtfySt = CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(scmNewArrNtfyStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMNewArrNtfyStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の物理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Delete(SCMNewArrNtfySt scmNewArrNtfySt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMNewArrNtfyStWork scmNewArrNtfyStWork = CopyToSCMNewArrNtfyStWorkFromSCMNewArrNtfySt(scmNewArrNtfySt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmNewArrNtfyStWork);

                // 物理削除
                status = this._iSCMNewArrNtfyStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMNewArrNtfyStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 復活処理 --
        /// <summary>
        /// 論理削除復活処理
        /// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の論理削除復活を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMNewArrNtfySt scmNewArrNtfySt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMNewArrNtfyStWork scmNewArrNtfyStWork = CopyToSCMNewArrNtfyStWorkFromSCMNewArrNtfySt(scmNewArrNtfySt);

                object obj = scmNewArrNtfyStWork;

                // 復活処理
                status = this._iSCMNewArrNtfyStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmNewArrNtfyStWork = (SCMNewArrNtfyStWork)obj;
                    // ワーク→UIデータクラス
                    scmNewArrNtfySt = CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(scmNewArrNtfyStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMNewArrNtfyStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// SCM新着通知設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// SCM新着通知設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の検索処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            SCMNewArrNtfyStWork scmNewArrNtfyStWork = new SCMNewArrNtfyStWork();
            scmNewArrNtfyStWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = scmNewArrNtfyStWork;
            object retobj = null;

            // SCM全体設定の全検索
            status = this._iSCMNewArrNtfyStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMNewArrNtfyStWork wkSCMNewArrNtfyStWork in workList)
                {
                    retList.Add(CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(wkSCMNewArrNtfyStWork));
                }
            }

            return status;
        }

        // ADD 2009/09/03 チケット[14236]対応 ---------->>>>>
        /// <summary>
        /// SCM新着通知設定検索処理(論理削除データ含まない)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM新着通知設定の検索処理を行います。論理削除データは抽出対象に含みません。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAvailable(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            SCMNewArrNtfyStWork scmNewArrNtfyStWork = new SCMNewArrNtfyStWork();
            scmNewArrNtfyStWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = scmNewArrNtfyStWork;
            object retobj = null;

            // SCM全体設定の全検索
            status = this._iSCMNewArrNtfyStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMNewArrNtfyStWork wkSCMNewArrNtfyStWork in workList)
                {
                    if (wkSCMNewArrNtfyStWork.LogicalDeleteCode.Equals(0))
                    {
                        retList.Add(CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(wkSCMNewArrNtfyStWork));
                    }
                }
            }

            return status;
        }
        // ADD 2009/09/03 チケット[14236]対応 ----------<<<<<

        #endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
        /// </summary>
        /// <param name="scmNewArrNtfyStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
        /// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private SCMNewArrNtfySt CopyToSCMNewArrNtfyStFromSCMNewArrNtfyStWork(SCMNewArrNtfyStWork scmNewArrNtfyStWork)
        {
            SCMNewArrNtfySt scmNewArrNtfySt = new SCMNewArrNtfySt();

            scmNewArrNtfySt.CreateDateTime = scmNewArrNtfyStWork.CreateDateTime;        // 作成日時
            scmNewArrNtfySt.UpdateDateTime = scmNewArrNtfyStWork.UpdateDateTime;        // 更新日時
            scmNewArrNtfySt.EnterpriseCode = scmNewArrNtfyStWork.EnterpriseCode;        // 企業コード
            scmNewArrNtfySt.FileHeaderGuid = scmNewArrNtfyStWork.FileHeaderGuid;        // GUID
            scmNewArrNtfySt.UpdEmployeeCode = scmNewArrNtfyStWork.UpdEmployeeCode;      // 更新従業員コード
            scmNewArrNtfySt.UpdAssemblyId1 = scmNewArrNtfyStWork.UpdAssemblyId1;        // 更新アセンブリID1
            scmNewArrNtfySt.UpdAssemblyId2 = scmNewArrNtfyStWork.UpdAssemblyId2;        // 更新アセンブリID2
            scmNewArrNtfySt.LogicalDeleteCode = scmNewArrNtfyStWork.LogicalDeleteCode;  // 論理削除区分
            
            scmNewArrNtfySt.SectionCode = scmNewArrNtfyStWork.SectionCode;              // 拠点コード
            scmNewArrNtfySt.CustomerCode = scmNewArrNtfyStWork.CustomerCode;            // 得意先コード

            scmNewArrNtfySt.CashRegisterNo = scmNewArrNtfyStWork.CashRegisterNo;        // レジ番号
            
            return scmNewArrNtfySt;
        }

        /// <summary>
        /// クラスメンバコピー処理（UIデータクラス→ワーククラス）
        /// </summary>
        /// <param name="scmNewArrNtfySt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private SCMNewArrNtfyStWork CopyToSCMNewArrNtfyStWorkFromSCMNewArrNtfySt(SCMNewArrNtfySt scmNewArrNtfySt)
        {
            SCMNewArrNtfyStWork scmNewArrNtfyStWork = new SCMNewArrNtfyStWork();

            scmNewArrNtfyStWork.CreateDateTime = scmNewArrNtfySt.CreateDateTime;        // 作成日時
            scmNewArrNtfyStWork.UpdateDateTime = scmNewArrNtfySt.UpdateDateTime;        // 更新日時
            scmNewArrNtfyStWork.EnterpriseCode = scmNewArrNtfySt.EnterpriseCode;        // 企業コード
            scmNewArrNtfyStWork.FileHeaderGuid = scmNewArrNtfySt.FileHeaderGuid;        // GUID
            scmNewArrNtfyStWork.UpdEmployeeCode = scmNewArrNtfySt.UpdEmployeeCode;      // 更新従業員コード
            scmNewArrNtfyStWork.UpdAssemblyId1 = scmNewArrNtfySt.UpdAssemblyId1;        // 更新アセンブリID1
            scmNewArrNtfyStWork.UpdAssemblyId2 = scmNewArrNtfySt.UpdAssemblyId2;        // 更新アセンブリID2
            scmNewArrNtfyStWork.LogicalDeleteCode = scmNewArrNtfySt.LogicalDeleteCode;  // 論理削除区分

            scmNewArrNtfyStWork.SectionCode = scmNewArrNtfySt.SectionCode;              // 拠点コード
            scmNewArrNtfyStWork.CustomerCode = scmNewArrNtfySt.CustomerCode;            // 得意先コード

            scmNewArrNtfyStWork.CashRegisterNo = scmNewArrNtfySt.CashRegisterNo;        // レジ番号
            
            return scmNewArrNtfyStWork;
        }
        #endregion
    }
}
