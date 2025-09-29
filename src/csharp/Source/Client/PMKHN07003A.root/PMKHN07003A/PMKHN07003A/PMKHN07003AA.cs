//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 葉書・封筒・ＤＭテキスト出力
// プログラム概要   : 葉書・封筒・ＤＭテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 葉書・封筒・ＤＭテキスト出力処理クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 葉書・封筒・ＤＭテキスト出力処理クラスのインスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class PostEnvelDMInstsMainAcs
    {
        #region ■ Private Member
        // マスタ検索インタフェース
        private IUseMastListDB _iUseMastListDB;

        private static PostEnvelDMInstsMainAcs _postEnvelDMInstsMainAcs;
        // CSVのDataSet
        private DataSet _dataSet;

        #endregion

        # region ■Constracter

        /// <summary>
        /// 葉書・封筒・ＤＭアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 葉書・封筒・ＤＭアクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public PostEnvelDMInstsMainAcs()
        {
            this._iUseMastListDB = (IUseMastListDB)MediationUseMastDB.GetMastDB();
        }

        /// <summary>
        /// 葉書・封筒・ＤＭアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 葉書・封筒・ＤＭアクセスクラスの新しいインスタンスを初期化します。。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public static PostEnvelDMInstsMainAcs GetInstance()
        {
            if (_postEnvelDMInstsMainAcs == null)
            {
                _postEnvelDMInstsMainAcs = new PostEnvelDMInstsMainAcs();
            }
            return _postEnvelDMInstsMainAcs;
        }

        /// public propaty name  :  DataSet
        /// <summary>DataSetプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   DataSetプロパティを行います。</br>
        /// <br>Programer        :   朱宝軍</br>
        /// </remarks>
        public DataSet UseMastDs
        {
            get { return this._dataSet; }
        }
        # endregion

        #region ■ 使用マスタ情報検索
        /// <summary>
        /// 使用マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="retList">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 使用マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Search(PostcardEnvelopeDMTextCndtn condition, out ArrayList retList)
        {
            _dataSet = new DataSet();
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retList = new ArrayList();
            object retObj = null;
            // 抽出条件展開<画面検索情報->remoteDean>  --------------------------------------------------------------
            PostcardEnvelopeDMWork postcardEnvelopeDMWork = new PostcardEnvelopeDMWork();
            // 抽出条件
            SetCondInfo(ref condition, ref postcardEnvelopeDMWork);

            // データ取得  ----------------------------------------------------------------
            // 得意先マスタデータ取得
            if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Customer)
            {
                status = _iUseMastListDB.SearchCustomer(out retObj, postcardEnvelopeDMWork);
                if (status == 0)
                {
                    ConverToDataSetCustomerInf((ArrayList)retObj);
                }
                retList = (ArrayList)retObj;
            }
            // 仕入先マスタデータ取得
            else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Supplier)
            {
                SupplierAcs supplierAcs = new SupplierAcs();
                status = supplierAcs.Search(out retList, postcardEnvelopeDMWork.EnterpriseCode);
                if (status == 0)
                {
                    ConverToDataSetSupplierInf(retList, condition);
                    if (_dataSet.Tables["SupplierExp"].DefaultView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

            }
            // 自社マスタデータ取得
            else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.Company)
            {
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                CompanyInf companyInf = null;
                status = companyInfAcs.Read(out companyInf, postcardEnvelopeDMWork.EnterpriseCode);
                if (status == 0)
                {
                    ConverToDataSetCompanyInf(companyInf);
                    if (_dataSet.Tables["CompanyExp"].DefaultView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

            }
            // 拠点マスタデータ取得
            else if (postcardEnvelopeDMWork.UseMast == (int)PostcardEnvelopeDMTextCndtn.UseMastDivState.SecInfo)
            {
                status = _iUseMastListDB.SearchSecInfoSet(out retObj, postcardEnvelopeDMWork);
                if (status == 0)
                {
                    ConverToDataSetSectionInf((ArrayList)retObj);
                }

                retList = (ArrayList)retObj;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            return status;
        }
        #endregion

        #region ■ Private Methods
        /// <summary>
        /// 検索結果クラスを設定
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="postcardEnvelopeDMWork">検索結果クラス</param>
        /// <remarks>
        /// <br>Note       : 検索結果クラスを設定する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void SetCondInfo(ref PostcardEnvelopeDMTextCndtn condition, ref PostcardEnvelopeDMWork postcardEnvelopeDMWork)
        {
            //企業コード
            postcardEnvelopeDMWork.EnterpriseCode = condition.EnterpriseCode;
            // 使用マスタ
            postcardEnvelopeDMWork.UseMast = condition.UseMast;
            // 出力区分
            postcardEnvelopeDMWork.OutShipDiv = condition.OutShipDiv;
            // 締日
            postcardEnvelopeDMWork.TotalDay = condition.TotalDay;
            // 対象日付開始日
            postcardEnvelopeDMWork.St_AddUpDay = condition.St_AddUpDay;
            // 対象日付終了日
            postcardEnvelopeDMWork.Ed_AddUpDay = condition.Ed_AddUpDay;
            // 拠点コード開始
            postcardEnvelopeDMWork.St_SectionCode = condition.St_SectionCode;
            // 拠点コード終了
            postcardEnvelopeDMWork.Ed_SectionCode = condition.Ed_SectionCode;
            // 得意先コード開始
            postcardEnvelopeDMWork.St_CustomerCode = condition.St_CustomerCode;
            // 得意先コード終了
            postcardEnvelopeDMWork.Ed_CustomerCode = condition.Ed_CustomerCode;
            // 仕入先コード開始
            postcardEnvelopeDMWork.St_SupplierCode = condition.St_SupplierCode;
            // 仕入先コード終了
            postcardEnvelopeDMWork.Ed_SupplierCode = condition.Ed_SupplierCode;
        }
        /// <summary>
        /// 検索結果をConvertToDataSet
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(ArrayList retList)
        {
            // データセット格納用データテーブル
            DataTable dataTable = new DataTable("CustomerExp");

            // カラム追加
            # region カラム追加(CSVデータ用)
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));      //  管理拠点コード
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));	    //  得意先コード
            dataTable.Columns.Add("NameRF", typeof(string));	            //  名称
            dataTable.Columns.Add("Name2RF", typeof(string));	            //  名称2
            dataTable.Columns.Add("PostNoRF", typeof(string));	            //  郵便番号
            dataTable.Columns.Add("Address1RF", typeof(string));	        //  住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("Address3RF", typeof(string));	        //  住所3（番地）
            dataTable.Columns.Add("Address4RF", typeof(string));	        //  住所4（アパート名称）
            dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	        //  電話番号（勤務先）
            dataTable.Columns.Add("HomeTelNoRF", typeof(string));	        //  電話番号（自宅）
            dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	        //  FAX番号（勤務先）
            dataTable.Columns.Add("CustomerAgentRF", typeof(string));	    //  得意先担当者
            foreach (PostCustomerWork customerWork in retList)
            {
                DataRow dataRow = dataTable.NewRow();
                // 管理拠点コード
                StringBuilder tempSection = new StringBuilder();
                for (int i = customerWork.MngSectionCode.Trim().Length; i < 2; i++)
                {
                    tempSection.Append("0");
                }
                tempSection.Append(customerWork.MngSectionCode);
                dataRow["MngSectionCodeRF"] = tempSection.ToString().Trim();
                // 得意先コード
                StringBuilder tempCustCd = new StringBuilder();
                for (int i = customerWork.CustomerCode.ToString().Length; i < 8; i++)
                {
                    tempCustCd.Append("0");
                }
                tempCustCd.Append(customerWork.CustomerCode);
                dataRow["CustomerCodeRF"] = tempCustCd.ToString().Trim();
                // 名称
                dataRow["NameRF"] = customerWork.Name.Trim();
                // 名称2
                dataRow["Name2RF"] = customerWork.Name2.Trim();
                // 郵便番号
                dataRow["PostNoRF"] = customerWork.PostNo.Trim();
                // 住所1（都道府県市区郡・町村・字）
                dataRow["Address1RF"] = customerWork.Address1.Trim();
                // 住所3（番地）
                dataRow["Address3RF"] = customerWork.Address3.Trim();
                // 住所4（アパート名称）
                dataRow["Address4RF"] = customerWork.Address4.Trim();
                // 電話番号（勤務先）
                dataRow["OfficeTelNoRF"] = customerWork.OfficeTelNo.Trim();
                // 電話番号（自宅）
                dataRow["HomeTelNoRF"] = customerWork.HomeTelNo.Trim();
                // FAX番号（勤務先）
                dataRow["OfficeFaxNoRF"] = customerWork.OfficeFaxNo.Trim();
                // 得意先担当者
                dataRow["CustomerAgentRF"] = customerWork.CustomerAgent.Trim();
                dataTable.Rows.Add(dataRow);

            }
            #endregion
            _dataSet.Tables.Add(dataTable);
        }
        /// <summary>
        /// 検索結果をConvertToDataSet
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="condition">検索条件</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetSupplierInf(ArrayList retList, PostcardEnvelopeDMTextCndtn condition)
        {
            // データセット格納用データテーブル
            DataTable dataTable = new DataTable("SupplierExp");

            // カラム追加
            # region カラム追加(CSVデータ用)
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));      //  管理拠点コード
            dataTable.Columns.Add("SupplierCdRF", typeof(string));           //  仕入先コード
            dataTable.Columns.Add("SupplierNm1RF", typeof(string));	        //  仕入先名1
            dataTable.Columns.Add("SupplierNm2RF", typeof(string));	        //  仕入先名2
            dataTable.Columns.Add("SupplierPostNoRF", typeof(string));	    //  仕入先郵便番号
            dataTable.Columns.Add("SupplierAddr1RF", typeof(string));	    //  仕入先住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("SupplierAddr3RF", typeof(string));	    //  仕入先住所3（番地）
            dataTable.Columns.Add("SupplierAddr4RF", typeof(string));	    //  仕入先住所4（アパート名称）
            dataTable.Columns.Add("SupplierTelNoRF", typeof(string));	    //  仕入先電話番号
            dataTable.Columns.Add("SupplierTelNo1RF", typeof(string));	    //  仕入先電話番号1
            dataTable.Columns.Add("SupplierTelNo2RF", typeof(string));	    //  仕入先電話番号2

            foreach (Supplier supplier in retList)
            {
                int checkstatus = DataCheck(supplier, condition);
                if (checkstatus == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    // 管理拠点コード
                    StringBuilder tempSection = new StringBuilder();
                    for (int i = supplier.MngSectionCode.Trim().Length; i < 2; i++)
                    {
                        tempSection.Append("0");
                    }
                    tempSection.Append(supplier.MngSectionCode);
                    dataRow["MngSectionCodeRF"] = tempSection.ToString().Trim();
                    // 仕入先コード
                    StringBuilder tempSuppCd = new StringBuilder();
                    for (int i = supplier.SupplierCd.ToString().Length; i < 6; i++)
                    {
                        tempSuppCd.Append("0");
                    }
                    tempSuppCd.Append(supplier.SupplierCd);
                    dataRow["SupplierCdRF"] = tempSuppCd.ToString().Trim();
                    // 仕入先名1
                    dataRow["SupplierNm1RF"] = supplier.SupplierNm1.Trim();
                    // 仕入先名2
                    dataRow["SupplierNm2RF"] = supplier.SupplierNm2.Trim();
                    // 仕入先郵便番号
                    dataRow["SupplierPostNoRF"] = supplier.SupplierPostNo.Trim();
                    // 仕入先住所1（都道府県市区郡・町村・字）
                    dataRow["SupplierAddr1RF"] = supplier.SupplierAddr1.Trim();
                    // 仕入先住所3（番地）
                    dataRow["SupplierAddr3RF"] = supplier.SupplierAddr3.Trim();
                    // 仕入先住所4（アパート名称）
                    dataRow["SupplierAddr4RF"] = supplier.SupplierAddr4.Trim();
                    // 仕入先電話番号
                    dataRow["SupplierTelNoRF"] = supplier.SupplierTelNo.Trim();
                    // 仕入先電話番号1
                    dataRow["SupplierTelNo1RF"] = supplier.SupplierTelNo1.Trim();
                    // 仕入先電話番号2
                    dataRow["SupplierTelNo2RF"] = supplier.SupplierTelNo2.Trim();
                    dataTable.Rows.Add(dataRow);
                }
            }
            #endregion
            _dataSet.Tables.Add(dataTable);
        }
        /// <summary>
        /// 検索結果をConvertToDataSet
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetSectionInf(ArrayList retList)
        {
            // データセット格納用データテーブル
            DataTable dataTable = new DataTable("SectionExp");

            // カラム追加
            # region カラム追加(CSVデータ用)
            dataTable.Columns.Add("SECTIONCODERF", typeof(string));	            //  拠点コード
            dataTable.Columns.Add("COMPANYNAME1RF", typeof(string));	        //  自社名称1
            dataTable.Columns.Add("COMPANYNAME2RF", typeof(string));	        //  自社名称2
            dataTable.Columns.Add("POSTNORF", typeof(string));	                //  郵便番号
            dataTable.Columns.Add("ADDRESS1RF", typeof(string));	            //  住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("ADDRESS3RF", typeof(string));	            //  住所3（番地）
            dataTable.Columns.Add("ADDRESS4RF", typeof(string));	            //  住所4（アパート名称）
            dataTable.Columns.Add("COMPANYTELNO1RF", typeof(string));	        //  自社電話番号1
            dataTable.Columns.Add("COMPANYTELNO2RF", typeof(string));	        //  自社電話番号2
            dataTable.Columns.Add("COMPANYTELNO3RF", typeof(string));	        //  自社電話番号3

            foreach (PostSecInfoSetWork SectionInfCsvData in retList)
            {
                DataRow dataRow = dataTable.NewRow();
                // 拠点コード
                StringBuilder tempSection = new StringBuilder();
                for (int i = SectionInfCsvData.SectionCode.Trim().Length; i < 2; i++)
                {
                    tempSection.Append("0");
                }
                tempSection.Append(SectionInfCsvData.SectionCode);
                dataRow["SECTIONCODERF"] = tempSection.ToString().Trim();
                // 自社名称1
                dataRow["COMPANYNAME1RF"] = SectionInfCsvData.CompanyName1.Trim();
                // 自社名称2
                dataRow["COMPANYNAME2RF"] = SectionInfCsvData.CompanyName2.Trim();
                // 郵便番号
                dataRow["POSTNORF"] = SectionInfCsvData.PostNo.Trim();
                // 住所1（都道府県市区郡・町村・字）
                dataRow["ADDRESS1RF"] = SectionInfCsvData.Address1.Trim();
                // 住所3（番地）
                dataRow["ADDRESS3RF"] = SectionInfCsvData.Address3.Trim();
                // 住所4（アパート名称）
                dataRow["ADDRESS4RF"] = SectionInfCsvData.Address4.Trim();
                // 自社電話番号1
                dataRow["COMPANYTELNO1RF"] = SectionInfCsvData.CompanyTelNo1.Trim();
                // 自社電話番号2
                dataRow["COMPANYTELNO2RF"] = SectionInfCsvData.CompanyTelNo2.Trim();
                // 自社電話番号3
                dataRow["COMPANYTELNO3RF"] = SectionInfCsvData.CompanyTelNo3.Trim();
                dataTable.Rows.Add(dataRow);
            }
            #endregion
            _dataSet.Tables.Add(dataTable);
        }
        /// <summary>
        /// 検索結果をConvertToDataSet
        /// </summary>
        /// <param name="companyInf">検索結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void ConverToDataSetCompanyInf(CompanyInf companyInf)
        {
            // データセット格納用データテーブル
            DataTable dataTable = new DataTable("CompanyExp");

            // カラム追加
            # region カラム追加(CSVデータ用)
            dataTable.Columns.Add("COMPANYNAME1RF", typeof(string));	    //  自社名称1
            dataTable.Columns.Add("COMPANYNAME2RF", typeof(string));	    //  自社名称2
            dataTable.Columns.Add("POSTNORF", typeof(string));	            //  郵便番号
            dataTable.Columns.Add("ADDRESS1RF", typeof(string));	        //  住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("ADDRESS3RF", typeof(string));	        //  住所3（番地）
            dataTable.Columns.Add("ADDRESS4RF", typeof(string));	        //  住所4（アパート名称）
            dataTable.Columns.Add("COMPANYTELNO1RF", typeof(string));	    //  自社電話番号1
            dataTable.Columns.Add("COMPANYTELNO2RF", typeof(string));	    //  自社電話番号2
            dataTable.Columns.Add("COMPANYTELNO3RF", typeof(string));	    //  自社電話番号3
            if (companyInf.LogicalDeleteCode == 0)
            {
                DataRow dataRow = dataTable.NewRow();
                // 自社名称1
                dataRow["COMPANYNAME1RF"] = companyInf.CompanyName1.Trim();
                // 自社名称2
                dataRow["COMPANYNAME2RF"] = companyInf.CompanyName2.Trim();
                // 郵便番号
                dataRow["POSTNORF"] = companyInf.PostNo.Trim();
                // 住所1（都道府県市区郡・町村・字）
                dataRow["ADDRESS1RF"] = companyInf.Address1.Trim();
                // 住所3（番地）
                dataRow["ADDRESS3RF"] = companyInf.Address3.Trim();
                // 住所4（アパート名称）
                dataRow["ADDRESS4RF"] = companyInf.Address4.Trim();
                // 自社電話番号1
                dataRow["COMPANYTELNO1RF"] = companyInf.CompanyTelNo1.Trim();
                // 自社電話番号2
                dataRow["COMPANYTELNO2RF"] = companyInf.CompanyTelNo2.Trim();
                // 自社電話番号3
                dataRow["COMPANYTELNO3RF"] = companyInf.CompanyTelNo3.Trim();

                dataTable.Rows.Add(dataRow);
            }

            #endregion
            _dataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="supplier">仕入先データ</param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(Supplier supplier, PostcardEnvelopeDMTextCndtn condition)
        {
            int status = 0;
            // 仕入先コード
            int stSupplierCd = condition.St_SupplierCode;
            int edSupplierCd = condition.Ed_SupplierCode;

            if (stSupplierCd != 0 && supplier.SupplierCd < stSupplierCd)
            {

                status = -1;
                return status;

            }
            if (edSupplierCd != 0 && supplier.SupplierCd > edSupplierCd)
            {
                status = -1;
                return status;

            }


            // 拠点コード
            if (!String.IsNullOrEmpty(supplier.MngSectionCode.Trim()))
            {
                int supplierSectionCd = System.Convert.ToInt32(supplier.MngSectionCode);
                if (!string.IsNullOrEmpty(condition.St_SectionCode) && supplierSectionCd < Int32.Parse(condition.St_SectionCode))
                {
                    status = -1;
                    return status;
                }
                if (!string.IsNullOrEmpty(condition.Ed_SectionCode) && supplierSectionCd > Int32.Parse(condition.Ed_SectionCode))
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
        #endregion

    }
}