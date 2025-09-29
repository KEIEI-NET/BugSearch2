//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 受信日付クラス
    /// </summary>
    public sealed class ReceivedDate
    {
        #region <生成された日時/>

        /// <summary>生成された日時</summary>
        private readonly DateTime _birthDay;
        /// <summary>
        /// 生成された日時を取得します。
        /// </summary>
        private DateTime BirthDay { get { return _birthDay; } }

        #endregion  // <生成された日時/>

        #region <受信日付のソース/>

        /// <summary>受信日付のソースフォーマット</summary>
        private const string SOURCE_FORMAT = "MMdd";

        /// <summary>受信日付のソース</summary>
        private readonly string _source;
        /// <summary>
        /// 受信日付のソースを取得します。
        /// </summary>
        /// <value>受信日付のソース</value>
        private string Source { get { return _source; } }

        #endregion  // <受信日付のソース/>

        #region <受信日付ソースの不正チェック/>

        /// <summary>不正な受信日付ソースであるフラグ</summary>
        private readonly bool _hasInvalidSource;
        /// <summary>
        /// 不正な受信日付ソースであるフラグを取得します。
        /// </summary>
        /// <value>
        /// <c>true</c> :不正な受信日付ソースである<br/>
        /// <c>false</c>:不正な受信日付ソースではない
        /// </value>
        private bool HasInvalidSource { get { return _hasInvalidSource; } }

        /// <summary>
        /// 不正な受信日付ソースであるか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :不正な受信日付ソースである<br/>
        /// <c>false</c>:不正な受信日付ソースではない
        /// </returns>
        private bool IsInvalidSource()
        {
            try
            {
                // 月の単純妥当性チェック
                _month = int.Parse(Source.Substring(0, 2)); // LITERAL:
                if (_month < 1 || _month > 12) return true;

                // 日の単純妥当性チェック
                _day = int.Parse(Source.Substring(2, 2));   // LITERAL:
                if (_day < 1 || _day > 31) return true;

                // 年の算出
                _year = BirthDay.Year;
                if (BirthDay.Month.Equals(12) && _month.Equals(1))
                {
                    // システム月が12月で仕入日付の受信月が1月の場合、システム年に+1
                    _year++;
                }
                else if (BirthDay.Month.Equals(1) && _month.Equals(12))
                {
                    // システム月が1月で仕入日付の受信月が12月の場合、システム年に-1
                    _year--;
                }

                // 閏年チェック
                StringBuilder strDate = new StringBuilder();
                strDate.Append(_year).Append("/").Append(_month).Append("/").Append(_day);

                DateTime date = DateTime.Parse(strDate.ToString());
                _date = date.ToString(DATE_FORMAT);

                return false;
            }
            catch (System.Exception)
            {
                return true;
            }
        }

        #endregion  //<受信日付ソースの不正チェック/>

        #region <年月日/>

        /// <summary>年</summary>
        private int _year;
        /// <summary>
        /// 年を取得します。
        /// </summary>
        /// <value>年</value>
        public int Year
        {
            get
            {
                if (HasInvalidSource)
                {
                    return BirthDay.Year;
                }
                else
                {
                    return _year;
                }
            }
        }

        /// <summary>月</summary>
        private int _month;
        /// <summary>
        /// 月を取得します。
        /// </summary>
        /// <value>月</value>
        public int Month
        {
            get
            {
                if (HasInvalidSource)
                {
                    return BirthDay.Month;
                }
                else
                {
                    return _month;
                }
            }
        }

        /// <summary>日</summary>
        private int _day;
        /// <summary>
        /// 日を取得します。
        /// </summary>
        /// <value>日</value>
        public int Day
        {
            get
            {
                if (HasInvalidSource)
                {
                    return BirthDay.Day;
                }
                else
                {
                    return _day;
                }
            }
        }

        /// <summary>日付フォーマット</summary>
        private const string DATE_FORMAT = "yyMMdd";

        /// <summary>日付</summary>
        private string _date;
        /// <summary>
        /// 日付を取得します。
        /// </summary>
        /// <value>日付</value>
        public string Date
        {
            get
            {
                if (HasInvalidSource)
                {
                    return BirthDay.ToString(DATE_FORMAT);
                }
                else
                {
                    return _date;
                }
            }
        }

        #endregion  // <年月日/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="source">受信日付のソース（MMdd形式）</param>
        public ReceivedDate(string source)
        {
            _birthDay   = DateTime.Now;
            _source     = source;
            _hasInvalidSource = IsInvalidSource();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// DateTime型に変換します。
        /// </summary>
        /// <returns><c>new DateTime(Year, Month, Day)</c></returns>
        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day);
        }

        #region <Override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return ToDateTime().ToString(DATE_FORMAT);
        }

        #endregion  // <Override/>
    }
}
