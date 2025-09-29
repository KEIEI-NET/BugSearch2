using System;

namespace Broadleaf.Application.Resources
{
	/// <summary>
	/// SuperFrontman Product定数定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : SuperFrontman Product 共通定数管理クラスです。</br>
	/// <br>Programmer : 96137　久保田　信一</br>
	/// <br>Date       : 2005.09.26</br>
	/// <br>Note	   : プロダクトコード、オプションコード等のプロダクト全体制御用のコンスタント情報を保持</br>
	/// <br></br>
    /// <br>Update Note: 2010/11/09 佐々木 超ＳＣＭ　接続先追加&オプションコード追加</br>
    /// <br>Update Note: 2011/07/13 22018 鈴木 正臣</br>
    /// <br>               リモート伝発、PCCUOE、PM7連携 オプションコード追加</br>
    /// <br>Update Note: 2011/08/01 22018 鈴木 正臣</br>
    /// <br>               PCCUOE 接続先追加</br>
    /// <br>Update Note: 2011/08/03 22018 鈴木 正臣</br>
    /// <br>               WebSync 接続先追加</br>
    /// <br>Update Note: 2012/10/09 FSI上北田　秀樹</br>
    /// <br>               仕入総括機能オプションコード追加</br>
    /// <br>Update Note: 2012/11/13 宮本 利明</br>
    /// <br>               売上伝票入力 日付制御オプション追加</br>
    /// <br>Update Note: 2012/12/10 堀田 剛生</br>
    /// <br>               山形部品完全個別オプション追加</br>
    /// <br>               得意先電子元帳 日付制御オプション追加</br>
    /// <br>               売上伝票入力・得意先電子元帳 売仕入同時入力制御オプション追加</br>
    /// <br>               売上伝票入力 仕入日付フォーカス制御オプション追加</br>
    /// <br>               売上伝票入力 原価修正制御オプション追加</br>
    /// <br>Update Note: 2013/05/24 長内 数馬</br>
    /// <br>               メニュー簡易起動オプション追加</br>
    /// <br>               藤木自動車オプション（個別）追加</br>
    /// <br>               タブレット基本オプション追加</br>
    /// <br>Update Note: 2013/08/27 鈴木 正臣</br>
    /// <br>               タブレット用WebSync接続情報追加</br>
    /// <br>Update Note: 2013/09/10 脇田 靖之</br>
    /// <br>               フタバオプション（個別）追加</br>
    /// <br>Update Note: 2013/09/13 脇田 靖之</br>
    /// <br>               フタバオプション（個別）追加</br>
    /// <br>Update Note: 2014/01/10 脇田 靖之</br>
    /// <br>               フタバオプション（個別）追加</br>
    /// <br>Update Note: 2014/01/23 長内 数馬</br>
    /// <br>               登戸オプション（個別）追加</br>
    /// <br>Update Note: 2014/03/28 河原林 一生</br>
    /// <br>               コンマン部品オプション（個別）追加</br>
    /// <br>Update Note: 2014/03/28 河原林 一生</br>
    /// <br>               信越自動車商会オプション（個別）追加</br>
    /// <br>Update Note: 2014/02/06 河原林 一生</br>
    /// <br>               前橋京和商会オプション（個別）追加</br>
    /// <br>Update Note: 2014/04/30 河原林 一生</br>
    /// <br>               東亜商会得意先電子元帳オプション（個別）追加</br>
    /// <br>Update Note: 2014/05/28 河原林 一生</br>
    /// <br>               カト―オプション（個別）追加</br>
    /// <br>Update Note: 2014/08/23 松本宏紀</br>
    /// <br>               レプリカ接続先 追加</br>
    /// <br>Update Note: 2015/05/11 30757 佐々木貴英</br>
    /// <br>               富士ジーワイ商事 スバルWebUOE制御オプション（個別）追加</br>
    /// <br>Update Note: 2015/05/14 清水 光春</br>
    /// <br>               モモセ部品㈱オプション（個別）追加</br>
    /// <br>Update Note: 2015/05/14 河原林 一生</br>
    /// <br>               森川部品オプション（個別）追加</br>
    /// <br>Update Note: 2015/06/25 河原林 一生</br>
    /// <br>               メイゴオプション（個別）追加</br>
    /// <br>Update Note: 2015/10/14 宮本 利明</br>
    /// <br>               ECサイト連携オプション(部品MAX)の追加</br>
    /// <br>Update Note: 2015/11/12 河原林 一生</br>
    /// <br>               コーエイオプション（個別）追加</br>
    /// <br>Update Note: 2016/02/04 西 毅</br>
    /// <br>               ECサイト連携オプション(部品MAX連携)の追加</br>
    /// <br>Update Note: 2016/02/03 河原林 一生</br>
    /// <br>               北進自動車部品オプション（個別）追加</br>
    /// <br>Update Note: 2016/2/25 櫻井 亮太</br>
    /// <br>               イケモトオプション(個別)の追加</br>
    /// <br>Update Note: 2016/05/27 河原林 一生</br>
    /// <br>               TBO対応オプションの追加</br>
    /// <br>Update Note: 2016/06/15 河原林 一生</br>
    /// <br>               SF側のイラスト選択サービスの追加(TBO対応で使用)</br>
    /// <br>Update Note: 2016/11/02 佐々木 貴英</br>
    /// <br>               神姫産業㈱ 操作履歴テキスト変換制御オプション(個別)追加</br>
    /// <br>Update Note: 2016/11/08 佐々木 貴英</br>
    /// <br>               ㈱コーエイ 売上伝票入力売価算出外部PG制御オプション（個別）追加</br>
    /// <br>Update Note: 2016/12/13 櫻井 亮太</br>
    /// <br>               福田部品 売上伝票入力仕入担当者制御(個別)追加</br>   
    /// <br>Update Note: 2016/12/26 菊地 将吾</br>
    /// <br>               山形部品 売上伝票入力 価格・売価変更ロック追加</br>   
    /// <br>Update Note: 2017/01/04 佐々木 貴英</br>
    /// <br>               水野商工㈱ 売上伝票入力第二売価算出PG制御オプション（個別）追加</br>
    /// <br>Update Note: 2017/08/01 脇田 靖之</br>
    /// <br>               ハンディターミナル対応オプションの追加</br>
    /// <br>Update Note: 2017/12/04 脇田 靖之</br>
    /// <br>               ＥＤＩ連携オプションの追加</br>
    /// <br>Update Note: 2018/10/04 金沢 貞義</br>
    /// <br>               Uploaderサービスの追加</br>
    /// <br>Update Note: 2019/01/07 太田 俊洋</br>
    /// <br>               Uploaderサービスの追加</br>
    /// <br>Update Note: 2019/12/08 佐々木 亘</br>
    /// <br>               売上データ連携オプションの追加</br>
    /// <br>Update Note: 2020/01/24 岸 傑</br>
    /// <br>               開発ツール監視オプションの追加</br>
    /// <br>Update Note: 2020/04/08 岸 傑</br>
    /// <br>               ハンディターミナル在庫登録オプションの追加</br>
    /// <br>Update Note: 2020/06/15 小原 卓也</br>
    /// <br>               セキュリティ対策オプションの追加</br>
    /// <br>Update Note: 2020/06/29 佐々木 亘</br>
    /// <br>               仕入データテキスト入力オプションの追加</br>
    /// <br>Update Note: 2020/11/24 小原 卓也</br>
    /// <br>               TSPオプションの追加</br>
    /// <br>Update Note: 2020/11/26 田村 顕成</br>
    /// <br>               請求書PDF一括出力オプションの追加</br>
    /// <br>Update Note: 2021/12/06 鈴木 創</br>
    /// <br>               11770181-00(先行配信マージ対応　3次リリース)　得意先電子元帳　引当済み伝票赤伝発行制御オプション改良対応</br>
    /// <br>Update Note: 2022/04/15 田村 顕成</br>
    /// <br>               11570183-00(電子帳簿連携対応)　電子帳簿連携オプションの追加</br>
    /// </remarks>
	public class ConstantManagement_SF_PRO
	{
		/// <summary>
		/// SuperFrontman Product定数定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.09.26</br>
		/// </remarks>
		public ConstantManagement_SF_PRO()
		{

		}
        
        public static string ProductCode
        {
            get {
                return _productCode;
            }
        }

 		/// <summary>
        /// Partsman プロダクトコード
		/// </summary>
        private const string _productCode = "Partsman";     //2008.04.21 chg sugimura

		#region AP/WEBサーバー接続定義
        /// <summary> ユーザーAPサーバー</summary>
		public const string ServerCode_UserAP		= "USER_AP" ;
        /// <summary> 提供APサーバー</summary>
		public const string ServerCode_OfferAP		= "OFFER_AP";
        /// <summary> (クライアント)ユーザーAPサーバー</summary>
        public const string ServerCode_Local_UserAP = "LOCAL_USER_AP";  //2007.03.12 add kubota
        /// <summary> (クライアント)提供APサーバー</summary>
        public const string ServerCode_Local_OfferAP = "LOCAL_OFFER_AP";//2007.03.12 add kubota
        /// <summary> (データセンター)提供APサーバー</summary>
        public const string ServerCode_Center_OfferAP = "CENTER_OFFER_AP";//2008.04.21 add sugi
        /// <summary> (データセンター)ユーザーAPサーバー</summary>
        public const string ServerCode_Center_UserAP = "CENTER_USER_AP";//2008.04.21 add sugi
        /// <summary> (集計サーバー)ユーザーAPサーバー</summary>
        public const string ServerCode_Summary_AP = "SUMMARY_AP";　　　//2008.09.09 add sugi
        /// <summary> 画像APサーバー</summary>
		public const string ServerCode_GraphicsAP	= "GRAPHICS_AP";
        /// <summary> 分析APサーバー</summary>
        public const string ServerCode_Analyze_AP = "ANALYZE_AP";       //2007.05.24 add kubota
		/// <summary> トップページWebサーバー</summary>
		public const string ServerCode_TopPageWeb	= "TOPPAGE_WEB";
		/// <summary>リサイクルパーツマンAPサーバー</summary>
		public const string ServerCode_RecycleAp	= "RECYCLE_AP";
		/// <summary>SCMAPサーバー</summary>
        public const string ServerCode_SCMAP = "SCM_AP"; //2009.06.03 add sugi
        /// <summary>相場APサーバー</summary>
        public const string ServerCode_MarketAP = "MARKET_AP"; //2010.07.30 add m.suzuki

        // 2010/11/09 Add >>>
        /// <summary>SCM問合せAPサーバーNS</summary>
        public const string ServerCode_SCM_ASK_AP_NS = "SCM_NS_ASK_AP";
        /// <summary>SCM問合せAPサーバーLG</summary>
        public const string ServerCode_SCM_OFFER_AP_LG = "SCM_LG_OFFER_AP";
        // 2010/11/09 Add <<<
        
        // --- ADD m.suzuki 2011/08/01 ---------->>>>>
        /// <summary>WebSyncサーバー</summary>
        public const string ServerCode_WEBSYNCAP = "WEBSYNC_AP";
        /// <summary>SCMAPサーバー</summary>
        public const string ServerCode_SCM_UserAP = "SCM_USER_AP";
        // --- ADD m.suzuki 2011/08/01 ----------<<<<<

        // --- ADD 松本宏紀 2011/08/23 ---------->>>>>
        /// <summary>PMデータ同期サーバー</summary>
        public const string ServerCode_SCM_PmKvmAP = "SCM_PMKVM_WEB";
        // --- ADD 松本宏紀 2014/08/23 ----------<<<<<
        
        // --- ADD 2015/10/14 T.Miyamoto ------------------------------>>>>>
        /// <summary>部品MAX</summary>
        public const string ServerCode_PARTSMAX = "EC_PARTSMAX_WEB";
        // --- ADD 2015/10/14 T.Miyamoto ------------------------------<<<<<
        // --- ADD 2016/02/04 T.Nishi ------------------------------>>>>>
        /// <summary>部品MAX連携</summary>
        public const string ServerCode_PARTSMAX_LG = "PARTSMAX_LGI_WEB";
        public const string ServerCode_PARTSMAX_EX = "PARTSMAX_EXH_WEB";
        public const string ServerCode_PARTSMAX_DE = "PARTSMAX_DER_WEB";
        // --- ADD 2016/02/04 T.Nishi ------------------------------<<<<<

        // --- ADD 2016/06/15 m.kawarabayashi ------------------------------>>>>>
        /// <summary>イラスト選択サービス(TBOで使用)</summary>
        public const string ServerCode_IllustSelectWeb = "ILLUST_WEB";
        // --- ADD 2016/06/15 m.kawarabayashi ------------------------------<<<<<
        #endregion

        // --- ADD 2018/10/04 S.Kanazawa ---------->>>>>
        /// <summary>Uploaderサービス</summary>
        public const string ServerCode_Uploader_Web = "UPLOADER_WEB";
        // --- ADD 2018/10/04 S.Kanazawa ----------<<<<<

		#region DB/Dir/Webサーバー接続/参照/設定定義
        /// <summary>ユーザーDBサーバーDB</summary>
		public const string IndexCode_UserDB		= "USER_DB" ;
        /// <summary>提供DBサーバーDB</summary>
		public const string IndexCode_OfferDB		= "OFFER_DB";
        /// <summary>(データセンター)ユーザーDBサーバーDB</summary>
        public const string IndexCode_Center_UserDB = "CENTER_USER_DB";   //2008.04.21 add sugi
        /// <summary>(データセンター)提供DBサーバーDB</summary>
        public const string IndexCode_Center_OfferDB = "CENTER_OFFER_DB"; //2008.04.21 add sugi
        /// <summary>(クライアント)ユーザーDBサーバーDB</summary>
        public const string IndexCode_Local_UserDB = "LOCAL_USER_DB";   //2007.03.13 add saitoh
        /// <summary>(クライアント)提供DBサーバーDB</summary>
        public const string IndexCode_Local_OfferDB = "LOCAL_OFFER_DB"; //2007.03.13 add saitoh
        /// <summary>(データセンター)ユーザーDBサーバーDB</summary>
        public const string IndexCode_Summary_DB = "SUMMARY_DB";   //2008.09.09 add sugi
        /// <summary>提供DBサーバーDIR</summary>
		public const string IndexCode_OfferDir	= "OFFER_DIR";
		/// <summary>画像Path</summary>
		public const string IndexCode_GraphicsDir	= "GRAPHICS_DIR";
        /// <summary>分析DBサーバー</summary>
        public const string IndexCode_Analyze_DB = "ANALYZE_DB";        //2007.05.24 add kubochi
		/// <summary>Webパラメータ</summary>
		public const string IndexCode_WebPara		= "WEB_PARA";
        /// <summary>Webパラメータ</summary>
        public const string IndexCode_Infomation = "INFORMATION_WEB";      //2008.11.08 add sugi
        /// <summary>リサイクルパーツマンWEBサービスパス</summary>
		public const string IndexCode_Recycle_WebPath	= "RECYCLE_WEBPATH";
        /// <summary>SCMWEBサービスパス</summary>
        public const string IndexCode_SCM_WebPath = "SCM_WEBPATH"; //2009.06.03 add sugi
        /// <summary>相場WEBサービスパス</summary>
        public const string IndexCode_Soba_WebPath = "SOBA_WEBPATH"; //2010.07.30 add m.suzuki

        // 2010/11/09 Add >>>
        /// <summary>SCM提供サーバーDB</summary>
        public const string IndexCode_SCM_NS_OFFER_DB = "SCM_NS_OFFER_DB";
        /// <summary>SCM連携DB</summary>
        public const string IndexCode_SCM_NS_DB = "SCM_NS_DB";
        /// <summary>SCM提供サーバーDB</summary>
        public const string IndexCode_SCM_LG_OFFER_DB = "SCM_LG_OFFER_DB";
        /// <summary>SCM連携DB</summary>
        public const string IndexCode_SCM_LG_DB = "SCM_LG_DB";
        // 2010/11/09 Add <<<

        // --- ADD m.suzuki 2011/08/01 ---------->>>>>
        /// <summary>SCM用ユーザーDBサーバーDB</summary>
        public const string IndexCode_SCM_UserDB = "SCM_USER_DB";
        // --- ADD m.suzuki 2011/08/01 ----------<<<<<

        // --- ADD m.suzuki 2011/08/03 ---------->>>>>
        /// <summary>WebSyncサービスパス</summary>
        public const string IndexCode_WebSync_WebPath = "WEBSYNC_WEBPATH";
        // --- ADD m.suzuki 2011/08/03 ----------<<<<<

        //--- ADD 2013/08/27 m.suzuki --->>>>>
        /// <summary>WEBSYNCサービスパス(TAB)</summary>
        public const string IndexCode_WebSync_Client_WebPath = "WSYNC_CL_WEBPATH";
        //--- ADD 2013/08/27 m.suzuki ---<<<<<

        // --- ADD 松本宏紀 2011/08/23 ---------->>>>>
        /// <summary>PMデータ同期サーバー</summary>
        public const string IndexCode_SCM_PmKvm_WebPath = "SCM_PMKVM_WEBPAT";
        // --- ADD 松本宏紀 2014/08/23 ----------<<<<<
        // --- ADD 2015/10/14 T.Miyamoto ------------------------------>>>>>
        /// <summary>部品MAX</summary>
        public const string IndexCode_PARTSMAX_WebPath = "EC_PARTSMAX_WEBP";
        // --- ADD 2015/10/14 T.Miyamoto ------------------------------<<<<<

        // --- ADD 2016/02/04 T.Nishi ------------------------------>>>>>
        /// <summary>部品MAX連携</summary>
        public const string IndexCode_PARTSMAX_LG_WebPath = "PARTSMAX_LGI_WEB";
        public const string IndexCode_PARTSMAX_EX_WebPath = "PARTSMAX_EXH_WEB";
        public const string IndexCode_PARTSMAX_DE_WebPath = "PARTSMAX_DER_WEB";
        // --- ADD 2016/02/04 T.Nishi ------------------------------<<<<<
        #endregion


		#region ソフトウェアコード（システムレベル）
		/// <summary>
		/// 整備ソフトウェアコード
		/// </summary>
		/// <br>Note       : </br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.09.26</br>
		public const string SoftwareCode_PAC_SF	= "PAC01000";
		/// <summary>
		/// 車販ソフトウェアコード
		/// </summary>
		/// <br>Note       : </br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.09.26</br>
		public const string SoftwareCode_PAC_CS	= "PAC03000";
		/// <summary>
		/// 鈑金ソフトウェアコード
		/// </summary>
		/// <br>Note       : </br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.09.26</br>
		public const string SoftwareCode_PAC_BK	= "PAC05000";
        /// <summary>
        /// 携帯ソフトウェアコード
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2005.09.26</br>
        public const string SoftwareCode_PAC_KT = "PAC07000";

        /// <summary>
        /// 旅行ソフトウェアコード
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2005.09.26</br>
        public const string SoftwareCode_PAC_TR = "PAC08000";

        /// <summary>
        /// パーツマンソフトウェアコード
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 20402　杉村 利彦</br>
        /// <br>Date       : 2007.08.09</br>
        public const string SoftwareCode_PAC_PM = "PAC09000";

        /// <summary>
        /// 機工ソフトウェアコード
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 20402　杉村 利彦</br>
        /// <br>Date       : 2007.08.09</br>
        public const string SoftwareCode_PAC_KM = "PAC11000";

		#endregion


		#region ソフトウェアコード（サブシステムレベル）
		/// <summary>
		/// Ｋタイプソフトウェアコード
		/// </summary>
		/// <br>Note       : </br>
		/// <br>Programmer : 20402　杉村 利彦</br>
		/// <br>Date       : 2008.10.11</br>
        /// <br>Note       : Ｋタイプ</br>
        public const string SoftwareCode_SUB_K_Type = "SUB01000";//2009.02.12 sugi chg
        /// <summary>
        /// Ｍタイプオプションソフトウェアコード
        /// </summary>
        /// <br>Programmer : 20402　杉村 利彦</br>
        /// <br>Date       : 2008.10.11</br>
        /// <br>Note       : Ｍタイプ</br>
        public const string SoftwareCode_SUB_M_Type = "SUB02000";//2009.02.12 sugi chg
        /// <summary>
        /// Ｊタイプソフトウェアコード
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 20402　杉村 利彦</br>
        /// <br>Date       : 2008.10.11</br>
        /// <br>Note       : Ｊタイプ</br>
        public const string SoftwareCode_SUB_J_Type = "SUB03000";//2009.02.12 sugi add

        
        #endregion


		#region ソフトウェアコード（オプションレベル）

		#region ソフトウェアコード（共通オプション）
        /// <summary>
        /// 共通オプション-販売管理基本オプション
        /// </summary>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2009.2.12</br>
        public const string SoftwareCode_OPT_CMN_BasicSalesMng = "OPT-CMN0050";//2009.02.12 sugi add
        /// <summary>
		/// 共通オプション-拠点オプション
		/// </summary>
		/// <br>Note       : 2005.11.01 デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.10.15</br>
		public const string SoftwareCode_OPT_CMN_SECTION		= "OPT-CMN0100";
        /// <summary>
        /// 共通オプション-本社管理オプション
        /// </summary>
        /// <br>Note       : 2009.3 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2009.2.12</br>
        public const string SoftwareCode_OPT_CMN_EnterpriseMng = "OPT-CMN5000";//2009.02.12 sugi add

		/// <summary>
		/// 共通オプション-売掛金消込オプション(Accounts receivable cancellation)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
		//public const string SoftwareCode_OPT_CMN_AcntRcveCncl	= "OPT-CMN0110";
		/// <summary>
		/// 共通オプション-領収書発行オプション(Receipt issue)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
		//public const string SoftwareCode_OPT_CMN_ReceiptIssue	= "OPT-CMN0120";
		/// <summary>
		/// 共通オプション-諸費用別入金オプション(Separate payment)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.02.21</br>
		//public const string SoftwareCode_OPT_CMN_SeparatePayment= "OPT-CMN0140";
        /// <summary>
        /// 共通オプション-仕入支払管理オプション
        /// </summary>
        /// <br>Note       : 2006.09.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.06.07</br>
        public const string SoftwareCode_OPT_CMN_StockingPayment = "OPT-CMN0200";
        /// <summary>
        /// 共通オプション-在庫管理オプション
        /// </summary>
        /// <br>Note       : 2006.09.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.06.07</br>
        public const string SoftwareCode_OPT_CMN_StockControl = "OPT-CMN0210";
        /// <summary>
        /// 共通オプション-棚管理オプション
        /// </summary>
        /// <br>Note       : 2006.09.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.06.07</br>
        //public const string SoftwareCode_OPT_CMN_ShelfControl = "OPT-CMN0220";
        /// <summary>
        /// 共通オプション-テキスト出力オプション
        /// </summary>
        /// <br>Note       : 2006.06.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.05.19</br>
        public const string SoftwareCode_OPT_CMN_TextOutput = "OPT-CMN0320";
        /// <summary>
        /// 共通オプション-大型提供データ
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.08.23</br>
        public const string SoftwareCode_OPT_CMN_BigCarOfferData = "OPT-CMN0310";
        /// <summary>
		/// 共通オプション-お正月パックオプション
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.02.21</br>
        //public const string SoftwareCode_OPT_CMN_NewYearPack = "OPT-CMN0330";
		/// <summary>
		/// 共通オプション-６ヵ月点検オプション
		/// </summary>
		/// <br>Note       : 2005.11.01 デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2005.10.15</br>
		//public const string SoftwareCode_OPT_CMN_6CarInspect	= "OPT-CMN0370";
		/// <summary>
		/// 共通オプション-バーコード入力オプション
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.12</br>
		//public const string SoftwareCode_OPT_CMN_BarCodeInput	= "OPT-CMN0380";
		/// <summary>
		/// 共通オプション-バーコード入力（TSP）オプション
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.03.02</br>
		//public const string SoftwareCode_OPT_CMN_BarCodeTspInput= "OPT-CMN0390";
        /// <summary>
        /// 共通オプション-ミレアパートナーズネットオプション
        /// </summary>
        /// <br>Note       : 2006.05.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.05.02</br>
        //public const string SoftwareCode_OPT_CMN_MireaPartnerzNet = "OPT-CMN0410";
        /// <summary>
        /// 共通オプション-J-NAVIオプション
        /// </summary>
        /// <br>Note       : 2006.05.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.05.02</br>
        //public const string SoftwareCode_OPT_CMN_J_NAVI = "OPT-CMN0420";
        /// <summary>
        /// 共通オプション-J1ネットオプション
        /// </summary>
        /// <br>Note       : 2006.05.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.05.02</br>
        //public const string SoftwareCode_OPT_CMN_J1 = "OPT-CMN0430";
        /// <summary>
		/// 共通オプション-e-JIBAIオプション
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
		//public const string SoftwareCode_OPT_CMN_E_JIBAI = "OPT-CMN0450";
        /// <summary>
        /// 共通オプション-工程管理オプション
        /// </summary>
        /// <br>Note       : 2006.06.?? デリバリ</br>
        /// <br>Programmer : 96137　久保田　信一</br>
        /// <br>Date       : 2006.05.31</br>
        //public const string SoftwareCode_OPT_CMN_ProcessManagement = "OPT-CMN0500";

        /// <summary>
        /// 共通オプション-基本提供データオプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.06.18</br>
        public const string SoftwareCode_OPT_CMN_BasicOfferData = "OPT-CMN0600";　//2008.06.18 sugi add

        /// <summary>
        /// 共通オプション-外装提供データオプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.06.18</br>
        public const string SoftwareCode_OPT_CMN_OutsideOfferData = "OPT-CMN0620";　//2008.06.18 sugi add

        /// <summary>
        /// 共通オプション-セキュリティ管理オプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.06.18</br>
        public const string SoftwareCode_OPT_CMN_SecuretyMng = "OPT-CMN0700";　//2008.11.08 sugi add

        /// <summary>
		/// 共通オプション-売上／入金管理オプション(Sales/payment management)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
		public const string SoftwareCode_OPT_CMN_SlsPymntMng	= "OPT-CMN2000";

        /// <summary>
        /// 共通オプション-締管理オプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.10.22</br>
        //public const string SoftwareCode_OPT_CMN_AddUpMng = "OPT-CMN2050";

		/// <summary>
		/// 共通オプション-請求管理オプション(Claim management)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
        //public const string SoftwareCode_OPT_CMN_ClaimMng = "OPT-CMN2100";

        /// <summary>
        /// 共通オプション-精算管理オプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.06.18</br>
        //public const string SoftwareCode_OPT_CMN_ACalcMng = "OPT-CMN2150";　//2008.06.18 sugi add

		/// <summary>
		/// 共通オプション-売掛管理オプション(Credit sales management)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
		public const string SoftwareCode_OPT_CMN_CrdtSlsMng = "OPT-CMN2200";

        /// <summary>
        /// 共通オプション-買掛管理オプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.06.18</br>
        //public const string SoftwareCode_OPT_CMN_AccPayMng = "OPT-CMN2250";　//2008.06.18 sugi add
        
        /// <summary>
		/// 共通オプション-販売分析管理オプション(Sales analysis management)
		/// </summary>
		/// <br>Note       : 2006.03.?? デリバリ</br>
		/// <br>Programmer : 96137　久保田　信一</br>
		/// <br>Date       : 2006.01.16</br>
		public const string SoftwareCode_OPT_CMN_SlsAnlysMng	= "OPT-CMN2300";

        /// <summary>
		/// 共通オプション-販売実績管理オプション
		/// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.10.22</br>
        public const string SoftwareCode_OPT_CMN_SlsResultsMng　="OPT-CMN2350";

        /// <summary>
		/// 共通オプション-統計オプションオプション
		/// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.10.22</br>
        /// <br>Note       : 経営ダッシュボード</br>
        public const string SoftwareCode_OPT_CMN_Statistical　="OPT-CMN2400";

        /// <summary>
        /// 共通オプション-手形管理オプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.06.18</br>
        public const string SoftwareCode_OPT_CMN_DraftMng = "OPT-CMN2500";　//2008.06.18 sugi add

        /// <summary>
        /// 共通オプション-バックアップサービスオプション
        /// </summary>
        /// <br>Note       : 2009.2 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2009.02.12</br>
        public const string SoftwareCode_OPT_CMN_DataBackup = "OPT-CMN8000";//2009.02.12 sugi add

        /// <summary>
        /// 共通オプション-リモートメンテナンスオプション
        /// </summary>
        /// <br>Note       : 2008.12 デリバリ</br>
        /// <br>Programmer : 20402　杉村　利彦</br>
        /// <br>Date       : 2008.09.29</br>
        public const string SoftwareCode_OPT_CMN_RemoteMaintenance = "OPT-CMN9000";

        // 2010/11/09 Add >>>
        /// <summary>
        /// 共通オプション-SCM部品問合せオプション
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 99033 iwamoto</br>
        /// <br>Date       : 20101018</br>
        public const string SoftwareCode_OPT_CMN_ScmPartsInq = "OPT-CMN1300";
        // 2010/11/09 Add <<<

		// ADD 2012/10/09 >>>
        /// <summary>
        /// 共通オプション-仕入総括機能オプション
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 20121009</br>
        public const string SoftwareCode_OPT_CMN_SuppSumFunc = "OPT-CPM0020";
        // ADD 2012/10/09 <<<

        // ADD T.Miyamoto 2012/11/13 ------------------------------>>>>>
        /// <summary>
        /// 共通オプション-売上伝票入力 日付制御オプション
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 20121108</br>
        public const string SoftwareCode_OPT_CMN_SalesDateControl = "OPT-CPM0030";
        // ADD T.Miyamoto 2012/11/13 ------------------------------<<<<<

        // ADD 2012/12/10 ------------------------------>>>>>
        /// <summary>
        /// 共通オプション-山形部品完全個別オプション
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 堀田 剛生</br>
        /// <br>Date       : 20121210</br>
        public const string SoftwareCode_OPT_CMN_YamagataCustomControl = "OPT-CPM0010";

        /// <summary>
        /// 共通オプション-得意先電子元帳 日付制御オプション追加
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 堀田 剛生</br>
        /// <br>Date       : 20121210</br>
        public const string SoftwareCode_OPT_CMN_SalesDateDControl = "OPT-CPM0040";

        /// <summary>
        /// 共通オプション-売上伝票入力・得意先電子元帳 売仕入同時入力制御オプション追加
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 堀田 剛生</br>
        /// <br>Date       : 20121210</br>
        public const string SoftwareCode_OPT_CMN_StockEntControl = "OPT-CPM0050";

        /// <summary>
        /// 共通オプション-売上伝票入力 仕入日付フォーカス制御オプション追加
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 堀田 剛生</br>
        /// <br>Date       : 20121210</br>
        public const string SoftwareCode_OPT_CMN_StockDateControl = "OPT-CPM0060";

        /// <summary>
        /// 共通オプション-売上伝票入力 原価修正制御オプション追加
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 堀田 剛生</br>
        /// <br>Date       : 20121210</br>
        public const string SoftwareCode_OPT_CMN_SalesCostControl = "OPT-CPM0070";
        // ADD 2012/12/10 ------------------------------<<<<<

        // ADD 2013/05/24 ------------------------------>>>>>
        /// <summary>
        /// 共通オプション-タブレット基本オプション
        /// </summary>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2013/05/24</br>
        public const string SoftwareCode_OPT_CMN_BasicTablet = "OPT-CMN3000";
        // ADD 2013/05/24 ------------------------------<<<<<

        #endregion

       #endregion

       #region ソフトウェアコード（PMオプション）　//2008.06.18 sugi add

        /// <summary>
        /// ＵＯＥオプション
		/// <br>Note : まず、このオプションをチェック。その後各メーカーのチェックを行う</br>
        /// </summary>
        public const string SoftwareCode_OPT_PM_UOE = "OPT-PM00100";
        /// <summary>UOE:トヨタ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Toyota = "OPT-PM00101";
        /// <summary>UOE:ニッサン</summary>
        public const string SoftwareCode_OPT_PM_UOE_Nissan = "OPT-PM00102";
        /// <summary>UOE:ミツビシ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Mitsubishi = "OPT-PM00103";
        /// <summary>UOE:マツダ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Mazda = "OPT-PM00104";
        /// <summary>UOE:ホンダ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Honda = "OPT-PM00105";
        /// <summary>UOE:イスズ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Isuzu = "OPT-PM00106";
        /// <summary>UOE:ダイハツ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Daihatsu = "OPT-PM00107";
        /// <summary>UOE:スバル</summary>
        public const string SoftwareCode_OPT_PM_UOE_Subaru = "OPT-PM00108";
        /// <summary>UOE:スズキ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Suzuki = "OPT-PM00109";
        /// <summary>UOE:ヒノ</summary>
        public const string SoftwareCode_OPT_PM_UOE_Hino = "OPT-PM00110";
        /// <summary>UOE:ニッサンUD</summary>
        public const string SoftwareCode_OPT_PM_UOE_NissanUD = "OPT-PM00111";
        /// <summary>UOE:ミツビシフソウ</summary>
        public const string SoftwareCode_OPT_PM_UOE_MitsubishiFuso = "OPT-PM00112";
        /// <summary>UOE:イスズ（大型）</summary>
        public const string SoftwareCode_OPT_PM_UOE_IsuzuBigCar = "OPT-PM00113";

        /// <summary>
        /// 優良ネットオプション
   		/// <br>Note : まず、このオプションをチェック。その後各メーカーのチェックを行う</br>
        /// </summary>
        public const string SoftwareCode_OPT_PM_PrimeNet = "OPT-PM00150";
        /// <summary>優良ネット：大和ネット</summary>
        public const string SoftwareCode_OPT_PM_DAIWANET = "OPT-PM00151";
        /// <summary>優良ネット：エンパイヤネット</summary>
        public const string SoftwareCode_OPT_PM_EMCNET = "OPT-PM00152";
        /// <summary>優良ネット：明治ネット</summary>
        public const string SoftwareCode_OPT_PM_MEIJINET = "OPT-PM00153";
        /// <summary>優良ネット：みづほネット</summary>
        public const string SoftwareCode_OPT_PM_MIDUHONET = "OPT-PM00154";
        /// <summary>優良ネット：ニッパンネット</summary>
        public const string SoftwareCode_OPT_PM_NPTNET = "OPT-PM00155";
        /// <summary>優良ネット：日新ネット</summary>
        public const string SoftwareCode_OPT_PM_NSNNET = "OPT-PM00156";
        /// <summary>優良ネット：新生ネット</summary>
        public const string SoftwareCode_OPT_PM_SNSINET = "OPT-PM00157";
        /// <summary>優良ネット：SPKネット</summary>
        public const string SoftwareCode_OPT_PM_SPKNET = "OPT-PM00158";
        /// <summary>優良ネット：昭和自工ネット</summary>
        public const string SoftwareCode_OPT_PM_SYOUWANET = "OPT-PM00159";
        /// <summary>優良ネット：昭和部品ネット</summary>
        public const string SoftwareCode_OPT_PM_SYOUBUNET = "OPT-PM00160";
        /// <summary>優良ネット：東海ネット</summary>
        public const string SoftwareCode_OPT_PM_TOKAINET = "OPT-PM00161";
        /// <summary>優良ネット：大洋ネット</summary>
        public const string SoftwareCode_OPT_PM_TAIYONET = "OPT-PM00162";
        /// <summary>優良ネット：タカラネット</summary>
        public const string SoftwareCode_OPT_PM_TKRNET = "OPT-PM00163";
        /// <summary>優良ネット：辰巳屋ネット</summary>
        public const string SoftwareCode_OPT_PM_TMYNET = "OPT-PM00164";
        /// <summary>優良ネット：ヤマトネット</summary>
        public const string SoftwareCode_OPT_PM_YMTNET = "OPT-PM00165";
        /// <summary>優良ネット：和興フィルタネット</summary>
        public const string SoftwareCode_OPT_PM_WAKOFILNET = "OPT-PM00166";


        /// <summary>
        /// SCMオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_SCM = "OPT-PM00200";
        /// <summary>
        /// PCCオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_PCC = "OPT-PM00250";
        /// <summary>
        /// 車輌管理オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_CarMng = "OPT-PM00300";
        /// <summary>
        /// 自由検索オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_FreeSearch = "OPT-PM00500";
        /// <summary>
        /// リサイクル連動オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_RCLink = "OPT-PM00600";
        /// <summary>
        /// 二輪検索オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_BikeSearch = "OPT-PM00700";
        /// <summary>
        /// イラストオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_Illustration = "OPT-PM00800";
        /// <summary>
        /// タクティ他社結合オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_TactiSearch = "OPT-PM01000";

        /// <summary>
        /// 拠点管理オプション
        /// </summary>
        /// <summary>拠点間データ送信オプションセット</summary>
        public const string SoftwareCode_OPT_PM_SectMng = "OPT-PM00400";
        /// <summary>拠点間データ送信オプション</summary>
        public const string SoftwareCode_OPT_PM_SectDataSend = "OPT-PM00410";
        /// <summary>拠点間在庫移動オプション</summary>
        public const string SoftwareCode_OPT_PM_SectStockMove = "OPT-PM00420";
        /// <summary>拠点間UOEオプション</summary>
        public const string SoftwareCode_OPT_PM_SectUOE = "OPT-PM00430";
        /// <summary>拠点間伝票発行オプション</summary>
        public const string SoftwareCode_OPT_PM_SectPrtSlip = "OPT-PM00440";

        // --- ADD m.suzuki 2010/04/06 ---------->>>>>
        /// <summary>
        /// Felicaログインオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_Felica = "OPT-PM01200";
        // --- ADD m.suzuki 2010/04/06 ----------<<<<<

        // --- ADD sasaki 2010/05/19 ---------->>>>>
        /// <summary>
        /// ＳＣＭ自動回答オプション
        /// </summary>
        // --- UPD m.suzuki 2010/08/05 ---------->>>>>
        //public const string SoftwareCode_OPT_PM_SCMAutoAnswer = "OPT-PM00201";
        public const string SoftwareCode_OPT_PM_SCMAutoAnswer = "OPT-PM00210";
        // --- UPD m.suzuki 2010/08/05 ----------<<<<<

        /// <summary>
        /// 相場情報オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_MarketInfo = "OPT-PM01300";
        // --- ADD sasaki 2010/05/19 ----------<<<<<

        // --- ADD m.suzuki 2010/06/26 ---------->>>>>
        /// <summary>
        /// ＱＲコード携帯メールオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_QRMail = "OPT-PM01400";
        // --- ADD m.suzuki 2010/06/26 ----------<<<<<

        // --- ADD m.suzuki 2011/07/13 ---------->>>>>
        /// <summary>
        /// リモート伝発オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_RemoteSlipPrt = "OPT-PM01700";
        /// <summary>
        /// PCCUOEオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_PCCUOE = "OPT-PM01800";
        /// <summary>
        /// PM7連携オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_PM7Link = "OPT-PM01900";
        // --- ADD m.suzuki 2011/07/13 ----------<<<<<

        // --- ADD 2013/05/24 -------- ---------->>>>>
        /// <summary>
        /// メニュー簡易起動オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_MenuSimpleStart = "OPT-PM02010";
        // --- ADD 2013/05/24 -------- ----------<<<<<
        
        // --- ADD 2017/08/01 Y.Wakita ---------->>>>>
        /// <summary>
        /// ハンディーターミナルOP検品管理（販売業務）基本
        /// </summary>
        public const string SoftwareCode_OPT_PM_HND_InspMng_Sales = "OPT-PM02400";
        /// <summary>
        /// ハンディーターミナルOP検品管理（仕入業務プラス）
        /// </summary>
        public const string SoftwareCode_OPT_PM_HND_InspMng_Stock = "OPT-PM02410";
        /// <summary>
        /// ハンディーターミナルOP検品管理（社内業務プラス）
        /// </summary>
        public const string SoftwareCode_OPT_PM_HND_InspMng_Company = "OPT-PM02420";
        /// <summary>
        /// ハンディーターミナルOPバーコード提供OP
        /// </summary>
        public const string SoftwareCode_OPT_PM_HND_BarcodeOffer = "OPT-PM02430";
        // --- ADD 2017/08/01 Y.Wakita ----------<<<<<
        // --- ADD 2020/04/08 M.Kishi ---------->>>>>
        /// <summary>
        /// ハンディーターミナルOP在庫登録OP
        /// </summary>
        public const string SoftwareCode_OPT_PM_HND_InsStock = "OPT-PM02440";
        // --- ADD 2020/04/08 M.Kishi ---------->>>>>
        
        // --- ADD 2017/12/04 Y.Wakita ---------->>>>>
        /// <summary>
        /// ＥＤＩ連携
        /// </summary>
        public const string SoftwareCode_OPT_PM_EDILink = "OPT-PM02500";
        // --- ADD 2017/12/04 Y.Wakita ----------<<<<<

        // --- ADD 2019/12/08 ---------->>>>>
        /// <summary>
        /// 売上データ連携
        /// </summary>
        public const string SoftwareCode_OPT_PM_SalesCprt = "OPT-PM02600";
        // --- ADD 2019/12/08 ----------<<<<<

        // --- ADD 2020/01/24 M.Kishi -------------------------->>>>>
        /// <summary>
        /// 開発ツール監視オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_ToolMonitoring = "OPT-PM02700";
        // --- ADD 2020/01/24 M.Kishi --------------------------<<<<<

        // --- ADD 2020/06/15 T.Obara ---------->>>>>
        /// <summary>
        /// セキュリティ対策オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_SecurityMeasures = "OPT-PM03000";
        // --- ADD 2020/06/15 T.Obara ----------<<<<<

        // --- ADD 2020/06/29 ---------->>>>>
        /// <summary>
        /// 仕入データテキスト入力オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_StockTextInPut = "OPT-PM03010";
        // --- ADD 2020/06/29 ----------<<<<<

        // --- ADD 2020/11/24 T.Obara ---------->>>>>
        /// <summary>
        /// TSPオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_Tsp = "OPT-PM03100";
        // --- ADD 2020/11/24 T.Obara ----------<<<<<

        // --- ADD 2020/11/26 A.Tamura ---------->>>>>
        /// <summary>
        /// 請求書PDF一括出力オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_PdfInvoiceBulkOutput = "OPT-PM03020";
        // --- ADD 2020/11/26 A.Tamura ----------<<<<<

        // --- ADD 2021/12/06 S.Suzuki ---------->>>>>
        /// <summary>
        /// 引当済み伝票赤伝発行制御オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_CtlIssuingAkaden = "OPT-PM03200";
        // --- ADD 2021/12/06 S.Suzuki ----------<<<<<

        // --- ADD 2022/04/15 A.Tamura ---------->>>>>
        /// <summary>
        /// 電子帳簿連携オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_EBooks = "OPT-PM03300";
        // --- ADD 2022/04/15 A.Tamura ----------<<<<<

        // --- ADD 2013/05/24 -------- ---------->>>>>
        /// <summary>
        /// 藤木自動車オプション（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FujikiCustom = "OPT-CPM0080";
        // --- ADD 2013/05/24 -------- ----------<<<<<

        // --- ADD 2013/09/10 Y.Wakita ---------->>>>>
        /// <summary>
        /// BLP参照倉庫追加オプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_BLPRefWarehouse = "OPT-PM00230";
        /// <summary>
        /// フタバ伝票印刷制御オプション（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FutabaSlipPrtCtl = "OPT-CPM0090";
        /// <summary>
        /// フタバ倉庫引当てオプション（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FutabaWarehAlloc = "OPT-CPM0100";
        /// <summary>
        /// フタバUOEオプション（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FutabaUOECtl = "OPT-CPM0110";
        // --- ADD 2013/09/10 Y.Wakita ----------<<<<<
        // --- ADD 2013/09/13 Y.Wakita ---------->>>>>
        /// <summary>
        /// フタバ出力済伝票制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FutabaOutSlipCtl = "OPT-CPM0120";
        // --- ADD 2013/09/13 Y.Wakita ----------<<<<<
        // --- ADD 2014/01/10 Y.Wakita ---------->>>>>
        /// <summary>
        /// フタバ拠点間発注処理制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FutabaSecOrderCtl = "OPT-CPM0130";
        // --- ADD 2014/01/10 Y.Wakita ----------<<<<<
        // --- ADD 2014/01/23 ------------------->>>>>
        /// <summary>
        /// 登戸個別オプション(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_NobutoCustom = "OPT-CPM0140";
        // --- ADD 2014/01/23 -------------------<<<<<
        // --- ADD 2014/03/28 m.kawarabayashi ---------->>>>>
        /// <summary>
        /// コンマン部品商品マスタ表示制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_KonmanGoodsMstCtl = "OPT-CPM0170";
        // --- ADD 2014/03/28 m.kawarabayashi ----------<<<<<
        // --- ADD 2014/03/28 m.kawarabayashi ---------->>>>>
        /// <summary>
        /// 信越自動車商会棚卸表制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl = "OPT-CPM0180";
        // --- ADD 2014/03/28 m.kawarabayashi ----------<<<<<
        // --- ADD 2014/03/28 m.kawarabayashi ---------->>>>>
        /// <summary>
        /// 前橋京和得意先ガイド制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl = "OPT-CPM0150";
        /// <summary>
        /// 前橋京和掛率更新日表示制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl = "OPT-CPM0160";
        // --- ADD 2014/03/28 m.kawarabayashi ----------<<<<<
        // --- ADD 2014/04/30 ------------------->>>>>
        /// <summary>
        /// 東亜商会得意先電子元帳オプション(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_ToaCustom = "OPT-CPM0190";
        // --- ADD 2014/04/30 -------------------<<<<<
        // --- ADD 2014/05/28 ------------------->>>>>
        /// <summary>
        /// カト―入金伝票入力オプション(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_KatoCustom = "OPT-CPM0200";
        // --- ADD 2014/05/28 -------------------<<<<<
        // --- ADD 2015/05/11 30757 佐々木貴英------------------->>>>>
        /// <summary>
        /// 富士ジーワイ商事 スバルWebUOE制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FujiGYSubaruWebUoeCtl = "OPT-CPM0210";
        // --- ADD 2015/05/11 30757 佐々木貴英 -------------------<<<<<
        // --- ADD 2015/05/14 ------------------->>>>>
        /// <summary>
        /// モモセ部品㈱得意先電子元帳オプション(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_MomoseCustom = "OPT-CPM0220";
        // --- ADD 2015/05/14 -------------------<<<<<
        // --- ADD 2015/05/14 m.kawarabayashi ------------------->>>>>
        /// <summary>
        /// 森川部品売上伝票入力オプション(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_MorikawaCustom = "OPT-CPM0230";
        // --- ADD 2015/05/14 m.kawarabayashi -------------------<<<<<
        // --- ADD 2015/06/25 m.kawarabayashi ------------------->>>>>
        /// <summary>
        /// メイゴWebUOE発注データ取込制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_MeigoWebUOECtrl = "OPT-CPM0240";
        /// <summary>
        /// メイゴ得意先電子元帳項目制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_MeigoLedgerCustom = "OPT-CPM0250";
        // --- ADD 2015/06/25 m.kawarabayashi -------------------<<<<<
        // --- ADD 2015/10/14 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// ECサイト連携オプション(部品MAX)
        /// </summary>
        public const string SoftwareCode_OPT_PM_PartsMax = "OPT-PM02200";
        // --- ADD 2015/10/14 T.Miyamoto ------------------------------<<<<<
        // --- ADD 2015/11/12 m.kawarabayashi ------------------->>>>>
        /// <summary>
        /// コーエイ得意先・在庫マスタインポート制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_KoeiMstImportCtrl = "OPT-CPM0270";
        // --- ADD 2015/11/12 m.kawarabayashi -------------------<<<<<
        // --- ADD 2016/02/03 m.kawarabayashi ------------------->>>>>
        /// <summary>
        /// 北進自動車部品オプション(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_HokushinCtrl = "OPT-CPM0271";
        // --- ADD 2016/02/03 m.kawarabayashi -------------------<<<<<
        // --- ADD 2016/02/25 r.sakurai ------------------->>>>>
        /// <summary>
        /// イケモト得意先電子元帳項目制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_IkemotoCustom = "OPT-CPM0280";
        // --- ADD 2016/02/25 r.sakurai -------------------<<<<<
        // --- ADD 2016/05/27 m.kawarabayashi ------------------------------>>>>>
        /// <summary>
        /// TBOオプション
        /// </summary>
        public const string SoftwareCode_OPT_PM_TBO = "OPT-PM02300";
        // --- ADD 2016/05/27 m.kawarabayashi ------------------------------<<<<<
        // --- ADD 2016/11/02 30757 佐々木貴英------------------->>>>>
        /// <summary>
        /// 神姫産業㈱ 操作履歴テキスト変換制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_ShinkiOperationhistoryCtl = "OPT-CPM0300";
        // --- ADD 2016/11/02 30757 佐々木貴英 -------------------<<<<<
        // --- ADD 2016/11/08 30757 佐々木貴英------------------->>>>>
        /// <summary>
        /// ㈱コーエイ 売上伝票入力売価算出外部PG制御（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_KoeiCallExtProgCtl = "OPT-CPM0310";
        // --- ADD 2016/11/08 30757 佐々木貴英 -------------------<<<<<
        // --- ADD 2016/12/13 30350 r.sakurai------------------->>>>>
        /// <summary>
        /// 福田部品 売上伝票入力仕入担当者制御(個別)
        /// </summary>
        public const string SoftwareCode_OPT_CPM_FukudaCustom = "OPT-CPM0290";
        // --- ADD 2016/12/13 30350 r.sakurai -------------------<<<<<
        // --- ADD 2016/12/26 31561 菊地将吾------------------->>>>>
        /// <summary>
        /// 山形部品 売上伝票入力 価格・売価変更ロック
        /// </summary>
        public const string SoftwareCode_OPT_CPM_YamagataCustomControl = "OPT-CPM0320";
        // --- ADD 2016/12/26 31561 菊地将吾-------------------<<<<<
        // --- ADD 2017/01/04 30757 佐々木貴英------------------->>>>>
        /// <summary>
        /// 水野商工㈱ 売上伝票入力第二売価算出PG制御オプション（個別）
        /// </summary>
        public const string SoftwareCode_OPT_CPM_Mizuno2ndSellPriceCtl = "OPT-CPM0330";
        // --- ADD 2017/01/04 30757 佐々木貴英 -------------------<<<<<
        // --- ADD 2019/01/07 太田俊洋 ---------->>>>>
        /// <summary>
        /// ランテル セットマスタ個別
        /// </summary>
        public const string SoftwareCode_OPT_CPM_RuntelCustom = "OPT-CPM0340";
        // --- ADD 2019/01/07 太田俊洋 ----------<<<<<
       #endregion

	}
}
