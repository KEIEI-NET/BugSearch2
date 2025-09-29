//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   印刷情報クラス、インターフェース                //
//                  :												    //
// Name Space       :   Broadleaf.Application.Common				　　//
// Programer        :   柏原　頼人　                                    //
// Date             :   2007.03.19                                      //
//----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co,. Ltd                 //
//**********************************************************************//
using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Collections.Generic;

//using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// SFANL08205C
	/// </summary>
	[Serializable]
	public class SFANL08205C
    {

        #region const
        // Message関連
        private const string ctDOWNLOAD_TITLE = "自由帳票背景画像取得処理";
        private const string ctDOWNLOAD_MESSAGE = "自由帳票用背景画像の取得中です．．．";
        // Image関連
        private const Int32 ctSYSTEMDIVCD = 0;
        private const Int32 ctIMAGEUSESYSTEM_CODE = 100;
        #endregion

        #region constructor
        // コンストラクタ
		/// <summary>
		/// PrintInfo クラスの初期化及びインスタンス生成を行います。
		/// </summary>
		public SFANL08205C()
		{
        }
        #endregion

        #region public member
        // 抽出条件パラメータ
		/// <summary>
		/// 抽出条件パラメータメイン（汎用化するため、ＯＢＪＥＣＴ型とする。）
		/// 型は画面、抽出、印刷側で判断できるため。
		/// </summary>
		public object jyoken;
        /// <summary>
        /// 抽出条件パラメータ明細用
        /// </summary>
        public object jyokenDtl;

		/// <summary>
		/// 企業コード
		/// </summary>
		public string enterpriseCode;

		// 印刷用パラメータ
		/// <summary>
		/// プレビュー有無区分 0:無し 1:有り
		/// </summary>
		public int prevkbn;
        /// <summary>
        /// ダミーデータ印刷区分 true:ダミーデータ印刷 false:DBデータ参照
        /// </summary>
        public Boolean dummyPrtDiv;
        /// <summary>
		/// 印刷モード 0:localpdf 1:local 2:両方 3:バッチ印刷 4:ダミーデータプレビュー
		/// </summary>
		public int printmode;
		/// <summary>
		/// 帳票名称
		/// </summary>
		public string prpnm;
		/// <summary>
		/// プリンタ名
		/// </summary>
		public string prinm;
        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string outputFormFileName;
        /// <summary>
        /// ユーザー帳票ID枝番
        /// </summary>
        public int userPrtPprIdDerivNo;
        /// <summary>
        /// 出力確認メッセージ
        /// </summary>
        public string outConfimationMsg;
		/// <summary>
		/// 抽出条件XML保存先パス
		/// </summary>
		public string jyokenxmlpath;
        /// <summary>
        /// 印字位置クラスデータ (ActiveReport)
        /// </summary>
        public object printPosClassData;
        /// <summary>
        /// 帳票背景画像データ
        /// </summary>
        public Bitmap PrintPprBgImageData;
        /// <summary>
        /// ソート順位リスト
        /// </summary>
        public List<FrePprSrtO> sortOdrLs;
        /// <summary>
        /// 選択拠点リスト
        /// </summary>
        public List<string> selectSecCds;
        /// <summary>
        /// 拠点オプション有無
        /// </summary>
        public bool sectionOptionDiv;
        /// <summary>
        /// 拠点名称リスト
        /// </summary>
        public Dictionary<string,string> sectionNameLs;
        /// <summary>
        /// 抽出拠点種別
        /// </summary>
        public int sectionKindCd = 1;
        /// <summary>
        /// DMはがき印刷一時中断枚数
        /// </summary>
        public int pcardPrtSuspendCnt;
        /// <summary>
        /// 帳票使用区分
        /// </summary>
        public int printPaperUseDivcd;
        /// <summary>
        /// 取込画像グループコード
        /// </summary>
        public Guid takeInImageGroupCd;
        /// <summary>
        /// 特殊コンバート使用区分 (0:無,1:マクロ)
        /// </summary>
        public int SpecialConvtUseDivCd;
        /// <summary>
        /// PDFパス
        /// </summary>
        public string pdftemppath;
        /// <summary>
        /// 自由帳票 特種用途区分 0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき
        /// </summary>
        public int freePrtPprSpPrpseCd;
        /// <summary>
        /// 全社区分(全社：True, 全社でない:false)
        /// </summary>
        public bool AllSectionCodeDiv = true;


		// -------------印刷引渡しパラメータ
		/// <summary>
		/// 抽出結果データオブジェクト
		/// </summary>
		public DataSet rdData;
        /// <summary>
		/// 起動ＰＧＩＤ
		/// </summary>
		public string kidopgid;
		/// <summary>
		/// 抽出ＰＧＩＤ
		/// </summary>
		public string extrapgid;
		/// <summary>
		/// 抽出ＰＧ完全型名
		/// </summary>
		public string extraclassid;
		/// <summary>
		/// 印刷ＰＧＩＤ
		/// </summary>
		public string printpgid;
        /// <summary>印刷ＰＧ完全型名</summary>
		public string printclassid;
        /// <summary>帳票背景画像縦位置</summary>
	    public double prtPprBgImageRowPos;
        /// <summary>帳票背景画像横位置</summary>
        public double prtPprBgImageColPos;
        
        // 戻りパラメータ
		/// <summary>ステータス</summary>
		public int status;
        /// <summary>戻りメッセージ</summary>
        public string message = string.Empty;
        #endregion

        #region private member
        #endregion

        #region public methods
        /// <summary>
        /// 印字位置設定情報取込処理(背景画像は取得しません)
        /// </summary>
        /// <param name="frePrtPSet">印字位置設定データクラス</param>
        /// <param name="enterpriseCode">起業コード</param>
        /// <param name="kidopgid">起動ＰＧＩＤ</param>
        /// <param name="jyokenMain">メイン抽出条件</param>
        /// <param name="jokenDtl">抽出条件明細</param>
        /// <param name="dummyPrtDiv">ダミーデータ印刷区分 true:ダミーデータ印刷 false:DBデータ参照</param>
        public void InportFrePrtPSet(FrePrtPSet frePrtPSet, string enterpriseCode, string kidopgid, object jyokenMain, object jokenDtl, bool dummyPrtDiv)
        {
            // 印刷パラメータをセット
            this.enterpriseCode = enterpriseCode;                      // 企業コード
            this.kidopgid = kidopgid;		                            // 起動ＰＧＩＤ
            this.extrapgid = frePrtPSet.ExtractionPgId;                // 抽出ＰＧＩＤ
            this.extraclassid = frePrtPSet.ExtractionPgClassId;        // 抽出ＰＧ完全型名
            this.printpgid = frePrtPSet.OutputPgId;                    // 出力ＰＧＩＤ
            this.printclassid = frePrtPSet.OutputPgClassId;            // 出力クラスＩＤ
            this.jyoken = jyokenMain;                                  // 抽出条件メイン
            this.jyokenDtl = jokenDtl;                                 // 抽出条件明細
            this.prpnm = frePrtPSet.DisplayName;                       // 出力名称
            this.outputFormFileName = frePrtPSet.OutputFormFileName;   // 出力ファイル名
            this.userPrtPprIdDerivNo = frePrtPSet.UserPrtPprIdDerivNo; // ユーザー帳票ID
            this.outConfimationMsg = frePrtPSet.OutConfimationMsg;     // 出力確認メッセージ
            this.printPosClassData = frePrtPSet.PrintPosClassData;     // 印字位置クラス
            this.prtPprBgImageRowPos = frePrtPSet.PrtPprBgImageRowPos; // 背景画像縦位置
            this.prtPprBgImageColPos = frePrtPSet.PrtPprBgImageColPos; // 背景画像横位置
            this.dummyPrtDiv = dummyPrtDiv;                            // ダミーデータ印刷区分
            this.printPaperUseDivcd = frePrtPSet.PrintPaperUseDivcd;   // 帳票使用区分
            this.takeInImageGroupCd = frePrtPSet.TakeInImageGroupCd;   // 取込画像グループコード
            this.freePrtPprSpPrpseCd = frePrtPSet.FreePrtPprSpPrpseCd; // 自由帳票 特種用途区分
            // 印字位置クラス
            MemoryStream mst1 = new MemoryStream(frePrtPSet.PrintPosClassData);
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = new DataDynamics.ActiveReports.ActiveReport3();
            prtRpt.LoadLayout(mst1);
            this.printPosClassData = prtRpt;
        }
        #endregion
    }
}