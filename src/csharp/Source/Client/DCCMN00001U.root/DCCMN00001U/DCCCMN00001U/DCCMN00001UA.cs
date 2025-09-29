using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using Broadleaf.Library.Resources;
using System.IO;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ＵＩ入力項目設定ツール
    /// </summary>
    /// <remarks>
    /// Note       : UI入力項目の入力制御設定を行うツールです。<br />
    /// Programmer : 22018 鈴木 正臣<br />
    /// Date       : 2008.01.30<br />
    /// <br />
    /// Update Note: 2008.05.09 鈴木正臣<br />
    ///                ①PM.NS向けリコンパイル<br />
    ///                ②TDateEditを構成するTNeditを自動抽出しないように変更(名称で判定)
    /// </remarks>
    public partial class DCCMN00001UA : Form
    {
        # region ■ private field ■
        // UI設定ファイルアクセス
        private UiSetFileAcs _uiSetFileAcs;
        // 設定データセット
        private UiSetDataSet _uisetDataSet;
        // 共通設定ファイルクラス
        private UiSetCommon _uiSetCommon;
        // アセンブリ別設定ファイルクラス
        private UiSetByAssembly _uiSetAsm;
        # endregion ■ private field ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DCCMN00001UA()
        {
            InitializeComponent();

            _uiSetFileAcs = new UiSetFileAcs();
            _uisetDataSet = new UiSetDataSet();

            _uisetDataSet.UiSet.Rows.Clear();
            _uisetDataSet.SetDD.Rows.Clear();

            // 初期状態で更新ボタンは押せないようにする
            this.bt_Update.Enabled = false;
        }
        # endregion ■ コンストラクタ ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCCMN00001UA_Load( object sender, EventArgs e )
        {
            // 入力項目用グリッド設定
            SettingGridUiSet();

            // ＤＤ用グリッド設定
            SettingGridSetDD();
        }
        # endregion ■ フォームロード ■

        # region ■ 設定表示関連 ■
        /// <summary>
        /// 表示ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Load_Click( object sender, EventArgs e )
        {
            string assemblyFileName = this.tb_Assembly.Text.Trim();

            DialogResult res;

            # region [アセンブリ名のチェック]
            if ( assemblyFileName == string.Empty )
            {
                res = MessageBox.Show( "共通設定を表示しますか？", "確認", MessageBoxButtons.YesNo );
                if ( res == DialogResult.No )
                {
                    return;
                }
            }
            else
            {
                if ( !File.Exists( assemblyFileName ) )
                {
                    MessageBox.Show( "ファイルが見つかりません。", "注意" );
                    return;
                }
                List<string> extList = new List<string>( new string[] { "DLL", "EXE" } );
                if ( !extList.Contains( Path.GetExtension( assemblyFileName ).Replace( ".", "" ).ToUpper() ) )
                {
                    MessageBox.Show( "*.EXEまたは*.DLLを入力して下さい。", "注意" );
                    return;
                }
            }
            # endregion

            string asmName = Path.GetFileNameWithoutExtension( assemblyFileName );
            lb_AssemblySnm.Text = asmName;

            bool existsXML = false;

            if ( asmName != string.Empty )
            {
                if ( _uiSetFileAcs.ExistsUiSetByAssembly( asmName ) )
                {
                    // 設定ファイルあり
                    existsXML = true;
                }
                else
                {
                    // 設定ファイルなし
                    res = MessageBox.Show( "このアセンブリの設定XMLファイルがありません。\n新規作成しますか？", "確認", MessageBoxButtons.YesNo );
                    if ( res == DialogResult.No )
                    {
                        // ＮＯ→中断
                        return;
                    }
                }
            }

            // 初期化
            _uisetDataSet.UiSet.Rows.Clear();
            _uisetDataSet.SetDD.Rows.Clear();


            SFCMN00299CA progressDialog = new SFCMN00299CA();
            try
            {
                progressDialog.Title = "処理中...";
                progressDialog.Message = "設定の読み込み中です...";
                progressDialog.Show();

                //---------------------------------------------------
                // 共通設定
                //---------------------------------------------------
                // 共通設定XMLファイルを読み込む
                _uiSetCommon = _uiSetFileAcs.ReadUiSetCommon();

                if ( _uiSetCommon == null )
                {
                    _uiSetCommon = new UiSetCommon();
                    _uiSetCommon.UISetDD = new List<UiSet>();
                    _uiSetCommon.UISetItems = new List<UiSetItem>();
                    // return;
                }
                // グリッド表示
                CopyToUiSetTableFromUiSetCommon( _uiSetCommon );

                if ( asmName != string.Empty )
                {
                    //---------------------------------------------------
                    // アセンブリ設定
                    //---------------------------------------------------
                    if ( existsXML )
                    {
                        // アセンブリに対応するXMLファイルを読み込む
                        _uiSetAsm = _uiSetFileAcs.ReadUiSetByAssembly( asmName );
                        // グリッド表示 
                        CopyToUiSetTableFromUiSetAsm( _uiSetAsm, asmName );
                    }

                    // アセンブリに対してリフレクションにより設定値を取得する
                    // (※すでにXMLファイルがあっても、変更分を抽出する為に再度行う)
                    CreateSetting( assemblyFileName );
                }

                // 表示が完了したら、更新ボタンを押せるようにする
                this.bt_Update.Enabled = true;

            }
            finally
            {
                // 処理中フォームを閉じる
                progressDialog.Close();

                //if ( _uiSetCommon == null )
                //{
                //    MessageBox.Show( "共通設定ファイルが見つかりません。" );
                //}
            }
        }
        /// <summary>
        /// アセンブリ別設定　新規作成処理
        /// </summary>
        /// <param name="asmName"></param>
        /// <remarks>
        /// <br>リフレクションにより、ＵＩアセンブリから入力項目一覧を生成します。</br>
        /// </remarks>
        private void CreateSetting( string assemblyFileName )
        {
            // アセンブリのロード
            Assembly assembly = Assembly.LoadFile( assemblyFileName );
            if ( assembly == null )
            {
                return;
            }

            // フォームクラスの抽出
            foreach ( Type definedType in assembly.GetTypes() )
            {
                //try
                //{
                //    // インスタンス生成
                //    object obj = Activator.CreateInstance( definedType );

                //    // インスタンスがFormを継承するクラスのインスタンスか
                //    // 判定し、処理を行う
                //    if ( obj is Form )
                //    {
                //        CreateSettingByForm( (Form)obj, assemblyFileName );
                //    }
                //}
                //catch
                //{
                //    // デフォルトコンストラクタの無いクラスは
                //    // CreateInstanceでエラーになるが、無視して読み飛ばす。
                //}

                // FormまたはFormのサブクラスまたはUserControlまたはUserControlサブクラスならば抽出
                if ( definedType == typeof(Form) || definedType.IsSubclassOf( typeof(Form) ) ||
                     definedType == typeof(UserControl) || definedType.IsSubclassOf( typeof(UserControl)))
                {
                    CreateSettingByForm( definedType, assemblyFileName );
                }
            }
        }
        /// <summary>
        /// フォーム毎の入力項目をグリッドに展開する
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="assemblyFileName"></param>
        private void CreateSettingByForm( Type formType, string assemblyFileName )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/09 ADD
            // 抽出から除外するコントロール名称のリスト
            List<string> ignoreNames = new List<string>(new string[]
                {
                    "YearEdit",     // TDateEditを構成する年Edit
                    "MonthEdit",    // TDateEditを構成する月Edit
                    "DayEdit"       // TDateEditを構成する日Edit
                });
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/09 ADD

            FieldInfo[] fields = formType.GetFields( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
            foreach ( FieldInfo fieldInfo in fields )
            {
                // TEditまたはTEditのサブクラス（TNedit含む）ならば
                if ( fieldInfo.FieldType == typeof(TEdit) || fieldInfo.FieldType.IsSubclassOf( typeof( TEdit ) ) )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/09 ADD
                    // 除外する名称ならば迂回
                    if ( ignoreNames.Contains( fieldInfo.Name ) )
                    {
                        continue;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/09 ADD

                    // 同一名称で設定が無いか確認する
                    if ( ExistsItemSetting( fieldInfo.Name ) )
                    {
                        continue;
                    }

                    // 新しい行を追加
                    UiSetDataSet.UiSetRow row = _uisetDataSet.UiSet.NewUiSetRow();

                    row.NewMark = "NEW";        // リフレクションにより自動抽出した分は"NEW"表示
                    row.DDName = string.Empty;  // 初期状態は未入力にする
                    row.ItemName = fieldInfo.Name;
                    row.AssemblyName = Path.GetFileNameWithoutExtension( assemblyFileName );
                    row.FormName = formType.Name;

                    _uisetDataSet.UiSet.AddUiSetRow( row );
                }
            }
        }
        ///// <summary>
        ///// フォーム毎の入力項目設定をグリッドに展開する
        ///// </summary>
        ///// <param name="form"></param>
        //private void CreateSettingByForm( Form form, string assemblyFileName )
        //{
        //    // コントロール一覧生成
        //    List<Control> controlList = new List<Control>();
        //    CreateControlList( ref controlList, form );

        //    // 一覧を元にUI設定クラスを生成
        //    foreach ( Control control in controlList )
        //    {
        //        // TEdit/TNeditならば
        //        if ( control is TEdit )
        //        {
        //            // 同一名称で設定が無いか確認する
        //            if ( ExistsItemSetting( control.Name ) )
        //            {
        //                continue;
        //            }

        //            // 新しい行を追加
        //            UiSetDataSet.UiSetRow row = _uisetDataSet.UiSet.NewUiSetRow();

        //            row.NewMark = "NEW";        // リフレクションにより自動抽出した分は"NEW"表示
        //            row.DDName = string.Empty;  // 初期状態は未入力にする
        //            row.ItemName = control.Name;
        //            row.AssemblyName = Path.GetFileNameWithoutExtension( assemblyFileName );
        //            row.FormName = form.GetType().Name;

        //            _uisetDataSet.UiSet.AddUiSetRow( row );
        //        }
        //    }
        //}
        ///// <summary>
        ///// コントロール一覧生成
        ///// </summary>
        ///// <param name="controlList"></param>
        ///// <param name="control"></param>
        //private void CreateControlList( ref List<Control> controlList, Control control )
        //{
        //    // リストに追加
        //    controlList.Add( control );

        //    // 子コントロールに再帰
        //    foreach ( Control childControl in control.Controls )
        //    {
        //        CreateControlList( ref controlList, childControl );
        //    }
        //}

        /// <summary>
        /// 同一名称の項目が存在するかチェックする（共通・アセンブリ別どちらもチェックする）
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private bool ExistsItemSetting( string itemName )
        {
            // データビュー生成
            DataView view = new DataView( _uisetDataSet.UiSet );
            view.RowFilter = string.Format( "{0} = '{1}'",
                                            _uisetDataSet.UiSet.ItemNameColumn.ColumnName, itemName );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //※大文字・小文字を区別していなかったので、以下修正

            //if ( view.Count > 0 )
            //{
            //    // 同一名称のレコードが存在する
            //    return true;
            //}
            //else
            //{
            //    // 同一名称のレコードが存在しない
            //    return false;
            //}

            foreach ( DataRowView rowView in view )
            {
                if ( (string)rowView[_uisetDataSet.UiSet.ItemNameColumn.ColumnName] == itemName )
                {
                    // 同一名称の項目あり
                    return true;
                }
            }
            // 同一名称の項目なし
            return false;

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// 共通設定に同一名称の項目が存在するかチェックする
        /// </summary>
        /// <returns></returns>
        private bool ExistsItemSetting( string assemblyName, string formName, string itemName )
        {
            // データビュー生成
            DataView view = new DataView( _uisetDataSet.UiSet );
            view.RowFilter = string.Format( "{0} = '{1}' AND {2} = '{3}'",
                                            _uisetDataSet.UiSet.AssemblyNameColumn.ColumnName, assemblyName,
                                            _uisetDataSet.UiSet.FormNameColumn.ColumnName, formName,
                                            _uisetDataSet.UiSet.ItemNameColumn.ColumnName, itemName );

            foreach ( DataRowView rowView in view )
            {
                if ( (string)rowView[_uisetDataSet.UiSet.ItemNameColumn.ColumnName] == itemName )
                {
                    // 同一名称の項目あり
                    return true;
                }
            }
            // 同一名称の項目なし
            return false;
        }

        /// <summary>
        /// 共通設定取り込み（UiSetCommon → UiSetTable）
        /// </summary>
        /// <param name="_uiSetCommon"></param>
        private void CopyToUiSetTableFromUiSetCommon( UiSetCommon uiSetCommon )
        {
            // 入力項目設定のコンボボックス項目
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)this.gridUiSet.Columns[_uisetDataSet.UiSet.DDNameColumn.ColumnName];
            // 初期化
            cmbColumn.Items.Clear();
            cmbColumn.Items.Add( string.Empty );
            

            //---------------------------------------------------
            // ＤＤ設定
            //---------------------------------------------------
            UiSetDataSet.SetDDRow ddRow;

            foreach ( UiSet ddItem in uiSetCommon.UISetDD )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 既に同一ＤＤがあれば除外（先に読み込んだ内容が優先）
                if ( cmbColumn.Items.Contains( ddItem.ItemDDName ) )
                {
                    continue;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // １項目毎に１行追加
                ddRow = _uisetDataSet.SetDD.NewSetDDRow();

                ddRow.Remarks = ddItem.Remarks;
                ddRow.AssemblyName = string.Empty;  // 共通設定なのでEmpty
                ddRow.DDName = ddItem.ItemDDName;
                ddRow.Columns = ddItem.Column;
                ddRow.AllowAlpha = ddItem.AllowAlpha;
                ddRow.AllowKana = ddItem.AllowKana;
                ddRow.AllowNum = ddItem.AllowNum;
                ddRow.AllowNumSign = ddItem.AllowNumSign;
                ddRow.AllowSign = ddItem.AllowSign;
                ddRow.AllowSpace = ddItem.AllowSpace;
                ddRow.AllowWord = ddItem.AllowWord;
                ddRow.PadZero = ddItem.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                ddRow.AllowZeroCode = ddItem.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD
                ddRow.ImeMode = this.GetImeModeText( ddItem.ImeMode );
                ddRow.HAlign = this.GetHAlignText( ddItem.HAlign );

                // 追加
                _uisetDataSet.SetDD.Rows.Add( ddRow );

                // 入力項目設定のコンボボックスにアイテム追加
                cmbColumn.Items.Add( ddItem.ItemDDName );
            }

            //---------------------------------------------------
            // 入力項目設定
            //---------------------------------------------------
            UiSetDataSet.UiSetRow setRow;
            
            foreach ( UiSetItem item in uiSetCommon.UISetItems )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 同一名称で設定が無いか確認する
                // (※もし共通設定内に重複して登録があれば、１つにまとめる。
                //    このとき、XMLファイル上、一番上に記述されていたものが優先)
                if ( ExistsItemSetting( item.ItemName ) )
                {
                    continue;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // １項目毎に１行追加
                setRow = _uisetDataSet.UiSet.NewUiSetRow();

                setRow.NewMark = string.Empty;      // 設定済み項目なので、"NEW"表示しない
                setRow.AssemblyName = string.Empty; // 共通設定なのでEmpty
                setRow.FormName = string.Empty;     // 共通設定なのでEmpty
                setRow.ItemName = item.ItemName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                //{
                //    cmbColumn.Items.Add( item.ItemDDName );
                //}
                //setRow.DDName = item.ItemDDName;

                if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                {
                    // ＤＤ設定に無い場合は空白にする（※注意！空白のまま更新すると設定が削除されます！）
                    setRow.DDName = string.Empty;
                }
                else
                {
                    setRow.DDName = item.ItemDDName;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 追加
                _uisetDataSet.UiSet.Rows.Add( setRow );
            }

            // コンボボックスアイテムをソートする
            ComboBoxItemSort( cmbColumn );
        }

        /// <summary>
        /// コンボボックスアイテムのソート処理
        /// </summary>
        /// <param name="cmbColumn"></param>
        private void ComboBoxItemSort( DataGridViewComboBoxColumn cmbColumn )
        {
            // アイテムをリストに移し替える
            List<string> _itemList = new List<string>();
            foreach ( object obj in cmbColumn.Items )
            {
                if ( obj is string )
                {
                    _itemList.Add( (string)obj );
                }
            }

            // ソートする
            _itemList.Sort();

            // アイテムを差し替える
            cmbColumn.Items.Clear();
            cmbColumn.Items.AddRange( _itemList.ToArray() );
        }
        /// <summary>
        /// アセンブリ別設定取り込み（UiSetByAssembly → UiSetTable）
        /// </summary>
        /// <param name="uiSetAsm"></param>
        private void CopyToUiSetTableFromUiSetAsm( UiSetByAssembly uiSetAsm, string assemblyName )
        {
            // 入力項目設定のコンボボックス項目
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)this.gridUiSet.Columns[_uisetDataSet.UiSet.DDNameColumn.ColumnName];
            //// 初期化しない
            //cmbColumn.Items.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // アセンブリ固有のＤＤの重複チェック用
            List<string> thisAsmDDList = new List<string>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //---------------------------------------------------
            // ＤＤ設定
            //---------------------------------------------------
            UiSetDataSet.SetDDRow ddRow;

            foreach ( UiSet ddItem in uiSetAsm.UISetDD )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // アセンブリ固有のＤＤの重複チェック
                if ( thisAsmDDList.Contains( ddItem.ItemDDName ) )
                {
                    // このアセンブリ固有のＤＤとして既に存在すれば除外（先に読み込んだ方が優先）
                    continue;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // １項目毎に１行追加
                ddRow = _uisetDataSet.SetDD.NewSetDDRow();

                ddRow.Remarks = ddItem.Remarks;
                ddRow.AssemblyName = assemblyName;  // アセンブリ別設定なので、名称セット
                ddRow.DDName = ddItem.ItemDDName;
                ddRow.Columns = ddItem.Column;
                ddRow.AllowAlpha = ddItem.AllowAlpha;
                ddRow.AllowKana = ddItem.AllowKana;
                ddRow.AllowNum = ddItem.AllowNum;
                ddRow.AllowNumSign = ddItem.AllowNumSign;
                ddRow.AllowSign = ddItem.AllowSign;
                ddRow.AllowSpace = ddItem.AllowSpace;
                ddRow.AllowWord = ddItem.AllowWord;
                ddRow.PadZero = ddItem.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                ddRow.AllowZeroCode = ddItem.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD

                ddRow.ImeMode = this.GetImeModeText( ddItem.ImeMode );
                ddRow.HAlign = this.GetHAlignText( ddItem.HAlign );

                // 追加
                _uisetDataSet.SetDD.Rows.Add( ddRow );

                // 入力項目設定のコンボボックスにアイテム追加
                cmbColumn.Items.Add( ddItem.ItemDDName );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // アセンブリ固有のＤＤの重複チェック用
                thisAsmDDList.Add( ddItem.ItemDDName );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }

            //---------------------------------------------------
            // 入力項目設定
            //---------------------------------------------------
            UiSetDataSet.UiSetRow setRow;

            foreach ( UiSetByForm uiSetFm in uiSetAsm.UISetByForms )
            {
                foreach ( UiSetItem item in uiSetFm.UISetItems )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    // 同一アセンブリ同一フォーム内で重複する設定が有った場合は１つにまとめる
                    // (※このとき、XMLファイル上一番上に記述されていた内容を優先)
                    ExistsItemSetting( assemblyName, uiSetFm.FormName, item.ItemName );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // １項目毎に１行追加
                    setRow = _uisetDataSet.UiSet.NewUiSetRow();

                    setRow.NewMark = string.Empty;          // 設定済み項目なので"NEW"表示しない
                    setRow.AssemblyName = assemblyName;     // アセンブリ別設定なので、名称セット
                    setRow.FormName = uiSetFm.FormName;     // アセンブリ別設定なので、名称セット
                    setRow.ItemName = item.ItemName;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                    //{
                    //    cmbColumn.Items.Add( item.ItemDDName );
                    //}
                    //setRow.DDName = item.ItemDDName;

                    if ( !cmbColumn.Items.Contains( item.ItemDDName ) )
                    {
                        // ＤＤ設定に登録が無ければ空白にする。（※注意！空白で更新すると設定が削除されます！）
                        setRow.DDName = string.Empty;
                    }
                    else
                    {
                        setRow.DDName = item.ItemDDName;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // 追加
                    _uisetDataSet.UiSet.Rows.Add( setRow );
                }
            }

            // コンボボックスアイテムをソートする
            ComboBoxItemSort( cmbColumn );

        }

        /// <summary>
        /// 左右揃え属性から対応する文字列を取得
        /// </summary>
        /// <param name="hAlign"></param>
        /// <returns></returns>
        private string GetHAlignText( Infragistics.Win.HAlign hAlign )
        {
            switch ( hAlign )
            {
                case Infragistics.Win.HAlign.Center:
                    return "Center";
                case Infragistics.Win.HAlign.Default:
                    return "Left";  // defaultはLeftにする
                case Infragistics.Win.HAlign.Left:
                    return "Left";
                case Infragistics.Win.HAlign.Right:
                    return "Right";
                default:
                    return "Left";  // defaultはLeftにする
            }
        }
        /// <summary>
        /// 文字列から対応する左右揃え属性を取得
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Infragistics.Win.HAlign GetHAlign( string hAlignText )
        {
            switch ( hAlignText )
            {
                case "Left":
                    return Infragistics.Win.HAlign.Left;
                case "Center":
                    return Infragistics.Win.HAlign.Center;
                case "Right":
                    return Infragistics.Win.HAlign.Right;
                default:
                    return Infragistics.Win.HAlign.Left;    // defaultはLeftにする
            }
        }
        /// <summary>
        /// ＩＭＥモードに対応する文字列を取得
        /// </summary>
        /// <param name="imeMode"></param>
        /// <returns></returns>
        private string GetImeModeText( ImeMode imeMode )
        {
            switch ( imeMode )
            {
                case ImeMode.Alpha:
                    return "Alpha";
                case ImeMode.AlphaFull:
                    return "AlphaFull";
                case ImeMode.Close:
                    return "Close";
                case ImeMode.Disable:
                    return "Disable";
                case ImeMode.Hangul:
                    return "Hangul";
                case ImeMode.HangulFull:
                    return "HangulFull";
                case ImeMode.Hiragana:
                    return "Hiragana";
                case ImeMode.Inherit:
                    return "Inherit";
                case ImeMode.Katakana:
                    return "Katakana";
                case ImeMode.KatakanaHalf:
                    return "KatakanaHalf";
                case ImeMode.NoControl:
                    return "NoControl";
                case ImeMode.Off:
                    return "Off";
                case ImeMode.On:
                    return "On";
                default:
                    return "NoControl"; // defaultはNoControlにする
            }
        }
        /// <summary>
        /// 文字列に対応するＩＭＥモードを取得
        /// </summary>
        /// <param name="imeModeText"></param>
        /// <returns></returns>
        private ImeMode GetImeMode( string imeModeText )
        {
            switch ( imeModeText )
            {
                case "Alpha":
                    return ImeMode.Alpha;
                case "AlphaFull":
                    return ImeMode.AlphaFull;
                case "Close":
                    return ImeMode.Close;
                case "Disable":
                    return ImeMode.Disable;
                case "Hangul":
                    return ImeMode.Hangul;
                case "HangulFull":
                    return ImeMode.HangulFull;
                case "Hiragana":
                    return ImeMode.Hiragana;
                case "Inherit":
                    return ImeMode.Inherit;
                case "Katakana":
                    return ImeMode.Katakana;
                case "KatakanaHalf":
                    return ImeMode.KatakanaHalf;
                case "NoControl":
                    return ImeMode.NoControl;
                case "Off":
                    return ImeMode.Off;
                case "On":
                    return ImeMode.On;
                default:
                    return ImeMode.NoControl;   // defaultはNoControlにする
            }
        }


        # endregion ■ 設定表示関連 ■

        # region ■ 設定ファイル書き込み関連 ■
        /// <summary>
        /// 書き込みボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click( object sender, EventArgs e )
        {
            // 更新ダイアログ
            SaveCompletionDialog cmplDialog;

            // 共通設定書き込み
            DialogResult dialogResult = MessageBox.Show( "全ＰＧ共通の設定を更新しますか？", "確認", MessageBoxButtons.YesNo );
            if ( dialogResult == DialogResult.Yes )
            {
                if ( WriteXMLCommon() )
                {
                    cmplDialog = new SaveCompletionDialog();
                    cmplDialog.ShowDialog( 2 );
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    MessageBox.Show( "全ＰＧ共通設定の更新に失敗しました。\r\n（読み取り専用属性を確認して下さい）" );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }

            if ( this.lb_AssemblySnm.Text.Trim() != string.Empty )
            {
                // アセンブリ別設定書き込み
                dialogResult = MessageBox.Show( "アセンブリ別の設定を更新しますか？", "確認", MessageBoxButtons.YesNo );
                if ( dialogResult == DialogResult.Yes )
                {
                    if ( WriteXMLByAssembly() )
                    {
                        cmplDialog = new SaveCompletionDialog();
                        cmplDialog.ShowDialog( 2 );
                    }
                    else
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        MessageBox.Show( "アセンブリ別設定の更新に失敗しました。\r\n（読み取り専用属性を確認して下さい）" );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    }
                }
            }
        }
        /// <summary>
        /// アセンブリ別設定ＸＭＬファイル書き込み処理
        /// </summary>
        private bool WriteXMLByAssembly()
        {
            // 設定クラス生成
            UiSetByAssembly uiSetAsm = new UiSetByAssembly();

            //-----------------------------------------------------------
            // ＤＤ設定
            //-----------------------------------------------------------
            uiSetAsm.UISetDD = new List<UiSet>();

            foreach ( UiSetDataSet.SetDDRow ddRow in _uisetDataSet.SetDD.Rows )
            {
                // 正しく設定されていない行は除外
                if ( ddRow.DDName == string.Empty )
                {
                    continue;
                }
                // 共通設定の行は除外
                if ( ddRow.AssemblyName == string.Empty )
                {
                    continue;
                }

                UiSet uiSet = new UiSet();

                uiSet.Remarks = ddRow.Remarks;
                uiSet.ItemDDName = ddRow.DDName;
                uiSet.Column = ddRow.Columns;
                uiSet.AllowAlpha = ddRow.AllowAlpha;
                uiSet.AllowKana = ddRow.AllowKana;
                uiSet.AllowNum = ddRow.AllowNum;
                uiSet.AllowNumSign = ddRow.AllowNumSign;
                uiSet.AllowSign = ddRow.AllowSign;
                uiSet.AllowSpace = ddRow.AllowSpace;
                uiSet.AllowWord = ddRow.AllowWord;
                uiSet.PadZero = ddRow.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                uiSet.AllowZeroCode = ddRow.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD

                uiSet.ImeMode = this.GetImeMode( ddRow.ImeMode );
                uiSet.HAlign = this.GetHAlign( ddRow.HAlign );

                uiSetAsm.UISetDD.Add( uiSet );
            }
            // ソート
            uiSetAsm.UISetDD.Sort();


            //-----------------------------------------------------------
            // 入力項目設定
            //-----------------------------------------------------------

            uiSetAsm.UISetByForms = new List<UiSetByForm>();
            Dictionary<string,UiSetByForm> setFmDic = new Dictionary<string,UiSetByForm>();

            foreach ( UiSetDataSet.UiSetRow setRow in _uisetDataSet.UiSet.Rows )
            {
                // 正しく設定されていない行は除外
                if ( setRow.ItemName == string.Empty )
                {
                    continue;
                }
                // 正しく設定されていない行は除外
                if ( setRow.DDName == string.Empty )
                {
                    continue;
                }
                // アセンブリ別設定の行は除外
                if ( setRow.AssemblyName == string.Empty )
                {
                    continue;
                }


                // フォームの切り分け
                UiSetByForm uiSetFm;
                if ( setFmDic.ContainsKey( setRow.FormName ) )
                {
                    // 既存のフォーム設定
                    uiSetFm = setFmDic[setRow.FormName];
                }
                else
                {
                    // 新規フォーム設定を作成
                    uiSetFm = new UiSetByForm();
                    uiSetFm.FormName = setRow.FormName;
                    uiSetFm.UISetItems = new List<UiSetItem>();
                    uiSetAsm.UISetByForms.Add( uiSetFm );   // 参照型なので先に追加してもＯＫ

                    // ディクショナリに追加
                    setFmDic.Add( uiSetFm.FormName, uiSetFm );
                }

                UiSetItem uiSetItem = new UiSetItem();

                uiSetItem.ItemName = setRow.ItemName;
                uiSetItem.ItemDDName = setRow.DDName;

                uiSetFm.UISetItems.Add( uiSetItem );
            }
            // ソート
            foreach ( UiSetByForm fm in uiSetAsm.UISetByForms )
            {
                fm.UISetItems.Sort();
            }

            // 書き込み
            return _uiSetFileAcs.WriteXMLByAssembly( this.lb_AssemblySnm.Text, uiSetAsm );

        }
        /// <summary>
        /// 共通設定ＸＭＬファイル書き込み処理
        /// </summary>
        private bool WriteXMLCommon()
        {
            // 設定クラス生成
            UiSetCommon uiSetCmn = new UiSetCommon();

            //-----------------------------------------------------------
            // ＤＤ設定
            //-----------------------------------------------------------
            uiSetCmn.UISetDD = new List<UiSet>();

            foreach ( UiSetDataSet.SetDDRow ddRow in _uisetDataSet.SetDD.Rows )
            {
                // 正しく設定されていない行は除外
                if ( ddRow.DDName == string.Empty )
                {
                    continue;
                }
                // アセンブリ別設定の行は除外
                if ( ddRow.AssemblyName != string.Empty )
                {
                    continue;
                }

                UiSet uiSet = new UiSet();
                
                uiSet.Remarks = ddRow.Remarks;
                uiSet.ItemDDName = ddRow.DDName;
                uiSet.Column = ddRow.Columns;
                uiSet.AllowAlpha = ddRow.AllowAlpha;
                uiSet.AllowKana = ddRow.AllowKana;
                uiSet.AllowNum = ddRow.AllowNum;
                uiSet.AllowNumSign = ddRow.AllowNumSign;
                uiSet.AllowSign = ddRow.AllowSign;
                uiSet.AllowSpace = ddRow.AllowSpace;
                uiSet.AllowWord = ddRow.AllowWord;
                uiSet.PadZero = ddRow.PadZero;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 ADD
                uiSet.AllowZeroCode = ddRow.AllowZeroCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 ADD
                uiSet.ImeMode = this.GetImeMode( ddRow.ImeMode );
                uiSet.HAlign = this.GetHAlign( ddRow.HAlign );

                uiSetCmn.UISetDD.Add( uiSet );
            }
            // ソート
            uiSetCmn.UISetDD.Sort();


            //-----------------------------------------------------------
            // 入力項目設定
            //-----------------------------------------------------------
            uiSetCmn.UISetItems = new List<UiSetItem>();

            foreach ( UiSetDataSet.UiSetRow setRow in _uisetDataSet.UiSet.Rows )
            {
                // 正しく設定されていない行は除外
                if ( setRow.ItemName == string.Empty )
                {
                    continue;
                }
                // 正しく設定されていない行は除外
                if ( setRow.DDName == string.Empty )
                {
                    continue;
                }
                // アセンブリ別設定の行は除外
                if ( setRow.AssemblyName != string.Empty )
                {
                    continue;
                }

                UiSetItem uiSetItem = new UiSetItem();

                uiSetItem.ItemName = setRow.ItemName;
                uiSetItem.ItemDDName = setRow.DDName;

                uiSetCmn.UISetItems.Add( uiSetItem );
            }
            // ソート
            uiSetCmn.UISetItems.Sort();


            // 書き込み
            return _uiSetFileAcs.WriteXMLCommon( uiSetCmn );
        }

        # endregion ■ 設定ファイル書き込み関連 ■

        # region ■ グリッド初期設定関連 ■
        /// <summary>
        /// 入力項目用グリッドの設定処理
        /// </summary>
        private void SettingGridUiSet()
        {
            // データソースを登録
            this.gridUiSet.DataSource = _uisetDataSet.UiSet;

            // フォント設定
            this.gridUiSet.Font = new Font( "ＭＳ ゴシック", 10.5f );

            // ComboBox列の設定
            List<string> itemList = new List<string>(); // ※項目が動的に変わる為、このタイミングでは追加できないので、空のリストを渡す
            SetComboBoxColumn( this.gridUiSet, _uisetDataSet.UiSet, _uisetDataSet.UiSet.DDNameColumn.ColumnName, itemList );

            // 項目名を設定
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.NewMarkColumn.ColumnName, "", 40, true );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.AssemblyNameColumn.ColumnName, "アセンブリ", 120 );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.FormNameColumn.ColumnName, "フォーム", 120 );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.ItemNameColumn.ColumnName, "入力項目名(*)", 210 );
            SetColumnStyle( this.gridUiSet, _uisetDataSet.UiSet.DDNameColumn.ColumnName, "ＤＤ(*)", 210 );

        }
        /// <summary>
        /// ＤＤ用グリッドの設定処理
        /// </summary>
        private void SettingGridSetDD()
        {
            // データソースを登録
            this.gridSetDD.DataSource = _uisetDataSet.SetDD;

            // フォント設定
            this.gridSetDD.Font = new Font( "ＭＳ ゴシック", 10.5f );

            // ComboBox列の設定
            // (HAlign)
            List<string> itemList = new List<string>();
            itemList.Add( "Left" );
            itemList.Add( "Center" );
            itemList.Add( "Right" );
            SetComboBoxColumn( this.gridSetDD, _uisetDataSet.SetDD, _uisetDataSet.SetDD.HAlignColumn.ColumnName, itemList );
            // (IMEMode)
            itemList = new List<string>();
            itemList.Add( "Alpha" );
            itemList.Add( "AlphaFull" );
            itemList.Add( "Close" );
            itemList.Add( "Disable" );
            itemList.Add( "Hangul" );
            itemList.Add( "HangulFull" );
            itemList.Add( "Hiragana" );
            itemList.Add( "Inherit" );
            itemList.Add( "Katakana" );
            itemList.Add( "KatakanaHalf" );
            itemList.Add( "NoControl" );
            itemList.Add( "Off" );
            itemList.Add( "On" );
            SetComboBoxColumn( this.gridSetDD, _uisetDataSet.SetDD, _uisetDataSet.SetDD.ImeModeColumn.ColumnName, itemList );

            // 項目名を設定
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AssemblyNameColumn.ColumnName, "ｱｾﾝﾌﾞﾘ", 100 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.RemarksColumn.ColumnName, "説明", 110 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.DDNameColumn.ColumnName, "ＤＤ(*)", 110 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.ColumnsColumn.ColumnName, "桁数", 30 );
            
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowAlphaColumn.ColumnName, "英字", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowKanaColumn.ColumnName, "カナ", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowNumColumn.ColumnName, "数字", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowNumSignColumn.ColumnName, "数記号", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowSignColumn.ColumnName, "記号", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowSpaceColumn.ColumnName, "空白", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowWordColumn.ColumnName, "全角", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.HAlignColumn.ColumnName, "左右揃", 80 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.PadZeroColumn.ColumnName, "ｾﾞﾛ詰", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.AllowZeroCodeColumn.ColumnName, "ｾﾞﾛ可", 30 );
            SetColumnStyle( this.gridSetDD, _uisetDataSet.SetDD.ImeModeColumn.ColumnName, "IMEﾓｰﾄﾞ", 120 );

        }

        /// <summary>
        /// グリッド列スタイル設定
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        private void SetColumnStyle( DataGridView grid, string columnName, string caption, int width )
        {
            // 列スタイル設定（ReadOnly=false）
            SetColumnStyle( grid, columnName, caption, width, false );
        }

        /// <summary>
        /// グリッド列スタイル設定
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        private void SetColumnStyle( DataGridView grid, string columnName, string caption, int width, bool readOnly )
        {
            // 型によって、左右揃え位置を自動で取得
            DataGridViewContentAlignment align;

            if ( grid.Columns[columnName].ValueType == typeof( Int32 ) )
            {
                align = DataGridViewContentAlignment.MiddleRight;
            }
            else if ( grid.Columns[columnName].ValueType == typeof( Boolean ) )
            {
                align = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                align = DataGridViewContentAlignment.MiddleLeft;
            }

            // 列スタイル設定
            SetColumnStyle( grid, columnName, caption, width, align, readOnly );
        }
        /// <summary>
        /// グリッド列スタイル設定
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        private void SetColumnStyle( DataGridView grid, string columnName, string caption, int width, DataGridViewContentAlignment align, bool readOnly )
        {
            grid.Columns[columnName].HeaderText = caption;
            grid.Columns[columnName].Width = width;
            grid.Columns[columnName].DefaultCellStyle.Alignment = align;

            // 読み取り専用の列スタイル
            if ( readOnly )
            {
                grid.Columns[columnName].ReadOnly = true;
                grid.Columns[columnName].DefaultCellStyle.SelectionForeColor = Color.Black;
                grid.Columns[columnName].DefaultCellStyle.BackColor = SystemColors.Control;
                grid.Columns[columnName].DefaultCellStyle.SelectionBackColor = SystemColors.Control;
            }
        }
        /// <summary>
        /// コンボボックス列の設定
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="itemList"></param>
        private void SetComboBoxColumn( DataGridView grid, DataTable table, string columnName, List<string> itemList )
        {
            // コンボボックス列を定義する
            DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();
            
            // 選択アイテム一覧を生成
            foreach ( string itemText in itemList )
            {
                cmbColumn.Items.Add( itemText );
            }

            // 生成したコンボボックス列と既存の列を差し替える
            string cmbColumnName = columnName;
            cmbColumn.DataPropertyName = cmbColumnName;

            int index = table.Columns.IndexOf( cmbColumnName );

            grid.Columns.Insert( index, cmbColumn );
            grid.Columns.Remove( cmbColumnName );
            cmbColumn.Name = cmbColumnName;
        }
        # endregion ■ グリッド初期設定関連 ■

        # region ■ ドラッグ＆ドロップ ■
        /// <summary>
        /// ドラッグ＆ドロップ準備
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Assembly_DragOver( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                if ( (e.AllowedEffect & DragDropEffects.Move) != 0 )
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        /// <summary>
        /// ドラッグ＆ドロップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Assembly_DragDrop( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                // ドロップされたファイルの名称を取得
                string[] astr = (string[])e.Data.GetData( DataFormats.FileDrop );

                // ファイル名をテキストボックスに表示
                tb_Assembly.Text = astr[0];
            }
        }
        # endregion ■ドラッグ＆ドロップ ■

        # region ■ ファイル選択 ■
        /// <summary>
        /// ファイル選択ダイアログ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click( object sender, EventArgs e )
        {
            DialogResult res = openFileDialog1.ShowDialog( this );
            if ( res == DialogResult.OK )
            {
                this.tb_Assembly.Text = openFileDialog1.FileName;
                this.bt_Load.Focus();
            }
        }
        # endregion ■ ファイル選択 ■

        # region ■ 行削除ボタン ■
        /// <summary>
        /// 行削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1( object sender, EventArgs e )
        {
            // 選択されているタブによって、アクティブなグリッドが変わる
            if ( tabControl1.SelectedIndex == 0 )
            {
                // 入力項目設定
                int selectedCount = gridUiSet.SelectedRows.Count;
                for ( int index = 0; index < selectedCount; index++ )
                {
                    int rowIndex = gridUiSet.SelectedRows[0].Index;
                    if ( rowIndex != gridUiSet.Rows.Count - 1 )
                    {
                        gridUiSet.Rows.RemoveAt( rowIndex );
                    }
                }
            }
            else
            {
                // ＤＤ設定
                int selectedCount = gridSetDD.SelectedRows.Count;
                for ( int index = 0; index < selectedCount; index++ )
                {
                    int rowIndex = gridSetDD.SelectedRows[0].Index;
                    if ( rowIndex != gridUiSet.Rows.Count - 1 )
                    {
                        gridSetDD.Rows.RemoveAt( rowIndex );
                    }
                }
            }
        }
        # endregion ■ 行削除ボタン ■
    }

}