﻿using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   IOWriteMAHNBReadWork
    /// <summary>
    ///                      売上データ(IOWriteMAHNBRead)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データ(IOWriteMAHNBRead)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br></br>
    /// <br>note             :   </br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/09/27</br>
    /// <br>Genarated Date   :   </br>
    /// <br>Update Note      :   障害対応(「受注計上残区分：残さない」で計上した売上伝票が伝票修正で呼出せない障害の修正)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMAHNBReadWork 
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _salesSlipNum = "";

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</remarks>
        private Int32 _salesGoodsCd;

        // --- ADD 2012/09/27 y.wakita ----->>>>>
        /// <summary>論理削除区分フラグ</summary>
        /// <remarks>0:条件とする,1:条件としない</remarks>
        private Int32 _logicalDeleteCodeFlg;
        // --- ADD 2012/09/27 y.wakita -----<<<<<

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>売上商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        // --- ADD 2012/09/27 y.wakita ----->>>>>
        /// public propaty name  :  logicalDeleteCodeFlg
        /// <summary>論理削除区分フラグプロパティ</summary>
        /// <value>0:条件とする,1:条件としない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCodeFlg
        {
            get { return _logicalDeleteCodeFlg; }
            set { _logicalDeleteCodeFlg = value; }
        }
        // --- ADD 2012/09/27 y.wakita -----<<<<<

        /// <summary>
        /// 売上データ(IOWriteMAHNBRead)ワークコンストラクタ
        /// </summary>
        /// <returns>IOWriteMAHNBReadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMAHNBReadWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public IOWriteMAHNBReadWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>IOWriteMAHNBReadWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   IOWriteMAHNBReadWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class IOWriteMAHNBReadWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMAHNBReadWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMAHNBReadWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMAHNBReadWork || graph is ArrayList || graph is IOWriteMAHNBReadWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(IOWriteMAHNBReadWork).FullName));

            if (graph != null && graph is IOWriteMAHNBReadWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMAHNBReadWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMAHNBReadWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMAHNBReadWork[])graph).Length;
            }
            else if (graph is IOWriteMAHNBReadWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //赤伝区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //売上伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //売上商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            // --- ADD 2012/09/27 y.wakita ----->>>>>
            //論理削除区分フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCodeFlg
            // --- ADD 2012/09/27 y.wakita -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMAHNBReadWork)
            {
                IOWriteMAHNBReadWork temp = (IOWriteMAHNBReadWork)graph;

                SetIOWriteMAHNBReadWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMAHNBReadWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMAHNBReadWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMAHNBReadWork temp in lst)
                {
                    SetIOWriteMAHNBReadWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMAHNBReadWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD 2012/09/27 y.wakita ----->>>>>
        //private const int currentMemberCount = 6;
        private const int currentMemberCount = 7;
        // --- UPD 2012/09/27 y.wakita -----<<<<<

        /// <summary>
        ///  IOWriteMAHNBReadWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMAHNBReadWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetIOWriteMAHNBReadWork(System.IO.BinaryWriter writer, IOWriteMAHNBReadWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //赤伝区分
            writer.Write(temp.DebitNoteDiv);
            //売上伝票区分
            writer.Write(temp.SalesSlipCd);
            //売上商品区分
            writer.Write(temp.SalesGoodsCd);
            // --- ADD 2012/09/27 y.wakita ----->>>>>
            //論理削除区分フラグ
            writer.Write(temp.LogicalDeleteCodeFlg);
            // --- ADD 2012/09/27 y.wakita -----<<<<<
        }

        /// <summary>
        ///  IOWriteMAHNBReadWorkインスタンス取得
        /// </summary>
        /// <returns>IOWriteMAHNBReadWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMAHNBReadWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private IOWriteMAHNBReadWork GetIOWriteMAHNBReadWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            IOWriteMAHNBReadWork temp = new IOWriteMAHNBReadWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //売上伝票区分
            temp.SalesSlipCd = reader.ReadInt32();
            //売上商品区分
            temp.SalesGoodsCd = reader.ReadInt32();
            // --- ADD 2012/09/27 y.wakita ----->>>>>
            //論理削除区分フラグ
            temp.LogicalDeleteCodeFlg = reader.ReadInt32();
            // --- ADD 2012/09/27 y.wakita -----<<<<<

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
        /// <returns>IOWriteMAHNBReadWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   IOWriteMAHNBReadWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMAHNBReadWork temp = GetIOWriteMAHNBReadWork(reader, serInfo);
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
                    retValue = (IOWriteMAHNBReadWork[])lst.ToArray(typeof(IOWriteMAHNBReadWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
