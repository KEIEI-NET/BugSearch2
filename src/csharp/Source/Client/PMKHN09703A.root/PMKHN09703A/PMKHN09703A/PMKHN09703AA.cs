//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動回答品目設定マスタメンテナンス
// プログラム概要   : 自動回答品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/10/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/13  修正内容 : 11/14配信 システムテスト障害№18,19対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/16  修正内容 : 12/12配信 システムテスト障害№36対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 三戸 伸悟
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№58対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№77対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/11/22  修正内容 : VSS[019] Redmine#677対応
//----------------------------------------------------------------------------//
// 管理番号  11170187-00 作成担当 : 田建委
// 作 成 日  2015/10/19  修正内容 : Redmine#47535
//                                  既存レコードの優先順位＞２ && 新規レコードの優先順位＞既存レコードの優先順位の場合登録エラーの解除
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自動回答品目設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自動回答品目設定マスタのアクセス制御を行います。</br>
    /// <br></br>
    /// <br>UpdateNote : 2015/10/19 田建委 </br>
    /// <br>管理番号   : 11170187-00 Redmine#47535</br>
    /// <br>           : 既存レコードの優先順位＞２ && 新規レコードの優先順位＞既存レコードの優先順位の場合登録エラーの解除</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class AutoAnsItemStAcs
    {
        #region public const
        //----------------------------------------
        // 自動回答品目設定マスタ定数定義
        //----------------------------------------
        /// <summary>作成日時</summary>
        public const string ct_COL_CREATEDATETIME = "CreateDateTime";
        /// <summary>更新日時</summary>
        public const string ct_COL_UPDATEDATETIME = "UpdateDateTime";
        /// <summary>企業コード</summary>
        public const string ct_COL_ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ct_COL_FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>更新従業員コード</summary>
        public const string ct_COL_UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>更新アセンブリID1</summary>
        public const string ct_COL_UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>更新アセンブリID2</summary>
        public const string ct_COL_UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>論理削除区分</summary>
        public const string ct_COL_LOGICALDELETECODE = "LogicalDeleteCode";
        /// <summary>拠点コード</summary>
        public const string ct_COL_SECTIONCODE = "SectionCode";
        /// <summary>得意先コード</summary>
        public const string ct_COL_CUSTOMERCODE = "CustomerCode";
        /// <summary>商品中分類コード</summary>
        public const string ct_COL_GOODSMGROUP = "GoodsMGroup";
        /// <summary>BL商品コード</summary>
        public const string ct_COL_BLGOODSCODE = "BLGoodsCode";
        /// <summary>商品メーカーコード</summary>
        public const string ct_COL_GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>優良設定詳細コード２</summary>
        public const string ct_COL_PRMSETDTLNO2 = "PrmSetDtlNo2";
        /// <summary>優良設定詳細名称２</summary>
        public const string ct_COL_PRMSETDTLNAME2 = "PrmSetDtlName2";
        /// <summary>自動回答区分</summary>
        public const string ct_COL_AUTOANSWERDIV = "AutoAnswerDiv";
        /// <summary>優先順位</summary>
        public const string ct_COL_PRIORITYORDER = "PriorityOrder";

        /// <summary>自動回答区分(前回退避)</summary>
        public const string ct_COL_AUTOANSWERDIV_BACKUP = "AutoAnswerDiv_Backup";

        /// <summary>優先順位(前回退避)</summary>
        public const string ct_COL_PRIORITYORDER_BACKUP = "PriorityOrder_Backup";

        /// <summary>拠点名称</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>得意先名称</summary>
        public const string ct_COL_CUSTOMERNAME = "CustomerName";
        /// <summary>商品中分類名称</summary>
        public const string ct_COL_GOODSMGROUPNAME = "GoodsMGroupName";
        /// <summary>BL商品コード名称</summary>
        public const string ct_COL_BLGOODSNAME = "BLGoodsName";
        /// <summary>メーカー名称</summary>
        public const string ct_COL_MAKERNAME = "MakerName";

        # region [ソート用]
        /// <summary>拠点コード</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>得意先コード</summary>
        public const string ct_COL_CUSTOMERCODE_SORT = "CustomerCode_Sort";
        /// <summary>商品中分類コード</summary>
        public const string ct_COL_GOODSMGROUP_SORT = "GoodsMGroup_Sort";
        /// <summary>BL商品コード</summary>
        public const string ct_COL_BLGOODSCODE_SORT = "BLGoodsCode_Sort";
        /// <summary>商品メーカーコード</summary>
        public const string ct_COL_GOODSMAKERCD_SORT = "GoodsMakerCd_Sort";
        /// <summary>種別 </summary>
        public const string ct_COL_PRMSETDTLNO2_SORT = "PrmSetDtlName2_Sort";
        /// <summary>優先順位 </summary>
        public const string ct_COL_PRIORITYORDER_SORT = "PriorityOrder_Sort";
        # endregion

        /// <summary>論理削除日(表示用)</summary>
        public const string ct_COL_LOGICALDELETEDATE = "LogicalDeleteDate";

        /// <summary>商品中分類コード（表示用）</summary>
        public const string ct_COL_GOODSMGROUPDISPLAY = "GoodsMGroupDisplay";
        /// <summary>BL商品コード（表示用）</summary>
        public const string ct_COL_BLGOODSCODEDISPLAY = "BLGoodsCodeDisplay";
        /// <summary>種別（表示用）</summary>
        public const string ct_COL_PRMSETDTLNO2DISPLAY = "PrmSetDtlName2Display";
        /// <summary>優先順位（表示用）</summary>
        public const string ct_COL_PRIORITYORDERDISPLAY = "PriorityOrderDisplay";
        /// <summary>行№（表示用）</summary>
        public const string ct_COL_ROWNUMBERDISPLAY = "RowNumberDisplay";

        /// <summary>自動回答品目設定マスタworkオブジェクト(内部保持用)</summary>
        public const string ct_COL_AUTOANSITEMSTWORKOBJECT = "AutoAnsItemStWorkObject";
        public object _autoAnsItemStWorkList = null; // 自動回答品目設定リモート

        /// <summary>新規追加行区分(内部保持用)</summary>
        public const string ct_COL_NEWADDROWDIV = "NewAddRowDiv";
        /// <summary>新規追加行保存可否区分(内部保持用)</summary>
        public const string ct_COL_NEWADDROWALLOWSAVE = "NewAddRowAllowSave";

        // テーブル名
        /// <summary>自動回答品目設定テーブル</summary>
        public const string ct_TABLE_AUTOANSITEMST = "AutoAnsItemStTable";

        #region 優良設定マスタ関連

        /// <summary>提供優良設定クラス </summary>
        public const string COL_OFFERPRIMESETTING = "OfferPrimeSetting";
        /// <summary>ﾕｰｻﾞｰ優良設定クラス </summary>
        public const string COL_USERPRIMESETTING = "UserPrimeSetting";
        /// <summary>チェックボックスステータス </summary>
        public const string COL_CHECKSTATE = "CheckState";
        /// <summary>変更フラグ </summary>
        public const string COL_CHANGEFLAG = "ChangeFlag";
        /// <summary>チェックボックスステータス </summary>
        public const string COL_ORIGINAL_CHECKSTATE = "Original_CheckState";

        #endregion

        #endregion

        #region Private Members
        // ===================================================================================== //
        // プライベートメンバー
        // ===================================================================================== //
        // リモートオブジェクト格納バッファ
        private IAutoAnsItemStDB _iAutoAnsItemStDB = null; // 自動回答品目設定リモート

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        #endregion

        # region enum
        // 列挙型
        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }
        # endregion

        /// <summary>自動回答区分の列挙型です。</summary>
        public enum AutoAnswerDiv
        {
            /// <summary>0:しない</summary>
            None = 0,
            /// <summary>1:する(全て自動回答)</summary>
            All = 1,
            /// <summary>2:する(優先順位)</summary>
            Priority = 2
        }

        /// <summary>新規追加行区分の列挙型です。</summary>
        public enum NewAddRowDiv
        {
            /// <summary>0:既存行</summary>
            Edit = 0,
            /// <summary>1:新規行</summary>
            New = 1
        }

        /// <summary>>新規追加行で保存可能な状態か否か（必要情報が入力されているか否か）</summary>
        public enum NewAddRowAllowSave
        {
            /// <summary>0:保存ＯＫ（必要情報入力済み）</summary>
            Yes = 0,
            /// <summary>1:保存ＮＧ（必要情報不足）</summary>
            No = 1
        }

        #region Construcstor
        /// <summary>
        /// 自動回答品目設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// </remarks>
        public AutoAnsItemStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iAutoAnsItemStDB = (IAutoAnsItemStDB)MediationAutoAnsItemStDB.GetAutoAnsItemStDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
            }

            // 論理削除除外する
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// 自動回答品目設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public AutoAnsItemStAcs(string enterpriseCode, string sectionCode) : this()
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode    = sectionCode;
        }
        #endregion

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iAutoAnsItemStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// データテーブル更新後イベント
        /// </summary>
        public event EventHandler AfterTableUpdate;


        #region Property
        /// <summary>
        /// データビュー（マスタ一覧用）
        /// </summary>
        public DataView DataViewForMstList
        {
            get 
            {
                // 生成前にget要求されたら初期生成処理を実行する
                if ( _dataTableList == null )
                {
                    this._dataTableList = new DataSet();
                    DataSetColumnConstruction();
                }
                return _dataView; 
            }
        }
        /// <summary>
        /// DataView論理削除除外フラグ
        /// </summary>
        public bool ExcludeLogicalDeleteFromView
        {
            set
            {
                DataView view = this.DataViewForMstList;
                if ( value == true )
                {
                    // 論理削除除く
                    view.RowFilter = string.Format( "{0}='{1}'", ct_COL_LOGICALDELETECODE, 0 );
                }
                else
                {
                    // 論理削除含む
                    view.RowFilter = string.Empty;
                }
            }
            get { return _excludeLogicalDeleteFromView; }
        }

        /// <summary>
        /// 企業コードを取得または設定します。
        /// </summary>
        public string EnterpriseCode
        {
            get
            {
                if (string.IsNullOrEmpty(_enterpriseCode.Trim()))
                {
                    return LoginInfoAcquisition.EnterpriseCode;
                }
                else
                {
                    return _enterpriseCode;
                }
            }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 拠点コードを取得または設定します。
        /// </summary>
        public string SectionCode
        {
            get
            {
                if (string.IsNullOrEmpty(_sectionCode.Trim()))
                {
                    return LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                else
                {
                    return _sectionCode;
                }
            }
            set { _sectionCode = value; }
        }
        #endregion

        #region Search 検索処理
        /// <summary>
        /// 検索結果クリア処理
        /// </summary>
        public void Clear()
        {
            // 格納先テーブル準備
            if ( _dataTableList == null )
            {
                // 初回のみ生成
                this._dataTableList = new DataSet();
                DataSetColumnConstruction();
            }
            else
            {
                // ２回目以降はクリアのみ
                _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Clear();
            }
        }

        /// <summary>
        /// 優先順位付き自動回答品目設定マスタ複数検索処理（論理削除含まない）自動回答品目設定マスメン以外用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        public int SearchAll(AutoAnsItemStOrder paraData, out List<AutoAnsItemSt> retList, out string message)
        {
            // 1パラ目
            AutoAnsItemStOrder searchingByLump = new AutoAnsItemStOrder();
            {
                // 企業コード
                searchingByLump.EnterpriseCode = paraData.EnterpriseCode;
            }
            // 2パラ目
            List<AutoAnsItemSt> firstSearchedList = null;
            // 一括検索
            int status = SearchSimply(searchingByLump, out firstSearchedList, out message);

            if (firstSearchedList == null || firstSearchedList.Count.Equals(0))
            {
                retList = firstSearchedList;
                return status;
            }

            // 得意先コードと拠点と共通を抽出する
            retList = firstSearchedList.FindAll(
                      delegate(AutoAnsItemSt autoAnsItemSt)
                      {
                          if (autoAnsItemSt.CustomerCode == paraData.St_CustomerCode
                                ||
                              autoAnsItemSt.SectionCode.Trim() == paraData.SectionCode.Trim()
                                ||
                              autoAnsItemSt.SectionCode.Trim() == "00")
                          {
                              return true;
                          }
                          else
                          {
                              return false;
                          }
                      });
            return status;
        }

        /// <summary>
        /// 優先順位付き自動回答品目設定マスタ複数検索処理（論理削除含まない）自動回答品目設定マスメン以外用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        public int Search(AutoAnsItemStOrder paraData, out List<AutoAnsItemSt> retList, out string message)
        {
            // 1パラ目
            AutoAnsItemStOrder searchingByLump = new AutoAnsItemStOrder();
            {
                // 企業コードで全検索
                searchingByLump.EnterpriseCode = paraData.EnterpriseCode;

                #region <代替条件>

                if (string.IsNullOrEmpty(searchingByLump.EnterpriseCode.Trim()))
                {
                    if (paraData.St_CustomerCode > 0)
                    {
                        // 企業コードが未設定の場合、得意先コード
                        searchingByLump.St_CustomerCode = paraData.St_CustomerCode;
                        searchingByLump.Ed_CustomerCode = paraData.Ed_CustomerCode;
                    }
                    else if (!string.IsNullOrEmpty(paraData.SectionCode.Trim()))
                    {
                        // 得意先コードも未設定の場合、拠点コード
                        searchingByLump.SectionCode = paraData.SectionCode;
                    }
                    else
                    {
                        // 拠点コードも未設定の場合、そのまま
                        searchingByLump = paraData;
                    }
                }

                #endregion // </代替条件>
            }
            // 2パラ目
            List<AutoAnsItemSt> firstSearchedList = null;
            // 一括検索
            int status = SearchSimply(searchingByLump, out firstSearchedList, out message);
            if (firstSearchedList == null || firstSearchedList.Count.Equals(0))
            {
                retList = firstSearchedList;
                return status;
            }

            // 一括検索結果より優先順位に合わせて検索結果を抽出
            if (paraData.St_CustomerCode > 0)
            {
                #region  優先順位1:得意先＋メーカー＋品番

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority1(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位1:得意先(={0})＋メーカー(={1}) で検索されました。",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion

                #region 優先順位2:得意先＋メーカー＋BLコード

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority2(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位2:得意先(={0})＋メーカー(={1})＋BLコード(={2}) で検索されました。",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_BLGoodsCode
                    );
                    return status;
                }

                #endregion

                #region 優先順位3:得意先＋メーカー＋中分類コード

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority3(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位3:得意先(={0})＋メーカー(={1})＋中分類コード(={2}) で検索されました。",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_GoodsMGroup
                    );
                    return status;
                }

                #endregion

                #region 優先順位4:得意先＋メーカー

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority4(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位4:得意先(={0})＋メーカー(={1}) で検索されました。",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion
            }
            if (!string.IsNullOrEmpty(paraData.SectionCode.Trim()))
            {
                #region 優先順位5:拠点＋メーカー＋品番

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority5(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位5:拠点(={0})＋メーカー(={1}) で検索されました。",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion

                #region 優先順位6:拠点＋メーカー＋BLコード

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority6(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位6:拠点(={0})＋メーカー(={1})＋BLコード(={2}) で検索されました。",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_BLGoodsCode
                    );
                    return status;
                }

                #endregion

                #region 優先順位7:拠点＋メーカー＋中分類コード

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority7(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位7:拠点(={0})＋メーカー(={1})＋中分類コード(={2}) で検索されました。",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_GoodsMGroup
                    );
                    return status;
                }

                #endregion

                #region 優先順位8:拠点＋メーカー

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority8(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位8:拠点(={0})＋メーカー(={1}) で検索されました。",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion
            }
            else
            {
                retList = null;
                return status;
            }

            int sectionCode = int.Parse(paraData.SectionCode.Trim());
            if (sectionCode > 0)
            {
                paraData.SectionCode = "00";    // 全社で再検索
                return Search(paraData, out retList, out message);
            }

            retList = null;
            return status;
        }

        #region 優先順位の判断

        /// <summary>
        /// 優先順位1:得意先＋中分類＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位1です。<br/>
        /// <c>false</c>:優先順位1ではありません。
        /// </returns>
        private static bool IsPriority1(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                    );
            }
            return false;
        }

        /// <summary>
        /// 優先順位1:得意先＋中分類＋BLコードであるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位2です。<br/>
        /// <c>false</c>:優先順位2ではありません。
        /// </returns>
        private static bool IsPriority2(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == 0
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位1:得意先＋中分類であるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位3です。<br/>
        /// <c>false</c>:優先順位3ではありません。
        /// </returns>
        private static bool IsPriority3(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位4:得意先であるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位4です。<br/>
        /// <c>false</c>:優先順位4ではありません。
        /// </returns>
        private static bool IsPriority4(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位5:拠点＋中分類＋BLコード＋メーカーであるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位5です。<br/>
        /// <c>false</c>:優先順位5ではありません。
        /// </returns>
        private static bool IsPriority5(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位6:拠点＋中分類＋BLコードであるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位6です。<br/>
        /// <c>false</c>:優先順位6ではありません。
        /// </returns>
        private static bool IsPriority6(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == 0
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位7:拠点＋中分類であるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位7です。<br/>
        /// <c>false</c>:優先順位7ではありません。
        /// </returns>
        private static bool IsPriority7(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// 優先順位8:拠点であるか判断します。
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定</param>
        /// <param name="AutoAnsItemStOrder">自動回答品目設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位8です。<br/>
        /// <c>false</c>:優先順位8ではありません。
        /// </returns>
        private static bool IsPriority8(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        #endregion // 優先順位の判断

        /// <summary>
        /// 自動回答品目設定マスタ複数検索処理（論理削除含まない）自動回答品目設定マスメン以外用
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="AutoAnsItemStList">自動回答品目設定オブジェクトリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定マスタリストの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
        /// </remarks>
        private int SearchSimply( AutoAnsItemStOrder paraData, out List<AutoAnsItemSt> retList, out string message )
        {
            // 検索
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // 結果格納
            retList = new List<AutoAnsItemSt>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is AutoAnsItemStWork )
                    {
                        AutoAnsItemStWork retWork = (obj as AutoAnsItemStWork);

                        // 値をセット
                        AutoAnsItemSt autoAnsItemSt = CopyToAutoAnsItemStFromAutoAnsItemStWork(retWork);
                        retList.Add(autoAnsItemSt);
                    }
                }
            }

            if ( retList.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        public void Renewal()
        {
            this.Clear();
        }

        /// <summary>
        /// 自動回答品目設定マスタ複数検索処理（論理削除含まない）自動回答品目設定マスメン用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( AutoAnsItemStOrder paraData, out string message )
        {
            // 初期化/クリア
            this.Clear();

            // 検索
            ArrayList retWorkList;
            int status = SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message );

            // 結果格納
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach (object obj in retWorkList)
                {
                    if (obj is AutoAnsItemStWork)
                    {
                        AutoAnsItemStWork retWork = (obj as AutoAnsItemStWork);

                        // アクセスクラス内のDataTableに追加
                        DataRow row = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();

                        // 値をセット
                        CopyToDataRowFromAutoAnsItemStWork(ref row, retWork);
                        _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(row);
                    }
                }
            }

            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // 新規追加行の追加
            RowAdd(); 
            #region 旧ソース
            //// 新規追加行の追加
            //DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
            //AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
            //CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref newRow, newRetWork);
            //_dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);

            //if (_dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Count == 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}

            //// テーブル更新後イベント
            //if ( AfterTableUpdate != null )
            //{
            //    AfterTableUpdate( this, new EventArgs() );
            //}
            #endregion
            // ADD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public AutoAnsItemSt GetRecordForMaintenance( Guid guid )
        {
            AutoAnsItemStWork autoAnsItemStWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromDataRow( view[0].Row );
                }
            }

            // 該当無しなら空データ
            if ( autoAnsItemStWork == null )
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            return this.CopyToAutoAnsItemStFromAutoAnsItemStWork( autoAnsItemStWork );
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public AutoAnsItemSt GetRecordForMaintenance(int rowIndex)
        {
            AutoAnsItemStWork autoAnsItemStWork = null;

            if (_dataTableList != null)
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = string.Format("{0}='{1}'", ct_COL_ROWNUMBERDISPLAY, rowIndex);

                if (view.Count > 0)
                {
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromDataRow(view[0].Row);
                }
            }

            // 該当無しなら空データ
            if (autoAnsItemStWork == null)
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            return this.CopyToAutoAnsItemStFromAutoAnsItemStWork(autoAnsItemStWork);
        }

        /// <summary>
        /// マスメン向けレコード取得処理 メイン処理
        /// </summary>
        /// <param name="filter">検索条件</param>
        /// <returns>検索条件に一致したレコードリスト</returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public List<AutoAnsItemSt> GetRecordListForMaintenance(string filter,int rowCount)
        {
            List<AutoAnsItemStWork> autoAnsItemStWorkList = new List<AutoAnsItemStWork>();

            if (_dataTableList != null)
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = filter;

                if (view.Count > 0)
                {
                    foreach (DataRow row in view.Table.Select(filter))
                    {
                        autoAnsItemStWorkList.Add(CopyToAutoAnsItemStWorkFromDataRow(row));
                    }
                }
            }

            // 該当無しなら空データ
            if (autoAnsItemStWorkList.Count.Equals(0))
            {
                for (int i = 0; i < rowCount; i++)
                {
                    autoAnsItemStWorkList.Add(new AutoAnsItemStWork());
                }
            }
            else
            {
                for (int i = autoAnsItemStWorkList.Count; i < rowCount; i++)
                {
                    autoAnsItemStWorkList.Add(new AutoAnsItemStWork());
                }
            }

            // 返値作成
            List<AutoAnsItemSt> rtnList = new List<AutoAnsItemSt>();
            foreach (AutoAnsItemStWork wrk in autoAnsItemStWorkList)
            {
                rtnList.Add(this.CopyToAutoAnsItemStFromAutoAnsItemStWork(wrk));
            }

            return rtnList;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    row = view[0].Row;
                }
            }

            // 該当無しならNULL
            return row;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public DataRow GetRowForMaintenance(int rowIndex)
        {
            DataRow row = null;
            if (_dataTableList != null)
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = string.Format("{0}='{1}'", ct_COL_ROWNUMBERDISPLAY, rowIndex);

                if (view.Count > 0)
                {
                    row = view[0].Row;
                }
            }

            // 該当無しならNULL
            return row;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="filter">抽出条件</param>
        /// <returns></returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public int GetRowForMaintenance(string filter)
        {
            int rowCount = 0;

            if (_dataTableList != null && !string.IsNullOrEmpty(filter))
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = filter;
                rowCount = view.Count;
            }

            // 該当無しなら0
            return rowCount;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>自動回答品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public DataView GetRowListForMaintenance(string filter)
        {
            DataView retView = null;
            if (_dataTableList != null)
            {
                retView = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                retView.RowFilter = filter;

                if (retView.Count > 0)
                {
                    return retView;
                }
            }
            // 該当無しならNULL
            return retView;
        }

        #endregion

        #region Write 書き込み処理
        /// <summary>
        /// 書き込み処理
        /// </summary>
        /// <param name="autoAnsItemStList">保存データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 書き込み処理を行います。</br>
        /// </remarks>
        public int Write(ref ArrayList autoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // 優先順位の設定の有無確認
                bool isPriority = false;
                // 編集対象リスト
                List<AutoAnsItemSt> editList = new List<AutoAnsItemSt>();

                ArrayList paraAutoAnsItemStList = new ArrayList();

                // 画面より変更のあったレコードに優先順位の設定があるかチェック
                for ( int i = 0; i < autoAnsItemStList.Count; i++ )
                {
                    // 一旦、パラメータリストを作成
                    paraAutoAnsItemStList.Add(CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)autoAnsItemStList[i]));
                    
                    if (((AutoAnsItemSt)autoAnsItemStList[i]).AutoAnswerDiv.Equals((int)AutoAnswerDiv.Priority))
                    {
                        editList.Add(((AutoAnsItemSt)autoAnsItemStList[i]));
                        isPriority = true;
                    }
                }

                // 優良メーカーで優先順位の設定がある場合、他レコードとの妥当性を確認する
                if (isPriority)
                {
                    // 編集対象リストを優先順位でソート
                    editList.Sort(
                        delegate(AutoAnsItemSt w1, AutoAnsItemSt w2)
                        {
                            return w1.PriorityOrder - w2.PriorityOrder;
                        });

                    // 編集対象BLコードに設定されている順位を全件取得
                    List<AutoAnsItemSt> retListWk = new List<AutoAnsItemSt>();
                    List<AutoAnsItemSt> retList = new List<AutoAnsItemSt>();

                    status = Read2(editList[0], ref retListWk, true);
                    if (!(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        // 何かしらのエラー発生
                        message = "登録に失敗しました。";
                        return status;
                    }

                    // 上記全件取得(retListWk)から、画面から渡された編集対象レコードと同一のものを除き、retListに追加
                    foreach (AutoAnsItemSt retWk in retListWk)
                    {
                        bool isTarget = true;
                        foreach (AutoAnsItemSt edit in editList)
                        {
                            if(IsEqualsAutoAnsItemStForPriority(edit,retWk))
                            {
                                isTarget = false;
                                break;
                            }
                        }

                        if(isTarget)
                        {
                            retList.Add(retWk);
                        }
                    }

                    // 編集対象リストを編集
                    EditForPriority(ref editList, ref retList);
                }

                // 編集対象リストをワーククラスデータに変換しパラメータリストに追加
                foreach (AutoAnsItemSt edit in editList)
                {
                    // 既にパラメータリストに存在している場合は、パラメータリストから削除し、新たに編集対象リストから追加
                    foreach (object para in paraAutoAnsItemStList)
                    {
                        if (IsEqualsAutoAnsItemSt(edit, para as AutoAnsItemStWork))
                        {
                            paraAutoAnsItemStList.Remove(para);
                            break;
                        }

                    }
                    paraAutoAnsItemStList.Add(CopyToAutoAnsItemStWorkFromAutoAnsItemSt(edit));
                }

                object paraObj = (object)paraAutoAnsItemStList;

                // 書き込み処理
                status = this._iAutoAnsItemStDB.Write( ref paraObj );

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "登録に失敗しました。";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 優先順位編集時にのみ使用
        /// 同一キーの自動回答品目設定マスタレコードか否か（優良設定詳細コード２は除く）
        /// 企業コード～BLコードまでが同一であることが前提
        /// </summary>
        /// <param name="target1">比較対象１</param>
        /// <param name="target2">比較対象２</param>
        /// <returns>true：キーが同じ　false：キーが異なる</returns>
        private bool IsEqualsAutoAnsItemStForPriority(AutoAnsItemSt target1, AutoAnsItemSt target2)
        {
            return target1.GoodsMakerCd == target2.GoodsMakerCd;
        }

        /// <summary>
        /// 同一キーの自動回答品目設定マスタレコードか否か
        /// </summary>
        /// <param name="target1">比較対象１</param>
        /// <param name="target2">比較対象２</param>
        /// <returns>true：キーが同じ　false：キーが異なる</returns>
        private bool IsEqualsAutoAnsItemSt(AutoAnsItemSt target1, AutoAnsItemStWork target2)
        {
            if (target1.EnterpriseCode == target2.EnterpriseCode
                && target1.SectionCode == target2.SectionCode
                && target1.CustomerCode == target2.CustomerCode
                && target1.GoodsMGroup == target2.GoodsMGroup
                && target1.BLGoodsCode == target2.BLGoodsCode
                && target1.GoodsMakerCd == target2.GoodsMakerCd
                && target1.PrmSetDtlNo2 == target2.PrmSetDtlNo2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 優先順位の編集
        /// </summary>
        /// <param name="editList">編集対象リスト</param>
        /// <param name="retList">編集対象リストと同一BLコードのレコード</param>
        /// <remarks>
        /// <br>UpdateNote : 2015/10/19 田建委 </br>
        /// <br>管理番号   : 11170187-00 Redmine#47535</br>
        /// <br>           : 既存レコードの優先順位＞２ && 新規レコードの優先順位＞既存レコードの優先順位の場合登録エラーの解除</br>
        /// </remarks>
        private void EditForPriority(ref List<AutoAnsItemSt> editList, ref List<AutoAnsItemSt> retList )
        {
            // リストから追加・削除しながら自己回帰するため、foreachは使用不可
            for (int i1 = 0; i1 < retList.Count; i1++)
            {
                bool isNoAdd = true;
                for (int i2 = 0; i2 < editList.Count; i2++)
                {
                    if (editList[i2].PriorityOrder >= retList[i1].PriorityOrder)
                    {
                        if (editList[i2].PriorityOrder == retList[i1].PriorityOrder)
                        {
                            // 同一の優先順位であれば優先順位を１追加
                            retList[i1].PriorityOrder++;
                            continue;
                        }

                        // 編集対象リストの途中に追加
                        //editList.Insert(retList[i1].PriorityOrder - 1, retList[i1]); // DEL 2015/10/19 田建委 Redmine#47535
                        editList.Add(retList[i1]); // ADD 2015/10/19 田建委 Redmine#47535
                        isNoAdd = false;
                        break;
                    }
                }
                // 途中に追加されなかったら、retListから編集対象リストの最後に追加
                if (isNoAdd)
                {
                    editList.Add(retList[i1]);
                }
                // 追加したレコードをretListから削除
                retList.Remove(retList[i1]);
                // 自己回帰
                EditForPriority(ref editList, ref retList);
            }
        }

        /// <summary>
        /// 自動回答品目設定マスタレコードから、検索条件の作成
        /// 優先順位の整合性確認用
        /// </summary>
        /// <param name="r">自動回答品目設定マスタレコード</param>
        /// <returns>
        /// 検索条件文字列　検索キー：企業コード、拠点コード、得意先コード
        /// 商品中分類コード、BL商品コード
        /// </returns>
        private string GetFilterPriority(AutoAnsItemStWork r)
        {
            return string.Format(
                "{0}='{1}' AND " +
                "{2}='{3}' AND " +
                "{4}='{5}' AND " +
                "{6}='{7}' AND " +
                "{8}='{9}' AND " 
                , ct_COL_ENTERPRISECODE, r.EnterpriseCode.ToString()
                , ct_COL_SECTIONCODE, r.SectionCode
                , ct_COL_CUSTOMERCODE, r.CustomerCode
                , ct_COL_GOODSMGROUP, r.GoodsMGroup
                , ct_COL_BLGOODSCODE, r.BLGoodsCode);
        }


        /// <summary>
        /// 更新件数の取得（内部DataTableより）
        /// </summary>
        /// <returns></returns>
        public int GetUpdateCountFromTable()
        {
            if (_dataTableList != null)
            {
                DataView view = new DataView(_dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                // 自動回答区分・優先順位の変更があるか、新規追加行の入力行が存在する時、更新対象とする
                view.RowFilter = string.Format("{0}<>{1} OR {2}<>{3} OR ( {4}={5} AND {6}={7} )",
                                                ct_COL_AUTOANSWERDIV, ct_COL_AUTOANSWERDIV_BACKUP,
                                                ct_COL_PRIORITYORDER, ct_COL_PRIORITYORDER_BACKUP,
                                                ct_COL_NEWADDROWDIV, ((int)NewAddRowDiv.New).ToString(),
                                                ct_COL_NEWADDROWALLOWSAVE, ((int)NewAddRowAllowSave.Yes).ToString());

                return view.Count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// DataTableからの一括書き込み処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int WriteAll( out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // DataTableから書き込みリスト生成
                ArrayList paraAutoAnsItemStList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows )
                {
                    // 変更有無チェック
                    // UPD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    //if (((int)row[ct_COL_AUTOANSWERDIV] == (int)row[ct_COL_AUTOANSWERDIV_BACKUP] &&
                    //     (int)row[ct_COL_PRIORITYORDER] == (int)row[ct_COL_PRIORITYORDER_BACKUP] &&
                    //     (int)row[ct_COL_NEWADDROWDIV] == (int)NewAddRowDiv.Edit) ||
                    //    ((int)row[ct_COL_NEWADDROWDIV] == (int)NewAddRowDiv.New &&
                    //     (int)row[ct_COL_NEWADDROWALLOWSAVE] == (int)NewAddRowAllowSave.No)
                    //   )
                    #endregion 
                    if (( IntObjToInt(row[ct_COL_AUTOANSWERDIV]) == IntObjToInt(row[ct_COL_AUTOANSWERDIV_BACKUP]) &&
                         IntObjToInt(row[ct_COL_PRIORITYORDER]) == IntObjToInt(row[ct_COL_PRIORITYORDER_BACKUP]) &&
                         IntObjToInt(row[ct_COL_NEWADDROWDIV]) == (int)NewAddRowDiv.Edit) ||
                        (IntObjToInt(row[ct_COL_NEWADDROWDIV]) == (int)NewAddRowDiv.New &&
                         IntObjToInt(row[ct_COL_NEWADDROWALLOWSAVE]) == (int)NewAddRowAllowSave.No)
                       )
                    // UPD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // 変更可能な項目がSearch時と変わらないので対象外にする
                        continue;
                    }



                    AutoAnsItemStWork autoAnsItemStWork = CopyToAutoAnsItemStWorkFromDataRow( row );
                    paraAutoAnsItemStList.Add( autoAnsItemStWork );
                }
                // 変更有無チェック
                if ( paraAutoAnsItemStList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "更新対象のデータが存在しません";
                    return status;
                }

                object paraObj = (object)paraAutoAnsItemStList;


                // 書き込み処理
                status = this._iAutoAnsItemStDB.Write( ref paraObj );

                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 何かしらのエラー発生
                    message = "登録に失敗しました。";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 内部データテーブル書き換え処理(物理削除後)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList AutoAnsItemStWorkList )
        {
            foreach ( object obj in AutoAnsItemStWorkList )
            {
                if ( obj is AutoAnsItemStWork )
                {
                    AutoAnsItemStWork retWork = (AutoAnsItemStWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // 削除
                        _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="AutoAnsItemStList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList AutoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraAutoAnsItemStList = new ArrayList();
                AutoAnsItemStWork autoAnsItemStWork = null;

                for (int i = 0; i < AutoAnsItemStList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)AutoAnsItemStList[i]);

                    paraAutoAnsItemStList.Add(autoAnsItemStWork);
                }
                object paraObj = (object)paraAutoAnsItemStList;

                // 論理削除処理
                status = this._iAutoAnsItemStDB.LogicalDelete( ref paraObj );

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 内部データテーブル書き換え処理(新規追加行)
        /// </summary>
        /// <param name="retObj"></param>
        public int LogicalDeleteRowIndex(ref int rowIndex, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            DataRow row = this.GetRowForMaintenance(rowIndex);

            if (row != null)
            {
                // 削除
                _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Remove(row);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// 内部データテーブル書き換え処理(新規追加行)
        /// </summary>
        /// <param name="retObj"></param>
        private int LogicalDeleteFilter(string filter, out AutoAnsItemStWork deleteAutoAnsItemStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = string.Empty;
            deleteAutoAnsItemStWork = new AutoAnsItemStWork();

            DataView deleteDataView = this.GetRowListForMaintenance(filter);

            if (deleteDataView != null && deleteDataView.Count != 0)
            {
                // 名称退避
                deleteAutoAnsItemStWork.SectionNm = deleteDataView[0][ct_COL_SECTIONNM].ToString();
                deleteAutoAnsItemStWork.CustomerName = deleteDataView[0][ct_COL_CUSTOMERNAME].ToString();
                deleteAutoAnsItemStWork.GoodsMGroupName = deleteDataView[0][ct_COL_GOODSMGROUPNAME].ToString();
                deleteAutoAnsItemStWork.BLGoodsName = deleteDataView[0][ct_COL_BLGOODSNAME].ToString();
                deleteAutoAnsItemStWork.MakerName = deleteDataView[0][ct_COL_MAKERNAME].ToString();

                foreach (DataRow dvr in deleteDataView.Table.Select(filter))
                {
                    // 内部テーブル行指定削除
                    int rowNumberDisplay = 0;
                    int.TryParse(dvr[ct_COL_ROWNUMBERDISPLAY].ToString(), out rowNumberDisplay);
                    status = LogicalDeleteRowIndex(ref rowNumberDisplay, out message);
                    if (status != 0) break;
                }
            }
            return status;
        }

        #endregion

        #region Revival 復旧処理
        /// <summary>
        /// 復旧処理
        /// </summary>
        /// <param name="AutoAnsItemStList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
        /// </remarks>
        public int Revival(ref ArrayList autoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraAutoAnsItemStList = new ArrayList();
                AutoAnsItemStWork autoAnsItemStWork = null;

                for (int i = 0; i < autoAnsItemStList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)autoAnsItemStList[i]);

                    paraAutoAnsItemStList.Add(autoAnsItemStWork);
                }

                object paraObj = (object)paraAutoAnsItemStList;

                // 書き込み処理
                status = this._iAutoAnsItemStDB.RevivalLogicalDelete(ref paraObj);

                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region Delete 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="AutoAnsItemStList">削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理（物理削除）を行います。</br>
        /// </remarks>
        public int Delete(ref ArrayList AutoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // 復活、物理削除は優良設定詳細コード２を除いたキー項目（当画面から1件のレコードで済む）を
                // 検索条件とするため、パラメータを1件にする
                
                byte[] paraAutoAnsItemStWork = null;
                AutoAnsItemStWork autoAnsItemStWork = null;
                ArrayList autoAnsItemStWorkList = new ArrayList();	// ワーククラス格納用ArrayList

                // ワーククラス格納用ArrayListへ詰め替え
                for (int i = 0; i < AutoAnsItemStList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)AutoAnsItemStList[i]);
                    autoAnsItemStWorkList.Add(autoAnsItemStWork);
                }
                // ArrayListから配列を生成
                AutoAnsItemStWork[] autoAnsItemStWorks = (AutoAnsItemStWork[])autoAnsItemStWorkList.ToArray(typeof(AutoAnsItemStWork));
                AutoAnsItemStWork[] autoAnsItemStWorksPara = new AutoAnsItemStWork[1];
                autoAnsItemStWorksPara[0] = autoAnsItemStWorks[0];

                // シリアライズ
                paraAutoAnsItemStWork = XmlByteSerializer.Serialize(autoAnsItemStWorksPara);

                // 物理削除処理
                status = this._iAutoAnsItemStDB.Delete(paraAutoAnsItemStWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // テーブルから削除
                        DeleteFromDataTable( autoAnsItemStWorkList );
                    }
                }
                else
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region データセット列情報構築処理
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // 自動回答品目設定テーブル列定義
            //----------------------------------------------------------------
            DataTable AutoAnsItemStTable = new DataTable(ct_TABLE_AUTOANSITEMST);


            // 作成日時
            AutoAnsItemStTable.Columns.Add(ct_COL_CREATEDATETIME, typeof(DateTime));
            // 更新日時
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDATEDATETIME, typeof(DateTime));
            // 企業コード
            AutoAnsItemStTable.Columns.Add(ct_COL_ENTERPRISECODE, typeof(string));
            // GUID
            AutoAnsItemStTable.Columns.Add(ct_COL_FILEHEADERGUID, typeof(Guid));
            // 更新従業員コード
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDEMPLOYEECODE, typeof(string));
            // 更新アセンブリID1
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDASSEMBLYID1, typeof(string));
            // 更新アセンブリID2
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDASSEMBLYID2, typeof(string));
            // 論理削除区分
            AutoAnsItemStTable.Columns.Add(ct_COL_LOGICALDELETECODE, typeof(Int32));
            // 拠点コード
            AutoAnsItemStTable.Columns.Add(ct_COL_SECTIONCODE, typeof(string));
            // 拠点名称
            AutoAnsItemStTable.Columns.Add(ct_COL_SECTIONNM, typeof(string));
            // 得意先コード
            AutoAnsItemStTable.Columns.Add(ct_COL_CUSTOMERCODE, typeof(Int32));
            // 得意先名称
            AutoAnsItemStTable.Columns.Add(ct_COL_CUSTOMERNAME, typeof(string));
            // 商品中分類コード
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUP, typeof(Int32));
            // 商品中分類名称
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUPNAME, typeof(string));
            // BL商品コード
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSCODE, typeof(Int32));
            // BL商品コード名称
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSNAME, typeof(string));
            // 商品メーカーコード
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMAKERCD, typeof(Int32));
            // メーカー名称
            AutoAnsItemStTable.Columns.Add(ct_COL_MAKERNAME, typeof(string));
            // 種別
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNO2, typeof(Int32));
            // 種別名称
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNAME2, typeof(string));
            // 自動回答区分
            AutoAnsItemStTable.Columns.Add(ct_COL_AUTOANSWERDIV, typeof(Int32));
            // 自動回答区分バックアップ
            AutoAnsItemStTable.Columns.Add(ct_COL_AUTOANSWERDIV_BACKUP, typeof(Int32));
            // 優先順位
            AutoAnsItemStTable.Columns.Add(ct_COL_PRIORITYORDER, typeof(Int32));
            // 優先順位バックアップ
            AutoAnsItemStTable.Columns.Add(ct_COL_PRIORITYORDER_BACKUP, typeof(Int32));

            # region [ソート用]
            // 拠点コード
            AutoAnsItemStTable.Columns.Add(ct_COL_SECTIONCODE_SORT, typeof(string));
            // 得意先コード
            AutoAnsItemStTable.Columns.Add(ct_COL_CUSTOMERCODE_SORT, typeof(Int32));
            // 商品中分類コード
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUP_SORT, typeof(Int32));
            // BL商品コード
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSCODE_SORT, typeof(Int32));
            // 商品メーカーコード
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMAKERCD_SORT, typeof(Int32));
            // 種別コード
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNO2_SORT, typeof(Int32));
            # endregion

            // 論理削除日(表示用)
            AutoAnsItemStTable.Columns.Add(ct_COL_LOGICALDELETEDATE, typeof(string));
            // 商品中分類コード（表示用）
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUPDISPLAY, typeof(string));
            // BL商品コード（表示用）
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSCODEDISPLAY, typeof(string));
            // 種別（表示用）
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNO2DISPLAY, typeof(string));
            // 優先順位（表示用）
            AutoAnsItemStTable.Columns.Add(ct_COL_PRIORITYORDERDISPLAY, typeof(string));
            // オブジェクト(内部保持用)
            AutoAnsItemStTable.Columns.Add(ct_COL_AUTOANSITEMSTWORKOBJECT, typeof(AutoAnsItemStWork));
            // 新規追加行区分（内部保持用）
            AutoAnsItemStTable.Columns.Add(ct_COL_NEWADDROWDIV, typeof(Int32));
            // 新規追加行表示区分（内部保持用）
            AutoAnsItemStTable.Columns.Add(ct_COL_NEWADDROWALLOWSAVE, typeof(Int32));
            // 行№（表示用）
            AutoAnsItemStTable.Columns.Add(ct_COL_ROWNUMBERDISPLAY, typeof(Int32));

            this._dataTableList.Tables.Add(AutoAnsItemStTable);

            //----------------------------------------------------------------
            // データビュー生成
            //----------------------------------------------------------------
            this._dataView = new DataView(AutoAnsItemStTable);
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._dataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}",
                                    ct_COL_SECTIONCODE_SORT,
                                    ct_COL_CUSTOMERCODE_SORT,
                                    ct_COL_GOODSMGROUP_SORT,
                                    ct_COL_BLGOODSCODE_SORT,
                                    ct_COL_GOODSMAKERCD_SORT
                                    );
            // ADD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        }
        #endregion

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバーコピー処理（自動回答品目設定クラス⇒自動回答品目設定ワーククラス）
        /// </summary>
        /// <param name="AutoAnsItemSt">自動回答品目設定クラス</param>
        /// <returns>AutoAnsItemStWork</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定クラスから自動回答品目設定ワーククラスへメンバーのコピーを行います。</br>
        /// </remarks>
        private AutoAnsItemStWork CopyToAutoAnsItemStWorkFromAutoAnsItemSt(AutoAnsItemSt autoAnsItemSt)
        {
            AutoAnsItemStWork autoAnsItemStWork = new AutoAnsItemStWork();

            autoAnsItemStWork.CreateDateTime = autoAnsItemSt.CreateDateTime; // 作成日時
            autoAnsItemStWork.UpdateDateTime = autoAnsItemSt.UpdateDateTime; // 更新日時
            autoAnsItemStWork.EnterpriseCode = autoAnsItemSt.EnterpriseCode; // 企業コード
            autoAnsItemStWork.FileHeaderGuid = autoAnsItemSt.FileHeaderGuid; // GUID
            autoAnsItemStWork.UpdEmployeeCode = autoAnsItemSt.UpdEmployeeCode; // 更新従業員コード
            autoAnsItemStWork.UpdAssemblyId1 = autoAnsItemSt.UpdAssemblyId1; // 更新アセンブリID1
            autoAnsItemStWork.UpdAssemblyId2 = autoAnsItemSt.UpdAssemblyId2; // 更新アセンブリID2
            autoAnsItemStWork.LogicalDeleteCode = autoAnsItemSt.LogicalDeleteCode; // 論理削除区分
            autoAnsItemStWork.SectionCode = autoAnsItemSt.SectionCode; // 拠点コード
            autoAnsItemStWork.CustomerCode = autoAnsItemSt.CustomerCode; // 得意先コード
            autoAnsItemStWork.GoodsMGroup = autoAnsItemSt.GoodsMGroup; // 商品中分類コード
            autoAnsItemStWork.BLGoodsCode = autoAnsItemSt.BLGoodsCode; // BL商品コード
            autoAnsItemStWork.GoodsMakerCd = autoAnsItemSt.GoodsMakerCd; // 商品メーカーコード
            autoAnsItemStWork.PrmSetDtlNo2 = autoAnsItemSt.PrmSetDtlNo2; // 優良設定詳細コード２
            autoAnsItemStWork.PrmSetDtlName2 = autoAnsItemSt.PrmSetDtlName2; // 優良設定詳細名称２
            autoAnsItemStWork.AutoAnswerDiv = autoAnsItemSt.AutoAnswerDiv; // 自動回答区分
            autoAnsItemStWork.PriorityOrder = autoAnsItemSt.PriorityOrder; //優先順位

            autoAnsItemStWork.SectionNm = autoAnsItemSt.SectionNm;  // 拠点名称
            autoAnsItemStWork.CustomerName = autoAnsItemSt.CustomerName;    // 得意先名称
            autoAnsItemStWork.GoodsMGroupName = autoAnsItemSt.GoodsMGroupName;  // 商品中分類名称
            autoAnsItemStWork.BLGoodsName = autoAnsItemSt.BLGoodsName; // BL商品コード名称
            autoAnsItemStWork.MakerName = autoAnsItemSt.MakerName;  // メーカー名称


            return autoAnsItemStWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自動回答品目設定ワーククラス⇒自動回答品目設定クラス）
        /// </summary>
        /// <param name="AutoAnsItemStWork">自動回答品目設定ワーククラス</param>
        /// <returns>AutoAnsItemSt</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定ワーククラスから自動回答品目設定クラスへメンバーのコピーを行います。</br>
        /// </remarks>
        private AutoAnsItemSt CopyToAutoAnsItemStFromAutoAnsItemStWork(AutoAnsItemStWork autoAnsItemStWork)
        {
            AutoAnsItemSt autoAnsItemSt = new AutoAnsItemSt();

            autoAnsItemSt.CreateDateTime = autoAnsItemStWork.CreateDateTime; // 作成日時
            autoAnsItemSt.UpdateDateTime = autoAnsItemStWork.UpdateDateTime; // 更新日時
            autoAnsItemSt.EnterpriseCode = autoAnsItemStWork.EnterpriseCode; // 企業コード
            autoAnsItemSt.FileHeaderGuid = autoAnsItemStWork.FileHeaderGuid; // GUID
            autoAnsItemSt.UpdEmployeeCode = autoAnsItemStWork.UpdEmployeeCode; // 更新従業員コード
            autoAnsItemSt.UpdAssemblyId1 = autoAnsItemStWork.UpdAssemblyId1; // 更新アセンブリID1
            autoAnsItemSt.UpdAssemblyId2 = autoAnsItemStWork.UpdAssemblyId2; // 更新アセンブリID2
            autoAnsItemSt.LogicalDeleteCode = autoAnsItemStWork.LogicalDeleteCode; // 論理削除区分
            autoAnsItemSt.SectionCode = autoAnsItemStWork.SectionCode; // 拠点コード
            autoAnsItemSt.SectionNm = autoAnsItemStWork.SectionNm;  // 拠点名称
            autoAnsItemSt.CustomerCode = autoAnsItemStWork.CustomerCode; // 得意先コード
            autoAnsItemSt.CustomerName = autoAnsItemStWork.CustomerName; // 得意先名称
            autoAnsItemSt.GoodsMGroup = autoAnsItemStWork.GoodsMGroup; // 商品中分類コード
            autoAnsItemSt.GoodsMGroupName = autoAnsItemStWork.GoodsMGroupName; // 商品中分類名称
            autoAnsItemSt.BLGoodsCode = autoAnsItemStWork.BLGoodsCode; // BL商品コード
            autoAnsItemSt.GoodsMakerCd = autoAnsItemStWork.GoodsMakerCd; // 商品メーカーコード
            autoAnsItemSt.MakerName = autoAnsItemStWork.MakerName; // メーカー名称
            autoAnsItemSt.AutoAnswerDiv = autoAnsItemStWork.AutoAnswerDiv; // 自動回答区分
            autoAnsItemSt.BLGoodsName = autoAnsItemStWork.BLGoodsName; // BL商品コード名称
            autoAnsItemSt.PriorityOrder = autoAnsItemStWork.PriorityOrder; // 優先順位
            autoAnsItemSt.PrmSetDtlNo2 = autoAnsItemStWork.PrmSetDtlNo2; //種別コード
            autoAnsItemSt.PrmSetDtlName2 = autoAnsItemStWork.PrmSetDtlName2; //種別名称

            return autoAnsItemSt;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自動回答品目設定クラス⇒DataRow）
        /// </summary>
        /// <param name="AutoAnsItemStWork">自動回答品目設定クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定ワーククラスから自動回答品目設定クラスへメンバーのコピーを行います。</br>
        /// </remarks>
        private void CopyToDataRowFromAutoAnsItemStWork( ref DataRow dr, AutoAnsItemStWork autoAnsItemStWork )
        {
            # region [dr←AutoAnsItemSt]
            dr[ct_COL_ROWNUMBERDISPLAY] = 0;
            dr[ct_COL_CREATEDATETIME] = autoAnsItemStWork.CreateDateTime; // 作成日時
            dr[ct_COL_UPDATEDATETIME] = autoAnsItemStWork.UpdateDateTime; // 更新日時
            dr[ct_COL_ENTERPRISECODE] = autoAnsItemStWork.EnterpriseCode; // 企業コード
            dr[ct_COL_FILEHEADERGUID] = autoAnsItemStWork.FileHeaderGuid; // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = autoAnsItemStWork.UpdEmployeeCode; // 更新従業員コード
            dr[ct_COL_UPDASSEMBLYID1] = autoAnsItemStWork.UpdAssemblyId1; // 更新アセンブリID1
            dr[ct_COL_UPDASSEMBLYID2] = autoAnsItemStWork.UpdAssemblyId2; // 更新アセンブリID2
            dr[ct_COL_LOGICALDELETECODE] = autoAnsItemStWork.LogicalDeleteCode; // 論理削除区分
            dr[ct_COL_SECTIONCODE] = autoAnsItemStWork.SectionCode; // 拠点コード
            dr[ct_COL_SECTIONNM] = autoAnsItemStWork.SectionNm; // 拠点名称
            dr[ct_COL_CUSTOMERCODE] = autoAnsItemStWork.CustomerCode; // 得意先コード
            dr[ct_COL_CUSTOMERNAME] = autoAnsItemStWork.CustomerName; // 得意先名称
            if (autoAnsItemStWork.GoodsMGroup == 0)
            {
                dr[ct_COL_GOODSMGROUP] = 0; // 商品中分類コード
                dr[ct_COL_GOODSMGROUPDISPLAY] = "0000"; // 商品中分類コード（表示用）
                dr[ct_COL_GOODSMGROUPNAME] = "共通"; // 商品中分類名称
            }
            else
            {
                dr[ct_COL_GOODSMGROUP] = autoAnsItemStWork.GoodsMGroup; // 商品中分類コード
                dr[ct_COL_GOODSMGROUPDISPLAY] = autoAnsItemStWork.GoodsMGroup.ToString("0000"); // 商品中分類コード（表示用）
                dr[ct_COL_GOODSMGROUPNAME] = autoAnsItemStWork.GoodsMGroupName; // 商品中分類名称
            }
            if (autoAnsItemStWork.BLGoodsCode == 0)
            {
                // 商品中分類コードが共通の時はBL商品コードの表示はしない
                if (autoAnsItemStWork.GoodsMGroup == 0)
                {
                    dr[ct_COL_BLGOODSCODE] = 0; // BL商品コード
                    dr[ct_COL_BLGOODSCODEDISPLAY] = string.Empty; // BL商品コード（表示用）
                    dr[ct_COL_BLGOODSNAME] = string.Empty; // BL商品名称
                }
                else
                {
                    dr[ct_COL_BLGOODSCODE] = 0; // BL商品コード
                    dr[ct_COL_BLGOODSCODEDISPLAY] = "00000"; // BL商品コード（表示用）
                    dr[ct_COL_BLGOODSNAME] = "共通"; // BL商品名称
                }
            }
            else
            {
                dr[ct_COL_BLGOODSCODE] = autoAnsItemStWork.BLGoodsCode; // BL商品コード
                dr[ct_COL_BLGOODSCODEDISPLAY] = autoAnsItemStWork.BLGoodsCode.ToString("00000"); // BL商品コード（表示用）
                dr[ct_COL_BLGOODSNAME] = autoAnsItemStWork.BLGoodsName; // BL商品名称
            }
            dr[ct_COL_GOODSMAKERCD] = autoAnsItemStWork.GoodsMakerCd; // 商品メーカーコード
            dr[ct_COL_MAKERNAME] = autoAnsItemStWork.MakerName; // 商品メーカー名称
            if (autoAnsItemStWork.PrmSetDtlNo2 == 0)
            {
                dr[ct_COL_PRMSETDTLNO2] = 0; // 種別（優良設定詳細コード２）
                dr[ct_COL_PRMSETDTLNO2DISPLAY] = string.Empty; // 種別（優良設定詳細コード２）（表示用）
            }
            else
            {
                dr[ct_COL_PRMSETDTLNO2] = autoAnsItemStWork.PrmSetDtlNo2; // 種別（優良設定詳細コード２）
                dr[ct_COL_PRMSETDTLNO2DISPLAY] = autoAnsItemStWork.PrmSetDtlNo2.ToString("0"); // 種別（優良設定詳細コード２）（表示用）
            }
            dr[ct_COL_PRMSETDTLNAME2] = autoAnsItemStWork.PrmSetDtlName2; // 種別名称
            dr[ct_COL_AUTOANSWERDIV] = autoAnsItemStWork.AutoAnswerDiv; // 自動回答区分
            if (autoAnsItemStWork.PriorityOrder == 0)
            {
                dr[ct_COL_PRIORITYORDER] = 0; // 優先順位
                dr[ct_COL_PRIORITYORDER_BACKUP] = 0; // 優先順位(前回値退避)
                dr[ct_COL_PRIORITYORDERDISPLAY] = string.Empty; // 優先順位（表示用）
            }
            else
            {
                dr[ct_COL_PRIORITYORDER] = autoAnsItemStWork.PriorityOrder; // 優先順位
                dr[ct_COL_PRIORITYORDER_BACKUP] = autoAnsItemStWork.PriorityOrder; // 優先順位(前回値退避)
                dr[ct_COL_PRIORITYORDERDISPLAY] = autoAnsItemStWork.PriorityOrder.ToString("0"); // 優先順位（表示用）
            }


            dr[ct_COL_AUTOANSWERDIV_BACKUP] = autoAnsItemStWork.AutoAnswerDiv; // 自動回答区分(前回値退避)

            // 論理削除日(表示用)
            if (autoAnsItemStWork.LogicalDeleteCode == 0)
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", autoAnsItemStWork.UpdateDateTime);
            }

            // ソート用カラム
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue(autoAnsItemStWork.SectionCode); // 拠点コード
            dr[ct_COL_CUSTOMERCODE_SORT] = autoAnsItemStWork.CustomerCode; // 得意先コード
            dr[ct_COL_GOODSMAKERCD_SORT] = autoAnsItemStWork.GoodsMakerCd; // 商品メーカーコード
            dr[ct_COL_GOODSMGROUP_SORT] = autoAnsItemStWork.GoodsMGroup; // 商品中分類コード
            dr[ct_COL_BLGOODSCODE_SORT] = autoAnsItemStWork.BLGoodsCode; // BL商品コード
            dr[ct_COL_PRMSETDTLNO2_SORT] = autoAnsItemStWork.PrmSetDtlNo2; // 種別コード

            // オブジェクト(内部保持用)
            dr[ct_COL_AUTOANSITEMSTWORKOBJECT] = autoAnsItemStWork;

            // 新規追加行情報
            dr[ct_COL_NEWADDROWDIV] = NewAddRowDiv.Edit;  // 新規追加行区分（内部保持用）
            dr[ct_COL_NEWADDROWALLOWSAVE] = NewAddRowAllowSave.Yes;  // 新規追加行表示区分（内部保持用）

            # endregion
        }

        /// <summary>
        /// クラスメンバーコピー処理（自動回答品目設定クラス（新規）⇒DataRow）
        /// </summary>
        /// <param name="AutoAnsItemStWork">自動回答品目設定クラス（新規）</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定ワーククラスから自動回答品目設定クラスへメンバーのコピーを行います。</br>
        /// </remarks>
        private void CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref DataRow dr, AutoAnsItemStWork autoAnsItemStWork)
        {
            # region [dr←AutoAnsItemSt(New)]
            dr[ct_COL_ROWNUMBERDISPLAY] = 1;
            dr[ct_COL_CREATEDATETIME] = autoAnsItemStWork.CreateDateTime; // 作成日時
            dr[ct_COL_UPDATEDATETIME] = autoAnsItemStWork.UpdateDateTime; // 更新日時
            dr[ct_COL_ENTERPRISECODE] = autoAnsItemStWork.EnterpriseCode; // 企業コード
            dr[ct_COL_FILEHEADERGUID] = autoAnsItemStWork.FileHeaderGuid; // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = autoAnsItemStWork.UpdEmployeeCode; // 更新従業員コード
            dr[ct_COL_UPDASSEMBLYID1] = autoAnsItemStWork.UpdAssemblyId1; // 更新アセンブリID1
            dr[ct_COL_UPDASSEMBLYID2] = autoAnsItemStWork.UpdAssemblyId2; // 更新アセンブリID2
            dr[ct_COL_LOGICALDELETECODE] = autoAnsItemStWork.LogicalDeleteCode; // 論理削除区分
            dr[ct_COL_SECTIONCODE] = autoAnsItemStWork.SectionCode; // 拠点コード 
            dr[ct_COL_SECTIONNM] = autoAnsItemStWork.SectionNm; // 拠点名称
            dr[ct_COL_CUSTOMERCODE] = autoAnsItemStWork.CustomerCode; // 得意先コード
            dr[ct_COL_CUSTOMERNAME] = autoAnsItemStWork.CustomerName; // 得意先名称
            dr[ct_COL_GOODSMGROUP] = autoAnsItemStWork.GoodsMGroup; // 商品中分類コード
            dr[ct_COL_GOODSMGROUPDISPLAY] = string.Empty; // 商品中分類コード（表示用）
            dr[ct_COL_GOODSMGROUPNAME] = autoAnsItemStWork.GoodsMGroupName; // 商品中分類名称
            dr[ct_COL_BLGOODSCODE] = autoAnsItemStWork.BLGoodsCode; // BL商品コード
            dr[ct_COL_BLGOODSCODEDISPLAY] = string.Empty; // BL商品コード
            dr[ct_COL_BLGOODSNAME] = autoAnsItemStWork.BLGoodsName; // BL商品名称
            dr[ct_COL_GOODSMAKERCD] = autoAnsItemStWork.GoodsMakerCd; // 商品メーカーコード
            dr[ct_COL_MAKERNAME] = autoAnsItemStWork.MakerName; // 商品メーカー名称
            dr[ct_COL_PRMSETDTLNO2] = autoAnsItemStWork.PrmSetDtlNo2; // 種別（優良設定詳細コード２）
            dr[ct_COL_PRMSETDTLNO2DISPLAY] = string.Empty; // 種別（優良設定詳細コード２）（表示用）
            dr[ct_COL_PRMSETDTLNAME2] = autoAnsItemStWork.PrmSetDtlName2; // 種別名称
            dr[ct_COL_AUTOANSWERDIV] = autoAnsItemStWork.AutoAnswerDiv; // 自動回答区分
            dr[ct_COL_PRIORITYORDER] = autoAnsItemStWork.PriorityOrder; // 優先順位
            dr[ct_COL_PRIORITYORDER_BACKUP] = autoAnsItemStWork.PriorityOrder; // 優先順位(前回値退避)
            dr[ct_COL_PRIORITYORDERDISPLAY] = string.Empty; // 優先順位（表示用）
            dr[ct_COL_AUTOANSWERDIV_BACKUP] = autoAnsItemStWork.AutoAnswerDiv; // 自動回答区分(前回値退避)
            dr[ct_COL_LOGICALDELETEDATE] = string.Empty;

            // ソート用カラム
            // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // dr[ct_COL_SECTIONCODE_SORT] = GetSortValue(autoAnsItemStWork.SectionCode); // 拠点コード
            // 未編集の新規追加行は常に一番下に表示
            dr[ct_COL_SECTIONCODE_SORT] = "ZZ"; // 拠点コード
            // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            dr[ct_COL_CUSTOMERCODE_SORT] = Int32.MaxValue; // 得意先コード ※最下行に表示するためMAX値を設定する
            dr[ct_COL_GOODSMAKERCD_SORT] = autoAnsItemStWork.GoodsMakerCd; // 商品メーカーコード
            dr[ct_COL_GOODSMGROUP_SORT] = autoAnsItemStWork.GoodsMGroup; // 商品中分類コード
            dr[ct_COL_BLGOODSCODE_SORT] = autoAnsItemStWork.BLGoodsCode; // BL商品コード
            dr[ct_COL_PRMSETDTLNO2_SORT] = autoAnsItemStWork.PrmSetDtlNo2; // 種別コード

            // オブジェクト(内部保持用)
            dr[ct_COL_AUTOANSITEMSTWORKOBJECT] = autoAnsItemStWork;

            // 新規追加行情報
            dr[ct_COL_NEWADDROWDIV] = NewAddRowDiv.New;  // 新規追加行区分（内部保持用）
            dr[ct_COL_NEWADDROWALLOWSAVE] = NewAddRowAllowSave.No;  // 新規追加行表示区分（内部保持用）

            # endregion
        }

        /// <summary>
        /// ソート値取得（数値）
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetSortValue( int value )
        {
            if ( value != 0 )
            {
                return value;
            }
            else
            {
                // 未設定が後ろになるようにする
                return Int32.MaxValue;
            }
        }
        /// <summary>
        /// ソート値取得（文字列）
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetSortValue( string value )
        {
            if ( value.Trim() != string.Empty )
            {
                return value;
            }
            else
            {
                // 未設定が後ろになるようにする
                // (※現状は拠点のみで使用しているので便宜的にAAにしています)
                return "AA";
            }
        }
        /// <summary>
        /// クラスメンバーコピー処理（DataRow⇒自動回答品目設定クラス）
        /// </summary>
        /// <param name="row"></param>
        /// <returns>AutoAnsItemStWork</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定ワーククラスから自動回答品目設定クラスへメンバーのコピーを行います。</br>
        /// </remarks>
        private AutoAnsItemStWork CopyToAutoAnsItemStWorkFromDataRow( DataRow row )
        {
            AutoAnsItemStWork autoAnsItemStWork = (AutoAnsItemStWork)row[ct_COL_AUTOANSITEMSTWORKOBJECT];
            
            // 書き換え可能項目のみ差し替える
            autoAnsItemStWork.AutoAnswerDiv = (int)row[ct_COL_AUTOANSWERDIV];
            autoAnsItemStWork.PriorityOrder = IntObjToInt(row[ct_COL_PRIORITYORDER]);
            

            // 新規追加の時は追加項目を設定する
            if ((int)row[ct_COL_NEWADDROWDIV] == (int)NewAddRowDiv.New)
            {
                autoAnsItemStWork.EnterpriseCode = this._enterpriseCode;
                autoAnsItemStWork.LogicalDeleteCode = (int)row[ct_COL_LOGICALDELETECODE]; // 論理削除区分
                autoAnsItemStWork.SectionCode = row[ct_COL_SECTIONCODE].ToString(); // 拠点コード
                autoAnsItemStWork.CustomerCode = (int)row[ct_COL_CUSTOMERCODE]; // 得意先コード
                autoAnsItemStWork.GoodsMGroup = (int)row[ct_COL_GOODSMGROUP]; // 商品中分類コード
                autoAnsItemStWork.BLGoodsCode = (int)row[ct_COL_BLGOODSCODE]; // BL商品コード
                autoAnsItemStWork.GoodsMakerCd = (int)row[ct_COL_GOODSMAKERCD]; // 商品メーカーコード
                autoAnsItemStWork.PrmSetDtlNo2 = (int)row[ct_COL_PRMSETDTLNO2]; // 優良設定詳細コード２
                autoAnsItemStWork.PrmSetDtlName2 = row[ct_COL_PRMSETDTLNAME2].ToString(); // 優良設定詳細名称２

                autoAnsItemStWork.SectionNm = row[ct_COL_SECTIONNM].ToString();  // 拠点名称
                autoAnsItemStWork.CustomerName = row[ct_COL_CUSTOMERNAME].ToString();    // 得意先名称
                autoAnsItemStWork.GoodsMGroupName = row[ct_COL_GOODSMGROUPNAME].ToString();  // 商品中分類名称
                autoAnsItemStWork.BLGoodsName = row[ct_COL_BLGOODSNAME].ToString(); // BL商品コード名称
                autoAnsItemStWork.MakerName = row[ct_COL_MAKERNAME].ToString();  // メーカー名称
            }

            return autoAnsItemStWork;
        }

        /// <summary>
        /// 抽出条件クラスメンバーコピー処理
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private AutoAnsItemStOrderWork CopyToAutoAnsItemStOrderWorkFromAutoAnsItemStOrder( AutoAnsItemStOrder paraData )
        {
            AutoAnsItemStOrderWork paraWork = new AutoAnsItemStOrderWork();
            
            # region [paraWork←paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;  // 企業コード
            paraWork.SectionCode = paraData.SectionCode;  // 拠点コード
            paraWork.St_CustomerCode = paraData.St_CustomerCode;  // 開始得意先コード
            paraWork.Ed_CustomerCode = paraData.Ed_CustomerCode;  // 終了得意先コード
            paraWork.St_GoodsMGroup = paraData.St_GoodsMGroup;  // 開始商品中分類コード
            paraWork.Ed_GoodsMGroup = paraData.Ed_GoodsMGroup;  // 終了商品中分類コード
            paraWork.St_BLGroupCode = paraData.St_BLGroupCode;  // 開始BLグループコード
            paraWork.Ed_BLGroupCode = paraData.Ed_BLGroupCode;  // 終了BLグループコード
            paraWork.St_BLGoodsCode = paraData.St_BLGoodsCode;  // 開始BL商品コード
            paraWork.Ed_BLGoodsCode = paraData.Ed_BLGoodsCode;  // 終了BL商品コード
            paraWork.St_GoodsMakerCd = paraData.St_GoodsMakerCd;  // 開始商品メーカーコード
            paraWork.Ed_GoodsMakerCd = paraData.Ed_GoodsMakerCd;  // 終了商品メーカーコード
            # endregion
            
            return paraWork;
        }
        #endregion

        #region SearchProc 検索処理メイン（論理削除含む）
        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果テーブル</param>
        /// <param name="AutoAnsItemStList">自動回答品目設定オブジェクトリスト</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定マスタの複数検索処理を行います。</br>
        /// </remarks>
        private int SearchProc( AutoAnsItemStOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                _autoAnsItemStWorkList = null;
                //==========================================
                // 自動回答品目設定マスタ読み込み
                //==========================================
                AutoAnsItemStOrderWork paraWork = CopyToAutoAnsItemStOrderWorkFromAutoAnsItemStOrder(paraData);

                // リモート戻りリスト
                object autoAnsItemStWorkList = null;
                // 自動回答品目設定マスタ検索
                status = this._iAutoAnsItemStDB.Search(out autoAnsItemStWorkList, paraWork, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)autoAnsItemStWorkList;
                    _autoAnsItemStWorkList = (ArrayList)autoAnsItemStWorkList;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #region Read 検索処理
        /// <summary>
        /// 自動回答品目設定マスタ複数検索処理（論理削除含まない）自動回答品目設定マスメン用
        /// </summary>
        /// <param name="autoAnsItemSt">検索パラメータ用</param>
        /// <param name="retList">返値用リスト</param>
        /// <returns></returns>
        public int Read2(AutoAnsItemSt autoAnsItemSt, ref List<AutoAnsItemSt> retList)
        {
            return Read2(autoAnsItemSt, ref retList, false);
        }

        /// <summary>
        /// 自動回答品目設定マスタ複数検索処理（論理削除含まない）自動回答品目設定マスメン用
        /// </summary>
        /// <param name="autoAnsItemSt">検索パラメータ用</param>
        /// <param name="retList">返値用リスト</param>
        /// <returns></returns>
        public int Read2(AutoAnsItemSt autoAnsItemSt, ref List<AutoAnsItemSt> retList,bool forPriority)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string message;
                retList = new List<AutoAnsItemSt>();

                // 抽出条件パラメータ
                AutoAnsItemStWork autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt(autoAnsItemSt);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(autoAnsItemStWork);

                // 検索
                ArrayList retWorkList;
                status = ReadProc2(parabyte, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message, forPriority);

                if (status == 0)
                {
                    foreach (object obj in retWorkList)
                    {
                        if (obj is AutoAnsItemStWork)
                        {
                            AutoAnsItemStWork retWork = (obj as AutoAnsItemStWork);

                            // クラス内メンバコピー
                            retList.Add(CopyToAutoAnsItemStFromAutoAnsItemStWork(retWork));
                        }
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                retList.Clear();
                //オフライン時はnullをセット
                this._iAutoAnsItemStDB = null;
                return -1;
            }
        }

        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果テーブル</param>
        /// <param name="AutoAnsItemStList">自動回答品目設定オブジェクトリスト</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 自動回答品目設定マスタの複数検索処理を行います。</br>
        /// </remarks>
        private int ReadProc2(byte[] paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message, bool forPriority)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                //==========================================
                // 自動回答品目設定マスタ読み込み
                //==========================================
                // リモート戻りリスト
                object autoAnsItemStWorkList = null;
                // 自動回答品目設定マスタ検索
                if (forPriority)
                {
                    status = this._iAutoAnsItemStDB.Read3(out autoAnsItemStWorkList, paraData, 0, logicalMode);
                }
                else
                {
                    status = this._iAutoAnsItemStDB.Read2(out autoAnsItemStWorkList, paraData, 0, logicalMode);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)autoAnsItemStWorkList;
                    _autoAnsItemStWorkList = (ArrayList)autoAnsItemStWorkList;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 提供優良設定リスト取得
        /// </summary>
        public int GetOfferPrimesettingList(ref DataView dataView) 
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            object objret = null;
            int status = -1;

            IPrimeSettingDB offerPrimeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB();
            DataTable PrimeSettingTable = CreateTable(PrimeSettingInfo.TABLENAME_PRIMESETTING);

            try
            {
                // 提供優良設定取得
                status = offerPrimeSettingSearchDB.Search(out objret);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)objret)       
                    {
                        DataRow primeSettingRow = PrimeSettingTable.NewRow();

                        primeSettingRow[COL_OFFERPRIMESETTING] = wkPrimeSettingWork;
                        primeSettingRow[COL_USERPRIMESETTING] = null;
                        primeSettingRow[COL_CHANGEFLAG] = false;                // 提供は変更不可
                        primeSettingRow[COL_CHECKSTATE] = CheckState.Unchecked; // 提供は未チェック（デフォルト）
                        primeSettingRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Unchecked; // 提供は未チェック（デフォルト）
                        
                        //カラムにデータをセット
                        //デフォルト表示順位はメーカーコード順
                        primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = 0;   

                        //表示区分は０固定(提供の場合）
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                        primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.GoodsMGroup;        // ADD 2008/07/01
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] = wkPrimeSettingWork.PartsMakerCd;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO] = wkPrimeSettingWork.TbsPartsCdDerivedNo;
                        primeSettingRow[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.PrmSetDtlNo1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrmSetDtlNo2;
                        primeSettingRow[PrimeSettingInfo.COL_SECRETCODE] = wkPrimeSettingWork.SecretCode;

                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = "";

                        primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.PrmSetDtlName1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrmSetDtlName2;

                        primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP] = wkPrimeSettingWork.PrmSetGroup;

                        PrimeSettingTable.Rows.Add(primeSettingRow);

                        
                        if (!wkPrimeSettingWork.PrmSetGroup.Equals(0))
                        {
                            Debug.WriteLine("優良設定グループ：" + ((int)primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP]).ToString() + " <- " + wkPrimeSettingWork.PrmSetGroup.ToString());
                            Debug.WriteLine("中：" + wkPrimeSettingWork.GoodsMGroup.ToString() + ", M：" + wkPrimeSettingWork.PartsMakerCd.ToString() + ", B：" + wkPrimeSettingWork.TbsPartsCode.ToString());
                        }
                    }

                    dataView = new DataView(PrimeSettingTable);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// テーブル作成
        /// </summary>
        private DataTable CreateTable(string TableName)
        {
            DataTable table = new DataTable(TableName);

            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERCD, typeof(int), "メーカーコード"));	//メーカーコード
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "メーカー"));	//全角メーカー名
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERHALFNAME, typeof(string), "ﾒｰｶｰ"));	//半角メーカー名
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BLｺｰﾄﾞ"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "品目名"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSHALFNAME, typeof(string), "品目名(半角)"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRECODE, typeof(int), "中分類"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRENAME, typeof(string), "中分類名"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SECRETCODE, typeof(int), "シークレットコード"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTCODE, typeof(int), "セレクトコード"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "セレクト"));           
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDCODE, typeof(int), "優良種別コード"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "種別"));            
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCD, typeof(int), "仕入先コード"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCDDERIVEDNO, typeof(int), "仕入先コード枝番"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERNAME, typeof(string), "仕入先名称"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MAKERDISPORDER, typeof(int), "表示順位"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_DISPLAYORDER, typeof(int), "表示順"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEDISPLAYCODE, typeof(int), ""));	//表示区分

            table.Columns.Add(CreateColumn(COL_CHANGEFLAG, typeof(bool), ""));	//変更フラグ
            table.Columns.Add(CreateColumn(COL_CHECKSTATE, typeof(CheckState), ""));	//チェック
            table.Columns.Add(CreateColumn(COL_ORIGINAL_CHECKSTATE, typeof(CheckState), ""));	//チェック
            table.Columns.Add(CreateColumn(COL_OFFERPRIMESETTING, typeof(object), ""));	//提供優良設定クラス
            table.Columns.Add(CreateColumn(COL_USERPRIMESETTING, typeof(object), ""));	//ユーザー優良設定クラス

            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRMSETGROUP, typeof(int), "優良設定グループ")); // 
            return table;
        }
        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }

        #endregion


        #region DataTable操作

        // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 行追加処理　自動回答品目設定マスメン一覧用
        /// </summary>
        /// <returns></returns>
        public void RowAdd()
        {
            // 新規追加行の追加
            DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
            AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
            CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref newRow, newRetWork);
            _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);

            // テーブル更新後イベント
            if (AfterTableUpdate != null)
            {
                AfterTableUpdate(this, new EventArgs());
            }
        }
        #region 旧ソース
        //public int RowAdd()
        //{
        //    int status = 0;

        //    // 新規追加行の追加
        //    DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
        //    AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
        //    CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref newRow, newRetWork);
        //    _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);

        //    // テーブル更新後イベント
        //    if (AfterTableUpdate != null)
        //    {
        //        AfterTableUpdate(this, new EventArgs());
        //    }

        //    return status;
        //}
        #endregion
        // UPD 2012/11/13 T.Yoshioka 2012/12/12配信 システムテスト障害№18,№19 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 行挿入処理　自動回答品目設定マスメン一覧用
        /// </summary>
        /// <returns></returns>
        public int RowInsert(string filter, string filterBefore, string sectionCode, int customerCode, int  makerCode, int goodsMGroup, int blCode)
        {
            string deleteFilter = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            DataView OfferPrimeSettingDataView = null;
            AutoAnsItemStWork deleteAutoAnsItemStWork = new AutoAnsItemStWork();

            // 変更前入力行削除
            status = LogicalDeleteFilter(filterBefore, out deleteAutoAnsItemStWork);

            // 優良設定マスタ取得
            status = GetOfferPrimesettingList(ref OfferPrimeSettingDataView);

            // 条件より抽出
            OfferPrimeSettingDataView.RowFilter = filter;

            // 初期値
            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // 種別が存在する時
            // --- DEL 2012/11/22 吉岡 2012/12/12配信分 システムテスト障害№77 --------->>>>>>>>>>>>>>>>>>>>>>>>
            #region del
            //// --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№58 --------->>>>>>>>>>>>>>>>>>>>>>>>
            ////if (OfferPrimeSettingDataView.Count != 0)
            //if (OfferPrimeSettingDataView.Count > 1)
            //// --- UPD 2012/11/22 三戸 2012/12/12配信分 システムテスト障害№58 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //{
            //    // 新規行削除 + 入力行削除
            //    deleteFilter = string.Format("{0}='' AND {1}=0 AND {2}=0 AND {3}=0 AND {4}=0 AND {5}={6}",
            //                                  ct_COL_SECTIONCODE.ToString(),
            //                                  ct_COL_CUSTOMERCODE.ToString(), 
            //                                  ct_COL_GOODSMGROUP.ToString(),
            //                                  ct_COL_BLGOODSCODE.ToString(), 
            //                                  ct_COL_GOODSMAKERCD.ToString(), 
            //                                  ct_COL_NEWADDROWALLOWSAVE.ToString(), (int)NewAddRowAllowSave.No
            //                                );
            //    status = LogicalDeleteFilter(deleteFilter, out deleteAutoAnsItemStWork);

            //    deleteFilter = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11}",
            //                                  ct_COL_SECTIONCODE.ToString(), sectionCode.Trim(),
            //                                  ct_COL_CUSTOMERCODE.ToString(), customerCode,
            //                                  ct_COL_GOODSMGROUP.ToString(), goodsMGroup,
            //                                  ct_COL_BLGOODSCODE.ToString(), blCode,
            //                                  ct_COL_GOODSMAKERCD.ToString(), makerCode,
            //                                  ct_COL_NEWADDROWDIV.ToString(), (int)NewAddRowDiv.New
            //                                );
            //    status = LogicalDeleteFilter(deleteFilter, out deleteAutoAnsItemStWork);

            //    foreach (DataRow dr in OfferPrimeSettingDataView.Table.Select(filter))
            //    {
            //        // 行追加処理
            //        DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
            //        AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
            //        // 初期値設定
            //        newRetWork.SectionCode = sectionCode;
            //        newRetWork.SectionNm = deleteAutoAnsItemStWork.SectionNm;
            //        newRetWork.CustomerCode = customerCode;
            //        newRetWork.CustomerName = deleteAutoAnsItemStWork.CustomerName;
            //        newRetWork.GoodsMakerCd = makerCode;
            //        newRetWork.MakerName = deleteAutoAnsItemStWork.MakerName;
            //        newRetWork.GoodsMGroup = goodsMGroup;
            //        newRetWork.GoodsMGroupName = deleteAutoAnsItemStWork.GoodsMGroupName;
            //        newRetWork.BLGoodsCode = blCode;
            //        newRetWork.BLGoodsName = deleteAutoAnsItemStWork.BLGoodsName;
            //        newRetWork.PrmSetDtlNo2 = int.Parse(dr[PrimeSettingInfo.COL_PRIMEKINDCODE].ToString());
            //        newRetWork.PrmSetDtlName2 = dr[PrimeSettingInfo.COL_PRIMEKINDNAME].ToString();

            //        CopyToDataRowFromAutoAnsItemStWork(ref newRow, newRetWork);

            //        // 行挿入なので入力済みの新規追加行とする


            //        newRow[ct_COL_NEWADDROWALLOWSAVE] = NewAddRowAllowSave.Yes;
            //        newRow[ct_COL_NEWADDROWDIV] = NewAddRowDiv.New;
            //        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //        // newRow[ct_COL_SECTIONCODE_SORT] = GetSortValue(sectionCode); // 拠点コード
            //        // 編集中の新規追加行は下から２番目に表示
            //        newRow[ct_COL_SECTIONCODE_SORT] = "YY"; // 拠点コード
            //        // UPD 2012/11/16 T.Yoshioka 2012/12/12配信 システムテスト障害№36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //        newRow[ct_COL_CUSTOMERCODE_SORT] = Int32.MaxValue; // 得意先コード ※最下行に表示するためMAX値を設定する
            //        _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);
            //    }
            //    // 新規入力行追加
            //    RowAdd();
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            #endregion
            // --- DEL 2012/11/22 吉岡 2012/12/12配信分 システムテスト障害№77 ---------<<<<<<<<<<<<<<<<<<<<<<


            // テーブル更新後イベント
            if (AfterTableUpdate != null)
            {
                AfterTableUpdate(this, new EventArgs());
            }

            return status;
        }

        #endregion

        #region ユーティリティ
        /// <summary>
        /// 整数値を想定するオブジェクトの整数値へのキャスト
        /// NULLであれば0を返す
        /// </summary>
        /// <param name="target">キャスト対象</param>
        /// <returns>Int型</returns>
        /// <remarks>
        /// <br>Note        : キャスト対象をInt型に変換します。</br>
        /// </remarks>
        private int IntObjToInt(object target)
        {
            if ((target == DBNull.Value) || (target == null) || (target.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (int)target;
            }
        }
        #endregion

    }
}
