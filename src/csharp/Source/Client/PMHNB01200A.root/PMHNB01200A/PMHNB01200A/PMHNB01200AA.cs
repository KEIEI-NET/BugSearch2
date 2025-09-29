using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Diagnostics;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上データＱＲ送信制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データＱＲコード送信制御を行うクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// </remarks>
    public class SalesQRSendController
    {
        // メーラーEXEファイル名
        private const string ct_NS_MAILER = "PMKHN07500U.EXE";


        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="cndtn"></param>
        public void Execute( SalesQRSendCtrlCndtn cndtn )
        {
            try
            {
                // ログイン拠点
                string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

                # region [各種アクセスクラス]
                // 売上データ読み込みクラス
                SalesSlipReader salesSlipReader = new SalesSlipReader();
                // QRファイル生成クラス
                QRFileCreator qrFileCreator = new QRFileCreator();
                // モバイル受発注データ書き込みクラス
                MblOdrDataWriter mblOdrDataWriter = new MblOdrDataWriter();
                // メール情報アクセスクラス
                MailDefaultDataAcs mailDefaultDataAcs = new MailDefaultDataAcs();
                // メール情報設定アクセスクラス
                MailInfoSettingAcs mailInfoSettingAcs = new MailInfoSettingAcs();
                # endregion

                # region [メール情報設定マスタ読み込み]
                // 読み込み
                MailInfoSetting mailInfoSetting = null;
                mailInfoSettingAcs.Read( out mailInfoSetting, cndtn.EnterpriseCode, _loginSectionCode );
                // 設定有無判定
                if ( mailInfoSetting == null || string.IsNullOrEmpty( mailInfoSetting.FilePathNm ) )
                {
                    // 未設定ならば処理続行しない
                    return;
                }
                # endregion

                // KEYリストに含まれる伝票の数だけ繰り返す
                foreach ( SalesQRSendCtrlCndtn.QRSendCtrlSalesSlipKey slipKey in cndtn.SalesSlipKeyList )
                {
                    // QR読み込みGUID
                    Guid qrGuid = Guid.Empty;
                    // メール情報ファイル名
                    string mailInfoFileName = string.Empty;

                    // Jpgファイル名
                    string bmpFileName = GetBmpFileName( mailInfoSetting.FilePathNm, slipKey );


                    # region [売上データ読み込み]
                    // 売上データ読み込み
                    SalesSlipWork salesSlip;
                    List<SalesDetailWork> salesDetailList;
                    List<AcceptOdrCarWork> acceptOdrCarList;
                    int readStatus = salesSlipReader.ReadSalesSlip( ConstantManagement.LogicalMode.GetData0, cndtn.EnterpriseCode,
                                                                slipKey.AcptAnOdrStatus, slipKey.SalesSlipNum,
                                                                out salesSlip, out salesDetailList, out acceptOdrCarList );
                    // 読み込めなければ次の伝票
                    if ( readStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                         salesDetailList == null ||
                         salesDetailList.Count == 0 )
                    {
                        continue;
                    }
                    // 先頭明細に紐付く車輌情報を取得
                    AcceptOdrCarWork acceptOdrCar = FindAcceptOdrCar( acceptOdrCarList, salesDetailList[0] );
                    if ( acceptOdrCar == null )
                    {
                        acceptOdrCar = new AcceptOdrCarWork();
                    }
                    // QRにセットするGUIDは売上データのGUID
                    qrGuid = salesSlip.FileHeaderGuid;
                    # endregion

                    # region [ＱＲコード生成]
                    // ＱＲコード生成(bmpファイル出力)
                    qrFileCreator.CreateQRFile( MailQRDataCreateMediator.CreateData( qrGuid ), bmpFileName );
                    # endregion

                    # region [モバイル受発注データ更新]
                    // モバイル受発注データ更新
                    int writeStatus = mblOdrDataWriter.WriteMblOdrData( qrGuid, salesSlip, acceptOdrCar, salesDetailList, acceptOdrCarList );
                    # endregion

                    if ( writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        # region [ＮＳメーラー起動]
                        // メール情報生成
                        CreateMailDefaultData( ref mailDefaultDataAcs, salesSlip, acceptOdrCar, salesDetailList, acceptOdrCarList, bmpFileName, out mailInfoFileName );
                        if ( !string.IsNullOrEmpty( mailInfoFileName ) )
                        {
                            // メーラー起動
                            MailerExecute( CreateMailerExecuteParameter( cndtn, mailInfoFileName ) );
                        }
                        # endregion
                    }
                }
            }
            catch
            {
            }
        }

        # region [共通]
        /// <summary>
        /// JPEGファイル名取得
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="slipKey"></param>
        /// <returns></returns>
        private string GetBmpFileName( string filePath, SalesQRSendCtrlCndtn.QRSendCtrlSalesSlipKey slipKey )
        {
            // <マスメンで設定したフォルダ>\QR999999999.JPG
            string fileName = string.Format( "QR{0}.JPG", slipKey.SalesSlipNum );
            return Path.Combine( filePath, fileName );
        }
        /// <summary>
        /// 受注マスタ(車両)のリスト内検索
        /// </summary>
        /// <param name="acceptOdrCarList"></param>
        /// <param name="salesDetailWork"></param>
        /// <returns></returns>
        private AcceptOdrCarWork FindAcceptOdrCar( List<AcceptOdrCarWork> acceptOdrCarList, SalesDetailWork salesDetailWork )
        {
            AcceptOdrCarWork acceptOdrCar = acceptOdrCarList.Find( delegate( AcceptOdrCarWork acceptOdrCarWork )
                                            {
                                                return (acceptOdrCarWork.AcceptAnOrderNo == salesDetailWork.AcceptAnOrderNo &&
                                                        acceptOdrCarWork.AcptAnOdrStatus == GetAcptStatus( salesDetailWork.AcptAnOdrStatus ));
                                            } );
            return acceptOdrCar;
        }
        /// <summary>
        /// 受注ステータス変換処理（売上明細⇒受注マスタ(車両)）
        /// </summary>
        /// <param name="acptStatus"></param>
        /// <returns></returns>
        private int GetAcptStatus( int acptStatus )
        {
            switch ( acptStatus )
            {
                // 見積10⇒1
                case 10: return 1;
                // 受注20⇒3
                case 20: return 3;
                // 売上30⇒7
                case 30: return 7;
                // 貸出40⇒5
                case 40: return 5;
                // (defaultは売上とみなす)
                default: return 7;
            }
        }
        # endregion

        # region [メール]
        /// <summary>
        /// メーラー実行処理
        /// </summary>
        private void MailerExecute( string executeParameter )
        {
            // カレントディレクトリを設定（※伝票印刷で"C:\WINDOWS\system32\spool"に変わる場合が有る為）
            //System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory; // ... Delphiエントリから起動時はエラーになる
            System.Environment.CurrentDirectory = Path.GetDirectoryName( System.Windows.Forms.Application.ExecutablePath );

            if ( File.Exists( ct_NS_MAILER ) )
            {
                // メーラーのプロセスを生成
                Process mailer = new Process();

                // プロセスの起動情報を設定
                mailer.StartInfo.FileName = ct_NS_MAILER;
                mailer.StartInfo.Arguments = executeParameter;

                try
                {
                    // メーラー起動(別プロセスとして起動)
                    mailer.Start();
                }
                catch
                {
                    // 実行に失敗
                }
            }
            else
            {
                // メーラーがみつからない
            }
        }
        /// <summary>
        /// メーラー実行パラメータ生成
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="mailInfoFileName"></param>
        /// <returns></returns>
        private string CreateMailerExecuteParameter( SalesQRSendCtrlCndtn cndtn, string mailInfoFileName )
        {
            // メーラーのコマンドライン引数に渡す文字列の生成
            return string.Format( "{0} {1}", cndtn.ProgramParameter, mailInfoFileName );
        }
        /// <summary>
        /// メール情報ファイル出力
        /// </summary>
        /// <param name="mailDefaultDataAcs"></param>
        /// <param name="salesSlip"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <param name="bmpFileName"></param>
        /// <param name="mailInfoFileName"></param>
        private void CreateMailDefaultData( ref MailDefaultDataAcs mailDefaultDataAcs, SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCar, List<SalesDetailWork> salesDetailList,  List<AcceptOdrCarWork> acceptOdrCarList, string bmpFileName, out string mailInfoFileName )
        {
            // ヘッダ
            MailDefaultHeader mailDefaultHeader = MailDefaultDataConverter.ConverToMailDefaultHeader( salesSlip );
            mailDefaultHeader.Mode = 1; // 1:QR付き起動
            mailDefaultHeader.AttachedFilePath = bmpFileName; // 添付ファイルパス（ＱＲコードのファイルパス）
            
            // 車輌
            MailDefaultCar mailDefaultCar = MailDefaultDataConverter.ConverToMailDefaultCar( acceptOdrCar );

            // 明細
            List<MailDefaultDetail> mailDefaultDetailList = new List<MailDefaultDetail>();
            foreach ( SalesDetailWork salesDetail in salesDetailList )
            {
                MailDefaultDetail mailDefaultDetail = MailDefaultDataConverter.ConverToMailDefaultDetail( salesDetail );

                mailDefaultDetail.GoodsName = GetPrintGoodsName( salesDetail );
                mailDefaultDetail.ShipmentCnt = Round( mailDefaultDetail.ShipmentCnt );
                    
                mailDefaultDetailList.Add( mailDefaultDetail );
            }

            // カレントディレクトリを設定（※伝票印刷で"C:\WINDOWS\system32\spool"に変わる場合が有る為）
            //System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory; // ... Delphiエントリから起動時はエラーになる
            System.Environment.CurrentDirectory = Path.GetDirectoryName( System.Windows.Forms.Application.ExecutablePath );

            // ファイル出力
            mailDefaultDataAcs.Write( mailDefaultHeader, mailDefaultCar, mailDefaultDetailList, out mailInfoFileName );
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int Round( double orgValue )
        {
            Int64 resultValue;

            // 端数処理（1:切捨 2:四捨五入 3:切上）
            FractionCalculate.FracCalcMoney( (double)orgValue, 1.0f, 2, out resultValue );

            return (int)resultValue;
        }
        /// <summary>
        /// 印刷品名取得処理
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns></returns>
        private string GetPrintGoodsName( SalesDetailWork salesDetail )
        {
            // ※伝票印刷と同様の仕様で品名を取得します。

            // "品名カナ"が空の場合は"品名"
            if ( !string.IsNullOrEmpty( salesDetail.GoodsNameKana ) && salesDetail.GoodsNameKana.Trim() != string.Empty )
            {
                // 品名カナ
                return salesDetail.GoodsNameKana;
            }
            else
            {
                // 品名
                return salesDetail.GoodsName;
            }
        }
        # endregion
    }

    /// <summary>
    /// メール用ＱＲデータ生成仲介クラス
    /// </summary>
    internal class MailQRDataCreateMediator : QRDataCreateMediator
    {
        /// <summary>
        /// 生成処理
        /// </summary>
        /// <returns></returns>
        public static string CreateData( Guid guid )
        {
            // ＱＲコード用データ文字列に変換して返却
            return QRDataCreator.CreateDataForMail( guid.ToString(), false );
        }
    }
}
