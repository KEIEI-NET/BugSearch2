//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE 自社設定マスタデータパラメータ
//                  :   PMUOE09046D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOESettingWork
    /// <summary>
    ///                      UOE自社設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE自社設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/22  長内</br>
    /// <br>                 :   ○項目追加（キー変更）</br>
    /// <br>                 :   　拠点コード</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOESettingWork : IFileHeader
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

        /// <summary>伝票出力区分</summary>
        /// <remarks>伝票出力発行区分</remarks>
        private Int32 _slipOutputDivCd;

        /// <summary>フォロー伝票出力区分</summary>
        /// <remarks>フォロー伝票出力形態</remarks>
        private Int32 _followSlipOutputDiv;

        /// <summary>計上日付区分</summary>
        /// <remarks>伝発Ⅱ売上日付</remarks>
        private Int32 _addUpADateDiv;

        /// <summary>在庫一括品番区分</summary>
        /// <remarks>在庫一括代替品番区分</remarks>
        private Int32 _stockBlnktPrtNoDiv;

        /// <summary>メーカーフォロー計上区分</summary>
        /// <remarks>メーカーフォロー計上区分</remarks>
        private Int32 _makerFollowAddUpDiv;

        /// <summary>回線エラー印刷区分</summary>
        /// <remarks>回線ｴﾗｰﾘｽﾄ印刷区分</remarks>
        private Int32 _circuitErrPrtDiv;

        /// <summary>卸商入庫更新区分</summary>
        /// <remarks>卸商入庫更新区分</remarks>
        private Int32 _distEnterDiv;

        /// <summary>卸商拠点設定区分</summary>
        /// <remarks>卸商営業所設定区分</remarks>
        private Int32 _distSectionSetDiv;

        /// <summary>明治用リマーク区分</summary>
        /// <remarks>明治用Ⅱリマーク区分</remarks>
        private Int32 _meijiRemark;

        /// <summary>手入力検索リマーク</summary>
        /// <remarks>手入力検索リマーク</remarks>
        private string _inpSearchRemark = "";

        /// <summary>在庫一括補充リマーク</summary>
        /// <remarks>在庫一括補充リマーク</remarks>
        private string _stockBlnktRemark = "";

        /// <summary>伝発リマーク</summary>
        /// <remarks>伝発Ⅱリマーク</remarks>
        private string _slipOutputRemark = "";

        /// <summary>伝発リマーク区分</summary>
        /// <remarks>伝発Ⅱリマーク区分 ※予備の1:ﾘﾏｰｸ(個別)を統合させる</remarks>
        private Int32 _slipOutputRemarkDiv;

        /// <summary>UOE伝票発行区分</summary>
        /// <remarks>UOE伝票発行区分</remarks>
        private Int32 _uOESlipPrtDiv;

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

        /// public propaty name  :  SlipOutputDivCd
        /// <summary>伝票出力区分プロパティ</summary>
        /// <value>伝票出力発行区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipOutputDivCd
        {
            get { return _slipOutputDivCd; }
            set { _slipOutputDivCd = value; }
        }

        /// public propaty name  :  FollowSlipOutputDiv
        /// <summary>フォロー伝票出力区分プロパティ</summary>
        /// <value>フォロー伝票出力形態</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FollowSlipOutputDiv
        {
            get { return _followSlipOutputDiv; }
            set { _followSlipOutputDiv = value; }
        }

        /// public propaty name  :  AddUpADateDiv
        /// <summary>計上日付区分プロパティ</summary>
        /// <value>伝発Ⅱ売上日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpADateDiv
        {
            get { return _addUpADateDiv; }
            set { _addUpADateDiv = value; }
        }

        /// public propaty name  :  StockBlnktPrtNoDiv
        /// <summary>在庫一括品番区分プロパティ</summary>
        /// <value>在庫一括代替品番区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫一括品番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockBlnktPrtNoDiv
        {
            get { return _stockBlnktPrtNoDiv; }
            set { _stockBlnktPrtNoDiv = value; }
        }

        /// public propaty name  :  MakerFollowAddUpDiv
        /// <summary>メーカーフォロー計上区分プロパティ</summary>
        /// <value>メーカーフォロー計上区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーフォロー計上区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerFollowAddUpDiv
        {
            get { return _makerFollowAddUpDiv; }
            set { _makerFollowAddUpDiv = value; }
        }

        /// public propaty name  :  CircuitErrPrtDiv
        /// <summary>回線エラー印刷区分プロパティ</summary>
        /// <value>回線ｴﾗｰﾘｽﾄ印刷区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回線エラー印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CircuitErrPrtDiv
        {
            get { return _circuitErrPrtDiv; }
            set { _circuitErrPrtDiv = value; }
        }

        /// public propaty name  :  DistEnterDiv
        /// <summary>卸商入庫更新区分プロパティ</summary>
        /// <value>卸商入庫更新区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   卸商入庫更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DistEnterDiv
        {
            get { return _distEnterDiv; }
            set { _distEnterDiv = value; }
        }

        /// public propaty name  :  DistSectionSetDiv
        /// <summary>卸商拠点設定区分プロパティ</summary>
        /// <value>卸商営業所設定区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   卸商拠点設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DistSectionSetDiv
        {
            get { return _distSectionSetDiv; }
            set { _distSectionSetDiv = value; }
        }

        /// public propaty name  :  MeijiRemark
        /// <summary>明治用リマーク区分プロパティ</summary>
        /// <value>明治用Ⅱリマーク区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明治用リマーク区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MeijiRemark
        {
            get { return _meijiRemark; }
            set { _meijiRemark = value; }
        }

        /// public propaty name  :  InpSearchRemark
        /// <summary>手入力検索リマークプロパティ</summary>
        /// <value>手入力検索リマーク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手入力検索リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSearchRemark
        {
            get { return _inpSearchRemark; }
            set { _inpSearchRemark = value; }
        }

        /// public propaty name  :  StockBlnktRemark
        /// <summary>在庫一括補充リマークプロパティ</summary>
        /// <value>在庫一括補充リマーク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫一括補充リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemark
        /// <summary>伝発リマークプロパティ</summary>
        /// <value>伝発Ⅱリマーク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝発リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipOutputRemark
        {
            get { return _slipOutputRemark; }
            set { _slipOutputRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemarkDiv
        /// <summary>伝発リマーク区分プロパティ</summary>
        /// <value>伝発Ⅱリマーク区分 ※予備の1:ﾘﾏｰｸ(個別)を統合させる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝発リマーク区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipOutputRemarkDiv
        {
            get { return _slipOutputRemarkDiv; }
            set { _slipOutputRemarkDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE伝票発行区分プロパティ</summary>
        /// <value>UOE伝票発行区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uOESlipPrtDiv; }
            set { _uOESlipPrtDiv = value; }
        }


        /// <summary>
        /// UOE自社設定ワークコンストラクタ
        /// </summary>
        /// <returns>UOESettingWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESettingWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>UOESettingWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   UOESettingWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class UOESettingWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOESettingWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOESettingWork || graph is ArrayList || graph is UOESettingWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UOESettingWork).FullName));

            if (graph != null && graph is UOESettingWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOESettingWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOESettingWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOESettingWork[])graph).Length;
            }
            else if (graph is UOESettingWork)
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
            //伝票出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipOutputDivCd
            //フォロー伝票出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FollowSlipOutputDiv
            //計上日付区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADateDiv
            //在庫一括品番区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockBlnktPrtNoDiv
            //メーカーフォロー計上区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowAddUpDiv
            //回線エラー印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CircuitErrPrtDiv
            //卸商入庫更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DistEnterDiv
            //卸商拠点設定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DistSectionSetDiv
            //明治用リマーク区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MeijiRemark
            //手入力検索リマーク
            serInfo.MemberInfo.Add(typeof(string)); //InpSearchRemark
            //在庫一括補充リマーク
            serInfo.MemberInfo.Add(typeof(string)); //StockBlnktRemark
            //伝発リマーク
            serInfo.MemberInfo.Add(typeof(string)); //SlipOutputRemark
            //伝発リマーク区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipOutputRemarkDiv
            //UOE伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESlipPrtDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is UOESettingWork)
            {
                UOESettingWork temp = (UOESettingWork)graph;

                SetUOESettingWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOESettingWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOESettingWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOESettingWork temp in lst)
                {
                    SetUOESettingWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOESettingWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  UOESettingWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetUOESettingWork(System.IO.BinaryWriter writer, UOESettingWork temp)
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
            //伝票出力区分
            writer.Write(temp.SlipOutputDivCd);
            //フォロー伝票出力区分
            writer.Write(temp.FollowSlipOutputDiv);
            //計上日付区分
            writer.Write(temp.AddUpADateDiv);
            //在庫一括品番区分
            writer.Write(temp.StockBlnktPrtNoDiv);
            //メーカーフォロー計上区分
            writer.Write(temp.MakerFollowAddUpDiv);
            //回線エラー印刷区分
            writer.Write(temp.CircuitErrPrtDiv);
            //卸商入庫更新区分
            writer.Write(temp.DistEnterDiv);
            //卸商拠点設定区分
            writer.Write(temp.DistSectionSetDiv);
            //明治用リマーク区分
            writer.Write(temp.MeijiRemark);
            //手入力検索リマーク
            writer.Write(temp.InpSearchRemark);
            //在庫一括補充リマーク
            writer.Write(temp.StockBlnktRemark);
            //伝発リマーク
            writer.Write(temp.SlipOutputRemark);
            //伝発リマーク区分
            writer.Write(temp.SlipOutputRemarkDiv);
            //UOE伝票発行区分
            writer.Write(temp.UOESlipPrtDiv);

        }

        /// <summary>
        ///  UOESettingWorkインスタンス取得
        /// </summary>
        /// <returns>UOESettingWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private UOESettingWork GetUOESettingWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            UOESettingWork temp = new UOESettingWork();

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
            //伝票出力区分
            temp.SlipOutputDivCd = reader.ReadInt32();
            //フォロー伝票出力区分
            temp.FollowSlipOutputDiv = reader.ReadInt32();
            //計上日付区分
            temp.AddUpADateDiv = reader.ReadInt32();
            //在庫一括品番区分
            temp.StockBlnktPrtNoDiv = reader.ReadInt32();
            //メーカーフォロー計上区分
            temp.MakerFollowAddUpDiv = reader.ReadInt32();
            //回線エラー印刷区分
            temp.CircuitErrPrtDiv = reader.ReadInt32();
            //卸商入庫更新区分
            temp.DistEnterDiv = reader.ReadInt32();
            //卸商拠点設定区分
            temp.DistSectionSetDiv = reader.ReadInt32();
            //明治用リマーク区分
            temp.MeijiRemark = reader.ReadInt32();
            //手入力検索リマーク
            temp.InpSearchRemark = reader.ReadString();
            //在庫一括補充リマーク
            temp.StockBlnktRemark = reader.ReadString();
            //伝発リマーク
            temp.SlipOutputRemark = reader.ReadString();
            //伝発リマーク区分
            temp.SlipOutputRemarkDiv = reader.ReadInt32();
            //UOE伝票発行区分
            temp.UOESlipPrtDiv = reader.ReadInt32();


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
        /// <returns>UOESettingWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOESettingWork temp = GetUOESettingWork(reader, serInfo);
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
                    retValue = (UOESettingWork[])lst.ToArray(typeof(UOESettingWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
