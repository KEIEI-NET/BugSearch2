//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 作 成 日  2011/05/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 修 正 日  2011/05/27  修正内容 : Redmine#21759の対応
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 修 正 日  2011/05/27  修正内容 : Redmine#21795の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/10/18  修正内容 : WEB発注分が考慮されていない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2011/12/02  修正内容 : Redmine#8304の対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 李侠
// 作 成 日  2012/03/07  修正内容 : Redmine#28795マツダ回答データ取り込み処理の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// マツダWeb-UOE発注回答データの構築クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : マツダWeb-UOE発注回答データの構築クラスを行います。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>Update Note: 2011/05/27 曹文傑</br>
    /// <br>              Redmine#21759の対応</br>
    /// <br>Update Note: 2011/05/27 曹文傑</br>
    /// <br>              Redmine#21795の対応</br>
    /// <br>Update Note: 2012/03/07 李侠</br>
    /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
    /// <br>             Redmine#28795マツダ回答データ取り込み処理の対応</br>    
    /// </remarks>
    public sealed class MazdaWebUOEOrderDtlInfoBuilder : UOEOrderDtlInfoBuilder
    {
        # region -- プライベート変数 --
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private MAZDA_H mazda_h = new MAZDA_H();
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

        private const string COMMASSEMBLY_ID = "0403";
        private const string HEADERMARK = "HD";
        private const string FOOTERMARK = "TL";

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //ＵＯＥ発注先アクセスクラス
        private UOESupplierAcs _uoeSupplierAcs;
        //ＵＯＥ発注先
        private List<UOESupplier> _uoeSupplier01623;
        private  int UOESupplierFlag = 0;

        private UOESupplier _uoeSupplier = null;
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public MazdaWebUOEOrderDtlInfoBuilder()
            : base()
        {
            this._uoeSupplierAcs = new UOESupplierAcs();
            this.CacheUOESupplier_01623();
        }
        # endregion

        # region  -- 構築クラスの実装 --
        
        /// <summary>
        /// 手動と自動のFalg取る
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手動と自動のFalg取る</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void GetSupplierFlag()
        {
            foreach (UOESupplier uoeSupplier in _uoeSupplier01623)
            {
                if (COMMASSEMBLY_ID.Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 1;
                    this._uoeSupplier = uoeSupplier;
                    break;
                }
            }

        }

        /// <summary>
        /// ＵＯＥ発注先情報キャッシュ制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注先情報キャッシュ制御処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void CacheUOESupplier_01623()
        {
            _uoeSupplier01623 = new List<UOESupplier>();
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
                    if (UOESupplierCd == target.UOESupplierCd)
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
                    _uoeSupplier01623 = resultList;
                }
            }
            catch (Exception)
            {
                _uoeSupplier01623 = new List<UOESupplier>();
            }

        }
       
        /// <summary>
        /// ファイル情報取得処理
        /// </summary>
        /// <param name="filesDataDtlList">ファイル情報情報</param>
        /// <param name="answerSaveFolder">回答保存フォルダ</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : ファイル情報を取得処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// <br>Update Note: 2012/03/07 李侠</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28795マツダ回答データ取り込み処理の対応</br>    
        /// </remarks>
        protected override int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage) 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this._dataTable.Clear();

            CacheUOESupplier_01623(); 

            GetSupplierFlag();
            // ファイル情報
            filesDataDtlList = new List<UOEOrderDtlInfo>();

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            StreamReader streamReader = null;
            try
            {
                string filePathName = "";

                #region HATTU.MLGを取込
                List<UOEOrderDtlInfo> datDataDtlList = new List<UOEOrderDtlInfo>();

                if (UOESupplierFlag == 1) 
                {
                    filePathName = answerSaveFolder + "\\HATTU.MLG";
                    //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                    string timeFormat = "yyyyMMddHHmmss";
                    DateTime dt = DateTime.Now;
                    string bakFilePathName = answerSaveFolder + "\\HATTU_" + dt.ToString(timeFormat) + ".MLG";                    
                    File.Copy(filePathName, bakFilePathName);
                    //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                    if (File.Exists(filePathName))
                    {
                        try
                        {
                            // HATTU.MLGファイル使用中判断
                            streamReader = new StreamReader(filePathName, Encoding.GetEncoding("Shift-JIS"));
                        }
                        catch (IOException)
                        {
                            errMessage = "発注回答ファイルが使用中です。";
                            // 異常場合
                            return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        }

                        List<string> mlgDateList = new List<string>();
                        string strLine = string.Empty;
                        while ((strLine = streamReader.ReadLine()) != null)
                        {
                            if (strLine.Trim() != string.Empty)
                            {
                                mlgDateList.Add(strLine);
                            }
                        }

                        Dictionary<string, List<string>> mlgDateDic = new Dictionary<string, List<string>>();

                        List<string> mlgDateSubList = new List<string>();

                        List<string> list = null;
                        string uoeRemark2 = string.Empty;
                        for (int rowIndex = 0; rowIndex < mlgDateList.Count; rowIndex++)
                        {
                            string str = mlgDateList[rowIndex];
                            if (HEADERMARK.Equals(str.Substring(0, 2)))
                            {
                                continue;
                            }
                            if (FOOTERMARK.Equals(str.Substring(0, 2)))
                            {
                                if (rowIndex > 0)
                                {
                                    uoeRemark2 = mlgDateList[rowIndex - 1].Substring(2, 12);

                                    //---ADD 李侠 2012/03/07 Redmine#28795------>>>>>
                                    if (uoeRemark2.Substring(0, 3) != _uoeSupplier.HondaSectionCode.Trim())
                                    {
                                        mlgDateSubList.Clear();
                                        continue;
                                    }
                                    //---ADD 李侠 2012/03/07 Redmine#28795------<<<<<

                                    list = new List<string>();
                                    foreach (string s in mlgDateSubList)
                                    {
                                        list.Add(s);
                                    }

                                    mlgDateDic.Add(uoeRemark2, list);
                                    mlgDateSubList.Clear();
                                }
                                continue;
                            }
                            mlgDateSubList.Add(str);
                        }

                        foreach (string reMark in mlgDateDic.Keys)
                        {
                            mlgDateSubList = mlgDateDic[reMark];

                            //---DEL 李侠 2012/03/07 Redmine#28795------>>>>>
                            // 2011/10/18
                            //if (reMark.Substring(0, 3) != _uoeSupplier.HondaSectionCode.Trim())
                            //{
                            //    continue;
                            //}
                            // 2011/10/18
                            //---DEL 李侠 2012/03/07 Redmine#28795------<<<<<

                            for (int i = 0; i < mlgDateSubList.Count; i++)
                            {
                                if (i == mlgDateSubList.Count - 1)
                                {
                                    break;
                                }

                                // 2011/10/18
                                //if (i % 5 != 0 || i == 0)
                                if (mlgDateSubList[i].Substring(2, 12) != reMark || i == 0)
                                // 2011/10/18
                                {
                                    byte[] line = Encoding.GetEncoding("Shift-JIS").GetBytes(mlgDateSubList[i]);
                                    this.FromByteArray(line);
                                    UOEOrderDtlInfo uOEOrderDtlMazdaInfo = new UOEOrderDtlInfo();
                                    uOEOrderDtlMazdaInfo.UoeRemark2 = reMark;
                                    this.ConverDatToUOEOrderDtlInfo(ref uOEOrderDtlMazdaInfo);
                                    if (uOEOrderDtlMazdaInfo != null)
                                    {
                                        datDataDtlList.Add(uOEOrderDtlMazdaInfo);
                                    }
                                }
                            }
                        }

                        filesDataDtlList = datDataDtlList;

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
                if (streamReader != null)
                {
                    streamReader.Dispose();
                    streamReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// マツダ発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">MLG情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : マツダ発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            if (UOESupplierFlag == 1)
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note: 2011/05/27 曹文傑</br>
        /// <br>              Redmine#21759の対応</br>
        /// <br>Update Note: 2011/05/27 曹文傑</br>
        /// <br>              Redmine#21795の対応</br>
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
                        // ---ADD 2011/05/27--------->>>>>
                        // リマーク2のクリア
                        workList[i].UoeRemark2 = string.Empty;
                        // ---ADD 2011/05/27---------<<<<<

                        // 受信日付	
                        workList[i].ReceiveDate = dateList[i].ReceiveDate;
                        //受信時刻
                        workList[i].ReceiveTime = dateList[i].ReceiveTime;
                        if (dateList[i].SubstPartsNo.Trim() == string.Empty && dateList[i].UOESubstMark.Trim() == string.Empty)
                        {
                            //回答品番
                            workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                            //回答品名
                            workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                        }
                        else
                        {
                            //回答品番
                            workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                            //回答品名
                            workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                            //代替品番
                            workList[i].SubstPartsNo = dateList[i].SubstPartsNo;
                            //UOE代替マーク
                            workList[i].UOESubstMark = dateList[i].UOESubstMark;
                        }

                        //拠点出庫数							
                        workList[i].UOESectOutGoodsCnt = dateList[i].UOESectOutGoodsCnt;
                        //BO出庫数1	
                        workList[i].BOShipmentCnt1 = dateList[i].BOShipmentCnt1;
                        //BO出庫数2							
                        workList[i].BOShipmentCnt2 = dateList[i].BOShipmentCnt2;
                        //メーカーフォロー数							
                        workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
                        //UOE拠点伝票番号							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO伝票№1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO伝票№2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;

                        //回答定価
                        // ---UPD 2011/05/27-------------->>>>>
                        //workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        if (dateList[i].AnswerListPrice != 999999)
                        {			
                            workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        }
                        else
                        {			
                            workList[i].AnswerListPrice = 0;
                        }
                        // ---UPD 2011/05/27--------------<<<<<

                        //回答原価単価							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
                        // UOE出荷拠点コード1（マツダ）
                        workList[i].MazdaUOEShipSectCd1 = dateList[i].MazdaUOEShipSectCd1;
                        // UOE出荷拠点コード2（マツダ）
                        workList[i].MazdaUOEShipSectCd2 = dateList[i].MazdaUOEShipSectCd2;
                        // UOE出荷拠点コード3（マツダ）
                        workList[i].MazdaUOEShipSectCd3 = dateList[i].MazdaUOEShipSectCd3;
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
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
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 処理結果
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>処理結果をを取得</remarks>
        public DataTable DetailDataTable
        {
            get { return this._dataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public override void DataTableClear()
        {
            this._dataTable.Clear();
        }
        #endregion

        # region -- データ変換 --
        /// <summary>
        /// バイト型配列に変換
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : バイト型配列に変換を行う。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void FromByteArray(byte[] line)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(line, 0, line.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ms.Read(mazda_h.seqno, 0, mazda_h.seqno.Length);
            ms.Read(mazda_h.bhnum, 0, mazda_h.bhnum.Length);
            ms.Read(mazda_h.trle, 0, mazda_h.trle.Length);
            ms.Read(mazda_h.trsu, 0, mazda_h.trsu.Length);
            ms.Read(mazda_h.num, 0, mazda_h.num.Length);
            ms.Read(mazda_h.ordnum, 0, mazda_h.ordnum.Length);
            ms.Read(mazda_h.shiptt, 0, mazda_h.shiptt.Length);
            ms.Read(mazda_h.bonum, 0, mazda_h.bonum.Length);
            ms.Read(mazda_h.bocd, 0, mazda_h.bocd.Length);
            ms.Read(mazda_h.bhnam, 0, mazda_h.bhnam.Length);
            ms.Read(mazda_h.concc, 0, mazda_h.concc.Length);
            ms.Read(mazda_h.bhnums, 0, mazda_h.bhnums.Length);
            ms.Read(mazda_h.comcd, 0, mazda_h.comcd.Length);
            ms.Read(mazda_h.unitpr, 0, mazda_h.unitpr.Length);
            ms.Read(mazda_h.retpr, 0, mazda_h.retpr.Length);
            ms.Read(mazda_h.seccd1, 0, mazda_h.seccd1.Length);
            ms.Read(mazda_h.slipcd1, 0, mazda_h.slipcd1.Length);
            ms.Read(mazda_h.shipnum1, 0, mazda_h.shipnum1.Length);
            ms.Read(mazda_h.seccd2, 0, mazda_h.seccd2.Length);
            ms.Read(mazda_h.slipcd2, 0, mazda_h.slipcd2.Length);
            ms.Read(mazda_h.shipnum2, 0, mazda_h.shipnum2.Length);
            ms.Read(mazda_h.seccd3, 0, mazda_h.seccd3.Length);
            ms.Read(mazda_h.slipcd3, 0, mazda_h.slipcd3.Length);
            ms.Read(mazda_h.shipnum3, 0, mazda_h.shipnum3.Length);
            ms.Read(mazda_h.seccd4, 0, mazda_h.seccd4.Length);
            ms.Read(mazda_h.slipcd4, 0, mazda_h.slipcd4.Length);
            ms.Read(mazda_h.shipnum4, 0, mazda_h.shipnum4.Length);
            ms.Read(mazda_h.seccd5, 0, mazda_h.seccd5.Length);
            ms.Read(mazda_h.slipcd5, 0, mazda_h.slipcd5.Length);
            ms.Read(mazda_h.shipnum5, 0, mazda_h.shipnum5.Length);
            ms.Read(mazda_h.seccd6, 0, mazda_h.seccd6.Length);
            ms.Read(mazda_h.slipcd6, 0, mazda_h.slipcd6.Length);
            ms.Read(mazda_h.shipnum6, 0, mazda_h.shipnum6.Length);
            ms.Read(mazda_h.seccd7, 0, mazda_h.seccd7.Length);
            ms.Read(mazda_h.slipcd7, 0, mazda_h.slipcd7.Length);
            ms.Read(mazda_h.shipnum7, 0, mazda_h.shipnum7.Length);
            ms.Read(mazda_h.seccd8, 0, mazda_h.seccd8.Length);
            ms.Read(mazda_h.slipcd8, 0, mazda_h.slipcd8.Length);
            ms.Read(mazda_h.shipnum8, 0, mazda_h.shipnum8.Length);
            ms.Read(mazda_h.seccd9, 0, mazda_h.seccd9.Length);
            ms.Read(mazda_h.slipcd9, 0, mazda_h.slipcd9.Length);
            ms.Read(mazda_h.shipnum9, 0, mazda_h.shipnum9.Length);
            ms.Read(mazda_h.seccd10, 0, mazda_h.seccd10.Length);
            ms.Read(mazda_h.slipcd10, 0, mazda_h.slipcd10.Length);
            ms.Read(mazda_h.shipnum10, 0, mazda_h.shipnum10.Length);
            ms.Read(mazda_h.status1, 0, mazda_h.status1.Length);
            ms.Read(mazda_h.mcnum1, 0, mazda_h.mcnum1.Length);
            ms.Read(mazda_h.didate1, 0, mazda_h.didate1.Length);
            ms.Read(mazda_h.status2, 0, mazda_h.status2.Length);
            ms.Read(mazda_h.mcnum2, 0, mazda_h.mcnum2.Length);
            ms.Read(mazda_h.didate2, 0, mazda_h.didate2.Length);
            ms.Read(mazda_h.status3, 0, mazda_h.status3.Length);
            ms.Read(mazda_h.mcnum3, 0, mazda_h.mcnum3.Length);
            ms.Read(mazda_h.didate3, 0, mazda_h.didate3.Length);
            ms.Read(mazda_h.status4, 0, mazda_h.status4.Length);
            ms.Read(mazda_h.mcnum4, 0, mazda_h.mcnum4.Length);
            ms.Read(mazda_h.didate4, 0, mazda_h.didate4.Length);
            ms.Read(mazda_h.status5, 0, mazda_h.status5.Length);
            ms.Read(mazda_h.mcnum5, 0, mazda_h.mcnum5.Length);
            ms.Read(mazda_h.didate5, 0, mazda_h.didate5.Length);
            ms.Read(mazda_h.cmto, 0, mazda_h.cmto.Length);

            ms.Close();
        }

        /// <summary>
        /// マツダ発注回答ファイルのﾚｺｰﾄﾞの処理
        /// </summary>
        /// <param name="uOEOrderDtlMazdaInfo">ﾚｺｰﾄﾞリスト</param>
        /// <remarks>
        /// <br>Note       : マツダ発注回答ファイルのﾚｺｰﾄﾞを処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note: 2011/05/27 曹文傑</br>
        /// <br>              Redmine#21759の対応</br>
        /// </remarks>
        private void ConverDatToUOEOrderDtlInfo(ref UOEOrderDtlInfo uOEOrderDtlMazdaInfo)
        {
            if (uOEOrderDtlMazdaInfo == null)
            {
                uOEOrderDtlMazdaInfo = new UOEOrderDtlInfo();
            }

            // 項目「レベル・サフィックス」が「01・01」以外の場合は、その明細を読み込み対象外とする
            if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.trle) != "01"
                || UoeCommonFnc.ToStringFromByteStrAry(mazda_h.trsu) != "01")
            {
                uOEOrderDtlMazdaInfo = null;
                return;
            }

            // 受信日付
            uOEOrderDtlMazdaInfo.ReceiveDate = DateTime.Today;
            // 受信時刻
            uOEOrderDtlMazdaInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss"));

            // 発注回答ファイルの｢互換性コード｣の先頭１Byteが「半角スペース or 0」以外の場合にセットします。
            if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.comcd).Substring(0, 1) == " "
                || UoeCommonFnc.ToStringFromByteStrAry(mazda_h.comcd).Substring(0, 1) == "0")
            {
                // 回答品番
                uOEOrderDtlMazdaInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnum);
                // 回答品名
                uOEOrderDtlMazdaInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnam);
            }
            else
            {
                // ---UPD 2011/05/27----------------->>>>>
                // 回答品番
                //uOEOrderDtlMazdaInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnums);
                uOEOrderDtlMazdaInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnum);
                // ---UPD 2011/05/27-----------------<<<<<
                // 回答品名
                uOEOrderDtlMazdaInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnam);
                // ---UPD 2011/05/27----------------->>>>>
                // 代替品番
                //uOEOrderDtlMazdaInfo.SubstPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnum);
                uOEOrderDtlMazdaInfo.SubstPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnums);
                // ---UPD 2011/05/27-----------------<<<<<
                // UOE代替マーク
                uOEOrderDtlMazdaInfo.UOESubstMark = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.comcd);
            }

            // 回答定価
            uOEOrderDtlMazdaInfo.AnswerListPrice = UoeCommonFnc.ToDoubleFromByteStrAry(mazda_h.retpr);
            // 回答原価単価
            uOEOrderDtlMazdaInfo.AnswerSalesUnitCost = UoeCommonFnc.ToDoubleFromByteStrAry(mazda_h.unitpr);
            // ラインエラーメッセージ
            uOEOrderDtlMazdaInfo.LineErrorMassage = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.cmto);
            // データ送信区分
            uOEOrderDtlMazdaInfo.DataSendCode = 5;
            // メーカーフォロー数
            uOEOrderDtlMazdaInfo.MakerFollowCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum1)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum2)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum3)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum4)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum5);

            if (this._uoeSupplier == null || this._uoeSupplier.CommAssemblyId.Trim().PadLeft(4, '0') != "0403")
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01623)
                {
                    if (("0403").Equals(uoeSupplier.CommAssemblyId))
                    {
                        this._uoeSupplier = uoeSupplier;
                        break;
                    }
                }
            }

            Dictionary<int, UOEMergeDateInfo> uoeMergeDateDic = new Dictionary<int, UOEMergeDateInfo>();
            this.GetMergeDateDic(out uoeMergeDateDic);
            int count = uoeMergeDateDic.Count;

            if (count == 0)
            {
                // UOE出荷拠点コード１（マツダ）
                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd1 = string.Empty;
                // UOE拠点伝票番号
                uOEOrderDtlMazdaInfo.UOESectionSlipNo = string.Empty;
                // 拠点出庫数
                uOEOrderDtlMazdaInfo.UOESectOutGoodsCnt = 0;
                // UOE出荷拠点コード2（マツダ）
                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = string.Empty;
                // BO伝票№1
                uOEOrderDtlMazdaInfo.BOSlipNo1 = string.Empty;
                // BO出庫数1
                uOEOrderDtlMazdaInfo.BOShipmentCnt1 = 0;
                // UOE出荷拠点コード3（マツダ）
                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                // BO伝票№2
                uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                // BO出庫数2
                uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
            }
            else
            {

                for (int i = 1; i <= count; i++)
                {
                    if (uoeMergeDateDic.ContainsKey(i))
                    {
                        if (uoeMergeDateDic[i].SectionCode == this._uoeSupplier.MazdaSectionCode.Trim().PadLeft(3, ' ').Substring(1, 2))
                        {
                            // UOE出荷拠点コード１（マツダ）
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd1 = uoeMergeDateDic[i].SectionCode;
                            // UOE拠点伝票番号
                            uOEOrderDtlMazdaInfo.UOESectionSlipNo = uoeMergeDateDic[i].SlipNo;
                            // 拠点出庫数
                            uOEOrderDtlMazdaInfo.UOESectOutGoodsCnt = uoeMergeDateDic[i].ShipCnt;
                            uoeMergeDateDic.Remove(i);
                            break;
                        }
                    }
                }

                if (count != uoeMergeDateDic.Count)
                {
                    if (uoeMergeDateDic.Count == 0)
                    {
                        // UOE出荷拠点コード2（マツダ）
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = string.Empty;
                        // BO伝票№1
                        uOEOrderDtlMazdaInfo.BOSlipNo1 = string.Empty;
                        // BO出庫数1
                        uOEOrderDtlMazdaInfo.BOShipmentCnt1 = 0;
                        // UOE出荷拠点コード3（マツダ）
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                        // BO伝票№2
                        uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                        // BO出庫数2
                        uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
                    }
                    else
                    {
                        for (int j = 1; j <= count; j++)
                        {
                            if (uoeMergeDateDic.ContainsKey(j))
                            {
                                // UOE出荷拠点コード2（マツダ）
                                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = uoeMergeDateDic[j].SectionCode;
                                // BO伝票№1
                                uOEOrderDtlMazdaInfo.BOSlipNo1 = uoeMergeDateDic[j].SlipNo;
                                // BO出庫数1
                                uOEOrderDtlMazdaInfo.BOShipmentCnt1 = uoeMergeDateDic[j].ShipCnt;
                                uoeMergeDateDic.Remove(j);
                                break;
                            }
                        }

                        if (uoeMergeDateDic.Count == 0)
                        {
                            // UOE出荷拠点コード3（マツダ）
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                            // BO伝票№2
                            uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                            // BO出庫数2
                            uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
                        }
                        else if (uoeMergeDateDic.Count == 1)
                        {
                            foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                            {
                                // UOE出荷拠点コード3（マツダ）
                                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = info.SectionCode;
                                // BO伝票№2
                                uOEOrderDtlMazdaInfo.BOSlipNo2 = info.SlipNo;
                                // BO出庫数2
                                uOEOrderDtlMazdaInfo.BOShipmentCnt2 = info.ShipCnt;
                            }
                        }
                        else
                        {
                            int shipCntSum = 0;
                            foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                            {
                                shipCntSum += info.ShipCnt;
                            }
                            // UOE出荷拠点コード3（マツダ）
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                            // BO伝票№2
                            uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                            // BO出庫数2
                            uOEOrderDtlMazdaInfo.BOShipmentCnt2 = shipCntSum;
                        }
                    }
                }
                else
                {
                    // UOE出荷拠点コード１（マツダ）
                    uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd1 = string.Empty;
                    // UOE拠点伝票番号
                    uOEOrderDtlMazdaInfo.UOESectionSlipNo = string.Empty;
                    // 拠点出庫数
                    uOEOrderDtlMazdaInfo.UOESectOutGoodsCnt = 0;

                    for (int k = 1; k <= count; k++)
                    {
                        if (uoeMergeDateDic.ContainsKey(k))
                        {
                            // UOE出荷拠点コード2（マツダ）
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = uoeMergeDateDic[k].SectionCode;
                            // BO伝票№1
                            uOEOrderDtlMazdaInfo.BOSlipNo1 = uoeMergeDateDic[k].SlipNo;
                            // BO出庫数1
                            uOEOrderDtlMazdaInfo.BOShipmentCnt1 = uoeMergeDateDic[k].ShipCnt;
                            uoeMergeDateDic.Remove(k);
                            break;
                        }
                    }

                    if (uoeMergeDateDic.Count == 0)
                    {
                        // UOE出荷拠点コード3（マツダ）
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                        // BO伝票№2
                        uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                        // BO出庫数2
                        uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
                    }
                    else if (uoeMergeDateDic.Count == 1)
                    {
                        foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                        {
                            // UOE出荷拠点コード3（マツダ）
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = info.SectionCode;
                            // BO伝票№2
                            uOEOrderDtlMazdaInfo.BOSlipNo2 = info.SlipNo;
                            // BO出庫数2
                            uOEOrderDtlMazdaInfo.BOShipmentCnt2 = info.ShipCnt;
                        }
                    }
                    else
                    {
                        int shipCntSum = 0;
                        foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                        {
                            shipCntSum += info.ShipCnt;
                        }
                        // UOE出荷拠点コード3（マツダ）
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                        // BO伝票№2
                        uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                        // BO出庫数2
                        uOEOrderDtlMazdaInfo.BOShipmentCnt2 = shipCntSum;
                    }
                }
            }
        }

        /// <summary>
        /// 出荷数、伝票№、拠点コードについてセット処理
        /// </summary>
        /// <param name="uoeMergeDateDic">出荷数、伝票№、拠点コードDictionary</param>
        /// <remarks>
        /// <br>Note       : 出荷数、伝票№、拠点コードについてセット処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note: 2011/05/27 曹文傑</br>
        /// <br>              Redmine#21759の対応</br>
        /// </remarks>
        private void GetMergeDateDic(out Dictionary<int, UOEMergeDateInfo> uoeMergeDateDic)
        {
            Dictionary<int, UOEMergeDateInfo> dictionary = new Dictionary<int, UOEMergeDateInfo>();

            //UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd1).Trim(); // DEL 2011/05/27
            int count = 0;
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd1).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum1) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd1);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd1);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum1);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd2).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum2) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd2);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd2);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum2);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd3).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum3) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd3);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd3);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum3);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd4).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum4) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd4);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd4);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum4);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd5).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum5) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd5);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd5);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum5);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd6).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum6) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd6);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd6);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum6);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd7).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum7) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd7);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd7);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum7);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd8).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum8) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd8);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd8);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum8);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd9).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum9) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd9);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd9);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum9);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd10).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum10) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd10);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd10);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum10);
                dictionary.Add(count, uoeMergeDateInfo);
            }

            uoeMergeDateDic = dictionary;
        }
        #endregion

        # region  -- 日産Web-UOE発注回答データクラス --
        /// <summary>
        /// マシダ発注回答ファイル＜本体＞
        /// </summary>
        private class MAZDA_H
        {
            #region -- 明細部 --
            public byte[] seqno = new byte[2];	    //           発注ＳＥＱ№
            public byte[] bhnum = new byte[12];		//           部品番号
            public byte[] trle = new byte[2];		//           振替レベル
            public byte[] trsu = new byte[2];		//           振替サフィックス
            public byte[] num = new byte[2];	    //           員数
            public byte[] ordnum = new byte[5];	    //           注文数
            public byte[] shiptt = new byte[5];		//           出荷数合計
            public byte[] bonum = new byte[5];		//           ＢＯ数
            public byte[] bocd = new byte[1];		//           ＢＯコード
            public byte[] bhnam = new byte[20];		//           部品名
            public byte[] concc = new byte[1];	    //           価格建区分
            public byte[] bhnums = new byte[12];	//           部品番号（注文）
            public byte[] comcd = new byte[2];		//           互換性コード
            public byte[] unitpr = new byte[7];		//           単価（仕切）
            public byte[] retpr = new byte[7];	    //           希望小売価格
            public byte[] seccd1 = new byte[2];	    //           拠点コード1
            public byte[] slipcd1 = new byte[7];	//           伝票№1
            public byte[] shipnum1 = new byte[5];	//           出荷数1
            public byte[] seccd2 = new byte[2];    	//           拠点コード2
            public byte[] slipcd2 = new byte[7];	//           伝票№2
            public byte[] shipnum2 = new byte[5];	//           出荷数2
            public byte[] seccd3 = new byte[2];	    //           拠点コード3
            public byte[] slipcd3 = new byte[7];	//           伝票№3
            public byte[] shipnum3 = new byte[5];	//           出荷数3
            public byte[] seccd4 = new byte[2];	    //           拠点コード4
            public byte[] slipcd4 = new byte[7];	//           伝票№4
            public byte[] shipnum4 = new byte[5];	//           出荷数4
            public byte[] seccd5 = new byte[2];	    //           拠点コード5
            public byte[] slipcd5 = new byte[7];	//           伝票№5
            public byte[] shipnum5 = new byte[5];	//           出荷数5
            public byte[] seccd6 = new byte[2];	    //           拠点コード6
            public byte[] slipcd6 = new byte[7];	//           伝票№6
            public byte[] shipnum6 = new byte[5];	//           出荷数6
            public byte[] seccd7 = new byte[2];	    //           拠点コード7
            public byte[] slipcd7 = new byte[7];	//           伝票№7
            public byte[] shipnum7 = new byte[5];	//           出荷数7
            public byte[] seccd8 = new byte[2];	    //           拠点コード8
            public byte[] slipcd8 = new byte[7];	//           伝票№8
            public byte[] shipnum8 = new byte[5];	//           出荷数8
            public byte[] seccd9 = new byte[2];	    //           拠点コード9
            public byte[] slipcd9 = new byte[7];	//           伝票№9
            public byte[] shipnum9 = new byte[5];	//           出荷数9
            public byte[] seccd10 = new byte[2];	//           拠点コード10
            public byte[] slipcd10 = new byte[7];	//           伝票№10
            public byte[] shipnum10 = new byte[5];	//           出荷数10
            public byte[] status1 = new byte[2];	//           ステータス1
            public byte[] mcnum1 = new byte[4];		//           ＭＣ引当数1
            public byte[] didate1 = new byte[8];	//           お届け日1
            public byte[] status2 = new byte[2];	//           ステータス2
            public byte[] mcnum2 = new byte[4];		//           ＭＣ引当数2
            public byte[] didate2 = new byte[8];	//           お届け日2
            public byte[] status3 = new byte[2];	//           ステータス3
            public byte[] mcnum3 = new byte[4];		//           ＭＣ引当数3
            public byte[] didate3 = new byte[8];	//           お届け日3
            public byte[] status4 = new byte[2];	//           ステータス4
            public byte[] mcnum4 = new byte[4];		//           ＭＣ引当数4
            public byte[] didate4 = new byte[8];	//           お届け日4
            public byte[] status5 = new byte[2];	//           ステータス5
            public byte[] mcnum5 = new byte[4];		//           ＭＣ引当数5
            public byte[] didate5 = new byte[8];	//           お届け日5
            public byte[] cmto = new byte[30];		//           コメント
            #endregion -- 明細部 --

            /// <summary>	
            /// コンストラクター
            /// </summary>
            public MAZDA_H()
            {
                Clear(0x00);
            }

            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref seqno, cd, seqno.Length);
                UoeCommonFnc.MemSet(ref bhnum, cd, bhnum.Length);
                UoeCommonFnc.MemSet(ref trle, cd, trle.Length);
                UoeCommonFnc.MemSet(ref trsu, cd, trsu.Length);
                UoeCommonFnc.MemSet(ref num, cd, num.Length);
                UoeCommonFnc.MemSet(ref ordnum, cd, ordnum.Length);
                UoeCommonFnc.MemSet(ref shiptt, cd, shiptt.Length);
                UoeCommonFnc.MemSet(ref bonum, cd, bonum.Length);
                UoeCommonFnc.MemSet(ref bocd, cd, bocd.Length);
                UoeCommonFnc.MemSet(ref bhnam, cd, bhnam.Length);
                UoeCommonFnc.MemSet(ref concc, cd, concc.Length);
                UoeCommonFnc.MemSet(ref bhnums, cd, bhnums.Length);
                UoeCommonFnc.MemSet(ref comcd, cd, comcd.Length);
                UoeCommonFnc.MemSet(ref unitpr, cd, unitpr.Length);
                UoeCommonFnc.MemSet(ref retpr, cd, retpr.Length);
                UoeCommonFnc.MemSet(ref seccd1, cd, seccd1.Length);
                UoeCommonFnc.MemSet(ref slipcd1, cd, slipcd1.Length);
                UoeCommonFnc.MemSet(ref shipnum1, cd, shipnum1.Length);
                UoeCommonFnc.MemSet(ref seccd2, cd, seccd2.Length);
                UoeCommonFnc.MemSet(ref slipcd2, cd, slipcd2.Length);
                UoeCommonFnc.MemSet(ref shipnum2, cd, shipnum2.Length);
                UoeCommonFnc.MemSet(ref seccd3, cd, seccd3.Length);
                UoeCommonFnc.MemSet(ref slipcd3, cd, slipcd3.Length);
                UoeCommonFnc.MemSet(ref shipnum3, cd, shipnum3.Length);
                UoeCommonFnc.MemSet(ref seccd4, cd, seccd4.Length);
                UoeCommonFnc.MemSet(ref slipcd4, cd, slipcd4.Length);
                UoeCommonFnc.MemSet(ref shipnum4, cd, shipnum4.Length);
                UoeCommonFnc.MemSet(ref seccd5, cd, seccd5.Length);
                UoeCommonFnc.MemSet(ref slipcd5, cd, slipcd5.Length);
                UoeCommonFnc.MemSet(ref shipnum5, cd, shipnum5.Length);
                UoeCommonFnc.MemSet(ref seccd6, cd, seccd6.Length);
                UoeCommonFnc.MemSet(ref slipcd6, cd, slipcd6.Length);
                UoeCommonFnc.MemSet(ref shipnum6, cd, shipnum6.Length);
                UoeCommonFnc.MemSet(ref seccd7, cd, seccd7.Length);
                UoeCommonFnc.MemSet(ref slipcd7, cd, slipcd7.Length);
                UoeCommonFnc.MemSet(ref shipnum7, cd, shipnum7.Length);
                UoeCommonFnc.MemSet(ref seccd8, cd, seccd8.Length);
                UoeCommonFnc.MemSet(ref slipcd8, cd, slipcd8.Length);
                UoeCommonFnc.MemSet(ref shipnum8, cd, shipnum8.Length);
                UoeCommonFnc.MemSet(ref seccd9, cd, seccd9.Length);
                UoeCommonFnc.MemSet(ref slipcd9, cd, slipcd9.Length);
                UoeCommonFnc.MemSet(ref shipnum9, cd, shipnum9.Length);
                UoeCommonFnc.MemSet(ref seccd10, cd, seccd10.Length);
                UoeCommonFnc.MemSet(ref slipcd10, cd, slipcd10.Length);
                UoeCommonFnc.MemSet(ref shipnum10, cd, shipnum10.Length);
                UoeCommonFnc.MemSet(ref status1, cd, status1.Length);
                UoeCommonFnc.MemSet(ref mcnum1, cd, mcnum1.Length);
                UoeCommonFnc.MemSet(ref didate1, cd, didate1.Length);
                UoeCommonFnc.MemSet(ref status2, cd, status2.Length);
                UoeCommonFnc.MemSet(ref mcnum2, cd, mcnum2.Length);
                UoeCommonFnc.MemSet(ref didate2, cd, didate3.Length);
                UoeCommonFnc.MemSet(ref status3, cd, status3.Length);
                UoeCommonFnc.MemSet(ref mcnum3, cd, mcnum3.Length);
                UoeCommonFnc.MemSet(ref didate3, cd, didate3.Length);
                UoeCommonFnc.MemSet(ref status4, cd, status4.Length);
                UoeCommonFnc.MemSet(ref mcnum4, cd, mcnum4.Length);
                UoeCommonFnc.MemSet(ref didate4, cd, didate4.Length);
                UoeCommonFnc.MemSet(ref status5, cd, status5.Length);
                UoeCommonFnc.MemSet(ref mcnum5, cd, mcnum5.Length);
                UoeCommonFnc.MemSet(ref didate5, cd, didate5.Length);
                UoeCommonFnc.MemSet(ref cmto, cd, cmto.Length);
            }
        }
        # endregion

        # region  -- 拠点、伝票№、出荷数クラス --
        /// <summary>
        /// 拠点、伝票№、出荷数クラス（発注回答データをUOE発注データに反映用）
        /// </summary>
        private class UOEMergeDateInfo
        {
            /// <summary>拠点コード</summary>
            private string _sectionCode = string.Empty;

            /// <summary>伝票№</summary>
            private string _slipNo = string.Empty;

            /// <summary>出荷数</summary>
            private int _shipCnt;

            /// public propaty name  :  SectionCode
            /// <summary>拠点コード</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   拠点コード</br>
            /// <br>Programer        :   曹文傑</br>
            /// </remarks>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            /// public propaty name  :  SlipNo
            /// <summary>伝票№</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   伝票№</br>
            /// <br>Programer        :   曹文傑</br>
            /// </remarks>
            public string SlipNo
            {
                get { return _slipNo; }
                set { _slipNo = value; }
            }

            /// public propaty name  :  ShipCnt
            /// <summary>出荷数</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   出荷数</br>
            /// <br>Programer        :   曹文傑</br>
            /// </remarks>
            public int ShipCnt
            {
                get { return _shipCnt; }
                set { _shipCnt = value; }
            }
        }
        #endregion
    }
}
