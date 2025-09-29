using System;
using System.Collections;
using System.Data;
using System.Reflection;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 見積初期値設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 見積初期値設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 980035 金沢　貞義</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br>UpdateNote : 2008/06/03 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>  
    /// <br>Update Note: 2009.07.13 20056 對馬 大輔</br>
    /// <br>             コンストラクタオーバーロード(拠点情報を取得しない)</br>
    /// </remarks>
    public class EstimateDefSetAcs
	{
		// リモートオブジェクト格納バッファ
        private IEstimateDefSetDB _iEstimateDefSetDB = null;

		// 拠点情報取得部品
		private SecInfoAcs      _secInfoAcs   = null;

		/// <summary>
        /// 見積初期値設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 見積初期値設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public EstimateDefSetAcs()
		{
			this._secInfoAcs = new SecInfoAcs(1);
			try {
				// リモートオブジェクト取得
                this._iEstimateDefSetDB = (IEstimateDefSetDB)MediationEstimateDefSetDB.GetEstimateDefSetDB();
			}
			catch(Exception) {
				// オフライン時はnullをセット
				this._iEstimateDefSetDB = null;
			}
		}

        // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 見積初期値設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <param name="mode">処理モード(0:通常(ﾃﾞﾌｫﾙﾄｺﾝｽﾄﾗｸﾀと同様) 1:拠点名称取得なし)</param>
        public EstimateDefSetAcs(int mode)
        {
            switch (mode)
            {
                case 0:
                    this._secInfoAcs = new SecInfoAcs(1);
                    break;
                case 1:
                    this._secInfoAcs = null;
                    break;
                default:
                    this._secInfoAcs = null;
                    break;
            }

            try
            {
                // リモートオブジェクト取得
                this._iEstimateDefSetDB = (IEstimateDefSetDB)MediationEstimateDefSetDB.GetEstimateDefSetDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iEstimateDefSetDB = null;
            }
        }
        // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int GetOnlineMode()
		{
			// オンラインモードを取得します
			if( this._iEstimateDefSetDB == null ) {
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
        /// 見積初期値設定読込処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の読み込みを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Read(out EstimateDefSet estimateDefSet, string enterpriseCode, string sectionCode)
		{
			int status = 0;

			try {
				estimateDefSet = null;

				// パラメータを設定
                EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();
				estimateDefSetWork.EnterpriseCode	= enterpriseCode;	// 企業コード
                estimateDefSetWork.SectionCode      = sectionCode;		// 拠点コード

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // 見積初期値設定読み込み
				status = this._iEstimateDefSetDB.Read( ref parabyte, 0 );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 見積初期値設定ワーククラスをデシリアライズ
                    estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // 見積初期値設定ワーククラスから見積初期値設定クラスへメンバコピー
					estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork( estimateDefSetWork );
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				estimateDefSet = null;
				this._iEstimateDefSetDB = null;

				// 通信エラーは-1を返す。
				return -1;
			}
		}

		/// <summary>
        /// 見積初期値設定登録・更新処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の登録・更新を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Write(ref EstimateDefSet estimateDefSet)
		{
			int status = 0;

			try {
                // 見積初期値設定クラスを見積初期値設定ワーククラスへメンバコピー
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);

				// XMLへ変換し、文字列のバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

				// 従業員目標実績を保存
				//status = this._iEstimateDefSetDB.Write( ref parabyte );
                Object paraObj = (object)estimateDefSetWork;
                status = this._iEstimateDefSetDB.Write(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 見積初期値設定ワーククラスをデシリアライズ
                    //estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // 見積初期値設定ワーククラスから見積初期値設定クラスへメンバコピー
                    ArrayList wklist = (ArrayList)paraObj;
                    estimateDefSetWork = wklist[0] as EstimateDefSetWork;
                    estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork(estimateDefSetWork);
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iEstimateDefSetDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
        /// 見積初期値設定論理削除処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の論理削除を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int LogicalDelete(ref EstimateDefSet estimateDefSet)
		{
			int status = 0;

			try {

                // 見積初期値設定クラスを見積初期値設定ワーククラスへメンバコピー
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);
				// XML変換し、文字列をバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // 見積初期値設定を論理削除
				//status = this._iEstimateDefSetDB.LogicalDelete( ref parabyte );
                Object paraObj = (object)estimateDefSetWork;
                status = this._iEstimateDefSetDB.LogicalDelete(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 見積初期値設定ワーククラスをデシリアライズ
                    //estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // 見積初期値設定ワーククラスを見積初期値設定クラスにメンバコピー
                    estimateDefSetWork = paraObj as EstimateDefSetWork;
                    estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork(estimateDefSetWork);
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iEstimateDefSetDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
        /// 見積初期値設定論理削除復活処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の論理削除復活を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Revival(ref EstimateDefSet estimateDefSet)
		{
			int status = 0;

			try {
                // 見積初期値設定クラスを見積初期値設定ワーククラスへメンバコピー
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);
				// XML変換し、文字列をバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // 見積初期値設定を復活
				//status = this._iEstimateDefSetDB.RevivalLogicalDelete( ref parabyte );
                Object paraObj = (object)estimateDefSetWork;
                status = this._iEstimateDefSetDB.RevivalLogicalDelete(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 見積初期値設定ワーククラスをデシリアライズ
                    //estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                    // 見積初期値設定ワーククラスを見積初期値設定クラスにメンバコピー
                    estimateDefSetWork = paraObj as EstimateDefSetWork;
                    estimateDefSet = CopyToEstimateDefSetFromEstimateDefSetWork(estimateDefSetWork);
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iEstimateDefSetDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
        /// 見積初期値設定物理削除処理
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の物理削除を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        public int Delete(EstimateDefSet estimateDefSet)
		{
			int status = 0;
			try {
                // 見積初期値設定クラスを見積初期値設定ワーククラスへメンバコピー
                EstimateDefSetWork estimateDefSetWork = CopyToEstimateDefSetWorkFromEstimateDefSet(estimateDefSet);
				// XML変換し、文字列をバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize( estimateDefSetWork );

                // 見積初期値設定物理削除
				status = this._iEstimateDefSetDB.Delete( parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullを設定
				this._iEstimateDefSetDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
        /// 見積初期値設定検索処理(論理削除データ除く)
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の検索処理を行います。論理削除データは抽出対象外です。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int Search( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, 0 );
		}

		/// <summary>
        /// 見積初期値設定検索処理(論理削除データ含む)
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int SearchAll( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01 );
		}

		/// <summary>
        /// 見積初期値設定検索処理(メイン)
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定の検索処理を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int SearchProc( out ArrayList retList, string enterpriseCode, 
			ConstantManagement.LogicalMode logicalMode )
		{
			int status = 0;
			
			retList = new ArrayList();
			retList.Clear();

            EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();
			estimateDefSetWork.EnterpriseCode = enterpriseCode;		// 企業コード

			ArrayList wkList = new ArrayList();
			wkList.Clear();

			object paraobj	= estimateDefSetWork;
			object retobj	= null;

            // 見積初期値設定全件検索
			status = this._iEstimateDefSetDB.Search( out retobj, paraobj, 0, logicalMode );

			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				wkList = retobj as ArrayList;
				if( wkList != null ) {
                    foreach (EstimateDefSetWork wkEstimateDefSetWork in wkList)
                    {
						retList.Add( CopyToEstimateDefSetFromEstimateDefSetWork( wkEstimateDefSetWork ) );
					}
				}
			}

			return status;
		}

		/// <summary>
        /// クラスメンバコピー処理(見積初期値設定ワーククラス→見積初期値設定クラス)
		/// </summary>
        /// <param name="estimateDefSetWork">見積初期値設定ワーククラス</param>
        /// <returns>見積初期値設定クラス</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定ワーククラスから見積初期値設定クラスへメンバコピーを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private EstimateDefSet CopyToEstimateDefSetFromEstimateDefSetWork(EstimateDefSetWork estimateDefSetWork)
		{
            EstimateDefSet estimateDefSet = new EstimateDefSet();

			// 共通ヘッダ
			estimateDefSet.CreateDateTime		= estimateDefSetWork.CreateDateTime;
			estimateDefSet.UpdateDateTime		= estimateDefSetWork.UpdateDateTime;
			estimateDefSet.EnterpriseCode		= estimateDefSetWork.EnterpriseCode;
			estimateDefSet.FileHeaderGuid		= estimateDefSetWork.FileHeaderGuid;
			estimateDefSet.UpdEmployeeCode		= estimateDefSetWork.UpdEmployeeCode;
			estimateDefSet.UpdAssemblyId1		= estimateDefSetWork.UpdAssemblyId1;
			estimateDefSet.UpdAssemblyId2		= estimateDefSetWork.UpdAssemblyId2;
			estimateDefSet.LogicalDeleteCode	= estimateDefSetWork.LogicalDeleteCode;

            estimateDefSet.SectionCode          = estimateDefSetWork.SectionCode;           // 拠点コード
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSet.FractionProcCd       = estimateDefSetWork.FractionProcCd;		// 端数処理区分
            estimateDefSet.ConsTaxLayMethod     = estimateDefSetWork.ConsTaxLayMethod;	    // 消費税転嫁方式
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSet.ListPricePrintDiv    = estimateDefSetWork.ListPricePrintDiv;     // 定価印刷区分
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSet.EraNameDispCd1		= estimateDefSetWork.EraNameDispCd1;		// 元号表示区分１
            estimateDefSet.EstimateTotalPrtCd   = estimateDefSetWork.EstimateTotalPrtCd;    // 見積合計印刷区分
            estimateDefSet.EstimateFormPrtCd    = estimateDefSetWork.EstimateFormPrtCd;     // 見積書印刷区分
            estimateDefSet.HonorificTitlePrtCd  = estimateDefSetWork.HonorificTitlePrtCd;   // 敬称印刷区分
            estimateDefSet.EstimateRequestCd    = estimateDefSetWork.EstimateRequestCd;     // 見積依頼区分
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSet.EstmFormNoPickDiv    = estimateDefSetWork.EstmFormNoPickDiv;     // 見積書番号採番区分
            estimateDefSet.EstimateTitle1       = estimateDefSetWork.EstimateTitle1;        // 見積タイトル１
            estimateDefSet.EstimateNote1        = estimateDefSetWork.EstimateNote1;         // 見積備考１
            estimateDefSet.EstimateNote2        = estimateDefSetWork.EstimateNote2;         // 見積備考２
            estimateDefSet.EstimateNote3        = estimateDefSetWork.EstimateNote3;         // 見積備考３
            estimateDefSet.EstimatePrtDiv       = estimateDefSetWork.EstimatePrtDiv;        // 見積書発行区分
            //estimateDefSet.EstimateReqPrtDiv    = estimateDefSetWork.EstimateReqPrtDiv;     // 見積依頼書発行区分  // DEL 2008/06/06
            //estimateDefSet.EstimateConfPrtDiv   = estimateDefSetWork.EstimateConfPrtDiv;    // 見積確認書発行区分  // DEL 2008/06/06
            estimateDefSet.FaxEstimatetDiv      = estimateDefSetWork.FaxEstimatetDiv;       // ＦＡＸ見積区分
            estimateDefSet.ConsTaxPrintDiv      = estimateDefSetWork.ConsTaxPrintDiv;       // 消費税印刷区分
            // --- ADD 2008/06/03 -------------------------------->>>>>
            estimateDefSet.PartsNoPrtCd = estimateDefSetWork.PartsNoPrtCd;                  // 品番印字区分
            estimateDefSet.OptionPringDivCd = estimateDefSetWork.OptionPringDivCd;          // オプション印字区分
            estimateDefSet.PartsSelectDivCd = estimateDefSetWork.PartsSelectDivCd;          // 部品選択区分
            estimateDefSet.PartsSearchDivCd = estimateDefSetWork.PartsSearchDivCd;          // 部品検索区分
            estimateDefSet.EstimateDtCreateDiv = estimateDefSetWork.EstimateDtCreateDiv;    // 見積データ作成区分
            estimateDefSet.EstimateValidityTerm = estimateDefSetWork.EstimateValidityTerm;  // 見積書有効期限
            estimateDefSet.RateUseCode = estimateDefSetWork.RateUseCode;                    // 掛率使用区分
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return estimateDefSet;
		}

		/// <summary>
        /// クラスメンバコピー処理(見積初期値設定クラス→見積初期値設定ワーククラス)
		/// </summary>
        /// <param name="estimateDefSet">見積初期値設定クラス</param>
        /// <returns>見積初期値設定ワーククラス</returns>
		/// <remarks>
        /// <br>Note       : 見積初期値設定クラスから見積初期値設定ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private EstimateDefSetWork CopyToEstimateDefSetWorkFromEstimateDefSet(EstimateDefSet estimateDefSet)
		{
            EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();

			// 共通ヘッダ
			estimateDefSetWork.CreateDateTime		= estimateDefSet.CreateDateTime;
			estimateDefSetWork.UpdateDateTime		= estimateDefSet.UpdateDateTime;
			estimateDefSetWork.EnterpriseCode		= estimateDefSet.EnterpriseCode;
			estimateDefSetWork.FileHeaderGuid		= estimateDefSet.FileHeaderGuid;
			estimateDefSetWork.UpdEmployeeCode		= estimateDefSet.UpdEmployeeCode;
			estimateDefSetWork.UpdAssemblyId1		= estimateDefSet.UpdAssemblyId1.TrimEnd();
			estimateDefSetWork.UpdAssemblyId2		= estimateDefSet.UpdAssemblyId2.TrimEnd();
			estimateDefSetWork.LogicalDeleteCode	= estimateDefSet.LogicalDeleteCode;

            estimateDefSetWork.SectionCode          = estimateDefSet.SectionCode;           // 拠点コード

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// --- ADD 2008/06/03 -------------------------------->>>>>
            //foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //{
            //    if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
            //    {
            //        estimateDefSetWork.SectionGuideNm = si.SectionGuideNm;
            //        break;
            //    }
            //}
            //// --- ADD 2008/06/03 --------------------------------<<<<< 

            if (this._secInfoAcs != null)
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
                    {
                        estimateDefSetWork.SectionGuideNm = si.SectionGuideNm;
                        break;
                    }
                }
            }
            else
            {
                estimateDefSetWork.SectionGuideNm = string.Empty;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSetWork.FractionProcCd       = estimateDefSet.FractionProcCd;		// 端数処理区分
            estimateDefSetWork.ConsTaxLayMethod     = estimateDefSet.ConsTaxLayMethod;	    // 消費税転嫁方式
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSetWork.ListPricePrintDiv    = estimateDefSet.ListPricePrintDiv;     // 定価印刷区分
            /* --- DEL 2008/06/03 -------------------------------->>>>>
            estimateDefSetWork.EraNameDispCd1       = estimateDefSet.EraNameDispCd1;		// 元号表示区分１
            estimateDefSetWork.EstimateTotalPrtCd   = estimateDefSet.EstimateTotalPrtCd;    // 見積合計印刷区分
            estimateDefSetWork.EstimateFormPrtCd    = estimateDefSet.EstimateFormPrtCd;     // 見積書印刷区分
            estimateDefSetWork.HonorificTitlePrtCd  = estimateDefSet.HonorificTitlePrtCd;   // 敬称印刷区分
            estimateDefSetWork.EstimateRequestCd    = estimateDefSet.EstimateRequestCd;     // 見積依頼区分
               --- DEL 2008/06/03 --------------------------------<<<<< */
            estimateDefSetWork.EstmFormNoPickDiv    = estimateDefSet.EstmFormNoPickDiv;     // 見積書番号採番区分
            estimateDefSetWork.EstimateTitle1       = estimateDefSet.EstimateTitle1;        // 見積タイトル１
            estimateDefSetWork.EstimateNote1        = estimateDefSet.EstimateNote1;         // 見積備考１
            estimateDefSetWork.EstimateNote2        = estimateDefSet.EstimateNote2;         // 見積備考２
            estimateDefSetWork.EstimateNote3        = estimateDefSet.EstimateNote3;         // 見積備考３
            estimateDefSetWork.EstimatePrtDiv       = estimateDefSet.EstimatePrtDiv;        // 見積書発行区分
            //estimateDefSetWork.EstimateReqPrtDiv    = estimateDefSet.EstimateReqPrtDiv;     // 見積依頼書発行区分  // DEL 2008/06/06
            //estimateDefSetWork.EstimateConfPrtDiv   = estimateDefSet.EstimateConfPrtDiv;    // 見積確認書発行区分  // DEL 2008/06/06
            estimateDefSetWork.FaxEstimatetDiv      = estimateDefSet.FaxEstimatetDiv;       // ＦＡＸ見積区分
            estimateDefSetWork.ConsTaxPrintDiv      = estimateDefSet.ConsTaxPrintDiv;       // 消費税印刷区分
            // --- ADD 2008/06/03 -------------------------------->>>>>
            estimateDefSetWork.PartsNoPrtCd         = estimateDefSet.PartsNoPrtCd;          // 品番印字区分
            estimateDefSetWork.OptionPringDivCd     = estimateDefSet.OptionPringDivCd;      // オプション印字区分
            estimateDefSetWork.PartsSelectDivCd     = estimateDefSet.PartsSelectDivCd;      // 部品選択区分
            estimateDefSetWork.PartsSearchDivCd     = estimateDefSet.PartsSearchDivCd;      // 部品検索区分
            estimateDefSetWork.EstimateDtCreateDiv  = estimateDefSet.EstimateDtCreateDiv;   // 見積データ作成区分
            estimateDefSetWork.EstimateValidityTerm = estimateDefSet.EstimateValidityTerm;  // 見積書有効期限
            estimateDefSetWork.RateUseCode          = estimateDefSet.RateUseCode;           // 掛率使用区分
            // --- ADD 2008/06/03 --------------------------------<<<<< 

			return estimateDefSetWork;
		}
	}
}
