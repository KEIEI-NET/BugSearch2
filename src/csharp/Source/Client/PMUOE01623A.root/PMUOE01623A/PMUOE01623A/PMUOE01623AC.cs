//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 修 正 日  2010/03/18  修正内容 : redmine#4044,4046とソース指摘の修正 
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 修 正 日  2010/03/23  修正内容 : redmine#4160の対応 
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 鄧潘ハン
// 修 正 日  2010/12/31  修正内容 : 自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。 
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 修 正 日  2011/03/01  修正内容 : 日産自動化追加仕様分の組み込み
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/15  修正内容 : Redmine #19948の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2011/12/02  修正内容 : Redmine#8304の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 作 成 日  2011/12/18  修正内容 : Redmine#26901の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenw
// 作 成 日  2013/03/07  修正内容 : 2013/04/03配信分
//                                  Redmine#34989の対応 日産UOEWEBの改良(ＯＰＥＮ価格対応)
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 日産Web-UOE発注回答データの構築クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 日産Web-UOE発注回答データの構築クラスを行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : 李占川 2010/03/18 redmine#4044,4046とソース指摘の修正</br>
    /// <br>Update Note: 2010/03/23 李占川 redmine#4160の対応</br>
    /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
    /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
    /// <br>UpdateNpet :2011/03/01 liyp 日産自動化追加仕様分の組み込み</br>
    /// <br>UpdateNpet :2011/03/15 曹文傑 Redmine #19948の対応 </br>
    /// </remarks>
    public sealed class NissanWebUOEOrderDtlInfoBuilder : UOEOrderDtlInfoBuilder
    {
        # region -- プライベート変数 --
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private NISSAN_H nissan_h = new NISSAN_H();
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
        /// BO伝票番号3(タイトル)	
        /// </summary>
        public static string BOSLIPNO3 = "BOSlipNo3";
        /// <summary>
        /// 出荷数(タイトル)		
        /// </summary>
        public static string BOSHIPMENTCNT3 = "BOShipmentCnt3";
        /// <summary>
        /// ﾒｰｶｰﾌｫﾛｰ数(タイトル)	
        /// </summary>
        public static string MAKERFOLLOWCNT = "MakerFollowCnt";
        /// <summary>
        /// BO管理番号	
        /// </summary>
        public static string BOMANAGEMENTNO = "BOManagementNo";
        /// <summary>
        /// EO引当数	
        /// </summary>
        public static string EOALWCCOUNT = "EOAlwcCount";

        //ヘッドエラーメッセージ
        private const string MSG_SZE = "ｻｰﾋﾞｽ ｼﾞｶﾝﾀｲｴﾗｰ";	// 0x13 
        private const string MSG_STT = "ｻｰﾋﾞｽ ﾃｲｼﾁｭｳ";	// 0x17
        private const string MSG_STE = "ｿﾉﾀｴﾗｰ";	// 0x99
        private const string MSG_ECD = "ｴﾗｰｺｰﾄﾞ";	// 他

        private const string COMMASSEMBLY_ID = "0203";
        private const string AUTOCOMMASSEMBLY_ID = "0204";  // ADD 2010/12/31
        private const string OPENFLAG1 = "OPEN"; // ADD chenw 2013/03/07 Redmine#34989
        private const string OPENFLAG2 = "OPEN価格"; // ADD chenw 2013/03/07 Redmine#34989
        //---ADD 2010/12/31----------------------------------------------->>>>>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //ＵＯＥ発注先アクセスクラス
        private UOESupplierAcs _uoeSupplierAcs;
        //ＵＯＥ発注先
        private List<UOESupplier> _uoeSupplier01623;
        private  int UOESupplierFlag = 0;
        //---ADD 2010/12/31-----------------------------------------------<<<<<
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// </remarks>
        //public NissanWebUOEOrderDtlInfoBuilder() // DEL 2010/03/18
        public NissanWebUOEOrderDtlInfoBuilder()
            : base() // ADD 2010/03/18
        {
            //---ADD 2010/12/31----------------------------------------------->>>>>
            this._uoeSupplierAcs = new UOESupplierAcs();
            this.CacheUOESupplier_01623();
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
            foreach (UOESupplier uoeSupplier in _uoeSupplier01623)
            {
                if (("0204").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 1;
                    break;
                }
                // --------ADD 2011/03/01 ---------------->>>>>
                if (("0203").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 2;
                    break;
                }
                if (("0205").Equals(uoeSupplier.CommAssemblyId) && uoeSupplier.InqOrdDivCd==0)
                {
                    UOESupplierFlag = 3;
                    break;
                }
                if (("0205").Equals(uoeSupplier.CommAssemblyId) && uoeSupplier.InqOrdDivCd == 1)
                {
                    UOESupplierFlag = 4;
                    break;
                }
                if (("0206").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 5;
                    break;
                }
                // --------ADD 2011/03/01 ----------------<<<<<
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br>
        /// <br>UpdateNpet :2011/03/01 liyp 日産自動化追加仕様分の組み込み</br>
        /// <br>UpdateNpet :2011/03/15 曹文傑 Redmine #19948の対応 </br>
        /// </remarks>
        //public override int GetFilesDate(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage) // DEL 2010/03/18
        protected override int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage) // ADD 2010/03/18
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this._dataTable.Clear();

            CacheUOESupplier_01623(); // ADD 2010/12/31

            GetSupplierFlag();// ADD 2010/12/31
            this.SetUOESupplierFlag(UOESupplierFlag); // ADD 2011/03/15
            // ファイル情報
            filesDataDtlList = new List<UOEOrderDtlInfo>();

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            FileStream fileStream = null;
            try
            {
                string filePathName = "";
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                string timeFormat = "yyyyMMddHHmmss";
                DateTime dt = DateTime.Now;
                string bakFilePathName = string.Empty;
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                #region HKAITO.DATを取込
                List<UOEOrderDtlInfo> datDataDtlList = new List<UOEOrderDtlInfo>();
                //---UPD 2010/12/31----------------------------------------------->>>>>
                //if (UOESupplierFlag != 1) // DEL 2011/03/01
                //if (UOESupplierFlag == 2 && UOESupplierFlag == 3) // ADD 2011/03/01 //DEL BY 凌小青 on 2011/12/02 for Redmine#8304
                if (UOESupplierFlag == 2 || UOESupplierFlag == 3)//ADD BY 凌小青 on 2011/12/02 for Redmine#8304
                {
                    filePathName = answerSaveFolder + "\\HKAITO.DAT";
                    //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                    if (File.Exists(filePathName))
                    {
                        bakFilePathName = answerSaveFolder + "\\HKAITO_" + dt.ToString(timeFormat) + ".DAT";
                        File.Copy(filePathName, bakFilePathName);//ADD BY 凌小青 on 2011/12/18 for Redmine#26901
                    }
                    //File.Copy(filePathName, bakFilePathName);//DEL BY 凌小青 on 2011/12/18 for Redmine#26901
                    //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                    if (File.Exists(filePathName))
                    {
                        try
                        {
                            // HKAITO.DATファイル使用中判断
                            fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                        }
                        catch (IOException)
                        {
                            errMessage = "発注回答ファイルが使用中です。";
                            // 異常場合
                            return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        }

                        int recordLength = 256;
                        int num = (int)fileStream.Length / recordLength;

                        for (int i = 0; i < num; i++)
                        {
                            this.nissan_h.Clear(0x00);

                            byte[] line = new byte[recordLength];
                            fileStream.Read(line, 0, line.Length);
                            this.FromByteArray(line);
                            this.ConverDatToUOEOrderDtlInfo(ref datDataDtlList);

                            if (!uoeRemarkDic.ContainsKey(UoeCommonFnc.ToStringFromByteStrAry(nissan_h.cmto).Trim()))
                            {
                                uoeRemarkDic.Add(UoeCommonFnc.ToStringFromByteStrAry(nissan_h.cmto).Trim(), null);
                            }
                        }

                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }    
                    //---UPD 2010/12/31-----------------------------------------------<<<<<
                }
                #endregion

                #region Order.csvを取込
                List<UOEOrderDtlInfo> orderDataDtlList = new List<UOEOrderDtlInfo>();
                filePathName = answerSaveFolder + "\\Order.csv";
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                if (File.Exists(filePathName))
                {
                    bakFilePathName = answerSaveFolder + "\\Order_" + dt.ToString(timeFormat) + ".csv";
                    File.Copy(filePathName, bakFilePathName);
                }
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                if (File.Exists(filePathName))
                {
                    try
                    {
                        // Order.csvファイル使用中判断
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
                    List<string[]> tempCsvDataList = new List<string[]>();//ADD 2011/03/01
                    string uoeRemark2 = "";
                    for (int row = 0; row < csvDataList.Count; row++)
                    {
                        string[] detailInfo = csvDataList[row];

                        //---UPD 2010/12/31----------------------------------------------->>>>>
                        if (UOESupplierFlag == 1 || UOESupplierFlag == 4)
                        {
                            // ヘッダー：ユーザー情報
                            if (detailInfo.Length == 10)
                            {
                                uoeRemark2 = detailInfo[7].Trim(); // コメント1
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // ＵＯＥリマーク２
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // コメント1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                        }
                       // -------ADD 2011/03/01 -------------------->>>>>
                        else if (UOESupplierFlag == 5)//0206
                        {
                            string renKeNo = "";
                            // ヘッダー：ユーザー情報
                            if (detailInfo.Length == 10)
                            {
                                if (row != 0)
                                {
                                    string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                    if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                    {
                                        //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                        renKeNo = tempDetailInfo[0].Trim().Replace("-",""); // ADD 2011/03/15
                                    }
                                    for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                    {
                                        UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                        tempDetailInfo = tempCsvDataList[i];
                                        uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                        uOEOrderDtlNissanInfo.RenkeNo = renKeNo; // 連携番号
                                        //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                        if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                        {
                                            continue;
                                        }
                                        int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                        if (ret == -1)
                                        {
                                            continue;
                                        }
                                        orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                                    }
                                    tempCsvDataList.Clear();
                                }
                                uoeRemark2 = detailInfo[7].Trim(); // コメント2
                                continue;
                            }
                            tempCsvDataList.Add(detailInfo);
                            
                            if (csvDataList.Count - 1 == row)
                              {
                                  string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                  if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                  {
                                      //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                      renKeNo = tempDetailInfo[0].Trim().Replace("-", ""); // ADD 2011/03/15
                                  }
                                  for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                  {
                                      UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                      tempDetailInfo = tempCsvDataList[i];
                                      uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                      uOEOrderDtlNissanInfo.RenkeNo = renKeNo; // // 連携番号
                                      //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                      if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                      {
                                          continue;
                                      }
                                      int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                      if (ret == -1)
                                      {
                                          continue;
                                      }
                                      orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                                  }
                                  tempCsvDataList.Clear();
                              }

                            continue;
                        }
                       // -------ADD 2011/03/01 --------------------<<<<<
                        else
                        {
                            // ヘッダー：ユーザー情報
                            if (detailInfo.Length == 10)
                            {
                                // ---UPD 2011/03/01--------------->>>>>
                                //uoeRemark2 = detailInfo[6].Trim(); // コメント1
                                if (UOESupplierFlag == 2)
                                {
                                    uoeRemark2 = detailInfo[6].Trim(); // コメント1
                                }
                                else if (UOESupplierFlag == 3)
                                {
                                    uoeRemark2 = detailInfo[7].Trim(); // コメント2
                                }
                                else
                                {
                                    //なし。
                                }
                                // ---UPD 2011/03/01---------------<<<<<
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // ＵＯＥリマーク２
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // コメント1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                        }
                        //---UPD 2010/12/31-----------------------------------------------<<<<<
                    }
                }
                #endregion

                #region OrderAns.csvを取込
                List<UOEOrderDtlInfo> orderAnsDataDtlList = new List<UOEOrderDtlInfo>();
                filePathName = answerSaveFolder + "\\OrderAns.csv";
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                if (File.Exists(filePathName))
                {
                    bakFilePathName = answerSaveFolder + "\\OrderAns_" + dt.ToString(timeFormat) + ".csv";
                    File.Copy(filePathName, bakFilePathName);
                }
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                if (File.Exists(filePathName))
                {
                    try
                    {
                        // OrderAns.csvファイル使用中判断
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
                    List<string[]> tempCsvDataList = new List<string[]>(); //ADD 2011/03/01
                    string uoeRemark2 = "";
                    for (int row = 0; row < csvDataList.Count; row++)
                    {
                        string[] detailInfo = csvDataList[row];

                        //---UPD 2010/12/31----------------------------------------------->>>>>
                        // ---UPD 2011/03/01------------->>>>>
                        //if (UOESupplierFlag == 1)
                        if (UOESupplierFlag == 1 || UOESupplierFlag == 4)
                        // ---UPD 2011/03/01-------------<<<<<
                        {
                            // ヘッダー：ユーザー情報
                            if (detailInfo.Length == 10)
                            {
                                uoeRemark2 = detailInfo[7]; // コメント1
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // ＵＯＥリマーク２
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // コメント1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                        }
                        // -------ADD 2011/03/01 -------------------->>>>>
                        else if (UOESupplierFlag == 5)
                        {
                            string renKeNo = "";
                            // ヘッダー：ユーザー情報
                            if (detailInfo.Length == 10)
                            {
                                if (row != 0)
                                {
                                    string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                    if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                    {
                                        //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                        renKeNo = tempDetailInfo[0].Trim().Replace("-",""); // ADD 2011/03/15
                                    }
                                    for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                    {
                                        UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                        tempDetailInfo = tempCsvDataList[i];
                                        uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                        uOEOrderDtlNissanInfo.RenkeNo = renKeNo;// 連携番号
                                        //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                        if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                        {
                                            continue;
                                        }
                                        int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                        if (ret == -1)
                                        {
                                            continue;
                                        }
                                        orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                                    }
                                    tempCsvDataList.Clear();
                                }
                                uoeRemark2 = detailInfo[7].Trim(); // コメント2
                                continue;
                            }
                            tempCsvDataList.Add(detailInfo);

                            if (csvDataList.Count - 1 == row)
                            {
                                string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                {
                                    //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                    renKeNo = tempDetailInfo[0].Trim().Replace("-", ""); // ADD 2011/03/15
                                }
                                for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                {
                                    UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                    tempDetailInfo = tempCsvDataList[i];
                                    uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                    uOEOrderDtlNissanInfo.RenkeNo = renKeNo; // 連携番号
                                    //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                    if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                    {
                                        continue;
                                    }
                                    int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                    if (ret == -1)
                                    {
                                        continue;
                                    }
                                    orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                                }
                                tempCsvDataList.Clear();
                            }
                            continue;
                        }
                        // -------ADD 2011/03/01 --------------------<<<<<
                        else
                        {
                            // ヘッダー：ユーザー情報
                            if (detailInfo.Length == 10)
                            {
                                // -------UPD 2011/03/01 -------------------->>>>>
                                //uoeRemark2 = detailInfo[6]; // コメント1
                                if (UOESupplierFlag == 2)
                                {
                                    uoeRemark2 = detailInfo[6]; // コメント1
                                }
                                else if (UOESupplierFlag == 3)
                                {
                                    uoeRemark2 = detailInfo[7]; // コメント2
                                }
                                else
                                {
                                    //なし。
                                }
                                // -------UPD 2011/03/01 --------------------<<<<<
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // ＵＯＥリマーク２
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // コメント1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                            //---UPD 2010/12/31-----------------------------------------------<<<<<
                        }
                    }
                }
                #endregion

                filesDataDtlList = datDataDtlList;
                // ---------UPD 2011/03/01 ------------------------->>>>>
                if (UOESupplierFlag == 5)
                {
                    // Order.csv
                    foreach (UOEOrderDtlInfo orderInfo in orderDataDtlList)
                    {
                        string renkeNo = orderInfo.RenkeNo;
                        if (!uoeRemarkDic.ContainsKey(renkeNo))
                        {
                            List<UOEOrderDtlInfo> tempList = orderDataDtlList.FindAll(
                                                delegate(UOEOrderDtlInfo info)
                                                {
                                                    if (info.RenkeNo  == renkeNo)
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

                            uoeRemarkDic.Add(renkeNo.Trim(), null);
                        }
                    }

                    // OrderAns.csv
                    foreach (UOEOrderDtlInfo orderAnsInfo in orderAnsDataDtlList)
                    {
                        string renkeNo = orderAnsInfo.RenkeNo;
                        if (!uoeRemarkDic.ContainsKey(renkeNo))
                        {
                            List<UOEOrderDtlInfo> tempList = orderAnsDataDtlList.FindAll(
                                                delegate(UOEOrderDtlInfo info)
                                                {
                                                    if (info.RenkeNo  == renkeNo)
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

                            uoeRemarkDic.Add(renkeNo.Trim(), null);
                        }
                    }
                }
                else
                {
                    // Order.csv
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

                    // OrderAns.csv
                    foreach (UOEOrderDtlInfo orderAnsInfo in orderAnsDataDtlList)
                    {
                        string uoeRemark2 = orderAnsInfo.UoeRemark2;
                        if (!uoeRemarkDic.ContainsKey(uoeRemark2))
                        {
                            List<UOEOrderDtlInfo> tempList = orderAnsDataDtlList.FindAll(
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
                }
                
                // ---------UPD 2011/03/01 -------------------------<<<<<
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
        /// 日産発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">RCV情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 日産発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
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
            // ---UPD 2011/03/01-------------->>>>>
            //else
            //{
            //    foreach (UOEOrderDtlWork work in list)
            //    {
            //        if (work.CommAssemblyId == COMMASSEMBLY_ID
            //            && work.UoeRemark2 == remark2
            //            && work.DataRecoverDiv == 0)
            //        {
            //            retList.Add(work);
            //        }
            //    }
            //}
            else if (UOESupplierFlag == 2)
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
            else if (UOESupplierFlag == 3 || UOESupplierFlag == 4)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == "0205"
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            else if (UOESupplierFlag == 5)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == "0206"
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            // ---UPD 2011/03/01--------------<<<<<
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// <br>UpdateNote : liyp 2011/03/01 日産UOE自動化B対応</br>
        /// </remarks>
        //public override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList) // DEL 2010/03/18
        protected override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList) // ADD 2010/03/18
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
                        //BO出庫数3							
                        workList[i].BOShipmentCnt3 = dateList[i].BOShipmentCnt3;
                        //メーカーフォロー数							
                        workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
                        //UOE拠点伝票番号							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO伝票№1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO伝票№2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;
                        //BO伝票№3							
                        workList[i].BOSlipNo3 = dateList[i].BOSlipNo3;
                        // EO引当数
                        workList[i].EOAlwcCount = dateList[i].EOAlwcCount;
                        // BO管理番号
                        workList[i].BOManagementNo = dateList[i].BOManagementNo;
                        //回答定価				
                        workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        //回答原価単価							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
                        // 層別コード
                        workList[i].PartsLayerCd = dateList[i].PartsLayerCd;
                        // ＢＯ数
                        workList[i].BOCount = dateList[i].BOCount;
                        //ラインエラーメッセージ	
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // データ送信区分
                        workList[i].DataSendCode = dateList[i].DataSendCode;
                        // -------ADD 2011/03/01 ------------------------->>>>>
                        if (UOESupplierFlag == 5)
                        {
                            // リマーク2
                            workList[i].UoeRemark2 = dateList[i].UoeRemark2;
                        }
                        // -------ADD 2011/03/01 -------------------------<<<<<
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public override void DataTableColumnConstruction() // DEL 2010/03/18
        protected override void DataTableColumnConstruction() // ADD 2010/03/18
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
            table.Columns.Add(BOSLIPNO3, typeof(string)); // BO伝票番号3(タイトル)				
            table.Columns.Add(BOSHIPMENTCNT3, typeof(Int32)); // BO管理番号	
            table.Columns.Add(BOMANAGEMENTNO, typeof(string)); // ＥＯ	
            table.Columns.Add(EOALWCCOUNT, typeof(Int32)); // EO引当数
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
            table.Columns[UOESECTIONSLIPNO].Caption = "自拠点"; // 拠点伝票番号(タイトル)				
            table.Columns[UOESECTOUTGOODSCNT].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO1].Caption = "サブ"; // BO伝票番号1(タイトル)				
            table.Columns[BOSHIPMENTCNT1].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO2].Caption = "メイン"; // BO伝票番号2(タイトル)				
            table.Columns[BOSHIPMENTCNT2].Caption = "出荷数"; // 出荷数(タイトル)				
            table.Columns[BOSLIPNO3].Caption = "他拠点"; // BO伝票番号3(タイトル)				
            table.Columns[BOSHIPMENTCNT3].Caption = "出荷数"; // 出荷数(タイトル)
            table.Columns[BOMANAGEMENTNO].Caption = "ＥＯ"; // BO管理番号	
            table.Columns[EOALWCCOUNT].Caption = "出荷数"; // EO引当数
            table.Columns[MAKERFOLLOWCNT].Caption = "ＢＯ"; // ﾒｰｶｰﾌｫﾛｰ数(タイトル)	

            this._dataTable = table;
        }

        /// <summary>
        /// データセット行増加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット行増加処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public override void DataTableAddRow(List<UOEOrderDtlWork> workList) // DEL 2010/03/18
        protected override void DataTableAddRow(List<UOEOrderDtlWork> workList) // ADD 2010/03/18
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
                //自拠点								
                row[UOESECTIONSLIPNO] = work.UOESectionSlipNo;
                //出荷数
                row[UOESECTOUTGOODSCNT] = work.UOESectOutGoodsCnt;
                //サブ								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //出荷数								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //メイン								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //出荷数								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //他拠点								
                row[BOSLIPNO3] = work.BOSlipNo3;
                //出荷数								
                row[BOSHIPMENTCNT3] = work.BOShipmentCnt3;
                //ＢＯ								
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;
                //ＥＯ
                row[BOMANAGEMENTNO] = work.BOManagementNo;
                //出荷数								
                row[EOALWCCOUNT] = work.EOAlwcCount;

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void FromByteArray(byte[] line)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(line, 0, line.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ms.Read(nissan_h.usercd, 0, nissan_h.usercd.Length);
            ms.Read(nissan_h.otscd, 0, nissan_h.otscd.Length);
            ms.Read(nissan_h.nhkbn, 0, nissan_h.nhkbn.Length);
            ms.Read(nissan_h.isycd, 0, nissan_h.isycd.Length);
            ms.Read(nissan_h.stsec, 0, nissan_h.stsec.Length);
            ms.Read(nissan_h.bin, 0, nissan_h.bin.Length);
            ms.Read(nissan_h.cmto, 0, nissan_h.cmto.Length);
            ms.Read(nissan_h.bhnum, 0, nissan_h.bhnum.Length);
            ms.Read(nissan_h.bokbn, 0, nissan_h.bokbn.Length);
            ms.Read(nissan_h.bnnm, 0, nissan_h.bnnm.Length);
            ms.Read(nissan_h.hqsu, 0, nissan_h.hqsu.Length);
            ms.Read(nissan_h.bosbr, 0, nissan_h.bosbr.Length);
            ms.Read(nissan_h.zsec_sksu, 0, nissan_h.zsec_sksu.Length);
            ms.Read(nissan_h.zsec_nohno, 0, nissan_h.zsec_nohno.Length);
            ms.Read(nissan_h.zsec_szhs, 0, nissan_h.zsec_szhs.Length);
            ms.Read(nissan_h.zsec_szzhsu, 0, nissan_h.zsec_szzhsu.Length);
            ms.Read(nissan_h.sbst_seccd, 0, nissan_h.sbst_seccd.Length);
            ms.Read(nissan_h.sbst_sksu, 0, nissan_h.sbst_sksu.Length);
            ms.Read(nissan_h.sbst_nohno, 0, nissan_h.sbst_nohno.Length);
            ms.Read(nissan_h.sbst_szhs, 0, nissan_h.sbst_szhs.Length);
            ms.Read(nissan_h.minst_seccd, 0, nissan_h.minst_seccd.Length);
            ms.Read(nissan_h.minst_sksu, 0, nissan_h.minst_sksu.Length);
            ms.Read(nissan_h.minst_nohno, 0, nissan_h.minst_nohno.Length);
            ms.Read(nissan_h.minst_szhs, 0, nissan_h.minst_szhs.Length);
            ms.Read(nissan_h.hsec_seccd, 0, nissan_h.hsec_seccd.Length);
            ms.Read(nissan_h.hsec_sksu, 0, nissan_h.hsec_sksu.Length);
            ms.Read(nissan_h.hsec_nohno, 0, nissan_h.hsec_nohno.Length);
            ms.Read(nissan_h.htzhsu, 0, nissan_h.htzhsu.Length);
            ms.Read(nissan_h.fskusu, 0, nissan_h.fskusu.Length);
            ms.Read(nissan_h.mkeobhsu, 0, nissan_h.mkeobhsu.Length);
            ms.Read(nissan_h.eohtsu, 0, nissan_h.eohtsu.Length);
            ms.Read(nissan_h.mkbosu, 0, nissan_h.mkbosu.Length);
            ms.Read(nissan_h.ytnokbn, 0, nissan_h.ytnokbn.Length);
            ms.Read(nissan_h.ytnodate, 0, nissan_h.ytnodate.Length);
            ms.Read(nissan_h.bomno, 0, nissan_h.bomno.Length);
            ms.Read(nissan_h.zszkosu, 0, nissan_h.zszkosu.Length);
            ms.Read(nissan_h.tekiyo, 0, nissan_h.tekiyo.Length);
            ms.Read(nissan_h.skkku, 0, nissan_h.skkku.Length);
            ms.Read(nissan_h.bhsb, 0, nissan_h.bhsb.Length);
            ms.Read(nissan_h.srtb, 0, nissan_h.srtb.Length);
            ms.Read(nissan_h.srdate, 0, nissan_h.srdate.Length);
            ms.Read(nissan_h.srtime, 0, nissan_h.srtime.Length);
            ms.Read(nissan_h.cmto2, 0, nissan_h.cmto2.Length);
            ms.Read(nissan_h.smsbru, 0, nissan_h.smsbru.Length);
            ms.Read(nissan_h.htosrdate, 0, nissan_h.htosrdate.Length);
            ms.Read(nissan_h.htosrtime, 0, nissan_h.htosrtime.Length);
            ms.Read(nissan_h.szhhz, 0, nissan_h.szhhz.Length);
            ms.Read(nissan_h.zszkhz, 0, nissan_h.zszkhz.Length);
            ms.Read(nissan_h.errmkbn, 0, nissan_h.errmkbn.Length);
            ms.Read(nissan_h.errm, 0, nissan_h.errm.Length);
            ms.Read(nissan_h.bo_errmkbn, 0, nissan_h.bo_errmkbn.Length);
            ms.Read(nissan_h.bokg_num, 0, nissan_h.bokg_num.Length);
            ms.Read(nissan_h.yobi, 0, nissan_h.yobi.Length);
            ms.Read(nissan_h.mtart, 0, nissan_h.mtart.Length);

            ms.Close();
        }

        /// <summary>
        /// 日産発注回答ファイルのﾚｺｰﾄﾞの処理
        /// </summary>
        /// <param name="datDataDtlList">ﾚｺｰﾄﾞリスト</param>
        /// <remarks>
        /// <br>Note       : 日産発注回答ファイルのﾚｺｰﾄﾞを処理</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ConverDatToUOEOrderDtlInfo(ref List<UOEOrderDtlInfo> datDataDtlList)
        {
            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

            // ＵＯＥリマーク２
            uOEOrderDtlNissanInfo.UoeRemark2 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.cmto).Trim();

            // 連携Noチェック
            if (!this.CheckUoeRemark2(uOEOrderDtlNissanInfo.UoeRemark2))
            {
                return;
            }
            // 受信日付
            uOEOrderDtlNissanInfo.ReceiveDate = DateTime.Today;
            // 受信時刻
            uOEOrderDtlNissanInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss"));
            // 回答品番
            uOEOrderDtlNissanInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bhnum);
            // 品番チェック
            if (uOEOrderDtlNissanInfo.AnswerPartsNo.Trim() == string.Empty)
            {
                return;
            }
            // 回答品名
            uOEOrderDtlNissanInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bnnm);
            // 代替品番
            uOEOrderDtlNissanInfo.SubstPartsNo = this.GetSubstPartsNo(UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bnnm));
            // 拠点出庫数
            uOEOrderDtlNissanInfo.UOESectOutGoodsCnt = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.zsec_sksu);
            // BO出庫数1
            uOEOrderDtlNissanInfo.BOShipmentCnt1 = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.sbst_sksu);
            // BO出庫数2
            uOEOrderDtlNissanInfo.BOShipmentCnt2 = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.minst_sksu);
            // BO出庫数3
            uOEOrderDtlNissanInfo.BOShipmentCnt3 = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.hsec_sksu);
            // メーカーフォロー数
            uOEOrderDtlNissanInfo.MakerFollowCnt = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.mkbosu);
            // UOE拠点伝票番号
            uOEOrderDtlNissanInfo.UOESectionSlipNo = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.zsec_nohno);
            // BO伝票№1
            uOEOrderDtlNissanInfo.BOSlipNo1 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.sbst_nohno);
            // BO伝票№2
            uOEOrderDtlNissanInfo.BOSlipNo2 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.minst_nohno);
            // BO伝票№3
            uOEOrderDtlNissanInfo.BOSlipNo3 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.hsec_nohno);
            // EO引当数
            uOEOrderDtlNissanInfo.EOAlwcCount = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.eohtsu);
            // BO管理番号
            uOEOrderDtlNissanInfo.BOManagementNo = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bomno);
            // 回答定価
            uOEOrderDtlNissanInfo.AnswerListPrice = UoeCommonFnc.ToDoubleFromByteStrAry(nissan_h.tekiyo);
            // 回答原価単価
            uOEOrderDtlNissanInfo.AnswerSalesUnitCost = UoeCommonFnc.ToDoubleFromByteStrAry(nissan_h.skkku);
            // 層別コード
            uOEOrderDtlNissanInfo.PartsLayerCd = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bhsb);
            // ＢＯ数
            uOEOrderDtlNissanInfo.BOCount = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.bokg_num);
            // ラインエラーメッセージ
            uOEOrderDtlNissanInfo.LineErrorMassage = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.errm);
            // データ送信区分
            uOEOrderDtlNissanInfo.DataSendCode = 5;

            datDataDtlList.Add(uOEOrderDtlNissanInfo);
        }

        /// <summary>
        /// 日産発注回答ファイルのﾚｺｰﾄﾞの処理
        /// </summary>
        /// <param name="uOEOrderDtlNissanInfo">発注回答データ</param>
        /// <param name="detailInfo">CSVのlineデータ</param>
        /// <remarks>
        /// <br>Note       : 日産発注回答ファイルのﾚｺｰﾄﾞを処理</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int ConverStringToUOEOrderDtlInfo(ref UOEOrderDtlInfo uOEOrderDtlNissanInfo, string[] detailInfo)
        {
            // 受信日付
            uOEOrderDtlNissanInfo.ReceiveDate = DateTime.Today; // システム日付
            // 受信時刻
            uOEOrderDtlNissanInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss")); // システム時刻
            // 回答品番
            uOEOrderDtlNissanInfo.AnswerPartsNo = this.GetPartsNo(detailInfo[0]);  // 部品番号
            if (uOEOrderDtlNissanInfo.AnswerPartsNo.Trim() == string.Empty)
            {
                return -1;
            }
            // 回答品名
            uOEOrderDtlNissanInfo.AnswerPartsName = detailInfo[8]; // 部品名称
            // 代替品番
            uOEOrderDtlNissanInfo.SubstPartsNo = this.GetSubstPartsNo(detailInfo[8]);   // 部品名称の4ﾊﾞｲﾄ目から　※1
            // 拠点出庫数
            uOEOrderDtlNissanInfo.UOESectOutGoodsCnt = this.GetUOESectOutGoodsCnt(detailInfo[5]); // 出庫数（自拠点）
            // BO出庫数1
            uOEOrderDtlNissanInfo.BOShipmentCnt1 = this.GetBOShipmentCnt(detailInfo[12]);  // 出庫数（サブセンター）
            // BO出庫数2
            uOEOrderDtlNissanInfo.BOShipmentCnt2 = this.GetBOShipmentCnt(detailInfo[20]);  // 出庫数（メインセンター）
            // BO出庫数2
            uOEOrderDtlNissanInfo.BOShipmentCnt3 = this.GetBOShipmentCnt(detailInfo[24]);  // 出庫数（他拠点）
            // メーカーフォロー数
            uOEOrderDtlNissanInfo.MakerFollowCnt = this.GetMakerFollowCnt(detailInfo[9]);  // メーカーBO
            // UOE拠点伝票番号
            uOEOrderDtlNissanInfo.UOESectionSlipNo = detailInfo[6]; // 納品書No（自拠点）
            // BO伝票№1
            uOEOrderDtlNissanInfo.BOSlipNo1 = detailInfo[13]; // 納品書No（サブセンター）
            // BO伝票№1
            uOEOrderDtlNissanInfo.BOSlipNo2 = detailInfo[21]; // 納品書No（メインセンター）
            // BO伝票№1
            uOEOrderDtlNissanInfo.BOSlipNo3 = detailInfo[25]; //  納品書No（他拠点）
            // EO引当数
            uOEOrderDtlNissanInfo.EOAlwcCount = this.StringToInt(detailInfo[4]); // EO発注引当
            // BO管理番号
            uOEOrderDtlNissanInfo.BOManagementNo = detailInfo[16];// BO管理No
            // 回答定価
            uOEOrderDtlNissanInfo.AnswerListPrice = this.StringToDouble(this.RemoveComma(detailInfo[10]));// 摘要
            // 回答原価単価
            uOEOrderDtlNissanInfo.AnswerSalesUnitCost = this.StringToDouble(this.RemoveComma(detailInfo[3]));// 仕切
            // ＢＯ数
            uOEOrderDtlNissanInfo.BOCount = this.GetBONum(detailInfo[2]);// B/O数
            // データ送信区分
            uOEOrderDtlNissanInfo.DataSendCode = 5;// 5:回答埋込
            // ---- ADD chenw 2013/03/07 Redmine#34989 ------------->>>>>
            // ラインエラーメッセージ
            if (OPENFLAG1.Equals(detailInfo[10].Trim()))
            {
                uOEOrderDtlNissanInfo.LineErrorMassage = OPENFLAG2;
            }
            // ---- ADD chenw 2013/03/07 Redmine#34989 -------------<<<<<

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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private string GetPartsNo(string filePartsNo)
        {
            if (string.IsNullOrEmpty(filePartsNo))
            {
                return "";
            }

            if (filePartsNo.Length > 12)
            {
                return filePartsNo.Substring(0, 12);
            }
            else
            {
                return filePartsNo;
            }
        }

        /// <summary>
        /// 代替品番の設定処理
        /// </summary>
        /// <param name="partsNo">ｺｰﾄﾞ</param>
        /// <returns>代替品番</returns>
        /// <remarks>
        /// <br>Note       : 代替品番の設定処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>Update Note: 2010/03/23 李占川 redmine#4160の対応</br>
        /// </remarks>
        private string GetSubstPartsNo(string partsNo)
        {
            // 発注回答ﾃﾞｰﾀの「部品名称」の上3桁が"F2△"から"F5△"の場合
            // もしくは"B2△"から"B5△"の場合は品名の4ﾊﾞｲﾄ目以降をｾｯﾄ
            // --- UPD 2010/03/23 ---------->>>>>
            //if (("F2 ".CompareTo(partsNo) < 0 && "F5 ".CompareTo(partsNo) > 0)
            //    || ("B2 ".CompareTo(partsNo) < 0 && "B5 ".CompareTo(partsNo) > 0))
            
            //{
            //    return partsNo.Substring(3);
            //}

            if (!string.IsNullOrEmpty(partsNo) && partsNo.Length >= 3)
            {
                string substPartsNo = partsNo.Substring(0, 3);

                if (("F2 ".Equals(substPartsNo)) || ("F3 ".Equals(substPartsNo)) || ("F4 ".Equals(substPartsNo))
                    || ("F5 ".Equals(substPartsNo)) || ("B2 ".Equals(substPartsNo)) || ("B3 ".Equals(substPartsNo))
                    || ("B4 ".Equals(substPartsNo)) || ("B5 ".Equals(substPartsNo)))
                {
                    return partsNo.Substring(3);
                }
            }
            // --- UPD 2010/03/23 ----------<<<<<

            return string.Empty;
        }

        /// <summary>
        /// B/O数の処理
        /// </summary>
        /// <param name="fileBONum">*-ZZZ (BO区分＋"-"＋BO数)</param>
        /// <returns>B/O数</returns>
        /// <remarks>
        /// <br>Note       : 品番の処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
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

        /// <summary>
        /// 出庫数(自拠点)の処理
        /// </summary>
        /// <param name="fileUOESectOutGoodsCnt">自:ZZZ ("自:"＋出庫数)</param>
        /// <returns>出庫数(自拠点)</returns>
        /// <remarks>
        /// <br>Note       : 出庫数(自拠点)の処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 redmine#4044の修正</br>
        /// </remarks>
        private int GetUOESectOutGoodsCnt(string fileUOESectOutGoodsCnt)
        {
            if (string.IsNullOrEmpty(fileUOESectOutGoodsCnt))
            {
                return 0;
            }

            // --- UPD 2010/03/18 ---------->>>>>
            //return this.StringToInt(fileUOESectOutGoodsCnt.Substring(2));
            int indexStr = fileUOESectOutGoodsCnt.IndexOf(":");

            return this.StringToInt(fileUOESectOutGoodsCnt.Substring(indexStr + 1));
            // --- UPD 2010/03/18 ----------<<<<<
        }

        /// <summary>
        /// メーカBOの処理
        /// </summary>
        /// <param name="fileMakerFollowCnt">*-ZZZ (BO区分＋"-"＋BO数)</param>
        /// <returns>メーカBO</returns>
        /// <remarks>
        /// <br>Note       : メーカBOの処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int GetMakerFollowCnt(string fileMakerFollowCnt)
        {
            if (string.IsNullOrEmpty(fileMakerFollowCnt))
            {
                return 0;
            }

            int indexStr = fileMakerFollowCnt.IndexOf("-");

            return this.StringToInt(fileMakerFollowCnt.Substring(indexStr + 1));
        }

        /// <summary>
        /// 出庫数の処理
        /// </summary>
        /// <param name="fileBOShipmentCnt">ZZZ:ZZZ (拠点ｺｰﾄﾞ＋":"＋出庫数)</param>
        /// <returns>出庫数</returns>
        /// <remarks>
        /// <br>Note       : 出庫数の処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int GetBOShipmentCnt(string fileBOShipmentCnt)
        {
            if (string.IsNullOrEmpty(fileBOShipmentCnt))
            {
                return 0;
            }

            int indexStr = fileBOShipmentCnt.IndexOf(":");

            return this.StringToInt(fileBOShipmentCnt.Substring(indexStr + 1));
        }
        #endregion

        # region  -- 日産Web-UOE発注回答データクラス --
        /// <summary>
        /// 日産発注回答ファイル＜本体＞
        /// </summary>
        private class NISSAN_H
        {
            public byte[] usercd = new byte[6];		//           ユーザーコード
            public byte[] otscd = new byte[6];		//           お届け先コード     
            public byte[] nhkbn = new byte[1];		//           納品区分  
            public byte[] isycd = new byte[2];		//           依頼者コード     
            public byte[] stsec = new byte[3];		//           指定拠点 
            public byte[] bin = new byte[1];		//           便    
            public byte[] cmto = new byte[10];		//           コメント     
            public byte[] bhnum = new byte[12];		//           部品番号     
            public byte[] bokbn = new byte[1];		//           BO区分     
            public byte[] bnnm = new byte[16];		//           部品名称     
            public byte[] hqsu = new byte[5];		//           発注数    
            public byte[] bosbr = new byte[1];		//           BOシンボル   
            public byte[] zsec_sksu = new byte[5];	//           自拠点・出庫数　    
            public byte[] zsec_nohno = new byte[6];	//           自拠点・納品書No　　    
            public byte[] zsec_szhs = new byte[1];	//           自拠点・仕掛在庫引当シンボル    
            public byte[] zsec_szzhsu = new byte[5];//           自拠点・仕掛    
            public byte[] sbst_seccd = new byte[3];	//           サブセンター・拠点コード　    
            public byte[] sbst_sksu = new byte[5];	//           サブセンター・出庫数　　　    
            public byte[] sbst_nohno = new byte[6];	//           サブセンター・納品書No　　    
            public byte[] sbst_szhs = new byte[1];	//           サブセンター・仕掛在庫引当シンボル　    
            public byte[] minst_seccd = new byte[3];//           メインセンター・拠点コード　    
            public byte[] minst_sksu = new byte[5];	//           メインセンター・出庫数　　    
            public byte[] minst_nohno = new byte[6];//           メインセンター・納品書No　
            public byte[] minst_szhs = new byte[1];	//           メインセンター・仕掛在庫引当シンボル　　
            public byte[] hsec_seccd = new byte[3];	//           他拠点・拠点コード　
            public byte[] hsec_sksu = new byte[5];	//           他拠点・出庫数　　
            public byte[] hsec_nohno = new byte[6];	//           他拠点・納品書No　
            public byte[] htzhsu = new byte[5];		//           発注残引当数　　
            public byte[] fskusu = new byte[5];		//           不足数
            public byte[] mkeobhsu = new byte[12];	//           メーカーEO引当部品番号	
            public byte[] eohtsu = new byte[3];		//           EO発注引当数	
            public byte[] mkbosu = new byte[3];		//           メーカーBO数	
            public byte[] ytnokbn = new byte[1];	//           予定納期区分	
            public byte[] ytnodate = new byte[4];	//           予定納期日	
            public byte[] bomno = new byte[6];		//           BO管理No	
            public byte[] zszkosu = new byte[5];	//           全社在庫数	
            public byte[] tekiyo = new byte[7];		//           摘要	
            public byte[] skkku = new byte[7];		//           仕切り価格	
            public byte[] bhsb = new byte[2];		//           部品層別	
            public byte[] srtb = new byte[6];		//           出力通番	
            public byte[] srdate = new byte[6];		//           処理年月日	
            public byte[] srtime = new byte[4];		//           処理時間	
            public byte[] cmto2 = new byte[10];		//           コメント２	
            public byte[] smsbru = new byte[1];		//           ２世代前シンボル	
            public byte[] htosrdate = new byte[8];	//           ホスト処理年月日	
            public byte[] htosrtime = new byte[4];	//           ホスト処理時間	
            public byte[] szhhz = new byte[1];		//           仕掛在庫引当表示	
            public byte[] zszkhz = new byte[1];		//           全社在庫表示	
            public byte[] errmkbn = new byte[1];	//           エラーメッセージ区分	
            public byte[] errm = new byte[12];		//           エラーメッセージ	
            public byte[] bo_errmkbn = new byte[1];	//           BO結果・メッセージ区分	
            public byte[] bokg_num = new byte[5];	//           BO結果・数量	
            public byte[] yobi = new byte[9];	    //           予備	
            public byte[] mtart = new byte[2];	    //           (復改)	



            /// <summary>	
            /// コンストラクター
            /// </summary>
            public NISSAN_H()
            {
                Clear(0x00);
            }

            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref usercd, cd, usercd.Length);
                UoeCommonFnc.MemSet(ref otscd, cd, otscd.Length);
                UoeCommonFnc.MemSet(ref nhkbn, cd, nhkbn.Length);
                UoeCommonFnc.MemSet(ref isycd, cd, isycd.Length);
                UoeCommonFnc.MemSet(ref stsec, cd, stsec.Length);
                UoeCommonFnc.MemSet(ref bin, cd, bin.Length);
                UoeCommonFnc.MemSet(ref cmto, cd, cmto.Length);
                UoeCommonFnc.MemSet(ref bhnum, cd, bhnum.Length);
                UoeCommonFnc.MemSet(ref bokbn, cd, bokbn.Length);
                UoeCommonFnc.MemSet(ref bnnm, cd, bnnm.Length);
                UoeCommonFnc.MemSet(ref hqsu, cd, hqsu.Length);
                UoeCommonFnc.MemSet(ref bosbr, cd, bosbr.Length);
                UoeCommonFnc.MemSet(ref zsec_sksu, cd, zsec_sksu.Length);
                UoeCommonFnc.MemSet(ref zsec_nohno, cd, zsec_nohno.Length);
                UoeCommonFnc.MemSet(ref zsec_szhs, cd, zsec_szhs.Length);
                UoeCommonFnc.MemSet(ref zsec_szzhsu, cd, zsec_szzhsu.Length);
                UoeCommonFnc.MemSet(ref sbst_seccd, cd, sbst_seccd.Length);
                UoeCommonFnc.MemSet(ref sbst_sksu, cd, sbst_sksu.Length);
                UoeCommonFnc.MemSet(ref sbst_nohno, cd, sbst_nohno.Length);
                UoeCommonFnc.MemSet(ref sbst_szhs, cd, sbst_szhs.Length);
                UoeCommonFnc.MemSet(ref minst_seccd, cd, minst_seccd.Length);
                UoeCommonFnc.MemSet(ref minst_sksu, cd, minst_sksu.Length);
                UoeCommonFnc.MemSet(ref minst_nohno, cd, minst_nohno.Length);
                UoeCommonFnc.MemSet(ref minst_szhs, cd, minst_szhs.Length);
                UoeCommonFnc.MemSet(ref hsec_seccd, cd, hsec_seccd.Length);
                UoeCommonFnc.MemSet(ref hsec_sksu, cd, hsec_sksu.Length);
                UoeCommonFnc.MemSet(ref hsec_nohno, cd, hsec_nohno.Length);
                UoeCommonFnc.MemSet(ref htzhsu, cd, htzhsu.Length);
                UoeCommonFnc.MemSet(ref fskusu, cd, fskusu.Length);
                UoeCommonFnc.MemSet(ref mkeobhsu, cd, mkeobhsu.Length);
                UoeCommonFnc.MemSet(ref eohtsu, cd, eohtsu.Length);
                UoeCommonFnc.MemSet(ref mkbosu, cd, mkbosu.Length);
                UoeCommonFnc.MemSet(ref ytnokbn, cd, ytnokbn.Length);
                UoeCommonFnc.MemSet(ref ytnodate, cd, ytnodate.Length);
                UoeCommonFnc.MemSet(ref bomno, cd, bomno.Length);
                UoeCommonFnc.MemSet(ref zszkosu, cd, zszkosu.Length);
                UoeCommonFnc.MemSet(ref tekiyo, cd, tekiyo.Length);
                UoeCommonFnc.MemSet(ref skkku, cd, skkku.Length);
                UoeCommonFnc.MemSet(ref bhsb, cd, bhsb.Length);
                UoeCommonFnc.MemSet(ref srtb, cd, srtb.Length);
                UoeCommonFnc.MemSet(ref srdate, cd, srdate.Length);
                UoeCommonFnc.MemSet(ref srtime, cd, srtime.Length);
                UoeCommonFnc.MemSet(ref cmto2, cd, cmto2.Length);
                UoeCommonFnc.MemSet(ref smsbru, cd, smsbru.Length);
                UoeCommonFnc.MemSet(ref htosrdate, cd, htosrdate.Length);
                UoeCommonFnc.MemSet(ref htosrtime, cd, htosrtime.Length);
                UoeCommonFnc.MemSet(ref szhhz, cd, szhhz.Length);
                UoeCommonFnc.MemSet(ref zszkhz, cd, zszkhz.Length);
                UoeCommonFnc.MemSet(ref errmkbn, cd, errmkbn.Length);
                UoeCommonFnc.MemSet(ref errm, cd, errm.Length);
                UoeCommonFnc.MemSet(ref bo_errmkbn, cd, bo_errmkbn.Length);
                UoeCommonFnc.MemSet(ref bokg_num, cd, bokg_num.Length);
                UoeCommonFnc.MemSet(ref yobi, cd, yobi.Length);
                UoeCommonFnc.MemSet(ref mtart, cd, mtart.Length);
            }
        }
        # endregion
    }
}
