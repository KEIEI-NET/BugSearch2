//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品（テキスト変換）
// プログラム概要   : 商品（テキスト変換）ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : 高陽
// 作 成 日  K2013/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsTextExpWork
    /// <summary>
    ///                      商品（テキスト変換）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品（テキスト変換）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/8/8</br>
    /// <br>Genarated Date   :   2013/09/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsTextExpWork
    {
        /// <summary>開始商品番号</summary>
        private string _goodsNoSt = "";

        /// <summary>終了商品番号</summary>
        private string _goodsNoEd = "";

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始登録日付</summary>
        private Int32 _updateDateSt;

        /// <summary>終了登録日付</summary>
        private Int32 _updateDateEd;

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";


        /// public propaty name  :  GoodsNoSt
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  UpdateDateSt
        /// <summary>開始登録日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始登録日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDateSt
        {
            get { return _updateDateSt; }
            set { _updateDateSt = value; }
        }

        /// public propaty name  :  UpdateDateEd
        /// <summary>終了登録日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了登録日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDateEd
        {
            get { return _updateDateEd; }
            set { _updateDateEd = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
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


        /// <summary>
        /// 商品（テキスト変換）ワークコンストラクタ
        /// </summary>
        /// <returns>GoodsTextExpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTextExpWork()
        {
        }

        /// <summary>
        /// 商品（テキスト変換）ワークコンストラクタ
        /// </summary>
        /// <param name="goodsNoSt">開始商品番号</param>
        /// <param name="goodsNoEd">終了商品番号</param>
        /// <param name="goodsMakerCdSt">開始商品メーカーコード</param>
        /// <param name="goodsMakerCdEd">終了商品メーカーコード</param>
        /// <param name="bLGoodsCodeSt">開始BL商品コード</param>
        /// <param name="bLGoodsCodeEd">終了BL商品コード</param>
        /// <param name="updateDateSt">開始登録日付</param>
        /// <param name="updateDateEd">終了登録日付</param>
        /// <param name="priceStartDate">価格開始日(YYYYMMDD)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <returns>GoodsTextExpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTextExpWork(string goodsNoSt, string goodsNoEd, Int32 goodsMakerCdSt, Int32 goodsMakerCdEd, Int32 bLGoodsCodeSt, Int32 bLGoodsCodeEd, Int32 updateDateSt, Int32 updateDateEd, Int32 priceStartDate, string enterpriseCode)
        {
            this._goodsNoSt = goodsNoSt;
            this._goodsNoEd = goodsNoEd;
            this._goodsMakerCdSt = goodsMakerCdSt;
            this._goodsMakerCdEd = goodsMakerCdEd;
            this._bLGoodsCodeSt = bLGoodsCodeSt;
            this._bLGoodsCodeEd = bLGoodsCodeEd;
            this._updateDateSt = updateDateSt;
            this._updateDateEd = updateDateEd;
            this._priceStartDate = priceStartDate;
            this._enterpriseCode = enterpriseCode;

        }

        /// <summary>
        /// 商品（テキスト変換）ワーク複製処理
        /// </summary>
        /// <returns>GoodsTextExpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsTextExpWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTextExpWork Clone()
        {
            return new GoodsTextExpWork(this._goodsNoSt, this._goodsNoEd, this._goodsMakerCdSt, this._goodsMakerCdEd, this._bLGoodsCodeSt, this._bLGoodsCodeEd, this._updateDateSt, this._updateDateEd, this._priceStartDate, this._enterpriseCode);
        }

        /// <summary>
        /// 商品（テキスト変換）ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsTextExpWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsTextExpWork target)
        {
            return ((this.GoodsNoSt == target.GoodsNoSt)
                 && (this.GoodsNoEd == target.GoodsNoEd)
                 && (this.GoodsMakerCdSt == target.GoodsMakerCdSt)
                 && (this.GoodsMakerCdEd == target.GoodsMakerCdEd)
                 && (this.BLGoodsCodeSt == target.BLGoodsCodeSt)
                 && (this.BLGoodsCodeEd == target.BLGoodsCodeEd)
                 && (this.UpdateDateSt == target.UpdateDateSt)
                 && (this.UpdateDateEd == target.UpdateDateEd)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.EnterpriseCode == target.EnterpriseCode));
        }

        /// <summary>
        /// 商品（テキスト変換）ワーク比較処理
        /// </summary>
        /// <param name="goodsTextExp1">
        ///                    比較するGoodsTextExpWorkクラスのインスタンス
        /// </param>
        /// <param name="goodsTextExp2">比較するGoodsTextExpWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsTextExpWork goodsTextExp1, GoodsTextExpWork goodsTextExp2)
        {
            return ((goodsTextExp1.GoodsNoSt == goodsTextExp2.GoodsNoSt)
                 && (goodsTextExp1.GoodsNoEd == goodsTextExp2.GoodsNoEd)
                 && (goodsTextExp1.GoodsMakerCdSt == goodsTextExp2.GoodsMakerCdSt)
                 && (goodsTextExp1.GoodsMakerCdEd == goodsTextExp2.GoodsMakerCdEd)
                 && (goodsTextExp1.BLGoodsCodeSt == goodsTextExp2.BLGoodsCodeSt)
                 && (goodsTextExp1.BLGoodsCodeEd == goodsTextExp2.BLGoodsCodeEd)
                 && (goodsTextExp1.UpdateDateSt == goodsTextExp2.UpdateDateSt)
                 && (goodsTextExp1.UpdateDateEd == goodsTextExp2.UpdateDateEd)
                 && (goodsTextExp1.PriceStartDate == goodsTextExp2.PriceStartDate)
                 && (goodsTextExp1.EnterpriseCode == goodsTextExp2.EnterpriseCode));
        }
        /// <summary>
        /// 商品（テキスト変換）ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsTextExpWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsTextExpWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.GoodsNoSt != target.GoodsNoSt) resList.Add("GoodsNoSt");
            if (this.GoodsNoEd != target.GoodsNoEd) resList.Add("GoodsNoEd");
            if (this.GoodsMakerCdSt != target.GoodsMakerCdSt) resList.Add("GoodsMakerCdSt");
            if (this.GoodsMakerCdEd != target.GoodsMakerCdEd) resList.Add("GoodsMakerCdEd");
            if (this.BLGoodsCodeSt != target.BLGoodsCodeSt) resList.Add("BLGoodsCodeSt");
            if (this.BLGoodsCodeEd != target.BLGoodsCodeEd) resList.Add("BLGoodsCodeEd");
            if (this.UpdateDateSt != target.UpdateDateSt) resList.Add("UpdateDateSt");
            if (this.UpdateDateEd != target.UpdateDateEd) resList.Add("UpdateDateEd");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");

            return resList;
        }

        /// <summary>
        /// 商品（テキスト変換）ワーク比較処理
        /// </summary>
        /// <param name="goodsTextExp1">比較するGoodsTextExpWorkクラスのインスタンス</param>
        /// <param name="goodsTextExp2">比較するGoodsTextExpWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsTextExpWork goodsTextExp1, GoodsTextExpWork goodsTextExp2)
        {
            ArrayList resList = new ArrayList();
            if (goodsTextExp1.GoodsNoSt != goodsTextExp2.GoodsNoSt) resList.Add("GoodsNoSt");
            if (goodsTextExp1.GoodsNoEd != goodsTextExp2.GoodsNoEd) resList.Add("GoodsNoEd");
            if (goodsTextExp1.GoodsMakerCdSt != goodsTextExp2.GoodsMakerCdSt) resList.Add("GoodsMakerCdSt");
            if (goodsTextExp1.GoodsMakerCdEd != goodsTextExp2.GoodsMakerCdEd) resList.Add("GoodsMakerCdEd");
            if (goodsTextExp1.BLGoodsCodeSt != goodsTextExp2.BLGoodsCodeSt) resList.Add("BLGoodsCodeSt");
            if (goodsTextExp1.BLGoodsCodeEd != goodsTextExp2.BLGoodsCodeEd) resList.Add("BLGoodsCodeEd");
            if (goodsTextExp1.UpdateDateSt != goodsTextExp2.UpdateDateSt) resList.Add("UpdateDateSt");
            if (goodsTextExp1.UpdateDateEd != goodsTextExp2.UpdateDateEd) resList.Add("UpdateDateEd");
            if (goodsTextExp1.PriceStartDate != goodsTextExp2.PriceStartDate) resList.Add("PriceStartDate");
            if (goodsTextExp1.EnterpriseCode != goodsTextExp2.EnterpriseCode) resList.Add("EnterpriseCode");

            return resList;
        }
    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsTextExpWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsTextExpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsTextExpWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsTextExpWork || graph is ArrayList || graph is GoodsTextExpWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsTextExpWork).FullName));

            if (graph != null && graph is GoodsTextExpWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsTextExpWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsTextExpWork[])graph).Length;
            }
            else if (graph is GoodsTextExpWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //開始商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoSt
            //終了商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoEd
            //開始商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdSt
            //終了商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdEd
            //開始BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeSt
            //終了BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeEd
            //開始登録日付
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDateSt
            //終了登録日付
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDateEd
            //価格開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsTextExpWork)
            {
                GoodsTextExpWork temp = (GoodsTextExpWork)graph;

                SetGoodsTextExpWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsTextExpWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsTextExpWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsTextExpWork temp in lst)
                {
                    SetGoodsTextExpWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsTextExpWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  GoodsTextExpWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsTextExpWork(System.IO.BinaryWriter writer, GoodsTextExpWork temp)
        {
            //開始商品番号
            writer.Write(temp.GoodsNoSt);
            //終了商品番号
            writer.Write(temp.GoodsNoEd);
            //開始商品メーカーコード
            writer.Write(temp.GoodsMakerCdSt);
            //終了商品メーカーコード
            writer.Write(temp.GoodsMakerCdEd);
            //開始BL商品コード
            writer.Write(temp.BLGoodsCodeSt);
            //終了BL商品コード
            writer.Write(temp.BLGoodsCodeEd);
            //開始登録日付
            writer.Write(temp.UpdateDateSt);
            //終了登録日付
            writer.Write(temp.UpdateDateEd);
            //価格開始日
            writer.Write(temp.PriceStartDate);
            //企業コード
            writer.Write(temp.EnterpriseCode);

        }

        /// <summary>
        ///  GoodsTextExpWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsTextExpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsTextExpWork GetGoodsTextExpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsTextExpWork temp = new GoodsTextExpWork();

            //開始商品番号
            temp.GoodsNoSt = reader.ReadString();
            //終了商品番号
            temp.GoodsNoEd = reader.ReadString();
            //開始商品メーカーコード
            temp.GoodsMakerCdSt = reader.ReadInt32();
            //終了商品メーカーコード
            temp.GoodsMakerCdEd = reader.ReadInt32();
            //開始BL商品コード
            temp.BLGoodsCodeSt = reader.ReadInt32();
            //終了BL商品コード
            temp.BLGoodsCodeEd = reader.ReadInt32();
            //開始登録日付
            temp.UpdateDateSt = reader.ReadInt32();
            //終了登録日付
            temp.UpdateDateEd = reader.ReadInt32();
            //価格開始日
            temp.PriceStartDate = reader.ReadInt32();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();


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
        /// <returns>GoodsTextExpWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsTextExpWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsTextExpWork temp = GetGoodsTextExpWork(reader, serInfo);
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
                    retValue = (GoodsTextExpWork[])lst.ToArray(typeof(GoodsTextExpWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

