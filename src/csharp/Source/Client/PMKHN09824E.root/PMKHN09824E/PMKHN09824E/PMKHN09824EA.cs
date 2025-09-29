//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ（インポート）テーブルスキーマ情報クラス
// プログラム概要   : 掛率マスタ（インポート）帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 掛率マスタ掛率マスタインポート・エクスポート　テーブルスキーマ情報クラス
	/// </summary>
	/// <remarks>
    /// <br>Note        : 掛率マスタインポート・エクスポート・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer	: 菅原 庸平</br>
    /// <br>Date        : 2013/06/12</br>
	/// </remarks>
    public class PMKHN09824EA 
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_PdfData = "Tbl_PdfData";

        /// <summary> エラー内容 </summary>
        public const string Col_ErrorNote = "ErrorNote";

#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 掛率マスタ（インポート）クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note        : 掛率マスタ（インポート）クラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
		/// </remarks>
        public PMKHN09824EA()
		{

		}
		#endregion

		#region ■ Static Public Method
        #region ◆ CreateDataTable(ref DataTable dt)
        /// <summary>
        /// 掛率マスタインポート・エクスポートDataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
        /// <br>Note        : 掛率マスタインポート・エクスポートのスキーマを設定する。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
		/// </remarks>
        static public void CreatePrintDataTable(ref DataTable dt)
        {
            // テーブルが存在するかどうかのチェック
            if (dt != null)
            {
                // テーブルが存在する時はクリアするのみ。スキーマをもう一度設定するようなことはしない。
                dt.Clear();
            }
            else
            {
                // スキーマ設定
                dt = new DataTable(ct_Tbl_PdfData);

                dt.Columns.Add(Col_ErrorNote, typeof(string));                  // エラー内容
                dt.Columns[Col_ErrorNote].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}
