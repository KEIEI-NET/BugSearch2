//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上確認表
// プログラム概要   : 売上確認表アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 谷藤　範幸
// 作 成 日  2005/01/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/31  修正内容 : 消費税印字方法変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 障害対応10247,11302,10743,11402
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 消費税転嫁方式[伝票][明細]以外は非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/06/29  修正内容 : Mantis.15691　車種名の印字を車種全角名称から車種半角名称へ変更する。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30531 大矢 睦美
// 修 正 日  2010/07/14  修正内容 : Mantis【15806】　商品名称に商品名称カナをセットするよう修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 施健
// 修 正 日  2011/07/18  修正内容 : 明細に「自動回答」の追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 修 正 日  2011/11/29  修正内容 : 障害報告 #8076売上確認表/訂正伝票と削除伝票の区別についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 3H 尹安
// 修 正 日  2020/02/27  修正内容 : 11570208-00 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹 
// 修 正 日  2022/09/05  修正内容 : 11800255-00　インボイス対応（税率別合計金額不具合修正）
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 売上確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上確認表にアクセスするクラスです</br>
    /// <br>Programer  : 22021　谷藤　範幸</br>
    /// <br>Date       : 2005.01.23</br>
    /// <br>UpdateNote : 2008/10/31 照田 貴志　消費税印字方法変更</br>
    /// <br>UpdateNote : 2009/04/13 上野 俊治　障害対応10247,11302,10743,11402</br>
    /// <br>UpdateNote : 2009/04/14 上野 俊治　消費税転嫁方式[伝票][明細]以外は非表示に修正</br>
    /// <br>UpdateNote : 2010/07/14 大矢 睦美　Mantis【15806】品名が全角の場合、半角に変換する</br>
    /// <br>UpdateNote : 2020/02/27 3H 尹安 11570208-00 軽減税率対応</br>
    /// </remarks>
	public class SaleConfAcs
	{
  	    // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
	    #region public constant
	    /// <summary>全拠点レコード用拠点コード</summary>
        // 2008.07.07 30413 犬飼 拠点コードは2桁に変更 >>>>>>START
        //public const string CT_AllSectionCode = "000000";
        public const string CT_AllSectionCode = "00";
        // 2008.07.07 30413 犬飼 拠点コードは2桁に変更 <<<<<<END
        #endregion
    
	    // ===================================================================================== //
        //  スタティック変数
        // ===================================================================================== //
        #region static variable

        /// <summary>自拠点コード</summary>
        private static string mySectionCode               = "";

		/// <summary>帳票出力設定データクラス</summary>
		private static PrtOutSet prtOutSetData            = null;
		
	    #endregion

        // ===================================================================================== //
        //  内部使用変数
        // ===================================================================================== //
        #region private member

        private static SecInfoAcs _secInfoAcs;
        /// <summary>帳票出力設定アクセスクラス</summary>
	    private static PrtOutSetAcs prtOutSetAcs         = null;

        /// <summary>印刷用DataSet</summary>
		public DataSet _printDataSet;

        /// <summary>バッファDataSet</summary>
        public static DataSet _printBuffDataSet;

        /// <summary>売上順位表データテーブル名</summary>
        private string _SalesConfDataTable;

        // 帳票タイプ（合計 or 明細判定用）
        private int _printDiv;      //ADD 2008/10/31
        // --- ADD START 3H 尹安 2020/02/27---------->>>>>
        private int    _iTaxPrintDiv;  // 税別内訳印字有無区分
        private Double _taxRate1;      // 税率１
        private Double _taxRate2;      // 税率２
        // --- ADD END 3H 尹安 2020/02/27----------<<<<<

        // ↓ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>表示順位</summary>
        //private string CT_Sort1_Odr = "SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                               // 売上日→伝票番号
        //private string CT_Sort2_Odr = "SalesDateRF, CustomerCodeRF, SalesFormCodeRF, GoodsCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF"; // 売上日→得意先→販売形態→商品→伝票番号
        //private string CT_Sort3_Odr = "SalesDateRF, CustomerCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                               // 売上日→得意先→伝票番号
        //private string CT_Sort4_Odr = "SalesFormCodeRF, CustomerCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";              // 販売形態→得意先→売上日→伝票番号
        //private string CT_Sort5_Odr = "SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                                            // 伝票番号
        // ↑ 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 2008.07.07 30413 犬飼 不要プロパティの削除 >>>>>>START
        // ↓ 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private string CT_Sort1_Odr = "SalesDateRF, SalesSlipNumRF, SalesRowNoRF";                                               // 売上日+伝票番号
        //private string CT_Sort2_Odr = "CustomerCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF"; 　                            // 得意先+売上日+伝票番号
        //private string CT_Sort3_Odr = "SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";                                          // 入力日+伝票番号
        //private string CT_Sort4_Odr = "CustomerCodeRF, SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";                          // 得意先+入力日+伝票番号
        //private string CT_Sort5_Odr = "SalesEmployeeNmRF, SalesSlipNumRF, SalesRowNoRF";                                         // 担当者+伝票番号
        //private string CT_Sort6_Odr = "SalesAreaCodeRF, SalesSlipNumRF, SalesRowNoRF";                                           // 地区(販売エリア)+伝票番号
        // ↑ 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        

        //private string CT_UpperOrder = " ASC";   // 昇順出力
        // 2008.07.07 30413 犬飼 不要プロパティの削除 <<<<<<END
        //private string CT_DownOrder  = " DESC";  // 降順出力

        // 2009.02.03 30413 犬飼 カウント済みの伝票キーリストを追加 >>>>>>START
        /// <summary>カウント済みの伝票キーリスト</summary>
        private readonly IList<string> _countedSlipKeyList = new List<string>();
        /// <summary>
        /// カウント済みの伝票キーリストを取得します。
        /// </summary>
        /// <value>カウント済みの伝票キーリスト</value>
        private IList<string> CountedSlipKeyList
        {
            get { return _countedSlipKeyList; }
        }
        // 2009.02.03 30413 犬飼 カウント済みの伝票キーリストを追加 <<<<<<END
        
	    #endregion

        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
        /// <summary>カウント済みの非課税伝票キーリスト</summary>
        private readonly IList<string> _countedTaxFreeKeyList = new List<string>();
        /// <summary>
        /// カウント済みの非課税伝票キーリストを取得します。
        /// </summary>
        /// <value>カウント済みの非課税伝票キーリスト</value>
        private IList<string> CountedTaxFreeKeyList
        {
            get { return _countedTaxFreeKeyList; }
        }
        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant
	  
		///// <summary>売上順位表バッファデータテーブル名</summary>
        //public const string CT_SalesOrderBuffDataTable = Broadleaf.Application.UIData.MAHNB02349EA.CT_SalesOrderAgentBuffDataTable;
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        #endregion
        
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
		#region コンストラクター
       
		/// <summary>
        /// 売上順位表アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021 谷藤　範幸</br>
        /// <br>Date       : 2005.01.30</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public SaleConfAcs()
        {
            this.SettingDataTable();

            // 印刷用DataSet
		    this._printDataSet	= new DataSet();

            DataSetColumnConstruction(ref this._printDataSet);

            // バッファテーブルデータセット
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // 拠点情報取得
            this.CreateSecInfoAcs();
        }
        
		#endregion

        // ===================================================================================== //
        // 静的コンストラクタ
        // ===================================================================================== //
        #region 静的コンストラクター

		/// <summary>
        /// 売上順位表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021　谷藤　範幸</br>
        /// <br>Date       : 2006.01.31</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static SaleConfAcs()
        {
            // 帳票出力設定アクセスクラスインスタンス化
		    prtOutSetAcs       = new PrtOutSetAcs();

            // ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				mySectionCode = loginEmployee.BelongSectionCode;
		    }
	    }

        #endregion

        // ===================================================================================== //
        // 外部提供関数
        // ===================================================================================== //
        #region public method
		
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="prtOutSet">帳票出力設定データクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 22021 谷藤　範幸</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			// prtOutSet  = null;

            prtOutSet = new PrtOutSet();

			message = "";	
			try
			{
				// データは読込済みか？
				if (prtOutSetData != null)
				{
					prtOutSet = prtOutSetData.Clone(); 
					status    = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				} 
				else 
				{
					status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							prtOutSet = prtOutSetData.Clone();	
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
							prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
						default:
							prtOutSet = new PrtOutSet();
							message = "帳票出力設定の読込に失敗しました。";
							break;
					}
				}
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}

		/// <summary>
    	/// 売上順位表データ初期化処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static情報を初期化します。</br>
		/// <br>Programmer : 22021　谷藤　範幸</br>
		/// <br>Date       : 2006.01.31</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
     		// --テーブル行初期化-----------------------
			// 抽出結果データテーブルをクリア
			if(this._printDataSet.Tables[_SalesConfDataTable] != null)
			{
				this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();
			}

			// 抽出結果バッファデータテーブルをクリア
            if (_printBuffDataSet.Tables[_SalesConfDataTable] != null)
			{
                _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Clear();
			}
		}


        /// <summary>
        /// 売上順位表データ取得処理
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(saleConfListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(saleConfListCndtn, out message);
                        }
                        break;
                    }
                case 2:
                    {
                        // static only の場合はリモーティングに行かない
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }


        /// <summary>
        /// 売上順位表スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_SalesConfDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

        /// <summary>
        /// 売上順位表データ取得処理
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の売上チェックリストデータを取得します。</br>
        /// <br>Programmer : 22021　谷藤　範幸</br>
        /// <br>Date       : 2006.01.31</br>
        /// </remarks>
        public int Search(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
                SalesConfShWork salesConfShWork = new SalesConfShWork();

                // 抽出条件パラメータセット
                this.SearchParaSet(saleConfListCndtn, ref salesConfShWork);

                status = this.SearchByMode(out retObj, salesConfShWork);

                // 仮データ****************************
                // 情報取得
                //for (int i = 0; i < 10; i++)
                //{
                //dr = this._printDataSet.Tables[CT_SalesConfDataTable].NewRow();
                //
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SalesEmployeeCdRF] = "200";     // 販売従業員コード (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SalesEmployeeNmRF] = "飯谷耕平";     // 販売従業員名称 (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SectionCodeRF] = "KYOTEN";             // 拠点コード (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SectionGuideNmRF] = "第三開発課";       // 拠点ガイド名称 (string)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SalesCountTotal] = 100 * i + 1;       // 売上台数(集計) (Int32)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumSalesRF] = (100 * i + 1) * 1000;                   // 売上金額合計(集計) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumIncMoneyRF] = (100 * i + 1) * 700;             // INC金額合計(集計) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumMoneyRF] = (100 * i + 1) * 300;                // 総売上金額(集計) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumCostRF] = (100 * i + 1 )* 200;                     // 原価金額合計(集計) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumGrossProfitRF] = (100 * i + 1) * 100;       // 粗利金額合計(集計) (Int64)
                //    dr[MAHNB02349EA.CT_SalesOrderAgent_SumNwopCountRF] = (100 * i + 1) * 2;           // ネットワーク獲得数(集計) (int64) 

                //    //dr[SFURI06225EA.CT_CsSaleChkList_AddUpADateStr    ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.AddUpADate);  // 計上日付(印刷用)　(string)
                //    //dr[SFURI06225EA.CT_CsSaleChkList_PublicationStr   ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.Publication); // 売上日付(印刷用)　(string)
                //    //dr[SFURI06225EA.CT_CsSaleChkList_CorporateDivName ] = DivCdCnvStrDivNm((Int32)dr["CorporateDivCode"]); //個人・法人区分(印刷用)　(string)

                //    this._printDataSet.Tables[CT_SalesConfDataTable].Rows.Add(dr);
                //}
                //status = 0;
                // 仮データ**************************** end

                //return status;

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }

                    this._printDataSet.AcceptChanges();

                    // バッファテーブルへの格納
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }


        /// <summary>
        /// 売上順位表データ取得処理(伝票形式)
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の売上チェックリストデータを取得します。</br>
        /// <br>Programmer : 矢田 敬吾</br>
        /// <br>Date       : 2007.11.08</br>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        public int SearchSlipform(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                this._printDiv = 1;     //ADD 2008/10/31
                // --- ADD START 3H 尹安 2020/02/27---------->>>>>
                _iTaxPrintDiv = saleConfListCndtn.TaxPrintDiv;　　// 税別内訳印字有無区分
                _taxRate1     = 0;                                // 税率１
                _taxRate2     = 0;                                // 税率２
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(saleConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(saleConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H 尹安 2020/02/27----------<<<<<

                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
                SalesConfShWork salesConfShWork = new SalesConfShWork();

                // 抽出条件パラメータセット
                this.SearchParaSet(saleConfListCndtn, ref salesConfShWork);

                status = this.SearchByModeSlip(out retObj, salesConfShWork);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }

                    this._printDataSet.AcceptChanges();

                    // バッファテーブルへの格納
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    // 2009.02.13 30413 犬飼 エラーステータスを返却を修正 >>>>>>START
                    //status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    if (status == 0)
                    {
                        // 仮に抽出結果0件で、statusがゼロの場合
                        status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // 2009.02.13 30413 犬飼 エラーステータスを返却を修正 <<<<<<END
                }

            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// 売上順位表データ取得処理(明細、詳細形式)
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の売上チェックリストデータを取得します。</br>
        /// <br>Programmer : 矢田 敬吾</br>
        /// <br>Date       : 2007.11.08</br>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        public int SearchDetailform(ExtrInfo_MAHNB02347E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                this._printDiv = 2;     //ADD 2008/10/31
                // --- ADD START 3H 尹安 2020/02/27---------->>>>>
                _iTaxPrintDiv = saleConfListCndtn.TaxPrintDiv;　　// 税別内訳印字有無区分
                _taxRate1 = 0;                                    // 税率１
                _taxRate2 = 0;                                    // 税率２
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(saleConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(saleConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H 尹安 2020/02/27----------<<<<<

                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
                SalesConfShWork salesConfShWork = new SalesConfShWork();
                // 抽出条件パラメータセット
                this.SearchParaSet(saleConfListCndtn, ref salesConfShWork);

                status = this.SearchByModeDetail(out retObj, salesConfShWork);
  
                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);

                        // 売上伝票区分（明細）が3(注釈)は除く
                        if (dr[MAHNB02349EA.CT_Col_SalesSlipCdDtl].ToString() != "3") // ADD 2009/04/13
                        {
                            this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                        }
                    }

                    this._printDataSet.AcceptChanges();

                    // バッファテーブルへの格納
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    // 2009.02.13 30413 犬飼 エラーステータスを返却を修正 >>>>>>START
                    //status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    if (status == 0)
                    {
                        // 仮に抽出結果0件で、statusがゼロの場合
                        status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // 2009.02.13 30413 犬飼 エラーステータスを返却を修正 <<<<<<END
                }

            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

		#endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 検索パラメータ設定処理
        /// </summary>
        private void SearchParaSet(ExtrInfo_MAHNB02347E saleConfListCndtn, ref SalesConfShWork salesConfShWork)
        {
            salesConfShWork.EnterpriseCode = saleConfListCndtn.EnterpriseCode;         // 企業コード

            // 拠点
            if (saleConfListCndtn.ResultsAddUpSecList.Length != 0)
            {
                if (saleConfListCndtn.ResultsAddUpSecList[0] == "0")
                {
                    // 全社の時
                    salesConfShWork.ResultsAddUpSecList = new string[0];        // 拠点コード
                    // 2008.07.08 30413 犬飼 未定義のためコメント化 >>>>>>START
                    //salesConfShWork.IsOutputAllSecRec = true;
                    // 2008.07.08 30413 犬飼 未定義のためコメント化 <<<<<<END
                    salesConfShWork.IsSelectAllSection = true;
                }
                else
                {
                    salesConfShWork.ResultsAddUpSecList = saleConfListCndtn.ResultsAddUpSecList;     // 拠点コード
                    salesConfShWork.IsSelectAllSection = false;
                    // 2008.07.08 30413 犬飼 未定義のためコメント化 >>>>>>START
                    // 全拠点にチェックがつけられているかどうかのチェック
                    //if (_secInfoAcs.SecInfoSetList.Length == saleConfListCndtn.ResultsAddUpSecList.Length)
                    //{
                    //    salesConfShWork.IsOutputAllSecRec = true;
                    //}
                    //else
                    //{
                    //    salesConfShWork.IsOutputAllSecRec = false;
                    //}
                    // 2008.07.08 30413 犬飼 未定義のためコメント化 <<<<<<END
                }
            }
            else
            {
                salesConfShWork.ResultsAddUpSecList = new string[0];    // 拠点コード
                // 2008.07.08 30413 犬飼 未定義のためコメント化 >>>>>>START
                //salesConfShWork.IsOutputAllSecRec = true;               // 全拠点集計レコードでの出力
                // 2008.07.08 30413 犬飼 未定義のためコメント化 <<<<<<END
                salesConfShWork.IsSelectAllSection = false;
            }

            // 2008.07.07 30413 犬飼 発行タイプ、論理削除区を追加 >>>>>>START
            salesConfShWork.LogicalDeleteCode = saleConfListCndtn.LogicalDeleteCode;        // 論理削除区分
            // 2008.07.07 30413 犬飼 発行タイプ、論理削除区を追加 <<<<<<END
            
            // ↓ 2007.11.08 keigo yata Delete //////////////////////////////////////////////////////////////
            //salesConfShWork.IsDetails = saleConfListCndtn.IsDetails;                        // 出力単位
            // ↑ 2007.11.08 keigo yata Delete //////////////////////////////////////////////////////////////

            salesConfShWork.SalesDateSt = saleConfListCndtn.SalesDateSt;                    // 開始売上日
            salesConfShWork.SalesDateEd = saleConfListCndtn.SalesDateEd;                    // 終了売上日

            // ↓ 2007.11.08 keigo yata Change //////////////////////////////////////////////////////////////
            //salesConfShWork.ShipmentDaySt = saleConfListCndtn.ShipmentDaySt;              // 開始出荷日
            //salesConfShWork.ShipmentDayEd = saleConfListCndtn.ShipmentDayEd;              // 終了出荷日
            // ↑ 2007.11.08 keigo yata Change /////////////////////////////////////////////////////////////

            // 2008.07.08 30413 犬飼 入力日のプロパティ名称を変更 >>>>>>START
            // ↓ 2007.11.08 keigo yata Add ////////////////////////////////////////////////////////////////
            //salesConfShWork.SearchSlipDateSt = saleConfListCndtn.SearchSlipDataSt;          // 開始入力日
            //salesConfShWork.SearchSlipDateEd = saleConfListCndtn.SearchSlipDataEd;          // 終了入力日
            // ↑ 2007.11.08 keigo yata Add ////////////////////////////////////////////////////////////////
            salesConfShWork.SearchSlipDateSt = saleConfListCndtn.SearchSlipDateSt;          // 開始入力日
            salesConfShWork.SearchSlipDateEd = saleConfListCndtn.SearchSlipDateEd;          // 終了入力日
            // 2008.07.08 30413 犬飼 入力日のプロパティ名称を変更 >>>>>>START
            
            salesConfShWork.CustomerCodeSt = saleConfListCndtn.CustomerCodeSt;              // 開始得意先コード
            salesConfShWork.CustomerCodeEd = saleConfListCndtn.CustomerCodeEd;              // 終了得意先コード

            // 2008.07.07 30413 犬飼 仕入先を追加 >>>>>>START
            salesConfShWork.SupplierCdSt = saleConfListCndtn.SupplierCdSt;                  // 開始仕入先コード
            salesConfShWork.SupplierCdEd = saleConfListCndtn.SupplierCdEd;                  // 終了仕入先コード
            // 2008.07.07 30413 犬飼 仕入先を追加 <<<<<<END

            // ↓ 2007.11.08 keigo yata Delete /////////////////////////////////////////////////////////////////////////
            //salesConfShWork.LargeGoodsGanreCdSt = saleConfListCndtn.LargeGoodsGanreCdSt;    // 開始商品大分類コード
            //salesConfShWork.LargeGoodsGanreCdEd = saleConfListCndtn.LargeGoodsGanreCdEd;    // 終了商品大分類コード
            //salesConfShWork.MediumGoodsGanreCdSt = saleConfListCndtn.MediumGoodsGanreCdSt;  // 開始商品中分類コード
            //salesConfShWork.MediumGoodsGanreCdEd = saleConfListCndtn.MediumGoodsGanreCdEd;  // 終了商品中分類コード
            //salesConfShWork.CellphoneModelCodeSt = saleConfListCndtn.CellphoneModelCodeSt;  // 開始機種コード
            //salesConfShWork.CellphoneModelCodeEd = saleConfListCndtn.CellphoneModelCodeEd;  // 終了機種コード
            // ↑ 2007.11.08 keigo yata Delete /////////////////////////////////////////////////////////////////

            // ↓ 2007.11.08 keigo yata Change ////////////////////////////////////////////////////////////////
            //salesConfShWork.GoodsCodeSt = saleConfListCndtn.GoodsCodeSt;                  // 開始商品コード
            //salesConfShWork.GoodsCodeEd = saleConfListCndtn.GoodsCodeEd;                  // 終了商品コード
            // ↑ 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////

            salesConfShWork.DebitNoteDiv = saleConfListCndtn.DebitNoteDiv;                  // 赤伝区分
            salesConfShWork.SalesSlipCd = saleConfListCndtn.SalesSlipCd;                    // 伝票区分
            salesConfShWork.SalesSlipNumSt = saleConfListCndtn.SalesSlipNumSt;              // 開始売上伝票番号
            salesConfShWork.SalesSlipNumEd = saleConfListCndtn.SalesSlipNumEd;              // 終了売上伝票番号
            
            // ↓ 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////////
            salesConfShWork.SalesInputCodeSt = saleConfListCndtn.SalesInputCodeSt;          // 開始入力者コード
            salesConfShWork.SalesInputCodeEd = saleConfListCndtn.SalesInputCodeEd;          // 終了入力者コード           
            salesConfShWork.SalesEmployeeCdSt = saleConfListCndtn.SalesEmployeeCdSt;        // 開始担当コード
            salesConfShWork.SalesEmployeeCdEd = saleConfListCndtn.SalesEmployeeCdEd;        // 終了担当コード
            // 2008.07.15 30413 犬飼 受付従業員コードを追加 >>>>>>START
            salesConfShWork.FrontEmployeeCdSt = saleConfListCndtn.FrontEmployeeCdSt;        // 開始受付従業員コード
            salesConfShWork.FrontEmployeeCdSt = saleConfListCndtn.FrontEmployeeCdSt;        // 開始受付従業員コード
            // 2008.07.15 30413 犬飼 受付従業員コードを追加 <<<<<<END
            // 2008.07.07 30413 犬飼 地区、業種を追加 >>>>>>START
            salesConfShWork.SalesAreaCodeSt = saleConfListCndtn.SalesAreaCodeSt;            // 開始地区コード
            salesConfShWork.SalesAreaCodeEd = saleConfListCndtn.SalesAreaCodeEd;            // 終了地区コード
            salesConfShWork.BusinessTypeCodeSt = saleConfListCndtn.BusinessTypeCodeSt;      // 開始業種コード
            salesConfShWork.BusinessTypeCodeEd = saleConfListCndtn.BusinessTypeCodeEd;      // 終了業種コード
            // 2008.07.07 30413 犬飼 地区、業種を追加 <<<<<<END
            // 2008.07.07 30413 犬飼 発行タイプ、出力指定を追加 >>>>>>START
            salesConfShWork.SalesSlipUpdateCd = saleConfListCndtn.SalesSlipUpdateCd;        // 売上伝票更新区分
            salesConfShWork.SalesOrderDivCd = saleConfListCndtn.SalesOrderDivCd;            // 売上在庫取寄せ区分
            salesConfShWork.WayToOrder = saleConfListCndtn.WayToOrder;                      // 注文方法
            // 2008.07.07 30413 犬飼 発行タイプ、出力指定を追加 <<<<<<END
            salesConfShWork.GrsProfitCheckLower = saleConfListCndtn.GrsProfitCheckLower;    // 粗利下限チェック
            salesConfShWork.GrsProfitCheckBest = saleConfListCndtn.GrsProfitCheckBest;      // 粗利適正チェック
            salesConfShWork.GrsProfitCheckUpper = saleConfListCndtn.GrsProfitCheckUpper;    // 粗利上限チェック
            salesConfShWork.GrossMargin1Mark = saleConfListCndtn.GrossMargin1Mark;          // 粗利チェックマーク1           
            salesConfShWork.GrossMargin2Mark = saleConfListCndtn.GrossMargin2Mark;          // 粗利チェックマーク2
            salesConfShWork.GrossMargin3Mark = saleConfListCndtn.GrossMargin3Mark;          // 粗利チェックマーク3
            salesConfShWork.GrossMargin4Mark = saleConfListCndtn.GrossMargin4Mark;          // 粗利チェックマーク4
            // ↑ 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////////

            // 2008.07.15 30413 犬飼 印字プロパティを追加 >>>>>>START
            salesConfShWork.ZeroSalesPrint = saleConfListCndtn.ZeroSalesPrint;                  // 売価ゼロのみ印字
            salesConfShWork.ZeroCostPrint = saleConfListCndtn.ZeroCostPrint;                    // 原価ゼロのみ印字
            salesConfShWork.ZeroGrsProfitPrint = saleConfListCndtn.ZeroGrsProfitPrint;          // 粗利ゼロのみ印字
            salesConfShWork.ZeroUdrGrsProfitPrint = saleConfListCndtn.ZeroUdrGrsProfitPrint;    // 粗利ゼロ以下のみ印字
            salesConfShWork.GrsProfitRatePrint = saleConfListCndtn.GrsProfitRatePrint;          // 粗利率印字
            salesConfShWork.GrsProfitRatePrintVal = saleConfListCndtn.GrsProfitRatePrintVal;    // 粗利率印字値
            salesConfShWork.GrsProfitRatePrintDiv = saleConfListCndtn.GrsProfitRatePrintDiv;    // 粗利率印字区分
            // 2008.07.15 30413 犬飼 印字プロパティを追加 <<<<<<END
            

            // ↓ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////
            //// キャリア
            //if (saleConfListCndtn.CarrierCodeList.Length != 0)
            //{
            //    if (saleConfListCndtn.CarrierCodeList[0] == 0)
            //    {
            //        // 全ての時
            //        salesConfShWork.CarrierCodeList = new int[0];  // 対象キャリア
            //        salesConfShWork.IsSelectAllCarrier = true;     // 全キャリア集計レコードでの出力
            //    }
            //    else
            //    {
            //        salesConfShWork.CarrierCodeList = saleConfListCndtn.CarrierCodeList;  // 対象キャリア
            //        salesConfShWork.IsSelectAllCarrier = false;    // 各キャリアレコードでの出力
            //    }
            //}
            //else
            //{
            //    salesConfShWork.CarrierCodeList = new int[0];  // 対象キャリア
            //    salesConfShWork.IsOutputAllSecRec = true;      // 全キャリア集計レコードでの出力
            //}

            // 売上形式
            //if (saleConfListCndtn.SalesFormal.Length != 0)
            //{
            //    if (saleConfListCndtn.SalesFormal[0] == 0)
            //    {
            //        // 全ての時
            //        salesConfShWork.SalesFormal = new int[0];  // 対象売上形式
            //    }
            //    else
            //    {
            //        salesConfShWork.SalesFormal = saleConfListCndtn.SalesFormal;  // 対象売上形式
            //    }
            //}
            //else
            //{
            //    salesConfShWork.SalesFormal = new int[0];  // 対象売上形式
            //}

            // 販売形態
            //if (saleConfListCndtn.SalesFormCodeList.Length != 0)
            //{
            //    if (saleConfListCndtn.SalesFormCodeList[0] == 0)
            //    {
            //        // 全ての時
            //        salesConfShWork.SalesFormCode = new int[0];  // 対象売上形式
            //    }
            //    else
            //    {
            //        salesConfShWork.SalesFormCode = saleConfListCndtn.SalesFormCodeList;  // 対象売上形式
            //    }
            //}
            //else
            //{
            //    salesConfShWork.SalesFormCode = new int[0];  // 対象売上形式
            //}
            // ↑ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
		{
			// 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.MAHNB02349EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// モード毎のSearch呼出処理
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="salesConfShWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
        private int SearchByMode(out object retObj, SalesConfShWork salesConfShWork)
        {
            int status = 0;

            retObj = null;

            ISalesConfDB _iSalesConfDB = (ISalesConfDB)MediationSalesConfDB.GetSalesConfDB();

            status = _iSalesConfDB.SearchSlip(out retObj, salesConfShWork);

            return status;
        }

        // ↓ 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// モード毎のSearch呼出処理
        /// 伝票形式で出力するためのSearchSlipメソッドの呼び出し
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="salesConfShWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
        private int SearchByModeSlip(out object retObj, SalesConfShWork salesConfShWork)
        {
            int status = 0;

            retObj = null;

            ISalesConfDB _iSalesConfDB = (ISalesConfDB)MediationSalesConfDB.GetSalesConfDB();
            
            status = _iSalesConfDB.SearchSlip(out retObj, salesConfShWork);
            
            return status;
        }
        
        /// <summary>
        /// モード毎のSearch呼出処理
        /// 明細、詳細形式で出力するためのSearchDetailメソッドの呼び出し
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="salesConfShWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
        private int SearchByModeDetail(out object retObj, SalesConfShWork salesConfShWork)
        {
            int status = 0;

            retObj = null;

            ISalesConfDB _iSalesConfDB = (ISalesConfDB)MediationSalesConfDB.GetSalesConfDB();


            status = _iSalesConfDB.SearchDetail(out retObj, salesConfShWork);


            return status;
        }
        // ↑ 2007.11.08 keigo yata Add ///////////////////////////////////////////////////////////////////////

        // ↓ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// 印字順クエリ作成処理
        ///// </summary>
        ///// <returns>作成したクエリ</returns>
        ///// <remarks>
        ///// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2005.12.06</br>
        ///// </remarks>
        //private string GetPrintOderQuerry(ExtrInfo_MAHNB02347E saleConfListCndtn)
        //{
        //    string orderQuerry = "";

        //    // ソート順設定
        //    switch (saleConfListCndtn.SortOrder)
        //    {
        //        case 0:
        //            {
        //                // 売上台数
        //                orderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 1:
        //            {
        //                // 売上金額合計
        //                orderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
        //                // 総売上金額
        //                orderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
        //                // 粗利金額合計
        //                orderQuerry = CT_Sort4_Odr;
        //                break;
        //            }
        //        case 4:
        //            {
        //                // ﾈｯﾄﾜｰｸ獲得数
        //                orderQuerry = CT_Sort5_Odr;
        //                break;
        //            }

        //    }

        //    // 昇順固定
        //    orderQuerry += CT_UpperOrder; 

        //    return orderQuerry;
        //}
        // ↑ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////

        // 2008.07.25 30413 犬飼 不要メソッドの削除 >>>>>>START
        #region 不要メソッドの削除
        //// ↓ 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////
        ///// <summary>
        ///// 印字順クエリ作成処理
        ///// </summary>
        ///// <returns>作成したクエリ</returns>
        ///// <remarks>
        ///// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        ///// <br>Programmer : 矢田 敬吾</br>
        ///// <br>Date       : 2007.11.08</br>
        ///// </remarks>
        //private string GetPrintOderQuerry(ExtrInfo_MAHNB02347E saleConfListCndtn)
        //{
        //    string orderQuerry = "";

        //    // ソート順設定
        //    switch (saleConfListCndtn.SortOrder)
        //    {
        //        case 0:
        //            {
                        
        //                orderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 1:
        //            {
                        
        //                orderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
                        
        //                orderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
                        
        //                orderQuerry = CT_Sort4_Odr;
        //                break;
        //            }
        //        case 4:
        //            {
                        
        //                orderQuerry = CT_Sort5_Odr;
        //                break;
        //            }
        //        case 5:
        //            {
        //                orderQuerry = CT_Sort6_Odr;
        //                break;
        //            }
        //    }

        //    // 昇順固定
        //    orderQuerry += CT_UpperOrder;

        //    return orderQuerry;
        //}
        //// ↑ 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////
        #endregion
        // 2008.07.25 30413 犬飼 不要メソッドの削除 <<<<<<END
        
        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            this._SalesConfDataTable = Broadleaf.Application.UIData.MAHNB02349EA.CT_SalesConfDataTable;
        }


        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        {
            // ↓ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////
            //Int64 salesMoney = 0;
            //Int64 cost = 0;
            //double GrossMarginRate = 0.0;
            // ↑ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////

            // 明細単位
            SalesConfWork saleConfWork = (SalesConfWork)retList[setCnt];

            // 2008.07.08 30413 犬飼 Row項目の全置き換え >>>>>>START
            dr[MAHNB02349EA.CT_Col_SectionCode] = saleConfWork.SectionCode;                     // 拠点コード (string)
            dr[MAHNB02349EA.CT_Col_SectionGuideNm] = saleConfWork.SectionGuideNm;               // 拠点ガイド名称 (string)
            dr[MAHNB02349EA.CT_Col_SubSectionCode] = saleConfWork.SubSectionCode;               // 部門コード (Int32)
            dr[MAHNB02349EA.CT_Col_SubSectionName] = saleConfWork.SubSectionName;               // 部門名称 (string)
            dr[MAHNB02349EA.CT_Col_SalesSlipNum] = saleConfWork.SalesSlipNum;                   // 売上伝票番号 (string)
            dr[MAHNB02349EA.CT_Col_ClaimCode] = saleConfWork.ClaimCode;                         // 請求先コード (Int32)
            dr[MAHNB02349EA.CT_Col_ClaimSnm] = saleConfWork.ClaimSnm;                           // 請求先略称 (string)
            dr[MAHNB02349EA.CT_Col_CustomerCode] = saleConfWork.CustomerCode;                   // 得意先コード (Int32)
            dr[MAHNB02349EA.CT_Col_CustomerSnm] = saleConfWork.CustomerSnm;                     // 得意先略称 (string)
            dr[MAHNB02349EA.CT_Col_ShipmentDay] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.ShipmentDay);                     // 出荷日付 (DateTime)
            dr[MAHNB02349EA.CT_Col_SalesDate] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.SalesDate);                         // 売上日付 (DateTime)
            dr[MAHNB02349EA.CT_Col_AddUpADate] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.AddUpADate);                       // 計上日付 (Int32)
            dr[MAHNB02349EA.CT_Col_SalesSlipCd] = saleConfWork.SalesSlipCd;                     // 売上伝票区分 (Int32)
            dr[MAHNB02349EA.CT_Col_AccRecDivCd] = saleConfWork.AccRecDivCd;                     // 売掛区分 (Int32)
            dr[MAHNB02349EA.CT_Col_SalesInputCode] = saleConfWork.SalesInputCode;               // 売上入力者コード (string)
            dr[MAHNB02349EA.CT_Col_SalesInputName] = saleConfWork.SalesInputName;               // 売上入力者名称 (string)
            dr[MAHNB02349EA.CT_Col_FrontEmployeeCd] = saleConfWork.FrontEmployeeCd;             // 受付従業員コード (string)
            dr[MAHNB02349EA.CT_Col_FrontEmployeeNm] = saleConfWork.FrontEmployeeNm;             // 受付従業員名称 (string)
            dr[MAHNB02349EA.CT_Col_SalesEmployeeCd] = saleConfWork.SalesEmployeeCd;             // 販売従業員コード (string)
            dr[MAHNB02349EA.CT_Col_SalesEmployeeNm] = saleConfWork.SalesEmployeeNm;             // 販売従業員名称 (string)
            dr[MAHNB02349EA.CT_Col_PartySaleSlipNum] = saleConfWork.PartySaleSlipNum;           // 相手先伝票番号 (string)
            dr[MAHNB02349EA.CT_Col_SalesTotalTaxInc] = saleConfWork.SalesTotalTaxInc;           // 売上伝票合計（税込み） (Int64)
            dr[MAHNB02349EA.CT_Col_SalesTotalTaxExc] = saleConfWork.SalesTotalTaxExc;           // 売上伝票合計（税抜き） (Int64)
            dr[MAHNB02349EA.CT_Col_TotalCost] = saleConfWork.TotalCost;                         // 原価金額計 (Int64)
            //dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv;         // 返品理由コード (Int32)
            //dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // 返品理由 (string)
            // 返品理由コードと返品理由は一度空白で設定
            dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = "";                                     // 返品理由コード (Int32)
            dr[MAHNB02349EA.CT_Col_RetGoodsReason] = "";                                        // 返品理由 (string)
            //dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo;                       // 得意先伝票番号 (Int32)
            // 得意先伝票番号は一度空白で設定
            dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";                                            // 得意先伝票番号 (Int32)
            dr[MAHNB02349EA.CT_Col_SlipNote] = saleConfWork.SlipNote;                           // 伝票備考 (string)
            dr[MAHNB02349EA.CT_Col_SlipNote2] = saleConfWork.SlipNote2;                         // 伝票備考２ (string)
            dr[MAHNB02349EA.CT_Col_SlipNote3] = saleConfWork.SlipNote3;                         // 伝票備考３ (string)
            dr[MAHNB02349EA.CT_Col_BusinessTypeCode] = saleConfWork.BusinessTypeCode;           // 業種コード (Int32)
            dr[MAHNB02349EA.CT_Col_BusinessTypeName] = saleConfWork.BusinessTypeName;           // 業種名称 (string)
            dr[MAHNB02349EA.CT_Col_SalesAreaCode] = saleConfWork.SalesAreaCode;                 // 販売エリアコード (Int32)
            dr[MAHNB02349EA.CT_Col_SalesAreaName] = saleConfWork.SalesAreaName;                 // 販売エリア名称 (string)
            //dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // ＵＯＥリマーク１ (string)
            //dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // ＵＯＥリマーク２ (string)
            dr[MAHNB02349EA.CT_Col_GoodsNo] = saleConfWork.GoodsNo;                             // 商品番号 (string)
            // --- UPD  大矢睦美  2010/07/14 ---------->>>>>
            dr[MAHNB02349EA.CT_Col_GoodsName] = saleConfWork.GoodsName;                         // 商品名称 (string)
            dr[MAHNB02349EA.CT_Col_GoodsNameKana] = saleConfWork.GoodsNameKana;                       // 商品名称カナ (string)
            // --- UPD  大矢睦美  2010/07/14 ----------<<<<<
            // --- ADD  施健  2011/07/18 ---------->>>>>
            // 0:通常(PCC連携なし)
            if (saleConfWork.AutoAnswerDivSCM == 0)
            {
                dr[MAHNB02349EA.CT_AutoAnswer] = "通常";                       // 通常発行マーク
            }
            // 1:手動回答
            else if(saleConfWork.AutoAnswerDivSCM == 1)
            {
                dr[MAHNB02349EA.CT_AutoAnswer] = "手動回答";                       // SCM手動回答マーク
            }
            // 2:自動回答
            else if (saleConfWork.AutoAnswerDivSCM == 2)
            {
                dr[MAHNB02349EA.CT_AutoAnswer] = "自動回答";                       // SCM自動回答マーク
            }
            // --- ADD  施健  2011/07/18 ----------<<<<<
            //dr[MAHNB02349EA.CT_Col_BLGoodsCode] = saleConfWork.BLGoodsCode;                     // BL商品コード (Int32)
            if (saleConfWork.BLGoodsCode == 0)
            {
                dr[MAHNB02349EA.CT_Col_BLGoodsCode] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_BLGoodsCode] = saleConfWork.BLGoodsCode.ToString("d05");                     // BL商品コード (Int32)
            }
            dr[MAHNB02349EA.CT_Col_BLGoodsFullName] = saleConfWork.BLGoodsFullName;             // BL商品コード名称（全角） (string)
            dr[MAHNB02349EA.CT_Col_SalesOrderDivCd] = saleConfWork.SalesOrderDivCd;             // 売上在庫取寄せ区分 (Int32)
            dr[MAHNB02349EA.CT_Col_ListPriceTaxIncFl] = saleConfWork.ListPriceTaxIncFl;         // 定価（税込，浮動） (Double)
            dr[MAHNB02349EA.CT_Col_ListPriceTaxExcFl] = saleConfWork.ListPriceTaxExcFl;         // 定価（税抜，浮動） (Double)
            dr[MAHNB02349EA.CT_Col_SalesRate] = saleConfWork.SalesRate;                         // 売価率 (Double)
            dr[MAHNB02349EA.CT_Col_ShipmentCnt] = saleConfWork.ShipmentCnt;                     // 出荷数 (Double)
            dr[MAHNB02349EA.CT_Col_SalesUnitCost] = saleConfWork.SalesUnitCost;                 // 原価単価 (Double)
            dr[MAHNB02349EA.CT_Col_SalesUnPrcTaxIncFl] = saleConfWork.SalesUnPrcTaxIncFl;       // 売上単価（税込，浮動） (Double)
            dr[MAHNB02349EA.CT_Col_SalesUnPrcTaxExcFl] = saleConfWork.SalesUnPrcTaxExcFl;       // 売上単価（税抜，浮動） (Double)
            dr[MAHNB02349EA.CT_Col_Cost] = saleConfWork.Cost;                                   // 原価 (Int64)
            dr[MAHNB02349EA.CT_Col_SalesMoneyTaxInc] = saleConfWork.SalesMoneyTaxInc;           // 売上金額（税込み） (Int64)
            dr[MAHNB02349EA.CT_Col_SalesMoneyTaxExc] = saleConfWork.SalesMoneyTaxExc;           // 売上金額（税抜き） (Int64)
            //dr[MAHNB02349EA.CT_Col_SupplierCd] = saleConfWork.SupplierCd;                       // 仕入先コード (Int32)
            if (saleConfWork.SupplierCd == 0)
            {
                dr[MAHNB02349EA.CT_Col_SupplierCd] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_SupplierCd] = saleConfWork.SupplierCd.ToString("d06");                       // 仕入先コード (Int32)
            }
            dr[MAHNB02349EA.CT_Col_SupplierSnm] = saleConfWork.SupplierSnm;                     // 仕入先略称 (string)
            //dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = saleConfWork.SupplierSlipNo;               // 仕入伝票番号 (Int32)
            // 2009.03.12 30413 犬飼 仕入伝票番号に相手先伝票番号を設定するように修正 >>>>>>START
            //if (saleConfWork.SupplierSlipNo == 0)
            if (string.IsNullOrEmpty(saleConfWork.PartySaleSlipNumStock))
            {
                dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = "";
            }
            else
            {
                //dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = saleConfWork.SupplierSlipNo.ToString();               // 仕入伝票番号 (Int32)
                dr[MAHNB02349EA.CT_Col_SupplierSlipNo] = saleConfWork.PartySaleSlipNumStock;                    // 相手先伝票番号 (string)
            }
            // 2009.03.12 30413 犬飼 仕入伝票番号に相手先伝票番号を設定するように修正 <<<<<<END
            dr[MAHNB02349EA.CT_Col_WarehouseCode] = saleConfWork.WarehouseCode;                 // 倉庫コード (string)
            dr[MAHNB02349EA.CT_Col_WarehouseName] = saleConfWork.WarehouseName;                 // 倉庫名称 (string)
            dr[MAHNB02349EA.CT_Col_WarehouseShelfNo] = saleConfWork.WarehouseShelfNo;           // 倉庫棚番 (string)
            //dr[MAHNB02349EA.CT_Col_SalesCode] = saleConfWork.SalesCode;                         // 販売区分コード (Int32)
            if (saleConfWork.SalesCode == 0)
            {
                dr[MAHNB02349EA.CT_Col_SalesCode] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_SalesCode] = saleConfWork.SalesCode.ToString("d04");                         // 販売区分コード (Int32)
            }
            dr[MAHNB02349EA.CT_Col_SalesCdNm] = saleConfWork.SalesCdNm;                         // 販売区分名称 (string)
            dr[MAHNB02349EA.CT_Col_ModelFullName] = saleConfWork.ModelFullName;                 // 車種全角名称 (string)
            dr[MAHNB02349EA.CT_Col_FullModel] = saleConfWork.FullModel;                         // 型式（フル型） (string)
            dr[MAHNB02349EA.CT_Col_ModelDesignationNo] = saleConfWork.ModelDesignationNo;       // 型式指定番号 (Int32)
            dr[MAHNB02349EA.CT_Col_CategoryNo] = saleConfWork.CategoryNo;                       // 類別番号 (Int32)
            dr[MAHNB02349EA.CT_Col_CarMngCode] = saleConfWork.CarMngCode;                       // 車輌管理コード (string)
            dr[MAHNB02349EA.CT_Col_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", saleConfWork.FirstEntryDate);               // 初年度 (string)
            dr[MAHNB02349EA.CT_Col_TransactionName] = saleConfWork.TransactionName;             // 取引区分名[伝票] (string)
            dr[MAHNB02349EA.CT_Col_GrossMarginRate] = saleConfWork.GrossMarginRate;             // 粗利率[伝票] (Double)
            dr[MAHNB02349EA.CT_Col_GrossMarginMarkSlip] = saleConfWork.GrossMarginMarkSlip;     // 粗利チェックマーク[伝票] (string)
            dr[MAHNB02349EA.CT_Col_GrossMarginRateDtl] = saleConfWork.GrossMarginRateDtl;       // 粗利率[明細] (Double)
            dr[MAHNB02349EA.CT_Col_GrossMarginMarkDtl] = saleConfWork.GrossMarginMarkDtl;       // 粗利チェックマーク[明細] (string)
            dr[MAHNB02349EA.CT_Col_SalesSlipCdDtl] = saleConfWork.SalesSlipCdDtl;               // 売上伝票区分（明細） (Int32)
            dr[MAHNB02349EA.CT_Col_SalesDisTtlTaxExc] = saleConfWork.SalesDisTtlTaxExc;         // 売上値引金額計（税抜き） (Int64)
            dr[MAHNB02349EA.CT_Col_SearchSlipDate] = TDateTime.DateTimeToString(ExtrInfo_MAHNB02347E.ct_DateFomat, saleConfWork.SearchSlipDate);         // 伝票検索日付(入力日付)   (DateTime)

            // 伝票タイプの印字用日付
            dr[MAHNB02349EA.CT_Col_SalesDateY2] = TDateTime.DateTimeToString("YY/MM/DD", saleConfWork.SalesDate);                         // 売上日付 (DateTime)
            dr[MAHNB02349EA.CT_Col_AddUpADateY2] = TDateTime.DateTimeToString("YY/MM/DD", saleConfWork.AddUpADate);                       // 計上日付 (Int32)
            dr[MAHNB02349EA.CT_Col_SearchSlipDateY2] = TDateTime.DateTimeToString("YY/MM/DD", saleConfWork.SearchSlipDate);         // 伝票検索日付(入力日付)   (DateTime)


            // 売上伝票区分名称の設定
            dr[MAHNB02349EA.CT_Col_SalesSlipName] = saleConfWork.TransactionName;       // 取引区分名[伝票]でOK？

            dr[MAHNB02349EA.CT_COL_LOGICALDELETECODE] = saleConfWork.LogicalDeleteCode == 0 ? "" : "削除"; // --- ADD  陳建明  2010/11/29
            
            // 類別(明細)の設定
            if ((saleConfWork.ModelDesignationNo == 0) && (saleConfWork.CategoryNo == 0))
            {
                // 型式指定番号と類別番号が未設定の場合は、類別は設定しない
                dr[MAHNB02349EA.CT_Col_CategoryDtl] = "";
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_CategoryDtl] = saleConfWork.ModelDesignationNo.ToString("d05") + "-" + saleConfWork.CategoryNo.ToString("d04");
            }

            // 売上在庫取寄せ区分名称の設定
            if (saleConfWork.SalesOrderDivCd == 0)
            {
                dr[MAHNB02349EA.CT_Col_SalesOrderDivName] = "取寄";
            }
            else if (saleConfWork.SalesOrderDivCd == 1)
            {
                dr[MAHNB02349EA.CT_Col_SalesOrderDivName] = "在庫";
            }

            // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
            // 伝票タイプ
            long salesTax = 0;          // 売上／返品の消費税
            long salesTotalAll = 0;     // 売上／返品の合計金額
            long distTax = 0;           // 値引の消費税
            long distTotalAll = 0;      // 値引の合計金額
            // 明細タイプ
            long salesDtlTax = 0;       // 売上／返品の消費税
            long distDtlTax = 0;        // 値引の消費税
            // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

            // 2010/06/29 Add >>>
            if (string.IsNullOrEmpty(saleConfWork.ModelHalfName))
            {
                dr[MAHNB02349EA.CT_Col_ModelHalfName] = GetKanaString(saleConfWork.ModelFullName);  // 車種全角名称を半角変換
            }
            else
            {
                dr[MAHNB02349EA.CT_Col_ModelHalfName] = saleConfWork.ModelHalfName;                 // 車種半角名称 (string)
            }
            // 2010/06/29 Add <<<

            // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
            if (string.IsNullOrEmpty(saleConfWork.GoodsNameKana))
            {
                dr[MAHNB02349EA.CT_Col_GoodsNameKana] = saleConfWork.GoodsName;                     // 商品名称カナ（string）
            }
            // --- ADD  大矢睦美  2010/07/14 ----------<<<<<

            // 2009.02.06 30413 犬飼 明細タイプの伝票枚数カウント処理を変更(消費税転嫁方式に対応) >>>>>>START
            // 伝票キー
            string slipKey = saleConfWork.SectionCode.TrimEnd() + "-" + saleConfWork.CustomerCode.ToString("d08") + "-"
                           + saleConfWork.SalesSlipNum;
            // 2009.02.06 30413 犬飼 明細タイプの伝票枚数カウント処理を変更(消費税転嫁方式に対応) <<<<<<END

            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            string sConTaxRate = string.Empty;
            // 税別内訳印字の場合、
            if (_iTaxPrintDiv == 0)
            {
               sConTaxRate = Convert.ToString(saleConfWork.ConsTaxRate * 100) + "%"; // 消費税税率Title                        
               // 売上
               // Title_税率1
               dr[MAHNB02349EA.CT_SalesConf_TaxRate1_Title] = Convert.ToString(_taxRate1 * 100) + "%";
               // Title_税率2
               dr[MAHNB02349EA.CT_SalesConf_TaxRate2_Title] = Convert.ToString(_taxRate2 * 100) + "%";
               // Title_その他
               dr[MAHNB02349EA.CT_SalesConf_Other_Title] = "その他";
               // 返品
               // Title_税率1
               dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnTitle] = Convert.ToString(_taxRate1 * 100) + "%";
               // Title_税率2
               dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnTitle] = Convert.ToString(_taxRate2 * 100) + "%";
               // Title_その他
               dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTitle] = "その他";
               // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
               // 売上Title_非課税
               dr[MAHNB02349EA.CT_SalesConf_TaxFree_Title] = "非課税";
               // 返品Title_非課税
               dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnTitle] = "非課税";
               // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            }
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            
            // 消費税の設定
            //dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);      //DEL 2008/10/31 条件によって変化する為
            // --- ADD 2008/10/31 --------------------------------------------------------------------------------------------------------->>>>>
            // 伝票単位に出力時
            if (this._printDiv == 1)
            {
                // --- ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                //　消費税転嫁方式が伝票単位　かつ売上行番号が1行目の場合
                if (saleConfWork.ConsTaxLayMethod == 0 &&
                    saleConfWork.TaxRateExistFlag &&
                    _iTaxPrintDiv == 0 &&
                    !CountedSlipKeyList.Contains(slipKey))
                {
                    long salesTotalTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                    //　売上伝票区分(伝票)が「売上」の場合、売上数と売上原価を出力する
                    if (saleConfWork.SalesSlipCd == 0)
                    {
                        dr[MAHNB02349EA.CT_SalesConf_SalesTax] = salesTotalTax;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCountnumberDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCountnumberDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTotalTax;
                        }
                    }
                    //　売上伝票区分(伝票)が「返品」の場合、売上数と売上原価を出力する
                    if (saleConfWork.SalesSlipCd == 1)
                    {
                        dr[MAHNB02349EA.CT_SalesConf_ReturnTax] = salesTotalTax;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnSalesCountDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnSalesCountDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTotalTax;
                        }
                    }
                }
                // --- ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                if ((saleConfWork.ConsTaxLayMethod == 2) ||
                    (saleConfWork.ConsTaxLayMethod == 3) ||
                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // (saleConfWork.ConsTaxLayMethod == 9)
                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // 課税存在しないかつ非課税存在の場合
                    (saleConfWork.ConsTaxLayMethod == 9) ||
                    (saleConfWork.TaxFreeExistFlag && !saleConfWork.TaxRateExistFlag)
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    )
                {
                    // --- UPD 2022/09/29 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // 消費税
                    //dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalAmntConsTaxInclu + saleConfWork.SalesDisTtlTaxInclu); // DEL 2009/04/14
                    //dr[MAHNB02349EA.CT_SalesConf_Tax] = 0; // ADD 2009/04/14
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // 消費税税率
                        // dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                        if (saleConfWork.ConsTaxLayMethod == 0)
                        {
                            // 消費税税率
                            dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                        }
                        else
                        {
                            // 消費税税率
                            dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                        }
                        
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    // 合計金額
                    //dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc + (saleConfWork.SalAmntConsTaxInclu + saleConfWork.SalesDisTtlTaxInclu);

                    // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                    // 伝票タイプの消費税と合計金額を算出
                    //salesTax = saleConfWork.SalAmntConsTaxInclu; // DEL 2009/04/14
                    //salesTax = 0; // ADD 2009/04/14
                    //salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalAmntConsTaxInclu - saleConfWork.SalesDisTtlTaxExc;
                    if (saleConfWork.ConsTaxLayMethod == 0)
                    {
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc); 
                        salesTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc - saleConfWork.SalesDisOutTax;
                        distTax = saleConfWork.SalesDisOutTax;
                        distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisOutTax;
                        // 合計金額
                        dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc
                                                                        + (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);
                    }
                    else 
                    {
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = 0; 
                        salesTax = 0;
                        salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalAmntConsTaxInclu - saleConfWork.SalesDisTtlTaxExc;
                        distTax = 0; // DEL 2009/04/14
                        distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisTtlTaxInclu;
                        // 合計金額
                        dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc
                                                                        + (saleConfWork.SalAmntConsTaxInclu + saleConfWork.SalesDisTtlTaxInclu);
                    }

                    //distTax = saleConfWork.SalesDisTtlTaxInclu; // DEL 2009/04/14
                    //distTax = 0; // DEL 2009/04/14
                    //distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisTtlTaxInclu;
                    // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END
                    // --- UPD 2022/09/29 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                }
                // 消費税転嫁方式　0：伝票単位、1：明細単位
                else
                {
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // 消費税税率
                        dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    // 消費税
                    dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);
                    // 合計金額
                    dr[MAHNB02349EA.CT_Col_SalesTotalTaxExcPlusTax] = saleConfWork.SalesTotalTaxExc
                                                                    + (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);

                    // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                    // 伝票タイプの消費税と合計金額を算出
                    salesTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisOutTax;
                    salesTotalAll = saleConfWork.SalesTotalTaxExc + saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc - saleConfWork.SalesDisOutTax;
                    distTax = saleConfWork.SalesDisOutTax;
                    distTotalAll = saleConfWork.SalesDisTtlTaxExc + saleConfWork.SalesDisOutTax;
                    // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END
                }
            }
            // 明細単位に出力時
            else
            {
                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                if ((saleConfWork.ConsTaxLayMethod == 2) ||
                    (saleConfWork.ConsTaxLayMethod == 3) ||
                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // (saleConfWork.ConsTaxLayMethod == 9)
                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    (saleConfWork.ConsTaxLayMethod == 9) ||
                    (saleConfWork.TaxationDivCd == 1))
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                {
                    // --- DEL 2009/04/14 -------------------------------->>>>>
                    //// 課税区分　2：内税
                    //if (saleConfWork.TaxationDivCd == 2)
                    //{
                    //    // 消費税
                    //    dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                    //}
                    //// 課税区分　0：課税、1：非課税
                    //else
                    //{
                    //    // 消費税
                    //    dr[MAHNB02349EA.CT_SalesConf_Tax] = DBNull.Value;
                    //}
                    // --- DEL 2009/04/14 --------------------------------<<<<<
                    dr[MAHNB02349EA.CT_SalesConf_Tax] = 0; // ADD 2009/04/14
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // 消費税税率
                        dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

                    // --- ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                    // 消費税転嫁方式が伝票単位　かつ　売上明細行番号が1行目の場合、消費税と消費税税率を出力する
                    if (saleConfWork.ConsTaxLayMethod == 0 && 
                        saleConfWork.TaxationDivCd == 1 &&
                        !CountedSlipKeyList.Contains(slipKey) && 
                        !CountedTaxFreeKeyList.Contains(slipKey)) 
                    {
                        // 明細行番号が1行目
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        // 消費税税率
                        dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                }
                // 消費税転嫁方式　0：伝票単位、1：明細単位
                else
                {
                    // 2008.12.18 30413 犬飼 明細タイプの帳票で伝票転嫁の場合、売上行番号が1行目のみに消費税を設定 >>>>>>START                        
                    // 消費税
                    //dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                    if (saleConfWork.ConsTaxLayMethod == 0)
                    {
                        // 消費税転嫁方式　0：伝票単位
                        //if (saleConfWork.SalesRowNo == 1)
                        if (!CountedSlipKeyList.Contains(slipKey))
                        {
                            // 売上行番号が1行目
                            // 消費税
                            // dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc); DEL 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                            // --- ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                            if (!CountedTaxFreeKeyList.Contains(slipKey)) 
                            {
                                dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);
                            }
                            // --- ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

                            // 2009.01.21 30413 犬飼 小計部の消費税を追加 >>>>>>START
                            // 明細タイプの消費税を算出
                            salesDtlTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisOutTax;
                            distDtlTax = saleConfWork.SalesDisOutTax;
                            // 2009.01.21 30413 犬飼 小計部の消費税を追加 <<<<<<END
                            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                            // 税別内訳印字の場合、
                            // if (_iTaxPrintDiv == 0 ) DEL 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                            // 税別内訳印字かつ課税の場合
                            if (_iTaxPrintDiv == 0 && !CountedTaxFreeKeyList.Contains(slipKey)) // ADD 2022/09/20 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                            {
                                // 消費税税率
                                dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                            }
                            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                        }
                        else
                        {
                            // 上記以外
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_Tax] = 0;
                            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                            // 税別内訳印字の場合、
                            if (_iTaxPrintDiv == 0)
                            {
                                // 消費税税率
                                dr[MAHNB02349EA.CT_Col_ConsTaxRate] = string.Empty;
                            }
                            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                        }
                    }
                    else
                    {
                        // 消費税転嫁方式　1：明細単位
                        // 消費税
                        dr[MAHNB02349EA.CT_SalesConf_Tax] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // 消費税税率
                            dr[MAHNB02349EA.CT_Col_ConsTaxRate] = sConTaxRate;
                        }
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                    // 2008.12.18 30413 犬飼 明細タイプの帳票で伝票転嫁の場合、売上行番号が1行目のみに消費税を設定 <<<<<<END                        
                }
            }
            dr[MAHNB02349EA.CT_Col_ConsTaxLayMethod] = saleConfWork.ConsTaxLayMethod;       // 消費税転嫁方式
            dr[MAHNB02349EA.CT_Col_TaxationDivCd] = saleConfWork.TaxationDivCd;             // 課税区分
            // --- ADD 2008/10/31 ---------------------------------------------------------------------------------------------------------<<<<<

            // 粗利(税抜き)(伝票)の設定
            dr[MAHNB02349EA.CT_SalesConf_GrossProfit] = (saleConfWork.SalesTotalTaxExc - saleConfWork.TotalCost);

            // 粗利(税抜き)(明細)の設定
            dr[MAHNB02349EA.CT_SalesConf_GrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

            // 売上行番号(明細)
            dr[MAHNB02349EA.CT_SalesConf_SalesRowNo] = saleConfWork.SalesRowNo;

            //// 2009.02.03 30413 犬飼 明細タイプの伝票枚数カウント処理を変更 >>>>>>START
            //// 伝票キー
            //string slipKey = saleConfWork.SectionCode.TrimEnd() + "-" + saleConfWork.CustomerCode.ToString("d08") + "-"
            //               + saleConfWork.SalesSlipNum;
            //// 2009.02.03 30413 犬飼 明細タイプの伝票枚数カウント処理を変更 <<<<<<END
                
            // 計部の設定
            // 売上伝票区分(伝票)(SalesSlipCd → 0=売上、1=返品)
            if (saleConfWork.SalesSlipCd == 0)
            {
                // 売上伝票数のカウント(伝票)
                dr[MAHNB02349EA.CT_SalesConf_SalesCountNumber] = 1;

                // 2009.01.15 30413 犬飼 伝票タイプの値引設定の変更に伴う修正 >>>>>>START
                long totalMeter = saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc;
                long salesCost = saleConfWork.TotalCost - saleConfWork.DisCost;

                // 売上合計金額
                //dr[MAHNB02349EA.CT_SalesConf_TotalMeter] = saleConfWork.SalesTotalTaxExc;
                dr[MAHNB02349EA.CT_SalesConf_TotalMeter] = totalMeter;

                // 売上合計原価(税抜き)
                //dr[MAHNB02349EA.CT_SalesConf_SalesCost] = saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_SalesCost] = salesCost;

                // 売上合計粗利
                //dr[MAHNB02349EA.CT_SalesConf_SalesGrossProfit] = saleConfWork.SalesTotalTaxExc - saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_SalesGrossProfit] = totalMeter - salesCost;
                // 2009.01.15 30413 犬飼 伝票タイプの値引設定の変更に伴う修正 <<<<<<END

                // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                // 売上合計消費税(伝票)
                dr[MAHNB02349EA.CT_SalesConf_SalesTax] = salesTax;

                // 売上の消費税込合計金額(伝票)
                dr[MAHNB02349EA.CT_SalesConf_SalesTotalAll] = salesTotalAll;
                // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

                // 2009.02.03 30413 犬飼 明細タイプの伝票枚数カウント処理を変更 >>>>>>START
                //if (saleConfWork.SalesRowNo == 1)
                //{
                //    // 売上数のカウント(明細)
                //    dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;

                //    // 明細の1行目のみ印字する項目
                //    //dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // 得意先伝票番号 (Int32)
                //    if (saleConfWork.CustSlipNo == 0)
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                //    }
                //    else
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // 得意先伝票番号 (Int32)
                //    }
                //    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // ＵＯＥリマーク１ (string)
                //    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // ＵＯＥリマーク２ (string)
                //}
                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                //　明細単位に出力時、非課税の1行目かつ税別内訳印字の場合、売上数(明細)_非課税と売上数のカウント(明細)を出力する
                if (!CountedTaxFreeKeyList.Contains(slipKey) && this._printDiv != 1 && _iTaxPrintDiv == 0 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                {
                    // 売上数(明細)_非課税
                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCountnumberDtl] = 1;
                    if (!CountedSlipKeyList.Contains(slipKey)) {
                        // 売上数のカウント(明細)
                        dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;
                    }
                    CountedTaxFreeKeyList.Add(slipKey);
                    if (saleConfWork.ConsTaxLayMethod == 0 && saleConfWork.TaxRateExistFlag) {
                        long salesTotalTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            // 売上数(明細)_税率1
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCountnumberDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            // 売上数(明細)_税率2
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCountnumberDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            // 売上数(明細)_その他
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTotalTax;
                        }
                    }
                }
                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    // 売上数のカウント(明細)
                    // dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1; DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                    if (this._printDiv == 1)
                    {
                        // 売上数のカウント(明細)
                        dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;
                    }
                    else
                    {
                        // 非課税の1行目の場合、売上数のカウント(明細)を出力する
                        if (!CountedTaxFreeKeyList.Contains(slipKey))
                        {
                            // 売上数のカウント(明細)
                            dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;
                        }
                    }
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

                    // 明細の1行目のみ印字する項目
                    if (saleConfWork.CustSlipNo == 0)
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                    }
                    else
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // 得意先伝票番号 (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // ＵＯＥリマーク１ (string)
                    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // ＵＯＥリマーク２ (string)

                    //CountedSlipKeyList.Add(slipKey);
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        // 消費税転嫁方式　9：非課税
                        //if (saleConfWork.ConsTaxLayMethod == 9) 
                        //{
                        //    // 売上数(明細)_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1;
                        //    // 伝票単位
                        //    if (this._printDiv == 1)
                        //    {
                        //        // 売上合計金額_その他
                        //        dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = totalMeter;
                        //        // 売上合計消費税_その他
                        //        dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTax;
                        //        // 売上の消費税込合計金額_その他
                        //        dr[MAHNB02349EA.CT_SalesConf_Other_SalesTotalAll] = salesTotalAll;
                        //    }
                        //}
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        //　伝票単位に出力時、非課税存在するかつ課税存在するの場合
                        if (this._printDiv == 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxFreeExistFlag) && saleConfWork.TaxRateExistFlag)
                        {
                            // 売上数(明細)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCountnumberDtl] = 1;
                            // 伝票単位
                            if (this._printDiv == 1)
                            {
                                // 売上合計金額_非課税
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;
                                // 売上合計消費税_非課税
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtlTax] = 0;
                                // 売上の消費税込合計金額_非課税
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                            }
                        }

                        //　伝票単位に出力時、非課税存在するかつ課税存在しないの場合　
                        if (this._printDiv == 1 && (saleConfWork.TaxFreeExistFlag || saleConfWork.ConsTaxLayMethod == 9) && !saleConfWork.TaxRateExistFlag)
                        {
                            // 売上数(明細)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCountnumberDtl] = 1;
                            // 伝票単位
                            if (this._printDiv == 1)
                            {
                                // 売上合計金額_非課税
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;
                                // 売上合計消費税_非課税
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtlTax] = 0;
                                // 売上の消費税込合計金額_非課税
                                dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                            }
                        }
                        //　明細単位に出力時、非課税の場合
                        else if (this._printDiv != 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                        {
                            
                        }
                        //--- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        else
                        {
                            // 税率2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // 売上数(明細)_税率2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCountnumberDtl] = 1;
                                
                                // 伝票単位
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上合計金額_税率2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = totalMeter
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上合計金額_税率2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // 売上合計消費税_税率2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上の消費税込合計金額_税率2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上の消費税込合計金額_税率2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                }
                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // 売上数(明細)_税率1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCountnumberDtl] = 1; 
                                // 伝票単位
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上合計金額_税率1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = totalMeter
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上合計金額_税率1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // 売上合計消費税_税率1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上の消費税込合計金額_税率1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上の消費税込合計金額_税率1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                }
                            }
                            else
                            {
                                // 売上数(明細)_その他
                                dr[MAHNB02349EA.CT_SalesConf_Other_SalesCountnumberDtl] = 1; 
                                
                                // 伝票単位
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上合計金額_その他
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上合計金額_その他
                                    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = totalMeter - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // 売上合計消費税_その他
                                    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上の消費税込合計金額_その他
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_SalesTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 売上の消費税込合計金額_その他
                                    dr[MAHNB02349EA.CT_SalesConf_Other_SalesTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                }

                            }
                        }
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
                // 2009.02.03 30413 犬飼 明細タイプの伝票枚数カウント処理を変更 <<<<<<END
            }
            else if (saleConfWork.SalesSlipCd == 1)
            {
                // 返品伝票数のカウント(伝票)
                dr[MAHNB02349EA.CT_SalesConf_ReturnCountNumber] = 1;

                // 2009.01.15 30413 犬飼 伝票タイプの値引設定の変更に伴う修正 >>>>>>START
                long returnSalesMoney = saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc;
                long salesReturnCost = saleConfWork.TotalCost - saleConfWork.DisCost;
                
                // 返品合計金額(税抜き)
                //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoney] = saleConfWork.SalesTotalTaxExc;
                dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoney] = returnSalesMoney;

                // 返品合計原価(税抜き)
                //dr[MAHNB02349EA.CT_SalesConf_SalesReturnCost] = saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_SalesReturnCost] = salesReturnCost;

                // 返品合計粗利
                //dr[MAHNB02349EA.CT_SalesConf_ReturnGrossProfit] = saleConfWork.SalesTotalTaxExc - saleConfWork.TotalCost;
                dr[MAHNB02349EA.CT_SalesConf_ReturnGrossProfit] = returnSalesMoney - salesReturnCost;

                // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                // 返品合計消費税(伝票)
                dr[MAHNB02349EA.CT_SalesConf_ReturnTax] = salesTax;

                // 売上の消費税込合計金額(伝票)
                dr[MAHNB02349EA.CT_SalesConf_ReturnTotalAll] = salesTotalAll;
                // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END
                    
                if (saleConfWork.SalesRowNo == 0)
                {
                    // 伝票タイプの場合は、売上行番号がゼロ
                    if (saleConfWork.RetGoodsReasonDiv != 0)
                    {
                        // 返品理由コードが0以外の場合は、コードをセット
                        dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv.ToString("d04");  // 返品理由コード (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // 返品理由 (string)
                    
                }
                // 2009.02.03 30413 犬飼 明細タイプの伝票枚数カウント処理を変更 >>>>>>START
                //else if (saleConfWork.SalesRowNo == 1)
                //{
                //    // 返品数のカウント(明細)
                //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;

                //    // 明細の1行目のみ印字する項目
                //    if (saleConfWork.RetGoodsReasonDiv != 0)
                //    {
                //        // 返品理由コードが0以外の場合は、コードをセット
                //        dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv.ToString();  // 返品理由コード (Int32)
                //    }
                //    dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // 返品理由 (string)
                //    //dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // 得意先伝票番号 (Int32)
                //    if (saleConfWork.CustSlipNo == 0)
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                //    }
                //    else
                //    {
                //        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // 得意先伝票番号 (Int32)
                //    }
                //    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // ＵＯＥリマーク１ (string)
                //    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // ＵＯＥリマーク２ (string)
                //}
                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                //　明細単位に出力時、非課税の1行目かつ税別内訳印字の場合、返品数(明細)_非課税と返品数のカウント(明細)を出力する
                if (!CountedTaxFreeKeyList.Contains(slipKey) && this._printDiv != 1 && _iTaxPrintDiv == 0 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                {
                    // 返品数(明細)_非課税
                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnSalesCountDtl] = 1;
                    if (!CountedSlipKeyList.Contains(slipKey))
                    {
                        // 返品数のカウント(明細)
                        dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;
                    }
                    CountedTaxFreeKeyList.Add(slipKey);
                    if (saleConfWork.ConsTaxLayMethod == 0 && saleConfWork.TaxRateExistFlag)
                    {
                        long salesTotalTax = saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc;
                        if (saleConfWork.ConsTaxRate == _taxRate1)
                        {
                            // 返品数(明細)_税率1
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnSalesCountDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtlTax] = salesTotalTax;
                        }
                        else if (saleConfWork.ConsTaxRate == _taxRate2)
                        {
                            // 返品数(明細)_税率2
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnSalesCountDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtlTax] = salesTotalTax;
                        }
                        else
                        {
                            // 返品数(明細)_その他
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1;
                            // 消費税
                            dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTotalTax;
                        }
                    }
                }
                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    // 返品数のカウント(明細)
                    // dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1; DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                    if (this._printDiv == 1)
                    {
                        // 返品数のカウント(明細)
                        dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;
                    }
                    else {
                        // 非課税の1行目の場合、売上数のカウント(明細)を出力する
                        if (!CountedTaxFreeKeyList.Contains(slipKey)) 
                        {
                            // 返品数のカウント(明細)
                            dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtl] = 1;
                        }
                    }
                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<

                    // 明細の1行目のみ印字する項目
                    if (saleConfWork.RetGoodsReasonDiv != 0)
                    {
                        // 返品理由コードが0以外の場合は、コードをセット
                        dr[MAHNB02349EA.CT_Col_RetGoodsReasonDiv] = saleConfWork.RetGoodsReasonDiv.ToString();  // 返品理由コード (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_RetGoodsReason] = saleConfWork.RetGoodsReason;               // 返品理由 (string)
                    if (saleConfWork.CustSlipNo == 0)
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = "";
                    }
                    else
                    {
                        dr[MAHNB02349EA.CT_Col_CustSlipNo] = saleConfWork.CustSlipNo.ToString();            // 得意先伝票番号 (Int32)
                    }
                    dr[MAHNB02349EA.CT_Col_UoeRemark1] = saleConfWork.UoeRemark1;                       // ＵＯＥリマーク１ (string)
                    dr[MAHNB02349EA.CT_Col_UoeRemark2] = saleConfWork.UoeRemark2;                       // ＵＯＥリマーク２ (string)

                    //CountedSlipKeyList.Add(slipKey);
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        // 消費税転嫁方式　9：非課税
                        //if (saleConfWork.ConsTaxLayMethod == 9)
                        //{ 
                        //// 返品数(明細)_その他
                        //dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1;

                        //// 伝票単位
                        //if (this._printDiv == 1)
                        //{
                        //    // 返品合計金額_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = returnSalesMoney;

                        //    // 返品合計消費税_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTax;

                        //    // 返品の消費税込合計金額(明細)_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTotalAll] = salesTotalAll;
                        //}
                        //}
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        //　伝票単位に出力時、非課税存在するかつ課税存在するの場合
                        if (this._printDiv == 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxFreeExistFlag) && saleConfWork.TaxRateExistFlag)
                        {
                            // 返品数(明細)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnSalesCountDtl] = 1;
                             // 返品合計金額_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;

                            // 返品合計消費税_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtlTax] = 0;

                            // 返品の消費税込合計金額(明細)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                        }
                        //　伝票単位に出力時、非課税存在するかつ課税存在しないの場合
                        if (this._printDiv == 1 && (saleConfWork.TaxFreeExistFlag || saleConfWork.ConsTaxLayMethod == 9) && !saleConfWork.TaxRateExistFlag)
                        {
                            // 返品数(明細)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnSalesCountDtl] = 1;

                            // 返品合計金額_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxFreeCdrf;

                            // 返品合計消費税_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtlTax] = 0;

                            // 返品の消費税込合計金額(明細)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnTotalAll] = saleConfWork.SalesMoneyTaxFreeCdrf;
                        }
                        //　明細単位に出力時、非課税の場合
                        else if (this._printDiv != 1 && (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1))
                        {
                            
                        }
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        else
                        {
                            // 税率2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // 返品数(明細)_税率2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnSalesCountDtl] = 1; 

                                // 伝票単位
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_税率2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = returnSalesMoney
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_税率2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = returnSalesMoney - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

                                    // 返品合計消費税_税率2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtlTax] = salesTax;
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_税率2
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品の消費税込合計金額(明細)_税率2
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

                                }
                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // 返品数(明細)_税率1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnSalesCountDtl] = 1; 
                                // 伝票単位
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_税率1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = returnSalesMoney
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_税率1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = returnSalesMoney - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

                                    // 返品合計消費税_税率1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtlTax] = salesTax;

                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品の消費税込合計金額(明細)_税率1
                                    // dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品の消費税込合計金額(明細)_税率1
                                    dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                }
                            }
                            else
                            {
                                // 返品数(明細)_その他
                                dr[MAHNB02349EA.CT_SalesConf_Other_ReturnSalesCountDtl] = 1; 
                               
                                // 伝票単位
                                if (this._printDiv == 1)
                                {
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_その他
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = returnSalesMoney
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品合計金額_その他
                                    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = returnSalesMoney - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

                                    // 返品合計消費税_その他
                                    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtlTax] = salesTax;

                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品の消費税込合計金額(明細)_その他
                                    // dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTotalAll] = salesTotalAll
                                    // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                                    // 返品の消費税込合計金額(明細)_その他
                                    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnTotalAll] = salesTotalAll - saleConfWork.SalesMoneyTaxFreeCdrf;
                                    // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                                }

                            }
                        }
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
                // 2009.02.03 30413 犬飼 明細タイプの伝票枚数カウント処理を変更 <<<<<<END
            }

            // 2009.01.15 30413 犬飼 伝票タイプの値引設定を変更 >>>>>>START
            // 値引きの設定(伝票)
            // 値引き合計金額(税抜き)(伝票)
            dr[MAHNB02349EA.CT_SalesConf_DistSalesMoney] = saleConfWork.SalesDisTtlTaxExc;

            // 値引き合計原価金額(伝票)
            dr[MAHNB02349EA.CT_SalesConf_DistCost] = saleConfWork.DisCost;

            // 値引き合計粗利(伝票)
            dr[MAHNB02349EA.CT_SalesConf_DistGrossProfit] = saleConfWork.SalesDisTtlTaxExc - saleConfWork.DisCost;
            // 2009.01.15 30413 犬飼 伝票タイプの値引設定を変更 <<<<<<END

            // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
            // 値引き合計消費税(伝票)
            dr[MAHNB02349EA.CT_SalesConf_DistTax] = distTax;

            // 値引きの消費税込合計金額(伝票)
            dr[MAHNB02349EA.CT_SalesConf_DistTotalAll] = distTotalAll;
            // 2009.01.21 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

            
            // 売上伝票区分(明細)(SalesSlipCdDtl → 0=売上、1=返品、2=値引)
            if (saleConfWork.SalesSlipCdDtl == 0)
            {
                // 売上数のカウント(明細)
                //dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtl] = 1;

                // 売上合計金額(明細)
                dr[MAHNB02349EA.CT_SalesConf_SalesDtl] = (saleConfWork.SalesMoneyTaxExc);

                // 売上合計原価(税抜き)(明細)
                dr[MAHNB02349EA.CT_SalesConf_SalesCostDtl] = (saleConfWork.Cost);

                // 売上合計粗利(明細)
                dr[MAHNB02349EA.CT_SalesConf_SalesGrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

                // 2009.01.21 30413 犬飼 小計部の消費税を追加 >>>>>>START
                // 売上合計消費税(明細)
                //if ((saleConfWork.ConsTaxLayMethod == 0) && (saleConfWork.SalesRowNo == 1))
                if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                    dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = salesDtlTax;
                    // 値引き合計消費税(明細)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                }
                else
                {
                    // 上記以外
                    dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                }
                // 2009.01.21 30413 犬飼 小計部の消費税を追加 <<<<<<END
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // 明細単位
                    if (this._printDiv != 1)
                    {
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        // 消費税転嫁方式　9：非課税
                        //if (saleConfWork.ConsTaxLayMethod == 9) {
                        //    // 売上合計金額_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                        //    // 売上原価(税抜き)_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesCostDtl] = saleConfWork.Cost;
                        //}
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        // 消費税転嫁方式　9：非課税　又は　課税区分　1：非課税
                        if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                        {
                            // 売上合計金額_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                            // 売上原価(税抜き)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesCostDtl] = saleConfWork.Cost;
                        }
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        else
                        {
                            // 税率2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // 売上合計金額_税率2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                // 売上原価(税抜き)_税率2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesCostDtl] = saleConfWork.Cost;
                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // 売上合計金額_税率1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                // 売上原価(税抜き)_税率1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesCostDtl] = saleConfWork.Cost;
                            }
                            else
                            {
                                // 売上合計金額_その他
                                dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                // 売上原価(税抜き)_その他
                                dr[MAHNB02349EA.CT_SalesConf_Other_SalesCostDtl] = saleConfWork.Cost;
                            }
                        }
                    }
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            else if (saleConfWork.SalesSlipCdDtl == 1)
            {
                // 返品合計金額(明細)
                dr[MAHNB02349EA.CT_SalesConf_ReturnDtl] = (saleConfWork.SalesMoneyTaxExc);

                // 返品合計原価(税抜き)(明細)
                dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtl] = (saleConfWork.Cost);

                // 返品合計粗利(明細)
                dr[MAHNB02349EA.CT_SalesConf_ReturnGrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

                // 2009.01.21 30413 犬飼 小計部の消費税を追加 >>>>>>START
                // 返品合計消費税(明細)
                //if ((saleConfWork.ConsTaxLayMethod == 0) && (saleConfWork.SalesRowNo == 1))
                if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                    dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = salesDtlTax;
                    // 値引き合計消費税(明細)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                }
                else
                {
                    // 上記以外
                    dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                }
                // 2009.01.21 30413 犬飼 小計部の消費税を追加 <<<<<<END
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // 明細単位
                    if (this._printDiv != 1)
                    {
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        //// 消費税転嫁方式　9：非課税
                        //if (saleConfWork.ConsTaxLayMethod == 9) 
                        //{
                        //    // 返品合計金額_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                        //    // 返品原価(税抜き)_その他
                        //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnCostDtl] = saleConfWork.Cost;
                        //}
                        // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                        // 消費税転嫁方式　9：非課税　又は　課税区分　1：非課税
                        if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                        {
                            // 返品合計金額_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                            // 返品原価(税抜き)_非課税
                            dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnCostDtl] = saleConfWork.Cost;
                        }
                        // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                        else
                        {
                            // 税率2
                            if (saleConfWork.ConsTaxRate == _taxRate2)
                            {
                                // 返品合計金額_税率2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                // 返品原価(税抜き)_税率2
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnCostDtl] = saleConfWork.Cost;

                            }
                            else if (saleConfWork.ConsTaxRate == _taxRate1)
                            {
                                // 返品合計金額_税率1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                // 返品原価(税抜き)_税率1
                                dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnCostDtl] = saleConfWork.Cost;

                            }
                            else
                            {
                                // 返品合計金額_その他
                                dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                // 返品原価(税抜き)_その他
                                dr[MAHNB02349EA.CT_SalesConf_Other_ReturnCostDtl] = saleConfWork.Cost;
                            }
                        }
                    }
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            else if (saleConfWork.SalesSlipCdDtl == 2)
            {
                // 2009.03.13 30413 犬飼 行値引きの扱いを変更 >>>>>>START
                // 行値引きは売上／返品として扱う
                if (saleConfWork.ShipmentCnt == 0.0)
                {
                    // 行値引
                    if (saleConfWork.SalesSlipCd == 0)
                    {
                        // 売上に計上
                        // 売上合計金額(明細)
                        dr[MAHNB02349EA.CT_SalesConf_SalesDtl] = (saleConfWork.SalesMoneyTaxExc);
                        // 売上合計消費税(明細)
                        if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                            dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = salesDtlTax;
                            // 値引き合計消費税(明細)
                            dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // 上記以外
                            dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                        }
                        // --- ADD END 3H 尹安 2020/02/27 ----->>>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // 明細単位
                            if (this._printDiv != 1)
                            {
                                // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                                //// 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                                //if (saleConfWork.ConsTaxLayMethod == 9)
                                //{
                                //    // 売上合計金額_その他
                                //    dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                //}
                                // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                                // 消費税転嫁方式　9：非課税　又は　課税区分　1：非課税
                                if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                                {
                                    // 売上合計金額_非課税
                                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                }
                                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                                else
                                {
                                    // 税率2
                                    if (saleConfWork.ConsTaxRate == _taxRate2)
                                    {
                                        // 売上合計金額_税率2
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate2_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                    else if (saleConfWork.ConsTaxRate == _taxRate1)
                                    {
                                        // 売上合計金額_税率1
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate1_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                    else
                                    {
                                        // 売上合計金額_その他
                                        dr[MAHNB02349EA.CT_SalesConf_Other_SalesDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                }
                            }
                        }
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

                    }
                    else if (saleConfWork.SalesSlipCd == 1)
                    {
                        // 返品に計上
                        // 返品合計金額(明細)
                        dr[MAHNB02349EA.CT_SalesConf_ReturnDtl] = (saleConfWork.SalesMoneyTaxExc);
                        // 返品合計消費税(明細)
                        if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                            dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = salesDtlTax;
                            // 値引き合計消費税(明細)
                            dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // 上記以外
                            dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                        }
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // 明細単位
                            if (this._printDiv != 1)
                            {
                                // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                                //// 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                                //if (saleConfWork.ConsTaxLayMethod == 9)
                                //{
                                //    // 返品合計金額_その他
                                //    dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                //}
                                // --- DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ----->>>>>
                                // 消費税転嫁方式　9：非課税　又は　課税区分　1：非課税
                                if (saleConfWork.ConsTaxLayMethod == 9 || saleConfWork.TaxationDivCd == 1)
                                {
                                    // 返品合計金額_非課税
                                    dr[MAHNB02349EA.CT_SalesConf_TaxFree_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                }
                                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） -----<<<<<
                                else
                                {
                                    // 税率2
                                    if (saleConfWork.ConsTaxRate == _taxRate2)
                                    {
                                        // 返品合計金額_税率2
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate2_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;

                                    }
                                    else if (saleConfWork.ConsTaxRate == _taxRate1)
                                    {
                                        // 返品合計金額_税率1
                                        dr[MAHNB02349EA.CT_SalesConf_TaxRate1_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;

                                    }
                                    else
                                    {
                                        // 返品合計金額_その他
                                        dr[MAHNB02349EA.CT_SalesConf_Other_ReturnDtl] = saleConfWork.SalesMoneyTaxExc;
                                    }
                                }
                            }
                        }
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
          
                    }
                }
                else
                {
                    // 値引き合計金額(明細)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtl] = (saleConfWork.SalesMoneyTaxExc);

                    // 値引き合計原価金額(税抜き)(明細)
                    dr[MAHNB02349EA.CT_SalesConf_DistDtlCost] = (saleConfWork.Cost);

                    // 値引き合計粗利(明細)
                    dr[MAHNB02349EA.CT_SalesConf_DistGrossProfitDtl] = (saleConfWork.SalesMoneyTaxExc - saleConfWork.Cost);

                    // 2009.01.21 30413 犬飼 小計部の消費税を追加 >>>>>>START
                    // 値引き合計消費税(明細)
                    //if ((saleConfWork.ConsTaxLayMethod == 0) && (saleConfWork.SalesRowNo == 1))
                    if ((saleConfWork.ConsTaxLayMethod == 0) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                        dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = distDtlTax;
                        if (saleConfWork.SalesSlipCd == 0)
                        {
                            // 売上伝票区分が"0:売上"
                            dr[MAHNB02349EA.CT_SalesConf_SalesDtlTax] = salesDtlTax;
                        }
                        else if (saleConfWork.SalesSlipCd == 1)
                        {
                            // 売上伝票区分が"1:返品"
                            dr[MAHNB02349EA.CT_SalesConf_ReturnDtlTax] = salesDtlTax;
                        }
                    }
                    else
                    {
                        // 上記以外
                        dr[MAHNB02349EA.CT_SalesConf_DistDtlTax] = dr[MAHNB02349EA.CT_SalesConf_Tax];
                    }
                    // 2009.01.21 30413 犬飼 小計部の消費税を追加 <<<<<<END
                    // 2009.03.13 30413 犬飼 行値引きの扱いを変更 <<<<<<END
                }
                // 2009.01.15 30413 犬飼 伝票タイプの値引設定を変更 >>>>>>START
                //// 値引きの設定(伝票)
                //// 値引き合計金額(税抜き)(伝票)
                //dr[MAHNB02349EA.CT_SalesConf_DistSalesMoney] = (saleConfWork.SalesDisTtlTaxExc);

                //// 値引き合計原価金額(伝票)
                //dr[MAHNB02349EA.CT_SalesConf_DistCost] = (saleConfWork.TotalCost);

                //// 値引き合計粗利(伝票)
                //dr[MAHNB02349EA.CT_SalesConf_DistGrossProfit] = (saleConfWork.SalesDisTtlTaxExc - saleConfWork.Cost);
                // 2009.01.15 30413 犬飼 伝票タイプの値引設定を変更 <<<<<<END
            }
            
            // 2008.07.08 30413 犬飼 Row項目の全置き換え <<<<<<END

            // 2009.02.06 30413 犬飼 明細タイプの伝票枚数カウント処理を変更(消費税転嫁方式に対応) >>>>>>START
            // if (!CountedSlipKeyList.Contains(slipKey))  DEL 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            //　課税の1行目場合、カウント済みの伝票キーリストに伝票キーを追加する
            if (!CountedSlipKeyList.Contains(slipKey) && !(_iTaxPrintDiv == 0 && this._printDiv != 1 && saleConfWork.TaxationDivCd == 1)) // ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
            {
                CountedSlipKeyList.Add(slipKey);
            }
            // 2009.02.06 30413 犬飼 明細タイプの伝票枚数カウント処理を変更(消費税転嫁方式に対応) <<<<<<END
            
            // 2008.07.08 30413 犬飼 Row項目の全置き換えのため既存項目はコメント化 >>>>>>START
            //dr[MAHNB02349EA.CT_SalesConf_SectionCodeRF]          = saleConfWork.SectionCode;          // 拠点コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SectionGuideNmRF]       = saleConfWork.SectionGuideNm;       // 拠点ガイド名称     (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesDateRF]            = TDateTime.DateTimeToLongDate(saleConfWork.SalesDate);            // 売上日付           (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_ShipmentDayRF]          = TDateTime.DateTimeToLongDate(saleConfWork.ShipmentDay);          // 出荷日付           (Int32)   
            //dr[MAHNB02349EA.CT_SalesConf_SalesDateRF]            = saleConfWork.SalesDate;            // 売上日付           (DateTime)     
            //dr[MAHNB02349EA.CT_SalesConf_ShipmentDayRF]          = saleConfWork.ShipmentDay;          // 出荷日付           (DateTime)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerCodeRF]         = saleConfWork.CustomerCode;         // 得意先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerSnmRF]          = saleConfWork.CustomerSnm;          // 得意先略称         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdRF]          = saleConfWork.SalesSlipCd;                           // 売上伝票区分       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmRF]          = this.GetSalesSlipNm(saleConfWork.SalesSlipCd);      // 売上伝票区分名 (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF]     = saleConfWork.SalesTotalTaxExc;     // 売上金額(税抜) (伝票) (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF]     = saleConfWork.SalesMoneyTaxExc;     // 売上金額（税抜）(明細) (Int64)

            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxIncRF]     = saleConfWork.SalesMoneyTaxInc;     // 売上金額(税込) (明細) (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesGoodsCdRF]         = saleConfWork.SalesGoodsCd;         // 商品区分コード(Int64)            
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNumRF]         = saleConfWork.SalesSlipNum;         // 売上伝票番号       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesRowNoRF]           = saleConfWork.SalesRowNo;           // 売上行番号         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeCdRF]      = saleConfWork.SalesEmployeeCd;      // 販売従業員コード   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeNmRF]      = saleConfWork.SalesEmployeeNm;      // 販売従業員名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivRF]         = saleConfWork.DebitNoteDiv;         // 赤伝区分           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivNmRF]       = this.GetDebitNoteDivNm(saleConfWork.DebitNoteDiv);   // 赤伝区分名 (string)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivCdRF]          = saleConfWork.AccRecDivCd;                            // 売掛区分   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivNmRF]          = this.GetAccRecDivNm(saleConfWork.AccRecDivCd);       // 売掛区分名 (string)

            //// ↓ 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////
            
            //dr[MAHNB02349EA.CT_SalesConf_SearchSlipDateRF]       = saleConfWork.SearchSlipDate;       // 入力日付           (DateTime)
            //dr[MAHNB02349EA.CT_SalesConf_AddUpADateRF]           = saleConfWork.AddUpADate;           // 計上日(請求日)     (DateTime)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaCodeRF]        = saleConfWork.SalesAreaCode;        // 販売エリアコード   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaNameRF]        = saleConfWork.SalesAreaName;        // 販売エリア名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNoRF]              = saleConfWork.GoodsNo;              // 商品番号           (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = saleConfWork.GoodsName;            // 商品名称           (string)
            //dr[MAHNB02349EA.CT_SalesConf_UnitCodeRF]             = saleConfWork.UnitCode;             // 単位コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_UnitNameRF]             = saleConfWork.UnitName;             // 単位名称           (string)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionCodeRF]       = saleConfWork.SubSectionCode;       // 部門コード         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionNameRF]       = saleConfWork.SubSectionName;       // 部門名称           (string)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionCodeRF]       = saleConfWork.MinSectionCode;       // 課コード           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionNameRF]       = saleConfWork.MinSectionName;       // 課名称             (string)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimCodeRF]            = saleConfWork.ClaimCode;            // 請求先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimSnmRF]             = saleConfWork.ClaimSnm;             // 請求先名称         (string)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeCodeRF]        = saleConfWork.AddresseeCode;        // 納品先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeNameRF]        = saleConfWork.AddresseeName;        // 納品先名称         (string)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeName2RF]       = saleConfWork.AddresseeName2;       // 納品先名称2        (string)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeCdRF]      = saleConfWork.FrontEmployeeCd;      // 受付従業員コード   (string)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeNmRF]      = saleConfWork.FrontEmployeeNm;      // 受付従業員名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_AcptAnOdrStatusRF]      = saleConfWork.AcptAnOdrStatus;      // 受注ステータス     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_PartySaleSlipNumRF]     = saleConfWork.PartySaleSlipNum;     // 相手先伝票番号     (string)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkSlip]    = saleConfWork.GrossMarginMarkSlip;  // 粗利チェックマーク(伝票) (string)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkDtl]     = saleConfWork.GrossMarginMarkDtl;   // 粗利チェックマーク(明細) (string)
            //dr[MAHNB02349EA.CT_SalesConf_TotalCostRF]            = saleConfWork.TotalCost;            // 原価金額計         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SlipNoteRF]             = saleConfWork.SlipNote;             // 伝票備考           (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdDtlRF]       = saleConfWork.SalesSlipCdDtl;       // 売上伝票区分(明細) (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmDtlRF]       = this.GetSalesSlipNmDtl(saleConfWork.SalesSlipCdDtl); //売上伝票区分名称(明細) (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsMakerCdRF]         = saleConfWork.GoodsMakerCd;         // 商品メーカーコード (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MakerNameRF]            = saleConfWork.MakerName;            // メーカー名称       (string)
            //dr[MAHNB02349EA.CT_SalesConf_StdUnPrcSalUnPrcRF]     = saleConfWork.StdUnPrcSalUnPrc;     // 基準単価(売上単価) (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxIncFlRF]   = saleConfWork.SalesUnPrcTaxIncFl;   // 売上単価(税込)     (double)
            
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnitCostRF]        = saleConfWork.SalesUnitCost;        // 原価単価           (double)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierCdRF]           = saleConfWork.SupplierCd;           // 仕入先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierSnmRF]          = saleConfWork.SupplierSnm;          // 仕入先略称(明細)        (string)   
            //dr[MAHNB02349EA.CT_SalesConf_PartySlipNumDtlRF]      = saleConfWork.PartySlipNumDtl;      // 相手先伝票番号(明細) (string)
            //dr[MAHNB02349EA.CT_SalesConf_DtlNoteRF]              = saleConfWork.DtlNote;              // 明細備考           (string)
            //dr[MAHNB02349EA.CT_SalesConf_DelayPaymentDivRF]      = saleConfWork.DelayPaymentDiv;      // 来勘区分           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxExcRF]    = saleConfWork.SalesDisTtlTaxExc;    // 売上値引金額計(税抜)(伝票)  (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxIncluRF]  = saleConfWork.SalesDisTtlTaxInclu - saleConfWork.SalesDisTtlTaxExc;  // 売上値引金額計(税込)(伝票) (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRate]        = saleConfWork.GrossMarginRate;      // 粗利率(伝票)       (double)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRateDtl]     = saleConfWork.GrossMarginRateDtl;   // 粗利率(明細)       (double)
            //dr[MAHNB02349EA.CT_SalesConf_TransactionNameRF]      = saleConfWork.TransactionName;      // 取引区分名         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputCodeRF]       = saleConfWork.SalesInputCode;       // 入力者コード       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputNameRF]       = saleConfWork.SalesInputName;       // 入力者名称         (string)
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseCodeRF]        = saleConfWork.WarehouseCode;        // 倉庫コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseNameRF]        = saleConfWork.WarehouseName;        // 倉庫名称           (string)

            //// ↓変更予定あり////////////////////////////////////////////////////////
            //// 納品先住所の読込み(郵便番号、都道府県市区郡・町村・字、丁目、番地、アパート名称)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeAddrRF] = saleConfWork.AddresseePostNo.Trim() + saleConfWork.AddresseeAddr1.Trim()
            //                                                + saleConfWork.AddresseeAddr3.Trim() + saleConfWork.AddresseeAddr4.Trim();
            //// ↑変更予定あり////////////////////////////////////////////////////////


            //// ↑ 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////

            //// ↓ 2008.03.24 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////

            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxIncRF]  = saleConfWork.SalesSubtotalTaxInc;   // 売上小計(税抜き)         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxExcRF]  = saleConfWork.SalesSubtotalTaxExc;   // 売上小計(税込み)         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalseNetPriceRF]        = saleConfWork.SalseNetPrice;         // 売上正価金額             (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF]     = saleConfWork.SalesSubtotalTaxExc;   // 売上小計（税）           (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesOutTaxRF]     = saleConfWork.ItdedSalesOutTax;      // 売上外税対象額           (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesInTaxRF]      = saleConfWork.ItdedSalesInTax;       // 売上内税対象額           (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalSubttlSubToTaxFreRF] = saleConfWork.SalSubttlSubToTaxFre;  // 売上小計非課税対象額     (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalseOutTaxRF]          = saleConfWork.SalseOutTax;           // 売上金額消費税額（外税） (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalAmntConsTaxIncluRF]  = saleConfWork.SalAmntConsTaxInclu;   // 売上金額消費税額（内税） (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisOutTaxRF]  = saleConfWork.ItdedSalesDisOutTax;   // 売上値引外税対象額合計   (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisInTaxRF]   = saleConfWork.ItdedSalesDisInTax;    // 売上値引内税対象額合計   (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalseDisTaxFreRF]  = saleConfWork.ItdedSalseDisTaxFre;   // 売上値引非課税対象額合計 (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisOutTaxRF]       = saleConfWork.SalesDisOutTax;        // 売上値引消費税額（外税） (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_SalsePriceConsTaxRF]    = saleConfWork.SalsePriceConsTax;     // 売上金額消費税額         (Int64)

            //// ↑ 2008.03.24 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////


            //// ↓ 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////////////////////////////////
            ////dr[MAHNB02349EA.CT_SalesConf_GoodsCodeRF]            = saleConfWork.GoodsCode;            // 商品コード         (string)
            ////dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = saleConfWork.GoodsName;            // 商品名称           (string)
            //// ↑ 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////////////////////////////////

            //// ↓ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////
            ////dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF]     = saleConfWork.SalesSubtotalTax;     // 売上小計(税)       (Int64)
            ////dr[MAHNB02349EA.CT_SalesConf_CustomerName2RF]        = saleConfWork.CustomerName2;        // 得意先名称2        (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesFormCodeRF]        = saleConfWork.SalesFormCode;        // 販売形態コード     (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesFormNameRF]        = saleConfWork.SalesFormName;        // 販売形態名称       (string)
            ////dr[MAHNB02349EA.CT_SalesConf_SalesSlipExpNumRF]      = saleConfWork.SalesSlipExpNum;      // 売上詳細番号       (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_CarrierCodeRF]          = saleConfWork.CarrierCode;          // キャリアコード     (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_CarrierNameRF]          = saleConfWork.CarrierName;          // キャリア名称       (string)
            ////dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreCodeRF]  = saleConfWork.LargeGoodsGanreCode;  // 商品大分類コード   (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreNameRF]  = saleConfWork.LargeGoodsGanreName;  // 商品大分類名称     (string)
            ////dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreCodeRF] = saleConfWork.MediumGoodsGanreCode; // 商品中分類コード   (Int32)
            ////dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreNameRF] = saleConfWork.MediumGoodsGanreName; // 商品中分類名称     (string)
            ////dr[MAHNB02349EA.CT_SalesConf_CellphoneModelCodeRF]   = saleConfWork.CellphoneModelCode;   // 機種コード         (string)
            ////dr[MAHNB02349EA.CT_SalesConf_CellphoneModelNameRF]   = saleConfWork.CellphoneModelName;   // 機種名称           (string)
            ////dr[MAHNB02349EA.CT_SalesConf_ProductNumber1RF]       = saleConfWork.ProductNumber1;       // 製造番号1          (string)
            ////dr[MAHNB02349EA.CT_SalesConf_ProductNumber2RF]       = saleConfWork.ProductNumber2;       // 製造番号2          (string)
            ////dr[MAHNB02349EA.CT_SalesConf_StockTelNo1RF]          = saleConfWork.StockTelNo1;          // 商品電話番号1      (string)
            ////dr[MAHNB02349EA.CT_SalesConf_StockTelNo2RF]          = saleConfWork.StockTelNo2;          // 商品電話番号2      (string)
            //// ↑ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////

            //// ↓ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////
            ////if ((saleConfWork.SalesSlipExpNum == 0) ||
            ////    (saleConfWork.SalesSlipExpNum == 1))
            ////{
            ////// 明細単位出力の場合、もしくは詳細単位出力の一行目の場合のみ出力

            //    dr[MAHNB02349EA.CT_SalesConf_ShipmentCntRF]          = saleConfWork.ShipmentCnt;          // 売上数             (double)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxExcFlRF]   = saleConfWork.SalesUnPrcTaxExcFl;   // 売上単価（税抜き） (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_CostRF]                 = saleConfWork.Cost;                 // 原価               (Int64)

 
            //    //dr[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF]        = saleConfWork.IncentiveDtbt;        // 支払インセンティブ額(Int64)
            //    //dr[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF]        = saleConfWork.IncentiveRecv;        // 受取インセンティブ額(Int64)
            //    //salesMoney = saleConfWork.SalesMoneyTaxExc - saleConfWork.IncentiveDtbt;
            //    //cost = saleConfWork.Cost - saleConfWork.IncentiveRecv;
            //    //dr[MAHNB02349EA.CT_SalesConf_GrossProfitRF]          = salesMoney - cost;                 // 粗利金額           (Int64)
            ////}

            ////else
            ////{
            ////    dr[MAHNB02349EA.CT_SalesConf_SalesCountRF]           = 0;                             // 売上数             (double)
            ////    dr[MAHNB02349EA.CT_SalesConf_SalesUnitPriceTaxExcRF] = 0;                             // 売上単価（税抜き） (Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF]     = 0;                             // 売上金額（税抜き） (Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_CostRF]                 = 0;                             // 原価               (Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF]        = 0;                             // 支払インセンティブ額(Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF]        = 0;                             // 受取インセンティブ額(Int64)
            ////    dr[MAHNB02349EA.CT_SalesConf_GrossProfitRF]          = 0;                             // 粗利金額           (Int64)
            ////}
            //// ↑ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////
            
            
            //long total    = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc);           // 消費税の算出(伝票)
            //long totalDtl = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);           // 消費税の算出(明細)
            //long DisTltInclu = saleConfWork.SalesDisTtlTaxInclu - saleConfWork.SalesDisTtlTaxExc;      // 値引き消費税の算出
            //long SalesMoneyRF= 0;                                                                      // 売上伝票合計(売上／商品)
            //long SalesIncRF= 0;                                                                        // 売上伝票合計(消費税／商品)        
            //long BalanceAdjustmentRF = 0;                                                              // 売上伝票合計(売上／残高調整)
            //long ConsumptionTaxAdjustmentRF = 0;                                                       // 売上伝票合計(消費税／消費税調整)

            //long SalesMoney = 0;                                                                       // 売上明細合計(売上／商品)
            //long SalesInc = 0;                                                                         // 売上明細合計(消費税／商品)        
            //long BalanceAdjustment = 0;                                                                // 売上明細合計(売上／残高調整)
            //long ConsumptionTaxAdjustment = 0;                                                         // 売上明細合計(消費税／消費税調整)
            
            //// 伝票(0→商品 2→消費税 3→ 残高調整 4→ 売掛消費税 5→売掛残高)
            //if ((saleConfWork.SalesGoodsCd == 2) || (saleConfWork.SalesGoodsCd == 4))
            //{
            //    dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF] = 0;                                  // 売上金額(税抜) (伝票) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF] = saleConfWork.SalesSubtotalTax;               // 売上小計（税） (伝票) (Int64)

            //    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF] = 0;                                  // 売上金額（税抜）(明細) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF] = saleConfWork.SalsePriceConsTax;           // 売上金額消費税額       (Int64)

            //    // 合計値(売上消費税)
            //    ConsumptionTaxAdjustmentRF = (saleConfWork.SalesSubtotalTax);
            //    ConsumptionTaxAdjustment = (saleConfWork.SalsePriceConsTax);
         
            //}
            //else if ((saleConfWork.SalesGoodsCd == 3) || (saleConfWork.SalesGoodsCd == 5))
            //{
            //    dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF] = saleConfWork.SalesTotalTaxInc;      // 売上金額(税込) (伝票) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF] = 0;                                           // 売上小計（税）(伝票) (Int64)


            //    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF] = saleConfWork.SalesMoneyTaxExc;      // 売上金額（税抜）(明細) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF] = 0;                                        // 消費税(明細)

            //    //合計値(売上合計金額(税抜))
            //    BalanceAdjustmentRF = (saleConfWork.SalesTotalTaxInc);
            //    BalanceAdjustment = (saleConfWork.SalesMoneyTaxExc);
            //}
            //else
            //{
            //    dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF] = saleConfWork.SalesTotalTaxExc;     // 売上金額(税抜) (伝票) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF] = total;                                      // 消費税(伝票)
                

            //    dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF] = saleConfWork.SalesMoneyTaxExc;     // 売上金額（税抜）(明細) (Int64)
            //    dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF] = totalDtl;                                // 消費税(明細)

            //    //合計値
            //    // 売上合計金額(税抜き)
            //    SalesMoneyRF = (saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc);
            //    // 売上消費税
            //    SalesIncRF = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - DisTltInclu);

            //    SalesMoney = (saleConfWork.SalesMoneyTaxExc);
            //    SalesInc = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);
                
            //}
            
            //// 売上伝票区分(伝票)(SalesSlipCd → 0=売上、1=返品)
            //if (saleConfWork.SalesSlipCd == 0)
            //{                
            //    // 売上数のカウント(伝票)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberRF] = 1;
                
            //    // 売上合計原価金額(税抜き)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesCostRF] = (saleConfWork.TotalCost);
                
            //    // 売上合計金額
            //    dr[MAHNB02349EA.CT_SalesConf_TotalMeterRF] = SalesMoneyRF + BalanceAdjustmentRF;

            //    // 消費税合計
            //    dr[MAHNB02349EA.CT_SalesConf_ConsumptionTaxTotalRF] = SalesIncRF + ConsumptionTaxAdjustmentRF;
               
            //    if (saleConfWork.SalesRowNo == 1)
            //    {
            //        // 売上数のカウント(明細)
            //        dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtlRF] = 1;
            //    }

            //}            
            
            //if (saleConfWork.SalesSlipCd == 1)
            //{
            //    // 返品数のカウント(伝票)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountRF] = 1;

            //    // 返品合計金額(税抜き)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoneyRF] = (saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxExc);

            //    // 返品消費税
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnSalesIncRF] = (saleConfWork.SalesTotalTaxInc - saleConfWork.SalesTotalTaxExc - saleConfWork.SalesDisTtlTaxInclu);

            //    // 返品合計原価金額(税抜き)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostRF] = (saleConfWork.TotalCost);

            //    if (saleConfWork.SalesRowNo == 1)
            //    {
            //        // 返品数のカウント(明細)
            //        dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtlRF] = 1;
            //    }

            //}


            //// 売上伝票区分(明細)(SalesSlipCdDtl → 0=売上、1=返品、2=値引)
            //if (saleConfWork.SalesSlipCdDtl == 0)
            //{

            //    //売上合計金額(明細)
            //    //dr[MAHNB02349EA.CT_SalesConf_SalesDtlRF] = (saleConfWork.SalesMoneyTaxExc);

            //    dr[MAHNB02349EA.CT_SalesConf_SalesDtlRF] = SalesMoney + BalanceAdjustment;

            //    //売上消費税(明細)
            //    //dr[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);

            //    dr[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF] = SalesInc + ConsumptionTaxAdjustment;

            //    // 売上合計原価(税抜き)(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesCostDtlRF] = (saleConfWork.Cost);
                
            //}

            //if (saleConfWork.SalesSlipCdDtl == 1)
            //{

            //    //返品合計金額(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnDtlRF] = (saleConfWork.SalesMoneyTaxExc);

            //    // 返品消費税(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_ReturnIncDtlRF] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);

            //    //返品合計原価(税抜き)(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtlRF] = (saleConfWork.Cost);

            //}

            //if (saleConfWork.SalesSlipCdDtl == 2)
            //{
            //    //値引き合計金額(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_DistDtlRF] = (saleConfWork.SalesMoneyTaxExc);

            //    //値引き消費税(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_DistIncDtlRF] = (saleConfWork.SalesMoneyTaxInc - saleConfWork.SalesMoneyTaxExc);

            //    //値引き合計原価金額(税抜き)(明細)
            //    dr[MAHNB02349EA.CT_SalesConf_DistDtlCostRF] = (saleConfWork.Cost);

            //    // 値引き合計原価金額(伝票)
            //    dr[MAHNB02349EA.CT_SalesConf_DistCostRF] = (saleConfWork.Cost);
            //}
            // 2008.07.08 30413 犬飼 Row項目の全置き換えのため既存項目はコメント化 <<<<<<END
        }

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            // 2008.07.08 30413 犬飼 Row項目の全置き換えのため既存項目はコメント化 >>>>>>START
            //// 担当者別
            //dr[MAHNB02349EA.CT_SalesConf_SectionCodeRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SectionCodeRF];          // 拠点コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SectionGuideNmRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SectionGuideNmRF];       // 拠点ガイド名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDateRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDateRF];            // 売上日付           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_ShipmentDayRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_ShipmentDayRF];          // 出荷日付           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerCodeRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_CustomerCodeRF];         // 得意先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CustomerSnmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_CustomerSnmRF];          // 得意先名称         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNumRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipNumRF];         // 売上伝票番号       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesRowNoRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesRowNoRF];           // 売上行番号         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_DebitNoteDivRF];         // 赤伝区分           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_DebitNoteDivNmRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_DebitNoteDivNmRF];       // 赤伝区分名         (string)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivCdRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_AccRecDivCdRF];          // 売掛区分           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AccRecDivNmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_AccRecDivNmRF];          // 売掛区分名         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeCdRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesEmployeeCdRF];      // 販売従業員コード   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesEmployeeNmRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesEmployeeNmRF];      // 販売従業員名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_ShipmentCntRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_ShipmentCntRF];          // 出荷数             (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxExcFlRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxExcFlRF];   // 売上単価（税抜き） (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxExcRF];     // 売上金額（税込み） (Int64)          
            //dr[MAHNB02349EA.CT_SalesConf_CostRF]                 = sourceDataRow[MAHNB02349EA.CT_SalesConf_CostRF];                 // 原価               (Int64)         
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipCdRF];          // 売上伝票区分       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipNmRF];          // 売上伝票区分名     (string)

            //// ↓ 2007.11.08 keigo yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_SearchSlipDateRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SearchSlipDateRF];       // 入力日付           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AddUpADateRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddUpADateRF];           // 計上日付(請求日)   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesAreaCodeRF];        // 販売エリアコード   (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesAreaNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesAreaNameRF];        // 販売エリア名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNoRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsNoRF];              // 商品番号           (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsNameRF];            // 商品名称           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_UnitCodeRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_UnitCodeRF];             // 単位コード         (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_UnitNameRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_UnitNameRF];             // 単位名称           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionCodeRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SubSectionCodeRF];       // 部門コード         (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SubSectionNameRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SubSectionNameRF];       // 部門名称           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionCodeRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_MinSectionCodeRF];       // 課コード           (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MinSectionNameRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_MinSectionNameRF];       // 課名称             (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimCodeRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_ClaimCodeRF];            // 請求先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_ClaimSnmRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_ClaimSnmRF];             // 請求先略称         (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeCodeRF];        // 納品先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeNameRF];        // 納品先名称         (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeName2RF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeName2RF];       // 納品先名称2        (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeCdRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_FrontEmployeeCdRF];      // 受付従業員コード   (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_FrontEmployeeNmRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_FrontEmployeeNmRF];      // 受付従業員名称     (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_AcptAnOdrStatusRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_AcptAnOdrStatusRF];      // 受注ステータス     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesGoodsCdRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesGoodsCdRF];         // 売上商品区分       (Int32)            
            //dr[MAHNB02349EA.CT_SalesConf_PartySaleSlipNumRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_PartySaleSlipNumRF];     // 相手先伝票番号     (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkSlip]    = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginMarkSlip];    // 粗利チェックマーク(伝票) (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginMarkDtl]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginMarkDtl];     // 粗利チェックマーク(明細) (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyRF];           // 売上金額 (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyPrt]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyPrt];          // 売上金額 (String)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesMoneyRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesMoneyRF];     // 売上合計金額 (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesCostRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCostRF];            // 売上合計原価(税抜き)(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_TotalCostRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_TotalCostRF];            // 原価金額計         (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SlipNoteRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_SlipNoteRF];             // 伝票備考           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipCdDtlRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipCdDtlRF];       // 売上伝票区分(明細) (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipNmDtlRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipNmDtlRF];       // 売上伝票区分名称(明細)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsMakerCdRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsMakerCdRF];         // 商品メーカーコード (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MakerNameRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_MakerNameRF];            // メーカー名称       (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_StdUnPrcSalUnPrcRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_StdUnPrcSalUnPrcRF];     // 基準単価(売上単価) (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxIncFlRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesUnPrcTaxIncFlRF];   // 売上単価(税込)     (double)
            //dr[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxIncRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesMoneyTaxIncRF];     // 売上金額(税込)     (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesUnitCostRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesUnitCostRF];        // 原価単価           (double)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierCdRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_SupplierCdRF];           // 仕入先コード       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SupplierSnmRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SupplierSnmRF];          // 仕入先名称1        (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_PartySlipNumDtlRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_PartySlipNumDtlRF];      // 相手先伝票番号(明細)(stirng)
            //dr[MAHNB02349EA.CT_SalesConf_DtlNoteRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_DtlNoteRF];              // 明細備考           (stirng)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRate]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginRate];        // 粗利率(伝票)       (double)
            //dr[MAHNB02349EA.CT_SalesConf_GrossMarginRateDtl]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossMarginRateDtl];     // 粗利率(明細)       (double)      
            //dr[MAHNB02349EA.CT_SalesConf_DelayPaymentDivRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_DelayPaymentDivRF];      // 来勘区分      (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesTotalTaxExcRF];     // 売上伝票合計(税抜き)(伝票) (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesTotalTaxIncRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesTotalTaxIncRF];     // 売上伝票合計(税込み)(伝票)   (Int64)    
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxExcRF]    = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxExcRF];    // 売上値引金額計(税抜)(伝票)    (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxIncluRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDisTtlTaxIncluRF];  // 売上値引金額計(税込)(伝票)    (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_TransactionNameRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_TransactionNameRF];      // 取引区分(伝票)      (Int64)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputCodeRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesinputCodeRF];       // 入力者コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesinputNameRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesinputNameRF];       // 入力者名称           (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesDtlRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDtlRF];             // 売上合計金額(税抜き)(明細)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnDtlRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnDtlRF];            // 売上返品合計(税抜き)(明細)
            //dr[MAHNB02349EA.CT_SalesConf_DistDtlRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistDtlRF];              // 売上値引き合計(税抜き)(明細)
            //dr[MAHNB02349EA.CT_SalesConf_ConsTaxRF]              = sourceDataRow[MAHNB02349EA.CT_SalesConf_ConsTaxRF];              //消費税(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_ConsTaxDtlRF];           //消費税(明細)
            //dr[MAHNB02349EA.CT_SalesConf_SalesIncRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesIncRF];             // 売上消費税(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesIncRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesIncRF];       // 返品消費税(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesIncDtlRF];          // 売上消費税(明細)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnIncDtlRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnIncDtlRF];         // 返品消費税(明細)
            //dr[MAHNB02349EA.CT_SalesConf_DistIncDtlRF]           = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistIncDtlRF];           // 値引き消費税(明細)
            //dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCountnumberRF];     // 売上数(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesCountRF];     // 返品数(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtlRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCountnumberDtlRF];  // 売上数(明細)
            //dr[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtlRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_ReturnSalesCountDtlRF];  // 返品数(明細)
            //dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesReturnCostRF];      // 返品合計原価金額(伝票)  
            //dr[MAHNB02349EA.CT_SalesConf_SalesCostDtlRF]         = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesCostDtlRF];         //売上合計原価(税抜き)(明細)    
            //dr[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtlRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesReturnCostDtlRF];   //返品合計原価(税抜き)(明細)   
            //dr[MAHNB02349EA.CT_SalesConf_DistDtlCostRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistDtlCostRF];          //値引き合計原価金額(税抜き)(明細)
            //dr[MAHNB02349EA.CT_SalesConf_DistCostRF]             = sourceDataRow[MAHNB02349EA.CT_SalesConf_DistCostRF];             //値引き合計原価金額(税抜き)(伝票)
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_WarehouseCodeRF];        //倉庫コード
            //dr[MAHNB02349EA.CT_SalesConf_WarehouseNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_WarehouseNameRF];        //倉庫名称

            //// ↓変更予定あり////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_AddresseeAddrRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_AddresseeAddrRF];        //納品先住所(郵便番号、都道府県市区郡・町村・字、丁目、番地、アパート名称)
            //// ↑変更予定あり////////////////////////////////////////////////////////

            //// ↑ 2007.11.08 keigo yata Add //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //// ↓ 2008.03.24 keigo yata Add //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxIncRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxIncRF];   // 売上小計(税抜き)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxExcRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxExcRF];   // 売上小計(税込み)
            //dr[MAHNB02349EA.CT_SalesConf_SalseNetPriceRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalseNetPriceRF];         // 売上正価金額
            //dr[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSubtotalTaxRF];      // 売上小計（税)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesOutTaxRF]     = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesOutTaxRF];      // 売上外税対象額
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesInTaxRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesInTaxRF];       // 売上内税対象額
            //dr[MAHNB02349EA.CT_SalesConf_SalSubttlSubToTaxFreRF] = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalSubttlSubToTaxFreRF];  // 売上小計非課税対象額
            //dr[MAHNB02349EA.CT_SalesConf_SalseOutTaxRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalseOutTaxRF];           // 売上金額消費税額（外税)
            //dr[MAHNB02349EA.CT_SalesConf_SalAmntConsTaxIncluRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalAmntConsTaxIncluRF];   // 売上金額消費税額（内税)
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisOutTaxRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesDisOutTaxRF];   // 売上値引外税対象額合計
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalesDisInTaxRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalesDisInTaxRF];    // 売上値引内税対象額合計
            //dr[MAHNB02349EA.CT_SalesConf_ItdedSalseDisTaxFreRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_ItdedSalseDisTaxFreRF];   // 売上値引非課税対象額合計
            //dr[MAHNB02349EA.CT_SalesConf_SalesDisOutTaxRF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesDisOutTaxRF];        // 売上値引消費税額（外税)
            //dr[MAHNB02349EA.CT_SalesConf_SalsePriceConsTaxRF]    = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalsePriceConsTaxRF];     // 売上金額消費税額

            // ↑ 2008.03.24 keigo yata Add //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 2008.07.08 30413 犬飼 Row項目の全置き換えのため既存項目はコメント化 <<<<<<END
            
            // ↓ 2007.11.08 keigo yata Change ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_GoodsCodeRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsCodeRF];            // 商品コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_GoodsNameRF]            = sourceDataRow[MAHNB02349EA.CT_SalesConf_GoodsNameRF];            // 商品名称           (string)
            // ↑ 2007.11.08 keigo yata Change //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // ↓ 2007.11.08 keigo yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[MAHNB02349EA.CT_SalesConf_CustomerName2RF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_CustomerName2RF];        // 得意先名称2        (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesFormCodeRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesFormCodeRF];        // 販売形態コード     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_SalesFormNameRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesFormNameRF];        // 販売形態名称       (string)
            //dr[MAHNB02349EA.CT_SalesConf_SalesSlipExpNumRF]      = sourceDataRow[MAHNB02349EA.CT_SalesConf_SalesSlipExpNumRF];      // 売上詳細番号       (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CarrierCodeRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_CarrierCodeRF];          // キャリアコード     (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_CarrierNameRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_CarrierNameRF];          // キャリア名称       (string)
            //dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreCodeRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreCodeRF];  // 商品大分類コード   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreNameRF]  = sourceDataRow[MAHNB02349EA.CT_SalesConf_LargeGoodsGanreNameRF];  // 商品大分類名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreCodeRF] = sourceDataRow[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreCodeRF]; // 商品中分類コード   (Int32)
            //dr[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreNameRF] = sourceDataRow[MAHNB02349EA.CT_SalesConf_MediumGoodsGanreNameRF]; // 商品中分類名称     (string)
            //dr[MAHNB02349EA.CT_SalesConf_CellphoneModelCodeRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_CellphoneModelCodeRF];   // 機種コード         (string)
            //dr[MAHNB02349EA.CT_SalesConf_CellphoneModelNameRF]   = sourceDataRow[MAHNB02349EA.CT_SalesConf_CellphoneModelNameRF];   // 機種名称           (string)
            //dr[MAHNB02349EA.CT_SalesConf_ProductNumber1RF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_ProductNumber1RF];       // 製造番号1          (string)
            //dr[MAHNB02349EA.CT_SalesConf_ProductNumber2RF]       = sourceDataRow[MAHNB02349EA.CT_SalesConf_ProductNumber2RF];       // 製造番号2          (string)
            //dr[MAHNB02349EA.CT_SalesConf_StockTelNo1RF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_StockTelNo1RF];          // 商品電話番号1      (string)
            //dr[MAHNB02349EA.CT_SalesConf_StockTelNo2RF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_StockTelNo2RF];          // 商品電話番号2      (string)
            //dr[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_IncentiveDtbtRF];        // 支払インセンティブ額(Int64)
            //dr[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF]        = sourceDataRow[MAHNB02349EA.CT_SalesConf_IncentiveRecvRF];        // 受取インセンティブ額(Int64)
            //dr[MAHNB02349EA.CT_SalesConf_GrossProfitRF]          = sourceDataRow[MAHNB02349EA.CT_SalesConf_GrossProfitRF];          // 粗利金額           (Int64)
            
            // ↑ 2007.11.08 keigo yata Delete //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //dr[SFURI06225EA.CT_CsSaleChkList_AddUpADateStr    ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.AddUpADate);  // 計上日付(印刷用)　(string)
            //dr[SFURI06225EA.CT_CsSaleChkList_PublicationStr   ] = TDateTime.DateTimeToString("ggYY.MM.DD",agentSalesOdrWork.Publication); // 売上日付(印刷用)　(string)
            //dr[SFURI06225EA.CT_CsSaleChkList_CorporateDivName ] = DivCdCnvStrDivNm((Int32)dr["CorporateDivCode"]); //個人・法人区分(印刷用)　(string)
        }
        
        /// <summary>
        /// 伝票形式 名称化処理
        /// </summary>
        private string GetSalesSlipNm(int salesSlipCd)
        {
            string wkStr = "";

            switch (salesSlipCd)
            {
                case 0:
                    {
                        wkStr = "売上";
                        break;
                    }
                case 1:
                    {
                        wkStr = "返品";
                        break;
                    }
                //case 2:
                //    {
                //        wkStr = "値引";
                //        break;
                //    }
            }

            return wkStr;
        }

       
        // ↓ 2007.11.08 keigo yata Delete //////////////////////////////////////////////
        /// <summary>
        /// 明細形式 名称化処理
        /// </summary>
        private string GetSalesSlipNmDtl(int salesSlipCdDtl)
        {
            string wkStr = "";

            switch (salesSlipCdDtl)
            {
                case 0:
                    {
                        wkStr = ""; // 売上
                        break;
                    }
                case 1:
                    {
                        wkStr = "返品";
                        break;
                    }
                case 2:
                    {
                        wkStr = "値引";
                        break;
                    }
                case 3:
                    {
                        wkStr = "注釈";
                        break;
                    }
                case 9:
                    {
                        wkStr = "一式";
                        break;
                    }
            }

            return wkStr;
        }
        // ↑ 2007.11.08 keigo yata Delete //////////////////////////////////////////////

        /// <summary>
        /// 赤伝区分 名称化処理
        /// </summary>
        private string GetDebitNoteDivNm(int debitNoteDiv)
        {
            string wkStr = "";

            switch (debitNoteDiv)
            {
                case 0:
                    {
                        wkStr = "";//黒伝
                        break;
                    }
                case 1:
                    {
                        wkStr = "赤伝";
                        break;
                    }
                case 2:
                    {
                        wkStr = "元黒";
                        break;
                    }
            }

            return wkStr;
        }

        /// <summary>
        /// 売掛区分 名称化処理
        /// </summary>
        private string GetAccRecDivNm(int accRecDivCd)
        {
            string wkStr = "";

            switch (accRecDivCd)
            {
                case 0:
                    {
                        wkStr = "売掛なし";
                        break;
                    }
                case 1:
                    {
                        wkStr = "売掛あり";
                        break;
                    }
            }

            return wkStr;
        }

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        // 2010/07/01 Add >>>
        /// <summary>
        /// 全角⇒半角変換
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private static string GetKanaString(string orgString)
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }
        // 2010/07/01 Add <<<

		#endregion
	}
}