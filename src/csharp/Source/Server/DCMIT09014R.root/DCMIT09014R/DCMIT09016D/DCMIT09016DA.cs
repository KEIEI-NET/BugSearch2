using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EstimateDefSetWork
    /// <summary>
    ///                      見積初期値設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   見積初期値設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EstimateDefSetWork : IFileHeader
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>消費税印刷区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _consTaxPrintDiv;

        /// <summary>定価印刷区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _listPricePrintDiv;

        /// <summary>見積書番号採番区分</summary>
        /// <remarks>0:有り　1:無し</remarks>
        private Int32 _estmFormNoPickDiv;

        /// <summary>見積タイトル１</summary>
        private string _estimateTitle1 = "";


        /// <summary>見積備考１</summary>
        private string _estimateNote1 = "";

        /// <summary>見積備考２</summary>
        private string _estimateNote2 = "";

        /// <summary>見積備考３</summary>
        private string _estimateNote3 = "";


        /// <summary>見積書発行区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _estimatePrtDiv;

        /// <summary>ＦＡＸ見積区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _faxEstimatetDiv;

        /// <summary>品番印字区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _partsNoPrtCd;

        /// <summary>オプション印字区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _optionPringDivCd;

        /// <summary>部品選択区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _partsSelectDivCd;

        /// <summary>部品検索区分</summary>
        /// <remarks>0:部品検索,1:品番検索</remarks>
        private Int32 _partsSearchDivCd;

        /// <summary>見積データ作成区分</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _estimateDtCreateDiv;

        /// <summary>見積書有効期限</summary>
        private Int32 _estimateValidityTerm;

        /// <summary>掛率使用区分</summary>
        /// <remarks>0:売価＝定価 1:掛率指定,2:掛率設定</remarks>
        private Int32 _rateUseCode;


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

        /// public propaty name  :  ConsTaxPrintDiv
        /// <summary>消費税印刷区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxPrintDiv
        {
            get { return _consTaxPrintDiv; }
            set { _consTaxPrintDiv = value; }
        }

        /// public propaty name  :  ListPricePrintDiv
        /// <summary>定価印刷区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPricePrintDiv
        {
            get { return _listPricePrintDiv; }
            set { _listPricePrintDiv = value; }
        }

        /// public propaty name  :  EstmFormNoPickDiv
        /// <summary>見積書番号採番区分プロパティ</summary>
        /// <value>0:有り　1:無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書番号採番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstmFormNoPickDiv
        {
            get { return _estmFormNoPickDiv; }
            set { _estmFormNoPickDiv = value; }
        }



        /// public propaty name  :  EstimateTitle1
        /// <summary>見積タイトル１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積タイトル１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateTitle1
        {
            get { return _estimateTitle1; }
            set { _estimateTitle1 = value; }
        }


        /// public propaty name  :  EstimateNote1
        /// <summary>見積備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote1
        {
            get { return _estimateNote1; }
            set { _estimateNote1 = value; }
        }

        /// public propaty name  :  EstimateNote2
        /// <summary>見積備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote2
        {
            get { return _estimateNote2; }
            set { _estimateNote2 = value; }
        }

        /// public propaty name  :  EstimateNote3
        /// <summary>見積備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateNote3
        {
            get { return _estimateNote3; }
            set { _estimateNote3 = value; }
        }
        /// public propaty name  :  EstimatePrtDiv
        /// <summary>見積書発行区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  FaxEstimatetDiv
        /// <summary>ＦＡＸ見積区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＦＡＸ見積区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FaxEstimatetDiv
        {
            get { return _faxEstimatetDiv; }
            set { _faxEstimatetDiv = value; }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>品番印字区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
        }

        /// public propaty name  :  OptionPringDivCd
        /// <summary>オプション印字区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オプション印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OptionPringDivCd
        {
            get { return _optionPringDivCd; }
            set { _optionPringDivCd = value; }
        }

        /// public propaty name  :  PartsSelectDivCd
        /// <summary>部品選択区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsSelectDivCd
        {
            get { return _partsSelectDivCd; }
            set { _partsSelectDivCd = value; }
        }

        /// public propaty name  :  PartsSearchDivCd
        /// <summary>部品検索区分プロパティ</summary>
        /// <value>0:部品検索,1:品番検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsSearchDivCd
        {
            get { return _partsSearchDivCd; }
            set { _partsSearchDivCd = value; }
        }

        /// public propaty name  :  EstimateDtCreateDiv
        /// <summary>見積データ作成区分プロパティ</summary>
        /// <value>0:する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ作成区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateDtCreateDiv
        {
            get { return _estimateDtCreateDiv; }
            set { _estimateDtCreateDiv = value; }
        }

        /// public propaty name  :  EstimateValidityTerm
        /// <summary>見積書有効期限プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書有効期限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimateValidityTerm
        {
            get { return _estimateValidityTerm; }
            set { _estimateValidityTerm = value; }
        }

        /// public propaty name  :  RateUseCode
        /// <summary>掛率使用区分プロパティ</summary>
        /// <value>0:売価＝定価 1:掛率指定,2:掛率設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateUseCode
        {
            get { return _rateUseCode; }
            set { _rateUseCode = value; }
        }


        /// <summary>
        /// 見積初期値設定ワークコンストラクタ
        /// </summary>
        /// <returns>EstimateDefSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstimateDefSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EstimateDefSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EstimateDefSetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EstimateDefSetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EstimateDefSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstimateDefSetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EstimateDefSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EstimateDefSetWork || graph is ArrayList || graph is EstimateDefSetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(EstimateDefSetWork).FullName));

            if (graph != null && graph is EstimateDefSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EstimateDefSetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EstimateDefSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EstimateDefSetWork[])graph).Length;
            }
            else if (graph is EstimateDefSetWork)
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
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //消費税印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxPrintDiv
            //定価印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPricePrintDiv
            //見積書番号採番区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstmFormNoPickDiv
            //見積タイトル１
            serInfo.MemberInfo.Add(typeof(string)); //EstimateTitle1
            //見積備考１
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote1
            //見積備考２
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote2
            //見積備考３
            serInfo.MemberInfo.Add(typeof(string)); //EstimateNote3
            //見積書発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimatePrtDiv
            //ＦＡＸ見積区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FaxEstimatetDiv
            //品番印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNoPrtCd
            //オプション印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OptionPringDivCd
            //部品選択区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSelectDivCd
            //部品検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchDivCd
            //見積データ作成区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateDtCreateDiv
            //見積書有効期限
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateValidityTerm
            //掛率使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RateUseCode


            serInfo.Serialize(writer, serInfo);
            if (graph is EstimateDefSetWork)
            {
                EstimateDefSetWork temp = (EstimateDefSetWork)graph;

                SetEstimateDefSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EstimateDefSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EstimateDefSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EstimateDefSetWork temp in lst)
                {
                    SetEstimateDefSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EstimateDefSetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 26;
        

        /// <summary>
        ///  EstimateDefSetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstimateDefSetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEstimateDefSetWork(System.IO.BinaryWriter writer, EstimateDefSetWork temp)
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
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //消費税印刷区分
            writer.Write(temp.ConsTaxPrintDiv);
            //定価印刷区分
            writer.Write(temp.ListPricePrintDiv);
            //見積書番号採番区分
            writer.Write(temp.EstmFormNoPickDiv);
            //見積タイトル１
            writer.Write(temp.EstimateTitle1);
            //見積備考１
            writer.Write(temp.EstimateNote1);
            //見積備考２
            writer.Write(temp.EstimateNote2);
            //見積備考３
            writer.Write(temp.EstimateNote3);
            //見積書発行区分
            writer.Write(temp.EstimatePrtDiv);
            //ＦＡＸ見積区分
            writer.Write(temp.FaxEstimatetDiv);
            //品番印字区分
            writer.Write(temp.PartsNoPrtCd);
            //オプション印字区分
            writer.Write(temp.OptionPringDivCd);
            //部品選択区分
            writer.Write(temp.PartsSelectDivCd);
            //部品検索区分
            writer.Write(temp.PartsSearchDivCd);
            //見積データ作成区分
            writer.Write(temp.EstimateDtCreateDiv);
            //見積書有効期限
            writer.Write(temp.EstimateValidityTerm);
            //掛率使用区分
            writer.Write(temp.RateUseCode);

        }

        /// <summary>
        ///  EstimateDefSetWorkインスタンス取得
        /// </summary>
        /// <returns>EstimateDefSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstimateDefSetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private EstimateDefSetWork GetEstimateDefSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EstimateDefSetWork temp = new EstimateDefSetWork();

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
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //消費税印刷区分
            temp.ConsTaxPrintDiv = reader.ReadInt32();
            //定価印刷区分
            temp.ListPricePrintDiv = reader.ReadInt32();
            //見積書番号採番区分
            temp.EstmFormNoPickDiv = reader.ReadInt32();
            //見積タイトル１
            temp.EstimateTitle1 = reader.ReadString();
            //見積備考１
            temp.EstimateNote1 = reader.ReadString();
            //見積備考２
            temp.EstimateNote2 = reader.ReadString();
            //見積備考３
            temp.EstimateNote3 = reader.ReadString();
            //見積書発行区分
            temp.EstimatePrtDiv = reader.ReadInt32();
            //ＦＡＸ見積区分
            temp.FaxEstimatetDiv = reader.ReadInt32();
            //品番印字区分
            temp.PartsNoPrtCd = reader.ReadInt32();
            //オプション印字区分
            temp.OptionPringDivCd = reader.ReadInt32();
            //部品選択区分
            temp.PartsSelectDivCd = reader.ReadInt32();
            //部品検索区分
            temp.PartsSearchDivCd = reader.ReadInt32();
            //見積データ作成区分
            temp.EstimateDtCreateDiv = reader.ReadInt32();
            //見積書有効期限
            temp.EstimateValidityTerm = reader.ReadInt32();
            //掛率使用区分
            temp.RateUseCode = reader.ReadInt32();


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
        /// <returns>EstimateDefSetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstimateDefSetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EstimateDefSetWork temp = GetEstimateDefSetWork(reader, serInfo);
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
                    retValue = (EstimateDefSetWork[])lst.ToArray(typeof(EstimateDefSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
