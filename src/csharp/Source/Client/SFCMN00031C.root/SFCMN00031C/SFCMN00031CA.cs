using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

namespace Broadleaf.Library.Text
{

    //************************************************************
    //
    //  このソースファイルには「テキスト入出力(外部非公開クラス)」
    // に関連するクラス, 各種定義が実装されています
    //
    //************************************************************


    /// <summary>
    /// テキスト入出力クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力･入力処理基本クラス</br>
    /// <br>Programmer : R.Sokei</br>
    /// <br>Date       : 2006.04.21</br>
	/// <br>Update Date: ① 2007.06.26 小田　義昭 (20015)
	///                :    追加モードでの出力時、ヘッダが出力されていたので、Pegasusと同様に追加時は
	///                :    ヘッダを出力しないように変更
    /// </br>
    /// <br>Update Note: 2011/08/15  連番923 梁森東</br>
    /// <br>            : 品番や品名に "(ﾀﾞﾌﾞﾙｺｰﾃｰｼｮﾝ)が含まれると、ｲﾝﾎﾟｰﾄ時にエラーになる為の対応</br>
    /// <br>Update Note: 2011/08/17  連番923 梁森東</br>
    /// </br>            : 数字項目は"で括る必要はありません、文字列項目のみ""で括っての対応</br>
	/// </remarks>
    internal class CustomTextProvider
    { 
    

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力･入力クラス コンストラクタ</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public CustomTextProvider()
        {
            InitProc();
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <remarks>
        /// <br>Note       : テキスト出力･入力クラス コンストラクタ</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public CustomTextProvider(object source)
        {
            InitProc();
        }

        private void InitProc()
        {
            _ColInfoList = new Hashtable();
            _IsExistsSchemaFile = false;

            return;
        }


        // プロパティ

        private Hashtable _ColInfoList;
        private bool _IsExistsSchemaFile;

        // 操作属性セット


        // スキーマ解析関連(スキーマファイルの解析)


        // テキスト出力関連


        // テキスト入力関連


        // テキスト編集関連


        // 暗号化･複号化関連


        // クラス解析
        /// <summary>
        /// クラスメンバ値-->テキスト出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="text">生成テキスト</param>
        /// <remarks>
        /// <br>Note       : クラスメンバ値-->テキスト出力</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int ClassMemberToText(object source, out string text, CustomTextProviderInfo textInfo)
        {

            int st = 0;
            text = "";
            if (source != null)
            {
                ArrayList colInfoNumberList = null;

                // クラスタイプを取得
                Type workClassType = ((ArrayList)source)[0].GetType();

                // テキストサービス対象の属性を持っているかチェックする
                string protectType;
                if (HasTextServiceSerializationAttribute(workClassType, out protectType))
                {
                    DataSet retDataSet = null;
                    // スキーマファイルが指定されている場合は編集用DataSetを作成する
                    if (textInfo.SchemaFileName.Trim() != "")
                    {
                        // 編集用データセットの作成
                        MakeEditDataSet(source, textInfo.SchemaFileName, out retDataSet, out colInfoNumberList);
                    }

                    
                    // クラスリスト --> DataSet変換
                    CustomTextTool.ClassArrayToDataSet(source, ref retDataSet);
                    st = DataSetToText(retDataSet, out text, textInfo, colInfoNumberList);

                }
                else
                {
                    st = -9;  // 出力対象外のクラスが指定された
             
                }

            }

            return st;        
        }


        /// <summary>
        /// DataSetデータ値-->テキスト出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="text">生成テキスト</param>
        /// <remarks>
        /// <br>Note       : DataSetデータ値-->テキスト出力</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int DataSetToText(DataSet source, out string text, CustomTextProviderInfo textInfo)
        { 
            ArrayList colInfoNumberList = null;
            return DataSetToText(source, out text, textInfo, colInfoNumberList);
        }

        /// <summary>
        /// DataSetデータ値-->テキスト出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="text">生成テキスト</param>
        /// <remarks>
        /// <br>Note       : DataSetデータ値-->テキスト出力</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// <br>Update Note: 2011/08/17  連番923 梁森東</br>
        /// <br>            : 数字項目は"で括る必要はありません、文字列項目のみ""で括っての対応</br>
        /// </remarks>
        public int DataSetToText(DataSet source, out string text, CustomTextProviderInfo textInfo, ArrayList colInfoNumberList)
        {

            int st = 0;
            text = "";
            StringBuilder strBuilder;
            StringBuilder allText = new StringBuilder();

            if (colInfoNumberList == null)
            {
                colInfoNumberList = new ArrayList();
            }

            if (source.Tables.Count.Equals(0))
            {

                // 出力対象データが存在しない
                st = 4;
            }
            else
            {
                DataSet editDataSet = null;
                string headerStr;


                // 編集用データセットの作成
                st = MakeEditDataSet(source, textInfo.SchemaFileName, out editDataSet, out colInfoNumberList);

                // データテーブルの各列情報(ヘッダ情報)を出力する

                strBuilder = new StringBuilder();
                //                foreach (System.Data.DataColumn dtl in source.Tables[0].Columns)

                if (editDataSet != null)
                {
					// 追加モードの場合は、ヘッダは追加しない
					if (textInfo.AppendMode == false)											// 2007.06.26 小田 Add ＠追加出力時ヘッダ無し対応
					{
						foreach (System.Data.DataColumn dtl in editDataSet.Tables[0].Columns)
						{

							if (strBuilder.Length > 0)
							{
								strBuilder.Append(",");
							}

							if (dtl.Caption != null)
							{
								strBuilder.Append("\"");
								strBuilder.Append(dtl.Caption);
								strBuilder.Append("\"");
							}
							else
							{
								strBuilder.Append("\"");
								strBuilder.Append("\"");
							}

						}

						headerStr = strBuilder.ToString();

						// データテーブルの各行情報を出力する
						allText.AppendLine(headerStr);
					}

					int colCnt = editDataSet.Tables[0].Columns.Count;

                    foreach (System.Data.DataRow row in editDataSet.Tables[0].Rows)
                    {

                        strBuilder = new StringBuilder();
                        for (int idx = 0; idx < colCnt; idx++)
                        {


                            if (strBuilder.Length > 0)
                            {
                                strBuilder.Append(",");
                            }

                            if (row[idx] != null)
                            {
                                if (((TextColInfo)colInfoNumberList[idx]).ColDataType == "System.String")  //ADD by Liangsd     2011/08/17
                                {
                                    strBuilder.Append("\"");
                                }
                                string strTmp = "";


                                int textWidth = 0;
                                if (colInfoNumberList.Count > idx)
                                {

                                    // 出力サイズの取得
                                    textWidth = ((TextColInfo)colInfoNumberList[idx]).ColWidth;

                                    // データコンバート方法、編集式が指定されていればここで編集を行う
                                    if ((((TextColInfo)colInfoNumberList[idx]).DataConvert == "") && (((TextColInfo)colInfoNumberList[idx]).EditMode == 0))
                                    {
                                        // データコンバート方法、編集式が指定されていない場合はそのまま出力
                                        strTmp = row[idx].ToString();
                                    }
                                    else
                                    {
                                        object obj = null;
                                        if (((TextColInfo)colInfoNumberList[idx]).DataConvert != "")
                                        {
                                            // 指定された方式でデータコンバートを実行
                                            //                                    strTmp = strBuilder.Append(row[idx].ToString());
                                            obj = ConvertData(((TextColInfo)colInfoNumberList[idx]).DataConvert, row[idx]);
                                            if (obj != null)
                                            {
                                                strTmp = obj.ToString();
                                            }
                                        }


                                        if (((TextColInfo)colInfoNumberList[idx]).EditMode != 0)
                                        {
                                            // 指定された編集を加える
                                            strTmp = row[idx].ToString();

                                        }


                                        //                                strTmp = strBuilder.Append(row[idx].ToString());
                                    }
                                }
                                else
                                {
                                    strTmp = row[idx].ToString();
                                }

                                // 指定されたサイズに文字列を編集
                                if (textWidth > 0)
                                {
                                    if (textWidth < strTmp.Length)
                                    {
                                        strTmp = strTmp.Substring(0, textWidth);
                                    }
                                }

                                strBuilder.Append(strTmp);
                                if (((TextColInfo)colInfoNumberList[idx]).ColDataType == "System.String")//ADD by Liangsd     2011/08/17
                                {
                                    strBuilder.Append("\"");
                                }
                            }
                            else
                            {
                                if (((TextColInfo)colInfoNumberList[idx]).ColDataType == "System.String")//ADD by Liangsd     2011/08/17
                                {
                                    strBuilder.Append("\"");
                                    strBuilder.Append("\"");
                                }
                            }

                        }

                        if (strBuilder.Length > 0)
                        {
                            allText.AppendLine(strBuilder.ToString());
                        }

                    }

                }

            }

            text = allText.ToString();
            return st;
        }

        private object ConvertData(string convertFormat, object source)
        {
            object obj = source;
            string strTmp = null;
            int    numTmp = 0;

            switch (convertFormat.ToUpper())
            {
                case "DATETIMETOINT_YYYYMMDD":
                    {
                        if (source is DateTime)
                        {
                            if (((DateTime)source) == DateTime.MinValue)
                            {
                                numTmp = 0;
                            }
                            else
                            {
                                numTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate((DateTime)source);
                            }
                            obj = numTmp;
                        }
                    }
                    break;
                case "DATETIMETOINT_YYYYMM":
                    {
                        if (source is DateTime)
                        {

                            if (((DateTime)source) == DateTime.MinValue)
                            {
                                numTmp = 0;
                            }
                            else
                            {
                                numTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMM", (DateTime)source);
                            }

                            obj = numTmp;
                        }
                    }
                    break;
                case "DATETIMETOSTRING_YYYYMMDD":
                    {
                        if (source is DateTime)
                        {
                            strTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToString("YYYYMMDD", (DateTime)source);
                            obj = strTmp;
                        }
                    }
                    break; 
                case "DATETIMETOSTRING_YYYYMM":
                    {
                        if (source is DateTime)
                        {
                            strTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToString("YYYYMMDD", (DateTime)source);
                            obj = strTmp;
                        }
                    }
                    break;

                default:
                    {
                        obj = source;
                        break;
                    }
            }

//            case convertFormat

            return obj;
        }



        /// <summary>
        /// テキスト出力属性チェック
        /// </summary>
        /// <param name="type">対象オブジェクト</param>
        /// <param name="protectType">テキスト出力属性</param>
        /// <remarks>
        /// <br>Note       : テキスト出力属性を持っているかどかをチェックして取得した属性を返す</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        private bool HasTextServiceSerializationAttribute(Type type, out string protectType)
        {
            protectType = "";
            bool st = false;

            Attribute[] attributes = Attribute.GetCustomAttributes(type);
            foreach (Attribute att in attributes)
            {
                if (att is TextServiceSerializationAttribute)
                {
                    protectType = ((TextServiceSerializationAttribute)att).ProtectType;
                    st = true;
                    break;
                }            
            }
        
            return st;
        }



        //private int MakeEditDataSet(object source, string schemaPath, out DataSet editDataSet)
        //{
        //    Hashtable colInfoList = null;
        //    ArrayList colInfoNumberList = null;

        //    return MakeEditDataSet(source, schemaPath, out editDataSet, out colInfoList, out colInfoNumberList);
        
        //}


        private int MakeEditDataSet(object source, string schemaPath, out DataSet editDataSet, out ArrayList colInfoNumberList)
        {
            editDataSet = null;
            colInfoNumberList = null;
            if (source == null)
            {
                return 4;
            }            
            
            CustomTextProviderInfo customTextProviderInfo;
            Hashtable colInfoList = null;
//            ArrayList colInfoNumberList = null;
            bool isSuccess = false;

            CustomTextProviderInfo customTextProviderInfoUserDef;
            Hashtable colInfoListUserDef = null;
            ArrayList colInfoNumberListUserDef = null;

            int st   = ReadSchemaInfo(schemaPath, out customTextProviderInfo, out colInfoList, out colInfoNumberList);
            int stEx = ReadCustomSchemaInfo(schemaPath, out customTextProviderInfoUserDef, out colInfoListUserDef, out colInfoNumberListUserDef);

            // ユーザ定義スキーマファイルが存在するときは、ユーザ定義に基づいてスキーマ情報を編集する
            if (st.Equals(0) && stEx.Equals(0))
            { 

                // 提供スキーマファイルの内容をユーザ定義で上書きする
                UpdateSchemaInfoByCustomSchemaInfo(ref customTextProviderInfo, ref colInfoList, ref colInfoNumberList, customTextProviderInfoUserDef, colInfoListUserDef, colInfoNumberListUserDef);

            }


            if (st.Equals(0)) 
            {
                if ((colInfoNumberList != null) && (colInfoNumberList.Count > 0))
                {
                    editDataSet = new DataSet();
                    editDataSet.Tables.Add("EditDataTable1");
                    // スキーマ定義ファイルが存在すればファイルの設定を基にDataSetを生成する
                    foreach (TextColInfo colInfo in colInfoNumberList)
                    {
                        DataColumn dc = editDataSet.Tables[0].Columns.Add(colInfo.ColKey, Type.GetType(colInfo.ColDataType));
                        dc.Caption = colInfo.ColName;

                        // デフォルト値の設定
                        switch (colInfo.ColDataType)
                        {
                            case "System.Int32":
                                dc.DefaultValue = 0;
                                break;
                            case "System.String":
                                dc.DefaultValue = "";
                                break;
                            case "System.Int64":
                                dc.DefaultValue = 0;
                                break;
                            case "System.Double":
                                dc.DefaultValue = 0.0d;
                                break;
                            default:
                                break;
                        }
                        
                        dc.Unique = false;
                    }

                    isSuccess = true;
                }
            }

            if (!isSuccess)
            {

                if (source is DataSet)
                {
                    // スキーマ定義が存在しない&ソースが DataSet の場合
                    // データセットのコピーを生成して返す
                    if (schemaPath.Trim().Equals(""))
                    {
                        editDataSet = ((DataSet)source).Copy();
                    }
                    else
                    {
                        // スキーマファイルのパスを指定しているが、ファイルが読込めない場合はテキスト出力しない
                        editDataSet = null;

                        // スキーマファイルが存在しない
                        st = 21;
                    }
                }
                else 
                {
                    // スキーマ定義が存在しない&ソースが Class の場合
                    // クラスのメンバをDataSetへ転記して返す
                 


                }
            }

//            System.Windows.Forms.MessageBox.Show(st.ToString());

            // ソースから編集用データセットへデータをコピーする
            if (editDataSet != null)
            {
                ArrayList indexList = new ArrayList();

                if (source is DataSet)
                {
                    DataSet tmpDs = (DataSet)source;
                    // 転記用インデックスの作成
                    foreach (DataColumn col in tmpDs.Tables[0].Columns)
                    {
                        if (colInfoList.ContainsKey(col.ColumnName))
                        {

                            TransportIndexForDataSet Tds = new TransportIndexForDataSet(col.Ordinal, col.ColumnName);
                            indexList.Add(Tds);
                        }

                    }

                    // 転記用インデックスの内容に従って source --> editDataSet へデータを転記する
                    if (indexList.Count > 0)
                    {
                        DataRow editRow;

                        foreach (DataRow row in ((DataSet)source).Tables[0].Rows)
                        {

                            editRow = editDataSet.Tables[0].NewRow();
                            foreach (TransportIndexForDataSet tsIndex in indexList)
                            {
                                //editRow[tsIndex.EditColKey] = row[tsIndex.SourceColIndex];                                 //DEL by Liangsd     2011/08/15  
                                editRow[tsIndex.EditColKey] = ConvertString(row[tsIndex.SourceColIndex]);        //ADD by Liangsd     2011/08/15
                            }
                            editDataSet.Tables[0].Rows.Add(editRow);
                        }


                        st = 0;
                    }
                }

            }
            else
            {
                if (st.Equals(0))
                    st = 4;
            }

            return st;
        }

        //ADD by Liangsd   2011/08/15----------------->>>>>>>>>>
        /// <summary>
        /// 特別な文字列の変換
        /// </summary>
        /// <param name="str">改修前の文字列</param>
        /// <returns>改修後の文字列</returns>
        /// <remarks>
        /// <br>Note        : 特別な文字列の変換を行う</br>
        /// <br>Programmer  : Liangsd</br>
        /// <br>Date        : 2011/08/15</br>
        /// </remarks>
        private string ConvertString(object obj)
        {
            string res = obj.ToString();
            // 文字列の場合
            if (obj is string)
            {
                if (obj.ToString().Contains("\""))
                {
                    res = obj.ToString().Replace("\"", "\"\"");
                }
            }
            return res;
        }
        //ADD by Liangsd   2011/08/15-----------------<<<<<<<<<<

        private int CopyDtataTable(DataSet source, DataSet target)
        {
            // DataSetのデータテーブル内のデータをコピーする



            return 0;
        }


        #region スキーマ情報取得

        /// <summary>
        /// スキーマ情報取得
        /// </summary>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="customTextProviderInfo">スキーマ情報(返却値)</param>
        /// <returns>処理結果 0:取得成功, -1:取得エラー</returns>
        /// <remarks>
        /// <br>Note       : スキーマファイルの情報を取得して customTextProviderInfo へ返します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int ReadSchemaInfo(string schemaPath, out CustomTextProviderInfo customTextProviderInfo)
        { 
            Hashtable ht;
            ArrayList al;
            return ReadSchemaInfo(schemaPath, out customTextProviderInfo, out ht, out al);
        }

        private int ReadSchemaInfo(string schemaPath, out CustomTextProviderInfo customTextProviderInfo, out Hashtable colInfoList, out ArrayList colInfoNumberList)
        {
            customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            Hashtable ht = new Hashtable();
            ArrayList al = new ArrayList();

            int st = -1;
            bool IsSchemaError = true;
            

            // スキーマファイル読み込み
//            string path = MakeFilePath(0, customTextProviderInfo.outPutFolderName, customTextProviderInfo.outPutFileName);
            string path = schemaPath;
            bool existFile = false;
            if (System.IO.File.Exists(path))
            {
                existFile = true;
            }
            else
            {
                string lFileName = System.IO.Path.GetFileName(path);

                if (System.IO.File.Exists(lFileName))
                {
                    existFile = true;
                    path = lFileName;
                }            
            }


            if(existFile)
            {

           		XmlDocument _xmlDoc = null;
                bool _xPathDocEnable = false;

                // 出力ファイルの設定取得
                try
                {
                    _xmlDoc = new XmlDocument();
//                    _xmlDoc.Load(path);
                    _xmlDoc.LoadXml(ReadXMLFile(path));
                    _xPathDocEnable = true;
                }
                catch (FileNotFoundException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }
                catch (XmlException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }

                // ガイド設定ファイルの読込
                if (_xPathDocEnable)
                {
                    #region テキスト出力ファイルに関する設定
                    XmlElement xmlElem = _xmlDoc.DocumentElement;
                    XmlElement xmlElem2;
//                    int numTmp = 0;

                    // フォームメッセージ
                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutFileName");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFileName = xmlElem2.InnerText;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutDir");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFolderName = xmlElem2.InnerText;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/TextKind");
                    if (!(xmlElem2 == null))
                    {
                        SetTextKinds(ref customTextProviderInfo, xmlElem2.InnerText);
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/EncodeType");
                    if (!(xmlElem2 == null))
                    {
                        SetEncodeType(ref customTextProviderInfo, xmlElem2.InnerText);
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Formatter");
                    if (!(xmlElem2 == null))
                    {
                        SetTextFormats(ref customTextProviderInfo, xmlElem2.InnerText);
                    }

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Encryption");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo.e = xmlElem2.InnerText;
                    //}

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/CipherType");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo = xmlElem2.InnerText;
                    //}

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutputHeader");
                    if (!(xmlElem2 == null))
                    {
                        if (xmlElem2.InnerText.Trim().ToUpper() == "TRUE")
                            customTextProviderInfo.AddTextHeder = true;
                        else
                            customTextProviderInfo.AddTextHeder = false;

                    }
                    #endregion テキスト出力ファイルに関する設定

                    #region 出力情報の設定
                    XmlNodeList nodeList;
                    XmlNodeList nodeListChild;

                    nodeList = xmlElem.SelectNodes("/TextServiceSchema/ColInfoDef/ColInfo");
                    int idx = 0;
                    foreach (XmlNode isbn in nodeList)
                    {
                        string lColKey = "";
                        string lColName = "";
                        string lColType = "";
                        int lColWidth = 0;
                        int lColEditMode = 0;
                        string lColDataConvert = "";

                        nodeListChild = isbn.ChildNodes;

                        foreach (XmlElement iElem in nodeListChild)
                        {
                            if (!(iElem == null))
                            {

                                switch (iElem.Name)
                                {
                                    case "ColKey":
                                        lColKey = iElem.InnerText;
                                        break;
                                    case "ColName":
                                        lColName = iElem.InnerText;
                                        break;
                                    case "ColDataType":
                                        {
                                            switch (iElem.InnerText.ToUpper())
                                            {
                                                case "STRING":
                                                    lColType = "System.String";
                                                    break;
                                                case "INT32":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT64":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "LONG":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "DOUBLE":
                                                    lColType = "System.Double";
                                                    break;
                                                case "GUID":
                                                    lColType = "System.Guid";
                                                    break;
                                                case "DATETIME":
                                                    lColType = "System.DateTime";
                                                    break;
                                                case "INTEGER":
                                                    lColType = "System.Int32";
                                                    break;
                                                default:
                                                    lColType = iElem.InnerText;
                                                    break;
                                            }
                                        }
                                        break;
                                    case "ColWidth":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColWidth = Convert.ToInt32(iElem.InnerText);
                                        }
                                        else
                                        {
                                            lColWidth = 0;
                                        }
                                        break;
                                    case "ColEditMode":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColEditMode = Convert.ToInt32(iElem.InnerText);
                                        }
                                        else
                                        {
                                            lColEditMode = 0;
                                        }
                                        break;

                                    case "ColDataConvert":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColDataConvert = iElem.InnerText;
                                        }
                                        break;
                                        
                                    default:
                                        break;
                                }
                            }
                        }

                        if ((!(lColKey == "")) && (!(lColName == "")))
                        {
                            TextColInfo txinf = new TextColInfo(idx, lColKey, lColName, lColWidth, lColType, lColEditMode, lColDataConvert);

                            ht.Add(txinf.ColKey, txinf);
                            al.Add(txinf);
                            idx++;
                        }

                    }

                    #endregion 出力情報の設定
                    IsSchemaError = false;
                    st = 0;
                }
                else
                {
                    // スキーマファイルが取り込めなかった場合    
                    IsSchemaError = true;
                    st = -1;
                }

            }


            // 失敗した場合はセキュリティ関連の設定をMAXに設定する
            if (IsSchemaError)
            {
                customTextProviderInfo.AddTextHeder = false;
                st = -1;
            }

            colInfoList = ht;
            colInfoNumberList = al;
            return st;
        }

        #endregion スキーマ情報取得


        #region スキーマ(ユーザ定義)情報取得

        /// <summary>
        /// スキーマ(ユーザ定義)情報取得
        /// </summary>
        /// <param name="schemaPath">オリジナルスキーマファイルパス</param>
        /// <param name="customTextProviderInfo">スキーマ情報(返却値)</param>
        /// <returns>処理結果 0:取得成功, -1:取得エラー</returns>
        /// <remarks>
        /// <br>Note       : スキーマファイルの情報を取得して customTextProviderInfo へ返します</br>
        /// <br>           : originalSchemaPathを基にユーザ定義スキーマファイルパスを自動的に生成します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int ReadCustomSchemaInfo(string originalSchemaPath, out CustomTextProviderInfo customTextProviderInfo)
        {
            Hashtable ht;
            ArrayList al;
            return ReadSchemaInfo(originalSchemaPath, out customTextProviderInfo, out ht, out al);
        }

        private int ReadCustomSchemaInfo(string originalSchemaPath, out CustomTextProviderInfo customTextProviderInfo, out Hashtable colInfoList, out ArrayList colInfoNumberList)
        {
            customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            Hashtable ht = new Hashtable();
            ArrayList al = new ArrayList();

            int st = -1;
            bool IsSchemaError = true; 


            // ユーザ定義スキーマファイルパスの生成
            string path = MakeCustomSchemaPath(originalSchemaPath);

            bool existFile = false;
            if (System.IO.File.Exists(path))
            {
                existFile = true;
            }
            else
            {
                string lFileName = System.IO.Path.GetFileName(path);

                if (System.IO.File.Exists(lFileName))
                {
                    existFile = true;
                    path = lFileName;
                }            
            }

            // スキーマファイル読み込み
            if(existFile)
            {

                XmlDocument _xmlDoc = null;
                bool _xPathDocEnable = false;

                // 出力ファイルの設定取得
                try
                {
                    _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(path);
                    _xPathDocEnable = true;
                }
                catch (FileNotFoundException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }
                catch (XmlException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }

                // ガイド設定ファイルの読込
                if (_xPathDocEnable)
                {
                    #region テキスト出力ファイルに関する設定
                    XmlElement xmlElem = _xmlDoc.DocumentElement;
                    XmlElement xmlElem2;
                    //                    int numTmp = 0;

                    // フォームメッセージ
                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutFileName");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFileName = xmlElem2.InnerText;
                        customTextProviderInfo.IsDefaultData_OutPutFileName = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutDir");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFolderName = xmlElem2.InnerText;
                        customTextProviderInfo.IsDefaultData_OutPutFolderName = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/TextKind");
                    if (!(xmlElem2 == null))
                    {
                        SetTextKinds(ref customTextProviderInfo, xmlElem2.InnerText);
                        customTextProviderInfo.IsDefaultData_TextKind = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/EncodeType");
                    if (!(xmlElem2 == null))
                    {
                        SetEncodeType(ref customTextProviderInfo, xmlElem2.InnerText);
                        customTextProviderInfo.IsDefaultData_TextFormat = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Formatter");
                    if (!(xmlElem2 == null))
                    {
                        SetTextFormats(ref customTextProviderInfo, xmlElem2.InnerText);
                        customTextProviderInfo.IsDefaultData_TextFormat = false;
                    }

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Encryption");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo.e = xmlElem2.InnerText;
                    //}

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/CipherType");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo = xmlElem2.InnerText;
                    //}

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutputHeader");
                    if (!(xmlElem2 == null))
                    {
                        if (xmlElem2.InnerText.Trim().ToUpper() == "TRUE")
                            customTextProviderInfo.AddTextHeder = true;
                        else
                            customTextProviderInfo.AddTextHeder = false;

                        customTextProviderInfo.IsDefaultData_AddTextHeder = false;

                    }
                    #endregion テキスト出力ファイルに関する設定

                    #region 出力情報の設定
                    XmlNodeList nodeList;
                    XmlNodeList nodeListChild;

                    nodeList = xmlElem.SelectNodes("/TextServiceSchema/ColInfoDef/ColInfo");
                    int idx = 0;
                    foreach (XmlNode isbn in nodeList)
                    {
                        string lColKey = "";
                        string lColName = "";
                        string lColType = "";
                        int lColWidth = 0;
                        int lColEditMode = 0;
                        string lColDataConvert = "";
                        bool lColEnable = true;

                        bool isDefaultData_ColName = true;
                        bool isDefaultData_ColWidth = true;
                        bool isDefaultData_ColDataType = true;
                        bool isDefaultData_EditMode = true;
                        bool isDefaultData_DataConvert = true;


                        nodeListChild = isbn.ChildNodes;

                        foreach (XmlElement iElem in nodeListChild)
                        {
                            if (!(iElem == null))
                            {

                                switch (iElem.Name)
                                {
                                    case "ColKey":
                                        lColKey = iElem.InnerText;
                                        break;
                                    case "ColName":
                                        lColName = iElem.InnerText;
                                        isDefaultData_ColName = false;
                                        break;
                                    case "ColDataType":
                                        {
                                            switch (iElem.InnerText.ToUpper())
                                            {
                                                case "STRING":
                                                    lColType = "System.String";
                                                    break;
                                                case "INT32":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT64":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "LONG":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "DOUBLE":
                                                    lColType = "System.Double";
                                                    break;
                                                case "GUID":
                                                    lColType = "System.Guid";
                                                    break;
                                                case "DATETIME":
                                                    lColType = "System.DateTime";
                                                    break;
                                                case "INTEGER":
                                                    lColType = "System.Int32";
                                                    break;
                                                default:
                                                    lColType = iElem.InnerText;
                                                    break;

                                            }
                                            isDefaultData_ColDataType = false;

                                        }
                                        break;
                                    case "ColWidth":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColWidth = Convert.ToInt32(iElem.InnerText);
                                            isDefaultData_ColWidth = false;
                                        }
                                        else
                                        {
                                            lColWidth = 0;
                                        }

                                        break;
                                    case "ColEditMode":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColEditMode = Convert.ToInt32(iElem.InnerText);
                                            isDefaultData_EditMode = false;
                                        }
                                        else
                                        {
                                            lColEditMode = 0;
                                        }
                                        break;
                                    case "ColDataConvert":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColDataConvert = iElem.InnerText;
                                            isDefaultData_DataConvert = false;
                                        }
                                        break;
                                    case "ColEnable":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            if (xmlElem2.InnerText.Trim().ToUpper() == "TRUE")
                                                lColEnable = true;
                                            else
                                                lColEnable = false;

                                        }
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }

                        if ((!(lColKey == "")) && (!(lColName == "")))
                        {
                            TextColInfo txinf = new TextColInfo(idx, lColKey, lColName, lColWidth, lColType, lColEditMode, lColDataConvert);
                            txinf.SetDataState(isDefaultData_ColName, isDefaultData_ColWidth, isDefaultData_ColDataType, isDefaultData_EditMode, isDefaultData_DataConvert);
                            txinf.Enable = lColEnable;

                            ht.Add(txinf.ColKey, txinf);
                            al.Add(txinf);
                            idx++;
                        }

                    }

                    #endregion 出力情報の設定
                    IsSchemaError = false;
                    st = 0;
                }
                else
                {
                    // スキーマファイルが取り込めなかった場合    
                    IsSchemaError = true;
                    st = -1;
                }

            }


            // 失敗した場合はセキュリティ関連の設定をMAXに設定する
            if (IsSchemaError)
            {
                customTextProviderInfo.AddTextHeder = false;
                st = -1;
            }

            colInfoList = ht;
            colInfoNumberList = al;
            return st;
        }

        // オリジナルスキーマパスを基にユーザ定義スキーマパスを生成
        private string MakeCustomSchemaPath(string originalschemaPath)
        {
            string strTmp = "";
            string cFileName = "";

            // ディレクトリ名, ファイル名を分解
            cFileName = System.IO.Path.GetFileNameWithoutExtension(originalschemaPath);


            // ファイル名に _CD を加えてユーザ定義スキーマファイル名とする( "XXXXXXX_Ex.xml" )
            if ((cFileName != null) && (cFileName != ""))
            {
                cFileName = cFileName + "_Ex" + System.IO.Path.GetExtension(originalschemaPath);
                strTmp = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(originalschemaPath), cFileName);
            }

            return strTmp;

        }



        /// <summary>
        /// スキーマ情報更新(ユーザ定義情報追加)
        /// </summary>
        /// <param name="customTextProviderInfo">提供スキーマ情報(返却値)</param>
        /// <param name="colInfoList">出力項目情報提供スキーマリスト(返却値)</param>
        /// <param name="colInfoNumberList">出力項目情報提供スキーマ出力順リスト(返却値)</param>
        /// <param name="customTextProviderInfoUserDef">ユーザ定義スキーマ情報(返却値)</param>
        /// <param name="colInfoListUserDef">出力項目情報ユーザ定義スキーマリスト(返却値)</param>
        /// <param name="colInfoNumberListUserDef">出力項目情報ユーザ定義スキーマ出力順リスト(返却値)</param>
        /// <remarks>
        /// <br>Note       : 提供スキーマ情報をユーザ定義スキーマで更新します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        private void UpdateSchemaInfoByCustomSchemaInfo(ref CustomTextProviderInfo customTextProviderInfo, ref Hashtable colInfoList, ref ArrayList colInfoNumberList,
                                                        CustomTextProviderInfo customTextProviderInfoUserDef, Hashtable colInfoListUserDef, ArrayList colInfoNumberListUserDef)
        {

            Hashtable orgInfoList = new Hashtable();
            ArrayList newOrgNumberList = new ArrayList();
            Hashtable newOrgInfoList = new Hashtable();


            #region テキスト出力に対するユーザ定義

            // 出力ファイル名称
            if (!customTextProviderInfoUserDef.IsDefaultData_OutPutFileName)
            {
                customTextProviderInfo.OutPutFileName = customTextProviderInfoUserDef.OutPutFileName;
            }

            // 出力フォルダ
            if (!customTextProviderInfoUserDef.IsDefaultData_OutPutFolderName)
            {
                customTextProviderInfo.OutPutFolderName = customTextProviderInfoUserDef.OutPutFolderName;
            }

            // テキスト種類
            if (!customTextProviderInfoUserDef.IsDefaultData_TextKind)
            {
                customTextProviderInfo.TextKind = customTextProviderInfoUserDef.TextKind;
            }

            // テキストフォーマット
            if (!customTextProviderInfoUserDef.IsDefaultData_TextFormat)
            {
                customTextProviderInfo.TextFormat = customTextProviderInfoUserDef.TextFormat;
            }

            // コード体系
            if (!customTextProviderInfoUserDef.IsDefaultData_EncodeType)
            {
                customTextProviderInfo.EncodeType = customTextProviderInfoUserDef.EncodeType;
            }

            // 追加モード
            if (!customTextProviderInfoUserDef.IsDefaultData_AppendMode)
            {
                customTextProviderInfo.AppendMode = customTextProviderInfoUserDef.AppendMode;
            }

            #endregion

            #region 各出力項目に対するユーザ定義

            // ColKey-->ColName インデックスの再構築
            foreach (TextColInfo orgInfDtl in colInfoNumberList)
            {
                orgInfoList.Add(orgInfDtl.ColName, orgInfDtl);
            }

            //--------------------------------------------------------------------------------
            //
            // 各出力項目に対するユーザ定義
            //
            //--------------------------------------------------------------------------------
            foreach (TextColInfo infDtl in colInfoNumberListUserDef)
            {

                if (!infDtl.Enable) 
                {

                    // 出力項目を出力非対称にする(スキーマ情報から項目を削除する)

                    int delIndex = 0;
                    bool delFg = false;
                    for (int idx = 0; idx < colInfoNumberList.Count; idx++)
                    {
                        TextColInfo orgInfDtl = (TextColInfo)colInfoNumberList[idx];

                        if (orgInfDtl.ColName.Trim() == infDtl.ColKey.Trim())
                        {
                            delIndex = idx;
                            delFg = true;
                            break;
                        }
                    }

                    if (delFg)
                    {
                        // 項目情報削除
                        colInfoList.Remove(((TextColInfo)colInfoNumberList[delIndex]).ColKey);
                        colInfoNumberList.RemoveAt(delIndex);
                    }

                }
                else if (orgInfoList.ContainsKey(infDtl.ColKey))
                {

                    TextColInfo orgInfDtl = (TextColInfo)orgInfoList[infDtl.ColKey];
                    if(!infDtl.IsDefaultData_ColWidth)
                    {
                        orgInfDtl.ColWidth = infDtl.ColWidth;
                    }

                    if (!infDtl.IsDefaultData_EditMode)
                    {
                        orgInfDtl.EditMode = infDtl.EditMode;
                    }

                    if (!infDtl.IsDefaultData_DataConvert)
                    {
                        orgInfDtl.DataConvert = infDtl.DataConvert;
                    }

                    if (!infDtl.IsDefaultData_ColName)
                    {
                        orgInfDtl.ColName = infDtl.ColName;
                    }


                    newOrgNumberList.Add(orgInfDtl);
                    newOrgInfoList.Add(orgInfDtl.ColKey, orgInfDtl);
                }


            }

            #endregion


            // ユーザ定義スキーマで列定義されていない列情報を提供スキーマから削除する
            //Hashtable hs = (Hashtable)colInfoList.Clone();
            //foreach (string key in hs.Keys)
            //{
            //    if (!newOrgInfoList.ContainsKey(key))
            //    {
            //        colInfoList.Remove(key);
            //    }
            //}

            colInfoList = newOrgInfoList;
            colInfoNumberList = newOrgNumberList;

            return;
        }


        #endregion スキーマ(ユーザ定義)情報取得


        private string MakeFilePath(int mode, string outPutDir, string filePath)
        { 


            string madePath;

            if (System.IO.File.Exists(filePath))
            {
                // filePath にフルパスが存在する場合はそれでOK
                madePath = filePath;
            }
            // customTextProviderInfo に ファイルパスとディレクトリが指定されていればそれを使用する
           
            else
            {
                // filePathが指定されている場合はそれを合成する           
                madePath = "";
            
            }

            return madePath;
        }



        private string ReadXMLFile(string filePath)
        {
            // 指定されたファイルが通常ファイルか、暗号化されたファイルかを判別して
            // ファイル内容を返す

            string retStr = "";

            CrptographicMaker textCipher = new CrptographicMaker();

            string textTmp = File.ReadAllText(filePath);
            int pos = textTmp.IndexOf("<TextServiceSchema>");

            if (pos > 0)
            {
                // 通常ファイル
                retStr = textTmp;
            }
            else
            {
                // 暗号化ファイル

                retStr = textCipher.GetDecryptText(filePath, "abcdefghijklmn9587432");
            }

//            System.Windows.Forms.MessageBox.Show(retStr);

            return retStr;
        }



        private void SetTextKinds(ref CustomTextProviderInfo customTextProviderInfo, string textkind)
        {

            switch (textkind.ToUpper())
            {
                case "CSV":
                    customTextProviderInfo.TextKind = CustomTextKinds.CSV;
                    break;
                default:
                    customTextProviderInfo.TextKind = CustomTextKinds.CSV;
                    break;
            }

            return;
        }


        private void SetTextFormats(ref CustomTextProviderInfo customTextProviderInfo, string textFormat)
        {

            switch (textFormat.ToUpper())
            {
                case "TEXT":
                    customTextProviderInfo.TextFormat = CustomTextFormats.TEXT;
                    break;
                case "BINARY":
                    customTextProviderInfo.TextFormat = CustomTextFormats.BINARY;
                    break;
                default:
                    customTextProviderInfo.TextFormat = CustomTextFormats.TEXT;
                    break;
            }

            return;
        }

        private void SetEncodeType(ref CustomTextProviderInfo customTextProviderInfo, string encodeType)
        {

            switch (encodeType.ToUpper())
            {
                case "SJIS":
                    customTextProviderInfo.EncodeType = Encoding.Default;
                    break;
                case "UTF-8":
                    customTextProviderInfo.EncodeType = Encoding.UTF8;
                    break;
                default:
                    customTextProviderInfo.EncodeType = Encoding.Default;
                    break;
            }

            return;
        }


        class TransportIndexForDataSet
        {
            public int SourceColIndex;
            public string EditColKey;

            public TransportIndexForDataSet()
            { 
            
            
            }

            public TransportIndexForDataSet(int sourceColIndex, string editColKey)
            {
                SourceColIndex = sourceColIndex;
                EditColKey = editColKey;
            }
        
        }

    }


    internal class TextColInfo
    {

        public TextColInfo()
        { 
        
        
        }

        public TextColInfo(int index, string colKey, string colName, int colWidth, string colDataType, int colEditMode, string colDataConvert)
        {
            ColIndex = index;           // インデックス
            ColKey = colKey;            // キー情報
            ColName = colName;          // 項目名称
            ColWidth = colWidth;        // サイズ(byte)
            ColDataType = colDataType;  // 型
            EditMode = colEditMode;     // 編集方式
            DataConvert = colDataConvert;
        }

        public int ColIndex = 0;               // サイズ(byte)
        public string ColKey = "";             // キー情報
        public string ColName = "";            // 項目名称
        public int ColWidth = 0;               // サイズ(byte)
        public string ColDataType = "";        // 型
        public int EditMode = 0;               // 編集方式
        public string DataConvert = "";        // データコンバート方式 
        public bool Enable = true;             // 出力対象区分(true:出力, false:出力無し) 

        // 各種プロパティの入力状態(true=デフォルト値)
        public bool IsDefaultData_ColName = true;
        public bool IsDefaultData_ColWidth = true;
        public bool IsDefaultData_ColDataType = true;
        public bool IsDefaultData_EditMode = true;
        public bool IsDefaultData_DataConvert = true;
        
        // 各種プロパティの入力状態を変更する
        public void SetDataState(bool colNameState, bool colWidth, bool colDataType, bool editMode, bool dataConvert)
        {
            this.IsDefaultData_ColName = colNameState;
            this.IsDefaultData_ColWidth = colWidth;
            this.IsDefaultData_ColDataType = colDataType;
            this.IsDefaultData_EditMode = editMode;
            this.IsDefaultData_DataConvert = dataConvert;

            return;
        }


    }




    //public enum ColObjectEditMode
    //{ 
    //    DateTimeToInt_YYYYMMDD = 1010;    
    
    
    //}


}
