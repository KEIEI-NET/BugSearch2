using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 代替マスタ新旧関連表示アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       :  代替マスタ新旧関連のアクセスクラスです。<br />
    /// <br>Programmer : 30452 上野 俊治<br />
    /// <br>Date       : 2008.10.27<br />
    /// <br>Update Note: 2008.12.09 30452 上野 俊治</br>
    /// <br>            ・代替先検索でループする場合の対応を追加</br>
    /// </remarks>
    public class PartsSubstUSearchAcs
    {
        #region ■public定数
        public const string COL_ORDER_TITLE = "表示順位";
        public const string COL_CHGSRCGOODSNO_TITLE = "代替元品番";
        public const string COL_CHGDESTGOODSNO_TITLE = "代替先品番";
        public const string COL_MAKERCODE_TITLE = "メーカー";
        public const string COL_WAREHOUSECODE_TITLE = "倉庫";
        public const string COL_WAREHOUSESHELF_TITLE = "倉庫棚番";
        public const string COL_DUPLICATIONSHELF1_TITLE = "重複棚1";
        public const string COL_DUPLICATIONSHELF2_TITLE = "重複棚2";
        public const string COL_SHIPMENTPOSCNT_TITLE = "現在庫数";

        public const string TABLE_DESTPARTSSUBST = "DestPartsSubstTable";
        public const string TABLE_SRCPARTSSUBST = "SrcPartsSubstTable";

        #endregion 

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartsSubstUSearchAcs()
        {
        }
        #endregion

        #region ■publicメソッド
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="inParam"></param>
        /// <param name="outParam"></param>
        /// <param name="resultDataTable"></param>
        /// <returns></returns>
        public int Search(ArrayList inParam, ref ArrayList outParam, ref DataTable resultDataTable)
        {
            int status = 0;

            PartsSubstUSearchParamWork partsSubstUSearchParamWork = new PartsSubstUSearchParamWork();

            // リモート抽出条件設定
            partsSubstUSearchParamWork.EnterpriseCode = inParam[0].ToString();
            partsSubstUSearchParamWork.SearchDiv = (Int32)inParam[1];
            partsSubstUSearchParamWork.SectionCode = inParam[2].ToString();
            partsSubstUSearchParamWork.ChgSrcMakerCd = (Int32)inParam[3];
            partsSubstUSearchParamWork.ChgSrcGoodsNo = inParam[4].ToString();

            // 検索結果object
            object retObj;

            //検索処理実行
            IPartsSubstDspDB partsSubstDspDB = (IPartsSubstDspDB)MediationPartsSubstDspDB.GetPartsSubstDspDB();
            status = partsSubstDspDB.Search(out retObj, partsSubstUSearchParamWork);

            // テスト用
            //status = testProc(out retObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((ArrayList)retObj).Count != 0)
                {
                    // 検索結果展開
                    this.AddRowFromPartsSubstDspDB(retObj, ref outParam, ref resultDataTable, inParam);
                }
                else
                {
                    // 0件の場合、NotFoundエラーと同じにする
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }          

            return status;
        }
        #endregion

        #region ■privateメソッド
        /// <summary>
        /// 検索結果展開処理
        /// </summary>
        /// <param name="retObj">リモート抽出結果Object</param>
        /// <param name="resultDataSet">結果保持用DataSet</param>
        /// <param name="srcGoodsNo">抽出条件の品番</param>
        private void AddRowFromPartsSubstDspDB(object retObj, ref ArrayList outParam, ref DataTable resultDataTable, ArrayList inParam)
        {
            DataRow row;
            string goodsNo = inParam[4].ToString();
            int searchDiv= (Int32)inParam[1];


            foreach (PartsSubstUSearchResultWork partsSubstUSearchResultWork in (ArrayList)retObj)
            {
                // グリッド表示するテーブル情報を取得
                row = resultDataTable.NewRow();

                if (searchDiv == 0)
                {
                    // 代替先の場合
                    row[COL_CHGSRCGOODSNO_TITLE] = partsSubstUSearchResultWork.ChgSrcGoodsNo;
                    row[COL_CHGDESTGOODSNO_TITLE] = partsSubstUSearchResultWork.ChgDestGoodsNo;
                    row[COL_MAKERCODE_TITLE] = partsSubstUSearchResultWork.ChgDestMakerCd;
                    if (partsSubstUSearchResultWork.ChgDestWarehouseCode == string.Empty) row[COL_WAREHOUSECODE_TITLE] = string.Empty;
                    else row[COL_WAREHOUSECODE_TITLE] = partsSubstUSearchResultWork.ChgDestWarehouseCode.TrimEnd().PadLeft(4, '0');
                    row[COL_WAREHOUSESHELF_TITLE] = partsSubstUSearchResultWork.ChgDestWarehouseShelfNo;
                    row[COL_DUPLICATIONSHELF1_TITLE] = partsSubstUSearchResultWork.ChgDestDuplicationShelfNo1;
                    row[COL_DUPLICATIONSHELF2_TITLE] = partsSubstUSearchResultWork.ChgDestDuplicationShelfNo2;
                    row[COL_SHIPMENTPOSCNT_TITLE] = partsSubstUSearchResultWork.ChgDestShipmentPosCnt;
                }
                else
                {
                    // 代替元の場合
                    row[COL_CHGSRCGOODSNO_TITLE] = partsSubstUSearchResultWork.ChgSrcGoodsNo;
                    row[COL_MAKERCODE_TITLE] = partsSubstUSearchResultWork.ChgSrcMakerCd;
                    if (partsSubstUSearchResultWork.ChgSrcWarehouseCode == string.Empty) row[COL_WAREHOUSECODE_TITLE] = string.Empty;
                    else row[COL_WAREHOUSECODE_TITLE] = partsSubstUSearchResultWork.ChgSrcWarehouseCode.TrimEnd().PadLeft(4, '0');
                    row[COL_WAREHOUSESHELF_TITLE] = partsSubstUSearchResultWork.ChgSrcWarehouseShelfNo;
                    row[COL_DUPLICATIONSHELF1_TITLE] = partsSubstUSearchResultWork.ChgSrcDuplicationShelfNo1;
                    row[COL_DUPLICATIONSHELF2_TITLE] = partsSubstUSearchResultWork.ChgSrcDuplicationShelfNo2;
                    row[COL_SHIPMENTPOSCNT_TITLE] = partsSubstUSearchResultWork.ChgSrcShipmentPosCnt;
                }

                resultDataTable.Rows.Add(row);
            }

            // ソート処理（代替先の順位付含む）
            if (searchDiv == 0)
            {
                // 代替先
                string tmpGoodsNo = goodsNo;
                DataRow[] dr;
                DataTable newTable = resultDataTable.Copy();
                resultDataTable.Rows.Clear();
                // ループチェック用
                List<string> loopCheckGoodsNoList = new List<string>(); // ADD 2008/12/12

                // 代替元品番⇒代替先品番となるようにSelect(10行まで)
                for (int i = 0; i < newTable.Rows.Count && i < 10; i++)
                {
                    // 必ず1件該当
                    dr = newTable.Select(COL_CHGSRCGOODSNO_TITLE + " = '" + tmpGoodsNo + "'");

                    // --- ADD 2008/12/12 -------------------------------->>>>>
                    if (loopCheckGoodsNoList.Contains(dr[0][COL_CHGDESTGOODSNO_TITLE].ToString()))
                    {
                        // 検索先品番が既存の検索元品番に存在する(ループする)場合
                        break;
                    }
                    // --- ADD 2008/12/12 --------------------------------<<<<<
                    
                    // 順位設定
                    dr[0][COL_ORDER_TITLE] = i + 1;
                    resultDataTable.ImportRow(dr[0]);

                    // 検索元品番を保存
                    loopCheckGoodsNoList.Add(tmpGoodsNo);

                    // 次の元品番を設定
                    tmpGoodsNo = dr[0][COL_CHGDESTGOODSNO_TITLE].ToString();
                }
            }
            else
            {
                // 代替元
                DataRow[] dr;
                DataTable newTable = resultDataTable.Copy();
                resultDataTable.Rows.Clear();
                
                // メーカー、品番順にソート
                dr = newTable.Select("", COL_MAKERCODE_TITLE + ", " + COL_CHGSRCGOODSNO_TITLE);

                // ソート順に10行まで取得
                for (int i = 0; i < dr.Length && i < 10; i++ )
                {
                    resultDataTable.ImportRow(dr[i]);
                }
            }

            // 取得元データの取得
            PartsSubstUSearchResultWork work = (PartsSubstUSearchResultWork)((ArrayList)retObj)[0];

            if (searchDiv == 0)
            {
                // 代替先の場合、代替元情報を保持
                //outParam.Add(work.ChgSrcWarehouseCode.TrimEnd().PadLeft(4, '0')); // DEL 2008/12/25
                outParam.Add(work.ChgSrcWarehouseCode.TrimEnd()); // ADD 2008/12/25
                outParam.Add(work.ChgSrcWarehouseShelfNo);
                outParam.Add(work.ChgSrcDuplicationShelfNo1);
                outParam.Add(work.ChgSrcDuplicationShelfNo2);
                outParam.Add(work.ChgSrcShipmentPosCnt);
            }
            else
            {
                // 代替元の場合、代替先情報を保持
                //outParam.Add(work.ChgDestWarehouseCode.TrimEnd().PadLeft(4, '0')); // DEL 2008/12/25
                outParam.Add(work.ChgDestWarehouseCode.TrimEnd()); // ADD 2008/12/25
                outParam.Add(work.ChgDestWarehouseShelfNo);
                outParam.Add(work.ChgDestDuplicationShelfNo1);
                outParam.Add(work.ChgDestDuplicationShelfNo2);
                outParam.Add(work.ChgDestShipmentPosCnt);
            }
        }

        #endregion

        #region ■テスト用
        private int testProc(out object retObj)
        {
            ArrayList paramlist = new ArrayList();

            PartsSubstUSearchResultWork param1 = new PartsSubstUSearchResultWork();

            param1.EnterpriseCode = "1234567890123456";
            param1.ChgSrcMakerCd = 1234;
            param1.ChgSrcGoodsNo = "123456789012345678901234";
            // ハイフン無品番は使用しない
            param1.ChgSrcWarehouseCode = "8888";
            param1.ChgSrcWarehouseShelfNo = "12345678";
            param1.ChgSrcDuplicationShelfNo1 = "12345678";
            param1.ChgSrcDuplicationShelfNo2 = "12345678";
            param1.ChgSrcShipmentPosCnt = 200000;

            param1.ChgDestMakerCd = 4321;
            param1.ChgDestGoodsNo = "432109876543210987654321";
            // ハイフン無品番は使用しない
            param1.ChgDestWarehouseCode = "7777";
            param1.ChgDestWarehouseShelfNo = "87654321";
            param1.ChgDestDuplicationShelfNo1 = "87654321";
            param1.ChgDestDuplicationShelfNo2 = "87654321";
            param1.ChgDestShipmentPosCnt = 3000.1;

            paramlist.Add(param1);

            retObj = paramlist;

            return 0;
        }

        #endregion
    }
}
