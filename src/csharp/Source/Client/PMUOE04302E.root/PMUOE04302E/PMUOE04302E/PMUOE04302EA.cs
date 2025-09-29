using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OprationLogOrderWorkWork
	/// <summary>
	///                      操作履歴ログ抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   操作履歴ログ抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class OprationLogOrderParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>ログイン拠点コード</summary>
		private string[] _sectionCodes;

		/// <summary>ログデータ端末名</summary>
		private string _logDataMachineName = "";

		/// <summary>発注先コード</summary>
		/// <remarks>ログに書き込む原因となったクラスID　(UOE発注先コード)</remarks>
		private string _logDataObjClassID = "";

		/// <summary>開始ログデータ作成日時</summary>
		private DateTime _st_LogDataCreateDateTime;

		/// <summary>終了ログデータ作成日時</summary>
		private DateTime _ed_LogDataCreateDateTime;

		/// <summary>ログデータ種別区分コード</summary>
		/// <remarks>0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)</remarks>
		private Int32 _logDataKindCd;


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

		/// public propaty name  :  SectionCodes
		/// <summary>ログイン拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ログイン拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
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

		/// public propaty name  :  LogDataObjClassID
		/// <summary>発注先コードプロパティ</summary>
		/// <value>ログに書き込む原因となったクラスID　(UOE発注先コード)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LogDataObjClassID
		{
			get{return _logDataObjClassID;}
			set{_logDataObjClassID = value;}
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

		/// public propaty name  :  LogDataKindCd
		/// <summary>ログデータ種別区分コードプロパティ</summary>
		/// <value>0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)</value>
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


		/// <summary>
		/// 操作履歴ログ抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>OprationLogOrderWorkWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OprationLogOrderWorkWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OprationLogOrderParam()
		{
		}

        /// <summary>
        /// 出荷部品表示条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="stAddUpYearMonth">計上年月(開始)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">計上年月(終了)(YYYYMM)</param>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprationLogOrderParam(string enterpriseCode, string[] sectionCodes, string logDataMachineName, string logDataObjClassID, DateTime st_LogDataCreateDateTime
            , DateTime ed_LogDataCreateDateTime, Int32 logDataKindCd)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCodes = sectionCodes;
            this._logDataMachineName = logDataMachineName;
            this._logDataObjClassID = logDataObjClassID;
            this._st_LogDataCreateDateTime = st_LogDataCreateDateTime;
            this._ed_LogDataCreateDateTime = ed_LogDataCreateDateTime;
            this.LogDataKindCd = LogDataKindCd;
        }

        /// <summary>
        /// 出荷部品表示条件クラス複製処理
        /// </summary>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmentPartsDspParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OprationLogOrderParam Clone()
        {
            return new OprationLogOrderParam(this._enterpriseCode, this._sectionCodes, this._logDataMachineName, this._logDataObjClassID, this._st_LogDataCreateDateTime,
                this._ed_LogDataCreateDateTime, this.LogDataKindCd);
        }
    }
}