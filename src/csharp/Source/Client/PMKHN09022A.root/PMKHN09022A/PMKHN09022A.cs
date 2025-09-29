//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先マスタ
// プログラム概要   : 仕入先の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2008/05/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/11/07  修正内容 : リモート検索0件時の処理を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009/02/13  修正内容 : Readで仕入先情報をキャッシュするように修正
//                       修正内容 : 不要処理削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/27  修正内容 : MANTIS【13319】 子仕入先の支払情報が更新されない不具合を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2010/04/06  修正内容 : 品番検索速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31739 岸
// 作 成 日  2020/02/27  修正内容 : ハンディ常駐からの呼出用メソッド追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入先テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2008.05.08</br>
    /// <br>Update Note: 2008.11.07 30452 上野 俊治</br>
    /// <br>            ・リモート検索0件時の処理を修正</br>
    /// <br>Update Note: 2009.02.13 20056 對馬 大輔</br>
    /// <br>            ・Readで仕入先情報をキャッシュするように修正</br>
    /// <br>            ・不要処理削除</br>
	/// <br>Update Note: 2012.04.11 30182 立谷 亮介</br>
	/// <br>            ・仕入先コードフォーマット取得オプション付きのコンストラクタを追加（速度対応）</br>
	/// </remarks>
    public class SupplierAcs : IGeneralGuideData
    {
        # region [public Enum]
        /// <summary>
        /// 仕入金額端数処理区分
        /// </summary>
        public enum StockFracProcMoneyDiv
        {
            /// <summary>単価</summary>
            UnPrcFrcProcCd = 0,
            /// <summary>金額</summary>
            MoneyFrcProcCd = 1,
            /// <summary>消費税</summary>
            CnsTaxFrcProcCd = 2,
        }
        /// <summary>
        /// 検索モード列挙型
        /// </summary>
        public enum SearchMode
        {
            /// <summary>0:前方一致検索</summary>
            StartsWith = 0,
            /// <summary>1:曖昧検索</summary>
            Contains = 1,
        }
        # endregion

        # region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        ISupplierDB _isupplierDB = null;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 保留 ローカルＤＢ
        //private SupplierLcDB _supplierLcDB = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 保留 ローカルＤＢ

        // ガイド設定ファイル名
        private const string GUIDE_XML_FILENAME = "SUPPLIERGUIDEPARENT.XML";   // XMLファイル名

        // ガイドパラメータ
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";  // (パラメータ)企業コード
        private const string GUIDE_MNGSECTIONCODE_PARA = "MngSectionCode";  // (パラメータ)管理拠点コード

        // ガイド項目タイプ
        private const string GUIDE_TYPE_STR = "System.String";              // String型

        // ガイド項目名
        # region [ガイド項目（自動生成）]
        private const string GUIDE_SUPPLIERCD_TITLE = "SupplierCd"; // 仕入先コード
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
        private const string GUIDE_SUPPLIERCD_ZERO_TITLE = "SupplierCdZero"; // 仕入先コード(ゼロ詰め)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
        private const string GUIDE_MNGSECTIONCODE_TITLE = "MngSectionCode"; // 管理拠点コード
        private const string GUIDE_INPSECTIONCODE_TITLE = "InpSectionCode"; // 入力拠点コード
        private const string GUIDE_PAYMENTSECTIONCODE_TITLE = "PaymentSectionCode"; // 支払拠点コード
        private const string GUIDE_SUPPLIERNM1_TITLE = "SupplierNm1"; // 仕入先名1
        private const string GUIDE_SUPPLIERNM2_TITLE = "SupplierNm2"; // 仕入先名2
        private const string GUIDE_SUPPHONORIFICTITLE_TITLE = "SuppHonorificTitle"; // 仕入先敬称
        private const string GUIDE_SUPPLIERKANA_TITLE = "SupplierKana"; // 仕入先カナ
        private const string GUIDE_SUPPLIERSNM_TITLE = "SupplierSnm"; // 仕入先略称
        private const string GUIDE_ORDERHONORIFICTTL_TITLE = "OrderHonorificTtl"; // 発注書敬称
        private const string GUIDE_BUSINESSTYPECODE_TITLE = "BusinessTypeCode"; // 業種コード
        private const string GUIDE_SALESAREACODE_TITLE = "SalesAreaCode"; // 販売エリアコード
        private const string GUIDE_SUPPLIERPOSTNO_TITLE = "SupplierPostNo"; // 仕入先郵便番号
        private const string GUIDE_SUPPLIERADDR1_TITLE = "SupplierAddr1"; // 仕入先住所1（都道府県市区郡・町村・字）
        private const string GUIDE_SUPPLIERADDR3_TITLE = "SupplierAddr3"; // 仕入先住所3（番地）
        private const string GUIDE_SUPPLIERADDR4_TITLE = "SupplierAddr4"; // 仕入先住所4（アパート名称）
        private const string GUIDE_SUPPLIERTELNO_TITLE = "SupplierTelNo"; // 仕入先電話番号
        private const string GUIDE_SUPPLIERTELNO1_TITLE = "SupplierTelNo1"; // 仕入先電話番号1
        private const string GUIDE_SUPPLIERTELNO2_TITLE = "SupplierTelNo2"; // 仕入先電話番号2
        private const string GUIDE_PURECODE_TITLE = "PureCode"; // 純正区分
        private const string GUIDE_PAYMENTMONTHCODE_TITLE = "PaymentMonthCode"; // 支払月区分コード
        private const string GUIDE_PAYMENTMONTHNAME_TITLE = "PaymentMonthName"; // 支払月区分名称
        private const string GUIDE_PAYMENTDAY_TITLE = "PaymentDay"; // 支払日
        private const string GUIDE_SUPPCTAXLAYREFCD_TITLE = "SuppCTaxLayRefCd"; // 仕入先消費税転嫁方式参照区分
        private const string GUIDE_SUPPCTAXLAYCD_TITLE = "SuppCTaxLayCd"; // 仕入先消費税転嫁方式コード
        private const string GUIDE_SUPPCTAXATIONCD_TITLE = "SuppCTaxationCd"; // 仕入先課税方式コード
        private const string GUIDE_SUPPENTERPRISECD_TITLE = "SuppEnterpriseCd"; // 仕入先企業コード
        private const string GUIDE_PAYEECODE_TITLE = "PayeeCode"; // 支払先コード
        private const string GUIDE_SUPPLIERATTRIBUTEDIV_TITLE = "SupplierAttributeDiv"; // 仕入先属性区分
        private const string GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE = "SuppTtlAmntDspWayCd"; // 仕入先総額表示方法区分
        private const string GUIDE_STCKTTLAMNTDSPWAYREF_TITLE = "StckTtlAmntDspWayRef"; // 仕入時総額表示方法参照区分
        private const string GUIDE_PAYMENTCOND_TITLE = "PaymentCond"; // 支払条件
        private const string GUIDE_PAYMENTTOTALDAY_TITLE = "PaymentTotalDay"; // 支払締日
        private const string GUIDE_PAYMENTSIGHT_TITLE = "PaymentSight"; // 支払サイト
        private const string GUIDE_STOCKAGENTCODE_TITLE = "StockAgentCode"; // 仕入担当者コード
        private const string GUIDE_STOCKUNPRCFRCPROCCD_TITLE = "StockUnPrcFrcProcCd"; // 仕入単価端数処理コード
        private const string GUIDE_STOCKMONEYFRCPROCCD_TITLE = "StockMoneyFrcProcCd"; // 仕入金額端数処理コード
        private const string GUIDE_STOCKCNSTAXFRCPROCCD_TITLE = "StockCnsTaxFrcProcCd"; // 仕入消費税端数処理コード
        private const string GUIDE_SUPPRATEGRPCODE_TITLE = "SuppRateGrpCode"; // 仕入先掛率グループコード
        private const string GUIDE_NTIMECALCSTDATE_TITLE = "NTimeCalcStDate"; // 次回勘定開始日
        private const string GUIDE_SUPPLIERNOTE1_TITLE = "SupplierNote1"; // 仕入先備考1
        private const string GUIDE_SUPPLIERNOTE2_TITLE = "SupplierNote2"; // 仕入先備考2
        private const string GUIDE_SUPPLIERNOTE3_TITLE = "SupplierNote3"; // 仕入先備考3
        private const string GUIDE_SUPPLIERNOTE4_TITLE = "SupplierNote4"; // 仕入先備考4
        private const string GUIDE_STOCKAGENTNAME_TITLE = "StockAgentName"; // 仕入担当者名称
        private const string GUIDE_MNGSECTIONNAME_TITLE = "MngSectionName"; // 管理拠点名称
        private const string GUIDE_INPSECTIONNAME_TITLE = "InpSectionName"; // 入力拠点名称
        private const string GUIDE_PAYMENTSECTIONNAME_TITLE = "PaymentSectionName"; // 支払拠点名称
        private const string GUIDE_BUSINESSTYPENAME_TITLE = "BusinessTypeName"; // 業種名称
        private const string GUIDE_SALESAREANAME_TITLE = "SalesAreaName"; // 販売エリア名称
        private const string GUIDE_PAYEENAME_TITLE = "PayeeName"; // 支払先名称
        private const string GUIDE_PAYEENAME2_TITLE = "PayeeName2"; // 支払先名称２
        private const string GUIDE_PAYEESNM_TITLE = "PayeeSnm"; // 支払先略称
        # endregion

        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        // staticローカルキャッシュ
        private static Dictionary<int, Supplier> _supplierDic;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
        private string _supplierCodeFormat; // 仕入先コードフォーマット
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD

        # endregion

        # region Constructor

        /// <summary>
        /// 仕入先テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public SupplierAcs()
        {
			// -- Add St 2012.04.11 30182 R.Tachiya --
			//共通コンストラクタ
			this.SupplierAcsProc(true);
			// -- Add Ed 2012.04.11 30182 R.Tachiya --

			#region // -- Del 2012.04.11 30182 R.Tachiya --
			//try
			//{
			//    // リモートオブジェクト取得
			//    this._isupplierDB = (ISupplierDB)MediationSupplierDB.GetSupplierDB();
			//}
			//catch ( Exception )
			//{
			//    //オフライン時はnullをセット
			//    this._isupplierDB = null;
			//}

			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 保留 ローカルＤＢ
			////// ローカルDBアクセスオブジェクト取得
			////this._supplierLcDB = new SupplierLcDB();
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 保留 ローカルＤＢ

			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
			//// 仕入先コードフォーマット取得(アクセスクラス用)
			//UiSetFileAcs uiSetFileAcs = new UiSetFileAcs();
			//uiSetFileAcs.ReadXML( string.Empty );
			//UiSet uiset = uiSetFileAcs.GetUiSet( string.Empty, "tNedit_SupplierCd" );
			//if ( uiset != null )
			//{
			//    _supplierCodeFormat = new string( '0', uiset.Column );
			//}
			//else
			//{
			//    _supplierCodeFormat = string.Empty;
			//}
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
			#endregion
		}

		// -- Add St 2012.04.11 30182 R.Tachiya --
		/// <summary>
		/// 仕入先テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <param name="getSupplierCodeFormatOpt">仕入先コードフォーマット取得オプション(取得無しは高速）</param>
		/// <remarks>
		/// <br>Note       : 仕入先テーブルアクセスクラスの新しいインスタンスを初期化します。仕入先コードフォーマットオプション付き。</br>
		/// <br>Programmer : 30182 立谷 亮介</br>
		/// <br>Date       : 2012.04.11</br>
		/// </remarks>
		public SupplierAcs(bool getSupplierCodeFormatOpt)
		{
			//共通コンストラクタ
			this.SupplierAcsProc(getSupplierCodeFormatOpt);
		}

		/// <summary>
		/// 仕入先テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <param name="getSupplierCodeFormatOpt">仕入先コードフォーマット取得オプション(取得無しは高速）</param>
		/// <remarks>
		/// <br>Note       : 仕入先テーブルアクセスクラスの新しいインスタンスを初期化します。共通メソッド。</br>
		/// <br>Programmer : 30182 立谷 亮介</br>
		/// <br>Date       : 2012.04.11</br>
		/// </remarks>
		private void SupplierAcsProc(bool getSupplierCodeFormatOpt)
		{
			try
			{
				// リモートオブジェクト取得
				this._isupplierDB = (ISupplierDB)MediationSupplierDB.GetSupplierDB();
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._isupplierDB = null;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 保留 ローカルＤＢ
			//// ローカルDBアクセスオブジェクト取得
			//this._supplierLcDB = new SupplierLcDB();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 保留 ローカルＤＢ

			//仕入先コードフォーマット取得オプション ON
			if (getSupplierCodeFormatOpt)
			{
				//0詰の桁数を取得//

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
				// 仕入先コードフォーマット取得(アクセスクラス用)
				UiSetFileAcs uiSetFileAcs = new UiSetFileAcs();
				uiSetFileAcs.ReadXML(string.Empty);
				UiSet uiset = uiSetFileAcs.GetUiSet(string.Empty, "tNedit_SupplierCd");
				if (uiset != null)
				{
					_supplierCodeFormat = new string('0', uiset.Column);
				}
				else
				{
					_supplierCodeFormat = string.Empty;
				}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
			}
			//仕入先コードフォーマット取得オプション OFF
			else
			{
				//0詰の桁数取得無//
				_supplierCodeFormat = string.Empty;
			}

			return;
		}
		// -- Add Ed 2012.04.11 30182 R.Tachiya --

        # endregion

        #region Public Property

        //================================================================================
        //  プロパティ
        //================================================================================
        /// <summary>
        /// ローカルＤＢReadモード
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        #endregion

        #region GetOnlineMode

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ( this._isupplierDB == null )
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Read Methods
        // -- ADD 2010/04/06 -------------------------->>>
        /// <summary>
        /// 仕入先読み込み処理(キャッシュ機能有)
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="supplierCode"></param>
        /// <returns></returns>
        public int ReadCache(out Supplier supplier, string enterpriseCode, int supplierCode)
        {
            supplier = null;

            //パラメータが不正の場合は取得処理は行わない
            if (string.IsNullOrEmpty(enterpriseCode) || supplierCode == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            
            // キャッシュから取得
            supplier = this.GetFromCache(supplierCode);
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (supplier == null)
            {
                status = this.Read(out supplier, enterpriseCode, supplierCode);
            }

            return status;

        }
        // -- ADD 2010/04/06 --------------------------<<<

        // --- ADD 2020/02/27 ---------->>>>>
        /// <summary>
        /// 仕入先読み込み処理（ハンディ用）
        /// </summary>
        /// <param name="retValue">仕入先オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報を読み込みます。</br>
        /// <br>Programmer : 31739 岸</br>
        /// <br>Date       : 2020.04.08</br>
        /// </remarks>
        public int ReadHandy(out object retValue, object enterpriseCode, object supplierCode)
        {
            // パラメータ変換
            Supplier result = new Supplier();
            string paraEnterpriseCode = enterpriseCode as string;
            int paraSupplierCode = (int)supplierCode;
            SupplierWork convResult = new SupplierWork();

            // メソッド呼出
            int status = this.Read(out result, paraEnterpriseCode, paraSupplierCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            	if (result != null)
            	{
                    convResult = CopyToSupplierWorkFromSupplier(result);
                }
            }

            // パラメータ変換
            retValue = (object)convResult;

            // 戻り値返却
            return status;
        }
        // --- ADD 2020/02/27 ----------<<<<<

        /// <summary>
        /// 仕入先読み込み処理
        /// </summary>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報を読み込みます。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Read( out Supplier supplier, string enterpriseCode, int supplierCode )
        {
            try
            {
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                //// キャッシュから取得
                //supplier = GetFromCache( supplierCode );
                //if ( supplier != null )
                //{
                //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD

                supplier = new Supplier();
                int status = 0;
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = enterpriseCode;
                supplierWork.SupplierCd = supplierCode;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 保留　ローカル対応
                //if ( _isLocalDBRead )
                //{
                //    status = this._supplierLcDB.Read( ref supplierWork, 0 );
                //}
                //else
                //{
                //    // XMLへ変換し、文字列のバイナリ化
                //    byte[] parabyte = XmlByteSerializer.Serialize( supplierWork );
                //    status = this._isupplierDB.Read( ref parabyte, 0 );

                //    if ( status == 0 )
                //    {
                //        // XMLの読み込み
                //        supplierWork = (SupplierWork)XmlByteSerializer.Deserialize( parabyte, typeof( SupplierWork ) );
                //        // クラス内メンバコピー
                //        supplier = CopyToSupplierFromSupplierWork( supplierWork );
                //    }
                //}

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize( supplierWork );
                status = this._isupplierDB.Read( ref parabyte, 0 );

                if ( status == 0 )
                {
                    // XMLの読み込み
                    supplierWork = (SupplierWork)XmlByteSerializer.Deserialize( parabyte, typeof( SupplierWork ) );
                    // クラス内メンバコピー
                    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    // 2009.02.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 仕入先情報キャッシュ
                    this.UpdateCache(supplier);
                    // 2009.02.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 保留　ローカル対応

                // 2009.02.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (status == 0)
                //{
                //    // クラス内メンバコピー
                //    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                //}
                // 2009.02.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                return status;
            }
            catch ( Exception )
            {
                //通信エラーは-1を戻す
                supplier = null;
                //オフライン時はnullをセット
                this._isupplierDB = null;
                return -1;
            }
        }
        #endregion

        #region Write Methods

        /// <summary>
        /// 仕入先登録・更新処理
        /// </summary>
        /// <param name="supplierList">仕入先リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報の登録・更新を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        //public int Write( ref Supplier supplier )     // DEL 2009/05/27
        public int Write(ref ArrayList supplierList)    // ADD 2009/05/27
        {
            // 仕入先クラスから仕入先ワーカークラスにメンバコピー
            //SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );   // DEL 2009/05/27
            SupplierWork supplierWork = CopyToSupplierWorkFromSupplier(supplierList[0] as Supplier);    // ADD 2009/05/27

            ArrayList paraList = new ArrayList();

            // 親の仕入先を格納
            paraList.Add( supplierWork );

            //object paraObj = paraList;    // DEL 2009/05/27
            int status = 0;
            try
            {
                // ADD 2009/05/27 ------>>>
                object paraSearchObj = supplierWork;
                object outSupplierList;
                // 子の仕入先を取得
                status = this._isupplierDB.SearchWithChildren(out outSupplierList, paraSearchObj, 0, ConstantManagement.LogicalMode.GetDataAll);
                
                // 子の仕入先情報を更新
                if (outSupplierList != null)
                {
                    ArrayList childrenList = outSupplierList as ArrayList;
                    for (int i = 0; i < childrenList.Count; i++)
                    {
                        SupplierWork childSupplierWork = childrenList[i] as SupplierWork;

                        if (childSupplierWork.SupplierCd == supplierWork.SupplierCd)
                        {
                            continue;
                        }
                        else
                        {
                            ReflectChildSupplierFromParent(ref childSupplierWork, supplierWork);
                            paraList.Add(childSupplierWork);
                        }
                    }
                }

                // 親と子の仕入先情報を格納
                object paraObj = paraList;
                // ADD 2009/05/27 ------<<<

                //仕入先書き込み
                status = this._isupplierDB.Write(ref paraObj);

                if ( status == 0 )
                {
                    paraList = (ArrayList)paraObj;
                    // DEL 2009/05/27 ------>>>
                    //supplierWork = (SupplierWork)paraList[0];

                    //// refパラメータを設定
                    //supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                    //// キャッシュ更新
                    //UpdateCache( supplier );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
                    // DEL 2009/05/27 ------<<<
                    
                    // ADD 2009/05/27 ------>>>
                    supplierList = new ArrayList();
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        supplierWork = (SupplierWork)paraList[i];

                        // refパラメータを設定
                        Supplier supplier = CopyToSupplierFromSupplierWork(supplierWork);

                        // キャッシュ更新
                        UpdateCache(supplier);

                        supplierList.Add(supplier);
                    }
                    // ADD 2009/05/27 ------<<<
                }
            }
            catch ( Exception )
            {
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// 仕入先論理削除処理
        /// </summary>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報の論理削除を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int LogicalDelete( ref Supplier supplier )
        {
            int status = 0;

            try
            {
                // 仕入先変換
                ArrayList paraLst = new ArrayList();
                SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );
                paraLst.Add( supplierWork );
                object paraObj = paraLst;

                // 論理削除
                status = this._isupplierDB.LogicalDelete( ref paraObj );

                if ( status == 0 )
                {
                    paraLst = (ArrayList)paraObj;
                    supplierWork = (SupplierWork)paraLst[0];

                    // refパラメータを設定
                    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                    // キャッシュから削除
                    DeleteFromCache( supplier.SupplierCd );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
                }

                return status;
            }
            catch ( Exception )
            {
                //オフライン時はnullをセット
                this._isupplierDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// 仕入先論理削除復活処理
        /// </summary>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報の復活を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Revival( ref Supplier supplier )
        {
            try
            {
                SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );
                ArrayList paraLst = new ArrayList();

                paraLst.Add( supplierWork );

                object paraObj = paraLst;

                // 復活処理
                int status = this._isupplierDB.RevivalLogicalDelete( ref paraObj );

                if ( status == 0 )
                {
                    paraLst = (ArrayList)paraObj;
                    supplierWork = (SupplierWork)paraLst[0];
                    
                    // refパラメータを設定
                    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                    // キャッシュ更新
                    UpdateCache( supplier );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
                }
                return status;
            }
            catch ( Exception )
            {
                //オフライン時はnullをセット
                this._isupplierDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// 仕入先物理削除処理
        /// </summary>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報の物理削除を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Delete( Supplier supplier )
        {
            try
            {
                SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize( supplierWork );

                // 仕入先物理削除
                int status = this._isupplierDB.Delete( parabyte );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                // キャッシュから削除
                DeleteFromCache( supplier.SupplierCd );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD

                return status;
            }
            catch ( Exception )
            {
                //オフライン時はnullをセット
                this._isupplierDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// 仕入先全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Search( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, "", 0, null );
        }

        /// <summary>
        /// 仕入先全検索処理(拠点絞込み)（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">拠点コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Search( out ArrayList retList, string enterpriseCode, string sectionCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null );
        }

        // --- ADD 2020.02.27 ---------->>>>>
        /// <summary>
        /// 仕入先検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先情報を読み込みます。</br>
        /// <br>Programmer : 31739 岸</br>br>
        /// <br>Date       : 2020.02.27</br>
        /// </remarks>
        public int SearchAll(out object retList, object enterpriseCode)
        {
            // 型変換
            ArrayList paraList = new ArrayList();
            string paraEnterpriseCode = enterpriseCode as string;

            // 既存メソッド呼出
            int status = this.SearchAll(out paraList, paraEnterpriseCode);

            ArrayList resultList = new ArrayList();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int count = 0;
                foreach (Supplier itm in paraList)
                {
                	if (itm != null)
                	{
                        if (itm.LogicalDeleteCode == 0)
                        {
                            SupplierWork convWk = CopyToSupplierWorkFromSupplier(itm);
                            resultList.Add(convWk);
                            count++;
                            if (count >= 999)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            // 出力パラメータを呼出パラメータへ設定
            retList = (object)resultList;

            // 既存メソッド呼出結果ステータスを返却
            return status;
        }
        // --- ADD 2020.02.27 ----------<<<<<

        /// <summary>
        /// 仕入先検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null );
        }

        /// <summary>
        /// 仕入先検索処理(拠点絞り込み)（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">仕入先コード</param>		        
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, string enterpriseCode, string sectionCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, null );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
        /// <summary>
        /// 仕入先検索処理（元の"得意先ガイド"の機能に基づく機能追加）
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="searchParameter"></param>
        /// <param name="kanaSearchType">0:前方一致検索,1:曖昧検索</param>
        /// <returns></returns>
        public int Search( out ArrayList retList, Supplier searchParameter, int kanaSearchType )
        {
            retList = new ArrayList();

            ArrayList selectList;
            int retTotalCnt;
            // 管理拠点絞り込みはSearchProcの引数で適用できる(MngSectionCode)
            int status = SearchProc( out selectList, out retTotalCnt, searchParameter.EnterpriseCode, searchParameter.MngSectionCode, 0, null );

            foreach ( object obj in selectList )
            {
                if ( obj is Supplier )
                {
                    Supplier targetSupplier = (obj as Supplier);

                    // コード
                    if ( searchParameter.SupplierCd != 0 && targetSupplier.SupplierCd != searchParameter.SupplierCd ) continue;
                    // カナ(前方一致)
                    if ( searchParameter.SupplierKana != string.Empty && kanaSearchType == (int)SearchMode.StartsWith )
                    {
                        if ( !targetSupplier.SupplierKana.StartsWith( searchParameter.SupplierKana ) ) continue;
                    }
                    // カナ(あいまい)
                    if ( searchParameter.SupplierKana != string.Empty && kanaSearchType == (int)SearchMode.Contains )
                    {
                        if ( !targetSupplier.SupplierKana.Contains( searchParameter.SupplierKana ) ) continue;
                    }
                    //if ( searchParameter.SupplierCd != 0 && targetSupplier.SupplierCd != searchParameter.SupplierCd ) continue;
                    // 仕入担当者コード
                    if ( searchParameter.StockAgentCode != string.Empty && targetSupplier.StockAgentCode != searchParameter.StockAgentCode ) continue;


                    retList.Add( targetSupplier );
                }
            }

            // 返却リストに該当データが無ければデータなしで返す
            if ( status == 0 )
            {
                if ( retList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD

        /// <summary>
        /// 仕入先検索処理(拠点絞込み)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSupplierがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevSupplier">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先の検索処理を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private int SearchProc( out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, Supplier prevSupplier )
        {
            // 初期化
            retList = new ArrayList();
            retTotalCnt = 0;

            // 戻り値リスト
            ArrayList wkList = new ArrayList();

            // 検索条件セット
            SupplierWork supplierWork = new SupplierWork();
            if ( prevSupplier != null ) supplierWork = CopyToSupplierWorkFromSupplier( prevSupplier );

            supplierWork.EnterpriseCode = enterpriseCode;
            supplierWork.MngSectionCode = sectionCode;

            // Searchパラメータ
            ArrayList paraList = new ArrayList();
            paraList.Add( supplierWork );
            object paraobj = paraList;

            // 検索
            object retobj = null;

            int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 保留 ローカルＤＢ
            //if ( _isLocalDBRead )
            //{
            //    // ローカル
            //    List<SupplierWork> supplierWorkList = new List<SupplierWork>();
            //    status_o = this._supplierLcDB.Search( out supplierWorkList, supplierWork, 0, logicalMode );

            //    if ( status_o == 0 )
            //    {
            //        ArrayList al = new ArrayList();
            //        al.AddRange( supplierWorkList );
            //        retobj = (object)al;
            //    }
            //}
            //else
            //{
            //    // リモート
            //    status_o = this._isupplierDB.Search( out retobj, paraobj, 0, logicalMode );
            //}

            // リモート
            status_o = this._isupplierDB.Search( out retobj, paraobj, 0, logicalMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 保留 ローカルＤＢ

            // 検索結果判定
            switch ( status_o )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    wkList = retobj as ArrayList;

                    if ( wkList != null )
                    {
                        foreach ( SupplierWork wkLineupWork in wkList )
                        {
                            if ( (wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.MngSectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.MngSectionCode.TrimEnd() == "")) )
                            {
                                //メンバコピー
                                retList.Add( CopyToSupplierFromSupplierWork( wkLineupWork ) );
                            }
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND: // ADD 2008/11/07
                    status_o = (int)ConstantManagement.DB_Status.ctDB_EOF; // ADD 2008/11/07
                    break;
                default:
                    return status_o;
            }

            return status_o;
        }


        /// <summary>
        /// 仕入先マスタ検索処理（ローカルDB(ガイド)用）
        /// </summary>
        /// <param name="retList">取得結果格納用ArrayList</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタのローカルDB検索処理を行い、取得結果をArryListで返します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int SearchLocalDB( out ArrayList retList, string enterpriseCode, string sectionCode )
        {
            SupplierWork supplierWork = new SupplierWork();
            supplierWork.EnterpriseCode = enterpriseCode;
            supplierWork.MngSectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            int status = 0;

            List<SupplierWork> supplierWorkList = null;

            status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if ( supplierWorkList != null )
                    {
                        foreach ( SupplierWork wkLineupWork in supplierWorkList )
                        {
                            if ( (wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.MngSectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.MngSectionCode.TrimEnd() == "")) )
                            {
                                //メンバコピー
                                retList.Add( CopyToSupplierFromSupplierWork( wkLineupWork ) );
                            }
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            return status;
        }


        #endregion

        #region MemberCopy Methods
        /// <summary>
        /// クラスメンバーコピー処理（仕入先ワーククラス⇒仕入先）
        /// </summary>
        /// <param name="supplierWork">仕入先ワーククラス</param>
        /// <returns>仕入先</returns>
        /// <remarks>
        /// <br>Note       : 仕入先ワーククラスから仕入先へメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private Supplier CopyToSupplierFromSupplierWork( SupplierWork supplierWork )
        {
            Supplier supplier = new Supplier();

            # region [メンバコピー（自動生成）]
            supplier.CreateDateTime = supplierWork.CreateDateTime; // 作成日時
            supplier.UpdateDateTime = supplierWork.UpdateDateTime; // 更新日時
            supplier.EnterpriseCode = supplierWork.EnterpriseCode; // 企業コード
            supplier.FileHeaderGuid = supplierWork.FileHeaderGuid; // GUID
            supplier.UpdEmployeeCode = supplierWork.UpdEmployeeCode; // 更新従業員コード
            supplier.UpdAssemblyId1 = supplierWork.UpdAssemblyId1; // 更新アセンブリID1
            supplier.UpdAssemblyId2 = supplierWork.UpdAssemblyId2; // 更新アセンブリID2
            supplier.LogicalDeleteCode = supplierWork.LogicalDeleteCode; // 論理削除区分
            supplier.SupplierCd = supplierWork.SupplierCd; // 仕入先コード
            supplier.MngSectionCode = supplierWork.MngSectionCode; // 管理拠点コード
            supplier.InpSectionCode = supplierWork.InpSectionCode; // 入力拠点コード
            supplier.PaymentSectionCode = supplierWork.PaymentSectionCode; // 支払拠点コード
            supplier.SupplierNm1 = supplierWork.SupplierNm1; // 仕入先名1
            supplier.SupplierNm2 = supplierWork.SupplierNm2; // 仕入先名2
            supplier.SuppHonorificTitle = supplierWork.SuppHonorificTitle; // 仕入先敬称
            supplier.SupplierKana = supplierWork.SupplierKana; // 仕入先カナ
            supplier.SupplierSnm = supplierWork.SupplierSnm; // 仕入先略称
            supplier.OrderHonorificTtl = supplierWork.OrderHonorificTtl; // 発注書敬称
            supplier.BusinessTypeCode = supplierWork.BusinessTypeCode; // 業種コード
            supplier.SalesAreaCode = supplierWork.SalesAreaCode; // 販売エリアコード
            supplier.SupplierPostNo = supplierWork.SupplierPostNo; // 仕入先郵便番号
            supplier.SupplierAddr1 = supplierWork.SupplierAddr1; // 仕入先住所1（都道府県市区郡・町村・字）
            supplier.SupplierAddr3 = supplierWork.SupplierAddr3; // 仕入先住所3（番地）
            supplier.SupplierAddr4 = supplierWork.SupplierAddr4; // 仕入先住所4（アパート名称）
            supplier.SupplierTelNo = supplierWork.SupplierTelNo; // 仕入先電話番号
            supplier.SupplierTelNo1 = supplierWork.SupplierTelNo1; // 仕入先電話番号1
            supplier.SupplierTelNo2 = supplierWork.SupplierTelNo2; // 仕入先電話番号2
            supplier.PureCode = supplierWork.PureCode; // 純正区分
            supplier.PaymentMonthCode = supplierWork.PaymentMonthCode; // 支払月区分コード
            supplier.PaymentMonthName = supplierWork.PaymentMonthName; // 支払月区分名称
            supplier.PaymentDay = supplierWork.PaymentDay; // 支払日
            supplier.SuppCTaxLayRefCd = supplierWork.SuppCTaxLayRefCd; // 仕入先消費税転嫁方式参照区分
            supplier.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            supplier.SuppCTaxationCd = supplierWork.SuppCTaxationCd; // 仕入先課税方式コード
            supplier.SuppEnterpriseCd = supplierWork.SuppEnterpriseCd; // 仕入先企業コード
            supplier.PayeeCode = supplierWork.PayeeCode; // 支払先コード
            supplier.SupplierAttributeDiv = supplierWork.SupplierAttributeDiv; // 仕入先属性区分
            supplier.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd; // 仕入先総額表示方法区分
            supplier.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef; // 仕入時総額表示方法参照区分
            supplier.PaymentCond = supplierWork.PaymentCond; // 支払条件
            supplier.PaymentTotalDay = supplierWork.PaymentTotalDay; // 支払締日
            supplier.PaymentSight = supplierWork.PaymentSight; // 支払サイト
            supplier.StockAgentCode = supplierWork.StockAgentCode; // 仕入担当者コード
            supplier.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd; // 仕入単価端数処理コード
            supplier.StockMoneyFrcProcCd = supplierWork.StockMoneyFrcProcCd; // 仕入金額端数処理コード
            supplier.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd; // 仕入消費税端数処理コード
            supplier.NTimeCalcStDate = supplierWork.NTimeCalcStDate; // 次回勘定開始日
            supplier.SupplierNote1 = supplierWork.SupplierNote1; // 仕入先備考1
            supplier.SupplierNote2 = supplierWork.SupplierNote2; // 仕入先備考2
            supplier.SupplierNote3 = supplierWork.SupplierNote3; // 仕入先備考3
            supplier.SupplierNote4 = supplierWork.SupplierNote4; // 仕入先備考4
            supplier.StockAgentName = supplierWork.StockAgentName; // 仕入担当者名称
            supplier.MngSectionName = supplierWork.MngSectionName; // 管理拠点名称
            supplier.InpSectionName = supplierWork.InpSectionName; // 入力拠点名称
            supplier.PaymentSectionName = supplierWork.PaymentSectionName; // 支払拠点名称
            supplier.BusinessTypeName = supplierWork.BusinessTypeName; // 業種名称
            supplier.SalesAreaName = supplierWork.SalesAreaName; // 販売エリア名称
            supplier.PayeeName = supplierWork.PayeeName; // 支払先名称
            supplier.PayeeName2 = supplierWork.PayeeName2; // 支払先名称２
            supplier.PayeeSnm = supplierWork.PayeeSnm; // 支払先略称
            # endregion

            return supplier;
        }

        /// <summary>
        /// クラスメンバーコピー処理（仕入先⇒仕入先ワーククラス）
        /// </summary>
        /// <param name="supplier">仕入先クラス</param>
        /// <returns>仕入先ワーク</returns>
        /// <remarks>
        /// <br>Note       : 仕入先から仕入先ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private SupplierWork CopyToSupplierWorkFromSupplier( Supplier supplier )
        {
            SupplierWork supplierWork = new SupplierWork();

            # region [メンバコピー（自動生成）]
            supplierWork.CreateDateTime = supplier.CreateDateTime; // 作成日時
            supplierWork.UpdateDateTime = supplier.UpdateDateTime; // 更新日時
            supplierWork.EnterpriseCode = supplier.EnterpriseCode; // 企業コード
            supplierWork.FileHeaderGuid = supplier.FileHeaderGuid; // GUID
            supplierWork.UpdEmployeeCode = supplier.UpdEmployeeCode; // 更新従業員コード
            supplierWork.UpdAssemblyId1 = supplier.UpdAssemblyId1; // 更新アセンブリID1
            supplierWork.UpdAssemblyId2 = supplier.UpdAssemblyId2; // 更新アセンブリID2
            supplierWork.LogicalDeleteCode = supplier.LogicalDeleteCode; // 論理削除区分
            supplierWork.SupplierCd = supplier.SupplierCd; // 仕入先コード
            supplierWork.MngSectionCode = supplier.MngSectionCode; // 管理拠点コード
            supplierWork.InpSectionCode = supplier.InpSectionCode; // 入力拠点コード
            supplierWork.PaymentSectionCode = supplier.PaymentSectionCode; // 支払拠点コード
            supplierWork.SupplierNm1 = supplier.SupplierNm1; // 仕入先名1
            supplierWork.SupplierNm2 = supplier.SupplierNm2; // 仕入先名2
            supplierWork.SuppHonorificTitle = supplier.SuppHonorificTitle; // 仕入先敬称
            supplierWork.SupplierKana = supplier.SupplierKana; // 仕入先カナ
            supplierWork.SupplierSnm = supplier.SupplierSnm; // 仕入先略称
            supplierWork.OrderHonorificTtl = supplier.OrderHonorificTtl; // 発注書敬称
            supplierWork.BusinessTypeCode = supplier.BusinessTypeCode; // 業種コード
            supplierWork.SalesAreaCode = supplier.SalesAreaCode; // 販売エリアコード
            supplierWork.SupplierPostNo = supplier.SupplierPostNo; // 仕入先郵便番号
            supplierWork.SupplierAddr1 = supplier.SupplierAddr1; // 仕入先住所1（都道府県市区郡・町村・字）
            supplierWork.SupplierAddr3 = supplier.SupplierAddr3; // 仕入先住所3（番地）
            supplierWork.SupplierAddr4 = supplier.SupplierAddr4; // 仕入先住所4（アパート名称）
            supplierWork.SupplierTelNo = supplier.SupplierTelNo; // 仕入先電話番号
            supplierWork.SupplierTelNo1 = supplier.SupplierTelNo1; // 仕入先電話番号1
            supplierWork.SupplierTelNo2 = supplier.SupplierTelNo2; // 仕入先電話番号2
            supplierWork.PureCode = supplier.PureCode; // 純正区分
            supplierWork.PaymentMonthCode = supplier.PaymentMonthCode; // 支払月区分コード
            supplierWork.PaymentMonthName = supplier.PaymentMonthName; // 支払月区分名称
            supplierWork.PaymentDay = supplier.PaymentDay; // 支払日
            supplierWork.SuppCTaxLayRefCd = supplier.SuppCTaxLayRefCd; // 仕入先消費税転嫁方式参照区分
            supplierWork.SuppCTaxLayCd = supplier.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            supplierWork.SuppCTaxationCd = supplier.SuppCTaxationCd; // 仕入先課税方式コード
            supplierWork.SuppEnterpriseCd = supplier.SuppEnterpriseCd; // 仕入先企業コード
            supplierWork.PayeeCode = supplier.PayeeCode; // 支払先コード
            supplierWork.SupplierAttributeDiv = supplier.SupplierAttributeDiv; // 仕入先属性区分
            supplierWork.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd; // 仕入先総額表示方法区分
            supplierWork.StckTtlAmntDspWayRef = supplier.StckTtlAmntDspWayRef; // 仕入時総額表示方法参照区分
            supplierWork.PaymentCond = supplier.PaymentCond; // 支払条件
            supplierWork.PaymentTotalDay = supplier.PaymentTotalDay; // 支払締日
            supplierWork.PaymentSight = supplier.PaymentSight; // 支払サイト
            supplierWork.StockAgentCode = supplier.StockAgentCode; // 仕入担当者コード
            supplierWork.StockUnPrcFrcProcCd = supplier.StockUnPrcFrcProcCd; // 仕入単価端数処理コード
            supplierWork.StockMoneyFrcProcCd = supplier.StockMoneyFrcProcCd; // 仕入金額端数処理コード
            supplierWork.StockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd; // 仕入消費税端数処理コード
            supplierWork.NTimeCalcStDate = supplier.NTimeCalcStDate; // 次回勘定開始日
            supplierWork.SupplierNote1 = supplier.SupplierNote1; // 仕入先備考1
            supplierWork.SupplierNote2 = supplier.SupplierNote2; // 仕入先備考2
            supplierWork.SupplierNote3 = supplier.SupplierNote3; // 仕入先備考3
            supplierWork.SupplierNote4 = supplier.SupplierNote4; // 仕入先備考4
            supplierWork.StockAgentName = supplier.StockAgentName; // 仕入担当者名称
            supplierWork.MngSectionName = supplier.MngSectionName; // 管理拠点名称
            supplierWork.InpSectionName = supplier.InpSectionName; // 入力拠点名称
            supplierWork.PaymentSectionName = supplier.PaymentSectionName; // 支払拠点名称
            supplierWork.BusinessTypeName = supplier.BusinessTypeName; // 業種名称
            supplierWork.SalesAreaName = supplier.SalesAreaName; // 販売エリア名称
            supplierWork.PayeeName = supplier.PayeeName; // 支払先名称
            supplierWork.PayeeName2 = supplier.PayeeName2; // 支払先名称２
            supplierWork.PayeeSnm = supplier.PayeeSnm; // 支払先略称
            # endregion

            return supplierWork;
        }

        /// <summary>
        /// クラスメンバコピー処理 (ガイド選択データ⇒仕訳科目設定マスタクラス)
        /// </summary>
        /// <param name="guideData">ガイド選択データ</param>
        /// <returns>仕訳科目設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ガイド選択データから仕訳科目設定マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private Supplier CopyToSupplierFromGuideData( Hashtable guideData )
        {
            Supplier supplier = new Supplier();

            # region [ガイド結果からデータ取得（自動生成）]
            supplier.SupplierCd = (Int32)guideData[GUIDE_SUPPLIERCD_TITLE]; // 仕入先コード
            supplier.MngSectionCode = (string)guideData[GUIDE_MNGSECTIONCODE_TITLE]; // 管理拠点コード
            supplier.InpSectionCode = (string)guideData[GUIDE_INPSECTIONCODE_TITLE]; // 入力拠点コード
            supplier.PaymentSectionCode = (string)guideData[GUIDE_PAYMENTSECTIONCODE_TITLE]; // 支払拠点コード
            supplier.SupplierNm1 = (string)guideData[GUIDE_SUPPLIERNM1_TITLE]; // 仕入先名1
            supplier.SupplierNm2 = (string)guideData[GUIDE_SUPPLIERNM2_TITLE]; // 仕入先名2
            supplier.SuppHonorificTitle = (string)guideData[GUIDE_SUPPHONORIFICTITLE_TITLE]; // 仕入先敬称
            supplier.SupplierKana = (string)guideData[GUIDE_SUPPLIERKANA_TITLE]; // 仕入先カナ
            supplier.SupplierSnm = (string)guideData[GUIDE_SUPPLIERSNM_TITLE]; // 仕入先略称
            supplier.OrderHonorificTtl = (string)guideData[GUIDE_ORDERHONORIFICTTL_TITLE]; // 発注書敬称
            supplier.BusinessTypeCode = (Int32)guideData[GUIDE_BUSINESSTYPECODE_TITLE]; // 業種コード
            supplier.SalesAreaCode = (Int32)guideData[GUIDE_SALESAREACODE_TITLE]; // 販売エリアコード
            supplier.SupplierPostNo = (string)guideData[GUIDE_SUPPLIERPOSTNO_TITLE]; // 仕入先郵便番号
            supplier.SupplierAddr1 = (string)guideData[GUIDE_SUPPLIERADDR1_TITLE]; // 仕入先住所1（都道府県市区郡・町村・字）
            supplier.SupplierAddr3 = (string)guideData[GUIDE_SUPPLIERADDR3_TITLE]; // 仕入先住所3（番地）
            supplier.SupplierAddr4 = (string)guideData[GUIDE_SUPPLIERADDR4_TITLE]; // 仕入先住所4（アパート名称）
            supplier.SupplierTelNo = (string)guideData[GUIDE_SUPPLIERTELNO_TITLE]; // 仕入先電話番号
            supplier.SupplierTelNo1 = (string)guideData[GUIDE_SUPPLIERTELNO1_TITLE]; // 仕入先電話番号1
            supplier.SupplierTelNo2 = (string)guideData[GUIDE_SUPPLIERTELNO2_TITLE]; // 仕入先電話番号2
            supplier.PureCode = (Int32)guideData[GUIDE_PURECODE_TITLE]; // 純正区分
            supplier.PaymentMonthCode = (Int32)guideData[GUIDE_PAYMENTMONTHCODE_TITLE]; // 支払月区分コード
            supplier.PaymentMonthName = (string)guideData[GUIDE_PAYMENTMONTHNAME_TITLE]; // 支払月区分名称
            supplier.PaymentDay = (Int32)guideData[GUIDE_PAYMENTDAY_TITLE]; // 支払日
            supplier.SuppCTaxLayRefCd = (Int32)guideData[GUIDE_SUPPCTAXLAYREFCD_TITLE]; // 仕入先消費税転嫁方式参照区分
            supplier.SuppCTaxLayCd = (Int32)guideData[GUIDE_SUPPCTAXLAYCD_TITLE]; // 仕入先消費税転嫁方式コード
            supplier.SuppCTaxationCd = (Int32)guideData[GUIDE_SUPPCTAXATIONCD_TITLE]; // 仕入先課税方式コード
            supplier.SuppEnterpriseCd = (string)guideData[GUIDE_SUPPENTERPRISECD_TITLE]; // 仕入先企業コード
            supplier.PayeeCode = (Int32)guideData[GUIDE_PAYEECODE_TITLE]; // 支払先コード
            supplier.SupplierAttributeDiv = (Int32)guideData[GUIDE_SUPPLIERATTRIBUTEDIV_TITLE]; // 仕入先属性区分
            supplier.SuppTtlAmntDspWayCd = (Int32)guideData[GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE]; // 仕入先総額表示方法区分
            supplier.StckTtlAmntDspWayRef = (Int32)guideData[GUIDE_STCKTTLAMNTDSPWAYREF_TITLE]; // 仕入時総額表示方法参照区分
            supplier.PaymentCond = (Int32)guideData[GUIDE_PAYMENTCOND_TITLE]; // 支払条件
            supplier.PaymentTotalDay = (Int32)guideData[GUIDE_PAYMENTTOTALDAY_TITLE]; // 支払締日
            supplier.PaymentSight = (Int32)guideData[GUIDE_PAYMENTSIGHT_TITLE]; // 支払サイト
            supplier.StockAgentCode = (string)guideData[GUIDE_STOCKAGENTCODE_TITLE]; // 仕入担当者コード
            supplier.StockUnPrcFrcProcCd = (Int32)guideData[GUIDE_STOCKUNPRCFRCPROCCD_TITLE]; // 仕入単価端数処理コード
            supplier.StockMoneyFrcProcCd = (Int32)guideData[GUIDE_STOCKMONEYFRCPROCCD_TITLE]; // 仕入金額端数処理コード
            supplier.StockCnsTaxFrcProcCd = (Int32)guideData[GUIDE_STOCKCNSTAXFRCPROCCD_TITLE]; // 仕入消費税端数処理コード
            supplier.NTimeCalcStDate = (Int32)guideData[GUIDE_NTIMECALCSTDATE_TITLE]; // 次回勘定開始日
            supplier.SupplierNote1 = (string)guideData[GUIDE_SUPPLIERNOTE1_TITLE]; // 仕入先備考1
            supplier.SupplierNote2 = (string)guideData[GUIDE_SUPPLIERNOTE2_TITLE]; // 仕入先備考2
            supplier.SupplierNote3 = (string)guideData[GUIDE_SUPPLIERNOTE3_TITLE]; // 仕入先備考3
            supplier.SupplierNote4 = (string)guideData[GUIDE_SUPPLIERNOTE4_TITLE]; // 仕入先備考4
            supplier.StockAgentName = (string)guideData[GUIDE_STOCKAGENTNAME_TITLE]; // 仕入担当者名称
            supplier.MngSectionName = (string)guideData[GUIDE_MNGSECTIONNAME_TITLE]; // 管理拠点名称
            supplier.InpSectionName = (string)guideData[GUIDE_INPSECTIONNAME_TITLE]; // 入力拠点名称
            supplier.PaymentSectionName = (string)guideData[GUIDE_PAYMENTSECTIONNAME_TITLE]; // 支払拠点名称
            supplier.BusinessTypeName = (string)guideData[GUIDE_BUSINESSTYPENAME_TITLE]; // 業種名称
            supplier.SalesAreaName = (string)guideData[GUIDE_SALESAREANAME_TITLE]; // 販売エリア名称
            supplier.PayeeName = (string)guideData[GUIDE_PAYEENAME_TITLE]; // 支払先名称
            supplier.PayeeName2 = (string)guideData[GUIDE_PAYEENAME2_TITLE]; // 支払先名称２
            supplier.PayeeSnm = (string)guideData[GUIDE_PAYEESNM_TITLE]; // 支払先略称            
            # endregion

            return supplier;
        }

        /// <summary>
        /// DataRowコピー処理（仕入先クラス⇒ガイド用DataRow）
        /// </summary>
        /// <param name="guideRow">ガイド用DataRow</param>
        /// <param name="supplier">仕入先クラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先クラスからガイド用DataRowへコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void CopyToGuideRowFromSupplier( ref DataRow guideRow, Supplier supplier )
        {
            # region [データからガイドにセット（自動生成）]
            guideRow[GUIDE_SUPPLIERCD_TITLE] = supplier.SupplierCd; // 仕入先コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            guideRow[GUIDE_SUPPLIERCD_ZERO_TITLE] = supplier.SupplierCd.ToString( _supplierCodeFormat ); // 仕入先コードゼロ詰め
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            guideRow[GUIDE_MNGSECTIONCODE_TITLE] = supplier.MngSectionCode; // 管理拠点コード
            guideRow[GUIDE_INPSECTIONCODE_TITLE] = supplier.InpSectionCode; // 入力拠点コード
            guideRow[GUIDE_PAYMENTSECTIONCODE_TITLE] = supplier.PaymentSectionCode; // 支払拠点コード
            guideRow[GUIDE_SUPPLIERNM1_TITLE] = supplier.SupplierNm1; // 仕入先名1
            guideRow[GUIDE_SUPPLIERNM2_TITLE] = supplier.SupplierNm2; // 仕入先名2
            guideRow[GUIDE_SUPPHONORIFICTITLE_TITLE] = supplier.SuppHonorificTitle; // 仕入先敬称
            guideRow[GUIDE_SUPPLIERKANA_TITLE] = supplier.SupplierKana; // 仕入先カナ
            guideRow[GUIDE_SUPPLIERSNM_TITLE] = supplier.SupplierSnm; // 仕入先略称
            guideRow[GUIDE_ORDERHONORIFICTTL_TITLE] = supplier.OrderHonorificTtl; // 発注書敬称
            guideRow[GUIDE_BUSINESSTYPECODE_TITLE] = supplier.BusinessTypeCode; // 業種コード
            guideRow[GUIDE_SALESAREACODE_TITLE] = supplier.SalesAreaCode; // 販売エリアコード
            guideRow[GUIDE_SUPPLIERPOSTNO_TITLE] = supplier.SupplierPostNo; // 仕入先郵便番号
            guideRow[GUIDE_SUPPLIERADDR1_TITLE] = supplier.SupplierAddr1; // 仕入先住所1（都道府県市区郡・町村・字）
            guideRow[GUIDE_SUPPLIERADDR3_TITLE] = supplier.SupplierAddr3; // 仕入先住所3（番地）
            guideRow[GUIDE_SUPPLIERADDR4_TITLE] = supplier.SupplierAddr4; // 仕入先住所4（アパート名称）
            guideRow[GUIDE_SUPPLIERTELNO_TITLE] = supplier.SupplierTelNo; // 仕入先電話番号
            guideRow[GUIDE_SUPPLIERTELNO1_TITLE] = supplier.SupplierTelNo1; // 仕入先電話番号1
            guideRow[GUIDE_SUPPLIERTELNO2_TITLE] = supplier.SupplierTelNo2; // 仕入先電話番号2
            guideRow[GUIDE_PURECODE_TITLE] = supplier.PureCode; // 純正区分
            guideRow[GUIDE_PAYMENTMONTHCODE_TITLE] = supplier.PaymentMonthCode; // 支払月区分コード
            guideRow[GUIDE_PAYMENTMONTHNAME_TITLE] = supplier.PaymentMonthName; // 支払月区分名称
            guideRow[GUIDE_PAYMENTDAY_TITLE] = supplier.PaymentDay; // 支払日
            guideRow[GUIDE_SUPPCTAXLAYREFCD_TITLE] = supplier.SuppCTaxLayRefCd; // 仕入先消費税転嫁方式参照区分
            guideRow[GUIDE_SUPPCTAXLAYCD_TITLE] = supplier.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            guideRow[GUIDE_SUPPCTAXATIONCD_TITLE] = supplier.SuppCTaxationCd; // 仕入先課税方式コード
            guideRow[GUIDE_SUPPENTERPRISECD_TITLE] = supplier.SuppEnterpriseCd; // 仕入先企業コード
            guideRow[GUIDE_PAYEECODE_TITLE] = supplier.PayeeCode; // 支払先コード
            guideRow[GUIDE_SUPPLIERATTRIBUTEDIV_TITLE] = supplier.SupplierAttributeDiv; // 仕入先属性区分
            guideRow[GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE] = supplier.SuppTtlAmntDspWayCd; // 仕入先総額表示方法区分
            guideRow[GUIDE_STCKTTLAMNTDSPWAYREF_TITLE] = supplier.StckTtlAmntDspWayRef; // 仕入時総額表示方法参照区分
            guideRow[GUIDE_PAYMENTCOND_TITLE] = supplier.PaymentCond; // 支払条件
            guideRow[GUIDE_PAYMENTTOTALDAY_TITLE] = supplier.PaymentTotalDay; // 支払締日
            guideRow[GUIDE_PAYMENTSIGHT_TITLE] = supplier.PaymentSight; // 支払サイト
            guideRow[GUIDE_STOCKAGENTCODE_TITLE] = supplier.StockAgentCode; // 仕入担当者コード
            guideRow[GUIDE_STOCKUNPRCFRCPROCCD_TITLE] = supplier.StockUnPrcFrcProcCd; // 仕入単価端数処理コード
            guideRow[GUIDE_STOCKMONEYFRCPROCCD_TITLE] = supplier.StockMoneyFrcProcCd; // 仕入金額端数処理コード
            guideRow[GUIDE_STOCKCNSTAXFRCPROCCD_TITLE] = supplier.StockCnsTaxFrcProcCd; // 仕入消費税端数処理コード
            guideRow[GUIDE_NTIMECALCSTDATE_TITLE] = supplier.NTimeCalcStDate; // 次回勘定開始日
            guideRow[GUIDE_SUPPLIERNOTE1_TITLE] = supplier.SupplierNote1; // 仕入先備考1
            guideRow[GUIDE_SUPPLIERNOTE2_TITLE] = supplier.SupplierNote2; // 仕入先備考2
            guideRow[GUIDE_SUPPLIERNOTE3_TITLE] = supplier.SupplierNote3; // 仕入先備考3
            guideRow[GUIDE_SUPPLIERNOTE4_TITLE] = supplier.SupplierNote4; // 仕入先備考4
            guideRow[GUIDE_STOCKAGENTNAME_TITLE] = supplier.StockAgentName; // 仕入担当者名称
            guideRow[GUIDE_MNGSECTIONNAME_TITLE] = supplier.MngSectionName; // 管理拠点名称
            guideRow[GUIDE_INPSECTIONNAME_TITLE] = supplier.InpSectionName; // 入力拠点名称
            guideRow[GUIDE_PAYMENTSECTIONNAME_TITLE] = supplier.PaymentSectionName; // 支払拠点名称
            guideRow[GUIDE_BUSINESSTYPENAME_TITLE] = supplier.BusinessTypeName; // 業種名称
            guideRow[GUIDE_SALESAREANAME_TITLE] = supplier.SalesAreaName; // 販売エリア名称
            guideRow[GUIDE_PAYEENAME_TITLE] = supplier.PayeeName; // 支払先名称
            guideRow[GUIDE_PAYEENAME2_TITLE] = supplier.PayeeName2; // 支払先名称２
            guideRow[GUIDE_PAYEESNM_TITLE] = supplier.PayeeSnm; // 支払先略称
            # endregion
        }

        #endregion

        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="supplier">取得データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int ExecuteGuid( out Supplier supplier, string enterpriseCode, string sectionCode )
        {
            int status = -1;
            supplier = new Supplier();

            TableGuideParent tableGuideParent = new TableGuideParent( GUIDE_XML_FILENAME );
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add( GUIDE_ENTERPRISECODE_PARA, enterpriseCode );   // 企業コード
            inObj.Add( GUIDE_MNGSECTIONCODE_PARA, sectionCode );        // 拠点コード

            // ガイド起動
            if ( tableGuideParent.Execute( 0, inObj, ref retObj ) )
            {
                // 選択データの取得
                supplier = CopyToSupplierFromGuideData( retObj );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                supplier.EnterpriseCode = enterpriseCode;   // 企業コードセット
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                status = 0;
            }
            else
            {
                // キャンセル
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int GetGuideData( int mode, Hashtable inParm, ref DataSet guideList )
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

            if ( inParm.ContainsKey( GUIDE_ENTERPRISECODE_PARA ) )
            {
                // 企業コード設定有り
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
            }
            else
            {
                // 企業コード設定無し
                // 有り得ないのでエラー
                return status;
            }

            // 拠点コード設定有り
            if ( inParm.ContainsKey( GUIDE_MNGSECTIONCODE_PARA ) )
            {
                sectionCode = inParm[GUIDE_MNGSECTIONCODE_PARA].ToString();
            }

            // マスタテーブル読込み(ローカルDBに変更)
            ArrayList retList;
            status = this.SearchAll( out retList, enterpriseCode, sectionCode );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // ガイド初期起動時
                    if ( guideList.Tables.Count == 0 )
                    {
                        // ガイド用データセット列情報構築
                        this.GuideDataSetColumnConstruction( ref guideList );
                    }

                    // ガイド用データセットの作成
                    this.GetGuideDataSet( ref guideList, retList, inParm );

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = 4;
                    break;
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
        /// <param name="retList">結果取得アレイリスト</param>>
        /// <param name="inParm">絞込条件</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GetGuideDataSet( ref DataSet retDataSet, ArrayList retList, Hashtable inParm )
        {
            Supplier supplier = null;
            DataRow guideRow = null;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while ( dataCnt < retList.Count )
            {
                supplier = (Supplier)retList[dataCnt];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                if ( supplier.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                {
                    guideRow = retDataSet.Tables[0].NewRow();
                    // データコピー処理
                    CopyToGuideRowFromSupplier( ref guideRow, supplier );
                    // データ追加
                    retDataSet.Tables[0].Rows.Add( guideRow );
                }
                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// ガイド用データセット列情報構築処理
        /// </summary>
        /// <param name="guideList">ガイド用データセット</param>>
        /// <remarks>
        /// <br>Note       : ガイド用データセットの列情報を構築します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction( ref DataSet guideList )
        {
            DataTable table = new DataTable();

            # region [ガイド用テーブル生成（自動生成）]
            // 仕入先コード
            table.Columns.Add( GUIDE_SUPPLIERCD_TITLE, typeof( Int32 ) );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            // 表示用仕入先コード(ゼロ詰め)
            table.Columns.Add( GUIDE_SUPPLIERCD_ZERO_TITLE, typeof( string ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            // 管理拠点コード
            table.Columns.Add( GUIDE_MNGSECTIONCODE_TITLE, typeof( string ) );
            // 入力拠点コード
            table.Columns.Add( GUIDE_INPSECTIONCODE_TITLE, typeof( string ) );
            // 支払拠点コード
            table.Columns.Add( GUIDE_PAYMENTSECTIONCODE_TITLE, typeof( string ) );
            // 仕入先名1
            table.Columns.Add( GUIDE_SUPPLIERNM1_TITLE, typeof( string ) );
            // 仕入先名2
            table.Columns.Add( GUIDE_SUPPLIERNM2_TITLE, typeof( string ) );
            // 仕入先敬称
            table.Columns.Add( GUIDE_SUPPHONORIFICTITLE_TITLE, typeof( string ) );
            // 仕入先カナ
            table.Columns.Add( GUIDE_SUPPLIERKANA_TITLE, typeof( string ) );
            // 仕入先略称
            table.Columns.Add( GUIDE_SUPPLIERSNM_TITLE, typeof( string ) );
            // 発注書敬称
            table.Columns.Add( GUIDE_ORDERHONORIFICTTL_TITLE, typeof( string ) );
            // 業種コード
            table.Columns.Add( GUIDE_BUSINESSTYPECODE_TITLE, typeof( Int32 ) );
            // 販売エリアコード
            table.Columns.Add( GUIDE_SALESAREACODE_TITLE, typeof( Int32 ) );
            // 仕入先郵便番号
            table.Columns.Add( GUIDE_SUPPLIERPOSTNO_TITLE, typeof( string ) );
            // 仕入先住所1（都道府県市区郡・町村・字）
            table.Columns.Add( GUIDE_SUPPLIERADDR1_TITLE, typeof( string ) );
            // 仕入先住所3（番地）
            table.Columns.Add( GUIDE_SUPPLIERADDR3_TITLE, typeof( string ) );
            // 仕入先住所4（アパート名称）
            table.Columns.Add( GUIDE_SUPPLIERADDR4_TITLE, typeof( string ) );
            // 仕入先電話番号
            table.Columns.Add( GUIDE_SUPPLIERTELNO_TITLE, typeof( string ) );
            // 仕入先電話番号1
            table.Columns.Add( GUIDE_SUPPLIERTELNO1_TITLE, typeof( string ) );
            // 仕入先電話番号2
            table.Columns.Add( GUIDE_SUPPLIERTELNO2_TITLE, typeof( string ) );
            // 純正区分
            table.Columns.Add( GUIDE_PURECODE_TITLE, typeof( Int32 ) );
            // 支払月区分コード
            table.Columns.Add( GUIDE_PAYMENTMONTHCODE_TITLE, typeof( Int32 ) );
            // 支払月区分名称
            table.Columns.Add( GUIDE_PAYMENTMONTHNAME_TITLE, typeof( string ) );
            // 支払日
            table.Columns.Add( GUIDE_PAYMENTDAY_TITLE, typeof( Int32 ) );
            // 仕入先消費税転嫁方式参照区分
            table.Columns.Add( GUIDE_SUPPCTAXLAYREFCD_TITLE, typeof( Int32 ) );
            // 仕入先消費税転嫁方式コード
            table.Columns.Add( GUIDE_SUPPCTAXLAYCD_TITLE, typeof( Int32 ) );
            // 仕入先課税方式コード
            table.Columns.Add( GUIDE_SUPPCTAXATIONCD_TITLE, typeof( Int32 ) );
            // 仕入先企業コード
            table.Columns.Add( GUIDE_SUPPENTERPRISECD_TITLE, typeof( string ) );
            // 支払先コード
            table.Columns.Add( GUIDE_PAYEECODE_TITLE, typeof( Int32 ) );
            // 仕入先属性区分
            table.Columns.Add( GUIDE_SUPPLIERATTRIBUTEDIV_TITLE, typeof( Int32 ) );
            // 仕入先総額表示方法区分
            table.Columns.Add( GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE, typeof( Int32 ) );
            // 仕入時総額表示方法参照区分
            table.Columns.Add( GUIDE_STCKTTLAMNTDSPWAYREF_TITLE, typeof( Int32 ) );
            // 支払条件
            table.Columns.Add( GUIDE_PAYMENTCOND_TITLE, typeof( Int32 ) );
            // 支払締日
            table.Columns.Add( GUIDE_PAYMENTTOTALDAY_TITLE, typeof( Int32 ) );
            // 支払サイト
            table.Columns.Add( GUIDE_PAYMENTSIGHT_TITLE, typeof( Int32 ) );
            // 仕入担当者コード
            table.Columns.Add( GUIDE_STOCKAGENTCODE_TITLE, typeof( string ) );
            // 仕入単価端数処理コード
            table.Columns.Add( GUIDE_STOCKUNPRCFRCPROCCD_TITLE, typeof( Int32 ) );
            // 仕入金額端数処理コード
            table.Columns.Add( GUIDE_STOCKMONEYFRCPROCCD_TITLE, typeof( Int32 ) );
            // 仕入消費税端数処理コード
            table.Columns.Add( GUIDE_STOCKCNSTAXFRCPROCCD_TITLE, typeof( Int32 ) );
            // 仕入先掛率グループコード
            table.Columns.Add( GUIDE_SUPPRATEGRPCODE_TITLE, typeof( Int32 ) );
            // 次回勘定開始日
            table.Columns.Add( GUIDE_NTIMECALCSTDATE_TITLE, typeof( Int32 ) );
            // 仕入先備考1
            table.Columns.Add( GUIDE_SUPPLIERNOTE1_TITLE, typeof( string ) );
            // 仕入先備考2
            table.Columns.Add( GUIDE_SUPPLIERNOTE2_TITLE, typeof( string ) );
            // 仕入先備考3
            table.Columns.Add( GUIDE_SUPPLIERNOTE3_TITLE, typeof( string ) );
            // 仕入先備考4
            table.Columns.Add( GUIDE_SUPPLIERNOTE4_TITLE, typeof( string ) );
            // 仕入担当者名称
            table.Columns.Add( GUIDE_STOCKAGENTNAME_TITLE, typeof( string ) );
            // 管理拠点名称
            table.Columns.Add( GUIDE_MNGSECTIONNAME_TITLE, typeof( string ) );
            // 入力拠点名称
            table.Columns.Add( GUIDE_INPSECTIONNAME_TITLE, typeof( string ) );
            // 支払拠点名称
            table.Columns.Add( GUIDE_PAYMENTSECTIONNAME_TITLE, typeof( string ) );
            // 業種名称
            table.Columns.Add( GUIDE_BUSINESSTYPENAME_TITLE, typeof( string ) );
            // 販売エリア名称
            table.Columns.Add( GUIDE_SALESAREANAME_TITLE, typeof( string ) );
            // 支払先名称
            table.Columns.Add( GUIDE_PAYEENAME_TITLE, typeof( string ) );
            // 支払先名称２
            table.Columns.Add( GUIDE_PAYEENAME2_TITLE, typeof( string ) );
            // 支払先略称
            table.Columns.Add( GUIDE_PAYEESNM_TITLE, typeof( string ) );
            # endregion

            // テーブルコピー
            guideList.Tables.Add( table.Clone() );
        }
        #endregion

        # region [キャッシュ制御]
        /// <summary>
        /// キャッシュ更新処理
        /// </summary>
        /// <param name="supplier"></param>
        /// <remarks>金額端数処理取得を含めてReadの利用頻度を考慮し、キャッシュ制御を行います。</remarks>
        private void UpdateCache( Supplier supplier )
        {
            // staticディクショナリが無ければ生成
            if ( _supplierDic == null )
            {
                _supplierDic = new Dictionary<int, Supplier>();
            }
            // 既存ならば削除
            if ( _supplierDic.ContainsKey( supplier.SupplierCd ) )
            {
                _supplierDic.Remove( supplier.SupplierCd );
            }
            // 追加
            _supplierDic.Add( supplier.SupplierCd, supplier );
        }
        /// <summary>
        /// キャッシュ取得処理
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>金額端数処理取得を含めてReadの利用頻度を考慮し、キャッシュ制御を行います。</remarks>
        private Supplier GetFromCache( int supplierCode )
        {
            if ( _supplierDic != null )
            {
                // キャッシュから取得
                if ( _supplierDic.ContainsKey( supplierCode ) )
                {
                    return _supplierDic[supplierCode];
                }
            }

            return null;
        }
        /// <summary>
        /// キャッシュ削除処理
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>金額端数処理取得を含めてReadの利用頻度を考慮し、キャッシュ制御を行います。</remarks>
        private void DeleteFromCache(int supplierCode)
        {
            if (_supplierDic != null)
            {
                // キャッシュから削除
                if (_supplierDic.ContainsKey(supplierCode))
                {
                    _supplierDic.Remove(supplierCode);
                }
            }
        }
        
        // -- ADD 2010/04/06 ------------------------------>>>
        /// <summary>
        /// キャッシュ全削除処理
        /// </summary>
        public void DeleteAllFromCache()
        {
            _supplierDic = new Dictionary<int,Supplier>();
        }
        // -- ADD 2010/04/06 ------------------------------<<<
        # endregion

        # region [金額端数処理取得]
        /// <summary>
        /// 仕入金額端数処理区分取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="fracProcMoneyDiv">0:売上単価,1:売上金額,2:売上消費税</param>
        /// <returns>端数処理区分</returns>
        public int GetStockFractionProcCd( string enterpriseCode, int supplierCode, StockFracProcMoneyDiv fracProcMoneyDiv )
        {
            int fractionProcCd = 0;
            // -- ADD 2010/04/06 --------------------------->>>
            //パラメータが不正の場合は取得処理は行わない
            if (string.IsNullOrEmpty(enterpriseCode) || supplierCode == 0)
            {
                return fractionProcCd;
            }
            // -- ADD 2010/04/06 ---------------------------<<<
            
            Supplier supplier;

            // -- ADD 2010/04/06 --------------------------->>>
            //int status = Read(out supplier, enterpriseCode, supplierCode);
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            supplier = GetFromCache(supplierCode);
            if (supplier == null)
            {
                status = Read(out supplier, enterpriseCode, supplierCode);
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // -- ADD 2010/04/06 ---------------------------<<<

            if ( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (supplier != null) && (supplier.SupplierCd != 0) )
            {
                switch ( fracProcMoneyDiv )
                {
                    case StockFracProcMoneyDiv.UnPrcFrcProcCd:
                        fractionProcCd = supplier.StockUnPrcFrcProcCd;
                        break;
                    case StockFracProcMoneyDiv.MoneyFrcProcCd:
                        fractionProcCd = supplier.StockMoneyFrcProcCd;
                        break;
                    case StockFracProcMoneyDiv.CnsTaxFrcProcCd:
                        fractionProcCd = supplier.StockCnsTaxFrcProcCd;
                        break;
                }
            }
            return fractionProcCd;
        }
        # endregion

        # region [共通処理]
        /// <summary>
        /// 文字列→数値　変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text )
        {
            try
            {
                return Convert.ToInt32( text );
            }
            catch
            {
                return 0;
            }
        }
        # endregion

        // ADD 2009/05/27 ------>>>
        # region [親仕入先情報に基づく子仕入先情報の更新]
        /// <summary>
        /// 親仕入先情報に基づく子仕入先情報の更新
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        private void ReflectChildSupplierFromParent( ref SupplierWork child, SupplierWork parent )
        {
            child.PaymentTotalDay = parent.PaymentTotalDay;             // 支払締日
            child.PaymentMonthCode = parent.PaymentMonthCode;           // 支払月区分コード
            child.PaymentMonthName = parent.PaymentMonthName;           // 支払月区分名称
            child.PaymentDay = parent.PaymentDay;                       // 支払日
            child.PaymentCond = parent.PaymentCond;                     // 支払条件
            child.PaymentSight = parent.PaymentSight;                   // 支払サイト
            child.NTimeCalcStDate = parent.NTimeCalcStDate;             // 次回勘定開始日
            child.SuppCTaxLayRefCd = parent.SuppCTaxLayRefCd;           // 仕入先消費税転嫁方式参照区分
            child.SuppCTaxLayCd = parent.SuppCTaxLayCd;                 // 消費税転嫁方式
            child.StockUnPrcFrcProcCd = parent.StockUnPrcFrcProcCd;     // 仕入単価端数処理コード
            child.StockMoneyFrcProcCd = parent.StockMoneyFrcProcCd;     // 仕入金額端数処理コード
            child.StockCnsTaxFrcProcCd = parent.StockCnsTaxFrcProcCd;   // 仕入消費税端数処理コード
        }
        # endregion
        // ADD 2009/05/27 ------<<<
    }
}
