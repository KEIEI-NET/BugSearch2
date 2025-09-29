using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchGcdSalesTargetParaWork
    /// <summary>
    ///                      商品別売上目標設定検索ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品別売上目標設定検索ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchGcdSalesTargetParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>全拠点選択（企業単位）</summary>
        /// <remarks>true：全拠点選択（企業単位）　false：個別拠点選択</remarks>
        private Boolean _allSecSelEpUnit;

        /// <summary>全拠点選択（拠点単位）</summary>
        /// <remarks>true：全拠点選択（拠点単位）　false：個別拠点選択</remarks>
        private Boolean _allSecSelSecUnit;

        /// <summary>拠点コード</summary>
        /// <remarks>配列で複数拠点指定　全拠点の場合はNULL</remarks>
        private String[] _selectSectCd;

        /// <summary>目標設定区分</summary>
        /// <remarks>10：月間目標,20：個別期間目標</remarks>
        private Int32 _targetSetCd;

        /// <summary>目標対比区分</summary>
        /// <remarks>10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品</remarks>
        private Int32 _targetContrastCd;

        /// <summary>目標区分コード</summary>
        /// <remarks>月間目標：YYYYMM、個別期間目標：任意コード</remarks>
        private string _targetDivideCode = "";

        /// <summary>目標区分名称</summary>
        private string _targetDivideName = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>適用開始日(開始）</summary>
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

        /// public propaty name  :  AllSecSelEpUnit
        /// <summary>全拠点選択（企業単位）プロパティ</summary>
        /// <value>true：全拠点選択（企業単位）　false：個別拠点選択</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点選択（企業単位）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean AllSecSelEpUnit
        {
            get { return _allSecSelEpUnit; }
            set { _allSecSelEpUnit = value; }
        }

        /// public propaty name  :  AllSecSelSecUnit
        /// <summary>全拠点選択（拠点単位）プロパティ</summary>
        /// <value>true：全拠点選択（拠点単位）　false：個別拠点選択</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点選択（拠点単位）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean AllSecSelSecUnit
        {
            get { return _allSecSelSecUnit; }
            set { _allSecSelSecUnit = value; }
        }

        /// public propaty name  :  SelectSectCd
        /// <summary>拠点コードプロパティ</summary>
        /// <value>配列で複数拠点指定　全拠点の場合はNULL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String[] SelectSectCd
        {
            get { return _selectSectCd; }
            set { _selectSectCd = value; }
        }

        /// public propaty name  :  TargetSetCd
        /// <summary>目標設定区分プロパティ</summary>
        /// <value>10：月間目標,20：個別期間目標</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get { return _targetSetCd; }
            set { _targetSetCd = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>目標対比区分プロパティ</summary>
        /// <value>10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標対比区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  TargetDivideCode
        /// <summary>目標区分コードプロパティ</summary>
        /// <value>月間目標：YYYYMM、個別期間目標：任意コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get { return _targetDivideCode; }
            set { _targetDivideCode = value; }
        }

        /// public propaty name  :  TargetDivideName
        /// <summary>目標区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   目標区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TargetDivideName
        {
            get { return _targetDivideName; }
            set { _targetDivideName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }
        
        /// public propaty name  :  StartApplyStaDate
        /// <summary>適用開始日(開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日(開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartApplyStaDate
        {
            get { return _startApplyStaDate; }
            set { _startApplyStaDate = value; }
        }

        /// public propaty name  :  EndApplyStaDate
        /// <summary>適用開始日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EndApplyStaDate
        {
            get { return _endApplyStaDate; }
            set { _endApplyStaDate = value; }
        }

        /// public propaty name  :  StartApplyEndDate
        /// <summary>適用終了日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartApplyEndDate
        {
            get { return _startApplyEndDate; }
            set { _startApplyEndDate = value; }
        }

        /// public propaty name  :  EndApplyEndDate
        /// <summary>適用終了日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EndApplyEndDate
        {
            get { return _endApplyEndDate; }
            set { _endApplyEndDate = value; }
        }


        /// <summary>
        /// 商品別売上目標設定検索ワークコンストラクタ
        /// </summary>
        /// <returns>SearchGcdSalesTargetParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchGcdSalesTargetParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchGcdSalesTargetParaWork()
        {
        }

    }
}
