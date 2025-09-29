using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �񋟎d����e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����i�񋟁j�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2008.10.30</br>
    /// </remarks>
    public class OfrSupplierAcs : IGeneralGuideData
    {
        # region [private �t�B�[���h]
        private IOfrSupplierDB _iOfrSupplierDB = null;

        // �K�C�h�ݒ�t�@�C����
        private const string GUIDE_XML_FILENAME = "OFRSUPPLIERGUIDEPARENT.XML";   // XML�t�@�C����

        // �K�C�h�p�����[�^
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";  // (�p�����[�^)��ƃR�[�h
        private const string GUIDE_MNGSECTIONCODE_PARA = "MngSectionCode";  // (�p�����[�^)�Ǘ����_�R�[�h

        // �K�C�h���ڃ^�C�v
        private const string GUIDE_TYPE_STR = "System.String";              // String�^

        // �K�C�h����
        private const string GUIDE_OFFERDATE_TITLE = "OfferDate"; // �񋟓��t
        private const string GUIDE_SUPPLIERCD_TITLE = "SupplierCd"; // �d����R�[�h
        private const string GUIDE_SUPPLIERNM1_TITLE = "SupplierNm1"; // �d���於1
        private const string GUIDE_SUPPLIERKANA_TITLE = "SupplierKana"; // �d����J�i
        private const string GUIDE_SUPPLIERSNM_TITLE = "SupplierSnm"; // �d���旪��        
        private const string GUIDE_SUPPLIERCD_ZERO_TITLE = "SupplierCdZero"; // �d����R�[�h(�[���l��)

        // �R�[�h�t�H�[�}�b�g
        private string _supplierCodeFormat;

        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public OfrSupplierAcs()
        {
            // �d����R�[�h�t�H�[�}�b�g�擾(�A�N�Z�X�N���X�p)
            UiSetFileAcs uiSetFileAcs = new UiSetFileAcs();
            uiSetFileAcs.ReadXML( string.Empty );
            UiSet uiset = uiSetFileAcs.GetUiSet( string.Empty, "tNedit_SupplierCd" );
            if ( uiset != null )
            {
                _supplierCodeFormat = new string( '0', uiset.Column );
            }
            else
            {
                _supplierCodeFormat = string.Empty;
            }
        }
        # endregion


        # region [public ���\�b�h]
        /// <summary>
        /// �񋟎d����ǂݍ��ݏ���
        /// </summary>
        /// <param name="ofrSupplier">�d����I�u�W�F�N�g</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d�������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Read( out OfrSupplier ofrSupplier, int supplierCode )
        {
            try
            {
                ofrSupplier = new OfrSupplier();
                int status = 0;
                OfrSupplierWork paraWork = new OfrSupplierWork();
                paraWork.SupplierCd = supplierCode;
                object retObj;

                if ( _iOfrSupplierDB == null )
                {
                    _iOfrSupplierDB = MediationOfrSupplierDB.GetOfrSupplierDB();
                }
                status = this._iOfrSupplierDB.Read( out retObj, paraWork );

                if ( status == 0 )
                {
                    // �N���X�������o�R�s�[
                    ofrSupplier = CopyToOfrSupplierFromOfrSupplierWork( (OfrSupplierWork)retObj );
                }
                return status;
            }
            catch ( Exception )
            {
                //�ʐM�G���[��-1��߂�
                ofrSupplier = null;
                //�I�t���C������null���Z�b�g
                this._iOfrSupplierDB = null;
                return -1;
            }
        }
        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="ofrSupplier">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        public int ExecuteGuid( out OfrSupplier ofrSupplier )
        {
            int status = -1;
            ofrSupplier = new OfrSupplier();

            TableGuideParent tableGuideParent = new TableGuideParent( GUIDE_XML_FILENAME );
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // �K�C�h�N��
            if ( tableGuideParent.Execute( 0, inObj, ref retObj ) )
            {
                // �I���f�[�^�̎擾
                ofrSupplier = CopyToOfrSupplierFromGuideData( retObj );
                status = 0;
            }
            else
            {
                // �L�����Z��
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�R�s�[����
        /// </summary>
        /// <param name="retObj"></param>
        /// <returns></returns>
        private OfrSupplier CopyToOfrSupplierFromGuideData( Hashtable retObj )
        {
            OfrSupplier ofrSupplier = new OfrSupplier();

            ofrSupplier.OfferDate = (DateTime)retObj["OfferDate"];
            ofrSupplier.SupplierCd = (int)retObj["SupplierCd"];
            ofrSupplier.SupplierKana = (string)retObj["SupplierKana"];
            ofrSupplier.SupplierNm1 = (string)retObj["SupplierNm1"];
            ofrSupplier.SupplierSnm = (string)retObj["SupplierSnm"];

            return ofrSupplier;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int GetGuideData( int mode, Hashtable inParm, ref DataSet guideList )
        {
            int status = -1;

            // �}�X�^�e�[�u���Ǎ���
            ArrayList retList;
            status = this.SearchOffer( out retList);

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // �K�C�h�����N����
                    if ( guideList.Tables.Count == 0 )
                    {
                        // �K�C�h�p�f�[�^�Z�b�g����\�z
                        this.GuideDataSetColumnConstruction( ref guideList );
                    }

                    // �K�C�h�p�f�[�^�Z�b�g�̍쐬
                    this.GetGuideDataSet( ref guideList, retList, inParm );

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = 4;
                    break;
                default:
                    status = -1;
                    break;
            }

            return status;
        }
        /// <summary>
        /// �񋟎d���挟������
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="retTotalCnt"></param>
        /// <returns></returns>
        public int SearchOffer( out ArrayList retList, out int retTotalCnt )
        {
            return SearchProcOfOffer( out retList, out retTotalCnt );
        }
        /// <summary>
        /// �񋟎d���挟������
        /// </summary>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int SearchOffer( out ArrayList retList )
        {
            int retTotalCnt;
            return SearchProcOfOffer( out retList, out retTotalCnt );
        }
        # endregion

        # region [private ���\�b�h]
        /// <summary>
        /// �񋟎d���挟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSupplier��null�̏ꍇ�̂ݖ߂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����̌����������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        private int SearchProcOfOffer( out ArrayList retList, out int retTotalCnt )
        {
            // ������
            retList = new ArrayList();
            retTotalCnt = 0;

            // �߂�l���X�g
            ArrayList wkList = new ArrayList();

            // ���������Z�b�g
            OfrSupplierWork ofrSupplierWork = new OfrSupplierWork();

            // Search�p�����[�^
            ArrayList paraList = new ArrayList();
            paraList.Add( ofrSupplierWork );
            object paraobj = paraList;

            // ����
            object retobj = null;

            int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �����[�g
            if ( _iOfrSupplierDB == null )
            {
                _iOfrSupplierDB = MediationOfrSupplierDB.GetOfrSupplierDB();
            }
            status_o = this._iOfrSupplierDB.Search( out retobj, paraobj ); 

            // �������ʔ���
            switch ( status_o )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    wkList = retobj as ArrayList;

                    if ( wkList != null )
                    {
                        foreach ( OfrSupplierWork wkLineupWork in wkList )
                        {
                            //�����o�R�s�[
                            retList.Add( CopyToOfrSupplierFromOfrSupplierWork( wkLineupWork ) );
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status_o;
            }

            return status_o;
        }
        /// <summary>
        /// �񋟎d����f�[�^�R�s�[
        /// </summary>
        /// <param name="ofrSupplierWork"></param>
        /// <returns></returns>
        private OfrSupplier CopyToOfrSupplierFromOfrSupplierWork( OfrSupplierWork ofrSupplierWork )
        {
            OfrSupplier ofrSupplier = new OfrSupplier();

            # region [OfrSupplier]
            ofrSupplier.OfferDate = GetDateTime( ofrSupplierWork.OfferDate ); // �񋟓��t
            ofrSupplier.SupplierCd = ofrSupplierWork.SupplierCd; // �d����R�[�h
            ofrSupplier.SupplierNm1 = ofrSupplierWork.SupplierNm1; // �d���於1
            ofrSupplier.SupplierKana = ofrSupplierWork.SupplierKana; // �d����J�i
            ofrSupplier.SupplierSnm = ofrSupplierWork.SupplierSnm; // �d���旪��
            # endregion
            
            return ofrSupplier;
        }
        /// <summary>
        /// ���t�擾
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime GetDateTime( int longDate )
        {
            if ( longDate == 0 )
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return new DateTime( (longDate / 10000), (longDate / 100) % 100, (longDate % 100) );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g�쐬����
        /// </summary>
        /// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
        /// <param name="retList">���ʎ擾�A���C���X�g</param>>
        /// <param name="inParm">�i������</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GetGuideDataSet( ref DataSet retDataSet, ArrayList retList, Hashtable inParm )
        {
            OfrSupplier ofrSupplier = null;
            DataRow guideRow = null;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while ( dataCnt < retList.Count )
            {
                ofrSupplier = (OfrSupplier)retList[dataCnt];
                guideRow = retDataSet.Tables[0].NewRow();
                // �f�[�^�R�s�[����
                CopyToGuideRowFromOfrSupplier( ref guideRow, ofrSupplier );
                // �f�[�^�ǉ�
                retDataSet.Tables[0].Rows.Add( guideRow );
                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// �K�C�h�f�[�^�R�s�[����
        /// </summary>
        /// <param name="guideRow"></param>
        /// <param name="obj"></param>
        private void CopyToGuideRowFromOfrSupplier( ref DataRow guideRow, object obj )
        {
            OfrSupplier ofrSupplier = (OfrSupplier)obj;

            guideRow[GUIDE_OFFERDATE_TITLE] = ofrSupplier.OfferDate; // �񋟓��t
            guideRow[GUIDE_SUPPLIERCD_TITLE] = ofrSupplier.SupplierCd; // �d����R�[�h
            guideRow[GUIDE_SUPPLIERNM1_TITLE] = ofrSupplier.SupplierNm1; // �d���於1
            guideRow[GUIDE_SUPPLIERKANA_TITLE] = ofrSupplier.SupplierKana; // �d����J�i
            guideRow[GUIDE_SUPPLIERSNM_TITLE] = ofrSupplier.SupplierSnm; // �d���旪��

            guideRow[GUIDE_SUPPLIERCD_ZERO_TITLE] = ofrSupplier.SupplierCd.ToString( _supplierCodeFormat );
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="guideList">�K�C�h�p�f�[�^�Z�b�g</param>>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction( ref DataSet guideList )
        {
            DataTable table = new DataTable();

            # region [�K�C�h�p�e�[�u�������i���������j]
            // �\���p�d����R�[�h(�[���l��)
            table.Columns.Add( GUIDE_SUPPLIERCD_ZERO_TITLE, typeof( string ) );
            // �񋟓��t
            table.Columns.Add( GUIDE_OFFERDATE_TITLE, typeof( DateTime ) );
            // �d����R�[�h
            table.Columns.Add( GUIDE_SUPPLIERCD_TITLE, typeof( Int32 ) );
            // �d���於1
            table.Columns.Add( GUIDE_SUPPLIERNM1_TITLE, typeof( string ) );
            // �d����J�i
            table.Columns.Add( GUIDE_SUPPLIERKANA_TITLE, typeof( string ) );
            // �d���旪��
            table.Columns.Add( GUIDE_SUPPLIERSNM_TITLE, typeof( string ) );
            # endregion

            // �e�[�u���R�s�[
            guideList.Tables.Add( table.Clone() );
        }
        # endregion
    }
}
