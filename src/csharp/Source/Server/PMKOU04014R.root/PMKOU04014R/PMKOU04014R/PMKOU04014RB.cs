using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    class SuppPrtPprBlDspRsltQuery : ISuppPrtPpr
    {
        #region [SuppPrtPprBlDspRsltWork用 SELECT文]
        /// <summary>
        /// 残高照会のリスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="iParam"></param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高照会のリスト抽出SELECT文</returns>
        /// <br>Note       : 残高照会のリスト抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, ConstantManagement.LogicalMode logicalMode)
        {
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;
            return this.MakeSelectStringProc(ref sqlCommand, _suppPrtPprWork, logicalMode);
        }
        #endregion  //[SuppPrtPprBlDspRsltWork用 SELECT文]

        #region [SuppPrtPprBlDspRsltWork用 SELECT文生成処理]
        /// <summary>
        /// 残高照会のリスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高照会のリスト抽出SELECT文</returns>
        /// <br>Note       : 残高照会のリスト抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>Note       : READUNCOMMITTED対応</br>
        /// <br>Programmer : 20008 伊藤 豊</br>
        /// <br>Date       : 2012.06.26</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // 対象テーブル
            // SUPLIERPAYRF  SUPAY  仕入先支払金額マスタ
            // SUPPLIERRF    SUPLR  仕入先マスタ

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  SUPAY.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
            selectTxt += " ,SUPAY.LASTTIMEPAYMENTRF" + Environment.NewLine;
            selectTxt += " ,SUPAY.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
            selectTxt += " ,SUPAY.ADDUPYEARMONTHRF" + Environment.NewLine;
            selectTxt += " ,SUPLR.SUPPCTAXATIONCDRF" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
            //selectTxt += " FROM SUPLIERPAYRF AS SUPAY" + Environment.NewLine;
            selectTxt += " FROM SUPLIERPAYRF AS SUPAY WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応

            //JOIN
            //仕入先マスタ
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
            //selectTxt += " LEFT JOIN SUPPLIERRF SUPLR" + Environment.NewLine;
            selectTxt += " LEFT JOIN SUPPLIERRF SUPLR WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
            selectTxt += " ON  SUPLR.ENTERPRISECODERF=SUPAY.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SUPLR.SUPPLIERCDRF=SUPAY.SUPPLIERCDRF" + Environment.NewLine;

            //WHERE句
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, logicalMode);
            #endregion

            return selectTxt;
        }
        #endregion  //[SuppPrtPprBlDspRsltWork用 SELECT文生成処理]

        #region [SuppPrtPprBlDspRsltWork用 WHERE文生成処理]
        /// <summary>
        /// 残高照会のリスト抽出用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高照会のリスト抽出用WHERE句</returns>
        /// <br>Note       : 残高照会のリスト抽出用WHERE文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " SUPAY.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SUPAY.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SUPAY.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード
            if (paramWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND SUPAY.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //仕入先コード
            if ( paramWork.SupplierCd != 0 )
            {
                retstring += " AND SUPAY.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //支払先コード
            if ( paramWork.PayeeCode != 0 )
            {
                retstring += " AND SUPAY.PAYEECDERF=@FINDPAYEECDE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECDE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
            }

            //計上年月
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                retstring += " AND SUPAY.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.St_StockDate);
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                retstring += " AND SUPAY.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.Ed_StockDate);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprBlDspRsltWork用 WHERE文生成処理]

        #region [SuppPrtPprBlDspRsltWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprBlDspRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <param name="iParam"></param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam)
        {
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader, _suppPrtPprWork);
        }
        #endregion  //[SuppPrtPprBlDspRsltWork処理 呼出]

        #region [SuppPrtPprBlDspRsltWork処理]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprBlDspRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        private SuppPrtPprBlDspRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SuppPrtPprWork paramWork)
        {
            #region 抽出結果-値セット
            SuppPrtPprBlDspRsltWork resultWork = new SuppPrtPprBlDspRsltWork();

            resultWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            resultWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            resultWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
            resultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            resultWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXATIONCDRF"));
            #endregion

            return resultWork;
        }
        #endregion  //[SuppPrtPprBlDspRsltWork処理]
    }
}
