//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン管理マスタ
// プログラム概要   : キャンペーン管理の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignMngOrder
    /// <summary>
    ///                      キャンペーン管理マスタ抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン管理マスタ抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignMngOrder
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>開始商品中分類コード</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>終了商品中分類コード</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>開始BLグループコード</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>終了BLグループコード</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>開始BL商品コード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了BL商品コード</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>開始商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>終了商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>開始BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>終了BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>開始BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>終了BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
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


        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>CampaignMngOrderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngOrderクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignMngOrder()
        {
        }

        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="st_GoodsMGroup">開始商品中分類コード</param>
        /// <param name="ed_GoodsMGroup">終了商品中分類コード</param>
        /// <param name="st_BLGroupCode">開始BLグループコード</param>
        /// <param name="ed_BLGroupCode">終了BLグループコード</param>
        /// <param name="st_BLGoodsCode">開始BL商品コード</param>
        /// <param name="ed_BLGoodsCode">終了BL商品コード</param>
        /// <param name="st_GoodsMakerCd">開始商品メーカーコード</param>
        /// <param name="ed_GoodsMakerCd">終了商品メーカーコード</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>CampaignMngOrderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngOrderクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignMngOrder( string enterpriseCode, string sectionCode, Int32 st_GoodsMGroup, Int32 ed_GoodsMGroup, Int32 st_BLGroupCode, Int32 ed_BLGroupCode, Int32 st_BLGoodsCode, Int32 ed_BLGoodsCode, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, string enterpriseName )
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._st_GoodsMGroup = st_GoodsMGroup;
            this._ed_GoodsMGroup = ed_GoodsMGroup;
            this._st_BLGroupCode = st_BLGroupCode;
            this._ed_BLGroupCode = ed_BLGroupCode;
            this._st_BLGoodsCode = st_BLGoodsCode;
            this._ed_BLGoodsCode = ed_BLGoodsCode;
            this._st_GoodsMakerCd = st_GoodsMakerCd;
            this._ed_GoodsMakerCd = ed_GoodsMakerCd;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラス複製処理
        /// </summary>
        /// <returns>CampaignMngOrderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCampaignMngOrderクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignMngOrder Clone()
        {
            return new CampaignMngOrder( this._enterpriseCode, this._sectionCode, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._enterpriseName );
        }

        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignMngOrderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngOrderクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( CampaignMngOrder target )
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
                 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
                 && (this.St_BLGroupCode == target.St_BLGroupCode)
                 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
                 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="campaignMngOrder1">
        ///                    比較するCampaignMngOrderクラスのインスタンス
        /// </param>
        /// <param name="campaignMngOrder2">比較するCampaignMngOrderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngOrderクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( CampaignMngOrder campaignMngOrder1, CampaignMngOrder campaignMngOrder2 )
        {
            return ((campaignMngOrder1.EnterpriseCode == campaignMngOrder2.EnterpriseCode)
                 && (campaignMngOrder1.SectionCode == campaignMngOrder2.SectionCode)
                 && (campaignMngOrder1.St_GoodsMGroup == campaignMngOrder2.St_GoodsMGroup)
                 && (campaignMngOrder1.Ed_GoodsMGroup == campaignMngOrder2.Ed_GoodsMGroup)
                 && (campaignMngOrder1.St_BLGroupCode == campaignMngOrder2.St_BLGroupCode)
                 && (campaignMngOrder1.Ed_BLGroupCode == campaignMngOrder2.Ed_BLGroupCode)
                 && (campaignMngOrder1.St_BLGoodsCode == campaignMngOrder2.St_BLGoodsCode)
                 && (campaignMngOrder1.Ed_BLGoodsCode == campaignMngOrder2.Ed_BLGoodsCode)
                 && (campaignMngOrder1.St_GoodsMakerCd == campaignMngOrder2.St_GoodsMakerCd)
                 && (campaignMngOrder1.Ed_GoodsMakerCd == campaignMngOrder2.Ed_GoodsMakerCd)
                 && (campaignMngOrder1.EnterpriseName == campaignMngOrder2.EnterpriseName));
        }
        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignMngOrderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngOrderクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( CampaignMngOrder target )
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.St_GoodsMGroup != target.St_GoodsMGroup ) resList.Add( "St_GoodsMGroup" );
            if ( this.Ed_GoodsMGroup != target.Ed_GoodsMGroup ) resList.Add( "Ed_GoodsMGroup" );
            if ( this.St_BLGroupCode != target.St_BLGroupCode ) resList.Add( "St_BLGroupCode" );
            if ( this.Ed_BLGroupCode != target.Ed_BLGroupCode ) resList.Add( "Ed_BLGroupCode" );
            if ( this.St_BLGoodsCode != target.St_BLGoodsCode ) resList.Add( "St_BLGoodsCode" );
            if ( this.Ed_BLGoodsCode != target.Ed_BLGoodsCode ) resList.Add( "Ed_BLGoodsCode" );
            if ( this.St_GoodsMakerCd != target.St_GoodsMakerCd ) resList.Add( "St_GoodsMakerCd" );
            if ( this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd ) resList.Add( "Ed_GoodsMakerCd" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }

        /// <summary>
        /// キャンペーン管理マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="campaignMngOrder1">比較するCampaignMngOrderクラスのインスタンス</param>
        /// <param name="campaignMngOrder2">比較するCampaignMngOrderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignMngOrderクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( CampaignMngOrder campaignMngOrder1, CampaignMngOrder campaignMngOrder2 )
        {
            ArrayList resList = new ArrayList();
            if ( campaignMngOrder1.EnterpriseCode != campaignMngOrder2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( campaignMngOrder1.SectionCode != campaignMngOrder2.SectionCode ) resList.Add( "SectionCode" );
            if ( campaignMngOrder1.St_GoodsMGroup != campaignMngOrder2.St_GoodsMGroup ) resList.Add( "St_GoodsMGroup" );
            if ( campaignMngOrder1.Ed_GoodsMGroup != campaignMngOrder2.Ed_GoodsMGroup ) resList.Add( "Ed_GoodsMGroup" );
            if ( campaignMngOrder1.St_BLGroupCode != campaignMngOrder2.St_BLGroupCode ) resList.Add( "St_BLGroupCode" );
            if ( campaignMngOrder1.Ed_BLGroupCode != campaignMngOrder2.Ed_BLGroupCode ) resList.Add( "Ed_BLGroupCode" );
            if ( campaignMngOrder1.St_BLGoodsCode != campaignMngOrder2.St_BLGoodsCode ) resList.Add( "St_BLGoodsCode" );
            if ( campaignMngOrder1.Ed_BLGoodsCode != campaignMngOrder2.Ed_BLGoodsCode ) resList.Add( "Ed_BLGoodsCode" );
            if ( campaignMngOrder1.St_GoodsMakerCd != campaignMngOrder2.St_GoodsMakerCd ) resList.Add( "St_GoodsMakerCd" );
            if ( campaignMngOrder1.Ed_GoodsMakerCd != campaignMngOrder2.Ed_GoodsMakerCd ) resList.Add( "Ed_GoodsMakerCd" );
            if ( campaignMngOrder1.EnterpriseName != campaignMngOrder2.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }
    }
}
