//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCCキャンペーンメッセージ設定抽出結果ワーク
// プログラム概要   : PCCキャンペーンメッセージ設定抽出結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.08.11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PccCpMsgStWork
    /// <summary>
    ///                      PCCキャンペーンメッセージ設定抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCCキャンペーンメッセージ設定抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.08.11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PccCpMsgStWork  
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

        /// <summary>キャンペーンコード</summary>
        private Int32 _campaignCode;

        /// <summary>適用開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>適用終了日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>PCCメッセージ本文</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccMsgDocCnts = "";

        /// <summary>キャンペーン名称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _campaignName = "";

        /// <summary>キャンペーン対象区分</summary>
        /// <remarks>0:全得意先 1:対象得意先</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>更新区分</summary>
        /// <remarks>0:新規 1:更新 2:削除</remarks>
        private Int32 _updateFlag;


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

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
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

        /// public propaty name  :  PccMsgDocCnts
        /// <summary>PCCメッセージ本文プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCCメッセージ本文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccMsgDocCnts
        {
            get { return _pccMsgDocCnts; }
            set { _pccMsgDocCnts = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>キャンペーン名称プロパティ</summary>
        /// <value>(半角全角混在)</value>
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
        /// <value>0:全得意先 1:対象得意先</value>
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

        /// public propaty name  :  UpdateFlag
        /// <summary>更新区分プロパティ</summary>
        /// <value>0:新規 1:更新 2:削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }


        /// <summary>
        /// PCCキャンペーンメッセージ設定ワークコンストラクタ
        /// </summary>
        /// <returns>PccCpMsgStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCpMsgStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PccCpMsgStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PccCpMsgStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PccCpMsgStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PccCpMsgStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PccCpMsgStWork || graph is ArrayList || graph is PccCpMsgStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PccCpMsgStWork).FullName));

            if (graph != null && graph is PccCpMsgStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PccCpMsgStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PccCpMsgStWork[])graph).Length;
            }
            else if (graph is PccCpMsgStWork)
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
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //適用開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //適用終了日
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //PCCメッセージ本文
            serInfo.MemberInfo.Add(typeof(string)); //PccMsgDocCnts
            //キャンペーン名称
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //キャンペーン対象区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignObjDiv
            //更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateFlag


            serInfo.Serialize(writer, serInfo);
            if (graph is PccCpMsgStWork)
            {
                PccCpMsgStWork temp = (PccCpMsgStWork)graph;

                SetPccCpMsgStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PccCpMsgStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PccCpMsgStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PccCpMsgStWork temp in lst)
                {
                    SetPccCpMsgStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PccCpMsgStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  PccCpMsgStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPccCpMsgStWork(System.IO.BinaryWriter writer, PccCpMsgStWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //適用開始日
            writer.Write(temp.ApplyStaDate);
            //適用終了日
            writer.Write(temp.ApplyEndDate);
            //PCCメッセージ本文
            writer.Write(temp.PccMsgDocCnts);
            //キャンペーン名称
            writer.Write(temp.CampaignName);
            //キャンペーン対象区分
            writer.Write(temp.CampaignObjDiv);
            //更新区分
            writer.Write(temp.UpdateFlag);

        }

        /// <summary>
        ///  PccCpMsgStWorkインスタンス取得
        /// </summary>
        /// <returns>PccCpMsgStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PccCpMsgStWork GetPccCpMsgStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PccCpMsgStWork temp = new PccCpMsgStWork();

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
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //適用開始日
            temp.ApplyStaDate = reader.ReadInt32();
            //適用終了日
            temp.ApplyEndDate = reader.ReadInt32();
            //PCCメッセージ本文
            temp.PccMsgDocCnts = reader.ReadString();
            //キャンペーン名称
            temp.CampaignName = reader.ReadString();
            //キャンペーン対象区分
            temp.CampaignObjDiv = reader.ReadInt32();
            //更新区分
            temp.UpdateFlag = reader.ReadInt32();


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
        /// <returns>PccCpMsgStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCpMsgStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PccCpMsgStWork temp = GetPccCpMsgStWork(reader, serInfo);
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
                    retValue = (PccCpMsgStWork[])lst.ToArray(typeof(PccCpMsgStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
