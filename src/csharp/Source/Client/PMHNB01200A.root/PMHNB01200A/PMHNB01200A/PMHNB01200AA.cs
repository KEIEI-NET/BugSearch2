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
    /// ����f�[�^�p�q���M����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�p�q�R�[�h���M������s���N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/05/27</br>
    /// <br></br>
    /// </remarks>
    public class SalesQRSendController
    {
        // ���[���[EXE�t�@�C����
        private const string ct_NS_MAILER = "PMKHN07500U.EXE";


        /// <summary>
        /// �������s
        /// </summary>
        /// <param name="cndtn"></param>
        public void Execute( SalesQRSendCtrlCndtn cndtn )
        {
            try
            {
                // ���O�C�����_
                string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

                # region [�e��A�N�Z�X�N���X]
                // ����f�[�^�ǂݍ��݃N���X
                SalesSlipReader salesSlipReader = new SalesSlipReader();
                // QR�t�@�C�������N���X
                QRFileCreator qrFileCreator = new QRFileCreator();
                // ���o�C���󔭒��f�[�^�������݃N���X
                MblOdrDataWriter mblOdrDataWriter = new MblOdrDataWriter();
                // ���[�����A�N�Z�X�N���X
                MailDefaultDataAcs mailDefaultDataAcs = new MailDefaultDataAcs();
                // ���[�����ݒ�A�N�Z�X�N���X
                MailInfoSettingAcs mailInfoSettingAcs = new MailInfoSettingAcs();
                # endregion

                # region [���[�����ݒ�}�X�^�ǂݍ���]
                // �ǂݍ���
                MailInfoSetting mailInfoSetting = null;
                mailInfoSettingAcs.Read( out mailInfoSetting, cndtn.EnterpriseCode, _loginSectionCode );
                // �ݒ�L������
                if ( mailInfoSetting == null || string.IsNullOrEmpty( mailInfoSetting.FilePathNm ) )
                {
                    // ���ݒ�Ȃ�Ώ������s���Ȃ�
                    return;
                }
                # endregion

                // KEY���X�g�Ɋ܂܂��`�[�̐������J��Ԃ�
                foreach ( SalesQRSendCtrlCndtn.QRSendCtrlSalesSlipKey slipKey in cndtn.SalesSlipKeyList )
                {
                    // QR�ǂݍ���GUID
                    Guid qrGuid = Guid.Empty;
                    // ���[�����t�@�C����
                    string mailInfoFileName = string.Empty;

                    // Jpg�t�@�C����
                    string bmpFileName = GetBmpFileName( mailInfoSetting.FilePathNm, slipKey );


                    # region [����f�[�^�ǂݍ���]
                    // ����f�[�^�ǂݍ���
                    SalesSlipWork salesSlip;
                    List<SalesDetailWork> salesDetailList;
                    List<AcceptOdrCarWork> acceptOdrCarList;
                    int readStatus = salesSlipReader.ReadSalesSlip( ConstantManagement.LogicalMode.GetData0, cndtn.EnterpriseCode,
                                                                slipKey.AcptAnOdrStatus, slipKey.SalesSlipNum,
                                                                out salesSlip, out salesDetailList, out acceptOdrCarList );
                    // �ǂݍ��߂Ȃ���Ύ��̓`�[
                    if ( readStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                         salesDetailList == null ||
                         salesDetailList.Count == 0 )
                    {
                        continue;
                    }
                    // �擪���ׂɕR�t�����q�����擾
                    AcceptOdrCarWork acceptOdrCar = FindAcceptOdrCar( acceptOdrCarList, salesDetailList[0] );
                    if ( acceptOdrCar == null )
                    {
                        acceptOdrCar = new AcceptOdrCarWork();
                    }
                    // QR�ɃZ�b�g����GUID�͔���f�[�^��GUID
                    qrGuid = salesSlip.FileHeaderGuid;
                    # endregion

                    # region [�p�q�R�[�h����]
                    // �p�q�R�[�h����(bmp�t�@�C���o��)
                    qrFileCreator.CreateQRFile( MailQRDataCreateMediator.CreateData( qrGuid ), bmpFileName );
                    # endregion

                    # region [���o�C���󔭒��f�[�^�X�V]
                    // ���o�C���󔭒��f�[�^�X�V
                    int writeStatus = mblOdrDataWriter.WriteMblOdrData( qrGuid, salesSlip, acceptOdrCar, salesDetailList, acceptOdrCarList );
                    # endregion

                    if ( writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        # region [�m�r���[���[�N��]
                        // ���[����񐶐�
                        CreateMailDefaultData( ref mailDefaultDataAcs, salesSlip, acceptOdrCar, salesDetailList, acceptOdrCarList, bmpFileName, out mailInfoFileName );
                        if ( !string.IsNullOrEmpty( mailInfoFileName ) )
                        {
                            // ���[���[�N��
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

        # region [����]
        /// <summary>
        /// JPEG�t�@�C�����擾
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="slipKey"></param>
        /// <returns></returns>
        private string GetBmpFileName( string filePath, SalesQRSendCtrlCndtn.QRSendCtrlSalesSlipKey slipKey )
        {
            // <�}�X�����Őݒ肵���t�H���_>\QR999999999.JPG
            string fileName = string.Format( "QR{0}.JPG", slipKey.SalesSlipNum );
            return Path.Combine( filePath, fileName );
        }
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)�̃��X�g������
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
        /// �󒍃X�e�[�^�X�ϊ������i���㖾�ׁˎ󒍃}�X�^(�ԗ�)�j
        /// </summary>
        /// <param name="acptStatus"></param>
        /// <returns></returns>
        private int GetAcptStatus( int acptStatus )
        {
            switch ( acptStatus )
            {
                // ����10��1
                case 10: return 1;
                // ��20��3
                case 20: return 3;
                // ����30��7
                case 30: return 7;
                // �ݏo40��5
                case 40: return 5;
                // (default�͔���Ƃ݂Ȃ�)
                default: return 7;
            }
        }
        # endregion

        # region [���[��]
        /// <summary>
        /// ���[���[���s����
        /// </summary>
        private void MailerExecute( string executeParameter )
        {
            // �J�����g�f�B���N�g����ݒ�i���`�[�����"C:\WINDOWS\system32\spool"�ɕς��ꍇ���L��ׁj
            //System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory; // ... Delphi�G���g������N�����̓G���[�ɂȂ�
            System.Environment.CurrentDirectory = Path.GetDirectoryName( System.Windows.Forms.Application.ExecutablePath );

            if ( File.Exists( ct_NS_MAILER ) )
            {
                // ���[���[�̃v���Z�X�𐶐�
                Process mailer = new Process();

                // �v���Z�X�̋N������ݒ�
                mailer.StartInfo.FileName = ct_NS_MAILER;
                mailer.StartInfo.Arguments = executeParameter;

                try
                {
                    // ���[���[�N��(�ʃv���Z�X�Ƃ��ċN��)
                    mailer.Start();
                }
                catch
                {
                    // ���s�Ɏ��s
                }
            }
            else
            {
                // ���[���[���݂���Ȃ�
            }
        }
        /// <summary>
        /// ���[���[���s�p�����[�^����
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="mailInfoFileName"></param>
        /// <returns></returns>
        private string CreateMailerExecuteParameter( SalesQRSendCtrlCndtn cndtn, string mailInfoFileName )
        {
            // ���[���[�̃R�}���h���C�������ɓn��������̐���
            return string.Format( "{0} {1}", cndtn.ProgramParameter, mailInfoFileName );
        }
        /// <summary>
        /// ���[�����t�@�C���o��
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
            // �w�b�_
            MailDefaultHeader mailDefaultHeader = MailDefaultDataConverter.ConverToMailDefaultHeader( salesSlip );
            mailDefaultHeader.Mode = 1; // 1:QR�t���N��
            mailDefaultHeader.AttachedFilePath = bmpFileName; // �Y�t�t�@�C���p�X�i�p�q�R�[�h�̃t�@�C���p�X�j
            
            // ���q
            MailDefaultCar mailDefaultCar = MailDefaultDataConverter.ConverToMailDefaultCar( acceptOdrCar );

            // ����
            List<MailDefaultDetail> mailDefaultDetailList = new List<MailDefaultDetail>();
            foreach ( SalesDetailWork salesDetail in salesDetailList )
            {
                MailDefaultDetail mailDefaultDetail = MailDefaultDataConverter.ConverToMailDefaultDetail( salesDetail );

                mailDefaultDetail.GoodsName = GetPrintGoodsName( salesDetail );
                mailDefaultDetail.ShipmentCnt = Round( mailDefaultDetail.ShipmentCnt );
                    
                mailDefaultDetailList.Add( mailDefaultDetail );
            }

            // �J�����g�f�B���N�g����ݒ�i���`�[�����"C:\WINDOWS\system32\spool"�ɕς��ꍇ���L��ׁj
            //System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory; // ... Delphi�G���g������N�����̓G���[�ɂȂ�
            System.Environment.CurrentDirectory = Path.GetDirectoryName( System.Windows.Forms.Application.ExecutablePath );

            // �t�@�C���o��
            mailDefaultDataAcs.Write( mailDefaultHeader, mailDefaultCar, mailDefaultDetailList, out mailInfoFileName );
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="orgValue"></param>
        /// <returns></returns>
        private static int Round( double orgValue )
        {
            Int64 resultValue;

            // �[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j
            FractionCalculate.FracCalcMoney( (double)orgValue, 1.0f, 2, out resultValue );

            return (int)resultValue;
        }
        /// <summary>
        /// ����i���擾����
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns></returns>
        private string GetPrintGoodsName( SalesDetailWork salesDetail )
        {
            // ���`�[����Ɠ��l�̎d�l�ŕi�����擾���܂��B

            // "�i���J�i"����̏ꍇ��"�i��"
            if ( !string.IsNullOrEmpty( salesDetail.GoodsNameKana ) && salesDetail.GoodsNameKana.Trim() != string.Empty )
            {
                // �i���J�i
                return salesDetail.GoodsNameKana;
            }
            else
            {
                // �i��
                return salesDetail.GoodsName;
            }
        }
        # endregion
    }

    /// <summary>
    /// ���[���p�p�q�f�[�^��������N���X
    /// </summary>
    internal class MailQRDataCreateMediator : QRDataCreateMediator
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public static string CreateData( Guid guid )
        {
            // �p�q�R�[�h�p�f�[�^������ɕϊ����ĕԋp
            return QRDataCreator.CreateDataForMail( guid.ToString(), false );
        }
    }
}
