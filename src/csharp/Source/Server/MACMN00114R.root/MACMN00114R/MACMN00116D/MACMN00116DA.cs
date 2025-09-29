using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OprtnHisLogSrchWork
	/// <summary>
	///                      操作履歴ログ表示抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   操作履歴ログ表示抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   時シン K2016/10/28</br>
    /// <br>管理番号         :   11202046-00</br>
    /// <br>                 :   神姫産業㈱ 時刻検索条件の追加</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OprtnHisLogSrchWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>開始ログデータ作成日時</summary>
		private DateTime _st_LogDataCreateDateTime;

		/// <summary>終了ログデータ作成日時</summary>
        private DateTime _ed_LogDataCreateDateTime;

		/// <summary>ログイン拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _loginSectionCd;

		/// <summary>ログデータ種別区分コード</summary>
		/// <remarks>未指定(絞り込まない)の場合は「-1」</remarks>
		private Int32 _logDataKindCd;

		/// <summary>ログデータ端末名</summary>
		private string _logDataMachineName = "";

		/// <summary>ログデータ担当者コード</summary>
		private string _logDataAgentCd = "";

		/// <summary>ログデータ対象アセンブリID</summary>
		/// <remarks>ログを書き込んだアセンブリID</remarks>
		private string _logDataObjAssemblyID = "";

		/// <summary>ログデータオペレーションコード</summary>
		/// <remarks>操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)</remarks>
		private Int32 _logDataOperationCd;

        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
        /// <summary>時刻検索フラグ</summary>
        private bool _timeSearchFlag = false;

        /// <summary>開始検索時刻（時）</summary>
        private Int32 _searchHourSt;

        /// <summary>開始検索時刻（分）</summary>
        private Int32 _searchMinuteSt;

        /// <summary>開始検索時刻（秒）</summary>
        private Int32 _searchSecondSt;

        /// <summary>終了検索時刻（時）</summary>
        private Int32 _searchHourEd;

        /// <summary>終了検索時刻（分）</summary>
        private Int32 _searchMinuteEd;

        /// <summary>終了検索時刻（秒）</summary>
        private Int32 _searchSecondEd;

        /// <summary>時刻検索フラグ(00:00:00に跨っている)</summary>
        private bool _timeSearchFlag2 = false;

        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
        /// <summary>時刻検索フラグ(24時間を超える)</summary>
        private bool _timeSearchFlagOverDay = false;
        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

        /// <summary>開始検索時刻（時）</summary>
        private Int32 _searchHourSt2;

        /// <summary>開始検索時刻（分）</summary>
        private Int32 _searchMinuteSt2;

        /// <summary>開始検索時刻（秒）</summary>
        private Int32 _searchSecondSt2;

        /// <summary>終了検索時刻（時）</summary>
        private Int32 _searchHourEd2;

        /// <summary>終了検索時刻（分）</summary>
        private Int32 _searchMinuteEd2;

        /// <summary>終了検索時刻（秒）</summary>
        private Int32 _searchSecondEd2;
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  St_LogDataCreateDateTime
		/// <summary>開始ログデータ作成日時プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始ログデータ作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_LogDataCreateDateTime
		{
			get{return _st_LogDataCreateDateTime;}
			set{_st_LogDataCreateDateTime = value;}
		}

		/// public propaty name  :  Ed_LogDataCreateDateTime
		/// <summary>終了ログデータ作成日時プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了ログデータ作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_LogDataCreateDateTime
		{
			get{return _ed_LogDataCreateDateTime;}
			set{_ed_LogDataCreateDateTime = value;}
		}

		/// public propaty name  :  LoginSectionCd
		/// <summary>ログイン拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログイン拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] LoginSectionCd
		{
			get{return _loginSectionCd;}
			set{_loginSectionCd = value;}
		}

		/// public propaty name  :  LogDataKindCd
		/// <summary>ログデータ種別区分コードプロパティ</summary>
		/// <value>未指定(絞り込まない)の場合は「-1」</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログデータ種別区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogDataKindCd
		{
			get{return _logDataKindCd;}
			set{_logDataKindCd = value;}
		}

		/// public propaty name  :  LogDataMachineName
		/// <summary>ログデータ端末名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログデータ端末名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LogDataMachineName
		{
			get{return _logDataMachineName;}
			set{_logDataMachineName = value;}
		}

		/// public propaty name  :  LogDataAgentCd
		/// <summary>ログデータ担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログデータ担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LogDataAgentCd
		{
			get{return _logDataAgentCd;}
			set{_logDataAgentCd = value;}
		}

		/// public propaty name  :  LogDataObjAssemblyID
		/// <summary>ログデータ対象アセンブリIDプロパティ</summary>
		/// <value>ログを書き込んだアセンブリID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログデータ対象アセンブリIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LogDataObjAssemblyID
		{
			get{return _logDataObjAssemblyID;}
			set{_logDataObjAssemblyID = value;}
		}

		/// public propaty name  :  LogDataOperationCd
		/// <summary>ログデータオペレーションコードプロパティ</summary>
		/// <value>操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログデータオペレーションコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogDataOperationCd
		{
			get{return _logDataOperationCd;}
			set{_logDataOperationCd = value;}
		}

        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 --------------->>>>>
        /// public propaty name  :  TimeSearchFlag
        /// <summary>時刻検索フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   時刻検索フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TimeSearchFlag
        {
            get { return _timeSearchFlag; }
            set { _timeSearchFlag = value; }
        }

        /// public propaty name  :  SearchHourSt
        /// <summary>開始検索時刻（時）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索時刻（時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchHourSt
        {
            get { return _searchHourSt; }
            set { _searchHourSt = value; }
        }

        /// public propaty name  :  SearchMinuteSt
        /// <summary>開始検索時刻（分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索時刻（分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchMinuteSt
        {
            get { return _searchMinuteSt; }
            set { _searchMinuteSt = value; }
        }

        /// public propaty name  :  SearchSecondSt
        /// <summary>開始検索時刻（秒）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索時刻（秒）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSecondSt
        {
            get { return _searchSecondSt; }
            set { _searchSecondSt = value; }
        }

        /// public propaty name  :  SearchHourEd
        /// <summary>終了検索時刻（時）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索時刻（時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchHourEd
        {
            get { return _searchHourEd; }
            set { _searchHourEd = value; }
        }

        /// public propaty name  :  SearchMinuteEd
        /// <summary>終了検索時刻（分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索時刻（分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchMinuteEd
        {
            get { return _searchMinuteEd; }
            set { _searchMinuteEd = value; }
        }

        /// public propaty name  :  SearchSecondEd
        /// <summary>終了検索時刻（秒）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索時刻（秒）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSecondEd
        {
            get { return _searchSecondEd; }
            set { _searchSecondEd = value; }
        }

        /// public propaty name  :  TimeSearchFlag2
        /// <summary>時刻検索フラグ(00:00:00に跨っている)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   時刻検索フラグ(00:00:00に跨っている)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TimeSearchFlag2
        {
            get { return _timeSearchFlag2; }
            set { _timeSearchFlag2 = value; }
        }

        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
        /// public propaty name  :  TimeSearchFlagOverDay
        /// <summary>時刻検索フラグ(24時間を超える)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   時刻検索フラグ(24時間を超える)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool TimeSearchFlagOverDay
        {
            get { return _timeSearchFlagOverDay; }
            set { _timeSearchFlagOverDay = value; }
        }
        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

        /// public propaty name  :  SearchHourSt
        /// <summary>開始検索時刻（時）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索時刻（時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchHourSt2
        {
            get { return _searchHourSt2; }
            set { _searchHourSt2 = value; }
        }

        /// public propaty name  :  SearchMinuteSt
        /// <summary>開始検索時刻（分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索時刻（分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchMinuteSt2
        {
            get { return _searchMinuteSt2; }
            set { _searchMinuteSt2 = value; }
        }

        /// public propaty name  :  SearchSecondSt2
        /// <summary>開始検索時刻（秒）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始検索時刻（秒）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSecondSt2
        {
            get { return _searchSecondSt2; }
            set { _searchSecondSt2 = value; }
        }

        /// public propaty name  :  SearchHourEd2
        /// <summary>終了検索時刻（時）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索時刻（時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchHourEd2
        {
            get { return _searchHourEd2; }
            set { _searchHourEd2 = value; }
        }

        /// public propaty name  :  SearchMinuteEd2
        /// <summary>終了検索時刻（分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索時刻（分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchMinuteEd2
        {
            get { return _searchMinuteEd2; }
            set { _searchMinuteEd2 = value; }
        }

        /// public propaty name  :  SearchSecondEd2
        /// <summary>終了検索時刻（秒）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了検索時刻（秒）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSecondEd2
        {
            get { return _searchSecondEd2; }
            set { _searchSecondEd2 = value; }
        }
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ---------------<<<<<

		/// <summary>
		/// 操作履歴ログ表示抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>OprtnHisLogSrchWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OprtnHisLogSrchWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OprtnHisLogSrchWork()
		{
		}

	}
}
