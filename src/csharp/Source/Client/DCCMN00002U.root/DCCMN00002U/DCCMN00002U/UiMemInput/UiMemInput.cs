using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// カスタマイズReadイベントデリゲート
    /// </summary>
    /// <param name="targetControls"></param>
    /// <param name="customizeData"></param>
    //public delegate void CustomizeReadEventHandler( List<Control> targetControls, List<string> customizeData );
    public delegate void CustomizeReadEventHandler( Control[] targetControls, string[] customizeData );
    /// <summary>
    /// カスタマイズWriteイベントデリゲート
    /// </summary>
    /// <param name="targetControls"></param>
    /// <param name="customizeData"></param>
    //public delegate void CustomizeWriteEventHandler( List<Control> targetControls, out List<string> customizeData );
    public delegate void CustomizeWriteEventHandler( Control[] targetControls, out string[] customizeData );

    # region ■ UI入力保存コンポーネント ■
    /// <summary>
    /// ＵＩ入力保存コンポーネント
    /// </summary>
    /// <remarks>
    /// Note       : ＵＩの入力内容を保存し、次回起動時に復元する為のコンポーネントです。<br />
    /// Programmer : 22018 鈴木 正臣<br />
    /// Date       : 2008.04.21<br />
    /// <br />
    /// Update Note: 2011/08/02 李占川 NSユーザー改良要望一覧連番939と1022<br />
    /// </remarks>    
    [ToolboxBitmap( typeof( UiMemInput ), "UiMemInput.UiMemInput.bmp" ),
     Serializable]
    public partial class UiMemInput : TbsBaseComponent
    {
        # region [private fields]
        /// <summary>OwnerForm名称</summary>
        private string _ownerFormName;
        /// <summary>UI入力保持ファイルアクセス</summary>
        private UiMemFileAcs _uiMemFileAcs;
        /// <summary>対象コントロールリスト</summary>
        private List<Control> _targetControls;
        /// <summary>終了時書き込みありフラグ</summary>
        private bool _writeOnClose;
        /// <summary>開始時読み込みありフラグ</summary>
        private bool _readOnLoad;
        /// <summary>オプションコード</summary>
        private string _optionCode;
        ///// <summary>OwnerUserControlのLoad処理済みフラグ</summary>
        //private bool _ownerUserControlLoaded;
        # endregion

        # region [public propaties]
        /// <summary>
        /// 対象コントロールリスト
        /// </summary>
        [Category( "動作" ),
         Description( "対象コントロールのリストを取得・設定します。" )]
        public List<Control> TargetControls
        {
            //get { return _targetControls; }
            set 
            { 
                _targetControls = value;

                //-------------------------------------------------------
                // ※以下の処理は一見意味が無いように見えますが、重要です。
                //   OwnerFormのソースに記述されているLoad処理よりも後に
                //   UiMemInputのLoad処理が行われるようにします。
                //-------------------------------------------------------
                if ( OwnerForm is Form )
                {
                    (OwnerForm as Form).Load -= this.OwnerFormOnLoad;
                    (OwnerForm as Form).Load += this.OwnerFormOnLoad;
                }
                else if ( OwnerForm is UserControl )
                {
                    (OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                    (OwnerForm as UserControl).Load += this.OwnerFormOnLoad;
                }
            }
        }
        /// <summary>
        /// 終了時書き込みフラグ
        /// </summary>
        [Category( "動作" ),
         DefaultValue(true),
         Description( "終了時書き込みフラグを取得・設定します。" )]
        public bool WriteOnClose
        {
            get { return _writeOnClose; }
            set { _writeOnClose = value; }
        }
        /// <summary>
        /// 開始時読み込みフラグ
        /// </summary>
        [Category( "動作" ),
         DefaultValue( true ),
         Description( "開始時読み込みフラグを取得・設定します。" )]
        public bool ReadOnLoad
        {
            get { return _readOnLoad; }
            set { _readOnLoad = value; }
        }
        /// <summary>
        /// オプションコード
        /// </summary>
        [Category( "動作" ),
         DefaultValue( "" ),
         Description( "OwnerFormの設定を複数保持する場合のKeyとなるコードを取得・設定します。" )]
        public string OptionCode
        {
            get 
            {
                if ( _optionCode == null )
                {
                    _optionCode = string.Empty;
                }
                return _optionCode; 
            }
            set { _optionCode = value; }
        }
        # endregion


        # region [Constructor]
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UiMemInput()
        {
            InitializeComponent();

            _ownerFormName = string.Empty;
            _uiMemFileAcs = new UiMemFileAcs();

            _optionCode = string.Empty;
            _targetControls = new List<Control>();
            //this.TargetControls = new List<Control>();
            this.WriteOnClose = true;
            this.ReadOnLoad = true;
            //_ownerUserControlLoaded = false;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public UiMemInput( IContainer container )
        {
            container.Add( this );
            InitializeComponent();

            _ownerFormName = string.Empty;
            _uiMemFileAcs = new UiMemFileAcs();

            _optionCode = string.Empty;
            _targetControls = new List<Control>();
            //this.TargetControls = new List<Control>();
            this.WriteOnClose = true;
            this.ReadOnLoad = true;
            //_ownerUserControlLoaded = false;
        }
        # endregion

        # region [event]
        /// <summary>
        /// カスタマイズReadイベント
        /// </summary>
        [Category( "動作" ),
         Description( "プログラム固有のデータReadを実装します。" )]
        public event CustomizeReadEventHandler CustomizeRead;
        /// <summary>
        /// カスタマイズWriteイベント
        /// </summary>
        [Category( "動作" ),
         Description( "プログラム固有のデータWriteを実装します。" )]
        public event CustomizeWriteEventHandler CustomizeWrite;
        # endregion

        # region [public propaties]
        /// <summary>
        /// 本コンポーネントの処理対象となるフォームを取得又は設定します。
        /// </summary>
        public override ISynchronizeInvoke OwnerForm
        {
            get { return base.OwnerForm; }

            set
            {
                if ( base.OwnerForm != value )
                {
                    //----------------------------------------------------------
                    // 変更前のOwnerFormに対するイベントデリゲートを削除する
                    //----------------------------------------------------------
                    if ( base.OwnerForm is ContainerControl )
                    {
                        // イベントデリゲートを削除する
                        if ( base.OwnerForm is Form )
                        {
                            (base.OwnerForm as Form).Load -= this.OwnerFormOnLoad;
                            (base.OwnerForm as Form).FormClosing -= this.OwnerFormOnFormClosing;
                        }
                        if ( base.OwnerForm is UserControl )
                        {
                            (base.OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                            //(base.OwnerForm as UserControl).VisibleChanged -= this.OwnerFormOnVisibleChanged;
                        }
                    }

                    //----------------------------------------------------------
                    // 変更後のOwnerFormに対する設定
                    //----------------------------------------------------------
                    if ( value is ContainerControl || value is Control )
                    {
                        if ( value is Control )
                        {
                            // コントロールの場合は配置されているフォームを探して設定する
                            Form form = (value as Control).FindForm();

                            if ( form != null )
                            {
                                base.OwnerForm = form;
                            }
                            else
                            {
                                base.OwnerForm = value;
                            }
                        }
                        else
                        {
                            // フォームの場合はそのまま設定する
                            base.OwnerForm = value;
                        }

                        if ( base.OwnerForm is ContainerControl )
                        {
                            if ( base.OwnerForm is Form )
                            {
                                (base.OwnerForm as Form).Load += this.OwnerFormOnLoad;
                                (base.OwnerForm as Form).FormClosing += this.OwnerFormOnFormClosing;
                            }

                            if ( base.OwnerForm is UserControl )
                            {
                                (base.OwnerForm as UserControl).Load += this.OwnerFormOnLoad;
                                //(base.OwnerForm as UserControl).VisibleChanged += this.OwnerFormOnVisibleChanged;
                            }
                        }
                    }
                    else
                    {
                        base.OwnerForm = value;
                    }
                }
            }
        }
        # endregion

        # region [public methods]
        /// <summary>
        /// 入力保存データ読み込み
        /// </summary>
        public void ReadMemInput()
        {
            //_ownerUserControlLoaded = true;

            //----------------------------------------------------------------
            // 読み込み準備
            //----------------------------------------------------------------

            // OwnerFormを持つアセンブリ名称を取得
            string asmName = Path.GetFileNameWithoutExtension( this.OwnerForm.GetType().Assembly.GetName().Name );
            // OwnerFormの名称を取得
            string ownerName = this.OwnerForm.GetType().Name;

            //----------------------------------------------------------------
            // 前回入力情報の取得
            //----------------------------------------------------------------
            UiMemInputDataForm memForm;

            if ( _uiMemFileAcs.ReadMemInput( out memForm, asmName, ownerName, this.OptionCode ) != 0 )
            {
                // 設定がなければ処理しない
                return;
            }
            // ディクショナリ生成
            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            foreach ( UiMemInputData data in memForm.UiMemInputDatas )
            {
                if ( !dataDic.ContainsKey( data.TargetName ) )
                {
                    dataDic.Add( data.TargetName, data.InputData );
                }
            }

            //----------------------------------------------------------------
            // 各コントロールに適用 (Load)
            //----------------------------------------------------------------
            foreach ( Control control in _targetControls )
            {
                if ( !dataDic.ContainsKey( control.Name ) ) continue;

                Type type = control.GetType();

                # region [Type毎の前回入力値の適用]
                if ( IsClassOrSubClass( type, typeof( TDateEdit ) ) )
                {
                    //------------------------------------------------------
                    // 日付Edit
                    //------------------------------------------------------
                    DateTime dateTime = GetDateTime( dataDic[control.Name] );
                    if ( dateTime != DateTime.MinValue )
                    {
                        (control as TDateEdit).SetDateTime( dateTime );
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( TComboEditor ) ) )
                {
                    //------------------------------------------------------
                    // コンボボックス
                    //------------------------------------------------------
                    int index = GetInt( dataDic[control.Name], -1 );
                    if ( 0 <= index && index < (control as TComboEditor).Items.Count )
                    {
                        (control as TComboEditor).SelectedIndex = index;
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( TNedit ) ) )
                {
                    //------------------------------------------------------
                    // 数値Edit
                    //------------------------------------------------------
                    int number;
                    if ( GetInt( dataDic[control.Name], 0, out number ) )
                    {
                        (control as TNedit).SetInt( number );
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( TEdit ) ) )
                {
                    //------------------------------------------------------
                    // 文字列Edit
                    //------------------------------------------------------
                    if ( dataDic.ContainsKey( control.Name ) )
                    {
                        control.Text = dataDic[control.Name];
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.UltraWinEditors.UltraOptionSet ) ) )
                {
                    //------------------------------------------------------
                    // ラジオボタングループ
                    //------------------------------------------------------
                    Infragistics.Win.UltraWinEditors.UltraOptionSet optSet = (control as Infragistics.Win.UltraWinEditors.UltraOptionSet);

                    int number;
                    if ( GetInt( dataDic[control.Name], 0, out number ) && optSet.ValueList.FindByDataValue( number ) != null )
                    {
                        optSet.Value = number;
                    }
                    else
                    {
                        if ( optSet.ValueList.FindByDataValue( dataDic[control.Name] ) != null )
                        {
                            optSet.Value = dataDic[control.Name];
                        }
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( CheckedListBox ) ) )
                {
                    //------------------------------------------------------
                    // チェックリストボックス
                    //------------------------------------------------------
                    List<int> checkdIndexs = GetNumbersFromCSV( dataDic[control.Name] );

                    if ( checkdIndexs.Count > 0 )
                    {
                        for ( int index = 0; index < (control as CheckedListBox).Items.Count; index++ )
                        {
                            if ( checkdIndexs.Contains( index ) )
                            {
                                (control as CheckedListBox).SetItemChecked( index, true );
                            }
                            else
                            {
                                (control as CheckedListBox).SetItemChecked( index, false );
                            }
                        }
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( RadioButton ) ) )
                {
                    //------------------------------------------------------
                    // ラジオボタン
                    //------------------------------------------------------

                    if ( dataDic[control.Name].ToUpper() == "TRUE" )
                    {
                        (control as RadioButton).Checked = true;
                    }
                    else if ( dataDic[control.Name].ToUpper() == "FALSE" )
                    {
                        (control as RadioButton).Checked = false;
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( CheckBox ) ) )
                {
                    //------------------------------------------------------
                    // チェックボックス
                    //------------------------------------------------------
                    if ( dataDic[control.Name].ToUpper() == "TRUE" )
                    {
                        (control as CheckBox).Checked = true;
                    }
                    else if ( dataDic[control.Name].ToUpper() == "FALSE" )
                    {
                        (control as CheckBox).Checked = false;
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.Misc.UltraLabel ) ) )
                {
                    //------------------------------------------------------
                    // ラベル
                    //------------------------------------------------------
                    (control as Infragistics.Win.Misc.UltraLabel).Text = dataDic[control.Name];
                }
                else if ( IsClassOrSubClass( type, typeof( Label ) ) )
                {
                    //------------------------------------------------------
                    // ラベル
                    //------------------------------------------------------
                    (control as Label).Text = dataDic[control.Name];
                }
                # endregion
            }

            //----------------------------------------------------------------
            // カスタマイズReadイベント
            //----------------------------------------------------------------
            if ( this.CustomizeRead != null )
            {
                CustomizeRead( _targetControls.ToArray(), memForm.CustomizeData.ToArray() );
            }
        }
        /// <summary>
        /// 入力保存データ書き込み
        /// </summary>
        public void WriteMemInput()
        {
            //----------------------------------------------------------------
            // 読み込み準備
            //----------------------------------------------------------------

            // OwnerFormを持つアセンブリ名称を取得
            string asmName = Path.GetFileNameWithoutExtension( this.OwnerForm.GetType().Assembly.GetName().Name );
            // OwnerFormの名称を取得
            string ownerName = this.OwnerForm.GetType().Name;

            //----------------------------------------------------------------
            // 前回入力情報の取得
            //----------------------------------------------------------------
            UiMemInputDataForm memForm;

            if ( _uiMemFileAcs.ReadMemInput( out memForm, asmName, ownerName, this.OptionCode ) != 0 )
            {
                // 設定がなければ新規作成
                memForm = new UiMemInputDataForm();
                memForm.FormName = ownerName;
                memForm.OptionCode = this.OptionCode;
                //memForm.UiMemInputDatas = new List<UiMemInputData>();   // DEL 2011/08/02
            }
            memForm.UiMemInputDatas = new List<UiMemInputData>();   // ADD 2011/08/02

            //----------------------------------------------------------------
            // 各コントロールの保存 (FormClosing)
            //----------------------------------------------------------------
            foreach ( Control control in _targetControls )
            {
                Type type = control.GetType();
                string inputData = string.Empty;

                # region [Type毎の今回入力値の保存]
                if ( IsClassOrSubClass( type, typeof( TDateEdit ) ) )
                {
                    //------------------------------------------------------
                    // 日付Edit
                    //------------------------------------------------------
                    inputData = (control as TDateEdit).GetLongDate().ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( TComboEditor ) ) )
                {
                    //------------------------------------------------------
                    // コンボボックス
                    //------------------------------------------------------
                    inputData = (control as TComboEditor).SelectedIndex.ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( TNedit ) ) )
                {
                    //------------------------------------------------------
                    // 数値Edit
                    //------------------------------------------------------
                    inputData = (control as TNedit).GetInt().ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( TEdit ) ) )
                {
                    //------------------------------------------------------
                    // 文字列Edit
                    //------------------------------------------------------
                    inputData = (control as TEdit).Text;
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.UltraWinEditors.UltraOptionSet ) ) )
                {
                    //------------------------------------------------------
                    // ラジオボックスグループ
                    //------------------------------------------------------
                    if ( (control as Infragistics.Win.UltraWinEditors.UltraOptionSet).Value != null )
                    {
                        inputData = (control as Infragistics.Win.UltraWinEditors.UltraOptionSet).Value.ToString();
                    }
                }
                else if ( IsClassOrSubClass( type, typeof( CheckedListBox ) ) )
                {
                    //------------------------------------------------------
                    // チェックリストボックス
                    //------------------------------------------------------
                    string checkedIndexs = string.Empty;

                    CheckedListBox chkListBox = (control as CheckedListBox);
                    for ( int index = 0; index < chkListBox.Items.Count; index++ )
                    {
                        if ( chkListBox.GetItemChecked( index ) )
                        {
                            if ( checkedIndexs != string.Empty )
                            {
                                checkedIndexs += ",";
                            }
                            checkedIndexs += index.ToString();
                        }
                    }
                    inputData = checkedIndexs;
                }
                else if ( IsClassOrSubClass( type, typeof( RadioButton ) ) )
                {
                    //------------------------------------------------------
                    // ラジオボタン
                    //------------------------------------------------------
                    inputData = (control as RadioButton).Checked.ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( CheckBox ) ) )
                {
                    //------------------------------------------------------
                    // チェックボックス
                    //------------------------------------------------------
                    inputData = (control as CheckBox).Checked.ToString();
                }
                else if ( IsClassOrSubClass( type, typeof( Infragistics.Win.Misc.UltraLabel ) ) )
                {
                    //------------------------------------------------------
                    // ウルトララベル
                    //------------------------------------------------------
                    inputData = (control as Infragistics.Win.Misc.UltraLabel).Text;
                }
                else if ( IsClassOrSubClass( type, typeof( Label ) ) )
                {
                    //------------------------------------------------------
                    // ラベル
                    //------------------------------------------------------
                    inputData = (control as Label).Text;
                }
                # endregion

                // セット
                memForm.UiMemInputDatas.Add( new UiMemInputData( control.Name, inputData ) );
            }

            //----------------------------------------------------------------
            // カスタマイズWriteイベント
            //----------------------------------------------------------------
            if ( this.CustomizeWrite != null )
            {
                string[] customizeData;
                CustomizeWrite( _targetControls.ToArray(), out customizeData );
                memForm.CustomizeData = new List<string>( customizeData );
            }

            // 今回入力情報の保存
            _uiMemFileAcs.WriteMemInput( memForm, asmName );
        }

        # endregion

        # region [private methods]
        /// <summary>
        /// 型一致判定処理
        /// </summary>
        /// <param name="type">判定する型</param>
        /// <param name="targetType">指定型</param>
        /// <returns>targetTypeまたはそのサブクラスならばtrue</returns>
        private bool IsClassOrSubClass( Type type, Type targetType )
        {
            return (type == targetType || type.IsSubclassOf( targetType ));
        }
        /// <summary>
        /// CSV数値取得
        /// </summary>
        /// <param name="dataText"></param>
        /// <returns></returns>
        private List<int> GetNumbersFromCSV( string dataText )
        {
            List<int> numbers = new List<int>();
            string[] splitStrings = dataText.Split( ',' );

            for ( int index = 0; index < splitStrings.Length; index++ )
            {
                int number;
                if ( GetInt( splitStrings[index], 0, out number ) )
                {
                    numbers.Add( number );
                }
            }
            return numbers;
        }
        /// <summary>
        /// 日付取得処理
        /// </summary>
        /// <param name="dataText"></param>
        /// <returns></returns>
        private DateTime GetDateTime( string dataText )
        {
            int longDate = GetInt( dataText, 0 );
            try
            {
                return new DateTime( longDate / 10000, longDate / 100 % 100, longDate % 100 );
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// 数値取得処理
        /// </summary>
        /// <param name="dataText"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private int GetInt( string dataText, int defaultValue )
        {
            int result = defaultValue;
            try
            {
                return Int32.Parse( dataText );
            }
            catch
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 数値取得処理（変換不可判定あり）
        /// </summary>
        /// <param name="dataText"></param>
        /// <param name="defaultValue"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool GetInt( string dataText, int defaultValue, out int number )
        {
            number = 0;
            try
            {
                number = Int32.Parse( dataText );
                return true;
            }
            catch
            {
                return false;
            }
        }
        # endregion

        # region ■ OwnerFormのイベント ■
        /// <summary>
        /// オーナーフォームのLoadイベントに設定するイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OwnerFormOnLoad( Object sender, EventArgs e )
        {
            //----------------------------------
            // 読み込み
            //----------------------------------
            if ( ReadOnLoad )
            {
                // 読み込み
                ReadMemInput();
            }

            //----------------------------------
            // イベントハンドラ制御
            //----------------------------------
            if ( OwnerForm is Form )
            {
                // 貼り付け先が子フォームの場合
                if ( (OwnerForm as Form).TopLevel == false && (OwnerForm as Form).ParentForm != null)
                {
                    // 貼り付け先の親フォームにイベント処理追加
                    (OwnerForm as Form).ParentForm.FormClosing += this.OwnerFormOnFormClosing;
                    // 貼り付け先フォームからイベント処理削除
                    (OwnerForm as Form).FormClosing -= this.OwnerFormOnFormClosing;
                }
            }
            else if ( OwnerForm is UserControl )
            {
                // 貼り付け先がユーザーコントロールの場合は親フォームに対してセット
                if ( (OwnerForm as UserControl).ParentForm != null )
                {
                    // 貼り付け先の親フォームにイベント処理追加
                    (OwnerForm as UserControl).ParentForm.FormClosing += this.OwnerFormOnFormClosing;
                }
            }
        }
        /// <summary>
        /// オーナーフォームのFormClosingイベントに設定するイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OwnerFormOnFormClosing( Object sender, EventArgs e )
        {
            if ( WriteOnClose )
            {
                // 書き込み
                WriteMemInput();
            }
        }
        # endregion ■ OwnerFormのイベント ■
    }
    # endregion ■ UI入力項目設定コンポーネント ■
}
