using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePrtItmSetPrmWork
    /// <summary>
    ///                      自由帳票印字項目パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票印字項目パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/7/23</br>
    /// <br>Genarated Date   :   2007/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePrtItmSetPrmWork
    {
        /// <summary>
        /// 自由帳票印字項目パラメータワークコンストラクタ
        /// </summary>
        /// <returns>FrePrtItmSetPrmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePrtItmSetPrmWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePrtItmSetPrmWork()
        {
        }

        /// <summary>
        /// コンストラクタ：オーバーロード(+1)
        /// </summary>
        /// <param name="fileNm">ファイル名称</param>
        /// <param name="ddName">DD名称</param>
        /// <param name="ddCharCnt">DD桁数</param>
        /// <param name="cipherFlg">暗号化フラグ</param>
        /// <param name="extractionItdedFlg">抽出対象フラグ</param>
        public FrePrtItmSetPrmWork(string fileNm,string ddName, int ddCharCnt,int cipherFlg,int extractionItdedFlg)
		{
            _fileNm = fileNm;
            _dDName = ddName;
            _dDCharCnt = ddCharCnt;
            _cipherFlg = cipherFlg;
            _extractionItdedFlg = extractionItdedFlg;
        }

        /// <summary>ファイル名称</summary>
        /// <remarks>DBのテーブルID</remarks>
        private string _fileNm = "";

        /// <summary>DD名称</summary>
        /// <remarks>小文字で登録</remarks>
        private string _dDName = "";

        /// <summary>DD桁数</summary>
        private Int32 _dDCharCnt;

        /// <summary>暗号化フラグ</summary>
        /// <remarks>0:暗号化無　1:暗号化有</remarks>
        private Int32 _cipherFlg;

        /// <summary>抽出対象フラグ</summary>
        /// <remarks>0:非対象 1:対象    (項目IDは仮)</remarks>
        private Int32 _extractionItdedFlg;


        /// public propaty name  :  FileNm
        /// <summary>ファイル名称プロパティ</summary>
        /// <value>DBのテーブルID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileNm
        {
            get { return _fileNm; }
            set { _fileNm = value; }
        }

        /// public propaty name  :  DDName
        /// <summary>DD名称プロパティ</summary>
        /// <value>小文字で登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DD名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DDName
        {
            get { return _dDName; }
            set { _dDName = value; }
        }

        /// public propaty name  :  DDCharCnt
        /// <summary>DD桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DD桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DDCharCnt
        {
            get { return _dDCharCnt; }
            set { _dDCharCnt = value; }
        }

        /// public propaty name  :  CipherFlg
        /// <summary>暗号化フラグプロパティ</summary>
        /// <value>0:暗号化無　1:暗号化有</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   暗号化フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CipherFlg
        {
            get { return _cipherFlg; }
            set { _cipherFlg = value; }
        }

        /// public propaty name  :  ExtractionItdedFlg
        /// <summary>抽出対象フラグプロパティ</summary>
        /// <value>0:非対象 1:対象    (項目IDは仮)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出対象フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExtractionItdedFlg
        {
            get { return _extractionItdedFlg; }
            set { _extractionItdedFlg = value; }
        }
    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FrePrtItmSetPrmWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FrePrtItmSetPrmWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FrePrtItmSetPrmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ
        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePrtItmSetPrmWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  FrePrtItmSetPrmWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is FrePrtItmSetPrmWork || graph is ArrayList || graph is FrePrtItmSetPrmWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(FrePrtItmSetPrmWork).FullName));

            if (graph != null && graph is FrePrtItmSetPrmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePrtItmSetPrmWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is FrePrtItmSetPrmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePrtItmSetPrmWork[])graph).Length;
            }
            else if (graph is FrePrtItmSetPrmWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //ファイル名称
            serInfo.MemberInfo.Add(typeof(string)); //FileNm
            //DD名称
            serInfo.MemberInfo.Add(typeof(string)); //DDName
            //DD桁数
            serInfo.MemberInfo.Add(typeof(Int32)); //DDCharCnt
            //暗号化フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CipherFlg
            //抽出対象フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //ExtraTrgFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is FrePrtItmSetPrmWork)
            {
                FrePrtItmSetPrmWork temp = (FrePrtItmSetPrmWork)graph;

                SetFrePrtItmSetPrmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is FrePrtItmSetPrmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((FrePrtItmSetPrmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (FrePrtItmSetPrmWork temp in lst)
                {
                    SetFrePrtItmSetPrmWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// FrePrtItmSetPrmWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  FrePrtItmSetPrmWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePrtItmSetPrmWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFrePrtItmSetPrmWork(System.IO.BinaryWriter writer, FrePrtItmSetPrmWork temp)
        {
            //ファイル名称
            writer.Write(temp.FileNm);
            //DD名称
            writer.Write(temp.DDName);
            //DD桁数
            writer.Write(temp.DDCharCnt);
            //暗号化フラグ
            writer.Write(temp.CipherFlg);
            //抽出対象フラグ
            writer.Write(temp.ExtractionItdedFlg);

        }

        /// <summary>
        ///  FrePrtItmSetPrmWorkインスタンス取得
        /// </summary>
        /// <returns>FrePrtItmSetPrmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePrtItmSetPrmWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FrePrtItmSetPrmWork GetFrePrtItmSetPrmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FrePrtItmSetPrmWork temp = new FrePrtItmSetPrmWork();

            //ファイル名称
            temp.FileNm = reader.ReadString();
            //DD名称
            temp.DDName = reader.ReadString();
            //DD桁数
            temp.DDCharCnt = reader.ReadInt32();
            //暗号化フラグ
            temp.CipherFlg = reader.ReadInt32();
            //抽出対象フラグ
            temp.ExtractionItdedFlg = reader.ReadInt32();


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
        /// <returns>FrePrtItmSetPrmWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePrtItmSetPrmWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                FrePrtItmSetPrmWork temp = GetFrePrtItmSetPrmWork(reader, serInfo);
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
                    retValue = (FrePrtItmSetPrmWork[])lst.ToArray(typeof(FrePrtItmSetPrmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}