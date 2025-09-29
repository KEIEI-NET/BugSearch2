using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.LocalAccess; // ADD 2010/05/18

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// 自由帳票選択ガイドアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       	: 自由帳票選択ガイドのアクセスクラスです。</br>
    /// <br>Programmer 	: 30015　橋本　裕毅</br>
    /// <br>Date       	: 2007.04.27</br>
    /// <br>Update Note : 2008.03.18 30015 橋本　裕毅</br>
    /// <br>            : 自由帳票第一次改良案件　印刷ダイアログ起動速度Up対応</br>
    /// <br>Update Note : 2010/05/18 22008 長内 数馬</br>
    /// <br>            : ローカルＤＢ対応</br>
    /// </remarks>
    public class FrePrtGuideAcs
    {
	    /// <summary>
		/// 自由帳票選択ガイドアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票選択ガイドアクセスクラスの新しいインスタンスを初期化します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.04.27</br>
        /// <br></br>
        /// <br>Update Note : 2010/05/18 22008 長内 数馬</br>
        /// <br>            : ローカルＤＢ対応</br>
        /// </remarks>
        public FrePrtGuideAcs()
        {
			try
			{
                // リモートオブジェクト取得
                // -- UPD 2010/05/18 ------------------------------------------>>>
                //this._iFPprSchmGrDB = (IFPprSchmGrDB)MediationFPprSchmGrDB.GetFPprSchmGrDB();
                this._iFPprSchmGrDB = new FPprSchmGrLcDB();
                // -- UPD 2010/05/18 ------------------------------------------<<<
                
                this._iFrePrtPSetDLDB = (IFrePrtPSetDLDB)MediationFrePrtPSetDLDB.GetFrePrtPSetDLDB();
			}
			catch (Exception)
			{				
                //オフライン時はnullをセット
                this._iFPprSchmGrDB = null;
                this._iFrePrtPSetDLDB = null;
			}
        }
        
        // -- UPD 2010/05/18 --------------------------------------->>>
        //private IFPprSchmGrDB _iFPprSchmGrDB = null; // 自由帳票スキーマグループマスタインターフェース
        private FPprSchmGrLcDB _iFPprSchmGrDB = null; // 自由帳票スキーマグループマスタローカルＤＢアクセス
        // -- UPD 2010/05/18 ---------------------------------------<<<
        private IFrePrtPSetDLDB _iFrePrtPSetDLDB = null; // 自由帳票印字位置設定マスタインターフェース
        
		/// <summary>
		/// 自由帳票スキーマグループマスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="printPaperUseDivcd">帳票使用区分</param>
        /// <param name="printPaperDivCd">帳票区分コード</param>
        /// <param name="dataInputSystemArray">データ入力システム配列</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票スキーマグループマスタの検索処理を行います。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.22</br>
		/// </remarks>
        public int SearchFPprSchmGr(out ArrayList retList, out bool msgDiv, out string errMsg, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            retList = new ArrayList();
            retList.Clear();
            FPprSchmGrWork[] wkList = new FPprSchmGrWork[0];

            object retobj = null;
            // 自由帳票スキーマグループマスタ検索処理
            status = this._iFPprSchmGrDB.SearchFPprSchmGr(out retobj, out msgDiv, out errMsg, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray);

            if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as FPprSchmGrWork[];

                foreach (FPprSchmGrWork wkFPprSchmGrWork in wkList)
                {
                    retList.Add(CopyToFPprSchmGrFromFPprSchmGrWork(wkFPprSchmGrWork));
                }
            }
            
            return status;

        }

		/// <summary>
		/// 自由帳票抽出条件設定マスタ検索処理
		/// </summary>
		/// <param name="enterprisecode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票使用区分</param>
        /// <param name="printPaperDivCd">帳票区分コード</param>
        /// <param name="dataInputSystemArray">データ入力システム配列</param>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票抽出条件設定マスタの検索処理を行います。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.22</br>
		/// </remarks>
        public int SearchFrePrtPSetDLDB(string enterprisecode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray, out ArrayList retList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            retList = new ArrayList();
            retList.Clear();
            FrePrtPSetWork[] wkList = new FrePrtPSetWork[0];

            FrePrtPSetWork[] al;
            byte[] retbyte;
            // 自由帳票印字位置設定マスタ検索処理
            status = this._iFrePrtPSetDLDB.Search(enterprisecode, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray, out retbyte, out msgDiv, out errMsg);
            if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
				// XMLの読み込み
				al = (FrePrtPSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(FrePrtPSetWork[]));
                for (int i = 0; i < al.Length; i++)
                {
                    //サーチ結果取得
					FrePrtPSetWork wkFrePrtPSetWork = (FrePrtPSetWork)al[i];
                    retList.Add(CopyToFrePrtPSetFromFrePrtPSetWork(wkFrePrtPSetWork));
                }
            }
            return status;

        }

		/// <summary>
		/// クラスメンバーコピー処理（自由帳票スキーマグループワーククラス⇒自由帳票スキーマグループクラス）
		/// </summary>
		/// <param name="fPprSchmGrWork">自由帳票スキーマグループワーククラス</param>
		/// <returns>自由帳票スキーマグループクラス</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票スキーマグループワーククラスから自由帳票スキーマグループクラスへメンバーのコピーを行います。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.22</br>
		/// </remarks>
        private FPprSchmGr CopyToFPprSchmGrFromFPprSchmGrWork(FPprSchmGrWork fPprSchmGrWork)
        {
            FPprSchmGr fPprSchmGr = new FPprSchmGr();

            fPprSchmGr.CreateDateTime       = fPprSchmGrWork.CreateDateTime;        // 作成日付
            fPprSchmGr.UpdateDateTime       = fPprSchmGrWork.UpdateDateTime;        // 更新日付
            fPprSchmGr.LogicalDeleteCode    = fPprSchmGrWork.LogicalDeleteCode;     // 論理削除区分
            fPprSchmGr.FreePrtPprSchmGrpCd  = fPprSchmGrWork.FreePrtPprSchmGrpCd;   // 自由帳票スキーマグループコード
            fPprSchmGr.OutputFormFileName   = fPprSchmGrWork.OutputFormFileName;    // 出力ファイル名
            fPprSchmGr.OutputFileClassId    = fPprSchmGrWork.OutputFileClassId;     // 出力クラスID
            fPprSchmGr.FreePrtPprItemGrpCd  = fPprSchmGrWork.FreePrtPprItemGrpCd;   // 自由帳票項目グループコード
            fPprSchmGr.DisplayName          = fPprSchmGrWork.DisplayName;           // 出力名称
            fPprSchmGr.DataInputSystem      = fPprSchmGrWork.DataInputSystem;       // データ入力システム
            fPprSchmGr.PrintPaperDivCd      = fPprSchmGrWork.PrintPaperDivCd;       // 帳票区分コード
            fPprSchmGr.PrintPaperUseDivcd   = fPprSchmGrWork.PrintPaperUseDivcd;    // 帳票使用区分
			fPprSchmGr.SpecialConvtUseDivCd = fPprSchmGrWork.SpecialConvtUseDivCd;  // 特殊コンバート使用区分
			fPprSchmGr.OptionCode			= fPprSchmGrWork.OptionCode;			// オプションコード
			fPprSchmGr.FormFeedLineCount	= fPprSchmGrWork.FormFeedLineCount;		// 改頁行数
			fPprSchmGr.CrCharCnt			= fPprSchmGrWork.CrCharCnt;				// 改行文字数
			fPprSchmGr.TopMargin			= fPprSchmGrWork.TopMargin;				// 上余白
			fPprSchmGr.LeftMargin			= fPprSchmGrWork.LeftMargin;			// 左余白
			fPprSchmGr.RightMargin			= fPprSchmGrWork.RightMargin;			// 右余白
			fPprSchmGr.BottomMargin			= fPprSchmGrWork.BottomMargin;			// 下余白

            return fPprSchmGr;
        }

		/// <summary>
		/// クラスメンバーコピー処理（自由帳票抽出条件設定ワーククラス⇒自由帳票抽出条件設定クラス）
		/// </summary>
		/// <param name="frePrtPSetWork">自由帳票抽出条件設定ワーククラス</param>
		/// <returns>自由帳票抽出条件設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票抽出条件設定ワーククラスから自由帳票抽出条件設定クラスへメンバーのコピーを行います。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.22</br>
		/// </remarks>
        private FrePrtPSet CopyToFrePrtPSetFromFrePrtPSetWork(FrePrtPSetWork frePrtPSetWork)
        {
            FrePrtPSet frePrtPSet = new FrePrtPSet();
            frePrtPSet.UpdateDateTime       = frePrtPSetWork.UpdateDateTime;       // 更新日付
            frePrtPSet.EnterpriseCode       = frePrtPSetWork.EnterpriseCode;       // 企業コード
            frePrtPSet.OutputFormFileName   = frePrtPSetWork.OutputFormFileName;   // 出力ファイル名
            frePrtPSet.UserPrtPprIdDerivNo  = frePrtPSetWork.UserPrtPprIdDerivNo;  // ユーザー帳票ID枝番号
            frePrtPSet.DisplayName          = frePrtPSetWork.DisplayName;          // 出力名称
            frePrtPSet.FreePrtPprItemGrpCd  = frePrtPSetWork.FreePrtPprItemGrpCd;  // 自由帳票項目グループコード
            frePrtPSet.PrtPprUserDerivNoCmt = frePrtPSetWork.PrtPprUserDerivNoCmt; // 帳票ユーザー枝番コメント
            frePrtPSet.DataInputSystem      = frePrtPSetWork.DataInputSystem;      // データ入力システム
			// 2008.03.18 Hiroki Hashimoto Add Sta >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			frePrtPSet.OutConfimationMsg    = frePrtPSetWork.OutConfimationMsg;    // 出力確認メッセージ
			frePrtPSet.FreePrtPprSpPrpseCd	= frePrtPSetWork.FreePrtPprSpPrpseCd;  // 自由帳票 特種用途区分
			frePrtPSet.OptionCode			= frePrtPSetWork.OptionCode;		   // オプションコード
			frePrtPSet.PrintPaperDivCd		= frePrtPSetWork.PrintPaperDivCd;      // 帳票使用区分
			frePrtPSet.PrintPaperUseDivcd	= frePrtPSetWork.PrintPaperUseDivcd;   // 帳票区分コード
			// 2008.03.18 Hiroki Hashimoto Add End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return frePrtPSet;
        
        }
    

    }
}
