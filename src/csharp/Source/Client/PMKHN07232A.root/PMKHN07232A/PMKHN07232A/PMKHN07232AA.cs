//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点情報マスタ（エクスポート）
// プログラム概要   : 拠点情報マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 拠点情報マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点情報マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class SecExportSetAcs
    {
        #region ■ Private Member
        private ISecInfoSetDB _iSecInfoSetDB = null;
        private const string PRINTSET_TABLE = "SectionExp";
        #endregion

        # region ■Constracter
        /// <summary>
        /// 拠点情報マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public SecExportSetAcs()
        {
            this._iSecInfoSetDB = (ISecInfoSetDB)MediationSecInfoSetDB.GetSecInfoSetDB();
        }
        #endregion

        #region ■ 拠点情報マスタ情報検索
        /// <summary>
        /// 拠点情報マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(SecExportSetWork condition, out DataTable dataTable)
        {
            int status = 0;
            string message = "";
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);

            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

            secInfoSetWork.EnterpriseCode = condition.EnterpriseCode;
            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            SecInfoSetWork[] al;
            byte[] retbyte;
            status = this._iSecInfoSetDB.Search(out retbyte, parabyte, 0, logicalMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // XMLの読み込み
                al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte, typeof(SecInfoSetWork[]));

                CompanyNmAcs companyNmAcs = new CompanyNmAcs();
                ArrayList companyList = null;
                int companystatus = 0;
                try
                {
                    companystatus = companyNmAcs.Search(out companyList, condition.EnterpriseCode);
                }
                catch (Exception e)
                {
                    message = e.Message;
                    status = 1000;
                }
                bool noCompanyFlag;
                if (companystatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL || companystatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND 
                    || companystatus == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    for (int i = 0; i < al.Length; i++)
                    {
                        noCompanyFlag = true;
                        SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];
                        int checkstatus = DataCheck(wkSecInfoSetWork, condition);
                        if (checkstatus == 0)
                        {
                            foreach (CompanyNm companyNm in companyList)
                            {
                                if (wkSecInfoSetWork.CompanyNameCd1 == companyNm.CompanyNameCd)
                                {
                                    noCompanyFlag = false;
                                    ConverToDataSetWarehouseInf(wkSecInfoSetWork, companyNm, ref dataTable);
                                }
                            }
                            if (noCompanyFlag)
                            {
                                CompanyNm companyNm = new CompanyNm();
                                ConverToDataSetWarehouseInf(wkSecInfoSetWork, companyNm, ref dataTable);
                            }
                        }
                    }
                }
                else
                {
                    return companystatus;
                }

            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        # endregion

        #region ■ Private Methods
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="secInfoSetWork">拠点情報データ</param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataCheck(SecInfoSetWork secInfoSetWork, SecExportSetWork condition)
        {
            int status = 0;
            int sectionCd = Int32.Parse(secInfoSetWork.SectionCode.Trim());
            if (!String.IsNullOrEmpty(condition.SectionCodeSt.Trim()) && sectionCd < Int32.Parse(condition.SectionCodeSt.Trim()))
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(condition.SectionCodeEd.Trim()) && sectionCd > Int32.Parse(condition.SectionCodeEd.Trim()))
            {
                status = -1;
                return status;
            }
            return status;
        }

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("SectionCodeRF", typeof(string));             //  拠点コード
            dataTable.Columns.Add("SectionGuideNmRF", typeof(string));	        //  拠点ガイド名称
            dataTable.Columns.Add("SectionGuideSnmRF", typeof(string));	        //  拠点ガイド略称
            dataTable.Columns.Add("IntroductionDate", typeof(string));	        //  導入年月日
            dataTable.Columns.Add("SectWarehouseCd1RF", typeof(string));	    //  拠点倉庫コード１
            dataTable.Columns.Add("SectWarehouseCd2RF", typeof(string));	    //  拠点倉庫コード２
            dataTable.Columns.Add("SectWarehouseCd3RF", typeof(string));	    //  拠点倉庫コード３

            dataTable.Columns.Add("CompanyNameCdRF", typeof(string));	        //  自社名称コード
            dataTable.Columns.Add("CompanyName1RF", typeof(string));	        //  自社名称１
            dataTable.Columns.Add("CompanyName2RF", typeof(string));	        //  自社名称２
            dataTable.Columns.Add("CompanyPrRF", typeof(string));	            //  自社ＰＲ文
            dataTable.Columns.Add("CompanyPrSentence2RF", typeof(string));	    //  自社ＰＲ文２
            dataTable.Columns.Add("PostNoRF", typeof(string));	                //  郵便番号
            dataTable.Columns.Add("Address1RF", typeof(string));	            //  住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("Address3RF", typeof(string));	            //  住所3（番地）
            dataTable.Columns.Add("Address4RF", typeof(string));	            //  住所4（アパート名称）
            dataTable.Columns.Add("CompanyTelNo1RF", typeof(string));	        //  自社電話番号１
            dataTable.Columns.Add("CompanyTelNo2RF", typeof(string));	        //  自社電話番号２
            dataTable.Columns.Add("CompanyTelNo3RF", typeof(string));	        //  自社電話番号３
            dataTable.Columns.Add("CompanySetNote1RF", typeof(string));	        //  自社設定摘要１
            dataTable.Columns.Add("CompanySetNote2RF", typeof(string));	        //  自社設定摘要２

            dataTable.Columns.Add("TransferGuidanceRF", typeof(string));	    //  銀行振込案内文

            dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	        //  銀行口座1
            dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	        //  銀行口座２
            dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	        //  銀行口座３
            dataTable.Columns.Add("CompanyUrlRF", typeof(string));	            //  自社URL
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="wkSecInfoSetWork">検索結果</param>
        /// <param name="companyNm">検索結果</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(SecInfoSetWork wkSecInfoSetWork, CompanyNm companyNm, ref DataTable dataTable)
        {

            DataRow dataRow = dataTable.NewRow();

            dataRow["SectionCodeRF"] = AppendZero(wkSecInfoSetWork.SectionCode.Trim(), 2);
            dataRow["SectionGuideNmRF"] = GetSubString(wkSecInfoSetWork.SectionGuideNm, 6);
            dataRow["SectionGuideSnmRF"] = GetSubString(wkSecInfoSetWork.SectionGuideSnm, 10);
            if (wkSecInfoSetWork.IntroductionDate == DateTime.MinValue)
            {
                dataRow["IntroductionDate"] = DBNull.Value;
            }
            else
            {
                dataRow["IntroductionDate"] = TDateTime.DateTimeToLongDate("YYYYMMDD", wkSecInfoSetWork.IntroductionDate).ToString();
            }
            dataRow["SectWarehouseCd1RF"] = AppendStrZero(wkSecInfoSetWork.SectWarehouseCd1.Trim(), 4);
            dataRow["SectWarehouseCd2RF"] = AppendStrZero(wkSecInfoSetWork.SectWarehouseCd2.Trim(), 4);
            dataRow["SectWarehouseCd3RF"] = AppendStrZero(wkSecInfoSetWork.SectWarehouseCd3.Trim(), 4);

            if (companyNm.CompanyNameCd != 0)
            {
                dataRow["CompanyNameCdRF"] = AppendZero(companyNm.CompanyNameCd.ToString(), 4);
                dataRow["CompanyName1RF"] = GetSubString(companyNm.CompanyName1, 20);
                dataRow["CompanyName2RF"] = GetSubString(companyNm.CompanyName2, 20);
                dataRow["CompanyPrRF"] = GetSubString(companyNm.CompanyPr, 20);
                dataRow["CompanyPrSentence2RF"] = GetSubString(companyNm.CompanyPrSentence2, 20);
                dataRow["PostNoRF"] = GetSubString(companyNm.PostNo, 10);
                dataRow["Address1RF"] = GetSubString(companyNm.Address1, 30);
                dataRow["Address3RF"] = GetSubString(companyNm.Address3, 22);
                dataRow["Address4RF"] = GetSubString(companyNm.Address4, 30);
                dataRow["CompanyTelNo1RF"] = GetSubString(companyNm.CompanyTelNo1, 16);
                dataRow["CompanyTelNo2RF"] = GetSubString(companyNm.CompanyTelNo2, 16);
                dataRow["CompanyTelNo3RF"] = GetSubString(companyNm.CompanyTelNo3, 16);
                dataRow["CompanySetNote1RF"] = GetSubString(companyNm.CompanySetNote1, 20);
                dataRow["CompanySetNote2RF"] = GetSubString(companyNm.CompanySetNote2, 20);
                dataRow["TransferGuidanceRF"] = GetSubString(companyNm.TransferGuidance, 20);
                dataRow["AccountNoInfo1RF"] = GetSubString(companyNm.AccountNoInfo1, 30);
                dataRow["AccountNoInfo2RF"] = GetSubString(companyNm.AccountNoInfo2, 30);
                dataRow["AccountNoInfo3RF"] = GetSubString(companyNm.AccountNoInfo3, 30);
                dataRow["CompanyUrlRF"] = GetSubString(companyNm.CompanyUrl, 60);
            }

            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Trim().Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString();
        }
        # endregion
    }
}
