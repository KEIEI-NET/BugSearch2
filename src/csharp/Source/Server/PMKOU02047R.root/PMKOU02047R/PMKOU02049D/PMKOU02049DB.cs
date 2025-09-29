//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入不整合確認表
// プログラム概要   : 仕入不整合確認表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    /// public class name:   StockSalesInfoWork
    /// <summary>
    ///                      仕入不整合確認表データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入不整合確認表データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockSalesInfoWork 
    {
        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sectionGuideNm = "";

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _inputDay;

        /// <summary>仕入日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockDate;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>相手先伝票番号（明細）</summary>
        /// <remarks>得意先注文番号（仮伝No）</remarks>
        private string _partySlipNumDtl = "";

        /// <summary>仕入行番号</summary>
        private Int32 _stockRowNo;

        /// <summary>仕入担当者コード</summary>
        /// <remarks>発注者をセット</remarks>
        private string _stockAgentCode = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>不整合内容</summary>
        /// <remarks>不整合内容</remarks>
        private string _nayiYou = "";

        /// <summary>拠点コードヘッダ</summary>
        /// <remarks>ヘッダ</remarks>
        private string _sectionCodeHeader = "";

        /// <summary>仕入先コードヘッダ</summary>
        /// <remarks>ヘッダ</remarks>
        private Int32 _supplierCdHeader;

        /// <summary>数量チックフラグ</summary>
        /// <remarks>数量チックフラグ</remarks>
        private string _countFlg = "";

        /// <summary>価格チックフラグ</summary>
        /// <remarks>価格チックフラグ</remarks>
        private string _priceFlg = "";

        /// <summary>売上存在チックフラグ</summary>
        /// <remarks>売上存在チックフラグ</remarks>
        private string _existFlg = "";


        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入伝票番号,入荷伝票番号,注文書番号(発注)を兼ねる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
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

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>仕入日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PartySlipNumDtl
        /// <summary>相手先伝票番号（明細）プロパティ</summary>
        /// <value>得意先注文番号（仮伝No）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySlipNumDtl
        {
            get { return _partySlipNumDtl; }
            set { _partySlipNumDtl = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>仕入行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>発注者をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  NayiYou
        /// <summary>不整合内容プロパティ</summary>
        /// <value>不整合内容</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   不整合内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NayiYou
        {
            get { return _nayiYou; }
            set { _nayiYou = value; }
        }

        /// public propaty name  :  SectionCodeHeader
        /// <summary>拠点コードヘッダプロパティ</summary>
        /// <value>ヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードヘッダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeHeader
        {
            get { return _sectionCodeHeader; }
            set { _sectionCodeHeader = value; }
        }

        /// public propaty name  :  SupplierCdHeader
        /// <summary>仕入先コードヘッダプロパティ</summary>
        /// <value>ヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードヘッダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdHeader
        {
            get { return _supplierCdHeader; }
            set { _supplierCdHeader = value; }
        }

        /// public propaty name  :  CountFlg
        /// <summary>数量チックフラグプロパティ</summary>
        /// <value>数量チックフラグ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量チックフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CountFlg
        {
            get { return _countFlg; }
            set { _countFlg = value; }
        }

        /// public propaty name  :  PriceFlg
        /// <summary>価格チックフラグプロパティ</summary>
        /// <value>価格チックフラグ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格チックフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriceFlg
        {
            get { return _priceFlg; }
            set { _priceFlg = value; }
        }

        /// public propaty name  :  ExistFlg
        /// <summary>売上存在チックフラグプロパティ</summary>
        /// <value>売上存在チックフラグ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上存在チックフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExistFlg
        {
            get { return _existFlg; }
            set { _existFlg = value; }
        }


        /// <summary>
        /// 仕入不整合確認表データワークコンストラクタ
        /// </summary>
        /// <returns>StockSalesInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSalesInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockSalesInfoWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockSalesInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockSalesInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockSalesInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSalesInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockSalesInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockSalesInfoWork || graph is ArrayList || graph is StockSalesInfoWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockSalesInfoWork).FullName));

            if (graph != null && graph is StockSalesInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockSalesInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockSalesInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockSalesInfoWork[])graph).Length;
            }
            else if (graph is StockSalesInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //仕入日
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDate
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //相手先伝票番号（明細）
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //仕入行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //不整合内容
            serInfo.MemberInfo.Add(typeof(string)); //NayiYou
            //拠点コードヘッダ
            serInfo.MemberInfo.Add(typeof(string)); //SectionCodeHeader
            //仕入先コードヘッダ
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCdHeader
            //数量チックフラグ
            serInfo.MemberInfo.Add(typeof(string)); //CountFlg
            //価格チックフラグ
            serInfo.MemberInfo.Add(typeof(string)); //PriceFlg
            //売上存在チックフラグ
            serInfo.MemberInfo.Add(typeof(string)); //ExistFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is StockSalesInfoWork)
            {
                StockSalesInfoWork temp = (StockSalesInfoWork)graph;

                SetStockSalesInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockSalesInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockSalesInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockSalesInfoWork temp in lst)
                {
                    SetStockSalesInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockSalesInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 21;

        /// <summary>
        ///  StockSalesInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSalesInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockSalesInfoWork(System.IO.BinaryWriter writer, StockSalesInfoWork temp)
        {
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //入力日
            writer.Write(temp.InputDay);
            //仕入日
            writer.Write((Int64)temp.StockDate.Ticks);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //相手先伝票番号（明細）
            writer.Write(temp.PartySlipNumDtl);
            //仕入行番号
            writer.Write(temp.StockRowNo);
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //不整合内容
            writer.Write(temp.NayiYou);
            //拠点コードヘッダ
            writer.Write(temp.SectionCodeHeader);
            //仕入先コードヘッダ
            writer.Write(temp.SupplierCdHeader);
            //数量チックフラグ
            writer.Write(temp.CountFlg);
            //価格チックフラグ
            writer.Write(temp.PriceFlg);
            //売上存在チックフラグ
            writer.Write(temp.ExistFlg);

        }

        /// <summary>
        ///  StockSalesInfoWorkインスタンス取得
        /// </summary>
        /// <returns>StockSalesInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSalesInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockSalesInfoWork GetStockSalesInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockSalesInfoWork temp = new StockSalesInfoWork();

            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //入力日
            temp.InputDay = reader.ReadInt32();
            //仕入日
            temp.StockDate = new DateTime(reader.ReadInt64());
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //相手先伝票番号（明細）
            temp.PartySlipNumDtl = reader.ReadString();
            //仕入行番号
            temp.StockRowNo = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //不整合内容
            temp.NayiYou = reader.ReadString();
            //拠点コードヘッダ
            temp.SectionCodeHeader = reader.ReadString();
            //仕入先コードヘッダ
            temp.SupplierCdHeader = reader.ReadInt32();
            //数量チックフラグ
            temp.CountFlg = reader.ReadString();
            //価格チックフラグ
            temp.PriceFlg = reader.ReadString();
            //売上存在チックフラグ
            temp.ExistFlg = reader.ReadString();


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
        /// <returns>StockSalesInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSalesInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockSalesInfoWork temp = GetStockSalesInfoWork(reader, serInfo);
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
                    retValue = (StockSalesInfoWork[])lst.ToArray(typeof(StockSalesInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
