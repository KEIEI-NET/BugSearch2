using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePStockMoveDetailWork
    /// <summary>
    ///                      自由帳票在庫移動明細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票在庫移動明細データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/01/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePStockMoveDetailWork
    {
        /// <summary>在庫移動形式</summary>
        /// <remarks>1:在庫移動、2：倉庫移動</remarks>
        private Int32 _mOVD_STOCKMOVEFORMALRF;

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _mOVD_STOCKMOVESLIPNORF;

        /// <summary>在庫移動行番号</summary>
        private Int32 _mOVD_STOCKMOVEROWNORF;

        /// <summary>移動元拠点コード</summary>
        private string _mOVD_BFSECTIONCODERF = "";

        /// <summary>移動元倉庫コード</summary>
        private string _mOVD_BFENTERWAREHCODERF = "";

        /// <summary>移動先拠点コード</summary>
        private string _mOVD_AFSECTIONCODERF = "";

        /// <summary>移動先倉庫コード</summary>
        private string _mOVD_AFENTERWAREHCODERF = "";

        /// <summary>仕入先コード</summary>
        private Int32 _mOVD_SUPPLIERCDRF;

        /// <summary>仕入先略称</summary>
        private string _mOVD_SUPPLIERSNMRF = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _mOVD_GOODSMAKERCDRF;

        /// <summary>メーカー名称</summary>
        private string _mOVD_MAKERNAMERF = "";

        /// <summary>商品番号</summary>
        private string _mOVD_GOODSNORF = "";

        /// <summary>商品名称</summary>
        private string _mOVD_GOODSNAMERF = "";

        /// <summary>商品名称カナ</summary>
        private string _mOVD_GOODSNAMEKANARF = "";

        /// <summary>在庫区分</summary>
        /// <remarks>0:自社、1:受託</remarks>
        private Int32 _mOVD_STOCKDIVRF;

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _mOVD_STOCKUNITPRICEFLRF;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _mOVD_TAXATIONDIVCDRF;

        /// <summary>移動数</summary>
        private Double _mOVD_MOVECOUNTRF;

        /// <summary>移動元棚番</summary>
        private string _mOVD_BFSHELFNORF = "";

        /// <summary>移動先棚番</summary>
        private string _mOVD_AFSHELFNORF = "";

        /// <summary>BL商品コード</summary>
        private Int32 _mOVD_BLGOODSCODERF;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _mOVD_BLGOODSFULLNAMERF = "";

        /// <summary>定価（浮動）</summary>
        private Double _mOVD_LISTPRICEFLRF;

        /// <summary>移動状態</summary>
        /// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
        private Int32 _mOVD_MOVESTATUSRF;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGOODSCDURF_BLGOODSHALFNAMERF = "";

        /// <summary>メーカー略称</summary>
        private string _mAKERURF_MAKERSHORTNAMERF = "";

        /// <summary>メーカーカナ名称</summary>
        private string _mAKERURF_MAKERKANANAMERF = "";

        /// <summary>重複棚番１</summary>
        private string _sTC1_DUPLICATIONSHELFNO1RF = "";

        /// <summary>重複棚番２</summary>
        private string _sTC1_DUPLICATIONSHELFNO2RF = "";

        /// <summary>部品管理区分１</summary>
        private string _sTC1_PARTSMANAGEMENTDIVIDE1RF = "";

        /// <summary>部品管理区分２</summary>
        private string _sTC1_PARTSMANAGEMENTDIVIDE2RF = "";

        /// <summary>在庫備考１</summary>
        private string _sTC1_STOCKNOTE1RF = "";

        /// <summary>在庫備考２</summary>
        private string _sTC1_STOCKNOTE2RF = "";

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</remarks>
        private Double _sTC1_SHIPMENTPOSCNTRF;

        /// <summary>重複棚番１</summary>
        private string _sTC2_DUPLICATIONSHELFNO1RF = "";

        /// <summary>重複棚番２</summary>
        private string _sTC2_DUPLICATIONSHELFNO2RF = "";

        /// <summary>部品管理区分１</summary>
        private string _sTC2_PARTSMANAGEMENTDIVIDE1RF = "";

        /// <summary>部品管理区分２</summary>
        private string _sTC2_PARTSMANAGEMENTDIVIDE2RF = "";

        /// <summary>在庫備考１</summary>
        private string _sTC2_STOCKNOTE1RF = "";

        /// <summary>在庫備考２</summary>
        private string _sTC2_STOCKNOTE2RF = "";

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</remarks>
        private Double _sTC2_SHIPMENTPOSCNTRF;

        /// <summary>仕入先名1</summary>
        private string _sUP_SUPPLIERNM1RF = "";

        /// <summary>仕入先名2</summary>
        private string _sUP_SUPPLIERNM2RF = "";

        /// <summary>仕入先敬称</summary>
        private string _sUP_SUPPHONORIFICTITLERF = "";

        /// <summary>仕入先カナ</summary>
        private string _sUP_SUPPLIERKANARF = "";

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private Int32 _sUP_PURECODERF;

        /// <summary>仕入先備考1</summary>
        private string _sUP_SUPPLIERNOTE1RF = "";

        /// <summary>仕入先備考2</summary>
        private string _sUP_SUPPLIERNOTE2RF = "";

        /// <summary>仕入先備考3</summary>
        private string _sUP_SUPPLIERNOTE3RF = "";

        /// <summary>仕入先備考4</summary>
        private string _sUP_SUPPLIERNOTE4RF = "";

        /// <summary>商品名称カナ</summary>
        private string _gDS_GOODSNAMEKANARF = "";

        /// <summary>JANコード</summary>
        private string _gDS_JANRF = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _gDS_GOODSRATERANKRF = "";

        /// <summary>ハイフン無商品番号</summary>
        private string _gDS_GOODSNONONEHYPHENRF = "";

        /// <summary>商品備考１</summary>
        private string _gDS_GOODSNOTE1RF = "";

        /// <summary>商品備考２</summary>
        private string _gDS_GOODSNOTE2RF = "";

        /// <summary>商品規格・特記事項</summary>
        private string _gDS_GOODSSPECIALNOTERF = "";

        /// <summary>在庫区分名称</summary>
        /// <remarks>0:自社、1:受託</remarks>
        private string _dADD_STOCKDIVNMRF = "";

        /// <summary>課税区分名称</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private string _dADD_TAXATIONDIVCDNMRF = "";

        /// <summary>純正区分名称</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private string _dADD_PURECODENMRF = "";

        /// <summary>移動金額</summary>
        /// <remarks>【仕入単価×移動数】</remarks>
        private Int64 _dADD_STOCKMOVEPRICERF;

        /// <summary>移動金額(標準価格)</summary>
        /// <remarks>【定価×移動数】</remarks>
        private Int64 _dADD_STOCKMOVELISTPRICERF;

        /// <summary>移動元移動前数</summary>
        /// <remarks>移動元倉庫の現在庫数（移動前）</remarks>
        private Double _dADD_BFSTOCKCOUNTPREVRF;

        /// <summary>移動元移動後数</summary>
        /// <remarks>移動元倉庫の現在庫数（移動後）</remarks>
        private Double _dADD_BFSTOCKCOUNTRF;

        /// <summary>移動先移動前数</summary>
        /// <remarks>移動先倉庫の現在庫数（移動前）</remarks>
        private Double _dADD_AFSTOCKCOUNTPREVRF;

        /// <summary>移動先移動後数</summary>
        /// <remarks>移動先倉庫の現在庫数（移動後）</remarks>
        private Double _dADD_AFSTOCKCOUNTRF;

        /// <summary>移動金額</summary>
        private Int64 _mOVD_STOCKMOVEPRICERF;


        /// public propaty name  :  MOVD_STOCKMOVEFORMALRF
        /// <summary>在庫移動形式プロパティ</summary>
        /// <value>1:在庫移動、2：倉庫移動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_STOCKMOVEFORMALRF
        {
            get { return _mOVD_STOCKMOVEFORMALRF; }
            set { _mOVD_STOCKMOVEFORMALRF = value; }
        }

        /// public propaty name  :  MOVD_STOCKMOVESLIPNORF
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_STOCKMOVESLIPNORF
        {
            get { return _mOVD_STOCKMOVESLIPNORF; }
            set { _mOVD_STOCKMOVESLIPNORF = value; }
        }

        /// public propaty name  :  MOVD_STOCKMOVEROWNORF
        /// <summary>在庫移動行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_STOCKMOVEROWNORF
        {
            get { return _mOVD_STOCKMOVEROWNORF; }
            set { _mOVD_STOCKMOVEROWNORF = value; }
        }

        /// public propaty name  :  MOVD_BFSECTIONCODERF
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_BFSECTIONCODERF
        {
            get { return _mOVD_BFSECTIONCODERF; }
            set { _mOVD_BFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVD_BFENTERWAREHCODERF
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_BFENTERWAREHCODERF
        {
            get { return _mOVD_BFENTERWAREHCODERF; }
            set { _mOVD_BFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVD_AFSECTIONCODERF
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_AFSECTIONCODERF
        {
            get { return _mOVD_AFSECTIONCODERF; }
            set { _mOVD_AFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVD_AFENTERWAREHCODERF
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_AFENTERWAREHCODERF
        {
            get { return _mOVD_AFENTERWAREHCODERF; }
            set { _mOVD_AFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVD_SUPPLIERCDRF
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_SUPPLIERCDRF
        {
            get { return _mOVD_SUPPLIERCDRF; }
            set { _mOVD_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  MOVD_SUPPLIERSNMRF
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_SUPPLIERSNMRF
        {
            get { return _mOVD_SUPPLIERSNMRF; }
            set { _mOVD_SUPPLIERSNMRF = value; }
        }

        /// public propaty name  :  MOVD_GOODSMAKERCDRF
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_GOODSMAKERCDRF
        {
            get { return _mOVD_GOODSMAKERCDRF; }
            set { _mOVD_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  MOVD_MAKERNAMERF
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_MAKERNAMERF
        {
            get { return _mOVD_MAKERNAMERF; }
            set { _mOVD_MAKERNAMERF = value; }
        }

        /// public propaty name  :  MOVD_GOODSNORF
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_GOODSNORF
        {
            get { return _mOVD_GOODSNORF; }
            set { _mOVD_GOODSNORF = value; }
        }

        /// public propaty name  :  MOVD_GOODSNAMERF
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_GOODSNAMERF
        {
            get { return _mOVD_GOODSNAMERF; }
            set { _mOVD_GOODSNAMERF = value; }
        }

        /// public propaty name  :  MOVD_GOODSNAMEKANARF
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_GOODSNAMEKANARF
        {
            get { return _mOVD_GOODSNAMEKANARF; }
            set { _mOVD_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  MOVD_STOCKDIVRF
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:自社、1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_STOCKDIVRF
        {
            get { return _mOVD_STOCKDIVRF; }
            set { _mOVD_STOCKDIVRF = value; }
        }

        /// public propaty name  :  MOVD_STOCKUNITPRICEFLRF
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MOVD_STOCKUNITPRICEFLRF
        {
            get { return _mOVD_STOCKUNITPRICEFLRF; }
            set { _mOVD_STOCKUNITPRICEFLRF = value; }
        }

        /// public propaty name  :  MOVD_TAXATIONDIVCDRF
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_TAXATIONDIVCDRF
        {
            get { return _mOVD_TAXATIONDIVCDRF; }
            set { _mOVD_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  MOVD_MOVECOUNTRF
        /// <summary>移動数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MOVD_MOVECOUNTRF
        {
            get { return _mOVD_MOVECOUNTRF; }
            set { _mOVD_MOVECOUNTRF = value; }
        }

        /// public propaty name  :  MOVD_BFSHELFNORF
        /// <summary>移動元棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_BFSHELFNORF
        {
            get { return _mOVD_BFSHELFNORF; }
            set { _mOVD_BFSHELFNORF = value; }
        }

        /// public propaty name  :  MOVD_AFSHELFNORF
        /// <summary>移動先棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_AFSHELFNORF
        {
            get { return _mOVD_AFSHELFNORF; }
            set { _mOVD_AFSHELFNORF = value; }
        }

        /// public propaty name  :  MOVD_BLGOODSCODERF
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_BLGOODSCODERF
        {
            get { return _mOVD_BLGOODSCODERF; }
            set { _mOVD_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  MOVD_BLGOODSFULLNAMERF
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVD_BLGOODSFULLNAMERF
        {
            get { return _mOVD_BLGOODSFULLNAMERF; }
            set { _mOVD_BLGOODSFULLNAMERF = value; }
        }

        /// public propaty name  :  MOVD_LISTPRICEFLRF
        /// <summary>定価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MOVD_LISTPRICEFLRF
        {
            get { return _mOVD_LISTPRICEFLRF; }
            set { _mOVD_LISTPRICEFLRF = value; }
        }

        /// public propaty name  :  MOVD_MOVESTATUSRF
        /// <summary>移動状態プロパティ</summary>
        /// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVD_MOVESTATUSRF
        {
            get { return _mOVD_MOVESTATUSRF; }
            set { _mOVD_MOVESTATUSRF = value; }
        }

        /// public propaty name  :  BLGOODSCDURF_BLGOODSHALFNAMERF
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGOODSCDURF_BLGOODSHALFNAMERF
        {
            get { return _bLGOODSCDURF_BLGOODSHALFNAMERF; }
            set { _bLGOODSCDURF_BLGOODSHALFNAMERF = value; }
        }

        /// public propaty name  :  MAKERURF_MAKERSHORTNAMERF
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKERURF_MAKERSHORTNAMERF
        {
            get { return _mAKERURF_MAKERSHORTNAMERF; }
            set { _mAKERURF_MAKERSHORTNAMERF = value; }
        }

        /// public propaty name  :  MAKERURF_MAKERKANANAMERF
        /// <summary>メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKERURF_MAKERKANANAMERF
        {
            get { return _mAKERURF_MAKERKANANAMERF; }
            set { _mAKERURF_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  STC1_DUPLICATIONSHELFNO1RF
        /// <summary>重複棚番１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC1_DUPLICATIONSHELFNO1RF
        {
            get { return _sTC1_DUPLICATIONSHELFNO1RF; }
            set { _sTC1_DUPLICATIONSHELFNO1RF = value; }
        }

        /// public propaty name  :  STC1_DUPLICATIONSHELFNO2RF
        /// <summary>重複棚番２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC1_DUPLICATIONSHELFNO2RF
        {
            get { return _sTC1_DUPLICATIONSHELFNO2RF; }
            set { _sTC1_DUPLICATIONSHELFNO2RF = value; }
        }

        /// public propaty name  :  STC1_PARTSMANAGEMENTDIVIDE1RF
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC1_PARTSMANAGEMENTDIVIDE1RF
        {
            get { return _sTC1_PARTSMANAGEMENTDIVIDE1RF; }
            set { _sTC1_PARTSMANAGEMENTDIVIDE1RF = value; }
        }

        /// public propaty name  :  STC1_PARTSMANAGEMENTDIVIDE2RF
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC1_PARTSMANAGEMENTDIVIDE2RF
        {
            get { return _sTC1_PARTSMANAGEMENTDIVIDE2RF; }
            set { _sTC1_PARTSMANAGEMENTDIVIDE2RF = value; }
        }

        /// public propaty name  :  STC1_STOCKNOTE1RF
        /// <summary>在庫備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC1_STOCKNOTE1RF
        {
            get { return _sTC1_STOCKNOTE1RF; }
            set { _sTC1_STOCKNOTE1RF = value; }
        }

        /// public propaty name  :  STC1_STOCKNOTE2RF
        /// <summary>在庫備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC1_STOCKNOTE2RF
        {
            get { return _sTC1_STOCKNOTE2RF; }
            set { _sTC1_STOCKNOTE2RF = value; }
        }

        /// public propaty name  :  STC1_SHIPMENTPOSCNTRF
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double STC1_SHIPMENTPOSCNTRF
        {
            get { return _sTC1_SHIPMENTPOSCNTRF; }
            set { _sTC1_SHIPMENTPOSCNTRF = value; }
        }

        /// public propaty name  :  STC2_DUPLICATIONSHELFNO1RF
        /// <summary>重複棚番１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC2_DUPLICATIONSHELFNO1RF
        {
            get { return _sTC2_DUPLICATIONSHELFNO1RF; }
            set { _sTC2_DUPLICATIONSHELFNO1RF = value; }
        }

        /// public propaty name  :  STC2_DUPLICATIONSHELFNO2RF
        /// <summary>重複棚番２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC2_DUPLICATIONSHELFNO2RF
        {
            get { return _sTC2_DUPLICATIONSHELFNO2RF; }
            set { _sTC2_DUPLICATIONSHELFNO2RF = value; }
        }

        /// public propaty name  :  STC2_PARTSMANAGEMENTDIVIDE1RF
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC2_PARTSMANAGEMENTDIVIDE1RF
        {
            get { return _sTC2_PARTSMANAGEMENTDIVIDE1RF; }
            set { _sTC2_PARTSMANAGEMENTDIVIDE1RF = value; }
        }

        /// public propaty name  :  STC2_PARTSMANAGEMENTDIVIDE2RF
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC2_PARTSMANAGEMENTDIVIDE2RF
        {
            get { return _sTC2_PARTSMANAGEMENTDIVIDE2RF; }
            set { _sTC2_PARTSMANAGEMENTDIVIDE2RF = value; }
        }

        /// public propaty name  :  STC2_STOCKNOTE1RF
        /// <summary>在庫備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC2_STOCKNOTE1RF
        {
            get { return _sTC2_STOCKNOTE1RF; }
            set { _sTC2_STOCKNOTE1RF = value; }
        }

        /// public propaty name  :  STC2_STOCKNOTE2RF
        /// <summary>在庫備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STC2_STOCKNOTE2RF
        {
            get { return _sTC2_STOCKNOTE2RF; }
            set { _sTC2_STOCKNOTE2RF = value; }
        }

        /// public propaty name  :  STC2_SHIPMENTPOSCNTRF
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double STC2_SHIPMENTPOSCNTRF
        {
            get { return _sTC2_SHIPMENTPOSCNTRF; }
            set { _sTC2_SHIPMENTPOSCNTRF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNM1RF
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERNM1RF
        {
            get { return _sUP_SUPPLIERNM1RF; }
            set { _sUP_SUPPLIERNM1RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNM2RF
        /// <summary>仕入先名2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERNM2RF
        {
            get { return _sUP_SUPPLIERNM2RF; }
            set { _sUP_SUPPLIERNM2RF = value; }
        }

        /// public propaty name  :  SUP_SUPPHONORIFICTITLERF
        /// <summary>仕入先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPHONORIFICTITLERF
        {
            get { return _sUP_SUPPHONORIFICTITLERF; }
            set { _sUP_SUPPHONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERKANARF
        /// <summary>仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERKANARF
        {
            get { return _sUP_SUPPLIERKANARF; }
            set { _sUP_SUPPLIERKANARF = value; }
        }

        /// public propaty name  :  SUP_PURECODERF
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SUP_PURECODERF
        {
            get { return _sUP_PURECODERF; }
            set { _sUP_PURECODERF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE1RF
        /// <summary>仕入先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE1RF
        {
            get { return _sUP_SUPPLIERNOTE1RF; }
            set { _sUP_SUPPLIERNOTE1RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE2RF
        /// <summary>仕入先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE2RF
        {
            get { return _sUP_SUPPLIERNOTE2RF; }
            set { _sUP_SUPPLIERNOTE2RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE3RF
        /// <summary>仕入先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE3RF
        {
            get { return _sUP_SUPPLIERNOTE3RF; }
            set { _sUP_SUPPLIERNOTE3RF = value; }
        }

        /// public propaty name  :  SUP_SUPPLIERNOTE4RF
        /// <summary>仕入先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUP_SUPPLIERNOTE4RF
        {
            get { return _sUP_SUPPLIERNOTE4RF; }
            set { _sUP_SUPPLIERNOTE4RF = value; }
        }

        /// public propaty name  :  GDS_GOODSNAMEKANARF
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_GOODSNAMEKANARF
        {
            get { return _gDS_GOODSNAMEKANARF; }
            set { _gDS_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  GDS_JANRF
        /// <summary>JANコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JANコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_JANRF
        {
            get { return _gDS_JANRF; }
            set { _gDS_JANRF = value; }
        }

        /// public propaty name  :  GDS_GOODSRATERANKRF
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_GOODSRATERANKRF
        {
            get { return _gDS_GOODSRATERANKRF; }
            set { _gDS_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  GDS_GOODSNONONEHYPHENRF
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_GOODSNONONEHYPHENRF
        {
            get { return _gDS_GOODSNONONEHYPHENRF; }
            set { _gDS_GOODSNONONEHYPHENRF = value; }
        }

        /// public propaty name  :  GDS_GOODSNOTE1RF
        /// <summary>商品備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_GOODSNOTE1RF
        {
            get { return _gDS_GOODSNOTE1RF; }
            set { _gDS_GOODSNOTE1RF = value; }
        }

        /// public propaty name  :  GDS_GOODSNOTE2RF
        /// <summary>商品備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_GOODSNOTE2RF
        {
            get { return _gDS_GOODSNOTE2RF; }
            set { _gDS_GOODSNOTE2RF = value; }
        }

        /// public propaty name  :  GDS_GOODSSPECIALNOTERF
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GDS_GOODSSPECIALNOTERF
        {
            get { return _gDS_GOODSSPECIALNOTERF; }
            set { _gDS_GOODSSPECIALNOTERF = value; }
        }

        /// public propaty name  :  DADD_STOCKDIVNMRF
        /// <summary>在庫区分名称プロパティ</summary>
        /// <value>0:自社、1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_STOCKDIVNMRF
        {
            get { return _dADD_STOCKDIVNMRF; }
            set { _dADD_STOCKDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_TAXATIONDIVCDNMRF
        /// <summary>課税区分名称プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_TAXATIONDIVCDNMRF
        {
            get { return _dADD_TAXATIONDIVCDNMRF; }
            set { _dADD_TAXATIONDIVCDNMRF = value; }
        }

        /// public propaty name  :  DADD_PURECODENMRF
        /// <summary>純正区分名称プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_PURECODENMRF
        {
            get { return _dADD_PURECODENMRF; }
            set { _dADD_PURECODENMRF = value; }
        }

        /// public propaty name  :  DADD_STOCKMOVEPRICERF
        /// <summary>移動金額プロパティ</summary>
        /// <value>【仕入単価×移動数】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DADD_STOCKMOVEPRICERF
        {
            get { return _dADD_STOCKMOVEPRICERF; }
            set { _dADD_STOCKMOVEPRICERF = value; }
        }

        /// public propaty name  :  DADD_STOCKMOVELISTPRICERF
        /// <summary>移動金額(標準価格)プロパティ</summary>
        /// <value>【定価×移動数】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額(標準価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DADD_STOCKMOVELISTPRICERF
        {
            get { return _dADD_STOCKMOVELISTPRICERF; }
            set { _dADD_STOCKMOVELISTPRICERF = value; }
        }

        /// public propaty name  :  DADD_BFSTOCKCOUNTPREVRF
        /// <summary>移動元移動前数プロパティ</summary>
        /// <value>移動元倉庫の現在庫数（移動前）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元移動前数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DADD_BFSTOCKCOUNTPREVRF
        {
            get { return _dADD_BFSTOCKCOUNTPREVRF; }
            set { _dADD_BFSTOCKCOUNTPREVRF = value; }
        }

        /// public propaty name  :  DADD_BFSTOCKCOUNTRF
        /// <summary>移動元移動後数プロパティ</summary>
        /// <value>移動元倉庫の現在庫数（移動後）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元移動後数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DADD_BFSTOCKCOUNTRF
        {
            get { return _dADD_BFSTOCKCOUNTRF; }
            set { _dADD_BFSTOCKCOUNTRF = value; }
        }

        /// public propaty name  :  DADD_AFSTOCKCOUNTPREVRF
        /// <summary>移動先移動前数プロパティ</summary>
        /// <value>移動先倉庫の現在庫数（移動前）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先移動前数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DADD_AFSTOCKCOUNTPREVRF
        {
            get { return _dADD_AFSTOCKCOUNTPREVRF; }
            set { _dADD_AFSTOCKCOUNTPREVRF = value; }
        }

        /// public propaty name  :  DADD_AFSTOCKCOUNTRF
        /// <summary>移動先移動後数プロパティ</summary>
        /// <value>移動先倉庫の現在庫数（移動後）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先移動後数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DADD_AFSTOCKCOUNTRF
        {
            get { return _dADD_AFSTOCKCOUNTRF; }
            set { _dADD_AFSTOCKCOUNTRF = value; }
        }

        /// public propaty name  :  MOVD_STOCKMOVEPRICERF
        /// <summary>移動金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MOVD_STOCKMOVEPRICERF
        {
            get { return _mOVD_STOCKMOVEPRICERF; }
            set { _mOVD_STOCKMOVEPRICERF = value; }
        }


        /// <summary>
        /// 自由帳票在庫移動明細データワークコンストラクタ
        /// </summary>
        /// <returns>FrePStockMoveDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveDetailWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePStockMoveDetailWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FrePStockMoveDetailWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FrePStockMoveDetailWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FrePStockMoveDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveDetailWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePStockMoveDetailWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePStockMoveDetailWork || graph is ArrayList || graph is FrePStockMoveDetailWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( FrePStockMoveDetailWork ).FullName ) );

            if ( graph != null && graph is FrePStockMoveDetailWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePStockMoveDetailWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePStockMoveDetailWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePStockMoveDetailWork[])graph).Length;
            }
            else if ( graph is FrePStockMoveDetailWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //在庫移動形式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKMOVEFORMALRF
            //在庫移動伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKMOVESLIPNORF
            //在庫移動行番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKMOVEROWNORF
            //移動元拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BFSECTIONCODERF
            //移動元倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BFENTERWAREHCODERF
            //移動先拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_AFSECTIONCODERF
            //移動先倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_AFENTERWAREHCODERF
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_SUPPLIERCDRF
            //仕入先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_SUPPLIERSNMRF
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_GOODSMAKERCDRF
            //メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_MAKERNAMERF
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_GOODSNORF
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_GOODSNAMERF
            //商品名称カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_GOODSNAMEKANARF
            //在庫区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_STOCKDIVRF
            //仕入単価（税抜,浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //MOVD_STOCKUNITPRICEFLRF
            //課税区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_TAXATIONDIVCDRF
            //移動数
            serInfo.MemberInfo.Add( typeof( Double ) ); //MOVD_MOVECOUNTRF
            //移動元棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BFSHELFNORF
            //移動先棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_AFSHELFNORF
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_BLGOODSCODERF
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVD_BLGOODSFULLNAMERF
            //定価（浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //MOVD_LISTPRICEFLRF
            //移動状態
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVD_MOVESTATUSRF
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGOODSCDURF_BLGOODSHALFNAMERF
            //メーカー略称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKERURF_MAKERSHORTNAMERF
            //メーカーカナ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKERURF_MAKERKANANAMERF
            //重複棚番１
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_DUPLICATIONSHELFNO1RF
            //重複棚番２
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_DUPLICATIONSHELFNO2RF
            //部品管理区分１
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_PARTSMANAGEMENTDIVIDE1RF
            //部品管理区分２
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_PARTSMANAGEMENTDIVIDE2RF
            //在庫備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_STOCKNOTE1RF
            //在庫備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //STC1_STOCKNOTE2RF
            //出荷可能数
            serInfo.MemberInfo.Add( typeof( Double ) ); //STC1_SHIPMENTPOSCNTRF
            //重複棚番１
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_DUPLICATIONSHELFNO1RF
            //重複棚番２
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_DUPLICATIONSHELFNO2RF
            //部品管理区分１
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_PARTSMANAGEMENTDIVIDE1RF
            //部品管理区分２
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_PARTSMANAGEMENTDIVIDE2RF
            //在庫備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_STOCKNOTE1RF
            //在庫備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //STC2_STOCKNOTE2RF
            //出荷可能数
            serInfo.MemberInfo.Add( typeof( Double ) ); //STC2_SHIPMENTPOSCNTRF
            //仕入先名1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNM1RF
            //仕入先名2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNM2RF
            //仕入先敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPHONORIFICTITLERF
            //仕入先カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERKANARF
            //純正区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SUP_PURECODERF
            //仕入先備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE1RF
            //仕入先備考2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE2RF
            //仕入先備考3
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE3RF
            //仕入先備考4
            serInfo.MemberInfo.Add( typeof( string ) ); //SUP_SUPPLIERNOTE4RF
            //商品名称カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNAMEKANARF
            //JANコード
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_JANRF
            //商品掛率ランク
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSRATERANKRF
            //ハイフン無商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNONONEHYPHENRF
            //商品備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNOTE1RF
            //商品備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSNOTE2RF
            //商品規格・特記事項
            serInfo.MemberInfo.Add( typeof( string ) ); //GDS_GOODSSPECIALNOTERF
            //在庫区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_STOCKDIVNMRF
            //課税区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_TAXATIONDIVCDNMRF
            //純正区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_PURECODENMRF
            //移動金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_STOCKMOVEPRICERF
            //移動金額(標準価格)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DADD_STOCKMOVELISTPRICERF
            //移動元移動前数
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_BFSTOCKCOUNTPREVRF
            //移動元移動後数
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_BFSTOCKCOUNTRF
            //移動先移動前数
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_AFSTOCKCOUNTPREVRF
            //移動先移動後数
            serInfo.MemberInfo.Add( typeof( Double ) ); //DADD_AFSTOCKCOUNTRF
            //移動金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //MOVD_STOCKMOVEPRICERF


            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePStockMoveDetailWork )
            {
                FrePStockMoveDetailWork temp = (FrePStockMoveDetailWork)graph;

                SetFrePStockMoveDetailWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePStockMoveDetailWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePStockMoveDetailWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePStockMoveDetailWork temp in lst )
                {
                    SetFrePStockMoveDetailWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePStockMoveDetailWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 67;

        /// <summary>
        ///  FrePStockMoveDetailWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveDetailWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFrePStockMoveDetailWork( System.IO.BinaryWriter writer, FrePStockMoveDetailWork temp )
        {
            //在庫移動形式
            writer.Write( temp.MOVD_STOCKMOVEFORMALRF );
            //在庫移動伝票番号
            writer.Write( temp.MOVD_STOCKMOVESLIPNORF );
            //在庫移動行番号
            writer.Write( temp.MOVD_STOCKMOVEROWNORF );
            //移動元拠点コード
            writer.Write( temp.MOVD_BFSECTIONCODERF );
            //移動元倉庫コード
            writer.Write( temp.MOVD_BFENTERWAREHCODERF );
            //移動先拠点コード
            writer.Write( temp.MOVD_AFSECTIONCODERF );
            //移動先倉庫コード
            writer.Write( temp.MOVD_AFENTERWAREHCODERF );
            //仕入先コード
            writer.Write( temp.MOVD_SUPPLIERCDRF );
            //仕入先略称
            writer.Write( temp.MOVD_SUPPLIERSNMRF );
            //商品メーカーコード
            writer.Write( temp.MOVD_GOODSMAKERCDRF );
            //メーカー名称
            writer.Write( temp.MOVD_MAKERNAMERF );
            //商品番号
            writer.Write( temp.MOVD_GOODSNORF );
            //商品名称
            writer.Write( temp.MOVD_GOODSNAMERF );
            //商品名称カナ
            writer.Write( temp.MOVD_GOODSNAMEKANARF );
            //在庫区分
            writer.Write( temp.MOVD_STOCKDIVRF );
            //仕入単価（税抜,浮動）
            writer.Write( temp.MOVD_STOCKUNITPRICEFLRF );
            //課税区分
            writer.Write( temp.MOVD_TAXATIONDIVCDRF );
            //移動数
            writer.Write( temp.MOVD_MOVECOUNTRF );
            //移動元棚番
            writer.Write( temp.MOVD_BFSHELFNORF );
            //移動先棚番
            writer.Write( temp.MOVD_AFSHELFNORF );
            //BL商品コード
            writer.Write( temp.MOVD_BLGOODSCODERF );
            //BL商品コード名称（全角）
            writer.Write( temp.MOVD_BLGOODSFULLNAMERF );
            //定価（浮動）
            writer.Write( temp.MOVD_LISTPRICEFLRF );
            //移動状態
            writer.Write( temp.MOVD_MOVESTATUSRF );
            //BL商品コード名称（半角）
            writer.Write( temp.BLGOODSCDURF_BLGOODSHALFNAMERF );
            //メーカー略称
            writer.Write( temp.MAKERURF_MAKERSHORTNAMERF );
            //メーカーカナ名称
            writer.Write( temp.MAKERURF_MAKERKANANAMERF );
            //重複棚番１
            writer.Write( temp.STC1_DUPLICATIONSHELFNO1RF );
            //重複棚番２
            writer.Write( temp.STC1_DUPLICATIONSHELFNO2RF );
            //部品管理区分１
            writer.Write( temp.STC1_PARTSMANAGEMENTDIVIDE1RF );
            //部品管理区分２
            writer.Write( temp.STC1_PARTSMANAGEMENTDIVIDE2RF );
            //在庫備考１
            writer.Write( temp.STC1_STOCKNOTE1RF );
            //在庫備考２
            writer.Write( temp.STC1_STOCKNOTE2RF );
            //出荷可能数
            writer.Write( temp.STC1_SHIPMENTPOSCNTRF );
            //重複棚番１
            writer.Write( temp.STC2_DUPLICATIONSHELFNO1RF );
            //重複棚番２
            writer.Write( temp.STC2_DUPLICATIONSHELFNO2RF );
            //部品管理区分１
            writer.Write( temp.STC2_PARTSMANAGEMENTDIVIDE1RF );
            //部品管理区分２
            writer.Write( temp.STC2_PARTSMANAGEMENTDIVIDE2RF );
            //在庫備考１
            writer.Write( temp.STC2_STOCKNOTE1RF );
            //在庫備考２
            writer.Write( temp.STC2_STOCKNOTE2RF );
            //出荷可能数
            writer.Write( temp.STC2_SHIPMENTPOSCNTRF );
            //仕入先名1
            writer.Write( temp.SUP_SUPPLIERNM1RF );
            //仕入先名2
            writer.Write( temp.SUP_SUPPLIERNM2RF );
            //仕入先敬称
            writer.Write( temp.SUP_SUPPHONORIFICTITLERF );
            //仕入先カナ
            writer.Write( temp.SUP_SUPPLIERKANARF );
            //純正区分
            writer.Write( temp.SUP_PURECODERF );
            //仕入先備考1
            writer.Write( temp.SUP_SUPPLIERNOTE1RF );
            //仕入先備考2
            writer.Write( temp.SUP_SUPPLIERNOTE2RF );
            //仕入先備考3
            writer.Write( temp.SUP_SUPPLIERNOTE3RF );
            //仕入先備考4
            writer.Write( temp.SUP_SUPPLIERNOTE4RF );
            //商品名称カナ
            writer.Write( temp.GDS_GOODSNAMEKANARF );
            //JANコード
            writer.Write( temp.GDS_JANRF );
            //商品掛率ランク
            writer.Write( temp.GDS_GOODSRATERANKRF );
            //ハイフン無商品番号
            writer.Write( temp.GDS_GOODSNONONEHYPHENRF );
            //商品備考１
            writer.Write( temp.GDS_GOODSNOTE1RF );
            //商品備考２
            writer.Write( temp.GDS_GOODSNOTE2RF );
            //商品規格・特記事項
            writer.Write( temp.GDS_GOODSSPECIALNOTERF );
            //在庫区分名称
            writer.Write( temp.DADD_STOCKDIVNMRF );
            //課税区分名称
            writer.Write( temp.DADD_TAXATIONDIVCDNMRF );
            //純正区分名称
            writer.Write( temp.DADD_PURECODENMRF );
            //移動金額
            writer.Write( temp.DADD_STOCKMOVEPRICERF );
            //移動金額(標準価格)
            writer.Write( temp.DADD_STOCKMOVELISTPRICERF );
            //移動元移動前数
            writer.Write( temp.DADD_BFSTOCKCOUNTPREVRF );
            //移動元移動後数
            writer.Write( temp.DADD_BFSTOCKCOUNTRF );
            //移動先移動前数
            writer.Write( temp.DADD_AFSTOCKCOUNTPREVRF );
            //移動先移動後数
            writer.Write( temp.DADD_AFSTOCKCOUNTRF );
            //移動金額
            writer.Write( temp.MOVD_STOCKMOVEPRICERF );

        }

        /// <summary>
        ///  FrePStockMoveDetailWorkインスタンス取得
        /// </summary>
        /// <returns>FrePStockMoveDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveDetailWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FrePStockMoveDetailWork GetFrePStockMoveDetailWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FrePStockMoveDetailWork temp = new FrePStockMoveDetailWork();

            //在庫移動形式
            temp.MOVD_STOCKMOVEFORMALRF = reader.ReadInt32();
            //在庫移動伝票番号
            temp.MOVD_STOCKMOVESLIPNORF = reader.ReadInt32();
            //在庫移動行番号
            temp.MOVD_STOCKMOVEROWNORF = reader.ReadInt32();
            //移動元拠点コード
            temp.MOVD_BFSECTIONCODERF = reader.ReadString();
            //移動元倉庫コード
            temp.MOVD_BFENTERWAREHCODERF = reader.ReadString();
            //移動先拠点コード
            temp.MOVD_AFSECTIONCODERF = reader.ReadString();
            //移動先倉庫コード
            temp.MOVD_AFENTERWAREHCODERF = reader.ReadString();
            //仕入先コード
            temp.MOVD_SUPPLIERCDRF = reader.ReadInt32();
            //仕入先略称
            temp.MOVD_SUPPLIERSNMRF = reader.ReadString();
            //商品メーカーコード
            temp.MOVD_GOODSMAKERCDRF = reader.ReadInt32();
            //メーカー名称
            temp.MOVD_MAKERNAMERF = reader.ReadString();
            //商品番号
            temp.MOVD_GOODSNORF = reader.ReadString();
            //商品名称
            temp.MOVD_GOODSNAMERF = reader.ReadString();
            //商品名称カナ
            temp.MOVD_GOODSNAMEKANARF = reader.ReadString();
            //在庫区分
            temp.MOVD_STOCKDIVRF = reader.ReadInt32();
            //仕入単価（税抜,浮動）
            temp.MOVD_STOCKUNITPRICEFLRF = reader.ReadDouble();
            //課税区分
            temp.MOVD_TAXATIONDIVCDRF = reader.ReadInt32();
            //移動数
            temp.MOVD_MOVECOUNTRF = reader.ReadDouble();
            //移動元棚番
            temp.MOVD_BFSHELFNORF = reader.ReadString();
            //移動先棚番
            temp.MOVD_AFSHELFNORF = reader.ReadString();
            //BL商品コード
            temp.MOVD_BLGOODSCODERF = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.MOVD_BLGOODSFULLNAMERF = reader.ReadString();
            //定価（浮動）
            temp.MOVD_LISTPRICEFLRF = reader.ReadDouble();
            //移動状態
            temp.MOVD_MOVESTATUSRF = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGOODSCDURF_BLGOODSHALFNAMERF = reader.ReadString();
            //メーカー略称
            temp.MAKERURF_MAKERSHORTNAMERF = reader.ReadString();
            //メーカーカナ名称
            temp.MAKERURF_MAKERKANANAMERF = reader.ReadString();
            //重複棚番１
            temp.STC1_DUPLICATIONSHELFNO1RF = reader.ReadString();
            //重複棚番２
            temp.STC1_DUPLICATIONSHELFNO2RF = reader.ReadString();
            //部品管理区分１
            temp.STC1_PARTSMANAGEMENTDIVIDE1RF = reader.ReadString();
            //部品管理区分２
            temp.STC1_PARTSMANAGEMENTDIVIDE2RF = reader.ReadString();
            //在庫備考１
            temp.STC1_STOCKNOTE1RF = reader.ReadString();
            //在庫備考２
            temp.STC1_STOCKNOTE2RF = reader.ReadString();
            //出荷可能数
            temp.STC1_SHIPMENTPOSCNTRF = reader.ReadDouble();
            //重複棚番１
            temp.STC2_DUPLICATIONSHELFNO1RF = reader.ReadString();
            //重複棚番２
            temp.STC2_DUPLICATIONSHELFNO2RF = reader.ReadString();
            //部品管理区分１
            temp.STC2_PARTSMANAGEMENTDIVIDE1RF = reader.ReadString();
            //部品管理区分２
            temp.STC2_PARTSMANAGEMENTDIVIDE2RF = reader.ReadString();
            //在庫備考１
            temp.STC2_STOCKNOTE1RF = reader.ReadString();
            //在庫備考２
            temp.STC2_STOCKNOTE2RF = reader.ReadString();
            //出荷可能数
            temp.STC2_SHIPMENTPOSCNTRF = reader.ReadDouble();
            //仕入先名1
            temp.SUP_SUPPLIERNM1RF = reader.ReadString();
            //仕入先名2
            temp.SUP_SUPPLIERNM2RF = reader.ReadString();
            //仕入先敬称
            temp.SUP_SUPPHONORIFICTITLERF = reader.ReadString();
            //仕入先カナ
            temp.SUP_SUPPLIERKANARF = reader.ReadString();
            //純正区分
            temp.SUP_PURECODERF = reader.ReadInt32();
            //仕入先備考1
            temp.SUP_SUPPLIERNOTE1RF = reader.ReadString();
            //仕入先備考2
            temp.SUP_SUPPLIERNOTE2RF = reader.ReadString();
            //仕入先備考3
            temp.SUP_SUPPLIERNOTE3RF = reader.ReadString();
            //仕入先備考4
            temp.SUP_SUPPLIERNOTE4RF = reader.ReadString();
            //商品名称カナ
            temp.GDS_GOODSNAMEKANARF = reader.ReadString();
            //JANコード
            temp.GDS_JANRF = reader.ReadString();
            //商品掛率ランク
            temp.GDS_GOODSRATERANKRF = reader.ReadString();
            //ハイフン無商品番号
            temp.GDS_GOODSNONONEHYPHENRF = reader.ReadString();
            //商品備考１
            temp.GDS_GOODSNOTE1RF = reader.ReadString();
            //商品備考２
            temp.GDS_GOODSNOTE2RF = reader.ReadString();
            //商品規格・特記事項
            temp.GDS_GOODSSPECIALNOTERF = reader.ReadString();
            //在庫区分名称
            temp.DADD_STOCKDIVNMRF = reader.ReadString();
            //課税区分名称
            temp.DADD_TAXATIONDIVCDNMRF = reader.ReadString();
            //純正区分名称
            temp.DADD_PURECODENMRF = reader.ReadString();
            //移動金額
            temp.DADD_STOCKMOVEPRICERF = reader.ReadInt64();
            //移動金額(標準価格)
            temp.DADD_STOCKMOVELISTPRICERF = reader.ReadInt64();
            //移動元移動前数
            temp.DADD_BFSTOCKCOUNTPREVRF = reader.ReadDouble();
            //移動元移動後数
            temp.DADD_BFSTOCKCOUNTRF = reader.ReadDouble();
            //移動先移動前数
            temp.DADD_AFSTOCKCOUNTPREVRF = reader.ReadDouble();
            //移動先移動後数
            temp.DADD_AFSTOCKCOUNTRF = reader.ReadDouble();
            //移動金額
            temp.MOVD_STOCKMOVEPRICERF = reader.ReadInt64();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>FrePStockMoveDetailWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveDetailWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePStockMoveDetailWork temp = GetFrePStockMoveDetailWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (FrePStockMoveDetailWork[])lst.ToArray( typeof( FrePStockMoveDetailWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
