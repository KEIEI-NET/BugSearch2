//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsInfoDataWork
    /// <summary>
    ///                      商品追加データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品追加データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/2/27</br>
    /// <br>Genarated Date   :   2009/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsInfoDataWork : IFileHeader
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

        /// <summary>仕入先ｺｰﾄﾞ</summary>
        /// <remarks>仕入先ｺｰﾄﾞ</remarks>
        private Int32 _supplierCd;

        /// <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
        /// <remarks>ﾒｰｶｰｺｰﾄﾞ</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>分類ｺｰﾄﾞ</summary>
        /// <remarks>分類ｺｰﾄﾞ</remarks>
        private string _kindCd = "";

        /// <summary>翼ｺｰﾄﾞ</summary>
        /// <remarks>翼ｺｰﾄﾞ</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>品　番</summary>
        /// <remarks>品　番</remarks>
        private string _goodsNo = "";

        /// <summary>品　名</summary>
        /// <remarks>品　名</remarks>
        private string _goodsName = "";

        /// <summary>定　価</summary>
        /// <remarks>定　価</remarks>
        private Double _price;

        /// <summary>部品商原価１</summary>
        /// <remarks>部品商原価１</remarks>
        private string _price1 = "";

        /// <summary>部品商原価２</summary>
        /// <remarks>部品商原価２</remarks>
        private string _price2 = "";

        /// <summary>部品商原価３</summary>
        /// <remarks>部品商原価３</remarks>
        private string _price3 = "";

        /// <summary>価格実施日</summary>
        /// <remarks>価格実施日</remarks>
        private Int64 _priceStartDate;

        /// <summary>登録区分</summary>
        /// <remarks>登録区分</remarks>
        private string _loginFlg = "";

        /// <summary>売価率</summary>
        /// <remarks>売価率</remarks>
        private Double _stockRate;

        /// <summary>売　価</summary>
        /// <remarks>売　価</remarks>
        private Double _salesUnitCost;

        /// <summary>部品商ｺｰﾄﾞ</summary>
        /// <remarks>部品商ｺｰﾄﾞ</remarks>
        private string _goodsTraderCd = "";

        /// <summary>ファイル作成日付</summary>
        /// <remarks>作成日付</remarks>
        private string _fileCreateDateTime = "";

        /// <summary>pdf状態</summary>
        /// <remarks>pdf状態</remarks>
        private string _pdfStatus = "";

        /// <summary>エラーコード</summary>
        /// <remarks>DBエラーコード</remarks>
        private Int32 _errorCode;

        /// <summary>エラーメッセージ</summary>
        /// <remarks>DBエラーメッセージ</remarks>
        private string _errorMessage = "";


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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先ｺｰﾄﾞプロパティ</summary>
        /// <value>仕入先ｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>ﾒｰｶｰｺｰﾄﾞプロパティ</summary>
        /// <value>ﾒｰｶｰｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  KindCd
        /// <summary>分類ｺｰﾄﾞプロパティ</summary>
        /// <value>分類ｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   分類ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KindCd
        {
            get { return _kindCd; }
            set { _kindCd = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>翼ｺｰﾄﾞプロパティ</summary>
        /// <value>翼ｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品　番プロパティ</summary>
        /// <value>品　番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品　番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品　名プロパティ</summary>
        /// <value>品　名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品　名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  Price
        /// <summary>定　価プロパティ</summary>
        /// <value>定　価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定　価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        /// public propaty name  :  Price1
        /// <summary>部品商原価１プロパティ</summary>
        /// <value>部品商原価１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商原価１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Price1
        {
            get { return _price1; }
            set { _price1 = value; }
        }

        /// public propaty name  :  Price2
        /// <summary>部品商原価２プロパティ</summary>
        /// <value>部品商原価２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商原価２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Price2
        {
            get { return _price2; }
            set { _price2 = value; }
        }

        /// public propaty name  :  Price3
        /// <summary>部品商原価３プロパティ</summary>
        /// <value>部品商原価３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商原価３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Price3
        {
            get { return _price3; }
            set { _price3 = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格実施日プロパティ</summary>
        /// <value>価格実施日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格実施日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  LoginFlg
        /// <summary>登録区分プロパティ</summary>
        /// <value>登録区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LoginFlg
        {
            get { return _loginFlg; }
            set { _loginFlg = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>売価率プロパティ</summary>
        /// <value>売価率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>売　価プロパティ</summary>
        /// <value>売　価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売　価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  GoodsTraderCd
        /// <summary>部品商ｺｰﾄﾞプロパティ</summary>
        /// <value>部品商ｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品商ｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsTraderCd
        {
            get { return _goodsTraderCd; }
            set { _goodsTraderCd = value; }
        }

        /// public propaty name  :  FileCreateDateTime
        /// <summary>ファイル作成日付プロパティ</summary>
        /// <value>作成日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル作成日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileCreateDateTime
        {
            get { return _fileCreateDateTime; }
            set { _fileCreateDateTime = value; }
        }

        /// public propaty name  :  PdfStatus
        /// <summary>pdf状態プロパティ</summary>
        /// <value>pdf状態</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   pdf状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PdfStatus
        {
            get { return _pdfStatus; }
            set { _pdfStatus = value; }
        }

        /// public propaty name  :  ErrorCode
        /// <summary>エラーコードプロパティ</summary>
        /// <value>DBエラーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        /// public propaty name  :  ErrorMessage
        /// <summary>エラーメッセージプロパティ</summary>
        /// <value>DBエラーメッセージ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }


        /// <summary>
        /// 商品追加データワークコンストラクタ
        /// </summary>
        /// <returns>GoodsInfoDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsInfoDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsInfoDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsInfoDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsInfoDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsInfoDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsInfoDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsInfoDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsInfoDataWork || graph is ArrayList || graph is GoodsInfoDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsInfoDataWork).FullName));

            if (graph != null && graph is GoodsInfoDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsInfoDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsInfoDataWork[])graph).Length;
            }
            else if (graph is GoodsInfoDataWork)
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
            //仕入先ｺｰﾄﾞ
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //ﾒｰｶｰｺｰﾄﾞ
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //分類ｺｰﾄﾞ
            serInfo.MemberInfo.Add(typeof(string)); //KindCd
            //翼ｺｰﾄﾞ
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //品　番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //品　名
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //定　価
            serInfo.MemberInfo.Add(typeof(Double)); //Price
            //部品商原価１
            serInfo.MemberInfo.Add(typeof(string)); //Price1
            //部品商原価２
            serInfo.MemberInfo.Add(typeof(string)); //Price2
            //部品商原価３
            serInfo.MemberInfo.Add(typeof(string)); //Price3
            //価格実施日
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //登録区分
            serInfo.MemberInfo.Add(typeof(string)); //LoginFlg
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //売　価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //部品商ｺｰﾄﾞ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsTraderCd
            //ファイル作成日付
            serInfo.MemberInfo.Add(typeof(string)); //FileCreateDateTime
            //pdf状態
            serInfo.MemberInfo.Add(typeof(string)); //PdfStatus
            //エラーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorCode
            //エラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMessage


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsInfoDataWork)
            {
                GoodsInfoDataWork temp = (GoodsInfoDataWork)graph;

                SetGoodsInfoDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsInfoDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsInfoDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsInfoDataWork temp in lst)
                {
                    SetGoodsInfoDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsInfoDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 27;

        /// <summary>
        ///  GoodsInfoDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsInfoDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsInfoDataWork(System.IO.BinaryWriter writer, GoodsInfoDataWork temp)
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
            //仕入先ｺｰﾄﾞ
            writer.Write(temp.SupplierCd);
            //ﾒｰｶｰｺｰﾄﾞ
            writer.Write(temp.GoodsMakerCd);
            //分類ｺｰﾄﾞ
            writer.Write(temp.KindCd);
            //翼ｺｰﾄﾞ
            writer.Write(temp.BLGoodsCode);
            //品　番
            writer.Write(temp.GoodsNo);
            //品　名
            writer.Write(temp.GoodsName);
            //定　価
            writer.Write(temp.Price);
            //部品商原価１
            writer.Write(temp.Price1);
            //部品商原価２
            writer.Write(temp.Price2);
            //部品商原価３
            writer.Write(temp.Price3);
            //価格実施日
            writer.Write(temp.PriceStartDate);
            //登録区分
            writer.Write(temp.LoginFlg);
            //売価率
            writer.Write(temp.StockRate);
            //売　価
            writer.Write(temp.SalesUnitCost);
            //部品商ｺｰﾄﾞ
            writer.Write(temp.GoodsTraderCd);
            //ファイル作成日付
            writer.Write(temp.FileCreateDateTime);
            //pdf状態
            writer.Write(temp.PdfStatus);
            //エラーコード
            writer.Write(temp.ErrorCode);
            //エラーメッセージ
            writer.Write(temp.ErrorMessage);

        }

        /// <summary>
        ///  GoodsInfoDataWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsInfoDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsInfoDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsInfoDataWork GetGoodsInfoDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsInfoDataWork temp = new GoodsInfoDataWork();

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
            //仕入先ｺｰﾄﾞ
            temp.SupplierCd = reader.ReadInt32();
            //ﾒｰｶｰｺｰﾄﾞ
            temp.GoodsMakerCd = reader.ReadInt32();
            //分類ｺｰﾄﾞ
            temp.KindCd = reader.ReadString();
            //翼ｺｰﾄﾞ
            temp.BLGoodsCode = reader.ReadInt32();
            //品　番
            temp.GoodsNo = reader.ReadString();
            //品　名
            temp.GoodsName = reader.ReadString();
            //定　価
            temp.Price = reader.ReadDouble();
            //部品商原価１
            temp.Price1 = reader.ReadString();
            //部品商原価２
            temp.Price2 = reader.ReadString();
            //部品商原価３
            temp.Price3 = reader.ReadString();
            //価格実施日
            temp.PriceStartDate = reader.ReadInt64();
            //登録区分
            temp.LoginFlg = reader.ReadString();
            //売価率
            temp.StockRate = reader.ReadDouble();
            //売　価
            temp.SalesUnitCost = reader.ReadDouble();
            //部品商ｺｰﾄﾞ
            temp.GoodsTraderCd = reader.ReadString();
            //ファイル作成日付
            temp.FileCreateDateTime = reader.ReadString();
            //pdf状態
            temp.PdfStatus = reader.ReadString();
            //エラーコード
            temp.ErrorCode = reader.ReadInt32();
            //エラーメッセージ
            temp.ErrorMessage = reader.ReadString();


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
        /// <returns>GoodsInfoDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsInfoDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsInfoDataWork temp = GetGoodsInfoDataWork(reader, serInfo);
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
                    retValue = (GoodsInfoDataWork[])lst.ToArray(typeof(GoodsInfoDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
