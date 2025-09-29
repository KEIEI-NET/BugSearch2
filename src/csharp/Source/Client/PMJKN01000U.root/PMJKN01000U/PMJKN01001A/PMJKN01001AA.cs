using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由検索部品自動登録アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品自動登録選択ＵＩの制御を行います。</br>
    /// <br>           : （このアクセスクラスでは登録確認・選択の制御のみ行い、実際の登録はIOWriterから専用Rを呼び出します）</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/13</br>
    /// <br></br>
    /// </remarks>
    public partial class AutoEntryFreeSearchPartsAcs
    {
        # region [フィールド]
        private static AutoEntryFreeSearchPartsAcs stc_AutoEntryFreeSearchPartsAcs;
        private IFreeSearchPartsSearchDB iFreeSearchPartsSearchDB;
        private AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable _autoEntryFSPartsDataTable;
        private AutoEntryFreeSearchPartsDataSet.CarModelDataTable _carModelDataTable;
        # endregion

        # region [プロパティ]
        /// <summary>
        /// 自由検索部品自動登録テーブル
        /// </summary>
        public AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable AutoEntryFSPartsDataTable
        {
            get 
            {
                if ( _autoEntryFSPartsDataTable == null )
                {
                    _autoEntryFSPartsDataTable = new AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable();
                }
                return _autoEntryFSPartsDataTable; 
            }
        }
        /// <summary>
        /// 自由検索部品自動登録 型式情報テーブル
        /// </summary>
        public AutoEntryFreeSearchPartsDataSet.CarModelDataTable CarModelDataTable
        {
            get 
            {
                if ( _carModelDataTable == null )
                {
                    _carModelDataTable = new AutoEntryFreeSearchPartsDataSet.CarModelDataTable();
                }
                return _carModelDataTable; 
            }
        }
        # endregion

        # region [コンストラクタ類]
        /// <summary>
        /// private コンストラクタ
        /// </summary>
        private AutoEntryFreeSearchPartsAcs()
        {
        }
        /// <summary>
        /// public static コンストラクタ
        /// </summary>
        static AutoEntryFreeSearchPartsAcs()
        {
        }
        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns></returns>
        public static AutoEntryFreeSearchPartsAcs GetInsctance()
        {
            if ( stc_AutoEntryFreeSearchPartsAcs == null )
            {
                stc_AutoEntryFreeSearchPartsAcs = new AutoEntryFreeSearchPartsAcs();
            }
            return stc_AutoEntryFreeSearchPartsAcs;
        }
        # endregion

        # region [publicメソッド]
        /// <summary>
        /// データ保持テーブルのクリア
        /// </summary>
        public void ClearTables()
        {
            // NULLをセット⇒プロパティのgetで新規インスタンスが生成される
            _autoEntryFSPartsDataTable = null;
            _carModelDataTable = null;
        }
        /// <summary>
        /// 明細毎の自動登録対象フル型式リスト取得処理
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        /// <returns></returns>
        public string[] GetCarModelsForAutoEntryFreeSearchParts( Guid dtlRelationGuid )
        {
            //---------------------------------------------------------------
            // [エントリ入力イメージ]
            //
            // XX-XXX-XXXX, YY-YYY-YYYY
            //   hinban1 0001
            //   hinban2 0001
            // ZZ-ZZZ-ZZZZ
            //   hinban3 0001
            //
            // ↓
            //
            // [返却結果イメージ]
            //
            // hinban1 0001 … XX-XXX-XXXX, YY-YYY-YYYY
            // hinban2 0001 … XX-XXX-XXXX, YY-YYY-YYYY
            // hinban3 0001 … ZZ-ZZZ-ZZZZ
            //
            //---------------------------------------------------------------
            List<string> carModelList = new List<string>();

            // 指定のGUIDと合致し、かつ選択ＵＩでチェックが付けられた行を取得
            AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[] targetRows
                = (AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[])AutoEntryFSPartsDataTable.Select(
                    string.Format( "{0}='{1}' AND {2}='{3}'",
                        AutoEntryFSPartsDataTable.DtlRelationGuidColumn.ColumnName, dtlRelationGuid,
                        AutoEntryFSPartsDataTable.CheckedColumn.ColumnName, true
                    ) 
                  );

            // 該当の商品のフル型式をリスト化する
            foreach ( AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow fsPartsRow in targetRows )
            {
                carModelList.Add( fsPartsRow.FullModel );
            }

            // 結果の返却
            if ( carModelList.Count == 0 )
            {
                return null;
            }
            return carModelList.ToArray();
        }
        /// <summary>
        /// 自由検索部品 存在チェック
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="carInfo"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        public bool CheckFreeSearchParts( string enterpriseCode, PMKEN01010E carInfo, int blGoodsCode, string goodsNo, int goodsMakerCd )
        {
            if ( iFreeSearchPartsSearchDB == null )
            {
                iFreeSearchPartsSearchDB = MediationFreeSearchPartsSearchDB.GetRemoteObject();
            }

            // 抽出条件のセット
            FreeSearchPartsSParaWork paraWork = new FreeSearchPartsSParaWork();
            # region [paraWorkをセット]
            // 部品情報の検索条件
            paraWork.EnterpriseCode = enterpriseCode.Trim();
            paraWork.TbsPartsCode = blGoodsCode;
            paraWork.TbsPartsCdDerivedNo = 0;
            paraWork.GoodsNo = goodsNo;
            paraWork.GoodsMakerCd = goodsMakerCd;

            List<FreeSearchPartsSMdlParaWork> fsPartsSModelsList = new List<FreeSearchPartsSMdlParaWork>();
            foreach ( PMKEN01010E.CarModelInfoRow carModelInfoRow in carInfo.CarModelInfo.Rows )
            {
                // 型式情報をリストに追加
                FreeSearchPartsSMdlParaWork modelParaWork = new FreeSearchPartsSMdlParaWork();
                modelParaWork.MakerCode = carModelInfoRow.MakerCode;
                modelParaWork.ModelCode = carModelInfoRow.ModelCode;
                modelParaWork.ModelSubCode = carModelInfoRow.ModelSubCode;
                modelParaWork.FullModel = carModelInfoRow.FullModel;
                fsPartsSModelsList.Add( modelParaWork );
            }
            paraWork.FSPartsSModels = fsPartsSModelsList.ToArray();
            # endregion

            // 自由検索部品検索
            object retObj = null;
            long retCount;
            int status = iFreeSearchPartsSearchDB.Search( paraWork, ref retObj, out retCount );

            // 結果返却
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retCount > 0 && retObj != null )
            {
                // 既存あり
                return true;
            }
            else
            {
                // なし
                return false;
            }
        }
        # endregion
    }
}