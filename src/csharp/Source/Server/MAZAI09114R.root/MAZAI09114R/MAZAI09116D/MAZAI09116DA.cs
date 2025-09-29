using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockMngTtlStWork
	/// <summary>
	///                      在庫管理全体設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫管理全体設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/17</br>
	/// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2009/12/02 朱俊成</br>
    /// <br>                     PM.NS-4</br>
    /// <br>                     棚卸運用区分の追加</br>
    /// <br>Update Note      :   2011/08/29 周雨</br>
    /// <br>                     連番 1016 「現在庫表示区分」をに追加　</br>
    /// <br>Update Note      :   2012/06/08 lanl</br>
    /// <br>                     #Redmine30282 「棚卸データ削除区分」をに追加　</br>
    /// <br>Update Note      :   2012/07/02 三戸　伸悟</br>
    /// <br>                     「移動時在庫自動登録区分」を画面に追加　</br>
    /// <br>Update Note      :   2014/10/27 wangf </br>
    /// <br>                 :   Redmine#43854画面に列「移動伝票出力先区分」追加</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockMngTtlStWork : IFileHeader
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
		/// <remarks>オール０は全社</remarks>
		private string _sectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>在庫移動確定区分</summary>
		/// <remarks>1：出荷確定あり、２：出荷確定なし</remarks>
		private Int32 _stockMoveFixCode;

		/// <summary>在庫評価方法</summary>
		/// <remarks>1:最終仕入原価法,2:移動平均法</remarks>
		private Int32 _stockPointWay;

        /// <summary>端数処理区分</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fractionProcCd;

        // --- ADD 2009/12/02 ---------->>>>>
        /// <summary>棚卸運用区分</summary>
        /// <remarks>0：ＰＭ．ＮＳ,2：ＰＭ７</remarks>
        private Int32 _inventoryMngDiv;
        // --- ADD 2009/12/02 ----------<<<<<

        /// <summary>在庫切れ出荷区分</summary>
		/// <remarks>0:無し,1:警告,2:警告+再入力,3:再入力 （在庫切れチェック)</remarks>
		private Int32 _stockTolerncShipmDiv;

		/// <summary>棚卸印刷順初期設定区分</summary>
		/// <remarks>0:棚番順 1:仕入先順 2:BLｺｰﾄﾞ順 3:ﾒｰｶｰｺｰﾄﾞ順 4:仕入先･棚番順 5:仕入先･ﾒｰｶｰ順 （棚卸記入表、差異表で使用）</remarks>
		private Int32 _invntryPrtOdrIniDiv;

		/// <summary>最高在庫数超え発注区分</summary>
		/// <remarks>0:しない(最高在庫数まで)　1:する(最高在庫を超えた最小ﾛｯﾄ)発注点発注時最高在庫数を超えて発注データを作成するか否か</remarks>
		private Int32 _maxStkCntOverOderDiv;

		/// <summary>棚番重複区分</summary>
		/// <remarks>0:可能 1:不可　　※不可は1品番1棚で管理</remarks>
		private Int32 _shelfNoDuplDiv;

		/// <summary>ロット使用区分</summary>
		/// <remarks>0:発注ロット(在庫マスタ)　1:流通ロット(商品マスタ)※発注一覧表</remarks>
		private Int32 _lotUseDivCd;

		/// <summary>拠点表示区分</summary>
		/// <remarks>0:倉庫ﾏｽﾀ　1:自社ﾏｽﾀ　2:表示無し</remarks>
		private Int32 _sectDspDivCd;

        // -------------- ADD 2011/08/29 ----------------- >>>>>
        /// <summary>現在庫表示区分</summary>
        /// <remarks>0:受注分含む 1:受注分含まない</remarks>
        private Int32 _preStckCntDspDiv;
        // -------------- ADD 2011/08/29 ----------------- <<<<<

        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
        /// <summary>棚卸データ削除区分</summary>
        /// <remarks>0:可能 1:可能(拠点指定可能) 2:不可</remarks>
        private Int32 _invntryDtDelDiv;
        // -------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<

        // --- ADD 三戸 2012/07/02 ---------->>>>>
        // 移動時在庫自動登録区分
        private Int32 _moveStockAutoInsDiv;
        // --- ADD 三戸 2012/07/02 ----------<<<<<

        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
        // 移動伝票出力先区分
        private Int32 _moveSlipOutPutDiv;
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

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
		/// <value>オール０は全社</value>
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

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  StockMoveFixCode
		/// <summary>在庫移動確定区分プロパティ</summary>
		/// <value>1：出荷確定あり、２：出荷確定なし</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫移動確定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockMoveFixCode
		{
			get{return _stockMoveFixCode;}
			set{_stockMoveFixCode = value;}
		}
        
  		/// public propaty name  :  StockPointWay
		/// <summary>在庫評価方法プロパティ</summary>
		/// <value>1:最終仕入原価法,2:移動平均法</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫評価方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockPointWay
		{
			get{return _stockPointWay;}
			set{_stockPointWay = value;}
		}

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        // --- ADD 2009/12/02 ---------->>>>>
        /// public propaty name  :  InventoryMngDiv
        /// <summary>棚卸運用区分プロパティ</summary>
        /// <value>0：ＰＭ．ＮＳ,1：ＰＭ７</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸運用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }
        // --- ADD 2009/12/02 ----------<<<<<

        /// public propaty name  :  StockTolerncShipmDiv
		/// <summary>在庫切れ出荷区分プロパティ</summary>
		/// <value>0:無し,1:警告,2:警告+再入力,3:再入力 （在庫切れチェック)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫切れ出荷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockTolerncShipmDiv
		{
			get{return _stockTolerncShipmDiv;}
			set{_stockTolerncShipmDiv = value;}
		}

		/// public propaty name  :  InvntryPrtOdrIniDiv
		/// <summary>棚卸印刷順初期設定区分プロパティ</summary>
		/// <value>0:棚番順 1:仕入先順 2:BLｺｰﾄﾞ順 3:ﾒｰｶｰｺｰﾄﾞ順 4:仕入先･棚番順 5:仕入先･ﾒｰｶｰ順 （棚卸記入表、差異表で使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚卸印刷順初期設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InvntryPrtOdrIniDiv
		{
			get{return _invntryPrtOdrIniDiv;}
			set{_invntryPrtOdrIniDiv = value;}
		}

		/// public propaty name  :  MaxStkCntOverOderDiv
		/// <summary>最高在庫数超え発注区分プロパティ</summary>
		/// <value>0:しない(最高在庫数まで)　1:する(最高在庫を超えた最小ﾛｯﾄ)発注点発注時最高在庫数を超えて発注データを作成するか否か</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最高在庫数超え発注区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MaxStkCntOverOderDiv
		{
			get{return _maxStkCntOverOderDiv;}
			set{_maxStkCntOverOderDiv = value;}
		}

		/// public propaty name  :  ShelfNoDuplDiv
		/// <summary>棚番重複区分プロパティ</summary>
		/// <value>0:可能 1:不可　　※不可は1品番1棚で管理</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番重複区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShelfNoDuplDiv
		{
			get{return _shelfNoDuplDiv;}
			set{_shelfNoDuplDiv = value;}
		}

		/// public propaty name  :  LotUseDivCd
		/// <summary>ロット使用区分プロパティ</summary>
		/// <value>0:発注ロット(在庫マスタ)　1:流通ロット(商品マスタ)※発注一覧表</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ロット使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LotUseDivCd
		{
			get{return _lotUseDivCd;}
			set{_lotUseDivCd = value;}
		}

		/// public propaty name  :  SectDspDivCd
		/// <summary>拠点表示区分プロパティ</summary>
		/// <value>0:倉庫ﾏｽﾀ　1:自社ﾏｽﾀ　2:表示無し</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SectDspDivCd
		{
			get{return _sectDspDivCd;}
			set{_sectDspDivCd = value;}
		}

        // ---------------- ADD 2011/08/29 ------------------ >>>>>
        /// public propaty name  :  PreStckCntDspDiv
        /// <summary>現在庫表示区分プロパティ</summary>
        /// <value>0:受注分含む 1:受注分含まない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PreStckCntDspDiv
        {
            get { return _preStckCntDspDiv; }
            set { _preStckCntDspDiv = value; }
        }
        // ---------------- ADD 2011/08/29 ------------------ <<<<<

        // ---------------- ADD lanl 2012/06/08 Redmine#30282 ------------------ >>>>>
        /// public propaty name  :  InvntryDtDelDiv
        /// <summary>棚卸データ削除区分プロパティ</summary>
        /// <value>0:可能 1:可能(拠点指定可能) 2:不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸データ削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InvntryDtDelDiv
        {
            get { return _invntryDtDelDiv; }
            set { _invntryDtDelDiv = value; }
        }
        // ---------------- ADD lanl 2012/06/08 Redmine#30282 ------------------ <<<<<

        // --- ADD 三戸 2012/07/02 ---------->>>>>
        /// public propaty name  :  MoveStockAutoInsDiv
        /// <summary>移動時在庫自動登録区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動時在庫自動登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveStockAutoInsDiv
        {
            get { return _moveStockAutoInsDiv; }
            set { _moveStockAutoInsDiv = value; }
        }
        // --- ADD 三戸 2012/07/02 ----------<<<<<
        
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
        /// public propaty name  :  MoveSlipOutPutDiv
        /// <summary>移動伝票出力先区分プロパティ</summary>
        /// <value>0:入庫倉庫 1:出庫倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動伝票出力先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveSlipOutPutDiv
        {
            get { return _moveSlipOutPutDiv; }
            set { _moveSlipOutPutDiv = value; }
        }
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
        
        /// <summary>
		/// 在庫管理全体設定ワークコンストラクタ
		/// </summary>
		/// <returns>StockMngTtlStWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMngTtlStWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockMngTtlStWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockMngTtlStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockMngTtlStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockMngTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMngTtlStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMngTtlStWork || graph is ArrayList || graph is StockMngTtlStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockMngTtlStWork).FullName));

            if (graph != null && graph is StockMngTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMngTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMngTtlStWork[])graph).Length;
            }
            else if (graph is StockMngTtlStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //在庫移動確定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFixCode
            //在庫評価方法
            serInfo.MemberInfo.Add(typeof(Int32)); //StockPointWay
            //端数処理
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InventoryMngDiv
            // --- ADD 2009/12/02 ----------<<<<<
            //在庫切れ出荷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockTolerncShipmDiv
            //棚卸印刷順初期設定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InvntryPrtOdrIniDiv
            //最高在庫数超え発注区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MaxStkCntOverOderDiv
            //棚番重複区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShelfNoDuplDiv
            //ロット使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LotUseDivCd
            //拠点表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SectDspDivCd
            // ----------------- ADD 2011/08/29 -------------------- >>>>>
            //現在庫表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PreStckCntDspDiv
            // ----------------- ADD 2011/08/29 -------------------- <<<<<
            // ----------------- ADD lanl 2012/06/08 Redmine#30282 -------------------- >>>>>
            //棚卸データ削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InvntryDtDelDiv
            // ----------------- ADD lanl 2012/06/08 Redmine#30282 -------------------- <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveStockAutoInsDiv
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            serInfo.MemberInfo.Add(typeof(Int32)); //MoveSlipOutPutDiv
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is StockMngTtlStWork)
            {
                StockMngTtlStWork temp = (StockMngTtlStWork)graph;

                SetStockMngTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMngTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMngTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMngTtlStWork temp in lst)
                {
                    SetStockMngTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMngTtlStWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 21;//DEL lanl 2012/06/08 Redmine#30282
        //private const int currentMemberCount = 22;//ADD lanl 2012/06/08 Redmine#30282 //DEL 三戸 2012/07/02
        //private const int currentMemberCount = 23;//ADD 三戸 2012/07/02 // DEL wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加
        private const int currentMemberCount = 24; // ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加

        /// <summary>
        ///  StockMngTtlStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockMngTtlStWork(System.IO.BinaryWriter writer, StockMngTtlStWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //在庫移動確定区分
            writer.Write(temp.StockMoveFixCode);
            //在庫評価方法
            writer.Write(temp.StockPointWay);
            //端数処理
            writer.Write(temp.FractionProcCd);
            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            writer.Write(temp.InventoryMngDiv);
            // --- ADD 2009/12/02 ----------<<<<<
            //在庫切れ出荷区分
            writer.Write(temp.StockTolerncShipmDiv);
            //棚卸印刷順初期設定区分
            writer.Write(temp.InvntryPrtOdrIniDiv);
            //最高在庫数超え発注区分
            writer.Write(temp.MaxStkCntOverOderDiv);
            //棚番重複区分
            writer.Write(temp.ShelfNoDuplDiv);
            //ロット使用区分
            writer.Write(temp.LotUseDivCd);
            //拠点表示区分
            writer.Write(temp.SectDspDivCd);
            // ---------------- ADD 2011/08/29 ----------------- >>>>>
            //現在庫表示区分
            writer.Write(temp.PreStckCntDspDiv);
            // ---------------- ADD 2011/08/29 ----------------- <<<<<
            // ---------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- >>>>>
            //棚卸データ削除区分
            writer.Write(temp.InvntryDtDelDiv);
            // ---------------- ADD lanl 2012/06/08 Redmine#30282 ----------------- <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            writer.Write(temp.MoveStockAutoInsDiv);
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            writer.Write(temp.MoveSlipOutPutDiv);
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

        }

        /// <summary>
        ///  StockMngTtlStWorkインスタンス取得
        /// </summary>
        /// <returns>StockMngTtlStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockMngTtlStWork GetStockMngTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockMngTtlStWork temp = new StockMngTtlStWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //在庫移動確定区分
            temp.StockMoveFixCode = reader.ReadInt32();
            //在庫評価方法
            temp.StockPointWay = reader.ReadInt32();
            //端数処理
            temp.FractionProcCd = reader.ReadInt32();
            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            temp.InventoryMngDiv = reader.ReadInt32();
            // --- ADD 2009/12/02 ----------<<<<<
            //在庫切れ出荷区分
            temp.StockTolerncShipmDiv = reader.ReadInt32();
            //棚卸印刷順初期設定区分
            temp.InvntryPrtOdrIniDiv = reader.ReadInt32();
            //最高在庫数超え発注区分
            temp.MaxStkCntOverOderDiv = reader.ReadInt32();
            //棚番重複区分
            temp.ShelfNoDuplDiv = reader.ReadInt32();
            //ロット使用区分
            temp.LotUseDivCd = reader.ReadInt32();
            //拠点表示区分
            temp.SectDspDivCd = reader.ReadInt32();
            // ------------------ ADD 2011/08/29 ------------------ >>>>>
            //現在庫表示区分
            temp.PreStckCntDspDiv = reader.ReadInt32();
            // ------------------ ADD 2011/08/29 ------------------ <<<<<
            // ------------------ ADD lanl 2012/06/08 Redmine#30282 ------------------ >>>>>
            //棚卸データ削除区分
            temp.InvntryDtDelDiv = reader.ReadInt32();
            // ------------------ ADD lanl 2012/06/08 Redmine#30282 ------------------ <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            temp.MoveStockAutoInsDiv = reader.ReadInt32();
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            temp.MoveSlipOutPutDiv = reader.ReadInt32();
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>StockMngTtlStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMngTtlStWork temp = GetStockMngTtlStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (StockMngTtlStWork[])lst.ToArray(typeof(StockMngTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}