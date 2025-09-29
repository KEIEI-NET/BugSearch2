using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;

using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[�󎚈ʒuImport�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒuExport�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.11.08</br>
    /// <br></br>
    /// <br>UpdateNote	: 2008.06.09 22018 ��� ���b</br>
    /// <br>             :   PM.NS�����ύX�B</br>
    /// <br></br>
    /// <br>UpdateNote	: 2009.06.01 22018 ��� ���b</br>
    /// <br>             :   �敪�����[�̃C���|�[�g�ɑΉ�����ׁA�ꕔ�C���B</br>
    /// </remarks>
	public class FrePrtPSetImportAcs
	{
		#region Delegate
		/// <summary>
		/// ���R���[Export�C�x���g�n���h��
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <param name="frePrtExport">���R���[Export�N���X</param>
		/// <remarks>���R���[�󎚈ʒu�ݒ肪Export�����x�ɔ������܂��B</remarks>
		public delegate void FrePrtPSetImportEventHandler(int status, string errMsg, FrePrtExport frePrtExport, bool newWrite, List<int> slipKindList );
		#endregion

		#region Event
		/// <summary>���R���[Export�C�x���g</summary>
		public event FrePrtPSetImportEventHandler FrePrtPSetImported;
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ������ �e��A�N�Z�X�N���X ������
		// --------------------------------------------------------
		// ���R���[�󎚈ʒu���[�J���A�N�Z�X�N���X
		private FrePrtPosLocalAcs		_frePrtPosLocalAcs;
		// ���R���[�󎚈ʒu�A�N�Z�X�N���X
		private FrePrtPSetAcs			_frePrtPSetAcs;

		// --------------------------------------------------------
		// ������ �f�[�^�N���X ������
		// --------------------------------------------------------
		// ���R���[Export�N���XList
		private List<FrePrtExport>		_frePrtExportList;
		//
		private List<PrtItemGrpWork>	_prtItemGrpList;

		// --------------------------------------------------------
		// ������ ���̑����[�N�ϐ� ������
		// --------------------------------------------------------
		// �G���[���b�Z�[�W
		private string					_errorStr;
		// �������摜���ʐ��䕔�i
		private SFANL08235CF			_watermarkCmn;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public FrePrtPSetImportAcs()
		{
			// ���R���[�󎚈ʒu���[�J���A�N�Z�X�N���X
			_frePrtPosLocalAcs	= new FrePrtPosLocalAcs();
			// ���R���[�󎚈ʒu�A�N�Z�X�N���X
			_frePrtPSetAcs		= new FrePrtPSetAcs();
		}
		#endregion

		#region Property
		/// <summary>�G���[���b�Z�[�W</summary>
		/// <remarks>�ǂݎ���p</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>���R���[Export�N���XList</summary>
		public List<FrePrtExport> FrePrtExportList
		{
			get {
				if (_frePrtExportList == null)
					return new List<FrePrtExport>();
				else
					return _frePrtExportList;
			}
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// Export�t�@�C���Ǎ�����
		/// </summary>
		/// <param name="filePath">�t�@�C���p�X</param>
		/// <returns>�X�e�[�^�X</returns>
		public int ReadExportFile(string filePath)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				if (File.Exists(filePath))
				{
					_frePrtExportList = (List<FrePrtExport>)XmlByteSerializer.Deserialize(filePath, typeof(List<FrePrtExport>));
				}
				else
				{
					_errorStr = "�w�肵���G�N�X�|�[�g�t�@�C����������܂���ł����B";
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch (Exception ex)
			{
				_errorStr = "���R���[Export���Ǎ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�Import����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="directory">Import�Ώۃt�@�C���̃f�B���N�g��</param>
        /// <param name="exchangeDic">���[ID�ϊ��f�B�N�V���i��</param>
		/// <returns>�X�e�[�^�X</returns>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
        //public int Import(string enterpriseCode, string directory)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        public int Import( string enterpriseCode, string directory, Dictionary<string,string> exchangeDic )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
            bool updateFlag;
            List<int> slipPrtKindList = new List<int>();
            ArrayList retList;

            // �`�[����ݒ�̎擾
            # region [�`�[����ݒ�̎擾]
            SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
            List<SlipPrtSet> existsSlipPrtSetList = new List<SlipPrtSet>();

            if ( slipPrtSetAcs.SearchAllSlipPrtSet( out retList, enterpriseCode ) == 0)
            {
                foreach ( object obj in retList )
                {
                    if ( obj is SlipPrtSet )
                    {
                        existsSlipPrtSetList.Add( obj as SlipPrtSet );
                    }
                }
            }
            # endregion

            // ����������p�^�[��
            # region [����������p�^�[��]
            DmdPrtPtnAcs dmdPrtPtnAcs = new DmdPrtPtnAcs();
            List<DmdPrtPtn> existsDmdPrtPtnList = new List<DmdPrtPtn>();

            if ( dmdPrtPtnAcs.SearchAll( out retList, enterpriseCode ) == 0 )
            {
                foreach ( object obj in retList )
                {
                    if ( obj is DmdPrtPtn )
                    {
                        existsDmdPrtPtnList.Add( obj as DmdPrtPtn );
                    }
                }
            }
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD

            try
            {
                // �ۑ��Ώۂ��擾
                List<FrePrtExport> targetFrePrtExportList
                    = _frePrtExportList.FindAll(
                        delegate( FrePrtExport frePrtExport )
                        {
                            if ( frePrtExport.ExtractionItdedFlg == 1 )
                                return true;
                            else
                                return false;
                        }
                    );

                if ( targetFrePrtExportList != null && targetFrePrtExportList.Count > 0 )
                {
                    foreach ( FrePrtExport frePrtExport in targetFrePrtExportList )
                    {
                        string errMsg = string.Empty;
                        FrePrtPSet frePrtPSet;
                        List<FrePprECnd> frePprECndList;
                        List<FrePprSrtO> frePprSrtOList;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
                        updateFlag = false;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD

                        try
                        {
                            string filePath = Path.Combine( directory, frePrtExport.ExportDataFilePath );
                            status = _frePrtPosLocalAcs.ReadLocalFrePrtPSet( out frePrtPSet, out frePprECndList, out frePprSrtOList, filePath );
                            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                int userPrtPprIdDerivNo = _frePrtPSetAcs.GetUserPrtPprIdDerivNo( enterpriseCode, frePrtPSet.OutputFormFileName );
                                // ���R���[�󎚈ʒu�ݒ�
                                frePrtPSet.EnterpriseCode = enterpriseCode;
                                frePrtPSet.UpdateDateTime = DateTime.MinValue;
                                frePrtPSet.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                // �y���[�h�c�ϊ��z
                                # region [���[�h�c�ϊ�]
                                if ( exchangeDic != null )
                                {
                                    if ( exchangeDic.ContainsKey( frePrtPSet.OutputFormFileName ) )
                                    {
                                        frePrtPSet.OutputFormFileName = exchangeDic[frePrtPSet.OutputFormFileName];
                                    }
                                }
                                # endregion

                                // �y�㏑���X�V�Ή��z
                                # region [�㏑���X�V�Ή�]
                                // �c�a�̊����f�[�^�ǂݍ���
                                FrePrtPSet dbFrePrtPSet = new FrePrtPSet();
                                dbFrePrtPSet.EnterpriseCode = enterpriseCode;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                                //dbFrePrtPSet.OutputFormFileName = frePrtExport.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 ADD
                                dbFrePrtPSet.OutputFormFileName = frePrtPSet.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 ADD
                                dbFrePrtPSet.UserPrtPprIdDerivNo = frePrtExport.UserPrtPprIdDerivNo;

                                List<FrePprECnd> dbFrePprECndList;
                                List<FrePprSrtO> dbFrePprSrtOList;
                                
                                int dbStatus = _frePrtPSetAcs.ReadDBFrePrtPSet( ref dbFrePrtPSet, out dbFrePprECndList, out dbFrePprSrtOList );
                                if ( dbStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // ���ʃt�@�C���w�b�_��������
                                    frePrtPSet.CreateDateTime = dbFrePrtPSet.CreateDateTime;
                                    frePrtPSet.UpdateDateTime = dbFrePrtPSet.UpdateDateTime;
                                    frePrtPSet.EnterpriseCode = dbFrePrtPSet.EnterpriseCode;
                                    frePrtPSet.FileHeaderGuid = dbFrePrtPSet.FileHeaderGuid;
                                    frePrtPSet.UpdEmployeeCode = dbFrePrtPSet.UpdEmployeeCode;
                                    frePrtPSet.UpdAssemblyId1 = dbFrePrtPSet.UpdAssemblyId1;
                                    frePrtPSet.UpdAssemblyId2 = dbFrePrtPSet.UpdAssemblyId2;
                                    frePrtPSet.LogicalDeleteCode = dbFrePrtPSet.LogicalDeleteCode;
                                    // �X�V�t���O
                                    updateFlag = true;
                                }
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
                                // �Ώۓ`�[��ʃ��X�g
                                slipPrtKindList = new List<int>();

                                if ( frePrtExport.PrintPaperUseDivcd == 2 )
                                {
                                    # region [�`�[����ݒ�]
                                    // ���ɓo�^�ς݂̓`�[���
                                    List<int> existsKindList = new List<int>();
                                    foreach ( SlipPrtSet slipPrtSet in existsSlipPrtSetList )
                                    {
                                        int derivNo;
                                        try
                                        {
                                            derivNo = Int32.Parse( slipPrtSet.SpecialPurpose2 );
                                        }
                                        catch
                                        {
                                            derivNo = 0;
                                        }

                                        if ( slipPrtSet.OutputFormFileName == frePrtPSet.OutputFormFileName &&
                                             derivNo == frePrtPSet.UserPrtPprIdDerivNo )
                                        {
                                            existsKindList.Add( slipPrtSet.SlipPrtKind );
                                        }
                                    }
                                    // ��ʂ̃`�F�b�N���ʂ���`�[��ʂ��擾�i�����̓`�[��ʂ͏��O����j
                                    switch ( frePrtExport.FreePrtPprSpPrpseCd )
                                    {
                                        case 1:
                                            if ( !existsKindList.Contains( 10 ) ) slipPrtKindList.Add( 10 ); // ���Ϗ�
                                            break;
                                        case 15:
                                            if ( !existsKindList.Contains( 150 ) ) slipPrtKindList.Add( 150 ); // �݌Ɉړ��`�[
                                            break;
                                        case 16:
                                            if ( !existsKindList.Contains( 160 ) ) slipPrtKindList.Add( 160 ); // �t�n�d�`�[
                                            break;
                                        case 0:
                                        default:
                                            if ( frePrtExport.SlipKindEntryDiv1 == 1 && !existsKindList.Contains( 140 ) ) slipPrtKindList.Add( 140 ); // ���ϓ`�[
                                            if ( frePrtExport.SlipKindEntryDiv2 == 1 && !existsKindList.Contains( 120 ) ) slipPrtKindList.Add( 120 ); // �󒍓`�[
                                            if ( frePrtExport.SlipKindEntryDiv3 == 1 && !existsKindList.Contains( 130 ) ) slipPrtKindList.Add( 130 ); // �ݏo�`�[
                                            if ( frePrtExport.SlipKindEntryDiv4 == 1 && !existsKindList.Contains( 30 ) ) slipPrtKindList.Add( 30 ); // ����`�[
                                            break;
                                    }
                                    # endregion
                                }
                                else if ( frePrtExport.PrintPaperUseDivcd == 5 )
                                {
                                    # region [����������p�^�[��]
                                    // ���ɓo�^�ς݂̓`�[���(������)
                                    List<int> existsKindList = new List<int>();

                                    foreach ( DmdPrtPtn dmdPrtPtn in existsDmdPrtPtnList )
                                    {
                                        if ( dmdPrtPtn.OutputFormFileName == frePrtPSet.OutputFormFileName )
                                        {
                                            existsKindList.Add( dmdPrtPtn.SlipPrtKind );
                                        }
                                    }

                                    switch ( frePrtExport.FreePrtPprSpPrpseCd )
                                    {
                                        case 50:
                                            // ���v������
                                            if ( !existsKindList.Contains( 50 ) ) slipPrtKindList.Add( 50 );
                                            break;
                                        case 60:
                                            // ���א�����
                                            if ( !existsKindList.Contains( 60 ) ) slipPrtKindList.Add( 60 );
                                            break;
                                        case 70:
                                            // �`�[���v������
                                            if ( !existsKindList.Contains( 70 ) ) slipPrtKindList.Add( 70 );
                                            break;
                                        case 80:
                                            // �̎���
                                            if ( !existsKindList.Contains( 80 ) ) slipPrtKindList.Add( 80 );
                                            break;
                                    }
                                    # endregion
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                                //if ( frePprECndList == null ) frePprECndList = new List<FrePprECnd>();
                                //if ( frePprSrtOList == null ) frePprSrtOList = new List<FrePprSrtO>();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 ADD
                                frePprECndList = new List<FrePprECnd>();
                                frePprSrtOList = new List<FrePprSrtO>();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 ADD

                                // ----------------------------------------------------
                                // ���@�l�o�^�p�Ɉꕔ�f�[�^�̏�������
                                // ----------------------------------------------------

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //int userPrtPprIdDerivNo = _frePrtPSetAcs.GetUserPrtPprIdDerivNo(enterpriseCode, frePrtPSet.OutputFormFileName);
                                //// ���R���[�󎚈ʒu�ݒ�
                                //frePrtPSet.EnterpriseCode = enterpriseCode;
                                //frePrtPSet.UpdateDateTime = DateTime.MinValue;
                                //frePrtPSet.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/01 DEL
                                //// ���R���[���o����
                                //foreach ( FrePprECnd frePprECnd in frePprECndList )
                                //{
                                //    frePprECnd.EnterpriseCode = enterpriseCode;
                                //    frePprECnd.UpdateDateTime = DateTime.MinValue;
                                //    frePprECnd.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                //}
                                //// ���R���[�\�[�g����
                                //foreach ( FrePprSrtO frePprSrtO in frePprSrtOList )
                                //{
                                //    frePprSrtO.EnterpriseCode = enterpriseCode;
                                //    frePprSrtO.UpdateDateTime = DateTime.MinValue;
                                //    frePprSrtO.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/01 DEL

                                // ----------------------------------------------------
                                // �����[�e�B���O
                                // ----------------------------------------------------
                                // ���[�敪���`�[�̏ꍇ�͓`�[����ݒ�}�X�^�������ɓo�^
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //if ( frePrtExport.PrintPaperUseDivcd == 2 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                if ( frePrtExport.PrintPaperUseDivcd == 2 && slipPrtKindList.Count > 0)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                {
                                    if ( _prtItemGrpList == null )
                                    {
                                        PrtItemGrpAcs prtItemGrpAcs = new PrtItemGrpAcs();
                                        status = prtItemGrpAcs.SearchPrtItemGrpWork( out _prtItemGrpList );
                                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            errMsg = prtItemGrpAcs.ErrorMessage;
                                    }

                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        List<SlipPrtSetWork> slipPrtSetList = FrePrtPSetAcs.CreateSlipPrtSet( slipPrtKindList, frePrtPSet, _prtItemGrpList );

                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/09 DEL
                                        //status = _frePrtPSetAcs.WriteDBFrePrtPSet(ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, slipPrtSetList, true);
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/09 DEL
                                        status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, slipPrtSetList, new List<DmdPrtPtnWork>(), true );
                                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            errMsg = _frePrtPSetAcs.ErrorMessage;
                                    }
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                                // ���[�敪���������̏ꍇ�͐���������p�^�[���ݒ�������ɓo�^
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //else if ( frePrtExport.PrintPaperUseDivcd == 5 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                else if ( frePrtExport.PrintPaperUseDivcd == 5 && slipPrtKindList.Count > 0 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                {
                                    if ( _prtItemGrpList == null )
                                    {
                                        PrtItemGrpAcs prtItemGrpAcs = new PrtItemGrpAcs();
                                        status = prtItemGrpAcs.SearchPrtItemGrpWork( out _prtItemGrpList );
                                        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            errMsg = prtItemGrpAcs.ErrorMessage;
                                    }

                                    List<DmdPrtPtnWork> dmdPrtPtnList = FrePrtPSetAcs.CreateDmdPrtPtnList( frePrtPSet, _prtItemGrpList );

                                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, new List<SlipPrtSetWork>(), dmdPrtPtnList, true );
                                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                        errMsg = _frePrtPSetAcs.ErrorMessage;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
                                else
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                    //status = _frePrtPSetAcs.WriteDBFrePrtPSet(ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, true);
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, !updateFlag );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                        errMsg = _frePrtPSetAcs.ErrorMessage;
                                }
                            }
                            else
                            {
                                errMsg = _frePrtPosLocalAcs.ErrorMessage;
                            }
                        }
                        catch ( Exception ex )
                        {
                            errMsg = "���R���[Import�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        finally
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 DEL
                            //this.FrePrtPSetImported(status, errMsg, frePrtExport);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/10 ADD
                            this.FrePrtPSetImported( status, errMsg, frePrtExport, !updateFlag, slipPrtKindList );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/10 ADD
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "���R���[Import�����ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
		#endregion
	}
}
