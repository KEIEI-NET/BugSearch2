//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリスト抽出条件クラス
// プログラム概要   : 発注点設定マスタリスト抽出条件クラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OrderSetMasListPara
    /// <summary>
    ///                      発注点設定マスタリスト抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   発注点設定マスタリスト抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/04/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OrderSetMasListPara
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sectionGuideNm = "";

        /// <summary>開始設定コード</summary>
        private string _startSetCode = "";

        /// <summary>終了設定コード</summary>
        private string _endSetCode = "";

        /// <summary>開始倉庫コード</summary>
        private string _startWarehouseCode = "";

        /// <summary>終了倉庫コード</summary>
        private string _endWarehouseCode = "";

        /// <summary>開始仕入先コード</summary>
        private Int32 _startSupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _endSupplierCd;

        /// <summary>開始メーカーコード</summary>
        /// <remarks>純正９００番台 優良９０００番台</remarks>
        private Int32 _startGoodsMakerCd;

        /// <summary>終了メーカーコード</summary>
        /// <remarks>純正９００番台 優良９０００番台</remarks>
        private Int32 _endGoodsMakerCd;

        /// <summary>開始グループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _startBLGroupCode;

        /// <summary>終了グループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _endBLGroupCode;

        /// <summary>開始BL商品コード</summary>
        /// <remarks>提供:1～9999 ユーザー:10000～</remarks>
        private Int32 _startBLGoodsCode;

        /// <summary>終了BL商品コード</summary>
        /// <remarks>提供:1～9999 ユーザー:10000～</remarks>
        private Int32 _endBLGoodsCode;

        /// <summary>開始商品中分類コード</summary>
        private Int32 _startGoodsMGroup;

        /// <summary>終了商品中分類コード</summary>
        private Int32 _endGoodsMGroup;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>発行タイプ</summary>
        private Int32 _printType;

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

        /// public propaty name  :  SectionCodes
        /// <summary>計上拠点コード（複数指定）プロパティ</summary>
        /// <value>（※配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  StartSetCode
        /// <summary>開始設定コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始設定コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartSetCode
        {
            get { return _startSetCode; }
            set { _startSetCode = value; }
        }

        /// public propaty name  :  EndSetCode
        /// <summary>終了設定コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了設定コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndSetCode
        {
            get { return _endSetCode; }
            set { _endSetCode = value; }
        }

        /// public propaty name  :  StartWarehouseCode
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StartWarehouseCode
        {
            get { return _startWarehouseCode; }
            set { _startWarehouseCode = value; }
        }

        /// public propaty name  :  EndWarehouseCode
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EndWarehouseCode
        {
            get { return _endWarehouseCode; }
            set { _endWarehouseCode = value; }
        }

        /// public propaty name  :  StartSupplierCd
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartSupplierCd
        {
            get { return _startSupplierCd; }
            set { _startSupplierCd = value; }
        }

        /// public propaty name  :  EndSupplierCd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndSupplierCd
        {
            get { return _endSupplierCd; }
            set { _endSupplierCd = value; }
        }

        /// public propaty name  :  StartGoodsMakerCd
        /// <summary>開始メーカーコードプロパティ</summary>
        /// <value>純正９００番台 優良９０００番台</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartGoodsMakerCd
        {
            get { return _startGoodsMakerCd; }
            set { _startGoodsMakerCd = value; }
        }

        /// public propaty name  :  EndGoodsMakerCd
        /// <summary>終了メーカーコードプロパティ</summary>
        /// <value>純正９００番台 優良９０００番台</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndGoodsMakerCd
        {
            get { return _endGoodsMakerCd; }
            set { _endGoodsMakerCd = value; }
        }

        /// public propaty name  :  StartBLGroupCode
        /// <summary>開始グループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartBLGroupCode
        {
            get { return _startBLGroupCode; }
            set { _startBLGroupCode = value; }
        }

        /// public propaty name  :  EndBLGroupCode
        /// <summary>終了グループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndBLGroupCode
        {
            get { return _endBLGroupCode; }
            set { _endBLGroupCode = value; }
        }

        /// public propaty name  :  StartBLGoodsCode
        /// <summary>開始BL商品コードプロパティ</summary>
        /// <value>提供:1～9999 ユーザー:10000～</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartBLGoodsCode
        {
            get { return _startBLGoodsCode; }
            set { _startBLGoodsCode = value; }
        }

        /// public propaty name  :  EndBLGoodsCode
        /// <summary>終了BL商品コードプロパティ</summary>
        /// <value>提供:1～9999 ユーザー:10000～</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndBLGoodsCode
        {
            get { return _endBLGoodsCode; }
            set { _endBLGoodsCode = value; }
        }

        /// public propaty name  :  StartGoodsMGroup
        /// <summary>開始商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartGoodsMGroup
        {
            get { return _startGoodsMGroup; }
            set { _startGoodsMGroup = value; }
        }

        /// public propaty name  :  EndGoodsMGroup
        /// <summary>終了商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndGoodsMGroup
        {
            get { return _endGoodsMGroup; }
            set { _endGoodsMGroup = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>発行タイプ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }
    }
}