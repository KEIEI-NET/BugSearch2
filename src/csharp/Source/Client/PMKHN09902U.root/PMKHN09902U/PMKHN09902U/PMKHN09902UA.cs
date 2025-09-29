//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：李占川
// 修正日    2013/02/17     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号  10901273-00    作成担当 : donggy
// 作 成 日  2013/04/19     修正内容 :拠点を入力し赤字で呼び出した掛率等を修正した場合に、
//                                    黒字に置き換えて入力拠点で新規作成するように修正する
//----------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Excel;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率一括登録・修正ⅡUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率一括登録・修正ⅡUIフォームクラス</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2013/02/17</br>
    /// <br>Update Note : 2013/04/19 donggy</br>
    /// <br>管理番号    : 10901273-00 </br>
    /// <br>              Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
    /// <br>　　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
    /// </remarks>
    public partial class PMKHN09902UA : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09902U";

        //// 帳票名称
        private const string PDF_PRINT_NAME = "掛率マスタ一括修正・登録Ⅱ";

        // 帳票キー	
        private const string PDF_PRINT_KEY = "bf814cb3-97d8-4836-a2bd-618e232b300f";
        private string _printKey = PDF_PRINT_KEY;
        private string _GetDirectoryName = "";
        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09902U.dat";

        // グリッド列
        /// <summary>No</summary>
        public const string COLUMN_NO = "No";
        /// <summary>GoodsRateGrpCode</summary>
        public const string COLUMN_GOODSRATEGRPCODE = "GoodsRateGrpCode";
        /// <summary>GoodsRateRank</summary>
        public const string COLUMN_GOODSRATERANK = "GoodsRateRank";
        /// <summary>Glcd</summary>
        public const string COLUMN_GLCD = "Glcd";
        /// <summary>Blcd</summary>
        public const string COLUMN_BLCD = "Blcd";
        /// <summary>Name</summary>
        public const string COLUMN_NAME = "Name";
        /// <summary>MakerCode</summary>
        public const string COLUMN_MAKERCODE = "MakerCode";
        /// <summary>MakerName</summary>
        public const string COLUMN_MAKERNAME = "MakerName";
        /// <summary>SupplierCode</summary>
        public const string COLUMN_SUPPLIERCODE = "SupplierCode";
        /// <summary>CostRate</summary>
        public const string COLUMN_COSTRATE = "CostRate";
        /// <summary>ParentDiv</summary>
        public const string COLUMN_PARENTDIV = "ParentDiv";
        /// <summary>ExpandFlg</summary>
        public const string COLUMN_EXPANDFLG = "ExpandFlg";
        /// <summary>GoodsRateGrpCodeClone</summary>
        public const string COLUMN_GOODSRATEGRPCODE_HIDE = "GoodsRateGrpCodeClone";
        /// <summary>ExpandFlg</summary>
        public const string COLUMN_ENABLEFLG = "EnableFlg";

        // 売価率
        /// <summary>SaleRate</summary>
        public const string COLUMN_SALERATE = "SaleRate";
        /// <summary>SaleRate1</summary>
        public const string COLUMN_SALERATE1 = "SaleRate1";
        /// <summary>SaleRate2</summary>
        public const string COLUMN_SALERATE2 = "SaleRate2";
        /// <summary>SaleRate3</summary>
        public const string COLUMN_SALERATE3 = "SaleRate3";
        /// <summary>SaleRate4</summary>
        public const string COLUMN_SALERATE4 = "SaleRate4";
        /// <summary>SaleRate5</summary>
        public const string COLUMN_SALERATE5 = "SaleRate5";
        /// <summary>SaleRate6</summary>
        public const string COLUMN_SALERATE6 = "SaleRate6";
        /// <summary>SaleRate7</summary>
        public const string COLUMN_SALERATE7 = "SaleRate7";
        /// <summary>SaleRate8</summary>
        public const string COLUMN_SALERATE8 = "SaleRate8";
        /// <summary>SaleRate9</summary>
        public const string COLUMN_SALERATE9 = "SaleRate9";
        /// <summary>SaleRate10</summary>
        public const string COLUMN_SALERATE10 = "SaleRate10";
        /// <summary>SaleRate11</summary>
        public const string COLUMN_SALERATE11 = "SaleRate11";
        /// <summary>SaleRate12</summary>
        public const string COLUMN_SALERATE12 = "SaleRate12";
        /// <summary>SaleRate13</summary>
        public const string COLUMN_SALERATE13 = "SaleRate13";
        /// <summary>SaleRate14</summary>
        public const string COLUMN_SALERATE14 = "SaleRate14";
        /// <summary>SaleRate15</summary>
        public const string COLUMN_SALERATE15 = "SaleRate15";
        /// <summary>SaleRate16</summary>
        public const string COLUMN_SALERATE16 = "SaleRate16";
        /// <summary>SaleRate17</summary>
        public const string COLUMN_SALERATE17 = "SaleRate17";
        /// <summary>SaleRate18</summary>
        public const string COLUMN_SALERATE18 = "SaleRate18";
        /// <summary>SaleRate19</summary>
        public const string COLUMN_SALERATE19 = "SaleRate19";
        /// <summary>SaleRate20</summary>
        public const string COLUMN_SALERATE20 = "SaleRate20";
        /// <summary>SaleRate21</summary>
        public const string COLUMN_SALERATE21 = "SaleRate21";
        /// <summary>SaleRate22</summary>
        public const string COLUMN_SALERATE22 = "SaleRate22";
        /// <summary>SaleRate23</summary>
        public const string COLUMN_SALERATE23 = "SaleRate23";
        /// <summary>SaleRate24</summary>
        public const string COLUMN_SALERATE24 = "SaleRate24";
        /// <summary>SaleRate25</summary>
        public const string COLUMN_SALERATE25 = "SaleRate25";
        /// <summary>SaleRate26</summary>
        public const string COLUMN_SALERATE26 = "SaleRate26";
        /// <summary>SaleRate27</summary>
        public const string COLUMN_SALERATE27 = "SaleRate27";
        /// <summary>SaleRate28</summary>
        public const string COLUMN_SALERATE28 = "SaleRate28";
        /// <summary>SaleRate29</summary>
        public const string COLUMN_SALERATE29 = "SaleRate29";
        /// <summary>SaleRate30</summary>
        public const string COLUMN_SALERATE30 = "SaleRate30";
        /// <summary>SaleRate31</summary>
        public const string COLUMN_SALERATE31 = "SaleRate31";
        /// <summary>SaleRate32</summary>
        public const string COLUMN_SALERATE32 = "SaleRate32";
        /// <summary>SaleRate33</summary>
        public const string COLUMN_SALERATE33 = "SaleRate33";
        /// <summary>SaleRate34</summary>
        public const string COLUMN_SALERATE34 = "SaleRate34";
        /// <summary>SaleRate35</summary>
        public const string COLUMN_SALERATE35 = "SaleRate35";
        /// <summary>SaleRate36</summary>
        public const string COLUMN_SALERATE36 = "SaleRate36";
        /// <summary>SaleRate37</summary>
        public const string COLUMN_SALERATE37 = "SaleRate37";
        /// <summary>SaleRate38</summary>
        public const string COLUMN_SALERATE38 = "SaleRate38";
        /// <summary>SaleRate39</summary>
        public const string COLUMN_SALERATE39 = "SaleRate39";
        /// <summary>SaleRate40</summary>
        public const string COLUMN_SALERATE40 = "SaleRate40";
        /// <summary>SaleRate41</summary>
        public const string COLUMN_SALERATE41 = "SaleRate41";
        /// <summary>SaleRate42</summary>
        public const string COLUMN_SALERATE42 = "SaleRate42";
        /// <summary>SaleRate43</summary>
        public const string COLUMN_SALERATE43 = "SaleRate43";
        /// <summary>SaleRate44</summary>
        public const string COLUMN_SALERATE44 = "SaleRate44";
        /// <summary>SaleRate45</summary>
        public const string COLUMN_SALERATE45 = "SaleRate45";
        /// <summary>SaleRate46</summary>
        public const string COLUMN_SALERATE46 = "SaleRate46";
        /// <summary>SaleRate47</summary>
        public const string COLUMN_SALERATE47 = "SaleRate47";
        /// <summary>SaleRate48</summary>
        public const string COLUMN_SALERATE48 = "SaleRate48";
        /// <summary>SaleRate49</summary>
        public const string COLUMN_SALERATE49 = "SaleRate49";
        /// <summary>SaleRate50</summary>
        public const string COLUMN_SALERATE50 = "SaleRate50";
        /// <summary>SaleRate51</summary>
        public const string COLUMN_SALERATE51 = "SaleRate51";
        /// <summary>SaleRate52</summary>
        public const string COLUMN_SALERATE52 = "SaleRate52";
        /// <summary>SaleRate53</summary>
        public const string COLUMN_SALERATE53 = "SaleRate53";
        /// <summary>SaleRate54</summary>
        public const string COLUMN_SALERATE54 = "SaleRate54";
        /// <summary>SaleRate55</summary>
        public const string COLUMN_SALERATE55 = "SaleRate55";
        /// <summary>SaleRate56</summary>
        public const string COLUMN_SALERATE56 = "SaleRate56";
        /// <summary>SaleRate57</summary>
        public const string COLUMN_SALERATE57 = "SaleRate57";
        /// <summary>SaleRate58</summary>
        public const string COLUMN_SALERATE58 = "SaleRate58";
        /// <summary>SaleRate59</summary>
        public const string COLUMN_SALERATE59 = "SaleRate59";
        /// <summary>SaleRate60</summary>
        public const string COLUMN_SALERATE60 = "SaleRate60";
        /// <summary>SaleRate61</summary>
        public const string COLUMN_SALERATE61 = "SaleRate61";
        /// <summary>SaleRate62</summary>
        public const string COLUMN_SALERATE62 = "SaleRate62";
        /// <summary>SaleRate63</summary>
        public const string COLUMN_SALERATE63 = "SaleRate63";
        /// <summary>SaleRate64</summary>
        public const string COLUMN_SALERATE64 = "SaleRate64";
        /// <summary>SaleRate65</summary>
        public const string COLUMN_SALERATE65 = "SaleRate65";
        /// <summary>SaleRate66</summary>
        public const string COLUMN_SALERATE66 = "SaleRate66";
        /// <summary>SaleRate67</summary>
        public const string COLUMN_SALERATE67 = "SaleRate67";
        /// <summary>SaleRate68</summary>
        public const string COLUMN_SALERATE68 = "SaleRate68";
        /// <summary>SaleRate69</summary>
        public const string COLUMN_SALERATE69 = "SaleRate69";
        /// <summary>SaleRate70</summary>
        public const string COLUMN_SALERATE70 = "SaleRate70";
        /// <summary>SaleRate71</summary>
        public const string COLUMN_SALERATE71 = "SaleRate71";
        /// <summary>SaleRate72</summary>
        public const string COLUMN_SALERATE72 = "SaleRate72";
        /// <summary>SaleRate73</summary>
        public const string COLUMN_SALERATE73 = "SaleRate73";
        /// <summary>SaleRate74</summary>
        public const string COLUMN_SALERATE74 = "SaleRate74";
        /// <summary>SaleRate75</summary>
        public const string COLUMN_SALERATE75 = "SaleRate75";
        /// <summary>SaleRate76</summary>
        public const string COLUMN_SALERATE76 = "SaleRate76";
        /// <summary>SaleRate77</summary>
        public const string COLUMN_SALERATE77 = "SaleRate77";
        /// <summary>SaleRate78</summary>
        public const string COLUMN_SALERATE78 = "SaleRate78";
        /// <summary>SaleRate79</summary>
        public const string COLUMN_SALERATE79 = "SaleRate79";
        /// <summary>SaleRate80</summary>
        public const string COLUMN_SALERATE80 = "SaleRate80";
        /// <summary>SaleRate81</summary>
        public const string COLUMN_SALERATE81 = "SaleRate81";
        /// <summary>SaleRate82</summary>
        public const string COLUMN_SALERATE82 = "SaleRate82";
        /// <summary>SaleRate83</summary>
        public const string COLUMN_SALERATE83 = "SaleRate83";
        /// <summary>SaleRate84</summary>
        public const string COLUMN_SALERATE84 = "SaleRate84";
        /// <summary>SaleRate85</summary>
        public const string COLUMN_SALERATE85 = "SaleRate85";
        /// <summary>SaleRate86</summary>
        public const string COLUMN_SALERATE86 = "SaleRate86";
        /// <summary>SaleRate87</summary>
        public const string COLUMN_SALERATE87 = "SaleRate87";
        /// <summary>SaleRate88</summary>
        public const string COLUMN_SALERATE88 = "SaleRate88";
        /// <summary>SaleRate89</summary>
        public const string COLUMN_SALERATE89 = "SaleRate89";
        /// <summary>SaleRate90</summary>
        public const string COLUMN_SALERATE90 = "SaleRate90";
        /// <summary>SaleRate91</summary>
        public const string COLUMN_SALERATE91 = "SaleRate91";
        /// <summary>SaleRate92</summary>
        public const string COLUMN_SALERATE92 = "SaleRate92";
        /// <summary>SaleRate93</summary>
        public const string COLUMN_SALERATE93 = "SaleRate93";
        /// <summary>SaleRate94</summary>
        public const string COLUMN_SALERATE94 = "SaleRate94";
        /// <summary>SaleRate95</summary>
        public const string COLUMN_SALERATE95 = "SaleRate95";
        /// <summary>SaleRate96</summary>
        public const string COLUMN_SALERATE96 = "SaleRate96";
        /// <summary>SaleRate97</summary>
        public const string COLUMN_SALERATE97 = "SaleRate97";
        /// <summary>SaleRate98</summary>
        public const string COLUMN_SALERATE98 = "SaleRate98";
        /// <summary>SaleRate99</summary>
        public const string COLUMN_SALERATE99 = "SaleRate99";
        /// <summary>SaleRate100</summary>
        public const string COLUMN_SALERATE100 = "SaleRate100";

        // 原価ＵＰ率
        /// <summary>UpRate</summary>
        public const string COLUMN_UPRATE = "UpRate";
        /// <summary>UpRate1</summary>
        public const string COLUMN_UPRATE1 = "UpRate1";
        /// <summary>UpRate2</summary>
        public const string COLUMN_UPRATE2 = "UpRate2";
        /// <summary>UpRate3</summary>
        public const string COLUMN_UPRATE3 = "UpRate3";
        /// <summary>UpRate4</summary>
        public const string COLUMN_UPRATE4 = "UpRate4";
        /// <summary>UpRate5</summary>
        public const string COLUMN_UPRATE5 = "UpRate5";
        /// <summary>UpRate6</summary>
        public const string COLUMN_UPRATE6 = "UpRate6";
        /// <summary>UpRate7</summary>
        public const string COLUMN_UPRATE7 = "UpRate7";
        /// <summary>UpRate8</summary>
        public const string COLUMN_UPRATE8 = "UpRate8";
        /// <summary>UpRate9</summary>
        public const string COLUMN_UPRATE9 = "UpRate9";
        /// <summary>UpRate10</summary>
        public const string COLUMN_UPRATE10 = "UpRate10";
        /// <summary>UpRate11</summary>
        public const string COLUMN_UPRATE11 = "UpRate11";
        /// <summary>UpRate12</summary>
        public const string COLUMN_UPRATE12 = "UpRate12";
        /// <summary>UpRate13</summary>
        public const string COLUMN_UPRATE13 = "UpRate13";
        /// <summary>UpRate14</summary>
        public const string COLUMN_UPRATE14 = "UpRate14";
        /// <summary>UpRate15</summary>
        public const string COLUMN_UPRATE15 = "UpRate15";
        /// <summary>UpRate16</summary>
        public const string COLUMN_UPRATE16 = "UpRate16";
        /// <summary>UpRate17</summary>
        public const string COLUMN_UPRATE17 = "UpRate17";
        /// <summary>UpRate18</summary>
        public const string COLUMN_UPRATE18 = "UpRate18";
        /// <summary>UpRate19</summary>
        public const string COLUMN_UPRATE19 = "UpRate19";
        /// <summary>UpRate20</summary>
        public const string COLUMN_UPRATE20 = "UpRate20";
        /// <summary>UpRate21</summary>
        public const string COLUMN_UPRATE21 = "UpRate21";
        /// <summary>UpRate22</summary>
        public const string COLUMN_UPRATE22 = "UpRate22";
        /// <summary>UpRate23</summary>
        public const string COLUMN_UPRATE23 = "UpRate23";
        /// <summary>UpRate24</summary>
        public const string COLUMN_UPRATE24 = "UpRate24";
        /// <summary>UpRate25</summary>
        public const string COLUMN_UPRATE25 = "UpRate25";
        /// <summary>UpRate26</summary>
        public const string COLUMN_UPRATE26 = "UpRate26";
        /// <summary>UpRate27</summary>
        public const string COLUMN_UPRATE27 = "UpRate27";
        /// <summary>UpRate28</summary>
        public const string COLUMN_UPRATE28 = "UpRate28";
        /// <summary>UpRate29</summary>
        public const string COLUMN_UPRATE29 = "UpRate29";
        /// <summary>UpRate30</summary>
        public const string COLUMN_UPRATE30 = "UpRate30";
        /// <summary>UpRate31</summary>
        public const string COLUMN_UPRATE31 = "UpRate31";
        /// <summary>UpRate32</summary>
        public const string COLUMN_UPRATE32 = "UpRate32";
        /// <summary>UpRate33</summary>
        public const string COLUMN_UPRATE33 = "UpRate33";
        /// <summary>UpRate34</summary>
        public const string COLUMN_UPRATE34 = "UpRate34";
        /// <summary>UpRate35</summary>
        public const string COLUMN_UPRATE35 = "UpRate35";
        /// <summary>UpRate36</summary>
        public const string COLUMN_UPRATE36 = "UpRate36";
        /// <summary>UpRate37</summary>
        public const string COLUMN_UPRATE37 = "UpRate37";
        /// <summary>UpRate38</summary>
        public const string COLUMN_UPRATE38 = "UpRate38";
        /// <summary>UpRate39</summary>
        public const string COLUMN_UPRATE39 = "UpRate39";
        /// <summary>UpRate40</summary>
        public const string COLUMN_UPRATE40 = "UpRate40";
        /// <summary>UpRate41</summary>
        public const string COLUMN_UPRATE41 = "UpRate41";
        /// <summary>UpRate42</summary>
        public const string COLUMN_UPRATE42 = "UpRate42";
        /// <summary>UpRate43</summary>
        public const string COLUMN_UPRATE43 = "UpRate43";
        /// <summary>UpRate44</summary>
        public const string COLUMN_UPRATE44 = "UpRate44";
        /// <summary>UpRate45</summary>
        public const string COLUMN_UPRATE45 = "UpRate45";
        /// <summary>UpRate46</summary>
        public const string COLUMN_UPRATE46 = "UpRate46";
        /// <summary>UpRate47</summary>
        public const string COLUMN_UPRATE47 = "UpRate47";
        /// <summary>UpRate48</summary>
        public const string COLUMN_UPRATE48 = "UpRate48";
        /// <summary>UpRate49</summary>
        public const string COLUMN_UPRATE49 = "UpRate49";
        /// <summary>UpRate50</summary>
        public const string COLUMN_UPRATE50 = "UpRate50";
        /// <summary>UpRate51</summary>
        public const string COLUMN_UPRATE51 = "UpRate51";
        /// <summary>UpRate52</summary>
        public const string COLUMN_UPRATE52 = "UpRate52";
        /// <summary>UpRate53</summary>
        public const string COLUMN_UPRATE53 = "UpRate53";
        /// <summary>UpRate54</summary>
        public const string COLUMN_UPRATE54 = "UpRate54";
        /// <summary>UpRate55</summary>
        public const string COLUMN_UPRATE55 = "UpRate55";
        /// <summary>UpRate56</summary>
        public const string COLUMN_UPRATE56 = "UpRate56";
        /// <summary>UpRate57</summary>
        public const string COLUMN_UPRATE57 = "UpRate57";
        /// <summary>UpRate58</summary>
        public const string COLUMN_UPRATE58 = "UpRate58";
        /// <summary>UpRate59</summary>
        public const string COLUMN_UPRATE59 = "UpRate59";
        /// <summary>UpRate60</summary>
        public const string COLUMN_UPRATE60 = "UpRate60";
        /// <summary>UpRate61</summary>
        public const string COLUMN_UPRATE61 = "UpRate61";
        /// <summary>UpRate62</summary>
        public const string COLUMN_UPRATE62 = "UpRate62";
        /// <summary>UpRate63</summary>
        public const string COLUMN_UPRATE63 = "UpRate63";
        /// <summary>UpRate64</summary>
        public const string COLUMN_UPRATE64 = "UpRate64";
        /// <summary>UpRate65</summary>
        public const string COLUMN_UPRATE65 = "UpRate65";
        /// <summary>UpRate66</summary>
        public const string COLUMN_UPRATE66 = "UpRate66";
        /// <summary>UpRate67</summary>
        public const string COLUMN_UPRATE67 = "UpRate67";
        /// <summary>UpRate68</summary>
        public const string COLUMN_UPRATE68 = "UpRate68";
        /// <summary>UpRate69</summary>
        public const string COLUMN_UPRATE69 = "UpRate69";
        /// <summary>UpRate70</summary>
        public const string COLUMN_UPRATE70 = "UpRate70";
        /// <summary>UpRate71</summary>
        public const string COLUMN_UPRATE71 = "UpRate71";
        /// <summary>UpRate72</summary>
        public const string COLUMN_UPRATE72 = "UpRate72";
        /// <summary>UpRate73</summary>
        public const string COLUMN_UPRATE73 = "UpRate73";
        /// <summary>UpRate74</summary>
        public const string COLUMN_UPRATE74 = "UpRate74";
        /// <summary>UpRate75</summary>
        public const string COLUMN_UPRATE75 = "UpRate75";
        /// <summary>UpRate76</summary>
        public const string COLUMN_UPRATE76 = "UpRate76";
        /// <summary>UpRate77</summary>
        public const string COLUMN_UPRATE77 = "UpRate77";
        /// <summary>UpRate78</summary>
        public const string COLUMN_UPRATE78 = "UpRate78";
        /// <summary>UpRate79</summary>
        public const string COLUMN_UPRATE79 = "UpRate79";
        /// <summary>UpRate80</summary>
        public const string COLUMN_UPRATE80 = "UpRate80";
        /// <summary>UpRate81</summary>
        public const string COLUMN_UPRATE81 = "UpRate81";
        /// <summary>UpRate82</summary>
        public const string COLUMN_UPRATE82 = "UpRate82";
        /// <summary>UpRate83</summary>
        public const string COLUMN_UPRATE83 = "UpRate83";
        /// <summary>UpRate84</summary>
        public const string COLUMN_UPRATE84 = "UpRate84";
        /// <summary>UpRate85</summary>
        public const string COLUMN_UPRATE85 = "UpRate85";
        /// <summary>UpRate86</summary>
        public const string COLUMN_UPRATE86 = "UpRate86";
        /// <summary>UpRate87</summary>
        public const string COLUMN_UPRATE87 = "UpRate87";
        /// <summary>UpRate88</summary>
        public const string COLUMN_UPRATE88 = "UpRate88";
        /// <summary>UpRate89</summary>
        public const string COLUMN_UPRATE89 = "UpRate89";
        /// <summary>UpRate90</summary>
        public const string COLUMN_UPRATE90 = "UpRate90";
        /// <summary>UpRate91</summary>
        public const string COLUMN_UPRATE91 = "UpRate91";
        /// <summary>UpRate92</summary>
        public const string COLUMN_UPRATE92 = "UpRate92";
        /// <summary>UpRate93</summary>
        public const string COLUMN_UPRATE93 = "UpRate93";
        /// <summary>UpRate94</summary>
        public const string COLUMN_UPRATE94 = "UpRate94";
        /// <summary>UpRate95</summary>
        public const string COLUMN_UPRATE95 = "UpRate95";
        /// <summary>UpRate96</summary>
        public const string COLUMN_UPRATE96 = "UpRate96";
        /// <summary>UpRate97</summary>
        public const string COLUMN_UPRATE97 = "UpRate97";
        /// <summary>UpRate98</summary>
        public const string COLUMN_UPRATE98 = "UpRate98";
        /// <summary>UpRate99</summary>
        public const string COLUMN_UPRATE99 = "UpRate99";
        /// <summary>UpRate100</summary>
        public const string COLUMN_UPRATE100 = "UpRate100";

        // 粗利確保率
        /// <summary>GrsProfitSecureRat</summary>
        public const string COLUMN_GRSPROFITSECURERAT = "GrsProfitSecureRat";
        /// <summary>GrsProfitSecureRat1</summary>
        public const string COLUMN_GRSPROFITSECURERAT1 = "GrsProfitSecureRat1";
        /// <summary>GrsProfitSecureRat2</summary>
        public const string COLUMN_GRSPROFITSECURERAT2 = "GrsProfitSecureRat2";
        /// <summary>GrsProfitSecureRat3</summary>
        public const string COLUMN_GRSPROFITSECURERAT3 = "GrsProfitSecureRat3";
        /// <summary>GrsProfitSecureRat4</summary>
        public const string COLUMN_GRSPROFITSECURERAT4 = "GrsProfitSecureRat4";
        /// <summary>GrsProfitSecureRat5</summary>
        public const string COLUMN_GRSPROFITSECURERAT5 = "GrsProfitSecureRat5";
        /// <summary>GrsProfitSecureRat6</summary>
        public const string COLUMN_GRSPROFITSECURERAT6 = "GrsProfitSecureRat6";
        /// <summary>GrsProfitSecureRat7</summary>
        public const string COLUMN_GRSPROFITSECURERAT7 = "GrsProfitSecureRat7";
        /// <summary>GrsProfitSecureRat8</summary>
        public const string COLUMN_GRSPROFITSECURERAT8 = "GrsProfitSecureRat8";
        /// <summary>GrsProfitSecureRat9</summary>
        public const string COLUMN_GRSPROFITSECURERAT9 = "GrsProfitSecureRat9";
        /// <summary>GrsProfitSecureRat10</summary>
        public const string COLUMN_GRSPROFITSECURERAT10 = "GrsProfitSecureRat10";
        /// <summary>GrsProfitSecureRat9</summary>
        public const string COLUMN_GRSPROFITSECURERAT11 = "GrsProfitSecureRat11";
        /// <summary>GrsProfitSecureRat12</summary>
        public const string COLUMN_GRSPROFITSECURERAT12 = "GrsProfitSecureRat12";
        /// <summary>GrsProfitSecureRat13</summary>
        public const string COLUMN_GRSPROFITSECURERAT13 = "GrsProfitSecureRat13";
        /// <summary>GrsProfitSecureRat14</summary>
        public const string COLUMN_GRSPROFITSECURERAT14 = "GrsProfitSecureRat14";
        /// <summary>GrsProfitSecureRat15</summary>
        public const string COLUMN_GRSPROFITSECURERAT15 = "GrsProfitSecureRat15";
        /// <summary>GrsProfitSecureRat16</summary>
        public const string COLUMN_GRSPROFITSECURERAT16 = "GrsProfitSecureRat16";
        /// <summary>GrsProfitSecureRat17</summary>
        public const string COLUMN_GRSPROFITSECURERAT17 = "GrsProfitSecureRat17";
        /// <summary>GrsProfitSecureRat18</summary>
        public const string COLUMN_GRSPROFITSECURERAT18 = "GrsProfitSecureRat18";
        /// <summary>GrsProfitSecureRat19</summary>
        public const string COLUMN_GRSPROFITSECURERAT19 = "GrsProfitSecureRat19";
        /// <summary>GrsProfitSecureRat20</summary>
        public const string COLUMN_GRSPROFITSECURERAT20 = "GrsProfitSecureRat20";
        /// <summary>GrsProfitSecureRat21</summary>
        public const string COLUMN_GRSPROFITSECURERAT21 = "GrsProfitSecureRat21";
        /// <summary>GrsProfitSecureRat22</summary>
        public const string COLUMN_GRSPROFITSECURERAT22 = "GrsProfitSecureRat22";
        /// <summary>GrsProfitSecureRat23</summary>
        public const string COLUMN_GRSPROFITSECURERAT23 = "GrsProfitSecureRat23";
        /// <summary>GrsProfitSecureRat24</summary>
        public const string COLUMN_GRSPROFITSECURERAT24 = "GrsProfitSecureRat24";
        /// <summary>GrsProfitSecureRat25</summary>
        public const string COLUMN_GRSPROFITSECURERAT25 = "GrsProfitSecureRat25";
        /// <summary>GrsProfitSecureRat26</summary>
        public const string COLUMN_GRSPROFITSECURERAT26 = "GrsProfitSecureRat26";
        /// <summary>GrsProfitSecureRat27</summary>
        public const string COLUMN_GRSPROFITSECURERAT27 = "GrsProfitSecureRat27";
        /// <summary>GrsProfitSecureRat28</summary>
        public const string COLUMN_GRSPROFITSECURERAT28 = "GrsProfitSecureRat28";
        /// <summary>GrsProfitSecureRat29</summary>
        public const string COLUMN_GRSPROFITSECURERAT29 = "GrsProfitSecureRat29";
        /// <summary>GrsProfitSecureRat30</summary>
        public const string COLUMN_GRSPROFITSECURERAT30 = "GrsProfitSecureRat30";
        /// <summary>GrsProfitSecureRat31</summary>
        public const string COLUMN_GRSPROFITSECURERAT31 = "GrsProfitSecureRat31";
        /// <summary>GrsProfitSecureRat32</summary>
        public const string COLUMN_GRSPROFITSECURERAT32 = "GrsProfitSecureRat32";
        /// <summary>GrsProfitSecureRat33</summary>
        public const string COLUMN_GRSPROFITSECURERAT33 = "GrsProfitSecureRat33";
        /// <summary>GrsProfitSecureRat34</summary>
        public const string COLUMN_GRSPROFITSECURERAT34 = "GrsProfitSecureRat34";
        /// <summary>GrsProfitSecureRat35</summary>
        public const string COLUMN_GRSPROFITSECURERAT35 = "GrsProfitSecureRat35";
        /// <summary>GrsProfitSecureRat36</summary>
        public const string COLUMN_GRSPROFITSECURERAT36 = "GrsProfitSecureRat36";
        /// <summary>GrsProfitSecureRat37</summary>
        public const string COLUMN_GRSPROFITSECURERAT37 = "GrsProfitSecureRat37";
        /// <summary>GrsProfitSecureRat38</summary>
        public const string COLUMN_GRSPROFITSECURERAT38 = "GrsProfitSecureRat38";
        /// <summary>GrsProfitSecureRat39</summary>
        public const string COLUMN_GRSPROFITSECURERAT39 = "GrsProfitSecureRat39";
        /// <summary>GrsProfitSecureRat40</summary>
        public const string COLUMN_GRSPROFITSECURERAT40 = "GrsProfitSecureRat40";
        /// <summary>GrsProfitSecureRat41</summary>
        public const string COLUMN_GRSPROFITSECURERAT41 = "GrsProfitSecureRat41";
        /// <summary>GrsProfitSecureRat42</summary>
        public const string COLUMN_GRSPROFITSECURERAT42 = "GrsProfitSecureRat42";
        /// <summary>GrsProfitSecureRat43</summary>
        public const string COLUMN_GRSPROFITSECURERAT43 = "GrsProfitSecureRat43";
        /// <summary>GrsProfitSecureRat44</summary>
        public const string COLUMN_GRSPROFITSECURERAT44 = "GrsProfitSecureRat44";
        /// <summary>GrsProfitSecureRat45</summary>
        public const string COLUMN_GRSPROFITSECURERAT45 = "GrsProfitSecureRat45";
        /// <summary>GrsProfitSecureRat46</summary>
        public const string COLUMN_GRSPROFITSECURERAT46 = "GrsProfitSecureRat46";
        /// <summary>GrsProfitSecureRat47</summary>
        public const string COLUMN_GRSPROFITSECURERAT47 = "GrsProfitSecureRat47";
        /// <summary>GrsProfitSecureRat48</summary>
        public const string COLUMN_GRSPROFITSECURERAT48 = "GrsProfitSecureRat48";
        /// <summary>GrsProfitSecureRat49</summary>
        public const string COLUMN_GRSPROFITSECURERAT49 = "GrsProfitSecureRat49";
        /// <summary>GrsProfitSecureRat50</summary>
        public const string COLUMN_GRSPROFITSECURERAT50 = "GrsProfitSecureRat50";
        /// <summary>GrsProfitSecureRat51</summary>
        public const string COLUMN_GRSPROFITSECURERAT51 = "GrsProfitSecureRat51";
        /// <summary>GrsProfitSecureRat52</summary>
        public const string COLUMN_GRSPROFITSECURERAT52 = "GrsProfitSecureRat52";
        /// <summary>GrsProfitSecureRat53</summary>
        public const string COLUMN_GRSPROFITSECURERAT53 = "GrsProfitSecureRat53";
        /// <summary>GrsProfitSecureRat54</summary>
        public const string COLUMN_GRSPROFITSECURERAT54 = "GrsProfitSecureRat54";
        /// <summary>GrsProfitSecureRat55</summary>
        public const string COLUMN_GRSPROFITSECURERAT55 = "GrsProfitSecureRat55";
        /// <summary>GrsProfitSecureRat56</summary>
        public const string COLUMN_GRSPROFITSECURERAT56 = "GrsProfitSecureRat56";
        /// <summary>GrsProfitSecureRat57</summary>
        public const string COLUMN_GRSPROFITSECURERAT57 = "GrsProfitSecureRat57";
        /// <summary>GrsProfitSecureRat58</summary>
        public const string COLUMN_GRSPROFITSECURERAT58 = "GrsProfitSecureRat58";
        /// <summary>GrsProfitSecureRat59</summary>
        public const string COLUMN_GRSPROFITSECURERAT59 = "GrsProfitSecureRat59";
        /// <summary>GrsProfitSecureRat60</summary>
        public const string COLUMN_GRSPROFITSECURERAT60 = "GrsProfitSecureRat60";
        /// <summary>GrsProfitSecureRat61</summary>
        public const string COLUMN_GRSPROFITSECURERAT61 = "GrsProfitSecureRat61";
        /// <summary>GrsProfitSecureRat62</summary>
        public const string COLUMN_GRSPROFITSECURERAT62 = "GrsProfitSecureRat62";
        /// <summary>GrsProfitSecureRat63</summary>
        public const string COLUMN_GRSPROFITSECURERAT63 = "GrsProfitSecureRat63";
        /// <summary>GrsProfitSecureRat64</summary>
        public const string COLUMN_GRSPROFITSECURERAT64 = "GrsProfitSecureRat64";
        /// <summary>GrsProfitSecureRat65</summary>
        public const string COLUMN_GRSPROFITSECURERAT65 = "GrsProfitSecureRat65";
        /// <summary>GrsProfitSecureRat66</summary>
        public const string COLUMN_GRSPROFITSECURERAT66 = "GrsProfitSecureRat66";
        /// <summary>GrsProfitSecureRat67</summary>
        public const string COLUMN_GRSPROFITSECURERAT67 = "GrsProfitSecureRat67";
        /// <summary>GrsProfitSecureRat68</summary>
        public const string COLUMN_GRSPROFITSECURERAT68 = "GrsProfitSecureRat68";
        /// <summary>GrsProfitSecureRat69</summary>
        public const string COLUMN_GRSPROFITSECURERAT69 = "GrsProfitSecureRat69";
        /// <summary>GrsProfitSecureRat70</summary>
        public const string COLUMN_GRSPROFITSECURERAT70 = "GrsProfitSecureRat70";
        /// <summary>GrsProfitSecureRat71</summary>
        public const string COLUMN_GRSPROFITSECURERAT71 = "GrsProfitSecureRat71";
        /// <summary>GrsProfitSecureRat72</summary>
        public const string COLUMN_GRSPROFITSECURERAT72 = "GrsProfitSecureRat72";
        /// <summary>GrsProfitSecureRat73</summary>
        public const string COLUMN_GRSPROFITSECURERAT73 = "GrsProfitSecureRat73";
        /// <summary>GrsProfitSecureRat74</summary>
        public const string COLUMN_GRSPROFITSECURERAT74 = "GrsProfitSecureRat74";
        /// <summary>GrsProfitSecureRat75</summary>
        public const string COLUMN_GRSPROFITSECURERAT75 = "GrsProfitSecureRat75";
        /// <summary>GrsProfitSecureRat76</summary>
        public const string COLUMN_GRSPROFITSECURERAT76 = "GrsProfitSecureRat76";
        /// <summary>GrsProfitSecureRat77</summary>
        public const string COLUMN_GRSPROFITSECURERAT77 = "GrsProfitSecureRat77";
        /// <summary>GrsProfitSecureRat78</summary>
        public const string COLUMN_GRSPROFITSECURERAT78 = "GrsProfitSecureRat78";
        /// <summary>GrsProfitSecureRat79</summary>
        public const string COLUMN_GRSPROFITSECURERAT79 = "GrsProfitSecureRat79";
        /// <summary>GrsProfitSecureRat80</summary>
        public const string COLUMN_GRSPROFITSECURERAT80 = "GrsProfitSecureRat80";
        /// <summary>GrsProfitSecureRat81</summary>
        public const string COLUMN_GRSPROFITSECURERAT81 = "GrsProfitSecureRat81";
        /// <summary>GrsProfitSecureRat82</summary>
        public const string COLUMN_GRSPROFITSECURERAT82 = "GrsProfitSecureRat82";
        /// <summary>GrsProfitSecureRat83</summary>
        public const string COLUMN_GRSPROFITSECURERAT83 = "GrsProfitSecureRat83";
        /// <summary>GrsProfitSecureRat84</summary>
        public const string COLUMN_GRSPROFITSECURERAT84 = "GrsProfitSecureRat84";
        /// <summary>GrsProfitSecureRat85</summary>
        public const string COLUMN_GRSPROFITSECURERAT85 = "GrsProfitSecureRat85";
        /// <summary>GrsProfitSecureRat86</summary>
        public const string COLUMN_GRSPROFITSECURERAT86 = "GrsProfitSecureRat86";
        /// <summary>GrsProfitSecureRat87</summary>
        public const string COLUMN_GRSPROFITSECURERAT87 = "GrsProfitSecureRat87";
        /// <summary>GrsProfitSecureRat88</summary>
        public const string COLUMN_GRSPROFITSECURERAT88 = "GrsProfitSecureRat88";
        /// <summary>GrsProfitSecureRat89</summary>
        public const string COLUMN_GRSPROFITSECURERAT89 = "GrsProfitSecureRat89";
        /// <summary>GrsProfitSecureRat90</summary>
        public const string COLUMN_GRSPROFITSECURERAT90 = "GrsProfitSecureRat90";
        /// <summary>GrsProfitSecureRat91</summary>
        public const string COLUMN_GRSPROFITSECURERAT91 = "GrsProfitSecureRat91";
        /// <summary>GrsProfitSecureRat92</summary>
        public const string COLUMN_GRSPROFITSECURERAT92 = "GrsProfitSecureRat92";
        /// <summary>GrsProfitSecureRat93</summary>
        public const string COLUMN_GRSPROFITSECURERAT93 = "GrsProfitSecureRat93";
        /// <summary>GrsProfitSecureRat94</summary>
        public const string COLUMN_GRSPROFITSECURERAT94 = "GrsProfitSecureRat94";
        /// <summary>GrsProfitSecureRat95</summary>
        public const string COLUMN_GRSPROFITSECURERAT95 = "GrsProfitSecureRat95";
        /// <summary>GrsProfitSecureRat96</summary>
        public const string COLUMN_GRSPROFITSECURERAT96 = "GrsProfitSecureRat96";
        /// <summary>GrsProfitSecureRat97</summary>
        public const string COLUMN_GRSPROFITSECURERAT97 = "GrsProfitSecureRat97";
        /// <summary>GrsProfitSecureRat98</summary>
        public const string COLUMN_GRSPROFITSECURERAT98 = "GrsProfitSecureRat98";
        /// <summary>GrsProfitSecureRat99</summary>
        public const string COLUMN_GRSPROFITSECURERAT99 = "GrsProfitSecureRat99";
        /// <summary>GrsProfitSecureRat100</summary>
        public const string COLUMN_GRSPROFITSECURERAT100 = "GrsProfitSecureRat100";

        /// <summary>COLINDEX_SALERATE_ST</summary>
        public const int COLINDEX_SALERATE_ST = 10;
        /// <summary>COLINDEX_SALERATE_ED</summary>
        public const int COLINDEX_SALERATE_ED = 309;

        private const string FORMAT = "N";

        private const int ALL_CUST_RATE_GRP_CODE = -1;  // FIXME:得意先掛率グループコード
        private const string ALL_CUST_RATE_GRP = "ALL";  // FIXME:得意先掛率グループ

        private const string CUSTOMER_MODE1 = "得意先掛率Ｇ";
        private const string CUSTOMER_MODE2 = "得意先";

        private const string CUSTOMERGROUPCODE = "得意先掛率G範囲指定";
        private const string CUSTOMERCODE = "得意先範囲指定";

        private const string RATE_TITLE_RATEVAL = "売価率";
        private const string RATE_TITLE_UPRATE = "原価UP率";
        private const string RATE_TITLE_GRSPROFITSECURERAT = "粗利確保率";

        /// <summary>チェック時メッセージ「ファイルへの出力に失敗しました。」</summary>
        private const string MSG_OUTPUTFILE_FAILED = "ファイルへの出力に失敗しました。";

        /// <summary>テキストエクスポート成功時メッセージ「 行のデータをファイルへ出力しました。」</summary>
        private const string MSG_OUTPUTFILE_SUCCEEDED = "行のデータをファイルへ出力しました。";

        /// <summary>チェック時メッセージ「出力ファイル名が指定されていません。」</summary>
        private const string MSG_OUTPUTEXCEL_NOFILENAME = "出力ファイル名が指定されていません。";

        /// <summary>EXCELエクスポート成功時メッセージ「EXCELデータを出力しました。」</summary>
        private const string MSG_OUTPUTEXCEL_SUCCEEDED = "EXCELデータを出力しました。";

        /// <summary>メーカー情報は未入力時メッセージ「※メーカー未時は優良メーカーを参照します」</summary>
        private const string MSG_MAKERNOINTPUT = "※メーカー未入力時は優良メーカーを参照します";

        /// <summary>掛率起始入力列</summary>
        private const int RATESTARTCOLUMN = 7;

        /// <summary>掛率起始入力行</summary>
        private const int RATESTARTROW = 4;

        #endregion ■ Constants

        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SecInfoAcs _secInfoAcs;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;                           // 拠点情報設定アクセスクラス
        private SupplierAcs _supplierAcs;                               // 仕入先アクセスクラス
        private MakerAcs _makerAcs;                                     // メーカーアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs;                         // 商品掛率Ｇアクセスクラス
        private CustomerSearchAcs _customerSearchAcs;                   // 得意先情報アクセスクラス
        private UserGuideAcs _userGuideAcs;                             // ユーザーガイドアクセスクラス
        private BLGroupUAcs _blGroupUAcs;                               // BLグループアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;                             // BLアクセスクラス
        private RateUpdateAcs _rateUpdateAcs;                           // 掛率一括登録・修正Ⅱアクセスクラス

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private SortedDictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private SortedDictionary<int, string> _custRateGrpDic;
        private Dictionary<int, UserGdBd> _userGuid43Dic;

        /// <summary>ＢＬコードマスタ情報</summary>
        /// <remarks>key:BLコード  value:該当ＢＬコードの情報 </remarks>
        private Dictionary<int, BLGroupU> _blGroupUDic;

        /// <summary>ＢＬグループコードマスタ情報</summary>
        /// <remarks>key:ＢＬグループコード  value:該当ＢＬグループコードの情報 </remarks>
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic ;
        
        /// <summary>毎列小数部最大長さ</summary>
        /// <remarks>key:掛率列番号  value:該列小数部の最大長さ </remarks>
        private Dictionary<int, int> _maxPointLengthDic = new Dictionary<int,int>() ;

        /// <summary>入力得意先検索条件を覚える</summary>
        /// <remarks>key:得意先切替モード+範囲指定モード+列番号  value:入力得意先検索条件 ）</remarks>
        private Dictionary<string, string> _inputCustomerDic = new Dictionary<string, string>();

        /// <summary>新追加行用入力した商品情報を覚える</summary>
        /// <remarks>key:行番号 + 商品モード + 商品情報 value:商品情報変更フラグ</remarks>
        private Dictionary<string, bool> _inputGoodsInfoDic = new Dictionary<string, bool>();

        /// <summary>行追加を押す、検索条件の記憶</summary>
        private bool addRemberFlg = true;
        private string _searchSectionCode;
        private Dictionary<int, int> _targetDic = new Dictionary<int,int>();
        private Dictionary<int, int> _searchDic = new Dictionary<int, int>();
        private List<Rate2SearchResult> _parentList;
        private List<Rate2SearchResult> _parentGRList;
        private List<Rate2SearchResult> _childList;
        private List<Rate2SearchResult> _displayList;
        private Dictionary<int, ArrayList> _parentChildIndexDic;

        private Boolean _isDoing = false;// 仕事を行いますか（true: 仕事を行います。false:仕事を完了しました。）
        

        // 掛率取得用のリスト
        private List<Rate2SearchResult> _parentRateValList;
        private List<Rate2SearchResult> _parentGRRateValList;
        private List<Rate2SearchResult> _childRateValList;

        private Rate2SearchParam _extrInfo;

        private bool _prevAllExpand;
        private bool _closeFlg;
        private bool _existFlg = true;
        private Dictionary<string, bool> expandDic = new Dictionary<string, bool>();

        // フォーカス制御用
        //TNedit _preCtrl = null;
        // 得意先コードチェック用
        private CustomerInputAcs _customerInputAcs = null;
        // 前回のコード
        private string _prevCode = null;

        // 展開ボタンをクリックすると前回ActiveCellを記録する
        private int _prevActiveUltraGridCellRow = 0;
        private int _prevActiveUltraGridCellCol = 0;


        private DataTable tempTable = new DataTable();
        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>
        /// <summary>記録新追加行データ用</summary>
        private DataTable _newAddRowTempTable = new DataTable();
        /// <summary>セル初期設定色</summary>
        ///<remarks>key: 行番号　 value:セル色Dic（key:列名　 value:　セル初期設定糸色)</remarks>
        private Dictionary<int, Dictionary<string, Color>> _cellIniSettingColorDic = new Dictionary<int, Dictionary<string, Color>>();
        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<
        private bool _bevalueFlag = true;
        private string _beCustomerCd = string.Empty;
        private string _beCustomerRateG = string.Empty;
        private string _precode = string.Empty;
        /// <summary>true:マウス操作 false:キーボード操作</summary>
        private bool mouseFlag = true;
        private CustomerSearchMode _customerSearchMode = CustomerSearchMode.CustomerRateG;
        private GoodsMode _goodsMode = GoodsMode.GoodsRateG;
        private RateMode _rateMode = RateMode.RateVal;

        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";
        #endregion ■ Private Members

        #region ■ Constructor

        /// <summary>
        /// 掛率一括登録・修正ⅡUIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率一括登録・修正ⅡUIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public PMKHN09902UA()
		{
			InitializeComponent();
            
            this._controlScreenSkin = new ControlScreenSkin();
            
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();
            this._makerAcs = new MakerAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._rateUpdateAcs = new RateUpdateAcs();

            this._gridStateController = new GridStateController();

            // 得意先コードチェック用
            this._customerInputAcs = new CustomerInputAcs();
            this._prevCode = this.tEdit_SectionCodeAllowZero.Text;

            // マスタ読込
            ReadSecInfoSet();
            ReadCustomerSearchRet();
            ReadUserGuide();

            // 画面初期設定
            SetInitialSetting();

            // 画面クリア
            ClearScreen();
        }

        #endregion ■ Constructor

        #region 列挙体
        /// <summary>
        /// 得意先切替Mode
        /// </summary>
        public enum CustomerSearchMode : int
        {
            /// <summary>得意先掛率Ｇ</summary>
            CustomerRateG = 0,
            /// <summary>得意先ＣＤ</summary>
            Customer = 1
        }

        /// <summary>
        /// 商品切替Mode
        /// </summary>
        public enum GoodsMode : int
        {
            /// <summary>商品掛率Ｇ</summary>
            GoodsRateG = 0,
            /// <summary>層別</summary>
            GoodsRateRank = 1
        }

        /// <summary>
        /// 掛率切替Mode
        /// </summary>
        public enum RateMode : int
        {
            /// <summary>売価率</summary>
            RateVal = 0,
            /// <summary>原価ＵＰ率</summary>
            UpRate = 1,
            /// <summary>粗利確保率</summary>
            GrsProfitSecureRat = 2
        }

        /// <summary>
        /// 移動モード
        /// </summary>
        public enum CellMoveState : int
        {
            /// <summary>移動しない</summary>
            Stay = 0,
            /// <summary>グリッドの外へ移動可</summary>
            MustJump = 1,
            /// <summary>移動した</summary>
            Moved = 2
        }
        #endregion

        #region ■ Private Methods

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Details);
                if (gridStateInfo != null)
                {
                    // フォントサイズ
                    this.tComboEditor_GridFontSize.Value = (int)gridStateInfo.FontSize;
                    // 列の自動調整
                    this.uCheckEditor_AutoFillToColumn.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // フォントサイズ
                this.tComboEditor_GridFontSize.Value = 11;
                // 列の自動調整
                this.uCheckEditor_AutoFillToColumn.Checked = false;
            }
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion XML操作

        #region マスタ読込
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 仕入先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 仕入先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// 商品掛率Ｇマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 商品掛率Ｇマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int,GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new SortedDictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new SortedDictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// ユーザーガイドマスタ(得意先掛率Ｇ)読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadCustRateGrp()
        {
            this._custRateGrpDic = new SortedDictionary<int, string>();

            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     43, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                this._custRateGrpDic = new SortedDictionary<int, string>();
            }
        }

        /// <summary>
        /// グループコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グループコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
            this._rateUpdateAcs.BLGroupCodeDic = this._blGroupUDic;
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : BLコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            int status = 0;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
            this._rateUpdateAcs.BLCodeDic = this._blGoodsCdUMntDic;
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : BLコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ReadUserGuide()
        {
            int status = 0;

            this._userGuid43Dic = new Dictionary<int, UserGdBd>();

            try
            {
                ArrayList retList;
                UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                status = this._userGuideAcs.SearchDivCodeBody(out retList, this._enterpriseCode, 43, acsDataType);

                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._userGuid43Dic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            catch
            {
                this._userGuid43Dic = new Dictionary<int, UserGdBd>();
            }
        }
        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードに該当する拠点略称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "全社";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }

        /// <summary>
        /// 仕入先略称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>略称</returns>
        /// <remarks>
        /// <br>Note        : 仕入先コードに該当する略称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
            if (this._supplierDic == null)
            {
                // 仕入先マスタ読込処理
                this.ReadSupplier();
            }

            if (this._supplierDic.ContainsKey(supplierCode))
            {
                return this._supplierDic[supplierCode].SupplierSnm.Trim();
            }

            return "";
        }

        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note        : メーカーコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            if (this._makerDic == null)
            {
                // メーカーマスタ読込処理
                this.ReadMakerUMnt();
            }

            if (this._makerDic.ContainsKey(makerCode))
            {
                return this._makerDic[makerCode].MakerName.Trim();
            }

            return "";
        }

        /// <summary>
        /// 商品掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="goodsGroupCode">商品掛率Ｇコード</param>
        /// <returns>商品掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note        : 商品掛率Ｇコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetGoodsGroupName(int goodsGroupCode)
        {
            if (this._goodsGroupUDic == null)
            {
                // 商品掛率Ｇマスタ読込処理
                this.ReadGoodsGroupU();
            }

            if (this._goodsGroupUDic.ContainsKey(goodsGroupCode))
            {
                return this._goodsGroupUDic[goodsGroupCode].GoodsMGroupName.Trim();
            }

            return "";
        }

        /// <summary>
        /// 得意先掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率Ｇコード</param>
        /// <returns>得意先掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note        : 得意先掛率Ｇコードに該当する得意先掛率Ｇ名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            if (this._custRateGrpDic == null)
            {
                // ユーザーガイドマスタ(得意先掛率Ｇ)読込処理
                this.ReadCustRateGrp();
            }

            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                return (string)this._custRateGrpDic[custRateGrpCode];
            }

            return "";
        }

        /// <summary>
        /// ＢＬコード名取得処理
        /// </summary>
        /// <param name="blGroupCode">ＢＬコード</param>
        /// <returns>ＢＬコード名</returns>
        /// <remarks>
        /// <br>Note        : ＢＬコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            if (this._blGroupUDic == null)
            {
                // グループコードマスタ読込処理
                ReadBLGroupU();
            }

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                return this._blGroupUDic[blGroupCode].BLGroupName;
            }
            else
            {
                return "未登録";
            }
        }

        /// <summary>
        /// ＢＬコード名取得処理
        /// </summary>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <returns>ＢＬコード名</returns>
        /// <remarks>
        /// <br>Note        : ＢＬコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            if (this._blGoodsCdUMntDic == null)
            {
                // BLコードマスタ読込処理
                ReadBLGoodsCdUMnt();
            }

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                return this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName;
            }
            else
            {
                return "未登録";
            }
        }

        #endregion 名称取得

        #region マスタ存在チェック
        /// <summary>
        /// 得意先存在チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 得意先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }

        /// <summary>
        /// 仕入先存在チェック処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 仕入先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckSupplier(int supplierCode)
        {
            bool check = false;

            try
            {
                if (this._supplierDic.ContainsKey(supplierCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion マスタ存在チェック

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void SetInitialSetting()
        {

            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            this.tEdit_SectionCodeAllowZero.Size = new Size(28, 24);
            this.tEdit_SectionName.Size = new Size(175, 24);
            this.tNedit_SupplierCd.Size = new Size(59, 24);
            this.tEdit_SupplierName.Size = new Size(175, 24);
            this.tNedit_GoodsMGroup.Size = new Size(59, 24);
            this.tEdit_GoodsRateGrpName.Size = new Size(175, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(59, 24);
            this.tEdit_MakerName.Size = new Size(175, 24);

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            LabelTool labelTool;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CustomerChange"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_GoodsChange"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RateChange"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;

            // 拠点名
            ToolBase sectionName = tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"];
            if (sectionName != null && LoginInfoAcquisition.Employee != null)
            {
                sectionName.SharedProps.Caption = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }

            // ログイン名
            ToolBase loginName = tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            _GetDirectoryName = System.Environment.CurrentDirectory;

        }
        #endregion 初期設定

        #region クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "全社";
            // 仕入先コード
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierName.Clear();
            // 商品掛率Ｇコード
            this.tNedit_GoodsMGroup.Clear();
            this.tEdit_GoodsRateGrpName.Clear();
            this.GoodsRateRank_tEdit.Clear();
            this.tNedit_GoodsMGroup.Enabled = true;
            this.GoodsRateGrpGuide_Button.Enabled = true;
            this.GoodsRateRank_tEdit.Enabled = false;
            //this.ultraLabel6.Text = "商掛G";
            this.uLabel_SaleRate.Text = RATE_TITLE_RATEVAL;
            // メーカーコード
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            this.AllExpand_Button.Enabled = false;
            this.Expand_Button.Enabled = false;
            this.chkSearchingAll.Checked = false;
            this.chkSearchingAll.Enabled = true;
            this.chkSearchingAll.Text = CUSTOMERGROUPCODE;
            this.uLabel_Message.Text = MSG_MAKERNOINTPUT;
            this._inputCustomerDic.Clear();
            this._inputGoodsInfoDic.Clear();

            // スクロールポジション初期化
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            _customerSearchMode = CustomerSearchMode.CustomerRateG;
            _goodsMode = GoodsMode.GoodsRateG;
            _rateMode = RateMode.RateVal;

            // グリッドクリア
            ClearGrid();

            // グリッドにスクロールバー売価率ラベルの制御
            ScrollControl();

            // グリッド列Hidden制御設定処理
            SetColumnHidden();

            this.uGrid_Details.ActiveRow = null;
            // 明細グリッド値の記憶
            tempTable = ((DataTable)uGrid_Details.DataSource).Copy();

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
            AdjustButtonEnable(0, true);
            this.Delete_Button.Enabled = false;
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドを初期化を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ClearGrid()
        {
            // クリア前回展開セルの位置
            _prevActiveUltraGridCellRow = 0;
            _prevActiveUltraGridCellCol = 0;

            this._searchDic = new Dictionary<int, int>();
            this._displayList = new List<Rate2SearchResult>();
            this._parentList = new List<Rate2SearchResult>();
            this._parentGRList = new List<Rate2SearchResult>(); 
            this._childList = new List<Rate2SearchResult>();
            this._parentChildIndexDic = new Dictionary<int, ArrayList>();

            this._prevAllExpand = false;

            // グリッド作成処理
            CreateGrid(ref this.uGrid_Details);
        }
        #endregion クリア処理

        #region 保存
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 保存処理を行います
            status = SaveProc(true);
            return (status);
        }
        #endregion 保存

        #region 保存処理実行
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="reSearchFlag">再検索フラグ</param>
        /// <returns></returns>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// <br>Update Note : 2013/04/19 donggy</br>
        /// <br>管理番号    : 10901273-00 </br>
        /// <br>              Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
        /// <br>　　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
        private int SaveProc(bool reSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (string.IsNullOrEmpty(this.tNedit_SupplierCd.Text.Trim()))
            {
                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                     "仕入先を入力してください。",
                                     0,
                                     MessageBoxButtons.OK,
                                     MessageBoxDefaultButton.Button1);
                this.tNedit_SupplierCd.Focus();
                this.AdjustButtonEnable(1, true);
                return (status);
            }

            // 画面情報取得
            ArrayList saveList;
            ArrayList deleteList;
            GetUpdateList(out saveList, out deleteList);

            // 画面情報チェック
            string errMsg = "";
            // 既存画面行数取得
            int oldRowsCount = this._displayList.Count + 2;
            // 新追加行フラグ
            bool eFlag = false;

            try
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    errMsg = "保存対象データが存在しません。";
                    if (errMsg.Length > 0)
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       errMsg,
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                    }
                    this.tEdit_SectionCodeAllowZero.Focus();
                    this.AdjustButtonEnable(1, true);
                    return (status);
                }
                #region 新追加行保存処理
                if (this.uGrid_Details.Rows.Count > oldRowsCount)// 画面に新追加行があるかどうかの判定
                {
                    int newRowStartIndex = oldRowsCount;
                    foreach (UltraGridRow gridRow in this.uGrid_Details.Rows)
                    {
                        if (gridRow.Index >= newRowStartIndex)// 新追加行判定
                        {
                            // 保存前チェック処理
                            int newRowCheckPattarn = CheckNewAddRowDataBeforeSave(gridRow, out errMsg);
                            // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                            if (newRowCheckPattarn < 0) // 掛率列未入力、保存操作実行なし
                            {
                                continue;
                            }
                            // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                            // チェックメッセージの表示
                            if (errMsg != string.Empty && newRowCheckPattarn != 0)
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                               errMsg,
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);
                                // 掛率優先管理設定区分チェック後のフォカス設定
                                #region チェックパターン
                                // 0: チェックなし
                                // 1: 商品掛率Ｇの場合に、商品掛率Ｇ・GRCD・BLCDの入力チェック
                                // 2: 層別の場合、層別入力チェック
                                // 3: メーカー入力チェック
                                // 4: 重複チェック
                                // 5: 掛率優先管理設定区分チェック
                                #endregion
                                this.uGrid_Details.BeginUpdate();
                                this.uGrid_Details.Enter -= new System.EventHandler(this.uGrid_Details_Enter);
                                this.uGrid_Details.Focus();　// グリッドにフォーカスを取得します
                                this.uGrid_Details.Enter += new System.EventHandler(this.uGrid_Details_Enter);
                                if (newRowCheckPattarn != 3)
                                {
                                    if (this._goodsMode == GoodsMode.GoodsRateG)
                                    {
                                        gridRow.Cells[COLUMN_GOODSRATEGRPCODE].Activate();
                                    }
                                    else
                                    {
                                        gridRow.Cells[COLUMN_GOODSRATERANK].Activate();
                                    }
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    gridRow.Cells[COLUMN_MAKERCODE].Activate();
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                }
                                this.uGrid_Details.EndUpdate();
                                return (status);
                            }
                            else
                            {
                                // 新追加用Rate
                                Rate newRowRate = new Rate();
                                // 親子区分
                                int parentDiv = 0;
                                // 親
                                if (StrObjToInt (gridRow.Cells[COLUMN_BLCD].Value )== 0 && StrObjToInt(gridRow.Cells[COLUMN_GLCD].Value) == 0)
                                {
                                    parentDiv = 0;
                                }
                                // 子
                                else if (StrObjToInt(gridRow.Cells[COLUMN_BLCD].Value) != 0)
                                {
                                    parentDiv = 1;
                                }
                                // 子親
                                else if (StrObjToInt(gridRow.Cells[COLUMN_BLCD].Value) == 0 && StrObjToInt(gridRow.Cells[COLUMN_GLCD].Value) != 0)
                                {
                                    parentDiv = 2;
                                }
                                List<Rate2SearchResult> rate2SearchResultList = new List<Rate2SearchResult>();

                                NewAddRowRateSearch(gridRow, out rate2SearchResultList);
                                // 仕入率チェック
                                # region 仕入率
                                Rate2SearchResult result = rate2SearchResultList.Find(delegate(Rate2SearchResult target)
                                {
                                    if (target.UnitPriceKind == "2")
                                    {
                                        return (true);
                                    }
                                    else
                                    {
                                        return (false);
                                    }
                                });

                                if (result != null)
                                {
                                    // 変更データ取得
                                    //UpdateRateData(ref saveList, ref deleteList,gridRow.Cells, result, result.UnitPriceKind, 0); // DEL donggy 2013/04/19 for Redmine#35355
                                    UpdateRateData(ref saveList, ref deleteList, gridRow.Cells, result, result.UnitPriceKind, 0, parentDiv, 0); // ADD donggy 2013/04/19 for Redmine#35355
                                }
                                else
                                {
                                    // 入力仕入率のよって、新データを作成する
                                    if (DoubleObjToDouble(gridRow.Cells[COLUMN_COSTRATE].Value) != 0)
                                    {
                                        MakeNewCostrateData(out newRowRate, gridRow.Cells, parentDiv);
                                        newRowRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                                        //saveList.Add(updateRate.Clone()); // DEL donggy 2013/04/19 for Redmine#35355 
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                        if (newRowRate != null
                                            && newRowRate.RateVal != 0.0)
                                        {
                                            saveList.Add(newRowRate.Clone());
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                    }
                                }
                                #endregion 仕入率

                                #region 売価率チェック、原価ＵＰ率チェック、粗利確保率チェック
                                // 入力の掛率列番号
                                int colIndex = 1;
                                //　入力掛率のよって、新データを作成する。
                                foreach (UltraGridColumn gridColumn in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
                                {
                                    if ((gridColumn.Key.Contains(COLUMN_GRSPROFITSECURERAT)
                                        || gridColumn.Key.Contains(COLUMN_UPRATE)
                                        || gridColumn.Key.Contains(COLUMN_SALERATE))
                                        && (gridColumn.Hidden == false))
                                    {
                                        // 得意先検索条件
                                        int code = 0;
                                        if (this.uGrid_Details.Rows[0].Cells[gridColumn.Key].Value.ToString() == ALL_CUST_RATE_GRP)
                                        {
                                            code = ALL_CUST_RATE_GRP_CODE;
                                        }
                                        else
                                        {
                                            code = StrObjToInt(this.uGrid_Details.Rows[0].Cells[gridColumn.Key].Value);
                                        }
                                        // 元データ取得
                                        GetRateUpdateData(ref result, rate2SearchResultList,code);
                                        if (result != null)
                                        {
                                            // 変更データ取得
                                            //UpdateRateData(ref saveList, ref deleteList, gridRow.Cells, result, result.UnitPriceKind, colIndex); // DEL donggy 2013/04/19 for Redmine#35355
                                            UpdateRateData(ref saveList, ref deleteList, gridRow.Cells, result, result.UnitPriceKind, colIndex, parentDiv, code); // ADD donggy 2013/04/19 for Redmine#35355
                                        }
                                        else
                                        {
                                            // 新データ作成
                                            if (DoubleObjToDouble(gridRow.Cells[gridColumn].Value) != 0)
                                            {
                                                MakeNewRateData(out newRowRate, gridRow.Cells, parentDiv, code, colIndex);
                                                newRowRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                                                //saveList.Add(newRowRate.Clone());// DEL donggy 2013/04/19 for Redmine#35355
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                                                // 売価率、原価UP率と粗利確保率全部が全社拠点のデータを保存しない
                                                if (newRowRate.RateVal == 0.0
                                                    && newRowRate.UpRate == 0.0
                                                    && newRowRate.GrsProfitSecureRate == 0.0)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    saveList.Add(newRowRate.Clone());
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                                            }
                                            // 表示掛率列の掛率が「０」の場合
                                            else
                                            {
                                                switch (this._rateMode)
                                                {
                                                    // 売価率の場合
                                                    case RateMode.RateVal:
                                                        {
                                                            // 原価UP率と粗利確保率一つが「0」じゃないの場合データを保存します
                                                            if (DoubleObjToDouble(gridRow.Cells[COLUMN_UPRATE + colIndex.ToString()].Value) != 0
                                                                || DoubleObjToDouble(gridRow.Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value) != 0)
                                                            {
                                                                MakeNewRateData(out newRowRate, gridRow.Cells, parentDiv, code, colIndex);
                                                                newRowRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                                                                //saveList.Add(newRowRate.Clone());// DEL donggy 2013/04/19 for Redmine#35355
                                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                                                                // 売価率、原価UP率と粗利確保率全部が全社拠点のデータを保存しない
                                                                if (newRowRate.RateVal == 0.0
                                                                    && newRowRate.UpRate == 0.0
                                                                    && newRowRate.GrsProfitSecureRate == 0.0)
                                                                {
                                                                    continue;
                                                                }
                                                                else
                                                                {
                                                                    saveList.Add(newRowRate.Clone());
                                                                }
                                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                                                            }
                                                            break;
                                                        }
                                                    // 原価UP率の場合
                                                    case RateMode.UpRate:
                                                        {
                                                            // 売価率と粗利確保率一つが「0」じゃないの場合データを保存します
                                                            if (DoubleObjToDouble(gridRow.Cells[COLUMN_SALERATE + colIndex.ToString()].Value) != 0
                                                                || DoubleObjToDouble(gridRow.Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value) != 0)
                                                            {
                                                                MakeNewRateData(out newRowRate, gridRow.Cells, parentDiv, code, colIndex);
                                                                newRowRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                                                                //saveList.Add(newRowRate.Clone());// DEL donggy 2013/04/19 for Redmine#35355
                                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                                                                // 売価率、原価UP率と粗利確保率全部が全社拠点のデータを保存しない
                                                                if (newRowRate.RateVal == 0.0
                                                                    && newRowRate.UpRate == 0.0
                                                                    && newRowRate.GrsProfitSecureRate == 0.0)
                                                                {
                                                                    continue;
                                                                }
                                                                else
                                                                {
                                                                    saveList.Add(newRowRate.Clone());
                                                                }
                                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                                                            }
                                                            break;
                                                        }
                                                    // 粗利確保率の場合
                                                    case RateMode.GrsProfitSecureRat:
                                                        {
                                                            // 原価UP率と売価率一つが「0」じゃないの場合データを保存します
                                                            if (DoubleObjToDouble(gridRow.Cells[COLUMN_UPRATE + colIndex.ToString()].Value) != 0
                                                                || DoubleObjToDouble(gridRow.Cells[COLUMN_SALERATE + colIndex.ToString()].Value) != 0)
                                                            {
                                                                MakeNewRateData(out newRowRate, gridRow.Cells, parentDiv, code, colIndex);
                                                                newRowRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                                                                //saveList.Add(newRowRate.Clone());// DEL donggy 2013/04/19 for Redmine#35355
                                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                                                                // 売価率、原価UP率と粗利確保率全部が全社拠点のデータを保存しない
                                                                if (newRowRate.RateVal == 0.0
                                                                    && newRowRate.UpRate == 0.0
                                                                    && newRowRate.GrsProfitSecureRate == 0.0)
                                                                {
                                                                    continue;
                                                                }
                                                                else
                                                                {
                                                                    saveList.Add(newRowRate.Clone());
                                                                }
                                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                                                            }
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        colIndex++;
                                    }
                                }
                                #endregion 売価率チェック、原価ＵＰ率チェック、粗利確保率チェック
                            }

                            if (saveList.Count > 0)
                            {
                                eFlag = true;
                            }
                        }
                    }
                }
                #endregion 新追加行保存処理
                if ((saveList.Count == 0) && (deleteList.Count == 0))
                {
                    errMsg = "保存対象データが存在しません。";
                    if (errMsg.Length > 0)
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       errMsg,
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                    }
                    this.uGrid_Details.Rows[0].Cells[COLUMN_COSTRATE].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (status);
                }  
            }
            finally
            {
                
            }
            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "保存中";
            msgForm.Message = "掛率マスタ保存中です。\r\nしばらくお待ちください。";
            try
            {
                msgForm.Show();
                // 削除処理
                if (deleteList.Count > 0)
                {
                    status = this._rateUpdateAcs.Delete(deleteList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                {
                                    errMsg = "既に他端末より削除されています。";
                                }
                                else
                                {
                                    errMsg = "既に他端末より更新されています。";
                                }
                                msgForm.Close();
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                               "Save",
                                               errMsg,
                                               status,
                                               MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Focus();
                                this.AdjustButtonEnable(1, true);
                                return (status);
                            }
                        default:
                            {
                                msgForm.Close();
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                               "Save",
                                               "保存処理に失敗しました。",
                                               status,
                                               MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Focus();
                                this.AdjustButtonEnable(1, true);
                                return (status);
                            }
                    }
                }

                // 更新処理
                if (saveList.Count > 0)
                {
                    status = this._rateUpdateAcs.Write(saveList, eFlag);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                                {
                                    errMsg = "既に他端末より削除されています。";
                                }
                                else
                                {
                                    errMsg = "既に他端末より更新されています。";
                                }
                                msgForm.Close();
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                               "Save",
                                               errMsg,
                                               status,
                                               MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Focus();
                                this.AdjustButtonEnable(1, true);
                                return (status);
                            }
                        default:
                            {
                                msgForm.Close();
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "Save",
                                           "保存処理に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Focus();
                                this.AdjustButtonEnable(1, true);
                                return (status);
                            }
                    }
                }
                if (!reSearchFlag)
                {
                    msgForm.Close();
                    // 登録完了ダイアログ表示
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
                else
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 保存成功後で、再検索を行います
                        status = Search(true);
                        msgForm.Close();
                        if (status == 0)
                        {
                            // 登録完了ダイアログ表示
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);
                        }
                        else
                        {
                            switch (status)
                            {
                                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                    {
                                        DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                            "検索条件に該当するデータが存在しません。\r\n掛率の新規追加を行いますか？",
                                            status,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button1);

                                        // グリッドクリア
                                        ClearGrid();

                                        switch (res)
                                        {
                                            case DialogResult.Yes:
                                                {
                                        // 検索条件保留
                                        _searchDic.Clear();
                                        this.chkSearchingAll.Enabled = false;
                                        string name = string.Empty;
                                        int newColumnIndex = 1;
                                        // 得意先掛率Ｇ検索条件の制御
                                        if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                                        {
                                            foreach (int key in this._extrInfo.CustRateGrpCode)
                                            {
                                                this._searchDic.Add(key, newColumnIndex);

                                                CellsCollection cells = uGrid_Details.Rows[0].Cells;

                                                // 得意先掛率Ｇコード
                                                if (key < 0)
                                                {
                                                    cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                                                    cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                                                    cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                                                }
                                                else
                                                {
                                                    cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                                                    cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                                                    cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("0000");
                                                }

                                                // 得意先掛率Ｇ名称
                                                cells = uGrid_Details.Rows[1].Cells;
                                                if (key < 0)
                                                {
                                                    cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = string.Empty;
                                                    cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = string.Empty;
                                                    cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = string.Empty;
                                                }
                                                else
                                                {
                                                    CustomerGIsExist(key.ToString(), ref name);
                                                    cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                                                    cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                                                    cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;
                                                }
                                                newColumnIndex++;
                                            }
                                        }
                                        // 得意先検索条件の制御
                                        else
                                        {
                                            foreach (int key in this._extrInfo.CustomerCode)
                                            {
                                                this._searchDic.Add(key, newColumnIndex);

                                                // 得意先コード
                                                CellsCollection cells = uGrid_Details.Rows[0].Cells;
                                                cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                                                cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                                                cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("00000000");

                                                // 得意先名称
                                                cells = uGrid_Details.Rows[1].Cells;
                                                CustomerIsExist(key.ToString(), ref name);
                                                cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                                                cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                                                cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;

                                                newColumnIndex++;
                                            }
                                        }
                                        // 表示行のグレーアウト、表示しない行のhidden制御
                                        for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
                                        {
                                            if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[i].Value.ToString()))
                                            {
                                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                                            }
                                            else
                                            {
                                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden = true;
                                            }
                                        }
                                        // 明細グリッド値の記憶
                                        tempTable = ((DataTable)uGrid_Details.DataSource).Copy();

                                                    if (this._goodsMode == GoodsMode.GoodsRateRank) 
                                                    {
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = false;
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK].Hidden = false;
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                                                    }

                                                    // 行追加
                                                    this.addRemberFlg = false;
                                                    this.Add_Button_Click(this.Add_Button, new EventArgs());
                                                    this.addRemberFlg = true;

                                                    break;
                                                }
                                            case DialogResult.No:
                                                {
                                                    // 明細グリッド値の記憶
                                                    tempTable = ((DataTable)uGrid_Details.DataSource).Copy();
                                                    this.chkSearchingAll.Enabled = true;
                                                    this.chkSearchingAll.Checked = false;
                                                    this._inputCustomerDic.Clear();
                                                    this.AdjustButtonEnable(0, false);
                                                    this.AdjustButtonEnable(2, false);
                                                    this.AdjustButtonEnable(3, true);
                                                    break;
                                                }
                                        }
                                        // 検索データがない場合には、全展開ボタン押下不可
                                        this.AllExpand_Button.Enabled = false;
                                        // グリッド列Hidden制御設定処理
                                        SetColumnHidden();

                                        return (status);
                                    }
                                default:
                                    {
                                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                                       "Search",
                                                       "検索処理に失敗しました。",
                                                       status,
                                                       MessageBoxButtons.OK);

                                        // グリッドクリア
                                        ClearGrid();

                                        // グリッド列Hidden制御設定処理
                                        SetColumnHidden();

                                        AdjustButtonEnable(2, false);
                                        return (status);
                                    }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return (status);
        }
        #endregion 保存処理実行
       
        #region 検索
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="reSearchFlag">再検索フラグ</param>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private int Search(bool reSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // クリア前回展開セルの位置
            _prevActiveUltraGridCellRow = 0;
            _prevActiveUltraGridCellCol = 0;

            // 検索条件入力チェック
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return -1;
            }

            // 検索条件格納
            SetExtrInfo(out this._extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "掛率マスタの抽出中です。";
            

            List<Rate2SearchResult> rateSearchResultList;

            try
            {
                
                if (!reSearchFlag)
                {
                    msgForm.Show();
                }

                _isDoing = true; // 仕事を行います。
                this.Add_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"]).SharedProps.Enabled = true;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"]).SharedProps.Enabled = false;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"]).SharedProps.Enabled = false;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"]).SharedProps.Enabled = false;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CustomerChange"]).SharedProps.Enabled = true;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_GoodsChange"]).SharedProps.Enabled = true;

                if (this._blGoodsCdUMntDic == null)
                {
                    // BLコードマスタ読込処理
                    ReadBLGoodsCdUMnt();
                }
                if (this._blGroupUDic == null)
                {
                    // グループコードマスタ読込処理
                    ReadBLGroupU();
                }
                // 検索処理
                status = this._rateUpdateAcs.Search(out rateSearchResultList, this._extrInfo);
                if (status == 0)
                {
                    // グリッド表示リスト取得
                    GetDisplayList(rateSearchResultList);

                    // グリッドデータ削除
                    ((DataTable)uGrid_Details.DataSource).Clear();
                    CreatSearchCondtion(ref this.uGrid_Details);

                    // グリッドデータ追加
                    SetDateToScreen(ref this.uGrid_Details);

                    // グリッド行カラー設定
                    SetRowColor(ref this.uGrid_Details);

                    //グリッド列enable制御設定処理
                    SetColumnEnable(ref this.uGrid_Details);

                    // 全展開ボタン押下可
                    this.uGrid_Details.ActiveRow = null;
                    // 全展開ボタン制御
                    foreach (UltraGridRow row in this.uGrid_Details.Rows)
                    {
                        if (IntObjToInt(row.Cells[COLUMN_PARENTDIV].Value) > 0) // 展開対象有無の判断
                        {
                            // 展開対象あり、全展開ボタン押下可能
                    this.AllExpand_Button.Enabled = true;
                    this.AllExpand_Button.Focus();
                            break;
                        }
                        this.AllExpand_Button.Enabled = false;
                    }

                    _isDoing = false; // 仕事を完了しました。

                    this.AdjustButtonEnable(0, false);
                    this.AdjustButtonEnable(3, true);
                    this.chkSearchingAll.Enabled = false;

                    // グリッド列Hidden制御設定処理
                    SetColumnHidden();

                    // 検索後は子明細は非展開
                    if (!reSearchFlag)
                    {
                        this._prevAllExpand = true;
                        AllExpand_Button_Click(this.AllExpand_Button, new EventArgs());
                        this.uGrid_Details.ActiveColScrollRegion.Position = 0;
                    }
                    // 明細グリッド値の記憶
                    tempTable = ((DataTable)uGrid_Details.DataSource).Copy();
                    // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>>>
                    // 新追加行明細グリッド値記憶
                    this._newAddRowTempTable = ((DataTable)uGrid_Details.DataSource).Copy();
                    // 既存行削除
                    this._newAddRowTempTable.Rows.Clear();
                    DataRow newAddRow;
                    // 検索条件行追加
                    for (int i = 0; i < 2; i++)
                    {
                        newAddRow = this._newAddRowTempTable.NewRow();
                        foreach (UltraGridCell cell in this.uGrid_Details.Rows[i].Cells)
                        {
                            newAddRow[cell.Column.Key] = cell.Value;
                        }
                        this._newAddRowTempTable.Rows.Add(newAddRow);
                    }
                    // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<<
                    // グリッドにスクロールバー売価率ラベルの制御
                    ScrollControl();

                    return (status);
                }
                return (status);
            }
            finally
            {
                msgForm.Close();
                _isDoing = false;　// 仕事を完了しました。
            }
        }

        /// <summary>
        /// 検索条件設定処理
        /// </summary>
        /// <param name="para">検索条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報から検索条件を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void SetExtrInfo(out Rate2SearchParam para)
        {
            para = new Rate2SearchParam();
           
            // 企業コード
            para.EnterpriseCode = this._enterpriseCode;

            // 拠点
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                para.SectionCode = new string[1];
                para.SectionCode[0] = "00";
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            // 全社名称設定
            para.SectionName = new string[1];
            if (para.SectionCode[0] == "00")
            {
                para.SectionName[0] = "全社設定";
            }
            else
            {
                para.SectionName[0] = para.SectionCode[0] + " " + this.tEdit_SectionName.Text.Trim();
            }
            

            // 仕入先名称設定
            para.SupplierNm = this.tEdit_SupplierName.DataText.Trim();

            // 出力区分
            para.OutputDiv = "";
            StringBuilder tempOutDiv = new StringBuilder();
            if(_goodsMode == GoodsMode.GoodsRateG)
            {
                tempOutDiv.Append("商G ");
            }
            else 
            {
                tempOutDiv.Append("層別 ");
            }

            if (_customerSearchMode == CustomerSearchMode.CustomerRateG)
            {
                tempOutDiv.Append("得意先掛率ｸﾞﾙｰﾌﾟ");
            }
            else
            {
                tempOutDiv.Append("得意先");
            }

            para.OutputDiv = tempOutDiv.ToString();

            // 得意先検索モード
            para.CustomerSearchMode = (Int32)_customerSearchMode;


            // 仕入先
            para.SupplierCd = this.tNedit_SupplierCd.GetInt();

            // 商品掛率Ｇ
            para.GoodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

            // メーカーコード
            para.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // メーカー名称
            para.GoodsMakerNm = this.tEdit_MakerName.Text.Trim();

            // 層別
            para.GoodsRateRank = this.GoodsRateRank_tEdit.Text.Trim();

            // 商品切替モードモード
            para.GoodsChangeMode = (Int32)this._goodsMode;

            // 初検索時
            if (this.chkSearchingAll.Enabled )
            {

                // 得意先検索条件取得
                GetCustomerSecCondition();

                // 得意先掛率グループ
                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    para.CustRateGrpCode = new int[this._targetDic.Keys.Count];

                    int index = 0;
                    foreach (int key in this._targetDic.Keys)
                    {
                        para.CustRateGrpCode[index] = key;
                        index++;
                    }

                    // 得意先掛率グループコード(=-1)：指定なし分
                    if (para.CustRateGrpCode.Length > this._targetDic.Keys.Count)
                    {
                        // this._targetDic の先頭に"指定なし"を追加しているので 0 番目
                        para.CustRateGrpCode[0] = ALL_CUST_RATE_GRP_CODE;
                    }
                    // 手入力得意先掛率Ｇが「１００」の場合には、「ALL」を検索しない
                    if (para.CustRateGrpCode.Length > 100
                            && para.CustRateGrpCode[0] == ALL_CUST_RATE_GRP_CODE)
                    {
                        int[] tempCustRateGrpCode = new int[100];
                        for (int i = 1; i < para.CustRateGrpCode.Length; i++)
                        {
                            tempCustRateGrpCode[i - 1] = para.CustRateGrpCode[i ];
                        }
                        para.CustRateGrpCode = tempCustRateGrpCode;
                    }
                }
                // 得意先
                else
                {
                    para.CustomerCode = new int[this._targetDic.Keys.Count];

                    int index = 0;
                    foreach (int key in this._targetDic.Keys)
                    {
                        para.CustomerCode[index] = key;
                        index++;
                    }
                }
                // 前回記憶検索条件のクリア
                _inputCustomerDic.Clear();
                for (int i = 10; i < 310; i++)
                {
                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[i].Value.ToString()) && this.uGrid_Details.Rows[0].Cells[i].Value.ToString() != ALL_CUST_RATE_GRP)
                    {
                        string customerKey = this._customerSearchMode.ToString() + "-" + this.chkSearchingAll.Checked.ToString() + "-" + i.ToString();
                        if (!this._inputCustomerDic.ContainsKey(customerKey))
                        {
                            this._inputCustomerDic.Add(customerKey, this.uGrid_Details.Rows[0].Cells[i].Value.ToString());
                        }
                        else
                        {
                            this._inputCustomerDic[customerKey] = this.uGrid_Details.Rows[0].Cells[i].Value.ToString();
                        }
                    }
                }
            }
            // 再検索時（保存後、検索ボタンをクリックする）
            else
            {
                // 得意先掛率グループ
                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    // 手入力得意先掛率Ｇが「１００」の場合には、「ALL」を検索しない
                    if (this._targetDic.Keys.Count > 100
                       && this._targetDic.ContainsKey(ALL_CUST_RATE_GRP_CODE))
                    {
                        this._targetDic.Remove(ALL_CUST_RATE_GRP_CODE);
                    }
                    para.CustRateGrpCode = new int[this._targetDic.Keys.Count];

                    int index = 0;
                    foreach (int key in this._targetDic.Keys)
                    {
                        para.CustRateGrpCode[index] = key;
                        index++;
                    }
                    // 範囲が未指定の場合には、「ALL」を追加する
                    if (!this.chkSearchingAll.Checked)
                    {
                        // 手入力得意先掛率Ｇが「１００」の場合には、「ALL」を検索しない
                        if (para.CustRateGrpCode.Length > 100
                            && para.CustRateGrpCode[0] == ALL_CUST_RATE_GRP_CODE)
                        {
                            int[] tempCustRateGrpCode = new int[100];
                            for (int i = 1; i < para.CustRateGrpCode.Length; i++)
                        {
                                tempCustRateGrpCode[i - 1] = para.CustRateGrpCode[i];
                            }
                            para.CustRateGrpCode = tempCustRateGrpCode;
                        }
                    }
                }
                // 得意先
                else
                {
                    para.CustomerCode = new int[this._targetDic.Keys.Count];

                    int index = 0;
                    foreach (int key in this._targetDic.Keys)
                    {
                        para.CustomerCode[index] = key;
                        index++;
                    }
                }
            }

            // ログイン拠点
            para.PrmSectionCode = new string[1];
            para.PrmSectionCode[0] = LoginInfoAcquisition.Employee.BelongSectionCode;

            // バッファに保持
            this._searchSectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
        }
        #endregion 検索

        #region 新追加行掛率検索
        private int NewAddRowRateSearch(UltraGridRow newAddRow, out List<Rate2SearchResult> rate2SearchResultList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // 検索条件設定
            Rate2SearchParam rowSearchPara;
            // 検索条件設定処理
            SetExtrInfo(out rowSearchPara);
            // メーカーを新追加に入力したので設定します
            rowSearchPara.GoodsMakerCd =StrObjToInt(newAddRow.Cells[COLUMN_MAKERCODE].Value);
            if (this._goodsMode == GoodsMode.GoodsRateG)
            {
                // 商品掛率Ｇを新追加に入力したので設定します
                rowSearchPara.GoodsRateGrpCode = StrObjToInt(newAddRow.Cells[COLUMN_GOODSRATEGRPCODE].Value);
            }
            else
            {
                // 層別を新追加に入力したので設定します
                rowSearchPara.GoodsRateRank = StrObjToStr(newAddRow.Cells[COLUMN_GOODSRATERANK].Value);
            }
            // グループコード設定
            rowSearchPara.GroupCd = StrObjToInt(newAddRow.Cells[COLUMN_GLCD].Value);
            // ＢＬコード設定
            rowSearchPara.BlCd= StrObjToInt(newAddRow.Cells[COLUMN_BLCD].Value);

            // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
            // 非新追加行の掛率検索条件設定
            if (newAddRow.Index > 1
                && newAddRow.Index < this._displayList.Count + 2)
            {
                switch (this._goodsMode)
                {
                    // 商品掛率Gの場合
                    case GoodsMode.GoodsRateG:
                        {
                            if (rowSearchPara.BlCd != 0)
                            {
                                // BLコードがある場合、BLグループコートと商品掛率Ｇが「０」を設定する
                                rowSearchPara.GoodsRateGrpCode = 0;
                                rowSearchPara.GroupCd = 0;
                            }
                            else if (rowSearchPara.GroupCd != 0)
                            {
                                // BLコードがない、BLグループコートがある場合、商品掛率Ｇが「０」を設定する
                                rowSearchPara.GoodsRateGrpCode = 0;
                            }
                            break;
                        }
                    // 層別の場合
                    case GoodsMode.GoodsRateRank:
                        {
                            if (rowSearchPara.BlCd != 0)
                            {
                                // BLコードがある場合、BLグループコートが「０」を設定する
                                rowSearchPara.GroupCd = 0;
                            }
                            break;
                        }
                }
            }
            // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<

            try
            {
                // 検索実行
                status = this._rateUpdateAcs.SearchByOneGoodsInfo(out rate2SearchResultList, rowSearchPara);
            }
            finally
            {
                _isDoing = false;　// 仕事を完了しました。
            }
            return status;
        }
        #endregion 新追加行掛率検索

        # region PDF出力
        /// <summary>
        /// 帳票印刷
        /// </summary>
        /// <remarks>
        /// <br>Note        : 帳票PDFを出力します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void OutputPDF()
        {
            this.Print();
        }
        #endregion

        # region EXCELデータ出力
        /// <summary>
        /// EXCELデータ出力
        /// </summary>
        /// <remarks>
        /// <br>Note        : EXCELデータを出力します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ExportIntoExcelData()
        {
            string fileName = string.Empty;
            UltraGrid excelOutputDataGrid = null;// Excel出力用Grid
            this.openFileDialog.Reset(); // ファイルダイアログを初期化設定する
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "Excelファイル(*.xls) | *.xls";
            this.openFileDialog.FilterIndex = 0;
            // ファイル選択
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (this.openFileDialog.SafeFileName.Contains("."))
                {
                    string[] selectedFileNameSplit = this.openFileDialog.SafeFileName.Split('.'); 
                    string fileNameExt = selectedFileNameSplit[selectedFileNameSplit.Length - 1]; // ファイル名拡張子
                    if (fileNameExt != "xls" && fileNameExt != "XLS")　// 入力ファイル名の拡張子の判断
                    {
                        fileName = openFileDialog.FileName + ".xls";　// 拡張子が「xls」と違い場合、出力する時、拡張子「xls」を追加する
                    }
                    else
                    {
                        fileName = openFileDialog.FileName;
                    }
                }
                else
                {
                    fileName = openFileDialog.FileName;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            if (String.IsNullOrEmpty(fileName))
            {
                // ファイル名が指定されていない
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTEXCEL_NOFILENAME, -1, MessageBoxButtons.OK);

                return;
            }
            try
            {
                // Excel出力用Gridのデータ設定
                PMKHN09902UB excelOutput = new PMKHN09902UB();
                excelOutput.SetExcelOutputDataGrid(this.uGrid_Details, out excelOutputDataGrid);
                // 小数部最大長さ取得
                this._maxPointLengthDic = GetMaxValueCount(excelOutputDataGrid);
                // Excel出力実行
                if (this.ultraGridExcelExporter.Export(excelOutputDataGrid, fileName) != null)
                {
                    // 成功
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        MSG_OUTPUTEXCEL_SUCCEEDED, -1, MessageBoxButtons.OK);
                };
            }
            catch (Exception e)
            {

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    e.Message, -1, MessageBoxButtons.OK);
            }
        }
        #endregion

        # region CSVデータ出力
        /// <summary>
        /// CSVデータ出力
        /// </summary>
        /// <remarks>
        /// <br>Note        : CSVデータを出力します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void ExportIntoCSVData()
        {
            string fileName = string.Empty;
            this.openFileDialog.Reset(); // ファイルダイアログを初期化設定する
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.AddExtension = true;
            this.openFileDialog.Filter = "CSV ファイル(*.csv) | *.csv";
            this.openFileDialog.FilterIndex = 0;
            // ファイル選択
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (this.openFileDialog.SafeFileName.Contains("."))
                {
                    string[] selectedFileNameSplit = this.openFileDialog.SafeFileName.Split('.');
                    string fileNameExt = selectedFileNameSplit[selectedFileNameSplit.Length - 1]; // ファイル名拡張子
                    if (fileNameExt != "csv" && fileNameExt != "CSV")　// 入力ファイル名の拡張子の判断
                    {
                        fileName = openFileDialog.FileName + ".csv";　// 拡張子が「csv」と違い場合、出力する時、拡張子「csv」を追加する
                    }
                    else
                    {
                        fileName = openFileDialog.FileName;
                    }
                }
                else
                {
                    fileName = openFileDialog.FileName;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            FormattedTextWriter tw = new FormattedTextWriter();// テキスト出力クラスのインスタンス
            List<string> schemeList = new List<string>();
            List<Type> enclosingList = new List<Type>();
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            
            // 小数点表示区分設定
            string formatCount = "0.00";
            // 出力ファイル名
            tw.OutputFileName = fileName;
            // 出力項目名取得
            Dictionary<int, string> schemeDic = GetSchemeDic();
            DataTable dataTable = null;
            // テキスト出力データ取得
            GetTextOutputDataTable(out dataTable);
            foreach (string s in schemeDic.Values)
            {
                schemeList.Add(s);
                enclosingList.Add(dataTable.Columns[s].DataType);
                // 仕入率小数点表示区分設定
                if (s == COLUMN_COSTRATE)
                {
                    formatList.Add(s, formatCount);
                }
                // 得意先検索条件・売価率・原価UP率・粗利確保率の表示書式
                else if (s == uLabel_CustomerMode.Text || s == uLabel_SaleRate.Text )
                {
                    formatList.Add(s, null);
                }
                else
                {
                    formatList.Add(s, this.uGrid_Details.DisplayLayout.Bands[0].Columns[s].Format);
                }
            }
            tw.FormatList = formatList;// 出力データの表示書式
            tw.SchemeList = schemeList;// 出力項目名
            tw.DataSource = dataTable;// 出力データ
            tw.EnclosingTypeList = enclosingList;// 出力データのタイプ
            int outputCount = 0;
            int status = tw.TextOut(out outputCount);// テキスト出力実行
            if (status == 9)// 異常終了
            {
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILE_FAILED, -1, MessageBoxButtons.OK);
            }
            else
            {
                // 出力成功
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + MSG_OUTPUTFILE_SUCCEEDED, -1, MessageBoxButtons.OK);
            }
        }
        #endregion

        # region 得意先切替
        /// <summary>
        /// 得意先切替
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先切替します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks> 
        private void CustomerChange()
        {
            string customerKey = string.Empty;
            switch (this._customerSearchMode)
            {
                // 得意先掛率Ｇ
                case CustomerSearchMode.CustomerRateG:
                    {
                        this._customerSearchMode = CustomerSearchMode.Customer;
                        // 明細列
                        this.uLabel_CustomerMode.Text = CUSTOMER_MODE2;
                        this.chkSearchingAll.Text = CUSTOMERCODE;
                        this.chkSearchingAll.Checked = false;
                        customerKey = this._customerSearchMode.ToString() + "-" + this.chkSearchingAll.Checked.ToString();
                        break;
                    }
                // 得意先
                case CustomerSearchMode.Customer:
                    {
                        this._customerSearchMode = CustomerSearchMode.CustomerRateG;
                        // 明細列
                        this.uLabel_CustomerMode.Text = CUSTOMER_MODE1;
                        this.chkSearchingAll.Text = CUSTOMERGROUPCODE;
                        this.chkSearchingAll.Checked = false;
                        customerKey = this._customerSearchMode.ToString() + "-" + this.chkSearchingAll.Checked.ToString();
                        break;
                    }
            }

            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            // 明細列
            for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
            {
                string name = string.Empty;
                string tempKey = customerKey + "-" + i.ToString();
                if (this._inputCustomerDic.ContainsKey(tempKey))
                {
                    this.uGrid_Details.Rows[0].Cells[i].Value = this._inputCustomerDic[tempKey];
                    if (_customerSearchMode == CustomerSearchMode.Customer)
                    {
                        if (!string.IsNullOrEmpty(this._inputCustomerDic[tempKey].ToString()) && CustomerIsExist(this._inputCustomerDic[tempKey], ref name))
                        {
                            this.uGrid_Details.Rows[1].Cells[i].Value = name;
                        }
                        else
                        {
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this._inputCustomerDic[tempKey].ToString()) && CustomerGIsExist(this._inputCustomerDic[tempKey], ref name))
                        {
                            this.uGrid_Details.Rows[1].Cells[i].Value = name;
                        }
                        else
                        {
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                        }
                    }
                }
                else
                {
                    this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                    this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                }
            }
            this.uGrid_Details.UpdateData();
            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
        }
        #endregion

        # region 商品切替
        /// <summary>
        /// 商品切替
        /// </summary>
        /// <remarks>
        /// <br>Note        : 商品切替します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks> 
        private void GoodsChange()
        {
            switch (this._goodsMode)
            {
                // 商品掛率G
                case GoodsMode.GoodsRateG:
                    {
                        this._goodsMode = GoodsMode.GoodsRateRank;

                        // 抽出条件部
                        this.GoodsRateRank_tEdit.Enabled = true;
                        if (this.tNedit_GoodsMGroup.Focused
                            || this.GoodsRateGrpGuide_Button.Focused)
                        {
                            this.GoodsRateRank_tEdit.Focus();
                        }
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.GoodsRateGrpGuide_Button.Enabled = false;
                        this.tNedit_GoodsMGroup.Text = string.Empty;
                        this.tEdit_GoodsRateGrpName.Text = string.Empty;

                        
                        // 明細列
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = false;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK].Hidden = false;
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                        break;
                    }
                // 層別
                case GoodsMode.GoodsRateRank:
                    {
                        this._goodsMode = GoodsMode.GoodsRateG;

                        // 抽出条件部
                        this.tNedit_GoodsMGroup.Enabled = true;
                        if (this.GoodsRateRank_tEdit.Focused)
                        {
                            this.tNedit_GoodsMGroup.Focus();
                        }
                        this.GoodsRateGrpGuide_Button.Enabled = true;
                        this.GoodsRateRank_tEdit.Enabled = false;
                        this.GoodsRateRank_tEdit.Text = string.Empty;

                       
                        // 明細列
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = true;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK].Hidden = true;
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden = false;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE].Hidden = false;
                        break;
                    }
            }

            // セル結合設定処理
            ColumnsCollection columns = uGrid_Details.DisplayLayout.Bands[0].Columns;
            SettingMergedCell(columns[COLUMN_GLCD]);
        }
        #endregion

        # region 掛率切替
        /// <summary>
        /// 掛率切替
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率切替します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks> 
        private void RateChange()
        {
            // 切替前にフォーカス位置を覚える
            int rowIndex = 0;
            string columnName = string.Empty;
            if (this.uGrid_Details.Focused && this.uGrid_Details.ActiveCell != null)
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index; // 行
                columnName = this.uGrid_Details.ActiveCell.Column.Key; // 列 
            }
            switch (this._rateMode)
            {
                // 売価率
                case RateMode.RateVal:
                    {
                        this._rateMode = RateMode.UpRate;
                        this.uLabel_SaleRate.Text = RATE_TITLE_UPRATE;
                        // 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
                        if (this.uGrid_Details.Rows.Count > 2 && this._displayList.Count == 0)
                        {
                            SetNewRowCustColumnHidden();
                        }
                        else
                        {
                            // 明細列切替
                            this.SetColumnHidden();
                        }
                        break;
                    }
                // 原価UP率
                case RateMode.UpRate:
                    {
                        this._rateMode = RateMode.GrsProfitSecureRat;
                        this.uLabel_SaleRate.Text = RATE_TITLE_GRSPROFITSECURERAT;
                        // 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
                        if (this.uGrid_Details.Rows.Count > 2 && this._displayList.Count == 0)
                        {
                            SetNewRowCustColumnHidden();
                        }
                        else
                        {
                            // 明細列切替
                            this.SetColumnHidden();
                        }
                        break;
                    }
                // 粗利確保率
                case RateMode.GrsProfitSecureRat:
                    {
                        this._rateMode = RateMode.RateVal;
                        this.uLabel_SaleRate.Text = RATE_TITLE_RATEVAL;
                        // 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
                        if (this.uGrid_Details.Rows.Count > 2 && this._displayList.Count == 0)
                        {
                            SetNewRowCustColumnHidden();
                        }
                        else
                        {
                            // 明細列切替
                            this.SetColumnHidden();
                        }
                        break;
                    }
            }
            // 切替後で、フォーカス位置設定
            // 非掛率列
            if (string.IsNullOrEmpty(columnName)) return;
            this.uGrid_Details.BeginUpdate();
            this.uGrid_Details.Focus();
            if (!columnName.Contains(COLUMN_SALERATE)
                && (!columnName.Contains(COLUMN_UPRATE))
                && (!columnName.Contains(COLUMN_GRSPROFITSECURERAT)))
            {
                this.uGrid_Details.Rows[rowIndex].Cells[columnName].Selected = true;
                this.uGrid_Details.Rows[rowIndex].Cells[columnName].Activate();
                if (this.uGrid_Details.Rows[rowIndex].Cells[columnName].Activation == Activation.AllowEdit)
                {
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            // 掛率列
            else
            {
                string num = string.Empty;
                // 掛率列の列番号取得
                if (columnName.Contains(COLUMN_SALERATE))
                {
                    num = columnName.Remove(0, COLUMN_SALERATE.Length);
                }
                else if (columnName.Contains(COLUMN_UPRATE))
                {
                    num = columnName.Remove(0, COLUMN_UPRATE.Length);
                }
                else
                {
                    num = columnName.Remove(0, COLUMN_GRSPROFITSECURERAT.Length);
                }
                // フォーカス設定
                switch (this._rateMode)
                {
                    // 売価率の場合
                    case RateMode.RateVal:
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SALERATE + num].Selected = true;
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SALERATE + num].Activate();
                            if (this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_SALERATE + num].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    // 原価UP率の場合
                    case RateMode.UpRate:
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_UPRATE + num].Selected = true;
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_UPRATE + num].Activate();
                            if (this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_UPRATE + num].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                    // 粗利確保率の場合
                    case RateMode.GrsProfitSecureRat:
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GRSPROFITSECURERAT + num].Selected = true;
                            this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GRSPROFITSECURERAT + num].Activate();
                            if (this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_GRSPROFITSECURERAT + num].Activation == Activation.AllowEdit)
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                        }
                }
            }
            this.uGrid_Details.EndUpdate();
        }
        #endregion

        /// <summary>
        /// ボタンの有効/無効切替
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="enable">有効/無効</param>
        /// <remarks>
        /// <br>Note        : ボタンの有効/無効切替します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br> 
        /// </remarks>
        private void AdjustButtonEnable(int mode, bool enable)
        {
            // その他仕事を行います。ボタン制御処理を行います。
            if (_isDoing)
            {
                return;
            }

            switch (mode)
            {
                case 0:
                    {
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"]).SharedProps.Enabled = enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"]).SharedProps.Enabled = !enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"]).SharedProps.Enabled = !enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"]).SharedProps.Enabled = !enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CustomerChange"]).SharedProps.Enabled = enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_GoodsChange"]).SharedProps.Enabled = enable;
                        break;
                    }
                // ガイド
                case 1:
                    {
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"]).SharedProps.Enabled = enable;
                        break;
                    }
                case 2:
                    {
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"]).SharedProps.Enabled = enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"]).SharedProps.Enabled = enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"]).SharedProps.Enabled = enable;
                        break;
                    }
                case 3:
                    {
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CustomerChange"]).SharedProps.Enabled = enable;
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_GoodsChange"]).SharedProps.Enabled = enable;
                        break;
                    }
            }

            // 行追加の場合、ボタン制御
            if (this.uGrid_Details.Rows.Count > this._displayList.Count + 2)
            {
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_PDF"]).SharedProps.Enabled = false;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"]).SharedProps.Enabled = false;
                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"]).SharedProps.Enabled = false;
            }


            #region 仕入先、得意先掛率G(得意先）三つ項目欄に条件が入力ある時、行追加ボタンを操作可にする
            if (this.tNedit_SupplierCd.GetInt() > 0)
            {
                Boolean hasInputSearchData = false;

                for (int index = 9; index < this.uGrid_Details.Rows[0].Cells.Count; index++)
                {
                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[index].Text.Trim()) 
                        && (uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden == false))
                    {
                        hasInputSearchData = true;
                        break;
                    }
                }

                if (hasInputSearchData)
                {
                    this.Add_Button.Enabled = true;
                }
                else
                {
                    this.Add_Button.Enabled = false;
                }
            }
            else
            {
                this.Add_Button.Enabled = false;
            }
            #endregion 仕入先、得意先掛率G(得意先）三つ項目欄に条件が入力ある時、行追加ボタンを操作可にする
        }

        /// <summary>
        /// 検索したデータリストは画面のグリッドに表示
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : 検索したデータリストは画面のグリッドに表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br> 
        /// </remarks>
        private void SetDateToScreen(ref UltraGrid uGrid)
        {
            // データが無い場合
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                return;
            }

            List<Rate2SearchResult> targetList;

            this.uGrid_Details.BeginUpdate();
            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            this.uGrid_Details.BeforeRowActivate -= new Infragistics.Win.UltraWinGrid.RowEventHandler(this.uGrid_Details_BeforeRowActivate);
            // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
            // セル初期設定色を記憶するDicの初期化
            this._cellIniSettingColorDic.Clear();
            // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
            try
            {
                // 検索条件の設定
                this._searchDic.Clear();
                string name = string.Empty;
                int newColumnIndex = 1;
                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    foreach (int key in this._extrInfo.CustRateGrpCode)
                    {
                        this._searchDic.Add(key, newColumnIndex);

                        CellsCollection cells = uGrid.Rows[0].Cells;

                        if (key < 0)
                        {
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                        }
                        else
                        {
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("0000");
                        }

                        cells = uGrid.Rows[1].Cells;
                        if (key < 0)
                        {
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = string.Empty;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = string.Empty;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = string.Empty;
                        }
                        else
                        {
                            CustomerGIsExist(key.ToString(), ref name);
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;
                        }
                        newColumnIndex++;
                    }
                }
                else
                {
                    foreach (int key in this._extrInfo.CustomerCode)
                    {
                        this._searchDic.Add(key, newColumnIndex);

                        CellsCollection cells = uGrid.Rows[0].Cells;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("00000000");

                        cells = uGrid.Rows[1].Cells;
                        CustomerIsExist(key.ToString(), ref name);
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;

                        newColumnIndex++;
                    }
                }

                // 性能UP、「AddNew()」を替代する
                DataTable dtTblSrc = (DataTable)uGrid_Details.DataSource;
                dtTblSrc.AcceptChanges();

                for (int i = 0; i < this._displayList.Count; i++)
                {
                    DataRow row = dtTblSrc.NewRow();
                    dtTblSrc.Rows.Add(row);
                }
                // 最初の2行固定する
                //uGrid.DisplayLayout.Rows[0].Fixed = true;
                //uGrid.DisplayLayout.Rows[1].Fixed = true;
                bool expendFlag = false;
                // 検索結果の設定
                for (int index = 0; index < this._displayList.Count; index++)
                {
                    CellsCollection cells = uGrid.Rows[index + 2].Cells;

                    Rate2SearchResult result = (Rate2SearchResult)this._displayList[index];
                    Dictionary<string, Color> cellColorDic = new Dictionary<string, Color>(); // ADD donggy 2013/04/19 for Redmine#35355
                    // No
                    cells[COLUMN_NO].Value = index + 1;

                    // メーカー
                    cells[COLUMN_MAKERCODE].Value = result.PrmPartsMakerCd.ToString("0000");
                    cells[COLUMN_MAKERCODE].Activation = Activation.NoEdit;
                    cells[COLUMN_MAKERNAME].Value = GetMakerName(result.PrmPartsMakerCd);
                    // 仕入先
                    cells[COLUMN_SUPPLIERCODE].Value = result.GoodsSupplierCd.ToString("000000");

                    if (result.PrmTbsPartsCode == 0 && result.BGBLGroupCode == 0)
                    {
                        // 商掛Ｇ
                        cells[COLUMN_GOODSRATEGRPCODE].Value = result.PrmGoodsMGroup.ToString("0000");
                        cells[COLUMN_GOODSRATEGRPCODE].Activation = Activation.NoEdit;
                        // 層別
                        cells[COLUMN_GOODSRATERANK].Value = result.GoodsRateRank;
                        cells[COLUMN_GOODSRATERANK].Activation= Activation.NoEdit;
                        // GLCD
                        cells[COLUMN_GLCD].Value = DBNull.Value;
                        cells[COLUMN_GLCD].Activation = Activation.NoEdit;
                        // BLCD
                        cells[COLUMN_BLCD].Value = DBNull.Value;
                        cells[COLUMN_BLCD].Activation= Activation.NoEdit;
                        if (this._goodsMode == GoodsMode.GoodsRateG)
                        {
                            // 名称
                            if (!string.IsNullOrEmpty(GetGoodsGroupName(result.PrmGoodsMGroup)))
                            {
                                cells[COLUMN_NAME].Value = GetGoodsGroupName(result.PrmGoodsMGroup);
                            }
                            else
                            {
                                cells[COLUMN_NAME].Value = "未登録";
                            }
                        }
                        else
                        {
                            // 名称
                            cells[COLUMN_NAME].Value = DBNull.Value;
                        }
                        // 親子区分
                        cells[COLUMN_PARENTDIV].Value = 0;

                        string key = MakeParentKey(result);
                        targetList = this._parentRateValList.FindAll(delegate(Rate2SearchResult target)
                        {
                            if (key == MakeParentKey(target))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });

                        if (expandDic.ContainsKey(key))
                        {
                            expendFlag = expandDic[key];
                        }
                    }
                    else if (result.PrmTbsPartsCode == 0 && result.BGBLGroupCode != 0)
                    {
                        // 商掛Ｇ
                        cells[COLUMN_GOODSRATEGRPCODE].Value = result.PrmGoodsMGroup.ToString("0000");
                        cells[COLUMN_GOODSRATEGRPCODE].Activation = Activation.NoEdit;
                        // 層別
                        cells[COLUMN_GOODSRATERANK].Value = result.GoodsRateRank;
                        cells[COLUMN_GOODSRATERANK].Activation = Activation.NoEdit;
                        // GLCD
                        cells[COLUMN_GLCD].Value = result.BGBLGroupCode.ToString("00000");
                        cells[COLUMN_GLCD].Activation = Activation.NoEdit;
                        // BLCD
                        cells[COLUMN_BLCD].Value = DBNull.Value;
                        cells[COLUMN_BLCD].Activation = Activation.NoEdit;
                        // 名称
                        cells[COLUMN_NAME].Value = GetBLGroupName(result.BGBLGroupCode);
                        // 親子区分
                        cells[COLUMN_PARENTDIV].Value = 2;

                        string key = MakeParentGRKey(result);
                        targetList = this._parentGRRateValList.FindAll(delegate(Rate2SearchResult target)
                        {
                            if (key == MakeParentGRKey(target))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });

                        // 展開フラグ
                        cells[COLUMN_EXPANDFLG].Value = expendFlag;
                        
                        uGrid.Rows[index + 2].Hidden = !(bool)cells[COLUMN_EXPANDFLG].Value;

                    }
                    else
                    {
                        // 商掛Ｇ
                        cells[COLUMN_GOODSRATEGRPCODE].Value = result.PrmGoodsMGroup.ToString("0000");
                        cells[COLUMN_GOODSRATEGRPCODE].Activation = Activation.NoEdit;
                        // 層別
                        cells[COLUMN_GOODSRATERANK].Value = result.GoodsRateRank;
                        cells[COLUMN_GOODSRATERANK].Activation = Activation.NoEdit;
                        // GLCD
                        cells[COLUMN_GLCD].Value = result.BGBLGroupCode.ToString("00000");
                        cells[COLUMN_GLCD].Activation = Activation.NoEdit;
                        // BLCD
                        cells[COLUMN_BLCD].Value = result.PrmTbsPartsCode.ToString("00000");
                        cells[COLUMN_BLCD].Activation = Activation.NoEdit;
                        // 名称
                        cells[COLUMN_NAME].Value = GetBLGoodsName(result.PrmTbsPartsCode);
                        // 親子区分
                        cells[COLUMN_PARENTDIV].Value = 1;

                        string key = MakeChildKey(result);
                        targetList = this._childRateValList.FindAll(delegate(Rate2SearchResult target)
                        {
                            if (key == MakeChildKey(target))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });

                        // 展開フラグ
                        cells[COLUMN_EXPANDFLG].Value = expendFlag;

                        uGrid.Rows[index + 2].Hidden = !(bool)cells[COLUMN_EXPANDFLG].Value;
                    }

                    if (targetList != null)
                    {
                        foreach (Rate2SearchResult target in targetList)
                        {
                            if (target.UnitPriceKind == "1")
                            {
                                // 売価率
                                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                                {
                                    if (IsAllCustRateGrpCode(target))
                                    {
                                        if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                        {
                                            // 論理削除データ制御
                                            if (target.LogicalDeleteCode == 1)
                                            {
                                                // 売価率
                                                cells[COLUMN_SALERATE1.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                cells[COLUMN_SALERATE1.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                                cells[COLUMN_SALERATE1.ToString()].Activation = Activation.Disabled;
                                                // 原価ＵＰ率
                                                cells[COLUMN_UPRATE1.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                cells[COLUMN_UPRATE1.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                                cells[COLUMN_UPRATE1.ToString()].Activation = Activation.Disabled;
                                                // 粗利確保率
                                                cells[COLUMN_GRSPROFITSECURERAT1.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                cells[COLUMN_GRSPROFITSECURERAT1.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                                cells[COLUMN_GRSPROFITSECURERAT1.ToString()].Activation = Activation.Disabled;
                                                continue;
                                            }
                                            // 非正規データ表示しない
                                            else if (target.LogicalDeleteCode != 0)
                                            {
                                                continue;
                                            }
                                            if (target.RateVal != 0)
                                            {
                                                // 売価率
                                                cells[COLUMN_SALERATE1.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.RateVal));
                                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                                {
                                                    cells[COLUMN_SALERATE1].Appearance.ForeColor = Color.Red;
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                                // 色変更ありセルの初期設定色記憶
                                                if (!cellColorDic.ContainsKey(COLUMN_SALERATE1))
                                                {
                                                    cellColorDic.Add(COLUMN_SALERATE1, cells[COLUMN_SALERATE1].Appearance.ForeColor);
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                            }
                                            if (target.UpRate != 0)
                                            {
                                                // 原価ＵＰ率
                                                cells[COLUMN_UPRATE1.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.UpRate));
                                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                                {
                                                    cells[COLUMN_UPRATE1].Appearance.ForeColor = Color.Red;
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                                // 色変更ありセルの初期設定色記憶
                                                if (!cellColorDic.ContainsKey(COLUMN_UPRATE1))
                                                {
                                                    cellColorDic.Add(COLUMN_UPRATE1, cells[COLUMN_UPRATE1].Appearance.ForeColor);
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                            }

                                            if (target.GrsProfitSecureRate != 0)
                                            {
                                                // 粗利確保率
                                                cells[COLUMN_GRSPROFITSECURERAT1.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.GrsProfitSecureRate));
                                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                                {
                                                    cells[COLUMN_GRSPROFITSECURERAT1].Appearance.ForeColor = Color.Red;
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                                // 色変更ありセルの初期設定色記憶
                                                if (!cellColorDic.ContainsKey(COLUMN_GRSPROFITSECURERAT1))
                                                {
                                                    cellColorDic.Add(COLUMN_GRSPROFITSECURERAT1, cells[COLUMN_GRSPROFITSECURERAT1].Appearance.ForeColor);
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ExistsCustRateGrpCodeInTargetDic(target.CustRateGrpCode))
                                        {
                                            
                                            if (!_searchDic.ContainsKey(target.CustRateGrpCode))
                                            {
                                                continue;
                                            }

                                            int columnIndex = _searchDic[target.CustRateGrpCode];
                                            // 論理削除データ制御
                                            if (target.LogicalDeleteCode == 1)
                                            {
                                                // 売価率
                                                cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                                cells[COLUMN_SALERATE + columnIndex.ToString()].Activation = Activation.Disabled;
                                                // 原価ＵＰ率
                                                cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                                cells[COLUMN_UPRATE + columnIndex.ToString()].Activation = Activation.Disabled;
                                                // 粗利確保率
                                                cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                                cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Activation = Activation.Disabled;
                                                continue;
                                            }
                                            // 非正規データ表示しない
                                            else if (target.LogicalDeleteCode != 0)
                                            {
                                                continue;
                                            }
                                            if (target.RateVal != 0)
                                            {
                                                // 売価率
                                                cells[COLUMN_SALERATE + columnIndex.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.RateVal));
                                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                                {
                                                    cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.ForeColor = Color.Red;
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                                // 色変更ありセルの初期設定色記憶
                                                if (!cellColorDic.ContainsKey(COLUMN_SALERATE + columnIndex.ToString()))
                                                {
                                                    cellColorDic.Add(COLUMN_SALERATE + columnIndex.ToString(), cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.ForeColor);
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                            }
                                            if (target.UpRate != 0)
                                            {
                                                // 原価ＵＰ率
                                                cells[COLUMN_UPRATE + columnIndex.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.UpRate));
                                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                                {
                                                    cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.ForeColor = Color.Red;
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                                // 色変更ありセルの初期設定色記憶
                                                if (!cellColorDic.ContainsKey(COLUMN_UPRATE + columnIndex.ToString()))
                                                {
                                                    cellColorDic.Add(COLUMN_UPRATE + columnIndex.ToString(), cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.ForeColor);
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                            }

                                            if (target.GrsProfitSecureRate != 0)
                                            {
                                                // 粗利確保率
                                                cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.GrsProfitSecureRate));
                                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                                {
                                                    cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.ForeColor = Color.Red;
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                                // 色変更ありセルの初期設定色記憶
                                                if (!cellColorDic.ContainsKey(COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()))
                                                {
                                                    cellColorDic.Add(COLUMN_GRSPROFITSECURERAT + columnIndex.ToString(), cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.ForeColor);
                                                }
                                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (!_searchDic.ContainsKey(target.CustomerCode))
                                    {
                                        continue;
                                    }
                                    int columnIndex = _searchDic[target.CustomerCode];
                                    // 論理削除データ制御
                                    if (target.LogicalDeleteCode == 1)
                                    {
                                        // 売価率
                                        cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                        cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                        cells[COLUMN_SALERATE + columnIndex.ToString()].Activation = Activation.Disabled;
                                        // 原価ＵＰ率
                                        cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                        cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                        cells[COLUMN_UPRATE + columnIndex.ToString()].Activation = Activation.Disabled;
                                        // 粗利確保率
                                        cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                        cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                                        cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Activation = Activation.Disabled;
                                        continue;
                                    }
                                    // 非正規データ表示しない
                                    else if (target.LogicalDeleteCode != 0)
                                    {
                                        continue;
                                    }
                                    if (target.RateVal != 0)
                                    {
                                        // 売価率
                                        cells[COLUMN_SALERATE + columnIndex.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.RateVal));
                                        // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                        if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                        {
                                            cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.ForeColor = Color.Red;
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                        // 色変更ありセルの初期設定色記憶
                                        if (!cellColorDic.ContainsKey(COLUMN_SALERATE + columnIndex.ToString()))
                                        {
                                            cellColorDic.Add(COLUMN_SALERATE + columnIndex.ToString(), cells[COLUMN_SALERATE + columnIndex.ToString()].Appearance.ForeColor);
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                    }
                                    if (target.UpRate != 0)
                                    {
                                        // 原価ＵＰ率
                                        cells[COLUMN_UPRATE + columnIndex.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.UpRate));
                                        // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                        if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                        {
                                            cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.ForeColor = Color.Red;
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                        // 色変更ありセルの初期設定色記憶
                                        if (!cellColorDic.ContainsKey(COLUMN_UPRATE + columnIndex.ToString()))
                                        {
                                            cellColorDic.Add(COLUMN_UPRATE + columnIndex.ToString(), cells[COLUMN_UPRATE + columnIndex.ToString()].Appearance.ForeColor);
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                    }

                                    if (target.GrsProfitSecureRate != 0)
                                    {
                                        // 粗利確保率
                                        cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.GrsProfitSecureRate));
                                        // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                        if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                        {
                                            cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.ForeColor = Color.Red;
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                        // 色変更ありセルの初期設定色記憶
                                        if (!cellColorDic.ContainsKey(COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()))
                                        {
                                            cellColorDic.Add(COLUMN_GRSPROFITSECURERAT + columnIndex.ToString(), cells[COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].Appearance.ForeColor);
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                                    }
                                }
                            }
                            else if (target.UnitPriceKind == "2")
                            {
                                // 論理削除データ制御
                                if (target.LogicalDeleteCode == 1)
                                {
                                    // 仕入率
                                    cells[COLUMN_COSTRATE].Appearance.BackColorDisabled = Color.Gainsboro;
                                    cells[COLUMN_COSTRATE].Appearance.ForeColorDisabled = Color.Black;
                                    cells[COLUMN_COSTRATE].Activation = Activation.Disabled;
                                    continue;
                                }
                                // 非正規データ表示しない
                                else if (target.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }
                                // 仕入率
                                cells[COLUMN_COSTRATE].Value = string.Format("{0:0.00}", DoubleObjToDouble(target.RateVal));
                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                if (target.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != target.SectionCode.Trim())
                                {
                                    cells[COLUMN_COSTRATE].Appearance.ForeColor = Color.Red;
                                }
                                // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                                // 色変更ありセルの初期設定色記憶
                                if (!cellColorDic.ContainsKey(COLUMN_COSTRATE))
                                {
                                    cellColorDic.Add(COLUMN_COSTRATE, cells[COLUMN_COSTRATE].Appearance.ForeColor);
                                }
                                // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                            }
                        }
                    }

                    // 展開フラグ
                    //cells[COLUMN_EXPANDFLG].Value = false;
                    // 商品掛率グループコード(内部保持用)
                    cells[COLUMN_GOODSRATEGRPCODE_HIDE].Value = result.PrmGoodsMGroup.ToString("0000");
                    // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                    if (!this._cellIniSettingColorDic.ContainsKey(index + 2))
                    {
                        this._cellIniSettingColorDic.Add(index + 2, cellColorDic);
                    }
                    // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                }
            }
            finally
            {
                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                this.uGrid_Details.BeforeRowActivate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.uGrid_Details_BeforeRowActivate);
                this.uGrid_Details.UpdateData();
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// グリッドにスクロールバー売価率ラベルの制御
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドにスクロールバー売価率ラベルの制御を行う。</br>
        /// <br>Programmer  : gezh</br>
        /// <br>Date        : 2013/03/25</br> 
        /// </remarks>
        public void ScrollControl()
        {
            int rowHeight = uGrid_Details.Rows[0].Height;
            int displayRowCount =0;
            foreach (UltraGridRow row in uGrid_Details.Rows)
            {
                if (!row.Hidden)
                {
                    displayRowCount++;
                }
            }
            bool largerFlg = false;
            int height = this.panel3.Size.Height;
            int width = this.panel3.Size.Width;
            if (uGrid_Details.Size.Height - 4 <= rowHeight * displayRowCount)
            {
                largerFlg = true;
            }

            if (panel3.Tag ==null)
            {
                if (largerFlg)
                {
                    this.panel3.Size = new Size(width - 18, height);
                }
            }
            else
            {
                if (largerFlg)
                {
                    if (panel3.Tag.ToString() == "1")
                    {
                        this.panel3.Size = new Size(width - 18, height);
                    }
                }
                else
                {
                    if (panel3.Tag.ToString() == "0")
                    {
                        this.panel3.Size = new Size(width + 18, height);
                    }
                }
            }
            panel3.Tag = "1";
            if (largerFlg)
            {
                panel3.Tag = "0";
            }
        }

        #region データ取得
        /// <summary>
        /// グリッド表示リスト取得処理
        /// </summary>
        /// <param name="rateSearchResultList">掛率マスタ検索結果リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドに表示するリストを取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void GetDisplayList(List<Rate2SearchResult> rateSearchResultList)
        {
            this._parentList = new List<Rate2SearchResult>();
            this._parentGRList = new List<Rate2SearchResult>();
            this._childList = new List<Rate2SearchResult>();
            this._displayList = new List<Rate2SearchResult>();

            this._parentRateValList = new List<Rate2SearchResult>();
            this._parentGRRateValList = new List<Rate2SearchResult>();
            this._childRateValList = new List<Rate2SearchResult>();

            //---------------------------
            // 親データ取得
            //---------------------------
            # region 親データ取得
            this._parentList = rateSearchResultList.FindAll(delegate(Rate2SearchResult target)
            {
                if (target.PrmTbsPartsCode == 0 && target.BGBLGroupCode == 0) // TODO
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });
            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, Rate2SearchResult> parentDic = new Dictionary<string, Rate2SearchResult>();
            foreach (Rate2SearchResult result in this._parentList)
            {
                string key = MakeParentKey(result);
                if (!parentDic.ContainsKey(key))
                {
                    parentDic.Add(key, result.Clone());
                }
                else
                {
                    if (result.LotCount < parentDic[key].LotCount)
                    {
                        parentDic[key] = result.Clone();
                    }
                }
            }
            this._parentRateValList = this._parentList; // 掛率取得用に親データ退避
            this._parentList = new List<Rate2SearchResult>();
            foreach (Rate2SearchResult result in parentDic.Values)
            {
                this._parentList.Add(result.Clone());
            }
            # endregion

            //---------------------------
            // グループデータ取得
            //---------------------------
            # region グループデータ取得
            this._parentGRList = rateSearchResultList.FindAll(delegate(Rate2SearchResult target)
            {
                if (target.PrmTbsPartsCode == 0 && target.BGBLGroupCode != 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, Rate2SearchResult> parenGRtDic = new Dictionary<string, Rate2SearchResult>();
            foreach (Rate2SearchResult result in this._parentGRList)
            {
                string key = MakeParentGRKey(result);
                if (!parenGRtDic.ContainsKey(key))
                {
                    parenGRtDic.Add(key, result.Clone());
                }
                else
                {
                    if (result.LotCount < parenGRtDic[key].LotCount)
                    {
                        parenGRtDic[key] = result.Clone();
                    }
                }
            }
            this._parentGRRateValList = this._parentGRList; // 掛率取得用に親データ退避
            this._parentGRList = new List<Rate2SearchResult>();
            foreach (Rate2SearchResult result in parenGRtDic.Values)
            {
                this._parentGRList.Add(result.Clone());
            }
            # endregion

            //---------------------------
            // 子データ取得
            //---------------------------
            # region 子データ取得
            this._childList = rateSearchResultList.FindAll(delegate(Rate2SearchResult target)
            {
                if (target.PrmTbsPartsCode != 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });
            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, Rate2SearchResult> childDic = new Dictionary<string, Rate2SearchResult>();
            foreach (Rate2SearchResult result in this._childList)
            {
                string key = MakeChildKey(result);
                if (!childDic.ContainsKey(key))
                {
                    childDic.Add(key, result.Clone());
                }
                else
                {
                    if (result.LotCount < childDic[key].LotCount)
                    {
                        childDic[key] = result.Clone();
                    }
                }
            }
            this._childRateValList = this._childList; // 掛率取得用に子データ退避
            this._childList = new List<Rate2SearchResult>();
            foreach (Rate2SearchResult result in childDic.Values)
            {
                this._childList.Add(result.Clone());
            }
            # endregion

            //---------------------------
            // 表示リスト取得(親)
            //---------------------------
            Dictionary<string, Rate2SearchResult> parentDispList = new Dictionary<string, Rate2SearchResult>();
            foreach (Rate2SearchResult parentResult in this._parentList)
            {
                string key = MakeParentKey(parentResult);

                if (parentDispList.ContainsKey(key))
                {
                    continue;
                }

                // 表示リストに追加
                parentDispList.Add(key, parentResult);
            }

            //---------------------------
            // 表示リスト取得(親子)
            //---------------------------
            Dictionary<string, Rate2SearchResult> childDispDic = new Dictionary<string, Rate2SearchResult>();
            Dictionary<string, Rate2SearchResult> childGRDispDic = new Dictionary<string, Rate2SearchResult>();
            this._parentChildIndexDic = new Dictionary<int, ArrayList>();
            ArrayList childIndexList;

            int parentIndex = 2;

            foreach (string key in parentDispList.Keys)
            {
                childIndexList = new ArrayList();

                // 親を追加
                this._displayList.Add(((Rate2SearchResult)parentDispList[key]).Clone());

                List<Rate2SearchResult> childGRDispList = this._parentGRList.FindAll(delegate(Rate2SearchResult target)
                 {
                     if (key == MakeParentKey(target))
                     {
                         return (true);
                     }
                     else
                     {
                         return (false);
                     }
                 });

                int childIndex = parentIndex + 1;
                if (childGRDispList != null)
                {
                    foreach (Rate2SearchResult result in childGRDispList)
                    {
                        string childKey = MakeParentGRKey(result);

                        if (childGRDispDic.ContainsKey(childKey))
                        {
                            continue;
                        }
                        childGRDispDic.Add(childKey, result.Clone());
                    }
                }
                else
                {
                    this._parentChildIndexDic.Add(parentIndex, null);

                    parentIndex++;
                }

                List<Rate2SearchResult> childDispList = new List<Rate2SearchResult>();
                //グループデータ処理
                foreach (Rate2SearchResult rate2SearchResult in childGRDispList)
                {
                    this._displayList.Add(rate2SearchResult.Clone());

                    childIndexList.Add(childIndex);
                    childIndex++;

                    // 親に関連付く子を取得
                    childDispList = this._childList.FindAll(delegate(Rate2SearchResult target)
                    {
                        if (MakeParentGRKey(rate2SearchResult) == MakeParentGRKey(target))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    // 子を追加

                    if (childDispList != null)
                    {
                        foreach (Rate2SearchResult result in childDispList)
                        {
                            string childKey = MakeChildKey(result);

                            if (childDispDic.ContainsKey(childKey))
                            {
                                continue;
                            }
                            childDispDic.Add(childKey, result.Clone());

                            this._displayList.Add(result.Clone());

                            childIndexList.Add(childIndex);
                            childIndex++;
                        }
                    }

                }

                // 親に関連付く子を取得
                childDispList = this._childList.FindAll(delegate(Rate2SearchResult target)
                {
                    if (key == MakeParentKey(target))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                // 子を追加

                if (childDispList != null)
                {
                    foreach (Rate2SearchResult result in childDispList)
                    {
                        string childKey = MakeChildKey(result);

                        if (childDispDic.ContainsKey(childKey))
                        {
                            continue;
                        }
                        childDispDic.Add(childKey, result.Clone());

                        this._displayList.Add(result.Clone());

                        childIndexList.Add(childIndex);
                        childIndex++;
                    }
                }

                this._parentChildIndexDic.Add(parentIndex, childIndexList);

                parentIndex = childIndex;
                Rate2SchRstSort rate2SchRstSort = new Rate2SchRstSort((int)_goodsMode);
                this._displayList.Sort(rate2SchRstSort);
            }
        }

        /// <summary>
        /// 更新データ取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note        : 更新データを取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// <br>Update Note : 2013/04/19 donggy</br>
        /// <br>管理番号    : 10901273-00 </br>
        /// <br>              Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
        /// <br>　　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            string key;
            List<Rate2SearchResult> resultList;

            Rate updateRate = new Rate();

            this.uGrid_Details.ActiveCell = null;

            for (int rowIndex = 2; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

                // 親子区分
                int parentDiv = IntObjToInt(cells[COLUMN_PARENTDIV].Value);
                // 新追加行
                if (parentDiv == -1)
                {
                    continue;
                }
                // 既存行
                if (parentDiv == 0)
                {
                    //----------------
                    // 親明細
                    //----------------

                    key = MakeParentKey(cells);

                    resultList = this._parentRateValList.FindAll(delegate(Rate2SearchResult target)
                    {
                        if (key == MakeParentKey(target))
                        {
                            // 単価掛率設定区分の設定が無い場合、新規
                            if (string.IsNullOrEmpty(target.UnitRateSetDivCd.Trim())) return false;
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                }
                else if (parentDiv == 2)
                {
                    //----------------
                    // グループ親明細
                    //----------------

                    key = MakeParentGRKey(cells);

                    resultList = this._parentGRRateValList.FindAll(delegate(Rate2SearchResult target)
                    {
                        if (key == MakeParentGRKey(target))
                        {
                            // 単価掛率設定区分の設定が無い場合、新規
                            if (string.IsNullOrEmpty(target.UnitRateSetDivCd.Trim())) return false;
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                }
                else 
                {
                    //----------------
                    // 子明細
                    //----------------

                    key = MakeChildKey(cells);

                    resultList = this._childRateValList.FindAll(delegate(Rate2SearchResult target)
                    {
                        if (key == MakeChildKey(target))
                        {
                            // 単価掛率設定区分の設定が無い場合、新規
                            if (string.IsNullOrEmpty(target.UnitRateSetDivCd.Trim())) return false;
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                }

                if (resultList == null)
                {
                    continue;
                }

                // 仕入率チェック
                # region 仕入率
                Rate2SearchResult result = resultList.Find(delegate(Rate2SearchResult target)
                {
                    if (target.UnitPriceKind == "2")
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (result != null)
                {
                    // 変更データ取得
                    //UpdateRateData(ref saveList, ref deleteList,cells, result, result.UnitPriceKind, 0); // DEL donggy 2013/04/19 for Redmine#35355
                    UpdateRateData(ref saveList, ref deleteList, cells, result, result.UnitPriceKind, 0, parentDiv, 0); // ADD donggy 2013/04/19 for Redmine#35355
                }
                else
                {
                    if (DoubleObjToDouble(cells[COLUMN_COSTRATE].Value) != 0)
                    {
                        // データ追加
                        MakeNewCostrateData(out updateRate, cells, parentDiv);
                        //saveList.Add(updateRate.Clone()); // DEL donggy 2013/04/19 for Redmine#35355 
                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>
                        if (updateRate != null
                            && updateRate.RateVal != 0.0)
                        {
                            saveList.Add(updateRate.Clone());
                        }
                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                        
                    }
                }
                # endregion

                // 売価率チェック、原価ＵＰ率チェック、粗利確保率チェック
                foreach (int code in this._targetDic.Keys)
                {
                    // 元データ取得
                    GetRateUpdateData(ref result, resultList, code);
                    int colIndex = _searchDic[code];
                    if (result != null)
                    {
                        // 変更データ取得
                        //UpdateRateData(ref saveList, ref deleteList, cells, result, result.UnitPriceKind, colIndex); // DEL donggy 2013/04/19 for Redmine#35355
                        UpdateRateData(ref saveList, ref deleteList, cells, result, result.UnitPriceKind, colIndex, parentDiv, code); // ADD donggy 2013/04/19 for Redmine#35355
                    }
                    else
                    {
                        string colName = "";
                        switch (this._rateMode)
                        {
                            case RateMode.RateVal:
                                {
                                    colName = COLUMN_SALERATE;
                                    break;
                                }
                            case RateMode.UpRate:
                                {
                                    colName = COLUMN_UPRATE;
                                    break;
                                }
                            case RateMode.GrsProfitSecureRat:
                                {
                                    colName = COLUMN_GRSPROFITSECURERAT;
                                    break;
                                }
                        }

                        if (DoubleObjToDouble(cells[colName + colIndex.ToString()].Value) != 0)
                        {
                            MakeNewRateData(out updateRate, cells, parentDiv, code, colIndex);

                            //saveList.Add(updateRate.Clone()); // DEL donggy 2013/04/19 for Redmine#35355
                            // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                            // 売価率、原価UP率と粗利確保率全部が全社拠点のデータを保存しない
                            if (updateRate.RateVal == 0.0
                                && updateRate.UpRate == 0.0
                                && updateRate.GrsProfitSecureRate == 0.0)
                            {
                                continue;
                            }
                            else
                            {
                                saveList.Add(updateRate.Clone());
                            }
                            // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 掛率マスタ作成処理
        /// </summary>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note        : 掛率マスタを新規作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private Rate CreateRate()
        {
            // 固定値のものだけセット
            Rate newRate = new Rate();
            
            newRate.EnterpriseCode = this._enterpriseCode;
            newRate.SectionCode = this._searchSectionCode;
            newRate.LotCount = 9999999.99;
            newRate.UnPrcFracProcUnit = 0;
            newRate.UnPrcFracProcDiv = 0;

            return newRate;
        }

        /// <summary>
        /// クラスメンバコピー処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note        : 掛率マスタ検索結果から掛率マスタを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private Rate CopyToRateFromRateSearchResult(Rate2SearchResult result)
        {
            Rate newRate = new Rate();

            newRate.CreateDateTime = result.CreateDateTime;
            newRate.UpdateDateTime = result.UpdateDateTime;
            newRate.EnterpriseCode = result.EnterpriseCode;
            newRate.FileHeaderGuid = result.FileHeaderGuid;
            newRate.UpdEmployeeCode = result.UpdEmployeeCode;
            newRate.UpdAssemblyId1 = result.UpdAssemblyId1;
            newRate.UpdAssemblyId2 = result.UpdAssemblyId2;
            newRate.LogicalDeleteCode = result.LogicalDeleteCode;
            newRate.SectionCode = result.SectionCode;
            newRate.UnitRateSetDivCd = result.UnitRateSetDivCd;
            newRate.UnitPriceKind = result.UnitPriceKind;
            newRate.RateSettingDivide = result.RateSettingDivide;
            newRate.RateMngGoodsCd = result.RateMngGoodsCd;
            newRate.RateMngGoodsNm = result.RateMngGoodsNm;
            newRate.RateMngCustCd = result.RateMngCustCd;
            newRate.RateMngCustNm = result.RateMngCustNm;
            newRate.GoodsMakerCd = result.GoodsMakerCd;
            newRate.GoodsNo = result.GoodsNo;
            newRate.GoodsRateRank = result.GoodsRateRank;
            newRate.GoodsRateGrpCode = result.GoodsRateGrpCode;
            newRate.BLGroupCode = result.BLGroupCode;
            newRate.BLGoodsCode = result.BLGoodsCode;
            newRate.CustomerCode = result.CustomerCode;
            newRate.CustRateGrpCode = result.CustRateGrpCode;
            newRate.SupplierCd = result.SupplierCd;
            newRate.LotCount = result.LotCount;
            newRate.PriceFl = result.PriceFl;
            newRate.RateVal = result.RateVal;
            newRate.UpRate = result.UpRate;
            newRate.GrsProfitSecureRate = result.GrsProfitSecureRate;
            newRate.UnPrcFracProcUnit = result.UnPrcFracProcUnit;
            newRate.UnPrcFracProcDiv = result.UnPrcFracProcDiv;

            return newRate;
        }
        #endregion データ取得

        #region チェック処理
        /// <summary>
        /// 検索条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索条件をチェックします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            try
            {
                // 拠点
                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == "")
                {
                    errMsg = "拠点を入力してください。";
                    this.tEdit_SectionCodeAllowZero.Focus();

                    this.AdjustButtonEnable(1, true);
                    return (false);
                }

                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    this.AdjustButtonEnable(1, true);
                    return (false);
                }

                // 仕入先
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    errMsg = "仕入先を入力してください。";
                    this.tNedit_SupplierCd.Focus();
                    this.AdjustButtonEnable(1, true);
                    return (false);
                }

                int supplierCode = this.tNedit_SupplierCd.GetInt();
                if (!CheckSupplier(supplierCode))
                {
                    errMsg = "マスタに登録されていません。";
                    this.tNedit_SupplierCd.Focus();
                    this.AdjustButtonEnable(1, true);
                    return (false);
                }

                bool errFlag = false;
                // 範囲指定
                if (this.chkSearchingAll.Checked)
                {

                    int searchSt = StrObjToInt(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Value);
                    int searchEd = StrObjToInt(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE2].Value);
                    string searchStS = StrObjToStr(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Value);
                    string searchEdS = StrObjToStr(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE2].Value);

                    if (string.Empty.Equals(searchStS) && string.Empty.Equals(searchEdS))
                    {
                        // 未指定
                        if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                        {

                        }
                        else
                        {
                            errMsg = "得意先の範囲を指定して下さい。";
                            errFlag = true;
                        }  
                    }
                    else if (searchStS != string.Empty && searchEdS != string.Empty)
                    {
                        // 範囲指定に誤り
                        if (searchSt > searchEd)
                        {
                            if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                            {
                                errMsg = "得意先掛率Gの範囲指定に誤りがあります。";
                            }
                            else
                            {
                                errMsg = "得意先の範囲指定に誤りがあります。";
                            }

                            errFlag = true;
                        }
                        else
                        {
                            // 得意先検索条件取得
                            if (this.chkSearchingAll.Enabled)
                            {
                                GetCustomerSecCondition();
                                if (!_existFlg)
                                {
                                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                                    {
                                        errMsg = "指定された条件で得意先掛率Ｇコードは存在しませんでした。";
                                    }
                                    else
                                    {
                                        errMsg = "指定された条件で得意先コードは存在しませんでした。";
                                    }
                                    errFlag = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    bool flag = true;
                    for(int i = COLINDEX_SALERATE_ST;i <= COLINDEX_SALERATE_ED;i++ )
                    {
                        if(!string.IsNullOrEmpty( this.uGrid_Details.Rows[0].Cells[i].Value.ToString()))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (_customerSearchMode == CustomerSearchMode.Customer && flag)
                    {
                        errMsg = "得意先を入力してください。";

                        errFlag = true;
                    }
                    
                }

                if (errFlag)
                {
                    if (_rateMode == RateMode.RateVal)
                    {
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else if (_rateMode == RateMode.UpRate)
                    {
                        this.uGrid_Details.Rows[0].Cells[COLUMN_UPRATE1].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[0].Cells[COLUMN_GRSPROFITSECURERAT1].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return (false);
                }

            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

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
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 層別場合数値と文字以外は、ＮＧ
            if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GOODSRATERANK && Char.IsLetter(key))
            {
                // なし
            }
            // 数値以外は、ＮＧ
            else if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
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
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:処理続行　False:処理中断)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return (true);
            }
           
            uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            // 画面情報比較
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            int status = SaveProc(false);
                            if (status != 0)
                            {
                                return (false);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            DataTable dt = (DataTable)this.uGrid_Details.DataSource;
            if (dt.Rows.Count != tempTable.Rows.Count)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row[COLUMN_PARENTDIV].ToString() == "-1")
                    {
                        for (int index = COLINDEX_SALERATE_ST -1; index <= COLINDEX_SALERATE_ED; index++)
                        {
                            if (!string.IsNullOrEmpty(row[index].ToString()))
                            {
                                return (false);
                            }
                        }
                    }
                }
            }
            if (dt != null && dt.Rows.Count > 2)
            {
                for (int i = 2; i < tempTable.Rows.Count; i++)
                {
                    object[] tempArr = tempTable.Rows[i].ItemArray;
                    object[] dtArr = dt.Rows[i].ItemArray;
                    for (int j = 0; j < tempArr.Length; j++)
                    {
                        if (j >= 9 && j < 310 && !string.IsNullOrEmpty(dtArr[j].ToString()))
                        {
                            if (!tempArr[j].Equals(string.Format("{0:0.00}", DoubleObjToDouble(dtArr[j]))))
                                return (false);
                        }
                        else
                        {
                            if (j == 311) continue; // 311列は展開フラグ列です
                            if (!tempArr[j].Equals(dtArr[j]))
                                return (false);
                        }
                    }
                }
            }

            return (true);
        }

        #endregion チェック処理

        #region グリッド設定
        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの列を作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            DataTable dataTable = new DataTable();

            // No
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // 商掛Ｇ
            dataTable.Columns.Add(COLUMN_GOODSRATEGRPCODE, typeof(string));
            // 層別
            dataTable.Columns.Add(COLUMN_GOODSRATERANK, typeof(string));
            // GLCD
            dataTable.Columns.Add(COLUMN_GLCD, typeof(string));
            // BLCD
            dataTable.Columns.Add(COLUMN_BLCD, typeof(string));
            // 名称
            dataTable.Columns.Add(COLUMN_NAME, typeof(string));
            // メーカーコード
            dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
            // メーカー名
            dataTable.Columns.Add(COLUMN_MAKERNAME, typeof(string));
            // 仕入先
            dataTable.Columns.Add(COLUMN_SUPPLIERCODE, typeof(string));
            // 仕入率
            dataTable.Columns.Add(COLUMN_COSTRATE, typeof(string));
            // 売価率
            dataTable.Columns.Add(COLUMN_SALERATE1, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE2, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE3, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE4, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE5, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE6, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE7, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE8, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE9, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE10, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE11, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE12, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE13, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE14, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE15, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE16, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE17, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE18, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE19, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE20, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE21, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE22, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE23, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE24, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE25, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE26, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE27, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE28, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE29, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE30, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE31, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE32, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE33, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE34, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE35, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE36, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE37, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE38, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE39, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE40, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE41, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE42, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE43, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE44, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE45, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE46, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE47, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE48, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE49, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE50, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE51, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE52, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE53, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE54, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE55, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE56, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE57, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE58, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE59, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE60, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE61, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE62, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE63, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE64, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE65, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE66, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE67, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE68, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE69, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE70, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE71, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE72, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE73, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE74, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE75, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE76, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE77, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE78, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE79, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE80, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE81, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE82, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE83, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE84, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE85, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE86, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE87, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE88, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE89, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE90, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE91, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE92, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE93, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE94, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE95, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE96, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE97, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE98, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE99, typeof(string));
            dataTable.Columns.Add(COLUMN_SALERATE100, typeof(string));

            // 原価UP率
            dataTable.Columns.Add(COLUMN_UPRATE1, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE2, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE3, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE4, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE5, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE6, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE7, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE8, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE9, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE10, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE11, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE12, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE13, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE14, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE15, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE16, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE17, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE18, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE19, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE20, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE21, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE22, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE23, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE24, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE25, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE26, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE27, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE28, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE29, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE30, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE31, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE32, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE33, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE34, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE35, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE36, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE37, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE38, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE39, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE40, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE41, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE42, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE43, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE44, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE45, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE46, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE47, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE48, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE49, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE50, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE51, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE52, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE53, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE54, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE55, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE56, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE57, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE58, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE59, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE60, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE61, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE62, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE63, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE64, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE65, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE66, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE67, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE68, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE69, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE70, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE71, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE72, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE73, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE74, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE75, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE76, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE77, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE78, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE79, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE80, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE81, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE82, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE83, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE84, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE85, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE86, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE87, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE88, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE89, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE90, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE91, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE92, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE93, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE94, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE95, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE96, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE97, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE98, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE99, typeof(string));
            dataTable.Columns.Add(COLUMN_UPRATE100, typeof(string));

            // 粗利確保率
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT1, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT2, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT3, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT4, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT5, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT6, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT7, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT8, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT9, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT10, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT11, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT12, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT13, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT14, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT15, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT16, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT17, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT18, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT19, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT20, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT21, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT22, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT23, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT24, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT25, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT26, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT27, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT28, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT29, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT30, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT31, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT32, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT33, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT34, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT35, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT36, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT37, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT38, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT39, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT40, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT41, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT42, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT43, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT44, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT45, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT46, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT47, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT48, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT49, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT50, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT51, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT52, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT53, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT54, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT55, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT56, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT57, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT58, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT59, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT60, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT61, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT62, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT63, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT64, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT65, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT66, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT67, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT68, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT69, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT70, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT71, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT72, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT73, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT74, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT75, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT76, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT77, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT78, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT79, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT80, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT81, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT82, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT83, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT84, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT85, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT86, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT87, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT88, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT89, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT90, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT91, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT92, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT93, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT94, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT95, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT96, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT97, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT98, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT99, typeof(string));
            dataTable.Columns.Add(COLUMN_GRSPROFITSECURERAT100, typeof(string));

            // 親子区分
            dataTable.Columns.Add(COLUMN_PARENTDIV, typeof(int));
            // 展開フラグ
            dataTable.Columns.Add(COLUMN_EXPANDFLG, typeof(bool));
            // 商品掛率グループコード(内部保持用)
            dataTable.Columns.Add(COLUMN_GOODSRATEGRPCODE_HIDE, typeof(string));
            // 操作フラグ
            dataTable.Columns.Add(COLUMN_ENABLEFLG, typeof(string));

            uGrid.DataSource = dataTable;

            // グリッドスタイル設定
            SetGridLayout(ref uGrid);

            // グリッドに検索条件作成処理
            CreatSearchCondtion(ref uGrid);
        }

        /// <summary>
        /// グリッドに検索条件作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドに検索条件作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br> 
        /// </remarks>
        public void CreatSearchCondtion(ref UltraGrid uGrid)
        {

            uGrid.BeginUpdate();

            // 行追加
            uGrid.DisplayLayout.Bands[0].AddNew();

            CellsCollection cells = uGrid.Rows[0].Cells;
            for (int index = 1; index < 10; index++)
            {
                cells[index].Appearance.BackColorDisabled = Color.Gainsboro;
                cells[index].Appearance.ForeColorDisabled = Color.Black;

                cells[index].Activation = Activation.Disabled;
            }
            //uGrid.DisplayLayout.Rows[0].Fixed = true;

            uGrid.DisplayLayout.Bands[0].AddNew();
            cells = uGrid.Rows[1].Cells;
            for (int index = 1; index < cells.Count; index++)
            {
                if(this._displayList.Count < 1 && index >= 10)
                {
                    cells[index].Activation = Activation.NoEdit;
                }
                else
                {
                    cells[index].Appearance.BackColorDisabled = Color.Gainsboro;
                    cells[index].Appearance.ForeColorDisabled = Color.Black;

                    cells[index].Activation = Activation.Disabled;
                }
            }
            //uGrid.DisplayLayout.Rows[1].Fixed = true;

            uGrid_Details.DisplayLayout.Rows.FixedRows.Add(uGrid_Details.DisplayLayout.Rows[0]);
            uGrid_Details.DisplayLayout.Rows.FixedRows.Add(uGrid_Details.DisplayLayout.Rows[1]);
            this.uGrid_Details.UpdateData();
            uGrid.EndUpdate();
        }

        /// <summary>
        /// 得意先掛率グループが"指定なし"のデータであるか判断します。
        /// </summary>
        /// <param name="rateSearchResult">検索したデータ</param>
        /// <returns>
        /// <c>true</c> :得意先掛率グループが"指定なし"のデータです。<br/>
        /// <c>false</c>:得意先掛率グループが"指定なし"のデータではありません。
        /// </returns>
        /// <remarks>
        /// <br>Note        : 得意先掛率グループが"指定なし"のデータであるか判断します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>  
        /// </remarks>
        private bool IsAllCustRateGrpCode(Rate2SearchResult rateSearchResult)
        {
            string unitRateSetDivCd = rateSearchResult.UnitRateSetDivCd.Trim();
            if (this._goodsMode == GoodsMode.GoodsRateG)
            {
                return unitRateSetDivCd.Equals("15F") || unitRateSetDivCd.Equals("15D") || unitRateSetDivCd.Equals("15E");
            }
            else
            {
                return unitRateSetDivCd.Equals("15G") || unitRateSetDivCd.Equals("15B") || unitRateSetDivCd.Equals("15C");
            }
            
        }

        /// <summary>
        /// 対象とする得意先掛率グループコードに存在するか判断します。
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 対象とする得意先掛率グループコードに存在するか判断します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>   
        /// </remarks>
        private bool ExistsCustRateGrpCodeInTargetDic(int custRateGrpCode)
        {
            foreach (int custRateGrpCodeKey in this._extrInfo.CustRateGrpCode)
            {
                if (custRateGrpCodeKey.Equals(custRateGrpCode))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// グリッドスタイル設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドのスタイルを設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void SetGridLayout(ref UltraGrid uGrid)
        {
            try
            {
                uGrid.BeginUpdate();
                uGrid.DisplayLayout.Bands[0].Groups.Clear();
                uGrid.DisplayLayout.Bands[0].ColHeadersVisible = false;

                ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

                Infragistics.Win.UltraWinGrid.UltraGridGroup ugg = null;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_NO, "No.");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_NO]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_NO].Header.Fixed = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_GOODSRATEGRPCODE, "商掛G");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Header.Fixed = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_GOODSRATERANK, "層別");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Header.Fixed = true;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_GLCD, "GRCD");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_GLCD]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_GLCD].Header.Fixed = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_BLCD, "BLCD");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_BLCD]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_BLCD].Header.Fixed = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_NAME, "名称");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_NAME]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_NAME].Header.Fixed = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_MAKERCODE, "ﾒｰｶｰ");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MAKERCODE]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_MAKERCODE].Header.Fixed = true;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_MAKERCODE].Hidden = false;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_MAKERNAME, "ﾒｰｶｰ名");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MAKERNAME]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_MAKERNAME].Header.Fixed = true;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_MAKERNAME].Hidden = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_SUPPLIERCODE, "仕入先");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SUPPLIERCODE]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_SUPPLIERCODE].Hidden = true;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_SUPPLIERCODE].Header.Fixed = true;
                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add(COLUMN_COSTRATE, "仕入率");
                ugg.Columns.Add(uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COSTRATE]);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_COSTRATE].Header.Fixed = true;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_COSTRATE].Header.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_COSTRATE].Header.Appearance.BackColor2 = Color.FromArgb(192, 64, 0);
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_COSTRATE].Header.Appearance.BackGradientStyle = GradientStyle.Vertical;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_COSTRATE].Header.Appearance.ForeColor = Color.White;
                uGrid.DisplayLayout.Bands[0].Groups[COLUMN_COSTRATE].Header.Appearance.ForeColorDisabled = Color.White;

                ugg = uGrid.DisplayLayout.Bands[0].Groups.Add("SaleRate1", "");
                for (int index = 10; index < columns.Count; index++)
                {
                    ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[index]);
                }
                uGrid.DisplayLayout.Bands[0].Groups["SaleRate1"].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
                // セルスタイル
                for (int index = 0; index < columns.Count; index++)
                {
                    columns[index].CellAppearance.BackColorDisabled = Color.White;
                    columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                }

                // No
                columns[COLUMN_NO].Header.Caption = "No.";
                columns[COLUMN_NO].Header.Fixed = true;
                columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
                columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
                columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
                columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_NO].CellClickAction = CellClickAction.RowSelect;
                columns[COLUMN_NO].CellActivation = Activation.Disabled;
                

                // 商掛Ｇ
                columns[COLUMN_GOODSRATEGRPCODE].Header.Caption = "商掛G";
                columns[COLUMN_GOODSRATEGRPCODE].Header.Fixed = true;
                columns[COLUMN_GOODSRATEGRPCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_GOODSRATEGRPCODE].CellActivation = Activation.AllowEdit;
                // セル結合
                SettingMergedCell(columns[COLUMN_GOODSRATEGRPCODE]);

                // 層別
                columns[COLUMN_GOODSRATERANK].Header.Caption = "層別";
                columns[COLUMN_GOODSRATERANK].Header.Fixed = true;
                columns[COLUMN_GOODSRATERANK].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_GOODSRATERANK].CellActivation = Activation.AllowEdit;
                columns[COLUMN_GOODSRATERANK].Hidden = true;
                // セル結合
                SettingMergedCell(columns[COLUMN_GOODSRATERANK]);

                // GLCD
                columns[COLUMN_GLCD].Header.Caption = "GRCD";
                columns[COLUMN_GLCD].Header.Fixed = true;
                columns[COLUMN_GLCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_GLCD].CellActivation = Activation.AllowEdit;
                // セル結合
                SettingMergedCell(columns[COLUMN_GLCD]);

                // BLCD
                columns[COLUMN_BLCD].Header.Caption = "BLCD";
                columns[COLUMN_BLCD].Header.Fixed = true;
                columns[COLUMN_BLCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLCD].CellActivation = Activation.AllowEdit;

                // 名称
                columns[COLUMN_NAME].Header.Caption = "名称";
                columns[COLUMN_NAME].Header.Fixed = true;
                columns[COLUMN_NAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_NAME].CellActivation = Activation.NoEdit;

                // メーカーコード
                columns[COLUMN_MAKERCODE].Header.Caption = "ﾒｰｶｰ";
                columns[COLUMN_MAKERCODE].Header.Fixed = true;
                columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_MAKERCODE].CellActivation = Activation.AllowEdit;
                columns[COLUMN_MAKERCODE].Hidden = false;

                // メーカー名
                columns[COLUMN_MAKERNAME].Header.Caption = "ﾒｰｶｰ名";
                columns[COLUMN_MAKERNAME].Header.Fixed = true;
                columns[COLUMN_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_MAKERNAME].CellActivation = Activation.NoEdit;
                columns[COLUMN_MAKERNAME].Hidden = true;

                // 仕入先
                columns[COLUMN_SUPPLIERCODE].Header.Caption = "仕入先";
                columns[COLUMN_SUPPLIERCODE].Header.Fixed = true;
                columns[COLUMN_SUPPLIERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_SUPPLIERCODE].CellActivation = Activation.NoEdit;
                columns[COLUMN_SUPPLIERCODE].Hidden = true;

                // 仕入率
                columns[COLUMN_COSTRATE].Header.Caption = "仕入率";
                columns[COLUMN_COSTRATE].Header.Fixed = true;
                columns[COLUMN_COSTRATE].Format = FORMAT;
                columns[COLUMN_COSTRATE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_COSTRATE].CellActivation = Activation.AllowEdit;

                // 売価率
                if ((this._displayList == null) || (this._displayList.Count == 0))
                {
                    for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                    {
                        columns[index].CellAppearance.TextHAlign = HAlign.Right;
                        columns[index].CellActivation = Activation.AllowEdit;
                    }
                }

                // 親子区分
                columns[COLUMN_PARENTDIV].Header.Caption = "";
                columns[COLUMN_PARENTDIV].Hidden = true;

                // 展開フラグ
                columns[COLUMN_EXPANDFLG].Header.Caption = "";
                columns[COLUMN_EXPANDFLG].Hidden = true;

                // 商品掛率グループコード(内部保持用)
                columns[COLUMN_GOODSRATEGRPCODE_HIDE].Header.Caption = "";
                columns[COLUMN_GOODSRATEGRPCODE_HIDE].Hidden = true;

                // 操作フラグ
                columns[COLUMN_ENABLEFLG].Header.Caption = "";
                columns[COLUMN_ENABLEFLG].Hidden = true;

                // グリッド列幅設定
                SetColumnWidth(ref uGrid);
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// グリッド列幅設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの列幅を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void SetColumnWidth(ref UltraGrid uGrid)
        {
            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            // No
            columns[COLUMN_NO].Width = 45;
            // 商掛Ｇ
            columns[COLUMN_GOODSRATEGRPCODE].Width = 50;
            // 層別
            columns[COLUMN_GOODSRATERANK].Width = 50;
            // GLCD
            columns[COLUMN_GLCD].Width = 50;
            // BLCD
            columns[COLUMN_BLCD].Width = 50;
            // 名称
            columns[COLUMN_NAME].Width = 165;
            // メーカーコード
            columns[COLUMN_MAKERCODE].Width = 50;
            // メーカー名
            columns[COLUMN_MAKERNAME].Width = 165;
            // 仕入先
            columns[COLUMN_SUPPLIERCODE].Width = 70;
            // 仕入率
            columns[COLUMN_COSTRATE].Width = 103;
            // 売価率
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                {
                    columns[index].Width = 90;
                }
            }
        }

        /// <summary>
        /// グリッド行カラー設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの行カラーを設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public void SetRowColor(ref UltraGrid uGrid)
        {
            Color parentColor = Color.White;
            Color sonColor = Color.White;

            for (int rowIndex = 2; rowIndex < uGrid.Rows.Count; rowIndex++)
            {
                CellsCollection cells = uGrid.Rows[rowIndex].Cells;

                // 親子区分
                int parentDiv = IntObjToInt(cells[COLUMN_PARENTDIV].Value);

                if (parentDiv == 0)
                {
                    // 子親Key作成
                    string grKey = MakeParentKey(cells);

                    //子親が存在するかどうかチェック
                    List<Rate2SearchResult> parentGRList = this._parentGRList.FindAll(delegate(Rate2SearchResult target)
                    {
                        if (grKey == MakeParentKey(target))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    bool existFlg = false;

                    if ((parentGRList == null) || (parentGRList.Count == 0))
                    {
                        existFlg = false;
                    }
                    else
                    {
                        foreach (Rate2SearchResult result in parentGRList)
                        {
                            if (result.RateVal != 0 || result.UpRate != 0 || result.GrsProfitSecureRate != 0)
                            {
                                existFlg = true;
                                break;
                            }
                        }
                    }
                    if (!existFlg)
                    {
                        // Key作成
                        string key = MakeParentKey(cells);

                        // 子が存在するかどうかチェック
                        List<Rate2SearchResult> childList = this._childList.FindAll(delegate(Rate2SearchResult target)
                        {
                            if (key == MakeParentKey(target))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });

                        if ((childList == null) || (childList.Count == 0))
                        {
                            existFlg = false;
                        }
                        else
                        {
                            foreach (Rate2SearchResult result in childList)
                            {
                                if (result.RateVal != 0 || result.UpRate != 0 || result.GrsProfitSecureRate != 0)
                                {
                                    existFlg = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (existFlg)
                    {
                        // 子や子親明細に率が存在する場合
                        parentColor = Color.Pink;
                    }
                    else
                    {
                        // 子と子親明細に率が存在しない場合
                        parentColor = Color.White;
                    }
                }
                else
                {
                    sonColor = Color.Lavender;
                }

                int index = this._goodsMode == GoodsMode.GoodsRateG ? 1 : 2;
                cells[index].Appearance.BackColor = parentColor;
                cells[index].Appearance.BackColor2 = parentColor;
                Color cellColor = parentDiv == 0 ? parentColor : sonColor;
                for (int colIndex = index + 1; colIndex < cells.Count; colIndex++)
                {
                    cells[colIndex].Appearance.BackColor = cellColor;
                    cells[colIndex].Appearance.BackColor2 = cellColor;
                }
            }
        }

        /// <summary>
        /// グリッド列enable制御設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの列enable制御を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br> 
        /// </remarks>
        public void SetColumnEnable(ref UltraGrid uGrid)
        {
            // 検索条件の設定
            for (int index = 1; index <= COLINDEX_SALERATE_ED; index++)
            {
                uGrid_Details.Rows[0].Cells[index].Appearance.BackColorDisabled = Color.Gainsboro;
                uGrid_Details.Rows[0].Cells[index].Appearance.ForeColorDisabled = Color.Black;

                uGrid_Details.Rows[0].Cells[index].Activation = Activation.Disabled;

                uGrid_Details.Rows[1].Cells[index].Appearance.BackColorDisabled = Color.Gainsboro;
                uGrid_Details.Rows[1].Cells[index].Appearance.ForeColorDisabled = Color.Black;

                uGrid_Details.Rows[1].Cells[index].Activation = Activation.Disabled;
            }
            //uGrid_Details.DisplayLayout.Rows[1].Fixed = true;
            //uGrid_Details.DisplayLayout.Rows.FixedRows.Add(uGrid_Details.DisplayLayout.Rows[0]);
            //uGrid_Details.DisplayLayout.Rows.FixedRows.Add(uGrid_Details.DisplayLayout.Rows[1]);

            #region 掛率優先管理マスタに対象の区分より、入力不可能設定
            
            string message=string.Empty;
            //単価種類
            int unitPriceKind=0;
            //掛率設定区分
            string rateSettingDivide =string.Empty;
            // 掛率優先管理テブール
            DataTable rateProtyMngDataTable;
            //同じ拠点のデータ行
            DataRow[] sameSectionCodeRows = null;
            // 掛率優先管理テブール取得
            GetRateSettingMasterData(out rateProtyMngDataTable);
            Dictionary<string, List<object>> rateSettingsDic;
            foreach (UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                if (gridRow.Index > 1)
                {
                    
                    // 掛率設定区分を取得する
                    GetRateSetting(out rateSettingsDic, gridRow, rateProtyMngDataTable);
                    List<object> compareDataList;
                    foreach (UltraGridCell cell in gridRow.Cells)
                    {
                        // 毎セルの掛率設定区分比較データ取得
                        GetRateSettingComData(out compareDataList, cell, rateSettingsDic);
                        // 仕入率と掛率以外の列を設定しない
                        if (compareDataList.Count < 1)
                        {
                            continue;
                        }
                        // 画面によって、単価種類と掛率設定区分設定
                        unitPriceKind = StrObjToInt(compareDataList[0].ToString());
                        rateSettingDivide = compareDataList[1].ToString();
                        // 同じ拠点のデータ取得
                        sameSectionCodeRows = (DataRow[])compareDataList[2];
                        
                        //セル制御
                        if (unitPriceKind > 0 
                            && ((sameSectionCodeRows != null 
                                && sameSectionCodeRows.Length < 1)
                                || sameSectionCodeRows == null))
                        {
                            cell.Activation = Activation.Disabled;
                            cell.Appearance.BackColorDisabled = Color.Gainsboro;
                            cell.Appearance.ForeColorDisabled = Color.Black;
                            if (cell.Appearance.ForeColor == Color.Red)
                            {
                                cell.Appearance.ForeColorDisabled = Color.Red;
                            }
                        }
                       
                    } 
                }
            }
            #endregion 掛率優先管理マスタに対象の区分より、入力不可能設定

        }

        /// <summary>
        /// グリッド列Hidden制御設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドの列Hidden制御を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br> 
        /// </remarks>
        public void SetColumnHidden()
        {
            // 得意先切替
            switch (this._customerSearchMode)
            {
                case CustomerSearchMode.CustomerRateG:
                    {
                        // 明細列
                        this.uLabel_CustomerMode.Text = "得意先掛率Ｇ";
                        break;
                    }
                case CustomerSearchMode.Customer:
                    {
                        // 明細列
                        this.uLabel_CustomerMode.Text = "得意先";
                        break;
                    }
            }

            // 商品切替
            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 明細列
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = true;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK].Hidden = true;
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden = false;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE].Hidden = false;
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 明細列
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = false;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK].Hidden = false;
                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                        break;
                    }
            }

            //掛率切替
            switch (this._rateMode)
            {
                case RateMode.RateVal:
                    {
                        for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                        {
                            if (index < 110)
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = false;
                            }
                            else
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = true;
                            }

                            if (!this.chkSearchingAll.Enabled)
                            {
                                if (string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[index].Value.ToString()))
                                {
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = true;
                                }
                            }
                        }

                        break;
                    }
                case RateMode.UpRate:
                    {
                        for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                        {
                            if (index >= 110 && index < 210)
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = false;
                            }
                            else
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = true;
                            }

                            if (!this.chkSearchingAll.Enabled)
                            {
                                if (string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[index].Value.ToString()))
                                {
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = true;
                                }
                            }
                        }
                        break;
                    }
                case RateMode.GrsProfitSecureRat:
                    {
                        for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                        {
                            if (index >= 210)
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = false;
                            }
                            else
                            {
                                this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = true;
                            }

                            if (!this.chkSearchingAll.Enabled)
                            {
                                if (string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[index].Value.ToString()))
                                {
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden = true;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// セル結合設定処理
        /// </summary>
        /// <param name="column">グリッド列</param>
        /// <remarks>
        /// <br>Note        : セル結合処理を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>  
        /// </remarks>
        private void SettingMergedCell(Infragistics.Win.UltraWinGrid.UltraGridColumn column)
        {
            //--------------------------------------------------
            // CellAppearanceを強制的に統一する
            //--------------------------------------------------
            column.CellAppearance.TextVAlign = VAlign.Top;

            //--------------------------------------------------
            // セル結合設定
            //--------------------------------------------------
            column.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            column.MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText;
            column.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;

            // セル結合判定クラス
            CustomMergedCellEvaluator customMergedCellEvaluator = new CustomMergedCellEvaluator();

            if (column.Key == COLUMN_GOODSRATEGRPCODE)
            {
                // 商品掛率Ｇ
                customMergedCellEvaluator.JoinColList.Add(COLUMN_GOODSRATEGRPCODE);
            }
            else if (column.Key == COLUMN_GOODSRATERANK)
            {
                // 層別
                customMergedCellEvaluator.JoinColList.Add(COLUMN_GOODSRATERANK);
            }
            else
            {
                if (this._goodsMode == GoodsMode.GoodsRateG)
                {
                    // 商品掛率Ｇ
                    customMergedCellEvaluator.JoinColList.Add(COLUMN_GOODSRATEGRPCODE);
                    // GLCD
                    customMergedCellEvaluator.JoinColList.Add(COLUMN_GLCD);
                }
                else
                {
                    // 層別
                    customMergedCellEvaluator.JoinColList.Add(COLUMN_GOODSRATERANK);
                    // GLCD
                    customMergedCellEvaluator.JoinColList.Add(COLUMN_GLCD);
                }

            }
            column.MergedCellEvaluator = customMergedCellEvaluator;

        }
        #endregion グリッド設定

        #region セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Int型</returns>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public int IntObjToInt(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
                {
                    return 0;
                }
                else
                {
                    return (int)cellValue;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>String型</returns>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == "") || cellValue.ToString() == ALL_CUST_RATE_GRP)
                {
                    return 0;
                }
                else
                {
                    return int.Parse((string)cellValue);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>String型</returns>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public string StrObjToStr(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
                {
                    return string.Empty;
                }
                else
                {
                    return cellValue.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Double型</returns>
        /// <remarks>
        /// <br>Note        : セル値をDouble型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public double DoubleObjToDouble(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == "") || cellValue.ToString() == ".")
                {
                    return 0;
                }
                else
                {
                    return double.Parse(cellValue.ToString());
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Bool型</returns>
        /// <remarks>
        /// <br>Note        : セル値をBool型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        public bool BoolObjToBool(object cellValue)
        {
            try
            {
                if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
                {
                    return (false);
                }
                else
                {
                    return (bool)cellValue;
                }
            }
            catch
            {
                return (false);
            }
        }
        #endregion セル値変換

        #region Key作成
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string MakeParentKey(Rate2SearchResult result)
        {
            string key = string.Empty;

            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 商品中分類コード＋部品メーカーコード＋仕入先コード
                        key = result.PrmGoodsMGroup.ToString("0000") +
                                 result.PrmPartsMakerCd.ToString("0000") +
                                 result.GoodsSupplierCd.ToString("000000");
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 層別＋部品メーカーコード＋仕入先コード
                        key = result.GoodsRateRank.Trim() +
                                 result.PrmPartsMakerCd.ToString("0000") +
                                 result.GoodsSupplierCd.ToString("000000");
                        break;
                    }
            }


            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="cells">GridのCells</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string MakeParentKey(CellsCollection cells)
        {
            string key = string.Empty;
            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 商品中分類コード＋部品メーカーコード＋仕入先コード
                        key = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value).ToString("0000") +
                                    StrObjToInt(cells[COLUMN_MAKERCODE].Value).ToString("0000") +
                                    StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value).ToString("000000");
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 層別＋部品メーカーコード＋仕入先コード
                        key = cells[COLUMN_GOODSRATERANK].Value +
                                    StrObjToInt(cells[COLUMN_MAKERCODE].Value).ToString("0000") +
                                    StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value).ToString("000000");
                        break;
                    }
            }

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string MakeParentGRKey(Rate2SearchResult result)
        {
            string key = string.Empty;

            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 商品中分類コード＋部品メーカーコード＋仕入先コード
                        key = result.PrmGoodsMGroup.ToString("0000") +
                                 result.BGBLGroupCode.ToString("00000") +
                                 result.PrmPartsMakerCd.ToString("0000") +
                                 result.GoodsSupplierCd.ToString("000000");
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 層別＋部品メーカーコード＋仕入先コード
                        key = result.GoodsRateRank.Trim() +
                                 result.BGBLGroupCode.ToString("00000") +
                                 result.PrmPartsMakerCd.ToString("0000") +
                                 result.GoodsSupplierCd.ToString("000000");
                        break;
                    }
            }

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        ///<param name="cells">GridのCells</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string MakeParentGRKey(CellsCollection cells)
        {
            string key = string.Empty;

            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 商品中分類コード＋GLCD+ 部品メーカーコード＋仕入先コード
                        key = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value).ToString("0000") +
                            StrObjToInt(cells[COLUMN_GLCD].Value).ToString("00000") +
                            StrObjToInt(cells[COLUMN_MAKERCODE].Value).ToString("0000") +
                            StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value).ToString("000000");
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 層別＋GLCD+ 部品メーカーコード＋仕入先コード
                        key = cells[COLUMN_GOODSRATERANK].Value.ToString().Trim() +
                            StrObjToInt(cells[COLUMN_GLCD].Value).ToString("00000") +
                            StrObjToInt(cells[COLUMN_MAKERCODE].Value).ToString("0000") +
                            StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value).ToString("000000");
                        break;
                    }
            }

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string MakeChildKey(Rate2SearchResult result)
        {
            string key = string.Empty;

            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 商品中分類コード＋BLコード＋部品メーカーコード＋仕入先コード
                        key = result.PrmGoodsMGroup.ToString("0000") +
                                 result.BGBLGroupCode.ToString("00000") +
                                 result.PrmTbsPartsCode.ToString("00000") +
                                 result.PrmPartsMakerCd.ToString("0000") +
                                 result.GoodsSupplierCd.ToString("000000");
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 層別＋BLコード＋部品メーカーコード＋仕入先コード
                        key = result.GoodsRateRank.Trim() +
                                 result.BGBLGroupCode.ToString("00000") +
                                 result.PrmTbsPartsCode.ToString("00000") +
                                 result.PrmPartsMakerCd.ToString("0000") +
                                 result.GoodsSupplierCd.ToString("000000");
                        break;
                    }
            }

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="cells">GridのCells</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private string MakeChildKey(CellsCollection cells)
        {
            string key = string.Empty;

            switch (this._goodsMode)
            {
                case GoodsMode.GoodsRateG:
                    {
                        // 商品中分類コード＋GLCD + BLCD +部品メーカーコード＋仕入先コード
                        key = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value).ToString("0000") +
                                StrObjToInt(cells[COLUMN_GLCD].Value).ToString("00000") +
                                StrObjToInt(cells[COLUMN_BLCD].Value).ToString("00000") +
                                StrObjToInt(cells[COLUMN_MAKERCODE].Value).ToString("0000") +
                                StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value).ToString("000000");
                        break;
                    }
                case GoodsMode.GoodsRateRank:
                    {
                        // 層別＋GLCD + BLCD +部品メーカーコード＋仕入先コード
                        key = cells[COLUMN_GOODSRATERANK].Value +
                                StrObjToInt(cells[COLUMN_GLCD].Value).ToString("00000") +
                                StrObjToInt(cells[COLUMN_BLCD].Value).ToString("00000") +
                                StrObjToInt(cells[COLUMN_MAKERCODE].Value).ToString("0000") +
                                StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value).ToString("000000");
                        break;
                    }

            }

            return key;
        }
        #endregion Key作成

        #region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._rateUpdateAcs,	    // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        ///<summary>
        /// 掛率設定区分の設定
        /// </summary>
        /// <param name="row">画面の明細行</param>
        /// <param name="cell">rowの一つセル</param>
        /// <param name="unitPriceKind">単価種類　１：売価設定　２:原価設定</param>
        /// <param name="rateSettingDiv">掛率設定区分</param>
        /// <remarks>
        /// <br>Note       : 掛率設定区分を設定します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br> 
        /// </remarks>
        private void SetRateSettingDiv(UltraGridRow row,UltraGridCell cell,out int unitPriceKind,out string rateSettingDiv)
        {
            int blcd = StrObjToInt(row.Cells[COLUMN_BLCD].Value);//ＢＬコード
            int glcd = StrObjToInt(row.Cells[COLUMN_GLCD].Value);//グループコード
            int ggcd = StrObjToInt(row.Cells[COLUMN_GOODSRATEGRPCODE].Value);//商掛Ｇグループコード
            unitPriceKind = 0;//単価種類
            rateSettingDiv = string.Empty;//掛率設定区分
            #region 掛率設定パターン
            // 得意先掛率Ｇ		  商品掛率Ｇ      仕入先＋メーカー						３Ｆ	
            // 得意先掛率Ｇ        層別			  仕入先＋メーカー＋ＢＬＣＤ			３Ｂ	
            // 得意先掛率Ｇ        層別            仕入先＋メーカー＋ＧＬＣＤ			３Ｃ	
            // 得意先掛率Ｇ        層別            仕入先＋メーカー						３Ｇ	
            // 得意先掛率Ｇ        指定なし		  仕入先＋メーカー＋ＢＬＣＤ			３Ｄ	
            // 得意先掛率Ｇ        指定なし        仕入先＋メーカー＋ＧＬＣＤ			３Ｅ	
            // 得意先		      商品掛率Ｇ	  仕入先＋メーカー						１Ｆ	
            // 得意先              層別			  仕入先＋メーカー＋ＢＬＣＤ			１Ｂ	
            // 得意先              層別            仕入先＋メーカー＋ＧＬＣＤ			１Ｃ	
            // 得意先              層別            仕入先＋メーカー						１Ｇ	
            // 得意先              指定なし		  仕入先＋メーカー＋ＢＬＣＤ			１Ｄ	
            // 得意先              指定なし        仕入先＋メーカー＋ＧＬＣＤ			１Ｅ	
            // 指定なし			  商品掛率Ｇ      仕入先＋メーカー						５Ｆ	
            // 指定なし            層別			  仕入先＋メーカー＋ＢＬＣＤ			５Ｂ	
            // 指定なし            層別	          仕入先＋メーカー＋ＧＬＣＤ			５Ｃ	
            // 指定なし            層別            仕入先＋メーカー						５Ｇ	
            // 指定なし            指定なし		  仕入先＋メーカー＋ＢＬＣＤ			５Ｄ	
            // 指定なし            指定なし        仕入先＋メーカー＋ＧＬＣＤ			５Ｅ
            #endregion	

            // 仕入率・得意先掛率Ｇ入力なし
            if (cell.Column.Key == COLUMN_COSTRATE
                || (cell.Column.Key==COLUMN_SALERATE1&&this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Value.ToString() == "ALL")
                || (cell.Column.Key == COLUMN_UPRATE1 && this.uGrid_Details.Rows[0].Cells[COLUMN_UPRATE1].Value.ToString() == "ALL")
                || (cell.Column.Key == COLUMN_GRSPROFITSECURERAT1 && this.uGrid_Details.Rows[0].Cells[COLUMN_GRSPROFITSECURERAT1].Value.ToString() == "ALL"))
            {
                // 商品掛率Ｇの場合
                if (this._goodsMode == GoodsMode.GoodsRateG)
                {
                    if (blcd == 0 && glcd == 0 && ggcd == 0)
                    {
                        rateSettingDiv = "";
                    }
                    else if (blcd == 0 && glcd == 0)
                    {
                        rateSettingDiv = "5F";
                    }
                    else if (blcd != 0)
                    {
                        rateSettingDiv = "5D";
                    }
                    else if (glcd != 0)
                    {
                        rateSettingDiv = "5E";
                    }
                }
                // 層別の場合
                else 
                {
                    if (blcd == 0 && glcd == 0)
                    {
                        rateSettingDiv = "5G";
                    }
                    else if (blcd != 0)
                    {
                        rateSettingDiv = "5B";
                    }
                    else if (glcd != 0)
                    {
                        rateSettingDiv = "5C";
                    }
                }
                // 仕入率の単価種類は原価設定に取得する
                if (cell.Column.Key == COLUMN_COSTRATE)
                {
                    unitPriceKind = 2;
                }
                // 売価率・原価UP率・粗利確保率の単価種類は売価設定に取得する
                else
                {
                    unitPriceKind = 1;
                }
            }
            // 売価率・原価UP率・粗利確保率
            else if (cell.Column.Key.Contains(COLUMN_SALERATE)
                     || cell.Column.Key.Contains(COLUMN_UPRATE)
                     || cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT))
            {
                switch (this.uLabel_CustomerMode.Text)
                {
                    case "得意先掛率Ｇ":
                        {
                            // 商品掛率Ｇの場合
                            if (this._goodsMode == GoodsMode.GoodsRateG)
                            {
                                if (blcd == 0 && glcd == 0 && ggcd == 0)
                                {
                                    rateSettingDiv = "";
                                }
                                else if (blcd == 0 && glcd == 0)
                                {
                                    rateSettingDiv = "3F";
                                }
                                else if (blcd != 0)
                                {
                                    rateSettingDiv = "3D";
                                }
                                else if (glcd != 0)
                                {
                                    rateSettingDiv = "3E";
                                }
                            }
                            // 層別の場合
                            else
                            {
                                if (blcd == 0 && glcd == 0)
                                {
                                    rateSettingDiv = "3G";
                                }
                                else if (blcd != 0)
                                {
                                    rateSettingDiv = "3B";
                                }
                                else if (glcd != 0)
                                {
                                    rateSettingDiv = "3C";
                                }
                            }
                            break;
                        }
                    case "得意先":
                        {
                            // 商品掛率Ｇの場合
                            if (this._goodsMode == GoodsMode.GoodsRateG)
                            {
                                if (blcd == 0 && glcd == 0 && ggcd == 0)
                                {
                                    rateSettingDiv = "";
                                }
                                else if (blcd == 0 && glcd == 0)
                                {
                                    rateSettingDiv = "1F";
                                }
                                else if (blcd != 0)
                                {
                                    rateSettingDiv = "1D";
                                }
                                else if (glcd != 0)
                                {
                                    rateSettingDiv = "1E";
                                }
                            }
                            // 層別の場合
                            else
                            {
                                if (blcd == 0 && glcd == 0)
                                {
                                    rateSettingDiv = "1G";
                                }
                                else if (blcd != 0)
                                {
                                    rateSettingDiv = "1B";
                                }
                                else if (glcd != 0)
                                {
                                    rateSettingDiv = "1C";
                                }
                            }
                            break;
                        }
                }
                unitPriceKind = 1;
            }
        }

        /// <summary>
        /// 掛率設定区分取得
        /// </summary>
        /// <param name="rateSettingDic">戻る掛率設定区分　key:列名 value:単価種類と掛率設定区分</param>
        /// <param name="row"></param>
        /// <param name="rateProtyMngDataTable">掛率優先管理テブール</param>
        /// <remarks>
        /// <br>Note       : 掛率設定区分取得。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/18</br> 
        /// </remarks>
        private void GetRateSetting(out Dictionary<string, List<object>> rateSettingDic, UltraGridRow row, DataTable rateProtyMngDataTable)
        {
            rateSettingDic = new Dictionary<string, List<object>>();
            List<object> tempList;
            // 拠点コード
            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
            // 単価種類
            int unitPriceKind= 0;
            // 掛率設定区分
            string rateSettingDiv = string.Empty;
            //同じ拠点のデータ行
            List<DataRow> sameSectionCodeRowList;
            DataRow[] sameSectionCodeRows = null;
            // 取得掛率設定区分用列名設定
            List<string> columnNameList = new List<string>();
            // 仕入率列を追加する
            columnNameList.Add(COLUMN_COSTRATE);
            // 掛率列の第1列が売価率の第１列を追加する
            columnNameList.Add(COLUMN_SALERATE1);
            // 掛率の他の列が売価率の第2列が代表として、追加する
            columnNameList.Add(COLUMN_SALERATE2);

            for (int i = 0; i < columnNameList.Count; i++ )
            {
                sameSectionCodeRowList = new List<DataRow>();
                tempList = new List<object>();
                // 設定掛率設定区分
                SetRateSettingDiv(row, row.Cells[columnNameList[i]], out unitPriceKind, out rateSettingDiv);
                foreach (DataRow rateProtyMngDataTableRow in rateProtyMngDataTable.Rows)
                {
                    if (rateProtyMngDataTableRow["拠点コード"].ToString().Trim() == sectionCode.Trim()
                        && rateProtyMngDataTableRow["単価種類"].ToString().Trim() == unitPriceKind.ToString().Trim()
                        && rateProtyMngDataTableRow["掛率設定区分"].ToString().Trim() == rateSettingDiv.Trim()
                        && (( sectionCode.Trim() != "00" 
                             && rateProtyMngDataTableRow["使用区分"].ToString().Trim() == "自拠点")
                           || ( sectionCode.Trim() == "00" 
                               && rateProtyMngDataTableRow["使用区分"].ToString().Trim() == "全社共通")))
                    {
                        sameSectionCodeRowList.Add(rateProtyMngDataTableRow);
                    }
                }
                sameSectionCodeRows = new DataRow[sameSectionCodeRowList.Count];
                sameSectionCodeRowList.CopyTo(sameSectionCodeRows);
                // 単価種類
                tempList.Add(unitPriceKind);
                // 掛率設定区分
                tempList.Add(rateSettingDiv);
                //同じ拠点のデータ行
                tempList.Add(sameSectionCodeRows);
                // 戻る掛率設定区分Dictionaryに掛率設定区分を追加する
                if (!rateSettingDic.ContainsKey(columnNameList[i]))
                {
                    rateSettingDic.Add(columnNameList[i],tempList);
                }
            }
        }

        /// <summary>
        /// 毎セルの掛率設定区分比較データ取得
        /// </summary>
        /// <param name="comDataList"></param>
        /// <param name="cell"></param>
        /// <param name="rateSettingDic"></param>
        /// <remarks>
        /// <br>Note       : 毎セルの掛率設定区分比較データ取得。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/18</br>
        /// </remarks>
        private void GetRateSettingComData(out List<object> comDataList, UltraGridCell cell, Dictionary<string, List<object>> rateSettingDic)
        {
            comDataList = new List<object>();
            // 仕入率と掛率以外の列を設定しない
            if (!cell.Column.Key.Contains(COLUMN_COSTRATE)
                && (!cell.Column.Key.Contains(COLUMN_SALERATE))
                && (!cell.Column.Key.Contains(COLUMN_UPRATE))
                && (!cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
            {
                return;
            }
            List<string> columnNameList = new List<string>();
            foreach (string columnName in rateSettingDic.Keys)
            {
                columnNameList.Add(columnName);
            }
            if(cell.Column.Key == COLUMN_COSTRATE)
            {
                //画面によって、単価種類と掛率設定区分設定
                comDataList = rateSettingDic[COLUMN_COSTRATE];
            }
            
            if ((cell.Column.Key == COLUMN_SALERATE1 )
                || (cell.Column.Key == COLUMN_UPRATE1 )
                || (cell.Column.Key == COLUMN_GRSPROFITSECURERAT1))
            {
                //画面によって、単価種類と掛率設定区分設定
                comDataList = rateSettingDic[COLUMN_SALERATE1];
            }
            if ((cell.Column.Key.Contains(COLUMN_SALERATE) && (cell.Column.Key != COLUMN_SALERATE1))
               || (cell.Column.Key.Contains(COLUMN_UPRATE) && (cell.Column.Key != COLUMN_UPRATE1))
               || (cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT) && (cell.Column.Key != COLUMN_GRSPROFITSECURERAT1)))
            {
                //画面によって、単価種類と掛率設定区分設定
                comDataList = rateSettingDic[COLUMN_SALERATE2];
            }
        }

        /// <summary>
        /// 掛率優先管理マスタに条件と合わせるでータを取得
        /// </summary>
        /// <param name="rateProtyMngDataTable">掛率優先管理テブール</param>
        /// <remarks>
        /// <br>Note       : 掛率優先管理マスタに条件と合わせるでータを取得。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/18</br>
        /// </remarks>
        private void GetRateSettingMasterData(out DataTable rateProtyMngDataTable)
        {
            int status;
            // 拠点コード
            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.PadLeft(2, '0');
            RateProtyMng rateProtyMng = new RateProtyMng();
            rateProtyMngDataTable = new DataTable();
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();	// 掛率優先管理アクセスクラス
            //掛率優先管理テーブル
            string RATEPROTYMNG_TABLE = "RateProtyMngTable";
            //企業コード
            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            int retTotalCnt = 0;
            bool nextDta = false;
            string message = string.Empty;
            DataSet rateProtyMngDataSet = new DataSet();
            // 掛率優先管理マスタにデータの取得
            status = rateProtyMngAcs.Search(out rateProtyMngDataSet, out retTotalCnt, out nextDta, enterpriseCode, sectionCode, out message);
            if (status == 0)
            {
                // 掛率優先管理テブール取得
                rateProtyMngDataTable = rateProtyMngDataSet.Tables[RATEPROTYMNG_TABLE];
            }
        }

        /// <summary>
        /// テキスト出力:画面に表示しているパターンの取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : テキスト出力:画面に表示しているパターンを取得します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br>  
        /// </remarks>
        private int GetPatternNo()
        {
            int patternNo = 0;
            // 商品掛率Ｇの場合
            if (!this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden)
            {
                // 売価率の場合
                if (this.uLabel_SaleRate.Text==RATE_TITLE_RATEVAL)
                {
                    // 得意先掛率Ｇの場合
                    if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE1)
                    {
                        patternNo = 1;// 出力パターン1：商品掛率Ｇ＋得意先掛率Ｇ＋売価率
                    }
                    // 得意先の場合
                    else 
                    {
                        if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE2)
                        {
                            patternNo = 2;// 出力パターン2：商品掛率Ｇ＋得意先＋売価率
                        }
                        
                    }
                }
                // 原価UP率の場合
                else if (this.uLabel_SaleRate.Text==RATE_TITLE_UPRATE)
                {
                    // 得意先掛率Ｇの場合
                    if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE1)
                    {
                        patternNo = 3;// 出力パターン3：商品掛率Ｇ＋得意先掛率Ｇ＋原価UP率
                    }
                    // 得意先の場合
                    else 
                    {
                        if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE2)
                        {
                            patternNo = 4;// 出力パターン4：商品掛率Ｇ＋得意先＋原価UP率
                        }
                        
                    }
                }
        　　　　// 粗利確保率の場合
                else if (this.uLabel_SaleRate.Text==RATE_TITLE_GRSPROFITSECURERAT)
                {
                    // 原価UP率の場合
                    if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE1)
                    {
                        patternNo = 5;// 出力パターン5：商品掛率Ｇ＋得意先掛率Ｇ＋粗利確保率
                    }
                    // 得意先の場合
                    else 
                    {
                        if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE2)
                        {
                            patternNo = 6;// 出力パターン6：商品掛率Ｇ＋得意先＋粗利確保率
                        }
                        
                    }
                }
            }
            // 層別の場合
            else
            {
                if (!this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden)
                {
                    // 売価率の場合
                    if (this.uLabel_SaleRate.Text==RATE_TITLE_RATEVAL)
                    {
                        // 得意先掛率Ｇの場合
                        if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE1)
                        {
                            patternNo = 7;// 出力パターン7：層別＋得意先掛率Ｇ＋売価率
                        }
                        // 得意先の場合
                        else
                        {
                            if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE2)
                            {
                                patternNo = 8;// 出力パターン8：層別＋得意先＋売価率
                            }

                        }
                    }
                    // 原価UP率の場合
                    else if (this.uLabel_SaleRate.Text==RATE_TITLE_UPRATE)
                    {
                        // 得意先掛率Ｇの場合
                        if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE1)
                        {
                            patternNo = 9;// 出力パターン9：層別＋得意先掛率Ｇ＋原価UP率
                        }
                        // 得意先の場合
                        else
                        {
                            if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE2)
                            {
                                patternNo = 10;// 出力パターン10：層別＋得意先＋原価UP率
                            }

                        }
                    }
                    // 粗利確保率の場合
                    else if (this.uLabel_SaleRate.Text==RATE_TITLE_GRSPROFITSECURERAT)
                    {
                        // 得意先掛率Ｇの場合
                        if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE1)
                        {
                            patternNo = 11;// 出力パターン11：層別＋得意先掛率Ｇ＋粗利確保率
                        }
                        // 得意先の場合
                        else
                        {
                            if (this.uLabel_CustomerMode.Text==CUSTOMER_MODE2)
                            {
                                patternNo = 12;// 出力パターン12：層別＋得意先＋粗利確保率
                            }

                        }
                    }

                }
            }
            return patternNo;
        }

        /// <summary>
        /// テキスト出力:出力項目名設定
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : テキスト出力:出力項目名Dictionaryを取得します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br>  
        /// </remarks>
        private Dictionary<int, string> GetSchemeDic()
        {
            Dictionary<int, string> schemeDic = new Dictionary<int, string>();
            schemeDic.Add(1, COLUMN_NO);// 行番号
            schemeDic.Add(2, COLUMN_GOODSRATEGRPCODE);// 商品掛率Ｇ
            schemeDic.Add(3, COLUMN_GLCD);// グループコード
            schemeDic.Add(4, COLUMN_BLCD);// ＢＬコード
            schemeDic.Add(5, COLUMN_NAME);// グループとＢＬの名称
            schemeDic.Add(6, COLUMN_MAKERCODE);// メーカーコード
            schemeDic.Add(7, COLUMN_MAKERNAME);// メーカー名称
            schemeDic.Add(8, COLUMN_SUPPLIERCODE);// 仕入先
            schemeDic.Add(9, COLUMN_COSTRATE);// 仕入率
            schemeDic.Add(10, uLabel_CustomerMode.Text);// 得意先検索条件
            schemeDic.Add(11, uLabel_SaleRate.Text);// 掛率（売価率・原価UP率・粗利確保率）
            // 商品掛率Ｇの場合
            if (!this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden)
            {
                schemeDic[2] = COLUMN_GOODSRATEGRPCODE;// 商品掛率Ｇ出力する、層別出力しない
            }
            // 層別の場合
            else
            {
                if (!this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden)
                {
                    schemeDic[2] = COLUMN_GOODSRATERANK;// 商品掛率Ｇ出力しない、層別出力する
                }
                
            }
            return schemeDic;
        }

        ///<summary>
        /// テキスト出力用データテーブルの作成
        /// </summary>
        /// <param name="dataTable">テキスト出力用データテーブル</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : テキスト出力用データテーブルを作成します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br>  
        /// </remarks>
        private void GetTextOutputDataTable(out DataTable dataTable)
        {
            dataTable = new DataTable();
            Dictionary<int, string> schemeDic = GetSchemeDic();
            // データタイプ設定
            foreach (string scheme in schemeDic.Values)
            {
                switch (scheme)
               {
                    case COLUMN_NO:
                    {
                        dataTable.Columns.Add(scheme,typeof(int));
                        break;
                    }
                    case COLUMN_COSTRATE:
                    {
                        dataTable.Columns.Add(scheme, typeof(double));
                        break;
                    }
                    default:
                    {
                        dataTable.Columns.Add(scheme, typeof(string));
                        break;
                    }
                }
            }
            // 出力項目の表示文字の設定
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            dataTable.Columns[COLUMN_NO].Caption = "行No";
            dataTable.Columns[schemeDic[2]].Caption = schemeDic[2] == COLUMN_GOODSRATEGRPCODE ? "商品掛率G" : "層別";
            dataTable.Columns[COLUMN_GLCD].Caption = "GRCD";
            dataTable.Columns[COLUMN_BLCD].Caption = "BLｺｰﾄﾞ";
            dataTable.Columns[COLUMN_NAME].Caption = "BLｺｰﾄﾞ名称";
            dataTable.Columns[COLUMN_MAKERCODE].Caption = "ﾒｰｶｰｺｰﾄﾞ";
            dataTable.Columns[COLUMN_MAKERNAME].Caption = "ﾒｰｶｰ名称";
            dataTable.Columns[COLUMN_SUPPLIERCODE].Caption=columns[COLUMN_SUPPLIERCODE].Header.Caption;
            dataTable.Columns[COLUMN_COSTRATE].Caption=columns[COLUMN_COSTRATE].Header.Caption;
            dataTable.Columns[uLabel_CustomerMode.Text].Caption = uLabel_CustomerMode.Text;
            dataTable.Columns[uLabel_SaleRate.Text].Caption = uLabel_SaleRate.Text;
            DataRow row = null;
            DataTable uGridDetailsDataTable=(DataTable)this.uGrid_Details.DataSource;
            int patternNo = GetPatternNo();
            
            for (int rowIndex = 2; rowIndex < uGridDetailsDataTable.Rows.Count; rowIndex++)
            {
                // 得意先検索条件の入力列数の取得
                int columnsCount = 0;
                switch (patternNo)
                {
                    // 売価率の場合
                    case 1:
                    case 2:
                    case 7:
                    case 8:
                        {
                            for (int i = 1; i <= 100; i++)
                            {
                                if ((uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()] != DBNull.Value
                                    && uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()] != null
                                    && this._customerSearchMode == CustomerSearchMode.CustomerRateG
                                    && uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()].ToString() != string.Empty
                                    && StrObjToInt(uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()]) == 0)
                                    || StrObjToInt(uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()]) != 0)// 検索条件行の入力チェック
                                {
                                    columnsCount++;
                                    continue;
                                }
                            }

                        break;
                    }
                　　// 原価UP率の場合
                    case 3:
                    case 4:
                    case 9:
                    case 10:
                        {
                            for (int i = 1; i <= 100; i++)
                             {
                                 if ((uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()] != DBNull.Value
                                    && uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()] != null
                                    && this._customerSearchMode == CustomerSearchMode.CustomerRateG
                                    && uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()].ToString() != string.Empty
                                    && StrObjToInt(uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()]) == 0)
                                    || StrObjToInt(uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()]) != 0)// 検索条件行の入力チェック
                                 {
                                     columnsCount++;
                                     continue;
                                 }
                            }

                        break;
                    }
             　　   // 粗利確保率の場合
                    case 5:
                    case 6:
                    case 11:
                    case 12:
                        {
                            for (int i = 1; i <= 100; i++)
                            {
                                if ((uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()] != DBNull.Value
                                    && uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()] != null
                                    && this._customerSearchMode == CustomerSearchMode.CustomerRateG
                                    && uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()].ToString() != string.Empty
                                    && StrObjToInt(uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()]) == 0)
                                    || StrObjToInt(uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + i.ToString()]) != 0)// 検索条件行の入力チェック
                                {
                                    columnsCount++;
                                    continue;
                                }
                            }

                            break;
                        }
                }
                // データの複数行表示
                for (int columnIndex = 1; columnIndex <= columnsCount; columnIndex++)
                {
                    row = dataTable.NewRow();
                    // テキスト出力用データ取得
                    row[COLUMN_NO] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_NO];
                    if (schemeDic[2] == COLUMN_GOODSRATEGRPCODE)
                    {
                        row[schemeDic[2]] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_GOODSRATEGRPCODE];// 商品掛率Ｇ
                    }
                    else
                    {
                        row[schemeDic[2]] = uGridDetailsDataTable.Rows[rowIndex][schemeDic[2]];// 層別
                    }
                    row[COLUMN_GLCD] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_GLCD];// グループコード
                    row[COLUMN_BLCD] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_BLCD];// ＢＬコード
                    if ( StrObjToInt(uGridDetailsDataTable.Rows[rowIndex][COLUMN_BLCD]) != 0)
                    {
                        row[COLUMN_NAME] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_NAME];// ＢＬ名称
                    }
                    else
                    {
                        row[COLUMN_NAME] = string.Empty;// ＢＬ名称
                    }
                    row[COLUMN_MAKERCODE] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_MAKERCODE];// メーカーコード
                    row[COLUMN_MAKERNAME] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_MAKERNAME];// メーカー名称
                    row[COLUMN_SUPPLIERCODE] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_SUPPLIERCODE];// 仕入先
                    row[COLUMN_COSTRATE] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_COSTRATE].ToString() != String.Empty ? uGridDetailsDataTable.Rows[rowIndex][COLUMN_COSTRATE] : 0;//仕入率

                    switch (patternNo)
                    {
                        // 売価率の場合
                        case 1:
                        case 2:
                        case 7:
                        case 8:
                            {
                                row[uLabel_CustomerMode.Text] = uGridDetailsDataTable.Rows[0][COLUMN_SALERATE + columnIndex.ToString()];// 得意先掛率Ｇ・得意先
                                row[uLabel_SaleRate.Text] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_SALERATE + columnIndex.ToString()].ToString() != String.Empty ? uGridDetailsDataTable.Rows[rowIndex][COLUMN_SALERATE + columnIndex.ToString()] : 0;//売価率
                                string formatString = SetPriceDotDiv(row[uLabel_SaleRate.Text].ToString());
                                row[uLabel_SaleRate.Text] = DoubleObjToDouble(row[uLabel_SaleRate.Text]).ToString(formatString);
                                break;
                            }
                        // 原価UP率の場合
                        case 3:
                        case 4:
                        case 9:
                        case 10:
                            {
                                row[uLabel_CustomerMode.Text] = uGridDetailsDataTable.Rows[0][COLUMN_UPRATE + columnIndex.ToString()];// 得意先掛率Ｇ・得意先
                                row[uLabel_SaleRate.Text] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_UPRATE + columnIndex.ToString()].ToString() != String.Empty ? uGridDetailsDataTable.Rows[rowIndex][COLUMN_UPRATE + columnIndex.ToString()] : 0;//原価UP率
                                string formatString = SetPriceDotDiv(row[uLabel_SaleRate.Text].ToString());
                                row[uLabel_SaleRate.Text] = DoubleObjToDouble(row[uLabel_SaleRate.Text]).ToString(formatString);
                                break;
                            }
                         // 粗利確保率の場合
                        case 5:
                        case 6:
                        case 11:
                        case 12:
                            {
                                row[uLabel_CustomerMode.Text] = uGridDetailsDataTable.Rows[0][COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()];// 得意先掛率Ｇ・得意先
                                row[uLabel_SaleRate.Text] = uGridDetailsDataTable.Rows[rowIndex][COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()].ToString() != String.Empty ? uGridDetailsDataTable.Rows[rowIndex][COLUMN_GRSPROFITSECURERAT + columnIndex.ToString()] : 0;//粗利確保率
                                string formatString = SetPriceDotDiv(row[uLabel_SaleRate.Text].ToString());
                                row[uLabel_SaleRate.Text] = DoubleObjToDouble(row[uLabel_SaleRate.Text]).ToString(formatString);
                                 break;
                             }

                    }
                    dataTable.Rows.Add(row); 
                }
            }
        }

        ///<summary>
        /// Excel出力：セルマージ
        ///</summary>
        /// <param name="e">イベントハンドラ</param>
        /// <param name="columnNo">マージ列の番号</param>
        /// <param name="rowPosDic">前回マージ列の開始行番号と終了行番号</param>
        /// <remarks>
        /// <br>Note       : Excel出力：セルマージ処理します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br>  
        /// </remarks>
        private void CellMerge(ref Infragistics.Win.UltraWinGrid.ExcelExport.EndExportEventArgs e, int columnNo,ref Dictionary<int, int> rowPosDic)
        {
            string compareStr = string.Empty;
            int rowStartIndex = 0;// マージ開始行
            int rowEndIndex = 0;// マージ終了行
            // 商品掛率Ｇ・層別列のマージ
            if (rowPosDic.Count == 0)
            {
                rowStartIndex = 4;
                rowEndIndex = rowStartIndex;
                compareStr = e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].Value.ToString();
                int index = rowStartIndex;
                CellMergeProc(ref e, columnNo, ref rowPosDic,e.CurrentRowIndex, rowStartIndex, rowEndIndex);// マージ実行
            }
            // グループコード列のマージ
            else
            {
                // 同じ商品掛率Ｇ・層別にグループコード列のマージ
                foreach (int key in rowPosDic.Keys)
                {
                    rowStartIndex = key + 1;
                    rowEndIndex = rowStartIndex;
                    compareStr = e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].Value.ToString();
                    int index = rowStartIndex;
                    Dictionary<int, int> tempRowPosDic = new Dictionary<int, int>();
                    CellMergeProc(ref e, columnNo, ref tempRowPosDic, rowPosDic[key] + 1, rowStartIndex, rowEndIndex);// マージ実行
                }
                rowPosDic = new Dictionary<int, int>();
            }
        }

        ///<summary>
        /// Excel出力：セルマージ
        ///</summary>
        /// <param name="e">イベントハンドラ</param>
        /// <param name="columnNo">マージ列の番号</param>
        /// <param name="rowPosDic">マージ列の開始行番号と終了行番号</param>
        /// <param name="rowMaxCount">ファイルの最大行数</param>
        /// <param name="rowStartIndex">マージ開始行番号</param>
        /// <param name="rowEndIndex">マージ終了行番号</param>
        /// <remarks>
        /// <br>Note       : Excel出力：セルマージ処理します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br>  
        /// </remarks>
        private void CellMergeProc(ref Infragistics.Win.UltraWinGrid.ExcelExport.EndExportEventArgs e, int columnNo, ref Dictionary<int, int> rowPosDic,int rowMaxCount,int rowStartIndex,int rowEndIndex)
        {
            string compareGoodsMGStr = e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].Value.ToString();// 商品掛率グループ・層別
            string compareMakerStr = e.CurrentWorksheet.Rows[rowStartIndex].Cells[4].Value.ToString();// メーカーコード
            int index = rowStartIndex;

            while (index < rowMaxCount)
            {
                bool compareFlag = false;
                if (compareGoodsMGStr == e.CurrentWorksheet.Rows[index].Cells[columnNo].Value.ToString()
                    && compareMakerStr == e.CurrentWorksheet.Rows[index].Cells[4].Value.ToString())
                {
                    compareFlag = true;
                }
                e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].CellFormat.VerticalAlignment = Infragistics.Excel.VerticalCellAlignment.Center;
                if ((!compareFlag)
                    || (compareFlag  
                        && index == e.CurrentRowIndex - 1))
                {
                    if (index - rowStartIndex > 1
                            || (compareFlag
                               && index == rowMaxCount - 1
                               && index - rowStartIndex >= 1))// 単行マージなし
                    {
                        if (!compareFlag)
                        {
                            // 中間行のマージ
                            e.CurrentWorksheet.MergedCellsRegions.Add(rowStartIndex, columnNo, rowEndIndex - 1, columnNo);
                        }
                        else
                        {
                            // 最後行のマージ
                            e.CurrentWorksheet.MergedCellsRegions.Add(rowStartIndex, columnNo, rowEndIndex, columnNo);
                        }
                        // グループ名称・ＢＬコード名称取得
                        string value = e.CurrentWorksheet.Rows[rowStartIndex].Cells[3].Value.ToString();
                        e.CurrentWorksheet.MergedCellsRegions.Add(rowStartIndex, columnNo + 1, rowStartIndex, 3);
                        // マージ列のセル表示書類設定
                        e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].CellFormat.RightBorderStyle = Infragistics.Excel.CellBorderLineStyle.None;
                        e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo + 1].CellFormat.LeftBorderStyle = Infragistics.Excel.CellBorderLineStyle.None;
                        e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo + 1].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left;
                        e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo + 1].CellFormat.VerticalAlignment = Infragistics.Excel.VerticalCellAlignment.Center;
                        // グループコード列マージ後、セルの値がグループ名称・ＢＬコード名称に変更する
                        e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo + 1].Value = value;
                        // マージセルの文字の表示位置の設定
                        if (columnNo == 0)
                        {
                            // 商品掛率Ｇ・層別列のマージセルの文字の表示位置の設定（横方向）
                            e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left;
                        }
                        else
                        {
                            // グループ列のマージセルの文字の表示位置の設定（横方向）
                            e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Right;
                        }
                        // マージセルの文字の表示位置の設定（縦方向）
                        e.CurrentWorksheet.Rows[rowStartIndex].Cells[columnNo].CellFormat.VerticalAlignment = Infragistics.Excel.VerticalCellAlignment.Top;
                        rowPosDic.Add(rowStartIndex, rowEndIndex);
                    }
                    rowStartIndex = index;
                    compareGoodsMGStr = e.CurrentWorksheet.Rows[index].Cells[columnNo].Value.ToString();
                    compareMakerStr = e.CurrentWorksheet.Rows[index].Cells[4].Value.ToString();
                }
                rowEndIndex++;
                index++;
            }
            // 最後行、マージしない時、文字の表示位置の設定（縦方向）
            if(e.CurrentWorksheet.Rows[e.CurrentRowIndex - 1].Cells[columnNo].Value != null
               && ( e.CurrentWorksheet.Rows[e.CurrentRowIndex - 1].Cells[columnNo].Value != e.CurrentWorksheet.Rows[e.CurrentRowIndex - 2].Cells[columnNo].Value))
            {
                e.CurrentWorksheet.Rows[e.CurrentRowIndex - 1].Cells[columnNo].CellFormat.VerticalAlignment = Infragistics.Excel.VerticalCellAlignment.Center;
            }
        }

        /// <summary>
        /// 小数表示区分設定
        /// </summary>
        /// <param name="value">掛率</param>
        /// <returns>小数表示区分</returns>
        /// <remarks>
        /// <br>Note       : 小数表示区分設定。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/06</br>
        /// </remarks>
        private string SetPriceDotDiv(string value)
        {
            string formatCount = string.Empty;
            // 小数部がある場合
            if (value.Contains("."))
            {
                string[] subStrs = value.Split('.');
                // 小数部が「00」の場合、小数部表示しない
                if (subStrs[1] == "00")
                {
                    formatCount = "0";
                }
            　　// 小数部が「*0」の場合、小数部が一位で表示する
                else if (subStrs[1].Substring(1, 1) == "0")
                {
                    formatCount = "0.0";
                }
                // 他の場合、小数部が全表示を設定する
                else
                {
                    formatCount = "0.00";
                }
            }
            // 小数部がない場合、整数だけ表示する
            else
            {
                formatCount = "0";
            }
            return formatCount;
        }


        /// <summary>
        /// 列の小数部の最大長さを取得する
        /// </summary>
        /// <param name="ultraGrid">出力用グリード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 列の小数部の最大長さを取得する。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/12</br>
        /// </remarks>
        private Dictionary<int, int> GetMaxValueCount(UltraGrid ultraGrid)
        {
            Dictionary<int, int> retDic = new Dictionary<int, int>();
            foreach (UltraGridColumn column in ultraGrid.DisplayLayout.Bands[0].Columns)
            {
                // 掛率列だけ、数字の表示位置調整
                if (column.Key.Contains(COLUMN_GRSPROFITSECURERAT)
                    || column.Key.Contains(COLUMN_SALERATE)
                    || column.Key.Contains(COLUMN_UPRATE))
                {
                    List<int> cellValueList = new List<int>();
                    string maxValue = string.Empty;
                    foreach (UltraGridRow row in ultraGrid.Rows)
                    {
                        if (row.Index > 2)// 掛率表示行が第3行に開始する
                        {
                            if (DoubleObjToDouble(row.Cells[column].Value) != 0)// セルの値の判断
                            {
                                string cellValue = row.Cells[column].Value.ToString().Trim();
                                if (cellValue.Contains("."))
                                {
                                    // 小数部が「00」・「*0」以外の場合
                                    if (cellValue.Split('.')[1].Substring(cellValue.Split('.')[1].Length - 1, 1) != "0")
                                    {
                                        cellValueList.Add(cellValue.Split('.')[1].Length);// 小数部の長さ取得 
                                    }
                                    // 小数部が「*0」の場合（画面には小数が2位だけ入力するので、「*0」の場合には小数部の長さが「１」を設定する）
                                    else if (cellValue.Split('.')[1].Substring(cellValue.Split('.')[1].Length - 1, 1) == "0" && cellValue.Split('.')[1] != "00")
                                    {
                                        cellValueList.Add(1);
                                    }
                                    // 小数部が「00」の場合、小数の長さが「0」を設定します
                                    else 
                                    {
                                        cellValueList.Add(0);
                                    }
                                }
                                // 整数の場合、小数の長さが「0」を設定します
                                else
                                {
                                    cellValueList.Add(0);
                                }
                            }
                            else
                            {
                                cellValueList.Add(0);
                                continue;
                            }
                        }
                    }
                    if (cellValueList != null)
                    {
                        cellValueList.Sort();// 取得小数長さのソート処理
                        if (!retDic.ContainsKey(column.Index))
                        {
                            retDic.Add(column.Index, cellValueList[cellValueList.Count - 1]);// 戻るDictionaryに列番号と該列の小数の最大長さを追加する
                        }
                    }
                }
            }
            return retDic;
        }


        /// <summary>
        /// Excel出力後、掛率の表示位置設定
        /// </summary>
        /// <param name="e"></param>
        /// <param name="customerEndColNo">得意先検索条件表示列数</param>
        /// <remarks>
        /// <br>Note       : Excel出力後、掛率の表示位置設定。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/13</br>
        /// </remarks>
        private void SetDisplayRateFormat(ref Infragistics.Win.UltraWinGrid.ExcelExport.EndExportEventArgs e, int customerEndColNo)
        {
            // 掛率起始入力行
            const int rowStartIndex = RATESTARTROW;
            // 得意先検索条件と掛率起始入力列
            const int columnStartIndex = RATESTARTCOLUMN;
            // 掛率数字の表示長さ調整
           
            for (int columnIndex = columnStartIndex; columnIndex <= customerEndColNo; columnIndex++)
            {
                // 該列の小数最大長さ取得
                int maxPointLength = 0;
                if (this._maxPointLengthDic.ContainsKey(columnIndex))
                {
                    maxPointLength = this._maxPointLengthDic[columnIndex];
                }
                else
                {
                    continue;
                }
                for (int rowIndex = rowStartIndex; rowIndex < e.CurrentRowIndex; rowIndex++)
                {
                    // 該列の毎行の掛率の長さ調整
                    if (DoubleObjToDouble(e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value) != 0)// セルの値の判断
                    {
                        string cellValue = e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value.ToString().Trim();
                        if (cellValue.Contains("."))
                        {
                            string leftValue = cellValue.Split('.')[0].ToString().Trim();// 整数部
                            string rightValue = cellValue.Split('.')[1].ToString().Trim();// 小数部
                            if (rightValue.Length < maxPointLength)// 小数部の長さを該列の最大長さと比べる
                            {
                                // 長さ調整
                                e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value = leftValue + "." + rightValue.PadRight(maxPointLength　+ 1, ' '); 
                            }
                        }
                        else
                        {
                            // 小数部の最大長さが「0」の以上の場合、掛率を調整する。その以外の場合には、調整しません。
                            if (maxPointLength > 0)
                            {
                                // 長さ調整
                                e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value = cellValue.PadRight(cellValue.Length + (maxPointLength*2) + 1, ' '); 
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 新追加行のチェック処理
        /// </summary>
        /// <param name="newAddRow">新追加行</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>チェックパターン　0:チェックなし 1:必須入力項チェック　 2:重複データチェック　 3:掛率優先管理設定区分チェック </returns>
        /// <remarks>
        /// <br>Note       : 新追加行のチェック処理。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/16</br>
        /// </remarks>
        private int CheckNewAddRowDataBeforeSave(UltraGridRow newAddRow, out string message)
        {
            message = string.Empty;
            int checkPattarn = 0;
            // 既存画面行数取得
            int oldRowsCount = this._displayList.Count + 2;
            #region 掛率入力判断
            int cellIndex = 0;
            // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>>
            //foreach(UltraGridCell newAddRowCell in newAddRow.Cells)
            //{
            //    cellIndex++;
            //    // 非掛率列
            //    if (!newAddRowCell.Column.Key.Contains(COLUMN_COSTRATE)
            //        && !newAddRowCell.Column.Key.Contains(COLUMN_SALERATE)
            //        && !newAddRowCell.Column.Key.Contains(COLUMN_UPRATE)
            //        && !newAddRowCell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT))
            //    {
            //        continue;
            //    }
            //    // 非表示掛率列
            //    else if (newAddRowCell.Column.Hidden)
            //    {
            //        continue;
            //    }
            //    // 表示掛率列
            //    else
            //    {
            //         
            //        if (DoubleObjToDouble(newAddRowCell.Value) != 0)
            //        {
            //            break;
            //        }
            //    }
            //}
            // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
            // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
            string rowFilter = COLUMN_NO + " = " + IntObjToInt(newAddRow.Cells[COLUMN_NO].Value).ToString();
            DataRow[] matchRows = null;
            if (this._newAddRowTempTable.Rows.Count > 0)
            {
                matchRows = this._newAddRowTempTable.Select(rowFilter); 
            }
            foreach (UltraGridCell cell in newAddRow.Cells)
            {
                cellIndex++;
                // 非掛率列
                if (!cell.Column.Key.Contains(COLUMN_COSTRATE)
                    && !cell.Column.Key.Contains(COLUMN_SALERATE)
                    && !cell.Column.Key.Contains(COLUMN_UPRATE)
                    && !cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT))
                {
                    continue;
                }
                // 非表示掛率列
                else if (cell.Column.Hidden)
                {
                    continue;
                }
                // 表示掛率列
                else
                {
                    // 既存掛率あり
                    if ( matchRows != null && matchRows.Length > 0)
                    {
                        if (DoubleObjToDouble(cell.Value) != DoubleObjToDouble(matchRows[0][cell.Column.Key])) // 掛率値が変更されました
                        {
                            break;
                        }
                    }
　　　　　　　　　　// 既存掛率なし
                    else
                    {
                        if (DoubleObjToDouble(cell.Value) != 0) // 掛率値が入力した
                        {
                            break;
                        }
                    }
                }
            }
            // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
            // 入力した掛率列なし、チェックをしません
            if (cellIndex == newAddRow.Cells.Count)
            {
                checkPattarn = -1; // ADD donggy 2013/04/19 for Redmine#35355
                return checkPattarn;
            }
            #endregion　掛率入力判断
            #region 必須入力項チェック
           
            // 商品掛率グループの場合
            if(this._goodsMode == GoodsMode.GoodsRateG)
            {
                // 商品掛率グループとＢＬコードチェック
                if (StrObjToInt(newAddRow.Cells[COLUMN_GOODSRATEGRPCODE].Value) == 0
                    && StrObjToInt(newAddRow.Cells[COLUMN_BLCD].Value) == 0
                    && StrObjToInt(newAddRow.Cells[COLUMN_GLCD].Value) == 0)
                {
                    message = "商品掛率G、GRCD、BLCDのいずれかを入力してください。";
                    checkPattarn = 1;
                    return checkPattarn;
                }
            }
            // 層別の場合
            else
            {
                // 層別チェック
                if (StrObjToStr(newAddRow.Cells[COLUMN_GOODSRATERANK].Value) == string.Empty)
                {
                    message = "層別を入力してください。";
                    checkPattarn = 2;
                    return checkPattarn;
                }
            }
            // メーカーコードチェック
            if (StrObjToInt(newAddRow.Cells[COLUMN_MAKERCODE].Value) == 0)
            {
                message = "メーカーを入力してください。";
                checkPattarn = 3;
                return checkPattarn;
            }
            #endregion　必須入力項チェック

            #region 重複データチェック
            #region 画面に表示データとチェック処理
            if (this.uGrid_Details.Rows.Count == this._displayList.Count + 2)
            {
                return checkPattarn;
            }
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                // 新追加同じ行チェックなし
                if (row.Index == newAddRow.Index)
                {
                    break;
                }
                // 商品掛率グループの場合
                if (this._goodsMode == GoodsMode.GoodsRateG)
                {

                    if (newAddRow.Cells[COLUMN_MAKERCODE].Value.ToString().Trim() == row.Cells[COLUMN_MAKERCODE].Value.ToString().Trim() // メーカー
                        &&((StrObjToInt(newAddRow.Cells[COLUMN_BLCD].Value) != 0) // ＢＬコードを入力した場合
                            && (newAddRow.Cells[COLUMN_BLCD].Value.ToString().Trim() == row.Cells[COLUMN_BLCD].Value.ToString().Trim())
                          || ((StrObjToInt(newAddRow.Cells[COLUMN_GLCD].Value) != 0) // ＢＬグループコードを入力した場合
                            && (newAddRow.Cells[COLUMN_GLCD].Value.ToString().Trim() == row.Cells[COLUMN_GLCD].Value.ToString().Trim()))
                          || ((StrObjToInt(newAddRow.Cells[COLUMN_GOODSRATEGRPCODE].Value) != 0)// 商品掛率グループコードを入力した場合
                            && (newAddRow.Cells[COLUMN_GOODSRATEGRPCODE].Value.ToString().Trim() == row.Cells[COLUMN_GOODSRATEGRPCODE].Value.ToString().Trim()))))
                    {
                        message = "入力されたコードのデータが既に存在しています。";
                        checkPattarn = 4;
                        return checkPattarn;
                    }
                }
                // 層別の場合
                else
                {
                    if((newAddRow.Cells[COLUMN_GOODSRATERANK].Value.ToString().Trim() == row.Cells[COLUMN_GOODSRATERANK].Value.ToString().Trim())// 層別
                          && (newAddRow.Cells[COLUMN_MAKERCODE].Value.ToString().Trim() == row.Cells[COLUMN_MAKERCODE].Value.ToString().Trim()))　// メーカー
                    {
                        // ＢＬコードを入力した場合
                        if (StrObjToInt(newAddRow.Cells[COLUMN_BLCD].Value) != 0)
                        {
                            if(newAddRow.Cells[COLUMN_BLCD].Value.ToString().Trim() == row.Cells[COLUMN_BLCD].Value.ToString().Trim())
                            {
                                message = "入力されたコードのデータが既に存在しています。";
                                checkPattarn = 4;
                                return checkPattarn;
                            }
                        }
                        // グループコードを入力した場合
                        else if(StrObjToInt(newAddRow.Cells[COLUMN_GLCD].Value) != 0)// ＢＬグループコードを入力した場合
                        {
                            if(newAddRow.Cells[COLUMN_GLCD].Value.ToString().Trim() == row.Cells[COLUMN_GLCD].Value.ToString().Trim())
                            {
                                message = "入力されたコードのデータが既に存在しています。";
                                checkPattarn = 4;
                                return checkPattarn;
                            }
                        }
                    　　// グループコードとＢＬコードどちらも入力しない場合
                        else
                        {
                            if (StrObjToInt(newAddRow.Cells[COLUMN_GLCD].Value) == StrObjToInt(row.Cells[COLUMN_GLCD].Value)
                                && StrObjToInt(newAddRow.Cells[COLUMN_BLCD].Value) == StrObjToInt(row.Cells[COLUMN_BLCD].Value))
                            {
                            message = "入力されたコードのデータが既に存在しています。";
                            checkPattarn = 4;
                            return checkPattarn;
                        }
                    }
                }
            }
            }
            #endregion 画面に表示データとチェック処理

            #endregion　重複データチェック

            #region 掛率優先管理設定区分チェック
            //単価種類
            int unitPriceKind = 0;
            //掛率設定区分
            string rateSettingDivide = string.Empty;
            // 掛率優先管理テブール
            DataTable rateProtyMngDataTable;
            //同じ拠点のデータ行
            DataRow[] sameSectionCodeRows = null;
            // 掛率優先管理テブール取得
            GetRateSettingMasterData(out rateProtyMngDataTable);
            Dictionary<string, List<object>> rateSettingsDic;
            // 掛率設定区分を取得する
            GetRateSetting(out rateSettingsDic, newAddRow, rateProtyMngDataTable);
            List<object> compareDataList;
            foreach (UltraGridCell newRowCell in newAddRow.Cells)
            {
                // 毎セルの掛率設定区分比較データ取得
                GetRateSettingComData(out compareDataList, newRowCell, rateSettingsDic);
                // 仕入率と掛率以外の列をチェックしない
                if (compareDataList.Count < 1)
                {
                    continue;
                }
                // 未入力列をチェックしない
                if (DoubleObjToDouble(newRowCell.Value) == 0)
                {
                    continue;
                }
                // 画面によって、単価種類と掛率設定区分設定
                unitPriceKind = StrObjToInt(compareDataList[0].ToString());
                rateSettingDivide = compareDataList[1].ToString();
                // 同じ拠点のデータ取得
                sameSectionCodeRows = (DataRow[])compareDataList[2];
                if (unitPriceKind > 0
                            && ((sameSectionCodeRows != null
                                && sameSectionCodeRows.Length < 1)
                                || sameSectionCodeRows == null))
                {
                    message = "「" + rateSettingDivide + "」は掛率優先設定区分に未保存のパターンです。" + Environment.NewLine;
                    message +=  "行No:  " + newRowCell.Row.Cells[COLUMN_NO].Value.ToString();
                    checkPattarn = 5;
                    return checkPattarn;
                }
            }
            return checkPattarn;
            #endregion　掛率優先管理設定区分チェック
        }

        /// <summary>
        /// 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
        /// </summary>
        /// <remarks>
        /// <br>Note       : 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/19</br>
        /// </remarks>
        private void SetNewRowCustColumnHidden()
        {
            if ( this._displayList.Count == 0)
            {
                List<string> customerSerList = new List<string>();
                // 得意先検索条件取得
                if (this.chkSearchingAll.Enabled )
                {
                    this._targetDic.Clear();
                    GetCustomerSecCondition();
                    foreach (int key in this._targetDic.Keys)
                    {
                        if (key == -1)
                        {
                            customerSerList.Add(ALL_CUST_RATE_GRP);
                        }
                        else
                        {
                            customerSerList.Add(key.ToString());
                        }
                    }

                    // 入力条件のよって、画面を制御する
                    if (customerSerList.Count > 0)
                    {
                        int colIndex = 1;
                        // 画面制御
                        foreach (UltraGridCell cell in this.uGrid_Details.Rows[0].Cells)
                        {

                            if (!cell.Column.Key.Contains(COLUMN_SALERATE)
                                && (!cell.Column.Key.Contains(COLUMN_UPRATE))
                                && (!cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
                            {
                                continue;
                            }
                            else
                            {
                                cell.Column.Hidden = true;
                                cell.Appearance.BackColorDisabled = Color.Gainsboro;
                                cell.Appearance.ForeColorDisabled = Color.Black;
                                cell.Activation = Activation.Disabled;
                                // 入力条件の名称行
                                this.uGrid_Details.Rows[1].Cells[cell.Column.Key].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[cell.Column.Key].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[cell.Column.Key].Activation = Activation.Disabled;
                            }
                        }
                        foreach (string customerSerValue in customerSerList)
                        {
                            // 売価率の場合
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE + colIndex.ToString()].Value = customerSerValue;
                            // 原価UP率の場合
                            this.uGrid_Details.Rows[0].Cells[COLUMN_UPRATE + colIndex.ToString()].Value = customerSerValue;
                            // 粗利確保率の場合
                            this.uGrid_Details.Rows[0].Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value = customerSerValue;
                            colIndex++;
                        }
                    }
                }
                // 掛率列表示設定
                if (this._targetDic.Keys.Count > 0)
                {
                    for (int colIndex = 1; colIndex <= this._targetDic.Keys.Count; colIndex++)
                    {
                        switch (this._rateMode)
                        {
                            // 売価率の場合
                            case RateMode.RateVal:
                                {
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_SALERATE + colIndex.ToString()].Hidden = false;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_UPRATE + colIndex.ToString()].Hidden = true;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Hidden = true;

                                    break;
                                }
                            // 原価UP率の場合
                            case RateMode.UpRate:
                                {
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_SALERATE + colIndex.ToString()].Hidden = true;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_UPRATE + colIndex.ToString()].Hidden = false;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Hidden = true;
                                    break;
                                }
                            // 粗利確保率の場合
                            case RateMode.GrsProfitSecureRat:
                                {
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_SALERATE + colIndex.ToString()].Hidden = true;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_UPRATE + colIndex.ToString()].Hidden = true;
                                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Hidden = false;
                                    break;
                                }
                        }
                    }
                }
                // 得意先検索範囲指定
                this.chkSearchingAll.Enabled = false;
            }
        }

        /// <summary>
        /// 入力コードによって、名称を設定する
        /// </summary>
        /// <param name="textboxName">コードを入力したテキストボックス名</param>
        /// <param name="e">フォーカス変更イベント変数</param>
        /// <remarks>
        /// <br>Note       : 入力コードによって、名称を設定する。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/28</br>
        /// </remarks>
        private void SetNameByCode(string textboxName, ChangeFocusEventArgs e)
        {
            switch (textboxName)
            {
                # region 拠点コード
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                        if (!string.IsNullOrEmpty(sectionCode))
                        {
                            // 拠点名称を取る
                            string sectionName = GetSectionName(sectionCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(sectionName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で拠点コードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_SectionCodeAllowZero.Text = _prevCode;
                                this.tEdit_SectionCodeAllowZero.SelectAll();
                                if (e != null)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                                else
                                {
                                    this.tEdit_SectionCodeAllowZero.Focus();
                                }
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_SectionName.DataText = sectionName;
                                _prevCode = sectionCode;
                            }
                        }
                        else
                        {
                            this.tEdit_SectionName.DataText = GetSectionName(sectionCode);
                        }
                        break;
                    }
                # endregion

                #region 仕入先コード
                // 仕入先コード
                case "tNedit_SupplierCd":
                    {
                        int supplierCode = this.tNedit_SupplierCd.GetInt();

                        if (!string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
                        {
                            // 仕入先名称を取る
                            string supplierName = GetSupplierName(supplierCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(supplierName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で仕入先コードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_SupplierCd.Text = _prevCode;
                                this.tNedit_SupplierCd.SelectAll();
                                if (e != null)
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                }
                                else
                                {
                                    this.tNedit_SupplierCd.Focus();
                                }
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_SupplierName.DataText = supplierName;
                                _prevCode = supplierCode.ToString();
                            }
                        }
                        else
                        {
                            this.tEdit_SupplierName.DataText = string.Empty;
                        }
                        break;
                    }
                # endregion

                #region 商品掛率Ｇコード
                // 商品掛率Ｇコード
                case "tNedit_GoodsMGroup":
                    {
                        int goodsGroupCode = this.tNedit_GoodsMGroup.GetInt();

                        if (!string.IsNullOrEmpty(this.tNedit_GoodsMGroup.Text))
                        {
                            // 商品掛率Ｇ名称を取る
                            string goodsGroupName = GetGoodsGroupName(goodsGroupCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(goodsGroupName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で商品掛率Ｇコードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_GoodsMGroup.Text = _prevCode;
                                this.tNedit_GoodsMGroup.SelectAll();
                                if (e != null)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMGroup;
                                }
                                else
                                {
                                    this.tNedit_GoodsMGroup.Focus();
                                }
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_GoodsRateGrpName.DataText = goodsGroupName;
                                _prevCode = goodsGroupCode.ToString();
                            }
                        }
                        else
                        {
                            this.tEdit_GoodsRateGrpName.DataText = string.Empty;
                        }
                        break;
                    }
                # endregion

                # region メーカーコード
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                        if (!string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text))
                        {
                            // メーカー名称を取る
                            string makerName = GetMakerName(makerCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(makerName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件でメーカーコードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_GoodsMakerCd.Text = _prevCode;
                                this.tNedit_GoodsMakerCd.SelectAll();
                                if (e != null)
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Focus();
                                }
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_MakerName.DataText = makerName;
                                _prevCode = makerCode.ToString();
                            }
                        }
                        else
                        {
                            this.tEdit_MakerName.DataText = string.Empty;
                        }
                        break;
                    }
                    # endregion
            }
        }


        /// <summary>
        /// 得意先検索条件取得
        /// </summary>
        /// <br>Note       : 得意先検索条件範囲以内のデータ取得。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/03/18</br>
        private void GetCustomerSecCondition()
        {
            // 得意先検索条件範囲未指定の場合
            if (!this.chkSearchingAll.Checked)
            {
                this._targetDic.Clear();
                // 検索条件：Grid　処理
                for (int index = 9; index < this.uGrid_Details.Rows[0].Cells.Count; index++)
                {
                    if (!this.chkSearchingAll.Checked)
                    {
                        if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                        {
                            // 得意先掛率Ｇ検索時、ALLを設定する
                            if (!this._targetDic.ContainsKey(ALL_CUST_RATE_GRP_CODE))
                            {
                                this._targetDic.Add(ALL_CUST_RATE_GRP_CODE, ALL_CUST_RATE_GRP_CODE);
                                continue;
                            }
                        }

                        int code = StrObjToInt(this.uGrid_Details.Rows[0].Cells[index].Value);

                        if (code == 0)
                        {
                            object cellValue = this.uGrid_Details.Rows[0].Cells[index].Value;
                            if ((cellValue == DBNull.Value) || (cellValue == null) || !(cellValue.ToString() == "0000"))
                            {
                                continue;
                            }
                        }

                        if (!this._targetDic.ContainsKey(code))
                        {
                            this._targetDic.Add(code, code);
                        }
                    }
                }
                // 手入力得意先掛率Ｇ数が「１００」の場合には、「ALL」を検索しない
                if (this._targetDic.Keys.Count > 100
                    && this._targetDic.ContainsKey(ALL_CUST_RATE_GRP_CODE))
                {
                    this._targetDic.Remove(ALL_CUST_RATE_GRP_CODE);
                }
            }
            // 得意先検索条件範囲指定の場合
            else
            {
                int searchSt = StrObjToInt(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Value);
                int searchEd = StrObjToInt(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE2].Value);
                string searchStS = StrObjToStr(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Value);
                string searchEdS = StrObjToStr(this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE2].Value);

                if (this._customerSearchRetDic == null)
                {
                    // 得意先マスタ読込処理
                    this.ReadCustomerSearchRet();
                }
                if (this._custRateGrpDic == null)
                {
                    // ユーザーガイドマスタ(得意先掛率Ｇ)読込処理
                    this.ReadCustRateGrp();
                }
                this._targetDic.Clear();
                // 得意先掛率グループ
                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    // 得意先掛率グループマスタから範囲内の得意先掛率グループを取得する
                    foreach (int key in this._custRateGrpDic.Keys)
                    {
                        if (searchEdS == string.Empty && key >= searchSt && _targetDic.Count < 100)
                        {
                            this._targetDic.Add(key, key);
                        }
                        else if (key >= searchSt && key <= searchEd && _targetDic.Count < 100)
                        {
                            this._targetDic.Add(key, key);
                        }
                    }
                }
                // 得意先
                else
                {
                    foreach (int key in this._customerSearchRetDic.Keys)
                    {
                        if (searchEdS == string.Empty && key >= searchSt && _targetDic.Count < 100)
                        {
                            this._targetDic.Add(key, key);
                        }
                        else if (key >= searchSt && key <= searchEd && _targetDic.Count < 100)
                        {
                            this._targetDic.Add(key, key);
                        }
                    }
                }

                if (this._targetDic.Keys.Count == 0)
                {
                    _existFlg = false;
                }
                else
                {
                    _existFlg = true;
                }
            }
        }

        /// <summary>
        /// 売価率・原価UP率・粗利確保率元データ取得
        /// </summary>
        /// <param name="result">子明細</param>
        /// <param name="resultList">子明細リスト</param>
        /// <param name="code">得意先検索コード</param>
        /// <br>Note       : 売価率・原価UP率・粗利確保率元データ取得</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/04/04</br>
        private void GetRateUpdateData(ref Rate2SearchResult result,List<Rate2SearchResult> resultList,int code )
        {
            if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
            {
                result = resultList.Find(delegate(Rate2SearchResult target)
                {
                    if (target.UnitPriceKind != "1")
                        return false;

                    // FIXME:得意先掛率グループ"指定なし"
                    if (code < 0)
                    {
                        return IsAllCustRateGrpCode(target);
                    }
                    // 得意先掛率グループ指定有り
                    if (target.CustRateGrpCode == code && target.RateMngCustCd == "3")
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });
            }
            else
            {
                result = resultList.Find(delegate(Rate2SearchResult target)
                {
                    if (target.UnitPriceKind != "1")
                        return false;

                    // FIXME:得意先掛率グループ"指定なし"
                    if (code < 0)
                    {
                        return IsAllCustRateGrpCode(target);
                    }
                    if (target.CustomerCode == code)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });
            }
        }

        /// <summary>
        /// 既存掛率データ更新
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="cells">変更セル</param>
        /// <param name="result">子明細</param>
        /// <param name="unitPriceKind">単価種類区分</param>
        /// <param name="colIndex">掛率列番号</param>
        /// <param name="parentDiv">親子区分</param>
        /// <param name="code">得意先掛率Ｇ・得意先コード</param>
        /// <br>Note       : 既存掛率データ更新。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/04/04</br>
        /// <br>Update Note: 2013/04/19 donggy</br>
        /// <br>管理番号   : 10901273-00 配信日未定</br>
        /// <br>              Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
        /// <br>　　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
        // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>>
        //private void UpdateRateData(ref ArrayList saveList, ref ArrayList deleteList,CellsCollection cells,
        //                            Rate2SearchResult result, string unitPriceKind, int colIndex)
        // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<<
        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>>
        private void UpdateRateData(ref ArrayList saveList, ref ArrayList deleteList,CellsCollection cells,
                                    Rate2SearchResult result, string unitPriceKind, int colIndex, int parentDiv,int code)
        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<<
        {
            Rate updateRate = new Rate();
            if (unitPriceKind == "2")
            {
                // 論理削除データ保存なし
                if (cells[COLUMN_COSTRATE].Activation == Activation.Disabled) return;
                if (DoubleObjToDouble(cells[COLUMN_COSTRATE].Value) == 0)
                {
                    if (result.FileHeaderGuid != Guid.Empty)
                    {
                        // データ削除
                        updateRate = CopyToRateFromRateSearchResult(result.Clone());
                        deleteList.Add(updateRate.Clone());
                    }
                }
                else
                {
                    // データ更新
                    // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                    if (result.SectionCode.Trim() == ctSectionCode
                        && this.tEdit_SectionCodeAllowZero.Text.Trim() != ctSectionCode)
                    {
                        // 仕入変更する場合、入力拠点で新規データを作成する。
                        if(DoubleObjToDouble(cells[COLUMN_COSTRATE].Value) != 0)
                        {
                            MakeNewCostrateData(out updateRate, cells, parentDiv); // 入力拠点で新規データの作成
                            if (updateRate != null
                                && updateRate.RateVal != 0.0)
                            {
                                updateRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim(); // 入力拠点を設定する
                                saveList.Add(updateRate.Clone());
                            }
                            return;
                        }
                    }
                    // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                    // 変更がない場合は更新用リストに追加しない
                    if (result.RateVal != DoubleObjToDouble(cells[COLUMN_COSTRATE].Value))
                    {
                        updateRate = CopyToRateFromRateSearchResult(result.Clone());
                        updateRate.RateVal = DoubleObjToDouble(cells[COLUMN_COSTRATE].Value);
                        saveList.Add(updateRate.Clone());
                    }
                }
            }
            else if (unitPriceKind == "1")
            {
                // 論理削除データ保存なし
                if (cells[COLUMN_SALERATE + colIndex.ToString()].Activation == Activation.Disabled) return;
                if (DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value) == 0
                            && DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value) == 0
                            && DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value) == 0)
                {
                    if (result.FileHeaderGuid != Guid.Empty)
                    {
                        // データ削除
                        updateRate = CopyToRateFromRateSearchResult(result.Clone());
                        deleteList.Add(updateRate.Clone());
                    }
                }
                else
                {
                    // データ更新
                    // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                    if (result.SectionCode.Trim() == ctSectionCode
                        && this.tEdit_SectionCodeAllowZero.Text.Trim() != ctSectionCode)
                    {
                        // 掛率変更する場合、入力拠点で新規データを作成する。
                        switch (this._rateMode)
                        {
                            // 売価率の場合
                            case RateMode.RateVal:
                                {
                                    if (DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value) != 0)
                                    {
                                        MakeNewRateData(out updateRate, cells, parentDiv, code, colIndex); // 入力拠点で新規データの作成
                                        if (updateRate != null
                                            && updateRate.RateVal != 0.0)
                                        {
                                            updateRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim(); // 入力拠点を設定する
                                            saveList.Add(updateRate.Clone());
                                        }
                                        return;
                                    }
                                    break;
                                }
                            // 原価UP率の場合
                            case RateMode.UpRate:
                                {
                                    if (DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value) != 0)
                                    {
                                        MakeNewRateData(out updateRate, cells, parentDiv, code, colIndex); // 入力拠点で新規データの作成
                                        if (updateRate != null
                                            && updateRate.UpRate != 0.0)
                                        {
                                            updateRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim(); // 入力拠点を設定する
                                            saveList.Add(updateRate.Clone());
                                        }
                                        return;
                                    }
                                    break;
                                }
                            // 粗利確保率の場合
                            case RateMode.GrsProfitSecureRat:
                                {
                                    if (DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT+ colIndex.ToString()].Value) != 0)
                                    {
                                        MakeNewRateData(out updateRate, cells, parentDiv, code, colIndex); // 入力拠点で新規データの作成
                                        if (updateRate != null
                                            && updateRate.GrsProfitSecureRate != 0.0)
                                        {
                                            updateRate.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim(); // 入力拠点を設定する
                                            saveList.Add(updateRate.Clone());
                                        }
                                        return;
                                    }
                                    break;
                                }
                        }
                    }
                    // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<
                    // 変更がない場合は更新用リストに追加しない
                    if (result.RateVal != DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value)
                        || result.UpRate != DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value)
                        || result.GrsProfitSecureRate != DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value))
                    {
                        updateRate = CopyToRateFromRateSearchResult(result.Clone());
                        // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>
                        //updateRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //updateRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                        //updateRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value); 
                        // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<
                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>
                        if (cells[COLUMN_SALERATE + colIndex.ToString()].Appearance.ForeColor != Color.Red)
                        {
                            updateRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value); 
                        }
                        if (cells[COLUMN_UPRATE + colIndex.ToString()].Appearance.ForeColor != Color.Red)
                        {
                            updateRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value); 
                        }
                        if (cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Appearance.ForeColor != Color.Red)
                        {
                            updateRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value); 
                        }
                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<
                        saveList.Add(updateRate.Clone());
                    }
                }
            }
        }

        /// <summary>
        /// 新仕入率データ作成
        /// </summary>
        /// <param name="newCostrateRate">新仕入率デー</param>
        /// <param name="cells">新入力仕入率の行の全部セル</param>
        /// <param name="parentDiv">親子区分</param>
        /// <br>Note       : 新仕入率データ作成。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        private void MakeNewCostrateData(out Rate newCostrateRate,CellsCollection cells,int parentDiv)
        {
            // データ追加
            newCostrateRate = CreateRate();
            // 論理削除データ保存なし
            if (cells[COLUMN_COSTRATE].Activation == Activation.Disabled) return;
            // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>>
            if (cells[COLUMN_COSTRATE].Appearance.ForeColor == Color.Red) // データ変更なし
            {
                newCostrateRate = null;
                return;
            }
            // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<<
            // 商品掛率Ｇ
            if (this._goodsMode == GoodsMode.GoodsRateG)
            {
                // 親明細
                if (parentDiv == 0)
                {
                    newCostrateRate.UnitRateSetDivCd = "25F";
                    newCostrateRate.RateSettingDivide = "5F";
                    newCostrateRate.RateMngGoodsCd = "F";
                    newCostrateRate.RateMngGoodsNm = "ﾒｰｶｰ+商品掛率G";
                    newCostrateRate.GoodsRateGrpCode = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value);
                }
                // グループ親明細
                else if (parentDiv == 2)
                {
                    newCostrateRate.UnitRateSetDivCd = "25E";
                    newCostrateRate.RateSettingDivide = "5E";
                    newCostrateRate.RateMngGoodsCd = "E";
                    newCostrateRate.RateMngGoodsNm = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                    newCostrateRate.BLGroupCode = StrObjToInt(cells[COLUMN_GLCD].Value);
                }
                // 子明細
                else
                {
                    newCostrateRate.UnitRateSetDivCd = "25D";
                    newCostrateRate.RateSettingDivide = "5D";
                    newCostrateRate.RateMngGoodsCd = "D";
                    newCostrateRate.RateMngGoodsNm = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                    newCostrateRate.BLGoodsCode = StrObjToInt(cells[COLUMN_BLCD].Value);
                }
            }
            // 層別
            else
            {
                // 親明細
                if (parentDiv == 0)
                {
                    newCostrateRate.UnitRateSetDivCd = "25G";
                    newCostrateRate.RateSettingDivide = "5G";
                    newCostrateRate.RateMngGoodsCd = "G";
                    newCostrateRate.RateMngGoodsNm = "ﾒｰｶｰ+層別";
                    newCostrateRate.GoodsRateRank = cells[COLUMN_GOODSRATERANK].Value.ToString();
                }
                // グループ親明細
                else if (parentDiv == 2)
                {
                    newCostrateRate.UnitRateSetDivCd = "25C";
                    newCostrateRate.RateSettingDivide = "5C";
                    newCostrateRate.RateMngGoodsCd = "C";
                    newCostrateRate.RateMngGoodsNm = "ﾒｰｶｰ+層別+ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                    newCostrateRate.GoodsRateRank = cells[COLUMN_GOODSRATERANK].Value.ToString();
                    newCostrateRate.BLGroupCode = StrObjToInt(cells[COLUMN_GLCD].Value);
                }
                // 子明細
                else
                {
                    newCostrateRate.UnitRateSetDivCd = "25B";
                    newCostrateRate.RateSettingDivide = "5B";
                    newCostrateRate.RateMngGoodsCd = "B";
                    newCostrateRate.RateMngGoodsNm = "ﾒｰｶｰ+層別+BLｺｰﾄﾞ";
                    newCostrateRate.GoodsRateRank = cells[COLUMN_GOODSRATERANK].Value.ToString();
                    newCostrateRate.BLGoodsCode = StrObjToInt(cells[COLUMN_BLCD].Value);
                }
            }

            newCostrateRate.UnitPriceKind = "2";
            newCostrateRate.RateMngCustCd = "5";
            newCostrateRate.RateMngCustNm = "仕入先";
            newCostrateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_MAKERCODE].Value);
            newCostrateRate.SupplierCd = StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value);
            newCostrateRate.RateVal = DoubleObjToDouble(cells[COLUMN_COSTRATE].Value);
        }

        /// <summary>
        /// 新掛率（売価率・原価UP率・粗利確保率）データ作成
        /// </summary>
        /// <param name="newRate">新掛率データ</param>
        /// <param name="cells">新入力掛率の行の全部セル</param>
        /// <param name="parentDiv">親子区分</param>
        /// <param name="code">入力得意先検索条件</param>
        /// <param name="colIndex">入力列</param>
        /// <br>Note       : 新掛率（売価率・原価UP率・粗利確保率）データ作成。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// <br>Update Note: 2013/04/19 donggy</br>
        /// <br>管理番号   : 10901273-00 配信日未定</br>
        /// <br>            Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
        /// <br>　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
        private void MakeNewRateData(out Rate newRate, CellsCollection cells, int parentDiv,int code,int colIndex)
        {
            newRate = CreateRate();
            // 論理削除データ保存なし
            if (cells[COLUMN_SALERATE + colIndex.ToString()].Activation == Activation.Disabled) return;
            if (this._goodsMode == GoodsMode.GoodsRateG)
            {
                if (parentDiv == 0)
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        // 13F または 15F
                        newRate.UnitRateSetDivCd = code >= 0 ? "13F" : "15F";
                        newRate.RateSettingDivide = code >= 0 ? "3F" : "5F";
                        newRate.RateMngCustCd = code >= 0 ? "3" : "5";
                        newRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                        newRate.CustRateGrpCode = code >= 0 ? code : 0;
                    }
                    else
                    {
                        newRate.UnitRateSetDivCd = "11F";
                        newRate.RateSettingDivide = "1F";
                        newRate.RateMngCustCd = "1";
                        newRate.RateMngCustNm = "得意先+仕入先";
                        newRate.CustomerCode = code;
                    }
                    newRate.RateMngGoodsCd = "F";
                    newRate.RateMngGoodsNm = "ﾒｰｶｰ+商品掛率G";
                    newRate.GoodsRateGrpCode = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value);
                }
                else if (parentDiv == 2)
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        // FIXME:13E または 15E
                        newRate.UnitRateSetDivCd = code >= 0 ? "13E" : "15E";
                        newRate.RateSettingDivide = code >= 0 ? "3E" : "5E";
                        newRate.RateMngCustCd = code >= 0 ? "3" : "5";
                        newRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                        newRate.CustRateGrpCode = code >= 0 ? code : 0;
                    }
                    else
                    {
                        newRate.UnitRateSetDivCd = "11E";
                        newRate.RateSettingDivide = "1E";
                        newRate.RateMngCustCd = "1";
                        newRate.RateMngCustNm = "得意先+仕入先";
                        newRate.CustomerCode = code;
                    }
                    newRate.RateMngGoodsCd = "E";
                    newRate.RateMngGoodsNm = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                    newRate.BLGroupCode = StrObjToInt(cells[COLUMN_GLCD].Value);
                }
                else
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        // FIXME:13D または 15D
                        newRate.UnitRateSetDivCd = code >= 0 ? "13D" : "15D";
                        newRate.RateSettingDivide = code >= 0 ? "3D" : "5D";
                        newRate.RateMngCustCd = code >= 0 ? "3" : "5";
                        newRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                        newRate.CustRateGrpCode = code >= 0 ? code : 0;
                    }
                    else
                    {
                        newRate.UnitRateSetDivCd = "11D";
                        newRate.RateSettingDivide = "1D";
                        newRate.RateMngCustCd = "1";
                        newRate.RateMngCustNm = "得意先+仕入先";
                        newRate.CustomerCode = code;
                    }
                    newRate.RateMngGoodsCd = "D";
                    newRate.RateMngGoodsNm = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                    newRate.BLGoodsCode = StrObjToInt(cells[COLUMN_BLCD].Value);
                }
            }
            else
            {
                if (parentDiv == 0)
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        // 13G または 15G
                        newRate.UnitRateSetDivCd = code >= 0 ? "13G" : "15G";
                        newRate.RateSettingDivide = code >= 0 ? "3G" : "5G";
                        newRate.RateMngCustCd = code >= 0 ? "3" : "5";
                        newRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                        newRate.CustRateGrpCode = code >= 0 ? code : 0;
                    }
                    else
                    {
                        newRate.UnitRateSetDivCd = "11G";
                        newRate.RateSettingDivide = "1G";
                        newRate.RateMngCustCd = "1";
                        newRate.RateMngCustNm = "得意先+仕入先";
                        newRate.CustomerCode = code;
                    }
                    newRate.RateMngGoodsCd = "G";
                    newRate.RateMngGoodsNm = "ﾒｰｶｰ+層別";
                    newRate.GoodsRateRank = cells[COLUMN_GOODSRATERANK].Value.ToString();
                }
                else if (parentDiv == 2)
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        // FIXME:13C または 15C
                        newRate.UnitRateSetDivCd = code >= 0 ? "13C" : "15C";
                        newRate.RateSettingDivide = code >= 0 ? "3C" : "5C";
                        newRate.RateMngCustCd = code >= 0 ? "3" : "5";
                        newRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                        newRate.CustRateGrpCode = code >= 0 ? code : 0;
                    }
                    else
                    {
                        newRate.UnitRateSetDivCd = "11C";
                        newRate.RateSettingDivide = "1C";
                        newRate.RateMngCustCd = "1";
                        newRate.RateMngCustNm = "得意先+仕入先";
                        newRate.CustomerCode = code;
                    }
                    newRate.RateMngGoodsCd = "C";
                    newRate.RateMngGoodsNm = "ﾒｰｶｰ+層別+ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                    newRate.GoodsRateRank = cells[COLUMN_GOODSRATERANK].Value.ToString();
                    newRate.BLGroupCode = StrObjToInt(cells[COLUMN_GLCD].Value);
                }
                else
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        // FIXME:13B または 15B
                        newRate.UnitRateSetDivCd = code >= 0 ? "13B" : "15B";
                        newRate.RateSettingDivide = code >= 0 ? "3B" : "5B";
                        newRate.RateMngCustCd = code >= 0 ? "3" : "5";
                        newRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                        newRate.CustRateGrpCode = code >= 0 ? code : 0;
                    }
                    else
                    {
                        newRate.UnitRateSetDivCd = "11B";
                        newRate.RateSettingDivide = "1B";
                        newRate.RateMngCustCd = "1";
                        newRate.RateMngCustNm = "得意先+仕入先";
                        newRate.CustomerCode = code;
                    }
                    newRate.RateMngGoodsCd = "B";
                    newRate.RateMngGoodsNm = "ﾒｰｶｰ+層別+BLｺｰﾄﾞ";
                    newRate.GoodsRateRank = cells[COLUMN_GOODSRATERANK].Value.ToString();
                    newRate.BLGoodsCode = StrObjToInt(cells[COLUMN_BLCD].Value);
                }
            }

            newRate.UnitPriceKind = "1";
            newRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_MAKERCODE].Value);
            newRate.SupplierCd = StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value);

            switch (this._rateMode)
            {
                case RateMode.RateVal:
                    {
                        // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>
                        //if (DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value) != 0)
                        //{
                        //    newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //    // 新追加の原価UP率と粗利確保率も保存はずです
                        //    if (cells[COLUMN_SALERATE + colIndex.ToString()].Row.Index >= this._displayList.Count + 2)
                        //    {
                        //        newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                        //        newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);

                        //    }
                        //}
                        //else
                        //{
                        //    // 新追加行全て掛率列のデータを保存します
                        //    newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //    newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                        //    newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);
                        //}
                        // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>
                        if (DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value) != 0
                            && cells[COLUMN_SALERATE + colIndex.ToString()].Appearance.ForeColor != Color.Red) // 非赤字データ
                        {
                            newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                           
                        }
                        // 新追加の原価UP率と粗利確保率も保存はずです
                        if (cells[COLUMN_SALERATE + colIndex.ToString()].Row.Index >= this._displayList.Count + 2)
                        {
                            if (cells[COLUMN_UPRATE + colIndex.ToString()].Appearance.ForeColor != Color.Red ) // 非赤字データ
                            {
                                newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                            }
                            if (cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Appearance.ForeColor != Color.Red ) // 非赤字データ
                            {
                                newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);
                            }

                        }
                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                        break;
                    }
                case RateMode.UpRate:
                    {
                        // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                        //if (DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value) != 0)
                        //{
                        //    newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                        //    // 新追加の売価率と粗利確保率も保存はずです
                        //    if (cells[COLUMN_UPRATE + colIndex.ToString()].Row.Index >= this._displayList.Count + 2)
                        //    {
                        //        newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //        newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);
                        //    }
                        //}
                        //else
                        //{
                        //    // 新追加行非表示掛率列のデータを保存します
                        //    newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //    newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);
                        //}
                        // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>
                        if (DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value) != 0
                            && cells[COLUMN_UPRATE + colIndex.ToString()].Appearance.ForeColor != Color.Red) // 非赤字データ 
                        {
                            newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);

                        }
                        // 新追加の売価率と粗利確保率も保存はずです
                        if (cells[COLUMN_UPRATE + colIndex.ToString()].Row.Index >= this._displayList.Count + 2)
                        {
                            if (cells[COLUMN_SALERATE + colIndex.ToString()].Appearance.ForeColor != Color.Red ) // 非赤字データ
                            {
                                newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                            }
                            if (cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Appearance.ForeColor != Color.Red ) // 非赤字データ
                            {
                                newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);
                            }

                        }
                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                        break;
                    }
                case RateMode.GrsProfitSecureRat:
                    {
                        // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>>
                        //if (DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value) != 0)
                        //{
                        //    newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);
                        //    // 新追加の原価UP率と売価率も保存はずです
                        //    if (cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Row.Index >= this._displayList.Count + 2)
                        //    {
                        //        newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                        //        newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //    }
                        //}
                        //else
                        //{
                        //    // 新追加行非表示掛率列のデータを保存します
                        //    newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                        //    newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                        //}
                        // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<
                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>
                        if (DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value) != 0
                            && cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Appearance.ForeColor != Color.Red) // 非赤字データ
                        {
                            newRate.GrsProfitSecureRate = DoubleObjToDouble(cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value);

                        }
                        // 新追加の原価UP率と粗利確保率も保存はずです
                        if (cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Row.Index >= this._displayList.Count + 2)
                        {
                            if (cells[COLUMN_UPRATE + colIndex.ToString()].Appearance.ForeColor != Color.Red ) // 非赤字データ
                            {
                                newRate.UpRate = DoubleObjToDouble(cells[COLUMN_UPRATE + colIndex.ToString()].Value);
                            }
                            if (cells[COLUMN_SALERATE + colIndex.ToString()].Appearance.ForeColor != Color.Red ) // 非赤字データ
                            {
                                newRate.RateVal = DoubleObjToDouble(cells[COLUMN_SALERATE + colIndex.ToString()].Value);
                            }

                        }
                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                        break;
                    }
            }
        }

        /// <summary>
        /// 得意先コードチェック
        /// </summary>
        /// <param name="code">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 得意先コードチェックします</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private bool CustomerIsExist(string code,ref string customerName)
        {
            if (this._customerSearchRetDic == null)
            {
                // 得意先マスタ読込処理
                this.ReadCustomerSearchRet();
            }

            int customerCd = Convert.ToInt32(code);
            CustomerSearchRet customerInfo;

            if (this._customerSearchRetDic.TryGetValue(customerCd, out customerInfo))
            {
                customerName = customerInfo.Snm.Trim();
                return true;
            }

            return false;
        }
        /// <summary>
        /// 得意先掛率Gチェック
        /// </summary>
        /// <param name="code">得意先掛率G</param>
        /// <param name="customerGpName">得意先掛率G名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率Gチェックします</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private bool CustomerGIsExist(string code,ref string customerGpName)
        {
            if (_userGuid43Dic == null)
            {
                this.ReadUserGuide();
            }

            int customerGpCd = Convert.ToInt32(code);
            UserGdBd userGdBd = null;

            if (this._userGuid43Dic.TryGetValue(customerGpCd, out userGdBd))
            {
                customerGpName = userGdBd.GuideName.Trim();
                return true;
            }

            return false;
        }

        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// 次または先入力可能セル移動処理
        /// </summary>
        /// <param name="isNext">true:次のセールへ移動;false:先のセールへ移動</param>
        /// <returns>移動状態</returns>
        private CellMoveState MoveToAllowEditCell(bool isNext)
        {
            UltraGridCell cell = this.uGrid_Details.ActiveCell;
            if (cell == null) return CellMoveState.MustJump;

            int curRowIdx = cell.Row.Index;
            int curColIdx = cell.Column.Index;
            int rowCount = this.uGrid_Details.Rows.Count;
            int colCount = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count;

            // 得意先掛率Ｇコード又は得意先コードにフォーカスがある場合
            if (!cell.Column.Hidden
                && cell.Activation == Activation.AllowEdit)
            {
                this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                if (!_bevalueFlag)
                {
                    _bevalueFlag = true;
                    return CellMoveState.Stay;
                }
            }

            if (isNext)
            {
                for (int rowIdx = curRowIdx; rowIdx < rowCount; rowIdx++)
                {
                    int colIdx = 0;
                    if (rowIdx == curRowIdx) colIdx = curColIdx + 1;
                    for (; colIdx < colCount; colIdx++)
                    {
                        if (!uGrid_Details.Rows[rowIdx].Hidden
                            && !uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.Hidden
                            && uGrid_Details.Rows[rowIdx].Cells[colIdx].Activation == Activation.AllowEdit
                            && uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.CellActivation == Activation.AllowEdit)
                        {
                            uGrid_Details.Rows[rowIdx].Cells[colIdx].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return CellMoveState.Moved;
                        }
                    }
                }
            }
            else
            {
                for (int rowIdx = curRowIdx; rowIdx > -1; rowIdx--)
                {
                    int colIdx = colCount - 1;
                    if (rowIdx == curRowIdx) colIdx = curColIdx - 1; 
                    for (; colIdx > -1; colIdx--)
                    {
                        if (!uGrid_Details.Rows[rowIdx].Hidden
                            && !uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.Hidden
                            && uGrid_Details.Rows[rowIdx].Cells[colIdx].Activation == Activation.AllowEdit
                            && uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.CellActivation == Activation.AllowEdit)
                        {
                            uGrid_Details.Rows[rowIdx].Cells[colIdx].Activate();
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                            return CellMoveState.Moved;
                        }
                    }
                }
            }
            return CellMoveState.MustJump;
        }

        /// <summary>
        /// 得意先切替グリッドに明細はクリア
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先切替グリッドに明細はクリアを行う。</br>
        /// <br>Programmer  : gezh</br>
        /// <br>Date        : 2013/04/02</br>
        /// </remarks>
        private void CustomerGridDetailClear()
        {
            // グリッドデータ削除
            if (!this.chkSearchingAll.Enabled)
            {
                ClearGrid();
            }
            this.AllExpand_Button.Enabled = false;
            this.chkSearchingAll.Enabled = true;
            // グリッドにスクロールバー売価率ラベルの制御
            ScrollControl();
            // グリッド列Hidden制御設定処理
            SetColumnHidden();
            // 明細グリッド値の記憶
            tempTable = ((DataTable)uGrid_Details.DataSource).Copy();
        }

        /// <summary>
        /// 商品切替グリッドに明細はクリア
        /// </summary>
        /// <remarks>
        /// <br>Note		: 商品切替グリッドに明細はクリアを行う。</br>
        /// <br>Programmer  : gezh</br>
        /// <br>Date        : 2013/04/02</br>
        /// </remarks>
        private void GoodGridDetailClear()
        {
            if (this.uGrid_Details.Rows.Count > 2 && _extrInfo != null)
            {
                this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                // グリッドデータ削除
                ClearGrid();
                this.AllExpand_Button.Enabled = false;
                // グリッドにスクロールバー売価率ラベルの制御
                ScrollControl();
                // 検索条件の保留
                this._searchDic.Clear();
                string name = string.Empty;
                int newColumnIndex = 1;
                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    foreach (int key in this._extrInfo.CustRateGrpCode)
                    {
                        this._searchDic.Add(key, newColumnIndex);

                        CellsCollection cells = uGrid_Details.Rows[0].Cells;

                        if (key < 0)
                        {
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        }
                        else
                        {
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("0000");
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        }

                        cells = uGrid_Details.Rows[1].Cells;
                        if (key < 0)
                        {
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = string.Empty;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = string.Empty;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = string.Empty;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        }
                        else
                        {
                            CustomerGIsExist(key.ToString(), ref name);
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        }
                        newColumnIndex++;
                    }
                }
                else
                {
                    foreach (int key in this._extrInfo.CustomerCode)
                    {
                        this._searchDic.Add(key, newColumnIndex);

                        CellsCollection cells = uGrid_Details.Rows[0].Cells;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("00000000");
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Activation = Activation.Disabled;

                        cells = uGrid_Details.Rows[1].Cells;
                        CustomerIsExist(key.ToString(), ref name);
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                        cells[COLUMN_UPRATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                        cells[COLUMN_SALERATE + newColumnIndex.ToString()].Activation = Activation.Disabled;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Appearance.ForeColorDisabled = Color.Black;
                        cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Activation = Activation.Disabled;

                        newColumnIndex++;
                    }
                }
                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            }
            else
            {
                DataTable dtTable = (DataTable)uGrid_Details.DataSource;
                for (int i = dtTable.Rows.Count; i > 2; i--)
                {
                    dtTable.Rows[i-1].Delete();
                }
                if (this.chkSearchingAll.Checked)
                {
                    this.chkSearchingAll.Checked = true;
                }
                uGrid_Details.DataSource = dtTable;
            }
        }

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void PMKHN09902UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            #region 画面検索条件部名称の設定
            switch (e.Tool.Key)
            {
                case "ButtonTool_Search": // 検索ボタン
                case "ButtonTool_CustomerChange":　// 得意先切替ボタン
                case "ButtonTool_GoodsChange": // 商品切替ボタン
                case "ButtonTool_RateChange": // 掛率切替ボタン
                    {
                        // 拠点名称
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            SetNameByCode(this.tEdit_SectionCodeAllowZero.Name, null);
                        }
                        // 仕入先名称
                        else if (this.tNedit_SupplierCd.Focused)
                        {
                            SetNameByCode(this.tNedit_SupplierCd.Name, null);
                        }
                        // メーカー名称
                        else if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            SetNameByCode(this.tNedit_GoodsMakerCd.Name, null);
                        }
                        // 商品掛率Ｇ名称
                        else if (this.tNedit_GoodsMGroup.Focused)
                        {
                            SetNameByCode(this.tNedit_GoodsMGroup.Name, null);
                        }
                        break;
                    }
            }
            #endregion　画面検索条件部名称の設定

            switch (e.Tool.Key)
            {
                #region 終了ボタン
                case "ButtonTool_Close":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        this._closeFlg = true;

                        // 終了処理
                        Close();
                        break;
                    }
                #endregion // 終了ボタン

                #region 保存ボタン
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        Save();
                        break;
                    }
                #endregion

                #region 検索ボタン
                case "ButtonTool_Search":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // 検索処理
                        int status = Search(false);
                        if (status != 0 && status != -1)
                        {
                            switch (status)
                            {
                                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                    {
                                        DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                            "検索条件に該当するデータが存在しません。\r\n掛率の新規追加を行いますか？",
                                            status,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button1);

                                        // グリッドクリア
                                        ClearGrid();
                                        // グリッドにスクロールバー売価率ラベルの制御
                                        ScrollControl();

                                        switch (res)
                                        {
                                            case DialogResult.Yes:
                                                {
                                                    this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                                    // 検索条件保留
                                                    _searchDic.Clear();
                                                    this.chkSearchingAll.Enabled = false;
                                                    string name = string.Empty;
                                                    int newColumnIndex = 1;
                                                    // 得意先掛率Ｇ検索条件の制御
                                                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                                                    {
                                                        foreach (int key in this._extrInfo.CustRateGrpCode)
                                                        {
                                                            this._searchDic.Add(key, newColumnIndex);

                                                            CellsCollection cells = uGrid_Details.Rows[0].Cells;

                                                            // 得意先掛率Ｇコード
                                                            if (key < 0)
                                                            {
                                                                cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                                                                cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                                                                cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = ALL_CUST_RATE_GRP;   // HACK:"ALL"
                                                            }
                                                            else
                                                            {
                                                                cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                                                                cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("0000");
                                                                cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("0000");
                                                            }

                                                            // 得意先掛率Ｇ名称
                                                            cells = uGrid_Details.Rows[1].Cells;
                                                            if (key < 0)
                                                            {
                                                                cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = string.Empty;
                                                                cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = string.Empty;
                                                                cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = string.Empty;
                                                            }
                                                            else
                                                            {
                                                                CustomerGIsExist(key.ToString(), ref name);
                                                                cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                                                                cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                                                                cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;
                                                            }
                                                            newColumnIndex++;
                                                        }
                                                    }
                                                    // 得意先検索条件の制御
                                                    else
                                                    {
                                                        foreach (int key in this._extrInfo.CustomerCode)
                                                        {
                                                            this._searchDic.Add(key, newColumnIndex);

                                                            // 得意先コード
                                                            CellsCollection cells = uGrid_Details.Rows[0].Cells;
                                                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                                                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = key.ToString("00000000");
                                                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = key.ToString("00000000");

                                                            // 得意先名称
                                                            cells = uGrid_Details.Rows[1].Cells;
                                                            CustomerIsExist(key.ToString(), ref name);
                                                            cells[COLUMN_UPRATE + newColumnIndex.ToString()].Value = name;
                                                            cells[COLUMN_SALERATE + newColumnIndex.ToString()].Value = name;
                                                            cells[COLUMN_GRSPROFITSECURERAT + newColumnIndex.ToString()].Value = name;

                                                            newColumnIndex++;
                                                        }
                                                    }
                                                    // 表示行のグレーアウト、表示しない行のhidden制御
                                                    for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
                                                    {
                                                        if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[i].Value.ToString()))
                                                        {
                                                            this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                                            this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                                            this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                                            this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                                            this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                                            this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                                                        }
                                                        else
                                                        {
                                                            this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden = true;
                                                        }
                                                    }
                                                    if (this._goodsMode == GoodsMode.GoodsRateRank) 
                                                    {
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATERANK].Hidden = false;
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATERANK].Hidden = false;
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Groups[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                                                        this.uGrid_Details.DisplayLayout.Bands[0].Columns[COLUMN_GOODSRATEGRPCODE].Hidden = true;
                                                    }
                                                    this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                                    // 明細グリッド値の記憶
                                                    tempTable = ((DataTable)uGrid_Details.DataSource).Copy();
                                                    // 行追加
                                                    this.addRemberFlg = false;
                                                    this.Add_Button_Click(this.Add_Button, new EventArgs());
                                                    this.addRemberFlg = true;

                                                    break;
                                                }
                                            case DialogResult.No:
                                                {
                                                    // 明細グリッド値の記憶
                                                    tempTable = ((DataTable)uGrid_Details.DataSource).Copy();
                                                    this.chkSearchingAll.Enabled = true;
                                                    this.chkSearchingAll.Checked = false;
                                                    this._inputCustomerDic.Clear();
                                                    this.AdjustButtonEnable(0, false);
                                                    this.AdjustButtonEnable(2, false);
                                                    this.AdjustButtonEnable(3, true);
                                                    break;
                                                }
                                        }
                                        // 検索データがない場合には、全展開ボタン押下不可
                                        this.AllExpand_Button.Enabled = false;
                                        // グリッド列Hidden制御設定処理
                                        SetColumnHidden();
                                        break;
                                    }
                                default:
                                    {
                                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                                       "Search",
                                                       "検索処理に失敗しました。",
                                                       status,
                                                       MessageBoxButtons.OK);

                                        // グリッドクリア
                                        ClearGrid();

                                        // グリッド列Hidden制御設定処理
                                        SetColumnHidden();

                                        AdjustButtonEnable(2, false);
                                        break;
                                    }
                            }
                        }

                        break;
                    }
                #endregion 検索ボタン

                #region クリアボタン
                case "ButtonTool_Undo":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // クリア処理
                        ClearScreen();
                        break;
                    }
                #endregion

                #region 最新情報ボタン
                case "ButtonTool_Renewal":
                    {
                        // マスタ読込
                        ReadSecInfoSet();
                        ReadSupplier();
                        ReadMakerUMnt();
                        ReadGoodsGroupU();
                        ReadCustomerSearchRet();
                        ReadCustRateGrp();
                        ReadBLGoodsCdUMnt();
                        ReadBLGroupU();
                        ReadUserGuide();

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "最新情報を取得しました。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                        break;
                    }
                #endregion

                #region ガイドボタン
                case "ButtonTool_Guide":
                    {
                        // ガイド起動処理
                        bool flag = false;
                        if (Form1_Top_Panel.ContainsFocus)
                        {
                            foreach (Control ctrl in Form1_Top_Panel.Controls)
                            {
                                if (ctrl.ContainsFocus)
                                {
                                    switch (ctrl.Name)
                                    {
                                        // 拠点
                                        case "tEdit_SectionCodeAllowZero":
                                        case "SectionGuide_Button":
                                            {
                                                this.SectionGuide_Button_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
                                                flag = true;
                                                break;
                                            }
                                        // 仕入先
                                        case "tNedit_SupplierCd":
                                        case "SupplierGuide_Button":
                                            {
                                                this.SupplierGuide_Button_Click(this.tNedit_SupplierCd, new EventArgs());
                                                flag = true;
                                                break;
                                            }
                                        // 商品掛率Ｇ
                                        case "tNedit_GoodsMGroup":
                                        case "GoodsRateGrpGuide_Button":
                                            {
                                                this.GoodsRateGrpGuide_Button_Click(this.tNedit_GoodsMGroup, new EventArgs());
                                                flag = true;
                                                break;
                                            }
                                        // メーカー
                                        case "tNedit_GoodsMakerCd":
                                        case "MakerGuide_Button":
                                            {
                                                this.MakerGuide_Button_Click(this.tNedit_GoodsMakerCd, new EventArgs());
                                                flag = true;
                                                break;
                                            }
                                    }
                                    if (flag)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Control ctrl in panel_Detail.Controls)
                            {
                                if (ctrl.ContainsFocus)
                                {
                                    switch (ctrl.Name)
                                    {
                                        // 得意先条件入力部
                                        case "uGrid_Details":
                                            {
                                                // 新規行のガイド制御
                                                if (this.uGrid_Details.ActiveCell.Row.Index != 0 && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                                                {
                                                    // BLコード
                                                    if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_BLCD)
                                                    {
                                                        try
                                                        {
                                                            this.Cursor = Cursors.WaitCursor;

                                                            int status;
                                                            BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                                                            // BLコードガイド表示
                                                            status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                                                            if (status == 0)
                                                            {
                                                                this.uGrid_Details.ActiveCell.Value = blGoodsCdUMnt.BLGoodsCode.ToString("00000");
                                                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[COLUMN_NAME].Value = blGoodsCdUMnt.BLGoodsHalfName;
                                                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                                            }
                                                        }
                                                        finally
                                                        {
                                                            this.Cursor = Cursors.Default;
                                                        }
                                                    }
                                                    // 商品掛率Ｇ
                                                    else if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GOODSRATEGRPCODE)
                                                    {
                                                        try
                                                        {
                                                            this.Cursor = Cursors.WaitCursor;

                                                            GoodsGroupU goodsGroupU;

                                                            // 商品掛率Ｇガイド表示
                                                            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                                                            if (status == 0)
                                                            {
                                                                this.uGrid_Details.ActiveCell.Value = goodsGroupU.GoodsMGroup.ToString("0000");
                                                                if (string.IsNullOrEmpty(this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[COLUMN_BLCD].Value.ToString()))
                                                                {
                                                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[COLUMN_NAME].Value = goodsGroupU.GoodsMGroupName.Trim();
                                                                }
                                                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                                            }
                                                        }
                                                        finally
                                                        {
                                                            this.Cursor = Cursors.Default;
                                                        }
                                                    }
                                                    // メーカー
                                                    else if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_MAKERCODE)
                                                    {
                                                        try
                                                        {
                                                            this.Cursor = Cursors.WaitCursor;

                                                            MakerUMnt makerUMnt;

                                                            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                                                            if (status == 0)
                                                            {
                                                                this.uGrid_Details.ActiveCell.Value = makerUMnt.GoodsMakerCd.ToString("0000");
                                                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                                            }
                                                        }
                                                        finally
                                                        {
                                                            this.Cursor = Cursors.Default;
                                                        }
                                                    }
                                                    // ＢＬグループコード
                                                    else if (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GLCD)
                                                    {
                                                        try
                                                        {
                                                            this.Cursor = Cursors.WaitCursor;

                                                            int status;
                                                            BLGroupU blGroupU = new BLGroupU();

                                                            // BLグループガイド表示
                                                            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                                                            if (status == 0)
                                                            {
                                                                this.uGrid_Details.ActiveCell.Value = blGroupU.BLGroupCode.ToString("00000");
                                                                this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[COLUMN_NAME].Value = blGroupU.BLGroupName;
                                                                this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                                            }
                                                        }
                                                        finally
                                                        {
                                                            this.Cursor = Cursors.Default;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // なし
                                                    }
                                                }
                                                else
                                                {
                                                    // 得意先条件入力部のガイド制御
                                                    if (CustomerSearchMode.CustomerRateG == this._customerSearchMode)
                                                    {
                                                        // TODO
                                                        this.Cursor = Cursors.WaitCursor;

                                                        int status;
                                                        UserGdHd userGdHd;
                                                        UserGdBd userGdBd;

                                                        status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);

                                                        if (status == 0)
                                                        {
                                                            this.uGrid_Details.ActiveCell.Value = userGdBd.GuideCode.ToString("0000");
                                                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Cursor = Cursors.WaitCursor;
                                                        PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                                                        customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

                                                        DialogResult result = customerSearchForm.ShowDialog(this);

                                                        flag = true;

                                                        if ((int)result == 1)
                                                        {
                                                            this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                                        }
                                                    }
                                                }
                                                flag = true;
                                                break;
                                            }
                                    }

                                    if (flag)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region PDF出力ボタン
                case "ButtonTool_PDF":
                    {
                        // データ変更した場合、PDF出力できません
                        if (CompareOriginalScreen() == false)
                        {
                            return;
                        }

                        this.OutputPDF();
                        break;
                    }
                #endregion 

                #region テキスト出力ボタン
                case "ButtonTool_ExtractText":
                    {
                        // データ変更した場合、TEXT出力できません
                        if (CompareOriginalScreen() == false)
                        {
                            return;
                        }

                        this.ExportIntoCSVData();
                        System.Environment.CurrentDirectory = _GetDirectoryName;
                        break;
                    }
                #endregion

                #region EXCEL出力ボタン
                case "ButtonTool_ExtractExcel":
                    {
                        // データ変更した場合、Excel出力できません
                        if (CompareOriginalScreen() == false)
                        {
                            return;
                        }

                        this.ExportIntoExcelData();
                        System.Environment.CurrentDirectory = _GetDirectoryName;
                        break;
                    }
                #endregion

                #region 得意先切替ボタン
                case "ButtonTool_CustomerChange":
                    {
                        // 画面情報比較
                        if (!CompareOriginalScreen())
                        {
                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                              "",
                                                              0,
                                                              MessageBoxButtons.YesNoCancel,
                                                              MessageBoxDefaultButton.Button1);

                            switch (res)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        int status = SaveProc(true);
                                        if (status != 0)
                                        {
                                            return;
                                        }
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        // Gridのデータ取得
                                        DataTable dtTblSrc = (DataTable)this.uGrid_Details.DataSource;

                                        int i = 0;
                                        // 変更前データ再度設定
                                        for (i = 2; i < tempTable.Rows.Count; i++)
                                        {
                                            dtTblSrc.Rows[i].ItemArray = tempTable.Rows[i].ItemArray;
                                        }

                                        if (dtTblSrc.Rows.Count > tempTable.Rows.Count)
                                        {
                                            for (i = tempTable.Rows.Count; i < dtTblSrc.Rows.Count; i++)
                                            {
                                                // 仕入率から、空になります
                                                for (int j = 9; j < dtTblSrc.Columns.Count; j++)
                                                {
                                                    dtTblSrc.Rows[i][j] = DBNull.Value;
                                                }
                                                dtTblSrc.Rows[i][COLUMN_PARENTDIV] = -1 ;// 新追加行の親子区分の初期値が「-1」を設定する
                                            }
                                        }

                                        // 更新
                                        uGrid_Details.UpdateData();

                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        return;
                                    }
                            }
                        }
                        // グリッドに明細はクリア
                        CustomerGridDetailClear();
                        this.CustomerChange();
                        AdjustButtonEnable(2, false);
                        break;
                    }
                #endregion 得意先切替ボタン

                #region 商品切替ボタン
                case "ButtonTool_GoodsChange":
                    {
                        // 画面情報比較
                        if (!CompareOriginalScreen())
                        {
                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                              "",
                                                              0,
                                                              MessageBoxButtons.YesNoCancel,
                                                              MessageBoxDefaultButton.Button1);

                            switch (res)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        int status = SaveProc(true);
                                        if (status != 0)
                                        {
                                            return;
                                        }
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        // Gridのデータ取得
                                        DataTable dtTblSrc = (DataTable)this.uGrid_Details.DataSource;

                                        int i = 0;
                                        // 変更前データ再度設定
                                        for (i = 2; i < tempTable.Rows.Count; i++)
                                        {
                                            dtTblSrc.Rows[i].ItemArray = tempTable.Rows[i].ItemArray;
                                        }

                                        if (dtTblSrc.Rows.Count > tempTable.Rows.Count)
                                        {
                                            for (i = tempTable.Rows.Count; i < dtTblSrc.Rows.Count; i++)
                                            {
                                                // 仕入率から、空になります
                                                for (int j = 9; j < dtTblSrc.Columns.Count; j++)
                                                {
                                                    dtTblSrc.Rows[i][j] = DBNull.Value;
                                                }
                                                dtTblSrc.Rows[i][COLUMN_PARENTDIV] = -1;// 新追加行の親子区分の初期値が「-1」を設定する
                                            }
                                        }

                                        // 更新
                                        uGrid_Details.UpdateData();

                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        return;
                                    }
                            }
                        }
                        // グリッドに明細はクリア
                        GoodGridDetailClear();
                        // 明細グリッド値の記憶
                        tempTable = ((DataTable)uGrid_Details.DataSource).Copy();
                        this.GoodsChange();
                        AdjustButtonEnable(2, false);
                        break;
                    }
                #endregion 商品切替ボタン

                #region 掛率切替ボタン
                case "ButtonTool_RateChange":
                    {
                        // 画面情報比較
                        if (!CompareOriginalScreen())
                        {
                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                              "",
                                                              0,
                                                              MessageBoxButtons.YesNoCancel,
                                                              MessageBoxDefaultButton.Button1);

                            switch (res)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        int status = SaveProc(true);
                                        if (status != 0)
                                        {
                                            return;
                                        }
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        // Gridのデータ取得
                                        DataTable dtTblSrc = (DataTable)this.uGrid_Details.DataSource;

                                        int i = 0;
                                        // 変更前データ再度設定
                                        for(i = 2; i < tempTable.Rows.Count; i++)
                                        {
                                            dtTblSrc.Rows[i].ItemArray = tempTable.Rows[i].ItemArray;
                                        }

                                        if (dtTblSrc.Rows.Count > tempTable.Rows.Count)
                                        {
                                            for (i = tempTable.Rows.Count; i < dtTblSrc.Rows.Count; i++)
                                            {
                                                dtTblSrc.Rows[i][COLUMN_PARENTDIV] = -1;// 新追加行の親子区分の初期値が「-1」を設定する
                                            }
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>
                                        // セル設定色再設定
                                        foreach(UltraGridRow row in this.uGrid_Details.Rows)
                                        {
                                            // 検索条件行と新追加行再設定なし
                                            if (row.Index < 2 || row.Index >= this._displayList.Count + 2)
                                            {
                                                continue;
                                            }
                                            foreach (UltraGridCell rowCell in row.Cells)
                                            {
                                                // 色設定変更なし列再設定なし
                                                if (!rowCell.Column.Key.Contains(COLUMN_COSTRATE)
                                                    && (!rowCell.Column.Key.Contains(COLUMN_SALERATE))
                                                    && (!rowCell.Column.Key.Contains(COLUMN_UPRATE))
                                                    && (!rowCell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
                                                {
                                                    continue;
                                                }
                                                // セル表示文字色再設定
                                                if(this._cellIniSettingColorDic.ContainsKey(row.Index))
                                                {
                                                    if (this._cellIniSettingColorDic[row.Index].ContainsKey(rowCell.Column.Key))
                                                    {
                                                        rowCell.Appearance.ForeColor = this._cellIniSettingColorDic[row.Index][rowCell.Column.Key];
                                                    }
                                                }
                                                
                                            }
                                        }
                                        // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                                        // 更新
                                        uGrid_Details.UpdateData();

                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        return;
                                    }
                            }
                        }

                        this.RateChange();

                        break;
                    }
                #endregion 掛率切替ボタン
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            // 得意先コード設定
            this.uGrid_Details.ActiveCell.Value = customerSearchRet.CustomerCode.ToString("00000000"); ;
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());

                    // フォーカス設定
                    this.tNedit_SupplierCd.Focus();
                    this.AdjustButtonEnable(1, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Supplier supplier;

                int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                if (status == 0)
                {
                    this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                    this.tEdit_SupplierName.DataText = GetSupplierName(supplier.SupplierCd);

                    // フォーカス設定
                    this.tNedit_GoodsMakerCd.Focus();
                    this.AdjustButtonEnable(1, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 商品掛率Ｇガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GoodsGroupU goodsGroupU;

                int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                    this.tEdit_GoodsRateGrpName.DataText = GetGoodsGroupName(goodsGroupU.GoodsMGroup);

                    // フォーカス設定
                    uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Activate();
                    uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    this.AdjustButtonEnable(1, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                    this.tEdit_MakerName.DataText = GetMakerName(makerUMnt.GoodsMakerCd);

                    // フォーカス設定
                    this.tNedit_GoodsMGroup.Focus();
                    this.AdjustButtonEnable(1, true);
                }
            }
            finally
            {
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    this.uLabel_Message.Text = MSG_MAKERNOINTPUT;
                }
                else
                {
                    this.uLabel_Message.Text = string.Empty;
                }

                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void Expand_Button_Click(object sender, EventArgs e)
        {
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else if ((this.uGrid_Details.Selected.Rows != null) &&
                (this.uGrid_Details.Selected.Rows.Count > 0))
            {
                rowIndex = this.uGrid_Details.Selected.Rows[0].Index;
            }
            else if ((0 != _prevActiveUltraGridCellRow) && (0 != _prevActiveUltraGridCellCol))
            {
                // 前回ActiveCell行
                rowIndex = _prevActiveUltraGridCellRow;
            }
            else
            {
                return;
            }

            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            int parentRowIndex = 0;

            ArrayList childIndexList = null;

            if (IntObjToInt(cells[COLUMN_PARENTDIV].Value) == 0)
            {
                // 親明細

                parentRowIndex = rowIndex;
            }
            else
            {
                // 子明細
                foreach (int parentIndex in this._parentChildIndexDic.Keys)
                {
                    childIndexList = (ArrayList)this._parentChildIndexDic[parentIndex];

                    if (childIndexList.Contains(rowIndex))
                    {
                        parentRowIndex = parentIndex;
                        break;
                    }
                }
            }

            if (this._parentChildIndexDic.ContainsKey(parentRowIndex))
            {
                childIndexList = (ArrayList)this._parentChildIndexDic[parentRowIndex];
            }

            if (childIndexList != null)
            {
                bool expandFlg = BoolObjToBool(cells[COLUMN_EXPANDFLG].Value);
                if (expandFlg)
                {
                    // 圧縮
                    foreach (int childIndex in childIndexList)
                    {
                        this.uGrid_Details.Rows[childIndex].Hidden = true;
                        this.uGrid_Details.Rows[childIndex].Cells[COLUMN_EXPANDFLG].Value = false;
                    }
                    this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value = false;
                }
                else
                {
                    // 展開
                    foreach (int childIndex in childIndexList)
                    {
                        this.uGrid_Details.Rows[childIndex].Hidden = false;
                        this.uGrid_Details.Rows[childIndex].Cells[COLUMN_EXPANDFLG].Value = true;
                    }
                    this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value = true;
                }
            }

            this.uGrid_Details.UpdateData();

            // グリッドにスクロールバー売価率ラベルの制御
            ScrollControl();

            // フォーカス設定
            //this.uGrid_Details.ActiveRow = null;
            //this.Expand_Button.Focus();
            if ((0 != _prevActiveUltraGridCellRow) && (0 != _prevActiveUltraGridCellCol))
            {
                this.uGrid_Details.Rows[_prevActiveUltraGridCellRow].Cells[_prevActiveUltraGridCellCol].Activate();
                if (this.uGrid_Details.Rows[_prevActiveUltraGridCellRow].Cells[_prevActiveUltraGridCellCol].Activation == Activation.AllowEdit)
                {

                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 全展開ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void AllExpand_Button_Click(object sender, EventArgs e)
        {
            // 全展開ボタンを押す、展開ボタンを押す全部行を圧縮時、_prevAllExpand値を変更
            if (this.uGrid_Details.ActiveCell != null)
            {
                bool flag = false;
                foreach (int parentRowIndex in this._parentChildIndexDic.Keys)
                {
                    if (BoolObjToBool(this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value) != _prevAllExpand)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        _prevAllExpand = !_prevAllExpand;
                    }
                }
            }

            foreach (int parentRowIndex in this._parentChildIndexDic.Keys)
            {
                this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value = !this._prevAllExpand;

                // 子明細行インデックスリスト取得
                ArrayList childRowIndexList = (ArrayList)this._parentChildIndexDic[parentRowIndex];

                if (childRowIndexList == null)
                {
                    continue;
                }

                foreach (int childRowIndex in childRowIndexList)
                {
                    this.uGrid_Details.Rows[childRowIndex].Hidden = this._prevAllExpand;
                    this.uGrid_Details.Rows[childRowIndex].Cells[COLUMN_EXPANDFLG].Value = !this._prevAllExpand;
                }
            }
            this.uGrid_Details.UpdateData();

            this._prevAllExpand = !this._prevAllExpand;

            // グリッドにスクロールバー売価率ラベルの制御
            ScrollControl();

            // フォーカス設定
            this.uGrid_Details.ActiveRow = null;
            this.AllExpand_Button.Focus();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 行追加ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void Add_Button_Click(object sender, EventArgs e)
        {
            uGrid_Details.BeginUpdate();

            // 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
            if (this.addRemberFlg && this.chkSearchingAll.Enabled)
            {
                _inputCustomerDic.Clear();
                for (int i = 10; i < 310; i++)
                {
                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[i].Value.ToString()) && this.uGrid_Details.Rows[0].Cells[i].Value.ToString() != ALL_CUST_RATE_GRP)
                    {
                        string customerKey = this._customerSearchMode.ToString() + "-" + this.chkSearchingAll.Checked.ToString() + "-" + i.ToString();
                        if (!this._inputCustomerDic.ContainsKey(customerKey))
                        {
                            this._inputCustomerDic.Add(customerKey, this.uGrid_Details.Rows[0].Cells[i].Value.ToString());
                        }
                        else
                        {
                            this._inputCustomerDic[customerKey] = this.uGrid_Details.Rows[0].Cells[i].Value.ToString();
                        }
                    }
                }
                Dictionary<string, string> tempDic = new Dictionary<string, string>(this._inputCustomerDic);
                // 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
                SetNewRowCustColumnHidden();
                // 前回記憶検索条件のクリア
                this._inputCustomerDic.Clear();
                this._inputCustomerDic = new Dictionary<string, string>(tempDic);
            }
            else
            {
                // 行追加ボタン押下、得意先＆得意先掛率G未入力の列を非表示にする
                SetNewRowCustColumnHidden();
            }
            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            // 行追加
            UltraGridRow row = this.uGrid_Details.DisplayLayout.Bands[0].AddNew();

            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);

            CellsCollection cells = row.Cells;
            // No
            cells[COLUMN_NO].Value = this.uGrid_Details.Rows.Count - 2;
            for (int index = 1; index < cells.Count; index++)
            {
                cells[index].Activation = Activation.AllowEdit;
            }
            if (tNedit_GoodsMakerCd.GetInt() != 0)
            {
                cells[COLUMN_MAKERCODE].Value = tNedit_GoodsMakerCd.Text.Trim();
            }
            cells[COLUMN_SUPPLIERCODE].Value =StrObjToInt(this.tNedit_SupplierCd.Text);
            cells[COLUMN_PARENTDIV].Value = -1;// 新追加行の親子区分の初期値が「-1」を設定する
            uGrid_Details.EndUpdate();

            // 行追加の場合、ボタン制御
            AdjustButtonEnable(0, false);
            AdjustButtonEnable(2, false);
            AdjustButtonEnable(3, true);
            // 行追加後で、フォカス設定
            this.uGrid_Details.Enter -= new System.EventHandler(this.uGrid_Details_Enter);
            this.uGrid_Details.Focus();
            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
            if (this._goodsMode == GoodsMode.GoodsRateG)
            {
                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_GOODSRATEGRPCODE].Activate();
            }
            else
            {
                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_GOODSRATERANK].Activate();
            }
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            this.uGrid_Details.Enter += new System.EventHandler(this.uGrid_Details_Enter);
            // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>>>
            // 新追加行明細グリッド値記憶
            if (this._newAddRowTempTable.Rows.Count == 0)
            {
                this._newAddRowTempTable = ((DataTable)uGrid_Details.DataSource).Copy();
            }
            else
            {
                DataRow newAddRow = this._newAddRowTempTable.NewRow();
                newAddRow[COLUMN_NO] = this.uGrid_Details.Rows.Count - 2;
                this._newAddRowTempTable.Rows.Add(newAddRow);
            }
            // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<<
        }

        /// <summary>
        /// 行削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントセル</param>
        /// <remarks>
        /// <br>Note        : Delete_Button_Click</br>
        /// <br>Programmer  : 董桂鈺</br>
        /// <br>Date        : 2013/04/02</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            int activeRowIndex = 0;
            // 行番号取得
            if (this.uGrid_Details.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return;
            }
            if ( activeRowIndex >= this._displayList.Count + 2)　// 新追加行の判定
            {
                int beforeDeleteRowCount = this.uGrid_Details.Rows.Count; // 削除前総行数
                string activeColumnName = string.Empty;
                if (this.uGrid_Details.ActiveCell != null)
                {
                    activeColumnName = this.uGrid_Details.ActiveCell.Column.Key;
                }
                else
                {
                    if (this._goodsMode == GoodsMode.GoodsRateG)
                    {
                        activeColumnName = COLUMN_GOODSRATEGRPCODE;
                    }
                    else
                    {
                        activeColumnName = COLUMN_GOODSRATERANK;
                    }
                }
                this.uGrid_Details.BeginUpdate();
                this.uGrid_Details.Rows[activeRowIndex].Delete(); // 新追加行の削除
                // 保存画面グリッド明細データのDataTableに、削除行も削除します
                if (tempTable.Rows.Count > activeRowIndex
                    && this.uGrid_Details.Rows.Count < beforeDeleteRowCount )
                {
                    tempTable.Rows[activeRowIndex].Delete();
                    // 削除行以下の行のNo列の値の変更
                    for (int tempTableIndex = activeRowIndex; tempTableIndex < tempTable.Rows.Count; tempTableIndex++)
                    {
                        tempTable.Rows[tempTableIndex][COLUMN_NO] = IntObjToInt(tempTable.Rows[tempTableIndex][COLUMN_NO]) - 1;
                    }
                }
                // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>>>
                // 新追加行明細グリッド値記憶のDataTableに、削除行も削除します
                if (this._newAddRowTempTable.Rows.Count > (activeRowIndex - this._displayList.Count ))
                {
                    this._newAddRowTempTable.Rows[activeRowIndex - this._displayList.Count ].Delete();
                    // 削除行以下の行のNo列の値の変更
                    for (int tempTableIndex = (activeRowIndex - this._displayList.Count); tempTableIndex < this._newAddRowTempTable.Rows.Count; tempTableIndex++)
                    {
                        this._newAddRowTempTable.Rows[activeRowIndex - this._displayList.Count ][COLUMN_NO] = 
                                       IntObjToInt(this._newAddRowTempTable.Rows[activeRowIndex - this._displayList.Count ][COLUMN_NO]) - 1;
                    }
                }
                // セル初期設定色Dicに、削除行も削除します
                if (this._cellIniSettingColorDic.ContainsKey(activeRowIndex))
                {
                    this._cellIniSettingColorDic.Remove(activeRowIndex);
                    // セル初期設定色Dicに、削除行以下の行の行番号の変更
                    Dictionary<int, Dictionary<string, Color>> tempCellIniSetColerDic = new Dictionary<int, Dictionary<string, Color>>(); // 記録削除行以下の行セル初期設定色
                    foreach (int rowIndex in this._cellIniSettingColorDic.Keys)
                    {
                        if (rowIndex > activeRowIndex) // 記録削除行以下の行の判断
                        {
                            if (!tempCellIniSetColerDic.ContainsKey(rowIndex))
                            {
                                tempCellIniSetColerDic.Add(rowIndex, this._cellIniSettingColorDic[rowIndex]);
                            }
                        }
                    }
                    // 削除行以下の行の行番号の変更
                    foreach (int rowIndex in tempCellIniSetColerDic.Keys)
                    {
                        this._cellIniSettingColorDic.Remove(rowIndex);
                        int updateRowIndex = rowIndex - (rowIndex - activeRowIndex);
                        this._cellIniSettingColorDic.Add(updateRowIndex, tempCellIniSetColerDic[rowIndex]);
                    }
                }
                // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<<<
                this.uGrid_Details.Enter -= new System.EventHandler(this.uGrid_Details_Enter);
                this.uGrid_Details.Focus();　// グリッドにフォーカスを取得します
                this.uGrid_Details.Enter += new System.EventHandler(this.uGrid_Details_Enter);
                // 削除行は画面の最後行です
                if (activeRowIndex == this.uGrid_Details.Rows.Count
                    && this.uGrid_Details.Rows.Count < beforeDeleteRowCount)
                {
                    // 既存行がない場合
                    if (activeRowIndex == 2)
                    {
                        this.uGrid_Details.Rows[1].Activate();
                        this.uGrid_Details.EndUpdate();
                        return;
                    }
                    // 商品掛率Ｇの場合
                    if (this._goodsMode == GoodsMode.GoodsRateG)
                    {
                        for (int viewRowIndex = 1; viewRowIndex < activeRowIndex; viewRowIndex++)
                        {
                            if (!this.uGrid_Details.Rows[activeRowIndex - viewRowIndex].Hidden)
                            {
                                this.uGrid_Details.Rows[activeRowIndex - viewRowIndex].Cells[COLUMN_GOODSRATEGRPCODE].Activate();
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    // 層別の場合
                    else
                    {
                        this.uGrid_Details.BeginUpdate();
                        for (int viewRowIndex = 1; viewRowIndex < activeRowIndex; viewRowIndex++)
                        {
                            if (!this.uGrid_Details.Rows[activeRowIndex - viewRowIndex].Hidden)
                            {
                                this.uGrid_Details.Rows[activeRowIndex - viewRowIndex].Cells[COLUMN_GOODSRATERANK].Activate();
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    // 削除行の先行も新追加行の場合には、編集可を設定します
                    if (activeRowIndex - 1 >= this._displayList.Count + 2)
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    // 削除行の先行は既存行の場合には、画面変更を比べって、メニューに出力ボタン制御を設定します
                    else
                    {
                        // 画面変更なし
                        if (CompareOriginalScreen())
                        {
                            // 出力操作可
                            this.AdjustButtonEnable(2, true);
                        }
                        // 画面変更あり
                        else
                        {
                            // 出力操作不可
                            this.AdjustButtonEnable(2, false);
                        }
                    }
                    
                }
            　　// 削除は画面の最後行ではありません
                else if (activeRowIndex < this.uGrid_Details.Rows.Count
                        && this.uGrid_Details.Rows.Count < beforeDeleteRowCount)
                {
                    // 商品掛率Ｇの場合
                    if (this._goodsMode == GoodsMode.GoodsRateG)
                    {
                        this.uGrid_Details.Rows[activeRowIndex].Cells[COLUMN_GOODSRATEGRPCODE].Activate();
                    }
                    // 層別の場合
                    else
                    {
                        this.uGrid_Details.Rows[activeRowIndex].Cells[COLUMN_GOODSRATERANK].Activate();
                    }
                    // 編集可を設定します
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    // 削除行以下の行のNo列の値の変更
                    for (int index = activeRowIndex; index < this.uGrid_Details.Rows.Count; index++)
                    {
                        this.uGrid_Details.Rows[index].Cells[COLUMN_NO].Value = IntObjToInt(this.uGrid_Details.Rows[index].Cells[COLUMN_NO].Value) - 1;
                    }
                }
                else if (this.uGrid_Details.Rows.Count == beforeDeleteRowCount)
                {
                    this.uGrid_Details.Rows[activeRowIndex].Activate();
                    this.uGrid_Details.Rows[activeRowIndex].Cells[activeColumnName].Activate();
                    // 編集可を設定します
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            this.uGrid_Details.EndUpdate();
        }

        /// <summary>
        /// uGrid_Details_CellChangeイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントセル</param>
        /// <remarks>
        /// <br>Note       : uGrid_Details_CellChange</br>
        /// <br>Programmer  : 董桂鈺</br>
        /// <br>Date        : 2013/03/27</br>
        /// <br>Update Note : 2013/04/19 donggy</br>
        /// <br>管理番号    : 10901273-00 </br>
        /// <br>              Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
        /// <br>　　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Row.Index > 1　// 非得意先検索条件と得意先検索条件名称行判断
                && e.Cell.Row.Index < this._displayList.Count + 2　// 非新追加行判断
                && e.Cell.DataChanged)　// セル値変更の判断
            {
                if (DoubleObjToDouble(e.Cell.Text) 
                    != DoubleObjToDouble(tempTable.Rows[e.Cell.Row.Index][e.Cell.Column.Index]))　// 新入力値が前回値と比較する
                {
                    AdjustButtonEnable(2, false);　// 新入力値は前回値と違い時、PDF、EXCEL、テキスト出力不可を設定する 
                }
                else
                {
                    AdjustButtonEnable(2, true);　// 新入力値は前回値と同じ時、PDF、EXCEL、テキスト出力可を設定する
                }
            }

            #region 新追加行入力した商品情報を変更するかどうかの判断
            if (e.Cell.Row.Index >= this._displayList.Count + 2　// 新追加行判断
                && e.Cell.DataChanged　　// セル値変更の判断
                && e.Cell.Column.Index < 9
                && e.Cell.Column.Index > 0)
            {
                string searchKey = e.Cell.Row.Index.ToString() + "-" + this._goodsMode.ToString() + "-" + e.Cell.Column.Key;

                //  新追加行商品情報変更あり
                if (StrObjToStr(e.Cell.Text) != StrObjToStr(e.Cell.Value))
                {
                    if (!this._inputGoodsInfoDic.ContainsKey(searchKey))
                    {
                        this._inputGoodsInfoDic.Add(searchKey, true);
                    }
                    else
                    {
                        this._inputGoodsInfoDic[searchKey] = true;
                    }
                }
                //  新追加行商品情報変更なし
                else
                {
                    if (this._inputGoodsInfoDic.ContainsKey(searchKey))
                    {
                        this._inputGoodsInfoDic[searchKey] = false;
                    }
                    else
                    {
                        this._inputGoodsInfoDic.Add(searchKey, false);
                    }
                }
            }
            #endregion　新追加行入力した商品情報を変更するかどうかの判断

            // --- ADD donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>
            // 文字表示色設定
            if (this.tEdit_SectionCodeAllowZero.Text.Trim() == ctSectionCode)
            {
                return; // 全社拠点のデータが文字表示色設定なし
            }
            if (e.Cell.Row.Index > 1　// 非得意先検索条件と得意先検索条件名称行判断
                && e.Cell.DataChanged )　// セル値変更の判断
            {
                // 掛率列判断
                if(!e.Cell.Column.Key.Contains(COLUMN_COSTRATE)
                    && (!e.Cell.Column.Key.Contains(COLUMN_SALERATE))
                    && (!e.Cell.Column.Key.Contains(COLUMN_UPRATE))
                    && (!e.Cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
                {
                    return; // 非掛率列設定なし
                }
                // 非新追加行
                if (e.Cell.Row.Index < this._displayList.Count + 2)
                {
                    if (DoubleObjToDouble(e.Cell.Text) != DoubleObjToDouble(tempTable.Rows[e.Cell.Row.Index][e.Cell.Column.Key]))
                    {
                        e.Cell.Appearance.ForeColor = Color.Black; // 黒字設定
                    }
                    else
                    {
                        // 文字表示色設定
                        if (this._cellIniSettingColorDic.ContainsKey(e.Cell.Row.Index)
                            && this._cellIniSettingColorDic[e.Cell.Row.Index].ContainsKey(e.Cell.Column.Key)
                            && this._cellIniSettingColorDic[e.Cell.Row.Index][e.Cell.Column.Key] == Color.Red)
                        {
                            e.Cell.Appearance.ForeColor = Color.Red; // 赤字設定 
                            
                        }
                    }
                }
                // 新追加行
                else
                {
                    if (this._newAddRowTempTable.Rows.Count > ( e.Cell.Row.Index - this._displayList.Count ))
                    {
                        if (DoubleObjToDouble(e.Cell.Text) != DoubleObjToDouble(this._newAddRowTempTable.Rows[e.Cell.Row.Index - this._displayList.Count][e.Cell.Column.Key]))
                        {
                            e.Cell.Appearance.ForeColor = Color.Black; // 黒字設定
                        }
                        else
                        {
                            // 文字表示色設定
                            if (this._cellIniSettingColorDic.ContainsKey(e.Cell.Row.Index)
                            && this._cellIniSettingColorDic[e.Cell.Row.Index].ContainsKey(e.Cell.Column.Key)
                            && this._cellIniSettingColorDic[e.Cell.Row.Index][e.Cell.Column.Key] == Color.Red)
                            {
                                e.Cell.Appearance.ForeColor = Color.Red; // 赤字設定 

                            }
                        } 
                    }
                }
            }
            // --- ADD donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
        }

        /// <summary>
        /// uGrid_Details_AfterCellUpdateイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : uGrid_Details_AfterCellUpdate</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);

            this.uGrid_Details.ImeMode = ImeMode.Disable;
            string code = e.Cell.Row.Cells[e.Cell.Column.Index].Value.ToString();
            string name = string.Empty;
            bool flag = false;
            if (e.Cell.Row.Index == 0)
            {
                if (_customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    if (!_beCustomerRateG.Equals(code))
                    {
                        if (code != "")
                        {
                            if (code == ALL_CUST_RATE_GRP)
                            {
                                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                                return;
                            }

                            flag = this.CustomerGIsExist(code, ref name);
                            if (flag)
                            {
                                e.Cell.Value = code.PadLeft(4, '0');
                                this.uGrid_Details.Rows[e.Cell.Row.Index + 1].Cells[e.Cell.Column.Index].Value = name;
                            }
                            else
                            {
                                if (this.chkSearchingAll.Enabled && this.chkSearchingAll.Checked)
                                {
                                    _bevalueFlag = true;
                                    e.Cell.Value = code.PadLeft(4, '0');
                                    this.uGrid_Details.Rows[e.Cell.Row.Index + 1].Cells[e.Cell.Column.Index].Value = "";
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                       this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       "指定された条件で得意先掛率Ｇコードは存在しませんでした。",
                                       -1,
                                       MessageBoxButtons.OK);
                                    _bevalueFlag = false;
                                    e.Cell.Value = _beCustomerRateG;
                                }
                            }
                        }
                        else
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index + 1].Cells[e.Cell.Column.Index].Value = "";
                        }

                    }
                }
                else
                {
                    if (!_beCustomerCd.Equals(code))
                    {
                        if (code != "" && code != "0")
                        {
                            flag = this.CustomerIsExist(code, ref name);
                            if (flag)
                            {
                                e.Cell.Value = code.PadLeft(8, '0');
                                this.uGrid_Details.Rows[e.Cell.Row.Index + 1].Cells[e.Cell.Column.Index].Value = name;
                            }
                            else
                            {
                                if (this.chkSearchingAll.Enabled && this.chkSearchingAll.Checked)
                                {
                                    _bevalueFlag = true;
                                    e.Cell.Value = code.PadLeft(8, '0');
                                    this.uGrid_Details.Rows[e.Cell.Row.Index + 1].Cells[e.Cell.Column.Index].Value = "";
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                       this,
                                       emErrorLevel.ERR_LEVEL_INFO,
                                       this.Name,
                                       "指定された条件で得意先コードは存在しませんでした。",
                                       -1,
                                       MessageBoxButtons.OK);
                                    _bevalueFlag = false;
                                    e.Cell.Value = _beCustomerCd;
                                }
                            }
                        }
                        else
                        {
                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[e.Cell.Column.Index].Value = "";
                            this.uGrid_Details.Rows[e.Cell.Row.Index + 1].Cells[e.Cell.Column.Index].Value = "";
                        }
                    }

                }
            }
            else
            {
                switch (e.Cell.Column.Key)
                {
                    case COLUMN_MAKERCODE:
                        {
                            int codeInt = StrObjToInt(code);
                            int preCodeInt = StrObjToInt(_precode);

                            string returnCode = code.PadLeft(4, '0');
                            if (codeInt != 0)
                            {
                                if (codeInt != preCodeInt)
                                {
                                    int makerCode = Convert.ToInt32(code);
                                    string makerName = GetMakerName(makerCode);
                                    // マスタに存在しない場合
                                    if (string.IsNullOrEmpty(makerName))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "指定された条件でメーカーコードは存在しませんでした。",
                                            -1,
                                            MessageBoxButtons.OK);
                                            _bevalueFlag = false;
                                            returnCode = _precode;
                                    }
                                }
                            }
                            else
                            {
                                returnCode = string.Empty;
                            }
                            e.Cell.Value = returnCode;

                            break;
                        }
                    case COLUMN_GOODSRATEGRPCODE:
                        {
                            int codeInt = StrObjToInt(code);
                            int preCodeInt = StrObjToInt(_precode);

                            string returnCode = code.PadLeft(4, '0');
                            if (codeInt != 0)
                            {
                                if (codeInt != preCodeInt)
                                {
                                    int goodsGroupCode = Convert.ToInt32(code);
                                    // 商品掛率Ｇ名称を取る
                                    string goodsGroupName = GetGoodsGroupName(goodsGroupCode);

                                    // マスタに存在しない場合
                                    if (string.IsNullOrEmpty(goodsGroupName))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "指定された条件で商品掛率Ｇコードは存在しませんでした。",
                                            -1,
                                            MessageBoxButtons.OK);
                                            _bevalueFlag = false;
                                            returnCode = _precode; 
                                    }
                                    else
                                    {
                                        
                                        // 該当するデータが存在した場合
                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = goodsGroupName;
                                        if (e.Cell.Row.Index >= this._displayList.Count + 2)// 新追加行判定
                                        {
                                            // ＢＬグループコードとＢＬコードをクリアする
                                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value = string.Empty;
                                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value = string.Empty;
                                        }
                                        if (string.IsNullOrEmpty(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value.ToString()))
                                        {
                                            this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = goodsGroupName;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                returnCode = string.Empty;
                                if (string.IsNullOrEmpty(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value.ToString()))
                                {
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = string.Empty;
                                }
                            }
                            e.Cell.Value = returnCode;
                            
                            break;
                        }
                    case COLUMN_GLCD:
                        {
                            int codeInt = StrObjToInt(code);
                            int preCodeInt = StrObjToInt(_precode);

                            if (codeInt != 0)
                            {
                                if (codeInt != preCodeInt)
                                {
                                    int grCode = Convert.ToInt32(code);
                                    if (this._blGroupUDic == null)
                                    {
                                        // BLグループコードマスタ読込処理
                                        ReadBLGroupU();
                                    }
                                    // 入力したＢＬグループコードがＢＬグループコードマスタに存在する場合
                                    if (this._blGroupUDic.ContainsKey(grCode))
                                    {
                                        // ＢＬグループコードの表示書式設定
                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value = this._blGroupUDic[grCode].BLGroupCode.ToString("00000");
                                        // ＢＬグループコード名設定
                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = GetBLGroupName(grCode);
                                        if (e.Cell.Row.Index >= this._displayList.Count + 2)// 新追加行判定
                                        {
                                            switch (this._goodsMode)
                                            {
                                                case GoodsMode.GoodsRateG:
                                                    {
                                                        // 商品掛率ＧとＢＬコードをクリアする
                                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GOODSRATEGRPCODE].Value = string.Empty;
                                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value = string.Empty;
                                                        break;
                                                    }
                                                case GoodsMode.GoodsRateRank:
                                                    {
                                                        // ＢＬコードをクリアする
                                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value = string.Empty;
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    // 入力したＢＬグループコードがＢＬグループコードマスタに存在しない場合
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "指定された条件でBLグループコードは存在しませんでした。",
                                            -1,
                                            MessageBoxButtons.OK);
                                            _bevalueFlag = false;
                                            e.Cell.Value = _precode;
                                    }
                                }
                                else
                                {
                                    e.Cell.Value = code.PadLeft(5, '0');
                                }
                            }
                            else
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value = string.Empty;
                                if ((this._goodsMode == GoodsMode.GoodsRateG
                                    && StrObjToInt(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value) == 0
                                    && StrObjToInt(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GOODSRATEGRPCODE].Value) == 0)
                                    ||(this._goodsMode == GoodsMode.GoodsRateRank
                                    && StrObjToInt(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value) == 0))
                                {
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = string.Empty; 
                                }
                            }
                            break;
                        }
                    case COLUMN_BLCD:
                        {
                            int codeInt = StrObjToInt(code);
                            int preCodeInt = StrObjToInt(_precode);

                            if (codeInt != 0)
                            {
                                if (codeInt != preCodeInt)
                                {
                                    int blCode = Convert.ToInt32(code);
                                    if (this._blGoodsCdUMntDic == null)
                                    {
                                        // BLコードマスタ読込処理
                                        ReadBLGoodsCdUMnt();
                                    }
                                    if (_blGoodsCdUMntDic.ContainsKey(blCode))
                                    {
                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value = _blGoodsCdUMntDic[blCode].BLGoodsCode.ToString("00000");
                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = _blGoodsCdUMntDic[blCode].BLGoodsHalfName.Trim();
                                        if (e.Cell.Row.Index >= this._displayList.Count + 2)// 新追加行判定
                                        {
                                            switch (this._goodsMode)
                                            {
                                                case GoodsMode.GoodsRateG:
                                                    {
                                                        // ＢＬグループコードと商品掛率Ｇをクリアする
                                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GOODSRATEGRPCODE].Value = string.Empty;
                                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value = string.Empty;
                                                        break;
                                                    }
                                                case GoodsMode.GoodsRateRank:
                                                    {
                                                        // ＢＬグループコードをクリアする
                                                        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value = string.Empty;
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "指定された条件でBLコードは存在しませんでした。",
                                            -1,
                                            MessageBoxButtons.OK);
                                            _bevalueFlag = false;
                                            e.Cell.Value = _precode;
                                    }
                                }
                                else
                                {
                                    e.Cell.Value = code.PadLeft(5, '0');
                                }
                            }
                            else
                            {
                                this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_BLCD].Value = string.Empty;
                                if ((this._goodsMode == GoodsMode.GoodsRateG
                                    && StrObjToInt(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value) == 0
                                    && StrObjToInt(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GOODSRATEGRPCODE].Value) == 0)
                                    || (this._goodsMode == GoodsMode.GoodsRateRank
                                    && StrObjToInt(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_GLCD].Value) == 0))
                                {
                                    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[COLUMN_NAME].Value = string.Empty;
                                }
                            }
                            break;
                        }
                    case COLUMN_EXPANDFLG:
                        {
                            CellsCollection cells = uGrid_Details.Rows[e.Cell.Row.Index].Cells;

                            string expandKey = MakeParentKey(cells);
                            bool expandFlag;
                            if (this.expandDic.TryGetValue(expandKey, out expandFlag))
                            {
                                // 展開フラグ
                                expandDic[expandKey] = (bool)cells[COLUMN_EXPANDFLG].Value;
                            }
                            else
                            {
                                // 展開フラグ
                                expandDic.Add(expandKey, (bool)cells[COLUMN_EXPANDFLG].Value);
                            }
                            break;
                        }
                }
            }
            #region 入力検索条件を覚える
            if (e.Cell.Row.Index == 0)
            {
                string customerKey = this._customerSearchMode.ToString() + "-" + this.chkSearchingAll.Checked.ToString() + "-" + e.Cell.Column.Index.ToString();
                if (!this._inputCustomerDic.ContainsKey(customerKey))
                {
                    this._inputCustomerDic.Add(customerKey, e.Cell.Value.ToString());
                }
                else
                {
                    this._inputCustomerDic[customerKey] = e.Cell.Value.ToString();
                }
            }
            #endregion 入力検索条件を覚える

            // 編集アイコンを除く
            this.uGrid_Details.UpdateData();
            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
        }

        /// <summary>
        /// uGrid_Details_BeforeCellUpdateイベント
        /// </summary>
        /// <param name= "sender">対象オブジェクト</param>
        /// <param name= "e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : uGrid_Details_BeforeCellUpdate</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Row.Index == 0)
            {
                if (_customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    _beCustomerRateG = e.Cell.Value.ToString().Trim();
                }
                else
                {
                    _beCustomerCd = e.Cell.Value.ToString().Trim();
                }
            }
            else
            {
                _precode = e.Cell.Value.ToString().Trim();
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
                
                // 編集中であった場合
                if (cell.IsInEditMode)
                {
                    // セルのスタイルにて判定
                    switch (cell.StyleResolved)
                    {
                        // テキストボックス・テキストボックス(ボタン付)
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                        case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                            {
                                switch (e.KeyData)
                                {
                                    // ←キー
                                    case Keys.Left:
                                        if (cell.SelStart == 0)
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // →キー
                                    case Keys.Right:
                                        if (cell.SelStart >= cell.Text.Length)
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                }
                                break;
                            }
                        // 上記以外のスタイル
                        default:
                            {
                                switch (e.KeyData)
                                {
                                    // ←キー
                                    case Keys.Left:
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                    // →キー
                                    case Keys.Right:
                                        {
                                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                            e.Handled = true;
                                        }
                                        break;
                                }
                                break;
                            }
                    }
                }

                switch (e.KeyCode)
                {
                    case Keys.Home:
                        {
                            if ((cell != null) && (cell.IsInEditMode))
                            {
                                // 編集モードの場合はなにもしない
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                            }
                            break;
                        }
                    case Keys.End:
                        {
                            // 編集モードの場合はなにもしない
                            if ((cell != null) && (cell.IsInEditMode))
                            {
                                //
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                            }
                            break;
                        }
                }

                if (e.KeyCode == Keys.Up)
                {
                    int curRowIdx = cell.Row.Index;
                    int curColIdx = cell.Column.Index;
                    for (int rowIdx = curRowIdx - 1; rowIdx >= 0; rowIdx--)
                    {
                        if (!uGrid_Details.Rows[rowIdx].Hidden
                            && !uGrid_Details.Rows[rowIdx].Cells[curColIdx].Column.Hidden
                            && uGrid_Details.Rows[rowIdx].Cells[curColIdx].Activation != Activation.Disabled
                            && uGrid_Details.Rows[rowIdx].Cells[curColIdx].Column.CellActivation != Activation.Disabled)
                        {
                            return;
                        }
                    }

                    if (this.chkSearchingAll.Enabled)
                        chkSearchingAll.Focus();
                    else
                        Add_Button.Focus();
                    AdjustButtonEnable(1, false);

                    e.Handled = true;
                }
                // 行削除
                if (e.Alt)
                {
                    if (e.KeyCode == Keys.D
                        && this.Delete_Button.Enabled == true)
                    {
                        this.Delete_Button_Click(this.Delete_Button, new EventArgs());
                    }
                }
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            // 「Backspace」キーを押された時
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 編集できるのは仕入率と売価率のみ
            if (cell.IsInEditMode)
            {
                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (!KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    return;
                }
                // 仕入率、売価率と原価ＵＰ率
                if (cell.Column.Index >= 9 && cell.Column.Index <= 209)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 粗利確保率
                else if (cell.Column.Index >= 210)
                {
                    // Z9.99
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 商品掛率Ｇとメーカーコード
                else if (cell.Column.Key == COLUMN_GOODSRATEGRPCODE || cell.Column.Key == COLUMN_MAKERCODE)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // ＧroupコードとＢＬコード
                else if (cell.Column.Key == COLUMN_GLCD || cell.Column.Key == COLUMN_BLCD)
                {
                    if (!KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // 層別
                else if (cell.Column.Key == COLUMN_GOODSRATERANK)
                {
                    if (!KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルがアクティブ化した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Selected = false;
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell.Row.Index == 0 && this.uGrid_Details.ActiveCell.Column.Index > 9)
                {
                    this.AdjustButtonEnable(1, true);
                }
                else if ((this.uGrid_Details.ActiveCell.Column.Key == COLUMN_BLCD && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                        || (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_MAKERCODE && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                        || (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GOODSRATEGRPCODE && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                        || (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GLCD && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit))
                {
                    this.AdjustButtonEnable(1, true);
                }
                else
                {
                    this.AdjustButtonEnable(1, false);
                }
                // 展開ボタンをクリックすると前回ActiveCellを記録する
                _prevActiveUltraGridCellCol = this.uGrid_Details.ActiveCell.Column.Index;
                _prevActiveUltraGridCellRow = this.uGrid_Details.ActiveCell.Row.Index;
            }
        }

        /// <summary>
        /// AfterRowActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 行がアクティブ化した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.AdjustButtonEnable(1, true);
                }
                else if(this.tEdit_SectionCodeAllowZero.ContainsFocus || this.tNedit_GoodsMakerCd.ContainsFocus || this.tNedit_GoodsMGroup.ContainsFocus || this.tNedit_SupplierCd.ContainsFocus)
                {
                    this.AdjustButtonEnable(1, true);
                }
                else
                {
                    this.AdjustButtonEnable(1, false);
                }
                return;
            }
            this.AdjustButtonEnable(1, false);

            CellsCollection cells = this.uGrid_Details.ActiveRow.Cells;

            bool existFlg;
            bool existGRFlg;

            // 親子区分
            int parentDiv = IntObjToInt(cells[COLUMN_PARENTDIV].Value);
            if (parentDiv == 0)
            {
                // Key作成
                string grKey = MakeParentKey(cells);

                //子親が存在するかどうかチェック
                existGRFlg = this._parentGRList.Exists(delegate(Rate2SearchResult target)
                {
                    if (grKey == MakeParentKey(target))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                // Key作成
                string key = MakeParentKey(cells);

                // 子が存在するかどうかチェック
                existFlg = this._childList.Exists(delegate(Rate2SearchResult target)
                {
                    if (key == MakeParentKey(target))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });
            }
            // 新規行
            else if (parentDiv == -1)
            {
                existGRFlg = false;
                existFlg = false;
            }
            else
            {
                existGRFlg = true;
                existFlg = true;
            }
            this.Expand_Button.Enabled = (existFlg || existGRFlg);
        }

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モード時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                // 1行1列目から未入力でフォーカスアウト時は空欄と表示
                if (_customerSearchMode == CustomerSearchMode.CustomerRateG
                    && (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_SALERATE1
                    || this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GRSPROFITSECURERAT1
                    || this.uGrid_Details.ActiveCell.Column.Key == COLUMN_UPRATE1))
                {
                    if (this.uGrid_Details.ActiveCell.Value.ToString() == ALL_CUST_RATE_GRP)
                    {
                        this.uGrid_Details.ActiveRow.Cells[COLUMN_SALERATE1].Value = string.Empty;
                        this.uGrid_Details.ActiveRow.Cells[COLUMN_GRSPROFITSECURERAT1].Value = string.Empty;
                        this.uGrid_Details.ActiveRow.Cells[COLUMN_UPRATE1].Value = string.Empty;
                        this.AdjustButtonEnable(1, true);
                    }
                }
            }
            
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// <br>Update Note : 2013/04/19 donggy</br>
        /// <br>管理番号    : 10901273-00 </br>
        /// <br>              Redmine#35355　拠点を入力し赤字で呼び出した掛率等を修正した場合に、</br>
        /// <br>　　　　　　　黒字に置き換えて入力拠点で新規作成するように修正する</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (this.uGrid_Details.ActiveCell.Value.ToString() == ALL_CUST_RATE_GRP)
                {
                    this.AdjustButtonEnable(1, false);
                    return;
                }
                if (this.uGrid_Details.ActiveCell == null)
                {
                    return;
                }

                // 1行1列目から未入力でフォーカスアウト時はALLと表示
                if (_customerSearchMode == CustomerSearchMode.CustomerRateG
                    && !this.chkSearchingAll.Checked
                    && (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_SALERATE1
                    || this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GRSPROFITSECURERAT1
                    || this.uGrid_Details.ActiveCell.Column.Key == COLUMN_UPRATE1))
                {
                    if (string.IsNullOrEmpty(this.uGrid_Details.ActiveCell.Value.ToString()))
                    {
                        this.uGrid_Details.ActiveRow.Cells[COLUMN_SALERATE1].Value = ALL_CUST_RATE_GRP;
                        this.uGrid_Details.ActiveRow.Cells[COLUMN_GRSPROFITSECURERAT1].Value = ALL_CUST_RATE_GRP;
                        this.uGrid_Details.ActiveRow.Cells[COLUMN_UPRATE1].Value = ALL_CUST_RATE_GRP;

                        this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index + 1].Cells[COLUMN_SALERATE1].Value = string.Empty;
                        this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index + 1].Cells[COLUMN_GRSPROFITSECURERAT1].Value = string.Empty;
                        this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index + 1].Cells[COLUMN_UPRATE1].Value = string.Empty;

                        #region 仕入先、得意先掛率G(得意先）三つ項目欄に条件が入力ある時、行追加ボタンを操作可にする
                        if (this.tNedit_SupplierCd.GetInt() > 0)
                        {
                            Boolean hasInputSearchData = false;

                            for (int index = 9; index < this.uGrid_Details.Rows[0].Cells.Count; index++)
                            {
                                if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[index].Value.ToString().Trim())
                                    && (uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden == false))
                                {
                                    hasInputSearchData = true;
                                    break;
                                }
                            }

                            if (hasInputSearchData)
                            {
                                this.Add_Button.Enabled = true;
                            }
                            else
                            {
                                this.Add_Button.Enabled = false;
                            }
                        }
                        else
                        {
                            this.Add_Button.Enabled = false;
                        }
                        #endregion 仕入先、得意先掛率G(得意先）三つ項目欄に条件が入力ある時、行追加ボタンを操作可にする
                        return;
                    }
                }
                
                int code = StrObjToInt(this.uGrid_Details.ActiveCell.Value);
                string codeStr = StrObjToStr(this.uGrid_Details.ActiveCell.Value);

                int colIndex = 1;

                switch (this._rateMode)
                {
                    case RateMode.RateVal:
                        {
                            colIndex = StrObjToInt(this.uGrid_Details.ActiveCell.Column.Key.Substring(COLUMN_SALERATE.Length));
                            if (codeStr != string.Empty)
                            {
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_UPRATE + colIndex.ToString()].Value = code.ToString();
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value = code.ToString();
                            }
                            else
                            {
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_UPRATE + colIndex.ToString()].Value = string.Empty;
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value = string.Empty;
                            }
                            break;
                        }
                    case RateMode.UpRate:
                        {
                            colIndex = StrObjToInt(this.uGrid_Details.ActiveCell.Column.Key.Substring(COLUMN_UPRATE.Length));
                            if (codeStr != string.Empty)
                            {
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_SALERATE + colIndex.ToString()].Value = code.ToString();
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value = code.ToString();
                            }
                            else
                            {
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_SALERATE + colIndex.ToString()].Value = string.Empty;
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_GRSPROFITSECURERAT + colIndex.ToString()].Value = string.Empty;
                            }
                            break;
                        }
                    case RateMode.GrsProfitSecureRat:
                        {
                            colIndex = StrObjToInt(this.uGrid_Details.ActiveCell.Column.Key.Substring(COLUMN_GRSPROFITSECURERAT.Length));
                            if (codeStr != string.Empty)
                            {
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_SALERATE + colIndex.ToString()].Value = code.ToString();
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_UPRATE + colIndex.ToString()].Value = code.ToString();
                            }
                            else
                            {
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_SALERATE + colIndex.ToString()].Value = string.Empty;
                                this.uGrid_Details.ActiveRow.Cells[COLUMN_UPRATE + colIndex.ToString()].Value = string.Empty;
                            }
                            break;
                        }
                }

                if (codeStr != string.Empty && !_searchDic.ContainsKey(code))
                {
                    _searchDic.Add(code, colIndex);
                }                    

                return;
            }
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            // 入力値取得
            if (this.uGrid_Details.ActiveCell.Column.Index >= 9)
            {

                string rate = "";

                if ((this.uGrid_Details.ActiveCell.Column.Index < 210 && (DoubleObjToDouble(this.uGrid_Details.ActiveCell.Value) >= 1000)) || (this.uGrid_Details.ActiveCell.Column.Index >= 210 && (DoubleObjToDouble(this.uGrid_Details.ActiveCell.Value) >= 100)) || (DoubleObjToDouble(this.uGrid_Details.ActiveCell.Value) <= 0))
                {
                    rate = string.Format("{0:0.00}", 0);
                }
                else
                {
                    rate = string.Format("{0:0.00}", DoubleObjToDouble(this.uGrid_Details.ActiveCell.Value));
                }
                
                // 0は空白表示
                if ("0.00".Equals(rate))
                {
                    this.uGrid_Details.ActiveCell.Value = DBNull.Value;
                }
                else
                {
                    uGrid_Details.ActiveCell.Value = rate;
                }

                if (CompareOriginalScreen())
                {
                    AdjustButtonEnable(2, true);
                }
                else
                {
                    AdjustButtonEnable(2, false);
                }
            }
            else
            {
                #region 新追加行の掛率検索
                 // 新追加行商品情報部のkey作成
                string searchKey = this.uGrid_Details.ActiveCell.Row.Index.ToString() + "-" + this._goodsMode.ToString() + "-"
                                  + this.uGrid_Details.ActiveCell.Column.Key;

                #region　検索前に、商品情報変更の判断
                if((this._inputGoodsInfoDic.ContainsKey(searchKey)
                       && this._inputGoodsInfoDic[searchKey] == false) // 商品情報変更なし
                       || (!this._inputGoodsInfoDic.ContainsKey(searchKey))) // 商品情報変更なし
                {
                    return;
                }
                #endregion 検索前に、商品情報変更の判断
                #region 掛率検索
                if (this._inputGoodsInfoDic.ContainsKey(searchKey))
                {
                    this._inputGoodsInfoDic[searchKey] = false; 
                }
                if (this.uGrid_Details.ActiveCell.Row.Index < this._displayList.Count + 2 // 非新追加行
                    || (this.uGrid_Details.ActiveCell.Column.Key != COLUMN_GOODSRATEGRPCODE
                        && this.uGrid_Details.ActiveCell.Column.Key != COLUMN_GOODSRATERANK
                        && this.uGrid_Details.ActiveCell.Column.Key != COLUMN_GLCD
                        && this.uGrid_Details.ActiveCell.Column.Key != COLUMN_BLCD
                        && this.uGrid_Details.ActiveCell.Column.Key != COLUMN_MAKERCODE))
                {
                    return;
                }
                
                this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                // 商品掛率Ｇの場合
                List<Rate2SearchResult> rate2SearchResultList = new List<Rate2SearchResult>();
                int status = -2;
                if (this._goodsMode == GoodsMode.GoodsRateG)
                {
                    if ((StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GOODSRATEGRPCODE].Value) != 0
                        || StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GLCD].Value) != 0
                        || StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_BLCD].Value) != 0)// 商品掛率Ｇ・グループコード・ＢＬコード一つ入力した
                        && StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_MAKERCODE].Value) != 0) // メーカーを入力した
                    {
                       status = this.NewAddRowRateSearch(this.uGrid_Details.ActiveCell.Row, out rate2SearchResultList); // 検索実行
                    }
                }
                // 層別の場合
                else
                {
                    if ((StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GLCD].Value) != 0
                        || StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_BLCD].Value) != 0
                        || (StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GLCD].Value) == 0
                            && StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_BLCD].Value) == 0))　// グループコードとＢＬコード一つ入力した
                        && StrObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_MAKERCODE].Value) != 0 // メーカーを入力した
                        && StrObjToStr(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GOODSRATERANK].Value) != string.Empty) // 層別を入力した
                    {
                       status = this.NewAddRowRateSearch(this.uGrid_Details.ActiveCell.Row, out rate2SearchResultList); // 検索実行
                    }
                }
                if (status != -2)
                {
                    // 前回検索取得掛率削除
                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Value = string.Empty;
                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Activation = Activation.AllowEdit;
                    foreach (UltraGridCell cell in this.uGrid_Details.Rows[0].Cells)
                    {
                        if (!cell.Column.Key.Contains(COLUMN_SALERATE)
                            && (!cell.Column.Key.Contains(COLUMN_UPRATE))
                            && (!cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
                        {
                            continue;
                        }
                        else
                        {
                            this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = string.Empty;
                            this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Activation = Activation.AllowEdit;
                        }
                    } 
                }
                // 検索掛率あり
                if (rate2SearchResultList.Count > 0)
                {
                    foreach (Rate2SearchResult rate2SearchResult in rate2SearchResultList)
                    {
                        // 仕入率
                        if (rate2SearchResult.UnitPriceKind == "2"
                            && rate2SearchResult.RateMngCustCd == "5")
                        {
                            // 論理削除データ制御
                            if (rate2SearchResult.LogicalDeleteCode == 1)
                            {
                                this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Activation = Activation.Disabled;
                                continue;
                            }
                            // 非正規データ表示しない
                            else if (rate2SearchResult.LogicalDeleteCode != 0)
                            {
                                continue;
                            }
                            if (rate2SearchResult.RateVal != 0.0)
                            {
                                this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Value = rate2SearchResult.RateVal.ToString("0.00");
                                // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                if (rate2SearchResult.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                {
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_COSTRATE].Appearance.ForeColor = Color.Red;
                                }
                            }
                            continue;
                        }
                        // ALLの売価率・原価UP率・粗利確保率
                        else if (rate2SearchResult.UnitPriceKind == "1"
                             && rate2SearchResult.RateMngCustCd == "5")
                        {
                            if (this._customerSearchMode == CustomerSearchMode.CustomerRateG
                                && this.uGrid_Details.Rows[0].Cells[COLUMN_SALERATE1].Value.ToString() == ALL_CUST_RATE_GRP)
                            {
                                // 論理削除データ制御
                                if (rate2SearchResult.LogicalDeleteCode == 1)
                                {
                                    // 売価率
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_SALERATE1].Appearance.BackColorDisabled = Color.Gainsboro;
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_SALERATE1].Appearance.ForeColorDisabled = Color.Black;
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_SALERATE1].Activation = Activation.Disabled;
                                    // 原価UP率
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_UPRATE1].Appearance.BackColorDisabled = Color.Gainsboro;
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_UPRATE1].Appearance.ForeColorDisabled = Color.Black;
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_UPRATE1].Activation = Activation.Disabled;
                                    // 粗利確保率
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GRSPROFITSECURERAT1].Appearance.BackColorDisabled = Color.Gainsboro;
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GRSPROFITSECURERAT1].Appearance.ForeColorDisabled = Color.Black;
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GRSPROFITSECURERAT1].Activation = Activation.Disabled;
                                    continue;
                                }
                                // 非正規データ表示しない
                                else if (rate2SearchResult.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }
                                if (rate2SearchResult.RateVal != 0.0)
                                {
                                    // 新しい掛率を設定します
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_SALERATE1].Value = rate2SearchResult.RateVal.ToString("0.00");
                                    // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                    if (rate2SearchResult.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                    {
                                        this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_SALERATE1].Appearance.ForeColor = Color.Red;
                                    }
                                }
                                if (rate2SearchResult.UpRate != 0.0)
                                {
                                    // 新しい掛率を設定します
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_UPRATE1].Value = rate2SearchResult.UpRate.ToString("0.00");
                                    // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                    if (rate2SearchResult.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                    {
                                        this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_UPRATE1].Appearance.ForeColor = Color.Red;
                                    }
                                }
                                if (rate2SearchResult.GrsProfitSecureRate != 0.0)
                                {
                                    // 新しい掛率を設定します
                                    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GRSPROFITSECURERAT1].Value = rate2SearchResult.GrsProfitSecureRate.ToString("0.00");
                                    // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                    if (rate2SearchResult.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                    {
                                        this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GRSPROFITSECURERAT1].Appearance.ForeColor = Color.Red;
                                    }
                                }
                            }
                        }
                        // 非ALLの売価率・原価UP率・粗利確保率
                        else if (rate2SearchResult.UnitPriceKind == "1"
                                && rate2SearchResult.RateMngCustCd != "5")
                        {
                            foreach (UltraGridCell cell in this.uGrid_Details.Rows[0].Cells)
                            {
                                if (!cell.Column.Key.Contains(COLUMN_SALERATE)
                                    && (!cell.Column.Key.Contains(COLUMN_UPRATE))
                                    && (!cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
                                {
                                    continue;
                                }
                                else
                                {
                                    // 得意先掛率Ｇの場合
                                    if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                                    {
                                        if (cell.Value != DBNull.Value
                                                && cell.Value != null
                                                && cell.Value.ToString() != ""
                                                && cell.Value.ToString() != ALL_CUST_RATE_GRP
                                                && int.Parse(cell.Value.ToString()) == rate2SearchResult.CustRateGrpCode)
                                        {
                                            // 論理削除データ制御
                                            if (rate2SearchResult.LogicalDeleteCode == 1)
                                            {
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Appearance.BackColorDisabled = Color.Gainsboro;
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Appearance.ForeColorDisabled = Color.Black;
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Activation = Activation.Disabled;
                                                continue;
                                            }
                                            // 非正規データ表示しない
                                            else if (rate2SearchResult.LogicalDeleteCode != 0)
                                            {
                                                continue;
                                            }
                                            if (cell.Column.Key.Contains(COLUMN_SALERATE))
                                            {
                                                if (rate2SearchResult.RateVal != 0.0)
                                                {
                                                    // 新しい掛率を設定します
                                                    this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = rate2SearchResult.RateVal.ToString("0.00");
                                                }
                                            }
                                            else if (cell.Column.Key.Contains(COLUMN_UPRATE))
                                            {
                                                if (rate2SearchResult.UpRate != 0.0)
                                                {
                                                    // 新しい掛率を設定します
                                                    this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = rate2SearchResult.UpRate.ToString("0.00");
                                                }
                                            }
                                            else if (cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT))
                                            {
                                                if (rate2SearchResult.GrsProfitSecureRate != 0.0)
                                                {
                                                    // 新しい掛率を設定します
                                                    this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = rate2SearchResult.GrsProfitSecureRate.ToString("0.00");
                                                }
                                            }
                                            // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>
                                            // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                            if (rate2SearchResult.SectionCode.Trim() == ctSectionCode && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                            {
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Appearance.ForeColor = Color.Red; 
                                            }
                                            // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<
                                        }
                                    }
                                    // 得意先の場合
                                    else
                                    {
                                        if (StrObjToInt(cell.Value) == rate2SearchResult.CustomerCode)
                                        {
                                            // 論理削除データ制御
                                            if (rate2SearchResult.LogicalDeleteCode == 1)
                                            {
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Appearance.BackColorDisabled = Color.Gainsboro;
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Appearance.ForeColorDisabled = Color.Black;
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Activation = Activation.Disabled;
                                                continue;
                                            }
                                            // 非正規データ表示しない
                                            else if (rate2SearchResult.LogicalDeleteCode != 0)
                                            {
                                                continue;
                                            }
                                            if (cell.Column.Key.Contains(COLUMN_SALERATE))
                                            {
                                                if (rate2SearchResult.RateVal != 0.0)
                                                {
                                                    // 新しい掛率を設定します
                                                    this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = rate2SearchResult.RateVal.ToString("0.00");
                                                }
                                            }
                                            else if (cell.Column.Key.Contains(COLUMN_UPRATE))
                                            {
                                                if (rate2SearchResult.UpRate != 0.0)
                                                {
                                                    // 新しい掛率を設定します
                                                    this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = rate2SearchResult.UpRate.ToString("0.00");
                                                }
                                            }
                                            else if (cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT))
                                            {
                                                if (rate2SearchResult.GrsProfitSecureRate != 0.0)
                                                {
                                                    // 新しい掛率を設定します
                                                    this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Value = rate2SearchResult.GrsProfitSecureRate.ToString("0.00");
                                                }
                                            }
                                            // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>
                                            // 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                            if (rate2SearchResult.SectionCode.Trim() == ctSectionCode && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                            {
                                                this.uGrid_Details.ActiveCell.Row.Cells[cell.Column.Key].Appearance.ForeColor = Color.Red;
                                            }
                                            // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<
                                        }
                                    }
                                    // --- DEL donggy 2013/04/19 for Redmine#35355 --->>>>>>>>>>
                                    //// 拠点指定で呼び出した時に、全社共通の設定から表示された分は赤字で表示
                                    //if (rate2SearchResult.SectionCode.Trim() == "00" && this.tEdit_SectionCodeAllowZero.Text.Trim() != rate2SearchResult.SectionCode.Trim())
                                    //{
                                    //    this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_GRSPROFITSECURERAT1].Appearance.ForeColor = Color.Red; 
                                    //}
                                    // --- DEL donggy 2013/04/19 for Redmine#35355 ---<<<<<<<<<
                                }
                            }

                        }
                    }
                }
                this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
                #endregion 掛率検索
                #endregion　新追加行の掛率検索

                // --- ADD donggy 2013/04/19 for Redmine#35355 --- >>>>>>>>
                // 新追加行明細グリッド値記憶
                string rowFilter = COLUMN_NO + " = " + IntObjToInt(this.uGrid_Details.ActiveCell.Row.Cells[COLUMN_NO].Value).ToString();
                DataRow[] matchRows = null;
                if (this._newAddRowTempTable.Rows.Count > 0)
                {
                    matchRows = this._newAddRowTempTable.Select(rowFilter);
                    if (matchRows != null
                        && matchRows.Length > 0)
                    {
                        foreach (UltraGridCell newRowCell in this.uGrid_Details.ActiveCell.Row.Cells)
                        {
                            matchRows[0][newRowCell.Column.Key] = newRowCell.Value;
                        } 
                    }
                }
                
                // セル設定色を記憶する
                Dictionary<string, Color> cellColorDic = new Dictionary<string, Color>();
                foreach (UltraGridCell cell in this.uGrid_Details.ActiveCell.Row.Cells)
                {
                    // 色変更なしセル記憶なし
                    if (!cell.Column.Key.Contains(COLUMN_COSTRATE)
                        && (!cell.Column.Key.Contains(COLUMN_SALERATE))
                        && (!cell.Column.Key.Contains(COLUMN_UPRATE))
                        && (!cell.Column.Key.Contains(COLUMN_GRSPROFITSECURERAT)))
                    {
                        continue;
                    }
                    // 色変更ありセルの初期設定色記憶
                    if (!cellColorDic.ContainsKey(cell.Column.Key))
                    {
                        if (cell.Appearance.ForeColor == Color.Red)
                        {
                            cellColorDic.Add(cell.Column.Key, Color.Red);
                        }
                        else
                        {
                            cellColorDic.Add(cell.Column.Key, Color.Black);
                        }
                    }

                }
                if (!this._cellIniSettingColorDic.ContainsKey(this.uGrid_Details.ActiveCell.Row.Index))
                {
                    this._cellIniSettingColorDic.Add(this.uGrid_Details.ActiveCell.Row.Index, cellColorDic);
                }
                else
                {
                    this._cellIniSettingColorDic[this.uGrid_Details.ActiveCell.Row.Index] = cellColorDic;
                }
                // --- ADD donggy 2013/04/19 for Redmine#35355 --- <<<<<<<<
            }
        }

        /// <summary>
        /// BeforeCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集前時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // 前回選択行状態を解除する
            this.uGrid_Details.BeginUpdate();
            if(this.uGrid_Details.Selected.Rows.Count > 0)
            {
                List<int> selectedRowsIndexList = new List<int>();
                for (int i = 0; i < this.uGrid_Details.Selected.Rows.Count; i++)
                {
                    selectedRowsIndexList.Add(this.uGrid_Details.Selected.Rows[i].Index);
                }
                foreach (int rowIndex in selectedRowsIndexList)
                {
                    this.uGrid_Details.Rows[rowIndex].Selected = false;
                }
            }
            this.uGrid_Details.EndUpdate();

            // 行削除ボタン制御
            if ( e.Cell.Row.Index >= this._displayList.Count + 2) // 新追加行判定
            {
                this.Delete_Button.Enabled = true; // 新追加行：行削除可
            }
            else
            {
                this.Delete_Button.Enabled = false; // 非新追加行：行削除不可
            }

            if (e.Cell.Row.Index == 0) return;
            if (e.Cell.CanEnterEditMode == false)
            {
                return;
            }
            if (DBNull.Value.Equals(e.Cell.Value) || e.Cell.Value == null || string.IsNullOrEmpty(e.Cell.Value.ToString()))
            {
                return;
            }
            if (e.Cell.Column.Key == COLUMN_GOODSRATERANK) return;
            decimal val = Convert.ToDecimal(e.Cell.Value);
            if (val * 100 % 100 == 0)
            {
                e.Cell.Value = Convert.ToInt32(val).ToString();
            }
        }

        /// <summary>
        /// BeforeRowActivateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 選択前時に発生します。</br>
        /// <br>Programmer  : 董桂鈺</br>
        /// <br>Date        : 2013/04/03</br>
        /// </remarks>
        private void uGrid_Details_BeforeRowActivate(object sender, RowEventArgs e)
        {
            if (e.Row.Index > 0 && e.Row.Index >= this._displayList.Count + 2) // 新追加行判定
            {
                this.Delete_Button.Enabled = true; // 新追加行：行削除可
            }
            else
            {
                this.Delete_Button.Enabled = false; // 非新追加行：行削除不可
            }
        }


        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                        {
                                            // 全選択状態にする。
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            // キーボード操作時、グリッドエンターイベントが発生します
            if (!mouseFlag)
            {
                uGrid_Details.ActiveCell = uGrid_Details.Rows[0].Cells[COLUMN_NAME];

                MoveToAllowEditCell(true);

                this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
            }
            else
            {
                if (this.uGrid_Details.ActiveCell != null)
                {
                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                    {
                        this.AdjustButtonEnable(1, true);
                    }
                    else if ((this.uGrid_Details.ActiveCell.Column.Key == COLUMN_BLCD && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                        || (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_MAKERCODE && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                        || (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GOODSRATEGRPCODE && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                        || (this.uGrid_Details.ActiveCell.Column.Key == COLUMN_GLCD && this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit))
                    {
                        this.AdjustButtonEnable(1, true);
                    }
                    else
                    {
                        this.AdjustButtonEnable(1, false);
                    }
                }
                else
                {
                    this.AdjustButtonEnable(1, false);
                }
            }

            // 行削除ボタン制御
            if (this.uGrid_Details.ActiveRow != null
                &&this.uGrid_Details.ActiveRow.Index > 0
                && this.uGrid_Details.ActiveRow.Index >= this._displayList.Count + 2)
            {
                this.Delete_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
            }
        }

        /// <summary>
        /// uGrid_Details_Leaveイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : フォーカスがグリッドから他のコントロールに移動する時に発生します。</br>
        /// <br>Programmer  : 董桂鈺</br>
        /// <br>Date        : 2013/04/03</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // フォーカスがグリッドから他のコントロールに移動する時、削除ボタンの制御
            if (this.Delete_Button.Focused)
            {
                return;
            }
            this.Delete_Button.Enabled = false;
        }

        /// <summary>
        /// 行選択変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 行選択変更時に発生します。</br>
        /// <br>Programmer  : gezh</br>
        /// <br>Date        : 2013/03/28</br>
        /// </remarks>
        private void uGrid_Details_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // クリア前回展開セルの位置
            _prevActiveUltraGridCellRow = 0;
            _prevActiveUltraGridCellCol = 0;

            // グリッドにアクティブセルがある
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    // F5ガイドがあるの制御
                    case COLUMN_GOODSRATEGRPCODE:
                    case COLUMN_GLCD:
                    case COLUMN_BLCD:
                    case COLUMN_MAKERCODE:
                        this.AdjustButtonEnable(1, true);
                        break;
                    // F5ガイドが無しの制御
                    default:
                        this.AdjustButtonEnable(1, false);
                        break;
                }
            }
            // グリッドにアクティブセルが無し、F5ガイドの制御
            else
            {
                this.AdjustButtonEnable(1, false);
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
            this.AdjustButtonEnable(0, true);

            // XMLデータ読込
            LoadStateXmlData();

            SetColumnHidden();

            this.MakeKeyMappingForGrid(this.uGrid_Details);

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// 範囲の指定変更イベント
        /// </summary>
        /// <remarks>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void chkSearchingAll_CheckedChanged(object sender, EventArgs e)
        {
            this.uGrid_Details.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
            if (this.chkSearchingAll.Checked)
            {
                if (this._customerSearchMode == CustomerSearchMode.CustomerRateG)
                {
                    for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
                    {
                        if (i < 110)
                        {
                            this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                            if (i >= 12)
                            {
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                            }
                        }
                        else if (i < 210)
                        {
                            this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                            if (i >= 112)
                            {
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                            if (i >= 212)
                            {
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
                    {
                        if (i < 110)
                        {
                            this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                            if (i >= 12)
                            {
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                            }
                        }
                        else if (i < 210)
                        {
                            this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                            if (i >= 112)
                            {
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                            this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                            if (i >= 212)
                            {
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[0].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.Disabled;

                                this.uGrid_Details.Rows[1].Cells[i].Appearance.BackColorDisabled = Color.Gainsboro;
                                this.uGrid_Details.Rows[1].Cells[i].Appearance.ForeColorDisabled = Color.Black;
                                this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.Disabled;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
                {
                    this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                    this.uGrid_Details.Rows[0].Cells[i].Activation = Activation.AllowEdit;
                    this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                    this.uGrid_Details.Rows[1].Cells[i].Activation = Activation.NoEdit;
                }
            }
            #region 範囲指定状態変更後、前入力値を渡す
            // 明細列
            for (int i = 10; i <= COLINDEX_SALERATE_ED; i++)
            {
                string name = string.Empty;
                string customerKey = this._customerSearchMode.ToString() +"-" + this.chkSearchingAll.Checked.ToString() + "-" + i.ToString();
                if (this._inputCustomerDic.ContainsKey(customerKey))
                {
                    this.uGrid_Details.Rows[0].Cells[i].Value = this._inputCustomerDic[customerKey];
                    if (_customerSearchMode == CustomerSearchMode.Customer)
                    {
                        if (!string.IsNullOrEmpty( this._inputCustomerDic[customerKey].ToString()) && CustomerIsExist(this._inputCustomerDic[customerKey], ref name))
                        {
                            this.uGrid_Details.Rows[1].Cells[i].Value = name;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty( this._inputCustomerDic[customerKey].ToString()) && CustomerGIsExist(this._inputCustomerDic[customerKey], ref name))
                        {
                            this.uGrid_Details.Rows[1].Cells[i].Value = name;
                        }
                    }
                }
                else
                {
                    this.uGrid_Details.Rows[0].Cells[i].Value = string.Empty;
                    this.uGrid_Details.Rows[1].Cells[i].Value = string.Empty;
                }
            }
            #endregion　範囲指定状態変更後、前入力値を渡す
            #region 仕入先、得意先掛率G(得意先）三つ項目欄に条件が入力ある時、行追加ボタンを操作可にする
            if (this.tNedit_SupplierCd.GetInt() > 0)
            {
                Boolean hasInputSearchData = false;

                for (int index = 9; index < this.uGrid_Details.Rows[0].Cells.Count; index++)
                {
                    if (!string.IsNullOrEmpty(this.uGrid_Details.Rows[0].Cells[index].Text.Trim())
                        && (uGrid_Details.DisplayLayout.Bands[0].Columns[index].Hidden == false))
                    {
                        hasInputSearchData = true;
                        break;
                    }
                }

                if (hasInputSearchData)
                {
                    this.Add_Button.Enabled = true;
                }
                else
                {
                    this.Add_Button.Enabled = false;
                }
            }
            else
            {
                this.Add_Button.Enabled = false;
            }
            #endregion 仕入先、得意先掛率G(得意先）三つ項目欄に条件が入力ある時、行追加ボタンを操作可にする
            this.uGrid_Details.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Details_AfterCellUpdate);
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
                this.Form1_Top_Panel5.Size = new Size(295, 23);
                this.uLabel_SaleRate.Size = new Size(295, 23);
                this.uLabel_SaleRate.Appearance.FontData.SizeInPoints = 11;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                this.uLabel_SaleRate.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                this.uLabel_CustomerMode.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                switch ((int)this.tComboEditor_GridFontSize.Value)
                {
                    case 6:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 31);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 15);
                            break;
                        }
                    case 8:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 28);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 18);
                            break;
                        }
                    case 9:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 26);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 20);
                            break;
                        }
                    case 10:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 25);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 21);
                            break;
                        }
                    case 11:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 23);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 23);
                            break;
                        }
                    case 12:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 22);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 24);
                            break;
                        }
                    case 14:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 19);
                            int width = this.panel3.Size.Width;
                            this.panel3.Size = new Size(width, 27);
                            break;
                        }
                }
            }

            // グリッドにスクロールバー売価率ラベルの制御
            ScrollControl();
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                # region 拠点コード
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        // 入力コードによって、名称を設定する
                        SetNameByCode(e.PrevCtrl.Name, e);

                        if (e.NextCtrl != this.tEdit_SectionCodeAllowZero)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                    e.NextCtrl = null;
                                else
                                {
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != String.Empty)
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                    else
                                        e.NextCtrl = this.SectionGuide_Button;
                                }
                            }
                        }

                        break;
                    }
                # endregion

                #region 仕入先コード
                // 仕入先コード
                case "tNedit_SupplierCd":
                    {
                        // 入力コードによって、名称を設定する
                        SetNameByCode(e.PrevCtrl.Name, e);

                        if (e.NextCtrl != this.tNedit_SupplierCd)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                {
                                    e.NextCtrl = SectionGuide_Button;
                                }
                                else
                                {
                                    if (tNedit_SupplierCd.Text.Trim() != String.Empty)
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                    else
                                        e.NextCtrl = SupplierGuide_Button;
                                }
                            }
                        }

                        break;
                    }
                # endregion

                #region 商品掛率Ｇコード
                // 商品掛率Ｇコード
                case "tNedit_GoodsMGroup":
                    {
                        // 入力コードによって、名称を設定する
                        SetNameByCode(e.PrevCtrl.Name, e);

                        if (e.NextCtrl != this.tNedit_GoodsMGroup)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                {
                                    e.NextCtrl = MakerGuide_Button;
                                }
                                else
                                {
                                    if (this.tNedit_GoodsMGroup.Text.Trim() != String.Empty)
                                    {
                                        if (Expand_Button.Enabled)
                                            e.NextCtrl = Expand_Button;
                                        else if (AllExpand_Button.Enabled)
                                            e.NextCtrl = AllExpand_Button;
                                        else if (chkSearchingAll.Enabled)
                                            e.NextCtrl = chkSearchingAll;
                                        else
                                            e.NextCtrl = uGrid_Details;
                                    }
                                    else
                                        e.NextCtrl = GoodsRateGrpGuide_Button;
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (this.chkSearchingAll.Enabled)
                                    e.NextCtrl = this.chkSearchingAll;
                                else
                                    e.NextCtrl = this.uGrid_Details;
                            }
                        }
                        break;
                    }
                # endregion

                #region 商品掛率Ｇガイド
                case "GoodsRateGrpGuide_Button":
                    if (e.Key == Keys.Down)
                    {
                        if (this.chkSearchingAll.Enabled)
                            e.NextCtrl = this.chkSearchingAll;
                        else
                            e.NextCtrl = this.uGrid_Details;
                    }
                    break;
                #endregion

                #region 層別
                case "GoodsRateRank_tEdit":
                    if (e.Key == Keys.Down)
                    {
                        if (this.chkSearchingAll.Enabled)
                            e.NextCtrl = this.chkSearchingAll;
                        else
                            e.NextCtrl = this.uGrid_Details;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (this.tNedit_GoodsMGroup.Enabled)
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        else
                            e.NextCtrl = null;
                    }
                    break;
                #endregion

                # region メーカーコード
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        // 入力コードによって、名称を設定する
                        SetNameByCode(e.PrevCtrl.Name, e);

                        if (e.NextCtrl != this.tNedit_GoodsMakerCd)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (e.ShiftKey)
                                {
                                    e.NextCtrl = this.SupplierGuide_Button;
                                }
                                else
                                {
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != String.Empty)
                                    {
                                        if (tNedit_GoodsMGroup.Enabled)
                                            e.NextCtrl = tNedit_GoodsMGroup;
                                        else
                                            e.NextCtrl = GoodsRateRank_tEdit;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                        
                                }
                            }
                            else if (e.Key == Keys.Down)
                            {
                                if (this.AllExpand_Button.Enabled)
                                    e.NextCtrl = this.AllExpand_Button;
                                else if (this.Add_Button.Enabled)
                                {
                                    e.NextCtrl = this.Add_Button;
                                }
                            }
                            else
                            {
                            }

                            // メーカー備考メッセージ
                            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                            {
                                this.uLabel_Message.Text = MSG_MAKERNOINTPUT;
                            }
                            else
                            {
                                this.uLabel_Message.Text = string.Empty;
                            }
                        }
                        break;
                    }
                # endregion

                #region メーカーガイド
                case "MakerGuide_Button":
                    if (e.Key == Keys.Down)
                    {
                        if (this.Add_Button.Enabled)
                        {
                            e.NextCtrl = this.Add_Button;
                        }
                    }
                    break;
                #endregion

                #region 展開
                case "Expand_Button":
                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        if (e.ShiftKey 
                            && e.NextCtrl == this.GoodsRateGrpGuide_Button
                            && this.tNedit_GoodsMGroup.Text.Trim() != String.Empty)
                        {
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        }
                    }
                    break;
                #endregion

                #region 全展開
                case "AllExpand_Button":
                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                    {
                        if (e.ShiftKey
                            && e.NextCtrl == this.GoodsRateGrpGuide_Button
                            && this.tNedit_GoodsMGroup.Text.Trim() != String.Empty)
                        {
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        }
                    }
                    break;
                #endregion

                #region 行追加
                case "Add_Button":
                    if (e.Key == Keys.Up)
                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                    else if (e.Key == Keys.Right)
                    {
                        if (this.tNedit_GoodsMGroup.Enabled)
                            e.NextCtrl = this.tNedit_GoodsMGroup;
                        else if (this.GoodsRateRank_tEdit.Enabled)
                            e.NextCtrl = this.GoodsRateRank_tEdit;
                    }
                    break;
                #endregion

                # region グリッド
                // グリッド
                case "uGrid_Details":
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (e.ShiftKey)
                            {
                                if (MoveToAllowEditCell(false) == CellMoveState.MustJump)
                                {
                                    e.NextCtrl = null;
                                    // 行選択後、Shift+TabキーまたはShift+Enterキーでフォーカスが移動制御
                                    for (int rowIdx = this.uGrid_Details.ActiveRow.Index; rowIdx > -1; rowIdx--)
                                    {
                                        int colIdx = this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1;
                                        if (rowIdx == this.uGrid_Details.ActiveRow.Index) colIdx = 0;
                                        for (; colIdx > -1; colIdx--)
                                        {
                                            if (!uGrid_Details.Rows[rowIdx].Hidden
                                                && !uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.Hidden
                                                && uGrid_Details.Rows[rowIdx].Cells[colIdx].Activation == Activation.AllowEdit
                                                && uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.CellActivation == Activation.AllowEdit)
                                            {
                                                uGrid_Details.Rows[rowIdx].Cells[colIdx].Activate();
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                return;
                                            }
                                        }
                                    }
                                    if (chkSearchingAll.Enabled)
                                        e.NextCtrl = this.chkSearchingAll;
                                    else
                                        e.NextCtrl = Add_Button;
                                }
                                else e.NextCtrl = null;
                            }
                            else
                            {
                                if (MoveToAllowEditCell(true) == CellMoveState.MustJump)
                                {
                                    e.NextCtrl = null;
                                    if (this.uGrid_Details.ActiveCell != null) return;
                                    // 行選択後、TabキーまたはEnterキーでフォーカスが移動制御
                                    for (int rowIdx = this.uGrid_Details.ActiveRow.Index; rowIdx < this.uGrid_Details.Rows.Count; rowIdx++)
                                    {
                                        int colIdx = 0;
                                        if (rowIdx == this.uGrid_Details.ActiveRow.Index) colIdx = 0;
                                        for (; colIdx < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; colIdx++)
                                        {
                                            if (!uGrid_Details.Rows[rowIdx].Hidden
                                                && !uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.Hidden
                                                && uGrid_Details.Rows[rowIdx].Cells[colIdx].Activation == Activation.AllowEdit
                                                && uGrid_Details.Rows[rowIdx].Cells[colIdx].Column.CellActivation == Activation.AllowEdit)
                                            {
                                                uGrid_Details.Rows[rowIdx].Cells[colIdx].Activate();
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                    e.NextCtrl = null;
                            }
                        }

                        if ((e.NextCtrl != null) && (e.NextCtrl.Name == "Expand_Button"))
                        {
                            if (null != this.uGrid_Details.ActiveCell)
                            {
                                // 展開ボタンをクリックすると前回ActiveCellを記録する
                                _prevActiveUltraGridCellCol = this.uGrid_Details.ActiveCell.Column.Index;
                                _prevActiveUltraGridCellRow = this.uGrid_Details.ActiveCell.Row.Index;
                            }
                        }
                        break;
                    }
                # endregion
            } 

            if (e.NextCtrl == null)
            {
                return;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_SectionCodeAllowZero":
                        {
                            if (((TEdit)e.NextCtrl).Value == null)
                            {
                                this._prevCode = string.Empty;
                            }
                            else
                            {
                                this._prevCode = ((TEdit)e.NextCtrl).Value.ToString();
                            }
                            this.AdjustButtonEnable(1, true);
                            break;
                        }
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_SupplierCd":
                    case "tNedit_GoodsMGroup":
                        {
                            if (((TNedit)e.NextCtrl).Value == null)
                            {
                                this._prevCode = string.Empty;
                            }
                            else
                            {
                                this._prevCode = ((TNedit)e.NextCtrl).Value.ToString();
                            }
                            this.AdjustButtonEnable(1, true);
                            break;
                        }
                    case "SectionGuide_Button":
                    case "SupplierGuide_Button":
                    case "MakerGuide_Button":
                    case "GoodsRateGrpGuide_Button":
                        {
                            this.AdjustButtonEnable(1, true);
                            break;
                        }
                    case "Expand_Button":
                    case "AllExpand_Button":
                    case "GoodsRateRank_tEdit":
                    case "Add_Button":
                    case "chkSearchingAll":
                        {
                            this.AdjustButtonEnable(1, false);
                            break;
                        }
                    case "uGrid_Details":
                        {
                            // キーボード操作
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                mouseFlag = false;
                            }
                            // [↓]キー操作
                            else if (e.Key == Keys.Down)
                            {
                                mouseFlag = false;
                            }
                            // マウス操作
                            else
                            {
                                mouseFlag = true;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キー押下された時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private void PMKHN09902UA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 展開
                case Keys.F11:
                    {
                        // 展開できる場合
                        if (this.Expand_Button.Enabled)
                        {
                            Expand_Button_Click(this.Expand_Button, new EventArgs());
                        }
                        break;
                    }
                // 全展開
                case Keys.F12:
                    {
                        // 全展開できる場合
                        if (this.AllExpand_Button.Enabled)
                        {
                           AllExpand_Button_Click(this.AllExpand_Button, new EventArgs());
                        }
                        break;
                    }
                // 行追加
                case Keys.F3:
                    {
                        // 行追加できる場合
                        if (this.Add_Button.Enabled)
                        {
                            Add_Button_Click(this.Add_Button, new EventArgs());
                        }
                        break;
                    }
            }

        }

        /// <summary>
        /// Excel出力：出力ファイルの設定処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : Excel出力：出力ファイルの設定処理します。</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/02/17</br>
        /// </remarks>
        private void ultraGridExcelExporter_EndExport(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.EndExportEventArgs e)
        {
            // 最大列数
            const int maxColumnsCount = 107;
            // 掛率起始入力行
            const int rowStartIndex = RATESTARTROW;
            // 得意先検索条件と掛率起始入力列
            const int columnStartIndex = RATESTARTCOLUMN;
            // 商品掛率Ｇ・層別列
            const int goodsMGColumnNo = 0;
        　　// ＢＬグループコード列
            const int grcdColumnNo = 1;
            // セルマージ
            Dictionary<int, int> rowPosDic = new Dictionary<int, int>();
            CellMerge(ref e, goodsMGColumnNo, ref rowPosDic);
            CellMerge(ref e, grcdColumnNo, ref rowPosDic);
            
            // 得意先検索条件タイトル設定
            e.CurrentWorksheet.Rows[0].Cells[columnStartIndex].Value = uLabel_CustomerMode.Text;// タイトル名
            e.CurrentWorksheet.Rows[0].Height = e.CurrentWorksheet.Rows[1].Height;
            // 得意先検索条件タイトルの非表示列設定
            for (int i = 0; i < columnStartIndex; i++)
            {
                e.CurrentWorksheet.Rows[0].Cells[i].Value = string.Empty;
                e.CurrentWorksheet.Rows[0].Cells[i].CellFormat.FillPattern = Infragistics.Excel.FillPatternStyle.None;
                e.CurrentWorksheet.Rows[0].Cells[i].CellFormat.BottomBorderStyle = Infragistics.Excel.CellBorderLineStyle.None;
                e.CurrentWorksheet.Rows[0].Cells[i].CellFormat.LeftBorderStyle = Infragistics.Excel.CellBorderLineStyle.None;
                e.CurrentWorksheet.Rows[0].Cells[i].CellFormat.RightBorderStyle = Infragistics.Excel.CellBorderLineStyle.None;
                e.CurrentWorksheet.Rows[0].Cells[i].CellFormat.TopBorderStyle = Infragistics.Excel.CellBorderLineStyle.None;
            }
            // 得意先検索条件と掛率入力列数取得
            int columnEndIndex = columnStartIndex;
            for (int i = columnStartIndex; i < maxColumnsCount; i++)
            {
                if (e.CurrentWorksheet.Rows[2].Cells[i].Value!=null)// 2 : 入力した得意先検索条件表示行
                {
                    if (e.CurrentWorksheet.Rows[2].Cells[i].Value.ToString() != string.Empty)
                    {
                        columnEndIndex = i;
                    } 
                }
            }
            // 小数点表示設定
            for (int rowIndex = rowStartIndex; rowIndex < e.CurrentRowIndex; rowIndex++)
            {
                // 仕入率
                if (DoubleObjToDouble(e.CurrentWorksheet.Rows[rowIndex].Cells[RATESTARTCOLUMN - 1].Value) != 0)// 6 : 仕入率表示列の列番号
                {
                    e.CurrentWorksheet.Rows[rowIndex].Cells[RATESTARTCOLUMN - 1].Value = Convert.ToDouble(e.CurrentWorksheet.Rows[rowIndex].Cells[RATESTARTCOLUMN - 1].Value).ToString("0.00");
                }
                for (int columnIndex = columnStartIndex; columnIndex <= columnEndIndex; columnIndex++)
                {
                    e.CurrentWorksheet.Rows[3].Cells[columnIndex].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left;// 3 : 検索条件名称行番号
                    // 売価率・原価ＵＰ率・粗利確保率の小数点表示設定
                    if (DoubleObjToDouble(e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value) != 0)
                    {
                        // 売価率・原価ＵＰ率・粗利確保率の小数点表示区分設定
                        e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value = Convert.ToDouble(e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].Value).ToString("0.00");
                    }
                    // 掛率の表示位置設定
                    e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Right;
                    // 掛率表示列の文字型式設定
                    e.CurrentWorksheet.Rows[rowIndex].Cells[columnIndex].CellFormat.FormatString = "@";//「Text」型
                }
            }
            // タイトル行に表示文字が同じのセルのマージ
            e.CurrentWorksheet.MergedCellsRegions.Add(0, columnStartIndex, 0, columnEndIndex);// 0 : 得意先タイトル行の行番号
            e.CurrentWorksheet.MergedCellsRegions.Add(1, columnStartIndex, 1, columnEndIndex);// 1 : グリードのタイトル行の行番号

            // タイトルのマージ後のセルの表示文字位置の設定
            e.CurrentWorksheet.Rows[0].Cells[columnStartIndex].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left;// 0 : 得意先タイトル行の行番号
            e.CurrentWorksheet.Rows[1].Cells[columnStartIndex].CellFormat.Alignment = Infragistics.Excel.HorizontalCellAlignment.Left;// 1 : グリードのタイトル行の行番号
            
            // 出力後の掛率表示位置調整
            SetDisplayRateFormat(ref e, columnEndIndex);
            
        }
        #endregion ■ Control Events

        # region [グリッドセル結合判定クラス]
        /// <summary>
        /// グリッドセル結合判定クラス(カスタマイズ)
        /// </summary>
        private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>結合条件セルリスト</summary>
            private List<string> _joinColList;
            /// <summary>
            /// 結合条件セルリスト
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }

            /// <summary>
            /// セル結合判定処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// セルValue比較処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                if (string.IsNullOrEmpty(row1.Cells[columnName].Value.ToString()) && string.IsNullOrEmpty(row2.Cells[columnName].Value.ToString()))
                {
                    return false;
                }
                else
                {
                    return ((row1.Cells[columnName].Value.ToString() == row2.Cells[columnName].Value.ToString())
                            && row1.Cells[COLUMN_MAKERCODE].Value.ToString() == row2.Cells[COLUMN_MAKERCODE].Value.ToString());
                }
                
            }
        }
        # endregion

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2013/02/19</br>
        /// </remarks>
        private void Print()
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = new SFCMN06002C();	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ASSEMBLY_ID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = PDF_PRINT_NAME;
            printInfo.printmode = 2; // PDF表示

            // テンプレートの選択
            printInfo.PrintPaperSetCd = 1;　// 得意先・得意先掛率Gは同じPDFモードです 

            // 抽出条件の設定
            printInfo.jyoken = this._extrInfo;

            // PDF出力DateSet設定
            printInfo.rdData = InitPdfDataSet();

            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.pdfopen)
            {
                PMKHN09902UC pdfForm = new PMKHN09902UC((this.Parent as Form));
                try
                {
                    //-----------------------------------------------------
                    // 【注意】
                    // Debugモードの場合、１度でもPDF表示すると
                    // 電子元帳本体を閉じる際にエラー発生します。
                    //
                    // DCCMN04000UBのDispose内のPDFShowのタイミングで発生。
                    // →「基になるRCWから分割されたCOMオブジェクトを使うことはできません。」
                    // 
                    // Releaseモードでビルドすると発生しません。
                    //-----------------------------------------------------
                    pdfForm.PDFShow(printInfo.pdftemppath);
                }
                finally
                {
                    pdfForm.Close();
                    pdfForm.Dispose();
                }
            }
        }

        /// <summary>
        /// PDF出力用Dataset設定処理
        /// </summary>
        /// <br>Note		: PDF出力用Dataset設定処理を行う。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2013/02/19</br>
        /// <returns></returns>
        private DataSet InitPdfDataSet()
        {
            // 1 初期化DataSet
            DataSet dataset = new DataSet();
            PMKHN09903EC.CreateDataTable(ref dataset);
            DataTable mytable = dataset.Tables[PMKHN09903EC.ct_Tbl_ReportData];

            // 2 入力検索条件取得
            // 全て入力検索条件
            //     Dictionaryのkey：   string 得意先コード/得意先掛率Ｇ
            //     Dictionaryのvalue： int    Column番号
            Dictionary<string, int> allIntputSearchDic = new Dictionary<string, int>();
            UltraGridRow inputSearchRow = uGrid_Details.Rows[0];

            for (int k = 0; k < inputSearchRow.Cells.Count; k++)
            {
                // 入力検索条件の取得処理、値があって、VISIBLEがある。
                if (!String.IsNullOrEmpty(inputSearchRow.Cells[k].Value.ToString().Trim())
                    && (!this.uGrid_Details.DisplayLayout.Bands[0].Columns[k].Hidden))
                {
                    // 入力検索条件がある
                    allIntputSearchDic.Add(inputSearchRow.Cells[k].Value.ToString(), k);
                }
            }

            // 3 ヘッダ名称設定
            // コラム1のヘッダ名称（"商品掛率Ｇ/層別）
            string tempCol1HeadValue = "";
            if (_goodsMode == GoodsMode.GoodsRateG)
            {
                tempCol1HeadValue = "商品掛率Ｇ";
            }
            else
            {
                tempCol1HeadValue = "層別";
            }

            string tempRateVal = ""; // ヘッダの名称設定
            if (_rateMode == RateMode.RateVal)
            {
                tempRateVal = RATE_TITLE_RATEVAL;　// 売価率
            }
            else if (_rateMode == RateMode.UpRate)
            {
                tempRateVal = RATE_TITLE_UPRATE; // 原価ＵＰ率
            }
            else
            {
                tempRateVal = RATE_TITLE_GRSPROFITSECURERAT; // 粗利確保率
            }

            int tempColNum = 0;
            int colMaxNum = 0; // PDFで表示した入力検索Column表示数（得意先ＣＤモード：10コラム；得意先掛率Ｇモード：20コラム）
            if (_customerSearchMode == CustomerSearchMode.Customer)
            {
                colMaxNum = 10; // 得意先ＣＤモード：10コラム
            }
            else
            {
                colMaxNum = 10; // 得意先掛率Ｇモード：10コラム(All + 9コラムの得意先掛率)
            }

            // tempDic
            Dictionary<string, int> tempDic = new Dictionary<string, int>();

            // 入力検索条件があるの場合、続き設定します
            // 得意コードの場合：
            //          ０１～１０
            //          １１～２０
            //          ２１～２５
            //---------------------
            // 得意先掛率Ｇの場合：
            //          ALL～０９
            //          １０～１９
            while ((allIntputSearchDic != null) && (allIntputSearchDic.Values.Count > 0))
            {
                
                tempColNum = 0;
                tempDic = new Dictionary<string, int>();
                // TEMP用得意先コード・得意先掛率G設定
                foreach (KeyValuePair<string, int> tempValue in allIntputSearchDic)
                {
                    tempColNum++;

                    // colMaxNumの説明します
                    // 得意先コードの場合、colMaxNumは「10」です。
                    // 得意先掛率Gの場合、colMaxNumは「10」です。
                    if (tempColNum > colMaxNum)
                    {
                        break;
                    }

                    // 
                    tempDic.Add(tempValue.Key, tempValue.Value);
                }

                // 全てDicから、今回設定したの得意先コード・得意先掛率Gを削除します。
                foreach (KeyValuePair<string, int> tempValue in tempDic)
                {
                    allIntputSearchDic.Remove(tempValue.Key);
                }

                // 前回1コラムの値
                string beforeCol1ShowValue = ""; // 前回の商品掛率G/層別（PDFのセルマージ処理用）
                string beforeCol2ShowGlcd = "";　// 前回のBLコードG（PDFのセルマージ処理用）

                string beforeMakerValue = "";// 前回メーカーコード

                // 第二行は検索条件入力行
                // 第三行から、値を設定処理を行います。
                for (int rowCount = 2; rowCount < uGrid_Details.Rows.Count; rowCount++)
                {
                    // 新規DataRow
                    DataRow myrow = mytable.NewRow();
                    // Col1 ヘッダ名称
                    myrow[PMKHN09903EC.ct_Col_Col1HeadValue] = tempCol1HeadValue;

                    // Col1データ設定
                    if (_goodsMode == GoodsMode.GoodsRateG)
                    {
                        if (beforeCol1ShowValue == "")
                        {
                            beforeCol1ShowValue = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text;

                            // 商品掛率Ｇの場合
                            myrow[PMKHN09903EC.ct_Col_Col1ShowValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text;
                        }
                        else
                        {
                            // 前回と今回は不同です。
                            if (beforeCol1ShowValue != uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text)
                            {
                                beforeCol1ShowValue = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text;

                                // 商品掛率Ｇの場合
                                myrow[PMKHN09903EC.ct_Col_Col1ShowValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text;
                            }
                            else
                            {
                                if (beforeMakerValue != "")
                                {
                                    // 前回メーカーコード不正の場合、
                                    if (beforeMakerValue != uGrid_Details.Rows[rowCount].Cells[COLUMN_MAKERCODE].Text)
                                    {
                                        // 商品掛率Ｇの場合
                                        myrow[PMKHN09903EC.ct_Col_Col1ShowValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text;
                                    }
                                }
                            }
                        }    
                    
                        // Col1本体の値を設定します
                        myrow[PMKHN09903EC.ct_Col_Col1HideValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATEGRPCODE].Text;
                    }
                    else
                    {
                        if (beforeCol1ShowValue == "")
                        {
                            beforeCol1ShowValue = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text;

                            // 層別の場合
                            myrow[PMKHN09903EC.ct_Col_Col1ShowValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text;
                        }
                        else
                        {
                            // 前回と今回は不同です。
                            if (beforeCol1ShowValue != uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text)
                            {
                                beforeCol1ShowValue = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text;

                                // 層別の場合
                                myrow[PMKHN09903EC.ct_Col_Col1ShowValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text;
                            }
                            else
                            {
                                if (beforeMakerValue != "")
                                {
                                    // 前回メーカーコード不正の場合、
                                    if (beforeMakerValue != uGrid_Details.Rows[rowCount].Cells[COLUMN_MAKERCODE].Text)
                                    {
                                        // 層別の場合
                                        myrow[PMKHN09903EC.ct_Col_Col1ShowValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text;
                                    }
                                }
                            }
                        }

                        myrow[PMKHN09903EC.ct_Col_Col1HideValue] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GOODSRATERANK].Text;
                    }

                    // BLコードG
                    // PDFセルのマージについて、チェック処理を行います
                    if (beforeCol2ShowGlcd == "")
                    {
                        beforeCol2ShowGlcd = uGrid_Details.Rows[rowCount].Cells[COLUMN_GLCD].Text;
                        myrow[PMKHN09903EC.ct_Col_Col2ShowGlcd] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GLCD].Text;// BLコードG
                    }
                    else
                    {
                        if (beforeCol2ShowGlcd != uGrid_Details.Rows[rowCount].Cells[COLUMN_GLCD].Text)
                        {
                            beforeCol2ShowGlcd = uGrid_Details.Rows[rowCount].Cells[COLUMN_GLCD].Text;
                            myrow[PMKHN09903EC.ct_Col_Col2ShowGlcd] = uGrid_Details.Rows[rowCount].Cells[COLUMN_GLCD].Text;// BLコードG
                        }
                    }
                    
                    // 層別・商品掛率Gの値がある、また、Gridの「名称」列の値があるの場合。
                    if ((myrow[PMKHN09903EC.ct_Col_Col1ShowValue].ToString() != "")
                        && (!string.IsNullOrEmpty(uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text)))
                    {
                        myrow[PMKHN09903EC.ct_Col_Col2Name] = uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text;
                    }

                    // BLコード
                    myrow[PMKHN09903EC.ct_Col_Col3Blcd] = uGrid_Details.Rows[rowCount].Cells[COLUMN_BLCD].Text;

                    // BLコードGの名称設定
                    if ((myrow[PMKHN09903EC.ct_Col_Col2ShowGlcd].ToString() != "")
                        && (string.IsNullOrEmpty(uGrid_Details.Rows[rowCount].Cells[COLUMN_BLCD].Text))
                        && (!string.IsNullOrEmpty(uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text)))
                    {
                        myrow[PMKHN09903EC.ct_Col_Col3GlcdName] = uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text;
                    }

                    // BLコード名称設定
                    if (myrow[PMKHN09903EC.ct_Col_Col3Blcd].ToString() != "")
                    {
                        if (!string.IsNullOrEmpty(uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text)
                            && uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text.Length > 26)
                        {
                            String tempStr = uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text.Substring(0, 26);
                            myrow[PMKHN09903EC.ct_Col_Col4BLCodeName] = tempStr;
                        }
                        else
                        {
                            myrow[PMKHN09903EC.ct_Col_Col4BLCodeName] = uGrid_Details.Rows[rowCount].Cells[COLUMN_NAME].Text;
                        }
                    }

                    // メーカー
                    myrow[PMKHN09903EC.ct_Col_Col5Maker] = uGrid_Details.Rows[rowCount].Cells[COLUMN_MAKERCODE].Text;
                    // 仕入率
                    if (!String.Empty.Equals(uGrid_Details.Rows[rowCount].Cells[COLUMN_COSTRATE].Text))
                    {
                        //仕入率小数表示設定
                        myrow[PMKHN09903EC.ct_Col_Col6CostRate] = Convert.ToDouble(uGrid_Details.Rows[rowCount].Cells[COLUMN_COSTRATE].Text).ToString("0.00");
                    }
                    else
                    {
                        myrow[PMKHN09903EC.ct_Col_Col6CostRate] = uGrid_Details.Rows[rowCount].Cells[COLUMN_COSTRATE].Text;
                    }

                    // 得意先掛率Ｇの場合、All設定
                    if (_customerSearchMode == CustomerSearchMode.CustomerRateG)
                    {
                        myrow[PMKHN09903EC.ct_Col_Col7All] = "";
                    }
                    // 売価率/原価ＵＰ率/ 粗利確保率の設定
                    myrow[PMKHN09903EC.ct_Col_Row1Name] = tempRateVal;

                    int s = 0;
                    foreach (KeyValuePair<string, int> tempValue in tempDic)
                    {
                        s++;
                        myrow["Col" + s + "InputHeadName"] = tempValue.Key; // 検索条件

                        if (!string.IsNullOrEmpty(uGrid_Details.Rows[1].Cells[tempValue.Value].Text))
                        {
                            myrow["Col" + s + "InputHeadNm"] = GetStringByMaxLength(uGrid_Details.Rows[1].Cells[tempValue.Value].Text, 4); // 検索条件の名称
                        }

                        myrow["Col" + s + "InputValue"] = uGrid_Details.Rows[rowCount].Cells[tempValue.Value].Text;
                    }

                    // 前回メーカーコード記録
                    beforeMakerValue = uGrid_Details.Rows[rowCount].Cells[COLUMN_MAKERCODE].Text;

                    mytable.Rows.Add(myrow);
                }　// END OF [for (int rowCount = 1; rowCount < uGrid_Details.Rows.Count; rowCount++)]
            } // END OF[while ((allIntputSearchDic != null) && (allIntputSearchDic.Values.Count > 0))]

            return dataset;
        }

        /// <summary>
        /// 文字列切れる処理
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="maxLenght">全角長さ</param>
        /// <returns>切れた文字列</returns>
        private string GetStringByMaxLength(string s, int maxLenght)
        {
            maxLenght = maxLenght * 2;
            int nowLength = 0;
            int nowPoint = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (nowLength + Encoding.Default.GetByteCount(s.Substring(i, 1)) <= maxLenght)
                {
                    nowPoint = i;
                    nowLength = nowLength + Encoding.Default.GetByteCount(s.Substring(i, 1));
                }
                else
                {
                    break;
                }
            }


            return s.Substring(0, nowPoint + 1);
        }

        #endregion ◎ 印刷処理

    }
}