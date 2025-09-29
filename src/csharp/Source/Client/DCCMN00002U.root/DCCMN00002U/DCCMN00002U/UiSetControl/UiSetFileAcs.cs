using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;

using Broadleaf.Xml;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using System.Windows.Forms;
using System.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Windows.Forms
{
    # region ■ DDに対する設定を管理するクラス(Acs) ■
    /// <summary>
    /// ＵＩ入力項目設定ファイルアクセスクラス
    /// </summary>
    public class UiSetFileAcs
    {
        # region [static private fields]
        /// <summary>(static)共通設定XML設定</summary>
        static private UiSetCommon stc_UiSetCommon = null;
        /// <summary>(static)アセンブリ別設定XML設定ディクショナリ</summary>
        static private Dictionary<string, UiSetByAssembly> stc_UiSetByAssemblyDic = null;
        # endregion

        # region [private fields]
        // 項目名に対するDDのディクショナリ
        private Dictionary<DDDicKey, string> _ddDic;
        // DDに対するUI設定のディクショナリ
        private Dictionary<string, UiSet> _uiSetDic;

        // アセンブリ別ＸＭＬファイル名
        private string _uiSetFile;

        // 共通設定ＸＭＬファイル名
        private string _uiSetFileCommon;
        # endregion

        # region [Constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UiSetFileAcs()
        {
            _ddDic = new Dictionary<DDDicKey, string>();
            _uiSetDic = new Dictionary<string, UiSet>();

            _uiSetFile = string.Empty;
            _uiSetFileCommon = GetXMLName( "Common" );
        }
        # endregion

        # region [public Methods]

        # region ■ ＵＩ設定コンポーネント用 ■
        /// <summary>
        /// 設定ＸＭＬファイル読み込み処理
        /// </summary>
        /// <param name="assemblyName"></param>
        public void ReadXML( string assemblyName )
        {
            // アセンブリ別設定ファイル読み込み
            ReadXMLByAssembly( assemblyName );

            // 共通設定ファイル読み込み
            ReadXMLCommon();

            //--------------------------------------------------------
            // ※注意
            //   基本動作として、アセンブリ別設定を優先します。
            //   このReadXMLにより生成される２つのディクショナリを
            //   利用する際に、以下２点を考慮します。
            //   
            //   ①_ddDicはフォーム別で検索して、なければ
            //     共通の設定を使用します。
            //   ②_uiSetDicは意識せずに項目名をキーにして利用します。
            //     これはReadXML内で先にアセンブリ別設定があれば、
            //     共通設定があってもKey重複チェックにより
            //     _uiSetDicに追加されていない為です。
            //--------------------------------------------------------
        }

        /// <summary>
        /// 項目別設定内容取得処理
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public UiSet GetUiSet( string formName, string itemName )
        {
            string itemDDName = string.Empty;

            // ＤＤ取得（フォーム別）
            DDDicKey key = new DDDicKey( formName, itemName );
            if ( _ddDic.ContainsKey( key ) )
            {
                itemDDName = _ddDic[key];
            }
            else
            {
                // フォーム別が無ければ、共通設定
                DDDicKey cmnKey = new DDDicKey(string.Empty,itemName);
                if ( _ddDic.ContainsKey( cmnKey ) )
                {
                    itemDDName = _ddDic[cmnKey];
                }
            }

            // （ＤＤが見つからない）
            if ( itemDDName == string.Empty )
            {
                return null;
            }


            // ＵＩ設定取得
            if ( _uiSetDic.ContainsKey( itemDDName ) )
            {
                return _uiSetDic[itemDDName];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 項目別設定内容取得処理（複数対応：リスト）
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="itemNames"></param>
        /// <returns></returns>
        public List<UiSet> GetUiSetList( string formName, List<string> itemNames )
        {
            List<UiSet> uiSetList = new List<UiSet>();

            foreach ( string itemName in itemNames )
            {
                // １項目取得
                UiSet uiSet = GetUiSet( formName, itemName );
                if ( uiSet != null )
                {
                    // リストに追加
                    uiSetList.Add( uiSet );
                }
            }

            return uiSetList;
        }
        /// <summary>
        /// 項目別設定内容取得処理（複数対応：ディクショナリ）
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="itemNames"></param>
        /// <returns></returns>
        public Dictionary<string, UiSet> GetUiSetDictionary( string formName, List<string> itemNames )
        {
            Dictionary<string, UiSet> uiSetDic = new Dictionary<string, UiSet>();

            foreach ( string itemName in itemNames )
            {
                // １項目取得
                UiSet uiSet = GetUiSet( formName, itemName );
                if ( uiSet != null )
                {
                    // リストに追加
                    uiSetDic.Add( itemName, uiSet );
                }
            }

            return uiSetDic;
        }
        # endregion ■ ＵＩ設定コンポーネント用 ■

        # region ■ 設定ツール用 ■
        /// <summary>
        /// アセンブリ別設定ファイル有無判定処理
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public bool ExistsUiSetByAssembly(string assemblyName)
        {
            string fileName = GetXMLName( assemblyName );
            return File.Exists( fileName );
        }
        /// <summary>
        /// 共通設定読み込み処理（レイアウトのまま取得する）
        /// </summary>
        public UiSetCommon ReadUiSetCommon()
        {
            return this.GetUiSetCommon();
        }
        /// <summary>
        /// アセンブリ別設定読み込み処理（レイアウトのまま取得する）
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public UiSetByAssembly ReadUiSetByAssembly( string assemblyName )
        {
            return this.GetUiSetByAssembly( assemblyName );
        }
        /// <summary>
        /// 共通設定ＸＭＬファイル書き込み
        /// </summary>
        /// <param name="uiSetCommon">書き込み対象の共通設定</param>
        /// <returns></returns>
        public bool WriteXMLCommon( UiSetCommon uiSetCommon )
        {
            bool result = true;
            try
            {
                // 指定インスタンスをシリアライズする
                XmlByteSerializer.Serialize( uiSetCommon, _uiSetFileCommon );
                // キャッシュ更新
                stc_UiSetCommon = uiSetCommon;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// アセンブリ別設定ＸＭＬファイル書き込み
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="uiSetByAssembly"></param>
        /// <returns></returns>
        public bool WriteXMLByAssembly( string assemblyName, UiSetByAssembly uiSetByAssembly )
        {
            bool result = true;
            string fileName = GetXMLName( assemblyName ); 
            try
            {
                // 指定インスタンスをシリアライズする
                XmlByteSerializer.Serialize( uiSetByAssembly, fileName );
                // キャッシュ更新
                if ( stc_UiSetByAssemblyDic == null )
                {
                    stc_UiSetByAssemblyDic = new Dictionary<string, UiSetByAssembly>();
                }
                if ( stc_UiSetByAssemblyDic.ContainsKey( assemblyName ) )
                {
                    stc_UiSetByAssemblyDic[assemblyName] = uiSetByAssembly;
                }
                else
                {
                    stc_UiSetByAssemblyDic.Add( assemblyName, uiSetByAssembly );
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        # endregion ■ 設定ツール用 ■

        # endregion

        # region [private Methods]

        # region [設定読み込み]
        /// <summary>
        /// ＸＭＬ読み込み処理
        /// </summary>
        private void ReadXMLByAssembly( string assemblyName )
        {
            // アセンブリ別設定取得
            UiSetByAssembly uiSetByAssembly = GetUiSetByAssembly( assemblyName );

            // 取得に失敗していたら終了
            if ( uiSetByAssembly == null )
            {
                return;
            }

            // 項目名→ＤＤ名　のディクショナリを生成
            foreach ( UiSetByForm uiSetByForm in uiSetByAssembly.UISetByForms )
            {
                string formName = uiSetByForm.FormName;

                foreach ( UiSetItem uiSetItem in uiSetByForm.UISetItems )
                {
                    DDDicKey dicKey = new DDDicKey( formName, uiSetItem.ItemName );

                    if ( !_ddDic.ContainsKey( dicKey ) )
                    {
                        // 追加
                        _ddDic.Add( dicKey, uiSetItem.ItemDDName );
                    }
                }
            }

            // ＤＤ名→ＵＩ設定　のディクショナリを生成
            foreach ( UiSet uiSet in uiSetByAssembly.UISetDD )
            {
                if ( !_uiSetDic.ContainsKey( uiSet.ItemDDName ) )
                {
                    // 追加
                    _uiSetDic.Add( uiSet.ItemDDName, uiSet );
                }
            }
        }

        /// <summary>
        /// 共通ＸＭＬ読み込み処理
        /// </summary>
        private void ReadXMLCommon()
        {
            // 共通設定取得
            UiSetCommon uiSetCommon = GetUiSetCommon();

            // 取得失敗していたら終了
            if ( uiSetCommon == null )
            {
                return;
            }

            // 項目名→ＤＤ名　のディクショナリを生成
            foreach ( UiSetItem uiSetItem in uiSetCommon.UISetItems )
            {
                DDDicKey dicKey = new DDDicKey( string.Empty, uiSetItem.ItemName );

                if ( !_ddDic.ContainsKey( dicKey ) )
                {
                    // 追加
                    _ddDic.Add( dicKey, uiSetItem.ItemDDName );
                }
            }

            // ＤＤ名→ＵＩ設定　のディクショナリを生成
            foreach ( UiSet uiSet in uiSetCommon.UISetDD )
            {
                if ( !_uiSetDic.ContainsKey( uiSet.ItemDDName ) )
                {
                    // 追加
                    _uiSetDic.Add( uiSet.ItemDDName, uiSet );
                }
            }
        }
        # endregion

        # region [共通処理部品]
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <typeparam name="T">対象型</typeparam>
        /// <param name="fileName">取得元ファイル名</param>
        /// <returns>デシリアライズ結果</returns>
        private T Deserialize<T>( string fileName )
        {
            //----------------------------------------------------------------------
            // ※XmlByteSerializer.DeserializeだとReadOnly時に読み込めず、
            //   UserSettingController.DeserializeUserSettingはフォルダなし時に
            //   フォルダ作成してしまい、ｿﾘｭｰｼｮﾝを格納する開発環境に不要なUISettingフォルダが
            //   作成されてしまうので、以下のように実装。
            //----------------------------------------------------------------------

            T retObject;

            FileStream fs = new FileStream( fileName, FileMode.Open, FileAccess.Read );
            try
            {
                XmlSerializer xs = new XmlSerializer( typeof( T ) );
                retObject = (T)xs.Deserialize( fs );
            }
            finally
            {
                fs.Close();
            }

            return retObject;
        }
        /// <summary>
        /// アセンブリ別設定ファイル名称取得処理
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private string GetXMLName( string assemblyName )
        {
            return string.Format( "{0}\\UISetting_{1}.xml", ConstantManagement_ClientDirectory.UISettings, assemblyName );
        }
        /// <summary>
        /// 共通設定読み込み（キャッシュ考慮）
        /// </summary>
        /// <returns></returns>
        private UiSetCommon GetUiSetCommon()
        {
            UiSetCommon uiSetCommon = null;

            if ( stc_UiSetCommon == null )
            {
                try
                {
                    // デシリアライズでXMLから設定を取得
                    uiSetCommon = Deserialize<UiSetCommon>( _uiSetFileCommon );
                    // キャッシュに退避
                    stc_UiSetCommon = uiSetCommon;
                }
                catch
                {
                }
            }
            else
            {
                // キャッシュから取得
                uiSetCommon = stc_UiSetCommon;
            }

            // 返却
            return uiSetCommon;
        }
        /// <summary>
        /// アセンブリ別設定取得処理（キャッシュ考慮）
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private UiSetByAssembly GetUiSetByAssembly( string assemblyName )
        {
            UiSetByAssembly uiSetByAssembly = null;

            //------------------------------------------------
            // キャッシュとするディクショナリ自体が無ければ生成
            //------------------------------------------------
            if ( stc_UiSetByAssemblyDic == null )
            {
                stc_UiSetByAssemblyDic = new Dictionary<string, UiSetByAssembly>();
            }

            //------------------------------------------------
            // 退避済みならばキャッシュから取得
            //------------------------------------------------
            if ( stc_UiSetByAssemblyDic.ContainsKey( assemblyName ) )
            {
                // キャッシュから設定を取得
                uiSetByAssembly = stc_UiSetByAssemblyDic[assemblyName];
            }
            else
            {
                try
                {
                    // XMLからデシリアライズして設定を取得
                    string fileName = GetXMLName( assemblyName );
                    uiSetByAssembly = Deserialize<UiSetByAssembly>( fileName );
                    // キャッシュ退避
                    stc_UiSetByAssemblyDic.Add( assemblyName, uiSetByAssembly );
                }
                catch
                {
                }
            }

            // 返却
            return uiSetByAssembly;
        }
        # endregion

        # endregion

        # region [DD Dic Key]
        /// <summary>
        /// DDディクショナリキー構造体
        /// </summary>
        /// <remarks>
        /// <br>項目名→ＤＤ名のディクショナリのキー用</br>
        /// </remarks>
        private struct DDDicKey
        {
            private string _formName;
            private string _itemName;

            public string FormName
            {
                get { return _formName; }
                set { _formName = value; }
            }
            public string  ItemName
            {
                get { return _itemName; }
                set { _itemName = value; }
            }
            public DDDicKey( string formName, string itemName )
            {
                _formName = formName;
                _itemName = itemName;
            }
        }
        # endregion

    }
    # endregion ■ DDに対する設定を管理するクラス(Acs) ■

    # region ■ DDに対応する設定クラス ■
    # region [UI設定クラス（ＤＤ別）]
    /// <summary>
    /// UI設定クラス（ＤＤ別）
    /// </summary>
    [Serializable]
    public class UiSet : IComparable<UiSet>
    {
        # region [private Fields]
        /// <summary>備考</summary>
        private string _remarks;
        /// <summary>項目ＤＤ名</summary>
        private string _itemDDName;
        /// <summary>桁数</summary>
        private int _column;
        /// <summary>英字許可</summary>
        private bool _allowAlpha;
        /// <summary>カナ許可</summary>
        private bool _allowKana;
        /// <summary>数字許可</summary>
        private bool _allowNum;
        /// <summary>数値記号許可</summary>
        private bool _allowNumSign;
        /// <summary>記号許可</summary>
        private bool _allowSign;
        /// <summary>スペース許可</summary>
        private bool _allowSpace;
        /// <summary>全角文字許可</summary>
        private bool _allowWord;
        /// <summary>水平位置揃え</summary>
        private Infragistics.Win.HAlign _hAlign;
        /// <summary>ゼロ詰め有無</summary>
        private bool _padZero;
        /// <summary>ＩＭＥモード</summary>
        private ImeMode _imeMode;
        /// <summary>ゼロコード入力許可</summary>
        private bool _allowZeroCode;
        # endregion

        # region [public propaty]
        /// <summary>（設定リマーク）</summary>
        /// <remarks>この項目はPG動作設定には使用しません。設定ファイル用のメモ項目です。</remarks>
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        /// <summary>項目ＤＤ名</summary>
        public string ItemDDName
        {
            get { return _itemDDName; }
            set { _itemDDName = value; }
        }
        /// <summary>桁数</summary>
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }
        /// <summary>英字許可</summary>
        public bool AllowAlpha
        {
            get { return _allowAlpha; }
            set { _allowAlpha = value; }
        }
        /// <summary>カナ許可</summary>
        public bool AllowKana
        {
            get { return _allowKana; }
            set { _allowKana = value; }
        }
        /// <summary>数字許可</summary>
        public bool AllowNum
        {
            get { return _allowNum; }
            set { _allowNum = value; }
        }
        /// <summary>数値記号許可</summary>
        public bool AllowNumSign
        {
            get { return _allowNumSign; }
            set { _allowNumSign = value; }
        }
        /// <summary>記号許可</summary>
        public bool AllowSign
        {
            get { return _allowSign; }
            set { _allowSign = value; }
        }
        /// <summary>スペース許可</summary>
        public bool AllowSpace
        {
            get { return _allowSpace; }
            set { _allowSpace = value; }
        }
        /// <summary>全角文字許可</summary>
        public bool AllowWord
        {
            get { return _allowWord; }
            set { _allowWord = value; }
        }
        /// <summary>水平位置揃え</summary>
        public Infragistics.Win.HAlign HAlign
        {
            get { return _hAlign; }
            set { _hAlign = value; }
        }
        /// <summary>ゼロ詰め有無</summary>
        public bool PadZero
        {
            get { return _padZero; }
            set { _padZero = value; }
        }
        /// <summary>ＩＭＥモード</summary>
        public ImeMode ImeMode
        {
            get { return _imeMode; }
            set { _imeMode = value; }
        }
        /// <summary>ゼロコード入力許可</summary>
        public bool AllowZeroCode
        {
            get { return _allowZeroCode; }
            set { _allowZeroCode = value; }
        }
        # endregion

        # region [Constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UiSet()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="itemDDName">項目ＤＤ名</param>
        /// <param name="column">桁数</param>
        /// <param name="allowKana">カナ許可</param>
        /// <param name="allowNum">数字許可</param>
        /// <param name="allowNumSign">数値記号許可</param>
        /// <param name="allowSign">記号許可</param>
        /// <param name="allowSpace">スペース許可</param>
        /// <param name="allowWord">全角文字許可</param>
        /// <param name="hAlign">水平位置揃え</param>
        /// <param name="padZero">ゼロ詰め有無</param>
        /// <param name="allowZeroCode">ゼロコード入力許可</param>
        public UiSet( string itemDDName, int column, bool allowKana, bool allowNum, bool allowNumSign, bool allowSign, bool allowSpace, bool allowWord, Infragistics.Win.HAlign hAlign, bool padZero, bool allowZeroCode )
        {
            _itemDDName = itemDDName;
            _column = column;
            _allowKana = allowKana;
            _allowNum = allowNum;
            _allowNumSign = allowNumSign;
            _allowSign = allowSign;
            _allowSpace = allowSpace;
            _allowWord = allowWord;
            _hAlign = hAlign;
            _padZero = padZero;
            _allowZeroCode = allowZeroCode;
        }
        # endregion

        # region [CompareTo]
        /// <summary>
        /// UiSetクラス向け比較処理
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( UiSet other )
        {
            // 備考で比較
            int result = this.Remarks.CompareTo( other.Remarks );
            if ( result == 0 )
            {
                // ＤＤ名で比較
                result = this.ItemDDName.CompareTo( other.ItemDDName );
            }
            return result;
        }
        # endregion
    }
    # endregion

    # region [DD設定クラス（項目別）]
    /// <summary>
    /// DD設定クラス（項目別）
    /// </summary>
    [Serializable]
    public class UiSetItem : IComparable<UiSetItem>
    {
        # region [private Fields]
        /// <summary>項目名</summary>
        private string _itemName;
        /// <summary>項目ＤＤ名</summary>
        private string _itemDDName;
        # endregion

        # region [public propaty]
        /// <summary>
        /// 項目名
        /// </summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        /// <summary>
        /// 項目ＤＤ名
        /// </summary>
        public string ItemDDName
        {
            get { return _itemDDName; }
            set { _itemDDName = value; }
        }
        # endregion

        # region [CompareTo]
        /// <summary>
        /// UiSetItem向け比較処理
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( UiSetItem other )
        {
            // ＤＤ名で比較
            int result = this.ItemDDName.CompareTo( other.ItemDDName );
            if ( result == 0 )
            {
                // 項目名で比較
                result = this.ItemName.CompareTo( other.ItemName );
            }
            return result;
        }
        # endregion
    }
    # endregion

    # region [UI設定クラス（フォーム別）]
    /// <summary>
    /// UI設定クラス（フォーム別）
    /// </summary>
    [Serializable]
    public class UiSetByForm
    {
        private string _formName;
        private List<UiSetItem> _uiSetItems;

        /// <summary>
        /// フォーム名
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        /// <summary>
        /// ＵＩ設定アイテムリスト
        /// </summary>
        public List<UiSetItem> UISetItems
        {
            get { return _uiSetItems; }
            set { _uiSetItems = value; }
        }
    }
    # endregion

    # region [UI設定クラス（アセンブリ別）]
    /// <summary>
    /// UI設定クラス（アセンブリ別）
    /// </summary>
    [Serializable]
    public class UiSetByAssembly
    {
        private List<UiSetByForm> _uiSetByForm;
        private List<UiSet> _uiSetDD;

        /// <summary>
        /// フォーム別設定リスト
        /// </summary>
        public List<UiSetByForm> UISetByForms
        {
            get { return _uiSetByForm; }
            set { _uiSetByForm = value; }
        }
        /// <summary>
        /// ＤＤ設定リスト
        /// </summary>
        public List<UiSet> UISetDD
        {
            get { return _uiSetDD; }
            set { _uiSetDD = value; }
        }
    }
    # endregion

    # region [UI設定クラス（共通ファイル用）]
    /// <summary>
    /// UI設定クラス（共通ファイル用）
    /// </summary>
    [Serializable]
    public class UiSetCommon
    {
        private List<UiSetItem> _uiSetItems;
        private List<UiSet> _uiSetDD;

        /// <summary>
        /// ＵＩ設定アイテムリスト
        /// </summary>
        public List<UiSetItem> UISetItems
        {
            get { return _uiSetItems; }
            set { _uiSetItems = value; }
        }
        /// <summary>
        /// ＤＤ設定リスト
        /// </summary>
        public List<UiSet> UISetDD
        {
            get { return _uiSetDD; }
            set { _uiSetDD = value; }
        }
    }
    # endregion
    # endregion ■ DDに対応する設定クラス ■

}
