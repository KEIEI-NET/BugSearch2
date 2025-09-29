using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataDynamics.ActiveReports;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 自由帳票共通印刷用データセット生成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票のレポートクラスを元に印刷用データテーブルを生成します</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CA : SFANL08235CD
    {
        #region public methods
        /// <summary>
        /// 印字位置設定,ソート順位から印刷メインデータテーブルを作成します
        /// </summary>
        /// <param name="rpt">自由帳票レポートインスタンス</param>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <param name="frePprSrtOLs">ソート順位</param>
        /// <returns>ステータス　正常：0</returns>
        public int GenerateFrePprPrintMain_DT(ActiveReport3 rpt,List<FrePprSrtO> frePprSrtOLs, ref DataSet frePprDataSet)
        {
            try
            {
                SettingDataSet(ref frePprDataSet, CT_FREPPRPRINT_MAIN_DT, rpt, frePprSrtOLs);
            }
            catch
            {
                return -1;
            }
            return 0;
        }
        #endregion public methods

        #region protected methods
        /// <summary>
        /// レポートフッター文字列格納用のデータテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <returns>ステータス　正常：0</returns>
        protected int GenerateFrePprPrintPFtr_DT(ref DataSet frePprDataSet)
        {
            try
            {
                SettingDataSet(ref frePprDataSet, CT_FREPPRPRINT_PFTR_DT, null, null);
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 抽出条件文字列格納用のデータテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <returns>ステータス　正常：0</returns>
        protected int GenerateFrePprPrintExtr_DT(ref DataSet frePprDataSet)
        {
            try
            {
                SettingDataSet(ref frePprDataSet, CT_FREPPRPRINT_EXTR_DT, null, null);
            }
            catch
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// ソート順位格納用のデータテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <returns>ステータス　正常：0</returns>
        protected int GenerateFrePprPrintSrtO_DT(ref DataSet frePprDataSet)
        {
            try
            {
                SettingDataSet(ref frePprDataSet, CT_FREPPRPRINT_SRTO_DT, null, null);
            }
            catch
            {
                return -1;
            }
            return 0;
        }
        #endregion protected methods

        #region private methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <param name="settingTableName">セッティングデータテーブル名</param>
        /// <param name="rpt">自由帳票のレポートインスタンス</param>
        /// <param name="frePprSrtOLs">ソート順位</param>
        private void SettingDataSet(ref DataSet frePprDataSet, string settingTableName, ActiveReport3 rpt, List<FrePprSrtO> frePprSrtOLs)
        {
            // データセット作成
            if (frePprDataSet == null)
            {
                frePprDataSet = new DataSet();
            }

            // テーブルが存在するかをチェック
            if ((frePprDataSet.Tables.Contains(settingTableName)))
            {
                // テーブルが存在する時はクリアーするのみ
                frePprDataSet.Tables[settingTableName].Clear();
            }
            else
            {
                // テーブルが存在しないときは作成する
                switch (settingTableName)
                {
                    case CT_FREPPRPRINT_MAIN_DT:
                        {
                            CreateMAIN_DT(ref frePprDataSet, settingTableName, rpt, frePprSrtOLs);
                            break;
                        }
                    case CT_FREPPRPRINT_EXTR_DT:
                        {
                            CreateEXTR_DT(ref frePprDataSet, settingTableName);
                            break;
                        }
                    case CT_FREPPRPRINT_PFTR_DT:
                        {
                            CreatePFRT_DT(ref frePprDataSet, settingTableName);
                            break;
                        }
                    case CT_FREPPRPRINT_SRTO_DT:
                        {
                            CreateSortO_DT(ref frePprDataSet, settingTableName);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// メイン印刷情報データテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <param name="settingTableName">セッティングデータテーブル名</param>
        /// <param name="rpt">自由帳票レポートインスタンス</param>
        /// <param name="frePprSrtOLs">ソート順位</param>
        private void CreateMAIN_DT(ref DataSet frePprDataSet, string settingTableName, ActiveReport3 rpt, List<FrePprSrtO> frePprSrtOLs)
        {
            // テーブル設定
            frePprDataSet.Tables.Add(settingTableName);
            DataTable dt = frePprDataSet.Tables[settingTableName];

            
            // スキーマ設定
            // -- レポート上の印字項目分 ------------------------
            if (rpt != null)
            {
            
                // レポートのセクションを捜査
                foreach(Section section in rpt.Sections)
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
                        // controlのDataField追加
                        AddColumns(ref dt, control.DataField);
                    } // control end
                } // section end
            }

            // -- ソート順位分 ------------------------
            if (frePprSrtOLs != null)
            {
                foreach (FrePprSrtO frePprSrtO in frePprSrtOLs)
                {
                    AddColumns(ref dt, frePprSrtO.FileNm + "." + frePprSrtO.DDName);
                }
            }
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

        /// <summary>
        /// 抽出条件文字列用データテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <param name="settingTableName">セッティングデータテーブル名</param>
        private void CreateEXTR_DT(ref DataSet frePprDataSet, string settingTableName)
        {
            // テーブル設定
            frePprDataSet.Tables.Add(settingTableName);
            DataTable dt = frePprDataSet.Tables[settingTableName];

            // 抽出条件文字列
            dt.Columns.Add(CT_EXTRACTCONDS, typeof(string));
            dt.Columns[CT_EXTRACTCONDS].DefaultValue = "";
        }

        /// <summary>
        /// 帳票フッター用データテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <param name="settingTableName">セッティングデータテーブル名</param>
        private void CreatePFRT_DT(ref DataSet frePprDataSet, string settingTableName)
        {
            // テーブル設定
            frePprDataSet.Tables.Add(settingTableName);
            DataTable dt = frePprDataSet.Tables[settingTableName];

            // 帳票フッター文1
            dt.Columns.Add(CT_PRINTFOOTER1, typeof(string));
            dt.Columns[CT_PRINTFOOTER1].DefaultValue = "";
            // 帳票フッター文2
            dt.Columns.Add(CT_PRINTFOOTER2, typeof(string));
            dt.Columns[CT_PRINTFOOTER2].DefaultValue = "";
        }

        /// <summary>
        /// ソート順位用データテーブルを作成します
        /// </summary>
        /// <param name="frePprDataSet">自由帳票印刷用データセット</param>
        /// <param name="settingTableName">セッティングデータテーブル名</param>
        private void CreateSortO_DT(ref DataSet frePprDataSet, string settingTableName)
        {
            // テーブル設定
            frePprDataSet.Tables.Add(settingTableName);
            DataTable dt = frePprDataSet.Tables[settingTableName];

            // ソート順位1
            AddColumns(ref dt, CT_SORTODER1);
            AddColumns(ref dt, CT_SORTODER2);
            AddColumns(ref dt, CT_SORTODER3);
            AddColumns(ref dt, CT_SORTODER4);
            AddColumns(ref dt, CT_SORTODER5);
            // 初期値を代入
            DataRow dr = frePprDataSet.Tables[CT_FREPPRPRINT_SRTO_DT].NewRow();
            dr[CT_SORTODER1] = "";
            dr[CT_SORTODER2] = "";
            dr[CT_SORTODER3] = "";
            dr[CT_SORTODER4] = "";
            dr[CT_SORTODER5] = "";
            frePprDataSet.Tables[CT_FREPPRPRINT_SRTO_DT].Rows.Add(dr);
        }

        #endregion private methods

    }
}