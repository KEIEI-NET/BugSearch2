//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリストアクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/07/22  修正内容 : 帳票印字項目一覧の記載内容変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/07/22  修正内容 : ログメッセージの変更
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売価原価アンマッチリストアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価原価アンマッチリストで使用するデータを取得する。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.07</br>
    /// <br></br>
    /// </remarks>
    public class RateUnMatchAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 売価原価アンマッチリストアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売価原価アンマッチリストアクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 劉学智</br>
	    /// <br>Date       : 2009.04.07</br>
		/// </remarks>
		public RateUnMatchAcs()
		{
            this._iRateUnMatchDB = (IRateUnMatchDB)MediationRateUnMatchDB.GetRateUnMatchDB();
            this.goodsAcs = new GoodsAcs();
		}

		/// <summary>
        /// 売価原価アンマッチリスト表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売価原価アンマッチリスト表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static RateUnMatchAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
			
			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        private GoodsAcs goodsAcs;
        #endregion ■ Static Member

        #region ■ Private Member
        IRateUnMatchDB _iRateUnMatchDB;                 // 売価原価アンマッチリストリモート
        private DataSet _rateUnMatchDs;				    // 売価原価アンマッチリストデータセット
        private Int32 _delUnitPriceKind1Cnt;            // 売価削除件数
        private Int32 _delUnitPriceKind2Cnt;            // 原価削除件数
        private Int32 _delUnitPriceKind3Cnt;            // 価格削除件数
        private const string ct_UIPGID = "PMHNB02200U";
        private const string ct_UIPGNM = "売価原価アンマッチリスト";
        private const string ct_SPACE = "　";
        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// 売価原価アンマッチリストデータセット(読み取り専用)
        /// </summary>
        public DataSet RateUnMatchDs
        {
            get { return this._rateUnMatchDs; }
        }

        /// <summary>
        /// 売価削除件数(読み取り専用)
        /// </summary>
        public Int32 DelUnitPriceKind1Cnt
        {
            get { return this._delUnitPriceKind1Cnt; }
        }

        /// <summary>
        /// 原価削除件数(読み取り専用)
        /// </summary>
        public Int32 DelUnitPriceKind2Cnt
        {
            get { return this._delUnitPriceKind2Cnt; }
        }

        /// <summary>
        /// 価格削除件数(読み取り専用)
        /// </summary>
        public Int32 DelUnitPriceKind3Cnt
        {
            get { return this._delUnitPriceKind3Cnt; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ データ取得
        /// <summary>
        /// 売価原価アンマッチリストデータ取得
        /// </summary>
        /// <param name="rateUnMatchCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する売価原価アンマッチリストデータを取得する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int Search(RateUnMatchCndtn rateUnMatchCndtn, out string errMsg)
        {
            int status = this.SearchProc(rateUnMatchCndtn, out errMsg);

            return status;
        }
        #endregion
        #endregion ◆ 出力データ取得

        #region ◆ 削除データ取得
        #region ◎ 削除データ取得
        /// <summary>
        /// 売価原価アンマッチリスト削除データ取得
        /// </summary>
        /// <param name="rateUnMatchCndtn">抽出条件</param>
        /// <param name="delList">削除データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する売価原価アンマッチリスト削除データを取得する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int SearchAllForDelete(RateUnMatchCndtn rateUnMatchCndtn, out ArrayList delList, out string errMsg)
        {
            delList = new ArrayList();

            int status = this.SearchProc(rateUnMatchCndtn, out errMsg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = this.SearchAll(this._rateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch], out delList, out errMsg);
            }
            return status;
        }
        #endregion

        #region ◎ 削除データ取得処理
        /// <summary>
        /// 削除データ取得処理
        /// </summary>
        /// <param name="dt">検索したデータテーブル</param>
        /// <param name="delList">削除用の全てデータ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 削除データ取得処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int SearchAll(DataTable dt, out ArrayList delList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            delList = new ArrayList();
            try
            {
                RateAcs rateAcs = new RateAcs();
                ArrayList rateList = new ArrayList();
                foreach (DataRow dr in dt.Rows)
                {
                    Rate rate = new Rate();
                    // 企業コード
                    rate.EnterpriseCode = dr[RateUnMatchResult.Col_EnterpriseCode].ToString();
                    // 拠点コード
                    rate.SectionCode = dr[RateUnMatchResult.Col_SectionCode].ToString();
                    // 単価掛率設定区分
                    rate.UnitRateSetDivCd = dr[RateUnMatchResult.Col_UnitRateSetDivCd].ToString();
                    // 単価種類
                    rate.UnitPriceKind = dr[RateUnMatchResult.Col_UnitPriceKindCd].ToString();
                    // 掛率設定区分
                    rate.RateSettingDivide = dr[RateUnMatchResult.Col_RateSettingDivide].ToString();
                    // 商品メーカーコード
                    rate.GoodsMakerCd = Convert.ToInt32(dr[RateUnMatchResult.Col_GoodsMakerCd].ToString());
                    // 商品番号
                    rate.GoodsNo = dr[RateUnMatchResult.Col_GoodsNo].ToString();
                    // 商品掛率ランク
                    rate.GoodsRateRank = dr[RateUnMatchResult.Col_GoodsRateRank].ToString();
                    // 商品掛率グループコード
                    rate.GoodsRateGrpCode = Convert.ToInt32(dr[RateUnMatchResult.Col_GoodsRateGrpCode].ToString());
                    // BLグループコード
                    rate.BLGroupCode = Convert.ToInt32(dr[RateUnMatchResult.Col_BLGroupCode].ToString());
                    // BL商品コード
                    rate.BLGoodsCode = Convert.ToInt32(dr[RateUnMatchResult.Col_BLGoodsCode].ToString());
                    // 得意先コード
                    rate.CustomerCode = Convert.ToInt32(dr[RateUnMatchResult.Col_CustomerCode].ToString());
                    // 得意先掛率グループコード
                    rate.CustRateGrpCode = Convert.ToInt32(dr[RateUnMatchResult.Col_CustRateGrpCode].ToString());
                    // 仕入先コード
                    rate.SupplierCd = Convert.ToInt32(dr[RateUnMatchResult.Col_SupplierCd].ToString());

                    // 掛率マスタの検索処理
                    int subStatus = rateAcs.SearchAll(out rateList, ref rate, out errMsg);
                    if (subStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foreach (Rate rateObj in rateList)
                        {
                            RateUnMatchWork rateUnMatchWork = new RateUnMatchWork();
                            // 更新日時
                            rateUnMatchWork.UpdateDateTime = rateObj.UpdateDateTime;
                            // 論理削除区分
                            rateUnMatchWork.LogicalDeleteCode = rateObj.LogicalDeleteCode;
                            // 企業コード
                            rateUnMatchWork.EnterpriseCode = rateObj.EnterpriseCode;
                            // 拠点コード
                            rateUnMatchWork.SectionCode = rateObj.SectionCode;
                            // 単価掛率設定区分
                            rateUnMatchWork.UnitRateSetDivCd = rateObj.UnitRateSetDivCd;
                            // 単価種類
                            rateUnMatchWork.UnitPriceKindCd = rateObj.UnitPriceKind;
                            // 掛率設定区分
                            rateUnMatchWork.RateSettingDivide = rateObj.RateSettingDivide;
                            // 商品メーカーコード
                            rateUnMatchWork.GoodsMakerCd = rateObj.GoodsMakerCd;
                            // 商品番号
                            rateUnMatchWork.GoodsNo = rateObj.GoodsNo;
                            // 商品掛率ランク
                            rateUnMatchWork.GoodsRateRank = rateObj.GoodsRateRank;
                            // 商品掛率グループコード
                            rateUnMatchWork.GoodsRateGrpCode = rateObj.GoodsRateGrpCode;
                            // BLグループコード
                            rateUnMatchWork.BLGroupCode = rateObj.BLGroupCode;
                            // BL商品コード
                            rateUnMatchWork.BLGoodsCode = rateObj.BLGoodsCode;
                            // 得意先コード
                            rateUnMatchWork.CustomerCode = rateObj.CustomerCode;
                            // 得意先掛率グループコード
                            rateUnMatchWork.CustRateGrpCode = rateObj.CustRateGrpCode;
                            // 仕入先コード
                            rateUnMatchWork.SupplierCd = rateObj.SupplierCd;
                            // ロット数
                            rateUnMatchWork.LotCount = rateObj.LotCount;
                            // 内容
                            rateUnMatchWork.Content = dr[RateUnMatchResult.Col_Content].ToString();
                            delList.Add(rateUnMatchWork);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 削除データ取得処理
        #endregion ◆ 削除データ取得

        #region ◆ 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="delList">データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 削除処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int Delete(ArrayList delList, out string errMsg)
        {
            int status = this.DeleteProc(delList, out errMsg);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ログ処理
                this.WriteLog(delList, out errMsg);
            }
            return status;
        }
        #endregion ◆ 削除処理

        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 売価原価アンマッチリストデータ取得
        /// <summary>
        /// 売価原価アンマッチリストデータ取得
        /// </summary>
        /// <param name="rateUnMatchCndtn"></param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する売価原価アンマッチリストデータを取得する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int SearchProc(RateUnMatchCndtn rateUnMatchCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                // DataTable Create ----------------------------------------------------------
                RateUnMatchResult.CreateDataTableResultRateUnMatch(ref this._rateUnMatchDs);

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                status = this._iRateUnMatchDB.Search(out retList, rateUnMatchCndtn.SectionCodes);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevRateUnMatchWorkListData(rateUnMatchCndtn, this._rateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch], (ArrayList)retList);
                        if (this._rateUnMatchDs.Tables[RateUnMatchResult.Tbl_Result_RateUnMatch].Rows.Count > 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "売価原価アンマッチリストデータの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◆ 提供データのチェック処理
        /// <summary>
        /// 提供データのチェック処理
        /// </summary>
        /// <param name="rateUnMatchWork">抽出したデータ</param>
        /// <param name="isDelete">チェック結果</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : チェック処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int CheckProc(ref RateUnMatchWork rateUnMatchWork, out bool isDelete, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            isDelete = false;
            errMsg = string.Empty;
            try
            {
                // 商品名が空白の場合、ローカル商品マスタのチェックを行います
                if (rateUnMatchWork.GoodsNm == null || String.IsNullOrEmpty(rateUnMatchWork.GoodsNm))
                {
                    GoodsCndtn goodCndtn = new GoodsCndtn();
                    goodCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    goodCndtn.SectionCode = rateUnMatchWork.SectionCode.Trim();
                    goodCndtn.GoodsMakerCd = rateUnMatchWork.GoodsMakerCd;
                    goodCndtn.GoodsNo = rateUnMatchWork.GoodsNo;
                    goodCndtn.GoodsNoSrchTyp = 0;
                    goodCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

                    List<GoodsUnitData> list = new List<GoodsUnitData>();
                    string msg = "";
                    status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodCndtn, out list, out msg);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // 提供データに存在する場合
                        if (list != null && list.Count > 0)
                        {
                            if (rateUnMatchWork.IsErrRateProtyMng == "0"
                                && rateUnMatchWork.IsAllZero == "0"
                                && rateUnMatchWork.IsErrGoodsU == "1")
                            {
                                // 商品マスタチェックがエラーだけの場合、該当レコードを外す
                                isDelete = true;
                            }
                            else
                            {
                                // 提供データに存在する
                                rateUnMatchWork.IsErrGoodsU = "0";
                                // 品名をセットする
                                rateUnMatchWork.GoodsNm = ((GoodsUnitData)list[0]).GoodsNameKana;
                            }
                        }
                    }

                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◆ チェック処理

        #region ◆ 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="delList">削除データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 削除処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int DeleteProc(ArrayList delList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                this._delUnitPriceKind1Cnt = 0;
                this._delUnitPriceKind2Cnt = 0;
                this._delUnitPriceKind3Cnt = 0;
                RateAcs rateAcs = new RateAcs();
                IRateDB iRateDB = (IRateDB)MediationRateDB.GetRateDB();
                ArrayList delRateList = new ArrayList();
                foreach (RateUnMatchWork rateUnMatchWork in delList)
                {
                    Rate rate = new Rate();
                    // 更新日時
                    rate.UpdateDateTime = rateUnMatchWork.UpdateDateTime;
                    // 企業コード
                    rate.EnterpriseCode = rateUnMatchWork.EnterpriseCode;
                    // 拠点コード
                    rate.SectionCode = rateUnMatchWork.SectionCode;
                    // 単価掛率設定区分
                    rate.UnitRateSetDivCd = rateUnMatchWork.UnitRateSetDivCd;
                    // 単価種類
                    rate.UnitPriceKind = rateUnMatchWork.UnitPriceKindCd;
                    // 掛率設定区分
                    rate.RateSettingDivide = rateUnMatchWork.RateSettingDivide;
                    // 商品メーカーコード
                    rate.GoodsMakerCd = rateUnMatchWork.GoodsMakerCd;
                    // 商品番号
                    rate.GoodsNo = rateUnMatchWork.GoodsNo;
                    // 商品掛率ランク
                    rate.GoodsRateRank = rateUnMatchWork.GoodsRateRank;
                    // 商品掛率グループコード
                    rate.GoodsRateGrpCode = rateUnMatchWork.GoodsRateGrpCode;
                    // BLグループコード
                    rate.BLGroupCode = rateUnMatchWork.BLGroupCode;
                    // BL商品コード
                    rate.BLGoodsCode = rateUnMatchWork.BLGoodsCode;
                    // 得意先コード
                    rate.CustomerCode = rateUnMatchWork.CustomerCode;
                    // 得意先掛率グループコード
                    rate.CustRateGrpCode = rateUnMatchWork.CustRateGrpCode;
                    // 仕入先コード
                    rate.SupplierCd = rateUnMatchWork.SupplierCd;
                    // ロット数
                    rate.LotCount = rateUnMatchWork.LotCount;

                    // 単価種類
                    string kind = rate.UnitPriceKind;
                    switch (kind)
                    {
                        case "1":
                            this._delUnitPriceKind1Cnt++;
                            break;
                        case "2":
                            this._delUnitPriceKind2Cnt++;
                            break;
                        case "3":
                            this._delUnitPriceKind3Cnt++;
                            break;
                    }
                    delRateList.Add(rate);
                }
                // 掛率マスタの削除処理
                status = rateAcs.Delete(ref delRateList, out errMsg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                }
            }
            catch (Exception ex)
            {
                this._delUnitPriceKind1Cnt = 0;
                this._delUnitPriceKind2Cnt = 0;
                this._delUnitPriceKind3Cnt = 0;
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◆ 削除処理

        #region ◆ ログ処理
        /// <summary>
        /// ログ処理
        /// </summary>
        /// <param name="delList">削除データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ログ処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int WriteLog(ArrayList delList, out string errMsg)
        {
            return this.WriteLogProc(delList, out errMsg);
        }

        /// <summary>
        /// ログ処理
        /// </summary>
        /// <param name="delList">削除データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ログ処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private int WriteLogProc(ArrayList delList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                string preMsg = string.Empty;

                foreach (RateUnMatchWork rate in delList)
                {
                    StringBuilder msgSb = new StringBuilder("掛率マスタ削除");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("{0}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("{1}");
                    msgSb.Append("得G:{2}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("得意先:{3}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("仕入先:{4}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("ﾒｰｶｰ:{5}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("層別:{6}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("商品掛率:{7}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("ｸﾞﾙｰﾌﾟｺｰﾄﾞ:{8}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("BLｺｰﾄﾞ:{9}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("品番:{10}");
                    msgSb.Append(ct_SPACE);
                    msgSb.Append("{11}");
                    string logDelNm = String.Empty;
                    // 論理削除
                    if (rate.LogicalDeleteCode == 1)
                    {
                        logDelNm = "論理削除" + ct_SPACE;
                    }
                    // 作成区分
                    string kindNm = String.Empty;
                    switch (rate.UnitPriceKindCd)
                    {
                        case "1":
                            kindNm = "売価設定";
                            break;
                        case "2":
                            kindNm = "原価設定";
                            break;
                        case "3":
                            // upd by liuxz on 2009/07/22 start
                            // kindNm = "定価設定";
                            kindNm = "価格設定";
                            // upd by liuxz on 2009/07/22 end
                            break;
                    }
                    // upd by liuxz on 2009/07/22 start
                    /*
                    string msg = String.Format(msgSb.ToString(),
                                    kindNm,
                                    logDelNm,
                                    rate.CustRateGrpCode,
                                    rate.CustomerCode,
                                    rate.SupplierCd,
                                    rate.GoodsMakerCd,
                                    rate.GoodsRateRank,
                                    rate.GoodsRateGrpCode,
                                    rate.BLGroupCode,
                                    rate.BLGoodsCode,
                                    rate.GoodsNo,
                                    rate.Content);
                    */
                    string custRateGrpCode = GetMessageForLog(rate.CustRateGrpCode, 4);
                    string customerCode = GetMessageForLog(rate.CustomerCode, 8);
                    string supplierCd = GetMessageForLog(rate.SupplierCd, 6);
                    string goodsMakerCd = GetMessageForLog(rate.GoodsMakerCd, 4);
                    string goodsRateGrpCode = GetMessageForLog(rate.GoodsRateGrpCode, 4);
                    string bLGroupCode = GetMessageForLog(rate.BLGroupCode, 5);
                    string bLGoodsCode = GetMessageForLog(rate.BLGoodsCode, 5);
                    string msg = String.Format(msgSb.ToString(),
                                    kindNm,
                                    logDelNm,
                                    custRateGrpCode,
                                    customerCode,
                                    supplierCd,
                                    goodsMakerCd,
                                    rate.GoodsRateRank,
                                    goodsRateGrpCode,
                                    bLGroupCode,
                                    bLGoodsCode,
                                    rate.GoodsNo,
                                    rate.Content);
                    // upd by liuxz on 2009/07/22 end
                    if (string.IsNullOrEmpty(preMsg) || !preMsg.Equals(msg))
                    {
                        OperationHistoryLog log = new OperationHistoryLog();
                        log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, ct_UIPGID, ct_UIPGNM, string.Empty, 0, 0, msg, string.Empty);
                    }
                    preMsg = msg;
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        // add by liuxz on 2009/07/22 start
        #region ログ内容のフォーマット
        //
        /// <summary>
        /// ログ内容のフォーマット
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetMessageForLog(Int32 data, Int32 length)
        {
            if (data != 0)
            {
                return data.ToString().PadLeft(length, '0');
            }
            else
            {
                return string.Empty;
            }
        }
        // add by liuxz on 2009/07/22 end
        #endregion
        #endregion ◆ ログ処理

        #region ◆ データ展開処理
        #region ◎ 売価原価アンマッチリストデータ展開処理
        /// <summary>
        /// 売価原価アンマッチリストデータ展開処理
        /// </summary>
        /// <param name="rateUnMatchCndtn">抽出条件クラス</param>
        /// <param name="rateUnMatchDt">展開対象DataTable</param>
        /// <param name="rateUnMatchWorkList">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 売価原価アンマッチリストデータを展開する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private void DevRateUnMatchWorkListData(RateUnMatchCndtn rateUnMatchCndtn, DataTable rateUnMatchDt, ArrayList rateUnMatchWorkList)
        {
            string lastSectionCode = null;
            string lastUnitPriceKindCd = null;
            bool isDelete = false;
            string errMsg = string.Empty;

            for (int i = 0; i < rateUnMatchWorkList.Count; i++)
            {
                RateUnMatchWork rateUnMatchWork = (RateUnMatchWork)rateUnMatchWorkList[i];
                // 提供データに商品データをチェックする
                this.CheckProc(ref rateUnMatchWork, out isDelete, out errMsg);

                // 商品マスタチェックがエラーだけ以外の場合、データを作成する
                if (!isDelete)
                {
                    DataSetRateUnMatch(rateUnMatchCndtn, rateUnMatchDt, rateUnMatchWork, ref lastSectionCode, ref lastUnitPriceKindCd);
                }
            }
        }
        #endregion

        /// <summary>
        /// 取得データ設定処理
        /// </summary>
        /// <param name="rateUnMatchCndtn">抽出条件クラス</param>
        /// <param name="rateUnMatchDt">展開対象DataTable</param>
        /// <param name="rateUnMatchWork">取得データ</param>
        /// <param name="lastSectionCode">前回拠点コード</param>
        /// <param name="lastUnitPriceKindCd">前回作成区分</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        private void DataSetRateUnMatch(RateUnMatchCndtn rateUnMatchCndtn, DataTable rateUnMatchDt, RateUnMatchWork rateUnMatchWork, ref string lastSectionCode, ref string lastUnitPriceKindCd)
        {
            DataRow dr;

            dr = rateUnMatchDt.NewRow();

            // 売価原価アンマッチリストデータ展開
            #region 売価原価アンマッチリストデータ展開
            dr[RateUnMatchResult.Col_UpdateDateTime] = rateUnMatchWork.UpdateDateTime;
            // 処理区分
            switch (rateUnMatchCndtn.ProcessKbn)
            {
                case 0:
                    dr[RateUnMatchResult.Col_ProcessKbn] = "印刷のみ";
                    break;
                case 1:
                    dr[RateUnMatchResult.Col_ProcessKbn] = "印刷＆削除";
                    break;
                case 2:
                    break;
            }
            dr[RateUnMatchResult.Col_EnterpriseCode] = rateUnMatchWork.EnterpriseCode;
            dr[RateUnMatchResult.Col_LogicalDeleteCode] = rateUnMatchWork.LogicalDeleteCode;
            if (rateUnMatchWork.LogicalDeleteCode == 1)
            {
                dr[RateUnMatchResult.Col_LogicalDeleteName] = "論理削除";
            }
            else
            {
                dr[RateUnMatchResult.Col_LogicalDeleteName] = String.Empty;
            }
            dr[RateUnMatchResult.Col_SectionCode] = rateUnMatchWork.SectionCode;
            if (rateUnMatchWork.SectionCode != lastSectionCode)
            {
                dr[RateUnMatchResult.Col_SectionCodeForPrint] = rateUnMatchWork.SectionCode;
                dr[RateUnMatchResult.Col_SectionName] = rateUnMatchWork.SectionName;
            }
            else
            {
                dr[RateUnMatchResult.Col_SectionCodeForPrint] = String.Empty;
                dr[RateUnMatchResult.Col_SectionName] = String.Empty;
            }
            dr[RateUnMatchResult.Col_UnitRateSetDivCd] = rateUnMatchWork.UnitRateSetDivCd;
            dr[RateUnMatchResult.Col_UnitPriceKindCd] = rateUnMatchWork.UnitPriceKindCd;
            if (rateUnMatchWork.SectionCode != lastSectionCode || rateUnMatchWork.UnitPriceKindCd != lastUnitPriceKindCd)
            {
                switch (rateUnMatchWork.UnitPriceKindCd)
                {
                    case "1":
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = "売価設定";
                        break;
                    case "2":
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = "原価設定";
                        break;
                    case "3":
                        // upd by liuxz on 2009/07/22 start
                        // dr[RateUnMatchResult.Col_UnitPriceKindNm] = "定価設定";
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = "価格設定";
                        // upd by liuxz on 2009/07/22 end
                        break;
                    default:
                        dr[RateUnMatchResult.Col_UnitPriceKindNm] = String.Empty;
                        break;
                }
            }
            else
            {
                dr[RateUnMatchResult.Col_UnitPriceKindNm] = String.Empty;
            }
            lastSectionCode = rateUnMatchWork.SectionCode;
            lastUnitPriceKindCd = rateUnMatchWork.UnitPriceKindCd;
            // 掛率設定区分の設定対象の判定
            // メーカー
            if (RateAcs.IsMakerSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsMakerCdForPrint] = rateUnMatchWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                dr[RateUnMatchResult.Col_GoodsMakerNm] = rateUnMatchWork.GoodsMakerNm;
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsMakerCdForPrint] = String.Empty;
                dr[RateUnMatchResult.Col_GoodsMakerNm] = String.Empty;
            }
            // 品番
            if (RateAcs.IsGoodsNoSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsNoForPrint] = rateUnMatchWork.GoodsNo;
                dr[RateUnMatchResult.Col_GoodsNm] = rateUnMatchWork.GoodsNm;
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsNoForPrint] = String.Empty;
                dr[RateUnMatchResult.Col_GoodsNm] = String.Empty;
            }
            // 層別
            if (RateAcs.IsGoodsRateRankSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsRateRankForPrint] = rateUnMatchWork.GoodsRateRank;
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsRateRankForPrint] = String.Empty;
            }
            // 商品掛率
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_GoodsRateGrpCodeForPrint] = rateUnMatchWork.GoodsRateGrpCode.ToString().PadLeft(4, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_GoodsRateGrpCodeForPrint] = String.Empty;
            }
            // グループコード
            if (RateAcs.IsBLGroupCodeSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_BLGroupCodeForPrint] = rateUnMatchWork.BLGroupCode.ToString().PadLeft(5, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_BLGroupCodeForPrint] = String.Empty;
            }
            // BLコード
            if (RateAcs.IsBLGoodsSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_BLGoodsCodeForPrint] = rateUnMatchWork.BLGoodsCode.ToString().PadLeft(5, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_BLGoodsCodeForPrint] = String.Empty;
            }
            // 得意先コード
            if (RateAcs.IsCustomerSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_CustomerCodeForPrint] = rateUnMatchWork.CustomerCode.ToString().PadLeft(8, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_CustomerCodeForPrint] = String.Empty;
            }
            // 得G
            if (RateAcs.IsCustRateGrpSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_CustRateGrpCodeForPrint] = rateUnMatchWork.CustRateGrpCode.ToString().PadLeft(4, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_CustRateGrpCodeForPrint] = String.Empty;
            }
            // 仕入先コード
            if (RateAcs.IsSupplierSetting(rateUnMatchWork.RateSettingDivide))
            {
                dr[RateUnMatchResult.Col_SupplierCdForPrint] = rateUnMatchWork.SupplierCd.ToString().PadLeft(6, '0');
            }
            else
            {
                dr[RateUnMatchResult.Col_SupplierCdForPrint] = String.Empty;
            }

            dr[RateUnMatchResult.Col_RateSettingDivide] = rateUnMatchWork.RateSettingDivide;
            dr[RateUnMatchResult.Col_RateMngGoodsCd] = rateUnMatchWork.RateMngGoodsCd;
            dr[RateUnMatchResult.Col_RateMngGoodsNm] = rateUnMatchWork.RateMngGoodsNm;
            dr[RateUnMatchResult.Col_RateMngCustCd] = rateUnMatchWork.RateMngCustCd;
            dr[RateUnMatchResult.Col_RateMngCustNm] = rateUnMatchWork.RateMngCustNm;
            dr[RateUnMatchResult.Col_GoodsMakerCd] = rateUnMatchWork.GoodsMakerCd;
            dr[RateUnMatchResult.Col_GoodsNo] = rateUnMatchWork.GoodsNo;           
            dr[RateUnMatchResult.Col_GoodsRateRank] = rateUnMatchWork.GoodsRateRank;
            dr[RateUnMatchResult.Col_GoodsRateGrpCode] = rateUnMatchWork.GoodsRateGrpCode;
            dr[RateUnMatchResult.Col_BLGroupCode] = rateUnMatchWork.BLGroupCode;
            dr[RateUnMatchResult.Col_BLGoodsCode] = rateUnMatchWork.BLGoodsCode;
            dr[RateUnMatchResult.Col_CustomerCode] = rateUnMatchWork.CustomerCode;
            dr[RateUnMatchResult.Col_CustRateGrpCode] = rateUnMatchWork.CustRateGrpCode;
            dr[RateUnMatchResult.Col_SupplierCd] = rateUnMatchWork.SupplierCd;
            dr[RateUnMatchResult.Col_LotCount] = rateUnMatchWork.LotCount;
            dr[RateUnMatchResult.Col_PriceFl] = rateUnMatchWork.PriceFl;
            dr[RateUnMatchResult.Col_RateVal] = rateUnMatchWork.RateVal;
            dr[RateUnMatchResult.Col_UpRate] = rateUnMatchWork.UpRate;
            dr[RateUnMatchResult.Col_GrsProfitSecureRate] = rateUnMatchWork.GrsProfitSecureRate;
            dr[RateUnMatchResult.Col_UnPrcFracProcUnit] = rateUnMatchWork.UnPrcFracProcUnit;
            dr[RateUnMatchResult.Col_UnPrcFracProcDiv] = rateUnMatchWork.UnPrcFracProcDiv;
            dr[RateUnMatchResult.Col_IsErrRateProtyMng] = rateUnMatchWork.IsErrRateProtyMng;
            dr[RateUnMatchResult.Col_IsErrGoodsU] = rateUnMatchWork.IsErrGoodsU;
            dr[RateUnMatchResult.Col_IsAllZero] = rateUnMatchWork.IsAllZero;
            StringBuilder content = new StringBuilder();
            if (dr[RateUnMatchResult.Col_IsErrRateProtyMng].ToString() != "0")
            {
                content.Append("掛率優先順位に該当無し");
            }
            if (dr[RateUnMatchResult.Col_IsErrGoodsU].ToString() != "0")
            {
                if (content.Length > 0)
                {
                    content.Append("、");
                }
                content.Append("商品マスタ未登録");
            }
            if (dr[RateUnMatchResult.Col_IsAllZero].ToString() != "0")
            {
                if (content.Length > 0)
                {
                    content.Append("、");
                }
                content.Append("設定値が全てゼロ");
            }
            dr[RateUnMatchResult.Col_Content] = content.ToString();

            // TableにAdd
            rateUnMatchDt.Rows.Add(dr);
        }

        #endregion ◆ データ展開処理
        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得

        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票設定データ取得
        #endregion ■ Private Method
    }
}
