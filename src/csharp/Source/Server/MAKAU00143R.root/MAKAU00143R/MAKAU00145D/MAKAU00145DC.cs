using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentAddUpHisWork
    /// <summary>
    ///                      支払締更新履歴ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   支払締更新履歴ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/8  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   コンバート処理区分</br>
    /// <br>Update Note      :   2008/10/02  長内</br>
    /// <br>                 :   ○項目追加（キー変更）</br>
    /// <br>                 :   データ更新日時</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentAddUpHisWork : IFileHeader
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

        /// <summary>計上拠点コード</summary>
        /// <remarks>空白は全拠点の一括締め</remarks>
        private string _addUpSecCode = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>０の場合は一括締め</remarks>
        private Int32 _supplierCd;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  支払締次更新対象となった年月日</remarks>
        private DateTime _cAddUpUpdDate;

        /// <summary>締次更新年月</summary>
        /// <remarks>"YYYYMM"    支払締次更新対象となった年月</remarks>
        private DateTime _cAddUpUpdYearMonth;

        /// <summary>締次更新実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>前回締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>データ更新日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _dataUpdateDateTime;

        /// <summary>処理区分</summary>
        /// <remarks>0:更新処理 1:解除処理</remarks>
        private Int32 _procDivCd;

        /// <summary>エラーステータス</summary>
        /// <remarks>0:正常　1:エラー</remarks>
        private Int32 _errorStatus;

        /// <summary>履歴制御区分</summary>
        /// <remarks>0:確定 1:未確定(履歴情報)</remarks>
        private Int32 _histCtlCd;

        /// <summary>処理結果</summary>
        /// <remarks>処理結果をセット　例）エラーステータス0の時「正常終了」</remarks>
        private string _procResult = "";

        /// <summary>コンバート処理区分</summary>
        /// <remarks>0:通常　1:コンバートデータ</remarks>
        private Int32 _convertProcessDivCd;


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>空白は全拠点の一括締め</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>０の場合は一括締め</value>
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

        /// public propaty name  :  StartCAddUpUpdDate
        /// <summary>締次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartCAddUpUpdDate
        {
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }

        /// public propaty name  :  CAddUpUpdDate
        /// <summary>締次更新年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  支払締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CAddUpUpdDate
        {
            get { return _cAddUpUpdDate; }
            set { _cAddUpUpdDate = value; }
        }

        /// public propaty name  :  CAddUpUpdYearMonth
        /// <summary>締次更新年月プロパティ</summary>
        /// <value>"YYYYMM"    支払締次更新対象となった年月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CAddUpUpdYearMonth
        {
            get { return _cAddUpUpdYearMonth; }
            set { _cAddUpUpdYearMonth = value; }
        }

        /// public propaty name  :  CAddUpUpdExecDate
        /// <summary>締次更新実行年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新実行年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CAddUpUpdExecDate
        {
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

        /// public propaty name  :  LastCAddUpUpdDate
        /// <summary>前回締次更新年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  前回締次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回締次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastCAddUpUpdDate
        {
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>データ更新日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }

        /// public propaty name  :  ProcDivCd
        /// <summary>処理区分プロパティ</summary>
        /// <value>0:更新処理 1:解除処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDivCd
        {
            get { return _procDivCd; }
            set { _procDivCd = value; }
        }

        /// public propaty name  :  ErrorStatus
        /// <summary>エラーステータスプロパティ</summary>
        /// <value>0:正常　1:エラー</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorStatus
        {
            get { return _errorStatus; }
            set { _errorStatus = value; }
        }

        /// public propaty name  :  HistCtlCd
        /// <summary>履歴制御区分プロパティ</summary>
        /// <value>0:確定 1:未確定(履歴情報)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   履歴制御区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HistCtlCd
        {
            get { return _histCtlCd; }
            set { _histCtlCd = value; }
        }

        /// public propaty name  :  ProcResult
        /// <summary>処理結果プロパティ</summary>
        /// <value>処理結果をセット　例）エラーステータス0の時「正常終了」</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理結果プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProcResult
        {
            get { return _procResult; }
            set { _procResult = value; }
        }

        /// public propaty name  :  ConvertProcessDivCd
        /// <summary>コンバート処理区分プロパティ</summary>
        /// <value>0:通常　1:コンバートデータ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンバート処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConvertProcessDivCd
        {
            get { return _convertProcessDivCd; }
            set { _convertProcessDivCd = value; }
        }


        /// <summary>
        /// 支払締更新履歴ワークコンストラクタ
        /// </summary>
        /// <returns>PaymentAddUpHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentAddUpHisWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PaymentAddUpHisWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PaymentAddUpHisWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PaymentAddUpHisWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PaymentAddUpHisWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentAddUpHisWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PaymentAddUpHisWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PaymentAddUpHisWork || graph is ArrayList || graph is PaymentAddUpHisWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PaymentAddUpHisWork).FullName));

            if (graph != null && graph is PaymentAddUpHisWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PaymentAddUpHisWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PaymentAddUpHisWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PaymentAddUpHisWork[])graph).Length;
            }
            else if (graph is PaymentAddUpHisWork)
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
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //締次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdDate
            //締次更新年月
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdYearMonth
            //締次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //前回締次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //データ更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime
            //処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcDivCd
            //エラーステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorStatus
            //履歴制御区分
            serInfo.MemberInfo.Add(typeof(Int32)); //HistCtlCd
            //処理結果
            serInfo.MemberInfo.Add(typeof(string)); //ProcResult
            //コンバート処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ConvertProcessDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is PaymentAddUpHisWork)
            {
                PaymentAddUpHisWork temp = (PaymentAddUpHisWork)graph;

                SetPaymentAddUpHisWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PaymentAddUpHisWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PaymentAddUpHisWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PaymentAddUpHisWork temp in lst)
                {
                    SetPaymentAddUpHisWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PaymentAddUpHisWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 21;

        /// <summary>
        ///  PaymentAddUpHisWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentAddUpHisWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPaymentAddUpHisWork(System.IO.BinaryWriter writer, PaymentAddUpHisWork temp)
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
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //締次更新開始年月日
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //締次更新年月日
            writer.Write((Int64)temp.CAddUpUpdDate.Ticks);
            //締次更新年月
            writer.Write((Int64)temp.CAddUpUpdYearMonth.Ticks);
            //締次更新実行年月日
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //前回締次更新年月日
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //データ更新日時
            writer.Write((Int64)temp.DataUpdateDateTime.Ticks);
            //処理区分
            writer.Write(temp.ProcDivCd);
            //エラーステータス
            writer.Write(temp.ErrorStatus);
            //履歴制御区分
            writer.Write(temp.HistCtlCd);
            //処理結果
            writer.Write(temp.ProcResult);
            //コンバート処理区分
            writer.Write(temp.ConvertProcessDivCd);

        }

        /// <summary>
        ///  PaymentAddUpHisWorkインスタンス取得
        /// </summary>
        /// <returns>PaymentAddUpHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentAddUpHisWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PaymentAddUpHisWork GetPaymentAddUpHisWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PaymentAddUpHisWork temp = new PaymentAddUpHisWork();

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
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //締次更新開始年月日
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //締次更新年月日
            temp.CAddUpUpdDate = new DateTime(reader.ReadInt64());
            //締次更新年月
            temp.CAddUpUpdYearMonth = new DateTime(reader.ReadInt64());
            //締次更新実行年月日
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //前回締次更新年月日
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //データ更新日時
            temp.DataUpdateDateTime = new DateTime(reader.ReadInt64());
            //処理区分
            temp.ProcDivCd = reader.ReadInt32();
            //エラーステータス
            temp.ErrorStatus = reader.ReadInt32();
            //履歴制御区分
            temp.HistCtlCd = reader.ReadInt32();
            //処理結果
            temp.ProcResult = reader.ReadString();
            //コンバート処理区分
            temp.ConvertProcessDivCd = reader.ReadInt32();


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
        /// <returns>PaymentAddUpHisWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentAddUpHisWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PaymentAddUpHisWork temp = GetPaymentAddUpHisWork(reader, serInfo);
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
                    retValue = (PaymentAddUpHisWork[])lst.ToArray(typeof(PaymentAddUpHisWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
