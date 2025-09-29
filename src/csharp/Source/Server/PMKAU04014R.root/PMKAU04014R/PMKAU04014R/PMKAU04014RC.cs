/// <br>Update Note: 2011/08/18 連番729 許雁波 10704766-00 </br>
/// <br>             明細貼付ファンクションボタンを追加</br>
/// <br>Update Note: 2012/04/01 Redmine#29250 </br>
/// <br>             得意先電子元帳　データ更新日時の追加について(明細更新日時の追加)</br>
/// <br>Update Note: 2013/03/18 zhaimm </br>
/// <br>管理番号   : 10800003-00 2013/05/15配信分</br>
/// <br>           : Redmine#34807 №703 得意先電子元帳</br>
/// <br>           : 検索時：仮伝番号に0詰めデータと0詰めなしデータも抽出対象とする</br>
/// <br>Update Note: 2014/12/28 陳永康</br>
/// <br>管理番号   : 11070263-00</br>
/// <br>           : 変換後品番の追加対応</br>
/// <br>Update Note: 2015/02/05 王亜楠</br>
/// <br>           : テキスト出力件数制限なしモードの追加</br>
/// <br>UpdateNote : 2015/03/03 王亜楠 Redmine#44701</br>
/// <br>           : 画面の売上日が指定されない場合、入金データから開始・終了入金日を検索する</br>
/// <br>Update Note: K2015/06/16 鮑晶</br>
/// <br>管理番号   : 11101427-00</br>
/// <br>           : メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する。 メイゴ㈱オプションが有効の場合のみ</br>
/// <br>UpdateNote : 2016/01/21 脇田 靖之</br>
/// <br>管理番号   : 11270007-00 仕掛一覧№2808 貸出受注対応</br>
/// <br>           : ①検索条件に「出荷状況」項目を追加</br>
/// <br>           : ②明細表示に計上数、未計上数項目を追加</br>
/// <br>Update Note: K2016/02/23 時シン</br>
/// <br>管理番号   : 11200090-00 イケモ 得意先電子元帳</br>
/// <br>             ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
/// <br>Update Note: 2020/03/11 時シン</br>
/// <br>管理番号   : 11570208-00</br>
/// <br>           : PMKOBETSU-2912 軽減税率対応</br>
/// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
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
// -- DEL 2009/09/04 ------------------------------------->>>
//using System.Collections.Generic; //  m.suzuki 2009.08.24 ADD 
// -- DEL 2009/09/04 -------------------------------------<<<

namespace Broadleaf.Application.Remoting
{
    class CustPrtPprSalTblRsltQuery : ICustPrtPpr
    {
        #region [DEL 2009/09/04]
        // -- DEL 2009/09/04 ------------------------------------->>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        ///// <summary>伝票情報退避ディクショナリ</summary>
        //private Dictionary<string, string> _salesSlipHisKeyDic;
        ///// <summary>
        ///// 伝票情報退避ディクショナリ
        ///// </summary>
        //public Dictionary<string, string> SalesSlipHisKeyDic
        //{
        //    get { return _salesSlipHisKeyDic; }
        //    set { _salesSlipHisKeyDic = value; }
        //}

        ///// <summary>
        ///// コンストラクタ
        ///// </summary>
        //public CustPrtPprSalTblRsltQuery()
        //{
        //    _salesSlipHisKeyDic = new Dictionary<string, string>();
        //}
        ///// <summary>
        ///// キー文字列生成
        ///// </summary>
        ///// <param name="acptAnOdrStatus"></param>
        ///// <param name="salesSlipNum"></param>
        ///// <param name="salesRowNo"></param>
        ///// <param name="salesDate"></param>
        ///// <returns></returns>
        //private string CreateKeyString( int acptAnOdrStatus, string salesSlipNum, int salesRowNo, DateTime salesDate )
        //{
        //    return string.Format( "{0:D2}-{1}-{2:D3}-{3:yyyyMMdd}", acptAnOdrStatus, salesSlipNum.Trim(), salesRowNo, salesDate );
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ---------------------------------------<<<
        #endregion[DEL 2009/09/04]

        #region [CustPrtPprSalTblRsltWork用 SELECT文]
        /// <summary>
        /// 伝票表示・明細表示のリスト抽出クエリ作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="iType">検索タイプ 0:売上データ 1:入金データ</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>伝票表示・明細表示のリスト抽出SELECT文</returns>
        /// <remarks>
        /// <br>Note       : 伝票表示・明細表示のリスト抽出用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>貸出伝票抽出不具合の修正</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.12.24</br>
        /// <br></br>
        /// <br>UpdateNote : 2009.02.19 22018 鈴木正臣</br>
        /// <br>             ①赤伝発行可能チェックに使用している受注残数の取得方法について修正。</br>
        /// <br>               売上履歴明細データを使用するのは無理が出てきたので、売上明細を常に使用するよう変更。</br>
        /// <br></br>
        /// <br>UpdateNote : 2009.08.24 22018 鈴木正臣</br>
        /// <br>             過去分表示対応（売上データ抽出後に、売上履歴データ抽出分を追加）</br>
        /// <br></br>
        /// <br>UpdateNote : 2009.09.04 22008 長内 数馬</br>
        /// <br>             過去分表示速度アップ対応</br>
        /// <br>UpdateNote : 2009/09/07 張莉莉</br>
        /// <br>             車輌備考と車両走行距離の追加</br>
        /// <br>Update Note: 2015/02/05 王亜楠</br>
        /// <br>           : テキスト出力件数制限なしモードの追加</br>
        /// <br></br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iType, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";
            CustPrtPprWork _custPrtPprWork = paramWork as CustPrtPprWork;

            switch (iType)
            {
                case (int)iSrcType.SalTbl:  //売上データ
                    selectTxt = MakeTypeSalSlpQuery(ref sqlCommand, _custPrtPprWork, logicalMode);
                    break;
                // -- DEL 2009/09/04 ------------------------------>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                //case (int)iSrcType.SalHisTbl:  //売上履歴データ
                //    selectTxt = MakeTypeSalSlpHisQuery( ref sqlCommand, _custPrtPprWork, logicalMode );
                //    break;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // -- DEL 2009/09/04 ------------------------------<<<
                case (int)iSrcType.DepTbl:  //入金データ
                    selectTxt = MakeTypeDepSitQuery(ref sqlCommand, _custPrtPprWork, logicalMode);
                    break;
                //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
                case (int)iSrcType.SalDate:  // テキスト出力用売上日の検索
                    selectTxt = MakeTypeSalDate4Text(ref sqlCommand, _custPrtPprWork, logicalMode);
                    break;
                //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
                default:
                    break;
            }

            return selectTxt;
        }
        #endregion  //[CustPrtPprSalTblRsltWork用 SELECT文]

        #region [テキスト出力用売上日の検索 SELECT文生成処理]
        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>
        /// 売上日が指定されない場合、DBから開始・終了売上日を検索する
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 売上日が指定されない場合、DBから開始・終了売上日を検索する</br>
        /// <br>Programmer  : 王亜楠</br>
        /// <br>Date        : 2015/02/05</br>
        /// <br>UpdateNote  : 2015/03/03 王亜楠 Redmine#44701</br>
        /// <br>            : 画面の売上日が指定されない場合、入金データから開始・終了入金日を検索する</br>
        /// </remarks>
        private string MakeTypeSalDate4Text(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder selectTxt = new StringBuilder();

            //----- ADD 2015/03/03 王亜楠 Redmine#44701 ---------->>>>>
            if (paramWork.SearchSalDateType == 0) // 売上データから日付を検索
            {
            //----- ADD 2015/03/03 王亜楠 Redmine#44701 ----------<<<<<
                selectTxt.Append("SELECT TOP 1 ").Append(Environment.NewLine);
                selectTxt.Append(" CASE WHEN (SALSLP.ACPTANODRSTATUSRF=30) THEN SALSLP.SALESDATERF ELSE SALSLP.SHIPMENTDAYRF END SALESDATE ").Append(Environment.NewLine);
                selectTxt.Append(" ,SALSLP.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                selectTxt.Append(" ,SALSLP.SECTIONCODERF ").Append(Environment.NewLine);
                selectTxt.Append("FROM ( ").Append(Environment.NewLine);

                bool salSlipFlg = false;  //売上が含まれるか
                bool acpSlipFlg = false;  //貸出 or 受注が含まれるか
                //受注、貸出の指定が存在するかをチェック
                foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
                {
                    if (iacptSt == 30)
                    {
                        salSlipFlg = true;
                    }
                    if (iacptSt != 30)
                    {
                        acpSlipFlg = true;
                    }
                }

                if (salSlipFlg)
                {
                    // １・売上が含まれるか
                    selectTxt.Append(" SELECT ").Append(Environment.NewLine);
                    selectTxt.Append("  SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.SALESDATERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.SHIPMENTDAYRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.COMMONSEQNORF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.SALESCODERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1 ").Append(Environment.NewLine);
                    selectTxt.Append(" FROM SALESHISTORYRF AS SALSLPSUB WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append(" LEFT JOIN SALESHISTDTLRF SALDTL WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append(" ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append(" LEFT JOIN SALESHISTDTLRF SALDTL2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append(" ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);

                    sqlCommand.Parameters.Clear();
                    selectTxt.Append(MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 0));
                }

                if ((salSlipFlg) && (acpSlipFlg))
                {
                    selectTxt.Append("UNION ALL ").Append(Environment.NewLine);
                }

                if (acpSlipFlg)
                {
                    // ２・貸出 or 受注が含まれるか
                    selectTxt.Append("SELECT ").Append(Environment.NewLine);
                    selectTxt.Append(" SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.SALESDATERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.SHIPMENTDAYRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.COMMONSEQNORF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.SALESCODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1 ").Append(Environment.NewLine);
                    selectTxt.Append("FROM SALESSLIPRF AS SALSLPSUB WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append("LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append("ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append("LEFT JOIN SALESDETAILRF SALDTL2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append("ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);

                    sqlCommand.Parameters.Clear();
                    selectTxt.Append(MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 1));
                }

                selectTxt.Append(") AS SALSLP ").Append(Environment.NewLine);

                // 受注マスタ(車両)
                selectTxt.Append("LEFT JOIN ACCEPTODRCARRF AODCAR WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  AODCAR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND AODCAR.ACCEPTANORDERNORF=SALSLP.ACCEPTANORDERNORF_1 ").Append(Environment.NewLine);
                selectTxt.Append("AND ( ").Append(Environment.NewLine);
                selectTxt.Append(" (SALSLP.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1)  --　見積 ").Append(Environment.NewLine);
                selectTxt.Append(" OR (SALSLP.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3) -- 受注 ").Append(Environment.NewLine);
                selectTxt.Append(" OR (SALSLP.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7) -- 売上 ").Append(Environment.NewLine);
                selectTxt.Append(" OR (SALSLP.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5) -- 出荷 ").Append(Environment.NewLine);
                selectTxt.Append(") ").Append(Environment.NewLine);
                // UOE発注データ
                selectTxt.Append("LEFT JOIN UOEORDERDTLRF UOEODR WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  UOEODR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND UOEODR.COMMONSEQNORF=SALSLP.COMMONSEQNORF ").Append(Environment.NewLine);
                selectTxt.Append("AND UOEODR.UOEKINDRF=0 ").Append(Environment.NewLine);
                // 拠点情報設定マスタ
                selectTxt.Append("LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF ").Append(Environment.NewLine);
                // 仕入明細データ
                selectTxt.Append("LEFT JOIN STOCKSLHISTDTLRF STCDTL WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  STCDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCDTL.SUPPLIERFORMALRF=SALSLP.SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCDTL.STOCKSLIPDTLNUMRF=SALSLP.STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                // 仕入データ
                selectTxt.Append("LEFT JOIN STOCKSLIPHISTRF STCSLP WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
                // ユーザーガイドマスタ(ボディ)
                selectTxt.Append("LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  USRGBU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND USRGBU.USERGUIDEDIVCDRF=71 ").Append(Environment.NewLine);
                selectTxt.Append("AND USRGBU.GUIDECODERF=SALSLP.SALESCODERF ").Append(Environment.NewLine);

                //WHERE句
                selectTxt.Append(MakeWhereString_SALTBL(ref sqlCommand, paramWork, logicalMode));

                selectTxt.Append("ORDER BY CASE WHEN (SALSLP.ACPTANODRSTATUSRF=30) THEN SALSLP.SALESDATERF ELSE SALSLP.SHIPMENTDAYRF END ").Append(Environment.NewLine);
                if (paramWork.SearchSalDateStEd == 0)
                {
                    selectTxt.Append("ASC ").Append(Environment.NewLine);
                }
                else
                {
                    selectTxt.Append("DESC ").Append(Environment.NewLine);
                }
            //----- ADD 2015/03/03 王亜楠 Redmine#44701 ---------->>>>>
            }
            else // 入金データから日付を検索
            {
                selectTxt.Append("SELECT TOP 1 ").Append(Environment.NewLine);
                selectTxt.Append(" DEPSM.DEPOSITDATERF AS SALESDATE ").Append(Environment.NewLine);
                selectTxt.Append("FROM ( ").Append(Environment.NewLine);
                selectTxt.Append(" SELECT ").Append(Environment.NewLine);
                selectTxt.Append("  DEPSMSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.DEPOSITDATERF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.DEPOSITSLIPNORF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.ADDUPSECCODERF ").Append(Environment.NewLine);
                selectTxt.Append(" FROM DEPSITMAINRF AS DEPSMSUB WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                // WHERE
                selectTxt.Append(MakeWhereString_DEPSMSUB(ref sqlCommand, paramWork, logicalMode));

                selectTxt.Append(") AS DEPSM ").Append(Environment.NewLine);
                selectTxt.Append("LEFT JOIN DEPSITDTLRF DEPSD WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  DEPSD.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND DEPSD.ACPTANODRSTATUSRF=DEPSM.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                selectTxt.Append("AND DEPSD.DEPOSITSLIPNORF=DEPSM.DEPOSITSLIPNORF ").Append(Environment.NewLine);
                selectTxt.Append("LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  SCINFS.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND SCINFS.SECTIONCODERF=DEPSM.ADDUPSECCODERF ").Append(Environment.NewLine);
                if (paramWork.SearchSalDateStEd == 0)
                {
                    selectTxt.Append("ORDER BY DEPSM.DEPOSITDATERF ASC ").Append(Environment.NewLine);
                }
                else
                {
                    selectTxt.Append("ORDER BY DEPSM.DEPOSITDATERF DESC ").Append(Environment.NewLine);
                }
            }
            //----- ADD 2015/03/03 王亜楠 Redmine#44701 ----------<<<<<

            return selectTxt.ToString();
        }
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
        #endregion

        #region [売上データ用 SELECT文生成処理]
        /// <summary>
        /// 仕入データ用SELECT文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>仕入データ用SELECT文</returns>
        /// <br>Note       : 仕入データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        /// <br>UpdateNote : 2009/09/04 22008 長内 数馬</br>
        /// <br>             過去分表示速度アップ対応</br>
        /// <br></br>
        /// <br>UpdateNote : 2009/10/05 22008 長内 数馬</br>
        /// <br>             表示速度アップ対応</br>
        /// <br></br>
        /// <br>UpdateNote : 2009/12/28 呉元嘯</br>
        /// <br>             PM.NS保守依頼④</br>
        /// <br>             品番の抽出条件で、ハイフン無しで入力された場合にハイフン付も対象とするように修正</br>
        /// <br></br>
        /// <br>UpdateNote : 2010/01/12 呉元嘯</br>
        /// <br>             PM.NS保守依頼④</br>
        /// <br>             年のみ入力した年式の伝票を売上伝票入力で正常に見出貼付できるように変更する</br>
        /// <br></br>
        /// <br>UpdateNote : 2010/01/29 楊明俊</br>
        /// <br>             4次改良</br>
        /// <br>             赤伝発行時に、返品数の上限を制限が可能となるように、返品不可設定機能の追加を行う</br>
        /// <br></br>
        /// <br>UpdateNote : 2010/03/11 22018 鈴木 正臣</br>
        /// <br>             過去分(売上履歴明細があって売上明細が無いとき)の場合、ハイフン無品番検索にヒットしない件の修正</br>
        /// <br>UpdateNote : 2010/04/27 gaoyh</br>
        /// <br>             受注マスタ（車両）に自由検索型式固定番号配列の追加</br>  
        /// <br></br>
        /// <br>Update Note: 速度チューニング</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/05/10</br>
        /// <br></br>
        /// <br>Update Note: UOE発注データの結合条件不具合対応</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/06/07</br>
        /// <br></br>
        /// <br>Update Note: READUNCOMMITTED対応</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/06/09</br>
        /// <br></br>
        /// <br>Update Note: 障害・改良対応8月リリース分の対応</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/05</br>
        /// <br>Update Note: 計上元受注№・計上元貸出№の表示内容修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2010/12/20</br>
        /// <br>Update Note: 得意先電子元帳/(BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ)問合せ番号の追加</br>
        /// <br>Programmer : 楊洋</br>
        /// <br>Date       : 2011/11/28</br>
        /// <br>Update Note: 2014/12/28 陳永康</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 変換後品番の追加対応</br>
        /// <br>Update Note: 2015/02/05 王亜楠</br>
        /// <br>           : テキスト出力件数制限なしモードの追加</br>
        /// <br>Update Note: K2015/06/16 鮑晶</br>
        /// <br>管理番号   : 11101427-00</br>
        /// <br>           : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        private string MakeTypeSalSlpQuery(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // 対象テーブル
            // SALESSLIPRF     SALSLP   売上データ
            // SALESDETAILRF   SALDTL   売上明細データ①
            // SALESDETAILRF   SALDTL2  売上明細データ②
            // ACCEPTODRCARRF  AODCAR   受注マスタ(車両)
            // UOEORDERDTLRF   UOEODR   UOE発注データ
            // SECINFOSETRF    SCINFS   拠点情報設定マスタ
            // STOCKDETAILRF   STCDTL   仕入明細データ
            // STOCKSLIPRF     STCSLP   仕入データ
            // BLGROUPURF    　BLGRPU   BLグループマスタ
            // USERGDBDURF     USRGBU   ユーザーガイドマスタ(ボディ)

            #region [Select文作成]
            // -- DEL 2009/10/05 ------------------------------->>>
            //速度アップのため削除
            //selectTxt += "SELECT" + Environment.NewLine;
            //selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            //selectTxt += "   OVER(ORDER BY SALTBL.SALESSLIPNUMRF)" + Environment.NewLine;
            //selectTxt += "   AS ROWNUM" + Environment.NewLine;
            //selectTxt += " ,*" + Environment.NewLine;
            //selectTxt += " FROM (" + Environment.NewLine;
            // -- DEL 2009/10/05 -------------------------------<<<

            #region [データ抽出メインQuery]

            #region [DEL 2009/09/04]
            // -- DEL 2009/09/04 ------------------------------------->>>
            ////検索上限件数を超えるまで取得
            //selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            //selectTxt += "    SALSLP.SALESDATERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESROWNORF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESTOTALTAXEXCRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESTOTALTAXINCRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSNORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CONSTAXLAYMETHODRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.TOTALCOSTRF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.CATEGORYNORF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.MODELFULLNAMERF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.FIRSTENTRYDATERF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.SEARCHFRAMENORF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.FULLMODELRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SLIPNOTERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SLIPNOTE2RF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SLIPNOTE3RF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.FRONTEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESINPUTNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.CARMNGCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
            //selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
            //selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            //selectTxt += "   ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD" + Environment.NewLine;
            //selectTxt += "   ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.UOEREMARK1RF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.UOEREMARK2RF" + Environment.NewLine;
            //selectTxt += "   ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            //selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.DTLNOTERF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.COLORNAME1RF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.TRIMNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.MAKERNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.COSTRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTSLIPNORF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ADDUPADATERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ACCRECDIVCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SECTIONCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            ////if (paramWork.AcptAnOdrStatus[0] != 30)
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            //selectTxt += "   ,SALDTL.ACPTANODRREMAINCNTRF" + Environment.NewLine; // ADD 2009.01.30
            //// ADD 2008.12.09 >>>
            //selectTxt += "   ,SALSLP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
            //selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF" + Environment.NewLine;
            //// ADD 2008.12.09 <<<
            //selectTxt += "   ,SALSLP.SHIPMENTDAYRF" + Environment.NewLine;
            
            //// ADD 2009.01.06 >>>
            //selectTxt += "   ,SALSLP.ADDRESSEECODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ADDRESSEENAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ADDRESSEENAME2RF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.FRAMENORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
            //// ADD 2009.01.06 <<<
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            //selectTxt += "   ,SALSLP.SEARCHSLIPDATERF" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            //selectTxt += "   ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            //selectTxt += "   ,SALSLP.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
            //selectTxt += "   ,AODCAR.CARMNGNORF" + Environment.NewLine; // 車両管理SEQ
            //selectTxt += "   ,AODCAR.MAKERCODERF" + Environment.NewLine; // 車種メーカーコード
            //selectTxt += "   ,AODCAR.MODELCODERF" + Environment.NewLine; // 車種コード
            //selectTxt += "   ,AODCAR.MODELSUBCODERF" + Environment.NewLine; // 車種サブコード
            //selectTxt += "   ,AODCAR.ENGINEMODELNMRF" + Environment.NewLine; // エンジン型式名称
            //selectTxt += "   ,AODCAR.COLORCODERF" + Environment.NewLine; // カラーコード
            //selectTxt += "   ,AODCAR.TRIMCODERF" + Environment.NewLine; // トリムコード
            //selectTxt += "   ,AODCAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine; // フル型式固定番号配列
            //selectTxt += "   ,AODCAR.CATEGORYOBJARYRF" + Environment.NewLine; // 装備オブジェクト配列
            //selectTxt += "   ,SALSLP.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
            //selectTxt += "   ,SALSLP.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

            //selectTxt += "  FROM (" + Environment.NewLine;

            //#region [売上データ抽出Query]
            //selectTxt += "   SELECT" + Environment.NewLine;
            //selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
            //// 修正 2009.01.16 >>>
            ////selectTxt += "    ,SALSLPSUB.SECTIONCODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
            //// 修正 2009.01.16 <<<
            //selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine; // ADD 2008.12.09
            //selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
            //// ADD 2009.01.06 >>>
            //selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
            //// ADD 2009.01.06 <<<
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            //selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            //selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
            //selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
            //selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            ////if (paramWork.AcptAnOdrStatus != null)
            ////{
            ////    if (paramWork.AcptAnOdrStatus[0] == 30)  //受注ステータス=30  -> 売上履歴データから取得
            ////        selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB " + Environment.NewLine;
            ////    else                                     //受注ステータス!=30 -> 売上データから取得
            ////        selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
            ////}
            ////else
            ////{
            ////    //指定なしは売上データから取得
            ////    selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

            //selectTxt += MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode);
            //#endregion  //[売上データ抽出Query]

            //selectTxt += "  ) AS SALSLP" + Environment.NewLine;

            //#region [JOIN]
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            //////売上明細データ or 売上履歴明細データ
            ////if (paramWork.AcptAnOdrStatus != null)
            ////{
            ////    if (paramWork.AcptAnOdrStatus[0] == 30)  //受注ステータス=30  -> 売上履歴明細データから取得
            ////        selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
            ////    else                                     //受注ステータス!=30 -> 売上明細データから取得
            ////        selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            ////}
            ////else
            ////{
            ////    //指定なしは売上明細データから取得
            ////    selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
            //selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLP.SALESSLIPNUMRF" + Environment.NewLine;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            //////売上明細データ or 売上履歴明細データ(元伝票)
            ////if (paramWork.AcptAnOdrStatus != null)
            ////{
            ////    if (paramWork.AcptAnOdrStatus[0] == 30)  //受注ステータス=30  -> 売上履歴明細データから取得
            ////        selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2" + Environment.NewLine;
            ////    else                                     //受注ステータス!=30 -> 売上明細データから取得
            ////        selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
            ////}
            ////else
            ////{
            ////    //指定なしは売上明細データから取得
            ////    selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
            //selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;

            ////受注マスタ(車両)
            //selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR" + Environment.NewLine;
            //selectTxt += "  ON  AODCAR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND AODCAR.ACCEPTANORDERNORF=SALDTL.ACCEPTANORDERNORF" + Environment.NewLine;

            //// ADD 2008.12.09 >>>
            ////selectTxt += "  AND AODCAR.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "  AND (" + Environment.NewLine;
            //selectTxt += "         (SALDTL.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //　見積
            //selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // 受注
            //selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // 売上
            //selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // 出荷　
            //selectTxt += "    )" + Environment.NewLine;
            //// ADD 2008.12.09 <<<

            ////UOE発注データ
            //selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR" + Environment.NewLine;
            //selectTxt += "  ON  UOEODR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND UOEODR.COMMONSEQNORF=SALDTL.COMMONSEQNORF" + Environment.NewLine;

            ////拠点情報設定マスタ
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            //selectTxt += "  ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF" + Environment.NewLine;
            ////仕入明細データ
            //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
            //selectTxt += "  ON  STCDTL.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
            //selectTxt += "  AND STCDTL.STOCKSLIPDTLNUMRF=SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;

            ////仕入データ
            //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
            //selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            //selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

            ////BLグループマスタ
            //selectTxt += "  LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
            //selectTxt += "  ON  BLGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND BLGRPU.BLGROUPCODERF=SALDTL.BLGROUPCODERF" + Environment.NewLine;

            ////ユーザーガイドマスタ(ボディ)
            //// 修正 2009/05/12 >>>
            //#region DEL
            ////selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            ////selectTxt += "  ON  USRGBU.ENTERPRISECODERF=BLGRPU.ENTERPRISECODERF" + Environment.NewLine;
            ////selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
            ////selectTxt += "  AND USRGBU.GUIDECODERF=BLGRPU.SALESCODERF" + Environment.NewLine;
            //#endregion
            //selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            //selectTxt += "  ON  USRGBU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
            //selectTxt += "  AND USRGBU.GUIDECODERF=SALDTL.SALESCODERF" + Environment.NewLine;
            //// 修正 2009/05/12 <<<
            // -- DEL 2009/09/04 --------------------------------------------<<<
            //#endregion  //[JOIN]
            #endregion [DEL 2009/09/04]

            // -- ADD 2009/09/04 ------------------------------------------->>>
            //検索上限件数を超えるまで取得
            //selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine; // DEL 2015/02/05 王亜楠
            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            if (paramWork.SearchCountCtrl == 1)
            {
                // 抽出件数制限なしの場合
                selectTxt += "  SELECT " + Environment.NewLine;
            }
            else
            {
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            }
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
            selectTxt += "    SALSLP.SALESDATERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESROWNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESEMPLOYEENMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESTOTALTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESTOTALTAXINCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSNORF" + Environment.NewLine;
            selectTxt += "   ,GDSCHG.CHGDESTGOODSNORF" + Environment.NewLine; //変換後品番　//ADD 陳永康 2014/12/28 変換後品番の追加対応
            // -------------ADD 2009/12/28-------------->>>>>
            selectTxt += "   ,SALSLP.GOODSNORF_NOHALF" + Environment.NewLine;//ハイフン除去後の品番
            // -------------ADD 2009/12/28--------------<<<<<
            selectTxt += "   ,SALSLP.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SHIPMENTCNTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.COSTRATERF" + Environment.NewLine;   // ADD 連番729 2011/08/18
            selectTxt += "   ,SALSLP.SALESRATERF" + Environment.NewLine;   // ADD 連番729 2011/08/18
            selectTxt += "   ,SALSLP.CONSTAXRATERF" + Environment.NewLine; // ADD 時シン 2020/03/11 PMKOBETSU-2912
            selectTxt += "   ,SALSLP.OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESUNITCOSTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESMONEYTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CONSTAXLAYMETHODRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.TOTALCOSTRF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.CATEGORYNORF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.MODELFULLNAMERF" + Environment.NewLine;
            // --- ADD m.suzuki 2010/04/02 ---------->>>>>
            selectTxt += "   ,AODCAR.MODELHALFNAMERF" + Environment.NewLine;
            // --- ADD m.suzuki 2010/04/02 ----------<<<<<
            selectTxt += "   ,AODCAR.FIRSTENTRYDATERF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.SEARCHFRAMENORF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.FULLMODELRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SLIPNOTERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SLIPNOTE3RF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.FRONTEMPLOYEENMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESINPUTNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.CARMNGCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACCEPTANORDERNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SHIPMSALESSLIPNUM" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SRCSALESSLIPNUM" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESORDERDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD" + Environment.NewLine;
            selectTxt += "   ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM" + Environment.NewLine;
            selectTxt += "   ,SALSLP.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "   ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.DTLNOTERF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.COLORNAME1RF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.TRIMNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.STDUNPRCLPRICERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.STDUNPRCSALUNPRCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.STDUNPRCUNCSTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.MAKERNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.COSTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CUSTSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACCRECDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACPTANODRREMAINCNTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.TAXATIONDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SHIPMENTDAYRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDRESSEECODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDRESSEENAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDRESSEENAME2RF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.FRAMENORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ENTERPRISEGANRECODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SEARCHSLIPDATERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSKINDCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSMGROUPRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.WAREHOUSESHELFNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPCDDTLRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSLGROUPNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSMGROUPNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
            selectTxt += "   ,AODCAR.CARMNGNORF" + Environment.NewLine; // 車両管理SEQ
            selectTxt += "   ,AODCAR.MAKERCODERF" + Environment.NewLine; // 車種メーカーコード
            selectTxt += "   ,AODCAR.MODELCODERF" + Environment.NewLine; // 車種コード
            selectTxt += "   ,AODCAR.MODELSUBCODERF" + Environment.NewLine; // 車種サブコード
            selectTxt += "   ,AODCAR.ENGINEMODELNMRF" + Environment.NewLine; // エンジン型式名称
            selectTxt += "   ,AODCAR.COLORCODERF" + Environment.NewLine; // カラーコード
            selectTxt += "   ,AODCAR.TRIMCODERF" + Environment.NewLine; // トリムコード
            selectTxt += "   ,AODCAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine; // フル型式固定番号配列
            selectTxt += "   ,AODCAR.FREESRCHMDLFXDNOARYRF" + Environment.NewLine; // 自由検索型式固定番号配列 // ADD 2010/04/27
            selectTxt += "   ,AODCAR.CATEGORYOBJARYRF" + Environment.NewLine; // 装備オブジェクト配列
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  張莉莉 2009/09/07 ADD
            selectTxt += "   ,AODCAR.MILEAGERF" + Environment.NewLine; // 車両走行距離
            selectTxt += "   ,AODCAR.CARNOTERF" + Environment.NewLine; // 車輌備考
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  張莉莉 2009/09/07 ADD
            selectTxt += "   ,SALSLP.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
            selectTxt += "   ,SALSLP.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）
            selectTxt += "   ,SALSLP.HISTORYDIVRF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += "   ,SALSLP.UPDATEDATETIMERF" + Environment.NewLine; // 更新日時
            selectTxt += "   ,SALSLP.UPDATEDATETIME" + Environment.NewLine; // 更新日時(明細)  // ADD 2012/04/01 gezh Redmine#29250
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            // -------------ADD 2009/12/28-------------->>>>>
            selectTxt += "    ,SALSLP.BFSALESUNITPRICERF" + Environment.NewLine;
            selectTxt += "    ,SALSLP.BFUNITCOSTRF" + Environment.NewLine;
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            selectTxt += "    ,SALSLP.BFLISTPRICERF" + Environment.NewLine;
            // -------------ADD 2010/08/05--------------<<<<<
            // -------------ADD 2011/07/18-------------->>>>>
            selectTxt += "    ,SALSLP.AUTOANSWERDIVSCMRF" + Environment.NewLine;
            // -------------ADD 2011/07/18--------------<<<<<

            //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
            selectTxt += "    ,SALSLP.INQUIRYNUMBERRF" + Environment.NewLine;
            //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

            // -------------ADD 2010/01/29 ---------->>>>>
            selectTxt += "    ,SALSLP.RETUPPERCNTRF" + Environment.NewLine;
            selectTxt += "    ,SALSLP.RETUPPERCNTDIVRF" + Environment.NewLine;
            // -------------ADD 2010/01/29 ----------<<<<<
            // -----ADD 2010/12/20 ----->>>>>
            selectTxt += "    ,SALSLP.HISDTLSLIPNUMRF" + Environment.NewLine;
            selectTxt += "    ,SALSLP.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
            // -----ADD 2010/12/20 -----<<<<<

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            selectTxt += "    ,USRGBUF.GUIDENAMERF AS SALESAREANAMERF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE1RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE2RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE3RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE4RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE5RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE6RF" + Environment.NewLine;
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
 
            selectTxt += "  FROM (" + Environment.NewLine;

            #region [売上データ抽出Query]
            // -- ADD 2009/10/05 --------------------------------->>>
            bool SalSlipFlg = false;  //売上が含まれるか
            bool AcpSlipFlg = false;  //貸出 or 受注が含まれるか
            //受注、貸出の指定が存在するかをチェック
            foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
            {
                if (iacptSt == 30)
                {
                    SalSlipFlg = true;
                }
                if (iacptSt != 30)
                {
                    AcpSlipFlg = true;
                }
            }
            // -- ADD 2009/10/05 ---------------------------------<<<

            // -- ADD 2009/10/05 --------------------------------->>>
            if (SalSlipFlg)
            {
            // -- ADD 2009/10/05 ---------------------------------<<<
                //売上抽出用(売上履歴データから抽出)
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXRATERF" + Environment.NewLine; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
                selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALSLPSUB.UPDATEDATETIMERF" + Environment.NewLine; // 更新日時
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALDTL.SALESROWNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNORF" + Environment.NewLine;
                // --- UPD m.suzuki 2010/03/11 ---------->>>>>
                //// -------------ADD 2009/12/28-------------->>>>>
                //selectTxt += "    ,REPLACE (SALDTL3.GOODSNORF, '-', '') AS GOODSNORF_NOHALF" + Environment.NewLine;//ハイフン除去後の品番
                //// -------------ADD 2009/12/28--------------<<<<<
                selectTxt += "    ,REPLACE (SALDTL.GOODSNORF, '-', '') AS GOODSNORF_NOHALF" + Environment.NewLine;//ハイフン除去後の品番（売上履歴明細から取得する）
                // --- UPD m.suzuki 2010/03/11 ----------<<<<<
                selectTxt += "    ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRATERF" + Environment.NewLine;   // ADD 連番729 2011/08/18
                selectTxt += "    ,SALDTL.SALESRATERF" + Environment.NewLine;   // ADD 連番729 2011/08/18
                selectTxt += "    ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.DTLNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL3.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;

                selectTxt += "    ,SALDTL.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1" + Environment.NewLine; // 受注マスタ（車両）がJOIN出来なかったため追加
                // -----ADD 2010/12/20 ----->>>>>
                selectTxt += "    ,SALDTL4.SALESSLIPNUMRF AS HISDTLSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACPTANODRSTATUSSRCRF AS ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                // -----ADD 2010/12/20 -----<<<<<
                selectTxt += "    ,(CASE WHEN SALDTL3.ACPTANODRREMAINCNTRF IS NULL THEN 1 ELSE 0 END) AS HISTORYDIVRF" + Environment.NewLine;
                // -------------ADD 2009/12/28-------------->>>>>
                selectTxt += "    ,SALDTL.BFSALESUNITPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BFUNITCOSTRF" + Environment.NewLine;
                // -------------ADD 2009/12/28--------------<<<<<
                // -------------ADD 2010/08/05-------------->>>>>
                selectTxt += "    ,SALDTL.BFLISTPRICERF" + Environment.NewLine;
                // -------------ADD 2010/08/05--------------<<<<<
                // -------------ADD 2011/07/18-------------->>>>>
                selectTxt += "    ,SALDTL.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                // -------------ADD 2011/07/18--------------<<<<<

                //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
                selectTxt += "    ,SALDTL.INQUIRYNUMBERRF" + Environment.NewLine;
                //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

                // -------------ADD 2010/01/29 ---------->>>>>
                selectTxt += "    ,RETURNU.RETUPPERCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.UPDATEDATETIMERF AS UPDATEDATETIME" + Environment.NewLine; // 更新日時（売上履歴明細から取得する） // ADD 2012/04/01 gezh Redmine#29250
                selectTxt += "    ,(CASE WHEN RETURNU.RETUPPERCNTRF IS NULL THEN 1 ELSE 0 END) AS RETUPPERCNTDIVRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB " + Environment.NewLine;
                selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;

                //受注残数は売上明細データにのみ存在するため結合
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL3" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL3.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL3.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL3.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ---------->>>>>
                // -----ADD 2010/12/20 ----->>>>>
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "  ON  SALDTL4.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL4.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL4.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                // -----ADD 2010/12/20 -----<<<<<
                //返品上限設定マスタ
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU" + Environment.NewLine;
                selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  RETURNU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<
                sqlCommand.Parameters.Clear();  // ADD 2009/10/05

                selectTxt += MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 0);
            }  // ADD 2009/10/05 

            // -- DEL 2009/10/05 ----------------------------->>>
            //bool SalSlipFlg = false;
            ////受注、貸出の指定が存在するかをチェック
            //foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
            //{
            //    if (iacptSt != 30)
            //    {
            //        SalSlipFlg = true;
            //        break;
            //    }
            //}
            // -- DEL 2009/10/05 -----------------------------<<<

            // -- UPD 2009/10/05 ----------------------------->>>
            //if (SalSlipFlg)
            //{
            //    selectTxt += "UNION ALL" + Environment.NewLine;

            if ((SalSlipFlg) && (AcpSlipFlg))
            {
                selectTxt += "UNION ALL" + Environment.NewLine;
            }
            // -- UPD 2009/10/05 -----------------------------<<<

            // -- ADD 2009/10/05 ----------------------------->>>
            if (AcpSlipFlg)
            {
            // -- ADD 2009/10/05 -----------------------------<<<
                //受注、貸出データ用（売上データから抽出）
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXRATERF" + Environment.NewLine; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
                selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALSLPSUB.UPDATEDATETIMERF" + Environment.NewLine; // 更新日時
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALDTL.SALESROWNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNORF" + Environment.NewLine;
                // -------------ADD 2009/12/28-------------->>>>>
                selectTxt += "    ,REPLACE (SALDTL.GOODSNORF, '-', '') AS GOODSNORF_NOHALF" + Environment.NewLine;//ハイフン除去後の品番
                // -------------ADD 2009/12/28--------------<<<<<
                selectTxt += "    ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRATERF" + Environment.NewLine;   // ADD 連番729 2011/08/18
                selectTxt += "    ,SALDTL.SALESRATERF" + Environment.NewLine;   // ADD 連番729 2011/08/18
                selectTxt += "    ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.DTLNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;

                selectTxt += "    ,SALDTL.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1" + Environment.NewLine; // 受注マスタ（車両）がJOIN出来なかったため追加
                // -----ADD 2010/12/20 ----->>>>>
                selectTxt += "    ,'' AS HISDTLSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,0 AS ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                // -----ADD 2010/12/20 -----<<<<<
                selectTxt += "    ,0 AS HISTORYDIVRF" + Environment.NewLine;
                // -------------ADD 2009/12/28-------------->>>>>
                selectTxt += "    ,SALDTL.BFSALESUNITPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BFUNITCOSTRF" + Environment.NewLine;
                // -------------ADD 2009/12/28--------------<<<<<
                // -------------ADD 2010/08/05-------------->>>>>
                selectTxt += "    ,SALDTL.BFLISTPRICERF" + Environment.NewLine;
                // -------------ADD 2010/08/05--------------<<<<<
                // -------------ADD 2011/07/18-------------->>>>>
                selectTxt += "    ,SALDTL.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                // -------------ADD 2011/07/18--------------<<<<<

                //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
                selectTxt += "    ,SALDTL.INQUIRYNUMBERRF" + Environment.NewLine;
                //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

                // -------------ADD 2010/01/29 ---------->>>>>
                selectTxt += "    ,RETURNU.RETUPPERCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.UPDATEDATETIMERF AS UPDATEDATETIME" + Environment.NewLine;  // 更新日時（売上明細から取得する） // ADD 2012/04/01 gezh Redmine#29250 
                selectTxt += "    ,(CASE WHEN RETURNU.RETUPPERCNTRF IS NULL THEN 1 ELSE 0 END) AS RETUPPERCNTDIVRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
                selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ---------->>>>>
                //返品上限設定マスタ
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU" + Environment.NewLine;
                selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  RETURNU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<
                //パラメータの重複指定を防ぐため、一度クリア
                sqlCommand.Parameters.Clear();
                selectTxt += MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 1);
            }
            #endregion  //[売上データ抽出Query]

            selectTxt += "  ) AS SALSLP" + Environment.NewLine;

            #region [JOIN]

            //受注マスタ(車両)
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR" + Environment.NewLine;
            selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  AODCAR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND AODCAR.ACCEPTANORDERNORF=SALSLP.ACCEPTANORDERNORF_1" + Environment.NewLine;
            selectTxt += "  AND (" + Environment.NewLine;
            selectTxt += "         (SALSLP.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //　見積
            selectTxt += "      OR (SALSLP.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // 受注
            selectTxt += "      OR (SALSLP.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // 売上
            selectTxt += "      OR (SALSLP.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // 出荷　
            selectTxt += "    )" + Environment.NewLine;

            //UOE発注データ
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR" + Environment.NewLine;
            selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  UOEODR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND UOEODR.COMMONSEQNORF=SALSLP.COMMONSEQNORF" + Environment.NewLine;
            // -- ADD 2010/06/07 -------------------------------->>>
            selectTxt += "  AND UOEODR.UOEKINDRF=0" + Environment.NewLine;
            // -- ADD 2010/06/07 --------------------------------<<<

            //拠点情報設定マスタ
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF" + Environment.NewLine;
            //仕入明細データ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            selectTxt += "  ON  STCDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=SALSLP.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.STOCKSLIPDTLNUMRF=SALSLP.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;

            //仕入データ
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN STOCKSLIPHISTRF STCSLP" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKSLIPHISTRF STCSLP WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

            //BLグループマスタ
            // -- DEL 2009/10/05 -------------------------------------->>>
            //selectTxt += "  LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
            //selectTxt += "  ON  BLGRPU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND BLGRPU.BLGROUPCODERF=SALSLP.BLGROUPCODERF" + Environment.NewLine;
            // -- DEL 2009/10/05 --------------------------------------<<<

            //ユーザーガイドマスタ(ボディ)
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            selectTxt += "  LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  USRGBU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
            selectTxt += "  AND USRGBU.GUIDECODERF=SALSLP.SALESCODERF" + Environment.NewLine;

            //--- ADD 陳永康 2014/12/28 変換後品番の追加対応 ----->>>>>
            selectTxt += "  LEFT JOIN GOODSNOCHANGERF GDSCHG WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += "  ON  GDSCHG.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND GDSCHG.GOODSMAKERCDRF=SALSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "  AND GDSCHG.CHGSRCGOODSNORF=SALSLP.GOODSNORF" + Environment.NewLine;
            //--- ADD 陳永康 2014/12/28 変換後品番の追加対応 -----<<<<<
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            selectTxt += " LEFT JOIN CUSTOMERRF CUSTOMER WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  CUSTOMER.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUSTOMER.CUSTOMERCODERF=SALSLP.CUSTOMERCODERF" + Environment.NewLine;

            selectTxt += " LEFT JOIN USERGDBDURF USRGBUF WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  USRGBUF.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBUF.USERGUIDEDIVCDRF=21" + Environment.NewLine;
            selectTxt += " AND USRGBUF.LOGICALDELETECODERF=0" + Environment.NewLine;
            selectTxt += " AND USRGBUF.GUIDECODERF=CUSTOMER.SALESAREACODERF" + Environment.NewLine;
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
            #endregion  //[JOIN]
            // -- ADD 2009/09/04 -------------------------------------------<<<

            //WHERE句
            selectTxt += MakeWhereString_SALTBL(ref sqlCommand, paramWork, logicalMode);

            #endregion  //[データ抽出メインQuery]

            // -- DEL 2009/10/05 ----------------------->>>
            //selectTxt += " ) AS SALTBL" + Environment.NewLine;

            ////ORDER BY
            //selectTxt += " ORDER BY ROWNUM DESC";
            // -- DEL 2009/10/05 -----------------------<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            //selectTxt += " ORDER BY SALSLP.SALESDATERF, SALSLP.SALESSLIPNUMRF" + Environment.NewLine; // DEL 2015/02/05 王亜楠
            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            if (paramWork.SearchCountCtrl == 1)
            {
                // 抽出件数制限なしの場合
                selectTxt += " ORDER BY SALSLP.SALESDATERF, SALSLP.SALESSLIPNUMRF, SALSLP.SALESROWNORF" + Environment.NewLine;
            }
            else
            {
            selectTxt += " ORDER BY SALSLP.SALESDATERF, SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            }
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            #endregion

            return selectTxt;
        }
        #endregion  //[CustPrtPprSalTblRsltWork用 SELECT文生成処理]

        #region [DEL 2009/09/04]
        // -- DEL 2009/09/04 ------------------------------>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        //#region [売上履歴データ用 SELECT文生成処理]
        ///// <summary>
        ///// 売上履歴データ用SELECT文作成
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommandオブジェクト</param>
        ///// <param name="paramWork">検索条件</param>
        ///// <param name="logicalMode">論理削除区分</param>
        ///// <returns>売上履歴データ用SELECT文</returns>
        ///// <br>Note       : 売上履歴データ用SELECT文を作成して戻します</br>
        ///// <br>Programmer : 22018 鈴木 正臣</br>
        ///// <br>Date       : 2009.08.24</br>
        //private string MakeTypeSalSlpHisQuery( ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode )
        //{
        //    string selectTxt = "";

        //    // 対象テーブル
        //    // SALESHISTORYRF    SALSLP   売上履歴データ 
        //    // SALESHISTDTLRF    SALDTL   売上履歴明細データ① 
        //    // SALESHISTDTLRF    SALDTL2  売上履歴明細データ② 
        //    // ACCEPTODRCARRF    AODCAR   受注マスタ(車両)
        //    // UOEORDERDTLRF     UOEODR   UOE発注データ
        //    // SECINFOSETRF      SCINFS   拠点情報設定マスタ
        //    // STOCKSLHISTDTLRF  STCDTL   仕入履歴明細データ 
        //    // STOCKSLIPHISTRF   STCSLP   仕入履歴データ 
        //    // BLGROUPURF        BLGRPU   BLグループマスタ
        //    // USERGDBDURF       USRGBU   ユーザーガイドマスタ(ボディ)

        //    #region [Select文作成]
        //    selectTxt += "SELECT" + Environment.NewLine;
        //    selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
        //    selectTxt += "   OVER(ORDER BY SALTBL.SALESSLIPNUMRF)" + Environment.NewLine;
        //    selectTxt += "   AS ROWNUM" + Environment.NewLine;
        //    selectTxt += " ,*" + Environment.NewLine;
        //    selectTxt += " FROM (" + Environment.NewLine;

        //    #region [データ抽出メインQuery]
        //    //検索上限件数を超えるまで取得
        //    selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
        //    selectTxt += "    SALSLP.SALESDATERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESROWNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESSLIPCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESTOTALTAXEXCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESTOTALTAXINCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CONSTAXLAYMETHODRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.TOTALCOSTRF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.CATEGORYNORF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.MODELFULLNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.FIRSTENTRYDATERF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.SEARCHFRAMENORF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.FULLMODELRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SLIPNOTERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SLIPNOTE2RF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SLIPNOTE3RF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.FRONTEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESINPUTNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.CARMNGCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
        //    selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
        //    selectTxt += "   ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD" + Environment.NewLine;
        //    selectTxt += "   ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.UOEREMARK1RF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.UOEREMARK2RF" + Environment.NewLine;
        //    selectTxt += "   ,USRGBU.GUIDENAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.DTLNOTERF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.COLORNAME1RF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.TRIMNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.MAKERNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.COSTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CUSTSLIPNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDUPADATERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ACCRECDIVCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.DEBITNOTEDIVRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SECTIONCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
        //    //selectTxt += "   ,SALDTL.ACPTANODRREMAINCNTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
        //    selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SHIPMENTDAYRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDRESSEECODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDRESSEENAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDRESSEENAME2RF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.FRAMENORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SEARCHSLIPDATERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
        //    selectTxt += "   ,AODCAR.CARMNGNORF" + Environment.NewLine; // 車両管理SEQ
        //    selectTxt += "   ,AODCAR.MAKERCODERF" + Environment.NewLine; // 車種メーカーコード
        //    selectTxt += "   ,AODCAR.MODELCODERF" + Environment.NewLine; // 車種コード
        //    selectTxt += "   ,AODCAR.MODELSUBCODERF" + Environment.NewLine; // 車種サブコード
        //    selectTxt += "   ,AODCAR.ENGINEMODELNMRF" + Environment.NewLine; // エンジン型式名称
        //    selectTxt += "   ,AODCAR.COLORCODERF" + Environment.NewLine; // カラーコード
        //    selectTxt += "   ,AODCAR.TRIMCODERF" + Environment.NewLine; // トリムコード
        //    selectTxt += "   ,AODCAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine; // フル型式固定番号配列
        //    selectTxt += "   ,AODCAR.CATEGORYOBJARYRF" + Environment.NewLine; // 装備オブジェクト配列
        //    selectTxt += "   ,SALSLP.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
        //    selectTxt += "   ,SALSLP.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）

        //    selectTxt += "  FROM (" + Environment.NewLine;

        //    #region [売上履歴データ抽出Query]
        //    selectTxt += "   SELECT" + Environment.NewLine;
        //    selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // 納品区分
        //    selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // 売上入力者コード（発行者）
        //    selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // 受付従業員コード（受注者）

        //    //selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
        //    selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB " + Environment.NewLine;

        //    selectTxt += MakeWhereString_SALSLPSUB( ref sqlCommand, paramWork, logicalMode );
        //    #endregion

        //    selectTxt += "  ) AS SALSLP" + Environment.NewLine;

        //    #region [JOIN]
        //    //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
        //    selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLP.SALESSLIPNUMRF" + Environment.NewLine;

        //    //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2" + Environment.NewLine;
        //    selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;

        //    //受注マスタ(車両)
        //    selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR" + Environment.NewLine;
        //    selectTxt += "  ON  AODCAR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND AODCAR.ACCEPTANORDERNORF=SALDTL.ACCEPTANORDERNORF" + Environment.NewLine;
        //    selectTxt += "  AND (" + Environment.NewLine;
        //    selectTxt += "         (SALDTL.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //　見積
        //    selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // 受注
        //    selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // 売上
        //    selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // 出荷　
        //    selectTxt += "    )" + Environment.NewLine;

        //    //UOE発注データ
        //    selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR" + Environment.NewLine;
        //    selectTxt += "  ON  UOEODR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND UOEODR.COMMONSEQNORF=SALDTL.COMMONSEQNORF" + Environment.NewLine;

        //    //拠点情報設定マスタ
        //    selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
        //    selectTxt += "  ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF" + Environment.NewLine;
        //    //仕入明細データ
        //    //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL" + Environment.NewLine;
        //    selectTxt += "  ON  STCDTL.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
        //    selectTxt += "  AND STCDTL.STOCKSLIPDTLNUMRF=SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;

        //    //仕入データ
        //    //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN STOCKSLIPHISTRF STCSLP" + Environment.NewLine;
        //    selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
        //    selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

        //    //BLグループマスタ
        //    selectTxt += "  LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
        //    selectTxt += "  ON  BLGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND BLGRPU.BLGROUPCODERF=SALDTL.BLGROUPCODERF" + Environment.NewLine;

        //    //ユーザーガイドマスタ(ボディ)
        //    selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
        //    selectTxt += "  ON  USRGBU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
        //    selectTxt += "  AND USRGBU.GUIDECODERF=SALDTL.SALESCODERF" + Environment.NewLine;
        //    #endregion

        //    //WHERE句
        //    selectTxt += MakeWhereString_SALTBL( ref sqlCommand, paramWork, logicalMode );

        //    #endregion  //[データ抽出メインQuery]

        //    selectTxt += " ) AS SALTBL" + Environment.NewLine;

        //    //ORDER BY
        //    selectTxt += " ORDER BY ROWNUM DESC";
        //    #endregion

        //    return selectTxt;
        //}
        //#endregion
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ------------------------------<<<
        #endregion [DEL 2009/09/04]


        #region [入金データ用 SELECT文生成処理]
        /// <summary>
        /// 支払データ用SELECT文作成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>支払データ用SELECT文</returns>
        /// <br>Note       : 支払データ用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: K2015/06/16 鮑晶</br>
        /// <br>管理番号   : 11101427-00</br>
        /// <br>           : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        private string MakeTypeDepSitQuery(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // 対象テーブル
            // DEPSITMAINRF  DEPSM  入金マスタ
            // DEPSITDTLRF   DEPSD  入金明細データ

            #region [Select文作成]
            // -- DEL 2009/10/05 -------------------------------------->>>
            // 抽出速度アップのため削除
            //selectTxt += "SELECT" + Environment.NewLine;
            //selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            //selectTxt += "   OVER(ORDER BY SALTBL.DEPOSITSLIPNORF)" + Environment.NewLine;
            //selectTxt += "   AS ROWNUM" + Environment.NewLine;
            //selectTxt += " ,*" + Environment.NewLine;
            //selectTxt += " FROM (" + Environment.NewLine;
            // -- DEL 2009/10/05 --------------------------------------<<<

            #region [データ抽出メインQuery]
            //検索上限件数を超えるまで取得
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            selectTxt += "    DEPSM.DEPOSITDATERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,DEPSD.DEPOSITROWNORF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITAGENTNMRF" + Environment.NewLine;
            selectTxt += "   ,(DEPSM.DEPOSITRF+DEPSM.DISCOUNTDEPOSITRF+DEPSM.FEEDEPOSITRF)" + Environment.NewLine;
            selectTxt += "    AS DEPOSPRICTOTAL" + Environment.NewLine;
            selectTxt += "   ,DEPSD.MONEYKINDNAMERF" + Environment.NewLine;
            selectTxt += "   ,DEPSD.DEPOSITRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.OUTLINERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.ADDUPSECCODERF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine; // ADD 2009.01.14  
            selectTxt += "   ,DEPSD.VALIDITYTERMRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
            // ADD 2009.02.13 >>>
            selectTxt += "    ,DEPSM.FEEDEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSM.DISCOUNTDEPOSITRF" + Environment.NewLine;
            // ADD 2009.02.13 <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            selectTxt += "    ,DEPSM.INPUTDAYRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += "    ,DEPSM.UPDATEDATETIMERF" + Environment.NewLine; // 更新日時
            selectTxt += "    ,DEPSD.UPDATEDATETIMERF AS UPDATEDATETIME" + Environment.NewLine; // 更新日時（入金明細から取得する） // ADD 2012/04/01 gezh Redmine#29250 
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            selectTxt += "    ,USRGBUF.GUIDENAMERF AS SALESAREANAMERF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE1RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE2RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE3RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE4RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE5RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE6RF" + Environment.NewLine;
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

            selectTxt += "  FROM (" + Environment.NewLine;

            #region [入金データ抽出Query]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     DEPSMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITDATERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITSLIPNORF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITAGENTNMRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DISCOUNTDEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.FEEDEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.OUTLINERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.ADDUPSECCODERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            selectTxt += "    ,DEPSMSUB.INPUTDAYRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += "    ,DEPSMSUB.UPDATEDATETIMERF" + Environment.NewLine; // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            // -- UPD 2010/06/09 ----------------------------------->>>
            //selectTxt += "   FROM DEPSITMAINRF AS DEPSMSUB" + Environment.NewLine;
            selectTxt += "   FROM DEPSITMAINRF AS DEPSMSUB WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------<<<
            selectTxt += MakeWhereString_DEPSMSUB(ref sqlCommand, paramWork, logicalMode);
            #endregion  //[入金データ抽出Query]

            selectTxt += "  ) AS DEPSM" + Environment.NewLine;

            //JOIN
            //入金明細データ
            // -- UPD 2010/06/09 ----------------------------------->>>
            //selectTxt += "  LEFT JOIN DEPSITDTLRF DEPSD" + Environment.NewLine;
            selectTxt += "  LEFT JOIN DEPSITDTLRF DEPSD WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------<<<
            selectTxt += "  ON  DEPSD.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND DEPSD.ACPTANODRSTATUSRF=DEPSM.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "  AND DEPSD.DEPOSITSLIPNORF=DEPSM.DEPOSITSLIPNORF" + Environment.NewLine;
            // ADD 2009.01.14 >>>
            //拠点情報設定マスタ
            // -- UPD 2010/06/09 ----------------------------------->>>
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------<<<
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SCINFS.SECTIONCODERF=DEPSM.ADDUPSECCODERF" + Environment.NewLine;
             // ADD 2009.01.14 <<<
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            selectTxt += " LEFT JOIN CUSTOMERRF CUSTOMER WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  CUSTOMER.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUSTOMER.CUSTOMERCODERF=DEPSM.CUSTOMERCODERF" + Environment.NewLine;

            selectTxt += " LEFT JOIN USERGDBDURF USRGBUF WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  USRGBUF.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBUF.USERGUIDEDIVCDRF=21" + Environment.NewLine;
            selectTxt += " AND USRGBUF.LOGICALDELETECODERF=0" + Environment.NewLine;
            selectTxt += " AND USRGBUF.GUIDECODERF=CUSTOMER.SALESAREACODERF" + Environment.NewLine;

            selectTxt += MakeWhereString_DEPSM(ref sqlCommand, paramWork, logicalMode);
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
            #endregion  //[データ抽出メインQuery]

            //  -- UPD 2009/10/05 --------------------------->>>
            //selectTxt += " ) AS SALTBL" + Environment.NewLine;

            ////ORDER BY
            //selectTxt += " ORDER BY ROWNUM DESC";
            //  -- UPD 2009/10/05 ---------------------------<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += " ORDER BY DEPSM.DEPOSITDATERF, DEPSM.DEPOSITSLIPNORF";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            #endregion

            return selectTxt;
        }
        #endregion  //[CustPrtPprSalTblRsltWork用 SELECT文生成処理]

        #region [CustPrtPprSalTblRsltWork用 WHERE文生成処理 (仕入データSELECT用)]
        /// <summary>
        /// 伝票表示・明細表示のリスト抽出用WHERE句 生成処理 (仕入データSELECT用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="mode">0:売上抽出(売上履歴読み込み),1:受注貸出抽出(売上データ読み込み)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        private string MakeWhereString_SALSLPSUB(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode, int mode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " SALSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SALSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SALSLPSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード
            if (paramWork.SectionCode != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
                //string sectionCodestr = "";
                //foreach ( string seccdstr in paramWork.SectionCode )
                //{
                //    if ( sectionCodestr != "" )
                //    {
                //        sectionCodestr += ",";
                //    }
                //    sectionCodestr += "'" + seccdstr + "'";
                //}
                //if ( sectionCodestr != "" )
                //{
                //    // 修正 2009.01.16 >>>
                //    //retstring += " AND SALSLPSUB.SECTIONCODERF IN (" + sectionCodestr + ") ";
                //    retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                //    // 修正 2009.01.16 <<<
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                if (paramWork.SectionCode.Length == 1)
                {
                    // -- UPD 2009/10/05 ---------------------------->>>
                    //「@FINDRESULTSADDUPSECCD」の名前にすると拠点有り指定でCPUが100%になる現象が発生したため改名
                    //retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF=@FINDRESULTSADDUPSECCD ";
                    //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                    retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF=@RESULTSADDUPSECCD " + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                    // -- UPD 2009/10/05 ----------------------------<<<


                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode[0]);
                }
                else
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
                        retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                retstring += Environment.NewLine;
            }
            // ADD 2009/10/05 ------------------------->>>
            else
            {
                retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF=SALSLPSUB.RESULTSADDUPSECCDRF " + Environment.NewLine;
            }
            // ADD 2009/10/05 -------------------------<<<

            //得意先コード
            if ( paramWork.CustomerCode != 0 )
            {
                retstring += " AND SALSLPSUB.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32( paramWork.CustomerCode );
            }

            //請求先コード
            if ( paramWork.ClaimCode != 0 )
            {
                retstring += " AND SALSLPSUB.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add( "@FINDCLAIMCODE", SqlDbType.Int );
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32( paramWork.ClaimCode );
            }


            //売上日付
            if (paramWork.St_SalesDate != DateTime.MinValue)
            {
                // 2008/12/24 DEL >>> 
                //retstring += " AND SALSLPSUB.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                // 2008/12/24 DEL <<<
                // -- UPD 2010/05/10 ------------------------------------>>>
                //// 2008/12/24 ADD >>>
                //retstring += " AND ((SALSLPSUB.SALESDATERF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                //// 2008/12/24 ADD <<<
                if (mode == 0)
                {
                    //売上履歴データの抽出の場合
                    retstring += " AND SALSLPSUB.SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_SalesDate).ToString() + Environment.NewLine;
                }
                else
                {
                    //売上データの抽出の場合
                    retstring += " AND ((SALSLPSUB.SALESDATERF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                }

                // -- UPD 2010/05/10 ------------------------------------<<<
                SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_SalesDate);

            }
            if (paramWork.Ed_SalesDate != DateTime.MinValue)
            {
                // 2008.12.24 DEL >>>
                //retstring += " AND SALSLPSUB.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                // 2008.12.24 DEL <<<

                // -- UPD 2010/05/10 ------------------------------------>>>
                //// 2008.12.24 ADD >>>
                //retstring += " AND ((SALSLPSUB.SALESDATERF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                //// 2008.12.24 ADD <<<
                if (mode == 0)
                {
                    //売上履歴データの抽出の場合
                    retstring += " AND SALSLPSUB.SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_SalesDate).ToString() + Environment.NewLine;
                }
                else
                {
                    //売上データの抽出の場合
                    retstring += " AND ((SALSLPSUB.SALESDATERF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                }
                // -- UPD 2010/05/10 ------------------------------------<<<
                SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_SalesDate);

            }

            //入力日付(伝票検索日付)
            if (paramWork.St_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND SALSLPSUB.SEARCHSLIPDATERF>=@STSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraStAddUpADate = sqlCommand.Parameters.Add("@STSEARCHSLIPDATE", SqlDbType.Int);
                paraStAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_AddUpADate);
            }
            if (paramWork.Ed_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND SALSLPSUB.SEARCHSLIPDATERF<=@EDSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraEdAddUpADate = sqlCommand.Parameters.Add("@EDSEARCHSLIPDATE", SqlDbType.Int);
                paraEdAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_AddUpADate);
            }

            //受注ステータス
            if (paramWork.AcptAnOdrStatus != null)
            {
                string acptAnOdrStatusstr = "";
                foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
                {
                    // -- ADD 2009/09/04 ---------------------------->>>
                    //受注貸出用の売上データの抽出の場合、30:売上は抽出対象外とする
                    if ((mode == 1) && (iacptSt == 30)) continue;
                    // -- ADD 2009/09/04 ----------------------------<<<
                    // -- ADD 2009/10/05 ----------------------------->>>
                    if ((mode == 0) && ((iacptSt == 20) || (iacptSt == 40))) continue;
                    // -- ADD 2009/10/05 -----------------------------<<<

                    if (acptAnOdrStatusstr != "")
                    {
                        acptAnOdrStatusstr += ",";
                    }
                    acptAnOdrStatusstr += iacptSt.ToString();
                }
                if (acptAnOdrStatusstr != "")
                {
                    retstring += " AND SALSLPSUB.ACPTANODRSTATUSRF IN (" + acptAnOdrStatusstr + ") ";
                }

                retstring += Environment.NewLine;
            }

            //売上伝票区分
            if (paramWork.SalesSlipCd != null)
            {
                string salesSlipCdstr = "";
                foreach (Int32 isalCd in paramWork.SalesSlipCd)
                {
                    if (salesSlipCdstr != "")
                    {
                        salesSlipCdstr += ",";
                    }
                    salesSlipCdstr += isalCd.ToString();
                }
                if (salesSlipCdstr != "")
                {
                    retstring += " AND SALSLPSUB.SALESSLIPCDRF IN (" + salesSlipCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //売上伝票番号
            if (paramWork.SalesSlipNum != "")
            {
                retstring += " AND SALSLPSUB.SALESSLIPNUMRF>=@FINDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.SalesSlipNum);
            }

            //担当者(販売従業員コード)
            if (paramWork.SalesEmployeeCd != "")
            {
                retstring += " AND SALSLPSUB.SALESEMPLOYEECDRF=@FINDSALESEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
            }

            //受注者(受付従業員コード)
            if (paramWork.FrontEmployeeCd != "")
            {
                retstring += " AND SALSLPSUB.FRONTEMPLOYEECDRF=@FINDFRONTEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDFRONTEMPLOYEECD", SqlDbType.NChar);
                paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paramWork.FrontEmployeeCd);
            }

            //発行者(売上入力者コード)
            if (paramWork.SalesInputCode != "")
            {
                retstring += " AND SALSLPSUB.SALESINPUTCODERF=@FINDSALESINPUTCODE" + Environment.NewLine;
                SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@FINDSALESINPUTCODE", SqlDbType.NChar);
                paraSalesInputCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesInputCode);
            }

            //得意先注番(相手先伝票番号)
            if (paramWork.PartySaleSlipNum != "")
            {
                // ----- DEL 2013/03/18 zhaimm Redmine#34807 --------------------------------------------------------------->>>>>
                //retstring += " AND SALSLPSUB.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM" + Environment.NewLine;
                //SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                //paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.PartySaleSlipNum);
                // ----- DEL 2013/03/18 zhaimm Redmine#34807 ---------------------------------------------------------------<<<<<
                retstring += " AND SALSLPSUB.PARTYSALESLIPNUMRF IN (" + paramWork.PartySaleSlipNum + ")" + Environment.NewLine; // ADD 2013/03/18 zhaimm Redmine#34807
            }

            //備考１(伝票備考) ※あいまい検索あり
            if (paramWork.SlipNote != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND SALSLPSUB.SLIPNOTERF LIKE @FINDSLIPNOTE" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND SALSLPSUB.SLIPNOTERF=@FINDSLIPNOTE" + Environment.NewLine;
                }
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@FINDSLIPNOTE", SqlDbType.NVarChar);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote);
            }

            //備考２(伝票備考２) ※あいまい検索あり
            if (paramWork.SlipNote2 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote2, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND SALSLPSUB.SLIPNOTE2RF LIKE @FINDSLIPNOTE2" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND SALSLPSUB.SLIPNOTE2RF=@FINDSLIPNOTE2" + Environment.NewLine;
                }
                SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@FINDSLIPNOTE2", SqlDbType.NVarChar);
                paraSlipNote2.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote2);
            }

            //備考３(伝票備考３) ※あいまい検索あり
            if (paramWork.SlipNote3 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote3, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND SALSLPSUB.SLIPNOTE3RF LIKE @FINDSLIPNOTE3" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND SALSLPSUB.SLIPNOTE3RF=@FINDSLIPNOTE3" + Environment.NewLine;
                }
                SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@FINDSLIPNOTE3", SqlDbType.NVarChar);
                paraSlipNote3.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote3);
            }

            //ＵＯＥリマーク１ ※あいまい検索あり
            if (paramWork.UoeRemark1 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark1, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND SALSLPSUB.UOEREMARK1RF LIKE @FINDUOEREMARK1" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND SALSLPSUB.UOEREMARK1RF=@FINDUOEREMARK1" + Environment.NewLine;
                }
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@FINDUOEREMARK1", SqlDbType.NVarChar);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark1);
            }

            //ＵＯＥリマーク２ ※あいまい検索あり
            if (paramWork.UoeRemark2 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark2, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND SALSLPSUB.UOEREMARK2RF LIKE @FINDUOEREMARK2" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND SALSLPSUB.UOEREMARK2RF=@FINDUOEREMARK2" + Environment.NewLine;
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprSalTblRsltWork用 WHERE文生成処理 (仕入データSELECT用)]

        #region [CustPrtPprSalTblRsltWork用 WHERE文生成処理 (仕入明細データSELECT用)]
        /// <summary>
        /// 伝票表示・明細表示のリスト抽出用WHERE句 生成処理 (仕入明細データSELECT用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>UpdateNote : 張莉莉 2009/10/22 /br>
        /// <br>           : Mentis：0014427 仕様変更:抽出条件の管理番号を文字列入力可能に変更、また、管理番号検索条件の追加する</br>
        /// <br>Update Note :2010/08/05 呉元嘯 障害・改良対応8月リリース分</br>
        /// <br>             車台番号検索条件変更</br>
        /// <br>Update Note :2011/07/18 zhubj 回答区分追加対応</br>
        /// <br>Update Note :2011/11/28 楊洋 redmine#8172の追加対応</br>
        /// <br>Update Note :K2015/06/16 鮑晶</br>
        /// <br>管理番号    :11101427-00</br>
        /// <br>            :メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>UpdateNote : 2016/01/21 脇田 靖之</br>
        /// <br>管理番号   : 11270007-00 仕掛一覧№2808 貸出受注対応</br>
        /// <br>           : ①検索条件に「出荷状況」項目を追加</br>
        /// <br>           : ②明細表示に計上数、未計上数項目を追加</br>
        /// <br>Update Note :K2016/02/23 時シン</br>
        /// <br>             ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
        /// <br></br>
        private string MakeWhereString_SALTBL(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " SALSLP.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //管理番号(車輌管理コード)
            if (paramWork.CarMngCode != "")
            {
                // --- ADD 2009/10/22 Mentis：0014427----->>>>>
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.CarMngCode, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND AODCAR.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND AODCAR.CARMNGCODERF=@FINDCARMNGCODE" + Environment.NewLine;
                }
                //retstring += " AND AODCAR.CARMNGCODERF=@FINDCARMNGCODE" + Environment.NewLine;
                // --- ADD 2009/10/22 Mentis：0014427-----<<<<<
                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NVarChar);
                paraCarMngCode.Value = SqlDataMediator.SqlSetString(paramWork.CarMngCode);
            }

            //車種名称(車種全角名称) ※あいまい検索あり
            if (paramWork.ModelFullName != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.ModelFullName, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND AODCAR.MODELFULLNAMERF LIKE @FINDMODELFULLNAME" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND AODCAR.MODELFULLNAMERF=@FINDMODELFULLNAME" + Environment.NewLine;
                }
                SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@FINDMODELFULLNAME", SqlDbType.NVarChar);
                paraModelFullName.Value = SqlDataMediator.SqlSetString(paramWork.ModelFullName);
            }

            //型式(型式(フル型)) ※あいまい検索あり
            if (paramWork.FullModel != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.FullModel, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND AODCAR.FULLMODELRF LIKE @FINDFULLMODEL" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND AODCAR.FULLMODELRF=@FINDFULLMODEL" + Environment.NewLine;
                }
                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                paraFullModel.Value = SqlDataMediator.SqlSetString(paramWork.FullModel);
            }

            // -----------UPD 2010/08/05------------>>>>>
            ////車台№(車台番号(検索用))
            //if (paramWork.SearchFrameNo != 0)
            //{
            //    retstring += " AND AODCAR.SEARCHFRAMENORF>=@FINDSEARCHFRAMENO" + Environment.NewLine;
            //    SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@FINDSEARCHFRAMENO", SqlDbType.Int);
            //    paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(paramWork.SearchFrameNo);
            //}
            //車台№
            if (paramWork.FrameNo != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.FrameNo, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND AODCAR.FRAMENORF LIKE @FINDFRAMENO" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND AODCAR.FRAMENORF=@FINDFRAMENO" + Environment.NewLine;
                }
                SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FINDFRAMENO", SqlDbType.NVarChar);
                paraFrameNo.Value = SqlDataMediator.SqlSetString(paramWork.FrameNo);
            }
            // -----------UPD 2010/08/05------------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //自動回答
            if (paramWork.AutoAnswerDivSCM != 0)
            {
                retstring += " AND SALSLP.AUTOANSWERDIVSCMRF =@FINDAUTOANSWERDIVSCM" + Environment.NewLine;
                SqlParameter paraAutoAnswerDivSCM = sqlCommand.Parameters.Add("@FINDAUTOANSWERDIVSCM", SqlDbType.Int);
                paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(paramWork.AutoAnswerDivSCM - 1);
            }
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<
            
            //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
            //問合せ番号
            if (paramWork.InquiryNumber != 0)
            {
                retstring += " AND SALSLP.INQUIRYNUMBERRF =@FINDSTINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraStInquiryNumber = sqlCommand.Parameters.Add("@FINDSTINQUIRYNUMBER", SqlDbType.BigInt);
                paraStInquiryNumber.Value = SqlDataMediator.SqlSetInt64(paramWork.InquiryNumber);
            }
            //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

            //カラー名称(カラー名称1) ※あいまい検索あり
            if (paramWork.ColorName1 != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.ColorName1, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND AODCAR.COLORNAME1RF LIKE @FINDCOLORNAME1" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND AODCAR.COLORNAME1RF=@FINDCOLORNAME1" + Environment.NewLine;
                }
                SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@FINDCOLORNAME1", SqlDbType.NVarChar);
                paraColorName1.Value = SqlDataMediator.SqlSetString(paramWork.ColorName1);
            }

            //トリム名称 ※あいまい検索あり
            if (paramWork.TrimName != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.TrimName, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND AODCAR.TRIMNAMERF LIKE @FINDTRIMNAME" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND AODCAR.TRIMNAMERF=@FINDTRIMNAME" + Environment.NewLine;
                }
                SqlParameter paraTrimName = sqlCommand.Parameters.Add("@FINDTRIMNAME", SqlDbType.NVarChar);
                paraTrimName.Value = SqlDataMediator.SqlSetString(paramWork.TrimName);
            }

            //UOE送信(データ送信区分)
            if (paramWork.DataSendCode != 0)
            {
                if (paramWork.DataSendCode == 9)
                {
                    //UOE送信 -> UOE送信のみ
                    retstring += " AND UOEODR.UOEKINDRF = 0" + Environment.NewLine;
                    retstring += " AND UOEODR.DATASENDCODERF=9" + Environment.NewLine;
                }
                else
                {
                    //通常 -> UOE送信以外
                    //retstring += " AND UOEODR.DATASENDCODERF<>9" + Environment.NewLine;
                    retstring += " AND ((UOEODR.DATASENDCODERF IS NULL) OR UOEODR.DATASENDCODERF<>9)" + Environment.NewLine;

                }
            }

            //ＢＬグループ(BLグループコード)
            if (paramWork.BLGroupCode != 0)
            {
                // -- UPD 2009/09/04 ------------------------------------------->>>
                //retstring += " AND SALDTL.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                retstring += " AND SALSLP.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 -------------------------------------------<<<
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //ＢＬコード(BL商品コード)
            if (paramWork.BLGoodsCode != 0)
            {
                // -- UPD 2009/09/04 ------------------------------------------->>>
                //retstring += " AND SALDTL.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                retstring += " AND SALSLP.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 -------------------------------------------<<<
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCode);
            }

            //品名(商品名称) ※あいまい検索あり
            if (paramWork.GoodsName != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsName, "(%)").Success == true)
                {
                    //あいまい検索
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                    retstring += " AND SALSLP.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                    // -- UPD 2009/09/04 ----------------------------------------<<<

                }
                else
                {
                    //あいまい検索じゃない
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
                    retstring += " AND SALSLP.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
                    // -- UPD 2009/09/04 ----------------------------------------<<<
                }
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(paramWork.GoodsName);
            }

            //品番(商品番号) ※あいまい検索あり
            if (paramWork.GoodsNo != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsNo, "(%)").Success == true)
                {
                    //あいまい検索
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    //retstring += " AND SALSLP.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;// DEL 2009/12/28
                    // -- UPD 2009/09/04 ----------------------------------------<<<
                    // -------------ADD 2009/12/28-------------->>>>>
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND SALSLP.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND SALSLP.GOODSNORF_NOHALF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    // -------------ADD 2009/12/28--------------<<<<<
                 }
                else
                {
                    //あいまい検索じゃない
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    //retstring += " AND SALSLP.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;// DEL 2009/12/28
                    // -- UPD 2009/09/04 ----------------------------------------<<<
                    // -------------ADD 2009/12/28-------------->>>>>
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND SALSLP.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND SALSLP.GOODSNORF_NOHALF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    // -------------ADD 2009/12/28--------------<<<<<

                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //メーカー(商品メーカーコード)
            if (paramWork.GoodsMakerCd != 0)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //販売区分コード
            if (paramWork.SalesCode != 0)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                retstring += " AND SALSLP.SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesCode);
            }

            //自社分類コード
            if (paramWork.EnterpriseGanreCode != 0)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;
                retstring += " AND SALSLP.ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(paramWork.EnterpriseGanreCode);
            }

            //在庫取寄区分(売上在庫取寄せ区分)
            if (paramWork.SalesOrderDivCd != -1)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.SALESORDERDIVCDRF=@FINDSALESORDERDIVCD" + Environment.NewLine;
                retstring += " AND SALSLP.SALESORDERDIVCDRF=@FINDSALESORDERDIVCD" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@FINDSALESORDERDIVCD", SqlDbType.Int);
                paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesOrderDivCd);
            }

            //倉庫コード
            if (paramWork.WarehouseCode != "")
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                retstring += " AND SALSLP.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }

            //仕入伝票番号
            if (paramWork.SupplierSlipNo != "")
            {
                retstring += " AND STCSLP.PARTYSALESLIPNUMRF=@FINDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.NVarChar);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNo);
            }

            //仕入先(仕入先コード)
            if (paramWork.SupplierCd != 0)
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                retstring += " AND SALSLP.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //発注先
            if (paramWork.UOESupplierCd != 0)
            {
                retstring += " AND UOEODR.SUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.UOESupplierCd);
            }


            //明細備考 ※あいまい検索あり
            if (paramWork.DtlNote != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.DtlNote, "(%)").Success == true)
                {
                    //あいまい検索
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.DTLNOTERF LIKE @FINDDTLNOTE" + Environment.NewLine;
                    retstring += " AND SALSLP.DTLNOTERF LIKE @FINDDTLNOTE" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                else
                {
                    //あいまい検索じゃない
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.DTLNOTERF=@FINDDTLNOTE" + Environment.NewLine;
                    retstring += " AND SALSLP.DTLNOTERF=@FINDDTLNOTE" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@FINDDTLNOTE", SqlDbType.NVarChar);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(paramWork.DtlNote);
            }

            //納品先コード
            if (paramWork.AddresseeCode != 0)
            {
                retstring += " AND SALSLP.ADDRESSEECODERF=@FINDADDRESSEECODE" + Environment.NewLine;
                SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@FINDADDRESSEECODE", SqlDbType.Int);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.AddresseeCode);
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            // 商品属性
            if ( paramWork.GoodsKindCode != -1 )
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSKINDCODERF=@FINDGOODSKINDCODE" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSKINDCODERF=@FINDGOODSKINDCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@FINDGOODSKINDCODE", SqlDbType.Int);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodsKindCode );
            }

            // 商品大分類コード
            if ( paramWork.GoodsLGroup != 0 )
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSLGROUPRF=@FINDGOODSLGROUP" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSLGROUPRF=@FINDGOODSLGROUP" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@FINDGOODSLGROUP", SqlDbType.Int);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodsLGroup );
            }

            // 商品中分類コード
            if ( paramWork.GoodsMGroup != 0 )
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodsMGroup );
            }
            
            // 棚番
            if ( paramWork.WarehouseShelfNo != string.Empty )
            {
                //あいまい検索かどうかをチェック
                if ( System.Text.RegularExpressions.Regex.Match( paramWork.WarehouseShelfNo, "(%)" ).Success == true )
                {
                    //あいまい検索
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.WAREHOUSESHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    retstring += " AND SALSLP.WAREHOUSESHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                else
                {
                    //あいまい検索じゃない
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.WAREHOUSESHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    retstring += " AND SALSLP.WAREHOUSESHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add( "@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar );
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString( paramWork.WarehouseShelfNo );
            }
            
            // 売上伝票区分(明細)
            switch(paramWork.SalesSlipCdDtl)
            {
                // 1:値引除く
                case 1:
                    {
                        // -- UPD 2009/09/04 -------------------------------------->>>
                        //retstring += " AND SALDTL.SALESSLIPCDDTLRF<>@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        retstring += " AND SALSLP.SALESSLIPCDDTLRF<>@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        // -- UPD 2009/09/04 --------------------------------------<<<
                        SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                        paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32( 2 );
                    }
                    break;
                // 2:値引のみ
                case 2:
                    {
                        // -- UPD 2009/09/04 -------------------------------------->>>
                        //retstring += " AND SALDTL.SALESSLIPCDDTLRF=@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        retstring += " AND SALSLP.SALESSLIPCDDTLRF=@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        // -- UPD 2009/09/04 --------------------------------------<<<
                        SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                        paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32( 2 );
                    }
                    break;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            //地区コード
            if (paramWork.SalesAreaCode != 0)
            {
                retstring += " AND CUSTOMER.SALESAREACODERF=@SALESAREACODE" + Environment.NewLine;
                SqlParameter salesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                salesAreaCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesAreaCode);
            }
            //分析コード1
            if (paramWork.CustAnalysCode1 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE1RF=@CUSTANALYSCODE1RF" + Environment.NewLine;
                SqlParameter custAnalysCode1RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE1RF", SqlDbType.Int);
                custAnalysCode1RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode1);
            }
            //分析コード2
            if (paramWork.CustAnalysCode2 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE2RF=@CUSTANALYSCODE2RF" + Environment.NewLine;
                SqlParameter custAnalysCode2RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE2RF", SqlDbType.Int);
                custAnalysCode2RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode2);
            }
            //分析コード3
            if (paramWork.CustAnalysCode3 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE3RF=@CUSTANALYSCODE3RF" + Environment.NewLine;
                SqlParameter custAnalysCode3RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE3RF", SqlDbType.Int);
                custAnalysCode3RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode3);
            }
            //分析コード4
            if (paramWork.CustAnalysCode4 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE4RF=@CUSTANALYSCODE4RF" + Environment.NewLine;
                SqlParameter custAnalysCode4RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE4RF", SqlDbType.Int);
                custAnalysCode4RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode4);
            }
            //分析コード5
            if (paramWork.CustAnalysCode5 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE5RF=@CUSTANALYSCODE5RF" + Environment.NewLine;
                SqlParameter custAnalysCode5RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE5RF", SqlDbType.Int);
                custAnalysCode5RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode5);
            }
            //分析コード6
            if (paramWork.CustAnalysCode6 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE6RF=@CUSTANALYSCODE6RF" + Environment.NewLine;
                SqlParameter custAnalysCode6RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE6RF", SqlDbType.Int);
                custAnalysCode6RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode6);
            }
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

           //----- ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応 ----->>>>>
            // 受注作成区分:通常受注伝票
            if (paramWork.AcptAnOdrMakeDiv == 2)
            {
                retstring += " AND SALSLP.ACPTANODRSTATUSRF = 20" + Environment.NewLine;
                retstring += " AND UOEODR.DATASENDCODERF IS NULL" + Environment.NewLine;
            }
            // 受注作成区分:伝発UOE受注伝票
            else if (paramWork.AcptAnOdrMakeDiv == 3)
            {
                retstring += " AND SALSLP.ACPTANODRSTATUSRF = 20" + Environment.NewLine;
                retstring += " AND UOEODR.DATASENDCODERF IS NOT NULL" + Environment.NewLine;
            }
            //----- ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応 -----<<<<<

            // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
            //出荷状況(計上残区分)
            if (paramWork.AddUpRemDiv != 0)
            {
                if (paramWork.AddUpRemDiv == 1)
                {   //残あり
                    retstring += " AND SALSLP.ACPTANODRREMAINCNTRF>0" + Environment.NewLine;
                }
                else if (paramWork.AddUpRemDiv == 2)
                {   //計上済み
                    retstring += " AND SALSLP.ACPTANODRREMAINCNTRF<=0" + Environment.NewLine;
                }
            }
            // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprSalTblRsltWork用 WHERE文生成処理 (仕入データSELECT用)]

        #region [CustPrtPprSalTblRsltWork用 WHERE文生成処理 (支払データSELECT用)]
        /// <summary>
        /// 伝票表示・明細表示のリスト抽出用WHERE句 生成処理 (支払データSELECT用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        private string MakeWhereString_DEPSMSUB(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " DEPSMSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND DEPSMSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND DEPSMSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
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
                    retstring += " AND DEPSMSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //得意先コード
            if (paramWork.CustomerCode != 0)
            {
                retstring += " AND DEPSMSUB.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
            }
            // ADD 2009.02.09 >>>
            //請求先コード
            if (paramWork.ClaimCode != 0)
            {
                retstring += " AND DEPSMSUB.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(paramWork.ClaimCode);
            }
            // ADD 2009.02.09 <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
            ////伝票日付(入金日付)
            //if (paramWork.St_SalesDate != DateTime.MinValue)
            //{
            //    retstring += " AND DEPSMSUB.DEPOSITDATERF>=@STDEPOSITDATE" + Environment.NewLine;
            //    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STDEPOSITDATE", SqlDbType.Int);
            //    paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_SalesDate);
            //}
            //if (paramWork.Ed_SalesDate != DateTime.MinValue)
            //{
            //    retstring += " AND DEPSMSUB.DEPOSITDATERF<=@EDDEPOSITDATE" + Environment.NewLine;
            //    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDDEPOSITDATE", SqlDbType.Int);
            //    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_SalesDate);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
            // 伝票日付(入金日付)→SalesDate:ADDUPADATERF
            if ( paramWork.St_SalesDate != DateTime.MinValue )
            {
                retstring += " AND DEPSMSUB.ADDUPADATERF>=@STADDUPADATE" + Environment.NewLine;
                SqlParameter paraStAddUpADate = sqlCommand.Parameters.Add( "@STADDUPADATE", SqlDbType.Int );
                paraStAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.St_SalesDate );
            }
            if ( paramWork.Ed_SalesDate != DateTime.MinValue )
            {
                retstring += " AND DEPSMSUB.ADDUPADATERF<=@EDADDUPADATE" + Environment.NewLine;
                SqlParameter paraEdAddUpADate = sqlCommand.Parameters.Add( "@EDADDUPADATE", SqlDbType.Int );
                paraEdAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.Ed_SalesDate );
            }
            // 入力日付→AddUpADate:DEPOSITDATERF // m.suzuki 2009/04/09 DEPOSITDATERF→INPUTDAYRF(追加項目)へ変更
            if ( paramWork.St_AddUpADate != DateTime.MinValue )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 DEL
                //retstring += " AND DEPSMSUB.DEPOSITDATERF>=@STDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                retstring += " AND DEPSMSUB.INPUTDAYRF>=@STDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                SqlParameter paraStDepositDate = sqlCommand.Parameters.Add( "@STDEPOSITDATE", SqlDbType.Int );
                paraStDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.St_AddUpADate );
            }
            if ( paramWork.Ed_AddUpADate != DateTime.MinValue )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 DEL
                //retstring += " AND DEPSMSUB.DEPOSITDATERF<=@EDDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                retstring += " AND DEPSMSUB.INPUTDAYRF<=@EDDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                SqlParameter paraEdDepositDate = sqlCommand.Parameters.Add( "@EDDEPOSITDATE", SqlDbType.Int );
                paraEdDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.Ed_AddUpADate );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
            ////受注ステータス
            //if (paramWork.AcptAnOdrStatus != null)
            //{
            //    string acptAnOdrStatusstr = "";
            //    foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
            //    {
            //        if (acptAnOdrStatusstr != "")
            //        {
            //            acptAnOdrStatusstr += ",";
            //        }
            //        acptAnOdrStatusstr += iacptSt.ToString();
            //    }
            //    if (acptAnOdrStatusstr != "")
            //    {
            //        retstring += " AND DEPSMSUB.ACPTANODRSTATUSRF IN (" + acptAnOdrStatusstr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL

            //担当者(入金担当者コード)
            if (paramWork.SalesEmployeeCd != "")
            {
                retstring += " AND DEPSMSUB.DEPOSITAGENTCODERF=@FINDDEPOSITAGENTCODE" + Environment.NewLine;
                SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDDEPOSITAGENTCODE", SqlDbType.NChar);
                paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
            }

            //備考１(伝票摘要) ※あいまい検索あり
            if (paramWork.SlipNote != "")
            {
                //あいまい検索かどうかをチェック
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote, "(%)").Success == true)
                {
                    //あいまい検索
                    retstring += " AND DEPSMSUB.OUTLINERF LIKE @FINDOUTLINE" + Environment.NewLine;
                }
                else
                {
                    //あいまい検索じゃない
                    retstring += " AND DEPSMSUB.OUTLINERF=@FINDOUTLINE" + Environment.NewLine;
                }
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@FINDOUTLINE", SqlDbType.NVarChar);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote);
            }

            //発行者(入金入力者コード)
            if (paramWork.SalesInputCode != "")
            {
                retstring += " AND DEPSMSUB.DEPOSITINPUTAGENTCDRF=@FINDDEPOSITINPUTAGENTCD" + Environment.NewLine;
                SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@FINDDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                paraSalesInputCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesInputCode);
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprSalTblRsltWork用 WHERE文生成処理 (支払データSELECT用)]
       
        
       //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
       #region [CustPrtPprSalTblRsltWork用 WHERE文生成処理 (入金データSELECT用)]
        /// <summary>
        /// 伝票表示・明細表示のリスト抽出用WHERE句 生成処理 (入金データSELECT用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paramWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>Where条件文字列</returns>        
        /// <br>Note		: メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>Programmer	: 鮑晶</br>
        /// <br>Date		: K2015/06/16</br>
        /// <br></br>
        private string MakeWhereString_DEPSM(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;
            
            //企業コード
            retstring += " DEPSM.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
            //地区コード
            if (paramWork.SalesAreaCode != 0)
            {
                retstring += " AND CUSTOMER.SALESAREACODERF=@SALESAREACODE" + Environment.NewLine;
                SqlParameter salesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                salesAreaCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesAreaCode);
            }
            //分析コード1
            if (paramWork.CustAnalysCode1 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE1RF=@CUSTANALYSCODE1RF" + Environment.NewLine;
                SqlParameter custAnalysCode1RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE1RF", SqlDbType.Int);
                custAnalysCode1RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode1);
            }
            //分析コード2
            if (paramWork.CustAnalysCode2 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE2RF=@CUSTANALYSCODE2RF" + Environment.NewLine;
                SqlParameter custAnalysCode2RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE2RF", SqlDbType.Int);
                custAnalysCode2RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode2);
            }
            //分析コード3
            if (paramWork.CustAnalysCode3 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE3RF=@CUSTANALYSCODE3RF" + Environment.NewLine;
                SqlParameter custAnalysCode3RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE3RF", SqlDbType.Int);
                custAnalysCode3RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode3);
            }
            //分析コード4
            if (paramWork.CustAnalysCode4 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE4RF=@CUSTANALYSCODE4RF" + Environment.NewLine;
                SqlParameter custAnalysCode4RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE4RF", SqlDbType.Int);
                custAnalysCode4RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode4);
            }
            //分析コード5
            if (paramWork.CustAnalysCode5 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE5RF=@CUSTANALYSCODE5RF" + Environment.NewLine;
                SqlParameter custAnalysCode5RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE5RF", SqlDbType.Int);
                custAnalysCode5RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode5);
            }
            //分析コード6
            if (paramWork.CustAnalysCode6 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE6RF=@CUSTANALYSCODE6RF" + Environment.NewLine;
                SqlParameter custAnalysCode6RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE6RF", SqlDbType.Int);
                custAnalysCode6RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode6);
            }
            return retstring;
            #endregion  
        }
        #endregion [CustPrtPprSalTblRsltWork用 WHERE文生成処理 (入金データSELECT用)]
        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

        #region [CustPrtPprSalTblRsltWork処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CustPrtPprSalTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprWork</param>
        /// <param name="iParam">検索タイプ 0:売上データ 1:入金データ</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam)
        {
            CustPrtPprWork _custPrtPprWork = paramWork as CustPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader, _custPrtPprWork, iParam);
        }
        #endregion  //[CustPrtPprSalTblRsltWork処理 呼出]

        #region [CustPrtPprSalTblRsltWork処理]
        /// <summary>
        /// クラス格納処理 Reader → SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprWork</param>
        /// <param name="iType">検索タイプ 0:売上データ 1:入金データ</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note : 2009/12/28 呉元嘯 PM.NS保守依頼④</br>
        /// <br>              変更前単価、原価の追加</br>
        /// <br>Update Note : 2010/01/29 楊明俊 4次改良</br>
        /// <br>              返品上限数、返品上限数存在フラグの追加</br>
        /// <br>Update Note : 2010/08/05 呉元嘯 障害・改良対応8月リリース分</br>
        /// <br>              変更前定価の追加</br>
        /// <br>Update Note : 2010/12/20 yangmj 計上元受注№・計上元貸出№の表示内容修正</br>
        /// <br>Update Note : 2011/11/28 楊洋 得意先電子元帳/(BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ)問合せ番号の追加</br>
        /// <br>Update Note : 2014/12/28 陳永康</br>
        /// <br>管理番号    : 11070263-00</br>
        /// <br>            : 変換後品番の追加対応(変換後品番)</br>
        /// <br>Update Note :  K2015/06/16 鮑晶 </br>
        /// <br>            :  メイゴ㈱の個別開発依頼 </br>
        /// <br>            :  得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>Update Note: 2015/02/05 王亜楠</br>
        /// <br>           : テキスト出力件数制限なしモードの追加</br>
        /// <br>Update Note :K2016/02/23 時シン</br>
        /// <br>             ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        private CustPrtPprSalTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CustPrtPprWork paramWork, int iType)
        {
            #region 抽出結果-値セット
            CustPrtPprSalTblRsltWork resultWork = new CustPrtPprSalTblRsltWork();

            if (iType == (int)iSrcType.SalTbl)
            {
                #region [売上データ]
                resultWork.DataDiv = 0;
                // -------------ADD 2009/12/28-------------->>>>>
                resultWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                resultWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                // -------------ADD 2009/12/28--------------<<<<<
                // -------------ADD 2010/08/05-------------->>>>>
                resultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                // -------------ADD 2010/08/05--------------<<<<<
                resultWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));// add 2011/07/18 zhubj
                
                //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
                resultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
                //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<
                
                resultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                resultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                resultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                resultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                resultWork.ChangeGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF")); //ADD 陳永康 2014/12/28 変換後品番の追加対応
                resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                resultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                resultWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));  //原価率 ADD 連番729 2011/08/18
                resultWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));  //売価率 ADD 連番729 2011/08/18
                resultWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));  //消費税率 // ADD 時シン 2020/03/11 PMKOBETSU-2912
                resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                resultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                resultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                resultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                resultWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
                resultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                resultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                resultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                resultWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                resultWork.ModelHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                //resultWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));// DEL 2010/01/12
                resultWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));// ADD 2010/01/12
                resultWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));
                resultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                resultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                resultWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                resultWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                resultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                resultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                resultWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                resultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                resultWork.ShipmSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPMSALESSLIPNUM"));
                resultWork.SrcSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCSALESSLIPNUM"));
                resultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                resultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCD"));
                resultWork.UOESupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERSNM"));
                resultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                resultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                resultWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                resultWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                resultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                resultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                resultWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
                resultWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                resultWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
                resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                resultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                resultWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
                resultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                resultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                // ADD 2008.12.09 >>>
                resultWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                resultWork.StockPartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKPARTYSALESLIPNUMRF"));
                // ADD 2008.12.09 <<<
                // ADD 2009.01.06 >>>
                resultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                resultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                resultWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                resultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                resultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));                    
                // ADD 2009.01.06 <<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
                //if (paramWork.AcptAnOdrStatus[0] != 30)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
                    resultWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF")); // ADD 2009.01.30

                if (resultWork.AcptAnOdrStatus != 40)
                {
                    resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                }
                else
                {
                    resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SEARCHSLIPDATERF" ) ); // 入力日
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) ); // 商品属性[明細]
                resultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSLGROUPRF" ) ); // 商品大分類コード[明細]
                resultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) ); // 商品中分類コード[明細]
                resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) ); // 倉庫棚番[明細]
                resultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) ); // 売上伝票区分（明細）[明細]
                resultWork.GoodsLGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSLGROUPNAMERF" ) ); // 商品大分類名称[明細]
                resultWork.GoodsMGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSMGROUPNAMERF" ) ); // 商品中分類名称[明細]
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                // ↓見出貼付用
                resultWork.CarMngNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) ); // 車両管理SEQ
                resultWork.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) ); // 車種メーカーコード
                resultWork.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) ); // 車種コード
                resultWork.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) ); // 車種サブコード
                resultWork.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) ); // エンジン型式名称
                resultWork.ColorCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) ); // カラーコード
                resultWork.TrimCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) ); // トリムコード
                resultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) ); // 納品区分
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  張莉莉 2009/09/07 ADD
                resultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF")); // 車両走行距離
                resultWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF")); // 車輌備考
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  張莉莉 2009/09/07 ADD
                // -------------ADD 2010/01/29 ---------->>>>>
                resultWork.Retuppercnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETUPPERCNTRF")); // 返品上限数
                resultWork.RetuppercntDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETUPPERCNTDIVRF")); // 返品上限数存在フラグ
                // -------------ADD 2010/01/29 ----------<<<<<
                try
                {
                    byte[] varbinary = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "FULLMODELFIXEDNOARYRF" ) ); // フル型式固定番号配列
                    resultWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof( int )];
                    for ( int idx = 0; idx < resultWork.FullModelFixedNoAry.Length; idx++ )
                    {
                        resultWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32( varbinary, idx * sizeof( int ) );
                    }
                }
                catch
                {
                    resultWork.FullModelFixedNoAry = new int[0];
                }

                // ------------- ADD 2010/04/27 ---------------->>>>>
                try
                {
                    resultWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF")); // 自由検索型式固定番号配列
                }
                catch
                {
                    resultWork.FreeSrchMdlFxdNoAry = new byte[0];
                }
                // ------------- ADD 2010/04/27 ----------------<<<<<

                try
                {
                    resultWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "CATEGORYOBJARYRF" ) ); // 装備オブジェクト配列
                }
                catch
                {
                    resultWork.CategoryObjAry = new byte[0];
                }
                resultWork.SalesInputCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) ); // 売上入力者コード（発行者）
                resultWork.FrontEmployeeCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) ); // 受付従業員コード（受注者）
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                // 履歴区分=0:通常
                resultWork.HistoryDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTORYDIVRF")); ;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                resultWork.UpdateDateTime = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) ); // 更新日時
                resultWork.UpdateDateTimeDetail = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIME")); // 更新日時  // ADD 2012/04/01 gezh Redmine#29250
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

                // --- ADD 2010/12/20 ---------->>>>>
                resultWork.HisDtlSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HISDTLSLIPNUMRF")); // 売上伝票番号
                resultWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF")); // 受注ステータス（元）
                // --- ADD 2010/12/20 ----------<<<<<

                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                resultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                resultWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                resultWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                resultWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                resultWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                resultWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                resultWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                #endregion

                // -- DEL 2009/09/04 ------------------------------>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                //// 売上履歴データ表示判定の為、退避
                //string key = CreateKeyString( resultWork.AcptAnOdrStatus, resultWork.SalesSlipNum, resultWork.SalesRowNo, resultWork.SalesDate );
                //if ( !_salesSlipHisKeyDic.ContainsKey( key ) )
                //{
                //    _salesSlipHisKeyDic.Add( key, string.Empty );
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // -- DEL 2009/09/04 ------------------------------<<<
            }
            #region [DEL 2009/09/04]
            // -- DEL 2009/09/04 ----------------------------->>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
            //else if ( iType == (int)iSrcType.SalHisTbl )
            //{
            //    # region [売上履歴データ表示判定処理]
            //    // 売上履歴データキー生成
            //    int acptAnOdrStatus = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
            //    string salesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
            //    int salesRowNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
            //    DateTime salesDate;
            //    if ( acptAnOdrStatus != 40 )
            //    {
            //        salesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
            //    }
            //    else
            //    {
            //        salesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SHIPMENTDAYRF" ) );
            //    }
            //    string key = CreateKeyString( acptAnOdrStatus, salesSlipNum, salesRowNo, salesDate );
            //    // 既存なら追加しない
            //    if ( _salesSlipHisKeyDic.ContainsKey( key ) )
            //    {
            //        return null;
            //    }
            //    # endregion

            //    # region [売上履歴データ]
            //    resultWork.DataDiv = 0;
            //    resultWork.SalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
            //    resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
            //    resultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
            //    resultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDRF" ) );
            //    resultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEENMRF" ) );
            //    resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXEXCRF" ) );
            //    resultWork.GoodsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );
            //    resultWork.GoodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );
            //    resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODERF" ) );
            //    resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGROUPCODERF" ) );
            //    resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SHIPMENTCNTRF" ) );
            //    resultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXEXCFLRF" ) );
            //    resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
            //    resultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXEXCFLRF" ) );
            //    resultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNITCOSTRF" ) );
            //    resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
            //    resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONSTAXLAYMETHODRF" ) );
            //    resultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXINCRF" ) );
            //    resultWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRICECONSTAXRF" ) );
            //    resultWork.TotalCost = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TOTALCOSTRF" ) );
            //    resultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELDESIGNATIONNORF" ) );
            //    resultWork.CategoryNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATEGORYNORF" ) );
            //    resultWork.ModelFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
            //    resultWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "FIRSTENTRYDATERF" ) );
            //    resultWork.SearchFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEARCHFRAMENORF" ) );
            //    resultWork.FullModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );
            //    resultWork.SlipNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) );
            //    resultWork.SlipNote2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE2RF" ) );
            //    resultWork.SlipNote3 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE3RF" ) );
            //    resultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEENMRF" ) );
            //    resultWork.SalesInputName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTNAMERF" ) );
            //    resultWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
            //    resultWork.CustomerSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
            //    resultWork.SupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
            //    resultWork.SupplierSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERSNMRF" ) );
            //    resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSALESLIPNUMRF" ) );
            //    resultWork.CarMngCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CARMNGCODERF" ) );
            //    resultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCEPTANORDERNORF" ) );
            //    resultWork.ShipmSalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIPMSALESSLIPNUM" ) );
            //    resultWork.SrcSalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SRCSALESSLIPNUM" ) );
            //    resultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESORDERDIVCDRF" ) );
            //    resultWork.WarehouseName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) );
            //    resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERSLIPNORF" ) );
            //    resultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "UOESUPPLIERCD" ) );
            //    resultWork.UOESupplierSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOESUPPLIERSNM" ) );
            //    resultWork.UoeRemark1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK1RF" ) );
            //    resultWork.UoeRemark2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK2RF" ) );
            //    resultWork.GuideName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GUIDENAMERF" ) );
            //    resultWork.SectionGuideNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONGUIDENMRF" ) );
            //    resultWork.DtlNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DTLNOTERF" ) );
            //    resultWork.ColorName1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORNAME1RF" ) );
            //    resultWork.TrimName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMNAMERF" ) );
            //    resultWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STDUNPRCLPRICERF" ) );
            //    resultWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STDUNPRCSALUNPRCRF" ) );
            //    resultWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STDUNPRCUNCSTRF" ) );
            //    resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );
            //    resultWork.MakerName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
            //    resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
            //    resultWork.Cost = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "COSTRF" ) );
            //    resultWork.CustSlipNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTSLIPNORF" ) );
            //    resultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
            //    resultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCRECDIVCDRF" ) );
            //    resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEBITNOTEDIVRF" ) );
            //    resultWork.SectionCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONCODERF" ) );
            //    resultWork.WarehouseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) );
            //    resultWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TOTALAMOUNTDISPWAYCDRF" ) );
            //    resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TAXATIONDIVCDRF" ) );
            //    resultWork.StockPartySaleSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKPARTYSALESLIPNUMRF" ) );
            //    resultWork.AddresseeCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDRESSEECODERF" ) );
            //    resultWork.AddresseeName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAMERF" ) );
            //    resultWork.AddresseeName2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAME2RF" ) );
            //    resultWork.FrameNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMENORF" ) );
            //    resultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ENTERPRISEGANRECODERF" ) );
            //    //resultWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "ACPTANODRREMAINCNTRF" ) );
            //    resultWork.AcptAnOdrRemainCnt = 0;
            //    if ( resultWork.AcptAnOdrStatus != 40 )
            //    {
            //        resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
            //    }
            //    else
            //    {
            //        resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SHIPMENTDAYRF" ) );
            //    }
            //    resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SEARCHSLIPDATERF" ) ); // 入力日
            //    resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) ); // 商品属性[明細]
            //    resultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSLGROUPRF" ) ); // 商品大分類コード[明細]
            //    resultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) ); // 商品中分類コード[明細]
            //    resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) ); // 倉庫棚番[明細]
            //    resultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) ); // 売上伝票区分（明細）[明細]
            //    resultWork.GoodsLGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSLGROUPNAMERF" ) ); // 商品大分類名称[明細]
            //    resultWork.GoodsMGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSMGROUPNAMERF" ) ); // 商品中分類名称[明細]
            //    // ↓見出貼付用
            //    resultWork.CarMngNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) ); // 車両管理SEQ
            //    resultWork.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) ); // 車種メーカーコード
            //    resultWork.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) ); // 車種コード
            //    resultWork.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) ); // 車種サブコード
            //    resultWork.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) ); // エンジン型式名称
            //    resultWork.ColorCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) ); // カラーコード
            //    resultWork.TrimCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) ); // トリムコード
            //    resultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) ); // 納品区分
            //    try
            //    {
            //        byte[] varbinary = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "FULLMODELFIXEDNOARYRF" ) ); // フル型式固定番号配列
            //        resultWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof( int )];
            //        for ( int idx = 0; idx < resultWork.FullModelFixedNoAry.Length; idx++ )
            //        {
            //            resultWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32( varbinary, idx * sizeof( int ) );
            //        }
            //    }
            //    catch
            //    {
            //        resultWork.FullModelFixedNoAry = new int[0];
            //    }

            //    try
            //    {
            //        resultWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "CATEGORYOBJARYRF" ) ); // 装備オブジェクト配列
            //    }
            //    catch
            //    {
            //        resultWork.CategoryObjAry = new byte[0];
            //    }
            //    resultWork.SalesInputCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) ); // 売上入力者コード（発行者）
            //    resultWork.FrontEmployeeCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) ); // 受付従業員コード（受注者）
            //    // 履歴区分=1:履歴
            //    resultWork.HistoryDiv = 1;
            //    # endregion
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
            // -- DEL 2009/09/04 -----------------------------<<<
            #endregion [2009/09/04]
            else if (iType == (int)iSrcType.DepTbl)
            {
                #region [入金データ]
                resultWork.DataDiv = 1;
                resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                Int32 iDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                resultWork.SalesSlipNum = iDepositSlipNo.ToString();
                resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
                resultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSPRICTOTAL"));
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                resultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                resultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                // 修正 2009.01.14 >>>
                //resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));                
                // 修正 2009.01.14 <<<
                Int32 iValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                resultWork.DtlNote = iValidityTerm.ToString();

                resultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                
                resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                resultWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                resultWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "INPUTDAYRF" ) ); // 入力日
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                // 履歴区分=0:通常
                resultWork.HistoryDiv = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                resultWork.UpdateDateTime = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) ); // 更新日時
                resultWork.UpdateDateTimeDetail = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIME")); // 更新日時  // ADD 2012/04/01 gezh Redmine#29250
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                resultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                resultWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                resultWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                resultWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                resultWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                resultWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                resultWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                #endregion  //[入金データ]
            }
            #endregion
            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            #region [テキスト出力用売上日]
            else if (iType == (int)iSrcType.SalDate)
            {
                resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATE"));
            }
            #endregion
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

            return resultWork;
        }
        #endregion  //[CustPrtPprSalTblRsltWork処理]
    }
}
