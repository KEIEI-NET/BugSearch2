//**********************************************************************//
// System           :   SuperFrontman                                   //
// Sub System       :                                                   //
// Program name     :   日付時刻クラス                                  //
//                  :   Broadleaf.SFLibrary.Globarization               //
// Name Space       :   Broadleaf.                                      //
// Programer        :   R.Sokei                                         //
// Date             :   2004.12.04                                      //
//----------------------------------------------------------------------//
// Update Note      :   2009.05.29 21027 T.Sugawa                       //
//                  :   1.昭和64年 → 平成1年となるように修正           //
//                  :     [昭和]～1989.01.07、[平成]1989.01.08～        //
//                  :   2012.03.30 nogchi VSS566                        //
//                  :     高速化対応                                    //
//                  :   2018.12.19 31983 S.Tomohiro                     //
//                  :     新元号対応に合わせ、.NET Frameworkに依らない  //
//                  :     元号つき日付の変換に対応                      //
//                  :     あわせて元号情報のXML保持に対応               //
//                  :     画面日付項目のフォーマットのXML保持に対応     //
//----------------------------------------------------------------------//
//                 Copyright(c)2004 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Broadleaf.Library.Globarization
{

	/// <summary>
	/// <see cref="TDateTime"/>TDateTimeクラスで利用する列挙体です。
	/// TDateTimeで利用するDateTime型の内部形式を定義します
	/// </summary>
	/// <remarks>
	/// <br><see cref="TDateTimeFormat"/>TDateTimeで利用するDateTime型の内部形式を定義します</br>
	/// </remarks>
	public enum TDateTimeFormat : int
	{
		/// <summary>
		/// "YYYYMMDD"の形式(例: 20050301)
		/// </summary>
		df4Y2M2D = 1,
		/// <summary>
		/// "YYMMDD"の形式(例: 050301)
		/// </summary>
		df2Y2M2D = 2,
		/// <summary>
		/// (和暦)GGYYMMDDの形式(例: 170301)
		/// </summary>
		dfG2Y2M2D = 31,
		/// <summary>
		/// YYYY年MM月の形式
		/// </summary>
		df4Y2M = 4,
		/// <summary>
		/// YY年MM月の形式
		/// </summary>
		df2Y2M = 5,
		/// <summary>
		/// 元号YY年MM月の形式
		/// </summary>
		dfG2Y2M = 32,
		/// <summary>
		/// MM月DD日の形式
		/// </summary>
		df2M2D = 6,
		/// <summary>
		/// YYYY年の形式
		/// </summary>
		df4Y = 7,
		/// <summary>
		/// MM月の形式
		/// </summary>
		df2Y = 8,
		/// <summary>
		/// 元号YY年の形式
		/// </summary>
		dfG2Y = 33,
		/// <summary>
		/// MM月の形式
		/// </summary>
		df2M = 9,
		/// <summary>
		/// DD日の形式
		/// </summary>
		df2D = 10
	}

	/// <summary>
	/// <see cref="TDateTime"/>TDateTimeクラスで利用する列挙体です。
	/// TDateTimeで扱う日付型を文字列に変換する際の出力形式を定義します
	/// </summary>
	/// <remarks>
	/// <br><see cref="TDateTimeStringFormat"/>TDateTimeで扱う日付型を文字列に変換する際の出力形式を定義します</br>
	/// </remarks>
	public enum TDateTimeStringFormat : int
	{
		//	case "YYYYMMDD":
		/// <summary>
		/// "YYYY年MM月DD日"の形式(例: "2005年03月01日")
		/// "YYYYMMDD"
		/// </summary>
		df4Y2M2D = 0,

		//	case "YYMMDD":
		/// <summary>
		/// "YY年MM月DD日"の形式(例: "05年03月01日")
		/// "YYMMDD":
		/// </summary>
		df2Y2M2D = 1,

		//	case "GGYYMMDD":
		/// <summary>
		/// 元号YY年MM月DD日の形式(例: "平成17年03月01日")
		/// "GGYYMMDD":
		/// </summary>
		dfG2Y2M2D = 2,

		//	case "YYYYMM":
		/// <summary>
		/// YYYY年MM月の形式(例: "2005年03月")
		/// "YYYYMM":
		/// </summary>
		df4Y2M = 3,
		/// <summary>
		/// xx年xx月の形式
		/// </summary>
		df2Y2M = 4,
		/// <summary>
		/// 元号xx年xx月xx日の形式
		/// </summary>
		dfG2Y2M = 5,
		/// <summary>
		/// xx月xx日の形式
		/// </summary>
		df2M2D = 6,
		/// <summary>
		/// xxxx年の形式
		/// </summary>
		df4Y = 7,
		/// <summary>
		/// xx月の形式
		/// </summary>
		df2Y = 8,
		/// <summary>
		/// 元号xx年の形式
		/// </summary>
		dfG2Y = 9,
		/// <summary>
		/// xx月の形式
		/// </summary>
		df2M = 10,
		/// <summary>
		/// xx日の形式
		/// </summary>
		df2D = 11

		//	case "GGyymmdd":
		//	case "ggYYMMDD":
		//	case "ggyymmdd":
		//	case "GGYYMM":
		//	case "GGyymm":
		//	case "GGYY":
		//	case "GGyy":
		//	case "ggYYMM":
		//	case "ggyymm":
		//	case "ggYY":
		//	case "YYYYmmdd":
		//	case "yyyymmdd":
		//	case "YYYYmm":
		//	case "MMDD":
		//	case "YYYY":
		//	case "MM":
		//	case "DD":
		//	case "YYYY/MM/DD":
		//	case "YYYY/mm/dd":
		//	case "YY/MM/DD":
		//	case "YYYY.MM.DD":
		//	case "YYYY.mm.dd":
		//	case "YY.MM.DD":
		//	case "GGYY/MM/DD":
		//	case "GGyy/mm/dd":
		//	case "ggYY/MM/DD":
		//	case "ggyy/mm/dd":
		//	case "GGYY.MM.DD":
		//	case "GGyy.mm.dd":
		//	case "GGYY.MM":
		//	case "GGyy.mm":
		//	case "GGYY/MM":
		//	case "ggYY.MM.DD":
		//	case "ggyy.mm.dd":
		//	case "ggYY.MM":
		//	case "ggyy.mm":
		//	case "HHMMSS":
		//	case "HHMM":
		//	case "HH":
		//	case "HH:MM:SS":
		//	case "HH:MM":
	}

	/// <summary>
	/// LongDate形式日付の編集方法
	/// </summary>
	public enum TLongDateEditor
	{
		/// <summary>
		/// 編集無し
		/// </summary>
		Non,
		/// <summary>
		/// ゼロサプレス
		/// </summary>
		ZeroSuppress
	}

    /// <summary>
    /// 元号リスト取得時のモード。どの元号以降を取得するかの設定に使用する。
    /// ※しばらくは平成以降を表示することしかないと思われるため、
    /// 　2019年新元号以降を取得するモードは追加していません。
    /// 　必要がある場合にモードの追加を行ってください。
    /// </summary>
    public enum TDateTimeGengouMode : int
    {
        /// <summary>
        /// デフォルト：0
        /// （通常は明治以降を取得するモードと同等で動作しますが、TDateEditのように平成以降が前提というような場合は
        /// 　呼び出し元で適切なモードに変更してください）
        /// </summary>
        Default = 0,
        /// <summary>
        /// 明治以降を取得するモード：1
        /// </summary>
        StartsWithMeiji = 1,
        /// <summary>
        /// 大正以降を取得するモード：2
        /// </summary>
        StartsWithTaisho = 2,
        /// <summary>
        /// 昭和以降を取得するモード：3
        /// </summary>
        StartsWithShowa = 3,
        /// <summary>
        /// 平成以降を取得するモード：4
        /// </summary>
        StartsWithHeisei = 4,
    }

    /// <summary>
    /// 元号データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : XMLから読み込んだ元号の情報を保持するクラスです。</br>
    /// <br>Programmer : 31983 友廣 真一</br>
    /// <br>Date       : 2018.12.12</br>
    /// </remarks>
    public class EraInfo
    {
        /// <summary>
        /// 元号名（例：平成）
        /// </summary>
        private string _eraName;
        /// <summary>
        /// 元号略称（例：平）
        /// </summary>
        private string _eraShortName;
        /// <summary>
        /// 元号大文字頭文字（例：H）
        /// </summary>
        private string _eraUpperInitial;
        /// <summary>
        /// 元号小文字頭文字（例：h）
        /// </summary>
        private string _eraLowerInitial;
        /// <summary>
        /// 元号開始日
        /// </summary>
        private DateTime _startDate;
        /// <summary>
        /// 元号終了日（現行の元号の場合は、DateTime.MaxValueを設定）
        /// </summary>
        private DateTime _endDate;

        /// <summary>
        /// 元号名（例：平成）
        /// </summary>
        public string EraName
        {
            get { return this._eraName; }
            set { this._eraName = value; }
        }

        /// <summary>
        /// 元号略称（例：平）
        /// </summary>
        public string EraShortName
        {
            get { return this._eraShortName; }
            set { this._eraShortName = value; }
        }

        /// <summary>
        /// 元号大文字頭文字（例：H）
        /// </summary>
        public string EraUpperInitial
        {
            get { return this._eraUpperInitial; }
            set { this._eraUpperInitial = value; }
        }

        /// <summary>
        /// 元号小文字頭文字（例：h）
        /// </summary>
        public string EraLowerInitial
        {
            get { return this._eraLowerInitial; }
            set { this._eraLowerInitial = value; }
        }

        /// <summary>
        /// 元号開始日
        /// </summary>
        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        /// <summary>
        /// 元号終了日
        /// </summary>
        public DateTime EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        /// <summary>
        /// 現在の元号か否か
        /// </summary>
        public bool IsPresentEra
        {
            get { return (_startDate <= DateTime.Today) && (DateTime.Today <= _endDate); }
        }

        /// <summary>
        /// 西暦→和暦年変換時の基準年
        /// （開始年の1年前。西暦から基準年を引くことで和暦年を算出する）
        /// </summary>
        public int BaseYear
        {
            get { return _startDate.Year - 1; }
        }
    }

    /// <summary>
    /// 各フォームのフォーマット情報
    /// </summary>
    public class FormDateFormatInfo
    {
        /// <summary>
        /// フォーム名
        /// </summary>
        private string _formName;
        /// <summary>
        /// 
        /// </summary>
        private DateFormatInfo[] _dateFormatInfoArray;

        /// <summary>
        /// フォーム名
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateFormatInfo[] DateFormatInfoArray
        {
            get { return _dateFormatInfoArray; }
            set { _dateFormatInfoArray = value; }
        }
    }

    /// <summary>
    /// 各コンポーネントの日付フォーマット情報
    /// </summary>
    public class DateFormatInfo
    {
        /// <summary>
        /// コンポーネント名
        /// </summary>
        private string _componentName;

        /// <summary>
        /// 日付フォーマット
        /// </summary>
        private string _dateFormat;

        /// <summary>
        /// コンポーネント名称
        /// </summary>
        public string ComponentName
        {
            get { return _componentName; }
            set { _componentName = value; }
        }
        /// <summary>
        /// 日付フォーマット
        /// </summary>
        public string DateFormat
        {
            get { return _dateFormat; }
            set { _dateFormat = value; }
        }
    }


	/// <summary>
	/// 日付時刻操作クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       :  日付,時刻に関連する各種操作を提供します</br>
	/// <br>Programmer : 980056 R.Sokei</br>
	/// <br>Date       : 2004.11.27</br>
	/// <br></br>
	/// </remarks>
	public class TDateTime
	{
		private const int ctYearDef = 19000000;		// YYYY --> 1900
		private const int ctMonthDayDef = 101;		// MMDD --> 0101

        /// <summary>
        /// 元号情報のXMLファイル
        /// </summary>
        private const string ERAINFO_XML_FILENAME = "ERAINFO.xml";
        /// <summary>
        /// 日付フォーマット情報のXMLファイル
        /// </summary>
        private const string DATETIMEFORMATINFO_XML_FILENAME = "DATETIMEFORMATINFO.xml";
        /// <summary>
        /// 元号情報
        /// </summary>
        private static ArrayList _eraInfoList = new ArrayList();
        /// <summary>
        /// 元号リスト
        /// </summary>
        private static ArrayList _eraNameList = new ArrayList();
        /// <summary>
        /// 日付フォーマット情報リスト
        /// </summary>
        private static Dictionary<string, Dictionary<string, string>> _formDateTimeFormat = null;

		/// **********************************************************************
		/// Module name      : xDateTime
		/// <summary>
		///                    日付時刻クラスコンストラクタ
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   日付時刻クラスコンストラクタ</br>
		/// <br>Programer        :   R.Sokei                     </br>
		/// <br>Date             :   2004.12.04                  </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		private TDateTime()
		{
			//
			// メンバが全て static なので、インスタンスが生成されないようにする
			//
		}

		// システム日付の取得(SF.NET)
		// システム時刻を取得する(SF.NET)
		/// **********************************************************************
		/// Module name      : GetSFDateNow
		/// <summary>
		///                    SF.NETシステムで定義されているシステム日付
		///                    を取得します(SF.NETシステム日付)
		/// </summary>
		/// <returns>
		///                    SFシステム日付(DateTime型)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   SF.NETシステムの現在の日付と時刻を取得します</br>
		/// <br>Programer        :   R.Sokei                                     </br>
		/// <br>Date             :   2004.12.06                                  </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static DateTime GetSFDateNow()
		{
			// メーカーシステム等でサーバ時刻を使用する必要がある場合は、
			// 以下の記述を変更してサーバ時刻を返すように変更してください

			DateTime myDateTime = DateTime.Now;
			return myDateTime;
		}

		// システム日付の取得(SF.NET)(YYYYMMDD)
		// システム時刻を取得する(SF.NET)(HHMMDD)
		/// **********************************************************************
		/// Module name      : GetSFDateNow
		/// <summary>
		///                    SF.NETシステムで定義されているシステム日付
		///                    を取得します(SF.NETシステム日付)
		/// </summary>
		/// <param name="dateFormat">
		///                    日付フォーマット形式
		/// </param>
		/// <returns>
		///                    SFシステム日付(Int型)(YYYYMMDD形式)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   SFシステムの現在の日付を取得する</br>
		/// <br>                     戻り値は、指定された形式(YYYYMMDD,YYYYMM･･･)のint型を返す</br>
		/// <br>Programer        :   R.Sokei                         </br>
		/// <br>Date             :   2004.12.06                      </br>
		/// <br>Update Note      :                 </br>
		/// </remarks>
		/// **********************************************************************
		public static int GetSFDateNow(string dateFormat)
		{
			// メーカーシステム等でサーバ時刻を使用する必要がある場合は、
			// 以下の記述を変更してサーバ時刻を返すように変更してください

			// 現在の日付時刻を取得
			DateTime myDateTime = DateTime.Now;
			int ldate = 0;
			switch (dateFormat.Trim().ToUpper())
			{
				case "YYYYMMDD":
					{
						// 日付をYYYYMMDD形式に変換
						ldate = DateTimeToLongDate(myDateTime);
						break;
					}
				case "YYYYMM":
					{
						// 日付をYYYYMMDD形式に変換
						ldate = DateTimeToLongDate("YYYYMM", myDateTime);
						break;
					}
				case "YYYY":
					{
						// 日付をYYYYMMDD形式に変換
						ldate = DateTimeToLongDate("YYYY", myDateTime);
						break;
					}
				case "MM":
					{
						// 日付をYYYYMMDD形式に変換
						ldate = DateTimeToLongDate("MM", myDateTime);
						break;
					}
				case "DD":
					{
						// 日付をYYYYMMDD形式に変換
						ldate = DateTimeToLongDate("DD", myDateTime);
						break;
					}
				case "HHMMSS":
					{
						ldate = DateTimeToLongDate("HHMMSS", myDateTime);
						break;
					}
			}

			return ldate;
		}

		// LongDate型(YYYYMMDD) -> DateTime型に変換
		/// **********************************************************************
		/// Module name      : LongDateToDateTime
		/// <summary>
		///                    LongDate型(YYYYMMDD)の日付をDateTime型に変換します
		/// </summary>
		/// <param name="inLongDate">
		///                    変換対象日付(LonDate形式)
		/// </param>
		/// <returns>
		///                    日付変換結果(DateTime型)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <list type="bullet">
		/// <item>longDateFormat形式 : 変換例(入力が2004/12/10の場合)</item>
		/// <item>YYYYMMDD : 20041210</item>
		/// <item>YYYYMM   : 200412</item>
		/// <item>YYMMDD   : 041210</item>
		/// <item>MMDD     : 1210</item>
		/// </list>
		/// <br>Note　　　　　　 :   LongDate形式(YYYYMMDD)の日付をDateTime型に変換する</br>
		/// <br>Programer        :   R.Sokei                                    </br>
		/// <br>Date             :   2004.12.06                                      </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static DateTime LongDateToDateTime(int inLongDate)
		{
			return LongDateToDateTime("YYYYMMDD", inLongDate);
		}

		// LongDate型(YYYYMMDD) -> DateTime型に変換
		/// **********************************************************************
		/// Module name      : LongDateToDateTime
		/// <summary>
		///                    LongDate型(YYYYMMDD)の日付をDateTime型に変換します
		/// </summary>
		/// <param name="longDateFormat">
		///                    LongDate日付フォーマット形式
		/// </param>
		/// <param name="inLongDate">
		///                    変換対象日付(LonDate形式)
		/// </param>
		/// <returns>
		///                    日付変換結果(DateTime型)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <list type="bullet">
		/// <item>longDateFormat形式 : 変換例(入力が2004/12/10の場合)</item>
		/// <item>YYYYMMDD : 20041210</item>
		/// <item>YYYYMM   : 200412</item>
		/// <item>YYMMDD   : 041210</item>
		/// <item>MMDD     : 1210</item>
		/// </list>
		/// <br>Note　　　　　　 :   LongDate形式(YYYYMMDD)の日付をDateTime型に変換する</br>
		/// <br>Programer        :   R.Sokei                                    </br>
		/// <br>Date             :   2004.12.06                                      </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static DateTime LongDateToDateTime(string longDateFormat, int inLongDate)
		{
			DateTime tmpDateTime = new DateTime(0);
			if (inLongDate > 0)
			{
				try
				{
					// LongDate形式の値チェック

					// LongDate-->Stringに変換
					string sStrDate = LongDateToBaseString(longDateFormat, inLongDate);

					switch (longDateFormat.ToUpper())
					{
						case "YYYYMMDD":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "yyyyMMdd");
								break;
							}
						case "YYYYMM":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "yyyyMM");
								break;
							}
						case "YYMMDD":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "yyMMdd");
								break;
							}
						case "MMDD":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "MMdd");
								break;
							}
						case "HHMMSS":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "HHmmss");
								break;
							}
						case "HHMM":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "HHmm");
								break;
							}
						case "MMSS":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "mmss");
								break;
							}
						default:
							{
								break;
							}
					}
				}
				catch (ArgumentNullException)
				{
					tmpDateTime = new DateTime(0);
					// 指定された値がNULLの場合
				}
				catch (FormatException)
				{
					tmpDateTime = new DateTime(0);
					// 指定書式通りに変換できない場合の例外
				}
			}

			return tmpDateTime;
		}

		/// **********************************************************************
		/// Module name      : DateTimeParseExact
		/// <summary>
		///                    日付時刻を表す文字列をDateTime型に変換します
		/// </summary>
		/// <param name="inStrDate">
		///                    変換対象日付(string型)
		/// </param>
		/// <param name="dateFormatStr">
		///                    変換対象日付のフォーマット形式(YYYYMMDD,YYYYMM,...)
		/// </param>
		/// <returns>
		///                    日付変換結果(DateTime型)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   日付時刻を表す文字列をDateTime型に変換します</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		private static DateTime DateTimeParseExact(string inStrDate, string dateFormatStr)
		{

            // 引数がnullの場合は例外
            if (inStrDate == null || dateFormatStr == null)
            {
                throw new ArgumentNullException("引数が設定されていません。");
            }

            // 本クラス内で使用する形式のみ受け付けます
            string[] splitStr;

            #region 文字列分割処理
            try
            {
                switch (dateFormatStr)
                {
                    case "yyyy/M/d":
                    case "ggyy/M/d":
                        splitStr = inStrDate.Split(new char[] { '/' });
                        if (splitStr.Length != 3)
                        {
                            // 3分割でない場合は年月日の分割ではないと判断して例外とする。
                            throw new FormatException("文字列は有効な DateTime ではありませんでした。");
                        }
                        break;
                    case "yyyyMMdd":
                        splitStr = new string[] { inStrDate.Substring(0, 4), inStrDate.Substring(4, 2), inStrDate.Substring(6, 2) };
                        break;
                    case "yyyyMM":
                        splitStr = new string[] { inStrDate.Substring(0, 4), inStrDate.Substring(4, 2) };
                        break;
                    case "yyMMdd":
                    case "HHmmss":
                        splitStr = new string[] { inStrDate.Substring(0, 2), inStrDate.Substring(2, 2), inStrDate.Substring(4, 2) };
                        break;
                    case "MMdd":
                    case "HHmm":
                    case "mmss":
                        splitStr = new string[] { inStrDate.Substring(0, 2), inStrDate.Substring(2, 2) };
                        break;
                    default:
                        splitStr = new string[0];
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Substringに失敗した場合はFormatException（メッセージはDateTime.ParseExactと同じにしておく）
                throw new FormatException("文字列は有効な DateTime ではありませんでした。");
            }
            #endregion

            #region 各型式ごとのDateTime生成処理
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = 0;
            int minute = 0;
            int second = 0;

            try
            {
                switch (dateFormatStr)
                {
                    case "yyyy/M/d":
                    case "yyyyMMdd":
                        year = Int32.Parse(splitStr[0]);
                        month = Int32.Parse(splitStr[1]);
                        day = Int32.Parse(splitStr[2]);
                        break;
                    case "ggyy/M/d":
                        year = GetYearFromJapaneseYear(splitStr[0]);
                        month = Int32.Parse(splitStr[1]);
                        day = Int32.Parse(splitStr[2]);

                        // 元号指定の場合、明治元年（1868年）9月8日より前の場合は例外
                        if (year < 1868 || (year == 1868 && month < 9) || (year == 1868 && month == 9 && day < 8))
                        {
                            // DateTime.Parseの時と同じメッセージにしておく
                            throw new FormatException("文字列で表される DateTime がカレンダー System.Globalization.JapaneseCalendar でサポートされていません。");
                        }

                        break;
                    case "yyyyMM":
                        year = Int32.Parse(splitStr[0]);
                        month = Int32.Parse(splitStr[1]);
                        day = 1;
                        break;
                    case "yyMMdd":
                        year = Int32.Parse(splitStr[0]) + 2000;     // 2桁指定の場合は、2000年代として計算する
                        month = Int32.Parse(splitStr[1]);
                        day = Int32.Parse(splitStr[2]);
                        break;
                    case "MMdd":
                        month = Int32.Parse(splitStr[0]);
                        day = Int32.Parse(splitStr[1]);
                        break;
                    case "HHmmss":
                        hour = Int32.Parse(splitStr[0]);
                        minute = Int32.Parse(splitStr[1]);
                        second = Int32.Parse(splitStr[2]);
                        break;
                    case "HHmm":
                        hour = Int32.Parse(splitStr[0]);
                        minute = Int32.Parse(splitStr[1]);
                        break;
                    case "mmss":
                        minute = Int32.Parse(splitStr[0]);
                        second = Int32.Parse(splitStr[1]);
                        break;
                    default:
                        // 上記以外のパターンが増えた場合は、処理を追加してください。
                        // 受け入れるパターン以外はFormatExceptionをthrowします。
                        throw new FormatException("日時の書式が不正です。");
                }
            }
            catch (IndexOutOfRangeException)
            {
                // 想定した数に分割できていなかった場合
                throw new FormatException("日時の書式が不正です。");
            }

            #endregion
            DateTime returnDt;
            try
            {
                returnDt = new DateTime(year, month, day, hour, minute, second);
            }
            catch (ArgumentException)
            {
                // 日付に変換できない（13月など）場合は、FormatExceptionをthrow（メッセージはDateTime.Parseのものに合わせる）
                throw new FormatException("文字列で表される DateTime がカレンダー System.Globalization.GregorianCalendar でサポートされていません。");
            }

            return returnDt;
        }

        /// <summary>
        /// 和暦の年から西暦に変換して返却します。
        /// 本メソッドで扱える和暦は明治以降のものとし、
        /// 漢字2文字（例：平成）・漢字先頭1文字（例：平）・略号半角大文字（例：H）・略号半角小文字（例：h）のみを扱います。
        /// それ以外のものを付与している場合は、例外を返却します。
        /// </summary>
        /// <exception cref="System.FormatException">
        /// 下記の場合、FormatExceptionが発生します。
        /// 　・引数が空文字の場合
        /// 　・元号に明治以降の元号を指定していない場合
        /// 　・元号の指定が漢字2文字・漢字先頭1文字・略号半角大文字・略号半角小文字以外の場合
        /// 　・元号を除いた文字列に数字以外のものが含まれる場合
        /// 　・元号を除いた文字列の桁数が3桁以上の場合
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// 引数がnullの場合、ArgumentNullExceptionが発生します
        /// </exception>
        /// <param name="japaneseYearStr">和暦の年（元号＋年の結合文字列）</param>
        /// <returns>西暦の年</returns>
        private static int GetYearFromJapaneseYear(string japaneseYearStr)
        {
            if (japaneseYearStr == null)
            {
                throw new ArgumentNullException("和暦の年の設定がありません。");
            }
            else if (japaneseYearStr == string.Empty)
            {
                throw new FormatException("和暦の年に空文字が設定されています。");
            }

            // 各元号の設定ごとに、対象の元号と年に分割する
            string gengo = string.Empty;
            string japaneseYear = string.Empty;

            ArrayList eraInfoList = GetEraInfoList();

            foreach (EraInfo info in eraInfoList)
            {
                // 後々の元号のReplaceのために、設定されている元号そのものを保持しておく
                if (japaneseYearStr.StartsWith(info.EraName))
                {
                    gengo = info.EraName;
                    break;
                }
                else if (japaneseYearStr.StartsWith(info.EraShortName))
                {
                    gengo = info.EraShortName;
                    break;
                }
                else if (japaneseYearStr.StartsWith(info.EraUpperInitial))
                {
                    gengo = info.EraUpperInitial;
                    break;
                }
                else if (japaneseYearStr.StartsWith(info.EraLowerInitial))
                {
                    gengo = info.EraLowerInitial;
                    break;
                }
            }

            if (string.IsNullOrEmpty(gengo))
            {
                throw new FormatException("元号が正しく設定されていません。");
            }

            japaneseYear = japaneseYearStr.Replace(gengo, string.Empty).Trim();

            if (string.IsNullOrEmpty(japaneseYear))
            {
                throw new FormatException("年が正しく設定されていません。");
            }

            return GetYearFromJapaneseYear(gengo, japaneseYear);
        }

        /// <summary>
        /// 和暦の年から西暦に変換して返却します。
        /// 本メソッドで扱える和暦は明治以降のものとし、
        /// 漢字2文字（例：平成）・漢字先頭1文字（例：平）・略号半角大文字（例：H）・略号半角小文字（例：h）のみを扱います。
        /// それ以外のものを付与している場合は、例外を返却します。
        /// </summary>
        /// <exception cref="System.FormatException">
        /// 下記の場合、FormatExceptionが発生します。
        /// 　・引数が空文字の場合
        /// 　・元号に明治以降の元号を指定していない場合
        /// 　・元号の指定が漢字2文字・漢字先頭1文字・略号半角大文字・略号半角小文字以外の場合
        /// 　・元号を除いた文字列に数字以外のものが含まれる場合
        /// 　・元号を除いた文字列の桁数が3桁以上の場合
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// 引数がnullの場合、ArgumentNullExceptionが発生します
        /// </exception>
        /// <param name="gengo">元号</param>
        /// <param name="japaneseYear">和暦の年（年のみ）</param>
        /// <returns>西暦の年</returns>
        private static int GetYearFromJapaneseYear(string gengo, string japaneseYear)
        {
            // 引数チェック
            if (gengo == null)
            {
                throw new ArgumentNullException("元号が正しく設定されていません。");
            }
            else if (gengo == string.Empty)
            {
                throw new FormatException("元号が正しく設定されていません。");
            }
            else if (japaneseYear == null)
            {
                throw new ArgumentNullException("年が正しく設定されていません。");
            }
            else if (japaneseYear == string.Empty)
            {
                throw new FormatException("年が正しく設定されていません。");
            }
            else if (japaneseYear.Length > 2)
            {
                throw new FormatException("年に3桁以上の値が設定されています。");
            }

            // 基準年（各元号の0年に相当する西暦）を算出
            ArrayList eraInfoList = GetEraInfoList();
            int baseYear = 0;

            foreach (EraInfo info in eraInfoList)
            {
                if (gengo == info.EraName || gengo == info.EraShortName || gengo == info.EraUpperInitial || gengo == info.EraLowerInitial)
                {
                    baseYear = info.BaseYear;
                    break;
                }
            }

            if (baseYear == 0)
            {
                throw new FormatException("元号が正しく設定されていません。");
            }

            // 数字以外が含まれるFormatExceptionはそのままthrowするため、Parse処理でtry-catchはしない
            return Int32.Parse(japaneseYear) + baseYear;

        }

		// DateTime型 -> LongDate型(YYYYMMDD)に変換
		/// **********************************************************************
		/// Module name      : DateTimeToLongDate
		/// <summary>
		///                    DateTime型の日付をLongDate型(YYYYMMDD)に変換します
		/// </summary>
		/// <param name="inDateTime">
		///                    変換対象日付(DateTime型)
		/// </param>
		/// <returns>
		///                    日付変換結果(LonDate形式)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   DateTime型の日付をLongDate形式(YYYYMMDD)に変換する</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static int DateTimeToLongDate(DateTime inDateTime)
		{
			int rLongDate = 0;

			//if (inDateTime != DateTime.MinValue)
			//{
			rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMMdd"));
			//}

			return rLongDate;
		}

		/// **********************************************************************
		/// Module name      : DateTimeToLongDate
		/// <summary>
		///                    DateTime型の日付をLongDate型(YYYYMMDD)に変換します
		/// </summary>
		/// <param name="dateFormat">
		///                    日付フォーマット形式
		/// </param>
		/// <param name="inDateTime">
		///                    変換対象日付(DateTime型)
		/// </param>
		/// <returns>
		///                    日付変換結果(LonDate形式)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   DateTime型の日付をLongDate形式(YYYYMMDD)に変換する</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static int DateTimeToLongDate(string dateFormat, DateTime inDateTime)
		{
			int rLongDate = 0;
			// 指定形式の桁に編集
			//if ((inDateTime == null) || (inDateTime == DateTime.MinValue))
			//{
			//    rLongDate = 0;
			//}
			//else
			{
				switch (dateFormat.ToUpper())
				{
					case "YYYYMMDD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMMdd"));
							break;
						}
					case "YYMMDD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyMMdd"));
							break;
						}
					case "YYYYMM":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMM"));
							break;
						}
					case "MMDD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("MMdd"));
							break;
						}
					case "YYYY":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyy"));
							break;
						}
					case "MM":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("MM"));
							break;
						}
					case "DD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("dd"));
							break;
						}
					case "HHMMSS":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("HHmmss"));
							break;
						}
					default:
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMMdd"));
							break;
						}
				}
			}

			return rLongDate;
		}

		// 日付分割(年,月,日)
		// 日付分割(年,月,日)(YYYYMMDD)
		/// **********************************************************************
		/// Module name      : SplitDate
		/// <summary>
		///                    指定された日付を(元号,年,月,日)に分割します
		/// </summary>
		/// <param name="dateFormat">
		///                    日付フォーマット形式
		/// </param>
		/// <param name="orgDate">
		///                    分割対象日付(YYYYMMDD形式)
		/// </param>
		/// <param name="rGengo">
		///                    分割結果(元号)
		/// </param>
		/// <param name="rYear">
		///                    分割結果(年)
		/// </param>
		/// <param name="rMonth">
		///                    分割結果(月)
		/// </param>
		/// <param name="rDay">
		///                    分割結果(日)
		/// </param>
		/// <returns>
		///                    分割結果(0:成功, -1:分割失敗)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   日付を年,月,日に分割して指定された引数に返す</br>
		/// <br>                     戻り値は、分割結果(成否)を返す</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static int SplitDate(string dateFormat, int orgDate, ref string rGengo, ref int rYear, ref int rMonth, ref int rDay)
		{
			if (orgDate == 0)
			{
				rGengo = "";
				rYear = 0;
				rMonth = 0;
				rDay = 0;
				return 0;
			}

			rGengo = "";
			int lYear = 0, lMonth = 0, lDay = 0;

			//// 入力値が不正な場合は、デフォルト値に自動変換
			//if (orgDate < (ctYearDef + ctMonthDayDef))
			//    orgDate = orgDate + ctYearDef;

			//// DateTime型に変換
			//DateTime orgDateTime = LongDateToDateTime("YYYYMMDD", orgDate);

			//// 日付分割
			//SplitDate(dateFormat, orgDateTime, ref lGengo, ref lYear, ref lMonth, ref lDay);

			//rGengo = lGengo;
			//rYear = lYear;
			//rMonth = lMonth;
			//rDay = lDay;
			//return 0;

			lYear = (orgDate / 10000);
			lMonth = ((orgDate % 10000) / 100);
			lDay = orgDate % 100;

			// 元号,年 を分割･生成
			switch (dateFormat.ToUpper())
			{
				case "YYYYMMDD":
					{
						lYear = (orgDate / 10000);
						lMonth = ((orgDate % 10000) / 100);
						lDay = orgDate % 100;
						break;
					}
				case "YYMMDD":
					{
						//lyy = ((orgDate % 1000000) / 10000);
						lYear = (orgDate / 10000);
						lMonth = ((orgDate % 10000) / 100);
						lDay = orgDate % 100;
						break;
					}
				case "YYYYMM":
					{
						lYear = (orgDate / 100);
						lMonth = ((orgDate % 10000) / 100);
						lDay = 1;
						break;
					}
				case "GGYYMMDD":
					{
						try
						{
							int lMonthTmp = lMonth;
							int lDayTmp = lDay;

                            // ※元号情報リストは新しい元号から順に並んでいる
                            ArrayList eraInfoList = GetEraInfoList();

                            if (lMonthTmp == 0)
                            {
                                // 月指定がない場合の月日設定は1月1日とする。
                                // 　＜例外パターン＞
                                // 　　元号の終了年の場合は、その年の最終元号の開始日とする。

                                lMonthTmp = 1;
                                lDayTmp = 1;

                                // ただし、元号の終了年の場合は後の元号を優先する。（元号終了日が12/31の場合を除く）
                                foreach (EraInfo info in eraInfoList)
                                {
                                    if (lYear == info.EndDate.Year)
                                    {
                                        // 終了日の翌日を設定して次の元号扱いとする。（その年の最終元号になる）
                                        DateTime eraEndDateNextDay = info.EndDate.AddDays(1);
                                        if (lYear != eraEndDateNextDay.Year)
                                        {
                                            // 元号の終了日が12月31日（元号終了日翌日が翌年のため一致しない）の場合は1月1日とする。（何もせずにbreak）
                                            // ただし、元号の開始日と終了日が同じ年の場合は、その元号の開始日を設定する。（その年の最終元号になる）
                                            if (lYear == info.StartDate.Year)
                                            {
                                                lMonthTmp = info.StartDate.Month;
                                                lDayTmp = info.StartDate.Day;
                                            }
                                            break;
                                        }

                                        lMonthTmp = eraEndDateNextDay.Month;
                                        lDayTmp = eraEndDateNextDay.Day;
                                        break;
                                    }
                                    else if (info.StartDate.Year < lYear && lYear < info.EndDate.Year)
                                    {
                                        // 対象の元号に含まれる場合は、以後の元号を見る必要がないためbreakする。
                                        // （ただし、元年に相当する年の場合は前の元号の終了年に当たるため、処理継続）
                                        break;
                                    }
                                }
                            }
                            else if (lDayTmp == 0)
                            {
                                // 日指定がない場合の日設定は1日とする。
                                // 　＜例外パターン＞
                                // 　　元号の終了年月の場合は、その年月の最終元号の開始日とする。

                                lDayTmp = 1;

                                // 比較用に年月を連結した数値を持つ
                                int yyyyMm = lYear * 100 + lMonthTmp;

                                // ただし、元号の終了年月の場合は後の元号を優先する。（元号終了日が12/31の場合を除く）
                                foreach (EraInfo info in eraInfoList)
                                {
                                    // 比較用に元号の開始・終了年月を連結した数値を持つ
                                    int eraStartYyyyMm = info.StartDate.Year * 100 + info.StartDate.Month;
                                    int eraEndYyyyMm = info.EndDate.Year * 100 + info.EndDate.Month;

                                    // 元号の終了年・月の場合は後の元号を優先する。
                                    if (yyyyMm == eraEndYyyyMm)
                                    {
                                        DateTime eraEndDateNextDay = info.EndDate.AddDays(1);

                                        if (lMonthTmp != eraEndDateNextDay.Month)
                                        {
                                            // 元号の終了日が月末（元号終了日翌日が翌月）の場合は1日とする。（何もせずにbreak）
                                            // ただし、元号の開始日が同じ年月の場合は、その元号の開始日を設定する。
                                            if (yyyyMm == eraStartYyyyMm)
                                            {
                                                lDayTmp = info.StartDate.Day;
                                            }
                                            break;
                                        }

                                        // それ以外の場合は、終了日の翌日を設定して次の元号扱いとする。
                                        lDayTmp = eraEndDateNextDay.Day;
                                        break;
                                    }
                                    else if (eraStartYyyyMm < yyyyMm && yyyyMm < eraEndYyyyMm)
                                    {
                                        // 年月が対象の元号に含まれる場合は、以後の元号を見る必要がないためbreakする。
                                        // （ただし、元年に相当する年の改元月の場合は前の元号の終了年月に当たるため、処理継続）
                                        break;
                                    }
                                }
                            }

                            GetJapaneseEraFromYMD(lYear, lMonthTmp, lDayTmp, ref rGengo, ref lYear);
						}
                        catch (ArgumentOutOfRangeException)
						{
                            // 日付の範囲を超えた場合
						}

						break;
					}
				default:
					{
						break;
					}
			}
			rYear = lYear;
			// 月,日 を分割
			rMonth = lMonth;
			rDay = lDay;

			return 0;
		}

        //2012.03.30 23011 noguchi 毎回呼び出すとオーバーヘッドが大きいためクラス変数化 >>
        // 元号取得の場合のみ、Japaneseカルチャーのカレンダーを取得する
        private static System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
        private static System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
        //>> 2012.03.30 23011 noguchi 毎回呼び出すとオーバーヘッドが大きいためクラス変数化



		/// **********************************************************************
		/// Module name      : SplitDate
		/// <summary>
		///                    指定された日付を(元号,年,月,日)に分割します
		/// </summary>
		/// <param name="dateFormat">
		///                    日付フォーマット形式
		/// </param>
		/// <param name="orgDate">
		///                    分割対象日付(DateTime型)
		/// </param>
		/// <param name="rGengo">
		///                    分割結果(元号)
		/// </param>
		/// <param name="rYear">
		///                    分割結果(年)
		/// </param>
		/// <param name="rMonth">
		///                    分割結果(月)
		/// </param>
		/// <param name="rDay">
		///                    分割結果(日)
		/// </param>
		/// <returns>
		///                    分割結果(0:成功, -1:分割失敗)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   日付を年,月,日に分割して指定された引数に返す</br>
		/// <br>                     戻り値は、分割結果(成否)を返す</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static int SplitDate(string dateFormat, DateTime orgDate, ref string rGengo, ref int rYear, ref int rMonth, ref int rDay)
		{
			rGengo = ""; rYear = 0; rMonth = 0; rDay = 0;
			int lYyyy = 0, lYy = 0, lMonth = 0, lDay = 0;

			lYyyy = Convert.ToInt32(orgDate.ToString("yyyy"));
			lYy = Convert.ToInt32(orgDate.ToString("yy"));
			lMonth = Convert.ToInt32(orgDate.ToString("MM"));
			lDay = Convert.ToInt32(orgDate.ToString("dd"));

			// 元号,年 を分割･生成
			switch (dateFormat)
			{
				case "YYYYMMDD":
					{
						lYy = lYyyy;
						//rMonth = rMonth
						//rDay = rDay
						break;
					}
				case "YYMMDD":
					{
						//lyy = ((orgDate % 1000000) / 10000);
						//lyy = (orgDate / 10000);
						//lMonth = ((orgDate % 10000) / 100);
						//lDay = orgDate % 100;
						break;
					}
				case "YYYYMM":
					{
						lYy = lYyyy;
						//lMonth = ((orgDate % 10000) / 100);
						lDay = 1;
						break;
					}
				case "GGYYMMDD":
					{
                        //2012.03.30 23011 noguchi 不正な日付の場合には元号取得の処理を行なわない。
                        //例外が発生してスピードが落ちる。
                        if (orgDate != DateTime.MinValue
                            && orgDate != DateTime.MaxValue)
                        {
                            try
                            {
                                GetJapaneseEraFromYMD(orgDate, ref rGengo, ref lYy);
                            }
                            catch (System.ArgumentOutOfRangeException)
                            {
                                // 日付の範囲を超えた場合
                            }
                        }

						break;
					}
				default:
					{
						lYy = lYyyy;
						break;
					}
			}

			rYear = lYy;
			rMonth = lMonth;
			rDay = lDay;

			return 0;
		}

        /// <summary>
        /// 西暦の年月日を元に和暦の元号と年を返却します。
        /// ※CultureInfoに"ja-JP"を設定した際のDateTime.ToString(DateTime, CultureInfo)と同様に、
        /// 　明治時代は1868年1月1日～とし、それより前の日を指定した場合はArgumentOutOfRangeExceptionをthrowします。
        /// 　また、未来の日付に関しては、最新の元号を返却します。
        /// </summary>
        /// <param name="year">西暦の年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="gengo">元号（返却値）</param>
        /// <param name="japaneseYear">和暦の年（返却値）</param>
        private static void GetJapaneseEraFromYMD(int year, int month, int day, ref string gengo, ref int japaneseYear)
        {
            GetJapaneseEraFromYMD(new DateTime(year, month, day), ref gengo, ref japaneseYear);
        }

        /// <summary>
        /// 西暦の年月日を元に和暦の元号と年を返却します。
        /// ※CultureInfoに"ja-JP"を設定した際のDateTime.ToString(DateTime, CultureInfo)と同様に、
        /// 　明治時代は1868年1月1日～とし、それより前の日を指定した場合はArgumentOutOfRangeExceptionをthrowします。
        /// 　また、未来の日付に関しては、最新の元号を返却します。
        /// </summary>
        /// <param name="dt">取得対象の日付</param>
        /// <param name="gengo">元号（返却値）</param>
        /// <param name="japaneseYear">和暦の年（返却値）</param>
        private static void GetJapaneseEraFromYMD(DateTime dt, ref string gengo, ref int japaneseYear)
        {
            gengo = string.Empty;
            japaneseYear = 0;

            ArrayList eraInfoList = GetEraInfoList();

            foreach (EraInfo info in eraInfoList)
            {
                // 渡された日付が、各元号の開始～終了日に含まれているかを確認する
                if (info.StartDate <= dt && dt <= info.EndDate)
                {
                    gengo = info.EraName;
                    japaneseYear = dt.Year - info.BaseYear;
                    break;
                }
            }

            // 明治より前については例外とする（エラーメッセージはDateTime.ToString(DateTime, CultureInfo)の例外発生時と同様）
            if (gengo == string.Empty)
            {
                throw new ArgumentOutOfRangeException("指定された引数は、有効な値の範囲内にありません。\r\nパラメータ名: 時間値が年号の範囲を超えています。");
            }

            return;
        }

		// 指定日付を『元号YY年MM月DD日』に編集する    GGYYMMDD, GGYY/MM/DD, GGYY.MM.DD
		// 指定日付を『元号YY年MM月』に編集する        GGYY/MM, GGYY.MM
		// 指定日付を『元号YY年』に編集する            GGYY
		// 指定日付を『略号YY年MM月DD日』に編集する    ggYYMMDD, ggYY/MM/DD, ggYY.MM.DD
		// 指定日付を『略号YY年MM月』に編集する        ggYY/MM, ggYY.MM
		// 指定日付を『略号YY年』に編集する            ggYY
		// 指定日付を『YYYY年MM月DD日』に編集する      YYYYMMDD, YYYY/MM/DD, YYYY.MM.DD
		// 指定日付を『YYYY年MM月』に編集する          YYYYMM, YYYY/MM, YYYY.MM
		// 指定日付を『YYYY年』に編集する              YYYY

		// 指定日付を『元号YY/MM/DD』に編集する
		// 指定日付を『元号YY/MM』に編集する
		// 指定日付を『略号YY/MM/DD』に編集する
		// 指定日付を『略号YY/MM』に編集する
		// 指定日付を『略号YY』に編集する
		// 指定日付を『YYYY/MM/DD日』に編集する
		// 指定日付を『YYYY/MM』に編集する
		// 指定日付を『YYYY』に編集する

		// 指定日付を『元号YY.MM.DD』に編集する
		// 指定日付を『元号YY.MM』に編集する
		// 指定日付を『略号YY.MM.DD』に編集する
		// 指定日付を『略号YY.MM』に編集する
		// 指定日付を『略号YY』に編集する
		// 指定日付を『YYYY.MM.DD日』に編集する
		// 指定日付を『YYYY.MM』に編集する
		// 指定日付を『YYYY』に編集する
		// 指定時刻を『HH時MM分SS秒』に編集する
		// 指定時刻を『HH時MM分』に編集する
		// 指定時刻を『HH時』に編集する
		// 指定時刻を『HH:MM:SS』に編集する
		// 指定時刻を『HH:MM』に編集する
		// 指定時刻を『HH』に編集する

		///// <summary>
		///// DateTime --> 日付文字列変換
		///// </summary>
		///// <param name="dateFormat">日付フォーマット形式</param>
		///// <param name="inDateTime">変換対象日付(DateTime型)</param>
		///// <returns>日付変換結果(指定された形式の文字列)</returns>
		///// <remarks>
		///// <br>Note		 :   DateTime型,LongDate型(YYYYMMDD)の日付を指定されたフォーマット</br>
		/////	<br>		 	     形式の文字列に変換します</br>
		/////	<br>					日付フォーマットは、以下の様式を指定します</br>
		/////	<br>					</br>
		/////	<br>					フォーマット形式 : 出力結果(例)</br>
		/////	<br>					</br>
		/////	<br>				YYYYMMDD   : 2004年01月01日</br>
		/////	<br>				YYYYmmdd   : 2004年 1月 1日</br>
		/////	<br>				YYYYMM     : 2004年01月</br>
		/////	<br>				YYYYmm     : 2004年 1月</br>
		/////	<br>				GGYYMMDD   : 平成16年01月01日</br>
		/////	<br>				GGyymmdd   : 平成 5年 1月 1日</br>
		/////	<br>				GGYYMM     : 平成16年01月</br>
		/////	<br>				GGyymm     : 平成 5年 1月</br>
		/////	<br>				ggYYMM     : H16年01月</br>
		/////	<br>				ggyymm     : H 5年 1月</br>
		/////	<br>				ggYY/MM/DD : H16/01/01</br>
		/////	<br>				ggyy/mm/dd : H 5/ 1/ 1</br>
		/////	<br>				ggYY/MM    : H16/01</br>
		/////	<br>				ggyy/mm    : H 5/ 1</br>
		/////	<br>				ggYY.MM.DD : H16.01.01</br>
		/////	<br>				ggyy.mm.dd : H 5. 1. 1</br>
		/////	<br>				ggYY.MM    : H16.01</br>
		/////	<br>				ggyy.mm    : H 5. 1</br>
		/////	<br>				GGYY       : 平成16年</br>
		/////	<br>				ggYY       : H16年</br>
		/////	<br>				GGyy       : 平成 5年</br>
		/////	<br>				ggyy       : H 5年</br>
		/////	<br>				YYYY/MM/DD : 2004/01/01</br>
		/////	<br>				YYYY/mm/dd : 2004/ 1/ 1</br>
		/////	<br>				YYYY.MM.DD : 2004.01.01</br>
		/////	<br>				YYYY.mm.dd : 2004. 1. 1</br>
		/////	<br>				exggYY     : H16</br>
		/////	<br>				exggyy     : H 5</br>
		/////	<br>				ggYY.      : H16</br>
		/////	<br>				ggyy.      : H 5</br>
		/////	<br>				ggYY/      : H16</br>
		/////	<br>				ggyy/      : H 5</br>
		/////	<br>				GG         : 平成</br>
		/////	<br>				gg         : H</br>
		/////	・	<br>            	GGYY/MM    : H18/08</br>
		/////                         この定義が間違っています。 本来 GGYY/MM では以下の exGGYY/MM と同等の結果を返さなければ
		/////			                いけませんが、既にこの定義を使用している処理があるのでこのままにしておきます。
		/////	<br>				exGGYY/MM  : 上記 GGYY/MM の代わりに使用してください。 元号 + 年 + / +月  例) 平成18/08</br>
		/////	<br>				</br>
		///// <br>Programer        :   R.Sokei</br>
		///// <br>Date             :   2004.12.06</br>
		///// </remarks>

		/// <summary>
		/// DateTime --> 日付文字列変換
		/// </summary>
		/// <param name="dateFormat">日付フォーマット形式</param>
		/// <param name="inDateTime">変換対象日付(DateTime型)</param>
		/// <returns>日付変換結果(指定された形式の文字列)</returns>
		/// <remarks>
		/// <br>Note		 :   DateTime型,LongDate型(YYYYMMDD)の日付を指定されたフォーマット</br>
		///	<br>		 	     形式の文字列に変換します</br>
		///	<br>					</br>
		///	<br>					</br>
		///
		///	日付フォーマットは、以下の様式を指定します
		/// <list type="bullet">
		///	<item>フォーマット形式(dateFormat) : 出力結果(例)</item>
		///	<item>YYYYMMDD   : 2004年01月01日</item>
		///	<item>YYYYmmdd   : 2004年 1月 1日</item>
		///	<item>YYYYMM     : 2004年01月</item>
		///	<item>YYYYmm     : 2004年 1月</item>
		///	<item>GGYYMMDD   : 平成16年01月01日</item>
		///	<item>GGyymmdd   : 平成 5年 1月 1日</item>
		///	<item>GGYYMM     : 平成16年01月</item>
		///	<item>GGyymm     : 平成 5年 1月</item>
		///	<item>ggYYMM     : H16年01月</item>
		///	<item>ggyymm     : H 5年 1月</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : 平成16年</item>
		///	<item>ggYY       : H16年</item>
		///	<item>GGyy       : 平成 5年</item>
		///	<item>ggyy       : H 5年</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : 平成</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// この定義が間違っています。 本来 GGYY/MM では以下の exGGYY/MM と同等の結果を返さなければ
		///	いけませんが、既にこの定義を使用している処理があるのでこのままにしておきます。</item>
		///	<item>				exGGYY/MM  : 上記 GGYY/MM の代わりに使用してください。 元号 + 年 + / +月  例) 平成18/08</item>
		/// </list>
		///	<br>				</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// </remarks>
		public static string DateTimeToString(string dateFormat, DateTime inDateTime)
		{
			string rDate;
			string rGengo = ""; int rYear = 0; int rMonth = 0; int rDay = 0;

			SplitDate("GGYYMMDD", inDateTime, ref rGengo, ref rYear, ref rMonth, ref rDay);

			// 指定形式の桁に編集
			if (inDateTime.Equals(DateTime.MinValue))
			{
				// 日付データが未入力(DateTime.MinValue)の場合は文字列を返さない
				rDate = "";
			}
			else
			{
				switch (dateFormat)
				{
					case "GGYYMMDD":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("年MM月dd日");
							break;
						}
					case "GGyymmdd":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月" + inDateTime.ToString("%d").PadLeft(2) + "日";
							break;
						}
					case "ggYYMMDD":
						{
							// 略号取得 致します
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("年MM月dd日");
							break;
						}
					case "ggyymmdd":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月" + inDateTime.ToString("%d").PadLeft(2) + "日";
							break;
						}
					case "GGYYMM":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("年MM月");
							break;
						}
					case "GGyymm":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月";
							break;
						}
					case "GGYY":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + "年";
							break;
						}
					case "GGyy":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "年";
							break;
						}
					case "ggYYMM":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("年MM月");
							break;
						}
					case "ggyymm":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月";
							break;
						}
					case "ggYY":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + "年";
							break;
						}
					case "ggyy":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "年";
							break;
						}
					case "gg":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo);
							break;
						}
					case "GG":
						{
							rDate = rGengo;
							break;
						}
					case "exggYY":
						{
							// 拡張形式で定義されています。
							// 同一結果の得られる "ggYY." を使用してください

							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0');
							break;
						}
					case "exggyy":
						{
							// 拡張形式で定義されています。
							// 同一結果の得られる "ggyy." を使用してください

							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2);
							break;
						}
					case "ggYY.":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0');
							break;
						}
					case "ggyy.":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2);
							break;
						}
					case "ggYY/":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0');
							break;
						}
					case "ggyy/":
						{
							// 略号取得
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2);
							break;
						}
					case "YYYYMMDD":
						{
							rDate = inDateTime.ToString("yyyy年MM月dd日");
							break;
						}
					case "YYYYmmdd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月" + inDateTime.ToString("%d").PadLeft(2) + "日";
							break;
						}
					case "yyyymmdd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月" + inDateTime.ToString("%d").PadLeft(2) + "日";
							break;
						}
					case "YYMMDD":
						{
							rDate = inDateTime.ToString("yy年MM月dd日");
							break;
						}
					case "YYYYMM":
						{
							rDate = inDateTime.ToString("yyyy年MM月");
							break;
						}
					case "YYYYmm":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "年" + inDateTime.ToString("%M").PadLeft(2) + "月";
							break;
						}
					case "MMDD":
						{
							rDate = inDateTime.ToString("MM月dd日");
							break;
						}
					case "YYYY":
						{
							rDate = inDateTime.ToString("yyyy年");
							break;
						}
					case "MM":
						{
							rDate = inDateTime.ToString("MM月");
							break;
						}
					case "DD":
						{
							rDate = inDateTime.ToString("dd日");
							break;
						}
					case "YYYY/MM/DD":
						{
							rDate = inDateTime.ToString("yyyy/MM/dd");
							break;
						}
					case "YYYY/mm/dd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "/" + inDateTime.ToString("%M").PadLeft(2) + "/" + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "YY/MM/DD":
						{
							rDate = inDateTime.ToString("yy/MM/dd");
							break;
						}
					case "YYYY/MM":
						{
							rDate = inDateTime.ToString("yyyy/MM");
							break;
						}
					case "YYYY/mm":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "/" + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "YYYY.MM.DD":
						{
							rDate = inDateTime.ToString("yyyy.MM.dd");
							break;
						}
					case "YY/MM":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "/" + inDateTime.ToString("%M").PadLeft(2, '0');
							break;
						}
					case "YY/mm":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "/" + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "YYYY.MM":
						{
							rDate = inDateTime.ToString("yyyy.MM");
							break;
						}
					case "YYYY.mm":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "YYYY.mm.dd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "." + inDateTime.ToString("%M").PadLeft(2) + "." + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "YY.MM.DD":
						{
							//rDate = inDateTime.ToString("yy.MM.dd");
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "." + inDateTime.ToString("%M").PadLeft(2, '0') + "." + inDateTime.ToString("%d").PadLeft(2, '0');
							break;
						}
					case "YY.MM":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "." + inDateTime.ToString("%M").PadLeft(2, '0');
							break;
						}
					case "YY.mm":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "GGYY/MM/DD":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM/dd");
							break;
						}
					case "GGyy/mm/dd":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "/" + inDateTime.ToString("%M").PadLeft(2) + "/" + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "ggYY/MM/DD":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM/dd");
							break;
						}
					case "ggyy/mm/dd":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "/" + inDateTime.ToString("%M").PadLeft(2) + "/" + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "GGYY.MM.DD":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM.dd");
							break;
						}
					case "GGyy.mm.dd":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2) + "." + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "GGYY.MM":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM");
							break;
						}
					case "GGyy.mm":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "GGYY/MM":
						{
							// この定義が間違っています。 本来 GGYY/MM では以下の exGGYY/MM と同等の結果を返さなければ
							// いけませんが、既にこの定義を使用している処理があるのでこのままにしておきます。
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM");
							break;
						}
					case "exGGYY/MM":
						{
							// 上記 GGYY/MM の代わりに使用してください。 元号 + 年 + / +月  例) 平成18/08
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM");
							break;
						}
					case "ggYY/MM":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM");
							break;
						}
					case "ggyy/mm":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "/" + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "ggYY.MM.DD":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM.dd");
							break;
						}
					case "ggyy.mm.dd":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2) + "." + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "ggYY.MM":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM");
							break;
						}
					case "ggyy.mm":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "HHMMSS":
						{
							rDate = inDateTime.ToString("HH時mm分ss秒");
							break;
						}
					case "HHMM":
						{
							rDate = inDateTime.ToString("HH時mm分");
							break;
						}
					case "hhmm":
						{
							rDate = inDateTime.ToString("H時m分");
							break;
						}
					case "HH":
						{
							rDate = inDateTime.ToString("HH時");
							break;
						}
					case "HH:MM:SS":
						{
							rDate = inDateTime.ToString("HH:mm:ss");
							break;
						}
					case "HH:MM":
						{
							rDate = inDateTime.ToString("HH:mm");
							break;
						}
					case "":
					default:
						{
							rDate = inDateTime.ToString("yyyy年MM月dd日");
							break;
						}
				}
			}
			return rDate;
		}

		/// <summary>
		/// DateTime --> 日付文字列変換
		/// </summary>
		/// <param name="dateFormat">日付フォーマット形式</param>
		/// <param name="inDateTime">変換対象日付(DateTime型)</param>
		/// <param name="defaultStr">inDateTimeが不正な日付、最小値だった場合に返す文字列</param>
		/// <returns>日付変換結果(指定された形式の文字列)</returns>
		/// <remarks>
		/// <list type="bullet">
		///	<item>フォーマット形式(dateFormat) : 出力結果(例)</item>
		///	<item>YYYYMMDD   : 2004年01月01日</item>
		///	<item>YYYYmmdd   : 2004年 1月 1日</item>
		///	<item>YYYYMM     : 2004年01月</item>
		///	<item>YYYYmm     : 2004年 1月</item>
		///	<item>GGYYMMDD   : 平成16年01月01日</item>
		///	<item>GGyymmdd   : 平成 5年 1月 1日</item>
		///	<item>GGYYMM     : 平成16年01月</item>
		///	<item>GGyymm     : 平成 5年 1月</item>
		///	<item>ggYYMM     : H16年01月</item>
		///	<item>ggyymm     : H 5年 1月</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : 平成16年</item>
		///	<item>ggYY       : H16年</item>
		///	<item>GGyy       : 平成 5年</item>
		///	<item>ggyy       : H 5年</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : 平成</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// この定義が間違っています。 本来 GGYY/MM では以下の exGGYY/MM と同等の結果を返さなければ
		///	いけませんが、既にこの定義を使用している処理があるのでこのままにしておきます。</item>
		///	<item>				exGGYY/MM  : 上記 GGYY/MM の代わりに使用してください。 元号 + 年 + / +月  例) 平成18/08</item>
		/// </list>
		/// <br>Note       : DateTimeを指定された日付フォーマット形式の文字列に変換します</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public static string DateTimeToString(string dateFormat, DateTime inDateTime, string defaultStr)
		{

			// 日付有効性チェック
			if (!IsAvailableDate(inDateTime))
			{
				return defaultStr;
			}
			else
			{
				// 文字列変換
				return DateTimeToString(dateFormat, inDateTime);
			}
		}

		// 時刻分割(時,分,秒)
		// 時刻分割(時,分,秒)(HHMMSS)

		// 月内日数を取得する(末日取得)
		/// <summary>
		/// 月内日数を取得する(末日取得)
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="month">月</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : R.Sokei</br>
		/// <br>Date       : 2005.07.10</br>
		/// </remarks>
		public static int GetLastDate(int year, int month)
		{
			return DateTime.DaysInMonth(year, month);
		}

		/// <summary>
		/// 月内日数を取得する(末日取得)
		/// </summary>
		/// <param name="inLongDate">YYYYMMDD形式(8桁)の日付</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : R.Sokei</br>
		/// <br>Date       : 2005.07.10</br>
		/// </remarks>
		public static int GetLastDate(int inLongDate)
		{
			DateTime dt = LongDateToDateTime(inLongDate);
			return DateTime.DaysInMonth(dt.Year, dt.Month);
		}


		///// <summary>
		///// 月内日数を取得する(末日取得)
		///// </summary>
		///// <param name="inLongdateFormat">inLongDateのフォーマット形式を指定します</param>
		///// <param name="inLongDate">数値形式の日付</param>
		///// <remarks>
		///// <br>Note       : </br>
		///// <br>Programmer : R.Sokei</br>
		///// <br>Date       : 2005.07.10</br>
		///// <br>例)</br>
		///// <br>inLongDateがYYYYMMDD形式の場合、inLongdateFormatは TDateTimeFormat.df4Y2M2D を指定する</br>
		///// <br>inLongDateがYYYYMM形式の場合、inLongdateFormatは TDateTimeFormat.df4Y2M を指定する</br>
		///// </remarks>
		//		public static int GetLastDate(TDateTimeFormat inLongdateFormat, int inLongDate)
		//		{
		//			TDateTimeFormat.df4Y2M
		//			DateTime dt = LongDateToDateTime( ,inLongDate);
		//			return DateTime.DaysInMonth(dt.Year , dt.Month);
		//		}


		// 指定日付の曜日を取得する

		// 年数の加算
		// 年数の減算
		// 月数の加算
		// 月数の減算
		// 日数の加算
		// 日数の減算

		// 閏年判定

		// 指定時刻を『AM/PM HH:MM:SS』に編集する
		// 指定時刻を『AM/PM HH:MM』に編集する
		// 指定時刻を『AM/PM HH』に編集する

		/// <summary>
		///
		/// </summary>
		/// <param name="dateFormat"></param>
		/// <param name="inDateTime"></param>
		/// <returns></returns>
		public static string[] DateTimeToStringArray(string dateFormat, DateTime inDateTime)
		{
			string[] strTmp = new string[4];
			StringBuilder rDate1 = new StringBuilder();
			StringBuilder rDate2 = new StringBuilder();
			StringBuilder rDate3 = new StringBuilder();
			StringBuilder rDate4 = new StringBuilder();

			string rGengo = ""; int rYear = 0; int rMonth = 0; int rDay = 0;

			SplitDate("GGYYMMDD", inDateTime, ref rGengo, ref rYear, ref rMonth, ref rDay);

			if (dateFormat.Equals("YYYYMM"))
			{
				//case "GGyymmdd":
				rDate1.Append(rGengo);
				rDate1.Append(rYear.ToString().PadLeft(2));
				rDate1.Append("年");
				rDate1.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate1.Append("月");
				//case "ggyy/mm/dd":
				rDate2.Append(GetRyakGou(rGengo));
				rDate2.Append(rYear.ToString().PadLeft(2));
				rDate2.Append("/");
				rDate2.Append(inDateTime.Month.ToString().PadLeft(2));
				//case "YYYYmmdd":
				rDate3.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate3.Append("年");
				rDate3.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate3.Append("月");
				//case "YYYY/mm/dd":
				rDate4.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate4.Append("/");
				rDate4.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate4.Append("/");
			}
			else
			{
				//case "GGyymmdd":
				rDate1.Append(rGengo);
				rDate1.Append(rYear.ToString().PadLeft(2));
				rDate1.Append("年");
				rDate1.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate1.Append("月");
				rDate1.Append(inDateTime.Day.ToString().PadLeft(2));
				rDate1.Append("日");
				//case "ggyy/mm/dd":
				rDate2.Append(GetRyakGou(rGengo));
				rDate2.Append(rYear.ToString().PadLeft(2));
				rDate2.Append("/");
				rDate2.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate2.Append("/");
				rDate2.Append(inDateTime.Day.ToString().PadLeft(2));
				//case "YYYYmmdd":
				rDate3.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate3.Append("年");
				rDate3.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate3.Append("月");
				rDate3.Append(inDateTime.Day.ToString().PadLeft(2));
				rDate3.Append("日");
				//case "YYYY/mm/dd":
				rDate4.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate4.Append("/");
				rDate4.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate4.Append("/");
				rDate4.Append(inDateTime.Day.ToString().PadLeft(2));
				rDate4.Append("/");
			}

			strTmp.SetValue(rDate1.ToString(), 0);
			strTmp.SetValue(rDate2.ToString(), 1);
			strTmp.SetValue(rDate3.ToString(), 2);
			strTmp.SetValue(rDate4.ToString(), 3);

			return strTmp;
		}

		private static string LongDateToBaseString(string longDateFormat, int inLongDate)
		{
			return inLongDate.ToString().PadLeft(longDateFormat.Length, '0');
		}

		/// <summary>
		///  LongDate形式の日付を指定されたフォーマット 形式の文字列に変換します
		/// </summary>
		/// <param name="longDateFormat">変換対象日付のフォーマット形式(LongDate形式 YYYYMMDD or YYYYMM)</param>
		/// <param name="dateFormat">変換する日付フォーマット形式(YYYYMMDD, YYYYMM・・・)</param>
		/// <param name="inLongDate">変換対象日付(LongDate形式)</param>
		/// <param name="longDateEditor">LongDate形式日付の編集方法(TLongDateEditor.ZeroSuppress は、longDateFormatが"YYYYMMDD","YYYYMM"時のみ有効)</param>
		/// <returns>日付変換結果(string)</returns>
		/// <remarks>
		/// <list type="bullet">
		///	<item>フォーマット形式(dateFormat) : 出力結果(例)</item>
		///	<item>YYYYMMDD   : 2004年01月01日</item>
		///	<item>YYYYmmdd   : 2004年 1月 1日</item>
		///	<item>YYYYMM     : 2004年01月</item>
		///	<item>YYYYmm     : 2004年 1月</item>
		///	<item>GGYYMMDD   : 平成16年01月01日</item>
		///	<item>GGyymmdd   : 平成 5年 1月 1日</item>
		///	<item>GGYYMM     : 平成16年01月</item>
		///	<item>GGyymm     : 平成 5年 1月</item>
		///	<item>ggYYMM     : H16年01月</item>
		///	<item>ggyymm     : H 5年 1月</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : 平成16年</item>
		///	<item>ggYY       : H16年</item>
		///	<item>GGyy       : 平成 5年</item>
		///	<item>ggyy       : H 5年</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : 平成</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// この定義が間違っています。 本来 GGYY/MM では以下の exGGYY/MM と同等の結果を返さなければ
		///	いけませんが、既にこの定義を使用している処理があるのでこのままにしておきます。</item>
		///	<item>				exGGYY/MM  : 上記 GGYY/MM の代わりに使用してください。 元号 + 年 + / +月  例) 平成18/08</item>
		/// </list>
		/// <br>Note　　　　　　 :   LongDate形式の日付を指定されたフォーマット 形式の文字列に変換します</br>
		/// <br>                     文字列左側は必要に応じてゼロ埋めされます</br>
		/// <br>                     longDateFormatがYYYYMMDD形式の場合に、日付が00だと、全て空白で戻ります</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		public static string LongDateToString(string longDateFormat, string dateFormat, int inLongDate, TLongDateEditor longDateEditor)
		{
			if (inLongDate.Equals(0))
			{
				return "";
			}
			else
			{
				//-- 2009.05.29 Add Start by T.Sugawa ------------------------------------------------//
				if (longDateFormat == "YYYYMM")
				{
					int year = inLongDate / 100;
					int month = inLongDate % 100;

					switch (year)
					{
						case 1989:		//@ 昭和64年 → 平成1年対応
							// 月が 1月 → 1989/1/8(平成)に置き換え and "YYYYMMDD"に変更
							if (month == 1)
							{
								inLongDate = inLongDate * 100 + 8;
								longDateFormat = "YYYYMMDD";
							}
							break;
						default:
							break;
					}
				}
				//-- 2009.05.29 Add End by T.Sugawa --------------------------------------------------//

				// ゼロサプレスする必要がある場合
				if (longDateEditor == TLongDateEditor.ZeroSuppress)
				{
					// 2006.11.08現在、
					// YYYYMMDD形式で入力日付が無い場合(例: 20061100 等)、変換される文字列は空文字列になります
					// この場合に、TLongDateEditor.ZeroSuppress を有効にしたい場合は、以下の処理または
					// ChangeDateFormatZeroSuppress の処理に修正が必要になります

					// dateFormat --> ゼロサプレスする場合はゼロに該当する記述も削除する 例) 日付が20060800で入力されている場合 "YYYYMMDD" ----> "YYYYMM"
					//string chgFormat = ChangeDateFormatZeroSuppress(longDateFormat, ref inLongDate, dateFormat);			// 2009.05.29 Chg T.Sugawa
					string chgFormat = ChangeDateFormatZeroSuppress(ref longDateFormat, ref inLongDate, dateFormat);

					// LongDate --> DateTime変換
					DateTime dt = LongDateToDateTime(longDateFormat, inLongDate);

					// DateTime変換 --> String変換
					return DateTimeToString(chgFormat, dt);
				}
				// ゼロサプレスする必要が無い場合はそのまま変換処理を実行する
				else
				{
					// LongDate --> DateTime変換
					DateTime dt = LongDateToDateTime(longDateFormat, inLongDate);

					// DateTime変換 --> String変換
					return DateTimeToString(dateFormat, dt);
				}
			}
		}

		/// <summary>
		/// 編集文字列変更処理(ゼロサプレス)
		/// </summary>
		/// <param name="inLongDataFormat">数値形式の入力日付のフォーマット(YYYYMMDD or YYYYMM)</param>
		/// <param name="inLongDate">数値形式の入力日付</param>
		/// <param name="orgDateFormat">変換する日付フォーマット</param>
		/// <returns></returns>
		//private static string ChangeDateFormatZeroSuppress(string inLongDataFormat, ref int inLongDate, string orgDateFormat)		// 2009.05.29 Chg T.Sugawa
		private static string ChangeDateFormatZeroSuppress(ref string inLongDataFormat, ref int inLongDate, string orgDateFormat)
		{
			string inLDateStr = inLongDataFormat;
			string retDateFormat = orgDateFormat;
			if (inLDateStr == "")
			{
				inLDateStr = "YYYYMMDD";
			}

			if (inLDateStr == "YYYYMMDD")
			{
				int day = inLongDate % 100;
				if (day.Equals(0))
				{
					// 日付が無い場合 ".dd", "/dd", "dd" を削除する
					retDateFormat = retDateFormat.Replace(".dd", "");
					retDateFormat = retDateFormat.Replace("/dd", "");
					retDateFormat = retDateFormat.Replace(".DD", "");
					retDateFormat = retDateFormat.Replace("/DD", "");
					retDateFormat = retDateFormat.Replace("dd", "");
					retDateFormat = retDateFormat.Replace("DD", "");

					// YYYYMMDD形式でゼロサプレスを有効にしたい場合は、以下の処理のコメントを外して有効なコードにします

					// inLongDate  = inLongDate + 8; // 昭和64年 ----> 平成元年の処理

					// ↑上記処理を有効にすることで、LongDateToDateTime内で日付が初期値に変換されるのを防ぐことができます
				}
			}
			else if (inLDateStr == "YYYYMM")
			{
				int month = inLongDate % 100;
				if (month.Equals(0))
				{
					// 月が無い場合 日付と"mm"を削除する
					retDateFormat = retDateFormat.Replace(".dd", "");
					retDateFormat = retDateFormat.Replace("/dd", "");
					retDateFormat = retDateFormat.Replace(".DD", "");
					retDateFormat = retDateFormat.Replace("/DD", "");
					retDateFormat = retDateFormat.Replace("dd", "");
					retDateFormat = retDateFormat.Replace("DD", "");

					retDateFormat = retDateFormat.Replace("mm", "");
					retDateFormat = retDateFormat.Replace("MM", "");

                    int year = inLongDate / 100;

                    // 元号開始年の場合は、その年の一番後の元号の月とする
                    // ※元号情報リストは新しい元号から順番に入っている
                    ArrayList eraInfoList = GetEraInfoList();
                    bool isEraStartYear = false;
                    foreach (EraInfo info in eraInfoList)
                    {
                        if (info.StartDate.Year < year)
                        {
                            // 開始日の年より後の場合は、以後の元号を見る必要がないためループを抜ける
                            break;
                        }
                        if (year == info.StartDate.Year)
                        {
                            if (info.StartDate.Day == 1 || info.StartDate.Month == 12)
                            {
                                // 1日に元号が始まる、もしくは、12月に元号が始まる場合は、その月として扱う
                                inLongDate = inLongDate + info.StartDate.Month;
                            }
                            else
                            {
                                // それ以外は、元号開始月の翌月として扱う
                                inLongDate = inLongDate + info.StartDate.Month + 1;
                            }
                            isEraStartYear = true;
                            break;
                        }
                    }

                    // 元号開始月でない場合は、1月として扱う
                    if (!isEraStartYear)
                    {
                        inLongDate = inLongDate + 1;
                    }
				}
			}

			return retDateFormat;
		}

		/// **********************************************************************
		/// Module name      : LongDateToString
		/// <summary>
		///                    LongDate形式の日付を指定されたフォーマット 形式の文字列に変換します
		/// </summary>
		/// <param name="longDateFormat">
		///                    変換対象日付のフォーマット形式(LongDate形式 YYYYMMDD or YYYYMM)
		/// </param>
		/// <param name="dateFormat">
		///                    日付フォーマット形式(YYYYMMDD, YYYYMM・・・)
		/// </param>
		/// <param name="inLongDate">
		///                    変換対象日付(LongDate形式)
		/// </param>
		/// <returns>
		///                    日付変換結果(string)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <list type="bullet">
		///	<item>フォーマット形式(dateFormat) : 出力結果(例)</item>
		///	<item>YYYYMMDD   : 2004年01月01日</item>
		///	<item>YYYYmmdd   : 2004年 1月 1日</item>
		///	<item>YYYYMM     : 2004年01月</item>
		///	<item>YYYYmm     : 2004年 1月</item>
		///	<item>GGYYMMDD   : 平成16年01月01日</item>
		///	<item>GGyymmdd   : 平成 5年 1月 1日</item>
		///	<item>GGYYMM     : 平成16年01月</item>
		///	<item>GGyymm     : 平成 5年 1月</item>
		///	<item>ggYYMM     : H16年01月</item>
		///	<item>ggyymm     : H 5年 1月</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : 平成16年</item>
		///	<item>ggYY       : H16年</item>
		///	<item>GGyy       : 平成 5年</item>
		///	<item>ggyy       : H 5年</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : 平成</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// この定義が間違っています。 本来 GGYY/MM では以下の exGGYY/MM と同等の結果を返さなければ
		///	いけませんが、既にこの定義を使用している処理があるのでこのままにしておきます。</item>
		///	<item>				exGGYY/MM  : 上記 GGYY/MM の代わりに使用してください。 元号 + 年 + / +月  例) 平成18/08</item>
		/// </list>
		/// <br>Note　　　　　　 :   LongDate形式の日付を指定されたフォーマット 形式の文字列に変換します</br>
		/// <br>                     文字列左側は必要に応じてゼロ埋めされます</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static string LongDateToString(string longDateFormat, string dateFormat, int inLongDate)
		{
			return LongDateToString(longDateFormat, dateFormat, inLongDate, TLongDateEditor.Non);
		}

		/// **********************************************************************
		/// Module name      : LongDateToString
		/// <summary>
		///                    LongDate形式の日付を指定されたフォーマット 形式の文字列に変換します
		/// </summary>
		/// <param name="dateFormat">
		///                    日付フォーマット形式
		/// </param>
		/// <param name="inLongDate">
		///                    変換対象日付(LongDate形式)
		/// </param>
		/// <returns>
		///                    日付変換結果(string)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   LongDate形式の日付をYYYYMMDDの文字列に変換します</br>
		/// <br>                     文字列左側は必要に応じてゼロ埋めされます</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static string LongDateToString(string dateFormat, int inLongDate)
		{
			if (inLongDate.Equals(0))
			{
				return "";
			}
			else
			{
				// LongDate --> DateTime変換
				DateTime dt = LongDateToDateTime("YYYYMMDD", inLongDate);

				// DateTime変換 --> String変換
				return DateTimeToString(dateFormat, dt);
			}
		}

		/// **********************************************************************
		/// Module name      : GetRyakGou
		/// <summary>
		///                    指定された元号の略号を取得する
		///                    指定された元号が存在しない場合は、最新の元号の略称を返却する
		/// </summary>
		/// <param name="inGengou">
		///                    元号
		/// </param>
		/// <returns>
		///                    略号
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   指定された元号の略号を取得する</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static string GetRyakGou(string inGengou)
		{

            ArrayList eraInfoList = GetEraInfoList();

			string rRyakugo = ((EraInfo)eraInfoList[0]).EraUpperInitial;    
            foreach (EraInfo info in eraInfoList)
            {
                if (inGengou.Trim() == info.EraName)
                {
                    rRyakugo = info.EraUpperInitial;
                    break;
                }
            }

			return rRyakugo;
		}

		/// **********************************************************************
		/// Module name      : GetDayOfWeek
		/// <summary>
		///                    曜日を取得する
		///
		/// </summary>
		/// <param name="inDateTime">
		///                    対象日付
		/// </param>
		/// <returns>
		///                    曜日
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   曜日を取得する</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static string GetDayOfWeek(DateTime inDateTime)
		{
			return GetDayOfWeek("DDDSYS", inDateTime);
		}

		/// **********************************************************************
		/// Module name      : GetDayOfWeek
		/// <summary>
		///                    曜日を取得する
		///
		/// </summary>
		/// <param name="dateFormat">
		///                    曜日フォーマット形式
		/// </param>
		/// <param name="inDateTime">
		///                    対象日付
		/// </param>
		/// <returns>
		///                    曜日
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　　　　 :   曜日を取得する    </br>
		/// <br>Programer        :   R.Sokei           </br>
		/// <br>Date             :   2004.12.06        </br>
		/// <br>Update Note      :                     </br>
		/// </remarks>
		/// **********************************************************************
		public static string GetDayOfWeek(string dateFormat, DateTime inDateTime)
		{
			string[] lWeeks = { "日", "月", "火", "水", "木", "金", "土" };
			string lWeekChar = "曜日";
			string strWeek;

			switch (dateFormat.Trim())
			{
				case "DDDSYS":
					{
						strWeek = lWeeks[(int)inDateTime.DayOfWeek] + lWeekChar;
						break;
					}
				case "DDDCC":
					{
						strWeek = lWeeks[(int)inDateTime.DayOfWeek] + lWeekChar;
						break;
					}
				case "DDDENG":
					{
						strWeek = inDateTime.DayOfWeek.ToString();
						break;
					}
				case "DDD":
					{
						strWeek = lWeeks[(int)inDateTime.DayOfWeek].ToString();
						break;
					}
				default:
					{   // デフォルトは、現在の元号(略号)を返す
						strWeek = lWeeks[(int)inDateTime.DayOfWeek] + lWeekChar;
						break;
					}
			}

			return strWeek;
		}

		// 日付有効性チェック
		/// <summary>
		/// 日付の有効性チェック処理
		/// </summary>
		/// <param name="dateFormat">入力日付文字列の日付形式</param>
		/// <param name="inDateTime">チェック対象日付(DateTime)</param>
		/// <returns>日付有効性: true:有効, false:無効(不正な日付)</returns>
		/// <remarks>
		/// <br>Note       : 指定された日付文字列のの有効性チェックします</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(TDateTimeFormat dateFormat, DateTime inDateTime)
		{
			bool isAvailable = true;

			try
			{
				string datestr = inDateTime.Year.ToString() + "/" + inDateTime.Month.ToString() + "/" + inDateTime.Day.ToString();
				DateTime dateTime = DateTime.Parse(datestr);

				if (dateFormat >= TDateTimeFormat.dfG2Y2M2D)
				{
                    // 元号ありの場合は、明治元年（1868年）より前の場合は無効と判断
                    if (inDateTime.Year < 1868)
                    {
                        return false;
                    }
				}

				switch (dateFormat)
				{

					// "YYYYMMDD"の形式(例: 20050301)
					case TDateTimeFormat.df4Y2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}

							break;
						}

					// "YYMMDD"の形式(例: 050301)
					case TDateTimeFormat.df2Y2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// (和暦)GGYYMMDDの形式(例: 170301)
					case TDateTimeFormat.dfG2Y2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// YYYY年MM月の形式
					case TDateTimeFormat.df4Y2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// YY年MM月の形式
					case TDateTimeFormat.df2Y2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// 元号YY年MM月の形式
					case TDateTimeFormat.dfG2Y2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// MM月DD日の形式
					case TDateTimeFormat.df2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// YYYY年の形式
					case TDateTimeFormat.df4Y:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// MM月の形式
					case TDateTimeFormat.df2Y:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// 元号YY年の形式
					case TDateTimeFormat.dfG2Y:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// MM月の形式
					case TDateTimeFormat.df2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// DD日の形式
					case TDateTimeFormat.df2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}
					default:
						{
							// デフォルトは、現在の元号(略号)を返す
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}
				}

				return isAvailable;
			}
			catch (ArgumentNullException)
			{
				// 指定された値がNULLの場合
				isAvailable = false;
				return isAvailable;
			}
			catch (FormatException)
			{
				// 指定書式通りに変換できない場合の例外
				isAvailable = false;
				return isAvailable;
			}
		}

		/// <summary>
		/// 日付の有効性チェック処理
		/// </summary>
		/// <param name="dateFormat">入力日付文字列の日付形式</param>
		/// <param name="inDateTimeString">チェック対象日付文字列</param>
		/// <returns>日付有効性: true:有効, false:無効(不正な日付)</returns>
		/// <remarks>
		/// <br>Note       : 指定された日付文字列のの有効性チェックします</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(TDateTimeFormat dateFormat, string inDateTimeString)
		{
			bool isAvailable = true;

			try
			{
				DateTime dateTime;
				System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
				System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
				culture.DateTimeFormat.Calendar = calendar;
				string datestr = inDateTimeString;

				switch (dateFormat)
				{
					// "YYYYMMDD"の形式(例: 20050301)
					case TDateTimeFormat.df4Y2M2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// "YYMMDD"の形式(例: 050301)
					case TDateTimeFormat.df2Y2M2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// (和暦)GGYYMMDDの形式(例: 170301)
					case TDateTimeFormat.dfG2Y2M2D:
						{
                            // 取得した元号・和暦の年は使用しておらず、例外が発生するか否かにしか使用していないため、新元号の仮対応では特に何もしない。
							dateTime = DateTimeParseExact(datestr, "ggyy/M/d");

							if (dateFormat >= TDateTimeFormat.dfG2Y2M2D)
							{
                                // 元号ありの場合は、明治元年（1868年）より前の場合は無効と判断
                                if (dateTime.Year < 1868)
                                {
                                    return false;
                                }
							}
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// YYYY年MM月の形式
					case TDateTimeFormat.df4Y2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// YY年MM月の形式
					case TDateTimeFormat.df2Y2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// 元号YY年MM月の形式
					case TDateTimeFormat.dfG2Y2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// MM月DD日の形式
					case TDateTimeFormat.df2M2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// YYYY年の形式
					case TDateTimeFormat.df4Y:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// MM月の形式
					case TDateTimeFormat.df2Y:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// 元号YY年の形式
					case TDateTimeFormat.dfG2Y:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// MM月の形式
					case TDateTimeFormat.df2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// DD日の形式
					case TDateTimeFormat.df2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					default:
						{
							// デフォルトは、現在の元号(略号)を返す
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}
				}

				return isAvailable;
			}
			catch (ArgumentNullException)
			{
				// 指定された値がNULLの場合
				isAvailable = false;
				return isAvailable;
			}
			catch (FormatException)
			{
				// 指定書式通りに変換できない場合の例外
				isAvailable = false;
				return isAvailable;
			}
		}

		// 日付有効性チェック
		/// <summary>
		/// 日付の有効性チェック処理
		/// </summary>
		/// <param name="inDateTime">チェック対象日付(DateTime)</param>
		/// <returns>日付有効性: true:有効, false:無効(不正な日付)</returns>
		/// <remarks>
		/// <br>Note       : 指定された日付文字列のの有効性チェックします</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(DateTime inDateTime)
		{
			bool isAvailable = true;

			if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Day <= 1))
			{
				isAvailable = false;
			}

			return isAvailable;
		}

		/// <summary>
		/// 日付の有効性チェック処理
		/// </summary>
		/// <param name="inDateTime">チェック対象日付(DateTime)</param>
		/// <param name="mode">0:MinValue(0001/01/01)を不正な無効な日付と判定する, 1:0:MinValue(0001/01/01)を有効な日付と判定する</param>
		/// <returns>日付有効性: true:有効, false:無効(不正な日付)</returns>
		/// <remarks>
		/// <br>Note       : 指定された日付文字列のの有効性チェックします</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(DateTime inDateTime, int mode)
		{
			bool isAvailable = true;

			if (mode.Equals(0))
			{
				if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Day <= 1))
				{
					isAvailable = false;
				}
			}
			else
			{
				if ((inDateTime.Year < 1) && (inDateTime.Month < 1) && (inDateTime.Day < 1))
				{
					isAvailable = false;
				}
			}

			return isAvailable;
		}

		/// <summary>
		/// 元号リスト取得
		/// </summary>
		/// <param name="rGList">元号リスト(取得用)</param>
		/// <returns>処理ステータス 0:成功</returns>
		/// <remarks>
		/// <br>Note       : 元号リストを取得します</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static int GetGengouList(out ArrayList rGList)
		{

            rGList = GetEraNameList();

			return 0;
		}

        /// <summary>
        /// 元号リスト取得（特定の元号以降を取得）
        /// </summary>
        /// <param name="rGList">元号リスト(取得要)</param>
        /// <param name="mode">取得する元号のモード</param>
        /// <returns>処理ステータス 0:成功</returns>
        /// <remarks>
        /// <br>Note       : 元号リストを取得します</br>
        /// <br>             基本的に今後は取得した元号リストから不要な元号を削除する処理を各プログラム内で行わず、本メソッドを使用してください。</br>
        /// <br>Programmer : 31983 S.Tomohiro</br>
        /// <br>Date       : 2018.12.11</br>
        /// </remarks>
        public static int GetGengouList(out ArrayList rGList, TDateTimeGengouMode mode)
        {
            // 最新元号からいくつの元号を取得するかを判断する。
            rGList = new ArrayList();
            ArrayList eraNameList = GetEraNameList();
            int getEraCount = eraNameList.Count - (int)mode + 1;

            // 取得数分、返却用Listに移し替え
            foreach (string eraName in eraNameList)
            {
                if (getEraCount <= 0)
                {
                    break;
                }

                rGList.Add(eraName);
                getEraCount--;
            }

            return 0;
        }

		/// <summary>
		/// 和暦文字列-->LongDate(YYYYMMDD)変換
        /// 変換に失敗した際は、西暦1年1月1日を返却します。
        /// ※本メソッドでは、原則として元号＋年月日の文字列を対象とします。
        /// 　また、年月日の区切り文字は、"/" "-" "."の3種類を許容します。
        /// 　元号については、漢字2文字・漢字先頭1文字・略号半角大文字・略号半角小文字を許容します。
        /// 　それ以外の形式の値が来た場合も、.NET Frameworkの動作に従って変換を試みますが、
        /// 　動作する端末の状態によっては、新元号への対応ができない場合があります。
        /// 　時分秒が付与された文字列についても、.NET Frameworkの動作に従って変換を試みます。
		/// </summary>
		/// <param name="japaneseDate">和暦文字列(例 "平成17年8月1日")</param>
		/// <returns>変換日付(YYYYMMDD)</returns>
		/// <remarks>
		/// <br>Note       : 和暦文字列をLongDate型(YYYYMMDD)の日付に変換します</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		public static int JapaneseDateStringToLongDate(string japaneseDate)
		{
            // DateTimeに変換したものをLongDateに変換して返却
			return DateTimeToLongDate(JapaneseDateStringToDateTime(japaneseDate));
        }

        /// <summary>
        /// 和暦文字列-->DateTime変換
        /// 変換に失敗した際は、西暦1年1月1日を返却します。
        /// ※本メソッドでは、原則として元号＋年月日の文字列を対象とします。
        /// 　また、年月日の区切り文字は、"/" "-" "."の3種類を許容します。
        /// 　元号については、漢字2文字・漢字先頭1文字・略号半角大文字・略号半角小文字を許容します。
        /// 　それ以外の形式の値が来た場合も、.NET Frameworkの動作に従って変換を試みますが、
        /// 　動作する端末の状態によっては、新元号への対応ができない場合があります。
        /// 　時分秒が付与された文字列についても、.NET Frameworkの動作に従って変換を試みます。
        /// ※本メソッドは、元々存在したJapaneseDateStringToLongDateメソッドをもとにしています
        /// </summary>
        /// <param name="japaneseDate">和暦文字列(例 "平成17年8月1日")</param>
        /// <returns>変換日付(DateTime型)</returns>
        /// <remarks>
        /// <br>Note       : 和暦文字列をDateTime型に変換します</br>
        /// <br>Programmer : 31983 S.Tomohiro</br>
        /// <br>Date       : 2019.02.14</br>
        /// </remarks>
        public static DateTime JapaneseDateStringToDateTime(string japaneseDate)
        {
            DateTime retDateTime = new DateTime(1, 1, 1);
            bool canConvert = false;

            try
            {
                string tmpDate = japaneseDate.Trim();

                // 区切り文字の"年"・"月"・"."・"-"を"/"に変換（すべての区切り文字を"/"にする）
                tmpDate = japaneseDate.Replace("年", "/");
                tmpDate = tmpDate.Replace("月", "/");
                tmpDate = tmpDate.Replace(".", "/");
                tmpDate = tmpDate.Replace("-", "/");

                // "日"を削除する
                tmpDate = tmpDate.Replace("日", string.Empty);

                // "/"で終わっている場合は、最後の"/"を削除（年や月のみの指定の場合向け）
                if (tmpDate.EndsWith("/"))
                {
                    tmpDate = tmpDate.Substring(0, tmpDate.Length - 1);
                }

                // "/"で文字列を分割
                string[] splitStr = tmpDate.Split(new char[] { '/' });

                string year = string.Empty;
                string month = string.Empty;
                string day = string.Empty;

                // 1つだけの場合は年だけが指定されていると判断して、月・日を1月1日として処理
                if (splitStr.Length == 1)
                {
                    year = GetYearFromJapaneseYear(splitStr[0].Trim()).ToString();
                    month = "1";
                    day = "1";

                    canConvert = true;
                }
                // 2つある場合は年月が指定されていると判断して、日を1日として処理
                else if (splitStr.Length == 2)
                {
                    year = GetYearFromJapaneseYear(splitStr[0].Trim()).ToString();
                    month = splitStr[1].Trim();
                    day = "1";

                    canConvert = true;
                }
                // 3つある場合は年月日が指定されていると判断して処理
                else if (splitStr.Length == 3)
                {
                    year = GetYearFromJapaneseYear(splitStr[0].Trim()).ToString();
                    month = splitStr[1].Trim();
                    day = splitStr[2].Trim();

                    canConvert = true;
                }
                // 上記以外のパターンについては、既存ロジックで処理を実行（canConvertはfalseなので、ここでは特に何もしない）

                if (canConvert)
                {
                    retDateTime = DateTime.Parse(year + "/" + month + "/" + day);
                }
            }
            catch (Exception)
            {
                // 何かしらの例外をcatchした場合は、既存のロジックで処理を実行
                canConvert = false;
            }
            finally
            {
                if (!canConvert)
                {
                    // 変換できなかった場合は既存のJapaneseDateStringToLongDate処理を実行
                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);

                    try
                    {
                        retDateTime = System.DateTime.Parse(
                            japaneseDate,
                            format,
                            System.Globalization.DateTimeStyles.None);
                    }
                    catch (ArgumentNullException)
                    {
                        retDateTime = new DateTime(1, 1, 1);
                    }
                    catch (FormatException)
                    {
                        retDateTime = new DateTime(1, 1, 1);
                    }
                }
            }

            // DateTime型-->LongDate型
            return retDateTime;
        }

        /// <summary>
        /// 日付部品（TDateEdit・TDateEdit2・BDateEdit）の日付フォーマット取得処理。
        /// 指定したフォーム名とコンポーネントに設定された名前から、日付フォーマットを取得する。
        /// XMLに設定がない場合は、string.Emptyを返却する。
        /// ※TDateEdit・TDateEdit2・BDateEdit以外からの呼び出しは想定していませんので、
        /// 　通常のPGからの利用は行わないでください。
        /// </summary>
        /// <param name="formName">フォーム名。原則、Broadleaf.Windows.Forms名前空間のものを指定する。</param>
        /// <param name="componentName">コンポーネントに設定された名前（Nameプロパティの値）</param>
        /// <returns>XMLに設定されている日付フォーマット。設定がない場合はstring.Empty。</returns>
        public static string GetDateFormat(string formName, string componentName)
        {
            if (_formDateTimeFormat == null)
            {
                ReadDateFormatInfoXml();
            }

            Dictionary<string, string> dateTimeFormat;
            if (_formDateTimeFormat.TryGetValue(formName, out dateTimeFormat))
            {
                string format;
                if (dateTimeFormat.TryGetValue(componentName, out format))
                {
                    return format;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 指定した元号の基準年（足すと西暦になる年。各元号の0年に相当）取得処理。
        /// 元号情報に存在しない元号を指定された場合は0を返却します。
        /// </summary>
        /// <param name="eraName">元号名</param>
        /// <returns>基準年</returns>
        public static int GetBaseYear(string eraName)
        {
            int baseYear = 0;
            ArrayList eraInfoList = GetEraInfoList();

            foreach (EraInfo info in eraInfoList)
            {
                if (info.EraName == eraName)
                {
                    baseYear = info.BaseYear;
                    break;
                }
            }

            return baseYear;
        }

        #region private methods
        /// <summary>
        /// 元号情報リストの取得。
        /// 元号情報が読み込まれていない場合はXMLを読み込んで返却、読み込み済みの場合は読み込み済みデータを返却する。
        /// </summary>
        /// <returns>元号情報リスト</returns>
        private static ArrayList GetEraInfoList()
        {
            // 元号情報が読み込まれていない場合は、読み込みを行う。
            if (_eraInfoList.Count == 0)
            {
                ReadEraInfoXml();
            }

            return _eraInfoList;
        }

        /// <summary>
        /// 元号名リストの取得。
        /// 元号情報が読み込まれていない場合はXMLを読み込んで返却、読み込み済みの場合は読み込み済みデータを返却する。
        /// </summary>
        /// <returns>元号情報リスト</returns>
        private static ArrayList GetEraNameList()
        {
            // 元号情報が読み込まれていない場合は、読み込みを行う。
            if (_eraNameList.Count == 0)
            {
                ReadEraInfoXml();
            }

            return (ArrayList)(_eraNameList.Clone());
        }

        /// <summary>
        /// 元号情報XMLの読み込み処理
        /// ※元号情報XMLが存在しない場合、ファイルの中身がない場合は、元号コンボボックスが空で表示されます。
        /// 　元号コンボボックスが空で表示されるような問い合わせを受けた際は、XMLの破損・紛失を疑ってください。
        /// ※呼び出し元で行っている0件チェックをすり抜けてしまう場合があることが確認されたため、
        /// 　同一元号情報が既に登録されている場合はその元号の追加をスキップするようにしています。
        /// </summary>
        private static void ReadEraInfoXml()
        {
            EraInfo[] eraInfoArray = null;
            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            string filePath = Path.Combine(Path.GetDirectoryName(assemblyPath), ERAINFO_XML_FILENAME);
            if (File.Exists(filePath))
            {
                // XMLから元号情報クラス配列にデシリアライズする
                eraInfoArray = (EraInfo[])XmlDeserialize(filePath, typeof(EraInfo[]));
                if (eraInfoArray != null)
                {
                    foreach (EraInfo info in eraInfoArray)
                    {
                        // 元号情報リストと同時に、元号名リストも作成しておく
                        // 終了日は23:59:59.9999999に設定する。
                        info.EndDate = info.EndDate.AddTicks(863999999999L);

                        // 非同期処理での重複追加を防ぐため、ここでもチェックをしてからListにAddする
                        if (!_eraNameList.Contains(info.EraName))
                        {
                            _eraNameList.Add(info.EraName);
                            _eraInfoList.Add(info);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 日付フォーマット情報XMLの読み込み処理
        /// 日付フォーマット情報は任意情報のため、ファイルがない場合や1件もデータがない場合でもエラーとしない。
        /// </summary>
        private static void ReadDateFormatInfoXml()
        {
            _formDateTimeFormat = new Dictionary<string, Dictionary<string, string>>();

            FormDateFormatInfo[] FormDateFormatInfoArray = null;
            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            string filePath = Path.Combine(Path.GetDirectoryName(assemblyPath), DATETIMEFORMATINFO_XML_FILENAME);
            if (File.Exists(filePath))
            {
                // XMLから日付フォーマット情報クラス配列にデシリアライズする
                FormDateFormatInfoArray = (FormDateFormatInfo[])XmlDeserialize(filePath, typeof(FormDateFormatInfo[]));
                if (FormDateFormatInfoArray != null)
                {
                    // 取得したデータをDictionary形式に変換
                    foreach (FormDateFormatInfo formInfo in FormDateFormatInfoArray)
                    {
                        Dictionary<string, string> dateFormatInfo;
                        bool containsKey = false;
                        if (_formDateTimeFormat.ContainsKey(formInfo.FormName))
                        {
                            dateFormatInfo = _formDateTimeFormat[formInfo.FormName];
                            containsKey = true;
                        }
                        else
                        {
                            dateFormatInfo = new Dictionary<string, string>();
                        }

                        foreach (DateFormatInfo formatInfo in formInfo.DateFormatInfoArray)
                        {
                            if (dateFormatInfo.ContainsKey(formatInfo.ComponentName))
                            {
                                continue;
                            }

                            dateFormatInfo.Add(formatInfo.ComponentName, formatInfo.DateFormat);
                        }

                        if (!containsKey)
                        {
                            _formDateTimeFormat.Add(formInfo.FormName, dateFormatInfo);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// XML物理ファイル デシリアライズ処理。
        /// ※通常のXmlByteSerializerがRead/Writeでファイルを開いてしまうため、
        /// 　ごくごく稀にファイルの排他エラーになる場合があります。
        /// 　そのため、本部品独自でReadモード（読み取り専用）でファイルを開き、
        /// 　排他制御を行わないようにしています。
        /// </summary>
        /// <param name="fileName">デシリアライズファイル名</param>
        /// <param name="type">デシリアライズオブジェクトタイプ</param>
        /// <returns>デシリアライズオブジェクト</returns>
        static private object XmlDeserialize(string fileName, Type type)
        {
            System.IO.FileStream fs = null;
            try
            {
                // XmlSerializerオブジェクトの作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
                // 読み取り専用でファイルを開く
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, FileAccess.Read);
                // XMLファイルから読み込み、逆シリアル化する
                object ret = (object)serializer.Deserialize(fs);
                return ret;
            }
            finally
            {
                // 閉じる
                if (fs != null) fs.Close();
            }
        }

        #endregion
    }
}
