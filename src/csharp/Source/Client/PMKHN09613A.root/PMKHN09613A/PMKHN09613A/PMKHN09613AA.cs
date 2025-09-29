//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン売価優先設定マスタメンテナンス
// プログラム概要   : キャンペーン売価優先設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン売価優先設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン売価優先設定マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br></br>
    /// </remarks>
    public class CampaignPrcPrStAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private ICampaignPrcPrStDB _iCampaignPrcPrStDB = null;

        // ローカルＤＢモード
        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        public CampaignPrcPrStAcs()
        {
            // リモートオブジェクト取得
            this._iCampaignPrcPrStDB = (ICampaignPrcPrStDB)MediationCampaignPrcPrStDB.GetCampaignPrcPrStDB();
        }

        #endregion

        #region [ローカルアクセス用]
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        #endregion

        #region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="campaignPrcPrSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Write(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            int status = 0;
           
            try
            {
                // UIデータクラス→ワーク
                CampaignPrcPrStWork campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);

                object objCampaignPrcPrStWork = campaignPrcPrStWork;

                int writeMode = 0;

                // 書き込み処理
                status = this._iCampaignPrcPrStDB.Write(ref objCampaignPrcPrStWork, writeMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    campaignPrcPrStWork = objCampaignPrcPrStWork as CampaignPrcPrStWork;

                    // クラス内メンバコピー
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignPrcPrStDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
          
            return status;
        }

        #endregion -- 登録･更新処理 --

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="campaignPrcPrSt">キャンペーン売価優先設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタの論理削除を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int LogicalDelete(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            try
            {
                CampaignPrcPrStWork campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);
                object objCampaignPrcPrStWork = campaignPrcPrStWork;

                // 拠点情報論理削除
                int status = this._iCampaignPrcPrStDB.LogicalDelete(ref objCampaignPrcPrStWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    campaignPrcPrStWork = objCampaignPrcPrStWork as CampaignPrcPrStWork;

                    // クラス内メンバコピー
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);

                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignPrcPrStDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
           
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="campaignPrcPrSt">キャンペーン売価優先設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタの物理削除を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Delete(CampaignPrcPrSt campaignPrcPrSt)
        {
            try
            {
                CampaignPrcPrStWork campaignPrcPrStWorks = new CampaignPrcPrStWork();
                campaignPrcPrStWorks = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);

                byte[] parabyte = XmlByteSerializer.Serialize(campaignPrcPrStWorks);

                // 物理削除
                int status = this._iCampaignPrcPrStDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignPrcPrStDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region -- 検索･復活処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// キャンペーン売価優先設定マスタ全件検索処理（論理削除含む）
        /// </summary>
        /// <param name="campaignPrcPrStList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int SearchAll(out ArrayList campaignPrcPrStList, string enterpriseCode)
        {
            return SearchProc(out campaignPrcPrStList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// キャンペーン売価優先設定マスタ全件検索処理
        /// </summary>
        /// <param name="campaignPrcPrStList">読込結果コレクション</param>  
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList campaignPrcPrStList, string enterpriseCode, SearchMode searchMode)
        {

            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();

            campaignPrcPrStWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            campaignPrcPrStList = new ArrayList();
            campaignPrcPrStList.Clear();

            ArrayList campaignPrcPrStWorkList = new ArrayList();
            campaignPrcPrStWorkList.Clear();

            object paraobj = campaignPrcPrStWork;
            object retobj = null;

            status = this._iCampaignPrcPrStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                campaignPrcPrStWorkList = retobj as ArrayList;

                foreach (CampaignPrcPrStWork wkCampaignPrcPrStWork in campaignPrcPrStWorkList)
                {
                    campaignPrcPrStList.Add(CopyToCampaignPrcPrStFromCampaignPrcPrStWork(wkCampaignPrcPrStWork));
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (campaignPrcPrStList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ検索処理
        /// </summary>
        /// <param name="campaignPrcPrSt">キャンペーン売価優先設定クラスオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Read(out CampaignPrcPrSt campaignPrcPrSt, string enterpriseCode, string sectionCode)
        {
            try
            {
                campaignPrcPrSt = null;

                CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();

                campaignPrcPrStWork.EnterpriseCode = enterpriseCode;
                campaignPrcPrStWork.SectionCode = sectionCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(campaignPrcPrStWork);

                // メール送信管理フィールド名称読み込み
                int status = this._iCampaignPrcPrStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    campaignPrcPrStWork = (CampaignPrcPrStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignPrcPrStWork));
                    // クラス内メンバコピー
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                campaignPrcPrSt = null;
                //オフライン時はnullをセット
                this._iCampaignPrcPrStDB = null;
                return -1;
            }
        }

        /// <summary>
        /// 論理削除復活処理
        /// </summary>
        /// <param name="campaignPrcPrSt">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : の復活を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Revival(ref CampaignPrcPrSt campaignPrcPrSt)
        {
            try
            {
                CampaignPrcPrStWork campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(campaignPrcPrSt);

                // XMLへ変換し、文字列のバイナリ化
                object objCampaignPrcPrStWork = campaignPrcPrStWork;

                // 復活処理
                int status = this._iCampaignPrcPrStDB.RevivalLogicalDelete(ref objCampaignPrcPrStWork);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    campaignPrcPrStWork = objCampaignPrcPrStWork as CampaignPrcPrStWork;

                    // クラス内メンバコピー
                    campaignPrcPrSt = CopyToCampaignPrcPrStFromCampaignPrcPrStWork(campaignPrcPrStWork);

                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignPrcPrStDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
           
           
        }

        #endregion -- 検索･復活処理 --

        #region -- クラスメンバーコピー処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン売価優先設定マスタワーククラス⇒キャンペーン売価優先設定マスタクラス）
        /// </summary>
        /// <param name="campaignPrcPrStWork">キャンペーン売価優先設定マスタワーククラス</param>
        /// <returns>キャンペーン売価優先設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタワーククラスからキャンペーン売価優先設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private CampaignPrcPrSt CopyToCampaignPrcPrStFromCampaignPrcPrStWork(CampaignPrcPrStWork campaignPrcPrStWork)
        {
            CampaignPrcPrSt campaignPrcPrSt = new CampaignPrcPrSt();
            campaignPrcPrSt.CreateDateTime = campaignPrcPrStWork.CreateDateTime;
            campaignPrcPrSt.UpdateDateTime = campaignPrcPrStWork.UpdateDateTime;
            campaignPrcPrSt.EnterpriseCode = campaignPrcPrStWork.EnterpriseCode;
            campaignPrcPrSt.FileHeaderGuid = campaignPrcPrStWork.FileHeaderGuid;
            campaignPrcPrSt.UpdEmployeeCode = campaignPrcPrStWork.UpdEmployeeCode;
            campaignPrcPrSt.UpdAssemblyId1 = campaignPrcPrStWork.UpdAssemblyId1;
            campaignPrcPrSt.UpdAssemblyId2 = campaignPrcPrStWork.UpdAssemblyId2;
            campaignPrcPrSt.LogicalDeleteCode = campaignPrcPrStWork.LogicalDeleteCode;
            campaignPrcPrSt.SectionCode = campaignPrcPrStWork.SectionCode;
            campaignPrcPrSt.PrioritySettingCd1 = campaignPrcPrStWork.PrioritySettingCd1;
            campaignPrcPrSt.PrioritySettingCd2 = campaignPrcPrStWork.PrioritySettingCd2;
            campaignPrcPrSt.PrioritySettingCd3 = campaignPrcPrStWork.PrioritySettingCd3;
            campaignPrcPrSt.PrioritySettingCd4 = campaignPrcPrStWork.PrioritySettingCd4;
            campaignPrcPrSt.PrioritySettingCd5 = campaignPrcPrStWork.PrioritySettingCd5;
            campaignPrcPrSt.PrioritySettingCd6 = campaignPrcPrStWork.PrioritySettingCd6;

            return campaignPrcPrSt;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン売価優先設定マスタクラス⇒キャンペーン売価優先設定マスタワーククラス）
        /// </summary>
        /// <param name="allDefSet">キャンペーン売価優先設定マスタクラス</param>
        /// <returns>キャンペーン売価優先設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタクラスからキャンペーン売価優先設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private CampaignPrcPrStWork CopyToCampaignPrcPrStWorkFromCampaignPrcPrSt(CampaignPrcPrSt campaignPrcPrSt)
        {
            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();
            campaignPrcPrStWork.CreateDateTime = campaignPrcPrSt.CreateDateTime;
            campaignPrcPrStWork.UpdateDateTime = campaignPrcPrSt.UpdateDateTime;
            campaignPrcPrStWork.EnterpriseCode = campaignPrcPrSt.EnterpriseCode;
            campaignPrcPrStWork.FileHeaderGuid = campaignPrcPrSt.FileHeaderGuid;
            campaignPrcPrStWork.UpdEmployeeCode = campaignPrcPrSt.UpdEmployeeCode;
            campaignPrcPrStWork.UpdAssemblyId1 = campaignPrcPrSt.UpdAssemblyId1;
            campaignPrcPrStWork.UpdAssemblyId2 = campaignPrcPrSt.UpdAssemblyId2;
            campaignPrcPrStWork.LogicalDeleteCode = campaignPrcPrSt.LogicalDeleteCode;
            campaignPrcPrStWork.SectionCode = campaignPrcPrSt.SectionCode;
            campaignPrcPrStWork.PrioritySettingCd1 = campaignPrcPrSt.PrioritySettingCd1;
            campaignPrcPrStWork.PrioritySettingCd2 = campaignPrcPrSt.PrioritySettingCd2;
            campaignPrcPrStWork.PrioritySettingCd3 = campaignPrcPrSt.PrioritySettingCd3;
            campaignPrcPrStWork.PrioritySettingCd4 = campaignPrcPrSt.PrioritySettingCd4;
            campaignPrcPrStWork.PrioritySettingCd5 = campaignPrcPrSt.PrioritySettingCd5;
            campaignPrcPrStWork.PrioritySettingCd6 = campaignPrcPrSt.PrioritySettingCd6;

            return campaignPrcPrStWork;

        }

        #endregion -- クラスメンバーコピー処理 --
       

    }
}
