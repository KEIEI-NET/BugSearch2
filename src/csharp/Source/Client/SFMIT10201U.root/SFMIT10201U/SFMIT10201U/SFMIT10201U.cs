using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolTip;
using System.Collections;
using Broadleaf.Application.Common;

using System.Reflection;

using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// TBO用品登録画面
    /// </summary>
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : 23010 JIN</br>
    /// <br>Date        : 2016.05.25</br>
    /// </br>
    /// </remarks>
    public partial class SFMIT10201U : Form
    {
        #region const
        /// <summary>
        /// セパレータ
        /// </summary>
        private const string ctSeparator = @"	";

        /// <summary>
        /// テーブル名
        /// </summary>
        private const string TABLE_MAIN = "GOODS_MAIN";      // 共通テーブル
        private const string TABLE_SUB  = "GOODS_CUSTOM";    // 個別設定テーブル

        /// <summary>
        /// フォーマット
        /// </summary>
        private const string CT_MONEYFORMAT = "#,##0;-#,##0;";
        private const string CT_CODEFORMAT = "#0;-#0;''";
        private const string CT_PARCENTFROMAT = "0.0%";

        /// <summary>リードオンリー用背景色</summary>
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        /// <summary>
        ///  整備工場カラムカラー
        /// </summary>
        /// 
        private static readonly Color REPAIR_COLOR1 = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(134)))), ((int)(((byte)(76)))));
        private static readonly Color REPAIR_COLOR2 = Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(104)))), ((int)(((byte)(32)))));
        private static readonly Color PRPAIR_FORE = Color.White;

        /// <summary>
        /// PGID
        /// </summary>
        private const string CT_ASSEMBLYID = "SFMIT10201U";

        ///PM抽出PG情報
        string CT_PM_AssemblyID = "PMKHN09510U.dll";
        string CT_PM_ClassID = "Broadleaf.Windows.Forms.PMKHN09510UA";

        #region Gridカラム定義

        // 共通
        private const string COL_DEL = "論理削除";
        private const string COL_SORTNO = "ソート順";
        private const string COL_RELEASE = "公開";
        private const string COL_RECOMMEND = "オススメ";
        private const string COL_GOODSNO = "品番";
        private const string COL_BLCD = "BLコード";
        private const string COL_BLCDBR = "BLコード枝番";
        private const string COL_IMAGE_NO = "画像No";
        private const string COL_IMAGE = "画像";
        private const string COL_IMAGE_GUIDE = "画像ガイド";
        private const string COL_IMAGE_CHANGE = "画像変更";
        private const string COL_MAKERTITLE = "メーカー";
        private const string COL_MAKERNM = "名称";
        private const string COL_MAKERCD = "コード";
        private const string COL_MAKERGD = "ガイド";
        private const string COL_GOODSNM = "商品名称";
        private const string COL_RELEASEDATE = "発売日";
        private const string COL_SHOPSALEBEGINDATE = "公開開始日";
        private const string COL_SHOPSALEENDDATE = "公開終了日";

        private const string COL_STOCKCOUNT = "在庫数";
        private const string COL_STOCKSTATE = "在庫状態";
        private const string COL_GOODSNOTE = "商品説明";
        private const string COL_GOODSPR = "商品ＰＲ";
        // 整備工場金額カラム (部品商モードの場合のみ表示)
        private const string COL_SF_TITLE = "整備工場";
        private const string COL_SUGGEST_PRICE = "標準価格";
        private const string COL_SHOP_PRICE = "店頭価格";
        private const string COL_GROSS_SF = "粗利";
        private const string COL_GROSSMARGIN_SF = "粗利率";
        // 部品商カラム
        private const string COL_PM_TITLE = "部品商";
        private const string COL_TRADE_PRICE = "売価";
        private const string COL_PURCHASE_COST = "仕入原価";
        private const string COL_GROSS_PM = "粗利PM";
        private const string COL_GROSSMARGIN_PM = "粗利率PM";
        // 個別設定
        private const string COL_INDIVIDUAL = "得意先別設定";
        // 非表示カラム
        private const string COL_PM_UPDATETIME = "在庫更新日"; // hyde

        // カテゴリ別
        // タイヤ
        private const string COL_TIRE_KEY1 = "サイズ";
        private const string COL_TIRE_KEY2 = "スタッドレス";
        // バッテリ
        private const string COL_BATTERY_KEY1 = "規格";
        private const string COL_BATTERY_KEY2 = "適合";
        // オイル
        private const string COL_OIL_KEY1 = "粘度";
        private const string COL_OIL_KEY2 = "適合オイル";
        // 商品情報オブジェクト
        private const string COL_POSTPARACLASS = "POSTパラメータクラス";
        // 付随整備用 
        private const string COL_REPARE = "COL_REPARE";

        // 商品価格合計
        private const string COL_MONEY_TOTAL = "合計";
     
        // 行コピーバッファ
        private List<object> _copyBufferList;

        // 金額入力MSG　　※
        private const string CT_INPMSG_TIRE     = "※下記金額は、１本単位の価格（税抜）となります";
        private const string CT_INPMSG_BATTERY  = "※下記金額は、１個単位の価格（税抜）となります";
        private const string CT_INPMSG_OIL      = "※下記金額は、１Ｌ単位の価格（税抜）となります";

        // CSV取込エラーST
        private const string ct_ErrSt = "-999";
        private const int ct_ErrInt = -999;
        private const short ct_Errshort = -999;
        private const double ct_ErrDouble = -999;


        #endregion

        #endregion

        #region メンバ

        // 起動パラメータ
        private Propose_Para_Main _bootPara;
        // TOBアクセスクラス
        private TBOServiceACS _TBOServiceACS;
        // 付随整備件数</summary>
        private int _repairCount;
        // 付随整備設定
        private Dictionary<long, List<AttendRepairSet>> _attendRepairSetDic;
        // 付随整備カラムディクショナリー
        private Dictionary<long, List<string>> _attendRepairColDic;
        // 拠点別SCM企業拠点連結ディクショナリー</summary>
        private Dictionary<string, List<Propose_Para_SCM>> _scmSceDic;
        // メーカーディクショナリー
        private Dictionary<int, Propose_Para_Maker> _makerCdDic;
        // セル非アクティブ時のセル情報
        private UltraGridCell _tempCell = null;
        // セル非アクティブ時の初期値
        private object _tempValue = null;

        // 商品カテゴリリスト
        private List<GoodsCategory> _categoryList;
        private ImageList _imgList;

        // 画像ガイド
        private GoodsImageForm _imageGuide;

        private DateTime _releaseStDate;

        // 金額計算ガイド
        private CalcPriceForm _calcPriceForm;

        // 動作設定リスト
        private Dictionary<string, Settings> _settingsDic;

        // グリッド色初期化フラグ
        private bool _initFlag = false;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SFMIT10201U()
        {
            InitializeComponent();
            this._TBOServiceACS = new TBOServiceACS();
            this._scmSceDic = new Dictionary<string, List<Propose_Para_SCM>>();
            this._attendRepairSetDic = new Dictionary<long, List<AttendRepairSet>>();
            this._makerCdDic = new Dictionary<int, Propose_Para_Maker>();
            this._attendRepairColDic = new Dictionary<long, List<string>>();
            this._categoryList = new List<GoodsCategory>();
            this._imgList = new ImageList();
            this._imgList.TransparentColor = Color.Cyan;
            this._imgList.Images.Add(Properties.Resources._28_STAR1);
            this._releaseStDate = DateTime.Now;
            this._settingsDic = new Dictionary<string, Settings>();
            this._copyBufferList = new List<object>();
        }
        #endregion

        #region public

        /// <summary>
        /// 外部起動処理
        /// </summary>
        /// <returns></returns>
        public void Show(Propose_Para_Main para)
        {
            this._bootPara = para;

            if (this._bootPara.BootMode == BootMode.PM)
            {
                this.Icon = Properties.Resources.PMICON;

#if DEBUG
                //// テスト用　強制PMモード
                //Propose_Para_SCM scm = new Propose_Para_SCM();
                //scm.CnectOriginalEpCd = "0140150842030050";
                //scm.CnectOriginalEpNm = "50企業";
                //scm.CnectOriginalSecCd = "000001";
                //scm.CnectOriginalSecNm = "本社";
                //scm.CnectOtherEpCd = "0140150842030504";
                //scm.CnectOtherEpNm = "株式会社ブロードリーフ福岡開発部(10.20.70.217)";
                //scm.CnectOtherSecCd = "01";
                //scm.CnectOtherSecNm = "本社";
                //scm.DiscDivCd = 0;

                //Propose_Para_SCM scm2 = new Propose_Para_SCM();
                //scm2.CnectOriginalEpCd = "0140150842030050";
                //scm2.CnectOriginalEpNm = "株式会社ブロードリーフ 本社";
                //scm2.CnectOriginalSecCd = "000001";
                //scm2.CnectOriginalSecNm = "本社";
                ////scm2.CnectOtherEpCd = "0140150842030504";
                //scm2.CnectOtherEpCd = "0101150842021003";
                //scm2.CnectOtherEpNm = "㈱広葉パーツ";
                //scm2.CnectOtherSecCd = "01";
                //scm2.CnectOtherSecNm = "本社";
                //scm2.DiscDivCd = 0;

                Propose_Para_SCM scm3 = new Propose_Para_SCM();
                scm3.CnectOriginalEpCd = "0140150842030035";
                scm3.CnectOriginalEpNm = "ブロードリーフ CarpodTab単体";
                scm3.CnectOriginalSecCd = "000001";
                scm3.CnectOriginalSecNm = "本社";
                scm3.CnectOtherEpCd = "0101150842021003";
                scm3.CnectOtherEpNm = "㈱広葉パーツ";
                scm3.CnectOtherSecCd = "01";
                scm3.CnectOtherSecNm = "本社";
                scm3.DiscDivCd = 0;

                // 部品商モード
                this._bootPara.EnterpriseCode = "0101150842021003";
                this._bootPara.EnterpriseName = "㈱広葉パーツ";
                this._bootPara.EmployeeCode = "1000";
                this._bootPara.EmployeeName = "部品太郎";
                this._bootPara.SectionCode = "01";


                List<Propose_Para_SCM> list = new List<Propose_Para_SCM>();
                //list.Add(scm);
                //list.Add(scm2);
                list.Add(scm3);
                this._bootPara.Propose_Para_SCM = list;

                List<Propose_Para_Section> secList = new List<Propose_Para_Section>();
                Propose_Para_Section section = new Propose_Para_Section();
                section.SectionCode = "01";
                section.SectionGuideNm = "本社";
                section.MainOfficeFuncFlag = 0;
                secList.Add(section);

                Propose_Para_Section section2 = new Propose_Para_Section();
                section2.SectionCode = "02";
                section2.SectionGuideNm = "小戸店";
                section2.MainOfficeFuncFlag = 0;
                secList.Add(section2);

                Propose_Para_Section section3 = new Propose_Para_Section();
                section3.SectionCode = "03";
                section3.SectionGuideNm = "中洲店";
                section3.MainOfficeFuncFlag = 0;
                secList.Add(section3);
                this._bootPara.Propose_Para_Section = secList;
#endif

                #region ランテルさんレビュー用

                //// TODO ランテルさんレビュー用
                //// テスト用　強制PMモード
                ////TODO ダミーで拠点連結を作成
                //Propose_Para_SCM scm = new Propose_Para_SCM();
                //scm.CnectOriginalEpCd = "0140150842030035";
                //scm.CnectOriginalEpNm = "株式会社ビッグモーター";
                //scm.CnectOriginalSecCd = "000001";
                //scm.CnectOriginalSecNm = "春日店";
                //scm.CnectOtherEpCd = "0140150842030504";
                //scm.CnectOtherEpNm = "株式会社ランテル";
                //scm.CnectOtherSecCd = "01";
                //scm.CnectOtherSecNm = "本社";
                //scm.DiscDivCd = 0;

                //// 部品商モード
                //this._bootPara.EnterpriseCode = "0140150842030504";
                //this._bootPara.EnterpriseName = "株式会社ランテル";
                //this._bootPara.EmployeeCode = "1000";
                //this._bootPara.EmployeeName = "部品太郎";
                //this._bootPara.SectionCode = "01";


                //List<Propose_Para_SCM> list = new List<Propose_Para_SCM>();
                //list.Add(scm);
                //this._bootPara.Propose_Para_SCM = list;


                //List<Propose_Para_Section> secList = new List<Propose_Para_Section>();
                //Propose_Para_Section section = new Propose_Para_Section();
                //section.SectionCode = "01";
                //section.SectionGuideNm = "本社";
                //section.MainOfficeFuncFlag = 0;
                //secList.Add(section);

                //Propose_Para_Section section2 = new Propose_Para_Section();
                //section2.SectionCode = "02";
                //section2.SectionGuideNm = "福岡営業所";
                //section2.MainOfficeFuncFlag = 0;
                //secList.Add(section2);

                //Propose_Para_Section section3 = new Propose_Para_Section();
                //section3.SectionCode = "03";
                //section3.SectionGuideNm = "久留米営業所";
                //section3.MainOfficeFuncFlag = 0;
                //secList.Add(section3);
                //this._bootPara.Propose_Para_Section = secList;

                #endregion

            }
            this.Show();
        }

        #endregion

        #region Private

        #region 拠点リスト作成
        /// <summary>
        /// 拠点リスト作成
        /// </summary>
        private void SetSection()
        {
            if (this._bootPara.BootMode == BootMode.SF)
            {
                // 整備工場モードの場合は本社拠点機能を見る 
                Propose_Para_Section target = this._bootPara.Propose_Para_Section.Find(
                    delegate(Propose_Para_Section sec)
                    {
                        if (sec.SectionCode.TrimEnd() == this._bootPara.SectionCode.TrimEnd())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });

                if (target != null)
                {
                    if (target.MainOfficeFuncFlag == 1)
                    {
                        // 本社機能
                        foreach (Propose_Para_Section section in this._bootPara.Propose_Para_Section)
                        {
                            this.Section_ComboEditor.Items.Add(section.SectionCode, section.SectionGuideNm);
                        }
                    }
                    else
                    {
                        // 拠点機能
                        this.Section_ComboEditor.Items.Add(target.SectionCode, target.SectionGuideNm);
                    }

                    // ログイン拠点を初期選択
                    this.Section_ComboEditor.Value = this._bootPara.SectionCode;
                }
            }
            else
            {
                // 部品商モード
                // PMには本社機能区分の概念がなく、ロールで対応しているとのこと
                // 企業拠点連結がある拠点でしか登録は不可

                bool loginExist = false;
                
                foreach (Propose_Para_Section section in this._bootPara.Propose_Para_Section)
                {
                    // 企業拠点連結がある
                    if (this._scmSceDic.ContainsKey(section.SectionCode))
                    {
                        if (section.SectionCode.TrimEnd() == this._bootPara.SectionCode.TrimEnd())
                        {
                            loginExist = true;
                        }
                        this.Section_ComboEditor.Items.Add(section.SectionCode, section.SectionGuideNm);
                    }
                }
                // ログイン拠点に有効なSCM連結設定が存在しない場合があるかもしれないので
                if (loginExist)
                {
                    // ログイン拠点を初期選択
                    this.Section_ComboEditor.Value = this._bootPara.SectionCode;
                }
                else
                {
                    // 企業拠点連結が有効な拠点はあるが、それはログイン拠点ではない
                    // ログイン拠点を初期選択
                    this.Section_ComboEditor.SelectedIndex = 0;

                    TMsgDisp.Show(
                      this,								                        // 親ウィンドウフォーム
                      emErrorLevel.ERR_LEVEL_EXCLAMATION,	                    // エラーレベル
                      CT_ASSEMBLYID,						                    // アセンブリIDまたはクラスID
                      "現在ログイン中の拠点には有効な提案先がありません。",
                      0,								                        // ステータス値
                      MessageBoxButtons.OK);				                    // 表示するボタン

                }
            }
        }
        #endregion

        #region 公開先作成
        /// <summary>
        /// 拠点別公開先リストを作成
        /// </summary>
        private void MakeCustomerList()
        {
            // 部品商モードの場合、企業拠点連結設定より公開先を決める
            if (this._bootPara.Propose_Para_SCM != null && this._bootPara.Propose_Para_SCM.Count > 0)
            {
                // 接続有効チェックは、この時点で企業の接続有効が分からないので、できない。
                // PM側から接続が有効なもののみ頂く。
                // たぶん企業連結：0:有効　AND　拠点連結：0:有効　AND　(通信方式(SCM):1:する　OR 通信方式(PCC-UOE):1する) RCのみ有効とかはダメ？

                foreach (Propose_Para_SCM para in this._bootPara.Propose_Para_SCM)
                {
                    if (this._scmSceDic.ContainsKey(para.CnectOtherSecCd))
                    {
                        this._scmSceDic[para.CnectOtherSecCd].Add(para);
                    }
                    else
                    {
                        List<Propose_Para_SCM> wkList = new List<Propose_Para_SCM>();
                        wkList.Add(para);
                        this._scmSceDic.Add(para.CnectOtherSecCd, wkList);
                    }
                }
            }
            else
            {
                // 外部ファイル確認
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory() ,"TBOConectInfo.xml")))
                {
                    Propose_Para_SCM[] localList = UserSettingController.DeserializeUserSetting<Propose_Para_SCM[]>(Path.Combine(Directory.GetCurrentDirectory() , "TBOConectInfo.xml"));

                    if(localList.Length > 0)
                    {
                        this._bootPara.Propose_Para_SCM = new List<Propose_Para_SCM>();
                        this._bootPara.Propose_Para_SCM.AddRange(localList);

                        // 表示順位でソート
                        this._bootPara.Propose_Para_SCM.Sort(delegate(Propose_Para_SCM obj1, Propose_Para_SCM obj2)
                        {
                            return obj1.DisplayOrder.CompareTo(obj2.DisplayOrder);
                        });

                             foreach (Propose_Para_SCM para in this._bootPara.Propose_Para_SCM)
                        {
                            if (this._scmSceDic.ContainsKey(para.CnectOtherSecCd))
                            {
                                this._scmSceDic[para.CnectOtherSecCd].Add(para);
                            }
                            else
                            {
                                List<Propose_Para_SCM> wkList = new List<Propose_Para_SCM>();
                                wkList.Add(para);
                                this._scmSceDic.Add(para.CnectOtherSecCd, wkList);
                            }
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                        CT_ASSEMBLYID,						    // アセンブリIDまたはクラスID
                        "有効な提案先がありません。" 
                        + Environment.NewLine
                        + "アプリケーションを終了します",		// 表示するメッセージ 
                        -1,								        // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボ
                        this.Close();
                    }
                }
                else
                {
                    TMsgDisp.Show(
                        this,								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                        CT_ASSEMBLYID,						    // アセンブリIDまたはクラスID
                        "有効な提案先がありません。" 
                        + Environment.NewLine
                        + "アプリケーションを終了します",		// 表示するメッセージ 
                        -1,								        // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボ

                    this.Close();
                }
            }
        }

        #endregion

        #region カテゴリリスト作成
        /// <summary>
        /// カテゴリリスト作成
        /// </summary>
        private void SetCategory()
        {
            this._categoryList = new List<GoodsCategory>();
            string errMsg = "";
            int st = this._TBOServiceACS.GetGoodsCategory(out this._categoryList, out errMsg);

            if (st == 0)
            {
                foreach (GoodsCategory category in this._categoryList)
                {
                    this.Category_ComboEditor.Items.Add(category.GoodsCategoryId, category.GoodsCategoryName);
                }

                // 初期選択は考えるがとりあえずタイヤ
                this.Category_ComboEditor.SelectedIndex = 0;
            }
            else
            {
                TMsgDisp.Show(
                     this,								            // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // エラーレベル
                     CT_ASSEMBLYID,						            // アセンブリIDまたはクラスID
                     "商品カテゴリ情報の取得に失敗しました。",		// 表示するメッセージ 
                     st,								            // ステータス値
                     MessageBoxButtons.OK);				            // 表示するボ
            }
        }
        #endregion

        #region 付随整備ディクショナリ作成

        #region 部品商用
        /// <summary>
        /// 付随整備設定を取得
        /// </summary>
        private int SetAttendRepairSet()
        {
            int st = 0;
            List<AttendRepairSet> attendRepairSetList = new List<AttendRepairSet>();
            this._attendRepairSetDic.Clear();
            this._attendRepairColDic.Clear();

            string errMsg = "";

            // 付随整備設定を取得
            st = this._TBOServiceACS.GetAttendRepairSet(this._bootPara.EnterpriseCode, out attendRepairSetList, out errMsg);

            if (st == 0)
            {
                foreach (AttendRepairSet attendRepairSet in attendRepairSetList)
                {
                    // カテゴリ別
                    if (this._attendRepairSetDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        this._attendRepairSetDic[attendRepairSet.goodsCategoryId].Add(attendRepairSet);
                    }
                    else
                    {
                        List<AttendRepairSet> wkList = new List<AttendRepairSet>();
                        wkList.Add(attendRepairSet);
                        this._attendRepairSetDic.Add(attendRepairSet.goodsCategoryId, wkList);
                    }

                    // カテゴリ別列名リスト(部品商モードの場合は COL_REPARE)
                    string colNm = MakeAttenRepairKey(attendRepairSet.attendRepairId.ToString());

                    if (this._attendRepairColDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        this._attendRepairColDic[attendRepairSet.goodsCategoryId].Add(colNm);
                    }
                    else
                    {
                        List<string> colList = new List<string>();
                        colList.Add(colNm);
                        this._attendRepairColDic.Add(attendRepairSet.goodsCategoryId, colList);
                    }

                }
            }
            else
            {
                TMsgDisp.Show(
                     this,								            // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // エラーレベル
                     CT_ASSEMBLYID,						            // アセンブリIDまたはクラスID
                     "付随整備設定情報の取得に失敗しました。",		// 表示するメッセージ 
                     st,								            // ステータス値
                     MessageBoxButtons.OK);				            // 表示するボ
            }
            return st;
        }

        /// <summary>
        /// 付随整備カラムのキーを作成
        /// </summary>
        /// <param name="p"></param>
        private string MakeAttenRepairKey(string repairId)
        {
            return COL_REPARE + repairId;
        }

        #endregion

        #region 整備工場用
        /// <summary>
        /// 付随整備設定を取得
        /// </summary>
        private int SetAttendRepairSet_ModeSF(out string errMsg)
        {
            int st = 0;
            errMsg = "";
            List<AttendRepairSet> attendRepairSetList = new List<AttendRepairSet>();
            this._attendRepairSetDic.Clear();
            this._attendRepairColDic.Clear();

            // 付随整備設定を取得
            st = this._TBOServiceACS.GetAttendRepairSetSF(this._bootPara.EnterpriseCode, this.Section_ComboEditor.Value.ToString(), (long)this.Category_ComboEditor.Value, out attendRepairSetList, out errMsg);
           
            if (st == 0)
            {
                foreach (AttendRepairSet attendRepairSet in attendRepairSetList)
                {
                    // カテゴリ別
                    if (this._attendRepairSetDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        this._attendRepairSetDic[attendRepairSet.goodsCategoryId].Add(attendRepairSet);
                    }
                    else
                    {
                        List<AttendRepairSet> wkList = new List<AttendRepairSet>();
                        wkList.Add(attendRepairSet);
                        this._attendRepairSetDic.Add(attendRepairSet.goodsCategoryId, wkList);
                    }

                    // カテゴリ別列名リスト 整備工場モードの場合はCOL_REPARE + storeAttendRepairId
                    string colNm = MakeAttenRepairKey(attendRepairSet.storeAttendRepairId.ToString());

                    if (this._attendRepairColDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        if (!this._attendRepairColDic[attendRepairSet.goodsCategoryId].Contains(colNm))
                        {
                            this._attendRepairColDic[attendRepairSet.goodsCategoryId].Add(colNm);
                        }
                    }
                    else
                    {
                        List<string> colList = new List<string>();
                        colList.Add(colNm);
                        this._attendRepairColDic.Add(attendRepairSet.goodsCategoryId, colList);
                    }
                }
            }
            return st;
        }
        #endregion


        #endregion

        #region メーカーリスト作成
        /// <summary>
        /// メーカーリスト作成
        /// </summary>
        private void MakeMakerDic()
        {
            // 表示順位でソート
            this._bootPara.Propose_Para_Maker.Sort(delegate(Propose_Para_Maker obj1, Propose_Para_Maker obj2)
            {
                return obj1.DisplayOrder.CompareTo(obj2.DisplayOrder);
            });
            foreach (Propose_Para_Maker maker in this._bootPara.Propose_Para_Maker)
            {
                // メーカーコードディクショナリ
                if (!this._makerCdDic.ContainsKey(maker.GoodsMakerCd))
                {
                    this._makerCdDic.Add(maker.GoodsMakerCd, maker);
                }
            }
        }
        #endregion

        #region データテーブル作成
        /// <summary>
        /// データテーブル作成
        /// </summary>
        private void MakeDataSet()
        {
            // 商品テーブル(共通)
            DataTable tboTable = new DataTable(TABLE_MAIN);

            tboTable.Columns.Add(COL_DEL, typeof(Int32));            // 削除区分   
            tboTable.Columns.Add(COL_SORTNO, typeof(Int32));        // ソート順
            tboTable.Columns.Add(COL_RELEASE, typeof(bool));        // 公開      
            tboTable.Columns.Add(COL_RECOMMEND, typeof(bool));      // オススメ
            tboTable.Columns.Add(COL_GOODSNO, typeof(string));      // 品番  

            tboTable.Columns.Add(COL_BLCD, typeof(Int32));          // BLコード  
            tboTable.Columns.Add(COL_BLCDBR, typeof(Int32));        // BLコード枝番

            tboTable.Columns.Add(COL_MAKERTITLE, typeof(string));   // メーカータイトル  
            tboTable.Columns.Add(COL_MAKERCD, typeof(Int32));       // 部品メーカーCD
            tboTable.Columns.Add(COL_MAKERGD, typeof(string));      // 部品メーカーガイド 
            tboTable.Columns.Add(COL_MAKERNM, typeof(string));      // 部品メーカー名称

            // カテゴリ毎のキー
            // タイヤ
            tboTable.Columns.Add(COL_TIRE_KEY1, typeof(string));    // サイズ
            tboTable.Columns.Add(COL_TIRE_KEY2, typeof(bool));      // スタッドレス
            // バッテリ
            tboTable.Columns.Add(COL_BATTERY_KEY1, typeof(string)); // 規格
            tboTable.Columns.Add(COL_BATTERY_KEY2, typeof(Int32)); // 適合(1:通常,2:ISS,3:兼用)
            // オイル
            tboTable.Columns.Add(COL_OIL_KEY1, typeof(string));     // 粘度
            tboTable.Columns.Add(COL_OIL_KEY2, typeof(Int32));     // 適合(1:ガソリン、2:ディーゼル、3：兼用)

            tboTable.Columns.Add(COL_IMAGE_NO, typeof(long));      // 画像№
            tboTable.Columns.Add(COL_IMAGE, typeof(Image));         // 画像
            tboTable.Columns.Add(COL_IMAGE_GUIDE, typeof(string));  // 画像ガイド
            tboTable.Columns.Add(COL_IMAGE_CHANGE, typeof(int));    // 画像変更区分
            
            
            tboTable.Columns.Add(COL_GOODSNM, typeof(string));      // 商品名称
            tboTable.Columns.Add(COL_GOODSNOTE, typeof(string));    // 商品説明
            tboTable.Columns.Add(COL_GOODSPR, typeof(string));      // 商品PR

            tboTable.Columns.Add(COL_RELEASEDATE, typeof(DateTime));    // 発売日

            tboTable.Columns.Add(COL_STOCKCOUNT, typeof(Double));      // 在庫数
            tboTable.Columns.Add(COL_STOCKSTATE, typeof(Int32));       // 在庫状態

            tboTable.Columns.Add(COL_SHOPSALEBEGINDATE, typeof(DateTime));  // 公開開始日
            tboTable.Columns.Add(COL_SHOPSALEENDDATE, typeof(DateTime));    // 公開終了日

            // 整備工場カラム
            tboTable.Columns.Add(COL_SF_TITLE, typeof(string));      // タイトルSF
            tboTable.Columns.Add(COL_SUGGEST_PRICE, typeof(long));   // 希望小売価格
            tboTable.Columns.Add(COL_SHOP_PRICE, typeof(long));     // 店頭価格 

            // 件数を保持
            this._repairCount = 0;


            // 付随整備
            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                List<AttendRepairSet> setList = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                for (int i = 0; i < setList.Count; i++)
                {
                    string key = "";
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        // 部品商モード⇒付随整備IDをキーとする
                        key = MakeAttenRepairKey(setList[i].attendRepairId.ToString());
                    }
                    else
                    {
                        // 整備工場モード⇒店舗付随整備IDをキーとする
                        key = MakeAttenRepairKey(setList[i].storeAttendRepairId.ToString());
                    }

                    if (!tboTable.Columns.Contains(key))
                    {
                        tboTable.Columns.Add(key, typeof(long));  // 付随整備ix
                        tboTable.Columns[key].DefaultValue = setList[i].repairPrice;  // 初期値
                    }
                    this._repairCount++;
                }
            }

            // 合計列
            tboTable.Columns.Add(COL_MONEY_TOTAL, typeof(long));      // 金額

            tboTable.Columns.Add(COL_GROSS_SF, typeof(long));           // 粗利(整備工場)   
            tboTable.Columns.Add(COL_GROSSMARGIN_SF, typeof(string));   // 粗利率(整備工場) 

            // 部品商カラム
            tboTable.Columns.Add(COL_PM_TITLE, typeof(string));         // タイトルPM
            tboTable.Columns.Add(COL_TRADE_PRICE, typeof(long));        // 卸値（整備工場の仕入原価）
            tboTable.Columns.Add(COL_PURCHASE_COST, typeof(long));      // 仕入原価(部品商の仕入原価) PMはdoubleやけど、四捨五入する
            tboTable.Columns.Add(COL_GROSS_PM, typeof(long));           // 粗利(部品商)  
            tboTable.Columns.Add(COL_GROSSMARGIN_PM, typeof(string));   // 粗利率(部品商)  
            tboTable.Columns.Add(COL_INDIVIDUAL, typeof(string));       // 個別設定
            tboTable.Columns.Add(COL_PM_UPDATETIME, typeof(long));      // PM在庫更新日
            tboTable.Columns.Add(COL_POSTPARACLASS, typeof(object));    // 商品情報POSTパラメータクラス

            // 初期値
            tboTable.Columns[COL_DEL].DefaultValue = 0;
            tboTable.Columns[COL_RELEASE].DefaultValue = true;
            tboTable.Columns[COL_RECOMMEND].DefaultValue = false;
            tboTable.Columns[COL_GOODSNO].DefaultValue = "";

            tboTable.Columns[COL_BLCD].DefaultValue = 0;
            tboTable.Columns[COL_BLCDBR].DefaultValue = 0;

            tboTable.Columns[COL_MAKERCD].DefaultValue = 0;
            tboTable.Columns[COL_MAKERNM].DefaultValue = "";
            tboTable.Columns[COL_GOODSNM].DefaultValue = "";
            tboTable.Columns[COL_GOODSNOTE].DefaultValue = "";
            tboTable.Columns[COL_GOODSPR].DefaultValue = "";
            tboTable.Columns[COL_TIRE_KEY1].DefaultValue = "";
            tboTable.Columns[COL_TIRE_KEY2].DefaultValue = false;
            tboTable.Columns[COL_BATTERY_KEY1].DefaultValue = "";
            tboTable.Columns[COL_BATTERY_KEY2].DefaultValue = 1;
            tboTable.Columns[COL_OIL_KEY1].DefaultValue = "";
            tboTable.Columns[COL_OIL_KEY2].DefaultValue = 1;
            tboTable.Columns[COL_IMAGE_NO].DefaultValue = 0;
            tboTable.Columns[COL_IMAGE_CHANGE].DefaultValue = 0;
            tboTable.Columns[COL_STOCKCOUNT].DefaultValue = 0;
            tboTable.Columns[COL_STOCKSTATE].DefaultValue = -1;
            tboTable.Columns[COL_SUGGEST_PRICE].DefaultValue = 0;
            tboTable.Columns[COL_MONEY_TOTAL].DefaultValue = 0;
            tboTable.Columns[COL_SHOP_PRICE].DefaultValue = 0;
            tboTable.Columns[COL_GROSS_SF].DefaultValue = 0;
            tboTable.Columns[COL_GROSSMARGIN_SF].DefaultValue = "";
            tboTable.Columns[COL_TRADE_PRICE].DefaultValue = 0;
            tboTable.Columns[COL_PURCHASE_COST].DefaultValue = 0;
            tboTable.Columns[COL_GROSS_PM].DefaultValue = 0;
            tboTable.Columns[COL_GROSSMARGIN_PM].DefaultValue = "";
            tboTable.Columns[COL_SHOPSALEBEGINDATE].DefaultValue = this._releaseStDate; // 公開開始日


            this.TBODataSet.Tables.Add(tboTable);
        }
        #endregion

        #region テーブルデータセット処理
        /// <summary>
        /// データテーブルセット処理
        /// </summary>
        /// <param name="retList"></param>
        private void SetDataTable(List<ProposeGoods> retList)
        {
            // テーブルを初期化
            if (this.TBODataSet.Tables.Contains(TABLE_MAIN))
            {
                this.TBODataSet.Tables.Remove(TABLE_MAIN);
            }

            // テーブル作成
            this.MakeDataSet();

            // データをセット
            foreach (ProposeGoods proposeGoods in retList)
            {
                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();

                // 画像
                row[COL_IMAGE_NO] = proposeGoods.imageId;
                row[COL_IMAGE] = proposeGoods.image_Data;
                row[COL_DEL] = proposeGoods.logicalDelDiv;          // 論理削除区分
                row[COL_SORTNO] = proposeGoods.sortNo;              // ソート順
                row[COL_RELEASE] = proposeGoods.releaseFlag;        // 公開フラグ
                row[COL_RECOMMEND] = proposeGoods.recommendFlag;    // オススメフラグ

                // タグ
                if (proposeGoods.goodsTagList != null)
                {
                    switch (proposeGoods.goodsCategoryId)
                    {
                        case 1: // タイヤ          
                            for (int i = 0; i < proposeGoods.goodsTagList.Length; i++)
                            {
                                if (proposeGoods.goodsTagList[i].tagNo == 1)
                                {
                                    row[COL_TIRE_KEY1] = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 2)
                                {
                                    row[COL_TIRE_KEY2] = proposeGoods.goodsTagList[i].tag.Equals("0") ? false : true;
                                }
                            }
                            break;
                        case 2: // バッテリ
                            string bTag2 = "";
                            string bTag3 = "";
                            for (int i = 0; i < proposeGoods.goodsTagList.Length; i++)
                            {
                                if (proposeGoods.goodsTagList[i].tagNo == 1)
                                {
                                    row[COL_BATTERY_KEY1] = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 2)
                                {
                                    bTag2 = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 3)
                                {
                                    bTag3 = proposeGoods.goodsTagList[i].tag;
                                }
                            }
                            if (bTag2 == "0")
                            {
                                if (bTag3 == "1")
                                {
                                    // ISS車専用
                                    row[COL_BATTERY_KEY2] = 2;
                                }
                                else
                                {
                                    // ありえない→標準車専用とする
                                    row[COL_BATTERY_KEY2] = 1;
                                }
                            }
                            else
                            {
                                if (bTag3 == "1")
                                {
                                    // 兼用
                                    row[COL_BATTERY_KEY2] = 3;
                                }
                                else
                                {
                                    // 標準車専用
                                    row[COL_BATTERY_KEY2] = 1;
                                }
                            }
                            break;
                        case 3: // オイル
                            string oTag2 = "";
                            string oTag3 = "";
                            for (int i = 0; i < proposeGoods.goodsTagList.Length; i++)
                            {
                                if (proposeGoods.goodsTagList[i].tagNo == 1)
                                {
                                    row[COL_OIL_KEY1] = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 2)
                                {
                                    oTag2 = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 3)
                                {
                                    oTag3 = proposeGoods.goodsTagList[i].tag;
                                }
                            }
                            if (oTag2 == "0")
                            {
                                if (oTag3 == "1")
                                {
                                    // ディーゼル車専用
                                    row[COL_OIL_KEY2] = 2;
                                }
                                else
                                {
                                    // ありえない→ガソリン車専用をセット
                                    row[COL_OIL_KEY2] = 1;
                                }
                            }
                            else
                            {
                                if (oTag3 == "1")
                                {
                                    // 兼用
                                    row[COL_OIL_KEY2] = 3;
                                }
                                else
                                {
                                    // ガソリン車専用
                                    row[COL_OIL_KEY2] = 1;
                                }
                            }
                            break;
                    }
                }

                row[COL_GOODSNOTE] = proposeGoods.goodsNote;        // 商品説明
                row[COL_GOODSPR] = proposeGoods.goodsPr;            // 商品PR
                row[COL_MAKERCD] = proposeGoods.pmMakerCode;        // 品番
                row[COL_MAKERNM] = proposeGoods.makerName;          // メーカー名称
                row[COL_GOODSNO] = proposeGoods.partsNumber;        // 品番
                row[COL_GOODSNM] = proposeGoods.proposeGoodsName;   // 商品名称
                row[COL_PM_UPDATETIME] = proposeGoods.pmUpdDtTime;  // PM在庫更新日時

                if (!String.IsNullOrEmpty(proposeGoods.releaseDate))
                {
                    try
                    {
                        row[COL_RELEASEDATE] = DateTime.Parse(proposeGoods.releaseDate); // 発売日

                    }
                    catch
                    {

                    }
                }

                // 公開開始日
                if (!String.IsNullOrEmpty(proposeGoods.shopSaleBeginDate))
                {
                    try
                    {
                        row[COL_SHOPSALEBEGINDATE] = DateTime.Parse(proposeGoods.shopSaleBeginDate); // 発売日

                    }
                    catch
                    {

                    }
                }

                // 公開終了日
                if (!String.IsNullOrEmpty(proposeGoods.shopSaleEndDate))
                {
                    try
                    {
                        row[COL_SHOPSALEENDDATE] = DateTime.Parse(proposeGoods.shopSaleEndDate); // 発売日

                    }
                    catch
                    {

                    }
                }


                row[COL_SUGGEST_PRICE] = proposeGoods.suggestPrice; // 標準価格
                row[COL_SHOP_PRICE] = proposeGoods.shopPrice;      // 店頭価格
                row[COL_TRADE_PRICE] = proposeGoods.tradePrice;     // 卸値
                row[COL_PURCHASE_COST] = proposeGoods.purchaseCost; // 仕入原価
                row[COL_STOCKSTATE] = proposeGoods.stockState;      // 在庫状態
                row[COL_POSTPARACLASS] = proposeGoods;              // 商品情報

                // 付随整備
                // 登録したデータ(proposeGoods.attendRepairList)の元データ付随整備設定、店舗付随整備設定が消されてると、こまるので、最新の設定にあるもののみ表示する
                
                // 最新のマスタ設定を元にデータを復元
                if (this._attendRepairSetDic.Count > 0)
                {
                    if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
                    {
                        Dictionary<long, long> monyDic = new Dictionary<long, long>();
                        if (proposeGoods.attendRepairList != null && proposeGoods.attendRepairList.Length > 0)
                        {
                            for (int i = 0; i < proposeGoods.attendRepairList.Length; i++)
                            {
                                // 部品商モード：proposeGoods.attendRepairIdに付随整備設定のattendRepairIdがセットされてる
                                // 整備工場モード：proposeGoods.attendRepairIdに店舗付随整備設定のstoreAttendRepairIdがセットされてる
                                if (!monyDic.ContainsKey(proposeGoods.attendRepairList[i].attendRepairId))
                                {
                                    // 既に登録済みの付随整備金額を格納
                                    monyDic.Add(proposeGoods.attendRepairList[i].attendRepairId, proposeGoods.attendRepairList[i].repairPrice);
                                }
                            }
                        }

                        List<AttendRepairSet> list = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                        for (int i = 0; i < list.Count; i++)
                        {
                            // データ上の付随整備IDが設定にあるかチェック、設定にある場合は金額をセット
                            // 大元の付随整備設定データが生きているか確認
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                if (monyDic.ContainsKey(list[i].attendRepairId))
                                {
                                    row[MakeAttenRepairKey(list[i].attendRepairId.ToString())] = monyDic[list[i].attendRepairId];
                                }
                            }
                            else
                            {
                                if (monyDic.ContainsKey(list[i].storeAttendRepairId))
                                {
                                    row[MakeAttenRepairKey(list[i].storeAttendRepairId.ToString())] = monyDic[list[i].storeAttendRepairId];
                                }
                            }
                        }
                    }
                }

                // 粗利を計算

                // 付随整備列有無
                bool existRepair = false;

                // 付随整備金額
                long repareTotal = 0;
                foreach (DataColumn col in this.TBODataSet.Tables[TABLE_MAIN].Columns)
                {
                    if (col.ColumnName.Contains(COL_REPARE))
                    {
                        existRepair = true;
                        repareTotal += (long)row[col.ColumnName];
                    }
                }

                // 付随整備列有り
                if (existRepair)
                {
                    row[COL_MONEY_TOTAL] = proposeGoods.shopPrice + repareTotal;
                }

                // 整備工場の粗利を再計算
                long grossSF = 0;
                string grossMarginSF = "";
                this.CalcGrossSF(proposeGoods.shopPrice, repareTotal, proposeGoods.tradePrice, out grossSF, out grossMarginSF);
                // 計算結果を展開
                row[COL_GROSS_SF] = grossSF;
                row[COL_GROSSMARGIN_SF] = grossMarginSF;

                // 部品商モード
                if (this._bootPara.BootMode == BootMode.PM)
                {
                    // 部品商の粗利を再計算
                    long grossPM = 0;
                    long cost = (long)proposeGoods.purchaseCost;
                    string grossMarginPM = "";
                    this.CalcGrossPM(proposeGoods.tradePrice, cost, out grossPM, out grossMarginPM);
                    // 計算結果を展開
                    row[COL_GROSS_PM] = grossPM;
                    row[COL_GROSSMARGIN_PM] = grossMarginPM;
                }
                this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(row);
            }

            this.Goods_Grid.DataSource = this.TBODataSet.Tables[TABLE_MAIN];

            this.UpDateGrid();
        }
        #endregion

        #region オススメ
        /// <summary>
        /// オススメ設定
        /// </summary>
        /// <param name="count">オススメ件数</param>
        /// <param name="target">1:部品商,2:整備工場</param>
        private void SetRecommend(int count, int target)
        {
            // データが0件の場合はスルー
            if (this.Goods_Grid.Rows.Count > 0)
            {
                // まず全てのオススメを外す
                foreach (DataRow row in this.TBODataSet.Tables[TABLE_MAIN].Rows)
                {
                    // 削除分は対象外
                    if (GetCellInt32(row[COL_DEL], 0) == 1)
                    {
                        continue;
                    }
                    row[COL_RECOMMEND] = false;
                }

                string GROSSCOL = COL_GROSS_SF;

                if (this._bootPara.BootMode == BootMode.PM && target == 1)
                {
                    // 部品商モードで部品商の粗利が高いもの
                    GROSSCOL = COL_GROSS_PM;
                }

                string TARGETCOL = "";
                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1:
                        TARGETCOL = COL_TIRE_KEY1;
                        break;
                    case 2:
                        TARGETCOL = COL_BATTERY_KEY1;
                        break;
                    case 3:
                        TARGETCOL = COL_OIL_KEY1;
                        break;
                }

                // 商品タグ１で擬似GROUPBYを行う
                DataView wkView = new DataView(this.TBODataSet.Tables[TABLE_MAIN]);
                DataTable wkTable = wkView.ToTable(true, new string[] { TARGETCOL });

                foreach (DataRow wkRow in wkTable.Rows)
                {
                    StringBuilder cndString = new StringBuilder();
                    string val = wkRow[TARGETCOL].ToString();
                    cndString.Append(String.Format("{0}={1} AND {2}='{3}'", COL_DEL, 0, TARGETCOL, val));
                    string sort = GROSSCOL + " DESC";
                    try
                    {
                        DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString(), sort);
                        if (rows != null)
                        {
                            for (int i = 0; i < rows.Length; i++)
                            {
                                if (i == count) break;
                                rows[i][COL_RECOMMEND] = true;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        #endregion

        #region Enable制御

        /// <summary>
        /// ボタン制御
        /// </summary>
        /// <param name="enabled"></param>
        private void SetSpButtonEnabled(bool enabled)
        {
            this.AddRow_button.Enabled = enabled;
            this.Recommend_button.Enabled = enabled;
            this.CalcPrice_Button.Enabled = enabled;
        }

        /// <summary>
        /// 行削除ボタンEnabled設定処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void SetRowDelEnabled()
        {
            if (this.Goods_Grid.Selected.Rows.Count > 0)
            {
                this.Del_button.Enabled = true;
            }
            else
            {
                this.Del_button.Enabled = false;
            }
        }
        #endregion

        #region チェック処理

        #region 入力チェック

        /// <summary>
        /// ワーニングチェック
        /// </summary>
        /// <returns></returns>
        private bool DataWarningCheck()
        {
            // 必須ではないけど、入力しないとまずいだろうというものをチェック

            bool ret = true;
            string errMsg = "";
            string columnNm = "";
            int rowIndex = 0;
            // グリッド入力チェック
            if (!GridWarningCheck(out errMsg, out columnNm, out rowIndex))
            {
                // メッセージを表示
                DialogResult rlt = TMsgDisp.Show(
                   this,							        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                   CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                   errMsg, 	                                // 表示するメッセージ 
                   0,								        // ステータス値
                   MessageBoxButtons.OKCancel);

                if (rlt == DialogResult.Cancel)
                {
                    ret = false;
                    this.Goods_Grid.ActiveCell = this.Goods_Grid.Rows[rowIndex].Cells[columnNm];
                    this.Goods_Grid.ActiveCell.Activate();
                    this.Goods_Grid.ActiveCell.Selected = true;
                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    this.Goods_Grid.DisplayLayout.ColScrollRegions[0].ScrollCellIntoView(this.Goods_Grid.ActiveCell, this.Goods_Grid.DisplayLayout.RowScrollRegions[0]);
                   
                }
            }
            return ret;

        }

        /// <summary>
        /// ワーニングチェック
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="columnNm"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private bool GridWarningCheck(out string errMsg, out string columnNm, out int rowIndex)
        {
            bool result = true;
            errMsg = "";
            columnNm = "";
            rowIndex = 0;
            //グリッドのアップデート
            this.UpDateGrid();

            errMsg = "以下の商品が存在します。" + Environment.NewLine + "このまま登録してもよろしいですか？";

            bool noInputFlag = false;
            bool minusFlag = false;
            int rowIndexNoinput = -1;
            int rowIndexMinus = -1;
            string ColNmNoinput = "";
            string ColNmMinus = "";

            for (int ix = 0; ix < this.Goods_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.Goods_Grid.Rows[ix];

                if (noInputFlag == false)
                {
                    // 標準価格
                    if (GetCellLong(ugRow.Cells[COL_SUGGEST_PRICE].Value, 0) == 0)
                    {
                        rowIndexNoinput = ix;
                        ColNmNoinput = COL_SUGGEST_PRICE;
                        noInputFlag = true;
                    }
                }

                if (noInputFlag == false)
                {
                    // 店頭価格
                    if (GetCellLong(ugRow.Cells[COL_SHOP_PRICE].Value, 0) == 0)
                    {
                        rowIndexNoinput = ix;
                        ColNmNoinput = COL_SHOP_PRICE;
                        noInputFlag = true;
                    }
                }

                if (noInputFlag == false)
                {
                    // 付随整備
                    if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
                    {
                        List<AttendRepairSet> setList = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                        for (int i = 0; i < setList.Count; i++)
                        {
                            string key = "";
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                key = this.MakeAttenRepairKey(setList[i].attendRepairId.ToString());
                            }
                            else
                            {
                                key = this.MakeAttenRepairKey(setList[i].storeAttendRepairId.ToString());
                            }

                            if (this.Goods_Grid.DisplayLayout.Bands[0].Columns.Exists(key))
                            {
                                if (GetCellLong(ugRow.Cells[key].Value, 0) == 0)
                                {
                                    rowIndexNoinput = ix;
                                    ColNmNoinput = key;
                                    noInputFlag = true;
                                }
                            }
                        }
                    }
                }

                if (noInputFlag == false)
                {
                    // 販売価格
                    if (GetCellLong(ugRow.Cells[COL_TRADE_PRICE].Value, 0) == 0)
                    {
                        rowIndexNoinput = ix;
                        ColNmNoinput = COL_TRADE_PRICE;
                        noInputFlag = true;
                    }
                }

                if (noInputFlag == false)
                {
                    // 部品商モードの場合
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        // 仕入原価
                        if (GetCellLong(ugRow.Cells[COL_PURCHASE_COST].Value, 0) == 0)
                        {
                            rowIndexNoinput = ix;
                            ColNmNoinput = COL_PURCHASE_COST;
                            noInputFlag = true;
                        }
                    }
                }

                if (!minusFlag)
                {
                    // 粗利(整備工場)
                    if (GetCellLong(ugRow.Cells[COL_GROSS_SF].Value, 0) <= 0)
                    {
                        rowIndexMinus = ix;
                        ColNmMinus = COL_GROSS_SF;
                        minusFlag = true;
                    }
                }

                if (!minusFlag)
                {
                    // 部品商モードの場合
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        if (GetCellLong(ugRow.Cells[COL_GROSS_PM].Value, 0) <= 0)
                        {
                            rowIndexMinus = ix;
                            ColNmMinus = COL_GROSS_PM;
                            minusFlag = true;
                        }
                    }
                }

                if (noInputFlag && minusFlag)
                {
                    break;
                }
            }

            if (noInputFlag || minusFlag)
            {
                if (noInputFlag)
                {
                    errMsg += Environment.NewLine + "・金額が未入力";
                }

                if (minusFlag)
                {
                    errMsg += Environment.NewLine + "・粗利が0円以下";
                }

                if (rowIndexNoinput == -1)
                {
                    rowIndex = rowIndexMinus;
                    columnNm = ColNmMinus;
                }
                else if (rowIndexMinus == -1)
                {
                    rowIndex = rowIndexNoinput;
                    columnNm = ColNmNoinput;
                }
                else if (rowIndexNoinput > rowIndexMinus)
                {
                    rowIndex = rowIndexMinus;
                    columnNm = ColNmMinus;
                }
                else
                {
                    rowIndex = rowIndexNoinput;
                    columnNm = ColNmNoinput;
                }
                return false;
            }
            return result;
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <returns></returns>
        private bool DataInputCheck()
        {
            bool ret = true;
            string errMsg = "";
            string columnNm = "";
            int rowIndex = 0;
            // グリッド入力チェック
            if (!GridInputCheck(out errMsg, out columnNm, out rowIndex))
            {
                // メッセージを表示
                TMsgDisp.Show(
                   this,							        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                   CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                   errMsg,	                                // 表示するメッセージ 
                   0,								        // ステータス値
                   MessageBoxButtons.OK);

                this.Goods_Grid.ActiveCell = this.Goods_Grid.Rows[rowIndex].Cells[columnNm];
                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                ret = false;
            }
            return ret;

        }

        /// <summary>
        /// グリッド入力チェック
        /// </summary>
        /// <param name="mess"></param>
        /// <param name="columnNm"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private bool GridInputCheck(out string errMsg, out string columnNm, out int rowIndex)
        {
            bool result = true;
            errMsg = "";
            columnNm = "";
            rowIndex = 0;
            //グリッドのアップデート
            this.UpDateGrid();

            // 入力チェック
            for (int ix = 0; ix < this.Goods_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.Goods_Grid.Rows[ix];

                // 未入力チェック  品番
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_GOODSNO].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "品番を入力して下さい。";
                    columnNm = COL_GOODSNO;
                    return false;
                }

                // 未入力チェック メーカー 
                // SFの場合提供のメーカーしか選択できないので、メーカー名称の手入力を可能とする
                // よってメーカー名称にてチェックする
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_MAKERNM].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "メーカーを入力して下さい。";
                    columnNm = COL_MAKERNM;
                    return false;
                }

                // 未入力チェック 商品
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_GOODSNM].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "商品名称を入力して下さい。";
                    columnNm = COL_GOODSNM;
                    return false;
                }

                // 商品公開日
                if (ugRow.Cells[COL_SHOPSALEBEGINDATE].Value == DBNull.Value)
                {
                    rowIndex = ix;
                    errMsg = "公開開始日を入力して下さい。";
                    columnNm = COL_SHOPSALEBEGINDATE;
                    return false;
                }

                // 商品公開日 > 商品終了日チェック
                if (ugRow.Cells[COL_SHOPSALEBEGINDATE].Value != DBNull.Value && ugRow.Cells[COL_SHOPSALEENDDATE].Value != DBNull.Value)
                {
                    if(((DateTime)ugRow.Cells[COL_SHOPSALEBEGINDATE].Value) > (((DateTime)ugRow.Cells[COL_SHOPSALEENDDATE].Value)))
                    {
                        rowIndex = ix;
                        errMsg = "公開開始日が公開終了日より未来の日付になっています。";
                        columnNm = COL_SHOPSALEBEGINDATE;
                        return false;
                    }
                }
            }

            // 重複チェック
            string mkNm = "";
            string goodsNo = "";
            Dictionary<string, int> overlapDic = new Dictionary<string, int>();
            for (int ix = 0; ix < this.Goods_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.Goods_Grid.Rows[ix];

                mkNm = GetCellString(ugRow.Cells[COL_MAKERNM].Value, "");
                goodsNo = GetCellString(ugRow.Cells[COL_GOODSNO].Value, "");
                string key = mkNm + ctSeparator + goodsNo;
                if (overlapDic.ContainsKey(key))
                {
                    // 重複
                    int befIndex = overlapDic[key];
                    if (this.Goods_Grid.Rows[befIndex].Cells[COL_GOODSNO].Activation == Activation.NoEdit)
                    {
                        rowIndex = ix;
                        errMsg = "品番が重複しています。" + Environment.NewLine + "品番：" + goodsNo;
                        columnNm = COL_GOODSNO;
                        return false;
                    }
                    else
                    {
                        rowIndex = befIndex;
                        errMsg = "品番が重複しています。" + Environment.NewLine + "品番：" + goodsNo;
                        columnNm = COL_GOODSNO;
                        return false;
                    }
                }
                else
                {
                    overlapDic.Add(key, ix);
                }
            }
            return result;
        }
        #endregion

        #region データ変更チェック

        /// <summary>
        /// データ変更チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckUpDate()
        {
            bool result = true;

            if (this.Goods_Grid.DataSource == null) return true;

            // 更新チェック
            if (!CheckUpDateProc())
            {
                DialogResult ret = TMsgDisp.Show(
                   this,								        // 親ウィンドウフォーム
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // エラーレベル
                   CT_ASSEMBLYID,						        // アセンブリIDまたはクラスID
                   "現在、編集中のデータが存在します"
                   + Environment.NewLine
                   + "登録してもよろしいですか？",   		    // 表示するメッセージ 
                   0,								            // ステータス値
                   MessageBoxButtons.YesNoCancel);				// 表示するボタン

                if (ret == DialogResult.Yes)
                {
                    // 保存処理
                    int st = this.SaveProc();
                    if (st != 0)
                    {
                        return false;
                    }
                }
                else if (ret == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return result;
        }

        /// <summary>
        /// データ変更チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckUpDateProc()
        {
            bool ret = true;

            // データが更新されているかチェック
            this.UpDateGrid();
            this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();

            // 保存データを作成
            List<ProposeGoods> saveList = new List<ProposeGoods>();
            List<ProposeGoods> delList = new List<ProposeGoods>();
            this.MakeSaveData(0, out saveList, out delList);

            // データ内容比較
            for (int i = 0; i < this.TBODataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].Rows[i];

                // 画像変更チェック
                if ((int)row[COL_IMAGE_CHANGE] == 1)
                {
                    return false;
                }

                if (row[COL_POSTPARACLASS] == DBNull.Value)
                {
                    // 新規行
                    return false;
                }
                else
                {
                    if ((int)row[COL_DEL] == 1)
                    {
                        // 保存済行が削除されている
                        return false;
                    }
                    else
                    {
                        ProposeGoods befGoods = (ProposeGoods)row[COL_POSTPARACLASS];
                        ProposeGoods afGoods = saveList.Find(
                            delegate(ProposeGoods wkProposeGoods)
                            {
                                if (wkProposeGoods.partsNumber == befGoods.partsNumber &&
                                    wkProposeGoods.makerName == befGoods.makerName)
                                    return true;
                                else
                                    return false;
                            }
                        );

                        if (afGoods == null)
                        {
                            return false;
                        }
                        else
                        {
                            // メンバ比較(付随整備、商品タグ以外)
                            if (!ProposeGoods.Equals(befGoods, afGoods))
                            {
                                return false;
                            }

                            // 付随整備を比較
                            #region
                            if (befGoods.attendRepairList == null)
                            {
                                if (afGoods.attendRepairList != null && afGoods.attendRepairList.Length > 0)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (afGoods.attendRepairList == null)
                                {
                                    return false;
                                }
                                else if (befGoods.attendRepairList.Length != afGoods.attendRepairList.Length)
                                {
                                    return false;
                                }
                                else
                                {
                                    foreach (AttendRepair bf in befGoods.attendRepairList)
                                    {
                                        bool sameFlag = false;
                                        foreach (AttendRepair af in afGoods.attendRepairList)
                                        {
                                            if (bf.attendRepairId == af.attendRepairId)
                                            {
                                                sameFlag = true;
                                                if (!bf.dataType.Equals(af.dataType)) return false;
                                                if (!bf.priceType.Equals(af.priceType)) return false;
                                                if (!bf.repairName.Equals(af.repairName)) return false;
                                                if (!bf.repairPrice.Equals(af.repairPrice)) return false;
                                                if (!bf.sortNo.Equals(af.sortNo)) return false;
                                            }
                                        }
                                        if (sameFlag == false) return false;
                                    }
                                }
                            }
                            #endregion

                            // 商品タグを比較
                            #region
                            if (befGoods.goodsTagList == null)
                            {
                                if (afGoods.goodsTagList != null && afGoods.goodsTagList.Length > 0)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (afGoods.goodsTagList == null)
                                {
                                    return false;
                                }
                                else if (befGoods.goodsTagList.Length != afGoods.goodsTagList.Length)
                                {
                                    return false;
                                }
                                else
                                {
                                    foreach (GoodsTag bfTag in befGoods.goodsTagList)
                                    {
                                        bool sameFlag = false;
                                        foreach (GoodsTag afTag in afGoods.goodsTagList)
                                        {
                                            if (bfTag.goodsTagId == afTag.goodsTagId)
                                            {
                                                sameFlag = true;
                                                if (!bfTag.tag.Equals(afTag.tag)) return false;
                                            }
                                        }
                                        if (sameFlag == false) return false;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            return ret;
        }


        /// <summary>
        /// データ変更チェック(行単位)
        /// </summary>
        /// <returns></returns>
        private bool CheckUpDateProc(DataRow row, ProposeGoods afGoods, ProposeGoods befGoods)
        {
            bool ret = true;

            // 画像変更チェック
            if ((int)row[COL_IMAGE_CHANGE] == 1)
            {
                return false;
            }

            if ((int)row[COL_DEL] == 1)
            {
                // 保存済行が削除されている
                return false;
            }
            else
            {
                // メンバ比較(付随整備、商品タグ以外)
                if (!ProposeGoods.Equals(befGoods, afGoods))
                {
                    return false;
                }

                // 付随整備を比較
                #region
                if (befGoods.attendRepairList == null)
                {
                    if (afGoods.attendRepairList != null && afGoods.attendRepairList.Length > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (afGoods.attendRepairList == null)
                    {
                        return false;
                    }
                    else if (befGoods.attendRepairList.Length != afGoods.attendRepairList.Length)
                    {
                        return false;
                    }
                    else
                    {
                        foreach (AttendRepair bf in befGoods.attendRepairList)
                        {
                            bool sameFlag = false;
                            foreach (AttendRepair af in afGoods.attendRepairList)
                            {
                                if (bf.attendRepairId == af.attendRepairId)
                                {
                                    sameFlag = true;
                                    if (!bf.dataType.Equals(af.dataType)) return false;
                                    if (!bf.priceType.Equals(af.priceType)) return false;
                                    if (!bf.repairName.Equals(af.repairName)) return false;
                                    if (!bf.repairPrice.Equals(af.repairPrice)) return false;
                                    if (!bf.sortNo.Equals(af.sortNo)) return false;
                                }
                            }
                            if (sameFlag == false) return false;
                        }
                    }
                }
                #endregion

                // 商品タグを比較
                #region
                if (befGoods.goodsTagList == null)
                {
                    if (afGoods.goodsTagList != null && afGoods.goodsTagList.Length > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (afGoods.goodsTagList == null)
                    {
                        return false;
                    }
                    else if (befGoods.goodsTagList.Length != afGoods.goodsTagList.Length)
                    {
                        return false;
                    }
                    else
                    {
                        foreach (GoodsTag bfTag in befGoods.goodsTagList)
                        {
                            bool sameFlag = false;
                            foreach (GoodsTag afTag in afGoods.goodsTagList)
                            {
                                if (bfTag.goodsTagId == afTag.goodsTagId)
                                {
                                    sameFlag = true;
                                    if (!bfTag.tag.Equals(afTag.tag)) return false;
                                }
                            }
                            if (sameFlag == false) return false;
                        }
                    }
                }
                #endregion
            }
            return ret;
        }
        #endregion

        #endregion

        #region 保存処理

        /// <summary>
        /// 保存処理
        /// </summary>
        private int SaveProc()
        {
            int st = 0;
            string errMsg = "";

            // 抽出されてない
            if (this.Goods_Grid.DataSource == null) return st;

            // グリッドが編集中だったら編集モードを終了する
            if (this.Goods_Grid.ActiveCell != null)
            {
                this.Goods_Grid.ActiveCell.Selected = false;
                this.Goods_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            // 入力チェック
            if (!this.DataInputCheck())
            {
                return -1;
            }

            // ワーニング
            if (!this.DataWarningCheck())
            {
                return -1;
            }

            // TODO 公開先追加の時に問題になりそうなのでやめる
            // データが１件でも更新されている
            //if (CheckUpDateProc())
            //{
            //    TMsgDisp.Show(
            //          this,							        // 親ウィンドウフォーム
            //          emErrorLevel.ERR_LEVEL_INFO,	        // エラーレベル
            //          CT_ASSEMBLYID,					    // アセンブリIDまたはクラスID
            //          "更新対象データはありません",		    // 表示するメッセージ 
            //          st,								    // ステータス値
            //          MessageBoxButtons.OK);
            //    return st;
            //}

            // 保存処理用リスト
            List<ProposeGoods> saveParaList = new List<ProposeGoods>();
            List<ProposeGoods> dellParaList = new List<ProposeGoods>();

            // 部品商モードの場合は公開先選択画面を起動
            if (this._bootPara.BootMode == BootMode.PM)
            {

                // 公開先選択画面を起動
                ReleaseSelectForm form = new ReleaseSelectForm();
                form.Icon = this.Icon;
                form._categoryID = (long)this.Category_ComboEditor.Value;
                form._categoryName = this.Category_ComboEditor.Text;
                form._enterpriseCode = this._bootPara.EnterpriseCode;
                form._enterpriseName = this._bootPara.EnterpriseName;
                form._sectionCode = this.Section_ComboEditor.Value.ToString();
                form._sectionName = this.Section_ComboEditor.Text;

                // TODO現在の拠点分のSCM接続情報を渡す
                if (this._scmSceDic.ContainsKey(form._sectionCode))
                {
                    form._scmList = this._scmSceDic[form._sectionCode];
                }
                else
                {
                    // 有効な公開先がない ありえないけど
                    TMsgDisp.Show(
                    this,							        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                    CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                    "公開先の取得に失敗しました",		    // 表示するメッセージ 
                    -1,								        // ステータス値
                    MessageBoxButtons.OK);
                    return -1;
                }

                form._mode = 0;

                DialogResult ret = form.ShowReleaseSelectFrom();
                if (ret == DialogResult.Cancel)
                {
                    return 0;
                }
                else if (ret == DialogResult.Abort)
                {
                    return -1;
                }

                // 保存データ作成
                this.MakeSaveData(1, out saveParaList, out dellParaList);
                ProposeGoods[] saveAray = saveParaList.ToArray();

                //ピロピロ表示
                Broadleaf.Windows.Forms.SFCMN00299CA waitForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                waitForm.Title = "保存中";
                waitForm.Message = "現在、商品データを保存中です。";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    waitForm.Show();

                    // 提案商品情報の更新
                    st = this._TBOServiceACS.SavePropose_Goods(ref saveAray, out errMsg);

                    if (st == 0)
                    {
                        // 更新情報を反映
                        this.SetSaveData(saveAray, dellParaList);

                        // 公開情報保存処理
                        if (form._startProposeList.Count > 0)
                        {
                            // 新着情報登録
                            News news = new News();
                            news.enterpriseCode = this._bootPara.EnterpriseCode;
                            news.enterpriseName = this._bootPara.EnterpriseName;
                            news.goodsCategoryId = (long)this.Category_ComboEditor.Value;
                            news.newsTitle = form.NewsTitle;
                            news.newsContent = form.NewsContent;
                            news.sectionCode = this.Section_ComboEditor.Value.ToString();
                            news.sectionName = this.Section_ComboEditor.Text;
                            news.proposeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            List<ProposeStore> storeList = new List<ProposeStore>();
                            foreach (Propose_Para_SCM scm in form._startProposeList)
                            {
                                ProposeStore proposeStore = new ProposeStore();
                                proposeStore.enterpriseCode = scm.CnectOriginalEpCd;
                                proposeStore.enterpriseName = scm.CnectOriginalEpNm;
                                proposeStore.sectionCode = scm.CnectOriginalSecCd;
                                proposeStore.sectionName = scm.CnectOriginalSecNm;
                                storeList.Add(proposeStore);
                            }
                            news.proposeStoreList = storeList.ToArray();

                            

                            // 公開処理
                            st = this._TBOServiceACS.SaveNews(news, out errMsg);
                            if (st != 0)
                            {
                                this.Cursor = Cursors.Default;
                                waitForm.Close();

                                TMsgDisp.Show(
                                this,							        // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                                CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                                errMsg,		                        // 表示するメッセージ 
                                st,								    // ステータス値
                                MessageBoxButtons.OK);
                                return st;
                            }
                        }

                        // 公開停止
                        if (form._stopProposeList.Count > 0)
                        {
                            st = this._TBOServiceACS.DeleteDestSetting_bulk(form._stopProposeList, out errMsg);

                            if (st != 0)
                            {
                                this.Cursor = Cursors.Default;
                                waitForm.Close();
                                TMsgDisp.Show(
                                this,							        // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                                CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                                errMsg,		                        // 表示するメッセージ 
                                st,								    // ステータス値
                                MessageBoxButtons.OK);
                                return st;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        waitForm.Close();

                        if (saveAray.Length > 0)
                        {
                            // 更新情報を反映
                            this.SetSaveData(saveAray, dellParaList);
                        }

                         TMsgDisp.Show(
                         this,							        // 親ウィンドウフォーム
                         emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                         CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                         errMsg,		                        // 表示するメッセージ 
                         st,								    // ステータス値
                         MessageBoxButtons.OK);
                        return st;
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    waitForm.Close();
                }

                if (st == 0)
                {
                    if (this._initFlag)
                    {
                        // セル色を初期化
                        this._initFlag = false;
                        this.Goods_Grid.DataSource = null;
                        this.Goods_Grid.DataSource = this.TBODataSet.Tables[TABLE_MAIN];
                    }

                    TMsgDisp.Show(
                    this,							// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                    CT_ASSEMBLYID,					// アセンブリIDまたはクラスID
                    "保存しました。",			    // 表示するメッセージ 
                    st,								// ステータス値
                    MessageBoxButtons.OK);
                }
            }
            else 
            {
                // 整備工場モード

                // 保存データ作成
                this.MakeSaveData(1, out saveParaList, out dellParaList);
                ProposeGoods[] saveAray = saveParaList.ToArray();

                 //ピロピロ表示
                Broadleaf.Windows.Forms.SFCMN00299CA waitForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                waitForm.Title = "保存中";
                waitForm.Message = "現在、提案データを保存中です。";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    waitForm.Show();

                    // 提案商品情報の更新
                    st = this._TBOServiceACS.SavePropose_Goods(ref saveAray, out errMsg);
                    if (st == 0)
                    {
                        // 更新情報を反映
                        this.SetSaveData(saveAray, dellParaList);

                        // 自社在庫なので公開先選択画面は起動しない
                        // 新着情報登録
                        News news = new News();
                        news.enterpriseCode = this._bootPara.EnterpriseCode;
                        news.enterpriseName = this._bootPara.EnterpriseName;
                        news.goodsCategoryId = (long)this.Category_ComboEditor.Value;
                        news.newsTitle = "商品情報の更新";
                        news.sectionCode = this.Section_ComboEditor.Value.ToString();
                        news.sectionName = this.Section_ComboEditor.Text;
                        news.proposeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        ProposeStore proposeStore = new ProposeStore();
                        proposeStore.enterpriseCode = this._bootPara.EnterpriseCode;
                        proposeStore.enterpriseName = this._bootPara.EnterpriseName;
                        proposeStore.sectionCode = this.Section_ComboEditor.Value.ToString();
                        proposeStore.sectionName = this.Section_ComboEditor.Text;
                        news.proposeStoreList = new ProposeStore[] { proposeStore };

                        // 公開処理
                        st = this._TBOServiceACS.SaveNewsAdopt(news, out errMsg);
                        if (st != 0)
                        {
                            this.Cursor = Cursors.Default;
                            waitForm.Close();
                            TMsgDisp.Show(
                            this,							        // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                            CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                            errMsg,		                        // 表示するメッセージ 
                            st,								    // ステータス値
                            MessageBoxButtons.OK);
                            return st;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        waitForm.Close();
                        TMsgDisp.Show(
                        this,							        // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                        CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                        errMsg,		                        // 表示するメッセージ 
                        st,								    // ステータス値
                        MessageBoxButtons.OK);
                        return st;
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    waitForm.Close();
                }

                if (st == 0)
                {
                    if (this._initFlag)
                    {
                        // セル色を初期化
                        this._initFlag = false;
                        this.Goods_Grid.DataSource = null;
                        this.Goods_Grid.DataSource = this.TBODataSet.Tables[TABLE_MAIN];
                    }

                    string saveMsg = "保存しました。";
                    if (this._bootPara.BootMode == BootMode.SF)
                    {
                        saveMsg += Environment.NewLine + "CarpodTabにて商品の確認・公開を行って下さい。";
                    }

                    TMsgDisp.Show(
                    this,							// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,	// エラーレベル
                    CT_ASSEMBLYID,					// アセンブリIDまたはクラスID
                    saveMsg,			            // 表示するメッセージ 
                    st,								// ステータス値
                    MessageBoxButtons.OK);
                }
            }
            return st;
        }

        #region 保存データ作成

        #region メイン
        /// <summary>
        /// 保存データ作成(メイン)
        /// </summary>
        /// <param name="mode">0:入力チェック用,1:保存データ作成用</param>
        /// <param name="saveParaList">保存データ</param>
        /// <param name="dellParaList">削除データ</param>
        private void MakeSaveData(int mode,　out List<ProposeGoods> saveParaList, out List<ProposeGoods> dellParaList)
        {
            saveParaList = new List<ProposeGoods>();
            dellParaList = new List<ProposeGoods>();

            // 未保存行削除分をテーブルから消す
            List<DataRow> delRowList = new List<DataRow>();
            for (int i = 0; i < this.TBODataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].Rows[i];
                // 新規、更新判断
                if ((int)row[COL_DEL] == 1 && row[COL_POSTPARACLASS] == DBNull.Value)
                {
                    delRowList.Add(row);
                }
            }

            foreach (DataRow delRow in delRowList)
            {
                this.TBODataSet.Tables[TABLE_MAIN].Rows.Remove(delRow);
            }

            this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
            this.UpDateGrid();

            // グリッドの表示順でソート順を振りなおし
            for (int i = 0; i < this.Goods_Grid.Rows.Count; i++)
            {
                this.Goods_Grid.Rows[i].Cells[COL_SORTNO].Value = i;
            }

            this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
            this.UpDateGrid();


            List<AttendRepairSet> repairSetList = new List<AttendRepairSet>();
            Dictionary<string, string> repairIdDic = new Dictionary<string, string>();
            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                repairSetList = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                repairIdDic = new Dictionary<string, string>();

                // 付随整備IDディクショナリ
                foreach (DataColumn col in this.TBODataSet.Tables[TABLE_MAIN].Columns)
                {
                    if (col.ColumnName.Contains(COL_REPARE))
                    {
                        // 部品商モードの場合はattendRepairID、整備工場モードの場合はstoreRepairIDがキーとなる
                        repairIdDic.Add(col.ColumnName.Replace(COL_REPARE, ""), col.ColumnName);
                    }
                }
            }

            long dtTicks = DateTime.Now.Ticks;

            for (int i = 0; i < this.TBODataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                ProposeGoods proposeGoods = new ProposeGoods();
                GoodsTag[] tagArray = null;

                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].Rows[i];

                // 新規、更新判断
                if (row[COL_POSTPARACLASS] != DBNull.Value)
                {
                    // 更新レコードクローン
                    proposeGoods = ((ProposeGoods)row[COL_POSTPARACLASS]).Clone();

                    // タグ
                    if(proposeGoods.goodsTagList != null)
                    {
                        tagArray = new GoodsTag[proposeGoods.goodsTagList.Length];
                        for (int ii = 0; ii < proposeGoods.goodsTagList.Length; ii++)
			            {
                            tagArray[ii] = proposeGoods.goodsTagList[ii].Clone();
			            }
                    }

                    // PM更新日時
                    proposeGoods.pmUpdDtTime = (long)row[COL_PM_UPDATETIME];
                }
                else
                {
                    // 新規レコード
                    proposeGoods.enterpriseCode = this._bootPara.EnterpriseCode;            // 企業コード  
                    proposeGoods.enterpriseName = this._bootPara.EnterpriseName;            // 企業名称 
                    proposeGoods.sectionCode = this.Section_ComboEditor.Value.ToString();   // 拠点コード
                    proposeGoods.sectionName = this.Section_ComboEditor.Text;               // 拠点名称
                    proposeGoods.goodsCategoryId = (long)this.Category_ComboEditor.Value;    // 商品カテゴリ

                    // ヘッダ項目
                    proposeGoods.insAccountId = 0;
                    proposeGoods.insDtTime = 0;
                    proposeGoods.proposeGoodsId = 0;
                    proposeGoods.uuid = "";

                    // PM更新日
                    if (row[COL_PM_UPDATETIME] == DBNull.Value || (long)row[COL_PM_UPDATETIME] == 0)
                    {
                        proposeGoods.pmUpdDtTime = dtTicks;
                    }
                    else
                    {
                        proposeGoods.pmUpdDtTime = (long)row[COL_PM_UPDATETIME];
                    }
                }

                // 新規・更新共通
                proposeGoods.logicalDelDiv = (int)row[COL_DEL];                         // 論理削除区分
                proposeGoods.releaseFlag = (bool)row[COL_RELEASE];                      // 公開フラグ
                proposeGoods.recommendFlag = (bool)row[COL_RECOMMEND];                  // オススメフラグ
                proposeGoods.pmMakerCode = (int)row[COL_MAKERCD];                       // メーカーコード
                proposeGoods.makerName = row[COL_MAKERNM].ToString();                   // メーカー名称
                proposeGoods.partsNumber = row[COL_GOODSNO].ToString();                 // 品番   
                proposeGoods.proposeGoodsName = row[COL_GOODSNM].ToString();            // 商品名称
                proposeGoods.goodsNote = row[COL_GOODSNOTE].ToString();                 // 商品説明
                proposeGoods.goodsPr = row[COL_GOODSPR].ToString();                     // 商品ＰＲ



                // 発売日
                if (row[COL_RELEASEDATE] != DBNull.Value)
                {
                    proposeGoods.releaseDate = ((DateTime)row[COL_RELEASEDATE]).ToString("yyyy-MM-dd");
                }
                else
                {
                    proposeGoods.releaseDate = null;
                }

                // 公開開始日
                if (row[COL_SHOPSALEBEGINDATE] != DBNull.Value)
                {
                    proposeGoods.shopSaleBeginDate = ((DateTime)row[COL_SHOPSALEBEGINDATE]).ToString("yyyy-MM-dd");
                }
                else
                {
                    proposeGoods.shopSaleBeginDate = null;
                }

                // 公開終了日
                if (row[COL_SHOPSALEENDDATE] != DBNull.Value)
                {
                    proposeGoods.shopSaleEndDate = ((DateTime)row[COL_SHOPSALEENDDATE]).ToString("yyyy-MM-dd");
                }
                else
                {
                    proposeGoods.shopSaleEndDate = null;
                }


                // 金額
                proposeGoods.suggestPrice = (long)row[COL_SUGGEST_PRICE];                   // 標準価格
                proposeGoods.shopPrice = (long)row[COL_SHOP_PRICE];                        // 店頭価格
                proposeGoods.tradePrice = (long)row[COL_TRADE_PRICE];                       // 卸値
                proposeGoods.purchaseCost = (long)row[COL_PURCHASE_COST];                   // 仕入原価
                proposeGoods.stockState = Convert.ToInt32(row[COL_STOCKSTATE].ToString());   // 在庫状態

                // 商品タグリスト
                proposeGoods.goodsTagList = this.MakeGoodsTagList(row, tagArray);

                // 付随整備リスト
                proposeGoods.attendRepairList = this.MakeAttendRepairList(row, repairSetList, repairIdDic);

                // ソート
                proposeGoods.sortNo = (int)row[COL_SORTNO];

                // 個別設定→拡張用
                proposeGoods.proposeDistGoodsSetting = new ProposeDistGoodsSetting[0];

                // 画像
                proposeGoods.imageId = (long)row[COL_IMAGE_NO];
                // シリアライズでエラーになるのでImageは削除
                proposeGoods.image_Data = null;


                // データ保存時は変更がある分のみ作成
                if (mode == 1)
                {
                    if (row[COL_POSTPARACLASS] != DBNull.Value)
                    {
                        // 行変更チェック
                        if (this.CheckUpDateProc(row, proposeGoods, ((ProposeGoods)row[COL_POSTPARACLASS]).Clone()))
                        {
                            // 変更されてなかったら保存対象外とする
                            continue;
                        }
                    }
                }

                saveParaList.Add(proposeGoods);

                if (proposeGoods.logicalDelDiv == 1)
                {
                    dellParaList.Add(proposeGoods.Clone());
                }
            }
        }
        #endregion

        #region 付随整備
        /// <summary>
        /// 付随整備データ作成処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="repairArray"></param>
        /// <returns></returns>
        private AttendRepair[] MakeAttendRepairList(DataRow row, List<AttendRepairSet> repairList, Dictionary<string, string> repairIdDic)
        {
            // DB側はDEL＆INSERTなので常に新規で送る。
            // 提案商品付随整備
            List<AttendRepair> retList = new List<AttendRepair>();

            // 付随整備設定
            foreach (AttendRepairSet set in repairList)
            {
                AttendRepair newData = new AttendRepair();
                newData.enterpriseCode = this._bootPara.EnterpriseCode;
                newData.sectionCode = this.Section_ComboEditor.Value.ToString();
                newData.dataType = set.dataType;
                newData.priceType = set.priceType;
                newData.repairName = set.repairName;
                newData.sortNo = set.sortNo;
                newData.uuid = "";

                if (this._bootPara.BootMode == BootMode.PM)
                {
                    newData.attendRepairId = set.attendRepairId;

                    if (repairIdDic.ContainsKey(set.attendRepairId.ToString()))
                    {
                        string colNm = repairIdDic[set.attendRepairId.ToString()];
                        if (this.TBODataSet.Tables[TABLE_MAIN].Columns.Contains(colNm))
                        {
                            newData.repairPrice = (long)row[colNm];
                        }
                        else
                        {
                            newData.repairPrice = set.repairPrice;
                        }
                    }
                }
                else
                {
                    // 整備工場モードの場合はstoreAttendRepairIdをattendRepairIdにセット
                    newData.attendRepairId = set.storeAttendRepairId;

                    if (repairIdDic.ContainsKey(set.storeAttendRepairId.ToString()))
                    {
                        string colNm = repairIdDic[set.storeAttendRepairId.ToString()];
                        if (this.TBODataSet.Tables[TABLE_MAIN].Columns.Contains(colNm))
                        {
                            newData.repairPrice = (long)row[colNm];
                        }
                        else
                        {
                            newData.repairPrice = set.repairPrice;
                        }
                    }
                }
                retList.Add(newData);
            }
            return retList.ToArray();
        }
        #endregion

        #region 商品タグリスト
        /// <summary>
        /// 商品タグリスト作成
        /// </summary>
        /// <returns></returns>
        private GoodsTag[] MakeGoodsTagList(DataRow row, GoodsTag[] tagArray)
        {
            #region
            List<GoodsTag> tagList = new List<GoodsTag>();

            if (tagArray != null && tagArray.Length > 0)
            {
                // 更新時
                // 論理削除区分を設定
                for (int i = 0; i < tagArray.Length; i++)
                {
                    tagArray[i].logicalDelDiv = (int)row[COL_DEL];
                }
            }

            if (tagArray != null)
            {
                // 更新時
                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1: // タイヤ
                        for (int i = 0; i < tagArray.Length; i++)
                        {
                            if (tagArray[i].tagNo == 1)
                            {
                                // サイズ
                                tagArray[i].tag = row[COL_TIRE_KEY1].ToString();
                            }
                            else if (tagArray[i].tagNo == 2)
                            {
                                // スタッドレス
                                if ((bool)row[COL_TIRE_KEY2])
                                {
                                    tagArray[i].tag = "1";
                                }
                                else
                                {
                                    tagArray[i].tag = "0";
                                }
                            }
                        }
                        break;
                    case 2: // バッテリ
                        for (int i = 0; i < tagArray.Length; i++)
                        {
                            if (tagArray[i].tagNo == 1)
                            {
                                // 規格
                                tagArray[i].tag = row[COL_BATTERY_KEY1].ToString();
                            }
                            else if (tagArray[i].tagNo == 2)
                            {
                                // 適合
                                switch ((int)row[COL_BATTERY_KEY2])
                                {
                                    case 1: // 標準車専用
                                    case 3: // 兼用
                                        tagArray[i].tag = "1";
                                        break;
                                    case 2: // ISS専用
                                        tagArray[i].tag = "0";
                                        break;
                                    default:
                                        tagArray[i].tag = "1";
                                        break;
                                }
                            }
                            else if (tagArray[i].tagNo == 3)
                            {
                                // 適合
                                switch ((int)row[COL_BATTERY_KEY2])
                                {
                                    case 1: // 標準車専用
                                        tagArray[i].tag = "0";
                                        break;
                                    case 2: // ISS専用
                                    case 3: // 兼用
                                        tagArray[i].tag = "1";
                                        break;
                                    default:
                                        tagArray[i].tag = "0";
                                        break;
                                }
                            }
                        }
                        break;
                    case 3: // オイル
                        for (int i = 0; i < tagArray.Length; i++)
                        {
                            if (tagArray[i].tagNo == 1)
                            {
                                // 規格
                                tagArray[i].tag = row[COL_OIL_KEY1].ToString();
                            }
                            else if (tagArray[i].tagNo == 2)
                            {
                                // 適合
                                switch ((int)row[COL_OIL_KEY2])
                                {
                                    case 1: // ガソリン専用
                                    case 3: // 兼用
                                        tagArray[i].tag = "1";
                                        break;
                                    case 2: // ディーゼル専用
                                        tagArray[i].tag = "0";
                                        break;
                                    default:
                                        tagArray[i].tag = "1";
                                        break;
                                }
                            }
                            else if (tagArray[i].tagNo == 3)
                            {
                                // 適合
                                switch ((int)row[COL_OIL_KEY2])
                                {
                                    case 1: // ガソリン専用
                                        tagArray[i].tag = "0";
                                        break;
                                    case 2: // ディーゼル専用
                                    case 3: // 兼用
                                        tagArray[i].tag = "1";
                                        break;
                                    default:
                                        tagArray[i].tag = "0";
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                // 新規時
                // カテゴリ別 ※使用するキーは今のところ固定
                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1: // タイヤ
                        for (int i = 1; i < 3; i++)
                        {
                            GoodsTag tag = new GoodsTag();
                            tag.enterpriseCode = this._bootPara.EnterpriseCode;
                            tag.tagNo = i;
                            tag.sectionCode = this.Section_ComboEditor.Value.ToString();
                            tag.uuid = "";
                            if (i == 1)
                            {
                                // サイズ
                                tag.tag = row[COL_TIRE_KEY1].ToString();
                            }
                            else if (i == 2)
                            {
                                // スタッドレス
                                if ((bool)row[COL_TIRE_KEY2])
                                {
                                    tag.tag = "1";
                                }
                                else
                                {
                                    tag.tag = "0";
                                }
                            }
                            tagList.Add(tag);
                        }
                        break;
                    case 2:　// バッテリ

                        // タグ
                        GoodsTag btag1 = new GoodsTag();
                        GoodsTag btag2 = new GoodsTag();
                        GoodsTag btag3 = new GoodsTag();
                        btag1.enterpriseCode = btag2.enterpriseCode = btag3.enterpriseCode = this._bootPara.EnterpriseCode;
                        btag1.tagNo = 1;
                        btag2.tagNo = 2;
                        btag3.tagNo = 3;
                        btag1.sectionCode = btag2.sectionCode = btag3.sectionCode = this.Section_ComboEditor.Value.ToString();
                        btag1.uuid = btag2.uuid = btag3.uuid = "";

                        // 規格
                        btag1.tag = row[COL_BATTERY_KEY1].ToString();

                        // 適合
                        switch ((int)row[COL_BATTERY_KEY2])
                        {
                            case 1: // 標準車専用
                                btag2.tag = "1";
                                btag3.tag = "0";
                                break;
                            case 2: // ISS専用
                                btag2.tag = "0";
                                btag3.tag = "1";
                                break;
                            case 3: // 兼用
                                btag2.tag = "1";
                                btag3.tag = "1";
                                break;
                            default:
                                btag2.tag = "1";
                                btag3.tag = "0";
                                break;
                        }

                        tagList.Add(btag1);
                        tagList.Add(btag2);
                        tagList.Add(btag3);
                        break;
                    case 3:　// オイル
                        // タグ
                        GoodsTag otag1 = new GoodsTag();
                        GoodsTag otag2 = new GoodsTag();
                        GoodsTag otag3 = new GoodsTag();
                        otag1.enterpriseCode = otag2.enterpriseCode = otag3.enterpriseCode = this._bootPara.EnterpriseCode;
                        otag1.tagNo = 1;
                        otag2.tagNo = 2;
                        otag3.tagNo = 3;
                        otag1.sectionCode = otag2.sectionCode = otag3.sectionCode = this.Section_ComboEditor.Value.ToString();
                        otag1.uuid = otag2.uuid = otag3.uuid = "";

                        // 規格
                        otag1.tag = row[COL_OIL_KEY1].ToString();

                        // 適合
                        switch ((int)row[COL_OIL_KEY2])
                        {
                            case 1: // ガソリン車専用
                                otag2.tag = "1";
                                otag3.tag = "0";
                                break;
                            case 2:　// ディーゼル車専用
                                otag2.tag = "0";
                                otag3.tag = "1";
                                break;
                            case 3: // 兼用
                                otag2.tag = "1";
                                otag3.tag = "1";
                                break;
                            default:
                                otag2.tag = "1";
                                otag3.tag = "0";
                                break;
                        }
                        tagList.Add(otag1);
                        tagList.Add(otag2);
                        tagList.Add(otag3);
                        break;
                }
            }

            if (tagArray != null)
                tagList.AddRange(tagArray);

            return tagList.ToArray();
            #endregion
        }
        #endregion

        #endregion

        /// <summary>
        /// 保存済みデータ更新
        /// </summary>
        /// <param name="saveAray"></param>
        private void SetSaveData(ProposeGoods[] saveAray, List<ProposeGoods> dellList)
        {
            // 提案商品IDはサーバー側で採番されるのでキーにならない
            // よって品番 + メーカー名称にて当てる
            // 名称であてるのはメーカーコードの未入力を許す為

            string mkNm = "";
            string goodsNo = "";
            if (saveAray != null)
            {
                for (int i = 0; i < saveAray.Length; i++)
                {
                    mkNm = saveAray[i].makerName;
                    goodsNo = saveAray[i].partsNumber;
                    StringBuilder cndString = new StringBuilder();
                    cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                    DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());
                    if (rows != null)
                    {
                        rows[0][COL_POSTPARACLASS] = saveAray[i];
                        rows[0][COL_PM_UPDATETIME] = saveAray[i].pmUpdDtTime;
                        rows[0][COL_IMAGE_CHANGE] = 0;
                    }
                }
            }

            if (dellList != null && dellList.Count > 0)
            {
                for (int i = 0; i < dellList.Count; i++)
                {
                    mkNm = dellList[i].makerName;
                    goodsNo = dellList[i].partsNumber;
                    StringBuilder cndString = new StringBuilder();
                    cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                    DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());
                    if (rows != null)
                    {
                        for (int ii = 0; ii < rows.Length; ii++)
                        {
                            this.TBODataSet.Tables[TABLE_MAIN].Rows.Remove(rows[ii]);
                        }
                    }
                }
            }
        }
        #endregion

        #region 金額計算

        #region 粗利
        /// <summary>
        /// 粗利の計算を行います(整備工場)
        /// </summary>
        private void CalcGrossSF(long shopPrice, long repareTotal, long tradePrice, out long gross, out string grossMargin)
        {
            // 部品商モード整備工場の粗利
            // 粗利金額: 店頭価格＋付随整備-売価　
            // 粗利率  : 粗利金額 / 売上高 ※現状は付随作業も売上として含めて計算

            gross = 0;
            grossMargin = "";

            // 粗利
            gross = shopPrice + repareTotal - tradePrice;
            // 売上
            long salesTotal = shopPrice + repareTotal;

            // 粗利率計算(小数点以下四捨五入とする)

            if (salesTotal != 0) // 0除算チェック
            {
                double wkGross = gross;
                double wkTotal = salesTotal;
                double ans = Math.Round(((wkGross / wkTotal) * 100), MidpointRounding.AwayFromZero);
                grossMargin = ans.ToString("F0") + "%";
            }
            else
            {
                grossMargin = "";
            }

        }

        /// <summary>
        /// 粗利の計算を行います
        /// </summary>
        private void CalcGrossPM(long tradePrice, long cost, out long gross, out string grossMargin)
        {
            // 部品商モード部品商の粗利
            // 粗利金額: 販売価格 - 仕入原価　
            // 粗利率  : 粗利金額 / 販売価格 

            gross = 0;
            grossMargin = "";

            // 粗利
            gross = tradePrice - cost;

            // 粗利率計算(小数点以下四捨五入とする)

            if (tradePrice != 0) // 0除算チェック
            {
                double wkGross = gross;
                double wkTotal = tradePrice;
                double ans = Math.Round(((wkGross / wkTotal) * 100), MidpointRounding.AwayFromZero);
                grossMargin = ans.ToString("F0") + "%";
            }
            else
            {
                grossMargin = "";
            }
        }
        #endregion

        #region 付随整備
        /// <summary>
        /// 付随整備金額の合計を計算します
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private long CalcRepareTotal(int index)
        {
            long ret = 0;
            UltraGridRow row = this.Goods_Grid.Rows[index];

            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                List<AttendRepairSet> list = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                for (int i = 0; i < list.Count; i++)
                {
                    string key = "";
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        key = this.MakeAttenRepairKey(list[i].attendRepairId.ToString());
                    }
                    else
                    {
                        key = this.MakeAttenRepairKey(list[i].storeAttendRepairId.ToString());
                    }

                    if(this.TBODataSet.Tables[TABLE_MAIN].Columns.Contains(key))
                    {
                        ret += GetCellLong(row.Cells[key].Value, 0);
                    }
                }
            }
            return ret;
        }
        #endregion

        #endregion

        #region Grid関連

        #region 次のセル取得
        /// <summary>
        /// 次のセル取得
        /// </summary>
        /// <param name="activeCell"></param>
        /// <returns></returns>
        private UltraGridCell GetNextCell(UltraGridCell activeCell)
        {
            UltraGridCell nextCell = null;
            switch (activeCell.Column.Key)
            {
                case COL_GOODSNO: nextCell = activeCell.Row.Cells[COL_MAKERCD]; break;   // 品番→メーカーCD
                case COL_MAKERCD: nextCell = activeCell.Row.Cells[COL_MAKERGD]; break;   // メーカーCD→ガイド
                case COL_MAKERGD: nextCell = activeCell.Row.Cells[COL_MAKERNM]; break;   // ガイド→名称

                case COL_GROSSMARGIN_SF:
                    if (this._bootPara.BootMode == BootMode.SF)
                    {
                        // 次の行
                        if (activeCell.Row.HasNextSibling())
                        {
                            UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                            nextCell = nextRow.Cells[COL_RELEASE];
                        }
                        break;
                    }
                    break;
                case COL_GROSSMARGIN_PM:
                    {
                        // 次の行
                        if (activeCell.Row.HasNextSibling())
                        {
                            UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                            nextCell = nextRow.Cells[COL_RELEASE];
                        }
                        else
                        {
                            // 最終セル
                            nextCell = activeCell;
                        }
                        break;
                    }
            }

            if (nextCell != null)
            {
                if (nextCell.Row.GetCellActivationResolved(nextCell.Column) == Activation.Disabled)
                    nextCell = GetNextCell(nextCell);
            }

            return nextCell;
        }
        #endregion

        #region 前のセル取得
        /// <summary>
        /// 前のセル取得
        /// </summary>
        /// <param name="activeCell"></param>
        /// <returns></returns>
        private UltraGridCell GetPrevCell(UltraGridCell activeCell)
        {
            UltraGridCell prevCell = null;
            switch (activeCell.Column.Key)
            {
                case COL_GOODSNO: prevCell = activeCell.Row.Cells[COL_RECOMMEND]; break; // 品番→オススメ
                case COL_MAKERCD: prevCell = activeCell.Row.Cells[COL_GOODSNO]; break;   // メーカーCD→品番
                case COL_MAKERGD: prevCell = activeCell.Row.Cells[COL_MAKERCD]; break;   // メーカーガイド→CD
                case COL_MAKERNM: prevCell = activeCell.Row.Cells[COL_MAKERGD]; break;   // メーカー名称→ガイド
                case COL_RELEASE:
                    {
                        // 前の行
                        if (activeCell.Row.HasPrevSibling())
                        {
                            UltraGridRow prvRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                            if (this._bootPara.BootMode == BootMode.SF)
                            {
                                prevCell = prvRow.Cells[COL_GROSSMARGIN_SF];
                            }
                            else
                            {
                                prevCell = prvRow.Cells[COL_GROSSMARGIN_PM];
                            }
                        }
                        break;
                    }
            }

            if (prevCell != null)
            {
                if (prevCell.Row.GetCellActivationResolved(prevCell.Column) == Activation.Disabled)
                    prevCell = GetPrevCell(prevCell);
            }
            return prevCell;
        }
        #endregion

        #region セル→データ取得処理
        /// <summary>
        /// セル→Int32取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得数値</returns>
        /// <remarks>
        /// <br>Note       : セルに格納されている値がDBNullかどうかを判別して値を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private Int32 GetCellInt32(object value, Int32 defaultValue)
        {
            return (value != DBNull.Value) ? (int)value : defaultValue;
        }

        /// <summary>
        /// セル→long取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得数値</returns>
        /// <remarks>
        /// <br>Note       : セルに格納されている値がDBNullかどうかを判別して値を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private long GetCellLong(object value, long defaultValue)
        {
            return (value != DBNull.Value) ? (long)value : defaultValue;
        }

        /// <summary>
        /// セル→文字列取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得文字列</returns>
        /// <remarks>
        /// <br>Note       : セルに格納されている値がDBNullかどうかを判別して値を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private string GetCellString(object value, string defaultValue)
        {
            return (value != DBNull.Value) ? (string)value : defaultValue;
        }
        #endregion

        #region アクティブ行インデックス取得処理
        /// <summary>
        /// アクティブ行インデックス取得処理
        /// </summary>
        /// <return>行インデックス</return>
        /// <remarks>
        /// <br>Note       : アクティブ行のインデックスを取得します</br>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Date       : 2007.08.02</br>
        /// </remarks>
        private int GetActiveIndex()
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                return this.Goods_Grid.ActiveCell.Row.Index;
            }
            else if (this.Goods_Grid.ActiveRow != null)
            {
                return this.Goods_Grid.ActiveRow.Index;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 更新エラー発生時例外処理
        /// <summary>
        /// セル更新エラ発生時処理
        /// </summary>
        private void CellDataErrorProc()
        {
            // 数値項目の場合
            if ((this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                (this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                (this.Goods_Grid.ActiveCell.Column.DataType == typeof(double)))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = this.Goods_Grid.ActiveCell.EditorResolved;

                // 未入力は0にする
                if (editorBase.CurrentEditText.Trim() == "")
                {
                    editorBase.Value = 0;				// 0をセット
                    this.Goods_Grid.ActiveCell.Value = 0;
                }
                // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                else if ((editorBase.CurrentEditText.Trim() == "-") ||
                    (editorBase.CurrentEditText.Trim() == ".") ||
                    (editorBase.CurrentEditText.Trim() == "-."))
                {
                    editorBase.Value = 0;				// 0をセット
                    this.Goods_Grid.ActiveCell.Value = 0;
                }
                // 通常入力
                else
                {
                    try
                    {
                        editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.Goods_Grid.ActiveCell.Column.DataType);
                        this.Goods_Grid.ActiveCell.Value = editorBase.Value;
                    }
                    catch
                    {
                        editorBase.Value = 0;
                        this.Goods_Grid.ActiveCell.Value = 0;
                        if(this.Goods_Grid.ActiveCell.Column.Key == COL_MAKERCD)
                        {
                            // 名称もクリア
                            this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERNM].Value = string.Empty;
                        }
                    }
                }
            }
        }

        #endregion

        #region 数値入力チェック
        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key) == true)
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (Char.IsNumber(key) == false)
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region グリッドアップデート
        /// <summary>
        /// グリッドアップデート処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドのアップデート処理を行います。</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.Goods_Grid.UpdateData();
            this.Goods_Grid.Refresh();

            if (this.Goods_Grid.DataSource != null)
            {
                this.rowCout_label.Text = this.Goods_Grid.Rows.Count.ToString() + "件";

                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1:
                        this.InputMsg_Label.Text = CT_INPMSG_TIRE;
                        break;
                    case 2:
                        this.InputMsg_Label.Text = CT_INPMSG_BATTERY;
                        break;
                    case 3:
                        this.InputMsg_Label.Text = CT_INPMSG_OIL;
                        break;
                }
            }
            else
            {
                this.rowCout_label.Text = "";
                this.InputMsg_Label.Text = "";
            }
        }

        #endregion

        #endregion

        #endregion

        #region Event

        #region From

        #region Shown

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFMIT10201U_Shown(object sender, EventArgs e)
        {
            // 整備工場モード
            if (this._bootPara.BootMode == BootMode.SF)
            {
                // 整備工場モードの時、公開先は非表示
                this.proposeInfo_toolStripButton.Visible = false;
                // セットマスタ取込は非表示
                this.toolStripButton_SetImp.Visible = false;
                this.toolStripSeparator4.Visible = false;
                this.toolStripSeparator6.Visible = false;
                // 動作設定は非表示
                this.Setting_Button.Visible = false;
                this.SFImageSet_Button.Visible = true;
             
            }
            else
            {
                // 公開先リスト作成
                this.MakeCustomerList();
                // 動作設定リスト取得
                this.GetSettings();
            }

            // ログイン担当表示
            this.EmpName_toolStripLabel.Text = this._bootPara.EmployeeName;
            // 拠点リスト作成  // TODO 本社、拠点制御
            this.SetSection();
            // カテゴリリスト作成
            this.SetCategory();

            // 部品商モードの場合は企業単位の設定なので起動時に全件取得しておく
            if (this._bootPara.BootMode == BootMode.PM)
            {
                // 付随整備リスト作成
                this.SetAttendRepairSet();
            }
          
            // メーカーリスト作成
            this.MakeMakerDic();
           
            // ボタン制御
            this.SetRowDelEnabled();
            this.SetSpButtonEnabled(false);
        }
        

        /// <summary>
        /// 動作設定取得
        /// </summary>
        private void GetSettings()
        {
            List<Settings> settingsList = new List<Settings>();
            string errMsg = "";
            this._settingsDic.Clear();
            int st = this._TBOServiceACS.GetSettings(this._bootPara.EnterpriseCode, out settingsList, out errMsg);

            if (st == 0)
            {
                foreach (Settings settings in settingsList)
                {
                    if (!this._settingsDic.ContainsKey(settings.sectionCode))
                    {
                        this._settingsDic.Add(settings.sectionCode, settings);
                    }
                }
            }
            else
            {
                TMsgDisp.Show(
                     this,								            // 親ウィンドウフォーム
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // エラーレベル
                     CT_ASSEMBLYID,						            // アセンブリIDまたはクラスID
                     errMsg,		                                // 表示するメッセージ 
                     st,								            // ステータス値
                     MessageBoxButtons.OK);				            // 表示するボ
            }
        }

        #endregion

        #region FormClosing
        /// <summary>
        /// 閉じる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFMIT10201U_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckUpDate())
            {
                e.Cancel = true;
            }
        }
        #endregion

        #endregion

        #region Grid

        #region InitializeLayout

        /// <summary>
        /// グリッド初期化イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // 行セレクタ
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            e.Layout.Override.RowSelectorWidth = 20;

            // UseRowLayoutモードON
            e.Layout.Bands[0].UseRowLayout = true;

            // 幅
            e.Layout.Override.DefaultRowHeight = 100;
            e.Layout.Override.AllowAddNew = AllowAddNew.Yes;
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.AllowColMoving = AllowColMoving.NotAllowed;  // 行移動不可

            // フィルター 有効
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            
            // ヘッダの概観
            e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            e.Layout.Override.HeaderAppearance.FontData.Name = "ＭＳ ゴシック";
            e.Layout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // 非表示
            e.Layout.Bands[0].Columns[COL_DEL].Hidden = true;
            e.Layout.Bands[0].Columns[COL_SORTNO].Hidden = true;
            e.Layout.Bands[0].Columns[COL_PM_UPDATETIME].Hidden = true;
            e.Layout.Bands[0].Columns[COL_POSTPARACLASS].Hidden = true;
            e.Layout.Bands[0].Columns[COL_INDIVIDUAL].Hidden = true;
            e.Layout.Bands[0].Columns[COL_STOCKCOUNT].Hidden = true;
            e.Layout.Bands[0].Columns[COL_IMAGE_NO].Hidden = true;
            e.Layout.Bands[0].Columns[COL_IMAGE_CHANGE].Hidden = true;
            // 合計列
            e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Hidden = true;

            // BLコード
            e.Layout.Bands[0].Columns[COL_BLCD].Hidden = true;
            e.Layout.Bands[0].Columns[COL_BLCDBR].Hidden = true;
            

            // 商品カテゴリ取得
            long category = (long)this.Category_ComboEditor.Value;
            switch (category)
            {
                case 1:
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY2].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY2].Hidden = true;
                    break;
                case 2:
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY2].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY2].Hidden = true;
                    break;
                case 3:
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY2].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY2].Hidden = true;
                    break;
            }

            // 在庫状態 ⇒ 動作設定にて通知するになっている場合は表示
            this.DispChangeStockState(e.Layout.Bands[0].Columns[COL_STOCKSTATE]);

            if (this._bootPara.BootMode == BootMode.SF)
            {
                // 整備工場モードの場合は表示しない
                e.Layout.Bands[0].Columns[COL_GROSS_PM].Hidden = true;
                e.Layout.Bands[0].Columns[COL_GROSSMARGIN_PM].Hidden = true;
                e.Layout.Bands[0].Columns[COL_PM_TITLE].Hidden = true;
                e.Layout.Bands[0].Columns[COL_PURCHASE_COST].Hidden = true;
                e.Layout.Bands[0].Columns[COL_SF_TITLE].Hidden = true;
                e.Layout.Bands[0].Columns[COL_STOCKSTATE].Hidden = true;
            }
          
            // 外観
            e.Layout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;

            // 描画
            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Activation.NoEdit;
                col.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                switch (col.Key)
                {
                    #region カラムを描画
                    case COL_RELEASE: // 公開
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                            col.Header.Caption = COL_RELEASE;
                            col.Width = 80;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.RELEASE;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_RECOMMEND: // オススメ
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                            col.Header.Caption = COL_RECOMMEND;
                            col.Width = 80;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.RECOMMEND;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GOODSNO: // 品番
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_GOODSNO;
                            col.Width = 150;
                            col.MaxLength = 24;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSNO;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_MAKERTITLE: // メーカータイトル
                        {
                            col.Header.Caption = COL_MAKERTITLE;
                            col.RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                            col.RowLayoutColumnInfo.SpanX = 3;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = OriginX.MAKERTITLE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.TabStop = false;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_MAKERCD: // メーカーコード
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_MAKERCD;
                            col.Width = 60;
                            col.MaxLength = 4;
                            col.Format = CT_CODEFORMAT;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.MAKERCD;
                            col.RowLayoutColumnInfo.OriginY = 1;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                         
                            break;
                        }
                    case COL_MAKERGD: // メーカーガイド
                        {
                            col.CellActivation = Activation.NoEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                            col.CellButtonAppearance.Image = this._imgList.Images[0];
                            col.ButtonDisplayStyle = ButtonDisplayStyle.Always;
                            col.Header.Caption = " ";
                            col.Width = 30;
                            col.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                            col.CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.MAKERGD;
                            col.RowLayoutColumnInfo.OriginY = 1;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_MAKERNM: // メーカー名称
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_MAKERNM;
                            col.Width = 150;
                            col.MaxLength = 30;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.MAKERNM;
                            col.RowLayoutColumnInfo.OriginY = 1;

                            break;
                        }
                    case COL_TIRE_KEY1: // タイヤ検索キー１
                        {
                            if (category == 1)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "サイズ";
                                col.Width = 120;
                                col.MaxLength = 32;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TIRE_KEY1;
                                col.RowLayoutColumnInfo.OriginY = 0;


                            }
                            break;
                        }
                    case COL_TIRE_KEY2: // タイヤ検索キー２
                        {
                            if (category == 1)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "スタッドレス";
                                col.Width = 110;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TIRE_KEY2;
                                col.RowLayoutColumnInfo.OriginY = 0;
                                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            }
                            break;
                        }
                    case COL_BATTERY_KEY1: // バッテリ検索キー１
                        {
                            if (category == 2)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "規格";
                                col.Width = 120;
                                col.MaxLength = 32;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.BATTERY_KEY1;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            break;
                        }
                    case COL_BATTERY_KEY2: // バッテリ検索キー２
                        {
                            if (category == 2)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                                col.Header.Caption = "適合";
                                col.Width = 120;

                                Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
                                valueList.ValueListItems.Add("1", "標準車");
                                valueList.ValueListItems.Add("2", "ISS車");
                                valueList.ValueListItems.Add("3", "兼用");
                                col.ValueList = valueList;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.BATTERY_KEY2;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            break;
                        }
                    case COL_OIL_KEY1: // オイル検索キー１
                        {
                            if (category == 3)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "粘度";
                                col.Width = 120;
                                col.MaxLength = 32;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.OIL_KEY1;
                                col.RowLayoutColumnInfo.OriginY = 0;

                            }
                            break;
                        }
                    case COL_OIL_KEY2: // オイル検索キー２
                        {
                            if (category == 3)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                                col.Header.Caption = "適合";
                                col.Width = 120;

                                Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
                                valueList.ValueListItems.Add("1", "ガソリン車");
                                valueList.ValueListItems.Add("2", "ディーゼル車");
                                valueList.ValueListItems.Add("3", "兼用");
                                col.ValueList = valueList;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.OIL_KEY2;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            break;
                        }
                    case COL_IMAGE: // 画像
                        {
                            col.CellActivation = Activation.NoEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                            col.Header.Caption = COL_IMAGE;
                            col.Width = 100;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.IMAGE;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            //col.TabStop = false;
                            break;
                        }
                    case COL_IMAGE_GUIDE: // 画像ガイド
                        {
                            col.CellActivation = Activation.NoEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                            col.CellButtonAppearance.Image = this._imgList.Images[0];
                            col.ButtonDisplayStyle = ButtonDisplayStyle.Always;
                            col.Header.Caption = " ";
                            col.Width = 30;
                            col.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                            col.CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.IMAGE_GD;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }

                    case COL_GOODSNM: // 商品名称
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_GOODSNM;
                            col.Width = 240;
                            col.MaxLength = 60;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSNM;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GOODSNOTE: // 商品説明
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_GOODSNOTE;
                            col.Width = 300;
                            col.MaxLength = 256;
                            col.CellMultiLine = Infragistics.Win.DefaultableBoolean.True; // 複数行入力

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSNOTE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GOODSPR: // 商品PR
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Width = 240;
                            col.MaxLength = 15;
                            col.Header.Caption = "商品見出し";

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSPR;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_RELEASEDATE: // 発売日
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                            col.MinValue = new DateTime(1753, 1, 1);
                            col.MaxValue = new DateTime(9998, 12, 31);
                            col.MaskInput = "yyyy年mm月";
                            col.Header.Caption = COL_RELEASEDATE;
                            col.Width = 110;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.RELEASEDATE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_STOCKCOUNT: // 在庫数
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_STOCKCOUNT;
                            col.MaxLength = 8;
                            col.Format = "#0.00";
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            col.Width = 70;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.STOCKCOUNT;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_STOCKSTATE: // 在庫状態
                        {
                            col.Header.Caption = COL_STOCKSTATE;
                            col.CellActivation = Activation.AllowEdit;
                            col.Width = 80;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;


                            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
                            valueList.ValueListItems.Add("-1"," ");
                            valueList.ValueListItems.Add("1", "○");
                            valueList.ValueListItems.Add("2", "△");
                            valueList.ValueListItems.Add("3", "×");
                            col.ValueList = valueList;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.STOCKSTATE;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_SHOPSALEBEGINDATE: // 公開開始日
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                            col.MinValue = new DateTime(1753, 1, 1);
                            col.MaxValue = new DateTime(9998, 12, 31);
                            col.MaskInput = "yyyy年mm月dd日";
                            col.Header.Caption = COL_SHOPSALEBEGINDATE;
                            col.Width = 130;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SHOPSALEBEGINDATE;
                            col.RowLayoutColumnInfo.OriginY = 0;


                            break;
                        }
                    case COL_SHOPSALEENDDATE: // 公開終了日
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                            col.MinValue = new DateTime(1753, 1, 1);
                            col.MaxValue = new DateTime(9998, 12, 31);
                            col.MaskInput = "yyyy年mm月dd日";
                            col.Header.Caption = COL_SHOPSALEENDDATE;
                            col.Width = 130;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SHOPSALEENDDATE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            break;
                        }
                    case COL_SF_TITLE: // SFタイトル
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                                col.Header.Caption = "整備工場";
                                col.RowLayoutColumnInfo.SpanX = 4 + _repairCount;
                                if (_repairCount > 0)
                                {
                                    col.RowLayoutColumnInfo.SpanX++; // 合計タイトル分
                                }
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = OriginX.SF_TITLE;
                                col.RowLayoutColumnInfo.OriginY = 0;


                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

                                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            }
                            col.TabStop = false;
                            break;
                        }
                    case COL_SUGGEST_PRICE: // 標準価格
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_SUGGEST_PRICE;
                            col.Format = CT_MONEYFORMAT;
                            col.MaxLength = 9;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SUGGEST_PRICE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_SHOP_PRICE: // 店頭価格
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_SHOP_PRICE;
                            col.Format = CT_MONEYFORMAT;
                            col.MaxLength = 9;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SHOPP_PRICE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSS_SF: // 粗利SF 
                        {
                            col.Header.Caption = "粗利";
                            col.Format = CT_MONEYFORMAT;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSS_SF + _repairCount;
                            if (_repairCount > 0)
                            {
                                col.RowLayoutColumnInfo.OriginX++; // 合計タイトル分
                                col.TabIndex++;
                            }
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSS_SF_PM + _repairCount;
                                if (_repairCount > 0)
                                {
                                    col.RowLayoutColumnInfo.OriginX++; // 合計タイトル分
                                }

                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSSMARGIN_SF: // 粗利率SF
                        {
                            col.Header.Caption = "粗利率";
                            col.Format = CT_PARCENTFROMAT;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSSMARGIN_SF + _repairCount;
                            if (_repairCount > 0)
                            {
                                col.RowLayoutColumnInfo.OriginX++; // 合計タイトル分
                                col.TabIndex++;
                            }
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSSMARGIN_SF_PM + _repairCount;
                                if (_repairCount > 0)
                                {
                                    col.RowLayoutColumnInfo.OriginX++; // 合計タイトル分
                                }
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_PM_TITLE: // PMタイトル
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                                col.Header.Caption = "部品商";
                                col.RowLayoutColumnInfo.SpanX = 4;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = OriginX.PM_TITLE + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            col.TabStop = false;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_TRADE_PRICE: // 整備工場モード:仕入原価、部品商モードだと売価
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = "仕入原価";
                            col.Format = CT_MONEYFORMAT;
                            col.MaxLength = 9;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TRADE_PRICE_SF + _repairCount;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = COL_TRADE_PRICE;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TRADE_PRICE_PM + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_PURCHASE_COST: // 仕入原価
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = COL_PURCHASE_COST;
                                col.Format = CT_MONEYFORMAT;
                                col.MaxLength = 9;
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.PURCHASE_COST + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSS_PM: // 粗利PM
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = "粗利";
                                col.Format = CT_MONEYFORMAT;
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSS_PM + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSSMARGIN_PM: // 粗利率PM
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = "粗利率";
                                col.Format = CT_PARCENTFROMAT;
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSSMARGIN_PM + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_INDIVIDUAL: // 得意先別設定
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = COL_INDIVIDUAL;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = OriginX.INDIVIDUAL + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            col.TabStop = false;
                            break;
                        }
                    #endregion
                }
            }

            int count = OriginX.REPAIR;
            List<AttendRepairSet> list = new List<AttendRepairSet>();
            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                list = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];

                for (int i = 0; i < list.Count; i++)
                {
                    string key = "";
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        key = this.MakeAttenRepairKey(list[i].attendRepairId.ToString());
                    }
                    else
                    {
                        key = this.MakeAttenRepairKey(list[i].storeAttendRepairId.ToString());
                    }

                    e.Layout.Bands[0].Columns[key].CellActivation = Activation.AllowEdit;
                    e.Layout.Bands[0].Columns[key].Header.Caption = list[i].repairName;
                    e.Layout.Bands[0].Columns[key].Format = CT_MONEYFORMAT;
                    e.Layout.Bands[0].Columns[key].MaxLength = 9;
                    e.Layout.Bands[0].Columns[key].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    e.Layout.Bands[0].Columns[key].DefaultCellValue = list[i].repairPrice;

                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.SpanX = 1;
                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.SpanY = 2;

                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.OriginY = 0;

                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.SpanY = 1;
                        e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.OriginY = 1;

                        e.Layout.Bands[0].Columns[key].Header.Appearance.BackColor = REPAIR_COLOR1;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.BackColor2 = REPAIR_COLOR2;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.ForeColor = PRPAIR_FORE;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                        e.Layout.Bands[0].Columns[key].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

                    }
                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns[key].TabIndex = count++;

                    e.Layout.Bands[0].Columns[key].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                }
            }

            // 合計列
            if (list.Count > 0)
            {
                // 付随整備あり→合計列を表示
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Hidden = false;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].CellActivation = Activation.NoEdit;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Format = CT_MONEYFORMAT;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.SpanX = 1;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.SpanY = 2;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].TabIndex = OriginX.MONEY_TOTAL + _repairCount;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.OriginY = 0;

                if (this._bootPara.BootMode == BootMode.PM)
                {
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.OriginY = 1;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.SpanY = 1;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.BackColor = REPAIR_COLOR1;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.BackColor2 = REPAIR_COLOR2;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.ForeColor = PRPAIR_FORE;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.FontData.Name = "ＭＳ ゴシック";
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                }

                // キャプション調整
                if (this._bootPara.BootMode == BootMode.SF)
                {
                    #region SFモード + 付随整備有り
                    // ①合計
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Caption = "①" + COL_MONEY_TOTAL;
                    // ②仕入原価
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "②" + COL_PURCHASE_COST;
                    // ③SF粗利
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "③" + "粗利" + "(①-②)";
                    // ④粗利率
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "粗利率" + "(③/①)";

                    #endregion
                }
                else
                {
                    #region PMモード + 付随整備有り
                    // ①合計
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Caption = "①" + "合計";
                    // ②売価
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "②" + COL_TRADE_PRICE;
                    // ③SF粗利
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "③" + "粗利" + "(①-②)";
                    // ④粗利率
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "粗利率" + "(③/①)";

                    // PM側
                    // ⑤仕入原価
                    e.Layout.Bands[0].Columns[COL_PURCHASE_COST].Header.Caption = "⑤" + COL_PURCHASE_COST;
                    // ⑥PM粗利
                    e.Layout.Bands[0].Columns[COL_GROSS_PM].Header.Caption = "⑥" + "粗利" + "(②-⑤)";
                    // ⑦PM粗利率
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_PM].Header.Caption = "粗利率" + "(⑥/②)";
                    #endregion
                }
            }
            else
            {
                // 付随整備なし

                if (this._bootPara.BootMode == BootMode.SF)
                {
                    #region SFモード + 付随整備無し
                    // ①店頭価格
                    e.Layout.Bands[0].Columns[COL_SHOP_PRICE].Header.Caption = "①" + COL_SHOP_PRICE;
                    // ②仕入原価
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "②" + COL_PURCHASE_COST;
                    // ③SF粗利
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "③" + "粗利" + "(①-②)";
                    // ④粗利率
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "粗利率" + "(③/①)";

                    #endregion

                }
                else
                {
                    #region PMモード + 付随整備無
                    // ①店頭価格
                    e.Layout.Bands[0].Columns[COL_SHOP_PRICE].Header.Caption = "①" + COL_SHOP_PRICE;
                    // ②売価
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "②" + COL_TRADE_PRICE;
                    // ③SF粗利
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "③" + "粗利" + "(①-②)";
                    // ④粗利率
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "粗利率" + "(③/①)";

                    // PM側
                    // ⑤仕入原価
                    e.Layout.Bands[0].Columns[COL_PURCHASE_COST].Header.Caption = "⑤" + COL_PURCHASE_COST;
                    // ⑥PM粗利
                    e.Layout.Bands[0].Columns[COL_GROSS_PM].Header.Caption = "⑥" + "粗利" + "(②-⑤)";
                    // ⑦PM粗利率
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_PM].Header.Caption = "粗利率" + "(⑥/②)";

                    #endregion
                }

            }

            // ヘッダーにチェックボックス表示
            this.InitCheckBoxOnColumnHeader();

            // ボタン制御
            this.SetSpButtonEnabled(true);
        }



        /// <summary>
        /// グリッドの Boolean 列の列ヘッダに、チェックボックスを表示します。
        /// </summary>
        private void InitCheckBoxOnColumnHeader()
        {
            // 作成フィルターのインスタンスを作成します。
            TBOCustomFilter filter = new TBOCustomFilter();
            // 列ヘッダ上のチェックボックスがクリックされたときに発生するイベントのハンドラを定義します。
            filter.CheckChanged += new TBOCustomFilter.HeaderCheckBoxClickedHandler(OnHeaderCheckBoxCheckChanged);
            // 作成フィルターをグリッドの CreationFilter プロパティに割り当てます。
            this.Goods_Grid.CreationFilter = filter;
        }

        /// <summary>
        /// グリッドヘッダーチェックボックスクリック時の処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : グリッドヘッダーチェックボックスクリックされた時に、処理を行います。</br>
        /// </remarks>
        internal void OnHeaderCheckBoxCheckChanged(object sender, TBOCustomFilter.HeaderCheckBoxEventArgs e)
        {
            this.UpDateGrid();
        }

        /// <summary>
        /// 在庫状態カラム表示切替
        /// </summary>
        /// <param name="ultraGridColumn"></param>
        private void DispChangeStockState(UltraGridColumn ultraGridColumn)
        {
            if (this._settingsDic.ContainsKey(this.Section_ComboEditor.Value.ToString()))
            {
                if (this._settingsDic[this.Section_ComboEditor.Value.ToString()].stockDisplayFlag)
                {
                    // 通知する
                    ultraGridColumn.Hidden = false;
                }
                else
                {
                    // 通知しない
                    ultraGridColumn.Hidden = true;
                }
            }
            else
            {
                // 設定なし
                ultraGridColumn.Hidden = true;
            }
        }

        #endregion

        #region KeyPress
        /// <summary>
        /// Grid KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Goods_Grid.ActiveCell;

                switch (cell.Column.Key)
                {
                    case COL_MAKERCD:
                        if (this.Goods_Grid.ActiveCell.Activation == Activation.AllowEdit && this.Goods_Grid.ActiveCell.IsInEditMode)
                        {
                            e.Handled = !KeyPressCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false);
                        }
                        break;
                    case COL_SUGGEST_PRICE:
                    case COL_SHOP_PRICE:
                    case COL_TRADE_PRICE:
                    case COL_PURCHASE_COST:
                        if (this.Goods_Grid.ActiveCell.Activation == Activation.AllowEdit && this.Goods_Grid.ActiveCell.IsInEditMode)
                        {
                            if (!KeyPressCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
                // 付随整備
                if (this._attendRepairColDic.ContainsKey((long)this.Category_ComboEditor.Value))
                {
                    if (this._attendRepairColDic[(long)this.Category_ComboEditor.Value].Contains(cell.Column.Key))
                    {
                        if (this.Goods_Grid.ActiveCell.Activation == Activation.AllowEdit && this.Goods_Grid.ActiveCell.IsInEditMode)
                        {
                            if (!KeyPressCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region AfterSelectChange
        /// <summary>
        /// グリッド選択状態変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // ボタン制御
            this.SetRowDelEnabled();
        }
        #endregion

        #region InitializeRow
        /// <summary>
        /// Goods_Grid_InitializeRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Cells[COL_POSTPARACLASS].Value == DBNull.Value)
            {
                e.Row.Cells[COL_GOODSNO].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_MAKERCD].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_MAKERGD].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_MAKERNM].Activation = Activation.AllowEdit;
            }
            else
            {
                e.Row.Cells[COL_GOODSNO].Activation = Activation.NoEdit;
                e.Row.Cells[COL_MAKERCD].Activation = Activation.NoEdit;
                e.Row.Cells[COL_MAKERGD].Activation = Activation.Disabled;
                e.Row.Cells[COL_MAKERNM].Activation = Activation.NoEdit;

                e.Row.Cells[COL_GOODSNO].Appearance.BackColor = READONLY_CELL_COLOR;
                e.Row.Cells[COL_MAKERCD].Appearance.BackColor = READONLY_CELL_COLOR;
                e.Row.Cells[COL_MAKERGD].Appearance.BackColor = READONLY_CELL_COLOR;
                e.Row.Cells[COL_MAKERNM].Appearance.BackColor = READONLY_CELL_COLOR;
            }
            e.Row.Cells[COL_GROSS_SF].Appearance.BackColor = READONLY_CELL_COLOR;
            e.Row.Cells[COL_GROSS_PM].Appearance.BackColor = READONLY_CELL_COLOR;
            e.Row.Cells[COL_GROSSMARGIN_PM].Appearance.BackColor = READONLY_CELL_COLOR;
            e.Row.Cells[COL_GROSSMARGIN_SF].Appearance.BackColor = READONLY_CELL_COLOR;

            e.Row.Cells[COL_MONEY_TOTAL].Appearance.BackColor = READONLY_CELL_COLOR;

        }
        #endregion

        #region KeyDown
        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // 編集中であった場合
            if (this.Goods_Grid.ActiveCell != null)
            {
                // アクティブセル
                UltraGridCell activeCell = this.Goods_Grid.ActiveCell;

                // セルのスタイルにて判定
                switch (activeCell.StyleResolved)
                {
                    // テキストボックス・テキストボックス(ボタン付)
                    case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                        switch (e.KeyData)
                        {
                            // ←キー
                            case Keys.Left:
                                if (activeCell.IsInEditMode && activeCell.SelStart == 0)
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                    e.Handled = true;
                                }
                                else if (!activeCell.IsInEditMode)
                                {
                                    UltraGridCell prevCell = GetPrevCell(activeCell);
                                    if (prevCell != null)
                                    {
                                        prevCell.Activate();
                                        prevCell.Selected = true;
                                        if (prevCell.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    else
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                    }
                                    e.Handled = true;
                                }
                                break;
                            // →キー
                            case Keys.Right:
                                if (activeCell.IsInEditMode && (activeCell.SelStart >= activeCell.Text.Length))
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                    e.Handled = true;
                                }
                                else if (!activeCell.IsInEditMode)
                                {
                                    UltraGridCell nextCell = GetNextCell(activeCell);
                                    if (nextCell != null)
                                    {
                                        nextCell.Activate();
                                        nextCell.Selected = true;
                                        if (nextCell.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    else
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                    }
                                    e.Handled = true;
                                }
                                break;
                            // ↑キー
                            case Keys.Up:
                                if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];

                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                            // ↓キー
                            case Keys.Down:
                                if (activeCell.Row.HasNextSibling())
                                {
                                    UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                    UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                    if (belowCel != null)
                                    {
                                        belowCel.Activate();
                                        belowCel.Selected = true;
                                        if (belowCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                e.Handled = true;
                                break;
                        }

                        // 改行
                        if (e.KeyCode == Keys.Enter && e.Alt)
                        {
                            if (this.Goods_Grid.ActiveCell != null && (this.Goods_Grid.ActiveCell.Column.Key == COL_GOODSNOTE))
                            {
                                // 改行
                                try
                                {
                                    int index = this.Goods_Grid.ActiveCell.SelStart;
                                    string insertVal = this.Goods_Grid.ActiveCell.Text;
                                    int length = insertVal.Length;
                                    if (length + 2 <= this.Goods_Grid.ActiveCell.Column.MaxLength)
                                    {
                                        string wk = insertVal.Insert(index, Environment.NewLine);
                                        this.Goods_Grid.ActiveCell.Value = wk;
                                        this.Goods_Grid.ActiveCell.SelStart = index + 2;  // rn分
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                        break;
                    case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:  // ドロップダウン
                        switch (e.KeyData)
                        {
                            // ←キー
                            case Keys.Left:
                                this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                                break;
                            // →キー
                            case Keys.Right:
                                this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                                break;
                            // ↓キー
                            case Keys.Down:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else if (activeCell.Row.HasNextSibling())
                                {
                                    UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                    UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                    if (belowCel != null)
                                    {
                                        belowCel.Activate();
                                        belowCel.Selected = true;
                                        if (belowCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                e.Handled = true;
                                break;
                            // ↑キー 
                            case Keys.Up:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                        }
                        break;
                    case Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime:  // 日付
                        switch (e.KeyData)
                        {
                            // ←キー
                            case Keys.Left:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                                e.Handled = true;
                                break;
                            // →キー
                            case Keys.Right:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                }
                                e.Handled = true;
                                break;
                            // ↓キー
                            case Keys.Down:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else if (activeCell.Row.HasNextSibling())
                                {
                                    UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                    UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                    if (belowCel != null)
                                    {
                                        belowCel.Activate();
                                        belowCel.Selected = true;
                                        if (belowCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                e.Handled = true;
                                break;
                            // ↑キー 
                            case Keys.Up:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                        }
                        break;
                    // 上記以外のスタイル チェックボックスなど
                    default:
                        switch (e.KeyData)
                        {
                            // ←キー
                            case Keys.Left:
                                // 最初のセル
                                if (activeCell.Column.Key == COL_RELEASE)
                                {
                                    if (activeCell.Row.HasPrevSibling())
                                    {
                                        UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                        UltraGridCell prevCel = null;
                                        if (this._bootPara.BootMode == BootMode.PM)
                                        {
                                            prevCel = prevRow.Cells[COL_GROSSMARGIN_PM];
                                        }
                                        else
                                        {
                                            prevCel = prevRow.Cells[COL_GROSSMARGIN_SF];
                                        }

                                        if (prevCel != null)
                                        {
                                            prevCel.Activate();
                                            prevCel.Selected = true;
                                            if (prevCel.Activation == Activation.AllowEdit)
                                            {
                                                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                                e.Handled = true;
                                break;
                            // →キー
                            case Keys.Right:
                                // 最終セル
                                if (activeCell.Column.Key == COL_GROSSMARGIN_PM)
                                {
                                    if (activeCell.Row.HasNextSibling())
                                    {
                                        UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                        UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];

                                        if (nextCel != null)
                                        {
                                            nextCel.Activate();
                                            nextCel.Selected = true;
                                            if (nextCel.Activation == Activation.AllowEdit)
                                            {
                                                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                        }
                                    }
                                }
                                else if (activeCell != null && activeCell.Column.Key == COL_GROSSMARGIN_SF)
                                {
                                    if (this._bootPara.BootMode == BootMode.SF)
                                    {
                                        if (activeCell.Row.HasNextSibling())
                                        {
                                            UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                            UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];
                                            if (nextCel != null)
                                            {
                                                nextCel.Activate();
                                                nextCel.Selected = true;
                                                if (nextCel.Activation == Activation.AllowEdit)
                                                {
                                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                    }
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                }
                                e.Handled = true;
                                break;
                            case Keys.Up:
                                if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                            // ↓キー
                            case Keys.Down:
                                if (activeCell.Row.HasNextSibling())
                                {
                                    UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                    UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                    belowCel.Activate();
                                    belowCel.Selected = true;
                                    if (belowCel.Activation == Activation.AllowEdit)
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                e.Handled = true;
                                break;
                            case Keys.Space:
                                if (activeCell.Activation != Activation.Disabled)
                                {
                                    if (activeCell.Column.Key == COL_MAKERGD)
                                    {
                                        // メーカーガイド
                                        this.ShowMakerGuide(activeCell.Row.Index);
                                    }
                                    else if (activeCell.Column.Key == COL_IMAGE_GUIDE)
                                    {
                                        // 画像ガイド
                                        this.ShowImageGuide(activeCell.Row.Index);
                                    }
                                    else if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
                                    {
                                        activeCell.Value = !((bool)activeCell.Value);
                                    }
                                }
                                e.Handled = true;
                                break;
                        }
                        break;
                }
            }

            // 行コピー、貼り付け
            if (this.Goods_Grid.Selected.Rows != null && this.Goods_Grid.Selected.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.C && e.Control)
                {
                    // コピー
                    this.ROW_COPY_Click(this.Goods_Grid, new EventArgs());
                }
                else if (e.KeyCode == Keys.V && e.Control)
                {
                    // 貼り付け
                    this.ROW_PAST_Click(this.Goods_Grid, new EventArgs());
                }
                else if (e.KeyCode == Keys.A && e.Control)
                {
                    // 全選択
                    foreach (UltraGridRow row in this.Goods_Grid.Rows)
                    {
                        if (!row.IsFilteredOut)
                        {
                            row.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region CellChange
        /// <summary>
        /// Goods_Grid_CellChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            string columnKey = e.Cell.Column.Key;
            if (columnKey == COL_RELEASE)
            {
                if (this.Goods_Grid.ActiveRow.Cells[COL_RELEASE].Text == "True")
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RELEASE].Value = true;
                }
                else
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RELEASE].Value = false;
                }
            }
            else if (columnKey == COL_RECOMMEND)
            {
                if (this.Goods_Grid.ActiveRow.Cells[COL_RECOMMEND].Text == "True")
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RECOMMEND].Value = true;
                }
                else
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RECOMMEND].Value = false;
                }
            }
            else if (columnKey == COL_TIRE_KEY2)
            {
                if (this.Goods_Grid.ActiveRow.Cells[COL_TIRE_KEY2].Text == "True")
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_TIRE_KEY2].Value = true;
                }
                else
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_TIRE_KEY2].Value = false;
                }
            }

            // 現在のアクティブセルのスタイルがEdit or Default の場合
            if ((this.Goods_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                (this.Goods_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default))
            {
                // 変更された結果、Textが空白となった場合
                if ((this.Goods_Grid.ActiveCell.Text == null) || ((this.Goods_Grid.ActiveCell.Text != null) && (this.Goods_Grid.ActiveCell.Text.Trim() == "")))
                {
                    // 現在のセルの型が、Int32、Int64、double型の場合
                    if ((this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                        (this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                        (this.Goods_Grid.ActiveCell.Column.DataType == typeof(double)))
                    {
                        // 値を空白とはせずに、"0"をセットする
                        this.Goods_Grid.ActiveCell.Value = 0;
                        return;
                    }
                }
            }
        }
        #endregion

        #region AfterEnterEditMode
        /// <summary>
        /// Goods_Grid_AfterEnterEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // 編集モードになったら選択状態
            this.Goods_Grid.ActiveCell.SelectAll();
        }
        #endregion

        #region CellDataError
        /// <summary>
        /// 入力エラー時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                CellDataErrorProc();
                e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                e.StayInEditMode = false;			// 編集モードは抜ける
            }
        }
        #endregion

        #region AfterCellActivate
        /// <summary>
        /// AfterCellActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_AfterCellActivate(object sender, EventArgs e)
        {
            //非アクティブ時比較用にバッファリング
            this._tempCell = this.Goods_Grid.ActiveCell;
            if (this._tempCell != null)
            {
                this._tempValue = this._tempCell.Value;
            }
            else
            {
                this._tempValue = null;
            }
            // IME制御
            this.Goods_Grid.ImeMode = ImeMode.Off;
            if (this.Goods_Grid.ActiveCell.Row.GetCellActivationResolved(this.Goods_Grid.ActiveCell.Column) != Activation.Disabled)
            {
                switch (this.Goods_Grid.ActiveCell.Column.Key)
                {
                    case COL_GOODSNOTE:
                    case COL_GOODSPR:
                    case COL_MAKERNM:
                        {
                            this.Goods_Grid.ImeMode = ImeMode.Hiragana;
                            break;
                        }
                    case COL_GOODSNO:
                        {
                            this.Goods_Grid.ImeMode = ImeMode.Disable;
                            break;
                        }
                }
                if (this.Goods_Grid.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion

        #region BeforeExitEditMode
        /// <summary>
        /// BeforeExitEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            try
            {
                // AfterCellActivateイベントで捕捉したセルであるか？
                if ((this.Goods_Grid.ActiveCell != null) && (this._tempCell == this.Goods_Grid.ActiveCell))
                {
                    // コピペ対応
                    if (this.Goods_Grid.ActiveCell.Column.DataType == typeof(int) && this.Goods_Grid.ActiveCell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        Convert.ToInt32(this.Goods_Grid.ActiveCell.Text);
                    else if (this.Goods_Grid.ActiveCell.Column.DataType == typeof(long))
                        //Convert.ToInt64(this.Goods_Grid.ActiveCell.Text);
                        Convert.ToInt64(this.Goods_Grid.ActiveCell.Value);
                    else if (this.Goods_Grid.ActiveCell.Column.DataType == typeof(double))
                        Convert.ToDouble(this.Goods_Grid.ActiveCell.Text);

                    //グリッドのアップデート
                    this.Goods_Grid.UpdateData();
                    //データテーブルへの変更をコミット
                    this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                    //描画をとめる
                    this.Goods_Grid.BeginUpdate();

                    // 値に変更があった？
                    if (this.Goods_Grid.ActiveCell.Value.ToString() != this._tempValue.ToString())
                    {
                        int index = GetActiveIndex();

                        long shopPrice = GetCellLong(this.Goods_Grid.Rows[index].Cells[COL_SHOP_PRICE].Value, 0);      // 店頭価格
                        long repareTotal = CalcRepareTotal(index);                                                      // 付随整備合計金額
                        long tradePrice = GetCellLong(this.Goods_Grid.Rows[index].Cells[COL_TRADE_PRICE].Value, 0);     // 卸値
                        long cost = GetCellLong(this.Goods_Grid.Rows[index].Cells[COL_PURCHASE_COST].Value, 0);         // 仕入原価
                        long grossSF = 0;
                        string grossMarginSF = "";
                        long grossPM = 0;
                        string grossMarginPM = "";

                        if (this.Goods_Grid.ActiveCell.Column.Key.Contains(COL_REPARE))
                        {
                            // 付随整備カラム
                            // 整備工場の粗利を再計算
                            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
                            // 計算結果を展開
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_SF].Value = grossSF;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_SF].Value = grossMarginSF;

                            // 合計金額も計算
                            this.Goods_Grid.Rows[index].Cells[COL_MONEY_TOTAL].Value = shopPrice + repareTotal;
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_SHOP_PRICE)   // 店頭価格
                        {
                            // 整備工場の粗利を再計算
                            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
                            // 計算結果を展開
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_SF].Value = grossSF;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_SF].Value = grossMarginSF;

                            // 合計金額も計算
                            this.Goods_Grid.Rows[index].Cells[COL_MONEY_TOTAL].Value = shopPrice + repareTotal;
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_TRADE_PRICE)    // 卸値
                        {
                            // 両方の粗利を再計算

                            // 整備工場の粗利を再計算
                            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
                            // 計算結果を展開
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_SF].Value = grossSF;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_SF].Value = grossMarginSF;

                            // 部品商の粗利を再計算
                            this.CalcGrossPM(tradePrice, cost, out grossPM, out grossMarginPM);
                            // 計算結果を展開
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_PM].Value = grossPM;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_PM].Value = grossMarginPM;

                            // 合計金額も計算
                            this.Goods_Grid.Rows[index].Cells[COL_MONEY_TOTAL].Value = shopPrice + repareTotal;

                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_PURCHASE_COST)   //　仕入原価
                        {
                            // 部品商の粗利を再計算
                            this.CalcGrossPM(tradePrice, cost, out grossPM, out grossMarginPM);
                            // 計算結果を展開
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_PM].Value = grossPM;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_PM].Value = grossMarginPM;
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_MAKERCD) // メーカーCD
                        {
                            int mkCd = GetCellInt32(this.Goods_Grid.ActiveCell.Value, 0);

                            if (this._makerCdDic.ContainsKey(mkCd))
                            {
                                this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERNM].Value = this._makerCdDic[mkCd].MakerName;
                            }
                            else
                            {
                                if (GetCellInt32(this.Goods_Grid.ActiveCell.Value, 0) == 0)
                                {
                                    this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERNM].Value = "";
                                }
                                else if (this._tempValue != null)
                                {
                                    // 元に戻す
                                    this.Goods_Grid.ActiveCell.Value = this._tempValue;
                                }
                            }
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_MAKERNM) // メーカー名称
                        {
                            if (GetCellInt32(this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERCD].Value, 0) != 0)
                            {
                                // 元に戻す
                                this.Goods_Grid.ActiveCell.Value = this._tempValue;
                            }
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_SHOPSALEBEGINDATE) // 公開開始日
                        {
                            if (this.Goods_Grid.ActiveCell.Row.Cells[COL_SHOPSALEBEGINDATE].Value == DBNull.Value)
                            {
                                // 元に戻す
                                this.Goods_Grid.ActiveCell.Value = this._tempValue;
                            }
                        }
                    }
                }
            }
            catch
            {
                if (this.Goods_Grid.ActiveCell != null)
                {
                    //セル更新エラー時処理
                    CellDataErrorProc();
                }
            }
            finally
            {
                this.Goods_Grid.EndUpdate();
                //データテーブルへの変更をコミット
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
            }
        }
        #endregion

        #endregion

        #region ComboEditor
        /// <summary>
        /// 拠点コンボValueChangeイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Section_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //if (this._bootPara.BootMode == BootMode.PM)
            //{
            //    string sectionCode = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value.ToString();

            //    // 部品商モードの場合、拠点変更時に公開先も変更する。　拠点を気軽に変更されると困るので、あくまで抽出ってしたら、切り替わるほうがいいかも

            //    // TODO 一旦チェック外す
            //    //if (this._scmSceDic.Count == 0)
            //    //{
            //    //    MessageBox.Show("有効な公開先がありません。");
            //    //}
            //    //else
            //    //{
            //    //    if (this._scmSceDic.ContainsKey(sectionCode))
            //    //    {
            //    //        this.MakeCustomerTree(this._scmSceDic[sectionCode]);
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("有効な公開先がありません。");
            //    //    }
            //    //}
            //}
        }
        #endregion

        #region Button
        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_toolStripButton_Click(object sender, EventArgs e)
        {
            // 終了
            this.Close();
        }

        /// <summary>
        /// 行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Del_button_Click(object sender, EventArgs e)
        {
            // とりあえずは論理削除として、更新時に全部消す

            if (this.Goods_Grid.Selected.Rows.Count > 0)
            {
                DialogResult ret
                    = TMsgDisp.Show(
                       this,								// 親ウィンドウフォーム
                       emErrorLevel.ERR_LEVEL_QUESTION,	    // エラーレベル
                       CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                       "選択行を削除しますか？",			// 表示するメッセージ 
                       0,								    // ステータス値
                       MessageBoxButtons.YesNo);

                if (ret == DialogResult.Yes)
                {
                    foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                    {
                        // 保存済行
                        row.Cells[COL_DEL].Value = 1;
                    }
                }

                DataView dtView = this.TBODataSet.Tables[TABLE_MAIN].DefaultView;

                // フィルター掛けてみる
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();

                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// 行追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRow_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Goods_Grid.BeginUpdate();

                // 行フィルタは強制解除
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_MAKERNM].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_OIL_KEY1].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_TIRE_KEY1].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_BATTERY_KEY1].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_SHOPSALEBEGINDATE].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_SHOPSALEENDDATE].FilterConditions.Clear();

                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();

                row[COL_DEL] = 0;               // 論理削除区分
                row[COL_RELEASE] = true;        // 公開フラグ
                row[COL_RECOMMEND] = false;     // オススメフラグ
                row[COL_TIRE_KEY2] = false;
                row[COL_BATTERY_KEY2] = 1;
                row[COL_OIL_KEY2] = 1;
                row[COL_STOCKSTATE] = -1;

                // 行の粗利を計算
                this.CalcGrossProc(ref row);

                this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(row);

                UltraGridRow ugRow = this.Goods_Grid.GetRow(ChildRow.Last);
                if (ugRow != null)
                {
                    UltraGridCell cell = ugRow.Cells[COL_RELEASE];
                    this.Goods_Grid.Focus();
                    cell.Row.Cells[COL_RELEASE].Activate();
                    cell.Selected = true;
                    cell.Activate();
                }

            }
            finally
            {
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// 行の粗利を計算
        /// </summary>
        /// <param name="row"></param>
        private void CalcGrossProc(ref DataRow row)
        {
            // 粗利計算
            long shopPrice = GetCellLong(row[COL_SHOP_PRICE], 0);                  // 店頭価格
            long repareTotal = 0;                                                   // 付随整備合計金額
            foreach (DataColumn col in this.TBODataSet.Tables[TABLE_MAIN].Columns)
            {
                if (col.ColumnName.Contains(COL_REPARE))
                {
                    repareTotal += (long)row[col.ColumnName];
                }
            }

            long tradePrice = GetCellLong(row[COL_TRADE_PRICE], 0);     // 卸値
            long cost = GetCellLong(row[COL_PURCHASE_COST], 0);         // 仕入原価
            long grossSF = 0;
            string grossMarginSF = "";
            long grossPM = 0;
            string grossMarginPM = "";

            // 両方の粗利を再計算

            // 整備工場の粗利を再計算
            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
            // 計算結果を展開
            row[COL_GROSS_SF] = grossSF;
            row[COL_GROSSMARGIN_SF] = grossMarginSF;

            // 部品商の粗利を再計算
            this.CalcGrossPM(tradePrice, cost, out grossPM, out grossMarginPM);
            // 計算結果を展開
            row[COL_GROSS_PM] = grossPM;
            row[COL_GROSSMARGIN_PM] = grossMarginPM;

            // 合計金額も計算
            row[COL_MONEY_TOTAL] = shopPrice + repareTotal;
        }

      
        /// <summary>
        /// 簡易オススメ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recommend_button_Click(object sender, EventArgs e)
        {
            RecommendForm form = new RecommendForm();
            form.Icon = this.Icon;

            DialogResult ret = form.ShowRecomendForm(this._bootPara.BootMode, (long)this.Category_ComboEditor.Value, this.Category_ComboEditor.Text);
            if (ret == DialogResult.OK)
            {
                // オススメ設定
                this.SetRecommend(form._count, form._target);
            }
        }

        #endregion

        #region RetKeyControl
        /// <summary>
        /// RetKey_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

            //キー制御         
            switch (e.PrevCtrl.Name)
            {
                case "Goods_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;

                                    //シフトキーが押されているか？
                                    if (e.ShiftKey)
                                    {
                                        // 最初のセル
                                        if (this.Goods_Grid.ActiveCell != null && this.Goods_Grid.ActiveCell.Column.Key == COL_RELEASE)
                                        {
                                            if (this.Goods_Grid.ActiveCell.Row.HasPrevSibling())
                                            {
                                                UltraGridRow prevRow = this.Goods_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                UltraGridCell prevCel = null;
                                                if (this._bootPara.BootMode == BootMode.PM)
                                                {
                                                    prevCel = prevRow.Cells[COL_GROSSMARGIN_PM];
                                                }
                                                else
                                                {
                                                    prevCel = prevRow.Cells[COL_GROSSMARGIN_SF];
                                                }
                                                if (prevCel != null)
                                                {
                                                    prevCel.Activate();
                                                    prevCel.Selected = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                        }
                                    }
                                    else
                                    {
                                        // 最終セル
                                        if (this.Goods_Grid.ActiveCell != null && this.Goods_Grid.ActiveCell.Column.Key == COL_GROSSMARGIN_PM)
                                        {
                                            if (this.Goods_Grid.ActiveCell.Row.HasNextSibling())
                                            {
                                                UltraGridRow nextRow = this.Goods_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];
                                                if (nextCel != null)
                                                {
                                                    nextCel.Activate();
                                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                            }
                                        }
                                        else if (this.Goods_Grid.ActiveCell != null && this.Goods_Grid.ActiveCell.Column.Key == COL_GROSSMARGIN_SF)
                                        {
                                            if (this._bootPara.BootMode == BootMode.SF)
                                            {
                                                if (this.Goods_Grid.ActiveCell.Row.HasNextSibling())
                                                {
                                                    UltraGridRow nextRow = this.Goods_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                    UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];
                                                    if (nextCel != null)
                                                    {
                                                        nextCel.Activate();
                                                        this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                            }
                                        }
                                        else
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                        }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        #endregion

        #region ToolStrip

        #region 抽出
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_button_Click(object sender, EventArgs e)
        {
            //ピロピロ表示
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、商品データを抽出中です。";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                // ダイアログ表示
                form.Show();

                int st = 0;
                string errMsg = "";
                List<ProposeGoods> retList = new List<ProposeGoods>();
                st = this.SearchGoodsProc(out retList, out errMsg);

                if (st == 0)
                {
                    // データを反映
                    this.SetDataTable(retList);
                    this.Section_ComboEditor.Enabled = false;
                    this.Search_button.Enabled = false;
                    this.Category_ComboEditor.Enabled = false;
                }
                else
                {
                    TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                            errMsg,			                    // 表示するメッセージ 
                            st,								    // ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                }
            }
            finally
            {
                form.Close();
                this.Cursor = Cursors.Default;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// 商品検索処理
        /// </summary>
        private int SearchGoodsProc(out  List<ProposeGoods> retList, out string errMsg)
        {
            errMsg = "";
            int st = 0;
            retList = new List<ProposeGoods>();
            errMsg = "";

            // 整備工場モードの場合は拠点別なので、商品情報取得時に付随整備情報も取得する
            if (this._bootPara.BootMode == BootMode.SF)
            {
                st = this.SetAttendRepairSet_ModeSF(out errMsg);
                if (st != 0)
                {
                    return st;
                }
            }

            st = this._TBOServiceACS.GetProposegoods(this._bootPara.EnterpriseCode, this.Section_ComboEditor.Value.ToString(), (long)this.Category_ComboEditor.Value, out retList, out errMsg);
            return st;
        }
        #endregion

        #region クリア
        /// <summary>
        /// クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_toolStripButton_Click(object sender, EventArgs e)
        {
            // 更新チェック
            if (this.CheckUpDate())
            {
                if (this.Goods_Grid.DataSource != null)
                {
                    this.Goods_Grid.BeginUpdate();
                    this.Goods_Grid.DataSource = null;
                    this.TBODataSet.Tables[TABLE_MAIN].Rows.Clear();
                    this.Goods_Grid.EndUpdate();
                    this.UpDateGrid();
                    this.Section_ComboEditor.Enabled = true;
                    this.Del_button.Enabled = false;
                    this.Category_ComboEditor.Enabled = true;
                    this.Search_button.Enabled = true;
                    this.SetSpButtonEnabled(false);
                    this._copyBufferList.Clear();
                    this.Goods_Grid.EndUpdate();
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.SaveProc();
            this.UpDateGrid();
        }
        #endregion


        #endregion

        #endregion
       
        #region internal Class

        /// <summary>
        /// ブートモードクラス
        /// </summary>
        internal class BootMode
        {
            public const int PM = 1;    //部品商モード
            public const int SF = 2;    //整備工場モード
        }

        /// <summary>
        /// グリッドカラム ポジション
        /// </summary>
        internal class OriginX
        {
            public const int RELEASE = 0;           //公開
            public const int RECOMMEND = 1;         //オススメ
            public const int GOODSNO = 2;           //品番
            public const int MAKERTITLE = 10;       //メーカータイトル
            public const int MAKERCD = 10;          //メーカーコード
            public const int MAKERGD = 11;          //メーカーガイド
            public const int MAKERNM = 12;          //メーカー名称
            public const int TIRE_KEY1 = 26;        //タイヤ検索キー１
            public const int TIRE_KEY2 = 27;        //タイヤ検索キー２
            public const int BATTERY_KEY1 = 26;     //バッテリ検索キー１
            public const int BATTERY_KEY2 = 27;     //バッテリ検索キー２
            public const int OIL_KEY1 = 26;         //オイル検索キー１
            public const int OIL_KEY2 = 27;         //オイル検索キー２
            public const int IMAGE_NO = 40;         //画像№
            public const int IMAGE = 41;            //画像      
            public const int IMAGE_GD = 42;         //画像ガイド      
            public const int GOODSNM = 50;         //商品名称
            public const int GOODSNOTE = 51;       //商品説明 
            public const int GOODSPR = 52;         //商品PR
            public const int RELEASEDATE = 53;     //発売日
            public const int SHOPSALEBEGINDATE = 54;    //公開開始日
            public const int SHOPSALEENDDATE = 55;      //公開終了日
            public const int STOCKCOUNT = 57;      //在庫数
            public const int STOCKSTATE = 58;      //在庫状態

            public const int SF_TITLE = 86;             //SFタイトル
            public const int SUGGEST_PRICE = 86;        //標準価格
            public const int SHOPP_PRICE = 87;          //店頭価格
            public const int REPAIR = 88;              // 付随整備
            public const int MONEY_TOTAL = 88;         // 店頭価格＋付随整備
            //public const int GROSS_SF_PM = 89;          //SF粗利(部品商モード)
            //public const int GROSSMARGIN_SF_PM = 90;    //粗利率SF(部品商モード)

            public const int GROSS_SF_PM = 88;          //SF粗利(部品商モード)
            public const int GROSSMARGIN_SF_PM = 89;    //粗利率SF(部品商モード)
            
            public const int PM_TITLE = 100;             //PMタイトル
            public const int TRADE_PRICE_PM = 100;       //(部品商:販売価格)
            public const int PURCHASE_COST = 101;        //仕入原価
            public const int GROSS_PM = 102;             //粗利PM
            public const int GROSSMARGIN_PM = 103;       //粗利率PM
            public const int INDIVIDUAL = 104;         //個別設定PM


            public const int TRADE_PRICE_SF = 89;      //(整備工場：仕入原価)
            public const int GROSS_SF = 90;            //SF粗利(整備工場モード)
            public const int GROSSMARGIN_SF = 91;      //粗利率SF(整備工場モード)
        }

        #endregion

        /// <summary>
        /// 画像設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 更新チェック
            if (this.CheckUpDate())
            {
                GoodsImageForm form = new GoodsImageForm();
                form._enterPriseCode = this._bootPara.EnterpriseCode;
                form._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                form._goodsCategoryList = this._categoryList;
                form._mode = 0;
                form.Icon = this.Icon;
                form.ShowGoodsImageFrom();

                if (form._saveDiv)
                {
                    // 再読込
                    if (this.Category_ComboEditor.Enabled == false)
                    {
                        this.Search_button_Click(this, new EventArgs());
                    }

                    if (this._imageGuide != null)
                    {
                        this._imageGuide._dataReadFlag = true;
                    }
                }
            }
        }

        /// <summary>
        /// 商品画像設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImageSet_Button_Click(object sender, EventArgs e)
        {
            // 更新チェック
            if (this.CheckUpDate())
            {
                GoodsImageForm form = new GoodsImageForm();
                form._enterPriseCode = this._bootPara.EnterpriseCode;
                form._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                form._goodsCategoryList = this._categoryList;
                form._mode = 0;
                form.Icon = this.Icon;
                form.ShowGoodsImageFrom();

                if (form._saveDiv)
                {
                    // 再読込
                    if (this.Category_ComboEditor.Enabled == false)
                    {
                        this.Search_button_Click(this, new EventArgs());
                    }

                    if (this._imageGuide != null)
                    {
                        this._imageGuide._dataReadFlag = true;
                    }
                }
            }
        }


        /// <summary>
        /// 動作設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OthreSetting_Button_Click(object sender, EventArgs e)
        {
            OthreSettingForm form = new OthreSettingForm();
            form.Icon = this.Icon;
            form._enterpirseCode = this._bootPara.EnterpriseCode;
            form._sectionCode = this.Section_ComboEditor.Value.ToString();
            form._sectionList = this._bootPara.Propose_Para_Section;
            form._settingsDic = this._settingsDic;
            form.ShowOtherSettinfForm();

            // データが更新されている
            if (form._saveFlag)
            {
                // 動作設定再取得
                this.GetSettings();

                // グリッド切替
                if (this.Goods_Grid.DataSource != null)
                {
                    this.DispChangeStockState(this.Goods_Grid.DisplayLayout.Bands[0].Columns[COL_STOCKSTATE]);
                }
            }

        }

        /// <summary>
        /// グリッドボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            // 画像ガイド
            if (e.Cell.Column.Key == COL_IMAGE_GUIDE)
            {
                this.ShowImageGuide(e.Cell.Row.Index);
            }
            // メーカーガイド
            else if (e.Cell.Column.Key == COL_MAKERGD)
            {
                this.ShowMakerGuide(e.Cell.Row.Index);
            }
        }

        /// <summary>
        /// メーカーガイド起動
        /// </summary>
        /// <param name="p"></param>
        private void ShowMakerGuide(int index)
        {
            MakerGuide guide = new MakerGuide();
            guide.Icon = this.Icon;
            guide._makerList = this._bootPara.Propose_Para_Maker;
            DialogResult ret = guide.ShowMakerGuide();
            if (ret == DialogResult.OK)
            {
                this.Goods_Grid.Rows[index].Cells[COL_MAKERCD].Value = guide._makerCode;
                this.Goods_Grid.Rows[index].Cells[COL_MAKERNM].Value = guide._makerName;
            }
        }

        /// <summary>
        /// 画像ガイド起動
        /// </summary>
        private void ShowImageGuide(int index)
        {
            if(this._imageGuide == null) 
            {
                this._imageGuide = new GoodsImageForm();
                this._imageGuide._dataReadFlag = true;
                this._imageGuide._mode = 1;
                this._imageGuide.Icon = this.Icon;

            }
            this._imageGuide._enterPriseCode = this._bootPara.EnterpriseCode;
            this._imageGuide._goodsCategoryId = (long)this.Category_ComboEditor.Value;
            this._imageGuide._goodsCategoryList = this._categoryList;
            this._imageGuide._imageID = 0;
            this._imageGuide._goodsImage = null;

            DialogResult ret = this._imageGuide.ShowGoodsImageFrom();
            if (ret == DialogResult.OK)
            {
                this.Goods_Grid.Rows[index].Cells[COL_IMAGE_NO].Value = this._imageGuide._imageID;
                this.Goods_Grid.Rows[index].Cells[COL_IMAGE].Value = this._imageGuide._goodsImage;
                this.Goods_Grid.Rows[index].Cells[COL_IMAGE_CHANGE].Value = 1;
            }
        }

        /// <summary>
        /// 行削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROW_DEL_Click(object sender, EventArgs e)
        {
            this.Del_button_Click(this, new EventArgs());
        }

        /// <summary>
        /// 行コピー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROW_COPY_Click(object sender, EventArgs e)
        {
            if (this.Goods_Grid.Selected.Rows.Count == 0) return; 

            try
            {
                this.Goods_Grid.BeginUpdate();
                this._copyBufferList.Clear();
                // 論理削除行があるので一旦フィルターをクリア
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = "";

                foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                {
                    this._copyBufferList.Add(this.TBODataSet.Tables[TABLE_MAIN].Rows[row.Index].ItemArray.Clone());
                }
            }
            finally
            {
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// 行貼り付け(挿入貼り付けとする)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROW_PAST_Click(object sender, EventArgs e)
        {
            if (this._copyBufferList.Count == 0) return;

            try
            {
                this.Goods_Grid.BeginUpdate();

                // 論理削除行があるので一旦フィルターをクリア
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = "";

                int index = -1;
                if (this.Goods_Grid.Selected.Rows != null)
                {
                    foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                    {
                        if (row.Activated)
                        {
                            index = row.Index;
                            break;
                        }
                    }
                }

                if (index != -1)
                {
                    for (int i = 0; i < this._copyBufferList.Count; i++)
                    {
                        DataRow newRow = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                        newRow.ItemArray = (object[])this._copyBufferList[i];
                        // コピーしたらダメなものを初期化
                        newRow[COL_IMAGE_CHANGE] = 0;
                        newRow[COL_PM_UPDATETIME] = 0;
                        newRow[COL_POSTPARACLASS] = DBNull.Value;
                        newRow[COL_SORTNO] = 0;
                        newRow[COL_STOCKCOUNT] = 0;
                        this.TBODataSet.Tables[TABLE_MAIN].Rows.InsertAt(newRow, index);
                        index++;
                    }
                }
            }
            finally
            {
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
                this._copyBufferList.Clear();
            } 
        }

        /// <summary>
        /// コンテクストメニュー表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.Goods_Grid.Selected.Rows.Count > 0)
            {
                this.ROW_DEL.Enabled = true;
                this.ROW_COPY.Enabled = true;
                this.IMAGE_SET.Enabled = true;
                this.IMAGE_CLEAR.Enabled = true;
            }
            else
            {
                this.ROW_DEL.Enabled = false;
                this.ROW_COPY.Enabled = false;
                this.IMAGE_SET.Enabled = false;
                this.IMAGE_CLEAR.Enabled = false;
            }

            // 貼り付け
            if (this._copyBufferList.Count > 0)
            {
                this.ROW_PAST.Enabled = true;
            }
            else
            {
                this.ROW_PAST.Enabled = false;
            }
        }

        /// <summary>
        /// 画像指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IMAGE_SET_Click(object sender, EventArgs e)
        {
            // 画像ガイド起動
            if (this._imageGuide == null)
            {
                this._imageGuide = new GoodsImageForm();
                this._imageGuide._dataReadFlag = true;
                this._imageGuide._mode = 1;
                this._imageGuide.Icon = this.Icon;
            }
            this._imageGuide._enterPriseCode = this._bootPara.EnterpriseCode;
            this._imageGuide._goodsCategoryId = (long)this.Category_ComboEditor.Value;
            this._imageGuide._goodsCategoryList = this._categoryList;
            this._imageGuide._imageID = 0;
            this._imageGuide._goodsImage = null;

            DialogResult ret = this._imageGuide.ShowGoodsImageFrom();
            if (ret == DialogResult.OK)
            {
                for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
                {
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_NO].Value = this._imageGuide._imageID;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE].Value = this._imageGuide._goodsImage;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_CHANGE].Value = 1;
                }
            }
        }

        /// <summary>
        /// 画像クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IMAGE_CLEAR_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
            {
                if (GetCellLong(this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_NO].Value, 0) != 0)
                {
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_NO].Value = 0;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE].Value = DBNull.Value;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_CHANGE].Value = 1;
                }
            }
        }

        /// <summary>
        /// グリッドマウスクリック(右クリック用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_MouseClick(object sender, MouseEventArgs e)
        {
            // 右クリック以外は抜ける
            if (e.Button != MouseButtons.Right)
                return;

            try 
            {
                UltraGrid targetGrid = sender as UltraGrid;

                if (targetGrid.Selected.Rows.Count == 0) return;

                // マウスが入った最後の要素を取得
                Infragistics.Win.UIElement lastUIElement = targetGrid.DisplayLayout.UIElement.LastElementEntered;
                // チェーン内にRowUIElementがあるかどうかを調べます
                RowUIElement rowElement;

                if (lastUIElement == null)
                    return;

                if (lastUIElement is RowUIElement)
                {
                    rowElement = (RowUIElement)lastUIElement;
                }
                else
                {
                    rowElement = (RowUIElement)lastUIElement.GetAncestor(typeof(RowUIElement));
                }

                // 要素から行を取得します
                UltraGridRow row = (UltraGridRow)rowElement.GetContext(typeof(UltraGridRow));
                if (row == null)
                    return;

                // マウスは行の上にあります

                // 現在のマウスポインタの位置を取得してグリッド座標に変換します
                Point mousePosition = targetGrid.PointToClient(Control.MousePosition);

                // 座標点がAdjustableElement上にあるかどうかを調べます。すなわち、
                // ユーザーが行セレクタ上の行をクリックしているかどうか。
                if (lastUIElement.AdjustableElementFromPoint(mousePosition) != null)
                    return;

                // 右クリックメニュー表示
                if (this.Goods_Grid.Selected.Rows.Count > 0)
                {
                    this.InsertUpRow_ToolStripMenuItem.Text = this.Goods_Grid.Selected.Rows.Count.ToString() + "行を挿入";
                    //this.InsertDownRow_ToolStripMenuItem.Text = this.Goods_Grid.Selected.Rows.Count.ToString() + "行を下に挿入";
                }
               
                this.contextMenuStrip1.Show(this.Goods_Grid, e.X, e.Y);
            }
            catch (Exception)
            {
                // 予期せぬエラー用
            }
        }



        /// <summary>
        /// セットマスタ取込
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_SetImp_Click(object sender, EventArgs e)
        {
            // 保存確認
            if (CheckUpDate() == false) return;

            // 編集モード終了
            this.Goods_Grid.PerformAction(UltraGridAction.ExitEditMode);

            int st = 0;
            string errMsg = "";
            List<Propose_Goods> retList = new List<Propose_Goods>();

            try
            {
                // アセンブリロード
                Assembly assm = Assembly.LoadFrom(CT_PM_AssemblyID);
                // タイプ取得
                Type type = assm.GetType(CT_PM_ClassID);

                if (assm != null && type != null)
                {
                    // インスタンス生成
                    object instance = Activator.CreateInstance(type);
                    // 起動
                    MethodInfo method = type.GetMethod("ShowDialog", new Type[] { typeof(string), typeof(string), typeof(string), typeof(Int32) });
                    long categoryIDlong = (long)this.Category_ComboEditor.Value;
                    int categoryID = Convert.ToInt32(categoryIDlong .ToString());
                    //object ob = method.Invoke(instance, new object[] { this._bootPara.EnterpriseCode, this._bootPara.SectionCode, this._bootPara.EmployeeName, categoryID });
                    // ログイン拠点ではなく、現在選択中の拠点を渡す
                    object ob = method.Invoke(instance, new object[] { this._bootPara.EnterpriseCode, this.Section_ComboEditor.Value.ToString(), this._bootPara.EmployeeName, categoryID });

                    // 結果を取得
                    PropertyInfo property = type.GetProperty("TBODataList");
                    retList = (List<Propose_Goods>)property.GetValue(instance, null);

                    #region サンプル
#if DEBUG
                    retList = new List<Propose_Goods>();

                    if ((long)this.Category_ComboEditor.Value == 1)
                    {
                        Propose_Goods sample1 = new Propose_Goods();
                        sample1.BLGoodsCode = 7110;
                        sample1.GoodsCategory = 1;
                        sample1.GoodsMakerCd = 1464;
                        sample1.GoodsName = "ブリジストン 215/45R17 ZE914";
                        sample1.GoodsNo = "PMUPDATE";
                        sample1.MakerName = "ファルケン";
                        //sample1.PMUpdateTime = DateTime.Now.Ticks;
                        sample1.PurchaseCost = 8300;
                        sample1.SearchTag1 = "215/45R17";
                        sample1.SearchTag2 = "0";
                        sample1.SectionCode = "01";
                        sample1.StockStatusDiv = 0;
                        sample1.SuggestPrice = 0;
                        sample1.PMUpdateTime = DateTime.Now.Ticks;

                        //Propose_Goods sample2 = new Propose_Goods();
                        //sample2.BLGoodsCode = 7110;
                        //sample2.GoodsCategory = 1;
                        //sample2.GoodsMakerCd = 2485;
                        //sample2.GoodsName = "ﾄｰﾖｰﾀｲﾔ 215/45R17 PROXES R1R";
                        //sample2.GoodsNo = "14850554";
                        //sample2.MakerName = "東洋ゴム工業";
                        //sample2.PMUpdateTime = DateTime.Now.Ticks;
                        //sample2.PurchaseCost = 0;
                        //sample2.SearchTag1 = "215/45R17";
                        //sample2.SearchTag2 = "0";
                        //sample2.SectionCode = "01";
                        //sample2.StockStatusDiv = 2;
                        //sample2.SuggestPrice = 27900;

                        //Propose_Goods sample2_s = new Propose_Goods();
                        //sample2_s.BLGoodsCode = 7110;
                        //sample2_s.GoodsCategory = 1;
                        //sample2_s.GoodsMakerCd = 2485;
                        //sample2_s.GoodsName = "ﾄｰﾖｰｽﾀｯﾄﾞﾚｽ 215/45R17 GARIT G5";
                        //sample2_s.GoodsNo = "14860613";
                        //sample2_s.MakerName = "東洋ゴム工業";
                        //sample2_s.PMUpdateTime = DateTime.Now.Ticks;
                        //sample2_s.PurchaseCost = 16800;
                        //sample2_s.SearchTag1 = "215/45R17";
                        //sample2_s.SearchTag2 = "1";
                        //sample2_s.SectionCode = "01";
                        //sample2_s.StockStatusDiv = 3;
                        //sample2_s.SuggestPrice = 33500;


                        //Propose_Goods sample3 = new Propose_Goods();
                        //sample3.BLGoodsCode = 7110;
                        //sample3.GoodsCategory = 1;
                        //sample3.GoodsMakerCd = 1464;
                        //sample3.GoodsName = "ﾌｧﾙｹﾝ 215/45R18 ZE914";
                        //sample3.GoodsNo = "315265";
                        //sample3.MakerName = "ファルケン";
                        //sample3.PMUpdateTime = DateTime.Now.Ticks;
                        //sample3.PurchaseCost = 11900;
                        //sample3.SearchTag1 = "215/45R18";
                        //sample3.SearchTag2 = "0";
                        //sample3.SectionCode = "01";
                        //sample3.StockStatusDiv = 0;
                        //sample3.SuggestPrice = 23800;

                        //Propose_Goods sample4 = new Propose_Goods();
                        //sample4.BLGoodsCode = 7110;
                        //sample4.GoodsCategory = 1;
                        //sample4.GoodsMakerCd = 2485;
                        //sample4.GoodsName = "ﾄｰﾖｰﾀｲﾔ 215/45R18 PROXES T1S";
                        //sample4.GoodsNo = "12270186";
                        //sample4.MakerName = "東洋ゴム工業";
                        //sample4.PMUpdateTime = DateTime.Now.Ticks;
                        //sample4.PurchaseCost = 0;
                        //sample4.SearchTag1 = "215/45R18";
                        //sample4.SearchTag2 = "0";
                        //sample4.SectionCode = "01";
                        //sample4.StockStatusDiv = 2;
                        //sample4.SuggestPrice = 28300;


                        //Propose_Goods sample5 = new Propose_Goods();
                        //sample5.BLGoodsCode = 7110;
                        //sample5.GoodsCategory = 1;
                        //sample5.GoodsMakerCd = 1464;
                        //sample5.GoodsName = "ﾌｧﾙｹﾝ 215/50R17 ZE914";
                        //sample5.GoodsNo = "315293";
                        //sample5.MakerName = "ファルケン";
                        //sample5.PMUpdateTime = DateTime.Now.Ticks;
                        //sample5.PurchaseCost = 11900;
                        //sample5.SearchTag1 = "215/50R17";
                        //sample5.SearchTag2 = "0";
                        //sample5.SectionCode = "01";
                        //sample5.StockStatusDiv = 3;
                        //sample5.SuggestPrice = 20400;

                        //Propose_Goods sample6 = new Propose_Goods();
                        //sample6.BLGoodsCode = 7110;
                        //sample6.GoodsCategory = 1;
                        //sample6.GoodsMakerCd = 2485;
                        //sample6.GoodsName = "ﾄｰﾖｰﾀｲﾔ 215/50R17 PXCF2";
                        //sample6.GoodsNo = "13350175";
                        //sample6.MakerName = "東洋ゴム工業";
                        //sample6.PMUpdateTime = DateTime.Now.Ticks;
                        //sample6.PurchaseCost = 13500;
                        //sample6.SearchTag1 = "215/50R17";
                        //sample6.SearchTag2 = "0";
                        //sample6.SectionCode = "01";
                        //sample6.StockStatusDiv =　0;
                        //sample6.SuggestPrice = 23500;

                        retList.Add(sample1);
                        //retList.Add(sample2);
                        //retList.Add(sample2_s);
                        //retList.Add(sample3);
                        //retList.Add(sample4);
                        //retList.Add(sample5);
                        //retList.Add(sample6);
                    }

                    else if ((long)this.Category_ComboEditor.Value == 2)
                    {
                        // バッテリ

                        Propose_Goods sample4 = new Propose_Goods();
                        sample4.BLGoodsCode = 7350;
                        sample4.GoodsCategory = 2;
                        sample4.GoodsMakerCd = 1758;
                        sample4.GoodsName = "ﾊﾞｯﾃﾘｰ 75D23L/SP";
                        sample4.GoodsNo = "N-75D23L/SP";
                        sample4.MakerName = "パナソニック　ストレージバッテ";
                        sample4.PMUpdateTime = DateTime.Now.Ticks;
                        sample4.PurchaseCost = 14800;
                        sample4.SearchTag1 = "75D23L/SP";
                        sample4.SearchTag2 = "1";
                        sample4.SearchTag3 = "0";
                        sample4.SectionCode = "01";
                        sample4.StockStatusDiv = 1;
                        sample4.SuggestPrice = 20900;

                        Propose_Goods sample5 = new Propose_Goods();
                        sample5.BLGoodsCode = 7350;
                        sample5.GoodsCategory = 2;
                        sample5.GoodsMakerCd = 2480;
                        sample5.GoodsName = "ﾊﾞｯﾃﾘｰ 75D23L/SP";
                        sample5.GoodsNo = "N-75D23L/SP";
                        sample5.MakerName = "ブリヂストン";
                        sample5.PMUpdateTime = DateTime.Now.Ticks;
                        sample5.PurchaseCost = 14800;
                        sample5.SearchTag1 = "75D23L/SP";
                        sample5.SearchTag2 = "1";
                        sample5.SearchTag3 = "0";
                        sample5.SectionCode = "01";
                        sample5.StockStatusDiv = 1;
                        sample5.SuggestPrice = 20900;

                        Propose_Goods sample1 = new Propose_Goods();
                        sample1.BLGoodsCode = 7350;
                        sample1.GoodsCategory = 2;
                        sample1.GoodsMakerCd = 1091;
                        sample1.GoodsName = "ﾃﾞﾙｺｱﾊﾞｯﾃﾘｰ2年4万ｷﾛ保証";
                        sample1.GoodsNo = "D-80D23R/PL";
                        sample1.MakerName = "ＳＰＫ・諸口";
                        sample1.PMUpdateTime = DateTime.Now.Ticks;
                        sample1.PurchaseCost = 6100;
                        sample1.SearchTag1 = "80D23R";
                        sample1.SearchTag2 = "1";
                        sample1.SearchTag3 = "0";
                        sample1.SectionCode = "01";
                        sample1.StockStatusDiv = 1;
                        sample1.SuggestPrice = 10800;

                        Propose_Goods sample2 = new Propose_Goods();
                        sample2.BLGoodsCode = 7350;
                        sample2.GoodsCategory = 2;
                        sample2.GoodsMakerCd = 1091;
                        sample2.GoodsName = "ﾃﾞﾙｺｱﾊﾞｯﾃﾘｰ2年4万ｷﾛ保証";
                        sample2.GoodsNo = "0-90D26L/PL";
                        sample2.MakerName = "ＳＰＫ・諸口";
                        sample2.PMUpdateTime = DateTime.Now.Ticks;
                        sample2.PurchaseCost = 7000;
                        sample2.SearchTag1 = "90D26L";
                        sample2.SearchTag2 = "1";
                        sample2.SearchTag3 = "0";
                        sample2.SectionCode = "01";
                        sample2.StockStatusDiv = 1;
                        sample2.SuggestPrice = 0;

                        Propose_Goods sample3 = new Propose_Goods();
                        sample3.BLGoodsCode = 7350;
                        sample3.GoodsCategory = 2;
                        sample3.GoodsMakerCd = 1758;
                        sample3.GoodsName = "ﾊﾞｯﾃﾘｰ 135D31R/C4";
                        sample3.GoodsNo = "A-135D31R/C4";
                        sample3.MakerName = "パナソニック　ストレージバッテ";
                        sample3.PMUpdateTime = DateTime.Now.Ticks;
                        sample3.PurchaseCost = 14700;
                        sample3.SearchTag1 = "135D31R/C4";
                        sample3.SearchTag2 = "1";
                        sample3.SearchTag3 = "0";
                        sample3.SectionCode = "01";
                        sample3.StockStatusDiv = 1;
                        sample3.SuggestPrice = 20800;

                        retList.Add(sample4);
                        retList.Add(sample1);
                        retList.Add(sample2);
                        retList.Add(sample3);
                        retList.Add(sample5);
                    }
#endif

                    #endregion




                    if (retList.Count == 0)
                    {
                        TMsgDisp.Show(
                          this,								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                          CT_ASSEMBLYID,					// アセンブリIDまたはクラスID
                          "取込データがありません",			// 表示するメッセージ 
                          -1,								// ステータス値
                          MessageBoxButtons.OK);			// 表示するボタン
                        return;
                    }

                     // 既存データ読込が行われていない場合は一旦抽出処理を行う
                    if (this.Section_ComboEditor.Enabled == true)
                    {
                        st = 0;
                        errMsg = "";
                        List<ProposeGoods> proposeGoodstList = new List<ProposeGoods>();
                        st = this.SearchGoodsProc(out proposeGoodstList, out errMsg);

                        if (st == 0)
                        {
                            // データを反映
                            this.SetDataTable(proposeGoodstList);
                            this.Section_ComboEditor.Enabled = false;
                            this.Search_button.Enabled = false;
                            this.Category_ComboEditor.Enabled = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                            errMsg,			                    // 表示するメッセージ 
                            st,								    // ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                            return;
                        }
                    }

                    // 抽出PGで抽出したデータを反映
                    int newCount;
                    int updateCount;
                    Dictionary<int, List<string>> changeList = new Dictionary<int, List<string>>();

                    // 結果をソート 商品タグ１→メーカーコード→品番
                    retList.Sort(delegate(Propose_Goods obj1, Propose_Goods obj2)
                    {
                        if (obj1.SearchTag1.CompareTo(obj2.SearchTag1) == 0)
                        {
                            if (obj1.GoodsMakerCd.CompareTo(obj2.GoodsMakerCd) == 0)
                            {
                                return obj1.GoodsNo.CompareTo(obj2.GoodsNo);
                            }
                            else
                            {
                                return obj1.GoodsMakerCd.CompareTo(obj2.GoodsMakerCd);
                            }
                        }
                        else
                        {
                            return obj1.SearchTag1.CompareTo(obj2.SearchTag1);
                        }
                    });

                    // 取込実行
                    st = this.ReflectImportData(retList, out newCount, out updateCount, out changeList, out errMsg);
                    if (st == 0)
                    {
                        // 取込完了
                        if (changeList.Count > 0)
                        {
                            foreach (int rowIndex in changeList.Keys)
                            {
                                foreach (string colNm in changeList[rowIndex])
                                {
                                    this._initFlag = true;

                                    // 変更セルの文字色を変更
                                    if (this.Goods_Grid.Rows[rowIndex].Cells[colNm].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
                                    {
                                        this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                    }
                                    else
                                    {
                                        if (colNm == COL_STOCKSTATE && (int)this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == -1)
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                        }
                                        else if (colNm == COL_SHOPSALEENDDATE && this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == DBNull.Value)
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.ForeColor = Color.Red;
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.ForeColor = Color.Red;
                                        }
                                    }
                                }
                            }
                        }

                        // グリッド更新
                        this.UpDateGrid();

                        TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                        CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                        "取込が完了しました。"              // 表示するメッセージ 
                        + Environment.NewLine
                        + "新規:"
                        + newCount.ToString() + "件"
                        + Environment.NewLine
                        + "更新:"
                        + updateCount.ToString() + "件",
                        st,								    // ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                    }
                    else
                    {
                        // 取込失敗
                        TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                        errMsg,			                    // 表示するメッセージ 
                        st,								    // ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                    }
                }
                else
                {
                    throw new System.ArgumentException();
                }

            }
            catch(Exception)
            {
                TMsgDisp.Show(
                this,								                // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // エラーレベル
                CT_ASSEMBLYID,					                    // アセンブリIDまたはクラスID
                "セットマスタ取込画面の起動に失敗しました。",		// 表示するメッセージ 
                -1,								                // ステータス値
                MessageBoxButtons.OK);			                    // 表示するボタン
                return;
            }
        }


        #region セットマスタ取込
        /// <summary>
        /// 取込データ反映
        /// </summary>
        /// <param name="saveAray"></param>
        private int ReflectImportData(List<Propose_Goods> retList, out int newCount, out int updateCount, out  Dictionary<int, List<string>> changeList, out string errMsg)
        {
            int st = 0;
            newCount = 0;
            updateCount = 0;
            errMsg = "";
            changeList = new Dictionary<int, List<string>>();

            bool showMsg = false;
            bool upDateGoodsNm = false;

            try
            {
                this.Goods_Grid.BeginUpdate();

                // 品番 + メーカー名称にて既存行を検索

                if (retList != null)
                {
                    string mkNm = "";
                    string goodsNo = "";
                    for (int i = 0; i < retList.Count; i++)
                    {
                        mkNm = retList[i].MakerName;
                        goodsNo = retList[i].GoodsNo;
                        StringBuilder cndString = new StringBuilder();
                        // 登録済行のみ
                        cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                        DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());

                        if (rows != null && rows.Length > 0 && rows[0][COL_POSTPARACLASS] != DBNull.Value)
                        {
                            List<string> changColList = new List<string>();

                            // セットマスタ取込の場合、PM更新日が変更されてなかったら更新しない
                            if (((long)rows[0][COL_PM_UPDATETIME]).Equals(retList[i].PMUpdateTime))
                            {
                                continue;
                            }

                            // PM更新日
                            rows[0][COL_PM_UPDATETIME] = retList[i].PMUpdateTime;

                            if (showMsg == false)
                            {
                                // 上書き確認
                                DialogResult rslt = TMsgDisp.Show(
                                this,								        // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,	            // エラーレベル
                                CT_ASSEMBLYID,						        // アセンブリIDまたはクラスID
                                "既に登録済みの商品が含まれています。" 
                                + Environment.NewLine
                                + "商品名称の上書きを行いますか？",			// 表示するメッセージ 
                                st,								            // ステータス値
                                MessageBoxButtons.YesNo);				        // 表示するボタン

                                if (rslt == DialogResult.Yes)
                                {
                                    upDateGoodsNm = true;
                                }
                                showMsg = true;
                            }


                            // BLコード 元データに入ってなかったら追加
                            if (GetCellInt32(rows[0][COL_BLCD], 0) == 0)
                            {
                                rows[0][COL_BLCD] = retList[i].BLGoodsCode;
                                rows[0][COL_BLCDBR] = retList[i].BLGoodsDrCode;
                            }

                            // 商品名称
                            if (upDateGoodsNm)
                            {
                                // インポート値がNULlじゃない＆値が変更されている場合（文字列を赤くする為）
                                if (!string.IsNullOrEmpty(retList[i].GoodsName) && !(rows[0][COL_GOODSNM].ToString().Equals(retList[i].GoodsName)))
                                {
                                    rows[0][COL_GOODSNM] = retList[i].GoodsName;
                                    changColList.Add(COL_GOODSNM);
                                }
                            }

                            // 金額情報
                            // 標準価格、仕入原価は強制上書き（ただし0円は除外）

                            // 標準価格
                            if (!retList[i].SuggestPrice.Equals(0))
                            {
                                long suggestPrice = Convert.ToInt64(retList[i].SuggestPrice);
                                if (!((long)rows[0][COL_SUGGEST_PRICE]).Equals(suggestPrice))
                                {
                                    rows[0][COL_SUGGEST_PRICE] = suggestPrice;
                                    changColList.Add(COL_SUGGEST_PRICE);
                                }
                            }

                            // 仕入原価
                            if (!retList[i].PurchaseCost.Equals(0))
                            {
                                long purchaseCost = Convert.ToInt64(retList[i].PurchaseCost);
                                if (!((long)rows[0][COL_PURCHASE_COST]).Equals(purchaseCost))
                                {
                                    rows[0][COL_PURCHASE_COST] = purchaseCost;
                                    changColList.Add(COL_PURCHASE_COST);
                                }
                            }

                            // 売価もセットされるようになったので0でないかつ、変更されてたら取り込む
                            // 売価
                            if (!retList[i].TradePrice.Equals(0))
                            {
                                long tradePrice = Convert.ToInt64(retList[i].TradePrice);
                                if (!((long)rows[0][COL_TRADE_PRICE]).Equals(tradePrice))
                                {
                                    rows[0][COL_TRADE_PRICE] = tradePrice;
                                    changColList.Add(COL_TRADE_PRICE);
                                }
                            }



                            // 在庫状態 PMからは0:入荷待ち,2:在庫残少,3:在庫豊富　しか戻らない
                            int stockStatusDiv = retList[i].StockStatusDiv;

                            switch (stockStatusDiv)
                            {
                                case 0: // 取り寄せ
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(3))
                                    {
                                        rows[0][COL_STOCKSTATE] = 3;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                                case 2: // 在庫残少
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(2))
                                    {
                                        rows[0][COL_STOCKSTATE] = 2;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                                case 3: // 在庫豊富
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(1))
                                    {
                                        rows[0][COL_STOCKSTATE] = 1;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                                default:
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(stockStatusDiv))
                                    {
                                        rows[0][COL_STOCKSTATE] = -1;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                            }

                            // 商品タグ
                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // タイヤ
                                    // // 商品タグ1 サイズ
                                    if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_TIRE_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_TIRE_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_TIRE_KEY1);
                                    }
                                    // 商品タグ２ スタッドレス
                                    #region 現状PM側からは戻ってこないが、セットされた場合に取り込めるようにしておく
                                    if (retList[i].SearchTag2 != null && !String.IsNullOrEmpty(retList[i].SearchTag2))
                                    {
                                        if (((bool)rows[0][COL_TIRE_KEY2] == false) && (retList[i].SearchTag2 == "1"))
                                        {
                                            rows[0][COL_TIRE_KEY2] = true;
                                            changColList.Add(COL_TIRE_KEY2);
                                        }
                                        else if (((bool)rows[0][COL_TIRE_KEY2] == true) && (retList[i].SearchTag2 == "0"))
                                        {
                                            rows[0][COL_TIRE_KEY2] = false;
                                            changColList.Add(COL_TIRE_KEY2);
                                        }
                                    }
                                    #endregion

                                    break;
                                case 2: //バッテリ
                                    // // 商品タグ1 規格
                                    if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_BATTERY_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_BATTERY_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_BATTERY_KEY1);
                                    }

                                    // 商品タグ2 適合
                                    #region 現状PM側からは戻ってこないが、セットされた場合に取り込めるようにしておく
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_BATTERY_KEY2] != 1)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 1;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 2)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 2;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 3)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 3;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                    }
                                    #endregion

                                    break;
                                case 3: // オイル

                                    // 商品タグ1 粘度
                                    if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_OIL_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_OIL_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_OIL_KEY1);
                                    }

                                    // 商品タグ2 適合
                                    #region 現状PM側からは戻ってこないが、セットされた場合に取り込めるようにしておく
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_OIL_KEY2] != 1)
                                        {
                                            rows[0][COL_OIL_KEY2] = 1;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 2)
                                        {
                                            rows[0][COL_OIL_KEY2] = 2;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 3)
                                        {
                                            rows[0][COL_OIL_KEY2] = 3;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                    }
                                    #endregion

                                    break;
                            }

                            // 更新行のIndexを取得
                            if (!changeList.ContainsKey(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0])))
                            {
                                changeList.Add(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0]), changColList);
                            }

                            // 行の粗利を計算
                            this.CalcGrossProc(ref rows[0]);
                            // 更新件数
                            updateCount++;
                        }
                        else
                        {
                            // 新規
                            // 追加
                            DataRow newRow = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                            newRow[COL_BLCD] = retList[i].BLGoodsCode;
                            newRow[COL_BLCDBR] = retList[i].BLGoodsDrCode;
                            newRow[COL_GOODSNM] = retList[i].GoodsName;
                            newRow[COL_GOODSNO] = retList[i].GoodsNo;

                            // メーカーリストにあればコード採用。提供の名称を反映
                            if (this._makerCdDic.ContainsKey(retList[i].GoodsMakerCd))
                            {
                                newRow[COL_MAKERCD] = retList[i].GoodsMakerCd;
                                newRow[COL_MAKERNM] = this._makerCdDic[retList[i].GoodsMakerCd].MakerName;
                            }
                            else
                            {
                                // リストになければ名称のみ反映
                                newRow[COL_MAKERCD] = 0;
                                newRow[COL_MAKERNM] = retList[i].MakerName;
                            }

                            // PM在庫更新日
                            newRow[COL_PM_UPDATETIME] = retList[i].PMUpdateTime;
                           
                            // 金額系
                            newRow[COL_SHOP_PRICE] = Convert.ToInt64(retList[i].ShopPrice);
                            newRow[COL_STOCKCOUNT] = retList[i].StockCnt;

                            // 在庫状態
                            int stockStatusDiv = retList[i].StockStatusDiv;

                            switch (stockStatusDiv)
                            {
                                case 0: // 取り寄せ
                                    newRow[COL_STOCKSTATE] = 3;
                                    break;
                                case 2: // 在庫残少
                                    newRow[COL_STOCKSTATE] = 2;
                                    break;
                                case 3: // 在庫豊富
                                    newRow[COL_STOCKSTATE] = 1;
                                    break;
                                default:
                                    newRow[COL_STOCKSTATE] = -1;
                                    break;
                            }

                            newRow[COL_SUGGEST_PRICE] = Convert.ToInt64(retList[i].SuggestPrice);
                            newRow[COL_TRADE_PRICE] = Convert.ToInt64(retList[i].TradePrice);
                            newRow[COL_PURCHASE_COST] = Convert.ToInt64(retList[i].PurchaseCost);

                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // タイヤ
                                    newRow[COL_TIRE_KEY1] = retList[i].SearchTag1;

                                    #region 現状PM側からは戻ってこないが、セットされた場合に取り込めるようにしておく
                                    if (retList[i].SearchTag2 != null && !String.IsNullOrEmpty(retList[i].SearchTag2))
                                    {
                                        if (retList[i].SearchTag2 == "0")
                                        {
                                            newRow[COL_TIRE_KEY2] = false;
                                        }
                                        else if (retList[i].SearchTag2 == "1")
                                        {
                                            newRow[COL_TIRE_KEY2] = true;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 2: // バッテリ
                                    newRow[COL_BATTERY_KEY1] = retList[i].SearchTag1;

                                    #region 現状PM側からは戻ってこないが、セットされた場合に取り込めるようにしておく
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 3;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 3: // オイル
                                    newRow[COL_OIL_KEY1] = retList[i].SearchTag1;

                                    #region 現状PM側からは戻ってこないが、セットされた場合に取り込めるようにしておく
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_OIL_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 3;
                                        }
                                    }
                                    #endregion
                                    break;
                            }

                            // 行の粗利を計算
                            this.CalcGrossProc(ref newRow);

                            this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(newRow);
                            // 新規件数
                            newCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品取込処理中に例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            finally
            {
                this.Goods_Grid.EndUpdate();
            }
            return st;
        }
        #endregion

        #region CSVインポート
        /// <summary>
        /// 取込データ反映
        /// </summary>
        /// <param name="saveAray"></param>
        private int ReflectCSVImportData(List<Propose_Goods> retList, out int newCount, out int updateCount, out  Dictionary<int, List<string>> changeList, out string errMsg)
        {
            // セットマスタ取込とだいたい同じ処理だが、バグを生まないように別処理にする
            // CSV取込の場合はCSVを正として全上書きとする

            int st = 0;
            newCount = 0;
            updateCount = 0;
            errMsg = "";
            changeList = new Dictionary<int, List<string>>();
          
            try
            {
                this.Goods_Grid.BeginUpdate();

                // 品番 + メーカー名称にて既存行を検索
                // 同じキーが複数含まれていたら?
                // →更新時：後勝ち→イレギュラーなのでＯＫ
                // →新規時：全て新規行で取込、保存時にチェック→イレギュラーなのでＯＫ

                if (retList != null)
                {
                    string mkNm = "";
                    string goodsNo = "";
                    for (int i = 0; i < retList.Count; i++)
                    {
                        mkNm = retList[i].MakerName;
                        goodsNo = retList[i].GoodsNo;
                        StringBuilder cndString = new StringBuilder();
                        // 登録済行のみ
                        cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                        DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());

                        if (rows != null && rows.Length > 0 && rows[0][COL_POSTPARACLASS] != DBNull.Value)
                        {
                            List<string> changColList = new List<string>();

                            // 更新
                            // 取込エラーが発生してなかったら上書き
                            // 商品名称
                            // 変更されてたら取り込む
                            if (retList[i].GoodsName != ct_ErrSt && !(rows[0][COL_GOODSNM].ToString().Equals(retList[i].GoodsName)))
                            {
                                rows[0][COL_GOODSNM] = retList[i].GoodsName;
                                changColList.Add(COL_GOODSNM);
                            }

                            // 商品説明
                            if (retList[i].GoodsNote != ct_ErrSt && !(rows[0][COL_GOODSNOTE].ToString().Equals(retList[i].GoodsNote)))
                            {
                                rows[0][COL_GOODSNOTE] = retList[i].GoodsNote;
                                changColList.Add(COL_GOODSNOTE);
                            }


                            // 商品PR
                            if (retList[i].GoodsPR != ct_ErrSt && !(rows[0][COL_GOODSPR].ToString().Equals(retList[i].GoodsPR)))
                            {
                                rows[0][COL_GOODSPR] = retList[i].GoodsPR;
                                changColList.Add(COL_GOODSPR);
                            }

                            // 金額情報

                            // 標準価格
                            if (retList[i].SuggestPrice != ct_ErrDouble)
                            {
                                long suggestPrice = Convert.ToInt64(retList[i].SuggestPrice);
                                if (!((long)rows[0][COL_SUGGEST_PRICE]).Equals(suggestPrice))
                                {
                                    rows[0][COL_SUGGEST_PRICE] = suggestPrice;
                                    changColList.Add(COL_SUGGEST_PRICE);
                                }
                            }

                            // 店頭価格 
                            if (retList[i].ShopPrice != ct_ErrDouble)
                            {
                                long shopPrice = Convert.ToInt64(retList[i].ShopPrice);
                                if (!((long)rows[0][COL_SHOP_PRICE]).Equals(shopPrice))
                                {
                                    rows[0][COL_SHOP_PRICE] = shopPrice;
                                    changColList.Add(COL_SHOP_PRICE);
                                }
                            }

                            // 仕入原価
                            if (retList[i].PurchaseCost != ct_ErrDouble)
                            {
                                long purchaseCost = Convert.ToInt64(retList[i].PurchaseCost);
                                if (!((long)rows[0][COL_PURCHASE_COST]).Equals(purchaseCost))
                                {
                                    rows[0][COL_PURCHASE_COST] = purchaseCost;
                                    changColList.Add(COL_PURCHASE_COST);
                                }
                            }

                            // 売価
                            if (retList[i].TradePrice != ct_ErrDouble)
                            {
                                long tradePrice = Convert.ToInt64(retList[i].TradePrice);
                                if (!((long)rows[0][COL_TRADE_PRICE]).Equals(tradePrice))
                                {
                                    rows[0][COL_TRADE_PRICE] = tradePrice;
                                    changColList.Add(COL_TRADE_PRICE);
                                }
                            }

                            // 販売日
                            if (retList[i].ReleaseDate != ct_ErrInt)
                            {
                                if (retList[i].ReleaseDate == 0)
                                {
                                    // 販売日は一括クリアしたいことがあるかもしれないので
                                    if (rows[0][COL_RELEASEDATE] != DBNull.Value)
                                    {
                                        rows[0][COL_RELEASEDATE] = DBNull.Value;
                                        changColList.Add(COL_RELEASEDATE);
                                    }
                                }
                                else
                                {
                                    DateTime releaseDate = DateTime.MinValue;
                                    try
                                    {
                                        int releaseDateInt = retList[i].ReleaseDate;
                                        string releaseDateSt = retList[i].ReleaseDate.ToString();
                                        if (releaseDateSt.Length == 6)
                                        {
                                            releaseDateSt = ((releaseDateInt * 100) + 1).ToString();
                                        }
                                        // カルチャー設定
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        releaseDate = DateTime.ParseExact(releaseDateSt, "yyyyMMdd", format);
                                    }
                                    catch
                                    {

                                    }

                                    if (releaseDate != null && releaseDate != DateTime.MinValue)
                                    {
                                        if (rows[0][COL_RELEASEDATE] == DBNull.Value)
                                        {
                                            rows[0][COL_RELEASEDATE] = releaseDate;
                                            changColList.Add(COL_RELEASEDATE);
                                        }
                                        else
                                        {
                                            // YYYYMMで比較
                                            int befYear  = ((DateTime)rows[0][COL_RELEASEDATE]).Year;
                                            int befMonth = ((DateTime)rows[0][COL_RELEASEDATE]).Month;
                                            int afYear   = releaseDate.Year;
                                            int afMonth   = releaseDate.Month;

                                            if(!befYear.Equals(afYear) || !befMonth.Equals(afMonth))
                                            {
                                                rows[0][COL_RELEASEDATE] = releaseDate;
                                                changColList.Add(COL_RELEASEDATE);
                                            }
                                        }
                                    }
                                }
                            }

                            // 公開開始日
                            if (retList[i].ShopSaleBeginDate != ct_ErrInt)
                            {
                                DateTime beginDate = DateTime.MinValue;
                                try
                                {
                                    string beginDateIntSt = retList[i].ShopSaleBeginDate.ToString();
                                    // カルチャー設定
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    beginDate = DateTime.ParseExact(beginDateIntSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }
                                if (beginDate != null && beginDate != DateTime.MinValue)
                                {
                                    if (rows[0][COL_SHOPSALEBEGINDATE] == DBNull.Value)
                                    {
                                        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                                        changColList.Add(COL_SHOPSALEBEGINDATE);
                                    }
                                    else if (!((DateTime)rows[0][COL_SHOPSALEBEGINDATE]).Equals(beginDate))
                                    {
                                        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                                        changColList.Add(COL_SHOPSALEBEGINDATE);
                                    }
                                }

                                // 公開日はデフォルトが0なので、0が来てもクリアしない
                            }


                            // 公開終了日
                            if (retList[i].ShopSaleEndDate != ct_ErrInt)
                            {
                                if (retList[i].ShopSaleEndDate == 0)
                                {
                                    // 終了日は一括クリアしたいことがあるかもしれないので
                                    if (rows[0][COL_SHOPSALEENDDATE] != DBNull.Value)
                                    {
                                        rows[0][COL_SHOPSALEENDDATE] = DBNull.Value;
                                        changColList.Add(COL_SHOPSALEENDDATE);
                                    }
                                }
                                else
                                {
                                    DateTime endDate = DateTime.MinValue;
                                    try
                                    {
                                        string endDateSt = retList[i].ShopSaleEndDate.ToString();
                                        // カルチャー設定
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        endDate = DateTime.ParseExact(endDateSt, "yyyyMMdd", format);
                                    }
                                    catch
                                    {

                                    }

                                    if (endDate != null && endDate != DateTime.MinValue)
                                    {
                                        if (rows[0][COL_SHOPSALEENDDATE] == DBNull.Value)
                                        {
                                            rows[0][COL_SHOPSALEENDDATE] = endDate;
                                            changColList.Add(COL_SHOPSALEENDDATE);
                                        }
                                        else if (!((DateTime)rows[0][COL_SHOPSALEENDDATE]).Equals(endDate))
                                        {
                                            rows[0][COL_SHOPSALEENDDATE] = endDate;
                                            changColList.Add(COL_SHOPSALEENDDATE);
                                        }
                                    }
                                }
                            }

                            if (retList[i].StockStatusDiv != ct_Errshort)
                            {
                                // 在庫状態 (-1,0,1,2でくるのでそのままセット)
                                int stockStatusDiv = retList[i].StockStatusDiv;
                                if (!((int)rows[0][COL_STOCKSTATE]).Equals(stockStatusDiv))
                                {
                                    rows[0][COL_STOCKSTATE] = stockStatusDiv;
                                    changColList.Add(COL_STOCKSTATE);
                                }
                            }

                            // 商品タグ
                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // タイヤ
                                    // // 商品タグ1 サイズ
                                    if (retList[i].SearchTag1 != ct_ErrSt && !(rows[0][COL_TIRE_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_TIRE_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_TIRE_KEY1);
                                    }
                                    // 商品タグ２ スタッドレス
                                    if (retList[i].SearchTag2 != ct_ErrSt)
                                    {
                                        if (((bool)rows[0][COL_TIRE_KEY2] == false) && (retList[i].SearchTag2 == "1") ||
                                        ((bool)rows[0][COL_TIRE_KEY2] == true) && (retList[i].SearchTag2 == "0"))
                                        {
                                            rows[0][COL_TIRE_KEY2] = retList[i].SearchTag2.Equals("0") ? false : true;
                                            changColList.Add(COL_TIRE_KEY2);
                                        }
                                    }
                                    break;
                                case 2: //バッテリ
                                    // // 商品タグ1 規格
                                    if (retList[i].SearchTag1 != ct_ErrSt && !(rows[0][COL_BATTERY_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_BATTERY_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_BATTERY_KEY1);
                                    }

                                    // 商品タグ2 適合
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_BATTERY_KEY2] != 1)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 1;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 2)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 2;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 3)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 3;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                    }
                                    break;
                                case 3: // オイル

                                    // 商品タグ1 粘度
                                    if (retList[i].SearchTag1 != ct_ErrSt && !(rows[0][COL_OIL_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_OIL_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_OIL_KEY1);
                                    }

                                    // 商品タグ2 適合
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_OIL_KEY2] != 1)
                                        {
                                            rows[0][COL_OIL_KEY2] = 1;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 2)
                                        {
                                            rows[0][COL_OIL_KEY2] = 2;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 3)
                                        {
                                            rows[0][COL_OIL_KEY2] = 3;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                    }
                                    break;
                            }


                            // 公開
                            if (retList[i].release != ct_ErrInt)
                            {
                                if (((bool)rows[0][COL_RELEASE] == false) && (retList[i].release == 1) ||
                                    ((bool)rows[0][COL_RELEASE] == true) && (retList[i].release == 0))
                                {
                                    rows[0][COL_RELEASE] = retList[i].release;
                                    changColList.Add(COL_RELEASE);
                                }
                            }
                         

                            // オススメ
                            if (retList[i].recommend != ct_ErrInt)
                            {
                                if (((bool)rows[0][COL_RECOMMEND] == false) && (retList[i].recommend == 1) ||
                              ((bool)rows[0][COL_RECOMMEND] == true) && (retList[i].recommend == 0))
                                {
                                    rows[0][COL_RECOMMEND] = retList[i].recommend;
                                    changColList.Add(COL_RECOMMEND);
                                }
                            }

                            #region 過去の仕様
                            //// インポート値がNULlじゃない＆値が変更されている場合（文字列を赤くする為）
                            //if (!string.IsNullOrEmpty(retList[i].GoodsName) && !(rows[0][COL_GOODSNM].ToString().Equals(retList[i].GoodsName)))
                            //{
                            //    rows[0][COL_GOODSNM] = retList[i].GoodsName;
                            //    changColList.Add(COL_GOODSNM);
                            //}

                            //// 商品説明
                            //if (!string.IsNullOrEmpty(retList[i].GoodsNote) && !(rows[0][COL_GOODSNOTE].ToString().Equals(retList[i].GoodsNote)))
                            //{
                            //    rows[0][COL_GOODSNOTE] = retList[i].GoodsNote;
                            //    changColList.Add(COL_GOODSNOTE);
                            //}
                           

                            //// 商品PR
                            //if (!string.IsNullOrEmpty(retList[i].GoodsPR) && !(rows[0][COL_GOODSPR].ToString().Equals(retList[i].GoodsPR)))
                            //{
                            //    rows[0][COL_GOODSPR] = retList[i].GoodsPR;
                            //    changColList.Add(COL_GOODSPR);
                            //}

                            //// 金額情報

                            //// 標準価格
                            //if (!retList[i].SuggestPrice.Equals(0))
                            //{
                            //    long suggestPrice = Convert.ToInt64(retList[i].SuggestPrice);
                            //    if (!((long)rows[0][COL_SUGGEST_PRICE]).Equals(suggestPrice))
                            //    {
                            //        rows[0][COL_SUGGEST_PRICE] = suggestPrice;
                            //        changColList.Add(COL_SUGGEST_PRICE);
                            //    }
                            //}

                            //// 店頭価格 
                            //if (!retList[i].ShopPrice.Equals(0))
                            //{
                            //    long shopPrice = Convert.ToInt64(retList[i].ShopPrice);
                            //    if (!((long)rows[0][COL_SHOP_PRICE]).Equals(shopPrice))
                            //    {
                            //        rows[0][COL_SHOP_PRICE] = shopPrice;
                            //        changColList.Add(COL_SHOP_PRICE);
                            //    }
                            //}

                            //// 仕入原価
                            //if (!retList[i].PurchaseCost.Equals(0))
                            //{
                            //    long purchaseCost = Convert.ToInt64(retList[i].PurchaseCost);
                            //    if (!((long)rows[0][COL_PURCHASE_COST]).Equals(purchaseCost))
                            //    {
                            //        rows[0][COL_PURCHASE_COST] = purchaseCost;
                            //        changColList.Add(COL_PURCHASE_COST);
                            //    }
                            //}

                            //// 売価
                            //if (!retList[i].TradePrice.Equals(0))
                            //{
                            //    long tradePrice = Convert.ToInt64(retList[i].TradePrice);
                            //    if (!((long)rows[0][COL_TRADE_PRICE]).Equals(tradePrice))
                            //    {
                            //        rows[0][COL_TRADE_PRICE] = tradePrice;
                            //        changColList.Add(COL_TRADE_PRICE);
                            //    }
                            //}

                            //// 販売日
                            //DateTime releaseDate = DateTime.MinValue;

                            //try
                            //{
                            //    int releaseDateInt = retList[i].ReleaseDate;
                            //    string releaseDateSt = retList[i].ReleaseDate.ToString();
                            //    if (releaseDateSt.Length == 6)
                            //    {
                            //        releaseDateSt = ((releaseDateInt * 100) + 1).ToString();
                            //    }
                            //    // カルチャー設定
                            //    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                            //    releaseDate = DateTime.ParseExact(releaseDateSt, "yyyyMMdd", format);
                            //}
                            //catch
                            //{

                            //}

                            //if (releaseDate != null && releaseDate != DateTime.MinValue)
                            //{
                            //    if (rows[0][COL_RELEASEDATE] == DBNull.Value)
                            //    {
                            //        rows[0][COL_RELEASEDATE] = releaseDate;
                            //        changColList.Add(COL_RELEASEDATE);
                            //    }
                            //    else if (!((DateTime)rows[0][COL_RELEASEDATE]).Equals(releaseDate))
                            //    {
                            //        rows[0][COL_RELEASEDATE] = releaseDate;
                            //        changColList.Add(COL_RELEASEDATE);
                            //    }
                            //}


                            //// 公開開始日(上書き)
                            //DateTime beginDate = DateTime.MinValue;

                            //try
                            //{
                            //    string beginDateIntSt = retList[i].ShopSaleBeginDate.ToString();
                            //    // カルチャー設定
                            //    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                            //    beginDate = DateTime.ParseExact(beginDateIntSt, "yyyyMMdd", format);
                            //}
                            //catch
                            //{

                            //}
                            //if (beginDate != null && beginDate != DateTime.MinValue)
                            //{
                            //    if (rows[0][COL_SHOPSALEBEGINDATE] == DBNull.Value)
                            //    {
                            //        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                            //        changColList.Add(COL_SHOPSALEBEGINDATE);
                            //    }
                            //    else if (!((DateTime)rows[0][COL_SHOPSALEBEGINDATE]).Equals(beginDate))
                            //    {
                            //        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                            //        changColList.Add(COL_SHOPSALEBEGINDATE);
                            //    }
                            //}


                            //// 公開終了日
                            //if (retList[i].ShopSaleEndDate == 0)
                            //{
                            //    // 終了日は一括クリアしたいことがあるかもしれないので
                            //    if (rows[0][COL_SHOPSALEENDDATE] != DBNull.Value)
                            //    {
                            //        rows[0][COL_SHOPSALEENDDATE] = DBNull.Value;
                            //        changColList.Add(COL_SHOPSALEENDDATE);
                            //    }
                            //}
                            //else
                            //{
                            //    DateTime endDate = DateTime.MinValue;

                            //    try
                            //    {
                            //        string endDateSt = retList[i].ShopSaleEndDate.ToString();
                            //        // カルチャー設定
                            //        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                            //        endDate = DateTime.ParseExact(endDateSt, "yyyyMMdd", format);
                            //    }
                            //    catch
                            //    {

                            //    }

                            //    if (endDate != null && endDate != DateTime.MinValue)
                            //    {
                            //        if (rows[0][COL_SHOPSALEENDDATE] == DBNull.Value)
                            //        {
                            //            rows[0][COL_SHOPSALEENDDATE] = endDate;
                            //            changColList.Add(COL_SHOPSALEENDDATE);
                            //        }
                            //        else if (!((DateTime)rows[0][COL_SHOPSALEENDDATE]).Equals(endDate))
                            //        {
                            //            rows[0][COL_SHOPSALEENDDATE] = endDate;
                            //            changColList.Add(COL_SHOPSALEENDDATE);
                            //        }
                            //    }
                            //}

                            //// 在庫状態 (-1,0,1,2でくるのでそのままセット)
                            //int stockStatusDiv = retList[i].StockStatusDiv;
                            //if (!((int)rows[0][COL_STOCKSTATE]).Equals(stockStatusDiv))
                            //{
                            //    rows[0][COL_STOCKSTATE] = stockStatusDiv;
                            //    changColList.Add(COL_STOCKSTATE);
                            //}

                            //// 商品タグ
                            //switch ((long)this.Category_ComboEditor.Value)
                            //{
                            //    case 1: // タイヤ
                            //        // // 商品タグ1 サイズ
                            //        if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_TIRE_KEY1].ToString().Equals(retList[i].SearchTag1)))
                            //        {
                            //            rows[0][COL_TIRE_KEY1] = retList[i].SearchTag1;
                            //            changColList.Add(COL_TIRE_KEY1);
                            //        }
                            //        // 商品タグ２ スタッドレス
                            //        if (((bool)rows[0][COL_TIRE_KEY2] == false) && (retList[i].SearchTag2 == "1") ||
                            //        ((bool)rows[0][COL_TIRE_KEY2] == true) && (retList[i].SearchTag2 == "0"))
                            //        {
                            //            rows[0][COL_TIRE_KEY2] = retList[i].SearchTag2.Equals("0") ? false : true;
                            //            changColList.Add(COL_TIRE_KEY2);
                            //        }
                            //        break;
                            //    case 2: //バッテリ
                            //        // // 商品タグ1 規格
                            //        if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_BATTERY_KEY1].ToString().Equals(retList[i].SearchTag1)))
                            //        {
                            //            rows[0][COL_BATTERY_KEY1] = retList[i].SearchTag1;
                            //            changColList.Add(COL_BATTERY_KEY1);
                            //        }

                            //        // 商品タグ2 適合
                            //        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_BATTERY_KEY2] != 1)
                            //        {
                            //            rows[0][COL_BATTERY_KEY2] = 1;
                            //            changColList.Add(COL_BATTERY_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 2)
                            //        {
                            //            rows[0][COL_BATTERY_KEY2] = 2;
                            //            changColList.Add(COL_BATTERY_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 3)
                            //        {
                            //            rows[0][COL_BATTERY_KEY2] = 3;
                            //            changColList.Add(COL_BATTERY_KEY2);
                            //        }
                            //        break;
                            //    case 3: // オイル

                            //        // 商品タグ1 粘度
                            //        if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_OIL_KEY1].ToString().Equals(retList[i].SearchTag1)))
                            //        {
                            //            rows[0][COL_OIL_KEY1] = retList[i].SearchTag1;
                            //            changColList.Add(COL_OIL_KEY1);
                            //        }

                            //        // 商品タグ2 適合
                            //        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_OIL_KEY2] != 1)
                            //        {
                            //            rows[0][COL_OIL_KEY2] = 1;
                            //            changColList.Add(COL_OIL_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 2)
                            //        {
                            //            rows[0][COL_OIL_KEY2] = 2;
                            //            changColList.Add(COL_OIL_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 3)
                            //        {
                            //            rows[0][COL_OIL_KEY2] = 3;
                            //            changColList.Add(COL_OIL_KEY2);
                            //        }
                            //        break;
                            //}

                            
                            //// 公開
                            //if (((bool)rows[0][COL_RELEASE] == false) && (retList[i].release == 1) ||
                            //    ((bool)rows[0][COL_RELEASE] == true ) && (retList[i].release == 0))
                            //{
                            //    rows[0][COL_RELEASE] = retList[i].release;
                            //    changColList.Add(COL_RELEASE);
                            //}
                    
                            //// オススメ
                            //if (((bool)rows[0][COL_RECOMMEND] == false) && (retList[i].recommend == 1) ||
                            //   ((bool)rows[0][COL_RECOMMEND] == true) && (retList[i].recommend == 0))
                            //{
                            //    rows[0][COL_RECOMMEND] = retList[i].recommend;
                            //    changColList.Add(COL_RECOMMEND);
                            //}
                            #endregion

                            // 更新行のIndexを取得
                            if (!changeList.ContainsKey(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0])))
                            {
                                changeList.Add(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0]), changColList);
                            }

                            // 行の粗利を計算
                            this.CalcGrossProc(ref rows[0]);
                            // 更新件数
                            updateCount++;
                        }
                        else
                        {
                            // 新規
                            // 追加
                            DataRow newRow = this.TBODataSet.Tables[TABLE_MAIN].NewRow();

                            if (retList[i].GoodsName != ct_ErrSt)
                            {
                                newRow[COL_GOODSNM] = retList[i].GoodsName;
                            }
                            if (retList[i].GoodsNo != ct_ErrSt)
                            {
                                newRow[COL_GOODSNO] = retList[i].GoodsNo;
                            }
                            if (retList[i].GoodsNote != ct_ErrSt)
                            {
                                newRow[COL_GOODSNOTE] = retList[i].GoodsNote;
                            }
                            if (retList[i].GoodsPR != ct_ErrSt)
                            {
                                newRow[COL_GOODSPR] = retList[i].GoodsPR;
                            } 

                            // メーカーリストにあればコード採用。提供の名称を反映

                            if (retList[i].MakerName != ct_ErrSt)
                            {
                                newRow[COL_MAKERNM] = retList[i].MakerName;
                            }

                            if (retList[i].GoodsMakerCd != ct_ErrInt)
                            {
                                if (this._makerCdDic.ContainsKey(retList[i].GoodsMakerCd))
                                {
                                    newRow[COL_MAKERCD] = retList[i].GoodsMakerCd;
                                    newRow[COL_MAKERNM] = this._makerCdDic[retList[i].GoodsMakerCd].MakerName;
                                }
                                else
                                {
                                    // リストになければクリア
                                    newRow[COL_MAKERCD] = 0;
                                }
                            }

                            // 発売日
                            if (retList[i].ReleaseDate != ct_ErrInt)
                            {
                                DateTime releaseDate = DateTime.MinValue;
                                try
                                {
                                    int releaseDateInt = retList[i].ReleaseDate;
                                    string releaseDateSt = retList[i].ReleaseDate.ToString();
                                    if (releaseDateSt.Length == 6)
                                    {
                                        releaseDateSt = ((releaseDateInt * 100) + 1).ToString();
                                    }
                                    // カルチャー設定
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    releaseDate = DateTime.ParseExact(releaseDateSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }

                                if (releaseDate != null && releaseDate != DateTime.MinValue)
                                {
                                    newRow[COL_RELEASEDATE] = releaseDate;
                                }
                            }

                            // 公開開始日
                            if (retList[i].ShopSaleBeginDate != ct_ErrInt)
                            {
                                DateTime beginDate = DateTime.MinValue;

                                try
                                {
                                    string beginDateIntSt = retList[i].ShopSaleBeginDate.ToString();
                                    // カルチャー設定
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    beginDate = DateTime.ParseExact(beginDateIntSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }
                                if (beginDate != null && beginDate != DateTime.MinValue)
                                {
                                    newRow[COL_SHOPSALEBEGINDATE] = beginDate;
                                }
                            }

                            // 公開終了日
                            if (retList[i].ShopSaleEndDate != ct_ErrInt)
                            {
                                DateTime endDate = DateTime.MinValue;
                                try
                                {
                                    string endDateSt = retList[i].ShopSaleEndDate.ToString();
                                    // カルチャー設定
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    endDate = DateTime.ParseExact(endDateSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }

                                if (endDate != null && endDate != DateTime.MinValue)
                                {
                                    newRow[COL_SHOPSALEENDDATE] = endDate;
                                }
                            }
                            
                            // 金額

                            // 標準価格（PM,SF共用）
                            if (retList[i].SuggestPrice != ct_ErrDouble)
                            {
                                newRow[COL_SUGGEST_PRICE] = Convert.ToInt64(retList[i].SuggestPrice);
                            }
                            // 店頭価格（PM,SF共用）
                            if (retList[i].ShopPrice != ct_ErrDouble)
                            {
                                newRow[COL_SHOP_PRICE] = Convert.ToInt64(retList[i].ShopPrice);
                            }

                            // 売価(PM時)、仕入原価(SF時)
                            if (retList[i].TradePrice != ct_ErrDouble)
                            {
                                newRow[COL_TRADE_PRICE] = Convert.ToInt64(retList[i].TradePrice);
                            }

                            // 仕入原価（PM用）
                            if (retList[i].PurchaseCost != ct_ErrDouble)
                            {
                                newRow[COL_PURCHASE_COST] = Convert.ToInt64(retList[i].PurchaseCost);
                            }

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                // 部品商モード

                                // 在庫状態
                                if (retList[i].StockStatusDiv != ct_Errshort)
                                {
                                    newRow[COL_STOCKSTATE] = retList[i].StockStatusDiv;
                                }
                            }
                            else
                            {
                                // 整備工場モード
                                // 在庫状態
                                newRow[COL_STOCKSTATE] = -1;
                            }

                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // タイヤ
                                    if (retList[i].SearchTag1 != ct_ErrSt)
                                    {
                                        newRow[COL_TIRE_KEY1] = retList[i].SearchTag1;
                                    }
                                    if (retList[i].SearchTag2 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("1"))
                                        {
                                            newRow[COL_TIRE_KEY2] = true;
                                        }
                                        else
                                        {
                                            newRow[COL_TIRE_KEY2] = false;
                                        }
                                    }
                                    break;
                                case 2: // バッテリ
                                    if (retList[i].SearchTag1 != ct_ErrSt)
                                    {
                                        newRow[COL_BATTERY_KEY1] = retList[i].SearchTag1;
                                    }
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 3;
                                        }
                                    }
                                    break;
                                case 3: // オイル
                                    if (retList[i].SearchTag1 != ct_ErrSt)
                                    {
                                        newRow[COL_OIL_KEY1] = retList[i].SearchTag1;
                                    }
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_OIL_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 3;
                                        }
                                    }
                                    break;
                            }
                      
                            // 公開
                            if (retList[i].release != ct_ErrInt)
                            {
                                newRow[COL_RELEASE] = retList[i].release;
                            }

                            // オススメ
                            if (retList[i].recommend != ct_ErrInt)
                            {
                                newRow[COL_RECOMMEND] = retList[i].recommend;
                            }

                            // 行の粗利を計算
                            this.CalcGrossProc(ref newRow);

                            this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(newRow);
                            // 新規件数
                            newCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品取込処理中に例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            finally
            {
                this.Goods_Grid.EndUpdate();
            }
            return st;
        }
        #endregion


        /// <summary>
        /// CSVインポート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // 保存確認
            if (CheckUpDate() == false) return;
            CsvImportForm form = new CsvImportForm();
            form.Icon = this.Icon;
            form._bootMode = this._bootPara.BootMode;

            form._categoryId = (long)this.Category_ComboEditor.Value;
            form._categoryName = this.Category_ComboEditor.Text;

            int st = 0;
            string errMsg = "";

            DialogResult ret = form.ShowCsvImportForm();
            if (ret == DialogResult.OK)
            {
                if (form._proposeGoodsList.Count == 0)
                {
                    // 取込データなし
                    TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                    CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                    "取込データがありません",			// 表示するメッセージ 
                    0,								    // ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                }
                else
                {
                    // 既存データ読込が行われていない場合は一旦抽出処理を行う
                    if (this.Section_ComboEditor.Enabled == true)
                    {
                        st = 0;
                        errMsg = "";
                        List<ProposeGoods> proposeGoodstList = new List<ProposeGoods>();
                        st = this.SearchGoodsProc(out proposeGoodstList, out errMsg);

                        if (st == 0)
                        {
                            // データを反映
                            this.SetDataTable(proposeGoodstList);
                            this.Section_ComboEditor.Enabled = false;
                            this.Search_button.Enabled = false;
                            this.Category_ComboEditor.Enabled = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                            errMsg,			                    // 表示するメッセージ 
                            st,								    // ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                            return;
                        }
                    }

                    // 抽出PGで抽出したデータを反映
                    int newCount;
                    int updateCount;
                    Dictionary<int, List<string>> changeList = new Dictionary<int, List<string>>();

                    //ピロピロ表示
                    Broadleaf.Windows.Forms.SFCMN00299CA waitForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
                    // 表示文字を設定
                    waitForm.Title = "取込中";
                    waitForm.Message = "現在、商品データの取込中です。";

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        waitForm.Show();

                        // 取込実行
                        st = this.ReflectCSVImportData(form._proposeGoodsList, out newCount, out updateCount, out changeList, out errMsg);

                        if (st == 0)
                        {
                            // 取込完了
                            if (changeList.Count > 0)
                            {
                                foreach (int rowIndex in changeList.Keys)
                                {
                                    foreach (string colNm in changeList[rowIndex])
                                    {
                                        this._initFlag = true;
                                        // 変更セルの文字色を変更
                                        if (this.Goods_Grid.Rows[rowIndex].Cells[colNm].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            if (colNm == COL_STOCKSTATE && (int)this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == -1)
                                            {
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                            }
                                            else if (colNm == COL_SHOPSALEENDDATE && this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == DBNull.Value)
                                            {
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.ForeColor = Color.Red;
                                            }
                                        }
                                    }
                                }
                            }

                            this.Cursor = Cursors.Default;
                            waitForm.Close();

                            this.UpDateGrid();

                            TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                            CT_ASSEMBLYID,						// アセンブリIDまたはクラスID
                            "取込が完了しました。"              // 表示するメッセージ 
                            + Environment.NewLine
                            + "新規:"
                            + newCount.ToString() + "件"
                            + Environment.NewLine
                            + "更新:"
                            + updateCount.ToString() + "件",
                            st,								    // ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        waitForm.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 金額一括計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcPrice_Button_Click(object sender, EventArgs e)
        {
            // 部品モード
            // 整備工場の店頭価格計算機能
            // 標準価格の80%
            // 販売価格の120%

            // 部品商の売価計算機能
            // 仕入原価の120%
            // 販売価格の90%
            // 標準価格の70%

            // 端数処理は四捨五入

            // 整備工場モード
            // 店頭価格の計算機能
            // 標準価格のXX%
            // 仕入原価のXX%

            if (this._calcPriceForm == null)
            {
                this._calcPriceForm = new CalcPriceForm(this._bootPara.BootMode);
                this._calcPriceForm.Icon = this.Icon;
                this._calcPriceForm._bootMode = this._bootPara.BootMode;
            }

            DialogResult ret = this._calcPriceForm.ShowCalcPriceForm();
            if (ret == DialogResult.OK)
            {
                this.Goods_Grid.BeginUpdate();

                bool calcSF = false;
                bool calcPM = false;
                // 金額再計算
                if (!string.IsNullOrEmpty(this._calcPriceForm._originCol_SF) && !string.IsNullOrEmpty(this._calcPriceForm._targetCol_SF) && this._calcPriceForm._percentage_SF != 0)
                {
                    calcSF = true;
                }

                if (!string.IsNullOrEmpty(this._calcPriceForm._originCol_PM) && !string.IsNullOrEmpty(this._calcPriceForm._targetCol_PM) && this._calcPriceForm._percentage_PM != 0)
                {
                    calcPM = true;
                }

                // 整備工場金額
                // 販売価格を再計算

                for (int i = 0; i < this.Goods_Grid.Rows.Count; i++)
                {
                    UltraGridRow row = this.Goods_Grid.Rows[i];

                    if (calcPM)
                    {
                        // 金額が未設定の商品のみ
                        if (this._calcPriceForm._calcDiv && GetCellLong(row.Cells[this._calcPriceForm._targetCol_PM].Value, 0) != 0) continue;
                        long retPrice = this.CalcPrice(GetCellLong(row.Cells[this._calcPriceForm._originCol_PM].Value, 0), this._calcPriceForm._percentage_PM, this._calcPriceForm._fracCd);
                        if (retPrice > 999999999)
                        {
                            retPrice = 999999999;
                        }
                        row.Cells[this._calcPriceForm._targetCol_PM].Value = retPrice;

                        // 行の粗利を計算
                        DataRow targetRow = this.TBODataSet.Tables[TABLE_MAIN].Rows[row.Index];
                        this.CalcGrossProc(ref targetRow);
                    }
                    if (calcSF)
                    {
                        // 金額が未設定の商品のみ
                        if (this._calcPriceForm._calcDiv && GetCellLong(row.Cells[this._calcPriceForm._targetCol_SF].Value, 0) != 0) continue;
                        long retPrice = this.CalcPrice(GetCellLong(row.Cells[this._calcPriceForm._originCol_SF].Value, 0), this._calcPriceForm._percentage_SF, this._calcPriceForm._fracCd);
                        if(retPrice > 999999999)
                        {
                            retPrice = 999999999;
                        }
                        row.Cells[this._calcPriceForm._targetCol_SF].Value = retPrice;

                        // 行の粗利を計算
                        DataRow targetRow = this.TBODataSet.Tables[TABLE_MAIN].Rows[row.Index];
                        this.CalcGrossProc(ref targetRow);
                    }
                }

                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();

                TMsgDisp.Show(
                  this,								// 親ウィンドウフォーム
                  emErrorLevel.ERR_LEVEL_INFO,	    // エラーレベル
                  CT_ASSEMBLYID,					// アセンブリIDまたはクラスID
                  "計算が完了しました。",           // 表示するメッセージ 
                  0,								// ステータス値
                  MessageBoxButtons.OK);			// 表示するボタン
            }
        }


        /// <summary>
        /// 金額再計算
        /// </summary>
        /// <param name="price">計算元金額</param>
        /// <param name="persentage">割合</param>
        /// <param name="fracCd">端数処理区分</param>
        /// <returns></returns>
        private long CalcPrice(long price, int persentage, int fracCd)
        {
            long retPrice = 0;
            double priceDouble = price;
            double Base = 100;
            double rate = persentage / Base;
            double targetPrice = priceDouble * rate;

            retPrice = (long)CalculateConsTax.Fraction(targetPrice, fracCd);
            return retPrice;
        }

        /// <summary>
        /// 上に挿入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertUpRow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 描画STOP
                this.Goods_Grid.BeginUpdate();

                int index = 0;
                if (this.Goods_Grid.Selected.Rows != null)
                {
                    // 論理削除行があるので一旦フィルターをクリア
                    this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = "";

                    foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                    {
                        if (row.Activated)
                        {
                            index = row.Index;
                            break;
                        }
                    }

                    for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
                    {
                        DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                        row[COL_DEL] = 0;          // 論理削除区分
                        row[COL_RELEASE] = true;        // 公開フラグ
                        row[COL_RECOMMEND] = false;    // オススメフラグ
                        row[COL_TIRE_KEY2] = false;
                        row[COL_BATTERY_KEY2] = 1;
                        row[COL_OIL_KEY2] = 1;
                        row[COL_STOCKSTATE] = -1; //TODO

                        // 行の粗利を計算
                        this.CalcGrossProc(ref row);

                        this.TBODataSet.Tables[TABLE_MAIN].Rows.InsertAt(row, index);
                        index++;
                    }

                    UltraGridRow ugRow = this.Goods_Grid.Rows[index];
                    if (ugRow != null)
                    {
                        UltraGridCell cell = ugRow.Cells[COL_RELEASE];
                        this.Goods_Grid.Focus();
                        cell.Row.Cells[COL_RELEASE].Activate();
                        cell.Selected = true;
                        cell.Activate();
                    }
                }
            }
            finally
            {
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// 下に挿入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertDownRow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (this.Goods_Grid.Selected.Rows != null)
            {
                foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                {
                    if (row.Activated)
                    {
                        index = row.Index;
                        break;
                    }
                }

                for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
                {
                    DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                    row[COL_DEL] = 0;          // 論理削除区分
                    row[COL_RELEASE] = true;        // 公開フラグ
                    row[COL_RECOMMEND] = false;    // オススメフラグ
                    row[COL_TIRE_KEY2] = false;
                    row[COL_BATTERY_KEY2] = 1;
                    row[COL_OIL_KEY2] = 1;
                    row[COL_STOCKSTATE] = -1; //TODO

                    // 行の粗利を計算
                    this.CalcGrossProc(ref row);

                    index++;
                    this.TBODataSet.Tables[TABLE_MAIN].Rows.InsertAt(row, index);
                }

                UltraGridRow ugRow = this.Goods_Grid.Rows[index];
                if (ugRow != null)
                {
                    UltraGridCell cell = ugRow.Cells[COL_RELEASE];
                    this.Goods_Grid.Focus();
                    cell.Row.Cells[COL_RELEASE].Activate();
                    cell.Selected = true;
                    cell.Activate();
                }

                this.UpDateGrid();

            }
        }

        /// <summary>
        /// 公開状況確認
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void proposeInfo_toolStripButton_Click(object sender, EventArgs e)
        {
            // 公開先選択画面を起動
            ReleaseSelectForm form = new ReleaseSelectForm();
            form.Icon = this.Icon;
            form._categoryID = (long)this.Category_ComboEditor.Value;
            form._categoryName = this.Category_ComboEditor.Text;
            form._enterpriseCode = this._bootPara.EnterpriseCode;
            form._enterpriseName = this._bootPara.EnterpriseName;
            form._sectionCode = this.Section_ComboEditor.Value.ToString();
            form._sectionName = this.Section_ComboEditor.Text;

            // 現在の拠点分のSCM接続情報を渡す
            if (this._scmSceDic.ContainsKey(form._sectionCode))
            {
                form._scmList = this._scmSceDic[form._sectionCode];
            }
            else
            {
                // 有効な公開先がない ありえないけど
                TMsgDisp.Show(
                this,							        // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                CT_ASSEMBLYID,					        // アセンブリIDまたはクラスID
                "公開先の取得に失敗しました",		    // 表示するメッセージ 
                -1,								        // ステータス値
                MessageBoxButtons.OK);
                return;
            }

            form._mode = 1;
            DialogResult ret = form.ShowReleaseSelectFrom();
        }

        /// <summary>
        /// Goods_Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_Enter(object sender, EventArgs e)
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                this.Goods_Grid.ActiveCell.Selected = true;
                this.Goods_Grid.ActiveCell.Activate();
                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }
            else
            {
                if (this.Goods_Grid.Rows.Count > 0)
                {
                    this.Goods_Grid.Rows[0].Cells[COL_RELEASE].Selected = true;
                    this.Goods_Grid.Rows[0].Cells[COL_RELEASE].Activate();
                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// 付随整備
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepairSet_Button_Click(object sender, EventArgs e)
        {
            // 更新チェック
            if (this.CheckUpDate())
            {
                AttendRepairSetForm form = new AttendRepairSetForm();
                form.Icon = this.Icon;
                form._categoryList = this._categoryList;
                form.ShowDialog(this._bootPara.EnterpriseCode, this._bootPara.BootMode);

                if (form._saveDiv)
                {
                    // 付随整備再読込
                    this.SetAttendRepairSet();

                    // 再読込
                    if (this.Category_ComboEditor.Enabled == false)
                    {
                        this.Search_button_Click(this, new EventArgs());
                    }
                }
            }
        }

        #region InnerClass

        /// <summary>
        /// グリッドのヘッダにチェックボックスを表示する為のフィルタークラス
        /// </summary>
        public class TBOCustomFilter : Infragistics.Win.IUIElementCreationFilter
        {
            #region イベント
            /// <summary>
            /// カラムヘッドのチェックボックスクリックイベント
            /// </summary>
            /// <param name="sender">対象オブジェクト</param>
            /// <param name="e">イベントパラメータ</param>
            /// <remarks>
            /// <br>Note　　　 : カラムヘッドのチェックボックスがクリックされた時に、発生します。</br>
            /// </remarks>
            public delegate void HeaderCheckBoxClickedHandler(object sender, HeaderCheckBoxEventArgs e);

            /// <summary>
            /// カラムヘッドのチェックボックスクリックイベント
            /// </summary>
            public event HeaderCheckBoxClickedHandler CheckChanged;

            /// <summary>
            /// Boolean型のカラムヘッドにチェックボックスを表示処理クラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note	   : Boolean型のカラムヘッドにチェックボックスを表示処理クラスインスタンス初期化処理を行います。。</br>
            /// </remarks>
            public TBOCustomFilter()
            {
                CheckChanged += new HeaderCheckBoxClickedHandler(CheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked);
            }

            /// <summary>
            /// カラムヘッドのチェックボックスのクリック イベント
            /// </summary>
            /// <param name="sender">対象オブジェクト</param>
            /// <param name="e">イベントパラメータ</param>
            /// <remarks>
            /// <br>Note　　　 : カラムヘッドのチェックボックスがクリックされた時に、発生します。</br>
            /// </remarks>
            private void CheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked(object sender, TBOCustomFilter.HeaderCheckBoxEventArgs e)
            {
                // カラムタイプ // 公開列のみ
                if (e.Header.Column.DataType == typeof(bool) && e.Header.Column.Key == COL_RELEASE)
                {
                    foreach (UltraGridRow aRow in e.Rows)
                    {
                        aRow.Cells[e.Header.Column.Index].Value = (e.CurrentCheckState == CheckState.Checked);
                    }
                }
            }

            /// <summary>
            /// カラムヘッドのチェックボックスのクリック イベント
            /// </summary>
            /// <param name="sender">対象オブジェクト</param>
            /// <param name="e">イベントパラメータ</param>
            /// <remarks>
            /// <br>Note　　　 : カラムヘッドのチェックボックスがクリックされた時に、発生します。</br>
            /// </remarks>
            private void CheckBoxUIElement_ElementClick(Object sender, Infragistics.Win.UIElementEventArgs e)
            {
                // クリックされたチェックボックスUI要素
                Infragistics.Win.CheckBoxUIElement aCheckBoxUIElement = (Infragistics.Win.CheckBoxUIElement)e.Element;

                // カラムヘッド
                Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader = (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)).GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                // チェック状態設定
                aColumnHeader.Tag = aCheckBoxUIElement.CheckState;

                // ヘッドUI要素
                HeaderUIElement aHeaderUIElement = aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)) as HeaderUIElement;

                // 行集合
                RowsCollection hRows = aHeaderUIElement.GetContext(typeof(RowsCollection)) as RowsCollection;

                // カラムヘッドのチェックボックスクリックイベント
                if (CheckChanged != null)
                    CheckChanged(this, new HeaderCheckBoxEventArgs(aColumnHeader, aCheckBoxUIElement.CheckState, hRows));
            }
            #endregion

            #region IUIElementCreationFilter メンバ
            /// <summary>
            /// BeforeCreateChildElements
            /// </summary>
            /// <param name="parent">UIElement</param>
            public bool BeforeCreateChildElements(Infragistics.Win.UIElement parent)
            {
                // 処理なし
                return false;
            }

            /// <summary>
            /// BeforeCreateChildElements
            /// </summary>
            /// <param name="parent">UIElement</param>
            /// <returns>bool</returns>
            public void AfterCreateChildElements(Infragistics.Win.UIElement parent)
            {
                // グループヘッダ・カラムヘッダ
                if (parent is HeaderUIElement)
                {
                    Infragistics.Win.UltraWinGrid.HeaderBase aHeader = ((HeaderUIElement)parent).Header;

                    // カラムタイプ　＝　bool ※公開列のみ
                    if (aHeader.Column.DataType == typeof(bool) && aHeader.Column.Key == COL_RELEASE)
                    {
                        Infragistics.Win.TextUIElement aTextUIElement;
                        Infragistics.Win.CheckBoxUIElement aCheckBoxUIElement = (Infragistics.Win.CheckBoxUIElement)parent.GetDescendant(typeof(Infragistics.Win.CheckBoxUIElement));

                        if (aCheckBoxUIElement == null)
                        {
                            aCheckBoxUIElement = new Infragistics.Win.CheckBoxUIElement(parent);
                        }

                        // XP テーマを使用します。
                        if (aCheckBoxUIElement.Appearance == null)
                            aCheckBoxUIElement.Appearance = new Infragistics.Win.Appearance();
                        aCheckBoxUIElement.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Opaque;

                        // テキスト取得
                        aTextUIElement = (Infragistics.Win.TextUIElement)parent.GetDescendant(typeof(Infragistics.Win.TextUIElement));

                        if (aTextUIElement == null)
                            return;

                        // カラムヘッダ
                        Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader =
                            (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement))
                            .GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                        // カラムチェックボックスの初期化
                        if (aColumnHeader.Tag == null)
                            aColumnHeader.Tag = CheckState.Unchecked;
                        else
                            aCheckBoxUIElement.CheckState = (CheckState)aColumnHeader.Tag;

                        // カラムヘッドのチェックボックスのクリックイベント
                        aCheckBoxUIElement.ElementClick += new Infragistics.Win.UIElementEventHandler(CheckBoxUIElement_ElementClick);

                        parent.ChildElements.Add(aCheckBoxUIElement);

                        // チェックボックスと列ヘッダーの左端の間に 3ピクセルの余白を設定します。
                        // また、チェックボックスが列ヘッダーの中段に表示されるようにします。
                        aCheckBoxUIElement.Rect = new Rectangle(
                        parent.Rect.X + 5,
                        parent.Rect.Y + ((parent.Rect.Height - aCheckBoxUIElement.CheckSize.Height) / 2),
                        aCheckBoxUIElement.CheckSize.Width,
                        aCheckBoxUIElement.CheckSize.Height);

                        // テキスト位置調整
                        aTextUIElement.Rect = new Rectangle(
                            aCheckBoxUIElement.Rect.Right + 3,
                            aTextUIElement.Rect.Y,
                            parent.Rect.Width - (aCheckBoxUIElement.Rect.Right - parent.Rect.X),
                            aTextUIElement.Rect.Height);
                    }
                    // カラムタイプ　＜＞　bool
                    else
                    {
                        Infragistics.Win.CheckBoxUIElement aCheckBoxUIElement = (Infragistics.Win.CheckBoxUIElement)parent.GetDescendant(typeof(Infragistics.Win.CheckBoxUIElement));

                        if (aCheckBoxUIElement != null)
                        {
                            parent.ChildElements.Remove(aCheckBoxUIElement);
                            aCheckBoxUIElement.Dispose();
                        }
                    }
                }
            }

            #endregion

            #region HeaderCheckBoxEventArgs
            /// <summary>
            /// イベントパラメータ
            /// </summary>
            /// <remarks>
            /// <br>Note　　　 : イベントパラメータです。</br>
            /// </remarks>
            public class HeaderCheckBoxEventArgs : EventArgs
            {
                // カラムヘッド
                private Infragistics.Win.UltraWinGrid.ColumnHeader mvarColumnHeader;
                // チェック状態
                private CheckState mvarCheckState;
                // 行集合
                private RowsCollection mvarRowsCollection;

                /// <summary>
                /// イベントパラメータクラスコンストラクタ
                /// </summary>
                /// <param name="hdrColumnHeader">カラムヘッド</param>
                /// <param name="chkCheckState">チェック状態</param>
                /// <param name="Rows">行集合</param>
                public HeaderCheckBoxEventArgs(Infragistics.Win.UltraWinGrid.ColumnHeader hdrColumnHeader, CheckState chkCheckState, RowsCollection Rows)
                {
                    mvarColumnHeader = hdrColumnHeader;
                    mvarCheckState = chkCheckState;
                    mvarRowsCollection = Rows;
                }

                /// <summary>
                /// 行集合
                /// </summary>
                public RowsCollection Rows
                {
                    get
                    {
                        return mvarRowsCollection;
                    }
                }

                /// <summary>
                /// カラムヘッド
                /// </summary>
                public Infragistics.Win.UltraWinGrid.ColumnHeader Header
                {
                    get
                    {
                        return mvarColumnHeader;
                    }
                }

                /// <summary>
                /// チェック状態
                /// </summary>
                public CheckState CurrentCheckState
                {
                    get
                    {
                        return mvarCheckState;
                    }
                    set
                    {
                        mvarCheckState = value;
                    }
                }
            }
            #endregion
        }   

        #endregion
    }
}