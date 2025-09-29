//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン設定設定マスタ
// プログラム概要   : キャンペーン設定設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/14  修正内容 : 新規作成
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
using Broadleaf.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// キャンペーン設定設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : キャンペーン設定設定のアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
    public class CampaignStAcs : IGeneralGuideData
	{
		#region -- リモートオブジェクト格納バッファ --
		/// <summary>
		/// リモートオブジェクト格納バッファ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ICampaignStDB _iCampaignStDB = null;
		
		#endregion

		#region -- コンストラクタ --
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
		static CampaignStAcs()
		{			
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
		public CampaignStAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iCampaignStDB = (ICampaignStDB)MediationCampaignStDB.GetCampaignStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCampaignStDB = null;
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
            if (this._iCampaignStDB == null)
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
        /// <param name="campaignSt">UIデータクラス</param>
		/// <param name="enterpriseCode">企業コード</param> 
        /// <param name="campaignCode">キャンペーンコード</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
        public int Read(out CampaignSt campaignSt, string enterpriseCode, int campaignCode)
        {
            return ReadProc(out campaignSt, enterpriseCode, campaignCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="campaignSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out CampaignSt campaignSt, string enterpriseCode, int campaignCode)
		{
            int status = 0;

            campaignSt = null;

			try
			{
                CampaignStWork campaignStWork = new CampaignStWork();
                campaignStWork.EnterpriseCode = enterpriseCode;
                campaignStWork.CampaignCode = campaignCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(campaignStWork);

                status = this._iCampaignStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    campaignStWork = (CampaignStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignStWork));
                    // ワーク→UIデータクラス
                    campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                }

				return status;
			}
			catch (Exception)
			{				
				campaignSt = null;
				// オフライン時はnullをセット
				this._iCampaignStDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
		#endregion

		#region -- 登録･更新処理 --
		/// <summary>
		/// 登録・更新処理
		/// </summary>
        /// <param name="campaignSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 登録・更新処理を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref CampaignSt campaignSt)
		{
            int status = 0;

			// UIデータクラス→ワーク
            CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

            object obj = campaignStWork;
			
			try
			{
				// 書き込み処理
                status = this._iCampaignStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        campaignStWork = (CampaignStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                    }
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iCampaignStDB = null;
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
        /// <param name="campaignSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : キャンペーン設定設定の論理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref CampaignSt campaignSt)
		{
            int status = 0;

            // UIデータクラス→ワーク
            CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

            object obj = campaignStWork;

            try
            {
                // 論理削除
                status = this._iCampaignStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    campaignStWork = (CampaignStWork)obj;
                    // ワーク→UIデータクラス
                    campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}

		/// <summary>
		/// 物理削除処理
		/// </summary>
        /// <param name="campaignSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : キャンペーン設定設定の物理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Delete(CampaignSt campaignSt)
		{
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(campaignStWork);

                // 物理削除
                status = this._iCampaignStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}
		#endregion

        #region -- 復活処理 --
        /// <summary>
        /// キャンペーン設定設定復活処理
        /// </summary>
        /// <param name="campaignSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン設定設定の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref CampaignSt campaignSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                CampaignStWork campaignStWork = CopyToCampaignStWorkFromCampaignSt(campaignSt);

                object obj = campaignStWork;

                // 復活処理
                status = this._iCampaignStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    campaignStWork = (CampaignStWork)obj;
                    // ワーク→UIデータクラス
                    campaignSt = CopyToCampaignStFromCampaignStWork(campaignStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// キャンペーン設定設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン設定設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, string.Empty, false);
        }

        /// <summary>
        /// キャンペーン設定設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="searchingAllSectionIfEmpty">検索結果が0件の場合、拠点を全社で再検索するフラグ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : キャンペーン設定設定の検索処理を行います。</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, string sectionCode, bool searchingAllSectionIfEmpty)
		{
            int status = 0;

            CampaignStWork campaignStWork = new CampaignStWork();
            campaignStWork.EnterpriseCode = enterpriseCode;
            campaignStWork.SectionCode = sectionCode;

			retList = new ArrayList();
			
            object paraobj = campaignStWork;
			object retobj = null;

            // キャンペーン設定設定の全検索
            status = this._iCampaignStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (CampaignStWork wkCampaignStWork in workList)
                {
                    if (string.IsNullOrEmpty(sectionCode.Trim()))
                    {
                        // 拠点コードの指定が無い場合、全件追加
                        retList.Add(CopyToCampaignStFromCampaignStWork(wkCampaignStWork));
                    }
                    else if (wkCampaignStWork.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        // 拠点コードの指定がある場合、拠点コードが一致するものを追加
                        retList.Add(CopyToCampaignStFromCampaignStWork(wkCampaignStWork));
                    }
                }
            }

            #region 検索結果が0件の場合、拠点を全社で再検索

            if (retList == null || retList.Count.Equals(0))
            {
                if (searchingAllSectionIfEmpty)
                {
                    return SearchProc(out retList, enterpriseCode, "00", false);
                }
            }

            #endregion

            return status;
		}

        /// <summary>
        /// マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 取得結果をDataSetで返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode)
        {
            return Search(ref ds, enterpriseCode, string.Empty, false);
        }

        /// <summary>
        /// マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="searchingAllSectionIfEmpty">検索結果が0件の場合、拠点を全社で再検索するフラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 取得結果をDataSetで返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode, string sectionCode, bool searchingAllSectionIfEmpty)
        {
            ArrayList retList = new ArrayList();

            int status = 0;
            
            // マスタサーチ
            //status = SearchAll(out retList, enterpriseCode);
            status = SearchProc(out retList, enterpriseCode, sectionCode, searchingAllSectionIfEmpty);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (CampaignSt wkCampaignSt in workList)
            {
                if (wkCampaignSt.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkCampaignSt.CampaignCode, wkCampaignSt);
                }
            }

            CampaignSt[] campaignSt = new CampaignSt[workSort.Count];

            // データを元に戻す
            for (int i = 0; i < workSort.Count; i++)
            {
                campaignSt[i] = (CampaignSt)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(campaignSt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
		#endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
		/// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
		/// </summary>
        /// <param name="campaignStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
		/// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private CampaignSt CopyToCampaignStFromCampaignStWork(CampaignStWork campaignStWork)
		{
            CampaignSt campaignSt = new CampaignSt();

            campaignSt.CreateDateTime = campaignStWork.CreateDateTime;
            campaignSt.UpdateDateTime = campaignStWork.UpdateDateTime;
            campaignSt.EnterpriseCode = campaignStWork.EnterpriseCode;
            campaignSt.FileHeaderGuid = campaignStWork.FileHeaderGuid;
            campaignSt.UpdEmployeeCode = campaignStWork.UpdEmployeeCode;
            campaignSt.UpdAssemblyId1 = campaignStWork.UpdAssemblyId1;
            campaignSt.UpdAssemblyId2 = campaignStWork.UpdAssemblyId2;
            campaignSt.LogicalDeleteCode = campaignStWork.LogicalDeleteCode;
            
            campaignSt.CampaignCode = campaignStWork.CampaignCode;                  // キャンペーンコード
            campaignSt.CampaignName = campaignStWork.CampaignName;                  // キャンペーン名称
            campaignSt.SectionCode = campaignStWork.SectionCode;                    // 拠点コード
            campaignSt.CampaignObjDiv = campaignStWork.CampaignObjDiv;              // キャンペーン対象区分
            campaignSt.ApplyStaDate = campaignStWork.ApplyStaDate;                  // 適用開始日
            campaignSt.ApplyEndDate = campaignStWork.ApplyEndDate;                  // 適用終了日
            campaignSt.SalesTargetMoney = campaignStWork.SalesTargetMoney;          // 売上目標金額
            campaignSt.SalesTargetProfit = campaignStWork.SalesTargetProfit;        // 売上目標粗利額
            campaignSt.SalesTargetCount = campaignStWork.SalesTargetCount;          // 売上目標数量
			
            return campaignSt;
		}
		
		/// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
		/// </summary>
        /// <param name="campaignSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
		/// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private CampaignStWork CopyToCampaignStWorkFromCampaignSt(CampaignSt campaignSt)
		{
            CampaignStWork campaignStWork = new CampaignStWork();

            campaignStWork.CreateDateTime = campaignSt.CreateDateTime;
            campaignStWork.UpdateDateTime = campaignSt.UpdateDateTime;
            campaignStWork.EnterpriseCode = campaignSt.EnterpriseCode;
            campaignStWork.FileHeaderGuid = campaignSt.FileHeaderGuid;
            campaignStWork.UpdEmployeeCode = campaignSt.UpdEmployeeCode;
            campaignStWork.UpdAssemblyId1 = campaignSt.UpdAssemblyId1;
            campaignStWork.UpdAssemblyId2 = campaignSt.UpdAssemblyId2;
            campaignStWork.LogicalDeleteCode = campaignSt.LogicalDeleteCode;
            
            campaignStWork.CampaignCode = campaignSt.CampaignCode;                  // キャンペーンコード
            campaignStWork.CampaignName = campaignSt.CampaignName;                  // キャンペーン名称
            campaignStWork.SectionCode = campaignSt.SectionCode;                    // 拠点コード
            campaignStWork.CampaignObjDiv = campaignSt.CampaignObjDiv;              // キャンペーン対象区分
            campaignStWork.ApplyStaDate = campaignSt.ApplyStaDate;                  // 適用開始日
            campaignStWork.ApplyEndDate = campaignSt.ApplyEndDate;                  // 適用終了日
            campaignStWork.SalesTargetMoney = campaignSt.SalesTargetMoney;          // 売上目標金額
            campaignStWork.SalesTargetProfit = campaignSt.SalesTargetProfit;        // 売上目標粗利額
            campaignStWork.SalesTargetCount = campaignSt.SalesTargetCount;          // 売上目標数量
            
            return campaignStWork;
		}
		#endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br></br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode   = "";
            string sectionCode      = "";

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // 拠点コード設定有り
            if (inParm.ContainsKey("SectionCode"))
            {
                sectionCode = inParm["SectionCode"].ToString();
            }

            // キャンペーン設定マスタの読込
            status = Search(ref guideList, enterpriseCode, sectionCode, true);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// キャンペーン設定マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="campaignSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: キャンペーン設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out CampaignSt campaignSt)
        {
            return ExecuteGuid(enterpriseCode, string.Empty, out campaignSt);
        }

        /// <summary>
        /// キャンペーン設定マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="campaignSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: キャンペーン設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, string sectionCode, out CampaignSt campaignSt)
        {
            int status = -1;
            campaignSt = new CampaignSt();
            
            TableGuideParent tableGuideParent = new TableGuideParent("CAMPAIGNSTGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            // 拠点コード
            inObj.Add("SectionCode", sectionCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = retObj["CampaignCode"].ToString();
                campaignSt.CampaignCode = int.Parse(strCode);
                campaignSt.CampaignName = retObj["CampaignName"].ToString();
                strCode = retObj["CampaignObjDiv"].ToString();
                campaignSt.CampaignObjDiv = int.Parse(strCode);
                strCode = retObj["ApplyStaDate"].ToString();
                campaignSt.ApplyStaDate = DateTime.Parse(strCode);
                strCode = retObj["ApplyEndDate"].ToString();
                campaignSt.ApplyEndDate = DateTime.Parse(strCode);
                strCode = retObj["SalesTargetMoney"].ToString();
                campaignSt.SalesTargetMoney = long.Parse(strCode);
                strCode = retObj["SalesTargetProfit"].ToString();
                campaignSt.SalesTargetProfit = long.Parse(strCode);
                strCode = retObj["SalesTargetCount"].ToString();
                campaignSt.SalesTargetCount = long.Parse(strCode);
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
        #endregion
    }
}
