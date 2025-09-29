using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchConditionWork
    /// <summary>
    ///                      仕入データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/04/26</br>
    /// <br>Genarated Date   :   2011/05/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchConditionWork : IFileHeader
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

        /// <summary>キャンペーンコード</summary>
        /// <remarks>キャンペーンコード</remarks>
        private Int32 _campaignCode;

        /// <summary>拠点コード</summary>
        /// <remarks>拠点</remarks>
        private string _sectionCode = "";

        /// <summary>メーカー（開始）</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>メーカー（終了）</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>ＢＬコード（開始）</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>ＢＬコード（終了）</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>グループコード（開始）</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>グループコード（終了）</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>販売区分（開始）</summary>
        private Int32 _salesCodeSt;

        /// <summary>販売区分（終了）</summary>
        private Int32 _salesCodeEd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>削除指定区分</summary>
        private Int32 _deleteFlag;

        /// <summary>売価率</summary>
        private Double _rateVal;

        /// <summary>売価率区分</summary>
        private Int32 _rateValDiv;

        /// <summary>売価額</summary>
        private Double _priceFl;

        /// <summary>売価額区分</summary>
        private Int32 _priceFlDiv;

        /// <summary>値引率</summary>
        private Double _discountRate;

        /// <summary>値引率区分</summary>
        private Int32 _discountRateDiv;


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

        /// public propaty name  :  CampaignCode
        /// <summary>キャンペーンコードプロパティ</summary>
        /// <value>キャンペーンコード</value>
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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>拠点</value>
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

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>メーカー（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>メーカー（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>ＢＬコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>ＢＬコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>グループコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>グループコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>販売区分（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>販売区分（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
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

        /// public propaty name  :  DeleteFlag
        /// <summary>削除指定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  RateValDiv
        /// <summary>売価率区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateValDiv
        {
            get { return _rateValDiv; }
            set { _rateValDiv = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>売価額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  PriceFlDiv
        /// <summary>売価額区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価額区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceFlDiv
        {
            get { return _priceFlDiv; }
            set { _priceFlDiv = value; }
        }

        /// public propaty name  :  DiscountRate
        /// <summary>値引率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        /// public propaty name  :  DiscountRateDiv
        /// <summary>値引率区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引率区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DiscountRateDiv
        {
            get { return _discountRateDiv; }
            set { _discountRateDiv = value; }
        }


        /// <summary>
        /// 仕入データワークコンストラクタ
        /// </summary>
        /// <returns>SearchConditionWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchConditionWork()
        {
        }

    }
    
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SearchConditionWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SearchConditionWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SearchConditionWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SearchConditionWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SearchConditionWork || graph is ArrayList || graph is SearchConditionWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SearchConditionWork).FullName));

            if (graph != null && graph is SearchConditionWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SearchConditionWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SearchConditionWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SearchConditionWork[])graph).Length;
            }
            else if (graph is SearchConditionWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //メーカー（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdSt
            //メーカー（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdEd
            //ＢＬコード（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeSt
            //ＢＬコード（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeEd
            //グループコード（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCodeSt
            //グループコード（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCodeEd
            //販売区分（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCodeSt
            //販売区分（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCodeEd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //削除指定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeleteFlag
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //RateVal
            //売価率区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RateValDiv
            //売価額
            serInfo.MemberInfo.Add(typeof(Double)); //PriceFl
            //売価額区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceFlDiv
            //値引率
            serInfo.MemberInfo.Add(typeof(Double)); //DiscountRate
            //値引率区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DiscountRateDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is SearchConditionWork)
            {
                SearchConditionWork temp = (SearchConditionWork)graph;

                SetSearchConditionWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SearchConditionWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SearchConditionWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SearchConditionWork temp in lst)
                {
                    SetSearchConditionWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SearchConditionWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  SearchConditionWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSearchConditionWork(System.IO.BinaryWriter writer, SearchConditionWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //メーカー（開始）
            writer.Write(temp.GoodsMakerCdSt);
            //メーカー（終了）
            writer.Write(temp.GoodsMakerCdEd);
            //ＢＬコード（開始）
            writer.Write(temp.BLGoodsCodeSt);
            //ＢＬコード（終了）
            writer.Write(temp.BLGoodsCodeEd);
            //グループコード（開始）
            writer.Write(temp.BLGroupCodeSt);
            //グループコード（終了）
            writer.Write(temp.BLGroupCodeEd);
            //販売区分（開始）
            writer.Write(temp.SalesCodeSt);
            //販売区分（終了）
            writer.Write(temp.SalesCodeEd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //削除指定区分
            writer.Write(temp.DeleteFlag);
            //売価率
            writer.Write(temp.RateVal);
            //売価率区分
            writer.Write(temp.RateValDiv);
            //売価額
            writer.Write(temp.PriceFl);
            //売価額区分
            writer.Write(temp.PriceFlDiv);
            //値引率
            writer.Write(temp.DiscountRate);
            //値引率区分
            writer.Write(temp.DiscountRateDiv);

        }

        /// <summary>
        ///  SearchConditionWorkインスタンス取得
        /// </summary>
        /// <returns>SearchConditionWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SearchConditionWork GetSearchConditionWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SearchConditionWork temp = new SearchConditionWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //メーカー（開始）
            temp.GoodsMakerCdSt = reader.ReadInt32();
            //メーカー（終了）
            temp.GoodsMakerCdEd = reader.ReadInt32();
            //ＢＬコード（開始）
            temp.BLGoodsCodeSt = reader.ReadInt32();
            //ＢＬコード（終了）
            temp.BLGoodsCodeEd = reader.ReadInt32();
            //グループコード（開始）
            temp.BLGroupCodeSt = reader.ReadInt32();
            //グループコード（終了）
            temp.BLGroupCodeEd = reader.ReadInt32();
            //販売区分（開始）
            temp.SalesCodeSt = reader.ReadInt32();
            //販売区分（終了）
            temp.SalesCodeEd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //削除指定区分
            temp.DeleteFlag = reader.ReadInt32();
            //売価率
            temp.RateVal = reader.ReadDouble();
            //売価率区分
            temp.RateValDiv = reader.ReadInt32();
            //売価額
            temp.PriceFl = reader.ReadDouble();
            //売価額区分
            temp.PriceFlDiv = reader.ReadInt32();
            //値引率
            temp.DiscountRate = reader.ReadDouble();
            //値引率区分
            temp.DiscountRateDiv = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>SearchConditionWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SearchConditionWork temp = GetSearchConditionWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SearchConditionWork[])lst.ToArray(typeof(SearchConditionWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
