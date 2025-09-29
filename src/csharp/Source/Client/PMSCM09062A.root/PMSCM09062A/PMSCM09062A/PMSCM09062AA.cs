//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM優先設定マスタ
// プログラム概要   : SCM優先設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
// Update Note      :	 優先設定マスタを改良                   		      //
//                  :    lingxiaoqing                                         //
//                  :    2011.08.08                                           //
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
    /// SCM優先設定アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM優先設定のアクセス制御を行います。</br>
    /// <br></br>
    /// </remarks>
	public class SCMPriorStAcs
	{
		#region -- リモートオブジェクト格納バッファ --
		/// <summary>
		/// リモートオブジェクト格納バッファ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br></br>
		/// </remarks>
		private ISCMPriorStDB _iSCMPriorStDB = null;
		
		#endregion

		#region -- コンストラクタ --
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
		static SCMPriorStAcs()
		{			
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
		public SCMPriorStAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._iSCMPriorStDB = (ISCMPriorStDB)MediationSCMPriorStDB.GetSCMPriorStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSCMPriorStDB = null;
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
            if (this._iSCMPriorStDB == null)
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
        // ------------DELETE BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>
        // /// <summary>
        ///// 読み込み処理
        ///// </summary>
        ///// <param name="scmPriorSt">UIデータクラス</param>
        ///// <param name="enterpriseCode">企業コード</param> 
        ///// <param name="sectionCode">拠点コード</param> 
        ///// <remarks>
        ///// <br>Note       : </br>
        ///// <br></br>
        ///// </remarks>
        //public int Read(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode)
        //{
        //    return ReadProc(out scmPriorSt, enterpriseCode, sectionCode,customerCode,priorAppliDiv);
        //}
        // ------------DELETE BY lingxiaoqing  2011.08.08-------------<<<<<<<<<<<<<<

        // ------------ADD BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>>>
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>  
        /// <param name="customerCode">得意先コード</param> 
        /// <param name="priorAppliDiv">優先適用区分</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            return ReadProc(out scmPriorSt, enterpriseCode, sectionCode, customerCode, priorAppliDiv);
        }
        // ------------ADD BY lingxiaoqing  2011.08.08--------------<<<<<<<<<<<<<<<<
        // ------------ADD 2011.08.10------------->>>>>>>>>>>>>>>
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>  
        /// <param name="customerCode">得意先コード</param> 
        /// <param name="priorAppliDiv">優先適用区分</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int ReadPCCUOE(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            return ReadProcPCCUOE(out scmPriorSt, enterpriseCode, sectionCode, customerCode, priorAppliDiv);
        }
        // ------------ADD 2011.08.10-------------<<<<<<<<<<<<<<

        // ------------DELETE BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>>>>>   
        ///// <summary>
        ///// 読み込み処理
        ///// </summary>
        ///// <param name="scmPriorSt">UIデータクラス</param>
        ///// <param name="enterpriseCode">企業コード</param> 
        ///// <param name="sectionCode">拠点コード</param> 
        ///// <remarks>
        ///// <br>Note       : </br>
        ///// <br></br>
        ///// </remarks>
        //private int ReadProc(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode)
        //{
        //    int status = 0;

        //    scmPriorSt = null;

        //    try
        //    {
        //        SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
        //        scmPriorStWork.EnterpriseCode = enterpriseCode;
        //        scmPriorStWork.SectionCode = sectionCode;

        //        // XMLへ変換し、文字列のバイナリ化
        //        byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

        //        status = this._iSCMPriorStDB.Read(ref parabyte, 0);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // XMLの読み込み
        //            scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
        //            // ワーク→UIデータクラス
        //            scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
        //        }

        //        return status;
        //    }
        //    catch (Exception)
        //    {				
        //        scmPriorSt = null;
        //        // オフライン時はnullをセット
        //        this._iSCMPriorStDB = null;
        //        // 通信エラーは-1を戻す
        //        return -1;
        //    }
        //}
        // ------------DELETE BY lingxiaoqing  2011.08.08-------------<<<<<<<<<<<<<<

        // ------------ADD BY lingxiaoqing  2011.08.08------------->>>>>>>>>>>>>>>
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param> 
        /// <param name="priorAppliDiv">優先適用区分</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            int status = 0;

            scmPriorSt = null;

            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
                scmPriorStWork.EnterpriseCode = enterpriseCode;
                scmPriorStWork.SectionCode = sectionCode;
                scmPriorStWork.CustomerCode = customerCode;
                scmPriorStWork.PriorAppliDiv = priorAppliDiv;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

                status = this._iSCMPriorStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                    // ワーク→UIデータクラス
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                scmPriorSt = null;
                // オフライン時はnullをセット
                this._iSCMPriorStDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
        // ------------ADD BY lingxiaoqing  2011.08.08-------------<<<<<<<<<<<<<<

        // ------------ADD 2011.08.10------------->>>>>>>>>>>>>>>
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param> 
        /// <param name="priorAppliDiv">優先適用区分</param>  
        /// <remarks>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        private int ReadProcPCCUOE(out SCMPriorSt scmPriorSt, string enterpriseCode, string sectionCode, int customerCode, int priorAppliDiv)
        {
            int status = 0;

            scmPriorSt = null;

            try
            {
                SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
                scmPriorStWork.EnterpriseCode = enterpriseCode;
                scmPriorStWork.SectionCode = sectionCode;
                scmPriorStWork.CustomerCode = customerCode;
                scmPriorStWork.PriorAppliDiv = priorAppliDiv;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

                status = this._iSCMPriorStDB.ReadPCCUOE(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    scmPriorStWork = (SCMPriorStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMPriorStWork));
                    // ワーク→UIデータクラス
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                scmPriorSt = null;
                // オフライン時はnullをセット
                this._iSCMPriorStDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
        // ------------ADD 2011.08.10------------->>>>>>>>>>>>>>>
		#endregion

		#region -- 登録･更新処理 --
		/// <summary>
		/// 登録・更新処理
		/// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 登録・更新処理を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Write(ref SCMPriorSt scmPriorSt)
		{
            int status = 0;

			// UIデータクラス→ワーク
            SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

            object obj = scmPriorStWork;
			
			try
			{
				// 書き込み処理
                status = this._iSCMPriorStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (obj is ArrayList)
                    {
                        scmPriorStWork = (SCMPriorStWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                    }
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iSCMPriorStDB = null;
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
        /// <param name="scmPriorSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : SCM優先設定の論理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int LogicalDelete(ref SCMPriorSt scmPriorSt)
		{
            int status = 0;

            // UIデータクラス→ワーク
            SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

            object obj = scmPriorStWork;

            try
            {
                // 論理削除
                status = this._iSCMPriorStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmPriorStWork = (SCMPriorStWork)obj;
                    // ワーク→UIデータクラス
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMPriorStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}

		/// <summary>
		/// 物理削除処理
		/// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM優先設定の物理削除を行います。</br>
		/// <br></br>
		/// </remarks>
        public int Delete(SCMPriorSt scmPriorSt)
		{
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(scmPriorStWork);

                // 物理削除
                status = this._iSCMPriorStDB.Delete(parabyte);
                
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMPriorStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
		}
		#endregion

        #region -- 復活処理 --
        /// <summary>
        /// SCM優先設定復活処理
        /// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM優先設定の復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SCMPriorSt scmPriorSt)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                SCMPriorStWork scmPriorStWork = CopyToSCMPriorStWorkFromSCMPriorSt(scmPriorSt);

                object obj = scmPriorStWork;

                // 復活処理
                status = this._iSCMPriorStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    scmPriorStWork = (SCMPriorStWork)obj;
                    // ワーク→UIデータクラス
                    scmPriorSt = CopyToSCMPriorStFromSCMPriorStWork(scmPriorStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMPriorStDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索処理 --
        /// <summary>
        /// SCM優先設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM優先設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br></br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// SCM優先設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : SCM優先設定の検索処理を行います。</br>
		/// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
		{
            int status = 0;

            SCMPriorStWork scmPriorStWork = new SCMPriorStWork();
            scmPriorStWork.EnterpriseCode = enterpriseCode;

			retList = new ArrayList();
			
            object paraobj = scmPriorStWork;
			object retobj = null;

            // SCM優先設定の全検索
            status = this._iSCMPriorStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (SCMPriorStWork wkSCMPriorStWork in workList)
                {
                    retList.Add(CopyToSCMPriorStFromSCMPriorStWork(wkSCMPriorStWork));
                }
            }
                
 			return status;
		}
		#endregion

        #region -- クラスメンバーコピー処理 --
        /// <summary>
		/// クラスメンバーコピー処理（ワーククラス⇒UIデータクラス）
		/// </summary>
        /// <param name="scmPriorStWork">ワーククラス</param>
        /// <returns>UIデータクラス</returns>
		/// <remarks>
        /// <br>Note       : ワーククラスからUIデータクラスへメンバーのコピーを行います。</br>
		/// <br></br>
        /// </remarks>
        private SCMPriorSt CopyToSCMPriorStFromSCMPriorStWork(SCMPriorStWork scmPriorStWork)
		{
            SCMPriorSt scmPriorSt = new SCMPriorSt();

            scmPriorSt.CreateDateTime = scmPriorStWork.CreateDateTime;
            scmPriorSt.UpdateDateTime = scmPriorStWork.UpdateDateTime;
            scmPriorSt.EnterpriseCode = scmPriorStWork.EnterpriseCode;
            scmPriorSt.FileHeaderGuid = scmPriorStWork.FileHeaderGuid;
            scmPriorSt.UpdEmployeeCode = scmPriorStWork.UpdEmployeeCode;
            scmPriorSt.UpdAssemblyId1 = scmPriorStWork.UpdAssemblyId1;
            scmPriorSt.UpdAssemblyId2 = scmPriorStWork.UpdAssemblyId2;
            scmPriorSt.LogicalDeleteCode = scmPriorStWork.LogicalDeleteCode;
            scmPriorSt.SectionCode = scmPriorStWork.SectionCode;

            scmPriorSt.PrioritySettingCd1 = scmPriorStWork.PrioritySettingCd1;      // 優先設定コード１
            scmPriorSt.PrioritySettingNm1 = scmPriorStWork.PrioritySettingNm1;      // 優先設定名称１
            scmPriorSt.PrioritySettingCd2 = scmPriorStWork.PrioritySettingCd2;      // 優先設定コード２
            scmPriorSt.PrioritySettingNm2 = scmPriorStWork.PrioritySettingNm2;      // 優先設定名称２
            scmPriorSt.PrioritySettingCd3 = scmPriorStWork.PrioritySettingCd3;      // 優先設定コード３
            scmPriorSt.PrioritySettingNm3 = scmPriorStWork.PrioritySettingNm3;      // 優先設定名称３
            scmPriorSt.PrioritySettingCd4 = scmPriorStWork.PrioritySettingCd4;      // 優先設定コード４
            scmPriorSt.PrioritySettingNm4 = scmPriorStWork.PrioritySettingNm4;      // 優先設定名称４
            scmPriorSt.PrioritySettingCd5 = scmPriorStWork.PrioritySettingCd5;      // 優先設定コード５
            scmPriorSt.PrioritySettingNm5 = scmPriorStWork.PrioritySettingNm5;      // 優先設定名称５

            scmPriorSt.PriorPriceSetCd1 = scmPriorStWork.PriorPriceSetCd1;          // 優先価格設定コード１
            scmPriorSt.PriorPriceSetNm1 = scmPriorStWork.PriorPriceSetNm1;          // 優先価格設定名称１
            scmPriorSt.PriorPriceSetCd2 = scmPriorStWork.PriorPriceSetCd2;          // 優先価格設定コード２
            scmPriorSt.PriorPriceSetNm2 = scmPriorStWork.PriorPriceSetNm2;          // 優先価格設定名称２
            scmPriorSt.PriorPriceSetCd3 = scmPriorStWork.PriorPriceSetCd3;          // 優先価格設定コード３
            scmPriorSt.PriorPriceSetNm3 = scmPriorStWork.PriorPriceSetNm3;          // 優先価格設定名称３
            scmPriorSt.PriorPriceSetCd4 = scmPriorStWork.PriorPriceSetCd4;          // 優先価格設定コード４
            scmPriorSt.PriorPriceSetNm4 = scmPriorStWork.PriorPriceSetNm4;          // 優先価格設定名称４
            scmPriorSt.PriorPriceSetCd5 = scmPriorStWork.PriorPriceSetCd5;          // 優先価格設定コード５
            scmPriorSt.PriorPriceSetNm5 = scmPriorStWork.PriorPriceSetNm5;          // 優先価格設定名称５

            //-----ADD BY lingxiaoqing  2011.08.08---------->>>>>>>>>>>>>>>
            //得意先コード
            scmPriorSt.CustomerCode = scmPriorStWork.CustomerCode;
            //優先適用区分
            scmPriorSt.PriorAppliDiv = scmPriorStWork.PriorAppliDiv;
            //選択時対象純優区分    
            scmPriorSt.SelTgtPureDiv = scmPriorStWork.SelTgtPureDiv;
            //選択時対象在庫区分
            scmPriorSt.SelTgtStckDiv = scmPriorStWork.SelTgtStckDiv;
            //選択時対象キャンペーン区分
            scmPriorSt.SelTgtCampDiv = scmPriorStWork.SelTgtCampDiv;
            //非選択時対象純優区分    
            scmPriorSt.UnSelTgtPureDiv = scmPriorStWork.UnSelTgtPureDiv;
            //非選択時対象在庫区分
            scmPriorSt.UnSelTgtStckDiv = scmPriorStWork.UnSelTgtStckDiv;
            //非選択時対象キャンペーン区分
            scmPriorSt.UnSelTgtCampDiv = scmPriorStWork.UnSelTgtCampDiv;
            //選択時対象価格区分１
            scmPriorSt.SelTgtPricDiv1 = scmPriorStWork.SelTgtPricDiv1;
            //選択時対象価格区分２
            scmPriorSt.SelTgtPricDiv2 = scmPriorStWork.SelTgtPricDiv2;
            //選択時対象価格区分 3
            scmPriorSt.SelTgtPricDiv3 = scmPriorStWork.SelTgtPricDiv3;
            //非選択時対象価格区分１
            scmPriorSt.UnSelTgtPricDiv1 = scmPriorStWork.UnSelTgtPricDiv1;
            //非選択時対象価格区分２
            scmPriorSt.UnSelTgtPricDiv2 = scmPriorStWork.UnSelTgtPricDiv2;
            //非選択時対象価格区分 3
            scmPriorSt.UnSelTgtPricDiv3 = scmPriorStWork.UnSelTgtPricDiv3;
            //-----ADD BY lingxiaoqing  2011.08.08 -----------------<<<<<<<<<<<<<<<<<<
			
            return scmPriorSt;
		}
		
		/// <summary>
        /// クラスメンバーコピー処理（UIデータクラス⇒ワーククラス）
		/// </summary>
        /// <param name="scmPriorSt">UIデータクラス</param>
        /// <returns>ワーククラス</returns>
		/// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
		/// <br></br>
		/// </remarks>
        private SCMPriorStWork CopyToSCMPriorStWorkFromSCMPriorSt(SCMPriorSt scmPriorSt)
		{
            SCMPriorStWork scmPriorStWork = new SCMPriorStWork();

            scmPriorStWork.CreateDateTime = scmPriorSt.CreateDateTime;
            scmPriorStWork.UpdateDateTime = scmPriorSt.UpdateDateTime;
            scmPriorStWork.EnterpriseCode = scmPriorSt.EnterpriseCode;
            scmPriorStWork.FileHeaderGuid = scmPriorSt.FileHeaderGuid;
            scmPriorStWork.UpdEmployeeCode = scmPriorSt.UpdEmployeeCode;
            scmPriorStWork.UpdAssemblyId1 = scmPriorSt.UpdAssemblyId1;
            scmPriorStWork.UpdAssemblyId2 = scmPriorSt.UpdAssemblyId2;
            scmPriorStWork.LogicalDeleteCode = scmPriorSt.LogicalDeleteCode;
            scmPriorStWork.SectionCode = scmPriorSt.SectionCode;            

            scmPriorStWork.PrioritySettingCd1 = scmPriorSt.PrioritySettingCd1;      // 優先設定コード１
            scmPriorStWork.PrioritySettingNm1 = scmPriorSt.PrioritySettingNm1;      // 優先設定名称１
            scmPriorStWork.PrioritySettingCd2 = scmPriorSt.PrioritySettingCd2;      // 優先設定コード２
            scmPriorStWork.PrioritySettingNm2 = scmPriorSt.PrioritySettingNm2;      // 優先設定名称２
            scmPriorStWork.PrioritySettingCd3 = scmPriorSt.PrioritySettingCd3;      // 優先設定コード３
            scmPriorStWork.PrioritySettingNm3 = scmPriorSt.PrioritySettingNm3;      // 優先設定名称３
            scmPriorStWork.PrioritySettingCd4 = scmPriorSt.PrioritySettingCd4;      // 優先設定コード４
            scmPriorStWork.PrioritySettingNm4 = scmPriorSt.PrioritySettingNm4;      // 優先設定名称４
            scmPriorStWork.PrioritySettingCd5 = scmPriorSt.PrioritySettingCd5;      // 優先設定コード５
            scmPriorStWork.PrioritySettingNm5 = scmPriorSt.PrioritySettingNm5;      // 優先設定名称５

            scmPriorStWork.PriorPriceSetCd1 = scmPriorSt.PriorPriceSetCd1;          // 優先価格設定コード１
            scmPriorStWork.PriorPriceSetNm1 = scmPriorSt.PriorPriceSetNm1;          // 優先価格設定名称１
            scmPriorStWork.PriorPriceSetCd2 = scmPriorSt.PriorPriceSetCd2;          // 優先価格設定コード２
            scmPriorStWork.PriorPriceSetNm2 = scmPriorSt.PriorPriceSetNm2;          // 優先価格設定名称２
            scmPriorStWork.PriorPriceSetCd3 = scmPriorSt.PriorPriceSetCd3;          // 優先価格設定コード３
            scmPriorStWork.PriorPriceSetNm3 = scmPriorSt.PriorPriceSetNm3;          // 優先価格設定名称３
            scmPriorStWork.PriorPriceSetCd4 = scmPriorSt.PriorPriceSetCd4;          // 優先価格設定コード４
            scmPriorStWork.PriorPriceSetNm4 = scmPriorSt.PriorPriceSetNm4;          // 優先価格設定名称４
            scmPriorStWork.PriorPriceSetCd5 = scmPriorSt.PriorPriceSetCd5;          // 優先価格設定コード５
            scmPriorStWork.PriorPriceSetNm5 = scmPriorSt.PriorPriceSetNm5;          // 優先価格設定名称５

            //---------ADD BY lingxiaoqing------------>>>>>>>>>
            //得意先コード
            scmPriorStWork.CustomerCode = scmPriorSt.CustomerCode;
            //優先適用区分
            scmPriorStWork.PriorAppliDiv = scmPriorSt.PriorAppliDiv;
            //選択時対象純優区分    
            scmPriorStWork.SelTgtPureDiv = scmPriorSt.SelTgtPureDiv;
            //選択時対象在庫区分
            scmPriorStWork.SelTgtStckDiv = scmPriorSt.SelTgtStckDiv;
            //選択時対象キャンペーン区分
            scmPriorStWork.SelTgtCampDiv = scmPriorSt.SelTgtCampDiv;
            //非選択時対象純優区分    
            scmPriorStWork.UnSelTgtPureDiv = scmPriorSt.UnSelTgtPureDiv;
            //非選択時対象在庫区分
            scmPriorStWork.UnSelTgtStckDiv = scmPriorSt.UnSelTgtStckDiv;
            //非選択時対象キャンペーン区分
            scmPriorStWork.UnSelTgtCampDiv = scmPriorSt.UnSelTgtCampDiv;
            //選択時対象価格区分１
            scmPriorStWork.SelTgtPricDiv1 = scmPriorSt.SelTgtPricDiv1;
            //選択時対象価格区分２
            scmPriorStWork.SelTgtPricDiv2 = scmPriorSt.SelTgtPricDiv2;
            //選択時対象価格区分 3
            scmPriorStWork.SelTgtPricDiv3 = scmPriorSt.SelTgtPricDiv3;
            //非選択時対象価格区分１
            scmPriorStWork.UnSelTgtPricDiv1 = scmPriorSt.UnSelTgtPricDiv1;
            //非選択時対象価格区分２
            scmPriorStWork.UnSelTgtPricDiv2 = scmPriorSt.UnSelTgtPricDiv2;
            //非選択時対象価格区分 3
            scmPriorStWork.UnSelTgtPricDiv3 = scmPriorSt.UnSelTgtPricDiv3;
            //表示順7
            //---------ADD BY lingxiaoqing------------<<<<<<<<<<
            return scmPriorStWork;
		}
		#endregion
		
	}
}
