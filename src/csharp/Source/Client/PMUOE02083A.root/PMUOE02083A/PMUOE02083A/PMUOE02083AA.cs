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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注送信エラーリストアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注送信エラーリストで使用するデータを取得する。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.10</br>
    /// <br></br>
    /// </remarks>
    public class SupplierSendErOrderAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 発注送信エラーリストアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発注送信エラーリストアクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30413 犬飼</br>
	    /// <br>Date       : 2008.12.10</br>
		/// </remarks>
		public SupplierSendErOrderAcs()
		{
            this._iSupplierSendErOrderWorkDB = (ISupplierSendErOrderWorkDB)MediationSupplierSendErOrderWorkDB.GetSupplierSendErOrderWorkDB();
            this._iUOEOrderDtlDB = (IUOEOrderDtlDB)MediationUOEOrderDtlDB.GetUOEOrderDtlDB();
		}

		/// <summary>
        /// 発注送信エラーリスト表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発注送信エラーリスト表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        static SupplierSendErOrderAcs()
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
        #endregion ■ Static Member

        #region ■ Private Member
        ISupplierSendErOrderWorkDB _iSupplierSendErOrderWorkDB;         // 発注送信エラーリストリモート
        IUOEOrderDtlDB _iUOEOrderDtlDB;         // UOE発注データ更新リモート

        private DataSet _supplierSendErDs;				        // 発注送信エラーリストデータセット

        // 発注送信エラーリストの抽出結果を保存
        private static ArrayList _stc_SupplierSendErResultWorkList;

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// 発注送信エラーリストデータセット(読み取り専用)
        /// </summary>
        public DataSet SupplierSendErDs
        {
            get { return this._supplierSendErDs; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 発注送信エラーリストデータ取得
        /// <summary>
        /// 発注送信エラーリストデータ取得
        /// </summary>
        /// <param name="supplierSendErOrderCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する発注送信エラーリストデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        public int SearchSupplierSendErOrder(SupplierSendErOrderCndtn supplierSendErOrderCndtn, out string errMsg)
        {
            return this.SearchSupplierSendErOrderProc(supplierSendErOrderCndtn, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 発注送信エラーリストデータ取得
        /// <summary>
        /// 発注送信エラーリストデータ取得
        /// </summary>
        /// <param name="supplierSendErOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する発注送信エラーリストデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        private int SearchSupplierSendErOrderProc(SupplierSendErOrderCndtn supplierSendErOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // 更新用の発注送信エラーリストをクリア
                _stc_SupplierSendErResultWorkList = new ArrayList();

                // DataTable Create ----------------------------------------------------------
                SupplierSendErResult.CreateDataTableResultSupplierSendEr(ref this._supplierSendErDs);
                SupplierSendErOrderCndtnWork supplierSendErOrderCndtnWork = new SupplierSendErOrderCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevSupplierSendErOrder(supplierSendErOrderCndtn, out supplierSendErOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                status = this._iSupplierSendErOrderWorkDB.Search(out retList, (object)supplierSendErOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevSupplierSendErOrderData(supplierSendErOrderCndtn, this._supplierSendErDs.Tables[SupplierSendErResult.Col_Tbl_Result_SupplierSendEr], (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "発注送信エラーリストデータの取得に失敗しました。";
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
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="supplierSendErOrderCndtn">UI抽出条件クラス</param>
        /// <param name="supplierSendErOrderCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevSupplierSendErOrder(SupplierSendErOrderCndtn supplierSendErOrderCndtn, out SupplierSendErOrderCndtnWork supplierSendErOrderCndtnWork, out string errMsg)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            supplierSendErOrderCndtnWork = new SupplierSendErOrderCndtnWork();

            try
            {
                // 企業コード
                supplierSendErOrderCndtnWork.EnterpriseCode = supplierSendErOrderCndtn.EnterpriseCode;

                // 抽出条件パラメータセット
                if (supplierSendErOrderCndtn.SectionCodes.Length != 0)
                {
                    if (supplierSendErOrderCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        supplierSendErOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        supplierSendErOrderCndtnWork.SectionCodes = supplierSendErOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    supplierSendErOrderCndtnWork.SectionCodes = null;
                }


                supplierSendErOrderCndtnWork.St_UOESupplierCd = supplierSendErOrderCndtn.St_UOESupplierCd;          // 開始UOE発注先コード
                supplierSendErOrderCndtnWork.Ed_UOESupplierCd = supplierSendErOrderCndtn.Ed_UOESupplierCd;          // 終了UOE発注先コード
                
                supplierSendErOrderCndtnWork.St_ReceiveDate = supplierSendErOrderCndtn.St_ReceiveDate;	            // 開始受信日付
                supplierSendErOrderCndtnWork.Ed_ReceiveDate = supplierSendErOrderCndtn.Ed_ReceiveDate;	            // 終了受信日付

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 発注送信エラーリストデータ展開処理
        /// <summary>
        /// 発注送信エラーリストデータ展開処理
        /// </summary>
        /// <param name="supplierSendErOrderCndtn">UI抽出条件クラス</param>
        /// <param name="supplierSendErOrderDt">展開対象DataTable</param>
        /// <param name="supplierSendErResultWorkList">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 発注送信エラーリストデータを展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        private void DevSupplierSendErOrderData(SupplierSendErOrderCndtn supplierSendErOrderCndtn, DataTable supplierSendErOrderDt, ArrayList supplierSendErResultWorkList)
        {
            DataRow dr;

            foreach (SupplierSendErResultWork supplierSendErResultWork in supplierSendErResultWorkList)
            {
                dr = supplierSendErOrderDt.NewRow();

                // 発注送信エラーリストデータ展開
                #region 発注送信エラーリストデータ展開
                // 作成日時
                dr[SupplierSendErResult.Col_CreateDateTime] = supplierSendErResultWork.CreateDateTime;
                // 更新日時
                dr[SupplierSendErResult.Col_UpdateDateTime] = supplierSendErResultWork.UpdateDateTime;
                // 企業コード
                dr[SupplierSendErResult.Col_EnterpriseCode] = supplierSendErResultWork.EnterpriseCode;
                // GUID
                dr[SupplierSendErResult.Col_FileHeaderGuid] = supplierSendErResultWork.FileHeaderGuid;
                // 更新従業員コード
                dr[SupplierSendErResult.Col_UpdEmployeeCode] = supplierSendErResultWork.UpdEmployeeCode;
                // 更新アセンブリID1
                dr[SupplierSendErResult.Col_UpdAssemblyId1] = supplierSendErResultWork.UpdAssemblyId1;
                // 更新アセンブリID2
                dr[SupplierSendErResult.Col_UpdAssemblyId2] = supplierSendErResultWork.UpdAssemblyId2;
                // 論理削除区分
                dr[SupplierSendErResult.Col_LogicalDeleteCode] = supplierSendErResultWork.LogicalDeleteCode;
                // システム区分
                dr[SupplierSendErResult.Col_SystemDivCd] = supplierSendErResultWork.SystemDivCd;
                // UOE発注番号
                dr[SupplierSendErResult.Col_UOESalesOrderNo] = supplierSendErResultWork.UOESalesOrderNo;
                // UOE発注行番号
                dr[SupplierSendErResult.Col_UOESalesOrderRowNo] = supplierSendErResultWork.UOESalesOrderRowNo;
                // 送信端末番号
                dr[SupplierSendErResult.Col_SendTerminalNo] = supplierSendErResultWork.SendTerminalNo;
                // UOE発注先コード
                dr[SupplierSendErResult.Col_UOESupplierCd] = supplierSendErResultWork.UOESupplierCd;
                // UOE発注先名称
                dr[SupplierSendErResult.Col_UOESupplierName] = supplierSendErResultWork.UOESupplierName;
                // 通信アセンブリID
                dr[SupplierSendErResult.Col_CommAssemblyId] = supplierSendErResultWork.CommAssemblyId;
                // 通信アセンブリID
                dr[SupplierSendErResult.Col_OnlineNo] = supplierSendErResultWork.OnlineNo;
                // オンライン行番号
                dr[SupplierSendErResult.Col_OnlineRowNo] = supplierSendErResultWork.OnlineRowNo;
                // 売上日付
                dr[SupplierSendErResult.Col_SalesDate] = supplierSendErResultWork.SalesDate;
                // 入力日
                dr[SupplierSendErResult.Col_InputDay] = supplierSendErResultWork.InputDay;
                // データ更新日時
                dr[SupplierSendErResult.Col_DataUpdateDateTime] = supplierSendErResultWork.DataUpdateDateTime;
                // UOE種別
                dr[SupplierSendErResult.Col_UOEKind] = supplierSendErResultWork.UOEKind;
                // 売上伝票番号
                dr[SupplierSendErResult.Col_SalesSlipNum] = supplierSendErResultWork.SalesSlipNum;
                // 受注ステータス
                dr[SupplierSendErResult.Col_AcptAnOdrStatus] = supplierSendErResultWork.AcptAnOdrStatus;
                // 売上明細通番
                dr[SupplierSendErResult.Col_SalesSlipDtlNum] = supplierSendErResultWork.SalesSlipDtlNum;
                // 拠点コード
                dr[SupplierSendErResult.Col_SectionCode] = supplierSendErResultWork.SectionCode;
                // 拠点ガイド略称
                dr[SupplierSendErResult.Col_SectionGuideSnm] = supplierSendErResultWork.SectionGuideSnm;
                // 部門コード
                dr[SupplierSendErResult.Col_SubSectionCode] = supplierSendErResultWork.SubSectionCode;
                // 得意先コード
                dr[SupplierSendErResult.Col_CustomerCode] = supplierSendErResultWork.CustomerCode;
                // 得意先略称
                dr[SupplierSendErResult.Col_CustomerSnm] = supplierSendErResultWork.CustomerSnm;
                // レジ番号
                dr[SupplierSendErResult.Col_CashRegisterNo] = supplierSendErResultWork.CashRegisterNo;
                // 共通通番
                dr[SupplierSendErResult.Col_CommonSeqNo] = supplierSendErResultWork.CommonSeqNo;
                // 仕入形式
                dr[SupplierSendErResult.Col_SupplierFormal] = supplierSendErResultWork.SupplierFormal;
                // 仕入伝票番号
                dr[SupplierSendErResult.Col_SupplierSlipNo] = supplierSendErResultWork.SupplierSlipNo;
                // 仕入明細通番
                dr[SupplierSendErResult.Col_StockSlipDtlNum] = supplierSendErResultWork.StockSlipDtlNum;
                // BO区分
                dr[SupplierSendErResult.Col_BoCode] = supplierSendErResultWork.BoCode;
                // UOE納品区分
                dr[SupplierSendErResult.Col_UOEDeliGoodsDiv] = supplierSendErResultWork.UOEDeliGoodsDiv;
                // 納品区分名称
                dr[SupplierSendErResult.Col_DeliveredGoodsDivNm] = supplierSendErResultWork.DeliveredGoodsDivNm;
                // フォロー納品区分
                dr[SupplierSendErResult.Col_FollowDeliGoodsDiv] = supplierSendErResultWork.FollowDeliGoodsDiv;
                // フォロー納品区分名称
                dr[SupplierSendErResult.Col_FollowDeliGoodsDivNm] = supplierSendErResultWork.FollowDeliGoodsDivNm;
                // UOE指定拠点
                dr[SupplierSendErResult.Col_UOEResvdSection] = supplierSendErResultWork.UOEResvdSection;
                // UOE指定拠点名称
                dr[SupplierSendErResult.Col_UOEResvdSectionNm] = supplierSendErResultWork.UOEResvdSectionNm;
                // 従業員コード
                dr[SupplierSendErResult.Col_EmployeeCode] = supplierSendErResultWork.EmployeeCode;
                // 従業員名称
                dr[SupplierSendErResult.Col_EmployeeName] = supplierSendErResultWork.EmployeeName;
                // 商品メーカーコード
                dr[SupplierSendErResult.Col_GoodsMakerCd] = supplierSendErResultWork.GoodsMakerCd;
                // メーカー名称
                dr[SupplierSendErResult.Col_MakerName] = supplierSendErResultWork.MakerName;
                // 商品番号
                dr[SupplierSendErResult.Col_GoodsNo] = supplierSendErResultWork.GoodsNo;
                // ハイフン無商品番号
                dr[SupplierSendErResult.Col_GoodsNoNoneHyphen] = supplierSendErResultWork.GoodsNoNoneHyphen;
                // 商品名称
                dr[SupplierSendErResult.Col_GoodsName] = supplierSendErResultWork.GoodsName;
                // 倉庫コード
                dr[SupplierSendErResult.Col_WarehouseCode] = supplierSendErResultWork.WarehouseCode;
                // 倉庫名称
                dr[SupplierSendErResult.Col_WarehouseName] = supplierSendErResultWork.WarehouseName;
                // 倉庫棚番
                dr[SupplierSendErResult.Col_WarehouseShelfNo] = supplierSendErResultWork.WarehouseShelfNo;
                // 受注数量
                dr[SupplierSendErResult.Col_AcceptAnOrderCnt] = supplierSendErResultWork.AcceptAnOrderCnt;
                // 定価（浮動）
                dr[SupplierSendErResult.Col_ListPrice] = supplierSendErResultWork.ListPrice;
                // 原価単価
                dr[SupplierSendErResult.Col_SalesUnitCost] = supplierSendErResultWork.SalesUnitCost;
                // 仕入先コード
                dr[SupplierSendErResult.Col_SupplierCd] = supplierSendErResultWork.SupplierCd;
                // 仕入先略称
                dr[SupplierSendErResult.Col_SupplierSnm] = supplierSendErResultWork.SupplierSnm;
                // ＵＯＥリマーク１
                dr[SupplierSendErResult.Col_UoeRemark1] = supplierSendErResultWork.UoeRemark1;
                // ＵＯＥリマーク２
                dr[SupplierSendErResult.Col_UoeRemark2] = supplierSendErResultWork.UoeRemark2;
                // 受信日付
                dr[SupplierSendErResult.Col_ReceiveDate] = supplierSendErResultWork.ReceiveDate;
                // 受信時刻
                dr[SupplierSendErResult.Col_ReceiveTime] = supplierSendErResultWork.ReceiveTime;
                // 回答メーカーコード
                dr[SupplierSendErResult.Col_AnswerMakerCd] = supplierSendErResultWork.AnswerMakerCd;
                // 回答品番
                dr[SupplierSendErResult.Col_AnswerPartsNo] = supplierSendErResultWork.AnswerPartsNo;
                // 回答品名
                dr[SupplierSendErResult.Col_AnswerPartsName] = supplierSendErResultWork.AnswerPartsName;
                // 代替品番
                dr[SupplierSendErResult.Col_SubstPartsNo] = supplierSendErResultWork.SubstPartsNo;
                // UOE拠点出庫数
                dr[SupplierSendErResult.Col_UOESectOutGoodsCnt] = supplierSendErResultWork.UOESectOutGoodsCnt;
                // BO出庫数1
                dr[SupplierSendErResult.Col_BOShipmentCnt1] = supplierSendErResultWork.BOShipmentCnt1;
                // BO出庫数2
                dr[SupplierSendErResult.Col_BOShipmentCnt2] = supplierSendErResultWork.BOShipmentCnt2;
                // BO出庫数3
                dr[SupplierSendErResult.Col_BOShipmentCnt3] = supplierSendErResultWork.BOShipmentCnt3;
                // メーカーフォロー数
                dr[SupplierSendErResult.Col_MakerFollowCnt] = supplierSendErResultWork.MakerFollowCnt;
                // 未出庫数
                dr[SupplierSendErResult.Col_NonShipmentCnt] = supplierSendErResultWork.NonShipmentCnt;
                // UOE拠点在庫数
                dr[SupplierSendErResult.Col_UOESectStockCnt] = supplierSendErResultWork.UOESectStockCnt;
                // BO在庫数1
                dr[SupplierSendErResult.Col_BOStockCount1] = supplierSendErResultWork.BOStockCount1;
                // BO在庫数2
                dr[SupplierSendErResult.Col_BOStockCount2] = supplierSendErResultWork.BOStockCount2;
                // BO在庫数3
                dr[SupplierSendErResult.Col_BOStockCount3] = supplierSendErResultWork.BOStockCount3;
                // UOE拠点伝票番号
                dr[SupplierSendErResult.Col_UOESectionSlipNo] = supplierSendErResultWork.UOESectionSlipNo;
                // BO伝票番号１
                dr[SupplierSendErResult.Col_BOSlipNo1] = supplierSendErResultWork.BOSlipNo1;
                // BO伝票番号２
                dr[SupplierSendErResult.Col_BOSlipNo2] = supplierSendErResultWork.BOSlipNo2;
                // BO伝票番号３
                dr[SupplierSendErResult.Col_BOSlipNo3] = supplierSendErResultWork.BOSlipNo3;
                // EO引当数
                dr[SupplierSendErResult.Col_EOAlwcCount] = supplierSendErResultWork.EOAlwcCount;
                // BO管理番号
                dr[SupplierSendErResult.Col_BOManagementNo] = supplierSendErResultWork.BOManagementNo;
                // 回答定価
                dr[SupplierSendErResult.Col_AnswerListPrice] = supplierSendErResultWork.AnswerListPrice;
                // 回答原価単価
                dr[SupplierSendErResult.Col_AnswerSalesUnitCost] = supplierSendErResultWork.AnswerSalesUnitCost;
                // UOE代替マーク
                dr[SupplierSendErResult.Col_UOESubstMark] = supplierSendErResultWork.UOESubstMark;
                // UOE在庫マーク
                dr[SupplierSendErResult.Col_UOEStockMark] = supplierSendErResultWork.UOEStockMark;
                // 層別コード
                dr[SupplierSendErResult.Col_PartsLayerCd] = supplierSendErResultWork.PartsLayerCd;
                // UOE出荷拠点コード１（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEShipSectCd1] = supplierSendErResultWork.MazdaUOEShipSectCd1;
                // UOE出荷拠点コード２（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEShipSectCd2] = supplierSendErResultWork.MazdaUOEShipSectCd2;
                // UOE出荷拠点コード３（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEShipSectCd3] = supplierSendErResultWork.MazdaUOEShipSectCd3;
                // UOE拠点コード１（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd1] = supplierSendErResultWork.MazdaUOESectCd1;
                // UOE拠点コード２（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd2] = supplierSendErResultWork.MazdaUOESectCd2;
                // UOE拠点コード３（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd3] = supplierSendErResultWork.MazdaUOESectCd3;
                // UOE拠点コード４（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd4] = supplierSendErResultWork.MazdaUOESectCd4;
                // UOE拠点コード５（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd5] = supplierSendErResultWork.MazdaUOESectCd5;
                // UOE拠点コード６（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd6] = supplierSendErResultWork.MazdaUOESectCd6;
                // UOE拠点コード７（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOESectCd7] = supplierSendErResultWork.MazdaUOESectCd7;
                // UOE在庫数１（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt1] = supplierSendErResultWork.MazdaUOEStockCnt1;
                // UOE在庫数２（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt2] = supplierSendErResultWork.MazdaUOEStockCnt2;
                // UOE在庫数３（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt3] = supplierSendErResultWork.MazdaUOEStockCnt3;
                // UOE在庫数４（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt4] = supplierSendErResultWork.MazdaUOEStockCnt4;
                // UOE在庫数５（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt5] = supplierSendErResultWork.MazdaUOEStockCnt5;
                // UOE在庫数６（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt6] = supplierSendErResultWork.MazdaUOEStockCnt6;
                // UOE在庫数７（マツダ）
                dr[SupplierSendErResult.Col_MazdaUOEStockCnt7] = supplierSendErResultWork.MazdaUOEStockCnt7;
                // UOE卸コード
                dr[SupplierSendErResult.Col_UOEDistributionCd] = supplierSendErResultWork.UOEDistributionCd;
                // UOE他コード
                dr[SupplierSendErResult.Col_UOEOtherCd] = supplierSendErResultWork.UOEOtherCd;
                // UOEＨＭコード
                dr[SupplierSendErResult.Col_UOEHMCd] = supplierSendErResultWork.UOEHMCd;
                // ＢＯ数
                dr[SupplierSendErResult.Col_BOCount] = supplierSendErResultWork.BOCount;
                // UOEマークコード
                dr[SupplierSendErResult.Col_UOEMarkCode] = supplierSendErResultWork.UOEMarkCode;
                // 出荷元
                dr[SupplierSendErResult.Col_SourceShipment] = supplierSendErResultWork.SourceShipment;
                // アイテムコード
                dr[SupplierSendErResult.Col_ItemCode] = supplierSendErResultWork.ItemCode;
                // UOEチェックコード
                dr[SupplierSendErResult.Col_UOECheckCode] = supplierSendErResultWork.UOECheckCode;
                // ヘッドエラーメッセージ
                dr[SupplierSendErResult.Col_HeadErrorMassage] = supplierSendErResultWork.HeadErrorMassage;
                // ラインエラーメッセージ
                dr[SupplierSendErResult.Col_LineErrorMassage] = supplierSendErResultWork.LineErrorMassage;
                // データ送信区分
                dr[SupplierSendErResult.Col_DataSendCode] = supplierSendErResultWork.DataSendCode;
                // データ復旧区分
                dr[SupplierSendErResult.Col_DataRecoverDiv] = supplierSendErResultWork.DataRecoverDiv;
                // 入庫更新区分（拠点）
                dr[SupplierSendErResult.Col_EnterUpdDivSec] = supplierSendErResultWork.EnterUpdDivSec;
                // 入庫更新区分（BO1）
                dr[SupplierSendErResult.Col_EnterUpdDivBO1] = supplierSendErResultWork.EnterUpdDivBO1;
                // 入庫更新区分（BO2）
                dr[SupplierSendErResult.Col_EnterUpdDivBO2] = supplierSendErResultWork.EnterUpdDivBO2;
                // 入庫更新区分（BO3）
                dr[SupplierSendErResult.Col_EnterUpdDivBO3] = supplierSendErResultWork.EnterUpdDivBO3;
                // 入庫更新区分（ﾒｰｶｰ）
                dr[SupplierSendErResult.Col_EnterUpdDivMaker] = supplierSendErResultWork.EnterUpdDivMaker;
                // 入庫更新区分（EO）
                dr[SupplierSendErResult.Col_EnterUpdDivEO] = supplierSendErResultWork.EnterUpdDivEO;

                // 印刷用
                // 受信日付(印刷用)
                dr[SupplierSendErResult.Col_ReceiveDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", supplierSendErResultWork.ReceiveDate);

                // システム区分(印刷用)
                if (supplierSendErResultWork.SystemDivCd == 0)
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "手入力";
                }
                else if (supplierSendErResultWork.SystemDivCd == 1)
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "伝発";
                }
                else if (supplierSendErResultWork.SystemDivCd == 2)
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "検索";
                }
                else
                {
                    dr[SupplierSendErResult.Col_SystemDivCd_Print] = "一括";
                }

                #endregion

                // TableにAdd
                supplierSendErOrderDt.Rows.Add(dr);

                // 更新用の発注送信エラーリストに追加
                _stc_SupplierSendErResultWorkList.Add(supplierSendErResultWork);
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #region ◆ UOE発注データの更新処理
        #region ◎ UOE発注データ更新
        /// <summary>
        /// UOE発注データ更新
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 発注送信エラーのUOE発注データを更新する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public int UpdateUOEOrderDtl(out string errMsg)
        {
            return this.UpdateUOEOrderDtlProc(out errMsg);
        }
        #endregion

        #region ◎ UOE発注データ更新
        /// <summary>
        /// UOE発注データ更新
        /// </summary>
        /// <param name="supplierSendErOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 発注送信エラーのUOE発注データを更新する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private int UpdateUOEOrderDtlProc(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                ArrayList uoeOrderDtlWorkList;
                // 更新用のUOE発注データ作成
                this.SetUOEOrderDtlWork(out uoeOrderDtlWorkList);
                
                // 更新処理
                object writeObj = uoeOrderDtlWorkList;
                status = this._iUOEOrderDtlDB.Write(ref writeObj);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                       status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "UOE発注データの更新に失敗しました。";
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
        #endregion

        #region UOE発注データの設定
        /// <summary>
        /// UOE発注データの設定
        /// </summary>
        /// <param name="orderListCndtn">抽出条件データクラス</param>
        /// <param name="dr">抽出結果データ行</param>
        /// <param name="guid">UOE発注分関連付けGuid</param>
        /// <param name="uoeList">UOE発注データリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データを作成。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private void SetUOEOrderDtlWork(out ArrayList uoeOrderDtlWorkList)
        {
            UOEOrderDtlWork uoeOrderDtlWork;
         
            uoeOrderDtlWorkList = new ArrayList();

            foreach (SupplierSendErResultWork supplierSendErResultWork in _stc_SupplierSendErResultWorkList)
            {
                uoeOrderDtlWork = new UOEOrderDtlWork();

                // 作成日時
                uoeOrderDtlWork.CreateDateTime = supplierSendErResultWork.CreateDateTime;
                // 更新日時
                uoeOrderDtlWork.UpdateDateTime = supplierSendErResultWork.UpdateDateTime;
                // 企業コード
                uoeOrderDtlWork.EnterpriseCode = supplierSendErResultWork.EnterpriseCode;
                // GUID
                uoeOrderDtlWork.FileHeaderGuid = supplierSendErResultWork.FileHeaderGuid;
                // 更新従業員コード
                uoeOrderDtlWork.UpdEmployeeCode = supplierSendErResultWork.UpdEmployeeCode;
                // 更新アセンブリID1
                uoeOrderDtlWork.UpdAssemblyId1 = supplierSendErResultWork.UpdAssemblyId1;
                // 更新アセンブリID2
                uoeOrderDtlWork.UpdAssemblyId2 = supplierSendErResultWork.UpdAssemblyId2;
                // 論理削除区分
                uoeOrderDtlWork.LogicalDeleteCode = supplierSendErResultWork.LogicalDeleteCode;
                // システム区分
                uoeOrderDtlWork.SystemDivCd = supplierSendErResultWork.SystemDivCd;
                // UOE発注番号
                uoeOrderDtlWork.UOESalesOrderNo = supplierSendErResultWork.UOESalesOrderNo;
                // UOE発注行番号
                uoeOrderDtlWork.UOESalesOrderRowNo = supplierSendErResultWork.UOESalesOrderRowNo;
                // 送信端末番号
                uoeOrderDtlWork.SendTerminalNo = 0;
                // UOE発注先コード
                uoeOrderDtlWork.UOESupplierCd = supplierSendErResultWork.UOESupplierCd;
                // UOE発注先名称
                uoeOrderDtlWork.UOESupplierName = supplierSendErResultWork.UOESupplierName;
                // 通信アセンブリID
                uoeOrderDtlWork.CommAssemblyId = supplierSendErResultWork.CommAssemblyId;
                // 通信アセンブリID
                uoeOrderDtlWork.OnlineNo = supplierSendErResultWork.OnlineNo;
                // オンライン行番号
                uoeOrderDtlWork.OnlineRowNo = supplierSendErResultWork.OnlineRowNo;
                // 売上日付
                uoeOrderDtlWork.SalesDate = supplierSendErResultWork.SalesDate;
                // 入力日
                uoeOrderDtlWork.InputDay = supplierSendErResultWork.InputDay;
                // データ更新日時
                uoeOrderDtlWork.DataUpdateDateTime = supplierSendErResultWork.DataUpdateDateTime;
                // UOE種別
                uoeOrderDtlWork.UOEKind = supplierSendErResultWork.UOEKind;
                // 売上伝票番号
                uoeOrderDtlWork.SalesSlipNum = supplierSendErResultWork.SalesSlipNum;
                // 受注ステータス
                uoeOrderDtlWork.AcptAnOdrStatus = supplierSendErResultWork.AcptAnOdrStatus;
                // 売上明細通番
                uoeOrderDtlWork.SalesSlipDtlNum = supplierSendErResultWork.SalesSlipDtlNum;
                // 拠点コード
                uoeOrderDtlWork.SectionCode = supplierSendErResultWork.SectionCode;
                // 部門コード
                uoeOrderDtlWork.SubSectionCode = supplierSendErResultWork.SubSectionCode;
                // 得意先コード
                uoeOrderDtlWork.CustomerCode = supplierSendErResultWork.CustomerCode;
                // 得意先略称
                uoeOrderDtlWork.CustomerSnm = supplierSendErResultWork.CustomerSnm;
                // レジ番号
                uoeOrderDtlWork.CashRegisterNo = supplierSendErResultWork.CashRegisterNo;
                // 共通通番
                uoeOrderDtlWork.CommonSeqNo = supplierSendErResultWork.CommonSeqNo;
                // 仕入形式
                uoeOrderDtlWork.SupplierFormal = supplierSendErResultWork.SupplierFormal;
                // 仕入伝票番号
                uoeOrderDtlWork.SupplierSlipNo = supplierSendErResultWork.SupplierSlipNo;
                // 仕入明細通番
                uoeOrderDtlWork.StockSlipDtlNum = supplierSendErResultWork.StockSlipDtlNum;
                // BO区分
                uoeOrderDtlWork.BoCode = supplierSendErResultWork.BoCode;
                // UOE納品区分
                uoeOrderDtlWork.UOEDeliGoodsDiv = supplierSendErResultWork.UOEDeliGoodsDiv;
                // 納品区分名称
                uoeOrderDtlWork.DeliveredGoodsDivNm = supplierSendErResultWork.DeliveredGoodsDivNm;
                // フォロー納品区分
                uoeOrderDtlWork.FollowDeliGoodsDiv = supplierSendErResultWork.FollowDeliGoodsDiv;
                // フォロー納品区分名称
                uoeOrderDtlWork.FollowDeliGoodsDivNm = supplierSendErResultWork.FollowDeliGoodsDivNm;
                // UOE指定拠点
                uoeOrderDtlWork.UOEResvdSection = supplierSendErResultWork.UOEResvdSection;
                // UOE指定拠点名称
                uoeOrderDtlWork.UOEResvdSectionNm = supplierSendErResultWork.UOEResvdSectionNm;
                // 従業員コード
                uoeOrderDtlWork.EmployeeCode = supplierSendErResultWork.EmployeeCode;
                // 従業員名称
                uoeOrderDtlWork.EmployeeName = supplierSendErResultWork.EmployeeName;
                // 商品メーカーコード
                uoeOrderDtlWork.GoodsMakerCd = supplierSendErResultWork.GoodsMakerCd;
                // メーカー名称
                uoeOrderDtlWork.MakerName = supplierSendErResultWork.MakerName;
                // 商品番号
                uoeOrderDtlWork.GoodsNo = supplierSendErResultWork.GoodsNo;
                // ハイフン無商品番号
                uoeOrderDtlWork.GoodsNoNoneHyphen = supplierSendErResultWork.GoodsNoNoneHyphen;
                // 商品名称
                uoeOrderDtlWork.GoodsName = supplierSendErResultWork.GoodsName;
                // 倉庫コード
                uoeOrderDtlWork.WarehouseCode = supplierSendErResultWork.WarehouseCode;
                // 倉庫名称
                uoeOrderDtlWork.WarehouseName = supplierSendErResultWork.WarehouseName;
                // 倉庫棚番
                uoeOrderDtlWork.WarehouseShelfNo = supplierSendErResultWork.WarehouseShelfNo;
                // 受注数量
                uoeOrderDtlWork.AcceptAnOrderCnt = supplierSendErResultWork.AcceptAnOrderCnt;
                // 定価（浮動）
                uoeOrderDtlWork.ListPrice = supplierSendErResultWork.ListPrice;
                // 原価単価
                uoeOrderDtlWork.SalesUnitCost = supplierSendErResultWork.SalesUnitCost;
                // 仕入先コード
                uoeOrderDtlWork.SupplierCd = supplierSendErResultWork.SupplierCd;
                // 仕入先略称
                uoeOrderDtlWork.SupplierSnm = supplierSendErResultWork.SupplierSnm;
                // ＵＯＥリマーク１
                uoeOrderDtlWork.UoeRemark1 = supplierSendErResultWork.UoeRemark1;
                // ＵＯＥリマーク２
                uoeOrderDtlWork.UoeRemark2 = supplierSendErResultWork.UoeRemark2;
                // 受信日付
                uoeOrderDtlWork.ReceiveDate = supplierSendErResultWork.ReceiveDate;
                // 受信時刻
                uoeOrderDtlWork.ReceiveTime = supplierSendErResultWork.ReceiveTime;
                // 回答メーカーコード
                uoeOrderDtlWork.AnswerMakerCd = supplierSendErResultWork.AnswerMakerCd;
                // 回答品番
                uoeOrderDtlWork.AnswerPartsNo = supplierSendErResultWork.AnswerPartsNo;
                // 回答品名
                uoeOrderDtlWork.AnswerPartsName = supplierSendErResultWork.AnswerPartsName;
                // 代替品番
                uoeOrderDtlWork.SubstPartsNo = supplierSendErResultWork.SubstPartsNo;
                // UOE拠点出庫数
                uoeOrderDtlWork.UOESectOutGoodsCnt = supplierSendErResultWork.UOESectOutGoodsCnt;
                // BO出庫数1
                uoeOrderDtlWork.BOShipmentCnt1 = supplierSendErResultWork.BOShipmentCnt1;
                // BO出庫数2
                uoeOrderDtlWork.BOShipmentCnt2 = supplierSendErResultWork.BOShipmentCnt2;
                // BO出庫数3
                uoeOrderDtlWork.BOShipmentCnt3 = supplierSendErResultWork.BOShipmentCnt3;
                // メーカーフォロー数
                uoeOrderDtlWork.MakerFollowCnt = supplierSendErResultWork.MakerFollowCnt;
                // 未出庫数
                uoeOrderDtlWork.NonShipmentCnt = supplierSendErResultWork.NonShipmentCnt;
                // UOE拠点在庫数
                uoeOrderDtlWork.UOESectStockCnt = supplierSendErResultWork.UOESectStockCnt;
                // BO在庫数1
                uoeOrderDtlWork.BOStockCount1 = supplierSendErResultWork.BOStockCount1;
                // BO在庫数2
                uoeOrderDtlWork.BOStockCount2 = supplierSendErResultWork.BOStockCount2;
                // BO在庫数3
                uoeOrderDtlWork.BOStockCount3 = supplierSendErResultWork.BOStockCount3;
                // UOE拠点伝票番号
                uoeOrderDtlWork.UOESectionSlipNo = supplierSendErResultWork.UOESectionSlipNo;
                // BO伝票番号１
                uoeOrderDtlWork.BOSlipNo1 = supplierSendErResultWork.BOSlipNo1;
                // BO伝票番号２
                uoeOrderDtlWork.BOSlipNo2 = supplierSendErResultWork.BOSlipNo2;
                // BO伝票番号３
                uoeOrderDtlWork.BOSlipNo3 = supplierSendErResultWork.BOSlipNo3;
                // EO引当数
                uoeOrderDtlWork.EOAlwcCount = supplierSendErResultWork.EOAlwcCount;
                // BO管理番号
                uoeOrderDtlWork.BOManagementNo = supplierSendErResultWork.BOManagementNo;
                // 回答定価
                uoeOrderDtlWork.AnswerListPrice = supplierSendErResultWork.AnswerListPrice;
                // 回答原価単価
                uoeOrderDtlWork.AnswerSalesUnitCost = supplierSendErResultWork.AnswerSalesUnitCost;
                // UOE代替マーク
                uoeOrderDtlWork.UOESubstMark = supplierSendErResultWork.UOESubstMark;
                // UOE在庫マーク
                uoeOrderDtlWork.UOEStockMark = supplierSendErResultWork.UOEStockMark;
                // 層別コード
                uoeOrderDtlWork.PartsLayerCd = supplierSendErResultWork.PartsLayerCd;
                // UOE出荷拠点コード１（マツダ）
                uoeOrderDtlWork.MazdaUOEShipSectCd1 = supplierSendErResultWork.MazdaUOEShipSectCd1;
                // UOE出荷拠点コード２（マツダ）
                uoeOrderDtlWork.MazdaUOEShipSectCd2 = supplierSendErResultWork.MazdaUOEShipSectCd2;
                // UOE出荷拠点コード３（マツダ）
                uoeOrderDtlWork.MazdaUOEShipSectCd3 = supplierSendErResultWork.MazdaUOEShipSectCd3;
                // UOE拠点コード１（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd1 = supplierSendErResultWork.MazdaUOESectCd1;
                // UOE拠点コード２（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd2 = supplierSendErResultWork.MazdaUOESectCd2;
                // UOE拠点コード３（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd3 = supplierSendErResultWork.MazdaUOESectCd3;
                // UOE拠点コード４（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd4 = supplierSendErResultWork.MazdaUOESectCd4;
                // UOE拠点コード５（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd5 = supplierSendErResultWork.MazdaUOESectCd5;
                // UOE拠点コード６（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd6 = supplierSendErResultWork.MazdaUOESectCd6;
                // UOE拠点コード７（マツダ）
                uoeOrderDtlWork.MazdaUOESectCd7 = supplierSendErResultWork.MazdaUOESectCd7;
                // UOE在庫数１（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt1 = supplierSendErResultWork.MazdaUOEStockCnt1;
                // UOE在庫数２（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt2 = supplierSendErResultWork.MazdaUOEStockCnt2;
                // UOE在庫数３（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt3 = supplierSendErResultWork.MazdaUOEStockCnt3;
                // UOE在庫数４（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt4 = supplierSendErResultWork.MazdaUOEStockCnt4;
                // UOE在庫数５（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt5 = supplierSendErResultWork.MazdaUOEStockCnt5;
                // UOE在庫数６（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt6 = supplierSendErResultWork.MazdaUOEStockCnt6;
                // UOE在庫数７（マツダ）
                uoeOrderDtlWork.MazdaUOEStockCnt7 = supplierSendErResultWork.MazdaUOEStockCnt7;
                // UOE卸コード
                uoeOrderDtlWork.UOEDistributionCd = supplierSendErResultWork.UOEDistributionCd;
                // UOE他コード
                uoeOrderDtlWork.UOEOtherCd = supplierSendErResultWork.UOEOtherCd;
                // UOEＨＭコード
                uoeOrderDtlWork.UOEHMCd = supplierSendErResultWork.UOEHMCd;
                // ＢＯ数
                uoeOrderDtlWork.BOCount = supplierSendErResultWork.BOCount;
                // UOEマークコード
                uoeOrderDtlWork.UOEMarkCode = supplierSendErResultWork.UOEMarkCode;
                // 出荷元
                uoeOrderDtlWork.SourceShipment = supplierSendErResultWork.SourceShipment;
                // アイテムコード
                uoeOrderDtlWork.ItemCode = supplierSendErResultWork.ItemCode;
                // UOEチェックコード
                uoeOrderDtlWork.UOECheckCode = supplierSendErResultWork.UOECheckCode;
                // ヘッドエラーメッセージ
                uoeOrderDtlWork.HeadErrorMassage = supplierSendErResultWork.HeadErrorMassage;
                // ラインエラーメッセージ
                uoeOrderDtlWork.LineErrorMassage = supplierSendErResultWork.LineErrorMassage;
                // データ送信区分
                uoeOrderDtlWork.DataSendCode = 4;　 // 4:異常終了
                // データ復旧区分
                uoeOrderDtlWork.DataRecoverDiv = 1; // 1:処理中
                // 入庫更新区分（拠点）
                uoeOrderDtlWork.EnterUpdDivSec = supplierSendErResultWork.EnterUpdDivSec;
                // 入庫更新区分（BO1）
                uoeOrderDtlWork.EnterUpdDivBO1 = supplierSendErResultWork.EnterUpdDivBO1;
                // 入庫更新区分（BO2）
                uoeOrderDtlWork.EnterUpdDivBO2 = supplierSendErResultWork.EnterUpdDivBO2;
                // 入庫更新区分（BO3）
                uoeOrderDtlWork.EnterUpdDivBO3 = supplierSendErResultWork.EnterUpdDivBO3;
                // 入庫更新区分（ﾒｰｶｰ）
                uoeOrderDtlWork.EnterUpdDivMaker = supplierSendErResultWork.EnterUpdDivMaker;
                // 入庫更新区分（EO）
                uoeOrderDtlWork.EnterUpdDivEO = supplierSendErResultWork.EnterUpdDivEO;

                // 更新用UOE発注データリストに追加
                uoeOrderDtlWorkList.Add(uoeOrderDtlWork);
            }
        }
        #endregion
        #endregion ◆ UOE発注データの更新処理

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
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.10</br>
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
        #endregion
        #endregion ◆ 帳票設定データ取得
        #endregion ■ Private Method
    }
}
