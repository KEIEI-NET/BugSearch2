using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 GcdSalesTarget
    /// <summary>
    /// 					 商品別売上目標設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 商品別売上目標設定マスタファイル</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007.05.08  (CSharp File Generated Date)</br>
	/// <br>Update Note		 :   2007.11.21 上野 弘貴</br>
	/// <br>                     流通.DC用に変更（項目追加・削除）</br>
    /// <br></br>
    /// </remarks>
    public class GcdSalesTarget
    {
        #region Private Member

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
        private string _sectionCode = "";

        /// <summary>目標設定区分</summary>
        private Int32 _targetSetCd;

        /// <summary>目標対比区分</summary>
        private Int32 _targetContrastCd;

        /// <summary>目標区分コード</summary>
        private string _targetDivideCode = "";

        /// <summary>目標区分名称</summary>
        private string _targetDivideName = "";

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

		//----- ueno del---------- start 2007.11.21
		///// <summary>キャリアコード</summary>
		//private Int32 _carrierCode;

		///// <summary>キャリア名称</summary>
		//private string _carrierName = "";

		///// <summary>機種コード</summary>
		//private string _cellphoneModelCode = "";

		///// <summary>機種名称</summary>
		//private string _cellphoneModelName = "";
		//----- ueno del---------- end   2007.11.21

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品コード</summary>
        private string _goodsCode = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>売上目標金額</summary>
        private Int64 _gcdSalesTargetMoney;

        /// <summary>売上目標粗利額</summary>
        private Int64 _gcdSalesTargetProfit;

        /// <summary>売上目標数量</summary>
        private Double _gcdSalesTargetCount;

		//----- ueno del---------- start 2007.11.21
		///// <summary>平日比率</summary>
		//private Double _weekdayRatio;

		///// <summary>土日比率</summary>
		//private Double _satSunRatio;
		//----- ueno del---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        // BLグループコード
        private Int32 _bLGroupCode;
        // BLグループ名
        private string _bLGroupName;
        // BLコード
        private Int32 _bLGoodsCode;
        // BLコード名
        private string _bLCodeName;
        // 販売区分
        private Int32 _salesCode;
        // 販売区分名
        private string _salesCdNm;
        // 商品区分
        private Int32 _enterpriseGanreCode;
        // 商品区分名
        private string _enterpriseGanreName;

        // 業種名
        private string _businessTypeName;
        // 販売エリア名
        private string _salesAreaName;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 作成日時プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get
            {
                return _createDateTime;
            }
            set
            {
                _createDateTime = value;
            }
        }

        /// public propaty name  :	CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 作成日時 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 作成日時 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 作成日時 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 作成日時 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新日時プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get
            {
                return _updateDateTime;
            }
            set
            {
                _updateDateTime = value;
            }
        }

        /// public propaty name  :	UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新日時 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新日時 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新日時 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新日時 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 企業コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get
            {
                return _enterpriseCode;
            }
            set
            {
                _enterpriseCode = value;
            }
        }

        /// public propaty name  :	FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 GUIDプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get
            {
                return _fileHeaderGuid;
            }
            set
            {
                _fileHeaderGuid = value;
            }
        }

        /// public propaty name  :	UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新従業員コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get
            {
                return _updEmployeeCode;
            }
            set
            {
                _updEmployeeCode = value;
            }
        }

        /// public propaty name  :	UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新アセンブリID1プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get
            {
                return _updAssemblyId1;
            }
            set
            {
                _updAssemblyId1 = value;
            }
        }

        /// public propaty name  :	UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 更新アセンブリID2プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get
            {
                return _updAssemblyId2;
            }
            set
            {
                _updAssemblyId2 = value;
            }
        }

        /// public propaty name  :	LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 論理削除区分プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get
            {
                return _logicalDeleteCode;
            }
            set
            {
                _logicalDeleteCode = value;
            }
        }

        /// public propaty name  :	SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 拠点コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SectionCode
        {
            get
            {
                return _sectionCode;
            }
            set
            {
                _sectionCode = value;
            }
        }

        /// public propaty name  :	TargetSetCd
        /// <summary>目標設定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標設定区分プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get
            {
                return _targetSetCd;
            }
            set
            {
                _targetSetCd = value;
            }
        }

        /// public propaty name  :	TargetContrastCd
        /// <summary>目標対比区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標対比区分プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get
            {
                return _targetContrastCd;
            }
            set
            {
                _targetContrastCd = value;
            }
        }

        /// public propaty name  :	TargetDivideCode
        /// <summary>目標区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標区分コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get
            {
                return _targetDivideCode;
            }
            set
            {
                _targetDivideCode = value;
            }
        }

        /// public propaty name  :	TargetDivideName
        /// <summary>目標区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標区分名称プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string TargetDivideName
        {
            get
            {
                return _targetDivideName;
            }
            set
            {
                _targetDivideName = value;
            }
        }

        /// public propaty name  :	ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get
            {
                return _applyStaDate;
            }
            set
            {
                _applyStaDate = value;
            }
        }

        /// public propaty name  :	ApplyStaDateJpFormal
        /// <summary>適用開始日 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateJpInFormal
        /// <summary>適用開始日 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateAdFormal
        /// <summary>適用開始日 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateAdInFormal
        /// <summary>適用開始日 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get
            {
                return _applyEndDate;
            }
            set
            {
                _applyEndDate = value;
            }
        }

        /// public propaty name  :	ApplyEndDateJpFormal
        /// <summary>適用終了日 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateJpInFormal
        /// <summary>適用終了日 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateAdFormal
        /// <summary>適用終了日 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateAdInFormal
        /// <summary>適用終了日 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用終了日 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

		//----- ueno del---------- start 2007.11.21
		///// public propaty name  :	CarrierCode
		///// <summary>キャリアコードプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 従業員コードプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int32 CarrierCode
		//{
		//    get
		//    {
		//        return _carrierCode;
		//    }
		//    set
		//    {
		//        _carrierCode = value;
		//    }
		//}

		///// public propaty name  :	CarrierName
		///// <summary>キャリア名称プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 キャリア名称プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CarrierName
		//{
		//    get
		//    {
		//        return _carrierName;
		//    }
		//    set
		//    {
		//        _carrierName = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelCode
		///// <summary>機種コードプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 機種コードプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelCode
		//{
		//    get
		//    {
		//        return _cellphoneModelCode;
		//    }
		//    set
		//    {
		//        _cellphoneModelCode = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelName
		///// <summary>機種名称プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 機種名称プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelName
		//{
		//    get
		//    {
		//        return _cellphoneModelName;
		//    }
		//    set
		//    {
		//        _cellphoneModelName = value;
		//    }
		//}
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 メーカーコードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get
            {
                return _makerCode;
            }
            set
            {
                _makerCode = value;
            }
        }

        /// public propaty name  :	MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 メーカー名称プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string MakerName
        {
            get
            {
                return _makerName;
            }
            set
            {
                _makerName = value;
            }
        }

        /// public propaty name  :	GoodsCode
        /// <summary>商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 商品コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string GoodsCode
        {
            get
            {
                return _goodsCode;
            }
            set
            {
                _goodsCode = value;
            }
        }

        /// public propaty name  :	GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 商品名称プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string GoodsName
        {
            get
            {
                return _goodsName;
            }
            set
            {
                _goodsName = value;
            }
        }

        /// public propaty name  :	GcdSalesTargetMoney
        /// <summary>売上目標金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	売上目標金額プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 GcdSalesTargetMoney
        {
            get
            {
                return _gcdSalesTargetMoney;
            }
            set
            {
                _gcdSalesTargetMoney = value;
            }
        }

        /// public propaty name  :	GcdSalesTargetProfit
        /// <summary>売上目標粗利額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上目標粗利額プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 GcdSalesTargetProfit
        {
            get
            {
                return _gcdSalesTargetProfit;
            }
            set
            {
                _gcdSalesTargetProfit = value;
            }
        }

        /// public propaty name  :	GcdSalesTargetCount
        /// <summary>売上目標数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上目標数量プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Double GcdSalesTargetCount
        {
            get
            {
                return _gcdSalesTargetCount;
            }
            set
            {
                _gcdSalesTargetCount = value;
            }
        }

		//----- ueno del---------- start 2007.11.21
		///// public propaty name  :	WeekdayRatio
		///// <summary>平日比率プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 平日比率プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Double WeekdayRatio
		//{
		//    get
		//    {
		//        return _weekdayRatio;
		//    }
		//    set
		//    {
		//        _weekdayRatio = value;
		//    }
		//}

		///// public propaty name  :	SatSunRatio
		///// <summary>土日比率プロパティ</summary>
		///// <value>時刻（時間、分）商品入荷予定日</value>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 土日比率プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Double SatSunRatio
		//{
		//    get
		//    {
		//        return _satSunRatio;
		//    }
		//    set
		//    {
		//        _satSunRatio = value;
		//    }
		//}
		//----- ueno del---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { this._bLGroupCode = value; }
        }
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { this._bLGroupName = value; }
        }

        public Int32 BLCode
        {
            get { return _bLGoodsCode; }
            set { this._bLGoodsCode = value; }
        }

        public string BLCodeName
        {
            get { return _bLCodeName; }
            set { this._bLCodeName = value; }
        }

        public Int32 SalesTypeCode
        {
            get { return _salesCode; }
            set { this._salesCode = value; }
        }

        public string SalesTypeName
        {
            get { return _salesCdNm; }
            set { this._salesCdNm = value; }
        }

        public Int32 ItemTypeCode
        {
            get { return _enterpriseGanreCode; }
            set { this._enterpriseGanreCode = value; }
        }

        public string ItemTypeName
        {
            get { return _enterpriseGanreName; }
            set { this._enterpriseGanreName = value; }
        }

        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { this._businessTypeName = value; }
        }

        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { this._salesAreaName = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

        #endregion Public Propaty

        #region コンストラクタ
        /// <summary>
        /// 売上目標設定マスタコンストラクタ
        /// </summary>
        /// <returns>GcdSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 GcdSalesTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public GcdSalesTarget()
        {
        }

        /// <summary>
        /// 売上目標設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="targetSetCd">目標設定区分</param>
        /// <param name="targetContrastCd">目標対比区分</param>
        /// <param name="targetDivideCode">目標区分コード</param>
        /// <param name="targetDivideName">目標区分名称</param>
        /// <param name="applyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="applyEndDate">適用終了日(YYYYMMDD)</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="gcdSalesTargetMoney">売上目標金額</param>
        /// <param name="gcdSalesTargetProfit">売上目標粗利額</param>
        /// <param name="gcdSalesTargetCount">売上目標数量</param>
        /// <returns>GcdSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 GcdSalesTargetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public GcdSalesTarget(
            DateTime createDateTime,
            DateTime updateDateTime,
            string enterpriseCode,
            Guid fileHeaderGuid,
            string updEmployeeCode,
            string updAssemblyId1,
            string updAssemblyId2,
            Int32 logicalDeleteCode,
            string sectionCode,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            string targetDivideCode,
            string targetDivideName,
            DateTime applyStaDate,
            DateTime applyEndDate,
			//----- ueno del---------- start 2007.11.21
            //Int32 carrierCode,
            //string carrierName,
            //string cellphoneModelCode,
            //string cellphoneModelName,
			//----- ueno del---------- end   2007.11.21
            Int32 makerCode,
            string makerName,
            string goodsCode,
            string goodsName,
            Int64 gcdSalesTargetMoney,
            Int64 gcdSalesTargetProfit,
            Double gcdSalesTargetCount,
			//----- ueno del---------- start 2007.11.21
			//Double weekdayRatio,
            //Double satSunRatio
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            Int32 blGroupCode,
            string blGroupName,
            Int32 blCode,
            string blCodeName,
            Int32 salesTypeCode,
            string salesTypeName,
            Int32 itemTypeCode,
            string itemTypeName,
            string businessTypeName,
            string salesAreaName
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
			)
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
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
			//----- ueno del---------- start 2007.11.21
			//this._carrierCode = carrierCode;
            //this._carrierName = carrierName;
            //this._cellphoneModelCode = cellphoneModelCode;
            //this._cellphoneModelName = cellphoneModelName;
			//----- ueno del---------- end   2007.11.21
            this._makerCode = makerCode;
            this._makerName = makerName;
            this._goodsCode = goodsCode;
            this._goodsName = goodsName;
            this._gcdSalesTargetMoney = gcdSalesTargetMoney;
            this._gcdSalesTargetProfit = gcdSalesTargetProfit;
            this._gcdSalesTargetCount = gcdSalesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//this._weekdayRatio = weekdayRatio;
            //this._satSunRatio = satSunRatio;
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            this._bLGroupCode = blGroupCode;
            this._bLGroupName = blGroupName;
            this._bLGoodsCode = blCode;
            this._bLCodeName = blCodeName;
            this._salesCode = salesTypeCode;
            this._salesCdNm = salesTypeName;
            this._enterpriseGanreCode = itemTypeCode;
            this._enterpriseGanreName = itemTypeName;
            this._businessTypeName = businessTypeName;
            this._salesAreaName = salesAreaName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
		}

        #endregion コンストラクタ

        #region Public Method
        #region ◆　売上目標設定マスタ複製処理
        /// <summary>
        /// 売上目標設定マスタ複製処理
        /// </summary>
        /// <returns>GcdSalesTargetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 自身の内容と等しいGcdSalesTargetクラスのインスタンスを返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public GcdSalesTarget Clone()
        {
            return new GcdSalesTarget(this._createDateTime,
                               this._updateDateTime,
                               this._enterpriseCode,
                               this._fileHeaderGuid,
                               this._updEmployeeCode,
                               this._updAssemblyId1,
                               this._updAssemblyId2,
                               this._logicalDeleteCode,
                               this._sectionCode,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
                               this._applyStaDate,
                               this._applyEndDate,
							   //----- ueno del---------- start 2007.11.21
							   //this._carrierCode,
                               //this._carrierName,
                               //this._cellphoneModelCode,
                               //this._cellphoneModelName,
							   //----- ueno del---------- end   2007.11.21
                               this._makerCode,
                               this._makerName,
                               this._goodsCode,
                               this._goodsName,
                               this._gcdSalesTargetMoney,
                               this._gcdSalesTargetProfit,
                               this._gcdSalesTargetCount,
							   //----- ueno del---------- start 2007.11.21
							   //this._weekdayRatio,
                               //this._satSunRatio
							   //----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                               this._bLGroupCode,
                               this._bLGroupName,
                               this._bLGoodsCode,
                               this._bLCodeName,
                               this._salesCode,
                               this._salesCdNm,
                               this._enterpriseGanreCode,
                               this._enterpriseGanreName,
                               this._businessTypeName,
                               this._salesAreaName
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
							   );
        }
        #endregion ◆　売上目標設定マスタ複製処理

        #region ◆　売上目標設定マスタ比較処理(GcdSalesTarget)
        /// <summary>
        /// 売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のGcdSalesTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 GcdSalesTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(GcdSalesTarget target)
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
                 && (this.TargetSetCd == target.TargetSetCd)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.TargetDivideCode == target.TargetDivideCode)
                 && (this.TargetDivideName == target.TargetDivideName)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.CarrierCode == target.CarrierCode)
                 //&& (this.CarrierName == target.CarrierName)
                 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
                 //&& (this.CellphoneModelName == target.CellphoneModelName)
				 //----- ueno del---------- end   2007.11.21
                 && (this.MakerCode == target.MakerCode)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GcdSalesTargetMoney == target.GcdSalesTargetMoney)
                 && (this.GcdSalesTargetProfit == target.GcdSalesTargetProfit)
                 && (this.GcdSalesTargetCount == target.GcdSalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.WeekdayRatio == target.WeekdayRatio)
                 //&& (this.SatSunRatio == target.SatSunRatio)
				 //----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLCode == target.BLCode)
                 && (this.BLCodeName == target.BLCodeName)
                 && (this.SalesTypeCode == target.SalesTypeCode)
                 && (this.SalesTypeName == target.SalesTypeName)
                 && (this.ItemTypeCode == target.ItemTypeCode)
                 && (this.ItemTypeName == target.ItemTypeName)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaName == target.SalesAreaName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
        }
        #endregion ◆　売上目標設定マスタ比較処理

        #region ◆　売上目標設定マスタ比較処理(GcdSalesTarget,ResvdDT)
        /// <summary>
        /// 売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   比較するGcdSalesTargetクラスのインスタンス
        /// </param>
        /// <param name="salesMonTarget2">比較するGcdSalesTargetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 GcdSalesTargetクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static bool Equals(GcdSalesTarget salesMonTarget1, GcdSalesTarget salesMonTarget2)
        {
            return ((salesMonTarget1.CreateDateTime == salesMonTarget2.CreateDateTime)
                 && (salesMonTarget1.UpdateDateTime == salesMonTarget2.UpdateDateTime)
                 && (salesMonTarget1.EnterpriseCode == salesMonTarget2.EnterpriseCode)
                 && (salesMonTarget1.FileHeaderGuid == salesMonTarget2.FileHeaderGuid)
                 && (salesMonTarget1.UpdEmployeeCode == salesMonTarget2.UpdEmployeeCode)
                 && (salesMonTarget1.UpdAssemblyId1 == salesMonTarget2.UpdAssemblyId1)
                 && (salesMonTarget1.UpdAssemblyId2 == salesMonTarget2.UpdAssemblyId2)
                 && (salesMonTarget1.LogicalDeleteCode == salesMonTarget2.LogicalDeleteCode)
                 && (salesMonTarget1.SectionCode == salesMonTarget2.SectionCode)
                 && (salesMonTarget1.TargetSetCd == salesMonTarget2.TargetSetCd)
                 && (salesMonTarget1.TargetContrastCd == salesMonTarget2.TargetContrastCd)
                 && (salesMonTarget1.TargetDivideCode == salesMonTarget2.TargetDivideCode)
                 && (salesMonTarget1.TargetDivideName == salesMonTarget2.TargetDivideName)
                 && (salesMonTarget1.ApplyStaDate == salesMonTarget2.ApplyStaDate)
                 && (salesMonTarget1.ApplyEndDate == salesMonTarget2.ApplyEndDate)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.CarrierCode == salesMonTarget2.CarrierCode)
                 //&& (salesMonTarget1.CarrierName == salesMonTarget2.CarrierName)
                 //&& (salesMonTarget1.CellphoneModelCode == salesMonTarget2.CellphoneModelCode)
                 //&& (salesMonTarget1.CellphoneModelName == salesMonTarget2.CellphoneModelName)
				 //----- ueno del---------- start 2007.11.21
                 && (salesMonTarget1.MakerCode == salesMonTarget2.MakerCode)
                 && (salesMonTarget1.MakerName == salesMonTarget2.MakerName)
                 && (salesMonTarget1.GoodsCode == salesMonTarget2.GoodsCode)
                 && (salesMonTarget1.GoodsName == salesMonTarget2.GoodsName)
                 && (salesMonTarget1.GcdSalesTargetMoney == salesMonTarget2.GcdSalesTargetMoney)
                 && (salesMonTarget1.GcdSalesTargetProfit == salesMonTarget2.GcdSalesTargetProfit)
                 && (salesMonTarget1.GcdSalesTargetCount == salesMonTarget2.GcdSalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.WeekdayRatio == salesMonTarget2.WeekdayRatio)
                 //&& (salesMonTarget1.SatSunRatio == salesMonTarget2.SatSunRatio)
				 //----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (salesMonTarget1.BLGroupCode == salesMonTarget2.BLGroupCode)
                 && (salesMonTarget1.BLGroupName == salesMonTarget2.BLGroupName)
                 && (salesMonTarget1.BLCode == salesMonTarget2.BLCode)
                 && (salesMonTarget1.BLCodeName == salesMonTarget2.BLCodeName)
                 && (salesMonTarget1.SalesTypeCode == salesMonTarget2.SalesTypeCode)
                 && (salesMonTarget1.SalesTypeName == salesMonTarget2.SalesTypeName)
                 && (salesMonTarget1.ItemTypeCode == salesMonTarget2.ItemTypeCode)
                 && (salesMonTarget1.ItemTypeName == salesMonTarget2.ItemTypeName)
                 && (salesMonTarget1.BusinessTypeName == salesMonTarget2.BusinessTypeName)
                 && (salesMonTarget1.SalesAreaName == salesMonTarget2.SalesAreaName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
        }
        #endregion ◆　売上目標設定マスタ比較処理(GcdSalesTarget,ResvdDT)

        #region ◆　売上目標設定マスタ比較結果リスト作成処理(GcdSalesTarget)
        /// <summary>
        /// 売上目標設定マスタ比較結果リスト作成処理
        /// </summary>
        /// <param name="target">比較対象のGcdSalesTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 GcdSalesTargetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ArrayList Compare(GcdSalesTarget target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TargetSetCd != target.TargetSetCd) resList.Add("TargetSetCd");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.TargetDivideCode != target.TargetDivideCode) resList.Add("TargetDivideCode");
            if (this.TargetDivideName != target.TargetDivideName) resList.Add("TargetDivideName");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
			//----- ueno del---------- start 2007.11.21
			//if (this.CarrierCode != target.CarrierCode) resList.Add("CarrierCode");
            //if (this.CarrierName != target.CarrierName) resList.Add("CarrierName");
            //if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
            //if (this.CellphoneModelName != target.CellphoneModelName) resList.Add("CellphoneModelName");
			//----- ueno del---------- end   2007.11.21           
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsCode != target.GoodsCode) resList.Add("GoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GcdSalesTargetMoney != target.GcdSalesTargetMoney) resList.Add("GcdSalesTargetMoney");
            if (this.GcdSalesTargetProfit != target.GcdSalesTargetProfit) resList.Add("GcdSalesTargetProfit");
            if (this.GcdSalesTargetCount != target.GcdSalesTargetCount) resList.Add("GcdSalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (this.WeekdayRatio != target.WeekdayRatio) resList.Add("WeekdayRatio");
            //if (this.SatSunRatio != target.SatSunRatio) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLCode != target.BLCode) resList.Add("BLCode");
            if (this.BLCodeName != target.BLCodeName) resList.Add("BLCodeName");
            if (this.SalesTypeCode != target.SalesTypeCode) resList.Add("SalesTypeCode");
            if (this.SalesTypeName != target.SalesTypeName) resList.Add("SalesTypeName");
            if (this.ItemTypeCode != target.ItemTypeCode) resList.Add("ItemTypeCode");
            if (this.ItemTypeName != target.ItemTypeName) resList.Add("ItemTypeName");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

            return resList;
        }
        #endregion ◆　売上目標設定マスタ比較結果リスト作成処理(GcdSalesTarget)

        #region ◆　売上目標設定マスタ比較結果リスト作成処理(GcdSalesTarget,GcdSalesTarget)
        /// <summary>
        /// 売上目標設定マスタ比較処理
        /// </summary>
        /// <param name="salesMonTarget1">比較するGcdSalesTargetクラスのインスタンス</param>
        /// <param name="salesMonTarget2">比較するGcdSalesTargetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 GcdSalesTargetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static ArrayList Compare(GcdSalesTarget salesMonTarget1, GcdSalesTarget salesMonTarget2)
        {
            ArrayList resList = new ArrayList();
            if (salesMonTarget1.CreateDateTime != salesMonTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesMonTarget1.UpdateDateTime != salesMonTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesMonTarget1.EnterpriseCode != salesMonTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesMonTarget1.FileHeaderGuid != salesMonTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesMonTarget1.UpdEmployeeCode != salesMonTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesMonTarget1.UpdAssemblyId1 != salesMonTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesMonTarget1.UpdAssemblyId2 != salesMonTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesMonTarget1.LogicalDeleteCode != salesMonTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesMonTarget1.SectionCode != salesMonTarget2.SectionCode) resList.Add("SectionCode");
            if (salesMonTarget1.TargetSetCd != salesMonTarget2.TargetSetCd) resList.Add("TargetSetCd");
            if (salesMonTarget1.TargetContrastCd != salesMonTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (salesMonTarget1.TargetDivideCode != salesMonTarget2.TargetDivideCode) resList.Add("TargetDivideCode");
            if (salesMonTarget1.TargetDivideName != salesMonTarget2.TargetDivideName) resList.Add("TargetDivideName");
            if (salesMonTarget1.ApplyStaDate != salesMonTarget2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (salesMonTarget1.ApplyEndDate != salesMonTarget2.ApplyEndDate) resList.Add("ApplyEndDate");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.CarrierCode != salesMonTarget2.CarrierCode) resList.Add("CarrierCode");
			//if (salesMonTarget1.CarrierName != salesMonTarget2.CarrierName) resList.Add("CarrierName");
			//if (salesMonTarget1.CellphoneModelCode != salesMonTarget2.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//if (salesMonTarget1.CellphoneModelName != salesMonTarget2.CellphoneModelName) resList.Add("CellphoneModelName");
			//----- ueno del---------- end   2007.11.21           
            if (salesMonTarget1.MakerCode != salesMonTarget2.MakerCode) resList.Add("MakerCode");
            if (salesMonTarget1.MakerName != salesMonTarget2.MakerName) resList.Add("MakerName");
            if (salesMonTarget1.GoodsCode != salesMonTarget2.GoodsCode) resList.Add("GoodsCode");
            if (salesMonTarget1.GoodsName != salesMonTarget2.GoodsName) resList.Add("GoodsName");
            if (salesMonTarget1.GcdSalesTargetMoney != salesMonTarget2.GcdSalesTargetMoney) resList.Add("GcdSalesTargetMoney");
            if (salesMonTarget1.GcdSalesTargetProfit != salesMonTarget2.GcdSalesTargetProfit) resList.Add("GcdSalesTargetProfit");
            if (salesMonTarget1.GcdSalesTargetCount != salesMonTarget2.GcdSalesTargetCount) resList.Add("GcdSalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.WeekdayRatio != salesMonTarget2.WeekdayRatio) resList.Add("WeekdayRatio");
            //if (salesMonTarget1.SatSunRatio != salesMonTarget2.SatSunRatio) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            if (salesMonTarget1.BLGroupCode != salesMonTarget2.BLGroupCode) resList.Add("BLGroupCode");
            if (salesMonTarget1.BLGroupName != salesMonTarget2.BLGroupName) resList.Add("BLGroupName");
            if (salesMonTarget1.BLCode != salesMonTarget2.BLCode) resList.Add("BLCode");
            if (salesMonTarget1.BLCodeName != salesMonTarget2.BLCodeName) resList.Add("BLCodeName");
            if (salesMonTarget1.SalesTypeCode != salesMonTarget2.SalesTypeCode) resList.Add("SalesTypeCode");
            if (salesMonTarget1.SalesTypeName != salesMonTarget2.SalesTypeName) resList.Add("SalesTypeName");
            if (salesMonTarget1.ItemTypeCode != salesMonTarget2.ItemTypeCode) resList.Add("ItemTypeCode");
            if (salesMonTarget1.ItemTypeName != salesMonTarget2.ItemTypeName) resList.Add("ItemTypeName");
            if (salesMonTarget1.BusinessTypeName != salesMonTarget2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (salesMonTarget1.SalesAreaName != salesMonTarget2.SalesAreaName) resList.Add("SalesAreaName");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

            return resList;
        }
        #endregion ◆　売上目標設定マスタ比較結果リスト作成処理(GcdSalesTarget,GcdSalesTarget)

        #endregion Public Method
    }
}
