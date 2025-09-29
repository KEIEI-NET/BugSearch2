using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_UpdHisDspWork
    /// <summary>
    ///                      更新履歴表示抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   更新履歴表示抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_UpdHisDspWork
    {
        /// <summary>計上拠点コード</summary>
        /// <remarks>空白は全拠点の一括締め</remarks>
        private string _addUpSecCode = "";

        /// <summary>得意先コード</summary>
        /// <remarks>０の場合は一括締め</remarks>
        private Int32 _customerCode;

        /// <summary>仕入先コード</summary>
        /// <remarks>０の場合は一括締め</remarks>
        private Int32 _supplierCd;

        /// <summary>売掛買掛区分</summary>
        /// <remarks>０：売掛 １：買掛</remarks>
        private Int32 _accRecAccPayDiv;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となった年月日</remarks>
        private DateTime _cAddUpUpdDate;

        /// <summary>締次更新年月</summary>
        /// <remarks>"YYYYMM"    締次更新対象となった年月</remarks>
        private DateTime _cAddUpUpdYearMonth;

        /// <summary>締次更新実行年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>前回締次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回締次更新対象となった年月日</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>月次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  月次更新対象となる開始年月日</remarks>
        private DateTime _stMonCAddUpUpdDate;

        /// <summary>月次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  月次更新年月日</remarks>
        private DateTime _monthlyAddUpDate;

        /// <summary>月次更新年月</summary>
        /// <remarks>"YYYYMM"    月次更新対象となった年月</remarks>
        private DateTime _monthAddUpYearMonth;

        /// <summary>月次更新実行年月日</summary>
        /// <remarks>YYYYMMDD　月次更新実行年月日</remarks>
        private DateTime _monthAddUpExpDate;

        /// <summary>前回月次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回月次更新対象となった年月日</remarks>
        private DateTime _laMonCAddUpUpdDate;

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

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>所属拠点コード</summary>
        private string _belongSectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>データ更新日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _dataUpdateDateTime;


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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>０の場合は一括締め</value>
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

        /// public propaty name  :  AccRecAccPayDiv
        /// <summary>売掛買掛区分プロパティ</summary>
        /// <value>０：売掛 １：買掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛買掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecAccPayDiv
        {
            get { return _accRecAccPayDiv; }
            set { _accRecAccPayDiv = value; }
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
        /// <value>"YYYYMMDD"  締次更新対象となった年月日</value>
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
        /// <value>"YYYYMM"    締次更新対象となった年月</value>
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

        /// public propaty name  :  StMonCAddUpUpdDate
        /// <summary>月次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StMonCAddUpUpdDate
        {
            get { return _stMonCAddUpUpdDate; }
            set { _stMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  MonthlyAddUpDate
        /// <summary>月次更新年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  月次更新年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthlyAddUpDate
        {
            get { return _monthlyAddUpDate; }
            set { _monthlyAddUpDate = value; }
        }

        /// public propaty name  :  MonthAddUpYearMonth
        /// <summary>月次更新年月プロパティ</summary>
        /// <value>"YYYYMM"    月次更新対象となった年月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthAddUpYearMonth
        {
            get { return _monthAddUpYearMonth; }
            set { _monthAddUpYearMonth = value; }
        }

        /// public propaty name  :  MonthAddUpExpDate
        /// <summary>月次更新実行年月日プロパティ</summary>
        /// <value>YYYYMMDD　月次更新実行年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新実行年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MonthAddUpExpDate
        {
            get { return _monthAddUpExpDate; }
            set { _monthAddUpExpDate = value; }
        }

        /// public propaty name  :  LaMonCAddUpUpdDate
        /// <summary>前回月次更新年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  前回月次更新対象となった年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回月次更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
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

        /// public propaty name  :  BelongSectionCode
        /// <summary>所属拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BelongSectionCode
        {
            get { return _belongSectionCode; }
            set { _belongSectionCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>データ更新日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }


        /// <summary>
        /// 更新履歴表示抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RsltInfo_UpdHisDspWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_UpdHisDspWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltInfo_UpdHisDspWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RsltInfo_UpdHisDspWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RsltInfo_UpdHisDspWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RsltInfo_UpdHisDspWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_UpdHisDspWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_UpdHisDspWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_UpdHisDspWork || graph is ArrayList || graph is RsltInfo_UpdHisDspWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RsltInfo_UpdHisDspWork).FullName));

            if (graph != null && graph is RsltInfo_UpdHisDspWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_UpdHisDspWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_UpdHisDspWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_UpdHisDspWork[])graph).Length;
            }
            else if (graph is RsltInfo_UpdHisDspWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //売掛買掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecAccPayDiv
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
            //月次更新開始年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //StMonCAddUpUpdDate
            //月次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthlyAddUpDate
            //月次更新年月
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpYearMonth
            //月次更新実行年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate
            //前回月次更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //LaMonCAddUpUpdDate
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
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //所属拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //データ更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_UpdHisDspWork)
            {
                RsltInfo_UpdHisDspWork temp = (RsltInfo_UpdHisDspWork)graph;

                SetRsltInfo_UpdHisDspWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_UpdHisDspWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_UpdHisDspWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_UpdHisDspWork temp in lst)
                {
                    SetRsltInfo_UpdHisDspWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_UpdHisDspWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RsltInfo_UpdHisDspWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_UpdHisDspWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRsltInfo_UpdHisDspWork(System.IO.BinaryWriter writer, RsltInfo_UpdHisDspWork temp)
        {
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //売掛買掛区分
            writer.Write(temp.AccRecAccPayDiv);
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
            //月次更新開始年月日
            writer.Write((Int64)temp.StMonCAddUpUpdDate.Ticks);
            //月次更新年月日
            writer.Write((Int64)temp.MonthlyAddUpDate.Ticks);
            //月次更新年月
            writer.Write((Int64)temp.MonthAddUpYearMonth.Ticks);
            //月次更新実行年月日
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);
            //前回月次更新年月日
            writer.Write((Int64)temp.LaMonCAddUpUpdDate.Ticks);
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
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //所属拠点コード
            writer.Write(temp.BelongSectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //データ更新日時
            writer.Write(temp.DataUpdateDateTime);

        }

        /// <summary>
        ///  RsltInfo_UpdHisDspWorkインスタンス取得
        /// </summary>
        /// <returns>RsltInfo_UpdHisDspWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_UpdHisDspWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RsltInfo_UpdHisDspWork GetRsltInfo_UpdHisDspWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RsltInfo_UpdHisDspWork temp = new RsltInfo_UpdHisDspWork();

            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //売掛買掛区分
            temp.AccRecAccPayDiv = reader.ReadInt32();
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
            //月次更新開始年月日
            temp.StMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //月次更新年月日
            temp.MonthlyAddUpDate = new DateTime(reader.ReadInt64());
            //月次更新年月
            temp.MonthAddUpYearMonth = new DateTime(reader.ReadInt64());
            //月次更新実行年月日
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());
            //前回月次更新年月日
            temp.LaMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
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
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //所属拠点コード
            temp.BelongSectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //データ更新日時
            temp.DataUpdateDateTime = reader.ReadInt64();


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
        /// <returns>RsltInfo_UpdHisDspWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_UpdHisDspWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_UpdHisDspWork temp = GetRsltInfo_UpdHisDspWork(reader, serInfo);
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
                    retValue = (RsltInfo_UpdHisDspWork[])lst.ToArray(typeof(RsltInfo_UpdHisDspWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
