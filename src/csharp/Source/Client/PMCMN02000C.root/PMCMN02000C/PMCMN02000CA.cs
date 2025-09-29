using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 帳票印刷共通部品クラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : PM.NSの共通仕様に基づき、帳票印刷の一般的な制御を行います。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2009.02.06</br>
	/// <br></br>
	/// <br>Update Note  : 2009.04.22  22018 鈴木 正臣</br>
    /// <br>             : 　①グループサプレス対応処理を追加。</br>
    /// <br>Update Note  : 2009.07.16  22018 鈴木 正臣</br>
    /// <br>             : 　①右詰め項目(数値項目を想定)で、先頭がカンマ(,)の場合は取り除く処理を追加。(",ZZZ,ZZ9"→"ZZZZ,ZZ9")</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/24  22018 鈴木 正臣</br>
    /// <br>             : ＱＲコードの印刷機能を追加。</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/17  22018 鈴木 正臣</br>
    /// <br>             : サブレポート対応機能を追加。</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/29  22018 鈴木 正臣</br>
    /// <br>             : 請求書のアウトオブメモリエラー対応。</br>
    /// <br></br>
    /// <br>Update Note  : 2010/10/04  22018 鈴木 正臣</br>
    /// <br>             : 印字項目の前方スペースがカットされる件の修正。</br>
    /// <br></br>
    /// <br>Update Note  : 2011/01/13  30517 夏野 駿希</br>
    /// <br>             : 台東部品商会様個別対応</br>
    /// <br>             : 明細請求書・明細部に伝票計行の下へ罫線を引く（ar.Control is Line用イベントを作成）</br>
    /// <br></br>
    /// <br>Update Note  : 2011/04/07  22018 鈴木 正臣</br>
    /// <br>             : 一般帳票でも使用できるよう対応。(請求一覧表,回収予定表で使用)</br>
    /// </remarks>
	public class PMCMN02000CA
	{
        // DotPerInch
        private const decimal ct_DPI = 72;

        // staticインスタンス
        private static PMCMN02000CA _instance;
        // Shift-JISエンコーディング
        private static Encoding _sjisEnc;

        // コントロール初期化キャンセルフラグ
        private bool _initializeCancel;
        // 縦倍角対象リスト（外部パラメータ用）
        private List<string> _doubleHeightTargetList;
        // 縦倍角対象ディクショナリ（内部処理用）
        private Dictionary<string, DoubleHeightTarget> _doubleHeightTargetdic;
        // カスタム用紙フラグ
        private bool _customFormFlag = false;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        // グループサプレス区分
        private GroupSuppressDivState _groupSuppressDiv;
        // グループサプレスモード
        private GroupSuppressModeState _groupSuppressMode;
        // グループ項目リスト
        private List<string> _groupingItemList;
        // グループ処理前回値ディクショナリ
        private Dictionary<string, string> _prevGroupingItemValueDic;
        
        // セクション別コントロール一覧
        private Dictionary<string, List<ar.ARControl>> _arControlListDic;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        // ＱＲコード印刷サイズ一覧
        private Dictionary<string, float> _qrCodeSizeDic;
        // ＱＲコード印刷有無フラグ
        private bool _qrCodeVisible;
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        // サブレポート対象リスト(参照元)
        private List<string> _subReportTargetList;
        // サブレポートディクショナリ(参照先)
        private Dictionary<string, ar.ActiveReport3> _subReportDic;
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

        # region [プロパティ]
        /// <summary>
        /// コントロール初期化キャンセルフラグ
        /// </summary>
        public bool InitializeCancel
        {
            get { return _initializeCancel; }
            set { _initializeCancel = value; }
        }
        /// <summary>
        /// 縦倍角対応リスト
        /// </summary>
        public List<string> DoubleHeightTargetList
        {
            get { return _doubleHeightTargetList; }
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //set { _doubleHeightTargetList = value; }
            set 
            {
                // Listが書き変わる時、Dicもクリアする。
                _doubleHeightTargetdic = null;

                // set
                _doubleHeightTargetList = value;
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        /// <summary>
        /// グループサプレス区分
        /// </summary>
        public GroupSuppressDivState GroupSuppressDiv
        {
            get { return _groupSuppressDiv; }
            set { _groupSuppressDiv = value; }
        }
        /// <summary>
        /// グループサプレスモード
        /// </summary>
        public GroupSuppressModeState GroupSuppressMode
        {
            get { return _groupSuppressMode; }
            set { _groupSuppressMode = value; }
        }
        /// <summary>
        /// グループ項目リスト（GroupSuppressDiv=NormalまたはFreePrintの場合有効）
        /// </summary>
        public List<string> GroupingItemList
        {
            get { return _groupingItemList; }
            set { _groupingItemList = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// <summary>
        /// ＱＲコード印刷サイズ一覧
        /// </summary>
        public Dictionary<string, float> QrCodeSizeDic
        {
            get { return _qrCodeSizeDic; }
            set { _qrCodeSizeDic = value; }
        }
        /// <summary>
        /// ＱＲコード印字有無
        /// </summary>
        public bool QRCodeVisible
        {
            get { return _qrCodeVisible; }
            set { _qrCodeVisible = value; }
        }
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// サブレポート対象リスト(参照元)
        /// </summary>
        /// <remarks>DataFieldを指定(例 FREEPRINT.SUBREPORT)</remarks>
        public List<string> SubReportTargetList
        {
            get { return _subReportTargetList; }
            set { _subReportTargetList = value; }
        }
        /// <summary>
        /// サブレポートディクショナリ(参照先)
        /// </summary>
        /// <remarks>key:フォーム名(例 A999_b), value:対象のフォーム(例 A999_bで登録されているReport)</remarks>
        public Dictionary<string,ar.ActiveReport3> SubReportDic
        {
            get { return _subReportDic; }
            set { _subReportDic = value; }
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        # region [enum]
        # region [グループサプレス区分]
        /// <summary>
        /// グループサプレス区分（サプレス対象の指定）
        /// </summary>
        public enum GroupSuppressDivState
        {
            /// <summary>0:サプレスしない</summary>
            None = 0,
            /// <summary>1:通常帳票</summary>
            Normal = 1,
            /// <summary>2:自由帳票</summary>
            FreePrint = 2,
        }
        /// <summary>
        /// グループサプレスモード（サプレス方法の指定）
        /// </summary>
        public enum GroupSuppressModeState
        {
            /// <summary>単独</summary>
            Single = 1,
            /// <summary>複数(左側が上位)</summary>
            Multi = 2,
        }
        # endregion
        // --- ADD m.suzuki 2010/00/00 ---------->>>>>
        /// <summary>
        /// レポートプロパティ設定種別
        /// </summary>
        public enum SetReportPropsKind
        {
            /// <summary>自由帳票</summary>
            FreePrint = 0,
            /// <summary>一般帳票</summary>
            NormalList = 1,
        }
        // --- ADD m.suzuki 2010/00/00 ----------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD

        # region [BeforePrintEditEventArgs]
        /// <summary>
        /// BeforePrintEditEventArgs
        /// </summary>
        public class BeforePrintEditEventArgs : EventArgs
        {
            private ar.Section _section;
            private ar.ARControl _control;
            private string _adjustedText;
            private bool _cancel;

            public ar.Section Section
            {
                get { return _section; }
            }
            public ar.ARControl Control
            {
                get { return _control; }
            }
            public string AdjustedText
            {
                get { return _adjustedText; }
                set { _adjustedText = value; }
            }
            public bool Cancel
            {
                get { return _cancel; }
                set { _cancel = value; }
            }
            public BeforePrintEditEventArgs( ar.Section section, ar.ARControl control, string adjustedText, bool cancel )
            {
                _section = section;
                _control = control;
                _adjustedText = adjustedText;
                _cancel = cancel;
            }
        }
        # endregion

        // 2011/01/13 Add >>>
        # region [BeforePrintEditLineEventArgs]
        /// <summary>
        /// BeforePrintEditLineEventArgs
        /// </summary>
        public class BeforePrintEditLineEventArgs : EventArgs
        {
            private ar.ARControl _control;
            private List<ar.ARControl> _arControlList;

            public ar.ARControl Control
            {
                get { return _control; }
            }
            public List<ar.ARControl> ControlList
            {
                get { return _arControlList; }
                set { _arControlList = value; }
            }
            public BeforePrintEditLineEventArgs(ar.ARControl control, List<ar.ARControl> controlList)
            {
                _control = control;
                _arControlList = controlList;
            }
        }
        # endregion
        // 2011/01/13 Add <<<

        # region [イベントデリゲート定義]
        /// <summary>
        /// Edit印刷前イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BeforePrintEditHandler( object sender, BeforePrintEditEventArgs e );

        // 2011/01/13 Add >>>
        /// <summary>
        /// EditLine印刷前イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BeforePrintEditLineHandler( object sender, BeforePrintEditLineEventArgs e );
        // 2011/01/13 Add <<<
        # endregion

        # region [イベント]
        /// <summary>
        /// Edit印字前イベント
        /// </summary>
        public event BeforePrintEditHandler BeforePrintEdit;

        // 2011/01/13 Add >>>
        /// <summary>
        /// EditLine印字前イベント
        /// </summary>
        public event BeforePrintEditLineHandler BeforePrintEditLine;
        // 2011/01/13 Add <<<
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// privateコンストラクタ
        /// </summary>
        private PMCMN02000CA()
        {
            this.InitializeCancel = false;
            this.DoubleHeightTargetList = new List<string>();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            this.GroupSuppressDiv = GroupSuppressDivState.None;
            this.GroupSuppressMode = GroupSuppressModeState.Multi;
            this.GroupingItemList = new List<string>();
            this._prevGroupingItemValueDic = new Dictionary<string, string>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            this._qrCodeSizeDic = new Dictionary<string, float>();
            this._qrCodeVisible = true;
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
            this._subReportTargetList = new List<string>();
            this._subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        }
        /// <summary>
        /// static コンストラクタ
        /// </summary>
        static PMCMN02000CA()
        {
            // ↓staticメソッドで使用するstaticフィールドの初期化
            _sjisEnc = Encoding.GetEncoding( "Shift_JIS" );
        }
        # endregion

        # region [publicメソッド]
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns></returns>
        public static PMCMN02000CA GetInstance()
        {
            if ( _instance == null )
            {
                _instance = new PMCMN02000CA();
            }
            // --- ADD m.suzuki 2010/06/29 ---------->>>>>
            _instance.Clear();
            // --- ADD m.suzuki 2010/06/29 ----------<<<<<
            return _instance;
        }

        /// <summary>
        /// 帳票設定処理
        /// </summary>
        /// <param name="report"></param>
        public void SetReportProps( ref ar.ActiveReport3 report )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 DEL
            //// 縦倍角対象があれば
            //if ( DoubleHeightTargetList != null && DoubleHeightTargetList.Count > 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 DEL
            {
                // レポート印刷開始イベントハンドラ登録
                report.ReportStart += new EventHandler( report_ReportStart );

                // 連帳用
                if ( report.PageSettings.PaperKind == PaperKind.Custom )
                {
                    _customFormFlag = true;
                }
                else
                {
                    _customFormFlag = false;
                }
            }

            // 全てのセクションに対して
            foreach ( ar.Section section in report.Sections )
            {
                // 全コントロールのプロパティをセットする
                foreach ( ar.ARControl control in section.Controls )
                {
                    if ( control is ar.TextBox )
                    {
                        ar.TextBox textBox = (control as ar.TextBox);
                        //----------------------------------------------
                        // ※複数行＝なしの場合は、
                        //   折り返し＝なしにする。
                        //----------------------------------------------
                        if ( !textBox.MultiLine )
                        {
                            textBox.WordWrap = false;
                        }
                    }
                }

                // 印刷前イベントハンドラを登録する。
                section.BeforePrint += new EventHandler( section_BeforePrint );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            // グループサプレスする場合はサプレス解除用にイベントハンドラ登録する
            if ( GroupSuppressDiv != GroupSuppressDivState.None )
            {
                report.PageEnd += new EventHandler( report_PageEnd );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        }
        // --- ADD m.suzuki 2010/00/00 ---------->>>>>
        /// <summary>
        /// 帳票設定処理(ALL)
        /// </summary>
        /// <param name="report"></param>
        public void SetReportProps( ref ar.ActiveReport3 report, SetReportPropsKind kind )
        {
            switch ( kind )
            {
                case SetReportPropsKind.FreePrint:
                    {
                        // 自由帳票
                        SetReportProps( ref report );
                    }
                    break;
                case SetReportPropsKind.NormalList:
                    {
                        // 一般帳票
                        SetReportPropsForNormalList( ref report );
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 帳票設定処理(一般帳票用)
        /// </summary>
        /// <param name="report"></param>
        /// <remarks>※一般帳票に必要な機能だけに限定し、処理速度への影響を抑えます。</remarks>
        private void SetReportPropsForNormalList( ref DataDynamics.ActiveReports.ActiveReport3 report )
        {
            // 全てのセクションに対して
            foreach ( ar.Section section in report.Sections )
            {
                // 印刷前イベントハンドラを登録する。
                section.BeforePrint += new EventHandler( normalListSection_BeforePrint );
            }
        }
        // --- ADD m.suzuki 2010/00/00 ----------<<<<<
        // --- ADD m.suzuki 2010/06/29 ---------->>>>>
        /// <summary>
        /// 内部保持情報のクリア
        /// </summary>
        public void Clear()
        {
            _prevGroupingItemValueDic = null;
            _arControlListDic = null;
        }
        // --- ADD m.suzuki 2010/06/29 ----------<<<<<

        /// <summary>
        /// 印刷可能バイト数の取得（外部公開用）
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="minCount"></param>
        /// <param name="maxCount"></param>
        public static void GetPrintableByteCount( ar.TextBox textBox, out int minCount, out int maxCount )
        {
            if ( textBox.CharacterSpacing == 0 )
            {
                // 文字間隔＝ゼロの場合
                int count = (int)(((decimal)textBox.Width) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI));
                minCount = count;
                maxCount = count;
            }
            else
            {
                // 文字間隔≠ゼロの場合

                // 全て半角→バイト数あたりの文字数が多い→余白の数が多い→印刷可能バイト数：少
                minCount = (int)(((decimal)textBox.Width + (decimal)textBox.CharacterSpacing / ct_DPI) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI + (decimal)textBox.CharacterSpacing / ct_DPI));

                // 全て全角→バイト数あたりの文字数が少ない→余白の数が少ない→印刷可能バイト数：多
                maxCount = (int)((((decimal)textBox.Width + (decimal)textBox.CharacterSpacing / ct_DPI) / ((decimal)textBox.Font.SizeInPoints / ct_DPI + (decimal)textBox.CharacterSpacing / ct_DPI)) * 2);
            }
        }
        # endregion

        # region [レポートオブジェクトに対して差し込むイベントハンドラ関連（自由帳票用）]
        /// <summary>
        /// レポート印刷開始イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void report_ReportStart( object sender, EventArgs e )
        {
            // 対象ディクショナリ生成
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //_doubleHeightTargetdic = new Dictionary<string, DoubleHeightTarget>();
            if ( _doubleHeightTargetdic == null )
            {
                _doubleHeightTargetdic = new Dictionary<string, DoubleHeightTarget>();
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            _prevGroupingItemValueDic = new Dictionary<string, string>();
            // --- DEL m.suzuki 2010/05/17 ---------->>>>>
            //_arControlListDic = new Dictionary<string, List<DataDynamics.ActiveReports.ARControl>>();
            // --- DEL m.suzuki 2010/05/17 ----------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
            // サブレポート対応用リスト初期化
            List<ar.Label> subReportLabelList = new List<ar.Label>();
            List<ar.SubReport> subReportList = new List<ar.SubReport>();
            // --- ADD m.suzuki 2010/05/17 ----------<<<<<

            try
            {
                // 全てのセクションに対して処理
                foreach ( ar.Section section in (sender as ar.ActiveReport3).Sections )
                {
                    # region [セクションに対する操作]
                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                    //// セクション内の対象コントロールリスト生成
                    //_arControlListDic.Add( section.Name, new List<DataDynamics.ActiveReports.ARControl>() );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                    if ( _arControlListDic == null )
                    {
                        _arControlListDic = new Dictionary<string, List<DataDynamics.ActiveReports.ARControl>>();
                    }
                    // セクションにGUIDを付与する
                    section.Tag = Guid.NewGuid();
                    string sectionKey = section.Tag.ToString();
                    _arControlListDic.Add( sectionKey, new List<DataDynamics.ActiveReports.ARControl>() );
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<

                    foreach ( ar.ARControl control in section.Controls )
                    {
                        # region [セクション内のコントロールへの操作]
                        if ( control is ar.TextBox )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                            // 共通
                            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                            //_arControlListDic[section.Name].Add( control );
                            _arControlListDic[sectionKey].Add( control );
                            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD

                            // --- ADD m.suzuki 2010/00/00 ---------->>>>>
                            // データフィールド未設定ならば迂回
                            if ( string.IsNullOrEmpty( control.DataField ) ) continue;
                            // --- ADD m.suzuki 2010/00/00 ----------<<<<<

                            // 縦倍角対応
                            # region [縦倍角対応]
                            if ( _doubleHeightTargetList.Contains( control.DataField.ToUpper() ) )
                            {
                                // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                                //if ( !_doubleHeightTargetdic.ContainsKey( control.Name ) )
                                string doubleHeightTargetKey = CreateDoubleHeightTargetKey( sectionKey, control.Name );
                                if ( !_doubleHeightTargetdic.ContainsKey( doubleHeightTargetKey ) )
                                // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                                {
                                    // 縦倍角対応するための情報を生成して退避する
                                    DoubleHeightTarget target = new DoubleHeightTarget();

                                    target.DataField = control.DataField;
                                    target.ParentSection = section;
                                    target.TargetTextBox = (ar.TextBox)control;
                                    
                                    target.DoubleHeightPicture = new DataDynamics.ActiveReports.Picture();
                                    target.DoubleHeightPicture.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft;
                                    target.DoubleHeightPicture.Location = target.TargetTextBox.Location;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                                    target.DoubleHeightPicture.Visible = false;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
                                    
                                    target.DoubleHeightPicture.Size = target.TargetTextBox.Size;
                                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                                    //_doubleHeightTargetdic.Add( control.Name, target );
                                    _doubleHeightTargetdic.Add( doubleHeightTargetKey, target );
                                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                                }
                            }
                            # endregion

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                            // グループサプレス対応(自由帳票)
                            # region [グループサプレス対応(自由帳票)]
                            if ( GroupSuppressDiv == GroupSuppressDivState.FreePrint )
                            {
                                // サプレス対象リストに追加する
                                FrePControlTag tag = new FrePControlTag( control.Tag );
                                if ( tag.GroupSuppressCd == 1 && !_groupingItemList.Contains( control.Name ) )
                                {
                                    _groupingItemList.Add( control.Name );
                                }
                            }
                            # endregion
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                        }
                        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                        else if ( control is ar.Barcode )
                        {
                            if ( _qrCodeVisible )
                            {
                                control.Visible = true;

                                // PM7の印刷結果に合わせる為に下記の通りセットする（取込み結果は変わらない）
                                (control as ar.Barcode).QRCode.ErrorLevel = DataDynamics.ActiveReports.Options.QRCodeErrorLevel.M;
                                (control as ar.Barcode).QRCode.Mask = DataDynamics.ActiveReports.Options.QRCodeMask.Mask101;
                                (control as ar.Barcode).QRCode.Model = DataDynamics.ActiveReports.Options.QRCodeModel.Model2;

                                // QRコードのサイズ調整
                                string dataField = control.DataField.ToUpper();
                                if ( _qrCodeSizeDic.ContainsKey( dataField ) )
                                {
                                    // X * Y なので率はルートを求める
                                    float sizeRate = (float)Math.Pow( _qrCodeSizeDic[dataField], 0.5 );
                                    control.Size = new SizeF( control.Size.Width * sizeRate, control.Size.Height * sizeRate );
                                }
                            }
                            else
                            {
                                // QRｺｰﾄﾞを印字しない
                                control.Visible = false;
                            }
                        }
                        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        else if ( control is ar.Label )
                        {
                            # region [サブレポート対応]
                            if ( _subReportTargetList != null && _subReportDic != null && control.DataField != null )
                            {
                                if ( _subReportTargetList.Contains( control.DataField.ToUpper() ) )
                                {
                                    ar.Label orgLabel = (control as ar.Label);

                                    string[] param = orgLabel.Text.Split( ',' );
                                    if ( param.Length > 0 )
                                    {
                                        string formName = param[0];

                                        if ( _subReportDic.ContainsKey( formName ) )
                                        {
                                            ar.SubReport newSubReport = new ar.SubReport();

                                            // サブレポートにバインドするレポートを指定
                                            newSubReport.Report = _subReportDic[formName];
                                            // データソースを指定(親のレポートと同じにする)
                                            newSubReport.Report.DataSource = (sender as ar.ActiveReport3).DataSource;
                                            newSubReport.Report.DataMember = (sender as ar.ActiveReport3).DataMember;

                                            // サイズをデザイン用のラベルに合わせる
                                            newSubReport.Width = orgLabel.Width;
                                            newSubReport.Height = orgLabel.Height;
                                            newSubReport.Top = orgLabel.Top;
                                            newSubReport.Left = orgLabel.Left;

                                            // 固定でセット必要なプロパティ
                                            newSubReport.CanGrow = false;
                                            newSubReport.CanShrink = false;

                                            // 退避しておく
                                            subReportLabelList.Add( orgLabel );
                                            subReportList.Add( newSubReport );
                                        }
                                    }
                                }
                            }
                            # endregion
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                        // 2011/01/13 Add >>>
                        else if (control is ar.Line)
                        {
                            _arControlListDic[sectionKey].Add(control);
                        }
                        // 2011/01/13 Add <<<
                        # endregion
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                    // セクション別のリストをソート
                    if ( GroupSuppressMode != GroupSuppressModeState.Single )
                    {
                        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                        //_arControlListDic[section.Name].Sort( new ARControlComparer() );
                        _arControlListDic[sectionKey].Sort( new ARControlComparer() );
                        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                    # endregion
                }

                # region [コレクションに対して一括処理]
                // 縦倍角対応
                foreach ( DoubleHeightTarget target in _doubleHeightTargetdic.Values )
                {
                    target.ParentSection.Controls.Add( target.DoubleHeightPicture );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                    // 最背面へと移す(PDF出力時に背景色=透明にならない為)
                    target.DoubleHeightPicture.SendToBack();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                // グループサプレス対応
                foreach ( string groupingItemName in _groupingItemList )
                {
                    // サプレス用前回値退避ディクショナリに追加
                    _prevGroupingItemValueDic.Add( groupingItemName, string.Empty );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                // サブレポートへ置き換え
                for ( int index = 0; index < subReportLabelList.Count; index++ )
                {
                    ar.Section section = (subReportLabelList[index].Parent as ar.Section);
                    section.Controls.Add( subReportList[index] );
                    section.Controls.Remove( subReportLabelList[index] );
                }
                // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                # endregion
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// 縦倍角項目キー生成処理
        /// </summary>
        /// <param name="sectionKey"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private static string CreateDoubleHeightTargetKey( string sectionKey, string controlName )
        {
            return string.Format( "{0}-{1}", sectionKey, controlName );
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        /// <summary>
        /// 帳票セクション印刷前イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void section_BeforePrint( object sender, EventArgs e )
        {
            if ( sender == null || (sender is ar.Section) == false ) return;

            ar.Section section = (sender as ar.Section);

            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
            string sectionKey = (sender as ar.Section).Tag.ToString();
            if ( !_arControlListDic.ContainsKey( sectionKey ) ) return;
            // --- ADD m.suzuki 2010/05/17 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 DEL
            //foreach ( ar.ARControl control in section.Controls )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            bool prevItemSuppress = true;
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //foreach ( ar.ARControl control in _arControlListDic[section.Name] )
            foreach ( ar.ARControl control in _arControlListDic[sectionKey] )
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
            {
                if ( control is ar.TextBox )
                {
                    try
                    {
                        ar.TextBox textBox = (control as ar.TextBox);

                        string text = textBox.Text;
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        if ( text == null )
                        {
                            text = string.Empty;
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                        bool checkResult = false;

                        # region [グループサプレスチェック]
                        // グループサプレス対象の場合のみ、サプレスチェックと次項目の為のチェック結果退避を行う
                        if ( _groupingItemList.Contains( textBox.Name ) )
                        {
                            // サプレスチェック
                            checkResult = (CheckGroupSuppress( textBox ) && (prevItemSuppress));

                            // サプレスモード＝マルチの場合は、次項目の為にチェック結果を退避
                            if ( GroupSuppressMode == GroupSuppressModeState.Multi )
                            {
                                prevItemSuppress = checkResult;
                            }
                        }
                        # endregion

                        // サプレスor印字
                        if ( checkResult )
                        {
                            // サプレス
                            textBox.Text = string.Empty;
                        }
                        else
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                        {
                            # region [桁あふれ対応(Text書き換え)]
                            string format = textBox.OutputFormat;
                            switch ( format )
                            {
                                # region [コード下桁対応]
                                case "0":
                                    text = text.Substring( text.Length - 1, 1 );
                                    break;
                                case "00":
                                    text = text.Substring( text.Length - 2, 2 );
                                    break;
                                case "000":
                                    text = text.Substring( text.Length - 3, 3 );
                                    break;
                                case "0000":
                                    text = text.Substring( text.Length - 4, 4 );
                                    break;
                                case "00000":
                                    text = text.Substring( text.Length - 5, 5 );
                                    break;
                                case "000000":
                                    text = text.Substring( text.Length - 6, 6 );
                                    break;
                                case "0000000":
                                    text = text.Substring( text.Length - 7, 7 );
                                    break;
                                case "00000000":
                                    text = text.Substring( text.Length - 8, 8 );
                                    break;
                                case "000000000":
                                    text = text.Substring( text.Length - 9, 9 );
                                    break;
                                # endregion

                                # region[一般桁あふれ対応]
                                default:
                                    {
                                        text = GetPrintableText( textBox );
                                    }
                                    break;
                                # endregion
                            }

                            bool cancel = false;
                            # region [変更前イベント発生]
                            if ( this.BeforePrintEdit != null )
                            {
                                // イベント引数生成
                                BeforePrintEditEventArgs args = new BeforePrintEditEventArgs( section, control, text, false );

                                // イベント発生
                                this.BeforePrintEdit( sender, args );

                                // イベント結果反映
                                text = args.AdjustedText;
                                cancel = args.Cancel;
                            }
                            # endregion

                            // テキスト書き換え
                            if ( !cancel )
                            {
                                textBox.Text = text;
                            }
                            # endregion

                            // 縦倍角対応
                            # region [縦倍角対応]
                            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                            //if ( _doubleHeightTargetdic != null && _doubleHeightTargetdic.ContainsKey( control.Name ) )
                            string doubleHeightTargetKey = CreateDoubleHeightTargetKey( sectionKey, control.Name );
                            if ( _doubleHeightTargetdic != null && _doubleHeightTargetdic.ContainsKey( doubleHeightTargetKey ) )
                            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                            {
                                // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                                //DoubleHeightTarget target = _doubleHeightTargetdic[control.Name];
                                DoubleHeightTarget target = _doubleHeightTargetdic[doubleHeightTargetKey];
                                // --- UPD m.suzuki 2010/05/17 ----------<<<<<

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                                if ( !string.IsNullOrEmpty( target.TargetTextBox.Text ) )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
                                {
                                    target.DoubleHeightPicture.Image = GetDoubleHeightImage( target.TargetTextBox );
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                                    target.DoubleHeightPicture.PictureAlignment = GetPictureAlignment( target.TargetTextBox );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                                    target.DoubleHeightPicture.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
                                    target.DoubleHeightPicture.Visible = true;
                                    target.TargetTextBox.Visible = false;
                                }
                            }
                            # endregion
                        }
                    }
                    catch
                    {
                        // バインド先がDBNull.Valueの項目はcatch
                    }
                }
                // 2011/01/13 Add >>>
                if (control is ar.Line)
                {
                    try
                    {
                        if (this.BeforePrintEditLine != null)
                        {
                            BeforePrintEditLineEventArgs args = new BeforePrintEditLineEventArgs(control, _arControlListDic[sectionKey]);

                            this.BeforePrintEditLine(sender, args);
                        }
                    }
                    catch
                    {
                    }
                }
                // 2011/01/13 Add <<<
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        /// <summary>
        /// レポートページ終了イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void report_PageEnd( object sender, EventArgs e )
        {
            try
            {
                // 全ての前回値をクリアする(サプレスの解除)
                List<string> keyList = new List<string>();

                foreach ( string key in _prevGroupingItemValueDic.Keys )
                {
                    keyList.Add( key );
                }
                foreach ( string key in keyList )
                {
                    _prevGroupingItemValueDic[key] = string.Empty;
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }
        /// <summary>
        /// グループサプレスチェック処理
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>true: グループ化する / false: グループ化しない</returns>
        private bool CheckGroupSuppress( DataDynamics.ActiveReports.TextBox textBox )
        {
            if ( _prevGroupingItemValueDic.ContainsKey( textBox.Name ) )
            {
                // 前回値取得
                string prevText = _prevGroupingItemValueDic[textBox.Name];

                // 現在値を前回値として退避
                _prevGroupingItemValueDic[textBox.Name] = textBox.Text;


                // 前回値と比較
                return (textBox.Text == prevText);
            }
            else
            {
                // サプレス対象外
                return false;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        /// <summary>
        /// イメージ配置位置取得（ベースになるテキストボックスの配置位置から変換）
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private static DataDynamics.ActiveReports.PictureAlignment GetPictureAlignment( DataDynamics.ActiveReports.TextBox textBox )
        {
            switch ( textBox.Alignment )
            {
                // 左
                default:
                case DataDynamics.ActiveReports.TextAlignment.Left:
                    {
                        return DataDynamics.ActiveReports.PictureAlignment.BottomLeft;
                    }
                // 右
                case DataDynamics.ActiveReports.TextAlignment.Right:
                    {
                        return DataDynamics.ActiveReports.PictureAlignment.BottomRight;
                    }
                // 中央
                case DataDynamics.ActiveReports.TextAlignment.Center:
                case DataDynamics.ActiveReports.TextAlignment.Justify:
                    {
                        return DataDynamics.ActiveReports.PictureAlignment.Center;
                    }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

        /// <summary>
        /// 縦倍角印刷用Bmp生成処理
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private Image GetDoubleHeightImage(ar.TextBox textBox)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            # region // DEL
            //int size = 8; // ドットを細かくする為印刷フォントの8倍サイズでbmp作成する
            //Font font = new Font( textBox.Font.FontFamily, textBox.Font.SizeInPoints * size ); 

            //decimal sizeRate = 100.0m / ct_DPI;

            //string text = textBox.Text;

            //// 生成
            //Bitmap bmp = new Bitmap( (int)((decimal)font.SizeInPoints / 2.0m * (decimal)(_sjisEnc.GetByteCount( text ) + 1) * sizeRate), (int)((decimal)font.SizeInPoints * sizeRate) );
            //Graphics g = Graphics.FromImage( bmp );

            //// 描画
            //g.DrawString( text, font, new SolidBrush( textBox.ForeColor ), new PointF( 0, 0 ) );

            //// 縦倍角
            //Bitmap newBmp = new Bitmap( (int)bmp.Size.Width, (int)(bmp.Size.Height * 2.0m ) );
            //g = Graphics.FromImage( newBmp );
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //g.DrawImage( bmp, 0, 0, newBmp.Size.Width, newBmp.Size.Height );
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            int size = 8; // ドットを細かくする為印刷フォントの8倍サイズでbmp作成する

            Font font;
            if ( _customFormFlag )
            {
                // 連帳の場合は強制的にBoldにする
                font = new Font( textBox.Font.FontFamily, textBox.Font.SizeInPoints * size, textBox.Font.Style | FontStyle.Bold );
            }
            else
            {
                // 通常はそのまま
                font = new Font( textBox.Font.FontFamily, textBox.Font.SizeInPoints * size, textBox.Font.Style );
            }

            decimal sizeRate = 100.0m / ct_DPI;

            string text = textBox.Text;

            // 生成
            int bmpWidth = (int)((decimal)font.SizeInPoints / 2.0m * (decimal)(_sjisEnc.GetByteCount( text ) + 1) * sizeRate);
            int bmpHeight = (int)((decimal)font.SizeInPoints * sizeRate);
            Bitmap bmp = new Bitmap( bmpWidth, bmpHeight );
            Graphics g = Graphics.FromImage( bmp );

            // 描画
            g.DrawString( text, font, new SolidBrush( textBox.ForeColor ), new PointF( 0, 0 ) );

            // 縦倍角
            Bitmap newBmp = new Bitmap( (int)bmp.Size.Width, (int)(bmp.Size.Height * 2.0m) );
            g = Graphics.FromImage( newBmp );
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage( bmp, 0, 0, newBmp.Size.Width, newBmp.Size.Height );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            return newBmp;
        }
        /// <summary>
        /// 印刷可能テキスト取得処理
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private static string GetPrintableText( DataDynamics.ActiveReports.TextBox textBox )
        {
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //string originText = textBox.Text.Trim();
            string originText;
            if ( textBox.Text != null )
            {
                // --- UPD m.suzuki 2010/10/04 ---------->>>>>
                //originText = textBox.Text.Trim();
                originText = textBox.Text.TrimEnd();
                // --- UPD m.suzuki 2010/10/04 ----------<<<<<
            }
            else
            {
                originText = string.Empty;
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            if ( textBox.WordWrap == true && textBox.MultiLine == true )
            {
                // 複数行・文字間隔ありの場合は制御が不可能なので、文字間隔をゼロにする。
                textBox.CharacterSpacing = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD


            if ( textBox.CharacterSpacing == 0 )
            {
                //------------------------------------------------------------------------------
                // ※文字間隔がゼロならば、幅をバイト数で割るだけでＯＫ
                //------------------------------------------------------------------------------
                // 印刷可能文字数(バイト単位)
                int printableCount = (int)(((decimal)textBox.Width) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI));

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                // 複数行印刷
                if ( textBox.WordWrap == true && textBox.MultiLine == true )
                {
                    int printableLines = (int)(((decimal)textBox.Height) / ((decimal)textBox.Font.SizeInPoints / ct_DPI));
                    if ( printableLines >= 1 )
                    {
                        printableCount *= printableLines;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

                // バイト数区切り
                switch ( textBox.Alignment )
                {
                    case DataDynamics.ActiveReports.TextAlignment.Center:
                    case DataDynamics.ActiveReports.TextAlignment.Left:
                        // Left
                        originText = SubStringOfByteLeft( originText, printableCount );
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Right:
                        // Right
                        originText = SubStringOfByteRight( originText, printableCount );
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Justify:
                    default:
                        // 処理なし
                        break;
                }
            }
            else
            {
                //------------------------------------------------------------------------------
                // ※文字間隔がゼロ以外ならば、１文字ずつ検証する
                //------------------------------------------------------------------------------

                // バイト数区切り
                switch ( textBox.Alignment )
                {
                    case DataDynamics.ActiveReports.TextAlignment.Center:
                    case DataDynamics.ActiveReports.TextAlignment.Left:
                        // Left
                        {
                            # region [LEFT]
                            string resultString = string.Empty;
                            for ( int index = 1; index <= originText.Length; index++ )
                            {
                                string subString = originText.Substring( 0, index );
                                decimal checkWidth = _sjisEnc.GetByteCount( subString ) * (decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI
                                                     + (index - 1) * (decimal)textBox.CharacterSpacing / ct_DPI;
                                if ( checkWidth <= (decimal)textBox.Width )
                                {
                                    resultString = subString;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            originText = resultString.TrimEnd();
                            # endregion
                        }
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Right:
                        // Right
                        {
                            # region [RIGHT]
                            string resultString = string.Empty;
                            for ( int index = 1; index <= originText.Length; index++ )
                            {
                                string subString = originText.Substring( originText.Length - index, index );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                                if ( subString.Substring( 0, 1 ) == "," && index > 0 )
                                {
                                    subString = originText.Substring( originText.Length - index - 1, 1 )
                                                + subString.Substring( 1, subString.Length - 1 );
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
                                decimal checkWidth = _sjisEnc.GetByteCount( subString ) * (decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI
                                                     + (index - 1) * (decimal)textBox.CharacterSpacing / ct_DPI;
                                if ( checkWidth <= (decimal)textBox.Width )
                                {
                                    resultString = subString;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            originText = resultString.TrimStart();
                            # endregion
                        }
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Justify:
                    default:
                        // 処理なし
                        break;
                }
            }

            return originText;
        }
        /// <summary>
        /// 文字列　バイト数指定切り抜き（Left [12345]678→12345）
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        private static string SubStringOfByteLeft( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            // --- UPD m.suzuki 2010/10/04 ---------->>>>>
            //orgString = orgString.Trim().PadRight( byteCount ).Substring( 0, byteCount );
            orgString = orgString.TrimEnd().PadRight( byteCount ).Substring( 0, byteCount );
            // --- UPD m.suzuki 2010/10/04 ----------<<<<<

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // 「文字数」を減らす
                resultString = orgString.Substring( 0, i );

                // バイト数を取得して判定
                count = _sjisEnc.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }
            return resultString.TrimEnd();
        }
        /// <summary>
        /// 文字列　バイト数指定切り抜き（Right 123[45678]→45678）
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        private static string SubStringOfByteRight( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //// あらかじめ「文字数」を指定して切り抜いておく
            //// (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            //orgString = orgString.Trim().PadLeft( byteCount );
            //orgString = orgString.Substring( orgString.Length - byteCount, byteCount );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            // 先頭のカンマを取り除く場合を考慮して、１文字多く残しておく
            // --- UPD m.suzuki 2010/10/04 ---------->>>>>
            //orgString = orgString.Trim().PadLeft( byteCount + 1 );
            orgString = orgString.TrimEnd().PadLeft( byteCount + 1 );
            // --- UPD m.suzuki 2010/10/04 ----------<<<<<
            orgString = orgString.Substring( orgString.Length - byteCount - 1, byteCount + 1 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
                //// 「文字数」を減らす
                //resultString = orgString.Substring( orgString.Length - i, i );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                if ( orgString.Substring( orgString.Length - i, 1 ) != "," || i == 0 )
                {
                    // 「文字数」を減らす
                    resultString = orgString.Substring( orgString.Length - i, i );
                }
                else
                {
                    // カンマを除く
                    resultString = orgString.Substring( (orgString.Length - i) - 1, 1 )
                                    + orgString.Substring( (orgString.Length - i) + 1, (i - 1) );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

                // バイト数を取得して判定
                count = _sjisEnc.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }
            return resultString.TrimStart();
        }
        # endregion

        # region [レポートオブジェクトに対して差し込むイベントハンドラ関連（非自由帳票用）]
        /// <summary>
        /// セクション印刷前処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>一般帳票用の処理のみにする事で、処理時間への影響を抑える</remarks>
        private void normalListSection_BeforePrint( object sender, EventArgs e )
        {
            if ( sender == null || (sender is ar.Section) == false ) return;

            ar.Section section = (sender as ar.Section);

            foreach ( ar.ARControl control in section.Controls )
            {
                if ( control is ar.TextBox )
                {
                    try
                    {
                        ar.TextBox textBox = (control as ar.TextBox);

                        string text = textBox.Text;
                        if ( text == null )
                        {
                            text = string.Empty;
                        }

                        # region [桁あふれ対応(Text書き換え)]
                        string format = textBox.OutputFormat;
                        switch ( format )
                        {
                            # region [コード下桁対応]
                            case "0":
                                text = text.Substring( text.Length - 1, 1 );
                                break;
                            case "00":
                                text = text.Substring( text.Length - 2, 2 );
                                break;
                            case "000":
                                text = text.Substring( text.Length - 3, 3 );
                                break;
                            case "0000":
                                text = text.Substring( text.Length - 4, 4 );
                                break;
                            case "00000":
                                text = text.Substring( text.Length - 5, 5 );
                                break;
                            case "000000":
                                text = text.Substring( text.Length - 6, 6 );
                                break;
                            case "0000000":
                                text = text.Substring( text.Length - 7, 7 );
                                break;
                            case "00000000":
                                text = text.Substring( text.Length - 8, 8 );
                                break;
                            case "000000000":
                                text = text.Substring( text.Length - 9, 9 );
                                break;
                            # endregion

                            # region[一般桁あふれ対応]
                            default:
                                {
                                    text = GetPrintableText( textBox );
                                }
                                break;
                            # endregion
                        }

                        bool cancel = false;
                        # region [変更前イベント発生]
                        if ( this.BeforePrintEdit != null )
                        {
                            // イベント引数生成
                            BeforePrintEditEventArgs args = new BeforePrintEditEventArgs( section, control, text, false );

                            // イベント発生
                            this.BeforePrintEdit( sender, args );

                            // イベント結果反映
                            text = args.AdjustedText;
                            cancel = args.Cancel;
                        }
                        # endregion

                        // テキスト書き換え
                        if ( !cancel )
                        {
                            textBox.Text = text;
                        }
                        # endregion
                    }
                    catch
                    {
                        // バインド先がDBNull.Valueの項目はcatch
                    }
                }
            }
        }
        # endregion
    }

    # region [縦倍角対応リストセル]
    /// <summary>
    /// 縦倍角対応リストセル
    /// </summary>
    internal struct DoubleHeightTarget
    {
        /// <summary>データフィールド</summary>
        private string _dataField;
        /// <summary>親セクション</summary>
        private ar.Section _parentSection;
        /// <summary>対象テキストボックス</summary>
        private ar.TextBox _targetTextBox;
        /// <summary>縦倍角ピクチャ</summary>
        private ar.Picture _doubleHeightPicture;
        /// <summary>
        /// データフィールド
        /// </summary>
        public string DataField
        {
            get { return _dataField; }
            set { _dataField = value; }
        }
        /// <summary>
        /// 親セクション
        /// </summary>
        public ar.Section ParentSection
        {
            get { return _parentSection; }
            set { _parentSection = value; }
        }
        /// <summary>
        /// 対象テキストボックス
        /// </summary>
        public ar.TextBox TargetTextBox
        {
            get { return _targetTextBox; }
            set { _targetTextBox = value; }
        }
        /// <summary>
        /// 縦倍角ピクチャ
        /// </summary>
        public ar.Picture DoubleHeightPicture
        {
            get { return _doubleHeightPicture; }
            set { _doubleHeightPicture = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dataField">データフィールド</param>
        /// <param name="parentSection">親セクション</param>
        /// <param name="targetTextBox">対象テキストボックス</param>
        /// <param name="doubleHeightPicture">縦倍角ピクチャ</param>
        public DoubleHeightTarget( string dataField, ar.Section parentSection, ar.TextBox targetTextBox, ar.Picture doubleHeightPicture )
        {
            _dataField = dataField;
            _parentSection = parentSection;
            _targetTextBox = targetTextBox;
            _doubleHeightPicture = doubleHeightPicture;
        }
    }
    # endregion

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
    # region [自由帳票コントロールタグ]
    /// <summary>
    /// 自由帳票コントロールタグ
    /// </summary>
    internal struct FrePControlTag
    {
        /// <summary>自由帳票項目コード</summary>
        private int _freePrtPaperItemCd;
        /// <summary>印刷ページ区分</summary>
        private int _printPageCtrlDivCd;
        /// <summary>グループサプレス区分</summary>
        private int _groupSuppressCd;
        /// <summary>明細カラー変更区分</summary>
        private int _dtlColorChangeCd;
        /// <summary>高さ調節区分</summary>
        private int _heightAdjustDivCd;
        /// <summary>
        /// 自由帳票項目コード
        /// </summary>
        /// <remarks>1～100:ActiveReport用,101～:.NS用</remarks>
        public int FreePrtPaperItemCd
        {
            get { return _freePrtPaperItemCd; }
            set { _freePrtPaperItemCd = value; }
        }
        /// <summary>
        /// 印刷ページ区分
        /// </summary>
        public int PrintPageCtrlDivCd
        {
            get { return _printPageCtrlDivCd; }
            set { _printPageCtrlDivCd = value; }
        }
        /// <summary>
        /// グループサプレス区分
        /// </summary>
        /// <remarks>0:なし,1:あり</remarks>
        public int GroupSuppressCd
        {
            get { return _groupSuppressCd; }
            set { _groupSuppressCd = value; }
        }
        /// <summary>
        /// 明細カラー変更区分
        /// </summary>
        /// <remarks>0:非対象,1:対象</remarks>
        public int DtlColorChangeCd
        {
            get { return _dtlColorChangeCd; }
            set { _dtlColorChangeCd = value; }
        }
        /// <summary>
        /// 高さ調節区分
        /// </summary>
        /// <remarks>0:非対象,1:対象</remarks>
        public int HeightAdjustDivCd
        {
            get { return _heightAdjustDivCd; }
            set { _heightAdjustDivCd = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="freePrtPaperItemCd">自由帳票項目コード</param>
        /// <param name="printPageCtrlDivCd">印刷ページ区分</param>
        /// <param name="groupSuppressCd">グループサプレス区分</param>
        /// <param name="dtlColorChangeCd">明細カラー変更区分</param>
        /// <param name="heightAdjustDivCd">高さ調節区分</param>
        public FrePControlTag( int freePrtPaperItemCd, int printPageCtrlDivCd, int groupSuppressCd, int dtlColorChangeCd, int heightAdjustDivCd )
        {
            _freePrtPaperItemCd = freePrtPaperItemCd;
            _printPageCtrlDivCd = printPageCtrlDivCd;
            _groupSuppressCd = groupSuppressCd;
            _dtlColorChangeCd = dtlColorChangeCd;
            _heightAdjustDivCd = heightAdjustDivCd;
        }
        /// <summary>
        /// コンストラクタ(Tagから生成)
        /// </summary>
        /// <param name="tag"></param>
        public FrePControlTag( object tag )
        {
            // 初期化
            _freePrtPaperItemCd = 0;
            _printPageCtrlDivCd = 0;
            _groupSuppressCd = 0;
            _dtlColorChangeCd = 0;
            _heightAdjustDivCd = 0;

            if ( tag is string )
            {
                string[] tagValues = (tag as string).Split( ',' );

                _freePrtPaperItemCd = ToInt( tagValues, 0 );
                _printPageCtrlDivCd = ToInt( tagValues, 1 );
                _groupSuppressCd = ToInt( tagValues, 2 );
                _dtlColorChangeCd = ToInt( tagValues, 3 );
                _heightAdjustDivCd = ToInt( tagValues, 4 );
            }
            else
            {
                // 無効な設定
            }
        }
        /// <summary>
        /// 数値変換(string配列,index指定)
        /// </summary>
        /// <param name="para"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int ToInt( string[] para, int index )
        {
            if ( (para != null) && (para.Length > index) )
            {
                try
                {
                    return Int32.Parse( para[index] );
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
    # endregion

    # region [コントロール比較クラス（ソート用）]
    /// <summary>
    /// コントロール比較クラス（ソート用）
    /// </summary>
    internal class ARControlComparer : IComparer<ar.ARControl>
    {
        /// <summary>
        /// 比較処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare( ar.ARControl x, ar.ARControl y )
        {
            int result;

            // 位置(Y)
            result = x.Top.CompareTo( y.Top );
            if ( result != 0 ) return result;

            // 位置(X)
            result = x.Left.CompareTo( y.Left );

            return result;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
}
