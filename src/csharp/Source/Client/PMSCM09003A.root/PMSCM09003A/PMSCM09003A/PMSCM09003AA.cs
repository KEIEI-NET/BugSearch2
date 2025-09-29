//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM品目設定マスタメンテナンス
// プログラム概要   : SCM品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 修 正 日  2009/07/14  修正内容 : サーバ対応(LoginInfoAcquisition.Employee.BelongSectionCodeは使用不可)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/04/12  修正内容 : 速度改良
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ＳＣＭ品目設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＳＣＭ品目設定マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009/05/11</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class SCMPrtSettingAcs
    {
        #region public const
        //----------------------------------------
        // SCM品目設定マスタ定数定義
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
        /// <summary>商品番号</summary>
        public const string ct_COL_GOODSNO = "GoodsNo";
        /// <summary>自動回答区分</summary>
        public const string ct_COL_AUTOANSWERDIV = "AutoAnswerDiv";

        /// <summary>自動回答区分(前回退避)</summary>
        public const string ct_COL_AUTOANSWERDIV_BACKUP = "AutoAnswerDiv_Backup";

        /// <summary>拠点名称</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>得意先名称</summary>
        public const string ct_COL_CUSTOMERNAME = "CustomerName";
        /// <summary>商品中分類名称</summary>
        public const string ct_COL_GOODSMGROUPNAME = "GoodsMGroupName";
        /// <summary>BLグループ名称</summary>
        public const string ct_COL_BLGROUPNAME = "BLGroupName";
        /// <summary>BL商品コード名称</summary>
        public const string ct_COL_BLGOODSNAME = "BLGoodsName";
        /// <summary>メーカー名称</summary>
        public const string ct_COL_MAKERNAME = "MakerName";
        /// <summary>商品名称</summary>
        public const string ct_COL_GOODSNAME = "GoodsName";
        /// <summary>仕入先コード</summary>
        public const string ct_COL_SUPPLIERCD = "SupplierCd";
        /// <summary>仕入先略称</summary>
        public const string ct_COL_SUPPLIERSNM = "SupplierSnm";

        /// <summary>BLグループコード</summary>
        public const string ct_COL_BLGROUPCODE = "BLGroupCode";

        # region [ソート用]
        /// <summary>拠点コード</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>得意先コード</summary>
        public const string ct_COL_CUSTOMERCODE_SORT = "CustomerCode_Sort";
        /// <summary>仕入先コード</summary>
        public const string ct_COL_SUPPLIERCD_SORT = "SupplierCd_Sort";
        /// <summary>商品メーカーコード</summary>
        public const string ct_COL_GOODSMAKERCD_SORT = "GoodsMakerCd_Sort";
        /// <summary>商品中分類コード</summary>
        public const string ct_COL_GOODSMGROUP_SORT = "GoodsMGroup_Sort";
        /// <summary>BLグループコード</summary>
        public const string ct_COL_BLGROUPCODE_SORT = "BLGroupCode_Sort";
        /// <summary>BL商品コード</summary>
        public const string ct_COL_BLGOODSCODE_SORT = "BLGoodsCode_Sort";
        # endregion

        /// <summary>論理削除日(表示用)</summary>
        public const string ct_COL_LOGICALDELETEDATE = "LogicalDeleteDate";
        /// <summary>SCM品目設定マスタworkオブジェクト(内部保持用)</summary>
        public const string ct_COL_SCMPRTSETTINGWORKOBJECT = "SCMPrtSettingWorkObject";
        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public object _SCMPrtSetingWorkList = null; // SCM品目設定リモート
        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<




        // テーブル名
        /// <summary>SCM品目設定テーブル</summary>
        public const string ct_TABLE_SCMPRTSETTING = "SCMPrtSettingTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // プライベートメンバー
        // ===================================================================================== //
        // リモートオブジェクト格納バッファ
        private ISCMPrtSettingDB _iSCMPrtSetingDB = null; // SCM品目設定リモート

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        private GoodsAcs _goodsAcs;

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

        #region Construcstor
        /// <summary>
        /// SCM品目設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM品目設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public SCMPrtSettingAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iSCMPrtSetingDB = (ISCMPrtSettingDB)MediationSCMPrtSettingDB.GetSCMPrtSettingDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSCMPrtSetingDB = null;
            }

            // 論理削除除外する
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// SCM品目設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM品目設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30434 鈴木</br>
        /// <br>Date       : 2009/07/14</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public SCMPrtSettingAcs(string enterpriseCode, string sectionCode) : this()
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSCMPrtSetingDB == null)
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
                _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Clear();
            }
        }

        /// <summary>
        /// 優先順位付きSCM品目設定マスタ複数検索処理（論理削除含まない）SCM品目設定マスメン以外用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        public int Search(SCMPrtSettingOrder paraData, out List<SCMPrtSetting> retList, out string message)
        {
            // 1パラ目
            SCMPrtSettingOrder searchingByLump = new SCMPrtSettingOrder();
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
            List<SCMPrtSetting> firstSearchedList = null;
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority1(scmPrtSetting, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位1:得意先(={0})＋メーカー(={1})＋品番(={2}) で検索されました。",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd,
                        paraData.GoodsNo
                    );
                    return status;
                }

                #endregion

                #region 優先順位2:得意先＋メーカー＋BLコード

                retList = firstSearchedList.FindAll(
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority2(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority3(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority4(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority5(scmPrtSetting, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "優先順位5:拠点(={0})＋メーカー(={1})＋品番(={2}) で検索されました。",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd,
                        paraData.GoodsNo
                    );
                    return status;
                }

                #endregion

                #region 優先順位6:拠点＋メーカー＋BLコード

                retList = firstSearchedList.FindAll(
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority6(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority7(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority8(scmPrtSetting, paraData);
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
        /// 優先順位1:得意先＋メーカー＋品番であるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位1です。<br/>
        /// <c>false</c>:優先順位1ではありません。
        /// </returns>
        private static bool IsPriority1(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsNo.Equals(scmPrtSettingOrder.GoodsNo)
            );
        }

        /// <summary>
        /// 優先順位2:得意先＋メーカー＋BLコードであるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位2です。<br/>
        /// <c>false</c>:優先順位2ではありません。
        /// </returns>
        private static bool IsPriority2(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.BLGoodsCode >= scmPrtSettingOrder.St_BLGoodsCode
                    &&
                scmPrtSetting.BLGoodsCode <= scmPrtSettingOrder.Ed_BLGoodsCode
            );
        }

        /// <summary>
        /// 優先順位3:得意先＋メーカー＋中分類コードであるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位3です。<br/>
        /// <c>false</c>:優先順位3ではありません。
        /// </returns>
        private static bool IsPriority3(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMGroup >= scmPrtSettingOrder.St_GoodsMGroup
                    &&
                scmPrtSetting.GoodsMGroup <= scmPrtSettingOrder.Ed_GoodsMGroup
            );
        }

        /// <summary>
        /// 優先順位4:得意先＋メーカーであるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位4です。<br/>
        /// <c>false</c>:優先順位4ではありません。
        /// </returns>
        private static bool IsPriority4(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            if (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
            )
            {
                return scmPrtSetting.GoodsMGroup.Equals(0) && scmPrtSetting.BLGoodsCode.Equals(0) && string.IsNullOrEmpty(scmPrtSetting.GoodsNo.Trim());
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 優先順位5:拠点＋メーカー＋品番であるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位5です。<br/>
        /// <c>false</c>:優先順位5ではありません。
        /// </returns>
        private static bool IsPriority5(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsNo.Equals(scmPrtSettingOrder.GoodsNo)
            );
        }

        /// <summary>
        /// 優先順位6:拠点＋メーカー＋BLコードであるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位6です。<br/>
        /// <c>false</c>:優先順位6ではありません。
        /// </returns>
        private static bool IsPriority6(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.BLGoodsCode >= scmPrtSettingOrder.St_BLGoodsCode
                    &&
                scmPrtSetting.BLGoodsCode <= scmPrtSettingOrder.Ed_BLGoodsCode
            );
        }

        /// <summary>
        /// 優先順位7:拠点＋メーカー＋中分類コードであるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位7です。<br/>
        /// <c>false</c>:優先順位7ではありません。
        /// </returns>
        private static bool IsPriority7(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMGroup >= scmPrtSettingOrder.St_GoodsMGroup
                    &&
                scmPrtSetting.GoodsMGroup <= scmPrtSettingOrder.Ed_GoodsMGroup
            );
        }

        /// <summary>
        /// 優先順位8:拠点＋メーカーであるか判断します。
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目区設定</param>
        /// <param name="scmPrtSettingOrder">SCM品目区設定条件</param>
        /// <returns>
        /// <c>true</c> :優先順位8です。<br/>
        /// <c>false</c>:優先順位8ではありません。
        /// </returns>
        private static bool IsPriority8(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            if (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
            )
            {
                return scmPrtSetting.GoodsMGroup.Equals(0) && scmPrtSetting.BLGoodsCode.Equals(0) && string.IsNullOrEmpty(scmPrtSetting.GoodsNo.Trim());
            }
            else
            {
                return false;
            }
        }

        #endregion // 優先順位の判断

        /// <summary>
        /// SCM品目設定マスタ複数検索処理（論理削除含まない）SCM品目設定マスメン以外用
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="scmPrtSettingList">SCM品目設定オブジェクトリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定マスタリストの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.02.11</br>
        /// </remarks>
        private int SearchSimply( SCMPrtSettingOrder paraData, out List<SCMPrtSetting> retList, out string message )
        {
            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //パラメータの仕入先コードが0の場合は商品マスタアクセスクラスは読み込まない
            if (paraData.St_SupplierCd != 0 || paraData.Ed_SupplierCd != 0)
            {
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (_goodsAcs == null)
              {
                  string msg;
                  _goodsAcs = new GoodsAcs(SectionCode);
                  _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
              }
            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            }
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 検索
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // 結果格納
            retList = new List<SCMPrtSetting>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is SCMPrtSettingWork )
                    {
                        SCMPrtSettingWork retWork = (obj as SCMPrtSettingWork);

                        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //パラメータの仕入先コードが0の場合は商品マスタアクセスクラスは読み込まない
                        if (paraData.St_SupplierCd != 0 || paraData.Ed_SupplierCd != 0)
                        {
                        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // 商品管理情報より仕入先を取得
                            GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );
                             
                            // 仕入先範囲判定
                            if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                                 (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                            {
                                continue;
                            }
                            // 値をセット
                            SCMPrtSetting scmPrtSetting = CopyToSCMPrtSettingFromSCMPrtSettingWork(retWork);
                            if (goodsUnitData != null)
                            {
                                scmPrtSetting.SupplierCd = goodsUnitData.SupplierCd;
                                scmPrtSetting.SupplierSnm = goodsUnitData.SupplierSnm;
                            }
                            retList.Add(scmPrtSetting);
                        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        }
                        else
                        {
                            // 値をセット
                            SCMPrtSetting scmPrtSetting = CopyToSCMPrtSettingFromSCMPrtSettingWork(retWork);
                            retList.Add(scmPrtSetting);
                        }
                        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
            _goodsAcs = null;
            this.Clear();
        }

        /// <summary>
        /// SCM品目設定マスタ複数検索処理（論理削除含まない）SCM品目設定マスメン用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( SCMPrtSettingOrder paraData, out string message )
        {
            if ( _goodsAcs == null )
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            }

            // 初期化/クリア
            this.Clear();

            // 検索
            ArrayList retWorkList;
            int status = SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message );

            // 結果格納
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is SCMPrtSettingWork )
                    {
                        SCMPrtSettingWork retWork = (obj as SCMPrtSettingWork);

                        // アクセスクラス内のDataTableに追加
                        DataRow row = this._dataTableList.Tables[ct_TABLE_SCMPRTSETTING].NewRow();

                        // 商品管理情報より仕入先を取得
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        // 仕入先範囲判定
                        if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                             (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                        {
                            continue;
                        }

                        // 値をセット
                        CopyToDataRowFromSCMPrtSettingWork( ref row, retWork, goodsUnitData );
                        _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Add( row );
                    }
                }
            }
            if ( _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }


            // テーブル更新後イベント
            if ( AfterTableUpdate != null )
            {
                AfterTableUpdate( this, new EventArgs() );
            }

            return status;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>SCM品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public SCMPrtSetting GetRecordForMaintenance( Guid guid )
        {
            SCMPrtSettingWork scmPrtSettingWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_SCMPRTSETTING] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromDataRow( view[0].Row );
                }
            }

            // 該当無しなら空データ
            if ( scmPrtSettingWork == null )
            {
                scmPrtSettingWork = new SCMPrtSettingWork();
            }

            return this.CopyToSCMPrtSettingFromSCMPrtSettingWork( scmPrtSettingWork );
        }
        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>SCM品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_SCMPRTSETTING] );
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
        /// 商品管理情報取得処理
        /// </summary>
        /// <param name="scmPrtSettngWork"></param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsMngInfo( SCMPrtSettingWork scmPrtSettngWork )
        {
            GoodsUnitData goodsUnitData;

            if (_goodsAcs == null)
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial(scmPrtSettngWork.EnterpriseCode, SectionCode.Trim(), out msg);
            }

            goodsUnitData = new GoodsUnitData();

            goodsUnitData.EnterpriseCode = scmPrtSettngWork.EnterpriseCode.Trim();
            goodsUnitData.SectionCode = scmPrtSettngWork.SectionCode.Trim();
            goodsUnitData.GoodsMakerCd = scmPrtSettngWork.GoodsMakerCd;
            goodsUnitData.GoodsMGroup = scmPrtSettngWork.GoodsMGroup;
            goodsUnitData.BLGoodsCode = scmPrtSettngWork.BLGoodsCode;
            goodsUnitData.GoodsNo = scmPrtSettngWork.GoodsNo.Trim();

            _goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            if (goodsUnitData.SupplierCd == 0)
            {
                goodsUnitData.EnterpriseCode = scmPrtSettngWork.EnterpriseCode.Trim();
                goodsUnitData.SectionCode = "00";
                goodsUnitData.GoodsMakerCd = scmPrtSettngWork.GoodsMakerCd;
                goodsUnitData.GoodsMGroup = scmPrtSettngWork.GoodsMGroup;
                goodsUnitData.BLGoodsCode = scmPrtSettngWork.BLGoodsCode;
                goodsUnitData.GoodsNo = scmPrtSettngWork.GoodsNo.Trim();

                _goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            }

            return goodsUnitData;
        }
        #endregion

        #region Write 書き込み処理
        /// <summary>
        /// 書き込み処理
        /// </summary>
        /// <param name="scmPrtSettingList">保存データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 書き込み処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public int Write(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraSCMPrtSettingList = new ArrayList();
                SCMPrtSettingWork scmPrtSettingWork = null;

                for ( int i = 0; i < scmPrtSettingList.Count; i++ )
                {
                    // クラスデータをワーククラスデータに変換
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting( (SCMPrtSetting)scmPrtSettingList[i] );
                    paraSCMPrtSettingList.Add( scmPrtSettingWork );
                }

                object paraObj = (object)paraSCMPrtSettingList;

                // 書き込み処理
                status = this._iSCMPrtSetingDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 正常更新

                    // DataTableを使用している場合のみ書き換えを行う
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
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
                this._iSCMPrtSetingDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        /// <summary>
        /// 更新件数の取得（内部DataTableより）
        /// </summary>
        /// <returns></returns>
        public int GetUpdateCountFromTable()
        {
            if ( _dataTableList != null )
            {
                DataView view = new DataView( _dataTableList.Tables[ct_TABLE_SCMPRTSETTING] );
                view.RowFilter = string.Format( "{0}<>{1}", ct_COL_AUTOANSWERDIV, ct_COL_AUTOANSWERDIV_BACKUP );

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
                ArrayList paraSCMPrtSettingList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows )
                {
                    // 変更有無チェック
                    if ( (int)row[ct_COL_AUTOANSWERDIV] == (int)row[ct_COL_AUTOANSWERDIV_BACKUP] )
                    {
                        // 変更可能な項目がSearch時と変わらないので対象外にする
                        continue;
                    }

                    SCMPrtSettingWork scmPrtSettingWork = CopyToSCMPrtSettingWorkFromDataRow( row );
                    paraSCMPrtSettingList.Add( scmPrtSettingWork );
                }
                // 変更有無チェック
                if ( paraSCMPrtSettingList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "更新対象のデータが存在しません";
                    return status;
                }

                object paraObj = (object)paraSCMPrtSettingList;


                // 書き込み処理
                status = this._iSCMPrtSetingDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 正常更新

                    // DataTableを使用している場合のみ書き換えを行う
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
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
                this._iSCMPrtSetingDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 内部データテーブル書き換え処理
        /// </summary>
        /// <param name="paraObj"></param>
        private void UpdateDataTable( object retObj )
        {
            if ( retObj is ArrayList )
            {
                foreach ( object obj in (retObj as ArrayList) )
                {
                    if ( obj is SCMPrtSettingWork )
                    {
                        SCMPrtSettingWork retWork = (SCMPrtSettingWork)obj;

                        DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        if ( row == null )
                        {
                            // 追加
                            row = _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].NewRow();
                            CopyToDataRowFromSCMPrtSettingWork( ref row, retWork, goodsUnitData );
                            _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Add( row );
                        }
                        else
                        {
                            // 更新
                            CopyToDataRowFromSCMPrtSettingWork( ref row, retWork, goodsUnitData );
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 内部データテーブル書き換え処理(物理削除後)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList scmPrtSettingWorkList )
        {
            foreach ( object obj in scmPrtSettingWorkList )
            {
                if ( obj is SCMPrtSettingWork )
                {
                    SCMPrtSettingWork retWork = (SCMPrtSettingWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // 削除
                        _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="scmPrtSettingList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraSCMPrtSettingList = new ArrayList();
                SCMPrtSettingWork scmPrtSettingWork = null;

                for (int i = 0; i < scmPrtSettingList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting((SCMPrtSetting)scmPrtSettingList[i]);

                    paraSCMPrtSettingList.Add(scmPrtSettingWork);
                }
                object paraObj = (object)paraSCMPrtSettingList;

                // 論理削除処理
                status = this._iSCMPrtSetingDB.LogicalDelete( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
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
                this._iSCMPrtSetingDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival 復旧処理
        /// <summary>
        /// 復旧処理
        /// </summary>
        /// <param name="scmPrtSettingList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Revival(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraSCMPrtSettingList = new ArrayList();
                SCMPrtSettingWork scmPrtSettingWork = null;

                for (int i = 0; i < scmPrtSettingList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting((SCMPrtSetting)scmPrtSettingList[i]);

                    paraSCMPrtSettingList.Add(scmPrtSettingWork);
                }

                object paraObj = (object)paraSCMPrtSettingList;

                // 書き込み処理
                status = this._iSCMPrtSetingDB.RevivalLogicalDelete(ref paraObj);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
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
                this._iSCMPrtSetingDB = null;
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
        /// <param name="scmPrtSettingList">削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理（物理削除）を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Delete(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraSCMPrtSettingWork = null;
                SCMPrtSettingWork scmPrtSettingWork = null;
                ArrayList scmPrtSettingWorkList = new ArrayList();	// ワーククラス格納用ArrayList

                // ワーククラス格納用ArrayListへ詰め替え
                for (int i = 0; i < scmPrtSettingList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting((SCMPrtSetting)scmPrtSettingList[i]);
                    scmPrtSettingWorkList.Add(scmPrtSettingWork);
                }
                // ArrayListから配列を生成
                SCMPrtSettingWork[] scmPrtSettingWorks = (SCMPrtSettingWork[])scmPrtSettingWorkList.ToArray(typeof(SCMPrtSettingWork));

                // シリアライズ
                paraSCMPrtSettingWork = XmlByteSerializer.Serialize(scmPrtSettingWorks);

                // 物理削除処理
                status = this._iSCMPrtSetingDB.Delete(paraSCMPrtSettingWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // テーブルから削除
                        DeleteFromDataTable( scmPrtSettingWorkList );
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
                this._iSCMPrtSetingDB = null;
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // SCM品目設定テーブル列定義
            //----------------------------------------------------------------
            DataTable scmPrtSettingTable = new DataTable( ct_TABLE_SCMPRTSETTING );


            // 作成日時
            scmPrtSettingTable.Columns.Add( ct_COL_CREATEDATETIME, typeof( DateTime ) );
            // 更新日時
            scmPrtSettingTable.Columns.Add( ct_COL_UPDATEDATETIME, typeof( DateTime ) );
            // 企業コード
            scmPrtSettingTable.Columns.Add( ct_COL_ENTERPRISECODE, typeof( string ) );
            // GUID
            scmPrtSettingTable.Columns.Add( ct_COL_FILEHEADERGUID, typeof( Guid ) );
            // 更新従業員コード
            scmPrtSettingTable.Columns.Add( ct_COL_UPDEMPLOYEECODE, typeof( string ) );
            // 更新アセンブリID1
            scmPrtSettingTable.Columns.Add( ct_COL_UPDASSEMBLYID1, typeof( string ) );
            // 更新アセンブリID2
            scmPrtSettingTable.Columns.Add( ct_COL_UPDASSEMBLYID2, typeof( string ) );
            // 論理削除区分
            scmPrtSettingTable.Columns.Add( ct_COL_LOGICALDELETECODE, typeof( Int32 ) );
            // 拠点コード
            scmPrtSettingTable.Columns.Add( ct_COL_SECTIONCODE, typeof( string ) );
            // 得意先コード
            scmPrtSettingTable.Columns.Add( ct_COL_CUSTOMERCODE, typeof( Int32 ) );
            // 商品中分類コード
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMGROUP, typeof( Int32 ) );
            // BL商品コード
            scmPrtSettingTable.Columns.Add( ct_COL_BLGOODSCODE, typeof( Int32 ) );
            // 商品メーカーコード
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMAKERCD, typeof( Int32 ) );
            // 商品番号
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSNO, typeof( string ) );
            // 自動回答区分
            scmPrtSettingTable.Columns.Add( ct_COL_AUTOANSWERDIV, typeof( Int32 ) );

            // 自動回答区分
            scmPrtSettingTable.Columns.Add( ct_COL_AUTOANSWERDIV_BACKUP, typeof( Int32 ) );

            // 拠点名称
            scmPrtSettingTable.Columns.Add( ct_COL_SECTIONNM, typeof( string ) );
            // 得意先名称
            scmPrtSettingTable.Columns.Add( ct_COL_CUSTOMERNAME, typeof( string ) );
            // 商品中分類名称
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMGROUPNAME, typeof( string ) );
            // BLグループ名称
            scmPrtSettingTable.Columns.Add( ct_COL_BLGROUPNAME, typeof( string ) );
            // BL商品コード名称
            scmPrtSettingTable.Columns.Add( ct_COL_BLGOODSNAME, typeof( string ) );
            // メーカー名称
            scmPrtSettingTable.Columns.Add( ct_COL_MAKERNAME, typeof( string ) );
            // 商品名称
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSNAME, typeof( string ) );
            // 仕入先コード
            scmPrtSettingTable.Columns.Add( ct_COL_SUPPLIERCD, typeof( Int32 ) );
            // 仕入先略称
            scmPrtSettingTable.Columns.Add( ct_COL_SUPPLIERSNM, typeof( string ) );

            // グループコード
            scmPrtSettingTable.Columns.Add( ct_COL_BLGROUPCODE, typeof( Int32 ) );

            # region [ソート用]
            // 拠点コード
            scmPrtSettingTable.Columns.Add( ct_COL_SECTIONCODE_SORT, typeof( string ) );
            // 得意先コード
            scmPrtSettingTable.Columns.Add( ct_COL_CUSTOMERCODE_SORT, typeof( Int32 ) );
            // 商品中分類コード
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMGROUP_SORT, typeof( Int32 ) );
            // BL商品コード
            scmPrtSettingTable.Columns.Add( ct_COL_BLGOODSCODE_SORT, typeof( Int32 ) );
            // 商品メーカーコード
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMAKERCD_SORT, typeof( Int32 ) );
            // 仕入先コード
            scmPrtSettingTable.Columns.Add( ct_COL_SUPPLIERCD_SORT, typeof( Int32 ) );
            // グループコード
            scmPrtSettingTable.Columns.Add( ct_COL_BLGROUPCODE_SORT, typeof( Int32 ) );
            # endregion


            // 論理削除日(表示用)
            scmPrtSettingTable.Columns.Add( ct_COL_LOGICALDELETEDATE, typeof( string ) );
            // オブジェクト(内部保持用)
            scmPrtSettingTable.Columns.Add( ct_COL_SCMPRTSETTINGWORKOBJECT, typeof( SCMPrtSettingWork ) );

            this._dataTableList.Tables.Add(scmPrtSettingTable);

            //----------------------------------------------------------------
            // データビュー生成
            //----------------------------------------------------------------
            this._dataView = new DataView( scmPrtSettingTable );
            this._dataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                                                ct_COL_SECTIONCODE_SORT,
                                                ct_COL_CUSTOMERCODE_SORT,
                                                ct_COL_SUPPLIERCD_SORT,
                                                ct_COL_GOODSMAKERCD_SORT,
                                                ct_COL_GOODSMGROUP_SORT,
                                                ct_COL_BLGROUPCODE_SORT,
                                                ct_COL_BLGOODSCODE_SORT,
                                                ct_COL_GOODSNO 
                                                );
        }
        #endregion

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバーコピー処理（SCM品目設定クラス⇒SCM品目設定ワーククラス）
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目設定クラス</param>
        /// <returns>SCMPrtSettingWork</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定クラスからSCM品目設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private SCMPrtSettingWork CopyToSCMPrtSettingWorkFromSCMPrtSetting(SCMPrtSetting scmPrtSetting)
        {
            SCMPrtSettingWork scmPrtSettingWork = new SCMPrtSettingWork();

            scmPrtSettingWork.CreateDateTime = scmPrtSetting.CreateDateTime; // 作成日時
            scmPrtSettingWork.UpdateDateTime = scmPrtSetting.UpdateDateTime; // 更新日時
            scmPrtSettingWork.EnterpriseCode = scmPrtSetting.EnterpriseCode; // 企業コード
            scmPrtSettingWork.FileHeaderGuid = scmPrtSetting.FileHeaderGuid; // GUID
            scmPrtSettingWork.UpdEmployeeCode = scmPrtSetting.UpdEmployeeCode; // 更新従業員コード
            scmPrtSettingWork.UpdAssemblyId1 = scmPrtSetting.UpdAssemblyId1; // 更新アセンブリID1
            scmPrtSettingWork.UpdAssemblyId2 = scmPrtSetting.UpdAssemblyId2; // 更新アセンブリID2
            scmPrtSettingWork.LogicalDeleteCode = scmPrtSetting.LogicalDeleteCode; // 論理削除区分
            scmPrtSettingWork.SectionCode = scmPrtSetting.SectionCode; // 拠点コード
            scmPrtSettingWork.CustomerCode = scmPrtSetting.CustomerCode; // 得意先コード
            scmPrtSettingWork.GoodsMGroup = scmPrtSetting.GoodsMGroup; // 商品中分類コード
            scmPrtSettingWork.BLGroupCode = scmPrtSetting.BLGroupCode; // BLグループコード
            scmPrtSettingWork.BLGoodsCode = scmPrtSetting.BLGoodsCode; // BL商品コード
            scmPrtSettingWork.GoodsMakerCd = scmPrtSetting.GoodsMakerCd; // 商品メーカーコード
            scmPrtSettingWork.GoodsNo = scmPrtSetting.GoodsNo; // 商品番号
            scmPrtSettingWork.AutoAnswerDiv = scmPrtSetting.AutoAnswerDiv; // 自動回答区分
            scmPrtSettingWork.SectionNm = scmPrtSetting.SectionNm; // 拠点名称
            scmPrtSettingWork.CustomerName = scmPrtSetting.CustomerName; // 得意先名称
            scmPrtSettingWork.GoodsMGroupName = scmPrtSetting.GoodsMGroupName; // 商品中分類名称
            scmPrtSettingWork.BLGroupName = scmPrtSetting.BLGroupName; // BLグループ名称
            scmPrtSettingWork.BLGoodsName = scmPrtSetting.BLGoodsName; // BL商品コード名称
            scmPrtSettingWork.MakerName = scmPrtSetting.MakerName; // メーカー名称
            scmPrtSettingWork.GoodsName = scmPrtSetting.GoodsName; // 商品名称
            //scmPrtSettingWork.SupplierCd = scmPrtSetting.SupplierCd; // 仕入先コード
            //scmPrtSettingWork.SupplierSnm = scmPrtSetting.SupplierSnm; // 仕入先略称

            return scmPrtSettingWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（SCM品目設定ワーククラス⇒SCM品目設定クラス）
        /// </summary>
        /// <param name="scmPrtSettingWork">SCM品目設定ワーククラス</param>
        /// <returns>SCMPrtSetting</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定ワーククラスからSCM品目設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private SCMPrtSetting CopyToSCMPrtSettingFromSCMPrtSettingWork(SCMPrtSettingWork scmPrtSettingWork)
        {
            SCMPrtSetting scmPrtSetting = new SCMPrtSetting();

            scmPrtSetting.CreateDateTime = scmPrtSettingWork.CreateDateTime; // 作成日時
            scmPrtSetting.UpdateDateTime = scmPrtSettingWork.UpdateDateTime; // 更新日時
            scmPrtSetting.EnterpriseCode = scmPrtSettingWork.EnterpriseCode; // 企業コード
            scmPrtSetting.FileHeaderGuid = scmPrtSettingWork.FileHeaderGuid; // GUID
            scmPrtSetting.UpdEmployeeCode = scmPrtSettingWork.UpdEmployeeCode; // 更新従業員コード
            scmPrtSetting.UpdAssemblyId1 = scmPrtSettingWork.UpdAssemblyId1; // 更新アセンブリID1
            scmPrtSetting.UpdAssemblyId2 = scmPrtSettingWork.UpdAssemblyId2; // 更新アセンブリID2
            scmPrtSetting.LogicalDeleteCode = scmPrtSettingWork.LogicalDeleteCode; // 論理削除区分
            scmPrtSetting.SectionCode = scmPrtSettingWork.SectionCode; // 拠点コード
            scmPrtSetting.CustomerCode = scmPrtSettingWork.CustomerCode; // 得意先コード
            scmPrtSetting.GoodsMGroup = scmPrtSettingWork.GoodsMGroup; // 商品中分類コード
            scmPrtSetting.BLGroupCode = scmPrtSettingWork.BLGroupCode; // BLグループコード
            scmPrtSetting.BLGoodsCode = scmPrtSettingWork.BLGoodsCode; // BL商品コード
            scmPrtSetting.GoodsMakerCd = scmPrtSettingWork.GoodsMakerCd; // 商品メーカーコード
            scmPrtSetting.GoodsNo = scmPrtSettingWork.GoodsNo; // 商品番号
            scmPrtSetting.AutoAnswerDiv = scmPrtSettingWork.AutoAnswerDiv; // 自動回答区分
            scmPrtSetting.SectionNm = scmPrtSettingWork.SectionNm; // 拠点名称
            scmPrtSetting.CustomerName = scmPrtSettingWork.CustomerName; // 得意先名称
            scmPrtSetting.GoodsMGroupName = scmPrtSettingWork.GoodsMGroupName; // 商品中分類名称
            scmPrtSetting.BLGroupName = scmPrtSettingWork.BLGroupName; // BLグループ名称
            scmPrtSetting.BLGoodsName = scmPrtSettingWork.BLGoodsName; // BL商品コード名称
            scmPrtSetting.MakerName = scmPrtSettingWork.MakerName; // メーカー名称
            scmPrtSetting.GoodsName = scmPrtSettingWork.GoodsName; // 商品名称
            //scmPrtSetting.SupplierCd = scmPrtSettingWork.SupplierCd; // 仕入先コード
            //scmPrtSetting.SupplierSnm = scmPrtSettingWork.SupplierSnm; // 仕入先略称

            return scmPrtSetting;
        }

        /// <summary>
        /// クラスメンバーコピー処理（SCM品目設定クラス⇒DataRow）
        /// </summary>
        /// <param name="scmPrtSettingWork">SCM品目設定クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定ワーククラスからSCM品目設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void CopyToDataRowFromSCMPrtSettingWork( ref DataRow dr, SCMPrtSettingWork scmPrtSettingWork, GoodsUnitData goodsUnitData )
        {
            # region [dr←scmPrtSetting]
            dr[ct_COL_CREATEDATETIME] = scmPrtSettingWork.CreateDateTime; // 作成日時
            dr[ct_COL_UPDATEDATETIME] = scmPrtSettingWork.UpdateDateTime; // 更新日時
            dr[ct_COL_ENTERPRISECODE] = scmPrtSettingWork.EnterpriseCode; // 企業コード
            dr[ct_COL_FILEHEADERGUID] = scmPrtSettingWork.FileHeaderGuid; // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = scmPrtSettingWork.UpdEmployeeCode; // 更新従業員コード
            dr[ct_COL_UPDASSEMBLYID1] = scmPrtSettingWork.UpdAssemblyId1; // 更新アセンブリID1
            dr[ct_COL_UPDASSEMBLYID2] = scmPrtSettingWork.UpdAssemblyId2; // 更新アセンブリID2
            dr[ct_COL_LOGICALDELETECODE] = scmPrtSettingWork.LogicalDeleteCode; // 論理削除区分
            dr[ct_COL_SECTIONCODE] = scmPrtSettingWork.SectionCode; // 拠点コード
            dr[ct_COL_CUSTOMERCODE] = scmPrtSettingWork.CustomerCode; // 得意先コード
            dr[ct_COL_GOODSMGROUP] = scmPrtSettingWork.GoodsMGroup; // 商品中分類コード
            dr[ct_COL_BLGOODSCODE] = scmPrtSettingWork.BLGoodsCode; // BL商品コード
            dr[ct_COL_GOODSMAKERCD] = scmPrtSettingWork.GoodsMakerCd; // 商品メーカーコード
            dr[ct_COL_GOODSNO] = scmPrtSettingWork.GoodsNo; // 商品番号
            dr[ct_COL_AUTOANSWERDIV] = scmPrtSettingWork.AutoAnswerDiv; // 自動回答区分
            dr[ct_COL_AUTOANSWERDIV_BACKUP] = scmPrtSettingWork.AutoAnswerDiv; // 自動回答区分(前回値退避)

            // 論理削除日(表示用)
            if ( scmPrtSettingWork.LogicalDeleteCode == 0 )
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString( "ggYY/MM/DD", scmPrtSettingWork.UpdateDateTime );
            }

            dr[ct_COL_SECTIONNM] = scmPrtSettingWork.SectionNm; // 拠点名称
            dr[ct_COL_CUSTOMERNAME] = scmPrtSettingWork.CustomerName; // 得意先名称
            dr[ct_COL_GOODSMGROUPNAME] = scmPrtSettingWork.GoodsMGroupName; // 商品中分類名称
            dr[ct_COL_BLGROUPNAME] = scmPrtSettingWork.BLGroupName; // BLグループ名称
            dr[ct_COL_BLGOODSNAME] = scmPrtSettingWork.BLGoodsName; // BL商品コード名称
            dr[ct_COL_MAKERNAME] = scmPrtSettingWork.MakerName; // メーカー名称
            dr[ct_COL_GOODSNAME] = scmPrtSettingWork.GoodsName; // 商品名称
            dr[ct_COL_BLGROUPCODE] = scmPrtSettingWork.BLGroupCode; // BLグループコード

            // 商品情報からセットする
            dr[ct_COL_SUPPLIERCD] = goodsUnitData.SupplierCd; // 仕入先コード
            dr[ct_COL_SUPPLIERSNM] = goodsUnitData.SupplierSnm; // 仕入先略称

            // ソート用カラム
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue( scmPrtSettingWork.SectionCode ); // 拠点コード
            dr[ct_COL_CUSTOMERCODE_SORT] = GetSortValue( scmPrtSettingWork.CustomerCode ); // 得意先コード
            dr[ct_COL_SUPPLIERCD_SORT] = GetSortValue( goodsUnitData.SupplierCd ); // 仕入先コード
            dr[ct_COL_GOODSMAKERCD_SORT] = GetSortValue( scmPrtSettingWork.GoodsMakerCd ); // 商品メーカーコード
            dr[ct_COL_GOODSMGROUP_SORT] = GetSortValue( scmPrtSettingWork.GoodsMGroup ); // 商品中分類コード
            dr[ct_COL_BLGROUPCODE_SORT] = GetSortValue( scmPrtSettingWork.BLGroupCode ); // BLグループコード
            dr[ct_COL_BLGOODSCODE_SORT] = GetSortValue( scmPrtSettingWork.BLGoodsCode ); // BL商品コード

            // オブジェクト(内部保持用)
            dr[ct_COL_SCMPRTSETTINGWORKOBJECT] = scmPrtSettingWork;
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
        /// クラスメンバーコピー処理（DataRow⇒SCM品目設定クラス）
        /// </summary>
        /// <param name="row"></param>
        /// <returns>SCMPrtSettingWork</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定ワーククラスからSCM品目設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private SCMPrtSettingWork CopyToSCMPrtSettingWorkFromDataRow( DataRow row )
        {
            SCMPrtSettingWork scmPrtSettingWork = (SCMPrtSettingWork)row[ct_COL_SCMPRTSETTINGWORKOBJECT];
            
            // 書き換え可能項目のみ差し替える
            scmPrtSettingWork.AutoAnswerDiv = (int)row[ct_COL_AUTOANSWERDIV];

            return scmPrtSettingWork;
        }

        /// <summary>
        /// 抽出条件クラスメンバーコピー処理
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private SCMPrtSettingOrderWork CopyToSCMPrtSettingOrderWorkFromSCMPrtSettingOrder( SCMPrtSettingOrder paraData )
        {
            SCMPrtSettingOrderWork paraWork = new SCMPrtSettingOrderWork();
            
            # region [paraWork←paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;  // 企業コード
            paraWork.SectionCode = paraData.SectionCode;  // 拠点コード
            paraWork.St_CustomerCode = paraData.St_CustomerCode;  // 開始得意先コード
            paraWork.Ed_CustomerCode = paraData.Ed_CustomerCode;  // 終了得意先コード
            //paraWork.St_SupplierCd = paraData.St_SupplierCd;  // 開始仕入先コード
            //paraWork.Ed_SupplierCd = paraData.Ed_SupplierCd;  // 終了仕入先コード
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
        /// <param name="scmPrtSettingList">SCM品目設定オブジェクトリスト</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : SCM品目設定マスタの複数検索処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int SearchProc( SCMPrtSettingOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (_SCMPrtSetingWorkList != null)
            {
                retWorkList = (ArrayList)_SCMPrtSetingWorkList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                try
                {
                    //ArrayList paraList = new ArrayList();
                    //==========================================
                    // SCM品目設定マスタ読み込み
                    //==========================================
                    SCMPrtSettingOrderWork paraWork = CopyToSCMPrtSettingOrderWorkFromSCMPrtSettingOrder(paraData);

                    // リモート戻りリスト
                    object scmPrtSettingWorkList = null;
                    // SCM品目設定マスタ検索
                    status = this._iSCMPrtSetingDB.Search(out scmPrtSettingWorkList, paraWork, 0, logicalMode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retWorkList = (ArrayList)scmPrtSettingWorkList;
                        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        _SCMPrtSetingWorkList = (ArrayList)scmPrtSettingWorkList;
                        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            }
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return status;
        }
        #endregion

        #region Read 検索処理
        /// <summary>
        /// SCM品目設定レコード取得処理
        /// </summary>
        /// <param name="scmPrtSetting">SCM品目設定データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。
        ///                  scmPrtSettingクラスに検索データを設定し、結果もscmPrtSettingクラスに格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public int Read(ref SCMPrtSetting scmPrtSetting)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // 抽出条件パラメータ
                SCMPrtSettingWork scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting( scmPrtSetting );

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize( scmPrtSettingWork );
                status = this._iSCMPrtSetingDB.Read( ref parabyte, 0 );

                if (status == 0)
                {
                    // XMLの読み込み
                    scmPrtSettingWork = (SCMPrtSettingWork)XmlByteSerializer.Deserialize( parabyte, typeof( SCMPrtSettingWork ) );
                }

                if (status == 0)
                {
                    // クラス内メンバコピー
                    scmPrtSetting = CopyToSCMPrtSettingFromSCMPrtSettingWork( scmPrtSettingWork );
                }

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                scmPrtSetting = null;
                //オフライン時はnullをセット
                this._iSCMPrtSetingDB = null;
                return -1;
            }
        }
        #endregion
    }
}
