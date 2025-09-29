//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM全体設定マスタ
// プログラム概要   : SCM全体設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/16  修正内容 : Searchメソッド追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/08/03  修正内容 : 項目追加(レジ番号、受信処理起動間隔)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20073 西 毅
// 作 成 日  2012/04/20  修正内容 : 項目追加(販売区分設定、販売区分コード)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/31  修正内容 : 2012/10月配信予定 SCM障害№76の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341対応
//                                : 項目追加（自動回答区分（問合せ）、自動回答区分（発注）、
//                                : 受付従業員コード、受け従業員名称、納品区分、納品区分名称）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/04  修正内容 : 2012/12/12配信 システムテスト障害№96対応
//                                : PCC全体設定マスタへの更新処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : SCM障害追加②対応
//                                : 項目追加（該当無自動回答区分）
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 配信日なし分 Redmine#34752 データ更新倉庫区分を追加
//----------------------------------------------------------------------------//
//管理番号  10801804-00  作成担当 : wangl2
//作 成 日  2013/04/11   修正内容 : No.73 見積自動回答サービス
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// SCM全体設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM全体設定のアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
	public class SCMTtlStAcs
	{
		#region -- リモートオブジェクト格納バッファ --
		/// <summary>
		/// リモートオブジェクト格納バッファ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ISCMTtlStDB _iSCMTtlStDB = null;

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        private UserGuideAcs _userGuideAcs = null;
        private Hashtable _userGdBdTb = null;
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ADD 2012/12/04 2012/12/12配信 システムテスト障害№96対応 ---------------------------------->>>>>
        /// <summary>
        /// PCC全体設定マスタ アクセスクラス
        /// </summary>
        private PccTtlStAcs _pccTtlStAcs = null;
        private PccTtlSt _pccTtlSt = null;
        private Hashtable _pccTtlStTable;

        /// <summary>
        /// 拠点マスタ アクセスクラス
        /// </summary>
        private SecInfoSetAcs _secInfoSetAcs;
        private Hashtable _sectionTb = null;
        private const string SECTION_00_MES = "全体";
        // ADD 2012/12/04 2012/12/12配信 システムテスト障害№96対応 ----------------------------------<<<<<
		
		#endregion

		#region -- コンストラクタ --
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
		static SCMTtlStAcs()
		{			
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
		public SCMTtlStAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iSCMTtlStDB = (ISCMTtlStDB)MediationscmTtlStDB.GetSCMTtlStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSCMTtlStDB = null;
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
            if (this._iSCMTtlStDB == null)
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
        /// <param name="scmTtlSt">UIデータクラス</param>
		/// <param name="enterpriseCode">企業コード</param> 
		/// <param name="sectionCode">拠点コード</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out SCMTtlSt scmTtlSt, string enterpriseCode, string sectionCode)
        {
            return ReadProc(out scmTtlSt, enterpriseCode, sectionCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmTtlSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMTtlSt scmTtlSt, string enterpriseCode, string sectionCode)
		{
            int status = 0;

            scmTtlSt = null;

			try
			{
                SCMTtlStWork scmTtlStWork = new SCMTtlStWork();
                scmTtlStWork.EnterpriseCode = enterpriseCode;
                scmTtlStWork.SectionCode = sectionCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmTtlStWork);

                status = this._iSCMTtlStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    scmTtlStWork = (SCMTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMTtlStWork));
                    // ワーク→UIデータクラス
                    scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				scmTtlSt = null;
				// オフライン時はnullをセット
				this._iSCMTtlStDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
		#endregion

		#region -- 登録･更新処理 --
		/// <summary>
		/// 登録・更新処理
		/// </summary>
        /// <param name="scmTtlSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 登録・更新処理を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref SCMTtlSt scmTtlSt)
		{
            int status = 0;

			// UIデータクラス→ワーク
            SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

            object obj = scmTtlStWork;
			
			try
			{
				// 書き込み処理
                status = this._iSCMTtlStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応-------------------------->>>>>
                    // PCC全体設定マスタ登録・更新処理
                    status = PccTtlStWrite(scmTtlSt);
                    // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応--------------------------<<<<<

                    if (obj is ArrayList)
                    {
                        scmTtlStWork = (SCMTtlStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                    }
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iSCMTtlStDB = null;
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
        /// <param name="scmTtlSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : SCM全体設定の論理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref SCMTtlSt scmTtlSt)
		{
            int status = 0;

            // UIデータクラス→ワーク
            SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

            object obj = scmTtlStWork;

            try
            {
                // 論理削除
                status = this._iSCMTtlStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応-------------------------->>>>>
                    // PCC全体設定マスタ登録・更新処理
                    status = PccTtlStLogicalDelete(scmTtlSt);
                    // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応--------------------------<<<<<

                    scmTtlStWork = (SCMTtlStWork)obj;
                    // ワーク→UIデータクラス
                    scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMTtlStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}

		/// <summary>
		/// 物理削除処理
		/// </summary>
        /// <param name="scmTtlSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM全体設定の物理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Delete(SCMTtlSt scmTtlSt)
		{
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmTtlStWork);

                // 物理削除
                status = this._iSCMTtlStDB.Delete(parabyte);

                // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応 ----------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // PCC全体設定マスタ削除処理
                    status = PccTtlStDelete(scmTtlSt);
                }
                // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応 -----------------------<<<<<
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMTtlStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}
		#endregion

        #region -- 復活処理 --
        /// <summary>
        /// SCM全体設定復活処理
        /// </summary>
        /// <param name="scmTtlSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM全体設定の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMTtlSt scmTtlSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMTtlStWork scmTtlStWork = CopyToSCMTtlStWorkFromSCMTtlSt(scmTtlSt);

                object obj = scmTtlStWork;

                // 復活処理
                status = this._iSCMTtlStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応 ----------------------->>>>>
                    // PCC全体設定マスタ復活処理
                    status = PccTtlStRevival(scmTtlSt);
                    // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応 -----------------------<<<<<

                    scmTtlStWork = (SCMTtlStWork)obj;
                    // ワーク→UIデータクラス
                    scmTtlSt = CopyToSCMTtlStFromSCMTtlStWork(scmTtlStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMTtlStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        // ADD 2009/06/16 ------>>>
        /// <summary>
        /// SCM全体設定検索処理(論理削除データは除外)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM全体設定の全検索処理を行います。論理削除データは抽出されません。</br>
        /// <br></br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // ADD 2009/06/16 ------<<<
        
        /// <summary>
        /// SCM全体設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM全体設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br></br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// SCM全体設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM全体設定の検索処理を行います。</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
            int status = 0;

            SCMTtlStWork scmTtlStWork = new SCMTtlStWork();
            scmTtlStWork.EnterpriseCode = enterpriseCode;

			retList = new ArrayList();
			
            object paraobj = scmTtlStWork;
			object retobj = null;

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // ユーザーガイド設定の納品区分の取得
            SetDelivereds(scmTtlStWork.EnterpriseCode);
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // SCM全体設定の全検索
            status = this._iSCMTtlStDB.Search(out retobj, paraobj, 0, logicalMode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMTtlStWork wkSCMTtlStWork in workList)
                {
                    retList.Add(CopyToSCMTtlStFromSCMTtlStWork(wkSCMTtlStWork));
                }
            }
                
 			return status;
		}
		#endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
		/// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
		/// </summary>
        /// <param name="scmTtlStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
		/// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private SCMTtlSt CopyToSCMTtlStFromSCMTtlStWork(SCMTtlStWork scmTtlStWork)
		{
            SCMTtlSt scmTtlSt = new SCMTtlSt();

            scmTtlSt.CreateDateTime = scmTtlStWork.CreateDateTime;
            scmTtlSt.UpdateDateTime = scmTtlStWork.UpdateDateTime;
            scmTtlSt.EnterpriseCode = scmTtlStWork.EnterpriseCode;
            scmTtlSt.FileHeaderGuid = scmTtlStWork.FileHeaderGuid;
            scmTtlSt.UpdEmployeeCode = scmTtlStWork.UpdEmployeeCode;
            scmTtlSt.UpdAssemblyId1 = scmTtlStWork.UpdAssemblyId1;
            scmTtlSt.UpdAssemblyId2 = scmTtlStWork.UpdAssemblyId2;
            scmTtlSt.LogicalDeleteCode = scmTtlStWork.LogicalDeleteCode;
            scmTtlSt.SectionCode = scmTtlStWork.SectionCode;

            scmTtlSt.SalesSlipPrtDiv = scmTtlStWork.SalesSlipPrtDiv;            // 売上伝票発行区分
            scmTtlSt.AcpOdrrSlipPrtDiv = scmTtlStWork.AcpOdrrSlipPrtDiv;        // 受注伝票発行区分
            scmTtlSt.OldSysCooperatDiv = scmTtlStWork.OldSysCooperatDiv;        // 旧システム連携区分
            scmTtlSt.OldSysCoopFolder = scmTtlStWork.OldSysCoopFolder;          // 旧システム連携フォルダ
            scmTtlSt.BLCodeChgDiv = scmTtlStWork.BLCodeChgDiv;                  // BLコード変換
            scmTtlSt.AutoCooperatDis = scmTtlStWork.AutoCooperatDis;            // 自動連携値引率
            scmTtlSt.DiscountApplyCd = scmTtlStWork.DiscountApplyCd;            // 値引適用区分
            scmTtlSt.AutoAnswerDiv = scmTtlStWork.AutoAnswerDiv;                // 自動回答区分
            scmTtlSt.EstimatePrtDiv = scmTtlStWork.EstimatePrtDiv;              // 見積書発行区分
            //>>>2010/08/03
            scmTtlSt.CashRegisterNo = scmTtlStWork.CashRegisterNo;              // レジ番号
            scmTtlSt.RcvProcStInterval = scmTtlStWork.RcvProcStInterval;        // 受信処理起動間隔
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlSt.SalesCdStAutoAns = scmTtlStWork.SalesCdStAutoAns;                // 販売区分設定(自動回答時)
            scmTtlSt.SalesCode = scmTtlStWork.SalesCode;                // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlSt.AutoAnsHourDspDiv = scmTtlStWork.AutoAnsHourDspDiv;      //自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            scmTtlSt.AutoAnsInquiryDiv = scmTtlStWork.AutoAnsInquiryDiv;        // 自動回答区分（問合せ） 
            scmTtlSt.AutoAnsOrderDiv = scmTtlStWork.AutoAnsOrderDiv;            // 自動回答区分（発注）
            scmTtlSt.FrontEmployeeCd = scmTtlStWork.FrontEmployeeCd.Trim();     // 受付従業員コード
            scmTtlSt.DeliveredGoodsDiv = scmTtlStWork.DeliveredGoodsDiv;　　　　// 納品区分
            scmTtlSt.DeliveredGoodsNm = GetDeliveredName(scmTtlStWork.DeliveredGoodsDiv); //納品区分名称
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            scmTtlSt.FuwioutAutoAnsDiv = scmTtlStWork.FuwioutAutoAnsDiv;　　　　// 該当無自動回答区分
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            scmTtlSt.DataUpDateWareHDiv = scmTtlStWork.DataUpDateWareHDiv; // データ更新倉庫区分 // ADD 2013/02/27 qijh #34752
            scmTtlSt.SalesInputCode = scmTtlStWork.SalesInputCode.Trim();　　　　//　売上入力者コード　//ADD 2013.04.11 wangl2 FOR RedMine#35269

            return scmTtlSt;
		}
		
		/// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
		/// </summary>
        /// <param name="scmTtlSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
		/// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private SCMTtlStWork CopyToSCMTtlStWorkFromSCMTtlSt(SCMTtlSt scmTtlSt)
		{
            SCMTtlStWork scmTtlStWork = new SCMTtlStWork();

            scmTtlStWork.CreateDateTime = scmTtlSt.CreateDateTime;
            scmTtlStWork.UpdateDateTime = scmTtlSt.UpdateDateTime;
            scmTtlStWork.EnterpriseCode = scmTtlSt.EnterpriseCode;
            scmTtlStWork.FileHeaderGuid = scmTtlSt.FileHeaderGuid;
            scmTtlStWork.UpdEmployeeCode = scmTtlSt.UpdEmployeeCode;
            scmTtlStWork.UpdAssemblyId1 = scmTtlSt.UpdAssemblyId1;
            scmTtlStWork.UpdAssemblyId2 = scmTtlSt.UpdAssemblyId2;
            scmTtlStWork.LogicalDeleteCode = scmTtlSt.LogicalDeleteCode;
            scmTtlStWork.SectionCode = scmTtlSt.SectionCode;

            scmTtlStWork.SalesSlipPrtDiv = scmTtlSt.SalesSlipPrtDiv;            // 売上伝票発行区分
            scmTtlStWork.AcpOdrrSlipPrtDiv = scmTtlSt.AcpOdrrSlipPrtDiv;        // 受注伝票発行区分
            scmTtlStWork.OldSysCooperatDiv = scmTtlSt.OldSysCooperatDiv;        // 旧システム連携区分
            scmTtlStWork.OldSysCoopFolder = scmTtlSt.OldSysCoopFolder;          // 旧システム連携フォルダ
            scmTtlStWork.BLCodeChgDiv = scmTtlSt.BLCodeChgDiv;                  // BLコード変換
            scmTtlStWork.AutoCooperatDis = scmTtlSt.AutoCooperatDis;            // 自動連携値引率
            scmTtlStWork.DiscountApplyCd = scmTtlSt.DiscountApplyCd;            // 値引適用区分
            scmTtlStWork.AutoAnswerDiv = scmTtlSt.AutoAnswerDiv;                // 自動回答区分
            scmTtlStWork.EstimatePrtDiv = scmTtlSt.EstimatePrtDiv;              // 見積書発行区分
            //>>>2010/08/03
            scmTtlStWork.CashRegisterNo = scmTtlSt.CashRegisterNo;              // レジ番号
            scmTtlStWork.RcvProcStInterval = scmTtlSt.RcvProcStInterval;        // 受信処理起動間隔
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlStWork.SalesCdStAutoAns = scmTtlSt.SalesCdStAutoAns;                // 販売区分設定(自動回答時)
            scmTtlStWork.SalesCode = scmTtlSt.SalesCode;                // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlStWork.AutoAnsHourDspDiv = scmTtlSt.AutoAnsHourDspDiv;      //自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            scmTtlStWork.AutoAnsInquiryDiv = scmTtlSt.AutoAnsInquiryDiv;        // 自動回答区分（問合せ） 
            scmTtlStWork.AutoAnsOrderDiv = scmTtlSt.AutoAnsOrderDiv;            // 自動回答区分（発注）
            scmTtlStWork.FrontEmployeeCd = scmTtlSt.FrontEmployeeCd.Trim();     // 受付従業員コード
            scmTtlStWork.DeliveredGoodsDiv = scmTtlSt.DeliveredGoodsDiv;　　　　// 納品区分
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            scmTtlStWork.FuwioutAutoAnsDiv = scmTtlSt.FuwioutAutoAnsDiv;　　　　// 該当無自動回答区分
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            scmTtlStWork.DataUpDateWareHDiv = scmTtlSt.DataUpDateWareHDiv; // データ更新倉庫区分 // ADD 2013/02/27 qijh #34752
            scmTtlStWork.SalesInputCode = scmTtlSt.SalesInputCode.Trim();　　　　// 売上入力者コード　　//ADD 2013.04.11 wangl2 FOR RedMine#35269

            return scmTtlStWork;
		}
		#endregion
	
	    //>>>2010/08/03
        PosTerminalMgAcs _posTerminalMgAcs;
        List<PosTerminalMg> _posTerminalMgList;

        /// <summary>
        /// 端末管理情報キャッシュ処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        public void CachePosTerminalMg(string enterpriseCode)
        {
            ArrayList al;
            List<PosTerminalMg> posList = new List<PosTerminalMg>();

            if (this._posTerminalMgAcs == null)
            {
                this._posTerminalMgAcs = new PosTerminalMgAcs();
            }

            this._posTerminalMgAcs.SearchServer(out al, enterpriseCode);
            if (al != null) posList = new List<PosTerminalMg>((PosTerminalMg[])al.ToArray(typeof(PosTerminalMg)));

            this._posTerminalMgList = posList;
        }

        /// <summary>
        /// 端末管理情報取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="cashRegisterNo"></param>
        /// <returns></returns>
        public PosTerminalMg GetPosTerminalMg(string enterpriseCode, int cashRegisterNo)
        {
            PosTerminalMg retPosTerminalMg = null;

            if ((this._posTerminalMgList != null) && (this._posTerminalMgList.Count != 0))
            {
                retPosTerminalMg = this._posTerminalMgList.Find(
                    delegate(PosTerminalMg pos)
                    {
                        if (pos.CashRegisterNo == cashRegisterNo)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }

            return retPosTerminalMg;
        }
        //<<<2010/08/03
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// <summary>
        /// ユーザーガイド設定の納品区分の取得
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> 企業コード</param>
        /// <br>Note       : ユーザーガイド設定の納品区分を取得します。</br>
        /// <br>             (PCC全体設定マスタのアクセスクラスを元にしています）</br>
        /// <br>Programmer : 湯上 千加子</br>
        /// <br>Date       : 2012.09.07</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //ユーザーガイド設定の納品区分の取得
            ArrayList userGuidList = null;
            //納品区分の項目
            int userGuideDivCd = 48;
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        if (!_userGdBdTb.ContainsKey(userGdBd.GuideCode))
                        {
                            _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 納品区分名称の取得
        /// </summary>
        /// <param name="deliveredGoodsDiv"> 納品区分</param>
        /// <remarks>
        /// <returns>納品区分名称</returns>
        /// <br>Note       : 納品区分名称を取得します。</br>
        /// <br>             (PCC全体設定マスタのアクセスクラスを元にしています）</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応-------------------------->>>>>
        /// <summary>
        /// PCC全体設定マスタ登録・更新処理
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC全体設定マスタへの登録・更新処理を行います。</br>
        /// <br>             (PCC全体設定マスタのアクセスクラスを元にしています）</br>
        /// </remarks>
        private int PccTtlStWrite(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC全体設定マスタ取得
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // PCC全体設定が論理削除済の時
                if (this._pccTtlSt != null && this._pccTtlSt.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
                {
                    // PCC全体設定マスタ復活処理
                    status = this._pccTtlStAcs.RevivalLogicalDelete(ref this._pccTtlSt);
                }

                // SCM全体設定オブジェクトからPCC全体設定オブジェクトへ更新項目を設定
                ScmTtlStToPccTtlSt(scmTtlSt, ref this._pccTtlSt);

                // PCC全体設定マスタ更新
                status = this._pccTtlStAcs.Write(ref this._pccTtlSt);

            }
            return status;
        }

        /// <summary>
        /// PCC全体設定マスタ削除処理
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC全体設定マスタへの削除処理を行います。</br>
        /// <br>             (PCC全体設定マスタのアクセスクラスを元にしています）</br>
        /// </remarks>
        private int PccTtlStDelete(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC全体設定マスタ取得
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._pccTtlSt != null)
                {
                    // PCC全体設定マスタ削除
                    status = this._pccTtlStAcs.Delete(ref this._pccTtlSt);
                }
            }
            return status;
        }

        /// <summary>
        /// PCC全体設定マスタ論理削除処理
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC全体設定マスタへの論理削除処理を行います。</br>
        /// <br>             (PCC全体設定マスタのアクセスクラスを元にしています）</br>
        /// </remarks>
        private int PccTtlStLogicalDelete(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC全体設定マスタ取得
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._pccTtlSt != null)
                {
                    // PCC全体設定マスタ論理削除
                    status = this._pccTtlStAcs.LogicalDelete(ref this._pccTtlSt);
                }
            }
            return status;
        }

        /// <summary>
        /// PCC全体設定マスタ復活処理
        /// </summary>
        /// <param name="scmTtlSt"></param>
        /// <remarks>
        /// <returns></returns>
        /// <br>Note       : PCC全体設定マスタの復活処理を行います。</br>
        /// <br>             (PCC全体設定マスタのアクセスクラスを元にしています）</br>
        /// </remarks>
        private int PccTtlStRevival(SCMTtlSt scmTtlSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // PCC全体設定マスタ取得
            status = PccTtlStRead(scmTtlSt);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this._pccTtlSt != null)
                {
                    // PCC全体設定マスタ復活処理
                    status = this._pccTtlStAcs.RevivalLogicalDelete(ref this._pccTtlSt);
                }

                // SCM全体設定オブジェクトからPCC全体設定オブジェクトへ更新項目を設定
                ScmTtlStToPccTtlSt(scmTtlSt, ref this._pccTtlSt);

                // PCC全体設定マスタ更新
                status = this._pccTtlStAcs.Write(ref this._pccTtlSt);
            }
            return status;
        }

        /// <summary>
        /// PCC全体設定マスタ読込処理
        /// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC全体設定マスタの読み込みを行い、データを格納します</br>
        /// </remarks>
        private int PccTtlStRead(SCMTtlSt scmTtlSt)
        {
            int status = 0;

            // PCC全体設定マスタアクセスクラス取得
            if (this._pccTtlStAcs == null)
            {
                this._pccTtlStAcs = new PccTtlStAcs();
            }

            this._pccTtlStTable = new Hashtable();
            // PCC全体設定マスタ全件取得
            status = PccTtlStSearch(scmTtlSt);
            // 取得できなかった時、以降の処理を中止
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 更新対象データ検索
            this._pccTtlSt = null;
            string key = scmTtlSt.EnterpriseCode.Trim() + scmTtlSt.SectionCode.Trim();
            if (this._pccTtlStTable.ContainsKey(key))
            {
                _pccTtlSt = (PccTtlSt)this._pccTtlStTable[key];
            }

            return status;
        }

        /// <summary>
        /// PCC全体設定マスタ全件検索処理
        /// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したデータテーブルに設定します。</br>
        /// </remarks>
        private int PccTtlStSearch(SCMTtlSt scmTtlSt)
        {
            int status = 0;
            PccTtlSt parsepccTtlSt = new PccTtlSt();
            List<PccTtlSt> pccTtlStList = null;
            parsepccTtlSt.EnterpriseCode = scmTtlSt.EnterpriseCode;
            int totalCount = 0;

            if (this._pccTtlStTable.Count == 0)
            {
                status = this._pccTtlStAcs.Search(ref pccTtlStList, parsepccTtlSt, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this._pccTtlStTable.Clear();

                            //全体設定クラスをデータテーブルへ展開する
                            foreach (PccTtlSt pccTtlSt in pccTtlStList)
                            {
                                if (this._pccTtlStTable.ContainsKey(pccTtlSt.EnterpriseCode.Trim() + pccTtlSt.SectionCode.Trim()) == false)
                                {
                                    this._pccTtlStTable.Add(pccTtlSt.EnterpriseCode.Trim() + pccTtlSt.SectionCode.Trim(), pccTtlSt);
                                }
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return status;
        }

        /// <summary>
        /// PCC全体設定マスタ情報格納処理
        /// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
        /// <param name="pccTtlSt">PCC全体設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : SCM全体設定オブジェクトからPCC全体設定オブジェクトにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void ScmTtlStToPccTtlSt(SCMTtlSt scmTtlSt, ref PccTtlSt pccTtlSt)
        {
            // SCM全体設定情報がない時は以降の処理は行わない
            if (scmTtlSt == null) return;
            
            if (pccTtlSt == null)
            {
                // 新規の場合
                pccTtlSt = new PccTtlSt();
                pccTtlSt.EnterpriseCode = scmTtlSt.EnterpriseCode;
            }
            //拠点コード
            pccTtlSt.SectionCode = scmTtlSt.SectionCode;
            //拠点名称
            pccTtlSt.SectionName = GetSectionName(scmTtlSt.SectionCode.Trim(), scmTtlSt.EnterpriseCode);
            //受付従業員       
            pccTtlSt.FrontEmployeeCd = scmTtlSt.FrontEmployeeCd;
            //受付従業員名称
            pccTtlSt.FrontEmployeeNm = scmTtlSt.FrontEmployeeNm;
            //納品区分
            pccTtlSt.DeliveredGoodsDiv = scmTtlSt.DeliveredGoodsDiv;
            //売上伝票発行区分
            pccTtlSt.SalesSlipPrtDiv = scmTtlSt.SalesSlipPrtDiv;
            //受注伝票印刷区分
            pccTtlSt.AcpOdrrSlipPrtDiv = scmTtlSt.AcpOdrrSlipPrtDiv;

        }

        /// <summary>
        /// 拠点名称の取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetSectionName(string sectionCode, string enterpriseCode)
        {
            string sectionName = string.Empty;
            if (_sectionTb == null)
            {
                GetALLSectionName(enterpriseCode);
            }

            if (_sectionTb != null && _sectionTb.Count > 0 && _sectionTb.ContainsKey(sectionCode))
            {
                sectionName = (string)_sectionTb[sectionCode];
            }

            return sectionName;
        }

        /// <summary>
        /// 拠点名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void GetALLSectionName(string enterpriseCode)
        {
            if (this._secInfoSetAcs == null)
            {
                this._secInfoSetAcs = new SecInfoSetAcs();
            }
            if (_sectionTb == null)
            {
                _sectionTb = new Hashtable();
            }
            else
            {
                _sectionTb.Clear();
            }

            _sectionTb.Add("00", SECTION_00_MES);
            ArrayList retList = null;
            int status = this._secInfoSetAcs.SearchAll(out retList, enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (SecInfoSet secInfoSet in retList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        _sectionTb.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideSnm.TrimEnd());
                    }
                }
            }
        }

        // ADD 2012/12/04 2012/12/12配信システムテスト障害№96対応--------------------------<<<<<

	}
}
