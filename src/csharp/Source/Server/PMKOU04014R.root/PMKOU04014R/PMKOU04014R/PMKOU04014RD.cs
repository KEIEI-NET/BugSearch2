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
    class SuppPrtPprBlTblRsltQuery : ISuppPrtPpr
    {
        #region [SuppPrtPprBlTblRsltWork用 SELECT文]
        /// <summary>
        /// 残高一覧のリスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="SrchKndDiv">検索種別 0:支払 1:買掛</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高一覧のリスト抽出SELECT文</returns>
        /// <br>Note       : 残高一覧のリスト抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>Note       : READUNCOMMITTED対応</br>
        /// <br>Programmer : 20008 伊藤 豊</br>
        /// <br>Date       : 2012/06/26</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        {
            SuppPrtPprBlnceWork _suppPrtPprBlnceWork = paramWork as SuppPrtPprBlnceWork;
            return this.MakeSelectStringProc(ref sqlCommand, _suppPrtPprBlnceWork, SrchKndDiv, logicalMode);
        }
        #endregion  //[SuppPrtPprBlTblRsltWork用 SELECT文]

        #region [SuppPrtPprBlTblRsltWork用 SELECT文生成処理]
        /// <summary>
        /// 残高一覧のリスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="SrchKndDiv">検索種別 0:支払 1:買掛</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高一覧のリスト抽出SELECT文</returns>
        /// <br>Note       : 残高一覧のリスト抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SuppPrtPprBlnceWork paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // 対象テーブル
            // SUPLIERPAYRF  SURPAY  仕入先支払金額マスタ
            // SUPLACCPAYRF  SUAPAY  仕入先買掛金額マスタ

            #region [Select文作成]
            if (SrchKndDiv == (int)iSrchKndDiv.Suplier)
            {
                #region [支払 -> 仕入先支払金額マスタ]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SURPAY.ADDUPDATERF" + Environment.NewLine;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                selectTxt += " ,SURPAY.ADDUPYEARMONTHRF" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                //selectTxt += " ,SURPAY.LASTTIMEPAYMENTRF" + Environment.NewLine; // DEL 2010/07/20
                selectTxt += " ,(SURPAY.LASTTIMEPAYMENTRF + SURPAY.STOCKTTL2TMBFBLPAYRF + SURPAY.STOCKTTL3TMBFBLPAYRF)" + Environment.NewLine; // ADD 2010/07/20
                selectTxt += "   AS LASTTIMEBLC" + Environment.NewLine;
                selectTxt += " ,SURPAY.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += " ,SURPAY.THISTIMETTLBLCPAYRF" + Environment.NewLine;
                selectTxt += "   AS THISTIMETTLBLC" + Environment.NewLine;
                selectTxt += " ,SURPAY.THISTIMESTOCKPRICERF" + Environment.NewLine;
                selectTxt += " ,(SURPAY.THISSTCKPRICRGDSRF+SURPAY.THISSTCKPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS THISSTCKPRICRGDSDIS" + Environment.NewLine;
                selectTxt += " ,SURPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += " ,SURPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += " ,(SURPAY.OFSTHISTIMESTOCKRF+SURPAY.OFSTHISSTOCKTAXRF)" + Environment.NewLine;
                selectTxt += "   AS THISSTCKPRICTOTAL" + Environment.NewLine;
                selectTxt += " ,SURPAY.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                selectTxt += "   AS STCKTTLPAYBLC" + Environment.NewLine;
                selectTxt += " ,SURPAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                selectTxt += " ,SURPAY.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,SURPAY.PAYEECODERF" + Environment.NewLine;
                //selectTxt += " ,SURPAY.PAYEENAMERF" + Environment.NewLine; // DEL 2010/09/28 障害報告 #15619
                selectTxt += " ,SUPP.SUPPLIERSNMRF" + Environment.NewLine; // ADD 2010/09/28 障害報告 #15619
                // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
                // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
                //selectTxt += " FROM SUPLIERPAYRF AS SURPAY" + Environment.NewLine;
                selectTxt += " FROM SUPLIERPAYRF AS SURPAY WITH (READUNCOMMITTED)" + Environment.NewLine;
                // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
                // ---------------------- ADD 2010/09/28 障害報告 #15619--------------------------------->>>>>
                // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
                //selectTxt += " LEFT JOIN SUPPLIERRF AS SUPP ON" + Environment.NewLine;
                selectTxt += " LEFT JOIN SUPPLIERRF AS SUPP WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
                selectTxt += " SURPAY.ENTERPRISECODERF = SUPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SURPAY.PAYEECODERF = SUPP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += " AND SUPP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                // ---------------------- ADD 2010/09/28 障害報告 #15619---------------------------------<<<<<

                #endregion
            }
            else if (SrchKndDiv == (int)iSrchKndDiv.SuplAcc)
            {
                #region [買掛 -> 仕入先買掛金額マスタ]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUAPAY.ADDUPDATERF" + Environment.NewLine;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                selectTxt += " ,SUAPAY.ADDUPYEARMONTHRF" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                //selectTxt += " ,SUAPAY.LASTTIMEACCPAYRF" + Environment.NewLine; // DEL 2010/07/20
                selectTxt += " ,(SUAPAY.LASTTIMEACCPAYRF+SUAPAY.STCKTTL2TMBFBLACCPAYRF+SUAPAY.STCKTTL3TMBFBLACCPAYRF)" + Environment.NewLine; // ADD 2010/07/20
                selectTxt += "   AS LASTTIMEBLC" + Environment.NewLine;
                selectTxt += " ,SUAPAY.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += " ,SUAPAY.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "   AS THISTIMETTLBLC" + Environment.NewLine;
                selectTxt += " ,SUAPAY.THISTIMESTOCKPRICERF" + Environment.NewLine;
                selectTxt += " ,(SUAPAY.THISSTCKPRICRGDSRF+SUAPAY.THISSTCKPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS THISSTCKPRICRGDSDIS" + Environment.NewLine;
                selectTxt += " ,SUAPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += " ,SUAPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += " ,(SUAPAY.OFSTHISTIMESTOCKRF+SUAPAY.OFSTHISSTOCKTAXRF)" + Environment.NewLine;
                selectTxt += "   AS THISSTCKPRICTOTAL" + Environment.NewLine;
                selectTxt += " ,SUAPAY.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "   AS STCKTTLPAYBLC" + Environment.NewLine;
                selectTxt += " ,SUAPAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                selectTxt += " ,SUAPAY.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,SUAPAY.PAYEECODERF" + Environment.NewLine;
                //selectTxt += " ,SUAPAY.PAYEENAMERF" + Environment.NewLine; // DEL 2010/09/28 障害報告 #15619
                selectTxt += " ,SUPP.SUPPLIERSNMRF" + Environment.NewLine; // ADD 2010/09/28 障害報告 #15619
                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
                //selectTxt += " FROM SUPLACCPAYRF AS SUAPAY" + Environment.NewLine;
                selectTxt += " FROM SUPLACCPAYRF AS SUAPAY WITH (READUNCOMMITTED)" + Environment.NewLine;
                // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
                // ---------------------- ADD 2010/09/28 障害報告 #15619--------------------------------->>>>>
                // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
                //selectTxt += " LEFT JOIN SUPPLIERRF AS SUPP ON" + Environment.NewLine;
                selectTxt += " LEFT JOIN SUPPLIERRF AS SUPP WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
                selectTxt += " SUAPAY.ENTERPRISECODERF = SUPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUAPAY.PAYEECODERF = SUPP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += " AND SUAPAY.LOGICALDELETECODERF = 0" + Environment.NewLine;
                // ---------------------- ADD 2010/09/28 障害報告 #15619---------------------------------<<<<<
                #endregion
            }
            else
            {
                throw new Exception("検索実行時エラー(内部パラメータ不正)");
            }

            //WHERE句
            // --- DEL 2012/09/13 ---------->>>>>
            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, SrchKndDiv, logicalMode);
            // --- DEL 2012/09/13 ----------<<<<<
            // --- ADD 2012/09/13 ---------->>>>>
            if (paramWork.OptSupplierSummary)
            {
                // 仕入総括オプションが有効の場合
                selectTxt += MakeWhereStringSuppSum(ref sqlCommand, paramWork, SrchKndDiv, logicalMode);
            }
            else
            {
                // 仕入総括オプションが無効の場合
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, SrchKndDiv, logicalMode);
            }
            // --- ADD 2012/09/13 ----------<<<<<

            #endregion

            return selectTxt;
        }
        #endregion  //[SuppPrtPprBlTblRsltWork用 SELECT文生成処理]

        #region [SuppPrtPprBlTblRsltWork用 WHERE文生成処理]
        /// <summary>
        /// 残高一覧のリスト抽出用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="SrchKndDiv">検索種別 0:支払 1:買掛</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高一覧のリスト抽出用WHERE句</returns>
        /// <br>Note       : 残高一覧示のリスト抽出用WHERE文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応（６次改良追加依頼分）</br>
        /// <br>UpdateNote : 2010/09/21 曹文傑</br>
        /// <br>           　redmine#14876対応</br>
        /// <br>UpdateNote : 2012/09/13 FSI上北田 秀樹</br>
        /// <br>           　仕入先総括対応の追加</br> 
        private string MakeWhereString(ref SqlCommand sqlCommand, SuppPrtPprBlnceWork paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE " + Environment.NewLine;

            //テーブル略称
            string sTblNm = null;
            if (SrchKndDiv == (int)iSrchKndDiv.Suplier)
                sTblNm = "SURPAY.";  //支払 -> 仕入先支払金額マスタ
            else if (SrchKndDiv == (int)iSrchKndDiv.SuplAcc)
                sTblNm = "SUAPAY.";  //買掛 -> 仕入先買掛金額マスタ
            else
                throw new Exception("検索実行時エラー(内部パラメータ不正)");

            //企業コード
            retstring += sTblNm + "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += "AND " + sTblNm + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += "AND " + sTblNm + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
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
                    retstring += "AND " + sTblNm + "ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    // ------ ADD 2010/09/21 ----------------->>>>>
                    // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
                    //retstring += "AND " + sTblNm + "ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)";
                    retstring += "AND " + sTblNm + "ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)";
                    // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
                    // ------ ADD 2010/09/21 -----------------<<<<<
                }
                retstring += Environment.NewLine;
            }
            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            if (paramWork.SearchDiv == 1)
            {

                // 親レコード検索
                retstring += "AND " + sTblNm + "SUPPLIERCDRF=@FINDSUPPLIERCODE" + Environment.NewLine;
                SqlParameter paraSupplierCode = sqlCommand.Parameters.Add("@FINDSUPPLIERCODE", SqlDbType.Int);
                paraSupplierCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);

                //開始仕入先コード
                if (paramWork.St_SupplierCd != 0)
                {
                    retstring += "AND " + sTblNm + "PAYEECODERF>=@FINDSTPAYEECODE" + Environment.NewLine;
                    SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@FINDSTPAYEECODE", SqlDbType.Int);
                    paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.St_SupplierCd);
                }
                //終了仕入先コード
                if (paramWork.Ed_SupplierCd != 0)
                {
                    retstring += "AND " + sTblNm + "PAYEECODERF<=@FINDEDPAYEECODE" + Environment.NewLine;
                    SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@FINDEDPAYEECODE", SqlDbType.Int);
                    paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_SupplierCd);
                }

                // ------ ADD 2010/09/21 ----------------->>>>>
                // 2012/06/26 Y.Ito MOD START READUNCOMMITTED対応
                //retstring += "AND " + sTblNm + "PAYEECODERF IN (SELECT SUPPLIERCDRF FROM SUPPLIERRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)";
                retstring += "AND " + sTblNm + "PAYEECODERF IN (SELECT SUPPLIERCDRF FROM SUPPLIERRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)";
                // 2012/06/26 Y.Ito MOD END READUNCOMMITTED対応
                // ------ ADD 2010/09/21 -----------------<<<<<

            }
            else
            {
            // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
                //仕入先コード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //if (paramWork.SupplierCd != 0)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                {
                    retstring += "AND " + sTblNm + "SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
                }

                //支払先コード
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                //if (paramWork.PayeeCode != 0)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                {
                    retstring += "AND " + sTblNm + "PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
                }
            } // ADD 2010/07/20
            
            //計上年月
            if (paramWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += "AND " + sTblNm + "ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.St_AddUpYearMonth);
            }
            if (paramWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += "AND " + sTblNm + "ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.Ed_AddUpYearMonth);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprBlTblRsltWork用 WHERE文生成処理]

        #region [SuppPrtPprBlTblRsltWork用 WHERE文生成処理(仕入総括用)]
        /// <summary>
        /// 残高一覧のリスト抽出用WHERE句 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="SrchKndDiv">検索種別 0:支払 1:買掛</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>残高一覧のリスト抽出用WHERE句</returns>
        /// <br>Note       : 残高一覧示のリスト抽出用WHERE文を作成して戻します。仕入先総括対応の追加</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2012/09/13</br>
        /// <br>           　</br> 
        private string MakeWhereStringSuppSum(ref SqlCommand sqlCommand, SuppPrtPprBlnceWork paramWork, int SrchKndDiv, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE " + Environment.NewLine;

            //テーブル略称
            string sTblNm = null;
            if (SrchKndDiv == (int)iSrchKndDiv.Suplier)
                sTblNm = "SURPAY.";  //支払 -> 仕入先支払金額マスタ
            else if (SrchKndDiv == (int)iSrchKndDiv.SuplAcc)
                sTblNm = "SUAPAY.";  //買掛 -> 仕入先買掛金額マスタ
            else
                throw new Exception("検索実行時エラー(内部パラメータ不正)");

            //企業コード
            retstring += sTblNm + "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += "AND " + sTblNm + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += "AND " + sTblNm + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
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
                    retstring += "AND " + sTblNm + "ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            if (paramWork.SearchDiv == 1)
            {
                //開始仕入先コード
                if (paramWork.St_SupplierCd != 0)
                {
                    retstring += "AND " + sTblNm + "PAYEECODERF>=@FINDSTPAYEECODE" + Environment.NewLine;
                    SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@FINDSTPAYEECODE", SqlDbType.Int);
                    paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.St_SupplierCd);
                }
                //終了仕入先コード
                if (paramWork.Ed_SupplierCd != 0)
                {
                    retstring += "AND " + sTblNm + "PAYEECODERF<=@FINDEDPAYEECODE" + Environment.NewLine;
                    SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@FINDEDPAYEECODE", SqlDbType.Int);
                    paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.Ed_SupplierCd);
                }

                //集計レコード
                retstring += "AND " + sTblNm + "SUPPLIERCDRF=0" + Environment.NewLine;
            }
            else
            {
                //仕入先コード
                {
                    retstring += "AND " + sTblNm + "SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
                }

                //支払先コード
                {
                    retstring += "AND " + sTblNm + "PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
                }
            }

            //計上年月
            if (paramWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += "AND " + sTblNm + "ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.St_AddUpYearMonth);
            }
            if (paramWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += "AND " + sTblNm + "ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.Ed_AddUpYearMonth);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprBlTblRsltWork用 WHERE文生成処理(仕入総括用)]

        #region [SuppPrtPprBlTblRsltWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprBlTblRsltWork
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
            SuppPrtPprBlnceWork _suppPrtPprBlnceWork = paramWork as SuppPrtPprBlnceWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader, _suppPrtPprBlnceWork);
        }
        #endregion  //[SuppPrtPprBlTblRsltWork処理 呼出]

        #region [SuppPrtPprBlTblRsltWork処理]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprBlTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        private SuppPrtPprBlTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SuppPrtPprBlnceWork paramWork)
        {
            #region 抽出結果-値セット
            SuppPrtPprBlTblRsltWork resultWork = new SuppPrtPprBlTblRsltWork();

            resultWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            resultWork.LastTimeBlc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEBLC"));
            resultWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            resultWork.ThisTimeTtlBlc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLC"));
            resultWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            resultWork.ThisStckPricRgdsDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSDIS"));
            resultWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            resultWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            resultWork.ThisStckPricTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICTOTAL"));
            resultWork.StckTtlPayBlc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLPAYBLC"));
            resultWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            resultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "ADDUPYEARMONTHRF" ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
            // ---------------------- ADD 2010/07/20--------------------------------->>>>>
            resultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            //resultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF")); // DEL 2010/09/28 障害報告 #15619
            resultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF")); // ADD 2010/09/28 障害報告 #15619
            // ---------------------- ADD 2010/07/20---------------------------------<<<<<

            #endregion

            return resultWork;
        }
        #endregion  //[SuppPrtPprBlTblRsltWork処理]
    }
}
