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
	/// ���M�p�p�q�R�[�h��������
	/// </summary>
	/// <remarks>
	/// <br>Note         : ���[�����M�p�̂p�q�R�[�h�t�@�C��(jpg)�𐶐�����N���X�ł��B</br>
	/// <br>Programmer   : 22018 ��؁@���b</br>
	/// <br>Date         : 2010/05/27</br>
	/// <br></br>
    /// </remarks>
	public class QRFileCreator
	{
        // QR�o�͗p��а��߰�
        private QRReport _qrReport;
        // QR�o�͗pð���
        private DataTable _qrTable;

        /// <summary>
        /// �p�q�R�[�h�t�@�C���o��
        /// </summary>
        /// <param name="qrData"></param>
        /// <param name="bmpFileName"></param>
        public void CreateQRFile( string qrData, string bmpFileName )
        {
            // Bmp�t�@�C���ɕϊ�
            try
            {
                // TIFF�t�@�C����
                string tiffFileName = Path.ChangeExtension( bmpFileName, "TIFF" );

                // ���|�[�g�ݒ�
                ReportSetting( ref _qrReport, ref _qrTable, qrData );

                // ���s
                _qrReport.Run();

                // Tiff�G�N�X�|�[�g
                ar.Export.Tiff.TiffExport tiffExporter = new DataDynamics.ActiveReports.Export.Tiff.TiffExport();
                if ( !Directory.Exists( Path.GetDirectoryName( tiffFileName ) ) )
                {
                    Directory.CreateDirectory( Path.GetDirectoryName( tiffFileName ) );
                }
                tiffExporter.Export( _qrReport.Document, tiffFileName );

                // JPG�֕ϊ�����{�g���~���O����
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


                // �ϊ����I�������Tiff�͍폜
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
        /// QR�����p�_�~�[���|�[�g�ݒ菈��
        /// </summary>
        /// <param name="qrReport"></param>
        /// <param name="qrTable"></param>
        /// <param name="qrData"></param>
        private void ReportSetting( ref QRReport qrReport, ref DataTable qrTable, string qrData )
        {
            // ���|�[�g��������ΐ���
            if ( qrReport == null )
            {
                // ����
                qrReport = new QRReport();

                // ���|�[�g�̐ݒ�
                qrReport.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                qrReport.PageSettings.Margins = new DataDynamics.ActiveReports.Document.Margins( 0, 0, 0, 0 );
            }

            // �e�[�u����������ΐ����E�L��΃N���A
            if ( qrTable == null )
            {
                qrTable = new DataTable( "QRDATATABLE" );
                qrTable.Columns.Add( new DataColumn( "QRDATA", typeof( string ) ) );
            }
            else
            {
                qrTable.Rows.Clear();
            }

            // �p�q�f�[�^������Z�b�g
            DataRow row = qrTable.NewRow();
            row["QRDATA"] = qrData;
            qrTable.Rows.Add( row );

            // ���|�[�g�Ƀe�[�u�����o�C���h����
            qrReport.DataSource = qrTable;
        }
    }
}
