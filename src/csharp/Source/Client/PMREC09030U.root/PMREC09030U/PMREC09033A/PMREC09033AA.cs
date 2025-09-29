//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：お買得商品グループガイド
// プログラム概要   ：お買得商品グループアクセスクラス
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20073 西 毅
// 修正日    2015/02/24     修正内容：新規作成
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// お買得商品グループテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : お買得商品グループテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 20073 西 毅</br>
	/// <br>Date       : 2015.02.24</br>
    /// <br>------------------------------------------------------------------------------------</br>
	/// </remarks>
	public class RecBgnGrpAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IRecBgnGrpDB _iRecBgnGrpDB = null;

		/// <summary>
		/// お買得商品グループテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : お買得商品グループテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 20073 西 毅</br>
		/// <br>Date       : 2015.02.24</br>
		/// <br></br>
		/// </remarks>
        public RecBgnGrpAcs()
		{
			try
			{
				// リモートオブジェクト取得
                this._iRecBgnGrpDB = (IRecBgnGrpDB)MediationRecBgnGrpDB.GetRecBgnGrpDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
                this._iRecBgnGrpDB = null;
			}
		}

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

        /// <summary>
        /// 顧客全件検索
        /// </summary>
        /// <param name="retArray"></param>
        /// <param name="paraRec"></param>
        /// <returns></returns>
        public int Search(out RecBgnGrpRet[] retArray, string cnectOtherEpCd)
        {
            //RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = new RecBgnGrpSearchParaWork();
            //recBgnGrpSearchParaWork = CopyToParamDataFromUIData(paraRec);
            int count = 0;
            string errMsg = string.Empty;

            //object paraObj = recBgnGrpSearchParaWork;
            object retObj;
            ArrayList retList = new ArrayList();
            ArrayList recBgnGrpRetList = new ArrayList();
            //string cnectOtherEpCd = paraRec.InqOriginalEpCd;

            // 得意先検索 (論理削除行も取得)
            int status = this._iRecBgnGrpDB.Search(out retObj, cnectOtherEpCd, ConstantManagement.LogicalMode.GetData0, out count, ref errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList = retObj as ArrayList;

                if (retList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                else
                {
                    Hashtable pccCmpnyStHt = null;
                    foreach (RecBgnGrpWork retWork in retList)
                    {
                        recBgnGrpRetList.Add(this.CopyToUIDataFromParamData(retWork));
                    }
                }
            }

            retArray = (RecBgnGrpRet[])recBgnGrpRetList.ToArray(typeof(RecBgnGrpRet));

            return status;
        }
		
		/// <summary>
		/// 顧客全件検索
		/// </summary>
        /// <param name="retArray"></param>
        /// <param name="paraRec"></param>
		/// <returns></returns>
        public int Search(out RecBgnGrpRet[] retArray, RecBgnGrpPara paraRec)
		{
            RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = new RecBgnGrpSearchParaWork();
            recBgnGrpSearchParaWork = CopyToParamDataFromUIData(paraRec);
            object paraObj = (object)recBgnGrpSearchParaWork;
            object retObj;
			ArrayList retList = new ArrayList();
            ArrayList recBgnGrpRetList = new ArrayList();

            int count = 0;
            string errMsg = string.Empty;
            
            // 得意先検索 (論理削除行も取得)
            int status = this._iRecBgnGrpDB.Search(out retObj, paraObj, ConstantManagement.LogicalMode.GetData0, out count, ref errMsg);


			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				retList = retObj as ArrayList;

				if (retList == null)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
				else
				{
                    Hashtable pccCmpnyStHt = null;
                    foreach (RecBgnGrpWork retWork in retList)
                    {
                        recBgnGrpRetList.Add(this.CopyToUIDataFromParamData(retWork));
                    }
				}
			}

            retArray = (RecBgnGrpRet[])recBgnGrpRetList.ToArray(typeof(RecBgnGrpRet));

			return status;
		}
		
		/// <summary>
		/// クラスメンバーコピー処理（お買得商品グループワーククラス⇒お買得商品グループガイド結果クラス）
		/// </summary>
		/// <param name="customerSearchWork">お買得商品グループワーククラス</param>
		/// <returns>お買得商品グループ結果クラス</returns>
		/// <remarks>
		/// <br>Note       : お買得商品グループワーククラスからお買得商品グループクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 20073 西 毅</br>
		/// <br>Date       : 2015.02.24</br>
		/// </remarks>
        private RecBgnGrpRet CopyToUIDataFromParamData(RecBgnGrpWork recBgnGrpWork)
		{
            RecBgnGrpRet recBgnGrpRet = new RecBgnGrpRet();

			// 得意先情報
            //recBgnGrpWork.CreateDateTime = recBgnGrpSearchWork.CreateDateTime;            //作成日時
            //recBgnGrpWork.UpdateDateTime = recBgnGrpSearchWork.UpdateDateTime;            //更新日時
            recBgnGrpRet.LogicalDeleteCode = recBgnGrpWork.LogicalDeleteCode;      //論理削除区分
            recBgnGrpRet.InqOriginalEpCd = recBgnGrpWork.InqOriginalEpCd;          //問合せ元企業コード
            recBgnGrpRet.InqOriginalSecCd = recBgnGrpWork.InqOriginalSecCd;        //問合せ元拠点コード
            recBgnGrpRet.BrgnGoodsGrpCode = recBgnGrpWork.BrgnGoodsGrpCode;        //お買得商品グループコード
            recBgnGrpRet.DisplayOrder = recBgnGrpWork.DisplayOrder;                //表示順位
            recBgnGrpRet.BrgnGoodsGrpTitle = recBgnGrpWork.BrgnGoodsGrpTitle;      //お買得商品グループタイトル
            recBgnGrpRet.BrgnGoodsGrpTag = recBgnGrpWork.BrgnGoodsGrpTag;          //お買得商品グループコメントタグ
            recBgnGrpRet.BrgnGoodsGrpComment = recBgnGrpWork.BrgnGoodsGrpComment;  //お買得商品グループコメント

            return recBgnGrpRet;
		}


		/// <summary>
		/// クラスメンバーコピー処理（お買得商品グループ条件クラス⇒お買得商品グループガイドワーククラス）
		/// </summary>
        /// <param name="customerSearchPara">お買得商品グループ条件クラス</param>
		/// <returns>お買得商品グループワーククラス</returns>
		/// <remarks>
		/// <br>Note       : お買得商品グループ条件クラスからお買得商品グループワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 20073 西 毅</br>
		/// <br>Date       : 2015.02.24</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        private RecBgnGrpSearchParaWork CopyToParamDataFromUIData(RecBgnGrpPara recBgnGrpSearchWork)
		{
            RecBgnGrpSearchParaWork recBgnGrpSearchParaWork = new RecBgnGrpSearchParaWork();

            //recBgnGrpSearchParaWork.CreateDateTime = recBgnGrpSearchWork.CreateDateTime;
            //recBgnGrpSearchParaWork.UpdateDateTime = recBgnGrpSearchWork.UpdateDateTime;
            recBgnGrpSearchParaWork.LogicalDeleteCode = recBgnGrpSearchWork.LogicalDeleteCode;
            recBgnGrpSearchParaWork.InqOriginalEpCd = recBgnGrpSearchWork.InqOriginalEpCd;
            recBgnGrpSearchParaWork.InqOriginalSecCd = recBgnGrpSearchWork.InqOriginalSecCd;
            recBgnGrpSearchParaWork.BrgnGoodsGrpCode = recBgnGrpSearchWork.BrgnGoodsGrpCode;
            recBgnGrpSearchParaWork.DisplayOrder = recBgnGrpSearchWork.DisplayOrder;
            recBgnGrpSearchParaWork.BrgnGoodsGrpTitle = recBgnGrpSearchWork.BrgnGoodsGrpTitle;
            recBgnGrpSearchParaWork.BrgnGoodsGrpTag = recBgnGrpSearchWork.BrgnGoodsGrpTag;
            recBgnGrpSearchParaWork.BrgnGoodsGrpComment = recBgnGrpSearchWork.BrgnGoodsGrpComment;

            return recBgnGrpSearchParaWork;
		}


	}
}
