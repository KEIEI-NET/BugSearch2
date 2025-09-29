using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MonthlyAddUpHisWork
    /// <summary>
    ///                      月次締更新履歴ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   月次締更新履歴ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2010/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/8  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   コンバート処理区分</br>
    /// <br>Update Note      :   2008/10/02  長内</br>
    /// <br>                 :   ○項目追加（キー変更）</br>
    /// <br>                 :   データ更新日時</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MonthlyAddUpHisWork
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

        /// <summary>売掛買掛区分</summary>
        /// <remarks>０：売掛 １：買掛</remarks>
        private Int32 _accRecAccPayDiv;

        /// <summary>計上拠点コード</summary>
        /// <remarks>空白は全拠点の一括締め</remarks>
        private string _addUpSecCode = "";

        /// <summary>月次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  月次更新対象となる開始年月日</remarks>
        private Int32 _stMonCAddUpUpdDate;

        /// <summary>月次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  月次更新年月日</remarks>
        private DateTime _monthlyAddUpDate;

        /// <summary>月次更新年月</summary>
        /// <remarks>"YYYYMM"    月次更新対象となった年月</remarks>
        private Int32 _monthAddUpYearMonth;

        /// <summary>月次更新実行年月日</summary>
        /// <remarks>YYYYMMDD　月次更新実行年月日</remarks>
        private Int32 _monthAddUpExpDate;

        /// <summary>前回月次更新年月日</summary>
        /// <remarks>"YYYYMMDD"  前回月次更新対象となった年月日</remarks>
        private Int32 _laMonCAddUpUpdDate;

        /// <summary>データ更新日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private Int64 _dataUpdateDateTime;

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

        /// public propaty name  :  StMonCAddUpUpdDate
        /// <summary>月次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  月次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StMonCAddUpUpdDate
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
        public Int32 MonthAddUpYearMonth
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
        public Int32 MonthAddUpExpDate
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
        public Int32 LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
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
        /// 月次締更新履歴ワークコンストラクタ
        /// </summary>
        /// <returns>MonthlyAddUpHisWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpHisWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MonthlyAddUpHisWork()
        {
        }

    }
}
