//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 三菱回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/21  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 修 正 日  2010/05/07  修正内容 : redmine#7034 回答品番バイトの修正																																																																											
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 修 正 日  2010/05/07  修正内容 : redmine#7035 B/O数はメーカーフォロー数にセット																																																																											
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 鄧潘ハン
// 修 正 日  2010/12/31  修正内容 : 自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。																																																																											
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/12/02  修正内容 : Redmine#8304の対応																																																																										
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 三菱Web-UOE発注回答データの構築クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 三菱Web-UOE発注回答データの構築クラスを行います。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010/04/21</br>
	/// <br>UpdateNote : 2010/05/07 姜凱</br>
	/// <br>           　redmine#7034 回答品番バイトの修正</br>
	/// <br>UpdateNote : 2010/05/07 姜凱</br>
	/// <br>           　redmine#7035 B/O数はメーカーフォロー数にセット</br>
    /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
    /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>      
    /// </remarks>
    public sealed class MitsubishiWebUOEOrderDtlInfoBuilder : UOEOrderDtlInfoBuilder
    {
        # region -- プライベート変数 --
        private DataTable _dataTable;
        # endregion

        # region -- プライベート定数 --
        // datatable名称用
        /// <summary>
        /// datatable名称
        /// </summary>
        public static string TABLE_ID = "DETAIL_TABLE";
        /// <summary>
        /// No.
        /// </summary>
        public static string NO = "No";
        /// <summary>
        /// 品番
        /// </summary>
        public static string GOODSNO = "GoodsNo";
        /// <summary>
        /// ﾒｰｶｰ(タイトル)	
        /// </summary>
        public static string GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>
        /// 品名(タイトル)	
        /// </summary>
        public static string GOODSNAME = "GoodsName";
        /// <summary>
        /// 数量(タイトル)	
        /// </summary>
        public static string COUNT = "Count";
        /// <summary>
        /// 回答品番(タイトル)	
        /// </summary>
        public static string ANSWERPARTSNO = "AnswerPartsNo";
        /// <summary>
        /// 定価(タイトル)	
        /// </summary>
        public static string LISTPRICE = "ListPrice";
        /// <summary>
        /// 単価(タイトル)	
        /// </summary>
        public static string SALESUNITCOST = "SalesUnitCost";
        /// <summary>
        /// コメント(タイトル)	
        /// </summary>
        public static string COMMENT = "Comment";
        /// <summary>
        /// 拠点伝票番号(タイトル)	
        /// </summary>
        public static string UOESECTIONSLIPNO = "UOESectionSlipNo";
        /// <summary>
        /// 出荷数(タイトル)	
        /// </summary>
        public static string UOESECTOUTGOODSCNT = "UOESectOutGoodsCnt";
        /// <summary>
        /// BO伝票番号1(タイトル)
        /// </summary>
        public static string BOSLIPNO1 = "BOSlipNo1";
        /// <summary>
        /// 出荷数(タイトル)		
        /// </summary>
        public static string BOSHIPMENTCNT1 = "BOShipmentCnt1";
        /// <summary>
        /// BO伝票番号2(タイトル)	
        /// </summary>
        public static string BOSLIPNO2 = "BOSlipNo2";
        /// <summary>
        /// 出荷数(タイトル)		
        /// </summary>
        public static string BOSHIPMENTCNT2 = "BOShipmentCnt2";
        /// <summary>
        /// ﾒｰｶｰﾌｫﾛｰ数(タイトル)	
        /// </summary>
        public static string MAKERFOLLOWCNT = "MakerFollowCnt";
        private const string COMMASSEMBLY_ID = "0302";
        private const string AUTOCOMMASSEMBLY_ID = "0303";   // ADD 2010/12/31
        //---ADD 2010/12/31----------------------------------------------->>>>>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //ＵＯＥ発注先アクセスクラス
        private UOESupplierAcs _uoeSupplierAcs; 
        //ＵＯＥ発注先
        private List<UOESupplier> _uoeSupplier01633;
        private  int UOESupplierFlag = 0;
        //---ADD 2010/12/31-----------------------------------------------<<<<<
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// </remarks>
        public MitsubishiWebUOEOrderDtlInfoBuilder()
            : base()
        {
            //---ADD 2010/12/31----------------------------------------------->>>>>
            this._uoeSupplierAcs = new UOESupplierAcs();
            this.CacheUOESupplier_01633();
            //---ADD 2010/12/31-----------------------------------------------<<<<<
        }
        # endregion        

        # region  -- 構築クラスの実装 --

        //---ADD 2010/12/31----------------------------------------------->>>>>
        /// <summary>
        /// 手動と自動のFalg取る
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手動と自動のFalg取る</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// </remarks>
        public void GetSupplierFlag()
        {
            foreach (UOESupplier uoeSupplier in _uoeSupplier01633)
            {

                if (("0303").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 1;
                    break;
                }
            }
        
        }
        //---ADD 2010/12/31-----------------------------------------------<<<<<

        //---ADD 2010/12/31----------------------------------------------->>>>>
        /// <summary>
        /// ＵＯＥ発注先情報キャッシュ制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注先情報キャッシュ制御処理を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// </remarks>
        public void CacheUOESupplier_01633()
        {
            _uoeSupplier01633 = new List<UOESupplier>();
            List<UOESupplier> resultList = new List<UOESupplier>();
            try
            {
                ArrayList retList;
                int status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._loginSectionCode.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UOESupplier uoeSupplier in retList)
                    {
                        if (uoeSupplier.LogicalDeleteCode == 0)
                        {
                            resultList.Add(uoeSupplier);
                        }
                    }
                }

                resultList = resultList.FindAll(delegate(UOESupplier target)
                {
                    if (UOESupplierCd==target.UOESupplierCd)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (resultList != null && resultList.Count > 0)
                {
                    _uoeSupplier01633 = resultList;
                }
            }
            catch (Exception)
            {
                _uoeSupplier01633 = new List<UOESupplier>();
            }

        }
        //---ADD 2010/12/31-----------------------------------------------<<<<<
       
        /// <summary>
        /// ファイル情報取得処理
        /// </summary>
        /// <param name="filesDataDtlList">ファイル情報情報</param>
        /// <param name="answerSaveFolder">回答保存フォルダ</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : ファイル情報を取得処理する。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// </remarks>
        protected override int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this._dataTable.Clear();

            CacheUOESupplier_01633(); // ADD 2010/12/31

            GetSupplierFlag();// ADD 2010/12/31
            // ファイル情報
            filesDataDtlList = new List<UOEOrderDtlInfo>();

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            FileStream fileStream = null;
            try
            {
                string filePathName = "";

				#region UOE_Out.csvを取込
				List<UOEOrderDtlInfo> orderDataDtlList = new List<UOEOrderDtlInfo>();
				filePathName = answerSaveFolder + "\\UOE_Out.csv";
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                string timeFormat = "yyyyMMddHHmmss";
                DateTime dt = DateTime.Now;
                string bakFilePathName = answerSaveFolder + "\\UOE_Out_" + dt.ToString(timeFormat)+".csv";
                File.Copy(filePathName, bakFilePathName);
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                if (File.Exists(filePathName))
				{
					try
					{
						// UOE_Out.csvファイル使用中判断
                        fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
					}
					catch (IOException)
					{
						errMessage = "発注回答ファイルが使用中です。";
						// 異常場合
						return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
					}
					finally
					{
						if (fileStream != null)
						{
							fileStream.Close();
						}
					}

					List<string[]> csvDataList;
                    status = this.GetCSVData(out csvDataList, filePathName);

					string uoeRemark2 = "";
					for (int row = 0; row < csvDataList.Count; row++)
					{
						string[] detailInfo = csvDataList[row];

						if (detailInfo.Length == 40)
						{
                            //---UPD 2010/12/31----------------------------------------------->>>>>
                               if (UOESupplierFlag == 1)
                                {
                                    uoeRemark2 = detailInfo[7].Trim(); 
                                    UOEOrderDtlInfo uOEOrderDtlMitsubishiInfo = new UOEOrderDtlInfo();
                                    // ＵＯＥリマーク２
                                    uOEOrderDtlMitsubishiInfo.UoeRemark2 = uoeRemark2; // リマーク
                                    if (!this.CheckUoeRemark2(uoeRemark2))
                                    {
                                        continue;
                                    }
                                    int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlMitsubishiInfo, detailInfo);

                                    if (ret == -1)
                                    {
                                        continue;
                                    }
                                    orderDataDtlList.Add(uOEOrderDtlMitsubishiInfo);
                                }
                                else
                                {
                                    uoeRemark2 = detailInfo[6].Trim(); // リマーク
                                    UOEOrderDtlInfo uOEOrderDtlMitsubishiInfo = new UOEOrderDtlInfo();

                                    // ＵＯＥリマーク２
                                    uOEOrderDtlMitsubishiInfo.UoeRemark2 = uoeRemark2; // リマーク
                                    if (!this.CheckUoeRemark2(uoeRemark2))
                                    {
                                        continue;
                                    }
                                    int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlMitsubishiInfo, detailInfo);

                                    if (ret == -1)
                                    {
                                        continue;
                                    }
                                    orderDataDtlList.Add(uOEOrderDtlMitsubishiInfo);
                                }
                            }
                            //---UPD 2010/12/31-----------------------------------------------<<<<<
						
					}
				}

				foreach (UOEOrderDtlInfo orderInfo in orderDataDtlList)
				{
					string uoeRemark2 = orderInfo.UoeRemark2;
					if (!uoeRemarkDic.ContainsKey(uoeRemark2))
					{
						List<UOEOrderDtlInfo> tempList = orderDataDtlList.FindAll(
											delegate(UOEOrderDtlInfo info)
											{
												if (info.UoeRemark2 == uoeRemark2)
												{
													return true;
												}
												else
												{
													return false;
												}
											}
						);

						filesDataDtlList.AddRange(tempList);

						uoeRemarkDic.Add(uoeRemark2.Trim(), null);
					}
				}
				#endregion
			}
            catch
            {
                // 異常場合
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// 三菱発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">RCV情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 三菱発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        protected override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            // UPD 2010/12/31 ------------- >>>>>>>>>>>>>>>
            if (UOESupplierFlag == 1)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            else
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == COMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            // UPD 2010/12/31 ------------- <<<<<<<<<<<<<

            return retList;
        }

        /// <summary>
        /// 発注回答データをUOE発注データに反映の処理
        /// </summary>
        /// <param name="workList">UOE発注データ</param>
        /// <param name="dateList">発注回答データ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注回答データをUOE発注データに反映ﾞを処理</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : 2010/05/07 姜凱</br>
		/// <br>           　redmine#7035 B/O数はメーカーフォロー数にセット</br>
        /// </remarks>
        protected override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                for (int i = 0; i < workList.Count; i++)
                {
                    if (i < dateList.Count)
                    {
                        // 受信日付	
                        workList[i].ReceiveDate = dateList[i].ReceiveDate;
                        //受信時刻
                        workList[i].ReceiveTime = dateList[i].ReceiveTime;
                        //回答品番
                        workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                        //回答品名
                        workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                        //代替品番
                        workList[i].SubstPartsNo = dateList[i].SubstPartsNo;
                        //拠点出庫数							
                        workList[i].UOESectOutGoodsCnt = dateList[i].UOESectOutGoodsCnt;
                        //BO出庫数1	
                        workList[i].BOShipmentCnt1 = dateList[i].BOShipmentCnt1;
                        //BO出庫数2							
                        workList[i].BOShipmentCnt2 = dateList[i].BOShipmentCnt2;
						// --- ADD 2010/05/07 ---------->>>>>
						// メーカーフォロー数
						workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
						// --- ADD 2010/05/07 ----------<<<<<
						//拠点在庫数				
						workList[i].UOESectStockCnt = dateList[i].UOESectStockCnt;
						//BO在庫数1					
						workList[i].BOStockCount1 = dateList[i].BOStockCount1;
						//BO在庫数2					
						workList[i].BOStockCount2 = dateList[i].BOStockCount2;
                        //UOE拠点伝票番号							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO伝票№1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO伝票№2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;
                        //回答定価				
                        workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        //回答原価単価							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
						// --- DEL 2010/05/07 ---------->>>>>
						//// ＢＯ数
						//workList[i].BOCount = dateList[i].BOCount;
						// --- DEL 2010/05/07 ----------<<<<<
                        //ラインエラーメッセージ	
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // データ送信区分
                        workList[i].DataSendCode = dateList[i].DataSendCode;
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        protected override void DataTableColumnConstruction()
        {
            DataTable table = new DataTable(TABLE_ID);

            // Addを行う順番が、列の表示順位となります。
            table.Columns.Add(NO, typeof(string));   // No.
            table.Columns.Add(GOODSNO, typeof(string)); // 品番
            table.Columns.Add(GOODSMAKERCD, typeof(Int32)); // ﾒｰｶｰ(タイトル)				
            table.Columns.Add(GOODSNAME, typeof(string)); // 品名(タイトル)	
            table.Columns.Add(COUNT, typeof(Double)); // 数量(タイトル)		
            table.Columns.Add(ANSWERPARTSNO, typeof(string)); // 回答品番(タイトル)		
            table.Columns.Add(LISTPRICE, typeof(Double)); // 定価(タイトル)				
            table.Columns.Add(SALESUNITCOST, typeof(Double)); // 単価(タイトル)				
            table.Columns.Add(COMMENT, typeof(string)); // コメント(タイトル)				
            table.Columns.Add(UOESECTIONSLIPNO, typeof(string)); // 拠点伝票番号(タイトル)				
            table.Columns.Add(UOESECTOUTGOODSCNT, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(BOSLIPNO1, typeof(string)); // BO伝票番号1(タイトル)				
            table.Columns.Add(BOSHIPMENTCNT1, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(BOSLIPNO2, typeof(string)); // BO伝票番号2(タイトル)				
            table.Columns.Add(BOSHIPMENTCNT2, typeof(Int32)); // 出荷数(タイトル)				
            table.Columns.Add(MAKERFOLLOWCNT, typeof(Int32)); // ﾒｰｶｰﾌｫﾛｰ数(タイトル)				


            table.Columns[NO].Caption = "No.";
            table.Columns[GOODSNO].Caption = "品番"; // 品番
            table.Columns[GOODSMAKERCD].Caption = "ﾒｰｶｰ"; // 品番(タイトル)				
            table.Columns[GOODSNAME].Caption = "品名"; // 品名(タイトル)				
            table.Columns[COUNT].Caption = "数量"; // 数量(タイトル)				
            table.Columns[ANSWERPARTSNO].Caption = "回答品番"; // 回答品番(タイトル)				
            table.Columns[LISTPRICE].Caption = "定価"; // 定価(タイトル)				
            table.Columns[SALESUNITCOST].Caption = "単価"; // 単価(タイトル)				
            table.Columns[COMMENT].Caption = "コメント"; // コメント(タイトル)				
			table.Columns[UOESECTIONSLIPNO].Caption = "拠点"; // 拠点伝票番号(タイトル)				
            table.Columns[UOESECTOUTGOODSCNT].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO1].Caption = "サブ"; // BO伝票番号1(タイトル)				
            table.Columns[BOSHIPMENTCNT1].Caption = "出荷数"; // 出荷数(タイトル)				
			table.Columns[BOSLIPNO2].Caption = "本庫"; // BO伝票番号2(タイトル)				
            table.Columns[BOSHIPMENTCNT2].Caption = "出荷数"; // 出荷数(タイトル)				
			table.Columns[MAKERFOLLOWCNT].Caption = "ＭＦ"; // ﾒｰｶｰﾌｫﾛｰ数(タイトル)	

            this._dataTable = table;
        }

        /// <summary>
        /// データセット行増加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット行増加処理を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        protected override void DataTableAddRow(List<UOEOrderDtlWork> workList)
        {
            int rowIndex = 1;
            foreach (UOEOrderDtlWork work in workList)
            {
                DataRow row = this._dataTable.NewRow();

                row[NO] = rowIndex.ToString();
                //品番		
                row[GOODSNO] = work.GoodsNo;
                //ﾒｰｶｰ	
                row[GOODSMAKERCD] = work.GoodsMakerCd;
                //品名	
                row[GOODSNAME] = work.GoodsName;
                //数量
                row[COUNT] = work.AcceptAnOrderCnt;
                //回答品番	
                row[ANSWERPARTSNO] = work.AnswerPartsNo;
                //定価	
                row[LISTPRICE] = work.AnswerListPrice;
                //単価	
                row[SALESUNITCOST] = work.AnswerSalesUnitCost;
                //コメント
                if (string.IsNullOrEmpty(work.HeadErrorMassage))
                {
                    row[COMMENT] = work.LineErrorMassage;
                }
                else
                {
                    row[COMMENT] = work.HeadErrorMassage;
                }
                //拠点								
                row[UOESECTIONSLIPNO] = work.UOESectionSlipNo;
                //出荷数
                row[UOESECTOUTGOODSCNT] = work.UOESectOutGoodsCnt;
                //サブ								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //出荷数								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //本庫								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //出荷数								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //ＭＦ								
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;

                this._dataTable.Rows.Add(row);
                rowIndex++;
            }
        }
        # endregion

        # region -- DataTableの処理 --
        /// <summary>
        /// 処理結果
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>処理結果をを取得</remarks>
        public DataTable DetailDataTable
        {
            get { return this._dataTable; }
        }

        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public override void DataTableClear()
        {
            this._dataTable.Clear();
        }
        #endregion

        # region -- データ変換 --

        /// <summary>
        /// 三菱発注回答ファイルのﾚｺｰﾄﾞの処理
        /// </summary>
        /// <param name="uOEOrderDtlMitsubishiInfo">発注回答データ</param>
        /// <param name="detailInfo">CSVのlineデータ</param>
        /// <remarks>
        /// <br>Note       : 三菱発注回答ファイルのﾚｺｰﾄﾞを処理</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : 2010/05/07 姜凱</br>
		/// <br>           　redmine#7034 回答品番バイトの修正</br>
		/// <br>UpdateNote : 2010/05/07 姜凱</br>
		/// <br>           　redmine#7035 B/O数はメーカーフォロー数にセット</br>
        /// </remarks>
        private int ConverStringToUOEOrderDtlInfo(ref UOEOrderDtlInfo uOEOrderDtlMitsubishiInfo, string[] detailInfo)
        {
            // 受信日付
            uOEOrderDtlMitsubishiInfo.ReceiveDate = DateTime.Today; // システム日付
            // 受信時刻
            uOEOrderDtlMitsubishiInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss")); // システム時刻
			// 回答品番
			uOEOrderDtlMitsubishiInfo.AnswerPartsNo = this.GetPartsNo(detailInfo[12]);  // 部品番号
			if (uOEOrderDtlMitsubishiInfo.AnswerPartsNo.Trim() == string.Empty)
			{
				return -1;
			}
			// 回答品名
			uOEOrderDtlMitsubishiInfo.AnswerPartsName = detailInfo[19]; // 品名
			// 入力部品番号はスペース以外の場合
			if (!string.IsNullOrEmpty(detailInfo[13]))
			{
				// 代替品番
				//uOEOrderDtlMitsubishiInfo.SubstPartsNo = detailInfo[12];   // 部品番号  　※1   DEL 2010/05/07
				uOEOrderDtlMitsubishiInfo.SubstPartsNo = this.GetPartsNo(detailInfo[12]);   // 部品番号  　※1  ADD 2010/05/07
			}
			// 拠点出庫数
			uOEOrderDtlMitsubishiInfo.UOESectOutGoodsCnt = this.StringToInt(detailInfo[22]); // 拠点1出荷数
			// BO出庫数1
			uOEOrderDtlMitsubishiInfo.BOShipmentCnt1 = this.StringToInt(detailInfo[26]);  // 拠点2出荷数
            // BO出庫数2
			uOEOrderDtlMitsubishiInfo.BOShipmentCnt2 = this.StringToInt(detailInfo[30]);  // 拠点3出荷数
			// 拠点在庫数
			uOEOrderDtlMitsubishiInfo.UOESectStockCnt = this.StringToInt(detailInfo[23]); // 拠点1残在庫数
			// BO在庫数1
			uOEOrderDtlMitsubishiInfo.BOStockCount1 = this.StringToInt(detailInfo[27]);  // 拠点2残在庫数
			// BO在庫数2
			uOEOrderDtlMitsubishiInfo.BOStockCount2 = this.StringToInt(detailInfo[31]);  // 拠点3残在庫数
			// --- ADD 2010/05/07 ---------->>>>>
			// メーカーフォロー数
			uOEOrderDtlMitsubishiInfo.MakerFollowCnt = this.StringToInt(detailInfo[33]);  // B/O数
			// --- ADD 2010/05/07 ----------<<<<<
            // UOE拠点伝票番号
			uOEOrderDtlMitsubishiInfo.UOESectionSlipNo = detailInfo[24]; // 拠点1伝票No.
            // BO伝票№1
			uOEOrderDtlMitsubishiInfo.BOSlipNo1 = detailInfo[28]; // 拠点2伝票No.
			// BO伝票№2
			uOEOrderDtlMitsubishiInfo.BOSlipNo2 = detailInfo[32]; // 拠点3伝票No.
            // 回答定価
			uOEOrderDtlMitsubishiInfo.AnswerListPrice = this.StringToDouble(detailInfo[18]);// L/P
            // 回答原価単価
            uOEOrderDtlMitsubishiInfo.AnswerSalesUnitCost = this.StringToDouble(detailInfo[17]);// 仕切
			// --- DEL 2010/05/07 ---------->>>>>
			//// ＢＯ数
			//uOEOrderDtlMitsubishiInfo.BOCount = this.GetBONum(detailInfo[33]);// B/O数
			// --- DEL 2010/05/07 ----------<<<<<
			// ラインエラーメッセージ
			uOEOrderDtlMitsubishiInfo.LineErrorMassage = detailInfo[20];// メッセージ
            // データ送信区分
            uOEOrderDtlMitsubishiInfo.DataSendCode = 5;// 5:回答埋込

            return 0;
        }
        #endregion

        # region -- データの処理 --
        /// <summary>
        /// 品番の処理
        /// </summary>
        /// <param name="filePartsNo">部品番号１２桁＋ハイフン×２</param>
        /// <returns>品番</returns>
        /// <remarks>
        /// <br>Note       : 品番の処理を行う</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : 2010/05/07 姜凱</br>
		/// <br>           　redmine#7034 回答品番バイトの修正</br>
        /// </remarks>
		private string GetPartsNo(string filePartsNo)
		{
			if (string.IsNullOrEmpty(filePartsNo))
			{
				return "";
			}
			// --- DEL 2010/05/07 ---------->>>>>
			//if (filePartsNo.Length > 12)
			//{
			//    return filePartsNo.Substring(0, 12);
			//}
			// --- DEL 2010/05/07 ----------<<<<<
			// --- ADD 2010/05/07 ---------->>>>>
			if (filePartsNo.Length > 20)
			{
				return filePartsNo.Substring(0, 20);
			}
			// --- ADD 2010/05/07 ----------<<<<<
			else
			{
				return filePartsNo;
            }
        }

        /// <summary>
        /// B/O数の処理
        /// </summary>
        /// <param name="fileBONum">*-ZZZ (BO区分＋"-"＋BO数)</param>
        /// <returns>B/O数</returns>
        /// <remarks>
        /// <br>Note       : 品番の処理を行う</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private int GetBONum(string fileBONum)
        {
            if (string.IsNullOrEmpty(fileBONum))
            {
                return 0;
            }

            int indexStr = fileBONum.IndexOf("-");

            return this.StringToInt(fileBONum.Substring(indexStr + 1));
        }

        /// <summary>
        /// カンマ削除処理
        /// </summary>
        /// <param name="targetText">カンマ削除前テキスト</param>
        /// <remarks>
        /// <br>Note	   : 対象のテキストからカンマを削除します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private string RemoveComma(string targetText)
        {
            if (string.IsNullOrEmpty(targetText))
            {
                return "";
            }
            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマのみ削除
                if (targetText[i].ToString() == ",")
                {
                    targetText = targetText.Remove(i, 1);
                }
            }

            return targetText;
        }
        #endregion

		# region -- 確定処理 --
		/// <summary>
		/// 確定処理
		/// </summary>
		/// <param name="answerDateMitsubishiPara">画面情報</param>
		/// <param name="errMessage">メッセージ</param>
		/// <returns>チェック結果。　0：正常；　-1：異常</returns>
		/// <remarks>
		/// <br>Note       : 確定処理する。</br>
		/// <br>Programmer : 肖緒徳</br>
		/// <br>Date       : 2010/04/21</br>
		/// <br>UpdateNote : </br>
		/// </remarks>
		public override int DoConfirm(AnswerDateMitsubishiPara answerDateMitsubishiPara, out string errMessage)
		{
			errMessage = string.Empty;
			// 元の確認処理を呼出し
			int status = base.DoConfirm(answerDateMitsubishiPara, out errMessage);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 三菱WebUOE発注回答ファイルを削除
				string filePathName = answerDateMitsubishiPara.AnswerSaveFolder + "\\UOE_Out.csv";
				if (File.Exists(filePathName))
					File.Delete(filePathName);
			}
			return status;
		}
		#endregion
	}
}
