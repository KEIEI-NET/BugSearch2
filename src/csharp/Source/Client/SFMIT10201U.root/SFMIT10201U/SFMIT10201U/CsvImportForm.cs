using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Library.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// CSV取込クラス
    /// </summary>
    public partial class CsvImportForm : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CsvImportForm()
        {
            InitializeComponent();
        }
        #endregion

        #region const
        // アセンブリID
        private const string CT_ASSEMBLYID = "SFMIT010201U";
        //　フォーマットファイル名
        private const string CT_TIRE = "tire.csv";
        private const string CT_OIL = "oil.csv";
        private const string CT_BATTERY = "battery.csv";
        // ヘッダーフォーマット
        //private const string CT_HEADERCOMMON = @" ""公開(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON)"", ""ｵｽｽﾒ(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON)"", ""品番"", ""ﾒｰｶｰCD"", ""ﾒｰｶｰ名"",";
        //private const string CT_HEADERCOMMON = @"""公開(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON)"", ""ｵｽｽﾒ(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON)"", ""品番"", ""ﾒｰｶｰCD"", ""ﾒｰｶｰ名"",";
        private const string CT_HEADERCOMMON = @"公開(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON),ｵｽｽﾒ(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON),品番,ﾒｰｶｰCD,ﾒｰｶｰ名,";



        //private const string CT_HEADER_TIRE = @" ""ｻｲｽﾞ(例:205/65R15)"", ""ｽﾀｯﾄﾞﾚｽ(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON)"",";
        private const string CT_HEADER_TIRE = @"ｻｲｽﾞ(例:205/65R15),ｽﾀｯﾄﾞﾚｽ(数値入力⇒0:ﾁｪｯｸOFF、1:ﾁｪｯｸON),";

        //private const string CT_HEADER_BATTERY = @" ""規格(例:50B24)"", ""適合(数値入力⇒1:標準車専用、2:ISS車専用、3:兼用)"",";
        private const string CT_HEADER_BATTERY = @"規格(例:50B24),適合(数値入力⇒1:標準車専用、2:ISS車専用、3:兼用),";


        //private const string CT_HEADER_OIL = @" ""粘度(例:0W-20)"", ""適合(数値入力⇒1:ｶﾞｿﾘﾝ専用、2:ﾃﾞｨｰｾﾞﾙ専用、3:兼用)"",";
        private const string CT_HEADER_OIL = @"粘度(例:0W-20),適合(数値入力⇒1:ｶﾞｿﾘﾝ専用、2:ﾃﾞｨｰｾﾞﾙ専用、3:兼用),";


        //private const string CT_HEADERCOMMON2 = @" ""商品名称"", ""商品説明"", ""商品見出し"", ""発売日(例:20160601)"", ""公開開始日(例:20160601)"", ""公開終了日(例:20160630)"",";
        private const string CT_HEADERCOMMON2 = @"商品名称,商品説明,商品見出し,発売日(例:20160601),公開開始日(例:20160601),公開終了日(例:20160630),";


        //private const string CT_HEADER_PM = @" ""在庫状態(数値入力⇒1:○、2:△、3：×)"", ""標準価格"", ""店頭価格"", ""売価"", ""仕入原価"" ";
        private const string CT_HEADER_PM = @"在庫状態(数値入力⇒1:○、2:△、3：×),標準価格,店頭価格,売価,仕入原価";

        //private const string CT_HEADER_SF = @" ""標準価格"", ""店頭価格"", ""仕入原価"" ";
        private const string CT_HEADER_SF = @"標準価格,店頭価格,仕入原価";
        #endregion

        private const int RELEASE = 0;              //公開
        private const int RECOMMEND = 1;            //オススメ
        private const int GOODSNO = 2;              //品番
        private const int MAKERCD = 3;              //メーカーコード
        private const int MAKERNM = 4;              //メーカー名称
        private const int TAG1 = 5;                 // 商品タグ1
        private const int TAG2 = 6;                 // 商品タグ2
        private const int GOODSNM = 7;              //商品名称
        private const int GOODSNOTE = 8;            //商品説明 
        private const int GOODSPR = 9;              //商品PR
        private const int RELEASEDATE = 10;         //発売日
        private const int SHOPSALEBEGINDATE = 11;   //公開開始日
        private const int SHOPSALEENDDATE = 12;     //公開終了日
        private const int STOCKSTATE = 13;          //在庫状態
        private const int SUGGEST_PRICE = 14;       //標準価格
        private const int SHOPP_PRICE = 15;         //店頭価格
        private const int TRADE_PRICE_PM = 16;      //(部品商:販売価格)
        private const int PURCHASE_COST = 17;       //仕入原価

        private const int SF_SUGGEST_PRICE = 13;    //標準価格(SF)
        private const int SF_SHOPP_PRICE = 14;      //店頭価格(SF)
        private const int SF_PURCHASE_COST = 15;    //仕入原価(SF)

        #region memo

        // 取込エラー時
        private const string ct_ErrSt = "-999";
        private const int ct_ErrInt = -999;
        private const short ct_Errshort = -999;
        private const double ct_ErrDouble = -999;

        // 共通
        // 0:公開, 1:ｵｽｽﾒ ,2:品番, 3:ﾒｰｶｰCD, 4:ﾒｰｶｰ名
        // 7:商品名称, 8:商品説明 ,9:商品PR, 10:発売日, 11:公開開始日, 12:公開終了日

        // タイヤ
        // 5:ｻｲｽﾞ, 6:ｽﾀｯﾄﾞﾚｽ

        // バッテリ
        // 5:規格, 6:適合

        // オイル
        // 5:粘度, 6:適合


        // PM
        // 13:在庫状態, 14:標準価格, 15:店頭価格, 16:売価, 17:仕入原価

        // SF
        // 13:標準価格, 14:店頭価格, 15:仕入原価

        #endregion

        #region メンバ
        // 起動モード(1:整備工場、2：部品商)
        public int _bootMode;
        // カテゴリID
        public long _categoryId;
        // カテゴリ名称
        public string _categoryName;
        // カラムリスト
        public List<string> _colList;
        // 提案商品クラス
        public List<Propose_Goods> _proposeGoodsList;
        // OpenFileダイアログ
        private OpenFileDialog _openFileDialog;
        // フォーマットファイル名
        private string _formatFileNm;

        // 日付の上限(カレンダーの上限に合わせる)
        private DateTime _minValue;
        private DateTime _maxValue;
        #endregion

        #region Public
        /// <summary>
        /// 起動処理
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowCsvImportForm()
        {
            // カテゴリ名称を設定
            this.Category_textBox.Text = _categoryName;
            this._openFileDialog = new OpenFileDialog();
            this._openFileDialog.Filter = "CSVファイル(*.csv)|*.csv";
            this._openFileDialog.RestoreDirectory = true;

            this._proposeGoodsList = new List<Propose_Goods>();

            this._formatFileNm = "";
            //if (this._categoryId == 1) this._formatFileNm = CT_TIRE;
            //if (this._categoryId == 2) this._formatFileNm = CT_OIL;
            //if (this._categoryId == 3) this._formatFileNm = CT_BATTERY;

            if (this._categoryId == 1) this._formatFileNm = CT_TIRE;
            if (this._categoryId == 2) this._formatFileNm = CT_BATTERY;
            if (this._categoryId == 3) this._formatFileNm = CT_OIL;

            this._minValue = new DateTime(1753, 1, 1);
            this._maxValue = new DateTime(9998, 12, 31);


            return this.ShowDialog();
        }
        #endregion

        #region Private
        /// <summary>
        /// 出力ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Output_button_Click(object sender, EventArgs e)
        {
            // 出力先指定

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //上部に表示する説明テキストを指定する
            fbd.Description = "フォーマット出力先フォルダを選択して下さい。";

            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                string path = fbd.SelectedPath;


                if (File.Exists(Path.Combine(fbd.SelectedPath, this._formatFileNm)))
                {
                    DialogResult rlt = TMsgDisp.Show(
                       this,							            // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_INFO,	                // エラーレベル
                       CT_ASSEMBLYID,					            // アセンブリIDまたはクラスID
                       this._formatFileNm + "は既に存在します。"
                       + Environment.NewLine
                       + "上書きしますか？",	                    // 表示するメッセージ 
                       0,								            // ステータス値
                       MessageBoxButtons.YesNo);

                    if (rlt == DialogResult.No) return;
                }

                string text2 = "";

                switch (this._categoryId)
                {
                    case 1:
                        text2 += CT_HEADERCOMMON + CT_HEADER_TIRE + CT_HEADERCOMMON2;
                        if (this._bootMode == 1)
                        {
                            text2 += CT_HEADER_PM;
                        }
                        else
                        {
                            text2 += CT_HEADER_SF;
                        }
                        break;
                    case 2:
                        text2 += CT_HEADERCOMMON + CT_HEADER_BATTERY + CT_HEADERCOMMON2;
                        if (this._bootMode == 1)
                        {
                            text2 += CT_HEADER_PM;
                        }
                        else
                        {
                            text2 += CT_HEADER_SF;
                        }
                        break;
                    case 3:
                        text2 += CT_HEADERCOMMON + CT_HEADER_OIL + CT_HEADERCOMMON2;
                        if (this._bootMode == 1)
                        {
                            text2 += CT_HEADER_PM;
                        }
                        else
                        {
                            text2 += CT_HEADER_SF;
                        }
                        break;
                }

                try
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path, this._formatFileNm), false, System.Text.Encoding.GetEncoding("shift_jis")))
                    {
                        //sw.WriteLine(text1);
                        sw.WriteLine(text2);

                        TMsgDisp.Show(
                        this,							            // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,	            // エラーレベル
                        CT_ASSEMBLYID,					            // アセンブリIDまたはクラスID
                        "フォーマットファイルを出力しました。",	    // 表示するメッセージ 
                        0,								            // ステータス値
                        MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(
                       this,							        // 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_STOPDISP,	        // エラーレベル
                       CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                       "出力に失敗しました。" 
                       + Environment.NewLine
                       + ex.StackTrace.ToString(),	            // 表示するメッセージ 
                       -1,								        // ステータス値
                       MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// 取込ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import_button_Click(object sender, EventArgs e)
        {
            //ダイアログボックスの初期設定を行う
            DialogResult ret = this._openFileDialog.ShowDialog();
            if (ret == DialogResult.OK)
            {
                long rowNo = 0;
                string errMsg = "";
                List<string> errMsgList = new List<string>();

                try
                {
                    string path = Path.GetFullPath(_openFileDialog.FileName);

                    // CSV取込
                    Encoding Encode = Encoding.GetEncoding("Shift_JIS");    // Encode指定
                    using (TextFieldParser Parser = new TextFieldParser(path, Encode))
                    {
                        Parser.TextFieldType = FieldType.Delimited;    // フィールド区切りタイプ
                        Parser.Delimiters = new string[] { "," };      // 区切り文字
                        //Parser.HasFieldsEnclosedInQuotes = true;       // ダブルコーテーション区切り
                        Parser.HasFieldsEnclosedInQuotes = false;       // ダブルコーテーション区切り
                        //Parser.CommentTokens = new string[] { "#" };     // レコード先頭のコメント文字
                        Parser.TrimWhiteSpace = true;                  // フィールドの前後スペースを削除

                        bool firstData = false;

                       

                        // データ読み込み
                        while (!Parser.EndOfData)
                        {
                            string[] fields = Parser.ReadFields();

                            // 行番号
                            rowNo = Parser.LineNumber == -1 ? rowNo + 1 : Parser.LineNumber - 1;

                            // 1行目はヘッダとして読み飛ばし
                            if (firstData == false)
                            {
                                firstData = true;
                                continue;
                            }

                            // 不正データチェック　不正データは読み飛ばしログ表示
                            // 「,」チェック
                            if (this._bootMode == 1)
                            {
                                // 部品商モード
                                // 正常：18件

                                if (fields.Length < 18)
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "CSVファイル内の項目数が不足しています。" + " " + "項目数を確認して下さい。";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                                else if (fields.Length > 18)
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "CSVファイル内の項目数が超過しています。" + "項目に「,(カンマ)」が含まれていないか確認して下さい。";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                            }
                            else
                            {
                                // 整備工場モード
                                // 正常16件
                                if (fields.Length < 16)
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "CSVファイル内の項目数が不足しています。" + " " + "項目数を確認して下さい。";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                                else if (fields.Length > 16)
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "CSVファイル内の項目数が超過しています。" + "項目に「,(カンマ)」が含まれていないか確認して下さい。";
                                    errMsgList.Add(errMsg);
                                    continue;
                                }
                            }

                            Propose_Goods goods = new Propose_Goods();
                            goods.GoodsCategory = this._categoryId;

                            // 公開 
                            try
                            {
                                if (fields[RELEASE].Equals("0") || fields[RELEASE].Equals("1"))
                                {
                                    goods.release = Convert.ToInt32(fields[RELEASE]);
                                }
                                else
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「公開」の取込に失敗しました。" + " " + "0又は1を設定して下さい。";
                                    goods.release = ct_ErrInt;
                                    errMsgList.Add(errMsg);
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「公開」の取込に失敗しました。" + " " + "0又は1を設定して下さい。";
                                goods.release = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // オススメ
                            try
                            {
                                if (fields[RECOMMEND].Equals("0") || fields[RECOMMEND].Equals("1"))
                                {
                                    goods.recommend = Convert.ToInt32(fields[RECOMMEND]);
                                }
                                else
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「オススメ」の取込に失敗しました。" + " " + "0又は1を設定して下さい。";
                                    goods.recommend = ct_ErrInt;
                                    errMsgList.Add(errMsg);
                                }
                               
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「オススメ」の取込に失敗しました。" + " " + "0又は1を設定して下さい。";
                                goods.recommend = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // 品番 MAX24桁 イレギュラー値の場合は""
                            if (fields[GOODSNO].Length <= 24)
                            {
                                goods.GoodsNo = fields[GOODSNO];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「品番」の取込に失敗しました。" + " " + "24桁以内で入力して下さい。";
                                goods.GoodsNo = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // メーカーコード MAX4桁 
                            try
                            {
                                // 数値項目のみ未入力の場合は0扱いする
                                if (string.IsNullOrEmpty(fields[MAKERCD]))
                                {
                                    // 未入力の場合は0扱い
                                    goods.GoodsMakerCd = 0;
                                }
                                else
                                {
                                    int GoodsMakerCd = Convert.ToInt32(fields[MAKERCD]);
                                    if (GoodsMakerCd < 0)
                                    {
                                        errMsg = "<" + rowNo + "行目>" + " " + "「メーカーCD」の取込に失敗しました。" + " " + "マイナスは使用できません。";
                                        goods.GoodsMakerCd = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                    else if (GoodsMakerCd.ToString().Length <= 4)
                                    {
                                        goods.GoodsMakerCd = GoodsMakerCd;
                                    }
                                    else 
                                    {
                                        errMsg = "<" + rowNo + "行目>" + " " + "「メーカーCD」の取込に失敗しました。" + " " + "4桁以内で入力して下さい。";
                                        goods.GoodsMakerCd = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「メーカーCD」の取込に失敗しました。" + " " + "不正な値です。";
                                goods.GoodsMakerCd = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // メーカー名称 MAX30桁 イレギュラー値の場合は""
                            if (fields[MAKERNM].Length <= 30)
                            {
                                goods.MakerName = fields[MAKERNM];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「メーカー名称」の取込に失敗しました。" + " " + "30桁以内で入力して下さい。";
                                goods.MakerName = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // 商品名称 MAX60桁 イレギュラー値の場合は""
                            if (fields[GOODSNM].Length <= 60)
                            {
                                goods.GoodsName = fields[GOODSNM];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「商品名称」の取込に失敗しました。" + " " + "60桁以内で入力して下さい。";
                                goods.GoodsName = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // 商品説明 MAX256 イレギュラー値の場合は""
                            if (fields[GOODSNOTE].Length <= 256)
                            {
                                goods.GoodsNote = fields[GOODSNOTE];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「商品説明」の取込に失敗しました。" + " " + "256桁以内で入力して下さい。";
                                goods.GoodsNote = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // 商品PR MAX15 イレギュラー値の場合は""
                            if (fields[GOODSPR].Length <= 15)
                            {
                                goods.GoodsPR = fields[GOODSPR];
                            }
                            else
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「商品見出し」の取込に失敗しました。" + " " + "15桁以内で入力して下さい。";
                                goods.GoodsPR = ct_ErrSt;
                                errMsgList.Add(errMsg);
                            }

                            // 発売日 YYYYMMDD イレギュラー値の場合は0
                            try
                            {
                                if (string.IsNullOrEmpty(fields[RELEASEDATE]))
                                {
                                    // 未入力の場合は0扱い
                                    goods.ReleaseDate = 0;
                                }
                                else
                                {
                                    int ReleaseDate = Convert.ToInt32(fields[RELEASEDATE]);
                                    if (ReleaseDate == 0)
                                    {
                                        // 0はOK
                                        goods.ReleaseDate = ReleaseDate;
                                    }
                                    else if (ReleaseDate.ToString().Length == 8)
                                    {
                                        DateTime releaseDate = DateTime.MinValue;
                                        // カルチャー設定
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        releaseDate = DateTime.ParseExact(ReleaseDate.ToString(), "yyyyMMdd", format);

                                        if ((releaseDate != DateTime.MinValue) &&
                                            (releaseDate >= this._minValue && releaseDate <= this._maxValue) // カレンダーコンポの範囲内
                                            )
                                        {
                                            goods.ReleaseDate = ReleaseDate;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「発売日」の取込に失敗しました。" + " " + "不正な値です。";
                                            goods.ReleaseDate = ct_ErrInt;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "行目>" + " " + "「発売日」の取込に失敗しました。" + " " + "8桁で入力して下さい。";
                                        goods.ReleaseDate = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「発売日」の取込に失敗しました。" + " " + "不正な値です。";
                                goods.ReleaseDate = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // 商品タグ MAX32桁 イレギュラー値の場合は""
                            if (fields[TAG1].Length <= 32)
                            {
                                goods.SearchTag1 = fields[TAG1];
                            }
                            else
                            {
                                switch (this._categoryId)
                                {
                                    case 1:
                                        errMsg = "<" + rowNo + "行目>" + " " + "「サイズ」の取込に失敗しました。" + " " + "32桁以内で入力して下さい。";
                                        goods.SearchTag1 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                        break;
                                    case 2:
                                        errMsg = "<" + rowNo + "行目>" + " " + "「規格」の取込に失敗しました。" + " " + "32桁以内で入力して下さい。";
                                        goods.SearchTag1 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                        break;
                                    case 3:
                                        errMsg = "<" + rowNo + "行目>" + " " + "「粘度」の取込に失敗しました。" + " " + "32桁以内で入力して下さい。";
                                        goods.SearchTag1 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                        break;
                                }
                            }

                            // 商品タグ２～３　イレギュラー値の場合は""
                            switch (this._categoryId)
                            {
                                case 1:
                                    if (fields[TAG2].Equals("0") || fields[TAG2].Equals("1"))
                                    {
                                        goods.SearchTag2 = fields[TAG2];
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "行目>" + " " + "「スタッドレス」の取込に失敗しました。" + " " + "0又は1を設定して下さい。";
                                        goods.SearchTag2 = ct_ErrSt;
                                        errMsgList.Add(errMsg);
                                    }
                                    break;
                                case 2:
                                    switch (fields[TAG2])
                                    {
                                        case "1":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "0";
                                            break;
                                        case "2":
                                            goods.SearchTag2 = "0";
                                            goods.SearchTag3 = "1";
                                            break;
                                        case "3":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "1";
                                            break;
                                        default:
                                            errMsg = "<" + rowNo + "行目>" + " " + "「適合」の取込に失敗しました。" + " " + "1、2、3の何れかを設定して下さい。";
                                            goods.SearchTag2 = ct_ErrSt;
                                            goods.SearchTag3 = ct_ErrSt;
                                            errMsgList.Add(errMsg);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (fields[TAG2])
                                    {
                                        case "1":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "0";
                                            break;
                                        case "2":
                                            goods.SearchTag2 = "0";
                                            goods.SearchTag3 = "1";
                                            break;
                                        case "3":
                                            goods.SearchTag2 = "1";
                                            goods.SearchTag3 = "1";
                                            break;
                                        default:
                                            errMsg = "<" + rowNo + "行目>" + " " + "「適合」の取込に失敗しました。" + " " + "1、2、3の何れかを設定して下さい。";
                                            goods.SearchTag2 = ct_ErrSt;
                                            goods.SearchTag3 = ct_ErrSt;
                                            errMsgList.Add(errMsg);
                                            break;
                                    }
                                    break;
                            }

                            // 公開開始日
                            try
                            {
                                // 未入力、0の場合は結果的にシステム日付
                                if (string.IsNullOrEmpty(fields[SHOPSALEBEGINDATE]))
                                {
                                    // 未入力の場合は0扱い
                                    goods.ShopSaleBeginDate = 0;
                                }
                                else
                                {
                                    int beginDate = Convert.ToInt32(fields[SHOPSALEBEGINDATE]);
                                    if (beginDate == 0)
                                    {
                                        // 0はOK ただしシステム日付が入る
                                        goods.ShopSaleBeginDate = beginDate;
                                    }
                                    else if (beginDate.ToString().Length == 8)
                                    {
                                        DateTime beginDateTime = DateTime.MinValue;
                                        // カルチャー設定
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        beginDateTime = DateTime.ParseExact(beginDate.ToString(), "yyyyMMdd", format);

                                        if ((beginDateTime != DateTime.MinValue) &&
                                           (beginDateTime >= this._minValue && beginDateTime <= this._maxValue) // カレンダーコンポの範囲内
                                            )
                                        {
                                            goods.ShopSaleBeginDate = beginDate;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「公開開始日」の取込に失敗しました。" + " " + "不正な日付です。";
                                            goods.ShopSaleBeginDate = ct_ErrInt;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "行目>" + " " + "「公開開始日」の取込に失敗しました。" + " " + "8桁で入力して下さい。";
                                        goods.ShopSaleBeginDate = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「公開開始日」の取込に失敗しました。" + " " + "不正な値です。";
                                goods.ShopSaleBeginDate = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }

                            // 公開終了日　ゼロを許可する
                            try
                            {
                                if (string.IsNullOrEmpty(fields[SHOPSALEENDDATE]))
                                {
                                    // 未入力の場合は0扱い
                                    goods.ShopSaleEndDate = 0;
                                }
                                else
                                {
                                    int endDate = Convert.ToInt32(fields[SHOPSALEENDDATE]);
                                    if (endDate == 0)
                                    {
                                        // 0はＯＫ
                                        goods.ShopSaleEndDate = endDate;
                                    }
                                    else if (endDate.ToString().Length == 8)
                                    {
                                        DateTime endDateTime = DateTime.MinValue;
                                        // カルチャー設定
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        endDateTime = DateTime.ParseExact(endDate.ToString(), "yyyyMMdd", format);

                                        if ((endDateTime != DateTime.MinValue) &&
                                            (endDateTime >= this._minValue && endDateTime <= this._maxValue) // カレンダーコンポの範囲内
                                           )
                                        {
                                            goods.ShopSaleEndDate = endDate;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「公開終了日」の取込に失敗しました。" + " " + "不正な日付です。";
                                            goods.ShopSaleEndDate = ct_ErrInt;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                    else
                                    {
                                        errMsg = "<" + rowNo + "行目>" + " " + "「公開終了日」の取込に失敗しました。" + " " + "8桁で入力して下さい。";
                                        goods.ShopSaleEndDate = ct_ErrInt;
                                        errMsgList.Add(errMsg);
                                    }
                                }
                            }
                            catch
                            {
                                errMsg = "<" + rowNo + "行目>" + " " + "「公開終了日」の取込に失敗しました。" + " " + "不正な値です。";
                                goods.ShopSaleEndDate = ct_ErrInt;
                                errMsgList.Add(errMsg);
                            }


                            if (this._bootMode == 1)
                            {
                                // 部品商モード

                                // 在庫状態 イレギュラー値の場合は-1
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[STOCKSTATE]))
                                    {
                                        // 未入力の場合は-1扱い 在庫状態をしようしない場合を想定
                                        goods.StockStatusDiv = -1;
                                    }
                                    else
                                    {
                                        short StockStatusDiv = Convert.ToInt16(fields[STOCKSTATE]);
                                        if (StockStatusDiv > 0 && StockStatusDiv <= 3)
                                        {
                                            goods.StockStatusDiv = StockStatusDiv;
                                        }
                                        else
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「在庫状態」の取込に失敗しました。" + " " + "1、2、3の何れかを設定して下さい。";
                                            goods.StockStatusDiv = ct_Errshort;
                                            errMsgList.Add(errMsg);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「在庫状態」の取込に失敗しました。" + " " + "1、2、3の何れかを設定して下さい。";
                                    goods.StockStatusDiv = ct_Errshort;
                                    errMsgList.Add(errMsg);
                                }

                                // 標準価格 MAX9桁 イレギュラー値の場合は0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SUGGEST_PRICE]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.SuggestPrice = 0;
                                    }
                                    else
                                    {
                                        long SuggestPrice = Convert.ToInt64(fields[SUGGEST_PRICE]);
                                        if (SuggestPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「標準価格」の取込に失敗しました。" + " " + "金額がマイナスです。";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「標準価格」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length <= 9 && SuggestPrice >= 0)
                                        {
                                            goods.SuggestPrice = Convert.ToDouble(SuggestPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「標準価格」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.SuggestPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // 店頭価格　MAX9桁 イレギュラー値の場合は0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SHOPP_PRICE]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.ShopPrice = 0;
                                    }
                                    else
                                    {
                                        long ShopPrice = Convert.ToInt64(fields[SHOPP_PRICE]);
                                        if (ShopPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「店頭価格」の取込に失敗しました。" + " " + "金額がマイナスです。";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「店頭価格」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length <= 9 && ShopPrice >= 0)
                                        {
                                            goods.ShopPrice = Convert.ToDouble(ShopPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「店頭価格」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.ShopPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // 売価　MAX9桁 イレギュラー値の場合は0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[TRADE_PRICE_PM]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.TradePrice = 0;
                                    }
                                    else
                                    {
                                        long TradePrice = Convert.ToInt64(fields[TRADE_PRICE_PM]);
                                        if (TradePrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「売価」の取込に失敗しました。" + " " + "金額がマイナスです。";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「売価」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length < 9 && TradePrice >= 0)
                                        {
                                            goods.TradePrice = Convert.ToDouble(TradePrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「売価」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.TradePrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // 仕入原価　MAX9桁 イレギュラー値の場合は0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[PURCHASE_COST]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.PurchaseCost = 0;
                                    }
                                    else
                                    {
                                        long PurchaseCost = Convert.ToInt64(fields[PURCHASE_COST]);
                                        if (PurchaseCost < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「仕入原価」の取込に失敗しました。" + " " + "金額がマイナスです。";
                                            goods.PurchaseCost = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (PurchaseCost.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「仕入原価」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.PurchaseCost = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (PurchaseCost.ToString().Length < 9 && PurchaseCost >= 0)
                                        {
                                            goods.PurchaseCost = Convert.ToDouble(PurchaseCost);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「仕入原価」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.PurchaseCost = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }
                            }
                            else
                            {
                                // 整備工場モード

                                // 標準価格　MAX9桁 イレギュラー値の場合は0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SF_SUGGEST_PRICE]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.SuggestPrice = 0;
                                    }
                                    else
                                    {
                                        long SuggestPrice = Convert.ToInt64(fields[SF_SUGGEST_PRICE]);
                                        if (SuggestPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「標準価格」の取込に失敗しました。" + " " + "金額がマイナスになっています。";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「標準価格」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.SuggestPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (SuggestPrice.ToString().Length <= 9 && SuggestPrice >= 0)
                                        {
                                            goods.SuggestPrice = Convert.ToDouble(SuggestPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「標準価格」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.SuggestPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // 店頭価格　MAX9桁 イレギュラー値の場合は0
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SF_SHOPP_PRICE]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.ShopPrice = 0;
                                    }
                                    else
                                    {
                                        long ShopPrice = Convert.ToInt64(fields[SF_SHOPP_PRICE]);
                                        if (ShopPrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「店頭価格」の取込に失敗しました。" + " " + "金額がマイナスになっています。";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「店頭価格」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.ShopPrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (ShopPrice.ToString().Length <= 9 && ShopPrice >= 0)
                                        {
                                            goods.ShopPrice = Convert.ToDouble(ShopPrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「店頭価格」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.ShopPrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }

                                // 仕入原価　MAX9桁 整備工場モードの場合はTradePriceにセット
                                try
                                {
                                    if (string.IsNullOrEmpty(fields[SF_PURCHASE_COST]))
                                    {
                                        // 未入力の場合は0扱い
                                        goods.TradePrice = 0;
                                    }
                                    else
                                    {
                                        long TradePrice = Convert.ToInt64(fields[SF_PURCHASE_COST]);
                                        if (TradePrice < 0)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「仕入原価」の取込に失敗しました。" + " " + "金額がマイナスになっています。";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length > 9)
                                        {
                                            errMsg = "<" + rowNo + "行目>" + " " + "「仕入原価」の取込に失敗しました。" + " " + "9桁以内で入力して下さい。";
                                            goods.TradePrice = ct_ErrDouble;
                                            errMsgList.Add(errMsg);
                                        }
                                        else if (TradePrice.ToString().Length <= 9 && TradePrice >= 0)
                                        {
                                            goods.TradePrice = Convert.ToDouble(TradePrice);
                                        }
                                    }
                                }
                                catch
                                {
                                    errMsg = "<" + rowNo + "行目>" + " " + "「仕入原価」の取込に失敗しました。" + " " + "不正な値です。";
                                    goods.TradePrice = ct_ErrDouble;
                                    errMsgList.Add(errMsg);
                                }
                            }
                            this._proposeGoodsList.Add(goods);
                        }

                        if (errMsgList.Count > 0)
                        {
                            // ログを出力

                            string logPath = System.IO.Path.GetDirectoryName(path);
                            string logfileName = "ErrLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                            try
                            {
                                using (StreamWriter sw = new StreamWriter(Path.Combine(logPath, logfileName), true, System.Text.Encoding.GetEncoding("shift_jis")))
                                {
                                    foreach (string msg in errMsgList)
                                    {
                                        sw.WriteLine(msg);
                                    }
                                }

                                 TMsgDisp.Show(
                                  this,							            // 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // エラーレベル
                                  CT_ASSEMBLYID,					            // アセンブリIDまたはクラスID
                                  "一部データの取込に失敗しました。" + Environment.NewLine
                                  + "詳細はログファイルを確認して下さい。" + Environment.NewLine
                                  + "【ログファイル】" + Environment.NewLine + Path.Combine(logPath, logfileName),
                                  -1,								        // ステータス値
                                  MessageBoxButtons.OK);
                            }
                            catch
                            {
                                // ログ出力に失敗
                                  TMsgDisp.Show(
                                  this,							            // 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // エラーレベル
                                  CT_ASSEMBLYID,					            // アセンブリIDまたはクラスID
                                  "一部データの取込に失敗しました。" + Environment.NewLine +
                                  "取込結果の確認を行って下さい。",
                                  -1,								        // ステータス値
                                  MessageBoxButtons.OK);
                            }
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(
                     this,							            // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	        // エラーレベル
                     CT_ASSEMBLYID,					            // アセンブリIDまたはクラスID
                     "CSVの読込みに失敗しました。"
                     + Environment.NewLine
                     + ex.StackTrace.ToString(),	            // 表示するメッセージ 
                     -1,								        // ステータス値
                     MessageBoxButtons.OK);
                }
            }
        }
        #endregion
    }
}