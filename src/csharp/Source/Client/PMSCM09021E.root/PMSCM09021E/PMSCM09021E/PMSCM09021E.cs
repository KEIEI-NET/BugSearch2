//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM全体設定マスタ
// プログラム概要   : SCM全体設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009/05/01  修正内容 : 以下、項目追加。「レジ番号、受信処理起動間隔」
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20073 西 毅
// 作 成 日  2012/04/20  修正内容 : 項目追加「販売区分設定、販売区分コード」
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/31  修正内容 : 2012/10月配信予定 SCM障害№76の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341対応
//                                : 項目追加「自動回答区分（問合せ）、自動回答区分（発注）、
//                                : 受付従業員コード、受け従業員名称、納品区分、納品区分名称」
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : SCM障害追加②対応 2013/03/06配信
//                                : 項目追加「該当無自動回答区分」
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 配信日なし分 Redmine#34752
//                                : 項目追加「データ更新倉庫区分」
//----------------------------------------------------------------------------//
//管理番号  10801804-00  作成担当 : wangl2
//作 成 日  2013/04/11   修正内容 : No.73 見積自動回答サービス
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMTtlSt
	/// <summary>
	///                      SCM全体設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM全体設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/4/13</br>
	/// <br>Genarated Date   :   2010/08/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/5/12  杉村</br>
	/// <br>                 :   ○項目追加 </br>
	/// <br>                 :   旧システム連携フォルダ</br>
	/// <br>Update Note      :   2009/5/15  杉村</br>
	/// <br>                 :   ○項目追加 </br>
	/// <br>                 :   自動回答区分</br>
	/// <br>Update Note      :   2009/5/28  杉村</br>
	/// <br>                 :   ○補足修正</br>
	/// <br>                 :   0:しない 1:する</br>
	/// <br>                 :   ↓</br>
	/// <br>                 :   0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする</br>
	/// <br>Update Note      :   2009/7/7  杉村</br>
	/// <br>                 :   ○項目追加 </br>
	/// <br>                 :   見積書発行区分</br>
	/// <br>Update Note      :   2010/8/3  長内</br>
	/// <br>                 :   ○項目追加 </br>
	/// <br>                 :   レジ番号</br>
	/// <br>                 :   受信処理起動間隔</br>
	/// </remarks>
	public class SCMTtlSt
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		/// <remarks>00は全社</remarks>
		private string _sectionCode = "";

		/// <summary>売上伝票発行区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _salesSlipPrtDiv;

		/// <summary>受注伝票発行区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _acpOdrrSlipPrtDiv;

		/// <summary>旧システム連携区分</summary>
		/// <remarks>0:しない(PM.NS)　1:する（PM7SP）</remarks>
		private Int32 _oldSysCooperatDiv;

		/// <summary>旧システム連携フォルダ</summary>
		/// <remarks>デフォルトは"C:\SCMSHARE"</remarks>
		private string _oldSysCoopFolder = "";

		/// <summary>BLコード変換区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _bLCodeChgDiv;

		/// <summary>自動連携値引</summary>
		/// <remarks>値引き率</remarks>
		private double _autoCooperatDis;

		/// <summary>値引適用区分</summary>
		/// <remarks>0:しない 1:全て 2:外装品以外 3:重点品目</remarks>
		private Int32 _discountApplyCd;

		/// <summary>自動回答区分</summary>
		/// <remarks>0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする</remarks>
		private Int32 _autoAnswerDiv;

		/// <summary>見積書発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _estimatePrtDiv;

		/// <summary>レジ番号</summary>
		/// <remarks>マシン番号</remarks>
		private Int32 _cashRegisterNo;

		/// <summary>受信処理起動間隔</summary>
		private Int32 _rcvProcStInterval;

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// <summary>販売区分設定(自動回答時)</summary>
        private Int32 _salesCdStAutoAns;

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        /// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>自動回答時表示区分</summary>
        /// <remarks>0:使用しない,1:PM設定に従う,2:優良,3:純正,4:高い方(1:N),5:高い方(1:1)</remarks>
        private Int32 _autoAnsHourDspDiv;
        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// <summary>自動回答区分（問合せ）</summary>
        private Int32 _autoAnsInquiryDiv = 0;

        /// <summary>自動回答区分（発注）</summary>
        private Int32 _autoAnsOrderDiv = 0;

        /// <summary>受付従業員コード</summary>
        /// <remarks>PM受注者コード</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>納品区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>納品区分名称</summary>
        private string _deliveredGoodsNm = "";

        // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
        /// <summary>該当無自動回答区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _fuwioutAutoAnsDiv;
        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>データ更新倉庫区分</summary>
        /// <remarks>0:委託倉庫,1:主管倉庫</remarks>
        private Int32 _dataUpDateWareHDiv;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        /// <summary>売上入力者コード </summary>
        private string _salesInputCode;        // ADD 2013.04.11 wangl2 FOR RedMine#35269

		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// <value>00は全社</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SalesSlipPrtDiv
		/// <summary>売上伝票発行区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipPrtDiv
		{
			get{return _salesSlipPrtDiv;}
			set{_salesSlipPrtDiv = value;}
		}

		/// public propaty name  :  AcpOdrrSlipPrtDiv
		/// <summary>受注伝票発行区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcpOdrrSlipPrtDiv
		{
			get{return _acpOdrrSlipPrtDiv;}
			set{_acpOdrrSlipPrtDiv = value;}
		}

		/// public propaty name  :  OldSysCooperatDiv
		/// <summary>旧システム連携区分プロパティ</summary>
		/// <value>0:しない(PM.NS)　1:する（PM7SP）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧システム連携区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OldSysCooperatDiv
		{
			get{return _oldSysCooperatDiv;}
			set{_oldSysCooperatDiv = value;}
		}

		/// public propaty name  :  OldSysCoopFolder
		/// <summary>旧システム連携フォルダプロパティ</summary>
		/// <value>デフォルトは"C:\SCMSHARE"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧システム連携フォルダプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OldSysCoopFolder
		{
			get{return _oldSysCoopFolder;}
			set{_oldSysCoopFolder = value;}
		}

		/// public propaty name  :  BLCodeChgDiv
		/// <summary>BLコード変換区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLコード変換区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLCodeChgDiv
		{
			get{return _bLCodeChgDiv;}
			set{_bLCodeChgDiv = value;}
		}

		/// public propaty name  :  AutoCooperatDis
		/// <summary>自動連携値引プロパティ</summary>
		/// <value>値引き率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動連携値引プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public double AutoCooperatDis
		{
			get{return _autoCooperatDis;}
			set{_autoCooperatDis = value;}
		}

		/// public propaty name  :  DiscountApplyCd
		/// <summary>値引適用区分プロパティ</summary>
		/// <value>0:しない 1:全て 2:外装品以外 3:重点品目</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DiscountApplyCd
		{
			get{return _discountApplyCd;}
			set{_discountApplyCd = value;}
		}

		/// public propaty name  :  AutoAnswerDiv
		/// <summary>自動回答区分プロパティ</summary>
		/// <value>0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoAnswerDiv
		{
			get{return _autoAnswerDiv;}
			set{_autoAnswerDiv = value;}
		}

		/// public propaty name  :  EstimatePrtDiv
		/// <summary>見積書発行区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積書発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstimatePrtDiv
		{
			get{return _estimatePrtDiv;}
			set{_estimatePrtDiv = value;}
		}

		/// public propaty name  :  CashRegisterNo
		/// <summary>レジ番号プロパティ</summary>
		/// <value>マシン番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レジ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CashRegisterNo
		{
			get{return _cashRegisterNo;}
			set{_cashRegisterNo = value;}
		}

		/// public propaty name  :  RcvProcStInterval
		/// <summary>受信処理起動間隔プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信処理起動間隔プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RcvProcStInterval
		{
			get{return _rcvProcStInterval;}
			set{_rcvProcStInterval = value;}
		}
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// public propaty name  :  SalesCdStAutoAns
        /// <summary>販売区分設定(自動回答時)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分設定(自動回答時)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCdStAutoAns
        {
            get { return _salesCdStAutoAns; }
            set { _salesCdStAutoAns = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}

        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AutoAnsHourDspDiv
        /// <summary>自動回答時表示区分プロパティ</summary>
        /// <value>0:使用しない,1:PM設定に従う,2:優良,3:純正,4:高い方(1:N),5:高い方(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答時表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnsHourDspDiv
        {
            get { return _autoAnsHourDspDiv; }
            set { _autoAnsHourDspDiv = value; }
        }
        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<


        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// public propaty name  :  AutoAnsInquiryDiv
        /// <summary>自動回答区分（問合せ）プロパティ</summary>
        /// <value>0:しない(手動),1:する(全て自動回答),2:する(絞り込み時自動回答)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分（問合せ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnsInquiryDiv
        {
            get { return _autoAnsInquiryDiv; }
            set { _autoAnsInquiryDiv = value; }
        }


        /// public propaty name  : AutoAnsOrderDiv
        /// <summary>自動回答区分（発注）プロパティ</summary>
        /// <value>0:しない(手動),1:する(全て自動回答),2:する(委託在庫分のみ自動回答)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分（発注）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnsOrderDiv
        {
            get { return _autoAnsOrderDiv; }
            set { _autoAnsOrderDiv = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>PM受注者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsNm
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsNm
        {
            get { return _deliveredGoodsNm; }
            set { _deliveredGoodsNm = value; }
        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
        /// public propaty name  :  FuwioutAutoAnsDiv
        /// <summary>該当無自動回答区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   該当無自動回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FuwioutAutoAnsDiv
        {
            get { return _fuwioutAutoAnsDiv; }
            set { _fuwioutAutoAnsDiv = value; }
        }
        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  DataUpdWarehouseDiv
        /// <summary>データ更新倉庫区分プロパティ</summary>
        /// <value>0:委託倉庫,1:主管倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新倉庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataUpDateWareHDiv
        {
            get { return _dataUpDateWareHDiv; }
            set { _dataUpDateWareHDiv = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // --------------- ADD START 2013.04.11 wangl2 FOR RedMine#35269------>>>> 
        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }
        // --------------- ADD END 2013.04.11 wangl2 FOR RedMine#35269------<<<<<

		/// <summary>
		/// SCM全体設定マスタコンストラクタ
		/// </summary>
		/// <returns>SCMTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMTtlStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMTtlSt()
		{
		}

		/// <summary>
		/// SCM全体設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード(00は全社)</param>
		/// <param name="salesSlipPrtDiv">売上伝票発行区分(0:しない　1:する)</param>
		/// <param name="acpOdrrSlipPrtDiv">受注伝票発行区分(0:しない　1:する)</param>
		/// <param name="oldSysCooperatDiv">旧システム連携区分(0:しない(PM.NS)　1:する（PM7SP）)</param>
		/// <param name="oldSysCoopFolder">旧システム連携フォルダ(デフォルトは"C:\SCMSHARE")</param>
		/// <param name="bLCodeChgDiv">BLコード変換区分(0:する　1:しない)</param>
		/// <param name="autoCooperatDis">自動連携値引(値引き率)</param>
		/// <param name="discountApplyCd">値引適用区分(0:しない 1:全て 2:外装品以外 3:重点品目)</param>
		/// <param name="autoAnswerDiv">自動回答区分(0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする)</param>
		/// <param name="estimatePrtDiv">見積書発行区分(0:する　1:しない)</param>
		/// <param name="cashRegisterNo">レジ番号(マシン番号)</param>
		/// <param name="rcvProcStInterval">受信処理起動間隔</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="answerPriceDiv">自動回答時表示区分</param>
		/// <returns>SCMTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMTtlStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //2012/04/20 UPD T.Nishi >>>>>>>>>>
		//public SCMTtlSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 salesSlipPrtDiv,Int32 acpOdrrSlipPrtDiv,Int32 oldSysCooperatDiv,string oldSysCoopFolder,Int32 bLCodeChgDiv,double autoCooperatDis,Int32 discountApplyCd,Int32 autoAnswerDiv,Int32 estimatePrtDiv,Int32 cashRegisterNo,Int32 rcvProcStInterval,string enterpriseName,string updEmployeeName)
        // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode)
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv)
        // UPD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm)
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 fuwioutAutoAnsDiv)// DEL 2013/02/27 qijh #34752
        // UPD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
        // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        //2012/04/20 UPD T.Nishi <<<<<<<<<<
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 fuwioutAutoAnsDiv, Int32 dataUpDateWareHDiv)// ADD 2013/02/27 qijh #34752 //DEL 2013.04.11 wangl2 FOR RedMine#35269
        public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 fuwioutAutoAnsDiv, Int32 dataUpDateWareHDiv, string salesInputCode)//ADD 2013.04.11 wangl2 FOR RedMine#35269
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._salesSlipPrtDiv = salesSlipPrtDiv;
			this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
			this._oldSysCooperatDiv = oldSysCooperatDiv;
			this._oldSysCoopFolder = oldSysCoopFolder;
			this._bLCodeChgDiv = bLCodeChgDiv;
			this._autoCooperatDis = autoCooperatDis;
			this._discountApplyCd = discountApplyCd;
			this._autoAnswerDiv = autoAnswerDiv;
			this._estimatePrtDiv = estimatePrtDiv;
			this._cashRegisterNo = cashRegisterNo;
			this._rcvProcStInterval = rcvProcStInterval;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this._salesCdStAutoAns = salesCdStAutoAns;
            this._salesCode = salesCode;
            //2012/04/20 ADD T.Nishi <<<<<<<<<<
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._autoAnsHourDspDiv = autoAnsHourDspDiv;
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            this._autoAnsInquiryDiv = autoAnsInquiryDiv;
            this._autoAnsOrderDiv = autoAnsOrderDiv;
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsNm = deliveredGoodsNm;
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
            this._fuwioutAutoAnsDiv = fuwioutAutoAnsDiv;
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            this._dataUpDateWareHDiv = dataUpDateWareHDiv;// ADD 2013/02/27 qijh #34752
            this._salesInputCode = salesInputCode;//ADD 2013.04.11 wangl2 FOR RedMine#35269
        }

		/// <summary>
		/// SCM全体設定マスタ複製処理
		/// </summary>
		/// <returns>SCMTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMTtlStクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMTtlSt Clone()
		{
            //2012/04/20 UPD T.Nishi >>>>>>>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName);
            // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode);
            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv);
            // UPD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm);
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._fuwioutAutoAnsDiv);// DEL 2013/02/27 qijh #34752
            // UPD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
            // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //2012/04/20 UPD T.Nishi <<<<<<<<<<
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._fuwioutAutoAnsDiv, this._dataUpDateWareHDiv);// ADD 2013/02/27 qijh #34752  //DEL 2013.04.11 wangl2 FOR RedMine#35269
            return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._fuwioutAutoAnsDiv, this._dataUpDateWareHDiv, this._salesInputCode);//ADD 2013.04.11 wangl2 FOR RedMine#35269
        }

		/// <summary>
		/// SCM全体設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMTtlStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMTtlStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SCMTtlSt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
				 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
				 && (this.OldSysCooperatDiv == target.OldSysCooperatDiv)
				 && (this.OldSysCoopFolder == target.OldSysCoopFolder)
				 && (this.BLCodeChgDiv == target.BLCodeChgDiv)
				 && (this.AutoCooperatDis == target.AutoCooperatDis)
				 && (this.DiscountApplyCd == target.DiscountApplyCd)
				 && (this.AutoAnswerDiv == target.AutoAnswerDiv)
				 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
				 && (this.CashRegisterNo == target.CashRegisterNo)
				 && (this.RcvProcStInterval == target.RcvProcStInterval)
				 && (this.EnterpriseName == target.EnterpriseName)
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                 && (this.SalesCdStAutoAns == target.SalesCdStAutoAns)
                 && (this.SalesCode == target.SalesCode)
                //2012/04/20 ADD T.Nishi <<<<<<<<<<
                // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                 && (this.AutoAnsInquiryDiv == target.AutoAnsInquiryDiv)
                 && (this.AutoAnsOrderDiv == target.AutoAnsOrderDiv)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.DeliveredGoodsNm == target.DeliveredGoodsNm)
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
                // UPD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
                //&& (this.AutoAnsHourDspDiv == target.AutoAnsHourDspDiv));
                 && (this.AutoAnsHourDspDiv == target.AutoAnsHourDspDiv)
                 && (this.FuwioutAutoAnsDiv == target.FuwioutAutoAnsDiv)
                 && (this.DataUpDateWareHDiv == target.DataUpDateWareHDiv) // ADD 2013/02/27 qijh #34752
                 && (this.SalesInputCode == target.SalesInputCode)//ADD 2013.04.11 wangl2 FOR RedMine#35269
                );
            // UPD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// SCM全体設定マスタ比較処理
		/// </summary>
		/// <param name="sCMTtlSt1">
		///                    比較するSCMTtlStクラスのインスタンス
		/// </param>
		/// <param name="sCMTtlSt2">比較するSCMTtlStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMTtlStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SCMTtlSt sCMTtlSt1, SCMTtlSt sCMTtlSt2)
		{
			return ((sCMTtlSt1.CreateDateTime == sCMTtlSt2.CreateDateTime)
				 && (sCMTtlSt1.UpdateDateTime == sCMTtlSt2.UpdateDateTime)
				 && (sCMTtlSt1.EnterpriseCode == sCMTtlSt2.EnterpriseCode)
				 && (sCMTtlSt1.FileHeaderGuid == sCMTtlSt2.FileHeaderGuid)
				 && (sCMTtlSt1.UpdEmployeeCode == sCMTtlSt2.UpdEmployeeCode)
				 && (sCMTtlSt1.UpdAssemblyId1 == sCMTtlSt2.UpdAssemblyId1)
				 && (sCMTtlSt1.UpdAssemblyId2 == sCMTtlSt2.UpdAssemblyId2)
				 && (sCMTtlSt1.LogicalDeleteCode == sCMTtlSt2.LogicalDeleteCode)
				 && (sCMTtlSt1.SectionCode == sCMTtlSt2.SectionCode)
				 && (sCMTtlSt1.SalesSlipPrtDiv == sCMTtlSt2.SalesSlipPrtDiv)
				 && (sCMTtlSt1.AcpOdrrSlipPrtDiv == sCMTtlSt2.AcpOdrrSlipPrtDiv)
				 && (sCMTtlSt1.OldSysCooperatDiv == sCMTtlSt2.OldSysCooperatDiv)
				 && (sCMTtlSt1.OldSysCoopFolder == sCMTtlSt2.OldSysCoopFolder)
				 && (sCMTtlSt1.BLCodeChgDiv == sCMTtlSt2.BLCodeChgDiv)
				 && (sCMTtlSt1.AutoCooperatDis == sCMTtlSt2.AutoCooperatDis)
				 && (sCMTtlSt1.DiscountApplyCd == sCMTtlSt2.DiscountApplyCd)
				 && (sCMTtlSt1.AutoAnswerDiv == sCMTtlSt2.AutoAnswerDiv)
				 && (sCMTtlSt1.EstimatePrtDiv == sCMTtlSt2.EstimatePrtDiv)
				 && (sCMTtlSt1.CashRegisterNo == sCMTtlSt2.CashRegisterNo)
				 && (sCMTtlSt1.RcvProcStInterval == sCMTtlSt2.RcvProcStInterval)
				 && (sCMTtlSt1.EnterpriseName == sCMTtlSt2.EnterpriseName)
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                 && (sCMTtlSt1.SalesCdStAutoAns == sCMTtlSt2.SalesCdStAutoAns)
                 && (sCMTtlSt1.SalesCode == sCMTtlSt2.SalesCode)
                //2012/04/20 ADD T.Nishi <<<<<<<<<<
                // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //&& (sCMTtlSt1.UpdEmployeeName == sCMTtlSt2.UpdEmployeeName));
                 && (sCMTtlSt1.UpdEmployeeName == sCMTtlSt2.UpdEmployeeName)
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                 && (sCMTtlSt1.AutoAnsInquiryDiv == sCMTtlSt2.AutoAnsInquiryDiv)
                 && (sCMTtlSt1.AutoAnsOrderDiv == sCMTtlSt2.AutoAnsOrderDiv)
                 && (sCMTtlSt1.FrontEmployeeCd == sCMTtlSt2.FrontEmployeeCd)
                 && (sCMTtlSt1.FrontEmployeeNm == sCMTtlSt2.FrontEmployeeNm)
                 && (sCMTtlSt1.DeliveredGoodsDiv == sCMTtlSt2.DeliveredGoodsDiv)
                 && (sCMTtlSt1.DeliveredGoodsNm == sCMTtlSt2.DeliveredGoodsNm)
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
                // UPD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
                //&& (sCMTtlSt1.AutoAnsHourDspDiv == sCMTtlSt2.AutoAnsHourDspDiv));
                 && (sCMTtlSt1.AutoAnsHourDspDiv == sCMTtlSt2.AutoAnsHourDspDiv)
                 && (sCMTtlSt1.FuwioutAutoAnsDiv == sCMTtlSt2.FuwioutAutoAnsDiv)
                 && (sCMTtlSt1.DataUpDateWareHDiv == sCMTtlSt2.DataUpDateWareHDiv) // ADD 2013/02/27 qijh #34752
                 && (sCMTtlSt1.SalesInputCode == sCMTtlSt2.SalesInputCode)//ADD 2013.04.11 wangl2 FOR RedMine#35269
                 );
            // UPD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
		/// <summary>
		/// SCM全体設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMTtlStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMTtlStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SCMTtlSt target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SalesSlipPrtDiv != target.SalesSlipPrtDiv)resList.Add("SalesSlipPrtDiv");
			if(this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv)resList.Add("AcpOdrrSlipPrtDiv");
			if(this.OldSysCooperatDiv != target.OldSysCooperatDiv)resList.Add("OldSysCooperatDiv");
			if(this.OldSysCoopFolder != target.OldSysCoopFolder)resList.Add("OldSysCoopFolder");
			if(this.BLCodeChgDiv != target.BLCodeChgDiv)resList.Add("BLCodeChgDiv");
			if(this.AutoCooperatDis != target.AutoCooperatDis)resList.Add("AutoCooperatDis");
			if(this.DiscountApplyCd != target.DiscountApplyCd)resList.Add("DiscountApplyCd");
			if(this.AutoAnswerDiv != target.AutoAnswerDiv)resList.Add("AutoAnswerDiv");
			if(this.EstimatePrtDiv != target.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
			if(this.CashRegisterNo != target.CashRegisterNo)resList.Add("CashRegisterNo");
			if(this.RcvProcStInterval != target.RcvProcStInterval)resList.Add("RcvProcStInterval");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            if (this.SalesCdStAutoAns != target.SalesCdStAutoAns) resList.Add("SalesCdStAutoAns");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AutoAnsHourDspDiv != target.AutoAnsHourDspDiv) resList.Add("AutoAnsHourDspDiv");
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            if (this.AutoAnsInquiryDiv != target.AutoAnsInquiryDiv) resList.Add("AutoAnsInquiryDiv");
            if (this.AutoAnsOrderDiv != target.AutoAnsOrderDiv) resList.Add("AutoAnsOrderDiv");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.DeliveredGoodsNm != target.DeliveredGoodsNm) resList.Add("DeliveredGoodsNm");
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
            if (this.FuwioutAutoAnsDiv != target.FuwioutAutoAnsDiv) resList.Add("FuwioutAutoAnsDiv");
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            if (this.DataUpDateWareHDiv != target.DataUpDateWareHDiv) resList.Add("DataUpdWarehouseDiv"); // ADD 2013/02/27 qijh #34752
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");//ADD 2013.04.11 wangl2 FOR RedMine#35269

			return resList;
		}

		/// <summary>
		/// SCM全体設定マスタ比較処理
		/// </summary>
		/// <param name="sCMTtlSt1">比較するSCMTtlStクラスのインスタンス</param>
		/// <param name="sCMTtlSt2">比較するSCMTtlStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMTtlStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SCMTtlSt sCMTtlSt1, SCMTtlSt sCMTtlSt2)
		{
			ArrayList resList = new ArrayList();
			if(sCMTtlSt1.CreateDateTime != sCMTtlSt2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMTtlSt1.UpdateDateTime != sCMTtlSt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMTtlSt1.EnterpriseCode != sCMTtlSt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMTtlSt1.FileHeaderGuid != sCMTtlSt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMTtlSt1.UpdEmployeeCode != sCMTtlSt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMTtlSt1.UpdAssemblyId1 != sCMTtlSt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMTtlSt1.UpdAssemblyId2 != sCMTtlSt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMTtlSt1.LogicalDeleteCode != sCMTtlSt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMTtlSt1.SectionCode != sCMTtlSt2.SectionCode)resList.Add("SectionCode");
			if(sCMTtlSt1.SalesSlipPrtDiv != sCMTtlSt2.SalesSlipPrtDiv)resList.Add("SalesSlipPrtDiv");
			if(sCMTtlSt1.AcpOdrrSlipPrtDiv != sCMTtlSt2.AcpOdrrSlipPrtDiv)resList.Add("AcpOdrrSlipPrtDiv");
			if(sCMTtlSt1.OldSysCooperatDiv != sCMTtlSt2.OldSysCooperatDiv)resList.Add("OldSysCooperatDiv");
			if(sCMTtlSt1.OldSysCoopFolder != sCMTtlSt2.OldSysCoopFolder)resList.Add("OldSysCoopFolder");
			if(sCMTtlSt1.BLCodeChgDiv != sCMTtlSt2.BLCodeChgDiv)resList.Add("BLCodeChgDiv");
			if(sCMTtlSt1.AutoCooperatDis != sCMTtlSt2.AutoCooperatDis)resList.Add("AutoCooperatDis");
			if(sCMTtlSt1.DiscountApplyCd != sCMTtlSt2.DiscountApplyCd)resList.Add("DiscountApplyCd");
			if(sCMTtlSt1.AutoAnswerDiv != sCMTtlSt2.AutoAnswerDiv)resList.Add("AutoAnswerDiv");
			if(sCMTtlSt1.EstimatePrtDiv != sCMTtlSt2.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
			if(sCMTtlSt1.CashRegisterNo != sCMTtlSt2.CashRegisterNo)resList.Add("CashRegisterNo");
			if(sCMTtlSt1.RcvProcStInterval != sCMTtlSt2.RcvProcStInterval)resList.Add("RcvProcStInterval");
			if(sCMTtlSt1.EnterpriseName != sCMTtlSt2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMTtlSt1.UpdEmployeeName != sCMTtlSt2.UpdEmployeeName)resList.Add("UpdEmployeeName");
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            if (sCMTtlSt1.SalesCdStAutoAns != sCMTtlSt2.SalesCdStAutoAns) resList.Add("SalesCdStAutoAns");
            if (sCMTtlSt1.SalesCode != sCMTtlSt2.SalesCode) resList.Add("SalesCode");
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (sCMTtlSt1.AutoAnsHourDspDiv != sCMTtlSt2.AutoAnsHourDspDiv) resList.Add("AutoAnsHourDspDiv");
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            if (sCMTtlSt1.AutoAnsInquiryDiv != sCMTtlSt2.AutoAnsInquiryDiv) resList.Add("AutoAnsInquiryDiv");
            if (sCMTtlSt1.AutoAnsOrderDiv != sCMTtlSt2.AutoAnsOrderDiv) resList.Add("AutoAnsOrderDiv");
            if (sCMTtlSt1.FrontEmployeeCd != sCMTtlSt2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (sCMTtlSt1.FrontEmployeeNm != sCMTtlSt2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (sCMTtlSt1.DeliveredGoodsDiv != sCMTtlSt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (sCMTtlSt1.DeliveredGoodsNm != sCMTtlSt2.DeliveredGoodsNm) resList.Add("DeliveredGoodsNm");
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
            if (sCMTtlSt1.FuwioutAutoAnsDiv != sCMTtlSt2.FuwioutAutoAnsDiv) resList.Add("FuwioutAutoAnsDiv");
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            if (sCMTtlSt1.DataUpDateWareHDiv != sCMTtlSt2.DataUpDateWareHDiv) resList.Add("DataUpdWarehouseDiv"); // ADD 2013/02/27 qijh #34752
            if (sCMTtlSt1.SalesInputCode != sCMTtlSt2.SalesInputCode) resList.Add("SalesInputCode");//ADD 2013.04.11 wangl2 FOR RedMine#35269

			return resList;
		}
	}
}
