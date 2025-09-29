//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 帳票印刷共通部品クラス
// プログラム概要   : 帳票印刷共通部品クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 請求書発行(電子帳簿連携)新規作成
//----------------------------------------------------------------------------//
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
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
    /// </remarks>
	public class PMCMN02001CA
	{
        // DotPerInch
        private const decimal ct_DPI = 72;

        // staticインスタンス
        private static PMCMN02001CA _instance;
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
        // ＱＲコード印刷サイズ一覧
        private Dictionary<string, float> _qrCodeSizeDic;
        // ＱＲコード印刷有無フラグ
        private bool _qrCodeVisible;
        // サブレポート対象リスト(参照元)
        private List<string> _subReportTargetList;
        // サブレポートディクショナリ(参照先)
        private Dictionary<string, ar.ActiveReport3> _subReportDic;

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
            set 
            {
                // Listが書き変わる時、Dicもクリアする。
                _doubleHeightTargetdic = null;

                // set
                _doubleHeightTargetList = value;
            }
        }
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
        # endregion

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
        # endregion

        # region [BeforePrintEditEventArgs]
        /// <summary>
        /// BeforePrintEditEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note        : BeforePrintEditEventArgs</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br></br>
        /// </remarks>
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

        # region [BeforePrintEditLineEventArgs]
        /// <summary>
        /// BeforePrintEditLineEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note        : BeforePrintEditLineEventArgs</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br></br>
        /// </remarks>
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

        # region [イベントデリゲート定義]
        /// <summary>
        /// Edit印刷前イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BeforePrintEditHandler( object sender, BeforePrintEditEventArgs e );

        /// <summary>
        /// EditLine印刷前イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BeforePrintEditLineHandler( object sender, BeforePrintEditLineEventArgs e );
        # endregion

        # region [イベント]
        /// <summary>
        /// Edit印字前イベント
        /// </summary>
        public event BeforePrintEditHandler BeforePrintEdit;

        /// <summary>
        /// EditLine印字前イベント
        /// </summary>
        public event BeforePrintEditLineHandler BeforePrintEditLine;
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// privateコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : コンストラクタ生成</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private PMCMN02001CA()
        {
            this.InitializeCancel = false;
            this.DoubleHeightTargetList = new List<string>();
            this.GroupSuppressDiv = GroupSuppressDivState.None;
            this.GroupSuppressMode = GroupSuppressModeState.Multi;
            this.GroupingItemList = new List<string>();
            this._prevGroupingItemValueDic = new Dictionary<string, string>();
            this._qrCodeSizeDic = new Dictionary<string, float>();
            this._qrCodeVisible = true;
            this._subReportTargetList = new List<string>();
            this._subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
        }

        /// <summary>
        /// static コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : コンストラクタ生成</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        static PMCMN02001CA()
        {
            // ↓staticメソッドで使用するstaticフィールドの初期化
            _sjisEnc = Encoding.GetEncoding( "Shift_JIS" );
        }
        # endregion

        # region [publicメソッド]
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>インスタンス</returns>
        /// <remarks>
        /// <br>Note        : インスタンス取得処理処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static PMCMN02001CA GetInstance()
        {
            if ( _instance == null )
            {
                _instance = new PMCMN02001CA();
            }
            _instance.Clear();
            return _instance;
        }

        /// <summary>
        /// 帳票設定処理
        /// </summary>
        /// <param name="report">レポート</param>
        /// <remarks>
        /// <br>Note        : 帳票設定処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public void SetReportProps( ref ar.ActiveReport3 report )
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
            // グループサプレスする場合はサプレス解除用にイベントハンドラ登録する
            if ( GroupSuppressDiv != GroupSuppressDivState.None )
            {
                report.PageEnd += new EventHandler( report_PageEnd );
            }
        }

        /// <summary>
        /// 帳票設定処理(ALL)
        /// </summary>
        /// <param name="report">レポート</param>
        /// <param name="kind">レポートプロパティ設定種別</param>
        /// <remarks>
        /// <br>Note        : 帳票設定処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
        /// <param name="report">レポート</param>
        /// <remarks>
        /// <br>Note        : 一般帳票に必要な機能だけに限定し、処理速度への影響を抑えます。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SetReportPropsForNormalList( ref DataDynamics.ActiveReports.ActiveReport3 report )
        {
            // 全てのセクションに対して
            foreach ( ar.Section section in report.Sections )
            {
                // 印刷前イベントハンドラを登録する。
                section.BeforePrint += new EventHandler( normalListSection_BeforePrint );
            }
        }

        /// <summary>
        /// 内部保持情報のクリア
        /// </summary>
        /// <remarks>
        /// <br>Note        : 内部保持情報のクリア処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public void Clear()
        {
            _prevGroupingItemValueDic = null;
            _arControlListDic = null;
        }

        /// <summary>
        /// 印刷可能バイト数の取得（外部公開用）
        /// </summary>
        /// <param name="textBox">コントロール</param>
        /// <param name="minCount">最小カウント</param>
        /// <param name="maxCount">最大カウント</param>
        /// <remarks>
        /// <br>Note        : 印刷可能バイト数の取得処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 印刷可能バイト数の取得処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        void report_ReportStart( object sender, EventArgs e )
        {
            // 対象ディクショナリ生成
            if ( _doubleHeightTargetdic == null )
            {
                _doubleHeightTargetdic = new Dictionary<string, DoubleHeightTarget>();
            }
            _prevGroupingItemValueDic = new Dictionary<string, string>();
            // サブレポート対応用リスト初期化
            List<ar.Label> subReportLabelList = new List<ar.Label>();
            List<ar.SubReport> subReportList = new List<ar.SubReport>();

            try
            {
                // 全てのセクションに対して処理
                foreach ( ar.Section section in (sender as ar.ActiveReport3).Sections )
                {
                    # region [セクションに対する操作]
                    if ( _arControlListDic == null )
                    {
                        _arControlListDic = new Dictionary<string, List<DataDynamics.ActiveReports.ARControl>>();
                    }
                    // セクションにGUIDを付与する
                    section.Tag = Guid.NewGuid();
                    string sectionKey = section.Tag.ToString();
                    _arControlListDic.Add( sectionKey, new List<DataDynamics.ActiveReports.ARControl>() );

                    foreach ( ar.ARControl control in section.Controls )
                    {
                        # region [セクション内のコントロールへの操作]
                        if ( control is ar.TextBox )
                        {
                            // 共通
                            _arControlListDic[sectionKey].Add( control );

                            // データフィールド未設定ならば迂回
                            if ( string.IsNullOrEmpty( control.DataField ) ) continue;

                            // 縦倍角対応
                            # region [縦倍角対応]
                            if ( _doubleHeightTargetList.Contains( control.DataField.ToUpper() ) )
                            {
                                string doubleHeightTargetKey = CreateDoubleHeightTargetKey( sectionKey, control.Name );
                                if ( !_doubleHeightTargetdic.ContainsKey( doubleHeightTargetKey ) )
                                {
                                    // 縦倍角対応するための情報を生成して退避する
                                    DoubleHeightTarget target = new DoubleHeightTarget();

                                    target.DataField = control.DataField;
                                    target.ParentSection = section;
                                    target.TargetTextBox = (ar.TextBox)control;
                                    
                                    target.DoubleHeightPicture = new DataDynamics.ActiveReports.Picture();
                                    target.DoubleHeightPicture.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft;
                                    target.DoubleHeightPicture.Location = target.TargetTextBox.Location;
                                    target.DoubleHeightPicture.Visible = false;
                                    
                                    target.DoubleHeightPicture.Size = target.TargetTextBox.Size;
                                    _doubleHeightTargetdic.Add( doubleHeightTargetKey, target );
                                }
                            }
                            # endregion

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
                        }
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
                        else if (control is ar.Line)
                        {
                            _arControlListDic[sectionKey].Add(control);
                        }
                        # endregion
                    }

                    // セクション別のリストをソート
                    if ( GroupSuppressMode != GroupSuppressModeState.Single )
                    {
                        _arControlListDic[sectionKey].Sort( new ARControlComparer() );
                    }
                    # endregion
                }

                # region [コレクションに対して一括処理]
                // 縦倍角対応
                foreach ( DoubleHeightTarget target in _doubleHeightTargetdic.Values )
                {
                    target.ParentSection.Controls.Add( target.DoubleHeightPicture );
                    // 最背面へと移す(PDF出力時に背景色=透明にならない為)
                    target.DoubleHeightPicture.SendToBack();
                }
                // グループサプレス対応
                foreach ( string groupingItemName in _groupingItemList )
                {
                    // サプレス用前回値退避ディクショナリに追加
                    _prevGroupingItemValueDic.Add( groupingItemName, string.Empty );
                }
                // サブレポートへ置き換え
                for ( int index = 0; index < subReportLabelList.Count; index++ )
                {
                    ar.Section section = (subReportLabelList[index].Parent as ar.Section);
                    section.Controls.Add( subReportList[index] );
                    section.Controls.Remove( subReportLabelList[index] );
                }
                # endregion
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 縦倍角項目キー生成処理
        /// </summary>
        /// <param name="sectionKey">印刷セクションキー</param>
        /// <param name="controlName">コントロール項目名</param>
        /// <returns>縦倍角項目キー</returns>
        /// <remarks>
        /// <br>Note        : 帳票設定処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string CreateDoubleHeightTargetKey( string sectionKey, string controlName )
        {
            return string.Format( "{0}-{1}", sectionKey, controlName );
        }
        /// <summary>
        /// 帳票セクション印刷前イベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 帳票セクション印刷前イベント処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void section_BeforePrint( object sender, EventArgs e )
        {
            if ( sender == null || (sender is ar.Section) == false ) return;

            ar.Section section = (sender as ar.Section);

            string sectionKey = (sender as ar.Section).Tag.ToString();
            if (!_arControlListDic.ContainsKey(sectionKey)) return;

            bool prevItemSuppress = true;
            foreach (ar.ARControl control in _arControlListDic[sectionKey])
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
                            string doubleHeightTargetKey = CreateDoubleHeightTargetKey( sectionKey, control.Name );
                            if ( _doubleHeightTargetdic != null && _doubleHeightTargetdic.ContainsKey( doubleHeightTargetKey ) )
                            {
                                DoubleHeightTarget target = _doubleHeightTargetdic[doubleHeightTargetKey];

                                if ( !string.IsNullOrEmpty( target.TargetTextBox.Text ) )
                                {
                                    target.DoubleHeightPicture.Image = GetDoubleHeightImage( target.TargetTextBox );
                                    target.DoubleHeightPicture.PictureAlignment = GetPictureAlignment( target.TargetTextBox );
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
            }
        }

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
        /// <remarks>
        /// <br>Note        : グループサプレスチェック処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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

        /// <summary>
        /// イメージ配置位置取得（ベースになるテキストボックスの配置位置から変換）
        /// </summary>
        /// <param name="contrl">コントロール</param>
        /// <returns>イメージ配置位置</returns>
        /// <remarks>
        /// <br>Note        : イメージ配置位置取得処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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

        /// <summary>
        /// 縦倍角印刷用Bmp生成処理
        /// </summary>
        /// <param name="textBox">コントロール</param>
        /// <returns>イメージ</returns>
        /// <remarks>
        /// <br>Note        : 縦倍角印刷用Bmp生成処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private Image GetDoubleHeightImage(ar.TextBox textBox)
        {
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

            return newBmp;
        }

        /// <summary>
        /// 印刷可能テキスト取得処理
        /// </summary>
        /// <param name="textBox">コントロール</param>
        /// <returns>テキスト値</returns>
        /// <remarks>
        /// <br>Note        : 印刷可能テキスト取得処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetPrintableText( DataDynamics.ActiveReports.TextBox textBox )
        {
            string originText;
            if ( textBox.Text != null )
            {
                originText = textBox.Text.TrimEnd();
            }
            else
            {
                originText = string.Empty;
            }
            
            if ( textBox.WordWrap == true && textBox.MultiLine == true )
            {
                // 複数行・文字間隔ありの場合は制御が不可能なので、文字間隔をゼロにする。
                textBox.CharacterSpacing = 0;
            }

            if ( textBox.CharacterSpacing == 0 )
            {
                //------------------------------------------------------------------------------
                // ※文字間隔がゼロならば、幅をバイト数で割るだけでＯＫ
                //------------------------------------------------------------------------------
                // 印刷可能文字数(バイト単位)
                int printableCount = (int)(((decimal)textBox.Width) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI));

                // 複数行印刷
                if ( textBox.WordWrap == true && textBox.MultiLine == true )
                {
                    int printableLines = (int)(((decimal)textBox.Height) / ((decimal)textBox.Font.SizeInPoints / ct_DPI));
                    if ( printableLines >= 1 )
                    {
                        printableCount *= printableLines;
                    }
                }

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
                                if ( subString.Substring( 0, 1 ) == "," && index > 0 )
                                {
                                    subString = originText.Substring( originText.Length - index - 1, 1 )
                                                + subString.Substring( 1, subString.Length - 1 );
                                }
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
        /// <remarks>
        /// <br>Note        : 文字列　バイト数指定切り抜き処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string SubStringOfByteLeft( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.TrimEnd().PadRight( byteCount ).Substring( 0, byteCount );

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
        /// <remarks>
        /// <br>Note        : 文字列　バイト数指定切り抜き処理を行います。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string SubStringOfByteRight( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // 先頭のカンマを取り除く場合を考慮して、１文字多く残しておく
            orgString = orgString.TrimEnd().PadLeft( byteCount + 1 );
            orgString = orgString.Substring( orgString.Length - byteCount - 1, byteCount + 1 );

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
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
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 一般帳票用の処理のみにする事で、処理時間への影響を抑える。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
    /// <remarks>
    /// <br>Note        : 横倍角対応リストセル。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
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
        /// <param name="targetControl">対象テキストボックス</param>
        /// <param name="doubleWidthPicture">横倍角ピクチャ</param>
        /// <remarks>
        /// <br>Note        : コンストラクタ生成。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public DoubleHeightTarget( string dataField, ar.Section parentSection, ar.TextBox targetTextBox, ar.Picture doubleHeightPicture )
        {
            _dataField = dataField;
            _parentSection = parentSection;
            _targetTextBox = targetTextBox;
            _doubleHeightPicture = doubleHeightPicture;
        }
    }
    # endregion

    # region [自由帳票コントロールタグ]
    /// <summary>
    /// 自由帳票コントロールタグ
    /// </summary>
    /// <remarks>
    /// <br>Note        : 自由帳票コントロールタグ。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
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
        /// <remarks>
        /// <br>Note        : コンストラクタ生成。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
        /// <param name="tag">タグ</param>
        /// <remarks>
        /// <br>Note        : コンストラクタ(Tagから生成)生成。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
        /// <param name="para">パラメータ</param>
        /// <param name="index">インデックス</param>
        /// <returns>変換後数値</returns>
        /// <remarks>
        /// <br>Note        : コンストラクタ(Tagから生成)生成。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
    /// <remarks>
    /// <br>Note        : コントロール比較クラス（ソート用）。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
    internal class ARControlComparer : IComparer<ar.ARControl>
    {
        /// <summary>
        /// 比較処理
        /// </summary>
        /// <param name="x">比較元</param>
        /// <param name="y">比較先</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note        : コントロール比較クラス（ソート用）。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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
}
