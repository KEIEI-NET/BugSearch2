using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 ExtrInfo_MAMOK09137EA
    /// <summary>
    /// 					 商品別売上目標検索条件設定パラメータクラス
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 商品別売上目標検索条件設定パラメータファイル</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007/05/08</br>
	/// <br>Update Note		 :   2007.11.21 上野 弘貴</br>
	/// <br>                     流通.DC用に変更（項目追加・削除）</br>
	/// <br></br>
    /// </remarks>
    [Serializable]
    public class ExtrInfo_MAMOK09137EA
    {
        #region Private Member

        /// <summary>企業コード</summary>
        private String _enterpriseCode = "";

        /// <summary>選択拠点コード</summary>
        private String[] _selectSectCd;

        /// <summary>全社選択</summary>
        private Boolean _allSecSelEpUnit;

        /// <summary>全拠点レコード出力</summary>
        private Boolean _allSecSelSecUnit;

        /// <summary>目標設定区分</summary>
        private Int32 _targetSetCd;

        /// <summary>目標対比区分</summary>
        private Int32 _targetContrastCd;

        /// <summary>目標区分コード</summary>
        private String _targetDivideCode = "";

        /// <summary>目標区分名称</summary>
        private String _targetDivideName = "";

        /// <summary>適用開始日(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDateSt;

        /// <summary>適用開始日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDateEd;

        /// <summary>適用終了日(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDateSt;

        /// <summary>適用終了日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDateEd;

		//----- ueno del---------- start 2007.11.21
		///// <summary>キャリアコード</summary>
		//private Int32 _carrierCode = -1;

		///// <summary>機種コード</summary>
		//private string _cellphoneModelCode = "";
		//----- ueno del---------- end   2007.11.21

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode = -1;

        /// <summary>商品コード</summary>
        private String _goodsCode = "";

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

        /// public propaty name  :	EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 企業コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String EnterpriseCode
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

        /// public propaty name  :	SelectSectCd
        /// <summary>選択拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 選択拠点コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String[] SelectSectCd
        {
            get
            {
                return _selectSectCd;
            }
            set
            {
                _selectSectCd = value;
            }
        }

        /// public propaty name  :  AllSecSelEpUnit
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   NEPCO</br>
        /// </remarks>
        public Boolean AllSecSelEpUnit
        {
            get
            {
                return _allSecSelEpUnit;
            }
            set
            {
                _allSecSelEpUnit = value;
            }
        }

        /// public propaty name  :  AllSecSelSecUnit
        /// <summary>全拠点レコード出力プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点レコード出力プロパティ</br>
        /// <br>Programer        :   NEPCO</br>
        /// </remarks>
        public Boolean AllSecSelSecUnit
        {
            get
            {
                return _allSecSelSecUnit;
            }
            set
            {
                _allSecSelSecUnit = value;
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
        public String TargetDivideCode
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
        public String TargetDivideName
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

        /// public propaty name  :	ApplyStaDateSt
        /// <summary>適用開始日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDateSt
        {
            get
            {
                return _applyStaDateSt;
            }
            set
            {
                _applyStaDateSt = value;
            }
        }

        /// public propaty name  :	ApplyStaDateEd
        /// <summary>適用開始日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDateEd
        {
            get
            {
                return _applyStaDateEd;
            }
            set
            {
                _applyStaDateEd = value;
            }
        }

        /// public propaty name  :	ApplyStaDateSt
        /// <summary>適用終了日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDateSt
        {
            get
            {
                return _applyEndDateSt;
            }
            set
            {
                _applyEndDateSt = value;
            }
        }

        /// public propaty name  :	ApplyStaDateEd
        /// <summary>適用終了日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDateEd
        {
            get
            {
                return _applyEndDateEd;
            }
            set
            {
                _applyEndDateEd = value;
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

        /// public propaty name  :	GoodsCode
        /// <summary>商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 商品コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public String GoodsCode
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
        /// 売上月間目標設定マスタ検索条件コンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09157EAクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ExtrInfo_MAMOK09137EA()
        {
        }

        /// <summary>
        /// 売上月間目標設定マスタ検索条件コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="selectSectCd">選択拠点コード</param>
        /// <param name="allSecSelEpUnit">全社選択</param>
        /// <param name="allSecSelSecUnit">全拠点レコード出力</param>
        /// <param name="targetSetCd">目標設定区分</param>
        /// <param name="targetContrastCd">目標対比区分</param>
        /// <param name="targetDivideCode">目標区分コード</param>
        /// <param name="targetDivideName">目標区分名称</param>
        /// <param name="applyStaDateSt">適用開始日(YYYYMMDD)</param>
        /// <param name="applyStaDateEd">適用開始日(YYYYMMDD)</param>
        /// <param name="applyEndDateSt">適用終了日(YYYYMMDD)</param>
        /// <param name="applyEndDateEd">適用終了日(YYYYMMDD)</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09157EAクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ExtrInfo_MAMOK09137EA(
            String enterpriseCode,
            String[] selectSectCd,
            Boolean allSecSelEpUnit,
            Boolean allSecSelSecUnit,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            String targetDivideCode,
            String targetDivideName,
            DateTime applyStaDateSt,
            DateTime applyStaDateEd,
            DateTime applyEndDateSt,
            DateTime applyEndDateEd,
			//----- ueno del---------- start 2007.11.21
			//Int32 carrierCode,
            //String cellphoneModelCode,
			//----- ueno del---------- end 2007.11.21
            Int32 makerCode,
            String goodsCode,
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
            this._enterpriseCode = enterpriseCode;
            this._selectSectCd = selectSectCd;
            this._allSecSelEpUnit = allSecSelEpUnit;
            this._allSecSelSecUnit = allSecSelSecUnit;
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._applyStaDateSt = applyStaDateSt;
            this._applyStaDateEd = applyStaDateEd;
            this._applyEndDateSt = applyEndDateSt;
            this._applyEndDateEd = applyEndDateEd;
			//----- ueno del---------- start 2007.11.21
			//this._carrierCode = carrierCode;
            //this._cellphoneModelCode = cellphoneModelCode;
			//----- ueno del---------- end   2007.11.21            
            this._makerCode = makerCode;
            this._goodsCode = goodsCode;
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

        /// <summary>
        /// 売上月間目標設定マスタ検索条件複製処理
        /// </summary>
        /// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 自身の内容と等しいExtrInfo_MAMOK09157EAクラスのインスタンスを返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ExtrInfo_MAMOK09137EA Clone()
        {
            return new ExtrInfo_MAMOK09137EA(
                               this._enterpriseCode,
                               this._selectSectCd,
                               this._allSecSelEpUnit,
                               this._allSecSelSecUnit,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
                               this._applyStaDateSt,
                               this._applyStaDateEd,
                               this._applyEndDateSt,
                               this._applyEndDateEd,
							   //----- ueno del---------- start 2007.11.21
							   //this._carrierCode,
                               //this._cellphoneModelCode,
							   //----- ueno del---------- end   2007.11.21
                               this._makerCode,
                               this._goodsCode,
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

        /// <summary>
        /// 売上月間目標設定マスタ検索条件比較処理
        /// </summary>
        /// <param name="target">比較対象のExtrInfo_MAMOK09157EAクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09157EAクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(ExtrInfo_MAMOK09137EA target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SelectSectCd == target.SelectSectCd)
                 && (this.AllSecSelEpUnit == target.AllSecSelEpUnit)
                 && (this.AllSecSelSecUnit == target.AllSecSelSecUnit)
                 && (this.TargetSetCd == target.TargetSetCd)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.TargetDivideCode == target.TargetDivideCode)
                 && (this.TargetDivideName == target.TargetDivideName)
                 && (this.ApplyStaDateSt == target.ApplyStaDateSt)
                 && (this.ApplyStaDateEd == target.ApplyStaDateEd)
                 && (this.ApplyEndDateSt == target.ApplyEndDateSt)
                 && (this.ApplyEndDateEd == target.ApplyEndDateEd)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.CarrierCode == target.CarrierCode)
                 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
                 && (this.MakerCode == target.MakerCode)
                 && (this.GoodsCode == target.GoodsCode)
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

        #endregion Public Method

    }
}
