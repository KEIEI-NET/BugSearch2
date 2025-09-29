using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 商品マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: 連番 810 zhouyu </br>
    /// <br>Date       : 2011/08/12 </br>
	/// <br></br>
    /// </remarks>
	public class GoodsSetAcs 
	{

        #region ■ Constructor
        /// <summary>
        /// 商品マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public GoodsSetAcs()
        {
            this._iGoodsPrintDB = (IGoodsPrintDB)MediationGoodsPrintDB.GetGoodsPrintDB();

        }

        /// <summary>
        /// 商品マスタ印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品マスタ印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
        /// </remarks>
        static GoodsSetAcs()
        {
            stc_Employee = null;
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary

            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // 既存でなければ
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion ■ Static Member

        #region ■ Private Member
        IGoodsPrintDB _iGoodsPrintDB;
        //-------------------ADD 2011/08/12---------------------->>>>>
        private Dictionary<string, GoodsMngWork> _goodsMngDic1;      //拠点(全社共通含む)＋メーカー＋品番
        private Dictionary<string, GoodsMngWork> _goodsMngDic2;      //拠点(全社共通含む)＋中分類＋メーカー＋ＢＬ
        private Dictionary<string, GoodsMngWork> _goodsMngDic3;      //拠点(全社共通含む)＋中分類＋メーカー
        private Dictionary<string, GoodsMngWork> _goodsMngDic4;      //拠点(全社共通含む)＋メーカー
        private Dictionary<int, SupplierWork> _supplierWorkDic;      //仕入先
        //-------------------ADD 2011/08/12----------------------<<<<<
        #endregion ■ Private Member

		/// <summary>
		/// 商品マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 商品マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, GoodsPrintWork goodsPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, goodsPrintWork);
		}

		/// <summary>
		/// 商品マスタ検索処理（論理削除）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 商品マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, GoodsPrintWork goodsPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, goodsPrintWork);
		}


        //--------------------ADD 2011/08/12--------------------->>>>>
        /// <summary>
        ///  商品管理情報取得処理と仕入先
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       :  商品管理情報取得処理と仕入先を行います。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        private int SetGoodsMsgSupplier(string enterpriseCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            object retObj = null;
            status = this._iGoodsPrintDB.SearchGoodsMsgSpler(ref retObj, enterpriseCode, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (retObj is ArrayList)
                {
                    _goodsMngDic1 = new Dictionary<string, GoodsMngWork>();     //拠点＋メーカー＋品番
                    _goodsMngDic2 = new Dictionary<string, GoodsMngWork>();     //拠点＋中分類＋メーカー＋ＢＬ
                    _goodsMngDic3 = new Dictionary<string, GoodsMngWork>();     //拠点＋中分類＋メーカー
                    _goodsMngDic4 = new Dictionary<string, GoodsMngWork>();     //拠点＋メーカー
                    _supplierWorkDic = new Dictionary<int, SupplierWork>();  // 仕入先
                    ArrayList workList = retObj as ArrayList;
                    foreach (object obj in  workList)
                    {
                        if (obj is GoodsMngWork)
                        {
                            GoodsMngWork goodsMngWork = obj as GoodsMngWork;
                            StringBuilder goodsMngDic1Key = new StringBuilder();
                            StringBuilder goodsMngDic2Key = new StringBuilder();
                            StringBuilder goodsMngDic3Key = new StringBuilder();
                            StringBuilder goodsMngDic4Key = new StringBuilder();

                            goodsMngDic4Key.Append(goodsMngWork.SectionCode.Trim().PadLeft(2, '0'));     //拠点
                            goodsMngDic4Key.Append(goodsMngWork.GoodsMakerCd.ToString("0000"));         //メーカー

                            if (goodsMngWork.GoodsNo.Trim() != string.Empty)
                            {
                                goodsMngDic1Key.Append(goodsMngDic4Key.ToString());                         //拠点＋メーカー
                                goodsMngDic1Key.Append(goodsMngWork.GoodsNo.Trim());                    //品番

                                //拠点＋メーカー＋品番
                                if (!_goodsMngDic1.ContainsKey(goodsMngDic1Key.ToString()))
                                {
                                    _goodsMngDic1.Add(goodsMngDic1Key.ToString(), goodsMngWork);
                                }
                            }
                            else
                            {
                                goodsMngDic3Key.Append(goodsMngDic4Key.ToString());                         //拠点＋メーカー
                                goodsMngDic3Key.Append(goodsMngWork.GoodsMGroup.ToString("0000"));      //中分類

                                goodsMngDic2Key.Append(goodsMngDic3Key.ToString());                         //拠点＋メーカー＋中分類
                                goodsMngDic2Key.Append(goodsMngWork.BLGoodsCode.ToString("00000"));     //ＢＬ

                                if (goodsMngWork.BLGoodsCode != 0)
                                {
                                    //拠点＋中分類＋メーカー＋ＢＬ
                                    if (!_goodsMngDic2.ContainsKey(goodsMngDic2Key.ToString()))
                                    {
                                        _goodsMngDic2.Add(goodsMngDic2Key.ToString(), goodsMngWork);
                                    }
                                }
                                else if (goodsMngWork.GoodsMGroup != 0)
                                {
                                    //拠点＋中分類＋メーカー
                                    if (!_goodsMngDic3.ContainsKey(goodsMngDic3Key.ToString()))
                                    {
                                        _goodsMngDic3.Add(goodsMngDic3Key.ToString(), goodsMngWork);
                                    }
                                }
                                else
                                {
                                    //拠点＋メーカー
                                    if (!_goodsMngDic4.ContainsKey(goodsMngDic4Key.ToString()))
                                    {
                                        _goodsMngDic4.Add(goodsMngDic4Key.ToString(), goodsMngWork);
                                    }
                                }
                            }
                        }
                        if (obj is SupplierWork)
                        {
                            SupplierWork supplierWork = obj as SupplierWork;
                            _supplierWorkDic.Add(supplierWork.SupplierCd, supplierWork);
                        }
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 商品管理情報と仕入先追加処理
        /// </summary>
        /// <param name="goodsPrintResultWork">商品マスタ</param>
        /// <returns>GoodsPrintResultWork</returns>
        /// <remarks>
        /// <br>Note       :  商品管理情報と仕入先追加処理を行います。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        private GoodsPrintResultWork AddSupplierFormGoodsMsg(GoodsPrintResultWork goodsPrintResultWork)
        {
            //拠点＋メーカー
            StringBuilder goodsMngDic4key = new StringBuilder();
            goodsMngDic4key.Append(goodsPrintResultWork.SectionCode.Trim().PadLeft(2, '0'));
            goodsMngDic4key.Append(goodsPrintResultWork.GoodsMakerCd.ToString("0000"));
            //【拠点＋メーカー】＋品番
            StringBuilder goodsMngDic1key = new StringBuilder();
            goodsMngDic1key.Append(goodsMngDic4key.ToString());
            goodsMngDic1key.Append(goodsPrintResultWork.GoodsNo.Trim());

            //1.拠点＋メーカー＋品番
            if (_goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic1[goodsMngDic1key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic1[goodsMngDic1key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //全社＋メーカー
            StringBuilder goodsMngDic8key = new StringBuilder();
            goodsMngDic8key.Append("00");
            goodsMngDic8key.Append(goodsPrintResultWork.GoodsMakerCd.ToString("0000"));
            //【全社＋メーカー】＋品番
            StringBuilder goodsMngDic5key = new StringBuilder();
            goodsMngDic5key.Append(goodsMngDic8key.ToString());
            goodsMngDic5key.Append(goodsPrintResultWork.GoodsNo.Trim());

            //2.全社＋メーカー＋品番
            if (_goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic1[goodsMngDic5key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic1[goodsMngDic5key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //【拠点＋メーカー】＋中分類
            StringBuilder goodsMngDic3key = new StringBuilder();
            goodsMngDic3key.Append(goodsMngDic4key.ToString());
            goodsMngDic3key.Append(goodsPrintResultWork.GoodsRateGrpCode.ToString("0000"));
            //【拠点＋メーカー＋中分類】＋ＢＬ
            StringBuilder goodsMngDic2key = new StringBuilder();
            goodsMngDic2key.Append(goodsMngDic3key.ToString());
            goodsMngDic2key.Append(goodsPrintResultWork.BLGoodsCode.ToString("00000"));

            //3.拠点＋中分類＋メーカー＋ＢＬ
            if (_goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic2[goodsMngDic2key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic2[goodsMngDic2key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //【全社＋メーカー】＋中分類
            StringBuilder goodsMngDic7key = new StringBuilder();
            goodsMngDic7key.Append(goodsMngDic8key.ToString());
            goodsMngDic7key.Append(goodsPrintResultWork.GoodsRateGrpCode.ToString("0000"));
            //【全社＋メーカー＋中分類】＋ＢＬ
            StringBuilder goodsMngDic6key = new StringBuilder();
            goodsMngDic6key.Append(goodsMngDic7key.ToString());
            goodsMngDic6key.Append(goodsPrintResultWork.BLGoodsCode.ToString("00000"));

            //4.全社＋中分類＋メーカー＋ＢＬ
            if (_goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic2[goodsMngDic6key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic2[goodsMngDic6key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //5.拠点＋中分類＋メーカー
            if (_goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic3[goodsMngDic3key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic3[goodsMngDic3key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //6.全社＋中分類＋メーカー
            if (_goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic3[goodsMngDic7key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic3[goodsMngDic7key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //7.拠点＋メーカー
            if (_goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic4[goodsMngDic4key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic4[goodsMngDic4key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }

            //8.全社＋メーカー
            if (_goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
            {
                goodsPrintResultWork.SupplierCd = _goodsMngDic4[goodsMngDic8key.ToString()].SupplierCd;
                goodsPrintResultWork.SectionCode = _goodsMngDic4[goodsMngDic8key.ToString()].SectionCode;
                if (_supplierWorkDic.ContainsKey(goodsPrintResultWork.SupplierCd))
                    goodsPrintResultWork.SupplierSnm = _supplierWorkDic[goodsPrintResultWork.SupplierCd].SupplierSnm;
                return goodsPrintResultWork;
            }
            return null;
        }
        //--------------------ADD 2011/08/12---------------------<<<<<

        /// <summary>
        /// 商品マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品マスタの検索処理を行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsPrintWork goodsPrintWork)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            try
            {   

                GoodsPrintParamWork goodsPrintParamWork = new GoodsPrintParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevReatCndtn(goodsPrintWork, enterpriseCode, out goodsPrintParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }
                //---------------ADD 2011/08/12------------------->>>>>
                //商品管理情報取得処理と仕入先  -----------------------------------------------
                status = this.SetGoodsMsgSupplier(enterpriseCode);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }
                //---------------ADD 2011/08/12-------------------<<<<<

                // データ取得  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iGoodsPrintDB.Search(out retReatList, goodsPrintParamWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        //-------------------ADD 2011/08/12---------------------->>>>>
                        ArrayList goodsPrintResultWorkList = new ArrayList();
                        foreach (GoodsPrintResultWork goodsPrintResultWork in (ArrayList)retReatList)
                        {
                            // 全社共通
                            goodsPrintResultWork.SectionCode = "00";
                            GoodsPrintResultWork goodsPrintResultWork1 = this.AddSupplierFormGoodsMsg(goodsPrintResultWork);
                            if (goodsPrintResultWork1 != null)
                                goodsPrintResultWorkList.Add(goodsPrintResultWork1);

                            //自社のデータ
                            goodsPrintResultWork.SectionCode = stc_Employee.BelongSectionCode;
                            GoodsPrintResultWork goodsPrintResultWork2 = this.AddSupplierFormGoodsMsg(goodsPrintResultWork);
                            if (goodsPrintResultWork2 != null)
                                goodsPrintResultWorkList.Add(goodsPrintResultWork2);
                        }
                        //-------------------ADD 2011/08/12----------------------<<<<<
                        // データ展開処理
                        //DevReatData(goodsPrintWork, (ArrayList)retReatList, out retList); //DEL 2011/08/12
                        DevReatData(goodsPrintWork, goodsPrintResultWorkList, out retList); //ADD 2011/08/12

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {                            
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch 
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;

        }

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="goodsPrintWork">UI抽出条件クラス</param>
        /// <param name="goodsPrintParamWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(GoodsPrintWork goodsPrintWork, string enterpriseCode, out GoodsPrintParamWork goodsPrintParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            goodsPrintParamWork = new GoodsPrintParamWork();
            try
            {
                goodsPrintParamWork.EnterpriseCode = enterpriseCode;  // 企業コード
                // 抽出条件パラメータセット
                goodsPrintParamWork.SectionCode = null;
                goodsPrintParamWork.SupplierCdSt = goodsPrintWork.SupplierCdSt;
                if (goodsPrintWork.SupplierCdEd == 0)
                {
                    goodsPrintParamWork.SupplierCdEd = 999999;
                }
                else
                {
                    goodsPrintParamWork.SupplierCdEd = goodsPrintWork.SupplierCdEd;
                }
                goodsPrintParamWork.GoodsMakerCdSt = goodsPrintWork.GoodsMakerCdSt;
                if (goodsPrintWork.GoodsMakerCdEd == 0)
                {
                    goodsPrintParamWork.GoodsMakerCdEd = 9999;
                }
                else
                {
                    goodsPrintParamWork.GoodsMakerCdEd = goodsPrintWork.GoodsMakerCdEd;
                }
                goodsPrintParamWork.BLGoodsCodeSt = goodsPrintWork.BLGoodsCodeSt;
                if (goodsPrintWork.BLGoodsCodeEd == 0)
                {
                    goodsPrintParamWork.BLGoodsCodeEd = 99999;
                }
                else
                {
                    goodsPrintParamWork.BLGoodsCodeEd = goodsPrintWork.BLGoodsCodeEd;
                }
                goodsPrintParamWork.GoodsNoSt = goodsPrintWork.GoodsNoSt;
                goodsPrintParamWork.GoodsNoEd = goodsPrintWork.GoodsNoEd;
                goodsPrintParamWork.ListPrice = goodsPrintWork.ListPrice;
                goodsPrintParamWork.ListPriceDiv = goodsPrintWork.ListPriceDiv;
                goodsPrintParamWork.SalesUnitCost = goodsPrintWork.SalesUnitCost;
                goodsPrintParamWork.SalesUnitCostDiv = goodsPrintWork.SalesUnitCostDiv;
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="goodsPrintWork">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void DevReatData(GoodsPrintWork goodsPrintWork, ArrayList retaWork, out ArrayList retList)
        {
            
            retList = new ArrayList();

            foreach (GoodsPrintResultWork goodsPrintResultWork in retaWork)
            {
                if (DataCheck(goodsPrintResultWork, goodsPrintWork)==0)
                {
                    GoodsSet goodsSet = new GoodsSet();

                    goodsSet.UpdateDateTime = goodsPrintResultWork.UpdateDateTime;
                    goodsSet.GoodsMakerCd = goodsPrintResultWork.GoodsMakerCd;
                    goodsSet.MakerShortName = goodsPrintResultWork.MakerShortName;
                    goodsSet.GoodsNo = goodsPrintResultWork.GoodsNo;
                    goodsSet.BLGoodsCode = goodsPrintResultWork.BLGoodsCode;
                    goodsSet.GoodsName = goodsPrintResultWork.GoodsName;
                    goodsSet.SupplierCd = goodsPrintResultWork.SupplierCd;
                    goodsSet.SupplierSnm = goodsPrintResultWork.SupplierSnm;
                    goodsSet.ListPrice = goodsPrintResultWork.ListPrice;
                    goodsSet.StockRate = goodsPrintResultWork.StockRate;
                    goodsSet.SalesUnitCost = goodsPrintResultWork.SalesUnitCost;
                    goodsSet.GoodsRateRank = goodsPrintResultWork.GoodsRateRank;
                    goodsSet.SupplierLot = goodsPrintResultWork.SupplierLot;
                    goodsSet.GoodsSpecialNote = goodsPrintResultWork.GoodsSpecialNote;
                    goodsSet.GoodsNote1 = goodsPrintResultWork.GoodsNote1;
                    goodsSet.GoodsNote2 = goodsPrintResultWork.GoodsNote2;
                    goodsSet.PriceStartDate = goodsPrintResultWork.PriceStartDate;
                    goodsSet.NewListPrice = goodsPrintResultWork.NewListPrice;
                    goodsSet.GoodsKindCode = goodsPrintResultWork.GoodsKindCode;
                    goodsSet.TaxationDivCd = goodsPrintResultWork.TaxationDivCd;
                    goodsSet.EnterpriseGanreCode = goodsPrintResultWork.EnterpriseGanreCode;
                    goodsSet.EnterpriseGanreCodeName = goodsPrintResultWork.EnterpriseGanreCodeName;
                    goodsSet.OfferDataDiv = goodsPrintResultWork.OfferDataDiv;

                    retList.Add(goodsSet);
                }
                
            }

        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(GoodsPrintResultWork goodsPrintResultWork, GoodsPrintWork goodsPrintWork)
        {
            int status = 0;

            string upDateTime = goodsPrintResultWork.UpdateDateTime.Year.ToString("0000") +
                                goodsPrintResultWork.UpdateDateTime.Month.ToString("00") +
                                goodsPrintResultWork.UpdateDateTime.Day.ToString("00");

            if (goodsPrintWork.LogicalDeleteCode == 1 &&
                goodsPrintWork.DeleteDateTimeSt != 0 &&
                goodsPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < goodsPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > goodsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsPrintWork.LogicalDeleteCode == 1 &&
                        goodsPrintWork.DeleteDateTimeSt != 0 &&
                        goodsPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < goodsPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsPrintWork.LogicalDeleteCode == 1 &&
                      goodsPrintWork.DeleteDateTimeSt == 0 &&
                      goodsPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > goodsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // 全社共通又は、自社のデータのみを対象とする
            // DEL 2008/11/27 不具合対応[8324] ---------->>>>>
            //if (goodsPrintResultWork.SectionCode.Trim() != "00" &&
            //   goodsPrintResultWork.SectionCode != stc_Employee.BelongSectionCode)
            // DEL 2008/11/27 不具合対応[8324] ----------<<<<<
            // ADD 2008/11/27 不具合対応[8324] ---------->>>>>
            if (goodsPrintResultWork.SectionCode.Trim() != "" &&
                goodsPrintResultWork.SectionCode.Trim() != "00" &&
               goodsPrintResultWork.SectionCode != stc_Employee.BelongSectionCode)
            // ADD 2008/11/27 不具合対応[8324] ----------<<<<<
            {

                status = -1;
                return status;
            }

            // システム日付以前のデータのみを対象とする
            if (goodsPrintResultWork.PriceStartDate > DateTime.Today)
            {
                status = -1;
                return status;
            }
            //-----------------ADD 2011/08/12---------------------->>>>>
            //仕入先コード
            if (goodsPrintWork.SupplierCdSt != 0)
            {
                if (goodsPrintResultWork.SupplierCd < goodsPrintWork.SupplierCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            if ((goodsPrintWork.SupplierCdEd != 0) && (goodsPrintWork.SupplierCdEd != 999999))
            {
                if (goodsPrintResultWork.SupplierCd > goodsPrintWork.SupplierCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            //-----------------ADD 2011/08/12---------------------->>>>>
            return status;
        }
    }
}
