using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// 発行確認一覧表アクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 発行確認一覧表アクセスクラス</br>
    /// <br>Programmer : 30009 渋谷 大輔</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br>UpdateNote : 2008.12.24  30009 渋谷 大輔</br>
    /// <br>           : ・不具合の修正</br>
    /// <br>UpdateNote : 2009.01.13  30009 渋谷 大輔</br>
    /// <br>           : ・不具合の修正</br>
    /// <br></br>
    /// </remarks>
    public class PublicationConfListAcs
    {
        # region Constractor
        /// <summary>
        /// 発行確認一覧表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発行確認一覧表アクセスクラス</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// <br></br>
        /// </remarks>
        public PublicationConfListAcs()
        {
            this._iPublicationConfOrderWorkDB = (IPublicationConfOrderWorkDB)MediationPublicationConfOrderWorkDB.GetPublicationConfOrderWorkDB();
        }
        # endregion

        # region Static Constractor
        /// <summary>
		/// 発行確認一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発行確認一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		static PublicationConfListAcs()
		{
			// 従業員情報
			stc_Employee		= null;

			// 帳票出力設定データクラス
			stc_PrtOutSet		= null;
			
			// 帳票出力設定アクセスクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null) stc_Employee = loginEmployee.Clone();
		}
		# endregion

		# region Private Menbers
		/// <summary> 発行確認一覧表リモートインターフェース </summary>
        IPublicationConfOrderWorkDB _iPublicationConfOrderWorkDB;
		/// <summary> 在庫調整確認データセット </summary>
        private DataSet _PublicationConfDs;

        # endregion

		# region Static Private Member
		/// <summary> 従業員情報 </summary>
		private static Employee stc_Employee;
		/// <summary> 帳票出力設定データクラス </summary>
		private static PrtOutSet stc_PrtOutSet;
		/// <summary> 帳票出力設定アクセスクラス </summary>
		private static PrtOutSetAcs stc_PrtOutSetAcs;
		# endregion

		# region Public Property
		/// <summary>
		/// 在庫調整確認データセット(get)
		/// </summary>
        public DataSet PublicationConfDs
		{
            get { return this._PublicationConfDs; }
		}
		# endregion

		# region Public Method
		/// <summary>
		/// 在庫調整確認データ取得
		/// </summary>
        /// <param name="publicationConfOrderCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫調整確認データを取得する。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        public int SearchConfirmPublicationConf(PublicationConfOrderCndtn publicationConfOrderCndtn, out string errMsg)
		{
            return this.SearchConfirmPublicationConfProc(publicationConfOrderCndtn, out errMsg);
		}
		# endregion

		# region Public static Method
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";

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
		# endregion

		# region Private Method
		/// <summary>
		/// 発行確認データ取得
		/// </summary>
        /// <param name="publicationConfOrderCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫調整確認データを取得する。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private int SearchConfirmPublicationConfProc(PublicationConfOrderCndtn publicationConfOrderCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
                PMUOE02049EA.CreateDataTablePublicationConfDtl(ref this._PublicationConfDs);
                PublicationConfOrderCndtnWork publicationConfOrderCndtnWork = new PublicationConfOrderCndtnWork();

				// 抽出条件展開処理
                status = this.DevConfirmPublicationConfCndtn(publicationConfOrderCndtn, out publicationConfOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
                object retpublicationConfList = null;
                status = this._iPublicationConfOrderWorkDB.Search(out retpublicationConfList, (object)publicationConfOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //test @@status = this.GetTestData(out retpublicationConfList);//@@test

                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

						// 発行確認データ展開処理
                        this.DevPublicationConfData(publicationConfOrderCndtn, this._PublicationConfDs.Tables[PMUOE02049EA.ct_Tbl_PublicationConfDtl], (ArrayList)retpublicationConfList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
                        errMsg = "発行確認データの取得に失敗しました。";
						break;
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

		# region テスト用


        /// <summary>
        /// テスト用発行確認データ取得
        /// </summary>
        /// <param name="retpublicationConfList"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : テスト用在庫調整確認データを取得する。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private int GetTestData(out object retpublicationConfList)
        {
            ArrayList list = new ArrayList();

            PublicationConfResultWork work01 = new PublicationConfResultWork();
            work01.SectionCode = "01";
            work01.SectionGuideSnm = "拠点01";
            work01.OnlineNo = 100;
            work01.OnlineRowNo = 0;
            work01.SystemDivCd = 0;
            work01.GoodsNo = "30009-ACB100";
            work01.WarehouseCode = "0001";
            work01.WarehouseShelfNo = "01";
            work01.ListPrice = 10000;
            work01.AcceptAnOrderCnt = 100;
            work01.UOESectOutGoodsCnt = 120;
            work01.BOShipmentCnt1 = 150;
            work01.BOShipmentCnt2 = 155;
            work01.BOShipmentCnt3 = 156;
            work01.MakerFollowCnt = 158;
            work01.EOAlwcCount = 156;
            work01.UOESupplierName = "UOE発注先";
            work01.ReceiveDate = DateTime.Now.Date;
            work01.UoeRemark1 = "rem01";
            work01.UoeRemark2 = "rem02";
            work01.AnswerPartsNo = "30009-ACB100";
            work01.AnswerPartsName = "品名30009-ACB100品名";
            work01.AnswerListPrice = 10000;
            work01.AnswerSalesUnitCost = 8000;
            work01.UOESectionSlipNo = "1234567";
            work01.BOSlipNo1 = "111111";
            work01.BOSlipNo2 = "222222";
            work01.BOSlipNo3 = "333333";
            work01.BOManagementNo = "444444";
            list.Add(work01);

            PublicationConfResultWork work02 = new PublicationConfResultWork();
            work02.SectionCode = "01";
            work02.SectionGuideSnm = "拠点01";
            work02.OnlineNo = 100;
            work02.OnlineRowNo = 1;
            work02.SystemDivCd = 0;
            work02.GoodsNo = "30009-ACB100";
            work02.WarehouseCode = "0001";
            work02.WarehouseShelfNo = "01";
            work02.ListPrice = 10000;
            work02.AcceptAnOrderCnt = 100;
            work02.UOESectOutGoodsCnt = 120;
            work02.BOShipmentCnt1 = 150;
            work02.BOShipmentCnt2 = 155;
            work02.BOShipmentCnt3 = 156;
            work02.MakerFollowCnt = 158;
            work02.EOAlwcCount = 156;
            work02.UOESupplierName = "UOE発注先";
            work02.ReceiveDate = DateTime.Now.Date;
            work02.UoeRemark1 = "rem01";
            work02.UoeRemark2 = "rem02";
            work02.AnswerPartsNo = "30009-ACB100";
            work02.AnswerPartsName = "品名30009-ACB100品名";
            work02.AnswerListPrice = 10000;
            work02.AnswerSalesUnitCost = 8000;
            work02.UOESectionSlipNo = "1234567";
            work02.BOSlipNo1 = "111111";
            work02.BOSlipNo2 = "222222";
            work02.BOSlipNo3 = "333333";
            work02.BOManagementNo = "444444";
            list.Add(work02);

            PublicationConfResultWork work03 = new PublicationConfResultWork();
            work03.SectionCode = "01";
            work03.SectionGuideSnm = "拠点01";
            work03.OnlineNo = 100;
            work03.OnlineRowNo = 2;
            work03.SystemDivCd = 0;
            work03.GoodsNo = "30009-ACB100";
            work03.WarehouseCode = "0001";
            work03.WarehouseShelfNo = "01";
            work03.ListPrice = 10000;
            work03.AcceptAnOrderCnt = 100;
            work03.UOESectOutGoodsCnt = 120;
            work03.BOShipmentCnt1 = 150;
            work03.BOShipmentCnt2 = 155;
            work03.BOShipmentCnt3 = 156;
            work03.MakerFollowCnt = 158;
            work03.EOAlwcCount = 156;
            work03.UOESupplierName = "UOE発注先";
            work03.ReceiveDate = DateTime.Now.Date;
            work03.UoeRemark1 = "rem01";
            work03.UoeRemark2 = "rem02";
            work03.AnswerPartsNo = "30009-ACB100";
            work03.AnswerPartsName = "品名30009-ACB100品名";
            work03.AnswerListPrice = 10000;
            work03.AnswerSalesUnitCost = 8000;
            work03.UOESectionSlipNo = "1234567";
            work03.BOSlipNo1 = "111111";
            work03.BOSlipNo2 = "222222";
            work03.BOSlipNo3 = "333333";
            work03.BOManagementNo = "444444";
            list.Add(work03);

            PublicationConfResultWork work04 = new PublicationConfResultWork();
            work04.SectionCode = "01";
            work04.SectionGuideSnm = "拠点01";
            work04.OnlineNo = 100;
            work04.OnlineRowNo = 3;
            work04.SystemDivCd = 0;
            work04.GoodsNo = "30009-ACB100";
            work04.WarehouseCode = "0001";
            work04.WarehouseShelfNo = "01";
            work04.ListPrice = 10000;
            work04.AcceptAnOrderCnt = 100;
            work04.UOESectOutGoodsCnt = 120;
            work04.BOShipmentCnt1 = 150;
            work04.BOShipmentCnt2 = 155;
            work04.BOShipmentCnt3 = 156;
            work04.MakerFollowCnt = 158;
            work04.EOAlwcCount = 156;
            work04.UOESupplierName = "UOE発注先";
            work04.ReceiveDate = DateTime.Now.Date;
            work04.UoeRemark1 = "rem01";
            work04.UoeRemark2 = "rem02";
            work04.AnswerPartsNo = "30009-ACB100";
            work04.AnswerPartsName = "品名30009-ACB100品名";
            work04.AnswerListPrice = 10000;
            work04.AnswerSalesUnitCost = 8000;
            work04.UOESectionSlipNo = "1234567";
            work04.BOSlipNo1 = "111111";
            work04.BOSlipNo2 = "222222";
            work04.BOSlipNo3 = "333333";
            work04.BOManagementNo = "444444";
            list.Add(work04);

            PublicationConfResultWork work05 = new PublicationConfResultWork();
            work05.SectionCode = "01";
            work05.SectionGuideSnm = "拠点01";
            work05.OnlineNo = 100;
            work05.OnlineRowNo = 4;
            work05.SystemDivCd = 0;
            work05.GoodsNo = "30009-ACB100";
            work05.WarehouseCode = "0001";
            work05.WarehouseShelfNo = "01";
            work05.ListPrice = 10000;
            work05.AcceptAnOrderCnt = 100;
            work05.UOESectOutGoodsCnt = 120;
            work05.BOShipmentCnt1 = 150;
            work05.BOShipmentCnt2 = 155;
            work05.BOShipmentCnt3 = 156;
            work05.MakerFollowCnt = 158;
            work05.EOAlwcCount = 156;
            work05.UOESupplierName = "UOE発注先";
            work05.ReceiveDate = DateTime.Now.Date;
            work05.UoeRemark1 = "rem01";
            work05.UoeRemark2 = "rem02";
            work05.AnswerPartsNo = "30009-ACB100";
            work05.AnswerPartsName = "品名30009-ACB100品名";
            work05.AnswerListPrice = 10000;
            work05.AnswerSalesUnitCost = 8000;
            work05.UOESectionSlipNo = "1234567";
            work05.BOSlipNo1 = "111111";
            work05.BOSlipNo2 = "222222";
            work05.BOSlipNo3 = "333333";
            work05.BOManagementNo = "444444";
            list.Add(work05);

            PublicationConfResultWork work06 = new PublicationConfResultWork();
            work06.SectionCode = "01";
            work06.SectionGuideSnm = "拠点01";
            work06.OnlineNo = 100;
            work06.OnlineRowNo = 5;
            work06.SystemDivCd = 0;
            work06.GoodsNo = "30009-ACB100";
            work06.WarehouseCode = "0001";
            work06.WarehouseShelfNo = "01";
            work06.ListPrice = 10000;
            work06.AcceptAnOrderCnt = 100;
            work06.UOESectOutGoodsCnt = 120;
            work06.BOShipmentCnt1 = 150;
            work06.BOShipmentCnt2 = 155;
            work06.BOShipmentCnt3 = 156;
            work06.MakerFollowCnt = 158;
            work06.EOAlwcCount = 156;
            work06.UOESupplierName = "UOE発注先";
            work06.ReceiveDate = DateTime.Now.Date;
            work06.UoeRemark1 = "rem01";
            work06.UoeRemark2 = "rem02";
            work06.AnswerPartsNo = "30009-ACB100";
            work06.AnswerPartsName = "品名30009-ACB100品名";
            work06.AnswerListPrice = 10000;
            work06.AnswerSalesUnitCost = 8000;
            work06.UOESectionSlipNo = "1234567";
            work06.BOSlipNo1 = "111111";
            work06.BOSlipNo2 = "222222";
            work06.BOSlipNo3 = "333333";
            work06.BOManagementNo = "444444";
            list.Add(work06);

            PublicationConfResultWork work11 = new PublicationConfResultWork();
            work11.SectionCode = "02";
            work11.SectionGuideSnm = "拠点02";
            work11.OnlineNo = 222;
            work11.OnlineRowNo = 0;
            work11.SystemDivCd = 0;
            work11.GoodsNo = "30009-ACB100";
            work11.WarehouseCode = "0001";
            work11.WarehouseShelfNo = "01";
            work11.ListPrice = 10000;
            work11.AcceptAnOrderCnt = 100;
            work11.UOESectOutGoodsCnt = 120;
            work11.BOShipmentCnt1 = 150;
            work11.BOShipmentCnt2 = 155;
            work11.BOShipmentCnt3 = 156;
            work11.MakerFollowCnt = 158;
            work11.EOAlwcCount = 156;
            work11.UOESupplierName = "UOE発注先";
            work11.ReceiveDate = DateTime.Now.Date;
            work11.UoeRemark1 = "rem01";
            work11.UoeRemark2 = "rem02";
            work11.AnswerPartsNo = "30009-ACB100";
            work11.AnswerPartsName = "品名30009-ACB100品名";
            work11.AnswerListPrice = 10000;
            work11.AnswerSalesUnitCost = 8000;
            work11.UOESectionSlipNo = "1234567";
            work11.BOSlipNo1 = "111111";
            work11.BOSlipNo2 = "222222";
            work11.BOSlipNo3 = "333333";
            work11.BOManagementNo = "444444";
            list.Add(work11);

            PublicationConfResultWork work12 = new PublicationConfResultWork();
            work12.SectionCode = "02";
            work12.SectionGuideSnm = "拠点02";
            work12.OnlineNo = 222;
            work12.OnlineRowNo = 1;
            work12.SystemDivCd = 0;
            work12.GoodsNo = "30009-ACB100";
            work12.WarehouseCode = "0001";
            work12.WarehouseShelfNo = "01";
            work12.ListPrice = 10000;
            work12.AcceptAnOrderCnt = 100;
            work12.UOESectOutGoodsCnt = 120;
            work12.BOShipmentCnt1 = 150;
            work12.BOShipmentCnt2 = 155;
            work12.BOShipmentCnt3 = 156;
            work12.MakerFollowCnt = 158;
            work12.EOAlwcCount = 156;
            work12.UOESupplierName = "UOE発注先";
            work12.ReceiveDate = DateTime.Now.Date;
            work12.UoeRemark1 = "rem01";
            work12.UoeRemark2 = "rem02";
            work12.AnswerPartsNo = "30009-ACB100";
            work12.AnswerPartsName = "品名30009-ACB100品名";
            work12.AnswerListPrice = 10000;
            work12.AnswerSalesUnitCost = 8000;
            work12.UOESectionSlipNo = "1234567";
            work12.BOSlipNo1 = "111111";
            work12.BOSlipNo2 = "222222";
            work12.BOSlipNo3 = "333333";
            work12.BOManagementNo = "444444";
            list.Add(work12);

            PublicationConfResultWork work13 = new PublicationConfResultWork();
            work13.SectionCode = "02";
            work13.SectionGuideSnm = "拠点02";
            work13.OnlineNo = 222;
            work13.OnlineRowNo = 2;
            work13.SystemDivCd = 0;
            work13.GoodsNo = "30009-ACB100";
            work13.WarehouseCode = "0001";
            work13.WarehouseShelfNo = "01";
            work13.ListPrice = 10000;
            work13.AcceptAnOrderCnt = 100;
            work13.UOESectOutGoodsCnt = 120;
            work13.BOShipmentCnt1 = 150;
            work13.BOShipmentCnt2 = 155;
            work13.BOShipmentCnt3 = 156;
            work13.MakerFollowCnt = 158;
            work13.EOAlwcCount = 156;
            work13.UOESupplierName = "UOE発注先";
            work13.ReceiveDate = DateTime.Now.Date;
            work13.UoeRemark1 = "rem01";
            work13.UoeRemark2 = "rem02";
            work13.AnswerPartsNo = "30009-ACB100";
            work13.AnswerPartsName = "品名30009-ACB100品名";
            work13.AnswerListPrice = 10000;
            work13.AnswerSalesUnitCost = 8000;
            work13.UOESectionSlipNo = "1234567";
            work13.BOSlipNo1 = "111111";
            work13.BOSlipNo2 = "222222";
            work13.BOSlipNo3 = "333333";
            work13.BOManagementNo = "444444";
            list.Add(work13);

            PublicationConfResultWork work14 = new PublicationConfResultWork();
            work14.SectionCode = "02";
            work14.SectionGuideSnm = "拠点02";
            work14.OnlineNo = 222;
            work14.OnlineRowNo = 3;
            work14.SystemDivCd = 0;
            work14.GoodsNo = "30009-ACB100";
            work14.WarehouseCode = "0001";
            work14.WarehouseShelfNo = "01";
            work14.ListPrice = 10000;
            work14.AcceptAnOrderCnt = 100;
            work14.UOESectOutGoodsCnt = 120;
            work14.BOShipmentCnt1 = 150;
            work14.BOShipmentCnt2 = 155;
            work14.BOShipmentCnt3 = 156;
            work14.MakerFollowCnt = 158;
            work14.EOAlwcCount = 156;
            work14.UOESupplierName = "UOE発注先";
            work14.ReceiveDate = DateTime.Now.Date;
            work14.UoeRemark1 = "rem01";
            work14.UoeRemark2 = "rem02";
            work14.AnswerPartsNo = "30009-ACB100";
            work14.AnswerPartsName = "品名30009-ACB100品名";
            work14.AnswerListPrice = 10000;
            work14.AnswerSalesUnitCost = 8000;
            work14.UOESectionSlipNo = "1234567";
            work14.BOSlipNo1 = "111111";
            work14.BOSlipNo2 = "222222";
            work14.BOSlipNo3 = "333333";
            work14.BOManagementNo = "444444";
            list.Add(work14);

            PublicationConfResultWork work15 = new PublicationConfResultWork();
            work15.SectionCode = "02";
            work15.SectionGuideSnm = "拠点02";
            work15.OnlineNo = 222;
            work15.OnlineRowNo = 4;
            work15.SystemDivCd = 0;
            work15.GoodsNo = "30009-ACB100";
            work15.WarehouseCode = "0001";
            work15.WarehouseShelfNo = "01";
            work15.ListPrice = 10000;
            work15.AcceptAnOrderCnt = 100;
            work15.UOESectOutGoodsCnt = 120;
            work15.BOShipmentCnt1 = 150;
            work15.BOShipmentCnt2 = 155;
            work15.BOShipmentCnt3 = 156;
            work15.MakerFollowCnt = 158;
            work15.EOAlwcCount = 156;
            work15.UOESupplierName = "UOE発注先";
            work15.ReceiveDate = DateTime.Now.Date;
            work15.UoeRemark1 = "rem01";
            work15.UoeRemark2 = "rem02";
            work15.AnswerPartsNo = "30009-ACB100";
            work15.AnswerPartsName = "品名30009-ACB100品名";
            work15.AnswerListPrice = 10000;
            work15.AnswerSalesUnitCost = 8000;
            work15.UOESectionSlipNo = "1234567";
            work15.BOSlipNo1 = "111111";
            work15.BOSlipNo2 = "222222";
            work15.BOSlipNo3 = "333333";
            work15.BOManagementNo = "444444";
            list.Add(work15);

            PublicationConfResultWork work16 = new PublicationConfResultWork();
            work16.SectionCode = "02";
            work16.SectionGuideSnm = "拠点02";
            work16.OnlineNo = 222;
            work16.OnlineRowNo = 5;
            work16.SystemDivCd = 0;
            work16.GoodsNo = "30009-ACB100";
            work16.WarehouseCode = "0001";
            work16.WarehouseShelfNo = "01";
            work16.ListPrice = 10000;
            work16.AcceptAnOrderCnt = 100;
            work16.UOESectOutGoodsCnt = 120;
            work16.BOShipmentCnt1 = 150;
            work16.BOShipmentCnt2 = 155;
            work16.BOShipmentCnt3 = 156;
            work16.MakerFollowCnt = 158;
            work16.EOAlwcCount = 156;
            work16.UOESupplierName = "UOE発注先";
            work16.ReceiveDate = DateTime.Now.Date;
            work16.UoeRemark1 = "rem01";
            work16.UoeRemark2 = "rem02";
            work16.AnswerPartsNo = "30009-ACB100";
            work16.AnswerPartsName = "品名30009-ACB100品名";
            work16.AnswerListPrice = 10000;
            work16.AnswerSalesUnitCost = 8000;
            work16.UOESectionSlipNo = "1234567";
            work16.BOSlipNo1 = "111111";
            work16.BOSlipNo2 = "222222";
            work16.BOSlipNo3 = "333333";
            work16.BOManagementNo = "444444";
            list.Add(work16);

            retpublicationConfList = (object)list;
            return 0;
        }
        
		# endregion

		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
        /// <param name="publicationConfOrderCndtn">UI抽出条件クラス</param>
        /// <param name="publicationConfOrderCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>SortOrder</returns>
		/// <remarks>
		/// <br>Note       : リモート用の抽出条件に展開します。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private int DevConfirmPublicationConfCndtn(PublicationConfOrderCndtn publicationConfOrderCndtn, out PublicationConfOrderCndtnWork publicationConfOrderCndtnWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			errMsg = string.Empty;
            publicationConfOrderCndtnWork = new PublicationConfOrderCndtnWork();

            try
            {
                // 企業コード
                publicationConfOrderCndtnWork.EnterpriseCode = publicationConfOrderCndtn.EnterpriseCode;

                // システム区分
                publicationConfOrderCndtnWork.SystemDivCd = publicationConfOrderCndtn.SystemDivCd;

                // 拠点コード(複数指定)
                // 2008.12.24 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //publicationConfOrderCndtnWork.SectionCodes = publicationConfOrderCndtn.SectionCodes;
                if (publicationConfOrderCndtn.SectionCodes.Length != 0)
                {
                    if (publicationConfOrderCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                    }
                    else
                    {
                        publicationConfOrderCndtnWork.SectionCodes = publicationConfOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                }
                // 2008.12.24 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 受信日付
                publicationConfOrderCndtnWork.St_ReceiveDate = publicationConfOrderCndtn.St_ReceiveDate;
                publicationConfOrderCndtnWork.Ed_ReceiveDate = publicationConfOrderCndtn.Ed_ReceiveDate;

                // 印刷条件
                publicationConfOrderCndtnWork.PrintCndtn = publicationConfOrderCndtn.PrintCndtn;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
		}

		/// <summary>
        /// 発行確認データ展開処理
		/// </summary>
        /// <param name="publicationConfOrderCndtn">UI抽出条件クラス</param>
        /// <param name="publicationConfDt">展開対象DataTable</param>
        /// <param name="publicationConfWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 発行確認データを展開します。</br>
        /// <br>Programmer : 30009 渋谷 大輔</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private void DevPublicationConfData(PublicationConfOrderCndtn publicationConfOrderCndtn, DataTable publicationConfDt, ArrayList publicationConfWork)
		{
            DataRow dr;

            foreach (PublicationConfResultWork publicationConfResultWork in publicationConfWork)
            {
                dr = publicationConfDt.NewRow();
                #region 在庫調整データ展開
                
                // 拠点コード
                dr[PMUOE02049EA.ct_Col_SectionCode] = publicationConfResultWork.SectionCode;

                // 拠点ガイド名称
                // 2009.01.13 UPD 拠点コードも出力する >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //dr[PMUOE02049EA.ct_Col_SectionGuideNm] = publicationConfResultWork.SectionGuideSnm;
                dr[PMUOE02049EA.ct_Col_SectionGuideNm] = publicationConfResultWork.SectionCode.ToString() + " " + publicationConfResultWork.SectionGuideSnm;
                // 2009.01.13 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      
                // オンライン番号
                // 2009.01.13 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //dr[PMUOE02049EA.ct_Col_OnlineNo] = publicationConfResultWork.OnlineNo;
                dr[PMUOE02049EA.ct_Col_OnlineNo] = publicationConfResultWork.OnlineNo % 1000000;
                // 2009.01.13 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // オンライン行番号
                dr[PMUOE02049EA.ct_Col_OnlineRowNo] = publicationConfResultWork.OnlineRowNo;

                // システム区分
                dr[PMUOE02049EA.ct_Col_SystemDivCd] = publicationConfResultWork.SystemDivCd;

                // システム区分名称
                dr[PMUOE02049EA.ct_Col_SystemDivName] = PMUOE02049EA.GetSystemDivNm(publicationConfResultWork.SystemDivCd);

                // 商品番号
                dr[PMUOE02049EA.ct_Col_GoodsNo] = publicationConfResultWork.GoodsNo;

                // 倉庫コード
                dr[PMUOE02049EA.ct_Col_WarehouseCode] = publicationConfResultWork.WarehouseCode;

                // 倉庫棚番
                dr[PMUOE02049EA.ct_Col_WarehouseShelfNo] = publicationConfResultWork.WarehouseShelfNo;

                // 定価(浮動)
                dr[PMUOE02049EA.ct_Col_ListPrice] = publicationConfResultWork.ListPrice;

                // 受注数量
                dr[PMUOE02049EA.ct_Col_AcceptAnOrderCnt] = publicationConfResultWork.AcceptAnOrderCnt;

                // UOE拠点出庫数
                dr[PMUOE02049EA.ct_Col_UOESectOutGoodsCnt] = publicationConfResultWork.UOESectOutGoodsCnt;

                // BO出庫数1
                dr[PMUOE02049EA.ct_Col_BOShipmentCnt1] = publicationConfResultWork.BOShipmentCnt1;

                // BO出庫数2
                dr[PMUOE02049EA.ct_Col_BOShipmentCnt2] = publicationConfResultWork.BOShipmentCnt2;

                // BO出庫数3
                dr[PMUOE02049EA.ct_Col_BOShipmentCnt3] = publicationConfResultWork.BOShipmentCnt3;

                // メーカーフォロー数
                dr[PMUOE02049EA.ct_Col_MakerFollowCnt] = publicationConfResultWork.MakerFollowCnt;

                // EO引当数
                dr[PMUOE02049EA.ct_Col_EOAlwcCount] = publicationConfResultWork.EOAlwcCount;

                // UOE発注先名称
                dr[PMUOE02049EA.ct_Col_UOESupplierName] = publicationConfResultWork.UOESupplierName;

                // 受信日付
                dr[PMUOE02049EA.ct_Col_ReceiveDate] = publicationConfResultWork.ReceiveDate;

                // UOEリマーク1
                dr[PMUOE02049EA.ct_Col_UoeRemark1] = publicationConfResultWork.UoeRemark1;

                // UOEリマーク2
                dr[PMUOE02049EA.ct_Col_UoeRemark2] = publicationConfResultWork.UoeRemark2;

                // 回答品番
                dr[PMUOE02049EA.ct_Col_AnswerPartsNo] = publicationConfResultWork.AnswerPartsNo;

                // 回答品名
                dr[PMUOE02049EA.ct_Col_AnswerPartsName] = publicationConfResultWork.AnswerPartsName;

                // 回答定価
                dr[PMUOE02049EA.ct_Col_AnswerListPrice] = publicationConfResultWork.AnswerListPrice;

                // 回答原価単価
                dr[PMUOE02049EA.ct_Col_AnswerSalesUnitCost] = publicationConfResultWork.AnswerSalesUnitCost;

                // UOE拠点伝票番号
                dr[PMUOE02049EA.ct_Col_UOESectionSlipNo] = publicationConfResultWork.UOESectionSlipNo;

                // BO伝票番号1
                dr[PMUOE02049EA.ct_Col_BOSlipNo1] = publicationConfResultWork.BOSlipNo1;

                // BO伝票番号2
                dr[PMUOE02049EA.ct_Col_BOSlipNo2] = publicationConfResultWork.BOSlipNo2;

                // BO伝票番号3
                dr[PMUOE02049EA.ct_Col_BOSlipNo3] = publicationConfResultWork.BOSlipNo3;

                // BO管理番号
                dr[PMUOE02049EA.ct_Col_BOManagementNo] = publicationConfResultWork.BOManagementNo;

                // チェック内容
                if (publicationConfResultWork.AcceptAnOrderCnt != (publicationConfResultWork.UOESectOutGoodsCnt   // UOE拠点出庫数
                                                                 + publicationConfResultWork.BOShipmentCnt1       // BO出庫数1
                                                                 + publicationConfResultWork.BOShipmentCnt2       // BO出庫数2
                                                                 + publicationConfResultWork.BOShipmentCnt3       // BO出庫数3
                                                                 + publicationConfResultWork.MakerFollowCnt       // メーカーフォロー数
                                                                 + publicationConfResultWork.EOAlwcCount          // EO引当数
                                                                 ))
                {
                    // 数量不足
                    if (publicationConfResultWork.ListPrice != publicationConfResultWork.AnswerListPrice) 
                    {
                        // 定価不一致
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "数量不足/定価不一致";
                    }
                    else
                    {
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "数量不足";
                    }
                }
                else
                {
                    if (publicationConfResultWork.ListPrice != publicationConfResultWork.AnswerListPrice)
                    {
                        // 定価不一致
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "定価不一致";
                    }
                    else
                    {
                        dr[PMUOE02049EA.ct_Col_CheckCntsNm] = "";
                    }
                }

                #endregion

                // TableにAdd
                publicationConfDt.Rows.Add(dr);

            }
		}

        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <returns>四捨五入されたdouble</returns>
        private static Int64 Round(double parameter)
        {
            // 整数部　四捨五入
            return (Int64)Round(parameter, 0, 5);
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <returns>四捨五入されたdouble</returns>
        public static double Round(double parameter, int digits)
        {
            // 四捨五入
            return Round(parameter, digits, 5);
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <param name="divide">切り上げる境界の値 1～9　(ex. 5→四捨五入)</param>
        /// <returns>四捨五入されたdouble</returns>
        public static double Round(double parameter, int digits, int divide)
        {
            decimal param = (decimal)parameter;
            decimal dCoef = (decimal)Math.Pow(10, digits);
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if (param > 0)
            {
                // 0.5を足して「＋のときの切り捨て」（ゼロに近づける）
                param = Math.Floor((param * dCoef) + dDiv) / dCoef;
            }
            else
            {
                // -0.5を足して「－のときの切り捨て」（ゼロに近づける）
                param = Math.Ceiling((param * dCoef) - dDiv) / dCoef;
            }
            return (double)param;
        }
		# endregion
	}
}
