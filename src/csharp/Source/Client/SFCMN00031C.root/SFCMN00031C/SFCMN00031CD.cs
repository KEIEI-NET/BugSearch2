using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

namespace Broadleaf.Library.Text
{
    //*******************************************************************
    //
    //  このソースファイルには「テキスト出力関連共通クラス, パラメータ」
    // に関連するクラス, 各種定義が実装されています
    //
    //*******************************************************************

    /// <summary>
    /// テキスト出力サービスパラメータ
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力サービスを実行するための各種設定･条件パラメータ</br>
    /// <br>Programmer : R.Sokei</br>
    /// <br>Date       : 2006.04.21</br>
    /// </remarks>
    public class CustomTextProviderInfo
    {

        #region コンストラクタ
        public CustomTextProviderInfo()
        {

        
        }

        /// <summary>
        /// テキスト出力サービスパラメータ 初期値取得
        /// </summary>
        /// <returns>テキスト出力サービスパラメータ初期値</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力サービスパラメータの初期値をセットして返します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public CustomTextProviderInfo(string shemaName, string outputName)
        {
            InitProc();

            SchemaFileName = shemaName;
            if ((outputName != null) && (outputName != ""))
            {
                OutPutFileName = System.IO.Path.GetFileName(outputName);           // ファイル名
                OutPutFolderName = System.IO.Path.GetDirectoryName(outputName);    // ファイル作成フォルダ
            }
        }

        #endregion コンストラクタ

        
        #region プロパティ

        /// <summary>
        /// スキーマファイル名
        /// </summary>
        public string SchemaFileName = "";

        /// <summary>
        /// ファイル名
        /// </summary>
        public string OutPutFileName = "";

        /// <summary>
        /// ファイル作成フォルダ
        /// </summary>
        public string OutPutFolderName = "";

        /// <summary>
        /// テキスト種別
        /// </summary>
        public CustomTextKinds TextKind = CustomTextKinds.CSV;

        /// <summary>
        /// バイナリ形式
        /// </summary>
        public CustomTextFormats TextFormat = CustomTextFormats.TEXT;

        /// <summary>
        /// 文字コード(出力エンコード指定 SJIS, UTF-8等)
        /// </summary>
        public System.Text.Encoding EncodeType = System.Text.Encoding.Default;

        /// <summary>
        /// テキスト追加モード(True:追加モード,False:上書きモード)
        /// </summary>
        public bool AppendMode = false;

        // 出力時暗号化有無

        /// <summary>
        /// ヘッダ情報付加区分
        /// </summary>
        public bool AddTextHeder = false;


        // 各種プロパティの入力状態(true=デフォルト値)
        public bool IsDefaultData_OutPutFileName = true;
        public bool IsDefaultData_OutPutFolderName = true;
        public bool IsDefaultData_TextKind = true;
        public bool IsDefaultData_TextFormat = true;
        public bool IsDefaultData_EncodeType = true;
        public bool IsDefaultData_AppendMode = true;
        public bool IsDefaultData_AddTextHeder = true;


        // 各種プロパティの入力状態を変更する
        public void SetDataState(bool outPutFileName, bool outPutFolderName, bool textKind, bool textFormat, bool encodeType, bool appendMode, bool addTextHeder)
        {
            this.IsDefaultData_OutPutFileName = outPutFileName;
            this.IsDefaultData_OutPutFolderName = outPutFolderName;
            this.IsDefaultData_TextKind = textKind;
            this.IsDefaultData_TextFormat = textFormat;
            this.IsDefaultData_EncodeType = encodeType;
            this.IsDefaultData_AppendMode = appendMode;
            this.IsDefaultData_AddTextHeder = addTextHeder;

            return;
        }


        #endregion プロパティ


        private void InitProc()
        {
            CustomTextProviderInfo tmp = CustomTextProviderInfo.GetDefaultInfo();
            this.AddTextHeder = tmp.AddTextHeder;
            this.OutPutFileName = tmp.OutPutFileName;
            this.OutPutFolderName = tmp.OutPutFolderName;
            this.SchemaFileName = tmp.SchemaFileName;
            this.TextFormat = tmp.TextFormat;
            this.TextKind = tmp.TextKind;
            this.AppendMode = tmp.AppendMode;

            return;
        }



        static public CustomTextProviderInfo GetDefaultInfo()
        {
            CustomTextProviderInfo tmp = new CustomTextProviderInfo();

            //--- 設定情報初期化
            tmp.TextKind = CustomTextKinds.CSV;         // テキスト種別
            tmp.TextFormat = CustomTextFormats.TEXT;  // バイナリ形式
            tmp.EncodeType = System.Text.Encoding.Default;  // 文字コード(出力エンコード指定 SJIS, UTF-8等)

            // 出力時暗号化有無
            
            tmp.SchemaFileName = "";                        // スキーマファイル名
            tmp.OutPutFileName = "";                        // ファイル名
            tmp.OutPutFolderName = System.IO.Directory.GetCurrentDirectory();                      // ファイル作成フォルダ
//            tmp.outPutFolderName = "";                      // ファイル作成フォルダ
            tmp.AddTextHeder = false;                       // ヘッダ情報付加区分
            tmp.AppendMode = false;

            return tmp;

        }
 

    }

    /// <summary>
    /// テキスト出力サービス ステータス
    /// </summary>
    public enum CustomTextProviderStatus
    {
        JOB_SUCCESS,        // 処理成功    
        NOTHING_DATA,       // 対象データ無し
        PROTECTED_ERROER,   // テキスト化対象外
        EXCEPTION_ERROER    // 例外エラー 
    }

    /// <summary>
    /// テキスト種別
    /// </summary>
    public enum CustomTextKinds
    {
        CSV,                // CSV形式
        FIXED_LENGTH,       // 固定長テキスト
        XML,                // XML形式        
        XML_WITH_SCHEMA,    // XML形式(スキーマ定義付き)
        MSOffice_XML        // MS Office XML形式
    }

    /// <summary>
    /// テキスト･バイナリ形式区分
    /// </summary>
    public enum CustomTextFormats
    {
        TEXT,               // テキスト形式
        BINARY              // バイナリ形式
    }


    /// <summary>
    /// テキスト出力ツールライブラリ
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力･入力に関連する各種ツール･サービスを提供</br>
    /// <br>Programmer : R.Sokei</br>
    /// <br>Date       : 2006.04.21</br>
    /// </remarks>
    public class CustomTextTool
    {

        public CustomTextTool()
        {

        }


        /// <summary>
        /// クラスリスト(配列)-->DataSet変換、コピー
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="retDataSet">変換先DataSet</param>
        /// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
        /// <remarks>
        /// <br>Note       : クラスリスト(配列)-->DataSet</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        static public int ClassArrayToDataSet(object source, ref DataSet retDataSet)
        {
            int st = 4;

            if (source != null)
            {

                // データソース(操作対象オブジェクト)をArrayListに入れなおす
                ArrayList alSource;
                if (source is ArrayList)
                {
                    alSource = (ArrayList)source;
                }
                else if (source is Array)
                {
                    alSource = new ArrayList((Array)source);
                }
                else
                {
                    alSource = new ArrayList();
                    alSource.Add(source);
                }

                // クラスタイプを取得
                Type workClassType = ((ArrayList)alSource)[0].GetType();

                // プロパティを取得
                PropertyInfo[] propInfo = workClassType.GetProperties();
                object obj = null;
                bool needDefaultDataSet = false;
                ArrayList alIndex = new ArrayList();
                Hashtable hs = new Hashtable();

                if (retDataSet == null)
                {
                    // 転記先DataSetが空の場合はクラス情報を基に空DataSetを作成する                
                    retDataSet = new DataSet();
                    retDataSet.Tables.Add("DefaultTable1");
                    needDefaultDataSet = true;
                }
                else
                {
                    // 転記先DataSetが指定されている場合は、列名判定用のHashTableを作成する                

                    foreach (DataColumn col in retDataSet.Tables[0].Columns)
                    {
                        hs.Add(col.ColumnName, col.Caption);
                    }
                }


                TransportIndexClasstoDataSet tIndex;
                int cnt = 0;

                // 転記対象クラスプロパティとDataセット列のマッピングインデックスの作成
                foreach (PropertyInfo prop in propInfo)
                {
                    if (needDefaultDataSet)
                    {
                        retDataSet.Tables[0].Columns.Add(prop.Name, prop.PropertyType);
                        tIndex = new TransportIndexClasstoDataSet(cnt, prop.Name);
                        alIndex.Add(tIndex);
                    }
                    else if (hs.ContainsKey(prop.Name))
                    {
                        tIndex = new TransportIndexClasstoDataSet(cnt, prop.Name);
                        alIndex.Add(tIndex);
                    }

                    cnt++;
                }

              
                // クラスリストをDataSetへ転送する
                PropertyInfo propInf;
                DataRow dr;
                if (alIndex.Count > 0)
                {
          
                    foreach (object sourceDtl in (ArrayList)alSource)
                    {
                        // DataSet新規行の作成
                        dr = retDataSet.Tables[0].NewRow();

                        foreach (TransportIndexClasstoDataSet tiIndex in alIndex)
                        {
                            propInf = propInfo[tiIndex.SourcePropIndex];
                            obj = propInf.GetValue(sourceDtl, null);

                            if (obj != null)
                            {
                                dr[tiIndex.EditColKey] = obj;
                            }
                            else
                            {
                                dr[tiIndex.EditColKey] = DBNull.Value;
                            }
                        }

                        retDataSet.Tables[0].Rows.Add(dr);
                    }
                }
            }

            return st;        
        
        }


        /// <summary>
        /// DataSetデータ値-->XMLSchema形式テキスト出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
        /// <remarks>
        /// <br>Note       : DataSetデータ値-->テキスト出力</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        static public int DataSetToXMLSchema(DataSet source, string outputFilePath)
        {
            int st = 0;
            string text = "";
            StringBuilder strBuilder;
            StringBuilder allText = new StringBuilder();

            if (source.Tables.Count.Equals(0))
            {

                // 出力対象データが存在しない
                st = 4;
            }
            else
            {
                // データテーブルの各列情報(ヘッダ情報)を出力する

                string headerStr;
                strBuilder = new StringBuilder();

                strBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                strBuilder.AppendLine("<TextServiceSchema>");
                strBuilder.AppendLine("<!-- スキーマファイルの情報  -->");
                strBuilder.AppendLine("<SchemaInfoDef>");
                strBuilder.AppendLine("<SchemaName></SchemaName>");
                strBuilder.AppendLine("<SchemaFileName></SchemaFileName>");
                strBuilder.AppendLine("<Writer></Writer>");
                strBuilder.AppendLine("<Date>" + DateTime.Today.ToString("d") + "</Date>");
                strBuilder.AppendLine("<Version></Version>");
                strBuilder.AppendLine("</SchemaInfoDef>");
                strBuilder.AppendLine("<!--  出力ファイルの設定  -->");
                strBuilder.AppendLine("<FileInfoDef>");
                strBuilder.AppendLine("<OutPutFileName></OutPutFileName>");
                strBuilder.AppendLine("<OutPutDir></OutPutDir>");
                strBuilder.AppendLine("<EncodeType>SJIS</EncodeType>");
                strBuilder.AppendLine("<Formatter>Text</Formatter>");
                strBuilder.AppendLine("<Encryption>false</Encryption>");
                strBuilder.AppendLine("<CipherType>Default</CipherType>");
                strBuilder.AppendLine("<OutputHeader>true</OutputHeader>");
                strBuilder.AppendLine("</FileInfoDef>");
                strBuilder.AppendLine("<!-- 出力情報設定  -->");
                strBuilder.AppendLine("<ColInfoDef>");


                foreach (System.Data.DataColumn dtl in source.Tables[0].Columns)
                {

                    if (dtl.ColumnName != null)
                    {
                        strBuilder.AppendLine("<ColInfo key=\"" + dtl.ColumnName + "\">");
                        strBuilder.AppendLine("<ColKey>" + dtl.ColumnName + "</ColKey>");
                        strBuilder.AppendLine("<ColName></ColName>");
                        strBuilder.AppendLine("<ColWidth></ColWidth>");
                        strBuilder.AppendLine("<ColDataType>" + dtl.DataType.ToString() + "</ColDataType>");
                        strBuilder.AppendLine("</ColInfo>");
                    }

                }

                strBuilder.AppendLine("</ColInfoDef>");
                strBuilder.AppendLine("</TextServiceSchema>");
                headerStr = strBuilder.ToString();

                // データテーブルの各行情報を出力する
                allText.AppendLine(headerStr);
            }

            text = allText.ToString();

            if ((text != null) && (text != ""))
            {
                MakeTextFile(text, ref outputFilePath, 0, System.Text.Encoding.UTF8);
            }


            return st;

        }


        static private int MakeTextFile(string source, ref string outputFilepath, int cipherMode, System.Text.Encoding enCode)
        {
            int st = 0;

            if ((outputFilepath != null) && (outputFilepath.Trim() != ""))
            {
                // テキスト置換処理


            }
            else
            {
                // 出力ファイル名称生成
                outputFilepath = Guid.NewGuid().ToString() + ".xml";
            }

            // Shift JIS コードで書き出し
            System.IO.StreamWriter writer =
                new System.IO.StreamWriter(outputFilepath, false,
                    enCode);
            writer.WriteLine(source);
            writer.Close();

            return st;
        }


        class TransportIndexClasstoDataSet
        {
            public int SourcePropIndex;
            public string EditColKey;

            public TransportIndexClasstoDataSet()
            {


            }

            public TransportIndexClasstoDataSet(int sourcePropIndex, string editColKey)
            {
                SourcePropIndex = sourcePropIndex;
                EditColKey = editColKey;
            }

        }

    }

}
