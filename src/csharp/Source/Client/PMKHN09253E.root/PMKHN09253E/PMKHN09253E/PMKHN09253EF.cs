using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 SearchGcdSalesTargetPara
    /// <summary>
    /// 					 商品別売上目標検索条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 商品別売上目標検索条件ファイル</br>
    /// <br>Programmer		 :	 30414 忍 幸史</br>
    /// <br>Date			 :	 2008/10/08</br>
    /// <br></br>
    /// </remarks>
    public class SearchGcdSalesTargetPara
    {
        #region Private Member

        /// <summary>企業コード</summary>
        private String _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        private Int32 _logicalDeleteCode;

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
        private DateTime _startApplyStaDate;

        /// <summary>適用開始日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyStaDate;

        /// <summary>適用終了日(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _startApplyEndDate;

        /// <summary>適用終了日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _endApplyEndDate;

        /// <summary>BLコード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>グループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>品番</summary>
        private String _goodsNo;

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 企業コードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 論理削除区分プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	SelectSectCd
        /// <summary>選択拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 選択拠点コードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	AllSecSelEpUnit
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 全社選択プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	AllSecSelSecUnit
        /// <summary>全拠点レコード出力プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 全拠点レコード出力プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
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

        /// public propaty name  :	StartApplyStaDate
        /// <summary>適用開始日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime StartApplyStaDate
        {
            get
            {
                return _startApplyStaDate;
            }
            set
            {
                _startApplyStaDate = value;
            }
        }

        /// public propaty name  :	EndApplyStaDate
        /// <summary>適用開始日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime EndApplyStaDate
        {
            get
            {
                return _endApplyStaDate;
            }
            set
            {
                _endApplyStaDate = value;
            }
        }

        /// public propaty name  :	StartApplyStaDate
        /// <summary>適用終了日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime StartApplyEndDate
        {
            get
            {
                return _startApplyEndDate;
            }
            set
            {
                _startApplyEndDate = value;
            }
        }

        /// public propaty name  :	EndApplyStaDate
        /// <summary>適用終了日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 適用開始日プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public DateTime EndApplyEndDate
        {
            get
            {
                return _endApplyEndDate;
            }
            set
            {
                _endApplyEndDate = value;
            }
        }

        /// public propaty name  :	BLGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 BLコードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get
            {
                return _bLGoodsCode;
            }
            set
            {
                _bLGoodsCode = value;
            }
        }

        /// public propaty name  :	BLGroupCode
        /// <summary>グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 グループコードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get
            {
                return _bLGroupCode;
            }
            set
            {
                _bLGroupCode = value;
            }
        }

        /// public propaty name  :	GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 メーカーコードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get
            {
                return _goodsMakerCd;
            }
            set
            {
                _goodsMakerCd = value;
            }
        }

        /// public propaty name  :	GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 品番プロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public String GoodsNo
        {
            get
            {
                return _goodsNo;
            }
            set
            {
                _goodsNo = value;
            }
        }

        /// public propaty name  :	EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 自社分類コードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get
            {
                return _enterpriseGanreCode;
            }
            set
            {
                _enterpriseGanreCode = value;
            }
        }

        /// public propaty name  :	SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 販売区分コードプロパティ</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get
            {
                return _salesCode;
            }
            set
            {
                _salesCode = value;
            }
        }

        #endregion Public Propaty

        #region コンストラクタ
        /// <summary>
        /// 商品別売上目標検索条件コンストラクタ
        /// </summary>
        /// <returns>SearchGcdSalesTargetParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 SearchGcdSalesTargetParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public SearchGcdSalesTargetPara()
        {
        }


        /// <summary>
        /// 商品別売上目標検索条件コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="selectSectCd">選択拠点コード</param>
        /// <param name="allSecSelEpUnit">全社選択</param>
        /// <param name="allSecSelSecUnit">全拠点レコード出力</param>
        /// <param name="targetSetCd">目標設定区分</param>
        /// <param name="targetContrastCd">目標対比区分</param>
        /// <param name="targetDivideCode">目標区分コード</param>
        /// <param name="targetDivideName">目標区分名称</param>
        /// <param name="startApplyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="endApplyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="startApplyEndDate">適用終了日(YYYYMMDD)</param>
        /// <param name="endApplyEndDate">適用終了日(YYYYMMDD)</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="bLGroupCode">グループコード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        /// <param name="salesCode">販売区分コード</param>
        /// <returns>SearchGcdSalesTargetParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 SearchGcdSalesTargetParaクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public SearchGcdSalesTargetPara(
            String enterpriseCode,
            Int32 logicalDeleteCode,
            String[] selectSectCd,
            Boolean allSecSelEpUnit,
            Boolean allSecSelSecUnit,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            String targetDivideCode,
            String targetDivideName,
            DateTime startApplyStaDate,
            DateTime endApplyStaDate,
            DateTime startApplyEndDate,
            DateTime endApplyEndDate,
            Int32 bLGoodsCode,
            Int32 bLGroupCode,
            Int32 goodsMakerCd,
            String goodsNo,
            Int32 enterpriseGanreCode,
            Int32 salesCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._selectSectCd = selectSectCd;
            this._allSecSelEpUnit = allSecSelEpUnit;
            this._allSecSelSecUnit = allSecSelSecUnit;
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._startApplyStaDate = startApplyStaDate;
            this._endApplyStaDate = endApplyStaDate;
            this._startApplyEndDate = startApplyEndDate;
            this._endApplyEndDate = endApplyEndDate;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGroupCode = bLGroupCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._salesCode = salesCode;
        }

        #endregion コンストラクタ

        #region Public Method

        /// <summary>
        /// 商品別売上目標検索条件複製処理
        /// </summary>
        /// <returns>SearchGcdSalesTargetParaクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 自身の内容と等しいSearchGcdSalesTargetParaクラスのインスタンスを返します</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public SearchGcdSalesTargetPara Clone()
        {
            return new SearchGcdSalesTargetPara(
                               this._enterpriseCode,
                               this._logicalDeleteCode,
                               this._selectSectCd,
                               this._allSecSelEpUnit,
                               this._allSecSelSecUnit,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
                               this._startApplyStaDate,
                               this._endApplyStaDate,
                               this._startApplyEndDate,
                               this._endApplyEndDate,
                               this._bLGoodsCode,
                               this._bLGroupCode,
                               this._goodsMakerCd,
                               this._goodsNo,
                               this._enterpriseGanreCode,
                               this._salesCode);
        }

        /// <summary>
        /// 商品別売上目標検索条件比較処理
        /// </summary>
        /// <param name="target">比較対象のSearchGcdSalesTargetParaクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 SearchGcdSalesTargetParaクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 30414 忍 幸史</br>
        /// <br>Date			 :	 2008/10/08</br>
        /// </remarks>
        public bool Equals(SearchGcdSalesTargetPara target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                    && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                    && (this.SelectSectCd == target.SelectSectCd)
                    && (this.AllSecSelEpUnit == target.AllSecSelEpUnit)
                    && (this.AllSecSelSecUnit == target.AllSecSelSecUnit)
                    && (this.TargetSetCd == target.TargetSetCd)
                    && (this.TargetContrastCd == target.TargetContrastCd)
                    && (this.TargetDivideCode == target.TargetDivideCode)
                    && (this.TargetDivideName == target.TargetDivideName)
                    && (this.StartApplyStaDate == target.StartApplyStaDate)
                    && (this.EndApplyStaDate == target.EndApplyStaDate)
                    && (this.StartApplyEndDate == target.StartApplyEndDate)
                    && (this.EndApplyEndDate == target.EndApplyEndDate)
                    && (this.BLGoodsCode == target.BLGoodsCode)
                    && (this.BLGroupCode == target.BLGroupCode)
                    && (this.GoodsMakerCd == target.GoodsMakerCd)
                    && (this.GoodsNo == target.GoodsNo)
                    && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                    && (this.SalesCode == target.SalesCode));
        }

        #endregion Public Method

    }
}
