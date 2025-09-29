using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

using DataDynamics.ActiveReports;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 自由帳票ダミーデータレポート生成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票のレポートクラスを元にプレビュー印刷用ダミーデータを生成します</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CB
    {
        #region private const
        private const string CT_NOIMAGE = "NoPhoto";
        #endregion

        #region private member
        List<PrtItemSetWork> _prtItemSetLS = new List<PrtItemSetWork>();
        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public SFANL08235CB()
        {
        }


        #region public methods
        
        /// <summary>
        /// ダミーデータ印刷を実行します
        /// </summary>
        /// <param name="prtItemSetLs">印字項目設定のリスト</param>
        /// <param name="frePrtPset">印字位置設定</param>
        /// <param name="createRowCnt">印刷レコード件数</param>
        /// <param name="bgImage"></param>
        /// <param name="rpt"></param>
        /// <returns>正常終了:0</returns>
        public int CreateDummyDataReport(List<PrtItemSetWork> prtItemSetLs, FrePrtPSet frePrtPset, Int32 createRowCnt, Bitmap bgImage, out ActiveReport3 rpt)
        {
            // グローバル領域に確保
            _prtItemSetLS = prtItemSetLs;
            // ダミーデータ印刷用のレポート生成
            return GenerateDummyPrintReport(frePrtPset, createRowCnt, out rpt);
        }

        #endregion

        #region private methods

        /// <summary>
        /// ダミーデータ印刷用のActiveReportクラスを生成します
        /// </summary>
        /// <param name="frePrtPset">印字位置設定データクラス</param>
        /// <param name="createRowCnt">印刷レコード件数</param>
        /// <param name="rpt">ダミーデータ入りレポート</param>
        /// <returns>正常終了:0</returns>
        private int GenerateDummyPrintReport(FrePrtPSet frePrtPset, Int32 createRowCnt, out ActiveReport3 rpt)
        {
            try
            {
                //テーブルセット
                DataSet frePprDataSet = new DataSet();
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_MAIN_DT);  // 印刷メイン
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_EXTR_DT);  // 抽出条件
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_PFTR_DT);  // フッター
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_SRTO_DT);  // ソート順

                #region 印刷メインデータ
                DataTable dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_MAIN_DT];
                // 印字位置設定からレポートを取り出す
                MemoryStream mst1 = new MemoryStream(frePrtPset.PrintPosClassData);
                rpt = new ActiveReport3();
                rpt.LoadLayout(mst1);

                // ☆☆☆ 印刷用スキーマ(DataTable)作成 ☆☆☆
                // -- レポート上のDataFieldから作成
                if (rpt != null)
                {
                    // レポートのセクションを捜査
                    foreach (Section section in rpt.Sections)
                    {
                        // sectionのDataField追加
                        //グループヘッダだったら
                        if (section is GroupHeader)
                        {
                            AddColumns(ref dt, ((GroupHeader)section).DataField);
                        }
                        // セクション毎のコントロールを捜査
                        foreach (ARControl control in section.Controls)
                        {
                            AddColumns(ref dt, control.DataField);
                        }
                    }
                }

                // ☆☆☆ 印刷用ダミーデータ作成 ☆☆☆
                PrtItemSetWork prtItem = null;
                
                DataRow dr = dt.NewRow();
                foreach (DataColumn column in dt.Columns)
                {
                    prtItem = _prtItemSetLS.Find(delegate(PrtItemSetWork piSet) { return FrePrtSettingController.CreateDataField(piSet) == column.Caption; });
                    if (prtItem != null)
                    {
                        if (prtItem.ReportControlCode == 3)
                        {
                            // 画像
                            dr[column.Caption] = GenerateDummyDataForImage();
                        }
                        else if (prtItem.ReportControlCode == 6)
                        {
                            // バーコードの時は数値
                            Random rnd = new Random();
                            dr[column.Caption] = rnd.Next(999999999);
                        }
                        else
                        {
                            dr[column.Caption] = prtItem.FreePrtPaperItemNm;
                        }
                    }
                    else
                    {
                        dr[column.Caption] = string.Empty;
                    }
                }
                dt.Rows.Add(dr);
                // createRowCntで指定された件数分ダミーデータを作成
                for (int roopCnt = 1; roopCnt < createRowCnt; roopCnt++)
                {
                    DataRow copyDr = dt.NewRow();
                    copyDr.ItemArray = dr.ItemArray;
                    dt.Rows.Add(copyDr);
                }
                #endregion

                #region 抽出条件
                dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_EXTR_DT];
                AddColumns(ref dt, SFANL08235CD.CT_EXTRACTCONDS);
                dr = dt.NewRow();
                dr[SFANL08235CD.CT_EXTRACTCONDS] = "抽出条件";
                dt.Rows.Add(dr);
                #endregion

                #region フッター文字列
                dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_PFTR_DT];
                AddColumns(ref dt, SFANL08235CD.CT_PRINTFOOTER1);
                AddColumns(ref dt, SFANL08235CD.CT_PRINTFOOTER2);
                dr = dt.NewRow();
                dr[SFANL08235CD.CT_PRINTFOOTER1] = "帳票フッター文左";
                dr[SFANL08235CD.CT_PRINTFOOTER2] = "帳票フッター文右";
                dt.Rows.Add(dr);
                #endregion

                #region ソート順
                dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_SRTO_DT];
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER1);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER2);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER3);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER4);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER5);
                
                dr = dt.NewRow();
                dr[SFANL08235CD.CT_SORTODER1] = "ソート順１";
                dr[SFANL08235CD.CT_SORTODER2] = "ソート順２";
                dr[SFANL08235CD.CT_SORTODER3] = "ソート順３";
                dr[SFANL08235CD.CT_SORTODER4] = "ソート順４";
                dr[SFANL08235CD.CT_SORTODER5] = "ソート順５";
                dt.Rows.Add(dr);
                #endregion

                rpt.DataSource = frePprDataSet;
                rpt.DataMember = SFANL08235CD.CT_FREPPRPRINT_MAIN_DT;

                // スクリプトで使用できるように参照を追加
                SFANL08235CE.AddScriptReference(ref rpt);
                //rpt.Run();
            }
            catch
            {
                rpt = null;
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// データテーブルにカラムを追加します(カラム名の重複チェック有り)
        /// </summary>
        /// <param name="dt">追加対象のDataTable</param>
        /// <param name="addColumnNm">追加するカラム名称</param>
        private void AddColumns(ref DataTable dt, string addColumnNm)
        {
            if (!string.IsNullOrEmpty(addColumnNm))
            {
                // 存在しなければカラム追加
                if (!dt.Columns.Contains(addColumnNm))
                {
                    dt.Columns.Add(addColumnNm, typeof(object));
                    dt.Columns[addColumnNm].DefaultValue = DBNull.Value;
                }
            }
        }

        #region イメージ型ダミーデータ生成
        /// <summary>
        /// イメージ型のダミーデータを生成します
        /// </summary>
        /// <returns>イメージ型のダミーデータ</returns>
        private Bitmap GenerateDummyDataForImage()
        {
            return Broadleaf.Application.Common.Properties.Resources.NoPhoto;
        }
        #endregion

        #endregion
    }
}