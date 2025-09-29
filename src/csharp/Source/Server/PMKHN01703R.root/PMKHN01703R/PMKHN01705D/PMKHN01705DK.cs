//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業優良設定マスタ処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   NewPrmSettingUWork
    /// <summary>
    ///                      優良設定（ユーザー登録分）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良設定（ユーザー登録分）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2006/11/22</br>
    /// <br>Genarated Date   :   2015/01/20  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class NewPrmSettingUWork : IFileHeader
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

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private string _goodsMGroup = "";

        /// <summary>BLコード</summary>
        private string _tbsPartsCode = "";

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>メーカー表示順位</summary>
        private Int32 _makerDispOrder;

        /// <summary>部品メーカーコード</summary>
        private string _partsMakerCd = "";

        /// <summary>優良表示順位</summary>
        private Int32 _primeDispOrder;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>※セレクトコード</remarks>
        private string _prmSetDtlNo1 = "";

        /// <summary>優良設定詳細名称１</summary>
        private string _prmSetDtlName1 = "";

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>※種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>優良設定詳細名称２</summary>
        private string _prmSetDtlName2 = "";

        /// <summary>備考内容</summary>
        private string _outNote = "";

        /// <summary>優良表示区分</summary>
        private Int32 _primeDisplayCode;

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>新旧区分</summary>
        private Int32 _newAndOldDiv;

        /// <summary>変換前　種別コード</summary>
        private Int32 _prmSetDtlNoPast;

        /// <summary>変換後　旧種別コード</summary>
        private string _prmSetDtlNoAfterOld = "";

        /// <summary>変換後　新種別コード</summary>
        private string _prmSetDtlNoAfterNew = "";

        /// <summary>項目数不正フラグ</summary>
        private bool _countErrLog = false;

        /// <summary>優良設定詳細名称２(工場向け)</summary>
        /// <remarks>整備工場・鈑金工場などが理解可能な説明文が入る (半角全角混在)</remarks>
        private string _prmSetDtlName2ForFac = "";

        /// <summary>優良設定詳細名称２(カーオーナー向け)</summary>
        /// <remarks>カーオーナーが理解可能な説明文が入る (半角全角混在)</remarks>
        private string _prmSetDtlName2ForCOw = "";


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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  MakerDispOrder
        /// <summary>メーカー表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerDispOrder
        {
            get { return _makerDispOrder; }
            set { _makerDispOrder = value; }
        }

        /// public propaty name  :  PartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrimeDispOrder
        /// <summary>優良表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrimeDispOrder
        {
            get { return _primeDispOrder; }
            set { _primeDispOrder = value; }
        }

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>※セレクトコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlName1
        /// <summary>優良設定詳細名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName1
        {
            get { return _prmSetDtlName1; }
            set { _prmSetDtlName1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>※種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>優良設定詳細名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  OutNote
        /// <summary>備考内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutNote
        {
            get { return _outNote; }
            set { _outNote = value; }
        }

        /// public propaty name  :  PrimeDisplayCode
        /// <summary>優良表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrimeDisplayCode
        {
            get { return _primeDisplayCode; }
            set { _primeDisplayCode = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  NewAndOldDiv
        /// <summary>新旧区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新旧区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewAndOldDiv
        {
            get { return _newAndOldDiv; }
            set { _newAndOldDiv = value; }
        }

        /// public propaty name  :  PrmSetDtlNoPast
        /// <summary>変換前　種別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換前　種別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNoPast
        {
            get { return _prmSetDtlNoPast; }
            set { _prmSetDtlNoPast = value; }
        }

        /// public propaty name  :  PrmSetDtlNoAfterOld
        /// <summary>変換後　旧種別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後　旧種別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlNoAfterOld
        {
            get { return _prmSetDtlNoAfterOld; }
            set { _prmSetDtlNoAfterOld = value; }
        }

        /// public propaty name  :  PrmSetDtlNoAfterNew
        /// <summary>変換後　新種別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後　新種別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmSetDtlNoAfterNew
        {
            get { return _prmSetDtlNoAfterNew; }
            set { _prmSetDtlNoAfterNew = value; }
        }

        /// public propaty name  :  CountErrLog
        /// <summary>項目数不正フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool CountErrLog
        {
            get { return _countErrLog; }
            set { _countErrLog = value; }
        }

        /// <summary>
        /// 優良設定詳細名称２(工場向け)
        /// </summary>
        /// <value>整備工場・鈑金工場などが理解可能な説明文 (半角全角混在)</value>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// <summary>
        /// 優良設定詳細名称２(カーオーナー向け)
        /// </summary>
        /// <value>カーオーナーが理解可能な説明文 (半角全角混在)</value>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }

        /// <summary>
        /// 優良設定（ユーザー登録分）ワークコンストラクタ
        /// </summary>
        /// <returns>NewPrmSettingUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NewPrmSettingUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NewPrmSettingUWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>NewPrmSettingUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   NewPrmSettingUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class NewPrmSettingUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   NewPrmSettingUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  NewPrmSettingUWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is NewPrmSettingUWork || graph is ArrayList || graph is NewPrmSettingUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(NewPrmSettingUWork).FullName));

            if (graph != null && graph is NewPrmSettingUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NewPrmSettingUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is NewPrmSettingUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((NewPrmSettingUWork[])graph).Length;
            }
            else if (graph is NewPrmSettingUWork)
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
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroup
            //BLコード
            serInfo.MemberInfo.Add(typeof(string)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //メーカー表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerDispOrder
            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(string)); //PartsMakerCd
            //優良表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDispOrder
            //優良設定詳細コード１
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlNo1
            //優良設定詳細名称１
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName1
            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //優良設定詳細名称２
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //備考内容
            serInfo.MemberInfo.Add(typeof(string)); //OutNote
            //優良表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDisplayCode
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //新旧区分
            serInfo.MemberInfo.Add(typeof(Int32)); //NewAndOldDiv
            //変換前　種別コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNoPast
            //変換後　旧種別コード
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlNoAfterOld
            //変換後　新種別コード
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlNoAfterNew
            //項目数不正フラグ
            serInfo.MemberInfo.Add(typeof(bool)); //CountErrLog
            //優良設定詳細名称２(工場向け)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForFacRF
            //優良設定詳細名称２(カーオーナー向け)
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2ForCOwRF

            serInfo.Serialize(writer, serInfo);
            if (graph is NewPrmSettingUWork)
            {
                NewPrmSettingUWork temp = (NewPrmSettingUWork)graph;

                SetNewPrmSettingUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is NewPrmSettingUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((NewPrmSettingUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (NewPrmSettingUWork temp in lst)
                {
                    SetNewPrmSettingUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// NewPrmSettingUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 29;

        /// <summary>
        ///  NewPrmSettingUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   NewPrmSettingUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetNewPrmSettingUWork(System.IO.BinaryWriter writer, NewPrmSettingUWork temp)
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
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //メーカー表示順位
            writer.Write(temp.MakerDispOrder);
            //部品メーカーコード
            writer.Write(temp.PartsMakerCd);
            //優良表示順位
            writer.Write(temp.PrimeDispOrder);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //優良設定詳細名称１
            writer.Write(temp.PrmSetDtlName1);
            //優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            //優良設定詳細名称２
            writer.Write(temp.PrmSetDtlName2);
            //備考内容
            writer.Write(temp.OutNote);
            //優良表示区分
            writer.Write(temp.PrimeDisplayCode);
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //新旧区分
            writer.Write(temp.NewAndOldDiv);
            //変換前　種別コード
            writer.Write(temp.PrmSetDtlNoPast);
            //変換後　旧種別コード
            writer.Write(temp.PrmSetDtlNoAfterOld);
            //変換後　新種別コード
            writer.Write(temp.PrmSetDtlNoAfterNew);
            //項目数不正フラグ
            writer.Write(temp.CountErrLog);
            //優良設定詳細名称２(工場向け)
            writer.Write(temp.PrmSetDtlName2ForFac);
            //優良設定詳細名称２(カーオーナー向け)
            writer.Write(temp.PrmSetDtlName2ForCOw);

        }

        /// <summary>
        ///  NewPrmSettingUWorkインスタンス取得
        /// </summary>
        /// <returns>NewPrmSettingUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NewPrmSettingUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private NewPrmSettingUWork GetNewPrmSettingUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            NewPrmSettingUWork temp = new NewPrmSettingUWork();

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
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadString();
            //BLコード
            temp.TbsPartsCode = reader.ReadString();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //メーカー表示順位
            temp.MakerDispOrder = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadString();
            //優良表示順位
            temp.PrimeDispOrder = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadString();
            //優良設定詳細名称１
            temp.PrmSetDtlName1 = reader.ReadString();
            //優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //優良設定詳細名称２
            temp.PrmSetDtlName2 = reader.ReadString();
            //備考内容
            temp.OutNote = reader.ReadString();
            //優良表示区分
            temp.PrimeDisplayCode = reader.ReadInt32();
            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //新旧区分
            temp.NewAndOldDiv = reader.ReadInt32();
            //変換前　種別コード
            temp.PrmSetDtlNoPast = reader.ReadInt32();
            //変換後　旧種別コード
            temp.PrmSetDtlNoAfterOld = reader.ReadString();
            //変換後　新種別コード
            temp.PrmSetDtlNoAfterNew = reader.ReadString();
            //項目数不正フラグ
            temp.CountErrLog = reader.ReadBoolean();
            //優良設定詳細名称２(工場向け)
            temp.PrmSetDtlName2ForFac = reader.ReadString();
            //優良設定詳細名称２(カーオーナー向け)
            temp.PrmSetDtlName2ForCOw = reader.ReadString();


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
        /// <returns>NewPrmSettingUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NewPrmSettingUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                NewPrmSettingUWork temp = GetNewPrmSettingUWork(reader, serInfo);
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
                    retValue = (NewPrmSettingUWork[])lst.ToArray(typeof(NewPrmSettingUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
