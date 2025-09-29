//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   目標自動設定DB仲介クラス
//                  :   PMKHN09457D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   譚洪
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ObjAutoSetWork
    /// <summary>
    ///                      目標自動設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   目標自動設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/3/13</br>
    /// <br>Genarated Date   :   2009/04/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ObjAutoSetWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _secCode = "";

        /// <summary>拠点DRP</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Int32 _secDrp;

        /// <summary>部門DRP</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private Int32 _buMonDrp;

        /// <summary>得意先DRP</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private Int32 _customerDrp;

        /// <summary>担当者DRP</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _tantosyaDrp;

        /// <summary>受注者DRP</summary>
        /// <remarks>0:データ　1:マスタ</remarks>
        private Int32 _receOrdDrp;

        /// <summary>発行者DRP</summary>
        /// <remarks>0:送信 1:受信</remarks>
        private Int32 _publisherDrp;

        /// <summary>地区DRP</summary>
        private Int32 _districtDrp;

        /// <summary>業種DRP</summary>
        /// <remarks>最終送信日</remarks>
        private Int32 _typeBusinessDrp;

        /// <summary>販売区分DRP</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private Int32 _salesDivisionDrp;

        /// <summary>商品区分DRP</summary>
        private Int32 _comDivisionDrp;

        /// <summary>対象金額DRP</summary>
        private Int32 _objMoneyDrp;

        /// <summary>対象期DRP</summary>
        private Int32 _objPeriodDrp;

        /// <summary>比率DRP</summary>
        private Int32 _ratioDrp;

        /// <summary>単位DRP</summary>
        private Int32 _unitDrp;

        /// <summary>端数処理DRP</summary>
        private Int32 _fractionProcDrp;

        /// <summary>売上目標</summary>
        private Int32 _salesTarget;

        /// <summary>粗利目標</summary>
        private Int32 _groMarginTarget;

        /// <summary>数量目標</summary>
        private Int32 _amountTarget;

        /// <summary>過去</summary>
        private Int32 _past;


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

        /// public propaty name  :  SecCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SecCode
        {
            get { return _secCode; }
            set { _secCode = value; }
        }

        /// public propaty name  :  SecDrp
        /// <summary>拠点DRPプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecDrp
        {
            get { return _secDrp; }
            set { _secDrp = value; }
        }

        /// public propaty name  :  BuMonDrp
        /// <summary>部門DRPプロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BuMonDrp
        {
            get { return _buMonDrp; }
            set { _buMonDrp = value; }
        }

        /// public propaty name  :  CustomerDrp
        /// <summary>得意先DRPプロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerDrp
        {
            get { return _customerDrp; }
            set { _customerDrp = value; }
        }

        /// public propaty name  :  TantosyaDrp
        /// <summary>担当者DRPプロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TantosyaDrp
        {
            get { return _tantosyaDrp; }
            set { _tantosyaDrp = value; }
        }

        /// public propaty name  :  ReceOrdDrp
        /// <summary>受注者DRPプロパティ</summary>
        /// <value>0:データ　1:マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceOrdDrp
        {
            get { return _receOrdDrp; }
            set { _receOrdDrp = value; }
        }

        /// public propaty name  :  PublisherDrp
        /// <summary>発行者DRPプロパティ</summary>
        /// <value>0:送信 1:受信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PublisherDrp
        {
            get { return _publisherDrp; }
            set { _publisherDrp = value; }
        }

        /// public propaty name  :  DistrictDrp
        /// <summary>地区DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   地区DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DistrictDrp
        {
            get { return _districtDrp; }
            set { _districtDrp = value; }
        }

        /// public propaty name  :  TypeBusinessDrp
        /// <summary>業種DRPプロパティ</summary>
        /// <value>最終送信日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TypeBusinessDrp
        {
            get { return _typeBusinessDrp; }
            set { _typeBusinessDrp = value; }
        }

        /// public propaty name  :  SalesDivisionDrp
        /// <summary>販売区分DRPプロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDivisionDrp
        {
            get { return _salesDivisionDrp; }
            set { _salesDivisionDrp = value; }
        }

        /// public propaty name  :  ComDivisionDrp
        /// <summary>商品区分DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ComDivisionDrp
        {
            get { return _comDivisionDrp; }
            set { _comDivisionDrp = value; }
        }

        /// public propaty name  :  ObjMoneyDrp
        /// <summary>対象金額DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象金額DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ObjMoneyDrp
        {
            get { return _objMoneyDrp; }
            set { _objMoneyDrp = value; }
        }

        /// public propaty name  :  ObjPeriodDrp
        /// <summary>対象期DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象期DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ObjPeriodDrp
        {
            get { return _objPeriodDrp; }
            set { _objPeriodDrp = value; }
        }

        /// public propaty name  :  RatioDrp
        /// <summary>比率DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   比率DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RatioDrp
        {
            get { return _ratioDrp; }
            set { _ratioDrp = value; }
        }

        /// public propaty name  :  UnitDrp
        /// <summary>単位DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単位DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnitDrp
        {
            get { return _unitDrp; }
            set { _unitDrp = value; }
        }

        /// public propaty name  :  FractionProcDrp
        /// <summary>端数処理DRPプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理DRPプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcDrp
        {
            get { return _fractionProcDrp; }
            set { _fractionProcDrp = value; }
        }

        /// public propaty name  :  SalesTarget
        /// <summary>売上目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesTarget
        {
            get { return _salesTarget; }
            set { _salesTarget = value; }
        }

        /// public propaty name  :  GroMarginTarget
        /// <summary>粗利目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GroMarginTarget
        {
            get { return _groMarginTarget; }
            set { _groMarginTarget = value; }
        }

        /// public propaty name  :  AmountTarget
        /// <summary>数量目標プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量目標プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AmountTarget
        {
            get { return _amountTarget; }
            set { _amountTarget = value; }
        }

        /// public propaty name  :  Past
        /// <summary>過去プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   過去プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Past
        {
            get { return _past; }
            set { _past = value; }
        }


        /// <summary>
        /// 目標自動設定ワークコンストラクタ
        /// </summary>
        /// <returns>ObjAutoSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ObjAutoSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ObjAutoSetWork()
        {
        }

    }
}
