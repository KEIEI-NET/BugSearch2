//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品設定マスタ抽出結果（PM側）ワーク
// プログラム概要   : お買い得商品設定マスタ抽出結果（PM側）ワークデータパラメータ
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
    /// public class name:   RecBgnGdsPMWork
    /// <summary>
    ///                      お買い得商品設定マスタ抽出結果（PM側）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   お買い得商品設定マスタ抽出結果（PM側）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGdsPMWork 
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

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerNm = "";

        /// <summary>商品名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _goodsName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>(PMで利用) 旧グループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>商品コメント</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _goodsComment = "";

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

        /// <summary>適合車種区分</summary>
        /// <remarks>0:適合車種なし,1:適合車種あり</remarks>
        private Int16 _modelFitDiv;

        /// <summary>得意先掛率グループコード</summary>
        /// <remarks>(PMで利用)</remarks>
        private Int32 _custRateGrpCode;

        /// <summary>表示区分</summary>
        /// <remarks>0:表示,1:非表示</remarks>
        private Int32 _displayDivCode;

        /// <summary>お買得商品グループコード</summary>
        /// <remarks>0:グループ無し</remarks>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>商品画像</summary>
        private Byte[] _goodsImage = new Byte[0];

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

        /// public propaty name  :  GoodsMakerNm
        /// <summary>商品メーカー名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカー名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコード</summary>
        /// <value>(PMで利用) 旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsComment
        /// <summary>商品コメント</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品コメント</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsComment
        {
            get { return _goodsComment; }
            set { _goodsComment = value; }
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

        /// public propaty name  :  ModelFitDiv
        /// <summary>適合車種区分</summary>
        /// <value>0:適合車種なし,1:適合車種あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適合車種区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ModelFitDiv
        {
            get { return _modelFitDiv; }
            set { _modelFitDiv = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコード</summary>
        /// <value>(PMで利用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  DisplayDivCode
        /// <summary>表示区分</summary>
        /// <value>0:表示,1:非表示</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
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

        /// public propaty name  :  GoodsImage
        /// <summary>商品画像</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品画像</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] GoodsImage
        {
            get { return _goodsImage; }
            set { _goodsImage = value; }
        }



        /// <summary>
        /// お買い得商品設定マスタ抽出結果（PM側）ワークコンストラクタ
        /// </summary>
        /// <returns>RecBgnGdsPMWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGdsPMWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecBgnGdsPMWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsPMWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecBgnGdsPMWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnGdsPMWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGdsPMWork || graph is ArrayList || graph is RecBgnGdsPMWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecBgnGdsPMWork).FullName));

            if (graph != null && graph is RecBgnGdsPMWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGdsPMWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGdsPMWork[])graph).Length;
            }
            else if (graph is RecBgnGdsPMWork)
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
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //商品コメント
            serInfo.MemberInfo.Add(typeof(string)); //GoodsComment
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
            //適合車種区分
            serInfo.MemberInfo.Add(typeof(Int16)); //ModelFitDiv
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayDivCode
            //お買得商品グループコード
            serInfo.MemberInfo.Add(typeof(Int16)); //BrgnGoodsGrpCode
            //商品画像
            serInfo.MemberInfo.Add(typeof(Byte[])); //GoodsImage



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGdsPMWork)
            {
                RecBgnGdsPMWork temp = (RecBgnGdsPMWork)graph;

                SetRecBgnGdsPMWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGdsPMWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGdsPMWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGdsPMWork temp in lst)
                {
                    SetRecBgnGdsPMWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGdsPMWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RecBgnGdsPMWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecBgnGdsPMWork(System.IO.BinaryWriter writer, RecBgnGdsPMWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write((Int32)temp.LogicalDeleteCode);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write((Int32)temp.GoodsMakerCd);
            //商品メーカー名称
            writer.Write(temp.GoodsMakerNm);
            //商品名称
            writer.Write(temp.GoodsName);
            //BLグループコード
            writer.Write((Int32)temp.BLGroupCode);
            //BL商品コード
            writer.Write((Int32)temp.BLGoodsCode);
            //商品コメント
            writer.Write(temp.GoodsComment);
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
            //適合車種区分
            writer.Write(temp.ModelFitDiv);
            //得意先掛率グループコード
            writer.Write((Int32)temp.CustRateGrpCode);
            //表示区分
            writer.Write((Int32)temp.DisplayDivCode);
            //お買得商品グループコード
            writer.Write(temp.BrgnGoodsGrpCode);
            //商品画像
            writer.Write(temp.GoodsImage.Length);
            writer.Write(temp.GoodsImage);


        }

        /// <summary>
        ///  RecBgnGdsPMWorkインスタンス取得
        /// </summary>
        /// <returns>RecBgnGdsPMWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecBgnGdsPMWork GetRecBgnGdsPMWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecBgnGdsPMWork temp = new RecBgnGdsPMWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品メーカー名称
            temp.GoodsMakerNm = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //商品コメント
            temp.GoodsComment = reader.ReadString();
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
            //適合車種区分
            temp.ModelFitDiv = reader.ReadInt16();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //表示区分
            temp.DisplayDivCode = reader.ReadInt32();
            //お買得商品グループコード
            temp.BrgnGoodsGrpCode = reader.ReadInt16();
            //商品画像
            int length = reader.ReadInt32();
            temp.GoodsImage = reader.ReadBytes(length);



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
        /// <returns>RecBgnGdsPMWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGdsPMWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGdsPMWork temp = GetRecBgnGdsPMWork(reader, serInfo);
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
                    retValue = (RecBgnGdsPMWork[])lst.ToArray(typeof(RecBgnGdsPMWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
