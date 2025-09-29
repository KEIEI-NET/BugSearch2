using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ChangGidncParaWork
    /// <summary>
    ///                      変更案内検索条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   変更案内検索条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/3/5</br>
    /// <br>Genarated Date   :   2007/03/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/12/06  Kouguchi  検索条件項目変更</br>
    /// <br>                 :   2008/02/20  Kouguchi  検索条件項目追加</br>
    /// </remarks>
    public class ChangGidncParaWork //: IFileHeader
    {
        /// <summary>パッケージ区分</summary>
        private string _productCode = "";

        /// <summary>配信提供区分</summary>
        /// <remarks>-1:マージ,0:標準,1:個別</remarks>
        private Int32 _mcastOfferDivCd;

        /// <summary>更新グループコード</summary>
        private string[] _updateGroupCode;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>基準日</summary>
        /// <remarks>サポートORユーザー公開日時</remarks>
        private Int64 _stdDate;

        /// <summary>公開日時区分</summary>
        /// <remarks>0:全て,1:サポート公開日時,2:ユーザー公開日時</remarks>
        private Int32 _openDtTmDiv;

        /// <summary>配信バージョン</summary>
        private string _multicastVersion = "";

        /// <summary>配信連番</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _multicastConsNo;

        /// <summary>配信サブコード</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _multicastSubCode;



        /// <summary>配信日開始</summary>
        private DateTime _stMulticastDate;

        /// <summary>配信日終了</summary>
        private DateTime _edMulticastDate;

        /// <summary>配信バージョン開始</summary>
        private string _stMulticastVersion = "";

        /// <summary>配信バージョン終了</summary>
        private string _edMulticastVersion = "";

        /// <summary>配信システム区分</summary>
        /// <remarks>-1:全て,0:共通,1:整備,2:鈑金,3:車販・・・</remarks>
        private Int32 _multicastSystemDivCd;

        /// <summary>変更内容</summary>
        private string[] _changeContents;

        /// <summary>配信プログラム名称</summary>
        private string _multicastProgramName = "";


        //↓↓↓ 2007.12.06  Add Kouguchi
        /// <summary>案内区分</summary>
        /// <remarks>0:共通,1:ﾌﾟﾛｸﾞﾗﾑ配信,2:ｻｰﾊﾞｰﾒﾝﾃﾅﾝｽ・・・</remarks>
        private Int32 _mcastGidncCntntsCd;
        /// <summary>地域</summary>
        private string _area = "";

        /// <summary>メンテ区分</summary>
        private Int32 _mcastGidncMainteCd;
        //↑↑↑ 2007.12.06  Add Kouguchi

        //↓↓↓ 2008.02.20  Add Kouguchi
        /// <summary>メンテナンス予定開始</summary>
        private Int64 _stServerMainteScdl;

        /// <summary>メンテナンス予定終了</summary>
        private Int64 _edServerMainteScdl;
        //↑↑↑ 2008.02.20  Add Kouguchi



        /// public propaty name  :  ProductCode
        /// <summary>パッケージ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パッケージ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        /// public propaty name  :  McastOfferDivCd
        /// <summary>配信提供区分プロパティ</summary>
        /// <value>-1:マージ,0:標準,1:個別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信提供区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 McastOfferDivCd
        {
            get { return _mcastOfferDivCd; }
            set { _mcastOfferDivCd = value; }
        }

        /// public propaty name  :  UpdateGroupCode
        /// <summary>更新グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] UpdateGroupCode
        {
            get { return _updateGroupCode; }
            set { _updateGroupCode = value; }
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

        /// public propaty name  :  StdDate
        /// <summary>基準日プロパティ</summary>
        /// <value>サポートORユーザー公開日時</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StdDate
        {
            get { return _stdDate; }
            set { _stdDate = value; }
        }

        /// public propaty name  :  OpenDtTmDiv
        /// <summary>公開日時区分プロパティ</summary>
        /// <value>0:全て,1:サポート公開日時,2:ユーザー公開日時</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   公開日時区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenDtTmDiv
        {
            get { return _openDtTmDiv; }
            set { _openDtTmDiv = value; }
        }

        /// public propaty name  :  MulticastVersion
        /// <summary>配信バージョンプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信バージョンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MulticastVersion
        {
            get { return _multicastVersion; }
            set { _multicastVersion = value; }
        }

        /// public propaty name  :  MulticastConsNo
        /// <summary>配信連番プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信連番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MulticastConsNo
        {
            get { return _multicastConsNo; }
            set { _multicastConsNo = value; }
        }

        /// public propaty name  :  MulticastSubCode
        /// <summary>配信サブコードプロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MulticastSubCode
        {
            get { return _multicastSubCode; }
            set { _multicastSubCode = value; }
        }

        /// public propaty name  :  StMulticastDate
        /// <summary>配信日開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信日開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StMulticastDate
        {
            get { return _stMulticastDate; }
            set { _stMulticastDate = value; }
        }

        /// public propaty name  :  EdMulticastDate
        /// <summary>配信日終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信日終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime EdMulticastDate
        {
            get { return _edMulticastDate; }
            set { _edMulticastDate = value; }
        }

        /// public propaty name  :  StMulticastVersion
        /// <summary>配信バージョン開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信バージョン開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StMulticastVersion
        {
            get { return _stMulticastVersion; }
            set { _stMulticastVersion = value; }
        }

        /// public propaty name  :  EdMulticastVersion
        /// <summary>配信バージョン終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信バージョン終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EdMulticastVersion
        {
            get { return _edMulticastVersion; }
            set { _edMulticastVersion = value; }
        }

        /// public propaty name  :  MulticastSystemDivCd
        /// <summary>配信システム区分プロパティ</summary>
        /// <value>-1:全て,0:共通,1:整備,2:鈑金,3:車販・・・</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信システム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MulticastSystemDivCd
        {
            get { return _multicastSystemDivCd; }
            set { _multicastSystemDivCd = value; }
        }

        /// public propaty name  :  ChangeContents
        /// <summary>変更内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] ChangeContents
        {
            get { return _changeContents; }
            set { _changeContents = value; }
        }

        /// public propaty name  :  MulticastProgramName
        /// <summary>配信プログラム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信プログラム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MulticastProgramName
        {
            get { return _multicastProgramName; }
            set { _multicastProgramName = value; }
        }

        //↓↓↓ 2007.12.06  Add Kouguchi
        /// public propaty name  :  McastGidncCntntsCd
        /// <summary>案内区分プロパティ</summary>
        /// <value>0:共通,1:ﾌﾟﾛｸﾞﾗﾑ配信,2:ｻｰﾊﾞｰﾒﾝﾃﾅﾝｽ・・・</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   案内区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 McastGidncCntntsCd
        {
            get { return _mcastGidncCntntsCd; }
            set { _mcastGidncCntntsCd = value; }
        }

        /// public propaty name  :  Area
        /// <summary>地域プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   地域プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        /// public propaty name  :  McastGidncMainteCd
        /// <summary>メンテ区分プロパティ</summary>
        /// <value>1:定期ﾒﾝﾃ,2:ﾃﾞｰﾀﾒﾝﾃﾅﾝｽ,9:緊急ﾒﾝﾃ・・・</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メンテ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 McastGidncMainteCd
        {
            get { return _mcastGidncMainteCd; }
            set { _mcastGidncMainteCd = value; }
        }
        //↑↑↑ 2007.12.06  Add Kouguchi



        /// public propaty name  :  MulticastVersionZeroSup
        /// <summary>配信バージョン(ゼロサプレス)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信バージョン(ゼロサプレス)プロパティ</br>
        /// <br>Programer        :   23001 秋山　亮介</br>
        /// <br>Date             :   2007.03.15</br>
        /// </remarks>
        public string MulticastVersionZeroSup
        {
            get { return VersionStringConverter.ConvertToZeroSuppress( _multicastVersion ); }
            set { _multicastVersion = VersionStringConverter.ConvertToZeroPadding( value, 5 ); }
        }

        /// public propaty name  :  StMulticastVersionZeroSup
        /// <summary>配信バージョン開始(ゼロサプレス)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信バージョン開始(ゼロサプレス)プロパティ</br>
        /// <br>Programer        :   23001 秋山　亮介</br>
        /// <br>Date             :   2007.03.15</br>
        /// </remarks>
        public string StMulticastVersionZeroSup
        {
            get { return VersionStringConverter.ConvertToZeroSuppress( _stMulticastVersion ); }
            set { _stMulticastVersion = VersionStringConverter.ConvertToZeroPadding( value, 5 ); }
        }

        /// public propaty name  :  EdMulticastVersionZeroSup
        /// <summary>配信バージョン終了(ゼロサプレス)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   配信バージョン終了(ゼロサプレス)プロパティ</br>
        /// <br>Programer        :   23001 秋山　亮介</br>
        /// <br>Date             :   2007.03.15</br>
        /// </remarks>
        public string EdMulticastVersionZeroSup
        {
            get { return VersionStringConverter.ConvertToZeroSuppress( _edMulticastVersion ); }
            set { _edMulticastVersion = VersionStringConverter.ConvertToZeroPadding( value, 5 ); }
        }


        //↓↓↓ 2008.02.20  Add Kouguchi
        /// public propaty name  :  StServerMainteScdl
        /// <summary>メンテナンス予定開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メンテナンス予定開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StServerMainteScdl
        {
            get { return _stServerMainteScdl; }
            set { _stServerMainteScdl = value; }
        }

        /// public propaty name  :  EdServerMainteScdl
        /// <summary>メンテナンス予定終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メンテナンス予定終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 EdServerMainteScdl
        {
            get { return _edServerMainteScdl; }
            set { _edServerMainteScdl = value; }
        }
        //↑↑↑ 2008.02.20  Add Kouguchi


        /// <summary>
        /// 変更案内検索条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>ChangGidncParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ChangGidncParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ChangGidncParaWork()
        {
        }
    }
}
