using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignGoodsData
    /// <summary>
    ///                      キャンペーン対象商品設定マスタ一括削除
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン管理マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>                 :   </br>
    /// </remarks>
    public class CampaignGoodsData
    {
        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>キャンペーン対象商品設定マスタ削除件数</summary>
        private Int32 _goodsStCount;

        /// <summary>キャンペーン名称設定マスタ削除件数</summary>
        private Int32 _nameStCount;

        /// <summary>キャンペーン対象得意先設定マスタ削除件数</summary>
        private Int32 _customStCount;

        /// <summary>キャンペーン目標設定マスタ削除件数</summary>
        private Int32 _targetStCount;

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>ﾒｰｶｰ名</summary>
        private string _goodsMakerNm = "";

        /// <summary>頭品番</summary>
        private string _headerGoodsNo = "";


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

        /// public propaty name  :  GoodsStCount
        /// <summary>キャンペーン対象商品設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象商品設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsStCount
        {
            get { return _goodsStCount; }
            set { _goodsStCount = value; }
        }

        /// public propaty name  :  NameStCount
        /// <summary>キャンペーン名称設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン名称設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NameStCount
        {
            get { return _nameStCount; }
            set { _nameStCount = value; }
        }

        /// public propaty name  :  CustomStCount
        /// <summary>キャンペーン対象得意先設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン対象得意先設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomStCount
        {
            get { return _customStCount; }
            set { _customStCount = value; }
        }

        /// public propaty name  :  TargetStCount
        /// <summary>キャンペーン目標設定マスタ削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キャンペーン目標設定マスタ削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetStCount
        {
            get { return _targetStCount; }
            set { _targetStCount = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>ﾒｰｶｰ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  HeaderGoodsNo
        /// <summary>頭品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   頭品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HeaderGoodsNo
        {
            get { return _headerGoodsNo; }
            set { _headerGoodsNo = value; }
        }


        /// <summary>
        /// キャンペーン管理マスタコンストラクタ
        /// </summary>
        /// <returns>CampaignGoodsDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignGoodsData()
        {
        }

        /// <summary>
        /// キャンペーン管理マスタコンストラクタ
        /// </summary>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsStCount">キャンペーン対象商品設定マスタ削除件数</param>
        /// <param name="nameStCount">キャンペーン名称設定マスタ削除件数</param>
        /// <param name="customStCount">キャンペーン対象得意先設定マスタ削除件数</param>
        /// <param name="targetStCount">キャンペーン目標設定マスタ削除件数</param>
        /// <param name="sectionName">拠点名称</param>
        /// <param name="goodsMakerNm">ﾒｰｶｰ名</param>
        /// <param name="headerGoodsNo">頭品番</param>
        /// <returns>CampaignGoodsDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignGoodsData(string sectionCode, Int32 goodsMakerCd, Int32 goodsStCount, Int32 nameStCount, Int32 customStCount, Int32 targetStCount, string sectionName, string goodsMakerNm, string headerGoodsNo)
        {
            this._sectionCode = sectionCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsStCount = goodsStCount;
            this._nameStCount = nameStCount;
            this._customStCount = customStCount;
            this._targetStCount = targetStCount;
            this._sectionName = sectionName;
            this._goodsMakerNm = goodsMakerNm;
            this._headerGoodsNo = headerGoodsNo;
        }

        /// <summary>
        /// キャンペーン管理マスタ複製処理
        /// </summary>
        /// <returns>CampaignGoodsDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCampaignGoodsDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignGoodsData Clone()
        {
            return new CampaignGoodsData(this._sectionCode, this._goodsMakerCd, this._goodsStCount, this._nameStCount, this._customStCount, this._targetStCount, this._sectionName, this._goodsMakerNm, this._headerGoodsNo);
        }

        /// <summary>
        /// キャンペーン管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CampaignGoodsData target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsStCount == target.GoodsStCount)
                 && (this.NameStCount == target.NameStCount)
                 && (this.CustomStCount == target.CustomStCount)
                 && (this.TargetStCount == target.TargetStCount)
                 && (this.SectionName == target.SectionName)
                 && (this.GoodsMakerNm == target.GoodsMakerNm)
                 && (this.HeaderGoodsNo == target.HeaderGoodsNo));
        }

        /// <summary>
        /// キャンペーン管理マスタ比較処理
        /// </summary>
        /// <param name="campaignGoodsData1">
        ///                    比較するCampaignGoodsDataクラスのインスタンス
        /// </param>
        /// <param name="campaignGoodsData2">比較するCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            return ((campaignGoodsData1.SectionCode == campaignGoodsData2.SectionCode)
                 && (campaignGoodsData1.GoodsMakerCd == campaignGoodsData2.GoodsMakerCd)
                 && (campaignGoodsData1.GoodsStCount == campaignGoodsData2.GoodsStCount)
                 && (campaignGoodsData1.NameStCount == campaignGoodsData2.NameStCount)
                 && (campaignGoodsData1.CustomStCount == campaignGoodsData2.CustomStCount)
                 && (campaignGoodsData1.TargetStCount == campaignGoodsData2.TargetStCount)
                 && (campaignGoodsData1.SectionName == campaignGoodsData2.SectionName)
                 && (campaignGoodsData1.GoodsMakerNm == campaignGoodsData2.GoodsMakerNm)
                 && (campaignGoodsData1.HeaderGoodsNo == campaignGoodsData2.HeaderGoodsNo));
        }
        /// <summary>
        /// キャンペーン管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CampaignGoodsData target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsStCount != target.GoodsStCount) resList.Add("GoodsStCount");
            if (this.NameStCount != target.NameStCount) resList.Add("NameStCount");
            if (this.CustomStCount != target.CustomStCount) resList.Add("CustomStCount");
            if (this.TargetStCount != target.TargetStCount) resList.Add("TargetStCount");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (this.HeaderGoodsNo != target.HeaderGoodsNo) resList.Add("HeaderGoodsNo");

            return resList;
        }

        /// <summary>
        /// キャンペーン管理マスタ比較処理
        /// </summary>
        /// <param name="campaignGoodsData1">比較するCampaignGoodsDataクラスのインスタンス</param>
        /// <param name="campaignGoodsData2">比較するCampaignGoodsDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignGoodsDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CampaignGoodsData campaignGoodsData1, CampaignGoodsData campaignGoodsData2)
        {
            ArrayList resList = new ArrayList();
            if (campaignGoodsData1.SectionCode != campaignGoodsData2.SectionCode) resList.Add("SectionCode");
            if (campaignGoodsData1.GoodsMakerCd != campaignGoodsData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (campaignGoodsData1.GoodsStCount != campaignGoodsData2.GoodsStCount) resList.Add("GoodsStCount");
            if (campaignGoodsData1.NameStCount != campaignGoodsData2.NameStCount) resList.Add("NameStCount");
            if (campaignGoodsData1.CustomStCount != campaignGoodsData2.CustomStCount) resList.Add("CustomStCount");
            if (campaignGoodsData1.TargetStCount != campaignGoodsData2.TargetStCount) resList.Add("TargetStCount");
            if (campaignGoodsData1.SectionName != campaignGoodsData2.SectionName) resList.Add("SectionName");
            if (campaignGoodsData1.GoodsMakerNm != campaignGoodsData2.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (campaignGoodsData1.HeaderGoodsNo != campaignGoodsData2.HeaderGoodsNo) resList.Add("HeaderGoodsNo");

            return resList;
        }
    }
}
