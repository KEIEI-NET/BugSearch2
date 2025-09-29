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
    # region ■ UI入力項目設定コンポーネント ■
    /// <summary>
    /// ＵＩ入力項目設定コンポーネント
    /// </summary>
    /// <remarks>
    /// Note       : ＵＩの各種入力項目に対し、共通の制御を行う為のコンポーネントです。<br />
    /// Programmer : 22018 鈴木 正臣<br />
    /// Date       : 2008.01.28<br />
    /// <br />
    /// Update Note: 2008.03.03  鈴木 正臣<br />
    ///                ①グリッド明細に対応する為の準備として、ＵＩ設定を外部提供するメソッドを追加<br />
    /// Update Note: 2008.03.25  鈴木 正臣<br />
    ///                ①親フォーム側で入力チェック処理を行う為のメソッドを追加<br />
    ///                  (別csファイルのTLibAvatarを使用)<br />
    /// Update Note: 2008.04.16  鈴木 正臣<br />
    ///                ①一括ゼロ詰め処理メソッドを追加<br />
    /// 　　　　　　　　②TEdit編集状態のテキスト左右揃えが有効になるよう変更<br />
    ///                ③マウス中ボタン無効化処理を追加<br />
    /// Update Note: 2009.05.28  鈴木 正臣<br />
    ///                ①帳票メインフレームで全項目一括ゼロ詰め処理したとき、<br />
    /// 　　　　　　　　　子フォーム固有の設定に従って処理されない不具合を修正。<br />
    /// </remarks>    
    [ToolboxBitmap( typeof( UiSetControl ), "UiSetControl.UiSetControl.bmp" ),
     DefaultEvent( "ChangeFocus" ), Serializable]
    public partial class UiSetControl : TbsBaseComponent
    {
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
        # region [private static fields]
        /// <summary>UiSetControlリスト(static)</summary>
        private static List<UiSetControl> stc_UiSetControlList;
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD

        # region [private fields]
        /// <summary>設定ファイルアクセスクラス</summary>
        private UiSetFileAcs _uiSetFileAcs;
        /// <summary>OwnerForm名称</summary>
        private string _ownerFormName;
        /// <summary>入力項目の幅調整方法</summary>
        private EditWidthSettingWayState _editWidthSettingWay;
        /// <summary>ゼロ詰めするEditのリスト</summary>
        private List<string> _padZeroEditList;
        /// <summary>ゼロ詰めし、ゼロ入力可能なEditのリスト</summary>
        private List<string> _inputableZeroCodePadZeroEditList;
        # endregion

        # region [Constructor]
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UiSetControl()
        {
            InitializeComponent();

            _uiSetFileAcs = new UiSetFileAcs();
            _ownerFormName = string.Empty;
            _padZeroEditList = new List<string>();
            _inputableZeroCodePadZeroEditList = new List<string>();
            _editWidthSettingWay = EditWidthSettingWayState.None;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
            if ( stc_UiSetControlList == null )
            {
                stc_UiSetControlList = new List<UiSetControl>();
            }
            stc_UiSetControlList.Add( this );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public UiSetControl( IContainer container )
        {
            container.Add( this );
            InitializeComponent();

            _uiSetFileAcs = new UiSetFileAcs();
            _ownerFormName = string.Empty;
            _padZeroEditList = new List<string>();
            _inputableZeroCodePadZeroEditList = new List<string>();
            _editWidthSettingWay = EditWidthSettingWayState.None;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
            if ( stc_UiSetControlList == null )
            {
                stc_UiSetControlList = new List<UiSetControl>();
            }
            stc_UiSetControlList.Add( this );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        }
        # endregion

        # region [event]
        /// <summary>
        /// TArrowKeyのChangeFocusイベント処理
        /// </summary>
        [Description( "TArrowKeyControlに設定するものと同じChangeFocusイベント処理を指定します。" )]
        public event Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler ChangeFocus;
        # endregion

        # region [enum]
        /// <summary>
        /// 入力項目の幅の設定方法
        /// </summary>
        public enum EditWidthSettingWayState
        {
            /// <summary>幅設定しない</summary>
            None = 0,
            /// <summary>AutoWidthプロパティを使用する</summary>
            UseAutoWidth = 1,
            /// <summary>計算結果を使用する</summary>
            CalculateCollapsing = 2,
        }
        # endregion

        # region [public propaties]
        /// <summary>
        /// 入力項目の幅の調整方法を設定します。
        /// </summary>
        [Category( "動作" ),
         Description( "TEdit/TNeditの幅の調整方法を設定します。" )]
        public EditWidthSettingWayState EditWidthSettingWay
        {
            get { return _editWidthSettingWay; }
            set { _editWidthSettingWay = value; }
        }

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
                            //(base.OwnerForm as Form).ControlAdded -= this.OwnerFormOnControlAdded;
                        }

                        if ( base.OwnerForm is UserControl )
                        {
                            (base.OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                            //(base.OwnerForm as UserControl).ControlAdded -= this.OwnerFormOnControlAdded;
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
                                //(base.OwnerForm as Form).ControlAdded += OwnerFormOnControlAdded;
                            }

                            if ( base.OwnerForm is UserControl )
                            {
                                (base.OwnerForm as UserControl).Load += this.OwnerFormOnLoad;
                                //(base.OwnerForm as UserControl).ControlAdded += OwnerFormOnControlAdded;
                            }
                        }
                    }
                    else
                    {
                        base.OwnerForm = value;
                    }


                    // 設定読み込み
                    ReadUISetting( base.OwnerForm as ContainerControl );
                }
            }
        }

        # endregion

        # region [static public methods]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 指定されたオーナーフォームに張り付けられた、UiSetControlオブジェクトを取得する。
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static UiSetControl SearchFromOwner( ContainerControl owner )
        {
            UiSetControl uiSetControl = null;

            // リフレクションで全フィールドを取得
            Type type = owner.GetType();
            System.Reflection.FieldInfo[] fieldinfos = type.GetFields( System.Reflection.BindingFlags.Public |
                                                                      System.Reflection.BindingFlags.NonPublic |
                                                                      System.Reflection.BindingFlags.Instance |
                                                                      System.Reflection.BindingFlags.DeclaredOnly );
            if ( fieldinfos != null )
            {
                // 全フィールドの中から、UiSetControlを探す
                // (※注意：ここでは1フォームに対してUiSetControlは1つだけという前提で処理しています)
                foreach ( System.Reflection.FieldInfo field in fieldinfos )
                {
                    if ( field.FieldType == typeof( UiSetControl ) )
                    {
                        // 対象フォームのフィールドをオブジェクト化
                        uiSetControl = (field.GetValue( owner ) as UiSetControl);
                        break;
                    }
                }
            }
            // 返却
            return uiSetControl;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        # endregion

        # region [public methods]
        # region [ＵＩ項目設定取得]
        /// <summary>
        /// ＵＩ項目設定取得処理
        /// </summary>
        /// <param name="uiSet">(出力)UI設定情報</param>
        /// <param name="editName">入力項目名</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>ＵＩ設定情報を外部に提供します。</br>
        /// </remarks>
        public int ReadUISet( out UiSet uiSet, string editName )
        {
            uiSet = this._uiSetFileAcs.GetUiSet( this._ownerFormName, editName );
            if ( uiSet != null )
            {
                return 0;
            }
            else
            {
                uiSet = new UiSet();
                return 9;
            }
        }
        /// <summary>
        /// ＵＩ項目設定取得処理（複数対応：リスト）
        /// </summary>
        /// <param name="uiSetList">(出力)設定リスト</param>
        /// <param name="editNames">入力項目名リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>ＵＩ設定情報を外部に提供します。</br>
        /// </remarks>
        public int ReadUISetList( out List<UiSet> uiSetList, List<string> editNames )
        {
            // リスト取得
            uiSetList = this._uiSetFileAcs.GetUiSetList( this._ownerFormName, editNames );

            // リストが空でなければOK
            if ( uiSetList.Count > 0 )
            {
                return 0;
            }
            else
            {
                return 9;
            }
        }
        /// <summary>
        /// ＵＩ項目設定取得処理（複数対応：ディクショナリ）
        /// </summary>
        /// <param name="uiSetDic">(出力)設定ディクショナリ</param>
        /// <param name="editNames">入力項目名リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>ＵＩ設定情報を外部に提供します。</br>
        /// </remarks>
        public int ReadUISetDictionary( out Dictionary<string, UiSet> uiSetDic, List<string> editNames )
        {
            // ディクショナリ取得
            uiSetDic = this._uiSetFileAcs.GetUiSetDictionary( this._ownerFormName, editNames );

            // ディクショナリが空でなければOK
            if ( uiSetDic.Count > 0 )
            {
                return 0;
            }
            else
            {
                return 9;
            }
        }
        # endregion

        # region [入力許可文字パターンチェック]
        /// <summary>
        /// 入力許可文字パターンマッチ判定（全文字列）
        /// </summary>
        /// <param name="tEdit">対象TEdit</param>
        /// <returns></returns>
        public bool CheckMatchingSet( TEdit tEdit )
        {
            return CheckMatchingSet( tEdit.Name, tEdit.Text );
        }
        /// <summary>
        /// 入力許可文字パターンマッチ判定（全文字列）
        /// </summary>
        /// <param name="tNedit">対象TNedit</param>
        /// <returns></returns>
        public bool CheckMatchingSet( TNedit tNedit )
        {
            return CheckMatchingSet( tNedit.Name, tNedit.Text );
        }
        /// <summary>
        /// 入力許可文字パターンマッチ判定（全文字列）
        /// </summary>
        /// <param name="editName">入力項目名</param>
        /// <param name="fullText">入力済みのすべての文字列</param>
        /// <returns>true: 合致する／false: 合致しない</returns>
        public bool CheckMatchingSet( string editName, string fullText )
        {
            //-------------------------------------------------
            // 入力パターン文字取得
            //-------------------------------------------------
            TLibAvatar.EnableChars enableChars = GetEnableChars( editName );


            //-------------------------------------------------
            // TLibAvatarの全角判定は,文字列の全文字対象だと効率が良くないので、細工する。
            //-------------------------------------------------
            // 全角文字チェック(非許可なら除外チェック)
            if ( !enableChars.Word )
            {
                // バイト数≠文字数なら全角を含むと判断する
                Encoding encoding = Encoding.GetEncoding( "Shift-JIS" );
                if ( encoding.GetByteCount( fullText ) != fullText.Length )
                {
                    return false;
                }
            }
            // 以上で全角チェック済みなので,以下では許可扱いしてチェックをスキップする
            enableChars.Word = true;


            //-------------------------------------------------
            // 全文字チェック
            //-------------------------------------------------
            // 文字数分ループ
            for ( int index = 0; index < fullText.Length; index++ )
            {
                // １文字ずつ判定処理する
                if ( TLibAvatar.CheckCharactor( fullText[index], enableChars ) == false )
                {
                    return false;
                }
            }


            // 以上のチェック処理で問題なければＯＫ
            return true;
        }
        /// <summary>
        /// 入力許可文字パターンマッチ判定（文字単独）
        /// </summary>
        /// <param name="editName">入力項目名</param>
        /// <param name="addingChar">今回入力文字</param>
        /// <returns>true: 合致する／false: 合致しない</returns>
        public bool CheckMatchingSet( string editName, char addingChar )
        {
            // 入力許可文字パターンにマッチしているか判定
            return TLibAvatar.CheckCharactor( addingChar, GetEnableChars( editName ) );
        }
        /// <summary>
        /// 入力許可文字パターン取得処理
        /// </summary>
        /// <param name="editName">入力項目名</param>
        /// <returns>入力許可文字パターン</returns>
        public TLibAvatar.EnableChars GetEnableChars( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                return new TLibAvatar.EnableChars( uiSet.AllowSpace, uiSet.AllowSign, uiSet.AllowAlpha, uiSet.AllowKana, uiSet.AllowNum, uiSet.AllowNumSign, uiSet.AllowWord );
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////// 設定がみつからなかった場合は、全て許可しないものとみなす
                ////return new TLibAvatar.EnableChars( false, false, false, false, false, false, false );
                // 設定がみつからなかった場合は、全て許可するものとみなす
                return new TLibAvatar.EnableChars( true, true, true, true, true, true, true );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            }
        }
        # endregion

        # region [ゼロ埋め後テキスト取得]
        /// <summary>
        /// ゼロ埋め後テキスト取得処理
        /// </summary>
        /// <param name="editName">入力項目名</param>
        /// <param name="fullText">入力済みテキスト</param>
        /// <returns>ゼロ埋めしたテキスト</returns>
        public string GetZeroPaddedText( string editName, string fullText )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                if ( uiSet.PadZero )
                {
                    return GetZeroPaddedTextProc( fullText, uiSet.Column, uiSet.AllowZeroCode );
                }
                else
                {
                    // ゼロ詰めしない項目ならそのまま返す
                    return fullText;
                }
            }
            else
            {
                // 設定がなければそのまま返す
                return fullText;
            }
        }
        /// <summary>
        /// ゼロ埋めキャンセル後テキスト取得処理
        /// </summary>
        /// <param name="editName">入力項目名</param>
        /// <param name="fullText">入力済みテキスト</param>
        /// <returns>ゼロ埋めキャンセルしたテキスト</returns>
        public string GetZeroPadCanceledText( string editName, string fullText )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                if ( uiSet.PadZero )
                {
                    return GetZeroPadCanceledTextProc( fullText, uiSet.AllowZeroCode );
                }
                else
                {
                    // ゼロ詰めしない項目ならそのまま返す
                    return fullText;
                }
            }
            else
            {
                // 設定がなければそのまま返す
                return fullText;
            }
        }

        # endregion

        # region [設定の強制呼び出し]
        /// <summary>
        /// フォーム設定の呼び出し処理(親Form向け)
        /// </summary>
        /// <remarks>
        /// <br>※(特殊なケースへの対応)</br>
        /// <br>  Loadイベント前にUI設定を適用する必要がある場合のみ、このメソッドを使用して下さい。</br>
        /// <br>　通常はこのメソッドを呼び出す必要はありません。</br>
        /// </remarks>
        public void SettingFormBeforeLoad()
        {
            //-------------------------------------------------------
            // このメソッドが処理されれば、Load時に同じ処理は不要なのでハンドラを削除する
            //-------------------------------------------------------
            if ( base.OwnerForm is ContainerControl )
            {
                // イベントデリゲートを削除する
                if ( base.OwnerForm is Form )
                {
                    (base.OwnerForm as Form).Load -= this.OwnerFormOnLoad;
                    //(base.OwnerForm as Form).ControlAdded -= this.OwnerFormOnControlAdded;
                }

                if ( base.OwnerForm is UserControl )
                {
                    (base.OwnerForm as UserControl).Load -= this.OwnerFormOnLoad;
                    //(base.OwnerForm as UserControl).ControlAdded -= this.OwnerFormOnControlAdded;
                }
            }
            //-------------------------------------------------------
            // 処理呼び出し
            //-------------------------------------------------------
            OwnerFormOnLoad( this, new EventArgs() );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 全項目ゼロ詰めテキスト設定処理
        /// </summary>
        public void SettingAllControlsZeroPaddedText()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 DEL
            //if ( this.OwnerForm is Control )
            //{
            //    SettingChildControlZeroPaddedText( this.OwnerForm as Control );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
            if ( stc_UiSetControlList != null )
            {
                // プロセス内の全てのUiSetControlに対して処理
                foreach ( UiSetControl uiSetControl in stc_UiSetControlList )
                {
                    try
                    {
                        if ( uiSetControl != null )
                        {
                            uiSetControl.SettingAllControlsZeroPaddedTextProc();
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                // 自分自身だけ処理
                this.SettingAllControlsZeroPaddedTextProc();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
        /// <summary>
        /// 全項目ゼロ詰めテキスト設定処理
        /// </summary>
        internal void SettingAllControlsZeroPaddedTextProc()
        {
            if ( this.OwnerForm is Control )
            {
                SettingChildControlZeroPaddedText( this.OwnerForm as Control );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
        # endregion

        # region [設定値取得処理（設定要素単独）]
        /// <summary>
        /// ＩＭＥモード取得
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        public ImeMode GetSettingImeMode( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                // ＩＭＥモード返却
                return uiSet.ImeMode;
            }
            else
            {
                // 制御なし（既定）
                return ImeMode.NoControl;
            }
        }
        /// <summary>
        /// 桁数取得処理
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        public int GetSettingColumnCount( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                // 桁数返却
                return uiSet.Column;
            }
            else
            {
                // 例外
                return 0;
            }
        }
        /// <summary>
        /// 左右揃え位置取得
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        public Infragistics.Win.HAlign GetSettingHAlign( string editName )
        {
            UiSet uiSet;
            if ( ReadUISet( out uiSet, editName ) == 0 )
            {
                // 左右揃え位置
                return uiSet.HAlign;
            }
            else
            {
                // 制御なし（既定）
                return Infragistics.Win.HAlign.Default;
            }
        }
        # endregion
        # endregion

        # region [private methods]
        /// <summary>
        /// ＵＩ設定取得処理
        /// </summary>
        private void ReadUISetting( ContainerControl ownerForm )
        {
            // OwnerFormを持つアセンブリの名称を取得
            string asmName = Path.GetFileNameWithoutExtension( ownerForm.GetType().Assembly.GetName().Name );
            // OwnerFormの名称を取得
            this._ownerFormName = ownerForm.GetType().Name;

            // アセンブリ毎の設定取得
            _uiSetFileAcs.ReadXML( asmName );
        }
        /// <summary>
        /// ＵＩ入力項目設定処理
        /// </summary>
        /// <remarks>
        /// <br>OwnerFormのロード時にこのメソッドを呼びます。</br>
        /// </remarks>
        private void SettingUI()
        {
            //// OwnerFormを持つアセンブリの名称を取得
            //string asmName = Path.GetFileNameWithoutExtension( (this.OwnerForm as ContainerControl).GetType().Assembly.GetName().Name );
            //// OwnerFormの名称を取得
            //this._ownerFormName = (this.OwnerForm as ContainerControl).GetType().Name;

            //// アセンブリ毎の設定取得
            //_uiSetFileAcs.ReadXML( asmName );

            // 各種設定値を適用する。
            this.PropertyChange();
        }
        /// <summary>
        /// フォーム及びフォーム上に配置されているコンポーネントの設定を行います。
        /// </summary>
        private void PropertyChange()
        {
            if ( this.OwnerForm is ContainerControl && !(this.OwnerForm as ContainerControl).IsDisposed )
            {
                ContainerControl owner = (this.OwnerForm as ContainerControl);

                object obj = null;

                if ( DesignMode )
                {
                    // デザイン時は処理しない
                }
                else
                {
                    // 実行時はリフレクションを使用して Form のフィールドからコンポーネントの一覧を取得する
                    Type type = owner.GetType();
                    System.Reflection.FieldInfo[] fieldinfos = type.GetFields( System.Reflection.BindingFlags.Public |
                                                                              System.Reflection.BindingFlags.NonPublic |
                                                                              System.Reflection.BindingFlags.Instance |
                                                                              System.Reflection.BindingFlags.DeclaredOnly );

                    if ( fieldinfos != null )
                    {
                        foreach ( System.Reflection.FieldInfo field in fieldinfos )
                        {
                            obj = field.GetValue( owner );

                            // 取得したフィールドが Component クラスを継承しており、且つ UiSetControl クラス
                            // では無い場合にプロパティの変更処理を行う。(無駄なループ処理を省く)
                            if ( obj is Component && !(obj is UiSetControl) )
                            {
                                this.SettingPropertys( obj );
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// コントロール毎のプロパティ設定処理
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>
        /// <br>主にTEdit/TNeditに対して処理を行います。</br>
        /// <br>入力時の処理制御を行う為、TArrowKeyControl/TRetKeyControlに対しても処理を行います。</br>
        /// </remarks>
        private void SettingPropertys( object obj )
        {
            if ( obj is TEdit )
            {
                # region [for TEdit/TNedit]

                TEdit tEdit = (obj as TEdit);

                // コントロールの名称から設定内容を取得
                UiSet uiSet = _uiSetFileAcs.GetUiSet( _ownerFormName, tEdit.Name );

                // 設定を適用
                this.UISetting( tEdit, uiSet, ref this._padZeroEditList, ref this._inputableZeroCodePadZeroEditList );
                # endregion
            }
            else if ( obj is TArrowKeyControl )
            {
                # region [for TArrowKeyControl]
                //------------------------------------------------------------------------------
                // Formで設定される、TArrowKeyControl の ChangeFocusイベントよりも早いタイミングで
                // ゼロ詰めする為に細工する。
                //------------------------------------------------------------------------------

                TArrowKeyControl akControl = (obj as TArrowKeyControl);
                if ( ChangeFocus != null )
                {
                    // Formがセットするイベントハンドラを一時的に削除
                    akControl.ChangeFocus -= ChangeFocus;
                    // ゼロ詰めが先に処理されるように設定し直す。
                    akControl.ChangeFocus += new ChangeFocusEventHandler( akControl_ChangeFocus );
                    akControl.ChangeFocus += ChangeFocus;
                }
                else
                {
                    akControl.ChangeFocus += new ChangeFocusEventHandler( akControl_ChangeFocus );
                }
                # endregion
            }
            else if ( obj is TRetKeyControl )
            {
                # region [for TRetKeyControl]
                //------------------------------------------------------------------------------
                // Formで設定される、TRetKeyControl の ChangeFocusイベントよりも早いタイミングで
                // ゼロ詰めする為に細工する。
                // (※TArrowKeyControlと同じChangeFocusイベントハンドラがセットされている前提で処理しています)
                //------------------------------------------------------------------------------
                TRetKeyControl trkControl = (obj as TRetKeyControl);
                if ( ChangeFocus != null )
                {
                    // Formがセットするイベントハンドラを一時的に削除
                    trkControl.ChangeFocus -= ChangeFocus;
                    // ゼロ詰めが先に処理されるように設定し直す。
                    trkControl.ChangeFocus += new ChangeFocusEventHandler( akControl_ChangeFocus );
                    trkControl.ChangeFocus += ChangeFocus;

                }
                # endregion
            }
        }
        /// <summary>
        /// 設定クラスの設定値を適用（TEdit/TNedit対象）
        /// </summary>
        /// <param name="tEdit"></param>
        /// <param name="uiSet"></param>
        /// <param name="padZeroEditList"></param>
        /// <param name="inputableZeroCodePadZeroEditList"></param>
        /// <remarks>
        /// <br>この処理が、実際の入力項目に対する設定処理です。</br>
        /// </remarks>
        private void UISetting( TEdit tEdit, UiSet uiSet, ref List<string> padZeroEditList, ref List<string> inputableZeroCodePadZeroEditList )
        {
            // ＸＭＬで設定されていない項目ならば、処理しない
            if ( uiSet == null )
            {
                return;
            }

            //--------------------------------------------------------
            // プロパティのセット
            //--------------------------------------------------------
            tEdit.ExtEdit.Column = uiSet.Column;                    // 桁数
            tEdit.ExtEdit.EnableChars.Alpha = uiSet.AllowAlpha;     // アルファベット可
            tEdit.ExtEdit.EnableChars.Kana = uiSet.AllowKana;       // カナ可
            tEdit.ExtEdit.EnableChars.Num = uiSet.AllowNum;         // 数字可
            tEdit.ExtEdit.EnableChars.NumSign = uiSet.AllowNumSign; // 数値記号可
            tEdit.ExtEdit.EnableChars.Sign = uiSet.AllowSign;       // 記号可
            tEdit.ExtEdit.EnableChars.Space = uiSet.AllowSpace;     // スペース可
            tEdit.ExtEdit.EnableChars.Word = uiSet.AllowWord;       // 全角文字可
            tEdit.Appearance.TextHAlign = uiSet.HAlign;             // 左右揃え
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            tEdit.ActiveAppearance.TextHAlign = uiSet.HAlign;       // アクティブ時左右揃え
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            tEdit.ImeMode = uiSet.ImeMode;                          // IMEモード


            // 項目の横幅
            # region [横幅]
            if ( _editWidthSettingWay == EditWidthSettingWayState.None )
            {
                // 制御しない
            }
            else if ( _editWidthSettingWay == EditWidthSettingWayState.UseAutoWidth )
            {
                // AutoWidthを使用する
                tEdit.ExtEdit.AutoWidth = true;                 // 自動幅調整
            }
            else if ( _editWidthSettingWay == EditWidthSettingWayState.CalculateCollapsing )
            {
                // 計算値を使用する
                // 必要な幅を計算し,小さくなる場合のみセットする
                int resultWidth = this.GetEditWidth( tEdit );   // 幅算出
                if ( resultWidth < tEdit.Width )
                {
                    tEdit.Width = resultWidth;
                }
            }
            # endregion

            // 数値エディットならゼロ詰め設定を追加
            # region [数値エディット]
            if ( tEdit is TNedit )
            {
                if ( uiSet.PadZero )
                {
                    (tEdit as TNedit).NumEdit.ZeroSupp = emZeroSupp.zsFILL;     // ゼロ詰めする
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //(tEdit as TNedit).NumEdit.ZeroDisp = false;                 // ALLゼロ表示しない
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    (tEdit as TNedit).NumEdit.ZeroDisp = uiSet.AllowZeroCode;                 // ALLゼロ表示しない
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }
            # endregion


            //--------------------------------------------------------
            // イベント処理のセット
            //--------------------------------------------------------
            # region [イベント]
            if ( uiSet.PadZero )
            {
                if ( uiSet.AllowZeroCode )
                {
                    //--------------------------------------------------
                    // ゼロ入力可能・ゼロ詰めコントロール
                    //--------------------------------------------------

                    tEdit.Enter += new EventHandler( InputableZeroCdPadZeroTEdit_Enter );  // 進入イベント

                    if ( this.ChangeFocus == null )
                    {
                        // ｾﾞﾛ入力→ｾﾞﾛが入力された事とする
                        tEdit.Leave += new EventHandler( InputableZeroCdPadZeroTEdit_Leave );  // 脱出イベント
                    }
                    else
                    {
                        // Leave実行をTArrowKeyControl.ChangeFocusよりも早く行う為、
                        // Leaveのイベントハンドラには登録せず、
                        // リストに追加しておいて直前に処理する。
                        inputableZeroCodePadZeroEditList.Add( tEdit.Name );
                    }
                }
                else
                {
                    //--------------------------------------------------
                    // ゼロ入力不可・ゼロ詰めコントロール
                    //--------------------------------------------------
                    tEdit.Enter += new EventHandler( PadZeroTEdit_Enter );  // 進入イベント

                    if ( this.ChangeFocus == null )
                    {
                        // ｾﾞﾛ入力→未入力にする
                        tEdit.Leave += new EventHandler( PadZeroTEdit_Leave );  // 脱出イベント
                    }
                    else
                    {
                        // Leave実行をTArrowKeyControl.ChangeFocusよりも早く行う為、
                        // Leaveのイベントハンドラには登録せず、
                        // リストに追加しておいて直前に処理する。
                        padZeroEditList.Add( tEdit.Name );
                    }
                
                }
            }
            # endregion
        }

        /// <summary>
        /// TEdit/TNeditのwidth取得処理
        /// </summary>
        /// <param name="tEdit"></param>
        /// <returns></returns>
        private int GetEditWidth( TEdit tEdit )
        {
            // １文字当たりの平均幅
            float wAveCharWidth;

            // コントロールのグラフィックを取得
            Graphics editGraphics = tEdit.CreateGraphics();
            // 仮に描画する文字列を定義
            string drawString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //----------------------------------------
            //  利用するフォント作成
            //----------------------------------------
            # region [利用するフォント作成]

            System.Drawing.Font drawFont;
            string fontName;
            float fontSize;
            System.Drawing.FontStyle fontStyle = 0;

            // フォント名の決定
            if ( (tEdit.Appearance.FontData.Name == "") || (tEdit.Appearance.FontData.Name == null) )
            {
                fontName = tEdit.Font.Name;
            }
            else
            {
                fontName = tEdit.Appearance.FontData.Name;
            }
            // フォントサイズの決定
            if ( tEdit.Appearance.FontData.SizeInPoints == 0.0 )
            {
                fontSize = tEdit.Font.SizeInPoints;
            }
            else
            {
                fontSize = tEdit.Appearance.FontData.SizeInPoints;
            }
            // ボールドの指定
            if ( tEdit.Appearance.FontData.Bold == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Bold == true )
                    fontStyle |= System.Drawing.FontStyle.Bold;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Bold == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Bold;
            }
            // イタリックの指定
            if ( tEdit.Appearance.FontData.Italic == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Italic == true )
                    fontStyle |= System.Drawing.FontStyle.Italic;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Italic == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Italic;
            }
            // 取消線の指定
            if ( tEdit.Appearance.FontData.Strikeout == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Strikeout == true )
                    fontStyle |= System.Drawing.FontStyle.Strikeout;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Strikeout == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Strikeout;
            }
            // 下線の指定
            if ( tEdit.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.Default )
            {
                if ( tEdit.Font.Underline == true )
                    fontStyle |= System.Drawing.FontStyle.Underline;
            }
            else
            {
                if ( tEdit.Appearance.FontData.Underline == Infragistics.Win.DefaultableBoolean.True )
                    fontStyle |= System.Drawing.FontStyle.Underline;
            }
            // 使用されているフォントを取得
            drawFont = new Font( fontName, fontSize, fontStyle );
            # endregion

            // 文字列を表示する際のフォーマットを指定
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            SizeF wSizeF;

            // 文字列フォーマットを設定
            drawFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            // 文字列の表示に必要なサイズを取得
            wSizeF = editGraphics.MeasureString( drawString, drawFont, 640, drawFormat );
            // アルファベット26文字分の文字幅・・・26で割れば平均文字幅
            wAveCharWidth = wSizeF.Width / 26;

            // メモリを消費するオブジェクトを解放
            # region [Dispose]
            drawFont.Dispose();
            editGraphics.Dispose();
            # endregion

            return (int)Math.Floor( wAveCharWidth * (tEdit.ExtEdit.Column + 2) );
        }
        /// <summary>
        /// ゼロ埋め後テキスト取得処理実装
        /// </summary>
        /// <param name="fullText">入力済みテキスト</param>
        /// <param name="columnCount">入力可能桁数</param>
        /// <param name="allowZeroCode">ｾﾞﾛｺｰﾄﾞ入力許可</param>
        /// <returns>ゼロ埋めしたテキスト</returns>
        private static string GetZeroPaddedTextProc( string fullText, int columnCount, bool allowZeroCode )
        {
            if ( fullText.Trim() != string.Empty )
            {
                if ( allowZeroCode )
                {
                    // ゼロ詰め処理
                    return fullText.PadLeft( columnCount, '0' );
                }
                else
                {
                    if ( GetIntFromString( fullText.Trim(), -1 ) == 0 )
                    {
                        // 値ゼロならば空白
                        return string.Empty;
                    }
                    else
                    {
                        // ゼロ詰め処理
                        return fullText.PadLeft( columnCount, '0' );
                    }
                }
            }
            else
            {
                if ( allowZeroCode )
                {
                    // ゼロ詰め処理
                    return fullText.PadLeft( columnCount, '0' );
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// ゼロ埋めキャンセル後テキスト取得処理実装
        /// </summary>
        /// <param name="fullText">入力済みテキスト</param>
        /// <param name="allowZeroCd"></param>
        /// <returns>ゼロ埋めキャンセルしたテキスト</returns>
        private static string GetZeroPadCanceledTextProc( string fullText, bool allowZeroCd )
        {
            if ( fullText.Trim() != string.Empty )
            {
                if ( !allowZeroCd )
                {
                    // 先頭のゼロ詰めを削除
                    while ( fullText.StartsWith( "0" ) )
                    {
                        fullText = fullText.Substring( 1, fullText.Length - 1 );
                    }
                }
                return fullText;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 子コントロールのゼロ詰めテキスト一括設定処理
        /// </summary>
        /// <param name="parentControl"></param>
        private void SettingChildControlZeroPaddedText( Control parentControl )
        {
            // 子コントロールに対して処理する
            foreach ( Control control in parentControl.Controls )
            {
                if ( control is TEdit )
                {
                    // ゼロ埋めテキストで置き換える
                    control.Text = GetZeroPaddedText( control.Name, control.Text );
                }

                // 再帰呼び出し
                SettingChildControlZeroPaddedText( control );
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
            // 設定実行
            SettingUI();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 中ボタンキャンセル用メッセージフィルタ追加
            // (FormがWindowsMessageを受け取る前に処理されます)
            System.Windows.Forms.Application.AddMessageFilter( MButtonCancelMessageFilter.GetInstance() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        ///// <summary>
        ///// コントロール追加イベント処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>
        ///// <br>コントロールに共通の設定を行います。</br>
        ///// <br>※ここではコントロール名毎の設定は行えません。</br>
        ///// </remarks>
        //void OwnerFormOnControlAdded( object sender, ControlEventArgs e )
        //{
        //    if ( e.Control != null )
        //    {
        //        e.Control.ControlAdded += this.OwnerFormOnControlAdded;

        //        if ( e.Control is TEdit )
        //        {
        //            // AutoWidthをキャンセルする
        //            (e.Control as TEdit).ExtEdit.AutoWidth = false;
        //        }
        //    }
        //}
        # endregion ■ OwnerFormのイベント ■

        # region ■ TArrowKeyControlのイベント ■
        /// <summary>
        /// TArrowKeyControlのChangeFocusイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>※この処理が、Formにて設定されるChangeFocus処理よりも</br>
        /// <br>　早いタイミングで処理されるよう制御しています。</br>
        /// </remarks>
        void akControl_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == null )
            {
                return;
            }

            if ( _padZeroEditList.Contains( e.PrevCtrl.Name ) )
            {
                // コードゼロ詰め＋ゼロ入力は削除
                PadZeroTEdit_Leave( e.PrevCtrl, new EventArgs() );
            }
            else if ( _inputableZeroCodePadZeroEditList.Contains( e.PrevCtrl.Name ) )
            {
                // コードゼロ詰め＋ゼロあり
                InputableZeroCdPadZeroTEdit_Leave( e.PrevCtrl, new EventArgs() );
            }
        }
        # endregion ■ TArrowKeyControlのイベント ■

        # region ■ TEdit/TNeditのイベント ■
        /// <summary>
        /// ゼロ詰めを行うTEditの進入イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void PadZeroTEdit_Enter( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // 先頭のゼロ詰めを削除
            tEdit.Text = GetZeroPadCanceledTextProc( tEdit.Text, false );
        }
        /// <summary>
        /// ゼロ詰めを行うTEditの進入イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void InputableZeroCdPadZeroTEdit_Enter( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // 先頭のゼロ詰めを削除
            tEdit.Text = GetZeroPadCanceledTextProc( tEdit.Text, true );
        }
        /// <summary>
        /// ゼロ詰めを行うTEditの脱出イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>TArrowKeyControlのChangeFocusが設定されている場合、</br>
        /// <br>このイベント処理は直接TEditのLeaveイベントハンドラに登録せず、</br>
        /// <br>TArrowKeyControlのChangeFocusの直前に処理されるようにします。</br>
        /// </remarks>
        static void PadZeroTEdit_Leave( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // ゼロ詰め処理(値=ｾﾞﾛならｽﾍﾟｰｽにする)
            tEdit.Text = GetZeroPaddedTextProc( tEdit.Text, tEdit.ExtEdit.Column, false );
        }
        /// <summary>
        /// ゼロ詰めを行うTEditの脱出イベント処理（ｾﾞﾛｺｰﾄﾞを許可する）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void InputableZeroCdPadZeroTEdit_Leave( object sender, EventArgs e )
        {
            TEdit tEdit = (sender as TEdit);

            // ゼロ詰め処理(値=ｾﾞﾛでもそのまま)
            tEdit.Text = GetZeroPaddedTextProc( tEdit.Text, tEdit.ExtEdit.Column, true );
        }
        /// <summary>
        /// 文字列→数値変換
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        static int GetIntFromString( string str, int defaultValue )
        {
            try
            {
                return Int32.Parse( str );
            }
            catch
            {
                return defaultValue;
            }
        }
        # endregion ■ TEdit/TNeditのイベント ■
    }
    # endregion ■ UI入力項目設定コンポーネント ■

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
    # region ■ マウス中ボタンキャンセル用メッセージフィルタ ■
    /// <summary>
    /// マウス中ボタンキャンセル用メッセージフィルタ
    /// </summary>
    /// <remarks>このメッセージフィルタで、中ボタンを無効化します。</remarks>
    internal class MButtonCancelMessageFilter : IMessageFilter
    {
        /// <summary>
        /// インスタンス(singleton)
        /// </summary>
        private static MButtonCancelMessageFilter stc_mButtonCancelMessageFilter;
        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns></returns>
        public static MButtonCancelMessageFilter GetInstance()
        {
            if ( stc_mButtonCancelMessageFilter == null )
            {
                stc_mButtonCancelMessageFilter = new MButtonCancelMessageFilter();
            }
            return stc_mButtonCancelMessageFilter;
        }
        /// <summary>
        /// プライベートコンストラクタ
        /// </summary>
        private MButtonCancelMessageFilter()
        {
        }
        /// <summary>
        /// メッセージに対するフィルタ処理
        /// </summary>
        /// <param name="m"></param>
        /// <returns>true: 処理完了 / false: 処理未完了</returns>
        /// <remarks>この処理はFormがWindowsMessageを受け取る前に処理されます。</remarks>
        public bool PreFilterMessage( ref Message m )
        {
            // 中ボタンイベントはキャンセルする
            if ( m.Msg == (int)WindowsMessages.WM_MBUTTONDBLCLK ||
                m.Msg == (int)WindowsMessages.WM_MBUTTONDOWN ||
                m.Msg == (int)WindowsMessages.WM_MBUTTONUP )
            {
                return true;
            }

            return false;
        }
    }
    # endregion

    # region [WindowsMessages]
    /// <summary>
    /// ウィンドウズメッセージ
    /// </summary>
    internal enum WindowsMessages : uint
    {
        WM_ACTIVATE = 0x6,
        WM_ACTIVATEAPP = 0x1C,
        WM_AFXFIRST = 0x360,
        WM_AFXLAST = 0x37F,
        WM_APP = 0x8000,
        WM_ASKCBFORMATNAME = 0x30C,
        WM_CANCELJOURNAL = 0x4B,
        WM_CANCELMODE = 0x1F,
        WM_CAPTURECHANGED = 0x215,
        WM_CHANGECBCHAIN = 0x30D,
        WM_CHAR = 0x102,
        WM_CHARTOITEM = 0x2F,
        WM_CHILDACTIVATE = 0x22,
        WM_CLEAR = 0x303,
        WM_CLOSE = 0x10,
        WM_COMMAND = 0x111,
        WM_COMPACTING = 0x41,
        WM_COMPAREITEM = 0x39,
        WM_CONTEXTMENU = 0x7B,
        WM_COPY = 0x301,
        WM_COPYDATA = 0x4A,
        WM_CREATE = 0x1,
        WM_CTLCOLORBTN = 0x135,
        WM_CTLCOLORDLG = 0x136,
        WM_CTLCOLOREDIT = 0x133,
        WM_CTLCOLORLISTBOX = 0x134,
        WM_CTLCOLORMSGBOX = 0x132,
        WM_CTLCOLORSCROLLBAR = 0x137,
        WM_CTLCOLORSTATIC = 0x138,
        WM_CUT = 0x300,
        WM_DEADCHAR = 0x103,
        WM_DELETEITEM = 0x2D,
        WM_DESTROY = 0x2,
        WM_DESTROYCLIPBOARD = 0x307,
        WM_DEVICECHANGE = 0x219,
        WM_DEVMODECHANGE = 0x1B,
        WM_DISPLAYCHANGE = 0x7E,
        WM_DRAWCLIPBOARD = 0x308,
        WM_DRAWITEM = 0x2B,
        WM_DROPFILES = 0x233,
        WM_ENABLE = 0xA,
        WM_ENDSESSION = 0x16,
        WM_ENTERIDLE = 0x121,
        WM_ENTERMENULOOP = 0x211,
        WM_ENTERSIZEMOVE = 0x231,
        WM_ERASEBKGND = 0x14,
        WM_EXITMENULOOP = 0x212,
        WM_EXITSIZEMOVE = 0x232,
        WM_FONTCHANGE = 0x1D,
        WM_GETDLGCODE = 0x87,
        WM_GETFONT = 0x31,
        WM_GETHOTKEY = 0x33,
        WM_GETICON = 0x7F,
        WM_GETMINMAXINFO = 0x24,
        WM_GETOBJECT = 0x3D,
        WM_GETSYSMENU = 0x313,
        WM_GETTEXT = 0xD,
        WM_GETTEXTLENGTH = 0xE,
        WM_HANDHELDFIRST = 0x358,
        WM_HANDHELDLAST = 0x35F,
        WM_HELP = 0x53,
        WM_HOTKEY = 0x312,
        WM_HSCROLL = 0x114,
        WM_HSCROLLCLIPBOARD = 0x30E,
        WM_ICONERASEBKGND = 0x27,
        WM_IME_CHAR = 0x286,
        WM_IME_COMPOSITION = 0x10F,
        WM_IME_COMPOSITIONFULL = 0x284,
        WM_IME_CONTROL = 0x283,
        WM_IME_ENDCOMPOSITION = 0x10E,
        WM_IME_KEYDOWN = 0x290,
        WM_IME_KEYLAST = 0x10F,
        WM_IME_KEYUP = 0x291,
        WM_IME_NOTIFY = 0x282,
        WM_IME_REQUEST = 0x288,
        WM_IME_SELECT = 0x285,
        WM_IME_SETCONTEXT = 0x281,
        WM_IME_STARTCOMPOSITION = 0x10D,
        WM_INITDIALOG = 0x110,
        WM_INITMENU = 0x116,
        WM_INITMENUPOPUP = 0x117,
        WM_INPUT = 0x00FF,
        WM_INPUTLANGCHANGE = 0x51,
        WM_INPUTLANGCHANGEREQUEST = 0x50,
        WM_KEYDOWN = 0x100,
        WM_KEYFIRST = 0x100,
        WM_KEYLAST = 0x108,
        WM_KEYUP = 0x101,
        WM_KILLFOCUS = 0x8,
        WM_LBUTTONDBLCLK = 0x203,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_MBUTTONDBLCLK = 0x209,
        WM_MBUTTONDOWN = 0x207,
        WM_MBUTTONUP = 0x208,
        WM_MDIACTIVATE = 0x222,
        WM_MDICASCADE = 0x227,
        WM_MDICREATE = 0x220,
        WM_MDIDESTROY = 0x221,
        WM_MDIGETACTIVE = 0x229,
        WM_MDIICONARRANGE = 0x228,
        WM_MDIMAXIMIZE = 0x225,
        WM_MDINEXT = 0x224,
        WM_MDIREFRESHMENU = 0x234,
        WM_MDIRESTORE = 0x223,
        WM_MDISETMENU = 0x230,
        WM_MDITILE = 0x226,
        WM_MEASUREITEM = 0x2C,
        WM_MENUCHAR = 0x120,
        WM_MENUCOMMAND = 0x126,
        WM_MENUDRAG = 0x123,
        WM_MENUGETOBJECT = 0x124,
        WM_MENURBUTTONUP = 0x122,
        WM_MENUSELECT = 0x11F,
        WM_MOUSEACTIVATE = 0x21,
        WM_MOUSEFIRST = 0x200,
        WM_MOUSEHOVER = 0x2A1,
        WM_MOUSELAST = 0x20A,
        WM_MOUSELEAVE = 0x2A3,
        WM_MOUSEMOVE = 0x200,
        WM_MOUSEWHEEL = 0x20A,
        WM_MOUSEHWHEEL = 0x20E,
        WM_MOVE = 0x3,
        WM_MOVING = 0x216,
        WM_NCACTIVATE = 0x86,
        WM_NCCALCSIZE = 0x83,
        WM_NCCREATE = 0x81,
        WM_NCDESTROY = 0x82,
        WM_NCHITTEST = 0x84,
        WM_NCLBUTTONDBLCLK = 0xA3,
        WM_NCLBUTTONDOWN = 0xA1,
        WM_NCLBUTTONUP = 0xA2,
        WM_NCMBUTTONDBLCLK = 0xA9,
        WM_NCMBUTTONDOWN = 0xA7,
        WM_NCMBUTTONUP = 0xA8,
        WM_NCMOUSEHOVER = 0x2A0,
        WM_NCMOUSELEAVE = 0x2A2,
        WM_NCMOUSEMOVE = 0xA0,
        WM_NCPAINT = 0x85,
        WM_NCRBUTTONDBLCLK = 0xA6,
        WM_NCRBUTTONDOWN = 0xA4,
        WM_NCRBUTTONUP = 0xA5,
        WM_NEXTDLGCTL = 0x28,
        WM_NEXTMENU = 0x213,
        WM_NOTIFY = 0x4E,
        WM_NOTIFYFORMAT = 0x55,
        WM_NULL = 0x0,
        WM_PAINT = 0xF,
        WM_PAINTCLIPBOARD = 0x309,
        WM_PAINTICON = 0x26,
        WM_PALETTECHANGED = 0x311,
        WM_PALETTEISCHANGING = 0x310,
        WM_PARENTNOTIFY = 0x210,
        WM_PASTE = 0x302,
        WM_PENWINFIRST = 0x380,
        WM_PENWINLAST = 0x38F,
        WM_POWER = 0x48,
        WM_PRINT = 0x317,
        WM_PRINTCLIENT = 0x318,
        WM_QUERYDRAGICON = 0x37,
        WM_QUERYENDSESSION = 0x11,
        WM_QUERYNEWPALETTE = 0x30F,
        WM_QUERYOPEN = 0x13,
        WM_QUERYUISTATE = 0x129,
        WM_QUEUESYNC = 0x23,
        WM_QUIT = 0x12,
        WM_RBUTTONDBLCLK = 0x206,
        WM_RBUTTONDOWN = 0x204,
        WM_RBUTTONUP = 0x205,
        WM_RENDERALLFORMATS = 0x306,
        WM_RENDERFORMAT = 0x305,
        WM_SETCURSOR = 0x20,
        WM_SETFOCUS = 0x7,
        WM_SETFONT = 0x30,
        WM_SETHOTKEY = 0x32,
        WM_SETICON = 0x80,
        WM_SETREDRAW = 0xB,
        WM_SETTEXT = 0xC,
        WM_SETTINGCHANGE = 0x1A,
        WM_SHOWWINDOW = 0x18,
        WM_SIZE = 0x5,
        WM_SIZECLIPBOARD = 0x30B,
        WM_SIZING = 0x214,
        WM_SPOOLERSTATUS = 0x2A,
        WM_STYLECHANGED = 0x7D,
        WM_STYLECHANGING = 0x7C,
        WM_SYNCPAINT = 0x88,
        WM_SYSCHAR = 0x106,
        WM_SYSCOLORCHANGE = 0x15,
        WM_SYSCOMMAND = 0x112,
        WM_SYSDEADCHAR = 0x107,
        WM_SYSKEYDOWN = 0x104,
        WM_SYSKEYUP = 0x105,
        WM_SYSTIMER = 0x118,
        WM_TCARD = 0x52,
        WM_TIMECHANGE = 0x1E,
        WM_TIMER = 0x113,
        WM_UNDO = 0x304,
        WM_UNINITMENUPOPUP = 0x125,
        WM_USER = 0x400,
        WM_USERCHANGED = 0x54,
        WM_VKEYTOITEM = 0x2E,
        WM_VSCROLL = 0x115,
        WM_VSCROLLCLIPBOARD = 0x30A,
        WM_WINDOWPOSCHANGED = 0x47,
        WM_WINDOWPOSCHANGING = 0x46,
        WM_WININICHANGE = 0x1A,
        WM_XBUTTONDBLCLK = 0x20D,
        WM_XBUTTONDOWN = 0x20B,
        WM_XBUTTONUP = 0x20C
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
}
