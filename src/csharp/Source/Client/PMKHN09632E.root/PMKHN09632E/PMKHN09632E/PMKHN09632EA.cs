//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括登録
// プログラム概要   : キャンペーン対象商品設定マスタ一括登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/13  修正内容 : Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignGoodsData
    /// <summary>
    ///                      商品マスタ（ユーザー登録分）
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品マスタ（ユーザー登録分）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2011/05/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/9/5  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   　提供区分</br>
    /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
    /// </remarks>
    public class CampaignGoodsData
    {
        // ----- UPD 2011/07/13 ------- >>>>>>>>>
        /// <summary>ＢＬコード(開始)</summary>
        //private Int32 _bLGroupCodeSt;
        private Int32 _bLGoodsCode;
        // ----- UPD 2011/07/13 ------- <<<<<<<<<

        /// <summary>ＢＬコード(終了)</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>キャンペーンコード</summary>
        private Int32 _campaignCode;

        /// <summary>キャンペーン設定種別</summary>
        /// <remarks>1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _campaignSettingKind;

        /// <summary>キャンペーン名称</summary>
        private string _campaignName = "";

        /// <summary>キャンペーン対象区分</summary>
        /// <remarks>0:全得意先 1:対象得意先 2:中止</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        // ----- UPD 2011/07/13 ------- >>>>>>>>>
        /// public propaty name  :  BLGroupCodeSt
        /// <summary>ＢＬコード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public Int32 BLGroupCodeSt
        //{
        //    get { return _bLGroupCodeSt; }
        //    set { _bLGroupCodeSt = value; }
        //}
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }
        // ----- UPD 2011/07/13 ------- <<<<<<<<<

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>ＢＬコード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
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

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
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

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーンコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampaignSettingKind
        /// <summary>キャンペーン設定種別プロパティ</summary>
        /// <value>1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン設定種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignSettingKind
        {
            get { return _campaignSettingKind; }
            set { _campaignSettingKind = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>キャンペーン名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>キャンペーン対象区分プロパティ</summary>
        /// <value>0:全得意先 1:対象得意先 2:中止</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
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
        /// 商品マスタ（ユーザー登録分）コンストラクタ
        /// </summary>
        /// <returns>CampaignGoodsDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public CampaignGoodsData()
        {
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）コンストラクタ
        /// </summary>
        /// <param name="bLGoodsCode">ＢＬコード(開始)</param>
        /// <param name="bLGroupCodeEd">ＢＬコード(終了)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="campaignCode">キャンペーンコード</param>
        /// <param name="campaignSettingKind">キャンペーン設定種別(1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="campaignName">キャンペーン名称</param>
        /// <param name="campaignObjDiv">キャンペーン対象区分(0:全得意先 1:対象得意先 2:中止)</param>
        /// <param name="applyStaDate">適用開始日(YYYYMMDD)</param>
        /// <param name="applyEndDate">適用終了日(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>CampaignGoodsDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        //public CampaignGoodsData(Int32 bLGroupCodeSt, Int32 bLGroupCodeEd, string enterpriseCode, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNoNoneHyphen, string sectionCode, Int32 campaignCode, Int32 campaignSettingKind, string campaignName, Int32 campaignObjDiv, Int32 applyStaDate, Int32 applyEndDate, string enterpriseName)
        public CampaignGoodsData(Int32 bLGoodsCode, Int32 bLGroupCodeEd, string enterpriseCode, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNoNoneHyphen, string sectionCode, Int32 campaignCode, Int32 campaignSettingKind, string campaignName, Int32 campaignObjDiv, Int32 applyStaDate, Int32 applyEndDate, string enterpriseName)
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //this._bLGroupCodeSt = bLGroupCodeSt;
            this._bLGoodsCode = bLGoodsCode;
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            this._bLGroupCodeEd = bLGroupCodeEd;
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._sectionCode = sectionCode;
            this._campaignCode = campaignCode;
            this._campaignSettingKind = campaignSettingKind;
            this._campaignName = campaignName;
            this._campaignObjDiv = campaignObjDiv;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）複製処理
        /// </summary>
        /// <returns>CampaignGoodsDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCampaignGoodsDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public CampaignGoodsData Clone()
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //return new CampaignGoodsData(this._bLGroupCodeSt, this._bLGroupCodeEd, this._enterpriseCode, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNoNoneHyphen, this._sectionCode, this._campaignCode, this._campaignSettingKind, this._campaignName, this._campaignObjDiv, this._applyStaDate, this._applyEndDate, this._enterpriseName);
            return new CampaignGoodsData(this._bLGoodsCode, this._bLGroupCodeEd, this._enterpriseCode, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNoNoneHyphen, this._sectionCode, this._campaignCode, this._campaignSettingKind, this._campaignName, this._campaignObjDiv, this._applyStaDate, this._applyEndDate, this._enterpriseName);
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public bool Equals(CampaignGoodsData target)
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //return ((this.BLGroupCodeSt == target.BLGroupCodeSt)
            return ((this.BLGoodsCode == target.BLGoodsCode)
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
                 && (this.BLGroupCodeEd == target.BLGroupCodeEd)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampaignSettingKind == target.CampaignSettingKind)
                 && (this.CampaignName == target.CampaignName)
                 && (this.CampaignObjDiv == target.CampaignObjDiv)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="campaignGoodsData1">
        ///                    比較するCampaignGoodsDataクラスのインスタンス
        /// </param>
        /// <param name="campaignGoodsData2">比較するCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public static bool Equals(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //return ((campaignGoodsData1.BLGroupCodeSt == campaignGoodsData2.BLGroupCodeSt)
            return ((campaignGoodsData1.BLGoodsCode == campaignGoodsData2.BLGoodsCode)
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
                 && (campaignGoodsData1.BLGroupCodeEd == campaignGoodsData2.BLGroupCodeEd)
                 && (campaignGoodsData1.EnterpriseCode == campaignGoodsData2.EnterpriseCode)
                 && (campaignGoodsData1.LogicalDeleteCode == campaignGoodsData2.LogicalDeleteCode)
                 && (campaignGoodsData1.GoodsMakerCd == campaignGoodsData2.GoodsMakerCd)
                 && (campaignGoodsData1.GoodsNoNoneHyphen == campaignGoodsData2.GoodsNoNoneHyphen)
                 && (campaignGoodsData1.SectionCode == campaignGoodsData2.SectionCode)
                 && (campaignGoodsData1.CampaignCode == campaignGoodsData2.CampaignCode)
                 && (campaignGoodsData1.CampaignSettingKind == campaignGoodsData2.CampaignSettingKind)
                 && (campaignGoodsData1.CampaignName == campaignGoodsData2.CampaignName)
                 && (campaignGoodsData1.CampaignObjDiv == campaignGoodsData2.CampaignObjDiv)
                 && (campaignGoodsData1.ApplyStaDate == campaignGoodsData2.ApplyStaDate)
                 && (campaignGoodsData1.ApplyEndDate == campaignGoodsData2.ApplyEndDate)
                 && (campaignGoodsData1.EnterpriseName == campaignGoodsData2.EnterpriseName));
        }
        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public ArrayList Compare(CampaignGoodsData target)
        {
            ArrayList resList = new ArrayList();
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //if (this.BLGroupCodeSt != target.BLGroupCodeSt) resList.Add("BLGroupCodeSt");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            if (this.BLGroupCodeEd != target.BLGroupCodeEd) resList.Add("BLGroupCodeEd");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampaignSettingKind != target.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.CampaignObjDiv != target.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）比較処理
        /// </summary>
        /// <param name="campaignGoodsData1">比較するCampaignGoodsDataクラスのインスタンス</param>
        /// <param name="campaignGoodsData2">比較するCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public static ArrayList Compare(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            ArrayList resList = new ArrayList();
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //if (campaignGoodsData1.BLGroupCodeSt != campaignGoodsData2.BLGroupCodeSt) resList.Add("BLGroupCodeSt");
            if (campaignGoodsData1.BLGoodsCode != campaignGoodsData2.BLGoodsCode) resList.Add("BLGoodsCode");
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            if (campaignGoodsData1.BLGroupCodeEd != campaignGoodsData2.BLGroupCodeEd) resList.Add("BLGroupCodeEd");
            if (campaignGoodsData1.EnterpriseCode != campaignGoodsData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignGoodsData1.LogicalDeleteCode != campaignGoodsData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignGoodsData1.GoodsMakerCd != campaignGoodsData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignGoodsData1.GoodsNoNoneHyphen != campaignGoodsData2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (campaignGoodsData1.SectionCode != campaignGoodsData2.SectionCode) resList.Add("SectionCode");
            if (campaignGoodsData1.CampaignCode != campaignGoodsData2.CampaignCode) resList.Add("CampaignCode");
            if (campaignGoodsData1.CampaignSettingKind != campaignGoodsData2.CampaignSettingKind) resList.Add("CampaignSettingKind");
            if (campaignGoodsData1.CampaignName != campaignGoodsData2.CampaignName) resList.Add("CampaignName");
            if (campaignGoodsData1.CampaignObjDiv != campaignGoodsData2.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (campaignGoodsData1.ApplyStaDate != campaignGoodsData2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (campaignGoodsData1.ApplyEndDate != campaignGoodsData2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (campaignGoodsData1.EnterpriseName != campaignGoodsData2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
