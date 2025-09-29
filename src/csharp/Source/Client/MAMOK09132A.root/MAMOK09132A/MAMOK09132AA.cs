using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品別目標マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note			 : 商品別目標マスタへのアクセス制御を行います。</br>
    /// <br>Programmer		 : NEPCO</br>
    /// <br>Date			 : 2007.05.08</br>
	/// <br>Update Note		 : 2007.11.21 上野 弘貴</br>
	/// <br>                   流通.DC用に変更（項目追加・削除）</br>
	/// <br></br>
    /// </remarks>
    public class GcdSalesTargetAcs
    {
        #region Public EnumerationTypes
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモードの列挙型です。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }
        #endregion

        #region Private Member

        // 企業コード
        private string _enterpriseCode;
        // 拠点コード
        private string _sectionCode;

        ///// <summary>リモートオブジェクト格納バッファ</summary>
        private IGcdSalesTargetDB _iGcdSalesTargetDB = null;

        private GoodsAcs _goodsAcs;

//----- ueno add---------- start 2007.11.21
		// メーカーコードアクセスクラス
		private MakerAcs _makerAcs;
//----- ueno add---------- end   2007.11.21

        private int _goodsAcsStatus;

        #endregion Private Member

        #region Constructor
        /// <summary>
        /// 目標マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : リモートオブジェクトをインスタンス化します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public GcdSalesTargetAcs()
        {
            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            SecInfoSet secInfoSet;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            this._sectionCode = secInfoSet.SectionCode.TrimEnd();

            // オンラインの場合
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iGcdSalesTargetDB = (IGcdSalesTargetDB)MediationGcdSalesTargetDB.GetGcdSalesTargetDB();
                }
                catch (Exception)
                {
                    // オフライン時はnullをセット
                    this._iGcdSalesTargetDB = null;
                }

                this._goodsAcs = new GoodsAcs();

//----- ueno add---------- start 2007.11.21
				// メーカーコードアクセスクラス
				this._makerAcs = new MakerAcs();
//----- ueno add---------- end   2007.11.21

                string msg;
                try
                {

                    this._goodsAcsStatus = this._goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out msg);
                }
                catch (Exception ex)
                {
                    string ms = ex.Message;

                }
            }
            else
            // オフラインの場合
            {
                // オフライン時はnullをセット
                this._iGcdSalesTargetDB = null;
            }
        }

        #endregion Constructor

        #region Public Methods
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note	   : オンラインモードを取得します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iGcdSalesTargetDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="gcdSalesTarget">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 登録・更新処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Write(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            GcdSalesTargetWork gcdSalesTargetWork;
            ArrayList paraList = new ArrayList();

            // 商品マスタ初期化チェック
            if (this._goodsAcsStatus != 0)
            {
                return (this._goodsAcsStatus);
            }

            // UIデータクラス→ワーク
            foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
            {
                gcdSalesTargetWork = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget);
                paraList.Add(gcdSalesTargetWork);
            }

            object paraobj = paraList;

            int status = 0;
            try
            {
                // 書き込み処理
                status = this._iGcdSalesTargetDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }

                // ワーク→UIデータクラス
                GoodsUnitData goodsUnitData;
                paraList = (ArrayList)paraobj;
                GcdSalesTarget gcdSalesTarget2;
                gcdSalesTargetList.Clear();

//----- ueno upd---------- start 2007.11.21
                string goodsMakerName = "";	// メーカー名称
                string goodsName = "";		// 商品名称
                
                foreach (GcdSalesTargetWork gcdSalesTargetWork2 in paraList)
                {
                    if (gcdSalesTargetWork2.GoodsMakerCd != 0)
                    {
                        //メーカーコード有りで商品コード無しの場合、メーカーマスタを検索する
                        if (gcdSalesTargetWork2.GoodsNo == "")
                        //if (gcdSalesTargetWork2.GoodsNo == "")
                        {
                            MakerUMnt makerUMnt = null;
                            status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, gcdSalesTargetWork2.GoodsMakerCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = makerUMnt.MakerShortName;
                            goodsName = "";
                        }
                        // メーカーコード、商品コード有りの場合商品マスタを検索する
                        else
                        {
                            status = this._goodsAcs.Read(this._enterpriseCode, gcdSalesTargetWork2.GoodsMakerCd, gcdSalesTargetWork2.GoodsNo, out goodsUnitData);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = goodsUnitData.MakerName;
                            goodsName = goodsUnitData.GoodsName;
                        }
                    }
                        gcdSalesTarget2 = CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork2, goodsName, goodsMakerName);
                        gcdSalesTargetList.Add(gcdSalesTarget2);
                }
//----- ueno upd---------- end   2007.11.21

                return (0);

            }
            catch (Exception)
            {
                // 通信エラーは-1を戻す
                return (-1);
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="gcdSalesTargetList">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 削除処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Delete(List<GcdSalesTarget> gcdSalesTargetList)
        {
            GcdSalesTargetWork[] gcdSalesTargetWorkList;
            gcdSalesTargetWorkList = new GcdSalesTargetWork[gcdSalesTargetList.Count];

            // UIデータクラス→ワーク
            for (int index = 0; index < gcdSalesTargetList.Count; index++)
            {
                gcdSalesTargetWorkList[index] = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTargetList[index]);
            }

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(gcdSalesTargetWorkList);

            int status = 0;
            try
            {
                // 書き込み処理
                status = this._iGcdSalesTargetDB.Delete(parabyte);
                if (status != 0)
                {
                    return (status);
                }
                // static削除

                return (0);
            }
            catch (Exception)
            {
                // 通信エラーは-1を戻す
                return (-1);
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">リスト</param>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 検索処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Search(
            out List<GcdSalesTarget> retList,
            ExtrInfo_MAMOK09137EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status;

            retList = new List<GcdSalesTarget>();

            // 商品マスタ初期化チェック
            if (this._goodsAcsStatus != 0)
            {
                return (this._goodsAcsStatus);
            }

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // パラメータ
                    SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork = new SearchGcdSalesTargetParaWork();
                    searchGcdSalesTargetParaWork.EnterpriseCode = extrInfo.EnterpriseCode;
                    searchGcdSalesTargetParaWork.SelectSectCd = extrInfo.SelectSectCd;
                    searchGcdSalesTargetParaWork.AllSecSelEpUnit = extrInfo.AllSecSelEpUnit;
                    searchGcdSalesTargetParaWork.AllSecSelSecUnit = extrInfo.AllSecSelSecUnit;
                    searchGcdSalesTargetParaWork.TargetSetCd = extrInfo.TargetSetCd;
                    searchGcdSalesTargetParaWork.TargetContrastCd = extrInfo.TargetContrastCd;
                    searchGcdSalesTargetParaWork.TargetDivideCode = extrInfo.TargetDivideCode;
                    searchGcdSalesTargetParaWork.TargetDivideName = extrInfo.TargetDivideName;
                    searchGcdSalesTargetParaWork.StartApplyStaDate = extrInfo.ApplyStaDateSt;
                    searchGcdSalesTargetParaWork.EndApplyStaDate = extrInfo.ApplyStaDateEd;
                    searchGcdSalesTargetParaWork.StartApplyEndDate = extrInfo.ApplyEndDateSt;
                    searchGcdSalesTargetParaWork.EndApplyEndDate = extrInfo.ApplyEndDateEd;
					//----- ueno del---------- start 2007.11.21
					//searchGcdSalesTargetParaWork.CarrierCode = extrInfo.CarrierCode;
                    //searchGcdSalesTargetParaWork.CellphoneModelCode = extrInfo.CellphoneModelCode;
					//----- ueno del---------- end   2007.11.21
                    searchGcdSalesTargetParaWork.GoodsMakerCd = extrInfo.MakerCode;
                    searchGcdSalesTargetParaWork.GoodsNo = extrInfo.GoodsCode;

                    searchGcdSalesTargetParaWork.BLGoodsCode = extrInfo.BLCode;
                    searchGcdSalesTargetParaWork.BLGroupCode = extrInfo.BLGroupCode;
                    searchGcdSalesTargetParaWork.SalesCode = extrInfo.SalesTypeCode;
                    

                    // 目標マスタ検索
                    object objectGcdSalesTargetWork = null;
                    status = this._iGcdSalesTargetDB.Search(out objectGcdSalesTargetWork, searchGcdSalesTargetParaWork, 0, logicalMode);
                    if (status != 0)
                    {
                        return (status);
                    }

                    // パラメータが渡って来ているか確認
                    ArrayList paraList = objectGcdSalesTargetWork as ArrayList;
                    if (paraList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }
//----- ueno upd---------- start 2007.11.21
					string goodsMakerName = "";	// メーカー名称
					string goodsName = "";		// 商品名称

                    // データ変換
                    GoodsUnitData goodsUnitData;
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in paraList)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA MODIFY START
                        //メーカーコード有りで商品コード無しの場合、メーカーマスタを検索する
                        if (gcdSalesTargetWork.GoodsMakerCd != 0 && gcdSalesTargetWork.GoodsNo == "")
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA MODIFY END
                        {
                            MakerUMnt makerUMnt = null;
                            status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, gcdSalesTargetWork.GoodsMakerCd);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = makerUMnt.MakerShortName;
                            goodsName = "";
                        }
                        // メーカーコード、商品コード有りの場合商品マスタを検索する
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA MODIFY START
                        else if (gcdSalesTargetWork.GoodsMakerCd != 0 && !String.IsNullOrEmpty(gcdSalesTargetWork.GoodsNo))
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA MODIFY END
                        {
                            status = this._goodsAcs.Read(this._enterpriseCode, gcdSalesTargetWork.GoodsMakerCd, gcdSalesTargetWork.GoodsNo, out goodsUnitData);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return (status);
                            }
                            goodsMakerName = goodsUnitData.MakerName;
                            goodsName = goodsUnitData.GoodsName;
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA MODIFY START
                        // メーカーおよび商品コードが空の場合は変換せずに空白のまま追加する
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA MODIFY END
                        retList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork, goodsName, goodsMakerName));
//----- ueno upd---------- end   2007.11.21
                    }
                }
                catch
                {
                    return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                }

                return ((int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL);

            }
        }

        #endregion

        # region Private Methods

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（目標マスタワーククラス⇒目標マスタクラス）
        /// </summary>
        /// <param name="gcdSalesTargetWork">目標マスタワーククラス</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsMakerName">メーカー名称</param>
        /// <returns>目標マスタクラス</returns>
        /// <remarks>
        /// <br>Note	   : 目標マスタワーククラスから目標マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
		private GcdSalesTarget CopyToGcdSalesTargetFromGcdSalesTargetWork(GcdSalesTargetWork gcdSalesTargetWork, string goodsName, string goodsMakerName)
        {
            GcdSalesTarget gcdSalesTarget = new GcdSalesTarget();

            gcdSalesTarget.CreateDateTime = gcdSalesTargetWork.CreateDateTime;
            gcdSalesTarget.UpdateDateTime = gcdSalesTargetWork.UpdateDateTime;
            gcdSalesTarget.EnterpriseCode = gcdSalesTargetWork.EnterpriseCode;
            gcdSalesTarget.FileHeaderGuid = gcdSalesTargetWork.FileHeaderGuid;
            gcdSalesTarget.UpdEmployeeCode = gcdSalesTargetWork.UpdEmployeeCode;
            gcdSalesTarget.UpdAssemblyId1 = gcdSalesTargetWork.UpdAssemblyId1;
            gcdSalesTarget.UpdAssemblyId2 = gcdSalesTargetWork.UpdAssemblyId2;
            gcdSalesTarget.LogicalDeleteCode = gcdSalesTargetWork.LogicalDeleteCode;

            gcdSalesTarget.SectionCode = gcdSalesTargetWork.SectionCode;
            gcdSalesTarget.TargetSetCd = gcdSalesTargetWork.TargetSetCd;
            gcdSalesTarget.TargetContrastCd = gcdSalesTargetWork.TargetContrastCd;
            gcdSalesTarget.TargetDivideCode = gcdSalesTargetWork.TargetDivideCode;
            gcdSalesTarget.TargetDivideName = gcdSalesTargetWork.TargetDivideName;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTarget.CarrierCode = gcdSalesTargetWork.CarrierCode;
            //gcdSalesTarget.CellphoneModelCode = gcdSalesTargetWork.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            gcdSalesTarget.MakerCode = gcdSalesTargetWork.GoodsMakerCd;
            gcdSalesTarget.GoodsCode = gcdSalesTargetWork.GoodsNo;
            gcdSalesTarget.ApplyStaDate = gcdSalesTargetWork.ApplyStaDate;
            gcdSalesTarget.ApplyEndDate = gcdSalesTargetWork.ApplyEndDate;
            gcdSalesTarget.GcdSalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney;
            gcdSalesTarget.GcdSalesTargetProfit = gcdSalesTargetWork.SalesTargetProfit;
            gcdSalesTarget.GcdSalesTargetCount = gcdSalesTargetWork.SalesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTarget.WeekdayRatio = gcdSalesTargetWork.WeekdayRatio;
            //gcdSalesTarget.SatSunRatio = gcdSalesTargetWork.SatSunRatio;
			//----- ueno del---------- end   2007.11.21            

			//----- ueno upd---------- start 2007.11.21
			// 商品名称
			gcdSalesTarget.GoodsName = goodsName;
            // メーカー名称
			gcdSalesTarget.MakerName = goodsMakerName;
			//----- ueno upd---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
            // キャリア名称
            //gcdSalesTarget.CarrierName = goodsUnitData.CarrierName;
            // 機種名称
            //gcdSalesTarget.CellphoneModelName = goodsUnitData.CellphoneModelName;
			//----- ueno del---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            gcdSalesTarget.BLGroupCode = gcdSalesTargetWork.BLGroupCode;
            gcdSalesTarget.BLCode = gcdSalesTargetWork.BLGoodsCode;
            gcdSalesTarget.SalesTypeCode = gcdSalesTargetWork.SalesCode;
            gcdSalesTarget.ItemTypeCode = gcdSalesTargetWork.EnterpriseGanreCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

            return gcdSalesTarget;
        }

        ///*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（目標マスタクラス⇒目標マスタワーククラス）
        /// </summary>
        /// <param name="gcdSalesTarget">目標マスタクラス</param>
        /// <returns>目標マスタクラス</returns>
        /// <remarks>
        /// <br>Note	   : 目標マスタクラスから目標マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private GcdSalesTargetWork CopyToGcdSalesTargetWorkFromGcdSalesTarget(GcdSalesTarget gcdSalesTarget)
        {
            GcdSalesTargetWork gcdSalesTargetWork = new GcdSalesTargetWork();

            gcdSalesTargetWork.CreateDateTime = gcdSalesTarget.CreateDateTime;
            gcdSalesTargetWork.UpdateDateTime = gcdSalesTarget.UpdateDateTime;
            gcdSalesTargetWork.EnterpriseCode = gcdSalesTarget.EnterpriseCode;
            gcdSalesTargetWork.FileHeaderGuid = gcdSalesTarget.FileHeaderGuid;
            gcdSalesTargetWork.UpdEmployeeCode = gcdSalesTarget.UpdEmployeeCode;
            gcdSalesTargetWork.UpdAssemblyId1 = gcdSalesTarget.UpdAssemblyId1;
            gcdSalesTargetWork.UpdAssemblyId2 = gcdSalesTarget.UpdAssemblyId2;
            gcdSalesTargetWork.LogicalDeleteCode = gcdSalesTarget.LogicalDeleteCode;

            gcdSalesTargetWork.SectionCode = gcdSalesTarget.SectionCode;
            gcdSalesTargetWork.TargetSetCd = gcdSalesTarget.TargetSetCd;
            gcdSalesTargetWork.TargetContrastCd = gcdSalesTarget.TargetContrastCd;
            gcdSalesTargetWork.TargetDivideCode = gcdSalesTarget.TargetDivideCode;
            gcdSalesTargetWork.TargetDivideName = gcdSalesTarget.TargetDivideName;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTargetWork.CarrierCode = gcdSalesTarget.CarrierCode;
            //gcdSalesTargetWork.CellphoneModelCode = gcdSalesTarget.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            gcdSalesTargetWork.GoodsMakerCd = gcdSalesTarget.MakerCode;
            gcdSalesTargetWork.GoodsNo = gcdSalesTarget.GoodsCode;
            gcdSalesTargetWork.ApplyStaDate = gcdSalesTarget.ApplyStaDate;
            gcdSalesTargetWork.ApplyEndDate = gcdSalesTarget.ApplyEndDate;
            gcdSalesTargetWork.SalesTargetMoney = gcdSalesTarget.GcdSalesTargetMoney;
            gcdSalesTargetWork.SalesTargetProfit = gcdSalesTarget.GcdSalesTargetProfit;
            gcdSalesTargetWork.SalesTargetCount = gcdSalesTarget.GcdSalesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//gcdSalesTargetWork.WeekdayRatio = gcdSalesTarget.WeekdayRatio;
            //gcdSalesTargetWork.SatSunRatio = gcdSalesTarget.SatSunRatio;
			//----- ueno del---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            gcdSalesTargetWork.BLGroupCode = gcdSalesTarget.BLGroupCode;
            gcdSalesTargetWork.BLGoodsCode = gcdSalesTarget.BLCode;
            gcdSalesTargetWork.SalesCode = gcdSalesTarget.SalesTypeCode;
            gcdSalesTargetWork.EnterpriseGanreCode = gcdSalesTarget.ItemTypeCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

            return gcdSalesTargetWork;
        }

        #endregion
    }
}
