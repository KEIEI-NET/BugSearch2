//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM納期設定マスタ
// プログラム概要   : SCM納期設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/01  修正内容 : 新規作成
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
    /// SCM納期設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM納期設定テーブルのアクセス制御を行います。</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/01/06 30517 夏野 駿希</br>
    /// <br>           : SCM検証結果対応No.7　納期設定を取寄品・在庫品で別に設定出来る様に修正</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/10/11  呉軍</br>
    /// <br>Note       : Redmine #25765</br>
    /// <br>           : 優先在庫回答納期区分、優先在庫回答納期の追加</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2012/08/30 高川 悟</br>
    /// <br>           : SCM障害対応No.10345　回答納期の設定方法を変更</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/10 吉岡</br>
    /// <br>           : SCM高速化 回答納期区分対応</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// </remarks>
    public class SCMDeliDateStAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private ISCMDeliDateStDB _iSCMDeliDateStDB = null;

        #endregion

        #region -- コンストラクタ --
        /// <summary>
        /// SCM納期設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : SCM納期設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public SCMDeliDateStAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iSCMDeliDateStDB = (ISCMDeliDateStDB)MediationSCMDeliDateStDB.GetSCMDeliDateStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSCMDeliDateStDB = null;
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
            if (this._iSCMDeliDateStDB == null)
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
        /// <param name="scmDeliDateSt">UIデータクラス</param>
		/// <param name="enterpriseCode">企業コード</param> 
		/// <param name="sectionCode">拠点コード</param>  
		/// <param name="customerCode">得意先コード</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out SCMDeliDateSt scmDeliDateSt, string enterpriseCode, string sectionCode, int customerCode)
        {
            return ReadProc(out scmDeliDateSt, enterpriseCode, sectionCode, customerCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmDeliDateSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>  
		/// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMDeliDateSt scmDeliDateSt, string enterpriseCode, string sectionCode, int customerCode)
		{
            int status = 0;

            scmDeliDateSt = null;

			try
			{
                SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();
                scmDeliDateStWork.EnterpriseCode = enterpriseCode;
                scmDeliDateStWork.SectionCode = sectionCode;
                scmDeliDateStWork.CustomerCode = customerCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmDeliDateStWork);

                status = this._iSCMDeliDateStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    scmDeliDateStWork = (SCMDeliDateStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMDeliDateStWork));
                    // ワーク→UIデータクラス
                    scmDeliDateSt = CopyToSCMDeliDateStFromSCMDeliDateStWork(scmDeliDateStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				scmDeliDateSt = null;
				// オフライン時はnullをセット
                this._iSCMDeliDateStDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
        #endregion

        #region -- 登録･更新処理 --
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="scmDeliDateSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の登録・更新を行います</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref SCMDeliDateSt scmDeliDateSt)
        {
            int status = 0;

			// UIデータクラス→ワーク
            SCMDeliDateStWork scmDeliDateStWork = CopyToSCMDeliDateStWorkFromSCMDeliDateSt(scmDeliDateSt);

            object obj = scmDeliDateStWork;
			
			try
			{
				// 書き込み処理
                status = this._iSCMDeliDateStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        scmDeliDateStWork = (SCMDeliDateStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        scmDeliDateSt = CopyToSCMDeliDateStFromSCMDeliDateStWork(scmDeliDateStWork);
                    }
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
                this._iSCMDeliDateStDB = null;
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
        /// <param name="scmDeliDateSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref SCMDeliDateSt scmDeliDateSt)
        {
            int status = 0;

            // UIデータクラス→ワーク
            SCMDeliDateStWork scmDeliDateStWork = CopyToSCMDeliDateStWorkFromSCMDeliDateSt(scmDeliDateSt);

            object obj = scmDeliDateStWork;

            try
            {
                // 論理削除
                status = this._iSCMDeliDateStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmDeliDateStWork = (SCMDeliDateStWork)obj;
                    // ワーク→UIデータクラス
                    scmDeliDateSt = CopyToSCMDeliDateStFromSCMDeliDateStWork(scmDeliDateStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMDeliDateStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="scmDeliDateSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の物理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Delete(SCMDeliDateSt scmDeliDateSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMDeliDateStWork scmDeliDateStWork = CopyToSCMDeliDateStWorkFromSCMDeliDateSt(scmDeliDateSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmDeliDateStWork);

                // 物理削除
                status = this._iSCMDeliDateStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMDeliDateStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 復活処理 --
        /// <summary>
        /// 論理削除復活処理
        /// </summary>
        /// <param name="scmDeliDateSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の論理削除復活を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMDeliDateSt scmDeliDateSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMDeliDateStWork scmDeliDateStWork = CopyToSCMDeliDateStWorkFromSCMDeliDateSt(scmDeliDateSt);

                object obj = scmDeliDateStWork;

                // 復活処理
                status = this._iSCMDeliDateStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmDeliDateStWork = (SCMDeliDateStWork)obj;
                    // ワーク→UIデータクラス
                    scmDeliDateSt = CopyToSCMDeliDateStFromSCMDeliDateStWork(scmDeliDateStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMDeliDateStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// SCM納期設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br></br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        /// SCM納期設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// SCM納期設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM納期設定の検索処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();
            scmDeliDateStWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = scmDeliDateStWork;
            object retobj = null;

            // SCM全体設定の全検索
            status = this._iSCMDeliDateStDB.Search(out retobj, paraobj, 0, logicalMode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMDeliDateStWork wkSCMDeliDateStWork in workList)
                {
                    retList.Add(CopyToSCMDeliDateStFromSCMDeliDateStWork(wkSCMDeliDateStWork));
                }
            }

            return status;
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
        /// </summary>
        /// <param name="scmDeliDateStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
        /// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private SCMDeliDateSt CopyToSCMDeliDateStFromSCMDeliDateStWork(SCMDeliDateStWork scmDeliDateStWork)
        {
            SCMDeliDateSt scmDeliDateSt = new SCMDeliDateSt();

            scmDeliDateSt.CreateDateTime = scmDeliDateStWork.CreateDateTime;        // 作成日時
            scmDeliDateSt.UpdateDateTime = scmDeliDateStWork.UpdateDateTime;        // 更新日時
            scmDeliDateSt.EnterpriseCode = scmDeliDateStWork.EnterpriseCode;        // 企業コード
            scmDeliDateSt.FileHeaderGuid = scmDeliDateStWork.FileHeaderGuid;        // GUID
            scmDeliDateSt.UpdEmployeeCode = scmDeliDateStWork.UpdEmployeeCode;      // 更新従業員コード
            scmDeliDateSt.UpdAssemblyId1 = scmDeliDateStWork.UpdAssemblyId1;        // 更新アセンブリID1
            scmDeliDateSt.UpdAssemblyId2 = scmDeliDateStWork.UpdAssemblyId2;        // 更新アセンブリID2
            scmDeliDateSt.LogicalDeleteCode = scmDeliDateStWork.LogicalDeleteCode;  // 論理削除区分
            
            scmDeliDateSt.SectionCode = scmDeliDateStWork.SectionCode;              // 拠点コード
            scmDeliDateSt.CustomerCode = scmDeliDateStWork.CustomerCode;            // 得意先コード

            scmDeliDateSt.AnswerDeadTime1 = scmDeliDateStWork.AnswerDeadTime1;      // 回答締切時刻１
            scmDeliDateSt.AnswerDeadTime2 = scmDeliDateStWork.AnswerDeadTime2;      // 回答締切時刻２
            scmDeliDateSt.AnswerDeadTime3 = scmDeliDateStWork.AnswerDeadTime3;      // 回答締切時刻３
            scmDeliDateSt.AnswerDeadTime4 = scmDeliDateStWork.AnswerDeadTime4;      // 回答締切時刻４
            scmDeliDateSt.AnswerDeadTime5 = scmDeliDateStWork.AnswerDeadTime5;      // 回答締切時刻５
            scmDeliDateSt.AnswerDeadTime6 = scmDeliDateStWork.AnswerDeadTime6;      // 回答締切時刻６

            scmDeliDateSt.AnswerDelivDate1 = scmDeliDateStWork.AnswerDelivDate1;    // 回答納期１
            scmDeliDateSt.AnswerDelivDate2 = scmDeliDateStWork.AnswerDelivDate2;    // 回答納期２
            scmDeliDateSt.AnswerDelivDate3 = scmDeliDateStWork.AnswerDelivDate3;    // 回答納期３
            scmDeliDateSt.AnswerDelivDate4 = scmDeliDateStWork.AnswerDelivDate4;    // 回答納期４
            scmDeliDateSt.AnswerDelivDate5 = scmDeliDateStWork.AnswerDelivDate5;    // 回答納期５
            scmDeliDateSt.AnswerDelivDate6 = scmDeliDateStWork.AnswerDelivDate6;    // 回答納期６

            // 2011/01/06 Add >>>
            scmDeliDateSt.AnswerDeadTime1Stc = scmDeliDateStWork.AnswerDeadTime1Stc;      // 回答締切時刻１（在庫）
            scmDeliDateSt.AnswerDeadTime2Stc = scmDeliDateStWork.AnswerDeadTime2Stc;      // 回答締切時刻２（在庫）
            scmDeliDateSt.AnswerDeadTime3Stc = scmDeliDateStWork.AnswerDeadTime3Stc;      // 回答締切時刻３（在庫）
            scmDeliDateSt.AnswerDeadTime4Stc = scmDeliDateStWork.AnswerDeadTime4Stc;      // 回答締切時刻４（在庫）
            scmDeliDateSt.AnswerDeadTime5Stc = scmDeliDateStWork.AnswerDeadTime5Stc;      // 回答締切時刻５（在庫）
            scmDeliDateSt.AnswerDeadTime6Stc = scmDeliDateStWork.AnswerDeadTime6Stc;      // 回答締切時刻６（在庫）

            scmDeliDateSt.AnswerDelivDate1Stc = scmDeliDateStWork.AnswerDelivDate1Stc;    // 回答納期１（在庫）
            scmDeliDateSt.AnswerDelivDate2Stc = scmDeliDateStWork.AnswerDelivDate2Stc;    // 回答納期２（在庫）
            scmDeliDateSt.AnswerDelivDate3Stc = scmDeliDateStWork.AnswerDelivDate3Stc;    // 回答納期３（在庫）
            scmDeliDateSt.AnswerDelivDate4Stc = scmDeliDateStWork.AnswerDelivDate4Stc;    // 回答納期４（在庫）
            scmDeliDateSt.AnswerDelivDate5Stc = scmDeliDateStWork.AnswerDelivDate5Stc;    // 回答納期５（在庫）
            scmDeliDateSt.AnswerDelivDate6Stc = scmDeliDateStWork.AnswerDelivDate6Stc;    // 回答納期６（在庫）

            scmDeliDateSt.EntStckAnsDeliDtDiv = scmDeliDateStWork.EntStckAnsDeliDtDiv;    // 委託在庫回答納期区分
            scmDeliDateSt.EntStckAnsDeliDate = scmDeliDateStWork.EntStckAnsDeliDate;    // 委託在庫回答納期
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            scmDeliDateSt.PriStckAnsDeliDtDiv = scmDeliDateStWork.PriStckAnsDeliDtDiv;    // 優先在庫回答納期区分
            scmDeliDateSt.PriStckAnsDeliDate = scmDeliDateStWork.PriStckAnsDeliDate;    // 優先在庫回答納期
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            scmDeliDateSt.AnsDelDatShortOfStc = scmDeliDateStWork.AnsDelDatShortOfStc;      // 回答納期（在庫不足）
            scmDeliDateSt.AnsDelDatWithoutStc = scmDeliDateStWork.AnsDelDatWithoutStc;      // 回答納期（在庫数無し）
            scmDeliDateSt.EntStcAnsDelDatShort = scmDeliDateStWork.EntStcAnsDelDatShort;    // 委託在庫回答納期（在庫不足）
            scmDeliDateSt.EntStcAnsDelDatWiout = scmDeliDateStWork.EntStcAnsDelDatWiout;    // 委託在庫回答納期（在庫数無し）
            scmDeliDateSt.PriStcAnsDelDatShort = scmDeliDateStWork.PriStcAnsDelDatShort;    // 参照在庫回答納期（在庫不足）
            scmDeliDateSt.PriStcAnsDelDatWiout = scmDeliDateStWork.PriStcAnsDelDatWiout;    // 参照在庫回答納期（在庫数無し）
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            scmDeliDateSt.AnsDelDtDiv1 = scmDeliDateStWork.AnsDelDtDiv1;
            scmDeliDateSt.AnsDelDtDiv2 = scmDeliDateStWork.AnsDelDtDiv2;
            scmDeliDateSt.AnsDelDtDiv3 = scmDeliDateStWork.AnsDelDtDiv3;
            scmDeliDateSt.AnsDelDtDiv4 = scmDeliDateStWork.AnsDelDtDiv4;
            scmDeliDateSt.AnsDelDtDiv5 = scmDeliDateStWork.AnsDelDtDiv5;
            scmDeliDateSt.AnsDelDtDiv6 = scmDeliDateStWork.AnsDelDtDiv6;
            scmDeliDateSt.AnsDelDtDiv1Stc = scmDeliDateStWork.AnsDelDtDiv1Stc;
            scmDeliDateSt.AnsDelDtDiv2Stc = scmDeliDateStWork.AnsDelDtDiv2Stc;
            scmDeliDateSt.AnsDelDtDiv3Stc = scmDeliDateStWork.AnsDelDtDiv3Stc;
            scmDeliDateSt.AnsDelDtDiv4Stc = scmDeliDateStWork.AnsDelDtDiv4Stc;
            scmDeliDateSt.AnsDelDtDiv5Stc = scmDeliDateStWork.AnsDelDtDiv5Stc;
            scmDeliDateSt.AnsDelDtDiv6Stc = scmDeliDateStWork.AnsDelDtDiv6Stc;
            scmDeliDateSt.EntAnsDelDtStcDiv = scmDeliDateStWork.EntAnsDelDtStcDiv;
            scmDeliDateSt.PriAnsDelDtStcDiv = scmDeliDateStWork.PriAnsDelDtStcDiv;
            scmDeliDateSt.AnsDelDtShoStcDiv = scmDeliDateStWork.AnsDelDtShoStcDiv;
            scmDeliDateSt.AnsDelDtWioStcDiv = scmDeliDateStWork.AnsDelDtWioStcDiv;
            scmDeliDateSt.EntAnsDelDtShoDiv = scmDeliDateStWork.EntAnsDelDtShoDiv;
            scmDeliDateSt.EntAnsDelDtWioDiv = scmDeliDateStWork.EntAnsDelDtWioDiv;
            scmDeliDateSt.PriAnsDelDtShoDiv = scmDeliDateStWork.PriAnsDelDtShoDiv;
            scmDeliDateSt.PriAnsDelDtWioDiv = scmDeliDateStWork.PriAnsDelDtWioDiv;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return scmDeliDateSt;
        }

        /// <summary>
        /// クラスメンバコピー処理（UIデータクラス→ワーククラス）
        /// </summary>
        /// <param name="scmDeliDateSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private SCMDeliDateStWork CopyToSCMDeliDateStWorkFromSCMDeliDateSt(SCMDeliDateSt scmDeliDateSt)
        {
            SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();

            scmDeliDateStWork.CreateDateTime = scmDeliDateSt.CreateDateTime;        // 作成日時
            scmDeliDateStWork.UpdateDateTime = scmDeliDateSt.UpdateDateTime;        // 更新日時
            scmDeliDateStWork.EnterpriseCode = scmDeliDateSt.EnterpriseCode;        // 企業コード
            scmDeliDateStWork.FileHeaderGuid = scmDeliDateSt.FileHeaderGuid;        // GUID
            scmDeliDateStWork.UpdEmployeeCode = scmDeliDateSt.UpdEmployeeCode;      // 更新従業員コード
            scmDeliDateStWork.UpdAssemblyId1 = scmDeliDateSt.UpdAssemblyId1;        // 更新アセンブリID1
            scmDeliDateStWork.UpdAssemblyId2 = scmDeliDateSt.UpdAssemblyId2;        // 更新アセンブリID2
            scmDeliDateStWork.LogicalDeleteCode = scmDeliDateSt.LogicalDeleteCode;  // 論理削除区分

            scmDeliDateStWork.SectionCode = scmDeliDateSt.SectionCode;              // 拠点コード
            scmDeliDateStWork.CustomerCode = scmDeliDateSt.CustomerCode;            // 得意先コード

            scmDeliDateStWork.AnswerDeadTime1 = scmDeliDateSt.AnswerDeadTime1;      // 回答締切時刻１
            scmDeliDateStWork.AnswerDeadTime2 = scmDeliDateSt.AnswerDeadTime2;      // 回答締切時刻２
            scmDeliDateStWork.AnswerDeadTime3 = scmDeliDateSt.AnswerDeadTime3;      // 回答締切時刻３
            scmDeliDateStWork.AnswerDeadTime4 = scmDeliDateSt.AnswerDeadTime4;      // 回答締切時刻４
            scmDeliDateStWork.AnswerDeadTime5 = scmDeliDateSt.AnswerDeadTime5;      // 回答締切時刻５
            scmDeliDateStWork.AnswerDeadTime6 = scmDeliDateSt.AnswerDeadTime6;      // 回答締切時刻６

            scmDeliDateStWork.AnswerDelivDate1 = scmDeliDateSt.AnswerDelivDate1;    // 回答納期１
            scmDeliDateStWork.AnswerDelivDate2 = scmDeliDateSt.AnswerDelivDate2;    // 回答納期２
            scmDeliDateStWork.AnswerDelivDate3 = scmDeliDateSt.AnswerDelivDate3;    // 回答納期３
            scmDeliDateStWork.AnswerDelivDate4 = scmDeliDateSt.AnswerDelivDate4;    // 回答納期４
            scmDeliDateStWork.AnswerDelivDate5 = scmDeliDateSt.AnswerDelivDate5;    // 回答納期５
            scmDeliDateStWork.AnswerDelivDate6 = scmDeliDateSt.AnswerDelivDate6;    // 回答納期６

            // 2011/01/06 Add >>>
            scmDeliDateStWork.AnswerDeadTime1Stc = scmDeliDateSt.AnswerDeadTime1Stc;      // 回答締切時刻１（在庫）
            scmDeliDateStWork.AnswerDeadTime2Stc = scmDeliDateSt.AnswerDeadTime2Stc;      // 回答締切時刻２（在庫）
            scmDeliDateStWork.AnswerDeadTime3Stc = scmDeliDateSt.AnswerDeadTime3Stc;      // 回答締切時刻３（在庫）
            scmDeliDateStWork.AnswerDeadTime4Stc = scmDeliDateSt.AnswerDeadTime4Stc;      // 回答締切時刻４（在庫）
            scmDeliDateStWork.AnswerDeadTime5Stc = scmDeliDateSt.AnswerDeadTime5Stc;      // 回答締切時刻５（在庫）
            scmDeliDateStWork.AnswerDeadTime6Stc = scmDeliDateSt.AnswerDeadTime6Stc;      // 回答締切時刻６（在庫）

            scmDeliDateStWork.AnswerDelivDate1Stc = scmDeliDateSt.AnswerDelivDate1Stc;    // 回答納期１（在庫）
            scmDeliDateStWork.AnswerDelivDate2Stc = scmDeliDateSt.AnswerDelivDate2Stc;    // 回答納期２（在庫）
            scmDeliDateStWork.AnswerDelivDate3Stc = scmDeliDateSt.AnswerDelivDate3Stc;    // 回答納期３（在庫）
            scmDeliDateStWork.AnswerDelivDate4Stc = scmDeliDateSt.AnswerDelivDate4Stc;    // 回答納期４（在庫）
            scmDeliDateStWork.AnswerDelivDate5Stc = scmDeliDateSt.AnswerDelivDate5Stc;    // 回答納期５（在庫）
            scmDeliDateStWork.AnswerDelivDate6Stc = scmDeliDateSt.AnswerDelivDate6Stc;    // 回答納期６（在庫）

            scmDeliDateStWork.EntStckAnsDeliDtDiv = scmDeliDateSt.EntStckAnsDeliDtDiv;    // 委託在庫回答納期区分
            scmDeliDateStWork.EntStckAnsDeliDate = scmDeliDateSt.EntStckAnsDeliDate;    // 委託在庫回答納期
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            scmDeliDateStWork.PriStckAnsDeliDtDiv = scmDeliDateSt.PriStckAnsDeliDtDiv;    // 優先在庫回答納期区分
            scmDeliDateStWork.PriStckAnsDeliDate = scmDeliDateSt.PriStckAnsDeliDate;    // 優先在庫回答納期
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            scmDeliDateStWork.AnsDelDatShortOfStc = scmDeliDateSt.AnsDelDatShortOfStc;      // 回答納期（在庫不足）
            scmDeliDateStWork.AnsDelDatWithoutStc = scmDeliDateSt.AnsDelDatWithoutStc;      // 回答納期（在庫数無し）
            scmDeliDateStWork.EntStcAnsDelDatShort = scmDeliDateSt.EntStcAnsDelDatShort;    // 委託在庫回答納期（在庫不足）
            scmDeliDateStWork.EntStcAnsDelDatWiout = scmDeliDateSt.EntStcAnsDelDatWiout;    // 委託在庫回答納期（在庫数無し）
            scmDeliDateStWork.PriStcAnsDelDatShort = scmDeliDateSt.PriStcAnsDelDatShort;    // 参照在庫回答納期（在庫不足）
            scmDeliDateStWork.PriStcAnsDelDatWiout = scmDeliDateSt.PriStcAnsDelDatWiout;    // 参照在庫回答納期（在庫数無し）
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            scmDeliDateStWork.AnsDelDtDiv1 = scmDeliDateSt.AnsDelDtDiv1;
            scmDeliDateStWork.AnsDelDtDiv2 = scmDeliDateSt.AnsDelDtDiv2;
            scmDeliDateStWork.AnsDelDtDiv3 = scmDeliDateSt.AnsDelDtDiv3;
            scmDeliDateStWork.AnsDelDtDiv4 = scmDeliDateSt.AnsDelDtDiv4;
            scmDeliDateStWork.AnsDelDtDiv5 = scmDeliDateSt.AnsDelDtDiv5;
            scmDeliDateStWork.AnsDelDtDiv6 = scmDeliDateSt.AnsDelDtDiv6;
            scmDeliDateStWork.AnsDelDtDiv1Stc = scmDeliDateSt.AnsDelDtDiv1Stc;
            scmDeliDateStWork.AnsDelDtDiv2Stc = scmDeliDateSt.AnsDelDtDiv2Stc;
            scmDeliDateStWork.AnsDelDtDiv3Stc = scmDeliDateSt.AnsDelDtDiv3Stc;
            scmDeliDateStWork.AnsDelDtDiv4Stc = scmDeliDateSt.AnsDelDtDiv4Stc;
            scmDeliDateStWork.AnsDelDtDiv5Stc = scmDeliDateSt.AnsDelDtDiv5Stc;
            scmDeliDateStWork.AnsDelDtDiv6Stc = scmDeliDateSt.AnsDelDtDiv6Stc;
            scmDeliDateStWork.EntAnsDelDtStcDiv = scmDeliDateSt.EntAnsDelDtStcDiv;
            scmDeliDateStWork.PriAnsDelDtStcDiv = scmDeliDateSt.PriAnsDelDtStcDiv;
            scmDeliDateStWork.AnsDelDtShoStcDiv = scmDeliDateSt.AnsDelDtShoStcDiv;
            scmDeliDateStWork.AnsDelDtWioStcDiv = scmDeliDateSt.AnsDelDtWioStcDiv;
            scmDeliDateStWork.EntAnsDelDtShoDiv = scmDeliDateSt.EntAnsDelDtShoDiv;
            scmDeliDateStWork.EntAnsDelDtWioDiv = scmDeliDateSt.EntAnsDelDtWioDiv;
            scmDeliDateStWork.PriAnsDelDtShoDiv = scmDeliDateSt.PriAnsDelDtShoDiv;
            scmDeliDateStWork.PriAnsDelDtWioDiv = scmDeliDateSt.PriAnsDelDtWioDiv;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return scmDeliDateStWork;
        }
        #endregion
    }
}
