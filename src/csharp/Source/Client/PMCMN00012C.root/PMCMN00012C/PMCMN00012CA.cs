using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Drawing;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 送信用ＱＲコード生成処理
	/// </summary>
	/// <remarks>
	/// <br>Note         : メール送信用のＱＲコードファイル(jpg)を生成するクラスです。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2010/05/27</br>
	/// <br></br>
    /// </remarks>
	public class QRFileCreator
	{
        // QR出力用ﾀﾞﾐｰﾚﾎﾟｰﾄ
        private QRReport _qrReport;
        // QR出力用ﾃｰﾌﾞﾙ
        private DataTable _qrTable;

        /// <summary>
        /// ＱＲコードファイル出力
        /// </summary>
        /// <param name="qrData"></param>
        /// <param name="bmpFileName"></param>
        public void CreateQRFile( string qrData, string bmpFileName )
        {
            // Bmpファイルに変換
            try
            {
                // TIFFファイル名
                string tiffFileName = Path.ChangeExtension( bmpFileName, "TIFF" );

                // レポート設定
                ReportSetting( ref _qrReport, ref _qrTable, qrData );

                // 実行
                _qrReport.Run();

                // Tiffエクスポート
                ar.Export.Tiff.TiffExport tiffExporter = new DataDynamics.ActiveReports.Export.Tiff.TiffExport();
                if ( !Directory.Exists( Path.GetDirectoryName( tiffFileName ) ) )
                {
                    Directory.CreateDirectory( Path.GetDirectoryName( tiffFileName ) );
                }
                tiffExporter.Export( _qrReport.Document, tiffFileName );

                // JPGへ変換する＋トリミングする
                const int imageSize = 200;
                Bitmap newBmp = new Bitmap( imageSize, imageSize );
                using ( Bitmap bmp = new Bitmap( tiffFileName ) )
                {
                    using ( Graphics dg = Graphics.FromImage( newBmp ) )
                    {
                        dg.DrawImage( bmp, new Rectangle( 0, 0, imageSize, imageSize ), new Rectangle( 0, 0, imageSize, imageSize ), GraphicsUnit.Pixel );
                    }
                }
                newBmp.Save( bmpFileName, System.Drawing.Imaging.ImageFormat.Jpeg );
                newBmp.Dispose();


                // 変換が終わったらTiffは削除
                if ( File.Exists( tiffFileName ) )
                {
                    File.Delete( tiffFileName );
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// QR生成用ダミーレポート設定処理
        /// </summary>
        /// <param name="qrReport"></param>
        /// <param name="qrTable"></param>
        /// <param name="qrData"></param>
        private void ReportSetting( ref QRReport qrReport, ref DataTable qrTable, string qrData )
        {
            // レポートが無ければ生成
            if ( qrReport == null )
            {
                // 生成
                qrReport = new QRReport();

                // レポートの設定
                qrReport.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                qrReport.PageSettings.Margins = new DataDynamics.ActiveReports.Document.Margins( 0, 0, 0, 0 );
            }

            // テーブルが無ければ生成・有ればクリア
            if ( qrTable == null )
            {
                qrTable = new DataTable( "QRDATATABLE" );
                qrTable.Columns.Add( new DataColumn( "QRDATA", typeof( string ) ) );
            }
            else
            {
                qrTable.Rows.Clear();
            }

            // ＱＲデータ文字列セット
            DataRow row = qrTable.NewRow();
            row["QRDATA"] = qrData;
            qrTable.Rows.Add( row );

            // レポートにテーブルをバインドする
            qrReport.DataSource = qrTable;
        }
    }
}
