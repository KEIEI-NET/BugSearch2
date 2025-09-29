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
    public class UiMemFileAcs
    {
        # region [static private fields]
        /// <summary>(static)キーリストのディクショナリ（アセンブリ単位）</summary>
        static private Dictionary<string, List<UiMemInputDataKey>> stc_uiMemInputDataKeysDic;
        /// <summary>(static)入力保存ディクショナリ（アセンブリ・フォーム・オプション単位）</summary>
        static private Dictionary<UiMemInputDataKey, UiMemInputDataForm> stc_uiMemInputDataFormDic;
        # endregion

        # region [private fields]
        # endregion

        # region [Constructor]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UiMemFileAcs()
        {
        }
        # endregion

        # region [public Methods]
        /// <summary>
        /// 入力保存ファイル読み込み
        /// </summary>
        /// <param name="uiMemInputDataForm"></param>
        /// <param name="assemblyName"></param>
        /// <param name="formName"></param>
        /// <param name="optionCode"></param>
        /// <returns></returns>
        public int ReadMemInput( out UiMemInputDataForm uiMemInputDataForm,string assemblyName, string formName, string optionCode )
        {
            //-------------------------------------------------------------------
            // 準備
            //-------------------------------------------------------------------
            // 返却値・初期値セット
            int result = 4;
            // 出力パラメータ・初期値セット
            uiMemInputDataForm = null;

            // ディクショナリが無ければ新規作成
            if ( stc_uiMemInputDataFormDic == null )
            {
                stc_uiMemInputDataFormDic = new Dictionary<UiMemInputDataKey, UiMemInputDataForm>();
            }
            if ( stc_uiMemInputDataKeysDic == null )
            {
                stc_uiMemInputDataKeysDic = new Dictionary<string, List<UiMemInputDataKey>>();
            }

            //-------------------------------------------------------------------
            // 読み込み
            //-------------------------------------------------------------------

            // 読み込みキー生成
            UiMemInputDataKey key = new UiMemInputDataKey( assemblyName, formName, optionCode );


            if ( stc_uiMemInputDataFormDic.ContainsKey( key ) )
            {
                //------------------------------------------------------
                // ディクショナリに存在するならディクショナリから取得
                //------------------------------------------------------
                uiMemInputDataForm = stc_uiMemInputDataFormDic[key];

                // --- ADD 2011/08/02 by LDNS李占川---------->>>>>
                // 正常終了
                result = 0;
                // --- ADD 2011/08/02 by LDNS李占川----------<<<<<
            }
            else
            {
                //------------------------------------------------------
                // ディクショナリに存在しないなら、ファイルからデシリアライズ
                //------------------------------------------------------
                string xmlName = GetXMLName( key.AssemblyName );
                if ( File.Exists( xmlName ) )
                {
                    try
                    {
                        //-----------------------------------------------
                        // ＸＭＬファイルをデシリアライズ
                        //-----------------------------------------------
                        List<UiMemInputDataForm> uiMemAsm = Deserialize<List<UiMemInputDataForm>>( xmlName );

                        //-----------------------------------------------
                        // ディクショナリに退避
                        //-----------------------------------------------
                        List<UiMemInputDataKey> keyList = new List<UiMemInputDataKey>();
                        foreach ( UiMemInputDataForm uiMemForm in uiMemAsm )
                        {
                            // 書き込みキー生成
                            UiMemInputDataKey newKey = new UiMemInputDataKey( key.AssemblyName, uiMemForm.FormName, uiMemForm.OptionCode );

                            // 設定ディクショナリに追加
                            stc_uiMemInputDataFormDic.Add( newKey, uiMemForm );

                            // キーリストに追加
                            keyList.Add( newKey );
                        }
                        // アセンブリ別キーディクショナリに追加
                        stc_uiMemInputDataKeysDic.Add( key.AssemblyName, keyList );

                        //-----------------------------------------------
                        // ディクショナリから再取得
                        //-----------------------------------------------
                        if ( stc_uiMemInputDataFormDic.ContainsKey( key ) )
                        {
                            uiMemInputDataForm = stc_uiMemInputDataFormDic[key];

                            // 正常終了
                            result = 0;
                        }
                        else
                        {
                            // 設定なし
                        }
                    }
                    catch
                    { 
                        // 例外発生（デシリアライズ失敗など）
                    }
                }
                else
                {
                    // 保存ファイルなし
                }
            }

            return result;
        }
        /// <summary>
        /// 入力保存ファイル書き込み
        /// </summary>
        /// <param name="uiMemInputDataForm"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public void WriteMemInput( UiMemInputDataForm uiMemInputDataForm, string assemblyName )
        {
            //----------------------------------------------------------------
            // ディクショナリ更新
            //----------------------------------------------------------------
            
            // 書き込みキー生成
            UiMemInputDataKey key = new UiMemInputDataKey( assemblyName, uiMemInputDataForm.FormName, uiMemInputDataForm.OptionCode );

            if ( stc_uiMemInputDataFormDic.ContainsKey( key ) )
            {
                // 入力保存が既存なら更新
                stc_uiMemInputDataFormDic[key] = uiMemInputDataForm;
            }
            else
            {
                // 入力保存が無いなら追加
                stc_uiMemInputDataFormDic.Add( key, uiMemInputDataForm );

                // キーリストに追加
                if ( !stc_uiMemInputDataKeysDic.ContainsKey( assemblyName ) )
                {
                    // アセンブリ別Ｋｅｙリストが無いなら、
                    // アセンブリ別Ｋｅｙリストも追加。
                    stc_uiMemInputDataKeysDic.Add( assemblyName, new List<UiMemInputDataKey>() );
                }
                stc_uiMemInputDataKeysDic[assemblyName].Add( key );
            }
            //----------------------------------------------------------------
            // ＸＭＬ書き込み（シリアライズ）
            //----------------------------------------------------------------
            string xmlName = GetXMLName( assemblyName );

            List<UiMemInputDataForm> writeData = new List<UiMemInputDataForm>();
            foreach ( UiMemInputDataKey keyInAsm in stc_uiMemInputDataKeysDic[assemblyName])
            {
                if ( stc_uiMemInputDataFormDic.ContainsKey( keyInAsm ) )
                {
                    writeData.Add( stc_uiMemInputDataFormDic[keyInAsm] );
                }
            }
            // シリアライズ
            Serialize( xmlName, writeData );
        }
        # endregion

        # region [private Methods]

        # region [共通処理部品]
        /// <summary>
        /// シリアライズ処理
        /// </summary>
        /// <param name="fileName">取得元ファイル名</param>
        /// <param name="writeObject">シリアライズ対象オブジェクト</param>
        private void Serialize( string fileName, object writeObject )
        {
            FileStream fs = new FileStream( fileName, FileMode.Create );
            try
            {
                XmlSerializer xs = new XmlSerializer( writeObject.GetType() );

                xs.Serialize( fs, writeObject );
            }
            catch 
            {
            }
            finally
            {
                fs.Close();
            }
        }
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
            return string.Format( "{0}\\{1}.mem", ConstantManagement_ClientDirectory.UISettings_FormPos, assemblyName );
        }
        # endregion

        # endregion

        # region [入力保存データＫＥＹ]
        /// <summary>
        /// 入力保存データＫＥＹ
        /// </summary>
        private struct UiMemInputDataKey
        {
            /// <summary>アセンブリ名</summary>
            private string _assemblyName;
            /// <summary>フォーム名</summary>
            private string _formName;
            /// <summary>オプションコード</summary>
            private string _optionCode;
            /// <summary>
            /// アセンブリ名
            /// </summary>
            public string AssemblyName
            {
                get { return _assemblyName; }
                set { _assemblyName = value; }
            }
            /// <summary>
            /// フォーム名
            /// </summary>
            public string FormName
            {
                get { return _formName; }
                set { _formName = value; }
            }
            /// <summary>
            /// オプションコード
            /// </summary>
            /// <remarks>同一フォームで設定を複数持つ場合に使用します。</remarks>
            public string OptionCode
            {
                get { return _optionCode; }
                set { _optionCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="assemblyName">アセンブリ名</param>
            /// <param name="formName">フォーム名</param>
            /// <param name="optionCode">オプションコード</param>
            public UiMemInputDataKey (string assemblyName, string formName, string optionCode)
            {
                _assemblyName = assemblyName;
                _formName = formName;
                _optionCode = optionCode;
            }
        }
        # endregion
    }
    # endregion ■ DDに対する設定を管理するクラス(Acs) ■

    # region [入力内容保持クラス]
    /// <summary>
    /// ＵＩ入力保存データ・フォームクラス
    /// </summary>
    [Serializable]
    public class UiMemInputDataForm
    {
        /// <summary>フォーム名</summary>
        private string _formName;
        /// <summary>オプションコード</summary>
        private string _optionCode;
        /// <summary>入力保存データリスト</summary>
        private List<UiMemInputData> _uiMemInputDatas;
        /// <summary>カスタマイズデータ</summary>
        private List<string> _customizeData;

        /// <summary>
        /// フォーム名
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        /// <summary>
        /// オプションコード
        /// </summary>
        public string OptionCode
        {
            get { return _optionCode; }
            set { _optionCode = value; }
        }
        /// <summary>
        /// 入力保存データリスト
        /// </summary>
        public List<UiMemInputData> UiMemInputDatas
        {
            get { return _uiMemInputDatas; }
            set { _uiMemInputDatas = value; }
        }
        /// <summary>
        /// カスタマイズデータ
        /// </summary>
        public List<string> CustomizeData
        {
            get { return _customizeData; }
            set { _customizeData = value; }
        }
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UiMemInputDataForm()
        {
            FormName = string.Empty;
            OptionCode = string.Empty;
            UiMemInputDatas = new List<UiMemInputData>();
            CustomizeData = new List<string>();
        }
    }
    /// <summary>
    /// ＵＩ入力保存データクラス
    /// </summary>
    [Serializable]
    public class UiMemInputData
    {
        /// <summary>対象名称</summary>
        private string _targetName;
        /// <summary>入力データ</summary>
        private string _inputData;

        /// <summary>
        /// 対象名称
        /// </summary>
        public string TargetName
        {
            get { return _targetName; }
            set { _targetName = value; }
        }
        /// <summary>
        /// 入力データ
        /// </summary>
        public string InputData
        {
            get { return _inputData; }
            set { _inputData = value; }
        }
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UiMemInputData()
        {
            TargetName = string.Empty;
            InputData = string.Empty;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetName">対象コントロール名称</param>
        /// <param name="inputData">入力内容</param>
        public UiMemInputData( string targetName, string inputData)
        {
            TargetName = targetName;
            InputData = inputData;
        }
    }    
    # endregion
}
