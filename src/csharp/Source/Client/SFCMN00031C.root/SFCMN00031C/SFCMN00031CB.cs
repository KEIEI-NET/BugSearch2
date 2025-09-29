using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Library.Text
{
    //************************************************************
    //
    //  このソースファイルには「テキスト出力(外部公開クラス)」
    // に関連するクラス, 各種定義が実装されています
    //
    //************************************************************

    /// <summary>
    /// テキスト出力クラス	
    /// </summary>
    /// <remarks>
    /// <br>Note       : クラスやDataSet(DataTable)メンバ値をテキスト化する</br> 
    /// <br>           : 各種サービスを提供します</br>
    /// <br>Programmer : 980056 R.Sokei</br>
    /// <br>Date       : 2006.04.25</br>
	/// <br>Update Date: ① 2007.06.26 小田　義昭 (20015)
	///                :    追加モードでの出力時、ヘッダが出力されていたので、Pegasusと同様に追加時は
	///                :    ヘッダを出力しないように変更
	/// </br>
	/// </remarks>
    public class CustomTextWriter 
    {

        public CustomTextWriter()
        {
            TextIO = new CustomTextProvider();
        }

        private CustomTextProvider TextIO;

        /// <summary>
        /// テキストデータ取得
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="text">生成テキスト</param>
        /// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
        /// <remarks>
        /// <br>Note       : sourceのメンバ値リストをテキストデータとして取得します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int GetText(object source, string schemaPath, out string text)
        {
            return GetText(source, schemaPath, out text, null);
        }


        /// <summary>
        /// テキストデータ取得
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="text">生成テキスト</param>
        /// <param name="textInfo">カスタムテキスト作成用情報</param>
        /// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
        /// <remarks>
        /// <br>Note       : sourceのメンバ値リストをテキストデータとして取得します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int GetText(object source, string schemaPath, out string text, CustomTextProviderInfo customTextProviderInfo)
        {
            customTextProviderInfo = SetCustomTextProviderInfo(schemaPath, "", customTextProviderInfo);
            return MakeTextProc(source, out text, customTextProviderInfo);
        }


        /// <summary>
        /// テキストデータ出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="outputFilepath">出力ファイルパス</param>
        /// <param name="appendMode">テキスト追加モード true:追加モード, false:上書きモード</param>
        /// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
        /// <remarks>
        /// <br>Note       : sourceのメンバ値リストをテキストデータとしてファイルに出力します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int WriteText(object source, string schemaPath, string outputFilepath, bool appendMode)
        {
            CustomTextProviderInfo customTextProviderInfo = SetCustomTextProviderInfo(schemaPath, outputFilepath, null);
            customTextProviderInfo.AppendMode = appendMode;
            return WriteText(source, schemaPath, outputFilepath, customTextProviderInfo);
        }

        /// <summary>
        /// テキストデータ出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="outputFilepath">出力ファイルパス</param>
        /// <param name="textInfo">カスタムテキスト作成用情報</param>
        /// <returns>処理結果 0:処理成功, 4:対象データなし, -9:出力対象外のデータが指定された, -1:その他エラー</returns>
        /// <remarks>
        /// <br>Note       : sourceのメンバ値リストをテキストデータとしてファイルに出力します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int WriteText(object source, string schemaPath, string outputFilepath, CustomTextProviderInfo customTextProviderInfo)
        {
			string text;
            customTextProviderInfo = SetCustomTextProviderInfo(schemaPath, outputFilepath, customTextProviderInfo);

// >>>> 2007.06.26 小田 Add ＠追加出力時ヘッダ無し対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			// 追加モードチェック（UI上無チェックで追加モードにできる。本当はファイルが無いのに追加モードで来る可能性があるためチェック）
			if (customTextProviderInfo.AppendMode == true)
			{
				customTextProviderInfo.AppendMode = AppendModeCheck(customTextProviderInfo);
			}
// <<<< 2007.06.26 小田 Add ＠追加出力時ヘッダ無し対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // テキスト生成
            int st = MakeTextProc(source, out text, customTextProviderInfo);

            // テキストファイルへ出力
//            MakeTextFile(text, ref outputFilepath, 0, System.Text.Encoding.Default);
			MakeTextFile(text, ref customTextProviderInfo);


            return st; 

        }
		/// <summary>
		/// 追加モードチェック処理
		/// </summary>
		/// <param name="customTextProviderInfo">テキスト出力サービルパラメータ</param>
		/// <returns>追加モード(True:追加モード,False:上書きモード)</returns>
		/// <remarks>
		/// <br>Note       : テキスト出力サービス呼び側では、チェック無しで追加モードを指定されるので、追加モードで良いかチェックを行う</br>
		/// <br>Programmer : 小田　義昭</br>
		/// <br>Date       : 2007.06.26</br>
		/// </remarks>
		private bool AppendModeCheck(CustomTextProviderInfo customTextProviderInfo)
		{
			string lOutputFilepath;
			string folderName = "";

			// 出力ファイル名称が未設定の場合 ⇒ 上書きモードに変更
			if ((customTextProviderInfo.OutPutFileName == null) ||
				((customTextProviderInfo.OutPutFileName != null) && (customTextProviderInfo.OutPutFileName.Trim() == "")))
				return false;

			// 出力ディレクトリとファイル名を合成
			if ((customTextProviderInfo.OutPutFolderName != null) && (customTextProviderInfo.OutPutFolderName.Trim() != ""))
			{
				folderName = customTextProviderInfo.OutPutFolderName;
			}
			else
			{
				folderName = System.IO.Directory.GetCurrentDirectory();
			}

			if (folderName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
			{
				lOutputFilepath = folderName + customTextProviderInfo.OutPutFileName;
			}
			else
			{
				lOutputFilepath = folderName + System.IO.Path.DirectorySeparatorChar.ToString() + customTextProviderInfo.OutPutFileName;
			}

			// ファイルが存在しない場合 ⇒ 上書きモードに変更
			if (System.IO.File.Exists(lOutputFilepath) == false) return false;

			try
			{
				// ファイルが存在する場合は、ファイルの中に行が存在するのかチェック
				System.IO.StreamReader reader = new System.IO.StreamReader(lOutputFilepath);

				if (reader == null) return false;

				string oneLine = reader.ReadLine();

				// １行目が読み込めない場合
				if ((oneLine == null) || ((oneLine != null) && (oneLine.Trim() == ""))) return false;

				reader.Close();
			}
			catch
			{
				// エラーは無視
				return false;
			}

			return true;
		}


        public CustomTextProviderInfo GetCustomTextProviderInfo(string schemaPath)
        {
            CustomTextProviderInfo inf;
            TextIO.ReadSchemaInfo(schemaPath, out inf);

            if (inf == null)
            {
                inf = CustomTextProviderInfo.GetDefaultInfo();
            }

            return inf;

        }


        private CustomTextProviderInfo SetCustomTextProviderInfo(string schemaPath, string outputFilepath, CustomTextProviderInfo customTextProviderInfo)
        {
            CustomTextProviderInfo ltmp;

            if (customTextProviderInfo == null)
            {
                // textInfo が指定されていない場合
                if ((schemaPath != null) && (schemaPath.Trim() != ""))
                {
                    // schemaPathが指定されていれば、その設定を使用する
                    TextIO.ReadSchemaInfo(schemaPath, out ltmp);
                }
                else
                {
                    // schemaPathも無い場合はデフォルト設定を使用する
                    ltmp = CustomTextProviderInfo.GetDefaultInfo();
                }
            }
            else
            {
                // customTextProviderInfoがある場合は、それを使用する
                ltmp = customTextProviderInfo;
            }

            // schemaPathが指定されていれば、そのパスを転記する
            if ((schemaPath != null) && (schemaPath.Trim() != ""))
            {
                ltmp.SchemaFileName = schemaPath;

            }

            // outputFilepathが指定されていれば、そのパスを分解して転記する
            if ((outputFilepath != null) && (outputFilepath.Trim() != ""))
            {

                ltmp.OutPutFileName = System.IO.Path.GetFileName(outputFilepath);
                ltmp.OutPutFolderName = System.IO.Path.GetDirectoryName(outputFilepath);

            }
            
            return ltmp;
        }

        /// <summary>
        /// テキストデータ出力
        /// </summary>
        /// <param name="source">操作対象オブジェクト</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="schemaPath">出力ファイルパス</param>
        /// <param name="textInfo">カスタムテキスト作成用情報</param>
        /// <remarks>
        /// <br>Note       : sourceのメンバ値リストをテキストデータとしてファイルに出力します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        private int MakeTextProc(object source, out string text, CustomTextProviderInfo textInfo)
        {
            string strTmp;
            int st = 0;

            if(textInfo == null)
            {
                textInfo = new CustomTextProviderInfo();
            }
            
            if (source is DataSet)
            {
                st = TextIO.DataSetToText((DataSet)source, out strTmp, textInfo);
            }
            else if (source is DataTable)
            {
                // データソースが DataTable の場合は DataSetを作成して DataTable を格納する
                DataSet ds = new DataSet("systemMadeDataSet");

//				ds.Tables.Add((DataTable)source);				// 2006.08.30 小田 Del

// >>>>> 2006.08.30 小田 Add ここから >>>>>>>>>>>>>>>>>>>>>>>>
				// 出力対象データがDataTableの場合は、既に渡されたTableがDataSetに既に属している可能性があるので、テーブルをCOPYする
				DataTable dt = ((DataTable)source).Copy();
				ds.Tables.Add(dt);

                st = TextIO.DataSetToText(ds, out strTmp, textInfo);
// <<<<> 2006.08.30 小田 Add ここまで <<<<<<<<<<<<<<<<<<<<<<<<

			}
// >>>>> 2006.08.30 小田 Add ここから >>>>>>>>>>>>>>>>>>>>>>>>
			// DataViewの対応
			else if (source is DataView)
			{ 
				DataView dv = (DataView)source;

				DataSet ds = new DataSet("systemMadeDataSet");
				DataTable dt = dv.ToTable();

				ds.Tables.Add(dt);
				 
				st = TextIO.DataSetToText(ds, out strTmp, textInfo);
			}
// <<<<> 2006.08.30 小田 Add ここまで <<<<<<<<<<<<<<<<<<<<<<<<
			else
			{

				// データソース(操作対象オブジェクト)をArrayListに入れなおす
				ArrayList al;
				if (source is ArrayList)
				{
					al = (ArrayList)source;
				}
				else if (source is Array)
				{
					al = new ArrayList((Array)source);
				}
				else
				{
					al = new ArrayList();
					al.Add(source);
				}

				st = TextIO.ClassMemberToText(al, out strTmp, textInfo);

			}


            text = strTmp;
            return st;
        }


        /// <summary>
        /// テキストデータ出力
        /// </summary>
        /// <param name="source">出力データ</param>
        /// <param name="schemaPath">出力ファイルパス</param>
        /// <param name="cipherMode">暗号モード 0:暗号化なし, 0<>暗号化有り</param>
        /// <remarks>
        /// <br>Note       : sourceをファイルに出力します</br>
        /// <br>           : 出力ファイルパスをしてしなかった場合は自動生成したファイルパスを返します</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
//        private int MakeTextFile(string source, ref string outputFilepath, int cipherMode, System.Text.Encoding enCode)
        private int MakeTextFile(string source, ref CustomTextProviderInfo customTextProviderInfo)
        {
            int st = 0;

            string lOutputFilepath;
            string lOutputFileName = customTextProviderInfo.OutPutFileName;

            if ((lOutputFileName != null) && (lOutputFileName.Trim() != ""))
            {
                // テキスト置換処理

            }
            else 
            {
                // 出力ファイル名称生成
                lOutputFileName = Guid.NewGuid().ToString() + ".csv";

            }
            
            // 出力ディレクトリとファイル名を合成
//            lOutputFilepath = System.IO.Path.Combine(customTextProviderInfo.outPutFolderName, "\\"+lOutputFileName);
            if (customTextProviderInfo.OutPutFolderName == null)
            {
                customTextProviderInfo.OutPutFolderName = System.IO.Directory.GetCurrentDirectory();
            }


            if (customTextProviderInfo.OutPutFolderName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
            {
                lOutputFilepath = customTextProviderInfo.OutPutFolderName + lOutputFileName;
            }
            else
            {
                lOutputFilepath = customTextProviderInfo.OutPutFolderName + System.IO.Path.DirectorySeparatorChar.ToString() + lOutputFileName;
            }

            //          outputFilepath = System.IO.Path.Combine
//            System.Windows.Forms.MessageBox.Show(customTextProviderInfo.outPutFolderName + "\n" + lOutputFileName + "\n" + lOutputFilepath);

            // Shift JIS コードで書き出し
            System.IO.StreamWriter writer =
                new System.IO.StreamWriter(lOutputFilepath, customTextProviderInfo.AppendMode,
                    customTextProviderInfo.EncodeType);
//            writer.WriteLine(source);								// 2007.06.26 小田 Del ＠追加出力時ヘッダ無し対応
			writer.Write(source);									// 2007.06.26 小田 Add ＠追加出力時ヘッダ無し対応
            writer.Close();

            return st;
        }

    }


}
