using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AlItmDspNmWork
    /// <summary>
    ///                      全体項目表示名称ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   全体項目表示名称ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2008/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AlItmDspNmWork : IFileHeader
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

        /// <summary>自宅TEL表示名称</summary>
        private string _homeTelNoDspName = "";

        /// <summary>勤務先TEL表示名称</summary>
        private string _officeTelNoDspName = "";

        /// <summary>携帯TEL表示名称</summary>
        private string _mobileTelNoDspName = "";

        /// <summary>その他TEL表示名称</summary>
        private string _otherTelNoDspName = "";

        /// <summary>自宅FAX表示名称</summary>
        private string _homeFaxNoDspName = "";

        /// <summary>勤務先FAX表示名称</summary>
        private string _officeFaxNoDspName = "";

        /// <summary>追加情報1表示名称</summary>
        private string _addInfo1DspName = "";

        /// <summary>追加情報2表示名称</summary>
        private string _addInfo2DspName = "";

        /// <summary>追加情報3表示名称</summary>
        private string _addInfo3DspName = "";

        /// <summary>結合表示名称</summary>
        private string _joinDspName = "";

        /// <summary>仕入率表示名称</summary>
        private string _stockRateDspName = "";

        /// <summary>原単価表示名称</summary>
        private string _unitCostDspName = "";

        /// <summary>粗利額表示名称</summary>
        private string _profitDspName = "";

        /// <summary>粗利率表示名称</summary>
        private string _profitRateDspName = "";

        /// <summary>外税表示名称</summary>
        /// <remarks>（外）、外税</remarks>
        private string _outTaxDspName = "";

        /// <summary>内税表示名称</summary>
        private string _inTaxDspName = "";

        /// <summary>定価表示名称</summary>
        /// <remarks>標準価格、定価</remarks>
        private string _listPriceDspName = "";

        /// <summary>納品書敬称初期値</summary>
        private string _deliHonorTtlDef = "";

        /// <summary>請求書敬称初期値</summary>
        private string _billHonorTtlDef = "";

        /// <summary>見積書敬称初期値</summary>
        private string _estmHonorTtlDef = "";

        /// <summary>発注書敬称初期値</summary>
        private string _rectHonorTtlDef = "";


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

        /// public propaty name  :  HomeTelNoDspName
        /// <summary>自宅TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自宅TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNoDspName
        {
            get { return _homeTelNoDspName; }
            set { _homeTelNoDspName = value; }
        }

        /// public propaty name  :  OfficeTelNoDspName
        /// <summary>勤務先TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   勤務先TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNoDspName
        {
            get { return _officeTelNoDspName; }
            set { _officeTelNoDspName = value; }
        }

        /// public propaty name  :  MobileTelNoDspName
        /// <summary>携帯TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   携帯TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MobileTelNoDspName
        {
            get { return _mobileTelNoDspName; }
            set { _mobileTelNoDspName = value; }
        }

        /// public propaty name  :  OtherTelNoDspName
        /// <summary>その他TEL表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   その他TEL表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OtherTelNoDspName
        {
            get { return _otherTelNoDspName; }
            set { _otherTelNoDspName = value; }
        }

        /// public propaty name  :  HomeFaxNoDspName
        /// <summary>自宅FAX表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自宅FAX表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNoDspName
        {
            get { return _homeFaxNoDspName; }
            set { _homeFaxNoDspName = value; }
        }

        /// public propaty name  :  OfficeFaxNoDspName
        /// <summary>勤務先FAX表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   勤務先FAX表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNoDspName
        {
            get { return _officeFaxNoDspName; }
            set { _officeFaxNoDspName = value; }
        }

        /// public propaty name  :  AddInfo1DspName
        /// <summary>追加情報1表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加情報1表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddInfo1DspName
        {
            get { return _addInfo1DspName; }
            set { _addInfo1DspName = value; }
        }

        /// public propaty name  :  AddInfo2DspName
        /// <summary>追加情報2表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加情報2表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddInfo2DspName
        {
            get { return _addInfo2DspName; }
            set { _addInfo2DspName = value; }
        }

        /// public propaty name  :  AddInfo3DspName
        /// <summary>追加情報3表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加情報3表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddInfo3DspName
        {
            get { return _addInfo3DspName; }
            set { _addInfo3DspName = value; }
        }

        /// public propaty name  :  JoinDspName
        /// <summary>結合表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDspName
        {
            get { return _joinDspName; }
            set { _joinDspName = value; }
        }

        /// public propaty name  :  StockRateDspName
        /// <summary>仕入率表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRateDspName
        {
            get { return _stockRateDspName; }
            set { _stockRateDspName = value; }
        }

        /// public propaty name  :  UnitCostDspName
        /// <summary>原単価表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitCostDspName
        {
            get { return _unitCostDspName; }
            set { _unitCostDspName = value; }
        }

        /// public propaty name  :  ProfitDspName
        /// <summary>粗利額表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProfitDspName
        {
            get { return _profitDspName; }
            set { _profitDspName = value; }
        }

        /// public propaty name  :  ProfitRateDspName
        /// <summary>粗利率表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProfitRateDspName
        {
            get { return _profitRateDspName; }
            set { _profitRateDspName = value; }
        }

        /// public propaty name  :  OutTaxDspName
        /// <summary>外税表示名称プロパティ</summary>
        /// <value>（外）、外税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   外税表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutTaxDspName
        {
            get { return _outTaxDspName; }
            set { _outTaxDspName = value; }
        }

        /// public propaty name  :  InTaxDspName
        /// <summary>内税表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   内税表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InTaxDspName
        {
            get { return _inTaxDspName; }
            set { _inTaxDspName = value; }
        }

        /// public propaty name  :  ListPriceDspName
        /// <summary>定価表示名称プロパティ</summary>
        /// <value>標準価格、定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPriceDspName
        {
            get { return _listPriceDspName; }
            set { _listPriceDspName = value; }
        }

        /// public propaty name  :  DeliHonorTtlDef
        /// <summary>納品書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliHonorTtlDef
        {
            get { return _deliHonorTtlDef; }
            set { _deliHonorTtlDef = value; }
        }

        /// public propaty name  :  BillHonorTtlDef
        /// <summary>請求書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillHonorTtlDef
        {
            get { return _billHonorTtlDef; }
            set { _billHonorTtlDef = value; }
        }

        /// public propaty name  :  EstmHonorTtlDef
        /// <summary>見積書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstmHonorTtlDef
        {
            get { return _estmHonorTtlDef; }
            set { _estmHonorTtlDef = value; }
        }

        /// public propaty name  :  RectHonorTtlDef
        /// <summary>発注書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RectHonorTtlDef
        {
            get { return _rectHonorTtlDef; }
            set { _rectHonorTtlDef = value; }
        }


        /// <summary>
        /// 全体項目表示名称ワークコンストラクタ
        /// </summary>
        /// <returns>AlItmDspNmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AlItmDspNmWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AlItmDspNmWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AlItmDspNmWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AlItmDspNmWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AlItmDspNmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AlItmDspNmWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AlItmDspNmWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AlItmDspNmWork || graph is ArrayList || graph is AlItmDspNmWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AlItmDspNmWork).FullName));

            if (graph != null && graph is AlItmDspNmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AlItmDspNmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AlItmDspNmWork[])graph).Length;
            }
            else if (graph is AlItmDspNmWork)
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
            //自宅TEL表示名称
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNoDspName
            //勤務先TEL表示名称
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNoDspName
            //携帯TEL表示名称
            serInfo.MemberInfo.Add(typeof(string)); //MobileTelNoDspName
            //その他TEL表示名称
            serInfo.MemberInfo.Add(typeof(string)); //OtherTelNoDspName
            //自宅FAX表示名称
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNoDspName
            //勤務先FAX表示名称
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNoDspName
            //追加情報1表示名称
            serInfo.MemberInfo.Add(typeof(string)); //AddInfo1DspName
            //追加情報2表示名称
            serInfo.MemberInfo.Add(typeof(string)); //AddInfo2DspName
            //追加情報3表示名称
            serInfo.MemberInfo.Add(typeof(string)); //AddInfo3DspName
            //結合表示名称
            serInfo.MemberInfo.Add(typeof(string)); //JoinDspName
            //仕入率表示名称
            serInfo.MemberInfo.Add(typeof(string)); //StockRateDspName
            //原単価表示名称
            serInfo.MemberInfo.Add(typeof(string)); //UnitCostDspName
            //粗利額表示名称
            serInfo.MemberInfo.Add(typeof(string)); //ProfitDspName
            //粗利率表示名称
            serInfo.MemberInfo.Add(typeof(string)); //ProfitRateDspName
            //外税表示名称
            serInfo.MemberInfo.Add(typeof(string)); //OutTaxDspName
            //内税表示名称
            serInfo.MemberInfo.Add(typeof(string)); //InTaxDspName
            //定価表示名称
            serInfo.MemberInfo.Add(typeof(string)); //ListPriceDspName
            //納品書敬称初期値
            serInfo.MemberInfo.Add(typeof(string)); //DeliHonorTtlDef
            //請求書敬称初期値
            serInfo.MemberInfo.Add(typeof(string)); //BillHonorTtlDef
            //見積書敬称初期値
            serInfo.MemberInfo.Add(typeof(string)); //EstmHonorTtlDef
            //発注書敬称初期値
            serInfo.MemberInfo.Add(typeof(string)); //RectHonorTtlDef


            serInfo.Serialize(writer, serInfo);
            if (graph is AlItmDspNmWork)
            {
                AlItmDspNmWork temp = (AlItmDspNmWork)graph;

                SetAlItmDspNmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AlItmDspNmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AlItmDspNmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AlItmDspNmWork temp in lst)
                {
                    SetAlItmDspNmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AlItmDspNmWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 30;

        /// <summary>
        ///  AlItmDspNmWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AlItmDspNmWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAlItmDspNmWork(System.IO.BinaryWriter writer, AlItmDspNmWork temp)
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
            //自宅TEL表示名称
            writer.Write(temp.HomeTelNoDspName);
            //勤務先TEL表示名称
            writer.Write(temp.OfficeTelNoDspName);
            //携帯TEL表示名称
            writer.Write(temp.MobileTelNoDspName);
            //その他TEL表示名称
            writer.Write(temp.OtherTelNoDspName);
            //自宅FAX表示名称
            writer.Write(temp.HomeFaxNoDspName);
            //勤務先FAX表示名称
            writer.Write(temp.OfficeFaxNoDspName);
            //追加情報1表示名称
            writer.Write(temp.AddInfo1DspName);
            //追加情報2表示名称
            writer.Write(temp.AddInfo2DspName);
            //追加情報3表示名称
            writer.Write(temp.AddInfo3DspName);
            //結合表示名称
            writer.Write(temp.JoinDspName);
            //仕入率表示名称
            writer.Write(temp.StockRateDspName);
            //原単価表示名称
            writer.Write(temp.UnitCostDspName);
            //粗利額表示名称
            writer.Write(temp.ProfitDspName);
            //粗利率表示名称
            writer.Write(temp.ProfitRateDspName);
            //外税表示名称
            writer.Write(temp.OutTaxDspName);
            //内税表示名称
            writer.Write(temp.InTaxDspName);
            //定価表示名称
            writer.Write(temp.ListPriceDspName);
            //納品書敬称初期値
            writer.Write(temp.DeliHonorTtlDef);
            //請求書敬称初期値
            writer.Write(temp.BillHonorTtlDef);
            //見積書敬称初期値
            writer.Write(temp.EstmHonorTtlDef);
            //発注書敬称初期値
            writer.Write(temp.RectHonorTtlDef);

        }

        /// <summary>
        ///  AlItmDspNmWorkインスタンス取得
        /// </summary>
        /// <returns>AlItmDspNmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AlItmDspNmWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AlItmDspNmWork GetAlItmDspNmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AlItmDspNmWork temp = new AlItmDspNmWork();

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
            //自宅TEL表示名称
            temp.HomeTelNoDspName = reader.ReadString();
            //勤務先TEL表示名称
            temp.OfficeTelNoDspName = reader.ReadString();
            //携帯TEL表示名称
            temp.MobileTelNoDspName = reader.ReadString();
            //その他TEL表示名称
            temp.OtherTelNoDspName = reader.ReadString();
            //自宅FAX表示名称
            temp.HomeFaxNoDspName = reader.ReadString();
            //勤務先FAX表示名称
            temp.OfficeFaxNoDspName = reader.ReadString();
            //追加情報1表示名称
            temp.AddInfo1DspName = reader.ReadString();
            //追加情報2表示名称
            temp.AddInfo2DspName = reader.ReadString();
            //追加情報3表示名称
            temp.AddInfo3DspName = reader.ReadString();
            //結合表示名称
            temp.JoinDspName = reader.ReadString();
            //仕入率表示名称
            temp.StockRateDspName = reader.ReadString();
            //原単価表示名称
            temp.UnitCostDspName = reader.ReadString();
            //粗利額表示名称
            temp.ProfitDspName = reader.ReadString();
            //粗利率表示名称
            temp.ProfitRateDspName = reader.ReadString();
            //外税表示名称
            temp.OutTaxDspName = reader.ReadString();
            //内税表示名称
            temp.InTaxDspName = reader.ReadString();
            //定価表示名称
            temp.ListPriceDspName = reader.ReadString();
            //納品書敬称初期値
            temp.DeliHonorTtlDef = reader.ReadString();
            //請求書敬称初期値
            temp.BillHonorTtlDef = reader.ReadString();
            //見積書敬称初期値
            temp.EstmHonorTtlDef = reader.ReadString();
            //発注書敬称初期値
            temp.RectHonorTtlDef = reader.ReadString();


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
        /// <returns>AlItmDspNmWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AlItmDspNmWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AlItmDspNmWork temp = GetAlItmDspNmWork(reader, serInfo);
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
                    retValue = (AlItmDspNmWork[])lst.ToArray(typeof(AlItmDspNmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
