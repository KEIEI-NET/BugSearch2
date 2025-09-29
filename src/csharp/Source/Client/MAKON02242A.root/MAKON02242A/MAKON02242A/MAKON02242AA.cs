//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入確認表
// プログラム概要   : 仕入確認表アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 谷藤　範幸
// 作 成 日  2005/01/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/07/16  修正内容 : データ項目の追加/修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/12/02  修正内容 : dayliheaderのキーブレイクに仕入SEQ番号を追加
//                                : ソート条件の伝票番号の後に仕入SEQ番号を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/28  修正内容 : 不具合対応[10599]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/14  修正内容 : 消費税転嫁方式[伝票][明細]以外は非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 畠中 啓次朗
// 修 正 日  2009/07/17  修正内容 : 明細タイプの消費税金額を
//                                  消費税転嫁方式[明細]以外は非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 3H 尹安
// 修 正 日  2020/02/27  修正内容 : 11570208-00 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳艶丹
// 修 正 日  2022/09/28   修正内容 : 11800255-00　インボイス対応（税率別合計金額不具合修正）
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    using StockConfNames        = MAKON02249EA; // ADD 2008/10/07 不具合対応[5664]
    using StockConfSlipTtlNames = MAKON02249EB; // ADD 2008/10/07 不具合対応[5664]

	/// <summary>
    /// 仕入チェックリストアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入順位表にアクセスするクラスです</br>
    /// <br>Programer  : 22021　谷藤　範幸</br>
    /// <br>Date       : 2005.01.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ・データ項目の追加/修正</br>
    /// <br>Programmer	: 30415 柴田 倫幸</br>
    /// <br>Date		: 2008/07/16</br>
    /// <br>UpdateNote	: ・dayliheaderのキーブレイクに仕入SEQ番号を追加</br>
    /// <br>            : ・ソート条件の伝票番号の後に仕入SEQ番号を追加</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2008/12/02</br>
    /// <br>UpdateNote  : 2009/01/28 照田 貴志　不具合対応[10599]</br>
    /// <br>UpdateNote  : 2009/04/14 上野 俊治　消費税転嫁方式[伝票][明細]以外は非表示に修正</br>
    /// <br>UpdateNote	: 2020/02/27 3H 尹安 11570208-00 軽減税率対応</br>
    /// <br>UpdateNote	: 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）</br>
    /// </remarks>
	public class StockConfAcs
	{
  	    // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
	    #region public constant
	    /// <summary>全拠点レコード用拠点コード</summary>
        public const string CT_AllSectionCode = "000000";
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

		/// <summary>仕入確認表(明細単位)データテーブル名</summary>
        private string _StockConfDataTable;
		/// <summary>仕入確認表(伝票単位)データテーブル名</summary>
		private string _StockConfSlipTtlDataTable;

        /// <summary>表示順位</summary>
		private string CT_Sort1_Odr = "StockDateRF, SupplierSlipNoRF, StockRowNoRF";                                // 仕入日→伝票番号
		private string CT_Sort2_Odr = "CustomerCodeRF, StockDateRF, SupplierSlipNoRF, StockRowNoRF";                                // 仕入日→伝票番号
		private string CT_Sort3_Odr = "InputDayRF, SupplierSlipNoRF, StockRowNoRF";                                // 仕入日→伝票番号
		private string CT_Sort4_Odr = "CustomerCodeRF, InputDayRF, SupplierSlipNoRF, StockRowNoRF";                                // 仕入日→伝票番号
		private string CT_Sort5_Odr = "SupplierSlipNoRF, StockRowNoRF";                                             // 伝票番号

        private string CT_UpperOrder = " ASC";   // 昇順出力
        //private string CT_DownOrder  = " DESC";  // 降順出力

        // ADD 2008/10/15 不具合対応[5651]---------->>>>>
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

        // ADD 2008/10/15 不具合対応[5651]----------<<<<<
        // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        /// <summary>カウント済みの伝票キーリスト</summary>
        private readonly IList<string> _countedTaxFreeSlipKeyList = new List<string>();
        /// <summary>
        /// カウント済みの伝票キーリストを取得します。
        /// </summary>
        /// <value>カウント済みの伝票キーリスト</value>
        private IList<string> CountedTaxFreeSlipKeyList
        {
            get { return _countedTaxFreeSlipKeyList; }
        }
        // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
        // --- ADD START 3H 尹安 2020/02/27---------->>>>>
        private int _iTaxPrintDiv;  // 税別内訳印字有無区分
        private Double _taxRate1;   // 税率１
        private Double _taxRate2;   // 税率２
        // --- ADD END 3H 尹安 2020/02/27----------<<<<<
	    #endregion
        
        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant
	  
		///// <summary>仕入順位表バッファデータテーブル名</summary>
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

		private const string ct_DateFormat = "yyyy/MM/dd";
        #endregion
        
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
		#region コンストラクター
       
		/// <summary>
        /// 仕入順位表アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021 谷藤　範幸</br>
        /// <br>Date       : 2005.01.30</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public StockConfAcs()
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
        /// 仕入順位表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 22021　谷藤　範幸</br>
        /// <br>Date       : 2006.01.31</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static StockConfAcs()
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
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			prtOutSet  = null;
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
    	/// 仕入順位表データ初期化処理
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
			if(this._printDataSet.Tables[_StockConfDataTable] != null)
			{
				this._printDataSet.Tables[_StockConfDataTable].Rows.Clear();
			}
			// 抽出結果バッファデータテーブルをクリア
            if (_printBuffDataSet.Tables[_StockConfDataTable] != null)
			{
                _printBuffDataSet.Tables[_StockConfDataTable].Rows.Clear();
			}
			// 仕入確認表(伝票単位)抽出結果データテーブルをクリア
			if (this._printDataSet.Tables[_StockConfSlipTtlDataTable] != null)
			{
				this._printDataSet.Tables[_StockConfSlipTtlDataTable].Rows.Clear();
			}
		}

        /// <summary>
        /// 仕入順位表データ取得処理
        /// </summary>
        /// <param name="stockConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_MAKON02247E stockConfListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch(mode)
            {
                case 0:
                    {
                        status = this.Search(stockConfListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        //status = this.SearchStatic(out message);
                        //if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //{
                            status = this.Search(stockConfListCndtn, out message);
                        //}
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
        /// 仕入順位表スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;
            
            this._printDataSet.Tables[_StockConfDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_StockConfDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_StockConfDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_StockConfDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_StockConfDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_StockConfDataTable].Rows.Add(dr);
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
		/// 仕入順位表データ取得処理
		/// </summary>
        /// <param name="stockConfListCndtn"></param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 対象範囲の仕入チェックリストデータを取得します。</br>
		/// <br>Programmer : 22021　谷藤　範幸</br>
		/// <br>Date       : 2006.01.31</br>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
		/// </remarks>
		private int Search(ExtrInfo_MAKON02247E stockConfListCndtn, out string message)
		{
			object retObj;
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		    message    = "";
			try
			{
                // --- ADD START 3H 尹安 2020/02/27---------->>>>>
                _iTaxPrintDiv = stockConfListCndtn.TaxPrintDiv;　　// 税別内訳印字有無区分
                _taxRate1 = 0;                                     // 税率１
                _taxRate2 = 0;                                     // 税率２
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(stockConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(stockConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H 尹安 2020/02/27----------<<<<<

				// StaticMemory　初期化
				InitializeCustomerLedger();

                // リモートからデータの取得
                StockConfShWork stockConfShWork = new StockConfShWork();
                // 抽出条件パラメータセット
                this.SearchParaSet(stockConfListCndtn, ref stockConfShWork);

                status = this.SearchByMode(out retObj, stockConfShWork);

				ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // --- DEL 2008/07/16 -------------------------------->>>>>
                    //DataRow stockDr = null;
                    //bool existExplaFlg = true;   // 詳細情報有無フラグ
                    //int prevSupplierSlipNo = 0;  // 前回伝票番号
                    //int prevStockRowNo = 0;      // 前回行番号
                    // --- DEL 2008/07/16 --------------------------------<<<<< 

					// 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr;

                        dr = this._printDataSet.Tables[_StockConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i, stockConfListCndtn);

						

#if False
                        if (stockConfListCndtn.PrintDiv == 1)
                        {
#endif
						// 明細タイプの場合
						this._printDataSet.Tables[_StockConfDataTable].Rows.Add(dr);
#if False
						}
                        else
                        {
                            // 伝票番号、または行番号が変わったら
                            if ((prevSupplierSlipNo != 0) &&
                                (prevStockRowNo != 0))
                            {
                                if ((prevSupplierSlipNo != int.Parse(dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString())) ||
                                    (prevStockRowNo != int.Parse(dr[MAKON02249EA.CT_StockConf_StockRowNoRF].ToString())))
                                {
                                    if (stockDr != null)
                                    {
                                        if (existExplaFlg == false)
                                        {
                                            // 他に詳細情報を持つ明細が無い場合、詳細行番号をクリア
                                            stockDr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;
                                        }
                                        // 保持しておいた製番空白明細の書き込み
                                        this._printDataSet.Tables[_StockConfDataTable].Rows.Add(stockDr);
                                    }

                                    // 明細保持情報クリア
                                    stockDr = null;
                                    existExplaFlg = true;
                                }
                            }
#if False
                            // 詳細タイプの場合(詳細情報なしの明細をまとめるための処理)
                            if ((dr[MAKON02249EA.CT_StockConf_ProductNumber1RF].ToString() == "") &&
                                (dr[MAKON02249EA.CT_StockConf_ProductNumber2RF].ToString() == "") &&
                                (dr[MAKON02249EA.CT_StockConf_StockTelNo1RF].ToString() == "") &&
                                (dr[MAKON02249EA.CT_StockConf_StockTelNo2RF].ToString() == ""))
                            {
                                if (stockDr == null)
                                {
                                    // 製造番号空白の詳細明細を保管
                                    stockDr = dr;
                                }
                                else
                                {
                                    if ((prevSupplierSlipNo == int.Parse(dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString())) &&
                                        (prevStockRowNo == int.Parse(dr[MAKON02249EA.CT_StockConf_StockRowNoRF].ToString())))
                                    {
                                        existExplaFlg = false;
                                    }
                                }
                            }
                            else
                            {
#endif
							this._printDataSet.Tables[_StockConfDataTable].Rows.Add(dr);

#if False
							}
#endif

							// 前回伝票番号、行番号の保持
                            prevSupplierSlipNo = int.Parse(dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString());
                            prevStockRowNo = int.Parse(dr[MAKON02249EA.CT_StockConf_StockRowNoRF].ToString());
                        }
#endif
					}

#if False
					// 最終保持明細の書込
                    if (stockDr != null)
                    {
                        if (existExplaFlg == false)
                        {
                            // 他に詳細情報を持つ明細が無い場合、詳細行番号をクリア
                            stockDr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;
                        }
                        // 保持しておいた製番空白明細の書き込み
                        this._printDataSet.Tables[_StockConfDataTable].Rows.Add(stockDr);
                    }
#endif

                    // 明細保持情報クリア
                    // --- DEL 2008/07/16 -------------------------------->>>>>
                    //stockDr = null;
                    //existExplaFlg = true;
                    // --- DEL 2008/07/16 --------------------------------<<<<< 
                    this._printDataSet.AcceptChanges();

                    // ADD 2008/10/07 不具合対応[5664]---------->>>>>
                    this._printDataSet = CreateSortedDataSet(
                        this._printDataSet.Tables[_StockConfDataTable],
                        GetOrderByPhraseOfStockConf(stockConfListCndtn)
                    );
                    // ADD 2008/10/07 不具合対応[5664]----------<<<<<

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
				status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}


            #region テストデータ
#if false
            DataRow ab;
            int j;

            for (j = 1; j < 10; j++)
            {
                ab = this._printDataSet.Tables[_StockConfDataTable].NewRow();

                //if (j > 7)
                //{
                //    ab[MAKON02249EA.CT_StockConf_SectionCodeRF] = "02";                                     // 拠点コード         (string)
                //}
                //else
                //{
                    ab[MAKON02249EA.CT_StockConf_SectionCodeRF] = "01";                                     // 拠点コード         (string)
                //}

                ab[MAKON02249EA.CT_StockConf_SectionGuideNmRF] = "テスト拠点名称１１１";                      // 拠点ガイド名称     (string)  // ADD 2008/07/16

                if (j == 1)
                {
                    ab[MAKON02249EA.CT_StockConf_StockDateRF] = DateTime.Parse("2008/06/24");               // 仕入日付           (DateTime)
                }
                else
                {
                    ab[MAKON02249EA.CT_StockConf_StockDateRF] = DateTime.Parse("2008/06/25");               // 仕入日付           (DateTime)
                }

                ab[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF] = DateTime.Parse("2008/06/24");         // 出荷日付           (DateTime)
                ab[MAKON02249EA.CT_StockConf_InputDayRF] = DateTime.Parse("2008/06/24");                // 入力日付           (DateTime)
                ab[MAKON02249EA.CT_StockConf_StockAddUpADateRF] = DateTime.Parse("2008/06/24");	        // 仕入計上日付       (DateTime)
                ab[MAKON02249EA.CT_StockConf_StockDateStringRF] = DateTime.Parse("2008/06/24");			// 仕入日付(印刷用)     (DateTime)
                ab[MAKON02249EA.CT_StockConf_ArrivalGoodsDayStringRF] = "2008/06/24";                   // 出荷日付(印刷用)     (DateTime)
                ab[MAKON02249EA.CT_StockConf_InputDayStringRF] = "2008/06/24";			                // 入力日付(印刷用)     (DateTime)
                ab[MAKON02249EA.CT_StockConf_StockAddUpADateStringRF] = DateTime.Parse("2008/06/24");	// 仕入計上日付(印刷用) (DateTime)

                //if (j < 3)
                //{
                //    ab[MAKON02249EA.CT_StockConf_SupplierCd] = "999999";                    // 仕入先コード       (Int32)
                //}
                //else
                //{
                    ab[MAKON02249EA.CT_StockConf_SupplierCd] = "999998";                    // 仕入先コード       (Int32)
                //}

                ab[MAKON02249EA.CT_StockConf_SupplierSnm] = "テスト仕入先略称１１２２２２２";  // 仕入先略称
                ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF] = j.ToString();      // 相手先伝票番号 (string)
                ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF] = j;       // 仕入伝票番号       (Int32)

                string aaa, bbb;
                aaa = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString();
                bbb = ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString();

                //ヘッダー部DataField設定
                ab[MAKON02249EA.CT_StockConf_groupHeader1DataField] = aaa.PadLeft(2, '0') + bbb.PadLeft(6, '0');

                int sort = 1;
                // 仕入先→伝票日付→伝票番号
                if (sort == 1)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF].ToString();
                }
                // 仕入先→入力日付→伝票番号
                else if (sort == 3)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_InputDayRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_InputDayRF].ToString()
                                                                        + ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF].ToString();
                }
                // 仕入先→伝票番号
                else if (sort == 4)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF].ToString();
                }
                else if (sort == 5)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString();
                }
                else if (sort == 6)
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                    + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString();

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_StockDateRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString();
                }
                else
                {
                    ab[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                    ab[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = ab[MAKON02249EA.CT_StockConf_SectionCodeRF].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierCd].ToString()
                                                                       + ab[MAKON02249EA.CT_StockConf_SupplierSlipNoRF].ToString();
                }

                ab[MAKON02249EA.CT_StockConf_SupplierSlipNote1RF] = "テスト仕入伝票備考１２２２２２２２２２２３３３３３３３３３３"; // 備考１
                ab[MAKON02249EA.CT_StockConf_SupplierSlipNote2RF] = "テスト仕入伝票備考2";                                           // 備考２

                ab[MAKON02249EA.CT_StockConf_BfListPriceRF] = 111111111;        // 変更前定価  // ADD 2008/07/16
                ab[MAKON02249EA.CT_StockConf_ListPriceFlRF] = 111111111;  // 定価

                // 仕入伝票区分名
                ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = 10;
                ab[MAKON02249EA.CT_StockConf_EnterpriseGanreCodeRF] = 20;	                 //自社分類コード
                ab[MAKON02249EA.CT_StockConf_EnterpriseGanreNameRF] = "テスト自社分類名称";
                ab[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = 111111;			                 // メーカーコード
                ab[MAKON02249EA.CT_StockConf_GoodsNameRF] = "テスト商品名称１１１";    // 商品名称
                ab[MAKON02249EA.CT_StockConf_GoodsCodeRF] = "111111111122222222223333";                           // 商品コード
                ab[MAKON02249EA.CT_StockConf_WarehouseCodeRF] = "600";                       // 倉庫コード
                ab[MAKON02249EA.CT_StockConf_StockOrderDivNmRF] = "在取区分";                // 在取区分名
                ab[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = 11111111;                            // BLコード

                ab[MAKON02249EA.CT_StockConf_StockRowNoRF] = 15;               // 仕入行番号         (Int32)
                ab[MAKON02249EA.CT_StockConf_DebitNoteDivRF] = 2;              // 赤伝区分           (Int32)
                ab[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF] = "テスト赤伝"; // 赤伝区分名 (string)
                ab[MAKON02249EA.CT_StockConf_AccPayDivCdRF] = 1;               // 買掛区分           (Int32)
                ab[MAKON02249EA.CT_StockConf_AccPayDivNmRF] = "テスト買掛区分名";
                ab[MAKON02249EA.CT_StockConf_StockAgentCodeRF] = "100";        // 仕入担当者コード   (string)
                ab[MAKON02249EA.CT_StockConf_StockAgentNameRF] = "テスト仕入担当者名称";
                ab[MAKON02249EA.CT_StockConf_SupplierSlipCdRF] = 20;           // 仕入伝票区分       (Int32)
                ab[MAKON02249EA.CT_StockConf_SupplierSlipNmRF] = this.GetSupplierSlipNm(20);
                ab[MAKON02249EA.CT_StockConf_FirstRowFlg] = 9;                 // 先頭出力明細フラグ (Int32)
                // 明細単位出力の場合、もしくは詳細単位出力の一行目の場合のみ出力
                ab[MAKON02249EA.CT_StockConf_StockCountRF] = 11111111;               // 仕入数             (double)
                ab[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = 111111111;          // 仕入単価           (Int64)
                ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = 999999999999;       // 仕入金額           (Int64)
                ab[MAKON02249EA.CT_StockConf_TaxRF] = 111111111111;       // 仕入金額消費税額

                ab[MAKON02249EA.CT_StockConf_StockPriceTaxIncRF] = Int64.Parse(ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) + Int64.Parse(ab[MAKON02249EA.CT_StockConf_TaxRF].ToString());

                ab[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = 111111111;             // 変更前仕入単価 
                ab[MAKON02249EA.CT_StockConf_MakerNameRF] = "テストメーカー名称";           // メーカー名称
                ab[MAKON02249EA.CT_StockConf_WarehouseNameRF] = "テスト倉庫名称１１１";    // 倉庫名称
                ab[MAKON02249EA.CT_StockConf_SalesSlipNum] = 111111111;                    // 売上伝票番号
                ab[MAKON02249EA.CT_StockConf_StockDtiSlipNote1RF] = "";     // 仕入伝票明細備考1
                ab[MAKON02249EA.CT_StockConf_CustomerCodeRF] = 111111;                   // 得意先コード
                ab[MAKON02249EA.CT_StockConf_UoeRemark1] = "99999999991111111111";
                ab[MAKON02249EA.CT_StockConf_UoeRemark2] = "9999999999";

                ab[MAKON02249EA.CT_StockConf_FirstRowFlg] = 1;             // 先頭出力明細フラグ (Int32)
                ab[MAKON02249EA.CT_StockConf_StockRowNoRF] = 123;          // 仕入詳細番号       (Int32)
                ab[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;        // 仕入詳細番号       (Int32)

                //10:仕入
                if ((int)ab[MAKON02249EA.CT_StockConf_SupplierSlipCdRF] == 10)
                {
                    // 伝票枚数(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                    // 伝票枚数(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
                    // 伝票枚数(合計)
                    ab[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                    // 仕入金額(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF];
                    // 消費税(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = ab[MAKON02249EA.CT_StockConf_TaxRF];
                    // 合計金額(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = Int64.Parse(ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) + Int64.Parse(ab[MAKON02249EA.CT_StockConf_TaxRF].ToString());

                    // 仕入金額(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = 0;
                    // 消費税(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = 0;
                    // 合計金額(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = 0;
                }
                //20:仕入
                else
                {
                    // 伝票枚数(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalCntRF] = 0;
                    // 伝票枚数(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                    // 伝票枚数(合計)
                    ab[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                    // 仕入金額(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = 0;
                    // 消費税(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = 0;
                    // 合計金額(仕入)
                    ab[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = 0;

                    // 仕入金額(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF];
                    // 消費税(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = ab[MAKON02249EA.CT_StockConf_TaxRF];
                    // 合計金額(返品値引)
                    ab[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = Int64.Parse(ab[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) + Int64.Parse(ab[MAKON02249EA.CT_StockConf_TaxRF].ToString());
                }

                this._printDataSet.AcceptChanges();

                // バッファテーブルへの格納
                _printBuffDataSet = this._printDataSet.Copy();
                // 明細タイプの場合
                this._printDataSet.Tables[_StockConfDataTable].Rows.Add(ab);
            }
            status = 0;
#endif
            #endregion


      		return status;
        }

        // ADD 2008/10/07 不具合対応[5664]---------->>>>>
        /// <summary>
        /// 出力順（ソート順）の列挙体<br/>
        /// ※画面の出力順コンボボックスの値と同値
        /// </summary>
        /// <remarks>
        /// <br>Note       : 不具合対応[5664]にて追加</br>
        /// <br>Programmer : 30434　工藤　恵優</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private enum SortOrder : int
        {
            /// <summary>なし</summary>
            None = 0,

            /// <summary>仕入先→仕入日→伝票番号</summary>
            SupplierCd_StockDate_PartySaleSlipNum = 1,
            /// <summary>仕入先→入力日→伝票番号</summary>
            SupplierCd_InputDay_PartySaleSlipNum = 3,
            /// <summary>仕入先→伝票番号</summary>
            SupplierCd_PartySaleSlipNum = 4,

            /// <summary>仕入先→仕入日→仕入SEQ番号</summary>
            SupplierCd_StockDate_SupplierSlipNo = 5,
            /// <summary>仕入先→入力日→仕入SEQ番号</summary>
            SupplierCd_InputDay_SupplierSlipNo = 6,
            /// <summary>仕入先→仕入SEQ番号</summary>
            SupplierCd_SupplierSlipNo = 7
        }

        /// <summary>
        /// 仕入確認表(明細単位)のソート条件(ORDER BY句)を取得します。
        /// </summary>
        /// <param name="sortConditionInfo">ソート条件の情報</param>
        /// <returns>仕入確認表(明細単位)のソート条件のORDER BY句</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5664]にて追加</br>
        /// <br>Programmer : 30434　工藤　恵優</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private static string GetOrderByPhraseOfStockConf(ExtrInfo_MAKON02247E sortConditionInfo)
        {
            string orderBy = StockConfNames.CT_StockConf_SectionCodeRF + "," + StockConfNames.CT_StockConf_SupplierCd;

            switch (sortConditionInfo.SortOrder)
            {
                case (int)SortOrder.SupplierCd_StockDate_SupplierSlipNo:    // 仕入先→仕入日→仕入SEQ番号
                    orderBy += "," + StockConfNames.CT_StockConf_StockDateRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_SupplierSlipNo:     // 仕入先→入力日→仕入SEQ番号
                    orderBy += "," + StockConfNames.CT_StockConf_InputDayRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_SupplierSlipNo:              // 仕入先→仕入SEQ番号
                    orderBy += "," + StockConfNames.CT_StockConf_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_PartySaleSlipNum:   // 仕入先→入力日→伝票番号→仕入SEQ番号
                    orderBy += "," + StockConfNames.CT_StockConf_InputDayRF + "," + StockConfNames.CT_StockConf_PartySaleSlipNumRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                case (int)SortOrder.SupplierCd_PartySaleSlipNum:            // 仕入先→伝票番号→仕入SEQ番号
                    orderBy += "," + StockConfNames.CT_StockConf_PartySaleSlipNumRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                default:// 仕入先→仕入日→伝票番号→仕入SEQ番号
                    orderBy += "," + StockConfNames.CT_StockConf_StockDateRF + "," + StockConfNames.CT_StockConf_PartySaleSlipNumRF + "," + StockConfNames.CT_StockConf_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
            }

            return orderBy;
        }

        /// <summary>
        /// 仕入確認表(伝票単位)のソート条件(ORDER BY句)を取得します。
        /// </summary>
        /// <param name="sortConditionInfo">ソート条件の情報</param>
        /// <returns>仕入確認表(伝票単位)のソート条件のORDER BY句</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5664]にて追加</br>
        /// <br>Programmer : 30434　工藤　恵優</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private static string GetOrderByPhraseOfStockConfSlipTtl(ExtrInfo_MAKON02247E sortConditionInfo)
        {
            string orderBy = StockConfSlipTtlNames.CT_StockConfSlipTtl_SectionCodeRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierCd;
            
            switch (sortConditionInfo.SortOrder)
            {
                case (int)SortOrder.SupplierCd_StockDate_SupplierSlipNo:    // 仕入先→仕入日→仕入SEQ番号
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_StockDateRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_SupplierSlipNo:     // 仕入先→入力日→仕入SEQ番号
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_InputDayRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_SupplierSlipNo:              // 仕入先→仕入SEQ番号
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF;
                    break;
                case (int)SortOrder.SupplierCd_InputDay_PartySaleSlipNum:   // 仕入先→入力日→伝票番号→仕入SEQ番号
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_InputDayRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_PartySaleSlipNumRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                case (int)SortOrder.SupplierCd_PartySaleSlipNum:            // 仕入先→伝票番号→仕入SEQ番号
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_PartySaleSlipNumRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
                default:// 仕入先→仕入日→伝票番号→仕入SEQ番号
                    orderBy += "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_StockDateRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_PartySaleSlipNumRF + "," + StockConfSlipTtlNames.CT_StockConfSlipTtl_SupplierSlipNoRF; // ADD 2008/12/02
                    break;
            }

            return orderBy;
        }

        /// <summary>
        /// ソートされた仕入確認表データセットを生成します。
        /// </summary>
        /// <param name="originalDataTable">元テーブル</param>
        /// <param name="orderBy">ソート条件</param>
        /// <returns>ソートされた仕入確認表データセット</returns>
        /// <remarks>
        /// <br>Note       : 不具合対応[5664]にて追加</br>
        /// <br>Programmer : 30434　工藤　恵優</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private static DataSet CreateSortedDataSet(
            DataTable originalDataTable,
            string orderBy
        )
        {
            DataSet dataSet = new DataSet();
            DataSetColumnConstruction(ref dataSet);

            DataRow[] sortedRows = originalDataTable.Select("", orderBy);

            foreach (DataRow dataRow in sortedRows)
            {
                dataSet.Tables[originalDataTable.TableName].Rows.Add(dataRow.ItemArray);
            }

            return dataSet;
        }
        // ADD 2008/10/07 不具合対応[5664]----------<<<<<

		/// <summary>
		/// データ取得処理(伝票形式)
		/// </summary>
		/// <param name="stockConfListCndtn"></param>
		/// <param name="message"></param>
		/// <returns></returns>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
		public int SearchSlipTtl(ExtrInfo_MAKON02247E stockConfListCndtn, out string message)
		{
			object retObj = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			message = "";

			try
			{
                // --- ADD START 3H 尹安 2020/02/27---------->>>>>
                _iTaxPrintDiv = stockConfListCndtn.TaxPrintDiv;　　// 税別内訳印字有無区分
                _taxRate1 = 0;                                     // 税率１
                _taxRate2 = 0;                                     // 税率２
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    double.TryParse(stockConfListCndtn.TaxRate1, out _taxRate1);
                    double.TryParse(stockConfListCndtn.TaxRate2, out _taxRate2);
                }
                // --- ADD END 3H 尹安 2020/02/27----------<<<<<

				// StaticMemory　初期化
				InitializeCustomerLedger();

				// リモートからデータの取得
				StockConfShWork stockConfShWork = new StockConfShWork();
				// 抽出条件パラメータセット
				this.SearchParaSet(stockConfListCndtn, ref stockConfShWork);

	            IStockConfDB _iStockConfDB = (IStockConfDB)MediationStockConfDB.GetStockConfDB();
				status = _iStockConfDB.SearchSlipTtl(out retObj, stockConfShWork);

				ArrayList retList = new ArrayList();
				retList = (ArrayList)retObj;

				if ((status == 0) && (retList.Count != 0))
				{
					// 情報取得
					for (int i = 0; i < retList.Count; i++)
					{
						DataRow dr;

						dr = this._printDataSet.Tables[_StockConfSlipTtlDataTable].NewRow();
						SetStockConfSlipTtlDataTableRowFromRetList(ref dr, retList, i);

						this._printDataSet.Tables[_StockConfSlipTtlDataTable].Rows.Add(dr);
					}

                    // ADD 2008/10/07 不具合対応[5664]---------->>>>>
                    this._printDataSet = CreateSortedDataSet(
                        this._printDataSet.Tables[_StockConfSlipTtlDataTable],
                        GetOrderByPhraseOfStockConfSlipTtl(stockConfListCndtn)
                    );
                    // ADD 2008/10/07 不具合対応[5664]----------<<<<<

					status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}


                #region テストデータ
#if false
                DataRow ab;

                for (int j = 1; j < 34; j++)
                {
                    ab = this._printDataSet.Tables[_StockConfSlipTtlDataTable].NewRow();

                    //if (j > 3)
                    //{
                    //    // 拠点コード
                    //    ab[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF] = "02";
                    //}
                    //else
                    //{
                        // 拠点コード
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF] = "01";
                    //}

                    // 拠点ガイド名称
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SectionGuideNmRF] = "テストガイド名称１１";

                    //if (j < 2)
                    //{
                    //    // 仕入先コード
                    //    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd] = 999999;
                    //}
                    //else
                    //{
                        // 仕入先コード
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd] = 999998;
                    //}

                    // 仕入先略称
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSnm] = "テスト仕入先１１１１２２２２２";

                    // 入力日付
                    ab[MAKON02249EB.CT_StockConfSlipTtl_InputDayRF] = DateTime.Parse("2008/06/25");
                    // 入力日付(印刷)
                    ab[MAKON02249EB.CT_StockConfSlipTtl_InputDayNmRF] = "2008/06/25";

                    // 入荷日付
                    ab[MAKON02249EB.CT_StockConfSlipTtl_ArrivalGoodsDayRF] = DateTime.Parse("2008/06/25");
                    // 入力日付(印刷)
                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockDateRF] = "2008/06/25";
                    // 仕入日付(印刷)
                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockDateNmRF] = "2008/06/25";

                    // 仕入形式
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalRF] = 0;
                    // 仕入形式名
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalNmRF] = GetSupplierFormalNm(0);
                    // 仕入伝票番号
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNoRF] = 999999999;
                    // 相手先伝票番号
                    ab[MAKON02249EB.CT_StockConfSlipTtl_PartySaleSlipNumRF] = "9999999999888888888";
                    // 仕入伝票区分
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipCdRF] = 10;
                    // 仕入伝票区分名
                    ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = this.GetSupplierSlipNm(10);


                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] = 2;


                    long slipTtl_StockPriceTaxInc = 0;

                    if (((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 2) || ((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 4))
                    {
                        // 仕入金額計（税抜き）
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 999999999999;
                        // 仕入金額消費税額
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 999999999999;

                        //合計値
                        slipTtl_StockPriceTaxInc = 999999999999;
                    }
                    else if (((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 3) || ((int)ab[MAKON02249EB.CT_StockConfSlipTtl_StockGoodsCdRF] == 5))
                    {
                        // 仕入金額計（税抜き）
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 999999999999;
                        // 仕入金額消費税額
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 999999999999;

                        //合計値
                        slipTtl_StockPriceTaxInc = 999999999999;
                    }
                    else
                    {
                        // 仕入金額計（税抜き）
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 999999999999;
                        // 仕入金額消費税額
                        ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 999999999999;

                        //合計値
                        slipTtl_StockPriceTaxInc = 999999999999;
                    }

                    ab[MAKON02249EB.CT_StockConfSlipTtl_StockPriceTaxIncRF] = slipTtl_StockPriceTaxInc;

                    string aaa, bbb;
                    aaa = ab[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF].ToString();
                    bbb = ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd].ToString();
                    ab[MAKON02249EB.COL_KEYBREAK_AR] = aaa.PadLeft(2, '0') + bbb.PadLeft(6, '0');

                    //10:仕入
                    if ((int)ab[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipCdRF] == 10)
                    {
                        // 伝票枚数(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 1;
                        // 伝票枚数(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 0;
                        // 伝票枚数(合計)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

                        // 仕入金額(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = 999999999999;
                        // 消費税(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 999999999999;
                        // 合計金額(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = 999999999999;

                        // 仕入金額(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = 0;
                        // 消費税(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;
                        // 合計金額(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = 0;
                    }
                    //20:仕入
                    else
                    {
                        // 伝票枚数(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 0;
                        // 伝票枚数(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 1;
                        // 伝票枚数(合計)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

                        // 仕入金額(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = 0;
                        // 消費税(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 0;
                        // 合計金額(仕入)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = 0;

                        // 仕入金額(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = 999999999999;
                        // 消費税(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 999999999999;
                        // 合計金額(返品値引)
                        ab[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = 999999999999;
                    }

                    ab[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark1] = "テストＵＯＥリマーク";
                    ab[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark2] = "リマーク２";

                    this._printDataSet.Tables[_StockConfSlipTtlDataTable].Rows.Add(ab);
                }

                status = 0;
#endif
                #endregion

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
        private void SearchParaSet(ExtrInfo_MAKON02247E stockConfListCndtn, ref     StockConfShWork stockConfShWork)
        {
            stockConfShWork.EnterpriseCode = stockConfListCndtn.EnterpriseCode;  // 企業コード

            // 拠点
			if (stockConfListCndtn.StockSectionCd.Length != 0)
            {
				if (stockConfListCndtn.StockSectionCd[0] == "0")
                {
                    // 全社の時
					stockConfShWork.StockSectionCd = new string[0];  // 拠点コード
                    stockConfShWork.IsOutputAllSecRec = true;
                    stockConfShWork.IsSelectAllSection = true;
                }
                else
                {
					stockConfShWork.StockSectionCd = stockConfListCndtn.StockSectionCd;  // 拠点コード
                    stockConfShWork.IsSelectAllSection = false;
                    // 全拠点にチェックがつけられているかどうかのチェック
					if (_secInfoAcs.SecInfoSetList.Length == stockConfListCndtn.StockSectionCd.Length)
                    {
                        stockConfShWork.IsOutputAllSecRec = true;
                    }
                    else
                    {
                        stockConfShWork.IsOutputAllSecRec = false;
                    }
                }
            }
            else
            {
				stockConfShWork.StockSectionCd = new string[0];  // 拠点コード
                stockConfShWork.IsOutputAllSecRec = true;        // 全拠点集計レコードでの出力
                stockConfShWork.IsSelectAllSection = false;
            }

            stockConfShWork.StockDateSt = stockConfListCndtn.StockDateSt;                // 開始仕入日
            stockConfShWork.StockDateEd = stockConfListCndtn.StockDateEd;                // 終了仕入日
            stockConfShWork.ArrivalGoodsDaySt = stockConfListCndtn.ArrivalGoodsDaySt;    // 開始出荷日
            stockConfShWork.ArrivalGoodsDayEd = stockConfListCndtn.ArrivalGoodsDayEd;    // 終了出荷日

			stockConfShWork.InputDaySt = stockConfListCndtn.InputDaySt;			         // 開始入力日
			stockConfShWork.InputDayEd = stockConfListCndtn.InputDayEd;				     // 終了入力日
			stockConfShWork.PrintType = stockConfListCndtn.PrintType;	                 // 発行タイプ
			stockConfShWork.PartySaleSlipNumSt = stockConfListCndtn.PartySaleSlipNumSt;  // 開始相手先伝票番号
			stockConfShWork.PartySaleSlipNumEd = stockConfListCndtn.PartySaleSlipNumEd;  // 終了相手先伝票番号

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //stockConfShWork.CustomerCodeSt = stockConfListCndtn.CustomerCodeSt;        // 開始得意先コード
            //stockConfShWork.CustomerCodeEd = stockConfListCndtn.CustomerCodeEd;        // 終了得意先コード
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            stockConfShWork.SupplierCdSt = stockConfListCndtn.SupplierCdSt;              // 仕入先コード(開始)
            stockConfShWork.SupplierCdEd = stockConfListCndtn.SupplierCdEd;              // 仕入先コード(終了)
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            stockConfShWork.StockAgentCodeSt = stockConfListCndtn.StockAgentCodeSt;      // 開始担当コード
            stockConfShWork.StockAgentCodeEd = stockConfListCndtn.StockAgentCodeEd;      // 終了担当コード
            stockConfShWork.SupplierSlipNoSt = stockConfListCndtn.SupplierSlipNoSt;      // 開始仕入伝票番号
            stockConfShWork.SupplierSlipNoEd = stockConfListCndtn.SupplierSlipNoEd;      // 終了仕入伝票番号
            stockConfShWork.DebitNoteDiv = stockConfListCndtn.DebitNoteDiv;              // 赤伝区分
            stockConfShWork.SupplierSlipCd = stockConfListCndtn.SupplierSlipCd;          // 伝票区分

            // --- ADD 2008/07/16 -------------------------------->>>>>
            stockConfShWork.SalesAreaCodeSt = stockConfListCndtn.SalesAreaCodeSt;        // 販売エリアコード(開始)

            // 販売エリアコード(終了)
            // DEL 2008/10/06 不具合対応[5653]↓
            //stockConfShWork.SalesAreaCodeEd = stockConfListCndtn.SalesAreaCodeEd;
            // ADD 2008/10/06 不具合対応[5653]---------->>>>>
            if (stockConfListCndtn.SalesAreaCodeEd >= 9999)
            {
                stockConfShWork.SalesAreaCodeEd = 0;
            }
            else
            {
                stockConfShWork.SalesAreaCodeEd = stockConfListCndtn.SalesAreaCodeEd;
            }
            // ADD 2008/10/06 不具合対応[5653]----------<<<<<

            stockConfShWork.OutputDesignated = stockConfListCndtn.OutputDesignated;      // 出力指定
            stockConfShWork.StockOrderDivCd = stockConfListCndtn.StockOrderDivCd;        // 仕入在庫取寄せ区分
            // --- ADD 2008/07/16 --------------------------------<<<<< 

        }

        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private static void DataSetColumnConstruction(ref DataSet ds)
		{
			// 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.MAKON02249EA.SettingDataSet(ref ds);
			Broadleaf.Application.UIData.MAKON02249EB.SettingDataSet(ref ds);
		}

        /// <summary>
        /// モード毎のSearch呼出処理
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="stockConfShWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
        private int SearchByMode(out object retObj, StockConfShWork stockConfShWork)
        {
            int status = 0;

            retObj = null;

            IStockConfDB _iStockConfDB = (IStockConfDB)MediationStockConfDB.GetStockConfDB();

            status = _iStockConfDB.Search(out retObj, stockConfShWork);

            return status;
        }

        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.12.06</br>
        /// </remarks>
        private string GetPrintOderQuerry(ExtrInfo_MAKON02247E stockConfListCndtn)
        {
            string orderQuerry = "";

            // ソート順設定
            switch (stockConfListCndtn.SortOrder)
            {
                case 0:
                    {
						// ＜削除＞伝票日付→伝票番号
                        orderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case 1:
                    {
						// 仕入先→伝票日付→伝票番号
                        orderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 2:
                    {
						// ＜削除＞入力日付→伝票番号
                        orderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case 3:
                    {
						// 仕入先→入力日付→伝票番号
                        orderQuerry = CT_Sort4_Odr;
                        break;
                    }
                case 4:
                    {
						// 仕入先→伝票番号
                        orderQuerry = CT_Sort5_Odr;
                        break;
                    }
            }

            // 昇順固定
            orderQuerry += CT_UpperOrder; 

            return orderQuerry;
        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            this._StockConfDataTable = Broadleaf.Application.UIData.MAKON02249EA.CT_StockConfDataTable;
			this._StockConfSlipTtlDataTable = Broadleaf.Application.UIData.MAKON02249EB.CT_StockConfSlipTtlDataTable;
		}


        /// <summary>
		/// 仕入確認表(伝票単位)抽出結果データテーブルRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
		private void SetStockConfSlipTtlDataTableRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
		{
            StockConfSlipTtlWork stockConfSlipTtlWork = (StockConfSlipTtlWork)retList[setCnt];

			// 拠点コード
            // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
            //dr[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF]	 = stockConfSlipTtlWork.SectionCode;
            dr[MAKON02249EB.CT_StockConfSlipTtl_SectionCodeRF] = stockConfSlipTtlWork.StockSectionCd;
            // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            // 拠点ガイド名称
			//dr[MAKON02249EB.CT_StockConfSlipTtl_SectionGuideNmRF] = stockConfSlipTtlWork.SectionGuideNm;  // DEL 2008/07/16
            dr[MAKON02249EB.CT_StockConfSlipTtl_SectionGuideNmRF] = stockConfSlipTtlWork.SectionGuideSnm;   // ADD 2008/07/16

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //// 得意先コード
            //dr[MAKON02249EB.CT_StockConfSlipTtl_CustomerCodeRF]	 = stockConfSlipTtlWork.CustomerCode;
            //// 得意先名称
            //dr[MAKON02249EB.CT_StockConfSlipTtl_CustomerSnmRF]	 = stockConfSlipTtlWork.CustomerSnm;
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 仕入先コード
            dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierCd] = stockConfSlipTtlWork.SupplierCd;
            // 仕入先略称
            dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSnm] = stockConfSlipTtlWork.SupplierSnm;
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            
            // 入力日付
			dr[MAKON02249EB.CT_StockConfSlipTtl_InputDayRF] = TDateTime.LongDateToDateTime(stockConfSlipTtlWork.InputDay);
			// 入力日付(印刷)
			//dr[MAKON02249EB.CT_StockConfSlipTtl_InputDayNmRF]	 = TDateTime.DateTimeToString("YYYY/MM/DD", stockConfSlipTtlWork.InputDay);  // DEL 2008/07/16
            dr[MAKON02249EB.CT_StockConfSlipTtl_InputDayNmRF] = TDateTime.LongDateToDateTime(stockConfSlipTtlWork.InputDay);                 // ADD 2008/07/16


			// 入荷日付
			dr[MAKON02249EB.CT_StockConfSlipTtl_ArrivalGoodsDayRF] = TDateTime.LongDateToDateTime(stockConfSlipTtlWork.ArrivalGoodsDay);
			// 入力日付(印刷)
			dr[MAKON02249EB.CT_StockConfSlipTtl_StockDateRF] = stockConfSlipTtlWork.StockDate;
			// 仕入日付(印刷)
			dr[MAKON02249EB.CT_StockConfSlipTtl_StockDateNmRF] = TDateTime.DateTimeToString("YYYY/MM/DD", stockConfSlipTtlWork.StockDate);

			// 仕入形式
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalRF] = stockConfSlipTtlWork.SupplierFormal;
			// 仕入形式名
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierFormalNmRF] = GetSupplierFormalNm(stockConfSlipTtlWork.SupplierFormal);
			// 仕入伝票番号
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNoRF] = stockConfSlipTtlWork.SupplierSlipNo;
			// 相手先伝票番号
			dr[MAKON02249EB.CT_StockConfSlipTtl_PartySaleSlipNumRF] = stockConfSlipTtlWork.PartySaleSlipNum;
			// 仕入伝票区分
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipCdRF] = stockConfSlipTtlWork.SupplierSlipCd;
			// 仕入伝票区分名
			dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = this.GetSupplierSlipNm(stockConfSlipTtlWork.SupplierSlipCd);


			long slipTtl_StockPriceTaxInc = 0;

            // 2009.01.29 30413 犬飼 仕入商品区分による設定を削除 >>>>>>START
            //if ((stockConfSlipTtlWork.StockGoodsCd == 2) || (stockConfSlipTtlWork.StockGoodsCd == 4))
            //{
            //    // 仕入金額計（税抜き）
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = 0;
            //    // 仕入金額消費税額
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;

            //    //合計値
            //    slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockPriceConsTax;
            //}
            //else if ((stockConfSlipTtlWork.StockGoodsCd == 3) || (stockConfSlipTtlWork.StockGoodsCd == 5))
            //{
            //    // 仕入金額計（税抜き）
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTotalPrice;
            //    // 仕入金額消費税額
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 0;

            //    //合計値
            //    slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockTotalPrice;
            //}
            //else
            //{
            //    // 仕入金額計（税抜き）
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;
            //    // 仕入金額消費税額
            //    dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;

            //    //合計値
            //    slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockSubttlPrice + stockConfSlipTtlWork.StockPriceConsTax;
            //}
            // 仕入金額計（税抜き）
            dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;

            // 2009.02.05 30413 値引きの集計処理ミス対応 >>>>>>START
            // 仕入金額消費税額
            //long stockPriceConsTax = stockConfSlipTtlWork.StockPriceConsTax; // DEL 2009/04/14
            long stockPriceConsTax = stockConfSlipTtlWork.StockTotalPrice - stockConfSlipTtlWork.StockSubttlPrice; // ADD 2009/04/14

            // 値引用の消費税額
            long disStockPriceConsTax = stockConfSlipTtlWork.StckDisTtlTaxInclu
                                      + stockConfSlipTtlWork.StockDisOutTax;
            // 仕入返品用の消費税額
            long salRetGdsStockPriceConsTax = stockPriceConsTax - disStockPriceConsTax;
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            string sConTaxRate = string.Empty;
            // 税別内訳印字の場合、
            if (_iTaxPrintDiv == 0)
            {
                // 消費税税率
                sConTaxRate = Convert.ToString(stockConfSlipTtlWork.SupplierConsTaxRate * 100) + "%";

                // 仕入
                // Title_税率1
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_Title] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_税率2
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_Title] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_その他
                dr[MAKON02249EB.CT_StockConfSlipTtl_Other_Title] = "その他";

                // 返品
                // Title_税率1
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetTitle] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_税率2
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetTitle] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_その他
                dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetTitle] = "その他";
                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                // Title_非課税
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_Title] = "非課税";
                // Title_非課税
                dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetTitle] = "非課税";
                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
            }
            // --- ADD START 3H 尹安 2020/02/27 -----<<<<<

            // 請求転嫁時の消費税設定
            if (
                stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ParentPayment)
                    ||
                stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ChildPayment)
                    ||
                stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption)
                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    ||
                (stockConfSlipTtlWork.TaxFreeExistFlag && !stockConfSlipTtlWork.TaxRateExistFlag)
                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
            )
            {
                stockPriceConsTax = 0;
                disStockPriceConsTax = 0;
                salRetGdsStockPriceConsTax = 0;
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // sConTaxRate = string.Empty;
                    if (stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip))
                    {
                        sConTaxRate = Convert.ToString(stockConfSlipTtlWork.SupplierConsTaxRate * 100) + "%";
                    }
                    else 
                    {
                        sConTaxRate = string.Empty;
                    }
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = stockPriceConsTax;
            // 2009.02.05 30413 値引きの集計処理ミス対応 <<<<<<END
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 税別内訳印字の場合、
            if (_iTaxPrintDiv == 0)
            {
                // 消費税税率
                dr[MAKON02249EB.CT_Col_ConsTaxRate] = sConTaxRate;
            }
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            
            //合計値
            slipTtl_StockPriceTaxInc = stockConfSlipTtlWork.StockSubttlPrice + stockPriceConsTax;
            // 2009.01.29 30413 犬飼 仕入商品区分による設定を削除 <<<<<<END
            
			// 仕入金額計（税込み）
			//dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
			//														+ stockConfSlipTtlWork.StockPriceConsTax;

			dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceTaxIncRF] = slipTtl_StockPriceTaxInc;

			//dr[MAKON02249EB.COL_KEYBREAK_AR] = stockConfSlipTtlWork.SectionCode + stockConfSlipTtlWork.CustomerCode.ToString("d9");  // DEL 2008/07/16
            // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
            //dr[MAKON02249EB.COL_KEYBREAK_AR] = stockConfSlipTtlWork.SectionCode + stockConfSlipTtlWork.SupplierCd.ToString("d6");      // ADD 2008/07/16
            dr[MAKON02249EB.COL_KEYBREAK_AR] = stockConfSlipTtlWork.StockSectionCd + stockConfSlipTtlWork.SupplierCd.ToString("d6");      // ADD 2008/07/16
            // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            
            // 2009.02.05 30413 値引きの集計処理ミス対応 >>>>>>START
            // 2009.01.09 30413 犬飼 返品と値引を分けて印字 >>>>>>START
			//10:仕入
			if (stockConfSlipTtlWork.SupplierSlipCd == 10)
			{
				// 伝票枚数(仕入)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 1;
				// 伝票枚数(返品値引)
				dr[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 0;
				// 伝票枚数(合計)
				dr[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

                // 2009.01.29 30413 犬飼 仕入金額、消費税、合計金額の設定を修正 >>>>>>START
                // 仕入金額(仕入)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTtlPricTaxExc;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;
                dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                             - stockConfSlipTtlWork.StckDisTtlTaxExc;
				// 消費税(仕入)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = stockPriceConsTax;
                dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
				// 合計金額(仕入)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
                //                                                    + stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = slipTtl_StockPriceTaxInc;
                dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                     - stockConfSlipTtlWork.StckDisTtlTaxExc
                                                                     + salRetGdsStockPriceConsTax;
                // 2009.01.29 30413 犬飼 仕入金額、消費税、合計金額の設定を修正 <<<<<<END
                
                //// 仕入金額(返品値引)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = 0;
                //// 消費税(返品値引)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;
                //// 合計金額(返品値引)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = 0;
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                    //if (stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag)) 
                    {
                        // 仕入枚数_非課税
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_SalSlipCntRF] = 1;
                        // 仕入金額_非課税
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        // 仕入消費税_非課税
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_StockPriceConsTaxRF] = 0;
                        // 仕入の消費税込合計金額_非課税
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                    }

                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag) && !stockConfSlipTtlWork.TaxRateExistFlag)
                    {
                        // 処理なし
                    }
                    else
                    {
                        // 税率２
                        if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // 仕入枚数_税率２
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_SalSlipCntRF] = 1;
                            // 仕入金額_税率２
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf; ;
                            // 税率２
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // 仕入の消費税込合計金額_税率２
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // 仕入枚数_税率１
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_SalSlipCntRF] = 1;
                            // 仕入金額_税率１
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // 仕入消費税_税率１
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // 仕入の消費税込合計金額_税率１
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else
                        {
                            // 仕入枚数_その他
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_SalSlipCntRF] = 1;
                            // 仕入金額_その他
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // 仕入消費税_その他
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // 仕入の消費税込合計金額_その他
                            // dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_StockPriceTaxIncRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;

                        }
                    }
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
			}
			//20:返品
			else
			{
				// 伝票枚数(仕入)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalSlipCntRF] = 0;
				// 伝票枚数(返品値引)
				dr[MAKON02249EB.CT_StockConfSlipTtl_DisSlipCntRF] = 1;
				// 伝票枚数(合計)
				dr[MAKON02249EB.CT_StockConfSlipTtl_TotleSlipCntRF] = 1;

				// 仕入金額(仕入)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = 0;
				// 消費税(仕入)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 0;
				// 合計金額(仕入)
				dr[MAKON02249EB.CT_StockConfSlipTtl_SalTotalPriceRF] = 0;

                //// 仕入金額(返品値引)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTtlPricTaxExc;
                //// 消費税(返品値引)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;
                //// 合計金額(返品値引)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
                //                                                    + stockConfSlipTtlWork.StockPriceConsTax;
                // 2009.01.29 30413 犬飼 仕入金額、消費税、合計金額の設定を修正 >>>>>>START
                // 仕入金額(返品)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockTtlPricTaxExc;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice;
                dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                                - stockConfSlipTtlWork.StckDisTtlTaxExc;
                // 消費税(返品)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = stockPriceConsTax;
                dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                // 合計金額(返品)
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockTtlPricTaxExc
                //                                                        + stockConfSlipTtlWork.StockPriceConsTax;
                //dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsTotalPriceRF] = slipTtl_StockPriceTaxInc;
                dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice
                                                                        - stockConfSlipTtlWork.StckDisTtlTaxExc
                                                                        + salRetGdsStockPriceConsTax;
                // 2009.01.29 30413 犬飼 仕入金額、消費税、合計金額の設定を修正 <<<<<<END
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                    // if (stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag)) 
                    {
                        // 仕入枚数_その他
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_DisSlipCntRF] = 1;
                        // 仕入金額(返品)_その他
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        // 仕入消費税(返品)_その他
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetGdsStockPriceConsTaxRF] = 0;
                        // 仕入の消費税込合計金額_その他
                        dr[MAKON02249EB.CT_StockConfSlipTtl_TaxFree_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                    }

                    if ((stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfSlipTtlWork.TaxFreeExistFlag) && !stockConfSlipTtlWork.TaxRateExistFlag)
                    {
                        //　処理なし
                    }
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    else
                    {
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 税率２
                        if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // 仕入枚数_税率２
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_DisSlipCntRF] = 1;
                            // 仕入金額(返品)_税率２
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // 仕入消費税(返品)_税率２
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // 仕入の消費税込合計金額_税率２
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate2_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else if (stockConfSlipTtlWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // 仕入枚数_税率１
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_DisSlipCntRF] = 1;
                            // 仕入金額(返品)_税率１
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // 仕入消費税(返品)_税率１
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // 仕入の消費税込合計金額_税率１
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_TaxRate1_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        else
                        {
                            // 仕入枚数_その他
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_DisSlipCntRF] = 1;
                            // 仕入金額(返品)_その他
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                            // 仕入消費税(返品)_その他
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsStockPriceConsTaxRF] = salRetGdsStockPriceConsTax;
                            // 仕入の消費税込合計金額_その他
                            //dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax;
                            dr[MAKON02249EB.CT_StockConfSlipTtl_Other_RetGdsTotalPriceRF] = stockConfSlipTtlWork.StockSubttlPrice - stockConfSlipTtlWork.StckDisTtlTaxExc + salRetGdsStockPriceConsTax - stockConfSlipTtlWork.StockPriceTaxFreeCrf;
                        }
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    }
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }

            // 仕入金額(値引)
            dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockConfSlipTtlWork.StckDisTtlTaxExc;
            // 消費税(値引)
            //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = stockConfSlipTtlWork.StckDisTtlTaxInclu
            //                                                            + stockConfSlipTtlWork.StockDisOutTax;
            dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = disStockPriceConsTax;
            // 合計金額(値引)
            //dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = stockConfSlipTtlWork.StckDisTtlTaxExc
            //                                                     + stockConfSlipTtlWork.StckDisTtlTaxInclu
            //                                                     + stockConfSlipTtlWork.StockDisOutTax;
            dr[MAKON02249EB.CT_StockConfSlipTtl_DisTotalPriceRF] = stockConfSlipTtlWork.StckDisTtlTaxExc
                                                                 + disStockPriceConsTax;
            // 2009.01.09 30413 犬飼 返品と値引を分けて印字 <<<<<<END
            // 2009.02.05 30413 値引きの集計処理ミス対応 <<<<<<END
            
            // --- ADD 2008/07/16 -------------------------------->>>>>

            dr[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark1] = stockConfSlipTtlWork.UoeRemark1;
            dr[MAKON02249EB.CT_StockConfSlipTtl_UoeRemark2] = stockConfSlipTtlWork.UoeRemark2;
            // --- ADD 2008/07/16 --------------------------------<<<<<

            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
            // 仕入先総額表示方法区分
            dr[MAKON02249EB.CT_StockConfSlipTtl_SuppTtlAmntDspWayCd] = stockConfSlipTtlWork.SuppTtlAmntDspWayCd;

            // 仕入先消費税転嫁方式コード
            dr[MAKON02249EB.CT_StockConfSlipTtl_SuppCTaxLayCd] = stockConfSlipTtlWork.SuppCTaxLayCd;

            // 仕入金額消費税額（内税）
            dr[MAKON02249EB.CT_StockConfSlipTtl_StckPrcConsTaxInclu] = stockConfSlipTtlWork.StckPrcConsTaxInclu;

            // 仕入値引消費税額
            dr[MAKON02249EB.CT_StockConfSlipTtl_StckDisTtlTaxInclu] = stockConfSlipTtlWork.StckDisTtlTaxInclu;

            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 >>>>>>START
            //// TODO:内税のみ印字用の細工
            //if (
            //    stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ParentPayment)
            //        ||
            //    stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ChildPayment)
            //        ||
            //    stockConfSlipTtlWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption)
            //)
            //{
            //    if (stockConfSlipTtlWork.StckPrcConsTaxInclu.Equals(0))
            //    {
            //        // [明細用]
            //        // 仕入金額
            //        long stockTtlPricTaxExc = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF];
            //        long stockPriceConsTax  = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_StockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        // 消費税
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_StockPriceConsTaxRF] = 0;

            //        // [合計フッター用]
            //        // 仕入
            //        stockTtlPricTaxExc  = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF];
            //        stockPriceConsTax   = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_SalStockPriceConsTaxRF] = 0;

            //        // 2009.01.09 30413 犬飼 返品と値引を分けて印字 >>>>>>START
            //        //// 返品値引
            //        //stockTtlPricTaxExc  = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF];
            //        //stockPriceConsTax   = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF];
            //        //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        //dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;

            //        // 返品
            //        stockTtlPricTaxExc = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF];
            //        stockPriceConsTax = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_RetGdsStockPriceConsTaxRF] = 0;

            //        // 値引
            //        stockTtlPricTaxExc = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF];
            //        stockPriceConsTax = (long)dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF];
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockTtlPricTaxExcRF] = stockTtlPricTaxExc + stockPriceConsTax;
            //        dr[MAKON02249EB.CT_StockConfSlipTtl_DisStockPriceConsTaxRF] = 0;
            //        // 2009.01.09 30413 犬飼 返品と値引を分けて印字 <<<<<<END
            //    }
            //}
            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 <<<<<<END
            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<
		}

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
		/// <param name="stockConfListCndtn">条件抽出クラス</param>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
		private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt, ExtrInfo_MAKON02247E stockConfListCndtn)
        {
            // 明細単位
            StockConfWork stockConfWork = (StockConfWork)retList[setCnt];
            // 拠点コード
            // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
            //dr[MAKON02249EA.CT_StockConf_SectionCodeRF] = stockConfWork.SectionCode;
            dr[MAKON02249EA.CT_StockConf_SectionCodeRF] = stockConfWork.StockSectionCd;
            // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            // 拠点ガイド名称
            dr[MAKON02249EA.CT_StockConf_SectionGuideNmRF] = stockConfWork.SectionGuideSnm;    

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 仕入先コード
            dr[MAKON02249EA.CT_StockConf_SupplierCd] = stockConfWork.SupplierCd;
            // 仕入先略称
            dr[MAKON02249EA.CT_StockConf_SupplierSnm] = stockConfWork.SupplierSnm;  
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // 仕入日付
            dr[MAKON02249EA.CT_StockConf_StockDateRF] = stockConfWork.StockDate;
            // 出荷日付
            dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF] = 
                                      TDateTime.LongDateToDateTime(stockConfWork.ArrivalGoodsDay);
            // 入力日付
			dr[MAKON02249EA.CT_StockConf_InputDayRF] = 
                                      TDateTime.LongDateToDateTime(stockConfWork.InputDay);
            // 仕入計上日付
			dr[MAKON02249EA.CT_StockConf_StockAddUpADateRF] = stockConfWork.StockAddUpADate;
            // 仕入日付(印刷用)
            dr[MAKON02249EA.CT_StockConf_StockDateStringRF] = GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayStringRF] = GetDateTimeString(stockConfWork.ArrivalGoodsDay, ct_DateFormat);    // 出荷日付(印刷用)     (DateTime)
			//dr[MAKON02249EA.CT_StockConf_InputDayStringRF]        = GetDateTimeString(stockConfWork.InputDay, ct_DateFormat);			// 入力日付(印刷用)     (DateTime)
            // --- DEL 2008/07/16 --------------------------------<<<<< 
            
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 出荷日付(印刷用)
            dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayStringRF] = GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.ArrivalGoodsDay), ct_DateFormat);
            // 入力日付(印刷用)
            dr[MAKON02249EA.CT_StockConf_InputDayStringRF] = GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat);
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // 仕入計上日付(印刷用)
            dr[MAKON02249EA.CT_StockConf_StockAddUpADateStringRF] = GetDateTimeString(stockConfWork.StockAddUpADate, ct_DateFormat);

			//ヘッダー部DataField設定
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_groupHeader1DataField] = stockConfWork.SectionCode
            //                                                    + stockConfWork.CustomerCode.ToString("d9");
            // --- DEL 2008/07/16 --------------------------------<<<<< 
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
            //dr[MAKON02249EA.CT_StockConf_groupHeader1DataField] = stockConfWork.SectionCode
            dr[MAKON02249EA.CT_StockConf_groupHeader1DataField] = stockConfWork.StockSectionCd
                                                                  + stockConfWork.SupplierCd.ToString("d6");
            // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            // --- ADD 2008/07/16 --------------------------------<<<<< 

			// TODO:仕入先→伝票日付→伝票番号→仕入先SEQ番号
			if (stockConfListCndtn.SortOrder == 1)
			{
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat)
                //                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                                + stockConfWork.SupplierCd.ToString("d6")
                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat)
                                                                + stockConfWork.PartySaleSlipNum.PadLeft(9, '0')
                                                                + stockConfWork.SupplierSlipNo.ToString("d9"); // ADD 2008/12/01
                // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
                // --- ADD 2008/07/16 --------------------------------<<<<< 
			}
            // 仕入先→入力日付→伝票番号→仕入先SEQ番号
			else if (stockConfListCndtn.SortOrder == 3)
			{
                // --- DEL 2008/07/16 -------------------------------->>>>>
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.InputDay, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + GetDateTimeString(stockConfWork.InputDay, ct_DateFormat)
                //                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                                    + stockConfWork.SupplierCd.ToString("d6")
                                                    + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat)
                                                                + stockConfWork.PartySaleSlipNum.PadLeft(9, '0')
                                                                + stockConfWork.SupplierSlipNo.ToString("d9"); // ADD 2008/12/01
                // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }
			// 仕入先→伝票番号
            else if (stockConfListCndtn.SortOrder == 4)
			{
				dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                // --- DEL 2008/07/16 -------------------------------->>>>>
                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                //                                                + stockConfWork.CustomerCode.ToString("d9")
                //                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // --- DEL 2008/07/16 --------------------------------<<<<< 

                // --- ADD 2008/07/16 -------------------------------->>>>>
                // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + stockConfWork.PartySaleSlipNum.PadLeft(9, '0')
                                                                + stockConfWork.SupplierSlipNo.ToString("d9"); // ADD 2008/12/01
                // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
                // --- ADD 2008/07/16 --------------------------------<<<<< 
            }
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 仕入先→仕入日付→仕入SEQ番号
            else if (stockConfListCndtn.SortOrder == 5)
            {
                // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                + stockConfWork.SupplierCd.ToString("d6")
                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(stockConfWork.StockDate, ct_DateFormat)
                                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            }
            // 仕入先→入力日付→仕入SEQ番号
            else if (stockConfListCndtn.SortOrder == 6)
            {
                // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = stockConfWork.StockSectionCd
                                    + stockConfWork.SupplierCd.ToString("d6")
                                    + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat);

                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                                + stockConfWork.SupplierCd.ToString("d6")
                                                                + GetDateTimeString(TDateTime.LongDateToDateTime(stockConfWork.InputDay), ct_DateFormat)
                                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            }
            // 仕入先→仕入SEQ番号
            else
            {
                dr[MAKON02249EA.CT_StockConf_groupHeader2DataField] = "";

                // 2009.02.25 30413 犬飼 拠点コードの変更 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.SectionCode
                dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField] = stockConfWork.StockSectionCd
                                                + stockConfWork.SupplierCd.ToString("d6")
                                                + stockConfWork.SupplierSlipNo.ToString("d9");
                // 2009.02.25 30413 犬飼 拠点コードの変更 <<<<<<END
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            //仕入伝票備考1
			dr[MAKON02249EA.CT_StockConf_SupplierSlipNote1RF] = stockConfWork.SupplierSlipNote1;
            //仕入伝票備考2
			dr[MAKON02249EA.CT_StockConf_SupplierSlipNote2RF] = stockConfWork.SupplierSlipNote2;
            // 相手先伝票番号
			dr[MAKON02249EA.CT_StockConf_PartySaleSlipNumRF] = stockConfWork.PartySaleSlipNum;

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = stockConfWork.CustomerCode;            // 得意先コード       (Int32)

            //dr[MAKON02249EA.CT_StockConf_CustomerSnmRF] = stockConfWork.CustomerSnm;		        // 得意先略名称         (string)
            //dr[MAKON02249EA.CT_StockConf_CustomerNameRF] = stockConfWork.CustomerSnm;             // 得意先名称1        (string)
            //dr[MAKON02249EA.CT_StockConf_CustomerName2RF] = stockConfWork.CustomerSnm;            // 得意先名称2        (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

			//dr[MAKON02249EA.CT_StockConf_UnitNameRF] = stockConfWork.UnitName;        // 単位名称  // DEL 2008/07/16

            // 変更前定価
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = stockConfWork.BfListPrice;
            if (stockConfWork.BfListPrice == 0)
            {
                dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = DBNull.Value;
            }
            else
            {
                // 2009.02.16 30413 犬飼 変更前定価の印字制御を修正 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = stockConfWork.BfListPrice;
                if (stockConfWork.BfListPrice == stockConfWork.ListPriceTaxExcFl)
                {
                    // 変更前定価と定価が同じ場合は、変更前定価は印字しない
                    dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = DBNull.Value;
                }
                else
                {
                    // 上記以外は印字する
                    dr[MAKON02249EA.CT_StockConf_BfListPriceRF] = stockConfWork.BfListPrice;
                }
                // 2009.02.16 30413 犬飼 変更前定価の印字制御を修正 <<<<<<END
            }

            // 定価
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_ListPriceFlRF] = stockConfWork.ListPriceTaxExcFl;
            if (stockConfWork.ListPriceTaxExcFl == 0)
            {
                dr[MAKON02249EA.CT_StockConf_ListPriceFlRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_ListPriceFlRF] = stockConfWork.ListPriceTaxExcFl;
            }

            // 仕入伝票区分名
            dr[MAKON02249EB.CT_StockConfSlipTtl_SupplierSlipNmRF] = this.GetSupplierSlipNm(stockConfWork.SupplierSlipCd);

			//dr[MAKON02249EA.CT_StockConf_OrderNumberRF] = stockConfWork.OrderFormNo;        // 注文書番号  // DEL 2008/07/16

            //自社分類コード
			dr[MAKON02249EA.CT_StockConf_EnterpriseGanreCodeRF] = stockConfWork.EnterpriseGanreCode;
            //自社分類名称
			dr[MAKON02249EA.CT_StockConf_EnterpriseGanreNameRF] = stockConfWork.EnterpriseGanreName;
            // メーカーコード
            // 2008.01.05 Modify [9490]
			//dr[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = stockConfWork.GoodsMakerCd;
            if (stockConfWork.GoodsMakerCd == 0)
            {
                dr[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_GoodsMakerCdRF] = stockConfWork.GoodsMakerCd;
            }
            // 商品名称
            dr[MAKON02249EA.CT_StockConf_GoodsNameRF] = stockConfWork.GoodsName;
            // 商品コード
			dr[MAKON02249EA.CT_StockConf_GoodsCodeRF] = stockConfWork.GoodsNo;
            // 倉庫コード
			dr[MAKON02249EA.CT_StockConf_WarehouseCodeRF] = stockConfWork.WarehouseCode;
            // 在取区分名
            // 2009.02.16 30413 犬飼 商品値引の場合、在取区分名を印字 >>>>>>START
            // 2008.01.05 Modify [9490]
            // 仕入伝票区分（明細）=2（値引）の時は表示しない
            //if (stockConfWork.StockSlipCdDtl == 2)
            if ((string.IsNullOrEmpty(stockConfWork.GoodsNo)) && (stockConfWork.StockSlipCdDtl == 2))
            {
                // 行値引のみ印字しない
                dr[MAKON02249EA.CT_StockConf_StockOrderDivNmRF] = string.Empty;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_StockOrderDivNmRF] = GetStockOrderDivNm(stockConfWork.StockOrderDivCd);
            }
            // 2009.02.16 30413 犬飼 商品値引の場合、在取区分名を印字 <<<<<<END
            
            // BLコード
            // 2008.01.05 Modify [9490]
			//dr[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = stockConfWork.BLGoodsCode;
            if (stockConfWork.BLGoodsCode == 0)
            {
                dr[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_BLGoodsCodeRF] = stockConfWork.BLGoodsCode;
            }

            // 仕入伝票番号
			dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF] = stockConfWork.SupplierSlipNo;
            // 仕入行番号
            dr[MAKON02249EA.CT_StockConf_StockRowNoRF] = stockConfWork.StockRowNo;
            // 赤伝区分
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivRF] = stockConfWork.DebitNoteDiv;
            // 赤伝区分名
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF] = this.GetDebitNoteDivNm(stockConfWork.DebitNoteDiv);
            // 買掛区分
            dr[MAKON02249EA.CT_StockConf_AccPayDivCdRF] = stockConfWork.AccPayDivCd;
            // 買掛区分名
            dr[MAKON02249EA.CT_StockConf_AccPayDivNmRF] = this.GetAccRecDivNm(stockConfWork.AccPayDivCd);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreCodeRF]  = stockConfWork.LargeGoodsGanreCode;  // 商品大分類コード   (Int32)
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreNameRF]  = stockConfWork.LargeGoodsGanreName;  // 商品大分類名称     (string)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreCodeRF] = stockConfWork.MediumGoodsGanreCode; // 商品中分類コード   (Int32)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreNameRF] = stockConfWork.MediumGoodsGanreName; // 商品中分類名称     (string)
            //dr[MAKON02249EA.CT_StockConf_DetailGoodsGanreCodeRF] = stockConfWork.DetailGoodsGanreCode; // 商品詳細コード   (Int32)
            //dr[MAKON02249EA.CT_StockConf_DetailGoodsGanreNameRF] = stockConfWork.DetailGoodsGanreName; // 商品詳細名称     (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // 仕入担当者コード
			dr[MAKON02249EA.CT_StockConf_StockAgentCodeRF] = stockConfWork.StockAgentCode;
            // 仕入担当者名称
            dr[MAKON02249EA.CT_StockConf_StockAgentNameRF] = stockConfWork.StockAgentName;
            // 仕入伝票区分
            dr[MAKON02249EA.CT_StockConf_SupplierSlipCdRF] = stockConfWork.SupplierSlipCd;
            // 仕入伝票区分名
            dr[MAKON02249EA.CT_StockConf_SupplierSlipNmRF] = this.GetSupplierSlipNm(stockConfWork.SupplierSlipCd);
            // 先頭出力明細フラグ
            dr[MAKON02249EA.CT_StockConf_FirstRowFlg] = 9;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 変更前仕入単価 
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = stockConfWork.BfStockUnitPriceFl;
            if (stockConfWork.BfStockUnitPriceFl == 0)
            {
                dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = DBNull.Value;
            }
            else
            {
                // 2009.02.16 30413 犬飼 変更前仕入単価の印字制御を修正 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = stockConfWork.BfStockUnitPriceFl;
                if (stockConfWork.BfStockUnitPriceFl == stockConfWork.StockUnitPriceFl)
                {
                    // 変更前仕入単価と仕入単価が同じ場合は、変更前定価は印字しない
                    dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = DBNull.Value;
                }
                else
                {
                    // 上記以外の場合は印字する
                    dr[MAKON02249EA.CT_StockConf_BfStockUnitPriceFlRF] = stockConfWork.BfStockUnitPriceFl;
                }
                // 2009.02.16 30413 犬飼 変更前仕入単価の印字制御を修正 <<<<<<END
            }
            // メーカー名称
            dr[MAKON02249EA.CT_StockConf_MakerNameRF] = stockConfWork.MakerName;
            // 倉庫名称
            dr[MAKON02249EA.CT_StockConf_WarehouseNameRF] = stockConfWork.WarehouseName;
            // 売上伝票番号
            dr[MAKON02249EA.CT_StockConf_SalesSlipNum] = stockConfWork.SalesSlipNum;
            // 仕入伝票明細備考1
            dr[MAKON02249EA.CT_StockConf_StockDtiSlipNote1RF] = stockConfWork.StockDtiSlipNote1;
            // 得意先コード
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = stockConfWork.CustomerCode;
            if (stockConfWork.CustomerCode == 0)
            {
                dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_CustomerCodeRF] = stockConfWork.CustomerCode;
            }
            // ＵＯＥリマーク１
            dr[MAKON02249EA.CT_StockConf_UoeRemark1] = stockConfWork.UoeRemark1;
            // ＵＯＥリマーク２
            dr[MAKON02249EA.CT_StockConf_UoeRemark2] = stockConfWork.UoeRemark2;
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // 仕入数
            // 2008.01.05 Modify [9490]
            //dr[MAKON02249EA.CT_StockConf_StockCountRF] = stockConfWork.StockCount;
            if (stockConfWork.StockCount == 0)
            {
                dr[MAKON02249EA.CT_StockConf_StockCountRF] = DBNull.Value;
            }
            else
            {
                // 2009.02.16 30413 仕入商品区分で数量の印字制御を追加 >>>>>>START
                //dr[MAKON02249EA.CT_StockConf_StockCountRF] = stockConfWork.StockCount;
                if (stockConfWork.StockGoodsCd == 0)
                {
                    // 仕入商品区分が"0:商品"の場合
                    dr[MAKON02249EA.CT_StockConf_StockCountRF] = stockConfWork.StockCount;
                }
                else
                {
                    // 仕入商品区分が"0:商品"以外の場合(現在は"6:合計"のみ)
                    dr[MAKON02249EA.CT_StockConf_StockCountRF] = DBNull.Value;
                }
                // 2009.02.16 30413 仕入商品区分で数量の印字制御を追加 <<<<<<END
            }
            // 仕入単価
            // 2008.01.05 Modify [9490]
			//dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = stockConfWork.StockUnitPriceFl;
            if (stockConfWork.StockUnitPriceFl == 0)
            {
                dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF] = stockConfWork.StockUnitPriceFl;
            }

			//dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;     // 仕入金額           (Int64)
			//dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc;	//消費税

            // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 >>>>>>START
            // 2008.01.05 Modify [9490]
            //Int64 stockPrice = 0;
            //Int64 stockPriceTax = 0;
            
            // 2009.01.29 30413 犬飼 仕入商品区分による設定を削除 >>>>>>START
            //if ((stockConfWork.StockGoodsCd == 2) || (stockConfWork.StockGoodsCd == 4))
            //{
            //    // 仕入金額
            //    //dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = 0;
            //    dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            //    // 消費税
            //    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //    if (stockConfWork.StockPriceConsTax == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //        stockPriceTax = Int64.Parse(stockConfWork.StockPriceConsTax.ToString());
            //    }
            //}
            //else if ((stockConfWork.StockGoodsCd == 3) || (stockConfWork.StockGoodsCd == 5))
            //{
            //    // 仕入金額
            //    //dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxInc;
            //    if (stockConfWork.StockPriceTaxInc == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] =DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxInc;
            //        stockPrice = Int64.Parse(stockConfWork.StockPriceTaxInc.ToString());
            //    }
            //    // 消費税
            //    //dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;
            //    dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //}
            //else
            //{
            //    // 仕入金額
            //    //dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    if (stockConfWork.StockPriceTaxExc == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //        stockPrice = Int64.Parse(stockConfWork.StockPriceTaxExc.ToString());
            //    }
            //    //消費税
            //    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //    if (stockConfWork.StockPriceConsTax == 0)
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //        stockPriceTax = Int64.Parse(stockConfWork.StockPriceConsTax.ToString());
            //    }
            //}
            //// 仕入金額
            //if (stockConfWork.StockPriceTaxExc == 0)
            //{
            //    dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            //}
            //else
            //{
            //    dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    stockPrice = stockConfWork.StockPriceTaxExc;
            //}
            ////消費税
            //if (stockConfWork.StockPriceConsTax == 0)
            //{
            //    dr[MAKON02249EA.CT_StockConf_TaxRF] = DBNull.Value;
            //}
            //else
            //{
            //    dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax;
            //    stockPriceTax = Int64.Parse(stockConfWork.StockPriceConsTax.ToString());
            //}
            // 2009.01.29 30413 犬飼 仕入商品区分による設定を削除 <<<<<<END

            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 >>>>>>START
            //// 内税のみ印字用の細工
            //if (IsPrintingTaxIncludedOnlyPattern(stockConfWork))
            //{
            //    if (!stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxIncluded))
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;    // 内税でなければ \0
            //    }
            //}
            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 <<<<<<END
            
            //dr[MAKON02249EA.CT_StockConf_StockPriceTaxIncRF] = Int64.Parse(dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF].ToString()) 
            //                                                        + Int64.Parse(dr[MAKON02249EA.CT_StockConf_TaxRF].ToString());
            //dr[MAKON02249EA.CT_StockConf_StockPriceTaxIncRF] = stockPrice + stockPriceTax;
            // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 <<<<<<END
            
#if False
			if ((stockConfWork.StockRowNo == 1))
				||
				(stockConfWork.StockTelNo1 != "") ||
                (stockConfWork.StockTelNo2 != "") ||
                (stockConfWork.ProductNumber1 != "") ||
                (stockConfWork.ProductNumber2 != ""))
			{
#endif

            // 先頭出力明細フラグ
            dr[MAKON02249EA.CT_StockConf_FirstRowFlg] = 1;
            // 仕入詳細番号
			dr[MAKON02249EA.CT_StockConf_StockRowNoRF] = stockConfWork.StockRowNo;
            // 仕入詳細番号
            dr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF] = 0;

            // 2009.01.09 30413 犬飼 仕入伝票区分(明細)で判断するように修正 >>>>>>START
            // --- ADD 2008/07/16 -------------------------------->>>>>
            // 伝票キー
            string slipKey = (string)dr[MAKON02249EA.CT_StockConf_DailyHeaderDataField];    // ADD 2008/10/15 不具合対応[5651]
            //10:仕入
            //if (stockConfWork.SupplierSlipCd == 10)
            //{
            //    // 伝票枚数(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
            //    // 伝票枚数(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
            //    // 伝票枚数(合計)
            //    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

            //    // ADD 2008/10/15 不具合対応[5651]---------->>>>>
            //    // 既に数えた伝票は数えない
            //    if (CountedSlipKeyList.Contains(slipKey))
            //    {
            //        // 伝票枚数(仕入)
            //        dr[MAKON02249EA.CT_StockConf_SalCntRF]  = 0;
            //        // 伝票枚数(返品値引)
            //        dr[MAKON02249EA.CT_StockConf_DisCntRF]  = 0;
            //        // 伝票枚数(合計)
            //        dr[MAKON02249EA.CT_StockConf_TotleCntRF]= 0;
            //    }
            //    else
            //    {
            //        CountedSlipKeyList.Add(slipKey);
            //    }
            //    // ADD 2008/10/15 不具合対応[5651]----------<<<<<

            //    // 仕入金額(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    // 消費税(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
            //    // 合計金額(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = stockConfWork.StockPriceTaxExc
            //                                                        + stockConfWork.StockPriceConsTax;

            //    // 仕入金額(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = 0;
            //    // 消費税(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = 0;
            //    // 合計金額(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = 0;
            //}
            ////20:返品
            //else
            //{
            //    // 伝票枚数(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 0;     // TODO:
            //    // 伝票枚数(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;     // TODO:
            //    // 伝票枚数(合計)
            //    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;   // TODO:

            //    // ADD 2008/10/15 不具合対応[5651]---------->>>>>
            //    // 既に数えた伝票は数えない
            //    if (CountedSlipKeyList.Contains(slipKey))
            //    {
            //        // 伝票枚数(仕入)
            //        dr[MAKON02249EA.CT_StockConf_SalCntRF]  = 0;
            //        // 伝票枚数(返品値引)
            //        dr[MAKON02249EA.CT_StockConf_DisCntRF]  = 0;
            //        // 伝票枚数(合計)
            //        dr[MAKON02249EA.CT_StockConf_TotleCntRF]= 0;
            //    }
            //    else
            //    {
            //        CountedSlipKeyList.Add(slipKey);
            //    }
            //    // ADD 2008/10/15 不具合対応[5651]----------<<<<<

            //    // 仕入金額(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = 0;
            //    // 消費税(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = 0;
            //    // 合計金額(仕入)
            //    dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = 0;

            //    // 仕入金額(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
            //    // 消費税(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
            //    // 合計金額(返品値引)
            //    dr[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = stockConfWork.StockPriceTaxExc
            //                                                        + stockConfWork.StockPriceConsTax;
            //}
            // --- ADD 2008/07/16 --------------------------------<<<<<

            // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 >>>>>>START
            // 仕入金額
            if (stockConfWork.StockPriceTaxExc == 0)
            {
                dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = DBNull.Value;
            }
            else
            {
                dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF] = stockConfWork.StockPriceTaxExc;
            }
            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            // 消費税税率
            string sConTaxRate = string.Empty;
            // 税別内訳印字の場合、
            if (_iTaxPrintDiv == 0)
            {
                sConTaxRate = Convert.ToString(stockConfWork.SupplierConsTaxRate * 100) + "%";
                // 仕入
                // Title_税率1
                dr[MAKON02249EA.CT_StockConf_TaxRate1_Title] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_税率2
                dr[MAKON02249EA.CT_StockConf_TaxRate2_Title] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_その他
                dr[MAKON02249EA.CT_StockConf_Other_Title] = "その他";

                // 返品
                // Title_税率1
                dr[MAKON02249EA.CT_StockConf_TaxRate1_RetTitle] = Convert.ToString(_taxRate1 * 100) + "%";
                // Title_税率2
                dr[MAKON02249EA.CT_StockConf_TaxRate2_RetTitle] = Convert.ToString(_taxRate2 * 100) + "%";
                // Title_その他
                dr[MAKON02249EA.CT_StockConf_Other_RetTitle] = "その他";

                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                // Title_非課税
                dr[MAKON02249EA.CT_StockConf_TaxFree_Title] = "非課税";
                // Title_非課税
                dr[MAKON02249EA.CT_StockConf_TaxFree_RetTitle] = "非課税";
                // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                
            }
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            long salesDtlTax = 0;       // 仕入／返品の消費税
            long distDtlTax = 0;        // 値引の消費税
            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            // 消費税転嫁方式
            // if (IsPrintingTaxIncludedOnlyPattern(stockConfWork))
            if (IsPrintingTaxIncludedOnlyPattern(stockConfWork) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
            {
                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                if (!stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxIncluded))
                {
                    dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;    // 内税でなければ \0
                    // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip) && !CountedTaxFreeSlipKeyList.Contains(slipKey) && !CountedSlipKeyList.Contains(slipKey))
                    {
                        dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTaxDen;
                    }
                    // ----- ADD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        //dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                        if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip) && !CountedTaxFreeSlipKeyList.Contains(slipKey) && !CountedSlipKeyList.Contains(slipKey))
                        {
                            dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate; 
                        }
                        else 
                        {
                            dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                        }
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
                else
                {
                    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                    dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
            }
            else
            {
                // 消費税転嫁方式　0：伝票単位、1：明細単位
                if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip))
                {
                    // 消費税転嫁方式　0：伝票単位
                    if (!CountedSlipKeyList.Contains(slipKey))
                    {
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        //// 消費税
                        //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTaxDen;
                        //// --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        //// 税別内訳印字の場合、
                        //if (_iTaxPrintDiv == 0)
                        //{ 
                        //    dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                        //}
                        if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                        {
                            // 消費税
                            dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTaxDen;
                            // 税別内訳印字の場合、
                            if (_iTaxPrintDiv == 0)
                            {
                                dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                            }
                        }
                        else {
                            dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;
                            // 税別内訳印字の場合、
                            if (_iTaxPrintDiv == 0)
                            {
                                dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                            }
                        }
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

                        // DEL 2009/07/17 >>>
                        //// 明細タイプの消費税を算出
                        //salesDtlTax = stockConfWork.StockPriceConsTaxDen - stockConfWork.StockDisOutTax - stockConfWork.StckDisTtlTaxInclu;
                        //distDtlTax = stockConfWork.StockDisOutTax + stockConfWork.StckDisTtlTaxInclu;
                        // DEL 2009/07/17 <<<
                    }
                    else
                    {
                        // 上記以外
                        // 消費税
                        dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            dr[MAKON02249EA.CT_Col_ConsTaxRate] = string.Empty;
                        }
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                }
                else
                {
                    // 消費税転嫁方式　1：明細単位
                    //dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                    dr[MAKON02249EA.CT_StockConf_TaxRF] = stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        dr[MAKON02249EA.CT_Col_ConsTaxRate] = sConTaxRate;
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                }
            }
            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 <<<<<<END


            if (stockConfWork.StockSlipCdDtl == 0)
            {
                // 0:仕入
                /* ---DEL 2009/01/28 不具合対応[10599] ------------------------------------------->>>>>
                // 伝票枚数(仕入)
                dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                // 伝票枚数(合計)
                dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                // 既に数えた伝票は数えない
                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    CountedSlipKeyList.Add(slipKey);
                }
                   ---DEL 2009/01/28 不具合対応[10599] -------------------------------------------<<<<< */
                // ---ADD 2009/01/28 不具合対応[10599] ------------------------------------------->>>>>
                // 既に数えた伝票は数えない
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    // 伝票枚数(仕入)
                    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 0;
                    // 伝票枚数(合計)
                    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 0;
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey) &&
                        _iTaxPrintDiv == 0 &&
                        (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)))
                    {
                        dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                }
                else
                {
                    // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 伝票枚数(仕入)
                    // dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                    // 伝票枚数(合計)
                    // dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                        // 伝票枚数(仕入)
                        dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                        // 伝票枚数(合計)
                        dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    }
                    // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                        // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                        if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                        {
                            // 仕入数_その他
                            //dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;
                            if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                            {
                                dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                                CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        else
                        {
                            // 税率２
                            if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                            {
                                // 仕入数_税率２
                                dr[MAKON02249EA.CT_StockConf_TaxRate2_SalSlipCntRF] = 1;

                            }
                            else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                            {
                                // 仕入数_税率１
                                dr[MAKON02249EA.CT_StockConf_TaxRate1_SalSlipCntRF] = 1;
                            }
                            else
                            {
                                // 仕入数_その他
                                dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;

                            }
                        }
                    }
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    //CountedSlipKeyList.Add(slipKey);
                }
                // ---ADD 2009/01/28 不具合対応[10599] -------------------------------------------<<<<<
                
                // 仕入金額(仕入)
                dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 >>>>>>START
                // 2009.01.29 30413 犬飼 消費税の設定を修正 >>>>>>START
                // 消費税(仕入)
                //dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
                //dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // 消費税(仕入)
                    dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = salesDtlTax;
                    // 消費税(値引)
                    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                }
                else
                {
                    //dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];

                    // ADD 2009/07/17 >>>
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ByDetails)) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = stockConfWork.StockPriceConsTaxDen;
                    }
                    // ADD 2009/07/17 <<<

                }
                // 2009.01.29 30413 犬飼 消費税の設定を修正 <<<<<<END
                // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 <<<<<<END
                // 合計金額(仕入)
                dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = stockConfWork.StockPriceTaxExc
                //                                              + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                    // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                    {
                        // 仕入金額計（税抜き）_その他
                        //dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        dr[MAKON02249EA.CT_StockConf_TaxFree_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                    }
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    else
                    {
                        // 税率２
                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // 仕入金額計（税抜き）_税率２
                            dr[MAKON02249EA.CT_StockConf_TaxRate2_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                        }
                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // 仕入金額計（税抜き）_税率１
                            dr[MAKON02249EA.CT_StockConf_TaxRate1_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        }
                        else
                        {
                            // 仕入金額計（税抜き）_その他
                            dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                        }
                    }
                }
                // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                // 税別内訳印字しないの場合、
                else
                {
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                       !CountedTaxFreeSlipKeyList.Contains(slipKey))
                    {
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                }
                // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            else if (stockConfWork.StockSlipCdDtl == 1)
            {
                // 1:返品
                /* ---DEL 2009/01/28 不具合対応[10599] ------------------------------------------->>>>>
                // 伝票枚数(返品)
                dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                // 伝票枚数(合計)
                dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;

                // 既に数えた伝票は数えない
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    CountedSlipKeyList.Add(slipKey);
                }
                   ---DEL 2009/01/28 不具合対応[10599] -------------------------------------------<<<<< */
                // ---ADD 2009/01/28 不具合対応[10599] ------------------------------------------->>>>>
                // 既に数えた伝票は数えない
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    // 伝票枚数(返品)
                    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
                    // 伝票枚数(合計)
                    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 0;
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey) &&
                        _iTaxPrintDiv == 0 &&
                        (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)))
                    {
                        dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                }
                else
                {
                    // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 伝票枚数(返品)
                    // dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                    // 伝票枚数(合計)
                    // dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                        // 伝票枚数(返品)
                        dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                        // 伝票枚数(合計)
                        dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    }
                    // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                    // 税別内訳印字の場合、
                    if (_iTaxPrintDiv == 0)
                    {
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                        // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                        if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                        {
                            // 仕入枚数(返品値引)_その他
                            //dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;
                            if (!CountedTaxFreeSlipKeyList.Contains(slipKey)){
                                // 仕入枚数(返品値引)_非課税
                                dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                                CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        else
                        {
                            // 税率２
                            if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                            {
                                // 伝票枚数(返品値引)_税率２
                                dr[MAKON02249EA.CT_StockConf_TaxRate2_DisSlipCntRF] = 1;

                            }
                            // 税率１
                            else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                            {
                                // 伝票枚数(返品値引)_税率１
                                dr[MAKON02249EA.CT_StockConf_TaxRate1_DisSlipCntRF] = 1;
                            }
                            else
                            {
                                // 仕入数_その他
                                dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;

                            }
                        }
                    }
                    // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 税別内訳印字しないの場合、
                    else
                    {
                        if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                           !CountedTaxFreeSlipKeyList.Contains(slipKey))
                        {
                            CountedTaxFreeSlipKeyList.Add(slipKey);
                        }
                    }
                    // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

                    //CountedSlipKeyList.Add(slipKey);
                }
                // ---ADD 2009/01/28 不具合対応[10599] -------------------------------------------<<<<<

                // 仕入金額(返品)
                dr[MAKON02249EA.CT_StockConf_RetGdsStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 >>>>>>START
                // 2009.01.29 30413 犬飼 消費税の設定を修正 >>>>>>START
                // 消費税(返品)
                //dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
                //dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                {
                    // 消費税(返品)
                    dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = salesDtlTax;
                    // 消費税(値引)
                    dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                }
                else
                {                    
                    dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                    // ADD 2009/07/17 
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ByDetails)) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = stockConfWork.StockPriceConsTaxDen;
                    }

                }
                // 2009.01.29 30413 犬飼 消費税の設定を修正 <<<<<<END
                // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 <<<<<<END
                // 合計金額(返品)
                dr[MAKON02249EA.CT_StockConf_RetGdsTotalPriceRF] = stockConfWork.StockPriceTaxExc
                //                                                 + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                   + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                // 税別内訳印字の場合、
                if (_iTaxPrintDiv == 0)
                {
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                    // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                    if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                    {
                        // 仕入金額(返品)_その他
                        // dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        // 仕入金額(返品)_非課税
                        dr[MAKON02249EA.CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                    }
                    // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    else
                    {
                        // 税率２
                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                        {
                            // 仕入金額(返品)_税率２
                            dr[MAKON02249EA.CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                        }
                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                        {
                            // 仕入金額(返品)_税率１
                            dr[MAKON02249EA.CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        }
                        else
                        {
                            // 仕入金額(返品)_その他
                            dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        }
                    }
                }
                // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
            }
            else
            {
                // 2:値引
                // 2009.02.03 30413 犬飼 値引も伝票枚数をカウント >>>>>>START
                // 既に数えた伝票は数えない
                if (CountedSlipKeyList.Contains(slipKey))
                {
                    // 伝票枚数(仕入)
                    dr[MAKON02249EA.CT_StockConf_SalCntRF] = 0;
                    // 伝票枚数(返品)
                    dr[MAKON02249EA.CT_StockConf_DisCntRF] = 0;
                    // 伝票枚数(合計)
                    dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 0;
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey) &&
                        _iTaxPrintDiv == 0 &&
                        (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)))
                    {
                        if (stockConfWork.SupplierSlipCd == 10)
                        {
                            dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                        }
                        else if (stockConfWork.SupplierSlipCd == 20)
                        {
                            dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                        }
                        CountedTaxFreeSlipKeyList.Add(slipKey);
                    }
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                }
                else
                {
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                    if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                    {
                        // 伝票枚数(合計)
                        dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1;
                    }
                    // ----- ADD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                    if (stockConfWork.SupplierSlipCd == 10)
                    {
                        // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 伝票枚数(仕入)
                        // dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                        if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                            dr[MAKON02249EA.CT_StockConf_SalCntRF] = 1;
                        }
                        // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                            // 消費税転嫁方式 9：非課税 消費税税率(税率２,税率１以外)
                            // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // 仕入数_その他
                                // dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;
                                if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                                {
                                    // 仕入数_非課税
                                    dr[MAKON02249EA.CT_StockConf_TaxFree_SalSlipCntRF] = 1;
                                    CountedTaxFreeSlipKeyList.Add(slipKey);
                                    if (stockConfWork.TaxRateExistFlag)
                                    {
                                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                        {
                                            // 仕入数_税率２
                                            dr[MAKON02249EA.CT_StockConf_TaxRate2_SalSlipCntRF] = 1;

                                        }
                                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                        {
                                            // 仕入数_税率１
                                            dr[MAKON02249EA.CT_StockConf_TaxRate1_SalSlipCntRF] = 1;
                                        }
                                        else
                                        {
                                            // 仕入数_その他
                                            dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;
                                        }
                                    }
                                }
                            }
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                            else
                            {
                                // 税率２
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // 仕入数_税率２
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_SalSlipCntRF] = 1;

                                }
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // 仕入数_税率１
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_SalSlipCntRF] = 1;
                                }
                                else
                                {
                                    // 仕入数_その他
                                    dr[MAKON02249EA.CT_StockConf_Other_SalSlipCntRF] = 1;

                                }
                            }
                        }
                        // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 税別内訳印字しないの場合、
                        else {
                            if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                               !CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                                   CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                    else if (stockConfWork.SupplierSlipCd == 20)
                    {
                        
                        // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 伝票枚数(返品)
                        // dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                        if (!CountedTaxFreeSlipKeyList.Contains(slipKey))
                        {
                            // 伝票枚数(返品)
                            dr[MAKON02249EA.CT_StockConf_DisCntRF] = 1;
                        }
                        // ----- UPD 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                            // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                            //if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // 仕入枚数(返品値引)_その他
                                // dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;
                                if (!CountedTaxFreeSlipKeyList.Contains(slipKey)) {
                                    // 仕入枚数(返品値引)_非課税
                                    dr[MAKON02249EA.CT_StockConf_TaxFree_DisSlipCntRF] = 1;
                                    CountedTaxFreeSlipKeyList.Add(slipKey);
                                    if (stockConfWork.TaxRateExistFlag) {
                                        if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                        {
                                            // 伝票枚数(返品値引)_税率２
                                            dr[MAKON02249EA.CT_StockConf_TaxRate2_DisSlipCntRF] = 1;
                                        }
                                        // 税率１
                                        else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                        {
                                            // 伝票枚数(返品値引)_税率１
                                            dr[MAKON02249EA.CT_StockConf_TaxRate1_DisSlipCntRF] = 1;
                                        }
                                        else
                                        {
                                            // 仕入数_その他
                                            dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;
                                        }
                                    }
                                }
                            }
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                            else
                            {
                                // 税率２
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // 伝票枚数(返品値引)_税率２
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_DisSlipCntRF] = 1;

                                }
                                // 税率１
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // 伝票枚数(返品値引)_税率１
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_DisSlipCntRF] = 1;
                                }
                                else
                                {
                                    // 仕入数_その他
                                    dr[MAKON02249EA.CT_StockConf_Other_DisSlipCntRF] = 1;

                                }
                            }
                        }
                        // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                        // 税別内訳印字しないの場合、
                        else
                        {
                            if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption)) &&
                               !CountedTaxFreeSlipKeyList.Contains(slipKey))
                            {
                                CountedTaxFreeSlipKeyList.Add(slipKey);
                            }
                        }
                        // ----- ADD 2022/10/9 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }

                    // 伝票枚数(合計)
                    // dr[MAKON02249EA.CT_StockConf_TotleCntRF] = 1; DEL 2022/10/08 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    //CountedSlipKeyList.Add(slipKey);
                }
                // 2009.02.03 30413 犬飼 値引も伝票枚数をカウント <<<<<<END

                // 2009.03.16 30413 犬飼 行値引きの扱いを変更 >>>>>>START
                // 行値引きは仕入／返品として扱う
                if (stockConfWork.StockCount == 0.0)
                {
                    if (stockConfWork.SupplierSlipCd == 10)
                    {
                        // 仕入に計上
                        // 仕入金額(仕入)
                        dr[MAKON02249EA.CT_StockConf_SalStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        // 消費税(仕入)
                        if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // 消費税(仕入)
                            dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = salesDtlTax;
                            // 消費税(値引)
                            dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                        }
                        else
                        {
                            dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                        }
                        // 合計金額(仕入)
                        dr[MAKON02249EA.CT_StockConf_SalTotalPriceRF] = stockConfWork.StockPriceTaxExc
                        //                                                 + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                           + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                            // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                            // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // 仕入金額計（税抜き）_その他
                                // dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                // 仕入金額計（税抜き）_非課税
                                dr[MAKON02249EA.CT_StockConf_TaxFree_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                            }
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                            else
                            {
                                // 税率２
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // 仕入金額計（税抜き）_税率２
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // 仕入金額計（税抜き）_税率１
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                }
                                else
                                {
                                    // 仕入金額計（税抜き）_その他
                                    dr[MAKON02249EA.CT_StockConf_Other_StockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                            }
                        }
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                    else if (stockConfWork.SupplierSlipCd == 20)
                    {
                        // 仕入金額(返品)
                        dr[MAKON02249EA.CT_StockConf_RetGdsStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                        // 消費税(返品)
                        if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                        {
                            // 消費税(返品)
                            dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = salesDtlTax;
                            // 消費税(値引)
                            dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                        }
                        else
                        {
                            dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                        }
                        // 合計金額(返品)
                        dr[MAKON02249EA.CT_StockConf_RetGdsTotalPriceRF] = stockConfWork.StockPriceTaxExc
                        //                                                 + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                           + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
                        // 税別内訳印字の場合、
                        if (_iTaxPrintDiv == 0)
                        {
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                            // 消費税転嫁方式　9：非課税 消費税税率(税率２,税率１以外)
                            // if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption))
                            if (stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) || stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
                            {
                                // 仕入金額(返品)_その他
                                // dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                // 仕入金額(返品)_非課税
                                dr[MAKON02249EA.CT_StockConf_TaxFree_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                            }
                            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                            else
                            {
                                // 税率２
                                if (stockConfWork.SupplierConsTaxRate == _taxRate2)
                                {
                                    // 仕入金額(返品)_税率２
                                    dr[MAKON02249EA.CT_StockConf_TaxRate2_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                                else if (stockConfWork.SupplierConsTaxRate == _taxRate1)
                                {
                                    // 仕入金額(返品)_税率１
                                    dr[MAKON02249EA.CT_StockConf_TaxRate1_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                                }
                                else
                                {
                                    // 仕入金額(返品)_その他
                                    dr[MAKON02249EA.CT_StockConf_Other_RetGdsStockTtlPricTaxExcRF] = stockConfWork.StockPriceTaxExc;

                                }
                            }
                        }
                        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<
                    }
                }
                else
                {
                    // 仕入金額(値引)
                    dr[MAKON02249EA.CT_StockConf_DisStockPricTaxExcRF] = stockConfWork.StockPriceTaxExc;
                    // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 >>>>>>START
                    // 2009.01.29 30413 犬飼 消費税の設定を修正 >>>>>>START
                    // 消費税(値引)
                    //dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = stockConfWork.StockPriceConsTax;
                    //dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                    if ((stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.BySlip)) && (!CountedSlipKeyList.Contains(slipKey)))
                    {
                        // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                        dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = distDtlTax;
                        if (stockConfWork.SupplierSlipCd == 10)
                        {
                            // 仕入
                            dr[MAKON02249EA.CT_StockConf_SalStockPriceConsTaxRF] = salesDtlTax;
                        }
                        else if (stockConfWork.SupplierSlipCd == 20)
                        {
                            // 返品
                            dr[MAKON02249EA.CT_StockConf_RetGdsStockPriceConsTaxRF] = salesDtlTax;
                        }
                    }
                    else
                    {
                        // 上記以外
                        dr[MAKON02249EA.CT_StockConf_DisStockPriceConsTaxRF] = dr[MAKON02249EA.CT_StockConf_TaxRF];
                    }
                    // 2009.01.29 30413 犬飼 消費税の設定を修正 <<<<<<END
                    // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 <<<<<<END
                    // 合計金額(値引)
                    dr[MAKON02249EA.CT_StockConf_DisTotalPriceRF] = stockConfWork.StockPriceTaxExc
                    //                                            + stockConfWork.StockPriceConsTax; // DEL 2009/04/14
                                                                  + stockConfWork.StockPriceTaxInc - stockConfWork.StockPriceTaxExc; // ADD 2009/04/14
                }
                // 2009.03.16 30413 犬飼 行値引きの扱いを変更 <<<<<<END
            }
            // 2009.01.09 30413 犬飼 仕入伝票区分(明細)で判断するように修正 <<<<<<END

            // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 >>>>>>START
            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            // if (!CountedSlipKeyList.Contains(slipKey))
            if (!CountedSlipKeyList.Contains(slipKey) && 
                !stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption) && 
                !stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxExemption))
            // ----- UPD 2022/09/28 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<<
            {
                CountedSlipKeyList.Add(slipKey);
            }
            // 2009.02.06 30413 犬飼 消費税転嫁方式の対応修正 <<<<<<END
                        
            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
            // 仕入先総額表示方法区分
            dr[MAKON02249EA.CT_StockConf_SuppTtlAmntDspWayCd] = stockConfWork.SuppTtlAmntDspWayCd;

            // 仕入先消費税転嫁方式コード
            dr[MAKON02249EA.CT_StockConf_SuppCTaxLayCd] = stockConfWork.SuppCTaxLayCd;

            // 課税区分
            dr[MAKON02249EA.CT_StockConf_TaxationCode] = stockConfWork.TaxationCode;

            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 >>>>>>START
            //// TODO:内税のみ印字用の細工
            //if (IsPrintingTaxIncludedOnlyPattern(stockConfWork))
            //{
            //    if (!stockConfWork.TaxationCode.Equals((int)TaxationCode.TaxIncluded))
            //    {
            //        dr[MAKON02249EA.CT_StockConf_TaxRF] = 0;    // 内税でなければ \0
            //    }
            //}
            // 2009.01.29 30413 犬飼 内税チェックの処理位置を変更 <<<<<<END
            // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<
        }

        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ---------->>>>>
        /// <summary>
        /// 内税のみ印字するパターンか判定します。
        /// </summary>
        /// <remarks>
        /// 内税のみ印字するパターン：転嫁方式 = 請求親(支払親) || 請求子(支払子) || 非課税
        /// </remarks>
        /// <param name="stockConfWork">仕入データ（明細タイプ）</param>
        /// <returns>
        /// <c>true</c> :内税のみ印字するパターンである。<br/>
        /// <c>false</c>:内税のみ印字するパターンではない。
        /// </returns>
        private static bool IsPrintingTaxIncludedOnlyPattern(StockConfWork stockConfWork)
        {
            if (
                stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ParentPayment)
                    ||
                stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.ChildPayment)
                    ||
                stockConfWork.SuppCTaxLayCd.Equals((int)SuppCTaxLayCd.TaxExemption)
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ADD 2008/11/04 不具合対応[6980] 消費税の印字仕様の変更 ----------<<<<<

		/// <summary>
		/// 日付文字列を取得します。
		/// </summary>
		/// <param name="date">日付</param>
		/// <param name="format">フォーマット文字列</param>
		/// <returns>日付文字列</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            // 担当者別
            dr[MAKON02249EA.CT_StockConf_SectionCodeRF]          = sourceDataRow[MAKON02249EA.CT_StockConf_SectionCodeRF];          // 拠点コード         (string)
            dr[MAKON02249EA.CT_StockConf_SectionGuideNmRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SectionGuideNmRF];       // 拠点ガイド名称     (string)
            dr[MAKON02249EA.CT_StockConf_StockDateRF]            = sourceDataRow[MAKON02249EA.CT_StockConf_StockDateRF];            // 仕入日付           (Int32)
            dr[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF]      = sourceDataRow[MAKON02249EA.CT_StockConf_ArrivalGoodsDayRF];      // 出荷日付           (Int32)
			dr[MAKON02249EA.CT_StockConf_InputDayRF]             = sourceDataRow[MAKON02249EA.CT_StockConf_InputDayRF];             // 入力日付           (Int32)

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_CustomerCodeRF]         = sourceDataRow[MAKON02249EA.CT_StockConf_CustomerCodeRF];         // 得意先コード       (Int32)
            //dr[MAKON02249EA.CT_StockConf_CustomerNameRF]         = sourceDataRow[MAKON02249EA.CT_StockConf_CustomerNameRF];         // 得意先名称         (string)
            //dr[MAKON02249EA.CT_StockConf_CustomerName2RF]        = sourceDataRow[MAKON02249EA.CT_StockConf_CustomerName2RF];        // 得意先名称2        (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            dr[MAKON02249EA.CT_StockConf_SupplierCd] = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierCd];         // 仕入先コード       (Int32)
            dr[MAKON02249EA.CT_StockConf_SupplierSnm] = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSnm];       // 仕入先名称         (string)
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            dr[MAKON02249EA.CT_StockConf_GoodsCodeRF]            = sourceDataRow[MAKON02249EA.CT_StockConf_GoodsCodeRF];            // 商品コード         (string)
            dr[MAKON02249EA.CT_StockConf_GoodsNameRF]            = sourceDataRow[MAKON02249EA.CT_StockConf_GoodsNameRF];            // 商品名称           (string)
            dr[MAKON02249EA.CT_StockConf_SupplierSlipNoRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSlipNoRF];       // 仕入伝票番号       (Int32)
            dr[MAKON02249EA.CT_StockConf_StockRowNoRF]           = sourceDataRow[MAKON02249EA.CT_StockConf_StockRowNoRF];           // 仕入行番号         (Int32)
            dr[MAKON02249EA.CT_StockConf_StckSlipExpNumRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StckSlipExpNumRF];       // 仕入詳細番号       (Int32)
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivRF]         = sourceDataRow[MAKON02249EA.CT_StockConf_DebitNoteDivRF];         // 赤伝区分           (Int32)
            dr[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_DebitNoteDivNmRF];       // 赤伝区分名         (string)
            dr[MAKON02249EA.CT_StockConf_AccPayDivCdRF]          = sourceDataRow[MAKON02249EA.CT_StockConf_AccPayDivCdRF];          // 買掛区分           (Int32)
            dr[MAKON02249EA.CT_StockConf_AccPayDivNmRF]          = sourceDataRow[MAKON02249EA.CT_StockConf_AccPayDivNmRF];          // 買掛区分名         (string)

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreCodeRF]  = sourceDataRow[MAKON02249EA.CT_StockConf_LargeGoodsGanreCodeRF];  // 商品大分類コード   (Int32)
            //dr[MAKON02249EA.CT_StockConf_LargeGoodsGanreNameRF]  = sourceDataRow[MAKON02249EA.CT_StockConf_LargeGoodsGanreNameRF];  // 商品大分類名称     (string)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreCodeRF] = sourceDataRow[MAKON02249EA.CT_StockConf_MediumGoodsGanreCodeRF]; // 商品中分類コード   (Int32)
            //dr[MAKON02249EA.CT_StockConf_MediumGoodsGanreNameRF] = sourceDataRow[MAKON02249EA.CT_StockConf_MediumGoodsGanreNameRF]; // 商品中分類名称     (string)
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            dr[MAKON02249EA.CT_StockConf_StockAgentCodeRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StockAgentCodeRF];       // 仕入担当者コード   (string)
            dr[MAKON02249EA.CT_StockConf_StockAgentNameRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StockAgentNameRF];       // 仕入担当者名称     (string)
            dr[MAKON02249EA.CT_StockConf_StockCountRF]           = sourceDataRow[MAKON02249EA.CT_StockConf_StockCountRF];           // 仕入数             (double)
            dr[MAKON02249EA.CT_StockConf_StockUnitPriceRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_StockUnitPriceRF];       // 仕入単価           (Int64)
            dr[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF]     = sourceDataRow[MAKON02249EA.CT_StockConf_StockPriceTaxExcRF];     // 仕入金額           (Int64)
            dr[MAKON02249EA.CT_StockConf_SupplierSlipCdRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSlipCdRF];       // 仕入伝票区分       (Int32)
            dr[MAKON02249EA.CT_StockConf_SupplierSlipNmRF]       = sourceDataRow[MAKON02249EA.CT_StockConf_SupplierSlipNmRF];       // 仕入伝票区分名     (string)
            dr[MAKON02249EA.CT_StockConf_FirstRowFlg]            = sourceDataRow[MAKON02249EA.CT_StockConf_FirstRowFlg];            // 先頭明細フラグ     (Int32)
        }

		/// <summary>
		/// 伝票形式 仕入在庫取寄せ名称化処理
		/// </summary>
		private string GetStockOrderDivNm(int StockOrderDivCd)
		{
			string wkStr = "";

			switch (StockOrderDivCd)
			{
				case 1:
					{
						wkStr = "在庫";
						break;
					}
				case 0:
					{
						wkStr = "取寄";
						break;
					}
			}

			return wkStr;
		}

        /// <summary>
        /// 伝票形式 名称化処理
        /// </summary>
        private string GetSupplierSlipNm(int SupplierSlipCd)
        {
            string wkStr = "";

            switch (SupplierSlipCd)
            {
                case 10:
                    {
                        wkStr = "仕入";
                        break;
                    }
                case 20:
                    {
                        wkStr = "返品";
                        break;
                    }
            }

            return wkStr;
        }

		/// <summary>
		/// 仕入形式 名称化処理
		/// </summary>
		private string GetSupplierFormalNm(int SupplierFormal)
		{
			string wkStr = "";

			switch (SupplierFormal)
			{
				case 0:
					{
						wkStr = "仕入";
						break;
					}
				case 1:
					{
						wkStr = "入荷";
						break;
					}
				case 2:
					{
						wkStr = "発注";
						break;
					}
			}

			return wkStr;
		}


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
                        wkStr = "黒伝";
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
        /// 買掛区分 名称化処理
        /// </summary>
        private string GetAccRecDivNm(int accPayDivCd)
        {
            string wkStr = "";

            switch (accPayDivCd)
            {
                case 0:
                    {
                        wkStr = "買掛なし";
                        break;
                    }
                case 1:
                    {
                        wkStr = "買掛あり";
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

		#endregion
	}
}
