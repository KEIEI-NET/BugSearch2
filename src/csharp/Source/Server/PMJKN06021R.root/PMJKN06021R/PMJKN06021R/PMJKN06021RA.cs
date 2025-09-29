using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ���R�������i�@�����o�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�}�X�^�����o�^�̃f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22018</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class IOWriteFreeSearchParts : RemoteWithAppLockDB
    {
        # region [Write]
        /// <summary>
        /// ���R�������i�}�X�^�����o�^����
        /// </summary>
        /// <param name="salesDetailList"></param>
        /// <param name="acpOdrCarList"></param>
        /// <param name="slpDtlAdInfList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int WriteFreeSearchParts( ref ArrayList salesDetailList, ref ArrayList acpOdrCarList, ref ArrayList slpDtlAdInfList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList freeSearchPartsList = new ArrayList();

                // ArrayList.BinarySearch �ɂ����āA��r�Ώۍ��ڂ������A�C�e�������X�g���ɕ������݂����ꍇ
                // �������C���f�b�N�X�l��Ԃ��Ȃ������������ׂɃW�F�l���b�N�ɃR�s�[���Ĉȍ~�̏������s��
                List<SalesDetailWork> slsDtlList = new List<SalesDetailWork>();

                if ( salesDetailList != null )
                {
                    slsDtlList.AddRange( (SalesDetailWork[])salesDetailList.ToArray( typeof( SalesDetailWork ) ) );
                }


                // �󒍃}�X�^(�ԗ�)�f�B�N�V���i��
                Dictionary<string, AcceptOdrCarWork> acpOdrCarDic = new Dictionary<string, AcceptOdrCarWork>();
                // �󒍃}�X�^(�ԗ�)���f�B�N�V���i���Ɋi�[����
                foreach ( AcceptOdrCarWork acceptOdrCar in acpOdrCarList )
                {
                    string key = GetKey( acceptOdrCar.AcptAnOdrStatus, acceptOdrCar.AcceptAnOrderNo );
                    if ( !acpOdrCarDic.ContainsKey( key ) )
                    {
                        acpOdrCarDic.Add( key, acceptOdrCar );
                    }
                }

                // �`�[���גǉ����̖��׊֘A�t��GUID��r�N���X
                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();

                if ( ListUtils.IsNotEmpty( slpDtlAdInfList ) )
                {
                    slpDtlAdInfList.Sort( DtlRelationGuidComp );

                    # region [���㖾�׃f�[�^ �� ���R�������i]

                    if ( slsDtlList.Count > 0 )
                    {
                        foreach ( SalesDetailWork slsDtlWrk in slsDtlList )
                        {
                            // ���㖾�ׂɕR�t���`�[���גǉ������擾
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch( slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp );

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if ( slpDtlAdInfPos > -1 )
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // �`�[���גǉ���񂪑��݂��A�����R�������i�o�^�敪�� 1:�o�^ �̏ꍇ
                            if ( slpDtlAdInfWrk != null && slpDtlAdInfWrk.FreeSearchPartsEntryDiv == 1 )
                            {
                                // ���㖾�ׂɑΉ�����󒍃}�X�^(�ԗ�)���擾�i��key�ƂȂ�󒍃X�e�[�^�X�͕ϊ����K�v�j
                                string key = GetKey( GetAcptStatus( slsDtlWrk.AcptAnOdrStatus ), slsDtlWrk.AcceptAnOrderNo );
                                if ( acpOdrCarDic.ContainsKey( key ) )
                                {
                                    FreeSearchPartsWork[] freeSearchPartsWorks = CreateFreeSearchPartsInfo( slsDtlWrk, acpOdrCarDic[key], slpDtlAdInfWrk.FullModelList );
                                    if ( freeSearchPartsWorks != null )
                                    {
                                        freeSearchPartsList.AddRange( freeSearchPartsWorks );
                                    }
                                }
                            }
                        }
                    }

                    # endregion
                }

                if ( ListUtils.IsNotEmpty( freeSearchPartsList ) )
                {
                    // ���R�������i�}�X�^�ɏ�������
                    FreeSearchPartsDB freeSearchPartsDB = new FreeSearchPartsDB();
                    status = freeSearchPartsDB.Write( ref freeSearchPartsList, ref sqlConnection, ref sqlTransaction );
                }
                else
                {
                    // ���R�������i�}�X�^�ɓo�^���ׂ��f�[�^�����݂��Ȃ��ꍇ�� ctDB_NORMAL �Ƃ���B
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch ( Exception ex )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                base.WriteErrorLog( ex, errmsg, status );
            }

            return status;
        }
        # endregion

        # region [private���\�b�h]
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
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)�L�[������擾����
        /// </summary>
        /// <param name="acptStatus"></param>
        /// <param name="acptNo"></param>
        /// <returns></returns>
        private string GetKey( int acptStatus, int acptNo )
        {
            // �������̗���ɂ�萧�񂳂��ׁA���L�����͏ȗ�����B
            //   �E��ƃR�[�h��v
            //   �E�󒍃}�X�^(�ԗ�)��DataInputSystem=10

            return string.Format( "{0},{1}", acptStatus.ToString( "00" ), acptNo.ToString( "000000000" ) );
        }
        /// <summary>
        /// ���R�������i�}�X�^��񐶐������i���㖾�ׁ{�󒍃}�X�^(�ԗ�)�ˎ��R�������i�}�X�^�j
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <param name="acceptOdrCar"></param>
        /// <param name="fullModelList"></param>
        /// <returns></returns>
        private FreeSearchPartsWork[] CreateFreeSearchPartsInfo( SalesDetailWork salesDetail, AcceptOdrCarWork acceptOdrCar, string[] fullModelList )
        {
            // �t���^�����X�g����Ȃ�Γo�^�Ȃ�
            if ( fullModelList == null || fullModelList.Length == 0 )
            {
                return null;
            }

            List<FreeSearchPartsWork> retList = new List<FreeSearchPartsWork>();

            // �ΏۂƂȂ�t���^���̕��������R�[�h�𐶐�����
            foreach (string fullModel in fullModelList)
	        {
                FreeSearchPartsWork fsParts = new FreeSearchPartsWork();

                # region [���ڃZ�b�g]
                //--------------------------------------------------
                // FileHeader
                //--------------------------------------------------
                fsParts.EnterpriseCode = salesDetail.EnterpriseCode; // ��ƃR�[�h
                fsParts.LogicalDeleteCode = 0; // �_���폜�敪


                //--------------------------------------------------
                // Fields
                //--------------------------------------------------

                fsParts.FreSrchPrtPropNo = GetNewFreSrchPrtPropNo(); // ���R�������i�ŗL�ԍ�

                fsParts.MakerCode = acceptOdrCar.MakerCode; // ���[�J�[�R�[�h
                fsParts.ModelCode = acceptOdrCar.ModelCode; // �Ԏ�R�[�h
                fsParts.ModelSubCode = acceptOdrCar.ModelSubCode; // �Ԏ�T�u�R�[�h
                fsParts.FullModel = fullModel; // �^���i�t���^�j

                fsParts.TbsPartsCode = salesDetail.BLGoodsCode; // BL���i�R�[�h
                fsParts.TbsPartsCdDerivedNo = 0; // �����i�R�[�h�}��
                fsParts.GoodsNo = salesDetail.GoodsNo; // ���i�ԍ�
                fsParts.GoodsNoNoneHyphen = salesDetail.GoodsNo.Replace( "-", "" ); // �n�C�t�������i�ԍ�
                fsParts.GoodsMakerCd = salesDetail.GoodsMakerCd; // ���i���[�J�[�R�[�h
                fsParts.PartsQty = Math.Abs( salesDetail.ShipmentCnt ); // ���iQTY
                fsParts.PartsOpNm = string.Empty; // ���i�I�v�V��������

                fsParts.ModelPrtsAdptYm = DateTime.MinValue; // �^���ʕ��i�̗p�N��
                fsParts.ModelPrtsAblsYm = DateTime.MinValue; // �^���ʕ��i�p�~�N��
                fsParts.ModelPrtsAdptFrameNo = 0; // �^���ʕ��i�̗p�ԑ�ԍ�
                fsParts.ModelPrtsAblsFrameNo = 0; // �^���ʕ��i�p�~�ԑ�ԍ�
                fsParts.ModelGradeNm = string.Empty; // �^���O���[�h����
                fsParts.BodyName = string.Empty; // �{�f�B�[����
                fsParts.DoorCount = 0; // �h�A��
                fsParts.EngineModelNm = string.Empty; // �G���W���^������
                fsParts.EngineDisplaceNm = string.Empty; // �r�C�ʖ���
                fsParts.EDivNm = string.Empty; // E�敪����
                fsParts.TransmissionNm = string.Empty; // �~�b�V��������
                fsParts.WheelDriveMethodNm = string.Empty; // �쓮��������
                fsParts.ShiftNm = string.Empty; // �V�t�g����

                fsParts.CreateDate = TDateTime.DateTimeToLongDate( DateTime.Today ); // �쐬���t
                fsParts.UpdateDate = TDateTime.DateTimeToLongDate( DateTime.Today ); // �X�V�N����

                # endregion

                retList.Add( fsParts );
	        }

            // �[�����Ȃ��null��Ԃ�
            if ( retList.Count == 0 )
            {
                return null;
            }

            // �ԋp
            return retList.ToArray();
        }

        /// <summary>
        /// �V�K���R�������i�ŗL�ԍ� �擾����
        /// </summary>
        /// <returns></returns>
        private string GetNewFreSrchPrtPropNo()
        {
            // �V�KGUID���̔Ԃ��āA�n�C�t������菜��
            return Guid.NewGuid().ToString().Replace( "-", "" );
        }

        # endregion
    }
}
