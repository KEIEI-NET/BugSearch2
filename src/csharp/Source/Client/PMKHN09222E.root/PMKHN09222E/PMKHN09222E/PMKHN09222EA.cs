using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PriceChgProcSt
	/// <summary>
    ///                      価格改正設定マスタ データクラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   価格改正設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/04/30</br>
	/// <br>Genarated Date   :   2005/05/02  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2007.08.16 980035 金沢 貞義</br>
    /// <br>			         ・端数処理区分を削除して消費税転嫁方式を追加</br>
    /// <br></br>
    /// <br>Update Note      :   2009/12/11 21024　佐々木 健</br>
    /// <br>			         ・BLコード更新区分の追加</br>
    /// </remarks>
	public class PriceChgSet
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

        /// <summary>名称更新区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _nameUpdDiv;

        /// <summary>層別更新区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _partsLayerUpdDiv;

        /// <summary>価格更新区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _priceUpdDiv;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:価格を引継ぐ,1:0で更新</remarks>
        private Int32 _openPriceDiv;

        /// <summary>価格管理件数</summary>
        /// <remarks>3,4,5</remarks>
        private Int32 _priceMngCnt;

        /// <summary>価格改正処理区分</summary>
        /// <remarks>0:シンクと同期,1:手動処理</remarks>
        private Int32 _priceChgProcDiv;

        // 2009/12/11 Add >>>
        /// <summary>BLコード更新区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _bLGoodsCdUpdDiv;
        // 2009/12/11 Add <<<


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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  NameUpdDiv
        /// <summary>名称更新区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NameUpdDiv
        {
            get { return _nameUpdDiv; }
            set { _nameUpdDiv = value; }
        }

        /// public propaty name  :  PartsLayerUpdDiv
        /// <summary>層別更新区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsLayerUpdDiv
        {
            get { return _partsLayerUpdDiv; }
            set { _partsLayerUpdDiv = value; }
        }

        /// public propaty name  :  PriceUpdDiv
        /// <summary>価格更新区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceUpdDiv
        {
            get { return _priceUpdDiv; }
            set { _priceUpdDiv = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:価格を引継ぐ,1:0で更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  PriceMngCnt
        /// <summary>価格管理件数プロパティ</summary>
        /// <value>3,4,5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格管理件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceMngCnt
        {
            get { return _priceMngCnt; }
            set { _priceMngCnt = value; }
        }

        /// public propaty name  :  PriceChgProcDiv
        /// <summary>価格改正処理区分プロパティ</summary>
        /// <value>0:シンクと同期,1:手動処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格改正処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceChgProcDiv
        {
            get { return _priceChgProcDiv; }
            set { _priceChgProcDiv = value; }
        }

        // 2009/12/11 Add >>>
        /// public propaty name  :  BLGoodsCdUpdDiv
        /// <summary>BLコード更新区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        public Int32 BLGoodsCdUpdDiv
        {
            get { return _bLGoodsCdUpdDiv; }
            set { _bLGoodsCdUpdDiv = value; }
        }
        // 2009/12/11 Add <<<

        /// <summary>
        /// 価格改正設定コンストラクタ
        /// </summary>
        /// <returns>PriceChgProcStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceChgProcStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceChgSet()
        {
            _priceMngCnt = 3; // デフォルト値3
        }
        
        /// <summary>
        /// 価格改正設定クラスコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="nameUpdDiv">名称更新区分</param>
        /// <param name="partsLayerUpdDiv">層別更新区分</param>
        /// <param name="priceUpdDiv">価格更新区分</param>
        /// <param name="openPriceDiv">オープン価格区分</param>
        /// <param name="priceMngCnt">価格管理件数</param>
        /// <param name="priceChgProcDiv">価格改正処理区分</param>        
        /// <param name="bLGoodsCdUpdDiv">BLコード更新区分</param>
		/// <remarks>
        /// <br>Note　　　　　　 :   PriceChgSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        // 2009/12/11 >>>
        //public PriceChgSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, 
        //    string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode,
        //    Int32 nameUpdDiv, Int32 partsLayerUpdDiv, Int32 priceUpdDiv, Int32 openPriceDiv, Int32 priceMngCnt, Int32 priceChgProcDiv)
        public PriceChgSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid,
            string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode,
            Int32 nameUpdDiv, Int32 partsLayerUpdDiv, Int32 priceUpdDiv, Int32 openPriceDiv, Int32 priceMngCnt, Int32 priceChgProcDiv, Int32 bLGoodsCdUpdDiv)
        // 2009/12/11 <<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            this._nameUpdDiv = nameUpdDiv;
            this._partsLayerUpdDiv = partsLayerUpdDiv;
            this._priceUpdDiv = priceUpdDiv;
            this._openPriceDiv = openPriceDiv;
            this._priceMngCnt = priceMngCnt;
            this._priceChgProcDiv = priceChgProcDiv;
            this._bLGoodsCdUpdDiv = bLGoodsCdUpdDiv;    // 2009/12/11 Add
		}

        /// <summary>
        /// 価格改正設定クラス複製処理
        /// </summary>
        /// <returns>PriceChgSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPriceChgSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceChgSet Clone()
        {
            // 2009/12/11 >>>
            //return new PriceChgSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid,
            //    this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode,
            //    this._nameUpdDiv, this._partsLayerUpdDiv, this._priceUpdDiv, this._openPriceDiv,
            //    this._priceMngCnt, this._priceChgProcDiv);
            return new PriceChgSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid,
                this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode,
                this._nameUpdDiv, this._partsLayerUpdDiv, this._priceUpdDiv, this._openPriceDiv,
                this._priceMngCnt, this._priceChgProcDiv, this._bLGoodsCdUpdDiv);
            // 2009/12/11 <<<
        }


        /// <summary>
        /// 価格改正設定クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のPriceChgSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceChgSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PriceChgSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                && (this.UpdateDateTime == target.UpdateDateTime)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.FileHeaderGuid == target.FileHeaderGuid)
                && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                && (this._nameUpdDiv == target.NameUpdDiv)
                && (this._partsLayerUpdDiv == target.PartsLayerUpdDiv)
                && (this._priceUpdDiv == target.PriceUpdDiv)
                && (this._openPriceDiv == target.OpenPriceDiv)
                && (this._priceMngCnt == target.PriceMngCnt)
                // 2009/12/11 Add >>>
                && ( this._bLGoodsCdUpdDiv == target.BLGoodsCdUpdDiv )
                // 2009/12/11 Add <<<
                && (this._priceChgProcDiv == target.PriceChgProcDiv));
        }

        /// <summary>
        /// 価格改正設定クラス比較処理
        /// </summary>
        /// <param name="taxrateset1">
        ///                    比較するPriceChgSetクラスのインスタンス
        /// </param>
        /// <param name="taxrateset2">比較するPriceChgSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceChgSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PriceChgSet priceChgSet1, PriceChgSet priceChgSet2)
        {
            return ((priceChgSet1.CreateDateTime == priceChgSet2.CreateDateTime)
                && (priceChgSet1.UpdateDateTime == priceChgSet2.UpdateDateTime)
                && (priceChgSet1.EnterpriseCode == priceChgSet2.EnterpriseCode)
                && (priceChgSet1.FileHeaderGuid == priceChgSet2.FileHeaderGuid)
                && (priceChgSet1.UpdEmployeeCode == priceChgSet2.UpdEmployeeCode)
                && (priceChgSet1.UpdAssemblyId1 == priceChgSet2.UpdAssemblyId1)
                && (priceChgSet1.UpdAssemblyId2 == priceChgSet2.UpdAssemblyId2)
                && (priceChgSet1.LogicalDeleteCode == priceChgSet2.LogicalDeleteCode)
                && (priceChgSet1.NameUpdDiv == priceChgSet2.NameUpdDiv)
                && (priceChgSet1.PartsLayerUpdDiv == priceChgSet2.PartsLayerUpdDiv)
                && (priceChgSet1.PriceUpdDiv == priceChgSet2.PriceUpdDiv)
                && (priceChgSet1.OpenPriceDiv == priceChgSet2.OpenPriceDiv)
                && (priceChgSet1.PriceMngCnt == priceChgSet2.PriceMngCnt)
                // 2009/12/11 Add >>>
                && ( priceChgSet1.BLGoodsCdUpdDiv == priceChgSet2.BLGoodsCdUpdDiv )
                // 2009/12/11 Add <<<
                && (priceChgSet1.PriceChgProcDiv == priceChgSet2.PriceChgProcDiv));
        }
        /// <summary>
        /// 価格改正設定クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のPriceChgSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceChgSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PriceChgSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.NameUpdDiv != target.NameUpdDiv) resList.Add("NameUpdDiv");
            if (this.PartsLayerUpdDiv != target.PartsLayerUpdDiv) resList.Add("PartsLayerUpdDiv");
            if (this.PriceUpdDiv != target.PriceUpdDiv) resList.Add("PriceUpdDiv");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (this.PriceMngCnt != target.PriceMngCnt) resList.Add("PriceMngCnt");
            if (this.PriceChgProcDiv != target.PriceChgProcDiv) resList.Add("PriceChgProcDiv");
            if (this.BLGoodsCdUpdDiv != target.BLGoodsCdUpdDiv) resList.Add("BLGoodsCdUpdDiv");     // 2009/12/11 Add
            
            return resList;
        }
        /// <summary>
        /// 価格改正設定クラス比較処理
        /// </summary>
        /// <param name="priceChgSet1">比較するPriceChgSetクラスのインスタンス</param>
        /// <param name="priceChgSet2">比較するPriceChgSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceChgSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PriceChgSet priceChgSet1, PriceChgSet priceChgSet2)
        {
            ArrayList resList = new ArrayList();
            if (priceChgSet1.CreateDateTime != priceChgSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (priceChgSet1.UpdateDateTime != priceChgSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (priceChgSet1.EnterpriseCode != priceChgSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (priceChgSet1.FileHeaderGuid != priceChgSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (priceChgSet1.UpdEmployeeCode != priceChgSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (priceChgSet1.UpdAssemblyId1 != priceChgSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (priceChgSet1.UpdAssemblyId2 != priceChgSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (priceChgSet1.LogicalDeleteCode != priceChgSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (priceChgSet1.NameUpdDiv != priceChgSet2.NameUpdDiv) resList.Add("NameUpdDiv");
            if (priceChgSet1.PartsLayerUpdDiv != priceChgSet2.PartsLayerUpdDiv) resList.Add("PartsLayerUpdDiv");
            if (priceChgSet1.PriceUpdDiv != priceChgSet2.PriceUpdDiv) resList.Add("PriceUpdDiv");
            if (priceChgSet1.OpenPriceDiv != priceChgSet2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            if (priceChgSet1.PriceMngCnt != priceChgSet2.PriceMngCnt) resList.Add("PriceMngCnt");
            if (priceChgSet1.PriceChgProcDiv != priceChgSet2.PriceChgProcDiv) resList.Add("PriceChgProcDiv");
            if (priceChgSet1.BLGoodsCdUpdDiv != priceChgSet2.BLGoodsCdUpdDiv) resList.Add("BLGoodsCdUpdDiv");   // 2009/12/11 Add
            
            return resList;
        }
    }

}
