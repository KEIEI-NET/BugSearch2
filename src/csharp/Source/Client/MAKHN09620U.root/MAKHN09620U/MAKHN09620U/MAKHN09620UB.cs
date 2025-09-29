//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : セットマスタ
// プログラム概要   : セットマスタの登録・更新・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008.08.01  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2009/02/06  修正内容 : 各種速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 削除商品の商品情報を非表示に修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2009/09/16  修正内容 : 【MANTIS:14244】連続で行削除するとエラーが発生
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/08/04  修正内容 : 起動速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2010/12/03  修正内容 : １．明細行を全て削除後に、ヘッダ部の削除ボタンを押下するとエラーが発生する不具合の修正
//                                  ２．複数行の明細があるセット品の明細の一部を行削除し、ヘッダ部の削除ボタンを実行した場合の削除処理の不正 
//----------------------------------------------------------------------------//
// 管理番号  11175121-00 作成担当 : gaocheng
// 修 正 日  2015/05/08  修正内容 : ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正
//                                : ツールバーでショートカットキーの修正
//----------------------------------------------------------------------------//
// 管理番号  11175121-00 作成担当 : gaocheng
// 修 正 日  2015/07/02  修正内容 : ウィンドウ位置とサイズの記憶功能の対応
//----------------------------------------------------------------------------//
// 管理番号  11170188-00 作成担当 : 時シン
// 作 成 日  2015/10/28  修正内容 : Redmine#47547 セット子品番入力時に "." を入力できないことの対応
//----------------------------------------------------------------------------//
// 管理番号  11401643-00 作成担当 : 譚洪
// 作 成 日  K2019/01/07 修正内容 : Redmine#49802 ランテル様にてセットマスタの最大登録件数を99件に増やすの対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
using System.IO;
using Broadleaf.Application.Resources;
//---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// セット商品情報入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Note       : セット商品情報の入力を行なうコントロールクラスです。                   </br>
    /// <br>Programmer : 30005 木建　翼                                                         </br>
    /// <br>Date       : 2007.05.10                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpDateNote : セット商品情報の必須入力チェックを追加                                 </br>
    /// <br>Programmer : 30005 木建　翼                                                         </br>
    /// <br>Date       : 2007.07.10                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 入力コンポーネントが編集不可のときの文字の色を変更                     </br>
    /// <br>Programmer : 30005 木建　翼                                                         </br>
    /// <br>Date       : 2007.07.10                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : DC.NS用に変更する(変更点が多すぎるため変更コメントは残しません)        </br>
    /// <br>Programmer : 20081 疋田　勇人                                                       </br>
    /// <br>Date       : 2007.09.26                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : PM.NS対応                                                              </br>
    /// <br>Programmer : 30413 犬飼                                                             </br>
    /// <br>Date       : 2008.08.01                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.02.06 20056 對馬 大輔</br>
    /// <br>           : 　各種速度アップ対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2010/08/04 22018 鈴木 正臣</br>
    /// <br>           : 起動速度アップ対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/05/08 gaocheng</br>
    /// <br>           : ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>UpdateNote : 2015/07/02 gaocheng</br>
    /// <br>           : ウィンドウ位置とサイズの記憶功能の対応</br>
    /// <br>------------------------------------------------------------------------------------</br> 
    /// <br>UpdateNote : Redmine#47547 セット子品番入力時に "." を入力できないことの対応        </br>
    /// <br>Programmer : 時シン                                                                 </br>
    /// <br>Date       : 2015/10/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : Redmine#49802 ランテル様にてセットマスタの最大登録件数を99件に増やすの対応 </br>
    /// <br>Programmer : 譚洪　                                                                 </br>
    /// <br>Date       : K2019/01/07                                                            </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    public partial class MAKHN09620UB : UserControl
    {
        #region ◆Constractor
        /// <summary>
        /// セット商品情報入力コントロールクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : セット商品情報の入力を行なうコントロールクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30005 木建　翼</br>
        /// <br>Date       : 2007.05.10</br>
        /// <br>UpdateNote : 2010/12/03  鄧潘ハン</br>
        /// <br>修正内容   : １．明細行を全て削除後に、ヘッダ部の削除ボタンを押下するとエラーが発生する不具合の修正</br>
        /// <br>             ２．複数行の明細があるセット品の明細の一部を行削除し、ヘッダ部の削除ボタンを実行した場合の削除処理の不正</br>
        /// <br>UpdateNote : K2019/01/07 譚洪</br>
        /// <br>修正内容   : ランテル専用OPのオプションコード情報の取得</br>
        /// </remarks>
        // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //public MAKHN09620UB()
        public MAKHN09620UB(GoodsSetAcs inputGoodsSetAcs)
        // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            InitializeComponent();

            // 2008.08.06 30413 犬飼 プロパティ追加 >>>>>>START
            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
            // 2008.08.06 30413 犬飼 プロパティ追加 <<<<<<END

            _goodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();

            // 2008.08.12 30413 犬飼 プロパティ追加 >>>>>>START
            _deleteGoodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();
            // 2008.08.12 30413 犬飼 プロパティ追加 <<<<<<END

            // ---ADD 2010/12/03 ---------------------------------------->>>>>
            _deleteGoodsDetailDataTable.PrimaryKey = null;
            // ---ADD 2010/12/03 ----------------------------------------<<<<<

            // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 >>>>>>START
            _lcGoodsUnitDataList = new List<GoodsUnitData>();
            // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 <<<<<<END
        
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2009.02.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 商品セットマスタアクセスクラスインスタンス化
            //_goodsSetAcs = new GoodsSetAcs();
            // 商品セットマスタアクセスクラスインスタンス化
            _goodsSetAcs = inputGoodsSetAcs;
            // 2009.02.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
            this._userSetting = new SetMstUserConst();

            this.Deserialize();

            // 明細グリッド
            this.LoadGridColumnsSetting(this.uGrid_Details, this._detailColumnsList);
            //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

            //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ---->>>>>
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_RuntelCustom) > 0)
            {
                this.HaveRuntel = true;
            }
            else
            {
                this.HaveRuntel = false;
            }
            //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ----<<<<<
        }

        #endregion

        #region ◆Private Members

        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _goodsDetailDataTable;
        private Image _guideButtonImage;
        private ImageList _imageList16;

        // 初期表示行数
        private int _defaultRowCnt = 10;

        // 2008.08.07 30413 犬飼 プロパティ追加 >>>>>>START
        // 削除テーブル
        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _deleteGoodsDetailDataTable;
        // 最大行数
        private const int _maxRowNum = 50;
        // 2008.08.07 30413 犬飼 プロパティ追加 <<<<<<END
        private const int MaxRowNumForRuntel = 99; // ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応
        // 企業コード
        private string _enterpriseCode;

        // 入力値保持
        private int _beforeMakerCode = 0;
        private string _beforeGoodsCode = "";

        // 変更フラグ
        private bool _changeFlg;

        // 2008.08.06 30413 犬飼 プロパティ追加 >>>>>>START
        // ログイン従業員
        private Employee _loginEmployee = null;
        // 2008.08.06 30413 犬飼 プロパティ追加 <<<<<<END

        // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 >>>>>>START
        /// <summary>商品連結ローカルキャッシュ用データリストクラス</summary>
        private List<GoodsUnitData> _lcGoodsUnitDataList;
        // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 <<<<<<END
        
        // セット商品の品番更新区分
        private bool _setGoodNoUpdFlg = true;

        // 商品セットアクセスクラス
        private GoodsSetAcs _goodsSetAcs;
        
        // 2008.10.15 30413 犬飼 親商品の品番とメーカーを格納 >>>>>>START
        private string _parentGoodsNo = "";
        private int _parentMakerCode = 0;
        // 2008.10.15 30413 犬飼 親商品の品番とメーカーを格納 <<<<<<END

        // 2008.10.30 30413 犬飼 変更前セット商品の品番を格納 >>>>>>START
        private string _childGoodsNo = "";
        // 2008.10.30 30413 犬飼 変更前セット商品の品番を格納 <<<<<<END

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
        // ユーザー設定
        private SetMstUserConst _userSetting;
        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "MAKHN09620UB_Construction.XML";
        //初期化フラグ
        private bool _initialLoadFlag = false;
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

        private bool HaveRuntel = false; // ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応
        #endregion

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
        # region ◆プロパティー
        /// <summary>セットマスタユーザー設定</summary>
        public SetMstUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>初期化フラグ</summary>
        public bool InitialLoadFlag
        {
            get { return this._initialLoadFlag; }
            set { this._initialLoadFlag = value; }
        }
        # endregion
        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<

        # region ◆Event

        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>グリッド最下層行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownButtomRow;
        
        # endregion

        #region ◆Public Methods

        /// <summary>
        /// セット商品情報行追加処理
        /// </summary>
        /// <remarks>
        /// Note			:	セット商品情報の空行をデータテーブルに追加する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        public void AddGoodsDetailRow()
        {
            // No採番のためにデータテーブルの行数をカウントする
            int rowCount = this._goodsDetailDataTable.Rows.Count;

            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            row.No = (short)(rowCount + 1);
            this._goodsDetailDataTable.AddGoodsSetDetailRow(row);
        }

        /// <summary>
        /// データテーブルグリッドバインド処理
        /// </summary>
        /// <remarks>
        /// Note			:	表示するデータ行をグリッドにバインドします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.10<br />
        /// </remarks>
        public void SetGoodsSetGrid()
        {
            // グリッドに表示するデータテーブルを設定
            uGrid_Details.DataSource = _goodsDetailDataTable;

            // グリッド初期設定
            this.InitialSettingGridCol();
            // ボタンの初期設定
            ButtonInitialSetting();
            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// データ行データテーブル格納処理
        /// </summary>
        /// <param name="No">表示No</param>
        /// <param name="dataRow">選択されたデータ行</param>
        /// <remarks>
        /// Note			:	表示するデータ行をグリッドにバインドします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.10<br />
        /// </remarks>
        public void SetGoodsSetDataTable(int No, DataRow dataRow)
        {
            this._goodsDetailDataTable.BeginLoadData();

            // 表示行
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // 空の入力行以上データが存在する場合は新規行を作ってデータを格納
            if (No > _defaultRowCnt)
            {
                detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            }
            // 空の入力行以下の場合は存在する行数と変数Noが一致する行を更新する
            else
            {
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find((short)No);
            }

            // 必要な項目だけグリッド表示データテーブルにセット
            detailRow.No = (short)No;                                                  // No
            if (dataRow[GoodsSetAcs.DISPLAYORDER_TITLE].ToString() != string.Empty)
            {
                detailRow.Disply = (int)dataRow[GoodsSetAcs.DISPLAYORDER_TITLE];       // 表示順位
            }

            //detailRow.MakerCode = (int)dataRow[GoodsSetAcs.SUBGOODSMAKERCD_TITLE];     // メーカーコード
            int workMakerCode = (int)dataRow[GoodsSetAcs.SUBGOODSMAKERCD_TITLE];
            detailRow.MakerCode = workMakerCode.ToString("d04");     // メーカーコード
            detailRow.MakerName = (string)dataRow[GoodsSetAcs.SUBGOODSMAKERNM_TITLE];  // メーカー名称
            detailRow.GoodsCode = (string)dataRow[GoodsSetAcs.SUBGOODSNO_TITLE];       // 品番
            detailRow.GoodsName = (string)dataRow[GoodsSetAcs.SUBGOODSNAME_TITLE];     // 品名

            if (dataRow[GoodsSetAcs.CNTFL_TITLE].ToString() != string.Empty)
            {
                //detailRow.CntFl = (double)dataRow[GoodsSetAcs.CNTFL_TITLE];            // ＱＴＹ(数量)
                detailRow.CntFl = (string)dataRow[GoodsSetAcs.CNTFL_TITLE];            // ＱＴＹ(数量)
            }

            detailRow.SetNote   = dataRow[GoodsSetAcs.SETSPECIALNOTE_TITLE].ToString();   // セット規格・特記事項
            // 2008.08.04 30413 犬飼 カタログ図番の削除 >>>>>>START
            //detailRow.CatalogShape = dataRow[GoodsSetAcs.CATALOGSHAPENO_TITLE].ToString();// カタログ図番
            // 2008.08.04 30413 犬飼 カタログ図番の削除 <<<<<<END
            
            // 新規行のときのみ新しい行を追加するためAdd処理が必要
            if (No > _defaultRowCnt)
            {
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// データテーブルクリア処理
        /// </summary>
        /// <remarks>
        /// Note			:	データテーブルをクリアします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void ClearGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Clear();
            // 2008.08.20 30413 犬飼 削除データテーブルを追加 >>>>>>START
            this._deleteGoodsDetailDataTable.Clear();
            // 2008.08.20 30413 犬飼 削除データテーブルを追加 <<<<<<END

            // 2008.08.22 30413 犬飼 ローカルキャッシュをクリア >>>>>>START
            this._lcGoodsUnitDataList.Clear();
            // 2008.08.22 30413 犬飼 ローカルキャッシュをクリア <<<<<<END

            // 2008.10.15 30413 犬飼 親情報をクリア >>>>>>START
            this._parentGoodsNo = "";
            this._parentMakerCode = 0;
            // 2008.10.15 30413 犬飼 親情報をクリア <<<<<<END            
        }

        /// <summary>
        /// データテーブルリセット処理
        /// </summary>
        /// <remarks>
        /// Note			:	データテーブルをリセットします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void ResetGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Reset();
            // 2008.08.20 30413 犬飼 削除データテーブルを追加 >>>>>>START
            this._deleteGoodsDetailDataTable.Reset();
            // 2008.08.20 30413 犬飼 削除データテーブルを追加 <<<<<<END
        }

        /// <summary>
        /// グリッド入力許可制御処理
        /// </summary>
        /// <remarks>
        /// Note			:	グリッドの入力許可制御を設定します。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void GridInputPermissionControl(bool enabled)
        {
            this.uGrid_Details.Enabled = enabled;
        }

        /// <summary>
        /// グリッドボタン許可制御処理
        /// </summary>
        /// <remarks>
        /// Note			:	グリッドのボタンの許可制御を設定します。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public void GridButtonPermissionControl(bool enabled)
        {
            this.uButton_RowDelete.Enabled = enabled;
            this.uButton_RowInsert.Enabled = enabled;
        }

        /// <summary>
        /// グリッド内入力チェック
        /// </summary>
        /// <return>RESULT</return>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// <br>Note		: グリッド内のデータが正しく入力されているかチェックを行います。</br>
        /// <br>Programmer	: 30005 木建　翼</br>
        /// <br>Date		: 2007.05.14</br>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// Note			: 必須入力チェックを追加<br />
        /// Programmer		: 30005 木建　翼<br />
        /// Date			: 2007.07.10<br />
        /// <br>--------------------------------------------------------------------------------------</br>
        /// <br>UpdateNote  : K2019/01/07 譚洪</br>
        /// <br>修正内容    : ランテル様にてセットマスタの最大登録件数を99件に増やすの対応</br>
        /// </remarks>
        public bool GridDataCheck(ref Control control, ref string message)
        {
            bool result;
            int errorRowNo;
            string errorColNm;

            // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
            int errorDispNo;
            // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END            

            // 2009.03.26 30413 犬飼 セット商品の商品マスタ削除チェック >>>>>>START
            #region ●削除チェック
            this.CheckDeleteData(out errorRowNo);
            if (errorRowNo != 0)
            {
                message = "セット商品情報の [ " + errorRowNo + " ] 行目が商品マスタから削除されています。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            // 2009.03.26 30413 犬飼 セット商品の商品マスタ削除チェック <<<<<<END
            
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();
            
            #region ●有効データチェック
            
            #region < 有効データ件数取得 >
            this.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);
            #endregion

            #region < 必須入力チェック >
            if (errorColNm != "")
            {
                message = "セット商品情報の [ " + errorRowNo + " ] 行目の" + errorColNm + "を入力してください。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }

            // 2007.07.10 add by T-Kidate
            if (effectDataList.Count == 0)
            {
                message = "セット商品情報を入力してください。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #region < 無効データ件数チェック>
            if (errorRowNo != 0)
            {
                message = "セット商品情報の [ " + errorRowNo + " ] 行目を正しく入力してください。";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #endregion

            // 2008.10.15 30413 犬飼 表示順位の重複チェック >>>>>>START
            #region ●親商品と同一商品チェック
            this.CheckParentOverlapData(out errorRowNo, effectDataList);

            #region -- 親商品と同一商品有り --
            if (errorRowNo != 0)
            {
                message = "セット商品情報の [ " + errorRowNo + " ] 行目が親商品と同一です";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            #endregion
            // 2008.10.15 30413 犬飼 表示順位の重複チェック <<<<<<END
            
            #region ●重複チェック
            // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
            //this.CheckOverlapData(out errorRowNo, effectDataList);
            this.CheckOverlapData(out errorRowNo, out errorDispNo, effectDataList);
            // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END            

            #region -- 重複有り --
            if (errorRowNo != 0)
            {
                message = "セット商品情報の [ " + errorRowNo + " ] 行目が重複しています";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
            if (errorDispNo != 0)
            {
                //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ---->>>>>
                if(this.HaveRuntel)
                {
                    message = "セット商品情報の [ " + errorDispNo + " ] 行目の表示順位が重複\nまたは入力範囲(1～99)から外れています";
                }
                else
                {
                 //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ---->>>>>
                    message = "セット商品情報の [ " + errorDispNo + " ] 行目の表示順位が重複\nまたは入力範囲(1～50)から外れています";
                }// ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END            

            #endregion

            result = true;
            return result;
        }

        /// <summary>
        /// 商品マスタ削除データチェック
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <remarks>
        /// </remarks>
        public void CheckDeleteData(out int errorRowNo)
        {
            // エラーが行番号(0 が正常終了)
            errorRowNo = 0;
            
            // データテーブルの総件数をカウントし、その中でデータが入力されている行のみチェックを行う
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                if (row.EditFlg)
                {
                    // 品名が空白のデータは無効
                    if (row.MakerCode != "" && row.GoodsCode != "")
                    {
                        if (row.GoodsName.Trim() == "")
                        {
                            // 無効データ行の行番号
                            errorRowNo = (int)row.No;
                            return;
                        }                        
                    }
                }
                // ADD 2009/04/09 ------>>>
                else if (row.MakerCode == "" && row.GoodsCode == "")
                {
                    // 空データなので何もしない
                }
                // 無効データ
                else
                {
                    if (row.GoodsName.Trim() == "")
                    {
                        // 無効データ行の行番号
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
                // ADD 2009/04/09 ------<<<
            }
        }

        /// <summary>
        /// 有効データテーブル行取得処理
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <param name="errorColNm">エラー列名</param>
        /// <param name="effectDataList">有効データ行リスト</param>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// Note			:	データテーブルの中から有効なデータ行のリストを取得する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// <br>--------------------------------------------------------------------------------------</br>
          /// </remarks>
        public void GetEffectiveData(out int errorRowNo, out string errorColNm, out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            // エラーが行番号(0 が正常終了)
            errorRowNo = 0;
            errorColNm = "";
            effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // データテーブルの総件数をカウントし、その中でデータが入力されている行のみチェックを行う
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt ; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                // 2008.08.12 30413 犬飼 登録済みの提供データは対象外 >>>>>>START
                //// 全カラムが入力されている(☆有効データ)
                //if (row.MakerCode != 0 && row.GoodsCode != "")
                //{
                //    effectDataList.Add(row);
                //}
                //// 全カラムが入力されていない。(☆有効データ)
                //else if (row.MakerCode == 0 && row.GoodsCode == "")
                //{
                //    // 空データなので何もしない
                //}
                //// 無効データ
                //else
                //{
                //    // 無効データ行の行番号
                //    errorRowNo = (int)row.No;
                //    return;
                //}
                if (row.EditFlg)
                {
                    // 全カラムが入力されている(☆有効データ)
                    //if (row.MakerCode != 0 && row.GoodsCode != "")
                    if (row.MakerCode != "" && row.GoodsCode != "")
                    {
                        // 2009.02.06 30413 犬飼 QTYの入力チェックを追加 >>>>>>START
                        double cntFl = 0.0;
                        if ((!double.TryParse(row.CntFl, out cntFl)) || (cntFl == 0.0))
                        {
                            // 無効データ行の行番号
                            errorRowNo = (int)row.No;
                            errorColNm = this._goodsDetailDataTable.CntFlColumn.Caption;
                            return;
                        }
                        // 2009.02.06 30413 犬飼 QTYの入力チェックを追加 <<<<<<END
                        
                        effectDataList.Add(row);
                    }
                    // 全カラムが入力されていない。(☆有効データ)
                    //else if (row.MakerCode == 0 && row.GoodsCode == "")
                    else if (row.MakerCode == "" && row.GoodsCode == "")
                    {
                        // 空データなので何もしない
                    }
                    // 無効データ
                    else
                    {
                        // 無効データ行の行番号
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
                // 2008.08.12 30413 犬飼 登録済みの提供データは対象外 <<<<<<END                
            }
        }

        /// <summary>
        /// データテーブル行重複チェック処理
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <param name="errorDispNo">表示順位エラー行番号</param>
        /// <param name="effectDataList">有効データ行リスト</param>
        /// <remarks>
        /// Note			:	データテーブルのデータ行重複チェック処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.18<br />
        /// <br>UpdateNote  : K2019/01/07 譚洪</br>
        /// <br>修正内容    : ランテル様にてセットマスタの最大登録件数を99件に増やすの対応</br>
        /// </remarks>
        public void CheckOverlapData(out int errorRowNo, out int errorDispNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;
            
            // 有効データ全件数取得
            effectRowCnt = effectDataList.Count;

            // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
            errorRowNo = 0;
            errorDispNo = 0;
            // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END

            #region < 比較対象行を設定し全件比較 >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();
                // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
                List<int> equalDispNoList = new List<int>();

                //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ---->>>>>
                //if ((targetRow.Disply < 1) || (targetRow.Disply > 50))
                if ((targetRow.Disply < 1) || 
                    (!this.HaveRuntel && targetRow.Disply > 50) ||
                    (this.HaveRuntel && targetRow.Disply > MaxRowNumForRuntel))
                //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ----<<<<<
                {
                    // 表示順位の範囲が不正
                    equalDispNoList.Add((int)targetRow.No);
                }
                // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END

                #region -- 比較対象を元に行リストを全件比較 --
                for (int j = 0; j < effectRowCnt; j++)
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow compareRow = effectDataList[j];

                    #region - 品番比較 -
                    if (targetRow.GoodsCode == compareRow.GoodsCode)
                    {
                        equalRowNoList.Add((int)compareRow.No);
                    }
                    #endregion

                    // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
                    #region - 表示順位比較 -
                    if (targetRow.Disply == compareRow.Disply)
                    {
                        equalDispNoList.Add((int)compareRow.No);
                    }
                    #endregion
                    // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END

                }
                #endregion

                #region -- 重複Noチェック --
                if (equalRowNoList.Count > 1)
                {
                    // 重複があった最後の行番号を取得して引数に格納
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return ;
                }
                #endregion

                // 2008.08.11 30413 犬飼 表示順位の重複チェック >>>>>>START
                #region -- 重複表示順位チェック --
                if (equalDispNoList.Count > 1)
                {
                    // 重複があった最後の行番号を取得して引数に格納
                    errorDispNo = equalDispNoList[equalDispNoList.Count - 1];
                    return;
                }
                #endregion
                // 2008.08.11 30413 犬飼 表示順位の重複チェック <<<<<<END
            
            }
            #endregion

            // 重複が存在しなかったのでエラー番号は０
            errorRowNo = 0;
        }

        /// <summary>
        /// 親商品との同一品チェック処理
        /// </summary>
        /// <param name="errorRowNo">エラー行番号</param>
        /// <param name="effectDataList">有効データ行リスト</param>
        /// <remarks>
        /// Note			:	親商品との同一品チェック処理を行います。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.15<br />
        /// </remarks>
        public void CheckParentOverlapData(out int errorRowNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;

            // 有効データ全件数取得
            effectRowCnt = effectDataList.Count;

            errorRowNo = 0;
            
            #region < 比較対象行を設定し全件比較 >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();

                #region - 親商品の品番、メーカーと同一比較 -
                if ((targetRow.GoodsCode == this._parentGoodsNo) &&
                    (int.Parse(targetRow.MakerCode) == this._parentMakerCode))
                {
                    equalRowNoList.Add((int)targetRow.No);
                }
                #endregion

                #region -- 親商品同一Noチェック --
                if (equalRowNoList.Count > 0)
                {
                    // 親商品の品番、メーカーと同一のセット商品の行番号を取得して引数に格納
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return;
                }
                #endregion
            }
            #endregion

            // 重複が存在しなかったのでエラー番号は０
            errorRowNo = 0;
        }

        /// <summary>
        /// グリッド内変更確認処理
        /// </summary>
        /// <return>変更フラグ(ON:変更有  OFF:変更無)</return>
        /// <remarks>
        /// Note			:	グリッド内が編集されたかをチェックする処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public bool CheckGridChange()
        {
            return _changeFlg;
        }

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// Note			:	検索する方法を取得する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *が存在しないため完全一致検索
                return 0;
            }
        }

        #region Returnキーダウン処理 修正前
        ///// <summary>
        ///// Returnキーダウン処理
        ///// </summary>
        ///// <returns>true:セル移動完了 false:セル移動失敗</returns>
        //internal bool ReturnKeyDown()
        //{
        //    if (this.uGrid_Details.ActiveCell == null) return false;
        //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
        //    int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;

        //    //bool canMove;
        //    //canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

        //    bool canMove = true;

        //    // 2008.08.22 30413 犬飼 表示順位を追加 >>>>>>START
        //    #region ●ActiveCellが表示順位
        //    if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
        //    {
        //        if (!this._goodsDetailDataTable[cell.Row.Index].EditFlg)
        //        {
        //            this.MoveNextAllowEditCell(false);
        //        }
        //    }
        //    #endregion

        //    #region ●ActiveCellが品番
        //    //if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //    else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //    // 2008.08.22 30413 犬飼 表示順位を追加 <<<<<<END
        //    {
        //        // 2008.08.22 30413 犬飼 行が変更不可時の処理を追加 >>>>>>START
        //         ActiveCellの行が変更不可の場合は編集可能な行へ
        //        if (!this._goodsDetailDataTable[cell.Row.Index].EditFlg)
        //        {
        //            this.MoveNextAllowEditCell(false);
        //        }
        //        // 2008.08.22 30413 犬飼 行が変更不可時の処理を追加 <<<<<<END

        //        if (!this._setGoodNoUpdFlg)
        //        {
        //            this._setGoodNoUpdFlg = true;
        //            // 品番取得区分がfalseの場合(検索失敗時は次のセルへ遷移しない)
        //            return this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
        //        }
                
        //        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
        //        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

        //        // ActiveCellが変更していない場合はNextCellを実行する
        //        if (this.uGrid_Details.ActiveCell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //        {
        //            #region < 品番未入力 >
        //            if (this._goodsDetailDataTable[cell.Row.Index].GoodsCode == "")
        //            {
        //                canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
        //            }
        //            #endregion

        //            #region < 品番入力 >
        //            else
        //            {
        //                string goodsCode = cell.Value.ToString();

        //                if (!String.IsNullOrEmpty(goodsCode))
        //                {
        //                    string searchCode;

        //                    // 検索の種類を取得
        //                    int searchType = this.GetSearchType(goodsCode, out searchCode);

        //                    List<GoodsUnitData> goodsUnitDataList;
        //                    string message;

        //                    // 2008.08.06 30413 犬飼 商品検索処理の変更 >>>>>>START
        //                    #region < 商品検索処理 > <<<<<<変更前
        //                    //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
        //                    //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
        //                    #endregion

        //                    #region < 商品検索処理 >
        //                    string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
        //                    GoodsCndtn goodsCndtn = new GoodsCndtn();
        //                    //GoodsAcs goodsAcs = new GoodsAcs();

        //                    // 商品検索条件設定
        //                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //                    goodsCndtn.SectionCode = sectionCd;
        //                    goodsCndtn.GoodsMakerCd = 0;
        //                    goodsCndtn.MakerName = "";
        //                    goodsCndtn.GoodsNo = goodsCode;
        //                    goodsCndtn.GoodsNoSrchTyp = searchType;

        //                    //int status = goodsAcs.SearchInitial(this._enterpriseCode, sectionCd, out message);
        //                    // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 >>>>>>START
        //                    //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out goodsUnitDataList, out message);
        //                    //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //                    int status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //                    // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 <<<<<<END
        //                    #endregion
        //                    // 2008.08.06 30413 犬飼 商品検索処理の変更 <<<<<<END

        //                    #region -- 取得成功 --
        //                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //                    {
        //                        // 商品マスタデータクラス
        //                        GoodsUnitData goodsUnitData = new GoodsUnitData();
        //                        goodsUnitData = goodsUnitDataList[0];
        //                        // 商品マスタ情報設定処理
        //                        this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

        //                        // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 >>>>>>START
        //                        // 取得した商品連結データをキャッシュとして保持
        //                        if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
        //                        {
        //                            _lcGoodsUnitDataList.Add(goodsUnitData);
        //                        }
        //                        // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 <<<<<<END
        //                    }
        //                    #endregion

        //                    #region -- 取得失敗 --
        //                    else
        //                    {
        //                        TMsgDisp.Show(
        //                            this,
        //                            emErrorLevel.ERR_LEVEL_INFO,
        //                            this.Name,
        //                            // 2008.08.06 30413 犬飼 商品コード→品番に変更 >>>>>>START
        //                            //"商品コード [" + searchCode + "] に該当するデータが存在しません。",
        //                            "品番 [" + searchCode + "] に該当するデータが存在しません。",
        //                            // 2008.08.06 30413 犬飼 商品コード→品番に変更 <<<<<<END
        //                            -1,
        //                            MessageBoxButtons.OK);

        //                        // 項目クリア
        //                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // 品番
        //                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // 品名
        //                        //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;       // メーカーコード
        //                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";       // メーカーコード
        //                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // メーカー名称
        //                    }
        //                    #endregion
        //                }
        //                else
        //                {
        //                    // 品番を元に戻す
        //                    this._goodsDetailDataTable[cell.Row.Index].GoodsCode = this._beforeGoodsCode;
        //                    // 品名のクリア
        //                    this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";
        //                    //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;       // メーカーコード
        //                    this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";       // メーカーコード
        //                    this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // メーカー名称
        //                }
        //            }

        //            #endregion
        //        }
        //    }
        //    #endregion

        //    #region ●ActiveCellが品名
        //    else if (cell.Column.Key == this._goodsDetailDataTable.GoodsNameColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);
        //    }
        //    #endregion

        //    #region ●ActiveCellがメーカー名称
        //    else if (cell.Column.Key == this._goodsDetailDataTable.MakerNameColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);
        //    }
        //    #endregion

        //    #region ●ActiveCellがメーカーコード
        //    else if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
        //    {
        //        // 2008.08.22 30413 犬飼 行が変更不可時の処理を追加 >>>>>>START
        //        this.MoveNextAllowEditCell(false);
        //        // 2008.08.22 30413 犬飼 行が変更不可時の処理を追加 <<<<<<END

        //        // 2008.08.22 30413 犬飼 メーカーコードは編集不可に変更 >>>>>>START
        //        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
        //        //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

        //        //// ActiveCellが変更していない場合はNextCellを実行する
        //        //if (this.uGrid_Details.ActiveCell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
        //        //{
        //        //    #region < メーカーコード未入力 >
        //        //    if (this._goodsDetailDataTable[cell.Row.Index].MakerCode == 0)
        //        //    {
        //        //        //canMove = this.MoveNextAllowEditCell(false);
        //        //        canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
        //        //    }
        //        //    #endregion

        //        //    #region < メーカーコード入力 >
        //        //    else
        //        //    {
        //        //        int searchCode = (int)cell.Value;

        //        //        if (!String.IsNullOrEmpty(searchCode.ToString()))
        //        //        {
        //        //            MakerUMnt makerUMnt;
        //        //            GoodsAcs goodsAcs = new GoodsAcs();
        //        //            string msg;
        //        //            goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

        //        //            // ◎商品検索のメーカーマスタ情報取得メソッドを呼び出す
        //        //            int status = goodsAcs.GetMaker(this._enterpriseCode, searchCode, out makerUMnt);

        //        //            #region -- 取得成功 --
        //        //            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (makerUMnt != null))
        //        //            {
        //        //                // メーカーマスタ情報設定処理
        //        //                this.MakerDetailRowGoodsSetSetting(goodsRowNo, makerUMnt);

        //        //                // 商品コードが入力されるように制御する
        //        //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //        //                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //        //                this.uGrid_Details.ActiveCell.SelStart = 0;
        //        //                this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //        //            }
        //        //            #endregion

        //        //            #region -- 取得失敗 --
        //        //            else
        //        //            {
        //        //                TMsgDisp.Show(
        //        //                    this,
        //        //                    emErrorLevel.ERR_LEVEL_INFO,
        //        //                    this.Name,
        //        //                    "メーカーコード [" + searchCode + "] に該当するデータが存在しません。",
        //        //                    -1,
        //        //                    MessageBoxButtons.OK);

        //        //                // メーカーコードの初期化
        //        //                //this._goodsDetailDataTable[cell.Row.Index].MakerCode = this._beforeMakerCode;
        //        //                this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;
        //        //            }
        //        //            #endregion
        //        //        }
        //        //    }
        //        //    #endregion
        //        //}
        //        // 2008.08.22 30413 犬飼 メーカーコードは編集不可に変更 <<<<<<END
        //    }
        //    #endregion

        //    // 2008.08.22 30413 犬飼 ＱＴＹ、セット規格、提供区分を追加 >>>>>>START
        //    #region ●ActiveCellがＱＴＹ
        //    else if (cell.Column.Key == this._goodsDetailDataTable.CntFlColumn.ColumnName)
        //    {
        //        if (!this._goodsDetailDataTable[cell.Row.Index].EditFlg)
        //        {
        //            this.MoveNextAllowEditCell(false);
        //        }
        //    }
        //    #endregion

        //    #region ●ActiveCellがセット規格・特記事項
        //    else if (cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);                
        //    }
        //    #endregion

        //    #region ●ActiveCellが提供区分
        //    else if (cell.Column.Key == this._goodsDetailDataTable.DivisionColumn.ColumnName)
        //    {
        //        canMove = this.MoveNextAllowEditCell(false);
        //    }
        //    #endregion
        //    // 2008.08.22 30413 犬飼 ＱＴＹ、セット規格、提供区分を追加 <<<<<<END
            
        //    #region ●ActiveCellがガイドボタンの場合
        //    // 2008.08.04 30413 犬飼 ガイドボタンの削除 >>>>>>START
        //    //else if ((cell.Column.Key == this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName) ||
        //    //        (cell.Column.Key == this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName))
        //    //{
        //    //    // 次入力可能セル移動処理
        //    //    canMove = this.MoveNextAllowEditCell(false);
        //    //}
        //    // 2008.08.04 30413 犬飼 商品検索ガイドボタンの削除 <<<<<<END
        //    #endregion

        //    return canMove;
        //}
        #endregion

        #region Returnキーダウン処理 修正後
        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;

            bool moveFlg = this.MoveNextAllowEditCell(false);
            if (moveFlg)
            {
                return moveFlg;
            }
            else
            {
                return moveFlg;
            }
        }
        #endregion

        #region Returnキーダウン処理(Shift+TAB用)
        /// <summary>
        /// Returnキーダウン処理(Shift+TAB用)
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown2()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            
            bool canMove = this.MovePrevAllowEditCell(false);

            return canMove;
        }
        #endregion

        #endregion

        #region ◆Private Methods

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// Note			:	グリッドの初期設定をします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.10<br />
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// Note			:	入力コンポーネントが編集不可のときの文字の色を変更<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.07.10<br />
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// Note			:	商品コードを左詰めで表示するように変更<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.07.14<br />
        /// <br>--------------------------------------------------------------------------------------------</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            // ガイドボタンのアイコン
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            
            // 入力フォーム画面表示のためデータテーブル初期化
            this._goodsDetailDataTable.Clear();

            // 2008.08.04 30413 犬飼 表示幅設定の変更 >>>>>>START
            #region ●表示幅設定 <<<<<<変更前
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Width = 50;                   // No
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Width = 50;               // 表示順位
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Width = 120;           // メーカーコード 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].Width = 25;     // メーカーガイドボタン
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Width = 150;           // メーカー名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Width = 120;           // 品番
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].Width = 25;     // 商品ガイドボタン
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Width = 300;           // 品名
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Width = 50;                // 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Width = 50;              // セット規格・特記事項
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].Width = 50;         // カタログ図番
            #endregion

            if (_initialLoadFlag) // ADD gaocheng　2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応
            {
                #region ●表示幅設定
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Width = 50;                   // No
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Width = 50;               // 表示順位
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Width = 120;           // 品番
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Width = 300;           // 品名
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Width = 120;           // メーカーコード 
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Width = 150;           // メーカー名称
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Width = 80;                // ＱＴＹ(数量)
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Width = 300;             // セット規格・特記事項
                // 2009.02.06 30413 犬飼 文字切れのため表示幅を修正 >>>>>>START
                //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].Width = 50;             // 提供区分
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].Width = 100;            // 提供区分
                // 2009.02.06 30413 犬飼 文字切れのため表示幅を修正 <<<<<<END
            } // ADD gaocheng　2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応s
            #endregion
            // 2008.08.04 30413 犬飼 表示幅設定の変更 <<<<<<END

            // 2008.08.04 30413 犬飼 セル内のデータ表示位置設定の変更 >>>>>>START
            #region ●セル内のデータ表示位置設定 <<<<<<変更前
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion

            #region ●セル内のデータ表示位置設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            #endregion
            
            // 2008.08.04 30413 犬飼 セル内のデータ表示位置設定の変更 <<<<<<END
            
            #region ●セル内の入力項目大文字小文字設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            // 2008.12.17 30413 犬飼 大文字設定を通常に変更 >>>>>>START
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            // 2008.12.17 30413 犬飼 大文字設定を通常に変更 <<<<<<END
            // 2008.08.04 30413 犬飼 カタログ図番の削除 >>>>>>START
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            // 2008.08.04 30413 犬飼 カタログ図番の削除 <<<<<<END
            #endregion

            #region ●表示カーソル設定
            // 2008.08.04 30413 犬飼 ガイドボタンの削除 >>>>>>START
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            // 2008.08.04 30413 犬飼 ガイドボタンの削除 <<<<<<END
            #endregion

            // 2008.08.04 30413 犬飼 スタイル設定の変更 >>>>>>START
            #region ●スタイル設定 <<<<<<変更前
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // 表示順位
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // メーカーコード 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;       // メーカーガイドボタン
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // メーカー名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // 商品コード
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;       // 商品ガイドボタン
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // 商品名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                    // 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // セット規格・特記事項
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;             // カタログ図番
            #endregion

            #region ●スタイル設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // 表示順位
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // 品名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // メーカーコード 
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                    // ＱＴＹ(数量)
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // セット規格・特記事項
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                 // 提供区分
            #endregion
            // 2008.08.04 30413 犬飼 スタイル設定の変更 <<<<<<END
            
            #region ●個別設定
            
            // 2008.08.07 30413 犬飼 メーカーガイドボタンの削除 >>>>>>START
            #region < メーカーガイドボタン >
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            #endregion
            // 2008.08.07 30413 犬飼 メーカーガイドボタンの削除 <<<<<<END
            
            // 2008.08.04 30413 犬飼 商品検索ガイドボタンの削除 >>>>>>START
            #region < 商品ガイドボタン >
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.Image = this._guideButtonImage;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
            #endregion
            // 2008.08.04 30413 犬飼 商品検索ガイドボタンの削除 <<<<<<END
            
            #region < No >
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion
            
            #endregion

            #region ●入力制御
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;           // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// 品番
            // 2008.08.04 30413 犬飼 メーカーコード、提供区分の追加 >>>>>>START
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// メーカーコード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		// 提供区分
            // 2008.08.04 30413 犬飼 メーカーコード、提供区分の追加 <<<<<<END
            #endregion

            #region ●フォーマット設定

            string codeFormat = "#0;-#0;''";

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Format = codeFormat;

            #endregion

            // 2008.08.06 30413 犬飼 列幅の可変設定の追加 >>>>>>START
            #region ●列幅の可変設定
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.uGrid_Details.DisplayLayout.Bands[0].Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.EntireColumn;
            #endregion
            // 2008.08.06 30413 犬飼 列幅の可変設定の追加 <<<<<<END

            // 2008.08.07 30413 犬飼 列の非表示設定の追加 >>>>>>START
            #region ●列の非表示設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Hidden = true;               // 編集可否
            // 2008.10.30 30413 犬飼 追加フラグ >>>>>>START
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.AddFlagColumn.ColumnName].Hidden = true;               // 追加フラグ
            // 2008.10.30 30413 犬飼 追加フラグ <<<<<<END
            #endregion
            // 2008.08.07 30413 犬飼 列の非表示設定の追加 <<<<<<END

            // 2008.08.08 30413 犬飼 列の順序設定の追加 >>>>>>START
            #region ●列の順序設定
            // 列の移動を許可
            this.uGrid_Details.DisplayLayout.Bands[0].Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup;
            // 列の固定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.Fixed = true;              // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.Fixed = true;          // 表示順序
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.Fixed = true;       // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;       // 品名
            #endregion
            // 2008.08.08 30413 犬飼 列の順序設定の追加 <<<<<<END
            
            #region ●新規入力行作成

            int count;
            for (count = 1; count <= _defaultRowCnt; count++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
                detailRow.No = (short)count;
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
                
            }

            #endregion

            // 2008.08.04 30413 犬飼 変更不可時フォントカラー設定の変更 >>>>>>START
            #region ●変更不可時フォントカラー設定 <<<<<<変更前
            //// 2007.07.10 add by T-Kidate
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // 表示順位
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // メーカーコード 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;    // メーカーガイドボタン
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // メーカー名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // 商品コード
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;    // 商品ガイドボタン
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // 商品名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;               // 数量
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;             // セット規格・特記事項
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;        // カタログ図番
            #endregion

            #region ●変更不可時フォントカラー設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // 表示順位
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // 品名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // メーカーコード 
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;           // メーカー名称
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;               // ＱＴＹ(数量)
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;             // セット規格・特記事項
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DivisionColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // 提供区分
            #endregion
            // 2008.08.04 30413 犬飼 変更不可時フォントカラー設定の変更 >>>>>>START
            
            #region ●左詰め設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;  // 商品コード
            #endregion

            // 2008.08.22 30413 犬飼 1行目の表示順位をアクティブセルに設定 >>>>>>START
            this.uGrid_Details.Rows[0].Activate();
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
            // 2008.08.22 30413 犬飼 1行目の表示順位をアクティブセルに設定 <<<<<<END
        }

        /// <summary>
		/// ボタン初期設定処理
		/// </summary>
        /// <remarks>
        /// Note			:	ボタンの初期設定をします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;

            this.uButton_RowInsert.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;

            this.uButton_RowInsert.Appearance.Image = (int)Size16_Index.ROWINSERT;
            this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;

            this.uButton_RowInsert.Enabled = true;
            this.uButton_RowDelete.Enabled = true;
			
            // 変更フラグOFF
            this._changeFlg = false;
        }

        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        /// <remarks>
        /// Note			:	ボタンの初期設定をします。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
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
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        /// <remarks>
        /// Note			:	ActiveRowインデックスを取得する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            // --- ADD m.suzuki 2010/08/04 ---------->>>>>
            if ( this.uGrid_Details.ActiveCell == null )
            {
                return false;
            }
            // --- ADD m.suzuki 2010/08/04 ----------<<<<<

            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            // 2008.08.22 30413 犬飼 セルのフォーカス設定を変更 >>>>>>START
            else
            {
                while (!moved)
                {
                    if (!this._goodsDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].EditFlg)
                    {
                        int rowCnt = this.uGrid_Details.ActiveCell.Row.Index;
                        while (!this._goodsDetailDataTable[rowCnt].EditFlg)
                        {
                            rowCnt++;
                        }
                        this.uGrid_Details.Rows[rowCnt].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                        moved = true;
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                        if (!this._setGoodNoUpdFlg)
                        {
                            // 更新フラグがfalse
                            this._setGoodNoUpdFlg = true;
                            // 移動前のcellをアクティブ
                            performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                            moved = true;
                        }

                        if (performActionResult)
                        {
                            if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                            {
                                moved = true;
                            }
                            else
                            {
                                moved = false;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            //while (!moved)
            //{
            //    performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

            //    if (performActionResult)
            //    {
            //        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
            //            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
            //        {
            //            moved = true;
            //        }
            //        else
            //        {
            //            moved = false;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            // 2008.08.22 30413 犬飼 セルのフォーカス設定を変更 <<<<<<END
                
            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	前の入力可能なセルにフォーカスを移動する処理を行います。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.15<br />
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    if (!this._goodsDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].EditFlg)
                    {
                        int rowCnt = this.uGrid_Details.ActiveCell.Row.Index;
                        while (!this._goodsDetailDataTable[rowCnt].EditFlg)
                        {
                            rowCnt--;
                        }
                        this.uGrid_Details.Rows[rowCnt].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                        moved = true;
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                        if (performActionResult)
                        {
                            if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                            {
                                moved = true;
                            }
                            else
                            {
                                moved = false;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }


        /// <summary>
        /// セット商品情報行挿入処理
        /// </summary>
        /// <param name="insertIndex">挿入行Index</param>
        /// <remarks>
        /// Note			:	セット商品情報の空行を選択された行に挿入する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void InsertGoodsDetailRow(int insertIndex)
        {
            this.InsertGoodsDetailRow(insertIndex, 1);
        }

        /// <summary>
        /// セット商品情報行挿入処理（オーバーロード）
        /// </summary>
        /// <param name="insertIndex">挿入行Index</param>
        /// <param name="line">挿入段数</param>
        /// <remarks>
        /// Note			:	セット商品情報の空行を選択された行に挿入する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void InsertGoodsDetailRow(int insertIndex, int line)
        {
            this._goodsDetailDataTable.BeginLoadData();
            
            // 空行を追加する前の最終行のインデックスを保持
            int lastRowIndex = this._goodsDetailDataTable.Rows.Count - 1;
            // 選択された行の行Noを保持
            int goodsRowNo = this._goodsDetailDataTable[insertIndex].No;

            // セット商品情報行追加処理
            for (int i = 0; i < line; i++)
            {
                // 子商品を１行追加する
                this.AddGoodsDetailRow();
            }

            // 最終行から挿入対象行までの行情報を指定段ずつ下にコピーする
            for (int i = lastRowIndex; i >= insertIndex; i--)
            {
                // コピー元行の取得
                GoodsSetGoodsDataSet.GoodsSetDetailRow sourceRow = this._goodsDetailDataTable.FindByNo(this._goodsDetailDataTable[i].No);
                // コピー先行の取得
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = this._goodsDetailDataTable.FindByNo(this._goodsDetailDataTable[i + line].No);

                this.CopyGoodsDetailRow(sourceRow, targetRow);
            }

            // 挿入対象行をクリアする
            GoodsSetGoodsDataSet.GoodsSetDetailRow clearRow = this._goodsDetailDataTable.FindByNo(this._goodsDetailDataTable[insertIndex].No);
            this.ClearGoodsDetailRow(clearRow);

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// セット商品情報行コピー処理
        /// </summary>
        /// <param name="sourceRow">コピー元セット商品情報データテーブル行クラス</param>
        /// <param name="targetRow">コピー先セット商品情報データテーブル行クラス</param>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行をコピーする処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void CopyGoodsDetailRow(GoodsSetGoodsDataSet.GoodsSetDetailRow sourceRow, GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow)
        {
            if ((sourceRow == null) || (targetRow == null)) return;
            
            // 全カラムの情報をコピー先行にコピーする
            targetRow.Disply            = sourceRow.Disply;             // 表示順位 
            targetRow.MakerCode         = sourceRow.MakerCode;          // メーカーコード
            targetRow.MakerName         = sourceRow.MakerName;          // メーカー名称
            targetRow.GoodsCode         = sourceRow.GoodsCode;          // 品番
            targetRow.GoodsName         = sourceRow.GoodsName;          // 品名
            targetRow.CntFl             = sourceRow.CntFl;              // ＱＴＹ(数量)
            targetRow.SetNote           = sourceRow.SetNote;            // セット規格
            // 2008.08.04 30413 犬飼 カタログ図番の削除 >>>>>>START
            //targetRow.CatalogShape = sourceRow.CatalogShape;         // カタログ図番
            // 2008.08.04 30413 犬飼 カタログ図番の削除 <<<<<<END

            // 2008.08.04 30413 犬飼 提供区分の追加 >>>>>>START
            targetRow.Division = sourceRow.Division;                    // 提供区分
            // 2008.08.04 30413 犬飼 提供区分の追加 <<<<<<END

            // 2008.08.07 30413 犬飼 編集可否の追加 >>>>>>START
            targetRow.EditFlg = sourceRow.EditFlg;                      // 編集可否
            // 2008.08.07 30413 犬飼 編集可否の追加 <<<<<<END

            // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
            targetRow.AddFlag = sourceRow.AddFlag;                      // 追加フラグ
            // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END
        }

        /// <summary>
        /// セット商品情報行クリア処理
        /// </summary>
        /// <param name="row">セット商品情報データテーブル行クラス</param>
        /// <remarks>
        /// Note			:	セット商品情報の行をクリアする処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void ClearGoodsDetailRow(GoodsSetGoodsDataSet.GoodsSetDetailRow row)
        {
            if (row == null) return;

            // ガイドボタン以外に初期値を格納する
            row.Disply    = 0;
            //row.MakerCode = 0;
            row.MakerCode = "";
            row.MakerName = ""; 
            row.GoodsCode = "";
            row.GoodsName = "";
            //row.CntFl     = 0;
            row.CntFl = "";
            row.SetNote   = "";
            // 2008.08.04 30413 犬飼 カタログ図番の削除 >>>>>>START
            //row.CatalogShape = "";
            // 2008.08.04 30413 犬飼 カタログ図番の削除 <<<<<<END

            // 2008.08.04 30413 犬飼 提供区分の追加 >>>>>>START
            row.Division = "";
            // 2008.08.04 30413 犬飼 提供区分の追加 <<<<<<END

            // 2008.08.07 30413 犬飼 編集可否の追加 >>>>>>START
            row.EditFlg = true;
            // 2008.08.07 30413 犬飼 編集可否の追加 <<<<<<END

            // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
            row.AddFlag = true;
            // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END            
        }

        /// <summary>
        /// 選択済みセット商品情報行番号リスト取得処理
        /// </summary>
        /// <returns>選択済みセット商品情報行番号リスト</returns>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行番号を取得する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private List<int> GetSelectedGoodsRowNoList()
        {
            // 選択されたセルを取得
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            // 選択された行を取得する
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedGoodsRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                selectedGoodsRowNoList.Add(this._goodsDetailDataTable[cell.Row.Index].No);
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    selectedGoodsRowNoList.Add(this._goodsDetailDataTable[row.Index].No);
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedGoodsRowNoList;
        }

        /// <summary>
        /// セット商品情報行削除可能チェック処理
        /// </summary>
        /// <param name="goodsRowNoList">削除行StockRowNoリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>true:行削除可能 false:行削除不可</returns>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行番号が削除可能かチェックする処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private bool CanDeleteGoodsDetailRow(List<int> goodsRowNoList, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// セット商品情報行削除処理
        /// </summary>
        /// <param name="goodsRowNoList">削除行Noリスト</param>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行を削除する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// <br>UpdateNote  :   2010/12/03  鄧潘ハン</br>
        /// <br>修正内容    :   １．明細行を全て削除後に、ヘッダ部の削除ボタンを押下するとエラーが発生する不具合の修正</br>
        /// <br>                ２．複数行の明細があるセット品の明細の一部を行削除し、ヘッダ部の削除ボタンを実行した場合の削除処理の不正</br>
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList)
        {
            this.DeleteGoodsDetailRow(goodsRowNoList, false);
            // ---DEL 2010/12/03 ---------------------------------------->>>>>
            // 2009/09/16 Add >>>
            // 行削除後に削除データテーブル初期化
            //this._deleteGoodsDetailDataTable.Clear();
            // 2009/09/16 Add <<<
            // ---DEL 2010/12/03 ----------------------------------------<<<<<
        }

        /// <summary>
        /// セット商品情報行削除処理(オーバーロード)
        /// </summary>
        /// <param name="goodsRowNoList">削除行StockRowNoリスト</param>
        /// <param name="changeRowCount">true:行数を変更する false:行数を変更するは変更しない</param>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行を削除する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList, bool changeRowCount)
        {
            this._goodsDetailDataTable.BeginLoadData();
            foreach (int goodsRowNo in goodsRowNoList)
            {
                // 削除対象行情報を取得する
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);
                if (targetRow == null) continue;

                // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
                // 2008.08.12 30413 犬飼 削除対象行を退避 >>>>>>START
                // 削除対象行を退避
                //if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != 0))
                //if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != ""))
                if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != "") && (!targetRow.AddFlag))
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._deleteGoodsDetailDataTable.NewGoodsSetDetailRow();
                    row.No = targetRow.No;
                    row.Disply = targetRow.Disply;
                    row.GoodsCode = targetRow.GoodsCode;
                    row.GoodsName = targetRow.GoodsName;
                    row.MakerCode = targetRow.MakerCode;
                    row.MakerName = targetRow.MakerName;
                    row.CntFl = targetRow.CntFl;
                    row.SetNote = targetRow.SetNote;
                    row.Division = targetRow.Division;
                    row.EditFlg = targetRow.EditFlg;
                    row.AddFlag = targetRow.AddFlag;
                    this._deleteGoodsDetailDataTable.AddGoodsSetDetailRow(row);
                }
                // 2008.08.12 30413 犬飼 削除対象行を退避 <<<<<<END
                // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END
                
                // 対象行削除処理
                this._goodsDetailDataTable.RemoveGoodsSetDetailRow(targetRow);
            }

            // セット商品情報データテーブルStockRowNo列初期化処理
            this.InitializeGoodsSetDetailRowNoColumn();

            if (!changeRowCount)
            {
                // 削除した分だけ新規に行を追加する
                for (int i = 0; i < goodsRowNoList.Count; i++)
                {
                    this.AddGoodsDetailRow();
                }
            }
            this._goodsDetailDataTable.EndLoadData();

        }

        /// <summary>
        /// セット商品情報データテーブルNo列初期化処理
        /// </summary>
        /// <remarks>
        /// Note			:	セット商品情報データテーブルのNoを初期化する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void InitializeGoodsSetDetailRowNoColumn()
        {
            this._goodsDetailDataTable.BeginLoadData();

            for (int i = 0; i < this._goodsDetailDataTable.Rows.Count; i++)
            {
                this._goodsDetailDataTable[i].No = (short)(i + 1);
            }

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// セルアクティブ時ボタン有効無効コントロール処理
        /// </summary>
        /// <param name="index">行インデックス</param>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行を削除する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void ActiveCellButtonEnabledControl(int index)
        {
            // 行操作ボタンの有効無効を設定する
            //int makerCode = this._goodsDetailDataTable[index].MakerCode;
            int makerCode = int.Parse(this._goodsDetailDataTable[index].MakerCode); 
            string goodsCode = this._goodsDetailDataTable[index].GoodsCode;

            if (makerCode == 0 && goodsCode == "")
            {
                this.uButton_RowInsert.Enabled = true;
                
            }
            else
            {

            }
        }

        /// <summary>
        /// セット商品情報データセッティング処理（商品セット情報設定）
        /// </summary>
        /// <param name="goodsRowNo">セット商品情報行番号</param>
        /// <param name="goodsUnitData">商品セット内容クラスリスト</param>
        /// <remarks>
        /// Note			:	セット商品情報行に商品セット内容を追加します。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void GoodsDetailRowGoodsSetSetting(int goodsRowNo, GoodsUnitData goodsUnitData)
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            // ガイドデータ展開
            //row.MakerCode = goodsUnitData.GoodsMakerCd;
            row.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");
            row.MakerName = goodsUnitData.MakerName;
            row.GoodsCode = goodsUnitData.GoodsNo;
            row.GoodsName = goodsUnitData.GoodsName;
            // 2008.08.06 30413 犬飼 提供区分の追加 >>>>>>START
            switch (goodsUnitData.OfferKubun)
            {
                case 0:     // ユーザー登録
                case 1:     // 提供純正編集
                case 2:     // 提供優良編集
                    {
                        // ユーザー
                        row.Division = GoodsSetAcs.DIVISION_NAME_USER;
                        break;
                    }
                case 3:     // 3:提供純正
                case 4:     // 4:提供優良
                case 5:     // 5:TBO
                case 7:     // 7:オリジナル
                    {
                        // 提供
                        row.Division = GoodsSetAcs.DIVISION_NAME_OFFER;
                        break;
                    }
            }
            // 2008.08.06 30413 犬飼 提供区分の追加 <<<<<<END
            // 2008.08.07 30413 犬飼 編集可否の追加 >>>>>>START
            row.EditFlg = true;
            // 2008.08.07 30413 犬飼 編集可否の追加 <<<<<<END

            // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
            row.AddFlag = true;
            // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END                    

            // 次行が存在しない場合は新規に追加する
            if (goodsRowNo == (this._goodsDetailDataTable.Rows.Count + 1))
            {
                this.AddGoodsDetailRow();
            }
        }

        /// <summary>
        /// セット商品情報データセッティング処理（メーカー情報設定）
        /// </summary>
        /// <param name="goodsRowNo">セット商品情報行番号</param>
        /// <param name="makerUMnt">メーカー内容クラスリスト</param>
        /// <remarks>
        /// Note			:	選択されたセット商品情報の行にメーカー情報を設定する処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.11<br />
        /// </remarks>
        private void MakerDetailRowGoodsSetSetting(int goodsRowNo, MakerUMnt makerUMnt)
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            // ガイドデータ展開
            //row.MakerCode = makerUMnt.GoodsMakerCd;
            row.MakerCode = makerUMnt.GoodsMakerCd.ToString("d04");
            row.MakerName = makerUMnt.MakerName;

            // メーカーが設定されたらデータの整合性をあわせるため商品情報をクリアする
            row.GoodsCode = "";
            row.GoodsName = "";
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
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// Programmer		:	30005 木建　翼<br />
        /// Date			:	2007.05.14<br />
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
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
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 2008.10.15 30413 犬飼 小数点チェックはマイナス入力フラグと分離 >>>>>>START
            // 小数点のチェック
            if (key == '.')
            {
                //// 小数点(マイナス)が入力可能か？
                //if (minusFlg == false)
                //{
                //    return false;
                //}
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }       
            }
            // 2008.10.15 30413 犬飼 小数点チェックはマイナス入力フラグと分離 <<<<<<END
            
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
                // 2008.10.15 30413 犬飼 桁数チェックを小数点対応 >>>>>>START
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                // 2008.10.15 30413 犬飼 桁数チェックを小数点対応 <<<<<<END
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 提供区分で編集不可の制御を行う
        /// </summary>
        /// <remarks>
        /// Note			:	提供区分で編集不可を設定する処理を行います。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.08.07<br />
        /// </remarks>
        private void ChangeRowActivation_Division()
        {
            int rowCnt = this._goodsDetailDataTable.Rows.Count;
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // 行テーブル
            for (int i = 0; i < rowCnt; i++)
            {
                // データテーブルを取得
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];
                // 行番号を取得
                int rowNo = detailRow.No - 1;

                if ((detailRow.Division == GoodsSetAcs.DIVISION_NAME_OFFER) && !detailRow.EditFlg)
                {
                    // 提供データは編集不可
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.CntFlColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    // ユーザーデータは編集可
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.CntFlColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    this.uGrid_Details.Rows[rowNo].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;                    
                }
            }
        }

        #endregion

        # region ◆Control Event Methods

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
        }

        // 2008.10.30 30413 犬飼 未使用イベントの削除 >>>>>>START
        #region グリッドセルアップデート後イベント
        ///// <summary>
        ///// グリッドセルアップデート後イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        //{
        //    // 変更フラグON
        //    _changeFlg = true;
            
        //    if (e.Cell == null) return;

        //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
        //    int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;
        //    int rowIndex = e.Cell.Row.Index;

        //    // 数値項目が空の場合
        //    if (e.Cell.Value is DBNull)
        //    {
        //        if ((e.Cell.Column.DataType == typeof(Int32)) ||
        //            (e.Cell.Column.DataType == typeof(Int64)) ||
        //            (e.Cell.Column.DataType == typeof(double)))
        //        {
        //            e.Cell.Value = 0;
        //        }
        //    }

        //    #region ●ActiveCellが品番の場合
        //    if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
        //    {
        //        string goodsCode = cell.Value.ToString();

        //        // 品番更新区分の初期設定
        //        this._setGoodNoUpdFlg = true;

        //        if (!String.IsNullOrEmpty(goodsCode))
        //        {
        //            #region ■入力有
        //            string searchCode;

        //            #region < 検索種類取得 >
        //            int searchType = this.GetSearchType(goodsCode, out searchCode);
        //            #endregion

        //            List<GoodsUnitData> goodsUnitDataList;
        //            string message;

        //            // 2008.08.06 30413 犬飼 商品検索処理の変更 >>>>>>START
        //            #region < 商品名称取得 > <<<<<<変更前
        //            //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
        //            //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
        //            #endregion

        //            #region < 品名取得 >
        //            string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
        //            GoodsCndtn goodsCndtn = new GoodsCndtn();
        //            //GoodsAcs goodsAcs = new GoodsAcs();

        //            // 商品検索条件設定
        //            goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //            goodsCndtn.SectionCode = sectionCd;
        //            goodsCndtn.GoodsMakerCd = 0;
        //            goodsCndtn.MakerName = "";
        //            goodsCndtn.GoodsNo = goodsCode;
        //            goodsCndtn.GoodsNoSrchTyp = searchType;

        //            //int status = goodsAcs.SearchInitial(this._enterpriseCode, sectionCd, out message);
        //            // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 >>>>>>START
        //            //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out goodsUnitDataList, out message);
        //            //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //            int status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
        //            // 2008.08.26 30413 犬飼 商品アクセスクラスのメソッド変更 <<<<<<END
        //            #endregion
        //            // 2008.08.06 30413 犬飼 商品検索処理の変更 <<<<<<END

        //            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
        //            {
        //                #region -- 正常取得 --
        //                // 商品マスタデータクラス
        //                GoodsUnitData goodsUnitData = new GoodsUnitData();
        //                goodsUnitData = goodsUnitDataList[0];
                        
        //                // 商品マスタ情報設定処理
        //                this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

        //                // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 >>>>>>START
        //                // 取得した商品連結データをキャッシュとして保持
        //                if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
        //                {
        //                    _lcGoodsUnitDataList.Add(goodsUnitData);
        //                }
        //                // 2008.08.21 30413 犬飼 商品連結ローカルキャッシュ用データリスト追加 <<<<<<END
        //                #endregion
        //            }
        //            else
        //            {
        //                #region -- 取得失敗 --
        //                TMsgDisp.Show(
        //                    this,
        //                    emErrorLevel.ERR_LEVEL_INFO,
        //                    this.Name,
        //                    // 2008.08.06 30413 犬飼 商品コード→品番に変更 >>>>>>START
        //                    //"商品コード [" + searchCode + "] に該当するデータが存在しません。",
        //                    "品番 [" + searchCode + "] に該当するデータが存在しません。",
        //                    // 2008.08.06 30413 犬飼 商品コード→品番に変更 <<<<<<END
        //                    -1,
        //                    MessageBoxButtons.OK);

        //                // 対象行のクリア
        //                //this._goodsDetailDataTable[cell.Row.Index].GoodsCode = this._beforeGoodsCode;
        //                this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // 品番
        //                this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // 品名
        //                // 2008.08.20 30413 犬飼 メーカーもクリア >>>>>>START
        //                //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;           // メーカーコード
        //                this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // メーカーコード
        //                this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // メーカー名称
        //                this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
        //                this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // セット規格・特記事項
        //                this._goodsDetailDataTable[cell.Row.Index].Division = "";       // 提供区分
        //                this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // 編集可否フラグ
        //                // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
        //                this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // 追加フラグ
        //                // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END                        
        //                // 2008.08.20 30413 犬飼 メーカーもクリア <<<<<<END

        //                // 品番更新区分の初期設定
        //                this._setGoodNoUpdFlg = false;

        //                #endregion
        //            }
        //            #endregion
        //        }
        //        else
        //        {
        //            #region ■未入力
        //            // 品番を元に戻す
        //            //this._goodsDetailDataTable[cell.Row.Index].GoodsCode = this._beforeGoodsCode;
        //            this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";
        //            // 品名のクリア
        //            this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";
        //            // 2008.08.20 30413 犬飼 メーカーもクリア >>>>>>START
        //            //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;           // メーカーコード
        //            this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";          // メーカーコード
        //            this._goodsDetailDataTable[cell.Row.Index].MakerName = "";          // メーカー名称
        //            this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;             // QTY
        //            this._goodsDetailDataTable[cell.Row.Index].SetNote = "";            // セット規格・特記事項
        //            this._goodsDetailDataTable[cell.Row.Index].Division = "";           // 提供区分
        //            this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;          // 編集可否フラグ
        //            // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
        //            this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;
        //            // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END                        
        //            // 2008.08.20 30413 犬飼 メーカーもクリア <<<<<<END
        //            #endregion
        //        }

        //    }
        //    #endregion

        //    // 2008.10.10 30413 犬飼 メーカーコードは入力不可になったので削除 >>>>>>START
        //    #region ●ActiveCellがメーカーコードの場合
        //    //else if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
        //    //{
        //    //    int searchCode = (int)cell.Value;

        //    //    // 0 もしくは 空 以外が入力された場合
        //    //    if (searchCode != 0)
        //    //    {
        //    //        MakerUMnt makerUMnt;
        //    //        //MakerAcs makerAcs = new MakerAcs();
        //    //        GoodsAcs goodsAcs = new GoodsAcs();
        //    //        string msg;
        //    //        goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

        //    //        #region < メーカー情報取得 >
        //    //        // ◎商品検索のメーカーマスタ情報取得メソッドを呼び出す
        //    //        int status = goodsAcs.GetMaker(this._enterpriseCode, searchCode, out makerUMnt);
        //    //        #endregion

        //    //        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (makerUMnt != null))
        //    //        {
        //    //            #region -- 正常取得 --
        //    //            // メーカーマスタ情報設定処理
        //    //            this.MakerDetailRowGoodsSetSetting(goodsRowNo, makerUMnt);
                        
        //    //            // 商品コードが入力されるように制御する
        //    //            this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //    //            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //    //            this.uGrid_Details.ActiveCell.SelStart = 0;
        //    //            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //    //            #endregion
        //    //        }
        //    //        else
        //    //        {
        //    //            #region -- 取得失敗 --
        //    //            TMsgDisp.Show(
        //    //                this,
        //    //                emErrorLevel.ERR_LEVEL_INFO,
        //    //                this.Name,
        //    //                "メーカーコード [" + searchCode + "] に該当するデータが存在しません。",
        //    //                -1,
        //    //                MessageBoxButtons.OK);

        //    //            // メーカー情報をクリア
        //    //            //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;
        //    //            this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";
        //    //            this._goodsDetailDataTable[cell.Row.Index].MakerName = "";
                        
        //    //            //this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];
        //    //            //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //    //            //this.uGrid_Details.ActiveCell.SelStart = 0;
        //    //            //this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //    //            #endregion
        //    //        }
        //    //    }
        //    //    // 値が空なら
        //    //    else
        //    //    {
        //    //        // メーカー情報をクリア
        //    //        //this._goodsDetailDataTable[cell.Row.Index].MakerCode = 0;
        //    //        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";
        //    //        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";
                    
        //    //    }
        //    //}
        //    #endregion
        //    // 2008.10.10 30413 犬飼 メーカーコードは入力不可になったので削除 <<<<<<END
        //}
        #endregion
        // 2008.10.30 30413 犬飼 未使用イベントの削除 <<<<<<END
        
        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
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
        /// グリッドセルアクティブ化前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // 2008.12.17 30413 犬飼 IME制御を変更 >>>>>>START
            // セル単位でのIME制御
            //if (e.Cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName) 
            //{
            //    // IMEをひらがなモードにする
            //    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //}
            //if (e.Cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            //{
            //    // IMEを起動しない
            //    this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Off;
            //}
            if (e.Cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
            {
                // セット規格／特記事項 IMEをON
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            else
            {
                // その他 IMEを無効
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
            // 2008.12.17 30413 犬飼 IME制御を変更 <<<<<<END
        }

        /// <summary>
        /// グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            #region ●ActiveCellがメーカーコードの場合
            if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            {
                // 入力前のデータをAfterCellUpdateイベントのために保持
                //if (e.Cell.Value != null) 
                if (e.Cell.Value != DBNull.Value) 
                {
                    this._beforeMakerCode = (int)e.Cell.Value;
                }
                else
                {
                    this._beforeMakerCode = 0;
                }
            }
            #endregion

            #region ●ActiveCellが品番の場合
            else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                // 入力前のデータをAfterCellUpdateイベントのために保持
                if (e.Cell.Value != null)
                {
                    this._beforeGoodsCode = e.Cell.Value.ToString();
                }
                else
                {
                    this._beforeGoodsCode = "";
                }
            }
            #endregion
        }

        /// <summary>
        /// グリッドデータエラー発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        // 2008.08.07 30413 犬飼 セルボタンの削除 >>>>>>START
        #region セルボタンクリックイベント
        ///// <summary>
        ///// セルボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void uGrid_Details_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        //{
        //    this._goodsDetailDataTable.AcceptChanges();

        //    // ActiveRowインデックス取得処理
        //    int rowIndex = e.Cell.Row.Index;
        //    if (rowIndex == -1) return;

        //    // セット商品情報行番号を取得
        //    int goodsRowNo = this._goodsDetailDataTable[rowIndex].No;

        //    switch (e.Cell.Column.Index)
        //    {
        //        case 3:

        //            #region ●メーカーガイドボタン
        //            {
        //                #region < メーカーガイド起動 >
        //                GoodsAcs goodsAcs = new GoodsAcs();
        //                string msg;
        //                goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);

        //                MakerUMnt makerUMnt = new MakerUMnt();

        //                int status = goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out makerUMnt);
        //                #endregion

        //                #region < 取得失敗 >
        //                if (status != 0)
        //                {
        //                    // フォーカスをメーカーコードにして入力データを全選択
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];

        //                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //                    // 全選択処理
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                }
        //                #endregion

        //                #region < 正常取得 >
        //                else
        //                {
        //                    // メーカーマスタ情報設定処理
        //                    this.MakerDetailRowGoodsSetSetting(goodsRowNo, makerUMnt);

        //                    // フォーカスを商品コードにする
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //                    // 次入力可能セル移動処理
        //                    this.MoveNextAllowEditCell(true);
        //                    // 全選択処理
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                }
        //                #endregion

        //                break;
        //            }

        //            #endregion


        //        case 6:

        //            #region ●商品ガイドボタン
        //            {
        //                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

        //                GoodsUnitData goodsUnitData;

        //                #region < 検索条件追加 >
        //                // 入力されている検索条件に追加する
        //                GoodsCndtn goodsCndtn = new GoodsCndtn();
        //                goodsCndtn.GoodsMakerCd = (int)this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value;
        //                goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //                #endregion

        //                #region < 商品検索起動 >
        //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate START
        //                //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, false, goodsCndtn, out goodsUnitData);
        //                DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
        //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate END
        //                #endregion

        //                #region < 画面表示処理 >
        //                if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //                {
        //                    #region -- 正常取得 --
        //                    // 商品マスタ情報設定処理
        //                    this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

        //                    // 選択されている行が最終行？
        //                    if (this.uGrid_Details.Rows.Count == (rowIndex + 1))
        //                    {
        //                        // 空の新規行の追加
        //                        GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
        //                        detailRow.No = (short)(this.uGrid_Details.Rows.Count + 1);
        //                        this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
        //                    }

        //                    // フォーカスは次行のメーカーコード
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex + 1].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];
        //                    // セルを編集モードにする
        //                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                    #endregion
        //                }
        //                else
        //                {
        //                    #region -- 取得失敗 --
        //                    // フォーカスを元の商品コードに戻す
        //                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];
        //                    // セルを編集モードにする
        //                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        //                    this.uGrid_Details.ActiveCell.SelStart = 0;
        //                    this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
        //                    #endregion
        //                }
        //                #endregion

        //                break;
        //            }
        //            #endregion

        //    }
        //}
        #endregion
        // 2008.08.07 30413 犬飼 セルボタンの削除 <<<<<<END

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_Details.ActiveCell == null))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName];

                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_Details.ActiveCell != null)
            {
                if ((!this.uGrid_Details.ActiveCell.IsInEditMode) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // 次入力可能セル移動処理
                    this.MoveNextAllowEditCell(true);
                }
            }

            // グリッドセルアクティブ後発生イベント
            this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // なにもしない
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            #region ■セルが選択されている場合
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                #region ●Escapeキー
                if (e.KeyCode == Keys.Escape)
                {
                    // なにもしない
                }
                #endregion

                #region ●Shiftキー
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                    }
                }
                #endregion

                #region ●その他のキー
                else
                {
                    // 編集中であった場合
                    if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            #region < テキストボックス・テキストボックス(ボタン付) >
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion

                            #region < 上記以外のスタイル >
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
                            #endregion
                        }
                    }

                    switch (e.KeyCode)
                    {
                        #region < Homoキー >
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion

                        #region < Endキー >
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion
                    }

                    // 最上位行にフォーカス
                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                    {
                        #region < ↑キー >
                        if (e.KeyCode == Keys.Up)
                        {
                            if (this.GridKeyDownTopRow != null)
                            {
                                this.GridKeyDownTopRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                    // 最下位行にフォーカス
                    else if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                    {
                        #region < ↓キー >
                        if (e.KeyCode == Keys.Down)
                        {
                            if (this.GridKeyDownButtomRow != null)
                            {
                                this.GridKeyDownButtomRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }
            #endregion

            #region ■列が選択されている場合
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                switch (e.KeyCode)
                {
                    #region < Deleteキー >
                    case Keys.Delete:
                        {
                            this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                            break;
                        }
                    #endregion
                }

                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    #region < ↑キー >
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    #region < ↓キー >
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
            }
            #endregion
        }

        /// <summary>
        /// グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 2008.10.15 30413 犬飼 メーカーコードは入力不可に変更 >>>>>>START
            #region ●ActiveCellがメーカーコードの場合
            //if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            //{
            //    // 編集モード中？
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            #endregion
            // 2008.10.15 30413 犬飼 メーカーコードは入力不可に変更 <<<<<<END

            // 2008.10.15 30413 犬飼 表示順位の入力桁数チェックを追加 >>>>>>START
            #region ●ActiveCellが表示順位の場合
            if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
            // 2008.10.15 30413 犬飼 表示順位の入力桁数チェックを追加 <<<<<<END
            
            #region DEL 品番チェックの削除
            // DEL 2015/10/28 時シン Redmine#47547 セット子品番入力時に "." を入力できないことの対応 ----->>>>>
            //#region ●ActiveCellが品番の場合
            //else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            //{
            //    // 編集モード中？
            //    if (cell.IsInEditMode)
            //    {
            //        // 2008.10.15 30413 犬飼 品番の入力桁数を24桁に変更 >>>>>>START
            //        //if (!this.KeyPressNumCheck(15, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true, true))
            //        if (!this.KeyPressNumCheck(24, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true, true))
            //        // 2008.10.15 30413 犬飼 品番の入力桁数を24桁に変更 >>>>>>START
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            //#endregion
            // DEL 2015/10/28 時シン Redmine#47547 セット子品番入力時に "." を入力できないことの対応 -----<<<<<
            #endregion

            // 2008.10.15 30413 犬飼 QTYの入力桁数チェックを追加 >>>>>>START
            #region ●ActiveCellがQTYの場合
            if (cell.Column.Key == this._goodsDetailDataTable.CntFlColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion
            // 2008.10.15 30413 犬飼 QTYの入力桁数チェックを追加 <<<<<<END
            
            // 2008.08.07 30413 犬飼 メーカーガイドボタンの削除 >>>>>>START
            #region ●ActiveCellがメーカーガイドの場合
            //else if (cell.Column.Key == this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyChar == (char)Keys.Space)
            //    {
            //        //
            //    }
            //}
            #endregion
            // 2008.08.07 30413 犬飼 メーカーガイドボタンの削除 <<<<<<END
            
            // 2008.08.04 30413 犬飼 商品ガイドボタンの削除 >>>>>>START
            #region ●ActiveCellが商品ガイドボタンの場合
            //else if (cell.Column.Key == this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyChar == (char)Keys.Space)
            //    {
            //        //
            //    }
            //}
            #endregion
            // 2008.08.04 30413 犬飼 商品ガイドボタンの削除 <<<<<<END
            
        }

        /// <summary>
        /// グリッドキーアップイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 2008.08.04 30413 犬飼 商品ガイドボタンの削除 >>>>>>START
            #region ●ActiveCellが商品ガイドボタンの場合
            //if (cell.Column.Key == this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        Infragistics.Win.UltraWinGrid.CellEventArgs ce = new Infragistics.Win.UltraWinGrid.CellEventArgs(cell);
            //        this.uGrid_Details_ClickCellButton(this.uGrid_Details, ce);
            //    }
            //}
            #endregion
            // 2008.08.04 30413 犬飼 商品ガイドボタンの削除 <<<<<<END

            // 2008.08.07 30413 犬飼 メーカーガイドボタンの削除 >>>>>>START
            #region ●ActiveCellがメーカーガイドボタンの場合
            //if (cell.Column.Key == this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        Infragistics.Win.UltraWinGrid.CellEventArgs ce = new Infragistics.Win.UltraWinGrid.CellEventArgs(cell);
            //        this.uGrid_Details_ClickCellButton(this.uGrid_Details, ce);
            //    }
            //}
            // 2008.08.07 30413 犬飼 メーカーガイドボタンの削除 <<<<<<END
            #endregion

        }

        /// <summary>
        /// 明細グリッドリーヴイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // 今回の仕様では何も処理しない
            // 仕入入力では、ステータスバーの処理を実行
        }

        /// <summary>
        /// グリッドマウスエンターエレメントイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            // 今回の仕様ではなにも処理しない
        }

        /// <summary>
        /// グリッドマウスリーヴエレメントイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            // 今回の仕様ではなにも処理しない
        }

        /// <summary>
        /// ドラッグイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// Note			:	行・列・ヘッダのドラッグ時のイベントを処理します。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.08.08<br />
        /// </remarks>
        private void uGrid_Details_SelectionDrag(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Details.Selected.Columns.Count > 0)
            {
                int pos = this.uGrid_Details.Selected.Columns[0].VisiblePosition;
                if (this.uGrid_Details.DisplayLayout.Bands[0].Columns[pos].Header.Fixed)
                {
                    e.Cancel = true;
                }
            }
        }

        #region ■ uButton イベント

        /// <summary>
        /// 挿入ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote  : K2019/01/07 譚洪</br>
        /// <br>修正内容    : ランテル様にてセットマスタの最大登録件数を99件に増やすの対応</br>
        /// </remarks>
        private void uButton_RowInsert_Click(object sender, EventArgs e)
        {
            this._goodsDetailDataTable.AcceptChanges();

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex == -1) return;

            //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ---->>>>>
            if (this.HaveRuntel && this.uGrid_Details.Rows.Count >= MaxRowNumForRuntel)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "セット商品は９９個以内で構成してください。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            //---- ADD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ----<<<<<
            // 2008.08.07 30413 犬飼 行数が50を超える場合は挿入不可 >>>>>>START
            //---- UPD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ---->>>>>
            //if (this.uGrid_Details.Rows.Count >= _maxRowNum)
            else if (!this.HaveRuntel && this.uGrid_Details.Rows.Count >= _maxRowNum)
            //---- UPD 譚洪 K2019/01/07 FOR Redmine#49801の対応 ----<<<<<
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "セット商品は５０個以内で構成してください。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 2008.08.07 30413 犬飼 行数が50を超える場合は挿入不可 <<<<<<END
            

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 仕入明細行挿入処理
                this.InsertGoodsDetailRow(rowIndex);

                // 明細グリッドセル設定処理
                // 2007.05.11 deleted by T-Kidate : 挿入時にはとくにグリッドの設定を行なわないと判断したため
                //this.SettingGrid();

                // 2008.08.07 30413 犬飼 提供区分による編集不可制御 >>>>>>START
                this.ChangeRowActivation_Division();
                // 2008.08.07 30413 犬飼 提供区分による編集不可制御 <<<<<<END


                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 挿入ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowInsert_EnabledChanged(object sender, EventArgs e)
        {
            // [説明]ウインドウ内のボタンとツールボックス内のボタンのEnabledプロパティの同期を取るための処理
            //       今回ウインドウを表示しないためこのイベント内では処理は何も行なわないものとする。
            //this._rowInsertButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// 削除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._goodsDetailDataTable.AcceptChanges();

            // 選択済みセット商品情報行番号リスト取得処理
            List<int> selectedGoodsRowNoList = this.GetSelectedGoodsRowNoList();
            if ((selectedGoodsRowNoList == null) || (selectedGoodsRowNoList.Count == 0))
            {
                return;
            }

            // 2008.08.07 30413 犬飼 提供のチェック >>>>>>START
            int rowIdx = selectedGoodsRowNoList[0];
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find(rowIdx);

            if (!detailRow.EditFlg)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "登録済の提供データは削除できません。",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }
            // 2008.08.07 30413 犬飼 提供のチェック <<<<<<END
            
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "選択行を削除してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // ActiveRowインデックス取得処理
            int rowIndex = this.GetActiveRowIndex();

            string message;
            // 削除可能チェック処理(現在は必ずTrueがかえってくる)
            if (!this.CanDeleteGoodsDetailRow(selectedGoodsRowNoList, out message))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // セット商品情報行削除処理
                this.DeleteGoodsDetailRow(selectedGoodsRowNoList);

                // 明細グリッドセル設定処理
                // 2007.05.11 deleted by T-Kidate : 挿入時にはとくにグリッドの設定を行なわないと判断したため
                //this.SettingGrid();

                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];

                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }

                // 次入力可能セル移動処理
                this.MoveNextAllowEditCell(true);

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 削除ボタンEnabled変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
        {
            // [説明]ウインドウ内のボタンとツールボックス内のボタンのEnabledプロパティの同期を取るための処理
            //       今回ウインドウを表示しないためこのイベント内では処理は何も行なわないものとする。
            //this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        #endregion

        #endregion


        /// <summary>
        /// データ行データテーブル格納処理
        /// </summary>
        /// <param name="No">表示No</param>
        /// <param name="goodsUnitData">選択されたデータ行</param>
        /// <remarks>
        /// Note			:	表示するデータ行をグリッドにバインドします。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.08.07<br />
        /// </remarks>
        public void SetGoodsSetDataTable(int No, GoodsUnitData goodsUnitData)
        {
            this._goodsDetailDataTable.BeginLoadData();

            // 表示行
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // 空の入力行以上データが存在する場合は新規行を作ってデータを格納
            if (No > _defaultRowCnt)
            {
                detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            }
            // 空の入力行以下の場合は存在する行数と変数Noが一致する行を更新する
            else
            {
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find((short)No);
            }

            // 必要な項目だけグリッド表示データテーブルにセット
            detailRow.No = (short)No;                                                   // No
            if (goodsUnitData.DisplayOrder.ToString() != string.Empty)
            {
                detailRow.Disply = goodsUnitData.SetDispOrder;                          // 表示順位
            }

            detailRow.GoodsCode = goodsUnitData.GoodsNo;                                // 品番
            detailRow.GoodsName = goodsUnitData.GoodsName;                              // 品名
            //detailRow.MakerCode = goodsUnitData.GoodsMakerCd;                           // メーカーコード
            // DEL 2009/04/09 ------>>>
            //detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // メーカーコード
            //detailRow.MakerName = goodsUnitData.MakerName;                              // メーカー名称
            // DEL 2009/04/09 ------<<<
            
            // ADD 2009/04/09 ------>>>
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                detailRow.MakerCode = string.Empty;
                detailRow.MakerName = string.Empty;
            }
            else
            {
                detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // メーカーコード
                detailRow.MakerName = goodsUnitData.MakerName;                              // メーカー名称
            }
            // ADD 2009/04/09 ------<<<

            //if (dataRow[GoodsSetAcs.CNTFL_TITLE].ToString() != string.Empty)
            //{
                //detailRow.CntFl = (double)dataRow[GoodsSetAcs.CNTFL_TITLE];             // ＱＴＹ(数量)
            //}
            //detailRow.CntFl = goodsUnitData.SetQty;                                     // ＱＴＹ(数量)
            detailRow.CntFl = goodsUnitData.SetQty.ToString("##0.00");                                     // ＱＴＹ(数量)

            detailRow.SetNote = goodsUnitData.SetSpecialNote;                           // セット規格・特記事項

            // 新規行のときのみ新しい行を追加するためAdd処理が必要
            if (No > _defaultRowCnt)
            {
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            // 提供データ行を編集不可とする
            //if (goodsUnitData.OfferKubun != 0)
            if(!this._goodsSetAcs.CheckDivision(goodsUnitData))
            {
                // 提供データ
                detailRow.Division = GoodsSetAcs.DIVISION_NAME_OFFER;
                detailRow.EditFlg = false;

                int rowIdx = No - 1;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.CntFlColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else
            {
                // ユーザデータ
                detailRow.Division = GoodsSetAcs.DIVISION_NAME_USER;
                detailRow.EditFlg = true;
            }

            // 2008.10.20 30413 犬飼 追加フラグの追加 >>>>>>START
            detailRow.AddFlag = false;
            // 2008.10.20 30413 犬飼 追加フラグの追加 <<<<<<END                    

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// 削除対象データテーブル格納処理
        /// </summary>
        /// <param name="deleteDataList">選択されたデータ行</param>
        /// <remarks>
        /// Note			:	表示するデータ行をグリッドにバインドします。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.08.07<br />
        /// </remarks>
        public void GetDeleteData(out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList)
        {
            deleteDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // 削除対象データテーブルの件数をカウント
            int totalCnt = this._deleteGoodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._deleteGoodsDetailDataTable.Rows[i];

                // 削除対象データテーブルを追加
                deleteDataList.Add(row);
            }
        }

        /// <summary>
        /// 商品連結データ用ローカルキャッシュ取得
        /// </summary>
        /// <param name="goodsUnitDataDic">商品連結データ用ディクショナリー</param>
        /// <remarks>
        /// Note			:	商品連結データ用ローカルキャッシュを取得します。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.08.21<br />
        /// </remarks>
        public void GetLC_GoodsUnitData(out Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            goodsUnitDataDic = new Dictionary<string,GoodsUnitData>();

            foreach (GoodsUnitData workGoodsUnitData in _lcGoodsUnitDataList)
            {
                // ユーザー登録されていない商品連結データを設定
                switch (workGoodsUnitData.OfferKubun)
                {
                    case 3:     // 3:提供純正
                    case 4:     // 4:提供優良
                    case 5:     // 5:TBO
                    case 7:     // 7:オリジナル
                        {
                            // 品番とメーカーコードをキーとする
                            string key = workGoodsUnitData.GoodsNo + "-" + workGoodsUnitData.GoodsMakerCd.ToString("d04");
                            if (goodsUnitDataDic.ContainsKey(key))
                            {
                                goodsUnitDataDic.Remove(key);
                            }
                            goodsUnitDataDic.Add(key, workGoodsUnitData);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// マウスポインタアップ EVENT
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// Note			:	マウスポインタが離れたときのイベントを処理します。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.14<br />
        /// </remarks>
        private void uGrid_Details_MouseUp(object sender, MouseEventArgs e)
        {
            #region ●列の順序設定
            // 固定列の順序設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.VisiblePosition = 0;              // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.VisiblePosition = 1;          // 表示順序
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.VisiblePosition = 2;       // 品番
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = 3;       // 品名
            #endregion
            
        }

        /// <summary>
        /// 親商品情報を取得(チェック用)
        /// </summary>
        /// <param name="GoodsNo">親品番</param>
        /// <param name="GoodsMakerCd">親メーカー</param>
        /// <remarks>
        /// Note			:	親商品情報を取得します。<br />
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.15<br />
        /// </remarks>
        public void SetParentData(string GoodsNo, int GoodsMakerCd)
        {
            // 親品番
            this._parentGoodsNo = GoodsNo;
            // 親メーカー
            this._parentMakerCode = GoodsMakerCd;
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note	    :   GRIDのセル編集終了イベント処理。</br>
        /// Programmer		:	30413 犬飼<br />
        /// Date			:	2008.10.30<br />
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            int status = -1;

            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;
            int rowIndex = cell.Row.Index;

            #region ●ActiveCellが品番の場合
            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                string goodsCode = cell.Value.ToString();

                // 品番更新区分の初期設定
                this._setGoodNoUpdFlg = true;

                if (this._childGoodsNo == goodsCode)
                {
                    // 編集前と編集後が同じ場合は処理を行わない
                    return;
                }

                if (!String.IsNullOrEmpty(goodsCode))
                {
                    #region ■入力有
                    string searchCode;

                    #region < 検索種類取得 >
                    int searchType = this.GetSearchType(goodsCode, out searchCode);
                    #endregion

                    List<GoodsUnitData> goodsUnitDataList;
                    string message;

                    #region < 品名取得 >
                    string sectionCd = this._loginEmployee.BelongSectionCode.Trim();
                    GoodsCndtn goodsCndtn = new GoodsCndtn();

                    // 商品検索条件設定
                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.SectionCode = sectionCd;
                    goodsCndtn.GoodsMakerCd = 0;
                    goodsCndtn.MakerName = "";
                    goodsCndtn.GoodsNo = goodsCode;
                    goodsCndtn.GoodsNoSrchTyp = searchType;
                    goodsCndtn.IsSettingSupplier = 1; // 2009.02.09
                    goodsCndtn.PriceApplyDate = DateTime.Today;
            
                    status = this._goodsSetAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
                    #endregion

                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    {
                        #region -- 正常取得 --
                        // 商品マスタデータクラス
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataList[0];

                        // 商品マスタ情報設定処理
                        this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);

                        // 取得した商品連結データをキャッシュとして保持
                        if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
                        {
                            _lcGoodsUnitDataList.Add(goodsUnitData);
                        }
                        #endregion
                    }
                    else if (status == -1)
                    {
                        // 同一品番選択画面でキャンセル
                        // 対象行のクリア
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // 品番
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // 品名
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // メーカーコード
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // メーカー名称
                        //this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].CntFl = "";         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // セット規格・特記事項
                        this._goodsDetailDataTable[cell.Row.Index].Division = "";       // 提供区分
                        this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // 編集可否フラグ
                        this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // 追加フラグ

                        // 品番更新区分の初期設定
                        this._setGoodNoUpdFlg = false;
                    }
                    else
                    {
                        #region -- 取得失敗 --
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "品番 [" + searchCode + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 対象行のクリア
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // 品番
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // 品名
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // メーカーコード
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // メーカー名称
                        //this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].CntFl = "";         // QTY
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // セット規格・特記事項
                        this._goodsDetailDataTable[cell.Row.Index].Division = "";       // 提供区分
                        this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // 編集可否フラグ
                        this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // 追加フラグ

                        // 品番更新区分の初期設定
                        this._setGoodNoUpdFlg = false;

                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region ■未入力
                    // 対象行のクリア
                    this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";      // 品番
                    this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";      // 品名
                    this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";      // メーカーコード
                    this._goodsDetailDataTable[cell.Row.Index].MakerName = "";      // メーカー名称
                    //this._goodsDetailDataTable[cell.Row.Index].CntFl = 0.0;         // QTY
                    this._goodsDetailDataTable[cell.Row.Index].CntFl = "";         // QTY
                    this._goodsDetailDataTable[cell.Row.Index].SetNote = "";        // セット規格・特記事項
                    this._goodsDetailDataTable[cell.Row.Index].Division = "";       // 提供区分
                    this._goodsDetailDataTable[cell.Row.Index].EditFlg = true;      // 編集可否フラグ
                    this._goodsDetailDataTable[cell.Row.Index].AddFlag = true;      // 追加フラグ
                    #endregion
                }

            }
            // 2009.02.06 30413 犬飼 QTYのフォーマット >>>>>>START
            else if (cell.Column.Key == this._goodsDetailDataTable.CntFlColumn.ColumnName)
            {
                double cntFl = 0.0;
                if ((!double.TryParse(cell.Text, out cntFl)) || (cntFl == 0.0))
                {
                    if (cell.Text != "")
                    {
                        this._goodsDetailDataTable[cell.Row.Index].CntFl = "0";    
                    }
                }
                else
                {
                    this._goodsDetailDataTable[cell.Row.Index].CntFl = cntFl.ToString("##0.00");
                    
                }
            }
            // 2009.02.06 30413 犬飼 QTYのフォーマット <<<<<<END
            #endregion
        }

        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                this._childGoodsNo = cell.Value.ToString();
            }
        }

        //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正 ---->>>>>
        /// <summary>
        /// 画面の横幅を変更イベット
        /// </summary>
        /// <param name="width">画面の横幅</param>
        /// <param name="height">画面の高さ</param> 
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 画面の横幅を変更イベットを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/05/08</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正</br>    
        /// </remarks>     
        public void SettingGridWidth(int width, int height)
        {
            this.Width = width;
            this.pnl_uGrid.Width = width;
            this.uGrid_Details.Width = width;

            this.Height = height;
            this.pnl_uGrid.Height = height;
            this.uGrid_Details.Height = height;

            this.pnl_uGrid.Dock = DockStyle.Fill;
            this.uGrid_Details.Dock = DockStyle.Fill;
            this.uGrid_Details.Refresh();
        }
        //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正 ----<<<<<

        //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ---->>>>>
        # region [グリッドカラム情報 保存・復元]
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : グリッドカラム情報の保存を行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>    
        /// </remarks> 
        public void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : グリッドカラム情報の読み込みを行う。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>    
        /// </remarks>  
        public void LoadGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラム設定情報を表示順でソートする
            settingList.Sort(new ColumnInfoComparer());

            // 一度、全てのカラムのFixedを解除する
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // 列並び換え後、まとめてFixedを設定する。
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }
        # endregion

        #region ユーザー設定の保存・読み込み

        /// <summary>
        /// セットマスタ用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : セットマスタ用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// セットマスタ用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : セットマスタ用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : gaocheng</br>
        /// <br>Date       : 2015/07/02</br>
        /// <br>管理番号   : 11175121-00</br>
        /// <br>           : Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応</br>   
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<SetMstUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

                }
                catch
                {
                    this._userSetting = new SetMstUserConst();
                }
            }
        }

        #endregion // ユーザー設定の保存・読み込み
        //---- ADD gaocheng 2015/05/08 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<
    }

    # region [SetMstUserConst]
    /// <summary>
    /// セットマスタ用ユーザー設定クラス
    /// </summary>
    [Serializable]
    public class SetMstUserConst
    {

        # region プライベート変数

        // 明細グリッドカラムリスト
        private List<ColumnInfo> _detailColumnsList;

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// セットマスタユーザー設定情報クラス
        /// </summary>
        public SetMstUserConst()
        {

        }

        # endregion // コンストラクタ

        # region プロパティ
        /// <summary>明細グリッドカラムリスト</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        # endregion

        /// <summary>
        /// セットマスタユーザー設定情報クラス複製処理
        /// </summary>
        /// <returns>セットマスタユーザー設定情報クラス</returns>
        public SetMstUserConst Clone()
        {
            SetMstUserConst constObj = new SetMstUserConst();
            return constObj;
        }
    }
    #endregion

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>列名</summary>
        private string _columnName;
        /// <summary>並び順</summary>
        private int _visiblePosition;
        /// <summary>非表示フラグ</summary>
        private bool _hidden;
        /// <summary>幅</summary>
        private int _width;
        /// <summary>固定フラグ</summary>
        private bool _columnFixed;
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// 並び順
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// 非表示フラグ
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// 固定フラグ
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="visiblePosition">並び順</param>
        /// <param name="hidden">非表示フラグ</param>
        /// <param name="width">幅</param>
        /// <param name="columnFixed">固定フラグ</param>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }

    /// <summary>
    /// ColumnInfo比較クラス（ソート用）
    /// </summary>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo比較処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ColumnInfo x, ColumnInfo y)
        {
            // 列表示順で比較
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            // 列表示順が一致する場合は列名で比較(通常は発生しない)
            if (result == 0)
            {
                result = x.ColumnName.CompareTo(y.ColumnName);
            }
            return result;
        }
    }
    # endregion
    //---- ADD gaocheng 2015/07/02 for Redmine#45798 ウィンドウ位置とサイズの記憶功能の対応 ----<<<<<
}
