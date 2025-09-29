//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品得意先個別設定マスタ抽出結果ワーク
// プログラム概要   : お買得商品得意先個別設定マスタ抽出結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015/02/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecBgnCustPMWork
    /// <summary>
    ///                      お買得商品得意先個別設定マスタ抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   お買得商品得意先個別設定マスタ抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnCustPMWork 
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _goodsApplyStaDate;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>メーカー希望小売価格</summary>
        private Int64 _mkrSuggestRtPric;

        /// <summary>定価</summary>
        private Int64 _listPrice;

        /// <summary>単価算出掛率</summary>
        /// <remarks>(9.99)</remarks>
        private double _unitCalcRate;

        /// <summary>単価</summary>
        private Int64 _unitPrice;

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>お買得商品グループコード</summary>
        /// <remarks>0:グループ無し</remarks>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>表示区分</summary>
        /// <remarks>0:表示,1:非表示</remarks>
        private Int32 _displayDivCode;

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsApplyStaDate
        /// <summary>商品適用開始日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品適用開始日</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsApplyStaDate
        {
            get { return _goodsApplyStaDate; }
            set { _goodsApplyStaDate = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>メーカー希望小売価格</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー希望小売価格</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitCalcRate
        /// <summary>単価算出掛率</summary>
        /// <value>(9.99)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価算出掛率</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double UnitCalcRate
        {
            get { return _unitCalcRate; }
            set { _unitCalcRate = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>単価</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>お買得商品グループコード</summary>
        /// <value>0:グループ無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }

        /// public propaty name  :  DisplayDivCode
        /// <summary>表示区分プロパティ</summary>
        /// <value>0:0:表示,1:非表示</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
        }


        /// <summary>
        /// お買得商品得意先個別設定マスタ抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RecBgnCustPMWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustPMWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnCustPMWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecBgnCustPMWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnCustPMWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecBgnCustPMWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustPMWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnCustPMWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnCustPMWork || graph is ArrayList || graph is RecBgnCustPMWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecBgnCustPMWork).FullName));

            if (graph != null && graph is RecBgnCustPMWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnCustPMWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnCustPMWork[])graph).Length;
            }
            else if (graph is RecBgnCustPMWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品適用開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsApplyStaDate
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //メーカー希望小売価格
            serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
            //定価
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //単価算出掛率
            serInfo.MemberInfo.Add(typeof(double)); //UnitCalcRate
            //単価
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //適用開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //適用終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //お買得商品グループコード
            serInfo.MemberInfo.Add(typeof(Int16)); //BrgnGoodsGrpCode
            //表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayDivCode



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnCustPMWork)
            {
                RecBgnCustPMWork temp = (RecBgnCustPMWork)graph;

                SetRecBgnCustPMWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnCustPMWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnCustPMWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnCustPMWork temp in lst)
                {
                    SetRecBgnCustPMWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnCustPMWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  RecBgnCustPMWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustPMWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecBgnCustPMWork(System.IO.BinaryWriter writer, RecBgnCustPMWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write((Int32)temp.LogicalDeleteCode);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write((Int32)temp.GoodsMakerCd);
            //商品適用開始日
            writer.Write((Int32)temp.GoodsApplyStaDate);
            //得意先コード
            writer.Write((Int32)temp.CustomerCode);
            //管理拠点コード
            writer.Write(temp.MngSectionCode);
            //メーカー希望小売価格
            writer.Write((Int64)temp.MkrSuggestRtPric);
            //定価
            writer.Write((Int64)temp.ListPrice);
            //単価算出掛率
            writer.Write((double)temp.UnitCalcRate);
            //単価
            writer.Write((Int64)temp.UnitPrice);
            //適用開始日
            writer.Write((Int32)temp.ApplyStaDate);
            //適用終了日
            writer.Write((Int32)temp.ApplyEndDate);
            //お買得商品グループコード
            writer.Write(temp.BrgnGoodsGrpCode);
            //表示区分
            writer.Write(temp.DisplayDivCode);


        }

        /// <summary>
        ///  RecBgnCustPMWorkインスタンス取得
        /// </summary>
        /// <returns>RecBgnCustPMWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustPMWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecBgnCustPMWork GetRecBgnCustPMWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecBgnCustPMWork temp = new RecBgnCustPMWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品適用開始日
            temp.GoodsApplyStaDate = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //管理拠点コード
            temp.MngSectionCode = reader.ReadString();
            //メーカー希望小売価格
            temp.MkrSuggestRtPric = reader.ReadInt64();
            //定価
            temp.ListPrice = reader.ReadInt64();
            //単価算出掛率
            temp.UnitCalcRate = reader.ReadDouble();
            //単価
            temp.UnitPrice = reader.ReadInt64();
            //適用開始日
            temp.ApplyStaDate = reader.ReadInt32();
            //適用終了日
            temp.ApplyEndDate = reader.ReadInt32();
            //お買得商品グループコード
            temp.BrgnGoodsGrpCode = reader.ReadInt16();
            //表示区分
            temp.DisplayDivCode = reader.ReadInt32();



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
        /// <returns>RecBgnCustPMWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnCustPMWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnCustPMWork temp = GetRecBgnCustPMWork(reader, serInfo);
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
                    retValue = (RecBgnCustPMWork[])lst.ToArray(typeof(RecBgnCustPMWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
