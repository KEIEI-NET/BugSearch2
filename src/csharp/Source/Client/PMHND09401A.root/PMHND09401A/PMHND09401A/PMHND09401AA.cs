//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�X�V����
// �v���O�����T�v   : ���i�o�[�R�[�h�X�V�A�N�Z�T
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00  �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/09/20   �C�����e : �n���f�B�^�[�~�i���񎟑Ή��i�V�K�쐬�j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�o�[�R�[�h�X�V�A�N�Z�T�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�X�V�A�N�Z�T�N���X�̒�`�Ǝ���</br>
    /// <br>Programmer : 30757�@���X�؁@�M�p</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    public class PrmGoodsBarCodeRevnUpdateAcs
    {
        #region �� Sub Class

        /// <summary>
        /// ���i�o�[�R�[�h�X�V�A�N�Z�T�Ǝ��̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        public enum StatusCode
        {
              ReadCountMaxOrver = -1    // �擾�\�ő僌�R�[�h������
            , FatalError = 1000         // �v���I�G���[
        };

        /// <summary>
        /// �o�[�R�[�h�X�V�敪�񋓑�
        /// </summary>
        public enum BarcodeUpdateKndDiv
        {
              WithoutUserUpdate = 0     // ���[�U�[�X�V�ȊO
            , ALL = 1                   // �S��
        };

        #endregion //�� Sub Class

        #region �� Delegate

        /// <summary>
        /// ���o�����擾�����f���Q�[�g
        /// </summary>
        /// <param name="targetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="count">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�����擾�����̃f���Q�[�g�錾</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        delegate int GetSearchCountDelegate( object targetList, out int count );

        /// <summary>
        /// ���o�����f���Q�[�g
        /// </summary>
        /// <param name="targetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="resultList">���o��񃊃X�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�����̃f���Q�[�g�錾</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        delegate int SearchDelegate( object targetList, out ArrayList resultList );

        #endregion //�� Delegate

        #region �� Const

        /// <summary>
        /// �D�ǃ��[�J�[�R�[�h�����l
        /// </summary>
        public const int PrmMakerCodeMinimum = 1000;

        /// <summary>
        /// �D�ǃ��[�J�[�R�[�h����l
        /// </summary>
        public const int PrmMakerCodeMaximum = 9999;

        /// <summary>
        /// �擾�\�ő僌�R�[�h��
        /// </summary>
        private const int MaxExecuteCount = 20000;

        /// <summary>
        /// �_���폜�敪�F�L��
        /// </summary>
        private const int LogicalDeleteCodeValidity = 0;

        /// <summary>
        /// �`�F�b�N�f�W�b�g�敪�f�t�H���g�l[0:�Ȃ�]
        /// </summary>
        private const int CheckdigitCodeDefault = 0;

        /// <summary>
        /// �񋟃f�[�^�敪�f�t�H���g�l[1:�񋟃f�[�^]
        /// </summary>
        private const int OfferDataDivDefault = 1;

        /// <summary>
        /// �o�[�R�[�h�X�V�敪
        /// </summary>
        private const int BarcodeUpdateKndDivDefault = (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.ALL;

        #region //���샍�O

        /// <summary>
        /// �@�\��
        /// </summary>
        private const string ApplicationName = "���i�o�[�R�[�h�X�V����";

        /// <summary>
        /// �I�y���[�V�����R�[�h�f�t�H���g
        /// </summary>
        private const int OperationCodeDefault = 0;

        /// <summary>
        ///  �I�y���[�V�����X�e�[�^�X�f�t�H���g
        /// </summary>
        private const int OperationStatusDefault = 0;

        /// <summary>
        /// �o�[�R�[�h�X�V�敪�v�f������F���[�U�[�X�V�ȊO
        /// </summary>
        private static readonly string BarcodeUpdateKndNameWithoutUserUpdate = "���[�U�[�X�V�ȊO";

        /// <summary>
        /// �o�[�R�[�h�X�V�敪�v�f������F�S��
        /// </summary>
        private static readonly string BarcodeUpdateKndNameAll = "�S��";

        /// <summary>
        /// �X�V�������ʃ��O������F���[�J�[�͈�
        /// </summary>
        private static readonly string UpdateLogTextMakerRange = "���[�J�[�F{0:0000} �` {1:0000}";

        /// <summary>
        /// �X�V�������ʃ��O������F������
        /// </summary>
        private static readonly string UpdateLogTextGoodMGroup = " �����ށF{0:0000}";

        /// <summary>
        /// �X�V�������ʃ��O������FBL�R�[�h
        /// </summary>
        private static readonly string UpdateLogTextBLGoodsCode = " BL�R�[�h�F{0:00000}";

        /// <summary>
        /// �X�V�������ʃ��O������F�o�[�R�[�h�X�V�敪
        /// </summary>
        private static readonly string UpdateLogTextBarcodeUpdateKnd = " �o�[�R�[�h�X�V�敪�F{0}";

        /// <summary>
        /// �X�V�������ʃ��O������F��������
        /// </summary>
        private static readonly string UpdateLogTextResult = " ���A���i�o�[�R�[�h�}�X�^�ɂ́A{0} �����X�V���܂����B";
        #endregion //���샍�O

        #endregion //�� Const

        #region �� Private Field

        /// <summary>
        /// ���i�o�[�R�[�h�X�V�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
        /// </summary>
        private IPrmGoodsBarCodeRevnUpdateDB IPrmGoodsBrcdUpdDB = null;

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
        /// </summary>
        private  IOfferPrmPartsBrcdInfo IOfferPrmPartsBrcdDB = null;

        /// <summary>
        /// �I�y���[�V�������O�o�̓N���X
        /// </summary>
        private OperationHistoryLog OperationHistLogger;

        /// <summary>
        /// �A�Z���u��ID
        /// </summary>
        private string AssemblyId;

        #endregion //�� Private Field

        #region  �� Constructor

        /// <summary>
        /// ���i�o�[�R�[�h�X�V�A�N�Z�T�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�X�V�A�N�Z�T�N���X�̃C���X�^���X�𐶐�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public PrmGoodsBarCodeRevnUpdateAcs()
        {
            if (this.OperationHistLogger == null)
                this.OperationHistLogger = new OperationHistoryLog();

            // �A�Z���u�������t���p�X�Ŏ擾
            string fullAssemblyName = this.GetType().Assembly.Location;
            // �A�Z���u�����݂̂��擾
            this.AssemblyId = System.IO.Path.GetFileName( fullAssemblyName );
        }
        #endregion

        #region �� Public Method

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�o�^���j�X�V
        /// </summary>
        /// <param name="updateParam">�X�V�p�����[�^</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �X�V�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�}�X�^�̃f�[�^���擾���A���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�e�[�u�����X�V����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public int Update(ref PrmGoodsBrcdUpdateParamWork updateParam, bool autoFlag)
        {
            return this.UpdateProc(ref updateParam, autoFlag);
        }

        /// <summary>
        /// �I�y���[�V�������O�o��
        /// </summary>
        /// <param name="processName">��������</param>
        /// <param name="stepName">�����敪</param>
        /// <param name="data">�X�V���e</param>
        /// <remarks>
        /// <br>Note       : �����̓��e�ŃI�y���[�V�������O�ɑ��샍�O���o�͂���</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public void WriteOperationLog( string processName, string stepName, string data )
        {
            const int LogDataMassageMaxLength = 500;
            const int LogOperationDataMaxLength = 80;

            if (LoginInfoAcquisition.Employee == null)
            {
                //�����̏ꍇ�A���i�o�[�R�[�h�X�V�����[�g�N���X�̑��샍�O�o�̓��\�b�h�Ń��O�o�͂���B

                OprtnHisLogWork writeParam = new OprtnHisLogWork();
                writeParam.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                writeParam.LogDataObjClassID = this.AssemblyId;
                writeParam.LogDataCreateDateTime = DateTime.Now;
                writeParam.LogDataKindCd = (int)LogDataKind.SystemLog;
                writeParam.LogDataObjAssemblyID = this.AssemblyId;
                writeParam.LogDataObjAssemblyNm = PrmGoodsBarCodeRevnUpdateAcs.ApplicationName;
                writeParam.LogDataObjProcNm = processName;
                writeParam.LogOperationStatus = PrmGoodsBarCodeRevnUpdateAcs.OperationStatusDefault;
                writeParam.LogDataMassage = stepName;
                if ( !string.IsNullOrEmpty(stepName) && stepName.Length > LogDataMassageMaxLength)
                {
                    writeParam.LogDataMassage = stepName.Substring( 0, LogDataMassageMaxLength );
                }
                writeParam.LogOperationData = data;
                if ( !string.IsNullOrEmpty(data) && data.Length > LogOperationDataMaxLength)
                {
                    writeParam.LogDataMassage = data.Substring( 0, LogOperationDataMaxLength );
                }

                // �D�Ǖ��i�o�[�R�[�h�X�V�����[�g�I�u�W�F�N�g�̎擾
                if (this.IPrmGoodsBrcdUpdDB == null)
                {
                    this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
                }
                this.IPrmGoodsBrcdUpdDB.WriteOprtnHisLog( writeParam );
            }
            else
            {
                //�蓮�̏ꍇ�A���샍�O�A�N�Z�T�Ń��O�o�͂���B

                this.OperationHistLogger.WriteOperationLog(
                    this,
                    DateTime.Now,
                    LogDataKind.SystemLog,
                    this.AssemblyId,
                    PrmGoodsBarCodeRevnUpdateAcs.ApplicationName,
                    processName,
                    PrmGoodsBarCodeRevnUpdateAcs.OperationCodeDefault,
                    PrmGoodsBarCodeRevnUpdateAcs.OperationStatusDefault,
                    stepName,
                    data
                );
            }
        }

        /// <summary>
        /// �X�V�������ʃ��O�����񐶐�
        /// </summary>
        /// <param name="updateParam">�X�V�p�����[�^</param>
        /// <returns>���O������</returns>
        /// <remarks>
        /// <br>Note       : �X�V�����I�����Ƀ��O�ɏo�͂��邽�߂̕�����𐶐�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public string CreateUpdateLogText( ref PrmGoodsBrcdUpdateParamWork updateParam )
        {
            StringBuilder logText = new StringBuilder();
            if (updateParam.MakerCdST > 0)
                logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextMakerRange, updateParam.MakerCdST, updateParam.MakerCdED );
            if (updateParam.GoodMGroup > 0)
                logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextGoodMGroup, updateParam.GoodMGroup );
            if (updateParam.BLGoodsCode > 0)
                logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextBLGoodsCode, updateParam.BLGoodsCode );
            logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextBarcodeUpdateKnd, updateParam.BarcodeUpdateKndDiv == (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.ALL
                ? PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndNameAll : PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndNameWithoutUserUpdate );
            logText.AppendFormat( PrmGoodsBarCodeRevnUpdateAcs.UpdateLogTextResult, updateParam.RecordCnt );

            return logText.ToString();
        }

        #endregion �� Public Method

        #region �� Private Method

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�o�^���j�X�V����
        /// </summary>
        /// <param name="updateParam">�X�V�p�����[�^</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �X�V�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�}�X�^�̃f�[�^���擾���A���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�e�[�u�����X�V����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int UpdateProc(ref PrmGoodsBrcdUpdateParamWork updateParam, bool autoFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �X�V�Ώۃ��[�J�[�EBL�R�[�h���X�g
            ArrayList prmPartsTargetList = null;

            // ��DB���D�Ǖ��i�o�[�R�[�h��񃊃X�g
            ArrayList offerPrmPartsBrcdList = null;

            // ���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j��񃊃X�g
            ArrayList prmGoodsBrcdList = null;

            //
            // �D�ǐݒ�}�X�^�擾�p�����[�^�̐���
            //
            // �������œn���ꂽ�X�V�p�����[�^�������[�g�p���o�p�����[�^�ɕϊ�����B
            PrmSetUParamForBrcdWork searchParam = this.CopyToRemortSearchParamFromUIUpdateParam( ref updateParam );

            //
            // �D�ǐݒ�}�X�^���X�g�擾
            //
            status = this.SearchPrmPartsInfoList( ref searchParam, out prmPartsTargetList );
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //
            // ��DB���D�Ǖ��i�o�[�R�[�h���擾
            //
            status = this.SearchOfferPrmPartsBrcdList( ref prmPartsTargetList, out offerPrmPartsBrcdList );
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //
            // ���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���擾
            //
            status = this.SearchPrmGoodsBrcdList( ref prmPartsTargetList, out prmGoodsBrcdList );
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                return status;
            }

            //
            // ���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V�p���X�g�̐���
            //
            ArrayList updateTargetList = null;
            StringBuilder resultTextList = null;
            status = CreateUpdateList(
                  ref updateParam
                , ref prmGoodsBrcdList
                , ref offerPrmPartsBrcdList
                , out updateTargetList
                , out resultTextList
                , autoFlag);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //
            // ���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�̍X�V
            //
            int execCount = 0;
            status = UpdatePrmGoodsBrcdList( ref updateTargetList, updateParam.BarcodeUpdateKndDiv, out execCount );
            updateParam.RecordCnt = execCount;

            return status;
        }

        #region �y���[�U�[DB�z�D�ǐݒ�}�X�^���X�g�擾
        
        /// <summary>
        /// �����[�g�p�D�Ǖ��i�o�[�R�[�h��񒊏o�����p�����[�^����
        /// </summary>
        /// <param name="updateParam">UI�p�D�ǐݒ茟�������p�����[�^</param>
        /// <returns>�����[�g�p�D�Ǖ��i�o�[�R�[�h��񒊏o�����p�����[�^</returns>
        /// <remarks>
        /// <br>Note       : UI�p�D�ǐݒ茟�������p�����[�^���[�N�̓��e���������[�g�p�D�Ǖ��i�o�[�R�[�h��񒊏o�����p�����[�^�𐶐�����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private PrmSetUParamForBrcdWork CopyToRemortSearchParamFromUIUpdateParam( ref PrmGoodsBrcdUpdateParamWork updateParam )
        {
            PrmSetUParamForBrcdWork searchParam = new PrmSetUParamForBrcdWork();

            searchParam.EnterpriseCode = updateParam.EnterpriseCode;
            searchParam.MakerCdST = updateParam.MakerCdST;
            searchParam.MakerCdED = updateParam.MakerCdED;
            searchParam.GoodMGroup = updateParam.GoodMGroup;
            searchParam.BLGoodsCode = updateParam.BLGoodsCode;

            return searchParam;
        }
        
        /// <summary>
        /// �D�ǐݒ�}�X�^���X�g�擾
        /// </summary>
        /// <param name="searchParam">���o�p�����[�^</param>
        /// <param name="prmPartsTargetList">�D�ǐݒ��񃊃X�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�ǐݒ�������X�g�Ŏ擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchPrmPartsInfoList( ref PrmSetUParamForBrcdWork searchParam, out ArrayList prmPartsTargetList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            prmPartsTargetList = null;

            // �D�Ǖ��i�o�[�R�[�h�X�V�����[�g�I�u�W�F�N�g�̎擾
            if (this.IPrmGoodsBrcdUpdDB == null)
            {
                this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
            }

            // �D�ǐݒ�}�X�^����
            object getPrmPartsInfoListResult = null;
            status = this.IPrmGoodsBrcdUpdDB.GetPrmPartsInfoList( ref searchParam, out getPrmPartsInfoListResult );

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                prmPartsTargetList = getPrmPartsInfoListResult as ArrayList;
                if (prmPartsTargetList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else if (prmPartsTargetList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else if (!( prmPartsTargetList[0] is GetPrmPartsBrcdParaWork ))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        #endregion //�y���[�U�[DB�z�D�ǐݒ�}�X�^���X�g�擾

        #region �y��DB�z�D�Ǖ��i�o�[�R�[�h���擾

        /// <summary>
        /// �y��DB�z�D�Ǖ��i�o�[�R�[�h���擾
        /// </summary>
        /// <param name="prmPartsTargetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="offerPrmPartsBrcdList">�D�Ǖ��i�o�[�R�[�h��񃊃X�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ��DB����擾�Ώۃp�����[�^���X�g�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�������X�g�Ŏ擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchOfferPrmPartsBrcdList( ref ArrayList prmPartsTargetList, out ArrayList offerPrmPartsBrcdList )
        {
            offerPrmPartsBrcdList = null;
            return this.SearchListProc( ref prmPartsTargetList, this.GetSearchOfferPrmPartsBrcdCount, this.SearchOfferPrmPartsBrcdListMethod, out offerPrmPartsBrcdList, true );
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾
        /// </summary>
        /// <param name="searchParamList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="count">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�̗D�Ǖ��i�o�[�R�[�h��񒊏o�����擾���������s����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchOfferPrmPartsBrcdCount( object prmPartsTargetList, out int count )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            count = -1;

            // �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X�̎擾
            if (this.IOfferPrmPartsBrcdDB == null)
            {
                this.IOfferPrmPartsBrcdDB = MediationOfferPrmPartsWidthBrcdInfo.GetOfferPrmPartsWidthBrcdInfo();
            }

            // �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾
            object paramList = (object)prmPartsTargetList;
            status = this.IOfferPrmPartsBrcdDB.GetSearchCount( ref paramList, out count );

            return status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o����
        /// </summary>
        /// <param name="prmPartsTargetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="prmGoodsBrcdList">�D�Ǖ��i�o�[�R�[�h��񃊃X�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�̗D�Ǖ��i�o�[�R�[�h��񒊏o���������s����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchOfferPrmPartsBrcdListMethod( object prmPartsTargetList, out ArrayList offerPrmPartsBrcdList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            offerPrmPartsBrcdList = null;

            // �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X�̎擾
            if (this.IOfferPrmPartsBrcdDB == null)
            {
                this.IOfferPrmPartsBrcdDB = MediationOfferPrmPartsWidthBrcdInfo.GetOfferPrmPartsWidthBrcdInfo();
            }

            // ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o
            object resultList = null;
            status = this.IOfferPrmPartsBrcdDB.Search( ref prmPartsTargetList, out resultList );
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                offerPrmPartsBrcdList = resultList as ArrayList;
                if (offerPrmPartsBrcdList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else if (offerPrmPartsBrcdList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else if (!( offerPrmPartsBrcdList[0] is RettPrmPartsBrcdInfoWork ))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        #endregion //�y��DB�z�D�Ǖ��i�o�[�R�[�h���擾

        #region �y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���擾

        /// <summary>
        /// �y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���擾
        /// </summary>
        /// <param name="prmPartsTargetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="offerPrmPartsBrcdList">�D�Ǖ��i�o�[�R�[�h��񃊃X�g</param>
        /// <param name="doRecursionFlag">�ċA�ďo�w��t���O[true:����Afalse:���Ȃ�]</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[DB����擾�Ώۃp�����[�^���X�g�̏����ɍ��v���� ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�������X�g�Ŏ擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchPrmGoodsBrcdList( ref ArrayList prmPartsTargetList, out ArrayList prmGoodsBrcdList )
        {
            prmGoodsBrcdList = null;
            return this.SearchListProc( ref prmPartsTargetList, this.GetSearchPrmGoodsBrcdCount, this.SearchPrmGoodsBrcdListMethod, out prmGoodsBrcdList, true );
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o�����擾
        /// </summary>
        /// <param name="searchParamList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="count">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�X�V�����[�g�̏��i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o�����擾���������s����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchPrmGoodsBrcdCount( object prmPartsTargetList, out int count)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            count = -1;

            // ���i�o�[�R�[�h�X�V�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X�̎擾
            if (this.IPrmGoodsBrcdUpdDB == null)
            {
                this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
            }

            // ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o�����擾
            status = this.IPrmGoodsBrcdUpdDB.GetSearchCount( ref prmPartsTargetList, out count );

            return status;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o����
        /// </summary>
        /// <param name="prmPartsTargetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="prmGoodsBrcdList">���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���X�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�X�V�����[�g�̏��i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o���������s����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchPrmGoodsBrcdListMethod( object prmPartsTargetList, out ArrayList prmGoodsBrcdList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            prmGoodsBrcdList = null;

            // ���i�o�[�R�[�h�X�V�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X�̎擾
            if (this.IPrmGoodsBrcdUpdDB == null)
            {
                this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
            }

            // ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���o
            object resultList = null;
            status = this.IPrmGoodsBrcdUpdDB.Search( ref prmPartsTargetList, out resultList );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                prmGoodsBrcdList = resultList as ArrayList;
                if (prmGoodsBrcdList == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else if (prmGoodsBrcdList.Count <= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else if (!( prmGoodsBrcdList[0] is GoodsBarCodeRevnWork ))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        #endregion //�y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���擾

        #region ���擾�T�u���\�b�h

        /// <summary>
        /// �ċA�^��񃊃X�g�擾����
        /// </summary>
        /// <param name="searchParamList">�擾�Ώۃp�����[�^���X�g</param>
        /// <param name="getSearchCountMethod">���o�����擾�������\�b�h</param>
        /// <param name="searchMethod">���o�������\�b�h</param>
        /// <param name="resultList">�擾��񃊃X�g</param>
        /// <param name="doRecursionFlag">�ċA�ďo�w��t���O[true:����Afalse:���Ȃ�]</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �擾�Ώۃp�����[�^���X�g�̏����ɍ��v����������X�g�Ŏ擾����</br>
        /// <br>             ���s���钊�o�����擾�������\�b�h�y�ђ��o�������\�b�h�̓p�����[�^�Ŏw�肷��</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int SearchListProc( 
            ref ArrayList searchParamList
            , PrmGoodsBarCodeRevnUpdateAcs.GetSearchCountDelegate getSearchCountMethod
            , PrmGoodsBarCodeRevnUpdateAcs.SearchDelegate searchMethod
            , out ArrayList resultList
            , bool doRecursionFlag )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int count = 0;

            resultList = null;

            // ���o�����擾
            status = getSearchCountMethod((object)searchParamList, out count );

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            if (count == 0)
            {
                resultList = new ArrayList();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else if (count > PrmGoodsBarCodeRevnUpdateAcs.MaxExecuteCount)
            {
                status = (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver;
                // ���o�������擾�\�ő僌�R�[�h���𒴂���ꍇ
                if (!doRecursionFlag)
                {
                    // �ċA�t���O��false�̏ꍇ�A�߂�l�Ƃ��Ď擾�\�ő僌�R�[�h�����߂�Ԃ�
                    return status;
                }
                else
                {
                    // �ċA�t���O��false�̏ꍇ�A���o���������[�J�[���ɕ������Ď擾����B
                    resultList = new ArrayList();

                    // ���o���������[�J�[���ɕ���
                    List<ArrayList> splitParam = this.SplitPrmPartsTargetList( ref searchParamList );
                    if (splitParam == null || splitParam.Count <= 0)
                    {
                        // �����ł��Ȃ������ꍇ�A�������f
                        return status;
                    }

                    // ���[�J�[���ɒ��o����
                    for (int index = 0; index < splitParam.Count; index++)
                    {
                        ArrayList paramList = splitParam[index];
                        ArrayList splitResultList = null;

                        //�{���\�b�h���ċA�Ăяo��
                        status = this.SearchListProc( ref paramList, getSearchCountMethod, searchMethod, out splitResultList, false );
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            resultList.AddRange( splitResultList );
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            continue;
                        }
                        else
                        {
                            resultList = null;
                            return status;
                        }
                    }
                }
            }
            else
            {
                // ���o�������擾�\�ő僌�R�[�h���ȓ��̏ꍇ�A���o�������s
                status = searchMethod( (object)searchParamList, out resultList);
            }

            return status;
        }
        
        /// <summary>
        /// ���[�J�[�ʎ擾�Ώۃp�����[�^���X�g����
        /// </summary>
        /// <param name="prmPartsTargetList">�擾�Ώۃp�����[�^���X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �擾�Ώۃp�����[�^���X�g���烁�[�J�[�ʂ̎擾�Ώۃp�����[�^���X�g�𐶐�����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private List<ArrayList> SplitPrmPartsTargetList( ref ArrayList prmPartsTargetList )
        {
            List<ArrayList> splitList = new List<ArrayList>();
            Dictionary<int, int> splitDic = new Dictionary<int, int>();

            foreach (object element in prmPartsTargetList)
            {
                GetPrmPartsBrcdParaWork work = element as GetPrmPartsBrcdParaWork;
                if (work == null)
                {
                    continue;
                }
                int index = -1;
                if (!splitDic.ContainsKey( work.MakerCode ))
                {
                    splitList.Add( new ArrayList() );
                    splitDic.Add( work.MakerCode, splitList.Count - 1 );
                }
                index = splitDic[work.MakerCode];
                GetPrmPartsBrcdParaWork copyWork = new GetPrmPartsBrcdParaWork();
                copyWork.EnterpriseCode = work.EnterpriseCode;
                copyWork.MakerCode = work.MakerCode;
                copyWork.BLGoodsCode = work.BLGoodsCode;
                splitList[index].Add( copyWork );
            }

            return splitList;
        }

        #endregion //���擾�T�u���\�b�h

        #region �y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V

        /// <summary>
        /// �y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V�p���X�g����
        /// </summary>
        /// <param name="updateParam">�X�V�p�����[�^</param>
        /// <param name="prmGoodsBrcdList">���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���X�g</param>
        /// <param name="offerPrmPartsBrcdList">��DB���D�Ǖ��i�o�[�R�[�h��񃊃X�g</param>
        /// <param name="updateList">�X�V�p���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���X�g</param>
        /// <param name="resultTextList">�X�V���X�g�쐬���v�f�ʔ��茋�ʁi���g�p�j</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ��DB���D�Ǖ��i�o�[�R�[�h��񃊃X�g�ƃ��[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���X�g����</br>
        /// <br>             ���[�U�[DB�����i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V�p�̃��X�g�i�ȉ��A�X�V���X�g �ƕ\�L�j�𐶐�</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int CreateUpdateList( 
              ref PrmGoodsBrcdUpdateParamWork updateParam
            , ref ArrayList prmGoodsBrcdList
            , ref ArrayList offerPrmPartsBrcdList
            , out ArrayList updateList
            , out StringBuilder resultTextList
            , bool autoFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            updateList = null;
            resultTextList = new StringBuilder();

            //offerPrmPartsBrcdList�̊e�v�f�ɂ��āA�������s��
            for (int index = 0; index < offerPrmPartsBrcdList.Count; index++)
            {
                //�X�V�p���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j��񏉊���
                GoodsBarCodeRevnWork updateWork = null;

                //�D�Ǖ��i�o�[�R�[�h���̎擾
                RettPrmPartsBrcdInfoWork offerPrmPartsBrcd = offerPrmPartsBrcdList[index] as RettPrmPartsBrcdInfoWork;
                if (offerPrmPartsBrcd == null)
                {
                    continue;
                }

                //prmGoodsBrcdList�̗v�f����D�Ǖ��i�o�[�R�[�h���ɍ��v����v�f���擾����
                foreach (object userWork in prmGoodsBrcdList)
                {
                    //���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���̎擾
                    GoodsBarCodeRevnWork prmGoodsBrcd = userWork as GoodsBarCodeRevnWork;
                    if (prmGoodsBrcd == null)
                    {
                        continue;
                    }
                    //�Ώۂ̗D�Ǖ��i�o�[�R�[�h���ƍ��v���鏤�i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j��񂩔ۂ���r����
                    if (prmGoodsBrcd.GoodsMakerCd != offerPrmPartsBrcd.PartsMakerCd)
                    {
                        continue;
                    }
                    if (prmGoodsBrcd.GoodsNo != offerPrmPartsBrcd.PrimePartsNoWithH)
                    {
                        continue;
                    }
                    //�Ώۂ̗D�Ǖ��i�o�[�R�[�h���ƍ��v���鏤�i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j��񂩑��݂����ꍇ�A
                    //�X�V�p���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j���𐶐�����
                    updateWork = new GoodsBarCodeRevnWork();
                    updateWork.CreateDateTime = prmGoodsBrcd.CreateDateTime;
                    updateWork.UpdateDateTime = prmGoodsBrcd.UpdateDateTime;
                    updateWork.EnterpriseCode = prmGoodsBrcd.EnterpriseCode;
                    updateWork.FileHeaderGuid = prmGoodsBrcd.FileHeaderGuid;
                    updateWork.UpdEmployeeCode = prmGoodsBrcd.UpdEmployeeCode;
                    updateWork.UpdAssemblyId1 = prmGoodsBrcd.UpdAssemblyId1;
                    updateWork.UpdAssemblyId2 = prmGoodsBrcd.UpdAssemblyId2;
                    updateWork.LogicalDeleteCode = prmGoodsBrcd.LogicalDeleteCode;
                    updateWork.GoodsMakerCd = prmGoodsBrcd.GoodsMakerCd;
                    updateWork.GoodsNo = prmGoodsBrcd.GoodsNo;
                    updateWork.GoodsBarCode = prmGoodsBrcd.GoodsBarCode;
                    updateWork.GoodsBarCodeKind = prmGoodsBrcd.GoodsBarCodeKind;
                    updateWork.CheckdigitCode = prmGoodsBrcd.CheckdigitCode;
                    updateWork.OfferDate = prmGoodsBrcd.OfferDate;
                    updateWork.OfferDataDiv = prmGoodsBrcd.OfferDataDiv;
                    break;
                }

                //�X�V�p���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j��񂪐�������Ă��邩�ۂ��ŏ�����U�蕪��
                if (updateWork == null)
                {
                    //�X�V�p���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j��񂪐�������Ă��Ȃ��ꍇ�A�V�K�ǉ�
                    updateWork = new GoodsBarCodeRevnWork();

                    if (autoFlag)
                    {
                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)updateWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    updateWork.EnterpriseCode = updateParam.EnterpriseCode;
                    updateWork.UpdAssemblyId1 = updateWork.UpdAssemblyId2;
                    updateWork.UpdEmployeeCode = updateWork.UpdEmployeeCode;
                    updateWork.LogicalDeleteCode = PrmGoodsBarCodeRevnUpdateAcs.LogicalDeleteCodeValidity;
                    updateWork.GoodsMakerCd = offerPrmPartsBrcd.PartsMakerCd;
                    updateWork.GoodsNo = offerPrmPartsBrcd.PrimePartsNoWithH;
                    updateWork.GoodsBarCode = offerPrmPartsBrcd.PrimePartsBarCode;
                    updateWork.GoodsBarCodeKind = offerPrmPartsBrcd.PrimePrtsBarCdKndDiv;
                    updateWork.CheckdigitCode = PrmGoodsBarCodeRevnUpdateAcs.CheckdigitCodeDefault;
                    updateWork.OfferDate = offerPrmPartsBrcd.OfferDate;
                    updateWork.OfferDataDiv = PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault;
                }
                else if (updateParam.BarcodeUpdateKndDiv == (int)PrmGoodsBarCodeRevnUpdateAcs.BarcodeUpdateKndDiv.WithoutUserUpdate
                    && updateWork.OfferDataDiv != PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault)
                {
                    // �񋟃f�[�^�敪��[0:���[�U�[�X�V]�ł��A�o�[�R�[�h�X�V�敪��[0:���[�U�[�X�V�ȊO]�̏ꍇ�X�V�ΏۊO
                    updateWork = null;
                    continue;
                }
                else if (updateWork.OfferDataDiv == PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault
                    && updateWork.OfferDate == offerPrmPartsBrcd.OfferDate
                    && updateWork.GoodsBarCode == offerPrmPartsBrcd.PrimePartsBarCode
                    && updateWork.GoodsBarCodeKind == offerPrmPartsBrcd.PrimePrtsBarCdKndDiv)
                {
                    // �񋟃f�[�^�敪��[0:���[�U�[�X�V]�ł��A�񋟃f�[�^�̏��ōX�V�ς݂̏ꍇ�X�V�ΏۊO
                    // ���񋟓��t�A���i�o�[�R�[�h���A�o�[�R�[�h��ʂ����������̏ꍇ
                    updateWork = null;
                    continue;
                }
                else
                {
                    if (autoFlag)
                    {
                        //�X�V�w�b�_�����擾
                        object obj = (object)this;
                        GoodsBarCodeRevnWork dummyWork = new GoodsBarCodeRevnWork();
                        IFileHeader flhd = (IFileHeader)dummyWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        updateWork.UpdAssemblyId1 = dummyWork.UpdAssemblyId2;
                        updateWork.UpdEmployeeCode = dummyWork.UpdEmployeeCode;
                    }
                    updateWork.EnterpriseCode = updateParam.EnterpriseCode;
                    updateWork.GoodsBarCode = offerPrmPartsBrcd.PrimePartsBarCode;
                    updateWork.GoodsBarCodeKind = offerPrmPartsBrcd.PrimePrtsBarCdKndDiv;
                    updateWork.CheckdigitCode = PrmGoodsBarCodeRevnUpdateAcs.CheckdigitCodeDefault;
                    updateWork.OfferDate = offerPrmPartsBrcd.OfferDate;
                    updateWork.OfferDataDiv = PrmGoodsBarCodeRevnUpdateAcs.OfferDataDivDefault;
                }

                if (updateWork != null)
                {
                    if (updateList == null)
                        updateList = new ArrayList();
                    updateList.Add( updateWork );
                }
            }

            if (updateList != null && updateList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// �y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V
        /// </summary>
        /// <param name="barcodeUpdateKndDiv">�o�[�R�[�h�X�V�敪</param>
        /// <param name="prmGoodsBrcdUpdateList">���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V���X�g</param>
        /// <param name="count">�X�V����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�i�o�[�R�[�h�X�V���������[�g�̏��i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V���������s����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int UpdatePrmGoodsBrcdList( ref ArrayList prmGoodsBrcdUpdateList, int barcodeUpdateKndDiv, out int count )
        {
            count = 0;
            return this.UpdatePrmGoodsBrcdList( ref prmGoodsBrcdUpdateList, barcodeUpdateKndDiv, out count, true );
        }

        /// <summary>
        /// �y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V
        /// </summary>
        /// <param name="prmGoodsBrcdUpdateList">���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V���X�g</param>
        /// <param name="barcodeUpdateKndDiv">�o�[�R�[�h�X�V�敪</param>
        /// <param name="count">�X�V����</param>
        /// <param name="doRecursionFlag">�ċA�ďo�w��t���O[true:����Afalse:���Ȃ�]</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���i�i�o�[�R�[�h�X�V���������[�g�̏��i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V���������s����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        private int UpdatePrmGoodsBrcdList( ref ArrayList prmGoodsBrcdUpdateList, int barcodeUpdateKndDiv, out int count, bool doRecursionFlag )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            count = 0;

            if (prmGoodsBrcdUpdateList.Count > PrmGoodsBarCodeRevnUpdateAcs.MaxExecuteCount)
            {
                status = (int)PrmGoodsBarCodeRevnUpdateAcs.StatusCode.ReadCountMaxOrver;
                // �X�V���X�g�v�f���������\�ő僌�R�[�h���𒴂���ꍇ
                if (!doRecursionFlag)
                {
                    // �ċA�t���O��false�̏ꍇ�A�߂�l�Ƃ��Ď擾�\�ő僌�R�[�h�����߂�Ԃ�
                    return status;
                }

                // 20000���P�ʂōX�V���������s����
                int startIndex = 0;
                int untreatedCount = prmGoodsBrcdUpdateList.Count;
                int executeCount = PrmGoodsBarCodeRevnUpdateAcs.MaxExecuteCount;
                while (untreatedCount > 0)
                {
                    if (untreatedCount < executeCount)
                    {
                        executeCount = untreatedCount;
                    }
                    untreatedCount -= executeCount;

                    ArrayList updateList = new ArrayList();
                    updateList.AddRange( prmGoodsBrcdUpdateList.GetRange( startIndex, executeCount ) );

                    // �{���\�b�h���ċA�ďo
                    int excecCount = 0;
                    status = this.UpdatePrmGoodsBrcdList( ref updateList, barcodeUpdateKndDiv, out excecCount, false );
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                    count += excecCount;
                    startIndex += executeCount;
                }
            }
            else
            {
                // �X�V���X�g�v�f���������\�ő僌�R�[�h���A�X�V�������s

                // ���i�o�[�R�[�h�X�V�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X�̎擾
                if (this.IPrmGoodsBrcdUpdDB == null)
                {
                    this.IPrmGoodsBrcdUpdDB = MediationIPrmGoodsBarCodeRevnUpdateDB.GetIPrmGoodsBarCodeRevnUpdateDB();
                }

                // ���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V
                object updateParamList = (object)prmGoodsBrcdUpdateList;
                status = this.IPrmGoodsBrcdUpdDB.UpdateGoodsBarcodeRevn( ref updateParamList, out count, ref barcodeUpdateKndDiv );
            }

            return status;
        }

        #endregion //�y���[�U�[DB�z���i�o�[�R�[�h�֘A�t���}�X�^�i���[�U�[�f�[�^�j�X�V

        #endregion //�� Private Method

    }
}
