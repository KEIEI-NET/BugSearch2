using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// CSVチェックツール　アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 共通処理等</br>
    /// <br>Programmer	: 23006  高橋 明子</br>
    /// <br>Date		: 2014.08.27</br>
    /// </remarks>
    public class PMKHN09951A_Common
    {
        /// <summary>出力モード</summary>
        public enum OutputMode
        {
            /// <summary>キー単位に羅列</summary>
            ctByTheKey = 1,
            /// <summary>ベースとの比較チェック</summary>
            ctForCompCheck = 2,
            /// <summary>統合用</summary>
            ctForConsolidate = 3,
        }

        /// <summary>CSVチェックツールパラメータクラス</summary>
        public class CSVCheckToolPara
        {
            #region
            /// <summary>プライマリーキーリスト</summary>
            private SortedList<int, int> _primaryKeyList = null;

            /// <summary>対象ファイルメイン　パス</summary>
            private string _mainFilePath = null;

            /// <summary>対象ファイルメイン　ファイル表示名称</summary>
            private string _mainFileDispName = "メイン";

            /// <summary>対象ファイルサブ　パスList</summary>
            private Dictionary<string, string> _subFilePathList = null;

            /// <summary>出力モード</summary>
            private OutputMode _outputMode = OutputMode.ctForCompCheck;

            /// <summary>比較項目List</summary>
            private List<int> _comparItemList = null;

            /// <summary>ソート項目List</summary>
            private SortedList<int, int> _sortItemList = null;

            /// <summary>出力ファイルパス</summary>
            private string _outputFilePath = null;

            /// <summary>ヘッダー行有無区分</summary>
            private bool _headerLineExistDiv = false;

            /// public propaty name  :  PrimaryKeyList
            /// <summary>プライマリーキーリストプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   プライマリーキーリストプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public SortedList<int, int> PrimaryKeyList
            {
                get { return _primaryKeyList; }
                set { _primaryKeyList = value; }
            }

            /// public propaty name  :  MainFilePath
            /// <summary>対象ファイルメイン　パスプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   対象ファイルメイン　パスプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string MainFilePath
            {
                get { return _mainFilePath; }
                set { _mainFilePath = value; }
            }

            /// public propaty name  :  MainFileDispName
            /// <summary>対象ファイルメイン　ファイル表示名称プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   対象ファイルメイン　ファイル表示名称プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string MainFileDispName
            {
                get { return _mainFileDispName; }
                set { _mainFileDispName = value; }
            }

            /// public propaty name  :  SubFilePathList
            /// <summary>対象ファイルサブ　パスListプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   対象ファイルサブ　パスListプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Dictionary<string, string> SubFilePathList
            {
                get { return _subFilePathList; }
                set { _subFilePathList = value; }
            }

            /// public propaty name  :  OutputMode
            /// <summary>出力モードプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   出力モードプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public OutputMode OutputMode
            {
                get { return _outputMode; }
                set { _outputMode = value; }
            }

            /// public propaty name  :  ComparItemList
            /// <summary>比較項目Listプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   比較項目Listプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public List<int> ComparItemList
            {
                get { return _comparItemList; }
                set { _comparItemList = value; }
            }


            /// public propaty name  :  SortItemList
            /// <summary>ソート項目Listプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ソート項目Listプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public SortedList<int, int> SortItemList
            {
                get { return _sortItemList; }
                set { _sortItemList = value; }
            }

            /// public propaty name  :  OutputFilePath
            /// <summary>出力ファイルパスプロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   出力ファイルパスプロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public string OutputFilePath
            {
                get { return _outputFilePath; }
                set { _outputFilePath = value; }
            }

            /// public propaty name  :  HeaderLineExistDiv
            /// <summary>ヘッダー行有無区分プロパティ</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ヘッダー行有無区分プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public bool HeaderLineExistDiv
            {
                get { return _headerLineExistDiv; }
                set { _headerLineExistDiv = value; }
            }

            /// <summary>
            /// CSVチェックツール パラメータ
            /// </summary>
            /// <returns>ExportImportAcsPgInfoClassクラスのインスタンス</returns>
            /// <remarks>
            /// <br>Note　　　　　　 :   CSVCheckToolParaクラスの新しいインスタンスを生成します</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public CSVCheckToolPara()
            {
            }
            #endregion
        }
    }
}
