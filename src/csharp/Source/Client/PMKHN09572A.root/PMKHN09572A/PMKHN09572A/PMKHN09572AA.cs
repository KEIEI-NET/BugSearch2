//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン関連マスタ
// プログラム概要   : キャンペーン関連の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン関連マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン関連マスタテーブルのアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
    public class CampaignLinkAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
		private ICampaignLinkDB _iCampaignLinkDB = null;
        
        #endregion

        #region -- Private Member --
        /// <summary> キャンペーン設定アクセスクラス </summary>
        private CampaignStAcs _campaignStAcs = null;

        /// <summary> キャンペーン設定ディクショナリー </summary>
        private Dictionary<int, CampaignSt> _campaignStDic = null;
        #endregion

        #region -- コンストラクタ --
        /// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
        static CampaignLinkAcs()
		{			
		}

        /// <summary>
        /// キャンペーン関連マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : キャンペーン関連マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public CampaignLinkAcs()
		{
			try
			{
				// リモートオブジェクト取得
                this._iCampaignLinkDB = (ICampaignLinkDB)MediationCampaignLinkDB.GetCampaignLinkDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
                this._iCampaignLinkDB = null;
			}
		}

        #endregion

        #region -- プロパティ --
        public CampaignStAcs CampaignStAcs
        {
            get
            {
                if (_campaignStAcs == null)
                {
                    _campaignStAcs = new CampaignStAcs();
                }
                return _campaignStAcs;
            }
        }
        #endregion

        #region -- オンラインモード取得処理 --
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignLinkDB == null)
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
        /// <param name="campaignLink">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="campaignCode">キャンペーンコード</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out CampaignLink campaignLink, string enterpriseCode, int campaignCode)
        {
            return ReadProc(out campaignLink, enterpriseCode, campaignCode);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="campaignLink">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out CampaignLink campaignLink, string enterpriseCode, int campaignCode)
        {
            int status = 0;

            campaignLink = null;

            try
            {
                CampaignLinkWork campaignLinkWork = new CampaignLinkWork();
                campaignLinkWork.EnterpriseCode = enterpriseCode;
                campaignLinkWork.CampaignCode = campaignCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(campaignLinkWork);

                status = this._iCampaignLinkDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    campaignLinkWork = (CampaignLinkWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignLinkWork));
                    // ワーク→UIデータクラス
                    campaignLink = CopyToCampaignLinkFromCampaignLinkWork(campaignLinkWork);
                }

                return status;
            }
            catch (Exception)
            {
                campaignLink = null;
                // オフライン時はnullをセット
                this._iCampaignLinkDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 登録･更新処理 --
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="campaignLinkList">UIデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();            
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UIデータクラス→ワーク
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // 登録・更新情報を設定
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // 書き込み処理
                status = this._iCampaignLinkDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)obj;
                    campaignLinkList.Clear();

                    foreach (CampaignLinkWork wkCampaignLinkWork in paraList)
                    {
                        CampaignLink campaignLink = new CampaignLink();
                        // ワーク→UIデータクラス
                        campaignLink = this.CopyToCampaignLinkFromCampaignLinkWork((CampaignLinkWork)wkCampaignLinkWork);
                        campaignLinkList.Add(campaignLink);
                    }
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCampaignLinkDB = null;
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
        /// <param name="campaignLinkList">UIデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連の論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UIデータクラス→ワーク
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // 論理削除情報を設定
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // 論理削除
                status = this._iCampaignLinkDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)obj;
                    campaignLinkList.Clear();

                    foreach (CampaignLinkWork wkCampaignLinkWork in paraList)
                    {
                        CampaignLink campaignLink = new CampaignLink();
                        // ワーク→UIデータクラス
                        campaignLink = this.CopyToCampaignLinkFromCampaignLinkWork((CampaignLinkWork)wkCampaignLinkWork);
                        campaignLinkList.Add(campaignLink);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignLinkDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="campaignLinkList">UIデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連の物理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Delete(ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UIデータクラス→ワーク
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // 物理削除情報を設定
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // ArrayListから配列を生成
                CampaignLinkWork[] campaignMngWorks = (CampaignLinkWork[])paraList.ToArray(typeof(CampaignLinkWork));

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(campaignMngWorks);

                // 物理削除
                status = this._iCampaignLinkDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignLinkDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 復活処理 --
        /// <summary>
        /// キャンペーン関連復活処理
        /// </summary>
        /// <param name="campaignLinkList">UIデータクラスリスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref ArrayList campaignLinkList)
        {
            int status = 0;
            ArrayList paraList = new ArrayList();
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            foreach (CampaignLink campaignLink in campaignLinkList)
            {
                // UIデータクラス→ワーク
                campaignLinkWork = CopyToCampaignLinkWorkFromCampaignLink(campaignLink);

                // 論理削除情報を設定
                paraList.Add(campaignLinkWork);
            }

            object obj = paraList;

            try
            {
                // 復活処理
                status = this._iCampaignLinkDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)obj;
                    campaignLinkList.Clear();

                    foreach (CampaignLinkWork wkCampaignLinkWork in paraList)
                    {
                        CampaignLink campaignLink = new CampaignLink();
                        // ワーク→UIデータクラス
                        campaignLink = this.CopyToCampaignLinkFromCampaignLinkWork((CampaignLinkWork)wkCampaignLinkWork);
                        campaignLinkList.Add(campaignLink);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignLinkDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// キャンペーン関連検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, 0);
        }

        /// <summary>
        /// キャンペーン関連検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連の検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br></br>
        /// </remarks>
        public int SearchDetail(out ArrayList retList, string enterpriseCode, int campaignCode)
        {
            return SearchProc(out retList, enterpriseCode, campaignCode);
        }

        /// <summary>
        /// キャンペーン関連検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン関連の検索処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, int campaignCode)
        {
            int status = 0;

            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();
            campaignLinkWork.EnterpriseCode = enterpriseCode;
            campaignLinkWork.CampaignCode = campaignCode;

            retList = new ArrayList();

            object paraobj = campaignLinkWork;
            object retobj = null;

            // キャンペーン関連の全検索
            status = this._iCampaignLinkDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (CampaignLinkWork wkCampaignLinkWork in workList)
                {
                    retList.Add(CopyToCampaignLinkFromCampaignLinkWork(wkCampaignLinkWork));
                }
            }

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
            ArrayList retList = new ArrayList();

            int status = 0;

            // マスタサーチ
            status = SearchAll(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (CampaignLink wkCampaignLink in workList)
            {
                if (wkCampaignLink.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkCampaignLink.CampaignCode, wkCampaignLink);
                }
            }

            CampaignLink[] campaignLink = new CampaignLink[workSort.Count];

            // データを元に戻す
            for (int i = 0; i < workSort.Count; i++)
            {
                campaignLink[i] = (CampaignLink)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(campaignLink);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
        /// </summary>
        /// <param name="campaignLinkWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
        /// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private CampaignLink CopyToCampaignLinkFromCampaignLinkWork(CampaignLinkWork campaignLinkWork)
        {
            CampaignLink campaignLink = new CampaignLink();

            campaignLink.CreateDateTime = campaignLinkWork.CreateDateTime;
            campaignLink.UpdateDateTime = campaignLinkWork.UpdateDateTime;
            campaignLink.EnterpriseCode = campaignLinkWork.EnterpriseCode;
            campaignLink.FileHeaderGuid = campaignLinkWork.FileHeaderGuid;
            campaignLink.UpdEmployeeCode = campaignLinkWork.UpdEmployeeCode;
            campaignLink.UpdAssemblyId1 = campaignLinkWork.UpdAssemblyId1;
            campaignLink.UpdAssemblyId2 = campaignLinkWork.UpdAssemblyId2;
            campaignLink.LogicalDeleteCode = campaignLinkWork.LogicalDeleteCode;

            campaignLink.CampaignCode = campaignLinkWork.CampaignCode;                  // キャンペーンコード
            campaignLink.CustomerCode = campaignLinkWork.CustomerCode;                  // 得意先コード
            campaignLink.SalesAreaCode = campaignLinkWork.SalesAreaCode;                // 販売エリアコード
            campaignLink.CustomerAgentCd = campaignLinkWork.CustomerAgentCd;            // 顧客担当従業員
            campaignLink.InfoSendCode = campaignLinkWork.InfoSendCode;                  // 情報送信区分
            
            return campaignLink;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
        /// </summary>
        /// <param name="campaignLink">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private CampaignLinkWork CopyToCampaignLinkWorkFromCampaignLink(CampaignLink campaignLink)
        {
            CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

            campaignLinkWork.CreateDateTime = campaignLink.CreateDateTime;
            campaignLinkWork.UpdateDateTime = campaignLink.UpdateDateTime;
            campaignLinkWork.EnterpriseCode = campaignLink.EnterpriseCode;
            campaignLinkWork.FileHeaderGuid = campaignLink.FileHeaderGuid;
            campaignLinkWork.UpdEmployeeCode = campaignLink.UpdEmployeeCode;
            campaignLinkWork.UpdAssemblyId1 = campaignLink.UpdAssemblyId1;
            campaignLinkWork.UpdAssemblyId2 = campaignLink.UpdAssemblyId2;
            campaignLinkWork.LogicalDeleteCode = campaignLink.LogicalDeleteCode;

            campaignLinkWork.CampaignCode = campaignLink.CampaignCode;                  // キャンペーンコード
            campaignLinkWork.CustomerCode = campaignLink.CustomerCode;                  // 得意先コード
            campaignLinkWork.SalesAreaCode = campaignLink.SalesAreaCode;                // 販売エリアコード
            campaignLinkWork.CustomerAgentCd = campaignLink.CustomerAgentCd;            // 顧客担当従業員
            campaignLinkWork.InfoSendCode = campaignLink.InfoSendCode;                  // 情報送信区分

            return campaignLinkWork;
        }
        #endregion

        #region -- キャンペーン名称取得 --
        /// <summary>
        /// キャンペーン名称取得
        /// </summary>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <returns>キャンペーン名称</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン名称の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public string GetCampaignName(int campaignCode)
        {
            string name = string.Empty;

            if (_campaignStDic == null)
            {
                // キャンペーン設定リスト取得
                GetCampaignStList();
            }

            CampaignSt campaignSt;
            if (_campaignStDic.ContainsKey(campaignCode))
            {
                // ディクショナリーに存在
                campaignSt = _campaignStDic[campaignCode];
                name = campaignSt.CampaignName;
            }
            else
            {
                // ディクショナリーに存在しないので、マスタから読込
                campaignSt = ReadCampaignSt(campaignCode);
                name = campaignSt.CampaignName;
            }

            return name;
        }

        /// <summary>
        /// 最新情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 最新情報の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public void Renewal()
        {
            // キャンペーン設定リスト取得
            GetCampaignStList();
        }

        /// <summary>
        /// キャンペーン設定リスト取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン設定マスタの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private void GetCampaignStList()
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            _campaignStDic = new Dictionary<int, CampaignSt>();
            ArrayList retList;

            // 全検索
            int status = _campaignStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (CampaignSt campaignSt in retList)
                {
                    if (campaignSt.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    if (!_campaignStDic.ContainsKey(campaignSt.CampaignCode))
                    {
                        _campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                    }
                }
            }
        }

        /// <summary>
        /// キャンペーン設定マスタ読込処理
        /// </summary>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <returns>キャンペーン設定データクラス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン設定マスタの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private CampaignSt ReadCampaignSt(int campaignCode)
        {
            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            CampaignSt campaignSt;
            int status = _campaignStAcs.Read(out campaignSt, LoginInfoAcquisition.EnterpriseCode, campaignCode);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (campaignSt.LogicalDeleteCode == 0))
            {
                ;
            }
            else
            {
                campaignSt = new CampaignSt();
            }

            return campaignSt;
        }
        #endregion
    }
}
