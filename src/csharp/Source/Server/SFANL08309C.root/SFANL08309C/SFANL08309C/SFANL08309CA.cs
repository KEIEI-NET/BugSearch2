using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// where文生成部品クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票の帳票用リモートが使用します。where文を生成します。</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.10.18</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08309CA
    {
        #region public methods
        
        #region 抽出条件クエリ作成
        /// <summary>
        /// 抽出条件クエリ作成(抽出条件パラメータを照合して文を生成します)
        /// </summary>
        /// <param name="whereString">where文を追加するStringBuilder</param>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <param name="sqlCommand">抽出に使用するSqlCommandのインスタンス</param>
        public void SettingPara(ref StringBuilder whereString, FrePprECndWork frePprECnd, ref SqlCommand sqlCommand)
        {
            switch (frePprECnd.ExtraConditionDivCd)
            {
                case 1:
                case 5:
                    {//数値/コンボボックス
                        if (frePprECnd.ExtraConditionTypeCd == 0)
                        {//一致
                            if(frePprECnd.StExtraNumCode != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " = " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findPara.Value = frePprECnd.StExtraNumCode;
                            }
                        }
                        else
                        {//範囲
                            //開始
                            if (frePprECnd.StExtraNumCode != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " >= " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findSrtPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findSrtPara.Value = frePprECnd.StExtraNumCode;
                            }
                            //終了
                            if (frePprECnd.EdExtraNumCode != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " <= " + GetFindPrNmEndStr(frePprECnd));
                                SqlParameter findEndPara = sqlCommand.Parameters.Add(GetFindPrNmEndStr(frePprECnd), SqlDbType.Int);
                                findEndPara.Value = frePprECnd.EdExtraNumCode;
                            }
                        }
                        break;
                    }
                case 2:
                case 3:
                    {//文字
                        if (frePprECnd.ExtraConditionTypeCd == 0)
                        {//一致
                            if (!string.IsNullOrEmpty(frePprECnd.StExtraCharCode))
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " = " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.NChar);
                                findPara.Value = frePprECnd.StExtraCharCode;
                            }
                        }
                        else if (frePprECnd.ExtraConditionTypeCd == 1)
                        {//範囲
                            if (!string.IsNullOrEmpty(frePprECnd.StExtraCharCode))
                            {
                                //開始
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " >= " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findSrtPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.NChar);
                                findSrtPara.Value = frePprECnd.StExtraCharCode;
                            }
                            //終了
                            if ((!string.IsNullOrEmpty(frePprECnd.EdExtraCharCode)))
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " <= " + GetFindPrNmEndStr(frePprECnd));
                                SqlParameter findEndPara = sqlCommand.Parameters.Add(GetFindPrNmEndStr(frePprECnd), SqlDbType.NChar);
                                findEndPara.Value = frePprECnd.EdExtraCharCode;
                            }
                        }
                        else if (frePprECnd.ExtraConditionTypeCd == 2)
                        {//曖昧
                            if ((!string.IsNullOrEmpty(frePprECnd.StExtraCharCode)))
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " like " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.NChar);
                                findPara.Value = "%"+frePprECnd.StExtraCharCode+"%";
                            }
                        }
                        break;
                    }
                case 4:
                    {//日付
                        if (frePprECnd.ExtraConditionTypeCd == 0)
                        {//一致
                            if (frePprECnd.StartExtraDate != 0)
                            {
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " = " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findPara.Value = frePprECnd.StartExtraDate;
                            }
                        }
                        else
                        {//範囲/期間
                            if (frePprECnd.StartExtraDate != 0)
                            {
                                //開始
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " >= " + GetFindPrNmStr(frePprECnd));
                                SqlParameter findSrtPara = sqlCommand.Parameters.Add(GetFindPrNmStr(frePprECnd), SqlDbType.Int);
                                findSrtPara.Value = frePprECnd.StartExtraDate;
                            }
                            if (frePprECnd.EndExtraDate != 0)
                            {
                                //終了
                                whereString.Append(" AND ");
                                whereString.Append(GetFieldName(frePprECnd) + " <= " + GetFindPrNmEndStr(frePprECnd));
                                SqlParameter findEndPara = sqlCommand.Parameters.Add(GetFindPrNmEndStr(frePprECnd), SqlDbType.Int);
                                findEndPara.Value = frePprECnd.EndExtraDate;
                            }
                        }
                        break;
                    }
                case 6:
                    {//チェックボックス
                        StringBuilder values = new StringBuilder();
                        if (frePprECnd.CheckItemCode1 != -1) values.Append(frePprECnd.CheckItemCode1.ToString());
                        if (frePprECnd.CheckItemCode2 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode2.ToString());
                        }
                        if (frePprECnd.CheckItemCode3 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode3.ToString());
                        }
                        if (frePprECnd.CheckItemCode4 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode4.ToString());
                        }
                        if (frePprECnd.CheckItemCode5 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode5.ToString());
                        }
                        if (frePprECnd.CheckItemCode6 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode6.ToString());
                        }
                        if (frePprECnd.CheckItemCode7 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode7.ToString());
                        }
                        if (frePprECnd.CheckItemCode8 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode8.ToString());
                        }
                        if (frePprECnd.CheckItemCode9 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode9.ToString());
                        }
                        if (frePprECnd.CheckItemCode10 != -1)
                        {
                            if (values.Length != 0) values.Append(",");
                            values.Append(frePprECnd.CheckItemCode10.ToString());
                        }
                        if (values.Length != 0)
                        {
                            whereString.Append(" AND ");
                            whereString.Append(GetFieldName(frePprECnd) + " IN (" + values.ToString() + ")");
                        }
                        break;
                    }
            }
        }
        #endregion

        #endregion

        #region private methods

        #region Sqlクエリ用変数名称取得
        /// <summary>
        /// Sqlクエリ用変数名称を返します(汎用)
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <returns></returns>
        private string GetFindPrNmStr(FrePprECndWork frePprECnd)
        {
            return ("@FIND" + CreateFindPara(frePprECnd));
        }
        /// <summary>
        /// Sqlクエリ用変数名称を返します(終了条件用)
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <returns></returns>
        private string GetFindPrNmEndStr(FrePprECndWork frePprECnd)
        {
            return ("@FINDEND" + CreateFindPara(frePprECnd));
        }
        #endregion

        #region フィールド名称取得
        /// <summary>
        /// フィールド名称を返します
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <returns>抽出対象のフィールド名称</returns>
        private string GetFieldName(FrePprECndWork frePprECnd)
        {
            return CreateDataField(frePprECnd);
        }

        /// <summary>
        /// 自由帳票抽出条件クラスからDD名称を生成します
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <returns></returns>
        private string CreateDataField(FrePprECndWork frePprECnd)
        {
            if (frePprECnd == null) return string.Empty;
            
            if (!string.IsNullOrEmpty(frePprECnd.FileNm) && !string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.FileNm + "." + frePprECnd.DDName;
            else if (!string.IsNullOrEmpty(frePprECnd.FileNm))
                return frePprECnd.FileNm;
            else if (!string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.DDName;
            else return string.Empty;
        }
        /// <summary>
        /// 自由帳票抽出条件クラスからスカラ変数用文字列を作成します
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <returns></returns>
        private string CreateFindPara(FrePprECndWork frePprECnd)
        {
            if (frePprECnd == null) return string.Empty;

            if (!string.IsNullOrEmpty(frePprECnd.FileNm) && !string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.FileNm + "_" + frePprECnd.DDName;
            else if (!string.IsNullOrEmpty(frePprECnd.FileNm))
                return frePprECnd.FileNm;
            else if (!string.IsNullOrEmpty(frePprECnd.DDName))
                return frePprECnd.DDName;
            else return string.Empty;
        } 
        #endregion

        #endregion
    }
}
