using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// Calendar_Controlクラス                                                      
    /// </summary>
    /// <remarks>
    /// Note       : UserControlの設定を行います。<br />       
    /// Programmer : NEPCO<br />                                   
    /// Date       : 2007.02.16<br />                                       
    /// <br />
    /// </remarks>
    public partial class Calendar_Control : UserControl
    {
        # region Constructor

        public Calendar_Control()
        {
            InitializeComponent();

            // アイコン画像の設定
            // 翌年ボタン
            this.NextYear_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEXT2];
            // 前年ボタン
            this.PreviousYear_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.BEFORE2];
        }

        # endregion

        # region private Members

        /// <summary>カレンダーコントロール</summary>                                   
        /// <remarks>１～１２月までのグリッドを配列化します。</remarks>　　　　　　　　　　　 
        internal Infragistics.Win.UltraWinGrid.UltraGrid[] _calendar_uGrid;

        /// <summary>年度</summary>     
        /// <remarks>yyyy</remarks>
        private int _year;

        /// <summary>適用区分</summary>                                   
        /// <remarks>０：休業日　１：祝祭日</remarks>　　　　　　　　　　　 
        private int _applyDateCd;

        /// <summary>休業日・祝祭日リスト</summary>                                   
        /// <remarks>適用年月日をkeyとして、適用区分を持ちます。</remarks>　　　　　　　　　　　 
        private SortedList<DateTime, int> _applyDateList;

        private Control _nextControl;

        # endregion

        # region Properties

        /// <summary>年度表示プロパティ</summary>                                   
        /// <value>表示する年度を設定します。</value>                                      
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        /// <summary>適用区分プロパティ</summary>                                   
        /// <value>休業日・祝祭日をします。</value>               
        /// <remarks>０：休業日　１：祝祭日</remarks>                       
        public int ApplyDateCd
        {
            get { return _applyDateCd; }
            set { _applyDateCd = value; }
        }

        /// <summary>休業日・祝祭日リストプロパティ</summary>                                   
        /// <value>適用年月日：yyyyMMDD</value>               
        /// <remarks>適用年月日をkeyとして、適用区分を持ちます。</remarks>                       
        public SortedList<DateTime, int> ApplyDateList
        {
            get { return _applyDateList; }
            set { _applyDateList = value; }
        }

        /// <summary>NEXTコントロールプロパティ</summary>                                   
        /// <remarks>下段のカレンダーコントロールの次に移動するコントロール</remarks>                       
        public Control NextControl
        {
            get { return _nextControl; }
            set { _nextControl = value; }
        }

        # endregion

        # region Public Methods

        /// <summary>
        /// カレンダーコントロール取得処理                                                     
        /// </summary>                         
        /// <remarks>
        /// Note       : カレンダーコントロールを取得します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.05.30<br />                                        
        /// </remarks>
        public Control GetCalendarControl(int month)
        {
            if (month <= 0 || 12 < month)
            {
                return (null);
            }
            return (this._calendar_uGrid[month - 1]);
        }

        # endregion Public Methods

        # region Private Methods

        /// <summary>
        /// カレンダー作成処理                                                         
        /// </summary>  
        /// <param name="year">年</param>
        /// <remarks>
        /// Note       : カレンダーを作成します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        public bool DispScrean(int year)
        {
            this._year = year;

            // 年見出し表示
            Year_uLabel.Text = _year.ToString() + "年";

            // データ追加用
            DataRow dataRow;

            for (int month = 1; month <= 12; month++)
            {
                // カラム作成
                DataTable dataTable = new DataTable("Calendar_tbl");
                dataTable.Columns.Add("Sunday", typeof(int));
                dataTable.Columns.Add("Monday", typeof(int));
                dataTable.Columns.Add("Tuesday", typeof(int));
                dataTable.Columns.Add("Wednesday", typeof(int));
                dataTable.Columns.Add("Thursday", typeof(int));
                dataTable.Columns.Add("Friday", typeof(int));
                dataTable.Columns.Add("Saturday", typeof(int));

                DateTime targetDate = new DateTime(_year, month, 1);
                int iDaysInMonth = DateTime.DaysInMonth(targetDate.Year, month);

                int day = 1;
                int dayOfWeek = (int)targetDate.DayOfWeek;

                // 対象月の日数分だけループ処理
                while (day <= iDaysInMonth)
                {
                    // 日付設定
                    dataRow = dataTable.NewRow();
                    while ((dayOfWeek < 7) && (day <= iDaysInMonth))
                    {
                        dataRow[dayOfWeek] = day;
                        dayOfWeek++;
                        day++;
                    }
                    // データ追加
                    dataTable.Rows.Add(dataRow);
                    dayOfWeek = 0;
                }
                this._calendar_uGrid[month - 1].DataSource = dataTable;
            }

            // カレンダースタイル設定処理
            DispScrean();

            // 設定済みデータ色表示処理
            SetHolidayColorAll();

            return (true);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.01.19</br>
        /// </remarks>
        public void ScreenClear()
        {
        }

        /// <summary>
        /// カレンダースタイル設定処理                                                         
        /// </summary>                           
        /// <remarks>
        /// Note       : カレンダースタイルを設定します。<br />                        
        /// Programmer : NEPCO<br />                                   
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected bool DispScrean()
        {
            for (int month = 1; month <= 12; month++)
            {
                // グリッドの背景色・枠スタイル指定
                this._calendar_uGrid[month - 1].DisplayLayout.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
                this._calendar_uGrid[month - 1].DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;

                // グリッド内を編集不可にする
                for (int i = 0; i < 7; i++)
                {
                    _calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[i].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

                this._calendar_uGrid[month - 1].UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

                // テキスト位置設定
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[0].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // 月見出しのスタイル指定
                this._calendar_uGrid[month - 1].Text = month + "月";
                this._calendar_uGrid[month - 1].DisplayLayout.CaptionAppearance.BackColor = Color.FromArgb(89, 135, 214);
                this._calendar_uGrid[month - 1].DisplayLayout.CaptionAppearance.ForeColor = Color.White;
                this._calendar_uGrid[month - 1].DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Default;
                this._calendar_uGrid[month - 1].DisplayLayout.CaptionAppearance.BorderColor = Color.Black;

                // ヘッダースタイルの指定
                this._calendar_uGrid[month - 1].DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.FromArgb(192, 225, 245);
                this._calendar_uGrid[month - 1].DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;

                // 曜日見出し作成
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[0].Header.Caption = "日";
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[1].Header.Caption = "月";
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[2].Header.Caption = "火";
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[3].Header.Caption = "水";
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[4].Header.Caption = "木";
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[5].Header.Caption = "金";
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[6].Header.Caption = "土";

                // 曜日見出し（土日）色表示
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[0].Header.Appearance.ForeColor = System.Drawing.Color.Red;
                this._calendar_uGrid[month - 1].DisplayLayout.Bands[0].Columns[6].Header.Appearance.ForeColor = System.Drawing.Color.Blue;

                // セルスタイルの指定
                this._calendar_uGrid[month - 1].DisplayLayout.Override.SelectedCellAppearance.ForeColor = System.Drawing.Color.Black;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                this._calendar_uGrid[month - 1].DisplayLayout.Override.ActiveCellAppearance.BackColor = Color.Empty;

                // 行スタイルの指定
                this._calendar_uGrid[month - 1].DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                // 列スタイルの指定
                this._calendar_uGrid[month - 1].DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
                this._calendar_uGrid[month - 1].DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            }

            // Columnの幅指定
            for (int gridIndex = 0; gridIndex < 12; gridIndex++)
            {
                this._calendar_uGrid[gridIndex].Size = new Size(175, 170);
                this._calendar_uGrid[gridIndex].Rows[0].Cells[0].Activate();

                for (int week = 0; week < 7; week++)
                {
                    this._calendar_uGrid[gridIndex].DisplayLayout.Bands[0].Columns[week].Width = 25;
                }
            }
            return (true);
        }

        /// <summary>
        /// 休業日・祝祭日設定処理                                                         
        /// </summary>
        /// <param name="targetDate">対象日</param>
        /// <remarks>
        /// Note       : 休業日・祝祭日の設定を行います。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected void SetHolidaySettingData(DateTime targetDate)
        {
            // _applyDateListに適用年月日があるかどうかチェック 
            if (_applyDateList.ContainsKey(targetDate))
            {
                // 適用区分も一緒かどうかチェック
                if (_applyDateList[targetDate] == this.ApplyDateCd)
                {
                    // 適用年月日・適用区分が一緒だったら_applyDateListから削除
                    _applyDateList.Remove(targetDate);
                }
                // 適用年月日が一緒だが、適用区分が違う場合 
                else
                {
                    // _applyDateListの適用区分を変更
                    _applyDateList[targetDate] = this.ApplyDateCd;
                }
            }
            // 適用年月日が違う場合    
            else
            {
                // _applyDateListに新しく追加
                _applyDateList.Add(targetDate, this.ApplyDateCd);
            }
        }

        /// <summary>
        /// 設定済みデータ色表示処理                                                         
        /// </summary>                           
        /// <remarks>
        /// Note       : 画面が変わった時に、設定済みデータをチェックし、色を表示します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected void SetHolidayColorAll()
        {
            int calendarIndex;
            int rowIndex;
            int columnIndex;

            DateTime targetDate = new DateTime(_year, 1, 1);

            // 年度が変わるまでループ処理
            while (targetDate.Year <= _year)
            {
                if (_applyDateList.ContainsKey(targetDate) == true)
                {
                    // 日付取得処理
                    FindTargetCell(targetDate, out calendarIndex, out rowIndex, out columnIndex);

                    if (_applyDateList[targetDate] == 0)
                    {
                        // 適用区分が休業日の場合、クリックした日付を休業日の色に変える
                        this._calendar_uGrid[calendarIndex].DisplayLayout.Rows[rowIndex].Cells[columnIndex].Appearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                    }
                    else
                    {
                        // 適用区分が祝祭日の場合、クリックした日付を祝祭日の色に変える
                        this._calendar_uGrid[calendarIndex].DisplayLayout.Rows[rowIndex].Cells[columnIndex].Appearance.BackColor = System.Drawing.Color.FromArgb(255, 135, 148);
                    }
                }
                targetDate = targetDate.AddDays(1);
            }
        }

        /// <summary>
        /// 色表示処理                                                         
        /// </summary>
        /// <param name="targetDate">対象日</param>
        /// <remarks>
        /// Note       : 設定された休業日・祝祭日に適した色を表示します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected void SetHolidayColor(DateTime targetDate)
        {
            int calendarIndex;
            int rowIndex;
            int columnIndex;

            // 日付取得処理
            FindTargetCell(targetDate, out calendarIndex, out rowIndex, out columnIndex);

            // _applyDateListに適用年月日があるかどうかチェック
            if (_applyDateList.ContainsKey(targetDate))
            {
                // 適用区分が休業日かどうかチェック
                if (ApplyDateCd == 0)
                {
                    // 適用区分が休業日の場合、クリックした日付を休業日の色に変える
                    this._calendar_uGrid[calendarIndex].DisplayLayout.Rows[rowIndex].Cells[columnIndex].Appearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                }
                else
                {
                    // 適用区分が祝祭日の場合、クリックした日付を祝祭日の色に変える
                    this._calendar_uGrid[calendarIndex].DisplayLayout.Rows[rowIndex].Cells[columnIndex].Appearance.BackColor = System.Drawing.Color.FromArgb(255, 135, 148);
                }
            }
            // 適用年月日がない場合
            else
            {
                // 色表示しない
                this._calendar_uGrid[calendarIndex].DisplayLayout.Rows[rowIndex].Cells[columnIndex].Appearance.BackColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// 曜日チェック処理                                                         
        /// </summary>  
        /// <param name="week">週</param>
        /// <param name="allCheck">選択削除チェック</param>
        /// <returns>allCheck = true　なら、クリックされた曜日を全て削除。</returns>
        /// <returns>allCheck = false　なら、クリックされた曜日を全て選択。</returns>
        /// <remarks>
        /// Note       : クリックされた曜日が休業日・祝祭日に設定されているかチェックします。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected void CheckTargetWeek(int week, out bool allCheck)
        {
            allCheck = true;

            // 初日取得処理 
            DateTime targetDate = GetFirstDay(_year, week);

            // クリックした日付が全て_applyDateListにあるかチェック
            // 年度が変わるまでループ処理
            while (targetDate.Year <= _year)
            {
                // _applyDateListに適用年月日がない、または適用区分が違う場合 
                if (_applyDateList.ContainsKey(targetDate) == false
                    || _applyDateList[targetDate] != this.ApplyDateCd)
                {
                    allCheck = false;
                    break;
                }
                targetDate = targetDate.AddDays(7);
            }
        }

        /// <summary>
        /// 全曜日削除処理                                                         
        /// </summary>
        /// <param name="week">週</param>
        /// <remarks>
        /// Note       : クリックされた曜日を全て削除します。<br />                       
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected void DeleteHolidaySettingDataAll(int week)
        {
            DateTime targetDate = GetFirstDay(_year, week);
            while (targetDate.Year <= _year)
            {
                _applyDateList.Remove(targetDate);

                // 色表示処理
                SetHolidayColor(targetDate);
                targetDate = targetDate.AddDays(7);
            }
        }

        /// <summary>
        /// 全曜日選択処理                                                         
        /// </summary> 
        /// <param name="week">週</param>
        /// <remarks>
        /// Note       : クリックされた曜日を全て選択します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected void SelectHolidaySettingDataAll(int week)
        {
            DateTime targetDate = GetFirstDay(_year, week);

            while (targetDate.Year <= _year)
            {
                _applyDateList[targetDate] = this.ApplyDateCd;

                // 色表示処理
                SetHolidayColor(targetDate);

                targetDate = targetDate.AddDays(7);
            }
        }

        /// <summary>
        /// セル位置処理                                                         
        /// </summary>
        /// <param name="targetDate">対象日</param>
        /// <param name="calendarIndex">カレンダーインデックス</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="columnIndex">カラムインデックス</param>
        /// <remarks>
        /// Note       : 日付からセル位置を取得します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        // 日付からセル位置を取得
        internal void FindTargetCell(DateTime targetDate, out int calendarIndex, out int rowIndex, out int columnIndex)
        {
            DateTime workMonth = new DateTime(targetDate.Year, targetDate.Month, 1);
            int workDayOfWeek = (int)workMonth.DayOfWeek;
            int workDay = targetDate.Day + workDayOfWeek - 1;

            calendarIndex = targetDate.Month - 1;
            rowIndex = workDay / 7;
            columnIndex = workDay % 7;
        }

        /// <summary>
        /// 日付取得処理                                                         
        /// </summary>
        /// <param name="month">月</param>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="colmunIndex">カラムインデックス</param>
        /// <param name="targetDate">日付</param>
        /// <remarks>
        /// Note       : クリックされた位置から日付を取得します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected int FindTargetDate(int month, int rowIndex, int colmunIndex, out DateTime targetDate)
        {
            targetDate = new DateTime();

            DateTime targetMonth = new DateTime(_year, month, 1);
            int iDaysInMonth = DateTime.DaysInMonth(_year, month);
            int dayOfWeek = (int)targetMonth.DayOfWeek;

            int day = rowIndex * 7 + colmunIndex + 1 - dayOfWeek;
            if (day <= 0 || iDaysInMonth < day)
            {
                return (1);
            }

            targetDate = new DateTime(_year, month, day);

            return (0);
        }

        /// <summary>
        /// 初日取得処理                                                         
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="week">週</param>
        /// <remarks>
        /// Note       : クリックされた曜日の初日を取得します。<br />                        
        /// Programmer : NEPCO<br />                                    
        /// Date       : 2007.01.19<br />                                        
        /// </remarks>
        protected DateTime GetFirstDay(int year, int week)
        {
            DateTime workDate = new DateTime(year, 1, 1);
            int addDay;
            if (week >= (int)workDate.DayOfWeek)
            {
                addDay = week - (int)workDate.DayOfWeek;
            }
            else
            {
                addDay = 7 - (int)workDate.DayOfWeek + week;
            }
            return (workDate.AddDays(addDay));
        }

        # endregion

        # region Control Events

        /// <summary>
        /// カレンダーコントロールロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// Note　　　  : カレンダーコントロールロード時に発生します<br />                  
        /// Programmer  : NEPCO<br />                                    
        /// Date        : 2007.01.19<br />                                        
        /// </remarks>
        private void Calendar_Control_Load(object sender, EventArgs e)
        {
            this._calendar_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid[12];

            this._calendar_uGrid[0] = this.January_uGrid;
            this._calendar_uGrid[1] = this.February_uGrid;
            this._calendar_uGrid[2] = this.March_uGrid;
            this._calendar_uGrid[3] = this.April_uGrid;
            this._calendar_uGrid[4] = this.May_uGrid;
            this._calendar_uGrid[5] = this.June_uGrid;
            this._calendar_uGrid[6] = this.July_uGrid;
            this._calendar_uGrid[7] = this.August_uGrid;
            this._calendar_uGrid[8] = this.September_uGrid;
            this._calendar_uGrid[9] = this.October_uGrid;
            this._calendar_uGrid[10] = this.November_uGrid;
            this._calendar_uGrid[11] = this.December_uGrid;

            for (int index = 0; index < 12; index++)
            {
                this._calendar_uGrid[index].Tag = index;
            }
        }

        /// <summary>
        /// 前年ボタンクリックイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// Note　　　  : 前年ボタンクリック時に発生します<br />                  
        /// Programmer  : NEPCO<br />                                    
        /// Date        : 2007.01.19<br />                                        
        /// </remarks>
        protected void PreviousYear_Button_Click(object sender, EventArgs e)
        {
            _year--;

            // カレンダー作成処理 
            this.DispScrean(_year);
        }

        /// <summary>
        /// 翌年ボタンクリックイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// Note　　　  : 翌年ボタンクリック時に発生します<br />                  
        /// Programmer  : NEPCO<br />                                    
        /// Date        : 2007.01.19<br />                                        
        /// </remarks>
        protected void NextYear_Button_Click(object sender, EventArgs e)
        {
            _year++;

            // カレンダー作成処理 
            this.DispScrean(_year);
        }

        /// <summary>
        /// カレンダーコントロールクリックイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// Note　　　  : カレンダーコントロールクリック時に発生します<br />                  
        /// Programmer  : NEPCO<br />                                    
        /// Date        : 2007.01.19<br />                                        
        /// </remarks>
        protected void January_uGrid_MouseDown(object sender, MouseEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid uGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
            System.Windows.Forms.MouseEventArgs mArgs = (System.Windows.Forms.MouseEventArgs)e;

            Infragistics.Win.UIElement parentElem;
            Infragistics.Win.UltraWinGrid.UltraGridRow uRow;
            Infragistics.Win.UltraWinGrid.UltraGridColumn uColumn;

            // クリックされたコントロールを取得 
            Infragistics.Win.UIElement elem = uGrid.DisplayLayout.UIElement.ElementFromPoint(new Point(mArgs.Location.X, mArgs.Location.Y));
            if (elem != null)
            {
                // クリックされたコントロールの親のヘッダーコントロールを取得  
                parentElem = elem.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.HeaderUIElement));
                if (parentElem != null)
                {
                    // 
                    // ヘッダーがクリックされた  
                    //
                    // クリックされた列を取得
                    uColumn = (Infragistics.Win.UltraWinGrid.UltraGridColumn)elem.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridColumn));
                    if (uColumn != null)
                    {
                        int week = uColumn.Index;
                        bool allCheck;

                        // 曜日チェック処理
                        CheckTargetWeek(week, out allCheck);

                        if (allCheck == true)
                        {
                            // 対象曜日すべてに休業日・祝祭日を解除
                            DeleteHolidaySettingDataAll(week);
                        }
                        else
                        {
                            // 対象曜日すべてに休業日・祝祭日を登録
                            SelectHolidaySettingDataAll(week);
                        }
                    }
                    return;
                }
                // クリックされたコントロールの親のヘッダーコントロールを取得  
                parentElem = elem.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.CellUIElement));
                if (parentElem != null)
                {
                    // 
                    // 日付セルがクリックされた  
                    //
                    // クリックされた行を取得
                    uRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)elem.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
                    // クリックされた列を取得
                    uColumn = (Infragistics.Win.UltraWinGrid.UltraGridColumn)elem.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridColumn));
                    if (uRow != null && uColumn != null)
                    {
                        int rowIndex = uRow.Index;
                        int columnIndex = uColumn.Index;
                        int gridIndex = (int)uGrid.Tag;
                        int month = gridIndex + 1;
                        DateTime targetDate;

                        // 日付取得処理
                        int ret = FindTargetDate(month, rowIndex, columnIndex, out targetDate);
                        if (ret != 0)
                        {
                            // 日付のないセルがクリックされた
                            return;
                        }

                        // 休業日・祝祭日の登録
                        SetHolidaySettingData(targetDate);
                        // グリッドの色を変更
                        SetHolidayColor(targetDate);
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// カレンダーコントロールキーダウンイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                           
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// Note　　　  : カレンダーコントロールキーダウン時に発生します<br />                  
        /// Programmer  : NEPCO<br />                                    
        /// Date        : 2007.05.30<br />                                        
        /// </remarks>
        private void January_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid uGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int columnIndex = uGrid.ActiveCell.Column.Index;
            int gridIndex = (int)uGrid.Tag;

            if (e.KeyCode == Keys.Space)
            {
                // 
                // スペースボタン押下
                //
                int month = gridIndex + 1;
                DateTime targetDate;

                // 日付取得処理
                int ret = FindTargetDate(month, rowIndex, columnIndex, out targetDate);
                if (ret != 0)
                {
                    // 日付のないセルがクリックされた
                    return;
                }

                // 休業日・祝祭日の登録
                SetHolidaySettingData(targetDate);
                // グリッドの色を変更
                SetHolidayColor(targetDate);
                
                //if (uGrid.ActiveCell != null)
                //{
                    
                //}
            }

            int targetRowIndex;

            if (e.KeyCode == Keys.Up)
            {
                if (rowIndex == 0)
                {
                    switch (gridIndex)
                    {
                        case 0:
                        case 1:
                            this.PreviousYear_Button.Focus();
                            break;
                        case 2:
                        case 3:
                            this.NextYear_Button.Focus();
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            targetRowIndex = this._calendar_uGrid[gridIndex - 4].Rows.Count - 1;
                            this._calendar_uGrid[gridIndex - 4].Focus();
                            this._calendar_uGrid[gridIndex - 4].Rows[targetRowIndex].Cells[columnIndex].Activate();
                            break;
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (rowIndex == uGrid.Rows.Count - 1)
                {
                    switch (gridIndex)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            this._calendar_uGrid[gridIndex + 4].Focus();
                            this._calendar_uGrid[gridIndex + 4].Rows[0].Cells[columnIndex].Activate();
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            this._nextControl.Focus();
                            break;
                    }
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (columnIndex == 6)
                {
                    switch (gridIndex)
                    {
                        case 3:
                        case 7:
                        case 11:
                            this._calendar_uGrid[gridIndex].Rows[rowIndex].Cells[columnIndex].Activate();
                            e.Handled = true;
                            break;
                        case 0:
                        case 1:
                        case 2:
                        case 4:
                        case 5:
                        case 6:
                        case 8:
                        case 9:
                        case 10:
                            targetRowIndex = this._calendar_uGrid[gridIndex + 1].Rows.Count - 1;
                            this._calendar_uGrid[gridIndex + 1].Focus();
                            if (rowIndex > targetRowIndex)
                            {
                                this._calendar_uGrid[gridIndex + 1].Rows[targetRowIndex].Cells[0].Activate();
                            }
                            else
                            {
                                this._calendar_uGrid[gridIndex + 1].Rows[rowIndex].Cells[0].Activate();
                            }
                            break;
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (columnIndex == 0)
                {
                    switch (gridIndex)
                    {
                        case 0:
                        case 4:
                        case 8:
                            this._calendar_uGrid[gridIndex].Rows[rowIndex].Cells[columnIndex].Activate();
                            e.Handled = true;
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 5:
                        case 6:
                        case 7:
                        case 9:
                        case 10:
                        case 11:
                            targetRowIndex = this._calendar_uGrid[gridIndex - 1].Rows.Count - 1;
                            this._calendar_uGrid[gridIndex - 1].Focus();
                            if (rowIndex > targetRowIndex)
                            {
                                this._calendar_uGrid[gridIndex - 1].Rows[targetRowIndex].Cells[6].Activate();
                            }
                            else
                            {
                                this._calendar_uGrid[gridIndex - 1].Rows[rowIndex].Cells[6].Activate();
                            }
                            break;
                    }
                }
            }
        }

        # endregion

    }
}

