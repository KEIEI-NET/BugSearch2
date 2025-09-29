//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM相場価格設定マスタ
// プログラム概要   : SCM相場価格設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/12  修正内容 : 相場価格品質コード２、相場価格品質コード３の追加
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
    /// SCM相場価格設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM相場価格設定のアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
	public class SCMMrktPriStAcs
	{
		#region -- リモートオブジェクト格納バッファ --
		/// <summary>
		/// リモートオブジェクト格納バッファ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ISCMMrktPriStDB _iSCMMrktPriStDB = null;
		
		#endregion

		#region -- コンストラクタ --
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
		static SCMMrktPriStAcs()
		{			
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
		public SCMMrktPriStAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iSCMMrktPriStDB = (ISCMMrktPriStDB)MediationSCMMrktPriStDB.GetSCMMrktPriStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSCMMrktPriStDB = null;
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
            if (this._iSCMMrktPriStDB == null)
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
        /// <param name="scmMrktPriSt">UIデータクラス</param>
		/// <param name="enterpriseCode">企業コード</param> 
		/// <param name="sectionCode">拠点コード</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out SCMMrktPriSt scmMrktPriSt, string enterpriseCode, string sectionCode)
        {
            return ReadProc(out scmMrktPriSt, enterpriseCode, sectionCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmMrktPriSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMMrktPriSt scmMrktPriSt, string enterpriseCode, string sectionCode)
		{
            int status = 0;

            scmMrktPriSt = null;

			try
			{
                SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();
                scmMrktPriStWork.EnterpriseCode = enterpriseCode;
                scmMrktPriStWork.SectionCode = sectionCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmMrktPriStWork);

                status = this._iSCMMrktPriStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    scmMrktPriStWork = (SCMMrktPriStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMMrktPriStWork));
                    // ワーク→UIデータクラス
                    scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				scmMrktPriSt = null;
				// オフライン時はnullをセット
				this._iSCMMrktPriStDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
		#endregion

		#region -- 登録･更新処理 --
		/// <summary>
		/// 登録・更新処理
		/// </summary>
        /// <param name="scmMrktPriSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 登録・更新処理を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref SCMMrktPriSt scmMrktPriSt)
		{
            int status = 0;

			// UIデータクラス→ワーク
            SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

            object obj = scmMrktPriStWork;
			
			try
			{
				// 書き込み処理
                status = this._iSCMMrktPriStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        scmMrktPriStWork = (SCMMrktPriStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                    }
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iSCMMrktPriStDB = null;
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
        /// <param name="scmMrktPriSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : SCM相場価格設定の論理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref SCMMrktPriSt scmMrktPriSt)
		{
            int status = 0;

            // UIデータクラス→ワーク
            SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

            object obj = scmMrktPriStWork;

            try
            {
                // 論理削除
                status = this._iSCMMrktPriStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmMrktPriStWork = (SCMMrktPriStWork)obj;
                    // ワーク→UIデータクラス
                    scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMMrktPriStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}

		/// <summary>
		/// 物理削除処理
		/// </summary>
        /// <param name="scmMrktPriSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM相場価格設定の物理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Delete(SCMMrktPriSt scmMrktPriSt)
		{
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmMrktPriStWork);

                // 物理削除
                status = this._iSCMMrktPriStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMMrktPriStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}
		#endregion

        #region -- 復活処理 --
        /// <summary>
        /// SCM相場価格設定復活処理
        /// </summary>
        /// <param name="scmMrktPriSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM相場価格設定の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMMrktPriSt scmMrktPriSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMMrktPriStWork scmMrktPriStWork = CopyToSCMMrktPriStWorkFromSCMMrktPriSt(scmMrktPriSt);

                object obj = scmMrktPriStWork;

                // 復活処理
                status = this._iSCMMrktPriStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmMrktPriStWork = (SCMMrktPriStWork)obj;
                    // ワーク→UIデータクラス
                    scmMrktPriSt = CopyToSCMMrktPriStFromSCMMrktPriStWork(scmMrktPriStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMMrktPriStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// SCM相場価格設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM相場価格設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br></br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// SCM相場価格設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM相場価格設定の検索処理を行います。</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
		{
            int status = 0;

            SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();
            scmMrktPriStWork.EnterpriseCode = enterpriseCode;

			retList = new ArrayList();
			
            object paraobj = scmMrktPriStWork;
			object retobj = null;

            // SCM相場価格設定の全検索
            status = this._iSCMMrktPriStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMMrktPriStWork wkSCMMrktPriStWork in workList)
                {
                    retList.Add(CopyToSCMMrktPriStFromSCMMrktPriStWork(wkSCMMrktPriStWork));
                }
            }
                
 			return status;
		}
		#endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
		/// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
		/// </summary>
        /// <param name="scmMrktPriStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
		/// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private SCMMrktPriSt CopyToSCMMrktPriStFromSCMMrktPriStWork(SCMMrktPriStWork scmMrktPriStWork)
		{
            SCMMrktPriSt scmMrktPriSt = new SCMMrktPriSt();

            scmMrktPriSt.CreateDateTime = scmMrktPriStWork.CreateDateTime;
            scmMrktPriSt.UpdateDateTime = scmMrktPriStWork.UpdateDateTime;
            scmMrktPriSt.EnterpriseCode = scmMrktPriStWork.EnterpriseCode;
            scmMrktPriSt.FileHeaderGuid = scmMrktPriStWork.FileHeaderGuid;
            scmMrktPriSt.UpdEmployeeCode = scmMrktPriStWork.UpdEmployeeCode;
            scmMrktPriSt.UpdAssemblyId1 = scmMrktPriStWork.UpdAssemblyId1;
            scmMrktPriSt.UpdAssemblyId2 = scmMrktPriStWork.UpdAssemblyId2;
            scmMrktPriSt.LogicalDeleteCode = scmMrktPriStWork.LogicalDeleteCode;
            scmMrktPriSt.SectionCode = scmMrktPriStWork.SectionCode;

            scmMrktPriSt.MarketPriceAreaCd = scmMrktPriStWork.MarketPriceAreaCd;            // 相場価格地域コード
            scmMrktPriSt.MarketPriceQualityCd = scmMrktPriStWork.MarketPriceQualityCd;      // 相場価格品質コード
            scmMrktPriSt.MarketPriceKindCd1 = scmMrktPriStWork.MarketPriceKindCd1;          // 相場価格種別コード１
            scmMrktPriSt.MarketPriceKindCd2 = scmMrktPriStWork.MarketPriceKindCd2;          // 相場価格種別コード２
            scmMrktPriSt.MarketPriceKindCd3 = scmMrktPriStWork.MarketPriceKindCd3;          // 相場価格種別コード３
            scmMrktPriSt.MarketPriceAnswerDiv = scmMrktPriStWork.MarketPriceAnswerDiv;      // 相場価格回答区分
            scmMrktPriSt.MarketPriceSalesRate = scmMrktPriStWork.MarketPriceSalesRate;      // 相場価格売価率

            scmMrktPriSt.AddPaymntAmbit1 = scmMrktPriStWork.AddPaymntAmbit1;                // 加算額範囲１
            scmMrktPriSt.AddPaymntAmbit2 = scmMrktPriStWork.AddPaymntAmbit2;                // 加算額範囲２
            scmMrktPriSt.AddPaymntAmbit3 = scmMrktPriStWork.AddPaymntAmbit3;                // 加算額範囲３
            scmMrktPriSt.AddPaymntAmbit4 = scmMrktPriStWork.AddPaymntAmbit4;                // 加算額範囲４
            scmMrktPriSt.AddPaymntAmbit5 = scmMrktPriStWork.AddPaymntAmbit5;                // 加算額範囲５
            scmMrktPriSt.AddPaymntAmbit6 = scmMrktPriStWork.AddPaymntAmbit6;                // 加算額範囲６
            scmMrktPriSt.AddPaymntAmbit7 = scmMrktPriStWork.AddPaymntAmbit7;                // 加算額範囲７
            scmMrktPriSt.AddPaymntAmbit8 = scmMrktPriStWork.AddPaymntAmbit8;                // 加算額範囲８
            scmMrktPriSt.AddPaymntAmbit9 = scmMrktPriStWork.AddPaymntAmbit9;                // 加算額範囲９
            scmMrktPriSt.AddPaymntAmbit10 = scmMrktPriStWork.AddPaymntAmbit10;              // 加算額範囲１０

            scmMrktPriSt.AddPaymnt1 = scmMrktPriStWork.AddPaymnt1;                          // 加算額１
            scmMrktPriSt.AddPaymnt2 = scmMrktPriStWork.AddPaymnt2;                          // 加算額２
            scmMrktPriSt.AddPaymnt3 = scmMrktPriStWork.AddPaymnt3;                          // 加算額３
            scmMrktPriSt.AddPaymnt4 = scmMrktPriStWork.AddPaymnt4;                          // 加算額４
            scmMrktPriSt.AddPaymnt5 = scmMrktPriStWork.AddPaymnt5;                          // 加算額５
            scmMrktPriSt.AddPaymnt6 = scmMrktPriStWork.AddPaymnt6;                          // 加算額６
            scmMrktPriSt.AddPaymnt7 = scmMrktPriStWork.AddPaymnt7;                          // 加算額７
            scmMrktPriSt.AddPaymnt8 = scmMrktPriStWork.AddPaymnt8;                          // 加算額８
            scmMrktPriSt.AddPaymnt9 = scmMrktPriStWork.AddPaymnt9;                          // 加算額９
            scmMrktPriSt.AddPaymnt10 = scmMrktPriStWork.AddPaymnt10;                        // 加算額１０

            scmMrktPriSt.FractionProcCd = scmMrktPriStWork.FractionProcCd;                  // 端数処理区分

            // 2010/04/12 Add >>>
            scmMrktPriSt.MarketPriceQualityCd2 = scmMrktPriStWork.MarketPriceQualityCd2;    // 相場価格品質コード２
            scmMrktPriSt.MarketPriceQualityCd3 = scmMrktPriStWork.MarketPriceQualityCd3;    // 相場価格品質コード３
            // 2010/04/12 Add <<<

            return scmMrktPriSt;
		}
		
		/// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
		/// </summary>
        /// <param name="scmMrktPriSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
		/// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private SCMMrktPriStWork CopyToSCMMrktPriStWorkFromSCMMrktPriSt(SCMMrktPriSt scmMrktPriSt)
		{
            SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();

            scmMrktPriStWork.CreateDateTime = scmMrktPriSt.CreateDateTime;
            scmMrktPriStWork.UpdateDateTime = scmMrktPriSt.UpdateDateTime;
            scmMrktPriStWork.EnterpriseCode = scmMrktPriSt.EnterpriseCode;
            scmMrktPriStWork.FileHeaderGuid = scmMrktPriSt.FileHeaderGuid;
            scmMrktPriStWork.UpdEmployeeCode = scmMrktPriSt.UpdEmployeeCode;
            scmMrktPriStWork.UpdAssemblyId1 = scmMrktPriSt.UpdAssemblyId1;
            scmMrktPriStWork.UpdAssemblyId2 = scmMrktPriSt.UpdAssemblyId2;
            scmMrktPriStWork.LogicalDeleteCode = scmMrktPriSt.LogicalDeleteCode;
            scmMrktPriStWork.SectionCode = scmMrktPriSt.SectionCode;

            scmMrktPriStWork.MarketPriceAreaCd = scmMrktPriSt.MarketPriceAreaCd;            // 相場価格地域コード
            scmMrktPriStWork.MarketPriceQualityCd = scmMrktPriSt.MarketPriceQualityCd;      // 相場価格品質コード
            scmMrktPriStWork.MarketPriceKindCd1 = scmMrktPriSt.MarketPriceKindCd1;          // 相場価格種別コード１
            scmMrktPriStWork.MarketPriceKindCd2 = scmMrktPriSt.MarketPriceKindCd2;          // 相場価格種別コード２
            scmMrktPriStWork.MarketPriceKindCd3 = scmMrktPriSt.MarketPriceKindCd3;          // 相場価格種別コード３
            scmMrktPriStWork.MarketPriceAnswerDiv = scmMrktPriSt.MarketPriceAnswerDiv;      // 相場価格回答区分
            scmMrktPriStWork.MarketPriceSalesRate = scmMrktPriSt.MarketPriceSalesRate;      // 相場価格売価率

            scmMrktPriStWork.AddPaymntAmbit1 = scmMrktPriSt.AddPaymntAmbit1;                // 加算額範囲１
            scmMrktPriStWork.AddPaymntAmbit2 = scmMrktPriSt.AddPaymntAmbit2;                // 加算額範囲２
            scmMrktPriStWork.AddPaymntAmbit3 = scmMrktPriSt.AddPaymntAmbit3;                // 加算額範囲３
            scmMrktPriStWork.AddPaymntAmbit4 = scmMrktPriSt.AddPaymntAmbit4;                // 加算額範囲４
            scmMrktPriStWork.AddPaymntAmbit5 = scmMrktPriSt.AddPaymntAmbit5;                // 加算額範囲５
            scmMrktPriStWork.AddPaymntAmbit6 = scmMrktPriSt.AddPaymntAmbit6;                // 加算額範囲６
            scmMrktPriStWork.AddPaymntAmbit7 = scmMrktPriSt.AddPaymntAmbit7;                // 加算額範囲７
            scmMrktPriStWork.AddPaymntAmbit8 = scmMrktPriSt.AddPaymntAmbit8;                // 加算額範囲８
            scmMrktPriStWork.AddPaymntAmbit9 = scmMrktPriSt.AddPaymntAmbit9;                // 加算額範囲９
            scmMrktPriStWork.AddPaymntAmbit10 = scmMrktPriSt.AddPaymntAmbit10;              // 加算額範囲１０

            scmMrktPriStWork.AddPaymnt1 = scmMrktPriSt.AddPaymnt1;                          // 加算額１
            scmMrktPriStWork.AddPaymnt2 = scmMrktPriSt.AddPaymnt2;                          // 加算額２
            scmMrktPriStWork.AddPaymnt3 = scmMrktPriSt.AddPaymnt3;                          // 加算額３
            scmMrktPriStWork.AddPaymnt4 = scmMrktPriSt.AddPaymnt4;                          // 加算額４
            scmMrktPriStWork.AddPaymnt5 = scmMrktPriSt.AddPaymnt5;                          // 加算額５
            scmMrktPriStWork.AddPaymnt6 = scmMrktPriSt.AddPaymnt6;                          // 加算額６
            scmMrktPriStWork.AddPaymnt7 = scmMrktPriSt.AddPaymnt7;                          // 加算額７
            scmMrktPriStWork.AddPaymnt8 = scmMrktPriSt.AddPaymnt8;                          // 加算額８
            scmMrktPriStWork.AddPaymnt9 = scmMrktPriSt.AddPaymnt9;                          // 加算額９
            scmMrktPriStWork.AddPaymnt10 = scmMrktPriSt.AddPaymnt10;                        // 加算額１０

            scmMrktPriStWork.FractionProcCd = scmMrktPriSt.FractionProcCd;                  // 端数処理区分

            // 2010/04/12 Add >>>
            scmMrktPriStWork.MarketPriceQualityCd2 = scmMrktPriSt.MarketPriceQualityCd2;    // 相場価格品質コード２
            scmMrktPriStWork.MarketPriceQualityCd3 = scmMrktPriSt.MarketPriceQualityCd3;    // 相場価格品質コード３
            // 2010/04/12 Add <<<

            return scmMrktPriStWork;
		}
		#endregion
		
	}
}
